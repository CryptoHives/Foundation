| Description                                 | TestDataSize | Mean         | Error      | StdDev     | Code Size | Allocated |
|-------------------------------------------- |------------- |-------------:|-----------:|-----------:|----------:|----------:|
| Decrypt · ARIA-256-CCM (CryptoHives-Scalar) | 128B         |     4.797 μs |  0.0138 μs |  0.0122 μs |  25,626 B |         - |
| Decrypt · ARIA-256-CCM (BouncyCastle)       | 128B         |     7.302 μs |  0.0144 μs |  0.0113 μs |     306 B |    3848 B |
|                                             |              |              |            |            |           |           |
| Encrypt · ARIA-256-CCM (CryptoHives-Scalar) | 128B         |     4.888 μs |  0.0263 μs |  0.0246 μs |  26,441 B |         - |
| Encrypt · ARIA-256-CCM (BouncyCastle)       | 128B         |     7.406 μs |  0.0508 μs |  0.0450 μs |     386 B |    3696 B |
|                                             |              |              |            |            |           |           |
| Decrypt · ARIA-256-CCM (CryptoHives-Scalar) | 1KB          |    32.731 μs |  0.1585 μs |  0.1323 μs |  24,976 B |         - |
| Decrypt · ARIA-256-CCM (BouncyCastle)       | 1KB          |    43.312 μs |  0.0659 μs |  0.0550 μs |     306 B |    9224 B |
|                                             |              |              |            |            |           |           |
| Encrypt · ARIA-256-CCM (CryptoHives-Scalar) | 1KB          |    31.604 μs |  0.3559 μs |  0.3329 μs |  28,030 B |         - |
| Encrypt · ARIA-256-CCM (BouncyCastle)       | 1KB          |    43.903 μs |  0.2461 μs |  0.2182 μs |     386 B |    8176 B |
|                                             |              |              |            |            |           |           |
| Decrypt · ARIA-256-CCM (CryptoHives-Scalar) | 8KB          |   249.819 μs |  0.9575 μs |  0.8488 μs |  25,362 B |         - |
| Decrypt · ARIA-256-CCM (BouncyCastle)       | 8KB          |   332.471 μs |  0.5453 μs |  0.4834 μs |     306 B |   52232 B |
|                                             |              |              |            |            |           |           |
| Encrypt · ARIA-256-CCM (CryptoHives-Scalar) | 8KB          |   248.416 μs |  2.5904 μs |  2.4231 μs |  26,579 B |         - |
| Encrypt · ARIA-256-CCM (BouncyCastle)       | 8KB          |   335.808 μs |  3.4104 μs |  3.1901 μs |     386 B |   44016 B |
|                                             |              |              |            |            |           |           |
| Decrypt · ARIA-256-CCM (CryptoHives-Scalar) | 128KB        | 3,881.593 μs | 19.2786 μs | 18.0332 μs |  24,848 B |         - |
| Decrypt · ARIA-256-CCM (BouncyCastle)       | 128KB        | 5,381.533 μs | 26.9638 μs | 22.5160 μs |     306 B |  789563 B |
|                                             |              |              |            |            |           |           |
| Encrypt · ARIA-256-CCM (CryptoHives-Scalar) | 128KB        | 3,956.701 μs | 62.6362 μs | 58.5899 μs |  26,673 B |         - |
| Encrypt · ARIA-256-CCM (BouncyCastle)       | 128KB        | 5,365.520 μs | 45.4580 μs | 42.5215 μs |     386 B |  658416 B |