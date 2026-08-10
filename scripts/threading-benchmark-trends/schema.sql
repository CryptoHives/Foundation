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
    -- The target framework the row executed on, e.g. 'net10.0', 'net8.0', 'net48'. Part of the
    -- primary key: the same commit measured on the same machine under two frameworks is two
    -- distinct results, and without this they would overwrite each other. NOT NULL rather than
    -- nullable because SQLite treats NULLs in a key as distinct, so a nullable key column
    -- silently appends a duplicate row on every rebuild instead of replacing - the bug that
    -- inflated this database from 4,718 rows to 6,413 when param_label was left nullable.
    -- No DEFAULT for the same reason: the importer always knows the framework (the archive path
    -- names it), so a missing value means something upstream broke and should fail loudly rather
    -- than be labelled with whatever was current when this file was written.
    framework   TEXT    NOT NULL,
    param_label TEXT,              -- e.g. '10' (contention level; NULL for non-parameterized benchmarks)
    param_value INTEGER,           -- 10 (for numeric sort/filter; NULL alongside label)
    mean_ns     REAL    NOT NULL,
    stddev_ns   REAL,              -- usually NULL: ThreadingConfig hides the StdDev/Error columns
    allocated_bytes REAL,
    PRIMARY KEY (run_id, platform, framework, class_name, method, family, variant, cancellation, param_label)
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
    framework       TEXT NOT NULL,  -- target framework, e.g. 'net10.0' - see benchmark_results
    PRIMARY KEY (run_id, platform, framework)
);

CREATE INDEX IF NOT EXISTS idx_runs_runtime ON benchmark_runs(runtime_version);
CREATE INDEX IF NOT EXISTS idx_runs_framework ON benchmark_runs(framework);

-- One row per (run, platform, package): the versions of the libraries the run measured against.
--
-- benchmark_runs answers "what machine and runtime", this answers "what did we compare to". A
-- competitor's line steps when that competitor ships a new version just as readily as when our
-- code changes, and until this table existed the two were indistinguishable in a trend chart -
-- AsyncKeyedLock went 7.1.8 -> 8.0.0 -> 8.0.1 -> 8.0.2 across the recorded history, and
-- Cryptography's BouncyCastle went 2.6.2 -> 2.7.0 in #210, with nothing in the recorded data to
-- show for any of it.
--
-- Its own table rather than columns on benchmark_runs because the set of packages is neither
-- fixed nor small, and it changes as competitors are added and dropped.
--
-- Populated from the `packages` block of each run's run.json. `source` records where that block
-- came from: 'project.assets.json' is the resolved restore graph, recorded at run time and
-- authoritative; 'Directory.Packages.props' is the declared central pin, recovered from git for
-- runs made before the resolved graph was captured. Central pinning makes the two agree in
-- practice, but declared is a minimum and resolved is a fact, so they are not interchangeable.
CREATE TABLE IF NOT EXISTS benchmark_run_packages (
    run_id      TEXT NOT NULL,
    platform    TEXT NOT NULL,  -- matches benchmark_runs.platform
    package_id  TEXT NOT NULL,  -- NuGet id, e.g. 'AsyncKeyedLock'
    version     TEXT NOT NULL,  -- e.g. '8.0.2'
    source      TEXT,           -- 'project.assets.json' or 'Directory.Packages.props'
    -- Keyed by framework as well, because the resolved graph genuinely differs between them:
    -- several competitors are referenced only for some target frameworks (Cryptography's Blake3
    -- packages are net8.0+ only, Threading's KeyedSemaphores and ProtoPromise exclude net48), so
    -- one run's package set is not the other's.
    framework   TEXT NOT NULL,
    PRIMARY KEY (run_id, platform, framework, package_id)
);

CREATE INDEX IF NOT EXISTS idx_run_packages_id ON benchmark_run_packages(package_id);
