// SPDX-FileCopyrightText: 2025 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace Memory.Tests.Buffers;

using CryptoHives.Foundation.Memory.Buffers;
using NUnit.Framework;
using System;
using System.Buffers;
using System.IO;

/// <summary>
/// Tests for <see cref="ReadOnlySequenceMemoryStream"/>.
/// </summary>
[Parallelizable(ParallelScope.All)]
public class ReadOnlySequenceMemoryStreamTests
{
    [Test]
    public void ReadOnlySequenceMemoryStreamWhenConstructedWithDefaultOptionsShouldNotThrow()
    {
        using ReadOnlySequenceMemoryStream stream = new(ReadOnlySequence<byte>.Empty);

        void Act() => stream.Dispose();
        byte[] buffer = new byte[1];

        using (Assert.EnterMultipleScope())
        {
            Assert.That(stream.CanSeek, Is.True);
            Assert.That(stream.CanRead, Is.True);
            Assert.That(stream.CanWrite, Is.False);
        }

        Assert.That(stream.ReadByte(), Is.EqualTo(-1));
        Assert.That(stream.Read(buffer, 0, 1), Is.Zero);
        Assert.That(stream.Read(buffer.AsSpan(0, 1)), Is.Zero);

        using (Assert.EnterMultipleScope())
        {
            Assert.That(stream.Seek(0, SeekOrigin.End), Is.Zero);
            Assert.That(stream.Seek(0, SeekOrigin.Current), Is.Zero);
            Assert.That(stream.Seek(0, SeekOrigin.Begin), Is.Zero);
        }

        Assert.Throws<IOException>(() => stream.Seek(-1, SeekOrigin.Begin));
        Assert.Throws<IOException>(() => stream.Seek(0, (SeekOrigin)66));
        Assert.Throws<IOException>(() => stream.Seek(1000, SeekOrigin.Begin));

        Assert.Throws<NotSupportedException>(() => stream.SetLength(0));
        Assert.Throws<NotSupportedException>(() => stream.WriteByte(0));
        Assert.Throws<NotSupportedException>(() => stream.Write(buffer, 0, 1));
        Assert.Throws<NotSupportedException>(() => stream.Write(buffer.AsSpan(0, 1)));

        Assert.That(stream.Seek(0, SeekOrigin.Begin), Is.Zero);
        Assert.That(stream.ReadByte(), Is.EqualTo(-1));
        Assert.That(stream.Read(buffer, 0, 1), Is.Zero);
        Assert.That(stream.Read(buffer.AsSpan(0, 1)), Is.Zero);
        stream.Flush();

        stream.Position = 0;
        Assert.That(stream.ToArray(), Is.Empty);

        Assert.That(stream.Seek(0, SeekOrigin.Begin), Is.Zero);

        Assert.That(stream.ToArray(), Is.Empty);

        Assert.DoesNotThrow(() => Act());
    }
}
