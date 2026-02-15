// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Security.Cryptography.Cipher;

using CryptoHives.Foundation.Security.Cryptography.Cipher.Compat;
using System;

/// <summary>
/// Base class for CryptoHives clean-room symmetric cipher implementations.
/// </summary>
/// <remarks>
/// <para>
/// This class extends <see cref="System.Security.Cryptography.SymmetricAlgorithm"/>
/// to enable drop-in replacement: switching the <c>using</c> directive from
/// <c>System.Security.Cryptography</c> to
/// <c>CryptoHives.Foundation.Security.Cryptography.Cipher</c> provides a managed
/// implementation while preserving API compatibility with <see cref="System.Security.Cryptography.CryptoStream"/>
/// and other .NET cryptographic infrastructure.
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
public abstract class SymmetricCipher : System.Security.Cryptography.SymmetricAlgorithm
{
    private CipherMode _mode = CipherMode.CBC;
    private PaddingMode _padding = PaddingMode.PKCS7;

    /// <summary>
    /// Gets the name of the cipher algorithm.
    /// </summary>
    /// <example>
    /// "AES-256", "ChaCha20", "AES-256-GCM"
    /// </example>
    public abstract string AlgorithmName { get; }

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
    /// <exception cref="System.Security.Cryptography.CryptographicException">Value has an invalid size.</exception>
    public override byte[] IV
    {
        get
        {
            if (IVValue == null)
            {
                GenerateIV();
            }

            return (byte[])IVValue!.Clone();
        }
        set
        {
            if (value is null) throw new ArgumentNullException(nameof(value));
            ValidateIVSize(value.Length);
            IVValue = (byte[])value.Clone();
        }
    }

    /// <summary>
    /// Gets or sets the secret key for the cipher operation.
    /// </summary>
    /// <exception cref="ArgumentNullException">Value is null.</exception>
    /// <exception cref="System.Security.Cryptography.CryptographicException">Value has an invalid size.</exception>
    public override byte[] Key
    {
        get
        {
            if (KeyValue == null)
            {
                GenerateKey();
            }

            return (byte[])KeyValue!.Clone();
        }
        set
        {
            if (value is null) throw new ArgumentNullException(nameof(value));
            ValidateKeySize(value.Length * 8);
            KeySizeValue = value.Length * 8;
            KeyValue = (byte[])value.Clone();
        }
    }

    /// <summary>
    /// Gets or sets the cipher mode of operation.
    /// </summary>
    /// <remarks>
    /// This property shadows <see cref="System.Security.Cryptography.SymmetricAlgorithm.Mode"/>
    /// to use <see cref="CryptoHives.Foundation.Security.Cryptography.Cipher.CipherMode"/>,
    /// which includes additional modes such as <see cref="CipherMode.CTR"/>,
    /// <see cref="CipherMode.GCM"/>, <see cref="CipherMode.CCM"/>, and
    /// <see cref="CipherMode.Stream"/>.
    /// </remarks>
    public new virtual CipherMode Mode
    {
        get => _mode;
        set => _mode = value;
    }

    /// <summary>
    /// Gets or sets the padding mode.
    /// </summary>
    /// <remarks>
    /// This property shadows <see cref="System.Security.Cryptography.SymmetricAlgorithm.Padding"/>
    /// to use <see cref="CryptoHives.Foundation.Security.Cryptography.Cipher.PaddingMode"/>,
    /// whose values are identical to <see cref="System.Security.Cryptography.PaddingMode"/>.
    /// </remarks>
    public new virtual PaddingMode Padding
    {
        get => _padding;
        set => _padding = value;
    }

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
    public virtual bool IsAuthenticated => Mode is CipherMode.GCM or CipherMode.CCM;

    /// <summary>
    /// Initializes a new instance of the <see cref="SymmetricCipher"/> class.
    /// </summary>
    protected SymmetricCipher()
    {
    }

    /// <summary>
    /// Generates a random key appropriate for this algorithm.
    /// </summary>
    public override void GenerateKey()
    {
        KeyValue = new byte[KeySizeValue / 8];
        using var rng = System.Security.Cryptography.RandomNumberGenerator.Create();
        rng.GetBytes(KeyValue);
    }

    /// <summary>
    /// Generates a random IV/nonce appropriate for this algorithm and mode.
    /// </summary>
    public override void GenerateIV()
    {
        IVValue = new byte[IVSize];
        using var rng = System.Security.Cryptography.RandomNumberGenerator.Create();
        rng.GetBytes(IVValue);
    }

