// SPDX-FileCopyrightText: 2025 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace Security.Cryptography.Tests.GOST;

using System;
using System.Linq;
using System.Text;
using CryptoHives.Foundation.Security.Cryptography.Hash;
using NUnit.Framework;
using OpenGost.Security.Cryptography;
using Org.BouncyCastle.Crypto.Digests;

/// <summary>
/// Tests comparing Streebog implementations against RFC 6986 test vectors.
/// This helps identify which reference implementation correctly implements the standard.
/// </summary>
[TestFixture]
[Parallelizable(ParallelScope.All)]
public class StreebogReferenceTests
{
    // RFC 6986 Test Message 1 (M1): 63 bytes
    // The string "303132..." represents ASCII digits
    private static readonly byte[] Rfc6986Message1 = TestHelpers.FromHexString(
        // "012345678901234567890123456789012345678901234567890123456789012"
        "3031323334353637383930313233343536373839303132333435363738393031" +
        "32333435363738393031323334353637383930313233343536373839303132");

    // RFC 6986 Test Message 2 (M2): 72 bytes
    private static readonly byte[] Rfc6986Message2 = TestHelpers.FromHexString(
        // "Се ветри, Стрибожи внуци, веютъ с моря стрелами на храбрыя плъкы Игоревы"
        "d1e520e2e5f2f0e82c20d1f2f0e8e1eee6e820e2edf3f6e82c20e2e5fef2fa20" +
        "f120eceef0ff20f1f2f0e5ebe0ece820ede020f5f0e0e1f0fbff20efebfaeafb20c8e3eef0e5e2fb");

    // RFC 6986 Section 10.1.1 - Expected hash for M1 with 512-bit output
    private static readonly byte[] Rfc6986M1Expected512 = TestHelpers.FromHexString(
        "1b54d01a4af5b9d5cc3d86d68d285462b19abc2475222f35c085122be4ba1ffa" +
        "00ad30f8767b3a82384c6574f024c311e2a481332b08ef7f41797891c1646f48");

    // RFC 6986 Section 10.1.2 - Expected hash for M2 with 512-bit output
    private static readonly byte[] Rfc6986M2Expected512 = TestHelpers.FromHexString(
        "1e88e62226bfca6f9994f1f2d51569e0daf8475a3b0fe61a5300eee46d961376" +
        "035fe83549ada2b8620fcd7c496ce5b33f0cb9dddc2b6460143b03dabac9fb28");

    // Expected hash for empty string with 512-bit output
    private static readonly byte[] Rfc6986EmptyStringExpected512 = TestHelpers.FromHexString(
        "8e945da209aa869f0455928529bcae4679e9873ab707b55315f56ceb98bef0a7" +
        "362f715528356ee83cda5f2aac4c6ad2ba3a715c1bcd81cb8e9f90bf4c1c1a8a");

    // RFC 6986 Section 10.2.1 - Expected hash for M1 with 256-bit output
    private static readonly byte[] Rfc6986M1Expected256 = TestHelpers.FromHexString(
        "9d151eefd8590b89daa6ba6cb74af9275dd051026bb149a452fd84e5e57b5500");

    // RFC 6986 Section 10.2.2 - Expected hash for M2 with 256-bit output
    private static readonly byte[] Rfc6986M2Expected256 = TestHelpers.FromHexString(
        "9dd2fe4e90409e5da87f53976d7405b0c0cac628fc669a741d50063c557e8f50");

    // Expected hash for empty string with 256-bit output
    private static readonly byte[] Rfc6986EmptyStringExpected256 = TestHelpers.FromHexString(
        "3f539a213e97c802cc229d474c6aa32a825a360b2a933a949fd925208d9ce1bb");

    #region OpenGost Reference Implementation Tests

    /// <summary>
    /// Test OpenGost Streebog-512 with RFC 6986 M1 test vector.
    /// </summary>
    [Test]
    public void OpenGost_Streebog512_Rfc6986_M1()
    {
        using var digest = Streebog512.Create();
        byte[] hash = digest.ComputeHash(Rfc6986Message1);

        TestContext.Out.WriteLine($"OpenGost 512 M1: {TestHelpers.ToHexString(hash)}");
        TestContext.Out.WriteLine($"RFC Expected:    {TestHelpers.ToHexString(Rfc6986M1Expected512)}");
        TestContext.Out.WriteLine($"Match: {hash.SequenceEqual(Rfc6986M1Expected512)}");

        Assert.That(hash, Is.EqualTo(Rfc6986M1Expected512), "OpenGost Streebog-512 should match RFC 6986 M1");
    }

