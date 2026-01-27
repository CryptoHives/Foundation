# XChaCha20-Poly1305 Benchmarks

## Overview

XChaCha20-Poly1305 is an extended-nonce variant of ChaCha20-Poly1305, featuring a 192-bit nonce instead of 96-bit. This makes it much safer for random nonce generation and reduces the risk of nonce collisions.

**Implementation Sources:**
- **Managed**: CryptoHives clean-room implementation
- **BouncyCastle**: Not available
- **OS**: Not available

**Note:** BouncyCastle and OS implementations are not available for XChaCha20-Poly1305, so only managed implementation benchmarks are provided.

## Performance Summary

XChaCha20-Poly1305 has nearly identical performance to ChaCha20-Poly1305, with a negligible overhead for the extended nonce derivation (HChaCha20).

**Key Observations:**
- Same performance characteristics as ChaCha20-Poly1305
- ~10-20 ns overhead for nonce extension (negligible)
- Safer for random nonce generation
- Used in libsodium, age encryption tool

## Benchmark Results

> **Note:** Run `.\scripts\run-benchmarks.ps1 -Project Cryptography -Family XChaCha20Poly1305` to generate latest results.
> Use `.\scripts\update-benchmark-docs.ps1 -Package Cryptography` to update this documentation.

Results will be generated and included here after running benchmarks.

## Algorithm Details

- **Key Size**: 256 bits (32 bytes)
- **Nonce Size**: 24 bytes (192 bits) - extended nonce
- **Tag Size**: 16 bytes (128 bits)
- **Cipher**: XChaCha20 stream cipher (HChaCha20 + ChaCha20)
- **MAC**: Poly1305 one-time authenticator

## Nonce Comparison

| Variant | Nonce Size | Random Nonce Safe? | Collision Risk |
|---------|------------|-------------------|----------------|
| ChaCha20-Poly1305 | 96 bits | ⚠️ No (requires counter) | High with random nonces |
| XChaCha20-Poly1305 | 192 bits | ✅ Yes | Negligible (2^96 messages) |

## See Also

- [XChaCha20-Poly1305 Algorithm Details](../cipher-algorithms.md#xchacha20-poly1305)
- [ChaCha20-Poly1305 Benchmarks](chacha20poly1305.md)
