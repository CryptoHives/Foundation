| Description                             | TestDataSize | Mean         | Error     | StdDev    | Allocated |
|---------------------------------------- |------------- |-------------:|----------:|----------:|----------:|
| Decrypt · SEED-CBC (CryptoHives-Scalar) | 128B         |     1.351 μs | 0.0022 μs | 0.0021 μs |         - |
| Decrypt · SEED-CBC (BouncyCastle)       | 128B         |     1.429 μs | 0.0042 μs | 0.0039 μs |     152 B |
|                                         |              |              |           |           |           |
| Encrypt · SEED-CBC (CryptoHives-Scalar) | 128B         |     1.396 μs | 0.0040 μs | 0.0037 μs |         - |
| Encrypt · SEED-CBC (BouncyCastle)       | 128B         |     1.462 μs | 0.0046 μs | 0.0043 μs |     152 B |
|                                         |              |              |           |           |           |
| Decrypt · SEED-CBC (CryptoHives-Scalar) | 1KB          |     9.615 μs | 0.0341 μs | 0.0319 μs |         - |
| Decrypt · SEED-CBC (BouncyCastle)       | 1KB          |     9.828 μs | 0.0226 μs | 0.0201 μs |     152 B |
|                                         |              |              |           |           |           |
| Encrypt · SEED-CBC (CryptoHives-Scalar) | 1KB          |    10.059 μs | 0.0292 μs | 0.0273 μs |         - |
| Encrypt · SEED-CBC (BouncyCastle)       | 1KB          |    10.188 μs | 0.0437 μs | 0.0408 μs |     152 B |
|                                         |              |              |           |           |           |
| Decrypt · SEED-CBC (CryptoHives-Scalar) | 8KB          |    75.615 μs | 0.1927 μs | 0.1803 μs |         - |
| Decrypt · SEED-CBC (BouncyCastle)       | 8KB          |    76.879 μs | 0.2183 μs | 0.2042 μs |     152 B |
|                                         |              |              |           |           |           |
| Encrypt · SEED-CBC (CryptoHives-Scalar) | 8KB          |    79.385 μs | 0.2414 μs | 0.2258 μs |         - |
| Encrypt · SEED-CBC (BouncyCastle)       | 8KB          |    80.066 μs | 0.3611 μs | 0.3378 μs |     152 B |
|                                         |              |              |           |           |           |
| Decrypt · SEED-CBC (CryptoHives-Scalar) | 128KB        | 1,208.888 μs | 3.6126 μs | 3.3792 μs |         - |
| Decrypt · SEED-CBC (BouncyCastle)       | 128KB        | 1,228.906 μs | 5.4685 μs | 5.1153 μs |     152 B |
|                                         |              |              |           |           |           |
| Encrypt · SEED-CBC (CryptoHives-Scalar) | 128KB        | 1,268.079 μs | 4.5537 μs | 4.2596 μs |         - |
| Encrypt · SEED-CBC (BouncyCastle)       | 128KB        | 1,276.503 μs | 3.3576 μs | 3.1407 μs |     152 B |