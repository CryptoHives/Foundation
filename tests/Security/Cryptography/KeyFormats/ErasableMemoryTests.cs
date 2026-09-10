// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace Cryptography.Tests.KeyFormats;

using CryptoHives.Foundation.Security.Cryptography;
using CryptoHives.Foundation.Security.Cryptography.Dsa;
using CryptoHives.Foundation.Security.Cryptography.Kem;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
#if NET
using System.Diagnostics.CodeAnalysis;
#endif
using System.Reflection;

/// <summary>
/// The rule that no public key-format member moves secret material through a
/// <see cref="string"/>, enforced against the shipped surface rather than restated in prose.
/// </summary>
/// <remarks>
/// <para>
/// A <see cref="string"/> is immutable: once a password or a plaintext private key is in one, it
/// stays on the managed heap until the collector happens to reuse that memory, and nothing the
/// caller or this library can do will overwrite it sooner. So the key-format surface takes
/// passwords as spans and writes plaintext PEM into a caller-owned buffer.
/// </para>
/// <para>
/// The members that broke the rule were not deleted - they are in the tree under
/// <c>#if SECURITY_REVIEW</c>, which no shipping build defines. The reflection test below is what
/// proves those fences are actually inactive: if one were dropped, or a new <see cref="string"/>
/// overload were added for convenience, the assembly would grow a member this test names and
/// fails on.
/// </para>
/// </remarks>
[TestFixture]
[Parallelizable(ParallelScope.All)]
public class ErasableMemoryTests
{
    private static readonly PbeOptions Pbe =
        new(PbeEncryptionAlgorithm.Aes256Cbc, Pbkdf2Prf.HmacSha256, 2048);

    /// <summary>
    /// The two members allowed to return a <see cref="string"/>, because what they return is
    /// public by construction: a public key, and ciphertext.
    /// </summary>
    private static readonly HashSet<string> PublicByConstruction =
    [
        "ExportSubjectPublicKeyInfoPem",
        "ExportEncryptedPkcs8PrivateKeyPem",
    ];

    [Test]
    public void NoPublicMemberTakesAPasswordAsAString()
    {
        using (Assert.EnterMultipleScope())
        {
            AssertNoStringPasswords<MLKem>();
            AssertNoStringPasswords<MLDsa>();
            AssertNoStringPasswords<SlhDsa>();
        }
    }

    [Test]
    public void NoPublicMemberReturnsPlaintextKeyMaterialAsAString()
    {
        using (Assert.EnterMultipleScope())
        {
            AssertNoSecretStringReturns<MLKem>();
            AssertNoSecretStringReturns<MLDsa>();
            AssertNoSecretStringReturns<SlhDsa>();
        }
    }

    [Test]
    public void TheOnlyPlaintextPemMembersAreTheOnesThatUseACallerBuffer()
    {
        using (Assert.EnterMultipleScope())
        {
            AssertPlaintextPemSurface<MLKem>();
            AssertPlaintextPemSurface<MLDsa>();
            AssertPlaintextPemSurface<SlhDsa>();
        }
    }

    [Test]
    public void GetPkcs8PrivateKeyPemSize_MatchesWhatTheExportWrites()
    {
        using var kem = MLKem.GenerateKey(MLKemAlgorithm.MLKem768);
        using var dsa = MLDsa.GenerateKey(MLDsaAlgorithm.MLDsa87);
        using var slh = SlhDsa.GenerateKey(SlhDsaAlgorithm.SlhDsaShake128f, pairwiseConsistencyTest: false);

        using (Assert.EnterMultipleScope())
        {
            AssertSizeAgrees(kem.GetPkcs8PrivateKeyPemSize(), kem.TryExportPkcs8PrivateKeyPem, "ML-KEM-768");
            AssertSizeAgrees(dsa.GetPkcs8PrivateKeyPemSize(), dsa.TryExportPkcs8PrivateKeyPem, "ML-DSA-87");
            AssertSizeAgrees(slh.GetPkcs8PrivateKeyPemSize(), slh.TryExportPkcs8PrivateKeyPem, "SLH-DSA-SHAKE-128f");
        }
    }

