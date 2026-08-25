# SPDX-FileCopyrightText: 2025 The Keepers of the CryptoHives
# SPDX-License-Identifier: MIT

# run-benchmarks.ps1
# Runs BenchmarkDotNet benchmarks for the Threading or Cryptography libraries
# Usage: .\scripts\run-benchmarks.ps1 -Project Threading [-Filter "*AsyncLock*"] [-Framework net10.0]
#        .\scripts\run-benchmarks.ps1 -Project Cryptography -Family SHA256
#        .\scripts\run-benchmarks.ps1 -Project Cryptography -Family BLAKE  (runs Blake2b256, Blake2b512, Blake2s128, Blake2s256, Blake3)
#        .\scripts\run-benchmarks.ps1 -Project Cryptography -Family RegionalCipher  (runs SM4, ARIA, Camellia, Kuznyechik, Kalyna, SEED)
#        .\scripts\run-benchmarks.ps1 -Project Cryptography -Family MAC  (runs HMAC (8 variants), AES-CMAC, AES-GMAC, Poly1305)

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
        "ParallelHash128", "ParallelHash256",
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
        # Regional cipher algorithms (individual)
        "Sm4Cbc", "AriaCbc128", "AriaCbc256",
        "CamelliaCbc128", "CamelliaCbc192", "CamelliaCbc256",
        "KuznyechikCbc", "KalynaCbc128", "KalynaCbc256",
        "SeedCbc",
        # MAC algorithms (individual)
        "HmacMd5", "HmacSha1", "HmacSha256", "HmacSha384", "HmacSha512",
        "HmacSha3_256", "HmacSha3_384", "HmacSha3_512",
        "AesCmac", "AesGmac", "Poly1305",
        # Post-quantum KEM (individual)
        "MLKem", "MLKemKeyGen", "MLKemOps", "MLKemInternals",
        # Group aliases (run multiple benchmarks)
        "SHA2", "SHA3", "Keccak", "KeccakCore", "SHAKE", "cSHAKE", "KT", "TurboSHAKE",
        "BLAKE2", "BLAKE2b", "BLAKE2s", "BLAKE",
        "Legacy", "RegionalHash", "Kupyna", "LSH", "Ascon", "ParallelHash", "KMAC",
        "XOF", "KeccakXOF", "BlakeXOF", "MacXOF", "AsconXOF",
        "AES-GCM", "AES-CCM", "AES-CBC", "ChaCha",
        "RegionalCipher", "SimdArm",
        "Cipher", "AEAD", "HMAC", "MAC",
        "KEM",
        "All"
    )]
    [string]$Family,

    [Parameter(HelpMessage = "Filter for benchmark names (e.g., '*AsyncLock*', '*SHA256*')")]
    [string[]]$Filter = @("*"),

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
    [string[]]$ExtraArgs,

    [Parameter(HelpMessage = "Optional timeout in minutes for the benchmark process (0 disables timeout)")]
    [ValidateRange(0, 1440)]
    [int]$TimeoutMinutes = 0,

    [Parameter(HelpMessage = "Shutdown dotnet build servers after run to avoid lingering MSBuild node-reuse processes")]
    [switch]$ShutdownBuildServers
)

$ErrorActionPreference = "Stop"

$filterArgs = @($Filter | ForEach-Object { [string]$_ } | Where-Object { -not [string]::IsNullOrWhiteSpace($_) })
if ($filterArgs.Count -eq 0) {
    $filterArgs = @("*")
}
$defaultFilterRequested = $filterArgs.Count -eq 1 -and $filterArgs[0] -eq "*"
$filterDisplay = $filterArgs -join " "

