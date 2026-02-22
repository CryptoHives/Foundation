// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace Cryptography.Tests.Cipher.Aes;

using CryptoHives.Foundation.Security.Cryptography;
using CryptoHives.Foundation.Security.Cryptography.Cipher;
using NUnit.Framework;
using System;

/// <summary>
/// Tests for AES ECB, CBC and CTR modes using NIST SP 800-38A Appendix F test vectors.
/// </summary>
/// <remarks>
/// All test vectors are from NIST Special Publication 800-38A,
/// "Recommendation for Block Cipher Modes of Operation: Methods and Techniques",
/// Appendix F: Example Vectors for Modes of Operation of the AES.
/// See: https://csrc.nist.gov/publications/detail/sp/800-38a/final
/// </remarks>
[TestFixture]
[Parallelizable(ParallelScope.All)]
internal class AesNistSp80038aTests
{
    // ========================================================================
    // NIST SP 800-38A Common Test Data
    // ========================================================================

    // All modes share the same four 16-byte plaintext blocks.
    private const string Plaintext =
        "6bc1bee22e409f96e93d7e117393172a" +
        "ae2d8a571e03ac9c9eb76fac45af8e51" +
        "30c81c46a35ce411e5fbc1191a0a52ef" +
        "f69f2445df4f9b17ad2b417be66c3710";

    private const string Key128 = "2b7e151628aed2a6abf7158809cf4f3c";
    private const string Key192 = "8e73b0f7da0e6452c810f32b809079e562f8ead2522c6b7b";
    private const string Key256 = "603deb1015ca71be2b73aef0857d77811f352c073b6108d72d9810a30914dff4";

    private const string CbcIv = "000102030405060708090a0b0c0d0e0f";
    private const string CtrIv = "f0f1f2f3f4f5f6f7f8f9fafbfcfdfeff";

    // ========================================================================
    // F.1 ECB-AES Test Vectors
    // ========================================================================

    // F.1.1 ECB-AES128.Encrypt
    private const string Ecb128Ciphertext =
        "3ad77bb40d7a3660a89ecaf32466ef97" +
        "f5d3d58503b9699de785895a96fdbaaf" +
        "43b1cd7f598ece23881b00e3ed030688" +
        "7b0c785e27e8ad3f8223207104725dd4";

    // F.1.3 ECB-AES192.Encrypt
    private const string Ecb192Ciphertext =
        "bd334f1d6e45f25ff712a214571fa5cc" +
        "974104846d0ad3ad7734ecb3ecee4eef" +
        "ef7afd2270e2e60adce0ba2face6444e" +
        "9a4b41ba738d6c72fb16691603c18e0e";

    // F.1.5 ECB-AES256.Encrypt
    private const string Ecb256Ciphertext =
        "f3eed1bdb5d2a03c064b5a7e3db181f8" +
        "591ccb10d410ed26dc5ba74a31362870" +
        "b6ed21b99ca6f4f9f153e7b1beafed1d" +
        "23304b7a39f9f3ff067d8d8f9e24ecc7";

    // ========================================================================
    // F.2 CBC-AES Test Vectors
    // ========================================================================

    // F.2.1 CBC-AES128.Encrypt
    private const string Cbc128Ciphertext =
        "7649abac8119b246cee98e9b12e9197d" +
        "5086cb9b507219ee95db113a917678b2" +
        "73bed6b8e3c1743b7116e69e22229516" +
        "3ff1caa1681fac09120eca307586e1a7";

    // F.2.3 CBC-AES192.Encrypt
    private const string Cbc192Ciphertext =
        "4f021db243bc633d7178183a9fa071e8" +
        "b4d9ada9ad7dedf4e5e738763f69145a" +
        "571b242012fb7ae07fa9baac3df102e0" +
        "08b0e27988598881d920a9e64f5615cd";

    // F.2.5 CBC-AES256.Encrypt
    private const string Cbc256Ciphertext =
        "f58c4c04d6e5f1ba779eabfb5f7bfbd6" +
        "9cfc4e967edb808d679f777bc6702c7d" +
        "39f23369a9d9bacfa530e26304231461" +
        "b2eb05e2c39be9fcda6c19078c6a9d1b";

