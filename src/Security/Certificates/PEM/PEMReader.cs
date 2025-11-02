// SPDX-FileCopyrightText: 2025 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Security.Certificates.PEM;

#if NETSTANDARD2_1 || NET5_0_OR_GREATER

using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

/// <summary>
/// Methods or read PEM data.
/// </summary>
public static class PEMReader
{
    #region Public Methods
    /// <summary>
    /// Import a PKCS#8 private key or RSA private key from PEM.
    /// The PKCS#8 private key may be encrypted using a password.
    /// </summary>
    /// <param name="pemDataBlob">The PEM datablob as byte span.</param>
    /// <param name="password">The password to use (optional).</param>
    /// <returns>The RSA private key.</returns>
    public static RSA ImportPrivateKeyFromPEM(
        ReadOnlySpan<byte> pemDataBlob,
        ReadOnlySpan<char> password)
    {
        string[] labels = {
            "ENCRYPTED PRIVATE KEY", "PRIVATE KEY", "RSA PRIVATE KEY"
            };
        try
        {
            string pemText = Encoding.UTF8.GetString(pemDataBlob);
            int count = 0;
            foreach (string label in labels)
            {
                count++;
                string beginlabel = $"-----BEGIN {label}-----";
                int beginIndex = pemText.IndexOf(beginlabel, StringComparison.Ordinal);
                if (beginIndex < 0)
                    {
                    continue;
                    }
                string endlabel = $"-----END {label}-----";
                int endIndex = pemText.IndexOf(endlabel, StringComparison.Ordinal);
                beginIndex += beginlabel.Length;
                if (endIndex < 0 || endIndex <= beginIndex)
                    {
                    continue;
                    }
                string pemData = pemText.Substring(beginIndex, endIndex - beginIndex);
                byte[] pemDecoded = new byte[pemData.Length];
                int bytesDecoded;
                if (Convert.TryFromBase64Chars(pemData, pemDecoded, out bytesDecoded))
                {
                    var rsaPrivateKey = RSA.Create();
                    int bytesRead;
                    switch (count)
                    {
                        case 1:
                            if (password.IsEmpty || password.IsWhiteSpace())
                                {
                                throw new ArgumentException("Need password for encrypted private key.");
                                }
                            rsaPrivateKey.ImportEncryptedPkcs8PrivateKey(password, pemDecoded, out bytesRead);
                            break;
                        case 2: rsaPrivateKey.ImportPkcs8PrivateKey(pemDecoded, out bytesRead); break;
                        case 3: rsaPrivateKey.ImportRSAPrivateKey(pemDecoded, out bytesRead); break;
                    }
                    return rsaPrivateKey;
                }
            }
        }
        catch (CryptographicException)
        {
            throw;
        }
        catch (Exception ex)
        {
            throw new CryptographicException("Failed to decode the PEM private key.", ex);
        }
        throw new ArgumentException("No private PEM key found.");
    }
    #endregion

    #region Private Methods
    #endregion
}
#endif

