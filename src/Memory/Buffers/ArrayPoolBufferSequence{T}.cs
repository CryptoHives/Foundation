// ------------------------------------------------------------
//  Copyright (c) 2025 The Keepers of the CryptoHives.  All rights reserved.
//  Licensed under the MIT License (MIT). See LICENSE in the repo root for license information.
// ------------------------------------------------------------

namespace CryptoHives.Memory.Buffers;

using System;
using System.Buffers;

/// <summary>
/// A class to hold a sequence of ArrayPool buffers in a <see cref="ReadOnlySequence{T}"/>"/>until disposed.
/// </summary>
public sealed class ArrayPoolBufferSequence<T> : IDisposable
{
    private ArrayPoolBufferSegment<T>? _firstSegment;
    private ReadOnlySequence<T> _sequence;
    private bool _clearArray;

    /// <summary>
    /// Initializes a new instance of the <see cref="ArrayPoolBufferSequence{T}"/> class.
    /// </summary>
    public ArrayPoolBufferSequence(ArrayPoolBufferSegment<T>? firstSegment, ReadOnlySequence<T> sequence, bool clearArray = false)
    {
        _firstSegment = firstSegment;
        _sequence = sequence;
        _clearArray = clearArray;
    }

    /// <summary>
    /// Gets a sequence which can be used to access the buffers.
    /// </summary>
    public ReadOnlySequence<T> Sequence => _sequence;

    /// <inheritdoc/>
    public void Dispose()
    {
        ArrayPoolBufferSegment<T>? segment = _firstSegment;
        while (segment != null)
        {
            segment.Return(_clearArray);
            segment = (ArrayPoolBufferSegment<T>?)segment.Next;
        }

        _sequence = ReadOnlySequence<T>.Empty;
        _firstSegment = null;
        GC.SuppressFinalize(this);
    }
}

