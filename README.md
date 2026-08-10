# CryptoHives benchmark run archive

This is an orphan branch. It shares no history with `main` and contains no source code — only
recorded benchmark runs, so that recording a run does not add to the tree everyone clones.

## Layout

```
<package>/<code-commit>/<platform>/
    run.json          what the numbers measure
    machine-spec.md   the machine and runtime they were measured on
    <scenario>.md     one BenchmarkDotNet report per benchmark class
```

A run is keyed by **the commit its binaries were built from**, not by the commit that recorded
it. Two machines measuring the same build therefore land in one run directory as two platform
directories, which is what makes a cross-platform comparison possible at all.

Nothing here is ever overwritten: a new run is a new directory. That is what lets the trends
database be rebuilt from a plain directory listing rather than by replaying git history, and it
means a run can be corrected or withdrawn by editing one directory.

## Recording a run

From a checkout of the code branch, with results in `tests/<Package>/BenchmarkDotNet.Artifacts`:

```
git worktree add ../foundation-bench benchmarks
./scripts/update-benchmark-docs.ps1 -Project Threading -DestDir ../foundation-bench/threading
cd ../foundation-bench && git add . && git commit && git push
```

`update-benchmark-docs.ps1` writes `run.json`, defaulting the code commit to `HEAD`. Pass
`-CodeCommit` when recording a run after the fact, or when HEAD has moved on since the run.

## Rebuilding the trends database

```
python scripts/threading-benchmark-trends/import_run_archive.py \
    --archive ../foundation-bench \
    --db docfx/packages/threading/benchmark-trends/benchmark-history.sqlite
```

The database is a derived artifact and is not committed — this archive is the source of truth.
