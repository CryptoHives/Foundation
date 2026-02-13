// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Security.Cryptography.Hash;

using System;
using System.Buffers.Binary;
using System.Numerics;
using System.Runtime.CompilerServices;

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
    private static readonly uint[] StepConstants;

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

    static Lsh256()
    {
        unchecked
        {
            StepConstants = new uint[NumSteps * NumWords];

            // SC[0]: initial step constant
            ReadOnlySpan<uint> sc0 =
            [
                0x917caf90, 0x6c1b10a2, 0x6f352943, 0xcf778243,
                0x2ceb7472, 0x29e96ff2, 0x8a9ba428, 0x2eeb2642
            ];

            for (int l = 0; l < NumWords; l++)
            {
                StepConstants[l] = sc0[l];
            }

            // SC[j][l] = SC[j-1][l] + rotL(SC[j-1][l], 8)
            for (int j = 1; j < NumSteps; j++)
            {
                int cur = j * NumWords;
                int prev = (j - 1) * NumWords;
                for (int l = 0; l < NumWords; l++)
                {
                    uint p = StepConstants[prev + l];
                    StepConstants[cur + l] = p + BitOperations.RotateLeft(p, 8);
                }
            }
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

    /// <inheritdoc/>
    public override void Initialize()
    {
        Array.Copy(_iv, 0, _cvL, 0, NumWords);
        Array.Copy(_iv, NumWords, _cvR, 0, NumWords);
        _bufferLength = 0;
    }

    /// <inheritdoc/>
    protected override void HashCore(ReadOnlySpan<byte> source)
    {
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
    protected override bool TryHashFinal(Span<byte> destination, out int bytesWritten)
    {
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
            int fullWords = _hashSizeBytes / 4;
            int outOff = 0;
            for (int l = 0; l < fullWords; l++)
            {
                BinaryPrimitives.WriteUInt32LittleEndian(destination.Slice(outOff, 4), _cvL[l] ^ _cvR[l]);
                outOff += 4;
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
            uint[] el = _submsgEL, er = _submsgER;
            uint[] ol = _submsgOL, or2 = _submsgOR;

            // Load 32-word message block into sub-message arrays.
            for (int i = 0; i < NumWords; i++)
            {
                int off = i << 2;
                el[i] = BinaryPrimitives.ReadUInt32LittleEndian(block.Slice(off, 4));
                er[i] = BinaryPrimitives.ReadUInt32LittleEndian(block.Slice(off + 32, 4));
                ol[i] = BinaryPrimitives.ReadUInt32LittleEndian(block.Slice(off + 64, 4));
                or2[i] = BinaryPrimitives.ReadUInt32LittleEndian(block.Slice(off + 96, 4));
            }

            // Step 0 (even): MsgAdd, Mix, WordPerm
            MsgAddEven();
            Mix(AlphaEven, BetaEven, 0);
            WordPerm();

            // Step 1 (odd): MsgAdd, Mix, WordPerm
            MsgAddOdd();
            Mix(AlphaOdd, BetaOdd, 1);
            WordPerm();

            // Steps 2..25
            for (int i = 1; i <= 12; i++)
            {
                MsgExpEven();
                MsgAddEven();
                Mix(AlphaEven, BetaEven, i * 2);
                WordPerm();

                MsgExpOdd();
                MsgAddOdd();
                Mix(AlphaOdd, BetaOdd, i * 2 + 1);
                WordPerm();
            }

            // Final half-step: MsgExp + MsgAdd only (no Mix, no WordPerm)
            MsgExpEven();
            MsgAddEven();
        }
    }

    /// <summary>
    /// Adds the even sub-messages to the chaining variable.
    /// </summary>
    [MethodImpl(MethodImplOptionsEx.HotPath)]
    private void MsgAddEven()
    {
        uint[] cvL = _cvL, cvR = _cvR;
        uint[] el = _submsgEL, er = _submsgER;
        for (int i = 0; i < NumWords; i++)
        {
            cvL[i] ^= el[i];
            cvR[i] ^= er[i];
        }
    }

    /// <summary>
    /// Adds the odd sub-messages to the chaining variable.
    /// </summary>
    [MethodImpl(MethodImplOptionsEx.HotPath)]
    private void MsgAddOdd()
    {
        uint[] cvL = _cvL, cvR = _cvR;
        uint[] ol = _submsgOL, or2 = _submsgOR;
        for (int i = 0; i < NumWords; i++)
        {
            cvL[i] ^= ol[i];
            cvR[i] ^= or2[i];
        }
    }

    /// <summary>
    /// Applies the mixing function to the chaining variable using the specified rotation
    /// amounts and step constant index.
    /// </summary>
    /// <param name="alpha">The first rotation amount.</param>
    /// <param name="beta">The second rotation amount.</param>
    /// <param name="step">The step index for selecting the step constant (0–25).</param>
    [MethodImpl(MethodImplOptionsEx.HotPath)]
    private void Mix(int alpha, int beta, int step)
    {
        unchecked
        {
            uint[] cvL = _cvL, cvR = _cvR;
            int scBase = step * NumWords;

            for (int i = 0; i < NumWords; i++)
            {
                cvL[i] += cvR[i];
                cvL[i] = BitOperations.RotateLeft(cvL[i], alpha);
                cvL[i] ^= StepConstants[scBase + i];
                cvR[i] += cvL[i];
                cvR[i] = BitOperations.RotateLeft(cvR[i], beta);
                cvL[i] += cvR[i];
                cvR[i] = BitOperations.RotateLeft(cvR[i], Gamma[i]);
            }
        }
    }

    /// <summary>
    /// Expands the even sub-messages using the τ permutation and the current odd sub-messages.
    /// </summary>
    [MethodImpl(MethodImplOptionsEx.HotPath)]
    private void MsgExpEven()
    {
        unchecked
        {
            uint[] el = _submsgEL, ol = _submsgOL;
            uint[] er = _submsgER, or2 = _submsgOR;

            uint temp = el[0];
            el[0] = ol[0] + el[3];
            el[3] = ol[3] + el[1];
            el[1] = ol[1] + el[2];
            el[2] = ol[2] + temp;

            temp = el[4];
            el[4] = ol[4] + el[7];
            el[7] = ol[7] + el[6];
            el[6] = ol[6] + el[5];
            el[5] = ol[5] + temp;

            temp = er[0];
            er[0] = or2[0] + er[3];
            er[3] = or2[3] + er[1];
            er[1] = or2[1] + er[2];
            er[2] = or2[2] + temp;

            temp = er[4];
            er[4] = or2[4] + er[7];
            er[7] = or2[7] + er[6];
            er[6] = or2[6] + er[5];
            er[5] = or2[5] + temp;
        }
    }

    /// <summary>
    /// Expands the odd sub-messages using the τ permutation and the current even sub-messages.
    /// </summary>
    [MethodImpl(MethodImplOptionsEx.HotPath)]
    private void MsgExpOdd()
    {
        unchecked
        {
            uint[] el = _submsgEL, ol = _submsgOL;
            uint[] er = _submsgER, or2 = _submsgOR;

            uint temp = ol[0];
            ol[0] = el[0] + ol[3];
            ol[3] = el[3] + ol[1];
            ol[1] = el[1] + ol[2];
            ol[2] = el[2] + temp;

            temp = ol[4];
            ol[4] = el[4] + ol[7];
            ol[7] = el[7] + ol[6];
            ol[6] = el[6] + ol[5];
            ol[5] = el[5] + temp;

            temp = or2[0];
            or2[0] = er[0] + or2[3];
            or2[3] = er[3] + or2[1];
            or2[1] = er[1] + or2[2];
            or2[2] = er[2] + temp;

            temp = or2[4];
            or2[4] = er[4] + or2[7];
            or2[7] = er[7] + or2[6];
            or2[6] = er[6] + or2[5];
            or2[5] = er[5] + temp;
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
    private void WordPerm()
    {
        uint[] cvL = _cvL, cvR = _cvR;

        // Cycle (3, 7, 13, 11): length 4
        uint temp = cvL[3];
        cvL[3] = cvL[7];
        cvL[7] = cvR[5];
        cvR[5] = cvR[3];
        cvR[3] = temp;

        // Cycle (0, 6, 14, 10, 1, 4, 12, 8, 2, 5, 15, 9): length 12
        temp = cvL[0];
        cvL[0] = cvL[6];
        cvL[6] = cvR[6];
        cvR[6] = cvR[2];
        cvR[2] = cvL[1];
        cvL[1] = cvL[4];
        cvL[4] = cvR[4];
        cvR[4] = cvR[0];
        cvR[0] = cvL[2];
        cvL[2] = cvL[5];
        cvL[5] = cvR[7];
        cvR[7] = cvR[1];
        cvR[1] = temp;
    }
}
