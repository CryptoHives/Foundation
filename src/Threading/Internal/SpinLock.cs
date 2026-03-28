// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Threading.Internal;

using System.Runtime.CompilerServices;
using System.Threading;

/// <summary>
/// A lightweight, non reentrant spin lock for
/// internal use in the threading libraries.
/// </summary>
internal struct SpinLock
{
    private volatile int _state;

    public SpinLock()
        => _state = 0;

    [MethodImpl(MethodImplOptionsEx.HotPath)]
    public bool TryEnter()
        => Interlocked.Exchange(ref _state, 1) == 0;

    [MethodImpl(MethodImplOptionsEx.HotPath)]
    public void Enter()
    {
        if (!TryEnter())
        {
            EnterCore();
        }
    }

    [MethodImpl(MethodImplOptionsEx.OptimizedLoop)]
    private void EnterCore()
    {
        // Spin forever
        var spinWait = new SpinWait();
        do
        {
            // SpinOnce yields based on .NET heuristics 
            spinWait.SpinOnce();
        } while (!TryEnter());
    }

    [MethodImpl(MethodImplOptionsEx.HotPath)]
    internal void Exit()
        => _state = 0;
}
