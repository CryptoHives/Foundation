# AES-128-GCM Benchmarks

## Overview

AES-128-GCM (Galois/Counter Mode) is a widely-deployed authenticated encryption algorithm that combines AES-128 block cipher with GMAC authentication.

**Implementation Sources:**
- **Managed**: CryptoHives clean-room implementation
- **BouncyCastle**: BouncyCastle GcmBlockCipher wrapper
- **OS**: .NET System.Security.Cryptography.AesGcm (.NET 8+)

## Performance Summary

The OS implementation leverages **AES-NI hardware instructions** for AES operations and **PCLMULQDQ** for GMAC, providing significant performance advantages on modern CPUs. The managed implementation is a pure software fallback.

**Key Observations:**
- OS implementation is fastest when AES-NI is available
- BouncyCastle and Managed implementations have similar performance
- All implementations scale linearly with message size

## Benchmark Results

> **Note:** Run `.\scripts\run-benchmarks.ps1 -Project Cryptography -Family AesGcm128` to generate latest results.
> Use `.\scripts\update-benchmark-docs.ps1 -Package Cryptography` to update this documentation.

Results will be generated and included here after running benchmarks.

## Algorithm Details

- **Key Size**: 128 bits (16 bytes)
- **Nonce Size**: 12 bytes (recommended), variable supported
- **Tag Size**: 16 bytes (128 bits)
- **Block Size**: 16 bytes

## See Also

- [AES-GCM Algorithm Details](../cipher-algorithms.md#aes-gcm-galoiscounter-mode)
- [AES-256-GCM Benchmarks](aesgcm256.md)
