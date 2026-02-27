// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

#pragma warning disable CS0618 // SHA-1 obsolete warning — intentionally tested for RFC 6070 compliance

namespace Cryptography.Tests.Kdf;

using CryptoHives.Foundation.Security.Cryptography.Kdf;
using CryptoHives.Foundation.Security.Cryptography.Mac;
using NUnit.Framework;
using System;
using System.Text;

/// <summary>
/// Tests for <see cref="Pbkdf2"/> using RFC 6070 test vectors (HMAC-SHA-1),
/// and known-answer vectors generated with .NET <c>Rfc2898DeriveBytes</c> for
/// HMAC-SHA-256, HMAC-SHA-384, and HMAC-SHA-512.
/// </summary>
[TestFixture]
[Parallelizable(ParallelScope.All)]
public class Pbkdf2Tests
{
    private static readonly HmacFactory Sha256Factory = key => new HmacSha256(key);
    private static readonly HmacFactory Sha384Factory = key => new HmacSha384(key);
    private static readonly HmacFactory Sha512Factory = key => new HmacSha512(key);
    private static readonly HmacFactory Sha1Factory = key => new HmacSha1(key);

    // ---------------------------------------------------------------
    // RFC 6070 test vectors (PBKDF2-HMAC-SHA-1)
    // ---------------------------------------------------------------

    #region RFC 6070 — PBKDF2-HMAC-SHA-1

    /// <summary>
    /// RFC 6070, Test Vector 1: P = "password", S = "salt", c = 1, dkLen = 20.
    /// </summary>
    [Test]
    public void Rfc6070Vector1Sha1Iterations1()
    {
        byte[] expected = TestHelpers.FromHexString("0C60C80F961F0E71F3A9B524AF6012062FE037A6");

        byte[] dk = Pbkdf2.DeriveKey(
            Sha1Factory,
            Encoding.UTF8.GetBytes("password"),
            Encoding.UTF8.GetBytes("salt"),
            iterations: 1,
            outputLength: 20);

        Assert.That(dk, Is.EqualTo(expected));
    }

    /// <summary>
    /// RFC 6070, Test Vector 2: P = "password", S = "salt", c = 2, dkLen = 20.
    /// </summary>
    [Test]
    public void Rfc6070Vector2Sha1Iterations2()
    {
        byte[] expected = TestHelpers.FromHexString("EA6C014DC72D6F8CCD1ED92ACE1D41F0D8DE8957");

        byte[] dk = Pbkdf2.DeriveKey(
            Sha1Factory,
            Encoding.UTF8.GetBytes("password"),
            Encoding.UTF8.GetBytes("salt"),
            iterations: 2,
            outputLength: 20);

        Assert.That(dk, Is.EqualTo(expected));
    }

    /// <summary>
    /// RFC 6070, Test Vector 3: P = "password", S = "salt", c = 4096, dkLen = 20.
    /// </summary>
    [Test]
    public void Rfc6070Vector3Sha1Iterations4096()
    {
        byte[] expected = TestHelpers.FromHexString("4B007901B765489ABEAD49D926F721D065A429C1");

        byte[] dk = Pbkdf2.DeriveKey(
            Sha1Factory,
            Encoding.UTF8.GetBytes("password"),
            Encoding.UTF8.GetBytes("salt"),
            iterations: 4096,
            outputLength: 20);

        Assert.That(dk, Is.EqualTo(expected));
    }

    #endregion

    // ---------------------------------------------------------------
    // PBKDF2-HMAC-SHA-256 known-answer vectors
    // ---------------------------------------------------------------

    #region HMAC-SHA-256 known-answer vectors

    /// <summary>
    /// PBKDF2-HMAC-SHA-256: P = "password", S = "salt", c = 1, dkLen = 32.
    /// </summary>
    [Test]
    public void Sha256Iterations1()
    {
        byte[] expected = TestHelpers.FromHexString(
            "120FB6CFFCF8B32C43E7225256C4F837A86548C92CCC35480805987CB70BE17B");

        byte[] dk = Pbkdf2.DeriveKey(
            Sha256Factory,
            Encoding.UTF8.GetBytes("password"),
            Encoding.UTF8.GetBytes("salt"),
            iterations: 1,
            outputLength: 32);

        Assert.That(dk, Is.EqualTo(expected));
    }

