// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

#pragma warning disable CA1050 // Declare types in namespaces

using Cryptography.Tests.Adapter.Hash;
using CryptoHives.Foundation.Security.Cryptography;
using Org.BouncyCastle.Crypto.Digests;
using System;
using System.Collections.Generic;
using System.Text;
using CH = CryptoHives.Foundation.Security.Cryptography;

/// <summary>
/// Factory for creating <see cref="IExtendableOutput"/> instances for XOF benchmarking.
/// </summary>
/// <remarks>
/// Each method returns implementations from CryptoHives (managed), BouncyCastle (reference),
/// and .NET OS (native) where available. The returned objects also implement
/// <see cref="IDisposable"/> for cleanup.
/// </remarks>
public sealed class XofAlgorithmType : IFormattable
{
    private readonly Func<CH.Hash.IExtendableOutput> _factory;

    /// <summary>
    /// Initializes a new instance of the <see cref="XofAlgorithmType"/> class.
    /// </summary>
    /// <param name="category">The algorithm family name.</param>
    /// <param name="name">The display name for this implementation.</param>
    /// <param name="factory">Factory function that creates an <see cref="IExtendableOutput"/> instance.</param>
    public XofAlgorithmType(string category, string name, Func<CH.Hash.IExtendableOutput> factory)
    {
        Category = category;
        Name = name;
        _factory = factory;
    }

    /// <summary>
    /// Gets the display name for this implementation.
    /// </summary>
    public string Name { get; }

    /// <summary>
    /// Gets the algorithm category/family.
    /// </summary>
    public string Category { get; }

    /// <summary>
    /// Creates an instance of the XOF algorithm.
    /// </summary>
    public CH.Hash.IExtendableOutput Create() => _factory();

    /// <inheritdoc/>
    public string ToString(string? format, IFormatProvider? formatProvider) => Name;

    /// <inheritdoc/>
    public override string ToString() => Name;

    #region SHAKE

    /// <summary>SHAKE128 XOF implementations.</summary>
    public static IEnumerable<XofAlgorithmType> Shake128()
    {
        yield return new("SHAKE128", "SHAKE128 (Managed)", () => CH.Hash.Shake128.Create(32));
        yield return new("SHAKE128", "SHAKE128 (BouncyCastle)", () => new BouncyCastleIXofAdapter(new ShakeDigest(128)));
#if NET8_0_OR_GREATER
        if (System.Security.Cryptography.Shake128.IsSupported)
            yield return new("SHAKE128", "SHAKE128 (OS)", () => new OSShakeXofAdapter(128));
#endif
    }

    /// <summary>SHAKE256 XOF implementations.</summary>
    public static IEnumerable<XofAlgorithmType> Shake256()
    {
        yield return new("SHAKE256", "SHAKE256 (Managed)", () => CH.Hash.Shake256.Create(64));
        yield return new("SHAKE256", "SHAKE256 (BouncyCastle)", () => new BouncyCastleIXofAdapter(new ShakeDigest(256)));
#if NET8_0_OR_GREATER
        if (System.Security.Cryptography.Shake256.IsSupported)
            yield return new("SHAKE256", "SHAKE256 (OS)", () => new OSShakeXofAdapter(256));
#endif
    }

    #endregion

    #region cSHAKE

    /// <summary>cSHAKE128 XOF implementations.</summary>
    public static IEnumerable<XofAlgorithmType> CShake128()
    {
        yield return new("cSHAKE128", "cSHAKE128 (Managed)", () => CH.Hash.CShake128.Create(32));
        yield return new("cSHAKE128", "cSHAKE128 (BouncyCastle)", () => new BouncyCastleIXofAdapter(new CShakeDigest(128, null, null)));
    }

    /// <summary>cSHAKE256 XOF implementations.</summary>
    public static IEnumerable<XofAlgorithmType> CShake256()
    {
        yield return new("cSHAKE256", "cSHAKE256 (Managed)", () => CH.Hash.CShake256.Create(64));
        yield return new("cSHAKE256", "cSHAKE256 (BouncyCastle)", () => new BouncyCastleIXofAdapter(new CShakeDigest(256, null, null)));
    }

    #endregion

    #region TurboSHAKE

    /// <summary>TurboSHAKE128 XOF implementation.</summary>
    public static IEnumerable<XofAlgorithmType> TurboShake128()
    {
        yield return new("TurboSHAKE128", "TurboSHAKE128 (Managed)", () => CH.Hash.TurboShake128.Create(32));
    }

