#!/usr/bin/env python3
# SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
# SPDX-License-Identifier: MIT
"""
Shared markdown-table parsing for Threading's benchmark trends pipeline, used by both
import_run_archive.py (the run archive on the `benchmarks` branch, which builds the published
database) and import_historical_markdown.py (the one-time recovery of the pre-archive era).
Unlike Cryptography's pipeline — which parses JSON for live recording and markdown only for
historical backfill, because those two eras use genuinely different formats — Threading's live
and historical reports are the *same* format (ThreadingConfig's DescriptionColumn), so one
parser correctly serves both call sites. See scripts/cryptography-benchmark-trends/import_historical_markdown.py
(Cryptography's) for the header-driven design this is adapted from.

Confirmed directly against a real generated report (AsyncLockMultipleBenchmark-report.md):
    | Description                               | Iterations | cancellationType | Mean | Ratio | Allocated |
    | Multiple · AsyncLock · Pooled (ValueTask) | 0          | None              | ... |
    | Multiple · SemaphoreSlim · System         | 0          | None              | ... |
- Unlike Cryptography's Description column, Threading's never uses a "Family (Variant)"
  parenthetical — it's always 1-3 plain "·"-separated parts: Operation, [TypeName], [Implementation].
  A variant string MAY itself contain literal parentheses (e.g. "Pooled (ValueTask)") — that's
  just part of the raw implementation name, not a pattern to split further.
- `family` genuinely varies row-by-row within one file: baseline comparisons (e.g. the built-in
  SemaphoreSlim) show their own real type name instead of the class's primitive name.
- StdDev/Error are always hidden (ThreadingConfig.HideColumns), so stddev_ns is reliably NULL.
- The contention-level [Params] axis is named either "Iterations" or "ParticipantCount"
  depending on the benchmark class (confirmed via grep across tests/Threading/Async/Pooled/*.cs).
- CancellationToken state, where present, is a separate "cancellationType" column
  (None/NotCancelled/Cancelled) — returned here as its own `cancellation` field (not folded
  into `variant`), so the dashboard can offer a dedicated Cancellation selector.
"""

import re
import sys

MEASUREMENT_PATTERN = re.compile(r"^([\d,]+\.?\d*)\s*(ns|μs|us|ms)$")
CANCELLATION_COLUMN = "cancellationType"

# BenchmarkDotNet keeps job characteristics in the preamble only while they are constant across
# the report; the moment one varies it becomes a table column instead. So a run over a single
# runtime says "Toolchain=net10.0" above the table and has no such column, while
# `--runtimes net8.0 net10.0` drops the preamble line and grows a "Runtime" column.
#
# Both have to be understood, because both are the framework the row executed on - and the
# alternative is worse than missing it. Parameters here are identified by exclusion, so an
# unrecognized "Runtime" column would be treated as a [Params] axis: it would land in param_label,
# split every series in two, and offer itself as a contention axis for the scaling chart.
#
# Ordered most specific first. "Job" is the fallback because BenchmarkDotNet uses it as the
# catch-all label when several characteristics vary at once, in which case its value is a job id
# ("Job-ABCDEF") rather than a runtime and normalize_framework leaves it alone.
FRAMEWORK_COLUMNS = ("Runtime", "Job")

# BenchmarkDotNet's display names for runtimes -> the target framework moniker used everywhere
# else in this pipeline (the archive path, run.json, -Framework). ".NET 10.0" and "net10.0" are
# the same thing recorded twice in two spellings, and the database should only know one.
_FRAMEWORK_DISPLAY = re.compile(r"^\.NET (?P<fw>Framework )?(?P<version>\d+(?:\.\d+){1,2})$")


