| Description                                 | TestDataSize | Mean        | Error     | StdDev    | Code Size | Allocated |
|-------------------------------------------- |------------- |------------:|----------:|----------:|----------:|----------:|
| Decrypt · ARIA-256-CCM (CryptoHives-Scalar) | 128B         |    10.75 μs |  0.012 μs |  0.011 μs |  14,355 B |         - |
| Decrypt · ARIA-256-CCM (BouncyCastle)       | 128B         |    14.02 μs |  0.017 μs |  0.016 μs |     310 B |    3880 B |
|                                             |              |             |           |           |           |           |
| Encrypt · ARIA-256-CCM (CryptoHives-Scalar) | 128B         |    10.66 μs |  0.018 μs |  0.017 μs |  14,407 B |         - |
| Encrypt · ARIA-256-CCM (BouncyCastle)       | 128B         |    13.89 μs |  0.019 μs |  0.018 μs |     387 B |    3768 B |
|                                             |              |             |           |           |           |           |
| Decrypt · ARIA-256-CCM (CryptoHives-Scalar) | 1KB          |    69.99 μs |  0.141 μs |  0.132 μs |  14,347 B |         - |
| Decrypt · ARIA-256-CCM (BouncyCastle)       | 1KB          |    78.38 μs |  0.137 μs |  0.128 μs |     310 B |    9256 B |
|                                             |              |             |           |           |           |           |
| Encrypt · ARIA-256-CCM (CryptoHives-Scalar) | 1KB          |    69.79 μs |  0.093 μs |  0.083 μs |  14,415 B |         - |
| Encrypt · ARIA-256-CCM (BouncyCastle)       | 1KB          |    78.75 μs |  0.133 μs |  0.118 μs |     387 B |    8248 B |
|                                             |              |             |           |           |           |           |
| Decrypt · ARIA-256-CCM (CryptoHives-Scalar) | 8KB          |   542.96 μs |  0.638 μs |  0.597 μs |  14,366 B |         - |
| Decrypt · ARIA-256-CCM (BouncyCastle)       | 8KB          |   605.42 μs |  1.467 μs |  1.372 μs |     310 B |   52264 B |
|                                             |              |             |           |           |           |           |
| Encrypt · ARIA-256-CCM (CryptoHives-Scalar) | 8KB          |   541.87 μs |  0.284 μs |  0.222 μs |  14,413 B |         - |
| Encrypt · ARIA-256-CCM (BouncyCastle)       | 8KB          |   592.79 μs |  1.294 μs |  1.147 μs |     387 B |   44088 B |
|                                             |              |             |           |           |           |           |
| Decrypt · ARIA-256-CCM (CryptoHives-Scalar) | 128KB        | 8,638.41 μs |  7.395 μs |  6.555 μs |  14,369 B |         - |
| Decrypt · ARIA-256-CCM (BouncyCastle)       | 128KB        | 9,556.81 μs | 12.853 μs | 12.023 μs |     310 B |  789554 B |
|                                             |              |             |           |           |           |           |
| Encrypt · ARIA-256-CCM (CryptoHives-Scalar) | 128KB        | 8,663.98 μs |  9.482 μs |  8.870 μs |  14,419 B |         - |
| Encrypt · ARIA-256-CCM (BouncyCastle)       | 128KB        | 9,548.42 μs | 25.878 μs | 24.207 μs |     387 B |  658488 B |