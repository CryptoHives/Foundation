// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Security.Cryptography.Kem;

using CryptoHives.Foundation.Security.Cryptography.KeyFormats;
using System;
using OS = System.Security.Cryptography;

/// <content>
/// The PKCS#8, SubjectPublicKeyInfo and PEM members, mirroring
/// <c>System.Security.Cryptography.MLKem</c>.
/// </content>
/// <remarks>
/// Every member here is a forwarder: the encoding lives once, in
/// <see cref="PqcKeyFormat"/>. What is ML-KEM-specific is the OID for the parameter set and the
/// <see cref="FromPkcs8Blob"/> / <see cref="FromSpkiBlob"/> factories below.
/// </remarks>
public sealed partial class MLKem
{
    // ========================================================================
    // SubjectPublicKeyInfo
    // ========================================================================

    /// <summary>
    /// Imports an ML-KEM encapsulation key from an X.509 SubjectPublicKeyInfo structure.
    /// </summary>
    /// <param name="source">The DER-encoded SubjectPublicKeyInfo.</param>
    /// <returns>An encapsulation-only instance.</returns>
    /// <exception cref="OS.CryptographicException">The structure is malformed or is not ML-KEM.</exception>
    public static MLKem ImportSubjectPublicKeyInfo(ReadOnlySpan<byte> source)
        => PqcKeyFormat.ImportSpki(source, FromSpkiBlob);

    /// <summary>
    /// Imports an ML-KEM encapsulation key from an X.509 SubjectPublicKeyInfo structure.
    /// </summary>
    /// <param name="source">The DER-encoded SubjectPublicKeyInfo.</param>
    /// <returns>An encapsulation-only instance.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="source"/> is null.</exception>
    /// <exception cref="OS.CryptographicException">The structure is malformed or is not ML-KEM.</exception>
    public static MLKem ImportSubjectPublicKeyInfo(byte[] source)
    {
        if (source is null)
        {
            throw new ArgumentNullException(nameof(source));
        }

        return ImportSubjectPublicKeyInfo(new ReadOnlySpan<byte>(source));
    }

    /// <summary>
    /// Exports the encapsulation key in the X.509 SubjectPublicKeyInfo format.
    /// </summary>
    /// <returns>The DER encoding.</returns>
    /// <exception cref="ObjectDisposedException">The instance has been disposed.</exception>
    public byte[] ExportSubjectPublicKeyInfo()
    {
        ThrowIfDisposed();
        return PqcKeyFormat.ExportSpki(AlgorithmOid, _encapsulationKey);
    }

    /// <summary>
    /// Exports the encapsulation key in a PEM-encoded SubjectPublicKeyInfo.
    /// </summary>
    /// <returns>The PEM text, labelled <c>PUBLIC KEY</c>.</returns>
    /// <exception cref="ObjectDisposedException">The instance has been disposed.</exception>
    public string ExportSubjectPublicKeyInfoPem()
    {
        ThrowIfDisposed();
        return PqcKeyFormat.ExportSpkiPem(AlgorithmOid, _encapsulationKey);
    }

    /// <summary>
    /// Attempts to export the encapsulation key as a SubjectPublicKeyInfo.
    /// </summary>
    /// <param name="destination">The buffer to receive the encoding.</param>
    /// <param name="bytesWritten">The number of bytes written.</param>
    /// <returns><see langword="false"/> when <paramref name="destination"/> is too small.</returns>
    /// <exception cref="ObjectDisposedException">The instance has been disposed.</exception>
    public bool TryExportSubjectPublicKeyInfo(Span<byte> destination, out int bytesWritten)
    {
        ThrowIfDisposed();
        return PqcKeyFormat.TryExportSpki(AlgorithmOid, _encapsulationKey, destination, out bytesWritten);
    }

    // ========================================================================
    // PKCS#8 PrivateKeyInfo
    // ========================================================================

