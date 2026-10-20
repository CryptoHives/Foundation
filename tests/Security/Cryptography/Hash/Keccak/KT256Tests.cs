// SPDX-FileCopyrightText: 2025 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT OR Apache-2.0

namespace Cryptography.Tests.Hash.Keccak;

using CryptoHives.Foundation.Security.Cryptography.Hash;
using NUnit.Framework;
using System;
using System.Text;

/// <summary>
/// Tests for KT256 per RFC 9861.
/// </summary>
/// <remarks>
/// Test vectors are from RFC 9861 Section 5.
/// </remarks>
[TestFixture]
[Parallelizable(ParallelScope.All)]
public class KT256Tests
{
    private static byte[] CreatePattern(int length)
    {
        byte[] result = new byte[length];
        for (int i = 0; i < length; i++)
        {
            result[i] = (byte)(i % 251); // 0x00 to 0xFA pattern
        }
        return result;
    }

    /// <summary>
    /// RFC 9861 test vector: KT256(M=empty, C=empty, 64)
    /// </summary>
    [Test]
    public void EmptyInputEmptyCustomization64Bytes()
    {
        byte[] expected = TestHelpers.FromHexString(
            "B2 3D 2E 9C EA 9F 49 04 E0 2B EC 06 81 7F C1 0C E3 8C E8 E9 3E F4 C8 9E 65 37 07 6A F8 64 64 04 " +
            "E3 E8 B6 81 07 B8 83 3A 5D 30 49 0A A3 34 82 35 3F D4 AD C7 14 8E CB 78 28 55 00 3A AE BD E4 A9");

        using var kt256 = new KT256(64);
        byte[] hash = kt256.ComputeHash(Array.Empty<byte>());

        Assert.That(hash, Is.EqualTo(expected));
    }

    /// <summary>
    /// RFC 9861 test vector: KT256(M=ptn(1), C=empty, 64)
    /// </summary>
    [Test]
    public void Pattern1ByteEmptyCustomization()
    {
        byte[] expected = TestHelpers.FromHexString(
            "0D 00 5A 19 40 85 36 02 17 12 8C F1 7F 91 E1 F7 13 14 EF A5 56 45 39 D4 44 91 2E 34 37 EF A1 7F " +
            "82 DB 6F 6F FE 76 E7 81 EA A0 68 BC E0 1F 2B BF 81 EA CB 98 3D 72 30 F2 FB 02 83 4A 21 B1 DD D0");
        byte[] input = CreatePattern(1);

        using var kt256 = new KT256(64);
        byte[] hash = kt256.ComputeHash(input);

        Assert.That(hash, Is.EqualTo(expected));
    }

    /// <summary>
    /// RFC 9861 test vector: KT256(M=ptn(17), C=empty, 64)
    /// </summary>
    [Test]
    public void Pattern17BytesEmptyCustomization()
    {
        byte[] expected = TestHelpers.FromHexString(
            "1B A3 C0 2B 1F C5 14 47 4F 06 C8 97 99 78 A9 05 6C 84 83 F4 A1 B6 3D 0D CC EF E3 A2 8A 2F 32 3E " +
            "1C DC CA 40 EB F0 06 AC 76 EF 03 97 15 23 46 83 7B 12 77 D3 E7 FA A9 C9 65 3B 19 07 50 98 52 7B");
        byte[] input = CreatePattern(17);

        using var kt256 = new KT256(64);
        byte[] hash = kt256.ComputeHash(input);

        Assert.That(hash, Is.EqualTo(expected));
    }

    /// <summary>
    /// Test that variable output sizes work correctly (XOF property).
    /// </summary>
    [Test]
    public void VariableOutputLength()
    {
        byte[] input = Encoding.ASCII.GetBytes("test");

        using var kt256_32 = KT256.Create(32);
        using var kt256_64 = KT256.Create(64);

        byte[] hash32 = kt256_32.ComputeHash(input);
        byte[] hash64 = kt256_64.ComputeHash(input);

        Assert.That(hash32, Has.Length.EqualTo(32));
        Assert.That(hash64, Has.Length.EqualTo(64));
        // First 32 bytes of 64-byte output should match 32-byte output (XOF property)
        Assert.That(hash64.AsSpan(0, 32).ToArray(), Is.EqualTo(hash32));
    }

    /// <summary>
    /// Test the algorithm name property.
    /// </summary>
    [Test]
    public void AlgorithmNameIsCorrect()
    {
        using var kt256 = KT256.Create();
        Assert.That(kt256.AlgorithmName, Is.EqualTo("KT256"));
    }

    /// <summary>
    /// Test block size property.
    /// </summary>
    [Test]
    public void BlockSizeIsCorrect()
    {
        using var kt256 = KT256.Create();
        Assert.That(kt256.BlockSize, Is.EqualTo(136)); // Same rate as TurboSHAKE256
    }

