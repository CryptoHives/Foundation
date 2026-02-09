// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace Cryptography.Tests.Hash;

using NUnit.Framework;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Digests;
using Org.BouncyCastle.Crypto.Macs;
using Org.BouncyCastle.Crypto.Parameters;
using System;
using System.Text;
using CH = CryptoHives.Foundation.Security.Cryptography;

/// <summary>
/// Tests that validate XOF (extendable-output) implementations against BouncyCastle
/// reference at variable output sizes and streaming squeeze scenarios.
/// </summary>
[TestFixture]
[Parallelizable(ParallelScope.All)]
public class XofReferenceTests
{
    private static readonly byte[] EmptyInput = [];
    private static readonly byte[] ShortInput = Encoding.UTF8.GetBytes("abc");
    private static readonly byte[] MediumInput = Encoding.UTF8.GetBytes("The quick brown fox jumps over the lazy dog");

    #region SHAKE128

    /// <summary>
    /// Validate SHAKE128 XOF output at variable sizes against BouncyCastle.
    /// </summary>
    [TestCase(32)]
    [TestCase(64)]
    [TestCase(128)]
    [TestCase(256)]
    public void Shake128XofVariableOutput(int outputSize)
    {
        foreach (byte[] input in new[] { EmptyInput, ShortInput, MediumInput })
        {
            var bc = new ShakeDigest(128);
            bc.BlockUpdate(input, 0, input.Length);
            byte[] expected = new byte[outputSize];
            bc.OutputFinal(expected, 0, outputSize);

            using var xof = CH.Hash.Shake128.Create(outputSize);
            xof.Absorb(input);
            byte[] actual = new byte[outputSize];
            xof.Squeeze(actual);

            Assert.That(actual, Is.EqualTo(expected),
                $"SHAKE128 XOF mismatch at {outputSize} bytes for input length {input.Length}");
        }
    }

    /// <summary>
    /// Validate SHAKE128 streaming squeeze matches BouncyCastle streaming output.
    /// </summary>
    [Test]
    public void Shake128StreamingSqueezeMatchesBouncyCastle()
    {
        AssertStreamingSqueeze(
            () => new ShakeDigest(128),
            () => CH.Hash.Shake128.Create(128),
            ShortInput, 64);
    }

    /// <summary>
    /// Validate SHAKE128 non-aligned streaming squeeze matches BouncyCastle.
    /// </summary>
    [Test]
    public void Shake128NonAlignedStreamingMatchesBouncyCastle()
    {
        AssertNonAlignedStreaming(
            () => new ShakeDigest(128),
            () => CH.Hash.Shake128.Create(128),
            MediumInput);
    }

    #endregion

    #region SHAKE256

    /// <summary>
    /// Validate SHAKE256 XOF output at variable sizes against BouncyCastle.
    /// </summary>
    [TestCase(32)]
    [TestCase(64)]
    [TestCase(128)]
    [TestCase(256)]
    public void Shake256XofVariableOutput(int outputSize)
    {
        foreach (byte[] input in new[] { EmptyInput, ShortInput, MediumInput })
        {
            var bc = new ShakeDigest(256);
            bc.BlockUpdate(input, 0, input.Length);
            byte[] expected = new byte[outputSize];
            bc.OutputFinal(expected, 0, outputSize);

            using var xof = CH.Hash.Shake256.Create(outputSize);
            xof.Absorb(input);
            byte[] actual = new byte[outputSize];
            xof.Squeeze(actual);

            Assert.That(actual, Is.EqualTo(expected),
                $"SHAKE256 XOF mismatch at {outputSize} bytes for input length {input.Length}");
        }
    }

    /// <summary>
    /// Validate SHAKE256 streaming squeeze matches BouncyCastle streaming output.
    /// </summary>
    [Test]
    public void Shake256StreamingSqueezeMatchesBouncyCastle()
    {
        AssertStreamingSqueeze(
            () => new ShakeDigest(256),
            () => CH.Hash.Shake256.Create(128),
            ShortInput, 64);
    }

