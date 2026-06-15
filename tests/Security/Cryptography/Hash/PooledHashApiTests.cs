// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace Cryptography.Tests.Hash;

using CryptoHives.Foundation.Security.Cryptography.Hash;
using NUnit.Framework;
using System;
using System.Buffers;
using System.Text;

/// <summary>
/// Tests for the static pooled <c>HashData</c> and <c>TryHashData</c> one-shot methods
/// exposed on every hash algorithm in the package.
/// </summary>
/// <remarks>
/// Each test verifies correctness against a known test vector and that the two overloads
/// (<c>TryHashData</c> to a span, <c>HashData</c> returning a byte array) agree.
/// Tests for undersized destinations, boundary conditions, and sequential concurrent reuse
/// are also included to validate the pooling contract.
/// </remarks>
[TestFixture]
[Parallelizable(ParallelScope.All)]
public class PooledHashApiTests
{
    private static readonly byte[] Empty = Array.Empty<byte>();
    private static readonly byte[] Abc = Encoding.ASCII.GetBytes("abc");

    // ── SHA-2 ─────────────────────────────────────────────────────────────────

    [Test]
    public void SHA256HashDataMatchesKnownVector()
    {
        byte[] expected = TestHelpers.FromHexString(
            "ba7816bf8f01cfea414140de5dae2223b00361a396177a9cb410ff61f20015ad");

        byte[] fromArray = SHA256.HashData(Abc);
        Assert.That(fromArray, Is.EqualTo(expected));

        Span<byte> dest = stackalloc byte[32];
        bool ok = SHA256.TryHashData(Abc, dest, out int written);
        Assert.That(ok, Is.True);
        Assert.That(written, Is.EqualTo(32));
        Assert.That(dest.ToArray(), Is.EqualTo(expected));
    }

    [Test]
    public void SHA224HashDataMatchesKnownVector()
    {
        byte[] expected = TestHelpers.FromHexString(
            "23097d223405d8228642a477bda255b32aadbce4bda0b3f7e36c9da7");

        byte[] fromArray = SHA224.HashData(Abc);
        Assert.That(fromArray, Is.EqualTo(expected));

        Span<byte> dest = stackalloc byte[28];
        bool ok = SHA224.TryHashData(Abc, dest, out int written);
        Assert.That(ok, Is.True);
        Assert.That(written, Is.EqualTo(28));
        Assert.That(dest.ToArray(), Is.EqualTo(expected));
    }

    [Test]
    public void SHA384HashDataMatchesKnownVector()
    {
        byte[] expected = TestHelpers.FromHexString(
            "cb00753f45a35e8bb5a03d699ac65007272c32ab0eded163" +
            "1a8b605a43ff5bed8086072ba1e7cc2358baeca134c825a7");

        byte[] fromArray = SHA384.HashData(Abc);
        Assert.That(fromArray, Is.EqualTo(expected));

        Span<byte> dest = stackalloc byte[48];
        bool ok = SHA384.TryHashData(Abc, dest, out int written);
        Assert.That(ok, Is.True);
        Assert.That(written, Is.EqualTo(48));
        Assert.That(dest.ToArray(), Is.EqualTo(expected));
    }

    [Test]
    public void SHA512HashDataMatchesKnownVector()
    {
        byte[] expected = TestHelpers.FromHexString(
            "ddaf35a193617abacc417349ae20413112e6fa4e89a97ea2" +
            "0a9eeee64b55d39a2192992a274fc1a836ba3c23a3feebbd" +
            "454d4423643ce80e2a9ac94fa54ca49f");

        byte[] fromArray = SHA512.HashData(Abc);
        Assert.That(fromArray, Is.EqualTo(expected));

        Span<byte> dest = stackalloc byte[64];
        bool ok = SHA512.TryHashData(Abc, dest, out int written);
        Assert.That(ok, Is.True);
        Assert.That(written, Is.EqualTo(64));
        Assert.That(dest.ToArray(), Is.EqualTo(expected));
    }

    [Test]
    public void SHA512_224HashDataMatchesKnownVector()
    {
        // NIST FIPS 180-4 example: SHA-512/224("abc")
        byte[] expected = TestHelpers.FromHexString(
            "4634270f707b6a54daae7530460842e20e37ed265ceee9a43e8924aa");

        byte[] fromArray = SHA512_224.HashData(Abc);
        Assert.That(fromArray, Is.EqualTo(expected));

        Span<byte> dest = stackalloc byte[28];
        bool ok = SHA512_224.TryHashData(Abc, dest, out int written);
        Assert.That(ok, Is.True);
        Assert.That(written, Is.EqualTo(28));
        Assert.That(dest.ToArray(), Is.EqualTo(expected));
    }

