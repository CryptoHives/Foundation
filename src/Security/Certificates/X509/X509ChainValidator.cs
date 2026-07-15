// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Security.Certificates.X509;

using System;
using System.Collections.Generic;
using System.Linq;

/// <summary>
/// Validates X.509 certificate chains per RFC 5280 §6.
/// </summary>
/// <remarks>
/// <para>
/// The validator builds a chain from a leaf certificate to a trusted root,
/// checking signatures, validity periods, basic constraints, key usage,
/// path length constraints, and name chaining at each step.
/// </para>
/// <para>
/// Optional CRL-based revocation checking is supported by providing
/// <see cref="X509Crl"/> instances to the <see cref="Validate"/> method.
/// </para>
/// </remarks>
public static class X509ChainValidator
{
    /// <summary>
    /// Validates a certificate chain from leaf to a trusted root.
    /// </summary>
    /// <param name="leaf">The end-entity certificate to validate.</param>
    /// <param name="intermediates">Intermediate CA certificates (may be empty).</param>
    /// <param name="trustedRoots">Trusted root CA certificates.</param>
    /// <param name="crls">Optional CRLs for revocation checking (may be null or empty).</param>
    /// <param name="validationTime">The time at which to validate. If null, uses <see cref="DateTimeOffset.UtcNow"/>.</param>
    /// <returns>A <see cref="ChainValidationResult"/> indicating whether the chain is valid.</returns>
    /// <exception cref="ArgumentNullException">
    /// <paramref name="leaf"/>, <paramref name="intermediates"/>, or <paramref name="trustedRoots"/> is <c>null</c>.
    /// </exception>
    public static ChainValidationResult Validate(
        X509Certificate leaf,
        IReadOnlyList<X509Certificate> intermediates,
        IReadOnlyList<X509Certificate> trustedRoots,
        IReadOnlyList<X509Crl>? crls = null,
        DateTimeOffset? validationTime = null)
    {
        if (leaf is null) throw new ArgumentNullException(nameof(leaf));
        if (intermediates is null) throw new ArgumentNullException(nameof(intermediates));
        if (trustedRoots is null) throw new ArgumentNullException(nameof(trustedRoots));

        DateTimeOffset now = validationTime ?? DateTimeOffset.UtcNow;
        var chain = new List<X509Certificate> { leaf };
        var errors = new List<string>();
        var status = ChainValidationStatus.Valid;

        // Build chain from leaf to root.
        bool chainComplete = BuildChain(chain, intermediates, trustedRoots);
        if (!chainComplete)
        {
            status |= ChainValidationStatus.UntrustedRoot;
            errors.Add("The chain could not be built to a trusted root.");
        }

        // Validate each certificate in the chain.
        for (int i = 0; i < chain.Count; i++)
        {
            X509Certificate cert = chain[i];

            // Time validity.
            if (now < cert.NotBefore || now > cert.NotAfter)
            {
                status |= ChainValidationStatus.NotTimeValid;
                errors.Add($"Certificate '{cert.Subject}' is not time-valid at {now:O}.");
            }

            // Basic Constraints for non-leaf certs.
            if (i > 0)
            {
                X509Extension? bcExt = cert.Extensions.GetExtension(X509ExtensionCollection.OidBasicConstraints);
                if (bcExt is null || !ExtensionParsers.BasicConstraints.Parse(bcExt.Value).IsCA)
                {
                    status |= ChainValidationStatus.InvalidBasicConstraints;
                    errors.Add($"Certificate '{cert.Subject}' is not a CA but appears as an issuer.");
                }
            }

            // Key Usage for non-leaf certs.
            if (i > 0)
            {
                X509Extension? kuExt = cert.Extensions.GetExtension(X509ExtensionCollection.OidKeyUsage);
                if (kuExt is not null)
                {
                    KeyUsage flags = ExtensionParsers.KeyUsage.Parse(kuExt.Value);
                    if ((flags & KeyUsage.KeyCertSign) == 0)
                    {
                        status |= ChainValidationStatus.InvalidKeyUsage;
                        errors.Add($"Certificate '{cert.Subject}' lacks keyCertSign key usage.");
                    }
                }
            }

            // Signature verification.
            if (i < chain.Count - 1)
            {
                if (!X509CertificateValidator.VerifySignature(chain[i], chain[i + 1]))
                {
                    status |= ChainValidationStatus.InvalidSignature;
                    errors.Add($"Certificate '{cert.Subject}' has an invalid signature.");
                }
            }
            else if (cert.IsSelfSigned)
            {
                if (!X509CertificateValidator.VerifySelfSigned(cert))
                {
                    status |= ChainValidationStatus.InvalidSignature;
                    errors.Add($"Self-signed certificate '{cert.Subject}' has an invalid signature.");
                }
            }

            // Name chaining.
            if (i < chain.Count - 1)
            {
                if (!cert.Issuer.Equals(chain[i + 1].Subject))
                {
                    status |= ChainValidationStatus.NameMismatch;
                    errors.Add($"Certificate '{cert.Subject}' issuer does not match signer subject.");
                }
            }
        }

        // Path length constraints (check from root down).
        ValidatePathLength(chain, errors, ref status);

        // CRL revocation checking.
        if (crls is not null && crls.Count > 0)
        {
            CheckRevocation(chain, crls, errors, ref status);
        }

        return new ChainValidationResult(status, chain.AsReadOnly(), errors.AsReadOnly());
    }

