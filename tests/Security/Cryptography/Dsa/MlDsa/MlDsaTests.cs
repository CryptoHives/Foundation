// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace Cryptography.Tests.Dsa.MlDsa;

using CryptoHives.Foundation.Security.Cryptography.Dsa;
using NUnit.Framework;
using System;

/// <summary>
/// Tests for the ML-DSA implementation (FIPS 204).
/// </summary>
[TestFixture]
[Parallelizable(ParallelScope.All)]
public class MlDsaTests
{
    private static readonly object[] AllParameterSets =
    [
        new object[] { "ML-DSA-44", new Func<IDsa>(() => MlDsa44.Create()), 1312, 2560, 2420 },
        new object[] { "ML-DSA-65", new Func<IDsa>(() => MlDsa65.Create()), 1952, 4032, 3309 },
        new object[] { "ML-DSA-87", new Func<IDsa>(() => MlDsa87.Create()), 2592, 4896, 4627 }
    ];

    [Test]
    [TestCaseSource(nameof(AllParameterSets))]
    public void ParameterSizes(string name, Func<IDsa> factory, int pkSize, int skSize, int sigSize)
    {
        using IDsa dsa = factory();
        Assert.That(dsa.AlgorithmName, Is.EqualTo(name));
        Assert.That(dsa.PublicKeySizeBytes, Is.EqualTo(pkSize));
        Assert.That(dsa.SecretKeySizeBytes, Is.EqualTo(skSize));
        Assert.That(dsa.SignatureSizeBytes, Is.EqualTo(sigSize));
    }

    [Test]
    [TestCaseSource(nameof(AllParameterSets))]
    public void SignVerify_RoundTrips(string name, Func<IDsa> factory, int pkSize, int skSize, int sigSize)
    {
        using IDsa dsa = factory();

        byte[] pk = new byte[pkSize];
        byte[] sk = new byte[skSize];
        dsa.GenerateKeyPair(pk, sk);

        byte[] message = new byte[137];
        for (int i = 0; i < message.Length; i++) message[i] = (byte)(i & 0xFF);

        byte[] signature = new byte[sigSize];
        dsa.Sign(sk, message, context: default, signature);

        Assert.That(dsa.Verify(pk, message, context: default, signature), Is.True,
            "A freshly created signature must verify.");
    }

    [Test]
    [TestCaseSource(nameof(AllParameterSets))]
    public void SignVerify_WithContext_RoundTrips(string name, Func<IDsa> factory, int pkSize, int skSize, int sigSize)
    {
        using IDsa dsa = factory();

        byte[] pk = new byte[pkSize];
        byte[] sk = new byte[skSize];
        dsa.GenerateKeyPair(pk, sk);

        byte[] message = new byte[64];
        byte[] context = new byte[17];
        for (int i = 0; i < context.Length; i++) context[i] = (byte)(0xC0 + i);

        byte[] signature = new byte[sigSize];
        dsa.Sign(sk, message, context, signature);

        Assert.That(dsa.Verify(pk, message, context, signature), Is.True);
        Assert.That(dsa.Verify(pk, message, context: default, signature), Is.False,
            "A signature bound to a context must not verify without it.");
    }

    [Test]
    [TestCaseSource(nameof(AllParameterSets))]
    public void DeterministicKeyGen_IsReproducible(string name, Func<IDsa> factory, int pkSize, int skSize, int sigSize)
    {
        using IDsa dsa = factory();

        byte[] seed = new byte[32];
        for (int i = 0; i < 32; i++) seed[i] = (byte)(i * 7 + 1);

        byte[] pk1 = new byte[pkSize];
        byte[] sk1 = new byte[skSize];
        dsa.GenerateKeyPair(seed, pk1, sk1);

        byte[] pk2 = new byte[pkSize];
        byte[] sk2 = new byte[skSize];
        dsa.GenerateKeyPair(seed, pk2, sk2);

        Assert.That(pk2, Is.EqualTo(pk1), "Same seed must produce the same public key.");
        Assert.That(sk2, Is.EqualTo(sk1), "Same seed must produce the same secret key.");
    }

