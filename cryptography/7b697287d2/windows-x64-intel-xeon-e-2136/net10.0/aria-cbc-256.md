| Description                                 | TestDataSize | Mean         | Error      | StdDev    | Code Size | Allocated |
|-------------------------------------------- |------------- |-------------:|-----------:|----------:|----------:|----------:|
| Decrypt · ARIA-256-CBC (CryptoHives-Scalar) | 128B         |     4.986 μs |  0.0049 μs | 0.0038 μs |   1,311 B |         - |
| Decrypt · ARIA-256-CBC (BouncyCastle)       | 128B         |     6.371 μs |  0.0088 μs | 0.0083 μs |   2,927 B |    1416 B |
|                                             |              |              |            |           |           |           |
| Encrypt · ARIA-256-CBC (CryptoHives-Scalar) | 128B         |     5.058 μs |  0.0069 μs | 0.0061 μs |   1,307 B |         - |
| Encrypt · ARIA-256-CBC (BouncyCastle)       | 128B         |     5.951 μs |  0.0086 μs | 0.0076 μs |   2,925 B |    1416 B |
|                                             |              |              |            |           |           |           |
| Decrypt · ARIA-256-CBC (CryptoHives-Scalar) | 1KB          |    35.278 μs |  0.0607 μs | 0.0568 μs |   1,311 B |         - |
| Decrypt · ARIA-256-CBC (BouncyCastle)       | 1KB          |    37.463 μs |  0.0387 μs | 0.0343 μs |   2,927 B |    3656 B |
|                                             |              |              |            |           |           |           |
| Encrypt · ARIA-256-CBC (CryptoHives-Scalar) | 1KB          |    35.883 μs |  0.0496 μs | 0.0463 μs |   1,307 B |         - |
| Encrypt · ARIA-256-CBC (BouncyCastle)       | 1KB          |    36.374 μs |  0.0654 μs | 0.0611 μs |   2,929 B |    3656 B |
|                                             |              |              |            |           |           |           |
| Decrypt · ARIA-256-CBC (CryptoHives-Scalar) | 8KB          |   277.615 μs |  0.5148 μs | 0.4816 μs |   1,311 B |         - |
| Decrypt · ARIA-256-CBC (BouncyCastle)       | 8KB          |   290.291 μs |  0.5688 μs | 0.5320 μs |   2,929 B |   21576 B |
|                                             |              |              |            |           |           |           |
| Encrypt · ARIA-256-CBC (CryptoHives-Scalar) | 8KB          |   282.120 μs |  0.4942 μs | 0.4127 μs |   1,305 B |         - |
| Encrypt · ARIA-256-CBC (BouncyCastle)       | 8KB          |   291.353 μs |  0.4633 μs | 0.3869 μs |   2,929 B |   21576 B |
|                                             |              |              |            |           |           |           |
| Decrypt · ARIA-256-CBC (CryptoHives-Scalar) | 128KB        | 4,431.797 μs |  7.7931 μs | 7.2897 μs |   1,311 B |         - |
| Decrypt · ARIA-256-CBC (BouncyCastle)       | 128KB        | 4,604.796 μs |  5.2388 μs | 4.6440 μs |   2,927 B |  328776 B |
|                                             |              |              |            |           |           |           |
| Encrypt · ARIA-256-CBC (CryptoHives-Scalar) | 128KB        | 4,502.064 μs |  6.8544 μs | 6.0762 μs |   1,305 B |         - |
| Encrypt · ARIA-256-CBC (BouncyCastle)       | 128KB        | 4,656.049 μs | 10.2141 μs | 9.5543 μs |   2,927 B |  328776 B |