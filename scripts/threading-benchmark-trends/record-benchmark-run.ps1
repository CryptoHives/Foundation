# SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
# SPDX-License-Identifier: MIT

# record-benchmark-run.ps1
# Explicit, opt-in step that appends the current local Threading benchmark run into the tracked
# trends database (docfx/packages/threading/benchmark-trends/benchmark-history.sqlite). Sibling
# of scripts/cryptography-benchmark-trends/record-benchmark-run.ps1 (Cryptography's) — same recency-filter
# design, adapted because Threading has no --category and ingests *-report.md (not JSON: see
# append_results.py's docstring for why) so the platform id is derived from the markdown
# machine-spec preamble instead of a JSON HostEnvironmentInfo object.
#
# This is deliberately separate from run-benchmarks.ps1 / update-benchmark-docs.ps1: those stay
# useful for quick before/after comparisons during development, but not every local run is worth
# keeping as a trend data point. Run this only when you've decided a run should be recorded.
#
# Usage:
#   .\scripts\threading-benchmark-trends\record-benchmark-run.ps1
#   .\scripts\threading-benchmark-trends\record-benchmark-run.ps1 -PlatformId linux-arm64-aws-graviton-4
#
# Note: only files written within -RecentWindowMinutes (default 30) of the newest file in the
# results directory are ingested — older leftovers from an earlier, unrelated run are ignored
# automatically. The script lists every file it's about to ingest so you can check first.

[CmdletBinding()]
param(
    [Parameter(HelpMessage = "Platform identifier override, e.g. linux-arm64-aws-graviton-4. Auto-derived from the report's machine-spec preamble if omitted.")]
    [string]$PlatformId,

    [Parameter(HelpMessage = "Directory containing *-report.md files")]
    [string]$ResultsDir,

    [Parameter(HelpMessage = "Path to the tracked trends SQLite database")]
    [string]$DatabasePath,

    [Parameter(HelpMessage = "Commit SHA to tag this run with (defaults to HEAD)")]
    [string]$CommitSha,

    [Parameter(HelpMessage = "Branch name to tag this run with (defaults to the current branch)")]
    [string]$Branch,

    [Parameter(HelpMessage = "Unique run identifier (defaults to <timestamp>-<short-sha>)")]
    [string]$RunId,

    [Parameter(HelpMessage = "Ignore *-report.md files older than this many minutes relative to the newest one in the results directory (excludes stale leftovers from an earlier, unrelated run)")]
    [int]$RecentWindowMinutes = 30,

    [Parameter(HelpMessage = "Show what would be recorded without writing to the database")]
    [switch]$DryRun
)

$ErrorActionPreference = "Stop"

$RepoRoot = Split-Path (Split-Path $PSScriptRoot)

if (-not $PSBoundParameters.ContainsKey('ResultsDir') -or [string]::IsNullOrWhiteSpace($ResultsDir)) {
    $ResultsDir = Join-Path $RepoRoot "tests/Threading/BenchmarkDotNet.Artifacts/results"
}

if (-not $PSBoundParameters.ContainsKey('DatabasePath') -or [string]::IsNullOrWhiteSpace($DatabasePath)) {
    $DatabasePath = Join-Path $RepoRoot "docfx/packages/threading/benchmark-trends/benchmark-history.sqlite"
}

if (-not (Test-Path $ResultsDir)) {
    Write-Host "ERROR: Results directory does not exist: $ResultsDir" -ForegroundColor Red
    Write-Host "Run benchmarks first, e.g.: .\scripts\run-benchmarks.ps1 -Project Threading -Filter ""*AsyncLock*"""
    exit 1
}

$allMdFiles = Get-ChildItem -Path $ResultsDir -Filter "*-report.md" -File
if ($allMdFiles.Count -eq 0) {
    Write-Host "ERROR: No *-report.md files found in $ResultsDir" -ForegroundColor Red
    Write-Host "Run a Threading benchmark first."
    exit 1
}

