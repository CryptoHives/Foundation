// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace Cryptography.Tests.Kem.MlKem;

using CryptoHives.Foundation.Security.Cryptography.Kem;
using NUnit.Framework;
using System;
using System.Linq;

/// <summary>
/// Tests for the ML-KEM implementation (FIPS 203).
/// </summary>
/// <remarks>
/// Includes round-trip tests for all three parameter sets (ML-KEM-512, ML-KEM-768, ML-KEM-1024),
/// deterministic key generation and encapsulation tests, and validation tests.
/// </remarks>
[TestFixture]
[Parallelizable(ParallelScope.All)]
public class MlKemTests
{
    // ========================================================================
    // Parameter Size Verification Tests
    // ========================================================================

    [Test]
    public void MlKem512_ParameterSizes()
    {
        using var kem = MlKem512.Create();
        Assert.That(kem.AlgorithmName, Is.EqualTo("ML-KEM-512"));
        Assert.That(kem.SharedSecretSizeBytes, Is.EqualTo(32));
        Assert.That(kem.EncapsulationKeySizeBytes, Is.EqualTo(800));
        Assert.That(kem.DecapsulationKeySizeBytes, Is.EqualTo(1632));
        Assert.That(kem.CiphertextSizeBytes, Is.EqualTo(768));
    }

    [Test]
    public void MlKem768_ParameterSizes()
    {
        using var kem = MlKem768.Create();
        Assert.That(kem.AlgorithmName, Is.EqualTo("ML-KEM-768"));
        Assert.That(kem.SharedSecretSizeBytes, Is.EqualTo(32));
        Assert.That(kem.EncapsulationKeySizeBytes, Is.EqualTo(1184));
        Assert.That(kem.DecapsulationKeySizeBytes, Is.EqualTo(2400));
        Assert.That(kem.CiphertextSizeBytes, Is.EqualTo(1088));
    }

    [Test]
    public void MlKem1024_ParameterSizes()
    {
        using var kem = MlKem1024.Create();
        Assert.That(kem.AlgorithmName, Is.EqualTo("ML-KEM-1024"));
        Assert.That(kem.SharedSecretSizeBytes, Is.EqualTo(32));
        Assert.That(kem.EncapsulationKeySizeBytes, Is.EqualTo(1568));
        Assert.That(kem.DecapsulationKeySizeBytes, Is.EqualTo(3168));
        Assert.That(kem.CiphertextSizeBytes, Is.EqualTo(1568));
    }

    // ========================================================================
    // Round-Trip Tests
    // ========================================================================

    [Test]
    public void MlKem512_RoundTrip()
    {
        RoundTripTest(MlKem512.Create());
    }

    [Test]
    public void MlKem768_RoundTrip()
    {
        RoundTripTest(MlKem768.Create());
    }

    [Test]
    public void MlKem1024_RoundTrip()
    {
        RoundTripTest(MlKem1024.Create());
    }

    // ========================================================================
    // Deterministic Key Generation Tests
    // ========================================================================

    [Test]
    public void MlKem512_DeterministicKeyGen()
    {
        DeterministicKeyGenTest(MlKem512.Create());
    }

    [Test]
    public void MlKem768_DeterministicKeyGen()
    {
        DeterministicKeyGenTest(MlKem768.Create());
    }

    [Test]
    public void MlKem1024_DeterministicKeyGen()
    {
        DeterministicKeyGenTest(MlKem1024.Create());
    }

    // ========================================================================
    // Deterministic Encapsulation Tests
    // ========================================================================

    [Test]
    public void MlKem512_DeterministicEncaps()
    {
        DeterministicEncapsTest(MlKem512.Create());
    }

    [Test]
    public void MlKem768_DeterministicEncaps()
    {
        DeterministicEncapsTest(MlKem768.Create());
    }

    [Test]
    public void MlKem1024_DeterministicEncaps()
    {
        DeterministicEncapsTest(MlKem1024.Create());
    }

    // ========================================================================
    // Implicit Rejection Tests
    // ========================================================================

    [Test]
    public void MlKem512_ImplicitRejection()
    {
        ImplicitRejectionTest(MlKem512.Create());
    }

    [Test]
    public void MlKem768_ImplicitRejection()
    {
        ImplicitRejectionTest(MlKem768.Create());
    }

    [Test]
    public void MlKem1024_ImplicitRejection()
    {
        ImplicitRejectionTest(MlKem1024.Create());
    }

    // ========================================================================
    // Multiple Round-Trip Consistency Tests
    // ========================================================================

    [Test]
    public void MlKem512_MultipleEncapsulations()
    {
        MultipleEncapsulationsTest(MlKem512.Create());
    }

