// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

#pragma warning disable IDE1006 // Naming rule violation - IV and Sigma are standard cryptographic constant names per RFC 7693
#pragma warning disable CS0414  // _simdSupport is read inside #if NET8_0_OR_GREATER guard

namespace CryptoHives.Foundation.Security.Cryptography.Hash;

using System;
using System.Buffers.Binary;
using System.Numerics;
using System.Runtime.CompilerServices;
#if NET8_0_OR_GREATER
using System.Runtime.Intrinsics;
using System.Runtime.Intrinsics.X86;
#endif

/// <summary>
/// Computes the BLAKE2b hash for the input data.
/// </summary>
/// <remarks>
/// <para>
/// This is a fully managed implementation of BLAKE2b that does not rely on
/// OS or hardware cryptographic APIs, ensuring deterministic behavior across
/// all platforms and runtimes.
/// </para>
/// <para>
/// BLAKE2b is optimized for 64-bit platforms and produces digests from 1 to 64 bytes.
/// The default output size is 64 bytes (512 bits).
/// </para>
/// <para>
/// BLAKE2b supports an optional key for keyed hashing (MAC mode) with keys up to 64 bytes.
/// </para>
/// </remarks>
public sealed partial class Blake2b : HashAlgorithm
{
    /// <summary>
    /// The maximum hash size in bits.
    /// </summary>
    public const int MaxHashSizeBits = 512;

    /// <summary>
    /// The maximum hash size in bytes.
    /// </summary>
    public const int MaxHashSizeBytes = MaxHashSizeBits / 8;

    /// <summary>
    /// The maximum key size in bytes.
    /// </summary>
    public const int MaxKeySizeBytes = 64;

    /// <summary>
    /// The block size in bytes.
    /// </summary>
    public const int BlockSizeBytes = 128;

    // Rounds of mixing
    private const int Rounds = 12;

    // The size of the state buffer
    private const int StateSize = 8;

    // The size of the scratch buffers
    private const int ScratchSize = 16;

    // BLAKE2b IV constants (same as SHA-512)
    private static readonly ulong[] IV =
    [
        0x6a09e667f3bcc908UL,
        0xbb67ae8584caa73bUL,
        0x3c6ef372fe94f82bUL,
        0xa54ff53a5f1d36f1UL,
        0x510e527fade682d1UL,
        0x9b05688c2b3e6c1fUL,
        0x1f83d9abfb41bd6bUL,
        0x5be0cd19137e2179UL
    ];

    // BLAKE2b sigma permutations for message scheduling
    private static readonly byte[] Sigma = new byte[Rounds * ScratchSize]
    {
        0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15,
        14, 10, 4, 8, 9, 15, 13, 6, 1, 12, 0, 2, 11, 7, 5, 3,
        11, 8, 12, 0, 5, 2, 15, 13, 10, 14, 3, 6, 7, 1, 9, 4,
        7, 9, 3, 1, 13, 12, 11, 14, 2, 6, 5, 10, 4, 0, 15, 8,
        9, 0, 5, 7, 2, 4, 10, 15, 14, 1, 11, 12, 6, 8, 3, 13,
        2, 12, 6, 10, 0, 11, 8, 3, 4, 13, 7, 5, 15, 14, 1, 9,
        12, 5, 1, 15, 14, 13, 4, 10, 0, 7, 6, 3, 9, 2, 8, 11,
        13, 11, 7, 14, 12, 1, 3, 9, 5, 0, 15, 4, 8, 6, 2, 10,
        6, 15, 14, 9, 11, 3, 0, 8, 12, 2, 13, 7, 1, 4, 10, 5,
        10, 2, 8, 4, 7, 6, 1, 5, 15, 11, 9, 14, 3, 12, 13, 0,
        0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15,
        14, 10, 4, 8, 9, 15, 13, 6, 1, 12, 0, 2, 11, 7, 5, 3
    };

    // Delegate types for SIMD dispatch — set once in constructor, avoiding per-call branch checks
    private delegate void InitializeStateAction(ulong paramBlock);
    private delegate void ExtractOutputAction(Span<byte> destination);

    private readonly InitializeStateAction _initializeState;
    private readonly ExtractOutputAction _extractOutput;

    // Scalar state for non-AVX2 path and output extraction
    private readonly SimdSupport _simdSupport;
    private readonly ulong[] _state;
    private readonly byte[] _buffer;
    private readonly byte[]? _key;
    private readonly int _outputBytes;
    private ulong _bytesCompressed;
    private int _bufferLength;

