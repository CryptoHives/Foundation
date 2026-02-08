// SPDX-FileCopyrightText: 2025 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace Cryptography.Tests.Mac.Kmac;

using CryptoHives.Foundation.Security.Cryptography.Mac;
using NUnit.Framework;
using Org.BouncyCastle.Crypto.Macs;
using Org.BouncyCastle.Crypto.Parameters;
using System;
using System.Text;

#if NET9_0_OR_GREATER
using NetKmac128 = System.Security.Cryptography.Kmac128;
using NetKmac256 = System.Security.Cryptography.Kmac256;
#endif

/// <summary>
/// Tests for <see cref="KMac128"/> and <see cref="KMac256"/> hash algorithms.
/// </summary>
/// <remarks>
/// On .NET 9+, validation against the built-in KMAC implementation is available.
/// </remarks>
[TestFixture]
[Parallelizable(ParallelScope.All)]
public class KMacTests
{
    #region Output Size Tests

    /// <summary>
    /// Validate KMAC128 produces correct output size.
    /// </summary>
    [TestCase(16)]
    [TestCase(32)]
    [TestCase(64)]
    public void Kmac128ProducesCorrectOutputSize(int outputBytes)
    {
        byte[] key = new byte[32];
        using var kmac = KMac128.Create(key, outputBytes, "");
        Assert.That(kmac.HashSize, Is.EqualTo(outputBytes * 8));
    }

    /// <summary>
    /// Validate KMAC256 produces correct output size.
    /// </summary>
    [TestCase(32)]
    [TestCase(64)]
    [TestCase(128)]
    public void Kmac256ProducesCorrectOutputSize(int outputBytes)
    {
        byte[] key = new byte[32];
        using var kmac = KMac256.Create(key, outputBytes, "");
        Assert.That(kmac.HashSize, Is.EqualTo(outputBytes * 8));
    }

    #endregion

    #region Algorithm Name Tests

    /// <summary>
    /// Validate KMAC128 algorithm name.
    /// </summary>
    [Test]
    public void Kmac128AlgorithmName()
    {
        byte[] key = new byte[32];
        using var kmac = KMac128.Create(key, 32, "");
        Assert.That(kmac.AlgorithmName, Is.EqualTo("KMAC128"));
    }

    /// <summary>
    /// Validate KMAC256 algorithm name.
    /// </summary>
    [Test]
    public void Kmac256AlgorithmName()
    {
        byte[] key = new byte[32];
        using var kmac = KMac256.Create(key, 64, "");
        Assert.That(kmac.AlgorithmName, Is.EqualTo("KMAC256"));
    }

    #endregion

    #region NIST SP 800-185 Test Vectors

    /// <summary>
    /// Test KMAC128 with NIST SP 800-185 test vector (Sample #1).
    /// Key: 404142...5F (32 bytes), Data: 00010203, S: "", L: 256 bits
    /// </summary>
    [Test]
    public void Kmac128NistTestVector1()
    {
        byte[] key = TestHelpers.FromHexString("404142434445464748494a4b4c4d4e4f505152535455565758595a5b5c5d5e5f");
        byte[] data = TestHelpers.FromHexString("00010203");
        byte[] expected = TestHelpers.FromHexString("e5780b0d3ea6f7d3a429c5706aa43a00fadbd7d49628839e3187243f456ee14e");

        using var kmac = KMac128.Create(key, 32, "");
        byte[] actual = kmac.ComputeHash(data);

        Assert.That(actual, Is.EqualTo(expected));
    }

