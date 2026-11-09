| Description                                 | TestDataSize | Mean         | Error     | StdDev    | Code Size | Allocated |
|-------------------------------------------- |------------- |-------------:|----------:|----------:|----------:|----------:|
| Decrypt · ARIA-256-CBC (CryptoHives-Scalar) | 128B         |     3.710 μs | 0.0293 μs | 0.0274 μs |   1,311 B |         - |
| Decrypt · ARIA-256-CBC (BouncyCastle)       | 128B         |     4.702 μs | 0.0198 μs | 0.0176 μs |   2,927 B |    1416 B |
|                                             |              |              |           |           |           |           |
| Encrypt · ARIA-256-CBC (CryptoHives-Scalar) | 128B         |     3.746 μs | 0.0056 μs | 0.0047 μs |   1,307 B |         - |
| Encrypt · ARIA-256-CBC (BouncyCastle)       | 128B         |     4.385 μs | 0.0170 μs | 0.0159 μs |   2,925 B |    1416 B |
|                                             |              |              |           |           |           |           |
| Decrypt · ARIA-256-CBC (CryptoHives-Scalar) | 1KB          |    26.029 μs | 0.0528 μs | 0.0494 μs |   1,311 B |         - |
| Decrypt · ARIA-256-CBC (BouncyCastle)       | 1KB          |    28.304 μs | 0.0528 μs | 0.0468 μs |   2,927 B |    3656 B |
|                                             |              |              |           |           |           |           |
| Encrypt · ARIA-256-CBC (CryptoHives-Scalar) | 1KB          |    26.480 μs | 0.0558 μs | 0.0522 μs |   1,307 B |         - |
| Encrypt · ARIA-256-CBC (BouncyCastle)       | 1KB          |    27.122 μs | 0.0450 μs | 0.0376 μs |   2,929 B |    3656 B |
|                                             |              |              |           |           |           |           |
| Decrypt · ARIA-256-CBC (CryptoHives-Scalar) | 8KB          |   204.798 μs | 0.3243 μs | 0.3034 μs |   1,311 B |         - |
| Decrypt · ARIA-256-CBC (BouncyCastle)       | 8KB          |   216.838 μs | 0.4385 μs | 0.4102 μs |   2,927 B |   21576 B |
|                                             |              |              |           |           |           |           |
| Encrypt · ARIA-256-CBC (CryptoHives-Scalar) | 8KB          |   207.962 μs | 0.2527 μs | 0.2364 μs |   1,305 B |         - |
| Encrypt · ARIA-256-CBC (BouncyCastle)       | 8KB          |   214.648 μs | 0.4338 μs | 0.4058 μs |   2,929 B |   21576 B |
|                                             |              |              |           |           |           |           |
| Decrypt · ARIA-256-CBC (CryptoHives-Scalar) | 128KB        | 3,271.736 μs | 6.5423 μs | 5.4631 μs |   1,311 B |         - |
| Decrypt · ARIA-256-CBC (BouncyCastle)       | 128KB        | 3,429.211 μs | 7.0913 μs | 6.6332 μs |   2,929 B |  328776 B |
|                                             |              |              |           |           |           |           |
| Encrypt · ARIA-256-CBC (CryptoHives-Scalar) | 128KB        | 3,321.590 μs | 6.6813 μs | 5.9228 μs |   1,305 B |         - |
| Encrypt · ARIA-256-CBC (BouncyCastle)       | 128KB        | 3,418.586 μs | 8.2339 μs | 7.7020 μs |   2,927 B |  328776 B |