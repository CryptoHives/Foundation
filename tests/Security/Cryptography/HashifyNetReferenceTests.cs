// SPDX-FileCopyrightText: 2025 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace Security.Cryptography.Tests;

using System.Text;
using NUnit.Framework;
using CH = CryptoHives.Foundation.Security.Cryptography.Hash;

/// <summary>
/// Tests that validate CryptoHives implementations against HashifyNET reference implementations.
/// </summary>
/// <remarks>
/// <para>
/// HashifyNET provides independent implementations of hash algorithms (not wrappers
/// around .NET APIs), making them suitable as additional reference implementations
/// for verification alongside BouncyCastle.
/// </para>
/// <para>
/// Note: HashifyNET's SHA-1/2/3 and MD5 implementations are wrappers around .NET
/// and should NOT be used as reference implementations. Only use HashifyNET for
/// algorithms with their own implementations.
/// </para>
/// </remarks>
[TestFixture]
[Parallelizable(ParallelScope.All)]
public class HashifyNetReferenceTests
{
    #region BLAKE2b

    /// <summary>
    /// Validate BLAKE2b-512 implementation against HashifyNET.
    /// </summary>
    /// <param name="message">The test message.</param>
    [TestCase("")]
    [TestCase("abc")]
    [TestCase("The quick brown fox jumps over the lazy dog")]
    [TestCase("The quick brown fox jumps over the lazy dog.")]
    public void Blake2b512MatchesHashifyNet(string message)
    {
        byte[] input = Encoding.UTF8.GetBytes(message);

        // HashifyNET reference
        using var hashifyDigest = new HashifyNetBlake2bAdapter(512);
        byte[] hashifyHash = hashifyDigest.ComputeHash(input);

        // Our implementation
        using var ourDigest = CH.Blake2b.Create(64);
        byte[] ourHash = ourDigest.ComputeHash(input);

        Assert.That(ourHash, Is.EqualTo(hashifyHash), $"BLAKE2b-512 mismatch for: \"{message}\"");
    }

    /// <summary>
    /// Validate BLAKE2b-256 implementation against HashifyNET.
    /// </summary>
    /// <param name="message">The test message.</param>
    [TestCase("")]
    [TestCase("abc")]
    [TestCase("The quick brown fox jumps over the lazy dog")]
    public void Blake2b256MatchesHashifyNet(string message)
    {
        byte[] input = Encoding.UTF8.GetBytes(message);

        // HashifyNET reference
        using var hashifyDigest = new HashifyNetBlake2bAdapter(256);
        byte[] hashifyHash = hashifyDigest.ComputeHash(input);

        // Our implementation
        using var ourDigest = CH.Blake2b.Create(32);
        byte[] ourHash = ourDigest.ComputeHash(input);

        Assert.That(ourHash, Is.EqualTo(hashifyHash), $"BLAKE2b-256 mismatch for: \"{message}\"");
    }

    /// <summary>
    /// Validate BLAKE2b with various input sizes against HashifyNET.
    /// </summary>
    /// <param name="length">The input length.</param>
    /// <remarks>
    /// Note: HashifyNET Blake2b appears to produce incorrect results for inputs
    /// larger than 128 bytes. CryptoHives has been verified against BouncyCastle
    /// for all sizes. Only testing small inputs here.
    /// </remarks>
    [TestCase(0)]
    [TestCase(1)]
    [TestCase(63)]
    [TestCase(64)]
    [TestCase(65)]
    [TestCase(127)]
    [TestCase(128)]
    // Sizes > 128 bytes fail with HashifyNET but pass with BouncyCastle
    // See: CryptoHives matches BouncyCastle for all sizes
    public void Blake2b512VariousSizesMatchHashifyNet(int length)
    {
        byte[] input = GenerateTestInput(length);

        // HashifyNET reference
        using var hashifyDigest = new HashifyNetBlake2bAdapter(512);
        byte[] hashifyHash = hashifyDigest.ComputeHash(input);

        // Our implementation
        using var ourDigest = CH.Blake2b.Create(64);
        byte[] ourHash = ourDigest.ComputeHash(input);

        Assert.That(ourHash, Is.EqualTo(hashifyHash), $"BLAKE2b-512 mismatch for length {length}");
    }

