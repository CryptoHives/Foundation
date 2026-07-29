#!/usr/bin/env python3
# SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
# SPDX-License-Identifier: MIT
"""
One-time backfill: walks git history for every commit that touched the (now-retired)
per-platform benchmark markdown tables and imports each commit's numbers into the trends
SQLite database as its own dated run, so historical development-over-time is visible
without having had the database running from day one.

Usage:
    python import_historical_markdown.py --db docfx/packages/security/cryptography/benchmark-trends/benchmark-history.sqlite

Design notes:
- Two eras of file layout exist in history:
    1. Flat: docfx/packages/security/cryptography/benchmarks/<algo>.md (no platform folder).
       Always ran on the same dev machine (confirmed via each era's machine-spec.md: AMD
       Ryzen 5 7600X throughout), so PLATFORM_FOR_FLAT_ERA applies retroactively.
    2. Platform-folder: docfx/packages/security/cryptography/benchmarks/<platform-id>/<algo>.md.
- Both eras' Description column decomposes to the same logical parts once split on
  whichever separator was in use at the time:
    - Hash/Mac: "Method · Category · Family (Variant)" (or, in the earliest commits, three
      raw pipe-delimited cells before the "·" fix — see HashConfig.cs's DescriptionColumn
      comment) — 3 parts.
    - Cipher: "Method · Family (Variant)" — 2 parts, no separate category.
  Either way, method = first part, "Family (Variant)" = last part; any middle part is a
  redundant category label and is ignored.
- Every commit that changed a file becomes its own run (run_id = "hist-<short-sha>",
  run_date = commit author date), so idempotent INSERT OR REPLACE re-runs are safe and
  each historical benchmark refresh shows up as a distinct point in the trends dashboard.
"""

import os
import re
import sqlite3
import subprocess
import sys

SCRIPT_DIR = os.path.dirname(os.path.abspath(__file__))
REPO_ROOT = os.path.dirname(os.path.dirname(SCRIPT_DIR))

PLATFORM_FOR_FLAT_ERA = "windows-x64-amd-ryzen-5-7600x"
BRANCH_FOR_HISTORY = "main"

PATHSPECS = [
    "docfx/packages/security/cryptography/benchmarks/*.md",
    "docfx/packages/security/cryptography/benchmarks/*/*.md",
]

EXCLUDE_FILENAMES = {
    "README.md", "machine-spec.md", "hash.md", "cipher.md", "mac.md",
    "benchmarks.md", "allhashers-all-sizes.md",
}

CIPHER_PREFIXES = (
    "aes-cbc", "aes-gcm", "aes-ccm", "chacha20", "xchacha20", "sm4-cbc",
    "aria-cbc", "camellia-cbc", "kuznyechik-cbc", "kalyna-cbc", "seed-cbc",
)
MAC_EXACT = {"aes-cmac", "aes-gmac", "poly1305"}

# A handful of historical commits (e.g. KMAC128/256 at 471b6052d4, 2026-02-09) had a
# DescriptionColumn bug where the "family" slot got filled with a benchmark method name
# instead of an algorithm name — "ComputeMac · TryComputeHash · Managed" instead of something
# like "ComputeMac · KMAC128 · CryptoHives-Scalar". A real family is never one of these verbs,
# so treat a match as a sign of that bug and skip the row rather than recording garbage.
KNOWN_METHOD_VERBS = {
    "ComputeHash", "TryComputeHash", "ComputeMac", "ComputeTag", "Encrypt", "Decrypt",
    "AbsorbSqueeze",
}

FAMILY_VARIANT_PATTERN = re.compile(r"^(?P<family>.+?)\s*\((?P<variant>[^()]+)\)$")

# An even older KMAC128/256 description format (predating "Method · Family · Variant"
# entirely) used a single flat token per row — "Kmac128_BouncyCastle", "Kmac256_DotNet" — with
# no method/family/variant separation at all. Recognize and skip it rather than recording the
# whole token as both a bogus method and a bogus family.
LEGACY_KMAC_TOKEN_PATTERN = re.compile(r"^Kmac(?:128|256)_\w+$")
SIZE_MULTIPLIERS = {"B": 1, "KB": 1024, "MB": 1024 * 1024}
SIZE_PATTERN = re.compile(r"^(?P<value>\d+)(?P<unit>B|KB|MB)$")
MEASUREMENT_PATTERN = re.compile(r"^([\d,]+\.?\d*)\s*(ns|μs|us|ms)$")