    /// <summary>
    /// Validate SHAKE256 non-aligned streaming squeeze matches BouncyCastle.
    /// </summary>
    [Test]
    public void Shake256NonAlignedStreamingMatchesBouncyCastle()
    {
        AssertNonAlignedStreaming(
            () => new ShakeDigest(256),
            () => CH.Hash.Shake256.Create(128),
            MediumInput);
    }

    #endregion

    #region cSHAKE128

    /// <summary>
    /// Validate cSHAKE128 XOF output at variable sizes against BouncyCastle.
    /// </summary>
    [TestCase(32)]
    [TestCase(64)]
    [TestCase(128)]
    [TestCase(256)]
    public void CShake128XofVariableOutput(int outputSize)
    {
        byte[] customization = Encoding.UTF8.GetBytes("XOF Test");
        byte[] input = ShortInput;

        var bc = new CShakeDigest(128, null, customization);
        bc.BlockUpdate(input, 0, input.Length);
        byte[] expected = new byte[outputSize];
        bc.OutputFinal(expected, 0, outputSize);

        using var xof = CH.Hash.CShake128.Create(outputSize, "", "XOF Test");
        xof.Absorb(input);
        byte[] actual = new byte[outputSize];
        xof.Squeeze(actual);

        Assert.That(actual, Is.EqualTo(expected),
            $"cSHAKE128 XOF mismatch at {outputSize} bytes");
    }

    /// <summary>
    /// Validate cSHAKE128 streaming squeeze matches BouncyCastle streaming output.
    /// </summary>
    [Test]
    public void CShake128StreamingSqueezeMatchesBouncyCastle()
    {
        byte[] customization = Encoding.UTF8.GetBytes("XOF Test");

        AssertStreamingSqueeze(
            () => new CShakeDigest(128, null, customization),
            () => CH.Hash.CShake128.Create(128, "", "XOF Test"),
            ShortInput, 64);
    }

    #endregion

    #region cSHAKE256

    /// <summary>
    /// Validate cSHAKE256 XOF output at variable sizes against BouncyCastle.
    /// </summary>
    [TestCase(32)]
    [TestCase(64)]
    [TestCase(128)]
    [TestCase(256)]
    public void CShake256XofVariableOutput(int outputSize)
    {
        byte[] customization = Encoding.UTF8.GetBytes("XOF Test");
        byte[] input = ShortInput;

        var bc = new CShakeDigest(256, null, customization);
        bc.BlockUpdate(input, 0, input.Length);
        byte[] expected = new byte[outputSize];
        bc.OutputFinal(expected, 0, outputSize);

        using var xof = CH.Hash.CShake256.Create(outputSize, "", "XOF Test");
        xof.Absorb(input);
        byte[] actual = new byte[outputSize];
        xof.Squeeze(actual);

        Assert.That(actual, Is.EqualTo(expected),
            $"cSHAKE256 XOF mismatch at {outputSize} bytes");
    }

    /// <summary>
    /// Validate cSHAKE256 streaming squeeze matches BouncyCastle streaming output.
    /// </summary>
    [Test]
    public void CShake256StreamingSqueezeMatchesBouncyCastle()
    {
        byte[] customization = Encoding.UTF8.GetBytes("XOF Test");

        AssertStreamingSqueeze(
            () => new CShakeDigest(256, null, customization),
            () => CH.Hash.CShake256.Create(128, "", "XOF Test"),
            ShortInput, 64);
    }

    #endregion

    #region Blake3

