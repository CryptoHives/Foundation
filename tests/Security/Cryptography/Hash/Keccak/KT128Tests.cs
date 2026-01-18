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
        byte[] expected = HexToBytes("1A C2 D4 50 FC 3B 42 05 D1 9D A7 BF CA 1B 37 51 3C 08 03 57 7A C7 16 7F 06 FE 2C E1 F0 EF 39 E5");

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
        byte[] expected = HexToBytes(
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
        byte[] expected = HexToBytes("2B DA 92 45 0E 8B 14 7F 8A 7C B6 29 E7 84 A0 58 EF CA 7C F7 D8 21 8E 02 D3 45 DF AA 65 24 4A 1F");
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
        byte[] expected = HexToBytes("6B F7 5F A2 23 91 98 DB 47 72 E3 64 78 F8 E1 9B 0F 37 12 05 F6 A9 A9 3A 27 3F 51 DF 37 12 28 88");
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
        byte[] expected = HexToBytes("0C 31 5E BC DE DB F6 14 26 DE 7D CF 8F B7 25 D1 E7 46 75 D7 F5 32 7A 50 67 F3 67 B1 08 EC B6 7C");
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
        byte[] expected = HexToBytes("FA B6 58 DB 63 E9 4A 24 61 88 BF 7A F6 9A 13 30 45 F4 6E E9 84 C5 6E 3C 33 28 CA AF 1A A1 A5 83");
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
}
