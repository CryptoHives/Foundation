| Description                                 | TestDataSize | Mean         | Error     | StdDev    | Allocated |
|-------------------------------------------- |------------- |-------------:|----------:|----------:|----------:|
| Decrypt · ARIA-256-CBC (CryptoHives-Scalar) | 128B         |     1.234 μs | 0.0006 μs | 0.0006 μs |         - |
| Decrypt · ARIA-256-CBC (BouncyCastle)       | 128B         |     2.966 μs | 0.0028 μs | 0.0024 μs |    1496 B |
|                                             |              |              |           |           |           |
| Encrypt · ARIA-256-CBC (CryptoHives-Scalar) | 128B         |     1.221 μs | 0.0008 μs | 0.0007 μs |         - |
| Encrypt · ARIA-256-CBC (BouncyCastle)       | 128B         |     2.915 μs | 0.0034 μs | 0.0032 μs |    1496 B |
|                                             |              |              |           |           |           |
| Decrypt · ARIA-256-CBC (CryptoHives-Scalar) | 1KB          |     8.818 μs | 0.0019 μs | 0.0017 μs |         - |
| Decrypt · ARIA-256-CBC (BouncyCastle)       | 1KB          |    18.559 μs | 0.0307 μs | 0.0287 μs |    3736 B |
|                                             |              |              |           |           |           |
| Encrypt · ARIA-256-CBC (CryptoHives-Scalar) | 1KB          |     8.704 μs | 0.0054 μs | 0.0051 μs |         - |
| Encrypt · ARIA-256-CBC (BouncyCastle)       | 1KB          |    18.522 μs | 0.0221 μs | 0.0207 μs |    3736 B |
|                                             |              |              |           |           |           |
| Decrypt · ARIA-256-CBC (CryptoHives-Scalar) | 8KB          |    69.497 μs | 0.0247 μs | 0.0219 μs |         - |
| Decrypt · ARIA-256-CBC (BouncyCastle)       | 8KB          |   141.442 μs | 0.1346 μs | 0.1193 μs |   21656 B |
|                                             |              |              |           |           |           |
| Encrypt · ARIA-256-CBC (CryptoHives-Scalar) | 8KB          |    68.550 μs | 0.0193 μs | 0.0171 μs |         - |
| Encrypt · ARIA-256-CBC (BouncyCastle)       | 8KB          |   141.413 μs | 0.1987 μs | 0.1858 μs |   21656 B |
|                                             |              |              |           |           |           |
| Decrypt · ARIA-256-CBC (CryptoHives-Scalar) | 128KB        | 1,111.162 μs | 0.8023 μs | 0.7505 μs |         - |
| Decrypt · ARIA-256-CBC (BouncyCastle)       | 128KB        | 2,264.531 μs | 2.8306 μs | 2.6477 μs |  328856 B |
|                                             |              |              |           |           |           |
| Encrypt · ARIA-256-CBC (CryptoHives-Scalar) | 128KB        | 1,095.734 μs | 0.7846 μs | 0.7339 μs |         - |
| Encrypt · ARIA-256-CBC (BouncyCastle)       | 128KB        | 2,245.190 μs | 2.6259 μs | 2.3278 μs |  328856 B |