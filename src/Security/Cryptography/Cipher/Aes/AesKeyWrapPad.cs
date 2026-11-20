// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT OR Apache-2.0

namespace CryptoHives.Foundation.Security.Cryptography.Cipher;

#if NET8_0_OR_GREATER
using System.Runtime.Intrinsics;
#endif

using System;
using System.Buffers;
using System.Buffers.Binary;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using OS = System.Security.Cryptography;

/// <summary>
/// AES Key Wrap with Padding as specified in RFC 5649 (and AES Key Wrap per RFC 3394).
/// </summary>
/// <remarks>
/// <para>
/// AES Key Wrap with Padding (KWP) extends RFC 3394 AES Key Wrap to support
/// arbitrary-length key material (1 byte minimum), adding zero-padding and a
/// message length indicator to the integrity check value.
/// </para>
/// <para>
/// <b>Algorithm overview:</b>
/// <list type="bullet">
///   <item><description>Uses AES ECB as the underlying block cipher</description></item>
///   <item><description>Supports 128, 192, and 256-bit key encryption keys (KEKs)</description></item>
///   <item><description>Wrap output is input length rounded up to 8-byte boundary + 8 bytes overhead</description></item>
///   <item><description>Deterministic: same input always produces the same output</description></item>
/// </list>
/// </para>
/// <para>
/// <b>Example usage:</b>
/// <code>
/// using var kwp = new AesKeyWrapPad(kek);
///
/// // Wrap a key
/// byte[] wrapped = kwp.EncryptKeyWrapPadded(keyToProtect);
///
/// // Unwrap a key
/// byte[] unwrapped = kwp.DecryptKeyWrapPadded(wrapped);
/// </code>
/// </para>
/// <para>
/// References:
/// <list type="bullet">
/// <item><see href="https://www.rfc-editor.org/rfc/rfc5649">RFC 5649 — AES Key Wrap with Padding</see></item>
/// <item><see href="https://www.rfc-editor.org/rfc/rfc3394">RFC 3394 — AES Key Wrap</see></item>
/// <item><see href="https://csrc.nist.gov/pubs/sp/800/38/f/final">NIST SP 800-38F</see></item>
/// </list>
/// </para>
/// </remarks>
public unsafe class AesKeyWrapPad : IDisposable
{
    /// <summary>
    /// Default Initial Value for RFC 3394 AES Key Wrap.
    /// </summary>
    private const ulong DefaultIV = 0xA6A6A6A6_A6A6A6A6UL;

    /// <summary>
    /// Alternative Initial Value prefix for RFC 5649 AES Key Wrap with Padding.
    /// </summary>
    private const uint AIVPrefix = 0xA65959A6U;

    /// <summary>
    /// Largest wrapped key unwrapped in a stack buffer; longer ones use a pooled array.
    /// </summary>
    private const int MaxStackUnwrapBytes = 512;

    /// <summary>
    /// AES block size in bytes.
    /// </summary>
    private const int BlockSize = 16;

    /// <summary>
    /// Half-block (semiblock) size in bytes.
    /// </summary>
    private const int SemiblockSize = 8;

    /// <summary>
    /// Maximum number of round key words (AES-256: 4 × 15 = 60).
    /// </summary>
    private const int MaxRoundKeyWords = 60;

    /// <summary>
    /// Shortest key RFC 3394 wraps: two semiblocks.
    /// </summary>
    private const int MinKeyWrapPlaintext = 16;

    /// <summary>
    /// Longest key either algorithm wraps, so the wrapped length stays a positive <see cref="int"/>.
    /// </summary>
    private const int MaxPlaintextLength = 0x7FFF_FFF0;

    private const string KeyWrapPlaintextLengthMessage = "Key material must be at least 16 bytes and a multiple of 8.";
    private const string EmptyPlaintextMessage = "Key material must not be empty.";
    private const string PlaintextTooLargeMessage = "Key material is too large to wrap.";
    private const string OverlappingBuffersMessage = "The source and destination buffers overlap.";
    private const string DestinationTooShortMessage = "Destination is too short.";

#pragma warning disable CS0169 // The field '_buffers' is never used
    private KeyWrapBuffers _buffers;
#pragma warning restore CS0169
    private readonly int _rounds;
    private bool _disposed;
#if NET8_0_OR_GREATER
    private readonly bool _useAes;
#endif

