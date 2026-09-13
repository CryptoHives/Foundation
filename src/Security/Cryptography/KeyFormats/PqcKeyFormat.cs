// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Security.Cryptography.KeyFormats;

using System;
using OS = System.Security.Cryptography;

/// <summary>
/// The one implementation of the PKCS#8, SubjectPublicKeyInfo and PEM members that
/// <c>MLKem</c>, <c>MLDsa</c> and <c>SlhDsa</c> each expose.
/// </summary>
/// <remarks>
/// <para>
/// The in-box types define the same key-format block on all three algorithms, and so do these -
/// twenty-seven members: the in-box shape minus the ones that moved a secret through a string, plus
/// the Span&lt;char&gt; PEM exports AsymmetricAlgorithm has and the in-box PQC types dropped.
/// C# has no mixins, so each type still has to <i>declare</i> those members - but none of them
/// implements anything: every one is a single call into this class, and the DER, PEM and
/// password-based encryption logic exists once.
/// </para>
/// <para>
/// What differs per algorithm is supplied as arguments: the algorithm OID, and for the import side
/// a delegate that turns a decoded <c>(oid, keyBytes)</c> pair into an instance. That keeps the
/// three façades uniform enough to read side by side.
/// </para>
/// </remarks>
internal static class PqcKeyFormat
{
    /// <summary>
    /// Builds an instance from a decoded key blob, throwing if the OID is not one this algorithm
    /// recognizes.
    /// </summary>
    /// <typeparam name="T">The key type.</typeparam>
    /// <param name="algorithmOid">The OID read from the encoding.</param>
    /// <param name="key">The decoded key bytes.</param>
    /// <returns>The new instance.</returns>
    internal delegate T KeyFactory<out T>(string algorithmOid, byte[] key);

    // ========================================================================
    // SubjectPublicKeyInfo
    // ========================================================================

    /// <summary>Exports a public key as a SubjectPublicKeyInfo.</summary>
    /// <param name="algorithmOid">The algorithm OID.</param>
    /// <param name="publicKey">The raw public key.</param>
    /// <returns>The DER encoding.</returns>
    public static byte[] ExportSpki(string algorithmOid, ReadOnlySpan<byte> publicKey)
        => Spki.Write(algorithmOid, publicKey);

    /// <summary>Exports a public key as a PEM-encoded SubjectPublicKeyInfo.</summary>
    /// <param name="algorithmOid">The algorithm OID.</param>
    /// <param name="publicKey">The raw public key.</param>
    /// <returns>The PEM text.</returns>
    public static string ExportSpkiPem(string algorithmOid, ReadOnlySpan<byte> publicKey)
        => PemFormat.EncodePublic(Spki.Write(algorithmOid, publicKey), PemLabels.PublicKey);

    /// <summary>Attempts to export a public key as a SubjectPublicKeyInfo.</summary>
    /// <param name="algorithmOid">The algorithm OID.</param>
    /// <param name="publicKey">The raw public key.</param>
    /// <param name="destination">The buffer to receive the encoding.</param>
    /// <param name="bytesWritten">The number of bytes written.</param>
    /// <returns><see langword="true"/> when the buffer was large enough.</returns>
    public static bool TryExportSpki(
        string algorithmOid,
        ReadOnlySpan<byte> publicKey,
        Span<byte> destination,
        out int bytesWritten)
        => TryWrite(Spki.Write(algorithmOid, publicKey), destination, out bytesWritten);

    /// <summary>
    /// Computes the exact number of characters <see cref="TryExportSpkiPem"/> writes.
    /// </summary>
    /// <param name="algorithmOid">The algorithm OID.</param>
    /// <param name="publicKey">The raw public key.</param>
    /// <returns>The encoded length in characters.</returns>
    public static int GetSpkiPemSize(string algorithmOid, ReadOnlySpan<byte> publicKey)
        => PemFormat.GetEncodedSize(Spki.Write(algorithmOid, publicKey).Length, PemLabels.PublicKey);

