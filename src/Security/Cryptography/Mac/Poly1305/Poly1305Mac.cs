// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Security.Cryptography.Mac;

using CryptoHives.Foundation.Security.Cryptography.Cipher;
using System;

/// <summary>
/// Computes the Poly1305 message authentication code as defined in RFC 8439.
/// </summary>
/// <remarks>
/// <para>
/// Poly1305 is a high-speed, one-time authenticator designed by Daniel J. Bernstein.
/// It takes a 32-byte one-time key and a message to produce a 16-byte tag.
/// </para>
/// <para>
/// <b>Important:</b> The key must be unique for every message. Reusing a key across
/// multiple messages completely compromises authenticity. In practice, the key is
/// typically derived from a session key and nonce (e.g., by ChaCha20-Poly1305).
/// </para>
/// <para>
/// This class provides a streaming <see cref="IMac"/> interface for incremental
/// hashing. For stack-only, zero-allocation usage, see <see cref="Poly1305Core"/>.
/// </para>
/// </remarks>
/// <example>
/// <code>
/// byte[] key = new byte[32]; // 32-byte one-time key
/// byte[] data = Encoding.UTF8.GetBytes("Hello, World!");
///
/// using var mac = Poly1305Mac.Create(key);
/// mac.Update(data);
/// byte[] tag = new byte[16];
/// mac.Finalize(tag);
/// </code>
/// </example>
public sealed class Poly1305Mac : IMac
{
    /// <summary>
    /// The MAC output size in bytes.
    /// </summary>
    public const int TagSizeBytes = Poly1305Core.TagSizeBytes;

    /// <summary>
    /// The required key size in bytes.
    /// </summary>
    public const int KeySizeBytes = Poly1305Core.KeySizeBytes;

    private const int BlockSize = Poly1305Core.BlockSize;

#if NET8_0_OR_GREATER
    // Donna-64 state
    private ulong _h0, _h1, _h2;
    private readonly ulong _r0, _r1, _r2, _s1, _s2;
    private readonly ulong _padLo, _padHi;
#else
    // Donna-32 state
    private uint _h0, _h1, _h2, _h3, _h4;
    private readonly uint _r0, _r1, _r2, _r3, _r4;
    private readonly uint _s1, _s2, _s3, _s4;
    private readonly uint _pad0, _pad1, _pad2, _pad3;
#endif

    private readonly byte[] _buffer;
    private int _bufferLength;
    private bool _finalized;
    private bool _disposed;

    /// <inheritdoc/>
    public string AlgorithmName => "Poly1305";

    /// <inheritdoc/>
    public int MacSize => TagSizeBytes;

    /// <summary>
    /// Initializes a new instance of the <see cref="Poly1305Mac"/> class.
    /// </summary>
    /// <param name="key">The 32-byte one-time key.</param>
    /// <exception cref="ArgumentException">The key is not 32 bytes.</exception>
    public Poly1305Mac(byte[] key) : this(key.AsSpan())
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Poly1305Mac"/> class.
    /// </summary>
    /// <param name="key">The 32-byte one-time key.</param>
    /// <exception cref="ArgumentException">The key is not 32 bytes.</exception>
    public Poly1305Mac(ReadOnlySpan<byte> key)
    {
        if (key.Length != KeySizeBytes)
            throw new ArgumentException($"Key must be {KeySizeBytes} bytes.", nameof(key));

#if NET8_0_OR_GREATER
        _h0 = _h1 = _h2 = 0;
        Poly1305Core.LoadKey64(key, out _r0, out _r1, out _r2, out _s1, out _s2, out _padLo, out _padHi);
#else
        _h0 = _h1 = _h2 = _h3 = _h4 = 0;
        Poly1305Core.LoadKey32(key,
            out _r0, out _r1, out _r2, out _r3, out _r4,
            out _s1, out _s2, out _s3, out _s4,
            out _pad0, out _pad1, out _pad2, out _pad3);
#endif

        _buffer = new byte[BlockSize];
        _bufferLength = 0;
    }

    /// <summary>
    /// Creates a new instance of the <see cref="Poly1305Mac"/> class.
    /// </summary>
    /// <param name="key">The 32-byte one-time key.</param>
    /// <returns>A new Poly1305 MAC instance.</returns>
    public static Poly1305Mac Create(byte[] key) => new(key);

    /// <summary>
    /// Creates a new instance of the <see cref="Poly1305Mac"/> class.
    /// </summary>
    /// <param name="key">The 32-byte one-time key.</param>
    /// <returns>A new Poly1305 MAC instance.</returns>
    public static Poly1305Mac Create(ReadOnlySpan<byte> key) => new(key);

