// SPDX-FileCopyrightText: 2025 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

#pragma warning disable CA2000 // Dispose objects before losing scope, this is handled by the caller

namespace CryptoHives.Foundation.Security.Cryptography.Hash;

using System;

/// <summary>
/// Base class for CryptoHives clean-room hash algorithm implementations.
/// </summary>
/// <remarks>
/// <para>
/// This class extends <see cref="System.Security.Cryptography.HashAlgorithm"/> to provide a common base for
/// all CryptoHives hash implementations. It ensures consistent behavior and
/// provides helper methods for derived implementations.
/// </para>
/// <para>
/// All derived classes implement hash algorithms without OS or hardware dependencies,
/// providing deterministic behavior across all platforms.
/// </para>
/// </remarks>
public abstract class HashAlgorithm : System.Security.Cryptography.HashAlgorithm
{
    /// <summary>
    /// Gets the name of the hash algorithm.
    /// </summary>
    public abstract string AlgorithmName { get; }

    /// <summary>
    /// Gets the block size in bytes used by the hash algorithm.
    /// </summary>
    public abstract int BlockSize { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="HashAlgorithm"/> class.
    /// </summary>
    protected HashAlgorithm() { }

    /// <summary>
    /// Creates a new instance of the specified hash algorithm.
    /// </summary>
    /// <param name="hashName">The name of the hash algorithm to create.</param>
    /// <returns>A new hash algorithm instance.</returns>
    /// <exception cref="ArgumentException">The specified algorithm is not supported.</exception>
    public static new System.Security.Cryptography.HashAlgorithm Create(string hashName)
    {
        return hashName?.ToUpperInvariant() switch {
            // SHA-2 family (FIPS 180-4)
            "SHA224" or "SHA-224" => SHA224.Create(),
            "SHA256" or "SHA-256" => SHA256.Create(),
            "SHA384" or "SHA-384" => SHA384.Create(),
            "SHA512" or "SHA-512" => SHA512.Create(),
            "SHA512/224" or "SHA-512/224" => SHA512_224.Create(),
            "SHA512/256" or "SHA-512/256" => SHA512_256.Create(),
            // SHA-3 family (FIPS 202)
            "SHA3-224" or "SHA3224" => SHA3_224.Create(),
            "SHA3-256" or "SHA3256" => SHA3_256.Create(),
            "SHA3-384" or "SHA3384" => SHA3_384.Create(),
            "SHA3-512" or "SHA3512" => SHA3_512.Create(),
            // SHAKE XOFs (FIPS 202)
            "SHAKE128" => Shake128.Create(),
            "SHAKE256" => Shake256.Create(),
            // cSHAKE (NIST SP 800-185)
            "CSHAKE128" => CShake128.Create(),
            "CSHAKE256" => CShake256.Create(),
            // Keccak (original, used by Ethereum)
            "KECCAK-256" or "KECCAK256" => Keccak256.Create(),
            // BLAKE family
            "BLAKE2B" or "BLAKE2B-512" => Blake2b.Create(),
            "BLAKE2S" or "BLAKE2S-256" => Blake2s.Create(),
            "BLAKE3" => Blake3.Create(),
            // RIPEMD (cryptocurrency)
            "RIPEMD-160" or "RIPEMD160" => Ripemd160.Create(),
            // SM3 (Chinese national standard)
            "SM3" => SM3.Create(),
            // Whirlpool (ISO/IEC 10118-3)
            "WHIRLPOOL" => Whirlpool.Create(),
            // Streebog / GOST R 34.11-2012
            "STREEBOG-256" or "STREEBOG256" or "GOST3411-2012-256" => Streebog.Create(32),
            "STREEBOG-512" or "STREEBOG512" or "GOST3411-2012-512" or "STREEBOG" => Streebog.Create(64),
            // Legacy (deprecated)
#pragma warning disable CS0618 // SHA-1 obsolete warning - intentionally supported for legacy compatibility
            "SHA1" or "SHA-1" => SHA1.Create(),
            "MD5" => MD5.Create(),
#pragma warning restore CS0618
            _ => throw new ArgumentException($"Hash algorithm '{hashName}' is not supported.", nameof(hashName))
        };
#pragma warning restore CA2000 // Dispose objects before losing scope
    }

    /// <inheritdoc/>
    protected sealed override void HashCore(byte[] array, int ibStart, int cbSize)
    {
        HashCore(array.AsSpan(ibStart, cbSize));
    }

#if !(NETSTANDARD2_1_OR_GREATER || NET5_0_OR_GREATER)
    /// <summary>
    /// When overridden in a derived class, routes data written to the object
    /// into the hash algorithm for computing the hash.
    /// </summary>
    /// <param name="source">The input to compute the hash code for.</param>
    protected abstract void HashCore(ReadOnlySpan<byte> source);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="destination">The target buffer to write the hash to.</param>
    /// <param name="bytesWritten">The number of bytes written into the buffer.</param>
    /// <returns></returns>
    protected abstract bool TryHashFinal(Span<byte> destination, out int bytesWritten);
#endif

    /// <inheritdoc/>
    protected override byte[] HashFinal()
    {
        byte[] hash = new byte[HashSizeValue / 8];
        TryHashFinal(hash, out int bytesWritten);
        return hash;
    }

    /// <summary>
    /// Clears sensitive data from a byte array.
    /// </summary>
    /// <param name="data">The data to clear.</param>
    protected static void ClearBuffer(byte[] data)
    {
        if (data != null)
        {
            Array.Clear(data, 0, data.Length);
        }
    }

    /// <summary>
    /// Clears sensitive data from a span.
    /// </summary>
    /// <param name="data">The data to clear.</param>
    protected static void ClearBuffer(Span<byte> data)
    {
        data.Clear();
    }
}
