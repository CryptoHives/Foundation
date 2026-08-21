// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

#pragma warning disable CA1050 // Declare types in namespaces

using CryptoHives.Foundation.Security.Cryptography.Kem;
using Org.BouncyCastle.Crypto.Generators;
using Org.BouncyCastle.Crypto.Kems;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Security;
using System;

/// <summary>
/// Uniform surface over the four ML-KEM implementations under comparison, so the
/// benchmark methods contain the operation itself and nothing else.
/// </summary>
/// <remarks>
/// <para>
/// The four implementations have genuinely different shapes — key-holding versus stateless,
/// span-based versus <c>byte[]</c>-with-offsets — so a fair comparison needs a common
/// surface. Two rules keep it honest:
/// </para>
/// <list type="bullet">
///   <item><description>
///     All buffers are <c>byte[]</c>. BouncyCastle's encapsulator only accepts
///     <c>byte[]</c> with offsets, so exposing spans here would force a per-call copy on
///     one competitor and distort the result.
///   </description></item>
///   <item><description>
///     Everything that an implementation can legitimately hoist out of the operation —
///     importing a key, constructing an encapsulator — happens in <see cref="Prepare"/>,
///     which runs once during setup. Work that an implementation genuinely repeats per
///     call stays inside the measured method. That is deliberate: the stateless
///     <see cref="IKem"/> path re-validates the decapsulation key on every
///     <c>Decapsulate</c>, and the benchmark is meant to show that.
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
    /// benchmarks operate on. Called once from setup.
    /// </summary>
    /// <remarks>
    /// Every implementation is handed the same bytes, produced deterministically from a
    /// fixed seed, so no implementation gets an easier key than another.
    /// </remarks>
    void Prepare(byte[] encapsulationKey, byte[] decapsulationKey);

    /// <summary>
    /// Produces a fresh key pair using the implementation's own natural API and returns the
    /// result so the work cannot be optimized away.
    /// </summary>
    /// <remarks>
    /// The allocation profiles differ by design and the memory diagnoser should show that:
    /// the stateless <see cref="IKem"/> path writes into caller-owned buffers, while the
    /// key-holding APIs allocate a key object per call.
    /// </remarks>
    object GenerateKeyPair();

    /// <summary>Encapsulates into caller-owned buffers.</summary>
    void Encapsulate(byte[] ciphertext, byte[] sharedSecret);

    /// <summary>Decapsulates into a caller-owned buffer.</summary>
    void Decapsulate(byte[] ciphertext, byte[] sharedSecret);
}

/// <summary>
/// The key-holding <see cref="MLKem"/> API — the recommended entry point, and the one
/// that mirrors <c>System.Security.Cryptography.MLKem</c>.
/// </summary>
public sealed class MLKemKeyHoldingRunner : IKemRunner
{
    private readonly MLKemAlgorithm _algorithm;
    private MLKem? _encapsulator;
    private MLKem? _decapsulator;

    /// <summary>
    /// Initializes a new instance of the <see cref="MLKemKeyHoldingRunner"/> class.
    /// </summary>
    /// <param name="algorithm">The parameter set to benchmark.</param>
    public MLKemKeyHoldingRunner(MLKemAlgorithm algorithm) => _algorithm = algorithm;

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
        _encapsulator = MLKem.ImportEncapsulationKey(_algorithm, encapsulationKey);
        _decapsulator = MLKem.ImportDecapsulationKey(_algorithm, decapsulationKey);
    }

    /// <inheritdoc/>
    public object GenerateKeyPair() => MLKem.GenerateKey(_algorithm);

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
/// The stateless <see cref="IKem"/> API, where the caller owns the raw key bytes.
/// </summary>
public sealed class MLKemStatelessRunner : IKemRunner
{
    private readonly IKem _kem;
    private byte[] _encapsulationKey = [];
    private byte[] _decapsulationKey = [];
    private readonly byte[] _keyGenEk;
    private readonly byte[] _keyGenDk;

    /// <summary>
    /// Initializes a new instance of the <see cref="MLKemStatelessRunner"/> class.
    /// </summary>
    /// <param name="kem">The stateless KEM instance to benchmark.</param>
    public MLKemStatelessRunner(IKem kem)
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
    /// <remarks>
    /// Writes into buffers owned by this instance, so unlike the key-holding APIs it
    /// allocates nothing per call.
    /// </remarks>
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
    /// This re-runs the FIPS 203 §7.3 hash check on every call, by design of the stateless
    /// API — there is no imported key to attach the check to.
    /// </remarks>
    public void Decapsulate(byte[] ciphertext, byte[] sharedSecret)
        => _kem.Decapsulate(_decapsulationKey, ciphertext, sharedSecret);

    /// <inheritdoc/>
    public void Dispose() => _kem.Dispose();
}

/// <summary>
/// BouncyCastle's ML-KEM, available on every target framework.
/// </summary>
public sealed class BouncyCastleKemRunner : IKemRunner
{
    private readonly MLKemParameters _parameters;
    private readonly SecureRandom _random = new();
    private readonly MLKemKeyPairGenerator _generator = new();
    private MLKemEncapsulator? _encapsulator;
    private MLKemDecapsulator? _decapsulator;

    /// <summary>
    /// Initializes a new instance of the <see cref="BouncyCastleKemRunner"/> class.
    /// </summary>
    /// <param name="parameters">The BouncyCastle parameter set to benchmark.</param>
    public BouncyCastleKemRunner(MLKemParameters parameters)
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
/// The in-box <c>System.Security.Cryptography.MLKem</c>, backed by the OS provider.
/// </summary>
/// <remarks>
/// Only constructed when <c>MLKem.IsSupported</c> is true, which on Windows means a recent
/// CNG build and on Linux means OpenSSL 3.5+. This is the reference point the managed
/// implementation is measured against.
/// </remarks>
public sealed class DotnetKemRunner : IKemRunner
{
    private readonly System.Security.Cryptography.MLKemAlgorithm _algorithm;
    private System.Security.Cryptography.MLKem? _encapsulator;
    private System.Security.Cryptography.MLKem? _decapsulator;

    /// <summary>
    /// Initializes a new instance of the <see cref="DotnetKemRunner"/> class.
    /// </summary>
    /// <param name="algorithm">The in-box parameter set to benchmark.</param>
    public DotnetKemRunner(System.Security.Cryptography.MLKemAlgorithm algorithm) => _algorithm = algorithm;

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
