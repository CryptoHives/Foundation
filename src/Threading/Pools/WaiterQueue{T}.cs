// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Threading.Pools;

using System;
using System.Diagnostics;

/// <summary>
/// An intrusive doubly-linked list used as a FIFO waiter queue for async primitives.
/// </summary>
/// <remarks>
/// <para>
/// Unlike <see cref="System.Collections.Generic.Queue{T}"/>, this structure supports O(1) removal
/// of any node by reference allowing for efficient removal of cancellation callbacks.
/// </para>
/// <para>
/// The link fields (<see cref="ManualResetValueTaskSource{T}.Next"/> and
/// <see cref="ManualResetValueTaskSource{T}.Prev"/>) are stored on the waiter nodes themselves,
/// making this an intrusive data structure with zero per-enqueue allocation overhead.
/// </para>
/// <para>
/// <b>Thread Safety:</b> All mutations must be performed under the caller's lock.
/// This struct provides no internal synchronization.
/// </para>
/// </remarks>
/// <typeparam name="T">The result type of the value task source.</typeparam>
internal struct WaiterQueue<T>
{
    private ManualResetValueTaskSource<T>? _head;
    private ManualResetValueTaskSource<T>? _tail;
    private int _count;

    /// <summary>
    /// Gets the number of nodes in the queue.
    /// </summary>
    public readonly int Count => _count;

    /// <summary>
    /// Appends a node to the tail of the queue.
    /// </summary>
    /// <param name="node">The waiter node to enqueue.</param>
    public void Enqueue(ManualResetValueTaskSource<T> node)
    {
        Debug.Assert(node.Next is null && node.Prev is null, "Node is already in a queue.");

        node.Prev = _tail;
        node.Next = null;

        if (_tail is not null)
        {
            _tail.Next = node;
        }
        else
        {
            _head = node;
        }

        _tail = node;
        _count++;
    }

    /// <summary>
    /// Removes and returns the node at the head of the queue.
    /// </summary>
    /// <returns>The dequeued waiter node.</returns>
    public ManualResetValueTaskSource<T> Dequeue()
    {
        Debug.Assert(_head is not null, "Queue is empty.");

        var node = _head;
        _head = node!.Next;

        if (_head is not null)
        {
            _head.Prev = null;
        }
        else
        {
            _tail = null;
        }

        node.Next = null;
        node.Prev = null;
        _count--;

        return node;
    }

    /// <summary>
    /// Removes a specific node from the queue in O(1) time.
    /// </summary>
    /// <param name="node">The waiter node to remove.</param>
    /// <returns><see langword="true"/> if the node was found and removed; otherwise, <see langword="false"/>.</returns>
    public bool Remove(ManualResetValueTaskSource<T> node)
    {
        // Node is not in this queue if it has no links and is not the only element.
        if (node.Next is null && node.Prev is null && !ReferenceEquals(_head, node))
        {
            return false;
        }

        if (ReferenceEquals(_head, node))
        {
            _head = node.Next;
        }

        if (ReferenceEquals(_tail, node))
        {
            _tail = node.Prev;
        }

        if (node.Prev is not null)
        {
            node.Prev.Next = node.Next;
        }

        if (node.Next is not null)
        {
            node.Next.Prev = node.Prev;
        }

        node.Next = null;
        node.Prev = null;
        _count--;

        return true;
    }

    /// <summary>
    /// Detaches the entire chain from the queue and returns the head node.
    /// </summary>
    /// <remarks>
    /// <para>
    /// The caller can walk the detached chain via <see cref="ManualResetValueTaskSource{T}.Next"/>
    /// links without holding a lock. The <see cref="ManualResetValueTaskSource{T}.Prev"/> links
    /// are cleared during detach, but <see cref="ManualResetValueTaskSource{T}.Next"/> links
    /// are preserved for traversal. The caller must clear each node's
    /// <see cref="ManualResetValueTaskSource{T}.Next"/> after processing.
    /// </para>
    /// </remarks>
    /// <param name="count">Receives the number of detached nodes.</param>
    /// <returns>The head of the detached chain, or <see langword="null"/> if the queue was empty.</returns>
    public ManualResetValueTaskSource<T>? DetachAll(out int count)
    {
        var head = _head;
        count = _count;

        // Clear Prev links (not needed for forward traversal); keep Next links for walking.
        var current = head;
        while (current is not null)
        {
            current.Prev = null;
            current = current.Next;
        }

        _head = null;
        _tail = null;
        _count = 0;

        return head;
    }

