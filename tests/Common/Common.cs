// SPDX-FileCopyrightText: 2025 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

using NUnit.Framework;
using System;
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
            sb.Append(b.ToString("x2"));
        }

        return sb.ToString();
#endif
    }
}

#if NET8_0_OR_GREATER
/// <summary>
/// Adapter to wrap .NET Shake128 XOF as a HashAlgorithm for testing.
/// </summary>
internal sealed class Shake128HashAdapter : System.Security.Cryptography.HashAlgorithm
{
    private readonly int _outputLength;
    private readonly System.IO.MemoryStream _buffer = new();

    public Shake128HashAdapter(int outputLength)
    {
        _outputLength = outputLength;
        HashSizeValue = outputLength * 8;
    }

    public override void Initialize() => _buffer.SetLength(0);

    protected override void HashCore(byte[] array, int ibStart, int cbSize)
        => _buffer.Write(array, ibStart, cbSize);

    protected override byte[] HashFinal()
    {
        var output = new byte[_outputLength];
        System.Security.Cryptography.Shake128.HashData(_buffer.ToArray(), output);
        return output;
    }

    protected override void Dispose(bool disposing)
    {
        if (disposing)
        {
            _buffer.Dispose();
        }

        base.Dispose(disposing);
    }
}

/// <summary>
/// Adapter to wrap .NET Shake256 XOF as a HashAlgorithm for testing.
/// </summary>
internal sealed class Shake256HashAdapter : System.Security.Cryptography.HashAlgorithm
{
    private readonly int _outputLength;
    private readonly System.IO.MemoryStream _buffer = new();

    public Shake256HashAdapter(int outputLength)
    {
        _outputLength = outputLength;
        HashSizeValue = outputLength * 8;
    }

    public override void Initialize() => _buffer.SetLength(0);

    protected override void HashCore(byte[] array, int ibStart, int cbSize)
        => _buffer.Write(array, ibStart, cbSize);

    protected override byte[] HashFinal()
    {
        var output = new byte[_outputLength];
        System.Security.Cryptography.Shake256.HashData(_buffer.ToArray(), output);
        return output;
    }

    protected override void Dispose(bool disposing)
    {
        if (disposing)
        {
            _buffer.Dispose();
        }

        base.Dispose(disposing);
    }
}
#endif

#if NET9_0_OR_GREATER
/// <summary>
/// Adapter to wrap .NET 9+ Kmac128 as a HashAlgorithm for testing and benchmarking.
/// </summary>
internal sealed class Kmac128HashAdapter : System.Security.Cryptography.HashAlgorithm
{
    private readonly byte[] _key;
    private readonly byte[] _customization;
    private readonly int _outputLength;
    private readonly System.IO.MemoryStream _buffer = new();

    public Kmac128HashAdapter(byte[] key, int outputLength, string customization = "")
    {
        _key = key ?? throw new ArgumentNullException(nameof(key));
        _customization = System.Text.Encoding.UTF8.GetBytes(customization ?? "");
        _outputLength = outputLength;
        HashSizeValue = outputLength * 8;
    }

    public Kmac128HashAdapter(byte[] key, int outputLength, byte[] customization)
    {
        _key = key ?? throw new ArgumentNullException(nameof(key));
        _customization = customization ?? [];
        _outputLength = outputLength;
        HashSizeValue = outputLength * 8;
    }

    public override void Initialize() => _buffer.SetLength(0);

    protected override void HashCore(byte[] array, int ibStart, int cbSize)
        => _buffer.Write(array, ibStart, cbSize);

    protected override byte[] HashFinal()
    {
        var output = new byte[_outputLength];
        System.Security.Cryptography.Kmac128.HashData(_key, _buffer.ToArray(), output, _customization);
        return output;
    }

    protected override void Dispose(bool disposing)
    {
        if (disposing)
        {
            _buffer.Dispose();
        }

        base.Dispose(disposing);
    }
}

/// <summary>
/// Adapter to wrap .NET 9+ Kmac256 as a HashAlgorithm for testing and benchmarking.
/// </summary>
internal sealed class Kmac256HashAdapter : System.Security.Cryptography.HashAlgorithm
{
    private readonly byte[] _key;
    private readonly byte[] _customization;
    private readonly int _outputLength;
    private readonly System.IO.MemoryStream _buffer = new();

    public Kmac256HashAdapter(byte[] key, int outputLength, string customization = "")
    {
        _key = key ?? throw new ArgumentNullException(nameof(key));
        _customization = System.Text.Encoding.UTF8.GetBytes(customization ?? "");
        _outputLength = outputLength;
        HashSizeValue = outputLength * 8;
    }

    public Kmac256HashAdapter(byte[] key, int outputLength, byte[] customization)
    {
        _key = key ?? throw new ArgumentNullException(nameof(key));
        _customization = customization ?? [];
        _outputLength = outputLength;
        HashSizeValue = outputLength * 8;
    }

    public override void Initialize() => _buffer.SetLength(0);

    protected override void HashCore(byte[] array, int ibStart, int cbSize)
        => _buffer.Write(array, ibStart, cbSize);

    protected override byte[] HashFinal()
    {
        var output = new byte[_outputLength];
        System.Security.Cryptography.Kmac256.HashData(_key, _buffer.ToArray(), output, _customization);
        return output;
    }

    protected override void Dispose(bool disposing)
    {
        if (disposing)
        {
            _buffer.Dispose();
        }

        base.Dispose(disposing);
    }
}
#endif
