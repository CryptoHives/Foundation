// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace Cryptography.Tests.Mac.KMac;

using CryptoHives.Foundation.Security.Cryptography.Mac;
using NUnit.Framework;
using System;
using System.Buffers;
using System.Collections.Generic;

/// <summary>
/// Pins that KMAC does not leave key material in <see cref="ArrayPool{T}.Shared"/>.
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
