// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Security.Cryptography.Dsa;

/// <summary>
/// Defines the parameter sets for SLH-DSA as specified in FIPS 205 Table 2.
/// </summary>
internal sealed class SlhDsaParams
{
    /// <summary>SLH-DSA-SHA2-128s parameter set.</summary>
    public static readonly SlhDsaParams Sha2_128s = new("SLH-DSA-SHA2-128s", n: 16, h: 63, d: 7, hPrime: 9, a: 12, k: 14, m: 30, isShake: false);

    /// <summary>SLH-DSA-SHAKE-128s parameter set.</summary>
    public static readonly SlhDsaParams Shake128s = new("SLH-DSA-SHAKE-128s", n: 16, h: 63, d: 7, hPrime: 9, a: 12, k: 14, m: 30, isShake: true);

    /// <summary>SLH-DSA-SHA2-128f parameter set.</summary>
    public static readonly SlhDsaParams Sha2_128f = new("SLH-DSA-SHA2-128f", n: 16, h: 66, d: 22, hPrime: 3, a: 6, k: 33, m: 34, isShake: false);

    /// <summary>SLH-DSA-SHAKE-128f parameter set.</summary>
    public static readonly SlhDsaParams Shake128f = new("SLH-DSA-SHAKE-128f", n: 16, h: 66, d: 22, hPrime: 3, a: 6, k: 33, m: 34, isShake: true);

    /// <summary>SLH-DSA-SHA2-192s parameter set.</summary>
    public static readonly SlhDsaParams Sha2_192s = new("SLH-DSA-SHA2-192s", n: 24, h: 63, d: 7, hPrime: 9, a: 14, k: 17, m: 39, isShake: false);

    /// <summary>SLH-DSA-SHAKE-192s parameter set.</summary>
    public static readonly SlhDsaParams Shake192s = new("SLH-DSA-SHAKE-192s", n: 24, h: 63, d: 7, hPrime: 9, a: 14, k: 17, m: 39, isShake: true);

    /// <summary>SLH-DSA-SHA2-192f parameter set.</summary>
    public static readonly SlhDsaParams Sha2_192f = new("SLH-DSA-SHA2-192f", n: 24, h: 66, d: 22, hPrime: 3, a: 8, k: 33, m: 42, isShake: false);

    /// <summary>SLH-DSA-SHAKE-192f parameter set.</summary>
    public static readonly SlhDsaParams Shake192f = new("SLH-DSA-SHAKE-192f", n: 24, h: 66, d: 22, hPrime: 3, a: 8, k: 33, m: 42, isShake: true);

    /// <summary>SLH-DSA-SHA2-256s parameter set.</summary>
    public static readonly SlhDsaParams Sha2_256s = new("SLH-DSA-SHA2-256s", n: 32, h: 64, d: 8, hPrime: 8, a: 14, k: 22, m: 47, isShake: false);

    /// <summary>SLH-DSA-SHAKE-256s parameter set.</summary>
    public static readonly SlhDsaParams Shake256s = new("SLH-DSA-SHAKE-256s", n: 32, h: 64, d: 8, hPrime: 8, a: 14, k: 22, m: 47, isShake: true);

    /// <summary>SLH-DSA-SHA2-256f parameter set.</summary>
    public static readonly SlhDsaParams Sha2_256f = new("SLH-DSA-SHA2-256f", n: 32, h: 68, d: 17, hPrime: 4, a: 9, k: 35, m: 49, isShake: false);

    /// <summary>SLH-DSA-SHAKE-256f parameter set.</summary>
    public static readonly SlhDsaParams Shake256f = new("SLH-DSA-SHAKE-256f", n: 32, h: 68, d: 17, hPrime: 4, a: 9, k: 35, m: 49, isShake: true);

    /// <summary>The Winternitz parameter w = 2^lg_w with lg_w = 4.</summary>
    public const int W = 16;

    /// <summary>The maximum context string length in bytes.</summary>
    public const int MaxContextBytes = 255;

    /// <summary>The algorithm name, e.g. <c>SLH-DSA-SHAKE-128f</c>.</summary>
    public readonly string Name;

    /// <summary>The security parameter n in bytes (16, 24, or 32).</summary>
    public readonly int N;

    /// <summary>The total hypertree height h.</summary>
    public readonly int H;

    /// <summary>The number of hypertree layers d.</summary>
    public readonly int D;

    /// <summary>The height h′ of each XMSS tree (h = d·h′).</summary>
    public readonly int HPrime;

    /// <summary>The height a of each FORS tree.</summary>
    public readonly int A;

    /// <summary>The number of FORS trees k.</summary>
    public readonly int K;

    /// <summary>The message digest length m in bytes.</summary>
    public readonly int M;

    /// <summary>True for the SHAKE instantiation, false for SHA-2.</summary>
    public readonly bool IsShake;

    /// <summary>WOTS+ message chain count: len1 = 2n.</summary>
    public readonly int Len1;

    /// <summary>WOTS+ checksum chain count: len2 = 3 for lg_w = 4.</summary>
    public readonly int Len2;

    /// <summary>WOTS+ total chain count: len = len1 + len2.</summary>
    public readonly int Len;

    /// <summary>The public key size in bytes: 2n (PK.seed ‖ PK.root).</summary>
    public readonly int PublicKeyBytes;

    /// <summary>The secret key size in bytes: 4n (SK.seed ‖ SK.prf ‖ PK.seed ‖ PK.root).</summary>
    public readonly int SecretKeyBytes;

    /// <summary>The signature size in bytes: n·(1 + k·(a + 1) + h + d·len).</summary>
    public readonly int SignatureBytes;

    private SlhDsaParams(string name, int n, int h, int d, int hPrime, int a, int k, int m, bool isShake)
    {
        Name = name;
        N = n;
        H = h;
        D = d;
        HPrime = hPrime;
        A = a;
        K = k;
        M = m;
        IsShake = isShake;

        Len1 = 2 * n;
        Len2 = 3;
        Len = Len1 + Len2;

        PublicKeyBytes = 2 * n;
        SecretKeyBytes = 4 * n;
        SignatureBytes = n * (1 + k * (a + 1) + h + d * Len);
    }
}
