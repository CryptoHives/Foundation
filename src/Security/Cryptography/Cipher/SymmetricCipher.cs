// SPDX-FileCopyrightText: 2025 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Security.Cryptography.Cipher;

using System;
using System.Security.Cryptography;

#if NETSTANDARD2_0 || NET462 || NET48
using CryptoHives.Foundation.Security.Cryptography.Cipher.Compat;
#endif

/// <summary>
/// Base class for CryptoHives clean-room symmetric cipher implementations.
/// </summary>
/// <remarks>
/// <para>
/// This class provides a common base for all CryptoHives symmetric cipher implementations.
/// It ensures consistent behavior and provides helper methods for derived implementations.
/// </para>
/// <para>
/// All derived classes implement cipher algorithms without OS or hardware dependencies,
/// providing deterministic behavior across all platforms. However, implementations may
/// optionally use hardware intrinsics (AES-NI, ARM Crypto) when available for performance.
/// </para>
/// <para>
/// <b>Usage pattern:</b>
/// <code>
/// using var aes = Aes256.Create();
/// aes.Key = key;
/// aes.IV = iv;
///
/// using var encryptor = aes.CreateEncryptor();
/// byte[] ciphertext = encryptor.TransformFinalBlock(plaintext, 0, plaintext.Length);
/// </code>
/// </para>
/// </remarks>
public abstract class SymmetricCipher : IDisposable
{
    private byte[]? _key;
    private byte[]? _iv;
    private bool _disposed;

    /// <summary>
    /// Gets the name of the cipher algorithm.
    /// </summary>
    /// <example>
    /// "AES-256", "ChaCha20", "AES-256-GCM"
    /// </example>
    public abstract string AlgorithmName { get; }

    /// <summary>
    /// Gets the block size in bits.
    /// </summary>
    /// <remarks>
    /// For AES, this is always 128 bits (16 bytes).
    /// For stream ciphers like ChaCha20, this returns 0 or the internal block size.
    /// </remarks>
    public abstract int BlockSize { get; }

    /// <summary>
    /// Gets the key size in bits.
    /// </summary>
    /// <remarks>
    /// Common values: 128, 192, or 256 bits for AES; 256 bits for ChaCha20.
    /// </remarks>
    public abstract int KeySize { get; }

    /// <summary>
    /// Gets the valid key sizes for this algorithm.
    /// </summary>
    public abstract KeySizes[] LegalKeySizes { get; }

    /// <summary>
    /// Gets the valid block sizes for this algorithm.
    /// </summary>
    public abstract KeySizes[] LegalBlockSizes { get; }

    /// <summary>
    /// Gets or sets the initialization vector (IV) or nonce for the cipher operation.
    /// </summary>
    /// <remarks>
    /// <para>
    /// The IV/nonce size depends on the algorithm and mode:
    /// <list type="bullet">
    ///   <item><description>AES-CBC: 16 bytes (block size)</description></item>
    ///   <item><description>AES-GCM: 12 bytes (recommended) or variable</description></item>
    ///   <item><description>ChaCha20: 12 bytes</description></item>
    ///   <item><description>XChaCha20: 24 bytes</description></item>
    /// </list>
    /// </para>
    /// <para>
    /// <b>Important:</b> Never reuse an IV/nonce with the same key.
    /// For GCM/Poly1305, nonce reuse completely compromises security.
    /// </para>
    /// </remarks>
    /// <exception cref="ArgumentNullException">Value is null.</exception>
    /// <exception cref="CryptographicException">Value has an invalid size.</exception>
    public virtual byte[]? IV
    {
        get => _iv?.Clone() as byte[];
        set
        {
            if (value != null)
            {
                ValidateIVSize(value.Length);
                _iv = (byte[])value.Clone();
            }
            else
            {
                _iv = null;
            }
        }
    }

    /// <summary>
    /// Gets or sets the secret key for the cipher operation.
    /// </summary>
    /// <exception cref="ArgumentNullException">Value is null.</exception>
    /// <exception cref="CryptographicException">Value has an invalid size.</exception>
    public virtual byte[]? Key
    {
        get => _key?.Clone() as byte[];
        set
        {
            if (value != null)
            {
                ValidateKeySize(value.Length * 8);
                _key = (byte[])value.Clone();
            }
            else
            {
                _key = null;
            }
        }
    }

    /// <summary>
    /// Gets or sets the cipher mode of operation.
    /// </summary>
    public virtual CipherMode Mode { get; set; } = CipherMode.Cbc;

