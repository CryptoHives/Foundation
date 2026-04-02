// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Security.Cryptography.Hash;

#if NET8_0_OR_GREATER

using System;
using System.Buffers.Binary;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Intrinsics;
using System.Runtime.Intrinsics.Arm;

using ArmSha256 = System.Runtime.Intrinsics.Arm.Sha256;

/// <summary>
/// ARM SHA-256 cryptographic extension hardware-accelerated compression function.
/// </summary>
/// <remarks>
/// <para>
/// Uses ARM SHA-256 instructions (SHA256H, SHA256H2, SHA256SU0, SHA256SU1) to
/// process 4 rounds per instruction pair, providing approximately 4–6× throughput
/// improvement over the scalar implementation on ARM cores with crypto extensions.
/// </para>
/// <para>
/// The ARM SHA-256 instructions operate on pairs of state vectors:
/// <list type="bullet">
///   <item><description><c>HashUpdate1(abcd, efgh, wk)</c> — SHA256H: 2 rounds updating abcd</description></item>
///   <item><description><c>HashUpdate2(efgh, abcd, wk)</c> — SHA256H2: 2 rounds updating efgh</description></item>
///   <item><description><c>ScheduleUpdate0(w0_3, w4_7)</c> — SHA256SU0: σ₀ message schedule</description></item>
///   <item><description><c>ScheduleUpdate1(w0_3, w8_11, w12_15)</c> — SHA256SU1: σ₁ message schedule</description></item>
/// </list>
/// </para>
/// </remarks>
internal static partial class SHA256Core
{
    /// <summary>
    /// Byte-reversal mask for converting little-endian to big-endian within each 32-bit lane.
    /// </summary>
    private static readonly Vector128<byte> WordByteSwapMask = Vector128.Create(
        (byte)3, 2, 1, 0, 7, 6, 5, 4, 11, 10, 9, 8, 15, 14, 13, 12);

    /// <summary>
    /// Gets whether ARM SHA-256 hardware acceleration is available on the current platform.
    /// </summary>
    internal static bool IsArmSha256Supported
    {
        get => ArmSha256.IsSupported;
    }