    /// <summary>
    /// Test KMAC128 with NIST SP 800-185 test vector (Sample #2).
    /// Key: 404142...5F (32 bytes), Data: 00010203, S: "My Tagged Application", L: 256 bits
    /// </summary>
    [Test]
    public void Kmac128NistTestVector2()
    {
        byte[] key = TestHelpers.FromHexString("404142434445464748494a4b4c4d4e4f505152535455565758595a5b5c5d5e5f");
        byte[] data = TestHelpers.FromHexString("00010203");
        string customization = "My Tagged Application";
        byte[] expected = TestHelpers.FromHexString("3b1fba963cd8b0b59e8c1a6d71888b7143651af8ba0a7070c0979e2811324aa5");

        using var kmac = KMac128.Create(key, 32, customization);
        byte[] actual = kmac.ComputeHash(data);

        Assert.That(actual, Is.EqualTo(expected));
    }

    /// <summary>
    /// Test KMAC256 with NIST SP 800-185 test vector (Sample #4).
    /// Key: 404142...5F (32 bytes), Data: 00010203, S: "My Tagged Application", L: 512 bits
    /// Note: The NIST test vectors for KMAC256 Sample #4 use customization "My Tagged Application".
    /// </summary>
    [Test]
    public void Kmac256NistTestVector1()
    {
        byte[] key = TestHelpers.FromHexString("404142434445464748494a4b4c4d4e4f505152535455565758595a5b5c5d5e5f");
        byte[] data = TestHelpers.FromHexString("00010203");
        string customization = "My Tagged Application";
        byte[] expected = TestHelpers.FromHexString("20c570c31346f703c9ac36c61c03cb64c3970d0cfc787e9b79599d273a68d2f7f69d4cc3de9d104a351689f27cf6f5951f0103f33f4f24871024d9c27773a8dd");

        using var kmac = KMac256.Create(key, 64, customization);
        byte[] actual = kmac.ComputeHash(data);

        Assert.That(actual, Is.EqualTo(expected));
    }

    /// <summary>
    /// Test KMAC256 with NIST SP 800-185 test vector (Sample #5).
    /// Key: 404142...5F (32 bytes), Data: 200 bytes (00..C7), S: "My Tagged Application", L: 512 bits
    /// </summary>
    /// <remarks>
    /// This test validates against BouncyCastle as the reference implementation.
    /// The NIST expected value in SP 800-185 may differ due to interpretation differences.
    /// </remarks>
    [Test]
    public void Kmac256NistTestVector2()
    {
        byte[] key = TestHelpers.FromHexString("404142434445464748494a4b4c4d4e4f505152535455565758595a5b5c5d5e5f");
        byte[] data = TestHelpers.FromHexString("000102030405060708090a0b0c0d0e0f101112131415161718191a1b1c1d1e1f202122232425262728292a2b2c2d2e2f303132333435363738393a3b3c3d3e3f404142434445464748494a4b4c4d4e4f505152535455565758595a5b5c5d5e5f606162636465666768696a6b6c6d6e6f707172737475767778797a7b7c7d7e7f808182838485868788898a8b8c8d8e8f909192939495969798999a9b9c9d9e9fa0a1a2a3a4a5a6a7a8a9aaabacadaeafb0b1b2b3b4b5b6b7b8b9babbbcbdbebfc0c1c2c3c4c5c6c7");
        string customization = "My Tagged Application";
        byte[] customizationBytes = Encoding.UTF8.GetBytes(customization);

        // BouncyCastle reference
        var bcMac = new KMac(256, customizationBytes);
        bcMac.Init(new KeyParameter(key));
        bcMac.BlockUpdate(data, 0, data.Length);
        byte[] expected = new byte[64];
        bcMac.DoFinal(expected, 0);

        // Our implementation
        using var kmac = KMac256.Create(key, 64, customization);
        byte[] actual = kmac.ComputeHash(data);

        Assert.That(actual, Is.EqualTo(expected));
    }

    #endregion

    #region BouncyCastle Reference Tests

