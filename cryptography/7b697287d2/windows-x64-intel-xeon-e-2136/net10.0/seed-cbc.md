| Description                             | TestDataSize | Mean         | Error     | StdDev    | Code Size | Allocated |
|---------------------------------------- |------------- |-------------:|----------:|----------:|----------:|----------:|
| Decrypt · SEED-CBC (CryptoHives-Scalar) | 128B         |     2.196 μs | 0.0027 μs | 0.0024 μs |   1,311 B |         - |
| Decrypt · SEED-CBC (BouncyCastle)       | 128B         |     2.385 μs | 0.0039 μs | 0.0034 μs |   2,935 B |     152 B |
|                                         |              |              |           |           |           |           |
| Encrypt · SEED-CBC (CryptoHives-Scalar) | 128B         |     2.226 μs | 0.0016 μs | 0.0014 μs |   1,307 B |         - |
| Encrypt · SEED-CBC (BouncyCastle)       | 128B         |     2.344 μs | 0.0033 μs | 0.0031 μs |   2,921 B |     152 B |
|                                         |              |              |           |           |           |           |
| Decrypt · SEED-CBC (CryptoHives-Scalar) | 1KB          |    15.243 μs | 0.0132 μs | 0.0123 μs |   1,311 B |         - |
| Decrypt · SEED-CBC (BouncyCastle)       | 1KB          |    15.629 μs | 0.0235 μs | 0.0220 μs |   2,935 B |     152 B |
|                                         |              |              |           |           |           |           |
| Encrypt · SEED-CBC (CryptoHives-Scalar) | 1KB          |    15.397 μs | 0.0210 μs | 0.0186 μs |   1,307 B |         - |
| Encrypt · SEED-CBC (BouncyCastle)       | 1KB          |    15.445 μs | 0.0243 μs | 0.0228 μs |   2,933 B |     152 B |
|                                         |              |              |           |           |           |           |
| Decrypt · SEED-CBC (CryptoHives-Scalar) | 8KB          |   119.062 μs | 0.2215 μs | 0.2072 μs |   1,311 B |         - |
| Decrypt · SEED-CBC (BouncyCastle)       | 8KB          |   121.748 μs | 0.1835 μs | 0.1716 μs |   2,933 B |     152 B |
|                                         |              |              |           |           |           |           |
| Encrypt · SEED-CBC (CryptoHives-Scalar) | 8KB          |   120.548 μs | 0.0457 μs | 0.0428 μs |   1,305 B |         - |
| Encrypt · SEED-CBC (BouncyCastle)       | 8KB          |   120.799 μs | 0.0835 μs | 0.0652 μs |   2,933 B |     152 B |
|                                         |              |              |           |           |           |           |
| Decrypt · SEED-CBC (CryptoHives-Scalar) | 128KB        | 1,899.543 μs | 3.2567 μs | 3.0463 μs |   1,311 B |         - |
| Decrypt · SEED-CBC (BouncyCastle)       | 128KB        | 1,939.562 μs | 1.5363 μs | 1.2829 μs |   2,933 B |     152 B |
|                                         |              |              |           |           |           |           |
| Encrypt · SEED-CBC (CryptoHives-Scalar) | 128KB        | 1,924.115 μs | 0.9971 μs | 0.9327 μs |   1,305 B |         - |
| Encrypt · SEED-CBC (BouncyCastle)       | 128KB        | 1,925.616 μs | 1.3058 μs | 1.2214 μs |   2,933 B |     152 B |