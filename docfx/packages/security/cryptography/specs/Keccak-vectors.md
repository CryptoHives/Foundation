# Keccak Test Vectors

## Overview

Keccak is the original hash function family before it was standardized as SHA-3.
The key difference is the padding: Keccak uses `0x01` while SHA-3 uses `0x06`.

Keccak-256 is primarily used in Ethereum for:
- Address generation
- Transaction hashing
- Merkle tree nodes
- Smart contract function selectors

## Test Vectors

### Keccak-256

#### Empty String

| Input | Output (Hex) |
|-------|--------------|
| "" | `c5d2460186f7233c927e7db2dcc703c0e500b653ca82273b7bfad8045d85a470` |

#### Standard Test Messages

| Input | Output (Hex) |
|-------|--------------|
| "abc" | `4e03657aea45a94fc7d47ba826c8d667c0d1e6e33a64a036ec44f58fa12d6c45` |
| "testing" | `5f16f4c7f149ac4f9510d9cf8cf384038ad348b3bcdc01915f95de12df9d1b02` |
| "The quick brown fox jumps over the lazy dog" | `4d741b6f1eb29cb2a9b9911c82f56fa8d73b04959d3d9d222895df6c0b28aa15` |

### Keccak-384

#### Empty String

| Input | Output (Hex) |
|-------|--------------|
| "" | `2c23146a63a29acf99e73b88f8c24eaa7dc60aa771780ccc006afbfa8fe2479b2dd2b21362337441ac12b515911957ff` |

#### Standard Test Messages

| Input | Output (Hex) |
|-------|--------------|
| "abc" | `f7df1165f033337be098e7d288ad6a2f74409d7a60b49c36642218de161b1f99f8c681e4afaf31a34db29fb763e3c28e` |
| "The quick brown fox jumps over the lazy dog" | `283990fa9d5fb731d786c5bbee94ea4db4910f18c62c03d173fc0a5e494422e8a0b3da7574dae7fa0baf005e504063b3` |

### Keccak-512

#### Empty String

| Input | Output (Hex) |
|-------|--------------|
| "" | `0eab42de4c3ceb9235fc91acffe746b29c29a8c366b7c60e4e67c466f36a4304c00fa9caf9d87976ba469bcbe06713b435f091ef2769fb160cdab33d3670680e` |

#### Standard Test Messages

| Input | Output (Hex) |
|-------|--------------|
| "abc" | `18587dc2ea106b9a1563e32b3312421ca164c7f1f07bc922a9c83d77cea3a1e5d0c69910739025372dc14ac9642629379540c17e2a65b19d77aa511a9d00bb96` |
| "The quick brown fox jumps over the lazy dog" | `d135bb84d0439dbac432247ee573a23ea7d3c9deb2a968eb31d47c4fb45f1ef4422d6c531b5b9bd6f449ebcc449ea94d0a8f05f62130fda612da53c79659f609` |

## Comparison: Keccak vs SHA-3

| Input | Keccak-256 | SHA3-256 |
|-------|------------|----------|
| "test" | `9c22ff5f21f0b81b113e63f7db6da94fedef11b2119b4088b89664fb9a3cb658` | `36f028580bb02cc8272a9a020f4200e346e276ae664e45ee80745574e2f5ab80` |

The outputs differ due to different domain separation padding bytes.

## References

- Ethereum Yellow Paper: https://ethereum.github.io/yellowpaper/paper.pdf
- Keccak Team: https://keccak.team/
- BouncyCastle KeccakDigest: Used as reference implementation
