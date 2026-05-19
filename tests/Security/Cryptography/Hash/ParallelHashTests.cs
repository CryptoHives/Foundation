// SPDX-FileCopyrightText: 2025 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Security.Cryptography.Hash;

using System;
using System.Text;
using NUnit.Framework;

/// <summary>
/// Tests for <see cref="ParallelHash"/> using NIST SP 800-185 sample vectors.
/// </summary>
/// <remarks>
/// Sample values from the NIST SP 800-185 companion document:
/// https://csrc.nist.gov/CSRC/media/Projects/Cryptographic-Standards-and-Guidelines/documents/examples/ParallelHash_samples.pdf
/// </remarks>
[TestFixture, Parallelizable(ParallelScope.All), CancelAfter(30000)]
public class ParallelHashTests
{
    // NIST SP 800-185 sample input data used across multiple test cases.
    private static readonly byte[] SampleData24 = TestHelpers.FromHexString(
        "000102030405060710111213141516172021222324252627");

    private static readonly byte[] SampleData72 = TestHelpers.FromHexString(
        "000102030405060708090A0B" +
        "101112131415161718191A1B" +
        "202122232425262728292A2B" +
        "303132333435363738393A3B" +
        "404142434445464748494A4B" +
        "505152535455565758595A5B");

    // -------------------------------------------------------------------------
    // ParallelHash128 — NIST SP 800-185 Appendix sample vectors
    // -------------------------------------------------------------------------

    /// <summary>
    /// ParallelHash128 Sample 1: empty customization, blockSize=8, 24-byte input.
    /// </summary>
    [Test]
    public void ParallelHash128NistSample1()
    {
        byte[] expected = TestHelpers.FromHexString(
            "BA8DC1D1D979331D3F813603C67F72609AB5E44B94A0B8F9AF46514454A2B4F5");
        byte[] output = new byte[32];

        ParallelHash.ComputeHash128(output, SampleData24, blockSizeBytes: 8);

        Assert.That(output, Is.EqualTo(expected));
    }

    /// <summary>
    /// ParallelHash128 Sample 2: customization="Parallel Data", blockSize=8, 24-byte input.
    /// </summary>
    [Test]
    public void ParallelHash128NistSample2()
    {
        byte[] expected = TestHelpers.FromHexString(
            "FC484DCB3F84DCEEDC353438151BEE58157D6EFED0445A81F165E495795B7206");
        byte[] output = new byte[32];
        byte[] customization = Encoding.ASCII.GetBytes("Parallel Data");

        ParallelHash.ComputeHash128(output, SampleData24, blockSizeBytes: 8, customization);

        Assert.That(output, Is.EqualTo(expected));
    }

    /// <summary>
    /// ParallelHash128 Sample 3: customization="Parallel Data", blockSize=12, 72-byte input.
    /// </summary>
    [Test]
    public void ParallelHash128NistSample3()
    {
        byte[] expected = TestHelpers.FromHexString(
            "F7FD5312896C6685C828AF7E2ADB97E393E7F8D54E3C2EA4B95E5ACA3796E8FC");
        byte[] output = new byte[32];
        byte[] customization = Encoding.ASCII.GetBytes("Parallel Data");

        ParallelHash.ComputeHash128(output, SampleData72, blockSizeBytes: 12, customization);

        Assert.That(output, Is.EqualTo(expected));
    }

    // -------------------------------------------------------------------------
    // ParallelHash256 — NIST SP 800-185 Appendix sample vectors
    // -------------------------------------------------------------------------

    /// <summary>
    /// ParallelHash256 Sample 1: empty customization, blockSize=8, 24-byte input.
    /// </summary>
    [Test]
    public void ParallelHash256NistSample1()
    {
        byte[] expected = TestHelpers.FromHexString(
            "BC1EF124DA34495E948EAD207DD9842235DA432D2BBC54B4C110E64C451105531B7F2A3E" +
            "0CE055C02805E7C2DE1FB746AF97A1DD01F43B824E31B87612410429");
        byte[] output = new byte[64];

        ParallelHash.ComputeHash256(output, SampleData24, blockSizeBytes: 8);

        Assert.That(output, Is.EqualTo(expected));
    }