    [Test]
    public void SHA512_256HashDataMatchesKnownVector()
    {
        // NIST FIPS 180-4 example: SHA-512/256("abc")
        byte[] expected = TestHelpers.FromHexString(
            "53048e2681941ef99b2e29b76b4c7dabe4c2d0c634fc6d46e0e2f13107e7af23");

        byte[] fromArray = SHA512_256.HashData(Abc);
        Assert.That(fromArray, Is.EqualTo(expected));

        Span<byte> dest = stackalloc byte[32];
        bool ok = SHA512_256.TryHashData(Abc, dest, out int written);
        Assert.That(ok, Is.True);
        Assert.That(written, Is.EqualTo(32));
        Assert.That(dest.ToArray(), Is.EqualTo(expected));
    }

    // ── SHA-3 ─────────────────────────────────────────────────────────────────

    [Test]
    public void SHA3_256HashDataMatchesKnownVector()
    {
        byte[] expected = TestHelpers.FromHexString(
            "3a985da74fe225b2045c172d6bd390bd855f086e3e9d525b46bfe24511431532");

        byte[] fromArray = SHA3_256.HashData(Abc);
        Assert.That(fromArray, Is.EqualTo(expected));

        Span<byte> dest = stackalloc byte[32];
        bool ok = SHA3_256.TryHashData(Abc, dest, out int written);
        Assert.That(ok, Is.True);
        Assert.That(written, Is.EqualTo(32));
        Assert.That(dest.ToArray(), Is.EqualTo(expected));
    }

    [Test]
    public void SHA3_224HashDataMatchesKnownVector()
    {
        byte[] expected = TestHelpers.FromHexString(
            "e642824c3f8cf24ad09234ee7d3c766fc9a3a5168d0c94ad73b46fdf");

        byte[] fromArray = SHA3_224.HashData(Abc);
        Assert.That(fromArray, Is.EqualTo(expected));

        Span<byte> dest = stackalloc byte[28];
        bool ok = SHA3_224.TryHashData(Abc, dest, out int written);
        Assert.That(ok, Is.True);
        Assert.That(written, Is.EqualTo(28));
        Assert.That(dest.ToArray(), Is.EqualTo(expected));
    }

    [Test]
    public void SHA3_384HashDataMatchesKnownVector()
    {
        byte[] expected = TestHelpers.FromHexString(
            "ec01498288516fc926459f58e2c6ad8df9b473cb0fc08c2596da7cf0e49be4b298d88cea927ac7f539f1edf228376d25");

        byte[] fromArray = SHA3_384.HashData(Abc);
        Assert.That(fromArray, Is.EqualTo(expected));

        Span<byte> dest = stackalloc byte[48];
        bool ok = SHA3_384.TryHashData(Abc, dest, out int written);
        Assert.That(ok, Is.True);
        Assert.That(written, Is.EqualTo(48));
        Assert.That(dest.ToArray(), Is.EqualTo(expected));
    }

    [Test]
    public void SHA3_512HashDataMatchesKnownVector()
    {
        byte[] expected = TestHelpers.FromHexString(
            "b751850b1a57168a5693cd924b6b096e08f621827444f70d884f5d0240d2712e" +
            "10e116e9192af3c91a7ec57647e3934057340b4cf408d5a56592f8274eec53f0");

        byte[] fromArray = SHA3_512.HashData(Abc);
        Assert.That(fromArray, Is.EqualTo(expected));

        Span<byte> dest = stackalloc byte[64];
        bool ok = SHA3_512.TryHashData(Abc, dest, out int written);
        Assert.That(ok, Is.True);
        Assert.That(written, Is.EqualTo(64));
        Assert.That(dest.ToArray(), Is.EqualTo(expected));
    }

    // ── Keccak ────────────────────────────────────────────────────────────────

    [Test]
    public void Keccak256HashDataMatchesKnownVector()
    {
        // Keccak-256("abc") — original Keccak, not SHA3
        byte[] expected = TestHelpers.FromHexString(
            "4e03657aea45a94fc7d47ba826c8d667c0d1e6e33a64a036ec44f58fa12d6c45");

        byte[] fromArray = Keccak256.HashData(Abc);
        Assert.That(fromArray, Is.EqualTo(expected));

        Span<byte> dest = stackalloc byte[32];
        bool ok = Keccak256.TryHashData(Abc, dest, out int written);
        Assert.That(ok, Is.True);
        Assert.That(written, Is.EqualTo(32));
        Assert.That(dest.ToArray(), Is.EqualTo(expected));
    }

