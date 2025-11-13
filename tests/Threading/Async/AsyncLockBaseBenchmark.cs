// SPDX-FileCopyrightText: 2025 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Threading.Tests.Async;

using CryptoHives.Foundation.Threading.Async;
using Nito.AsyncEx;

public class AsyncLockBaseBenchmark
{
    protected readonly PooledAsyncLock _lockPooled = new();
    protected readonly AsyncLock _lockNitoAsync = new();
    protected readonly object _lock = new();
}
