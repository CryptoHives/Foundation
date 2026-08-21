// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace Cryptography.Tests.Adapter.Kem;

using Org.BouncyCastle.Crypto.Generators;
using Org.BouncyCastle.Crypto.Kems;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Security;
using System;
using CH = CryptoHives.Foundation.Security.Cryptography.Kem;

/// <summary>
/// Uniform surface over the ML-KEM implementations under comparison, so tests and
/// benchmarks can drive all of them through one shape.
/// </summary>
/// <remarks>
/// <para>
/// Plays the same role for KEMs that <c>IOneShotHash</c> plays for hashes and <c>IMac</c>
/// for MACs: the implementations have genuinely different APIs — key-holding versus
/// stateless, span-based versus <c>byte[]</c>-with-offsets — and a fair comparison needs a
/// common one. Two rules keep it honest:
/// </para>
/// <list type="bullet">
///   <item><description>
///     All buffers are <c>byte[]</c>. BouncyCastle's encapsulator only accepts
///     <c>byte[]</c> with offsets, so exposing spans would force a per-call copy on one
///     competitor and distort the result.
///   </description></item>
///   <item><description>
///     Everything an implementation can legitimately hoist out of the operation — importing
///     a key, constructing an encapsulator — happens in <see cref="Prepare"/>. Work an
///     implementation genuinely repeats per call stays inside the measured method. That is
///     deliberate: the stateless <see cref="CH.IKem"/> path re-validates the decapsulation
///     key on every <c>Decapsulate</c>, and a benchmark should show that rather than hide it.
///   </description></item>
/// </list>
/// </remarks>
public interface IKemRunner : IDisposable
{
    /// <summary>Gets the encapsulation key size in bytes.</summary>
    int EncapsulationKeySizeBytes { get; }

    /// <summary>Gets the decapsulation key size in bytes.</summary>
    int DecapsulationKeySizeBytes { get; }

    /// <summary>Gets the ciphertext size in bytes.</summary>
    int CiphertextSizeBytes { get; }

    /// <summary>Gets the shared secret size in bytes.</summary>
    int SharedSecretSizeBytes { get; }

    /// <summary>
    /// Imports the key material the <see cref="Encapsulate"/> and <see cref="Decapsulate"/>
    /// methods operate on. Called once from setup.
    /// </summary>
    /// <param name="encapsulationKey">The encapsulation key.</param>
    /// <param name="decapsulationKey">The expanded decapsulation key.</param>
    void Prepare(byte[] encapsulationKey, byte[] decapsulationKey);

    /// <summary>
    /// Produces a fresh key pair using the implementation's own natural API and returns the
    /// result so the work cannot be optimized away.
    /// </summary>
    /// <returns>The generated key pair, in whatever form the implementation produces.</returns>
    /// <remarks>
    /// The allocation profiles differ by design: the stateless path writes into caller-owned
    /// buffers, while the key-holding APIs allocate a key object per call.
    /// </remarks>
    object GenerateKeyPair();

    /// <summary>Encapsulates into caller-owned buffers.</summary>
    /// <param name="ciphertext">Receives the ciphertext.</param>
    /// <param name="sharedSecret">Receives the shared secret.</param>
    void Encapsulate(byte[] ciphertext, byte[] sharedSecret);

    /// <summary>Decapsulates into a caller-owned buffer.</summary>
    /// <param name="ciphertext">The ciphertext.</param>
    /// <param name="sharedSecret">Receives the shared secret.</param>
    void Decapsulate(byte[] ciphertext, byte[] sharedSecret);
}

/// <summary>
/// Adapts the key-holding <see cref="CH.MLKem"/> API — the recommended entry point, and the
/// one that mirrors <c>System.Security.Cryptography.MLKem</c>.
/// </summary>
public sealed class MLKemAdapter : IKemRunner
{
    private readonly CH.MLKemAlgorithm _algorithm;
    private CH.MLKem? _encapsulator;
    private CH.MLKem? _decapsulator;

    /// <summary>
    /// Initializes a new instance of the <see cref="MLKemAdapter"/> class.
    /// </summary>
    /// <param name="algorithm">The parameter set.</param>
    public MLKemAdapter(CH.MLKemAlgorithm algorithm) => _algorithm = algorithm;

    /// <inheritdoc/>
    public int EncapsulationKeySizeBytes => _algorithm.EncapsulationKeySizeInBytes;

    /// <inheritdoc/>
    public int DecapsulationKeySizeBytes => _algorithm.DecapsulationKeySizeInBytes;

