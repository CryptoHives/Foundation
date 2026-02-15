// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Security.Cryptography.Hash;

using System;
using System.Buffers.Binary;
using System.Numerics;
using System.Runtime.CompilerServices;

/// <summary>
/// Computes the LSH-512 hash for the input data.
/// </summary>
/// <remarks>
/// <para>
/// This is a fully managed implementation of LSH-512 that does not rely on
/// OS or hardware cryptographic APIs, ensuring deterministic behavior across
/// all platforms and runtimes.
/// </para>
/// <para>
/// LSH is the Korean national cryptographic hash standard defined in KS X 3262.
/// The LSH-512 family uses 64-bit words and supports output sizes of 224, 256,
/// 384, or 512 bits.
/// </para>
/// <para>
/// The algorithm uses a wide-pipe Merkle-Damgård construction with 28 steps,
/// each consisting of message addition, a mixing function with rotation-based
/// diffusion, and a word permutation.
/// </para>
/// <para>
/// Implementation follows the specification published by KISA (Korea Internet
/// &amp; Security Agency) and the official reference implementation.
/// </para>
/// </remarks>
public sealed class Lsh512 : HashAlgorithm
{
    /// <summary>
    /// Number of 64-bit words in each half of the chaining variable.
    /// </summary>
    private const int NumWords = 8;

    /// <summary>
    /// Total number of mixing steps in the compression function.
    /// </summary>
    private const int NumSteps = 28;

    /// <summary>
    /// Message block size in bytes (32 words × 8 bytes).
    /// </summary>
    private const int MsgBlockBytes = 256;

    private const int AlphaEven = 23;
    private const int BetaEven = 59;
    private const int AlphaOdd = 7;
    private const int BetaOdd = 3;

    /// <summary>
    /// Per-element rotation amounts for the gamma rotation in the mix function.
    /// </summary>
    private static readonly int[] Gamma = [0, 16, 32, 48, 8, 24, 40, 56];

    /// <summary>
    /// Precomputed step constants for all 28 steps (28 × 8 values).
    /// </summary>
    private static readonly ulong[] StepConstants = InitializeStepConstants();

    /// <summary>
    /// Initial values for LSH-512-224.
    /// </summary>
    private static readonly ulong[] Iv224 =
    [
        0x0C401E9FE8813A55, 0x4A5F446268FD3D35, 0xFF13E452334F612A, 0xF8227661037E354A,
        0xA5F223723C9CA29D, 0x95D965A11AED3979, 0x01E23835B9AB02CC, 0x52D49CBAD5B30616,
        0x9E5C2027773F4ED3, 0x66A5C8801925B701, 0x22BBC85B4C6779D9, 0xC13171A42C559C23,
        0x31E2B67D25BE3813, 0xD522C4DEED8E4D83, 0xA79F5509B43FBAFE, 0xE00D2CD88B4B6C6A
    ];

    /// <summary>
    /// Initial values for LSH-512-256.
    /// </summary>
    private static readonly ulong[] Iv256 =
    [
        0x6DC57C33DF989423, 0xD8EA7F6E8342C199, 0x76DF8356F8603AC4, 0x40F1B44DE838223A,
        0x39FFE7CFC31484CD, 0x39C4326CC5281548, 0x8A2FF85A346045D8, 0xFF202AA46DBDD61E,
        0xCF785B3CD5FCDB8B, 0x1F0323B64A8150BF, 0xFF75D972F29EA355, 0x2E567F30BF1CA9E1,
        0xB596875BF8FF6DBA, 0xFCCA39B089EF4615, 0xECFF4017D020B4B6, 0x7E77384C772ED802
    ];

    /// <summary>
    /// Initial values for LSH-512-384.
    /// </summary>
    private static readonly ulong[] Iv384 =
    [
        0x53156A66292808F6, 0xB2C4F362B204C2BC, 0xB84B7213BFA05C4E, 0x976CEB7C1B299F73,
        0xDF0CC63C0570AE97, 0xDA4441BAA486CE3F, 0x6559F5D9B5F2ACC2, 0x22DACF19B4B52A16,
        0xBBCDACEFDE80953A, 0xC9891A2879725B3E, 0x7C9FE6330237E440, 0xA30BA550553F7431,
        0xBB08043FB34E3E30, 0xA0DEC48D54618EAD, 0x150317267464BC57, 0x32D1501FDE63DC93
    ];