    // ========================================================================
    // F.5 CTR-AES Test Vectors
    // ========================================================================

    // F.5.1 CTR-AES128.Encrypt
    private const string Ctr128Ciphertext =
        "874d6191b620e3261bef6864990db6ce" +
        "9806f66b7970fdff8617187bb9fffdff" +
        "5ae4df3edbd5d35e5b4f09020db03eab" +
        "1e031dda2fbe03d1792170a0f3009cee";

    // F.5.3 CTR-AES192.Encrypt
    private const string Ctr192Ciphertext =
        "1abc932417521ca24f2b0459fe7e6e0b" +
        "090339ec0aa6faefd5ccc2c6f4ce8e94" +
        "1e36b26bd1ebc670d1bd1d665620abf7" +
        "4f78a7f6d29809585a97daec58c6b050";

    // F.5.5 CTR-AES256.Encrypt
    private const string Ctr256Ciphertext =
        "601ec313775789a5b7a7f504bbf3d228" +
        "f443e3ca4d62b59aca84e990cacaf5c5" +
        "2b0930daa23de94ce87017ba2d84988d" +
        "dfc9c58db67aada613c2dd08457941a6";

    // ========================================================================
    // SIMD variant sources
    // ========================================================================

    private static readonly SimdSupport[] SimdVariants = [SimdSupport.None, SimdSupport.AesNi];

    // ========================================================================
    // F.1 ECB Mode Tests
    // ========================================================================

    /// <summary>
    /// NIST SP 800-38A F.1.1: ECB-AES128 encrypt.
    /// </summary>
    [Test]
    [TestCaseSource(nameof(SimdVariants))]
    public void EcbAes128Encrypt(SimdSupport simd)
    {
        using var aes = Aes128.Create(simd);
        aes.Mode = CipherMode.ECB;
        aes.Padding = PaddingMode.None;
        aes.Key = FromHex(Key128);
        aes.IV = new byte[16];

        Assert.That(aes.Encrypt(FromHex(Plaintext)), Is.EqualTo(FromHex(Ecb128Ciphertext)));
    }

    /// <summary>
    /// NIST SP 800-38A F.1.2: ECB-AES128 decrypt.
    /// </summary>
    [Test]
    [TestCaseSource(nameof(SimdVariants))]
    public void EcbAes128Decrypt(SimdSupport simd)
    {
        using var aes = Aes128.Create(simd);
        aes.Mode = CipherMode.ECB;
        aes.Padding = PaddingMode.None;
        aes.Key = FromHex(Key128);
        aes.IV = new byte[16];

        Assert.That(aes.Decrypt(FromHex(Ecb128Ciphertext)), Is.EqualTo(FromHex(Plaintext)));
    }

    /// <summary>
    /// NIST SP 800-38A F.1.3: ECB-AES192 encrypt.
    /// </summary>
    [Test]
    [TestCaseSource(nameof(SimdVariants))]
    public void EcbAes192Encrypt(SimdSupport simd)
    {
        using var aes = Aes192.Create(simd);
        aes.Mode = CipherMode.ECB;
        aes.Padding = PaddingMode.None;
        aes.Key = FromHex(Key192);
        aes.IV = new byte[16];

        Assert.That(aes.Encrypt(FromHex(Plaintext)), Is.EqualTo(FromHex(Ecb192Ciphertext)));
    }

    /// <summary>
    /// NIST SP 800-38A F.1.4: ECB-AES192 decrypt.
    /// </summary>
    [Test]
    [TestCaseSource(nameof(SimdVariants))]
    public void EcbAes192Decrypt(SimdSupport simd)
    {
        using var aes = Aes192.Create(simd);
        aes.Mode = CipherMode.ECB;
        aes.Padding = PaddingMode.None;
        aes.Key = FromHex(Key192);
        aes.IV = new byte[16];

        Assert.That(aes.Decrypt(FromHex(Ecb192Ciphertext)), Is.EqualTo(FromHex(Plaintext)));
    }

