// SPDX-FileCopyrightText: 2025 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

#pragma warning disable CA1815 // Override equals and operator equals on value types

namespace CryptoHives.Foundation.Security.Cryptography.Hash;

using System;
using System.Buffers.Binary;
using System.Diagnostics;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
#if NET8_0_OR_GREATER
using System.Runtime.Intrinsics;
using System.Runtime.Intrinsics.X86;
#endif

/// <summary>
/// Provides the core Keccak-f[1600] permutation and sponge construction primitives.
/// The state is also stored inline to avoid additional allocations.
/// </summary>
/// <remarks>
/// <para>
/// This class implements the Keccak permutation used by SHA-3, SHAKE, cSHAKE, KMAC,
/// and related algorithms. It is designed as a shared primitive to reduce code
/// duplication across Keccak-based implementations.
/// </para>
/// <para>
/// The Keccak state is a 5×5×64 = 1600-bit array organized as 25 64-bit lanes.
/// </para>
/// <para>
/// On platforms with AVX2 support (.NET 8+), an optimized SIMD implementation is used.
/// However, currently the all SIMD versions are slower than the scalar version on AMD 8945
/// which is used for benchmarking, so SIMD is disabled by default in release packages.
/// </para>
/// </remarks>
internal unsafe struct KeccakCoreState
{
    /// <summary>
    /// The state size in 64-bit words (25 lanes × 64 bits = 1600 bits).
    /// </summary>
    public const int StateSize = 25;

    /// <summary>
    /// The number of rounds in the Keccak-f[1600] permutation.
    /// </summary>
    public const int Rounds = 24;

    /// <summary>
    /// The number of rounds in the Keccak-f[1600] permutation for K12.
    /// </summary>
    public const int Rounds12 = 12;

    /// <summary>
    /// Round constants for the iota step of Keccak-f[1600].
    /// </summary>
    /// <remarks>
    /// These constants are derived from the output of a linear feedback shift register.
    /// </remarks>
    public static readonly ulong[] RoundConstants =
    [
        0x0000000000000001UL, 0x0000000000008082UL, 0x800000000000808aUL, 0x8000000080008000UL,
        0x000000000000808bUL, 0x0000000080000001UL, 0x8000000080008081UL, 0x8000000000008009UL,
        0x000000000000008aUL, 0x0000000000000088UL, 0x0000000080008009UL, 0x000000008000000aUL,
        0x000000008000808bUL, 0x800000000000008bUL, 0x8000000000008089UL, 0x8000000000008003UL,
        0x8000000000008002UL, 0x8000000000000080UL, 0x000000000000800aUL, 0x800000008000000aUL,
        0x8000000080008081UL, 0x8000000000008080UL, 0x0000000080000001UL, 0x8000000080008008UL
    ];

    /// <summary>
    /// Gets the SIMD instruction sets supported by this algorithm on the current platform.
    /// </summary>
    public static SimdSupport SimdSupport
    {
        get
        {
            SimdSupport support = SimdSupport.None;
#if NET8_0_OR_GREATER
            if (Avx2.IsSupported) support |= SimdSupport.Avx2;
            if (Avx512F.IsSupported) support |= SimdSupport.Avx512F;
#endif
            return support;
        }
    }

    /// <summary>
    /// Represents the internal state array used for cryptographic operations.
    /// </summary>
    private fixed ulong _state[StateSize];

    /// <summary>
    /// The SimD instruction sets to use for this instance.
    /// </summary>
    private readonly SimdSupport _simdSupport;

    /// <summary>
    /// The starting round for the permutation (default 0). Use 12 for TurboSHAKE.
    /// </summary>
    private readonly int _startRound;

    /// <summary>
    /// Initializes a new instance of the KeccakCoreStruct structure with the specified SIMD support configuration.
    /// </summary>
    /// <remarks>
    /// The initial state is cleared upon construction. The chosen SIMD support may affect
    /// performance characteristics but does not alter the functional behavior.
    /// </remarks>
    /// <param name="simdSupport">The SIMD support option to choose from. Unsupported bits are masked out.
    /// </param>
    /// <param name="startRound">The starting round for the permutation (default 0). Use 12 for TurboSHAKE.</param>
    public KeccakCoreState(SimdSupport simdSupport = SimdSupport.None, int startRound = 0)
    {
        // mask unsupported bits
        _simdSupport = simdSupport & SimdSupport;
        _startRound = startRound;
        Reset();
    }

    /// <summary>
    /// Resets the internal state to its initial, cleared state.
    /// </summary>
    public void Reset()
    {
        fixed (ulong* statePtr = _state)
        {
            Span<ulong> stateSpan = new(statePtr, StateSize);
            stateSpan.Clear();
        }
    }

    /// <summary>
    /// Performs the Keccak-f[1600] permutation on the given statePtr with explicit SIMD control.
    /// </summary>
    [MethodImpl(MethodImplOptionsEx.OptimizedLoop)]
    public void Permute()
    {
#if NET8_0_OR_GREATER
        if ((_simdSupport & SimdSupport.Avx512F) != 0)
        {
            PermuteAvx512F();
            return;
        }
        if ((_simdSupport & SimdSupport.Avx2) != 0)
        {
            PermuteAvx2();
            return;
        }
#endif
        PermuteScalar();
    }

    #region AVX512F Implementation
#if NET8_0_OR_GREATER
    // All static constants hosted outside method
    private readonly record struct PermuteAvx512FVectors
    {
        public PermuteAvx512FVectors()
        {
            Mask5 = Vector512.Create(ulong.MaxValue, ulong.MaxValue, ulong.MaxValue, ulong.MaxValue, ulong.MaxValue, 0UL, 0UL, 0UL);
            MoveThetaPrev = Vector512.Create(4UL, 0UL, 1UL, 2UL, 3UL, 5UL, 6UL, 7UL);
            MoveThetaNext = Vector512.Create(1UL, 2UL, 3UL, 4UL, 0UL, 5UL, 6UL, 7UL);
            RhoB = Vector512.Create(0UL, 1UL, 62UL, 28UL, 27UL, 0UL, 0UL, 0UL);
            RhoG = Vector512.Create(36UL, 44UL, 6UL, 55UL, 20UL, 0UL, 0UL, 0UL);
            RhoK = Vector512.Create(3UL, 10UL, 43UL, 25UL, 39UL, 0UL, 0UL, 0UL);
            RhoM = Vector512.Create(41UL, 45UL, 15UL, 21UL, 8UL, 0UL, 0UL, 0UL);
            RhoS = Vector512.Create(18UL, 2UL, 61UL, 56UL, 14UL, 0UL, 0UL, 0UL);

            Pi1B = Vector512.Create(0UL, 3UL, 1UL, 4UL, 2UL, 5UL, 6UL, 7UL);
            Pi1G = Vector512.Create(1UL, 4UL, 2UL, 0UL, 3UL, 5UL, 6UL, 7UL);
            Pi1K = Vector512.Create(2UL, 0UL, 3UL, 1UL, 4UL, 5UL, 6UL, 7UL);
            Pi1M = Vector512.Create(3UL, 1UL, 4UL, 2UL, 0UL, 5UL, 6UL, 7UL);
            Pi1S = Vector512.Create(4UL, 2UL, 0UL, 3UL, 1UL, 5UL, 6UL, 7UL);

            Pi2S1 = Vector512.Create(0UL, 1UL, 2UL, 3UL, 4UL, 5UL, 8UL, 10UL);
            Pi2S2 = Vector512.Create(0UL, 1UL, 2UL, 3UL, 4UL, 5UL, 9UL, 11UL);
            Pi2BG = Vector512.Create(0UL, 1UL, 8UL, 9UL, 6UL, 5UL, 6UL, 7UL);
            Pi2KM = Vector512.Create(2UL, 3UL, 10UL, 11UL, 7UL, 5UL, 6UL, 7UL);
            Pi2S3 = Vector512.Create(4UL, 5UL, 12UL, 13UL, 4UL, 5UL, 6UL, 7UL);
            Pi2SL4 = Vector512.Create(0UL, 1UL, 2UL, 3UL, 12UL, 5UL, 6UL, 7UL);
        }

        public readonly Vector512<ulong> Mask5;
        public readonly Vector512<ulong> MoveThetaPrev;
        public readonly Vector512<ulong> MoveThetaNext;
        public readonly Vector512<ulong> RhoB;
        public readonly Vector512<ulong> RhoG;
        public readonly Vector512<ulong> RhoK;
        public readonly Vector512<ulong> RhoM;
        public readonly Vector512<ulong> RhoS;

        public readonly Vector512<ulong> Pi1B;
        public readonly Vector512<ulong> Pi1G;
        public readonly Vector512<ulong> Pi1K;
        public readonly Vector512<ulong> Pi1M;
        public readonly Vector512<ulong> Pi1S;

        public readonly Vector512<ulong> Pi2S1;
        public readonly Vector512<ulong> Pi2S2;
        public readonly Vector512<ulong> Pi2BG;
        public readonly Vector512<ulong> Pi2KM;
        public readonly Vector512<ulong> Pi2S3;
        public readonly Vector512<ulong> Pi2SL4;

    }

