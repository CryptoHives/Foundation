// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Security.Cryptography;

using System;

/// <summary>
/// Selects how a private key is protected when exported in the PKCS#8
/// <c>EncryptedPrivateKeyInfo</c> format.
/// </summary>
/// <remarks>
/// <para>
/// This is the one place the key-format surface deliberately differs from
/// <c>System.Security.Cryptography</c>, which passes a <c>PbeParameters</c> here. Two reasons:
/// </para>
/// <list type="bullet">
///   <item><description>
///     The base class library only gained <c>PbeParameters</c> in .NET Standard 2.1, and this
///     library targets .NET Framework 4.6.2 upward. Supplying the type ourselves would mean
///     defining it in a namespace we do not own, which collides with any consumer that also
///     references a package defining it.
///   </description></item>
///   <item><description>
///     <c>PbeParameters</c> names its pseudorandom function with <c>HashAlgorithmName</c>, an open
///     string wrapper, so an unencodable choice can only fail at export. PBES2 has a finite set of
///     pseudorandom functions - the ones RFC 8018 gives an OID - so <see cref="Pbkdf2Prf"/> makes
///     that a compile-time choice instead.
///   </description></item>
/// </list>
/// <para>
/// Every other member of the key-format surface keeps its in-box signature; only the nine
/// encrypted-export members take this type.
/// </para>
/// <para>
/// Exports always use PBES2 (RFC 8018 §6.2). Imports additionally accept the legacy PKCS#12
/// schemes, so nothing here constrains what can be read.
/// </para>
/// </remarks>
/// <example>
/// <code>
/// using CryptoHives.Foundation.Security.Cryptography;
/// using CryptoHives.Foundation.Security.Cryptography.Dsa;
///
/// var options = new PbeOptions(
///     PbeEncryptionAlgorithm.Aes256Cbc, Pbkdf2Prf.HmacSha256, iterationCount: 600_000);
///
/// using var key = MLDsa.GenerateKey(MLDsaAlgorithm.MLDsa65);
/// string pem = key.ExportEncryptedPkcs8PrivateKeyPem("correct horse", options);
/// </code>
/// </example>
public sealed class PbeOptions
{
    /// <summary>
    /// Initializes a new instance of the <see cref="PbeOptions"/> class.
    /// </summary>
    /// <param name="encryptionAlgorithm">The content encryption algorithm.</param>
    /// <param name="prf">The PBKDF2 pseudorandom function.</param>
    /// <param name="iterationCount">
    /// The PBKDF2 iteration count. OWASP recommends at least 600,000 for HMAC-SHA-256; the minimum
    /// enforced here is 1, because test vectors and interoperability fixtures legitimately use
    /// small counts.
    /// </param>
    /// <exception cref="ArgumentOutOfRangeException">
    /// <paramref name="encryptionAlgorithm"/> or <paramref name="prf"/> is
    /// <c>Unknown</c> or undefined, or <paramref name="iterationCount"/> is less than 1.
    /// </exception>
    /// <remarks>
    /// Validation happens here rather than at export, so a bad combination fails next to the line
    /// that chose it instead of several calls later.
    /// </remarks>
    public PbeOptions(PbeEncryptionAlgorithm encryptionAlgorithm, Pbkdf2Prf prf, int iterationCount)
    {
        if (encryptionAlgorithm is < PbeEncryptionAlgorithm.Aes128Cbc or > PbeEncryptionAlgorithm.Aes256Cbc)
        {
            throw new ArgumentOutOfRangeException(
                nameof(encryptionAlgorithm),
                encryptionAlgorithm,
                "Select one of the AES-CBC algorithms. The legacy PKCS#12 schemes can be read but not written.");
        }

        if (prf is < Pbkdf2Prf.HmacSha1 or > Pbkdf2Prf.HmacSha512)
        {
            throw new ArgumentOutOfRangeException(
                nameof(prf), prf, "Select one of the PBKDF2 pseudorandom functions RFC 8018 defines.");
        }

        if (iterationCount < 1)
        {
            throw new ArgumentOutOfRangeException(
                nameof(iterationCount), iterationCount, "The iteration count must be at least 1.");
        }

        EncryptionAlgorithm = encryptionAlgorithm;
        Prf = prf;
        IterationCount = iterationCount;
    }

    /// <summary>
    /// Gets the content encryption algorithm.
    /// </summary>
    public PbeEncryptionAlgorithm EncryptionAlgorithm { get; }

    /// <summary>
    /// Gets the PBKDF2 pseudorandom function.
    /// </summary>
    public Pbkdf2Prf Prf { get; }

    /// <summary>
    /// Gets the PBKDF2 iteration count.
    /// </summary>
    public int IterationCount { get; }
}
