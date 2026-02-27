// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Security.Cryptography.Kdf;

using CryptoHives.Foundation.Security.Cryptography.Mac;
using NUnit.Framework;
using System;
using System.Text;

[TestFixture]
[Parallelizable(ParallelScope.All)]
public sealed class KbkdfTests
{
    // Key: 0x01..0x20 (32 bytes)
    private static readonly byte[] TestKey = CreateSequentialKey(32);

    private static readonly byte[] TestLabel = Encoding.UTF8.GetBytes("encryption");
    private static readonly byte[] TestContext = Encoding.UTF8.GetBytes("session-001");

    private static byte[] CreateSequentialKey(int length)
    {
        byte[] key = new byte[length];
        for (int i = 0; i < length; i++)
            key[i] = (byte)(i + 1);
        return key;
    }

    private static HmacFactory Sha256Factory => key => new HmacSha256(key);
    private static HmacFactory Sha384Factory => key => new HmacSha384(key);
    private static HmacFactory Sha512Factory => key => new HmacSha512(key);

    // -------------------------------------------------------------------
    // Known-answer tests (vectors generated via .NET IncrementalHash HMAC)
    // Format: [i]₄ ‖ Label ‖ 0x00 ‖ Context ‖ [L]₄  (counter before fixed)
    // -------------------------------------------------------------------

