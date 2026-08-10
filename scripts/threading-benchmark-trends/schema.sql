-- SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
-- SPDX-License-Identifier: MIT
--
-- Schema for the Threading package's benchmark trend-history database. A sibling of
-- scripts/benchmark-trends/schema.sql (Cryptography's) — deliberately a separate database,
-- not merged, since Threading's benchmarks vary along different axes entirely (no data size).
--
-- One row per (run, class, method, family, variant, contention level) — i.e. one row per
-- distinct BenchmarkDotNet result. Deliberately flat/denormalized, queried client-side via
-- sql.js, same rationale as Cryptography's schema.
--
-- Differences from Cryptography's schema:
--   - No `category` column: Threading has no Hash/Cipher/Mac-style second grouping level above
--     "family" (the primitive type, e.g. 'AsyncLock'), so it's dropped rather than populated
--     with a meaningless constant.
--   - `data_size_label`/`data_size_bytes` are replaced with `param_label`/`param_value`,
--     representing contention level (BenchmarkDotNet's `Iterations`/`ParticipantCount`
--     [Params] axis) instead of data size — the closest analog for a "scaling" X axis.
--   - CancellationToken state (None/NotCancelled) is its own `cancellation` column instead of
--     being folded into `variant` as a parenthetical suffix — this lets the dashboard offer a
--     dedicated Cancellation selector (mirroring the contention selector) instead of doubling
--     the number of distinct legend entries for every variant that supports cancellation.

CREATE TABLE IF NOT EXISTS benchmark_results (
    run_id      TEXT    NOT NULL,  -- e.g. short commit sha + run number; groups one run
    run_date    TEXT    NOT NULL,  -- ISO 8601 UTC timestamp, e.g. '2026-07-26T10:15:00Z'
    commit_sha  TEXT,              -- full git commit SHA
    branch      TEXT,              -- git branch name
    platform    TEXT    NOT NULL,  -- e.g. 'windows-x64-amd-ryzen-5-7600x'
    class_name  TEXT    NOT NULL,  -- e.g. 'AsyncLockMultipleBenchmark'
    method      TEXT    NOT NULL,  -- e.g. 'Multiple', 'Single', 'SignalAndWait' (the "Operation")
    family      TEXT    NOT NULL,  -- e.g. 'AsyncLock', 'AsyncBarrier' (the primitive/type compared)
    variant     TEXT    NOT NULL,  -- e.g. 'Pooled (ValueTask)', 'Nito', 'Lock.EnterScope'
    cancellation TEXT   NOT NULL DEFAULT 'None', -- 'None' or 'NotCancelled' (CancellationToken state)
    param_label TEXT,              -- e.g. '10' (contention level; NULL for non-parameterized benchmarks)
    param_value INTEGER,           -- 10 (for numeric sort/filter; NULL alongside label)
    mean_ns     REAL    NOT NULL,
    stddev_ns   REAL,              -- usually NULL: ThreadingConfig hides the StdDev/Error columns
    allocated_bytes REAL,
    PRIMARY KEY (run_id, platform, class_name, method, family, variant, cancellation, param_label)
);

-- Powers "all variants of one family/contention-level over time" and "one variant across
-- contention levels" queries.
CREATE INDEX IF NOT EXISTS idx_family_variant ON benchmark_results(family, variant);
CREATE INDEX IF NOT EXISTS idx_run_date        ON benchmark_results(run_date);
CREATE INDEX IF NOT EXISTS idx_platform        ON benchmark_results(platform);

-- One row per (run, platform): the environment the numbers were produced in.
--
-- Kept beside benchmark_results rather than folded into it, since it is constant across a run's
-- ~900 rows. Every field is parsed out of the machine-spec.md that sits next to the scenario
-- tables and has been committed alongside them since the first run, so this backfills across the
-- whole history rather than starting empty.
--
-- The point is attribution: the .NET runtime moved between nearly every recorded run so far
-- (10.0.3 -> 10.0.5 -> 10.0.9 -> 10.0.10, with the SDK jumping to an 11.0 preview), so a step in
-- a trend line cannot be read as a code regression without knowing whether the floor moved too.
CREATE TABLE IF NOT EXISTS benchmark_runs (
    run_id          TEXT NOT NULL,
    platform        TEXT NOT NULL,  -- matches benchmark_results.platform
    run_date        TEXT,           -- ISO 8601, same value as the results rows
    commit_sha      TEXT,
    branch          TEXT,
    bdn_version     TEXT,           -- e.g. '0.15.8'
    os              TEXT,           -- e.g. 'Windows 11 (10.0.26200.8875/25H2/...)'
    cpu             TEXT,           -- e.g. 'AMD Ryzen 5 7600X 4.70GHz'
    logical_cores   INTEGER,
    physical_cores  INTEGER,
    sdk_version     TEXT,           -- e.g. '11.0.100-preview.5.26302.115'
    runtime_version TEXT,           -- host runtime, e.g. '10.0.10'
    jit             TEXT,           -- e.g. 'X64 RyuJIT x86-64-v4'
    PRIMARY KEY (run_id, platform)
);

CREATE INDEX IF NOT EXISTS idx_runs_runtime ON benchmark_runs(runtime_version);
