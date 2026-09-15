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
        "Sm4Cbc", "AriaCbc128", "AriaCbc192", "AriaCbc256",
        "CamelliaCbc128", "CamelliaCbc192", "CamelliaCbc256",
        "KuznyechikCbc", "KalynaCbc128", "KalynaCbc256", "KalynaCbc512",
        "SeedCbc",
        # AEAD and key wrapping (individual)
        "AsconAead128", "AesKeyWrap",
        # MAC algorithms (individual)
        "HmacMd5", "HmacSha1", "HmacSha256", "HmacSha384", "HmacSha512",
        "HmacSha3_256", "HmacSha3_384", "HmacSha3_512",
        "AesCmac", "AesGmac", "Poly1305",
        # Post-quantum KEM (individual)
        "MLKem", "MLKemKeyGen", "MLKemOps", "MLKemInternals",
        # Post-quantum signatures (individual)
        "MLDsa", "MLDsaKeyGen", "MLDsaOps",
        "SlhDsa", "SlhDsaKeyGen", "SlhDsaOps",
        # Group aliases (run multiple benchmarks)
        "SHA2", "SHA3", "Keccak", "KeccakCore", "SHAKE", "cSHAKE", "KT", "TurboSHAKE",
        "BLAKE2", "BLAKE2b", "BLAKE2s", "BLAKE",
        "Legacy", "RegionalHash", "Kupyna", "LSH", "Ascon", "ParallelHash", "KMAC",
        "XOF", "KeccakXOF", "BlakeXOF", "MacXOF", "AsconXOF",
        "AES-GCM", "AES-CCM", "AES-CBC", "ChaCha",
        "RegionalCipher", "SimdArm",
        "Cipher", "AEAD", "HMAC", "MAC",
        "KEM", "DSA",
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
    [switch]$ShutdownBuildServers,

    [Parameter(HelpMessage = "Mask CoreCLR instruction-set support so a narrower target can be measured on this host (e.g. -DisableIsa AVX512)")]
    [ValidateSet("AVX512", "AVX2", "SSE42", "SSSE3", "AES", "AdvSimd")]
    [string[]]$DisableIsa,

    [Parameter(HelpMessage = "Pin the benchmark process to a single logical CPU (0-based). Windows/Linux only; ignored on macOS")]
    [ValidateRange(-1, 63)]
    [int]$PinToCore = -1,

    [Parameter(HelpMessage = "Power plan for the run: UserPowerPlan (keep the active one), Balanced, PowerSaver, HighPerformance, UltimatePerformance, or a plan GUID. Windows only")]
    [string]$PowerPlan
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
    Write-Host "   - DisableIsa — AVX512 | AVX2 | SSE42 | SSSE3 | AES | AdvSimd (comma list) — none  "
    Write-Host "   - PinToCore — int logical CPU to pin the benchmark process to — -1 (unpinned)  "
    Write-Host "   - PowerPlan — UserPowerPlan | Balanced | PowerSaver | HighPerformance | UltimatePerformance | GUID — none (BDN forces HighPerformance)  "
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
    "AriaCbc192"        = "AriaCbc192"
    "AriaCbc256"        = "AriaCbc256"
    "CamelliaCbc128"    = "CamelliaCbc128"
    "CamelliaCbc192"    = "CamelliaCbc192"
    "CamelliaCbc256"    = "CamelliaCbc256"
    "KuznyechikCbc"     = "KuznyechikCbc"
    "KalynaCbc128"      = "KalynaCbc128"
    "KalynaCbc256"      = "KalynaCbc256"
    "KalynaCbc512"      = "KalynaCbc512"
    "SeedCbc"           = "SeedCbc"
    # Ciphers - AEAD and key wrapping
    "AsconAead128"      = "AsconAead128"
    "AesKeyWrap"        = "AesKeyWrap"
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
    # Post-quantum signatures. Namespace-qualified for the same reason as the KEM entries above.
    # There is no MLDsaInternals or SlhDsaInternals: neither scheme has a counterpart to
    # MLKemInternalsBenchmark yet.
    "MLDsaOps"          = "Dsa.MLDsaBenchmark"
    "MLDsaKeyGen"       = "Dsa.MLDsaKeyGenBenchmark"
    # SLH-DSA runs the six 'f' parameter sets only; the 's' sets are marked
    # ExcludeFromBenchmark in DsaAlgorithmRegistry, because signing with one takes seconds.
    "SlhDsaOps"         = "Dsa.SlhDsaBenchmark"
    "SlhDsaKeyGen"      = "Dsa.SlhDsaKeyGenBenchmark"
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
    "RegionalCipher" = @("Sm4Cbc", "AriaCbc128", "AriaCbc192", "AriaCbc256", "CamelliaCbc128", "CamelliaCbc192", "CamelliaCbc256", "KuznyechikCbc", "KalynaCbc128", "KalynaCbc256", "KalynaCbc512", "SeedCbc")
    "AEAD"           = @("AesGcm128", "AesGcm192", "AesGcm256", "AesCcm128", "AesCcm256", "ChaCha20Poly1305", "XChaCha20Poly1305", "AsconAead128")
    "Cipher"         = @("AesGcm128", "AesGcm192", "AesGcm256", "AesCcm128", "AesCcm256", "AesCbc128", "AesCbc256", "AesKeyWrap", "ChaCha20", "ChaCha20Poly1305", "XChaCha20Poly1305", "AsconAead128", "Sm4Cbc", "AriaCbc128", "AriaCbc192", "AriaCbc256", "CamelliaCbc128", "CamelliaCbc192", "CamelliaCbc256", "KuznyechikCbc", "KalynaCbc128", "KalynaCbc256", "KalynaCbc512", "SeedCbc")
    "SimdArm"        = @("SHA256", "Blake2b256", "Blake2b512", "Blake2s128", "Blake2s256", "Blake3", "AesGcm128", "AesGcm192", "AesGcm256", "AesCcm128", "AesCcm256", "AesCbc128", "AesCbc256", "ChaCha20", "ChaCha20Poly1305", "XChaCha20Poly1305")
    "HMAC"           = @("HmacMd5", "HmacSha1", "HmacSha256", "HmacSha384", "HmacSha512", "HmacSha3_256", "HmacSha3_384", "HmacSha3_512")
    "MLKem"          = @("MLKemKeyGen", "MLKemOps")
    "KEM"            = @("MLKemKeyGen", "MLKemOps", "MLKemInternals")
    # 'MLDsa' and 'SlhDsa' are the algorithms, 'DSA' the category that runs both. Keeping them
    # separate is what let SLH-DSA join 'DSA' without changing what '-Family MLDsa' runs.
    "MLDsa"          = @("MLDsaKeyGen", "MLDsaOps")
    "SlhDsa"         = @("SlhDsaKeyGen", "SlhDsaOps")
    "DSA"            = @("MLDsaKeyGen", "MLDsaOps", "SlhDsaKeyGen", "SlhDsaOps")
}

