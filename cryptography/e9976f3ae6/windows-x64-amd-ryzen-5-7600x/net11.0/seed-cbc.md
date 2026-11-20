| Description                             | TestDataSize | Mean         | Error     | StdDev    | Code Size | Allocated |
|---------------------------------------- |------------- |-------------:|----------:|----------:|----------:|----------:|
| Decrypt · SEED-CBC (CryptoHives-Scalar) | 128B         |     1.348 μs | 0.0028 μs | 0.0025 μs |  10,522 B |         - |
| Decrypt · SEED-CBC (BouncyCastle)       | 128B         |     1.461 μs | 0.0041 μs | 0.0037 μs |  13,878 B |     152 B |
|                                         |              |              |           |           |           |           |
| Encrypt · SEED-CBC (CryptoHives-Scalar) | 128B         |     1.374 μs | 0.0020 μs | 0.0018 μs |  10,332 B |         - |
| Encrypt · SEED-CBC (BouncyCastle)       | 128B         |     1.455 μs | 0.0035 μs | 0.0031 μs |   7,734 B |     152 B |
|                                         |              |              |           |           |           |           |
| Decrypt · SEED-CBC (CryptoHives-Scalar) | 1KB          |     9.633 μs | 0.0434 μs | 0.0406 μs |   3,997 B |         - |
| Decrypt · SEED-CBC (BouncyCastle)       | 1KB          |    10.017 μs | 0.0258 μs | 0.0229 μs |  13,688 B |     152 B |
|                                         |              |              |           |           |           |           |
| Encrypt · SEED-CBC (CryptoHives-Scalar) | 1KB          |     9.839 μs | 0.0321 μs | 0.0285 μs |   3,997 B |         - |
| Encrypt · SEED-CBC (BouncyCastle)       | 1KB          |    10.009 μs | 0.0228 μs | 0.0214 μs |  13,697 B |     152 B |
|                                         |              |              |           |           |           |           |
| Decrypt · SEED-CBC (CryptoHives-Scalar) | 8KB          |    76.699 μs | 0.0749 μs | 0.0700 μs |  10,332 B |         - |
| Decrypt · SEED-CBC (BouncyCastle)       | 8KB          |    77.743 μs | 0.1354 μs | 0.1267 μs |  13,697 B |     152 B |
|                                         |              |              |           |           |           |           |
| Encrypt · SEED-CBC (CryptoHives-Scalar) | 8KB          |    77.153 μs | 0.3200 μs | 0.2994 μs |  10,522 B |         - |
| Encrypt · SEED-CBC (BouncyCastle)       | 8KB          |    78.526 μs | 0.3594 μs | 0.3002 μs |  13,883 B |     152 B |
|                                         |              |              |           |           |           |           |
| Decrypt · SEED-CBC (CryptoHives-Scalar) | 128KB        | 1,208.638 μs | 3.8281 μs | 3.5808 μs |  10,332 B |         - |
| Decrypt · SEED-CBC (BouncyCastle)       | 128KB        | 1,238.996 μs | 2.2031 μs | 1.9530 μs |  13,697 B |     152 B |
|                                         |              |              |           |           |           |           |
| Encrypt · SEED-CBC (CryptoHives-Scalar) | 128KB        | 1,231.404 μs | 2.6667 μs | 2.4944 μs |  10,343 B |         - |
| Encrypt · SEED-CBC (BouncyCastle)       | 128KB        | 1,272.038 μs | 2.4741 μs | 2.3142 μs |  13,883 B |     152 B |