    [Test]
    public void Keccak384HashDataMatchesKnownVector()
    {
        byte[] expected = TestHelpers.FromHexString(
            "f7df1165f033337be098e7d288ad6a2f74409d7a60b49c36642218de161b1f99" +
            "f8c681e4afaf31a34db29fb763e3c28e");

        byte[] fromArray = Keccak384.HashData(Abc);
        Assert.That(fromArray, Is.EqualTo(expected));

        Span<byte> dest = stackalloc byte[48];
        bool ok = Keccak384.TryHashData(Abc, dest, out int written);
        Assert.That(ok, Is.True);
        Assert.That(written, Is.EqualTo(48));
        Assert.That(dest.ToArray(), Is.EqualTo(expected));
    }

    [Test]
    public void Keccak512HashDataMatchesKnownVector()
    {
        byte[] expected = TestHelpers.FromHexString(
            "18587dc2ea106b9a1563e32b3312421ca164c7f1f07bc922a9c83d77cea3a1e5" +
            "d0c69910739025372dc14ac9642629379540c17e2a65b19d77aa511a9d00bb96");

        byte[] fromArray = Keccak512.HashData(Abc);
        Assert.That(fromArray, Is.EqualTo(expected));

        Span<byte> dest = stackalloc byte[64];
        bool ok = Keccak512.TryHashData(Abc, dest, out int written);
        Assert.That(ok, Is.True);
        Assert.That(written, Is.EqualTo(64));
        Assert.That(dest.ToArray(), Is.EqualTo(expected));
    }

    // ── SHAKE / TurboSHAKE / KT (default output sizes) ───────────────────────

    [Test]
    public void Shake128HashDataDefaultOutputMatchesInstance()
    {
        using var instance = Shake128.Create();
        byte[] expected = instance.ComputeHash(Abc);

        byte[] fromArray = Shake128.HashData(Abc);
        Assert.That(fromArray, Is.EqualTo(expected));

        Span<byte> dest = stackalloc byte[expected.Length];
        bool ok = Shake128.TryHashData(Abc, dest, out int written);
        Assert.That(ok, Is.True);
        Assert.That(written, Is.EqualTo(expected.Length));
        Assert.That(dest.ToArray(), Is.EqualTo(expected));
    }

    [Test]
    public void Shake256HashDataDefaultOutputMatchesInstance()
    {
        using var instance = Shake256.Create();
        byte[] expected = instance.ComputeHash(Abc);

        byte[] fromArray = Shake256.HashData(Abc);
        Assert.That(fromArray, Is.EqualTo(expected));

        Span<byte> dest = stackalloc byte[expected.Length];
        bool ok = Shake256.TryHashData(Abc, dest, out int written);
        Assert.That(ok, Is.True);
        Assert.That(written, Is.EqualTo(expected.Length));
        Assert.That(dest.ToArray(), Is.EqualTo(expected));
    }

    [Test]
    public void TurboShake128HashDataDefaultOutputMatchesInstance()
    {
        using var instance = TurboShake128.Create();
        byte[] expected = instance.ComputeHash(Abc);

        byte[] fromArray = TurboShake128.HashData(Abc);
        Assert.That(fromArray, Is.EqualTo(expected));

        Span<byte> dest = stackalloc byte[expected.Length];
        bool ok = TurboShake128.TryHashData(Abc, dest, out int written);
        Assert.That(ok, Is.True);
        Assert.That(written, Is.EqualTo(expected.Length));
        Assert.That(dest.ToArray(), Is.EqualTo(expected));
    }

    [Test]
    public void TurboShake256HashDataDefaultOutputMatchesInstance()
    {
        using var instance = TurboShake256.Create();
        byte[] expected = instance.ComputeHash(Abc);

        byte[] fromArray = TurboShake256.HashData(Abc);
        Assert.That(fromArray, Is.EqualTo(expected));

        Span<byte> dest = stackalloc byte[expected.Length];
        bool ok = TurboShake256.TryHashData(Abc, dest, out int written);
        Assert.That(ok, Is.True);
        Assert.That(written, Is.EqualTo(expected.Length));
        Assert.That(dest.ToArray(), Is.EqualTo(expected));
    }

    [Test]
    public void KT128HashDataDefaultOutputMatchesInstance()
    {
        using var instance = KT128.Create();
        byte[] expected = instance.ComputeHash(Abc);

        byte[] fromArray = KT128.HashData(Abc);
        Assert.That(fromArray, Is.EqualTo(expected));

        Span<byte> dest = stackalloc byte[expected.Length];
        bool ok = KT128.TryHashData(Abc, dest, out int written);
        Assert.That(ok, Is.True);
        Assert.That(written, Is.EqualTo(expected.Length));
        Assert.That(dest.ToArray(), Is.EqualTo(expected));
    }

