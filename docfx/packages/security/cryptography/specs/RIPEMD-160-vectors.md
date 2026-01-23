# RIPEMD-160 Test Vectors

## Overview

RIPEMD-160 is a 160-bit cryptographic hash function designed by Hans Dobbertin,
Antoon Bosselaers, and Bart Preneel. It is widely used in cryptocurrency systems,
particularly Bitcoin for address generation.

## Specification

- **Output Size:** 160 bits (20 bytes)
- **Block Size:** 512 bits (64 bytes)
- **Rounds:** 80 (5 groups of 16)
- **Word Size:** 32 bits

## Official Reference

- Original paper: "RIPEMD-160: A Strengthened Version of RIPEMD"
- https://homes.esat.kuleuven.be/~bosselae/ripemd160.html

## Test Vectors

### Vector 1: Empty string

```
Input:  "" (empty)
Length: 0 bytes
Output: 9c1185a5c5e9fc54612808977ee8f548b2258d31
```

### Vector 2: Single character "a"

```
Input:  "a"
Length: 1 byte
Hex:    61
Output: 0bdc9d2d256b3ee9daae347be6f4dc835a467ffe
```

### Vector 3: "abc"

```
Input:  "abc"
Length: 3 bytes
Hex:    616263
Output: 8eb208f7e05d987a9b044a8e98c6b087f15a0bfc
```

### Vector 4: "message digest"

```
Input:  "message digest"
Length: 14 bytes
Hex:    6d65737361676520646967657374
Output: 5d0689ef49d2fae572b881b123a85ffa21595f36
```

### Vector 5: Lowercase alphabet

```
Input:  "abcdefghijklmnopqrstuvwxyz"
Length: 26 bytes
Output: f71c27109c692c1b56bbdceb5b9d2865b3708dbc
```

### Vector 6: Alphanumeric

```
Input:  "abcdbcdecdefdefgefghfghighijhijkijkljklmklmnlmnomnopnopq"
Length: 56 bytes
Output: 12a053384a9c0c88e405a06c27dcf49ada62eb2b
```

### Vector 7: Full alphanumeric

```
Input:  "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789"
Length: 62 bytes
Output: b0e20b6e3116640286ed3a87a5713079b21f5189
```

### Vector 8: Repeated digits

```
Input:  "12345678901234567890123456789012345678901234567890123456789012345678901234567890"
Length: 80 bytes
Output: 9b752e45573d4b39f4dbd3323cab82bf63326bfb
```

### Vector 9: Million "a" characters

```
Input:  "a" repeated 1,000,000 times
Length: 1,000,000 bytes
Output: 52783243c1697bdbe16d37f97f68f08325dc1528
```

## Bitcoin Usage

In Bitcoin, addresses are generated using:

```
address = Base58Check(version || RIPEMD-160(SHA-256(public_key)))
```

This is often called "Hash160" in cryptocurrency contexts.

## Implementation Notes

- Uses Merkle-Damgård construction
- Two parallel lines of computation (left and right)
- Five boolean functions, one per round group
- Little-endian byte order
