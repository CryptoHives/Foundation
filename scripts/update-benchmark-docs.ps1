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
            # SHA-2 individual algorithms
            @{ Source = "SHA224Benchmark-report.md"; Target = "sha224.md" }
            @{ Source = "SHA256Benchmark-report.md"; Target = "sha256.md" }
            @{ Source = "SHA384Benchmark-report.md"; Target = "sha384.md" }
            @{ Source = "SHA512Benchmark-report.md"; Target = "sha512.md" }
            @{ Source = "SHA512_224Benchmark-report.md"; Target = "sha512-224.md" }
            @{ Source = "SHA512_256Benchmark-report.md"; Target = "sha512-256.md" }

            # SHA-3 individual algorithms
            @{ Source = "SHA3_224Benchmark-report.md"; Target = "sha3-224.md" }
            @{ Source = "SHA3_256Benchmark-report.md"; Target = "sha3-256.md" }
            @{ Source = "SHA3_384Benchmark-report.md"; Target = "sha3-384.md" }
            @{ Source = "SHA3_512Benchmark-report.md"; Target = "sha3-512.md" }

            # Keccak individual algorithms
            @{ Source = "Keccak256Benchmark-report.md"; Target = "keccak256.md" }
            @{ Source = "Keccak384Benchmark-report.md"; Target = "keccak384.md" }
            @{ Source = "Keccak512Benchmark-report.md"; Target = "keccak512.md" }

            # SHAKE individual algorithms
            @{ Source = "Shake128Benchmark-report.md"; Target = "shake128.md" }
            @{ Source = "Shake256Benchmark-report.md"; Target = "shake256.md" }

            # cSHAKE individual algorithms
            @{ Source = "CShake128Benchmark-report.md"; Target = "cshake128.md" }
            @{ Source = "CShake256Benchmark-report.md"; Target = "cshake256.md" }

            # KT individual algorithms
            @{ Source = "KT128Benchmark-report.md"; Target = "kt128.md" }
            @{ Source = "KT256Benchmark-report.md"; Target = "kt256.md" }

            # TurboSHAKE individual algorithms
            @{ Source = "TurboShake128Benchmark-report.md"; Target = "turboshake128.md" }
            @{ Source = "TurboShake256Benchmark-report.md"; Target = "turboshake256.md" }

            # BLAKE2b individual algorithms
            @{ Source = "Blake2b256Benchmark-report.md"; Target = "blake2b256.md" }
            @{ Source = "Blake2b512Benchmark-report.md"; Target = "blake2b512.md" }

            # BLAKE2s individual algorithms
            @{ Source = "Blake2s128Benchmark-report.md"; Target = "blake2s128.md" }
            @{ Source = "Blake2s256Benchmark-report.md"; Target = "blake2s256.md" }

            # BLAKE3
            @{ Source = "Blake3Benchmark-report.md"; Target = "blake3.md" }

            # Legacy individual algorithms
            @{ Source = "MD5Benchmark-report.md"; Target = "md5.md" }
            @{ Source = "SHA1Benchmark-report.md"; Target = "sha1.md" }

            # Regional individual algorithms
            @{ Source = "SM3Benchmark-report.md"; Target = "sm3.md" }
            @{ Source = "Streebog256Benchmark-report.md"; Target = "streebog256.md" }
            @{ Source = "Streebog512Benchmark-report.md"; Target = "streebog512.md" }
            @{ Source = "WhirlpoolBenchmark-report.md"; Target = "whirlpool.md" }
            @{ Source = "Ripemd160Benchmark-report.md"; Target = "ripemd160.md" }

            # Ascon individual algorithms
            @{ Source = "AsconHash256Benchmark-report.md"; Target = "asconhash256.md" }
            @{ Source = "AsconXof128Benchmark-report.md"; Target = "asconxof128.md" }

            # KMAC
            @{ Source = "Kmac128Benchmark-report.md"; Target = "kmac128.md" }
            @{ Source = "Kmac256Benchmark-report.md"; Target = "kmac256.md" }
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

# Function to normalize benchmark content (remove emphasis markers)
function Normalize-BenchmarkContent {
    param([string]$Content)

    if ([string]::IsNullOrWhiteSpace($Content)) {
        return $Content
    }

    $normalized = $Content -replace "\*\*", ""
    return $normalized.Trim()
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
        # Read source file as UTF-8 (BenchmarkDotNet outputs UTF-8)
        $content = [System.IO.File]::ReadAllText($sourceFile, [System.Text.Encoding]::UTF8)

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

        # Write the stripped content as UTF-8 with BOM
        if ($DryRun) {
            Write-Host "  [DRY RUN] Set-Content -Path $destFile (UTF-8 with BOM)" -ForegroundColor Yellow
        } else {
            $Utf8Bom = New-Object System.Text.UTF8Encoding $true
            [System.IO.File]::WriteAllText($destFile, $tableContent, $Utf8Bom)
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
        Write-Host "  [DRY RUN] Set-Content -Path $machineSpecFile (UTF-8 with BOM)" -ForegroundColor Yellow
    } else {
        $Utf8Bom = New-Object System.Text.UTF8Encoding $true
        [System.IO.File]::WriteAllText($machineSpecFile, $machineSpecContent, $Utf8Bom)
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
