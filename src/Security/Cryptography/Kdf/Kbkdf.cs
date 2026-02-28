// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Security.Cryptography.Kdf;

using CryptoHives.Foundation.Security.Cryptography.Mac;
using System;
using System.Buffers.Binary;

/// <summary>
/// Implements the Key-Based Key Derivation Function (KBKDF) in Counter Mode as defined
/// in <a href="https://csrc.nist.gov/pubs/sp/800/108/r1/upd1/final">NIST SP 800-108r1 §4.1</a>.
/// </summary>
/// <remarks>
/// <para>
/// KBKDF Counter Mode derives keying material from a key derivation key (KI) using a
/// pseudorandom function (PRF) iterated with an incrementing counter. The PRF can be
/// any keyed MAC such as HMAC-SHA-256, HMAC-SHA-512, or AES-CMAC.
/// </para>
/// <para>
/// The PRF input for each iteration is composed as:
/// <c>[i]₄ ‖ Label ‖ 0x00 ‖ Context ‖ [L]₄</c>
/// where <c>[i]₄</c> is a 32-bit big-endian counter (1-based) and <c>[L]₄</c> is
/// the output length in bits as a 32-bit big-endian integer. This format is compatible
/// with the .NET <c>SP800108DeriveBytes</c> class.
/// </para>
/// <para>
/// This KDF is widely used in IPsec (RFC 7296), Microsoft CNG, Windows DPAPI,
/// Kerberos, and many enterprise security protocols.
/// </para>
/// </remarks>
/// <example>
/// <code>
/// // Derive a 32-byte key using HMAC-SHA-256
/// byte[] masterKey = ...; // key derivation key
/// byte[] label = Encoding.UTF8.GetBytes("encryption");
/// byte[] context = Encoding.UTF8.GetBytes("session-001");
///
/// byte[] derivedKey = Kbkdf.DeriveKey(
///     key =&gt; new HmacSha256(key),
///     masterKey, outputLength: 32, label, context);
/// </code>
/// </example>
public static class Kbkdf
{
    /// <summary>
    /// Derives keying material using Counter Mode with structured input.
    /// </summary>
    /// <param name="macFactory">
    /// A factory that creates an <see cref="IMac"/> instance keyed with the given key.
    /// Supports HMAC variants (e.g., <c>HmacSha256</c>) and CMAC (e.g., <c>AesCmac</c>).
    /// </param>
    /// <param name="key">The key derivation key (KI).</param>
    /// <param name="output">The destination buffer to receive the derived keying material.</param>
    /// <param name="label">A label that identifies the purpose of the derived key.</param>
    /// <param name="context">Context information that binds the derived key to a specific use.</param>
    /// <exception cref="ArgumentNullException"><paramref name="macFactory"/> is null.</exception>
    /// <exception cref="ArgumentException">
    /// <paramref name="output"/> is empty or exceeds the maximum derivable length.
    /// </exception>
    public static void DeriveKey(
        HmacFactory macFactory,
        ReadOnlySpan<byte> key,
        Span<byte> output,
        ReadOnlySpan<byte> label,
        ReadOnlySpan<byte> context)
    {
        if (macFactory is null) throw new ArgumentNullException(nameof(macFactory));
        if (output.IsEmpty) throw new ArgumentException("Output buffer must not be empty.", nameof(output));

        long lengthInBits = (long)output.Length * 8;
        if (lengthInBits > uint.MaxValue)
            throw new ArgumentException($"Output length must not exceed {uint.MaxValue / 8} bytes.", nameof(output));

        // Compose fixed input data: Label ‖ 0x00 ‖ Context ‖ [L]₄
        int fixedLen = label.Length + 1 + context.Length + 4;
        byte[] fixedData = new byte[fixedLen];
        label.CopyTo(fixedData.AsSpan());
        // fixedData[label.Length] is already 0x00 (separator)
        context.CopyTo(fixedData.AsSpan(label.Length + 1));
        BinaryPrimitives.WriteUInt32BigEndian(fixedData.AsSpan(label.Length + 1 + context.Length), (uint)lengthInBits);

        CounterMode(macFactory, key, output, fixedData);
    }

    /// <summary>
    /// Derives keying material using Counter Mode with structured input.
    /// </summary>
    /// <param name="macFactory">
    /// A factory that creates an <see cref="IMac"/> instance keyed with the given key.
    /// </param>
    /// <param name="key">The key derivation key (KI).</param>
    /// <param name="outputLength">The desired length of the derived keying material in bytes.</param>
    /// <param name="label">
    /// A label that identifies the purpose of the derived key. If null, treated as empty.
    /// </param>
    /// <param name="context">
    /// Context information that binds the derived key to a specific use. If null, treated as empty.
    /// </param>
    /// <returns>The derived keying material.</returns>
    /// <exception cref="ArgumentNullException">
    /// <paramref name="macFactory"/> or <paramref name="key"/> is null.
    /// </exception>
    /// <exception cref="ArgumentOutOfRangeException">
    /// <paramref name="outputLength"/> is less than 1.
    /// </exception>
    public static byte[] DeriveKey(
        HmacFactory macFactory,
        byte[] key,
        int outputLength,
        byte[]? label = null,
        byte[]? context = null)
    {
        if (macFactory is null) throw new ArgumentNullException(nameof(macFactory));
        if (key is null) throw new ArgumentNullException(nameof(key));
        if (outputLength <= 0) throw new ArgumentOutOfRangeException(nameof(outputLength), "Output length must be at least 1.");

        byte[] result = new byte[outputLength];
        DeriveKey(macFactory, key, result, label ?? [], context ?? []);
        return result;
    }

    /// <summary>
    /// Core Counter Mode KDF loop using raw fixed input data.
    /// </summary>
    /// <param name="macFactory">A factory that creates a keyed MAC instance.</param>
    /// <param name="key">The key derivation key.</param>
    /// <param name="output">The destination buffer.</param>
    /// <param name="fixedInputData">
    /// The complete fixed input data appended after the counter in each PRF invocation.
    /// Typically composed as <c>Label ‖ 0x00 ‖ Context ‖ [L]₄</c>.
    /// </param>
    internal static void CounterMode(
        HmacFactory macFactory,
        ReadOnlySpan<byte> key,
        Span<byte> output,
        ReadOnlySpan<byte> fixedInputData)
    {
        using var mac = macFactory(key.ToArray());
        int h = mac.MacSize;

        Span<byte> counter = stackalloc byte[4];
        Span<byte> remaining = output;

        for (uint i = 1; remaining.Length > 0; i++)
        {
            BinaryPrimitives.WriteUInt32BigEndian(counter, i);

            mac.Reset();
            mac.Update(counter);
            mac.Update(fixedInputData);

            if (remaining.Length >= h)
            {
                mac.Finalize(remaining);
                remaining = remaining.Slice(h);
            }
            else
            {
                byte[] lastBlock = new byte[h];
                mac.Finalize(lastBlock);
                lastBlock.AsSpan(0, remaining.Length).CopyTo(remaining);
                remaining = [];
            }
        }
    }
}