    /// <summary>
    /// Imports an ML-KEM private key from a PKCS#8 PrivateKeyInfo structure.
    /// </summary>
    /// <param name="source">The DER-encoded PrivateKeyInfo.</param>
    /// <returns>The imported key.</returns>
    /// <exception cref="OS.CryptographicException">The structure is malformed or is not ML-KEM.</exception>
    public static MLKem ImportPkcs8PrivateKey(ReadOnlySpan<byte> source)
        => PqcKeyFormat.ImportPkcs8(source, FromPkcs8Blob);

    /// <summary>
    /// Imports an ML-KEM private key from a PKCS#8 PrivateKeyInfo structure.
    /// </summary>
    /// <param name="source">The DER-encoded PrivateKeyInfo.</param>
    /// <returns>The imported key.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="source"/> is null.</exception>
    /// <exception cref="OS.CryptographicException">The structure is malformed or is not ML-KEM.</exception>
    public static MLKem ImportPkcs8PrivateKey(byte[] source)
    {
        if (source is null)
        {
            throw new ArgumentNullException(nameof(source));
        }

        return ImportPkcs8PrivateKey(new ReadOnlySpan<byte>(source));
    }

    /// <summary>
    /// Exports this key in the PKCS#8 PrivateKeyInfo format.
    /// </summary>
    /// <returns>The DER encoding.</returns>
    /// <exception cref="ObjectDisposedException">The instance has been disposed.</exception>
    /// <exception cref="OS.CryptographicException">The instance holds no private key.</exception>
    public byte[] ExportPkcs8PrivateKey()
    {
        byte[] blob = BuildPrivateKeyBlob();

        try
        {
            return PqcKeyFormat.ExportPkcs8(AlgorithmOid, blob);
        }
        finally
        {
            CryptographicOperations.ZeroMemory(blob);
        }
    }

    /// <summary>
    /// Exports this key in a PEM-encoded PKCS#8 PrivateKeyInfo.
    /// </summary>
    /// <returns>The PEM text, labelled <c>PRIVATE KEY</c>.</returns>
    /// <exception cref="ObjectDisposedException">The instance has been disposed.</exception>
    /// <exception cref="OS.CryptographicException">The instance holds no private key.</exception>
    public string ExportPkcs8PrivateKeyPem()
    {
        byte[] blob = BuildPrivateKeyBlob();

        try
        {
            return PqcKeyFormat.ExportPkcs8Pem(AlgorithmOid, blob);
        }
        finally
        {
            CryptographicOperations.ZeroMemory(blob);
        }
    }

    /// <summary>
    /// Attempts to export this key in the PKCS#8 PrivateKeyInfo format.
    /// </summary>
    /// <param name="destination">The buffer to receive the encoding.</param>
    /// <param name="bytesWritten">The number of bytes written.</param>
    /// <returns><see langword="false"/> when <paramref name="destination"/> is too small.</returns>
    /// <exception cref="ObjectDisposedException">The instance has been disposed.</exception>
    /// <exception cref="OS.CryptographicException">The instance holds no private key.</exception>
    public bool TryExportPkcs8PrivateKey(Span<byte> destination, out int bytesWritten)
    {
        byte[] blob = BuildPrivateKeyBlob();

        try
        {
            return PqcKeyFormat.TryExportPkcs8(AlgorithmOid, blob, destination, out bytesWritten);
        }
        finally
        {
            CryptographicOperations.ZeroMemory(blob);
        }
    }

    // ========================================================================
    // PKCS#8 EncryptedPrivateKeyInfo
    // ========================================================================

    /// <summary>
    /// Imports an ML-KEM private key from a PKCS#8 EncryptedPrivateKeyInfo structure.
    /// </summary>
    /// <param name="password">The password, used verbatim as the key derivation input.</param>
    /// <param name="source">The DER-encoded EncryptedPrivateKeyInfo.</param>
    /// <returns>The imported key.</returns>
    /// <exception cref="OS.CryptographicException">
    /// The password is wrong, or the structure is malformed or is not ML-KEM.
    /// </exception>
    public static MLKem ImportEncryptedPkcs8PrivateKey(
        ReadOnlySpan<byte> password,
        ReadOnlySpan<byte> source)
        => PqcKeyFormat.ImportEncryptedPkcs8(PbePassword.FromBytes(password), source, FromPkcs8Blob);

