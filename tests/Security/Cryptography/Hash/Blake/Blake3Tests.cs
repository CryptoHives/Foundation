// SPDX-FileCopyrightText: 2025 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace Cryptography.Tests.Hash.Blake;

using Cryptography.Tests.Hash;
using CryptoHives.Foundation.Security.Cryptography.Hash;
using NUnit.Framework;
using System;
using System.Text;
using CH = CryptoHives.Foundation.Security.Cryptography;

/// <summary>
/// Tests for BLAKE3 implementations.
/// </summary>
/// <remarks>
/// These tests verify that all BLAKE3 implementations (Managed, BouncyCastle)
/// produce identical results for the same inputs using official test vectors.
/// </remarks>
[TestFixture]
[Parallelizable(ParallelScope.All)]
public class Blake3Tests
{
    /// <summary>
    /// Test vector: Empty string with 32-byte output.
    /// </summary>
    /// <param name="factory">The hash algorithm factory.</param>
    [TestCaseSource(typeof(Blake3Implementations), nameof(Blake3Implementations.All))]
    public void ComputeHashEmptyString(HashAlgorithmFactory factory)
    {
        byte[] expected = TestHelpers.FromHexString(
            "af1349b9f5f9a1a6a0404dea36dcc9499bcb25c9adc112b7cc9a93cae41f3262");

        using var algorithm = factory.Create();
        byte[] hash = algorithm.ComputeHash(Array.Empty<byte>());

        Assert.That(hash, Is.EqualTo(expected));
    }

    /// <summary>
    /// Test vector: "abc" with 32-byte output.
    /// </summary>
    /// <param name="factory">The hash algorithm factory.</param>
    [TestCaseSource(typeof(Blake3Implementations), nameof(Blake3Implementations.All))]
    public void ComputeHashAbc(HashAlgorithmFactory factory)
    {
        byte[] expected = TestHelpers.FromHexString(
            "6437b3ac38465133ffb63b75273a8db548c558465d79db03fd359c6cd5bd9d85");
        byte[] input = Encoding.ASCII.GetBytes("abc");

        using var algorithm = factory.Create();
        byte[] hash = algorithm.ComputeHash(input);

        Assert.That(hash, Is.EqualTo(expected));
    }

    /// <summary>
    /// Official test vectors using deterministic input pattern (index mod 251).
    /// Verified against BouncyCastle reference implementation.
    /// </summary>
    /// <param name="factory">The hash algorithm factory.</param>
    /// <param name="inputLength">The length of the input.</param>
    /// <param name="expectedHex">The expected hash in hexadecimal.</param>
    [TestCaseSource(nameof(OfficialTestVectorData))]
    public void OfficialTestVectors(HashAlgorithmFactory factory, int inputLength, string expectedHex)
    {
        byte[] input = GenerateTestInput(inputLength);
        byte[] expected = TestHelpers.FromHexString(expectedHex);

        using var algorithm = factory.Create();
        byte[] hash = algorithm.ComputeHash(input);

        Assert.That(hash, Is.EqualTo(expected));
    }

    /// <summary>
    /// Test variable output length (XOF capability) for our managed implementation.
    /// </summary>
    [Test]
    public void VariableOutputLength()
    {
        byte[] input = Encoding.ASCII.GetBytes("test");

        using var blake32 = Blake3.Create(32);
        using var blake64 = Blake3.Create(64);

        byte[] hash32 = blake32.ComputeHash(input);
        byte[] hash64 = blake64.ComputeHash(input);

        Assert.That(hash32, Has.Length.EqualTo(32));
        Assert.That(hash64, Has.Length.EqualTo(64));

        // First 32 bytes of 64-byte output should match 32-byte output
        Assert.That(hash64.AsSpan(0, 32).ToArray(), Is.EqualTo(hash32));
    }