    /// <summary>
    /// Validate Blake3 XOF output at variable sizes against BouncyCastle.
    /// </summary>
    [TestCase(32)]
    [TestCase(64)]
    [TestCase(128)]
    [TestCase(256)]
    public void Blake3XofVariableOutput(int outputSize)
    {
        foreach (byte[] input in new[] { EmptyInput, ShortInput, MediumInput })
        {
            var bc = new Blake3Digest(256);
            bc.BlockUpdate(input, 0, input.Length);
            byte[] expected = new byte[outputSize];
            bc.OutputFinal(expected, 0, outputSize);

            using var xof = CH.Hash.Blake3.Create(outputSize);
            xof.Absorb(input);
            byte[] actual = new byte[outputSize];
            xof.Squeeze(actual);

            Assert.That(actual, Is.EqualTo(expected),
                $"Blake3 XOF mismatch at {outputSize} bytes for input length {input.Length}");
        }
    }

    /// <summary>
    /// Validate Blake3 streaming squeeze matches BouncyCastle streaming output.
    /// </summary>
    [Test]
    public void Blake3StreamingSqueezeMatchesBouncyCastle()
    {
        AssertStreamingSqueezeXof(
            () => new Blake3Digest(256),
            () => CH.Hash.Blake3.Create(256),
            ShortInput, 64);
    }

    /// <summary>
    /// Validate Blake3 non-aligned streaming squeeze matches BouncyCastle.
    /// </summary>
    [Test]
    public void Blake3NonAlignedStreamingMatchesBouncyCastle()
    {
        AssertNonAlignedStreamingXof(
            () => (IXof)new Blake3Digest(256),
            () => CH.Hash.Blake3.Create(256),
            MediumInput);
    }

    /// <summary>
    /// Validate Blake3 XOF output spanning multiple counter-mode blocks (>64 bytes)
    /// matches BouncyCastle reference with various input sizes.
    /// </summary>
    [TestCase(0)]
    [TestCase(1)]
    [TestCase(64)]
    [TestCase(65)]
    [TestCase(1024)]
    public void Blake3LargeXofOutputMatchesBouncyCastle(int inputLength)
    {
        byte[] input = GenerateTestInput(inputLength);

        var bc = new Blake3Digest(256);
        bc.BlockUpdate(input, 0, input.Length);
        byte[] expected = new byte[512];
        bc.OutputFinal(expected, 0, 512);

        using var xof = CH.Hash.Blake3.Create(512);
        xof.Absorb(input);
        byte[] actual = new byte[512];
        xof.Squeeze(actual);

        Assert.That(actual, Is.EqualTo(expected),
            $"Blake3 large XOF mismatch for input length {inputLength}");
    }

    #endregion

    #region Ascon-XOF128

    /// <summary>
    /// Validate Ascon-XOF128 output at variable sizes against BouncyCastle.
    /// </summary>
    [TestCase(32)]
    [TestCase(64)]
    [TestCase(128)]
    [TestCase(256)]
    public void AsconXof128VariableOutput(int outputSize)
    {
        foreach (byte[] input in new[] { EmptyInput, ShortInput, MediumInput })
        {
            var bc = new Org.BouncyCastle.Crypto.Digests.AsconXof128();
            bc.BlockUpdate(input, 0, input.Length);
            byte[] expected = new byte[outputSize];
            bc.OutputFinal(expected, 0, outputSize);

            using var xof = CH.Hash.AsconXof128.Create(outputSize);
            xof.Absorb(input);
            byte[] actual = new byte[outputSize];
            xof.Squeeze(actual);

            Assert.That(actual, Is.EqualTo(expected),
                $"Ascon-XOF128 mismatch at {outputSize} bytes for input length {input.Length}");
        }
    }

    /// <summary>
    /// Validate Ascon-XOF128 streaming squeeze matches BouncyCastle streaming output.
    /// </summary>
    [Test]
    public void AsconXof128StreamingSqueezeMatchesBouncyCastle()
    {
        AssertStreamingSqueezeXof(
            () => (IXof)new Org.BouncyCastle.Crypto.Digests.AsconXof128(),
            () => CH.Hash.AsconXof128.Create(128),
            ShortInput, 32);
    }

