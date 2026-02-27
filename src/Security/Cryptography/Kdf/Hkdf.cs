// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Security.Cryptography.Kdf;

using CryptoHives.Foundation.Security.Cryptography.Mac;
using System;

/// <summary>
/// A factory that creates an <see cref="IMac"/> instance keyed with the specified key.
/// </summary>
/// <param name="key">The key bytes to use for the MAC.</param>
/// <returns>A new <see cref="IMac"/> instance keyed with <paramref name="key"/>.</returns>
/// <remarks>
/// <para>
/// Used by <see cref="Hkdf"/> to create HMAC instances with different keys during
/// the Extract and Expand phases of key derivation.
/// </para>
/// <code>
/// // Example: create a factory for HMAC-SHA-256
/// HmacFactory sha256Factory = key =&gt; new HmacSha256(key);
/// </code>
/// </remarks>
public delegate IMac HmacFactory(byte[] key);

/// <summary>
/// Implements HKDF (HMAC-based Extract-and-Expand Key Derivation Function) as defined
/// in <a href="https://tools.ietf.org/html/rfc5869">RFC 5869</a>.
/// </summary>
/// <remarks>
/// <para>
/// HKDF is a simple and efficient key derivation function based on HMAC. It consists
/// of two stages: Extract concentrates the entropy of the input keying
/// material into a pseudorandom key (PRK), and Expand derives one or
/// more output keys from the PRK.
/// </para>
/// <para>
/// This implementation uses the CryptoHives <see cref="IMac"/> interface, making it
/// pluggable with any HMAC variant (SHA-256, SHA-384, SHA-512, SHA3-256, etc.) and
/// fully managed across all platforms.
/// </para>
/// <para>
/// For situations where the input keying material is already uniformly random, the
/// Extract step can be skipped and the IKM used directly as the PRK in
/// Expand. See RFC 5869 for guidance.
/// </para>
/// </remarks>
/// <example>
/// <code>
/// // Derive a 32-byte key using HMAC-SHA-256
/// byte[] ikm = ...; // input keying material
/// byte[] salt = ...; // optional salt
/// byte[] info = ...; // context info
///
/// byte[] derivedKey = Hkdf.DeriveKey(
///     key =&gt; new HmacSha256(key),
///     ikm, outputLength: 32, salt, info);
/// </code>
/// </example>
public static class Hkdf
{
    /// <summary>
    /// Performs the HKDF-Extract function.
    /// See <a href="https://tools.ietf.org/html/rfc5869#section-2.2">RFC 5869 §2.2</a>.
    /// </summary>
    /// <param name="hmacFactory">A factory that creates an HMAC instance keyed with the given key.</param>
    /// <param name="ikm">The input keying material.</param>
    /// <param name="salt">
    /// The optional salt value (a non-secret random value). If empty, defaults to a
    /// zero-filled byte array of length <see cref="IMac.MacSize"/>.
    /// </param>
    /// <param name="prk">
    /// The destination buffer to receive the pseudorandom key.
    /// Must be at least <see cref="IMac.MacSize"/> bytes.
    /// </param>
    /// <returns>The number of bytes written to <paramref name="prk"/>.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="hmacFactory"/> is null.</exception>
    /// <exception cref="ArgumentException"><paramref name="prk"/> is too small.</exception>
    public static int Extract(
        HmacFactory hmacFactory,
        ReadOnlySpan<byte> ikm,
        ReadOnlySpan<byte> salt,
        Span<byte> prk)
    {
        if (hmacFactory is null) throw new ArgumentNullException(nameof(hmacFactory));

        // RFC 5869 §2.2: if salt is not provided, it is set to a string of HashLen zeros
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

        // PRK = HMAC-Hash(salt, IKM) — salt is the HMAC key
        using var hmac = hmacFactory(effectiveSalt);

        if (prk.Length < hmac.MacSize)
            throw new ArgumentException($"PRK buffer must be at least {hmac.MacSize} bytes.", nameof(prk));

        hmac.Update(ikm);
        hmac.Finalize(prk);
        return hmac.MacSize;
    }

