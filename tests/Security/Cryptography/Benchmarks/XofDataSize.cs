// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

#pragma warning disable CA1050 // Declare types in namespaces

using System.Linq;

/// <summary>
/// Defines squeeze output sizes for XOF benchmarks (no edge-case sizes).
/// </summary>
/// <remarks>
/// Unlike <see cref="DataSize"/>, this type omits block-boundary edge cases (137B, 1025B)
/// because XOF squeeze output is a continuous stream with no block alignment artifacts.
/// </remarks>
public class XofDataSize : DataSize
{
    /// <summary>
    /// Initializes a new instance.
    /// </summary>
    public XofDataSize() { }

    /// <summary>
    /// Initializes a new instance of the <see cref="XofDataSize"/> class with the specified name and size in bytes.
    /// </summary>
    /// <param name="name">The display name that identifies the data size.</param>
    /// <param name="bytes">The number of bytes represented by this data size.</param>
    public XofDataSize(string name, int bytes) : base(name, bytes) { }

    /// <summary>128 bytes - small squeeze output.</summary>
    public static new readonly XofDataSize B128 = new("128B", 128);

    /// <summary>1 KB - moderate squeeze output.</summary>
    public static new readonly XofDataSize K1 = new("1KB", 1024);

    /// <summary>8 KB - throughput testing.</summary>
    public static new readonly XofDataSize K8 = new("8KB", 8192);

    /// <summary>128 KB - sustained squeeze throughput.</summary>
    public static new readonly XofDataSize K128 = new("128KB", 131072);

    /// <summary>All XOF squeeze sizes (standard only, no edge cases).</summary>
    public static new readonly XofDataSize[] AllSizes = [B128, K1, K8, K128];

    /// <summary>All XOF squeeze sizes for NUnit test cases.</summary>
    public static new readonly object[] AllSizesTests = AllSizes.Where(s => s != null).Select(s => new object[] { s }).ToArray();
}
