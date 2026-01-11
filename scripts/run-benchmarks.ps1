# SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
# SPDX-License-Identifier: MIT

# run-benchmarks.ps1
# Runs BenchmarkDotNet benchmarks for the Threading library
# Usage: .\scripts\run-benchmarks.ps1 [-Filter "*AsyncLock*"] [-Framework net10.0] [-Runtimes net10.0,net8.0]

[CmdletBinding()]
param(
    [Parameter(HelpMessage = "Filter for benchmark names (e.g., '*AsyncLock*', 'AsyncAutoResetEvent*')")]
    [string]$Filter = "*",

    [Parameter(HelpMessage = "Target framework to build against (e.g., net10.0, net8.0)")]
    [ValidateSet("net10.0", "net8.0", "net48")]
    [string]$Framework = "net10.0",

    [Parameter(HelpMessage = "Comma-separated list of runtimes to benchmark (e.g., 'net10.0', 'net10.0,net8.0')")]
    [string]$Runtimes = "net10.0",

    [Parameter(HelpMessage = "Build configuration")]
    [ValidateSet("Release", "Debug")]
    [string]$Configuration = "Release",

    [Parameter(HelpMessage = "Verbosity level for dotnet")]
    [ValidateSet("q", "m", "n", "d", "diag")]
    [string]$Verbosity = "n",

    [Parameter(HelpMessage = "Show available benchmarks without running")]
    [switch]$List,

    [Parameter(HelpMessage = "Dry run - show command without executing")]
    [switch]$DryRun,

    [Parameter(HelpMessage = "Additional arguments to pass to BenchmarkDotNet")]
    [string[]]$ExtraArgs
)

$ErrorActionPreference = "Stop"

# Get repository root
$scriptPath = Split-Path -Parent $MyInvocation.MyCommand.Path
$repoRoot = Split-Path -Parent $scriptPath
$testProject = Join-Path $repoRoot "tests\Threading"

Write-Host ""
Write-Host "========================================"
Write-Host " CryptoHives Threading Benchmarks"
Write-Host "========================================"
Write-Host ""
Write-Host "Configuration:"
Write-Host "  Filter:        $Filter"
Write-Host "  Framework:     $Framework"
Write-Host "  Runtimes:      $Runtimes"
Write-Host "  Configuration: $Configuration"
Write-Host "  Project:       $testProject"
Write-Host ""

# Validate project exists
if (-not (Test-Path $testProject)) {
    Write-Host "ERROR: Test project not found at $testProject" -ForegroundColor Red
    exit 1
}

# Build the command arguments
$dotnetArgs = @(
    "run"
    "-v", $Verbosity
    "--configuration", $Configuration
    "--framework", $Framework
    "--"
)

if ($List) {
    $dotnetArgs += "--list"
} else {
    $dotnetArgs += "--filter", $Filter
    $dotnetArgs += "--runtimes", $Runtimes
}

# Add any extra arguments
if ($ExtraArgs) {
    $dotnetArgs += $ExtraArgs
}

# Show command
$cmdDisplay = "dotnet " + ($dotnetArgs -join " ")
Write-Host "Command: $cmdDisplay" -ForegroundColor Cyan
Write-Host ""

if ($DryRun) {
    Write-Host "[DRY RUN] Command would be executed in: $testProject" -ForegroundColor Yellow
    exit 0
}

# Change to test project directory and run
Push-Location $testProject
try {
    Write-Host "Starting benchmarks..." -ForegroundColor Green
    Write-Host "========================================"
    Write-Host ""

    & dotnet @dotnetArgs

    $exitCode = $LASTEXITCODE
    if ($exitCode -ne 0) {
        Write-Host ""
        Write-Host "Benchmarks failed with exit code: $exitCode" -ForegroundColor Red
        exit $exitCode
    }

    Write-Host ""
    Write-Host "========================================"
    Write-Host " Benchmarks completed successfully!"
    Write-Host "========================================"
    Write-Host ""
    Write-Host "Results saved to:"
    Write-Host "  $testProject\BenchmarkDotNet.Artifacts\results\"
    Write-Host ""
    Write-Host "To update documentation, run:"
    Write-Host "  .\scripts\update-benchmark-docs.ps1"
    Write-Host ""
}
finally {
    Pop-Location
}