    private static readonly PermuteAvx512FVectors Avx512FVectors = new();
    private static readonly Vector512<ulong>[] RoundConstantsAvx512 = CreateRoundConstantsAvx512();

    private static Vector512<ulong>[] CreateRoundConstantsAvx512()
    {
        var constants = new Vector512<ulong>[Rounds];
        for (int i = 0; i < Rounds; i++)
        {
            constants[i] = Vector512.Create(RoundConstants[i], 0UL, 0UL, 0UL, 0UL, 0UL, 0UL, 0UL);
        }
        return constants;
    }

    [SkipLocalsInit]
    [MethodImpl(MethodImplOptionsEx.OptimizedLoop)]
    public void PermuteAvx512F()
    {
        const byte xorThreeOperands = 0x96;
        const byte chiNonlinearity = 0xD2;

        Vector512<ulong> ab, ag, ak, am, @as;
        Vector512<ulong> eb, eg, ek, em, es;
        Vector512<ulong> ca;

        fixed (ulong* statePtr = _state)
        {
            ref Vector512<ulong> rcBase = ref MemoryMarshal.GetArrayDataReference(RoundConstantsAvx512);
            ref readonly PermuteAvx512FVectors vectors = ref Avx512FVectors;
            Vector512<ulong> mask5 = vectors.Mask5;

            // Load state
            ab = Vector512.BitwiseAnd(mask5, Unsafe.As<ulong, Vector512<ulong>>(ref statePtr[0]));
            ag = Vector512.BitwiseAnd(mask5, Unsafe.As<ulong, Vector512<ulong>>(ref statePtr[5]));
            ak = Vector512.BitwiseAnd(mask5, Unsafe.As<ulong, Vector512<ulong>>(ref statePtr[10]));
            am = Vector512.BitwiseAnd(mask5, Unsafe.As<ulong, Vector512<ulong>>(ref statePtr[15]));
            var asLow = Unsafe.As<ulong, Vector256<ulong>>(ref statePtr[20]);
            @as = Vector512.Create(asLow, Vector256.Create(statePtr[24], 0UL, 0UL, 0UL));

            // Initial parity computation (before loop)
            ca = Avx512F.TernaryLogic(
                Avx512F.TernaryLogic(ab, ag, ak, xorThreeOperands),
                am, @as, xorThreeOperands);

            for (int round = _startRound; round < Rounds; round += 2)
            {
                // =================================================================
                // ROUND 1 (A -> E) - Uses pre-computed caeiou
                // =================================================================
                {
                    var rc = Unsafe.Add(ref rcBase, round);
                    {
                        // Theta: Use parity accumulated during Round 1's Pi2
                        Vector512<ulong> cu = Avx512F.PermuteVar8x64(ca, vectors.MoveThetaPrev);
                        Vector512<ulong> cuda = Avx512F.Xor(cu, Avx512F.PermuteVar8x64(Avx512F.RotateLeft(ca, 1), vectors.MoveThetaNext));

                        // Apply Theta
                        ab = Avx512F.Xor(ab, cuda);
                        ag = Avx512F.Xor(ag, cuda);
                        ak = Avx512F.Xor(ak, cuda);
                        am = Avx512F.Xor(am, cuda);
                        @as = Avx512F.Xor(@as, cuda);
                    }

                    // Rho
                    ab = Avx512F.RotateLeftVariable(ab, vectors.RhoB);
                    ag = Avx512F.RotateLeftVariable(ag, vectors.RhoG);
                    ak = Avx512F.RotateLeftVariable(ak, vectors.RhoK);
                    am = Avx512F.RotateLeftVariable(am, vectors.RhoM);
                    @as = Avx512F.RotateLeftVariable(@as, vectors.RhoS);

                    // Pi
                    ab = Avx512F.PermuteVar8x64(ab, vectors.Pi1B);
                    ag = Avx512F.PermuteVar8x64(ag, vectors.Pi1G);
                    ak = Avx512F.PermuteVar8x64(ak, vectors.Pi1K);
                    am = Avx512F.PermuteVar8x64(am, vectors.Pi1M);
                    @as = Avx512F.PermuteVar8x64(@as, vectors.Pi1S);

                    // Chi
                    eb = Avx512F.TernaryLogic(ab, ag, ak, chiNonlinearity);
                    eg = Avx512F.TernaryLogic(ag, ak, am, chiNonlinearity);
                    ek = Avx512F.TernaryLogic(ak, am, @as, chiNonlinearity);
                    em = Avx512F.TernaryLogic(am, @as, ab, chiNonlinearity);
                    es = Avx512F.TernaryLogic(@as, ab, ag, chiNonlinearity);

                    // Iota
                    eb = Avx512F.Xor(eb, rc);

                    // Pi2 reorganization with parity accumulation
                    Vector512<ulong> s0 = Avx512F.UnpackLow(eb, eg);
                    Vector512<ulong> s1 = Avx512F.UnpackLow(ek, em);
                    Vector512<ulong> s2 = Avx512F.UnpackHigh(eb, eg);
                    Vector512<ulong> s3 = Avx512F.UnpackHigh(ek, em);
                    s0 = Avx512F.PermuteVar8x64x2(s0, vectors.Pi2S1, es);
                    s2 = Avx512F.PermuteVar8x64x2(s2, vectors.Pi2S2, es);

                    // Compute reorganized state AND accumulate parity simultaneously
                    eb = Avx512F.PermuteVar8x64x2(s0, vectors.Pi2BG, s1);
                    eg = Avx512F.PermuteVar8x64x2(s2, vectors.Pi2BG, s3);
                    ek = Avx512F.PermuteVar8x64x2(s0, vectors.Pi2KM, s1);
                    em = Avx512F.PermuteVar8x64x2(s2, vectors.Pi2KM, s3);
                    s0 = Avx512F.PermuteVar8x64x2(s0, vectors.Pi2S3, s1);
                    es = Avx512F.PermuteVar8x64x2(s0, vectors.Pi2SL4, es);
                    ca = Avx512F.TernaryLogic(eb, eg, ek, xorThreeOperands);
                    ca = Avx512F.TernaryLogic(ca, em, es, xorThreeOperands);
                }

                // =================================================================
                // ROUND 2 (E -> A) - Uses parity accumulated in Round 1
                // =================================================================
                {
                    var rc = Unsafe.Add(ref rcBase, round + 1);
                    {
                        // Theta: Use parity accumulated during Round 1's Pi2
                        Vector512<ulong> cu = Avx512F.PermuteVar8x64(ca, vectors.MoveThetaPrev);
                        Vector512<ulong> cuda = Avx512F.Xor(cu, Avx512F.PermuteVar8x64(Avx512F.RotateLeft(ca, 1), vectors.MoveThetaNext));

                        // Apply Theta
                        eb = Avx512F.Xor(eb, cuda);
                        eg = Avx512F.Xor(eg, cuda);
                        ek = Avx512F.Xor(ek, cuda);
                        em = Avx512F.Xor(em, cuda);
                        es = Avx512F.Xor(es, cuda);
                    }

                    // Rho
                    eb = Avx512F.RotateLeftVariable(eb, vectors.RhoB);
                    eg = Avx512F.RotateLeftVariable(eg, vectors.RhoG);
                    ek = Avx512F.RotateLeftVariable(ek, vectors.RhoK);
                    em = Avx512F.RotateLeftVariable(em, vectors.RhoM);
                    es = Avx512F.RotateLeftVariable(es, vectors.RhoS);

                    // Pi
                    eb = Avx512F.PermuteVar8x64(eb, vectors.Pi1B);
                    eg = Avx512F.PermuteVar8x64(eg, vectors.Pi1G);
                    ek = Avx512F.PermuteVar8x64(ek, vectors.Pi1K);
                    em = Avx512F.PermuteVar8x64(em, vectors.Pi1M);
                    es = Avx512F.PermuteVar8x64(es, vectors.Pi1S);

                    // Chi
                    ab = Avx512F.TernaryLogic(eb, eg, ek, chiNonlinearity);
                    ag = Avx512F.TernaryLogic(eg, ek, em, chiNonlinearity);
                    ak = Avx512F.TernaryLogic(ek, em, es, chiNonlinearity);
                    am = Avx512F.TernaryLogic(em, es, eb, chiNonlinearity);
                    @as = Avx512F.TernaryLogic(es, eb, eg, chiNonlinearity);

                    // Iota
                    ab = Avx512F.Xor(ab, rc);

                    // Pi2 reorganization with parity accumulation
                    Vector512<ulong> s0 = Avx512F.UnpackLow(ab, ag);
                    Vector512<ulong> s1 = Avx512F.UnpackLow(ak, am);
                    Vector512<ulong> s2 = Avx512F.UnpackHigh(ab, ag);
                    Vector512<ulong> s3 = Avx512F.UnpackHigh(ak, am);
                    s0 = Avx512F.PermuteVar8x64x2(s0, vectors.Pi2S1, @as);
                    s2 = Avx512F.PermuteVar8x64x2(s2, vectors.Pi2S2, @as);

                    // Pi2 with parity accumulation for next iteration
                    ab = Avx512F.PermuteVar8x64x2(s0, vectors.Pi2BG, s1);
                    ag = Avx512F.PermuteVar8x64x2(s2, vectors.Pi2BG, s3);
                    ak = Avx512F.PermuteVar8x64x2(s0, vectors.Pi2KM, s1);
                    am = Avx512F.PermuteVar8x64x2(s2, vectors.Pi2KM, s3);
                    s0 = Avx512F.PermuteVar8x64x2(s0, vectors.Pi2S3, s1);
                    @as = Avx512F.PermuteVar8x64x2(s0, vectors.Pi2SL4, @as);
                    ca = Avx512F.TernaryLogic(ab, ag, ak, xorThreeOperands);
                    ca = Avx512F.TernaryLogic(ca, am, @as, xorThreeOperands);
                }
            }

            // Store state back
            Unsafe.As<ulong, Vector256<ulong>>(ref statePtr[0]) = ab.GetLower();
            statePtr[4] = ab.GetElement(4);
            Unsafe.As<ulong, Vector256<ulong>>(ref statePtr[5]) = ag.GetLower();
            statePtr[9] = ag.GetElement(4);
            Unsafe.As<ulong, Vector256<ulong>>(ref statePtr[10]) = ak.GetLower();
            statePtr[14] = ak.GetElement(4);
            Unsafe.As<ulong, Vector256<ulong>>(ref statePtr[15]) = am.GetLower();
            statePtr[19] = am.GetElement(4);
            Unsafe.As<ulong, Vector256<ulong>>(ref statePtr[20]) = @as.GetLower();
            statePtr[24] = @as.GetElement(4);
        }
    }
#endif
    #endregion

