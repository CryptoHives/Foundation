// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Security.Cryptography.Kdf;

using CryptoHives.Foundation.Security.Cryptography.Mac;
using System;
using System.Buffers.Binary;
using System.Security.Cryptography;

/// <summary>
/// Implements the Concatenation Key Derivation Function (Concat KDF) as defined in
/// NIST SP 800-56A §5.8.1 and NIST SP 800-56C rev2 Option 1.
/// </summary>
/// <remarks>
/// <para>
/// Concat KDF is a single-step key derivation function used to derive keying material
/// from a shared secret (e.g., from ECDH key agreement). Each iteration computes:
/// <c>Hash(counter ‖ Z ‖ OtherInfo)</c> with a 32-bit big-endian counter starting at 1.
/// </para>
/// <para>
/// Two variants are supported:
/// </para>
/// <list type="bullet">
/// <item><b>Hash-based</b> (SP 800-56A §5.8.1): Uses a plain hash function as the
/// auxiliary function. The <see cref="DeriveKey(HashAlgorithm, ReadOnlySpan{byte}, Span{byte}, ReadOnlySpan{byte})"/>
/// overloads accept any <see cref="HashAlgorithm"/>.</item>
/// <item><b>HMAC-based</b> (SP 800-56C rev2 Option 1): Uses an HMAC keyed with an
/// optional salt as the auxiliary function. The <see cref="DeriveKey(HmacFactory, ReadOnlySpan{byte}, Span{byte}, ReadOnlySpan{byte}, ReadOnlySpan{byte})"/>
/// overloads accept an <see cref="HmacFactory"/>.</item>
/// </list>
/// <para>
/// This KDF is used in ECDH key agreement (NIST SP 800-56A), JOSE/JWE (RFC 7518),
/// and various ECC-based protocols.
/// </para>
/// </remarks>
/// <example>
/// <code>
/// // Hash-based: derive 32 bytes from ECDH shared secret
/// using var sha256 = SHA256.Create();
/// byte[] derivedKey = ConcatKdf.DeriveKey(sha256, sharedSecret, 32, otherInfo);
///
/// // HMAC-based: derive 32 bytes with salt
/// byte[] derivedKey = ConcatKdf.DeriveKey(
///     key =&gt; new HmacSha256(key),
///     sharedSecret, 32, otherInfo, salt);
/// </code>
/// </example>
public static class ConcatKdf
{
    // ---------------------------------------------------------------
    // Hash-based variant (SP 800-56A §5.8.1)
    // ---------------------------------------------------------------

    /// <summary>
    /// Derives keying material using the hash-based Concat KDF.
    /// </summary>
    /// <param name="hash">
    /// The hash algorithm to use. The instance is reused across iterations via
    /// <see cref="HashAlgorithm.ComputeHash(byte[])"/>.
    /// </param>
    /// <param name="sharedSecret">
    /// The shared secret (Z), typically from a key agreement such as ECDH.
    /// </param>
    /// <param name="output">The destination buffer to receive the derived keying material.</param>
    /// <param name="otherInfo">
    /// Supplementary public information (e.g., algorithm ID, party info, key length).
    /// </param>
    /// <exception cref="ArgumentNullException"><paramref name="hash"/> is null.</exception>
    /// <exception cref="ArgumentException"><paramref name="output"/> is empty.</exception>
    public static void DeriveKey(
        HashAlgorithm hash,
        ReadOnlySpan<byte> sharedSecret,
        Span<byte> output,
        ReadOnlySpan<byte> otherInfo)
    {
        if (hash is null) throw new ArgumentNullException(nameof(hash));
        if (output.IsEmpty) throw new ArgumentException("Output buffer must not be empty.", nameof(output));

        int hashLen = hash.HashSize / 8;

        // Compose input buffer: [counter(4)] [Z] [OtherInfo]
        byte[] input = new byte[4 + sharedSecret.Length + otherInfo.Length];
        sharedSecret.CopyTo(input.AsSpan(4));
        otherInfo.CopyTo(input.AsSpan(4 + sharedSecret.Length));

        Span<byte> remaining = output;

        for (uint counter = 1; remaining.Length > 0; counter++)
        {
            BinaryPrimitives.WriteUInt32BigEndian(input.AsSpan(0, 4), counter);
            byte[] block = hash.ComputeHash(input);

            if (remaining.Length >= hashLen)
            {
                block.AsSpan().CopyTo(remaining);
                remaining = remaining.Slice(hashLen);
            }
            else
            {
                block.AsSpan(0, remaining.Length).CopyTo(remaining);
                remaining = [];
            }
        }
    }

