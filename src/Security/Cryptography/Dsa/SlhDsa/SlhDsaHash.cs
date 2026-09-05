// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Security.Cryptography.Dsa;

using CryptoHives.Foundation.Security.Cryptography.Hash;
using CryptoHives.Foundation.Security.Cryptography.Mac;
using System;

/// <summary>
/// The SLH-DSA hash function family H_msg / PRF / PRF_msg / F / H / T_ℓ (FIPS 205 §11).
/// </summary>
/// <remarks>
/// Two instantiations exist: SHAKE256 (§11.1) and SHA-2 (§11.2). The SHA-2 variant uses
/// the compressed 22-byte address form, pads PK.seed to the underlying block size, and for
/// security categories 3 and 5 switches H_msg/PRF_msg/H/T_ℓ to SHA-512 while F/PRF stay
/// on SHA-256. Instances are stateful (cached hashers) and not thread-safe; create one per
/// operation.
/// </remarks>
internal abstract class SlhDsaHash : IDisposable
{
    /// <summary>The parameter set.</summary>
    protected readonly SlhDsaParams P;

    /// <summary>The public seed PK.seed (n bytes).</summary>
    protected readonly byte[] PkSeed;

    /// <summary>
    /// Initializes the hash family for a parameter set and public seed.
    /// </summary>
    protected SlhDsaHash(SlhDsaParams p, ReadOnlySpan<byte> pkSeed)
    {
        P = p;
        PkSeed = pkSeed.Slice(0, p.N).ToArray();
    }

    /// <summary>
    /// Creates the hash family instance for the given parameter set.
    /// </summary>
    public static SlhDsaHash Create(SlhDsaParams p, ReadOnlySpan<byte> pkSeed)
        => p.IsShake ? new ShakeInstance(p, pkSeed) : new Sha2Instance(p, pkSeed);

    /// <summary>F(PK.seed, ADRS, M₁): hashes a single n-byte block.</summary>
    public abstract void F(Adrs adrs, ReadOnlySpan<byte> m1, Span<byte> output);

    /// <summary>H(PK.seed, ADRS, M₂): hashes two n-byte tree nodes.</summary>
    public abstract void H(Adrs adrs, ReadOnlySpan<byte> left, ReadOnlySpan<byte> right, Span<byte> output);

    /// <summary>T_ℓ(PK.seed, ADRS, M_ℓ): compresses ℓ·n bytes to n bytes.</summary>
    public abstract void T(Adrs adrs, ReadOnlySpan<byte> ml, Span<byte> output);

    /// <summary>PRF(PK.seed, SK.seed, ADRS): derives an n-byte secret value.</summary>
    public abstract void Prf(Adrs adrs, ReadOnlySpan<byte> skSeed, Span<byte> output);

    /// <summary>PRF_msg(SK.prf, opt_rand, M′): derives the n-byte randomizer R.</summary>
    public abstract void PrfMsg(ReadOnlySpan<byte> skPrf, ReadOnlySpan<byte> optRand,
                                ReadOnlySpan<byte> prefix, ReadOnlySpan<byte> message, Span<byte> output);

    /// <summary>H_msg(R, PK.seed, PK.root, M′): derives the m-byte message digest.</summary>
    public abstract void HMsg(ReadOnlySpan<byte> r, ReadOnlySpan<byte> pkRoot,
                              ReadOnlySpan<byte> prefix, ReadOnlySpan<byte> message, Span<byte> output);

    /// <inheritdoc/>
    public abstract void Dispose();

    // ========================================================================
    // SHAKE256 instantiation (FIPS 205 §11.1)
    // ========================================================================

    private sealed class ShakeInstance : SlhDsaHash
    {
        private readonly Shake256 _shake;

        public ShakeInstance(SlhDsaParams p, ReadOnlySpan<byte> pkSeed)
            : base(p, pkSeed)
        {
            _shake = Shake256.Create(p.N);
        }

        public override void F(Adrs adrs, ReadOnlySpan<byte> m1, Span<byte> output)
        {
            _shake.Reset();
            _shake.Absorb(PkSeed);
            _shake.Absorb(adrs.Bytes);
            _shake.Absorb(m1.Slice(0, P.N));
            _shake.Squeeze(output.Slice(0, P.N));
        }

        public override void H(Adrs adrs, ReadOnlySpan<byte> left, ReadOnlySpan<byte> right, Span<byte> output)
        {
            _shake.Reset();
            _shake.Absorb(PkSeed);
            _shake.Absorb(adrs.Bytes);
            _shake.Absorb(left.Slice(0, P.N));
            _shake.Absorb(right.Slice(0, P.N));
            _shake.Squeeze(output.Slice(0, P.N));
        }