    #region AVX2 Implementation
#if NET8_0_OR_GREATER
    private static readonly Vector256<ulong> Rol64Avx2RShift = Vector256.Create(64ul);
    private static readonly Vector256<ulong> Plane0Rol64Avx2 = Vector256.Create(0ul, 44ul, 43ul, 21ul);
    private static readonly Vector256<ulong> Plane1Rol64Avx2 = Vector256.Create(28ul, 20ul, 3ul, 45ul);
    private static readonly Vector256<ulong> Plane2Rol64Avx2 = Vector256.Create(1ul, 6ul, 25ul, 8ul);
    private static readonly Vector256<ulong> Plane3Rol64Avx2 = Vector256.Create(27ul, 36ul, 10ul, 15ul);
    private static readonly Vector256<ulong> Plane4Rol64Avx2 = Vector256.Create(62ul, 55ul, 39ul, 41ul);
    private static readonly Vector256<ulong> BksgmRol64Avx2 = Vector256.Create(18ul, 2ul, 61ul, 56ul);

    /// <summary>
    /// Performs 64-bit rotation using AVX2 shift and OR operations.
    /// </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static Vector256<ulong> Rol64Avx2(Vector256<ulong> a, byte offset)
    {
        return Avx2.Or(Avx2.ShiftLeftLogical(a, offset), Avx2.ShiftRightLogical(a, (byte)(64 - offset)));
    }

    /// <summary>
    /// Performs 64-bit rotation on each lane of a Vector256 with different rotation amounts.
    /// </summary>
    /// <returns>A vector with each element rotated left by its corresponding amount.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static Vector256<ulong> Rol64Avx2(Vector256<ulong> a, Vector256<ulong> leftShifts)
    {
        // Perform variable shifts and combine with OR
        return Avx2.Or(
            Avx2.ShiftLeftLogicalVariable(a, leftShifts),
            Avx2.ShiftRightLogicalVariable(a, Avx2.Subtract(Rol64Avx2RShift, leftShifts)));
    }

    private static readonly Vector256<ulong>[] RoundConstantsAvx2 = CreateRoundConstantsAvx2();

    private static Vector256<ulong>[] CreateRoundConstantsAvx2()
    {
        var constants = new Vector256<ulong>[Rounds];
        for (int i = 0; i < Rounds; i++)
        {
            constants[i] = Vector256.Create(RoundConstants[i], 0UL, 0UL, 0UL);
        }
        return constants;
    }

