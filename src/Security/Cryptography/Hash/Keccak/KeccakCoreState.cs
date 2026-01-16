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
/// However, currently the AVX512F version is slower than the scalar version on AMD 8945
/// which is used for benchmarking, so AVX512F is disabled by default.
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
            var support = SimdSupport.None;
#if NET8_0_OR_GREATER
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
    /// Initializes a new instance of the KeccakCoreStruct structure with the specified SIMD support configuration.
    /// </summary>
    /// <remarks>
    /// The initial state is cleared upon construction. The chosen SIMD support may affect
    /// performance characteristics but does not alter the functional behavior.
    /// </remarks>
    /// <param name="simdSupport">The SIMD support option to choose from. Unsupported bits are masked out.
    /// </param>
    public KeccakCoreState(SimdSupport simdSupport = SimdSupport.None)
    {
        // mask unsupported bits
        _simdSupport = simdSupport & SimdSupport;
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
    /// Performs the Keccak-f[1600] permutation on the given state with explicit SIMD control.
    /// </summary>
    [MethodImpl(MethodImplOptionsEx.OptimizedLoop)]
    public void Permute(int startRound = 0)
    {
#if NET8_0_OR_GREATER
        if ((_simdSupport & SimdSupport.Avx512F) != 0)
        {
            PermuteAvx512F(startRound);
            return;
        }
#endif
        PermuteScalar(startRound);
    }

#if NET8_0_OR_GREATER
    // All static constants hoisted outside method
    private record struct PermuteAvx512FVectors
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

            Lane4Mask = Vector512.Create(0UL, 0UL, 0UL, 0UL, ulong.MaxValue, 0UL, 0UL, 0UL);
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
        public readonly Vector512<ulong> Lane4Mask;
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
    public void PermuteAvx512F(int startRound = 0)
    {
        fixed (ulong* statePtr = _state)
        {
            var vectors = Avx512FVectors;
            var mask5 = vectors.Mask5;

            Vector512<ulong> a0 = Vector512.BitwiseAnd(mask5, Unsafe.As<ulong, Vector512<ulong>>(ref statePtr[0]));
            Vector512<ulong> a1 = Vector512.BitwiseAnd(mask5, Unsafe.As<ulong, Vector512<ulong>>(ref statePtr[5]));
            Vector512<ulong> a2 = Vector512.BitwiseAnd(mask5, Unsafe.As<ulong, Vector512<ulong>>(ref statePtr[10]));
            Vector512<ulong> a3 = Vector512.BitwiseAnd(mask5, Unsafe.As<ulong, Vector512<ulong>>(ref statePtr[15]));

            Vector256<ulong> a4Lower = Unsafe.As<ulong, Vector256<ulong>>(ref statePtr[20]);
            Vector512<ulong> a4 = Vector512.Create(a4Lower, Vector256.Create(statePtr[24], 0UL, 0UL, 0UL));

            for (int round = startRound; round < Rounds; round++)
            {
                Vector512<ulong> parity = Avx512F.TernaryLogic(
                    Avx512F.TernaryLogic(a0, a1, a2, 0x96), a3, a4, 0x96);

                Vector512<ulong> thetaPrev = Avx512F.PermuteVar8x64(parity, vectors.MoveThetaPrev);
                Vector512<ulong> thetaNext = Avx512F.RotateLeft(Avx512F.PermuteVar8x64(parity, vectors.MoveThetaNext), 1);

                a0 = Avx512F.TernaryLogic(a0, thetaPrev, thetaNext, 0x96);
                a1 = Avx512F.TernaryLogic(a1, thetaPrev, thetaNext, 0x96);
                a2 = Avx512F.TernaryLogic(a2, thetaPrev, thetaNext, 0x96);
                a3 = Avx512F.TernaryLogic(a3, thetaPrev, thetaNext, 0x96);
                a4 = Avx512F.TernaryLogic(a4, thetaPrev, thetaNext, 0x96);

                a0 = Avx512F.RotateLeftVariable(a0, vectors.RhoB);
                a1 = Avx512F.RotateLeftVariable(a1, vectors.RhoG);
                a2 = Avx512F.RotateLeftVariable(a2, vectors.RhoK);
                a3 = Avx512F.RotateLeftVariable(a3, vectors.RhoM);
                a4 = Avx512F.RotateLeftVariable(a4, vectors.RhoS);

                Vector512<ulong> p0 = Avx512F.PermuteVar8x64(a0, vectors.Pi1B);
                Vector512<ulong> p1 = Avx512F.PermuteVar8x64(a1, vectors.Pi1G);
                Vector512<ulong> p2 = Avx512F.PermuteVar8x64(a2, vectors.Pi1K);
                Vector512<ulong> p3 = Avx512F.PermuteVar8x64(a3, vectors.Pi1M);
                Vector512<ulong> p4 = Avx512F.PermuteVar8x64(a4, vectors.Pi1S);

                a0 = Avx512F.TernaryLogic(p0, p1, p2, 0xD2);
                a1 = Avx512F.TernaryLogic(p1, p2, p3, 0xD2);
                a2 = Avx512F.TernaryLogic(p2, p3, p4, 0xD2);
                a3 = Avx512F.TernaryLogic(p3, p4, p0, 0xD2);
                a4 = Avx512F.TernaryLogic(p4, p0, p1, 0xD2);

                a0 = Vector512.Xor(a0, RoundConstantsAvx512[round]);

                Vector512<ulong> a4Chi = a4;
                Vector512<ulong> s0 = Avx512F.UnpackLow(a0, a1);
                Vector512<ulong> s1 = Avx512F.UnpackLow(a2, a3);
                s0 = Avx512F.PermuteVar8x64x2(s0, vectors.Pi2S1, a4Chi);
                Vector512<ulong> s2 = Avx512F.UnpackHigh(a0, a1);
                Vector512<ulong> s3 = Avx512F.UnpackHigh(a2, a3);
                s2 = Avx512F.PermuteVar8x64x2(s2, vectors.Pi2S2, a4Chi);

                a0 = Avx512F.PermuteVar8x64x2(s0, vectors.Pi2BG, s1);
                a1 = Avx512F.PermuteVar8x64x2(s2, vectors.Pi2BG, s3);
                a2 = Avx512F.PermuteVar8x64x2(s0, vectors.Pi2KM, s1);
                a3 = Avx512F.PermuteVar8x64x2(s2, vectors.Pi2KM, s3);
                s0 = Avx512F.PermuteVar8x64x2(s0, vectors.Pi2S3, s1);

                Vector512<ulong> lane4Mask = vectors.Lane4Mask;
                Vector512<ulong> keepLane4 = Avx512F.And(lane4Mask, a4Chi);
                Vector512<ulong> replaceOthers = Avx512F.AndNot(lane4Mask, s0);
                a4 = Avx512F.Or(keepLane4, replaceOthers);
            }

            Unsafe.As<ulong, Vector512<ulong>>(ref statePtr[0]) = a0;
            Unsafe.As<ulong, Vector512<ulong>>(ref statePtr[5]) = a1;
            Unsafe.As<ulong, Vector512<ulong>>(ref statePtr[10]) = a2;
            Unsafe.As<ulong, Vector512<ulong>>(ref statePtr[15]) = a3;
            Unsafe.As<ulong, Vector256<ulong>>(ref statePtr[20]) = a4.GetLower();
            statePtr[24] = a4.GetElement(4);
        }
    }

    /// <summary>
    /// This implementation follows the naming conventions and structure from:
    /// https://github.com/XKCP/K12/blob/master/lib/Optimized64/KeccakP-1600-opt64.c
    /// </summary>
    /// <param name="startRound">Set the round start to 12 for TurboShake and KT</param>
    [SkipLocalsInit]
#endif
    [MethodImpl(MethodImplOptionsEx.OptimizedLoop)]
    public void PermuteScalar(int startRound = 0)
    {
        ulong aba, abe, abi, abo, abu;
        ulong aga, age, agi, ago, agu;
        ulong aka, ake, aki, ako, aku;
        ulong ama, ame, ami, amo, amu;
        ulong asa, ase, asi, aso, asu;
        ulong bCa, bCe, bCi, bCo, bCu;
        ulong da, de, di, @do, du;
        ulong eba, ebe, ebi, ebo, ebu;
        ulong ega, ege, egi, ego, egu;
        ulong eka, eke, eki, eko, eku;
        ulong ema, eme, emi, emo, emu;
        ulong esa, ese, esi, eso, esu;

        fixed (ulong* state = _state)
        {
            asu = state[24];
            aso = state[23];
            asi = state[22];
            ase = state[21];
            asa = state[20];
            amu = state[19];
            amo = state[18];
            ami = state[17];
            ame = state[16];
            ama = state[15];
            aku = state[14];
            ako = state[13];
            aki = state[12];
            ake = state[11];
            aka = state[10];
            agu = state[9];
            ago = state[8];
            agi = state[7];
            age = state[6];
            aga = state[5];
            abu = state[4];
            abo = state[3];
            abi = state[2];
            abe = state[1];
            aba = state[0];

            for (int round = startRound; round < Rounds; round += 2)
            {
                // prepareTheta
                bCa = aba ^ aga ^ aka ^ ama ^ asa;
                bCe = abe ^ age ^ ake ^ ame ^ ase;
                bCi = abi ^ agi ^ aki ^ ami ^ asi;
                bCo = abo ^ ago ^ ako ^ amo ^ aso;
                bCu = abu ^ agu ^ aku ^ amu ^ asu;

                // thetaRhoPiChiIotaPrepareTheta(round, A, E)
                da = bCu ^ BitOperations.RotateLeft(bCe, 1);
                de = bCa ^ BitOperations.RotateLeft(bCi, 1);
                di = bCe ^ BitOperations.RotateLeft(bCo, 1);
                @do = bCi ^ BitOperations.RotateLeft(bCu, 1);
                du = bCo ^ BitOperations.RotateLeft(bCa, 1);

                bCa = aba ^ da;
                bCe = BitOperations.RotateLeft(age ^ de, 44);
                bCi = BitOperations.RotateLeft(aki ^ di, 43);
                eba = bCa ^ ((~bCe) & bCi) ^ RoundConstants[round];
                bCo = BitOperations.RotateLeft(amo ^ @do, 21);
                ebe = bCe ^ ((~bCi) & bCo);
                bCu = BitOperations.RotateLeft(asu ^ du, 14);
                ebi = bCi ^ ((~bCo) & bCu);
                ebo = bCo ^ ((~bCu) & bCa);
                ebu = bCu ^ ((~bCa) & bCe);

                bCa = BitOperations.RotateLeft(abo ^ @do, 28);
                bCe = BitOperations.RotateLeft(agu ^ du, 20);
                bCi = BitOperations.RotateLeft(aka ^ da, 3);
                ega = bCa ^ ((~bCe) & bCi);
                bCo = BitOperations.RotateLeft(ame ^ de, 45);
                ege = bCe ^ ((~bCi) & bCo);
                bCu = BitOperations.RotateLeft(asi ^ di, 61);
                egi = bCi ^ ((~bCo) & bCu);
                ego = bCo ^ ((~bCu) & bCa);
                egu = bCu ^ ((~bCa) & bCe);

                bCa = BitOperations.RotateLeft(abe ^ de, 1);
                bCe = BitOperations.RotateLeft(agi ^ di, 6);
                bCi = BitOperations.RotateLeft(ako ^ @do, 25);
                eka = bCa ^ ((~bCe) & bCi);
                bCo = BitOperations.RotateLeft(amu ^ du, 8);
                eke = bCe ^ ((~bCi) & bCo);
                bCu = BitOperations.RotateLeft(asa ^ da, 18);
                eki = bCi ^ ((~bCo) & bCu);
                eko = bCo ^ ((~bCu) & bCa);
                eku = bCu ^ ((~bCa) & bCe);

                bCa = BitOperations.RotateLeft(abu ^ du, 27);
                bCe = BitOperations.RotateLeft(aga ^ da, 36);
                bCi = BitOperations.RotateLeft(ake ^ de, 10);
                ema = bCa ^ ((~bCe) & bCi);
                bCo = BitOperations.RotateLeft(ami ^ di, 15);
                eme = bCe ^ ((~bCi) & bCo);
                bCu = BitOperations.RotateLeft(aso ^ @do, 56);
                emi = bCi ^ ((~bCo) & bCu);
                emo = bCo ^ ((~bCu) & bCa);
                emu = bCu ^ ((~bCa) & bCe);

                bCa = BitOperations.RotateLeft(abi ^ di, 62);
                bCe = BitOperations.RotateLeft(ago ^ @do, 55);
                bCi = BitOperations.RotateLeft(aku ^ du, 39);
                esa = bCa ^ ((~bCe) & bCi);
                bCo = BitOperations.RotateLeft(ama ^ da, 41);
                ese = bCe ^ ((~bCi) & bCo);
                bCu = BitOperations.RotateLeft(ase ^ de, 2);
                esi = bCi ^ ((~bCo) & bCu);
                eso = bCo ^ ((~bCu) & bCa);
                esu = bCu ^ ((~bCa) & bCe);

                // prepareTheta
                bCe = ebe ^ ege ^ eke ^ eme ^ ese;
                bCu = ebu ^ egu ^ eku ^ emu ^ esu;

                // thetaRhoPiChiIotaPrepareTheta(round+1, E, A)
                da = bCu ^ BitOperations.RotateLeft(bCe, 1);
                bCa = eba ^ ega ^ eka ^ ema ^ esa;
                bCi = ebi ^ egi ^ eki ^ emi ^ esi;
                de = bCa ^ BitOperations.RotateLeft(bCi, 1);
                bCo = ebo ^ ego ^ eko ^ emo ^ eso;
                di = bCe ^ BitOperations.RotateLeft(bCo, 1);
                @do = bCi ^ BitOperations.RotateLeft(bCu, 1);
                du = bCo ^ BitOperations.RotateLeft(bCa, 1);

                bCi = BitOperations.RotateLeft(eki ^ di, 43);
                bCe = BitOperations.RotateLeft(ege ^ de, 44);
                bCa = eba ^ da;
                aba = bCa ^ ((~bCe) & bCi) ^ RoundConstants[round + 1];
                bCo = BitOperations.RotateLeft(emo ^ @do, 21);
                abe = bCe ^ ((~bCi) & bCo);
                bCu = BitOperations.RotateLeft(esu ^ du, 14);
                abi = bCi ^ ((~bCo) & bCu);
                abo = bCo ^ ((~bCu) & bCa);
                abu = bCu ^ ((~bCa) & bCe);

                bCa = BitOperations.RotateLeft(ebo ^ @do, 28);
                bCe = BitOperations.RotateLeft(egu ^ du, 20);
                bCi = BitOperations.RotateLeft(eka ^ da, 3);
                aga = bCa ^ ((~bCe) & bCi);
                bCo = BitOperations.RotateLeft(eme ^ de, 45);
                age = bCe ^ ((~bCi) & bCo);
                bCu = BitOperations.RotateLeft(esi ^ di, 61);
                agi = bCi ^ ((~bCo) & bCu);
                ago = bCo ^ ((~bCu) & bCa);
                agu = bCu ^ ((~bCa) & bCe);

                bCa = BitOperations.RotateLeft(ebe ^ de, 1);
                bCe = BitOperations.RotateLeft(egi ^ di, 6);
                bCi = BitOperations.RotateLeft(eko ^ @do, 25);
                aka = bCa ^ ((~bCe) & bCi);
                bCo = BitOperations.RotateLeft(emu ^ du, 8);
                ake = bCe ^ ((~bCi) & bCo);
                bCu = BitOperations.RotateLeft(esa ^ da, 18);
                aki = bCi ^ ((~bCo) & bCu);
                ako = bCo ^ ((~bCu) & bCa);
                aku = bCu ^ ((~bCa) & bCe);

                bCa = BitOperations.RotateLeft(ebu ^ du, 27);
                bCe = BitOperations.RotateLeft(ega ^ da, 36);
                bCi = BitOperations.RotateLeft(eke ^ de, 10);
                ama = bCa ^ ((~bCe) & bCi);
                bCo = BitOperations.RotateLeft(emi ^ di, 15);
                ame = bCe ^ ((~bCi) & bCo);
                bCu = BitOperations.RotateLeft(eso ^ @do, 56);
                ami = bCi ^ ((~bCo) & bCu);
                amo = bCo ^ ((~bCu) & bCa);
                amu = bCu ^ ((~bCa) & bCe);

                bCa = BitOperations.RotateLeft(ebi ^ di, 62);
                bCe = BitOperations.RotateLeft(ego ^ @do, 55);
                bCi = BitOperations.RotateLeft(eku ^ du, 39);
                asa = bCa ^ ((~bCe) & bCi);
                bCo = BitOperations.RotateLeft(ema ^ da, 41);
                ase = bCe ^ ((~bCi) & bCo);
                bCu = BitOperations.RotateLeft(ese ^ de, 2);
                asi = bCi ^ ((~bCo) & bCu);
                aso = bCo ^ ((~bCu) & bCa);
                asu = bCu ^ ((~bCa) & bCe);
            }

            //copyToState(state, A)
            state[24] = asu;
            state[23] = aso;
            state[22] = asi;
            state[21] = ase;
            state[20] = asa;
            state[19] = amu;
            state[18] = amo;
            state[17] = ami;
            state[16] = ame;
            state[15] = ama;
            state[14] = aku;
            state[13] = ako;
            state[12] = aki;
            state[11] = ake;
            state[10] = aka;
            state[9] = agu;
            state[8] = ago;
            state[7] = agi;
            state[6] = age;
            state[5] = aga;
            state[4] = abu;
            state[3] = abo;
            state[2] = abi;
            state[1] = abe;
            state[0] = aba;
        }
    }

    /// <summary>
    /// Absorbs a block of data into the Keccak state with explicit SIMD control.
    /// </summary>
    /// <param name="block">The block to absorb (must be exactly rateBytes long).</param>
    /// <param name="rateBytes">The rate in bytes (determines how many bytes to XOR).</param>
    /// <param name="startRound">The starting round for the permutation (default 0). Use 12 for TurboSHAKE.</param>
    [MethodImpl(MethodImplOptionsEx.OptimizedLoop)]
    public void Absorb(ReadOnlySpan<byte> block, int rateBytes, int startRound = 0)
    {
        int rateLanes = rateBytes / 8;
        Debug.Assert(rateLanes <= StateSize);

        fixed (ulong* statePtr = _state)
        {
            if (BitConverter.IsLittleEndian)
            {
                // Fast path: direct memory XOR on little-endian systems
                ReadOnlySpan<ulong> blockLanes = MemoryMarshal.Cast<byte, ulong>(block.Slice(0, rateLanes * 8));
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
                    statePtr[i] ^= BinaryPrimitives.ReadUInt64LittleEndian(block.Slice(i * 8));
                }
            }
        }

        Permute(startRound);
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
    /// <param name="startRound">The starting round for the permutation (default 0). Use 12 for TurboSHAKE.</param>
    [MethodImpl(MethodImplOptionsEx.OptimizedLoop)]
    public void SqueezeXof(Span<byte> output, int rateBytes, ref int squeezeOffset, int startRound = 0)
    {
        int outputOffset = 0;

        fixed (ulong* statePtr = _state)
        {
            while (outputOffset < output.Length)
            {
                if (squeezeOffset >= rateBytes)
                {
                    Permute(startRound);
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