        public override void T(Adrs adrs, ReadOnlySpan<byte> ml, Span<byte> output)
        {
            _shake.Reset();
            _shake.Absorb(PkSeed);
            _shake.Absorb(adrs.Bytes);
            _shake.Absorb(ml);
            _shake.Squeeze(output.Slice(0, P.N));
        }

        public override void Prf(Adrs adrs, ReadOnlySpan<byte> skSeed, Span<byte> output)
        {
            _shake.Reset();
            _shake.Absorb(PkSeed);
            _shake.Absorb(adrs.Bytes);
            _shake.Absorb(skSeed.Slice(0, P.N));
            _shake.Squeeze(output.Slice(0, P.N));
        }

        public override void PrfMsg(ReadOnlySpan<byte> skPrf, ReadOnlySpan<byte> optRand,
                                    ReadOnlySpan<byte> prefix, ReadOnlySpan<byte> message, Span<byte> output)
        {
            _shake.Reset();
            _shake.Absorb(skPrf.Slice(0, P.N));
            _shake.Absorb(optRand.Slice(0, P.N));
            _shake.Absorb(prefix);
            _shake.Absorb(message);
            _shake.Squeeze(output.Slice(0, P.N));
        }

        public override void HMsg(ReadOnlySpan<byte> r, ReadOnlySpan<byte> pkRoot,
                                  ReadOnlySpan<byte> prefix, ReadOnlySpan<byte> message, Span<byte> output)
        {
            _shake.Reset();
            _shake.Absorb(r.Slice(0, P.N));
            _shake.Absorb(PkSeed);
            _shake.Absorb(pkRoot.Slice(0, P.N));
            _shake.Absorb(prefix);
            _shake.Absorb(message);
            _shake.Squeeze(output.Slice(0, P.M));
        }

        public override void Dispose()
        {
            _shake.Dispose();
            CryptographicOperations.ZeroMemory(PkSeed);
        }
    }

    // ========================================================================
    // SHA-2 instantiation (FIPS 205 §11.2)
    // ========================================================================

    private sealed class Sha2Instance : SlhDsaHash
    {
        private readonly Hash.HashAlgorithm _sha256;
        private readonly Hash.HashAlgorithm? _sha512;
        private readonly byte[] _paddedSeed256; // PK.seed ‖ toByte(0, 64 − n)
        private readonly byte[]? _paddedSeed512; // PK.seed ‖ toByte(0, 128 − n)
        private readonly byte[] _compressedAdrs = new byte[Adrs.CompressedBytes];

        public Sha2Instance(SlhDsaParams p, ReadOnlySpan<byte> pkSeed)
            : base(p, pkSeed)
        {
            _sha256 = SHA256.Create();
            _paddedSeed256 = new byte[64];
            pkSeed.Slice(0, p.N).CopyTo(_paddedSeed256);

            if (p.N > 16)
            {
                _sha512 = SHA512.Create();
                _paddedSeed512 = new byte[128];
                pkSeed.Slice(0, p.N).CopyTo(_paddedSeed512);
            }
        }

        public override void F(Adrs adrs, ReadOnlySpan<byte> m1, Span<byte> output)
        {
            adrs.CopyCompressedTo(_compressedAdrs);
            _sha256.AppendData(_paddedSeed256);
            _sha256.AppendData(_compressedAdrs);
            _sha256.AppendData(m1.Slice(0, P.N));
            FinishTruncated(_sha256, 32, output);
        }

        public override void H(Adrs adrs, ReadOnlySpan<byte> left, ReadOnlySpan<byte> right, Span<byte> output)
        {
            var (sha, seed, hashLen) = TreeHash();
            adrs.CopyCompressedTo(_compressedAdrs);
            sha.AppendData(seed);
            sha.AppendData(_compressedAdrs);
            sha.AppendData(left.Slice(0, P.N));
            sha.AppendData(right.Slice(0, P.N));
            FinishTruncated(sha, hashLen, output);
        }

        public override void T(Adrs adrs, ReadOnlySpan<byte> ml, Span<byte> output)
        {
            var (sha, seed, hashLen) = TreeHash();
            adrs.CopyCompressedTo(_compressedAdrs);
            sha.AppendData(seed);
            sha.AppendData(_compressedAdrs);
            sha.AppendData(ml);
            FinishTruncated(sha, hashLen, output);
        }

        public override void Prf(Adrs adrs, ReadOnlySpan<byte> skSeed, Span<byte> output)
        {
            adrs.CopyCompressedTo(_compressedAdrs);
            _sha256.AppendData(_paddedSeed256);
            _sha256.AppendData(_compressedAdrs);
            _sha256.AppendData(skSeed.Slice(0, P.N));
            FinishTruncated(_sha256, 32, output);
        }