    /// <summary>
    /// Performs the HKDF-Extract function.
    /// See <a href="https://tools.ietf.org/html/rfc5869#section-2.2">RFC 5869 §2.2</a>.
    /// </summary>
    /// <param name="hmacFactory">A factory that creates an HMAC instance keyed with the given key.</param>
    /// <param name="ikm">The input keying material.</param>
    /// <param name="salt">
    /// The optional salt value. If null, defaults to a zero-filled byte array.
    /// </param>
    /// <returns>The pseudorandom key (PRK).</returns>
    /// <exception cref="ArgumentNullException">
    /// <paramref name="hmacFactory"/> or <paramref name="ikm"/> is null.
    /// </exception>
    public static byte[] Extract(HmacFactory hmacFactory, byte[] ikm, byte[]? salt = null)
    {
        if (hmacFactory is null) throw new ArgumentNullException(nameof(hmacFactory));
        if (ikm is null) throw new ArgumentNullException(nameof(ikm));

        // Probe to get MacSize
        int macSize;
        using (var probe = hmacFactory(new byte[1]))
        {
            macSize = probe.MacSize;
        }

        byte[] prk = new byte[macSize];
        Extract(hmacFactory, ikm, salt ?? [], prk);
        return prk;
    }

    /// <summary>
    /// Performs the HKDF-Expand function.
    /// See <a href="https://tools.ietf.org/html/rfc5869#section-2.3">RFC 5869 §2.3</a>.
    /// </summary>
    /// <param name="hmacFactory">A factory that creates an HMAC instance keyed with the given key.</param>
    /// <param name="prk">
    /// The pseudorandom key (at least <see cref="IMac.MacSize"/> bytes, typically
    /// the output of Extract).
    /// </param>
    /// <param name="output">The destination buffer to receive the output keying material.</param>
    /// <param name="info">The optional context and application-specific information.</param>
    /// <exception cref="ArgumentNullException"><paramref name="hmacFactory"/> is null.</exception>
    /// <exception cref="ArgumentException">
    /// <paramref name="output"/> is empty, or exceeds 255 × <see cref="IMac.MacSize"/> bytes.
    /// </exception>
    public static void Expand(
        HmacFactory hmacFactory,
        ReadOnlySpan<byte> prk,
        Span<byte> output,
        ReadOnlySpan<byte> info)
    {
        if (hmacFactory is null) throw new ArgumentNullException(nameof(hmacFactory));
        if (output.IsEmpty) throw new ArgumentException("Output buffer must not be empty.", nameof(output));

        using var hmac = hmacFactory(prk.ToArray());
        int hashLen = hmac.MacSize;

        // RFC 5869 §2.3: L ≤ 255 × HashLen
        int maxOutput = 255 * hashLen;
        if (output.Length > maxOutput)
            throw new ArgumentException($"Output length must not exceed {maxOutput} bytes (255 × {hashLen}).", nameof(output));

        // T(0) = empty string
        // T(i) = HMAC-Hash(PRK, T(i-1) ‖ info ‖ i)  for i = 1..N
        byte[] previousT = [];
        Span<byte> remaining = output;

        for (int i = 1; remaining.Length > 0; i++)
        {
            hmac.Reset();
            if (previousT.Length > 0)
                hmac.Update(previousT);
            hmac.Update(info);
            hmac.Update([(byte)i]);

            if (remaining.Length >= hashLen)
            {
                hmac.Finalize(remaining);
                previousT = remaining.Slice(0, hashLen).ToArray();
                remaining = remaining.Slice(hashLen);
            }
            else
            {
                // Last partial block
                byte[] lastBlock = new byte[hashLen];
                hmac.Finalize(lastBlock);
                lastBlock.AsSpan(0, remaining.Length).CopyTo(remaining);
                remaining = [];
            }
        }
    }

