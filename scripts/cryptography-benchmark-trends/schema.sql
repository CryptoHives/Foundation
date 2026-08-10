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

-- One row per (run, platform): the environment the numbers were produced in.
--
-- Mirrors the table of the same name in scripts/threading-benchmark-trends/schema.sql - these two
-- pipelines are deliberate siblings rather than one generic one, because their result shapes
-- differ, but the environment a run was measured in is identical across both.
--
-- Kept beside benchmark_results rather than folded into it, since it is constant across a run's
-- hundreds of rows. Every field is parsed out of the machine-spec.md that sits next to the
-- scenario tables in the run archive, so this backfills across the whole history.
--
-- The point is attribution: the recorded runs span .NET 10.0.2 through 10.0.9 on three different
-- machines, so a step in a trend line cannot be read as a code regression without knowing whether
-- the floor moved under it.
CREATE TABLE IF NOT EXISTS benchmark_runs (
    run_id          TEXT NOT NULL,
    platform        TEXT NOT NULL,  -- matches benchmark_results.platform
    run_date        TEXT,           -- ISO 8601, same value as the results rows
    commit_sha      TEXT,
    branch          TEXT,
    bdn_version     TEXT,           -- e.g. '0.15.8'
    os              TEXT,           -- e.g. 'Windows 10 (10.0.19045.6456/22H2/2022Update)'
    cpu             TEXT,           -- e.g. 'Intel Xeon CPU E3-1240 v5 3.50GHz'
    logical_cores   INTEGER,
    physical_cores  INTEGER,
    sdk_version     TEXT,           -- e.g. '10.0.102'
    runtime_version TEXT,           -- host runtime, e.g. '10.0.2'
    jit             TEXT,           -- e.g. 'X64 RyuJIT x86-64-v3'
    PRIMARY KEY (run_id, platform)
);

CREATE INDEX IF NOT EXISTS idx_runs_runtime ON benchmark_runs(runtime_version);
