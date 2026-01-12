# Streebog (GOST R 34.11-2012) Test Vectors

## Overview

Streebog is the Russian national cryptographic hash standard defined in
GOST R 34.11-2012. It supports two output sizes: 256-bit and 512-bit.

## Specification

- **Standard:** GOST R 34.11-2012 (Russia), RFC 6986
- **Output Sizes:** 256 bits or 512 bits
- **Block Size:** 512 bits (64 bytes)
- **Rounds:** 12
- **State Size:** 512 bits (64 bytes)

## Official Reference

- GOST R 34.11-2012
- RFC 6986: "GOST R 34.11-2012: Hash Function"
- https://tc26.ru/ (Technical Committee for Standardization)

## Test Vectors

### Streebog-512

#### Vector 1: Message M1 (32 bytes)

```
Input (hex): 323130393837363534333231303938373635343332313039383736353433323130393837363534333231303938373635343332313039383736353433323130
(ASCII: "012345678901234567890123456789012345678901234567890123456789012")
Length: 63 bytes

Output: 1b54d01a4af5b9d5cc3d86d68d285462b19abc2475222f35c085122be4ba1ffa
        00ad30f8767b3a82384c6574f024c311e2a481332b08ef7f41797891c1646f48
```

#### Vector 2: Message M2 (72 bytes)

```
Input (hex): fbe2e5f0eee3c820fbeafaebef20fffbf0e1e0f0f520e0ed20e8ece0ebe5f0f2f120fff0eeec20f120faf2fee5e2202ce8f6f3ede220e8e6eee1e8f0f2d1202ce8f0f2e5e220e5d1
Length: 72 bytes

Output: 28fbc9bada033b1460642bdcddb90c3fb3e56c497ccd0f62b8a2ad4935e85f03
        7613966de4ee00531ae60f3b5a47f8dae06915d5f2f194996fcabf2622f6e00561b47db2d2e11
```

#### Vector 3: Empty string

```
Input:  "" (empty)
Length: 0 bytes

Output (Streebog-512):
8e945da209aa869f0455928529bcae4679e9873ab707b55315f56ceb98bef0a7
362f715528356ee83cda5f2aac4c6ad2ba3a715c1bcd81cb8e9f90bf4c1c1a8a
```

### Streebog-256

#### Vector 1: Message M1

```
Input (hex): 323130393837363534333231303938373635343332313039383736353433323130393837363534333231303938373635343332313039383736353433323130
Length: 63 bytes

Output: 9d151eefd8590b89daa6ba6cb74af9275dd051026bb149a452fd84e5e57b5500
```

#### Vector 2: Message M2

```
Input (hex): fbe2e5f0eee3c820fbeafaebef20fffbf0e1e0f0f520e0ed20e8ece0ebe5f0f2f120fff0eeec20f120faf2fee5e2202ce8f6f3ede220e8e6eee1e8f0f2d1202ce8f0f2e5e220e5d1
Length: 72 bytes

Output: 9dd2fe4e90409e5da87f53976d7405b0c0cac628fc669a741d50063c557e8f50
```

#### Vector 3: Empty string

```
Input:  "" (empty)
Length: 0 bytes

Output (Streebog-256):
3f539a213e97c802cc229d474c6aa32a825a360b2a933a949fd925208d9ce1bb
```

## Algorithm Details

### Initial Vector (IV)

```
Streebog-512: IV = 0x00 repeated 64 times
Streebog-256: IV = 0x01 repeated 64 times
```

### Compression Function g_N

The compression function uses:
- **LPS transform:** L(P(S(x))) - Linear, Permutation, Substitution
- **Key schedule:** 12 iterations
- **Miyaguchi-Preneel mode**

### S-box (Pi)

The S-box is a 256-byte substitution table defined in the standard.

### Permutation (Tau)

The permutation rearranges bytes in the state according to a fixed pattern.

### Linear Transform (L)

The linear transformation uses a 64×64 binary matrix over GF(2).

### Iteration Constants (C)

12 iteration constants derived from LPS transform of sequential values.

## Compliance Requirements

Streebog is required for:
- Russian government cryptographic applications
- Russian banking and financial systems (together with GOST R 34.10-2012 signatures)
- Products certified under Russian cryptography regulations

## Implementation Notes

- Uses big-endian byte order within the algorithm
- State organized as 64-byte array
- Counter N tracks message length in bits
- Checksum Sigma accumulates message blocks
- Final stage includes additional compressions with N and Sigma
