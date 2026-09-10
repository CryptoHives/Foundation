// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

// PbeParameters was added to the base class library in .NET Core 3.0 / .NET Standard 2.1, so it is
// absent on net462, net472 and netstandard2.0 - three of the six frameworks this library targets.
//
// It appears in the *public* signature of nine members on MLKem, MLDsa and SlhDsa
// (ExportEncryptedPkcs8PrivateKey and friends). A drop-in replacement has to accept the same type
// the caller already holds, so unlike everything else under shared/ this cannot be an internal
// helper in the CryptoHives namespace: it must be public and in System.Security.Cryptography.
//
// Collision surface, measured rather than assumed: on these three frameworks the only package that
// also defines this type is Microsoft.Bcl.Cryptography. System.Security.Cryptography.Pkcs does not
// - its downlevel builds omit PbeParameters entirely. A project referencing both this package and
// Microsoft.Bcl.Cryptography on net462/net472/netstandard2.0 sees CS0433 and needs an extern alias
// on one of them; that is documented in the package README.
#if NET462 || NET472 || NETSTANDARD2_0

namespace System.Security.Cryptography;

using System;

/// <summary>
/// Represents parameters to be used for Password-Based Encryption (PBE).
/// </summary>
public sealed class PbeParameters
{
    /// <summary>
    /// Initializes a new instance of the <see cref="PbeParameters"/> class.
    /// </summary>
    /// <param name="encryptionAlgorithm">The algorithm to use when encrypting data.</param>
    /// <param name="hashAlgorithm">
    /// The hash algorithm to use with the key derivation function to produce the encryption key.
    /// </param>
    /// <param name="iterationCount">
    /// The iteration count to provide to the key derivation function.
    /// </param>
    /// <exception cref="ArgumentOutOfRangeException">
    /// <paramref name="iterationCount"/> is less than 1.
    /// </exception>
    public PbeParameters(
        PbeEncryptionAlgorithm encryptionAlgorithm,
        HashAlgorithmName hashAlgorithm,
        int iterationCount)
    {
        if (iterationCount < 1)
        {
            throw new ArgumentOutOfRangeException(nameof(iterationCount));
        }

        EncryptionAlgorithm = encryptionAlgorithm;
        HashAlgorithm = hashAlgorithm;
        IterationCount = iterationCount;
    }

    /// <summary>
    /// Gets the algorithm to use when encrypting data.
    /// </summary>
    public PbeEncryptionAlgorithm EncryptionAlgorithm { get; }

    /// <summary>
    /// Gets the hash algorithm to use with the key derivation function.
    /// </summary>
    public HashAlgorithmName HashAlgorithm { get; }

    /// <summary>
    /// Gets the iteration count to provide to the key derivation function.
    /// </summary>
    public int IterationCount { get; }
}

#endif