    /// <summary>
    /// Test that invalid output size throws for our managed implementation.
    /// </summary>
    [Test]
    public void InvalidOutputSizeThrows()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => Blake3.Create(0));
        Assert.Throws<ArgumentOutOfRangeException>(() => Blake3.Create(-1));
    }

    /// <summary>
    /// Test that hash size is correct for our managed implementation.
    /// </summary>
    [Test]
    public void HashSizeIsCorrect()
    {
        using var blake3 = Blake3.Create();
        Assert.That(blake3.HashSize, Is.EqualTo(256));

        using var blake64 = Blake3.Create(64);
        Assert.That(blake64.HashSize, Is.EqualTo(512));
    }

    /// <summary>
    /// Test block size is correct for our managed implementation.
    /// </summary>
    [Test]
    public void BlockSizeIsCorrect()
    {
        using var blake3 = Blake3.Create();
        Assert.That(blake3.BlockSize, Is.EqualTo(64));
    }

    /// <summary>
    /// Cross-validates the AVX2 chunk-parallel batching path (<c>CompressChunksPartialAvx2</c>)
    /// against the scalar reference implementation across sizes chosen to land on and
    /// around 8-chunk (8192-byte) batch boundaries, since none of the official test
    /// vectors above exceed one batch.
    /// </summary>
    /// <param name="inputLength">The length of the input.</param>
    [TestCase(0)]
    [TestCase(1)]
    [TestCase(4)]
    [TestCase(100)]
    [TestCase(1000)]
    [TestCase(2048)]      // 2 full chunks, none committable by the partial batch (no byte follows)
    [TestCase(2049)]      // smallest partial batch: 2 committable chunks + 1 byte
    [TestCase(3072)]
    [TestCase(3073)]
    [TestCase(4096)]
    [TestCase(4097)]
    [TestCase(5120)]
    [TestCase(7168)]      // 6 committable chunks + 1 full tail chunk
    [TestCase(8191)]      // 7 committable chunks (largest partial batch)
    [TestCase(8192)]
    [TestCase(8193)]
    [TestCase(8194)]
    [TestCase(9216)]      // 1 batch + 1 full chunk
    [TestCase(10000)]
    [TestCase(16383)]
    [TestCase(16384)]     // exactly 2 batches
    [TestCase(16385)]     // 2 batches + 1 byte
    [TestCase(24576)]     // exactly 3 batches
    [TestCase(24577)]
    [TestCase(65536)]
    [TestCase(100000)]
    [TestCase(131072)]    // exactly 16 batches
    [TestCase(131072 + 37)]
    [TestCase(262144)]    // exactly 32 batches
    [TestCase(524288)]    // exactly 64 batches
    [TestCase(1000000)]
    [TestCase(10000000)]
    public void Avx2BatchingMatchesScalarReference(int inputLength)
    {
        if ((Blake3.SimdSupport & CH.SimdSupport.Avx2) == 0)
        {
            Assert.Ignore("AVX2 not supported on this platform.");
        }

        byte[] input = GenerateTestInput(inputLength);

        using var scalar = Blake3.Create(
            CH.SimdSupport.None, 32);
        using var avx2 = Blake3.Create(
            CH.SimdSupport.Avx2, 32);

        byte[] expected = scalar.ComputeHash(input);
        byte[] actual = avx2.ComputeHash(input);

        Assert.That(actual, Is.EqualTo(expected), $"AVX2 batching mismatch at {inputLength} bytes");
    }

    /// <summary>
    /// Same as <see cref="Avx2BatchingMatchesScalarReference"/> but exercises the
    /// streaming (multi-call) <c>Append</c> path with small, chunk-boundary-crossing
    /// writes, to make sure the batching fast path composes correctly with buffered state.
    /// </summary>
    [TestCase(16385, 97)]
    [TestCase(24576, 1024)]
    [TestCase(100000, 4001)]
    public void Avx2BatchingMatchesScalarReferenceStreaming(int inputLength, int writeSize)
    {
        if ((Blake3.SimdSupport & CH.SimdSupport.Avx2) == 0)
        {
            Assert.Ignore("AVX2 not supported on this platform.");
        }

        byte[] input = GenerateTestInput(inputLength);

        using var scalar = Blake3.Create(CH.SimdSupport.None, 32);
        using var avx2 = Blake3.Create(CH.SimdSupport.Avx2, 32);

        for (int offset = 0; offset < input.Length; offset += writeSize)
        {
            int len = Math.Min(writeSize, input.Length - offset);
            scalar.TransformBlock(input, offset, len, null, 0);
            avx2.TransformBlock(input, offset, len, null, 0);
        }
        scalar.TransformFinalBlock(Array.Empty<byte>(), 0, 0);
        avx2.TransformFinalBlock(Array.Empty<byte>(), 0, 0);

        Assert.That(avx2.Hash, Is.EqualTo(scalar.Hash), $"AVX2 streaming mismatch at {inputLength} bytes / {writeSize}-byte writes");
    }

    /// <summary>
    /// Cross-validates that a tiny first write (leaving a small partial chunk
    /// buffered) followed by one large second write still matches the scalar
    /// reference — the large write's remainder, once the buffered chunk is
    /// finalized, must re-enter the batched SIMD paths (see the
    /// <c>RestartBatching</c> goto in <c>Append</c>) rather than falling back
    /// to per-chunk scalar processing for the rest of the call.
    /// </summary>
    [TestCase(1, 100000)]
    [TestCase(3, 250000)]
    [TestCase(1023, 50000)]
    [TestCase(1, 16385)]
    public void SmallThenLargeAppendReentersBatching(int firstWriteSize, int totalLength)
    {
        if ((Blake3.SimdSupport & CH.SimdSupport.Avx2) == 0)
        {
            Assert.Ignore("AVX2 not supported on this platform.");
        }

        byte[] input = GenerateTestInput(totalLength);

        using var scalar = Blake3.Create(CH.SimdSupport.None, 32);
        using var avx2 = Blake3.Create(CH.SimdSupport.Avx2, 32);

        scalar.TransformBlock(input, 0, firstWriteSize, null, 0);
        avx2.TransformBlock(input, 0, firstWriteSize, null, 0);

        scalar.TransformBlock(input, firstWriteSize, totalLength - firstWriteSize, null, 0);
        avx2.TransformBlock(input, firstWriteSize, totalLength - firstWriteSize, null, 0);

        scalar.TransformFinalBlock(Array.Empty<byte>(), 0, 0);
        avx2.TransformFinalBlock(Array.Empty<byte>(), 0, 0);

        Assert.That(avx2.Hash, Is.EqualTo(scalar.Hash),
            $"Small-then-large append mismatch: {firstWriteSize}-byte write then {totalLength - firstWriteSize}-byte write");
    }

    /// <summary>
    /// Cross-validates the NEON 4-chunk-parallel batching path (<c>CompressChunks4Neon</c>)
    /// against the scalar reference implementation across sizes chosen to land on and
    /// around 4-chunk (4096-byte) batch boundaries — one register width down from the
    /// AVX2 8-chunk cases above, since NEON's 128-bit vectors hold 4 lanes instead of 8.
    /// </summary>
    /// <param name="inputLength">The length of the input.</param>
    [TestCase(0)]
    [TestCase(1)]
    [TestCase(4)]
    [TestCase(100)]
    [TestCase(1000)]
    [TestCase(2048)]      // 2 full chunks, none committable by the partial batch (no byte follows)
    [TestCase(2049)]      // smallest partial batch: 2 committable chunks + 1 byte
    [TestCase(3072)]      // 3 committable chunks (largest NEON partial batch)
    [TestCase(3073)]
    [TestCase(4096)]      // exactly 1 batch
    [TestCase(4097)]      // 1 batch + 1 byte
    [TestCase(5120)]      // 1 batch + 1 full chunk
    [TestCase(8192)]      // exactly 2 batches
    [TestCase(8193)]      // 2 batches + 1 byte
    [TestCase(12288)]     // exactly 3 batches
    [TestCase(12289)]
    [TestCase(16384)]     // exactly 4 batches: one full subtree-group step below 64
    [TestCase(65536)]     // exactly 16 batches: one full 64-chunk subtree group
    [TestCase(65536 + 37)]
    [TestCase(131072)]    // exactly 2 subtree groups
    [TestCase(1000000)]
    [TestCase(10000000)]
    public void NeonBatchingMatchesScalarReference(int inputLength)
    {
        if ((Blake3.SimdSupport & CH.SimdSupport.Neon) == 0)
        {
            Assert.Ignore("NEON not supported on this platform.");
        }

        byte[] input = GenerateTestInput(inputLength);

        using var scalar = Blake3.Create(
            CH.SimdSupport.None, 32);
        using var neon = Blake3.Create(
            CH.SimdSupport.Neon, 32);

        byte[] expected = scalar.ComputeHash(input);
        byte[] actual = neon.ComputeHash(input);

        Assert.That(actual, Is.EqualTo(expected), $"NEON batching mismatch at {inputLength} bytes");
    }

    /// <summary>
    /// Same as <see cref="NeonBatchingMatchesScalarReference"/> but exercises the
    /// streaming (multi-call) <c>Append</c> path with small, chunk-boundary-crossing
    /// writes, to make sure the batching fast path composes correctly with buffered state.
    /// </summary>
    [TestCase(8193, 97)]
    [TestCase(12288, 1024)]
    [TestCase(100000, 4001)]
    [TestCase(100000, 6144)]   // 4KB batch + 1 chunk per write: later batches start at unaligned chunk counters
    [TestCase(6144, 3072)]     // 1st write = 3-chunk NEON partial batch that exactly drains (pending-CV holdback)
    public void NeonBatchingMatchesScalarReferenceStreaming(int inputLength, int writeSize)
    {
        if ((Blake3.SimdSupport & CH.SimdSupport.Neon) == 0)
        {
            Assert.Ignore("NEON not supported on this platform.");
        }

        byte[] input = GenerateTestInput(inputLength);

        using var scalar = Blake3.Create(CH.SimdSupport.None, 32);
        using var neon = Blake3.Create(CH.SimdSupport.Neon, 32);

        for (int offset = 0; offset < input.Length; offset += writeSize)
        {
            int len = Math.Min(writeSize, input.Length - offset);
            scalar.TransformBlock(input, offset, len, null, 0);
            neon.TransformBlock(input, offset, len, null, 0);
        }
        scalar.TransformFinalBlock(Array.Empty<byte>(), 0, 0);
        neon.TransformFinalBlock(Array.Empty<byte>(), 0, 0);

        Assert.That(neon.Hash, Is.EqualTo(scalar.Hash), $"NEON streaming mismatch at {inputLength} bytes / {writeSize}-byte writes");
    }

    /// <summary>
    /// Cross-validates the AVX-512 16-chunk batching path (<c>CompressChunksPartialAvx512</c>)
    /// against the scalar reference implementation across sizes chosen to land on and
    /// around 16-chunk (16384-byte) batch boundaries, plus AVX2-boundary sizes to cover
    /// the AVX-512 → AVX2 tail handoff.
    /// </summary>
    /// <param name="inputLength">The length of the input.</param>
    [TestCase(0)]
    [TestCase(1)]
    [TestCase(8192)]      // below one AVX-512 batch: AVX2 path only
    [TestCase(9216)]      // 9 chunks: smallest AVX-512 partial-batch case
    [TestCase(9217)]      // 9 chunks + 1 byte
    [TestCase(12288)]     // 12 chunks: mid-range AVX-512 partial batch
    [TestCase(15360)]     // 15 chunks: largest AVX-512 partial-batch case
    [TestCase(15361)]     // 15 chunks + 1 byte
    [TestCase(16383)]
    [TestCase(16384)]     // exactly 1 batch
    [TestCase(16385)]     // 1 batch + 1 byte
    [TestCase(24576)]     // 1 batch + 1 AVX2 batch
    [TestCase(24577)]
    [TestCase(32768)]     // exactly 2 batches
    [TestCase(32769)]
    [TestCase(49152)]     // exactly 3 batches
    [TestCase(65536)]
    [TestCase(100000)]
    [TestCase(131072)]    // exactly 8 batches
    [TestCase(131072 + 37)]
    [TestCase(262144)]
    [TestCase(1000000)]
    public void Avx512BatchingMatchesScalarReference(int inputLength)
    {
        if ((Blake3.SimdSupport & CH.SimdSupport.Avx512F) == 0)
        {
            Assert.Ignore("AVX-512F not supported on this platform.");
        }

        byte[] input = GenerateTestInput(inputLength);

        using var scalar = Blake3.Create(
            CH.SimdSupport.None, 32);
        using var avx512 = Blake3.Create(
            CH.SimdSupport.Avx512F | CH.SimdSupport.Avx2, 32);

        byte[] expected = scalar.ComputeHash(input);
        byte[] actual = avx512.ComputeHash(input);

        Assert.That(actual, Is.EqualTo(expected), $"AVX-512 batching mismatch at {inputLength} bytes");
    }

    /// <summary>
    /// Same as <see cref="Avx512BatchingMatchesScalarReference"/> but with the AVX-512
    /// flag isolated (no explicit AVX2 flag). Since AVX-512 hardware implies AVX2,
    /// the Append fast path still batches 8 KB tails through the AVX2 loop and
    /// 9-15 chunk tails through the dedicated AVX-512 partial-batch kernel
    /// (see <c>CompressChunksPartialAvx512</c>); only sub-8 KB tails go
    /// through the per-chunk path.
    /// </summary>
    /// <param name="inputLength">The length of the input.</param>
    [TestCase(8192)]      // below one AVX-512 batch: implied AVX2 batching only
    [TestCase(9216)]      // 9 chunks: AVX-512 partial-batch kernel, implied tier
    [TestCase(15360)]     // 15 chunks: largest AVX-512 partial-batch case, implied tier
    [TestCase(16384)]
    [TestCase(24576)]     // 1 batch + 8 KB tail picked up by implied AVX2 batching
    [TestCase(32769)]
    [TestCase(100000)]
    public void Avx512IsolatedMatchesScalarReference(int inputLength)
    {
        if ((Blake3.SimdSupport & CH.SimdSupport.Avx512F) == 0)
        {
            Assert.Ignore("AVX-512F not supported on this platform.");
        }

        byte[] input = GenerateTestInput(inputLength);

        using var scalar = Blake3.Create(CH.SimdSupport.None, 32);
        using var avx512 = Blake3.Create(CH.SimdSupport.Avx512F, 32);

        byte[] expected = scalar.ComputeHash(input);
        byte[] actual = avx512.ComputeHash(input);

        Assert.That(actual, Is.EqualTo(expected), $"Isolated AVX-512 batching mismatch at {inputLength} bytes");
    }

    /// <summary>
    /// Same as <see cref="Avx512BatchingMatchesScalarReference"/> but exercises the
    /// streaming (multi-call) <c>Append</c> path with small, chunk-boundary-crossing
    /// writes, to make sure the batching fast path composes correctly with buffered state.
    /// </summary>
    [TestCase(32769, 97)]
    [TestCase(49152, 1024)]
    [TestCase(100000, 4001)]
    [TestCase(100000, 17408)]  // 16KB batch + 1 chunk per write: later batches start at unaligned chunk counters
    [TestCase(100000, 25600)]  // 16KB + 8KB batches + 1 chunk per write: exercises both subtree levels then unaligned fallback
    [TestCase(300000, 70000)]  // 64-chunk group + tail per write: later groups start at unaligned chunk counters
    [TestCase(20480, 12288)]   // 1st write = 12-chunk AVX-512 partial batch, not draining (8 chunks follow)
    [TestCase(21504, 8192)]    // 1st write = 8-chunk AVX2 batch; 2nd write = 13-chunk AVX-512 partial batch that exactly drains (pending-CV holdback)
    public void Avx512BatchingMatchesScalarReferenceStreaming(int inputLength, int writeSize)
    {
        if ((Blake3.SimdSupport & CH.SimdSupport.Avx512F) == 0)
        {
            Assert.Ignore("AVX-512F not supported on this platform.");
        }

        byte[] input = GenerateTestInput(inputLength);

        using var scalar = Blake3.Create(CH.SimdSupport.None, 32);
        using var avx512 = Blake3.Create(CH.SimdSupport.Avx512F | CH.SimdSupport.Avx2, 32);

        for (int offset = 0; offset < input.Length; offset += writeSize)
        {
            int len = Math.Min(writeSize, input.Length - offset);
            scalar.TransformBlock(input, offset, len, null, 0);
            avx512.TransformBlock(input, offset, len, null, 0);
        }
        scalar.TransformFinalBlock(Array.Empty<byte>(), 0, 0);
        avx512.TransformFinalBlock(Array.Empty<byte>(), 0, 0);

        Assert.That(avx512.Hash, Is.EqualTo(scalar.Hash), $"AVX-512 streaming mismatch at {inputLength} bytes / {writeSize}-byte writes");
    }

    /// <summary>
    /// Cross-validates <see cref="Blake3.TryHashOneShot"/> (and the static
    /// <see cref="Blake3.TryHashData(ReadOnlySpan{byte}, Span{byte}, out int)"/>
    /// entry point that pools it) against the scalar streaming reference across
    /// sizes chosen to exercise both branches of the one-shot path: the
    /// direct-from-source single-chunk compress (&lt;= 1024 bytes, including the
    /// 0/1-block and 64-byte block-boundary edge cases) and the multi-chunk
    /// fallback into the batched <c>Append</c>/<c>TryGetCurrentHash</c> machinery.
    /// </summary>
    /// <param name="inputLength">The length of the input.</param>
    [TestCase(0)]
    [TestCase(1)]
    [TestCase(63)]
    [TestCase(64)]     // exactly one block
    [TestCase(65)]
    [TestCase(127)]
    [TestCase(128)]    // exactly two blocks
    [TestCase(1023)]
    [TestCase(1024)]   // exactly one chunk: last size handled by the single-chunk branch
    [TestCase(1025)]   // one byte over: first size handled by the multi-chunk branch
    [TestCase(8192)]
    [TestCase(16385)]
    [TestCase(100000)]
    public void TryHashOneShotMatchesScalarReference(int inputLength)
    {
        byte[] input = GenerateTestInput(inputLength);

        using var scalar = Blake3.Create(CH.SimdSupport.None, 32);
        byte[] expected = scalar.ComputeHash(input);

        using var oneShot = Blake3.Create();
        Span<byte> actual = stackalloc byte[32];
        Assert.That(oneShot.TryHashOneShot(input, actual, out int bytesWritten), Is.True);
        Assert.That(bytesWritten, Is.EqualTo(32));
        Assert.That(actual.ToArray(), Is.EqualTo(expected), $"One-shot mismatch at {inputLength} bytes");

        byte[] staticActual = Blake3.HashData(input);
        Assert.That(staticActual, Is.EqualTo(expected), $"Static HashData mismatch at {inputLength} bytes");
    }

    /// <summary>
    /// Same as <see cref="TryHashOneShotMatchesScalarReference"/> but with a
    /// 128-byte output, exercising the multi-block squeeze branch of
    /// <see cref="Blake3.TryHashOneShot"/> (output greater than one 64-byte block).
    /// </summary>
    /// <summary>
    /// Cross-validates the batched multi-block <c>Squeeze</c> path
    /// (<c>SqueezeRootBlocks</c>) — which produces several independent output
    /// blocks per call directly into the caller's span — against a byte-at-a-time
    /// reference squeeze, which only ever exercises the older single-block,
    /// partial-resume path and never the new batched loop. Sizes span several
    /// full blocks plus a non-64-aligned remainder, across every SIMD tier this
    /// platform supports, so a wrong counter increment or slice offset inside the
    /// batched loop (only reachable with 2+ extra blocks in one call) would show up.
    /// </summary>
    [TestCase(64)]
    [TestCase(65)]
    [TestCase(128)]
    [TestCase(129)]
    [TestCase(192)]
    [TestCase(447)]      // 6 blocks + 63 bytes: entirely inside the AVX2 remainder (no full 8-lane group)
    [TestCase(511)]      // 7 full blocks + 63 bytes: largest remainder still with no full group
    [TestCase(512)]      // exactly 8 blocks: exactly one full AVX2 group, zero remainder
    [TestCase(513)]      // one full AVX2 group + 1 byte into a 9th block
    [TestCase(576)]      // 9 blocks: one full AVX2 group + 1 remainder block
    [TestCase(1000)]
    [TestCase(1024)]     // exactly 16 blocks: two full AVX2 groups, zero remainder
    [TestCase(1025)]     // two full AVX2 groups + 1 byte into a 17th block
    [TestCase(4096)]
    [TestCase(10000)]
    public void SqueezeBatchingMatchesByteAtATimeReference(int outputLength)
    {
        byte[] input = GenerateTestInput(37);

        foreach (CH.SimdSupport tier in new[]
        {
            CH.SimdSupport.None,
            CH.SimdSupport.Ssse3,
            CH.SimdSupport.Avx2,
            CH.SimdSupport.Avx512F,
            CH.SimdSupport.Neon,
        })
        {
            if (tier != CH.SimdSupport.None && (Blake3.SimdSupport & tier) == 0)
            {
                continue;
            }

            using var reference = Blake3.Create(tier, 32);
            reference.Absorb(input);
            byte[] expected = new byte[outputLength];
            for (int i = 0; i < outputLength; i++)
            {
                reference.Squeeze(expected.AsSpan(i, 1));
            }

            using var batched = Blake3.Create(tier, 32);
            batched.Absorb(input);
            byte[] actual = new byte[outputLength];
            batched.Squeeze(actual);

            Assert.That(actual, Is.EqualTo(expected),
                $"Squeeze batching mismatch at {outputLength} bytes, tier {tier}");
        }
    }

    [TestCase(0)]
    [TestCase(1)]
    [TestCase(64)]
    [TestCase(1024)]
    [TestCase(1025)]
    [TestCase(8192)]
    public void TryHashOneShotMultiBlockOutputMatchesScalarReference(int inputLength)
    {
        byte[] input = GenerateTestInput(inputLength);

        using var scalar = Blake3.Create(CH.SimdSupport.None, 128);
        byte[] expected = scalar.ComputeHash(input);

        using var oneShot = Blake3.Create(128);
        Span<byte> actual = stackalloc byte[128];
        Assert.That(oneShot.TryHashOneShot(input, actual, out int bytesWritten), Is.True);
        Assert.That(bytesWritten, Is.EqualTo(128));
        Assert.That(actual.ToArray(), Is.EqualTo(expected), $"Multi-block one-shot mismatch at {inputLength} bytes");
    }

    /// <summary>
    /// Verifies <see cref="Blake3.TryHashOneShot"/> can be called repeatedly on the
    /// same instance (it must leave the instance freshly initialized for reuse,
    /// matching <c>TryComputeHash</c>'s auto-reset contract), since the benchmark's
    /// <c>Blake3SimdOneShotAdapter</c> reuses one instance across many calls.
    /// </summary>
    [Test]
    public void TryHashOneShotIsReusableAcrossCalls()
    {
        byte[] small = GenerateTestInput(100);
        byte[] large = GenerateTestInput(20000);

        using var oneShot = Blake3.Create();
        using var scalarSmall = Blake3.Create(CH.SimdSupport.None, 32);
        using var scalarLarge = Blake3.Create(CH.SimdSupport.None, 32);
        byte[] expectedSmall = scalarSmall.ComputeHash(small);
        byte[] expectedLarge = scalarLarge.ComputeHash(large);

        Span<byte> actual = stackalloc byte[32];

        Assert.That(oneShot.TryHashOneShot(large, actual, out _), Is.True);
        Assert.That(actual.ToArray(), Is.EqualTo(expectedLarge));

        Assert.That(oneShot.TryHashOneShot(small, actual, out _), Is.True);
        Assert.That(actual.ToArray(), Is.EqualTo(expectedSmall));

        Assert.That(oneShot.TryHashOneShot(large, actual, out _), Is.True);
        Assert.That(actual.ToArray(), Is.EqualTo(expectedLarge));
    }

    /// <summary>
    /// A plain (unkeyed) instance is eligible for pool reuse: <c>TryReset</c>
    /// succeeds and leaves the instance in the same freshly-initialized state
    /// <see cref="Blake3.Create()"/> would produce, so a pool can safely hand it
    /// to the next caller without disposing it.
    /// </summary>
    [Test]
    public void TryResetSucceedsForUnkeyedInstance()
    {
        using var hash = Blake3.Create();
        using var reference = Blake3.Create();

        hash.ComputeHash(GenerateTestInput(1000));

        Assert.That(hash.TryReset(), Is.True);
        Assert.That(hash.ComputeHash(GenerateTestInput(100)),
            Is.EqualTo(reference.ComputeHash(GenerateTestInput(100))));
    }

    /// <summary>
    /// A keyed instance must never be recycled into a shared pool: it carries the
    /// caller's secret key in its state, so <c>TryReset</c> must refuse reuse
    /// (return <see langword="false"/>), signalling the pool to <c>Dispose</c> the
    /// instance instead of returning it.
    /// </summary>
    [Test]
    public void TryResetRefusesKeyedInstance()
    {
        byte[] key = GenerateTestInput(32);
        using var keyed = Blake3.CreateKeyed(key);

        Assert.That(keyed.TryReset(), Is.False);
    }

    /// <summary>
    /// The key material must be gone the instant <c>TryReset</c> is called, not
    /// only once a well-behaved pool subsequently calls <c>Dispose</c> in response
    /// to the <see langword="false"/> return. Verified behaviorally: if the
    /// instance were misused after <c>TryReset</c> (e.g. by a pool that ignores
    /// the <see langword="false"/> result), hashing with it must no longer match
    /// what the original key would have produced.
    /// </summary>
    [Test]
    public void TryResetErasesKeyMaterial()
    {
        byte[] key = GenerateTestInput(32);
        byte[] message = GenerateTestInput(16);

        using var keyed = Blake3.CreateKeyed(key);
        Assert.That(keyed.TryReset(), Is.False);

        byte[] afterReset = keyed.ComputeHash(message);

        using var freshWithSameKey = Blake3.CreateKeyed(key);
        byte[] referenceWithOriginalKey = freshWithSameKey.ComputeHash(message);

        Assert.That(afterReset, Is.Not.EqualTo(referenceWithOriginalKey),
            "TryReset must erase the key material, not just refuse pooling");
    }

    /// <summary>
    /// Cross-validates <see cref="Blake3.TryHashOneShot"/> across every SIMD tier
    /// this platform supports, mirroring how <c>ParameterizedHashBenchmark</c>
    /// dispatches to it for the "CryptoHives-*" benchmark rows (see
    /// <c>ParameterizedHashBenchmark.TryComputeHash</c>), so the per-tier fast-path
    /// wiring is covered by correctness tests just like the streaming path already is.
    /// </summary>
    [TestCase(0)]
    [TestCase(1)]
    [TestCase(1024)]
    [TestCase(1025)]
    [TestCase(100000)]
    public void TryHashOneShotMatchesScalarReferenceAcrossSimdTiers(int inputLength)
    {
        byte[] input = GenerateTestInput(inputLength);

        using var scalar = Blake3.Create(CH.SimdSupport.None, 32);
        byte[] expected = scalar.ComputeHash(input);

        Span<byte> actual = stackalloc byte[32];
        foreach (var flag in new[] { CH.SimdSupport.None, CH.SimdSupport.Ssse3, CH.SimdSupport.Avx2, CH.SimdSupport.Avx512F, CH.SimdSupport.Neon })
        {
            if (flag != CH.SimdSupport.None && (Blake3.SimdSupport & flag) == 0)
            {
                continue;
            }

            using var tier = Blake3.Create(flag, 32);
            Assert.That(tier.TryHashOneShot(input, actual, out int bytesWritten), Is.True, $"tier {flag}");
            Assert.That(bytesWritten, Is.EqualTo(32), $"tier {flag}");
            Assert.That(actual.ToArray(), Is.EqualTo(expected), $"One-shot mismatch at {inputLength} bytes, tier {flag}");
        }
    }

    /// <summary>
    /// Provides test data combining implementations with test vectors.
    /// </summary>
    public static System.Collections.IEnumerable OfficialTestVectorData
    {
        get
        {
            var testVectors = new (int length, string hash)[]
            {
                (0, "af1349b9f5f9a1a6a0404dea36dcc9499bcb25c9adc112b7cc9a93cae41f3262"),
                (1, "2d3adedff11b61f14c886e35afa036736dcd87a74d27b5c1510225d0f592e213"),
                (2, "7b7015bb92cf0b318037702a6cdd81dee41224f734684c2c122cd6359cb1ee63"),
                (3, "e1be4d7a8ab5560aa4199eea339849ba8e293d55ca0a81006726d184519e647f"),
                (4, "f30f5ab28fe047904037f77b6da4fea1e27241c5d132638d8bedce9d40494f32"),
                (5, "b40b44dfd97e7a84a996a91af8b85188c66c126940ba7aad2e7ae6b385402aa2"),
                (6, "06c4e8ffb6872fad96f9aaca5eee1553eb62aed0ad7198cef42e87f6a616c844"),
                (7, "3f8770f387faad08faa9d8414e9f449ac68e6ff0417f673f602a646a891419fe"),
                (8, "2351207d04fc16ade43ccab08600939c7c1fa70a5c0aaca76063d04c3228eaeb"),
                (63, "e9bc37a594daad83be9470df7f7b3798297c3d834ce80ba85d6e207627b7db7b"),
                (64, "4eed7141ea4a5cd4b788606bd23f46e212af9cacebacdc7d1f4c6dc7f2511b98"),
                (65, "de1e5fa0be70df6d2be8fffd0e99ceaa8eb6e8c93a63f2d8d1c30ecb6b263dee"),
                (127, "d81293fda863f008c09e92fc382a81f5a0b4a1251cba1634016a0f86a6bd640d"),
                (128, "f17e570564b26578c33bb7f44643f539624b05df1a76c81f30acd548c44b45ef"),
                (129, "683aaae9f3c5ba37eaaf072aed0f9e30bac0865137bae68b1fde4ca2aebdcb12"),
                (1023, "10108970eeda3eb932baac1428c7a2163b0e924c9a9e25b35bba72b28f70bd11"),
                (1024, "42214739f095a406f3fc83deb889744ac00df831c10daa55189b5d121c855af7"),
                // Multi-chunk test vectors (> 1024 bytes)
                (1025, "d00278ae47eb27b34faecf67b4fe263f82d5412916c1ffd97c8cb7fb814b8444"),
                (2048, "e776b6028c7cd22a4d0ba182a8bf62205d2ef576467e838ed6f2529b85fba24a"),
                (2049, "5f4d72f40d7a5f82b15ca2b2e44b1de3c2ef86c426c95c1af0b6879522563030"),
                // Extended multi-chunk test vectors
                (4096, "015094013f57a5277b59d8475c0501042c0b642e531b0a1c8f58d2163229e969"),
                (8192, "aae792484c8efe4f19e2ca7d371d8c467ffb10748d8a5a1ae579948f718a2a63"),
            };

            foreach (HashAlgorithmFactory factory in Blake3Implementations.All)
            {
                foreach (var (length, hash) in testVectors)
                {
                    yield return new TestCaseData(factory, length, hash)
                        .SetName($"OfficialTestVectors({factory.Name}, {length})");
                }
            }
        }
    }

    /// <summary>
    /// Generates test input using the official BLAKE3 pattern (index mod 251).
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


