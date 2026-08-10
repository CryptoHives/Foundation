| Description                             | TestDataSize | Mean         | Error     | StdDev    | Allocated |
|---------------------------------------- |------------- |-------------:|----------:|----------:|----------:|
| Decrypt · SEED-CBC (CryptoHives-Scalar) | 128B         |     1.172 μs | 0.0011 μs | 0.0010 μs |         - |
| Decrypt · SEED-CBC (BouncyCastle)       | 128B         |     1.301 μs | 0.0015 μs | 0.0014 μs |     152 B |
|                                         |              |              |           |           |           |
| Encrypt · SEED-CBC (CryptoHives-Scalar) | 128B         |     1.172 μs | 0.0033 μs | 0.0031 μs |         - |
| Encrypt · SEED-CBC (BouncyCastle)       | 128B         |     1.299 μs | 0.0018 μs | 0.0015 μs |     152 B |
|                                         |              |              |           |           |           |
| Decrypt · SEED-CBC (CryptoHives-Scalar) | 1KB          |     8.297 μs | 0.0105 μs | 0.0082 μs |         - |
| Decrypt · SEED-CBC (BouncyCastle)       | 1KB          |     8.775 μs | 0.0155 μs | 0.0138 μs |     152 B |
|                                         |              |              |           |           |           |
| Encrypt · SEED-CBC (CryptoHives-Scalar) | 1KB          |     8.391 μs | 0.0244 μs | 0.0216 μs |         - |
| Encrypt · SEED-CBC (BouncyCastle)       | 1KB          |     8.839 μs | 0.0168 μs | 0.0149 μs |     152 B |
|                                         |              |              |           |           |           |
| Decrypt · SEED-CBC (CryptoHives-Scalar) | 8KB          |    65.332 μs | 0.0791 μs | 0.0740 μs |         - |
| Decrypt · SEED-CBC (BouncyCastle)       | 8KB          |    68.672 μs | 0.1475 μs | 0.1379 μs |     152 B |
|                                         |              |              |           |           |           |
| Encrypt · SEED-CBC (CryptoHives-Scalar) | 8KB          |    66.188 μs | 0.1036 μs | 0.0969 μs |         - |
| Encrypt · SEED-CBC (BouncyCastle)       | 8KB          |    69.140 μs | 0.0993 μs | 0.0880 μs |     152 B |
|                                         |              |              |           |           |           |
| Decrypt · SEED-CBC (CryptoHives-Scalar) | 128KB        | 1,044.445 μs | 1.3474 μs | 1.2603 μs |         - |
| Decrypt · SEED-CBC (BouncyCastle)       | 128KB        | 1,108.726 μs | 3.9076 μs | 3.6552 μs |     152 B |
|                                         |              |              |           |           |           |
| Encrypt · SEED-CBC (CryptoHives-Scalar) | 128KB        | 1,053.903 μs | 1.2117 μs | 1.0742 μs |         - |
| Encrypt · SEED-CBC (BouncyCastle)       | 128KB        | 1,107.289 μs | 3.6531 μs | 3.4171 μs |     152 B |