    /// <summary>
    /// Imports an ML-KEM private key from a PKCS#8 EncryptedPrivateKeyInfo structure.
    /// </summary>
    /// <param name="password">The password, encoded per the scheme in the structure.</param>
    /// <param name="source">The DER-encoded EncryptedPrivateKeyInfo.</param>
    /// <returns>The imported key.</returns>
    /// <exception cref="OS.CryptographicException">
    /// The password is wrong, or the structure is malformed or is not ML-KEM.
    /// </exception>
    public static MLKem ImportEncryptedPkcs8PrivateKey(
        ReadOnlySpan<char> password,
        ReadOnlySpan<byte> source)
        => PqcKeyFormat.ImportEncryptedPkcs8(PbePassword.FromChars(password), source, FromPkcs8Blob);

    /// <summary>
    /// Imports an ML-KEM private key from a PKCS#8 EncryptedPrivateKeyInfo structure.
    /// </summary>
    /// <param name="password">The password.</param>
    /// <param name="source">The DER-encoded EncryptedPrivateKeyInfo.</param>
    /// <returns>The imported key.</returns>
    /// <exception cref="ArgumentNullException">
    /// <paramref name="password"/> or <paramref name="source"/> is null.
    /// </exception>
    /// <exception cref="OS.CryptographicException">
    /// The password is wrong, or the structure is malformed or is not ML-KEM.
    /// </exception>
    public static MLKem ImportEncryptedPkcs8PrivateKey(string password, byte[] source)
    {
        if (password is null)
        {
            throw new ArgumentNullException(nameof(password));
        }

        if (source is null)
        {
            throw new ArgumentNullException(nameof(source));
        }

        return ImportEncryptedPkcs8PrivateKey(password.AsSpan(), new ReadOnlySpan<byte>(source));
    }

    /// <summary>
    /// Exports this key in the PKCS#8 EncryptedPrivateKeyInfo format.
    /// </summary>
    /// <param name="password">The password, used verbatim as the key derivation input.</param>
    /// <param name="pbeOptions">Selects the cipher, pseudorandom function and iteration count.</param>
    /// <returns>The DER encoding.</returns>
    /// <exception cref="ObjectDisposedException">The instance has been disposed.</exception>
    /// <exception cref="OS.CryptographicException">The instance holds no private key.</exception>
    public byte[] ExportEncryptedPkcs8PrivateKey(
        ReadOnlySpan<byte> password,
        PbeOptions pbeOptions)
        => ExportEncrypted(PbePassword.FromBytes(password), pbeOptions);

    /// <summary>
    /// Exports this key in the PKCS#8 EncryptedPrivateKeyInfo format.
    /// </summary>
    /// <param name="password">The password.</param>
    /// <param name="pbeOptions">Selects the cipher, pseudorandom function and iteration count.</param>
    /// <returns>The DER encoding.</returns>
    /// <exception cref="ObjectDisposedException">The instance has been disposed.</exception>
    /// <exception cref="OS.CryptographicException">The instance holds no private key.</exception>
    public byte[] ExportEncryptedPkcs8PrivateKey(
        ReadOnlySpan<char> password,
        PbeOptions pbeOptions)
        => ExportEncrypted(PbePassword.FromChars(password), pbeOptions);

    /// <summary>
    /// Exports this key in the PKCS#8 EncryptedPrivateKeyInfo format.
    /// </summary>
    /// <param name="password">The password.</param>
    /// <param name="pbeOptions">Selects the cipher, pseudorandom function and iteration count.</param>
    /// <returns>The DER encoding.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="password"/> is null.</exception>
    /// <exception cref="ObjectDisposedException">The instance has been disposed.</exception>
    /// <exception cref="OS.CryptographicException">The instance holds no private key.</exception>
    public byte[] ExportEncryptedPkcs8PrivateKey(string password, PbeOptions pbeOptions)
    {
        if (password is null)
        {
            throw new ArgumentNullException(nameof(password));
        }

        return ExportEncrypted(PbePassword.FromChars(password.AsSpan()), pbeOptions);
    }