    /// <summary>
    /// Initial values for LSH-512-512.
    /// </summary>
    private static readonly ulong[] Iv512 =
    [
        0xADD50F3C7F07094E, 0xE3F3CEE8F9418A4F, 0xB527ECDE5B3D0AE9, 0x2EF6DEC68076F501,
        0x8CB994CAE5ACA216, 0xFBB9EAE4BBA48CC7, 0x650A526174725FEA, 0x1F9A61A73F8D8085,
        0xB6607378173B539B, 0x1BC99853B0C0B9ED, 0xDF727FC19B182D47, 0xDBEF360CF893A457,
        0x4981F5E570147E80, 0xD00C4490CA7D3E30, 0x5D73940C0E4AE1EC, 0x894085E2EDB2D819
    ];

    private static ulong[] InitializeStepConstants()
    {
        unchecked
        {
            var stepConstants = new ulong[NumSteps * NumWords];

            // SC[0]: initial step constant
            ReadOnlySpan<ulong> sc0 =
            [
                0x97884283C938982A, 0xBA1FCA93533E2355, 0xC519A2E87AEB1C03, 0x9A0FC95462AF17B1,
                0xFC3DDA8AB019A82B, 0x02825D079A895407, 0x79F2D0A7EE06A6F7, 0xD76D15EED9FDF5FE
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
                    ulong p = stepConstants[prev + l];
                    stepConstants[cur + l] = p + BitOperations.RotateLeft(p, 8);
                }
            }

            return stepConstants;
        }
    }

    private readonly int _hashSizeBytes;
    private readonly ulong[] _iv;
    private readonly ulong[] _cvL;
    private readonly ulong[] _cvR;
    private readonly ulong[] _submsgEL;
    private readonly ulong[] _submsgER;
    private readonly ulong[] _submsgOL;
    private readonly ulong[] _submsgOR;
    private readonly byte[] _buffer;
    private int _bufferLength;

    /// <summary>
    /// Initializes a new instance of the <see cref="Lsh512"/> class with 512-bit output.
    /// </summary>
    public Lsh512() : this(64)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Lsh512"/> class.
    /// </summary>
    /// <param name="hashSizeBytes">The desired output size in bytes (28, 32, 48, or 64).</param>
    /// <exception cref="ArgumentException">
    /// Thrown when <paramref name="hashSizeBytes"/> is not 28, 32, 48, or 64.
    /// </exception>
    public Lsh512(int hashSizeBytes)
    {
        if (hashSizeBytes != 28 && hashSizeBytes != 32 && hashSizeBytes != 48 && hashSizeBytes != 64)
        {
            throw new ArgumentException(
                "Hash size must be 28 (224-bit), 32 (256-bit), 48 (384-bit), or 64 (512-bit) bytes.",
                nameof(hashSizeBytes));
        }

        _hashSizeBytes = hashSizeBytes;
        HashSizeValue = hashSizeBytes * 8;

        _iv = hashSizeBytes switch {
            28 => Iv224,
            32 => Iv256,
            48 => Iv384,
            _ => Iv512
        };

        _cvL = new ulong[NumWords];
        _cvR = new ulong[NumWords];
        _submsgEL = new ulong[NumWords];
        _submsgER = new ulong[NumWords];
        _submsgOL = new ulong[NumWords];
        _submsgOR = new ulong[NumWords];
        _buffer = new byte[MsgBlockBytes];
        Initialize();
    }

    /// <inheritdoc/>
    public override string AlgorithmName => $"LSH-512-{_hashSizeBytes * 8}";

    /// <inheritdoc/>
    public override int BlockSize => MsgBlockBytes;

    /// <summary>
    /// Creates a new instance with default 512-bit output.
    /// </summary>
    /// <returns>A new <see cref="Lsh512"/> instance.</returns>
    public static new Lsh512 Create() => new();

    /// <summary>
    /// Creates a new instance with specified output size.
    /// </summary>
    /// <param name="hashSizeBytes">The hash size in bytes (28, 32, 48, or 64).</param>
    /// <returns>A new <see cref="Lsh512"/> instance.</returns>
    public static Lsh512 Create(int hashSizeBytes) => new(hashSizeBytes);

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
            int fullWords = _hashSizeBytes / sizeof(UInt64);
            int outOff = 0;
            for (int l = 0; l < fullWords; l++)
            {
                BinaryPrimitives.WriteUInt64LittleEndian(destination.Slice(outOff, sizeof(UInt64)), _cvL[l] ^ _cvR[l]);
                outOff += sizeof(UInt64);
            }

            // Handle partial word (LSH-512-224: 28 bytes = 3 full words + 4 bytes)
            int extraBytes = _hashSizeBytes - outOff;
            if (extraBytes > 0)
            {
                Span<byte> temp = stackalloc byte[sizeof(UInt64)];
                BinaryPrimitives.WriteUInt64LittleEndian(temp, _cvL[fullWords] ^ _cvR[fullWords]);
                temp.Slice(0, extraBytes).CopyTo(destination.Slice(outOff));
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
    /// Processes a single 256-byte message block through the LSH-512 compression function.
    /// </summary>
    [MethodImpl(MethodImplOptionsEx.OptimizedLoop)]
    private void Compress(ReadOnlySpan<byte> block)
    {
        unchecked
        {
            ulong[] el = _submsgEL, er = _submsgER;
            ulong[] ol = _submsgOL, or2 = _submsgOR;

            // Load 32-word message block into sub-message arrays.
            for (int i = 0; i < NumWords; i++)
            {
                int off = i << 3;
                el[i] = BinaryPrimitives.ReadUInt64LittleEndian(block.Slice(off, sizeof(UInt64)));
                er[i] = BinaryPrimitives.ReadUInt64LittleEndian(block.Slice(off + 64, sizeof(UInt64)));
                ol[i] = BinaryPrimitives.ReadUInt64LittleEndian(block.Slice(off + 128, sizeof(UInt64)));
                or2[i] = BinaryPrimitives.ReadUInt64LittleEndian(block.Slice(off + 192, sizeof(UInt64)));
            }

            // Step 0 (even): MsgAdd, Mix, WordPerm
            MsgAddEven();
            Mix(AlphaEven, BetaEven, 0);
            WordPerm();

            // Step 1 (odd): MsgAdd, Mix, WordPerm
            MsgAddOdd();
            Mix(AlphaOdd, BetaOdd, 1);
            WordPerm();

            // Steps 2..27
            for (int i = 1; i <= 13; i++)
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
        ulong[] cvL = _cvL, cvR = _cvR;
        ulong[] el = _submsgEL, er = _submsgER;
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
        ulong[] cvL = _cvL, cvR = _cvR;
        ulong[] ol = _submsgOL, or2 = _submsgOR;
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
    /// <param name="step">The step index for selecting the step constant (0–27).</param>
    [MethodImpl(MethodImplOptionsEx.HotPath)]
    private void Mix(int alpha, int beta, int step)
    {
        unchecked
        {
            ulong[] cvL = _cvL, cvR = _cvR;
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
            ulong[] el = _submsgEL, ol = _submsgOL;
            ulong[] er = _submsgER, or2 = _submsgOR;

            // First 4-word group: cycle 0→3→1→2→0
            ulong temp = el[0];
            el[0] = ol[0] + el[3];
            el[3] = ol[3] + el[1];
            el[1] = ol[1] + el[2];
            el[2] = ol[2] + temp;

            // Second 4-word group: cycle 4→7→6→5→4
            temp = el[4];
            el[4] = ol[4] + el[7];
            el[7] = ol[7] + el[6];
            el[6] = ol[6] + el[5];
            el[5] = ol[5] + temp;

            // Same pattern for right arrays
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
            ulong[] el = _submsgEL, ol = _submsgOL;
            ulong[] er = _submsgER, or2 = _submsgOR;

            // First 4-word group: cycle 0→3→1→2→0
            ulong temp = ol[0];
            ol[0] = el[0] + ol[3];
            ol[3] = el[3] + ol[1];
            ol[1] = el[1] + ol[2];
            ol[2] = el[2] + temp;

            // Second 4-word group: cycle 4→7→6→5→4
            temp = ol[4];
            ol[4] = el[4] + ol[7];
            ol[7] = el[7] + ol[6];
            ol[6] = el[6] + ol[5];
            ol[5] = el[5] + temp;

            // Same pattern for right arrays
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
        ulong[] cvL = _cvL, cvR = _cvR;

        // Cycle (3, 7, 13, 11): length 4
        ulong temp = cvL[3];
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
