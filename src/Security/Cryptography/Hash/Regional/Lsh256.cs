// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Security.Cryptography.Hash;

using System;
using System.Buffers;
using System.Buffers.Binary;
using System.Diagnostics;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

/// <summary>
/// Computes the LSH-256 hash for the input data.
/// </summary>
/// <remarks>
/// <para>
/// This is a fully managed implementation of LSH-256 that does not rely on
/// OS or hardware cryptographic APIs, ensuring deterministic behavior across
/// all platforms and runtimes.
/// </para>
/// <para>
/// LSH is the Korean national cryptographic hash standard defined in KS X 3262.
/// The LSH-256 family uses 32-bit words and supports output sizes of 224 or 256 bits.
/// </para>
/// <para>
/// The algorithm uses a wide-pipe Merkle-Damgård construction with 26 steps,
/// each consisting of message addition, a mixing function with rotation-based
/// diffusion, and a word permutation.
/// </para>
/// <para>
/// Implementation follows the specification published by KISA (Korea Internet
/// &amp; Security Agency) and the official reference implementation.
/// </para>
/// </remarks>
public sealed class Lsh256 : HashAlgorithm
{
    /// <summary>
    /// Number of 32-bit words in each half of the chaining variable.
    /// </summary>
    private const int NumWords = 8;

    /// <summary>
    /// Total number of mixing steps in the compression function.
    /// </summary>
    private const int NumSteps = 26;

    /// <summary>
    /// Message block size in bytes (32 words × 4 bytes).
    /// </summary>
    private const int MsgBlockBytes = 128;

    private const int AlphaEven = 29;
    private const int BetaEven = 1;
    private const int AlphaOdd = 5;
    private const int BetaOdd = 17;

    /// <summary>
    /// Per-element rotation amounts for the gamma rotation in the mix function.
    /// </summary>
    private static readonly int[] Gamma = [0, 8, 16, 24, 24, 16, 8, 0];

    /// <summary>
    /// Precomputed step constants for all 26 steps (26 × 8 values).
    /// </summary>
    private static readonly uint[] StepConstants = InitializeStepConstants();

    /// <summary>
    /// Initial values for LSH-256-224.
    /// </summary>
    private static readonly uint[] Iv224 =
    [
        0x068608D3, 0x62D8F7A7, 0xD76652AB, 0x4C600A43,
        0xBDC40AA8, 0x1ECA0B68, 0xDA1A89BE, 0x3147D354,
        0x707EB4F9, 0xF65B3862, 0x6B0B2ABE, 0x56B8EC0A,
        0xCF237286, 0xEE0D1727, 0x33636595, 0x8BB8D05F
    ];

    /// <summary>
    /// Initial values for LSH-256-256.
    /// </summary>
    private static readonly uint[] Iv256 =
    [
        0x46A10F1F, 0xFDDCE486, 0xB41443A8, 0x198E6B9D,
        0x3304388D, 0xB0F5A3C7, 0xB36061C4, 0x7ADBD553,
        0x105D5378, 0x2F74DE54, 0x5C2F2D95, 0xF2553FBE,
        0x8051357A, 0x138668C8, 0x47AA4484, 0xE01AFB41
    ];

    private static uint[] InitializeStepConstants()
    {
        unchecked
        {
            var stepConstants = new uint[NumSteps * NumWords];

            // SC[0]: initial step constant
            ReadOnlySpan<uint> sc0 =
            [
                0x917caf90, 0x6c1b10a2, 0x6f352943, 0xcf778243,
                0x2ceb7472, 0x29e96ff2, 0x8a9ba428, 0x2eeb2642
            ];

            for (int l = 0; l < NumWords; l++)
            {
                stepConstants[l] = sc0[l];
            }

            // SC[j][l] = SC[j-1][l] + rotL(SC[j-1][l], 8)
            for (int j = 1; j < NumSteps; j++)
            {
                int cur = j * NumWords;
                int prev = (j - 1) * NumWords;
                for (int l = 0; l < NumWords; l++)
                {
                    uint p = stepConstants[prev + l];
                    stepConstants[cur + l] = p + BitOperations.RotateLeft(p, 8);
                }
            }

            return stepConstants;
        }
    }

