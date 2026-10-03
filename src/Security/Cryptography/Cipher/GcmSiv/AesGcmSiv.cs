// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Security.Cryptography.Cipher;

using System;
using System.Buffers.Binary;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using OS = System.Security.Cryptography;
#if NET8_0_OR_GREATER
using System.Runtime.Intrinsics;
#endif

/// <summary>
/// AES-GCM-SIV (RFC 8452) nonce-misuse-resistant authenticated encryption.
/// </summary>
/// <remarks>
/// <para>
/// The tag is derived from the plaintext and then used as the counter-mode IV, so repeating a
/// nonce reveals only whether the same (associated data, plaintext) pair was encrypted twice.
/// It does not leak plaintext or allow forgeries, as a repeated nonce under AES-GCM does.
/// A unique nonce per message remains the intended use.
/// </para>
/// <para>
/// Fixed sizes: 16- or 32-byte key, 12-byte nonce, 16-byte tag. Each message derives its own
/// authentication and encryption keys from the key and nonce.
/// </para>
/// </remarks>
public abstract class AesGcmSiv : IAeadCipher
{
    /// <summary>The nonce size in bytes.</summary>
    public const int NonceSize = 12;

    /// <summary>The tag size in bytes.</summary>
    public const int TagSize = 16;

    private const int BlockSize = 16;
    private const int MaxRoundKeyWords = 60;
    private const int MaxEncryptionKeyBytes = 32;

    private readonly uint[] _kgkRoundKeys = new uint[MaxRoundKeyWords];
    private readonly int _kgkRounds;
    private readonly int _keySizeBytes;
    private readonly bool _useAesNi;
    private readonly bool _useArmAes;
    private readonly bool _usePclmul;
    private bool _disposed;

    /// <summary>
    /// Initializes a new instance of the <see cref="AesGcmSiv"/> class.
    /// </summary>
    /// <param name="simdSupport">The SIMD instruction sets to use.</param>
    /// <param name="key">The 16- or 32-byte key-generating key.</param>
    private protected AesGcmSiv(SimdSupport simdSupport, ReadOnlySpan<byte> key)
    {
        if (key.Length != 16 && key.Length != 32)
            throw new ArgumentException("Key must be 16 or 32 bytes.", nameof(key));

        simdSupport = simdSupport.WithImplicit() & SimdSupport;
        _useAesNi = (simdSupport & SimdSupport.AesNi) != 0;
        _useArmAes = !_useAesNi && (simdSupport & SimdSupport.ArmAes) != 0;
        _usePclmul = (simdSupport & SimdSupport.PClMul) != 0;
        _keySizeBytes = key.Length;
        _kgkRounds = ExpandKey(key, _kgkRoundKeys);
    }

    /// <summary>
    /// Gets the SIMD instruction sets AES-GCM-SIV can use on the current platform.
    /// </summary>
    /// <remarks>
    /// POLYVAL uses PCLMULQDQ on x86; on Arm64 it runs the scalar path.
    /// </remarks>
    internal static SimdSupport SimdSupport =>
#if NET8_0_OR_GREATER
        (AesCoreAesNi.IsSupported ? SimdSupport.AesNi : SimdSupport.None) |
        (AesCoreArm.IsSupported ? SimdSupport.ArmAes : SimdSupport.None) |
        (Polyval.IsPclmulSupported ? SimdSupport.PClMul : SimdSupport.None);
#else
        SimdSupport.None;
#endif

    /// <inheritdoc/>
    public abstract string AlgorithmName { get; }

    /// <inheritdoc/>
    public int KeySizeBytes => _keySizeBytes;

    /// <inheritdoc/>
    public int NonceSizeBytes => NonceSize;

    /// <inheritdoc/>
    public int TagSizeBytes => TagSize;

