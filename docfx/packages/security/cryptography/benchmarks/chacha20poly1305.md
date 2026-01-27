# ChaCha20-Poly1305 Benchmarks

## Overview

ChaCha20-Poly1305 is an authenticated encryption algorithm combining the ChaCha20 stream cipher with Poly1305 MAC. It's designed as a software-friendly alternative to AES-GCM, offering excellent performance without requiring hardware acceleration.

**Implementation Sources:**
- **Managed**: CryptoHives clean-room implementation
- **BouncyCastle**: BouncyCastle ChaCha20Poly1305 wrapper
- **OS**: .NET System.Security.Cryptography.ChaCha20Poly1305 (.NET 9+)

## Performance Summary

ChaCha20-Poly1305 excels on platforms without AES-NI hardware acceleration. It's the preferred cipher for mobile devices, embedded systems, and software-only environments.

**Key Observations:**
- Consistently fast across all platforms (no hardware dependency)
- Competitive with AES-GCM on systems without AES-NI
- Faster than AES-GCM on ARM and older x86 CPUs
- Used in TLS 1.3, WireGuard VPN, SSH

## Benchmark Results

> **Note:** Run `.\scripts\run-benchmarks.ps1 -Project Cryptography -Family ChaCha20Poly1305` to generate latest results.
> Use `.\scripts\update-benchmark-docs.ps1 -Package Cryptography` to update this documentation.

Results will be generated and included here after running benchmarks.

## Algorithm Details

- **Key Size**: 256 bits (32 bytes)
- **Nonce Size**: 12 bytes (96 bits)
- **Tag Size**: 16 bytes (128 bits)
- **Cipher**: ChaCha20 stream cipher (20 rounds)
- **MAC**: Poly1305 one-time authenticator

## See Also

- [ChaCha20-Poly1305 Algorithm Details](../cipher-algorithms.md#chacha20-poly1305)
- [XChaCha20-Poly1305 Benchmarks](xchacha20poly1305.md)
