// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Security.Cryptography.Dsa;

using CryptoHives.Foundation.Security.Cryptography.KeyFormats;
using System;
using OS = System.Security.Cryptography;

/// <content>
/// The PKCS#8, SubjectPublicKeyInfo and PEM members, mirroring
/// <c>System.Security.Cryptography.SlhDsa</c>.
/// </content>
/// <remarks>
/// Every member here is a forwarder: the encoding lives once, in
/// <see cref="PqcKeyFormat"/>. What is SLH-DSA-specific is the OID for the parameter set and the
/// <see cref="FromPkcs8Blob"/> / <see cref="FromSpkiBlob"/> factories below.
/// </remarks>
public sealed partial class SlhDsa
{
    // ========================================================================
    // SubjectPublicKeyInfo
    // ========================================================================

    /// <summary>
    /// Imports an SLH-DSA public key from an X.509 SubjectPublicKeyInfo structure.
    /// </summary>
    /// <param name="source">The DER-encoded SubjectPublicKeyInfo.</param>
    /// <returns>A verify-only instance.</returns>
    /// <exception cref="OS.CryptographicException">The structure is malformed or is not SLH-DSA.</exception>
    public static SlhDsa ImportSubjectPublicKeyInfo(ReadOnlySpan<byte> source)
        => PqcKeyFormat.ImportSpki(source, FromSpkiBlob);

    /// <summary>
    /// Imports an SLH-DSA public key from an X.509 SubjectPublicKeyInfo structure.
    /// </summary>
    /// <param name="source">The DER-encoded SubjectPublicKeyInfo.</param>
    /// <returns>A verify-only instance.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="source"/> is null.</exception>
    /// <exception cref="OS.CryptographicException">The structure is malformed or is not SLH-DSA.</exception>
    public static SlhDsa ImportSubjectPublicKeyInfo(byte[] source)
    {
        if (source is null)
        {
            throw new ArgumentNullException(nameof(source));
        }

        return ImportSubjectPublicKeyInfo(new ReadOnlySpan<byte>(source));
    }

    /// <summary>
    /// Exports the public-key portion of this key in the X.509 SubjectPublicKeyInfo format.
    /// </summary>
    /// <returns>The DER encoding.</returns>
    /// <exception cref="ObjectDisposedException">The instance has been disposed.</exception>
    public byte[] ExportSubjectPublicKeyInfo()
    {
        ThrowIfDisposed();
        return PqcKeyFormat.ExportSpki(AlgorithmOid, _publicKey);
    }

    /// <summary>
    /// Exports the public-key portion of this key in a PEM-encoded SubjectPublicKeyInfo.
    /// </summary>
    /// <returns>The PEM text, labelled <c>PUBLIC KEY</c>.</returns>
    /// <exception cref="ObjectDisposedException">The instance has been disposed.</exception>
    public string ExportSubjectPublicKeyInfoPem()
    {
        ThrowIfDisposed();
        return PqcKeyFormat.ExportSpkiPem(AlgorithmOid, _publicKey);
    }

    /// <summary>
    /// Attempts to export the public-key portion of this key as a SubjectPublicKeyInfo.
    /// </summary>
    /// <param name="destination">The buffer to receive the encoding.</param>
    /// <param name="bytesWritten">The number of bytes written.</param>
    /// <returns><see langword="false"/> when <paramref name="destination"/> is too small.</returns>
    /// <exception cref="ObjectDisposedException">The instance has been disposed.</exception>
    public bool TryExportSubjectPublicKeyInfo(Span<byte> destination, out int bytesWritten)
    {
        ThrowIfDisposed();
        return PqcKeyFormat.TryExportSpki(AlgorithmOid, _publicKey, destination, out bytesWritten);
    }


    /// <summary>
    /// Gets the exact number of characters <see cref="TryExportSubjectPublicKeyInfoPem"/> writes.
    /// </summary>
    /// <returns>The required buffer length, in characters.</returns>
    /// <exception cref="ObjectDisposedException">The instance has been disposed.</exception>
    public int GetSubjectPublicKeyInfoPemSize()
    {
        ThrowIfDisposed();
        return PqcKeyFormat.GetSpkiPemSize(AlgorithmOid, _publicKey);
    }

