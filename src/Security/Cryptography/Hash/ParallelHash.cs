// SPDX-FileCopyrightText: 2025 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Security.Cryptography.Hash;

using System;
using System.Text;

/// <summary>
/// Computes a variable-length output using ParallelHash (NIST SP 800-185).
/// </summary>
/// <remarks>
/// <para>
/// ParallelHash divides input into fixed-size blocks, hashes each block with SHAKE128 or SHAKE256
/// (i.e. <c>KECCAK[256](block ‖ 1111, 256)</c> or <c>KECCAK[512](block ‖ 1111, 512)</c>),
/// concatenates those chaining values with encoding of the block count and output length, and
/// finalizes with cSHAKE128 or cSHAKE256 using function-name string <c>"ParallelHash"</c>
/// per NIST SP 800-185 Section 6.3 / Appendix A.4.
/// </para>
/// <para>
/// Use <see cref="ComputeHash128(Span{byte}, ReadOnlySpan{byte}, int, ReadOnlySpan{byte})"/> for 128-bit security (SHAKE128 inner blocks, cSHAKE128
/// finalization) and <see cref="ComputeHash256(Span{byte}, ReadOnlySpan{byte}, int, ReadOnlySpan{byte})"/> for 256-bit security (SHAKE256, cSHAKE256).
/// For incremental or streaming computation, use <see cref="IncrementalParallelHash"/>.
/// </para>
/// </remarks>
public static class ParallelHash
{
    /// <summary>
    /// Default block size in bytes (4 MiB).
    /// </summary>
    public const int DefaultBlockSizeBytes = 0x100_000;

    private const int ChainingValue128Bytes = 32;
    private const int ChainingValue256Bytes = 64;
    private static readonly byte[] ParallelHashFunctionName = Encoding.ASCII.GetBytes("ParallelHash");

    /// <summary>
    /// Computes a hash using ParallelHash128.
    /// </summary>
    /// <param name="output">The output span to receive the hash.</param>
    /// <param name="inputData">The data to hash.</param>
    /// <param name="blockSizeBytes">Block size in bytes (default: 4 MiB).</param>
    /// <param name="customization">Optional customization string S (default: empty).</param>
    /// <returns>The computed hash value as a span.</returns>
    public static Span<byte> ComputeHash128(
        Span<byte> output,
        ReadOnlySpan<byte> inputData,
        int blockSizeBytes = DefaultBlockSizeBytes,
        ReadOnlySpan<byte> customization = default)
        => ComputeHashCore(output, inputData, blockSizeBytes, useShake256: false, customization);

    /// <summary>
    /// Computes a hash using ParallelHash256.
    /// </summary>
    /// <param name="output">The output span to receive the hash.</param>
    /// <param name="inputData">The data to hash.</param>
    /// <param name="blockSizeBytes">Block size in bytes (default: 4 MiB).</param>
    /// <param name="customization">Optional customization string S (default: empty).</param>
    /// <returns>The computed hash value as a span.</returns>
    public static Span<byte> ComputeHash256(
        Span<byte> output,
        ReadOnlySpan<byte> inputData,
        int blockSizeBytes = DefaultBlockSizeBytes,
        ReadOnlySpan<byte> customization = default)
        => ComputeHashCore(output, inputData, blockSizeBytes, useShake256: true, customization);

    /// <summary>
    /// Computes a hash using ParallelHash128, returning the result as an immutable byte array.
    /// </summary>
    /// <param name="inputData">The data to hash.</param>
    /// <param name="blockSizeBytes">Block size in bytes (default: 4 MiB).</param>
    /// <returns>The 32-byte hash value.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="inputData"/> is null.</exception>
    public static byte[] ComputeHash128(byte[] inputData, int blockSizeBytes = DefaultBlockSizeBytes)
    {
        if (inputData is null) throw new ArgumentNullException(nameof(inputData));
        byte[] output = new byte[ChainingValue128Bytes];
        ComputeHash128(output, inputData, blockSizeBytes);
        return output;
    }

    /// <summary>
    /// Computes a hash using ParallelHash256, returning the result as an immutable byte array.
    /// </summary>
    /// <param name="inputData">The data to hash.</param>
    /// <param name="blockSizeBytes">Block size in bytes (default: 4 MiB).</param>
    /// <returns>The 64-byte hash value.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="inputData"/> is null.</exception>
    public static byte[] ComputeHash256(byte[] inputData, int blockSizeBytes = DefaultBlockSizeBytes)
    {
        if (inputData is null) throw new ArgumentNullException(nameof(inputData));
        byte[] output = new byte[ChainingValue256Bytes];
        ComputeHash256(output, inputData, blockSizeBytes);
        return output;
    }