    /// <inheritdoc/>
    public int CiphertextSizeBytes => _algorithm.CiphertextSizeInBytes;

    /// <inheritdoc/>
    public int SharedSecretSizeBytes => _algorithm.SharedSecretSizeInBytes;

    /// <inheritdoc/>
    public void Prepare(byte[] encapsulationKey, byte[] decapsulationKey)
    {
        _encapsulator = CH.MLKem.ImportEncapsulationKey(_algorithm, encapsulationKey);
        _decapsulator = CH.MLKem.ImportDecapsulationKey(_algorithm, decapsulationKey);
    }

    /// <inheritdoc/>
    public object GenerateKeyPair() => CH.MLKem.GenerateKey(_algorithm);

    /// <inheritdoc/>
    public void Encapsulate(byte[] ciphertext, byte[] sharedSecret)
        => _encapsulator!.Encapsulate(ciphertext, sharedSecret);

    /// <inheritdoc/>
    public void Decapsulate(byte[] ciphertext, byte[] sharedSecret)
        => _decapsulator!.Decapsulate(ciphertext, sharedSecret);

    /// <inheritdoc/>
    public void Dispose()
    {
        _encapsulator?.Dispose();
        _decapsulator?.Dispose();
    }
}

/// <summary>
/// Adapts the stateless <see cref="CH.IKem"/> API, where the caller owns the raw key bytes.
/// </summary>
public sealed class MLKemStatelessAdapter : IKemRunner
{
    private readonly CH.IKem _kem;
    private readonly byte[] _keyGenEk;
    private readonly byte[] _keyGenDk;
    private byte[] _encapsulationKey = [];
    private byte[] _decapsulationKey = [];

    /// <summary>
    /// Initializes a new instance of the <see cref="MLKemStatelessAdapter"/> class.
    /// </summary>
    /// <param name="kem">The stateless KEM instance.</param>
    public MLKemStatelessAdapter(CH.IKem kem)
    {
        _kem = kem;
        _keyGenEk = new byte[kem.EncapsulationKeySizeBytes];
        _keyGenDk = new byte[kem.DecapsulationKeySizeBytes];
    }

    /// <inheritdoc/>
    public int EncapsulationKeySizeBytes => _kem.EncapsulationKeySizeBytes;

    /// <inheritdoc/>
    public int DecapsulationKeySizeBytes => _kem.DecapsulationKeySizeBytes;

    /// <inheritdoc/>
    public int CiphertextSizeBytes => _kem.CiphertextSizeBytes;

    /// <inheritdoc/>
    public int SharedSecretSizeBytes => _kem.SharedSecretSizeBytes;

    /// <inheritdoc/>
    public void Prepare(byte[] encapsulationKey, byte[] decapsulationKey)
    {
        _encapsulationKey = encapsulationKey;
        _decapsulationKey = decapsulationKey;
    }

    /// <inheritdoc/>
    /// <remarks>Writes into buffers owned by this adapter, so it allocates nothing per call.</remarks>
    public object GenerateKeyPair()
    {
        _kem.GenerateKeyPair(_keyGenEk, _keyGenDk);
        return _keyGenEk;
    }

    /// <inheritdoc/>
    public void Encapsulate(byte[] ciphertext, byte[] sharedSecret)
        => _kem.Encapsulate(_encapsulationKey, ciphertext, sharedSecret);

    /// <inheritdoc/>
    /// <remarks>
    /// Re-runs the FIPS 203 §7.3 hash check on every call, by design of the stateless API —
    /// there is no imported key to attach the check to.
    /// </remarks>
    public void Decapsulate(byte[] ciphertext, byte[] sharedSecret)
        => _kem.Decapsulate(_decapsulationKey, ciphertext, sharedSecret);

    /// <inheritdoc/>
    public void Dispose() => _kem.Dispose();
}

/// <summary>
/// Adapts BouncyCastle's ML-KEM, available on every target framework.
/// </summary>
public sealed class BouncyCastleKemAdapter : IKemRunner
{
    private readonly MLKemParameters _parameters;
    private readonly SecureRandom _random = new();
    private readonly MLKemKeyPairGenerator _generator = new();
    private MLKemEncapsulator? _encapsulator;
    private MLKemDecapsulator? _decapsulator;

    /// <summary>
    /// Initializes a new instance of the <see cref="BouncyCastleKemAdapter"/> class.
    /// </summary>
    /// <param name="parameters">The BouncyCastle parameter set.</param>
    public BouncyCastleKemAdapter(MLKemParameters parameters)
    {
        _parameters = parameters;
        _generator.Init(new MLKemKeyGenerationParameters(_random, parameters));
    }

