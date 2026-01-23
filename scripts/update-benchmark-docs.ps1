# SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
# SPDX-License-Identifier: MIT

# update-benchmark-docs.ps1
# Copies BenchmarkDotNet results to docfx benchmark documentation folder
# Usage: .\scripts\update-benchmark-docs.ps1 [-SourceDir <path>] [-DestDir <path>] [-DryRun]

[CmdletBinding()]
param(
    [Parameter(HelpMessage = "Benchmark package to update (Threading or Cryptography)")]
    [ValidateSet("Threading", "Cryptography")]
    [string]$Package = "Threading",

    [Parameter(HelpMessage = "Source directory containing BenchmarkDotNet results")]
    [string]$SourceDir,

    [Parameter(HelpMessage = "Destination directory for docfx benchmark documentation")]
    [string]$DestDir,

    [Parameter(HelpMessage = "Dry run - show actions without executing")]
    [switch]$DryRun
)

$ErrorActionPreference = "Stop"

$packageConfigurations = @{
    "Threading" = [ordered]@{
        SourceDir = "tests/Threading/BenchmarkDotNet.Artifacts/results"
        DestDir   = "docfx/packages/threading/benchmarks"
        Files     = @(
            @{ Source = "Threading.Tests.Async.Pooled.AsyncLockSingleBenchmark-report-github.md"; Target = "asynclock-single.md" }
            @{ Source = "Threading.Tests.Async.Pooled.AsyncLockMultipleBenchmark-report-github.md"; Target = "asynclock-multiple.md" }
            @{ Source = "Threading.Tests.Async.Pooled.AsyncAutoResetEventSetBenchmark-report-github.md"; Target = "asyncautoresetevent-set.md" }
            @{ Source = "Threading.Tests.Async.Pooled.AsyncAutoResetEventSetThenWaitBenchmark-report-github.md"; Target = "asyncautoresetevent-setthenw.md" }
            @{ Source = "Threading.Tests.Async.Pooled.AsyncAutoResetEventWaitThenSetBenchmark-report-github.md"; Target = "asyncautoresetevent-waitthenset.md" }
            @{ Source = "Threading.Tests.Async.Pooled.AsyncManualResetEventSetResetBenchmark-report-github.md"; Target = "asyncmanualresetevent-setreset.md" }
            @{ Source = "Threading.Tests.Async.Pooled.AsyncManualResetEventSetThenWaitBenchmark-report-github.md"; Target = "asyncmanualresetevent-setthenw.md" }
            @{ Source = "Threading.Tests.Async.Pooled.AsyncManualResetEventWaitThenSetBenchmark-report-github.md"; Target = "asyncmanualresetevent-waitthenset.md" }
            @{ Source = "Threading.Tests.Async.Pooled.AsyncSemaphoreSingleBenchmark-report-github.md"; Target = "asyncsemaphore-single.md" }
            @{ Source = "Threading.Tests.Async.Pooled.AsyncCountdownEventSignalBenchmark-report-github.md"; Target = "asynccountdownevent-signal.md" }
            @{ Source = "Threading.Tests.Async.Pooled.AsyncBarrierSignalAndWaitBenchmark-report-github.md"; Target = "asyncbarrier-signalandwait.md" }
            @{ Source = "Threading.Tests.Async.Pooled.AsyncReaderWriterLockReaderBenchmark-report-github.md"; Target = "asyncreaderwriterlock-reader.md" }
            @{ Source = "Threading.Tests.Async.Pooled.AsyncReaderWriterLockWriterBenchmark-report-github.md"; Target = "asyncreaderwriterlock-writer.md" }
        )
    }
    "Cryptography" = [ordered]@{
        SourceDir = "tests/Security/Cryptography/BenchmarkDotNet.Artifacts/results"
        DestDir   = "docfx/packages/security/cryptography/benchmarks"
        Files     = @(
            @{ Source = "Cryptography.Tests.Benchmarks.AllHashersAllSizesBenchmark-report-github.md"; Target = "allhashers-all-sizes.md" }
        )
    }
}

if (-not $packageConfigurations.ContainsKey($Package)) {
    Write-Host "ERROR: Unknown package '$Package'." -ForegroundColor Red
    exit 1
}

$selectedConfig = $packageConfigurations[$Package]

if (-not $PSBoundParameters.ContainsKey('SourceDir') -or [string]::IsNullOrWhiteSpace($SourceDir)) {
    $SourceDir = $selectedConfig.SourceDir
}

if (-not $PSBoundParameters.ContainsKey('DestDir') -or [string]::IsNullOrWhiteSpace($DestDir)) {
    $DestDir = $selectedConfig.DestDir
}

$benchmarkMappings = $selectedConfig.Files

