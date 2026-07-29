#!/usr/bin/env python3
# SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
# SPDX-License-Identifier: MIT
"""
Parses Threading benchmark markdown reports (*-report.md) and appends them as rows to the
Threading trend-history SQLite database (schema.sql). Sibling of
scripts/cryptography-benchmark-trends/append_results.py (Cryptography's) — that one parses JSON because
Cryptography's variant identity lives in a benchmark parameter's ToString(); Threading's lives
in [BenchmarkCategory] attributes / the method name instead, which only the markdown Description
column (computed by ThreadingConfig's DescriptionColumn) captures cleanly. See
markdown_parser.py for the shared parsing logic used by both this script and the historical
importer.

Usage:
    python append_results.py \
        --results-dir tests/Threading/BenchmarkDotNet.Artifacts/results \
        --db benchmark-history.sqlite \
        --platform windows-x64-amd-ryzen-5-7600x \
        --commit-sha abc1234 \
        --branch main \
        --run-id abc1234-42

Design notes:
- Idempotent: re-running with the same --run-id overwrites rather than duplicates
  (INSERT OR REPLACE against the primary key).
- No --category (Threading's schema has none — see schema.sql).
- No live-side normalization: current variant names from a fresh run are already correct: it's
  only the historical importer that needs a rename table for old naming.
"""

import argparse
import datetime
import glob
import os
import sqlite3
import sys

SCRIPT_DIR = os.path.dirname(os.path.abspath(__file__))
sys.path.insert(0, SCRIPT_DIR)

from markdown_parser import parse_markdown_table  # noqa: E402


def main() -> int:
    parser = argparse.ArgumentParser(description=__doc__)
    parser.add_argument("--results-dir", required=True, help="Directory containing *-report.md files")
    parser.add_argument("--db", required=True, help="Path to the SQLite database file (created if missing)")
    parser.add_argument("--platform", required=True, help="Platform slug, e.g. windows-x64-amd-ryzen-5-7600x")
    parser.add_argument("--commit-sha", default="")
    parser.add_argument("--branch", default="")
    parser.add_argument("--run-id", required=True, help="Unique ID for this run, e.g. <timestamp>-<short-sha>")
    parser.add_argument("--run-date", default=None, help="ISO 8601 UTC timestamp; defaults to now")
    args = parser.parse_args()

    run_date = args.run_date or datetime.datetime.now(datetime.timezone.utc).isoformat()

    md_files = sorted(glob.glob(os.path.join(args.results_dir, "*-report.md")))
    if not md_files:
        print(f"No *-report.md files found in {args.results_dir}", file=sys.stderr)
        return 1

    with open(os.path.join(SCRIPT_DIR, "schema.sql"), encoding="utf-8") as f:
        schema_sql = f.read()

    conn = sqlite3.connect(args.db)
    try:
        conn.executescript(schema_sql)

        total_rows = 0
        for md_path in md_files:
            with open(md_path, encoding="utf-8") as f:
                content = f.read()

            class_name = os.path.basename(md_path)
            if class_name.endswith("-report.md"):
                class_name = class_name[: -len("-report.md")]

            rows = list(parse_markdown_table(content, source_label=os.path.basename(md_path)))
            for row in rows:
                conn.execute(
                    """
                    INSERT OR REPLACE INTO benchmark_results
                        (run_id, run_date, commit_sha, branch, platform,
                         class_name, method, family, variant, cancellation,
                         param_label, param_value, mean_ns, stddev_ns, allocated_bytes)
                    VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)
                    """,
                    (
                        args.run_id, run_date, args.commit_sha, args.branch, args.platform,
                        class_name, row["method"], row["family"], row["variant"], row["cancellation"],
                        row["param_label"], row["param_value"],
                        row["mean_ns"], row["stddev_ns"], row["allocated_bytes"],
                    ),
                )
            total_rows += len(rows)
            print(f"  [ok] {os.path.basename(md_path)}: {len(rows)} row(s)")

        conn.commit()
        print(f"Inserted/updated {total_rows} row(s) into {args.db} (run_id={args.run_id})")
    finally:
        conn.close()

    return 0


if __name__ == "__main__":
    raise SystemExit(main())
