// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace Cryptography.Tests.Benchmarks;

using BenchmarkDotNet.Attributes;
using NUnit.Framework;
using CryptoHives.Foundation.Security.Cryptography.Cipher;
using System;

/// <summary>
/// Base class for AEAD (Authenticated Encryption with Associated Data) cipher benchmarks.
/// </summary>
/// <remarks>
/// <para>
/// This class provides common setup and teardown for AEAD cipher benchmarks,
/// including deterministic key/nonce/AAD generation for reproducible results.
/// </para>
/// <para>
/// AEAD ciphers operate differently from traditional block ciphers:
/// - They use nonces instead of IVs
/// - They produce authentication tags
/// - They support additional authenticated data (AAD)
/// </para>
/// </remarks>
public abstract class AeadBenchmarkBase
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
    private byte[] _tag = null!;
    private byte[] _nonce = null!;
    private byte[] _aad = null!;

    /// <summary>
    /// Gets or sets the input data size in bytes.
    /// </summary>
    protected int Bytes { get; set; } = DataSize.K8.Bytes;

    /// <summary>
    /// Gets or sets the AEAD cipher algorithm instance to benchmark.
    /// </summary>
    /// <remarks>
    /// Derived classes must set this before calling base <see cref="GlobalSetup"/>.
    /// </remarks>
    protected IAeadCipher? AeadCipher { get; set; }

    /// <summary>
    /// Gets the plaintext input data for encryption benchmarks.
    /// </summary>
    protected byte[] InputData => _inputData;

    /// <summary>
    /// Gets the output buffer for benchmark operations.
    /// </summary>
    protected byte[] OutputData => _outputData;

    /// <summary>
    /// Gets the pre-encrypted ciphertext for decryption benchmarks.
    /// </summary>
    protected byte[] EncryptedData => _encryptedData;

    /// <summary>
    /// Gets the authentication tag.
    /// </summary>
    protected byte[] Tag => _tag;

    /// <summary>
    /// Gets the nonce/IV.
    /// </summary>
    protected byte[] Nonce => _nonce;

    /// <summary>
    /// Gets the additional authenticated data (AAD).
    /// </summary>
    protected byte[] Aad => _aad;

    /// <summary>
    /// Performs global setup for the benchmark.
    /// Derived classes must call this from their [GlobalSetup] method after setting AeadCipher and Bytes.
    /// </summary>
    /// <remarks>
    /// Generates deterministic test data, nonce, and AAD.
    /// Also pre-encrypts data for decryption benchmarks.
    /// </remarks>
    [OneTimeSetUp]
    public virtual void GlobalSetup()
    {
        if (AeadCipher == null)
        {
            throw new InvalidOperationException("AeadCipher must be set before calling base GlobalSetup.");
        }

        var random = new Random(RandomSeed);

        // Generate deterministic input data
        _inputData = new byte[Bytes];
        random.NextBytes(_inputData);

        // Generate deterministic nonce
        _nonce = new byte[AeadCipher.NonceSizeBytes];
        random.NextBytes(_nonce);

        // Generate deterministic AAD (16 bytes - typical for TLS/IPsec headers)
        _aad = new byte[16];
        random.NextBytes(_aad);

        // Allocate tag buffer
        _tag = new byte[AeadCipher.TagSizeBytes];

        // Pre-encrypt data for decryption benchmarks
        _encryptedData = new byte[_inputData.Length];
        AeadCipher.Encrypt(_nonce, _inputData, _encryptedData, _tag, _aad);

        // Allocate output buffer (same size as input, no padding for AEAD)
        _outputData = new byte[_inputData.Length];
    }

    /// <summary>
    /// Performs cleanup after the benchmark completes.
    /// </summary>
    [OneTimeTearDown]
    [GlobalCleanup]
    public virtual void GlobalCleanup()
    {
        AeadCipher?.Dispose();

        // Clear sensitive data
        if (_nonce != null) Array.Clear(_nonce, 0, _nonce.Length);
        if (_aad != null) Array.Clear(_aad, 0, _aad.Length);
        if (_tag != null) Array.Clear(_tag, 0, _tag.Length);
    }

    /// <summary>
    /// Increments the nonce before each test iteration (NUnit only).
    /// </summary>
    /// <remarks>
    /// BouncyCastle GCM throws "cannot reuse nonce" if the same nonce is used twice.
    /// We increment the nonce for each test iteration to avoid this.
    /// Note: [IterationSetup] is intentionally NOT used because it forces InvocationCount=1,
    /// which results in poor benchmark measurements. For benchmarks, use IncrementNonce()
    /// at the start of the benchmark method.
    /// </remarks>
    [SetUp]
    public virtual void TestSetup()
    {
        IncrementNonce();
    }

    /// <summary>
    /// Increments the nonce by one (with carry).
    /// </summary>
    /// <remarks>
    /// Call this at the start of each benchmark method to ensure unique nonces
    /// for implementations that enforce nonce uniqueness (e.g., BouncyCastle).
    /// The overhead is negligible (~1-2 ns) compared to cipher operations.
    /// </remarks>
    protected void IncrementNonce()
    {
        // Skip if not yet initialized
        if (_nonce == null)
            return;

        // Increment nonce (big-endian with carry)
        // Use unchecked to allow byte overflow (255 + 1 = 0 with carry)
        unchecked
        {
            for (int i = _nonce.Length - 1; i >= 0; i--)
            {
                if (++_nonce[i] != 0)
                    break;
            }
        }
    }
}
