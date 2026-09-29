| Description                                 | TestDataSize | Mean         | Error      | StdDev     | Allocated |
|-------------------------------------------- |------------- |-------------:|-----------:|-----------:|----------:|
| Decrypt · ARIA-256-CBC (CryptoHives-Scalar) | 128B         |     2.219 μs |  0.0300 μs |  0.0281 μs |         - |
| Decrypt · ARIA-256-CBC (BouncyCastle)       | 128B         |     3.742 μs |  0.0381 μs |  0.0357 μs |    1416 B |
|                                             |              |              |            |            |           |
| Encrypt · ARIA-256-CBC (CryptoHives-Scalar) | 128B         |     2.220 μs |  0.0259 μs |  0.0243 μs |         - |
| Encrypt · ARIA-256-CBC (BouncyCastle)       | 128B         |     3.595 μs |  0.0277 μs |  0.0259 μs |    1416 B |
|                                             |              |              |            |            |           |
| Decrypt · ARIA-256-CBC (CryptoHives-Scalar) | 1KB          |    15.932 μs |  0.2166 μs |  0.2026 μs |         - |
| Decrypt · ARIA-256-CBC (BouncyCastle)       | 1KB          |    23.370 μs |  0.1567 μs |  0.1389 μs |    3656 B |
|                                             |              |              |            |            |           |
| Encrypt · ARIA-256-CBC (CryptoHives-Scalar) | 1KB          |    15.988 μs |  0.2024 μs |  0.1893 μs |         - |
| Encrypt · ARIA-256-CBC (BouncyCastle)       | 1KB          |    23.442 μs |  0.2406 μs |  0.2250 μs |    3656 B |
|                                             |              |              |            |            |           |
| Decrypt · ARIA-256-CBC (CryptoHives-Scalar) | 8KB          |   125.439 μs |  1.2256 μs |  1.0864 μs |         - |
| Decrypt · ARIA-256-CBC (BouncyCastle)       | 8KB          |   180.957 μs |  1.5353 μs |  1.4361 μs |   21576 B |
|                                             |              |              |            |            |           |
| Encrypt · ARIA-256-CBC (CryptoHives-Scalar) | 8KB          |   127.918 μs |  1.2967 μs |  1.1495 μs |         - |
| Encrypt · ARIA-256-CBC (BouncyCastle)       | 8KB          |   182.739 μs |  1.6130 μs |  1.5088 μs |   21576 B |
|                                             |              |              |            |            |           |
| Decrypt · ARIA-256-CBC (CryptoHives-Scalar) | 128KB        | 2,008.229 μs | 17.0109 μs | 15.9120 μs |         - |
| Decrypt · ARIA-256-CBC (BouncyCastle)       | 128KB        | 2,874.680 μs | 29.0793 μs | 27.2008 μs |  328776 B |
|                                             |              |              |            |            |           |
| Encrypt · ARIA-256-CBC (CryptoHives-Scalar) | 128KB        | 2,006.078 μs | 25.3729 μs | 23.7339 μs |         - |
| Encrypt · ARIA-256-CBC (BouncyCastle)       | 128KB        | 2,909.838 μs | 24.4358 μs | 22.8572 μs |  328776 B |