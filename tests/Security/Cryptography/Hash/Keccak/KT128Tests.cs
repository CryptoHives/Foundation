// SPDX-FileCopyrightText: 2025 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace Cryptography.Tests.Hash.Keccak;

using CryptoHives.Foundation.Security.Cryptography.Hash;
using NUnit.Framework;
using System;
using System.Text;

/// <summary>
/// Tests for KT128 (KangarooTwelve) per RFC 9861.
/// </summary>
/// <remarks>
/// Test vectors are from RFC 9861 Section 5.
/// </remarks>
[TestFixture]
[Parallelizable(ParallelScope.All)]
public class KT128Tests
{
    /// <summary>
    /// RFC 9861 test vector: KT128(M=empty, C=empty, 32)
    /// </summary>
    [Test]
    public void EmptyInputEmptyCustomization32Bytes()
    {
        byte[] expected = TestHelpers.FromHexString("1A C2 D4 50 FC 3B 42 05 D1 9D A7 BF CA 1B 37 51 3C 08 03 57 7A C7 16 7F 06 FE 2C E1 F0 EF 39 E5");

        using var kt128 = new KT128(32);
        byte[] hash = kt128.ComputeHash(Array.Empty<byte>());

        Assert.That(hash, Is.EqualTo(expected));
    }

    /// <summary>
    /// RFC 9861 test vector: KT128(M=empty, C=empty, 64)
    /// </summary>
    [Test]
    public void EmptyInputEmptyCustomization64Bytes()
    {
        byte[] expected = TestHelpers.FromHexString(
            "1A C2 D4 50 FC 3B 42 05 D1 9D A7 BF CA 1B 37 51 3C 08 03 57 7A C7 16 7F 06 FE 2C E1 F0 EF 39 E5 " +
            "42 69 C0 56 B8 C8 2E 48 27 60 38 B6 D2 92 96 6C C0 7A 3D 46 45 27 2E 31 FF 38 50 81 39 EB 0A 71");

        using var kt128 = new KT128(64);
        byte[] hash = kt128.ComputeHash(Array.Empty<byte>());

        Assert.That(hash, Is.EqualTo(expected));
    }

    /// <summary>
    /// RFC 9861 test vector: KT128(M=ptn(1), C=empty, 32)
    /// </summary>
    [Test]
    public void Pattern1ByteEmptyCustomization()
    {
        byte[] expected = TestHelpers.FromHexString("2B DA 92 45 0E 8B 14 7F 8A 7C B6 29 E7 84 A0 58 EF CA 7C F7 D8 21 8E 02 D3 45 DF AA 65 24 4A 1F");
        byte[] input = CreatePattern(1);

        using var kt128 = new KT128(32);
        byte[] hash = kt128.ComputeHash(input);

        Assert.That(hash, Is.EqualTo(expected));
    }

    /// <summary>
    /// RFC 9861 test vector: KT128(M=ptn(17), C=empty, 32)
    /// </summary>
    [Test]
    public void Pattern17BytesEmptyCustomization()
    {
        byte[] expected = TestHelpers.FromHexString("6B F7 5F A2 23 91 98 DB 47 72 E3 64 78 F8 E1 9B 0F 37 12 05 F6 A9 A9 3A 27 3F 51 DF 37 12 28 88");
        byte[] input = CreatePattern(17);

        using var kt128 = new KT128(32);
        byte[] hash = kt128.ComputeHash(input);

        Assert.That(hash, Is.EqualTo(expected));
    }

    /// <summary>
    /// RFC 9861 test vector: KT128(M=ptn(17^2), C=empty, 32)
    /// </summary>
    [Test]
    public void Pattern289BytesEmptyCustomization()
    {
        byte[] expected = TestHelpers.FromHexString("0C 31 5E BC DE DB F6 14 26 DE 7D CF 8F B7 25 D1 E7 46 75 D7 F5 32 7A 50 67 F3 67 B1 08 EC B6 7C");
        byte[] input = CreatePattern(17 * 17);

        using var kt128 = new KT128(32);
        byte[] hash = kt128.ComputeHash(input);

        Assert.That(hash, Is.EqualTo(expected));
    }

