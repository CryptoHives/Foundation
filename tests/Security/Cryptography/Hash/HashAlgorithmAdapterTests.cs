// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace Cryptography.Tests.Hash;

using Cryptography.Tests.Adapter.Hash;
using NUnit.Framework;
using System;
using System.Security.Cryptography;

/// <summary>
/// Tests for <see cref="HashAlgorithmAdapter"/>, which presents an in-box
/// <see cref="HashAlgorithm"/> through the CryptoHives base type so callers can hold one
/// algorithm type for every implementation.
/// </summary>
[TestFixture]
public class HashAlgorithmAdapterTests
{
    private static readonly int[] Sizes = [0, 1, 63, 64, 65, 1000, 8192, 100000];

    private static byte[] Data(int size)
    {
        byte[] data = new byte[size];
        new Random(0x43727970).NextBytes(data);
        return data;
    }

    private static byte[] Expected(byte[] data)
    {
#if NET5_0_OR_GREATER
        return SHA256.HashData(data);
#else
        using var sha256 = SHA256.Create();
        return sha256.ComputeHash(data);
#endif
    }

    /// <summary>
    /// The one-shot path produces the same digest as the wrapped algorithm.
    /// </summary>
    /// <param name="size">The input size in bytes.</param>
    [Test]
    public void TryComputeHashMatchesTheWrappedAlgorithm([ValueSource(nameof(Sizes))] int size)
    {
        byte[] data = Data(size);
        using var adapter = new HashAlgorithmAdapter(SHA256.Create());

        Span<byte> actual = stackalloc byte[32];
        Assert.That(adapter.TryComputeHash(data, actual, out int bytesWritten), Is.True);
        Assert.That(bytesWritten, Is.EqualTo(32));
        Assert.That(actual.ToArray(), Is.EqualTo(Expected(data)));
    }

    /// <summary>
    /// The streaming path - which has to copy through <c>TransformBlock</c>, since the in-box
    /// type exposes no span-based append - agrees with the one-shot.
    /// </summary>
    /// <param name="size">The input size in bytes.</param>
    [Test]
    public void StreamingMatchesTheWrappedAlgorithm([ValueSource(nameof(Sizes))] int size)
    {
        byte[] data = Data(size);
        using var adapter = new HashAlgorithmAdapter(SHA256.Create());

        for (int offset = 0; offset < data.Length; offset += 97)
        {
            adapter.AppendData(data.AsSpan(offset, Math.Min(97, data.Length - offset)));
        }

        Span<byte> actual = stackalloc byte[32];
        Assert.That(adapter.TryGetHashAndReset(actual, out int bytesWritten), Is.True);
        Assert.That(bytesWritten, Is.EqualTo(32));
        Assert.That(actual.ToArray(), Is.EqualTo(Expected(data)));
    }

    /// <summary>
    /// A one-shot must still cover data already appended to the instance, per the base class
    /// contract, rather than silently dropping it.
    /// </summary>
    [Test]
    public void TryComputeHashHonoursPendingAppendedData()
    {
        byte[] data = Data(1000);
        using var adapter = new HashAlgorithmAdapter(SHA256.Create());

        adapter.AppendData(data.AsSpan(0, 400));

        Span<byte> actual = stackalloc byte[32];
        Assert.That(adapter.TryComputeHash(data.AsSpan(400), actual, out _), Is.True);
        Assert.That(actual.ToArray(), Is.EqualTo(Expected(data)));
    }

    /// <summary>
    /// Both finalizing paths reset the instance, so it can be reused without an explicit
    /// <see cref="HashAlgorithm.Initialize"/>.
    /// </summary>
    [Test]
    public void FinalizingResetsForReuse()
    {
        byte[] first = Data(1000);
        byte[] second = Data(64);
        using var adapter = new HashAlgorithmAdapter(SHA256.Create());

        Span<byte> actual = stackalloc byte[32];
        Assert.That(adapter.TryComputeHash(first, actual, out _), Is.True);
        Assert.That(actual.ToArray(), Is.EqualTo(Expected(first)));

        adapter.AppendData(second);
        Assert.That(adapter.TryGetHashAndReset(actual, out _), Is.True);
        Assert.That(actual.ToArray(), Is.EqualTo(Expected(second)));

        Assert.That(adapter.TryComputeHash(first, actual, out _), Is.True);
        Assert.That(actual.ToArray(), Is.EqualTo(Expected(first)));
    }

