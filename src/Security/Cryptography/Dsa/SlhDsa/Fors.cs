// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Security.Cryptography.Dsa;

using System;

/// <summary>
/// FORS few-time signatures for SLH-DSA (FIPS 205 §8, Algorithms 14–17).
/// </summary>
internal static class Fors
{
    /// <summary>
    /// fors_skGen (Algorithm 14 helper): derives the FORS secret value at <paramref name="idx"/>.
    /// </summary>
    private static void SkGen(SlhDsaHash hash, SlhDsaParams p, ReadOnlySpan<byte> skSeed,
                              Adrs adrs, int idx, Span<byte> sk)
    {
        Adrs skAdrs = adrs.Clone();
        skAdrs.SetTypeAndClear(Adrs.ForsPrf);
        skAdrs.SetKeyPairAddress(adrs.GetKeyPairAddress());
        skAdrs.SetTreeIndex(idx);
        hash.Prf(skAdrs, skSeed, sk);
    }

    /// <summary>
    /// fors_node (Algorithm 15): computes the FORS subtree node <paramref name="i"/> at height <paramref name="z"/>.
    /// </summary>
    private static void Node(SlhDsaHash hash, SlhDsaParams p, ReadOnlySpan<byte> skSeed,
                             int i, int z, Adrs adrs, Span<byte> output)
    {
        if (z == 0)
        {
            Span<byte> sk = stackalloc byte[32];
            SkGen(hash, p, skSeed, adrs, i, sk.Slice(0, p.N));
            adrs.SetTreeHeight(0);
            adrs.SetTreeIndex(i);
            hash.F(adrs, sk.Slice(0, p.N), output);
            CryptographicOperations.ZeroMemory(sk);
            return;
        }

        byte[] children = new byte[2 * p.N];
        Node(hash, p, skSeed, 2 * i, z - 1, adrs, children.AsSpan(0, p.N));
        Node(hash, p, skSeed, 2 * i + 1, z - 1, adrs, children.AsSpan(p.N, p.N));

        adrs.SetTreeHeight(z);
        adrs.SetTreeIndex(i);
        hash.H(adrs, children.AsSpan(0, p.N), children.AsSpan(p.N, p.N), output);

        CryptographicOperations.ZeroMemory(children);
    }

    /// <summary>
    /// fors_sign (Algorithm 16): signs the k·a-bit message digest md.
    /// </summary>
    /// <param name="hash">The hash family bound to PK.seed.</param>
    /// <param name="p">The parameter set.</param>
    /// <param name="md">The ⌈k·a/8⌉-byte message digest.</param>
    /// <param name="skSeed">The secret seed SK.seed.</param>
    /// <param name="adrs">A FORS_TREE address with layer 0, tree, and key pair set.</param>
    /// <param name="signature">Output: k·(a + 1)·n bytes — per tree: secret value ‖ auth path.</param>
    public static void Sign(SlhDsaHash hash, SlhDsaParams p, ReadOnlySpan<byte> md,
                            ReadOnlySpan<byte> skSeed, Adrs adrs, Span<byte> signature)
    {
        Span<int> indices = stackalloc int[p.K];
        Base2b(md, p.A, indices);

        int perTreeBytes = (p.A + 1) * p.N;
        for (int i = 0; i < p.K; i++)
        {
            Span<byte> treeSig = signature.Slice(i * perTreeBytes, perTreeBytes);
            SkGen(hash, p, skSeed, adrs, (i << p.A) + indices[i], treeSig.Slice(0, p.N));

            for (int j = 0; j < p.A; j++)
            {
                int s = (indices[i] >> j) ^ 1;
                Node(hash, p, skSeed, (i << (p.A - j)) + s, j, adrs, treeSig.Slice((1 + j) * p.N, p.N));
            }
        }
    }

    /// <summary>
    /// fors_pkFromSig (Algorithm 17): recomputes the FORS public key from a signature.
    /// </summary>
    /// <param name="hash">The hash family bound to PK.seed.</param>
    /// <param name="p">The parameter set.</param>
    /// <param name="signature">The k·(a + 1)·n-byte FORS signature.</param>
    /// <param name="md">The ⌈k·a/8⌉-byte message digest.</param>
    /// <param name="adrs">A FORS_TREE address with layer 0, tree, and key pair set.</param>
    /// <param name="pk">Output: the n-byte FORS public key.</param>
    public static void PkFromSig(SlhDsaHash hash, SlhDsaParams p, ReadOnlySpan<byte> signature,
                                 ReadOnlySpan<byte> md, Adrs adrs, Span<byte> pk)
    {
        Span<int> indices = stackalloc int[p.K];
        Base2b(md, p.A, indices);

        int perTreeBytes = (p.A + 1) * p.N;
        byte[] roots = new byte[p.K * p.N];
        Span<byte> node = stackalloc byte[32];

        for (int i = 0; i < p.K; i++)
        {
            ReadOnlySpan<byte> treeSig = signature.Slice(i * perTreeBytes, perTreeBytes);

            adrs.SetTreeHeight(0);
            adrs.SetTreeIndex((i << p.A) + indices[i]);
            hash.F(adrs, treeSig.Slice(0, p.N), node.Slice(0, p.N));

            for (int j = 0; j < p.A; j++)
            {
                adrs.SetTreeHeight(j + 1);
                ReadOnlySpan<byte> auth = treeSig.Slice((1 + j) * p.N, p.N);
                if (((indices[i] >> j) & 1) == 0)
                {
                    adrs.SetTreeIndex(adrs.GetTreeIndex() / 2);
                    hash.H(adrs, node.Slice(0, p.N), auth, node.Slice(0, p.N));
                }
                else
                {
                    adrs.SetTreeIndex((adrs.GetTreeIndex() - 1) / 2);
                    hash.H(adrs, auth, node.Slice(0, p.N), node.Slice(0, p.N));
                }
            }

            node.Slice(0, p.N).CopyTo(roots.AsSpan(i * p.N, p.N));
        }

        Adrs pkAdrs = adrs.Clone();
        pkAdrs.SetTypeAndClear(Adrs.ForsRoots);
        pkAdrs.SetKeyPairAddress(adrs.GetKeyPairAddress());
        hash.T(pkAdrs, roots, pk);
    }

    /// <summary>
    /// base_2b (FIPS 205 Algorithm 4): splits a bit string into b-bit big-endian values.
    /// </summary>
    /// <param name="input">The input bytes (at least ⌈output.Length·b/8⌉ bytes).</param>
    /// <param name="b">Bits per output value.</param>
    /// <param name="output">The output values.</param>
    internal static void Base2b(ReadOnlySpan<byte> input, int b, Span<int> output)
    {
        int bitPos = 0;
        for (int i = 0; i < output.Length; i++)
        {
            int value = 0;
            for (int bit = 0; bit < b; bit++)
            {
                value = (value << 1) | ((input[bitPos >> 3] >> (7 - (bitPos & 7))) & 1);
                bitPos++;
            }

            output[i] = value;
        }
    }
}