    /// <summary>
    /// Inline fixed-size buffers for encryption and decryption round keys.
    /// </summary>
    private struct KeyWrapBuffers
    {
        public fixed uint EncKeys[MaxRoundKeyWords];
        public fixed uint DecKeys[MaxRoundKeyWords];
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="AesKeyWrapPad"/> class.
    /// </summary>
    /// <param name="kek">The key encryption key (16, 24, or 32 bytes).</param>
    /// <exception cref="ArgumentException">Thrown when <paramref name="kek"/> is not 16, 24, or 32 bytes.</exception>
    public AesKeyWrapPad(ReadOnlySpan<byte> kek) : this(AesCore.AesDefault, kek)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="AesKeyWrapPad"/> class with specified SIMD support.
    /// </summary>
    /// <param name="simdSupport">The SIMD instruction set to use.</param>
    /// <param name="kek">The key encryption key (16, 24, or 32 bytes).</param>
    /// <exception cref="ArgumentException">Thrown when <paramref name="kek"/> is not 16, 24, or 32 bytes.</exception>
    internal AesKeyWrapPad(SimdSupport simdSupport, ReadOnlySpan<byte> kek)
    {
        if (kek.Length != 16 && kek.Length != 24 && kek.Length != 32)
            throw new ArgumentException("Key must be 16, 24, or 32 bytes.", nameof(kek));

        fixed (uint* encP = _buffers.EncKeys)
        fixed (uint* decP = _buffers.DecKeys)
        {
            var encKeys = new Span<uint>(encP, MaxRoundKeyWords);
            var decKeys = new Span<uint>(decP, MaxRoundKeyWords);

#if NET8_0_OR_GREATER
            if ((simdSupport & SimdSupport & SimdSupport.AesNi) != 0)
            {
                _useAes = true;
                var encView = MemoryMarshal.Cast<uint, Vector128<byte>>(encKeys);
                _rounds = AesCoreAesNi.ExpandKey(kek, encView);

                var decView = MemoryMarshal.Cast<uint, Vector128<byte>>(decKeys);
                AesCoreAesNi.CreateDecryptionKeys(encView, decView, _rounds);
            }
            else if ((simdSupport & SimdSupport & SimdSupport.ArmAes) != 0)
            {
                _useAes = true;
                var encView = MemoryMarshal.Cast<uint, Vector128<byte>>(encKeys);
                _rounds = AesCoreArm.ExpandKey(kek, encView);

                var decView = MemoryMarshal.Cast<uint, Vector128<byte>>(decKeys);
                AesCoreArm.CreateDecryptionKeys(encView, decView, _rounds);
            }
            else
#endif
            {
                _rounds = AesCore.ExpandKey(kek, encKeys);
                AesCore.CreateDecryptionKeys(encKeys, decKeys, _rounds);
            }
        }
    }

    /// <summary>
    /// Gets the SIMD instruction sets supported by AES Key Wrap on the current platform.
    /// </summary>
    internal static SimdSupport SimdSupport => AesCipherTransform.SimdSupport;

    /// <summary>
    /// Gets the length of the RFC 3394 wrapped form of a key of the given length.
    /// </summary>
    /// <param name="plaintextLengthInBytes">The length of the key to wrap.</param>
    /// <returns>The wrapped length, <paramref name="plaintextLengthInBytes"/> + 8.</returns>
    /// <exception cref="ArgumentOutOfRangeException">
    /// <paramref name="plaintextLengthInBytes"/> is less than 16, not a multiple of 8, or too large.
    /// </exception>
    public static int GetKeyWrapLength(int plaintextLengthInBytes)
    {
        if (plaintextLengthInBytes < MinKeyWrapPlaintext || plaintextLengthInBytes % SemiblockSize != 0)
            throw new ArgumentOutOfRangeException(nameof(plaintextLengthInBytes), KeyWrapPlaintextLengthMessage);
        if (plaintextLengthInBytes > MaxPlaintextLength)
            throw new ArgumentOutOfRangeException(nameof(plaintextLengthInBytes), PlaintextTooLargeMessage);

        return plaintextLengthInBytes + SemiblockSize;
    }

    /// <summary>
    /// Gets the length of the RFC 5649 wrapped form of a key of the given length.
    /// </summary>
    /// <param name="plaintextLengthInBytes">The length of the key to wrap.</param>
    /// <returns>The length rounded up to a multiple of 8, plus 8.</returns>
    /// <exception cref="ArgumentOutOfRangeException">
    /// <paramref name="plaintextLengthInBytes"/> is zero, negative, or too large.
    /// </exception>
    public static int GetKeyWrapPaddedLength(int plaintextLengthInBytes)
    {
        if (plaintextLengthInBytes <= 0)
            throw new ArgumentOutOfRangeException(nameof(plaintextLengthInBytes), EmptyPlaintextMessage);
        if (plaintextLengthInBytes > MaxPlaintextLength)
            throw new ArgumentOutOfRangeException(nameof(plaintextLengthInBytes), PlaintextTooLargeMessage);

        return (((plaintextLengthInBytes + SemiblockSize - 1) / SemiblockSize) + 1) * SemiblockSize;
    }