    /// <summary>Attempts to export a public key as a PEM-encoded SubjectPublicKeyInfo.</summary>
    /// <param name="algorithmOid">The algorithm OID.</param>
    /// <param name="publicKey">The raw public key.</param>
    /// <param name="destination">The buffer to receive the text.</param>
    /// <param name="charsWritten">The number of characters written.</param>
    /// <returns><see langword="true"/> when the buffer was large enough.</returns>
    public static bool TryExportSpkiPem(
        string algorithmOid,
        ReadOnlySpan<byte> publicKey,
        Span<char> destination,
        out int charsWritten)
        => PemFormat.TryEncode(
            Spki.Write(algorithmOid, publicKey), PemLabels.PublicKey, destination, out charsWritten);

    /// <summary>Imports a SubjectPublicKeyInfo.</summary>
    /// <typeparam name="T">The key type.</typeparam>
    /// <param name="source">The DER encoding.</param>
    /// <param name="factory">Builds the instance from the decoded key.</param>
    /// <returns>The imported key.</returns>
    public static T ImportSpki<T>(ReadOnlySpan<byte> source, KeyFactory<T> factory)
    {
        byte[] publicKey = Spki.Read(source, out string algorithmOid);
        return factory(algorithmOid, publicKey);
    }

    // ========================================================================
    // PKCS#8 PrivateKeyInfo
    // ========================================================================

    /// <summary>Exports a private key blob as a PKCS#8 PrivateKeyInfo.</summary>
    /// <param name="algorithmOid">The algorithm OID.</param>
    /// <param name="privateKeyBlob">The contents of the privateKey OCTET STRING.</param>
    /// <returns>The DER encoding.</returns>
    public static byte[] ExportPkcs8(string algorithmOid, ReadOnlySpan<byte> privateKeyBlob)
        => Pkcs8.Write(algorithmOid, privateKeyBlob);

    // Dropped from the shipping surface: a PEM-encoded plaintext private key in a string cannot be
    // overwritten.
    // Retained unbuilt for review; see docfx/packages/security/cryptography/erasable-memory.md.
#if OBSOLETE_SECRET_AS_STRING_API
    /// <summary>Exports a private key blob as a PEM-encoded PKCS#8 PrivateKeyInfo.</summary>
    /// <param name="algorithmOid">The algorithm OID.</param>
    /// <param name="privateKeyBlob">The contents of the privateKey OCTET STRING.</param>
    /// <returns>The PEM text.</returns>
    /// <remarks>
    /// The returned string is the plaintext private key and cannot be overwritten; compare against
    /// <see cref="TryExportPkcs8Pem"/>.
    /// </remarks>
    public static string ExportPkcs8Pem(string algorithmOid, ReadOnlySpan<byte> privateKeyBlob)
    {
        byte[] encoded = Pkcs8.Write(algorithmOid, privateKeyBlob);

        try
        {
            return PemFormat.EncodePublic(encoded, PemLabels.Pkcs8PrivateKey);
        }
        finally
        {
            CryptographicOperations.ZeroMemory(encoded);
        }
    }
#endif

    /// <summary>
    /// Computes the exact number of characters <see cref="TryExportPkcs8Pem"/> writes.
    /// </summary>
    /// <param name="algorithmOid">The algorithm OID.</param>
    /// <param name="privateKeyBlob">The contents of the privateKey OCTET STRING.</param>
    /// <returns>The encoded length in characters.</returns>
    /// <remarks>
    /// The trade off is that the PKCS#8 encoding has to be built to be measured.
    /// </remarks>
    public static int GetPkcs8PemSize(string algorithmOid, ReadOnlySpan<byte> privateKeyBlob)
    {
        byte[] encoded = Pkcs8.Write(algorithmOid, privateKeyBlob);

        try
        {
            return PemFormat.GetEncodedSize(encoded.Length, PemLabels.Pkcs8PrivateKey);
        }
        finally
        {
            CryptographicOperations.ZeroMemory(encoded);
        }
    }

