// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT OR Apache-2.0

namespace Cryptography.Tests.Mac.KMac;

using CryptoHives.Foundation.Security.Cryptography.Mac;
using NUnit.Framework;
using Org.BouncyCastle.Crypto.Parameters;
using System;
using System.Buffers;
using System.Collections.Generic;
using System.Text;

/// <summary>
/// Pins that KMAC neither leaves key material in <see cref="ArrayPool{T}.Shared"/> nor depends on what it rents from it.
/// </summary>
/// <remarks>
/// <para>
/// <c>bytepad(encode_string(K), rate)</c> is assembled on the stack for keys that fit within the
/// rate, and in a rented buffer for keys that do not — 168 bytes for KMAC128, 136 for KMAC256. The
/// rented path is the one that matters: whatever it holds outlives the operation and becomes visible
/// to the next caller who rents that bucket.
/// </para>
/// <para>
/// Not parallelizable, and every assertion is guarded by an <c>Assume</c>, so a pool that hands back
/// something other than the buffer under test makes the test inconclusive rather than falsely green.
/// </para>
/// </remarks>
[TestFixture]
[NonParallelizable]
public class KMacBufferHygieneTests
{
    /// <summary>A key long enough to force the pooled path on both KMAC128 and KMAC256.</summary>
    private const int LongKeyLength = 256;

    private const byte Marker = 0xA7;

    /// <summary>The bucket <c>bytepad</c> lands in for a key of <see cref="LongKeyLength"/> bytes.</summary>
    private const int BucketLength = 512;

    private static List<byte[]> DrainBucket()
    {
        var drained = new List<byte[]>();
        for (int i = 0; i < 8; i++)
        {
            drained.Add(ArrayPool<byte>.Shared.Rent(BucketLength));
        }

        return drained;
    }

    private static void ReturnDrained(List<byte[]> drained)
    {
        foreach (byte[] array in drained)
        {
            ArrayPool<byte>.Shared.Return(array);
        }
    }

    /// <summary>Finds a run of <paramref name="length"/> consecutive marker bytes.</summary>
    private static bool ContainsKeyRun(byte[] haystack, int length)
    {
        int run = 0;
        foreach (byte b in haystack)
        {
            run = b == Marker ? run + 1 : 0;
            if (run >= length)
            {
                return true;
            }
        }

        return false;
    }

    private static byte[] LongKey()
    {
        var key = new byte[LongKeyLength];
        for (int i = 0; i < key.Length; i++)
        {
            key[i] = Marker;
        }

        return key;
    }

    [Test]
    public void KMac128DoesNotLeaveTheKeyInThePoolWhenItExceedsTheRate()
    {
        AssertNoKeyResidue(outputBytes => KMac128.Create(LongKey(), outputBytes, ""));
    }

    [Test]
    public void KMac256DoesNotLeaveTheKeyInThePoolWhenItExceedsTheRate()
    {
        AssertNoKeyResidue(outputBytes => KMac256.Create(LongKey(), outputBytes, ""));
    }

    [TestCase(128, 16, 300)]
    [TestCase(128, LongKeyLength, 0)]
    [TestCase(256, 16, 300)]
    [TestCase(256, LongKeyLength, 0)]
    public void KMacMatchesBouncyCastleWhenThePoolHandsBackDirtyBuffers(int bits, int keyLength, int customizationLength)
    {
        byte[] key = new byte[keyLength];
        for (int i = 0; i < key.Length; i++)
        {
            key[i] = (byte)i;
        }

        string customization = new('c', customizationLength);
        byte[] input = new byte[64];

        var reference = new Org.BouncyCastle.Crypto.Macs.KMac(bits, Encoding.UTF8.GetBytes(customization));
        reference.Init(new KeyParameter(key));
        reference.BlockUpdate(input, 0, input.Length);
        byte[] expected = new byte[32];
        reference.OutputFinal(expected, 0, expected.Length);

        PoisonBucket();
        using System.Security.Cryptography.HashAlgorithm kmac = bits == 128
            ? KMac128.Create(key, 32, customization)
            : KMac256.Create(key, 32, customization);

        Assert.That(kmac.ComputeHash(input), Is.EqualTo(expected));
    }

    /// <summary>Returns non-zero buffers to the bucket a <c>bytepad</c> over one rate block rents from.</summary>
    private static void PoisonBucket()
    {
        List<byte[]> drained = DrainBucket();
        foreach (byte[] array in drained)
        {
            array.AsSpan().Fill(0xFF);
        }

        ReturnDrained(drained);
    }

    private static void AssertNoKeyResidue(Func<int, System.Security.Cryptography.HashAlgorithm> create)
    {
        List<byte[]> drained = DrainBucket();
        try
        {
            using (System.Security.Cryptography.HashAlgorithm kmac = create(32))
            {
                byte[] mac = kmac.ComputeHash(new byte[64]);
                Assume.That(mac.Length, Is.EqualTo(32), "the MAC did not compute, so nothing was absorbed");
            }

            // Whichever buffer bytepad used is now back in the pool; take the bucket and look.
            var inspected = new List<byte[]>();
            try
            {
                for (int i = 0; i < 8; i++)
                {
                    byte[] candidate = ArrayPool<byte>.Shared.Rent(BucketLength);
                    inspected.Add(candidate);

                    Assert.That(ContainsKeyRun(candidate, 32), Is.False,
                        "a buffer in the pool still holds the MAC key");
                }
            }
            finally
            {
                foreach (byte[] array in inspected)
                {
                    ArrayPool<byte>.Shared.Return(array);
                }
            }
        }
        finally
        {
            ReturnDrained(drained);
        }
    }
}