    /// <inheritdoc/>
    /// <remarks>The ciphertext may be the plaintext buffer itself; any other overlap is not supported.</remarks>
    /// <exception cref="ObjectDisposedException">Thrown when the instance has been disposed.</exception>
    [SkipLocalsInit]
    public void Encrypt(
        ReadOnlySpan<byte> nonce, ReadOnlySpan<byte> plaintext,
        Span<byte> ciphertext, Span<byte> tag,
        ReadOnlySpan<byte> associatedData = default)
    {
        if (_disposed)
            throw new ObjectDisposedException(GetType().Name);
        if (nonce.Length != NonceSize)
            throw new ArgumentException($"Nonce must be {NonceSize} bytes.", nameof(nonce));
        if (ciphertext.Length < plaintext.Length)
            throw new ArgumentException("Ciphertext buffer too small.", nameof(ciphertext));
        if (tag.Length < TagSize)
            throw new ArgumentException("Tag buffer too small.", nameof(tag));

        Span<byte> authKey = stackalloc byte[BlockSize];
        Span<byte> encKey = stackalloc byte[MaxEncryptionKeyBytes];
        Span<uint> roundKeys = stackalloc uint[MaxRoundKeyWords];
        Span<byte> fullTag = stackalloc byte[TagSize];
        try
        {
            int rounds = DeriveKeys(nonce, authKey, encKey, roundKeys);

            // The tag covers the plaintext, so it is computed before the plaintext can be overwritten in place.
            ComputeTag(nonce, authKey, associatedData, plaintext, roundKeys, rounds, fullTag);
            Ctr(fullTag, plaintext, ciphertext.Slice(0, plaintext.Length), roundKeys, rounds);
            fullTag.CopyTo(tag);
        }
        finally
        {
            CryptographicOperations.ZeroMemory(authKey);
            CryptographicOperations.ZeroMemory(encKey);
            CryptographicOperations.ZeroMemory(MemoryMarshal.AsBytes(roundKeys));
        }
    }

    /// <inheritdoc/>
    /// <remarks>The plaintext may be the ciphertext buffer itself; any other overlap is not supported.</remarks>
    /// <exception cref="ObjectDisposedException">Thrown when the instance has been disposed.</exception>
    [SkipLocalsInit]
    public bool Decrypt(
        ReadOnlySpan<byte> nonce, ReadOnlySpan<byte> ciphertext,
        ReadOnlySpan<byte> tag, Span<byte> plaintext,
        ReadOnlySpan<byte> associatedData = default)
    {
        if (_disposed)
            throw new ObjectDisposedException(GetType().Name);
        if (nonce.Length != NonceSize)
            throw new ArgumentException($"Nonce must be {NonceSize} bytes.", nameof(nonce));
        if (tag.Length != TagSize)
            throw new ArgumentException($"Tag must be {TagSize} bytes.", nameof(tag));
        if (plaintext.Length < ciphertext.Length)
            throw new ArgumentException("Plaintext buffer too small.", nameof(plaintext));

        Span<byte> output = plaintext.Slice(0, ciphertext.Length);
        Span<byte> authKey = stackalloc byte[BlockSize];
        Span<byte> encKey = stackalloc byte[MaxEncryptionKeyBytes];
        Span<uint> roundKeys = stackalloc uint[MaxRoundKeyWords];
        Span<byte> receivedTag = stackalloc byte[TagSize];
        Span<byte> expectedTag = stackalloc byte[TagSize];
        try
        {
            int rounds = DeriveKeys(nonce, authKey, encKey, roundKeys);

            // Copied so an output buffer overlapping the caller's tag cannot change the IV or the comparison.
            tag.CopyTo(receivedTag);
            Ctr(receivedTag, ciphertext, output, roundKeys, rounds);
            ComputeTag(nonce, authKey, associatedData, output, roundKeys, rounds, expectedTag);

            if (!CryptographicOperations.FixedTimeEquals(receivedTag, expectedTag))
            {
                CryptographicOperations.ZeroMemory(output);
                return false;
            }

            return true;
        }
        finally
        {
            CryptographicOperations.ZeroMemory(authKey);
            CryptographicOperations.ZeroMemory(encKey);
            CryptographicOperations.ZeroMemory(MemoryMarshal.AsBytes(roundKeys));
        }
    }

    /// <inheritdoc/>
    public byte[] Encrypt(
        ReadOnlySpan<byte> nonce, ReadOnlySpan<byte> plaintext,
        ReadOnlySpan<byte> associatedData = default)
    {
        byte[] result = new byte[plaintext.Length + TagSize];
        Encrypt(nonce, plaintext, result.AsSpan(0, plaintext.Length), result.AsSpan(plaintext.Length, TagSize), associatedData);
        return result;
    }