$GroupAliases["MAC"] = $GroupAliases["HMAC"] + @("AesCmac", "AesGmac", "Poly1305")

# 'All' should run all hash, cipher, MAC, KEM and signature benchmarks (convenience alias)
$GroupAliases["All"] = $GroupAliases["SHA2"] + $GroupAliases["SHA3"] + $GroupAliases["Keccak"] + $GroupAliases["SHAKE"] + $GroupAliases["cSHAKE"] + $GroupAliases["KT"] + $GroupAliases["TurboSHAKE"] + $GroupAliases["BLAKE2"] + $GroupAliases["BLAKE2b"] + $GroupAliases["BLAKE2s"] + $GroupAliases["BLAKE"] + $GroupAliases["Legacy"] + $GroupAliases["RegionalHash"] + $GroupAliases["Kupyna"] + $GroupAliases["LSH"] + $GroupAliases["Ascon"] + $GroupAliases["ParallelHash"] + $GroupAliases["KMAC"] + $GroupAliases["XOF"] + $GroupAliases["KeccakXOF"] + $GroupAliases["BlakeXOF"] + $GroupAliases["MacXOF"] + $GroupAliases["AsconXOF"] + $GroupAliases["Cipher"] + $GroupAliases["MAC"] + $GroupAliases["KEM"] + $GroupAliases["DSA"]

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
    Write-Host "  AES-KeyWrap:   -Family AesKeyWrap"
    Write-Host "  ChaCha:        -Family ChaCha20, ChaCha20Poly1305, XChaCha20Poly1305"
    Write-Host "  Ascon-AEAD:    -Family AsconAead128"
    Write-Host "  Regional:      -Family Sm4Cbc, AriaCbc128, AriaCbc192, AriaCbc256, CamelliaCbc128, CamelliaCbc192, CamelliaCbc256"
    Write-Host "                          KuznyechikCbc, KalynaCbc128, KalynaCbc256, KalynaCbc512, SeedCbc"
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
    Write-Host "Available post-quantum signature families:" -ForegroundColor Yellow
    Write-Host ""
    Write-Host "  ML-DSA:        -Family MLDsa            (key generation plus sign/verify)"
    Write-Host "  ML-DSA keygen: -Family MLDsaKeyGen      (adds the no-pairwise-consistency-test variant)"
    Write-Host "  ML-DSA ops:    -Family MLDsaOps         (sign, verify, verify of a tampered signature)"
    Write-Host "  SLH-DSA:       -Family SlhDsa           (key generation plus sign/verify, 'f' sets only)"
    Write-Host "  SLH-DSA keygen:-Family SlhDsaKeyGen     (adds the no-pairwise-consistency-test variant)"
    Write-Host "  SLH-DSA ops:   -Family SlhDsaOps        (sign, verify, verify of a tampered signature)"
    Write-Host "                                          The 's' (small-signature) sets are excluded:"
    Write-Host "                                          signing with one takes seconds per operation."
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
    Write-Host "  -Family AEAD       runs: All AEAD ciphers (AES-GCM, AES-CCM, ChaCha20-Poly1305, XChaCha20-Poly1305, Ascon-AEAD128)"
    Write-Host "  -Family RegionalCipher : All regional ciphers (SM4, ARIA-128/192/256, Camellia-128/192/256, Kuznyechik, Kalyna-128/256/512, SEED)"
    Write-Host "  -Family Cipher     runs: All cipher benchmarks (including regional)"
    Write-Host "  -Family HMAC       runs: HmacMd5, HmacSha1, HmacSha256, HmacSha384, HmacSha512, HmacSha3_256, HmacSha3_384, HmacSha3_512"
    Write-Host "  -Family MAC        runs: All HMAC variants + AesCmac, AesGmac, Poly1305"
    Write-Host "  -Family MLKem      runs: MLKemKeyGen, MLKemOps"
    Write-Host "  -Family KEM        runs: MLKemKeyGen, MLKemOps, MLKemInternals"
    Write-Host "  -Family MLDsa      runs: MLDsaKeyGen, MLDsaOps"
    Write-Host "  -Family SlhDsa     runs: SlhDsaKeyGen, SlhDsaOps"
    Write-Host "  -Family DSA        runs: MLDsaKeyGen, MLDsaOps, SlhDsaKeyGen, SlhDsaOps"
    Write-Host "  -Family All        runs: All Hash, Cipher, MAC, KEM and signature benchmarks"
    Write-Host ""
    exit 0
}