    /// <summary>
    /// ParallelHash256 Sample 2: customization="Parallel Data", blockSize=8, 24-byte input.
    /// </summary>
    [Test]
    public void ParallelHash256NistSample2()
    {
        byte[] expected = TestHelpers.FromHexString(
            "CDF15289B54F6212B4BC270528B49526006DD9B54E2B6ADD1EF6900DDA3963BB" +
            "33A72491F236969CA8AFAEA29C682D47A393C065B38E29FAE651A2091C833110");
        byte[] output = new byte[64];
        byte[] customization = Encoding.ASCII.GetBytes("Parallel Data");

        ParallelHash.ComputeHash256(output, SampleData24, blockSizeBytes: 8, customization);

        Assert.That(output, Is.EqualTo(expected));
    }

    /// <summary>
    /// ParallelHash256 Sample 3: customization="Parallel Data", blockSize=12, 72-byte input.
    /// </summary>
    [Test]
    public void ParallelHash256NistSample3()
    {
        byte[] expected = TestHelpers.FromHexString(
            "69D0FCB764EA055DD09334BC6021CB7E4B61348DFF375DA262671CDEC3EFFA8D" +
            "1B4568A6CCE16B1CAD946DDDE27F6CE2B8DEE4CD1B24851EBF00EB90D43813E9");
        byte[] output = new byte[64];
        byte[] customization = Encoding.ASCII.GetBytes("Parallel Data");

        ParallelHash.ComputeHash256(output, SampleData72, blockSizeBytes: 12, customization);

        Assert.That(output, Is.EqualTo(expected));
    }

    // -------------------------------------------------------------------------
    // Incremental API consistency tests
    // -------------------------------------------------------------------------

    /// <summary>
    /// IncrementalParallelHash128 produces same result as static ParallelHash128.
    /// </summary>
    [Test]
    public void IncrementalParallelHash128MatchesStaticApi()
    {
        byte[] expected = new byte[32];
        ParallelHash.ComputeHash128(expected, SampleData24, blockSizeBytes: 8);

        byte[] actual = new byte[32];
        using var incremental = new IncrementalParallelHash(IncrementalParallelHash.ShakeType.Shake128, blockSizeBytes: 8);
        incremental.Absorb(SampleData24);
        incremental.Squeeze(actual);

        Assert.That(actual, Is.EqualTo(expected));
    }

    /// <summary>
    /// IncrementalParallelHash256 produces same result as static ParallelHash256.
    /// </summary>
    [Test]
    public void IncrementalParallelHash256MatchesStaticApi()
    {
        byte[] expected = new byte[64];
        byte[] customization = Encoding.ASCII.GetBytes("Parallel Data");
        ParallelHash.ComputeHash256(expected, SampleData24, blockSizeBytes: 8, customization);

        byte[] actual = new byte[64];
        using var incremental = new IncrementalParallelHash(IncrementalParallelHash.ShakeType.Shake256, blockSizeBytes: 8, customization);
        incremental.Absorb(SampleData24);
        incremental.Squeeze(actual);

        Assert.That(actual, Is.EqualTo(expected));
    }

    /// <summary>
    /// Absorbing data in multiple chunks matches a single-chunk absorb.
    /// </summary>
    [Test]
    public void IncrementalAbsorbInChunksMatchesSingleAbsorb()
    {
        byte[] expected = new byte[32];
        using (var single = new IncrementalParallelHash(blockSizeBytes: 8))
        {
            single.Absorb(SampleData24);
            single.Squeeze(expected);
        }

        byte[] actual = new byte[32];
        using (var chunked = new IncrementalParallelHash(blockSizeBytes: 8))
        {
            chunked.Absorb(SampleData24.AsSpan(0, 12));
            chunked.Absorb(SampleData24.AsSpan(12));
            chunked.Squeeze(actual);
        }

        Assert.That(actual, Is.EqualTo(expected));
    }

    // -------------------------------------------------------------------------
    // Edge case / boundary tests
    // -------------------------------------------------------------------------

