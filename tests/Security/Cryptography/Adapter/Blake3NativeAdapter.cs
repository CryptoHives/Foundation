// SPDX-FileCopyrightText: 2025 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace Cryptography.Tests.Adapter;

#if BLAKE3_NATIVE

using System;
using System.Security.Cryptography;
using Blake3Native = Blake3;

/// <summary>
/// Wraps the Blake3.NET native implementation as a <see cref="HashAlgorithm"/>.
/// </summary>
/// <remarks>
/// <para>
/// This adapter allows the Blake3.NET native Rust-based implementation to be used
/// interchangeably with .NET <see cref="HashAlgorithm"/> implementations in tests.
/// </para>
/// <para>
/// The Blake3.NET package provides SIMD-optimized native implementations for maximum
/// performance, making it an excellent reference for correctness testing.
/// </para>
/// </remarks>
internal sealed class Blake3NativeAdapter : HashAlgorithm
{
    private readonly int _outputBytes;
    private Blake3Native.Hasher _hasher;

    /// <summary>
    /// Initializes a new instance of the <see cref="Blake3NativeAdapter"/> class.
    /// </summary>
    /// <param name="outputBytes">The desired output size in bytes. Default is 32.</param>
    public Blake3NativeAdapter(int outputBytes = 32)
    {
        if (outputBytes < 1)
        {
            throw new ArgumentOutOfRangeException(nameof(outputBytes), "Output size must be positive.");
        }

        _outputBytes = outputBytes;
        HashSizeValue = outputBytes * 8;
        _hasher = Blake3Native.Hasher.New();
    }

    /// <inheritdoc/>
    public override void Initialize()
    {
        _hasher.Reset();
    }

    /// <inheritdoc/>
    protected override void HashCore(byte[] array, int ibStart, int cbSize)
    {
        _hasher.Update(array.AsSpan(ibStart, cbSize));
    }

    /// <inheritdoc/>
    protected override byte[] HashFinal()
    {
        byte[] hash = new byte[_outputBytes];
        _hasher.Finalize(hash);
        return hash;
    }

    /// <inheritdoc/>
    protected override void Dispose(bool disposing)
    {
        if (disposing)
        {
            _hasher.Reset();
        }
        base.Dispose(disposing);
    }
}

#endif