    /// <inheritdoc/>
    public byte[] Decrypt(
        ReadOnlySpan<byte> nonce, ReadOnlySpan<byte> ciphertextWithTag,
        ReadOnlySpan<byte> associatedData = default)
    {
        if (ciphertextWithTag.Length < TagSize)
            throw new OS.CryptographicException("Ciphertext too short.");

        int ciphertextLength = ciphertextWithTag.Length - TagSize;
        byte[] plaintext = new byte[ciphertextLength];

        if (!Decrypt(nonce, ciphertextWithTag.Slice(0, ciphertextLength),
                     ciphertextWithTag.Slice(ciphertextLength, TagSize), plaintext, associatedData))
        {
            throw new OS.CryptographicException("Authentication failed.");
        }

        return plaintext;
    }

    /// <inheritdoc/>
    public void Dispose()
    {
        Dispose(disposing: true);
        GC.SuppressFinalize(this);
    }

    /// <summary>
    /// Releases resources used by this instance.
    /// </summary>
    /// <param name="disposing">True if called from <see cref="Dispose()"/>, false if from finalizer.</param>
    protected virtual void Dispose(bool disposing)
    {
        if (!_disposed)
        {
            if (disposing)
            {
                CryptographicOperations.ZeroMemory(MemoryMarshal.AsBytes(_kgkRoundKeys.AsSpan()));
            }

            _disposed = true;
        }
    }

    /// <summary>
    /// RFC 8452 §4: derives the per-nonce authentication key and expands the per-nonce encryption key.
    /// </summary>
    /// <returns>The number of AES rounds for the encryption key.</returns>
    private int DeriveKeys(ReadOnlySpan<byte> nonce, Span<byte> authKey, Span<byte> encKey, Span<uint> roundKeys)
    {
        Span<byte> block = stackalloc byte[BlockSize];
        Span<byte> output = stackalloc byte[BlockSize];
        nonce.CopyTo(block.Slice(4));

        // Block i = LE32(i) ‖ nonce; keep the first 8 bytes of each encryption.
        int blocks = _keySizeBytes == 16 ? 4 : 6;
        for (int i = 0; i < blocks; i++)
        {
            BinaryPrimitives.WriteUInt32LittleEndian(block, (uint)i);
            EncryptBlock(block, output, _kgkRoundKeys, _kgkRounds);
            Span<byte> destination = i < 2 ? authKey.Slice(i * 8, 8) : encKey.Slice((i - 2) * 8, 8);
            output.Slice(0, 8).CopyTo(destination);
        }

        CryptographicOperations.ZeroMemory(output);
        return ExpandKey(encKey.Slice(0, _keySizeBytes), roundKeys);
    }

    /// <summary>
    /// RFC 8452 §4: tag = AES(encKey, (POLYVAL(authKey, …) ⊕ nonce) with the top bit cleared).
    /// </summary>
    private void ComputeTag(
        ReadOnlySpan<byte> nonce, ReadOnlySpan<byte> authKey,
        ReadOnlySpan<byte> associatedData, ReadOnlySpan<byte> plaintext,
        ReadOnlySpan<uint> roundKeys, int rounds, Span<byte> tag)
    {
        Span<byte> s = stackalloc byte[BlockSize];
        Polyval.ComputeSiv(authKey, associatedData, plaintext, s, _usePclmul);
        for (int i = 0; i < NonceSize; i++)
        {
            s[i] ^= nonce[i];
        }
        s[15] &= 0x7f;

        EncryptBlock(s, tag, roundKeys, rounds);
        CryptographicOperations.ZeroMemory(s);
    }