    /// <summary>
    /// The in-box <c>ComputeHash</c> inherited from the base class routes through the adapter.
    /// </summary>
    [Test]
    public void ComputeHashMatchesTheWrappedAlgorithm()
    {
        byte[] data = Data(1000);
        using var adapter = new HashAlgorithmAdapter(SHA256.Create());

        Assert.That(adapter.ComputeHash(data), Is.EqualTo(Expected(data)));
    }

#if NET5_0_OR_GREATER
    /// <summary>
    /// An optional static one-shot is used in place of the instance path, and agrees with it.
    /// </summary>
    [Test]
    public void SuppliedOneShotMatchesTheInstancePath()
    {
        byte[] data = Data(1000);
        using var adapter = new HashAlgorithmAdapter(SHA256.Create(), "SHA-256", oneShot: SHA256.HashData);

        Span<byte> actual = stackalloc byte[32];
        Assert.That(adapter.TryComputeHash(data, actual, out int bytesWritten), Is.True);
        Assert.That(bytesWritten, Is.EqualTo(32));
        Assert.That(actual.ToArray(), Is.EqualTo(Expected(data)));

        // Pending state disqualifies the static one-shot; the instance path must take over.
        adapter.AppendData(data.AsSpan(0, 400));
        Assert.That(adapter.TryComputeHash(data.AsSpan(400), actual, out _), Is.True);
        Assert.That(actual.ToArray(), Is.EqualTo(Expected(data)));
    }
#endif

    /// <summary>
    /// A destination too small for the digest is reported, not truncated into.
    /// </summary>
    [Test]
    public void ShortDestinationReturnsFalse()
    {
        byte[] data = Data(64);
        using var adapter = new HashAlgorithmAdapter(SHA256.Create());

        Span<byte> tooShort = stackalloc byte[31];
        Assert.That(adapter.TryComputeHash(data, tooShort, out int bytesWritten), Is.False);
        Assert.That(bytesWritten, Is.Zero);
    }

    /// <summary>
    /// The metadata the CryptoHives base type adds is inferred from the wrapped instance.
    /// </summary>
    [Test]
    public void MetadataIsInferredFromTheWrappedAlgorithm()
    {
        using (var sha256 = new HashAlgorithmAdapter(SHA256.Create()))
        {
            Assert.That(sha256.AlgorithmName, Is.EqualTo("SHA256"));
            Assert.That(sha256.BlockSize, Is.EqualTo(64));
            Assert.That(sha256.HashSize, Is.EqualTo(256));
        }

        using (var sha512 = new HashAlgorithmAdapter(SHA512.Create()))
        {
            Assert.That(sha512.AlgorithmName, Is.EqualTo("SHA512"));
            Assert.That(sha512.BlockSize, Is.EqualTo(128));
            Assert.That(sha512.HashSize, Is.EqualTo(512));
        }

        using var named = new HashAlgorithmAdapter(SHA256.Create(), "SHA-256", blockSize: 64);
        Assert.That(named.AlgorithmName, Is.EqualTo("SHA-256"));
        Assert.That(named.BlockSize, Is.EqualTo(64));
    }

    /// <summary>
    /// Disposing the adapter disposes the instance it took ownership of.
    /// </summary>
    [Test]
    public void DisposeDisposesTheWrappedAlgorithm()
    {
        var inner = SHA256.Create();
        var adapter = new HashAlgorithmAdapter(inner);
        adapter.Dispose();

        Assert.Throws<ObjectDisposedException>(() => inner.ComputeHash(Data(64)));
    }
}