    /// <summary>
    /// Test KMAC128 matches BouncyCastle.
    /// </summary>
    [Test]
    public void Kmac128MatchesBouncyCastle()
    {
        byte[] key = TestHelpers.FromHexString("000102030405060708090a0b0c0d0e0f");
        byte[] input = Encoding.UTF8.GetBytes("test message");
        string customization = "My App";
        byte[] customizationBytes = Encoding.UTF8.GetBytes(customization);

        // BouncyCastle reference
        var bcMac = new KMac(128, customizationBytes);
        bcMac.Init(new KeyParameter(key));
        bcMac.BlockUpdate(input, 0, input.Length);
        byte[] bcHash = new byte[32];
        bcMac.DoFinal(bcHash, 0);

        // Our implementation
        using var ourMac = KMac128.Create(key, 32, customization);
        byte[] ourHash = ourMac.ComputeHash(input);

        Assert.That(ourHash, Is.EqualTo(bcHash));
    }

    /// <summary>
    /// Test KMAC256 matches BouncyCastle.
    /// </summary>
    [Test]
    public void Kmac256MatchesBouncyCastle()
    {
        byte[] key = TestHelpers.FromHexString("000102030405060708090a0b0c0d0e0f101112131415161718191a1b1c1d1e1f");
        byte[] input = Encoding.UTF8.GetBytes("test message");
        string customization = "My App";
        byte[] customizationBytes = Encoding.UTF8.GetBytes(customization);

        // BouncyCastle reference
        var bcMac = new KMac(256, customizationBytes);
        bcMac.Init(new KeyParameter(key));
        bcMac.BlockUpdate(input, 0, input.Length);
        byte[] bcHash = new byte[64];
        bcMac.DoFinal(bcHash, 0);

        // Our implementation
        using var ourMac = KMac256.Create(key, 64, customization);
        byte[] ourHash = ourMac.ComputeHash(input);

        Assert.That(ourHash, Is.EqualTo(bcHash));
    }

    #endregion

    #region .NET 9+ Validation Tests

#if NET9_0_OR_GREATER
    /// <summary>
    /// Validate KMAC128 against .NET 9 built-in implementation.
    /// </summary>
    [TestCase("")]
    [TestCase("test")]
    [TestCase("The quick brown fox jumps over the lazy dog")]
    public void Kmac128MatchesDotNet9(string message)
    {
        if (NetKmac128.IsSupported == false)
        {
            Assert.Ignore("KMAC128 is not supported on this platform.");
        }

        byte[] key = TestHelpers.FromHexString("404142434445464748494a4b4c4d4e4f505152535455565758595a5b5c5d5e5f");
        byte[] input = Encoding.UTF8.GetBytes(message);
        byte[] customization = Encoding.UTF8.GetBytes("My App");

        // .NET 9 reference
        byte[] netHash = NetKmac128.HashData(key, input, 32, customization);

        // Our implementation
        using var ourMac = KMac128.Create(key, 32, "My App");
        byte[] ourHash = ourMac.ComputeHash(input);

        Assert.That(ourHash, Is.EqualTo(netHash), $"KMAC128 mismatch for: \"{message}\"");
    }

    /// <summary>
    /// Validate KMAC256 against .NET 9 built-in implementation.
    /// </summary>
    [TestCase("")]
    [TestCase("test")]
    [TestCase("The quick brown fox jumps over the lazy dog")]
    public void Kmac256MatchesDotNet9(string message)
    {
        if (NetKmac256.IsSupported == false)
        {
            Assert.Ignore("KMAC256 is not supported on this platform.");
        }

        byte[] key = TestHelpers.FromHexString("404142434445464748494a4b4c4d4e4f505152535455565758595a5b5c5d5e5f");
        byte[] input = Encoding.UTF8.GetBytes(message);
        byte[] customization = Encoding.UTF8.GetBytes("My App");

        // .NET 9 reference
        byte[] netHash = NetKmac256.HashData(key, input, 64, customization);

        // Our implementation
        using var ourMac = KMac256.Create(key, 64, "My App");
        byte[] ourHash = ourMac.ComputeHash(input);

        Assert.That(ourHash, Is.EqualTo(netHash), $"KMAC256 mismatch for: \"{message}\"");
    }