    /// <summary>
    /// NIST SP 800-38A F.1.5: ECB-AES256 encrypt.
    /// </summary>
    [Test]
    [TestCaseSource(nameof(SimdVariants))]
    public void EcbAes256Encrypt(SimdSupport simd)
    {
        using var aes = Aes256.Create(simd);
        aes.Mode = CipherMode.ECB;
        aes.Padding = PaddingMode.None;
        aes.Key = FromHex(Key256);
        aes.IV = new byte[16];

        Assert.That(aes.Encrypt(FromHex(Plaintext)), Is.EqualTo(FromHex(Ecb256Ciphertext)));
    }

    /// <summary>
    /// NIST SP 800-38A F.1.6: ECB-AES256 decrypt.
    /// </summary>
    [Test]
    [TestCaseSource(nameof(SimdVariants))]
    public void EcbAes256Decrypt(SimdSupport simd)
    {
        using var aes = Aes256.Create(simd);
        aes.Mode = CipherMode.ECB;
        aes.Padding = PaddingMode.None;
        aes.Key = FromHex(Key256);
        aes.IV = new byte[16];

        Assert.That(aes.Decrypt(FromHex(Ecb256Ciphertext)), Is.EqualTo(FromHex(Plaintext)));
    }

    // ========================================================================
    // F.2 CBC Mode Tests
    // ========================================================================

    /// <summary>
    /// NIST SP 800-38A F.2.1: CBC-AES128 encrypt.
    /// </summary>
    [Test]
    [TestCaseSource(nameof(SimdVariants))]
    public void CbcAes128Encrypt(SimdSupport simd)
    {
        using var aes = Aes128.Create(simd);
        aes.Mode = CipherMode.CBC;
        aes.Padding = PaddingMode.None;
        aes.Key = FromHex(Key128);
        aes.IV = FromHex(CbcIv);

        Assert.That(aes.Encrypt(FromHex(Plaintext)), Is.EqualTo(FromHex(Cbc128Ciphertext)));
    }

    /// <summary>
    /// NIST SP 800-38A F.2.2: CBC-AES128 decrypt.
    /// </summary>
    [Test]
    [TestCaseSource(nameof(SimdVariants))]
    public void CbcAes128Decrypt(SimdSupport simd)
    {
        using var aes = Aes128.Create(simd);
        aes.Mode = CipherMode.CBC;
        aes.Padding = PaddingMode.None;
        aes.Key = FromHex(Key128);
        aes.IV = FromHex(CbcIv);

        Assert.That(aes.Decrypt(FromHex(Cbc128Ciphertext)), Is.EqualTo(FromHex(Plaintext)));
    }

    /// <summary>
    /// NIST SP 800-38A F.2.3: CBC-AES192 encrypt.
    /// </summary>
    [Test]
    [TestCaseSource(nameof(SimdVariants))]
    public void CbcAes192Encrypt(SimdSupport simd)
    {
        using var aes = Aes192.Create(simd);
        aes.Mode = CipherMode.CBC;
        aes.Padding = PaddingMode.None;
        aes.Key = FromHex(Key192);
        aes.IV = FromHex(CbcIv);

        Assert.That(aes.Encrypt(FromHex(Plaintext)), Is.EqualTo(FromHex(Cbc192Ciphertext)));
    }

    /// <summary>
    /// NIST SP 800-38A F.2.4: CBC-AES192 decrypt.
    /// </summary>
    [Test]
    [TestCaseSource(nameof(SimdVariants))]
    public void CbcAes192Decrypt(SimdSupport simd)
    {
        using var aes = Aes192.Create(simd);
        aes.Mode = CipherMode.CBC;
        aes.Padding = PaddingMode.None;
        aes.Key = FromHex(Key192);
        aes.IV = FromHex(CbcIv);

        Assert.That(aes.Decrypt(FromHex(Cbc192Ciphertext)), Is.EqualTo(FromHex(Plaintext)));
    }

    /// <summary>
    /// NIST SP 800-38A F.2.5: CBC-AES256 encrypt.
    /// </summary>
    [Test]
    [TestCaseSource(nameof(SimdVariants))]
    public void CbcAes256Encrypt(SimdSupport simd)
    {
        using var aes = Aes256.Create(simd);
        aes.Mode = CipherMode.CBC;
        aes.Padding = PaddingMode.None;
        aes.Key = FromHex(Key256);
        aes.IV = FromHex(CbcIv);

        Assert.That(aes.Encrypt(FromHex(Plaintext)), Is.EqualTo(FromHex(Cbc256Ciphertext)));
    }

