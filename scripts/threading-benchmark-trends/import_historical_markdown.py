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

import json
import os
import subprocess
import sys

SCRIPT_DIR = os.path.dirname(os.path.abspath(__file__))
REPO_ROOT = os.path.dirname(os.path.dirname(SCRIPT_DIR))
sys.path.insert(0, SCRIPT_DIR)

from markdown_parser import parse_machine_spec, parse_markdown_table  # noqa: E402

PLATFORM_FOR_FLAT_ERA = "windows-x64-amd-ryzen-5-7600x"
BRANCH_FOR_HISTORY = "main"

PATHSPECS = [
    "docfx/packages/threading/benchmarks/*.md",
    "docfx/packages/threading/benchmarks/*/*.md",
]

EXCLUDE_FILENAMES = {
    "README.md", "machine-spec.md", "threading.md", "run.json",
}

# Renames discovered empirically (dry-run, compare old vs. new distinct (family, variant)
# pairs at the same class_name across commits) — same iterative process as Cryptography's
# NORMALIZE_VARIANT table. Confirmed by tracing e.g. ManualResetEventSlim's variant at every
# commit: "Slim" only at 6dc2213 (2026-02-12), "System" at every commit after.
NORMALIZE_VARIANT: dict[str, str] = {
    "Nito.AsyncEx": "Nito",
    "Proto.Promises": "ProtoPromise",
    "ProtoPromises": "ProtoPromise",
    "Standard": "System",
    "Slim": "System",
}


def normalize_variant(variant: str) -> str:
    return NORMALIZE_VARIANT.get(variant, variant)


# ThreadingConfig's DescriptionColumn used to let a method's 3rd [BenchmarkCategory] argument
# override the *family* (e.g. a sync `lock()` baseline inside AsyncLockSingleBenchmark reported
# family="Lock"/"SpinLock"/"Interlocked.Add"/etc. instead of "AsyncLock"), scattering what should
# be one comparison table ("every way to lock/unlock, sync and async") across a dozen bogus
# single-row families. Fixed at the source (ThreadingConfig.cs now always uses the class-level
# category as family, and the override becomes the variant instead) — but historical commits
# baked in the old, wrong (family, variant) pairs, so those need remapping here. Keyed by the
# scenario's class_name (the docfx page slug, e.g. "asynclock-single") since the same raw
# (family, variant) string pair can mean different things in different scenarios.
#
# Built by direct inspection of every distinct (class_name, method, family, variant) triple
# already imported (not guessed): each entry below corresponds to an exact historical row.
# Values are (new_family, new_variant): the pure synchronous lock/spin/interlocked baselines get
# their own "SyncLock" family (a separate comparison table among themselves), while the
# comparisons that are genuinely "one async implementation vs. its sync BCL equivalent"
# (AutoResetEvent, ManualResetEvent, Barrier, CountdownEvent, ReaderWriterLockSlim, and the
# SemaphoreSlim/VS.Threading async-compatible techniques used as a lock) stay merged into the
# primitive's own async family.
FAMILY_VARIANT_REMAP: dict[str, dict[tuple[str, str], tuple[str, str]]] = {
    "asynclock-single": {
        ("Baseline", "Increment"): ("SyncLock", "Increment"),
        ("Increment", "System"): ("SyncLock", "Increment"),
        ("Interlocked", "Interlocked"): ("SyncLock", "Interlocked.Inc"),
        ("Interlocked.Add", "System"): ("SyncLock", "Interlocked.Add"),
        ("Interlocked.CmpX", "System"): ("SyncLock", "Interlocked.CmpX"),
        ("Interlocked.Exchange", "System"): ("SyncLock", "Interlocked.Exchange"),
        ("Interlocked.Inc", "System"): ("SyncLock", "Interlocked.Inc"),
        ("Interlocked.Increment", "System"): ("SyncLock", "Interlocked.Inc"),
        ("Lock", "Lock.EnterScope"): ("SyncLock", "Lock.EnterScope"),
        ("Lock", "System"): ("SyncLock", "Lock"),
        ("Lock", "System.Lock"): ("SyncLock", "Lock"),
        ("Lock.EnterScope", "System"): ("SyncLock", "Lock.EnterScope"),
        ("Monitor", "Monitor"): ("SyncLock", "lock()"),
        ("lock()", "System"): ("SyncLock", "lock()"),
        ("SpinLock", "System"): ("SyncLock", "SpinLock"),
        ("SpinLock", "CryptoHives"): ("SyncLock", "SpinLock (CryptoHives)"),
        ("SpinOnce", "System"): ("SyncLock", "SpinOnce"),
        ("SemaphoreSlim", "SemaphoreSlim"): ("AsyncLock", "SemaphoreSlim"),
        ("SemaphoreSlim", "System"): ("AsyncLock", "SemaphoreSlim"),
        ("AsyncSemaphore", "VS.Threading"): ("AsyncLock", "VS.Threading"),
    },
    "asyncbarrier-signalandwait": {("Barrier", "System"): ("AsyncBarrier", "Barrier")},
    "asynccountdownevent-signal": {
        ("CountdownEvent", "System"): ("AsyncCountdownEvent", "CountdownEvent"),
        # "AsyncCountdownEv" was an inconsistent abbreviation in ThreadingConfig's FormatPrimitive
        # (every other family kept its natural short form, e.g. "AsyncBarrier"/"AsyncRWLock",
        # this one alone was truncated mid-word) — fixed at the source; these rows already carry
        # the class-level family correctly, just under the old abbreviated spelling.
        ("AsyncCountdownEv", "Pooled"): ("AsyncCountdownEvent", "Pooled"),
        ("AsyncCountdownEv", "ProtoPromise"): ("AsyncCountdownEvent", "ProtoPromise"),
        ("AsyncCountdownEv", "RefImpl"): ("AsyncCountdownEvent", "RefImpl"),
    },
    "asyncautoresetevent-set": {("AutoResetEvent", "System"): ("AsyncAutoReset", "AutoResetEvent")},
    "asyncmanualresetevent-setreset": {
        ("ManualResetEvent", "System"): ("AsyncManualReset", "ManualResetEvent"),
        ("ManualResetEventSlim", "System"): ("AsyncManualReset", "ManualResetEventSlim"),
    },
    "asyncsemaphore-single": {
        ("SemaphoreSlim", "SemaphoreSlim"): ("AsyncSemaphore", "SemaphoreSlim"),
        ("SemaphoreSlim", "System"): ("AsyncSemaphore", "SemaphoreSlim"),
    },
}
for _rwlock_class in (
    "asyncreaderwriterlock-reader",
    "asyncreaderwriterlock-upgradeablereader",
    "asyncreaderwriterlock-upgradedwriter",
    "asyncreaderwriterlock-writer",
):
    FAMILY_VARIANT_REMAP[_rwlock_class] = {
        ("RWLockSlim", "System"): ("AsyncRWLock", "RWLockSlim"),
        ("ReaderWriterLockSlim", "System"): ("AsyncRWLock", "RWLockSlim"),
        ("ReaderWriterLockSlim", "RWLockSlim"): ("AsyncRWLock", "RWLockSlim"),
    }

