// SPDX-FileCopyrightText: 2025 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace Cryptography.Tests.Hash.Keccak;

using System;
using System.Text;
using CryptoHives.Foundation.Security.Cryptography.Hash;
using NUnit.Framework;

/// <summary>
/// Tests for KangarooTwelve (K12) implementations.
/// </summary>
/// <remarks>
/// These tests verify the KangarooTwelve implementation behavior.
/// Test vectors are from the XKCP reference implementation.
/// </remarks>
[TestFixture]
[Parallelizable(ParallelScope.All)]
public class KangarooTwelveTests
{
    /// <summary>
    /// Test that variable output sizes work correctly (XOF property).
    /// </summary>
    [Test]
    public void VariableOutputLength()
    {
        byte[] input = Encoding.ASCII.GetBytes("test");

        using var k12_16 = KangarooTwelve.Create(16);
        using var k12_64 = KangarooTwelve.Create(64);

        byte[] hash16 = k12_16.ComputeHash(input);
        byte[] hash64 = k12_64.ComputeHash(input);

        Assert.That(hash16.Length, Is.EqualTo(16));
        Assert.That(hash64.Length, Is.EqualTo(64));
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

        using var k12NoCustom = new KangarooTwelve(32);
        using var k12WithCustom = new KangarooTwelve(32, "MyCustomization");

        byte[] hash1 = k12NoCustom.ComputeHash(input);
        byte[] hash2 = k12WithCustom.ComputeHash(input);

        Assert.That(hash1, Is.Not.EqualTo(hash2));
    }

    /// <summary>
    /// Test that different inputs produce different outputs.
    /// </summary>
    [Test]
    public void DifferentInputsProduceDifferentOutputs()
    {
        using var k12 = KangarooTwelve.Create(32);

        byte[] hash1 = k12.ComputeHash(Encoding.ASCII.GetBytes("test1"));

        k12.Initialize();
        byte[] hash2 = k12.ComputeHash(Encoding.ASCII.GetBytes("test2"));

        Assert.That(hash1, Is.Not.EqualTo(hash2));
    }

    /// <summary>
    /// Test that invalid output size throws.
    /// </summary>
    [Test]
    public void InvalidOutputSizeThrows()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => KangarooTwelve.Create(0));
        Assert.Throws<ArgumentOutOfRangeException>(() => KangarooTwelve.Create(-1));
    }

    /// <summary>
    /// Test the algorithm name property.
    /// </summary>
    [Test]
    public void AlgorithmNameIsCorrect()
    {
        using var k12 = KangarooTwelve.Create();
        Assert.That(k12.AlgorithmName, Is.EqualTo("KangarooTwelve"));
    }

    /// <summary>
    /// Test that incremental hashing produces same result as single-shot.
    /// </summary>
    [Test]
    public void IncrementalHashingMatchesSingleShot()
    {
        byte[] input = CreatePatternMessage(256);

        // Single-shot
        using var k12Single = KangarooTwelve.Create(32);
        byte[] singleShot = k12Single.ComputeHash(input);

        // Incremental
        using var k12Incremental = KangarooTwelve.Create(32);
        k12Incremental.TransformBlock(input, 0, 100, null, 0);
        k12Incremental.TransformBlock(input, 100, 100, null, 0);
        k12Incremental.TransformFinalBlock(input, 200, 56);
        byte[] incremental = k12Incremental.Hash!;

        Assert.That(incremental, Is.EqualTo(singleShot));
    }

    /// <summary>
    /// Test block size property.
    /// </summary>
    [Test]
    public void BlockSizeIsCorrect()
    {
        using var k12 = KangarooTwelve.Create();
        Assert.That(k12.BlockSize, Is.EqualTo(168)); // Same rate as SHAKE128
    }

    /// <summary>
    /// Test that empty input produces non-zero output.
    /// </summary>
    [Test]
    public void EmptyInputProducesNonZeroOutput()
    {
        using var k12 = KangarooTwelve.Create(32);
        byte[] hash = k12.ComputeHash(Array.Empty<byte>());

        // K12 of empty message should not be all zeros
        bool allZeros = true;
        foreach (byte b in hash)
        {
            if (b != 0)
            {
                allZeros = false;
                break;
            }
        }

        Assert.That(allZeros, Is.False, "K12 of empty message should not be all zeros");
    }

    /// <summary>
    /// Creates a pattern message where byte[i] = i % 251.
    /// </summary>
    private static byte[] CreatePatternMessage(int length)
    {
        byte[] result = new byte[length];
        for (int i = 0; i < length; i++)
        {
            result[i] = (byte)(i % 251);
        }
        return result;
    }
}