    [Test]
    public void KT256HashDataDefaultOutputMatchesInstance()
    {
        using var instance = KT256.Create();
        byte[] expected = instance.ComputeHash(Abc);

        byte[] fromArray = KT256.HashData(Abc);
        Assert.That(fromArray, Is.EqualTo(expected));

        Span<byte> dest = stackalloc byte[expected.Length];
        bool ok = KT256.TryHashData(Abc, dest, out int written);
        Assert.That(ok, Is.True);
        Assert.That(written, Is.EqualTo(expected.Length));
        Assert.That(dest.ToArray(), Is.EqualTo(expected));
    }

    // ── BLAKE ─────────────────────────────────────────────────────────────────

    [Test]
    public void Blake2bHashDataMatchesInstance()
    {
        using var instance = Blake2b.Create();
        byte[] expected = instance.ComputeHash(Abc);

        byte[] fromArray = Blake2b.HashData(Abc);
        Assert.That(fromArray, Is.EqualTo(expected));

        Span<byte> dest = stackalloc byte[64];
        bool ok = Blake2b.TryHashData(Abc, dest, out int written);
        Assert.That(ok, Is.True);
        Assert.That(written, Is.EqualTo(64));
        Assert.That(dest.ToArray(), Is.EqualTo(expected));
    }

    [Test]
    public void Blake2sHashDataMatchesInstance()
    {
        using var instance = Blake2s.Create();
        byte[] expected = instance.ComputeHash(Abc);

        byte[] fromArray = Blake2s.HashData(Abc);
        Assert.That(fromArray, Is.EqualTo(expected));

        Span<byte> dest = stackalloc byte[32];
        bool ok = Blake2s.TryHashData(Abc, dest, out int written);
        Assert.That(ok, Is.True);
        Assert.That(written, Is.EqualTo(32));
        Assert.That(dest.ToArray(), Is.EqualTo(expected));
    }

    [Test]
    public void Blake3HashDataMatchesInstance()
    {
        using var instance = Blake3.Create();
        byte[] expected = instance.ComputeHash(Abc);

        byte[] fromArray = Blake3.HashData(Abc);
        Assert.That(fromArray, Is.EqualTo(expected));

        Span<byte> dest = stackalloc byte[32];
        bool ok = Blake3.TryHashData(Abc, dest, out int written);
        Assert.That(ok, Is.True);
        Assert.That(written, Is.EqualTo(32));
        Assert.That(dest.ToArray(), Is.EqualTo(expected));
    }

    // ── Ascon ─────────────────────────────────────────────────────────────────

    [Test]
    public void AsconHash256HashDataMatchesInstance()
    {
        using var instance = AsconHash256.Create();
        byte[] expected = instance.ComputeHash(Abc);

        byte[] fromArray = AsconHash256.HashData(Abc);
        Assert.That(fromArray, Is.EqualTo(expected));

        Span<byte> dest = stackalloc byte[32];
        bool ok = AsconHash256.TryHashData(Abc, dest, out int written);
        Assert.That(ok, Is.True);
        Assert.That(written, Is.EqualTo(32));
        Assert.That(dest.ToArray(), Is.EqualTo(expected));
    }

    [Test]
    public void AsconXof128HashDataDefaultOutputMatchesInstance()
    {
        using var instance = AsconXof128.Create();
        byte[] expected = instance.ComputeHash(Abc);

        byte[] fromArray = AsconXof128.HashData(Abc);
        Assert.That(fromArray, Is.EqualTo(expected));

        Span<byte> dest = stackalloc byte[expected.Length];
        bool ok = AsconXof128.TryHashData(Abc, dest, out int written);
        Assert.That(ok, Is.True);
        Assert.That(written, Is.EqualTo(expected.Length));
        Assert.That(dest.ToArray(), Is.EqualTo(expected));
    }

    // ── RIPEMD-160 ────────────────────────────────────────────────────────────

    [Test]
    public void Ripemd160HashDataMatchesKnownVector()
    {
        // RIPEMD-160("abc")
        byte[] expected = TestHelpers.FromHexString(
            "8eb208f7e05d987a9b044a8e98c6b087f15a0bfc");

        byte[] fromArray = Ripemd160.HashData(Abc);
        Assert.That(fromArray, Is.EqualTo(expected));

        Span<byte> dest = stackalloc byte[20];
        bool ok = Ripemd160.TryHashData(Abc, dest, out int written);
        Assert.That(ok, Is.True);
        Assert.That(written, Is.EqualTo(20));
        Assert.That(dest.ToArray(), Is.EqualTo(expected));
    }

