// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Security.Cryptography.Dsa;

using System;
using OS = System.Security.Cryptography;

/// <summary>
/// Core SLH-DSA operations implementing FIPS 205 algorithms.
/// </summary>
/// <remarks>
/// Implements slh_keygen_internal (Algorithm 18), slh_sign_internal (Algorithm 19), and
/// slh_verify_internal (Algorithm 20). The external interface (Algorithms 22/24) is
/// obtained by passing the message prefix 0x00 ‖ |ctx| ‖ ctx; the internal test interface
/// passes an empty prefix. Hedged signing passes fresh randomness as opt_rand; the
/// deterministic variant passes PK.seed.
/// </remarks>
internal static class SlhDsaCore
{
    /// <summary>
    /// slh_keygen_internal (Algorithm 18): derives a key pair from the three n-byte seeds.
    /// </summary>
    /// <param name="p">The parameter set.</param>
    /// <param name="skSeed">The secret seed SK.seed (n bytes).</param>
    /// <param name="skPrf">The secret PRF key SK.prf (n bytes).</param>
    /// <param name="pkSeed">The public seed PK.seed (n bytes).</param>
    /// <param name="pk">Output: the 2n-byte public key (PK.seed ‖ PK.root).</param>
    /// <param name="sk">Output: the 4n-byte secret key (SK.seed ‖ SK.prf ‖ PK.seed ‖ PK.root).</param>
    public static void KeyGenFromSeeds(SlhDsaParams p, ReadOnlySpan<byte> skSeed, ReadOnlySpan<byte> skPrf,
                                       ReadOnlySpan<byte> pkSeed, Span<byte> pk, Span<byte> sk)
    {
        using var hash = SlhDsaHash.Create(p, pkSeed);

        var adrs = new Adrs();
        adrs.SetLayerAddress(p.D - 1);

        Span<byte> pkRoot = stackalloc byte[32];
        XmssTree.Node(hash, p, skSeed, 0, p.HPrime, adrs, pkRoot.Slice(0, p.N));

        pkSeed.Slice(0, p.N).CopyTo(pk);
        pkRoot.Slice(0, p.N).CopyTo(pk.Slice(p.N));

        skSeed.Slice(0, p.N).CopyTo(sk);
        skPrf.Slice(0, p.N).CopyTo(sk.Slice(p.N));
        pkSeed.Slice(0, p.N).CopyTo(sk.Slice(2 * p.N));
        pkRoot.Slice(0, p.N).CopyTo(sk.Slice(3 * p.N));
    }

    /// <summary>
    /// slh_keygen (Algorithm 21): generates a key pair from fresh randomness and runs a
    /// sign/verify pairwise consistency test as expected by FIPS 140-3.
    /// </summary>
    /// <exception cref="OS.CryptographicException">The key pair failed the consistency test.</exception>
    public static void KeyGen(SlhDsaParams p, Span<byte> pk, Span<byte> sk)
    {
        Span<byte> seeds = stackalloc byte[3 * 32];
        Span<byte> used = seeds.Slice(0, 3 * p.N);
        MlDsaCore.GenerateRandomSeed(used);

        KeyGenFromSeeds(p, used.Slice(0, p.N), used.Slice(p.N, p.N), used.Slice(2 * p.N, p.N), pk, sk);
        CryptographicOperations.ZeroMemory(seeds);

        Span<byte> message = stackalloc byte[32];
        MlDsaCore.GenerateRandomSeed(message);

        byte[] signature = new byte[p.SignatureBytes];
        Sign(p, sk, ReadOnlySpan<byte>.Empty, message, sk.Slice(2 * p.N, p.N), signature);
        bool consistent = Verify(p, pk, ReadOnlySpan<byte>.Empty, message, signature);

        CryptographicOperations.ZeroMemory(message);

        if (!consistent)
        {
            throw new OS.CryptographicException("SLH-DSA key generation failed the pairwise consistency test.");
        }
    }