    private readonly int _hashSizeBytes;
    private readonly uint[] _iv;
    private readonly uint[] _cvL;
    private readonly uint[] _cvR;
    private readonly uint[] _submsgEL;
    private readonly uint[] _submsgER;
    private readonly uint[] _submsgOL;
    private readonly uint[] _submsgOR;
    private readonly byte[] _buffer;
    private int _bufferLength;
    private bool _disposed;

    /// <summary>
    /// Initializes a new instance of the <see cref="Lsh256"/> class with 256-bit output.
    /// </summary>
    public Lsh256() : this(32)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Lsh256"/> class.
    /// </summary>
    /// <param name="hashSizeBytes">The desired output size in bytes (28 or 32).</param>
    /// <exception cref="ArgumentException">
    /// Thrown when <paramref name="hashSizeBytes"/> is not 28 or 32.
    /// </exception>
    public Lsh256(int hashSizeBytes)
    {
        if (hashSizeBytes != 28 && hashSizeBytes != 32)
        {
            throw new ArgumentException(
                "Hash size must be 28 (224-bit) or 32 (256-bit) bytes.",
                nameof(hashSizeBytes));
        }

        _hashSizeBytes = hashSizeBytes;
        HashSizeValue = hashSizeBytes * 8;

        _iv = hashSizeBytes switch {
            28 => Iv224,
            _ => Iv256
        };

        _cvL = new uint[NumWords];
        _cvR = new uint[NumWords];
        _submsgEL = new uint[NumWords];
        _submsgER = new uint[NumWords];
        _submsgOL = new uint[NumWords];
        _submsgOR = new uint[NumWords];
        _buffer = new byte[MsgBlockBytes];
        Initialize();
    }

    /// <inheritdoc/>
    public override string AlgorithmName => $"LSH-256-{_hashSizeBytes * 8}";

    /// <inheritdoc/>
    public override int BlockSize => MsgBlockBytes;

    /// <summary>
    /// Creates a new instance with default 256-bit output.
    /// </summary>
    /// <returns>A new <see cref="Lsh256"/> instance.</returns>
    public static new Lsh256 Create() => new();

    /// <summary>
    /// Creates a new instance with specified output size.
    /// </summary>
    /// <param name="hashSizeBytes">The hash size in bytes (28 or 32).</param>
    /// <returns>A new <see cref="Lsh256"/> instance.</returns>
    public static Lsh256 Create(int hashSizeBytes) => new(hashSizeBytes);

    private static readonly Microsoft.Extensions.ObjectPool.ObjectPool<Lsh256> _pool224
        = HashAlgorithmPool.CreatePool(() => new Lsh256(28));

    private static readonly Microsoft.Extensions.ObjectPool.ObjectPool<Lsh256> _pool256
        = HashAlgorithmPool.CreatePool(() => new Lsh256(32));

    /// <summary>
    /// Computes the LSH-256 hash of <paramref name="source"/> and writes it into <paramref name="destination"/>.
    /// </summary>
    /// <param name="source">The input data to hash.</param>
    /// <param name="destination">The buffer to receive the hash value. Must be at least <paramref name="hashSizeBytes"/> bytes.</param>
    /// <param name="hashSizeBytes">The desired output size in bytes (28 or 32).</param>
    /// <param name="bytesWritten">When this method returns, the number of bytes written into <paramref name="destination"/>.</param>
    /// <returns><see langword="true"/> if <paramref name="destination"/> was large enough; otherwise, <see langword="false"/>.</returns>
    /// <exception cref="ArgumentException">Thrown when <paramref name="hashSizeBytes"/> is not 28 or 32.</exception>
    public static bool TryHashData(ReadOnlySpan<byte> source, Span<byte> destination, int hashSizeBytes, out int bytesWritten)
    {
        var pool = hashSizeBytes switch {
            28 => _pool224,
            32 => _pool256,
            _ => throw new ArgumentException("Hash size must be 28 or 32 bytes.", nameof(hashSizeBytes))
        };
        return HashAlgorithmPool.TryHashData(pool, source, destination, out bytesWritten);
    }

