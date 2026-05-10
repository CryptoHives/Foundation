// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace Cryptography.Tests.Asymmetric.EC;

using System;
using System.Security.Cryptography;
using CryptoHives.Foundation.Security.Cryptography.Asymmetric.EC;
using NUnit.Framework;

[TestFixture]
[Parallelizable(ParallelScope.All)]
public class EcDhManagedTests
{
    [Test]
    [TestCase("nistP256")]
    [TestCase("nistP384")]
    [TestCase("nistP521")]
    public void SharedSecretAgreement(string curveName)
    {
#if NET462 || NETSTANDARD2_0
        var curve = ResolveCurve(curveName);

        using var alice = new EcDhManaged();
        using var bob = new EcDhManaged();

#if NETSTANDARD2_0
        alice.GenerateKey(curve);
        bob.GenerateKey(curve);
#else
        if (!string.Equals(curveName, "nistP256", StringComparison.Ordinal))
        {
            Assert.Ignore("Curve selection is limited on net462 polyfill path.");
        }
#endif

        var alicePub = alice.PublicKey.ToByteArray();
        var bobPub = bob.PublicKey.ToByteArray();

        ParsePublicBlob(alicePub, out _, out byte[] aliceX, out byte[] aliceY);
        ParsePublicBlob(bobPub, out _, out byte[] bobX, out byte[] bobY);

        byte[] aliceSecret = alice.DeriveRawSecretAgreement(bobX, bobY);
        byte[] bobSecret = bob.DeriveRawSecretAgreement(aliceX, aliceY);

        Assert.That(aliceSecret, Is.EqualTo(bobSecret));
#else
        var curve = ECCurve.CreateFromFriendlyName(curveName);

        // Generate two key pairs using BCL
        using var alice = ECDiffieHellman.Create(curve);
        using var bob = ECDiffieHellman.Create(curve);

        var aliceParams = alice.ExportParameters(true);
        var bobParams = bob.ExportParameters(true);

        // Alice computes shared secret with Bob's public key
        using var aliceManaged = new EcDhManaged();
        aliceManaged.ImportParameters(aliceParams);
        byte[] aliceSecret = aliceManaged.DeriveRawSecretAgreement(bob.ExportParameters(false));

        // Bob computes shared secret with Alice's public key
        using var bobManaged = new EcDhManaged();
        bobManaged.ImportParameters(bobParams);
        byte[] bobSecret = bobManaged.DeriveRawSecretAgreement(alice.ExportParameters(false));

        // Both should derive the same shared secret
        Assert.That(aliceSecret, Is.EqualTo(bobSecret));
#endif
    }

#if !(NET462 || NETSTANDARD2_0 || NETFRAMEWORK)
    [Test]
    [TestCase("nistP256")]
    [TestCase("nistP384")]
    public void CrossValidateWithBcl(string curveName)
    {
        var curve = ECCurve.CreateFromFriendlyName(curveName);

        using var alice = ECDiffieHellman.Create(curve);
        using var bob = ECDiffieHellman.Create(curve);

        var aliceParams = alice.ExportParameters(true);
        var bobPubParams = bob.ExportParameters(false);

        byte[] bclSecret = alice.DeriveRawSecretAgreement(bob.PublicKey);

        using var managed = new EcDhManaged();
        managed.ImportParameters(aliceParams);
        byte[] managedSecret = managed.DeriveRawSecretAgreement(bobPubParams);

        Assert.That(managedSecret, Is.EqualTo(bclSecret));
    }
#endif

    [Test]
    public void InvalidPublicKeyThrows()
    {
#if NET462 || NETSTANDARD2_0
        using var managed = new EcDhManaged();
        var badX = new byte[32];
        var badY = new byte[32];
        badX[31] = 1;
        badY[31] = 1;

        Assert.Throws<CryptographicException>(() => managed.DeriveRawSecretAgreement(badX, badY));
#else
        using var alice = ECDiffieHellman.Create(ECCurve.NamedCurves.nistP256);
        var aliceParams = alice.ExportParameters(true);

        using var managed = new EcDhManaged();
        managed.ImportParameters(aliceParams);

        var badParams = new ECParameters
        {
            Curve = ECCurve.NamedCurves.nistP256,
            Q = new ECPoint
            {
                X = new byte[32],
                Y = new byte[32]
            }
        };
        badParams.Q.X[31] = 1;
        badParams.Q.Y[31] = 1;

        Assert.Throws<CryptographicException>(() => managed.DeriveRawSecretAgreement(badParams));
#endif
    }

#if NET462 || NETSTANDARD2_0
    private static void ParsePublicBlob(byte[] blob, out string curveName, out byte[] x, out byte[] y)
    {
        int offset = 0;
        int curveLength = ReadInt(blob, ref offset);
        curveName = System.Text.Encoding.ASCII.GetString(blob, offset, curveLength);
        offset += curveLength;

        int xLength = ReadInt(blob, ref offset);
        x = new byte[xLength];
        Buffer.BlockCopy(blob, offset, x, 0, xLength);
        offset += xLength;

        int yLength = ReadInt(blob, ref offset);
        y = new byte[yLength];
        Buffer.BlockCopy(blob, offset, y, 0, yLength);
    }

    private static int ReadInt(byte[] buffer, ref int offset)
    {
        int value =
            (buffer[offset] << 24) |
            (buffer[offset + 1] << 16) |
            (buffer[offset + 2] << 8) |
            buffer[offset + 3];
        offset += 4;
        return value;
    }

#if NETSTANDARD2_0
    private static ECCurve ResolveCurve(string curveName)
    {
        return curveName switch
        {
            "nistP256" => ECCurve.NamedCurves.nistP256,
            "nistP384" => ECCurve.NamedCurves.nistP384,
            "nistP521" => ECCurve.NamedCurves.nistP521,
            _ => throw new ArgumentOutOfRangeException(nameof(curveName))
        };
    }
#endif
#endif
}