    /// <summary>
    /// Wraps a key with AES Key Wrap (RFC 3394).
    /// </summary>
    /// <param name="plaintext">The key to wrap; at least 16 bytes and a multiple of 8.</param>
    /// <returns>The wrapped key, 8 bytes longer than <paramref name="plaintext"/>.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="plaintext"/> is <see langword="null"/>.</exception>
    /// <exception cref="ArgumentException"><paramref name="plaintext"/> has an invalid length.</exception>
    /// <exception cref="ObjectDisposedException">The instance has been disposed.</exception>
    public byte[] EncryptKeyWrap(byte[] plaintext)
    {
        if (plaintext is null) throw new ArgumentNullException(nameof(plaintext));
        return EncryptKeyWrap(new ReadOnlySpan<byte>(plaintext));
    }

    /// <inheritdoc cref="EncryptKeyWrap(byte[])"/>
    public byte[] EncryptKeyWrap(ReadOnlySpan<byte> plaintext)
    {
        byte[] output = new byte[GetKeyWrapCiphertextLength(plaintext)];
        WrapNoPad(plaintext, output);
        return output;
    }

    /// <summary>
    /// Wraps a key with AES Key Wrap (RFC 3394) into a caller-provided buffer.
    /// </summary>
    /// <param name="plaintext">The key to wrap; at least 16 bytes and a multiple of 8.</param>
    /// <param name="destination">The buffer to receive the wrapped key; exactly <see cref="GetKeyWrapLength"/> bytes.</param>
    /// <exception cref="ArgumentException">
    /// <paramref name="plaintext"/> has an invalid length, or <paramref name="destination"/> is not exactly the wrapped length.
    /// </exception>
    /// <exception cref="OS.CryptographicException"><paramref name="plaintext"/> and <paramref name="destination"/> overlap.</exception>
    /// <exception cref="ObjectDisposedException">The instance has been disposed.</exception>
    public void EncryptKeyWrap(ReadOnlySpan<byte> plaintext, Span<byte> destination)
    {
        int requiredLength = GetKeyWrapCiphertextLength(plaintext);
        if (destination.Length != requiredLength)
            throw new ArgumentException($"Destination must be exactly {requiredLength} bytes.", nameof(destination));
        if (plaintext.Overlaps(destination))
            throw new OS.CryptographicException(OverlappingBuffersMessage);

        WrapNoPad(plaintext, destination);
    }

    /// <summary>
    /// Unwraps a key wrapped with AES Key Wrap (RFC 3394).
    /// </summary>
    /// <param name="ciphertext">The wrapped key; at least 24 bytes and a multiple of 8.</param>
    /// <returns>The unwrapped key, 8 bytes shorter than <paramref name="ciphertext"/>.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="ciphertext"/> is <see langword="null"/>.</exception>
    /// <exception cref="ArgumentException"><paramref name="ciphertext"/> has an invalid length.</exception>
    /// <exception cref="OS.CryptographicException">The integrity check failed.</exception>
    /// <exception cref="ObjectDisposedException">The instance has been disposed.</exception>
    public byte[] DecryptKeyWrap(byte[] ciphertext)
    {
        if (ciphertext is null) throw new ArgumentNullException(nameof(ciphertext));
        return DecryptKeyWrap(new ReadOnlySpan<byte>(ciphertext));
    }

    /// <inheritdoc cref="DecryptKeyWrap(byte[])"/>
    public byte[] DecryptKeyWrap(ReadOnlySpan<byte> ciphertext)
    {
        byte[] output = new byte[GetKeyWrapPlaintextLength(ciphertext)];
        UnwrapNoPad(ciphertext, output);
        return output;
    }

    /// <summary>
    /// Unwraps a key wrapped with AES Key Wrap (RFC 3394) into a caller-provided buffer.
    /// </summary>
    /// <param name="ciphertext">The wrapped key; at least 24 bytes and a multiple of 8.</param>
    /// <param name="destination">The buffer to receive the unwrapped key.</param>
    /// <returns>The number of bytes written to <paramref name="destination"/>.</returns>
    /// <exception cref="ArgumentException">
    /// <paramref name="ciphertext"/> has an invalid length, or <paramref name="destination"/> is too short.
    /// </exception>
    /// <exception cref="OS.CryptographicException">
    /// The buffers overlap, or the integrity check failed.
    /// </exception>
    /// <exception cref="ObjectDisposedException">The instance has been disposed.</exception>
    public int DecryptKeyWrap(ReadOnlySpan<byte> ciphertext, Span<byte> destination)
    {
        if (TryDecryptKeyWrap(ciphertext, destination, out int bytesWritten))
            return bytesWritten;

        throw new ArgumentException(DestinationTooShortMessage, nameof(destination));
    }