    /// <summary>
    /// Computes the LSH-256 hash of <paramref name="source"/> and returns it as a new byte array.
    /// </summary>
    /// <param name="source">The input data to hash.</param>
    /// <param name="hashSizeBytes">The desired output size in bytes (28 or 32).</param>
    /// <returns>A new byte array containing the LSH-256 hash.</returns>
    /// <exception cref="ArgumentException">Thrown when <paramref name="hashSizeBytes"/> is not 28 or 32.</exception>
    public static byte[] HashData(ReadOnlySpan<byte> source, int hashSizeBytes)
    {
        var pool = hashSizeBytes switch {
            28 => _pool224,
            32 => _pool256,
            _ => throw new ArgumentException("Hash size must be 28 or 32 bytes.", nameof(hashSizeBytes))
        };
        return HashAlgorithmPool.HashData(pool, source);
    }

    /// <summary>
    /// Computes the LSH-256 hash of <paramref name="source"/> and writes it into <paramref name="destination"/>.
    /// </summary>
    /// <param name="source">The (possibly multi-segment) input sequence to hash.</param>
    /// <param name="destination">The buffer to receive the hash value. Must be at least <paramref name="hashSizeBytes"/> bytes.</param>
    /// <param name="hashSizeBytes">The desired output size in bytes (28 or 32).</param>
    /// <param name="bytesWritten">When this method returns, the number of bytes written into <paramref name="destination"/>.</param>
    /// <returns><see langword="true"/> if <paramref name="destination"/> was large enough; otherwise, <see langword="false"/>.</returns>
    /// <exception cref="ArgumentException">Thrown when <paramref name="hashSizeBytes"/> is not 28 or 32.</exception>
    public static bool TryHashData(in ReadOnlySequence<byte> source, Span<byte> destination, int hashSizeBytes, out int bytesWritten)
    {
        var pool = hashSizeBytes switch {
            28 => _pool224,
            32 => _pool256,
            _ => throw new ArgumentException("Hash size must be 28 or 32 bytes.", nameof(hashSizeBytes))
        };
        return HashAlgorithmPool.TryHashData(pool, source, destination, out bytesWritten);
    }

    /// <summary>
    /// Computes the LSH-256 hash of <paramref name="source"/> and returns it as a new byte array.
    /// </summary>
    /// <param name="source">The (possibly multi-segment) input sequence to hash.</param>
    /// <param name="hashSizeBytes">The desired output size in bytes (28 or 32).</param>
    /// <returns>A new byte array containing the LSH-256 hash.</returns>
    /// <exception cref="ArgumentException">Thrown when <paramref name="hashSizeBytes"/> is not 28 or 32.</exception>
    public static byte[] HashData(in ReadOnlySequence<byte> source, int hashSizeBytes)
    {
        var pool = hashSizeBytes switch {
            28 => _pool224,
            32 => _pool256,
            _ => throw new ArgumentException("Hash size must be 28 or 32 bytes.", nameof(hashSizeBytes))
        };
        return HashAlgorithmPool.HashData(pool, source);
    }

    /// <inheritdoc/>
    /// <exception cref="ObjectDisposedException">Thrown when the instance has been disposed.</exception>
    public override void Initialize()
    {
        if (_disposed) throw new ObjectDisposedException(nameof(Lsh256));
        Array.Copy(_iv, 0, _cvL, 0, NumWords);
        Array.Copy(_iv, NumWords, _cvR, 0, NumWords);
        _bufferLength = 0;
    }

    /// <inheritdoc/>
    /// <exception cref="ObjectDisposedException">Thrown when the instance has been disposed.</exception>
    protected override void HashCore(ReadOnlySpan<byte> source)
    {
        if (_disposed) throw new ObjectDisposedException(nameof(Lsh256));
        int offset = 0;

        if (_bufferLength > 0)
        {
            int toCopy = Math.Min(MsgBlockBytes - _bufferLength, source.Length);
            source.Slice(0, toCopy).CopyTo(_buffer.AsSpan(_bufferLength));
            _bufferLength += toCopy;
            offset += toCopy;

            if (_bufferLength == MsgBlockBytes)
            {
                Compress(_buffer);
                _bufferLength = 0;
            }
        }

        while (offset + MsgBlockBytes <= source.Length)
        {
            Compress(source.Slice(offset, MsgBlockBytes));
            offset += MsgBlockBytes;
        }

        int remaining = source.Length - offset;
        if (remaining > 0)
        {
            source.Slice(offset, remaining).CopyTo(_buffer.AsSpan());
            _bufferLength = remaining;
        }
    }