    /// <summary>
    /// Derives keying material using the hash-based Concat KDF.
    /// </summary>
    /// <param name="hash">The hash algorithm to use.</param>
    /// <param name="sharedSecret">The shared secret (Z).</param>
    /// <param name="outputLength">The desired length of the derived keying material in bytes.</param>
    /// <param name="otherInfo">Supplementary public information. If null, treated as empty.</param>
    /// <returns>The derived keying material.</returns>
    /// <exception cref="ArgumentNullException">
    /// <paramref name="hash"/> or <paramref name="sharedSecret"/> is null.
    /// </exception>
    /// <exception cref="ArgumentOutOfRangeException">
    /// <paramref name="outputLength"/> is less than 1.
    /// </exception>
    public static byte[] DeriveKey(
        HashAlgorithm hash,
        byte[] sharedSecret,
        int outputLength,
        byte[]? otherInfo = null)
    {
        if (hash is null) throw new ArgumentNullException(nameof(hash));
        if (sharedSecret is null) throw new ArgumentNullException(nameof(sharedSecret));
        if (outputLength <= 0) throw new ArgumentOutOfRangeException(nameof(outputLength), "Output length must be at least 1.");

        byte[] result = new byte[outputLength];
        DeriveKey(hash, sharedSecret, result, otherInfo ?? []);
        return result;
    }

    // ---------------------------------------------------------------
    // HMAC-based variant (SP 800-56C rev2 Option 1 with HMAC)
    // ---------------------------------------------------------------

    /// <summary>
    /// Derives keying material using the HMAC-based Concat KDF.
    /// </summary>
    /// <param name="hmacFactory">
    /// A factory that creates an <see cref="IMac"/> instance keyed with the given key.
    /// </param>
    /// <param name="sharedSecret">
    /// The shared secret (Z), typically from a key agreement such as ECDH.
    /// </param>
    /// <param name="output">The destination buffer to receive the derived keying material.</param>
    /// <param name="otherInfo">Supplementary public information.</param>
    /// <param name="salt">
    /// The optional salt used as the HMAC key. If empty, defaults to a zero-filled
    /// byte array of length <see cref="IMac.MacSize"/>.
    /// </param>
    /// <exception cref="ArgumentNullException"><paramref name="hmacFactory"/> is null.</exception>
    /// <exception cref="ArgumentException"><paramref name="output"/> is empty.</exception>
    public static void DeriveKey(
        HmacFactory hmacFactory,
        ReadOnlySpan<byte> sharedSecret,
        Span<byte> output,
        ReadOnlySpan<byte> otherInfo,
        ReadOnlySpan<byte> salt)
    {
        if (hmacFactory is null) throw new ArgumentNullException(nameof(hmacFactory));
        if (output.IsEmpty) throw new ArgumentException("Output buffer must not be empty.", nameof(output));

        byte[] effectiveSalt;
        if (salt.IsEmpty)
        {
            using var probe = hmacFactory(new byte[1]);
            effectiveSalt = new byte[probe.MacSize];
        }
        else
        {
            effectiveSalt = salt.ToArray();
        }

        using var hmac = hmacFactory(effectiveSalt);
        int h = hmac.MacSize;

        Span<byte> counterBytes = stackalloc byte[4];
        Span<byte> remaining = output;

        for (uint counter = 1; remaining.Length > 0; counter++)
        {
            BinaryPrimitives.WriteUInt32BigEndian(counterBytes, counter);

            hmac.Reset();
            hmac.Update(counterBytes);
            hmac.Update(sharedSecret);
            hmac.Update(otherInfo);

            if (remaining.Length >= h)
            {
                hmac.Finalize(remaining);
                remaining = remaining.Slice(h);
            }
            else
            {
                byte[] lastBlock = new byte[h];
                hmac.Finalize(lastBlock);
                lastBlock.AsSpan(0, remaining.Length).CopyTo(remaining);
                remaining = [];
            }
        }
    }

    /// <summary>
    /// Derives keying material using the HMAC-based Concat KDF.
    /// </summary>
    /// <param name="hmacFactory">
    /// A factory that creates an <see cref="IMac"/> instance keyed with the given key.
    /// </param>
    /// <param name="sharedSecret">The shared secret (Z).</param>
    /// <param name="outputLength">The desired length of the derived keying material in bytes.</param>
    /// <param name="otherInfo">Supplementary public information. If null, treated as empty.</param>
    /// <param name="salt">
    /// The optional salt used as the HMAC key. If null, defaults to a zero-filled byte array.
    /// </param>
    /// <returns>The derived keying material.</returns>
    /// <exception cref="ArgumentNullException">
    /// <paramref name="hmacFactory"/> or <paramref name="sharedSecret"/> is null.
    /// </exception>
    /// <exception cref="ArgumentOutOfRangeException">
    /// <paramref name="outputLength"/> is less than 1.
    /// </exception>
    public static byte[] DeriveKey(
        HmacFactory hmacFactory,
        byte[] sharedSecret,
        int outputLength,
        byte[]? otherInfo = null,
        byte[]? salt = null)
    {
        if (hmacFactory is null) throw new ArgumentNullException(nameof(hmacFactory));
        if (sharedSecret is null) throw new ArgumentNullException(nameof(sharedSecret));
        if (outputLength <= 0) throw new ArgumentOutOfRangeException(nameof(outputLength), "Output length must be at least 1.");

        byte[] result = new byte[outputLength];
        DeriveKey(hmacFactory, sharedSecret, result, otherInfo ?? [], salt ?? []);
        return result;
    }
}
