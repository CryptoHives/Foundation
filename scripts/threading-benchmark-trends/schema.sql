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
--   - CancellationToken state (None/NotCancelled/Cancelled), where present, is folded into
--     `variant` (e.g. 'Pooled' vs 'Pooled (Cancelled)') rather than given its own column, so
--     it still renders as its own comparable line without a sixth schema dimension.

CREATE TABLE IF NOT EXISTS benchmark_results (
    run_id      TEXT    NOT NULL,  -- e.g. short commit sha + run number; groups one run
    run_date    TEXT    NOT NULL,  -- ISO 8601 UTC timestamp, e.g. '2026-07-26T10:15:00Z'
    commit_sha  TEXT,              -- full git commit SHA
    branch      TEXT,              -- git branch name
    platform    TEXT    NOT NULL,  -- e.g. 'windows-x64-amd-ryzen-5-7600x'
    class_name  TEXT    NOT NULL,  -- e.g. 'AsyncLockMultipleBenchmark'
    method      TEXT    NOT NULL,  -- e.g. 'Multiple', 'Single', 'SignalAndWait' (the "Operation")
    family      TEXT    NOT NULL,  -- e.g. 'AsyncLock', 'SemaphoreSlim' (the primitive/type compared)
    variant     TEXT    NOT NULL,  -- e.g. 'Pooled (ValueTask)', 'Nito', 'System (Cancelled)'
    param_label TEXT,              -- e.g. '10' (contention level; NULL for non-parameterized benchmarks)
    param_value INTEGER,           -- 10 (for numeric sort/filter; NULL alongside label)
    mean_ns     REAL    NOT NULL,
    stddev_ns   REAL,              -- usually NULL: ThreadingConfig hides the StdDev/Error columns
    allocated_bytes REAL,
    PRIMARY KEY (run_id, platform, class_name, method, family, variant, param_label)
);

-- Powers "all variants of one family/contention-level over time" and "one variant across
-- contention levels" queries.
CREATE INDEX IF NOT EXISTS idx_family_variant ON benchmark_results(family, variant);
CREATE INDEX IF NOT EXISTS idx_run_date        ON benchmark_results(run_date);
CREATE INDEX IF NOT EXISTS idx_platform        ON benchmark_results(platform);
