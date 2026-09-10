// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Security.Cryptography.KeyFormats;

using CryptoHives.Foundation.Security.Cryptography.Hash;
using System;

/// <summary>
/// The PKCS#12 v1 key derivation function (RFC 7292 Appendix B.2).
/// </summary>
/// <remarks>
/// <para>
/// Needed only on the <b>import</b> path, to open <c>EncryptedPrivateKeyInfo</c> structures written
/// by older OpenSSL and Windows tooling. Nothing in this library writes it: exports always use
/// PBES2, matching what .NET 10 emits.
/// </para>
/// <para>
/// The password is encoded as big-endian UTF-16 with a trailing two-byte NUL terminator, which is
/// the detail this KDF is most often got wrong on.
/// </para>
/// </remarks>
internal static class Pkcs12Kdf
{
    /// <summary>Derives an encryption key (ID 1).</summary>
    public const byte KeyMaterialId = 1;

    /// <summary>Derives an initialization vector (ID 2).</summary>
    public const byte IvMaterialId = 2;

    /// <summary>Derives a MAC key (ID 3).</summary>
    public const byte MacMaterialId = 3;

    /// <summary>
    /// Derives keying material.
    /// </summary>
    /// <param name="password">
    /// The password, already encoded per RFC 7292 B.1 - see <see cref="PbePassword.ForPkcs12Kdf"/>,
    /// which owns that encoding so no call site has to repeat it.
    /// </param>
    /// <param name="salt">The salt.</param>
    /// <param name="iterations">The iteration count.</param>
    /// <param name="id">One of <see cref="KeyMaterialId"/>, <see cref="IvMaterialId"/>, <see cref="MacMaterialId"/>.</param>
    /// <param name="output">Receives the derived material.</param>
    public static void DeriveKey(
        ReadOnlySpan<byte> password,
        ReadOnlySpan<byte> salt,
        int iterations,
        byte id,
        Span<byte> output)
    {
        // SHA-1 is the only hash the PKCS#12 schemes in RFC 7292 App. C use.
        const int u = 20;
        const int v = 64;

        Span<byte> diversifier = stackalloc byte[v];
        diversifier.Fill(id);

        byte[] s = Expand(salt, v);
        byte[] p = Expand(password, v);
        byte[] i = new byte[s.Length + p.Length];
        Buffer.BlockCopy(s, 0, i, 0, s.Length);
        Buffer.BlockCopy(p, 0, i, s.Length, p.Length);

        byte[] a = new byte[u];
        Span<byte> b = stackalloc byte[v];

        try
        {
            int generated = 0;
            while (generated < output.Length)
            {
#pragma warning disable CS0618 // RFC 7292 App. B.2 specifies SHA-1; this is a legacy read path.
                using (var sha1 = SHA1.Create())
#pragma warning restore CS0618
                {
                    sha1.AppendData(diversifier);
                    sha1.AppendData(i);
                    sha1.TryGetHashAndReset(a, out _);

                    for (int round = 1; round < iterations; round++)
                    {
                        sha1.AppendData(a);
                        sha1.TryGetHashAndReset(a, out _);
                    }
                }

                int take = Math.Min(u, output.Length - generated);
                a.AsSpan(0, take).CopyTo(output.Slice(generated));
                generated += take;

                if (generated >= output.Length)
                {
                    break;
                }

                // B = the first v bits of A, repeated.
                for (int k = 0; k < v; k++)
                {
                    b[k] = a[k % u];
                }

                // I_j = (I_j + B + 1) mod 2^v, for each v-byte block of I.
                for (int block = 0; block < i.Length / v; block++)
                {
                    int carry = 1;
                    for (int k = v - 1; k >= 0; k--)
                    {
                        int index = (block * v) + k;
                        int sum = i[index] + b[k] + carry;
                        i[index] = (byte)sum;
                        carry = sum >> 8;
                    }
                }
            }
        }
        finally
        {
            CryptographicOperations.ZeroMemory(a);
            CryptographicOperations.ZeroMemory(b);
            CryptographicOperations.ZeroMemory(i);
            CryptographicOperations.ZeroMemory(p);
            CryptographicOperations.ZeroMemory(s);
        }
    }

    /// <summary>
    /// Repeats <paramref name="source"/> to fill a whole number of <paramref name="blockSize"/>
    /// blocks, as RFC 7292 B.2 steps 2 and 3 require. An empty input expands to nothing.
    /// </summary>
    private static byte[] Expand(ReadOnlySpan<byte> source, int blockSize)
    {
        if (source.IsEmpty)
        {
            return [];
        }

        int length = ((source.Length + blockSize - 1) / blockSize) * blockSize;
        byte[] result = new byte[length];
        for (int i = 0; i < length; i++)
        {
            result[i] = source[i % source.Length];
        }

        return result;
    }
}
