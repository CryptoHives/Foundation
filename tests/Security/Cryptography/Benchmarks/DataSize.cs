// SPDX-FileCopyrightText: 2025 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

#pragma warning disable CA1050 // Declare types in namespaces

using System;
using System.Linq;

/// <summary>
/// Defines data sizes for hash benchmarks with edge cases for block boundaries.
/// </summary>
public class DataSize : IFormattable
{
    /// <summary>
    /// Initializes a new instance.
    /// </summary>
    public DataSize()
    {
        Name = string.Empty;
        Bytes = 0;
    }

    /// <summary>
    /// Initializes a new instance of the DataSize class with the specified name and size in bytes.
    /// </summary>
    /// <param name="name">The display name that identifies the data size. Cannot be null.</param>
    /// <param name="bytes">The number of bytes represented by this data size. Must be zero or greater.</param>
    public DataSize(string name, int bytes)
    {
        Name = name;
        Bytes = bytes;
    }

    /// <summary>
    /// Gets the name associated with this instance.
    /// </summary>
    public string Name { get; }

    /// <summary>
    /// Gets the number of bytes represented by this instance.
    /// </summary>
    public int Bytes { get; }

    public string ToString(string? format, IFormatProvider? formatProvider) => Name;

    public override string ToString() => Name;

    /// <summary>128 bytes - small data, fits in single block for most algorithms.</summary>
    public static readonly DataSize B128 = new("128B", 128);

    /// <summary>137 bytes - edge case: SHA3-256/Keccak-256 rate (136) + 1 byte.</summary>
    public static readonly DataSize B137 = new("137B", 137);

    /// <summary>1 KB - multiple blocks.</summary>
    public static readonly DataSize K1 = new("1KB", 1024);

    /// <summary>1025 bytes - edge case: BLAKE3 chunk boundary (1024) + 1 byte.</summary>
    public static readonly DataSize B1025 = new("1025B", 1025);

    /// <summary>8 KB - throughput testing.</summary>
    public static readonly DataSize K8 = new("8KB", 8192);

    /// <summary>128 KB - sustained throughput.</summary>
    public static readonly DataSize K128 = new("128KB", 131072);

    /// <summary>Standard sizes for quick benchmarks.</summary>
    public static readonly DataSize[] Standard = [B128, K1, K8, K128];

    /// <summary>All sizes including edge cases.</summary>
    public static readonly DataSize[] AllSizes = [B128, B137, K1, B1025, K8, K128];

    /// <summary>4 bytes - minimal input.</summary>
    public static readonly DataSize B4 = new("4B", 4);

    /// <summary>100 bytes - sub-block input.</summary>
    public static readonly DataSize B100 = new("100B", 100);

    /// <summary>1000 bytes - just below the BLAKE3 chunk size (1024).</summary>
    public static readonly DataSize B1000 = new("1000B", 1000);

    /// <summary>4 KB - one half BLAKE3 8-chunk batch (8192).</summary>
    public static readonly DataSize K4 = new("4KB", 4096);

    /// <summary>10000 bytes - one BLAKE3 8-chunk batch (8192) + partial chunks.</summary>
    public static readonly DataSize B10000 = new("10000B", 10000);

    /// <summary>64 KB - exactly 8 BLAKE3 8-chunk batches.</summary>
    public static readonly DataSize K64 = new("64KB", 65536);

    /// <summary>100000 bytes - 12 BLAKE3 batches + partial chunks.</summary>
    public static readonly DataSize B100000 = new("100000B", 100000);

    /// <summary>256 KB - exactly 32 BLAKE3 8-chunk batches.</summary>
    public static readonly DataSize K256 = new("256KB", 262144);

    /// <summary>512 KB - exactly 64 BLAKE3 8-chunk batches.</summary>
    public static readonly DataSize K512 = new("512KB", 524288);

    /// <summary>1 MB (decimal, 1000000 bytes) - large non-aligned input.</summary>
    public static readonly DataSize M1 = new("1MB", 1000000);

    /// <summary>10 MB (decimal, 10000000 bytes) - sustained throughput, exceeds L2 cache.</summary>
    public static readonly DataSize M10 = new("10MB", 10000000);

    /// <summary>
    /// Sizes for BLAKE3 benchmarks: extends <see cref="AllSizes"/> with sizes on and around
    /// the 8 KB SIMD chunk-batch boundary, since the batching fast path makes BLAKE3
    /// throughput sensitive to sizes other algorithms are indifferent to.
    /// </summary>
    public static readonly DataSize[] Blake3Sizes =
        [B4, B100, B128, B137, B1000, K1, B1025, K4, K8, B10000, K64, B100000, K128, K256, K512, M1, M10];

    /// <summary>Edge case sizes only.</summary>
    public static readonly DataSize[] EdgeCases = [B137, B1025];

    /// <summary>17 bytes - one AES block (16) + 1 byte partial block.</summary>
    public static readonly DataSize B17 = new("17B", 17);

    /// <summary>65 bytes - 4 AES block (64) + 1 byte partial block.</summary>
    public static readonly DataSize B65 = new("65B", 65);

    /// <summary>88 bytes - 4 + 1 AES block (80) + 8 byte partial block.</summary>
    public static readonly DataSize B88 = new("88B", 88);

    /// <summary>129 bytes - 8 AES blocks (128) + 1 byte, tests pipelined block boundary.</summary>
    public static readonly DataSize B129 = new("129B", 129);

    /// <summary>152 bytes - 8 + 1 AES blocks (144) + 8 byte, tests pipelined block boundary.</summary>
    public static readonly DataSize B152 = new("152B", 152);

    /// <summary>256 bytes - 16 AES blocks, tests two full 8-block pipeline iterations.</summary>
    public static readonly DataSize B256 = new("256B", 256);

    /// <summary>65535 bytes - 4k-1 AES blocks + 15 byte partial blocks.</summary>
    public static readonly DataSize B65535 = new("65535B", 65535);

    /// <summary>Standard sizes with cipher pipeline edge cases.</summary>
    public static readonly DataSize[] CipherSizes = [B17, B65, B128, B152, B256, K1, K8, K128];

    /// <summary>Standard sizes for quick benchmarks.</summary>
    public static readonly object[] StandardTests = Standard.Where(s => s != null).Select(s => new object[] { s }).ToArray();

    /// <summary>All sizes including edge cases.</summary>
    public static readonly object[] AllSizesTests = AllSizes.Where(s => s != null).Select(s => new object[] { s }).ToArray();

    /// <summary>Edge case sizes only.</summary>
    public static readonly object[] EdgeCasesTests = EdgeCases.Where(s => s != null).Select(s => new object[] { s }).ToArray();
}


