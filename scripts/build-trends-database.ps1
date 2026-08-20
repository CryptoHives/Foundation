# SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
# SPDX-License-Identifier: MIT

<#
.SYNOPSIS
    Rebuilds the benchmark trends databases from the run archive on the `benchmarks` branch.

.DESCRIPTION
    A trends database is a derived artifact: the archive of recorded runs is the source of truth,
    and the database is regenerated from it. That keeps a multi-megabyte binary that changes
    wholesale on every rebuild out of the history everyone clones, and it means a parser or schema
    change is applied by re-running this rather than by hand-editing rows.

    Run it before `docfx build` when working on the dashboards locally, so the pages have data.
    `run-docfx.ps1` does that for you.

    If -Archive is not given, a worktree of the `benchmarks` branch is created in a temporary
    directory, used, and removed. Pass -Archive to reuse a worktree you keep around, which is
    faster and lets you build from runs you have not committed yet.

.EXAMPLE
    ./scripts/build-trends-database.ps1
    Rebuilds both packages from the committed `benchmarks` branch.

.EXAMPLE
    ./scripts/build-trends-database.ps1 -Project Threading -Archive ../foundation-bench
    Rebuilds one package from a worktree you manage, including uncommitted runs.
#>
[CmdletBinding()]
param(
    [Parameter(HelpMessage = "Package to rebuild. 'All' does both.")]
    [ValidateSet("Threading", "Cryptography", "All")]
    [string]$Project = "All",

    [Parameter(HelpMessage = "Path to a checkout of the benchmarks branch. A temporary worktree is used when omitted.")]
    [string]$Archive,

    [Parameter(HelpMessage = "Branch holding the run archive")]
    [string]$Branch = "benchmarks",

    [Parameter(HelpMessage = "Output database path. Only valid for a single package; defaults to where docfx expects it.")]
    [string]$DatabasePath
)

$ErrorActionPreference = "Stop"

$RepoRoot = Split-Path $PSScriptRoot

# Each package has its own importer and database. The two schemas genuinely differ - Cryptography
# carries a category and a data-size axis, Threading a contention parameter and a cancellation
# state - so two small readers fit better than one generic one.
$packages = [ordered]@{
    Threading    = @{
        Directory = "threading"
        Importer  = "scripts/threading-benchmark-trends/import_run_archive.py"
        Database  = "docfx/packages/threading/benchmark-trends/benchmark-history.sqlite"
    }
    Cryptography = @{
        Directory = "cryptography"
        Importer  = "scripts/cryptography-benchmark-trends/import_run_archive.py"
        Database  = "docfx/packages/security/cryptography/benchmark-trends/benchmark-history.sqlite"
    }
}

$selected = if ($Project -eq "All") { @($packages.Keys) } else { @($Project) }

if ($DatabasePath -and $selected.Count -gt 1) {
    throw "-DatabasePath applies to one package; pass -Project Threading or -Project Cryptography with it."
}

$python = (Get-Command python3 -ErrorAction SilentlyContinue) ?? (Get-Command python -ErrorAction SilentlyContinue)
if (-not $python) { throw "Python 3 is required to rebuild the trends databases, but neither python3 nor python is on PATH." }

$temporaryWorktree = $null
try {
    if (-not $Archive) {
        # A detached worktree rather than a checkout: the branch shares no history with the code
        # branch, so checking it out in place would replace the working tree.
        $temporaryWorktree = Join-Path ([System.IO.Path]::GetTempPath()) ("trends-archive-" + [System.Guid]::NewGuid().ToString("N").Substring(0, 8))
        Write-Host "Creating temporary worktree of '$Branch' at $temporaryWorktree"
        git -C $RepoRoot worktree add --detach $temporaryWorktree $Branch | Out-Null
        $Archive = $temporaryWorktree
    }

    foreach ($name in $selected) {
        $expected = $packages[$name].Directory
        if (-not (Test-Path (Join-Path $Archive $expected))) {
            throw "No '$expected' directory under '$Archive' - is that a checkout of the $Branch branch?"
        }
    }

    foreach ($name in $selected) {
        $importer = Join-Path $RepoRoot $packages[$name].Importer
        $database = if ($DatabasePath) { $DatabasePath } else { Join-Path $RepoRoot $packages[$name].Database }

        Write-Host ""
        Write-Host "Rebuilding $name -> $database" -ForegroundColor Cyan
        & $python.Source $importer --archive $Archive --db $database
        if ($LASTEXITCODE -ne 0) { throw "$name importer failed with exit code $LASTEXITCODE." }
    }

    Write-Host ""
    Write-Host "Done. Run 'docfx build docfx/docfx.json' to refresh the site." -ForegroundColor Green
}
finally {
    if ($temporaryWorktree -and (Test-Path $temporaryWorktree)) {
        git -C $RepoRoot worktree remove --force $temporaryWorktree | Out-Null
    }
}
