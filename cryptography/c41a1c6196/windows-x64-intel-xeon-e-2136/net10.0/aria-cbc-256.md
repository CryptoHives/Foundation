| Description                                 | TestDataSize | Mean         | Error      | StdDev     | Code Size | Allocated |
|-------------------------------------------- |------------- |-------------:|-----------:|-----------:|----------:|----------:|
| Decrypt · ARIA-256-CBC (CryptoHives-Scalar) | 128B         |     5.022 μs |  0.0299 μs |  0.0280 μs |   1,311 B |         - |
| Decrypt · ARIA-256-CBC (BouncyCastle)       | 128B         |     6.335 μs |  0.0192 μs |  0.0170 μs |   2,927 B |    1416 B |
|                                             |              |              |            |            |           |           |
| Encrypt · ARIA-256-CBC (CryptoHives-Scalar) | 128B         |     5.084 μs |  0.0150 μs |  0.0133 μs |   1,307 B |         - |
| Encrypt · ARIA-256-CBC (BouncyCastle)       | 128B         |     5.976 μs |  0.0221 μs |  0.0207 μs |   2,913 B |    1416 B |
|                                             |              |              |            |            |           |           |
| Decrypt · ARIA-256-CBC (CryptoHives-Scalar) | 1KB          |    35.457 μs |  0.1436 μs |  0.1273 μs |   1,311 B |         - |
| Decrypt · ARIA-256-CBC (BouncyCastle)       | 1KB          |    37.673 μs |  0.0713 μs |  0.0667 μs |   2,927 B |    3656 B |
|                                             |              |              |            |            |           |           |
| Encrypt · ARIA-256-CBC (CryptoHives-Scalar) | 1KB          |    35.989 μs |  0.0755 μs |  0.0630 μs |   1,307 B |         - |
| Encrypt · ARIA-256-CBC (BouncyCastle)       | 1KB          |    36.400 μs |  0.0817 μs |  0.0765 μs |   2,929 B |    3656 B |
|                                             |              |              |            |            |           |           |
| Decrypt · ARIA-256-CBC (CryptoHives-Scalar) | 8KB          |   279.161 μs |  1.3142 μs |  1.2293 μs |   1,311 B |         - |
| Decrypt · ARIA-256-CBC (BouncyCastle)       | 8KB          |   291.320 μs |  0.6701 μs |  0.5941 μs |   2,929 B |   21576 B |
|                                             |              |              |            |            |           |           |
| Encrypt · ARIA-256-CBC (CryptoHives-Scalar) | 8KB          |   283.006 μs |  0.5991 μs |  0.5604 μs |   1,305 B |         - |
| Encrypt · ARIA-256-CBC (BouncyCastle)       | 8KB          |   287.590 μs |  1.0443 μs |  0.9768 μs |   2,929 B |   21576 B |
|                                             |              |              |            |            |           |           |
| Decrypt · ARIA-256-CBC (CryptoHives-Scalar) | 128KB        | 4,441.833 μs | 10.6667 μs |  8.9072 μs |   1,311 B |         - |
| Decrypt · ARIA-256-CBC (BouncyCastle)       | 128KB        | 4,674.556 μs | 18.5010 μs | 17.3058 μs |   2,929 B |  328776 B |
|                                             |              |              |            |            |           |           |
| Encrypt · ARIA-256-CBC (CryptoHives-Scalar) | 128KB        | 4,517.734 μs | 13.4943 μs | 11.9624 μs |   1,305 B |         - |
| Encrypt · ARIA-256-CBC (BouncyCastle)       | 128KB        | 4,605.276 μs | 22.3844 μs | 20.9384 μs |   2,927 B |  328776 B |