// SPDX-FileCopyrightText: 2025 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

#if !NETSTANDARD2_1 && !NET472_OR_GREATER && !NET5_0_OR_GREATER

namespace CryptoHives.Security.Certificates.BouncyCastle;

using System;
using System.Security.Cryptography;
using Org.BouncyCastle.Asn1.X509;
using Org.BouncyCastle.Crypto;
using System.IO;

/// <summary>
/// The signature factory for Bouncy Castle to sign a digest with a KeyVault key.
/// </summary>
public class X509SignatureFactory : ISignatureFactory
{
    private readonly AlgorithmIdentifier _algID;
    private readonly HashAlgorithmName _hashAlgorithm;
    private readonly X509SignatureGenerator _generator;

    /// <summary>
    /// Constructor which also specifies a source of randomness to be used if one is required.
    /// </summary>
    /// <param name="hashAlgorithm">The name of the signature algorithm to use.</param>
    /// <param name="generator">The signature generator.</param>
    public X509SignatureFactory(HashAlgorithmName hashAlgorithm, X509SignatureGenerator generator)
    {
        Org.BouncyCastle.Asn1.DerObjectIdentifier sigOid;
        if (hashAlgorithm == HashAlgorithmName.SHA1)
        {
            sigOid = Org.BouncyCastle.Asn1.Pkcs.PkcsObjectIdentifiers.Sha1WithRsaEncryption;
        }
        else if (hashAlgorithm == HashAlgorithmName.SHA256)
        {
            sigOid = Org.BouncyCastle.Asn1.Pkcs.PkcsObjectIdentifiers.Sha256WithRsaEncryption;
        }
        else if (hashAlgorithm == HashAlgorithmName.SHA384)
        {
            sigOid = Org.BouncyCastle.Asn1.Pkcs.PkcsObjectIdentifiers.Sha384WithRsaEncryption;
        }
        else if (hashAlgorithm == HashAlgorithmName.SHA512)
        {
            sigOid = Org.BouncyCastle.Asn1.Pkcs.PkcsObjectIdentifiers.Sha512WithRsaEncryption;
        }
        else
        {
            throw new ArgumentOutOfRangeException(nameof(hashAlgorithm));
        }
        _hashAlgorithm = hashAlgorithm;
        _generator = generator;
        _algID = new AlgorithmIdentifier(sigOid);
    }

    /// <inheritdoc/>
    public Object AlgorithmDetails => _algID;

    /// <inheritdoc/>
    public IStreamCalculator<IBlockResult> CreateCalculator()
    {
        return new X509StreamCalculator(_generator, _hashAlgorithm);
    }

    /// <summary>
    /// Signs a Bouncy Castle digest stream with the .NET X509SignatureGenerator.
    /// </summary>
    class X509StreamCalculator : IStreamCalculator<IBlockResult>
    {
        private X509SignatureGenerator _generator;
        private readonly HashAlgorithmName _hashAlgorithm;

        /// <summary>
        /// Ctor for the stream calculator. 
        /// </summary>
        /// <param name="generator">The X509SignatureGenerator to sign the digest.</param>
        /// <param name="hashAlgorithm">The hash algorithm to use for the signature.</param>
        public X509StreamCalculator(
            X509SignatureGenerator generator,
            HashAlgorithmName hashAlgorithm)
        {
            Stream = new MemoryStream();
            _generator = generator;
            _hashAlgorithm = hashAlgorithm;
        }

        /// <summary>
        /// The digest stream (MemoryStream).
        /// </summary>
        public Stream Stream { get; }

        /// <summary>
        /// Callback signs the digest with X509SignatureGenerator.
        /// </summary>
        public IBlockResult GetResult()
        {
            if (Stream is not MemoryStream memStream) throw new ArgumentNullException(nameof(Stream));
            byte[] digest = memStream.ToArray();
            byte[] signature = _generator.SignData(digest, _hashAlgorithm);
            return new Org.BouncyCastle.Crypto.SimpleBlockResult(signature);
        }
    }
}

#endif