    /// <summary>TurboSHAKE256 XOF implementation.</summary>
    public static IEnumerable<XofAlgorithmType> TurboShake256()
    {
        yield return new("TurboSHAKE256", "TurboSHAKE256 (Managed)", () => CH.Hash.TurboShake256.Create(64));
    }

    #endregion

    #region KangarooTwelve

    /// <summary>KT128 XOF implementation.</summary>
    public static IEnumerable<XofAlgorithmType> KT128()
    {
        yield return new("KT128", "KT128 (Managed)", () => CH.Hash.KT128.Create(32));
    }

    /// <summary>KT256 XOF implementation.</summary>
    public static IEnumerable<XofAlgorithmType> KT256()
    {
        yield return new("KT256", "KT256 (Managed)", () => CH.Hash.KT256.Create(64));
    }

    #endregion

    #region KMAC

    private static readonly byte[] SharedKMacKey =
    [
        0x40, 0x41, 0x42, 0x43, 0x44, 0x45, 0x46, 0x47,
        0x48, 0x49, 0x4a, 0x4b, 0x4c, 0x4d, 0x4e, 0x4f,
        0x50, 0x51, 0x52, 0x53, 0x54, 0x55, 0x56, 0x57,
        0x58, 0x59, 0x5a, 0x5b, 0x5c, 0x5d, 0x5e, 0x5f
    ];

    private static readonly byte[] SharedKMacCustomization = Encoding.UTF8.GetBytes("Benchmark");

    /// <summary>KMAC128 XOF implementations.</summary>
    public static IEnumerable<XofAlgorithmType> KMac128()
    {
        yield return new("KMAC-128", "KMAC-128 (Managed)", () => CH.Mac.KMac128.Create(SimdSupport.None, SharedKMacKey, 32, "Benchmark"));
        yield return new("KMAC-128", "KMAC-128 (BouncyCastle)", () => new BouncyCastleKMacXofAdapter(128, SharedKMacKey, SharedKMacCustomization));
#if NET9_0_OR_GREATER
        if (System.Security.Cryptography.Kmac128.IsSupported)
            yield return new("KMAC-128", "KMAC-128 (OS)", () => new OSKmacXofAdapter(128, SharedKMacKey, SharedKMacCustomization));
#endif
    }

    /// <summary>KMAC256 XOF implementations.</summary>
    public static IEnumerable<XofAlgorithmType> KMac256()
    {
        yield return new("KMAC-256", "KMAC-256 (Managed)", () => CH.Mac.KMac256.Create(SimdSupport.None, SharedKMacKey, 64, "Benchmark"));
        yield return new("KMAC-256", "KMAC-256 (BouncyCastle)", () => new BouncyCastleKMacXofAdapter(256, SharedKMacKey, SharedKMacCustomization));
#if NET9_0_OR_GREATER
        if (System.Security.Cryptography.Kmac256.IsSupported)
            yield return new("KMAC-256", "KMAC-256 (OS)", () => new OSKmacXofAdapter(256, SharedKMacKey, SharedKMacCustomization));
#endif
    }

    #endregion

    #region BLAKE3

    /// <summary>BLAKE3 XOF implementations.</summary>
    public static IEnumerable<XofAlgorithmType> Blake3()
    {
        yield return new("BLAKE3", "BLAKE3 (Managed)", () => CH.Hash.Blake3.Create(SimdSupport.None, 32));
        if ((CH.Hash.Blake3.SimdSupport & SimdSupport.Ssse3) != 0)
        {
            yield return new("BLAKE3", "BLAKE3 (Ssse3)", () => CH.Hash.Blake3.Create(SimdSupport.Ssse3, 32));
        }
        yield return new("BLAKE3", "BLAKE3 (BouncyCastle)", () => new BouncyCastleIXofAdapter(new Blake3Digest(256)));
#if BLAKE3_NATIVE
        yield return new("BLAKE3", "BLAKE3 (Native)", () => new Blake3NativeXofAdapter());
#endif
    }

    #endregion

    #region Ascon

    /// <summary>Ascon-XOF128 implementations.</summary>
    public static IEnumerable<XofAlgorithmType> AsconXof128()
    {
        yield return new("Ascon-XOF128", "Ascon-XOF128 (Managed)", () => new CH.Hash.AsconXof128(32));
        yield return new("Ascon-XOF128", "Ascon-XOF128 (BouncyCastle)",
            () => new BouncyCastleIXofAdapter(new Org.BouncyCastle.Crypto.Digests.AsconXof128()));
    }

    #endregion
}