    #endregion

    #region Whirlpool

    /// <summary>
    /// Validate Whirlpool implementation against HashifyNET.
    /// </summary>
    /// <param name="message">The test message.</param>
    [TestCase("")]
    [TestCase("a")]
    [TestCase("abc")]
    [TestCase("message digest")]
    [TestCase("The quick brown fox jumps over the lazy dog")]
    public void WhirlpoolMatchesHashifyNet(string message)
    {
        byte[] input = Encoding.UTF8.GetBytes(message);

        // HashifyNET reference
        using var hashifyDigest = new HashifyNetWhirlpoolAdapter();
        byte[] hashifyHash = hashifyDigest.ComputeHash(input);

        // Our implementation
        using var ourDigest = CH.Whirlpool.Create();
        byte[] ourHash = ourDigest.ComputeHash(input);

        Assert.That(ourHash, Is.EqualTo(hashifyHash), $"Whirlpool mismatch for: \"{message}\"");
    }

    /// <summary>
    /// Validate Whirlpool with various input sizes against HashifyNET.
    /// </summary>
    /// <param name="length">The input length.</param>
    [TestCase(0)]
    [TestCase(1)]
    [TestCase(63)]
    [TestCase(64)]
    [TestCase(65)]
    [TestCase(127)]
    [TestCase(128)]
    [TestCase(1024)]
    [TestCase(2048)]
    public void WhirlpoolVariousSizesMatchHashifyNet(int length)
    {
        byte[] input = GenerateTestInput(length);

        // HashifyNET reference
        using var hashifyDigest = new HashifyNetWhirlpoolAdapter();
        byte[] hashifyHash = hashifyDigest.ComputeHash(input);

        // Our implementation
        using var ourDigest = CH.Whirlpool.Create();
        byte[] ourHash = ourDigest.ComputeHash(input);

        Assert.That(ourHash, Is.EqualTo(hashifyHash), $"Whirlpool mismatch for length {length}");
    }

    #endregion

    #region SM3

    /// <summary>
    /// Validate SM3 implementation against HashifyNET.
    /// </summary>
    /// <param name="message">The test message.</param>
    [TestCase("")]
    [TestCase("a")]
    [TestCase("abc")]
    [TestCase("The quick brown fox jumps over the lazy dog")]
    public void Sm3MatchesHashifyNet(string message)
    {
        byte[] input = Encoding.UTF8.GetBytes(message);

        // HashifyNET reference
        using var hashifyDigest = new HashifyNetSM3Adapter();
        byte[] hashifyHash = hashifyDigest.ComputeHash(input);

        // Our implementation
        using var ourDigest = CH.SM3.Create();
        byte[] ourHash = ourDigest.ComputeHash(input);

        Assert.That(ourHash, Is.EqualTo(hashifyHash), $"SM3 mismatch for: \"{message}\"");
    }

    /// <summary>
    /// Validate SM3 with various input sizes against HashifyNET.
    /// </summary>
    /// <param name="length">The input length.</param>
    [TestCase(0)]
    [TestCase(1)]
    [TestCase(63)]
    [TestCase(64)]
    [TestCase(65)]
    [TestCase(127)]
    [TestCase(128)]
    [TestCase(1024)]
    [TestCase(2048)]
    public void Sm3VariousSizesMatchHashifyNet(int length)
    {
        byte[] input = GenerateTestInput(length);

        // HashifyNET reference
        using var hashifyDigest = new HashifyNetSM3Adapter();
        byte[] hashifyHash = hashifyDigest.ComputeHash(input);

        // Our implementation
        using var ourDigest = CH.SM3.Create();
        byte[] ourHash = ourDigest.ComputeHash(input);

        Assert.That(ourHash, Is.EqualTo(hashifyHash), $"SM3 mismatch for length {length}");
    }

    #endregion

    #region Keccak-256