    // ── SM3 ───────────────────────────────────────────────────────────────────

    [Test]
    public void SM3HashDataMatchesInstance()
    {
        using var instance = SM3.Create();
        byte[] expected = instance.ComputeHash(Abc);

        byte[] fromArray = SM3.HashData(Abc);
        Assert.That(fromArray, Is.EqualTo(expected));

        Span<byte> dest = stackalloc byte[32];
        bool ok = SM3.TryHashData(Abc, dest, out int written);
        Assert.That(ok, Is.True);
        Assert.That(written, Is.EqualTo(32));
        Assert.That(dest.ToArray(), Is.EqualTo(expected));
    }

    // ── Whirlpool ─────────────────────────────────────────────────────────────

    [Test]
    public void WhirlpoolHashDataMatchesInstance()
    {
        using var instance = Whirlpool.Create();
        byte[] expected = instance.ComputeHash(Abc);

        byte[] fromArray = Whirlpool.HashData(Abc);
        Assert.That(fromArray, Is.EqualTo(expected));

        Span<byte> dest = stackalloc byte[64];
        bool ok = Whirlpool.TryHashData(Abc, dest, out int written);
        Assert.That(ok, Is.True);
        Assert.That(written, Is.EqualTo(64));
        Assert.That(dest.ToArray(), Is.EqualTo(expected));
    }

    // ── Streebog ──────────────────────────────────────────────────────────────

    [Test]
    public void Streebog256HashDataMatchesKnownVector()
    {
        // RFC 6986 M1 Streebog-256
        byte[] input = TestHelpers.FromHexString(
            "3031323334353637383930313233343536373839303132333435363738393031" +
            "32333435363738393031323334353637383930313233343536373839303132");
        byte[] expected = TestHelpers.FromHexString(
            "9d151eefd8590b89daa6ba6cb74af9275dd051026bb149a452fd84e5e57b5500");

        byte[] fromArray = Streebog.HashData(input, 32);
        Assert.That(fromArray, Is.EqualTo(expected));

        Span<byte> dest = stackalloc byte[32];
        bool ok = Streebog.TryHashData(input, dest, 32, out int written);
        Assert.That(ok, Is.True);
        Assert.That(written, Is.EqualTo(32));
        Assert.That(dest.ToArray(), Is.EqualTo(expected));
    }

    [Test]
    public void Streebog512HashDataMatchesKnownVector()
    {
        // RFC 6986 M1 Streebog-512
        byte[] input = TestHelpers.FromHexString(
            "3031323334353637383930313233343536373839303132333435363738393031" +
            "32333435363738393031323334353637383930313233343536373839303132");
        byte[] expected = TestHelpers.FromHexString(
            "1b54d01a4af5b9d5cc3d86d68d285462b19abc2475222f35c085122be4ba1ffa" +
            "00ad30f8767b3a82384c6574f024c311e2a481332b08ef7f41797891c1646f48");

        byte[] fromArray = Streebog.HashData(input, 64);
        Assert.That(fromArray, Is.EqualTo(expected));

        Span<byte> dest = stackalloc byte[64];
        bool ok = Streebog.TryHashData(input, dest, 64, out int written);
        Assert.That(ok, Is.True);
        Assert.That(written, Is.EqualTo(64));
        Assert.That(dest.ToArray(), Is.EqualTo(expected));
    }

    [Test]
    public void StreebogHashDataInvalidSizeThrows()
    {
        Assert.Throws<ArgumentException>(() => Streebog.HashData(Abc, 16));
        Assert.Throws<ArgumentException>(() => {
            Span<byte> buf = stackalloc byte[16];
            Streebog.TryHashData(Abc, buf, 16, out _);
        });
    }

    // ── Kupyna ────────────────────────────────────────────────────────────────

    [Test]
    public void Kupyna256HashDataMatchesInstance()
    {
        using var instance = Kupyna.Create(32);
        byte[] expected = instance.ComputeHash(Abc);

        byte[] fromArray = Kupyna.HashData(Abc, 32);
        Assert.That(fromArray, Is.EqualTo(expected));

        Span<byte> dest = stackalloc byte[32];
        bool ok = Kupyna.TryHashData(Abc, dest, 32, out int written);
        Assert.That(ok, Is.True);
        Assert.That(written, Is.EqualTo(32));
        Assert.That(dest.ToArray(), Is.EqualTo(expected));
    }

