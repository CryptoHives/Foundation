// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

#pragma warning disable CA1508 // Avoid dead conditional code - Deliberately asserts the null == null branch of the equality operator

namespace Cryptography.Tests.Dsa.SlhDsa;

using NUnit.Framework;
using System;
using System.Collections.Generic;
using CH = CryptoHives.Foundation.Security.Cryptography.Dsa;
using OS = System.Security.Cryptography;

/// <summary>
/// Tests for the parts of <see cref="CH.SlhDsa"/> that exist to mirror
/// <c>System.Security.Cryptography.SlhDsa</c> member for member.
/// </summary>
/// <remarks>
/// <para>
/// The counterpart of <c>MLDsaApiTests</c>. <c>SlhDsaTests</c> covers signing and verification
/// behaviour; what is checked here is drop-in compatibility itself — the exact member names, the
/// <c>byte[]</c> overloads that sit beside the span ones, value equality on the algorithm
/// descriptors, the always-true <c>IsSupported</c>, and the pairwise-consistency-test opt-out.
/// </para>
/// <para>
/// <see cref="ApiSurface_MatchesTheInBoxType"/> is the load-bearing one: it is a compile-time
/// assertion, not a runtime one.
/// </para>
/// </remarks>
[TestFixture]
[Parallelizable(ParallelScope.All)]
public class SlhDsaApiTests
{
    /// <summary>
    /// The fast parameter sets. Signing with an <c>s</c> set costs on the order of a million
    /// hash invocations, and nothing tested here depends on which set is used.
    /// </summary>
    private static readonly CH.SlhDsaAlgorithm[] Algorithms =
    [
        CH.SlhDsaAlgorithm.SlhDsaSha2_128f,
        CH.SlhDsaAlgorithm.SlhDsaShake128f,
        CH.SlhDsaAlgorithm.SlhDsaShake192f,
    ];

    [Test]
    public void IsSupported_IsAlwaysTrue()
    {
        // Unlike the in-box SlhDsa, the managed implementation never depends on OS support --
        // and for SLH-DSA that gap is wide: no shipping Windows exposes it through CNG.
        Assert.That(CH.SlhDsa.IsSupported, Is.True);
    }

    [Test]
    public void GenerateKey_PctOptOut_ProducesUsableKeys()
    {
        using var dsa = CH.SlhDsa.GenerateKey(CH.SlhDsaAlgorithm.SlhDsaShake128f, pairwiseConsistencyTest: false);

        byte[] message = new byte[32];
        Assert.That(dsa.VerifyData(message, dsa.SignData(message)), Is.True);
    }

    [Test]
    [TestCaseSource(nameof(Algorithms))]
    public void ByteArrayOverloads_BehaveLikeTheSpanOverloads(CH.SlhDsaAlgorithm algorithm)
    {
        using var original = CH.SlhDsa.GenerateKey(algorithm, pairwiseConsistencyTest: false);
        byte[] message = [1, 2, 3, 4, 5];
        byte[] context = "ctx"u8.ToArray();

        // Every import has a byte[] overload alongside the span one, as the in-box type has.
        using var fromPrivateKey = CH.SlhDsa.ImportSlhDsaPrivateKey(algorithm, original.ExportSlhDsaPrivateKey());
        using var fromPublicKey = CH.SlhDsa.ImportSlhDsaPublicKey(algorithm, original.ExportSlhDsaPublicKey());

        byte[] signature = fromPrivateKey.SignData(message, context);

        using (Assert.EnterMultipleScope())
        {
            Assert.That(fromPrivateKey.ExportSlhDsaPublicKey(), Is.EqualTo(original.ExportSlhDsaPublicKey()));
            Assert.That(fromPublicKey.VerifyData(message, signature, context), Is.True);
            Assert.That(fromPublicKey.VerifyData(message, signature), Is.False,
                "The byte[] overload must bind the context just as the span overload does.");
        }

        Assert.That(() => CH.SlhDsa.ImportSlhDsaPrivateKey(algorithm, (byte[])null!),
            Throws.InstanceOf<ArgumentNullException>());
        Assert.That(() => CH.SlhDsa.ImportSlhDsaPublicKey(algorithm, (byte[])null!),
            Throws.InstanceOf<ArgumentNullException>());
        Assert.That(() => fromPrivateKey.SignData((byte[])null!),
            Throws.InstanceOf<ArgumentNullException>());
        Assert.That(() => fromPublicKey.VerifyData((byte[])null!, signature),
            Throws.InstanceOf<ArgumentNullException>());
        Assert.That(() => fromPublicKey.VerifyData(message, (byte[])null!),
            Throws.InstanceOf<ArgumentNullException>());
    }

