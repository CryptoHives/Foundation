// SPDX-FileCopyrightText: 2025 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Security.Cryptography.Hash;

#if NET8_0_OR_GREATER

using System.Numerics;
using System.Runtime.CompilerServices;

/// <summary>
/// ARM64-optimized scalar Keccak-f[1600] permutation.
/// </summary>
internal unsafe partial struct KeccakCoreState
{
    /// <summary>
    /// ARM64-optimized scalar Keccak-f[1600] permutation (1 round per loop iteration,
    /// register-based state).
    /// </summary>
    /// <remarks>
    /// <para>
    /// All 25 state lanes are loaded into local variables before the loop and stored back
    /// after. Inside the loop every step — theta D-values, Pi+Rho, chi, iota — operates
    /// entirely on locals, eliminating the ~50 store/reload memory round-trips per round
    /// that the in-place theta pattern incurs.
    /// </para>
    /// <para>
    /// One round per loop iteration (vs. the 2-round unrolling in <see cref="PermuteScalar"/>)
    /// reduces peak live locals from ~57 to ~35, cutting register spills on ARM64's
    /// 31 GP registers.
    /// </para>
    /// <para>
    /// Register pressure is kept low by the <em>pre-save pattern</em>: each chi output
    /// row overwrites 5 state lanes; any lane that is also a source for a <em>later</em>
    /// chi row is rotated and saved before that earlier row executes. This ensures every
    /// B value is read from the post-theta state before it can be overwritten.
    /// </para>
    /// <para>
    /// Pi+Rho mapping (output index ← source index × rotation):<br/>
    /// row 0: [0]←[0]×0  [1]←[6]×44  [2]←[12]×43 [3]←[18]×21 [4]←[24]×14<br/>
    /// row 1: [5]←[3]×28 [6]←[9]×20  [7]←[10]×3  [8]←[16]×45 [9]←[22]×61<br/>
    /// row 2: [10]←[1]×1 [11]←[7]×6  [12]←[13]×25 [13]←[19]×8 [14]←[20]×18<br/>
    /// row 3: [15]←[4]×27 [16]←[5]×36 [17]←[11]×10 [18]←[17]×15 [19]←[23]×56<br/>
    /// row 4: [20]←[2]×62 [21]←[8]×55 [22]←[14]×39 [23]←[15]×41 [24]←[21]×2
    /// </para>
    /// </remarks>
    [SkipLocalsInit]
    [MethodImpl(MethodImplOptionsEx.OptimizedLoop)]
    private void PermuteScalarArm64()
    {
        ulong aba, abe, abi, abo, abu;
        ulong aga, age, agi, ago, agu;
        ulong aka, ake, aki, ako, aku;
        ulong ama, ame, ami, amo, amu;
        ulong asa, ase, asi, aso, asu;
        ulong ca, ce, ci, co, cu;
        ulong da, de, di, @do, du;
        ulong r1b0, r2b0, r3b0, r4b0;
        ulong r2b1, r3b1, r4b1;
        ulong r3b2, r4b2;
        ulong r4b3;

        fixed (ulong* s = _state)
        {
            aba = s[0]; abe = s[1]; abi = s[2]; abo = s[3]; abu = s[4];
            aga = s[5]; age = s[6]; agi = s[7]; ago = s[8]; agu = s[9];
            aka = s[10]; ake = s[11]; aki = s[12]; ako = s[13]; aku = s[14];
            ama = s[15]; ame = s[16]; ami = s[17]; amo = s[18]; amu = s[19];
            asa = s[20]; ase = s[21]; asi = s[22]; aso = s[23]; asu = s[24];

            for (int round = _startRound; round < Rounds; round++)
            {
                // ── Theta: column parities → D values ────────────────────────────────
                ce = abe ^ age ^ ake ^ ame ^ ase;
                cu = abu ^ agu ^ aku ^ amu ^ asu;
                da = cu ^ BitOperations.RotateLeft(ce, 1);
                co = abo ^ ago ^ ako ^ amo ^ aso;
                di = ce ^ BitOperations.RotateLeft(co, 1);
                ci = abi ^ agi ^ aki ^ ami ^ asi;
                @do = ci ^ BitOperations.RotateLeft(cu, 1);
                ca = aba ^ aga ^ aka ^ ama ^ asa;
                du = co ^ BitOperations.RotateLeft(ca, 1);
                de = ca ^ BitOperations.RotateLeft(ci, 1);

                // ── Pre-save B[0] for rows 1-4 (abo,abe,abu,abi are overwritten by chi row 0)
                r1b0 = BitOperations.RotateLeft(abo ^ @do, 28);
                r2b0 = BitOperations.RotateLeft(abe ^ de, 1);
                r3b0 = BitOperations.RotateLeft(abu ^ du, 27);
                r4b0 = BitOperations.RotateLeft(abi ^ di, 62);

                // ── Chi row 0 ─────────────────────────────────────────────────────────
                ca = aba ^ da;
                ce = BitOperations.RotateLeft(age ^ de, 44);
                ci = BitOperations.RotateLeft(aki ^ di, 43);
                aba = ca ^ (~ce & ci) ^ GetRoundConstants(round);
                co = BitOperations.RotateLeft(amo ^ @do, 21);
                abe = ce ^ (~ci & co);
                cu = BitOperations.RotateLeft(asu ^ du, 14);
                abu = cu ^ (~ca & ce);

                // ── Pre-save B[1] for rows 2-4 (agi,aga,ago are overwritten by chi row 1)
                r2b1 = BitOperations.RotateLeft(agi ^ di, 6);
                r3b1 = BitOperations.RotateLeft(aga ^ da, 36);
                r4b1 = BitOperations.RotateLeft(ago ^ @do, 55);

                abo = co ^ (~cu & ca);
                ce = BitOperations.RotateLeft(agu ^ du, 20);
                abi = ci ^ (~co & cu);

                // ── Chi row 1 ─────────────────────────────────────────────────────────
                ca = r1b0;
                ci = BitOperations.RotateLeft(aka ^ da, 3);
                aga = ca ^ (~ce & ci);
                co = BitOperations.RotateLeft(ame ^ de, 45);
                age = ce ^ (~ci & co);
                cu = BitOperations.RotateLeft(asi ^ di, 61);
                agu = cu ^ (~ca & ce);

                // ── Pre-save B[2] for rows 3-4 (ake,aku are overwritten by chi row 2) ──
                r3b2 = BitOperations.RotateLeft(ake ^ de, 10);
                r4b2 = BitOperations.RotateLeft(aku ^ du, 39);

                ago = co ^ (~cu & ca);
                ce = r2b1;
                agi = ci ^ (~co & cu);
                ca = r2b0;

                // ── Chi row 2 ─────────────────────────────────────────────────────────
                ci = BitOperations.RotateLeft(ako ^ @do, 25);
                aka = ca ^ (~ce & ci);
                co = BitOperations.RotateLeft(amu ^ du, 8);
                ake = ce ^ (~ci & co);
                cu = BitOperations.RotateLeft(asa ^ da, 18);
                aku = cu ^ (~ca & ce);

                // ── Pre-save B[3] for row 4 (ama is overwritten by chi row 3) ──────────
                r4b3 = BitOperations.RotateLeft(ama ^ da, 41);

                ako = co ^ (~cu & ca);
                ce = r3b1;
                aki = ci ^ (~co & cu);
                ca = r3b0;

                // ── Chi row 3 ─────────────────────────────────────────────────────────
                ci = r3b2;
                co = BitOperations.RotateLeft(ami ^ di, 15);
                ama = ca ^ (~ce & ci);
                cu = BitOperations.RotateLeft(aso ^ @do, 56);
                ame = ce ^ (~ci & co);
                amu = cu ^ (~ca & ce);
                amo = co ^ (~cu & ca);
                ce = r4b1;
                ami = ci ^ (~co & cu);
                ca = r4b0;

                // ── Chi row 4 ─────────────────────────────────────────────────────────
                ci = r4b2;
                co = r4b3;
                asa = ca ^ (~ce & ci);
                cu = BitOperations.RotateLeft(ase ^ de, 2);
                ase = ce ^ (~ci & co);
                asu = cu ^ (~ca & ce);
                aso = co ^ (~cu & ca);
                asi = ci ^ (~co & cu);
            }

            s[0] = aba; s[1] = abe; s[2] = abi; s[3] = abo; s[4] = abu;
            s[5] = aga; s[6] = age; s[7] = agi; s[8] = ago; s[9] = agu;
            s[10] = aka; s[11] = ake; s[12] = aki; s[13] = ako; s[14] = aku;
            s[15] = ama; s[16] = ame; s[17] = ami; s[18] = amo; s[19] = amu;
            s[20] = asa; s[21] = ase; s[22] = asi; s[23] = aso; s[24] = asu;
        }
    }
}

#endif
