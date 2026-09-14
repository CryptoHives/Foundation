// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace Cryptography.Tests.Hash;

using CryptoHives.Foundation.Security.Cryptography;
using CryptoHives.Foundation.Security.Cryptography.Hash;
using Microsoft.Extensions.ObjectPool;
using NUnit.Framework;
using System;
using System.Buffers;
using System.Text;

/// <summary>
/// Tests for <see cref="HashAlgorithm.TryReset"/> and the <c>IsInitialized</c> predicate that
/// lets it skip the reset.
/// </summary>
/// <remarks>
/// <para>
/// The pooled one-shot helpers finish with <c>TryComputeHash</c> or <c>TryGetHashAndReset</c>,
/// both of which end in <c>Initialize()</c> on success, so the instance the pool receives is
/// normally already reset. An algorithm that can cheaply prove it — BLAKE3, via
/// <c>Blake3State.IsFresh</c> — skips the second reset.
/// </para>
/// <para>
/// The failure mode this guards is silent: a predicate that reports "already initial" while any
/// state differs produces a wrong digest on the <i>next</i> use of the instance, never the
/// current one. So every test here hashes at least twice through one instance, with
/// <b>different</b> inputs, and compares against an instance that was never reused. Repeating the
/// same input would pass even with a broken predicate in some states.
/// </para>
/// </remarks>
[TestFixture]
public class HashAlgorithmResetTests
{
    private static readonly byte[] Abc = Encoding.ASCII.GetBytes("abc");

    /// <summary>
    /// Sizes spanning the BLAKE3 structural boundaries: empty, sub-block, one block, a partial
    /// chunk, exactly one chunk (the largest single-chunk one-shot), and past it into the tree.
    /// </summary>
    private static readonly int[] Sizes = [0, 1, 63, 64, 65, 1023, 1024, 1025, 4096];

    private static byte[] Data(int length)
    {
        byte[] data = new byte[length];
        for (int i = 0; i < length; i++)
        {
            data[i] = (byte)((i * 31 + 7) & 0xFF);
        }

        return data;
    }

    private static byte[] Reference(int length)
    {
        // A fresh instance per call: never reused, so it cannot be affected by a reset bug.
        using var oracle = new Blake3();
        byte[] expected = new byte[32];
        Assert.That(oracle.TryComputeHash(Data(length), expected, out int written), Is.True);
        Assert.That(written, Is.EqualTo(32));
        return expected;
    }

    // ── TryReset on an instance we own ───────────────────────────────────────────

    [Test]
    public void TryResetAfterAOneShotLeavesTheInstanceUsable()
    {
        // The skip path: TryComputeHash already re-initialized, so TryReset finds the state
        // initial and does nothing. The next hash must still be correct, and must be correct
        // for a *different* length than the one before it.
        using var hasher = new Blake3();
        byte[] actual = new byte[32];

        foreach (int length in Sizes)
        {
            Assert.That(hasher.TryComputeHash(Data(length), actual, out _), Is.True);
            Assert.That(actual, Is.EqualTo(Reference(length)), $"one-shot at {length} bytes");

            Assert.That(hasher.TryReset(), Is.True, $"TryReset after {length} bytes");
        }
    }

    [Test]
    public void TryResetAfterAPartialAppendLeavesTheInstanceUsable()
    {
        // The full-reset path: data has been appended but never finalized, so the state is
        // dirty and TryReset must actually reset it. This is what an exception escaping
        // mid-input leaves behind, and what the pool relies on to recover.
        using var hasher = new Blake3();
        byte[] actual = new byte[32];

        foreach (int length in Sizes)
        {
            hasher.AppendData(Data(length));
            Assert.That(hasher.TryReset(), Is.True, $"TryReset after appending {length} bytes");

            Assert.That(hasher.TryComputeHash(Data(3), actual, out _), Is.True);
            Assert.That(
                actual,
                Is.EqualTo(Reference(3)),
                $"digest after discarding a {length}-byte partial append");
        }
    }