    [Test]
    public void Sha256With32ByteOutput()
    {
        byte[] expected = Convert.FromHexString(
            "4CF30DA1E591E846467CEBBCBD1C656B568154FB8EFA0FBE48DC1129E5334058");

        byte[] result = Kbkdf.DeriveKey(Sha256Factory, TestKey, 32, TestLabel, TestContext);

        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Sha256With64ByteOutputTwoIterations()
    {
        byte[] expected = Convert.FromHexString(
            "BCCD5B19A501B55C5F2C8FB332C23E77AD465633AA919D8DC3A14A8409C040EC" +
            "39118AC074A9F58BBD0D64DCBA6953CB35A1ACC86409B0C0356DCFF4E18B5141");

        byte[] result = Kbkdf.DeriveKey(Sha256Factory, TestKey, 64, TestLabel, TestContext);

        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Sha256With16BytePartialBlock()
    {
        byte[] expected = Convert.FromHexString(
            "D39F05AF190AFD73C1E1565F81F2474F");

        byte[] result = Kbkdf.DeriveKey(Sha256Factory, TestKey, 16, TestLabel, TestContext);

        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Sha512With64ByteOutput()
    {
        byte[] expected = Convert.FromHexString(
            "82D33336EFE3290B26875A091E7CD67CFE85137C9EE400EBC33314AE4E308F04" +
            "C0E5FDC2C85150470BF1378211C636C47328E43C3B3207C204CFA2DB615C13A0");

        byte[] result = Kbkdf.DeriveKey(Sha512Factory, TestKey, 64, TestLabel, TestContext);

        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Sha256WithEmptyLabelAndContext()
    {
        byte[] expected = Convert.FromHexString(
            "F8B724820DF0EFEA81C252B67A8860B644D3C37B9FCE782458214F14C661C00A");

        byte[] result = Kbkdf.DeriveKey(Sha256Factory, TestKey, 32);

        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Sha384With48ByteOutput()
    {
        byte[] expected = Convert.FromHexString(
            "1A3786038AFA521267B3853A161555CBCE7B05F9AEECDD80" +
            "B15B9063F42E52C450A43C9711C8493D4BC33658501D9331");

        byte[] result = Kbkdf.DeriveKey(Sha384Factory, TestKey, 48, TestLabel, TestContext);

        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Sha256SingleByteOutput()
    {
        byte[] expected = Convert.FromHexString("4A");

        byte[] result = Kbkdf.DeriveKey(Sha256Factory, TestKey, 1, TestLabel, TestContext);

        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Sha256With100BytesFourIterations()
    {
        byte[] expected = Convert.FromHexString(
            "AD0D2F7B58370446C8CF188045DF0BEEAEC385DA8CDEBDB15F115F4CB44853C4" +
            "F1E00076BF9AE3877E5EA5540AFF64D2C9188AC2E892A569A46DE931C5B6E017" +
            "B8F75A933D9B11E02E03B5197A1C7672EDE202202365FB734639AF8D733F0C6C" +
            "2CBDE989");

        // 100 bytes = 3 full SHA-256 blocks (96) + 4 bytes partial
        byte[] result = Kbkdf.DeriveKey(Sha256Factory, TestKey, 100, TestLabel, TestContext);

        Assert.That(result, Is.EqualTo(expected));
    }

    // -------------------------------------------------------------------
    // Span and array API consistency
    // -------------------------------------------------------------------

    [Test]
    public void SpanAndArrayApisProduceSameResult()
    {
        byte[] arrayResult = Kbkdf.DeriveKey(Sha256Factory, TestKey, 32, TestLabel, TestContext);

        Span<byte> spanResult = stackalloc byte[32];
        Kbkdf.DeriveKey(Sha256Factory, TestKey, spanResult, TestLabel, TestContext);

        Assert.That(spanResult.ToArray(), Is.EqualTo(arrayResult));
    }

    // -------------------------------------------------------------------
    // AES-CMAC as PRF
    // -------------------------------------------------------------------

    [Test]
    public void DeriveKeyWithAesCmac()
    {
        byte[] key = new byte[16]; // AES-128
        for (int i = 0; i < 16; i++) key[i] = (byte)(i + 0x10);

        HmacFactory cmacFactory = k => AesCmac.Create(k);

        // AES-CMAC produces 16-byte MACs, so 32 bytes requires 2 iterations
        byte[] result = Kbkdf.DeriveKey(cmacFactory, key, 32, TestLabel, TestContext);

        Assert.That(result, Has.Length.EqualTo(32));

        // Verify deterministic
        byte[] result2 = Kbkdf.DeriveKey(cmacFactory, key, 32, TestLabel, TestContext);
        Assert.That(result2, Is.EqualTo(result));
    }

    // -------------------------------------------------------------------
    // Multiple derivations from same key with different labels
    // -------------------------------------------------------------------

    [Test]
    public void DifferentLabelsProduceDifferentKeys()
    {
        byte[] enc = Kbkdf.DeriveKey(Sha256Factory, TestKey, 32,
            Encoding.UTF8.GetBytes("encryption"), TestContext);
        byte[] auth = Kbkdf.DeriveKey(Sha256Factory, TestKey, 32,
            Encoding.UTF8.GetBytes("authentication"), TestContext);
        byte[] iv = Kbkdf.DeriveKey(Sha256Factory, TestKey, 32,
            Encoding.UTF8.GetBytes("iv"), TestContext);

        Assert.That(enc, Is.Not.EqualTo(auth));
        Assert.That(enc, Is.Not.EqualTo(iv));
        Assert.That(auth, Is.Not.EqualTo(iv));
    }

    [Test]
    public void DifferentContextsProduceDifferentKeys()
    {
        byte[] s1 = Kbkdf.DeriveKey(Sha256Factory, TestKey, 32,
            TestLabel, Encoding.UTF8.GetBytes("session-001"));
        byte[] s2 = Kbkdf.DeriveKey(Sha256Factory, TestKey, 32,
            TestLabel, Encoding.UTF8.GetBytes("session-002"));

        Assert.That(s1, Is.Not.EqualTo(s2));
    }

    // -------------------------------------------------------------------
    // Parameter validation
    // -------------------------------------------------------------------

    [Test]
    public void NullFactoryThrows()
    {
        Assert.Throws<ArgumentNullException>(
            () => Kbkdf.DeriveKey(null!, TestKey, 32, TestLabel, TestContext));
    }

    [Test]
    public void NullKeyThrows()
    {
        Assert.Throws<ArgumentNullException>(
            () => Kbkdf.DeriveKey(Sha256Factory, null!, 32, TestLabel, TestContext));
    }

    [Test]
    public void ZeroOutputLengthThrows()
    {
        Assert.Throws<ArgumentOutOfRangeException>(
            () => Kbkdf.DeriveKey(Sha256Factory, TestKey, 0, TestLabel, TestContext));
    }

    [Test]
    public void NegativeOutputLengthThrows()
    {
        Assert.Throws<ArgumentOutOfRangeException>(
            () => Kbkdf.DeriveKey(Sha256Factory, TestKey, -1, TestLabel, TestContext));
    }

    [Test]
    public void EmptyOutputSpanThrows()
    {
        Assert.Throws<ArgumentException>(
            () => Kbkdf.DeriveKey(Sha256Factory, TestKey, Span<byte>.Empty, TestLabel, TestContext));
    }

    // -------------------------------------------------------------------
    // Determinism
    // -------------------------------------------------------------------

    [Test]
    public void SameInputsProduceSameOutput()
    {
        byte[] r1 = Kbkdf.DeriveKey(Sha256Factory, TestKey, 32, TestLabel, TestContext);
        byte[] r2 = Kbkdf.DeriveKey(Sha256Factory, TestKey, 32, TestLabel, TestContext);

        Assert.That(r1, Is.EqualTo(r2));
    }
}