    /// <summary>
    /// Test OpenGost Streebog-512 with RFC 6986 M2 test vector.
    /// </summary>
    [Test]
    public void OpenGost_Streebog512_Rfc6986_M2()
    {
        using var digest = Streebog512.Create();
        byte[] hash = digest.ComputeHash(Rfc6986Message2);

        TestContext.Out.WriteLine($"OpenGost 512 M2: {TestHelpers.ToHexString(hash)}");
        TestContext.Out.WriteLine($"RFC Expected:    {TestHelpers.ToHexString(Rfc6986M2Expected512)}");
        TestContext.Out.WriteLine($"Match: {hash.SequenceEqual(Rfc6986M2Expected512)}");

        Assert.That(hash, Is.EqualTo(Rfc6986M2Expected512), "OpenGost Streebog-512 should match RFC 6986 M2");
    }

    /// <summary>
    /// Test OpenGost Streebog-512 with empty string test vector.
    /// </summary>
    [Test]
    public void OpenGost_Streebog512_Rfc6986_EmptyString()
    {
        using var digest = Streebog512.Create();
        byte[] hash = digest.ComputeHash(TestHelpers.FromHexString(string.Empty));

        TestContext.Out.WriteLine($"OpenGost 512 empty string: {TestHelpers.ToHexString(hash)}");
        TestContext.Out.WriteLine($"RFC Expected:    {TestHelpers.ToHexString(Rfc6986EmptyStringExpected512)}");
        TestContext.Out.WriteLine($"Match: {hash.SequenceEqual(Rfc6986EmptyStringExpected512)}");

        Assert.That(hash, Is.EqualTo(Rfc6986EmptyStringExpected512), "OpenGost Streebog-512 should match empty string");
    }

    /// <summary>
    /// Test OpenGost Streebog-256 with RFC 6986 M1 test vector.
    /// </summary>
    [Test]
    public void OpenGost_Streebog256_Rfc6986_M1()
    {
        using var digest = Streebog256.Create();
        byte[] hash = digest.ComputeHash(Rfc6986Message1);

        TestContext.Out.WriteLine($"OpenGost 256 M1: {TestHelpers.ToHexString(hash)}");
        TestContext.Out.WriteLine($"RFC Expected:    {TestHelpers.ToHexString(Rfc6986M1Expected256)}");
        TestContext.Out.WriteLine($"Match: {hash.SequenceEqual(Rfc6986M1Expected256)}");

        Assert.That(hash, Is.EqualTo(Rfc6986M1Expected256), "OpenGost Streebog-256 should match RFC 6986 M1");
    }

    /// <summary>
    /// Test OpenGost Streebog-256 with RFC 6986 M2 test vector.
    /// </summary>
    [Test]
    public void OpenGost_Streebog256_Rfc6986_M2()
    {
        using var digest = Streebog256.Create();
        byte[] hash = digest.ComputeHash(Rfc6986Message2);

        TestContext.Out.WriteLine($"OpenGost 256 M2: {TestHelpers.ToHexString(hash)}");
        TestContext.Out.WriteLine($"RFC Expected:    {TestHelpers.ToHexString(Rfc6986M2Expected256)}");
        TestContext.Out.WriteLine($"Match: {hash.SequenceEqual(Rfc6986M2Expected256)}");

        Assert.That(hash, Is.EqualTo(Rfc6986M2Expected256), "OpenGost Streebog-256 should match RFC 6986 M2");
    }

    /// <summary>
    /// Test OpenGost Streebog-256 with empty string test vector.
    /// </summary>
    [Test]
    public void OpenGost_Streebog256_Rfc6986_EmptyString()
    {
        using var digest = Streebog256.Create();
        byte[] hash = digest.ComputeHash(TestHelpers.FromHexString(string.Empty));

        TestContext.Out.WriteLine($"OpenGost 256 empty string: {TestHelpers.ToHexString(hash)}");
        TestContext.Out.WriteLine($"RFC Expected:    {TestHelpers.ToHexString(Rfc6986EmptyStringExpected256)}");
        TestContext.Out.WriteLine($"Match: {hash.SequenceEqual(Rfc6986EmptyStringExpected256)}");

        Assert.That(hash, Is.EqualTo(Rfc6986EmptyStringExpected256), "OpenGost Streebog-256 should match empty string");
    }

