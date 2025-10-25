// ------------------------------------------------------------
//  Copyright (c) 2025 The Keepers of the CryptoHives.  All rights reserved.
//  Licensed under the MIT License (MIT). See LICENSE in the repo root for license information.
// ------------------------------------------------------------

namespace CryptoHives.Security.Certificates;

#if mist

using System;
using System.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;

/// <summary>
/// A helper to support the .NET 9 certificate loader primitives on older .NET versions.
/// </summary>
public static class X509CertificateLoader
{
    /// <summary>
    ///   Initializes a new instance of the <see cref="X509Certificate2"/> class from certificate data.
    /// </summary>
    public static X509Certificate2 LoadCertificate(byte[] data)
    {
        return new X509Certificate2(data);
    }

#if NET6_0_OR_GREATER
    /// <summary>
    ///   Initializes a new instance of the <see cref="X509Certificate2"/> class from certificate data.
    /// </summary>
    public static X509Certificate2 LoadCertificate(ReadOnlySpan<byte> rawData)
    {
        return new X509Certificate2(rawData);
    }
#endif

    /// <summary>
    ///   Initializes a new instance of the <see cref="X509Certificate2"/> class from certificate file.
    /// </summary>
    public static X509Certificate2 LoadCertificateFromFile(string path)
    {
        return new X509Certificate2(path);
    }

    /// <summary>
    ///   Initializes a new instance of the <see cref="X509Certificate2"/> class from Pfx data.
    /// </summary>
    public static X509Certificate2 LoadPkcs12(
        byte[] data,
        ReadOnlySpan<char> password,
        X509KeyStorageFlags keyStorageFlags = X509KeyStorageFlags.DefaultKeySet)
    {
#if NETFRAMEWORK
        if (password.IsEmpty)
        {
            return new X509Certificate2(data, string.Empty, keyStorageFlags);
        }

        using var passwordString = new SecureString();
        foreach (char c in password)
        {
            passwordString.AppendChar(c);
        }
        passwordString.MakeReadOnly();

        return new X509Certificate2(data, passwordString, keyStorageFlags);
#else
#if NET6_0_OR_GREATER
        return new X509Certificate2(data, password, keyStorageFlags);
#else
        // .NET Standard does not support ReadOnlySpan<char> for password,
        // creates a string artifact of the password in memory.
        return new X509Certificate2(data, password.ToString(), keyStorageFlags);
#endif
#endif
    }

    /// <summary>
    ///   Initializes a new instance of the <see cref="X509Certificate2"/> class from Pfx file.
    /// </summary>
    public static X509Certificate2 LoadPkcs12FromFile(
        string filename,
        ReadOnlySpan<char> password,
        X509KeyStorageFlags keyStorageFlags = X509KeyStorageFlags.DefaultKeySet)
    {
#if NETFRAMEWORK
        if (password.IsEmpty)
        {
            return new X509Certificate2(filename, string.Empty, keyStorageFlags);
        }

        using var passwordString = new SecureString();
        foreach (char c in password)
        {
            passwordString.AppendChar(c);
        }
        passwordString.MakeReadOnly();

        return new X509Certificate2(filename, passwordString, keyStorageFlags);
#else
#if NET6_0_OR_GREATER
        return new X509Certificate2(filename, password, keyStorageFlags);
#else
        // .NET Standard does not support ReadOnlySpan<char> for password,
        // creates a string artifact of the password in memory.
        return new X509Certificate2(filename, password.ToString(), keyStorageFlags);
#endif
#endif
    }
}
#endif
