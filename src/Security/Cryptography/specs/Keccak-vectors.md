# Keccak-256 Test Vectors

## Overview

Keccak-256 is the original Keccak hash function before it was standardized as SHA-3.
The key difference is the padding: Keccak uses `0x01` while SHA-3 uses `0x06`.

Keccak-256 is primarily used in Ethereum for:
- Address generation
- Transaction hashing
- Merkle tree nodes
- Smart contract function selectors

## Test Vectors

### Empty String

| Input | Output (Hex) |
|-------|--------------|
| "" | `c5d2460186f7233c927e7db2dcc703c0e500b653ca82273b7bfad8045d85a470` |

### Standard Test Messages

| Input | Output (Hex) |
|-------|--------------|
| "abc" | `4e03657aea45a94fc7d47ba826c8d667c0d1e6e33a64a036ec44f58fa12d6c45` |
| "testing" | `5f16f4c7f149ac4f9510d9cf8cf384038ad348b3bcdc01915f95de12df9d1b02` |
| "The quick brown fox jumps over the lazy dog" | `4d741b6f1eb29cb2a9b9911c82f56fa8d73b04959d3d9d222895df6c0b28aa15` |

## Comparison: Keccak-256 vs SHA3-256

| Input | Keccak-256 | SHA3-256 |
|-------|------------|----------|
| "test" | `9c22ff5f21f0b81b113e63f7db6da94fedef11b2119b4088b89664fb9a3cb658` | `36f028580bb02cc8272a9a020f4200e346e276ae664e45ee80745574e2f5ab80` |

The outputs differ due to different domain separation padding bytes.

## References

- Ethereum Yellow Paper: https://ethereum.github.io/yellowpaper/paper.pdf
- Keccak Team: https://keccak.team/
- BouncyCastle KeccakDigest: Used as reference implementation