    [Test]
    public void AlgorithmDescriptors_HaveValueEquality()
    {
        CH.SlhDsaAlgorithm shake128f = CH.SlhDsaAlgorithm.SlhDsaShake128f;
        CH.SlhDsaAlgorithm sha2128f = CH.SlhDsaAlgorithm.SlhDsaSha2_128f;
        CH.SlhDsaAlgorithm shake256s = CH.SlhDsaAlgorithm.SlhDsaShake256s;
        CH.SlhDsaAlgorithm? nothing = null;
        object foreignType = "SLH-DSA-SHAKE-128f";

        using (Assert.EnterMultipleScope())
        {
            Assert.That(shake128f == CH.SlhDsaAlgorithm.SlhDsaShake128f, Is.True);
            Assert.That(shake128f != sha2128f, Is.True);
            Assert.That(shake128f.Equals(CH.SlhDsaAlgorithm.SlhDsaShake128f), Is.True);
            Assert.That(shake128f.Equals((object)CH.SlhDsaAlgorithm.SlhDsaShake128f), Is.True);
            Assert.That(shake128f.Equals(shake256s), Is.False);
            Assert.That(shake128f.Equals(nothing), Is.False);
            Assert.That(shake128f.Equals(foreignType), Is.False, "Equals(object) must reject other types.");

            // Null handling must not throw and must not report a match.
            Assert.That(nothing == sha2128f, Is.False);
            Assert.That(sha2128f == nothing, Is.False);
            Assert.That(nothing == null, Is.True);
        }

        // The behavioural point of GetHashCode: the singletons work as dictionary keys.
        var seen = new HashSet<CH.SlhDsaAlgorithm>(AllTwelve());
        using (Assert.EnterMultipleScope())
        {
            Assert.That(seen, Has.Count.EqualTo(12), "The twelve parameter sets must be distinct.");
            Assert.That(seen, Does.Contain(CH.SlhDsaAlgorithm.SlhDsaSha2_256s));
        }
    }

    [Test]
    public void AlgorithmDescriptors_ExposeThePrivateKeySizeUnderTheInBoxName()
    {
        // Renamed from SecretKeySizeInBytes: the in-box SlhDsaAlgorithm calls it
        // PrivateKeySizeInBytes, and a drop-in has to agree.
        using (Assert.EnterMultipleScope())
        {
            Assert.That(CH.SlhDsaAlgorithm.SlhDsaSha2_128s.PrivateKeySizeInBytes, Is.EqualTo(64));
            Assert.That(CH.SlhDsaAlgorithm.SlhDsaShake192f.PrivateKeySizeInBytes, Is.EqualTo(96));
            Assert.That(CH.SlhDsaAlgorithm.SlhDsaShake256f.PrivateKeySizeInBytes, Is.EqualTo(128));
        }
    }

#if NET10_0_OR_GREATER
#pragma warning disable SYSLIB5006 // Post-quantum cryptography APIs may be experimental.

    /// <summary>
    /// Asserts, at compile time, that the managed type can stand in for the in-box one.
    /// </summary>
    /// <remarks>
    /// <para>
    /// The two methods below are the same source written twice, differing only in the type
    /// prefix. That is the whole point: if a member is renamed, re-typed, or loses an overload
    /// on either side, one of them stops compiling and this file fails the build rather than
    /// failing a run. A runtime assertion could not catch a signature change at all — the code
    /// that used the old name would simply not exist.
    /// </para>
    /// <para>
    /// The in-box half is skipped at run time where the platform has no SLH-DSA, which is
    /// currently everywhere on Windows. It still compiles, and compiling is what is being
    /// tested.
    /// </para>
    /// </remarks>
    [Test]
    public void ApiSurface_MatchesTheInBoxType()
    {
        byte[] message = [9, 8, 7];
        byte[] context = "ctx"u8.ToArray();

        ExerciseManaged(message, context);

        if (!OS.SlhDsa.IsSupported)
        {
            Assert.Ignore("System.Security.Cryptography.SlhDsa is not supported on this platform; "
                + "the in-box half of this test compiled, which is what it exists to prove.");
        }

        ExerciseInBox(message, context);
    }

