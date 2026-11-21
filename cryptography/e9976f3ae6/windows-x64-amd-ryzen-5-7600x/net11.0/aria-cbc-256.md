| Description                                 | TestDataSize | Mean         | Error      | StdDev     | Code Size | Allocated |
|-------------------------------------------- |------------- |-------------:|-----------:|-----------:|----------:|----------:|
| Decrypt · ARIA-256-CBC (CryptoHives-Scalar) | 128B         |     2.256 μs |  0.0312 μs |  0.0292 μs |  10,332 B |         - |
| Decrypt · ARIA-256-CBC (BouncyCastle)       | 128B         |     3.494 μs |  0.0406 μs |  0.0360 μs |   7,731 B |    1416 B |
|                                             |              |              |            |            |           |           |
| Encrypt · ARIA-256-CBC (CryptoHives-Scalar) | 128B         |     2.243 μs |  0.0276 μs |  0.0258 μs |  10,522 B |         - |
| Encrypt · ARIA-256-CBC (BouncyCastle)       | 128B         |     3.282 μs |  0.0386 μs |  0.0361 μs |  13,690 B |    1416 B |
|                                             |              |              |            |            |           |           |
| Decrypt · ARIA-256-CBC (CryptoHives-Scalar) | 1KB          |    16.084 μs |  0.2292 μs |  0.2144 μs |  10,332 B |         - |
| Decrypt · ARIA-256-CBC (BouncyCastle)       | 1KB          |    21.669 μs |  0.1845 μs |  0.1726 μs |   7,736 B |    3656 B |
|                                             |              |              |            |            |           |           |
| Encrypt · ARIA-256-CBC (CryptoHives-Scalar) | 1KB          |    16.152 μs |  0.2224 μs |  0.2080 μs |  10,332 B |         - |
| Encrypt · ARIA-256-CBC (BouncyCastle)       | 1KB          |    21.426 μs |  0.2460 μs |  0.2301 μs |   7,740 B |    3656 B |
|                                             |              |              |            |            |           |           |
| Decrypt · ARIA-256-CBC (CryptoHives-Scalar) | 8KB          |   126.772 μs |  1.0351 μs |  0.9176 μs |   3,997 B |         - |
| Decrypt · ARIA-256-CBC (BouncyCastle)       | 8KB          |   163.040 μs |  1.8504 μs |  1.7309 μs |  13,885 B |   21576 B |
|                                             |              |              |            |            |           |           |
| Encrypt · ARIA-256-CBC (CryptoHives-Scalar) | 8KB          |   126.255 μs |  1.2869 μs |  1.2037 μs |  10,332 B |         - |
| Encrypt · ARIA-256-CBC (BouncyCastle)       | 8KB          |   167.842 μs |  1.4001 μs |  1.3096 μs |  13,695 B |   21576 B |
|                                             |              |              |            |            |           |           |
| Decrypt · ARIA-256-CBC (CryptoHives-Scalar) | 128KB        | 2,028.919 μs | 34.1463 μs | 31.9405 μs |  10,522 B |         - |
| Decrypt · ARIA-256-CBC (BouncyCastle)       | 128KB        | 2,675.654 μs | 24.5709 μs | 22.9837 μs |  13,885 B |  328776 B |
|                                             |              |              |            |            |           |           |
| Encrypt · ARIA-256-CBC (CryptoHives-Scalar) | 128KB        | 2,018.921 μs | 27.0843 μs | 25.3346 μs |  10,522 B |         - |
| Encrypt · ARIA-256-CBC (BouncyCastle)       | 128KB        | 2,686.316 μs | 24.3747 μs | 21.6075 μs |  13,695 B |  328776 B |