    /// <summary>
    /// Validate Ascon-XOF128 non-aligned streaming squeeze matches BouncyCastle.
    /// </summary>
    [Test]
    public void AsconXof128NonAlignedStreamingMatchesBouncyCastle()
    {
        AssertNonAlignedStreamingXof(
            () => (IXof)new Org.BouncyCastle.Crypto.Digests.AsconXof128(),
            () => CH.Hash.AsconXof128.Create(128),
            MediumInput);
    }

    #endregion

    #region KMAC128

    /// <summary>
    /// Validate KMAC128 XOF output at variable sizes against BouncyCastle.
    /// </summary>
    [TestCase(32)]
    [TestCase(64)]
    [TestCase(128)]
    [TestCase(256)]
    public void Kmac128XofVariableOutput(int outputSize)
    {
        byte[] key = TestHelpers.FromHexString("404142434445464748494a4b4c4d4e4f505152535455565758595a5b5c5d5e5f");
        byte[] input = TestHelpers.FromHexString("00010203");

        var bc = new KMac(128, Array.Empty<byte>());
        bc.Init(new KeyParameter(key));
        bc.BlockUpdate(input, 0, input.Length);
        byte[] expected = new byte[outputSize];
        ((IXof)bc).OutputFinal(expected, 0, outputSize);

        using var xof = CH.Mac.KMac128.Create(key, outputSize, "");
        xof.Absorb(input);
        byte[] actual = new byte[outputSize];
        xof.Squeeze(actual);

        Assert.That(actual, Is.EqualTo(expected),
            $"KMAC128 XOF mismatch at {outputSize} bytes");
    }

    #endregion

    #region KMAC256

    /// <summary>
    /// Validate KMAC256 XOF output at variable sizes against BouncyCastle.
    /// </summary>
    [TestCase(32)]
    [TestCase(64)]
    [TestCase(128)]
    [TestCase(256)]
    public void Kmac256XofVariableOutput(int outputSize)
    {
        byte[] key = TestHelpers.FromHexString("404142434445464748494a4b4c4d4e4f505152535455565758595a5b5c5d5e5f");
        byte[] input = TestHelpers.FromHexString("00010203");

        var bc = new KMac(256, Array.Empty<byte>());
        bc.Init(new KeyParameter(key));
        bc.BlockUpdate(input, 0, input.Length);
        byte[] expected = new byte[outputSize];
        ((IXof)bc).OutputFinal(expected, 0, outputSize);

        using var xof = CH.Mac.KMac256.Create(key, outputSize, "");
        xof.Absorb(input);
        byte[] actual = new byte[outputSize];
        xof.Squeeze(actual);

        Assert.That(actual, Is.EqualTo(expected),
            $"KMAC256 XOF mismatch at {outputSize} bytes");
    }

    #endregion

#if NET8_0_OR_GREATER

    #region OS SHAKE128

    /// <summary>
    /// Validate SHAKE128 XOF output at variable sizes against .NET OS implementation.
    /// </summary>
    [TestCase(32)]
    [TestCase(64)]
    [TestCase(128)]
    [TestCase(256)]
    public void Shake128XofMatchesOsImplementation(int outputSize)
    {
        Assume.That(System.Security.Cryptography.Shake128.IsSupported, "OS SHAKE128 not supported on this platform.");

        foreach (byte[] input in new[] { EmptyInput, ShortInput, MediumInput })
        {
            byte[] expected = new byte[outputSize];
            System.Security.Cryptography.Shake128.HashData(input, expected);

            using var xof = CH.Hash.Shake128.Create(outputSize);
            xof.Absorb(input);
            byte[] actual = new byte[outputSize];
            xof.Squeeze(actual);

            Assert.That(actual, Is.EqualTo(expected),
                $"SHAKE128 OS mismatch at {outputSize} bytes for input length {input.Length}");
        }
    }

    #endregion

    #region OS SHAKE256

