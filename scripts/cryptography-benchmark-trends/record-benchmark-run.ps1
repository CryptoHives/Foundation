# SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
# SPDX-License-Identifier: MIT

# record-benchmark-run.ps1
# Explicit, opt-in step that appends the current local benchmark run into the tracked
# trends database (docfx/packages/security/cryptography/benchmark-trends/benchmark-history.sqlite).
#
# This is deliberately separate from run-benchmarks.ps1 / update-benchmark-docs.ps1: those stay
# useful for quick before/after comparisons during development, but not every local run is worth
# keeping as a trend data point. Run this only when you've decided a run should be recorded.
#
# Usage:
#   .\scripts\cryptography-benchmark-trends\record-benchmark-run.ps1 -Category Hash
#   .\scripts\cryptography-benchmark-trends\record-benchmark-run.ps1 -Category Cipher -PlatformId linux-arm64-aws-graviton-4
#
# Note: only files written within -RecentWindowMinutes (default 30) of the newest file in the
# results directory are ingested — older leftovers from an earlier, unrelated run are ignored
# automatically. --category still tags every file that DOES pass that filter with the same
# category, so mixing e.g. Cipher and Mac benchmarks within one run (or within the window) will
# still mislabel rows — the script lists every file it's about to ingest so you can check.

[CmdletBinding()]
param(
    [Parameter(Mandatory = $true, HelpMessage = "Benchmark category these results belong to")]
    [ValidateSet("Hash", "Cipher", "Mac")]
    [string]$Category,

    [Parameter(HelpMessage = "Platform identifier override, e.g. linux-arm64-aws-graviton-4. Auto-derived from the JSON HostEnvironmentInfo if omitted.")]
    [string]$PlatformId,

    [Parameter(HelpMessage = "Directory containing *-report-full.json files")]
    [string]$ResultsDir,

    [Parameter(HelpMessage = "Path to the tracked trends SQLite database")]
    [string]$DatabasePath,

    [Parameter(HelpMessage = "Commit SHA to tag this run with (defaults to HEAD)")]
    [string]$CommitSha,

    [Parameter(HelpMessage = "Branch name to tag this run with (defaults to the current branch)")]
    [string]$Branch,

    [Parameter(HelpMessage = "Unique run identifier (defaults to <timestamp>-<short-sha>)")]
    [string]$RunId,

    [Parameter(HelpMessage = "Ignore *-report-full.json files older than this many minutes relative to the newest one in the results directory (excludes stale leftovers from an earlier, unrelated run)")]
    [int]$RecentWindowMinutes = 30,

    [Parameter(HelpMessage = "Show what would be recorded without writing to the database")]
    [switch]$DryRun
)

$ErrorActionPreference = "Stop"

$RepoRoot = Split-Path (Split-Path $PSScriptRoot)

if (-not $PSBoundParameters.ContainsKey('ResultsDir') -or [string]::IsNullOrWhiteSpace($ResultsDir)) {
    $ResultsDir = Join-Path $RepoRoot "tests/Security/Cryptography/BenchmarkDotNet.Artifacts/results"
}

if (-not $PSBoundParameters.ContainsKey('DatabasePath') -or [string]::IsNullOrWhiteSpace($DatabasePath)) {
    $DatabasePath = Join-Path $RepoRoot "docfx/packages/security/cryptography/benchmark-trends/benchmark-history.sqlite"
}

if (-not (Test-Path $ResultsDir)) {
    Write-Host "ERROR: Results directory does not exist: $ResultsDir" -ForegroundColor Red
    Write-Host "Run benchmarks first, e.g.: .\scripts\run-benchmarks.ps1 -Project Cryptography -Family $Category"
    exit 1
}

$allJsonFiles = Get-ChildItem -Path $ResultsDir -Filter "*-report-full.json" -File
if ($allJsonFiles.Count -eq 0) {
    Write-Host "ERROR: No *-report-full.json files found in $ResultsDir" -ForegroundColor Red
    Write-Host "The JSON exporter is on by default (HashConfig/MacConfig/CipherConfig) — rerun the benchmark first."
    exit 1
}