    private static bool BuildChain(
        List<X509Certificate> chain,
        IReadOnlyList<X509Certificate> intermediates,
        IReadOnlyList<X509Certificate> trustedRoots)
    {
        int maxLength = intermediates.Count + trustedRoots.Count + 1;
        X509Certificate current = chain[0];

        while (true)
        {
            if (current.IsSelfSigned && IsTrustedRoot(current, trustedRoots))
            {
                return true;
            }

            X509Certificate? issuer = FindIssuer(current, trustedRoots) ?? FindIssuer(current, intermediates);
            if (issuer is null)
            {
                return false;
            }

            chain.Add(issuer);
            current = issuer;

            if (chain.Count > maxLength)
            {
                return false;
            }
        }
    }

    private static bool IsTrustedRoot(X509Certificate cert, IReadOnlyList<X509Certificate> trustedRoots)
    {
        for (int i = 0; i < trustedRoots.Count; i++)
        {
            if (ReferenceEquals(cert, trustedRoots[i]))
            {
                return true;
            }
        }

        return false;
    }

    private static X509Certificate? FindIssuer(X509Certificate cert, IReadOnlyList<X509Certificate> candidates)
    {
        // Try AKI/SKI matching first.
        X509Extension? akiExt = cert.Extensions.GetExtension(X509ExtensionCollection.OidAuthorityKeyIdentifier);
        if (akiExt is not null)
        {
            (byte[]? akiKeyId, _, _) = ExtensionParsers.AuthorityKeyIdentifier.Parse(akiExt.Value);
            if (akiKeyId is not null)
            {
                for (int i = 0; i < candidates.Count; i++)
                {
                    X509Certificate candidate = candidates[i];
                    if (!candidate.Subject.Equals(cert.Issuer))
                    {
                        continue;
                    }

                    X509Extension? skiExt = candidate.Extensions.GetExtension(
                        X509ExtensionCollection.OidSubjectKeyIdentifier);
                    if (skiExt is not null)
                    {
                        byte[] skiBytes = ExtensionParsers.SubjectKeyIdentifier.Parse(skiExt.Value);
                        if (akiKeyId.SequenceEqual(skiBytes))
                        {
                            return candidate;
                        }
                    }
                }
            }
        }

        // Fallback to name matching only.
        for (int i = 0; i < candidates.Count; i++)
        {
            X509Certificate candidate = candidates[i];
            if (candidate.Subject.Equals(cert.Issuer) && !ReferenceEquals(candidate, cert))
            {
                return candidate;
            }
        }

        return null;
    }

    private static void ValidatePathLength(
        List<X509Certificate> chain,
        List<string> errors,
        ref ChainValidationStatus status)
    {
        for (int i = chain.Count - 1; i >= 1; i--)
        {
            X509Certificate cert = chain[i];
            X509Extension? bcExt = cert.Extensions.GetExtension(X509ExtensionCollection.OidBasicConstraints);
            if (bcExt is null)
            {
                continue;
            }

            (_, int? pathLen) = ExtensionParsers.BasicConstraints.Parse(bcExt.Value);
            if (!pathLen.HasValue)
            {
                continue;
            }

            // Count CA certificates below this one, excluding the leaf.
            int caCertsBelow = 0;
            for (int j = i - 1; j >= 1; j--)
            {
                caCertsBelow++;
            }

            if (caCertsBelow > pathLen.Value)
            {
                status |= ChainValidationStatus.PathLengthExceeded;
                errors.Add($"Certificate '{cert.Subject}' path length constraint ({pathLen.Value}) exceeded ({caCertsBelow} CA certs below).");
            }
        }
    }

    private static void CheckRevocation(
        List<X509Certificate> chain,
        IReadOnlyList<X509Crl> crls,
        List<string> errors,
        ref ChainValidationStatus status)
    {
        for (int i = 0; i < chain.Count - 1; i++)
        {
            X509Certificate cert = chain[i];
            X509Certificate issuer = chain[i + 1];

            for (int j = 0; j < crls.Count; j++)
            {
                X509Crl crl = crls[j];
                if (crl.Issuer.Equals(issuer.Subject) && crl.IsRevoked(cert))
                {
                    status |= ChainValidationStatus.Revoked;
                    errors.Add($"Certificate '{cert.Subject}' has been revoked.");
                }
            }
        }
    }
}