    /// <summary>
    /// AVX2-optimized Keccak-f[1600] permutation with fully vectorized lanes.
    ///
    /// Implementation notes:
    /// - The Keccak permutation is composed of the steps Theta, Rho, Pi, Chi and Iota.
    /// - This routine processes two rounds per loop iteration (round and round+1) to allow
    ///   pipelined accumulation of Theta parity and reduce register pressure.
    /// - Vectors are grouped by plane (y) and by x lanes packed into a Vector256&lt;ulong&gt;:
    ///     - "aeio" vectors pack x=0,1,2,3 lanes into the 4 lanes of a Vector256
    ///     - The x=4 lanes (U lanes) are stored separately in Vector256 where only element 0
    ///       is used. Storing U lanes separately avoids frequent scalar/vector transitions.
    /// - Naming convention used in the code: [State][Plane][Lanes]
    ///     - State: a (input), b (after Rho/Pi), e (after Chi), c (Theta parity), d (Theta effect)
    ///     - Plane: b (y=0), g (y=1), k (y=2), m (y=3), s (y=4)
    ///     - Lanes: aeio (x=0,1,2,3 in a vector), u (x=4 in separate vector)
    ///
    /// The implementation carefully uses blends, permutes and byte-shuffle rotations where
    /// those are faster than variable shifts on each target CPU. Results are written back
    /// to the scalar state array at the end of the permutation.
    /// </summary>
    [SkipLocalsInit]
    [MethodImpl(MethodImplOptionsEx.OptimizedLoop)]
    public void PermuteAvx2()
    {
        // Vector variables naming convention:
        // [State][Plane][Lanes]
        // State: a (current), b (after Rho/Pi), e (after Chi), c (Theta parity), d (Theta effect)
        // Plane: b(y=0), g(y=1), k(y=2), m(y=3), s(y=4)
        // Lanes: aeio (x=0,1,2,3 in a vector), u (x=4 in lane 0 of separate vector)
        //        permutated planes in lines named as e.g. ceiou (C plane, eiou lanes)

        Vector256<ulong> abaeio, ebaeio;
        Vector256<ulong> agaeio, egaeio;
        Vector256<ulong> akaeio, ekaeio;
        Vector256<ulong> amaeio, emaeio;
        Vector256<ulong> asaeio, esaeio;

        // U-lanes: value in lane 0, other lanes unused
        Vector256<ulong> abu, ebu;
        Vector256<ulong> agu, egu;
        Vector256<ulong> aku, eku;
        Vector256<ulong> amu, emu;
        Vector256<ulong> asu, esu;

        // Theta parity and effect
        Vector256<ulong> caeio, daeio;
        Vector256<ulong> cu, du;

        fixed (ulong* statePtr = _state)
        {
            ref Vector256<ulong> rcBase = ref MemoryMarshal.GetArrayDataReference(RoundConstantsAvx2);

            // Load state into vectors
            // Key detail: we use Vector256.Create(value) for the U-lanes so that the value
            // is available in a vector register. All elements of the U-vector are meaningful;
            // This lets us keep all math in vector domain
            // and avoid back-and-forth scalar/vector traffic which is expensive.
            abaeio = Unsafe.As<ulong, Vector256<ulong>>(ref statePtr[0]);
            abu = Vector256.Create(statePtr[4]);
            agaeio = Unsafe.As<ulong, Vector256<ulong>>(ref statePtr[5]);
            agu = Vector256.Create(statePtr[9]);
            akaeio = Unsafe.As<ulong, Vector256<ulong>>(ref statePtr[10]);
            aku = Vector256.Create(statePtr[14]);
            amaeio = Unsafe.As<ulong, Vector256<ulong>>(ref statePtr[15]);
            amu = Vector256.Create(statePtr[19]);
            asaeio = Unsafe.As<ulong, Vector256<ulong>>(ref statePtr[20]);
            asu = Vector256.Create(statePtr[24]);

            // 1. Initial Theta Parity
            caeio = Avx2.Xor(abaeio, Avx2.Xor(agaeio, Avx2.Xor(akaeio, Avx2.Xor(amaeio, asaeio))));
            cu = Avx2.Xor(abu, Avx2.Xor(agu, Avx2.Xor(aku, Avx2.Xor(amu, asu))));

            for (int round = _startRound; round < Rounds; round += 2)
            {
                // =================================================================================
                // ROUND 1 (A -> E)
                // =================================================================================
                {
                    // Daeio[i] = C[(i+4)%5] ^ ROL(C[(i+1)%5], 1)
                    // For aeio lanes: Da = Cu ^ ROL(Ce,1), De = Ca ^ ROL(Ci,1), Di = Ce ^ ROL(Co,1), Do = Ci ^ ROL(Cu,1)
                    // Ceiou: permute Caeio then replace lane3 with Cu
                    var ceiou = Avx.Blend(
                        Avx2.Permute4x64(caeio, 0b00_11_10_01).AsDouble(),
                        cu.AsDouble(),
                        0b1000 /* select lane3 from Cu */
                        ).AsUInt64();

                    // Cuaei: permute Caeio then replace lane0 with Cu
                    var cuaei = Avx.Blend(
                        Avx2.Permute4x64(caeio, 0b10_01_00_00).AsDouble(),
                        cu.AsDouble(),
                        0b0001 /* select lane0 from Cu */
                        ).AsUInt64();
                    var ceiouRol1 = Rol64Avx2(ceiou, 1);
                    daeio = Avx2.Xor(cuaei, ceiouRol1);

                    // Du = Co ^ ROL(Ca, 1) (only lane 0 is meaningful; broadcast for invariant)
                    du = Avx2.Xor(
                        Avx2.Permute4x64(caeio, 0b11_11_11_11),
                        Rol64Avx2(Avx2.Permute4x64(caeio, 0b00_00_00_00), 1)
                        );
                }

                // Apply Theta - all in vector domain
                abaeio = Avx2.Xor(abaeio, daeio); abu = Avx2.Xor(abu, du);
                agaeio = Avx2.Xor(agaeio, daeio); agu = Avx2.Xor(agu, du);
                akaeio = Avx2.Xor(akaeio, daeio); aku = Avx2.Xor(aku, du);
                amaeio = Avx2.Xor(amaeio, daeio); amu = Avx2.Xor(amu, du);
                asaeio = Avx2.Xor(asaeio, daeio); asu = Avx2.Xor(asu, du);

                // Plane 0: gather [Aba, Age, Aki, Amo] + Bbu from Asu
                {
                    var rc = Unsafe.Add(ref rcBase, round);
                    var bbaeio = Rol64Avx2(
                        Avx.Blend(
                            Avx.Blend(abaeio.AsDouble(), agaeio.AsDouble(), 0b_0010),
                            Avx.Blend(akaeio.AsDouble(), amaeio.AsDouble(), 0b_1000),
                            0b_1100).AsUInt64(),
                        Plane0Rol64Avx2);

                    var bbu = Rol64Avx2(asu, 14);
                    var bbioua = Avx.Blend(
                        Avx2.Permute4x64(bbaeio, 0b00_00_11_10).AsDouble(),
                        bbu.AsDouble(), 0b0100).AsUInt64();
                    var bbeiou = Avx.Blend(
                        Avx2.Permute4x64(bbaeio, 0b00_11_10_01).AsDouble(),
                        bbu.AsDouble(), 0b1000).AsUInt64();
                    ebaeio = Avx2.Xor(bbaeio, Avx2.AndNot(bbeiou, bbioua));
                    // Chi logic works on Lane 0, but unused lanes get garbage. Broadcast result to restore invariant.
                    ebu = Avx2.Xor(bbu, Avx2.AndNot(bbaeio, bbeiou));
                    ebu = Avx2.Permute4x64(ebu, 0b00_00_00_00);
                    ebaeio = Avx2.Xor(ebaeio, rc);
                }
                caeio = ebaeio; cu = ebu;

                var bksgm = Rol64Avx2(asaeio, BksgmRol64Avx2);

                // Plane 1: gather [Abo, Agu, Aka, Ame] + Bgu from Asi
                {
                    var bgaeio = Rol64Avx2(
                        Avx.Blend(
                            Avx.Blend(
                                Avx.Blend(
                                    Avx2.Permute4x64(abaeio, 0b_11_11_11_11).AsDouble(),
                                    Avx2.Permute4x64(akaeio, 0b_00_00_00_00).AsDouble(),
                                    0b_0100),
                                Avx2.Permute4x64(amaeio, 0b_01_01_01_01).AsDouble(),
                                0b_1000),
                            agu.AsDouble(),
                        0b_0010).AsUInt64(),
                        Plane1Rol64Avx2);

                    var bgu = Avx2.Permute4x64(bksgm, 0b_10_10_10_10);
                    var bgioua = Avx.Blend(
                        Avx2.Permute4x64(bgaeio, 0b00_00_11_10).AsDouble(),
                        bgu.AsDouble(), 0b0100).AsUInt64();
                    var bgeiou = Avx.Blend(
                        Avx2.Permute4x64(bgaeio, 0b00_11_10_01).AsDouble(),
                        bgu.AsDouble(), 0b1000).AsUInt64();
                    egaeio = Avx2.Xor(bgaeio, Avx2.AndNot(bgeiou, bgioua));
                    egu = Avx2.Xor(bgu, Avx2.AndNot(bgaeio, bgeiou));
                    egu = Avx2.Permute4x64(egu, 0b00_00_00_00);
                }
                caeio = Avx2.Xor(caeio, egaeio); cu = Avx2.Xor(cu, egu);

                // Plane 2: gather [Abe, Agi, Ako, Amu] + Bku from Asa
                {
                    var bkaeio = Rol64Avx2(
                        Avx.Blend(
                            Avx.Blend(
                                Avx.Blend(
                                    Avx2.Permute4x64(abaeio, 0b_01_01_01_01).AsDouble(),
                                    Avx2.Permute4x64(agaeio, 0b_10_10_10_10).AsDouble(),
                                    0b_0010),
                                Avx2.Permute4x64(akaeio, 0b_11_11_11_11).AsDouble(),
                                0b_0100),
                            amu.AsDouble(),
                            0b_1000).AsUInt64(),
                        Plane2Rol64Avx2);

                    var bku = Avx2.Permute4x64(bksgm, 0b_00_00_00_00);
                    var bkioua = Avx.Blend(
                        Avx2.Permute4x64(bkaeio, 0b00_00_11_10).AsDouble(),
                        bku.AsDouble(), 0b0100).AsUInt64();
                    var bkeiou = Avx.Blend(
                        Avx2.Permute4x64(bkaeio, 0b00_11_10_01).AsDouble(),
                        bku.AsDouble(), 0b1000).AsUInt64();
                    ekaeio = Avx2.Xor(bkaeio, Avx2.AndNot(bkeiou, bkioua));
                    eku = Avx2.Xor(bku, Avx2.AndNot(bkaeio, bkeiou));
                    eku = Avx2.Permute4x64(eku, 0b00_00_00_00);
                }
                caeio = Avx2.Xor(caeio, ekaeio); cu = Avx2.Xor(cu, eku);

                // Plane 3: gather [Abu, Aga, Ake, Ami] + Bmu from Aso
                {
                    var bmaeio = Rol64Avx2(
                        Avx.Blend(
                            abu.AsDouble(),
                            Avx.Blend(
                                Avx.Blend(
                                    Avx2.Permute4x64(agaeio, 0b_00_00_00_00).AsDouble(),
                                    Avx2.Permute4x64(akaeio, 0b_01_01_01_01).AsDouble(),
                                    0b_0100),
                                Avx2.Permute4x64(amaeio, 0b_10_10_10_10).AsDouble(),
                                0b_1000),
                            0b_1110).AsUInt64(),
                        Plane3Rol64Avx2);

                    var bmu = Avx2.Permute4x64(bksgm, 0b_11_11_11_11);
                    var bmioua = Avx.Blend(
                        Avx2.Permute4x64(bmaeio, 0b00_00_11_10).AsDouble(),
                        bmu.AsDouble(), 0b0100).AsUInt64();
                    var bmeiou = Avx.Blend(
                        Avx2.Permute4x64(bmaeio, 0b00_11_10_01).AsDouble(),
                        bmu.AsDouble(), 0b1000).AsUInt64();
                    emaeio = Avx2.Xor(bmaeio, Avx2.AndNot(bmeiou, bmioua));
                    emu = Avx2.Xor(bmu, Avx2.AndNot(bmaeio, bmeiou));
                    emu = Avx2.Permute4x64(emu, 0b00_00_00_00);
                }
                caeio = Avx2.Xor(caeio, emaeio); cu = Avx2.Xor(cu, emu);

                // Plane 4: gather [Abi, Ago, Aku, Ama] + Bsu from Ase
                {
                    var bsaeio = Rol64Avx2(
                        Avx.Blend(
                            Avx.Blend(
                                Avx.Blend(
                                    Avx2.Permute4x64(abaeio, 0b_10_10_10_10).AsDouble(),
                                    Avx2.Permute4x64(agaeio, 0b_11_11_11_11).AsDouble(),
                                    0b_0010),
                                Avx2.Permute4x64(amaeio, 0b_00_00_00_00).AsDouble(),
                                0b_1000),
                            aku.AsDouble(),
                            0b_0100).AsUInt64(),
                        Plane4Rol64Avx2);

                    var bsu = Avx2.Permute4x64(bksgm, 0b_01_01_01_01);
                    var bsioua = Avx.Blend(
                        Avx2.Permute4x64(bsaeio, 0b00_00_11_10).AsDouble(),
                        bsu.AsDouble(), 0b0100).AsUInt64();
                    var bseiou = Avx.Blend(
                        Avx2.Permute4x64(bsaeio, 0b00_11_10_01).AsDouble(),
                        bsu.AsDouble(), 0b1000).AsUInt64();
                    esaeio = Avx2.Xor(bsaeio, Avx2.AndNot(bseiou, bsioua));
                    esu = Avx2.Xor(bsu, Avx2.AndNot(bsaeio, bseiou));
                    esu = Avx2.Permute4x64(esu, 0b00_00_00_00);
                }
                caeio = Avx2.Xor(caeio, esaeio); cu = Avx2.Xor(cu, esu);

                // =================================================================================
                // ROUND 2 (E -> A)
                // =================================================================================
                {
                    var ceiou = Avx.Blend(
                        Avx2.Permute4x64(caeio, 0b00_11_10_01).AsDouble(),
                        cu.AsDouble(),
                        0b1000 /* select lane3 from Cu */
                        ).AsUInt64();

                    var cuaei = Avx.Blend(
                        Avx2.Permute4x64(caeio, 0b10_01_00_00).AsDouble(),
                        cu.AsDouble(),
                        0b0001 /* select lane0 from Cu */
                        ).AsUInt64();

                    daeio = Avx2.Xor(cuaei, Rol64Avx2(ceiou, 1));
                    du = Avx2.Xor(
                        Avx2.Permute4x64(caeio, 0b11_11_11_11),
                        Rol64Avx2(Avx2.Permute4x64(caeio, 0b00_00_00_00), 1)
                        );
                }

                ebaeio = Avx2.Xor(ebaeio, daeio); ebu = Avx2.Xor(ebu, du);
                egaeio = Avx2.Xor(egaeio, daeio); egu = Avx2.Xor(egu, du);
                ekaeio = Avx2.Xor(ekaeio, daeio); eku = Avx2.Xor(eku, du);
                emaeio = Avx2.Xor(emaeio, daeio); emu = Avx2.Xor(emu, du);
                esaeio = Avx2.Xor(esaeio, daeio); esu = Avx2.Xor(esu, du);

                // Plane 0
                {
                    var rc = Unsafe.Add(ref rcBase, round + 1);
                    var bbaeio = Rol64Avx2(
                        Avx.Blend(
                            Avx.Blend(ebaeio.AsDouble(), egaeio.AsDouble(), 0b_0010),
                            Avx.Blend(ekaeio.AsDouble(), emaeio.AsDouble(), 0b_1000),
                            0b_1100).AsUInt64(),
                        Plane0Rol64Avx2);

                    var bbu = Rol64Avx2(esu, 14);
                    var bbioua = Avx.Blend(
                        Avx2.Permute4x64(bbaeio, 0b00_00_11_10).AsDouble(),
                        bbu.AsDouble(), 0b0100).AsUInt64();
                    var bbeiou = Avx.Blend(
                        Avx2.Permute4x64(bbaeio, 0b00_11_10_01).AsDouble(),
                        bbu.AsDouble(), 0b1000).AsUInt64();
                    abaeio = Avx2.Xor(bbaeio, Avx2.AndNot(bbeiou, bbioua));
                    abaeio = Avx2.Xor(abaeio, RoundConstantsAvx2[round + 1]); // Apply constant early

                    abu = Avx2.Xor(bbu, Avx2.AndNot(bbaeio, bbeiou));
                    abu = Avx2.Permute4x64(abu, 0b00_00_00_00);
                }
                caeio = abaeio;
                cu = abu;

                // Gather Bksgm from Esaeio and prepare for planes 1..4
                bksgm = Rol64Avx2(esaeio, BksgmRol64Avx2);

                // Plane 1
                {
                    var bgaeio = Rol64Avx2(
                        Avx.Blend(
                            Avx.Blend(
                                Avx.Blend(
                                    Avx2.Permute4x64(ebaeio, 0b_11_11_11_11).AsDouble(),
                                    Avx2.Permute4x64(ekaeio, 0b_00_00_00_00).AsDouble(),
                                    0b_0100),
                                Avx2.Permute4x64(emaeio, 0b_01_01_01_01).AsDouble(),
                                0b_1000),
                            egu.AsDouble(),
                            0b_0010).AsUInt64(),
                        Plane1Rol64Avx2);

                    var bgu = Avx2.Permute4x64(bksgm, 0b_10_10_10_10);
                    var bgioua = Avx.Blend(
                        Avx2.Permute4x64(bgaeio, 0b00_00_11_10).AsDouble(),
                        bgu.AsDouble(), 0b0100).AsUInt64();
                    var bgeiou = Avx.Blend(
                        Avx2.Permute4x64(bgaeio, 0b00_11_10_01).AsDouble(),
                        bgu.AsDouble(), 0b1000).AsUInt64();
                    agaeio = Avx2.Xor(bgaeio, Avx2.AndNot(bgeiou, bgioua));
                    agu = Avx2.Xor(bgu, Avx2.AndNot(bgaeio, bgeiou));
                    agu = Avx2.Permute4x64(agu, 0b00_00_00_00);
                }
                caeio = Avx2.Xor(caeio, agaeio);
                cu = Avx2.Xor(cu, agu);

                // Plane 2
                {
                    var bkaeio = Rol64Avx2(
                        Avx.Blend(
                            Avx.Blend(
                                Avx.Blend(
                                    Avx2.Permute4x64(ebaeio, 0b_01_01_01_01).AsDouble(),
                                    Avx2.Permute4x64(egaeio, 0b_10_10_10_10).AsDouble(),
                                    0b_0010),
                                Avx2.Permute4x64(ekaeio, 0b_11_11_11_11).AsDouble(),
                                0b_0100),
                            emu.AsDouble(),
                            0b_1000).AsUInt64(),
                        Plane2Rol64Avx2);

                    var bku = Avx2.Permute4x64(bksgm, 0b_00_00_00_00);
                    var bkioua = Avx.Blend(
                        Avx2.Permute4x64(bkaeio, 0b00_00_11_10).AsDouble(),
                        bku.AsDouble(), 0b0100).AsUInt64();
                    var bkeiou = Avx.Blend(
                        Avx2.Permute4x64(bkaeio, 0b00_11_10_01).AsDouble(),
                        bku.AsDouble(), 0b1000).AsUInt64();
                    akaeio = Avx2.Xor(bkaeio, Avx2.AndNot(bkeiou, bkioua));
                    aku = Avx2.Xor(bku, Avx2.AndNot(bkaeio, bkeiou));
                    aku = Avx2.Permute4x64(aku, 0b00_00_00_00);
                }
                caeio = Avx2.Xor(caeio, akaeio);
                cu = Avx2.Xor(cu, aku);

                // Plane 3
                {
                    var bmaeio = Rol64Avx2(
                        Avx.Blend(
                            ebu.AsDouble(),
                            Avx.Blend(
                                Avx.Blend(
                                    Avx2.Permute4x64(egaeio, 0b_00_00_00_00).AsDouble(),
                                    Avx2.Permute4x64(ekaeio, 0b_01_01_01_01).AsDouble(),
                                    0b_0100),
                                Avx2.Permute4x64(emaeio, 0b_10_10_10_10).AsDouble(),
                                0b_1000),
                            0b_1110).AsUInt64(),
                        Plane3Rol64Avx2);

                    var bmu = Avx2.Permute4x64(bksgm, 0b_11_11_11_11);
                    var bmioua = Avx.Blend(
                        Avx2.Permute4x64(bmaeio, 0b00_00_11_10).AsDouble(),
                        bmu.AsDouble(), 0b0100).AsUInt64();
                    var bmeiou = Avx.Blend(
                        Avx2.Permute4x64(bmaeio, 0b00_11_10_01).AsDouble(),
                        bmu.AsDouble(), 0b1000).AsUInt64();
                    amaeio = Avx2.Xor(bmaeio, Avx2.AndNot(bmeiou, bmioua));
                    amu = Avx2.Xor(bmu, Avx2.AndNot(bmaeio, bmeiou));
                    amu = Avx2.Permute4x64(amu, 0b00_00_00_00);
                }
                caeio = Avx2.Xor(caeio, amaeio);
                cu = Avx2.Xor(cu, amu);

                // Plane 4
                {
                    var bsaeio = Rol64Avx2(
                        Avx.Blend(
                            Avx.Blend(
                                Avx.Blend(
                                    Avx2.Permute4x64(ebaeio, 0b_10_10_10_10).AsDouble(),
                                    Avx2.Permute4x64(egaeio, 0b_11_11_11_11).AsDouble(),
                                    0b_0010),
                                Avx2.Permute4x64(emaeio, 0b_00_00_00_00).AsDouble(),
                                0b_1000),
                            eku.AsDouble(),
                            0b_0100).AsUInt64(),
                        Plane4Rol64Avx2);

                    var bsu = Avx2.Permute4x64(bksgm, 0b_01_01_01_01);
                    var bsioua = Avx.Blend(
                        Avx2.Permute4x64(bsaeio, 0b00_00_11_10).AsDouble(),
                        bsu.AsDouble(), 0b0100).AsUInt64();
                    var bseiou = Avx.Blend(
                        Avx2.Permute4x64(bsaeio, 0b00_11_10_01).AsDouble(),
                        bsu.AsDouble(), 0b1000).AsUInt64();
                    asaeio = Avx2.Xor(bsaeio, Avx2.AndNot(bseiou, bsioua));
                    asu = Avx2.Xor(bsu, Avx2.AndNot(bsaeio, bseiou));
                    asu = Avx2.Permute4x64(asu, 0b00_00_00_00);
                }
                caeio = Avx2.Xor(caeio, asaeio);
                cu = Avx2.Xor(cu, asu);
            }

            // Store state back
            Unsafe.As<ulong, Vector256<ulong>>(ref statePtr[0]) = abaeio;
            statePtr[4] = abu.GetElement(0);
            Unsafe.As<ulong, Vector256<ulong>>(ref statePtr[5]) = agaeio;
            statePtr[9] = agu.GetElement(0);
            Unsafe.As<ulong, Vector256<ulong>>(ref statePtr[10]) = akaeio;
            statePtr[14] = aku.GetElement(0);
            Unsafe.As<ulong, Vector256<ulong>>(ref statePtr[15]) = amaeio;
            statePtr[19] = amu.GetElement(0);
            Unsafe.As<ulong, Vector256<ulong>>(ref statePtr[20]) = asaeio;
            statePtr[24] = asu.GetElement(0);
        }
    }
#endif
    #endregion

