# SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
# SPDX-License-Identifier: MIT

# update-benchmark-docs.ps1
# Copies BenchmarkDotNet results to docfx benchmark documentation folder
# Usage: .\scripts\update-benchmark-docs.ps1 [-Project Threading] [-SourceDir <path>] [-DestDir <path>] [-DryRun]

[CmdletBinding()]
param(
    [Parameter(HelpMessage = "Project to update (Threading or Cryptography)")]
    [ValidateSet("Threading", "Cryptography")]
    [string]$Project = "Threading",

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
            @{ Source = "AsyncLockSingleBenchmark-report.md"; Target = "asynclock-single.md" }
            @{ Source = "AsyncLockMultipleBenchmark-report.md"; Target = "asynclock-multiple.md" }
            @{ Source = "AsyncAutoResetEventSetBenchmark-report.md"; Target = "asyncautoresetevent-set.md" }
            @{ Source = "AsyncAutoResetEventSetThenWaitBenchmark-report.md"; Target = "asyncautoresetevent-setthenw.md" }
            @{ Source = "AsyncAutoResetEventWaitThenSetBenchmark-report.md"; Target = "asyncautoresetevent-waitthenset.md" }
            @{ Source = "AsyncManualResetEventSetResetBenchmark-report.md"; Target = "asyncmanualresetevent-setreset.md" }
            @{ Source = "AsyncManualResetEventSetThenWaitBenchmark-report.md"; Target = "asyncmanualresetevent-setthenw.md" }
            @{ Source = "AsyncManualResetEventWaitThenSetBenchmark-report.md"; Target = "asyncmanualresetevent-waitthenset.md" }
            @{ Source = "AsyncSemaphoreSingleBenchmark-report.md"; Target = "asyncsemaphore-single.md" }
            @{ Source = "AsyncCountdownEventSignalBenchmark-report.md"; Target = "asynccountdownevent-signal.md" }
            @{ Source = "AsyncBarrierSignalAndWaitBenchmark-report.md"; Target = "asyncbarrier-signalandwait.md" }
            @{ Source = "AsyncReaderWriterLockReaderBenchmark-report.md"; Target = "asyncreaderwriterlock-reader.md" }
            @{ Source = "AsyncReaderWriterLockWriterBenchmark-report.md"; Target = "asyncreaderwriterlock-writer.md" }
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

            # Kupyna (DSTU 7564) individual algorithms
            @{ Source = "Kupyna256Benchmark-report.md"; Target = "kupyna256.md" }
            @{ Source = "Kupyna384Benchmark-report.md"; Target = "kupyna384.md" }
            @{ Source = "Kupyna512Benchmark-report.md"; Target = "kupyna512.md" }

            # Ascon individual algorithms
            @{ Source = "AsconHash256Benchmark-report.md"; Target = "asconhash256.md" }
            @{ Source = "AsconXof128Benchmark-report.md"; Target = "asconxof128.md" }

            # KMAC
            @{ Source = "KMac128Benchmark-report.md"; Target = "kmac128.md" }
            @{ Source = "KMac256Benchmark-report.md"; Target = "kmac256.md" }

            # XOF (Absorb/Squeeze)
            @{ Source = "Shake128XofBenchmark-report.md"; Target = "xof-shake128.md" }
            @{ Source = "Shake256XofBenchmark-report.md"; Target = "xof-shake256.md" }
            @{ Source = "CShake128XofBenchmark-report.md"; Target = "xof-cshake128.md" }
            @{ Source = "CShake256XofBenchmark-report.md"; Target = "xof-cshake256.md" }
            @{ Source = "TurboShake128XofBenchmark-report.md"; Target = "xof-turboshake128.md" }
            @{ Source = "TurboShake256XofBenchmark-report.md"; Target = "xof-turboshake256.md" }
            @{ Source = "KT128XofBenchmark-report.md"; Target = "xof-kt128.md" }
            @{ Source = "KT256XofBenchmark-report.md"; Target = "xof-kt256.md" }
            @{ Source = "KMac128XofBenchmark-report.md"; Target = "xof-kmac128.md" }
            @{ Source = "KMac256XofBenchmark-report.md"; Target = "xof-kmac256.md" }
            @{ Source = "Blake3XofBenchmark-report.md"; Target = "xof-blake3.md" }
            @{ Source = "AsconXof128XofBenchmark-report.md"; Target = "xof-asconxof128.md" }
        )
    }
}

if (-not $packageConfigurations.ContainsKey($Project)) {
    Write-Host "ERROR: Unknown project '$Project'." -ForegroundColor Red
    exit 1
}

$selectedConfig = $packageConfigurations[$Project]

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
Write-Host "Project: $Project"
Write-Host "Source: $SourceDir"
Write-Host "Destination: $DestDir"
Write-Host ""

if (-not (Test-Path $SourceDir)) {
    Write-Host "ERROR: Source directory does not exist." -ForegroundColor Red
    $testProjectDir = Split-Path (Split-Path $SourceDir)
    Write-Host "Please run benchmarks first:"
    Write-Host "  cd $testProjectDir"
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