    /// <inheritdoc/>
    public int EncapsulationKeySizeBytes { get; private set; }

    /// <inheritdoc/>
    public int DecapsulationKeySizeBytes { get; private set; }

    /// <inheritdoc/>
    public int CiphertextSizeBytes => _encapsulator!.EncapsulationLength;

    /// <inheritdoc/>
    public int SharedSecretSizeBytes => _encapsulator!.SecretLength;

    /// <inheritdoc/>
    public void Prepare(byte[] encapsulationKey, byte[] decapsulationKey)
    {
        EncapsulationKeySizeBytes = encapsulationKey.Length;
        DecapsulationKeySizeBytes = decapsulationKey.Length;

        _encapsulator = new MLKemEncapsulator(_parameters);
        _encapsulator.Init(new ParametersWithRandom(
            MLKemPublicKeyParameters.FromEncoding(_parameters, encapsulationKey), _random));

        _decapsulator = new MLKemDecapsulator(_parameters);
        _decapsulator.Init(MLKemPrivateKeyParameters.FromEncoding(_parameters, decapsulationKey));
    }

    /// <inheritdoc/>
    public object GenerateKeyPair() => _generator.GenerateKeyPair();

    /// <inheritdoc/>
    public void Encapsulate(byte[] ciphertext, byte[] sharedSecret)
        => _encapsulator!.Encapsulate(ciphertext, 0, ciphertext.Length, sharedSecret, 0, sharedSecret.Length);

    /// <inheritdoc/>
    public void Decapsulate(byte[] ciphertext, byte[] sharedSecret)
        => _decapsulator!.Decapsulate(ciphertext, 0, ciphertext.Length, sharedSecret, 0, sharedSecret.Length);

    /// <inheritdoc/>
    public void Dispose()
    {
        // BouncyCastle's ML-KEM types hold no unmanaged state.
    }
}

#if NET10_0_OR_GREATER
#pragma warning disable SYSLIB5006 // Post-quantum cryptography APIs may be experimental.

/// <summary>
/// Adapts the in-box <c>System.Security.Cryptography.MLKem</c>, backed by the OS provider.
/// </summary>
/// <remarks>
/// Only usable where <c>MLKem.IsSupported</c> is true, which on Windows means a recent CNG
/// build and on Linux means OpenSSL 3.5+. This is the reference point the managed
/// implementation is measured against.
/// </remarks>
public sealed class OSKemAdapter : IKemRunner
{
    private readonly System.Security.Cryptography.MLKemAlgorithm _algorithm;
    private System.Security.Cryptography.MLKem? _encapsulator;
    private System.Security.Cryptography.MLKem? _decapsulator;

    /// <summary>
    /// Initializes a new instance of the <see cref="OSKemAdapter"/> class.
    /// </summary>
    /// <param name="algorithm">The in-box parameter set.</param>
    public OSKemAdapter(System.Security.Cryptography.MLKemAlgorithm algorithm) => _algorithm = algorithm;

    /// <inheritdoc/>
    public int EncapsulationKeySizeBytes => _algorithm.EncapsulationKeySizeInBytes;

    /// <inheritdoc/>
    public int DecapsulationKeySizeBytes => _algorithm.DecapsulationKeySizeInBytes;

    /// <inheritdoc/>
    public int CiphertextSizeBytes => _algorithm.CiphertextSizeInBytes;

    /// <inheritdoc/>
    public int SharedSecretSizeBytes => _algorithm.SharedSecretSizeInBytes;

    /// <inheritdoc/>
    public void Prepare(byte[] encapsulationKey, byte[] decapsulationKey)
    {
        _encapsulator = System.Security.Cryptography.MLKem.ImportEncapsulationKey(_algorithm, encapsulationKey);
        _decapsulator = System.Security.Cryptography.MLKem.ImportDecapsulationKey(_algorithm, decapsulationKey);
    }

    /// <inheritdoc/>
    public object GenerateKeyPair() => System.Security.Cryptography.MLKem.GenerateKey(_algorithm);

    /// <inheritdoc/>
    public void Encapsulate(byte[] ciphertext, byte[] sharedSecret)
        => _encapsulator!.Encapsulate(ciphertext, sharedSecret);

    /// <inheritdoc/>
    public void Decapsulate(byte[] ciphertext, byte[] sharedSecret)
        => _decapsulator!.Decapsulate(ciphertext, sharedSecret);