# The CryptoHives-authored variant names were renamed at various points in history (bare
# "Managed"/"AVX2"/"AES-NI" etc. -> "CryptoHives-"-prefixed, confirmed by diffing the current
# registries — HashAlgorithmRegistry.cs, CipherAlgorithmRegistry.cs — against old markdown
# snapshots. Some third-party comparator names also drifted because the DescriptionColumn's
# cosmetic GetImplementationType mapping (added partway through history) only sometimes ran —
# e.g. "SHA-256 (OS)" (raw) vs. "OS Native" (cosmetic), or Blake3's three comparator libraries
# showing up under either their raw or cosmetic name depending on which commit. Old rows are
# normalized to today's raw registry names so a family's trend line stays continuous instead
# of forking across a rename.
NORMALIZE_VARIANT = {
    "Managed": "CryptoHives-Scalar",
    "AVX2": "CryptoHives-AVX2",
    "AVX512F": "CryptoHives-AVX512F",
    "SSE2": "CryptoHives-Sse2",
    "Sse2": "CryptoHives-Sse2",
    "SSSE3": "CryptoHives-Ssse3",
    "Ssse3": "CryptoHives-Ssse3",
    "Neon": "CryptoHives-Neon",
    "OS Native": "OS",
    "Native": "Blake3Native",
    "Blake3.NET-Native": "Blake3Native",
    "Blake3.NET-Managed": "Blake3Managed",
    "Blake3.Managed": "Blake3Dissimilis",
    "Hashify .NET": "HashifyNET",
    "AES-NI": "CryptoHives-AES-NI",
    "AES-NI+PClMul": "CryptoHives-AES-NI+PClMul",
    "AES-NI+PClMulV256": "CryptoHives-AES-NI+PClMulV256",
    "ArmAes": "CryptoHives-ARM-AES",
    "ArmAes+ArmPmull": "CryptoHives-ARM-AES+PMULL",
}


def normalize_variant(variant: str) -> str:
    return NORMALIZE_VARIANT.get(variant, variant)


# The Hash benchmark method itself was renamed from "ComputeHash" to "TryComputeHash" at some
# point in history (reflecting a real API/benchmark improvement, not a different measurement) —
# same normalization idea as NORMALIZE_VARIANT, just for the method column.
NORMALIZE_METHOD = {
    "ComputeHash": "TryComputeHash",
}


def normalize_method(method: str) -> str:
    return NORMALIZE_METHOD.get(method, method)


def classify_category(filename: str) -> str:
    stem = filename[:-3] if filename.endswith(".md") else filename
    if stem.startswith("hmac-") or stem in MAC_EXACT:
        return "Mac"
    if stem.startswith(CIPHER_PREFIXES):
        return "Cipher"
    return "Hash"


def parse_family_variant(name: str) -> tuple[str, str]:
    match = FAMILY_VARIANT_PATTERN.match(name.strip())
    if match:
        return match.group("family").strip(), match.group("variant").strip()
    return name.strip(), "default"


def parse_data_size_bytes(label: str) -> int | None:
    match = SIZE_PATTERN.match(label.strip())
    if not match:
        return None
    return int(match.group("value")) * SIZE_MULTIPLIERS[match.group("unit")]


def parse_measurement_ns(cell: str) -> float | None:
    cell = cell.strip().replace(",", "")
    match = MEASUREMENT_PATTERN.match(cell)
    if not match:
        return None
    value = float(match.group(1))
    unit = match.group(2)
    if unit == "ns":
        return value
    if unit in ("μs", "us"):
        return value * 1000
    return value * 1_000_000  # ms


def parse_allocated_bytes(cell: str) -> int | None:
    cell = cell.strip().replace(",", "")
    if cell in ("", "-", "NA"):
        return None
    cell = cell.rstrip("B").strip()
    try:
        return int(round(float(cell)))
    except ValueError:
        return None