    [Test]
    public void TryExportPkcs8PrivateKeyPem_ReportsAShortBufferWithoutWritingToIt()
    {
        using var key = MLDsa.GenerateKey(MLDsaAlgorithm.MLDsa44);
        int size = key.GetPkcs8PrivateKeyPemSize();
        char[] oneShort = new char[size - 1];

        using (Assert.EnterMultipleScope())
        {
            Assert.That(key.TryExportPkcs8PrivateKeyPem(oneShort, out int charsWritten), Is.False);
            Assert.That(charsWritten, Is.Zero);
            Assert.That(oneShort, Is.All.EqualTo('\0'),
                "a failed export must leave no part of the private key in the buffer");
        }
    }

    [Test]
    public void TryExportPkcs8PrivateKeyPem_RoundTripsThroughImportFromPem()
    {
        using var key = MLDsa.GenerateKey(MLDsaAlgorithm.MLDsa65);
        char[] buffer = new char[key.GetPkcs8PrivateKeyPemSize()];

        try
        {
            Assert.That(key.TryExportPkcs8PrivateKeyPem(buffer, out int charsWritten), Is.True);

            using var imported = MLDsa.ImportFromPem(buffer.AsSpan(0, charsWritten));
            Assert.That(imported.ExportMLDsaPrivateSeed(), Is.EqualTo(key.ExportMLDsaPrivateSeed()));
        }
        finally
        {
            Array.Clear(buffer, 0, buffer.Length);
        }
    }

#if NET10_0_OR_GREATER
#pragma warning disable SYSLIB5006 // Post-quantum cryptography APIs may be experimental.

    [Test]
    public void TryExportPkcs8PrivateKeyPem_ProducesTheSameTextAsTheInBoxExport()
    {
        // The rewrite that removed the strings must not have changed the format. .NET 10 is the
        // independent reference; on the downlevel targets the PEM shape is pinned separately by
        // PemEncodingTests.
        if (!System.Security.Cryptography.MLDsa.IsSupported)
        {
            Assert.Ignore("The in-box ML-DSA implementation is not available on this platform.");
        }

        using var key = MLDsa.GenerateKey(MLDsaAlgorithm.MLDsa44);

        using var reference = System.Security.Cryptography.MLDsa.ImportPkcs8PrivateKey(
            key.ExportPkcs8PrivateKey());

        Assert.That(
            KeyFormatAssert.PrivateKeyPem(key.GetPkcs8PrivateKeyPemSize(), key.TryExportPkcs8PrivateKeyPem),
            Is.EqualTo(reference.ExportPkcs8PrivateKeyPem()));
    }

#pragma warning restore SYSLIB5006
#endif

    [Test]
    public void AFailedDecryptLeavesNoPlaintextInTheCallerBuffer()
    {
        using var key = MLKem.GenerateKey(MLKemAlgorithm.MLKem512);
        char[] password = "right".ToCharArray();
        byte[] encrypted = key.ExportEncryptedPkcs8PrivateKey(password, Pbe);

        // Overwrite the password the way a caller is expected to. The import below must then fail
        // on content alone, with nothing recoverable from the buffer that held it.
        Array.Clear(password, 0, password.Length);

        using (Assert.EnterMultipleScope())
        {
            Assert.That(
                () => MLKem.ImportEncryptedPkcs8PrivateKey(password, encrypted),
                Throws.InstanceOf<System.Security.Cryptography.CryptographicException>());
            Assert.That(password, Is.All.EqualTo('\0'));
        }
    }

    [Test]
    public void APasswordInACharArrayCanBeErasedAfterUse()
    {
        using var key = MLDsa.GenerateKey(MLDsaAlgorithm.MLDsa44);
        char[] password = "hunter2".ToCharArray();

        byte[] encrypted = key.ExportEncryptedPkcs8PrivateKey(password, Pbe);
        using var imported = MLDsa.ImportEncryptedPkcs8PrivateKey(password, encrypted);

        Assert.That(imported.ExportMLDsaPrivateSeed(), Is.EqualTo(key.ExportMLDsaPrivateSeed()));

        Array.Clear(password, 0, password.Length);
        Assert.That(password, Is.All.EqualTo('\0'),
            "the caller owns the password storage and can clear it - the point of the span overloads");
    }