    /// <summary>
    /// Attempts to unwrap a key wrapped with AES Key Wrap (RFC 3394) into a caller-provided buffer.
    /// </summary>
    /// <param name="ciphertext">The wrapped key; at least 24 bytes and a multiple of 8.</param>
    /// <param name="destination">The buffer to receive the unwrapped key.</param>
    /// <param name="bytesWritten">The number of bytes written to <paramref name="destination"/>.</param>
    /// <returns><see langword="true"/> if <paramref name="destination"/> was long enough; otherwise <see langword="false"/>.</returns>
    /// <exception cref="ArgumentException"><paramref name="ciphertext"/> has an invalid length.</exception>
    /// <exception cref="OS.CryptographicException">
    /// The buffers overlap, or the integrity check failed.
    /// </exception>
    /// <exception cref="ObjectDisposedException">The instance has been disposed.</exception>
    public bool TryDecryptKeyWrap(ReadOnlySpan<byte> ciphertext, Span<byte> destination, out int bytesWritten)
    {
        int requiredLength = GetKeyWrapPlaintextLength(ciphertext);
        if (destination.Length < requiredLength)
        {
            bytesWritten = 0;
            return false;
        }

        if (ciphertext.Overlaps(destination))
            throw new OS.CryptographicException(OverlappingBuffersMessage);

        UnwrapNoPad(ciphertext, destination.Slice(0, requiredLength));
        bytesWritten = requiredLength;
        return true;
    }

    /// <summary>
    /// Wraps a key with AES Key Wrap with Padding (RFC 5649).
    /// </summary>
    /// <param name="plaintext">The key to wrap; at least 1 byte.</param>
    /// <returns>The wrapped key, <see cref="GetKeyWrapPaddedLength"/> bytes long.</returns>
    /// <exception cref="ArgumentException"><paramref name="plaintext"/> is <see langword="null"/> or empty.</exception>
    /// <exception cref="ObjectDisposedException">The instance has been disposed.</exception>
    public byte[] EncryptKeyWrapPadded(byte[] plaintext)
    {
        if (plaintext is null || plaintext.Length == 0)
            throw new ArgumentException(EmptyPlaintextMessage, nameof(plaintext));
        return EncryptKeyWrapPadded(new ReadOnlySpan<byte>(plaintext));
    }

    /// <summary>
    /// Wraps a key with AES Key Wrap with Padding (RFC 5649).
    /// </summary>
    /// <param name="plaintext">The key to wrap; at least 1 byte.</param>
    /// <returns>The wrapped key, <see cref="GetKeyWrapPaddedLength"/> bytes long.</returns>
    /// <exception cref="ArgumentException"><paramref name="plaintext"/> is empty.</exception>
    /// <exception cref="ObjectDisposedException">The instance has been disposed.</exception>
    public byte[] EncryptKeyWrapPadded(ReadOnlySpan<byte> plaintext)
    {
        byte[] output = new byte[GetKeyWrapPaddedCiphertextLength(plaintext)];
        WrapPadded(plaintext, output);
        return output;
    }

    /// <summary>
    /// Wraps a key with AES Key Wrap with Padding (RFC 5649) into a caller-provided buffer.
    /// </summary>
    /// <param name="plaintext">The key to wrap; at least 1 byte.</param>
    /// <param name="destination">The buffer to receive the wrapped key; exactly <see cref="GetKeyWrapPaddedLength"/> bytes.</param>
    /// <exception cref="ArgumentException">
    /// <paramref name="plaintext"/> is empty, or <paramref name="destination"/> is not exactly the wrapped length.
    /// </exception>
    /// <exception cref="OS.CryptographicException"><paramref name="plaintext"/> and <paramref name="destination"/> overlap.</exception>
    /// <exception cref="ObjectDisposedException">The instance has been disposed.</exception>
    public void EncryptKeyWrapPadded(ReadOnlySpan<byte> plaintext, Span<byte> destination)
    {
        int requiredLength = GetKeyWrapPaddedCiphertextLength(plaintext);
        if (destination.Length != requiredLength)
            throw new ArgumentException($"Destination must be exactly {requiredLength} bytes.", nameof(destination));
        if (plaintext.Overlaps(destination))
            throw new OS.CryptographicException(OverlappingBuffersMessage);

        WrapPadded(plaintext, destination);
    }

