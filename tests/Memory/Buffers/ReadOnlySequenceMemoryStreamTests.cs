// ------------------------------------------------------------
//  Copyright (c) 2025 The Keepers of the CryptoHives.  All rights reserved.
//  Licensed under the MIT License (MIT). See LICENSE in the repo root for license information.
// ------------------------------------------------------------

namespace CryptoHives.Memory.Tests.Buffers;

using CryptoHives.Memory.Buffers;
using NUnit.Framework;
using System;
using System.Buffers;
using System.IO;

/// <summary>
/// Tests for <see cref="ReadOnlySequenceMemoryStreamTests"/>.
/// </summary>
[Parallelizable(ParallelScope.All)]
public class ReadOnlySequenceMemoryStreamTests
{
    /// <summary>
    /// Test the default behavior of <see cref="ReadOnlySequenceMemoryStream"/>.
    /// </summary>
    [Test]
    public void ReadOnlySequenceMemoryStreamWhenConstructedWithDefaultOptionsShouldNotThrow()
    {
        // Arrange
        using ReadOnlySequenceMemoryStream stream = new(ReadOnlySequence<byte>.Empty);

        // Act
        void Act() => stream.Dispose();
        byte[] buffer = new byte[1];

        // Assert
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
        Assert.That(stream, Is.Empty);

        Assert.That(stream, Is.Empty);

        Assert.That(stream.Seek(0, SeekOrigin.Begin), Is.Zero);

        byte[] array = stream.ToArray();
        Assert.That(array, Is.Empty);

        Assert.DoesNotThrow(() => Act());
    }
}
