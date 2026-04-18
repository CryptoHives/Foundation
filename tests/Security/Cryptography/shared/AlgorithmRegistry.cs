// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace Cryptography.Tests;

using CryptoHives.Foundation.Security.Cryptography.Hash;
using System;
using System.Collections.Generic;
using System.Linq;
using static Cryptography.Tests.Hash.HashAlgorithmRegistry;
using CH = CryptoHives.Foundation.Security.Cryptography;

/// <summary>
/// Algorithm registry shared code.
/// </summary>
internal static class AlgorithmRegistry
{
    public static IEnumerable<CH.SimdSupport> GetSimdVariantFlags(CH.SimdSupport simdSupport)
    {
#if NETFRAMEWORK
        return Enum.GetValues(typeof(CH.SimdSupport)).Cast<CH.SimdSupport>()
#else
        return Enum.GetValues<CH.SimdSupport>()
#endif
            .Where<CH.SimdSupport>(IsSingleBitSimdFlag)
            .Where(flag => (simdSupport & flag) != 0)
            .OrderByDescending(flag => (int)flag);
    }

    public static bool IsSingleBitSimdFlag(CH.SimdSupport flag)
    {
        int value = (int)flag;
        return value != 0 && (value & (value - 1)) == 0;
    }

    public static string GetSimdVariantName(CH.SimdSupport flag)
    {
        var suffix = flag switch {
            CH.SimdSupport.Sse2 => "SSE2",
            CH.SimdSupport.Ssse3 => "SSSE3",
            CH.SimdSupport.Avx2 => "AVX2",
            CH.SimdSupport.Avx512F => "AVX512F",
            CH.SimdSupport.AesNi => "AES-NI",
            CH.SimdSupport.PClMul => "PClMul",
            CH.SimdSupport.PClMulV256 => "PClMulV256",
            CH.SimdSupport.ArmAes => "ARM-AES",
            CH.SimdSupport.ArmPmull => "ArmPmull",
            CH.SimdSupport.ArmSha256 => "ArmSha256",
            _ => flag.ToString()
        };

        return "CryptoHives-" + suffix;
    }

    public static void AddHashSimdVariants(
        List<HashImplementation> list,
        string family,
        int hashSizeBits,
        CH.SimdSupport simdSupport,
        Func<CH.SimdSupport, HashAlgorithm> factory)
    {
        foreach (var flag in GetSimdVariantFlags(simdSupport))
        {
            string variantName = GetSimdVariantName(flag);
            list.Add(new(family, variantName, hashSizeBits,
                () => factory(flag), Source.Simd,
                () => (simdSupport & flag) != 0));
        }

        list.Add(new(family, "CryptoHives-Scalar", hashSizeBits,
            () => factory(CH.SimdSupport.None), Source.Managed));
    }
}
