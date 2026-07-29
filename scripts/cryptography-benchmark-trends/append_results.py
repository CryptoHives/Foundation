#!/usr/bin/env python3
# SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
# SPDX-License-Identifier: MIT
"""
Parses BenchmarkDotNet's full JSON exports (*-report-full.json) and appends
them as rows to the trend-history SQLite database (schema.sql).

Usage:
    python append_results.py \
        --results-dir tests/Security/Cryptography/BenchmarkDotNet.Artifacts/results \
        --db benchmark-history.sqlite \
        --platform windows-x64-amd-ryzen-5-7600x \
        --category Hash \
        --commit-sha abc1234 \
        --branch blake3 \
        --run-id abc1234-42

Design notes:
- Idempotent: re-running with the same --run-id overwrites rather than duplicates
  (INSERT OR REPLACE against the primary key), so a failed/retried CI step is safe.
- One invocation covers one (platform, category) pair, since --category is a flat
  tag applied to every row parsed in this pass — run it once per Benchmarks/<X>
  results directory per platform.
- Only parses benchmarks whose FullName ends in "(TestDataSize: <x>, Test<Y>Algorithm: <z>)"
  — the convention every ParameterizedHashBenchmark / ParameterizedMacBenchmark /
  cipher benchmark in this repo follows. Anything else (e.g. AesKeyWrapBenchmark,
  AesGmacBenchmark, which don't use that TestFixtureSource pattern) is skipped with
  a warning printed to stderr — extend PARAM_PATTERN below to cover them.
"""

import argparse
import glob
import json
import os
import re
import sqlite3
import sys

SCRIPT_DIR = os.path.dirname(os.path.abspath(__file__))

# Matches: Namespace.ClassName.MethodName(TestDataSize: 128B, TestFooAlgorithm: Family (Variant))
# Greedy `(.+)\)$` correctly captures a Variant containing its own "(...)" (e.g.
# "AES-128-CBC (CryptoHives-AES-NI)") because it matches up to the FINAL ")" in the string.
PARAM_PATTERN = re.compile(
    r"^(?:[\w.]+\.)?(?P<class_name>\w+)\.(?P<method>\w+)\("
    r"TestDataSize:\s*(?P<size_label>[^,]+),\s*"
    r"Test\w*Algorithm:\s*(?P<algo>.+)\)$"
)

# Matches "Family (Variant)" -> ("Family", "Variant"). Falls back to treating the
# whole string as the family with variant "default" if there's no trailing "(...)".
FAMILY_VARIANT_PATTERN = re.compile(r"^(?P<family>.+?)\s*\((?P<variant>[^()]+)\)$")

SIZE_MULTIPLIERS = {"B": 1, "KB": 1024, "MB": 1024 * 1024}
SIZE_PATTERN = re.compile(r"^(?P<value>\d+)(?P<unit>B|KB|MB)$")


def parse_data_size_bytes(label: str) -> int | None:
    match = SIZE_PATTERN.match(label.strip())
    if not match:
        return None
    return int(match.group("value")) * SIZE_MULTIPLIERS[match.group("unit")]


def parse_family_variant(algo: str) -> tuple[str, str]:
    match = FAMILY_VARIANT_PATTERN.match(algo.strip())
    if match:
        return match.group("family").strip(), match.group("variant").strip()
    return algo.strip(), "default"


def iter_rows(report_json: dict, category: str):
    for bench in report_json.get("Benchmarks", []):
        full_name = bench.get("FullName", "")
        match = PARAM_PATTERN.match(full_name)
        if not match:
            print(f"  [skip] unrecognized FullName shape: {full_name}", file=sys.stderr)
            continue

        family, variant = parse_family_variant(match.group("algo"))
        size_label = match.group("size_label").strip()

        stats = bench.get("Statistics") or {}
        mean_ns = stats.get("Mean")
        if mean_ns is None:
            continue  # benchmark failed / no measurements (e.g. NA rows)

        memory = bench.get("Memory") or {}

        yield {
            "class_name": match.group("class_name"),
            "method": match.group("method"),
            "family": family,
            "variant": variant,
            "data_size_label": size_label,
            "data_size_bytes": parse_data_size_bytes(size_label),
            "mean_ns": mean_ns,
            "stddev_ns": stats.get("StandardDeviation"),
            "allocated_bytes": memory.get("BytesAllocatedPerOperation"),
            "category": category,
        }


def main() -> int:
    parser = argparse.ArgumentParser(description=__doc__)
    parser.add_argument("--results-dir", required=True, help="Directory containing *-report-full.json files")
    parser.add_argument("--db", required=True, help="Path to the SQLite database file (created if missing)")
    parser.add_argument("--platform", required=True, help="Platform slug, e.g. windows-x64-amd-ryzen-5-7600x")
    parser.add_argument("--category", required=True, choices=["Hash", "Cipher", "Mac"])
    parser.add_argument("--commit-sha", default="")
    parser.add_argument("--branch", default="")
    parser.add_argument("--run-id", required=True, help="Unique ID for this CI run, e.g. <short-sha>-<run-number>")
    parser.add_argument("--run-date", default=None, help="ISO 8601 UTC timestamp; defaults to now")
    args = parser.parse_args()

    run_date = args.run_date or __import__("datetime").datetime.now(__import__("datetime").timezone.utc).isoformat()

    json_files = sorted(glob.glob(os.path.join(args.results_dir, "*-report-full.json")))
    if not json_files:
        print(f"No *-report-full.json files found in {args.results_dir}", file=sys.stderr)
        return 1

    with open(os.path.join(SCRIPT_DIR, "schema.sql"), encoding="utf-8") as f:
        schema_sql = f.read()

    conn = sqlite3.connect(args.db)
    try:
        conn.executescript(schema_sql)

        total_rows = 0
        for json_path in json_files:
            with open(json_path, encoding="utf-8") as f:
                report = json.load(f)

            rows = list(iter_rows(report, args.category))
            for row in rows:
                conn.execute(
                    """
                    INSERT OR REPLACE INTO benchmark_results
                        (run_id, run_date, commit_sha, branch, platform, category,
                         class_name, method, family, variant,
                         data_size_label, data_size_bytes, mean_ns, stddev_ns, allocated_bytes)
                    VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)
                    """,
                    (
                        args.run_id, run_date, args.commit_sha, args.branch, args.platform, row["category"],
                        row["class_name"], row["method"], row["family"], row["variant"],
                        row["data_size_label"], row["data_size_bytes"],
                        row["mean_ns"], row["stddev_ns"], row["allocated_bytes"],
                    ),
                )
            total_rows += len(rows)
            print(f"  [ok] {os.path.basename(json_path)}: {len(rows)} row(s)")

        conn.commit()
        print(f"Inserted/updated {total_rows} row(s) into {args.db} (run_id={args.run_id})")
    finally:
        conn.close()

    return 0


if __name__ == "__main__":
    raise SystemExit(main())