    [Test]
    [TestCaseSource(nameof(AllParameterSets))]
    public void DeterministicSign_IsReproducible(string name, Func<IDsa> factory, int pkSize, int skSize, int sigSize)
    {
        using IDsa dsa = factory();

        byte[] pk = new byte[pkSize];
        byte[] sk = new byte[skSize];
        dsa.GenerateKeyPair(pk, sk);

        byte[] message = new byte[48];

        byte[] sig1 = new byte[sigSize];
        byte[] sig2 = new byte[sigSize];
        dsa.SignDeterministic(sk, message, context: default, sig1);
        dsa.SignDeterministic(sk, message, context: default, sig2);

        Assert.That(sig2, Is.EqualTo(sig1), "Deterministic signing must be reproducible.");
        Assert.That(dsa.Verify(pk, message, context: default, sig1), Is.True);
    }

    [Test]
    [TestCaseSource(nameof(AllParameterSets))]
    public void TamperedSignatureOrMessage_FailsVerification(string name, Func<IDsa> factory, int pkSize, int skSize, int sigSize)
    {
        using IDsa dsa = factory();

        byte[] pk = new byte[pkSize];
        byte[] sk = new byte[skSize];
        dsa.GenerateKeyPair(pk, sk);

        byte[] message = new byte[96];
        byte[] signature = new byte[sigSize];
        dsa.Sign(sk, message, context: default, signature);

        byte[] tamperedSig = (byte[])signature.Clone();
        tamperedSig[0] ^= 0x01;
        Assert.That(dsa.Verify(pk, message, context: default, tamperedSig), Is.False,
            "A tampered signature must not verify.");

        byte[] tamperedMsg = (byte[])message.Clone();
        tamperedMsg[0] ^= 0x01;
        Assert.That(dsa.Verify(pk, tamperedMsg, context: default, signature), Is.False,
            "A tampered message must not verify.");
    }

    [Test]
    public void InvalidSizes_Throw()
    {
        using IDsa dsa = MlDsa44.Create();
        byte[] pk = new byte[MlDsa44.PublicKeySizeBytesConst];
        byte[] sk = new byte[MlDsa44.SecretKeySizeBytesConst];
        byte[] sig = new byte[MlDsa44.SignatureSizeBytesConst];
        byte[] msg = new byte[8];

        Assert.That(() => dsa.GenerateKeyPair(new byte[16], pk, sk), Throws.InstanceOf<ArgumentException>());
        Assert.That(() => dsa.Sign(new byte[100], msg, default, sig), Throws.InstanceOf<ArgumentException>());
        Assert.That(() => dsa.Sign(sk, msg, new byte[256], sig), Throws.InstanceOf<ArgumentException>(),
            "Context longer than 255 bytes must be rejected.");
        Assert.That(() => dsa.Verify(new byte[100], msg, default, sig), Throws.InstanceOf<ArgumentException>());
        Assert.That(() => dsa.Verify(pk, msg, default, new byte[100]), Throws.InstanceOf<ArgumentException>());
    }

    [Test]
    public void Diagnostic_NttRoundTrip()
    {
        // NTT⁻¹(NTT(a) ∘ᵐ NTT(1)) must reproduce a: multiplying by the NTT of the
        // constant-one polynomial exercises forward NTT, Montgomery pointwise
        // multiplication, and the scaled inverse NTT together.
        int[] a = new int[256];
        int[] one = new int[256];
        var rng = new Random(42);
        for (int i = 0; i < 256; i++)
        {
            a[i] = rng.Next(0, MlDsaParams.Q);
        }

        one[0] = 1;

        int[] expected = (int[])a.Clone();

        Ntt.Forward(a);
        Ntt.Forward(one);
        int[] product = new int[256];
        Poly.PointwiseMontgomery(product, a, one);
        Ntt.Inverse(product);
        Poly.Reduce(product);
        Poly.ConditionalAddQ(product);

        Assert.That(product, Is.EqualTo(expected), "NTT round-trip through Montgomery pointwise multiplication failed.");
    }
}