    /// <summary>
    /// Unwraps a key wrapped with AES Key Wrap with Padding (RFC 5649).
    /// </summary>
    /// <param name="ciphertext">The wrapped key; at least 16 bytes and a multiple of 8.</param>
    /// <returns>The unwrapped key.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="ciphertext"/> is <see langword="null"/>.</exception>
    /// <exception cref="ArgumentException"><paramref name="ciphertext"/> has an invalid length.</exception>
    /// <exception cref="OS.CryptographicException">The integrity check failed.</exception>
    /// <exception cref="ObjectDisposedException">The instance has been disposed.</exception>
    public byte[] DecryptKeyWrapPadded(byte[] ciphertext)
    {
        if (ciphertext is null) throw new ArgumentNullException(nameof(ciphertext));
        return DecryptKeyWrapPadded(new ReadOnlySpan<byte>(ciphertext));
    }

    /// <inheritdoc cref="DecryptKeyWrapPadded(byte[])"/>
    [SkipLocalsInit]
    public byte[] DecryptKeyWrapPadded(ReadOnlySpan<byte> ciphertext)
    {
        int maxOutput = GetKeyWrapPaddedPlaintextMaxLength(ciphertext);

        byte[]? rented = null;
        Span<byte> scratch = maxOutput <= MaxStackUnwrapBytes
            ? stackalloc byte[MaxStackUnwrapBytes]
            : (rented = ArrayPool<byte>.Shared.Rent(maxOutput));
        scratch = scratch.Slice(0, maxOutput);
        try
        {
            int written = UnwrapPadded(ciphertext, scratch);
            return scratch.Slice(0, written).ToArray();
        }
        finally
        {
            CryptographicOperations.ZeroMemory(scratch);
            if (rented is not null)
            {
                ArrayPool<byte>.Shared.Return(rented);
            }
        }
    }

    /// <summary>
    /// Unwraps a key wrapped with AES Key Wrap with Padding (RFC 5649) into a caller-provided buffer.
    /// </summary>
    /// <param name="ciphertext">The wrapped key; at least 16 bytes and a multiple of 8.</param>
    /// <param name="destination">The buffer to receive the unwrapped key.</param>
    /// <returns>The number of bytes written to <paramref name="destination"/>.</returns>
    /// <exception cref="ArgumentException">
    /// <paramref name="ciphertext"/> has an invalid length, or <paramref name="destination"/> is too short.
    /// </exception>
    /// <exception cref="OS.CryptographicException">
    /// The buffers overlap, or the integrity check failed.
    /// </exception>
    /// <exception cref="ObjectDisposedException">The instance has been disposed.</exception>
    public int DecryptKeyWrapPadded(ReadOnlySpan<byte> ciphertext, Span<byte> destination)
    {
        if (TryDecryptKeyWrapPadded(ciphertext, destination, out int bytesWritten))
            return bytesWritten;

        throw new ArgumentException(DestinationTooShortMessage, nameof(destination));
    }

    /// <summary>
    /// Attempts to unwrap a key wrapped with AES Key Wrap with Padding (RFC 5649) into a caller-provided buffer.
    /// </summary>
    /// <remarks>
    /// The unwrapped length is known only after decryption, so a <paramref name="destination"/> shorter
    /// than the ciphertext length minus 8 can still return <see langword="false"/>. One at least that
    /// long always suffices and is unwrapped in place.
    /// </remarks>
    /// <param name="ciphertext">The wrapped key; at least 16 bytes and a multiple of 8.</param>
    /// <param name="destination">The buffer to receive the unwrapped key.</param>
    /// <param name="bytesWritten">The number of bytes written to <paramref name="destination"/>.</param>
    /// <returns><see langword="true"/> if <paramref name="destination"/> was long enough; otherwise <see langword="false"/>.</returns>
    /// <exception cref="ArgumentException"><paramref name="ciphertext"/> has an invalid length.</exception>
    /// <exception cref="OS.CryptographicException">
    /// The buffers overlap, or the integrity check failed.
    /// </exception>
    /// <exception cref="ObjectDisposedException">The instance has been disposed.</exception>
    [SkipLocalsInit]
    public bool TryDecryptKeyWrapPadded(ReadOnlySpan<byte> ciphertext, Span<byte> destination, out int bytesWritten)
    {
        int maxOutput = GetKeyWrapPaddedPlaintextMaxLength(ciphertext);
        int minOutput = maxOutput - (SemiblockSize - 1);
        if (destination.Length < minOutput)
        {
            bytesWritten = 0;
            return false;
        }

        if (ciphertext.Overlaps(destination))
            throw new OS.CryptographicException(OverlappingBuffersMessage);

        if (destination.Length >= maxOutput)
        {
            bytesWritten = UnwrapPadded(ciphertext, destination.Slice(0, maxOutput));
            return true;
        }

        Span<byte> scratch = stackalloc byte[MaxStackUnwrapBytes];
        byte[]? rented = null;
        if (maxOutput > MaxStackUnwrapBytes)
        {
            rented = ArrayPool<byte>.Shared.Rent(maxOutput);
            scratch = rented;
        }

        scratch = scratch.Slice(0, maxOutput);
        try
        {
            int written = UnwrapPadded(ciphertext, scratch);
            if (written > destination.Length)
            {
                bytesWritten = 0;
                return false;
            }

            scratch.Slice(0, written).CopyTo(destination);
            bytesWritten = written;
            return true;
        }
        finally
        {
            CryptographicOperations.ZeroMemory(scratch);
            if (rented is not null)
            {
                ArrayPool<byte>.Shared.Return(rented);
            }
        }
    }

