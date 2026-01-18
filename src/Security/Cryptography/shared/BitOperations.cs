namespace CryptoHives.Foundation.Security.Cryptography;

using System.Runtime.CompilerServices;

#if !NET5_0_OR_GREATER

internal class BitOperations
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static uint RotateLeft(uint x, int n) => (x << n) | (x >> (32 - n));

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ulong RotateLeft(ulong x, int n) => (x << n) | (x >> (64 - n));

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static uint RotateRight(uint x, int n) => (x >> n) | (x << (32 - n));

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ulong RotateRight(ulong x, int n) => (x >> n) | (x << (64 - n));
}

#endif