    /// <summary>
    /// NIST SP 800-38A F.2.6: CBC-AES256 decrypt.
    /// </summary>
    [Test]
    [TestCaseSource(nameof(SimdVariants))]
    public void CbcAes256Decrypt(SimdSupport simd)
    {
        using var aes = Aes256.Create(simd);
        aes.Mode = CipherMode.CBC;
        aes.Padding = PaddingMode.None;
        aes.Key = FromHex(Key256);
        aes.IV = FromHex(CbcIv);

        Assert.That(aes.Decrypt(FromHex(Cbc256Ciphertext)), Is.EqualTo(FromHex(Plaintext)));
    }

    // ========================================================================
    // F.5 CTR Mode Tests
    // ========================================================================

    /// <summary>
    /// NIST SP 800-38A F.5.1: CTR-AES128 encrypt.
    /// </summary>
    [Test]
    [TestCaseSource(nameof(SimdVariants))]
    public void CtrAes128Encrypt(SimdSupport simd)
    {
        using var aes = Aes128.Create(simd);
        aes.Mode = CipherMode.CTR;
        aes.Padding = PaddingMode.None;
        aes.Key = FromHex(Key128);
        aes.IV = FromHex(CtrIv);

        Assert.That(aes.Encrypt(FromHex(Plaintext)), Is.EqualTo(FromHex(Ctr128Ciphertext)));
    }

    /// <summary>
    /// NIST SP 800-38A F.5.2: CTR-AES128 decrypt.
    /// </summary>
    [Test]
    [TestCaseSource(nameof(SimdVariants))]
    public void CtrAes128Decrypt(SimdSupport simd)
    {
        using var aes = Aes128.Create(simd);
        aes.Mode = CipherMode.CTR;
        aes.Padding = PaddingMode.None;
        aes.Key = FromHex(Key128);
        aes.IV = FromHex(CtrIv);

        Assert.That(aes.Decrypt(FromHex(Ctr128Ciphertext)), Is.EqualTo(FromHex(Plaintext)));
    }

    /// <summary>
    /// NIST SP 800-38A F.5.3: CTR-AES192 encrypt.
    /// </summary>
    [Test]
    [TestCaseSource(nameof(SimdVariants))]
    public void CtrAes192Encrypt(SimdSupport simd)
    {
        using var aes = Aes192.Create(simd);
        aes.Mode = CipherMode.CTR;
        aes.Padding = PaddingMode.None;
        aes.Key = FromHex(Key192);
        aes.IV = FromHex(CtrIv);

        Assert.That(aes.Encrypt(FromHex(Plaintext)), Is.EqualTo(FromHex(Ctr192Ciphertext)));
    }

    /// <summary>
    /// NIST SP 800-38A F.5.4: CTR-AES192 decrypt.
    /// </summary>
    [Test]
    [TestCaseSource(nameof(SimdVariants))]
    public void CtrAes192Decrypt(SimdSupport simd)
    {
        using var aes = Aes192.Create(simd);
        aes.Mode = CipherMode.CTR;
        aes.Padding = PaddingMode.None;
        aes.Key = FromHex(Key192);
        aes.IV = FromHex(CtrIv);

        Assert.That(aes.Decrypt(FromHex(Ctr192Ciphertext)), Is.EqualTo(FromHex(Plaintext)));
    }

    /// <summary>
    /// NIST SP 800-38A F.5.5: CTR-AES256 encrypt.
    /// </summary>
    [Test]
    [TestCaseSource(nameof(SimdVariants))]
    public void CtrAes256Encrypt(SimdSupport simd)
    {
        using var aes = Aes256.Create(simd);
        aes.Mode = CipherMode.CTR;
        aes.Padding = PaddingMode.None;
        aes.Key = FromHex(Key256);
        aes.IV = FromHex(CtrIv);

        Assert.That(aes.Encrypt(FromHex(Plaintext)), Is.EqualTo(FromHex(Ctr256Ciphertext)));
    }