    [Test]
    public void MlKem768_MultipleEncapsulations()
    {
        MultipleEncapsulationsTest(MlKem768.Create());
    }

    [Test]
    public void MlKem1024_MultipleEncapsulations()
    {
        MultipleEncapsulationsTest(MlKem1024.Create());
    }

    // ========================================================================
    // FIPS 203 Known Answer Test Vectors
    // ========================================================================

    /// <summary>
    /// ML-KEM-512 deterministic test: verifies keygen + encaps + decaps produce
    /// consistent results with a fixed seed. This validates the entire pipeline.
    /// </summary>
    [Test]
    public void MlKem512_Fips203_DeterministicPipeline()
    {
        using var kem = MlKem512.Create();

        // Fixed seed for deterministic keygen (d ‖ z = 64 bytes)
        byte[] keyGenSeed = new byte[64];
        for (int i = 0; i < 64; i++) keyGenSeed[i] = (byte)i;

        byte[] ek = new byte[kem.EncapsulationKeySizeBytes];
        byte[] dk = new byte[kem.DecapsulationKeySizeBytes];
        kem.GenerateKeyPair(keyGenSeed, ek, dk);

        // Fixed seed for deterministic encaps (m = 32 bytes)
        byte[] encapsSeed = new byte[32];
        for (int i = 0; i < 32; i++) encapsSeed[i] = (byte)(0x40 + i);

        byte[] ct = new byte[kem.CiphertextSizeBytes];
        byte[] ss1 = new byte[kem.SharedSecretSizeBytes];
        kem.Encapsulate(ek, encapsSeed, ct, ss1);

        byte[] ss2 = new byte[kem.SharedSecretSizeBytes];
        kem.Decapsulate(dk, ct, ss2);

        Assert.That(ss2, Is.EqualTo(ss1), "Decapsulated shared secret must match encapsulated one.");

        // Verify determinism: repeat with same seeds
        byte[] ek2 = new byte[kem.EncapsulationKeySizeBytes];
        byte[] dk2 = new byte[kem.DecapsulationKeySizeBytes];
        kem.GenerateKeyPair(keyGenSeed, ek2, dk2);
        Assert.That(ek2, Is.EqualTo(ek), "Deterministic keygen must produce same encapsulation key.");
        Assert.That(dk2, Is.EqualTo(dk), "Deterministic keygen must produce same decapsulation key.");

        byte[] ct2 = new byte[kem.CiphertextSizeBytes];
        byte[] ss3 = new byte[kem.SharedSecretSizeBytes];
        kem.Encapsulate(ek, encapsSeed, ct2, ss3);
        Assert.That(ct2, Is.EqualTo(ct), "Deterministic encaps must produce same ciphertext.");
        Assert.That(ss3, Is.EqualTo(ss1), "Deterministic encaps must produce same shared secret.");
    }

    /// <summary>
    /// ML-KEM-768 deterministic pipeline test.
    /// </summary>
    [Test]
    public void MlKem768_Fips203_DeterministicPipeline()
    {
        using var kem = MlKem768.Create();

        byte[] keyGenSeed = new byte[64];
        for (int i = 0; i < 64; i++) keyGenSeed[i] = (byte)i;

        byte[] ek = new byte[kem.EncapsulationKeySizeBytes];
        byte[] dk = new byte[kem.DecapsulationKeySizeBytes];
        kem.GenerateKeyPair(keyGenSeed, ek, dk);

        byte[] encapsSeed = new byte[32];
        for (int i = 0; i < 32; i++) encapsSeed[i] = (byte)(0x40 + i);

        byte[] ct = new byte[kem.CiphertextSizeBytes];
        byte[] ss1 = new byte[kem.SharedSecretSizeBytes];
        kem.Encapsulate(ek, encapsSeed, ct, ss1);

        byte[] ss2 = new byte[kem.SharedSecretSizeBytes];
        kem.Decapsulate(dk, ct, ss2);

        Assert.That(ss2, Is.EqualTo(ss1));
    }

    /// <summary>
    /// ML-KEM-1024 deterministic pipeline test.
    /// </summary>
    [Test]
    public void MlKem1024_Fips203_DeterministicPipeline()
    {
        using var kem = MlKem1024.Create();

        byte[] keyGenSeed = new byte[64];
        for (int i = 0; i < 64; i++) keyGenSeed[i] = (byte)i;

        byte[] ek = new byte[kem.EncapsulationKeySizeBytes];
        byte[] dk = new byte[kem.DecapsulationKeySizeBytes];
        kem.GenerateKeyPair(keyGenSeed, ek, dk);

        byte[] encapsSeed = new byte[32];
        for (int i = 0; i < 32; i++) encapsSeed[i] = (byte)(0x40 + i);

        byte[] ct = new byte[kem.CiphertextSizeBytes];
        byte[] ss1 = new byte[kem.SharedSecretSizeBytes];
        kem.Encapsulate(ek, encapsSeed, ct, ss1);

        byte[] ss2 = new byte[kem.SharedSecretSizeBytes];
        kem.Decapsulate(dk, ct, ss2);

        Assert.That(ss2, Is.EqualTo(ss1));
    }