    /// <summary>
    /// Exports this key in a PEM-encoded PKCS#8 EncryptedPrivateKeyInfo.
    /// </summary>
    /// <param name="password">The password, used verbatim as the key derivation input.</param>
    /// <param name="pbeOptions">Selects the cipher, pseudorandom function and iteration count.</param>
    /// <returns>The PEM text, labelled <c>ENCRYPTED PRIVATE KEY</c>.</returns>
    /// <exception cref="ObjectDisposedException">The instance has been disposed.</exception>
    /// <exception cref="OS.CryptographicException">The instance holds no private key.</exception>
    public string ExportEncryptedPkcs8PrivateKeyPem(
        ReadOnlySpan<byte> password,
        PbeOptions pbeOptions)
        => ExportEncryptedPem(PbePassword.FromBytes(password), pbeOptions);

    /// <summary>
    /// Exports this key in a PEM-encoded PKCS#8 EncryptedPrivateKeyInfo.
    /// </summary>
    /// <param name="password">The password.</param>
    /// <param name="pbeOptions">Selects the cipher, pseudorandom function and iteration count.</param>
    /// <returns>The PEM text, labelled <c>ENCRYPTED PRIVATE KEY</c>.</returns>
    /// <exception cref="ObjectDisposedException">The instance has been disposed.</exception>
    /// <exception cref="OS.CryptographicException">The instance holds no private key.</exception>
    public string ExportEncryptedPkcs8PrivateKeyPem(
        ReadOnlySpan<char> password,
        PbeOptions pbeOptions)
        => ExportEncryptedPem(PbePassword.FromChars(password), pbeOptions);

    /// <summary>
    /// Exports this key in a PEM-encoded PKCS#8 EncryptedPrivateKeyInfo.
    /// </summary>
    /// <param name="password">The password.</param>
    /// <param name="pbeOptions">Selects the cipher, pseudorandom function and iteration count.</param>
    /// <returns>The PEM text, labelled <c>ENCRYPTED PRIVATE KEY</c>.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="password"/> is null.</exception>
    /// <exception cref="ObjectDisposedException">The instance has been disposed.</exception>
    /// <exception cref="OS.CryptographicException">The instance holds no private key.</exception>
    public string ExportEncryptedPkcs8PrivateKeyPem(string password, PbeOptions pbeOptions)
    {
        if (password is null)
        {
            throw new ArgumentNullException(nameof(password));
        }

        return ExportEncryptedPem(PbePassword.FromChars(password.AsSpan()), pbeOptions);
    }

    /// <summary>
    /// Attempts to export this key in the PKCS#8 EncryptedPrivateKeyInfo format.
    /// </summary>
    /// <param name="password">The password, used verbatim as the key derivation input.</param>
    /// <param name="pbeOptions">Selects the cipher, pseudorandom function and iteration count.</param>
    /// <param name="destination">The buffer to receive the encoding.</param>
    /// <param name="bytesWritten">The number of bytes written.</param>
    /// <returns><see langword="false"/> when <paramref name="destination"/> is too small.</returns>
    /// <exception cref="ObjectDisposedException">The instance has been disposed.</exception>
    /// <exception cref="OS.CryptographicException">The instance holds no private key.</exception>
    public bool TryExportEncryptedPkcs8PrivateKey(
        ReadOnlySpan<byte> password,
        PbeOptions pbeOptions,
        Span<byte> destination,
        out int bytesWritten)
        => TryExportEncrypted(PbePassword.FromBytes(password), pbeOptions, destination, out bytesWritten);

