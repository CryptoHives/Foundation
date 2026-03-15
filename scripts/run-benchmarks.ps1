# SPDX-FileCopyrightText: 2025 The Keepers of the CryptoHives
# SPDX-License-Identifier: MIT

# run-benchmarks.ps1
# Runs BenchmarkDotNet benchmarks for the Threading or Cryptography libraries
# Usage: .\scripts\run-benchmarks.ps1 -Project Threading [-Filter "*AsyncLock*"] [-Framework net10.0]
#        .\scripts\run-benchmarks.ps1 -Project Cryptography -Family SHA256
#        .\scripts\run-benchmarks.ps1 -Project Cryptography -Family BLAKE  (runs Blake2b256, Blake2b512, Blake2s128, Blake2s256, Blake3)

[CmdletBinding()]
param(
    [Parameter(HelpMessage = "Project to benchmark (Threading or Cryptography)")]
    [ValidateSet("Threading", "Cryptography")]
    [string]$Project,
    
    [Parameter(HelpMessage = "Show help and available families for Cryptography (prints families and exits)")]
    [switch]$Help,

    [Parameter(HelpMessage = "Algorithm family to benchmark (Cryptography only)")]
    [ValidateSet(
        # Hash algorithms (individual)
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
        "Kupyna256", "Kupyna384", "Kupyna512",
        "Lsh256_256", "Lsh512_256", "Lsh512_512",
        "AsconHash256", "AsconXof128",
        "KMac128", "KMac256",
        # XOF (Absorb/Squeeze) benchmarks
        "Shake128Xof", "Shake256Xof",
        "CShake128Xof", "CShake256Xof",
        "TurboShake128Xof", "TurboShake256Xof",
        "KT128Xof", "KT256Xof",
        "KMac128Xof", "KMac256Xof",
        "Blake3Xof", "AsconXof128Xof",
        # Cipher algorithms (individual)
        "AesGcm128", "AesGcm192", "AesGcm256",
        "AesCcm128", "AesCcm256",
        "AesCbc128", "AesCbc256",
        "ChaCha20",
        "ChaCha20Poly1305", "XChaCha20Poly1305",
        # Group aliases (run multiple benchmarks)
        "SHA2", "SHA3", "Keccak", "SHAKE", "cSHAKE", "KT", "TurboSHAKE",
        "BLAKE2", "BLAKE2b", "BLAKE2s", "BLAKE",
        "Legacy", "Regional", "Kupyna", "LSH", "Ascon", "KMAC",
        "XOF", "KeccakXOF", "BlakeXOF", "MacXOF", "AsconXOF",
        "AES-GCM", "AES-CCM", "AES-CBC", "ChaCha",
        "Cipher", "AEAD",
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

# If invoked with no parameters, print concise supported-parameters summary and exit
if (-not $Project -or $PSBoundParameters.Count -eq 0) {
    Write-Host ""
    Write-Host "Summary of supported parameters (name — choices — default):" -ForegroundColor Yellow
    Write-Host ""
    Write-Host "   - Project — Threading | Cryptography — Threading  "
    Write-Host "   - Family — many individual algorithms + group aliases (SHA2, SHA3, Keccak, SHAKE, cSHAKE, KT, TurboSHAKE, BLAKE2, BLAKE, KMAC, XOF, AES-GCM, Cipher, All, etc.) — none (null)  "
    Write-Host "   - Filter — string globs applied to full benchmark name — \"*\"  "
    Write-Host "   - Framework — net10.0 | net8.0 | net48 — net10.0  "
    Write-Host "   - Runtimes — comma list (e.g. \"net10.0,net8.0\") — \"net10.0\"  "
    Write-Host "   - Configuration — Release | Debug — Release  "
    Write-Host "   - Verbosity — q | m | n | d | diag — n  "
    Write-Host "   - List — switch (show benchmarks) — off  "
    Write-Host "   - DryRun — switch (show command / minimal iterations) — off  "
    Write-Host "   - ExtraArgs — string[] forwarded to BenchmarkDotNet — none  "
    Write-Host ""
    exit 0
}

# When parameters are provided, require -Project to be present
if ($PSBoundParameters.Count -gt 0 -and -not $Project) {
    Write-Host "ERROR: -Project is required when any options are supplied. Use -Help or run without arguments to see supported parameters." -ForegroundColor Red
    exit 1
}


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
    # Kupyna (DSTU 7564)
    "Kupyna256"   = "Kupyna256"
    "Kupyna384"   = "Kupyna384"
    "Kupyna512"   = "Kupyna512"
    # LSH (KS X 3262)
    "Lsh256_256"  = "Lsh256_256"
    "Lsh512_256"  = "Lsh512_256"
    "Lsh512_512"  = "Lsh512_512"
    # Ascon
    "AsconHash256" = "AsconHash256"
    "AsconXof128" = "AsconXof128"
    # KMAC
    "KMac128"     = "KMac128"
    "KMac256"     = "KMac256"
    # XOF (Absorb/Squeeze)
    "Shake128Xof"      = "Shake128Xof"
    "Shake256Xof"      = "Shake256Xof"
    "CShake128Xof"     = "CShake128Xof"
    "CShake256Xof"     = "CShake256Xof"
    "TurboShake128Xof" = "TurboShake128Xof"
    "TurboShake256Xof" = "TurboShake256Xof"
    "KT128Xof"         = "KT128Xof"
    "KT256Xof"         = "KT256Xof"
    "KMac128Xof"       = "KMac128Xof"
    "KMac256Xof"       = "KMac256Xof"
    "Blake3Xof"        = "Blake3Xof"
    "AsconXof128Xof"   = "AsconXof128Xof"
    # Ciphers - AES-GCM
    "AesGcm128"   = "AesGcm128"
    "AesGcm192"   = "AesGcm192"
    "AesGcm256"   = "AesGcm256"
    # Ciphers - AES-CCM
    "AesCcm128"   = "AesCcm128"
    "AesCcm256"   = "AesCcm256"
    # Ciphers - AES-CBC
    "AesCbc128"   = "AesCbc128"
    "AesCbc256"   = "AesCbc256"
    # Ciphers - ChaCha
    "ChaCha20"    = "ChaCha20"
    "ChaCha20Poly1305" = "ChaCha20Poly1305"
    "XChaCha20Poly1305" = "XChaCha20Poly1305"
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
    "Regional"    = @("SM3", "Streebog256", "Streebog512", "Whirlpool", "Ripemd160", "Kupyna256", "Kupyna384", "Kupyna512", "Lsh256_256", "Lsh512_256", "Lsh512_512")
    "Kupyna"      = @("Kupyna256", "Kupyna384", "Kupyna512")
    "LSH"         = @("Lsh256_256", "Lsh512_256", "Lsh512_512")
    "Ascon"       = @("AsconHash256", "AsconXof128")
    "KMAC"        = @("KMac128", "KMac256")
    "XOF"         = @("Shake128Xof", "Shake256Xof", "CShake128Xof", "CShake256Xof", "TurboShake128Xof", "TurboShake256Xof", "KT128Xof", "KT256Xof", "KMac128Xof", "KMac256Xof", "Blake3Xof", "AsconXof128Xof")
    "KeccakXOF"   = @("Shake128Xof", "Shake256Xof", "CShake128Xof", "CShake256Xof", "TurboShake128Xof", "TurboShake256Xof", "KT128Xof", "KT256Xof")
    "BlakeXOF"    = @("Blake3Xof")
    "MacXOF"      = @("KMac128Xof", "KMac256Xof")
    "AsconXOF"    = @("AsconXof128Xof")
    "AES-GCM"     = @("AesGcm128", "AesGcm192", "AesGcm256")
    "AES-CCM"     = @("AesCcm128", "AesCcm256")
    "AES-CBC"     = @("AesCbc128", "AesCbc256")
    "ChaCha"      = @("ChaCha20", "ChaCha20Poly1305", "XChaCha20Poly1305")
    "AEAD"        = @("AesGcm128", "AesGcm192", "AesGcm256", "AesCcm128", "AesCcm256", "ChaCha20Poly1305", "XChaCha20Poly1305")
    "Cipher"      = @("AesGcm128", "AesGcm192", "AesGcm256", "AesCcm128", "AesCcm256", "AesCbc128", "AesCbc256", "ChaCha20", "ChaCha20Poly1305", "XChaCha20Poly1305")
}

# 'All' should run all hash-related benchmarks (convenience alias)
$GroupAliases["All"] = $GroupAliases["SHA2"] + $GroupAliases["SHA3"] + $GroupAliases["Keccak"] + $GroupAliases["SHAKE"] + $GroupAliases["cSHAKE"] + $GroupAliases["KT"] + $GroupAliases["TurboSHAKE"] + $GroupAliases["BLAKE2"] + $GroupAliases["BLAKE2b"] + $GroupAliases["BLAKE2s"] + $GroupAliases["BLAKE"] + $GroupAliases["Legacy"] + $GroupAliases["Regional"] + $GroupAliases["Kupyna"] + $GroupAliases["LSH"] + $GroupAliases["Ascon"] + $GroupAliases["KMAC"] + $GroupAliases["XOF"] + $GroupAliases["KeccakXOF"] + $GroupAliases["BlakeXOF"] + $GroupAliases["MacXOF"] + $GroupAliases["AsconXOF"]

# 'Hash' alias groups the common hash families (excluding XOF-specific families)
$GroupAliases["Hash"] = $GroupAliases["SHA2"] + $GroupAliases["SHA3"] + $GroupAliases["Keccak"] + $GroupAliases["SHAKE"] + $GroupAliases["cSHAKE"] + $GroupAliases["KT"] + $GroupAliases["TurboSHAKE"] + $GroupAliases["BLAKE2"] + $GroupAliases["BLAKE2b"] + $GroupAliases["BLAKE2s"] + $GroupAliases["BLAKE"] + $GroupAliases["Legacy"] + $GroupAliases["Regional"] + $GroupAliases["Kupyna"] + $GroupAliases["LSH"] + $GroupAliases["Ascon"] + $GroupAliases["KMAC"]

# Get repository root
$scriptPath = Split-Path -Parent $MyInvocation.MyCommand.Path
$repoRoot = Split-Path -Parent $scriptPath

# Determine test project path based on selection
switch ($Project) {
    "Threading" {
        # Use cross-platform path joining
        $testProject = Join-Path $repoRoot 'tests' 'Threading'
        $projectTitle = 'Threading'
    }
    "Cryptography" {
        $testProject = Join-Path $repoRoot 'tests' 'Security' 'Cryptography'
        $projectTitle = 'Security.Cryptography'
    }
}

# If no Family specified for Cryptography and no explicit filter, default
# to running all cryptography hash benchmarks for convenience.
if ($Project -eq "Cryptography" -and -not $Family -and $Filter -eq "*") {
    Write-Host "No family specified; running all Cryptography benchmarks by default." -ForegroundColor Yellow
    $Family = "All"
}

# Resolve family to benchmark classes and build filter patterns (case-insensitive)
$benchmarkClasses = @()
$filterPatterns = @()
if ($Project -eq "Cryptography" -and $Family) {
    $familyKey = $null
    $lowerFamily = $Family.ToLower()
    $familyKey = $GroupAliases.Keys | Where-Object { $_.ToLower() -eq $lowerFamily } | Select-Object -First 1
    if ($familyKey) {
        foreach ($alg in $GroupAliases[$familyKey]) {
            if ($AlgorithmBenchmarkMap.ContainsKey($alg)) {
                $benchmarkClasses += $AlgorithmBenchmarkMap[$alg]
            }
        }
    } else {
        $algKey = $AlgorithmBenchmarkMap.Keys | Where-Object { $_.ToLower() -eq $lowerFamily } | Select-Object -First 1
        if ($algKey) {
            $benchmarkClasses += $AlgorithmBenchmarkMap[$algKey]
        }
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
try {
    $resolvedTestProject = (Resolve-Path -LiteralPath $testProject -ErrorAction Stop).Path
} catch {
    $resolvedTestProject = $testProject
}
Write-Host "  Path:          $resolvedTestProject"
Write-Host ""

if ($Project -eq "Cryptography" -and (-not $Family -or $Help)) {
    Write-Host "Available hash algorithm families (each creates its own output table):" -ForegroundColor Yellow
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
    Write-Host "  Regional:      -Family SM3, Streebog256, Streebog512, Whirlpool, Ripemd160, Kupyna256, Kupyna384, Kupyna512, Lsh256_256, Lsh512_256, Lsh512_512"
    Write-Host "  LSH:           -Family Lsh256_256, Lsh512_256, Lsh512_512"
    Write-Host "  Kupyna:        -Family Kupyna256, Kupyna384, Kupyna512"
    Write-Host "  Ascon:         -Family AsconHash256, AsconXof128"
    Write-Host "  KMAC:          -Family KMac128, KMac256"
    Write-Host "  XOF:           -Family Shake128Xof, Shake256Xof, CShake128Xof, CShake256Xof, TurboShake128Xof, TurboShake256Xof"
    Write-Host "                          KT128Xof, KT256Xof, KMac128Xof, KMac256Xof, Blake3Xof, AsconXof128Xof"
    Write-Host ""
    Write-Host "Available cipher algorithm families:" -ForegroundColor Yellow
    Write-Host ""
    Write-Host "  AES-GCM:       -Family AesGcm128, AesGcm192, AesGcm256"
    Write-Host "  AES-CCM:       -Family AesCcm128, AesCcm256"
    Write-Host "  AES-CBC:       -Family AesCbc128, AesCbc256"
    Write-Host "  ChaCha:        -Family ChaCha20, ChaCha20Poly1305, XChaCha20Poly1305"
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
    Write-Host "  -Family Regional   runs: SM3, Streebog256, Streebog512, Whirlpool, Ripemd160, Kupyna256, Kupyna384, Kupyna512, Lsh256_256, Lsh512_256, Lsh512_512"
    Write-Host "  -Family Kupyna     runs: Kupyna256, Kupyna384, Kupyna512"
    Write-Host "  -Family LSH        runs: Lsh256_256, Lsh512_256, Lsh512_512"
    Write-Host "  -Family Ascon      runs: AsconHash256, AsconXof128"
    Write-Host "  -Family KMAC       runs: KMac128, KMac256"
    Write-Host "  -Family XOF        runs: All XOF Absorb/Squeeze benchmarks (12 algorithms)"
    Write-Host "  -Family KeccakXOF  runs: Shake128Xof, Shake256Xof, CShake128Xof, CShake256Xof, TurboShake128Xof, TurboShake256Xof, KT128Xof, KT256Xof"
    Write-Host "  -Family BlakeXOF   runs: Blake3Xof"
    Write-Host "  -Family MacXOF     runs: KMac128Xof, KMac256Xof"
    Write-Host "  -Family AsconXOF   runs: AsconXof128Xof"
    Write-Host "  -Family AES-GCM    runs: AesGcm128, AesGcm192, AesGcm256"
    Write-Host "  -Family AES-CCM    runs: AesCcm128, AesCcm256"
    Write-Host "  -Family AES-CBC    runs: AesCbc128, AesCbc256"
    Write-Host "  -Family ChaCha     runs: ChaCha20, ChaCha20Poly1305, XChaCha20Poly1305"
    Write-Host "  -Family AEAD       runs: All AEAD ciphers (AES-GCM, AES-CCM, ChaCha20-Poly1305, XChaCha20-Poly1305)"
    Write-Host "  -Family Cipher     runs: All cipher benchmarks"
    Write-Host "  -Family All        runs: All Hash benchmarks"
    Write-Host ""
    exit 0
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
            # Cast to string to avoid PowerShell wildcard expansion when splatting arguments
            $dotnetArgs += [string]$pattern
        }
    } else {
        $dotnetArgs += [string]$Filter
    }
    $dotnetArgs += "--runtimes"
    $dotnetArgs += [string]$Runtimes
}

# Add any extra arguments
if ($ExtraArgs) {
    foreach ($arg in $ExtraArgs) {
        $dotnetArgs += [string]$arg
    }
}

# Show command
$cmdDisplay = "dotnet " + ($dotnetArgs -join " ")
Write-Host "Command: $cmdDisplay" -ForegroundColor Cyan
Write-Host ""

if ($DryRun) {
    $dotnetArgs += "--job"
    $dotnetArgs += "Dry"
    Write-Host "[DRY RUN] Running all benchmarks with minimal iterations (Job.Dry)" -ForegroundColor Yellow
    Write-Host ""
}

# Change to test project directory and run
Push-Location $testProject
try {
    Write-Host "Starting benchmarks..." -ForegroundColor Green
    Write-Host "========================================"
    Write-Host ""

    # Use Start-Process with ArgumentList to avoid PowerShell wildcard expansion when passing arguments
    $dotnetPath = (Get-Command dotnet -ErrorAction Stop).Source
    $proc = Start-Process -FilePath $dotnetPath -ArgumentList $dotnetArgs -NoNewWindow -Wait -PassThru

    $exitCode = $proc.ExitCode
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
    $resultsPath = Join-Path $resolvedTestProject 'BenchmarkDotNet.Artifacts' 'results'
    Write-Host "  $resultsPath"
    Write-Host ""
    
    if ($Project -eq "Cryptography") {
        Write-Host "To generate benchmark charts, run:"
        Write-Host "  .\scripts\generate-benchmark-charts.ps1"
        Write-Host ""
        Write-Host "To update documentation, run:"
        Write-Host "  .\scripts\update-benchmark-docs.ps1 -Package Cryptography"
        Write-Host ""
    }
}
finally {
    Pop-Location
}