# If invoked with no parameters, print concise supported-parameters summary and exit
if (-not $Project -or $PSBoundParameters.Count -eq 0) {
    Write-Host ""
    Write-Host "Summary of supported parameters (name - choices - default):" -ForegroundColor Yellow
    Write-Host ""
    Write-Host "   - Project — Threading | Cryptography - select one"
    Write-Host "   - Family — many individual algorithms + group aliases (SHA2, SHA3, etc.) — none (null)  "
    Write-Host "   - Filter — one or more string globs applied to full benchmark name — \"*\"  "
    Write-Host "   - Framework — net10.0 | net8.0 | net48 — net10.0  "
    Write-Host "   - Runtimes — comma list (e.g. \"net10.0, net8.0\") — \"net10.0\"  "
    Write-Host "   - Configuration — Release | Debug — Release  "
    Write-Host "   - Verbosity — q | m | n | d | diag — n  "
    Write-Host "   - List — switch (show benchmarks) — off  "
    Write-Host "   - DryRun — switch (show command / minimal iterations) — off  "
    Write-Host "   - ExtraArgs — string[] forwarded to BenchmarkDotNet — none  "
    Write-Host "   - TimeoutMinutes — int (0..1440), process timeout in minutes — 0 (disabled)  "
    Write-Host "   - ShutdownBuildServers — switch (runs 'dotnet build-server shutdown' after completion) — off  "
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
    "SHA224"            = "SHA224"
    "SHA256"            = "SHA256"
    "SHA384"            = "SHA384"
    "SHA512"            = "SHA512"
    "SHA512_224"        = "SHA512_224"
    "SHA512_256"        = "SHA512_256"
    # SHA-3
    "SHA3_224"          = "SHA3_224"
    "SHA3_256"          = "SHA3_256"
    "SHA3_384"          = "SHA3_384"
    "SHA3_512"          = "SHA3_512"
    # Keccak
    "Keccak256"         = "Keccak256"
    "Keccak384"         = "Keccak384"
    "Keccak512"         = "Keccak512"
    # SHAKE
    "Shake128"          = "Shake128"
    "Shake256"          = "Shake256"
    # cSHAKE
    "CShake128"         = "CShake128"
    "CShake256"         = "CShake256"
    # KT
    "KT128"             = "KT128"
    "KT256"             = "KT256"
    # TurboSHAKE
    "TurboShake128"     = "TurboShake128"
    "TurboShake256"     = "TurboShake256"
    # BLAKE2b
    "Blake2b256"        = "Blake2b256"
    "Blake2b512"        = "Blake2b512"
    # BLAKE2s
    "Blake2s128"        = "Blake2s128"
    "Blake2s256"        = "Blake2s256"
    # BLAKE3
    "Blake3"            = "Blake3"
    # Legacy
    "MD5"               = "MD5"
    "SHA1"              = "SHA1"
    # Regional Hash
    "SM3"               = "SM3"
    "Streebog256"       = "Streebog256"
    "Streebog512"       = "Streebog512"
    "Whirlpool"         = "Whirlpool"
    "Ripemd160"         = "Ripemd160"
    # Kupyna (DSTU 7564)
    "Kupyna256"         = "Kupyna256"
    "Kupyna384"         = "Kupyna384"
    "Kupyna512"         = "Kupyna512"
    # LSH (KS X 3262)
    "Lsh256_256"        = "Lsh256_256"
    "Lsh512_256"        = "Lsh512_256"
    "Lsh512_512"        = "Lsh512_512"
    # Ascon
    "AsconHash256"      = "AsconHash256"
    "AsconXof128"       = "AsconXof128"
    # ParallelHash (NIST SP 800-185)
    "ParallelHash128"   = "ParallelHash128"
    "ParallelHash256"   = "ParallelHash256"
    # KMAC
    "KMac128"           = "KMac128"
    "KMac256"           = "KMac256"
    # XOF (Absorb/Squeeze)
    "Shake128Xof"       = "Shake128Xof"
    "Shake256Xof"       = "Shake256Xof"
    "CShake128Xof"      = "CShake128Xof"
    "CShake256Xof"      = "CShake256Xof"
    "TurboShake128Xof"  = "TurboShake128Xof"
    "TurboShake256Xof"  = "TurboShake256Xof"
    "KT128Xof"          = "KT128Xof"
    "KT256Xof"          = "KT256Xof"
    "KMac128Xof"        = "KMac128Xof"
    "KMac256Xof"        = "KMac256Xof"
    "Blake3Xof"         = "Blake3Xof"
    "AsconXof128Xof"    = "AsconXof128Xof"
    # Ciphers - AES-GCM
    "AesGcm128"         = "AesGcm128"
    "AesGcm192"         = "AesGcm192"
    "AesGcm256"         = "AesGcm256"
    # Ciphers - AES-CCM
    "AesCcm128"         = "AesCcm128"
    "AesCcm256"         = "AesCcm256"
    # Ciphers - AES-CBC
    "AesCbc128"         = "AesCbc128"
    "AesCbc256"         = "AesCbc256"
    # Ciphers - ChaCha
    "ChaCha20"          = "ChaCha20"
    "ChaCha20Poly1305"  = "ChaCha20Poly1305"
    "XChaCha20Poly1305" = "XChaCha20Poly1305"
    # Ciphers - Regional
    "Sm4Cbc"            = "Sm4Cbc"
    "AriaCbc128"        = "AriaCbc128"
    "AriaCbc256"        = "AriaCbc256"
    "CamelliaCbc128"    = "CamelliaCbc128"
    "CamelliaCbc192"    = "CamelliaCbc192"
    "CamelliaCbc256"    = "CamelliaCbc256"
    "KuznyechikCbc"     = "KuznyechikCbc"
    "KalynaCbc128"      = "KalynaCbc128"
    "KalynaCbc256"      = "KalynaCbc256"
    "SeedCbc"           = "SeedCbc"
    # MAC - HMAC
    "HmacMd5"           = "HmacMd5"
    "HmacSha1"          = "HmacSha1"
    "HmacSha256"        = "HmacSha256"
    "HmacSha384"        = "HmacSha384"
    "HmacSha512"        = "HmacSha512"
    "HmacSha3_256"      = "HmacSha3_256"
    "HmacSha3_384"      = "HmacSha3_384"
    "HmacSha3_512"      = "HmacSha3_512"
    # MAC - CMAC / GMAC / Poly1305
    "AesCmac"           = "AesCmac"
    "AesGmac"           = "AesGmac"
    "Poly1305"          = "Mac.Poly1305Benchmark"
    # Post-quantum KEM. Namespace-qualified so the three classes stay distinct: the filters
    # below match one class each and never overlap.
    "MLKemOps"          = "Kem.MLKemBenchmark"
    "MLKemKeyGen"       = "Kem.MLKemKeyGenBenchmark"
    "MLKemInternals"    = "Kem.MLKemInternalsBenchmark"
    # Group Aliases
    "All"               = "Hash"
}