        public override void PrfMsg(ReadOnlySpan<byte> skPrf, ReadOnlySpan<byte> optRand,
                                    ReadOnlySpan<byte> prefix, ReadOnlySpan<byte> message, Span<byte> output)
        {
            byte[] key = skPrf.Slice(0, P.N).ToArray();
            using HmacCore hmac = P.N == 16 ? new HmacSha256(key) : new HmacSha512(key);
            CryptographicOperations.ZeroMemory(key);

            hmac.Update(optRand.Slice(0, P.N));
            hmac.Update(prefix);
            hmac.Update(message);

            int hashLen = P.N == 16 ? 32 : 64;
            Span<byte> full = stackalloc byte[64];
            hmac.Finalize(full.Slice(0, hashLen));
            full.Slice(0, P.N).CopyTo(output);
            CryptographicOperations.ZeroMemory(full);
        }

        public override void HMsg(ReadOnlySpan<byte> r, ReadOnlySpan<byte> pkRoot,
                                  ReadOnlySpan<byte> prefix, ReadOnlySpan<byte> message, Span<byte> output)
        {
            Hash.HashAlgorithm sha = P.N == 16 ? _sha256 : _sha512!;
            int hashLen = P.N == 16 ? 32 : 64;

            // inner = Hash(R ‖ PK.seed ‖ PK.root ‖ M′)
            Span<byte> inner = stackalloc byte[64];
            sha.AppendData(r.Slice(0, P.N));
            sha.AppendData(PkSeed);
            sha.AppendData(pkRoot.Slice(0, P.N));
            sha.AppendData(prefix);
            sha.AppendData(message);
            sha.TryGetHashAndReset(inner.Slice(0, hashLen), out _);

            // H_msg = MGF1-Hash(R ‖ PK.seed ‖ inner, m)
            Span<byte> mgfSeed = stackalloc byte[2 * 32 + 64 + 4];
            int seedLength = 0;
            r.Slice(0, P.N).CopyTo(mgfSeed);
            seedLength += P.N;
            PkSeed.AsSpan().CopyTo(mgfSeed.Slice(seedLength));
            seedLength += P.N;
            inner.Slice(0, hashLen).CopyTo(mgfSeed.Slice(seedLength));
            seedLength += hashLen;

            Mgf1(sha, hashLen, mgfSeed.Slice(0, seedLength + 4), seedLength, output.Slice(0, P.M));
        }

        public override void Dispose()
        {
            _sha256.Dispose();
            _sha512?.Dispose();
            CryptographicOperations.ZeroMemory(PkSeed);
            CryptographicOperations.ZeroMemory(_paddedSeed256);
            if (_paddedSeed512 is not null)
            {
                CryptographicOperations.ZeroMemory(_paddedSeed512);
            }
        }

        private (Hash.HashAlgorithm Sha, byte[] PaddedSeed, int HashLen) TreeHash()
            => P.N == 16 ? (_sha256, _paddedSeed256, 32) : (_sha512!, _paddedSeed512!, 64);

        private void FinishTruncated(Hash.HashAlgorithm sha, int hashLen, Span<byte> output)
        {
            Span<byte> full = stackalloc byte[64];
            sha.TryGetHashAndReset(full.Slice(0, hashLen), out _);
            full.Slice(0, P.N).CopyTo(output);
            CryptographicOperations.ZeroMemory(full);
        }

        /// <summary>
        /// MGF1 (RFC 8017 B.2.1): output = Hash(seed ‖ 0) ‖ Hash(seed ‖ 1) ‖ … truncated.
        /// </summary>
        /// <param name="sha">The hash instance to use.</param>
        /// <param name="hashLen">The hash output length.</param>
        /// <param name="seedWithCounter">Buffer holding the seed followed by 4 spare bytes for the counter.</param>
        /// <param name="seedLength">The seed length within <paramref name="seedWithCounter"/>.</param>
        /// <param name="output">The mask output.</param>
        private static void Mgf1(Hash.HashAlgorithm sha, int hashLen, Span<byte> seedWithCounter, int seedLength, Span<byte> output)
        {
            Span<byte> block = stackalloc byte[64];
            int written = 0;
            uint counter = 0;
            while (written < output.Length)
            {
                seedWithCounter[seedLength] = (byte)(counter >> 24);
                seedWithCounter[seedLength + 1] = (byte)(counter >> 16);
                seedWithCounter[seedLength + 2] = (byte)(counter >> 8);
                seedWithCounter[seedLength + 3] = (byte)counter;

                sha.AppendData(seedWithCounter.Slice(0, seedLength + 4));
                sha.TryGetHashAndReset(block.Slice(0, hashLen), out _);

                int take = Math.Min(hashLen, output.Length - written);
                block.Slice(0, take).CopyTo(output.Slice(written));
                written += take;
                counter++;
            }

            CryptographicOperations.ZeroMemory(block);
        }
    }
}
