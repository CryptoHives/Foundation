| Description                             | TestDataSize | Mean         | Error     | StdDev    | Allocated |
|---------------------------------------- |------------- |-------------:|----------:|----------:|----------:|
| Decrypt · SEED-CBC (CryptoHives-Scalar) | 128B         |     1.179 μs | 0.0034 μs | 0.0028 μs |         - |
| Decrypt · SEED-CBC (BouncyCastle)       | 128B         |     1.313 μs | 0.0028 μs | 0.0023 μs |     152 B |
|                                         |              |              |           |           |           |
| Encrypt · SEED-CBC (CryptoHives-Scalar) | 128B         |     1.185 μs | 0.0017 μs | 0.0014 μs |         - |
| Encrypt · SEED-CBC (BouncyCastle)       | 128B         |     1.312 μs | 0.0034 μs | 0.0032 μs |     152 B |
|                                         |              |              |           |           |           |
| Decrypt · SEED-CBC (CryptoHives-Scalar) | 1KB          |     8.389 μs | 0.0230 μs | 0.0215 μs |         - |
| Decrypt · SEED-CBC (BouncyCastle)       | 1KB          |     8.904 μs | 0.0311 μs | 0.0291 μs |     152 B |
|                                         |              |              |           |           |           |
| Encrypt · SEED-CBC (CryptoHives-Scalar) | 1KB          |     8.454 μs | 0.0224 μs | 0.0198 μs |         - |
| Encrypt · SEED-CBC (BouncyCastle)       | 1KB          |     8.916 μs | 0.0128 μs | 0.0107 μs |     152 B |
|                                         |              |              |           |           |           |
| Decrypt · SEED-CBC (CryptoHives-Scalar) | 8KB          |    66.100 μs | 0.1383 μs | 0.1294 μs |         - |
| Decrypt · SEED-CBC (BouncyCastle)       | 8KB          |    69.301 μs | 0.2633 μs | 0.2463 μs |     152 B |
|                                         |              |              |           |           |           |
| Encrypt · SEED-CBC (CryptoHives-Scalar) | 8KB          |    66.690 μs | 0.0951 μs | 0.0843 μs |         - |
| Encrypt · SEED-CBC (BouncyCastle)       | 8KB          |    69.750 μs | 0.0757 μs | 0.0632 μs |     152 B |
|                                         |              |              |           |           |           |
| Decrypt · SEED-CBC (CryptoHives-Scalar) | 128KB        | 1,095.500 μs | 3.4800 μs | 3.2552 μs |         - |
| Decrypt · SEED-CBC (BouncyCastle)       | 128KB        | 1,110.392 μs | 5.7750 μs | 5.4019 μs |     152 B |
|                                         |              |              |           |           |           |
| Encrypt · SEED-CBC (CryptoHives-Scalar) | 128KB        | 1,096.398 μs | 0.9642 μs | 0.8051 μs |         - |
| Encrypt · SEED-CBC (BouncyCastle)       | 128KB        | 1,123.612 μs | 5.8304 μs | 5.4538 μs |     152 B |