// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Security.Cryptography.Hash;

#pragma warning disable IDE1006 // Naming rule violation - ArmSha1 alias name

#if NET8_0_OR_GREATER

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Intrinsics;
using System.Runtime.Intrinsics.Arm;

using ArmSha1 = System.Runtime.Intrinsics.Arm.Sha1;

/// <summary>
/// ARM SHA-1 cryptographic extension hardware-accelerated compression function.
/// </summary>
/// <remarks>
/// Uses ARM SHA-1 instructions (SHA1C, SHA1P, SHA1M, SHA1H, SHA1SU0, SHA1SU1) to
/// process 4 rounds per instruction, mirroring the reference round/message-schedule
/// chaining pattern used by every public ARMv8 SHA-1 implementation (e.g.
/// <c>sha1_process_arm</c> in noloader/SHA-Intrinsics): each 4-round group derives
/// its "e" input from <c>FixedRotate</c> of the previous group's "a" before that
/// group's hash update overwrites it, and alternates two message-schedule
/// accumulators (<c>TMP0</c>/<c>TMP1</c>) one group ahead of the hash update that
/// consumes them.
/// </remarks>

partial class SHA1
{
    private static readonly Vector128<byte> WordByteSwapMask = Vector128.Create(
        (byte)3, 2, 1, 0, 7, 6, 5, 4, 11, 10, 9, 8, 15, 14, 13, 12);

    private static readonly Vector128<uint> K0 = Vector128.Create(0x5A827999u);
    private static readonly Vector128<uint> K1 = Vector128.Create(0x6ED9EBA1u);
    private static readonly Vector128<uint> K2 = Vector128.Create(0x8F1BBCDCu);
    private static readonly Vector128<uint> K3 = Vector128.Create(0xCA62C1D6u);

    /// <summary>
    /// Gets whether ARM SHA-1 hardware acceleration is available on the current platform.
    /// </summary>
    internal static bool IsArmSha1Supported => ArmSha1.IsSupported;