    /// <summary>
    /// NIST SP 800-38A F.5.6: CTR-AES256 decrypt.
    /// </summary>
    [Test]
    [TestCaseSource(nameof(SimdVariants))]
    public void CtrAes256Decrypt(SimdSupport simd)
    {
        using var aes = Aes256.Create(simd);
        aes.Mode = CipherMode.CTR;
        aes.Padding = PaddingMode.None;
        aes.Key = FromHex(Key256);
        aes.IV = FromHex(CtrIv);

        Assert.That(aes.Decrypt(FromHex(Ctr256Ciphertext)), Is.EqualTo(FromHex(Plaintext)));
    }

    // ========================================================================
    // ECB Single-Block Incremental Tests
    // ========================================================================

    /// <summary>
    /// Verifies each ECB ciphertext block individually to pinpoint failures.
    /// </summary>
    [Test]
    [TestCase(0, Description = "Block 1")]
    [TestCase(1, Description = "Block 2")]
    [TestCase(2, Description = "Block 3")]
    [TestCase(3, Description = "Block 4")]
    public void EcbAes128EncryptPerBlock(int blockIndex)
    {
        byte[] pt = FromHex(Plaintext);
        byte[] expected = FromHex(Ecb128Ciphertext);

        using var aes = Aes128.Create();
        aes.Mode = CipherMode.ECB;
        aes.Padding = PaddingMode.None;
        aes.Key = FromHex(Key128);
        aes.IV = new byte[16];

        byte[] singleBlock = new byte[16];
        Buffer.BlockCopy(pt, blockIndex * 16, singleBlock, 0, 16);
        byte[] ct = aes.Encrypt(singleBlock);

        byte[] expectedBlock = new byte[16];
        Buffer.BlockCopy(expected, blockIndex * 16, expectedBlock, 0, 16);

        Assert.That(ct, Is.EqualTo(expectedBlock),
            $"ECB-AES128 block {blockIndex + 1} mismatch");
    }

    // ========================================================================
    // CBC Chaining Verification
    // ========================================================================

    /// <summary>
    /// Verifies CBC produces different ciphertext blocks even for identical
    /// plaintext blocks, confirming proper IV chaining.
    /// </summary>
    [Test]
    [TestCaseSource(nameof(SimdVariants))]
    public void CbcChainingProducesDifferentBlocks(SimdSupport simd)
    {
        byte[] pt = new byte[32];

        using var aes = Aes128.Create(simd);
        aes.Mode = CipherMode.CBC;
        aes.Padding = PaddingMode.None;
        aes.Key = FromHex(Key128);
        aes.IV = FromHex(CbcIv);

        byte[] ct = aes.Encrypt(pt);

        byte[] block1 = new byte[16];
        byte[] block2 = new byte[16];
        Buffer.BlockCopy(ct, 0, block1, 0, 16);
        Buffer.BlockCopy(ct, 16, block2, 0, 16);
        Assert.That(block1, Is.Not.EqualTo(block2),
            "CBC should produce different ciphertext for identical plaintext blocks");
    }

    // ========================================================================
    // CTR Partial Block Tests
    // ========================================================================

    /// <summary>
    /// Verifies CTR mode correctly handles partial (non-block-aligned) plaintext.
    /// </summary>
    [Test]
    [TestCaseSource(nameof(SimdVariants))]
    public void CtrPartialBlockRoundTrip(SimdSupport simd)
    {
        byte[] fullPt = FromHex(Plaintext);
        byte[] pt = new byte[25];
        Buffer.BlockCopy(fullPt, 0, pt, 0, 25);

        using var aes = Aes128.Create(simd);
        aes.Mode = CipherMode.CTR;
        aes.Padding = PaddingMode.None;
        aes.Key = FromHex(Key128);
        aes.IV = FromHex(CtrIv);

        byte[] ct = aes.Encrypt(pt);
        Assert.That(ct, Has.Length.EqualTo(25));

        // First 25 bytes should match the reference ciphertext
        byte[] expectedCt = new byte[25];
        Buffer.BlockCopy(FromHex(Ctr128Ciphertext), 0, expectedCt, 0, 25);
        Assert.That(ct, Is.EqualTo(expectedCt));

        aes.IV = FromHex(CtrIv);
        byte[] decrypted = aes.Decrypt(ct);
        Assert.That(decrypted, Is.EqualTo(pt));
    }

