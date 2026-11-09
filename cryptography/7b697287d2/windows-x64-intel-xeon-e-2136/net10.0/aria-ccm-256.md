| Description                                 | TestDataSize | Mean         | Error      | StdDev     | Code Size | Allocated |
|-------------------------------------------- |------------- |-------------:|-----------:|-----------:|----------:|----------:|
| Decrypt · ARIA-256-CCM (CryptoHives-Scalar) | 128B         |     7.936 μs |  0.0252 μs |  0.0224 μs |  14,355 B |         - |
| Decrypt · ARIA-256-CCM (BouncyCastle)       | 128B         |    10.455 μs |  0.0222 μs |  0.0197 μs |     310 B |    3880 B |
|                                             |              |              |            |            |           |           |
| Encrypt · ARIA-256-CCM (CryptoHives-Scalar) | 128B         |     7.874 μs |  0.0227 μs |  0.0201 μs |  14,408 B |         - |
| Encrypt · ARIA-256-CCM (BouncyCastle)       | 128B         |    10.231 μs |  0.0223 μs |  0.0208 μs |     387 B |    3768 B |
|                                             |              |              |            |            |           |           |
| Decrypt · ARIA-256-CCM (CryptoHives-Scalar) | 1KB          |    51.527 μs |  0.0823 μs |  0.0770 μs |  14,365 B |         - |
| Decrypt · ARIA-256-CCM (BouncyCastle)       | 1KB          |    59.106 μs |  0.0953 μs |  0.0845 μs |     310 B |    9256 B |
|                                             |              |              |            |            |           |           |
| Encrypt · ARIA-256-CCM (CryptoHives-Scalar) | 1KB          |    51.462 μs |  0.1463 μs |  0.1368 μs |  14,408 B |         - |
| Encrypt · ARIA-256-CCM (BouncyCastle)       | 1KB          |    57.969 μs |  0.1131 μs |  0.1058 μs |     387 B |    8248 B |
|                                             |              |              |            |            |           |           |
| Decrypt · ARIA-256-CCM (CryptoHives-Scalar) | 8KB          |   400.821 μs |  0.5486 μs |  0.4581 μs |  14,366 B |         - |
| Decrypt · ARIA-256-CCM (BouncyCastle)       | 8KB          |   442.468 μs |  3.4189 μs |  2.8549 μs |     310 B |   52264 B |
|                                             |              |              |            |            |           |           |
| Encrypt · ARIA-256-CCM (CryptoHives-Scalar) | 8KB          |   399.130 μs |  0.6975 μs |  0.6183 μs |  14,419 B |         - |
| Encrypt · ARIA-256-CCM (BouncyCastle)       | 8KB          |   441.350 μs |  0.7743 μs |  0.7243 μs |     387 B |   44088 B |
|                                             |              |              |            |            |           |           |
| Decrypt · ARIA-256-CCM (CryptoHives-Scalar) | 128KB        | 6,372.874 μs |  8.0267 μs |  6.7027 μs |  14,366 B |         - |
| Decrypt · ARIA-256-CCM (BouncyCastle)       | 128KB        | 7,112.052 μs | 11.8105 μs | 10.4697 μs |     310 B |  789557 B |
|                                             |              |              |            |            |           |           |
| Encrypt · ARIA-256-CCM (CryptoHives-Scalar) | 128KB        | 6,367.814 μs | 12.1261 μs | 10.7495 μs |  14,419 B |         - |
| Encrypt · ARIA-256-CCM (BouncyCastle)       | 128KB        | 7,049.176 μs | 11.0670 μs | 10.3521 μs |     387 B |  658488 B |