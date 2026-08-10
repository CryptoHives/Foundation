# CryptoHives benchmark run archive

This is an orphan branch. It shares no history with `main` and contains no source code — only
recorded benchmark runs, so that recording a run does not add to the tree everyone clones.

## Layout

```
<package>/<code-commit>/<platform>/<framework>/
    run.json          what the numbers measure, and which library versions they measure against
    machine-spec.md   the machine and runtime they were measured on
    <scenario>.md     one BenchmarkDotNet report per benchmark class
```

A run is keyed by **the commit its binaries were built from**, not by the commit that recorded
it. Two machines measuring the same build therefore land in one run directory as two platform
directories, which is what makes a cross-platform comparison possible at all.

The framework level is what lets the same commit be measured on the same machine under more than
one target framework — net10.0 against net8.0, or net10.0 against net48. Without it the second
recording overwrote the first file by file, since every report has the same name in both. A run
covering several runtimes in one BenchmarkDotNet invocation instead lands in one directory and
splits per row, because BenchmarkDotNet moves the runtime into a table column as soon as it varies.

Nothing here is ever overwritten: a new run is a new directory. That is what lets the trends
database be rebuilt from a plain directory listing rather than by replaying git history, and it
means a run can be corrected or withdrawn by editing one directory.

## Recording a run

From a checkout of the code branch, with results in `tests/<Package>/BenchmarkDotNet.Artifacts`:

```
git worktree add ../foundation-bench benchmarks
./scripts/update-benchmark-docs.ps1 -Project Threading -DestDir ../foundation-bench/threading
cd ../foundation-bench && git add . && git commit && git push
gh workflow run docfx.yml     # publish it: pushing this branch does not
```

That last step is not optional. The trends database is generated when the docs workflow runs, and a
push to this branch cannot start it — GitHub only runs workflows that exist in the pushed ref, and
this branch carries no `.github/` directory. Without the dispatch the run sits here unpublished
until something else pushes to `main`.

`update-benchmark-docs.ps1` writes `run.json`, defaulting the code commit to `HEAD`. Pass
`-CodeCommit` when recording a run after the fact, or when HEAD has moved on since the run.

## Third-party library versions

`run.json` also carries a `packages` block: the version of every library the run measured
against, read from the benchmark project's resolved NuGet graph
(`obj/project.assets.json`). Pass `-TargetFramework` if the benchmarks did not run on the
default `net10.0`, since the resolved graph is per framework.

This exists because a competitor's trend line steps when that competitor ships a release just as
readily as when our own code changes, and nothing else in a recorded run distinguishes the two —
BouncyCastle went 2.6.2 to 2.7.0, and Microsoft.VisualStudio.Threading 17.14.15 to 18.7.23,
across runs already in this archive. The dashboard shows the version in each point's tooltip and
marks any compared row whose library moved between the two runs.

Runs recorded before this existed were backfilled from the central pins in
`Directory.Packages.props` at their code commit, and are stamped
`"packagesSource": "Directory.Packages.props"` rather than `"project.assets.json"` — a declared
minimum, not a resolved fact. To backfill a run added from an older commit:

```
python scripts/backfill-run-packages.py --archive ../foundation-bench
```

It skips any run that already has a `packages` block, so it is safe to re-run.

## Rebuilding the trends database

```
python scripts/threading-benchmark-trends/import_run_archive.py \
    --archive ../foundation-bench \
    --db docfx/packages/threading/benchmark-trends/benchmark-history.sqlite
```

The database is a derived artifact and is not committed — this archive is the source of truth.