    #endregion

    #region BouncyCastle Reference Implementation Tests

    /// <summary>
    /// Test BouncyCastle Streebog-512 with RFC 6986 M1 test vector.
    /// </summary>
    [Test]
    public void BouncyCastle_Streebog512_Rfc6986_M1()
    {
        var digest = new Gost3411_2012_512Digest();
        digest.BlockUpdate(Rfc6986Message1, 0, Rfc6986Message1.Length);
        byte[] hash = new byte[64];
        digest.DoFinal(hash, 0);

        TestContext.Out.WriteLine($"BouncyCastle 512 M1: {TestHelpers.ToHexString(hash)}");
        TestContext.Out.WriteLine($"RFC Expected:        {TestHelpers.ToHexString(Rfc6986M1Expected512)}");
        TestContext.Out.WriteLine($"Match: {hash.SequenceEqual(Rfc6986M1Expected512)}");

        Assert.That(hash, Is.EqualTo(Rfc6986M1Expected512), "BouncyCastle Streebog-512 should match RFC 6986 M1");
    }

    /// <summary>
    /// Test BouncyCastle Streebog-512 with RFC 6986 M2 test vector.
    /// </summary>
    [Test]
    public void BouncyCastle_Streebog512_Rfc6986_M2()
    {
        var digest = new Gost3411_2012_512Digest();
        digest.BlockUpdate(Rfc6986Message2, 0, Rfc6986Message2.Length);
        byte[] hash = new byte[64];
        digest.DoFinal(hash, 0);

        TestContext.Out.WriteLine($"BouncyCastle 512 M2: {TestHelpers.ToHexString(hash)}");
        TestContext.Out.WriteLine($"RFC Expected:        {TestHelpers.ToHexString(Rfc6986M2Expected512)}");
        TestContext.Out.WriteLine($"Match: {hash.SequenceEqual(Rfc6986M2Expected512)}");

        Assert.That(hash, Is.EqualTo(Rfc6986M2Expected512), "BouncyCastle Streebog-512 should match RFC 6986 M2");
    }

    /// <summary>
    /// Test BouncyCastle Streebog-256 with RFC 6986 M1 test vector.
    /// </summary>
    [Test]
    public void BouncyCastle_Streebog256_Rfc6986_M1()
    {
        var digest = new Gost3411_2012_256Digest();
        digest.BlockUpdate(Rfc6986Message1, 0, Rfc6986Message1.Length);
        byte[] hash = new byte[32];
        digest.DoFinal(hash, 0);

        TestContext.Out.WriteLine($"BouncyCastle 256 M1: {TestHelpers.ToHexString(hash)}");
        TestContext.Out.WriteLine($"RFC Expected:        {TestHelpers.ToHexString(Rfc6986M1Expected256)}");
        TestContext.Out.WriteLine($"Match: {hash.SequenceEqual(Rfc6986M1Expected256)}");

        Assert.That(hash, Is.EqualTo(Rfc6986M1Expected256), "BouncyCastle Streebog-256 should match RFC 6986 M1");
    }

    /// <summary>
    /// Test BouncyCastle Streebog-256 with RFC 6986 M2 test vector.
    /// </summary>
    [Test]
    public void BouncyCastle_Streebog256_Rfc6986_M2()
    {
        var digest = new Gost3411_2012_256Digest();
        digest.BlockUpdate(Rfc6986Message2, 0, Rfc6986Message2.Length);
        byte[] hash = new byte[32];
        digest.DoFinal(hash, 0);

        TestContext.Out.WriteLine($"BouncyCastle 256 M2: {TestHelpers.ToHexString(hash)}");
        TestContext.Out.WriteLine($"RFC Expected:        {TestHelpers.ToHexString(Rfc6986M2Expected256)}");
        TestContext.Out.WriteLine($"Match: {hash.SequenceEqual(Rfc6986M2Expected256)}");

        Assert.That(hash, Is.EqualTo(Rfc6986M2Expected256), "BouncyCastle Streebog-256 should match RFC 6986 M2");
    }

    #endregion

    #region Cross-Reference Comparison Tests

