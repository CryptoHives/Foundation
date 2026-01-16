// SPDX-FileCopyrightText: 2025 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace Cryptography.Tests.Hash.Keccak;

using System;
using System.Text;
using Cryptography.Tests.Hash;
using CryptoHives.Foundation.Security.Cryptography.Hash;
using NUnit.Framework;

/// <summary>
/// Tests for TurboSHAKE256 per RFC 9861.
/// </summary>
/// <remarks>
/// Test vectors are from RFC 9861 Section 5.
/// </remarks>
[TestFixture]
[Parallelizable(ParallelScope.All)]
public class TurboShake256Tests
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
    /// RFC 9861 test vector: TurboSHAKE256(M=empty, D=1F, 64)
    /// </summary>
    [TestCaseSource(typeof(TurboShake256Implementations), nameof(TurboShake256Implementations.All))]
    public void EmptyInputDefaultCustomization64Bytes(HashAlgorithmFactory factory)
    {
        byte[] expected = HexToBytes(
            "36 7A 32 9D AF EA 87 1C 78 02 EC 67 F9 05 AE 13 C5 76 95 DC 2C 66 63 C6 10 35 F5 9A 18 F8 E7 DB " +
            "11 ED C0 E1 2E 91 EA 60 EB 6B 32 DF 06 DD 7F 00 2F BA FA BB 6E 13 EC 1C C2 0D 99 55 47 60 0D B0");

        using var ts256 = factory.Create();
        byte[] hash = ts256.ComputeHash(Array.Empty<byte>());

        Assert.That(hash, Is.EqualTo(expected));
    }

    /// <summary>
    /// RFC 9861 test vector: TurboSHAKE256(M=ptn(1), D=1F, 64)
    /// </summary>
    [TestCaseSource(typeof(TurboShake256Implementations), nameof(TurboShake256Implementations.All))]
    public void Pattern1ByteDefaultCustomization(HashAlgorithmFactory factory)
    {
        byte[] expected = HexToBytes(
            "3E 17 12 F9 28 F8 EA F1 05 46 32 B2 AA 0A 24 6E D8 B0 C3 78 72 8F 60 BC 97 04 10 15 5C 28 82 0E " +
            "90 CC 90 D8 A3 00 6A A2 37 2C 5C 5E A1 76 B0 68 2B F2 2B AE 74 67 AC 94 F7 4D 43 D3 9B 04 82 E2");
        byte[] input = CreatePattern(1);

        using var ts256 = factory.Create();
        byte[] hash = ts256.ComputeHash(input);

        Assert.That(hash, Is.EqualTo(expected));
    }

    /// <summary>
    /// RFC 9861 test vector: TurboSHAKE256(M=ptn(17), D=1F, 64)
    /// </summary>
    [TestCaseSource(typeof(TurboShake256Implementations), nameof(TurboShake256Implementations.All))]
    public void Pattern17BytesDefaultCustomization(HashAlgorithmFactory factory)
    {
        byte[] expected = HexToBytes(
            "B3 BA B0 30 0E 6A 19 1F BE 61 37 93 98 35 92 35 78 79 4E A5 48 43 F5 01 10 90 FA 2F 37 80 A9 E5 " +
            "CB 22 C5 9D 78 B4 0A 0F BF F9 E6 72 C0 FB E0 97 0B D2 C8 45 09 1C 60 44 D6 87 05 4D A5 D8 E9 C7");
        byte[] input = CreatePattern(17);

        using var ts256 = factory.Create();
        byte[] hash = ts256.ComputeHash(input);

        Assert.That(hash, Is.EqualTo(expected));
    }

    /// <summary>
    /// Test that variable output sizes work correctly (XOF property).
    /// </summary>
    [Test]
    public void VariableOutputLength()
    {
        byte[] input = Encoding.ASCII.GetBytes("test");

        using var ts256_32 = TurboShake256.Create(32);
        using var ts256_64 = TurboShake256.Create(64);

        byte[] hash32 = ts256_32.ComputeHash(input);
        byte[] hash64 = ts256_64.ComputeHash(input);

        Assert.That(hash32, Has.Length.EqualTo(32));
        Assert.That(hash64, Has.Length.EqualTo(64));
        
        Assert.That(hash64.AsSpan(0, 32).ToArray(), Is.EqualTo(hash32));
    }

    /// <summary>
    /// Test the algorithm name property.
    /// </summary>
    [Test]
    public void AlgorithmNameIsCorrect()
    {
        using var ts256 = TurboShake256.Create();
        Assert.That(ts256.AlgorithmName, Is.EqualTo("TurboSHAKE256"));
    }

    /// <summary>
    /// Test block size property.
    /// </summary>
    [Test]
    public void BlockSizeIsCorrect()
    {
        using var ts256 = TurboShake256.Create();
        Assert.That(ts256.BlockSize, Is.EqualTo(136));
    }
}