    /// <inheritdoc/>
    /// <exception cref="ObjectDisposedException">Thrown when the instance has been disposed.</exception>
    protected override bool TryHashFinal(Span<byte> destination, out int bytesWritten)
    {
        if (_disposed) throw new ObjectDisposedException(nameof(Lsh256));
        if (destination.Length < _hashSizeBytes)
        {
            bytesWritten = 0;
            return false;
        }

        unchecked
        {
            // One-zeros padding: append 0x80, then zeros to fill the block.
            _buffer[_bufferLength++] = 0x80;

            while (_bufferLength < MsgBlockBytes)
            {
                _buffer[_bufferLength++] = 0;
            }

            Compress(_buffer);

            // Finalization: H[l] = cv_l[l] ^ cv_r[l]
            int fullWords = _hashSizeBytes / sizeof(UInt32);
            int outOff = 0;
            for (int l = 0; l < fullWords; l++)
            {
                BinaryPrimitives.WriteUInt32LittleEndian(destination.Slice(outOff, sizeof(UInt32)), _cvL[l] ^ _cvR[l]);
                outOff += sizeof(UInt32);
            }

            bytesWritten = _hashSizeBytes;
            return true;
        }
    }

    /// <inheritdoc/>
    protected override void Dispose(bool disposing)
    {
        if (disposing)
        {
            Array.Clear(_cvL, 0, _cvL.Length);
            Array.Clear(_cvR, 0, _cvR.Length);
            Array.Clear(_submsgEL, 0, _submsgEL.Length);
            Array.Clear(_submsgER, 0, _submsgER.Length);
            Array.Clear(_submsgOL, 0, _submsgOL.Length);
            Array.Clear(_submsgOR, 0, _submsgOR.Length);
            ClearBuffer(_buffer);
            _disposed = true;
        }

        base.Dispose(disposing);
    }