    /// <inheritdoc/>
    public void Dispose()
    {
        _encapsulator?.Dispose();
        _decapsulator?.Dispose();
    }
}

#pragma warning restore SYSLIB5006
#endif

#if KYBERNET

/// <summary>
/// Adapts KyberNET, an independent pure-managed ML-KEM implementation.
/// </summary>
/// <remarks>
/// <para>
/// The reason this one is here: BouncyCastle aside, every other competitor is either the
/// operating system or a wrapper over it, so without KyberNET there is no second
/// <i>managed</i> implementation to measure the managed code against.
/// </para>
/// <para>
/// <b>Reading its Allocated column:</b> KyberNET's API returns objects — an encapsulation
/// result, a ciphertext, a fresh <c>byte[]</c> shared secret — where the others write into
/// caller-owned buffers. Its allocation figures are therefore dominated by API shape rather
/// than by the implementation, and are not comparable with the rest of the table. The
/// timings are.
/// </para>
/// <para>
/// Unavailable on the net48 leg: the package targets netstandard2.1 and net10.0.
/// </para>
/// </remarks>
public sealed class KyberNetKemAdapter : IKemRunner
{
    private readonly KyberNET.Constants.KyberParameter _parameter;
    private KyberNET.Keys.KyberEncapsulationKey? _encapsulationKey;
    private KyberNET.Keys.KyberDecapsulationKey? _decapsulationKey;

    /// <summary>
    /// Initializes a new instance of the <see cref="KyberNetKemAdapter"/> class.
    /// </summary>
    /// <param name="parameter">The KyberNET parameter set.</param>
    /// <param name="ciphertextSizeBytes">The ciphertext size for that parameter set.</param>
    public KyberNetKemAdapter(KyberNET.Constants.KyberParameter parameter, int ciphertextSizeBytes)
    {
        _parameter = parameter;
        CiphertextSizeBytes = ciphertextSizeBytes;
    }

    /// <inheritdoc/>
    public int EncapsulationKeySizeBytes { get; private set; }

    /// <inheritdoc/>
    public int DecapsulationKeySizeBytes { get; private set; }

    /// <inheritdoc/>
    public int CiphertextSizeBytes { get; }

    /// <inheritdoc/>
    public int SharedSecretSizeBytes => 32;

    /// <inheritdoc/>
    public void Prepare(byte[] encapsulationKey, byte[] decapsulationKey)
    {
        EncapsulationKeySizeBytes = encapsulationKey.Length;
        DecapsulationKeySizeBytes = decapsulationKey.Length;

        _encapsulationKey = KyberNET.Keys.KyberEncapsulationKey.FromBytes(encapsulationKey);
        _decapsulationKey = KyberNET.Keys.KyberDecapsulationKey.FromBytes(decapsulationKey);
    }

    /// <inheritdoc/>
    public object GenerateKeyPair()
        => KyberNET.KyberKeyGenerator.Generate(_parameter, SystemRandomProvider.Instance);

    /// <inheritdoc/>
    public void Encapsulate(byte[] ciphertext, byte[] sharedSecret)
    {
        using KyberNET.Keys.KyberEncapsulationResult result =
            _encapsulationKey!.Encapsulate(SystemRandomProvider.Instance);

        result.CipherText.WriteTo(ciphertext);
        result.CopySharedSecretTo(sharedSecret);
    }

    /// <inheritdoc/>
    public void Decapsulate(byte[] ciphertext, byte[] sharedSecret)
    {
        // Both the ciphertext wrapper and the returned secret are allocations the API
        // requires; there is no span-based overload to write into caller buffers.
        KyberNET.Keys.KyberCipherText wrapped = KyberNET.Keys.KyberCipherText.FromBytes(ciphertext);
        byte[] secret = _decapsulationKey!.Decapsulate(wrapped);
        secret.CopyTo(sharedSecret, 0);
    }

    /// <inheritdoc/>
    public void Dispose() => _decapsulationKey?.Dispose();

    /// <summary>
    /// Bridges KyberNET's randomness abstraction onto the platform CSPRNG. KyberNET's own
    /// default provider is internal to that assembly.
    /// </summary>
    private sealed class SystemRandomProvider : KyberNET.IRandomProvider
    {
        public static readonly SystemRandomProvider Instance = new();

        public void FillWithRandom(byte[] buffer)
            => System.Security.Cryptography.RandomNumberGenerator.Fill(buffer);
    }
}

#endif