# "AsyncLockMultipleBenchmark" is an older class_name slug (pre-dating the "asynclock-multiple"
# docfx page naming) carrying the same SemaphoreSlim/VS.Threading baseline mislabeling.
FAMILY_VARIANT_REMAP["asynclock-multiple"] = FAMILY_VARIANT_REMAP["AsyncLockMultipleBenchmark"] = {
    ("SemaphoreSlim", "SemaphoreSlim"): ("AsyncLock", "SemaphoreSlim"),
    ("SemaphoreSlim", "System"): ("AsyncLock", "SemaphoreSlim"),
    ("AsyncSemaphore", "VS.Threading"): ("AsyncLock", "VS.Threading"),
}

# asynclock-single's rows historically reported method="Lock"/"SpinWait"/"SpinLock" instead of
# "LockAsync" — the same fix applied at the source (AsyncLockSingleBenchmark.cs) for future runs.
# Every row in this one scenario represents the same "single/uncontended" comparison, so
# unifying the method lets AsyncLock's rows plot alongside Pooled/Nito/etc. under one Family+
# Method selection (SyncLock's rows get their own family, but keep the same method value too,
# for consistency — there's only ever one method in that family).
METHOD_OVERRIDE_FOR_CLASS: dict[str, str] = {
    "asynclock-single": "LockAsync",
}


def normalize_family_method_variant(class_name: str, method: str, family: str, variant: str) -> tuple[str, str, str]:
    """Maps a historically-recorded (family, variant) pair — and, for asynclock-single, the
    method — onto the current, unified taxonomy. See FAMILY_VARIANT_REMAP/METHOD_OVERRIDE_FOR_CLASS
    above for the exact, empirically-confirmed mapping."""
    remap = FAMILY_VARIANT_REMAP.get(class_name)
    if remap is not None:
        mapped = remap.get((family, variant))
        if mapped is not None:
            family, variant = mapped
    method = METHOD_OVERRIDE_FOR_CLASS.get(class_name, method)
    return method, family, variant


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


