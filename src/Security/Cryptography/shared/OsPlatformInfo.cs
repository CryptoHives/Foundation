// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Security.Cryptography;

using System;
#if !(NET462 || NET472)
using System.Runtime.InteropServices;
#endif

/// <summary>
/// Caches the current process's operating system and architecture, computed once at startup.
/// </summary>
/// <remarks>
/// Used exclusively to resolve <see cref="OsNativeDefaults"/> - the curated, per-algorithm
/// preference for the OS-native implementation over the managed one (<see cref="SimdSupport.Os"/>).
/// This has no bearing on CPU-ISA feature detection, which remains entirely separate.
/// </remarks>
internal static class OsPlatformInfo
{
#if NET462 || NET472
    // .NET Framework has no built-in reference to System.Runtime.InteropServices.RuntimeInformation
    // without an extra package dependency, and only ever ships on Windows, so this is exact without it.

    /// <summary>
    /// <see langword="true"/> if the current process is running on Windows.
    /// </summary>
    internal const bool IsWindows = true;

    /// <summary>
    /// <see langword="true"/> if the current process is running on Linux.
    /// </summary>
    internal const bool IsLinux = false;

    /// <summary>
    /// <see langword="true"/> if the current process is running on macOS.
    /// </summary>
    internal const bool IsMacOs = false;

    /// <summary>
    /// <see langword="true"/> if the current process architecture is x64.
    /// </summary>
    internal static readonly bool IsX64 = Environment.Is64BitProcess;

    /// <summary>
    /// <see langword="true"/> if the current process architecture is Arm64.
    /// </summary>
    internal const bool IsArm64 = false;
#else
    /// <summary>
    /// <see langword="true"/> if the current process is running on Windows.
    /// </summary>
    internal static readonly bool IsWindows =
#if NET8_0_OR_GREATER
        OperatingSystem.IsWindows();
#else
        RuntimeInformation.IsOSPlatform(OSPlatform.Windows);
#endif

    /// <summary>
    /// <see langword="true"/> if the current process is running on Linux.
    /// </summary>
    internal static readonly bool IsLinux =
#if NET8_0_OR_GREATER
        OperatingSystem.IsLinux();
#else
        RuntimeInformation.IsOSPlatform(OSPlatform.Linux);
#endif

    /// <summary>
    /// <see langword="true"/> if the current process is running on macOS.
    /// </summary>
    internal static readonly bool IsMacOs =
#if NET8_0_OR_GREATER
        OperatingSystem.IsMacOS();
#else
        RuntimeInformation.IsOSPlatform(OSPlatform.OSX);
#endif

    /// <summary>
    /// <see langword="true"/> if the current process architecture is x64.
    /// </summary>
    internal static readonly bool IsX64 = RuntimeInformation.ProcessArchitecture == Architecture.X64;

    /// <summary>
    /// <see langword="true"/> if the current process architecture is Arm64.
    /// </summary>
    internal static readonly bool IsArm64 = RuntimeInformation.ProcessArchitecture == Architecture.Arm64;
#endif
}