    /// <summary>
    /// Attempts to export a private key blob as a PEM-encoded PKCS#8 PrivateKeyInfo.
    /// </summary>
    /// <param name="algorithmOid">The algorithm OID.</param>
    /// <param name="privateKeyBlob">The contents of the privateKey OCTET STRING.</param>
    /// <param name="destination">The buffer to receive the text.</param>
    /// <param name="charsWritten">The number of characters written.</param>
    /// <returns><see langword="true"/> when the buffer was large enough.</returns>
    /// <remarks>
    /// There is deliberately no allocating counterpart since a PEM-encoded plaintext private key
    /// is not erasable. Use <see cref="GetPkcs8PemSize"/> to detrmine the buffer size, then call
    /// this method to fill it. The buffer is not modified when it is too small.
    /// </remarks>
    public static bool TryExportPkcs8Pem(
        string algorithmOid,
        ReadOnlySpan<byte> privateKeyBlob,
        Span<char> destination,
        out int charsWritten)
    {
        byte[] encoded = Pkcs8.Write(algorithmOid, privateKeyBlob);

        try
        {
            return PemFormat.TryEncode(encoded, PemLabels.Pkcs8PrivateKey, destination, out charsWritten);
        }
        finally
        {
            CryptographicOperations.ZeroMemory(encoded);
        }
    }

    /// <summary>Attempts to export a private key blob as a PKCS#8 PrivateKeyInfo.</summary>
    /// <param name="algorithmOid">The algorithm OID.</param>
    /// <param name="privateKeyBlob">The contents of the privateKey OCTET STRING.</param>
    /// <param name="destination">The buffer to receive the encoding.</param>
    /// <param name="bytesWritten">The number of bytes written.</param>
    /// <returns><see langword="true"/> when the buffer was large enough.</returns>
    public static bool TryExportPkcs8(
        string algorithmOid,
        ReadOnlySpan<byte> privateKeyBlob,
        Span<byte> destination,
        out int bytesWritten)
    {
        byte[] encoded = Pkcs8.Write(algorithmOid, privateKeyBlob);

        try
        {
            return TryWrite(encoded, destination, out bytesWritten);
        }
        finally
        {
            // The encoding carries private key material; do not leave it for the collector.
            CryptographicOperations.ZeroMemory(encoded);
        }
    }

    /// <summary>Imports a PKCS#8 PrivateKeyInfo.</summary>
    /// <typeparam name="T">The key type.</typeparam>
    /// <param name="source">The DER encoding.</param>
    /// <param name="factory">Builds the instance from the decoded private key blob.</param>
    /// <returns>The imported key.</returns>
    public static T ImportPkcs8<T>(ReadOnlySpan<byte> source, KeyFactory<T> factory)
    {
        byte[] blob = Pkcs8.Read(source, out string algorithmOid);

        try
        {
            return factory(algorithmOid, blob);
        }
        finally
        {
            CryptographicOperations.ZeroMemory(blob);
        }
    }

    // ========================================================================
    // PKCS#8 EncryptedPrivateKeyInfo
    // ========================================================================

    /// <summary>Exports a private key blob as an encrypted PKCS#8 structure.</summary>
    /// <param name="algorithmOid">The algorithm OID.</param>
    /// <param name="privateKeyBlob">The contents of the privateKey OCTET STRING.</param>
    /// <param name="password">The password.</param>
    /// <param name="pbeOptions">Selects the cipher, pseudorandom function and iteration count.</param>
    /// <returns>The DER encoding.</returns>
    public static byte[] ExportEncryptedPkcs8(
        string algorithmOid,
        ReadOnlySpan<byte> privateKeyBlob,
        PbePassword password,
        PbeOptions pbeOptions)
    {
        byte[] pkcs8 = Pkcs8.Write(algorithmOid, privateKeyBlob);

        try
        {
            return EncryptedPkcs8.Write(pkcs8, password, pbeOptions);
        }
        finally
        {
            CryptographicOperations.ZeroMemory(pkcs8);
        }
    }

    /// <summary>Exports a private key blob as a PEM-encoded encrypted PKCS#8 structure.</summary>
    /// <param name="algorithmOid">The algorithm OID.</param>
    /// <param name="privateKeyBlob">The contents of the privateKey OCTET STRING.</param>
    /// <param name="password">The password.</param>
    /// <param name="pbeOptions">Selects the cipher, pseudorandom function and iteration count.</param>
    /// <returns>The PEM text.</returns>
    public static string ExportEncryptedPkcs8Pem(
        string algorithmOid,
        ReadOnlySpan<byte> privateKeyBlob,
        PbePassword password,
        PbeOptions pbeOptions)
    {
        // The payload here is ciphertext, so returning a string is safe.
        return PemFormat.EncodePublic(
            ExportEncryptedPkcs8(algorithmOid, privateKeyBlob, password, pbeOptions),
            PemLabels.EncryptedPkcs8PrivateKey);
    }

