// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace Cryptography.Tests.Hash;

using NUnit.Framework;
using System;
using System.Collections.Generic;

/// <summary>
/// Verifies that hashing the same bytes from a buffer that starts at a non-zero,
/// non-4-byte-aligned offset within its backing array produces the same result as
/// hashing a tight, zero-offset copy of those bytes.
/// </summary>
/// <remarks>
/// Several BLAKE3/BLAKE2 SIMD kernels read message bytes via raw unsafe pointer
/// casts and hardware-intrinsic vector loads directly against the caller-supplied
/// span. .NET on x86-64/ARM64 never faults on unaligned loads, so this test can't
/// find crashes — only a logic bug where the hash result depends on the input
/// buffer's memory offset rather than solely on its content.
/// </remarks>
[TestFixture]
[Parallelizable(ParallelScope.All)]
public class UnalignedInputTests
{
    /// <summary>
    /// Byte offsets into the backing array to start the hashed span at: 0 is the
    /// aligned baseline, the rest cover every remainder mod 8 except 6 (redundant
    /// with 2), so both 4-byte and 8-byte misalignment are exercised.
    /// </summary>
    private static readonly int[] Offsets = [0, 1, 2, 3, 4, 5, 7];

    /// <summary>
    /// Input sizes: zero-length and length=1 edge cases, generic 64/128-byte block
    /// boundaries for the non-BLAKE families, and BLAKE3's own SIMD batch
    /// thresholds (single chunk, partial-batch boundary, AVX2 8-chunk boundary,
    /// AVX512 16-chunk boundary, 64-chunk group boundary) reused from
    /// <c>Blake3Tests</c>.
    /// </summary>
    private static readonly int[] Sizes =
        [0, 1, 63, 64, 65, 1023, 1024, 1025, 2048, 2049, 8191, 8192, 8193, 16384, 16385, 65536];

    /// <summary>
    /// Verifies that every CryptoHives hash algorithm and SIMD tier produces an
    /// identical hash for the same bytes regardless of the input span's starting
    /// memory offset.
    /// </summary>
    /// <param name="factory">The hash algorithm factory under test.</param>
    [Test]
    [TestCaseSource(typeof(CryptoHivesManagedImplementations), nameof(CryptoHivesManagedImplementations.All))]
    public void UnalignedInputProducesSameHashAsAlignedInput(HashAlgorithmFactory factory)
    {
        using var algorithm = factory.Create();

        int maxOffset = Offsets[^1];
        int maxSize = Sizes[^1];
        byte[] backing = GenerateTestInput(maxOffset + maxSize);

        var failures = new List<string>();

        foreach (int offset in Offsets)
        {
            foreach (int size in Sizes)
            {
                byte[] unalignedHash = algorithm.ComputeHash(backing, offset, size);

                byte[] canonical = new byte[size];
                Array.Copy(backing, offset, canonical, 0, size);
                byte[] canonicalHash = algorithm.ComputeHash(canonical);

                if (!unalignedHash.AsSpan().SequenceEqual(canonicalHash))
                {
                    failures.Add($"offset={offset}, size={size}: " +
                        $"unaligned={TestHelpers.ToHexString(unalignedHash)} canonical={TestHelpers.ToHexString(canonicalHash)}");
                }
            }
        }

        Assert.That(failures, Is.Empty,
            () => $"{factory.Name}: {failures.Count} mismatch(es):\n" + string.Join("\n", failures));
    }

    /// <summary>
    /// Generates deterministic test input using the same pattern (index mod 251)
    /// used throughout the hash test suite.
    /// </summary>
    private static byte[] GenerateTestInput(int length)
    {
        byte[] input = new byte[length];
        for (int i = 0; i < length; i++)
        {
            input[i] = (byte)(i % 251);
        }
        return input;
    }
}
