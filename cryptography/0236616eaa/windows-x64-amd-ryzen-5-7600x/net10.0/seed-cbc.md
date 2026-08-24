| Description                             | TestDataSize | Mean         | Error     | StdDev    | Allocated |
|---------------------------------------- |------------- |-------------:|----------:|----------:|----------:|
| Decrypt · SEED-CBC (CryptoHives-Scalar) | 128B         |     1.160 μs | 0.0028 μs | 0.0023 μs |         - |
| Decrypt · SEED-CBC (BouncyCastle)       | 128B         |     1.299 μs | 0.0012 μs | 0.0009 μs |     152 B |
|                                         |              |              |           |           |           |
| Encrypt · SEED-CBC (CryptoHives-Scalar) | 128B         |     1.170 μs | 0.0037 μs | 0.0033 μs |         - |
| Encrypt · SEED-CBC (BouncyCastle)       | 128B         |     1.294 μs | 0.0025 μs | 0.0023 μs |     152 B |
|                                         |              |              |           |           |           |
| Decrypt · SEED-CBC (CryptoHives-Scalar) | 1KB          |     8.284 μs | 0.0122 μs | 0.0108 μs |         - |
| Decrypt · SEED-CBC (BouncyCastle)       | 1KB          |     8.781 μs | 0.0191 μs | 0.0169 μs |     152 B |
|                                         |              |              |           |           |           |
| Encrypt · SEED-CBC (CryptoHives-Scalar) | 1KB          |     8.507 μs | 0.0150 μs | 0.0133 μs |         - |
| Encrypt · SEED-CBC (BouncyCastle)       | 1KB          |     8.806 μs | 0.0094 μs | 0.0078 μs |     152 B |
|                                         |              |              |           |           |           |
| Decrypt · SEED-CBC (CryptoHives-Scalar) | 8KB          |    65.424 μs | 0.1770 μs | 0.1569 μs |         - |
| Decrypt · SEED-CBC (BouncyCastle)       | 8KB          |    68.493 μs | 0.1006 μs | 0.0785 μs |     152 B |
|                                         |              |              |           |           |           |
| Encrypt · SEED-CBC (CryptoHives-Scalar) | 8KB          |    65.820 μs | 0.1363 μs | 0.1208 μs |         - |
| Encrypt · SEED-CBC (BouncyCastle)       | 8KB          |    69.215 μs | 0.1111 μs | 0.0985 μs |     152 B |
|                                         |              |              |           |           |           |
| Decrypt · SEED-CBC (CryptoHives-Scalar) | 128KB        | 1,050.209 μs | 1.2872 μs | 1.0749 μs |         - |
| Decrypt · SEED-CBC (BouncyCastle)       | 128KB        | 1,097.329 μs | 6.8704 μs | 6.4266 μs |     152 B |
|                                         |              |              |           |           |           |
| Encrypt · SEED-CBC (CryptoHives-Scalar) | 128KB        | 1,094.041 μs | 1.9977 μs | 1.8687 μs |         - |
| Encrypt · SEED-CBC (BouncyCastle)       | 128KB        | 1,107.380 μs | 5.2554 μs | 4.9159 μs |     152 B |