    /// <summary>
    /// Initializes a new instance of the <see cref="Blake2b"/> class with default output size (64 bytes).
    /// </summary>
    public Blake2b() : this(SimdSupport.All, MaxHashSizeBytes, null)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Blake2b"/> class with specified output size.
    /// </summary>
    /// <param name="outputBytes">The desired output size in bytes (1-64).</param>
    public Blake2b(int outputBytes) : this(SimdSupport.All, outputBytes, null)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Blake2b"/> class with specified output size and key.
    /// </summary>
    /// <param name="outputBytes">The desired output size in bytes (1-64).</param>
    /// <param name="key">The optional key for keyed hashing (MAC mode). Must be 0-64 bytes.</param>
    public Blake2b(int outputBytes, byte[]? key) : this(SimdSupport.All, outputBytes, key)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Blake2b"/> class with specified output size, key, and SIMD support.
    /// </summary>
    /// <param name="outputBytes">The desired output size in bytes (1-64).</param>
    /// <param name="key">The optional key for keyed hashing (MAC mode). Must be 0-64 bytes.</param>
    /// <param name="simdSupport">The SIMD instruction sets to use. Use <see cref="SimdSupport.None"/> for scalar-only.</param>
    internal Blake2b(SimdSupport simdSupport, int outputBytes, byte[]? key)
    {
        if (outputBytes < 1 || outputBytes > MaxHashSizeBytes)
        {
            throw new ArgumentOutOfRangeException(nameof(outputBytes),
                $"Output size must be between 1 and {MaxHashSizeBytes} bytes.");
        }

        if (key != null && key.Length > MaxKeySizeBytes)
        {
            throw new ArgumentOutOfRangeException(nameof(key),
                $"Key size must be between 0 and {MaxKeySizeBytes} bytes.");
        }

        _outputBytes = outputBytes;
        HashSizeValue = outputBytes * 8;
        _state = new ulong[StateSize];
        _buffer = new byte[BlockSizeBytes];

        _simdSupport = SimdSupport.None;
        _initializeState = InitializeStateScalar;
        _extractOutput = ExtractOutputScalar;
#if NET8_0_OR_GREATER
        _simdSupport = simdSupport & Blake2b.SimdSupport;
        if ((simdSupport & Blake2b.SimdSupport & SimdSupport.Neon) != 0)
        {
            _initializeState = InitializeStateNeon;
            _extractOutput = ExtractOutputNeon;
        }
#endif

        if (key != null && key.Length > 0)
        {
            _key = new byte[key.Length];
            Array.Copy(key, _key, key.Length);
        }

        Initialize();
    }

    /// <inheritdoc/>
    public override string AlgorithmName => _key != null ? "BLAKE2b-MAC" : "BLAKE2b";

    /// <inheritdoc/>
    public override int BlockSize => BlockSizeBytes;

    /// <summary>
    /// Gets a value indicating whether this instance is configured for keyed hashing (MAC mode).
    /// </summary>
    public bool IsKeyed => _key != null;

    /// <summary>
    /// Creates a new instance of the <see cref="Blake2b"/> class with default output size.
    /// </summary>
    /// <returns>A new BLAKE2b instance.</returns>
    public static new Blake2b Create() => new();

    /// <summary>
    /// Creates a new instance of the <see cref="Blake2b"/> class with specified output size.
    /// </summary>
    /// <param name="outputBytes">The desired output size in bytes (1-64).</param>
    /// <returns>A new BLAKE2b instance.</returns>
    public static Blake2b Create(int outputBytes) => new(outputBytes);

    /// <summary>
    /// Creates a new instance of the <see cref="Blake2b"/> class with specified output size and SIMD support.
    /// </summary>
    /// <param name="simdSupport">The SIMD instruction sets to use.</param>
    /// <param name="outputBytes">The desired output size in bytes (1-64).</param>
    /// <returns>A new BLAKE2b instance.</returns>
    internal static Blake2b Create(SimdSupport simdSupport, int outputBytes) => new(simdSupport, outputBytes, null);

    /// <summary>
    /// Creates a new keyed instance of the <see cref="Blake2b"/> class.
    /// </summary>
    /// <param name="outputBytes">The desired output size in bytes (1-64).</param>
    /// <param name="key">The key for keyed hashing (up to 64 bytes).</param>
    /// <returns>A new BLAKE2b instance configured for keyed hashing.</returns>
    public static Blake2b CreateKeyed(int outputBytes, byte[] key) => new(outputBytes, key);