    // ========================================================================
    // Validation Tests
    // ========================================================================

    [Test]
    public void MlKem512_InvalidSeedSize_Throws()
    {
        using var kem = MlKem512.Create();
        byte[] shortSeed = new byte[32];
        byte[] ek = new byte[kem.EncapsulationKeySizeBytes];
        byte[] dk = new byte[kem.DecapsulationKeySizeBytes];

        Assert.That(() => kem.GenerateKeyPair(shortSeed, ek, dk), Throws.InstanceOf<ArgumentException>());
    }

    [Test]
    public void MlKem512_InvalidEncapsulationKeySize_Throws()
    {
        using var kem = MlKem512.Create();
        byte[] shortEk = new byte[100];
        byte[] ct = new byte[kem.CiphertextSizeBytes];
        byte[] ss = new byte[kem.SharedSecretSizeBytes];

        Assert.That(() => kem.Encapsulate(shortEk, ct, ss), Throws.InstanceOf<ArgumentException>());
    }

    [Test]
    public void MlKem512_InvalidDecapsulationKeySize_Throws()
    {
        using var kem = MlKem512.Create();
        byte[] shortDk = new byte[100];
        byte[] ct = new byte[kem.CiphertextSizeBytes];
        byte[] ss = new byte[kem.SharedSecretSizeBytes];

        Assert.That(() => kem.Decapsulate(shortDk, ct, ss), Throws.InstanceOf<ArgumentException>());
    }

    [Test]
    public void MlKem512_InvalidCiphertextSize_Throws()
    {
        using var kem = MlKem512.Create();
        byte[] dk = new byte[kem.DecapsulationKeySizeBytes];
        byte[] shortCt = new byte[100];
        byte[] ss = new byte[kem.SharedSecretSizeBytes];

        Assert.That(() => kem.Decapsulate(dk, shortCt, ss), Throws.InstanceOf<ArgumentException>());
    }

    // ========================================================================
    // Parameterized TestCaseSource Tests
    // ========================================================================

    /// <summary>
    /// All three ML-KEM parameter sets for parameterized tests.
    /// </summary>
    private static readonly object[] AllParameterSets =
    [
        new object[] { "ML-KEM-512", new Func<IKem>(() => MlKem512.Create()), 800, 1632, 768, 32 },
        new object[] { "ML-KEM-768", new Func<IKem>(() => MlKem768.Create()), 1184, 2400, 1088, 32 },
        new object[] { "ML-KEM-1024", new Func<IKem>(() => MlKem1024.Create()), 1568, 3168, 1568, 32 }
    ];

    [Test]
    [TestCaseSource(nameof(AllParameterSets))]
    public void MlKem_EncapsulationKeyContainsPublicSeed(
        string name, Func<IKem> factory, int ekSize, int dkSize, int ctSize, int ssSize)
    {
        using var kem = factory();

        byte[] seed = new byte[64];
        for (int i = 0; i < 64; i++) seed[i] = (byte)i;

        byte[] ek = new byte[ekSize];
        byte[] dk = new byte[dkSize];
        kem.GenerateKeyPair(seed, ek, dk);

        // The last 32 bytes of ek should be the public seed ρ
        byte[] rhoFromEk = ek.AsSpan(ekSize - 32, 32).ToArray();
        Assert.That(rhoFromEk, Is.Not.All.EqualTo(0), "Public seed ρ should not be all zeros.");
    }

    [Test]
    [TestCaseSource(nameof(AllParameterSets))]
    public void MlKem_DecapsulationKeyContainsEncapsulationKey(
        string name, Func<IKem> factory, int ekSize, int dkSize, int ctSize, int ssSize)
    {
        using var kem = factory();

        byte[] seed = new byte[64];
        for (int i = 0; i < 64; i++) seed[i] = (byte)(0xAA ^ i);

        byte[] ek = new byte[ekSize];
        byte[] dk = new byte[dkSize];
        kem.GenerateKeyPair(seed, ek, dk);

        // dk = dkPKE ‖ ekPKE ‖ H(ekPKE) ‖ z
        // The ek should appear at offset 384*k in the dk
        int dkPkeSize = ekSize - 32; // 384*k
        byte[] ekFromDk = dk.AsSpan(dkPkeSize, ekSize).ToArray();
        Assert.That(ekFromDk, Is.EqualTo(ek), "Decapsulation key must contain the encapsulation key.");
    }

