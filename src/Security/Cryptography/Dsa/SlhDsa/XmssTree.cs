// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Security.Cryptography.Dsa;

using System;

/// <summary>
/// XMSS Merkle trees inside the SLH-DSA hypertree (FIPS 205 §6, Algorithms 9–11).
/// </summary>
internal static class XmssTree
{
    /// <summary>
    /// xmss_node (Algorithm 9): computes the root of the subtree of height <paramref name="z"/>
    /// whose leftmost leaf is WOTS+ key pair <paramref name="i"/> · 2^z.
    /// </summary>
    /// <param name="hash">The hash family bound to PK.seed.</param>
    /// <param name="p">The parameter set.</param>
    /// <param name="skSeed">The secret seed SK.seed.</param>
    /// <param name="i">The node index at height <paramref name="z"/>.</param>
    /// <param name="z">The node height (0 = leaf).</param>
    /// <param name="adrs">An address with layer and tree set; type fields are managed here.</param>
    /// <param name="output">Output: the n-byte node value.</param>
    public static void Node(SlhDsaHash hash, SlhDsaParams p, ReadOnlySpan<byte> skSeed,
                            int i, int z, Adrs adrs, Span<byte> output)
    {
        if (z == 0)
        {
            adrs.SetTypeAndClear(Adrs.WotsHash);
            adrs.SetKeyPairAddress(i);
            Wots.PkGen(hash, p, skSeed, adrs, output);
            return;
        }

        byte[] children = new byte[2 * p.N];
        Node(hash, p, skSeed, 2 * i, z - 1, adrs, children.AsSpan(0, p.N));
        Node(hash, p, skSeed, 2 * i + 1, z - 1, adrs, children.AsSpan(p.N, p.N));

        adrs.SetTypeAndClear(Adrs.Tree);
        adrs.SetTreeHeight(z);
        adrs.SetTreeIndex(i);
        hash.H(adrs, children.AsSpan(0, p.N), children.AsSpan(p.N, p.N), output);

        CryptographicOperations.ZeroMemory(children);
    }

    /// <summary>
    /// xmss_sign (Algorithm 10): signs an n-byte message with the WOTS+ key at
    /// <paramref name="idx"/> and appends the authentication path.
    /// </summary>
    /// <param name="hash">The hash family bound to PK.seed.</param>
    /// <param name="p">The parameter set.</param>
    /// <param name="message">The n-byte message (the root of the tree below, or FORS pk).</param>
    /// <param name="skSeed">The secret seed SK.seed.</param>
    /// <param name="idx">The leaf (WOTS+ key pair) index within this tree.</param>
    /// <param name="adrs">An address with layer and tree set.</param>
    /// <param name="signature">Output: (len + h′)·n bytes — WOTS+ signature ‖ auth path.</param>
    public static void Sign(SlhDsaHash hash, SlhDsaParams p, ReadOnlySpan<byte> message,
                            ReadOnlySpan<byte> skSeed, int idx, Adrs adrs, Span<byte> signature)
    {
        int wotsSigBytes = p.Len * p.N;
        for (int j = 0; j < p.HPrime; j++)
        {
            int k = (idx >> j) ^ 1;
            Node(hash, p, skSeed, k, j, adrs, signature.Slice(wotsSigBytes + j * p.N, p.N));
        }

        adrs.SetTypeAndClear(Adrs.WotsHash);
        adrs.SetKeyPairAddress(idx);
        Wots.Sign(hash, p, message, skSeed, adrs, signature.Slice(0, wotsSigBytes));
    }

    /// <summary>
    /// xmss_pkFromSig (Algorithm 11): recomputes the tree root from a signature.
    /// </summary>
    /// <param name="hash">The hash family bound to PK.seed.</param>
    /// <param name="p">The parameter set.</param>
    /// <param name="idx">The leaf index within this tree.</param>
    /// <param name="signature">The (len + h′)·n-byte XMSS signature.</param>
    /// <param name="message">The n-byte signed message.</param>
    /// <param name="adrs">An address with layer and tree set.</param>
    /// <param name="root">Output: the n-byte candidate root.</param>
    public static void PkFromSig(SlhDsaHash hash, SlhDsaParams p, int idx, ReadOnlySpan<byte> signature,
                                 ReadOnlySpan<byte> message, Adrs adrs, Span<byte> root)
    {
        int wotsSigBytes = p.Len * p.N;

        adrs.SetTypeAndClear(Adrs.WotsHash);
        adrs.SetKeyPairAddress(idx);
        Span<byte> node = stackalloc byte[32];
        Wots.PkFromSig(hash, p, signature.Slice(0, wotsSigBytes), message, adrs, node.Slice(0, p.N));

        adrs.SetTypeAndClear(Adrs.Tree);
        adrs.SetTreeIndex(idx);
        for (int k = 0; k < p.HPrime; k++)
        {
            adrs.SetTreeHeight(k + 1);
            ReadOnlySpan<byte> auth = signature.Slice(wotsSigBytes + k * p.N, p.N);
            if (((idx >> k) & 1) == 0)
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

        node.Slice(0, p.N).CopyTo(root);
    }
}
