# SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
# SPDX-License-Identifier: MIT

<#
.SYNOPSIS
    Rebuilds a benchmark trends database from the run archive on the `benchmarks` branch.

.DESCRIPTION
    The database is a derived artifact: the archive of recorded runs is the source of truth, and
    the database is regenerated from it. That keeps a multi-megabyte binary that changes wholesale
    on every rebuild out of the history everyone clones, and it means a parser or schema change is
    applied by re-running this rather than by hand-editing rows.

    Run it before `docfx build` when working on the dashboard locally, so the page has data.

    If -Archive is not given, a worktree of the `benchmarks` branch is created in a temporary
    directory, used, and removed. Pass -Archive to reuse a worktree you keep around, which is
    faster and lets you build from uncommitted runs.

.EXAMPLE
    ./scripts/build-trends-database.ps1
    Builds from the committed `benchmarks` branch using a throwaway worktree.

.EXAMPLE
    ./scripts/build-trends-database.ps1 -Archive ../foundation-bench
    Builds from a worktree you manage, including runs you have not committed yet.
#>
[CmdletBinding()]
param(
    [Parameter(HelpMessage = "Package to rebuild")]
    [ValidateSet("Threading")]
    [string]$Project = "Threading",

    [Parameter(HelpMessage = "Path to a checkout of the benchmarks branch. A temporary worktree is used when omitted.")]
    [string]$Archive,

    [Parameter(HelpMessage = "Branch holding the run archive")]
    [string]$Branch = "benchmarks",

    [Parameter(HelpMessage = "Output database path. Defaults to the location docfx expects.")]
    [string]$DatabasePath
)

$ErrorActionPreference = "Stop"

$RepoRoot = Split-Path $PSScriptRoot

if (-not $DatabasePath) {
    $DatabasePath = Join-Path $RepoRoot "docfx/packages/threading/benchmark-trends/benchmark-history.sqlite"
}

$python = (Get-Command python3 -ErrorAction SilentlyContinue) ?? (Get-Command python -ErrorAction SilentlyContinue)
if (-not $python) { throw "Python 3 is required to rebuild the trends database, but neither python3 nor python is on PATH." }

$importer = Join-Path $RepoRoot "scripts/threading-benchmark-trends/import_run_archive.py"

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

    if (-not (Test-Path (Join-Path $Archive "threading"))) {
        throw "No 'threading' directory under '$Archive' - is that a checkout of the $Branch branch?"
    }

    Write-Host "Rebuilding $DatabasePath from $Archive"
    & $python.Source $importer --archive $Archive --db $DatabasePath
    if ($LASTEXITCODE -ne 0) { throw "Importer failed with exit code $LASTEXITCODE." }

    Write-Host ""
    Write-Host "Done. Run 'docfx build docfx/docfx.json' to refresh the site." -ForegroundColor Green
}
finally {
    if ($temporaryWorktree -and (Test-Path $temporaryWorktree)) {
        git -C $RepoRoot worktree remove --force $temporaryWorktree | Out-Null
    }
}
