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

    /// <summary>Edge case sizes only.</summary>
    public static readonly DataSize[] EdgeCases = [B137, B1025];

    /// <summary>Standard sizes for quick benchmarks.</summary>
    public static readonly object[] StandardTests = Standard.Where(s => s != null).Select(s => new object[] { s }).ToArray();

    /// <summary>All sizes including edge cases.</summary>
    public static readonly object[] AllSizesTests = AllSizes.Where(s => s != null).Select(s => new object[] { s }).ToArray();

    /// <summary>Edge case sizes only.</summary>
    public static readonly object[] EdgeCasesTests = EdgeCases.Where(s => s != null).Select(s => new object[] { s }).ToArray();
}