Write-Host ""
Write-Host "========================================"
Write-Host " Updating Benchmark Documentation"
Write-Host "========================================"
Write-Host ""
Write-Host "Package: $Package"
Write-Host "Source: $SourceDir"
Write-Host "Destination: $DestDir"
Write-Host ""

if (-not (Test-Path $SourceDir)) {
    Write-Host "ERROR: Source directory does not exist." -ForegroundColor Red
    Write-Host "Please run benchmarks first:"
    Write-Host "  cd tests/Threading"
    Write-Host "  dotnet run -c Release -- --filter `"*Benchmark*`"" 
    exit 1
}

if (-not (Test-Path $DestDir)) {
    Write-Host "Creating destination directory..."
    if ($DryRun) {
        Write-Host "  [DRY RUN] New-Item -ItemType Directory -Force -Path $DestDir" -ForegroundColor Yellow
    } else {
        New-Item -ItemType Directory -Force -Path $DestDir | Out-Null
    }
}

# Function to extract machine specification from benchmark content
function Extract-MachineSpec {
    param([string]$Content)

    $lines = $Content -split "`n"
    $specLines = @()
    $inSpec = $false

    foreach ($line in $lines) {
        $trimmed = $line.Trim()

        # Start capturing at "```" if followed by BenchmarkDotNet version
        if ($trimmed -eq '```' -and -not $inSpec) {
            $inSpec = $true
            continue
        }

        # Stop at empty line after Job= line or at table start
        if ($inSpec) {
            if ($trimmed -match '^\|' -or $trimmed -eq '```') {
                break
            }
            if ($trimmed -ne '') {
                $specLines += $trimmed
            }
        }
    }

    return $specLines -join "`n"
}

# Function to strip machine specification from benchmark content, keeping only the table
function Strip-MachineSpec {
    param([string]$Content)

    $lines = $Content -split "`n"
    $resultLines = @()
    $foundTable = $false

    foreach ($line in $lines) {
        $trimmed = $line.Trim()

        # Start including lines when we hit the table
        if ($trimmed -match '^\|') {
            $foundTable = $true
        }

        if ($foundTable) {
            # Stop at closing ``` if present
            if ($trimmed -eq '```') {
                break
            }
            $resultLines += $line
        }
    }

    return $resultLines -join "`n"
}

Write-Host "Copying benchmark results..."
Write-Host ""

$copied = 0
$missing = 0
$machineSpec = $null
$machineSpecExtracted = $false

foreach ($mapping in $benchmarkMappings) {
    $sourceFile = Join-Path $SourceDir $mapping.Source
    $targetName = $mapping.Target

    if (Test-Path $sourceFile) {
        $content = Get-Content -Path $sourceFile -Raw

        # Extract machine spec from first file only
        if (-not $machineSpecExtracted) {
            $machineSpec = Extract-MachineSpec -Content $content
            $machineSpecExtracted = $true
            Write-Host "  [INFO] Extracted machine specification from $($mapping.Source)" -ForegroundColor Cyan
        }

        # Strip machine spec and save only the table
        $tableContent = Strip-MachineSpec -Content $content
        $destFile = Join-Path $DestDir $targetName

        # Write the stripped content
        if ($DryRun) {
            Write-Host "  [DRY RUN] Set-Content -Path $destFile -Value $tableContent -NoNewline" -ForegroundColor Yellow
        } else {
            Set-Content -Path $destFile -Value $tableContent -NoNewline
            Write-Host "  [OK] $targetName" -ForegroundColor Green
        }
        $copied++
    } else {
        Write-Host "  [--] $targetName (not found: $($mapping.Source))" -ForegroundColor Yellow
        $missing++
    }
}

# Save machine specification to separate file
if ($machineSpec) {
    $machineSpecFile = Join-Path $DestDir "machine-spec.md"
    $machineSpecContent = @"
## Machine Specification

The benchmarks were run on the following machine:

``````
$machineSpec
``````

> **Note:** Results are machine-specific and may vary between systems. Run benchmarks locally for your specific hardware.
"@
    if ($DryRun) {
        Write-Host "  [DRY RUN] Set-Content -Path $machineSpecFile -Value $machineSpecContent" -ForegroundColor Yellow
    } else {
        Set-Content -Path $machineSpecFile -Value $machineSpecContent
        Write-Host ""
        Write-Host "  [OK] machine-spec.md (extracted machine specification)" -ForegroundColor Green
    }
}

Write-Host ""
Write-Host "========================================"
Write-Host " Benchmark documentation updated!"
Write-Host " Copied: $copied, Missing: $missing"
Write-Host "========================================"
Write-Host ""
Write-Host "Next steps:"
Write-Host "  1. Review the updated files in $DestDir"
Write-Host "  2. Build docfx to verify: docfx docfx/docfx.json"
Write-Host "  3. Commit the changes"
Write-Host ""
