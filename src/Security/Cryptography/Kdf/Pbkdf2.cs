// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Security.Cryptography.Kdf;

using CryptoHives.Foundation.Security.Cryptography.Mac;
using System;
using System.Buffers.Binary;

/// <summary>
/// Implements PBKDF2 (Password-Based Key Derivation Function 2) as defined in
/// <a href="https://tools.ietf.org/html/rfc8018#section-5.2">RFC 8018 §5.2</a>
/// (formerly RFC 2898).
/// </summary>
/// <remarks>
/// <para>
/// PBKDF2 derives keying material from a password by applying a pseudorandom function
/// (PRF) — typically HMAC — iteratively. The iteration count slows down brute-force
/// attacks, making it suitable for password hashing and password-based encryption.
/// </para>
/// <para>
/// This implementation uses the CryptoHives <see cref="IMac"/> interface via the
/// <see cref="HmacFactory"/> delegate, making it pluggable with any HMAC variant
/// (SHA-256, SHA-384, SHA-512, SHA-1, etc.) and fully managed across all platforms.
/// </para>
/// <para>
/// Unlike the .NET <c>Rfc2898DeriveBytes</c> class, this implementation:
/// </para>
/// <list type="bullet">
/// <item>Supports any PRF via <see cref="HmacFactory"/> (not limited to <c>HashAlgorithmName</c>).</item>
/// <item>Provides span-based overloads for zero-copy key derivation.</item>
/// <item>Works on all target frameworks including .NET Framework 4.6.2 and .NET Standard 2.0.</item>
/// </list>
/// <para>
/// PBKDF2 is used in WPA/WPA2 key derivation, PKCS#12, S/MIME, password storage,
/// and many enterprise authentication protocols.
/// </para>
/// </remarks>
/// <example>
/// <code>
/// // Derive a 32-byte key from a password using HMAC-SHA-256 with 600,000 iterations
/// byte[] password = Encoding.UTF8.GetBytes("my-password");
/// byte[] salt = RandomNumberGenerator.GetBytes(16);
///
/// byte[] derivedKey = Pbkdf2.DeriveKey(
///     key =&gt; new HmacSha256(key),
///     password, salt, iterations: 600_000, outputLength: 32);
/// </code>
/// </example>
public static class Pbkdf2
{
    /// <summary>
    /// Derives keying material from a password using PBKDF2.
    /// </summary>
    /// <param name="hmacFactory">
    /// A factory that creates an <see cref="IMac"/> instance keyed with the given key.
    /// The password is used as the HMAC key.
    /// </param>
    /// <param name="password">The password (input keying material).</param>
    /// <param name="salt">The cryptographic salt.</param>
    /// <param name="iterations">
    /// The iteration count (c). Higher values increase resistance to brute-force attacks.
    /// OWASP recommends at least 600,000 for HMAC-SHA-256.
    /// </param>
    /// <param name="output">The destination buffer to receive the derived keying material.</param>
    /// <exception cref="ArgumentNullException"><paramref name="hmacFactory"/> is null.</exception>
    /// <exception cref="ArgumentException"><paramref name="output"/> is empty.</exception>
    /// <exception cref="ArgumentOutOfRangeException">
    /// <paramref name="iterations"/> is less than 1.
    /// </exception>
    public static void DeriveKey(
        HmacFactory hmacFactory,
        ReadOnlySpan<byte> password,
        ReadOnlySpan<byte> salt,
        int iterations,
        Span<byte> output)
    {
        if (hmacFactory is null) throw new ArgumentNullException(nameof(hmacFactory));
        if (output.IsEmpty) throw new ArgumentException("Output buffer must not be empty.", nameof(output));
        if (iterations < 1) throw new ArgumentOutOfRangeException(nameof(iterations), "Iteration count must be at least 1.");

        using var prf = hmacFactory(password.ToArray());
        int hLen = prf.MacSize;

        // RFC 8018 §5.2: DK = T_1 ‖ T_2 ‖ ... ‖ T_dkLen/hLen
        Span<byte> remaining = output;
        Span<byte> blockIndex = stackalloc byte[4];

        byte[] u = new byte[hLen];
        byte[] t = new byte[hLen];

        try
        {
            for (uint i = 1; remaining.Length > 0; i++)
            {
                BinaryPrimitives.WriteUInt32BigEndian(blockIndex, i);

                // U_1 = PRF(Password, Salt ‖ INT(i))
                prf.Reset();
                prf.Update(salt);
                prf.Update(blockIndex);
                prf.Finalize(u);

                // T_i = U_1
                u.AsSpan().CopyTo(t);

                // T_i = U_1 ⊕ U_2 ⊕ ... ⊕ U_c
                for (int j = 2; j <= iterations; j++)
                {
                    // U_j = PRF(Password, U_{j-1})
                    prf.Reset();
                    prf.Update(u);
                    prf.Finalize(u);

                    // T_i ^= U_j
                    for (int k = 0; k < hLen; k++)
                        t[k] ^= u[k];
                }

                // Copy T_i to output (possibly truncated for last block)
                int copyLen = Math.Min(remaining.Length, hLen);
                t.AsSpan(0, copyLen).CopyTo(remaining);
                remaining = remaining.Slice(copyLen);
            }
        }
        finally
        {
            Array.Clear(u, 0, u.Length);
            Array.Clear(t, 0, t.Length);
        }
    }

    /// <summary>
    /// Derives keying material from a password using PBKDF2.
    /// </summary>
    /// <param name="hmacFactory">
    /// A factory that creates an <see cref="IMac"/> instance keyed with the given key.
    /// </param>
    /// <param name="password">The password (input keying material).</param>
    /// <param name="salt">The cryptographic salt.</param>
    /// <param name="iterations">
    /// The iteration count (c). Higher values increase resistance to brute-force attacks.
    /// </param>
    /// <param name="outputLength">The desired length of the derived keying material in bytes.</param>
    /// <returns>The derived keying material.</returns>
    /// <exception cref="ArgumentNullException">
    /// <paramref name="hmacFactory"/>, <paramref name="password"/>, or <paramref name="salt"/> is null.
    /// </exception>
    /// <exception cref="ArgumentOutOfRangeException">
    /// <paramref name="outputLength"/> is less than 1 or <paramref name="iterations"/> is less than 1.
    /// </exception>
    public static byte[] DeriveKey(
        HmacFactory hmacFactory,
        byte[] password,
        byte[] salt,
        int iterations,
        int outputLength)
    {
        if (hmacFactory is null) throw new ArgumentNullException(nameof(hmacFactory));
        if (password is null) throw new ArgumentNullException(nameof(password));
        if (salt is null) throw new ArgumentNullException(nameof(salt));
        if (iterations < 1) throw new ArgumentOutOfRangeException(nameof(iterations), "Iteration count must be at least 1.");
        if (outputLength <= 0) throw new ArgumentOutOfRangeException(nameof(outputLength), "Output length must be at least 1.");

        byte[] result = new byte[outputLength];
        DeriveKey(hmacFactory, password, salt, iterations, result);
        return result;
    }
}