    /// <summary>
    /// slh_sign_internal (Algorithm 19).
    /// </summary>
    /// <param name="p">The parameter set.</param>
    /// <param name="sk">The 4n-byte secret key.</param>
    /// <param name="prefix">The message prefix (0x00 ‖ |ctx| ‖ ctx for the external interface, empty for the internal interface).</param>
    /// <param name="message">The message M.</param>
    /// <param name="optRand">The n-byte opt_rand: fresh randomness for hedged signing, PK.seed for deterministic signing.</param>
    /// <param name="signature">Output: the signature.</param>
    public static void Sign(SlhDsaParams p, ReadOnlySpan<byte> sk, ReadOnlySpan<byte> prefix,
                            ReadOnlySpan<byte> message, ReadOnlySpan<byte> optRand, Span<byte> signature)
    {
        ReadOnlySpan<byte> skSeed = sk.Slice(0, p.N);
        ReadOnlySpan<byte> skPrf = sk.Slice(p.N, p.N);
        ReadOnlySpan<byte> pkSeed = sk.Slice(2 * p.N, p.N);
        ReadOnlySpan<byte> pkRoot = sk.Slice(3 * p.N, p.N);

        using var hash = SlhDsaHash.Create(p, pkSeed);

        // R = PRF_msg(SK.prf, opt_rand, M′)
        Span<byte> r = signature.Slice(0, p.N);
        hash.PrfMsg(skPrf, optRand, prefix, message, r);

        Span<byte> digest = stackalloc byte[64];
        hash.HMsg(r, pkRoot, prefix, message, digest.Slice(0, p.M));

        SplitDigest(p, digest.Slice(0, p.M), out int mdBytes, out ulong idxTree, out int idxLeaf);
        ReadOnlySpan<byte> md = digest.Slice(0, mdBytes);

        var adrs = new Adrs();
        adrs.SetTreeAddress(idxTree);
        adrs.SetTypeAndClear(Adrs.ForsTree);
        adrs.SetKeyPairAddress(idxLeaf);

        int forsSigBytes = p.K * (p.A + 1) * p.N;
        Span<byte> forsSig = signature.Slice(p.N, forsSigBytes);
        Fors.Sign(hash, p, md, skSeed, adrs, forsSig);

        var pkAdrs = new Adrs();
        pkAdrs.SetTreeAddress(idxTree);
        pkAdrs.SetTypeAndClear(Adrs.ForsTree);
        pkAdrs.SetKeyPairAddress(idxLeaf);

        Span<byte> pkFors = stackalloc byte[32];
        Fors.PkFromSig(hash, p, forsSig, md, pkAdrs, pkFors.Slice(0, p.N));

        Hypertree.Sign(hash, p, pkFors.Slice(0, p.N), skSeed, idxTree, idxLeaf,
                       signature.Slice(p.N + forsSigBytes));

        CryptographicOperations.ZeroMemory(digest);
        CryptographicOperations.ZeroMemory(pkFors);
    }

    /// <summary>
    /// slh_verify_internal (Algorithm 20).
    /// </summary>
    /// <param name="p">The parameter set.</param>
    /// <param name="pk">The 2n-byte public key.</param>
    /// <param name="prefix">The message prefix (0x00 ‖ |ctx| ‖ ctx for the external interface, empty for the internal interface).</param>
    /// <param name="message">The message M.</param>
    /// <param name="signature">The signature to verify.</param>
    /// <returns>True when the signature is valid.</returns>
    public static bool Verify(SlhDsaParams p, ReadOnlySpan<byte> pk, ReadOnlySpan<byte> prefix,
                              ReadOnlySpan<byte> message, ReadOnlySpan<byte> signature)
    {
        if (signature.Length != p.SignatureBytes)
        {
            return false;
        }

        ReadOnlySpan<byte> pkSeed = pk.Slice(0, p.N);
        ReadOnlySpan<byte> pkRoot = pk.Slice(p.N, p.N);

        using var hash = SlhDsaHash.Create(p, pkSeed);

        ReadOnlySpan<byte> r = signature.Slice(0, p.N);
        Span<byte> digest = stackalloc byte[64];
        hash.HMsg(r, pkRoot, prefix, message, digest.Slice(0, p.M));

        SplitDigest(p, digest.Slice(0, p.M), out int mdBytes, out ulong idxTree, out int idxLeaf);
        ReadOnlySpan<byte> md = digest.Slice(0, mdBytes);

        var adrs = new Adrs();
        adrs.SetTreeAddress(idxTree);
        adrs.SetTypeAndClear(Adrs.ForsTree);
        adrs.SetKeyPairAddress(idxLeaf);

        int forsSigBytes = p.K * (p.A + 1) * p.N;
        Span<byte> pkFors = stackalloc byte[32];
        Fors.PkFromSig(hash, p, signature.Slice(p.N, forsSigBytes), md, adrs, pkFors.Slice(0, p.N));

        return Hypertree.Verify(hash, p, pkFors.Slice(0, p.N), signature.Slice(p.N + forsSigBytes),
                                idxTree, idxLeaf, pkRoot);
    }

    /// <summary>
    /// Splits the H_msg digest into md ‖ idx_tree ‖ idx_leaf (FIPS 205 Algorithm 19 lines 7–10).
    /// </summary>
    private static void SplitDigest(SlhDsaParams p, ReadOnlySpan<byte> digest,
                                    out int mdBytes, out ulong idxTree, out int idxLeaf)
    {
        mdBytes = (p.K * p.A + 7) / 8;
        int treeBits = p.H - p.H / p.D;
        int leafBits = p.H / p.D;
        int treeBytes = (treeBits + 7) / 8;
        int leafBytes = (leafBits + 7) / 8;

        ulong treeMask = treeBits == 64 ? ulong.MaxValue : (1UL << treeBits) - 1;
        ulong leafMask = (1UL << leafBits) - 1;

        idxTree = ToUInt64(digest.Slice(mdBytes, treeBytes)) & treeMask;
        idxLeaf = (int)(ToUInt64(digest.Slice(mdBytes + treeBytes, leafBytes)) & leafMask);
    }

    private static ulong ToUInt64(ReadOnlySpan<byte> bytes)
    {
        ulong value = 0;
        for (int i = 0; i < bytes.Length; i++)
        {
            value = (value << 8) | bytes[i];
        }

        return value;
    }
}