def normalize_framework(value: str | None) -> str | None:
    """'.NET 10.0' -> 'net10.0', '.NET Framework 4.8' -> 'net48', 'net10.0' -> 'net10.0'.

    Anything unrecognized is returned unchanged rather than dropped: a value this does not know
    is still a truthful distinction between rows, and silently collapsing it would merge runs
    that are not the same.
    """
    if not value:
        return None
    value = value.strip()
    match = _FRAMEWORK_DISPLAY.match(value)
    if not match:
        return value
    version = match.group("version")
    # .NET Framework monikers drop the dots entirely (4.8 -> net48, 4.6.2 -> net462); .NET
    # Core-era ones keep the single dot and never have a third component (10.0 -> net10.0).
    if match.group("fw"):
        return "net" + version.replace(".", "")
    return "net" + ".".join(version.split(".")[:2])

# Everything BenchmarkDotNet emits that measures rather than parameterizes. Parameters are
# identified by exclusion rather than by a whitelist of known names: a whitelist silently drops
# any [Params] axis nobody remembered to add to it, and because param_label is part of the
# primary key, dropping an axis makes distinct rows collide and overwrite each other. Excluding
# known metrics instead fails safe - an unrecognized metric column would show up as a spurious
# parameter, which is visible, rather than as silently merged rows, which is not.
METRIC_COLUMNS = frozenset({
    "Mean", "Error", "StdDev", "StdErr", "Median", "Min", "Max", "Op/s",
    "Ratio", "RatioSD", "Rank", "Baseline",
    "Gen0", "Gen1", "Gen2", "Allocated", "Alloc Ratio", "Code Size",
    "Completed Work Items", "Lock Contentions",
})

# Which parameter supplies the numeric X axis of the dashboard's scaling view, most preferred
# first. Only one column can, since the chart plots a single dimension; the rest still appear in
# param_label, so no information is lost - they just narrow the series rather than spread it.
# Ordered by which axis a reader of that benchmark would expect to see load plotted against.
CONTENTION_COLUMNS = (
    "Iterations",       # queued waiters - the original and most common contention axis
    "WaiterCount",      # AsyncCountdownEvent's waiter side
    "ParticipantCount", # AsyncBarrier / AsyncCountdownEvent
    "ThreadCount",      # AsyncKeyedLock concurrent access
    "KeyCount",         # AsyncKeyedLock cardinality
    "WindowSize",       # AsyncKeyedLock rolling key: the live working set
    "InitialCount",     # AsyncSemaphore permits
)


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
    # "-" is BenchmarkDotNet reporting a measured zero, not a missing measurement, and conflating
    # the two hid the library's headline result: an allocation-free variant became NULL, so the
    # Allocated metric dropped its points entirely and the series vanished from the chart rather
    # than drawing the flat line at zero that is the whole claim. "NA" (diagnoser did not run)
    # and an empty cell stay NULL - checked across every committed report, neither ever occurs
    # in an Allocated column, so nothing currently relies on that path.
    if cell == "-":
        return 0
    if cell in ("", "NA"):
        return None
    cell = cell.rstrip("B").strip()
    try:
        return int(round(float(cell)))
    except ValueError:
        return None


def parse_ratio(cell: str) -> float | None:
    """The report's Ratio column, which is how BenchmarkDotNet records the declared baseline.

    Every Threading benchmark class marks one method `[Benchmark(Baseline = true)]`, and BDN then
    prints Ratio = 1.00 for it in every parameter group. That is the only place the declaration
    survives into the recorded data - the method attribute is not in the report, and the variant
    name gives no hint which one it was.

    Worth keeping precisely because the alternative is guessing. The dashboard used to pick the
    alphabetically first "Pooled" variant, which chose "Pooled (AsTask)" over "Pooled (ValueTask)"
    and computed every Ratio in the table against the wrong row - wrong in 7 of the 23 reports of
    a full run.
    """
    cell = cell.strip()
    if cell in ("", "-", "NA", "?"):
        return None
    try:
        return float(cell)
    except ValueError:
        return None