    /// <summary>
    /// Gets or sets the padding mode.
    /// </summary>
    public virtual PaddingMode Padding { get; set; } = PaddingMode.Pkcs7;

    /// <summary>
    /// Gets the required IV/nonce size in bytes for the current mode.
    /// </summary>
    public abstract int IVSize { get; }

    /// <summary>
    /// Gets the authentication tag size in bytes for AEAD modes.
    /// </summary>
    /// <remarks>
    /// Returns 0 for non-AEAD modes. For GCM, common values are 12, 13, 14, 15, or 16 bytes.
    /// </remarks>
    public virtual int TagSize => 0;

    /// <summary>
    /// Gets a value indicating whether this cipher provides authenticated encryption.
    /// </summary>
    public virtual bool IsAuthenticated => Mode is CipherMode.Gcm or CipherMode.Ccm;

    /// <summary>
    /// Initializes a new instance of the <see cref="SymmetricCipher"/> class.
    /// </summary>
    protected SymmetricCipher()
    {
    }

    /// <summary>
    /// Generates a random key appropriate for this algorithm.
    /// </summary>
    public virtual void GenerateKey()
    {
        _key = new byte[KeySize / 8];
        using var rng = RandomNumberGenerator.Create();
        rng.GetBytes(_key);
    }

    /// <summary>
    /// Generates a random IV/nonce appropriate for this algorithm and mode.
    /// </summary>
    public virtual void GenerateIV()
    {
        _iv = new byte[IVSize];
        using var rng = RandomNumberGenerator.Create();
        rng.GetBytes(_iv);
    }

    /// <summary>
    /// Creates an encryptor transform using the current key and IV.
    /// </summary>
    /// <returns>A new encryptor transform.</returns>
    /// <exception cref="CryptographicException">Key or IV is not set.</exception>
    public ICipherTransform CreateEncryptor()
    {
        return CreateEncryptor(GetKeyOrThrow(), GetIVOrThrow());
    }

    /// <summary>
    /// Creates an encryptor transform using the specified key and IV.
    /// </summary>
    /// <param name="key">The secret key.</param>
    /// <param name="iv">The initialization vector or nonce.</param>
    /// <returns>A new encryptor transform.</returns>
    public abstract ICipherTransform CreateEncryptor(byte[] key, byte[] iv);

    /// <summary>
    /// Creates a decryptor transform using the current key and IV.
    /// </summary>
    /// <returns>A new decryptor transform.</returns>
    /// <exception cref="CryptographicException">Key or IV is not set.</exception>
    public ICipherTransform CreateDecryptor()
    {
        return CreateDecryptor(GetKeyOrThrow(), GetIVOrThrow());
    }

    /// <summary>
    /// Creates a decryptor transform using the specified key and IV.
    /// </summary>
    /// <param name="key">The secret key.</param>
    /// <param name="iv">The initialization vector or nonce.</param>
    /// <returns>A new decryptor transform.</returns>
    public abstract ICipherTransform CreateDecryptor(byte[] key, byte[] iv);

    /// <summary>
    /// Encrypts plaintext in a single operation.
    /// </summary>
    /// <param name="plaintext">The data to encrypt.</param>
    /// <returns>The encrypted ciphertext.</returns>
    /// <remarks>
    /// This is a convenience method that creates an encryptor, transforms the data,
    /// and disposes the encryptor. For multiple operations, reuse <see cref="CreateEncryptor()"/>.
    /// </remarks>
    public virtual byte[] Encrypt(ReadOnlySpan<byte> plaintext)
    {
        using var encryptor = CreateEncryptor();

        // Calculate output size (includes padding for block ciphers)
        int outputSize = CalculateOutputSize(plaintext.Length, encrypting: true);
        byte[] output = new byte[outputSize];

        int written = encryptor.TransformFinalBlock(plaintext, output);

        if (written != output.Length)
        {
            Array.Resize(ref output, written);
        }

        return output;
    }

    /// <summary>
    /// Decrypts ciphertext in a single operation.
    /// </summary>
    /// <param name="ciphertext">The data to decrypt.</param>
    /// <returns>The decrypted plaintext.</returns>
    public virtual byte[] Decrypt(ReadOnlySpan<byte> ciphertext)
    {
        using var decryptor = CreateDecryptor();

        // Allocate max possible size (ciphertext size, padding will reduce)
        byte[] output = new byte[ciphertext.Length];

        int written = decryptor.TransformFinalBlock(ciphertext, output);

        if (written != output.Length)
        {
            Array.Resize(ref output, written);
        }

        return output;
    }

