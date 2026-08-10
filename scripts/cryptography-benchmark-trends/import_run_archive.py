#!/usr/bin/env python3
# SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
# SPDX-License-Identifier: MIT
"""
Builds the Cryptography trends database from the benchmark run archive.

The archive is a directory tree, one directory per run and one per platform inside it:

    cryptography/<code-commit>/<platform>/run.json
    cryptography/<code-commit>/<platform>/machine-spec.md
    cryptography/<code-commit>/<platform>/aes-cbc-128.md
    ...

It lives on the `benchmarks` branch, kept out of main so that recording a run does not add to the
working tree everyone clones. Point --archive at a worktree of that branch, or at any directory
holding the same layout. Sibling of scripts/threading-benchmark-trends/import_run_archive.py -
same design, adapted for Cryptography's data shape (a category per file, and a data-size axis
instead of a contention level).

Why a directory per run rather than one path overwritten per run, which is what
import_historical_markdown.py has to cope with:

- The tree is the archive. Listing directories replaces replaying 1,149 file-revisions across 25
  commits, so this reads the same data without git history at all - which matters because CI
  checks out shallow (fetch-depth 1) and would otherwise see nothing.
- A run's metadata is durable. Under the old layout only the newest run's run.json would survive,
  because every later run overwrote the same path; here nothing is ever overwritten.
- A run can be corrected or withdrawn by editing one directory, instead of rewriting history.

Usage:
    python import_run_archive.py --archive ../foundation-bench --db path/to/benchmark-history.sqlite
"""

import argparse
import json
import os
import sqlite3
import sys

SCRIPT_DIR = os.path.dirname(os.path.abspath(__file__))
sys.path.insert(0, SCRIPT_DIR)

from import_historical_markdown import (  # noqa: E402
    classify_category,
    parse_machine_spec,
    parse_markdown_table,
)

PACKAGE_DIR = "cryptography"
NON_SCENARIO_FILES = {"machine-spec.md", "run.json", "README.md", "benchmarks.md"}


def discover_runs(archive_root):
    """Yields (run_id, platform, run_dir, metadata) for every run-platform, oldest first.

    Ordered by the run date declared in run.json rather than by directory name: the directory is
    named for the commit measured, which says nothing about when it was measured.
    """
    package_root = os.path.join(archive_root, PACKAGE_DIR)
    if not os.path.isdir(package_root):
        raise SystemExit(f"No '{PACKAGE_DIR}' directory under {archive_root} - is this the archive root?")

    found = []
    for run_id in sorted(os.listdir(package_root)):
        run_root = os.path.join(package_root, run_id)
        if not os.path.isdir(run_root):
            continue
        for platform in sorted(os.listdir(run_root)):
            run_dir = os.path.join(run_root, platform)
            if not os.path.isdir(run_dir):
                continue
            metadata_path = os.path.join(run_dir, "run.json")
            if not os.path.isfile(metadata_path):
                print(f"  [skip] {run_id}/{platform}: no run.json", file=sys.stderr)
                continue
            with open(metadata_path, encoding="utf-8") as handle:
                metadata = json.load(handle)
            found.append((metadata.get("recordedAt", ""), run_id, platform, run_dir, metadata))

    found.sort(key=lambda entry: entry[0])
    for _date, run_id, platform, run_dir, metadata in found:
        yield run_id, platform, run_dir, metadata


def read_environment(run_dir):
    """The machine and runtime a run was measured on, or None when the run carries no spec."""
    path = os.path.join(run_dir, "machine-spec.md")
    if not os.path.isfile(path):
        return None
    with open(path, encoding="utf-8") as handle:
        return parse_machine_spec(handle.read())