# BenchmarkDotNet never cleans this directory — it only overwrites files for the classes
# actually included in the current run — so leftover *-report.md from an earlier, unrelated run
# can still be sitting here. Anchor to the newest file's timestamp (not "now", since a long
# multi-class run can take a while) and drop anything older than the tolerance window, so only
# "this run"'s files get ingested without requiring the caller to notice and clean up manually.
$newestWrite = ($allMdFiles | Measure-Object -Property LastWriteTimeUtc -Maximum).Maximum
$staleThreshold = $newestWrite.AddMinutes(-$RecentWindowMinutes)
$mdFiles = $allMdFiles | Where-Object { $_.LastWriteTimeUtc -ge $staleThreshold }
$staleFiles = $allMdFiles | Where-Object { $_.LastWriteTimeUtc -lt $staleThreshold }

Write-Host ""
Write-Host "========================================"
Write-Host " Recording Threading benchmark run to trends DB"
Write-Host "========================================"
Write-Host ""
Write-Host "Results dir: $ResultsDir"
Write-Host "Database: $DatabasePath"
Write-Host ""

if ($staleFiles.Count -gt 0) {
    Write-Host "Ignoring $($staleFiles.Count) file(s) older than $RecentWindowMinutes minute(s) (relative to the newest file) - likely leftovers from an earlier run:" -ForegroundColor Yellow
    foreach ($file in $staleFiles) {
        Write-Host "  - $($file.Name) (last written $($file.LastWriteTime))" -ForegroundColor Yellow
    }
    Write-Host ""
}

Write-Host "Files about to be ingested:"
foreach ($file in $mdFiles) {
    Write-Host "  - $($file.Name)"
}
Write-Host ""

# Extracts the BenchmarkDotNet machine-spec preamble (the fenced block above the results
# table) from a report.md — same convention scripts/update-benchmark-docs.ps1 already parses.
function Get-MachineSpecLines {
    param([string]$Content)

    $lines = $Content -split "`n"
    $specLines = @()
    $inSpec = $false

    foreach ($line in $lines) {
        $trimmed = $line.Trim()
        if ($trimmed -eq '```' -and -not $inSpec) {
            $inSpec = $true
            continue
        }
        if ($inSpec) {
            if ($trimmed -match '^\|' -or $trimmed -eq '```') {
                break
            }
            if ($trimmed -ne '') {
                $specLines += $trimmed
            }
        }
    }

    return $specLines
}

if (-not $PSBoundParameters.ContainsKey('PlatformId') -or [string]::IsNullOrWhiteSpace($PlatformId)) {
    $sampleContent = Get-Content -Path $mdFiles[0].FullName -Raw
    $specLines = Get-MachineSpecLines -Content $sampleContent

    $osLine = if ($specLines.Count -gt 0) { $specLines[0] } else { "" }
    $cpuLine = if ($specLines.Count -gt 1) { $specLines[1] } else { "" }
    $runtimeLine = $specLines | Where-Object { $_ -match '^\[Host\]' -or $_ -match '^\.NET\s+\d' } | Select-Object -First 1
    if (-not $runtimeLine) {
        $runtimeLine = $specLines | Where-Object { $_ -match 'Arm64|arm64|armv8|x86-64|\bX64\b|\bx64\b|\bx86\b' } | Select-Object -First 1
    }

    $osSlug = switch -Regex ($osLine) {
        'Windows' { 'windows'; break }
        'macOS'   { 'macos'; break }
        'Linux'   { 'linux'; break }
        default   { 'unknown-os' }
    }

    $archSlug = switch -Regex ($runtimeLine) {
        'Arm64|arm64|armv8' { 'arm64'; break }
        'X64|x86-64|x64'    { 'x64'; break }
        '\bx86\b'           { 'x86'; break }
        default             { 'unknown-arch' }
    }

    $cpuSlug = $cpuLine -replace ',.*$', ''
    $cpuSlug = $cpuSlug -replace '\s+[0-9.]+GHz\b', ''
    $cpuSlug = $cpuSlug.ToLowerInvariant() -replace '[^a-z0-9]+', '-'
    $cpuSlug = ($cpuSlug -replace '^-+', '') -replace '-+$', ''
    if ([string]::IsNullOrWhiteSpace($cpuSlug)) { $cpuSlug = 'unknown-cpu' }

    $PlatformId = "$osSlug-$archSlug-$cpuSlug"

    if ($PlatformId -match 'unknown-os|unknown-arch|unknown-cpu') {
        Write-Host "ERROR: Could not derive a platform id from the machine-spec preamble: '$PlatformId'." -ForegroundColor Red
        Write-Host "Pass -PlatformId explicitly, e.g. -PlatformId linux-arm64-aws-graviton-4"
        exit 1
    }

    Write-Host "Derived platform id: $PlatformId"
}