    /// <summary>
    /// Attempts to export this key as a PEM-encoded SubjectPublicKeyInfo.
    /// </summary>
    /// <param name="destination">The buffer to receive the text, labelled <c>PUBLIC KEY</c>.</param>
    /// <param name="charsWritten">The number of characters written.</param>
    /// <returns><see langword="false"/> when <paramref name="destination"/> is too small.</returns>
    /// <exception cref="ObjectDisposedException">The instance has been disposed.</exception>
    /// <remarks>
    /// A public key is not secret, so <see cref="ExportSubjectPublicKeyInfoPem"/> remains available
    /// and is usually the simpler call. This overload exists for parity with
    /// <c>AsymmetricAlgorithm</c>, which offers the same pair, and for callers avoiding allocation.
    /// </remarks>
    public bool TryExportSubjectPublicKeyInfoPem(Span<char> destination, out int charsWritten)
    {
        ThrowIfDisposed();
        return PqcKeyFormat.TryExportSpkiPem(AlgorithmOid, _publicKey, destination, out charsWritten);
    }

    // ========================================================================
    // PKCS#8 PrivateKeyInfo
    // ========================================================================

    /// <summary>
    /// Imports an SLH-DSA private key from a PKCS#8 PrivateKeyInfo structure.
    /// </summary>
    /// <param name="source">The DER-encoded PrivateKeyInfo.</param>
    /// <returns>The imported key.</returns>
    /// <exception cref="OS.CryptographicException">The structure is malformed or is not SLH-DSA.</exception>
    public static SlhDsa ImportPkcs8PrivateKey(ReadOnlySpan<byte> source)
        => PqcKeyFormat.ImportPkcs8(source, FromPkcs8Blob);

    /// <summary>
    /// Imports an SLH-DSA private key from a PKCS#8 PrivateKeyInfo structure.
    /// </summary>
    /// <param name="source">The DER-encoded PrivateKeyInfo.</param>
    /// <returns>The imported key.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="source"/> is null.</exception>
    /// <exception cref="OS.CryptographicException">The structure is malformed or is not SLH-DSA.</exception>
    public static SlhDsa ImportPkcs8PrivateKey(byte[] source)
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

    // Dropped from the shipping surface: a PEM-encoded plaintext private key in a string cannot be overwritten.
    // Retained unbuilt for review; see docfx/packages/security/cryptography/erasable-memory.md.
#if SECURITY_REVIEW
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
#endif

    /// <summary>
    /// Gets the exact number of characters <see cref="TryExportPkcs8PrivateKeyPem"/> writes for
    /// this key.
    /// </summary>
    /// <returns>The required buffer length, in characters.</returns>
    /// <exception cref="ObjectDisposedException">The instance has been disposed.</exception>
    /// <exception cref="OS.CryptographicException">The instance holds no private key.</exception>
    /// <remarks>
    /// The counterpart of <c>System.Security.Cryptography.PemEncoding.GetEncodedSize</c>, which is
    /// not available on every target framework this library supports. Rent a buffer of this size,
    /// call <see cref="TryExportPkcs8PrivateKeyPem"/>, and clear the buffer when finished.
    /// </remarks>
    public int GetPkcs8PrivateKeyPemSize()
    {
        byte[] blob = BuildPrivateKeyBlob();

        try
        {
            return PqcKeyFormat.GetPkcs8PemSize(AlgorithmOid, blob);
        }
        finally
        {
            CryptographicOperations.ZeroMemory(blob);
        }
    }

