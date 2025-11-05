// SPDX-FileCopyrightText: 2025 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Memory.Buffers;

using System;
using System.Buffers;
using System.Threading;

/// <summary>
/// Helper to build a ReadOnlySequence from a set of <see cref="ArrayPool{T}"/> allocated buffers.
/// </summary>
public sealed class ArrayPoolBufferSegment<T> : ReadOnlySequenceSegment<T>
{
    private T[]? _array;

    /// <summary>
    /// Initializes a new instance of the <see cref="ArrayPoolBufferSegment{T}"/> class.
    /// </summary>
    public ArrayPoolBufferSegment(T[] array, int offset, int length)
    {
        Memory = new ReadOnlyMemory<T>(array, offset, length);
        _array = array;
    }

    /// <summary>
    /// Returns a rented buffer to the shared pool and invalidates memory.
    /// </summary>
    public void Return(bool clearArray = false)
    {
        T[]? array = Interlocked.Exchange(ref _array, null);
        if (array != null)
        {
            ArrayPool<T>.Shared.Return(array, clearArray);
            Memory = ReadOnlyMemory<T>.Empty;
        }
    }

    /// <summary>
    /// Appends a buffer to the sequence.
    /// </summary>
    public ArrayPoolBufferSegment<T> Append(T[] array, int offset, int length)
    {
        var segment = new ArrayPoolBufferSegment<T>(array, offset, length) {
            RunningIndex = RunningIndex + Memory.Length,
        };
        Next = segment;
        return segment;
    }
}