    [Test]
    public void Kupyna512HashDataMatchesInstance()
    {
        using var instance = Kupyna.Create(64);
        byte[] expected = instance.ComputeHash(Abc);

        byte[] fromArray = Kupyna.HashData(Abc, 64);
        Assert.That(fromArray, Is.EqualTo(expected));

        Span<byte> dest = stackalloc byte[64];
        bool ok = Kupyna.TryHashData(Abc, dest, 64, out int written);
        Assert.That(ok, Is.True);
        Assert.That(written, Is.EqualTo(64));
        Assert.That(dest.ToArray(), Is.EqualTo(expected));
    }

    [Test]
    public void KupynaHashDataInvalidSizeThrows()
    {
        Assert.Throws<ArgumentException>(() => Kupyna.HashData(Abc, 20));
        Assert.Throws<ArgumentException>(() => {
            Span<byte> buf = stackalloc byte[20];
            Kupyna.TryHashData(Abc, buf, 20, out _);
        });
    }

    // ── LSH-256 ───────────────────────────────────────────────────────────────

    [Test]
    public void Lsh256HashDataMatchesInstance()
    {
        using var instance = Lsh256.Create(32);
        byte[] expected = instance.ComputeHash(Abc);

        byte[] fromArray = Lsh256.HashData(Abc, 32);
        Assert.That(fromArray, Is.EqualTo(expected));

        Span<byte> dest = stackalloc byte[32];
        bool ok = Lsh256.TryHashData(Abc, dest, 32, out int written);
        Assert.That(ok, Is.True);
        Assert.That(written, Is.EqualTo(32));
        Assert.That(dest.ToArray(), Is.EqualTo(expected));
    }

    [Test]
    public void Lsh256_224HashDataMatchesInstance()
    {
        using var instance = Lsh256.Create(28);
        byte[] expected = instance.ComputeHash(Abc);

        byte[] fromArray = Lsh256.HashData(Abc, 28);
        Assert.That(fromArray, Is.EqualTo(expected));

        Span<byte> dest = stackalloc byte[28];
        bool ok = Lsh256.TryHashData(Abc, dest, 28, out int written);
        Assert.That(ok, Is.True);
        Assert.That(written, Is.EqualTo(28));
        Assert.That(dest.ToArray(), Is.EqualTo(expected));
    }

    [Test]
    public void Lsh256HashDataInvalidSizeThrows()
    {
        Assert.Throws<ArgumentException>(() => Lsh256.HashData(Abc, 20));
    }

    // ── LSH-512 ───────────────────────────────────────────────────────────────

    [Test]
    public void Lsh512HashDataMatchesInstance()
    {
        using var instance = Lsh512.Create(64);
        byte[] expected = instance.ComputeHash(Abc);

        byte[] fromArray = Lsh512.HashData(Abc, 64);
        Assert.That(fromArray, Is.EqualTo(expected));

        Span<byte> dest = stackalloc byte[64];
        bool ok = Lsh512.TryHashData(Abc, dest, 64, out int written);
        Assert.That(ok, Is.True);
        Assert.That(written, Is.EqualTo(64));
        Assert.That(dest.ToArray(), Is.EqualTo(expected));
    }

    [Test]
    public void Lsh512_384HashDataMatchesInstance()
    {
        using var instance = Lsh512.Create(48);
        byte[] expected = instance.ComputeHash(Abc);

        byte[] fromArray = Lsh512.HashData(Abc, 48);
        Assert.That(fromArray, Is.EqualTo(expected));

        Span<byte> dest = stackalloc byte[48];
        bool ok = Lsh512.TryHashData(Abc, dest, 48, out int written);
        Assert.That(ok, Is.True);
        Assert.That(written, Is.EqualTo(48));
        Assert.That(dest.ToArray(), Is.EqualTo(expected));
    }

    [Test]
    public void Lsh512HashDataInvalidSizeThrows()
    {
        Assert.Throws<ArgumentException>(() => Lsh512.HashData(Abc, 20));
    }

    // ── Legacy ────────────────────────────────────────────────────────────────

    [Test]
#pragma warning disable CS0618 // Type or member is obsolete
    public void MD5HashDataMatchesKnownVector()
    {
        // MD5("abc")
        byte[] expected = TestHelpers.FromHexString("900150983cd24fb0d6963f7d28e17f72");

        byte[] fromArray = MD5.HashData(Abc);
        Assert.That(fromArray, Is.EqualTo(expected));

        Span<byte> dest = stackalloc byte[16];
        bool ok = MD5.TryHashData(Abc, dest, out int written);
        Assert.That(ok, Is.True);
        Assert.That(written, Is.EqualTo(16));
        Assert.That(dest.ToArray(), Is.EqualTo(expected));
    }
#pragma warning restore CS0618

