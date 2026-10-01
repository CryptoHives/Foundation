| Description                             | TestDataSize | Mean         | Error     | StdDev    | Allocated |
|---------------------------------------- |------------- |-------------:|----------:|----------:|----------:|
| Decrypt · SEED-CBC (CryptoHives-Scalar) | 128B         |     1.412 μs | 0.0029 μs | 0.0025 μs |         - |
| Decrypt · SEED-CBC (BouncyCastle)       | 128B         |     1.491 μs | 0.0030 μs | 0.0028 μs |     152 B |
|                                         |              |              |           |           |           |
| Encrypt · SEED-CBC (CryptoHives-Scalar) | 128B         |     1.461 μs | 0.0024 μs | 0.0020 μs |         - |
| Encrypt · SEED-CBC (BouncyCastle)       | 128B         |     1.524 μs | 0.0032 μs | 0.0028 μs |     152 B |
|                                         |              |              |           |           |           |
| Decrypt · SEED-CBC (CryptoHives-Scalar) | 1KB          |    10.057 μs | 0.0241 μs | 0.0213 μs |         - |
| Decrypt · SEED-CBC (BouncyCastle)       | 1KB          |    10.296 μs | 0.0360 μs | 0.0337 μs |     152 B |
|                                         |              |              |           |           |           |
| Encrypt · SEED-CBC (CryptoHives-Scalar) | 1KB          |    10.613 μs | 0.0285 μs | 0.0267 μs |         - |
| Encrypt · SEED-CBC (BouncyCastle)       | 1KB          |    10.647 μs | 0.0287 μs | 0.0269 μs |     152 B |
|                                         |              |              |           |           |           |
| Decrypt · SEED-CBC (CryptoHives-Scalar) | 8KB          |    79.138 μs | 0.1072 μs | 0.1003 μs |         - |
| Decrypt · SEED-CBC (BouncyCastle)       | 8KB          |    80.410 μs | 0.2309 μs | 0.2047 μs |     152 B |
|                                         |              |              |           |           |           |
| Encrypt · SEED-CBC (BouncyCastle)       | 8KB          |    83.584 μs | 0.1970 μs | 0.1843 μs |     152 B |
| Encrypt · SEED-CBC (CryptoHives-Scalar) | 8KB          |    83.716 μs | 0.1975 μs | 0.1750 μs |         - |
|                                         |              |              |           |           |           |
| Decrypt · SEED-CBC (CryptoHives-Scalar) | 128KB        | 1,265.941 μs | 3.3448 μs | 3.1287 μs |         - |
| Decrypt · SEED-CBC (BouncyCastle)       | 128KB        | 1,282.575 μs | 3.5402 μs | 3.3115 μs |     152 B |
|                                         |              |              |           |           |           |
| Encrypt · SEED-CBC (BouncyCastle)       | 128KB        | 1,333.633 μs | 3.4018 μs | 3.0156 μs |     152 B |
| Encrypt · SEED-CBC (CryptoHives-Scalar) | 128KB        | 1,337.417 μs | 3.0895 μs | 2.8899 μs |         - |