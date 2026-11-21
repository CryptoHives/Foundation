| Description                             | TestDataSize | Mean         | Error     | StdDev    | Allocated |
|---------------------------------------- |------------- |-------------:|----------:|----------:|----------:|
| Decrypt · SEED-CBC (CryptoHives-Scalar) | 128B         |     1.297 μs | 0.0066 μs | 0.0061 μs |         - |
| Decrypt · SEED-CBC (BouncyCastle)       | 128B         |     1.363 μs | 0.0046 μs | 0.0043 μs |     152 B |
|                                         |              |              |           |           |           |
| Encrypt · SEED-CBC (CryptoHives-Scalar) | 128B         |     1.360 μs | 0.0068 μs | 0.0063 μs |         - |
| Encrypt · SEED-CBC (BouncyCastle)       | 128B         |     1.409 μs | 0.0056 μs | 0.0052 μs |     152 B |
|                                         |              |              |           |           |           |
| Decrypt · SEED-CBC (CryptoHives-Scalar) | 1KB          |     9.155 μs | 0.0565 μs | 0.0528 μs |         - |
| Decrypt · SEED-CBC (BouncyCastle)       | 1KB          |     9.313 μs | 0.0459 μs | 0.0429 μs |     152 B |
|                                         |              |              |           |           |           |
| Encrypt · SEED-CBC (CryptoHives-Scalar) | 1KB          |     9.749 μs | 0.0398 μs | 0.0372 μs |         - |
| Encrypt · SEED-CBC (BouncyCastle)       | 1KB          |     9.827 μs | 0.0563 μs | 0.0526 μs |     152 B |
|                                         |              |              |           |           |           |
| Decrypt · SEED-CBC (CryptoHives-Scalar) | 8KB          |    72.169 μs | 0.5080 μs | 0.4752 μs |         - |
| Decrypt · SEED-CBC (BouncyCastle)       | 8KB          |    72.702 μs | 0.4342 μs | 0.4061 μs |     152 B |
|                                         |              |              |           |           |           |
| Encrypt · SEED-CBC (CryptoHives-Scalar) | 8KB          |    76.914 μs | 0.5035 μs | 0.4709 μs |         - |
| Encrypt · SEED-CBC (BouncyCastle)       | 8KB          |    77.182 μs | 0.4824 μs | 0.4513 μs |     152 B |
|                                         |              |              |           |           |           |
| Decrypt · SEED-CBC (CryptoHives-Scalar) | 128KB        | 1,148.848 μs | 2.8638 μs | 2.2359 μs |         - |
| Decrypt · SEED-CBC (BouncyCastle)       | 128KB        | 1,163.782 μs | 5.8364 μs | 5.4594 μs |     152 B |
|                                         |              |              |           |           |           |
| Encrypt · SEED-CBC (CryptoHives-Scalar) | 128KB        | 1,228.065 μs | 3.7437 μs | 3.3186 μs |         - |
| Encrypt · SEED-CBC (BouncyCastle)       | 128KB        | 1,232.280 μs | 5.7832 μs | 5.4096 μs |     152 B |