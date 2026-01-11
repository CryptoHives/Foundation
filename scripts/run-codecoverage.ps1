# SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
# SPDX-License-Identifier: MIT

# run-codecoverage.ps1
# Runs tests with code coverage and generates HTML reports
# Usage: .\scripts\run-codecoverage.ps1 [-Framework net10.0] [-Project Threading] [-OpenReport]

[CmdletBinding()]
param(
    [Parameter(HelpMessage = "Target framework to test (e.g., net10.0, net8.0, net48)")]
    [ValidateSet("net10.0", "net8.0", "net48")]
    [string]$Framework = "net10.0",

    [Parameter(HelpMessage = "Specific test project to run (e.g., Threading, Memory, or empty for all)")]
    [ValidateSet("", "Threading", "Memory", "Threading.Analyzers")]
    [string]$Project = "",

    [Parameter(HelpMessage = "Build configuration")]
    [ValidateSet("Release", "Debug")]
    [string]$Configuration = "Release",

    [Parameter(HelpMessage = "Verbosity level for dotnet")]
    [ValidateSet("q", "m", "n", "d", "diag")]
    [string]$Verbosity = "n",

    [Parameter(HelpMessage = "Open HTML report in browser after completion")]
    [switch]$OpenReport,

    [Parameter(HelpMessage = "Skip report generation (only run tests with coverage)")]
    [switch]$SkipReport,

    [Parameter(HelpMessage = "Clean previous results before running")]
    [switch]$Clean,

    [Parameter(HelpMessage = "Dry run - show commands without executing")]
    [switch]$DryRun
)

$ErrorActionPreference = "Stop"

# Get repository root
$scriptPath = Split-Path -Parent $MyInvocation.MyCommand.Path
$repoRoot = Split-Path -Parent $scriptPath
$solutionFile = Join-Path $repoRoot "CryptoHives .NET Foundation.sln"
$coverletSettings = Join-Path $repoRoot "tests\coverlet.runsettings.xml"
$testResultsDir = Join-Path $repoRoot "TestResults"
$codeCoverageDir = Join-Path $repoRoot "CodeCoverage"

Write-Host ""
Write-Host "========================================"
Write-Host " CryptoHives Code Coverage"
Write-Host "========================================"
Write-Host ""
Write-Host "Configuration:"
Write-Host "  Framework:     $Framework"
Write-Host "  Project:       $(if ($Project) { $Project } else { 'All' })"
Write-Host "  Configuration: $Configuration"
Write-Host "  Results Dir:   $testResultsDir"
Write-Host "  Coverage Dir:  $codeCoverageDir"
Write-Host ""

# Validate solution exists
if (-not (Test-Path $solutionFile)) {
    Write-Host "ERROR: Solution file not found at $solutionFile" -ForegroundColor Red
    exit 1
}

# Validate coverlet settings exist
if (-not (Test-Path $coverletSettings)) {
    Write-Host "ERROR: Coverlet settings not found at $coverletSettings" -ForegroundColor Red
    exit 1
}

# Clean previous results if requested or by default
if ($Clean -or -not $DryRun) {
    Write-Host "Cleaning previous results..." -ForegroundColor Yellow

    if (Test-Path $codeCoverageDir) {
        if ($DryRun) {
            Write-Host "  [DRY RUN] Would remove: $codeCoverageDir" -ForegroundColor Yellow
        } else {
            Remove-Item -Path $codeCoverageDir -Recurse -Force -ErrorAction SilentlyContinue
            Write-Host "  Removed: $codeCoverageDir" -ForegroundColor Gray
        }
    }

    if (Test-Path $testResultsDir) {
        if ($DryRun) {
            Write-Host "  [DRY RUN] Would remove: $testResultsDir" -ForegroundColor Yellow
        } else {
            Remove-Item -Path $testResultsDir -Recurse -Force -ErrorAction SilentlyContinue
            Write-Host "  Removed: $testResultsDir" -ForegroundColor Gray
        }
    }
    Write-Host ""
}

