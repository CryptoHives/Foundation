// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Security.Cryptography.Dsa;

using System;

/// <summary>
/// The SLH-DSA hypertree: a d-layer tree of XMSS trees (FIPS 205 §7, Algorithms 12/13).
/// </summary>
internal static class Hypertree
{
    /// <summary>
    /// ht_sign (Algorithm 12): signs an n-byte message (the FORS public key) with the
    /// leaf at (<paramref name="idxTree"/>, <paramref name="idxLeaf"/>), chaining
    /// XMSS signatures up all d layers.
    /// </summary>
    /// <param name="hash">The hash family bound to PK.seed.</param>
    /// <param name="p">The parameter set.</param>
    /// <param name="message">The n-byte message.</param>
    /// <param name="skSeed">The secret seed SK.seed.</param>
    /// <param name="idxTree">The tree index at the bottom layer.</param>
    /// <param name="idxLeaf">The leaf index within the bottom tree.</param>
    /// <param name="signature">Output: (h + d·len)·n bytes.</param>
    public static void Sign(SlhDsaHash hash, SlhDsaParams p, ReadOnlySpan<byte> message,
                            ReadOnlySpan<byte> skSeed, ulong idxTree, int idxLeaf, Span<byte> signature)
    {
        int xmssSigBytes = (p.Len + p.HPrime) * p.N;
        ulong leafMask = (1UL << p.HPrime) - 1;

        Span<byte> root = stackalloc byte[32];
        message.Slice(0, p.N).CopyTo(root);

        for (int j = 0; j < p.D; j++)
        {
            var adrs = new Adrs();
            adrs.SetLayerAddress(j);
            adrs.SetTreeAddress(idxTree);

            Span<byte> layerSig = signature.Slice(j * xmssSigBytes, xmssSigBytes);
            XmssTree.Sign(hash, p, root.Slice(0, p.N), skSeed, idxLeaf, adrs, layerSig);

            if (j < p.D - 1)
            {
                // The next layer signs this tree's root.
                var pkAdrs = new Adrs();
                pkAdrs.SetLayerAddress(j);
                pkAdrs.SetTreeAddress(idxTree);
                XmssTree.PkFromSig(hash, p, idxLeaf, layerSig, root.Slice(0, p.N), pkAdrs, root.Slice(0, p.N));

                idxLeaf = (int)(idxTree & leafMask);
                idxTree >>= p.HPrime;
            }
        }

        CryptographicOperations.ZeroMemory(root);
    }

    /// <summary>
    /// ht_verify (Algorithm 13): recomputes the hypertree root from a signature and
    /// compares it against PK.root.
    /// </summary>
    /// <param name="hash">The hash family bound to PK.seed.</param>
    /// <param name="p">The parameter set.</param>
    /// <param name="message">The n-byte signed message (the FORS public key).</param>
    /// <param name="signature">The (h + d·len)·n-byte hypertree signature.</param>
    /// <param name="idxTree">The tree index at the bottom layer.</param>
    /// <param name="idxLeaf">The leaf index within the bottom tree.</param>
    /// <param name="pkRoot">The public key root PK.root.</param>
    /// <returns>True when the recomputed root matches PK.root.</returns>
    public static bool Verify(SlhDsaHash hash, SlhDsaParams p, ReadOnlySpan<byte> message,
                              ReadOnlySpan<byte> signature, ulong idxTree, int idxLeaf, ReadOnlySpan<byte> pkRoot)
    {
        int xmssSigBytes = (p.Len + p.HPrime) * p.N;
        ulong leafMask = (1UL << p.HPrime) - 1;

        Span<byte> node = stackalloc byte[32];
        message.Slice(0, p.N).CopyTo(node);

        for (int j = 0; j < p.D; j++)
        {
            var adrs = new Adrs();
            adrs.SetLayerAddress(j);
            adrs.SetTreeAddress(idxTree);

            ReadOnlySpan<byte> layerSig = signature.Slice(j * xmssSigBytes, xmssSigBytes);
            XmssTree.PkFromSig(hash, p, idxLeaf, layerSig, node.Slice(0, p.N), adrs, node.Slice(0, p.N));

            idxLeaf = (int)(idxTree & leafMask);
            idxTree >>= p.HPrime;
        }

        return CryptographicOperations.FixedTimeEquals(node.Slice(0, p.N), pkRoot.Slice(0, p.N));
    }
}