    private static int GetKeyWrapCiphertextLength(ReadOnlySpan<byte> plaintext)
    {
        if (plaintext.Length < MinKeyWrapPlaintext || plaintext.Length % SemiblockSize != 0)
            throw new ArgumentException(KeyWrapPlaintextLengthMessage, nameof(plaintext));
        if (plaintext.Length > MaxPlaintextLength)
            throw new ArgumentException(PlaintextTooLargeMessage, nameof(plaintext));

        return plaintext.Length + SemiblockSize;
    }

    private static int GetKeyWrapPlaintextLength(ReadOnlySpan<byte> ciphertext)
    {
        if (ciphertext.Length < MinKeyWrapPlaintext + SemiblockSize || ciphertext.Length % SemiblockSize != 0)
            throw new ArgumentException("Wrapped key must be at least 24 bytes and a multiple of 8.", nameof(ciphertext));

        return ciphertext.Length - SemiblockSize;
    }

    private static int GetKeyWrapPaddedCiphertextLength(ReadOnlySpan<byte> plaintext)
    {
        if (plaintext.IsEmpty)
            throw new ArgumentException(EmptyPlaintextMessage, nameof(plaintext));
        if (plaintext.Length > MaxPlaintextLength)
            throw new ArgumentException(PlaintextTooLargeMessage, nameof(plaintext));

        return GetKeyWrapPaddedLength(plaintext.Length);
    }

    private static int GetKeyWrapPaddedPlaintextMaxLength(ReadOnlySpan<byte> ciphertext)
    {
        if (ciphertext.Length < BlockSize || ciphertext.Length % SemiblockSize != 0)
            throw new ArgumentException("Wrapped key must be at least 16 bytes and a multiple of 8.", nameof(ciphertext));

        return ciphertext.Length - SemiblockSize;
    }

    /// <summary>
    /// RFC 3394 wrap of a validated <paramref name="plaintext"/> into an exactly sized <paramref name="destination"/>.
    /// </summary>
    [SkipLocalsInit]
    private void WrapNoPad(ReadOnlySpan<byte> plaintext, Span<byte> destination)
    {
        if (_disposed) throw new ObjectDisposedException(nameof(AesKeyWrapPad));

        Span<byte> iv = stackalloc byte[SemiblockSize];
        BinaryPrimitives.WriteUInt64BigEndian(iv, DefaultIV);

        plaintext.CopyTo(destination.Slice(SemiblockSize));
        WrapCore(iv, destination, plaintext.Length / SemiblockSize);
    }

    /// <summary>
    /// RFC 5649 wrap of a validated <paramref name="plaintext"/> into an exactly sized <paramref name="destination"/>.
    /// </summary>
    [SkipLocalsInit]
    private void WrapPadded(ReadOnlySpan<byte> plaintext, Span<byte> destination)
    {
        if (_disposed) throw new ObjectDisposedException(nameof(AesKeyWrapPad));

        Span<byte> aiv = stackalloc byte[SemiblockSize];
        BinaryPrimitives.WriteUInt32BigEndian(aiv, AIVPrefix);
        BinaryPrimitives.WriteUInt32BigEndian(aiv.Slice(4), (uint)plaintext.Length);

        int n = (destination.Length / SemiblockSize) - 1;
        if (n == 1)
        {
            // RFC 5649 §4.1: a single padded semiblock is one AES block, AIV || P.
            Span<byte> block = stackalloc byte[BlockSize];
            aiv.CopyTo(block);
            block.Slice(SemiblockSize).Clear();
            plaintext.CopyTo(block.Slice(SemiblockSize));

            EncryptBlockDispatch(block, destination);
            CryptographicOperations.ZeroMemory(block);
            return;
        }

        Span<byte> r = destination.Slice(SemiblockSize);
        plaintext.CopyTo(r);
        r.Slice(plaintext.Length).Clear();
        WrapCore(aiv, destination, n);
    }