# Validate project exists
if (-not (Test-Path $testProject)) {
    Write-Host "ERROR: Test project not found at $testProject" -ForegroundColor Red
    exit 1
}

# ---------------------------------------------------------------------------
# Measurement environment: ISA masking, CPU pinning, power plan.
# ---------------------------------------------------------------------------

# CoreCLR reads these at startup and the benchmark host inherits them, as do the child
# processes BenchmarkDotNet spawns per benchmark. Note DOTNET_EnableAVX512 - the more
# obvious DOTNET_EnableAVX512F is silently a no-op.
$isaEnvMap = [ordered]@{
    "AVX512"  = "DOTNET_EnableAVX512"
    "AVX2"    = "DOTNET_EnableAVX2"
    "SSE42"   = "DOTNET_EnableSSE42"
    "SSSE3"   = "DOTNET_EnableSSSE3"
    "AES"     = "DOTNET_EnableAES"
    "AdvSimd" = "DOTNET_EnableArm64AdvSimd"
}
$savedEnv = @{}

function Set-BenchmarkEnv {
    param([string]$Name, [string]$Value)
    if (-not $savedEnv.ContainsKey($Name)) {
        $savedEnv[$Name] = [Environment]::GetEnvironmentVariable($Name)
    }
    [Environment]::SetEnvironmentVariable($Name, $Value)
}

