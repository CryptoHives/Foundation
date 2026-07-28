#!/usr/bin/env python3
# SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
# SPDX-License-Identifier: MIT
"""
Shared markdown-table parsing for Threading's benchmark trends pipeline, used by both
import_historical_markdown.py (git history backfill) and append_results.py (live recording).
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
  (None/NotCancelled/Cancelled) — folded into `variant` here rather than given its own schema
  column, so cancelled vs. non-cancelled still renders as distinguishable dashboard lines.
"""

import re
import sys

MEASUREMENT_PATTERN = re.compile(r"^([\d,]+\.?\d*)\s*(ns|μs|us|ms)$")
CONTENTION_COLUMNS = ("Iterations", "ParticipantCount")
CANCELLATION_COLUMN = "cancellationType"


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


def parse_markdown_table(content: str, source_label: str = "<content>", normalize_variant=None):
    """Yields dicts with method/family/variant/param_label/param_value/mean/stddev/allocated
    for each data row. `source_label` is only used in stderr diagnostics.

    `normalize_variant`, if given, is applied to the *base* variant name before the
    cancellation-state suffix (e.g. " (NotCancelled)") is folded on — so a caller-supplied
    rename table (e.g. historical "Nito.AsyncEx" -> current "Nito") matches regardless of
    whether the row also varies by cancellation state. Defaults to identity."""
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

        cancellation = fields.get(CANCELLATION_COLUMN, "").strip()
        if cancellation and cancellation != "None":
            variant = f"{variant} ({cancellation})"

        param_label = None
        for col in CONTENTION_COLUMNS:
            if col in fields and fields[col].strip():
                param_label = fields[col].strip()
                break
        param_value = None
        if param_label is not None:
            try:
                param_value = int(param_label)
            except ValueError:
                param_value = None

        yield {
            "method": method,
            "family": family,
            "variant": variant,
            "param_label": param_label,
            "param_value": param_value,
            "mean_ns": mean_ns,
            "stddev_ns": parse_measurement_ns(fields.get("StdDev", "")),
            "allocated_bytes": parse_allocated_bytes(fields.get("Allocated", "")),
        }