# Determine test target
$testTarget = $solutionFile
if ($Project) {
    $testTarget = Join-Path $repoRoot "tests\$Project\$Project.Tests.csproj"
    if (-not (Test-Path $testTarget)) {
        Write-Host "ERROR: Test project not found at $testTarget" -ForegroundColor Red
        exit 1
    }
}

# Build dotnet test command
$dotnetArgs = @(
    "test"
    "`"$testTarget`"" 
    "-v", $Verbosity
    "--configuration", $Configuration
    "--framework", $Framework
    "--collect:`"XPlat Code Coverage`"" 
    "--settings", $coverletSettings
    "--results-directory", $testResultsDir
)

$testCmd = "dotnet " + ($dotnetArgs -join " ")
Write-Host "Test Command:" -ForegroundColor Cyan
Write-Host "  $testCmd" -ForegroundColor Gray
Write-Host ""

if ($DryRun) {
    Write-Host "[DRY RUN] Would execute test command" -ForegroundColor Yellow
} else {
    Write-Host "Running tests with code coverage..." -ForegroundColor Green
    Write-Host "========================================"
    Write-Host ""

    Push-Location $repoRoot
    try {
        & dotnet test `"$testTarget`" -v $Verbosity --configuration $Configuration --framework $Framework --collect:"XPlat Code Coverage" --settings $coverletSettings --results-directory $testResultsDir

        if ($LASTEXITCODE -ne 0) {
            Write-Host ""
            Write-Host "Tests failed with exit code: $LASTEXITCODE" -ForegroundColor Red
            exit $LASTEXITCODE
        }
    }
    finally {
        Pop-Location
    }
}

# Generate report
if (-not $SkipReport) {
    Write-Host ""
    Write-Host "========================================"
    Write-Host " Generating Coverage Report"
    Write-Host "========================================"
    Write-Host ""

    # Check if reportgenerator is installed
    $reportGenInstalled = $null -ne (Get-Command reportgenerator -ErrorAction SilentlyContinue)

    if (-not $reportGenInstalled) {
        Write-Host "Installing dotnet-reportgenerator-globaltool..." -ForegroundColor Yellow
        if ($DryRun) {
            Write-Host "[DRY RUN] Would install reportgenerator" -ForegroundColor Yellow
        } else {
            & dotnet tool install -g dotnet-reportgenerator-globaltool
        }
    }

    $reportArgs = @(
        "-reports:$testResultsDir/**/coverage.cobertura.xml"
        "-targetdir:$codeCoverageDir"
        "-title:CryptoHives .NET Foundation Test Coverage"
        "-reporttypes:Badges;Html;HtmlSummary;Cobertura"
    )

    $reportCmd = "reportgenerator " + ($reportArgs -join " ")
    Write-Host "Report Command:" -ForegroundColor Cyan
    Write-Host "  $reportCmd" -ForegroundColor Gray
    Write-Host ""

    if ($DryRun) {
        Write-Host "[DRY RUN] Would generate report" -ForegroundColor Yellow
    } else {
        & reportgenerator @reportArgs

        if ($LASTEXITCODE -ne 0) {
            Write-Host ""
            Write-Host "Report generation failed with exit code: $LASTEXITCODE" -ForegroundColor Red
            exit $LASTEXITCODE
        }
    }
}

Write-Host ""
Write-Host "========================================"
Write-Host " Code Coverage Complete!"
Write-Host "========================================"
Write-Host ""
Write-Host "Results:"
Write-Host "  Test Results: $testResultsDir"
Write-Host "  HTML Report:  $codeCoverageDir\index.html"
Write-Host ""

# Open report in browser
if ($OpenReport -and -not $SkipReport -and -not $DryRun) {
    $reportPath = Join-Path $codeCoverageDir "index.html"
    if (Test-Path $reportPath) {
        Write-Host "Opening report in browser..." -ForegroundColor Green
        Start-Process $reportPath
    } else {
        Write-Host "WARNING: Report file not found at $reportPath" -ForegroundColor Yellow
    }
}