    [Test]
#pragma warning disable CS0618 // Type or member is obsolete
    public void SHA1HashDataMatchesKnownVector()
    {
        // SHA-1("abc")
        byte[] expected = TestHelpers.FromHexString("a9993e364706816aba3e25717850c26c9cd0d89d");

        byte[] fromArray = SHA1.HashData(Abc);
        Assert.That(fromArray, Is.EqualTo(expected));

        Span<byte> dest = stackalloc byte[20];
        bool ok = SHA1.TryHashData(Abc, dest, out int written);
        Assert.That(ok, Is.True);
        Assert.That(written, Is.EqualTo(20));
        Assert.That(dest.ToArray(), Is.EqualTo(expected));
    }
#pragma warning restore CS0618

    // ── Boundary conditions ───────────────────────────────────────────────────

    [Test]
    public void TryHashDataReturnsFalseWhenDestinationTooSmall()
    {
        Span<byte> tooSmall = stackalloc byte[31]; // SHA-256 needs 32
        bool ok = SHA256.TryHashData(Abc, tooSmall, out int written);
        Assert.That(ok, Is.False);
        Assert.That(written, Is.EqualTo(0));
    }

    [Test]
    public void TryHashDataReturnsFalseWhenDestinationEmpty()
    {
        bool ok = SHA256.TryHashData(Abc, Span<byte>.Empty, out int written);
        Assert.That(ok, Is.False);
        Assert.That(written, Is.EqualTo(0));
    }

    [Test]
    public void HashDataEmptyInputProducesCorrectDigest()
    {
        // SHA-256 of empty string
        byte[] expected = TestHelpers.FromHexString(
            "e3b0c44298fc1c149afbf4c8996fb92427ae41e4649b934ca495991b7852b855");

        byte[] result = SHA256.HashData(Empty);
        Assert.That(result, Is.EqualTo(expected));
    }

    // ── Pooling correctness — sequential reuse ────────────────────────────────

    [Test]
    public void PooledInstanceProducesConsistentResultsAcrossMultipleCalls()
    {
        // Calling HashData 10 times must always return the same digest,
        // verifying that TryReset() correctly reinitialises the pooled instance.
        byte[] first = SHA256.HashData(Abc);

        for (int i = 0; i < 9; i++)
        {
            byte[] next = SHA256.HashData(Abc);
            Assert.That(next, Is.EqualTo(first), $"Call {i + 2} produced a different digest");
        }
    }

    [Test]
    public void PooledInstanceProducesConsistentResultsForParameterisedAlgorithm()
    {
        byte[] first = Streebog.HashData(Abc, 32);

        for (int i = 0; i < 9; i++)
        {
            byte[] next = Streebog.HashData(Abc, 32);
            Assert.That(next, Is.EqualTo(first), $"Streebog-256 call {i + 2} produced a different digest");
        }
    }

    [Test]
    public void PooledInstancesFromDifferentVariantsDoNotInterfere()
    {
        // Streebog-256 and Streebog-512 pools are independent; mixing calls must not corrupt results.
        using var ref256 = Streebog.Create(32);
        using var ref512 = Streebog.Create(64);
        byte[] expected256 = ref256.ComputeHash(Abc);
        byte[] expected512 = ref512.ComputeHash(Abc);

        for (int i = 0; i < 5; i++)
        {
            Assert.That(Streebog.HashData(Abc, 32), Is.EqualTo(expected256));
            Assert.That(Streebog.HashData(Abc, 64), Is.EqualTo(expected512));
        }
    }

    [Test]
    public void HashDataAndTryHashDataProduceIdenticalResults()
    {
        // Cross-verify the two overloads for every family representative.
        byte[] sha256Array = SHA256.HashData(Abc);
        Span<byte> sha256Span = stackalloc byte[32];
        SHA256.TryHashData(Abc, sha256Span, out _);
        Assert.That(sha256Span.ToArray(), Is.EqualTo(sha256Array));

        byte[] blake3Array = Blake3.HashData(Abc);
        Span<byte> blake3Span = stackalloc byte[32];
        Blake3.TryHashData(Abc, blake3Span, out _);
        Assert.That(blake3Span.ToArray(), Is.EqualTo(blake3Array));

        byte[] kupyna256Array = Kupyna.HashData(Abc, 32);
        Span<byte> kupyna256Span = stackalloc byte[32];
        Kupyna.TryHashData(Abc, kupyna256Span, 32, out _);
        Assert.That(kupyna256Span.ToArray(), Is.EqualTo(kupyna256Array));
    }