    /// <summary>
    /// RFC 8452 §4: AES-CTR from the tag with its top bit set, advancing the first 32 bits as a
    /// little-endian counter that wraps modulo 2^32.
    /// </summary>
    [SkipLocalsInit]
    private void Ctr(ReadOnlySpan<byte> tag, ReadOnlySpan<byte> input, Span<byte> output, ReadOnlySpan<uint> roundKeys, int rounds)
    {
        Span<byte> counter = stackalloc byte[BlockSize];
        tag.CopyTo(counter);
        counter[15] |= 0x80;

        int offset = 0;
#if NET8_0_OR_GREATER
        if ((AesCoreAesNi.IsSupported && _useAesNi) || (AesCoreArm.IsSupported && _useArmAes))
        {
            offset = CtrBlocks4(counter, input, output, MemoryMarshal.Cast<uint, Vector128<byte>>(roundKeys), rounds);
        }
#endif

        Span<byte> keystream = stackalloc byte[BlockSize];
        uint ctr = BinaryPrimitives.ReadUInt32LittleEndian(counter);
        while (offset < input.Length)
        {
            BinaryPrimitives.WriteUInt32LittleEndian(counter, ctr);
            EncryptBlock(counter, keystream, roundKeys, rounds);

            int count = Math.Min(BlockSize, input.Length - offset);
            for (int i = 0; i < count; i++)
            {
                output[offset + i] = (byte)(input[offset + i] ^ keystream[i]);
            }

            ctr = unchecked(ctr + 1);
            offset += BlockSize;
        }

        CryptographicOperations.ZeroMemory(keystream);
    }

#if NET8_0_OR_GREATER
    /// <summary>
    /// Four interleaved counter blocks per AES pass while at least 64 bytes remain.
    /// </summary>
    /// <returns>The number of bytes processed; <paramref name="counter"/> is advanced past them.</returns>
    [MethodImpl(MethodImplOptionsEx.OptimizedLoop)]
    private int CtrBlocks4(
        Span<byte> counter, ReadOnlySpan<byte> input, Span<byte> output,
        ReadOnlySpan<Vector128<byte>> roundKeys, int rounds)
    {
        const int Stride = 4 * BlockSize;
        Vector128<uint> baseCounter = Vector128.Create((ReadOnlySpan<byte>)counter).AsUInt32();
        uint ctr = baseCounter.GetElement(0);

        int offset = 0;
        for (; offset + Stride <= input.Length; offset += Stride)
        {
            Vector128<byte> b0 = baseCounter.WithElement(0, ctr).AsByte();
            Vector128<byte> b1 = baseCounter.WithElement(0, unchecked(ctr + 1)).AsByte();
            Vector128<byte> b2 = baseCounter.WithElement(0, unchecked(ctr + 2)).AsByte();
            Vector128<byte> b3 = baseCounter.WithElement(0, unchecked(ctr + 3)).AsByte();
            ctr = unchecked(ctr + 4);

            if (_useAesNi)
            {
                AesCoreAesNi.EncryptBlocks4(ref b0, ref b1, ref b2, ref b3, roundKeys, rounds);
            }
            else
            {
                AesCoreArm.EncryptBlocks4(ref b0, ref b1, ref b2, ref b3, roundKeys, rounds);
            }

            ReadOnlySpan<byte> src = input.Slice(offset, Stride);
            Span<byte> dst = output.Slice(offset, Stride);
            Vector128<byte> x0 = Vector128.Create(src) ^ b0;
            Vector128<byte> x1 = Vector128.Create(src.Slice(16)) ^ b1;
            Vector128<byte> x2 = Vector128.Create(src.Slice(32)) ^ b2;
            Vector128<byte> x3 = Vector128.Create(src.Slice(48)) ^ b3;
            x0.CopyTo(dst);
            x1.CopyTo(dst.Slice(16));
            x2.CopyTo(dst.Slice(32));
            x3.CopyTo(dst.Slice(48));
        }

        BinaryPrimitives.WriteUInt32LittleEndian(counter, ctr);
        return offset;
    }
#endif

    private int ExpandKey(ReadOnlySpan<byte> key, Span<uint> roundKeys)
    {
#if NET8_0_OR_GREATER
        if (AesCoreAesNi.IsSupported && _useAesNi)
            return AesCoreAesNi.ExpandKey(key, MemoryMarshal.Cast<uint, Vector128<byte>>(roundKeys));
        if (AesCoreArm.IsSupported && _useArmAes)
            return AesCoreArm.ExpandKey(key, MemoryMarshal.Cast<uint, Vector128<byte>>(roundKeys));
#endif
        return AesCore.ExpandKey(key, roundKeys);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private void EncryptBlock(ReadOnlySpan<byte> input, Span<byte> output, ReadOnlySpan<uint> roundKeys, int rounds)
    {
#if NET8_0_OR_GREATER
        if (AesCoreAesNi.IsSupported && _useAesNi)
        {
            AesCoreAesNi.EncryptBlock(input, output, MemoryMarshal.Cast<uint, Vector128<byte>>(roundKeys), rounds);
            return;
        }
        if (AesCoreArm.IsSupported && _useArmAes)
        {
            AesCoreArm.EncryptBlock(input, output, MemoryMarshal.Cast<uint, Vector128<byte>>(roundKeys), rounds);
            return;
        }
#endif
        AesCore.EncryptBlock(input, output, roundKeys, rounds);
    }
}