def main():
    parser = argparse.ArgumentParser(description=__doc__,
                                     formatter_class=argparse.RawDescriptionHelpFormatter)
    parser.add_argument("--archive", required=True, help="Root of the run archive (a benchmarks-branch worktree)")
    parser.add_argument("--db", required=True, help="Path to the SQLite database (created if missing)")
    parser.add_argument("--dry-run", action="store_true", help="Parse and report without writing")
    args = parser.parse_args()

    with open(os.path.join(SCRIPT_DIR, "schema.sql"), encoding="utf-8") as handle:
        schema_sql = handle.read()

    conn = sqlite3.connect(args.db)
    conn.executescript(schema_sql)

    # Start from empty. The database is derived from the archive, so anything already in the file
    # is either about to be rewritten or is no longer true - a run withdrawn from the archive, or
    # rows keyed differently by an earlier version of the parser.
    #
    # INSERT OR REPLACE alone does not achieve this. param_label is part of the primary key and is
    # NULL for benchmarks with no [Params] axis, and SQLite treats NULLs in a key as distinct, so
    # those rows never match an existing one and every rebuild appends another copy. Locally that
    # grew the Threading database from 4,718 rows to 6,413 across four rebuilds, all of the excess
    # in unparameterised benchmarks. CI never saw it, because it always starts from a fresh
    # checkout with no database file.
    #
    # Deleting inside the same transaction as the inserts, rather than unlinking the file, means a
    # failed import leaves the previous database intact instead of an empty one.
    conn.execute("DELETE FROM benchmark_results")
    conn.execute("DELETE FROM benchmark_runs")

    total_rows = 0
    total_runs = 0
    for run_id, platform, run_dir, metadata in discover_runs(args.archive):
        run_date = metadata.get("recordedAt", "")
        commit_sha = metadata.get("codeCommit")
        branch = metadata.get("branch")

        run_rows = 0
        for filename in sorted(os.listdir(run_dir)):
            if filename in NON_SCENARIO_FILES or not filename.endswith(".md"):
                continue
            # Category is a property of which benchmark file this is (hash, cipher, mac), so it
            # is derived from the file name exactly as the history importer derives it.
            category = classify_category(filename)
            class_name = filename[:-3]
            with open(os.path.join(run_dir, filename), encoding="utf-8") as handle:
                content = handle.read()

            for row in parse_markdown_table(content):
                run_rows += 1
                if args.dry_run:
                    continue
                conn.execute(
                    "INSERT OR REPLACE INTO benchmark_results "
                    "(run_id, run_date, commit_sha, branch, platform, category, class_name, "
                    " method, family, variant, data_size_label, data_size_bytes, mean_ns, "
                    " stddev_ns, allocated_bytes) "
                    "VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)",
                    (run_id, run_date, commit_sha, branch, platform, category, class_name,
                     row["method"], row["family"], row["variant"], row["data_size_label"],
                     row["data_size_bytes"], row["mean_ns"], row["stddev_ns"],
                     row["allocated_bytes"]))

        # Recorded per (run, platform) so a step in a trend line can be checked against a runtime
        # or SDK change before being read as a code regression - the recorded runs span .NET 10.0.2
        # to 10.0.9 across three machines.
        environment = read_environment(run_dir)
        if environment and not args.dry_run:
            conn.execute(
                "INSERT OR REPLACE INTO benchmark_runs "
                "(run_id, platform, run_date, commit_sha, branch, bdn_version, os, cpu, "
                " logical_cores, physical_cores, sdk_version, runtime_version, jit) "
                "VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)",
                (run_id, platform, run_date, commit_sha, branch, environment["bdn_version"],
                 environment["os"], environment["cpu"], environment["logical_cores"],
                 environment["physical_cores"], environment["sdk_version"],
                 environment["runtime_version"], environment["jit"]))
        elif not environment:
            print(f"  [warn] {run_id}/{platform}: no machine-spec.md; environment not recorded",
                  file=sys.stderr)

        print(f"  [{'dry-run' if args.dry_run else 'ok'}] {run_id}/{platform}: {run_rows} row(s)")
        total_rows += run_rows
        total_runs += 1

    if not args.dry_run:
        conn.commit()
    conn.close()

    verb = "Would insert" if args.dry_run else "Inserted/updated"
    print(f"{verb} {total_rows} row(s) from {total_runs} run-platform(s) in {args.archive}")
    return 0


if __name__ == "__main__":
    raise SystemExit(main())