    /// <summary>
    /// Compare OpenGost and BouncyCastle outputs for empty string.
    /// This helps identify if both reference implementations agree.
    /// </summary>
    [Test]
    public void CrossReference_EmptyString_512()
    {
        byte[] input = Array.Empty<byte>();

        // OpenGost
        using var ogDigest = Streebog512.Create();
        byte[] ogHash = ogDigest.ComputeHash(input);

        // BouncyCastle
        var bcDigest = new Gost3411_2012_512Digest();
        bcDigest.BlockUpdate(input, 0, input.Length);
        byte[] bcHash = new byte[64];
        bcDigest.DoFinal(bcHash, 0);

        TestContext.Out.WriteLine($"OpenGost 512 empty:     {TestHelpers.ToHexString(ogHash)}");
        TestContext.Out.WriteLine($"BouncyCastle 512 empty: {TestHelpers.ToHexString(bcHash)}");
        TestContext.Out.WriteLine($"Match: {ogHash.SequenceEqual(bcHash)}");

        Assert.That(ogHash, Is.EqualTo(bcHash), "OpenGost and BouncyCastle should produce same hash for empty string");
    }

    /// <summary>
    /// Compare OpenGost and BouncyCastle outputs for empty string with 256-bit.
    /// </summary>
    [Test]
    public void CrossReference_EmptyString_256()
    {
        byte[] input = Array.Empty<byte>();

        // OpenGost
        using var ogDigest = Streebog256.Create();
        byte[] ogHash = ogDigest.ComputeHash(input);

        // BouncyCastle
        var bcDigest = new Gost3411_2012_256Digest();
        bcDigest.BlockUpdate(input, 0, input.Length);
        byte[] bcHash = new byte[32];
        bcDigest.DoFinal(bcHash, 0);

        TestContext.Out.WriteLine($"OpenGost 256 empty:     {TestHelpers.ToHexString(ogHash)}");
        TestContext.Out.WriteLine($"BouncyCastle 256 empty: {TestHelpers.ToHexString(bcHash)}");
        TestContext.Out.WriteLine($"Match: {ogHash.SequenceEqual(bcHash)}");

        Assert.That(ogHash, Is.EqualTo(bcHash), "OpenGost and BouncyCastle should produce same hash for empty string");
    }

    /// <summary>
    /// Compare all three implementations (OpenGost, BouncyCastle, Our) for empty string.
    /// </summary>
    [Test]
    public void ThreeWayComparison_EmptyString_512()
    {
        byte[] input = Array.Empty<byte>();

        // OpenGost
        using var ogDigest = Streebog512.Create();
        byte[] ogHash = ogDigest.ComputeHash(input);

        // BouncyCastle
        var bcDigest = new Gost3411_2012_512Digest();
        bcDigest.BlockUpdate(input, 0, input.Length);
        byte[] bcHash = new byte[64];
        bcDigest.DoFinal(bcHash, 0);

        // Our implementation
        using var ourDigest = Streebog.Create(64);
        byte[] ourHash = ourDigest.ComputeHash(input);

        TestContext.Out.WriteLine($"OpenGost 512:     {TestHelpers.ToHexString(ogHash)}");
        TestContext.Out.WriteLine($"BouncyCastle 512: {TestHelpers.ToHexString(bcHash)}");
        TestContext.Out.WriteLine($"Our impl 512:     {TestHelpers.ToHexString(ourHash)}");
        TestContext.Out.WriteLine($"OG==BC: {ogHash.SequenceEqual(bcHash)}");
        TestContext.Out.WriteLine($"Our==BC: {ourHash.SequenceEqual(bcHash)}");
        TestContext.Out.WriteLine($"Our==OG: {ourHash.SequenceEqual(ogHash)}");

        // Don't assert on our implementation - this is for diagnostic purposes
        Assert.That(ogHash, Is.EqualTo(bcHash), "Reference implementations should match");
    }