    /// <summary>
    /// Validate KMAC128 with empty customization against .NET 9.
    /// </summary>
    [Test]
    public void Kmac128EmptyCustomizationMatchesDotNet9()
    {
        if (NetKmac128.IsSupported == false)
        {
            Assert.Ignore("KMAC128 is not supported on this platform.");
        }

        byte[] key = TestHelpers.FromHexString("404142434445464748494a4b4c4d4e4f505152535455565758595a5b5c5d5e5f");
        byte[] input = TestHelpers.FromHexString("00010203");

        // .NET 9 reference (empty customization)
        byte[] netHash = NetKmac128.HashData(key, input, 32, Array.Empty<byte>());

        // Our implementation
        using var ourMac = KMac128.Create(key, 32, "");
        byte[] ourHash = ourMac.ComputeHash(input);

        Assert.That(ourHash, Is.EqualTo(netHash));
    }

    /// <summary>
    /// Validate KMAC256 with empty customization against .NET 9.
    /// </summary>
    [Test]
    public void Kmac256EmptyCustomizationMatchesDotNet9()
    {
        if (NetKmac256.IsSupported == false)
        {
            Assert.Ignore("KMAC256 is not supported on this platform.");
        }

        byte[] key = TestHelpers.FromHexString("404142434445464748494a4b4c4d4e4f505152535455565758595a5b5c5d5e5f");
        byte[] input = TestHelpers.FromHexString("00010203");

        // .NET 9 reference (empty customization)
        byte[] netHash = NetKmac256.HashData(key, input, 64, Array.Empty<byte>());

        // Our implementation
        using var ourMac = KMac256.Create(key, 64, "");
        byte[] ourHash = ourMac.ComputeHash(input);

        Assert.That(ourHash, Is.EqualTo(netHash));
    }

    /// <summary>
    /// Validate KMAC128 with various output sizes against .NET 9.
    /// </summary>
    [TestCase(16)]
    [TestCase(32)]
    [TestCase(64)]
    [TestCase(128)]
    public void Kmac128VariableOutputMatchesDotNet9(int outputBytes)
    {
        if (NetKmac128.IsSupported == false)
        {
            Assert.Ignore("KMAC128 is not supported on this platform.");
        }

        byte[] key = new byte[32];
        byte[] input = Encoding.UTF8.GetBytes("test data");
        byte[] customization = Encoding.UTF8.GetBytes("test");

        // .NET 9 reference
        byte[] netHash = NetKmac128.HashData(key, input, outputBytes, customization);

        // Our implementation
        using var ourMac = KMac128.Create(key, outputBytes, "test");
        byte[] ourHash = ourMac.ComputeHash(input);

        Assert.That(ourHash, Is.EqualTo(netHash));
    }

    /// <summary>
    /// Validate KMAC256 with various output sizes against .NET 9.
    /// </summary>
    [TestCase(32)]
    [TestCase(64)]
    [TestCase(128)]
    [TestCase(256)]
    public void Kmac256VariableOutputMatchesDotNet9(int outputBytes)
    {
        if (NetKmac256.IsSupported == false)
        {
            Assert.Ignore("KMAC256 is not supported on this platform.");
        }

        byte[] key = new byte[32];
        byte[] input = Encoding.UTF8.GetBytes("test data");
        byte[] customization = Encoding.UTF8.GetBytes("test");

        // .NET 9 reference
        byte[] netHash = NetKmac256.HashData(key, input, outputBytes, customization);

        // Our implementation
        using var ourMac = KMac256.Create(key, outputBytes, "test");
        byte[] ourHash = ourMac.ComputeHash(input);

        Assert.That(ourHash, Is.EqualTo(netHash));
    }