    [Test]
    [TestCase("hunter2", TestName = "ASCII")]
    [TestCase("hünter", TestName = "non-ASCII")]
    [TestCase("pw🔐", TestName = "outside the BMP")]
    public void Utf8LiteralAndCharacterPasswordsAgreeUnderPbes2(string password)
    {
        // PBES2 encodes a character password as UTF-8, so the bytes a u8 literal produces are the
        // same bytes - for any text, not only ASCII. This is why "use u8 for a fixed password" is
        // safe advice for the scheme this library writes, and it is worth pinning: if the character
        // encoding ever changed, the documented equivalence would silently stop holding.
        using var key = MLDsa.GenerateKey(MLDsaAlgorithm.MLDsa44);

        char[] chars = password.ToCharArray();
        byte[] utf8 = System.Text.Encoding.UTF8.GetBytes(chars);

        byte[] writtenWithChars = key.ExportEncryptedPkcs8PrivateKey(chars, Pbe);

        using var openedWithBytes = MLDsa.ImportEncryptedPkcs8PrivateKey(utf8, writtenWithChars);
        Assert.That(openedWithBytes.ExportMLDsaPrivateSeed(), Is.EqualTo(key.ExportMLDsaPrivateSeed()));
    }

    [Test]
    public void ABytePasswordThatIsNotValidUtf8IsUnreachableFromAnyCharacterPassword()
    {
        // The other half of the same rule, and the reason the byte overload exists at all: these
        // three bytes are not the UTF-8 encoding of any string, so no character password derives
        // this key.
        using var key = MLDsa.GenerateKey(MLDsaAlgorithm.MLDsa44);
        byte[] notUtf8 = [0x00, 0xFF, 0x10];

        byte[] encrypted = key.ExportEncryptedPkcs8PrivateKey(notUtf8, Pbe);

        using (Assert.EnterMultipleScope())
        {
            using var viaBytes = MLDsa.ImportEncryptedPkcs8PrivateKey(notUtf8, encrypted);
            Assert.That(viaBytes.ExportMLDsaPrivateSeed(), Is.EqualTo(key.ExportMLDsaPrivateSeed()));

            Assert.That(
                () => MLDsa.ImportEncryptedPkcs8PrivateKey(" ÿ".AsSpan(), encrypted),
                Throws.InstanceOf<System.Security.Cryptography.CryptographicException>(),
                "the closest character password must not open it");
        }
    }

    [Test]
    public void TryExportSubjectPublicKeyInfoPem_MatchesTheAllocatingExport()
    {
        using var key = MLDsa.GenerateKey(MLDsaAlgorithm.MLDsa65);
        int size = key.GetSubjectPublicKeyInfoPemSize();
        char[] buffer = new char[size];

        using (Assert.EnterMultipleScope())
        {
            Assert.That(key.TryExportSubjectPublicKeyInfoPem(buffer, out int charsWritten), Is.True);
            Assert.That(charsWritten, Is.EqualTo(size), "the reported size must be exact");
            Assert.That(new string(buffer, 0, charsWritten),
                Is.EqualTo(key.ExportSubjectPublicKeyInfoPem()));
        }
    }

    [Test]
    public void TryExportEncryptedPkcs8PrivateKeyPem_RoundTripsThroughBothPasswordOverloads()
    {
        using var key = MLDsa.GenerateKey(MLDsaAlgorithm.MLDsa44);
        char[] password = "hunter2".ToCharArray();
        char[] buffer = new char[8192];

        using (Assert.EnterMultipleScope())
        {
            Assert.That(
                key.TryExportEncryptedPkcs8PrivateKeyPem(password, Pbe, buffer, out int viaChars),
                Is.True);
            using var fromChars = MLDsa.ImportFromEncryptedPem(buffer.AsSpan(0, viaChars), password);
            Assert.That(fromChars.ExportMLDsaPrivateSeed(), Is.EqualTo(key.ExportMLDsaPrivateSeed()));

            Assert.That(
                key.TryExportEncryptedPkcs8PrivateKeyPem("hunter2"u8, Pbe, buffer, out int viaBytes),
                Is.True);
            using var fromBytes = MLDsa.ImportFromEncryptedPem(buffer.AsSpan(0, viaBytes), "hunter2"u8);
            Assert.That(fromBytes.ExportMLDsaPrivateSeed(), Is.EqualTo(key.ExportMLDsaPrivateSeed()));
        }

        Array.Clear(password, 0, password.Length);
    }

