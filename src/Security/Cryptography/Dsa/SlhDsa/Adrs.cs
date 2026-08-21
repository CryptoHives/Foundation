// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Security.Cryptography.Dsa;

using System;
using System.Runtime.CompilerServices;

/// <summary>
/// The 32-byte hash address structure ADRS used for SLH-DSA domain separation (FIPS 205 §4.2).
/// </summary>
/// <remarks>
/// Layout: layer address (4) ‖ tree address (12) ‖ type (4) ‖ three type-specific words (12),
/// all big-endian. The compressed 22-byte form used by the SHA-2 instantiation (§11.2.1)
/// keeps 1 byte of the layer, 8 bytes of the tree address, 1 byte of the type, and the
/// 12 type-specific bytes.
/// </remarks>
internal sealed class Adrs
{
    /// <summary>WOTS+ hash chain address type.</summary>
    public const int WotsHash = 0;

    /// <summary>WOTS+ public key compression address type.</summary>
    public const int WotsPk = 1;

    /// <summary>Merkle tree node address type.</summary>
    public const int Tree = 2;

    /// <summary>FORS tree node address type.</summary>
    public const int ForsTree = 3;

    /// <summary>FORS root compression address type.</summary>
    public const int ForsRoots = 4;

    /// <summary>WOTS+ secret key generation address type.</summary>
    public const int WotsPrf = 5;

    /// <summary>FORS secret key generation address type.</summary>
    public const int ForsPrf = 6;

    /// <summary>The size of the compressed address form in bytes.</summary>
    public const int CompressedBytes = 22;

    private readonly byte[] _bytes = new byte[32];

    /// <summary>
    /// Gets the raw 32-byte address.
    /// </summary>
    public ReadOnlySpan<byte> Bytes => _bytes;

    /// <summary>
    /// Creates a copy of this address.
    /// </summary>
    public Adrs Clone()
    {
        var copy = new Adrs();
        _bytes.CopyTo(copy._bytes, 0);
        return copy;
    }

    /// <summary>Sets the hypertree layer address (word 0).</summary>
    public void SetLayerAddress(int layer) => WriteWord(0, (uint)layer);

    /// <summary>Sets the 64-bit tree index within the layer (bytes 8–15; bytes 4–7 stay zero).</summary>
    public void SetTreeAddress(ulong tree)
    {
        WriteWord(4, 0);
        WriteWord(8, (uint)(tree >> 32));
        WriteWord(12, (uint)tree);
    }

    /// <summary>Sets the address type (word 4) and clears the three type-specific words.</summary>
    public void SetTypeAndClear(int type)
    {
        WriteWord(16, (uint)type);
        Array.Clear(_bytes, 20, 12);
    }

    /// <summary>Sets the WOTS+/FORS key pair address (word 5).</summary>
    public void SetKeyPairAddress(int keyPair) => WriteWord(20, (uint)keyPair);

    /// <summary>Gets the WOTS+/FORS key pair address (word 5).</summary>
    public int GetKeyPairAddress() => (int)ReadWord(20);

    /// <summary>Sets the WOTS+ chain address (word 6).</summary>
    public void SetChainAddress(int chain) => WriteWord(24, (uint)chain);

    /// <summary>Sets the Merkle tree height (word 6).</summary>
    public void SetTreeHeight(int height) => WriteWord(24, (uint)height);

    /// <summary>Sets the WOTS+ hash address within a chain (word 7).</summary>
    public void SetHashAddress(int hash) => WriteWord(28, (uint)hash);

    /// <summary>Sets the Merkle tree node index (word 7).</summary>
    public void SetTreeIndex(int index) => WriteWord(28, (uint)index);

    /// <summary>Gets the Merkle tree node index (word 7).</summary>
    public int GetTreeIndex() => (int)ReadWord(28);

    /// <summary>
    /// Writes the 22-byte compressed address form used by the SHA-2 instantiation.
    /// </summary>
    /// <param name="destination">The buffer to receive the compressed address (22 bytes).</param>
    public void CopyCompressedTo(Span<byte> destination)
    {
        destination[0] = _bytes[3];                       // layer, low byte
        _bytes.AsSpan(8, 8).CopyTo(destination.Slice(1)); // tree address, low 8 bytes
        destination[9] = _bytes[19];                      // type, low byte
        _bytes.AsSpan(20, 12).CopyTo(destination.Slice(10));
    }

    [MethodImpl(MethodImplOptionsEx.HotPath)]
    private void WriteWord(int offset, uint value)
    {
        _bytes[offset] = (byte)(value >> 24);
        _bytes[offset + 1] = (byte)(value >> 16);
        _bytes[offset + 2] = (byte)(value >> 8);
        _bytes[offset + 3] = (byte)value;
    }

    [MethodImpl(MethodImplOptionsEx.HotPath)]
    private uint ReadWord(int offset)
    {
        return ((uint)_bytes[offset] << 24)
             | ((uint)_bytes[offset + 1] << 16)
             | ((uint)_bytes[offset + 2] << 8)
             | _bytes[offset + 3];
    }
}
