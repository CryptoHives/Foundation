// SPDX-FileCopyrightText: 2025 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Security.Cryptography.Mac;

using CryptoHives.Foundation.Security.Cryptography.Hash;
using System;
using System.Text;

/// <summary>
/// Computes the KMAC256 (Keccak Message Authentication Code) for the input data.
/// </summary>
/// <remarks>
/// <para>
/// This is a fully managed implementation of KMAC256 based on the Keccak sponge
/// construction. It does not rely on OS or hardware cryptographic APIs, ensuring
/// deterministic behavior across all platforms and runtimes.
/// </para>
/// <para>
/// KMAC256 is a MAC function based on Keccak (cSHAKE256) defined in NIST SP 800-185.
/// It provides 256-bit security strength and supports variable-length output.
/// </para>
/// <para>
/// KMAC can be used as both a traditional MAC (fixed output length) or as a
/// pseudorandom function (XOF mode with arbitrary output length).
/// </para>
/// </remarks>
public sealed class Kmac256 : KeccakKmacCore
{
    /// <summary>
    /// The default output size in bits.
    /// </summary>
    public const int DefaultOutputBits = 512;

    /// <summary>
    /// The rate in bytes (1088 bits for KMAC256).
    /// </summary>
    public const int RateBytes = 136;

    /// <inheritdoc/>
    public override string AlgorithmName => "KMAC256";

    /// <inheritdoc/>
    public override int BlockSize => RateBytes;

    /// <summary>
    /// Initializes a new instance of the <see cref="Kmac256"/> class.
    /// </summary>
    /// <param name="key">The secret key.</param>
    /// <param name="outputBytes">The desired output size in bytes.</param>
    /// <param name="customization">Optional customization string S.</param>
    public Kmac256(byte[] key, int outputBytes = DefaultOutputBits / 8, string customization = "")
        : base(RateBytes, SimdSupport.KeccakDefault, key, outputBytes, customization)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Kmac256"/> class.
    /// </summary>
    /// <param name="key">The secret key.</param>
    /// <param name="outputBytes">The desired output size in bytes.</param>
    /// <param name="customization">Optional customization bytes S.</param>
    public Kmac256(byte[] key, int outputBytes, byte[] customization)
        : base(RateBytes, SimdSupport.KeccakDefault, key, outputBytes, customization)
    {
    }

    internal Kmac256(SimdSupport simdSupport, byte[] key, int outputBytes, byte[] customization)
        : base(RateBytes, simdSupport, key, outputBytes, customization)
    {
    }

    /// <summary>
    /// Creates a new instance of the <see cref="Kmac256"/> class.
    /// </summary>
    /// <param name="key">The secret key.</param>
    /// <param name="outputBytes">The desired output size in bytes.</param>
    /// <param name="customization">Optional customization string S.</param>
    /// <returns>A new KMAC256 instance.</returns>
    public static Kmac256 Create(byte[] key, int outputBytes = DefaultOutputBits / 8, string customization = "")
        => new(key, outputBytes, customization);

    internal static Kmac256 Create(SimdSupport simdSupport, byte[] key, int outputBytes, string customization)
        => new(simdSupport, key, outputBytes, Encoding.UTF8.GetBytes(customization ?? ""));
}

