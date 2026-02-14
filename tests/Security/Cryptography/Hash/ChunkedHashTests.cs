// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace Cryptography.Tests.Hash;

using NUnit.Framework;
using System;
using CryptoHivesHash = CryptoHives.Foundation.Security.Cryptography.Hash;

/// <summary>
/// Verifies that feeding data in random-sized chunks produces the same hash
/// as a single-shot computation. This exercises the internal block-buffering
/// logic across all boundary conditions (partial blocks, exact multiples,
/// cross-block spans, and empty chunks).
/// </summary>
[TestFixture]
[Parallelizable(ParallelScope.All)]
public class ChunkedHashTests
{
    /// <summary>
    /// Chunk-size strategies that stress different code paths in the block-buffering logic.
    /// </summary>
    private enum ChunkStrategy
    {
        /// <summary>Every chunk is a single byte (maximizes buffer fill/flush transitions).</summary>
        SingleByte,

        /// <summary>Random chunk sizes between 1 and 2× block size (hits all boundary cases).</summary>
        Random,

        /// <summary>Chunks exactly equal to the block size (no partial blocks until final).</summary>
        ExactBlock,

        /// <summary>Alternating between blockSize−1 and blockSize+1 (always straddles boundaries).</summary>
        Straddle,

        /// <summary>Feed the entire buffer in one chunk (baseline, same as single-shot).</summary>
        WholeBuffer,

        /// <summary>Every chunk is exactly two bytes (exercises frequent small-buffer fills).</summary>
        TwoBytes,

        /// <summary>Half-block sized chunks (splits every block into two halves).</summary>
        HalfBlock
    }

    private static readonly ChunkStrategy[] AllStrategies =
    [
        ChunkStrategy.SingleByte,
        ChunkStrategy.Random,
        ChunkStrategy.ExactBlock,
        ChunkStrategy.Straddle,
        ChunkStrategy.WholeBuffer,
        ChunkStrategy.TwoBytes,
        ChunkStrategy.HalfBlock
    ];

    /// <summary>
    /// Total input sizes chosen to exercise key edge cases relative to typical block sizes
    /// (64 and 128 bytes): zero, sub-block, exact block, multi-block, and large.
    /// </summary>
    private static readonly int[] InputSizes =
        [0, 1, 31, 63, 64, 65, 127, 128, 129, 255, 256, 1023, 1024, 1025, 4096, 8192];

    /// <summary>
    /// Verifies that chunked incremental hashing produces the same result as single-shot hashing
    /// for every CryptoHives algorithm, across multiple input sizes and chunking strategies.
    /// </summary>
    /// <param name="factory">The hash algorithm factory under test.</param>
    [Test]
    [TestCaseSource(typeof(CryptoHivesManagedImplementations), nameof(CryptoHivesManagedImplementations.All))]
    public void ChunkedHashMatchesSingleShot(HashAlgorithmFactory factory)
    {
        var dataRng = new Random(42);
        int blockSize = GetBlockSize(factory);

        foreach (int inputSize in InputSizes)
        {
            byte[] input = new byte[inputSize];
            if (inputSize > 0) dataRng.NextBytes(input);

            byte[] expected;
            using (var oneShot = (CryptoHivesHash.HashAlgorithm)factory.Create())
            {
                expected = oneShot.ComputeHash(input);
            }

            foreach (ChunkStrategy strategy in AllStrategies)
            {
                // Per-case seed ensures determinism independent of strategy enumeration order
                var chunkRng = new Random(inputSize * 31 + (int)strategy);
                byte[] actual = ComputeChunked(factory, input, blockSize, strategy, chunkRng);

                Assert.That(actual, Is.EqualTo(expected),
                    $"{factory.Name} | size={inputSize} | strategy={strategy}");
            }
        }
    }

    /// <summary>
    /// Verifies that inserting empty (zero-length) chunks between real data does not
    /// alter the hash result. This ensures implementations handle zero-length spans correctly.
    /// </summary>
    /// <param name="factory">The hash algorithm factory under test.</param>
    [Test]
    [TestCaseSource(typeof(CryptoHivesManagedImplementations), nameof(CryptoHivesManagedImplementations.All))]
    public void EmptyChunksDoNotAffectHash(HashAlgorithmFactory factory)
    {
        var rng = new Random(123);
        int blockSize = GetBlockSize(factory);
        byte[] input = new byte[blockSize * 3 + 7];
        rng.NextBytes(input);

        byte[] expected;
        using (var oneShot = (CryptoHivesHash.HashAlgorithm)factory.Create())
        {
            expected = oneShot.ComputeHash(input);
        }

        using var algo = factory.Create();
        int offset = 0;
        int chunkIndex = 0;

        while (offset < input.Length)
        {
            // Insert an empty chunk before every other real chunk
            if (chunkIndex % 2 == 0)
            {
                algo.TransformBlock(input, offset, 0, null, 0);
            }

            int remaining = input.Length - offset;
            int chunkSize = Math.Min(2 + rng.Next(blockSize), remaining);
            algo.TransformBlock(input, offset, chunkSize, null, 0);
            offset += chunkSize;
            chunkIndex++;
        }

        algo.TransformFinalBlock([], 0, 0);
        byte[] actual = algo.Hash!;

        Assert.That(actual, Is.EqualTo(expected),
            $"{factory.Name}: empty interleaved chunks altered the hash");
    }

