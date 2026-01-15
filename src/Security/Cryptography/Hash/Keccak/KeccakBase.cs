// SPDX-FileCopyrightText: 2025 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Security.Cryptography.Hash;

/// <summary>
/// All algorithms based on the Keccak permutation should derive from this class.
/// Provides the derived implementations with the core Keccak-f[1600] permutation,
/// state variables and a buffer for the rate bytes.
/// </summary>
/// <remarks>
/// <para>
/// This class holds the Keccak state used by SHA-3, SHAKE, cSHAKE, KMAC,
/// and related algorithms. It is designed as a shared primitive to reduce code
/// duplication across Keccak-based implementations.
/// </para>
/// <para>
/// The Keccak state is a 5×5×64 = 1600-bit array organized as 25 64-bit lanes.
/// </para>
/// <para>
/// On platforms with AVX512F support (.NET 8+), an optimized SIMD implementation can be used.
/// </para>
/// </remarks>
public abstract class KeccakBase : HashAlgorithm
{
    private protected KeccakCoreState _keccakCore;
    private protected readonly byte[] _buffer;
    private protected int _bufferLength;

    internal KeccakBase(int rateBytes, SimdSupport simdSupport = SimdSupport.None)
    {
        _keccakCore = new KeccakCoreState(simdSupport);
        _buffer = new byte[rateBytes];
    }

    /// <inheritdoc/>
    public override void Initialize()
    {
        _keccakCore.Reset();
        ClearBuffer(_buffer);
        _bufferLength = 0;
    }

    /// <summary>
    /// Gets the SIMD instruction sets supported by this algorithm on the current platform.
    /// </summary>
    internal static SimdSupport SimdSupport => KeccakCoreState.SimdSupport;

    /// <inheritdoc/>
    protected override void Dispose(bool disposing)
    {
        if (disposing)
        {
            _keccakCore.Reset();
            ClearBuffer(_buffer);
        }
        base.Dispose(disposing);
    }
}
