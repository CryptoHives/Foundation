# SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
# SPDX-License-Identifier: MIT

<#
.SYNOPSIS
    Generates benchmark visualization charts using R scripts.

.DESCRIPTION
    This script generates various benchmark charts from BenchmarkDotNet results:
    - Per-algorithm grouped charts (throughput by data size)
    - Cross-algorithm comparison chart (all CryptoHives implementations)
    - OS Native vs CryptoHives comparison chart

.PARAMETER ResultsDir
    Path to the BenchmarkDotNet results directory containing *-report.md files.
    Defaults to tests\Security\Cryptography\BenchmarkDotNet.Artifacts\results

.PARAMETER Size
    Data size to use for comparison charts (e.g., "1KB", "8KB", "128KB").
    Defaults to "1KB".

.PARAMETER SkipGrouped
    Skip generation of per-algorithm grouped charts.

.PARAMETER SkipComparison
    Skip generation of cross-algorithm comparison chart.

.PARAMETER SkipOsNative
    Skip generation of OS Native vs CryptoHives chart.

.EXAMPLE
    .\generate-benchmark-charts.ps1
    # Generates all charts with default settings

.EXAMPLE
    .\generate-benchmark-charts.ps1 -Size "8KB" -SkipGrouped
    # Generates only comparison charts for 8KB data size
#>

[CmdletBinding()]
param(
    [Parameter()]
    [string]$ResultsDir,

    [Parameter()]
    [string]$Size = "1KB",

    [switch]$SkipGrouped,
    [switch]$SkipComparison,
    [switch]$SkipOsNative
)

$ErrorActionPreference = "Stop"

# Find repository root
$repoRoot = Split-Path -Parent $PSScriptRoot

# Default results directory
if (-not $ResultsDir) {
    $ResultsDir = Join-Path $repoRoot "tests\Security\Cryptography\BenchmarkDotNet.Artifacts\results"
}

# Check if results directory exists
if (-not (Test-Path $ResultsDir)) {
    Write-Error "Results directory not found: $ResultsDir"
    exit 1
}

# Check for Rscript
$rscript = Get-Command Rscript -ErrorAction SilentlyContinue
if (-not $rscript) {
    Write-Error "Rscript not found. Please install R from https://cran.r-project.org/"
    exit 1
}

Write-Host "Benchmark Chart Generator" -ForegroundColor Cyan
Write-Host "=========================" -ForegroundColor Cyan
Write-Host "Results directory: $ResultsDir"
Write-Host "Comparison data size: $Size"
Write-Host ""

$scriptsDir = $PSScriptRoot
$successCount = 0
$failCount = 0

# 1. Generate per-algorithm grouped charts
if (-not $SkipGrouped) {
    Write-Host "Generating per-algorithm grouped charts..." -ForegroundColor Yellow
    $chartScript = Join-Path $scriptsDir "generate-grouped-charts.R"
    
    if (-not (Test-Path $chartScript)) {
        Write-Warning "Script not found: $chartScript"
    } else {
        $mdFiles = Get-ChildItem -Path $ResultsDir -Filter "*-report.md" -ErrorAction SilentlyContinue
        
        foreach ($md in $mdFiles) {
            $outputPng = $md.FullName -replace "-report\.md$", "-grouped.png"
            Write-Host "  Processing: $($md.Name)" -ForegroundColor Gray -NoNewline
            
            try {
                $output = & Rscript $chartScript $md.FullName $outputPng 2>&1
                if ($LASTEXITCODE -eq 0 -and (Test-Path $outputPng)) {
                    Write-Host " ✓" -ForegroundColor Green
                    $successCount++
                } else {
                    Write-Host " ✗" -ForegroundColor Red
                    $failCount++
                }
            } catch {
                Write-Host " ✗" -ForegroundColor Red
                $failCount++
            }
        }
        Write-Host ""
    }
}

# 2. Generate cross-algorithm comparison chart
if (-not $SkipComparison) {
    Write-Host "Generating cross-algorithm comparison chart..." -ForegroundColor Yellow
    $chartScript = Join-Path $scriptsDir "generate-comparison-chart.R"
    $outputPng = Join-Path $ResultsDir "comparison-$Size.png"
    
    if (-not (Test-Path $chartScript)) {
        Write-Warning "Script not found: $chartScript"
    } else {
        Write-Host "  Output: comparison-$Size.png" -ForegroundColor Gray -NoNewline
        
        try {
            $output = & Rscript $chartScript $ResultsDir $outputPng $Size 2>&1
            if ($LASTEXITCODE -eq 0 -and (Test-Path $outputPng)) {
                Write-Host " ✓" -ForegroundColor Green
                $successCount++
            } else {
                Write-Host " ✗" -ForegroundColor Red
                $failCount++
            }
        } catch {
            Write-Host " ✗" -ForegroundColor Red
            $failCount++
        }
        Write-Host ""
    }
}

# 3. Generate OS Native vs CryptoHives comparison chart
if (-not $SkipOsNative) {
    Write-Host "Generating OS Native vs CryptoHives chart..." -ForegroundColor Yellow
    $chartScript = Join-Path $scriptsDir "generate-osnative-comparison-chart.R"
    $outputPng = Join-Path $ResultsDir "osnative-comparison-$Size.png"
    
    if (-not (Test-Path $chartScript)) {
        Write-Warning "Script not found: $chartScript"
    } else {
        Write-Host "  Output: osnative-comparison-$Size.png" -ForegroundColor Gray -NoNewline
        
        try {
            $output = & Rscript $chartScript $ResultsDir $outputPng $Size 2>&1
            if ($LASTEXITCODE -eq 0 -and (Test-Path $outputPng)) {
                Write-Host " ✓" -ForegroundColor Green
                $successCount++
            } else {
                Write-Host " ✗" -ForegroundColor Red
                $failCount++
            }
        } catch {
            Write-Host " ✗" -ForegroundColor Red
            $failCount++
        }
        Write-Host ""
    }
}

# Summary
Write-Host "Summary" -ForegroundColor Cyan
Write-Host "-------"
Write-Host "  Successful: $successCount" -ForegroundColor Green
if ($failCount -gt 0) {
    Write-Host "  Failed: $failCount" -ForegroundColor Red
}
Write-Host ""
Write-Host "Charts saved to: $ResultsDir"