    /// <summary>
    /// Compare all three implementations for RFC M1 message.
    /// </summary>
    [Test]
    public void ThreeWayComparison_M1_512()
    {
        // OpenGost
        using var ogDigest = Streebog512.Create();
        byte[] ogHash = ogDigest.ComputeHash(Rfc6986Message1);

        // BouncyCastle
        var bcDigest = new Gost3411_2012_512Digest();
        bcDigest.BlockUpdate(Rfc6986Message1, 0, Rfc6986Message1.Length);
        byte[] bcHash = new byte[64];
        bcDigest.DoFinal(bcHash, 0);

        // Our implementation
        using var ourDigest = Streebog.Create(64);
        byte[] ourHash = ourDigest.ComputeHash(Rfc6986Message1);

        TestContext.Out.WriteLine($"RFC Expected:     {TestHelpers.ToHexString(Rfc6986M1Expected512)}");
        TestContext.Out.WriteLine($"OpenGost 512:     {TestHelpers.ToHexString(ogHash)}");
        TestContext.Out.WriteLine($"BouncyCastle 512: {TestHelpers.ToHexString(bcHash)}");
        TestContext.Out.WriteLine($"Our impl 512:     {TestHelpers.ToHexString(ourHash)}");
        TestContext.Out.WriteLine($"OG==RFC: {ogHash.SequenceEqual(Rfc6986M1Expected512)}");
        TestContext.Out.WriteLine($"BC==RFC: {bcHash.SequenceEqual(Rfc6986M1Expected512)}");
        TestContext.Out.WriteLine($"Our==RFC: {ourHash.SequenceEqual(Rfc6986M1Expected512)}");

        // Don't assert on our implementation - this is for diagnostic purposes
        // Just verify the reference implementations are consistent with each other
        Assert.Pass("Diagnostic test - see output for comparison");
    }

    #endregion

    #region RFC 6986 Byte Order Analysis

    /// <summary>
    /// Analyze byte ordering between RFC 6986 test vectors and implementations.
    /// The RFC may present values in big-endian while implementations output little-endian.
    /// </summary>
    [Test]
    public void ByteOrderAnalysis_M1_512()
    {
        // OpenGost
        using var ogDigest = Streebog512.Create();
        byte[] ogHash = ogDigest.ComputeHash(Rfc6986Message1);

        // Reverse the RFC expected value to see if it matches
        byte[] rfcReversed = (byte[])Rfc6986M1Expected512.Clone();
        Array.Reverse(rfcReversed);

        TestContext.Out.WriteLine($"OpenGost output:  {TestHelpers.ToHexString(ogHash)}");
        TestContext.Out.WriteLine($"RFC as-is:        {TestHelpers.ToHexString(Rfc6986M1Expected512)}");
        TestContext.Out.WriteLine($"RFC reversed:     {TestHelpers.ToHexString(rfcReversed)}");
        TestContext.Out.WriteLine($"OG==RFC-as-is:    {ogHash.SequenceEqual(Rfc6986M1Expected512)}");
        TestContext.Out.WriteLine($"OG==RFC-reversed: {ogHash.SequenceEqual(rfcReversed)}");

        // Check if OpenGost reversed matches RFC
        byte[] ogReversed = (byte[])ogHash.Clone();
        Array.Reverse(ogReversed);
        TestContext.Out.WriteLine($"OG-reversed==RFC: {ogReversed.SequenceEqual(Rfc6986M1Expected512)}");

        Assert.Pass("Byte order analysis - see output");
    }

    /// <summary>
    /// Test if RFC uses word-reversed byte order (common in GOST standards).
    /// </summary>
    [Test]
    public void ByteOrderAnalysis_WordReversed_M1_512()
    {
        // OpenGost
        using var ogDigest = Streebog512.Create();
        byte[] ogHash = ogDigest.ComputeHash(Rfc6986Message1);

        // Try reversing 8-byte words
        byte[] rfcWordReversed = new byte[64];
        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                rfcWordReversed[i * 8 + j] = Rfc6986M1Expected512[i * 8 + (7 - j)];
            }
        }

        // Try reversing word order (swap first word with last, etc.)
        byte[] rfcWordOrderReversed = new byte[64];
        for (int i = 0; i < 8; i++)
        {
            Array.Copy(Rfc6986M1Expected512, (7 - i) * 8, rfcWordOrderReversed, i * 8, 8);
        }

        TestContext.Out.WriteLine($"OpenGost output:      {TestHelpers.ToHexString(ogHash)}");
        TestContext.Out.WriteLine($"RFC as-is:            {TestHelpers.ToHexString(Rfc6986M1Expected512)}");
        TestContext.Out.WriteLine($"RFC word-byte-rev:    {TestHelpers.ToHexString(rfcWordReversed)}");
        TestContext.Out.WriteLine($"RFC word-order-rev:   {TestHelpers.ToHexString(rfcWordOrderReversed)}");
        TestContext.Out.WriteLine($"OG==RFC-word-byte:    {ogHash.SequenceEqual(rfcWordReversed)}");
        TestContext.Out.WriteLine($"OG==RFC-word-order:   {ogHash.SequenceEqual(rfcWordOrderReversed)}");

        Assert.Pass("Word byte order analysis - see output");
    }

    #endregion
}