    /// <summary>
    /// RFC 9861 test vector: KT128(empty, C=ptn(1), 32)
    /// </summary>
    [Test]
    public void EmptyInputPattern1Customization()
    {
        byte[] expected = TestHelpers.FromHexString("FA B6 58 DB 63 E9 4A 24 61 88 BF 7A F6 9A 13 30 45 F4 6E E9 84 C5 6E 3C 33 28 CA AF 1A A1 A5 83");
        byte[] customization = CreatePattern(1);

        using var kt128 = new KT128(32, customization);
        byte[] hash = kt128.ComputeHash(Array.Empty<byte>());

        Assert.That(hash, Is.EqualTo(expected));
    }

    /// <summary>
    /// Test that variable output sizes work correctly (XOF property).
    /// </summary>
    [Test]
    public void VariableOutputLength()
    {
        byte[] input = Encoding.ASCII.GetBytes("test");

        using var kt128_16 = KT128.Create(16);
        using var kt128_64 = KT128.Create(64);

        byte[] hash16 = kt128_16.ComputeHash(input);
        byte[] hash64 = kt128_64.ComputeHash(input);

        Assert.That(hash16, Has.Length.EqualTo(16));
        Assert.That(hash64, Has.Length.EqualTo(64));
        // First 16 bytes of 64-byte output should match 16-byte output (XOF property)
        Assert.That(hash64.AsSpan(0, 16).ToArray(), Is.EqualTo(hash16));
    }

    /// <summary>
    /// Test that customization string changes the output.
    /// </summary>
    [Test]
    public void CustomizationChangesOutput()
    {
        byte[] input = Encoding.ASCII.GetBytes("test");

        using var kt128NoCustom = new KT128(32);
        using var kt128WithCustom = new KT128(32, "MyCustomization");

        byte[] hash1 = kt128NoCustom.ComputeHash(input);
        byte[] hash2 = kt128WithCustom.ComputeHash(input);

        Assert.That(hash1, Is.Not.EqualTo(hash2));
    }

    /// <summary>
    /// Test the algorithm name property.
    /// </summary>
    [Test]
    public void AlgorithmNameIsCorrect()
    {
        using var kt128 = KT128.Create();
        Assert.That(kt128.AlgorithmName, Is.EqualTo("KT128"));
    }

    /// <summary>
    /// Test block size property.
    /// </summary>
    [Test]
    public void BlockSizeIsCorrect()
    {
        using var kt128 = KT128.Create();
        Assert.That(kt128.BlockSize, Is.EqualTo(168)); // Same rate as TurboSHAKE128
    }