    /// <inheritdoc/>
    public void Update(ReadOnlySpan<byte> input)
    {
        if (_finalized) throw new InvalidOperationException("Cannot update after finalization. Call Reset() first.");

        int offset = 0;

        // Fill the buffer if we have partial data
        if (_bufferLength > 0)
        {
            int needed = BlockSize - _bufferLength;
            if (input.Length < needed)
            {
                input.CopyTo(_buffer.AsSpan(_bufferLength));
                _bufferLength += input.Length;
                return;
            }

            input.Slice(0, needed).CopyTo(_buffer.AsSpan(_bufferLength));
            ProcessFullBlock(_buffer);
            _bufferLength = 0;
            offset = needed;
        }

        // Process full blocks directly from input
        while (offset + BlockSize <= input.Length)
        {
            ProcessFullBlock(input.Slice(offset, BlockSize));
            offset += BlockSize;
        }

        // Buffer remaining data
        int remaining = input.Length - offset;
        if (remaining > 0)
        {
            input.Slice(offset, remaining).CopyTo(_buffer.AsSpan(0));
            _bufferLength = remaining;
        }
    }

    /// <inheritdoc/>
    public void Finalize(Span<byte> destination)
    {
        if (destination.Length < TagSizeBytes) throw new ArgumentException("Destination buffer is too small.", nameof(destination));
        if (_finalized) throw new InvalidOperationException("Already finalized. Call Reset() first.");

        // Process remaining buffered data as a partial block
        if (_bufferLength > 0)
        {
#if NET8_0_OR_GREATER
            Poly1305Core.AddPartialBlock64(_buffer.AsSpan(0, _bufferLength), ref _h0, ref _h1, ref _h2);
            Poly1305Core.MulReduce64(ref _h0, ref _h1, ref _h2, _r0, _r1, _r2, _s1, _s2);
#else
            Poly1305Core.ProcessPartialBlock32(_buffer.AsSpan(0, _bufferLength),
                ref _h0, ref _h1, ref _h2, ref _h3, ref _h4,
                _r0, _r1, _r2, _r3, _r4, _s1, _s2, _s3, _s4);
#endif
        }

        // Finalize and write tag
#if NET8_0_OR_GREATER
        Poly1305Core.Finalize64(_h0, _h1, _h2, _padLo, _padHi, destination);
#else
        Poly1305Core.Finalize32(ref _h0, ref _h1, ref _h2, ref _h3, ref _h4,
            _pad0, _pad1, _pad2, _pad3, destination);
#endif

        _finalized = true;
    }

    /// <inheritdoc/>
    public void Reset()
    {
        _finalized = false;
#if NET8_0_OR_GREATER
        _h0 = _h1 = _h2 = 0;
#else
        _h0 = _h1 = _h2 = _h3 = _h4 = 0;
#endif
        Array.Clear(_buffer, 0, BlockSize);
        _bufferLength = 0;
    }

    /// <summary>
    /// Computes the Poly1305 tag for the given data in a single operation.
    /// </summary>
    /// <param name="data">The data to authenticate.</param>
    /// <returns>The 16-byte MAC tag.</returns>
    public byte[] ComputeHash(ReadOnlySpan<byte> data)
    {
        Reset();
        Update(data);
        byte[] result = new byte[TagSizeBytes];
        Finalize(result);
        return result;
    }

    /// <summary>
    /// Computes the Poly1305 tag for the given data in a single operation.
    /// </summary>
    /// <param name="data">The data to authenticate.</param>
    /// <returns>The 16-byte MAC tag.</returns>
    public byte[] ComputeHash(byte[] data)
    {
        return ComputeHash(data.AsSpan());
    }

    /// <summary>
    /// Computes the Poly1305 tag for the specified key and data in a single operation.
    /// </summary>
    /// <param name="key">The 32-byte one-time key.</param>
    /// <param name="data">The data to authenticate.</param>
    /// <returns>The 16-byte MAC tag.</returns>
    public static byte[] Hash(byte[] key, byte[] data)
    {
        using var mac = new Poly1305Mac(key);
        return mac.ComputeHash(data);
    }

    /// <inheritdoc/>
    public void Dispose()
    {
        if (!_disposed)
        {
            Array.Clear(_buffer, 0, _buffer.Length);
            _disposed = true;
        }
    }

    private void ProcessFullBlock(ReadOnlySpan<byte> block)
    {
#if NET8_0_OR_GREATER
        Poly1305Core.AddFullBlock64(block, ref _h0, ref _h1, ref _h2);
        Poly1305Core.MulReduce64(ref _h0, ref _h1, ref _h2, _r0, _r1, _r2, _s1, _s2);
#else
        Poly1305Core.ProcessFullBlock32(block,
            ref _h0, ref _h1, ref _h2, ref _h3, ref _h4,
            _r0, _r1, _r2, _r3, _r4, _s1, _s2, _s3, _s4);
#endif
    }
}