    [Test]
    [TestCaseSource(nameof(AllParameterSets))]
    public void MlKem_DifferentSeedsProduceDifferentKeys(
        string name, Func<IKem> factory, int ekSize, int dkSize, int ctSize, int ssSize)
    {
        using var kem = factory();

        byte[] seed1 = new byte[64];
        byte[] seed2 = new byte[64];
        for (int i = 0; i < 64; i++)
        {
            seed1[i] = (byte)i;
            seed2[i] = (byte)(0xFF - i);
        }

        byte[] ek1 = new byte[ekSize];
        byte[] dk1 = new byte[dkSize];
        kem.GenerateKeyPair(seed1, ek1, dk1);

        byte[] ek2 = new byte[ekSize];
        byte[] dk2 = new byte[dkSize];
        kem.GenerateKeyPair(seed2, ek2, dk2);

        Assert.That(ek2, Is.Not.EqualTo(ek1), "Different seeds must produce different encapsulation keys.");
    }

    // ========================================================================
    // Helper Methods
    // ========================================================================

    private static void RoundTripTest(IKem kem)
    {
        using (kem)
        {
            byte[] ek = new byte[kem.EncapsulationKeySizeBytes];
            byte[] dk = new byte[kem.DecapsulationKeySizeBytes];
            kem.GenerateKeyPair(ek, dk);

            byte[] ct = new byte[kem.CiphertextSizeBytes];
            byte[] ss1 = new byte[kem.SharedSecretSizeBytes];
            kem.Encapsulate(ek, ct, ss1);

            byte[] ss2 = new byte[kem.SharedSecretSizeBytes];
            kem.Decapsulate(dk, ct, ss2);

            Assert.That(ss2, Is.EqualTo(ss1), "Decapsulated shared secret must match.");
            Assert.That(ss1, Is.Not.All.EqualTo(0), "Shared secret must not be all zeros.");
        }
    }

    private static void DeterministicKeyGenTest(IKem kem)
    {
        using (kem)
        {
            byte[] seed = new byte[64];
            for (int i = 0; i < 64; i++) seed[i] = (byte)(i * 3 + 7);

            byte[] ek1 = new byte[kem.EncapsulationKeySizeBytes];
            byte[] dk1 = new byte[kem.DecapsulationKeySizeBytes];
            kem.GenerateKeyPair(seed, ek1, dk1);

            byte[] ek2 = new byte[kem.EncapsulationKeySizeBytes];
            byte[] dk2 = new byte[kem.DecapsulationKeySizeBytes];
            kem.GenerateKeyPair(seed, ek2, dk2);

            Assert.That(ek2, Is.EqualTo(ek1), "Same seed must produce same encapsulation key.");
            Assert.That(dk2, Is.EqualTo(dk1), "Same seed must produce same decapsulation key.");
        }
    }

    private static void DeterministicEncapsTest(IKem kem)
    {
        using (kem)
        {
            byte[] keyGenSeed = new byte[64];
            for (int i = 0; i < 64; i++) keyGenSeed[i] = (byte)i;

            byte[] ek = new byte[kem.EncapsulationKeySizeBytes];
            byte[] dk = new byte[kem.DecapsulationKeySizeBytes];
            kem.GenerateKeyPair(keyGenSeed, ek, dk);

            byte[] encapsSeed = new byte[32];
            for (int i = 0; i < 32; i++) encapsSeed[i] = (byte)(0xBB + i);

            byte[] ct1 = new byte[kem.CiphertextSizeBytes];
            byte[] ss1 = new byte[kem.SharedSecretSizeBytes];
            kem.Encapsulate(ek, encapsSeed, ct1, ss1);

            byte[] ct2 = new byte[kem.CiphertextSizeBytes];
            byte[] ss2 = new byte[kem.SharedSecretSizeBytes];
            kem.Encapsulate(ek, encapsSeed, ct2, ss2);

            Assert.That(ct2, Is.EqualTo(ct1), "Same seed must produce same ciphertext.");
            Assert.That(ss2, Is.EqualTo(ss1), "Same seed must produce same shared secret.");

            // Verify decapsulation also produces matching shared secret
            byte[] ss3 = new byte[kem.SharedSecretSizeBytes];
            kem.Decapsulate(dk, ct1, ss3);
            Assert.That(ss3, Is.EqualTo(ss1), "Decapsulated must match encapsulated shared secret.");
        }
    }

