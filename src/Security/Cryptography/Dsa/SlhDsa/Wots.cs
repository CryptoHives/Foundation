// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Security.Cryptography.Dsa;

using System;

/// <summary>
/// WOTS+ one-time signatures for SLH-DSA (FIPS 205 §5, Algorithms 5–8) with lg_w = 4.
/// </summary>
internal static class Wots
{
    /// <summary>
    /// chain (Algorithm 5): applies F <paramref name="steps"/> times starting at index <paramref name="start"/>.
    /// </summary>
    private static void Chain(SlhDsaHash hash, SlhDsaParams p, ReadOnlySpan<byte> x, int start, int steps,
                              Adrs adrs, Span<byte> output)
    {
        x.Slice(0, p.N).CopyTo(output);
        for (int j = start; j < start + steps; j++)
        {
            adrs.SetHashAddress(j);
            hash.F(adrs, output, output);
        }
    }

    /// <summary>
    /// wots_pkGen (Algorithm 6): computes the compressed WOTS+ public key.
    /// </summary>
    /// <param name="hash">The hash family bound to PK.seed.</param>
    /// <param name="p">The parameter set.</param>
    /// <param name="skSeed">The secret seed SK.seed.</param>
    /// <param name="adrs">A WOTS_HASH address with layer, tree, and key pair set.</param>
    /// <param name="pk">Output: the n-byte compressed public key.</param>
    public static void PkGen(SlhDsaHash hash, SlhDsaParams p, ReadOnlySpan<byte> skSeed, Adrs adrs, Span<byte> pk)
    {
        Adrs skAdrs = adrs.Clone();
        skAdrs.SetTypeAndClear(Adrs.WotsPrf);
        skAdrs.SetKeyPairAddress(adrs.GetKeyPairAddress());

        byte[] tmp = new byte[p.Len * p.N];
        Span<byte> sk = stackalloc byte[32];

        for (int i = 0; i < p.Len; i++)
        {
            skAdrs.SetChainAddress(i);
            hash.Prf(skAdrs, skSeed, sk);

            adrs.SetChainAddress(i);
            Chain(hash, p, sk, 0, SlhDsaParams.W - 1, adrs, tmp.AsSpan(i * p.N, p.N));
        }

        Adrs pkAdrs = adrs.Clone();
        pkAdrs.SetTypeAndClear(Adrs.WotsPk);
        pkAdrs.SetKeyPairAddress(adrs.GetKeyPairAddress());
        hash.T(pkAdrs, tmp, pk);

        CryptographicOperations.ZeroMemory(sk);
        CryptographicOperations.ZeroMemory(tmp);
    }

    /// <summary>
    /// wots_sign (Algorithm 7): signs an n-byte message.
    /// </summary>
    /// <param name="hash">The hash family bound to PK.seed.</param>
    /// <param name="p">The parameter set.</param>
    /// <param name="message">The n-byte message to sign.</param>
    /// <param name="skSeed">The secret seed SK.seed.</param>
    /// <param name="adrs">A WOTS_HASH address with layer, tree, and key pair set.</param>
    /// <param name="signature">Output: the len·n-byte WOTS+ signature.</param>
    public static void Sign(SlhDsaHash hash, SlhDsaParams p, ReadOnlySpan<byte> message,
                            ReadOnlySpan<byte> skSeed, Adrs adrs, Span<byte> signature)
    {
        Span<int> lengths = stackalloc int[p.Len];
        ComputeChainLengths(p, message, lengths);

        Adrs skAdrs = adrs.Clone();
        skAdrs.SetTypeAndClear(Adrs.WotsPrf);
        skAdrs.SetKeyPairAddress(adrs.GetKeyPairAddress());

        Span<byte> sk = stackalloc byte[32];
        for (int i = 0; i < p.Len; i++)
        {
            skAdrs.SetChainAddress(i);
            hash.Prf(skAdrs, skSeed, sk);

            adrs.SetChainAddress(i);
            Chain(hash, p, sk, 0, lengths[i], adrs, signature.Slice(i * p.N, p.N));
        }

        CryptographicOperations.ZeroMemory(sk);
    }

    /// <summary>
    /// wots_pkFromSig (Algorithm 8): recovers the compressed public key from a signature.
    /// </summary>
    /// <param name="hash">The hash family bound to PK.seed.</param>
    /// <param name="p">The parameter set.</param>
    /// <param name="signature">The len·n-byte WOTS+ signature.</param>
    /// <param name="message">The n-byte signed message.</param>
    /// <param name="adrs">A WOTS_HASH address with layer, tree, and key pair set.</param>
    /// <param name="pk">Output: the n-byte candidate public key.</param>
    public static void PkFromSig(SlhDsaHash hash, SlhDsaParams p, ReadOnlySpan<byte> signature,
                                 ReadOnlySpan<byte> message, Adrs adrs, Span<byte> pk)
    {
        Span<int> lengths = stackalloc int[p.Len];
        ComputeChainLengths(p, message, lengths);

        byte[] tmp = new byte[p.Len * p.N];
        for (int i = 0; i < p.Len; i++)
        {
            adrs.SetChainAddress(i);
            Chain(hash, p, signature.Slice(i * p.N, p.N), lengths[i], SlhDsaParams.W - 1 - lengths[i],
                  adrs, tmp.AsSpan(i * p.N, p.N));
        }

        Adrs pkAdrs = adrs.Clone();
        pkAdrs.SetTypeAndClear(Adrs.WotsPk);
        pkAdrs.SetKeyPairAddress(adrs.GetKeyPairAddress());
        hash.T(pkAdrs, tmp, pk);
    }

    /// <summary>
    /// Splits the message into len1 base-w digits and appends the len2 checksum digits.
    /// </summary>
    private static void ComputeChainLengths(SlhDsaParams p, ReadOnlySpan<byte> message, Span<int> lengths)
    {
        for (int i = 0; i < p.Len1; i++)
        {
            int b = message[i >> 1];
            lengths[i] = (i & 1) == 0 ? b >> 4 : b & 0xF;
        }

        int csum = 0;
        for (int i = 0; i < p.Len1; i++)
        {
            csum += SlhDsaParams.W - 1 - lengths[i];
        }

        // csum ≪ (8 − (len2·lg_w mod 8)) mod 8 = 4, then base_2b over toByte(csum, 2).
        csum <<= 4;
        lengths[p.Len1] = (csum >> 12) & 0xF;
        lengths[p.Len1 + 1] = (csum >> 8) & 0xF;
        lengths[p.Len1 + 2] = (csum >> 4) & 0xF;
    }
}