# Group aliases expand to multiple individual benchmarks
$GroupAliases = @{
    "SHA2"           = @("SHA224", "SHA256", "SHA384", "SHA512", "SHA512_224", "SHA512_256")
    "SHA3"           = @("SHA3_224", "SHA3_256", "SHA3_384", "SHA3_512")
    "Keccak"         = @("Keccak256", "Keccak384", "Keccak512")
    "SHAKE"          = @("Shake128", "Shake256")
    "cSHAKE"         = @("CShake128", "CShake256")
    "KT"             = @("KT128", "KT256")
    "TurboSHAKE"     = @("TurboShake128", "TurboShake256")
    "KeccakCore"     = @("SHA3_224", "SHA3_256", "SHA3_384", "SHA3_512", "Keccak256", "Keccak384", "Keccak512", "Shake128", "Shake256", "CShake128", "CShake256", "KT128", "KT256", "TurboShake128", "TurboShake256")
    "BLAKE2"         = @("Blake2b256", "Blake2b512", "Blake2s256", "Blake2s128")
    "BLAKE2b"        = @("Blake2b256", "Blake2b512")
    "BLAKE2s"        = @("Blake2s256", "Blake2s128")
    "BLAKE"          = @("Blake3", "Blake2s256", "Blake2b256", "Blake2s128", "Blake2b512")
    "Legacy"         = @("MD5", "SHA1")
    "RegionalHash"   = @("SM3", "Streebog256", "Streebog512", "Whirlpool", "Ripemd160", "Kupyna256", "Kupyna384", "Kupyna512", "Lsh256_256", "Lsh512_256", "Lsh512_512")
    "Kupyna"         = @("Kupyna256", "Kupyna384", "Kupyna512")
    "LSH"            = @("Lsh256_256", "Lsh512_256", "Lsh512_512")
    "Ascon"          = @("AsconHash256", "AsconXof128")
    "ParallelHash"   = @("ParallelHash128", "ParallelHash256")
    "KMAC"           = @("KMac128", "KMac256")
    "XOF"            = @("Shake128Xof", "Shake256Xof", "CShake128Xof", "CShake256Xof", "TurboShake128Xof", "TurboShake256Xof", "KT128Xof", "KT256Xof", "KMac128Xof", "KMac256Xof", "Blake3Xof", "AsconXof128Xof")
    "KeccakXOF"      = @("Shake128Xof", "Shake256Xof", "CShake128Xof", "CShake256Xof", "TurboShake128Xof", "TurboShake256Xof", "KT128Xof", "KT256Xof")
    "BlakeXOF"       = @("Blake3Xof")
    "MacXOF"         = @("KMac128Xof", "KMac256Xof")
    "AsconXOF"       = @("AsconXof128Xof")
    "AES-GCM"        = @("AesGcm128", "AesGcm192", "AesGcm256")
    "AES-CCM"        = @("AesCcm128", "AesCcm256")
    "AES-CBC"        = @("AesCbc128", "AesCbc256")
    "ChaCha"         = @("ChaCha20", "ChaCha20Poly1305", "XChaCha20Poly1305")
    "RegionalCipher" = @("Sm4Cbc", "AriaCbc128", "AriaCbc256", "CamelliaCbc128", "CamelliaCbc192", "CamelliaCbc256", "KuznyechikCbc", "KalynaCbc128", "KalynaCbc256", "SeedCbc")
    "AEAD"           = @("AesGcm128", "AesGcm192", "AesGcm256", "AesCcm128", "AesCcm256", "ChaCha20Poly1305", "XChaCha20Poly1305")
    "Cipher"         = @("AesGcm128", "AesGcm192", "AesGcm256", "AesCcm128", "AesCcm256", "AesCbc128", "AesCbc256", "ChaCha20", "ChaCha20Poly1305", "XChaCha20Poly1305", "Sm4Cbc", "AriaCbc128", "AriaCbc256", "CamelliaCbc128", "CamelliaCbc192", "CamelliaCbc256", "KuznyechikCbc", "KalynaCbc128", "KalynaCbc256", "SeedCbc")
    "SimdArm"        = @("SHA256", "Blake2b256", "Blake2b512", "Blake2s128", "Blake2s256", "Blake3", "AesGcm128", "AesGcm192", "AesGcm256", "AesCcm128", "AesCcm256", "AesCbc128", "AesCbc256", "ChaCha20", "ChaCha20Poly1305", "XChaCha20Poly1305")
    "HMAC"           = @("HmacMd5", "HmacSha1", "HmacSha256", "HmacSha384", "HmacSha512", "HmacSha3_256", "HmacSha3_384", "HmacSha3_512")
    "MLKem"          = @("MLKemKeyGen", "MLKemOps")
    "KEM"            = @("MLKemKeyGen", "MLKemOps", "MLKemInternals")
}

