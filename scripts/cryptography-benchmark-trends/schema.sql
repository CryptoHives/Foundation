-- SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
-- SPDX-License-Identifier: MIT
--
-- Schema for the benchmark trend-history database.
--
-- One row per (run, class, method, family, variant, data size) — i.e. one row per
-- distinct BenchmarkDotNet result. A single CI run inserts many rows sharing the
-- same run_id. Deliberately flat/denormalized (no separate "runs" or "algorithms"
-- tables) so every query is a single SELECT with plain WHERE/GROUP BY — this file
-- is queried client-side via sql.js, where join complexity has a real cost.

CREATE TABLE IF NOT EXISTS benchmark_results (
    run_id          TEXT    NOT NULL,  -- e.g. short commit sha + run number; groups one CI run
    run_date        TEXT    NOT NULL,  -- ISO 8601 UTC timestamp, e.g. '2026-07-26T10:15:00Z'
    commit_sha      TEXT,              -- full git commit SHA
    branch          TEXT,              -- git branch name
    platform        TEXT    NOT NULL,  -- e.g. 'windows-x64-amd-ryzen-5-7600x'
    category        TEXT    NOT NULL,  -- 'Hash' | 'Cipher' | 'Mac'
    class_name      TEXT    NOT NULL,  -- e.g. 'Blake3Benchmark'
    method          TEXT    NOT NULL,  -- e.g. 'TryComputeHash', 'ComputeMac'
    family          TEXT    NOT NULL,  -- e.g. 'BLAKE3', 'HMAC-SHA256'
    variant         TEXT    NOT NULL,  -- e.g. 'CryptoHives-AVX512F', 'BouncyCastle', 'OS'
    data_size_label TEXT,              -- e.g. '128KB' (NULL for benchmarks with no size axis)
    data_size_bytes INTEGER,           -- 131072 (for numeric sort/filter; NULL alongside label)
    mean_ns         REAL    NOT NULL,
    stddev_ns       REAL,
    allocated_bytes REAL,
    PRIMARY KEY (run_id, platform, class_name, method, family, variant, data_size_label)
);

-- Powers "all variants of one family/size over time" and "one variant across sizes" queries.
CREATE INDEX IF NOT EXISTS idx_family_variant ON benchmark_results(family, variant);
CREATE INDEX IF NOT EXISTS idx_run_date        ON benchmark_results(run_date);
CREATE INDEX IF NOT EXISTS idx_platform        ON benchmark_results(platform);