# BenchmarkDotNet never cleans this directory — it only overwrites files for the classes
# actually included in the current run — so leftover *-report-full.json from an earlier,
# unrelated run can still be sitting here. Anchor to the newest file's timestamp (not "now",
# since a long multi-family run can take a while) and drop anything older than the tolerance
# window, so only "this run"'s files get ingested without requiring the caller to notice and
# clean up manually.
$newestWrite = ($allJsonFiles | Measure-Object -Property LastWriteTimeUtc -Maximum).Maximum
$staleThreshold = $newestWrite.AddMinutes(-$RecentWindowMinutes)
$jsonFiles = $allJsonFiles | Where-Object { $_.LastWriteTimeUtc -ge $staleThreshold }
$staleFiles = $allJsonFiles | Where-Object { $_.LastWriteTimeUtc -lt $staleThreshold }

Write-Host ""
Write-Host "========================================"
Write-Host " Recording benchmark run to trends DB"
Write-Host "========================================"
Write-Host ""
Write-Host "Category: $Category"
Write-Host "Results dir: $ResultsDir"
Write-Host "Database: $DatabasePath"
Write-Host ""

if ($staleFiles.Count -gt 0) {
    Write-Host "Ignoring $($staleFiles.Count) file(s) older than $RecentWindowMinutes minute(s) (relative to the newest file) — likely leftovers from an earlier run:" -ForegroundColor Yellow
    foreach ($file in $staleFiles) {
        Write-Host "  - $($file.Name) (last written $($file.LastWriteTime))" -ForegroundColor Yellow
    }
    Write-Host ""
}

Write-Host "Files about to be ingested (verify these all belong to '$Category' — mixed categories will mislabel rows):"
foreach ($file in $jsonFiles) {
    Write-Host "  - $($file.Name)"
}
Write-Host ""

if (-not $PSBoundParameters.ContainsKey('PlatformId') -or [string]::IsNullOrWhiteSpace($PlatformId)) {
    $sample = Get-Content -Path $jsonFiles[0].FullName -Raw | ConvertFrom-Json
    $hostInfo = $sample.HostEnvironmentInfo

    $osSlug = switch -Regex ($hostInfo.OsVersion) {
        'Windows' { 'windows'; break }
        'macOS' { 'macos'; break }
        'Linux' { 'linux'; break }
        default { 'unknown-os' }
    }

    $archSlug = switch -Regex ($hostInfo.Architecture) {
        'Arm64' { 'arm64'; break }
        'X64' { 'x64'; break }
        'X86' { 'x86'; break }
        default { 'unknown-arch' }
    }

    $cpuSlug = $hostInfo.ProcessorName.ToLowerInvariant() -replace '[^a-z0-9]+', '-'
    $cpuSlug = ($cpuSlug -replace '^-+', '') -replace '-+$', ''
    if ([string]::IsNullOrWhiteSpace($cpuSlug)) { $cpuSlug = 'unknown-cpu' }

    $PlatformId = "$osSlug-$archSlug-$cpuSlug"

    if ($PlatformId -match 'unknown-os|unknown-arch|unknown-cpu') {
        Write-Host "ERROR: Could not derive a platform id from HostEnvironmentInfo: '$PlatformId'." -ForegroundColor Red
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

# append_results.py globs *-report-full.json directly from --results-dir, so the stale-file
# filter above only matters if we actually point it at a directory containing just the
# filtered set — stage those files into a scratch folder rather than passing $ResultsDir as-is.
$stagingDir = Join-Path ([System.IO.Path]::GetTempPath()) "benchmark-trends-staging-$RunId"
New-Item -ItemType Directory -Force -Path $stagingDir | Out-Null
foreach ($file in $jsonFiles) {
    Copy-Item -Path $file.FullName -Destination $stagingDir -Force
}

$pyArgs = @(
    $appendScript,
    "--results-dir", $stagingDir,
    "--db", $DatabasePath,
    "--platform", $PlatformId,
    "--category", $Category,
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
Write-Host " Database updated — review before committing"
Write-Host "========================================"
Write-Host ""
git -C $RepoRoot diff --stat -- $DatabasePath
Write-Host ""
Write-Host "This is a local change only — nothing was committed or pushed."
Write-Host "If this run is worth keeping as a trend point, commit $DatabasePath yourself."
Write-Host ""
