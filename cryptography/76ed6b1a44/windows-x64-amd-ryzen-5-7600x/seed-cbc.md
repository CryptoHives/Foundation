| Description                             | TestDataSize | Mean         | Error     | StdDev    | Allocated |
|---------------------------------------- |------------- |-------------:|----------:|----------:|----------:|
| Decrypt · SEED-CBC (CryptoHives-Scalar) | 128B         |     1.197 μs | 0.0030 μs | 0.0028 μs |         - |
| Decrypt · SEED-CBC (BouncyCastle)       | 128B         |     1.294 μs | 0.0027 μs | 0.0024 μs |     152 B |
|                                         |              |              |           |           |           |
| Encrypt · SEED-CBC (CryptoHives-Scalar) | 128B         |     1.206 μs | 0.0012 μs | 0.0011 μs |         - |
| Encrypt · SEED-CBC (BouncyCastle)       | 128B         |     1.290 μs | 0.0035 μs | 0.0033 μs |     152 B |
|                                         |              |              |           |           |           |
| Decrypt · SEED-CBC (CryptoHives-Scalar) | 1KB          |     8.563 μs | 0.0234 μs | 0.0219 μs |         - |
| Decrypt · SEED-CBC (BouncyCastle)       | 1KB          |     8.764 μs | 0.0429 μs | 0.0402 μs |     152 B |
|                                         |              |              |           |           |           |
| Encrypt · SEED-CBC (CryptoHives-Scalar) | 1KB          |     8.642 μs | 0.0170 μs | 0.0159 μs |         - |
| Encrypt · SEED-CBC (BouncyCastle)       | 1KB          |     8.814 μs | 0.0182 μs | 0.0162 μs |     152 B |
|                                         |              |              |           |           |           |
| Decrypt · SEED-CBC (CryptoHives-Scalar) | 8KB          |    67.367 μs | 0.0978 μs | 0.0867 μs |         - |
| Decrypt · SEED-CBC (BouncyCastle)       | 8KB          |    68.531 μs | 0.2005 μs | 0.1875 μs |     152 B |
|                                         |              |              |           |           |           |
| Encrypt · SEED-CBC (CryptoHives-Scalar) | 8KB          |    68.232 μs | 0.1106 μs | 0.1035 μs |         - |
| Encrypt · SEED-CBC (BouncyCastle)       | 8KB          |    69.019 μs | 0.0988 μs | 0.0876 μs |     152 B |
|                                         |              |              |           |           |           |
| Decrypt · SEED-CBC (CryptoHives-Scalar) | 128KB        | 1,075.896 μs | 2.1281 μs | 1.9907 μs |         - |
| Decrypt · SEED-CBC (BouncyCastle)       | 128KB        | 1,095.910 μs | 8.1496 μs | 7.2244 μs |     152 B |
|                                         |              |              |           |           |           |
| Encrypt · SEED-CBC (CryptoHives-Scalar) | 128KB        | 1,085.838 μs | 3.0743 μs | 2.8757 μs |         - |
| Encrypt · SEED-CBC (BouncyCastle)       | 128KB        | 1,099.553 μs | 3.1768 μs | 2.4802 μs |     152 B |