| Description                                 | TestDataSize | Mean         | Error     | StdDev    | Allocated |
|-------------------------------------------- |------------- |-------------:|----------:|----------:|----------:|
| Decrypt · ARIA-256-CBC (CryptoHives-Scalar) | 128B         |     1.931 μs | 0.0051 μs | 0.0046 μs |         - |
| Decrypt · ARIA-256-CBC (BouncyCastle)       | 128B         |     3.331 μs | 0.0047 μs | 0.0042 μs |    1496 B |
|                                             |              |              |           |           |           |
| Encrypt · ARIA-256-CBC (CryptoHives-Scalar) | 128B         |     1.925 μs | 0.0027 μs | 0.0024 μs |         - |
| Encrypt · ARIA-256-CBC (BouncyCastle)       | 128B         |     3.118 μs | 0.0083 μs | 0.0065 μs |    1496 B |
|                                             |              |              |           |           |           |
| Decrypt · ARIA-256-CBC (CryptoHives-Scalar) | 1KB          |    13.850 μs | 0.0372 μs | 0.0330 μs |         - |
| Decrypt · ARIA-256-CBC (BouncyCastle)       | 1KB          |    20.354 μs | 0.0779 μs | 0.0650 μs |    3736 B |
|                                             |              |              |           |           |           |
| Encrypt · ARIA-256-CBC (CryptoHives-Scalar) | 1KB          |    13.877 μs | 0.0237 μs | 0.0198 μs |         - |
| Encrypt · ARIA-256-CBC (BouncyCastle)       | 1KB          |    20.349 μs | 0.0390 μs | 0.0346 μs |    3736 B |
|                                             |              |              |           |           |           |
| Decrypt · ARIA-256-CBC (CryptoHives-Scalar) | 8KB          |   108.874 μs | 0.2079 μs | 0.1843 μs |         - |
| Decrypt · ARIA-256-CBC (BouncyCastle)       | 8KB          |   156.986 μs | 0.4342 μs | 0.3849 μs |   21656 B |
|                                             |              |              |           |           |           |
| Encrypt · ARIA-256-CBC (CryptoHives-Scalar) | 8KB          |   108.869 μs | 0.3092 μs | 0.2414 μs |         - |
| Encrypt · ARIA-256-CBC (BouncyCastle)       | 8KB          |   159.121 μs | 0.2537 μs | 0.2249 μs |   21656 B |
|                                             |              |              |           |           |           |
| Decrypt · ARIA-256-CBC (CryptoHives-Scalar) | 128KB        | 1,744.593 μs | 4.7876 μs | 4.4783 μs |         - |
| Decrypt · ARIA-256-CBC (BouncyCastle)       | 128KB        | 2,493.428 μs | 4.1157 μs | 3.6484 μs |  328856 B |
|                                             |              |              |           |           |           |
| Encrypt · ARIA-256-CBC (CryptoHives-Scalar) | 128KB        | 1,742.158 μs | 5.4415 μs | 5.0900 μs |         - |
| Encrypt · ARIA-256-CBC (BouncyCastle)       | 128KB        | 2,540.042 μs | 3.8058 μs | 3.3737 μs |  328856 B |