    /// <summary>
    /// Performs the HKDF-Expand function.
    /// See <a href="https://tools.ietf.org/html/rfc5869#section-2.3">RFC 5869 §2.3</a>.
    /// </summary>
    /// <param name="hmacFactory">A factory that creates an HMAC instance keyed with the given key.</param>
    /// <param name="prk">The pseudorandom key.</param>
    /// <param name="outputLength">The desired length of the output keying material.</param>
    /// <param name="info">The optional context and application-specific information.</param>
    /// <returns>The output keying material.</returns>
    /// <exception cref="ArgumentNullException">
    /// <paramref name="hmacFactory"/> or <paramref name="prk"/> is null.
    /// </exception>
    /// <exception cref="ArgumentOutOfRangeException">
    /// <paramref name="outputLength"/> is less than 1.
    /// </exception>
    public static byte[] Expand(HmacFactory hmacFactory, byte[] prk, int outputLength, byte[]? info = null)
    {
        if (hmacFactory is null) throw new ArgumentNullException(nameof(hmacFactory));
        if (prk is null) throw new ArgumentNullException(nameof(prk));
        if (outputLength <= 0) throw new ArgumentOutOfRangeException(nameof(outputLength), "Output length must be at least 1.");

        byte[] result = new byte[outputLength];
        Expand(hmacFactory, prk, result, info ?? []);
        return result;
    }

    /// <summary>
    /// Performs the combined HKDF Extract-then-Expand key derivation.
    /// </summary>
    /// <param name="hmacFactory">A factory that creates an HMAC instance keyed with the given key.</param>
    /// <param name="ikm">The input keying material.</param>
    /// <param name="output">The destination buffer to receive the output keying material.</param>
    /// <param name="salt">
    /// The optional salt value. If empty, defaults to a zero-filled byte array.
    /// </param>
    /// <param name="info">The optional context and application-specific information.</param>
    /// <exception cref="ArgumentNullException"><paramref name="hmacFactory"/> is null.</exception>
    /// <exception cref="ArgumentException">
    /// <paramref name="output"/> is empty, or exceeds 255 × <see cref="IMac.MacSize"/> bytes.
    /// </exception>
    public static void DeriveKey(
        HmacFactory hmacFactory,
        ReadOnlySpan<byte> ikm,
        Span<byte> output,
        ReadOnlySpan<byte> salt,
        ReadOnlySpan<byte> info)
    {
        if (hmacFactory is null) throw new ArgumentNullException(nameof(hmacFactory));

        // Probe to get MacSize for PRK buffer
        int macSize;
        using (var probe = hmacFactory(new byte[1]))
        {
            macSize = probe.MacSize;
        }

        byte[] prk = new byte[macSize];
        try
        {
            Extract(hmacFactory, ikm, salt, prk);
            Expand(hmacFactory, prk, output, info);
        }
        finally
        {
            Array.Clear(prk, 0, prk.Length);
        }
    }

    /// <summary>
    /// Performs the combined HKDF Extract-then-Expand key derivation.
    /// </summary>
    /// <param name="hmacFactory">A factory that creates an HMAC instance keyed with the given key.</param>
    /// <param name="ikm">The input keying material.</param>
    /// <param name="outputLength">The desired length of the output keying material.</param>
    /// <param name="salt">The optional salt value.</param>
    /// <param name="info">The optional context and application-specific information.</param>
    /// <returns>The output keying material.</returns>
    /// <exception cref="ArgumentNullException">
    /// <paramref name="hmacFactory"/> or <paramref name="ikm"/> is null.
    /// </exception>
    /// <exception cref="ArgumentOutOfRangeException">
    /// <paramref name="outputLength"/> is less than 1.
    /// </exception>
    public static byte[] DeriveKey(HmacFactory hmacFactory, byte[] ikm, int outputLength, byte[]? salt = null, byte[]? info = null)
    {
        if (hmacFactory is null) throw new ArgumentNullException(nameof(hmacFactory));
        if (ikm is null) throw new ArgumentNullException(nameof(ikm));
        if (outputLength <= 0) throw new ArgumentOutOfRangeException(nameof(outputLength), "Output length must be at least 1.");

        byte[] result = new byte[outputLength];
        DeriveKey(hmacFactory, ikm, result, salt ?? [], info ?? []);
        return result;
    }
}