    /// <summary>
    /// RFC 3394 unwrap of a validated <paramref name="ciphertext"/> into <paramref name="destination"/>,
    /// which is exactly 8 bytes shorter; cleared before the integrity failure is thrown.
    /// </summary>
    [SkipLocalsInit]
    private void UnwrapNoPad(ReadOnlySpan<byte> ciphertext, Span<byte> destination)
    {
        if (_disposed) throw new ObjectDisposedException(nameof(AesKeyWrapPad));

        Span<byte> a = stackalloc byte[SemiblockSize];
        ciphertext.Slice(0, SemiblockSize).CopyTo(a);
        ciphertext.Slice(SemiblockSize).CopyTo(destination);

        UnwrapCore(a, destination, destination.Length / SemiblockSize);

        if (BinaryPrimitives.ReadUInt64BigEndian(a) != DefaultIV)
        {
            CryptographicOperations.ZeroMemory(destination);
            throw new OS.CryptographicException("AES Key Wrap integrity check failed.");
        }
    }

    /// <summary>
    /// RFC 5649 unwrap of a validated <paramref name="ciphertext"/> into <paramref name="destination"/>,
    /// which is exactly 8 bytes shorter; cleared before the integrity failure is thrown.
    /// </summary>
    /// <returns>The unwrapped key length, at the start of <paramref name="destination"/>.</returns>
    [SkipLocalsInit]
    private int UnwrapPadded(ReadOnlySpan<byte> ciphertext, Span<byte> destination)
    {
        if (_disposed) throw new ObjectDisposedException(nameof(AesKeyWrapPad));

        int n = destination.Length / SemiblockSize;
        Span<byte> a = stackalloc byte[SemiblockSize];

        if (n == 1)
        {
            Span<byte> block = stackalloc byte[BlockSize];
            DecryptBlockDispatch(ciphertext, block);
            block.Slice(0, SemiblockSize).CopyTo(a);
            block.Slice(SemiblockSize).CopyTo(destination);
            CryptographicOperations.ZeroMemory(block);
        }
        else
        {
            ciphertext.Slice(0, SemiblockSize).CopyTo(a);
            ciphertext.Slice(SemiblockSize).CopyTo(destination);
            UnwrapCore(a, destination, n);
        }

        if (!TryVerifyAiv(a, destination, n, out int mli))
        {
            CryptographicOperations.ZeroMemory(destination);
            throw new OS.CryptographicException("AES Key Wrap with Padding integrity check failed.");
        }

        return mli;
    }

    /// <summary>
    /// RFC 3394 Section 2.2.1 — Key Wrap core algorithm.
    /// On entry, output[0..8) holds A (will be overwritten), output[8..] holds R[1..n].
    /// On exit, output[0..8) holds final A, output[8..] holds final R[1..n].
    /// </summary>
    /// <param name="iv">The 8-byte initial value (A₀).</param>
    /// <param name="output">The output buffer: [A || R1 || R2 || ... || Rn].</param>
    /// <param name="n">Number of 64-bit semiblocks of plaintext.</param>
    [SkipLocalsInit]
    private void WrapCore(ReadOnlySpan<byte> iv, Span<byte> output, int n)
    {
        Span<byte> block = stackalloc byte[BlockSize];
        Span<byte> b = stackalloc byte[BlockSize];

        // A = IV
        Span<byte> a = block.Slice(0, SemiblockSize);
        iv.CopyTo(a);

        for (int j = 0; j < 6; j++)
        {
            for (int i = 1; i <= n; i++)
            {
                // B = AES(K, A || R[i])
                output.Slice(i * SemiblockSize, SemiblockSize).CopyTo(block.Slice(SemiblockSize));
                EncryptBlockDispatch(block, b);

                // A = MSB(64, B) ^ t where t = n*j + i
                ulong msb = BinaryPrimitives.ReadUInt64BigEndian(b);
                ulong t = (ulong)(n * j + i);
                BinaryPrimitives.WriteUInt64BigEndian(a, msb ^ t);

                // R[i] = LSB(64, B)
                b.Slice(SemiblockSize).CopyTo(output.Slice(i * SemiblockSize));
            }
        }

        // Write final A to output[0..8)
        a.CopyTo(output);
        CryptographicOperations.ZeroMemory(block);
        CryptographicOperations.ZeroMemory(b);
    }

