| Description                             | TestDataSize | Mean         | Error     | StdDev    | Allocated |
|---------------------------------------- |------------- |-------------:|----------:|----------:|----------:|
| Decrypt · SEED-CBC (CryptoHives-Scalar) | 128B         |     1.352 μs | 0.0154 μs | 0.0128 μs |         - |
| Decrypt · SEED-CBC (BouncyCastle)       | 128B         |     1.438 μs | 0.0145 μs | 0.0121 μs |     152 B |
|                                         |              |              |           |           |           |
| Encrypt · SEED-CBC (BouncyCastle)       | 128B         |     1.475 μs | 0.0066 μs | 0.0058 μs |     152 B |
| Encrypt · SEED-CBC (CryptoHives-Scalar) | 128B         |     1.493 μs | 0.0072 μs | 0.0067 μs |         - |
|                                         |              |              |           |           |           |
| Decrypt · SEED-CBC (CryptoHives-Scalar) | 1KB          |     9.553 μs | 0.0354 μs | 0.0314 μs |         - |
| Decrypt · SEED-CBC (BouncyCastle)       | 1KB          |     9.780 μs | 0.0552 μs | 0.0490 μs |     152 B |
|                                         |              |              |           |           |           |
| Encrypt · SEED-CBC (BouncyCastle)       | 1KB          |    10.390 μs | 0.1815 μs | 0.1698 μs |     152 B |
| Encrypt · SEED-CBC (CryptoHives-Scalar) | 1KB          |    11.119 μs | 0.1949 μs | 0.2733 μs |         - |
|                                         |              |              |           |           |           |
| Decrypt · SEED-CBC (CryptoHives-Scalar) | 8KB          |    74.943 μs | 0.3096 μs | 0.2896 μs |         - |
| Decrypt · SEED-CBC (BouncyCastle)       | 8KB          |    76.362 μs | 0.3769 μs | 0.3342 μs |     152 B |
|                                         |              |              |           |           |           |
| Encrypt · SEED-CBC (BouncyCastle)       | 8KB          |    80.960 μs | 1.2714 μs | 1.0617 μs |     152 B |
| Encrypt · SEED-CBC (CryptoHives-Scalar) | 8KB          |    85.853 μs | 0.4465 μs | 0.3958 μs |         - |
|                                         |              |              |           |           |           |
| Decrypt · SEED-CBC (CryptoHives-Scalar) | 128KB        | 1,192.777 μs | 8.1407 μs | 7.2165 μs |         - |
| Decrypt · SEED-CBC (BouncyCastle)       | 128KB        | 1,225.473 μs | 8.5432 μs | 7.9913 μs |     152 B |
|                                         |              |              |           |           |           |
| Encrypt · SEED-CBC (BouncyCastle)       | 128KB        | 1,286.279 μs | 4.3548 μs | 3.8605 μs |     152 B |
| Encrypt · SEED-CBC (CryptoHives-Scalar) | 128KB        | 1,368.396 μs | 9.5930 μs | 7.4896 μs |         - |