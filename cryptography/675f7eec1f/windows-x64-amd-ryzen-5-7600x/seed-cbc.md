| Description                             | TestDataSize | Mean         | Error     | StdDev    | Allocated |
|---------------------------------------- |------------- |-------------:|----------:|----------:|----------:|
| Decrypt · SEED-CBC (CryptoHives-Scalar) | 128B         |     1.168 μs | 0.0032 μs | 0.0030 μs |         - |
| Decrypt · SEED-CBC (BouncyCastle)       | 128B         |     1.304 μs | 0.0045 μs | 0.0042 μs |     152 B |
|                                         |              |              |           |           |           |
| Encrypt · SEED-CBC (CryptoHives-Scalar) | 128B         |     1.176 μs | 0.0038 μs | 0.0036 μs |         - |
| Encrypt · SEED-CBC (BouncyCastle)       | 128B         |     1.298 μs | 0.0038 μs | 0.0034 μs |     152 B |
|                                         |              |              |           |           |           |
| Decrypt · SEED-CBC (CryptoHives-Scalar) | 1KB          |     8.336 μs | 0.0238 μs | 0.0211 μs |         - |
| Decrypt · SEED-CBC (BouncyCastle)       | 1KB          |     8.808 μs | 0.0344 μs | 0.0322 μs |     152 B |
|                                         |              |              |           |           |           |
| Encrypt · SEED-CBC (CryptoHives-Scalar) | 1KB          |     8.408 μs | 0.0307 μs | 0.0256 μs |         - |
| Encrypt · SEED-CBC (BouncyCastle)       | 1KB          |     8.873 μs | 0.0256 μs | 0.0239 μs |     152 B |
|                                         |              |              |           |           |           |
| Decrypt · SEED-CBC (CryptoHives-Scalar) | 8KB          |    65.509 μs | 0.1330 μs | 0.1111 μs |         - |
| Decrypt · SEED-CBC (BouncyCastle)       | 8KB          |    68.891 μs | 0.1653 μs | 0.1465 μs |     152 B |
|                                         |              |              |           |           |           |
| Encrypt · SEED-CBC (CryptoHives-Scalar) | 8KB          |    66.305 μs | 0.2063 μs | 0.1930 μs |         - |
| Encrypt · SEED-CBC (BouncyCastle)       | 8KB          |    69.323 μs | 0.2241 μs | 0.1872 μs |     152 B |
|                                         |              |              |           |           |           |
| Decrypt · SEED-CBC (CryptoHives-Scalar) | 128KB        | 1,047.105 μs | 2.4171 μs | 2.0184 μs |         - |
| Decrypt · SEED-CBC (BouncyCastle)       | 128KB        | 1,101.155 μs | 6.6899 μs | 6.2577 μs |     152 B |
|                                         |              |              |           |           |           |
| Encrypt · SEED-CBC (CryptoHives-Scalar) | 128KB        | 1,057.977 μs | 2.9596 μs | 2.6236 μs |         - |
| Encrypt · SEED-CBC (BouncyCastle)       | 128KB        | 1,112.708 μs | 4.5128 μs | 4.0005 μs |     152 B |