    /// <summary>
    /// Attempts to export this key as a PEM-encoded PKCS#8 PrivateKeyInfo, writing into a buffer
    /// the caller owns and can erase.
    /// </summary>
    /// <param name="destination">The buffer to receive the text, labelled <c>PRIVATE KEY</c>.</param>
    /// <param name="charsWritten">The number of characters written.</param>
    /// <returns><see langword="false"/> when <paramref name="destination"/> is too small.</returns>
    /// <exception cref="ObjectDisposedException">The instance has been disposed.</exception>
    /// <exception cref="OS.CryptographicException">The instance holds no private key.</exception>
    /// <remarks>
    /// <para>
    /// There is no allocating <c>ExportPkcs8PrivateKeyPem()</c>. The text this produces <i>is</i>
    /// the private key, and a <see cref="string"/> holding it could never be erased - so the only
    /// export this type offers is one that writes where the caller can clear it afterwards. Size
    /// the buffer with <see cref="GetPkcs8PrivateKeyPemSize"/>.
    /// </para>
    /// <para>
    /// When the buffer is too small nothing is written and <paramref name="charsWritten"/> is zero.
    /// </para>
    /// </remarks>
    public bool TryExportPkcs8PrivateKeyPem(Span<char> destination, out int charsWritten)
    {
        byte[] blob = BuildPrivateKeyBlob();

        try
        {
            return PqcKeyFormat.TryExportPkcs8Pem(AlgorithmOid, blob, destination, out charsWritten);
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
    /// Imports an SLH-DSA private key from a PKCS#8 EncryptedPrivateKeyInfo structure.
    /// </summary>
    /// <param name="password">The password, used verbatim as the key derivation input.</param>
    /// <param name="source">The DER-encoded EncryptedPrivateKeyInfo.</param>
    /// <returns>The imported key.</returns>
    /// <exception cref="OS.CryptographicException">
    /// The password is wrong, or the structure is malformed or is not SLH-DSA.
    /// </exception>
    public static SlhDsa ImportEncryptedPkcs8PrivateKey(
        ReadOnlySpan<byte> password,
        ReadOnlySpan<byte> source)
        => PqcKeyFormat.ImportEncryptedPkcs8(PbePassword.FromBytes(password), source, FromPkcs8Blob);

    /// <summary>
    /// Imports an SLH-DSA private key from a PKCS#8 EncryptedPrivateKeyInfo structure.
    /// </summary>
    /// <param name="password">The password, encoded per the scheme in the structure.</param>
    /// <param name="source">The DER-encoded EncryptedPrivateKeyInfo.</param>
    /// <returns>The imported key.</returns>
    /// <exception cref="OS.CryptographicException">
    /// The password is wrong, or the structure is malformed or is not SLH-DSA.
    /// </exception>
    public static SlhDsa ImportEncryptedPkcs8PrivateKey(
        ReadOnlySpan<char> password,
        ReadOnlySpan<byte> source)
        => PqcKeyFormat.ImportEncryptedPkcs8(PbePassword.FromChars(password), source, FromPkcs8Blob);

    // Dropped from the shipping surface: a string password cannot be overwritten once created.
    // Retained unbuilt for review; see docfx/packages/security/cryptography/erasable-memory.md.
#if SECURITY_REVIEW
    /// <summary>
    /// Imports an SLH-DSA private key from a PKCS#8 EncryptedPrivateKeyInfo structure.
    /// </summary>
    /// <param name="password">The password.</param>
    /// <param name="source">The DER-encoded EncryptedPrivateKeyInfo.</param>
    /// <returns>The imported key.</returns>
    /// <exception cref="ArgumentNullException">
    /// <paramref name="password"/> or <paramref name="source"/> is null.
    /// </exception>
    /// <exception cref="OS.CryptographicException">
    /// The password is wrong, or the structure is malformed or is not SLH-DSA.
    /// </exception>
    public static SlhDsa ImportEncryptedPkcs8PrivateKey(string password, byte[] source)
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
#endif

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

    // Dropped from the shipping surface: a string password cannot be overwritten once created.
    // Retained unbuilt for review; see docfx/packages/security/cryptography/erasable-memory.md.
#if SECURITY_REVIEW
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
#endif

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

    // Dropped from the shipping surface: a string password cannot be overwritten once created.
    // Retained unbuilt for review; see docfx/packages/security/cryptography/erasable-memory.md.
#if SECURITY_REVIEW
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
#endif

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

    // Dropped from the shipping surface: a string password cannot be overwritten once created.
    // Retained unbuilt for review; see docfx/packages/security/cryptography/erasable-memory.md.
#if SECURITY_REVIEW
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
#endif


    /// <summary>
    /// Attempts to export this key as a PEM-encoded PKCS#8 EncryptedPrivateKeyInfo.
    /// </summary>
    /// <param name="password">The password, used verbatim as the key derivation input.</param>
    /// <param name="pbeOptions">Selects the cipher, pseudorandom function and iteration count.</param>
    /// <param name="destination">The buffer to receive the text.</param>
    /// <param name="charsWritten">The number of characters written.</param>
    /// <returns><see langword="false"/> when <paramref name="destination"/> is too small.</returns>
    /// <exception cref="ObjectDisposedException">The instance has been disposed.</exception>
    /// <exception cref="OS.CryptographicException">The instance holds no private key.</exception>
    public bool TryExportEncryptedPkcs8PrivateKeyPem(
        ReadOnlySpan<byte> password,
        PbeOptions pbeOptions,
        Span<char> destination,
        out int charsWritten)
        => TryExportEncryptedPem(PbePassword.FromBytes(password), pbeOptions, destination, out charsWritten);

    /// <summary>
    /// Attempts to export this key as a PEM-encoded PKCS#8 EncryptedPrivateKeyInfo.
    /// </summary>
    /// <param name="password">The password, encoded per the scheme being written.</param>
    /// <param name="pbeOptions">Selects the cipher, pseudorandom function and iteration count.</param>
    /// <param name="destination">The buffer to receive the text.</param>
    /// <param name="charsWritten">The number of characters written.</param>
    /// <returns><see langword="false"/> when <paramref name="destination"/> is too small.</returns>
    /// <exception cref="ObjectDisposedException">The instance has been disposed.</exception>
    /// <exception cref="OS.CryptographicException">The instance holds no private key.</exception>
    /// <remarks>
    /// There is no size helper for this member: measuring the output means running the key
    /// derivation function, which at a realistic iteration count is the whole cost of the export.
    /// Use <see cref="ExportEncryptedPkcs8PrivateKeyPem(ReadOnlySpan{char}, PbeOptions)"/> - safe,
    /// because the payload is ciphertext - or grow a buffer until this succeeds.
    /// </remarks>
    public bool TryExportEncryptedPkcs8PrivateKeyPem(
        ReadOnlySpan<char> password,
        PbeOptions pbeOptions,
        Span<char> destination,
        out int charsWritten)
        => TryExportEncryptedPem(PbePassword.FromChars(password), pbeOptions, destination, out charsWritten);

    // ========================================================================
    // PEM
    // ========================================================================

    /// <summary>
    /// Imports an SLH-DSA key from an RFC 7468 PEM-encoded string.
    /// </summary>
    /// <param name="source">The PEM text.</param>
    /// <returns>The imported key.</returns>
    /// <exception cref="ArgumentException">
    /// <paramref name="source"/> contains no PEM block with a recognized label, or more than one.
    /// </exception>
    public static SlhDsa ImportFromPem(ReadOnlySpan<char> source)
        => PqcKeyFormat.ImportFromPem(source, FromPemBlob);

    // Dropped from the shipping surface: a PEM-encoded plaintext private key in a string cannot be overwritten.
    // Retained unbuilt for review; see docfx/packages/security/cryptography/erasable-memory.md.
#if SECURITY_REVIEW
    /// <summary>
    /// Imports an SLH-DSA key from an RFC 7468 PEM-encoded string.
    /// </summary>
    /// <param name="source">The PEM text.</param>
    /// <returns>The imported key.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="source"/> is null.</exception>
    /// <exception cref="ArgumentException">
    /// <paramref name="source"/> contains no PEM block with a recognized label, or more than one.
    /// </exception>
    public static SlhDsa ImportFromPem(string source)
    {
        if (source is null)
        {
            throw new ArgumentNullException(nameof(source));
        }

        return ImportFromPem(source.AsSpan());
    }
#endif

    /// <summary>
    /// Imports an SLH-DSA key from an encrypted RFC 7468 PEM-encoded string.
    /// </summary>
    /// <param name="source">The PEM text.</param>
    /// <param name="password">The password.</param>
    /// <returns>The imported key.</returns>
    /// <exception cref="ArgumentException">
    /// <paramref name="source"/> contains no encrypted private key, or more than one.
    /// </exception>
    public static SlhDsa ImportFromEncryptedPem(ReadOnlySpan<char> source, ReadOnlySpan<char> password)
        => PqcKeyFormat.ImportFromEncryptedPem(source, PbePassword.FromChars(password), FromPkcs8Blob);

    /// <summary>
    /// Imports an SLH-DSA key from an encrypted RFC 7468 PEM-encoded string.
    /// </summary>
    /// <param name="source">The PEM text.</param>
    /// <param name="passwordBytes">The password, used verbatim as the key derivation input.</param>
    /// <returns>The imported key.</returns>
    /// <exception cref="ArgumentException">
    /// <paramref name="source"/> contains no encrypted private key, or more than one.
    /// </exception>
    public static SlhDsa ImportFromEncryptedPem(ReadOnlySpan<char> source, ReadOnlySpan<byte> passwordBytes)
        => PqcKeyFormat.ImportFromEncryptedPem(source, PbePassword.FromBytes(passwordBytes), FromPkcs8Blob);

    // Dropped from the shipping surface: a string password cannot be overwritten once created.
    // Retained unbuilt for review; see docfx/packages/security/cryptography/erasable-memory.md.
#if SECURITY_REVIEW
    /// <summary>
    /// Imports an SLH-DSA key from an encrypted RFC 7468 PEM-encoded string.
    /// </summary>
    /// <param name="source">The PEM text.</param>
    /// <param name="password">The password.</param>
    /// <returns>The imported key.</returns>
    /// <exception cref="ArgumentNullException">An argument is null.</exception>
    /// <exception cref="ArgumentException">
    /// <paramref name="source"/> contains no encrypted private key, or more than one.
    /// </exception>
    public static SlhDsa ImportFromEncryptedPem(string source, string password)
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
#endif

    /// <summary>
    /// Imports an SLH-DSA key from an encrypted RFC 7468 PEM-encoded string.
    /// </summary>
    /// <param name="source">The PEM text.</param>
    /// <param name="passwordBytes">The password, used verbatim as the key derivation input.</param>
    /// <returns>The imported key.</returns>
    /// <exception cref="ArgumentNullException">An argument is null.</exception>
    /// <exception cref="ArgumentException">
    /// <paramref name="source"/> contains no encrypted private key, or more than one.
    /// </exception>
    public static SlhDsa ImportFromEncryptedPem(string source, byte[] passwordBytes)
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
    // SLH-DSA specifics
    // ========================================================================

    /// <summary>
    /// Gets the CSOR object identifier for this key's parameter set.
    /// </summary>
    private string AlgorithmOid => PqcKeyOids.ForSlhDsa(Algorithm.Name);

    /// <summary>
    /// Builds the contents of the PKCS#8 <c>privateKey</c> OCTET STRING.
    /// </summary>
    /// <remarks>
    /// Unlike ML-KEM and ML-DSA there is no CHOICE and no seed arm here: FIPS 205 private keys are
    /// the raw 4n bytes SK.seed ‖ SK.prf ‖ PK.seed ‖ PK.root, and the OCTET STRING carries them
    /// directly. Confirmed against what BouncyCastle emits for all twelve parameter sets.
    /// </remarks>
    private byte[] BuildPrivateKeyBlob()
    {
        ThrowIfDisposed();

        if (_privateKey is null)
        {
            throw new OS.CryptographicException(
                "The instance holds only a public key and cannot export a private key.");
        }

        return (byte[])_privateKey.Clone();
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

    /// <summary>
    /// Shared body of the two <c>TryExportEncryptedPkcs8PrivateKeyPem</c> overloads.
    /// </summary>
    /// <param name="password">The password.</param>
    /// <param name="pbeOptions">The password-based encryption options.</param>
    /// <param name="destination">The buffer to receive the text.</param>
    /// <param name="charsWritten">The number of characters written.</param>
    /// <returns><see langword="true"/> when the buffer was large enough.</returns>
    private bool TryExportEncryptedPem(
        PbePassword password,
        PbeOptions pbeOptions,
        Span<char> destination,
        out int charsWritten)
    {
        byte[] blob = BuildPrivateKeyBlob();

        try
        {
            return PqcKeyFormat.TryExportEncryptedPkcs8Pem(
                AlgorithmOid, blob, password, pbeOptions, destination, out charsWritten);
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
    private static SlhDsa FromSpkiBlob(string algorithmOid, byte[] publicKey)
    {
        SlhDsaAlgorithm algorithm = AlgorithmForOid(algorithmOid);
        DerGuard.KeyLength(
            publicKey.Length, algorithm.PublicKeySizeInBytes, "public key", algorithm.Name);
        return ImportSlhDsaPublicKey(algorithm, publicKey);
    }

    /// <summary>
    /// Builds an instance from a decoded PKCS#8 <c>privateKey</c> OCTET STRING.
    /// </summary>
    /// <remarks>
    /// No CHOICE to decode: the OCTET STRING is the key.
    /// </remarks>
    private static SlhDsa FromPkcs8Blob(string algorithmOid, byte[] privateKeyBlob)
    {
        SlhDsaAlgorithm algorithm = AlgorithmForOid(algorithmOid);
        DerGuard.KeyLength(
            privateKeyBlob.Length, algorithm.PrivateKeySizeInBytes, "private key", algorithm.Name);
        return ImportSlhDsaPrivateKey(algorithm, privateKeyBlob);
    }

    /// <summary>
    /// Dispatches a PEM block to the public or private importer. The label decides which, and
    /// <see cref="PqcKeyFormat.ImportFromPem"/> has already narrowed it to one of the two.
    /// </summary>
    private static SlhDsa FromPemBlob(string algorithmOid, byte[] key)
    {
        // A SubjectPublicKeyInfo yields a raw public key; a PrivateKeyInfo yields the CHOICE. The
        // two are told apart by length: only a public key can be exactly PublicKeySizeInBytes.
        SlhDsaAlgorithm algorithm = AlgorithmForOid(algorithmOid);
        return key.Length == algorithm.PublicKeySizeInBytes
            ? FromSpkiBlob(algorithmOid, key)
            : FromPkcs8Blob(algorithmOid, key);
    }

    private static SlhDsaAlgorithm AlgorithmForOid(string algorithmOid)
    {
        string? name = PqcKeyOids.SlhDsaNameFor(algorithmOid);

        if (name is null)
        {
            throw new OS.CryptographicException(
                $"The key algorithm '{algorithmOid}' is not an SLH-DSA parameter set.");
        }

        return name switch {
            "SLH-DSA-SHA2-128s" => SlhDsaAlgorithm.SlhDsaSha2_128s,
            "SLH-DSA-SHA2-128f" => SlhDsaAlgorithm.SlhDsaSha2_128f,
            "SLH-DSA-SHA2-192s" => SlhDsaAlgorithm.SlhDsaSha2_192s,
            "SLH-DSA-SHA2-192f" => SlhDsaAlgorithm.SlhDsaSha2_192f,
            "SLH-DSA-SHA2-256s" => SlhDsaAlgorithm.SlhDsaSha2_256s,
            "SLH-DSA-SHA2-256f" => SlhDsaAlgorithm.SlhDsaSha2_256f,
            "SLH-DSA-SHAKE-128s" => SlhDsaAlgorithm.SlhDsaShake128s,
            "SLH-DSA-SHAKE-128f" => SlhDsaAlgorithm.SlhDsaShake128f,
            "SLH-DSA-SHAKE-192s" => SlhDsaAlgorithm.SlhDsaShake192s,
            "SLH-DSA-SHAKE-192f" => SlhDsaAlgorithm.SlhDsaShake192f,
            "SLH-DSA-SHAKE-256s" => SlhDsaAlgorithm.SlhDsaShake256s,
            _ => SlhDsaAlgorithm.SlhDsaShake256f,
        };
    }
}