    /// <summary>
    /// PBKDF2-HMAC-SHA-256: P = "password", S = "salt", c = 2, dkLen = 32.
    /// </summary>
    [Test]
    public void Sha256Iterations2()
    {
        byte[] expected = TestHelpers.FromHexString(
            "AE4D0C95AF6B46D32D0ADFF928F06DD02A303F8EF3C251DFD6E2D85A95474C43");

        byte[] dk = Pbkdf2.DeriveKey(
            Sha256Factory,
            Encoding.UTF8.GetBytes("password"),
            Encoding.UTF8.GetBytes("salt"),
            iterations: 2,
            outputLength: 32);

        Assert.That(dk, Is.EqualTo(expected));
    }

    /// <summary>
    /// PBKDF2-HMAC-SHA-256: P = "password", S = "salt", c = 4096, dkLen = 32.
    /// </summary>
    [Test]
    public void Sha256Iterations4096()
    {
        byte[] expected = TestHelpers.FromHexString(
            "C5E478D59288C841AA530DB6845C4C8D962893A001CE4E11A4963873AA98134A");

        byte[] dk = Pbkdf2.DeriveKey(
            Sha256Factory,
            Encoding.UTF8.GetBytes("password"),
            Encoding.UTF8.GetBytes("salt"),
            iterations: 4096,
            outputLength: 32);

        Assert.That(dk, Is.EqualTo(expected));
    }

    /// <summary>
    /// PBKDF2-HMAC-SHA-256: longer password and salt, c = 4096, dkLen = 40.
    /// </summary>
    [Test]
    public void Sha256LongPasswordAndSalt()
    {
        byte[] expected = TestHelpers.FromHexString(
            "348C89DBCBD32B2F32D814B8116E84CF2B17347EBC1800181C4E2A1FB8DD53E1" +
            "C635518C7DAC47E9");

        byte[] dk = Pbkdf2.DeriveKey(
            Sha256Factory,
            Encoding.UTF8.GetBytes("passwordPASSWORDpassword"),
            Encoding.UTF8.GetBytes("saltSALTsaltSALTsaltSALTsaltSALTsalt"),
            iterations: 4096,
            outputLength: 40);

        Assert.That(dk, Is.EqualTo(expected));
    }

    /// <summary>
    /// PBKDF2-HMAC-SHA-256: single zero-byte password and salt, c = 4096, dkLen = 16.
    /// </summary>
    [Test]
    public void Sha256ZeroBytePwAndSalt()
    {
        byte[] expected = TestHelpers.FromHexString("89EC8BBA7838C5427F56A7FAAE0CDE48");

        byte[] dk = Pbkdf2.DeriveKey(
            Sha256Factory,
            [0],
            [0],
            iterations: 4096,
            outputLength: 16);

        Assert.That(dk, Is.EqualTo(expected));
    }

    /// <summary>
    /// PBKDF2-HMAC-SHA-256: multi-block output (64 bytes = 2 × SHA-256 blocks).
    /// </summary>
    [Test]
    public void Sha256MultiBlockOutput()
    {
        byte[] expected = TestHelpers.FromHexString(
            "120FB6CFFCF8B32C43E7225256C4F837A86548C92CCC35480805987CB70BE17B" +
            "4DBF3A2F3DAD3377264BB7B8E8330D4EFC7451418617DABEF683735361CDC18C");

        byte[] dk = Pbkdf2.DeriveKey(
            Sha256Factory,
            Encoding.UTF8.GetBytes("password"),
            Encoding.UTF8.GetBytes("salt"),
            iterations: 1,
            outputLength: 64);

        Assert.That(dk, Is.EqualTo(expected));
    }

    #endregion

    // ---------------------------------------------------------------
    // PBKDF2-HMAC-SHA-384 known-answer vectors
    // ---------------------------------------------------------------

    #region HMAC-SHA-384 known-answer vectors