    /// <summary>
    /// Empty output span returns without error.
    /// </summary>
    [Test]
    public void EmptyOutputSpanReturnsEmpty()
    {
        var result = ParallelHash.ComputeHash128(Span<byte>.Empty, SampleData24);
        Assert.That(result.Length, Is.EqualTo(0));
    }

    /// <summary>
    /// Zero-length input produces a deterministic result.
    /// </summary>
    [Test]
    public void EmptyInputProducesDeterministicOutput()
    {
        byte[] result1 = new byte[32];
        byte[] result2 = new byte[32];
        ParallelHash.ComputeHash128(result1, ReadOnlySpan<byte>.Empty, blockSizeBytes: 8);
        ParallelHash.ComputeHash128(result2, ReadOnlySpan<byte>.Empty, blockSizeBytes: 8);
        Assert.That(result1, Is.EqualTo(result2));
    }

    /// <summary>
    /// Non-positive block size throws ArgumentOutOfRangeException.
    /// </summary>
    [Test]
    public void ZeroBlockSizeThrows()
    {
        byte[] output = new byte[32];
        Assert.Throws<ArgumentOutOfRangeException>(() =>
            ParallelHash.ComputeHash128(output, SampleData24, blockSizeBytes: 0));
    }

    /// <summary>
    /// Null input byte array throws ArgumentNullException.
    /// </summary>
    [Test]
    public void NullInputThrows()
    {
        Assert.Throws<ArgumentNullException>(() => ParallelHash.ComputeHash128(null!, blockSizeBytes: 8));
    }

    /// <summary>
    /// Input exactly equal to block size (single full block) is handled correctly.
    /// </summary>
    [Test]
    public void SingleFullBlockProducesDeterministicOutput()
    {
        byte[] data = new byte[8];
        for (int i = 0; i < data.Length; i++) data[i] = (byte)i;

        byte[] result1 = new byte[32];
        byte[] result2 = new byte[32];
        ParallelHash.ComputeHash128(result1, data, blockSizeBytes: 8);
        ParallelHash.ComputeHash128(result2, data, blockSizeBytes: 8);
        Assert.That(result1, Is.EqualTo(result2));
    }

    /// <summary>
    /// Input spanning multiple complete blocks is handled correctly.
    /// </summary>
    [Test]
    public void MultipleCompleteBlocksProducesDeterministicOutput()
    {
        byte[] data = new byte[48];
        for (int i = 0; i < data.Length; i++) data[i] = (byte)(i % 256);

        byte[] result1 = new byte[32];
        byte[] result2 = new byte[32];
        ParallelHash.ComputeHash128(result1, data, blockSizeBytes: 8);
        ParallelHash.ComputeHash128(result2, data, blockSizeBytes: 8);
        Assert.That(result1, Is.EqualTo(result2));
    }

    /// <summary>
    /// Reset allows reuse of IncrementalParallelHash instance.
    /// </summary>
    [Test]
    public void IncrementalResetAllowsReuse()
    {
        byte[] expected = new byte[32];
        byte[] actual = new byte[32];

        using var incremental = new IncrementalParallelHash(blockSizeBytes: 8);

        incremental.Absorb(SampleData24);
        incremental.Squeeze(expected);

        incremental.Reset();

        incremental.Absorb(SampleData24);
        incremental.Squeeze(actual);

        Assert.That(actual, Is.EqualTo(expected));
    }

    /// <summary>
    /// Disposed instance throws ObjectDisposedException on Absorb.
    /// </summary>
    [Test]
    public void DisposedInstanceThrowsOnAbsorb()
    {
        var incremental = new IncrementalParallelHash();
        incremental.Dispose();
        Assert.Throws<ObjectDisposedException>(() => incremental.Absorb(SampleData24));
    }

    /// <summary>
    /// Disposed instance throws ObjectDisposedException on Squeeze.
    /// </summary>
    [Test]
    public void DisposedInstanceThrowsOnSqueeze()
    {
        var incremental = new IncrementalParallelHash();
        incremental.Dispose();
        byte[] output = new byte[32];
        Assert.Throws<ObjectDisposedException>(() => incremental.Squeeze(output));
    }
}
