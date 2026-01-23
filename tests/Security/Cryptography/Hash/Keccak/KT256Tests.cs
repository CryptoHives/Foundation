// SPDX-FileCopyrightText: 2025 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

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
    private static byte[] HexToBytes(string hex)
    {
        hex = hex.Replace(" ", "");
        byte[] result = new byte[hex.Length / 2];
        for (int i = 0; i < result.Length; i++)
        {
            result[i] = Convert.ToByte(hex.Substring(i * 2, 2), 16);
        }
        return result;
    }

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
        byte[] expected = HexToBytes(
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
        byte[] expected = HexToBytes(
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
        byte[] expected = HexToBytes(
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
}