    /// <summary>
    /// RFC 9861 pattern vectors around and past the chunk boundary.
    /// </summary>
    /// <remarks>
    /// With an empty customization an 8192-byte message is already two chunks, because
    /// length_encode(0) adds one byte to S; 8191 is the last single-node size.
    /// </remarks>
    [TestCase(4913,
        "64 7E FB 49 FE 9D 71 75 00 17 1B 41 E7 F1 1B D4 91 54 44 43 20 99 97 CE 1C 25 30 D1 5E B1 FF BB " +
        "59 89 35 EF 95 45 28 FF C1 52 B1 E4 D7 31 EE 26 83 68 06 74 36 5C D1 91 D5 62 BA E7 53 B8 4A A5")]
    [TestCase(8191,
        "30 81 43 4D 93 A4 10 8D 8D 8A 33 05 B8 96 82 CE BE DC 7C A4 EA 8A 3C E8 69 FB B7 3C BE 4A 58 EE " +
        "F6 F2 4D E3 8F FC 17 05 14 C7 0E 7A B2 D0 1F 03 81 26 16 E8 63 D7 69 AF B3 75 31 93 BA 04 5B 20")]
    [TestCase(8192,
        "C6 EE 8E 2A D3 20 0C 01 8A C8 7A AA 03 1C DA C2 21 21 B4 12 D0 7D C6 E0 DC CB B5 34 23 74 7E 9A " +
        "1C 18 83 4D 99 DF 59 6C F0 CF 4B 8D FA FB 7B F0 2D 13 9D 0C 90 35 72 5A DC 1A 01 B7 23 0A 41 FA")]
    [TestCase(83521,
        "B0 62 75 D2 84 CD 1C F2 05 BC BE 57 DC CD 3E C1 FF 66 86 E3 ED 15 77 63 83 E1 F2 FA 3C 6A C8 F0 " +
        "8B F8 A1 62 82 9D B1 A4 4B 2A 43 FF 83 DD 89 C3 CF 1C EB 61 ED E6 59 76 6D 5C CF 81 7A 62 BA 8D")]
    [TestCase(1419857,
        "94 73 83 1D 76 A4 C7 BF 77 AC E4 5B 59 F1 45 8B 16 73 D6 4B CD 87 7A 7C 66 B2 66 4A A6 DD 14 9E " +
        "60 EA B7 1B 5C 2B AB 85 8C 07 4D ED 81 DD CE 2B 40 22 B5 21 59 35 C0 D4 D1 9B F5 11 AE EB 07 72")]
    public void PatternAcrossChunkBoundary(int length, string expectedHex)
    {
        byte[] expected = TestHelpers.FromHexString(expectedHex);
        byte[] input = CreatePattern(length);

        using var kt256 = new KT256(64);
        byte[] hash = kt256.ComputeHash(input);

        Assert.That(hash, Is.EqualTo(expected));
    }

    /// <summary>
    /// RFC 9861 vectors whose customization string decides the chunk count: |S| is exactly two
    /// chunks with ptn(8189) and one byte into a third with ptn(8190).
    /// </summary>
    [TestCase(8189,
        "74 E4 78 79 F1 0A 9C 5D 11 BD 2D A7 E1 94 FE 57 E8 63 78 BF 3C 3F 74 48 EF F3 C5 76 A0 F1 8C 5C " +
        "AA E0 99 99 79 51 20 90 A7 F3 48 AF 42 60 D4 DE 3C 37 F1 EC AF 8D 2C 2C 96 C1 D1 6C 64 B1 24 96")]
    [TestCase(8190,
        "F4 B5 90 8B 92 9F FE 01 E0 F7 9E C2 F2 12 43 D4 1A 39 6B 2E 73 03 A6 AF 1D 63 99 CD 6C 7A 0A 2D " +
        "D7 C4 F6 07 E8 27 7F 9C 9B 1C B4 AB 9D DC 59 D4 B9 2D 1F C7 55 84 41 F1 83 2C 32 79 A4 24 1B 8B")]
    public void PatternCustomizationAcrossChunkBoundary(int customizationLength, string expectedHex)
    {
        byte[] expected = TestHelpers.FromHexString(expectedHex);
        byte[] input = CreatePattern(8192);

        using var kt256 = new KT256(64, CreatePattern(customizationLength));
        kt256.Absorb(input.AsSpan(0, 5000));
        kt256.Absorb(input.AsSpan(5000));

        byte[] actual = new byte[64];
        kt256.Squeeze(actual);

        Assert.That(actual, Is.EqualTo(expected));
    }

    /// <summary>
    /// A message spanning several chunks must hash the same whether it arrives in one call or in
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

        using var oneShot = new KT256(64);
        byte[] expected = oneShot.ComputeHash(input);

        using var streamed = new KT256(64);
        for (int offset = 0; offset < input.Length; offset += segmentLength)
        {
            streamed.Absorb(input.AsSpan(offset, Math.Min(segmentLength, input.Length - offset)));
        }

        byte[] actual = new byte[64];
        streamed.Squeeze(actual);

        Assert.That(actual, Is.EqualTo(expected));
    }

    /// <summary>
    /// A customization string is appended to the message before chunking, so it can push a
    /// message that is itself under the chunk size onto the tree path.
    /// </summary>
    [TestCase(8000, 500)]
    [TestCase(8192, 1)]
    public void CustomizationCanCrossTheChunkBoundary(int messageLength, int customizationLength)
    {
        byte[] input = CreatePattern(messageLength);
        byte[] customization = CreatePattern(customizationLength);

        using var oneShot = new KT256(64, customization);
        byte[] expected = oneShot.ComputeHash(input);

        using var streamed = new KT256(64, customization);
        streamed.Absorb(input.AsSpan(0, messageLength / 2));
        streamed.Absorb(input.AsSpan(messageLength / 2));

        byte[] actual = new byte[64];
        streamed.Squeeze(actual);

        Assert.That(actual, Is.EqualTo(expected));
    }
}