    // ── ReadOnlySequence overloads ────────────────────────────────────────────

    private static ReadOnlySequence<byte> BuildMultiSegmentSequence(byte[] data, int segmentSize)
    {
        // Split data into fixed-size segments linked via BufferSegment chain.
        BufferSegment? first = null;
        BufferSegment? last = null;
        for (int offset = 0; offset < data.Length; offset += segmentSize)
        {
            int length = Math.Min(segmentSize, data.Length - offset);
            var seg = new BufferSegment(data.AsMemory(offset, length));
            if (first is null)
            {
                first = last = seg;
            }
            else
            {
                last = last!.Append(seg);
            }
        }
        if (first is null)
            return ReadOnlySequence<byte>.Empty;
        return new ReadOnlySequence<byte>(first, 0, last!, last!.Memory.Length);
    }

    private sealed class BufferSegment : ReadOnlySequenceSegment<byte>
    {
        public BufferSegment(ReadOnlyMemory<byte> memory)
        {
            Memory = memory;
        }

        public BufferSegment Append(BufferSegment next)
        {
            next.RunningIndex = RunningIndex + Memory.Length;
            Next = next;
            return next;
        }
    }

    [Test]
    public void ReadOnlySequenceSingleSegmentMatchesSpanOverload()
    {
        ReadOnlySequence<byte> seq = new(Abc);

        Assert.That(SHA256.HashData(seq), Is.EqualTo(SHA256.HashData(Abc.AsSpan())));
        Assert.That(SHA512.HashData(seq), Is.EqualTo(SHA512.HashData(Abc.AsSpan())));
        Assert.That(Blake3.HashData(seq), Is.EqualTo(Blake3.HashData(Abc.AsSpan())));
        Assert.That(SM3.HashData(seq), Is.EqualTo(SM3.HashData(Abc.AsSpan())));
        Assert.That(Streebog.HashData(seq, 32), Is.EqualTo(Streebog.HashData(Abc.AsSpan(), 32)));
        Assert.That(Kupyna.HashData(seq, 32), Is.EqualTo(Kupyna.HashData(Abc.AsSpan(), 32)));
        Assert.That(Lsh256.HashData(seq, 32), Is.EqualTo(Lsh256.HashData(Abc.AsSpan(), 32)));
        Assert.That(Lsh512.HashData(seq, 64), Is.EqualTo(Lsh512.HashData(Abc.AsSpan(), 64)));
    }

    [Test]
    public void ReadOnlySequenceMultiSegmentMatchesSpanOverload()
    {
        byte[] data = Encoding.ASCII.GetBytes("The quick brown fox jumps over the lazy dog");
        ReadOnlySequence<byte> seq = BuildMultiSegmentSequence(data, 8);

        Assert.That(SHA256.HashData(seq), Is.EqualTo(SHA256.HashData(data.AsSpan())));
        Assert.That(Blake3.HashData(seq), Is.EqualTo(Blake3.HashData(data.AsSpan())));
        Assert.That(Whirlpool.HashData(seq), Is.EqualTo(Whirlpool.HashData(data.AsSpan())));
        Assert.That(Ripemd160.HashData(seq), Is.EqualTo(Ripemd160.HashData(data.AsSpan())));
        Assert.That(AsconHash256.HashData(seq), Is.EqualTo(AsconHash256.HashData(data.AsSpan())));
    }

    [Test]
    public void ReadOnlySequenceTryHashDataWritesCorrectBytes()
    {
        byte[] data = Encoding.ASCII.GetBytes("abc");
        ReadOnlySequence<byte> seq = BuildMultiSegmentSequence(data, 1);

        Span<byte> dest = stackalloc byte[32];
        bool ok = SHA256.TryHashData(seq, dest, out int written);
        Assert.That(ok, Is.True);
        Assert.That(written, Is.EqualTo(32));
        Assert.That(dest.ToArray(), Is.EqualTo(SHA256.HashData(data.AsSpan())));
    }

    [Test]
    public void ReadOnlySequenceEmptyInputMatchesSpanOverload()
    {
        ReadOnlySequence<byte> emptySeq = ReadOnlySequence<byte>.Empty;

        Assert.That(SHA256.HashData(emptySeq), Is.EqualTo(SHA256.HashData(ReadOnlySpan<byte>.Empty)));
        Assert.That(Blake3.HashData(emptySeq), Is.EqualTo(Blake3.HashData(ReadOnlySpan<byte>.Empty)));
        Assert.That(Streebog.HashData(emptySeq, 64), Is.EqualTo(Streebog.HashData(ReadOnlySpan<byte>.Empty, 64)));
    }
}