    #region Scalar Implementation
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static ulong GetRoundConstants(int round)
    {
#if NET8_0_OR_GREATER
        return Unsafe.Add(ref MemoryMarshal.GetArrayDataReference(RoundConstants), round);
#else
        return RoundConstants[round];
#endif
    }

    /// <summary>
    /// Scalar Keccak-f[1600] permutation implementation.
    /// </summary>

    /// <remarks>
    /// Implementation notes:
    /// - This follows the reference-style structure used in the XKCP optimized C code
    ///   (see KeccakP-1600-opt64), with explicit local variables named per lane to
    ///   maximize register allocation and clarity.
    /// - The routine computes two rounds per loop iteration (round and round+1). The
    ///   Theta parities are accumulated for the next round while Rho/Pi/Chi/Iota are
    ///   applied to the current lanes. This interleaving reduces temporary storage and
    ///   improves instruction-level parallelism on scalar cores.
    /// - The local variable naming matches the conventional Keccak layout: rows (A/E)
    ///   and columns (y=0..4) with lanes named by their x coordinate and row (e.g., aba,
    ///   abe, ..., asu). Temporary variables for Theta parity (ca, ce, ...) and
    ///   D effects (da, de, ...) are used to express the algorithm steps directly.
    /// - Use BitOperations.RotateLeft for 64-bit rotations which maps to efficient
    ///   CPU instructions on supported runtimes.
    /// On any benchmarked x64 CPU architecture, this scalar implementation is outperforming
    /// all SIMD variants in this class including the native Windows 11 OS SHA3
    /// implementation. ARM and linux results may vary and need to be benchmarked as well.
    /// </remarks>
    [SkipLocalsInit]
    [MethodImpl(MethodImplOptionsEx.OptimizedLoop)]
    public void PermuteScalar()
    {
        ulong aba, abe, abi, abo, abu;
        ulong aga, age, agi, ago, agu;
        ulong aka, ake, aki, ako, aku;
        ulong ama, ame, ami, amo, amu;
        ulong asa, ase, asi, aso, asu;
        ulong ca, ce, ci, co, cu;
        ulong da, de, di, @do, du;
        ulong eba, ebe, ebi, ebo, ebu;
        ulong ega, ege, egi, ego, egu;
        ulong eka, eke, eki, eko, eku;
        ulong ema, eme, emi, emo, emu;
        ulong esa, ese, esi, eso, esu;

        fixed (ulong* state = _state)
        {
            asu = state[24]; aso = state[23]; asi = state[22]; ase = state[21]; asa = state[20];
            amu = state[19]; amo = state[18]; ami = state[17]; ame = state[16]; ama = state[15];
            aku = state[14]; ako = state[13]; aki = state[12]; ake = state[11]; aka = state[10];
            agu = state[9]; ago = state[8]; agi = state[7]; age = state[6]; aga = state[5];
            abu = state[4]; abo = state[3]; abi = state[2]; abe = state[1]; aba = state[0];

            for (int round = _startRound; round < Rounds; round += 2)
            {
                // prepareTheta
                ce = abe ^ age ^ ake ^ ame ^ ase;
                cu = abu ^ agu ^ aku ^ amu ^ asu;

                // thetaRhoPiChiIotaPrepareTheta(round, A, E)
                da = cu ^ BitOperations.RotateLeft(ce, 1);
                co = abo ^ ago ^ ako ^ amo ^ aso;
                di = ce ^ BitOperations.RotateLeft(co, 1);
                ci = abi ^ agi ^ aki ^ ami ^ asi;
                @do = ci ^ BitOperations.RotateLeft(cu, 1);
                ca = aba ^ aga ^ aka ^ ama ^ asa;
                du = co ^ BitOperations.RotateLeft(ca, 1);
                de = ca ^ BitOperations.RotateLeft(ci, 1);

                ca = aba ^ da;
                ce = BitOperations.RotateLeft(age ^ de, 44);
                ci = BitOperations.RotateLeft(aki ^ di, 43);
                eba = ca ^ ((~ce) & ci) ^ GetRoundConstants(round);
                co = BitOperations.RotateLeft(amo ^ @do, 21);
                ebe = ce ^ ((~ci) & co);
                cu = BitOperations.RotateLeft(asu ^ du, 14);
                ebu = cu ^ ((~ca) & ce);
                ce = BitOperations.RotateLeft(agu ^ du, 20);
                ebo = co ^ ((~cu) & ca);
                ca = BitOperations.RotateLeft(abo ^ @do, 28);
                ebi = ci ^ ((~co) & cu);

                ci = BitOperations.RotateLeft(aka ^ da, 3);
                ega = ca ^ ((~ce) & ci);
                co = BitOperations.RotateLeft(ame ^ de, 45);
                ege = ce ^ ((~ci) & co);
                cu = BitOperations.RotateLeft(asi ^ di, 61);
                egu = cu ^ ((~ca) & ce);
                ce = BitOperations.RotateLeft(agi ^ di, 6);
                ego = co ^ ((~cu) & ca);
                ca = BitOperations.RotateLeft(abe ^ de, 1);
                egi = ci ^ ((~co) & cu);

                ci = BitOperations.RotateLeft(ako ^ @do, 25);
                eka = ca ^ ((~ce) & ci);
                co = BitOperations.RotateLeft(amu ^ du, 8);
                eke = ce ^ ((~ci) & co);
                cu = BitOperations.RotateLeft(asa ^ da, 18);
                eku = cu ^ ((~ca) & ce);
                ce = BitOperations.RotateLeft(aga ^ da, 36);
                eko = co ^ ((~cu) & ca);
                ca = BitOperations.RotateLeft(abu ^ du, 27);
                eki = ci ^ ((~co) & cu);

                ci = BitOperations.RotateLeft(ake ^ de, 10);
                ema = ca ^ ((~ce) & ci);
                co = BitOperations.RotateLeft(ami ^ di, 15);
                eme = ce ^ ((~ci) & co);
                cu = BitOperations.RotateLeft(aso ^ @do, 56);
                emu = cu ^ ((~ca) & ce);
                ce = BitOperations.RotateLeft(ago ^ @do, 55);
                emo = co ^ ((~cu) & ca);
                ca = BitOperations.RotateLeft(abi ^ di, 62);
                emi = ci ^ ((~co) & cu);

                ci = BitOperations.RotateLeft(aku ^ du, 39);
                esa = ca ^ ((~ce) & ci);
                co = BitOperations.RotateLeft(ama ^ da, 41);
                ese = ce ^ ((~ci) & co);
                cu = BitOperations.RotateLeft(ase ^ de, 2);
                esi = ci ^ ((~co) & cu);
                eso = co ^ ((~cu) & ca);
                esu = cu ^ ((~ca) & ce);

                // prepareTheta (more interleaved with rotations)
                ce = ebe ^ ege ^ eke ^ eme ^ ese;
                cu = ebu ^ egu ^ eku ^ emu ^ esu;

                // thetaRhoPiChiIotaPrepareTheta(round+1, E, A)
                // Compute D values for the next round from the newly accumulated parities.
                da = cu ^ BitOperations.RotateLeft(ce, 1);
                ci = ebi ^ egi ^ eki ^ emi ^ esi;
                @do = ci ^ BitOperations.RotateLeft(cu, 1);
                ca = eba ^ ega ^ eka ^ ema ^ esa;
                de = ca ^ BitOperations.RotateLeft(ci, 1);
                co = ebo ^ ego ^ eko ^ emo ^ eso;
                di = ce ^ BitOperations.RotateLeft(co, 1);
                du = co ^ BitOperations.RotateLeft(ca, 1);

                ci = BitOperations.RotateLeft(eki ^ di, 43);
                ce = BitOperations.RotateLeft(ege ^ de, 44);
                ca = eba ^ da;
                aba = ca ^ ((~ce) & ci) ^ GetRoundConstants(round + 1);
                co = BitOperations.RotateLeft(emo ^ @do, 21);
                abe = ce ^ ((~ci) & co);
                cu = BitOperations.RotateLeft(esu ^ du, 14);
                abu = cu ^ ((~ca) & ce);
                ce = BitOperations.RotateLeft(egu ^ du, 20);
                abo = co ^ ((~cu) & ca);
                ca = BitOperations.RotateLeft(ebo ^ @do, 28);
                abi = ci ^ ((~co) & cu);

                ci = BitOperations.RotateLeft(eka ^ da, 3);
                aga = ca ^ ((~ce) & ci);
                co = BitOperations.RotateLeft(eme ^ de, 45);
                age = ce ^ ((~ci) & co);
                cu = BitOperations.RotateLeft(esi ^ di, 61);
                agu = cu ^ ((~ca) & ce);
                ce = BitOperations.RotateLeft(egi ^ di, 6);
                ago = co ^ ((~cu) & ca);
                ca = BitOperations.RotateLeft(ebe ^ de, 1);
                agi = ci ^ ((~co) & cu);

                ci = BitOperations.RotateLeft(eko ^ @do, 25);
                aka = ca ^ ((~ce) & ci);
                co = BitOperations.RotateLeft(emu ^ du, 8);
                ake = ce ^ ((~ci) & co);
                cu = BitOperations.RotateLeft(esa ^ da, 18);
                aku = cu ^ ((~ca) & ce);
                ce = BitOperations.RotateLeft(ega ^ da, 36);
                ako = co ^ ((~cu) & ca);
                ca = BitOperations.RotateLeft(ebu ^ du, 27);
                aki = ci ^ ((~co) & cu);

                ci = BitOperations.RotateLeft(eke ^ de, 10);
                ama = ca ^ ((~ce) & ci);
                co = BitOperations.RotateLeft(emi ^ di, 15);
                ame = ce ^ ((~ci) & co);
                cu = BitOperations.RotateLeft(eso ^ @do, 56);
                amu = cu ^ ((~ca) & ce);
                ce = BitOperations.RotateLeft(ego ^ @do, 55);
                amo = co ^ ((~cu) & ca);
                ca = BitOperations.RotateLeft(ebi ^ di, 62);
                ami = ci ^ ((~co) & cu);

                ci = BitOperations.RotateLeft(eku ^ du, 39);
                asa = ca ^ ((~ce) & ci);
                co = BitOperations.RotateLeft(ema ^ da, 41);
                ase = ce ^ ((~ci) & co);
                cu = BitOperations.RotateLeft(ese ^ de, 2);
                asi = ci ^ ((~co) & cu);
                aso = co ^ ((~cu) & ca);
                asu = cu ^ ((~ca) & ce);
            }

            // copyToState(statePtr, A)
            state[24] = asu; state[23] = aso; state[22] = asi; state[21] = ase; state[20] = asa;
            state[19] = amu; state[18] = amo; state[17] = ami; state[16] = ame; state[15] = ama;
            state[14] = aku; state[13] = ako; state[12] = aki; state[11] = ake; state[10] = aka;
            state[9] = agu; state[8] = ago; state[7] = agi; state[6] = age; state[5] = aga;
            state[4] = abu; state[3] = abo; state[2] = abi; state[1] = abe; state[0] = aba;
        }
    }
    #endregion

