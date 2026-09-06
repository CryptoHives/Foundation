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

# `int | None`-style annotations below need this on Python < 3.10 (PEP 604 union syntax was
# added in 3.10); postponing evaluation makes them plain strings instead of executed `int.__or__`
# expressions, which is all this module needs since nothing here calls typing.get_type_hints().
from __future__ import annotations

import json
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
    "aes-cbc", "aes-gcm", "aes-ccm", "aes-key-wrap", "chacha20", "xchacha20", "sm4-cbc",
    "aria-cbc", "camellia-cbc", "kuznyechik-cbc", "kalyna-cbc", "seed-cbc",
    # Ascon-AEAD128 is a cipher; the Ascon hash and XOF stems (asconhash/asconxof) are not
    # matched by this prefix and stay under Hash.
    "ascon-aead",
)
MAC_EXACT = {"aes-cmac", "aes-gmac", "poly1305"}
# Post-quantum KEM. Unlike the hash/cipher/MAC scenarios these carry no data-size axis: the
# ordered dimension is the FIPS 203 parameter set, which the Description column already puts in
# the family slot (ML-KEM-512/768/1024), so data_size_label comes out empty for every row.
KEM_PREFIXES = ("ml-kem",)

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

# BenchmarkDotNet keeps job characteristics in the preamble only while they are constant across
# the report; the moment one varies it becomes a table column instead. A single-runtime run says
# "Toolchain=net10.0" above the table, while `--runtimes net8.0 net10.0` grows a "Runtime" column.
#
# Unlike Threading's parser - which identifies [Params] by exclusion, so an unknown column would
# become a spurious parameter - this one reads columns by name and would simply ignore a Runtime
# column. That failure is quieter and worse: every runtime's rows would share a primary key and
# silently overwrite one another, leaving one runtime's numbers labelled as the run's.
#
# Kept as a deliberate sibling of FRAMEWORK_COLUMNS/normalize_framework in
# scripts/threading-benchmark-trends/markdown_parser.py rather than shared, matching how the rest
# of these two pipelines are organized.
FRAMEWORK_COLUMNS = ("Runtime", "Job")

_FRAMEWORK_DISPLAY = re.compile(r"^\.NET (?P<fw>Framework )?(?P<version>\d+(?:\.\d+){1,2})$")


def normalize_framework(value):
    """'.NET 10.0' -> 'net10.0', '.NET Framework 4.6.2' -> 'net462', 'net10.0' -> 'net10.0'.

    Anything unrecognized is returned unchanged rather than dropped: a value this does not know
    is still a truthful distinction between rows, and collapsing it would merge runs that differ.
    """
    if not value:
        return None
    value = value.strip()
    match = _FRAMEWORK_DISPLAY.match(value)
    if not match:
        return value
    version = match.group("version")
    if match.group("fw"):
        return "net" + version.replace(".", "")
    return "net" + ".".join(version.split(".")[:2])

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
    # BenchmarkDotNet wraps a [Benchmark(Description = ...)] containing spaces in single quotes,
    # and the markdown exporter then HTML-escapes them, so a description like
    # "Decapsulate (rejected)" arrives as "&#39;Decapsulate (rejected)&#39;". Strip both forms
    # before the lookup, or the quotes become part of the method name in the database.
    method = method.strip()
    if method.startswith("&#39;") and method.endswith("&#39;"):
        method = method[5:-5].strip()
    method = method.strip("'").strip()
    return NORMALIZE_METHOD.get(method, method)