    /// <summary>
    /// Test that invalid output size throws.
    /// </summary>
    [Test]
    public void InvalidOutputSizeThrows()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => KT128.Create(0));
        Assert.Throws<ArgumentOutOfRangeException>(() => KT128.Create(-1));
    }

    /// <summary>
    /// RFC 9861 pattern vectors that reach the tree-hashing path.
    /// </summary>
    /// <remarks>
    /// The single-node test is on |S| = M || C || length_encode(|C|), and length_encode(0) is one
    /// byte, so with an empty customization an 8192-byte message is already two chunks and 8191 is
    /// the last single-node size. ptn(17^4) spans eleven chunks.
    /// </remarks>
    [TestCase(4913, "CB 55 2E 2E C7 7D 99 10 70 1D 57 8B 45 7D DF 77 2C 12 E3 22 E4 EE 7F E4 17 F9 2C 75 8F 0D 59 D0")]
    [TestCase(8191, "1B 57 76 36 F7 23 64 3E 99 0C C7 D6 A6 59 83 74 36 FD 6A 10 36 26 60 0E B8 30 1C D1 DB E5 53 D6")]
    [TestCase(8192, "48 F2 56 F6 77 2F 9E DF B6 A8 B6 61 EC 92 DC 93 B9 5E BD 05 A0 8A 17 B3 9A E3 49 08 70 C9 26 C3")]
    [TestCase(83521, "87 01 04 5E 22 20 53 45 FF 4D DA 05 55 5C BB 5C 3A F1 A7 71 C2 B8 9B AE F3 7D B4 3D 99 98 B9 FE")]
    public void PatternAcrossChunkBoundary(int length, string expectedHex)
    {
        byte[] expected = TestHelpers.FromHexString(expectedHex);
        byte[] input = CreatePattern(length);

        using var kt128 = new KT128(32);
        byte[] hash = kt128.ComputeHash(input);

        Assert.That(hash, Is.EqualTo(expected));
    }

    /// <summary>
    /// A message spanning eleven chunks must hash the same whether it arrives in one call or in
    /// segments that straddle the chunk boundary.
    /// </summary>
    [TestCase(1)]
    [TestCase(4096)]
    [TestCase(8191)]
    [TestCase(8192)]
    [TestCase(8193)]
    public void SegmentedAbsorbMatchesOneShotAcrossChunkBoundary(int segmentLength)
    {
        byte[] input = CreatePattern(83521);

        using var oneShot = new KT128(32);
        byte[] expected = oneShot.ComputeHash(input);

        using var streamed = new KT128(32);
        for (int offset = 0; offset < input.Length; offset += segmentLength)
        {
            streamed.Absorb(input.AsSpan(offset, Math.Min(segmentLength, input.Length - offset)));
        }

        byte[] actual = new byte[32];
        streamed.Squeeze(actual);

        Assert.That(actual, Is.EqualTo(expected));
    }

    /// <summary>
    /// A customization string is appended to the message before chunking, so it can push a
    /// message that is itself under the chunk size onto the tree path.
    /// </summary>
    [TestCase(8000, 500)]
    [TestCase(8191, 1)]
    [TestCase(8192, 1)]
    public void CustomizationCanCrossTheChunkBoundary(int messageLength, int customizationLength)
    {
        byte[] input = CreatePattern(messageLength);
        byte[] customization = CreatePattern(customizationLength);

        using var oneShot = new KT128(32, customization);
        byte[] expected = oneShot.ComputeHash(input);

        using var streamed = new KT128(32, customization);
        streamed.Absorb(input.AsSpan(0, messageLength / 2));
        streamed.Absorb(input.AsSpan(messageLength / 2));

        byte[] actual = new byte[32];
        streamed.Squeeze(actual);

        Assert.That(actual, Is.EqualTo(expected));
    }

#if !NETFRAMEWORK
    /// <summary>
    /// Absorbing must not retain the message. A four-megabyte hash fed in segments allocates
    /// nothing beyond the fixed state, where accumulating the whole input would allocate
    /// megabytes.
    /// </summary>
    [Test]
    public void AbsorbDoesNotAllocatePerMessageByte()
    {
        const int total = 4 * 1024 * 1024;
        const int segment = 64 * 1024;
        byte[] data = CreatePattern(segment);

        using var kt128 = new KT128(32);

        // Warm up over the full path so tiered compilation is settled before measuring.
        for (int written = 0; written < total; written += segment)
        {
            kt128.Absorb(data);
        }

        long before = GC.GetAllocatedBytesForCurrentThread();
        for (int written = 0; written < total; written += segment)
        {
            kt128.Absorb(data);
        }
        long allocated = GC.GetAllocatedBytesForCurrentThread() - before;

        Assert.That(allocated, Is.LessThan(1024),
            $"absorbing {total} bytes allocated {allocated} bytes; it must not scale with the message");
    }

    private const int ChunkSize = 8192;
#endif

    /// <summary>
    /// Creates the pattern message per RFC 9861: ptn(n) = (0x00, 0x01, ..., 0xFA) repeated.
    /// </summary>
    private static byte[] CreatePattern(int length)
    {
        byte[] result = new byte[length];
        for (int i = 0; i < length; i++)
        {
            result[i] = (byte)(i % 251); // 0x00 to 0xFA pattern
        }
        return result;
    }
}