    /// <summary>
    /// Attempts to export this key in the PKCS#8 EncryptedPrivateKeyInfo format.
    /// </summary>
    /// <param name="password">The password.</param>
    /// <param name="pbeOptions">Selects the cipher, pseudorandom function and iteration count.</param>
    /// <param name="destination">The buffer to receive the encoding.</param>
    /// <param name="bytesWritten">The number of bytes written.</param>
    /// <returns><see langword="false"/> when <paramref name="destination"/> is too small.</returns>
    /// <exception cref="ObjectDisposedException">The instance has been disposed.</exception>
    /// <exception cref="OS.CryptographicException">The instance holds no private key.</exception>
    public bool TryExportEncryptedPkcs8PrivateKey(
        ReadOnlySpan<char> password,
        PbeOptions pbeOptions,
        Span<byte> destination,
        out int bytesWritten)
        => TryExportEncrypted(PbePassword.FromChars(password), pbeOptions, destination, out bytesWritten);

    /// <summary>
    /// Attempts to export this key in the PKCS#8 EncryptedPrivateKeyInfo format.
    /// </summary>
    /// <param name="password">The password.</param>
    /// <param name="pbeOptions">Selects the cipher, pseudorandom function and iteration count.</param>
    /// <param name="destination">The buffer to receive the encoding.</param>
    /// <param name="bytesWritten">The number of bytes written.</param>
    /// <returns><see langword="false"/> when <paramref name="destination"/> is too small.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="password"/> is null.</exception>
    /// <exception cref="ObjectDisposedException">The instance has been disposed.</exception>
    /// <exception cref="OS.CryptographicException">The instance holds no private key.</exception>
    public bool TryExportEncryptedPkcs8PrivateKey(
        string password,
        PbeOptions pbeOptions,
        Span<byte> destination,
        out int bytesWritten)
    {
        if (password is null)
        {
            throw new ArgumentNullException(nameof(password));
        }

        return TryExportEncrypted(
            PbePassword.FromChars(password.AsSpan()), pbeOptions, destination, out bytesWritten);
    }

    // ========================================================================
    // PEM
    // ========================================================================

    /// <summary>
    /// Imports an ML-KEM key from an RFC 7468 PEM-encoded string.
    /// </summary>
    /// <param name="source">The PEM text.</param>
    /// <returns>The imported key.</returns>
    /// <exception cref="ArgumentException">
    /// <paramref name="source"/> contains no PEM block with a recognized label, or more than one.
    /// </exception>
    public static MLKem ImportFromPem(ReadOnlySpan<char> source)
        => PqcKeyFormat.ImportFromPem(source, FromPemBlob);

    /// <summary>
    /// Imports an ML-KEM key from an RFC 7468 PEM-encoded string.
    /// </summary>
    /// <param name="source">The PEM text.</param>
    /// <returns>The imported key.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="source"/> is null.</exception>
    /// <exception cref="ArgumentException">
    /// <paramref name="source"/> contains no PEM block with a recognized label, or more than one.
    /// </exception>
    public static MLKem ImportFromPem(string source)
    {
        if (source is null)
        {
            throw new ArgumentNullException(nameof(source));
        }

        return ImportFromPem(source.AsSpan());
    }

    /// <summary>
    /// Imports an ML-KEM key from an encrypted RFC 7468 PEM-encoded string.
    /// </summary>
    /// <param name="source">The PEM text.</param>
    /// <param name="password">The password.</param>
    /// <returns>The imported key.</returns>
    /// <exception cref="ArgumentException">
    /// <paramref name="source"/> contains no encrypted private key, or more than one.
    /// </exception>
    public static MLKem ImportFromEncryptedPem(ReadOnlySpan<char> source, ReadOnlySpan<char> password)
        => PqcKeyFormat.ImportFromEncryptedPem(source, PbePassword.FromChars(password), FromPkcs8Blob);

    /// <summary>
    /// Imports an ML-KEM key from an encrypted RFC 7468 PEM-encoded string.
    /// </summary>
    /// <param name="source">The PEM text.</param>
    /// <param name="passwordBytes">The password, used verbatim as the key derivation input.</param>
    /// <returns>The imported key.</returns>
    /// <exception cref="ArgumentException">
    /// <paramref name="source"/> contains no encrypted private key, or more than one.
    /// </exception>
    public static MLKem ImportFromEncryptedPem(ReadOnlySpan<char> source, ReadOnlySpan<byte> passwordBytes)
        => PqcKeyFormat.ImportFromEncryptedPem(source, PbePassword.FromBytes(passwordBytes), FromPkcs8Blob);