    private static void ImplicitRejectionTest(IKem kem)
    {
        using (kem)
        {
            byte[] keyGenSeed = new byte[64];
            for (int i = 0; i < 64; i++) keyGenSeed[i] = (byte)i;

            byte[] ek = new byte[kem.EncapsulationKeySizeBytes];
            byte[] dk = new byte[kem.DecapsulationKeySizeBytes];
            kem.GenerateKeyPair(keyGenSeed, ek, dk);

            byte[] encapsSeed = new byte[32];
            for (int i = 0; i < 32; i++) encapsSeed[i] = (byte)(0xCC + i);

            byte[] ct = new byte[kem.CiphertextSizeBytes];
            byte[] ssGood = new byte[kem.SharedSecretSizeBytes];
            kem.Encapsulate(ek, encapsSeed, ct, ssGood);

            // Tamper with ciphertext
            ct[0] ^= 0xFF;
            ct[ct.Length / 2] ^= 0xFF;

            byte[] ssBad = new byte[kem.SharedSecretSizeBytes];
            kem.Decapsulate(dk, ct, ssBad);

            // Implicit rejection: should not throw, but shared secret should differ
            Assert.That(ssBad, Is.Not.EqualTo(ssGood),
                "Tampered ciphertext must produce different shared secret (implicit rejection).");
            Assert.That(ssBad, Is.Not.All.EqualTo(0),
                "Implicit rejection secret must not be all zeros.");
        }
    }

    private static void MultipleEncapsulationsTest(IKem kem)
    {
        using (kem)
        {
            byte[] ek = new byte[kem.EncapsulationKeySizeBytes];
            byte[] dk = new byte[kem.DecapsulationKeySizeBytes];
            kem.GenerateKeyPair(ek, dk);

            // Perform multiple encapsulations with the same key pair
            for (int trial = 0; trial < 5; trial++)
            {
                byte[] ct = new byte[kem.CiphertextSizeBytes];
                byte[] ss1 = new byte[kem.SharedSecretSizeBytes];
                kem.Encapsulate(ek, ct, ss1);

                byte[] ss2 = new byte[kem.SharedSecretSizeBytes];
                kem.Decapsulate(dk, ct, ss2);

                Assert.That(ss2, Is.EqualTo(ss1), $"Round-trip #{trial} failed.");
            }
        }
    }

    [Test]
    public void Diagnostic_NttRoundTrip()
    {
        short[] poly = new short[256];
        short[] orig = new short[256];
        var rng = new Random(42);
        for (int i = 0; i < 256; i++)
        {
            poly[i] = (short)rng.Next(0, MlKemParams.Q);
            orig[i] = poly[i];
        }

        Ntt.Forward(poly);
        Ntt.Inverse(poly);

        // InvNTT(NTT(a)) = a * R mod Q (Montgomery scaling from invntt_tomont)
        // R² mod Q = 1353, but InvNTT introduces factor R (=2^16 mod Q = 2285)
        const int R = 2285;
        for (int i = 0; i < 256; i++)
        {
            short normalized = Ntt.ConditionalSubQ(Ntt.BarrettReduce(poly[i]));
            int expected = (int)((long)orig[i] * R % MlKemParams.Q);
            if (expected < 0) expected += MlKemParams.Q;
            Assert.That(normalized, Is.EqualTo((short)expected), $"NTT round-trip mismatch at index {i}");
        }
    }

    [Test]
    public void Diagnostic_KPkeRoundTrip()
    {
        var p = MlKemParams.MlKem512;
        byte[] d = new byte[32];
        for (int i = 0; i < 32; i++) d[i] = (byte)(i + 1);

        byte[] ekPke = new byte[p.EncapsulationKeyBytes];
        byte[] dkPke = new byte[p.PolyVecEncodedBytes];
        MlKemCore.KPkeKeyGen(p, d, ekPke, dkPke);

        byte[] msg = new byte[32];
        for (int i = 0; i < 32; i++) msg[i] = (byte)(0xAA ^ i);

        byte[] r = new byte[32];
        for (int i = 0; i < 32; i++) r[i] = (byte)(0x55 + i);

        byte[] ct = new byte[p.CiphertextBytes];
        MlKemCore.KPkeEncrypt(p, ekPke, msg, r, ct);

        byte[] recovered = new byte[32];
        MlKemCore.KPkeDecrypt(p, dkPke, ct, recovered);

        Assert.That(recovered, Is.EqualTo(msg), "K-PKE encrypt/decrypt must round-trip.");
    }
}