    /// <summary>
    /// PBKDF2-HMAC-SHA-384: P = "password", S = "salt", c = 1, dkLen = 48.
    /// </summary>
    [Test]
    public void Sha384Iterations1()
    {
        byte[] expected = TestHelpers.FromHexString(
            "C0E14F06E49E32D73F9F52DDF1D0C5C7191609233631DADD76A567DB42B78676" +
            "B38FC800CC53DDB642F5C74442E62BE4");

        byte[] dk = Pbkdf2.DeriveKey(
            Sha384Factory,
            Encoding.UTF8.GetBytes("password"),
            Encoding.UTF8.GetBytes("salt"),
            iterations: 1,
            outputLength: 48);

        Assert.That(dk, Is.EqualTo(expected));
    }

    /// <summary>
    /// PBKDF2-HMAC-SHA-384: P = "password", S = "salt", c = 4096, dkLen = 48.
    /// </summary>
    [Test]
    public void Sha384Iterations4096()
    {
        byte[] expected = TestHelpers.FromHexString(
            "559726BE38DB125BC85ED7895F6E3CF574C7A01C080C3447DB1E8A76764DEB3C" +
            "307B94853FBE424F6488C5F4F1289626");

        byte[] dk = Pbkdf2.DeriveKey(
            Sha384Factory,
            Encoding.UTF8.GetBytes("password"),
            Encoding.UTF8.GetBytes("salt"),
            iterations: 4096,
            outputLength: 48);

        Assert.That(dk, Is.EqualTo(expected));
    }

    #endregion

    // ---------------------------------------------------------------
    // PBKDF2-HMAC-SHA-512 known-answer vectors
    // ---------------------------------------------------------------

    #region HMAC-SHA-512 known-answer vectors

    /// <summary>
    /// PBKDF2-HMAC-SHA-512: P = "password", S = "salt", c = 1, dkLen = 64.
    /// </summary>
    [Test]
    public void Sha512Iterations1()
    {
        byte[] expected = TestHelpers.FromHexString(
            "867F70CF1ADE02CFF3752599A3A53DC4AF34C7A669815AE5D513554E1C8CF252" +
            "C02D470A285A0501BAD999BFE943C08F050235D7D68B1DA55E63F73B60A57FCE");

        byte[] dk = Pbkdf2.DeriveKey(
            Sha512Factory,
            Encoding.UTF8.GetBytes("password"),
            Encoding.UTF8.GetBytes("salt"),
            iterations: 1,
            outputLength: 64);

        Assert.That(dk, Is.EqualTo(expected));
    }

    /// <summary>
    /// PBKDF2-HMAC-SHA-512: P = "password", S = "salt", c = 4096, dkLen = 64.
    /// </summary>
    [Test]
    public void Sha512Iterations4096()
    {
        byte[] expected = TestHelpers.FromHexString(
            "D197B1B33DB0143E018B12F3D1D1479E6CDEBDCC97C5C0F87F6902E072F457B5" +
            "143F30602641B3D55CD335988CB36B84376060ECD532E039B742A239434AF2D5");

        byte[] dk = Pbkdf2.DeriveKey(
            Sha512Factory,
            Encoding.UTF8.GetBytes("password"),
            Encoding.UTF8.GetBytes("salt"),
            iterations: 4096,
            outputLength: 64);

        Assert.That(dk, Is.EqualTo(expected));
    }

    #endregion

    // ---------------------------------------------------------------
    // Cross-validation with .NET Rfc2898DeriveBytes
    // ---------------------------------------------------------------

    #region Cross-validation

#if NET8_0_OR_GREATER
    /// <summary>
    /// Cross-validates CryptoHives PBKDF2 against .NET
    /// <see cref="System.Security.Cryptography.Rfc2898DeriveBytes.Pbkdf2(byte[], byte[], int, System.Security.Cryptography.HashAlgorithmName, int)"/>.
    /// </summary>
    [Test]
    public void CrossValidateWithDotNetSha256()
    {
        byte[] password = Encoding.UTF8.GetBytes("cross-validation-test");
        byte[] salt = Encoding.UTF8.GetBytes("unique-salt-value-123");

        byte[] dotnet = System.Security.Cryptography.Rfc2898DeriveBytes.Pbkdf2(
            password, salt, iterations: 10_000,
            System.Security.Cryptography.HashAlgorithmName.SHA256, outputLength: 32);

        byte[] ours = Pbkdf2.DeriveKey(Sha256Factory, password, salt, iterations: 10_000, outputLength: 32);

        Assert.That(ours, Is.EqualTo(dotnet));
    }