    [Test]
    public void TryResetAfterAnUndersizedDestinationLeavesTheInstanceUsable()
    {
        // TryComputeHash rejects a short destination before consuming anything, so the state
        // is untouched -- but the instance must still hash correctly afterwards either way.
        using var hasher = new Blake3();
        Span<byte> tooSmall = stackalloc byte[31];

        Assert.That(hasher.TryComputeHash(Data(1024), tooSmall, out int written), Is.False);
        Assert.That(written, Is.Zero);

        Assert.That(hasher.TryReset(), Is.True);

        byte[] actual = new byte[32];
        Assert.That(hasher.TryComputeHash(Data(3), actual, out _), Is.True);
        Assert.That(actual, Is.EqualTo(Reference(3)));
    }

    [Test]
    public void TryResetAfterASqueezeLeavesTheInstanceUsable()
    {
        // Squeezing moves _squeezed, _outputCounter and _squeezeOffset, none of which a
        // one-shot touches. IsFresh must not report initial here.
        using var hasher = new Blake3();
        hasher.Absorb(Data(1024));

        byte[] xof = new byte[200];
        hasher.Squeeze(xof);

        Assert.That(hasher.TryReset(), Is.True);

        byte[] actual = new byte[32];
        Assert.That(hasher.TryComputeHash(Data(3), actual, out _), Is.True);
        Assert.That(actual, Is.EqualTo(Reference(3)), "digest after discarding a squeeze");
    }

    [Test]
    public void TryResetAfterASqueezeFromAnOtherwiseFreshInstanceRestartsTheStream()
    {
        // Squeezing without absorbing anything leaves every counter IsFresh reads at zero, so
        // _squeezed is the *only* field standing between this state and "already initial".
        // IsFresh excludes _outputCounter and _squeezeOffset deliberately, on the grounds that
        // !_squeezed already implies both are zero -- squeezing again after the reset is what
        // observes those two fields, and so what pins that reasoning.
        byte[] expected = new byte[300];
        using (var oracle = new Blake3())
        {
            oracle.Squeeze(expected);
        }

        using var hasher = new Blake3();
        byte[] first = new byte[300];
        hasher.Squeeze(first);
        Assert.That(first, Is.EqualTo(expected));

        Assert.That(hasher.TryReset(), Is.True);

        byte[] second = new byte[300];
        hasher.Squeeze(second);
        Assert.That(
            second,
            Is.EqualTo(expected),
            "the reset did not restart the output stream: the squeeze continued where it left off");
    }

    // ── Through the pool itself ──────────────────────────────────────────────────

    [Test]
    public void ADirtyInstanceReturnedToThePoolIsCleanBeforeItIsRentedAgain()
    {
        // The helpers in HashAlgorithmPool<T> return the instance from a finally, so an
        // exception thrown part-way through HashCore hands back a partially consumed
        // instance. The pool policy's TryReset is what recovers from that -- this asserts it
        // still does now that TryReset can skip the reset.
        ObjectPool<Blake3> pool = HashAlgorithmPool<Blake3>.Shared;

        Blake3 dirtied = pool.Get();
        dirtied.AppendData(Data(1025));
        pool.Return(dirtied);

        Blake3 rented = pool.Get();
        try
        {
            byte[] actual = new byte[32];
            Assert.That(rented.TryComputeHash(Data(3), actual, out _), Is.True);
            Assert.That(
                actual,
                Is.EqualTo(Reference(3)),
                "an instance returned to the pool mid-hash was rented out still dirty");
        }
        finally
        {
            pool.Return(rented);
        }
    }

    [Test]
    public void PooledStaticsAgreeWithAFreshInstanceAcrossVaryingSizes()
    {
        // Exercises all four static entry points back to back on the same pooled instance,
        // with the input length changing every call.
        foreach (int length in Sizes)
        {
            byte[] data = Data(length);
            byte[] expected = Reference(length);

            Assert.That(Blake3.HashData(data), Is.EqualTo(expected), $"HashData(span) at {length}");

            byte[] destination = new byte[32];
            Assert.That(Blake3.TryHashData(data, destination, out int written), Is.True);
            Assert.That(written, Is.EqualTo(32));
            Assert.That(destination, Is.EqualTo(expected), $"TryHashData(span) at {length}");

            ReadOnlySequence<byte> single = new(data);
            Assert.That(Blake3.HashData(single), Is.EqualTo(expected), $"HashData(sequence) at {length}");

            Array.Clear(destination, 0, destination.Length);
            Assert.That(Blake3.TryHashData(single, destination, out written), Is.True);
            Assert.That(destination, Is.EqualTo(expected), $"TryHashData(sequence) at {length}");
        }
    }

