// SPDX-FileCopyrightText: 2025 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

using NUnit.Framework;
using System.Threading;
using System.Threading.Tasks;

static class AsyncAssert
{
    public static async Task NeverCompletesAsync(Task task, int timeoutMs = 500)
    {
        Task completed = await Task.WhenAny(task, Task.Delay(timeoutMs)).ConfigureAwait(false);
        if (completed == task)
        {
            Assert.Fail("Expected task to never complete.");
        }
    }

    public static async Task CancelAsync(CancellationTokenSource cts)
    {
#if NET8_0_OR_GREATER
        await cts.CancelAsync().ConfigureAwait(false);
#else
        await Task.Run(() => cts.Cancel()).ConfigureAwait(false);
#endif
    }
}