    /// <summary>
    /// Processes a single 128-byte message block through the LSH-256 compression function.
    /// </summary>
    [MethodImpl(MethodImplOptionsEx.OptimizedLoop)]
    private void Compress(ReadOnlySpan<byte> block)
    {
        unchecked
        {
            // The six state arrays are readonly and allocated at NumWords in the constructor,
            // and every index below is either a constant 0..7 or bounded by NumWords. Taking
            // the references once here and indexing with Unsafe.Add lets the whole compression
            // function run without per-element bounds checks, which the JIT cannot eliminate
            // on its own because a field load hides the length from it.
            Debug.Assert(_cvL.Length == NumWords && _cvR.Length == NumWords, "chaining variable must be NumWords long");
            Debug.Assert(_submsgEL.Length == NumWords && _submsgER.Length == NumWords, "even sub-messages must be NumWords long");
            Debug.Assert(_submsgOL.Length == NumWords && _submsgOR.Length == NumWords, "odd sub-messages must be NumWords long");

            ref uint cvL = ref MemoryMarshalEx.GetArrayDataReference(_cvL);
            ref uint cvR = ref MemoryMarshalEx.GetArrayDataReference(_cvR);
            ref uint el = ref MemoryMarshalEx.GetArrayDataReference(_submsgEL);
            ref uint er = ref MemoryMarshalEx.GetArrayDataReference(_submsgER);
            ref uint ol = ref MemoryMarshalEx.GetArrayDataReference(_submsgOL);
            ref uint or2 = ref MemoryMarshalEx.GetArrayDataReference(_submsgOR);

            // Load 32-word message block into sub-message arrays.
            for (int i = 0; i < NumWords; i++)
            {
                int off = i << 2;
                Unsafe.Add(ref el, i) = BinaryPrimitives.ReadUInt32LittleEndian(block.Slice(off, sizeof(UInt32)));
                Unsafe.Add(ref er, i) = BinaryPrimitives.ReadUInt32LittleEndian(block.Slice(off + 32, sizeof(UInt32)));
                Unsafe.Add(ref ol, i) = BinaryPrimitives.ReadUInt32LittleEndian(block.Slice(off + 64, sizeof(UInt32)));
                Unsafe.Add(ref or2, i) = BinaryPrimitives.ReadUInt32LittleEndian(block.Slice(off + 96, sizeof(UInt32)));
            }

            // Step 0 (even): MsgAdd, Mix, WordPerm
            MsgAddEven(ref cvL, ref cvR, ref el, ref er);
            Mix(ref cvL, ref cvR, AlphaEven, BetaEven, 0);
            WordPerm(ref cvL, ref cvR);

            // Step 1 (odd): MsgAdd, Mix, WordPerm
            MsgAddOdd(ref cvL, ref cvR, ref ol, ref or2);
            Mix(ref cvL, ref cvR, AlphaOdd, BetaOdd, 1);
            WordPerm(ref cvL, ref cvR);

            // Steps 2..25
            for (int i = 1; i <= 12; i++)
            {
                MsgExpEven(ref el, ref er, ref ol, ref or2);
                MsgAddEven(ref cvL, ref cvR, ref el, ref er);
                Mix(ref cvL, ref cvR, AlphaEven, BetaEven, i * 2);
                WordPerm(ref cvL, ref cvR);

                MsgExpOdd(ref el, ref er, ref ol, ref or2);
                MsgAddOdd(ref cvL, ref cvR, ref ol, ref or2);
                Mix(ref cvL, ref cvR, AlphaOdd, BetaOdd, i * 2 + 1);
                WordPerm(ref cvL, ref cvR);
            }

            // Final half-step: MsgExp + MsgAdd only (no Mix, no WordPerm)
            MsgExpEven(ref el, ref er, ref ol, ref or2);
            MsgAddEven(ref cvL, ref cvR, ref el, ref er);
        }
    }

    /// <summary>
    /// Adds the even sub-messages to the chaining variable.
    /// </summary>
    [MethodImpl(MethodImplOptionsEx.HotPath)]
    private static void MsgAddEven(ref uint cvL, ref uint cvR, ref uint el, ref uint er)
    {
        for (int i = 0; i < NumWords; i++)
        {
            Unsafe.Add(ref cvL, i) ^= Unsafe.Add(ref el, i);
            Unsafe.Add(ref cvR, i) ^= Unsafe.Add(ref er, i);
        }
    }

    /// <summary>
    /// Adds the odd sub-messages to the chaining variable.
    /// </summary>
    [MethodImpl(MethodImplOptionsEx.HotPath)]
    private static void MsgAddOdd(ref uint cvL, ref uint cvR, ref uint ol, ref uint or2)
    {
        for (int i = 0; i < NumWords; i++)
        {
            Unsafe.Add(ref cvL, i) ^= Unsafe.Add(ref ol, i);
            Unsafe.Add(ref cvR, i) ^= Unsafe.Add(ref or2, i);
        }
    }

    /// <summary>
    /// Applies the mixing function to the chaining variable using the specified rotation
    /// amounts and step constant index.
    /// </summary>
    /// <param name="cvL">Reference to the first word of the left chaining variable.</param>
    /// <param name="cvR">Reference to the first word of the right chaining variable.</param>
    /// <param name="alpha">The first rotation amount.</param>
    /// <param name="beta">The second rotation amount.</param>
    /// <param name="step">The step index for selecting the step constant (0–25).</param>
    [MethodImpl(MethodImplOptionsEx.HotPath)]
    private static void Mix(ref uint cvL, ref uint cvR, int alpha, int beta, int step)
    {
        unchecked
        {
            int scBase = step * NumWords;
            Debug.Assert((uint)(scBase + NumWords) <= (uint)StepConstants.Length, "step constant index out of range");
            Debug.Assert(Gamma.Length == NumWords, "gamma table must be NumWords long");

            ref uint sc = ref Unsafe.Add(ref MemoryMarshalEx.GetArrayDataReference(StepConstants), scBase);
            ref int gamma = ref MemoryMarshalEx.GetArrayDataReference(Gamma);

            for (int i = 0; i < NumWords; i++)
            {
                ref uint l = ref Unsafe.Add(ref cvL, i);
                ref uint r = ref Unsafe.Add(ref cvR, i);

                l += r;
                l = BitOperations.RotateLeft(l, alpha);
                l ^= Unsafe.Add(ref sc, i);
                r += l;
                r = BitOperations.RotateLeft(r, beta);
                l += r;
                r = BitOperations.RotateLeft(r, Unsafe.Add(ref gamma, i));
            }
        }
    }