    /// <summary>
    /// Absorbs a block of data into the Keccak statePtr.
    /// </summary>
    /// <param name="block">The block to absorb (must be exactly rateBytes long).</param>
    /// <param name="rateBytes">The rate in bytes (determines how many bytes to XOR).</param>
    [MethodImpl(MethodImplOptionsEx.OptimizedLoop)]
    public void Absorb(ReadOnlySpan<byte> block, int rateBytes)
    {
        int rateLanes = rateBytes / 8;
        Debug.Assert(rateLanes <= StateSize);

        fixed (ulong* statePtr = _state)
        {
            if (BitConverter.IsLittleEndian)
            {
                // Fast path: direct memory XOR on little-endian systems
                ReadOnlySpan<ulong> blockLanes = MemoryMarshal.Cast<byte, ulong>(block.Slice(0, rateLanes * sizeof(ulong)));
                for (int i = 0; i < rateLanes; i++)
                {
                    statePtr[i] ^= blockLanes[i];
                }
            }
            else
            {
                // Big-endian: convert each ulong individually
                for (int i = 0; i < rateLanes; i++)
                {
                    statePtr[i] ^= BinaryPrimitives.ReadUInt64LittleEndian(block.Slice(i * sizeof(ulong)));
                }
            }
        }

        Permute();
    }