    /// <summary>
    /// Verifies that the algorithm can be reset and reused, producing the same result
    /// when fed identical data with different chunking patterns across iterations.
    /// </summary>
    /// <param name="factory">The hash algorithm factory under test.</param>
    [Test]
    [TestCaseSource(typeof(CryptoHivesManagedImplementations), nameof(CryptoHivesManagedImplementations.All))]
    public void ReuseAfterResetProducesSameHash(HashAlgorithmFactory factory)
    {
        var rng = new Random(99);
        int blockSize = GetBlockSize(factory);
        byte[] input = new byte[blockSize * 4 + 13];
        rng.NextBytes(input);

        using var algo = (CryptoHivesHash.HashAlgorithm)factory.Create();
        byte[] expected = algo.ComputeHash(input);

        // Reuse with varying chunk sizes: ComputeHash calls Initialize internally
        int[] chunkSizes = [1, blockSize / 3 + 1, blockSize - 1, blockSize, blockSize + 1];

        for (int iteration = 0; iteration < chunkSizes.Length; iteration++)
        {
            byte[] actual = ComputeChunkedWithInstance(algo, input, chunkSizes[iteration]);

            Assert.That(actual, Is.EqualTo(expected),
                $"{factory.Name}: iteration {iteration} (chunk={chunkSizes[iteration]}) after reuse");
        }
    }

    /// <summary>
    /// Verifies that feeding data in randomly-sized small chunks (2–16 bytes) produces
    /// the same hash as single-shot, stressing the buffer fill/flush transition logic.
    /// </summary>
    /// <param name="factory">The hash algorithm factory under test.</param>
    [Test]
    [TestCaseSource(typeof(CryptoHivesManagedImplementations), nameof(CryptoHivesManagedImplementations.All))]
    public void SmallRandomChunksMatchSingleShot(HashAlgorithmFactory factory)
    {
        var rng = new Random(77);
        int blockSize = GetBlockSize(factory);

        foreach (int inputSize in new[] { blockSize - 1, blockSize, blockSize + 1, blockSize * 3 + 5 })
        {
            byte[] input = new byte[inputSize];
            rng.NextBytes(input);

            byte[] expected;
            using (var oneShot = (CryptoHivesHash.HashAlgorithm)factory.Create())
            {
                expected = oneShot.ComputeHash(input);
            }

            using var algo = factory.Create();
            int offset = 0;

            while (offset < input.Length)
            {
                int remaining = input.Length - offset;
                int chunkSize = Math.Min(2 + rng.Next(15), remaining);
                algo.TransformBlock(input, offset, chunkSize, null, 0);
                offset += chunkSize;
            }

            algo.TransformFinalBlock([], 0, 0);
            byte[] actual = algo.Hash!;

            Assert.That(actual, Is.EqualTo(expected),
                $"{factory.Name} | size={inputSize} | small random chunks");
        }
    }

    private static int GetBlockSize(HashAlgorithmFactory factory)
    {
        using var algo = (CryptoHivesHash.HashAlgorithm)factory.Create();
        return algo.BlockSize;
    }

    private static byte[] ComputeChunked(
        HashAlgorithmFactory factory,
        byte[] input,
        int blockSize,
        ChunkStrategy strategy,
        Random rng)
    {
        using var algo = factory.Create();
        int offset = 0;

        while (offset < input.Length)
        {
            int remaining = input.Length - offset;
            int chunkSize = strategy switch {
                ChunkStrategy.SingleByte => 1,
                ChunkStrategy.Random => 1 + rng.Next(blockSize * 2),
                ChunkStrategy.ExactBlock => blockSize,
                ChunkStrategy.Straddle => (offset / blockSize) % 2 == 0
                    ? Math.Max(1, blockSize - 1)
                    : blockSize + 1,
                ChunkStrategy.WholeBuffer => remaining,
                ChunkStrategy.TwoBytes => 2,
                ChunkStrategy.HalfBlock => Math.Max(1, blockSize / 2),
                _ => remaining
            };

            chunkSize = Math.Min(chunkSize, remaining);
            algo.TransformBlock(input, offset, chunkSize, null, 0);
            offset += chunkSize;
        }

        algo.TransformFinalBlock([], 0, 0);
        return algo.Hash!;
    }

    private static byte[] ComputeChunkedWithInstance(
        System.Security.Cryptography.HashAlgorithm algo,
        byte[] input,
        int chunkSize)
    {
        algo.Initialize();
        int offset = 0;

        while (offset < input.Length)
        {
            int remaining = input.Length - offset;
            int size = Math.Min(chunkSize, remaining);
            algo.TransformBlock(input, offset, size, null, 0);
            offset += size;
        }

        algo.TransformFinalBlock([], 0, 0);
        return algo.Hash!;
    }
}