    /// <summary>
    /// Processes a single 64-byte block using ARM SHA-1 crypto extensions.
    /// </summary>
    [SkipLocalsInit]
    [MethodImpl(MethodImplOptionsEx.OptimizedLoop)]
    private static void ProcessBlockArm(ReadOnlySpan<byte> block, Span<uint> state)
    {
        // Both spans are read through raw refs below, so their sizes are a precondition
        // rather than something the loads check.
        Debug.Assert(block.Length >= BlockSizeBytes, "SHA-1 ARM block must be a full block");
        Debug.Assert(state.Length >= 5, "SHA-1 ARM state must hold the full chaining value");

        ref uint stateRef = ref MemoryMarshal.GetReference(state);
        var abcdSaved = Vector128.LoadUnsafe(ref stateRef);
        uint e0Saved = Unsafe.Add(ref stateRef, 4);
        var abcd = abcdSaved;
        uint e0 = e0Saved;
        uint e1;

        ref byte blockRef = ref MemoryMarshal.GetReference(block);
        var msg0 = Vector128.Shuffle(Vector128.LoadUnsafe(ref blockRef), WordByteSwapMask).AsUInt32();
        var msg1 = Vector128.Shuffle(Vector128.LoadUnsafe(ref blockRef, 16), WordByteSwapMask).AsUInt32();
        var msg2 = Vector128.Shuffle(Vector128.LoadUnsafe(ref blockRef, 32), WordByteSwapMask).AsUInt32();
        var msg3 = Vector128.Shuffle(Vector128.LoadUnsafe(ref blockRef, 48), WordByteSwapMask).AsUInt32();

        var tmp0 = AdvSimd.Add(msg0, K0);
        var tmp1 = AdvSimd.Add(msg1, K0);

        // Rounds 0-3
        e1 = ArmSha1.FixedRotate(Vector64.CreateScalar(abcd.GetElement(0))).ToScalar();
        abcd = ArmSha1.HashUpdateChoose(abcd, Vector64.CreateScalar(e0), tmp0);
        tmp0 = AdvSimd.Add(msg2, K0);
        msg0 = ArmSha1.ScheduleUpdate0(msg0, msg1, msg2);

        // Rounds 4-7
        e0 = ArmSha1.FixedRotate(Vector64.CreateScalar(abcd.GetElement(0))).ToScalar();
        abcd = ArmSha1.HashUpdateChoose(abcd, Vector64.CreateScalar(e1), tmp1);
        tmp1 = AdvSimd.Add(msg3, K0);
        msg0 = ArmSha1.ScheduleUpdate1(msg0, msg3);
        msg1 = ArmSha1.ScheduleUpdate0(msg1, msg2, msg3);

        // Rounds 8-11
        e1 = ArmSha1.FixedRotate(Vector64.CreateScalar(abcd.GetElement(0))).ToScalar();
        abcd = ArmSha1.HashUpdateChoose(abcd, Vector64.CreateScalar(e0), tmp0);
        tmp0 = AdvSimd.Add(msg0, K0);
        msg1 = ArmSha1.ScheduleUpdate1(msg1, msg0);
        msg2 = ArmSha1.ScheduleUpdate0(msg2, msg3, msg0);

        // Rounds 12-15
        e0 = ArmSha1.FixedRotate(Vector64.CreateScalar(abcd.GetElement(0))).ToScalar();
        abcd = ArmSha1.HashUpdateChoose(abcd, Vector64.CreateScalar(e1), tmp1);
        tmp1 = AdvSimd.Add(msg1, K1);
        msg2 = ArmSha1.ScheduleUpdate1(msg2, msg1);
        msg3 = ArmSha1.ScheduleUpdate0(msg3, msg0, msg1);

        // Rounds 16-19
        e1 = ArmSha1.FixedRotate(Vector64.CreateScalar(abcd.GetElement(0))).ToScalar();
        abcd = ArmSha1.HashUpdateChoose(abcd, Vector64.CreateScalar(e0), tmp0);
        tmp0 = AdvSimd.Add(msg2, K1);
        msg3 = ArmSha1.ScheduleUpdate1(msg3, msg2);
        msg0 = ArmSha1.ScheduleUpdate0(msg0, msg1, msg2);

        // Rounds 20-23
        e0 = ArmSha1.FixedRotate(Vector64.CreateScalar(abcd.GetElement(0))).ToScalar();
        abcd = ArmSha1.HashUpdateParity(abcd, Vector64.CreateScalar(e1), tmp1);
        tmp1 = AdvSimd.Add(msg3, K1);
        msg0 = ArmSha1.ScheduleUpdate1(msg0, msg3);
        msg1 = ArmSha1.ScheduleUpdate0(msg1, msg2, msg3);

        // Rounds 24-27
        e1 = ArmSha1.FixedRotate(Vector64.CreateScalar(abcd.GetElement(0))).ToScalar();
        abcd = ArmSha1.HashUpdateParity(abcd, Vector64.CreateScalar(e0), tmp0);
        tmp0 = AdvSimd.Add(msg0, K1);
        msg1 = ArmSha1.ScheduleUpdate1(msg1, msg0);
        msg2 = ArmSha1.ScheduleUpdate0(msg2, msg3, msg0);

        // Rounds 28-31
        e0 = ArmSha1.FixedRotate(Vector64.CreateScalar(abcd.GetElement(0))).ToScalar();
        abcd = ArmSha1.HashUpdateParity(abcd, Vector64.CreateScalar(e1), tmp1);
        tmp1 = AdvSimd.Add(msg1, K1);
        msg2 = ArmSha1.ScheduleUpdate1(msg2, msg1);
        msg3 = ArmSha1.ScheduleUpdate0(msg3, msg0, msg1);

        // Rounds 32-35
        e1 = ArmSha1.FixedRotate(Vector64.CreateScalar(abcd.GetElement(0))).ToScalar();
        abcd = ArmSha1.HashUpdateParity(abcd, Vector64.CreateScalar(e0), tmp0);
        tmp0 = AdvSimd.Add(msg2, K2);
        msg3 = ArmSha1.ScheduleUpdate1(msg3, msg2);
        msg0 = ArmSha1.ScheduleUpdate0(msg0, msg1, msg2);

        // Rounds 36-39
        e0 = ArmSha1.FixedRotate(Vector64.CreateScalar(abcd.GetElement(0))).ToScalar();
        abcd = ArmSha1.HashUpdateParity(abcd, Vector64.CreateScalar(e1), tmp1);
        tmp1 = AdvSimd.Add(msg3, K2);
        msg0 = ArmSha1.ScheduleUpdate1(msg0, msg3);
        msg1 = ArmSha1.ScheduleUpdate0(msg1, msg2, msg3);

        // Rounds 40-43
        e1 = ArmSha1.FixedRotate(Vector64.CreateScalar(abcd.GetElement(0))).ToScalar();
        abcd = ArmSha1.HashUpdateMajority(abcd, Vector64.CreateScalar(e0), tmp0);
        tmp0 = AdvSimd.Add(msg0, K2);
        msg1 = ArmSha1.ScheduleUpdate1(msg1, msg0);
        msg2 = ArmSha1.ScheduleUpdate0(msg2, msg3, msg0);

        // Rounds 44-47
        e0 = ArmSha1.FixedRotate(Vector64.CreateScalar(abcd.GetElement(0))).ToScalar();
        abcd = ArmSha1.HashUpdateMajority(abcd, Vector64.CreateScalar(e1), tmp1);
        tmp1 = AdvSimd.Add(msg1, K2);
        msg2 = ArmSha1.ScheduleUpdate1(msg2, msg1);
        msg3 = ArmSha1.ScheduleUpdate0(msg3, msg0, msg1);

        // Rounds 48-51
        e1 = ArmSha1.FixedRotate(Vector64.CreateScalar(abcd.GetElement(0))).ToScalar();
        abcd = ArmSha1.HashUpdateMajority(abcd, Vector64.CreateScalar(e0), tmp0);
        tmp0 = AdvSimd.Add(msg2, K2);
        msg3 = ArmSha1.ScheduleUpdate1(msg3, msg2);
        msg0 = ArmSha1.ScheduleUpdate0(msg0, msg1, msg2);

        // Rounds 52-55
        e0 = ArmSha1.FixedRotate(Vector64.CreateScalar(abcd.GetElement(0))).ToScalar();
        abcd = ArmSha1.HashUpdateMajority(abcd, Vector64.CreateScalar(e1), tmp1);
        tmp1 = AdvSimd.Add(msg3, K3);
        msg0 = ArmSha1.ScheduleUpdate1(msg0, msg3);
        msg1 = ArmSha1.ScheduleUpdate0(msg1, msg2, msg3);

        // Rounds 56-59
        e1 = ArmSha1.FixedRotate(Vector64.CreateScalar(abcd.GetElement(0))).ToScalar();
        abcd = ArmSha1.HashUpdateMajority(abcd, Vector64.CreateScalar(e0), tmp0);
        tmp0 = AdvSimd.Add(msg0, K3);
        msg1 = ArmSha1.ScheduleUpdate1(msg1, msg0);
        msg2 = ArmSha1.ScheduleUpdate0(msg2, msg3, msg0);

        // Rounds 60-63
        e0 = ArmSha1.FixedRotate(Vector64.CreateScalar(abcd.GetElement(0))).ToScalar();
        abcd = ArmSha1.HashUpdateParity(abcd, Vector64.CreateScalar(e1), tmp1);
        tmp1 = AdvSimd.Add(msg1, K3);
        msg2 = ArmSha1.ScheduleUpdate1(msg2, msg1);
        msg3 = ArmSha1.ScheduleUpdate0(msg3, msg0, msg1);

        // Rounds 64-67
        e1 = ArmSha1.FixedRotate(Vector64.CreateScalar(abcd.GetElement(0))).ToScalar();
        abcd = ArmSha1.HashUpdateParity(abcd, Vector64.CreateScalar(e0), tmp0);
        tmp0 = AdvSimd.Add(msg2, K3);
        msg3 = ArmSha1.ScheduleUpdate1(msg3, msg2);
        msg0 = ArmSha1.ScheduleUpdate0(msg0, msg1, msg2);

        // Rounds 68-71
        e0 = ArmSha1.FixedRotate(Vector64.CreateScalar(abcd.GetElement(0))).ToScalar();
        abcd = ArmSha1.HashUpdateParity(abcd, Vector64.CreateScalar(e1), tmp1);
        tmp1 = AdvSimd.Add(msg3, K3);
        msg0 = ArmSha1.ScheduleUpdate1(msg0, msg3);

        // Rounds 72-75 (no more schedule updates needed after round 68)
        e1 = ArmSha1.FixedRotate(Vector64.CreateScalar(abcd.GetElement(0))).ToScalar();
        abcd = ArmSha1.HashUpdateParity(abcd, Vector64.CreateScalar(e0), tmp0);

        // Rounds 76-79
        e0 = ArmSha1.FixedRotate(Vector64.CreateScalar(abcd.GetElement(0))).ToScalar();
        abcd = ArmSha1.HashUpdateParity(abcd, Vector64.CreateScalar(e1), tmp1);

        e0 += e0Saved;
        abcd = AdvSimd.Add(abcdSaved, abcd);

        abcd.CopyTo(state);
        Unsafe.Add(ref stateRef, 4) = e0;
    }
}

#endif
