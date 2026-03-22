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
    private int _state;

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

    [MethodImpl(MethodImplOptions.NoInlining)]
    private void EnterCore()
    {
        // Spin forever
        var spinWait = new SpinWait();
        spinWait.SpinOnce();

        while (!TryEnter())
        {
            // SpinOnce yields based on .NET heuristics 
            spinWait.SpinOnce();
        }
    }

    [MethodImpl(MethodImplOptionsEx.HotPath)]
    internal void Exit()
        => Interlocked.Exchange(ref _state, 0);
}
