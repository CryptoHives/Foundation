| Description                                 | TestDataSize | Mean        | Error     | StdDev    | Code Size | Allocated |
|-------------------------------------------- |------------- |------------:|----------:|----------:|----------:|----------:|
| Decrypt · ARIA-256-CCM (CryptoHives-Scalar) | 128B         |    10.73 μs |  0.009 μs |  0.008 μs |  14,355 B |         - |
| Decrypt · ARIA-256-CCM (BouncyCastle)       | 128B         |    14.14 μs |  0.027 μs |  0.025 μs |     310 B |    3880 B |
|                                             |              |             |           |           |           |           |
| Encrypt · ARIA-256-CCM (CryptoHives-Scalar) | 128B         |    10.64 μs |  0.007 μs |  0.006 μs |  14,408 B |         - |
| Encrypt · ARIA-256-CCM (BouncyCastle)       | 128B         |    14.03 μs |  0.024 μs |  0.022 μs |     387 B |    3768 B |
|                                             |              |             |           |           |           |           |
| Decrypt · ARIA-256-CCM (CryptoHives-Scalar) | 1KB          |    69.68 μs |  0.055 μs |  0.052 μs |  14,362 B |         - |
| Decrypt · ARIA-256-CCM (BouncyCastle)       | 1KB          |    79.12 μs |  0.096 μs |  0.080 μs |     310 B |    9256 B |
|                                             |              |             |           |           |           |           |
| Encrypt · ARIA-256-CCM (CryptoHives-Scalar) | 1KB          |    69.65 μs |  0.063 μs |  0.053 μs |  14,418 B |         - |
| Encrypt · ARIA-256-CCM (BouncyCastle)       | 1KB          |    80.87 μs |  0.098 μs |  0.082 μs |     387 B |    8248 B |
|                                             |              |             |           |           |           |           |
| Decrypt · ARIA-256-CCM (CryptoHives-Scalar) | 8KB          |   540.97 μs |  0.953 μs |  0.845 μs |  14,369 B |         - |
| Decrypt · ARIA-256-CCM (BouncyCastle)       | 8KB          |   602.87 μs |  1.019 μs |  0.795 μs |     310 B |   52264 B |
|                                             |              |             |           |           |           |           |
| Encrypt · ARIA-256-CCM (CryptoHives-Scalar) | 8KB          |   540.69 μs |  0.292 μs |  0.259 μs |  14,422 B |         - |
| Encrypt · ARIA-256-CCM (BouncyCastle)       | 8KB          |   598.29 μs |  1.122 μs |  1.049 μs |     387 B |   44088 B |
|                                             |              |             |           |           |           |           |
| Decrypt · ARIA-256-CCM (CryptoHives-Scalar) | 128KB        | 8,630.67 μs | 14.980 μs | 14.013 μs |  14,366 B |         - |
| Decrypt · ARIA-256-CCM (BouncyCastle)       | 128KB        | 9,641.49 μs | 14.475 μs | 12.831 μs |     310 B |  789554 B |
|                                             |              |             |           |           |           |           |
| Encrypt · ARIA-256-CCM (CryptoHives-Scalar) | 128KB        | 8,639.81 μs | 10.648 μs |  8.892 μs |  14,419 B |         - |
| Encrypt · ARIA-256-CCM (BouncyCastle)       | 128KB        | 9,525.20 μs | 15.125 μs | 14.148 μs |     387 B |  658488 B |