    [Test]
    public void TheParityMembersAsymmetricAlgorithmOffersAreAllPresent()
    {
        // AsymmetricAlgorithm - the base RSA, ECDsa and DSA inherit - carries a Span<char> PEM
        // export for each of the three encodings. The in-box PQC types carry none of them. These
        // do, and this test is what keeps that true.
        using (Assert.EnterMultipleScope())
        {
            AssertPemParity<MLKem>();
            AssertPemParity<MLDsa>();
            AssertPemParity<SlhDsa>();
        }
    }

    private static void AssertNoStringPasswords<
#if NET
        [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicMethods)]
#endif
        T>()
    {
        List<string> offenders = [];

        foreach (MethodInfo method in PublicMethods<T>())
        {
            foreach (ParameterInfo parameter in method.GetParameters())
            {
                if (parameter.ParameterType == typeof(string)
                    && parameter.Name?.IndexOf("password", StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    offenders.Add($"{typeof(T).Name}.{method.Name}({parameter.Name})");
                }
            }
        }

        Assert.That(offenders, Is.Empty,
            "a password in a string cannot be erased; take ReadOnlySpan<char> or ReadOnlySpan<byte>");
    }

    private static void AssertNoSecretStringReturns<
#if NET
        [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicMethods)]
#endif
        T>()
    {
        List<string> offenders = PublicMethods<T>()
            .Where(m => m.ReturnType == typeof(string) && !PublicByConstruction.Contains(m.Name))
            .Select(m => $"{typeof(T).Name}.{m.Name}")
            .ToList();

        Assert.That(offenders, Is.Empty,
            "only a public key or ciphertext may be returned as a string; everything else must "
            + "write into a caller-owned buffer");
    }

    private static void AssertPlaintextPemSurface<
#if NET
        [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicMethods)]
#endif
        T>()
    {
        string name = typeof(T).Name;
        MethodInfo[] methods = PublicMethods<T>().ToArray();

        Assert.That(methods.Any(m => m.Name == "ExportPkcs8PrivateKeyPem"), Is.False,
            $"{name}: the allocating plaintext-PEM export must not be in the shipped surface");
        Assert.That(methods.Any(m => m.Name == "TryExportPkcs8PrivateKeyPem"), Is.True, name);
        Assert.That(methods.Any(m => m.Name == "GetPkcs8PrivateKeyPemSize"), Is.True,
            $"{name}: a TryExport with no way to size the buffer is unusable");

        Assert.That(
            methods.Any(m => m.Name == "ImportFromPem"
                && m.GetParameters() is [{ ParameterType: var p }] && p == typeof(string)),
            Is.False,
            $"{name}: a plaintext-key PEM document handed in as a string cannot be erased");
        Assert.That(methods.Any(m => m.Name == "ImportFromPem"), Is.True, name);
    }

    private static void AssertPemParity<
#if NET
        [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicMethods)]
#endif
        T>()
    {
        string name = typeof(T).Name;
        MethodInfo[] methods = PublicMethods<T>().ToArray();

        foreach (string member in new[]
        {
            "TryExportPkcs8PrivateKeyPem",
            "TryExportSubjectPublicKeyInfoPem",
            "TryExportEncryptedPkcs8PrivateKeyPem",
        })
        {
            Assert.That(methods.Any(m => m.Name == member), Is.True, $"{name}.{member}");
        }
    }

    private static IEnumerable<MethodInfo> PublicMethods<
#if NET
        [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicMethods)]
#endif
        T>()
        => typeof(T).GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static)
            .Where(m => !m.IsSpecialName && m.DeclaringType == typeof(T));

    private static void AssertSizeAgrees(int size, KeyFormatAssert.TryExportPem tryExport, string label)
    {
        char[] buffer = new char[size];

        try
        {
            Assert.That(tryExport(buffer, out int charsWritten), Is.True, label);
            Assert.That(charsWritten, Is.EqualTo(size), label);
        }
        finally
        {
            Array.Clear(buffer, 0, buffer.Length);
        }
    }
}
