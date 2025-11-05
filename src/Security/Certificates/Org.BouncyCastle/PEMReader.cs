// SPDX-FileCopyrightText: 2025 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

#if !NETSTANDARD2_1 && !NET5_0_OR_GREATER

namespace CryptoHives.Security.Certificates;

using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.OpenSsl;
using Org.BouncyCastle.Security;

/// <summary>
/// Methods or read PEM data.
/// </summary>
public static class PEMReader
{
    #region Public Methods
    /// <summary>
    /// Import a private key from PEM.
    /// </summary>
    public static RSA ImportPrivateKeyFromPEM(
        byte[] pemDataBlob,
        ReadOnlySpan<char> password)
    {
        RSA rsaPrivateKey = null;
        Org.BouncyCastle.OpenSsl.PemReader pemReader;
        using (var pemStreamReader = new StreamReader(new MemoryStream(pemDataBlob), Encoding.UTF8, true))
        {
            if (password.IsEmpty || password.IsWhiteSpace())
            {
                pemReader = new Org.BouncyCastle.OpenSsl.PemReader(pemStreamReader);
            }
            else
            {
                var pwFinder = new Password(password.ToArray());
                pemReader = new Org.BouncyCastle.OpenSsl.PemReader(pemStreamReader, pwFinder);
            }
            try
            {
                // find the private key in the PEM blob
                object pemObject = pemReader.ReadObject();
                while (pemObject != null)
                {
                    RsaPrivateCrtKeyParameters privateKey = null;
                    if (pemObject is Org.BouncyCastle.Crypto.AsymmetricCipherKeyPair keypair)
                    {
                        privateKey = keypair.Private as RsaPrivateCrtKeyParameters;
                    }

                    if (privateKey == null)
                    {
                        privateKey = pemObject as RsaPrivateCrtKeyParameters;
                    }

                    if (privateKey != null)
                    {
                        rsaPrivateKey = RSA.Create();
                        rsaPrivateKey.ImportParameters(DotNetUtilities.ToRSAParameters(privateKey));
                        break;
                    }

                    // read next object
                    pemObject = pemReader.ReadObject();
                }
            }
            finally
            {
                pemReader.Reader.Dispose();
            }
        }

        if (rsaPrivateKey == null)
        {
            throw new CryptographicException("PEM data blob does not contain a private key.");
        }

        return rsaPrivateKey;
    }
    #endregion

    #region Internal class
    /// <summary>
    /// Wrapper for a password string.
    /// </summary>
    internal class Password
        : IPasswordFinder
    {
        private readonly char[] _password;

        public Password(char[] word)
        {
            _password = (char[])word.Clone();
        }

        public char[] GetPassword()
        {
            return (char[])_password.Clone();
        }
    }
    #endregion
}

#endif

