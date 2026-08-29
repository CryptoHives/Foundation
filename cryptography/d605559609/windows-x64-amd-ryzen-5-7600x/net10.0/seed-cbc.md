| Description                             | TestDataSize | Mean         | Error     | StdDev    | Allocated |
|---------------------------------------- |------------- |-------------:|----------:|----------:|----------:|
| Decrypt · SEED-CBC (CryptoHives-Scalar) | 128B         |     1.196 μs | 0.0049 μs | 0.0043 μs |         - |
| Decrypt · SEED-CBC (BouncyCastle)       | 128B         |     1.308 μs | 0.0107 μs | 0.0089 μs |     152 B |
|                                         |              |              |           |           |           |
| Encrypt · SEED-CBC (CryptoHives-Scalar) | 128B         |     1.175 μs | 0.0028 μs | 0.0025 μs |         - |
| Encrypt · SEED-CBC (BouncyCastle)       | 128B         |     1.302 μs | 0.0040 μs | 0.0036 μs |     152 B |
|                                         |              |              |           |           |           |
| Decrypt · SEED-CBC (CryptoHives-Scalar) | 1KB          |     8.323 μs | 0.0265 μs | 0.0248 μs |         - |
| Decrypt · SEED-CBC (BouncyCastle)       | 1KB          |     8.833 μs | 0.0421 μs | 0.0394 μs |     152 B |
|                                         |              |              |           |           |           |
| Encrypt · SEED-CBC (CryptoHives-Scalar) | 1KB          |     8.414 μs | 0.0285 μs | 0.0252 μs |         - |
| Encrypt · SEED-CBC (BouncyCastle)       | 1KB          |     8.925 μs | 0.1175 μs | 0.1099 μs |     152 B |
|                                         |              |              |           |           |           |
| Decrypt · SEED-CBC (CryptoHives-Scalar) | 8KB          |    65.557 μs | 0.1686 μs | 0.1577 μs |         - |
| Decrypt · SEED-CBC (BouncyCastle)       | 8KB          |    80.063 μs | 0.1799 μs | 0.1503 μs |     152 B |
|                                         |              |              |           |           |           |
| Encrypt · SEED-CBC (CryptoHives-Scalar) | 8KB          |    66.226 μs | 0.1693 μs | 0.1501 μs |         - |
| Encrypt · SEED-CBC (BouncyCastle)       | 8KB          |    69.653 μs | 0.2872 μs | 0.2687 μs |     152 B |
|                                         |              |              |           |           |           |
| Decrypt · SEED-CBC (CryptoHives-Scalar) | 128KB        | 1,046.354 μs | 3.0707 μs | 2.8724 μs |         - |
| Decrypt · SEED-CBC (BouncyCastle)       | 128KB        | 1,103.033 μs | 7.3120 μs | 6.8397 μs |     152 B |
|                                         |              |              |           |           |           |
| Encrypt · SEED-CBC (CryptoHives-Scalar) | 128KB        | 1,077.540 μs | 3.2561 μs | 3.0457 μs |         - |
| Encrypt · SEED-CBC (BouncyCastle)       | 128KB        | 1,106.730 μs | 4.2697 μs | 3.9938 μs |     152 B |