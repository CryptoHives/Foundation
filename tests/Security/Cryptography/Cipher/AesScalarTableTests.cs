// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace Cryptography.Tests.Cipher;

using CryptoHives.Foundation.Security.Cryptography.Cipher;
using NUnit.Framework;
using System;

/// <summary>
/// Pins the scalar AES path that uses AesCore's SBox/InvSBox/Rcon tables, which the
/// hardware-accelerated paths bypass entirely on x64 and Arm64.
/// </summary>
[TestFixture]
public class AesScalarTableTests
{
    // FIPS-197 Appendix B / C.1 known-answer vector for AES-128.
    private const string KeyHex = "000102030405060708090a0b0c0d0e0f";
    private const string PlainHex = "00112233445566778899aabbccddeeff";
    private const string CipherHex = "69c4e0d86a7b0430d8cdb78070b4c55a";

    [Test]
    public void ScalarAes128_MatchesFips197Vector()
    {
        byte[] key = TestHelpers.FromHexString(KeyHex);
        byte[] plaintext = TestHelpers.FromHexString(PlainHex);
        byte[] expected = TestHelpers.FromHexString(CipherHex);

        uint[] roundKeys = new uint[60];
        int nr = AesCore.ExpandKey(key, roundKeys);

        byte[] actual = new byte[16];
        AesCore.EncryptBlock(plaintext, actual, roundKeys, nr);
        Assert.That(actual, Is.EqualTo(expected), "Scalar AES-128 must match the FIPS-197 vector.");

        // Decryption uses the equivalent inverse cipher, which needs its own schedule.
        uint[] decRoundKeys = new uint[60];
        AesCore.CreateDecryptionKeys(roundKeys, decRoundKeys, nr);

        byte[] roundTrip = new byte[16];
        AesCore.DecryptBlock(actual, roundTrip, decRoundKeys, nr);
        Assert.That(roundTrip, Is.EqualTo(plaintext), "Scalar AES-128 must round-trip.");
    }
}