    /// <summary>
    /// Processes a single 64-byte block using ARM SHA-256 crypto extensions.
    /// </summary>
    /// <param name="block">The 64-byte block to process.</param>
    /// <param name="state">The 8-element state array to update.</param>
    [SkipLocalsInit]
    [MethodImpl(MethodImplOptionsEx.OptimizedLoop)]
    internal static void ProcessBlockArm(ReadOnlySpan<byte> block, Span<uint> state)
    {
        // Load state into two Vector128<uint>: abcd = state[0..3], efgh = state[4..7]
        ref uint stateRef = ref MemoryMarshal.GetReference(state);
        var abcd = Vector128.LoadUnsafe(ref stateRef);
        var efgh = Vector128.LoadUnsafe(ref stateRef, 4);

        // Save original state for final addition
        var abcdOrig = abcd;
        var efghOrig = efgh;

        // Load and byte-swap message words (SHA-256 uses big-endian input).
        // ARM64 is little-endian, so we reverse bytes within each 32-bit lane.
        ref byte blockRef = ref MemoryMarshal.GetReference(block);
        var w0 = Vector128.Shuffle(Vector128.LoadUnsafe(ref blockRef), WordByteSwapMask).AsUInt32();
        var w1 = Vector128.Shuffle(Vector128.LoadUnsafe(ref blockRef, 16), WordByteSwapMask).AsUInt32();
        var w2 = Vector128.Shuffle(Vector128.LoadUnsafe(ref blockRef, 32), WordByteSwapMask).AsUInt32();
        var w3 = Vector128.Shuffle(Vector128.LoadUnsafe(ref blockRef, 48), WordByteSwapMask).AsUInt32();

        // Rounds 0–3
        var wk = AdvSimd.Add(w0, Vector128.LoadUnsafe(ref MemoryMarshal.GetArrayDataReference(K)).AsUInt32());
        var tmp = abcd;
        abcd = ArmSha256.HashUpdate1(abcd, efgh, wk);
        efgh = ArmSha256.HashUpdate2(efgh, tmp, wk);

        // Rounds 4–7
        w0 = ArmSha256.ScheduleUpdate0(w0, w1);
        w0 = ArmSha256.ScheduleUpdate1(w0, w2, w3);
        wk = AdvSimd.Add(w1, Vector128.LoadUnsafe(ref MemoryMarshal.GetArrayDataReference(K), 4).AsUInt32());
        tmp = abcd;
        abcd = ArmSha256.HashUpdate1(abcd, efgh, wk);
        efgh = ArmSha256.HashUpdate2(efgh, tmp, wk);

        // Rounds 8–11
        w1 = ArmSha256.ScheduleUpdate0(w1, w2);
        w1 = ArmSha256.ScheduleUpdate1(w1, w3, w0);
        wk = AdvSimd.Add(w2, Vector128.LoadUnsafe(ref MemoryMarshal.GetArrayDataReference(K), 8).AsUInt32());
        tmp = abcd;
        abcd = ArmSha256.HashUpdate1(abcd, efgh, wk);
        efgh = ArmSha256.HashUpdate2(efgh, tmp, wk);

        // Rounds 12–15
        w2 = ArmSha256.ScheduleUpdate0(w2, w3);
        w2 = ArmSha256.ScheduleUpdate1(w2, w0, w1);
        wk = AdvSimd.Add(w3, Vector128.LoadUnsafe(ref MemoryMarshal.GetArrayDataReference(K), 12).AsUInt32());
        tmp = abcd;
        abcd = ArmSha256.HashUpdate1(abcd, efgh, wk);
        efgh = ArmSha256.HashUpdate2(efgh, tmp, wk);

        // Rounds 16–19
        w3 = ArmSha256.ScheduleUpdate0(w3, w0);
        w3 = ArmSha256.ScheduleUpdate1(w3, w1, w2);
        wk = AdvSimd.Add(w0, Vector128.LoadUnsafe(ref MemoryMarshal.GetArrayDataReference(K), 16).AsUInt32());
        tmp = abcd;
        abcd = ArmSha256.HashUpdate1(abcd, efgh, wk);
        efgh = ArmSha256.HashUpdate2(efgh, tmp, wk);

        // Rounds 20–23
        w0 = ArmSha256.ScheduleUpdate0(w0, w1);
        w0 = ArmSha256.ScheduleUpdate1(w0, w2, w3);
        wk = AdvSimd.Add(w1, Vector128.LoadUnsafe(ref MemoryMarshal.GetArrayDataReference(K), 20).AsUInt32());
        tmp = abcd;
        abcd = ArmSha256.HashUpdate1(abcd, efgh, wk);
        efgh = ArmSha256.HashUpdate2(efgh, tmp, wk);

        // Rounds 24–27
        w1 = ArmSha256.ScheduleUpdate0(w1, w2);
        w1 = ArmSha256.ScheduleUpdate1(w1, w3, w0);
        wk = AdvSimd.Add(w2, Vector128.LoadUnsafe(ref MemoryMarshal.GetArrayDataReference(K), 24).AsUInt32());
        tmp = abcd;
        abcd = ArmSha256.HashUpdate1(abcd, efgh, wk);
        efgh = ArmSha256.HashUpdate2(efgh, tmp, wk);

        // Rounds 28–31
        w2 = ArmSha256.ScheduleUpdate0(w2, w3);
        w2 = ArmSha256.ScheduleUpdate1(w2, w0, w1);
        wk = AdvSimd.Add(w3, Vector128.LoadUnsafe(ref MemoryMarshal.GetArrayDataReference(K), 28).AsUInt32());
        tmp = abcd;
        abcd = ArmSha256.HashUpdate1(abcd, efgh, wk);
        efgh = ArmSha256.HashUpdate2(efgh, tmp, wk);

        // Rounds 32–35
        w3 = ArmSha256.ScheduleUpdate0(w3, w0);
        w3 = ArmSha256.ScheduleUpdate1(w3, w1, w2);
        wk = AdvSimd.Add(w0, Vector128.LoadUnsafe(ref MemoryMarshal.GetArrayDataReference(K), 32).AsUInt32());
        tmp = abcd;
        abcd = ArmSha256.HashUpdate1(abcd, efgh, wk);
        efgh = ArmSha256.HashUpdate2(efgh, tmp, wk);

        // Rounds 36–39
        w0 = ArmSha256.ScheduleUpdate0(w0, w1);
        w0 = ArmSha256.ScheduleUpdate1(w0, w2, w3);
        wk = AdvSimd.Add(w1, Vector128.LoadUnsafe(ref MemoryMarshal.GetArrayDataReference(K), 36).AsUInt32());
        tmp = abcd;
        abcd = ArmSha256.HashUpdate1(abcd, efgh, wk);
        efgh = ArmSha256.HashUpdate2(efgh, tmp, wk);

        // Rounds 40–43
        w1 = ArmSha256.ScheduleUpdate0(w1, w2);
        w1 = ArmSha256.ScheduleUpdate1(w1, w3, w0);
        wk = AdvSimd.Add(w2, Vector128.LoadUnsafe(ref MemoryMarshal.GetArrayDataReference(K), 40).AsUInt32());
        tmp = abcd;
        abcd = ArmSha256.HashUpdate1(abcd, efgh, wk);
        efgh = ArmSha256.HashUpdate2(efgh, tmp, wk);

        // Rounds 44–47
        w2 = ArmSha256.ScheduleUpdate0(w2, w3);
        w2 = ArmSha256.ScheduleUpdate1(w2, w0, w1);
        wk = AdvSimd.Add(w3, Vector128.LoadUnsafe(ref MemoryMarshal.GetArrayDataReference(K), 44).AsUInt32());
        tmp = abcd;
        abcd = ArmSha256.HashUpdate1(abcd, efgh, wk);
        efgh = ArmSha256.HashUpdate2(efgh, tmp, wk);

        // Rounds 48–51 (last rounds with message schedule expansion)
        w3 = ArmSha256.ScheduleUpdate0(w3, w0);
        w3 = ArmSha256.ScheduleUpdate1(w3, w1, w2);
        wk = AdvSimd.Add(w0, Vector128.LoadUnsafe(ref MemoryMarshal.GetArrayDataReference(K), 48).AsUInt32());
        tmp = abcd;
        abcd = ArmSha256.HashUpdate1(abcd, efgh, wk);
        efgh = ArmSha256.HashUpdate2(efgh, tmp, wk);

        // Rounds 52–55 (no more schedule updates needed after round 48)
        wk = AdvSimd.Add(w1, Vector128.LoadUnsafe(ref MemoryMarshal.GetArrayDataReference(K), 52).AsUInt32());
        tmp = abcd;
        abcd = ArmSha256.HashUpdate1(abcd, efgh, wk);
        efgh = ArmSha256.HashUpdate2(efgh, tmp, wk);

        // Rounds 56–59
        wk = AdvSimd.Add(w2, Vector128.LoadUnsafe(ref MemoryMarshal.GetArrayDataReference(K), 56).AsUInt32());
        tmp = abcd;
        abcd = ArmSha256.HashUpdate1(abcd, efgh, wk);
        efgh = ArmSha256.HashUpdate2(efgh, tmp, wk);

        // Rounds 60–63
        wk = AdvSimd.Add(w3, Vector128.LoadUnsafe(ref MemoryMarshal.GetArrayDataReference(K), 60).AsUInt32());
        tmp = abcd;
        abcd = ArmSha256.HashUpdate1(abcd, efgh, wk);
        efgh = ArmSha256.HashUpdate2(efgh, tmp, wk);

        // Add original state
        abcd = AdvSimd.Add(abcd, abcdOrig);
        efgh = AdvSimd.Add(efgh, efghOrig);

        // Store back to state
        abcd.CopyTo(state);
        efgh.CopyTo(state.Slice(4));
    }
}

#endif
