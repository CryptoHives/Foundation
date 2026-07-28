#!/usr/bin/env python3
# SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
# SPDX-License-Identifier: MIT
"""
One-time backfill: walks git history for every commit that touched the (now-retired)
per-platform Threading benchmark markdown tables and imports each commit's numbers into the
trends SQLite database as its own dated run. Sibling of
scripts/cryptography-benchmark-trends/import_historical_markdown.py (Cryptography's) — same design, adapted
for Threading's different data shape (no category, contention level instead of data size).

Usage:
    python import_historical_markdown.py --db docfx/packages/threading/benchmark-trends/benchmark-history.sqlite

Design notes:
- Two eras of file layout, same as Cryptography's history:
    1. Flat: docfx/packages/threading/benchmarks/<scenario>.md (no platform folder).
    2. Platform-folder: docfx/packages/threading/benchmarks/<platform-id>/<scenario>.md,
       starting at commit 52374bf (2026-04-02) — confirmed via git log.
  Both eras ran on the same dev machine (AMD Ryzen 5 7600X per every machine-spec.md seen), so
  PLATFORM_FOR_FLAT_ERA applies retroactively, same reasoning as Cryptography's importer.
- The very earliest commit (d6ea9c1, 2026-01-09) predates ThreadingConfig's DescriptionColumn
  entirely — those files have a raw "Method" column with no family/variant breakdown possible.
  markdown_parser.parse_markdown_table() detects and skips these whole files.
- Unlike Cryptography, no NORMALIZE_VARIANT-style table is pre-populated here: Threading's
  mid-history Description taxonomy (commit 6dc2213, 2026-02-12) uses different label values than
  today, but which renames actually matter is discovered empirically by running this script and
  inspecting the distinct (family, variant) pairs per era — same iterative method used to build
  Cryptography's normalization tables, not something to guess blind. Add entries to
  NORMALIZE_VARIANT below as they're found.
"""

import os
import subprocess
import sys

SCRIPT_DIR = os.path.dirname(os.path.abspath(__file__))
REPO_ROOT = os.path.dirname(os.path.dirname(SCRIPT_DIR))
sys.path.insert(0, SCRIPT_DIR)

from markdown_parser import parse_markdown_table  # noqa: E402

PLATFORM_FOR_FLAT_ERA = "windows-x64-amd-ryzen-5-7600x"
BRANCH_FOR_HISTORY = "main"

PATHSPECS = [
    "docfx/packages/threading/benchmarks/*.md",
    "docfx/packages/threading/benchmarks/*/*.md",
]

EXCLUDE_FILENAMES = {
    "README.md", "machine-spec.md", "threading.md",
}

# Renames discovered empirically (dry-run, compare old vs. new distinct (family, variant)
# pairs at the same class_name across commits) — same iterative process as Cryptography's
# NORMALIZE_VARIANT table. Confirmed by tracing e.g. ManualResetEventSlim's variant at every
# commit: "Slim" only at 6dc2213 (2026-02-12), "System" at every commit after.
#
# Not attempted: the baseline-comparison *family* taxonomy (Interlocked/Lock/Monitor/etc.) at
# commit 6dc2213 doesn't reduce to a 1:1 rename — later commits added more granular
# measurements (e.g. one "Interlocked" family split into "Interlocked.Add"/".Inc"/".Exchange"/
# ".CmpX"), a real taxonomy change, not a label change. Forcing a merge there would invent a
# mapping that doesn't actually correspond — left as a historical fork, same tradeoff already
# accepted for Cryptography's third-party comparator libraries.
NORMALIZE_VARIANT: dict[str, str] = {
    "Nito.AsyncEx": "Nito",
    "Proto.Promises": "ProtoPromise",
    "ProtoPromises": "ProtoPromise",
    "Standard": "System",
    "Slim": "System",
}


def normalize_variant(variant: str) -> str:
    return NORMALIZE_VARIANT.get(variant, variant)


def git(*args) -> str:
    return subprocess.run(
        ["git", *args], cwd=REPO_ROOT, capture_output=True, check=True
    ).stdout.decode("utf-8")


def discover_commits():
    """Returns [(sha, iso_date, [changed_paths])] oldest first."""
    raw = git("log", "--format=COMMIT\t%H\t%aI", "--name-only", "--", *PATHSPECS)
    commits = []
    sha = date = None
    paths: list[str] = []
    for line in raw.splitlines():
        if line.startswith("COMMIT\t"):
            if sha:
                commits.append((sha, date, paths))
            _, sha, date = line.split("\t")
            paths = []
        elif line.strip():
            paths.append(line.strip())
    if sha:
        commits.append((sha, date, paths))
    commits.reverse()  # oldest first
    return commits


def resolve_platform_and_filename(path: str):
    marker = "docfx/packages/threading/benchmarks/"
    if not path.startswith(marker):
        return None
    rest = path[len(marker):]
    parts = rest.split("/")
    if len(parts) == 1:
        return PLATFORM_FOR_FLAT_ERA, parts[0]
    if len(parts) == 2:
        return parts[0], parts[1]
    return None


def main() -> int:
    import argparse

    parser = argparse.ArgumentParser(description=__doc__)
    parser.add_argument("--db", required=True, help="Path to the SQLite database file (created if missing)")
    parser.add_argument("--dry-run", action="store_true", help="Parse and report without writing to the database")
    args = parser.parse_args()

    import sqlite3

    with open(os.path.join(SCRIPT_DIR, "schema.sql"), encoding="utf-8") as f:
        schema_sql = f.read()

    conn = sqlite3.connect(args.db)
    conn.executescript(schema_sql)

    commits = discover_commits()
    print(f"Found {len(commits)} commit(s) touching Threading benchmark markdown tables.")

    total_rows = 0
    total_files = 0
    for sha, date, paths in commits:
        run_id = f"hist-{sha[:10]}"
        commit_rows = 0
        for path in paths:
            resolved = resolve_platform_and_filename(path)
            if resolved is None:
                continue
            platform, filename = resolved
            if filename in EXCLUDE_FILENAMES:
                continue

            try:
                content = git("show", f"{sha}:{path}")
            except subprocess.CalledProcessError:
                continue  # file deleted in this commit

            class_name = filename[:-3] if filename.endswith(".md") else filename

            rows = list(parse_markdown_table(
                content, source_label=f"{sha[:10]}:{path}", normalize_variant=normalize_variant
            ))
            if not rows:
                continue
            total_files += 1

            for row in rows:
                commit_rows += 1
                if args.dry_run:
                    continue
                conn.execute(
                    """
                    INSERT OR REPLACE INTO benchmark_results
                        (run_id, run_date, commit_sha, branch, platform,
                         class_name, method, family, variant,
                         param_label, param_value, mean_ns, stddev_ns, allocated_bytes)
                    VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)
                    """,
                    (
                        run_id, date, sha, BRANCH_FOR_HISTORY, platform,
                        class_name, row["method"], row["family"], row["variant"],
                        row["param_label"], row["param_value"],
                        row["mean_ns"], row["stddev_ns"], row["allocated_bytes"],
                    ),
                )
        if commit_rows:
            print(f"  [{'dry-run' if args.dry_run else 'ok'}] {sha[:10]} {date}: {commit_rows} row(s)")
        total_rows += commit_rows

    if not args.dry_run:
        conn.commit()
    conn.close()

    print(f"\n{'Would insert' if args.dry_run else 'Inserted/updated'} {total_rows} row(s) "
          f"across {total_files} file-revision(s) from {len(commits)} commit(s).")
    return 0


if __name__ == "__main__":
    raise SystemExit(main())