    // ========================================================================
    // Padding Mode Tests (CBC)
    // ========================================================================

    private static System.Collections.IEnumerable Pkcs7TestCases()
    {
        foreach (int length in new[] { 1, 7, 15, 16, 31, 48 })
            foreach (SimdSupport simd in SimdVariants)
                yield return new TestCaseData(length, simd)
                    .SetDescription($"{length} bytes, {simd}");
    }

    /// <summary>
    /// Verifies PKCS7 padding round-trip for various plaintext lengths.
    /// </summary>
    [Test]
    [TestCaseSource(nameof(Pkcs7TestCases))]
    public void CbcPkcs7RoundTrip(int length, SimdSupport simd)
    {
        byte[] pt = new byte[length];
        for (int i = 0; i < length; i++) pt[i] = (byte)(i & 0xFF);
        byte[] iv = FromHex(CbcIv);

        using var aes = Aes256.Create(simd);
        aes.Mode = CipherMode.CBC;
        aes.Padding = PaddingMode.PKCS7;
        aes.Key = FromHex(Key256);
        aes.IV = iv;

        byte[] ct = aes.Encrypt(pt);

        // PKCS7 always adds padding, so output is next block boundary
        int expectedLen = ((length / 16) + 1) * 16;
        Assert.That(ct, Has.Length.EqualTo(expectedLen));

        aes.IV = iv;
        byte[] decrypted = aes.Decrypt(ct);
        Assert.That(decrypted, Is.EqualTo(pt));
    }

    /// <summary>
    /// Verifies Zeros padding round-trip for non-block-aligned plaintext.
    /// </summary>
    [Test]
    [TestCaseSource(nameof(SimdVariants))]
    public void CbcZerosPaddingRoundTrip(SimdSupport simd)
    {
        byte[] pt = new byte[20]; // 1 block + 4 bytes
        for (int i = 0; i < pt.Length; i++) pt[i] = (byte)(i + 1);
        byte[] iv = FromHex(CbcIv);

        using var aes = Aes128.Create(simd);
        aes.Mode = CipherMode.CBC;
        aes.Padding = PaddingMode.Zeros;
        aes.Key = FromHex(Key128);
        aes.IV = iv;

        byte[] ct = aes.Encrypt(pt);
        Assert.That(ct, Has.Length.EqualTo(32)); // padded to 2 blocks

        aes.IV = iv;
        byte[] decrypted = aes.Decrypt(ct);

        // Zeros padding: decrypted includes trailing zeros
        byte[] first20 = new byte[20];
        Buffer.BlockCopy(decrypted, 0, first20, 0, 20);
        Assert.That(first20, Is.EqualTo(pt));
    }

    /// <summary>
    /// Verifies ANSI X9.23 padding round-trip.
    /// </summary>
    [Test]
    [TestCaseSource(nameof(SimdVariants))]
    public void CbcAnsiX923PaddingRoundTrip(SimdSupport simd)
    {
        byte[] pt = new byte[10];
        for (int i = 0; i < pt.Length; i++) pt[i] = (byte)(0xA0 + i);
        byte[] iv = FromHex(CbcIv);

        using var aes = Aes256.Create(simd);
        aes.Mode = CipherMode.CBC;
        aes.Padding = PaddingMode.ANSIX923;
        aes.Key = FromHex(Key256);
        aes.IV = iv;

        byte[] ct = aes.Encrypt(pt);
        Assert.That(ct, Has.Length.EqualTo(16));

        aes.IV = iv;
        byte[] decrypted = aes.Decrypt(ct);
        Assert.That(decrypted, Is.EqualTo(pt));
    }

    /// <summary>
    /// Verifies ISO 10126 padding round-trip.
    /// </summary>
    [Test]
    [TestCaseSource(nameof(SimdVariants))]
    public void CbcIso10126PaddingRoundTrip(SimdSupport simd)
    {
        byte[] pt = new byte[13];
        for (int i = 0; i < pt.Length; i++) pt[i] = (byte)(0xB0 + i);
        byte[] iv = FromHex(CbcIv);

        using var aes = Aes128.Create(simd);
        aes.Mode = CipherMode.CBC;
        aes.Padding = PaddingMode.ISO10126;
        aes.Key = FromHex(Key128);
        aes.IV = iv;

        byte[] ct = aes.Encrypt(pt);
        Assert.That(ct, Has.Length.EqualTo(16));

        aes.IV = iv;
        byte[] decrypted = aes.Decrypt(ct);
        Assert.That(decrypted, Is.EqualTo(pt));
    }