def parse_markdown_table(content: str):
    """Yields dicts with method/family/variant/size/mean/stddev/allocated for each data row.

    Column layout varies across history (an extra "Code Size" column appears whenever
    DisassemblyDiagnoser was active), so columns are located by header name rather than
    fixed position. The Description column itself sometimes arrives pre-split into 2-3 raw
    cells (the pre-"·"-separator era literally used "|" inside the Description string,
    which markdown then treats as extra columns) — detected as row_cells having more cells
    than the header, with the surplus always at the front since Description is always the
    first header column.
    """
    content = content.lstrip("﻿")
    header_cells: list[str] | None = None

    for raw_line in content.splitlines():
        line = raw_line.strip()
        if not line.startswith("|"):
            continue
        cells = [c.strip() for c in line.strip("|").split("|")]
        if len(cells) < 2:
            continue
        if set("".join(cells)) <= set("-: "):
            continue  # markdown divider row (e.g. "|---|---|")
        if cells[0].lower() == "description":
            header_cells = cells
            continue
        if header_cells is None:
            continue  # data row seen before any header; malformed/unsupported table
        if not any(c and c != "-" for c in cells[1:]):
            continue  # blank separator row, e.g. "|    |    |    |"

        extra = len(cells) - len(header_cells)
        if extra < 0:
            continue  # row shorter than header; not a data row we understand

        desc_cells = cells[: 1 + extra]
        fields = dict(zip(header_cells[1:], cells[1 + extra:]))

        mean_ns = parse_measurement_ns(fields.get("Mean", ""))
        if mean_ns is None:
            continue  # failed/NA row

        # The joined-cell era packs "Method · Category · Name" (or "Method · Name" for
        # Cipher) into a single raw cell using "·" as the separator; the pre-fix era instead
        # split on literal "|", arriving as separate raw cells already. Splitting every raw
        # cell on "·" and flattening handles both uniformly (a no-op when "·" isn't present).
        desc_parts = [p.strip() for raw in desc_cells for p in raw.split("·")]
        if not desc_parts:
            continue
        if len(desc_parts) == 1 and LEGACY_KMAC_TOKEN_PATTERN.match(desc_parts[0]):
            print(f"  [skip] legacy flat-token KMAC description: {desc_parts[0]!r}", file=sys.stderr)
            continue

        method = normalize_method(desc_parts[0])
        # Hash/Cipher embed "Family (Variant)" in the last part (family repeats the middle
        # "category" part, which is ignored). Mac's last part instead is a bare implementation
        # name (no parens) with category as the real family — detected by the absence of a
        # trailing "(...)".
        last = desc_parts[-1]
        if len(desc_parts) >= 3 and not FAMILY_VARIANT_PATTERN.match(last):
            family, variant = desc_parts[1], last
        else:
            family, variant = parse_family_variant(last)
        if family in KNOWN_METHOD_VERBS:
            print(f"  [skip] family looks like a method name (DescriptionColumn bug): {desc_parts}", file=sys.stderr)
            continue
        variant = normalize_variant(variant)
        size_label = fields.get("TestDataSize", "").strip()

        yield {
            "method": method,
            "family": family,
            "variant": variant,
            "data_size_label": size_label,
            "data_size_bytes": parse_data_size_bytes(size_label),
            "mean_ns": mean_ns,
            "stddev_ns": parse_measurement_ns(fields.get("StdDev", "")),
            "allocated_bytes": parse_allocated_bytes(fields.get("Allocated", "")),
        }


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
    marker = "docfx/packages/security/cryptography/benchmarks/"
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

    with open(os.path.join(SCRIPT_DIR, "schema.sql"), encoding="utf-8") as f:
        schema_sql = f.read()

    conn = sqlite3.connect(args.db)
    conn.executescript(schema_sql)

    commits = discover_commits()
    print(f"Found {len(commits)} commit(s) touching benchmark markdown tables.")

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

            category = classify_category(filename)
            class_name = filename[:-3] if filename.endswith(".md") else filename

            rows = list(parse_markdown_table(content))
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
                        (run_id, run_date, commit_sha, branch, platform, category,
                         class_name, method, family, variant,
                         data_size_label, data_size_bytes, mean_ns, stddev_ns, allocated_bytes)
                    VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)
                    """,
                    (
                        run_id, date, sha, BRANCH_FOR_HISTORY, platform, category,
                        class_name, row["method"], row["family"], row["variant"],
                        row["data_size_label"], row["data_size_bytes"],
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
