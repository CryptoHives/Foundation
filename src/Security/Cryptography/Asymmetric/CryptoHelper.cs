// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Security.Cryptography.Asymmetric;

using System;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;

using ManagedHash = CryptoHives.Foundation.Security.Cryptography.Hash;
using ManagedMac = CryptoHives.Foundation.Security.Cryptography.Mac;

/// <summary>
/// Internal cryptographic helper for the asymmetric module.
/// Provides managed hash/HMAC creation and constant-time comparison
/// without depending on OS cryptographic APIs.
/// </summary>
internal static class CryptoHelper
{
    /// <summary>
    /// Gets the output size in bytes for a named hash algorithm.
    /// </summary>
    /// <param name="hashAlgorithm">The hash algorithm identifier.</param>
    /// <returns>The hash output size in bytes.</returns>
    /// <exception cref="CryptographicException">The hash algorithm is not supported.</exception>
    internal static int GetHashLength(HashAlgorithmName hashAlgorithm)
    {
        if (hashAlgorithm == HashAlgorithmName.SHA1) return 20;
        if (hashAlgorithm == HashAlgorithmName.SHA256) return 32;
        if (hashAlgorithm == HashAlgorithmName.SHA384) return 48;
        if (hashAlgorithm == HashAlgorithmName.SHA512) return 64;
        throw new CryptographicException($"Unsupported hash algorithm: {hashAlgorithm.Name}");
    }

    /// <summary>
    /// Computes a hash of the given data using the named algorithm.
    /// </summary>
    /// <param name="hashAlgorithm">The hash algorithm identifier.</param>
    /// <param name="data">The data to hash.</param>
    /// <returns>The hash value.</returns>
    internal static byte[] HashData(HashAlgorithmName hashAlgorithm, ReadOnlySpan<byte> data)
    {
        using var hasher = CreateHash(hashAlgorithm);
        int hashSize = GetHashLength(hashAlgorithm);
        byte[] result = new byte[hashSize];
        hasher.TryComputeHash(data, result, out _);
        return result;
    }

    /// <summary>
    /// Computes HMAC using the named hash algorithm.
    /// </summary>
    /// <param name="hashAlgorithm">The hash algorithm identifier.</param>
    /// <param name="key">The HMAC key.</param>
    /// <param name="data">The data to authenticate.</param>
    /// <returns>The MAC tag.</returns>
    internal static byte[] HmacCompute(HashAlgorithmName hashAlgorithm, byte[] key, byte[] data)
    {
        using var hmac = CreateHmac(hashAlgorithm, key);
        return hmac.ComputeHash(data);
    }

    /// <summary>
    /// Constant-time byte span comparison.
    /// </summary>
    /// <param name="left">The first span to compare.</param>
    /// <param name="right">The second span to compare.</param>
    /// <returns><c>true</c> if the spans are equal; otherwise, <c>false</c>.</returns>
    [MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
    internal static bool FixedTimeEquals(ReadOnlySpan<byte> left, ReadOnlySpan<byte> right)
    {
        if (left.Length != right.Length) return false;
        int result = 0;
        for (int i = 0; i < left.Length; i++)
            result |= left[i] ^ right[i];
        return result == 0;
    }

#pragma warning disable CS0618 // SHA-1 obsolete warning - intentionally supported for legacy compatibility
    private static ManagedHash.HashAlgorithm CreateHash(HashAlgorithmName hashAlgorithm)
    {
        if (hashAlgorithm == HashAlgorithmName.SHA1) return ManagedHash.SHA1.Create();
        if (hashAlgorithm == HashAlgorithmName.SHA256) return ManagedHash.SHA256.Create();
        if (hashAlgorithm == HashAlgorithmName.SHA384) return ManagedHash.SHA384.Create();
        if (hashAlgorithm == HashAlgorithmName.SHA512) return ManagedHash.SHA512.Create();
        throw new CryptographicException($"Unsupported hash algorithm: {hashAlgorithm.Name}");
    }
#pragma warning restore CS0618

    private static ManagedMac.HmacCore CreateHmac(HashAlgorithmName hashAlgorithm, byte[] key)
    {
        if (hashAlgorithm == HashAlgorithmName.SHA256) return new ManagedMac.HmacSha256(key);
        if (hashAlgorithm == HashAlgorithmName.SHA384) return new ManagedMac.HmacSha384(key);
        if (hashAlgorithm == HashAlgorithmName.SHA512) return new ManagedMac.HmacSha512(key);
        throw new CryptographicException($"Unsupported HMAC hash: {hashAlgorithm.Name}");
    }
}