    private static void ExerciseManaged(byte[] message, byte[] context)
    {
        CH.SlhDsaAlgorithm algorithm = CH.SlhDsaAlgorithm.SlhDsaShake128f;

        using CH.SlhDsa signer = CH.SlhDsa.GenerateKey(algorithm);
        Assert.That(signer.Algorithm, Is.EqualTo(algorithm));

        byte[] privateKey = signer.ExportSlhDsaPrivateKey();
        byte[] publicKey = signer.ExportSlhDsaPublicKey();
        Assert.That(privateKey, Has.Length.EqualTo(algorithm.PrivateKeySizeInBytes));
        Assert.That(publicKey, Has.Length.EqualTo(algorithm.PublicKeySizeInBytes));

        byte[] signature = new byte[algorithm.SignatureSizeInBytes];
        signer.SignData(new ReadOnlySpan<byte>(message), new Span<byte>(signature), context);

        using CH.SlhDsa fromPrivate = CH.SlhDsa.ImportSlhDsaPrivateKey(algorithm, privateKey);
        using CH.SlhDsa fromPublic = CH.SlhDsa.ImportSlhDsaPublicKey(algorithm, publicKey);

        Assert.That(fromPublic.VerifyData(message, signature, context), Is.True);
        Assert.That(fromPublic.VerifyData(message, fromPrivate.SignData(message, context), context), Is.True);
    }

    private static void ExerciseInBox(byte[] message, byte[] context)
    {
        OS.SlhDsaAlgorithm algorithm = OS.SlhDsaAlgorithm.SlhDsaShake128f;

        using OS.SlhDsa signer = OS.SlhDsa.GenerateKey(algorithm);
        Assert.That(signer.Algorithm, Is.EqualTo(algorithm));

        byte[] privateKey = signer.ExportSlhDsaPrivateKey();
        byte[] publicKey = signer.ExportSlhDsaPublicKey();
        Assert.That(privateKey, Has.Length.EqualTo(algorithm.PrivateKeySizeInBytes));
        Assert.That(publicKey, Has.Length.EqualTo(algorithm.PublicKeySizeInBytes));

        byte[] signature = new byte[algorithm.SignatureSizeInBytes];
        signer.SignData(new ReadOnlySpan<byte>(message), new Span<byte>(signature), context);

        using OS.SlhDsa fromPrivate = OS.SlhDsa.ImportSlhDsaPrivateKey(algorithm, privateKey);
        using OS.SlhDsa fromPublic = OS.SlhDsa.ImportSlhDsaPublicKey(algorithm, publicKey);

        Assert.That(fromPublic.VerifyData(message, signature, context), Is.True);
        Assert.That(fromPublic.VerifyData(message, fromPrivate.SignData(message, context), context), Is.True);
    }

#pragma warning restore SYSLIB5006
#endif

    private static IEnumerable<CH.SlhDsaAlgorithm> AllTwelve()
    {
        yield return CH.SlhDsaAlgorithm.SlhDsaSha2_128s;
        yield return CH.SlhDsaAlgorithm.SlhDsaShake128s;
        yield return CH.SlhDsaAlgorithm.SlhDsaSha2_128f;
        yield return CH.SlhDsaAlgorithm.SlhDsaShake128f;
        yield return CH.SlhDsaAlgorithm.SlhDsaSha2_192s;
        yield return CH.SlhDsaAlgorithm.SlhDsaShake192s;
        yield return CH.SlhDsaAlgorithm.SlhDsaSha2_192f;
        yield return CH.SlhDsaAlgorithm.SlhDsaShake192f;
        yield return CH.SlhDsaAlgorithm.SlhDsaSha2_256s;
        yield return CH.SlhDsaAlgorithm.SlhDsaShake256s;
        yield return CH.SlhDsaAlgorithm.SlhDsaSha2_256f;
        yield return CH.SlhDsaAlgorithm.SlhDsaShake256f;
    }
}
