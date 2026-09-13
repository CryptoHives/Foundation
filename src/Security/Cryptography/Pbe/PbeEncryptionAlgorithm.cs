// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Security.Cryptography;

/// <summary>
/// The content encryption algorithm used when exporting a password-protected private key.
/// </summary>
/// <remarks>
/// <para>
/// Only the AES-CBC ciphers PBES2 defines are listed, because those are the only ones this library
/// writes. The legacy PKCS#12 schemes (TripleDES and RC2, RFC 7292 Appendix C) are still
/// <b>read</b> — files written by older OpenSSL and Windows tooling import fine — but they are not
/// offered here, so choosing one is not something a caller can express.
/// </para>
/// <para>
/// <see cref="Unknown"/> is the zero value on purpose. Without it <c>default</c> would silently
/// mean AES-128, and a default that quietly picks a cipher is worse than one that refuses.
/// </para>
/// </remarks>
public enum PbeEncryptionAlgorithm
{
    /// <summary>
    /// No algorithm selected. Rejected by the <see cref="PbeOptions"/> constructor.
    /// </summary>
    Unknown = 0,

    /// <summary>AES-128 in CBC mode with PKCS#7 padding.</summary>
    Aes128Cbc = 1,

    /// <summary>AES-192 in CBC mode with PKCS#7 padding.</summary>
    Aes192Cbc = 2,

    /// <summary>AES-256 in CBC mode with PKCS#7 padding.</summary>
    Aes256Cbc = 3,
}