    /// <summary>
    /// Expands the even sub-messages using the τ permutation and the current odd sub-messages.
    /// </summary>
    [MethodImpl(MethodImplOptionsEx.HotPath)]
    private static void MsgExpEven(ref uint el, ref uint er, ref uint ol, ref uint or2)
    {
        unchecked
        {
            uint temp = Unsafe.Add(ref el, 0);
            Unsafe.Add(ref el, 0) = Unsafe.Add(ref ol, 0) + Unsafe.Add(ref el, 3);
            Unsafe.Add(ref el, 3) = Unsafe.Add(ref ol, 3) + Unsafe.Add(ref el, 1);
            Unsafe.Add(ref el, 1) = Unsafe.Add(ref ol, 1) + Unsafe.Add(ref el, 2);
            Unsafe.Add(ref el, 2) = Unsafe.Add(ref ol, 2) + temp;

            temp = Unsafe.Add(ref el, 4);
            Unsafe.Add(ref el, 4) = Unsafe.Add(ref ol, 4) + Unsafe.Add(ref el, 7);
            Unsafe.Add(ref el, 7) = Unsafe.Add(ref ol, 7) + Unsafe.Add(ref el, 6);
            Unsafe.Add(ref el, 6) = Unsafe.Add(ref ol, 6) + Unsafe.Add(ref el, 5);
            Unsafe.Add(ref el, 5) = Unsafe.Add(ref ol, 5) + temp;

            temp = Unsafe.Add(ref er, 0);
            Unsafe.Add(ref er, 0) = Unsafe.Add(ref or2, 0) + Unsafe.Add(ref er, 3);
            Unsafe.Add(ref er, 3) = Unsafe.Add(ref or2, 3) + Unsafe.Add(ref er, 1);
            Unsafe.Add(ref er, 1) = Unsafe.Add(ref or2, 1) + Unsafe.Add(ref er, 2);
            Unsafe.Add(ref er, 2) = Unsafe.Add(ref or2, 2) + temp;

            temp = Unsafe.Add(ref er, 4);
            Unsafe.Add(ref er, 4) = Unsafe.Add(ref or2, 4) + Unsafe.Add(ref er, 7);
            Unsafe.Add(ref er, 7) = Unsafe.Add(ref or2, 7) + Unsafe.Add(ref er, 6);
            Unsafe.Add(ref er, 6) = Unsafe.Add(ref or2, 6) + Unsafe.Add(ref er, 5);
            Unsafe.Add(ref er, 5) = Unsafe.Add(ref or2, 5) + temp;
        }
    }

