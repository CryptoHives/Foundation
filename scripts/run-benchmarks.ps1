# SPDX-FileCopyrightText: 2025 The Keepers of the CryptoHives
# SPDX-License-Identifier: MIT

# run-benchmarks.ps1
# Runs BenchmarkDotNet benchmarks for the Threading or Cryptography libraries
# Usage: .\scripts\run-benchmarks.ps1 [-Project Threading] [-Filter "*AsyncLock*"] [-Framework net10.0]
#        .\scripts\run-benchmarks.ps1 -Project Cryptography -Family SHA256
#        .\scripts\run-benchmarks.ps1 -Project Cryptography -Family BLAKE  (runs Blake2b256, Blake2b512, Blake2s128, Blake2s256, Blake3)

[CmdletBinding()]
param(
    [Parameter(HelpMessage = "Project to benchmark (Threading or Cryptography)")]
    [ValidateSet("Threading", "Cryptography")]
    [string]$Project = "Threading",

    [Parameter(HelpMessage = "Algorithm family to benchmark (Cryptography only)")]
    [ValidateSet(
        # Individual algorithms (each creates its own output table)
        "SHA224", "SHA256", "SHA384", "SHA512", "SHA512_224", "SHA512_256",
        "SHA3_224", "SHA3_256", "SHA3_384", "SHA3_512",
        "Keccak256", "Keccak384", "Keccak512",
        "Shake128", "Shake256",
        "CShake128", "CShake256",
        "KT128", "KT256",
        "TurboShake128", "TurboShake256",
        "Blake2b256", "Blake2b512",
        "Blake2s128", "Blake2s256",
        "Blake3",
        "MD5", "SHA1",
        "SM3", "Streebog256", "Streebog512", "Whirlpool", "Ripemd160",
        "AsconHash256", "AsconXof128",
        "KMac128", "KMac256", "KMac128Incremental", "KMac128OutputSize", "KMac256Incremental", "KMac256OutputSize",
        # Group aliases (run multiple benchmarks)
        "SHA2", "SHA3", "Keccak", "SHAKE", "cSHAKE", "KT", "TurboSHAKE",
        "BLAKE2", "BLAKE2b", "BLAKE2s", "BLAKE",
        "Legacy", "Regional", "Ascon", "KMAC",
        "All"
    )]
    [string]$Family,

    [Parameter(HelpMessage = "Filter for benchmark names (e.g., '*AsyncLock*', '*SHA256*')")]
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

# Individual algorithm to benchmark category mapping
$AlgorithmBenchmarkMap = @{
    # SHA-2
    "SHA224"      = "SHA224"
    "SHA256"      = "SHA256"
    "SHA384"      = "SHA384"
    "SHA512"      = "SHA512"
    "SHA512_224"  = "SHA512_224"
    "SHA512_256"  = "SHA512_256"
    # SHA-3
    "SHA3_224"    = "SHA3_224"
    "SHA3_256"    = "SHA3_256"
    "SHA3_384"    = "SHA3_384"
    "SHA3_512"    = "SHA3_512"
    # Keccak
    "Keccak256"   = "Keccak256"
    "Keccak384"   = "Keccak384"
    "Keccak512"   = "Keccak512"
    # SHAKE
    "Shake128"    = "Shake128"
    "Shake256"    = "Shake256"
    # cSHAKE
    "CShake128"   = "CShake128"
    "CShake256"   = "CShake256"
    # KT
    "KT128"       = "KT128"
    "KT256"       = "KT256"
    # TurboSHAKE
    "TurboShake128" = "TurboShake128"
    "TurboShake256" = "TurboShake256"
    # BLAKE2b
    "Blake2b256"  = "Blake2b256"
    "Blake2b512"  = "Blake2b512"
    # BLAKE2s
    "Blake2s128"  = "Blake2s128"
    "Blake2s256"  = "Blake2s256"
    # BLAKE3
    "Blake3"      = "Blake3"
    # Legacy
    "MD5"         = "MD5"
    "SHA1"        = "SHA1"
    # Regional
    "SM3"         = "SM3"
    "Streebog256" = "Streebog256"
    "Streebog512" = "Streebog512"
    "Whirlpool"   = "Whirlpool"
    "Ripemd160"   = "Ripemd160"
    # Ascon
    "AsconHash256" = "AsconHash256"
    "AsconXof128" = "AsconXof128"
    # KMAC
    "Kmac128"     = "Kmac128"
    "Kmac256"     = "Kmac256"
    "Kmac128Incremental" = "Kmac128Incremental"
    "Kmac128OutputSize" = "Kmac128OutputSize"
    "Kmac256Incremental" = "Kmac256Incremental"
    "Kmac256OutputSize" = "Kmac256OutputSize"
    # Group Aliases
    "All"         = "Hash"
}

# Group aliases expand to multiple individual benchmarks
$GroupAliases = @{
    "SHA2"        = @("SHA224", "SHA256", "SHA384", "SHA512", "SHA512_224", "SHA512_256")
    "SHA3"        = @("SHA3_224", "SHA3_256", "SHA3_384", "SHA3_512")
    "Keccak"      = @("Keccak256", "Keccak384", "Keccak512")
    "SHAKE"       = @("Shake128", "Shake256")
    "cSHAKE"      = @("CShake128", "CShake256")
    "KT"          = @("KT128", "KT256")
    "TurboSHAKE"  = @("TurboShake128", "TurboShake256")
    "BLAKE2"      = @("Blake2b256", "Blake2b512", "Blake2s256", "Blake2s128")
    "BLAKE2b"     = @("Blake2b256", "Blake2b512")
    "BLAKE2s"     = @("Blake2s256", "Blake2s128")
    "BLAKE"       = @("Blake3", "Blake2s256", "Blake2b256", "Blake2s128", "Blake2b512")
    "Legacy"      = @("MD5", "SHA1")
    "Regional"    = @("SM3", "Streebog256", "Streebog512", "Whirlpool", "Ripemd160")
    "Ascon"       = @("AsconHash256", "AsconXof128")
    "KMAC"        = @("Kmac128", "Kmac256", "Kmac128Incremental", "Kmac128OutputSize", "Kmac256Incremental", "Kmac256OutputSize")
}

# Get repository root
$scriptPath = Split-Path -Parent $MyInvocation.MyCommand.Path
$repoRoot = Split-Path -Parent $scriptPath

# Determine test project path based on selection
switch ($Project) {
    "Threading" {
        $testProject = Join-Path $repoRoot "tests\Threading"
        $projectTitle = "Threading"
    }
    "Cryptography" {
        $testProject = Join-Path $repoRoot "tests\Security\Cryptography"
        $projectTitle = "Security.Cryptography"
    }
}

# Resolve family to benchmark classes and build filter patterns
$benchmarkClasses = @()
$filterPatterns = @()
if ($Project -eq "Cryptography" -and $Family) {
    if ($GroupAliases.ContainsKey($Family)) {
        foreach ($alg in $GroupAliases[$Family]) {
            $benchmarkClasses += $AlgorithmBenchmarkMap[$alg]
        }
    } elseif ($AlgorithmBenchmarkMap.ContainsKey($Family)) {
        $benchmarkClasses += $AlgorithmBenchmarkMap[$Family]
    }

    if ($benchmarkClasses.Count -gt 0) {
        # Build filter patterns (one per category)
        $filterPatterns = $benchmarkClasses | ForEach-Object { "*$_*" }
    }
}

Write-Host ""
Write-Host "========================================"
Write-Host " CryptoHives $projectTitle Benchmarks"
Write-Host "========================================"
Write-Host ""
Write-Host "Configuration:"
Write-Host "  Project:       $Project"
if ($Family) {
    Write-Host "  Family:        $Family"
    if ($benchmarkClasses.Count -gt 1) {
        Write-Host "  Benchmarks:    $($benchmarkClasses -join ', ')"
    }
}
Write-Host "  Filter:        $Filter"
Write-Host "  Framework:     $Framework"
Write-Host "  Runtimes:      $Runtimes"
Write-Host "  Configuration: $Configuration"
Write-Host "  Path:          $testProject"
Write-Host ""

if ($Project -eq "Cryptography" -and -not $Family -and $Filter -eq "*") {
    Write-Host "Available algorithm families (each creates its own output table):" -ForegroundColor Yellow
    Write-Host ""
    Write-Host "  SHA-2:         -Family SHA224, SHA256, SHA384, SHA512, SHA512_224, SHA512_256"
    Write-Host "  SHA-3:         -Family SHA3_224, SHA3_256, SHA3_384, SHA3_512"
    Write-Host "  Keccak:        -Family Keccak256, Keccak384, Keccak512"
    Write-Host "  SHAKE:         -Family Shake128, Shake256"
    Write-Host "  cSHAKE:        -Family CShake128, CShake256"
    Write-Host "  KT:            -Family KT128, KT256"
    Write-Host "  TurboSHAKE:    -Family TurboShake128, TurboShake256"
    Write-Host "  BLAKE2b:       -Family Blake2b256, Blake2b512"
    Write-Host "  BLAKE2s:       -Family Blake2s128, Blake2s256"
    Write-Host "  BLAKE3:        -Family Blake3"
    Write-Host "  Legacy:        -Family MD5, SHA1"
    Write-Host "  Regional:      -Family SM3, Streebog256, Streebog512, Whirlpool, Ripemd160"
    Write-Host "  Ascon:         -Family AsconHash256, AsconXof128"
    Write-Host "  KMAC:          -Family Kmac128, Kmac256, Kmac128Incremental, Kmac128OutputSize, Kmac256Incremental, Kmac256OutputSize"
    Write-Host ""
    Write-Host "Group aliases (run multiple benchmarks, each with its own output):" -ForegroundColor Yellow
    Write-Host "  -Family SHA2       runs: SHA224, SHA256, SHA384, SHA512, SHA512_224, SHA512_256"
    Write-Host "  -Family SHA3       runs: SHA3_224, SHA3_256, SHA3_384, SHA3_512"
    Write-Host "  -Family Keccak     runs: Keccak256, Keccak384, Keccak512"
    Write-Host "  -Family SHAKE      runs: Shake128, Shake256"
    Write-Host "  -Family cSHAKE     runs: CShake128, CShake256"
    Write-Host "  -Family KT         runs: KT128, KT256"
    Write-Host "  -Family TurboSHAKE runs: TurboShake128, TurboShake256"
    Write-Host "  -Family BLAKE2b    runs: Blake2b256, Blake2b512"
    Write-Host "  -Family BLAKE2s    runs: Blake2s128, Blake2s256"
    Write-Host "  -Family BLAKE      runs: Blake2b256, Blake2b512, Blake2s128, Blake2s256, Blake3"
    Write-Host "  -Family Legacy     runs: MD5, SHA1"
    Write-Host "  -Family Regional   runs: SM3, Streebog256, Streebog512, Whirlpool, Ripemd160"
    Write-Host "  -Family Ascon      runs: AsconHash256, AsconXof128"
    Write-Host "  -Family KMAC       runs: Kmac128, Kmac256, Kmac128Incremental, Kmac128OutputSize, Kmac256Incremental, Kmac256OutputSize"
    Write-Host "  -Family All        runs: All Hash benchmarks"
    Write-Host ""
}

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
    # Add filter patterns - multiple patterns are space-separated after --filter
    $dotnetArgs += "--filter"
    if ($filterPatterns.Count -gt 0) {
        foreach ($pattern in $filterPatterns) {
            $dotnetArgs += $pattern
        }
    } else {
        $dotnetArgs += $Filter
    }
    $dotnetArgs += "--runtimes"
    $dotnetArgs += $Runtimes
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
    if ($Project -eq "Cryptography") {
        Write-Host "To update documentation, run:"
        Write-Host "  .\scripts\update-benchmark-docs.ps1 -Package Cryptography"
        Write-Host ""
    }
}
finally {
    Pop-Location
}