if (-not $PSBoundParameters.ContainsKey('CommitSha') -or [string]::IsNullOrWhiteSpace($CommitSha)) {
    $CommitSha = (git -C $RepoRoot rev-parse HEAD).Trim()
}

if (-not $PSBoundParameters.ContainsKey('Branch') -or [string]::IsNullOrWhiteSpace($Branch)) {
    $Branch = (git -C $RepoRoot rev-parse --abbrev-ref HEAD).Trim()
}

if (-not $PSBoundParameters.ContainsKey('RunId') -or [string]::IsNullOrWhiteSpace($RunId)) {
    $timestamp = Get-Date -AsUTC -Format "yyyyMMddTHHmmssZ"
    $shortSha = $CommitSha.Substring(0, [Math]::Min(8, $CommitSha.Length))
    $RunId = "$timestamp-$shortSha"
}

Write-Host "Commit: $CommitSha"
Write-Host "Branch: $Branch"
Write-Host "Run ID: $RunId"
Write-Host ""

$pythonCmd = Get-Command python3 -ErrorAction SilentlyContinue
if (-not $pythonCmd) { $pythonCmd = Get-Command python -ErrorAction SilentlyContinue }
if (-not $pythonCmd) {
    Write-Host "ERROR: No python3/python found on PATH." -ForegroundColor Red
    exit 1
}

$appendScript = Join-Path $PSScriptRoot "append_results.py"

# append_results.py globs *-report.md directly from --results-dir, so the stale-file filter
# above only matters if we actually point it at a directory containing just the filtered set —
# stage those files into a scratch folder rather than passing $ResultsDir as-is.
$stagingDir = Join-Path ([System.IO.Path]::GetTempPath()) "threading-benchmark-trends-staging-$RunId"
New-Item -ItemType Directory -Force -Path $stagingDir | Out-Null
foreach ($file in $mdFiles) {
    Copy-Item -Path $file.FullName -Destination $stagingDir -Force
}

$pyArgs = @(
    $appendScript,
    "--results-dir", $stagingDir,
    "--db", $DatabasePath,
    "--platform", $PlatformId,
    "--commit-sha", $CommitSha,
    "--branch", $Branch,
    "--run-id", $RunId
)

if ($DryRun) {
    Write-Host "[DRY RUN] $($pythonCmd.Source) $($pyArgs -join ' ')" -ForegroundColor Yellow
    Remove-Item -Recurse -Force $stagingDir
    exit 0
}

& $pythonCmd.Source @pyArgs
$exitCode = $LASTEXITCODE
Remove-Item -Recurse -Force $stagingDir

if ($exitCode -ne 0) {
    Write-Host "ERROR: append_results.py failed with exit code $exitCode" -ForegroundColor Red
    exit $exitCode
}

Write-Host ""
Write-Host "========================================"
Write-Host " Database updated - review before committing"
Write-Host "========================================"
Write-Host ""
git -C $RepoRoot diff --stat -- $DatabasePath
Write-Host ""
Write-Host "This is a local change only - nothing was committed or pushed."
Write-Host "If this run is worth keeping as a trend point, commit $DatabasePath yourself."
Write-Host ""