    /// <summary>
    /// Creates a new keyed instance of the <see cref="Blake2b"/> class with default output size.
    /// </summary>
    /// <param name="key">The key for keyed hashing (up to 64 bytes).</param>
    /// <returns>A new BLAKE2b instance configured for keyed hashing.</returns>
    public static Blake2b CreateKeyed(byte[] key) => new(MaxHashSizeBytes, key);

    /// <summary>
    /// Creates a new keyed instance of the <see cref="Blake2b"/> class with specified SIMD support.
    /// </summary>
    /// <param name="outputBytes">The desired output size in bytes (1-64).</param>
    /// <param name="key">The key for keyed hashing (up to 64 bytes).</param>
    /// <param name="simdSupport">The SIMD instruction sets to use.</param>
    /// <returns>A new BLAKE2b instance configured for keyed hashing.</returns>
    internal static Blake2b CreateKeyed(SimdSupport simdSupport, int outputBytes, byte[] key) => new(simdSupport, outputBytes, key);

    /// <inheritdoc/>
    public override void Initialize()
    {
        int keyLength = _key?.Length ?? 0;
        ulong paramBlock = 0x01010000UL | ((ulong)keyLength << 8) | (uint)_outputBytes;

        _initializeState(paramBlock);

        _bytesCompressed = 0;
        _bufferLength = 0;
        ClearBuffer(_buffer);

        // If keyed, the first block is the zero-padded key
        if (_key != null && _key.Length > 0)
        {
            Array.Copy(_key, _buffer, _key.Length);
            _bufferLength = BlockSizeBytes;
        }
    }

    [MethodImpl(MethodImplOptionsEx.HotPath)]
    private void Compress(ReadOnlySpan<byte> block, int bytesConsumed, bool isFinal)
    {
#if NET8_0_OR_GREATER
        if ((_simdSupport & SimdSupport.Avx2) != 0)
        {
            CompressAvx2(block, bytesConsumed, isFinal);
        }
        else if ((_simdSupport & SimdSupport.Neon) != 0)
        {
            CompressNeon(block, bytesConsumed, isFinal);
        }
        else
#endif
        {
            CompressScalar(block, bytesConsumed, isFinal);
        }
    }

    private void InitializeStateScalar(ulong paramBlock)
    {
        Array.Copy(IV, _state, StateSize);
        _state[0] ^= paramBlock;
    }

    /// <inheritdoc/>
    protected override void HashCore(ReadOnlySpan<byte> source)
    {
        int offset = 0;

        // If we have data in buffer, fill it first
        if (_bufferLength > 0)
        {
            int toCopy = Math.Min(BlockSizeBytes - _bufferLength, source.Length);
            source.Slice(0, toCopy).CopyTo(_buffer.AsSpan(_bufferLength));
            _bufferLength += toCopy;
            offset += toCopy;

            // Only compress if buffer is full AND there's more data coming
            // (we need to keep the last block for finalization)
            if (_bufferLength == BlockSizeBytes && offset < source.Length)
            {
                Compress(_buffer, BlockSizeBytes, false);
                _bufferLength = 0;
            }
        }

        // Process full blocks, but always keep at least one block for finalization
        while (offset + BlockSizeBytes < source.Length)
        {
            Compress(source.Slice(offset, BlockSizeBytes), BlockSizeBytes, false);
            offset += BlockSizeBytes;
        }

        // Store remaining bytes in buffer
        if (offset < source.Length)
        {
            int remaining = source.Length - offset;
            if (_bufferLength == 0)
            {
                source.Slice(offset, remaining).CopyTo(_buffer.AsSpan());
                _bufferLength = remaining;
            }
            else
            {
                // Buffer already has data, append to it
                source.Slice(offset, remaining).CopyTo(_buffer.AsSpan(_bufferLength));
                _bufferLength += remaining;
            }
        }
    }

    /// <inheritdoc/>
    protected override bool TryHashFinal(Span<byte> destination, out int bytesWritten)
    {
        if (destination.Length < _outputBytes)
        {
            bytesWritten = 0;
            return false;
        }

        // Zero-pad the remaining buffer
        _buffer.AsSpan(_bufferLength).Clear();

        // Compress final block
        Compress(_buffer, _bufferLength, true);

        // Extract output using dispatch delegate
        _extractOutput(destination);

        bytesWritten = _outputBytes;
        return true;
    }