    /// <summary>
    /// Imports an ML-KEM key from an encrypted RFC 7468 PEM-encoded string.
    /// </summary>
    /// <param name="source">The PEM text.</param>
    /// <param name="password">The password.</param>
    /// <returns>The imported key.</returns>
    /// <exception cref="ArgumentNullException">An argument is null.</exception>
    /// <exception cref="ArgumentException">
    /// <paramref name="source"/> contains no encrypted private key, or more than one.
    /// </exception>
    public static MLKem ImportFromEncryptedPem(string source, string password)
    {
        if (source is null)
        {
            throw new ArgumentNullException(nameof(source));
        }

        if (password is null)
        {
            throw new ArgumentNullException(nameof(password));
        }

        return ImportFromEncryptedPem(source.AsSpan(), password.AsSpan());
    }

    /// <summary>
    /// Imports an ML-KEM key from an encrypted RFC 7468 PEM-encoded string.
    /// </summary>
    /// <param name="source">The PEM text.</param>
    /// <param name="passwordBytes">The password, used verbatim as the key derivation input.</param>
    /// <returns>The imported key.</returns>
    /// <exception cref="ArgumentNullException">An argument is null.</exception>
    /// <exception cref="ArgumentException">
    /// <paramref name="source"/> contains no encrypted private key, or more than one.
    /// </exception>
    public static MLKem ImportFromEncryptedPem(string source, byte[] passwordBytes)
    {
        if (source is null)
        {
            throw new ArgumentNullException(nameof(source));
        }

        if (passwordBytes is null)
        {
            throw new ArgumentNullException(nameof(passwordBytes));
        }

        return ImportFromEncryptedPem(source.AsSpan(), new ReadOnlySpan<byte>(passwordBytes));
    }

    // ========================================================================
    // ML-KEM specifics
    // ========================================================================

    /// <summary>
    /// Gets the CSOR object identifier for this key's parameter set.
    /// </summary>
    private string AlgorithmOid => PqcKeyOids.ForMLKem(Algorithm.Name);

    /// <summary>
    /// Builds the contents of the PKCS#8 <c>privateKey</c> OCTET STRING.
    /// </summary>
    /// <remarks>
    /// Writes the seed when this instance still has one - a key that was generated or expanded
    /// from a seed - and the expanded key otherwise. That is what .NET 10 does, verified by
    /// exporting both kinds of in-box key and decoding the result, and it means a seed survives a
    /// PKCS#8 round trip instead of being silently traded for 1.6-3.2 KB of decapsulation key.
    /// </remarks>
    private byte[] BuildPrivateKeyBlob()
    {
        ThrowIfDisposed();

        if (_seed is not null)
        {
            return PqcPrivateKeyChoice.WriteSeed(_seed);
        }

        if (_decapsulationKey is not null)
        {
            return PqcPrivateKeyChoice.WriteExpandedKey(_decapsulationKey);
        }

        throw new OS.CryptographicException(
            "The instance holds only an encapsulation key and cannot export a private key.");
    }

    private byte[] ExportEncrypted(PbePassword password, PbeOptions pbeOptions)
    {
        byte[] blob = BuildPrivateKeyBlob();

        try
        {
            return PqcKeyFormat.ExportEncryptedPkcs8(AlgorithmOid, blob, password, pbeOptions);
        }
        finally
        {
            CryptographicOperations.ZeroMemory(blob);
        }
    }

    private string ExportEncryptedPem(PbePassword password, PbeOptions pbeOptions)
    {
        byte[] blob = BuildPrivateKeyBlob();

        try
        {
            return PqcKeyFormat.ExportEncryptedPkcs8Pem(AlgorithmOid, blob, password, pbeOptions);
        }
        finally
        {
            CryptographicOperations.ZeroMemory(blob);
        }
    }