    /// <summary>
    /// Expands the odd sub-messages using the τ permutation and the current even sub-messages.
    /// </summary>
    [MethodImpl(MethodImplOptionsEx.HotPath)]
    private static void MsgExpOdd(ref uint el, ref uint er, ref uint ol, ref uint or2)
    {
        unchecked
        {
            uint temp = Unsafe.Add(ref ol, 0);
            Unsafe.Add(ref ol, 0) = Unsafe.Add(ref el, 0) + Unsafe.Add(ref ol, 3);
            Unsafe.Add(ref ol, 3) = Unsafe.Add(ref el, 3) + Unsafe.Add(ref ol, 1);
            Unsafe.Add(ref ol, 1) = Unsafe.Add(ref el, 1) + Unsafe.Add(ref ol, 2);
            Unsafe.Add(ref ol, 2) = Unsafe.Add(ref el, 2) + temp;

            temp = Unsafe.Add(ref ol, 4);
            Unsafe.Add(ref ol, 4) = Unsafe.Add(ref el, 4) + Unsafe.Add(ref ol, 7);
            Unsafe.Add(ref ol, 7) = Unsafe.Add(ref el, 7) + Unsafe.Add(ref ol, 6);
            Unsafe.Add(ref ol, 6) = Unsafe.Add(ref el, 6) + Unsafe.Add(ref ol, 5);
            Unsafe.Add(ref ol, 5) = Unsafe.Add(ref el, 5) + temp;

            temp = Unsafe.Add(ref or2, 0);
            Unsafe.Add(ref or2, 0) = Unsafe.Add(ref er, 0) + Unsafe.Add(ref or2, 3);
            Unsafe.Add(ref or2, 3) = Unsafe.Add(ref er, 3) + Unsafe.Add(ref or2, 1);
            Unsafe.Add(ref or2, 1) = Unsafe.Add(ref er, 1) + Unsafe.Add(ref or2, 2);
            Unsafe.Add(ref or2, 2) = Unsafe.Add(ref er, 2) + temp;

            temp = Unsafe.Add(ref or2, 4);
            Unsafe.Add(ref or2, 4) = Unsafe.Add(ref er, 4) + Unsafe.Add(ref or2, 7);
            Unsafe.Add(ref or2, 7) = Unsafe.Add(ref er, 7) + Unsafe.Add(ref or2, 6);
            Unsafe.Add(ref or2, 6) = Unsafe.Add(ref er, 6) + Unsafe.Add(ref or2, 5);
            Unsafe.Add(ref or2, 5) = Unsafe.Add(ref er, 5) + temp;
        }
    }

    /// <summary>
    /// Applies the word permutation σ to the 16-word chaining variable.
    /// </summary>
    /// <remarks>
    /// The permutation σ = {6,4,5,7,12,15,14,13,2,0,1,3,8,11,10,9} is decomposed into
    /// two cycles and applied using temporary variables to avoid intermediate arrays.
    /// </remarks>
    [MethodImpl(MethodImplOptionsEx.HotPath)]
    private static void WordPerm(ref uint cvL, ref uint cvR)
    {
        // Cycle (3, 7, 13, 11): length 4
        uint temp = Unsafe.Add(ref cvL, 3);
        Unsafe.Add(ref cvL, 3) = Unsafe.Add(ref cvL, 7);
        Unsafe.Add(ref cvL, 7) = Unsafe.Add(ref cvR, 5);
        Unsafe.Add(ref cvR, 5) = Unsafe.Add(ref cvR, 3);
        Unsafe.Add(ref cvR, 3) = temp;

        // Cycle (0, 6, 14, 10, 1, 4, 12, 8, 2, 5, 15, 9): length 12
        temp = Unsafe.Add(ref cvL, 0);
        Unsafe.Add(ref cvL, 0) = Unsafe.Add(ref cvL, 6);
        Unsafe.Add(ref cvL, 6) = Unsafe.Add(ref cvR, 6);
        Unsafe.Add(ref cvR, 6) = Unsafe.Add(ref cvR, 2);
        Unsafe.Add(ref cvR, 2) = Unsafe.Add(ref cvL, 1);
        Unsafe.Add(ref cvL, 1) = Unsafe.Add(ref cvL, 4);
        Unsafe.Add(ref cvL, 4) = Unsafe.Add(ref cvR, 4);
        Unsafe.Add(ref cvR, 4) = Unsafe.Add(ref cvR, 0);
        Unsafe.Add(ref cvR, 0) = Unsafe.Add(ref cvL, 2);
        Unsafe.Add(ref cvL, 2) = Unsafe.Add(ref cvL, 5);
        Unsafe.Add(ref cvL, 5) = Unsafe.Add(ref cvR, 7);
        Unsafe.Add(ref cvR, 7) = Unsafe.Add(ref cvR, 1);
        Unsafe.Add(ref cvR, 1) = temp;
    }
}