    [Test]
    public void PooledStaticsAgreeWithAFreshInstanceForAMultiSegmentSequence()
    {
        // The multi-segment arm takes AppendData/TryGetHashAndReset rather than
        // TryComputeHash, so it is a second route into the same pooled instance.
        foreach (int length in Sizes)
        {
            if (length == 0)
            {
                continue;
            }

            byte[] data = Data(length);
            ReadOnlySequence<byte> segmented = BuildMultiSegmentSequence(data, 7);

            Assert.That(
                Blake3.HashData(segmented),
                Is.EqualTo(Reference(length)),
                $"multi-segment HashData at {length}");
        }
    }

    // ── The pooling guard must survive the predicate ─────────────────────────────

    [Test]
    public void AKeyedInstanceStillRefusesToBePooled()
    {
        // IsInitialized must not short-circuit the mode guard: a keyed or derive-key instance
        // carries caller secrets and has to be disposed rather than recycled, even when its
        // state happens to look initial.
        byte[] key = new byte[32];
        for (int i = 0; i < key.Length; i++)
        {
            key[i] = (byte)i;
        }

        using (var keyed = Blake3.CreateKeyed(key))
        {
            Assert.That(keyed.TryReset(), Is.False, "a freshly created keyed instance");
        }

        using (var keyed = Blake3.CreateKeyed(key))
        {
            byte[] mac = new byte[32];
            Assert.That(keyed.TryComputeHash(Abc, mac, out _), Is.True);
            Assert.That(keyed.TryReset(), Is.False, "a keyed instance after a completed hash");
        }

        using (var derived = Blake3.CreateDeriveKey("CryptoHives 2026-09-14 reset test"))
        {
            Assert.That(derived.TryReset(), Is.False, "a derive-key instance");
        }
    }

    [Test]
    public void AnAlgorithmWithoutThePredicateStillResets()
    {
        // SHA-256 leaves IsInitialized at the false default, so TryReset always calls
        // Initialize(). Same contract, different path through it.
        using var sha = new SHA256();
        byte[] actual = new byte[32];

        sha.AppendData(Data(1000));
        Assert.That(sha.TryReset(), Is.True);

        Assert.That(sha.TryComputeHash(Abc, actual, out _), Is.True);

        using var oracle = new SHA256();
        byte[] expected = new byte[32];
        Assert.That(oracle.TryComputeHash(Abc, expected, out _), Is.True);
        Assert.That(actual, Is.EqualTo(expected));
    }

    private static ReadOnlySequence<byte> BuildMultiSegmentSequence(byte[] data, int segmentSize)
    {
        Segment? first = null;
        Segment? current = null;

        for (int offset = 0; offset < data.Length; offset += segmentSize)
        {
            int length = Math.Min(segmentSize, data.Length - offset);
            var memory = new ReadOnlyMemory<byte>(data, offset, length);
            current = current is null ? (first = new Segment(memory, 0)) : current.Append(memory);
        }

        return first is null
            ? ReadOnlySequence<byte>.Empty
            : new ReadOnlySequence<byte>(first, 0, current!, current!.Memory.Length);
    }

    private sealed class Segment : ReadOnlySequenceSegment<byte>
    {
        public Segment(ReadOnlyMemory<byte> memory, long runningIndex)
        {
            Memory = memory;
            RunningIndex = runningIndex;
        }

        public Segment Append(ReadOnlyMemory<byte> memory)
        {
            var next = new Segment(memory, RunningIndex + Memory.Length);
            Next = next;
            return next;
        }
    }
}