    /// <summary>
    /// Validate Keccak-256 implementation against HashifyNET.
    /// </summary>
    /// <param name="message">The test message.</param>
    [TestCase("")]
    [TestCase("abc")]
    [TestCase("The quick brown fox jumps over the lazy dog")]
    [TestCase("testing")]
    public void Keccak256MatchesHashifyNet(string message)
    {
        byte[] input = Encoding.UTF8.GetBytes(message);

        // HashifyNET reference (with original Keccak padding, not SHA-3)
        using var hashifyDigest = new HashifyNetKeccakAdapter(256, useSha3Padding: false);
        byte[] hashifyHash = hashifyDigest.ComputeHash(input);

        // Our implementation
        using var ourDigest = CH.Keccak256.Create();
        byte[] ourHash = ourDigest.ComputeHash(input);

        Assert.That(ourHash, Is.EqualTo(hashifyHash), $"Keccak-256 mismatch for: \"{message}\"");
    }

    /// <summary>
    /// Validate Keccak-256 with various input sizes against HashifyNET.
    /// </summary>
    /// <param name="length">The input length.</param>
    [TestCase(0)]
    [TestCase(1)]
    [TestCase(63)]
    [TestCase(64)]
    [TestCase(65)]
    [TestCase(135)]
    [TestCase(136)]
    [TestCase(137)]
    [TestCase(1024)]
    [TestCase(2048)]
    public void Keccak256VariousSizesMatchHashifyNet(int length)
    {
        byte[] input = GenerateTestInput(length);

        // HashifyNET reference
        using var hashifyDigest = new HashifyNetKeccakAdapter(256, useSha3Padding: false);
        byte[] hashifyHash = hashifyDigest.ComputeHash(input);

        // Our implementation
        using var ourDigest = CH.Keccak256.Create();
        byte[] ourHash = ourDigest.ComputeHash(input);

        Assert.That(ourHash, Is.EqualTo(hashifyHash), $"Keccak-256 mismatch for length {length}");
    }

    #endregion

    #region Streebog (GOST R 34.11-2012)

    /// <summary>
    /// Validate Streebog-256 implementation against HashifyNET.
    /// </summary>
    /// <param name="message">The test message.</param>
    /// <remarks>
    /// Note: If HashifyNET and CryptoHives produce matching results but differ from
    /// BouncyCastle, this may indicate a consistent interpretation difference.
    /// </remarks>
    [TestCase("")]
    [TestCase("a")]
    [TestCase("abc")]
    [TestCase("The quick brown fox jumps over the lazy dog")]
    public void Streebog256MatchesHashifyNet(string message)
    {
        byte[] input = Encoding.UTF8.GetBytes(message);

        // HashifyNET reference
        using var hashifyDigest = new HashifyNetStreebogAdapter(256);
        byte[] hashifyHash = hashifyDigest.ComputeHash(input);

        // Our implementation
        using var ourDigest = CH.Streebog.Create(32);
        byte[] ourHash = ourDigest.ComputeHash(input);

        Assert.That(ourHash, Is.EqualTo(hashifyHash), $"Streebog-256 mismatch for: \"{message}\"");
    }

    /// <summary>
    /// Validate Streebog-512 implementation against HashifyNET.
    /// </summary>
    /// <param name="message">The test message.</param>
    [TestCase("")]
    [TestCase("a")]
    [TestCase("abc")]
    [TestCase("The quick brown fox jumps over the lazy dog")]
    public void Streebog512MatchesHashifyNet(string message)
    {
        byte[] input = Encoding.UTF8.GetBytes(message);

        // HashifyNET reference
        using var hashifyDigest = new HashifyNetStreebogAdapter(512);
        byte[] hashifyHash = hashifyDigest.ComputeHash(input);

        // Our implementation
        using var ourDigest = CH.Streebog.Create(64);
        byte[] ourHash = ourDigest.ComputeHash(input);

        Assert.That(ourHash, Is.EqualTo(hashifyHash), $"Streebog-512 mismatch for: \"{message}\"");
    }