def classify_category(filename: str) -> str:
    stem = filename[:-3] if filename.endswith(".md") else filename
    if stem.startswith("hmac-") or stem in MAC_EXACT:
        return "Mac"
    if stem.startswith(CIPHER_PREFIXES):
        return "Cipher"
    if stem.startswith(KEM_PREFIXES):
        return "Kem"
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
    # "-" is BenchmarkDotNet reporting a measured zero, not a missing measurement. Folding the two
    # together made every allocation-free row NULL - 16,326 of 22,604 - so the Allocated metric
    # dropped exactly the rows a managed crypto implementation exists to produce, reading as no
    # data rather than as the flat zero it is. "NA" (diagnoser did not run) and an empty cell
    # stay NULL.
    if cell == "-":
        return 0
    if cell in ("", "NA"):
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

        # Present only when the report covers more than one runtime; a single-runtime run leaves
        # this None and the caller substitutes the framework the run directory names.
        framework = None
        for column in FRAMEWORK_COLUMNS:
            if fields.get(column, "").strip():
                framework = normalize_framework(fields[column])
                break

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
            "framework": framework,
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


def read_machine_spec_text(sha: str, platform: str):
    """The machine-spec.md that applies to `platform` at `sha`, or None.

    Tries the per-platform path first and falls back to the flat-era root file, so both layouts
    resolve without the caller needing to know which era a commit belongs to.
    """
    base = "docfx/packages/security/cryptography/benchmarks"
    for path in (f"{base}/{platform}/machine-spec.md", f"{base}/machine-spec.md"):
        try:
            return git("show", f"{sha}:{path}")
        except subprocess.CalledProcessError:
            continue
    return None


def export_archive(dest_root: str) -> int:
    """Writes every run reachable from history into the per-run directory layout.

    One directory per run, keyed by the commit its binaries were built from, with a platform
    directory inside - the layout the `benchmarks` branch uses and import_run_archive.py reads.
    Unlike this module, that reader needs no git history at all, which is what lets CI build the
    database from a shallow checkout.

    These runs predate run.json, so one is synthesized and marked backfilled: results were
    committed alongside the code they measured, so the recording commit is the code commit.
    """
    commits = discover_commits()
    written_runs = 0
    written_files = 0

    for sha, date, paths in commits:
        by_platform = {}
        for path in paths:
            resolved = resolve_platform_and_filename(path)
            if resolved is None:
                continue
            platform, filename = resolved
            if filename in EXCLUDE_FILENAMES or filename == "machine-spec.md":
                continue
            try:
                content = git("show", f"{sha}:{path}")
            except subprocess.CalledProcessError:
                continue  # deleted in this commit
            if not list(parse_markdown_table(content)):
                continue  # nothing parseable - not a results table
            by_platform.setdefault(platform, {})[filename] = content

        for platform, files in sorted(by_platform.items()):
            run_dir = os.path.join(dest_root, "cryptography", sha[:10], platform)
            os.makedirs(run_dir, exist_ok=True)

            spec = read_machine_spec_text(sha, platform)
            if spec is not None:
                files["machine-spec.md"] = spec

            for filename, content in sorted(files.items()):
                with open(os.path.join(run_dir, filename), "w", encoding="utf-8", newline="\n") as handle:
                    handle.write(content)
                written_files += 1

            metadata = {
                "codeCommit": sha,
                "recordedAt": date,
                "package": "cryptography",
                "platform": platform,
                "backfilled": True,
                "note": "Recovered from git history, where results were committed alongside the "
                        "code they measured, so the recording commit is the code commit.",
            }
            with open(os.path.join(run_dir, "run.json"), "w", encoding="utf-8", newline="\n") as handle:
                json.dump(metadata, handle, indent=2)
                handle.write("\n")
            written_files += 1
            written_runs += 1
            print(f"  [export] {sha[:10]}/{platform}: {len(files)} file(s)")

    print(f"\nExported {written_runs} run-platform(s), {written_files} file(s) to {dest_root}")
    return 0