    /// <summary>
    /// Creates an encryptor transform using the current key and IV.
    /// </summary>
    /// <returns>A new encryptor transform.</returns>
    /// <exception cref="System.Security.Cryptography.CryptographicException">Key or IV is not set.</exception>
    public new ICipherTransform CreateEncryptor()
    {
        return CreateCipherEncryptor(GetKeyOrThrow(), GetIVOrThrow());
    }

    /// <summary>
    /// Creates an encryptor transform using the specified key and IV.
    /// </summary>
    /// <param name="rgbKey">The secret key.</param>
    /// <param name="rgbIV">The initialization vector or nonce.</param>
    /// <returns>A new encryptor transform.</returns>
    public override System.Security.Cryptography.ICryptoTransform CreateEncryptor(byte[] rgbKey, byte[]? rgbIV)
    {
        return CreateCipherEncryptor(rgbKey, rgbIV ?? GetIVOrThrow());
    }

    /// <summary>
    /// Creates a decryptor transform using the current key and IV.
    /// </summary>
    /// <returns>A new decryptor transform.</returns>
    /// <exception cref="System.Security.Cryptography.CryptographicException">Key or IV is not set.</exception>
    public new ICipherTransform CreateDecryptor()
    {
        return CreateCipherDecryptor(GetKeyOrThrow(), GetIVOrThrow());
    }

    /// <summary>
    /// Creates a decryptor transform using the specified key and IV.
    /// </summary>
    /// <param name="rgbKey">The secret key.</param>
    /// <param name="rgbIV">The initialization vector or nonce.</param>
    /// <returns>A new decryptor transform.</returns>
    public override System.Security.Cryptography.ICryptoTransform CreateDecryptor(byte[] rgbKey, byte[]? rgbIV)
    {
        return CreateCipherDecryptor(rgbKey, rgbIV ?? GetIVOrThrow());
    }

    /// <summary>
    /// Creates an encryptor transform using the specified key and IV.
    /// </summary>
    /// <param name="key">The secret key.</param>
    /// <param name="iv">The initialization vector or nonce.</param>
    /// <returns>A new cipher encryptor transform.</returns>
    protected abstract ICipherTransform CreateCipherEncryptor(byte[] key, byte[] iv);

    /// <summary>
    /// Creates a decryptor transform using the specified key and IV.
    /// </summary>
    /// <param name="key">The secret key.</param>
    /// <param name="iv">The initialization vector or nonce.</param>
    /// <returns>A new cipher decryptor transform.</returns>
    protected abstract ICipherTransform CreateCipherDecryptor(byte[] key, byte[] iv);

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
        if (Mode is CipherMode.Stream or CipherMode.CTR or CipherMode.GCM or CipherMode.CCM)
        {
            return encrypting ? inputLength + TagSize : inputLength - TagSize;
        }

        if (Padding == PaddingMode.None)
        {
            return inputLength;
        }

        int blockSizeBytes = BlockSize / 8;
        if (encrypting)
        {
            return ((inputLength / blockSizeBytes) + 1) * blockSizeBytes;
        }
        else
        {
            return inputLength;
        }
    }

    /// <summary>
    /// Validates that the specified key size is valid for this algorithm.
    /// </summary>
    /// <param name="bitLength">The key size in bits.</param>
    /// <exception cref="System.Security.Cryptography.CryptographicException">The key size is invalid.</exception>
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

        throw new System.Security.Cryptography.CryptographicException($"Invalid key size: {bitLength} bits. Valid sizes: {FormatKeySizes(LegalKeySizes)}");
    }

    /// <summary>
    /// Validates that the specified IV size is valid for this algorithm and mode.
    /// </summary>
    /// <param name="byteLength">The IV size in bytes.</param>
    /// <exception cref="System.Security.Cryptography.CryptographicException">The IV size is invalid.</exception>
    protected virtual void ValidateIVSize(int byteLength)
    {
        if (byteLength != IVSize)
        {
            throw new System.Security.Cryptography.CryptographicException($"Invalid IV size: {byteLength} bytes. Expected: {IVSize} bytes.");
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
        return KeyValue ?? throw new System.Security.Cryptography.CryptographicException("Key has not been set.");
    }

    /// <summary>
    /// Gets the current IV or throws if not set.
    /// </summary>
    protected byte[] GetIVOrThrow()
    {
        return IVValue ?? throw new System.Security.Cryptography.CryptographicException("IV/nonce has not been set.");
    }

    private static string FormatKeySizes(System.Security.Cryptography.KeySizes[] sizes)
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
}