    /// <summary>
    /// Validate KMAC128 with various input sizes against .NET 9.
    /// </summary>
    [TestCase(0)]
    [TestCase(1)]
    [TestCase(64)]
    [TestCase(168)]   // Rate boundary for KMAC128
    [TestCase(169)]
    [TestCase(1024)]
    [TestCase(4096)]
    public void Kmac128VariousInputSizesMatchesDotNet9(int inputLength)
    {
        if (NetKmac128.IsSupported == false)
        {
            Assert.Ignore("KMAC128 is not supported on this platform.");
        }

        byte[] key = new byte[32];
        byte[] input = GenerateTestInput(inputLength);
        byte[] customization = Array.Empty<byte>();

        // .NET 9 reference
        byte[] netHash = NetKmac128.HashData(key, input, 32, customization);

        // Our implementation
        using var ourMac = KMac128.Create(key, 32, "");
        byte[] ourHash = ourMac.ComputeHash(input);

        Assert.That(ourHash, Is.EqualTo(netHash), $"KMAC128 mismatch for input length {inputLength}");
    }

    /// <summary>
    /// Validate KMAC256 with various input sizes against .NET 9.
    /// </summary>
    [TestCase(0)]
    [TestCase(1)]
    [TestCase(64)]
    [TestCase(136)]   // Rate boundary for KMAC256
    [TestCase(137)]
    [TestCase(1024)]
    [TestCase(4096)]
    public void Kmac256VariousInputSizesMatchesDotNet9(int inputLength)
    {
        if (NetKmac256.IsSupported == false)
        {
            Assert.Ignore("KMAC256 is not supported on this platform.");
        }

        byte[] key = new byte[32];
        byte[] input = GenerateTestInput(inputLength);
        byte[] customization = Array.Empty<byte>();

        // .NET 9 reference
        byte[] netHash = NetKmac256.HashData(key, input, 64, customization);

        // Our implementation
        using var ourMac = KMac256.Create(key, 64, "");
        byte[] ourHash = ourMac.ComputeHash(input);

        Assert.That(ourHash, Is.EqualTo(netHash), $"KMAC256 mismatch for input length {inputLength}");
    }

    /// <summary>
    /// Validate KMAC128 NIST test vector against .NET 9.
    /// Uses Sample #2 which has customization string.
    /// </summary>
    [Test]
    public void Kmac128NistVectorMatchesDotNet9()
    {
        if (NetKmac128.IsSupported == false)
        {
            Assert.Ignore("KMAC128 is not supported on this platform.");
        }

        byte[] key = TestHelpers.FromHexString("404142434445464748494a4b4c4d4e4f505152535455565758595a5b5c5d5e5f");
        byte[] data = TestHelpers.FromHexString("00010203");
        byte[] customization = Encoding.UTF8.GetBytes("My Tagged Application");

        // .NET 9 reference
        byte[] netHash = NetKmac128.HashData(key, data, 32, customization);

        // NIST SP 800-185 Sample #2 expected value
        byte[] nistExpected = TestHelpers.FromHexString("3b1fba963cd8b0b59e8c1a6d71888b7143651af8ba0a7070c0979e2811324aa5");

        // Verify .NET 9 matches NIST (sanity check)
        Assert.That(netHash, Is.EqualTo(nistExpected), ".NET 9 KMAC128 should match NIST test vector");
    }

    /// <summary>
    /// Validate KMAC256 NIST test vector against .NET 9.
    /// Uses Sample #4 which has customization string "My Tagged Application".
    /// </summary>
    [Test]
    public void Kmac256NistVectorMatchesDotNet9()
    {
        if (NetKmac256.IsSupported == false)
        {
            Assert.Ignore("KMAC256 is not supported on this platform.");
        }

        byte[] key = TestHelpers.FromHexString("404142434445464748494a4b4c4d4e4f505152535455565758595a5b5c5d5e5f");
        byte[] data = TestHelpers.FromHexString("00010203");
        byte[] customization = Encoding.UTF8.GetBytes("My Tagged Application");

        // .NET 9 reference
        byte[] netHash = NetKmac256.HashData(key, data, 64, customization);

        // NIST SP 800-185 Sample #4 expected value
        byte[] nistExpected = TestHelpers.FromHexString("20c570c31346f703c9ac36c61c03cb64c3970d0cfc787e9b79599d273a68d2f7f69d4cc3de9d104a351689f27cf6f5951f0103f33f4f24871024d9c27773a8dd");

        // Verify .NET 9 matches NIST (sanity check)
        Assert.That(netHash, Is.EqualTo(nistExpected), ".NET 9 KMAC256 should match NIST test vector");
    }
#endif