    /// <summary>
    /// Calculates the output buffer size required for the given input size.
    /// </summary>
    /// <param name="inputLength">The input data length in bytes.</param>
    /// <param name="encrypting">True if encrypting, false if decrypting.</param>
    /// <returns>The required output buffer size in bytes.</returns>
    protected virtual int CalculateOutputSize(int inputLength, bool encrypting)
    {
        if (Mode is CipherMode.Stream or CipherMode.Ctr or CipherMode.Gcm or CipherMode.Ccm)
        {
            // Stream modes and AEAD modes don't use padding
            return encrypting ? inputLength + TagSize : inputLength - TagSize;
        }

        if (Padding == PaddingMode.None)
        {
            return inputLength;
        }

        // Block modes with padding
        int blockSizeBytes = BlockSize / 8;
        if (encrypting)
        {
            // PKCS#7 always adds at least one byte of padding
            return ((inputLength / blockSizeBytes) + 1) * blockSizeBytes;
        }
        else
        {
            // When decrypting, output will be at most input size (minus padding)
            return inputLength;
        }
    }

    /// <summary>
    /// Validates that the specified key size is valid for this algorithm.
    /// </summary>
    /// <param name="bitLength">The key size in bits.</param>
    /// <exception cref="CryptographicException">The key size is invalid.</exception>
    protected void ValidateKeySize(int bitLength)
    {
        foreach (var sizes in LegalKeySizes)
        {
            if (bitLength >= sizes.MinSize && bitLength <= sizes.MaxSize)
            {
                if (sizes.SkipSize == 0 || (bitLength - sizes.MinSize) % sizes.SkipSize == 0)
                {
                    return;
                }
            }
        }

        throw new CryptographicException($"Invalid key size: {bitLength} bits. Valid sizes: {FormatKeySizes(LegalKeySizes)}");
    }

    /// <summary>
    /// Validates that the specified IV size is valid for this algorithm and mode.
    /// </summary>
    /// <param name="byteLength">The IV size in bytes.</param>
    /// <exception cref="CryptographicException">The IV size is invalid.</exception>
    protected virtual void ValidateIVSize(int byteLength)
    {
        if (byteLength != IVSize)
        {
            throw new CryptographicException($"Invalid IV size: {byteLength} bytes. Expected: {IVSize} bytes.");
        }
    }

    /// <summary>
    /// Clears sensitive data from memory.
    /// </summary>
    /// <param name="data">The data to clear.</param>
    protected static void ClearSensitiveData(byte[]? data)
    {
        if (data != null)
        {
            CryptographicOperations.ZeroMemory(data);
        }
    }

    /// <summary>
    /// Gets the current key or throws if not set.
    /// </summary>
    protected byte[] GetKeyOrThrow()
    {
        return _key ?? throw new CryptographicException("Key has not been set.");
    }

    /// <summary>
    /// Gets the current IV or throws if not set.
    /// </summary>
    protected byte[] GetIVOrThrow()
    {
        return _iv ?? throw new CryptographicException("IV/nonce has not been set.");
    }

    private static string FormatKeySizes(KeySizes[] sizes)
    {
        var parts = new System.Collections.Generic.List<string>();
        foreach (var size in sizes)
        {
            if (size.MinSize == size.MaxSize)
            {
                parts.Add($"{size.MinSize}");
            }
            else if (size.SkipSize == 0)
            {
                parts.Add($"{size.MinSize}-{size.MaxSize}");
            }
            else
            {
                parts.Add($"{size.MinSize}-{size.MaxSize} (step {size.SkipSize})");
            }
        }
        return string.Join(", ", parts);
    }

    /// <summary>
    /// Releases all resources used by this instance.
    /// </summary>
    public void Dispose()
    {
        Dispose(disposing: true);
        GC.SuppressFinalize(this);
    }

    /// <summary>
    /// Releases resources used by this instance.
    /// </summary>
    /// <param name="disposing">True if called from Dispose(), false if from finalizer.</param>
    protected virtual void Dispose(bool disposing)
    {
        if (!_disposed)
        {
            if (disposing)
            {
                ClearSensitiveData(_key);
                ClearSensitiveData(_iv);
                _key = null;
                _iv = null;
            }

            _disposed = true;
        }
    }
}