    private void ExtractOutputScalar(Span<byte> destination)
    {
        int fullWords = _outputBytes / sizeof(UInt64);

        BinarySpans.WriteUInt64LittleEndian(_state.AsSpan(0, fullWords), destination);

        // Handle partial final word
        int remainingBytes = _outputBytes % sizeof(UInt64);
        if (remainingBytes > 0)
        {
            Span<byte> temp = stackalloc byte[sizeof(UInt64)];
            BinaryPrimitives.WriteUInt64LittleEndian(temp, _state[fullWords]);
            temp.Slice(0, remainingBytes).CopyTo(destination.Slice(fullWords * sizeof(UInt64)));
        }
    }

    /// <inheritdoc/>
    protected override void Dispose(bool disposing)
    {
        if (disposing)
        {
            Array.Clear(_state, 0, _state.Length);
            ClearBuffer(_buffer);
            if (_key != null)
            {
                ClearBuffer(_key);
            }
        }
        base.Dispose(disposing);
    }

    [SkipLocalsInit]
    [MethodImpl(MethodImplOptionsEx.OptimizedLoop)]
    private void CompressScalar(ReadOnlySpan<byte> block, int bytesConsumed, bool isFinal)
    {
        _bytesCompressed += (ulong)bytesConsumed;

        // Load all 16 message words into locals — eliminates span bounds checks and
        // Sigma array indirections from the 12 fully-unrolled rounds below.
        Span<ulong> msgBuf = stackalloc ulong[ScratchSize];
        BinarySpans.ReadUInt64LittleEndian(block, msgBuf);
        ref ulong mr = ref msgBuf[0];
        ulong m0  = mr,                     m1  = Unsafe.Add(ref mr, 1),
              m2  = Unsafe.Add(ref mr, 2),  m3  = Unsafe.Add(ref mr, 3),
              m4  = Unsafe.Add(ref mr, 4),  m5  = Unsafe.Add(ref mr, 5),
              m6  = Unsafe.Add(ref mr, 6),  m7  = Unsafe.Add(ref mr, 7),
              m8  = Unsafe.Add(ref mr, 8),  m9  = Unsafe.Add(ref mr, 9),
              m10 = Unsafe.Add(ref mr, 10), m11 = Unsafe.Add(ref mr, 11),
              m12 = Unsafe.Add(ref mr, 12), m13 = Unsafe.Add(ref mr, 13),
              m14 = Unsafe.Add(ref mr, 14), m15 = Unsafe.Add(ref mr, 15);

        // Load current hash state into 16 local working-vector variables.
        // The JIT can allocate these in registers — unlike Span<ulong> which forces
        // every element access through a bounds-checked memory dereference.
        ref ulong sr = ref _state[0];
        ulong v0  = sr,                     v1  = Unsafe.Add(ref sr, 1),
              v2  = Unsafe.Add(ref sr, 2),  v3  = Unsafe.Add(ref sr, 3),
              v4  = Unsafe.Add(ref sr, 4),  v5  = Unsafe.Add(ref sr, 5),
              v6  = Unsafe.Add(ref sr, 6),  v7  = Unsafe.Add(ref sr, 7);

        // IV constants
        ulong v8  = IV[0], v9  = IV[1],
              v10 = IV[2], v11 = IV[3],
              v12 = IV[4] ^ _bytesCompressed,
              v13 = IV[5],
              v14 = isFinal ? ~IV[6] : IV[6],
              v15 = IV[7];

        // 10+2 rounds, fully unrolled — no loop counter, no Sigma table access at runtime.
        // Round 0 — sigma: 0,1,2,3,4,5,6,7,8,9,10,11,12,13,14,15
        G(ref v0, ref v4, ref v8,  ref v12, m0,  m1);  G(ref v1, ref v5, ref v9,  ref v13, m2,  m3);
        G(ref v2, ref v6, ref v10, ref v14, m4,  m5);  G(ref v3, ref v7, ref v11, ref v15, m6,  m7);
        G(ref v0, ref v5, ref v10, ref v15, m8,  m9);  G(ref v1, ref v6, ref v11, ref v12, m10, m11);
        G(ref v2, ref v7, ref v8,  ref v13, m12, m13); G(ref v3, ref v4, ref v9,  ref v14, m14, m15);
        // Round 1 — sigma: 14,10,4,8,9,15,13,6,1,12,0,2,11,7,5,3
        G(ref v0, ref v4, ref v8,  ref v12, m14, m10); G(ref v1, ref v5, ref v9,  ref v13, m4,  m8);
        G(ref v2, ref v6, ref v10, ref v14, m9,  m15); G(ref v3, ref v7, ref v11, ref v15, m13, m6);
        G(ref v0, ref v5, ref v10, ref v15, m1,  m12); G(ref v1, ref v6, ref v11, ref v12, m0,  m2);
        G(ref v2, ref v7, ref v8,  ref v13, m11, m7);  G(ref v3, ref v4, ref v9,  ref v14, m5,  m3);
        // Round 2 — sigma: 11,8,12,0,5,2,15,13,10,14,3,6,7,1,9,4
        G(ref v0, ref v4, ref v8,  ref v12, m11, m8);  G(ref v1, ref v5, ref v9,  ref v13, m12, m0);
        G(ref v2, ref v6, ref v10, ref v14, m5,  m2);  G(ref v3, ref v7, ref v11, ref v15, m15, m13);
        G(ref v0, ref v5, ref v10, ref v15, m10, m14); G(ref v1, ref v6, ref v11, ref v12, m3,  m6);
        G(ref v2, ref v7, ref v8,  ref v13, m7,  m1);  G(ref v3, ref v4, ref v9,  ref v14, m9,  m4);
        // Round 3 — sigma: 7,9,3,1,13,12,11,14,2,6,5,10,4,0,15,8
        G(ref v0, ref v4, ref v8,  ref v12, m7,  m9);  G(ref v1, ref v5, ref v9,  ref v13, m3,  m1);
        G(ref v2, ref v6, ref v10, ref v14, m13, m12); G(ref v3, ref v7, ref v11, ref v15, m11, m14);
        G(ref v0, ref v5, ref v10, ref v15, m2,  m6);  G(ref v1, ref v6, ref v11, ref v12, m5,  m10);
        G(ref v2, ref v7, ref v8,  ref v13, m4,  m0);  G(ref v3, ref v4, ref v9,  ref v14, m15, m8);
        // Round 4 — sigma: 9,0,5,7,2,4,10,15,14,1,11,12,6,8,3,13
        G(ref v0, ref v4, ref v8,  ref v12, m9,  m0);  G(ref v1, ref v5, ref v9,  ref v13, m5,  m7);
        G(ref v2, ref v6, ref v10, ref v14, m2,  m4);  G(ref v3, ref v7, ref v11, ref v15, m10, m15);
        G(ref v0, ref v5, ref v10, ref v15, m14, m1);  G(ref v1, ref v6, ref v11, ref v12, m11, m12);
        G(ref v2, ref v7, ref v8,  ref v13, m6,  m8);  G(ref v3, ref v4, ref v9,  ref v14, m3,  m13);
        // Round 5 — sigma: 2,12,6,10,0,11,8,3,4,13,7,5,15,14,1,9
        G(ref v0, ref v4, ref v8,  ref v12, m2,  m12); G(ref v1, ref v5, ref v9,  ref v13, m6,  m10);
        G(ref v2, ref v6, ref v10, ref v14, m0,  m11); G(ref v3, ref v7, ref v11, ref v15, m8,  m3);
        G(ref v0, ref v5, ref v10, ref v15, m4,  m13); G(ref v1, ref v6, ref v11, ref v12, m7,  m5);
        G(ref v2, ref v7, ref v8,  ref v13, m15, m14); G(ref v3, ref v4, ref v9,  ref v14, m1,  m9);
        // Round 6 — sigma: 12,5,1,15,14,13,4,10,0,7,6,3,9,2,8,11
        G(ref v0, ref v4, ref v8,  ref v12, m12, m5);  G(ref v1, ref v5, ref v9,  ref v13, m1,  m15);
        G(ref v2, ref v6, ref v10, ref v14, m14, m13); G(ref v3, ref v7, ref v11, ref v15, m4,  m10);
        G(ref v0, ref v5, ref v10, ref v15, m0,  m7);  G(ref v1, ref v6, ref v11, ref v12, m6,  m3);
        G(ref v2, ref v7, ref v8,  ref v13, m9,  m2);  G(ref v3, ref v4, ref v9,  ref v14, m8,  m11);
        // Round 7 — sigma: 13,11,7,14,12,1,3,9,5,0,15,4,8,6,2,10
        G(ref v0, ref v4, ref v8,  ref v12, m13, m11); G(ref v1, ref v5, ref v9,  ref v13, m7,  m14);
        G(ref v2, ref v6, ref v10, ref v14, m12, m1);  G(ref v3, ref v7, ref v11, ref v15, m3,  m9);
        G(ref v0, ref v5, ref v10, ref v15, m5,  m0);  G(ref v1, ref v6, ref v11, ref v12, m15, m4);
        G(ref v2, ref v7, ref v8,  ref v13, m8,  m6);  G(ref v3, ref v4, ref v9,  ref v14, m2,  m10);
        // Round 8 — sigma: 6,15,14,9,11,3,0,8,12,2,13,7,1,4,10,5
        G(ref v0, ref v4, ref v8,  ref v12, m6,  m15); G(ref v1, ref v5, ref v9,  ref v13, m14, m9);
        G(ref v2, ref v6, ref v10, ref v14, m11, m3);  G(ref v3, ref v7, ref v11, ref v15, m0,  m8);
        G(ref v0, ref v5, ref v10, ref v15, m12, m2);  G(ref v1, ref v6, ref v11, ref v12, m13, m7);
        G(ref v2, ref v7, ref v8,  ref v13, m1,  m4);  G(ref v3, ref v4, ref v9,  ref v14, m10, m5);
        // Round 9 — sigma: 10,2,8,4,7,6,1,5,15,11,9,14,3,12,13,0
        G(ref v0, ref v4, ref v8,  ref v12, m10, m2);  G(ref v1, ref v5, ref v9,  ref v13, m8,  m4);
        G(ref v2, ref v6, ref v10, ref v14, m7,  m6);  G(ref v3, ref v7, ref v11, ref v15, m1,  m5);
        G(ref v0, ref v5, ref v10, ref v15, m15, m11); G(ref v1, ref v6, ref v11, ref v12, m9,  m14);
        G(ref v2, ref v7, ref v8,  ref v13, m3,  m12); G(ref v3, ref v4, ref v9,  ref v14, m13, m0);
        // Round 10 — (same as round 0)
        G(ref v0, ref v4, ref v8,  ref v12, m0,  m1);  G(ref v1, ref v5, ref v9,  ref v13, m2,  m3);
        G(ref v2, ref v6, ref v10, ref v14, m4,  m5);  G(ref v3, ref v7, ref v11, ref v15, m6,  m7);
        G(ref v0, ref v5, ref v10, ref v15, m8,  m9);  G(ref v1, ref v6, ref v11, ref v12, m10, m11);
        G(ref v2, ref v7, ref v8,  ref v13, m12, m13); G(ref v3, ref v4, ref v9,  ref v14, m14, m15);
        // Round 11 — (same as round 1)
        G(ref v0, ref v4, ref v8,  ref v12, m14, m10); G(ref v1, ref v5, ref v9,  ref v13, m4,  m8);
        G(ref v2, ref v6, ref v10, ref v14, m9,  m15); G(ref v3, ref v7, ref v11, ref v15, m13, m6);
        G(ref v0, ref v5, ref v10, ref v15, m1,  m12); G(ref v1, ref v6, ref v11, ref v12, m0,  m2);
        G(ref v2, ref v7, ref v8,  ref v13, m11, m7);  G(ref v3, ref v4, ref v9,  ref v14, m5,  m3);

        // Finalize: state[i] ^= v[i] ^ v[i+8] — bounds-check-free via Unsafe.Add
        sr                      ^= v0 ^ v8;
        Unsafe.Add(ref sr, 1)   ^= v1 ^ v9;
        Unsafe.Add(ref sr, 2)   ^= v2 ^ v10;
        Unsafe.Add(ref sr, 3)   ^= v3 ^ v11;
        Unsafe.Add(ref sr, 4)   ^= v4 ^ v12;
        Unsafe.Add(ref sr, 5)   ^= v5 ^ v13;
        Unsafe.Add(ref sr, 6)   ^= v6 ^ v14;
        Unsafe.Add(ref sr, 7)   ^= v7 ^ v15;
    }

    /// <summary>
    /// BLAKE2b mixing function G.
    /// </summary>
    [MethodImpl(MethodImplOptionsEx.HotPath)]
    private static void G(ref ulong a, ref ulong b, ref ulong c, ref ulong d, ulong x, ulong y)
    {
        unchecked
        {
            a = a + b + x;
            d = BitOperations.RotateRight(d ^ a, 32);
            c = c + d;
            b = BitOperations.RotateRight(b ^ c, 24);
            a = a + b + y;
            d = BitOperations.RotateRight(d ^ a, 16);
            c = c + d;
            b = BitOperations.RotateRight(b ^ c, 63);
        }
    }
}