def parse_markdown_table(content: str, source_label: str = "<content>", normalize_variant=None):
    """Yields dicts with method/family/variant/cancellation/param_label/param_value/mean/stddev/
    allocated for each data row. `source_label` is only used in stderr diagnostics.

    `normalize_variant`, if given, is applied to the variant name (e.g. a caller-supplied rename
    table mapping historical "Nito.AsyncEx" -> current "Nito"). Defaults to identity."""
    if normalize_variant is None:
        normalize_variant = lambda v: v  # noqa: E731
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
        if cells[0].lower() == "method" and header_cells is None:
            # Earliest era (pre-DescriptionColumn): raw BenchmarkDotNet Method names with no
            # Family (·-joined) breakdown available. Not reliably parseable — skip the whole file.
            print(f"  [skip] {source_label}: raw Method column, no Description - pre-dates "
                  f"ThreadingConfig's DescriptionColumn, skipping file", file=sys.stderr)
            return
        if header_cells is None:
            continue  # data row seen before any recognized header; malformed/unsupported table

        if not any(c and c != "-" for c in cells[1:]):
            continue  # blank separator row, e.g. "|    |    |    |"

        if len(cells) != len(header_cells):
            continue  # row doesn't match header shape; not a data row we understand

        fields = dict(zip(header_cells[1:], cells[1:]))
        description = cells[0]

        mean_ns = parse_measurement_ns(fields.get("Mean", ""))
        if mean_ns is None:
            continue  # failed/NA row

        parts = [p.strip() for p in description.split("·")]
        if not parts or not parts[0]:
            continue

        method = parts[0]
        if len(parts) >= 3:
            family, variant = parts[1], parts[2]
        elif len(parts) == 2:
            family, variant = parts[1], "default"
        else:
            print(f"  [skip] {source_label}: unparseable Description (no family): {description!r}",
                  file=sys.stderr)
            continue
        variant = normalize_variant(variant)

        cancellation = fields.get(CANCELLATION_COLUMN, "").strip() or "None"

        # Present only when the report covers more than one runtime; a single-runtime run leaves
        # this None and the caller substitutes the framework the run directory names.
        framework = None
        for column in FRAMEWORK_COLUMNS:
            if fields.get(column, "").strip():
                framework = normalize_framework(fields[column])
                break

        # Every parameter column, in the order the report lists them, composed into one label.
        # A benchmark with two axes (e.g. KeyCount x Iterations) needs both here: param_label is
        # part of the primary key, so a label naming only one of them makes every value of the
        # other collapse onto a single row, last write winning.
        params = [
            (col, fields[col].strip())
            for col in header_cells[1:]
            if col not in METRIC_COLUMNS and col != CANCELLATION_COLUMN
            and col not in FRAMEWORK_COLUMNS and fields.get(col, "").strip()
        ]
        param_label = ", ".join(f"{col}={value}" for col, value in params) or None

        # A single numeric value for the scaling chart's X axis, which can only plot one
        # dimension. Prefer a recognized contention axis; fall back to the sole parameter when a
        # benchmark has exactly one and it is numeric. Left NULL when neither applies, which the
        # dashboard already treats as "not contention-parameterized".
        param_value = None
        by_name = dict(params)
        candidates = [c for c in CONTENTION_COLUMNS if c in by_name]
        if candidates:
            chosen = by_name[candidates[0]]
        elif len(params) == 1:
            chosen = params[0][1]
        else:
            chosen = None
        if chosen is not None:
            try:
                param_value = int(chosen)
            except ValueError:
                param_value = None

        yield {
            "method": method,
            "family": family,
            "variant": variant,
            "cancellation": cancellation,
            "framework": framework,
            "param_label": param_label,
            "param_value": param_value,
            "mean_ns": mean_ns,
            "ratio": parse_ratio(fields.get("Ratio", "")),
            "stddev_ns": parse_measurement_ns(fields.get("StdDev", "")),
            "allocated_bytes": parse_allocated_bytes(fields.get("Allocated", "")),
        }


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
    # Toolchain is already a target framework moniker; Runtime is the display name and needs
    # normalizing. Every run recorded so far carries both.
    match = re.search(r"Toolchain=(\S+)", text)
    if match:
        spec["framework"] = match.group(1)
    else:
        match = re.search(r"Runtime=(\.NET(?: Framework)? \d+\.\d+)", text)
        if match:
            spec["framework"] = normalize_framework(match.group(1))

    return spec
