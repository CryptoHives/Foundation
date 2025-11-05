// SPDX-FileCopyrightText: 2025 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

#pragma warning disable CS1591 // self describing enum values, suppress warning

namespace CryptoHives.Security.Certificates.X509Crl;

/// <summary>
/// CRL Reason codes.
/// </summary>
/// <remarks>
/// id-ce-cRLReasons OBJECT IDENTIFIER ::= { id-ce 21 }
///   -- reasonCode::= { CRLReason }
/// CRLReason::= ENUMERATED {
///      unspecified(0),
///      keyCompromise(1),
///      cACompromise(2),
///      affiliationChanged(3),
///      superseded(4),
///      cessationOfOperation(5),
///      certificateHold(6),
///           --value 7 is not used
///      removeFromCRL(8),
///      privilegeWithdrawn(9),
///      aACompromise(10) }
/// </remarks>
public enum CRLReason
{
    Unspecified = 0,
    KeyCompromise = 1,
    CACompromise = 2,
    AffiliationChanged = 3,
    Superseded = 4,
    CessationOfOperation = 5,
    CertificateHold = 6,
    RemoveFromCRL = 8,
    PrivilegeWithdrawn = 9,
    AACompromise = 10
};