    /// <summary>
    /// Validate SHAKE256 XOF output at variable sizes against .NET OS implementation.
    /// </summary>
    [TestCase(32)]
    [TestCase(64)]
    [TestCase(128)]
    [TestCase(256)]
    public void Shake256XofMatchesOsImplementation(int outputSize)
    {
        Assume.That(System.Security.Cryptography.Shake256.IsSupported, "OS SHAKE256 not supported on this platform.");

        foreach (byte[] input in new[] { EmptyInput, ShortInput, MediumInput })
        {
            byte[] expected = new byte[outputSize];
            System.Security.Cryptography.Shake256.HashData(input, expected);

            using var xof = CH.Hash.Shake256.Create(outputSize);
            xof.Absorb(input);
            byte[] actual = new byte[outputSize];
            xof.Squeeze(actual);

            Assert.That(actual, Is.EqualTo(expected),
                $"SHAKE256 OS mismatch at {outputSize} bytes for input length {input.Length}");
        }
    }

    #endregion

#endif

#if BLAKE3_NATIVE

    #region Blake3 Native

    /// <summary>
    /// Validate Blake3 XOF output at variable sizes against Blake3.NET native Rust implementation.
    /// </summary>
    [TestCase(32)]
    [TestCase(64)]
    [TestCase(128)]
    [TestCase(256)]
    [TestCase(512)]
    public void Blake3XofMatchesNativeImplementation(int outputSize)
    {
        foreach (byte[] input in new[] { EmptyInput, ShortInput, MediumInput })
        {
            var hasher = global::Blake3.Hasher.New();
            hasher.Update(input);
            byte[] expected = new byte[outputSize];
            hasher.Finalize(expected);

            using var xof = CH.Hash.Blake3.Create(outputSize);
            xof.Absorb(input);
            byte[] actual = new byte[outputSize];
            xof.Squeeze(actual);

            Assert.That(actual, Is.EqualTo(expected),
                $"Blake3 native mismatch at {outputSize} bytes for input length {input.Length}");
        }
    }

    /// <summary>
    /// Validate Blake3 large XOF output against Blake3.NET native with various input sizes.
    /// </summary>
    [TestCase(0)]
    [TestCase(1)]
    [TestCase(64)]
    [TestCase(65)]
    [TestCase(1024)]
    public void Blake3LargeXofMatchesNativeImplementation(int inputLength)
    {
        byte[] input = GenerateTestInput(inputLength);

        var hasher = global::Blake3.Hasher.New();
        hasher.Update(input);
        byte[] expected = new byte[512];
        hasher.Finalize(expected);

        using var xof = CH.Hash.Blake3.Create(512);
        xof.Absorb(input);
        byte[] actual = new byte[512];
        xof.Squeeze(actual);

        Assert.That(actual, Is.EqualTo(expected),
            $"Blake3 native large XOF mismatch for input length {inputLength}");
    }

    #endregion

#endif

    #region Helpers

    /// <summary>
    /// Asserts streaming squeeze for a SHAKE-based XOF matches BouncyCastle streaming output.
    /// </summary>
    private static void AssertStreamingSqueeze(
        Func<ShakeDigest> bcFactory,
        Func<CH.Hash.IExtendableOutput> chFactory,
        byte[] input,
        int halfSize)
    {
        // BouncyCastle streaming via IXof.Output (no reset between calls)
        var bc = bcFactory();
        bc.BlockUpdate(input, 0, input.Length);
        byte[] bcPart1 = new byte[halfSize];
        byte[] bcPart2 = new byte[halfSize];
        ((IXof)bc).Output(bcPart1, 0, halfSize);
        ((IXof)bc).Output(bcPart2, 0, halfSize);

        // Our streaming
        using var ch = (IDisposable)chFactory();
        var xof = (CH.Hash.IExtendableOutput)ch;
        xof.Absorb(input);
        byte[] ourPart1 = new byte[halfSize];
        byte[] ourPart2 = new byte[halfSize];
        xof.Squeeze(ourPart1);
        xof.Squeeze(ourPart2);

        Assert.That(ourPart1, Is.EqualTo(bcPart1), "Streaming part 1 mismatch");
        Assert.That(ourPart2, Is.EqualTo(bcPart2), "Streaming part 2 mismatch");
    }