    /// <summary>
    /// Extracts output bytes from the Keccak state (single squeeze, no additional permutations).
    /// </summary>
    /// <param name="output">The buffer to receive the output.</param>
    /// <param name="length">The number of bytes to extract (must be ≤ rate).</param>
    [MethodImpl(MethodImplOptionsEx.OptimizedLoop)]
    public void Squeeze(Span<byte> output, int length)
    {
        const int uInt64Size = sizeof(ulong);

        fixed (ulong* statePtr = _state)
        {
            if (BitConverter.IsLittleEndian)
            {
                // Fast path: direct memory copy on little-endian systems
                new ReadOnlySpan<byte>(statePtr, length).CopyTo(output);
            }
            else
            {
                // Big-endian: convert each ulong individually
                int offset = 0;
                int stateIndex = 0;
                int bytesToCopy = length;

                while (bytesToCopy >= uInt64Size)
                {
                    BinaryPrimitives.WriteUInt64LittleEndian(output.Slice(offset), statePtr[stateIndex]);
                    offset += uInt64Size;
                    bytesToCopy -= uInt64Size;
                    stateIndex++;
                }

                if (bytesToCopy > 0)
                {
                    Span<byte> temp = stackalloc byte[uInt64Size];
                    BinaryPrimitives.WriteUInt64LittleEndian(temp, statePtr[stateIndex]);
                    temp.Slice(0, bytesToCopy).CopyTo(output.Slice(offset));
                }
            }
        }
    }

    /// <summary>
    /// Performs an extended squeeze operation for XOF.
    /// </summary>
    /// <param name="output">The buffer to receive the output.</param>
    /// <param name="rateBytes">The rate in bytes.</param>
    /// <param name="squeezeOffset">
    /// The current offset within the rate portion. Updated after the operation.
    /// </param>
    [MethodImpl(MethodImplOptionsEx.OptimizedLoop)]
    public void SqueezeXof(Span<byte> output, int rateBytes, ref int squeezeOffset)
    {
        int outputOffset = 0;

        fixed (ulong* statePtr = _state)
        {
            while (outputOffset < output.Length)
            {
                if (squeezeOffset >= rateBytes)
                {
                    Permute();
                    squeezeOffset = 0;
                }

                int stateIndex = squeezeOffset / 8;
                int byteIndex = squeezeOffset % 8;

                unchecked
                {
                    while (outputOffset < output.Length && squeezeOffset < rateBytes)
                    {
                        output[outputOffset++] = (byte)(statePtr[stateIndex] >> (byteIndex * 8));
                        byteIndex++;
                        squeezeOffset++;

                        if (byteIndex >= 8)
                        {
                            byteIndex = 0;
                            stateIndex++;
                        }
                    }
                }
            }
        }
    }
}
