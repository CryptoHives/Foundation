| Description                                 | TestDataSize | Mean         | Error     | StdDev    | Code Size | Allocated |
|-------------------------------------------- |------------- |-------------:|----------:|----------:|----------:|----------:|
| Decrypt · ARIA-256-CBC (CryptoHives-Scalar) | 128B         |     4.387 μs | 0.0080 μs | 0.0075 μs |  10,551 B |         - |
| Decrypt · ARIA-256-CBC (BouncyCastle)       | 128B         |     5.758 μs | 0.0054 μs | 0.0050 μs |   7,778 B |    1416 B |
|                                             |              |              |           |           |           |           |
| Encrypt · ARIA-256-CBC (CryptoHives-Scalar) | 128B         |     4.381 μs | 0.0095 μs | 0.0089 μs |  10,361 B |         - |
| Encrypt · ARIA-256-CBC (BouncyCastle)       | 128B         |     5.387 μs | 0.0144 μs | 0.0120 μs |  13,737 B |    1416 B |
|                                             |              |              |           |           |           |           |
| Decrypt · ARIA-256-CBC (CryptoHives-Scalar) | 1KB          |    31.237 μs | 0.0844 μs | 0.0705 μs |  10,361 B |         - |
| Decrypt · ARIA-256-CBC (BouncyCastle)       | 1KB          |    33.710 μs | 0.0300 μs | 0.0281 μs |  13,737 B |    3656 B |
|                                             |              |              |           |           |           |           |
| Encrypt · ARIA-256-CBC (CryptoHives-Scalar) | 1KB          |    31.256 μs | 0.0656 μs | 0.0614 μs |   4,026 B |         - |
| Encrypt · ARIA-256-CBC (BouncyCastle)       | 1KB          |    32.832 μs | 0.0706 μs | 0.0660 μs |  13,737 B |    3656 B |
|                                             |              |              |           |           |           |           |
| Decrypt · ARIA-256-CBC (CryptoHives-Scalar) | 8KB          |   246.309 μs | 0.4077 μs | 0.3405 μs |   4,026 B |         - |
| Decrypt · ARIA-256-CBC (BouncyCastle)       | 8KB          |   257.134 μs | 0.0998 μs | 0.0833 μs |  13,737 B |   21576 B |
|                                             |              |              |           |           |           |           |
| Encrypt · ARIA-256-CBC (CryptoHives-Scalar) | 8KB          |   246.161 μs | 0.3100 μs | 0.2748 μs |  10,361 B |         - |
| Encrypt · ARIA-256-CBC (BouncyCastle)       | 8KB          |   252.832 μs | 0.1932 μs | 0.1508 μs |  13,737 B |   21576 B |
|                                             |              |              |           |           |           |           |
| Decrypt · ARIA-256-CBC (CryptoHives-Scalar) | 128KB        | 4,061.671 μs | 7.3527 μs | 6.8777 μs |  10,312 B |         - |
| Decrypt · ARIA-256-CBC (BouncyCastle)       | 128KB        | 4,136.769 μs | 3.9522 μs | 3.5035 μs |  13,927 B |  328776 B |
|                                             |              |              |           |           |           |           |
| Encrypt · ARIA-256-CBC (CryptoHives-Scalar) | 128KB        | 3,938.189 μs | 7.6479 μs | 7.1538 μs |  10,502 B |         - |
| Encrypt · ARIA-256-CBC (BouncyCastle)       | 128KB        | 4,011.885 μs | 3.9979 μs | 3.5440 μs |  13,737 B |  328776 B |