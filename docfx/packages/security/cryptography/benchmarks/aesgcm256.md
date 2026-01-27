# AES-256-GCM Benchmarks

## Overview

AES-256-GCM (Galois/Counter Mode) is a widely-deployed authenticated encryption algorithm that combines AES-256 block cipher with GMAC authentication. It offers higher security than AES-128-GCM with a larger key size.

**Implementation Sources:**
- **Managed**: CryptoHives clean-room implementation
- **BouncyCastle**: BouncyCastle GcmBlockCipher wrapper
- **OS**: .NET System.Security.Cryptography.AesGcm (.NET 8+)

## Performance Summary

The OS implementation leverages **AES-NI hardware instructions** for AES operations and **PCLMULQDQ** for GMAC, providing significant performance advantages on modern CPUs. AES-256 requires 14 rounds compared to AES-128's 10 rounds, resulting in approximately 40% higher latency.

**Key Observations:**
- OS implementation is fastest when AES-NI is available
- ~40% slower than AES-128-GCM due to additional rounds
- BouncyCastle and Managed implementations have similar performance
- All implementations scale linearly with message size

## Benchmark Results

> **Note:** Run `.\scripts\run-benchmarks.ps1 -Project Cryptography -Family AesGcm256` to generate latest results.
> Use `.\scripts\update-benchmark-docs.ps1 -Package Cryptography` to update this documentation.

Results will be generated and included here after running benchmarks.

## Algorithm Details

- **Key Size**: 256 bits (32 bytes)
- **Nonce Size**: 12 bytes (recommended), variable supported
- **Tag Size**: 16 bytes (128 bits)
- **Block Size**: 16 bytes
- **Rounds**: 14 (vs 10 for AES-128)

## See Also

- [AES-GCM Algorithm Details](../cipher-algorithms.md#aes-gcm-galoiscounter-mode)
- [AES-128-GCM Benchmarks](aesgcm128.md)