def read_run_metadata(sha: str, platform: str):
    """Reads run.json for `platform` at `sha`, or None when the run predates it.

    A run is identified by the commit its binaries were built from, not by the commit that
    recorded the numbers. Those coincided while results were committed alongside code, but stop
    coinciding the moment two machines report separately - and it is the code commit that makes
    "the same build on two platforms" one run rather than two.
    """
    base = "docfx/packages/threading/benchmarks"
    for path in (f"{base}/{platform}/run.json", f"{base}/run.json"):
        try:
            return json.loads(git("show", f"{sha}:{path}"))
        except (subprocess.CalledProcessError, ValueError):
            continue
    return None


def read_machine_spec(sha: str, platform: str):
    """Reads the machine-spec.md that applies to `platform` at `sha`, or None if there is none.

    Tries the per-platform path first and falls back to the flat-era root file, so both layouts
    resolve without the caller needing to know which era a commit belongs to.
    """
    base = "docfx/packages/threading/benchmarks"
    for path in (f"{base}/{platform}/machine-spec.md", f"{base}/machine-spec.md"):
        try:
            return parse_machine_spec(git("show", f"{sha}:{path}"))
        except subprocess.CalledProcessError:
            continue
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
        # Fallback identity for the runs recorded before run.json existed; replaced below by the
        # code commit as soon as any platform in this commit carries one.
        run_id = f"hist-{sha[:10]}"
        commit_rows = 0

        # Platforms this commit actually produced results for, collected during the loop below so
        # the environment is recorded for exactly those.
        platforms_with_results = set()

        # A commit may carry several platforms, but they are one run only if they name the same
        # code commit - which is exactly the case run.json exists to express.
        run_metadata_by_platform = {}

        # Resolved before the rows are written, since every insert carries it: prefer the code
        # commit any platform in this commit declares, and fall back to the recording commit for
        # the runs that predate run.json.
        commit_platforms = sorted({
            resolved[0] for resolved in (resolve_platform_and_filename(x) for x in paths) if resolved
        })
        for platform_probe in commit_platforms:
            metadata = read_run_metadata(sha, platform_probe)
            run_metadata_by_platform[platform_probe] = metadata
            if metadata and metadata.get("codeCommit"):
                run_id = metadata["codeCommit"][:10]
                break

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
            platforms_with_results.add(platform)

            for row in rows:
                commit_rows += 1
                if args.dry_run:
                    continue
                method, family, variant = normalize_family_method_variant(
                    class_name, row["method"], row["family"], row["variant"]
                )
                conn.execute(
                    """
                    INSERT OR REPLACE INTO benchmark_results
                        (run_id, run_date, commit_sha, branch, platform,
                         class_name, method, family, variant, cancellation,
                         param_label, param_value, mean_ns, stddev_ns, allocated_bytes)
                    VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)
                    """,
                    (
                        run_id, date, sha, BRANCH_FOR_HISTORY, platform,
                        class_name, method, family, variant, row["cancellation"],
                        row["param_label"], row["param_value"],
                        row["mean_ns"], row["stddev_ns"], row["allocated_bytes"],
                    ),
                )
        # Read at the commit rather than from its changed-file list: git log --name-only reports
        # only what a commit touched, and a run that reused an unchanged machine-spec.md would
        # otherwise record no environment at all. Restricting this to platforms that produced
        # results also keeps out commits that revised the spec without publishing any tables.
        if not args.dry_run:
            for platform in sorted(platforms_with_results):
                spec = read_machine_spec(sha, platform)
                if spec is None:
                    print(f"  [warn] {sha[:10]} {platform}: no machine-spec.md found; "
                          f"environment not recorded", file=sys.stderr)
                    continue
                conn.execute(
                    """
                    INSERT OR REPLACE INTO benchmark_runs
                        (run_id, platform, run_date, commit_sha, branch, bdn_version, os, cpu,
                         logical_cores, physical_cores, sdk_version, runtime_version, jit)
                    VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)
                    """,
                    (run_id, platform, date, sha, None, spec["bdn_version"], spec["os"],
                     spec["cpu"], spec["logical_cores"], spec["physical_cores"],
                     spec["sdk_version"], spec["runtime_version"], spec["jit"]),
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