    /// <summary>
    /// Cross-validates CryptoHives PBKDF2 against .NET with SHA-512.
    /// </summary>
    [Test]
    public void CrossValidateWithDotNetSha512()
    {
        byte[] password = Encoding.UTF8.GetBytes("another-password");
        byte[] salt = Encoding.UTF8.GetBytes("another-salt-456");

        byte[] dotnet = System.Security.Cryptography.Rfc2898DeriveBytes.Pbkdf2(
            password, salt, iterations: 5_000,
            System.Security.Cryptography.HashAlgorithmName.SHA512, outputLength: 64);

        byte[] ours = Pbkdf2.DeriveKey(Sha512Factory, password, salt, iterations: 5_000, outputLength: 64);

        Assert.That(ours, Is.EqualTo(dotnet));
    }
#endif

    #endregion

    // ---------------------------------------------------------------
    // Span overload tests
    // ---------------------------------------------------------------

    #region Span overloads

    /// <summary>
    /// Verifies the span-based overload produces the same result as the array overload.
    /// </summary>
    [Test]
    public void SpanOverloadMatchesArrayOverload()
    {
        byte[] password = Encoding.UTF8.GetBytes("password");
        byte[] salt = Encoding.UTF8.GetBytes("salt");

        byte[] arrayResult = Pbkdf2.DeriveKey(Sha256Factory, password, salt, iterations: 4096, outputLength: 32);

        byte[] spanResult = new byte[32];
        Pbkdf2.DeriveKey(Sha256Factory, password, salt, iterations: 4096, spanResult);

        Assert.That(spanResult, Is.EqualTo(arrayResult));
    }

    /// <summary>
    /// Verifies that a partial last block is correctly truncated.
    /// </summary>
    [Test]
    public void PartialBlockTruncation()
    {
        byte[] password = Encoding.UTF8.GetBytes("password");
        byte[] salt = Encoding.UTF8.GetBytes("salt");

        // 10 bytes = less than one HMAC-SHA-256 block (32 bytes)
        byte[] full = Pbkdf2.DeriveKey(Sha256Factory, password, salt, iterations: 1, outputLength: 32);
        byte[] partial = Pbkdf2.DeriveKey(Sha256Factory, password, salt, iterations: 1, outputLength: 10);

        Assert.That(partial, Is.EqualTo(full.AsSpan(0, 10).ToArray()));
    }

    #endregion

    // ---------------------------------------------------------------
    // Behavioral tests
    // ---------------------------------------------------------------

    #region Behavioral tests

    /// <summary>
    /// Different passwords produce different derived keys.
    /// </summary>
    [Test]
    public void DifferentPasswordsProduceDifferentKeys()
    {
        byte[] salt = Encoding.UTF8.GetBytes("common-salt");
        byte[] dk1 = Pbkdf2.DeriveKey(Sha256Factory, Encoding.UTF8.GetBytes("password1"), salt, 1000, 32);
        byte[] dk2 = Pbkdf2.DeriveKey(Sha256Factory, Encoding.UTF8.GetBytes("password2"), salt, 1000, 32);

        Assert.That(dk1, Is.Not.EqualTo(dk2));
    }

    /// <summary>
    /// Different salts produce different derived keys.
    /// </summary>
    [Test]
    public void DifferentSaltsProduceDifferentKeys()
    {
        byte[] password = Encoding.UTF8.GetBytes("password");
        byte[] dk1 = Pbkdf2.DeriveKey(Sha256Factory, password, Encoding.UTF8.GetBytes("salt1"), 1000, 32);
        byte[] dk2 = Pbkdf2.DeriveKey(Sha256Factory, password, Encoding.UTF8.GetBytes("salt2"), 1000, 32);

        Assert.That(dk1, Is.Not.EqualTo(dk2));
    }

    /// <summary>
    /// Different iteration counts produce different derived keys.
    /// </summary>
    [Test]
    public void DifferentIterationsProduceDifferentKeys()
    {
        byte[] password = Encoding.UTF8.GetBytes("password");
        byte[] salt = Encoding.UTF8.GetBytes("salt");
        byte[] dk1 = Pbkdf2.DeriveKey(Sha256Factory, password, salt, 1000, 32);
        byte[] dk2 = Pbkdf2.DeriveKey(Sha256Factory, password, salt, 2000, 32);

        Assert.That(dk1, Is.Not.EqualTo(dk2));
    }