    private bool TryExportEncrypted(
        PbePassword password,
        PbeOptions pbeOptions,
        Span<byte> destination,
        out int bytesWritten)
    {
        byte[] blob = BuildPrivateKeyBlob();

        try
        {
            return PqcKeyFormat.TryExportEncryptedPkcs8(
                AlgorithmOid, blob, password, pbeOptions, destination, out bytesWritten);
        }
        finally
        {
            CryptographicOperations.ZeroMemory(blob);
        }
    }

    /// <summary>
    /// Builds an instance from a decoded SubjectPublicKeyInfo.
    /// </summary>
    private static MLKem FromSpkiBlob(string algorithmOid, byte[] publicKey)
    {
        MLKemAlgorithm algorithm = AlgorithmForOid(algorithmOid);
        DerGuard.KeyLength(
            publicKey.Length, algorithm.EncapsulationKeySizeInBytes, "encapsulation key", algorithm.Name);
        return ImportEncapsulationKey(algorithm, publicKey);
    }

    /// <summary>
    /// Builds an instance from a decoded PKCS#8 <c>privateKey</c> OCTET STRING.
    /// </summary>
    private static MLKem FromPkcs8Blob(string algorithmOid, byte[] privateKeyBlob)
    {
        MLKemAlgorithm algorithm = AlgorithmForOid(algorithmOid);

        PqcPrivateKeyForm form = PqcPrivateKeyChoice.Read(
            privateKeyBlob, out byte[]? seed, out byte[]? expandedKey);

        try
        {
            // The `both` arm carries a seed and an expanded key that are supposed to agree. Expand
            // the seed and let ImportPrivateSeed's own consistency checking apply, rather
            // than trusting the expanded half of a structure a stranger produced.
            if (form is PqcPrivateKeyForm.Seed or PqcPrivateKeyForm.Both)
            {
                DerGuard.KeyLength(
                    seed!.Length, algorithm.PrivateSeedSizeInBytes, "private seed", algorithm.Name);
                return ImportPrivateSeed(algorithm, seed);
            }

            DerGuard.KeyLength(
                expandedKey!.Length, algorithm.DecapsulationKeySizeInBytes, "decapsulation key", algorithm.Name);
            return ImportDecapsulationKey(algorithm, expandedKey);
        }
        finally
        {
            if (seed is not null)
            {
                CryptographicOperations.ZeroMemory(seed);
            }

            if (expandedKey is not null)
            {
                CryptographicOperations.ZeroMemory(expandedKey);
            }
        }
    }

    /// <summary>
    /// Dispatches a PEM block to the public or private importer. The label decides which, and
    /// <see cref="PqcKeyFormat.ImportFromPem"/> has already narrowed it to one of the two.
    /// </summary>
    private static MLKem FromPemBlob(string algorithmOid, byte[] key)
    {
        // A SubjectPublicKeyInfo yields a raw public key; a PrivateKeyInfo yields the CHOICE. The
        // two are told apart by length: only an encapsulation key can be exactly
        // EncapsulationKeySizeInBytes.
        MLKemAlgorithm algorithm = AlgorithmForOid(algorithmOid);
        return key.Length == algorithm.EncapsulationKeySizeInBytes
            ? FromSpkiBlob(algorithmOid, key)
            : FromPkcs8Blob(algorithmOid, key);
    }

    private static MLKemAlgorithm AlgorithmForOid(string algorithmOid)
    {
        string? name = PqcKeyOids.MLKemNameFor(algorithmOid);

        if (name is null)
        {
            throw new OS.CryptographicException(
                $"The key algorithm '{algorithmOid}' is not an ML-KEM parameter set.");
        }

        return name switch {
            "ML-KEM-512" => MLKemAlgorithm.MLKem512,
            "ML-KEM-768" => MLKemAlgorithm.MLKem768,
            _ => MLKemAlgorithm.MLKem1024,
        };
    }
}
