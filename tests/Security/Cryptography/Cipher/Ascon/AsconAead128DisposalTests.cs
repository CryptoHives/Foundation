// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace Cryptography.Tests.Cipher.Ascon;

using CryptoHives.Foundation.Security.Cryptography.Cipher;
using NUnit.Framework;
using System;

/// <summary>
/// Pins the disposal contract of <see cref="AsconAead128"/>.
/// </summary>
/// <remarks>
/// The key lives in two <c>ulong</c> fields rather than an array, so it used to survive disposal
/// entirely — <c>Dispose</c> was a comment saying there was nothing to clear. Zeroing those fields
/// makes the key unrecoverable, but on its own it would turn a use-after-dispose from "works" into
/// "silently encrypts under an all-zero key", so the operations now refuse instead.
/// </remarks>
[TestFixture]
[Parallelizable(ParallelScope.All)]
public class AsconAead128DisposalTests
{
    private static byte[] Key() => new byte[AsconAead128.KeySizeBytesConst];

    private static byte[] Nonce() => new byte[AsconAead128.NonceSizeBytesConst];

    [Test]
    public void EncryptAfterDisposeThrows()
    {
        var aead = new AsconAead128(Key());
        aead.Dispose();

        var ciphertext = new byte[16];
        var tag = new byte[AsconAead128.TagSizeBytesConst];

        Assert.That(() => aead.Encrypt(Nonce(), new byte[16], ciphertext, tag),
            Throws.InstanceOf<ObjectDisposedException>());
    }

    [Test]
    public void DecryptAfterDisposeThrows()
    {
        var aead = new AsconAead128(Key());
        aead.Dispose();

        var plaintext = new byte[16];
        var tag = new byte[AsconAead128.TagSizeBytesConst];

        Assert.That(() => aead.Decrypt(Nonce(), new byte[16], tag, plaintext),
            Throws.InstanceOf<ObjectDisposedException>());
    }

    [Test]
    public void DisposeIsIdempotent()
    {
        var aead = new AsconAead128(Key());
        aead.Dispose();

        Assert.That(() => aead.Dispose(), Throws.Nothing);
    }

    [Test]
    public void RoundTripStillWorksBeforeDispose()
    {
        // Guards against the disposed check being wired to the wrong condition.
        using var aead = new AsconAead128(Key());

        byte[] plaintext = new byte[] { 1, 2, 3, 4, 5 };
        var ciphertext = new byte[plaintext.Length];
        var tag = new byte[AsconAead128.TagSizeBytesConst];
        aead.Encrypt(Nonce(), plaintext, ciphertext, tag);

        var recovered = new byte[plaintext.Length];
        Assert.That(aead.Decrypt(Nonce(), ciphertext, tag, recovered), Is.True);
        Assert.That(recovered, Is.EqualTo(plaintext));
    }
}