    /// <summary>
    /// RFC 3394 Section 2.2.2 — Key Unwrap core algorithm, in place.
    /// On entry, <paramref name="a"/> holds C[0] and <paramref name="r"/> holds C[1..n].
    /// On exit, <paramref name="a"/> holds the recovered A and <paramref name="r"/> holds R[1..n].
    /// </summary>
    /// <param name="a">The 8-byte integrity value.</param>
    /// <param name="r">The n semiblocks being unwrapped.</param>
    /// <param name="n">Number of 64-bit semiblocks in <paramref name="r"/>.</param>
    [SkipLocalsInit]
    private void UnwrapCore(Span<byte> a, Span<byte> r, int n)
    {
        Span<byte> block = stackalloc byte[BlockSize];
        Span<byte> b = stackalloc byte[BlockSize];

        for (int j = 5; j >= 0; j--)
        {
            for (int i = n; i >= 1; i--)
            {
                // B = AES-1(K, (A ^ t) || R[i]) where t = n*j + i
                ulong aVal = BinaryPrimitives.ReadUInt64BigEndian(a);
                ulong t = (ulong)(n * j + i);
                BinaryPrimitives.WriteUInt64BigEndian(block, aVal ^ t);
                r.Slice((i - 1) * SemiblockSize, SemiblockSize).CopyTo(block.Slice(SemiblockSize));

                DecryptBlockDispatch(block, b);

                // A = MSB(64, B)
                b.Slice(0, SemiblockSize).CopyTo(a);

                // R[i] = LSB(64, B)
                b.Slice(SemiblockSize).CopyTo(r.Slice((i - 1) * SemiblockSize));
            }
        }

        CryptographicOperations.ZeroMemory(block);
        CryptographicOperations.ZeroMemory(b);
    }

    /// <summary>
    /// Verifies the Alternative Initial Value (AIV) per RFC 5649 Section 3.
    /// </summary>
    /// <param name="a">The recovered 8-byte AIV.</param>
    /// <param name="data">The padded plaintext data.</param>
    /// <param name="n">Number of 64-bit semiblocks of padded data.</param>
    /// <param name="mli">The message length indicator, valid only when the check passes.</param>
    /// <returns><see langword="true"/> if the AIV, length and padding are all valid.</returns>
    private static bool TryVerifyAiv(ReadOnlySpan<byte> a, ReadOnlySpan<byte> data, int n, out int mli)
    {
        uint prefix = BinaryPrimitives.ReadUInt32BigEndian(a);
        uint length = BinaryPrimitives.ReadUInt32BigEndian(a.Slice(4));
        mli = (int)length;

        // MLI range per RFC 5649 §3: 8n - 7 <= MLI <= 8n.
        uint maxLen = (uint)(n * SemiblockSize);
        if (prefix != AIVPrefix || length > maxLen || length < maxLen - (SemiblockSize - 1))
            return false;

        int padding = 0;
        foreach (byte value in data.Slice(mli, (int)maxLen - mli))
        {
            padding |= value;
        }

        return padding == 0;
    }

    [MethodImpl(MethodImplOptionsEx.HotPath)]
    private void EncryptBlockDispatch(ReadOnlySpan<byte> input, Span<byte> output)
    {
        fixed (uint* p = _buffers.EncKeys)
        {
            var roundKeys = new ReadOnlySpan<uint>(p, MaxRoundKeyWords);
#if NET8_0_OR_GREATER
            if (AesCoreAesNi.IsSupported && _useAes)
            {
                AesCoreAesNi.EncryptBlock(input, output,
                    MemoryMarshal.Cast<uint, Vector128<byte>>(roundKeys), _rounds);
                return;
            }

            if (AesCoreArm.IsSupported && _useAes)
            {
                AesCoreArm.EncryptBlock(input, output,
                    MemoryMarshal.Cast<uint, Vector128<byte>>(roundKeys), _rounds);
                return;
            }
#endif
            AesCore.EncryptBlock(input, output, roundKeys, _rounds);
        }
    }

    [MethodImpl(MethodImplOptionsEx.HotPath)]
    private void DecryptBlockDispatch(ReadOnlySpan<byte> input, Span<byte> output)
    {
        fixed (uint* p = _buffers.DecKeys)
        {
            var roundKeys = new ReadOnlySpan<uint>(p, MaxRoundKeyWords);
#if NET8_0_OR_GREATER
            if (AesCoreAesNi.IsSupported && _useAes)
            {
                AesCoreAesNi.DecryptBlock(input, output,
                    MemoryMarshal.Cast<uint, Vector128<byte>>(roundKeys), _rounds);
                return;
            }

            if (AesCoreArm.IsSupported && _useAes)
            {
                AesCoreArm.DecryptBlock(input, output,
                    MemoryMarshal.Cast<uint, Vector128<byte>>(roundKeys), _rounds);
                return;
            }
#endif
            AesCore.DecryptBlock(input, output, roundKeys, _rounds);
        }
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
        if (_disposed) return;
        _disposed = true;

        if (disposing)
        {
            fixed (uint* encP = _buffers.EncKeys)
            fixed (uint* decP = _buffers.DecKeys)
            {
                CryptographicOperations.ZeroMemory(MemoryMarshal.AsBytes(new Span<uint>(encP, MaxRoundKeyWords)));
                CryptographicOperations.ZeroMemory(MemoryMarshal.AsBytes(new Span<uint>(decP, MaxRoundKeyWords)));
            }
        }
    }
}