    internal static Span<byte> ComputeHashCore(
        Span<byte> output,
        ReadOnlySpan<byte> inputData,
        int blockSizeBytes,
        bool useShake256,
        ReadOnlySpan<byte> customization)
    {
        if (output.Length == 0)
        {
            return output;
        }

        if (blockSizeBytes <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(blockSizeBytes), "Block size must be positive.");
        }

        byte[] customBytes = customization.IsEmpty ? Array.Empty<byte>() : customization.ToArray();

        if (useShake256)
        {
            using var finalXof = CShake256.Create(
                outputBytes: CShake256.DefaultOutputBits / 8,
                functionName: ParallelHashFunctionName,
                customization: customBytes);
            return RunHashWithXof(finalXof, output, inputData, blockSizeBytes, useShake256: true);
        }
        else
        {
            using var finalXof = CShake128.Create(
                outputBytes: CShake128.DefaultOutputBits / 8,
                functionName: ParallelHashFunctionName,
                customization: customBytes);
            return RunHashWithXof(finalXof, output, inputData, blockSizeBytes, useShake256: false);
        }
    }

    private static Span<byte> RunHashWithXof(
        IExtendableOutput finalXof,
        Span<byte> output,
        ReadOnlySpan<byte> inputData,
        int blockSizeBytes,
        bool useShake256)
    {
        long blockCount = (inputData.Length + blockSizeBytes - 1L) / blockSizeBytes;
        long outputBits = checked((long)output.Length * 8L);

        Span<byte> encodeBuffer = stackalloc byte[CShake128.EncodeBufferLength];
        AbsorbEncodedLeft(finalXof, blockSizeBytes, encodeBuffer);

        int chainingValueBytes = useShake256 ? ChainingValue256Bytes : ChainingValue128Bytes;
        byte[] chainingValue = new byte[chainingValueBytes];

        for (long i = 0; i < blockCount; i++)
        {
            int offset = checked((int)(i * blockSizeBytes));
            int blockLength = Math.Min(blockSizeBytes, inputData.Length - offset);
            ReadOnlySpan<byte> block = inputData.Slice(offset, blockLength);

            ComputeInnerBlockHash(useShake256, block, chainingValue);
            finalXof.Absorb(chainingValue);
        }

        AbsorbEncodedRight(finalXof, blockCount, encodeBuffer);
        AbsorbEncodedRight(finalXof, outputBits, encodeBuffer);
        finalXof.Squeeze(output);
        return output;
    }

    private static void ComputeInnerBlockHash(bool useShake256, ReadOnlySpan<byte> block, Span<byte> chainingValue)
    {
        // Spec: KECCAK[256](block || 1111, 256) = SHAKE128(block, 256 bits) for 128-bit variant
        //       KECCAK[512](block || 1111, 512) = SHAKE256(block, 512 bits) for 256-bit variant
        if (useShake256)
        {
            using var shake256 = Shake256.Create(ChainingValue256Bytes);
            if (!shake256.TryComputeHash(block, chainingValue, out _))
            {
                throw new InvalidOperationException("Failed to compute SHAKE256 chaining value.");
            }
            return;
        }

        using var shake128 = Shake128.Create(ChainingValue128Bytes);
        if (!shake128.TryComputeHash(block, chainingValue, out _))
        {
            throw new InvalidOperationException("Failed to compute SHAKE128 chaining value.");
        }
    }

    private static void AbsorbEncodedLeft(IExtendableOutput xof, long value, Span<byte> encodeBuffer)
    {
        if (!CShake128.TryLeftEncode(encodeBuffer, value, out int written))
        {
            throw new InvalidOperationException("Failed to left-encode value.");
        }

        xof.Absorb(encodeBuffer[..written]);
    }

    private static void AbsorbEncodedRight(IExtendableOutput xof, long value, Span<byte> encodeBuffer)
    {
        if (!CShake128.TryRightEncode(encodeBuffer, value, out int written))
        {
            throw new InvalidOperationException("Failed to right-encode value.");
        }

        xof.Absorb(encodeBuffer[..written]);
    }
}