def main() -> int:
    import argparse

    parser = argparse.ArgumentParser(description=__doc__)
    parser.add_argument("--db", required=True, help="Path to the SQLite database file (created if missing)")
    parser.add_argument("--dry-run", action="store_true", help="Parse and report without writing to the database")
    parser.add_argument("--export", metavar="DIR",
                        help="Instead of importing, write every run found in history into DIR as "
                             "cryptography/<code-commit>/<platform>/, the layout the benchmarks "
                             "branch uses")
    args = parser.parse_args()

    with open(os.path.join(SCRIPT_DIR, "schema.sql"), encoding="utf-8") as f:
        schema_sql = f.read()

    if args.export:
        return export_archive(args.export)

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


# Mirrors scripts/threading-benchmark-trends/markdown_parser.py. Duplicated rather than shared:
# these two pipelines are deliberate siblings, each with its own parser and schema, and a third
# module for one 50-line function would couple them for less than it costs. The preamble format is
# BenchmarkDotNet's, so it does not drift with either package.
# BenchmarkDotNet's machine-spec preamble, e.g.
#
#     BenchmarkDotNet v0.15.8, Windows 11 (10.0.26200.8875/25H2/2025Update/HudsonValley2)
#     AMD Ryzen 5 7600X 4.70GHz, 1 CPU, 12 logical and 6 physical cores
#     .NET SDK 11.0.100-preview.5.26302.115
#     [Host]    : .NET 10.0.10 (10.0.10, 10.0.1026.32716), X64 RyuJIT x86-64-v4
#
# Every field is optional: the flat era's files and the per-platform era's differ in wording, and
# a missing line should leave a NULL column rather than abort the import of a whole run.
_BDN_LINE = re.compile(r"^BenchmarkDotNet v(?P<bdn>[\w.\-+]+),\s*(?P<os>.+?)\s*$", re.M)
_CPU_LINE = re.compile(
    r"^(?P<cpu>.+?),\s*\d+ CPU,\s*(?P<logical>\d+) logical(?: and (?P<physical>\d+) physical)? cores",
    re.M,
)
_SDK_LINE = re.compile(r"^\.NET SDK (?P<sdk>[\w.\-+]+)", re.M)
_HOST_LINE = re.compile(
    r"^\s*\[Host\]\s*:\s*\.NET (?P<runtime>[\w.\-+]+)\s*\([^)]*\),\s*(?P<jit>.+?)\s*$", re.M
)


def parse_machine_spec(text: str) -> dict:
    """Extracts the environment fields from a machine-spec.md.

    Returns a dict with bdn_version/os/cpu/logical_cores/physical_cores/sdk_version/
    runtime_version/jit, each None when that line is absent.
    """
    spec = {
        "bdn_version": None, "os": None, "cpu": None,
        "logical_cores": None, "physical_cores": None,
        "sdk_version": None, "runtime_version": None, "jit": None,
        "framework": None,
    }

    match = _BDN_LINE.search(text)
    if match:
        spec["bdn_version"] = match.group("bdn")
        spec["os"] = match.group("os")

    match = _CPU_LINE.search(text)
    if match:
        spec["cpu"] = match.group("cpu").strip()
        spec["logical_cores"] = int(match.group("logical"))
        if match.group("physical"):
            spec["physical_cores"] = int(match.group("physical"))

    match = _SDK_LINE.search(text)
    if match:
        spec["sdk_version"] = match.group("sdk")

    match = _HOST_LINE.search(text)
    if match:
        spec["runtime_version"] = match.group("runtime")
        spec["jit"] = match.group("jit")

    # "Job=.NET 10.0  Runtime=.NET 10.0  Toolchain=net10.0" - present only while the job is
    # constant across the report, which is exactly when the table carries no Runtime column.
    match = re.search(r"Toolchain=(\S+)", text)
    if match:
        spec["framework"] = match.group(1)
    else:
        match = re.search(r"Runtime=(\.NET(?: Framework)? \d+(?:\.\d+){1,2})", text)
        if match:
            spec["framework"] = normalize_framework(match.group(1))

    return spec


if __name__ == "__main__":
    raise SystemExit(main())
