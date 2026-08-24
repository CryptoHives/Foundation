| Description                             | TestDataSize | Mean         | Error     | StdDev    | Allocated |
|---------------------------------------- |------------- |-------------:|----------:|----------:|----------:|
| Decrypt · SEED-CBC (CryptoHives-Scalar) | 128B         |     1.387 μs | 0.0004 μs | 0.0003 μs |         - |
| Decrypt · SEED-CBC (BouncyCastle)       | 128B         |     1.464 μs | 0.0004 μs | 0.0004 μs |     152 B |
|                                         |              |              |           |           |           |
| Encrypt · SEED-CBC (CryptoHives-Scalar) | 128B         |     1.434 μs | 0.0006 μs | 0.0006 μs |         - |
| Encrypt · SEED-CBC (BouncyCastle)       | 128B         |     1.496 μs | 0.0029 μs | 0.0022 μs |     152 B |
|                                         |              |              |           |           |           |
| Decrypt · SEED-CBC (CryptoHives-Scalar) | 1KB          |     9.877 μs | 0.0025 μs | 0.0022 μs |         - |
| Decrypt · SEED-CBC (BouncyCastle)       | 1KB          |    10.087 μs | 0.0049 μs | 0.0046 μs |     152 B |
|                                         |              |              |           |           |           |
| Encrypt · SEED-CBC (CryptoHives-Scalar) | 1KB          |    10.382 μs | 0.0111 μs | 0.0104 μs |         - |
| Encrypt · SEED-CBC (BouncyCastle)       | 1KB          |    10.444 μs | 0.0037 μs | 0.0033 μs |     152 B |
|                                         |              |              |           |           |           |
| Decrypt · SEED-CBC (CryptoHives-Scalar) | 8KB          |    77.694 μs | 0.0191 μs | 0.0170 μs |         - |
| Decrypt · SEED-CBC (BouncyCastle)       | 8KB          |    78.891 μs | 0.0145 μs | 0.0129 μs |     152 B |
|                                         |              |              |           |           |           |
| Encrypt · SEED-CBC (BouncyCastle)       | 8KB          |    81.986 μs | 0.0499 μs | 0.0467 μs |     152 B |
| Encrypt · SEED-CBC (CryptoHives-Scalar) | 8KB          |    82.922 μs | 1.1447 μs | 1.0147 μs |         - |
|                                         |              |              |           |           |           |
| Decrypt · SEED-CBC (CryptoHives-Scalar) | 128KB        | 1,242.179 μs | 0.4079 μs | 0.3407 μs |         - |
| Decrypt · SEED-CBC (BouncyCastle)       | 128KB        | 1,258.501 μs | 0.3728 μs | 0.3487 μs |     152 B |
|                                         |              |              |           |           |           |
| Encrypt · SEED-CBC (BouncyCastle)       | 128KB        | 1,310.251 μs | 0.2892 μs | 0.2563 μs |     152 B |
| Encrypt · SEED-CBC (CryptoHives-Scalar) | 128KB        | 1,310.979 μs | 0.9402 μs | 0.8795 μs |         - |