    /// <summary>Attempts to export a private key blob as an encrypted PKCS#8 structure.</summary>
    /// <param name="algorithmOid">The algorithm OID.</param>
    /// <param name="privateKeyBlob">The contents of the privateKey OCTET STRING.</param>
    /// <param name="password">The password.</param>
    /// <param name="pbeOptions">Selects the cipher, pseudorandom function and iteration count.</param>
    /// <param name="destination">The buffer to receive the encoding.</param>
    /// <param name="bytesWritten">The number of bytes written.</param>
    /// <returns><see langword="true"/> when the buffer was large enough.</returns>
    public static bool TryExportEncryptedPkcs8(
        string algorithmOid,
        ReadOnlySpan<byte> privateKeyBlob,
        PbePassword password,
        PbeOptions pbeOptions,
        Span<byte> destination,
        out int bytesWritten)
        => TryWrite(
            ExportEncryptedPkcs8(algorithmOid, privateKeyBlob, password, pbeOptions),
            destination,
            out bytesWritten);

    /// <summary>
    /// Attempts to export a private key blob as a PEM-encoded encrypted PKCS#8 structure.
    /// </summary>
    /// <param name="algorithmOid">The algorithm OID.</param>
    /// <param name="privateKeyBlob">The contents of the privateKey OCTET STRING.</param>
    /// <param name="password">The password.</param>
    /// <param name="pbeOptions">Selects the cipher, pseudorandom function and iteration count.</param>
    /// <param name="destination">The buffer to receive the text.</param>
    /// <param name="charsWritten">The number of characters written.</param>
    /// <returns><see langword="true"/> when the buffer was large enough.</returns>
    /// <remarks>
    /// There is deliberately no <c>GetEncryptedPkcs8PemSize</c>. Measuring the output means running
    /// the key derivation function, and at a realistic iteration count that is the entire cost of
    /// the export - a caller who sized a buffer and then exported would pay it twice. Use the
    /// allocating <see cref="ExportEncryptedPkcs8Pem"/>, which is safe here because the payload is
    /// ciphertext, or grow a buffer until this returns <see langword="true"/>.
    /// </remarks>
    public static bool TryExportEncryptedPkcs8Pem(
        string algorithmOid,
        ReadOnlySpan<byte> privateKeyBlob,
        PbePassword password,
        PbeOptions pbeOptions,
        Span<char> destination,
        out int charsWritten)
    {
        byte[] encrypted = ExportEncryptedPkcs8(algorithmOid, privateKeyBlob, password, pbeOptions);
        return PemFormat.TryEncode(
            encrypted, PemLabels.EncryptedPkcs8PrivateKey, destination, out charsWritten);
    }

    /// <summary>Imports an encrypted PKCS#8 structure.</summary>
    /// <typeparam name="T">The key type.</typeparam>
    /// <param name="password">The password.</param>
    /// <param name="source">The DER encoding.</param>
    /// <param name="factory">Builds the instance from the decoded private key blob.</param>
    /// <returns>The imported key.</returns>
    public static T ImportEncryptedPkcs8<T>(
        PbePassword password,
        ReadOnlySpan<byte> source,
        KeyFactory<T> factory)
    {
        byte[] pkcs8 = EncryptedPkcs8.Read(source, password);

        try
        {
            return ImportPkcs8(pkcs8, factory);
        }
        finally
        {
            CryptographicOperations.ZeroMemory(pkcs8);
        }
    }

    // ========================================================================
    // PEM
    // ========================================================================