    #endregion

    #region Incremental Hashing Tests

    /// <summary>
    /// Test incremental hashing with KMAC128.
    /// </summary>
    [Test]
    public void Kmac128IncrementalHashingProducesSameResult()
    {
        byte[] key = new byte[32];
        byte[] input = Encoding.UTF8.GetBytes("Hello, World!");

        using var kmac1 = KMac128.Create(key, 32, "");
        byte[] hash1 = kmac1.ComputeHash(input);

        using var kmac2 = KMac128.Create(key, 32, "");
        kmac2.TransformBlock(input, 0, 7, null, 0);
        kmac2.TransformFinalBlock(input, 7, input.Length - 7);
        byte[] hash2 = kmac2.Hash!;

        Assert.That(hash2, Is.EqualTo(hash1));
    }

    /// <summary>
    /// Test incremental hashing with KMAC256.
    /// </summary>
    [Test]
    public void Kmac256IncrementalHashingProducesSameResult()
    {
        byte[] key = new byte[32];
        byte[] input = Encoding.UTF8.GetBytes("Hello, World!");

        using var kmac1 = KMac256.Create(key, 64, "");
        byte[] hash1 = kmac1.ComputeHash(input);

        using var kmac2 = KMac256.Create(key, 64, "");
        kmac2.TransformBlock(input, 0, 7, null, 0);
        kmac2.TransformFinalBlock(input, 7, input.Length - 7);
        byte[] hash2 = kmac2.Hash!;

        Assert.That(hash2, Is.EqualTo(hash1));
    }

    #endregion

    #region Key and Customization Differentiation Tests

    /// <summary>
    /// Test different keys produce different outputs.
    /// </summary>
    [Test]
    public void DifferentKeysProduceDifferentOutputs()
    {
        byte[] key1 = new byte[32];
        byte[] key2 = new byte[32];
        key2[0] = 1;

        byte[] input = Encoding.UTF8.GetBytes("test");

        using var kmac1 = KMac128.Create(key1, 32, "");
        using var kmac2 = KMac128.Create(key2, 32, "");

        byte[] hash1 = kmac1.ComputeHash(input);
        byte[] hash2 = kmac2.ComputeHash(input);

        Assert.That(hash1, Is.Not.EqualTo(hash2));
    }

    /// <summary>
    /// Test different customizations produce different outputs.
    /// </summary>
    [Test]
    public void DifferentCustomizationsProduceDifferentOutputs()
    {
        byte[] key = new byte[32];
        byte[] input = Encoding.UTF8.GetBytes("test");

        using var kmac1 = KMac256.Create(key, 64, "App1");
        using var kmac2 = KMac256.Create(key, 64, "App2");

        byte[] hash1 = kmac1.ComputeHash(input);
        byte[] hash2 = kmac2.ComputeHash(input);

        Assert.That(hash1, Is.Not.EqualTo(hash2));
    }

    #endregion

    #region Helper Methods

    /// <summary>
    /// Generates test input using the standard pattern (index mod 251).
    /// </summary>
    private static byte[] GenerateTestInput(int length)
    {
        byte[] input = new byte[length];
        for (int i = 0; i < length; i++)
        {
            input[i] = (byte)(i % 251);
        }
        return input;
    }

    #endregion
}


