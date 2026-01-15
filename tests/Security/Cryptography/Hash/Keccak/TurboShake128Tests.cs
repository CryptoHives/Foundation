// SPDX-FileCopyrightText: 2025 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace Cryptography.Tests.Hash.Keccak;

using System;
using CryptoHives.Foundation.Security.Cryptography.Hash;
using NUnit.Framework;

/// <summary>
/// Tests for TurboSHAKE128 per RFC 9861.
/// </summary>
/// <remarks>
/// Test vectors are from RFC 9861 Section 5.
/// </remarks>
[TestFixture]
[Parallelizable(ParallelScope.All)]
public class TurboShake128Tests
{
    /// <summary>
    /// RFC 9861 test vector: TurboSHAKE128(M=empty, D=0x1F, 32)
    /// </summary>
    [Test]
    public void EmptyInput32Bytes()
    {
        byte[] expected = HexToBytes("1E 41 5F 1C 59 83 AF F2 16 92 17 27 7D 17 BB 53 8C D9 45 A3 97 DD EC 54 1F 1C E4 1A F2 C1 B7 4C");

        using var turbo = new TurboShake128(32);
        byte[] hash = turbo.ComputeHash(Array.Empty<byte>());

        Assert.That(hash, Is.EqualTo(expected));
    }

    /// <summary>
    /// RFC 9861 test vector: TurboSHAKE128(M=empty, D=0x1F, 64)
    /// </summary>
    [Test]
    public void EmptyInput64Bytes()
    {
        byte[] expected = HexToBytes(
            "1E 41 5F 1C 59 83 AF F2 16 92 17 27 7D 17 BB 53 8C D9 45 A3 97 DD EC 54 1F 1C E4 1A F2 C1 B7 4C " +
            "3E 8C CA E2 A4 DA E5 6C 84 A0 4C 23 85 C0 3C 15 E8 19 3B DF 58 73 73 63 32 16 91 C0 54 62 C8 DF");

        using var turbo = new TurboShake128(64);
        byte[] hash = turbo.ComputeHash(Array.Empty<byte>());

        Assert.That(hash, Is.EqualTo(expected));
    }

    /// <summary>
    /// RFC 9861 test vector: TurboSHAKE128(M=ptn(17^0=1), D=0x1F, 32)
    /// </summary>
    [Test]
    public void Pattern1Byte()
    {
        byte[] expected = HexToBytes("55 CE DD 6F 60 AF 7B B2 9A 40 42 AE 83 2E F3 F5 8D B7 29 9F 89 3E BB 92 47 24 7D 85 69 58 DA A9");
        byte[] input = CreatePattern(1);

        using var turbo = new TurboShake128(32);
        byte[] hash = turbo.ComputeHash(input);

        Assert.That(hash, Is.EqualTo(expected));
    }

    /// <summary>
    /// RFC 9861 test vector: TurboSHAKE128(M=ptn(17), D=0x1F, 32)
    /// </summary>
    [Test]
    public void Pattern17Bytes()
    {
        byte[] expected = HexToBytes("9C 97 D0 36 A3 BA C8 19 DB 70 ED E0 CA 55 4E C6 E4 C2 A1 A4 FF BF D9 EC 26 9C A6 A1 11 16 12 33");
        byte[] input = CreatePattern(17);

        using var turbo = new TurboShake128(32);
        byte[] hash = turbo.ComputeHash(input);

        Assert.That(hash, Is.EqualTo(expected));
    }

    /// <summary>
    /// RFC 9861 test vector: TurboSHAKE128(M=ptn(17^2), D=0x1F, 32)
    /// </summary>
    [Test]
    public void Pattern289Bytes()
    {
        byte[] expected = HexToBytes("96 C7 7C 27 9E 01 26 F7 FC 07 C9 B0 7F 5C DA E1 E0 BE 60 BD BE 10 62 00 40 E7 5D 72 23 A6 24 D2");
        byte[] input = CreatePattern(17 * 17);

        using var turbo = new TurboShake128(32);
        byte[] hash = turbo.ComputeHash(input);

        Assert.That(hash, Is.EqualTo(expected));
    }

    /// <summary>
    /// RFC 9861 test vector: TurboSHAKE128(M=0xFF 0xFF 0xFF, D=0x01, 32)
    /// </summary>
    [Test]
    public void DomainSeparator01()
    {
        byte[] expected = HexToBytes("BF 32 3F 94 04 94 E8 8E E1 C5 40 FE 66 0B E8 A0 C9 3F 43 D1 5E C0 06 99 84 62 FA 99 4E ED 5D AB");
        byte[] input = new byte[] { 0xFF, 0xFF, 0xFF };

        using var turbo = new TurboShake128(32, 0x01);
        byte[] hash = turbo.ComputeHash(input);

        Assert.That(hash, Is.EqualTo(expected));
    }

    /// <summary>
    /// RFC 9861 test vector: TurboSHAKE128(M=0xFF, D=0x06, 32)
    /// </summary>
    [Test]
    public void DomainSeparator06()
    {
        byte[] expected = HexToBytes("8E C9 C6 64 65 ED 0D 4A 6C 35 D1 35 06 71 8D 68 7A 25 CB 05 C7 4C CA 1E 42 50 1A BD 83 87 4A 67");
        byte[] input = new byte[] { 0xFF };

        using var turbo = new TurboShake128(32, 0x06);
        byte[] hash = turbo.ComputeHash(input);

        Assert.That(hash, Is.EqualTo(expected));
    }

    /// <summary>
    /// Test that variable output sizes work correctly (XOF property).
    /// </summary>
    [Test]
    public void VariableOutputLength()
    {
        byte[] input = Array.Empty<byte>();

        using var turbo32 = new TurboShake128(32);
        using var turbo64 = new TurboShake128(64);

        byte[] hash32 = turbo32.ComputeHash(input);
        byte[] hash64 = turbo64.ComputeHash(input);

        Assert.That(hash32.Length, Is.EqualTo(32));
        Assert.That(hash64.Length, Is.EqualTo(64));
        // First 32 bytes of 64-byte output should match 32-byte output (XOF property)
        Assert.That(hash64.AsSpan(0, 32).ToArray(), Is.EqualTo(hash32));
    }

    /// <summary>
    /// Test the algorithm name property.
    /// </summary>
    [Test]
    public void AlgorithmNameIsCorrect()
    {
        using var turbo = TurboShake128.Create();
        Assert.That(turbo.AlgorithmName, Is.EqualTo("TurboSHAKE128"));
    }

    /// <summary>
    /// Test block size property.
    /// </summary>
    [Test]
    public void BlockSizeIsCorrect()
    {
        using var turbo = TurboShake128.Create();
        Assert.That(turbo.BlockSize, Is.EqualTo(168)); // Rate of 1344 bits = 168 bytes
    }

    /// <summary>
    /// Test that invalid output size throws.
    /// </summary>
    [Test]
    public void InvalidOutputSizeThrows()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => TurboShake128.Create(0));
        Assert.Throws<ArgumentOutOfRangeException>(() => TurboShake128.Create(-1));
    }

    /// <summary>
    /// Test that invalid domain separator throws.
    /// </summary>
    [Test]
    public void InvalidDomainSeparatorThrows()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => new TurboShake128(32, 0x00));
        Assert.Throws<ArgumentOutOfRangeException>(() => new TurboShake128(32, 0x80));
        Assert.Throws<ArgumentOutOfRangeException>(() => new TurboShake128(32, 0xFF));
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