    /// <summary>
    /// Imports the single PEM block carrying a public or unencrypted private key.
    /// </summary>
    /// <typeparam name="T">The key type.</typeparam>
    /// <param name="pem">The PEM document.</param>
    /// <param name="factory">Builds the instance from the decoded key.</param>
    /// <returns>The imported key.</returns>
    /// <exception cref="ArgumentException">
    /// The document contains no recognized PEM label, or more than one.
    /// </exception>
    /// <remarks>
    /// Matches the in-box rule: labels this type does not understand are skipped, but two
    /// understood blocks are an error rather than a silent choice of the first. An
    /// <c>ENCRYPTED PRIVATE KEY</c> block counts as recognized and is rejected with a message
    /// pointing at <c>ImportFromEncryptedPem</c>, because failing with "no key found" when the
    /// document plainly holds one is the more confusing outcome.
    /// </remarks>
    public static T ImportFromPem<T>(ReadOnlySpan<char> pem, KeyFactory<T> factory)
    {
        PemBlock found = default;
        int position = 0;

        while (PemFormat.TryFindBlock(pem, ref position, out PemBlock block))
        {
            if (!block.LabelIs(pem, PemLabels.PublicKey)
                && !block.LabelIs(pem, PemLabels.Pkcs8PrivateKey)
                && !block.LabelIs(pem, PemLabels.EncryptedPkcs8PrivateKey))
            {
                continue;
            }

            if (found.Found)
            {
                throw new ArgumentException(
                    "The PEM data contains more than one key with a recognized label.", nameof(pem));
            }

            found = block;
        }

        if (!found.Found)
        {
            throw new ArgumentException(
                "The PEM data does not contain a key with a recognized label.", nameof(pem));
        }

        if (found.LabelIs(pem, PemLabels.EncryptedPkcs8PrivateKey))
        {
            throw new ArgumentException(
                "The PEM data contains an encrypted private key; use ImportFromEncryptedPem.",
                nameof(pem));
        }

        bool isPublic = found.LabelIs(pem, PemLabels.PublicKey);
        byte[] der = DecodeOrThrow(pem, found, nameof(pem));

        try
        {
            return isPublic ? ImportSpki(der, factory) : ImportPkcs8(der, factory);
        }
        finally
        {
            CryptographicOperations.ZeroMemory(der);
        }
    }

    /// <summary>
    /// Imports the single <c>ENCRYPTED PRIVATE KEY</c> block in a PEM document.
    /// </summary>
    /// <typeparam name="T">The key type.</typeparam>
    /// <param name="pem">The PEM document.</param>
    /// <param name="password">The password.</param>
    /// <param name="factory">Builds the instance from the decoded private key blob.</param>
    /// <returns>The imported key.</returns>
    /// <exception cref="ArgumentException">
    /// The document contains no encrypted private key, or more than one.
    /// </exception>
    public static T ImportFromEncryptedPem<T>(
        ReadOnlySpan<char> pem,
        PbePassword password,
        KeyFactory<T> factory)
    {
        PemBlock found = default;
        int position = 0;

        while (PemFormat.TryFindBlock(pem, ref position, out PemBlock block))
        {
            if (!block.LabelIs(pem, PemLabels.EncryptedPkcs8PrivateKey))
            {
                continue;
            }

            if (found.Found)
            {
                throw new ArgumentException(
                    "The PEM data contains more than one encrypted private key.", nameof(pem));
            }

            found = block;
        }

        if (!found.Found)
        {
            throw new ArgumentException(
                "The PEM data does not contain an encrypted private key.", nameof(pem));
        }

        byte[] der = DecodeOrThrow(pem, found, nameof(pem));
        return ImportEncryptedPkcs8(password, der, factory);
    }

    private static byte[] DecodeOrThrow(ReadOnlySpan<char> pem, PemBlock block, string parameterName)
    {
        try
        {
            return PemFormat.Decode(pem, block);
        }
        catch (FormatException e)
        {
            throw new ArgumentException("The PEM data is not valid base64.", parameterName, e);
        }
    }

    /// <summary>
    /// Copies an encoding into a caller buffer, reporting failure rather than throwing when the
    /// buffer is too small and leaving it untouched in that case.
    /// </summary>
    private static bool TryWrite(byte[] encoded, Span<byte> destination, out int bytesWritten)
    {
        if (destination.Length < encoded.Length)
        {
            bytesWritten = 0;
            return false;
        }

        encoded.AsSpan().CopyTo(destination);
        bytesWritten = encoded.Length;
        return true;
    }
}