    /// <summary>
    /// Asserts non-aligned streaming squeeze for a SHAKE-based XOF matches BouncyCastle.
    /// </summary>
    private static void AssertNonAlignedStreaming(
        Func<ShakeDigest> bcFactory,
        Func<CH.Hash.IExtendableOutput> chFactory,
        byte[] input)
    {
        int[] sizes = [10, 15, 12, 7, 19];

        // BouncyCastle streaming
        var bc = bcFactory();
        bc.BlockUpdate(input, 0, input.Length);
        byte[][] bcParts = new byte[sizes.Length][];
        for (int i = 0; i < sizes.Length; i++)
        {
            bcParts[i] = new byte[sizes[i]];
            ((IXof)bc).Output(bcParts[i], 0, sizes[i]);
        }

        // Our streaming
        using var ch = (IDisposable)chFactory();
        var xof = (CH.Hash.IExtendableOutput)ch;
        xof.Absorb(input);
        for (int i = 0; i < sizes.Length; i++)
        {
            byte[] part = new byte[sizes[i]];
            xof.Squeeze(part);
            Assert.That(part, Is.EqualTo(bcParts[i]), $"Non-aligned streaming mismatch at segment {i} (size {sizes[i]})");
        }
    }

    /// <summary>
    /// Asserts streaming squeeze for a generic IXof matches BouncyCastle streaming output.
    /// </summary>
    private static void AssertStreamingSqueezeXof(
        Func<IXof> bcFactory,
        Func<CH.Hash.IExtendableOutput> chFactory,
        byte[] input,
        int halfSize)
    {
        var bc = bcFactory();
        bc.BlockUpdate(input, 0, input.Length);
        byte[] bcPart1 = new byte[halfSize];
        byte[] bcPart2 = new byte[halfSize];
        bc.Output(bcPart1, 0, halfSize);
        bc.Output(bcPart2, 0, halfSize);

        using var ch = (IDisposable)chFactory();
        var xof = (CH.Hash.IExtendableOutput)ch;
        xof.Absorb(input);
        byte[] ourPart1 = new byte[halfSize];
        byte[] ourPart2 = new byte[halfSize];
        xof.Squeeze(ourPart1);
        xof.Squeeze(ourPart2);

        Assert.That(ourPart1, Is.EqualTo(bcPart1), "Streaming part 1 mismatch");
        Assert.That(ourPart2, Is.EqualTo(bcPart2), "Streaming part 2 mismatch");
    }

    /// <summary>
    /// Asserts non-aligned streaming squeeze for a generic IXof matches BouncyCastle.
    /// </summary>
    private static void AssertNonAlignedStreamingXof(
        Func<IXof> bcFactory,
        Func<CH.Hash.IExtendableOutput> chFactory,
        byte[] input)
    {
        int[] sizes = [10, 15, 12, 7, 19];

        var bc = bcFactory();
        bc.BlockUpdate(input, 0, input.Length);
        byte[][] bcParts = new byte[sizes.Length][];
        for (int i = 0; i < sizes.Length; i++)
        {
            bcParts[i] = new byte[sizes[i]];
            bc.Output(bcParts[i], 0, sizes[i]);
        }

        using var ch = (IDisposable)chFactory();
        var xof = (CH.Hash.IExtendableOutput)ch;
        xof.Absorb(input);
        for (int i = 0; i < sizes.Length; i++)
        {
            byte[] part = new byte[sizes[i]];
            xof.Squeeze(part);
            Assert.That(part, Is.EqualTo(bcParts[i]), $"Non-aligned streaming mismatch at segment {i} (size {sizes[i]})");
        }
    }

    /// <summary>
    /// Generates test input using the BLAKE3 pattern (index mod 251).
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
