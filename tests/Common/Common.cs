// SPDX-FileCopyrightText: 2025 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

#pragma warning disable CA1308 // Normalize strings to uppercase

using NUnit.Framework;
using System;
using System.Globalization;
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

/// <summary>
/// Test helper methods for cross-platform compatibility.
/// </summary>
static class TestHelpers
{
    /// <summary>
    /// Converts a hexadecimal string to a byte array.
    /// </summary>
    /// <param name="hex">The hexadecimal string to convert.</param>
    /// <returns>A byte array representing the hexadecimal string.</returns>
    /// <remarks>
    /// This method provides cross-platform compatibility for .NET Framework
    /// where <c>Convert.FromHexString</c> is not available.
    /// </remarks>
    public static byte[] FromHexString(string hex)
    {
#if NET5_0_OR_GREATER
        return Convert.FromHexString(hex);
#else
        if (hex is null)
        {
            throw new ArgumentNullException(nameof(hex));
        }

        if (hex.Length % 2 != 0)
        {
            throw new FormatException("The hexadecimal string must have an even length.");
        }

        byte[] bytes = new byte[hex.Length / 2];
        for (int i = 0; i < bytes.Length; i++)
        {
            bytes[i] = Convert.ToByte(hex.Substring(i * 2, 2), 16);
        }

        return bytes;
#endif
    }

    /// <summary>
    /// Converts a byte array to a hexadecimal string.
    /// </summary>
    /// <param name="bytes">The byte array to convert.</param>
    /// <returns>A lowercase hexadecimal string.</returns>
    public static string ToHexString(byte[] bytes)
    {
#if NET5_0_OR_GREATER
        return Convert.ToHexString(bytes).ToLowerInvariant();
#else
        if (bytes is null)
        {
            throw new ArgumentNullException(nameof(bytes));
        }

        var sb = new System.Text.StringBuilder(bytes.Length * 2);
        foreach (byte b in bytes)
        {
            sb.Append(b.ToString("x2", CultureInfo.InvariantCulture));
        }

        return sb.ToString();
#endif
    }
}