$GroupAliases["MAC"] = $GroupAliases["HMAC"] + @("AesCmac", "AesGmac", "Poly1305")

# 'All' should run all hash, cipher, and MAC benchmarks (convenience alias)
$GroupAliases["All"] = $GroupAliases["SHA2"] + $GroupAliases["SHA3"] + $GroupAliases["Keccak"] + $GroupAliases["SHAKE"] + $GroupAliases["cSHAKE"] + $GroupAliases["KT"] + $GroupAliases["TurboSHAKE"] + $GroupAliases["BLAKE2"] + $GroupAliases["BLAKE2b"] + $GroupAliases["BLAKE2s"] + $GroupAliases["BLAKE"] + $GroupAliases["Legacy"] + $GroupAliases["RegionalHash"] + $GroupAliases["Kupyna"] + $GroupAliases["LSH"] + $GroupAliases["Ascon"] + $GroupAliases["ParallelHash"] + $GroupAliases["KMAC"] + $GroupAliases["XOF"] + $GroupAliases["KeccakXOF"] + $GroupAliases["BlakeXOF"] + $GroupAliases["MacXOF"] + $GroupAliases["AsconXOF"] + $GroupAliases["Cipher"] + $GroupAliases["MAC"] + $GroupAliases["KEM"]

# 'Hash' alias groups the common hash families (excluding XOF-specific families)
$GroupAliases["Hash"] = $GroupAliases["SHA2"] + $GroupAliases["SHA3"] + $GroupAliases["Keccak"] + $GroupAliases["SHAKE"] + $GroupAliases["cSHAKE"] + $GroupAliases["KT"] + $GroupAliases["TurboSHAKE"] + $GroupAliases["BLAKE2"] + $GroupAliases["BLAKE2b"] + $GroupAliases["BLAKE2s"] + $GroupAliases["BLAKE"] + $GroupAliases["Legacy"] + $GroupAliases["RegionalHash"] + $GroupAliases["Kupyna"] + $GroupAliases["LSH"] + $GroupAliases["Ascon"] + $GroupAliases["ParallelHash"] + $GroupAliases["KMAC"]

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
if ($Project -eq "Cryptography" -and -not $Family -and $defaultFilterRequested) {
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
    }
    else {
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
Write-Host "  Filter:        $filterDisplay"
Write-Host "  Framework:     $Framework"
Write-Host "  Runtimes:      $Runtimes"
Write-Host "  Configuration: $Configuration"
try {
    $resolvedTestProject = (Resolve-Path -LiteralPath $testProject -ErrorAction Stop).Path
}
catch {
    $resolvedTestProject = $testProject
}
Write-Host "  Path:          $resolvedTestProject"
Write-Host ""

if ($Project -eq "Cryptography" -and $Help) {
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
    Write-Host "  ParallelHash:  -Family ParallelHash128, ParallelHash256"
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
    Write-Host "  Regional:      -Family Sm4Cbc, AriaCbc128, AriaCbc256, CamelliaCbc128, CamelliaCbc192, CamelliaCbc256"
    Write-Host "                          KuznyechikCbc, KalynaCbc128, KalynaCbc256, SeedCbc"
    Write-Host ""
    Write-Host "Available MAC algorithm families:" -ForegroundColor Yellow
    Write-Host ""
    Write-Host "  HMAC:          -Family HmacMd5, HmacSha1, HmacSha256, HmacSha384, HmacSha512"
    Write-Host "                          HmacSha3_256, HmacSha3_384, HmacSha3_512"
    Write-Host "  CMAC/GMAC:     -Family AesCmac, AesGmac"
    Write-Host "  Poly1305:      -Family Poly1305"
    Write-Host ""
    Write-Host "Available post-quantum KEM families:" -ForegroundColor Yellow
    Write-Host ""
    Write-Host "  ML-KEM:        -Family MLKem            (key generation plus encapsulation/decapsulation)"
    Write-Host "  ML-KEM keygen: -Family MLKemKeyGen      (adds the no-pairwise-consistency-test variant)"
    Write-Host "  ML-KEM ops:    -Family MLKemOps         (encapsulate, decapsulate, implicit rejection)"
    Write-Host "  ML-KEM core:   -Family MLKemInternals   (CryptoHives-only diagnostics: pairwise"
    Write-Host "                                           consistency test cost, SampleNtt, packers)"
    Write-Host ""
    Write-Host "Group aliases (run multiple benchmarks, each with its own output):" -ForegroundColor Yellow
    Write-Host "  -Family SHA2       runs: SHA224, SHA256, SHA384, SHA512, SHA512_224, SHA512_256"
    Write-Host "  -Family SHA3       runs: SHA3_224, SHA3_256, SHA3_384, SHA3_512"
    Write-Host "  -Family Keccak     runs: Keccak256, Keccak384, Keccak512"
    Write-Host "  -Family KeccakCore runs: Keccak, SHA3, SHAKE, cSHAKE, TurboSHAKE, KT (all Keccak-core algorithms)"
    Write-Host "  -Family SHAKE      runs: Shake128, Shake256"
    Write-Host "  -Family cSHAKE     runs: CShake128, CShake256"
    Write-Host "  -Family KT         runs: KT128, KT256"
    Write-Host "  -Family TurboSHAKE runs: TurboShake128, TurboShake256"
    Write-Host "  -Family BLAKE2b    runs: Blake2b256, Blake2b512"
    Write-Host "  -Family BLAKE2s    runs: Blake2s128, Blake2s256"
    Write-Host "  -Family BLAKE      runs: Blake2b256, Blake2b512, Blake2s128, Blake2s256, Blake3"
    Write-Host "  -Family Legacy     runs: MD5, SHA1"
    Write-Host "  -Family RegionalHash   : SM3, Streebog256, Streebog512, Whirlpool, Ripemd160, Kupyna256, Kupyna384, Kupyna512, Lsh256_256, Lsh512_256, Lsh512_512"
    Write-Host "  -Family Kupyna     runs: Kupyna256, Kupyna384, Kupyna512"
    Write-Host "  -Family LSH        runs: Lsh256_256, Lsh512_256, Lsh512_512"
    Write-Host "  -Family Ascon      runs: AsconHash256, AsconXof128"
    Write-Host "  -Family ParallelHash   : ParallelHash128, ParallelHash256"
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
    Write-Host "  -Family RegionalCipher : All regional ciphers (SM4, ARIA, Camellia-128/192/256, Kuznyechik, Kalyna, SEED)"
    Write-Host "  -Family Cipher     runs: All cipher benchmarks (including regional)"
    Write-Host "  -Family HMAC       runs: HmacMd5, HmacSha1, HmacSha256, HmacSha384, HmacSha512, HmacSha3_256, HmacSha3_384, HmacSha3_512"
    Write-Host "  -Family MAC        runs: All HMAC variants + AesCmac, AesGmac, Poly1305"
    Write-Host "  -Family MLKem      runs: MLKemKeyGen, MLKemOps"
    Write-Host "  -Family KEM        runs: MLKemKeyGen, MLKemOps, MLKemInternals"
    Write-Host "  -Family All        runs: All Hash, Cipher, MAC, and KEM benchmarks"
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
}
else {
    # Add filter patterns - multiple patterns are space-separated after --filter
    $dotnetArgs += "--filter"
    if ($filterPatterns.Count -gt 0) {
        foreach ($pattern in $filterPatterns) {
            # Cast to string to avoid PowerShell wildcard expansion when splatting arguments
            $dotnetArgs += [string]$pattern
        }
    }
    else {
        foreach ($pattern in $filterArgs) {
            $dotnetArgs += [string]$pattern
        }
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

# Show command. Quote any argument a shell would otherwise treat specially (wildcards,
# whitespace, etc.) so this line is safe to copy-paste and re-run directly - the actual
# invocation below uses Start-Process -ArgumentList and never goes through a shell, so it
# doesn't need this, but a printed "*Aes*" left unquoted will glob-expand (or error with
# "no matches found" under zsh's nomatch) if pasted as-is.
$cmdDisplay = "dotnet " + (($dotnetArgs | ForEach-Object {
    if ($_ -match '[\s\*\?\$`"''|<>&;()\[\]{}]') { '"' + ($_ -replace '"', '\"') + '"' } else { $_ }
}) -join " ")
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
    $runStart = Get-Date
    $proc = Start-Process -FilePath $dotnetPath -ArgumentList $dotnetArgs -NoNewWindow -PassThru

    if ($TimeoutMinutes -gt 0) {
        $timeout = [TimeSpan]::FromMinutes($TimeoutMinutes)
        if (-not $proc.WaitForExit([int]$timeout.TotalMilliseconds)) {
            Write-Host ""
            Write-Host "ERROR: Benchmark process exceeded timeout of $TimeoutMinutes minute(s). Stopping process..." -ForegroundColor Red
            Stop-Process -Id $proc.Id -Force -ErrorAction SilentlyContinue
            exit 124
        }

        # Ensure process has fully exited after timeout-based wait.
        $proc.WaitForExit()
    }
    else {
        $proc.WaitForExit()
    }

    $elapsed = (Get-Date) - $runStart
    Write-Host "Benchmark host process exited (code: $($proc.ExitCode), elapsed: $([math]::Round($elapsed.TotalSeconds, 2))s)." -ForegroundColor DarkGray

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
    
    # Recording is a separate, deliberate step: not every local run is worth keeping as history.
    Write-Host "To record this run into the archive on the benchmarks branch:"
    Write-Host "  git worktree add ../foundation-bench benchmarks"
    Write-Host "  .\scripts\update-benchmark-docs.ps1 -Project $Project -DestDir ../foundation-bench/$($Project.ToLowerInvariant())"
    Write-Host ""
    Write-Host "Then commit in that worktree. To rebuild the dashboard database locally:"
    Write-Host "  .\scripts\build-trends-database.ps1"
    Write-Host ""
}
finally {
    Pop-Location

    if ($ShutdownBuildServers) {
        Write-Host ""
        Write-Host "Shutting down dotnet build servers..." -ForegroundColor DarkGray
        & dotnet build-server shutdown | Out-Host
    }
}