    // ========================================================================
    // Managed vs AES-NI Cross-Validation
    // ========================================================================

    private static System.Collections.IEnumerable CrossValidationTestCases()
    {
        foreach (CipherMode mode in new[] { CipherMode.ECB, CipherMode.CBC, CipherMode.CTR })
            foreach (int keyLen in new[] { 16, 24, 32 })
                yield return new TestCaseData(mode, keyLen)
                    .SetDescription($"{mode} AES-{keyLen * 8}");
    }

    /// <summary>
    /// Verifies Managed and AES-NI produce identical ciphertext for all modes.
    /// </summary>
    [Test]
    [TestCaseSource(nameof(CrossValidationTestCases))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Reliability", "CA2000:Dispose objects before losing scope", Justification = "Factory method; disposed in finally block")]
    public void ManagedMatchesAesNi(CipherMode mode, int keyLen)
    {
        byte[] key = new byte[keyLen];
        byte[] iv = new byte[16];
        for (int i = 0; i < keyLen; i++) key[i] = (byte)((i * 3 + 7) & 0xFF);
        for (int i = 0; i < 16; i++) iv[i] = (byte)((i * 5 + 11) & 0xFF);

        int[] sizes = mode == CipherMode.CTR
            ? [1, 7, 15, 16, 17, 31, 32, 33, 63, 64, 65, 128, 255, 256, 1024]
            : [16, 32, 48, 64, 128, 256, 1024];

        foreach (int size in sizes)
        {
            byte[] pt = new byte[size];
            for (int i = 0; i < size; i++) pt[i] = unchecked((byte)(i ^ 0x5A));

            SymmetricCipher? managed = null;
            SymmetricCipher? aesni = null;
            try
            {
                managed = CreateAes(keyLen, SimdSupport.None);
                managed.Mode = mode;
                managed.Padding = PaddingMode.None;
                managed.Key = key;
                managed.IV = iv;

                aesni = CreateAes(keyLen, SimdSupport.AesNi);
                aesni.Mode = mode;
                aesni.Padding = PaddingMode.None;
                aesni.Key = key;
                aesni.IV = iv;

                byte[] ctManaged = managed.Encrypt(pt);
                byte[] ctAesNi = aesni.Encrypt(pt);

                Assert.That(ctAesNi, Is.EqualTo(ctManaged),
                    $"{mode} AES-{keyLen * 8} size={size}: AES-NI ciphertext differs from Managed");

                managed.IV = iv;
                aesni.IV = iv;

                byte[] ptManaged = managed.Decrypt(ctManaged);
                byte[] ptAesNi = aesni.Decrypt(ctAesNi);

                Assert.That(ptManaged, Is.EqualTo(pt),
                    $"{mode} AES-{keyLen * 8} size={size}: Managed decrypt mismatch");
                Assert.That(ptAesNi, Is.EqualTo(pt),
                    $"{mode} AES-{keyLen * 8} size={size}: AES-NI decrypt mismatch");
            }
            finally
            {
                managed?.Dispose();
                aesni?.Dispose();
            }
        }
    }

    // ========================================================================
    // Helper Methods
    // ========================================================================

    private static SymmetricCipher CreateAes(int keyLength, SimdSupport simd)
    {
        return keyLength switch {
            16 => Aes128.Create(simd),
            24 => Aes192.Create(simd),
            32 => Aes256.Create(simd),
            _ => throw new ArgumentException($"Invalid key length: {keyLength}")
        };
    }

    private static byte[] FromHex(string hex)
    {
        byte[] bytes = new byte[hex.Length / 2];
        for (int i = 0; i < bytes.Length; i++)
        {
            bytes[i] = Convert.ToByte(hex.Substring(i * 2, 2), 16);
        }
        return bytes;
    }
}
