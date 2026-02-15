// SPDX-FileCopyrightText: 2025 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace Cryptography.Tests.Benchmarks;

using BenchmarkDotNet.Attributes;
using NUnit.Framework;
using System;

/// <summary>
/// Base class for symmetric cipher benchmarks with deterministic test data.
/// </summary>
/// <remarks>
/// <para>
/// This class provides common setup and teardown for cipher benchmarks,
/// including deterministic key/IV/data generation for reproducible results.
/// </para>
/// <para>
/// Derived classes should set <see cref="CipherAlgorithm"/> in their
/// <see cref="GlobalSetup"/> override before calling the base implementation.
/// </para>
/// </remarks>
public abstract class CipherBenchmarkBase
{
    /// <summary>
    /// Random seed for deterministic test data generation.
    /// </summary>
    /// <remarks>
    /// Using "Cryp" as ASCII bytes: 0x43 0x72 0x79 0x70
    /// </remarks>
    private const int RandomSeed = 0x43727970;

    private byte[] _inputData = null!;
    private byte[] _outputData = null!;
    private byte[] _encryptedData = null!;
    private byte[] _key = null!;
    private byte[] _iv = null!;

    /// <summary>
    /// Gets or sets the input data size in bytes.
    /// </summary>
    protected int Bytes { get; set; } = DataSize.K8.Bytes;

    /// <summary>
    /// Gets or sets the cipher algorithm instance to benchmark.
    /// </summary>
    /// <remarks>
    /// Derived classes must set this before calling base <see cref="GlobalSetup"/>.
    /// </remarks>
    protected CryptoHives.Foundation.Security.Cryptography.Cipher.SymmetricCipher? CipherAlgorithm { get; set; }

    /// <summary>
    /// Gets the plaintext input data for encryption benchmarks.
    /// </summary>
    protected byte[] InputData => _inputData;

    /// <summary>
    /// Gets the output buffer for benchmark operations.
    /// </summary>
    protected byte[] OutputData => _outputData;

    /// <summary>
    /// Gets the pre-encrypted data for decryption benchmarks.
    /// </summary>
    protected byte[] EncryptedData => _encryptedData;

    /// <summary>
    /// Gets the cryptographic key.
    /// </summary>
    protected byte[] Key => _key;

    /// <summary>
    /// Gets the initialization vector or nonce.
    /// </summary>
    protected byte[] IV => _iv;

    /// <summary>
    /// Gets or sets the encryptor transform for reuse across benchmark iterations.
    /// </summary>
    protected CryptoHives.Foundation.Security.Cryptography.Cipher.ICipherTransform? Encryptor { get; set; }

    /// <summary>
    /// Gets or sets the decryptor transform for reuse across benchmark iterations.
    /// </summary>
    protected CryptoHives.Foundation.Security.Cryptography.Cipher.ICipherTransform? Decryptor { get; set; }

    /// <summary>
    /// Performs global setup for the benchmark.
    /// </summary>
    /// <remarks>
    /// Generates deterministic test data, key, and IV.
    /// Also pre-encrypts data for decryption benchmarks.
    /// </remarks>
    [OneTimeSetUp]
    [GlobalSetup]
    public virtual void GlobalSetup()
    {
        if (CipherAlgorithm == null)
        {
            throw new InvalidOperationException("CipherAlgorithm must be set before calling base GlobalSetup.");
        }

        var random = new Random(RandomSeed);

        // Generate deterministic input data
        _inputData = new byte[Bytes];
        random.NextBytes(_inputData);

        // Generate deterministic key
        _key = new byte[CipherAlgorithm.KeySize / 8];
        random.NextBytes(_key);

        // Generate deterministic IV/nonce
        _iv = new byte[CipherAlgorithm.IVSize];
        random.NextBytes(_iv);

        // Set key and IV on the cipher
        CipherAlgorithm.Key = _key;
        CipherAlgorithm.IV = _iv;

        // Pre-encrypt data for decryption benchmarks
        _encryptedData = CipherAlgorithm.Encrypt(_inputData);

        // Allocate output buffer (max of plaintext or ciphertext size)
        int maxSize = Math.Max(_inputData.Length, _encryptedData.Length);
        _outputData = new byte[maxSize + CipherAlgorithm.BlockSize / 8]; // Extra block for padding

        // Create reusable transforms
        Encryptor = CipherAlgorithm.CreateEncryptor();
        Decryptor = CipherAlgorithm.CreateDecryptor();
    }

    /// <summary>
    /// Performs cleanup after the benchmark completes.
    /// </summary>
    [OneTimeTearDown]
    [GlobalCleanup]
    public virtual void GlobalCleanup()
    {
        Encryptor?.Dispose();
        Decryptor?.Dispose();
        CipherAlgorithm?.Dispose();

        // Clear sensitive data
        if (_key != null) Array.Clear(_key, 0, _key.Length);
        if (_iv != null) Array.Clear(_iv, 0, _iv.Length);
    }

    /// <summary>
    /// Resets the encryptor transform between iterations if needed.
    /// </summary>
    [IterationSetup]
    public virtual void IterationSetup()
    {
        Encryptor?.Reset();
        Decryptor?.Reset();
    }
}
