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

function Normalize-BenchmarkContent {
    param([string]$Content)

    if ([string]::IsNullOrWhiteSpace($Content)) {
        return $Content
    }

    $normalized = $Content -replace "\*\*", ""
    return $normalized.Trim()
}
    "Cryptography" = [ordered]@{
        SourceDir = "tests/Security/Cryptography/BenchmarkDotNet.Artifacts/results"
        DestDir   = "docfx/packages/security/cryptography/benchmarks"
        Files     = @(
            # Aggregate benchmark (all algorithms in one table)
            @{ Source = "Cryptography.Tests.Benchmarks.AllHashersAllSizesBenchmark-report-github.md"; Target = "allhashers-all-sizes.md" }

            # SHA-2 individual algorithms
            @{ Source = "Cryptography.Tests.Benchmarks.SHA224Benchmark-report-github.md"; Target = "sha224.md" }
            @{ Source = "Cryptography.Tests.Benchmarks.SHA256Benchmark-report-github.md"; Target = "sha256.md" }
            @{ Source = "Cryptography.Tests.Benchmarks.SHA384Benchmark-report-github.md"; Target = "sha384.md" }
            @{ Source = "Cryptography.Tests.Benchmarks.SHA512Benchmark-report-github.md"; Target = "sha512.md" }
            @{ Source = "Cryptography.Tests.Benchmarks.SHA512_224Benchmark-report-github.md"; Target = "sha512-224.md" }
            @{ Source = "Cryptography.Tests.Benchmarks.SHA512_256Benchmark-report-github.md"; Target = "sha512-256.md" }

            # SHA-3 individual algorithms
            @{ Source = "Cryptography.Tests.Benchmarks.SHA3_224Benchmark-report-github.md"; Target = "sha3-224.md" }
            @{ Source = "Cryptography.Tests.Benchmarks.SHA3_256Benchmark-report-github.md"; Target = "sha3-256.md" }
            @{ Source = "Cryptography.Tests.Benchmarks.SHA3_384Benchmark-report-github.md"; Target = "sha3-384.md" }
            @{ Source = "Cryptography.Tests.Benchmarks.SHA3_512Benchmark-report-github.md"; Target = "sha3-512.md" }

            # Keccak individual algorithms
            @{ Source = "Cryptography.Tests.Benchmarks.Keccak256Benchmark-report-github.md"; Target = "keccak256.md" }
            @{ Source = "Cryptography.Tests.Benchmarks.Keccak384Benchmark-report-github.md"; Target = "keccak384.md" }
            @{ Source = "Cryptography.Tests.Benchmarks.Keccak512Benchmark-report-github.md"; Target = "keccak512.md" }

            # SHAKE individual algorithms
            @{ Source = "Cryptography.Tests.Benchmarks.Shake128Benchmark-report-github.md"; Target = "shake128.md" }
            @{ Source = "Cryptography.Tests.Benchmarks.Shake256Benchmark-report-github.md"; Target = "shake256.md" }

            # cSHAKE individual algorithms
            @{ Source = "Cryptography.Tests.Benchmarks.CShake128Benchmark-report-github.md"; Target = "cshake128.md" }
            @{ Source = "Cryptography.Tests.Benchmarks.CShake256Benchmark-report-github.md"; Target = "cshake256.md" }

            # KT individual algorithms
            @{ Source = "Cryptography.Tests.Benchmarks.KT128Benchmark-report-github.md"; Target = "kt128.md" }
            @{ Source = "Cryptography.Tests.Benchmarks.KT256Benchmark-report-github.md"; Target = "kt256.md" }

            # TurboSHAKE individual algorithms
            @{ Source = "Cryptography.Tests.Benchmarks.TurboShake128Benchmark-report-github.md"; Target = "turboshake128.md" }
            @{ Source = "Cryptography.Tests.Benchmarks.TurboShake256Benchmark-report-github.md"; Target = "turboshake256.md" }

            # BLAKE2b individual algorithms
            @{ Source = "Cryptography.Tests.Benchmarks.Blake2b256Benchmark-report-github.md"; Target = "blake2b256.md" }
            @{ Source = "Cryptography.Tests.Benchmarks.Blake2b512Benchmark-report-github.md"; Target = "blake2b512.md" }

            # BLAKE2s individual algorithms
            @{ Source = "Cryptography.Tests.Benchmarks.Blake2s128Benchmark-report-github.md"; Target = "blake2s128.md" }
            @{ Source = "Cryptography.Tests.Benchmarks.Blake2s256Benchmark-report-github.md"; Target = "blake2s256.md" }

            # BLAKE3
            @{ Source = "Cryptography.Tests.Benchmarks.Blake3Benchmark-report-github.md"; Target = "blake3.md" }

            # Legacy individual algorithms
            @{ Source = "Cryptography.Tests.Benchmarks.MD5Benchmark-report-github.md"; Target = "md5.md" }
            @{ Source = "Cryptography.Tests.Benchmarks.SHA1Benchmark-report-github.md"; Target = "sha1.md" }

            # Regional individual algorithms
            @{ Source = "Cryptography.Tests.Benchmarks.SM3Benchmark-report-github.md"; Target = "sm3.md" }
            @{ Source = "Cryptography.Tests.Benchmarks.Streebog256Benchmark-report-github.md"; Target = "streebog256.md" }
            @{ Source = "Cryptography.Tests.Benchmarks.Streebog512Benchmark-report-github.md"; Target = "streebog512.md" }
            @{ Source = "Cryptography.Tests.Benchmarks.WhirlpoolBenchmark-report-github.md"; Target = "whirlpool.md" }
            @{ Source = "Cryptography.Tests.Benchmarks.Ripemd160Benchmark-report-github.md"; Target = "ripemd160.md" }

            # Ascon individual algorithms
            @{ Source = "Cryptography.Tests.Benchmarks.AsconHash256Benchmark-report-github.md"; Target = "asconhash256.md" }
            @{ Source = "Cryptography.Tests.Benchmarks.AsconXof128Benchmark-report-github.md"; Target = "asconxof128.md" }

            # KMAC
            @{ Source = "Cryptography.Tests.Benchmarks.KmacBenchmark-report-github.md"; Target = "kmac.md" }
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

        # Strip machine spec and remove BenchmarkDotNet emphasis markers
        $tableContent = Strip-MachineSpec -Content $content
        $tableContent = Normalize-BenchmarkContent -Content $tableContent
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