if ($DisableIsa) {
    Write-Host "ISA mask requested: $($DisableIsa -join ', ')" -ForegroundColor Yellow
    foreach ($isa in $DisableIsa) {
        Set-BenchmarkEnv -Name $isaEnvMap[$isa] -Value "0"
        Write-Host "  $($isaEnvMap[$isa])=0" -ForegroundColor DarkGray
    }

    # Assert rather than trust. A knob that silently does nothing produces a run that
    # looks fine and measures the wrong target - after an hour of CPU time.
    Write-Host "  verifying the mask took effect..." -ForegroundColor DarkGray
    Push-Location $testProject
    try {
        $probeOutput = & dotnet run -v q --configuration $Configuration --framework $Framework -- --print-isa 2>&1
    }
    finally {
        Pop-Location
    }

    $isaLine = $probeOutput | Where-Object { $_ -is [string] -and $_ -match '^ISA ' } | Select-Object -Last 1
    if (-not $isaLine) {
        Write-Host "ERROR: could not read the ISA probe. Output was:" -ForegroundColor Red
        $probeOutput | ForEach-Object { Write-Host "  $_" -ForegroundColor DarkGray }
        exit 1
    }
    if ($isaLine -match 'unavailable=') {
        Write-Host "ERROR: -DisableIsa needs a framework with the intrinsics APIs; $Framework has none." -ForegroundColor Red
        exit 1
    }

    $resolved = @{}
    foreach ($pair in ($isaLine -replace '^ISA\s+', '') -split '\s+') {
        $kv = $pair -split '=', 2
        if ($kv.Count -eq 2) { $resolved[$kv[0]] = [bool]::Parse($kv[1]) }
    }

    $failed = @()
    foreach ($isa in $DisableIsa) {
        if ($resolved.ContainsKey($isa) -and $resolved[$isa]) { $failed += $isa }
    }
    if ($failed.Count -gt 0) {
        Write-Host "ERROR: still enabled after masking: $($failed -join ', ')" -ForegroundColor Red
        Write-Host "  resolved: $isaLine" -ForegroundColor DarkGray
        Write-Host "  The environment variable had no effect - do not trust a run made this way." -ForegroundColor Red
        exit 1
    }

    Write-Host "  resolved: $isaLine" -ForegroundColor DarkGray

    # Masking an ISA removes rows: the adapters force an algorithm tier the hardware no
    # longer offers, so those rows either vanish or silently fall back to a narrower one.
    $collapsed = @()
    if (-not $resolved["AVX512"]) { $collapsed += "CryptoHives-AVX512F" }
    if (-not $resolved["AVX2"])   { $collapsed += "CryptoHives-AVX2" }
    if (-not $resolved["SSSE3"])  { $collapsed += "CryptoHives-Ssse3" }
    if ($collapsed.Count -gt 0) {
        Write-Host "  tier collapse: no meaningful $($collapsed -join ', ') rows in this run." -ForegroundColor Yellow
    }
    Write-Host ""
}

# BenchmarkDotNet forces the High Performance plan for the duration of a run unless a job
# says otherwise, so activating a plan externally (powercfg) does nothing. tests/Common/
# Main.cs reads this and applies it as a mutator job instead.
if ($PowerPlan) {
    if (-not $IsWindows -and $PSVersionTable.PSVersion.Major -ge 6) {
        Write-Host "WARNING: -PowerPlan is Windows-only; ignoring." -ForegroundColor Yellow
    }
    else {
        Set-BenchmarkEnv -Name "CRYPTOHIVES_BENCH_POWERPLAN" -Value $PowerPlan
        Write-Host "Power plan: $PowerPlan" -ForegroundColor Yellow
        if ($PowerPlan -eq "UserPowerPlan") {
            Write-Host "  keeping the currently active plan instead of forcing High Performance." -ForegroundColor DarkGray
        }
        Write-Host ""
    }
}

# Affinity is passed to BenchmarkDotNet rather than set on this process, so it lands on
# the benchmark child processes and is recorded as a job column in the report.
$affinityMask = $null
if ($PinToCore -ge 0) {
    if (-not $IsWindows -and $PSVersionTable.PSVersion.Major -ge 6 -and -not $IsLinux) {
        Write-Host "WARNING: -PinToCore is Windows/Linux-only; ignoring." -ForegroundColor Yellow
    }
    else {
        $affinityMask = [int]([math]::Pow(2, $PinToCore))
        Write-Host "Pinning the benchmark process to logical CPU $PinToCore (affinity mask $affinityMask)." -ForegroundColor Yellow
        Write-Host "  This does not reduce throttling - it makes it repeatable, which is what an A/B needs." -ForegroundColor DarkGray
        Write-Host ""
    }
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
    # BenchmarkDotNet's --list takes a value (Flat/Tree); a bare --list is rejected
    # with "Option 'list' is defined with a bad format".
    $dotnetArgs += "--list"
    $dotnetArgs += "flat"
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

if ($null -ne $affinityMask) {
    $dotnetArgs += "--affinity"
    $dotnetArgs += [string]$affinityMask
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

    # Leave the shell as we found it - an ISA mask left set would silently affect
    # every later run from this session.
    foreach ($name in $savedEnv.Keys) {
        [Environment]::SetEnvironmentVariable($name, $savedEnv[$name])
    }

    if ($ShutdownBuildServers) {
        Write-Host ""
        Write-Host "Shutting down dotnet build servers..." -ForegroundColor DarkGray
        & dotnet build-server shutdown | Out-Host
    }
}

