// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Security.Cryptography.Asymmetric.X509;

using System;
using System.Collections.Generic;

/// <summary>
/// Describes the status flags from X.509 certificate chain validation.
/// </summary>
[Flags]
public enum ChainValidationStatus
{
    /// <summary>No errors; chain is valid.</summary>
    Valid = 0,

    /// <summary>The chain could not be built to a trusted root.</summary>
    UntrustedRoot = 1 << 0,

    /// <summary>A certificate in the chain has an invalid signature.</summary>
    InvalidSignature = 1 << 1,

    /// <summary>A certificate in the chain is expired or not yet valid.</summary>
    NotTimeValid = 1 << 2,

    /// <summary>An intermediate or root is not marked as a CA.</summary>
    InvalidBasicConstraints = 1 << 3,

    /// <summary>A CA certificate does not have the keyCertSign key usage.</summary>
    InvalidKeyUsage = 1 << 4,

    /// <summary>The path length constraint was exceeded.</summary>
    PathLengthExceeded = 1 << 5,

    /// <summary>Issuer name does not match subject name of the signer.</summary>
    NameMismatch = 1 << 6,

    /// <summary>A certificate in the chain has been revoked.</summary>
    Revoked = 1 << 7,
}

/// <summary>
/// Contains the result of an X.509 certificate chain validation.
/// </summary>
/// <remarks>
/// The <see cref="Chain"/> list is ordered from leaf to root when the chain
/// could be fully built, or contains only the certificates that were successfully
/// linked when the chain is incomplete.
/// </remarks>
public sealed class ChainValidationResult
{
    /// <summary>
    /// Gets a value indicating whether the chain is valid (no errors).
    /// </summary>
    public bool IsValid => Status == ChainValidationStatus.Valid;

    /// <summary>
    /// Gets the combined validation status flags.
    /// </summary>
    public ChainValidationStatus Status { get; }

    /// <summary>
    /// Gets the ordered certificate chain from leaf to root.
    /// </summary>
    public IReadOnlyList<X509Certificate> Chain { get; }

    /// <summary>
    /// Gets detailed error messages for each validation failure.
    /// </summary>
    public IReadOnlyList<string> Errors { get; }

    /// <summary>
    /// Initializes a new <see cref="ChainValidationResult"/>.
    /// </summary>
    /// <param name="status">The validation status flags.</param>
    /// <param name="chain">The certificate chain from leaf to root.</param>
    /// <param name="errors">The error messages.</param>
    internal ChainValidationResult(
        ChainValidationStatus status,
        IReadOnlyList<X509Certificate> chain,
        IReadOnlyList<string> errors)
    {
        Status = status;
        Chain = chain;
        Errors = errors;
    }
}