    /// <summary>
    /// PBKDF2 is deterministic — same inputs produce the same output.
    /// </summary>
    [Test]
    public void Deterministic()
    {
        byte[] password = Encoding.UTF8.GetBytes("password");
        byte[] salt = Encoding.UTF8.GetBytes("salt");
        byte[] dk1 = Pbkdf2.DeriveKey(Sha256Factory, password, salt, 100, 32);
        byte[] dk2 = Pbkdf2.DeriveKey(Sha256Factory, password, salt, 100, 32);

        Assert.That(dk1, Is.EqualTo(dk2));
    }

    /// <summary>
    /// Single-byte output works correctly.
    /// </summary>
    [Test]
    public void SingleByteOutput()
    {
        byte[] password = Encoding.UTF8.GetBytes("password");
        byte[] salt = Encoding.UTF8.GetBytes("salt");

        byte[] full = Pbkdf2.DeriveKey(Sha256Factory, password, salt, 1, 32);
        byte[] single = Pbkdf2.DeriveKey(Sha256Factory, password, salt, 1, 1);

        Assert.That(single, Has.Length.EqualTo(1));
        Assert.That(single[0], Is.EqualTo(full[0]));
    }

    /// <summary>
    /// Empty salt is allowed and produces a valid result.
    /// </summary>
    [Test]
    public void EmptySaltIsAllowed()
    {
        byte[] password = Encoding.UTF8.GetBytes("password");
        byte[] dk = Pbkdf2.DeriveKey(Sha256Factory, password, [], 1, 32);

        Assert.That(dk, Has.Length.EqualTo(32));
    }

    #endregion

    // ---------------------------------------------------------------
    // Parameter validation
    // ---------------------------------------------------------------

    #region Validation

    /// <summary>
    /// Null factory throws <see cref="ArgumentNullException"/>.
    /// </summary>
    [Test]
    public void NullFactoryThrows()
    {
        Assert.Throws<ArgumentNullException>(() =>
            Pbkdf2.DeriveKey(null!, [1], [1], 1, 32));
    }

    /// <summary>
    /// Null password throws <see cref="ArgumentNullException"/>.
    /// </summary>
    [Test]
    public void NullPasswordThrows()
    {
        Assert.Throws<ArgumentNullException>(() =>
            Pbkdf2.DeriveKey(Sha256Factory, null!, [1], 1, 32));
    }

    /// <summary>
    /// Null salt throws <see cref="ArgumentNullException"/>.
    /// </summary>
    [Test]
    public void NullSaltThrows()
    {
        Assert.Throws<ArgumentNullException>(() =>
            Pbkdf2.DeriveKey(Sha256Factory, [1], null!, 1, 32));
    }

    /// <summary>
    /// Zero iterations throws <see cref="ArgumentOutOfRangeException"/>.
    /// </summary>
    [Test]
    public void ZeroIterationsThrows()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() =>
            Pbkdf2.DeriveKey(Sha256Factory, [1], [1], 0, 32));
    }

    /// <summary>
    /// Negative iterations throws <see cref="ArgumentOutOfRangeException"/>.
    /// </summary>
    [Test]
    public void NegativeIterationsThrows()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() =>
            Pbkdf2.DeriveKey(Sha256Factory, [1], [1], -1, 32));
    }

    /// <summary>
    /// Zero output length throws <see cref="ArgumentOutOfRangeException"/>.
    /// </summary>
    [Test]
    public void ZeroOutputLengthThrows()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() =>
            Pbkdf2.DeriveKey(Sha256Factory, [1], [1], 1, 0));
    }

    /// <summary>
    /// Empty output span throws <see cref="ArgumentException"/>.
    /// </summary>
    [Test]
    public void EmptyOutputSpanThrows()
    {
        Assert.Throws<ArgumentException>(() =>
            Pbkdf2.DeriveKey(Sha256Factory, new byte[] { 1 }, new byte[] { 1 }, 1, Span<byte>.Empty));
    }

    #endregion
}
