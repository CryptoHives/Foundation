| Description                                 | TestDataSize | Mean         | Error     | StdDev    | Allocated |
|-------------------------------------------- |------------- |-------------:|----------:|----------:|----------:|
| Decrypt · ARIA-256-CBC (CryptoHives-Scalar) | 128B         |     1.242 μs | 0.0020 μs | 0.0017 μs |         - |
| Decrypt · ARIA-256-CBC (BouncyCastle)       | 128B         |     3.052 μs | 0.0020 μs | 0.0019 μs |    1496 B |
|                                             |              |              |           |           |           |
| Encrypt · ARIA-256-CBC (CryptoHives-Scalar) | 128B         |     1.228 μs | 0.0027 μs | 0.0026 μs |         - |
| Encrypt · ARIA-256-CBC (BouncyCastle)       | 128B         |     2.953 μs | 0.0043 μs | 0.0038 μs |    1496 B |
|                                             |              |              |           |           |           |
| Decrypt · ARIA-256-CBC (CryptoHives-Scalar) | 1KB          |     8.883 μs | 0.0073 μs | 0.0068 μs |         - |
| Decrypt · ARIA-256-CBC (BouncyCastle)       | 1KB          |    18.708 μs | 0.0587 μs | 0.0549 μs |    3736 B |
|                                             |              |              |           |           |           |
| Encrypt · ARIA-256-CBC (CryptoHives-Scalar) | 1KB          |     8.762 μs | 0.0073 μs | 0.0068 μs |         - |
| Encrypt · ARIA-256-CBC (BouncyCastle)       | 1KB          |    18.540 μs | 0.0143 μs | 0.0127 μs |    3736 B |
|                                             |              |              |           |           |           |
| Decrypt · ARIA-256-CBC (CryptoHives-Scalar) | 8KB          |    69.914 μs | 0.1446 μs | 0.1353 μs |         - |
| Decrypt · ARIA-256-CBC (BouncyCastle)       | 8KB          |   143.640 μs | 0.1616 μs | 0.1511 μs |   21656 B |
|                                             |              |              |           |           |           |
| Encrypt · ARIA-256-CBC (CryptoHives-Scalar) | 8KB          |    69.009 μs | 0.1026 μs | 0.0960 μs |         - |
| Encrypt · ARIA-256-CBC (BouncyCastle)       | 8KB          |   143.577 μs | 0.1426 μs | 0.1333 μs |   21656 B |
|                                             |              |              |           |           |           |
| Decrypt · ARIA-256-CBC (CryptoHives-Scalar) | 128KB        | 1,118.920 μs | 0.7709 μs | 0.7211 μs |         - |
| Decrypt · ARIA-256-CBC (BouncyCastle)       | 128KB        | 2,287.192 μs | 3.5879 μs | 3.3562 μs |  328856 B |
|                                             |              |              |           |           |           |
| Encrypt · ARIA-256-CBC (CryptoHives-Scalar) | 128KB        | 1,103.281 μs | 0.4138 μs | 0.3870 μs |         - |
| Encrypt · ARIA-256-CBC (BouncyCastle)       | 128KB        | 2,259.564 μs | 6.3513 μs | 5.9410 μs |  328856 B |