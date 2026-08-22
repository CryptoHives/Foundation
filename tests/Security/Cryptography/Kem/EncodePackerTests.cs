// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace Cryptography.Tests.Kem;

using CryptoHives.Foundation.Security.Cryptography.Kem;
using NUnit.Framework;
using System;

/// <summary>
/// Pins the specialized ML-KEM bit packers against the generic bit-at-a-time implementation.
/// </summary>
/// <remarks>
/// The specialized routines for d ∈ {4, 5, 10, 11} exist purely for speed and must be
/// bit-for-bit identical to the generic loop they replace. Comparing the two directly across
/// every coefficient value is a stronger check than the ACVP vectors alone: the vectors
/// exercise whichever bit patterns the sampled polynomials happen to contain, while these
/// tests deliberately include the boundary values (0 and 2^d − 1) that a mis-stated shift is
/// most likely to mangle.
/// </remarks>
[TestFixture]
public class EncodePackerTests
{
    private const int RandomSeed = 0x4B454D50;

    /// <summary>The widths ML-KEM actually uses that have a specialized packer.</summary>
    private static readonly int[] SpecializedWidths = [4, 5, 10, 11];

    [Test]
    [TestCaseSource(nameof(SpecializedWidths))]
    public void Encode_MatchesGenericImplementation(int d)
    {
        short[] coeffs = RandomCoefficients(d);

        byte[] specialized = new byte[32 * d];
        byte[] generic = new byte[32 * d];

        Encode.ByteEncodeD(coeffs, d, specialized);
        Encode.ByteEncodeGeneric(coeffs, d, generic);

        Assert.That(specialized, Is.EqualTo(generic),
            $"Specialized d={d} packer must agree with the generic implementation.");
    }

    [Test]
    [TestCaseSource(nameof(SpecializedWidths))]
    public void Decode_MatchesGenericImplementation(int d)
    {
        byte[] packed = new byte[32 * d];
        new Random(RandomSeed + d).NextBytes(packed);

        short[] specialized = new short[MLKemParams.N];
        short[] generic = new short[MLKemParams.N];

        Encode.ByteDecodeD(packed, d, specialized);
        Encode.ByteDecodeGeneric(packed, d, generic);

        Assert.That(specialized, Is.EqualTo(generic),
            $"Specialized d={d} unpacker must agree with the generic implementation.");
    }

    [Test]
    [TestCaseSource(nameof(SpecializedWidths))]
    public void EncodeDecode_RoundTrips(int d)
    {
        short[] original = RandomCoefficients(d);

        byte[] packed = new byte[32 * d];
        Encode.ByteEncodeD(original, d, packed);

        short[] decoded = new short[MLKemParams.N];
        Encode.ByteDecodeD(packed, d, decoded);

        Assert.That(decoded, Is.EqualTo(original), $"d={d} must round-trip.");
    }

    [Test]
    [TestCaseSource(nameof(SpecializedWidths))]
    public void Encode_WritesExactlyItsOwnRegion(int d)
    {
        short[] coeffs = RandomCoefficients(d);

        // A destination longer than 32·d, pre-filled with a sentinel. The packer must write
        // its own bytes and leave everything after them untouched — the generic path used to
        // clear the whole remaining span, which silently destroyed adjacent ciphertext.
        const byte Sentinel = 0xA5;
        byte[] destination = new byte[(32 * d) + 64];
        destination.AsSpan().Fill(Sentinel);

        Encode.ByteEncodeD(coeffs, d, destination);

        Assert.That(destination.AsSpan((32 * d)).ToArray(), Is.All.EqualTo(Sentinel),
            $"d={d} packer must not write past 32·d bytes.");
    }

    [Test]
    [TestCaseSource(nameof(SpecializedWidths))]
    public void Encode_HandlesBoundaryCoefficients(int d)
    {
        int max = (1 << d) - 1;

        // All-zero and all-max are where an off-by-one shift shows up most reliably.
        foreach (short value in new short[] { 0, (short)max })
        {
            short[] coeffs = new short[MLKemParams.N];
            coeffs.AsSpan().Fill(value);

            byte[] specialized = new byte[32 * d];
            byte[] generic = new byte[32 * d];
            Encode.ByteEncodeD(coeffs, d, specialized);
            Encode.ByteEncodeGeneric(coeffs, d, generic);

            Assert.That(specialized, Is.EqualTo(generic),
                $"d={d} packer must agree with the generic implementation for coefficient {value}.");

            short[] decoded = new short[MLKemParams.N];
            Encode.ByteDecodeD(specialized, d, decoded);
            Assert.That(decoded, Is.All.EqualTo(value), $"d={d} must round-trip coefficient {value}.");
        }
    }

    private static short[] RandomCoefficients(int d)
    {
        var random = new Random(RandomSeed + d);
        int max = 1 << d;

        short[] coeffs = new short[MLKemParams.N];
        for (int i = 0; i < coeffs.Length; i++)
        {
            coeffs[i] = (short)random.Next(0, max);
        }

        // Force the extremes into the sample as well.
        coeffs[0] = 0;
        coeffs[1] = (short)(max - 1);
        coeffs[^1] = (short)(max - 1);

        return coeffs;
    }
}