    /// <summary>
    /// Detaches up to <paramref name="maxCount"/> nodes from the head of the queue and returns the chain.
    /// </summary>
    /// <remarks>
    /// <para>
    /// Used by <see cref="CryptoHives.Foundation.Threading.Async.Pooled.AsyncSemaphore"/> to release
    /// a subset of waiters. The <see cref="ManualResetValueTaskSource{T}.Next"/> links are preserved
    /// for traversal; the caller must clear each node's link after processing.
    /// </para>
    /// </remarks>
    /// <param name="maxCount">The maximum number of nodes to detach.</param>
    /// <param name="count">Receives the actual number of detached nodes.</param>
    /// <returns>The head of the detached chain, or <see langword="null"/> if the queue was empty.</returns>
    public ManualResetValueTaskSource<T>? DetachFirst(int maxCount, out int count)
    {
        Debug.Assert(maxCount > 0, "maxCount must be positive.");

        count = maxCount < _count ? maxCount : _count;
        if (count == 0)
        {
            return null;
        }

        var head = _head;
        var current = head;

        // Walk to the last node to detach.
        for (int i = 1; i < count; i++)
        {
            current!.Prev = null;
            current = current.Next;
        }

        // current is now the last node to detach. Sever the chain.
        var newHead = current!.Next;
        current.Next = null;
        current.Prev = null;

        _head = newHead;
        if (_head is not null)
        {
            _head.Prev = null;
        }
        else
        {
            _tail = null;
        }

        _count -= count;

        // Clear Prev on head (it was tail's prev before, but head.Prev is already null for head node).
        // head.Prev is already null since it was the queue head.
        return head;
    }

    /// <summary>
    /// Walks a detached chain calling <see cref="ManualResetValueTaskSource{T}.SetResult"/> on each node.
    /// </summary>
    /// <remarks>
    /// Clears the <see cref="ManualResetValueTaskSource{T}.Next"/> link on each node after processing.
    /// Must be called outside the caller's lock since <see cref="ManualResetValueTaskSource{T}.SetResult"/>
    /// may invoke continuations synchronously.
    /// </remarks>
    /// <param name="chain">The head of the detached chain, or <see langword="null"/>.</param>
    /// <param name="value">The result value to set on each node.</param>
    public static void SetChainResult(ManualResetValueTaskSource<T>? chain, T value)
    {
        while (chain is not null)
        {
            var next = chain.Next;
            chain.Next = null;
            chain.SetResult(value);
            chain = next;
        }
    }

    /// <summary>
    /// Walks a detached chain calling <see cref="ManualResetValueTaskSource{T}.SetException"/> on each node.
    /// </summary>
    /// <remarks>
    /// Clears the <see cref="ManualResetValueTaskSource{T}.Next"/> link on each node after processing.
    /// Must be called outside the caller's lock since <see cref="ManualResetValueTaskSource{T}.SetException"/>
    /// may invoke continuations synchronously.
    /// </remarks>
    /// <param name="chain">The head of the detached chain, or <see langword="null"/>.</param>
    /// <param name="exception">The exception to set on each node.</param>
    public static void SetChainException(ManualResetValueTaskSource<T>? chain, Exception exception)
    {
        while (chain is not null)
        {
            var next = chain.Next;
            chain.Next = null;
            chain.SetException(exception);
            chain = next;
        }
    }
}