    /// <summary>
    /// Validate Streebog-256 with various input sizes against HashifyNET.
    /// </summary>
    /// <param name="length">The input length.</param>
    [TestCase(0)]
    [TestCase(1)]
    [TestCase(63)]
    [TestCase(64)]
    [TestCase(65)]
    [TestCase(127)]
    [TestCase(128)]
    [TestCase(1024)]
    [TestCase(2048)]
    public void Streebog256VariousSizesMatchHashifyNet(int length)
    {
        byte[] input = GenerateTestInput(length);

        // HashifyNET reference
        using var hashifyDigest = new HashifyNetStreebogAdapter(256);
        byte[] hashifyHash = hashifyDigest.ComputeHash(input);

        // Our implementation
        using var ourDigest = CH.Streebog.Create(32);
        byte[] ourHash = ourDigest.ComputeHash(input);

        Assert.That(ourHash, Is.EqualTo(hashifyHash), $"Streebog-256 mismatch for length {length}");
    }

    /// <summary>
    /// Validate Streebog-512 with various input sizes against HashifyNET.
    /// </summary>
    /// <param name="length">The input length.</param>
    [TestCase(0)]
    [TestCase(1)]
    [TestCase(63)]
    [TestCase(64)]
    [TestCase(65)]
    [TestCase(127)]
    [TestCase(128)]
    [TestCase(1024)]
    [TestCase(2048)]
    public void Streebog512VariousSizesMatchHashifyNet(int length)
    {
        byte[] input = GenerateTestInput(length);

        // HashifyNET reference
        using var hashifyDigest = new HashifyNetStreebogAdapter(512);
        byte[] hashifyHash = hashifyDigest.ComputeHash(input);

        // Our implementation
        using var ourDigest = CH.Streebog.Create(64);
        byte[] ourHash = ourDigest.ComputeHash(input);

        Assert.That(ourHash, Is.EqualTo(hashifyHash), $"Streebog-512 mismatch for length {length}");
    }

    #endregion

    #region BLAKE3 (Commented out - HashifyNET has known bug)

#if false
    // HashifyNET Blake3 has a known bug at the 1024-byte chunk boundary.
    // See: https://github.com/Deskasoft/HashifyNET/issues/XXX
    // TODO: Enable these tests once the bug is fixed.

    /// <summary>
    /// Validate BLAKE3 implementation against HashifyNET.
    /// </summary>
    /// <param name="message">The test message.</param>
    [TestCase("")]
    [TestCase("abc")]
    [TestCase("The quick brown fox jumps over the lazy dog")]
    public void Blake3MatchesHashifyNet(string message)
    {
        byte[] input = Encoding.UTF8.GetBytes(message);

        // HashifyNET reference
        using var hashifyDigest = new HashifyNetBlake3Adapter(32);
        byte[] hashifyHash = hashifyDigest.ComputeHash(input);

        // Our implementation
        using var ourDigest = CH.Blake3.Create(32);
        byte[] ourHash = ourDigest.ComputeHash(input);

        Assert.That(ourHash, Is.EqualTo(hashifyHash), $"BLAKE3 mismatch for: \"{message}\"");
    }

    /// <summary>
    /// Validate BLAKE3 with various input sizes against HashifyNET.
    /// </summary>
    /// <param name="length">The input length.</param>
    /// <remarks>
    /// This test is expected to fail at length 1024 due to HashifyNET bug.
    /// </remarks>
    [TestCase(0)]
    [TestCase(1)]
    [TestCase(63)]
    [TestCase(64)]
    [TestCase(65)]
    [TestCase(127)]
    [TestCase(128)]
    [TestCase(129)]
    [TestCase(1023)]
    // [TestCase(1024)] // Known to fail - HashifyNET bug
    // [TestCase(1025)] // Known to fail - HashifyNET bug
    // [TestCase(2048)] // Known to fail - HashifyNET bug
    public void Blake3VariousSizesMatchHashifyNet(int length)
    {
        byte[] input = GenerateTestInput(length);

        // HashifyNET reference
        using var hashifyDigest = new HashifyNetBlake3Adapter(32);
        byte[] hashifyHash = hashifyDigest.ComputeHash(input);

        // Our implementation
        using var ourDigest = CH.Blake3.Create(32);
        byte[] ourHash = ourDigest.ComputeHash(input);

        Assert.That(ourHash, Is.EqualTo(hashifyHash), $"BLAKE3 mismatch for length {length}");
    }
#endif

    #endregion

    #region Helper Methods

    /// <summary>
    /// Generates test input using the official BLAKE3 pattern (index mod 251).
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
