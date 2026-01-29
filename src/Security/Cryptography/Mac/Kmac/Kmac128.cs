// SPDX-FileCopyrightText: 2025 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Security.Cryptography.Mac;

using CryptoHives.Foundation.Security.Cryptography.Hash;
using System;
using System.Text;

/// <summary>
/// Computes the KMAC128 (Keccak Message Authentication Code) for the input data.
/// </summary>
/// <remarks>
/// <para>
/// This is a fully managed implementation of KMAC128 based on the Keccak sponge
/// construction. It does not rely on OS or hardware cryptographic APIs, ensuring
/// deterministic behavior across all platforms and runtimes.
/// </para>
/// <para>
/// KMAC128 is a MAC function based on Keccak (cSHAKE128) defined in NIST SP 800-185.
/// It provides 128-bit security strength and supports variable-length output.
/// </para>
/// <para>
/// KMAC can be used as both a traditional MAC (fixed output length) or as a
/// pseudorandom function (XOF mode with arbitrary output length).
/// </para>
/// </remarks>
public sealed class Kmac128 : KeccakKmacCore
{
    /// <summary>
    /// The default output size in bits.
    /// </summary>
    public const int DefaultOutputBits = 256;

    /// <summary>
    /// The rate in bytes (1344 bits for KMAC128).
    /// </summary>
    public const int RateBytes = 168;

    /// <inheritdoc/>
    public override string AlgorithmName => "KMAC128";

    /// <inheritdoc/>
    public override int BlockSize => RateBytes;

    /// <summary>
    /// Initializes a new instance of the <see cref="Kmac128"/> class.
    /// </summary>
    /// <param name="key">The secret key.</param>
    /// <param name="outputBytes">The desired output size in bytes.</param>
    /// <param name="customization">Optional customization string S.</param>
    public Kmac128(byte[] key, int outputBytes = DefaultOutputBits / 8, string customization = "")
        : base(RateBytes, SimdSupport.KeccakDefault, key, outputBytes, customization)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Kmac128"/> class.
    /// </summary>
    /// <param name="key">The secret key.</param>
    /// <param name="outputBytes">The desired output size in bytes.</param>
    /// <param name="customization">Optional customization bytes S.</param>
    public Kmac128(byte[] key, int outputBytes, byte[] customization)
        : base(RateBytes, SimdSupport.KeccakDefault, key, outputBytes, customization)
    {
    }

    internal Kmac128(SimdSupport simdSupport, byte[] key, int outputBytes, byte[] customization)
        : base(RateBytes, simdSupport, key, outputBytes, customization)
    {
    }

    /// <summary>
    /// Creates a new instance of the <see cref="Kmac128"/> class.
    /// </summary>
    /// <param name="key">The secret key.</param>
    /// <param name="outputBytes">The desired output size in bytes.</param>
    /// <param name="customization">Optional customization string S.</param>
    /// <returns>A new KMAC128 instance.</returns>
    public static Kmac128 Create(byte[] key, int outputBytes = DefaultOutputBits / 8, string customization = "")
        => new(key, outputBytes, customization);

    internal static Kmac128 Create(SimdSupport simdSupport, byte[] key, int outputBytes, string customization)
        => new(simdSupport, key, outputBytes, Encoding.UTF8.GetBytes(customization ?? ""));
}

