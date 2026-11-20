| Description                                 | TestDataSize | Mean         | Error     | StdDev    | Code Size | Allocated |
|-------------------------------------------- |------------- |-------------:|----------:|----------:|----------:|----------:|
| Decrypt · ARIA-192-CBC (CryptoHives-Scalar) | 128B         |     3.886 μs | 0.0069 μs | 0.0058 μs |  10,361 B |         - |
| Decrypt · ARIA-192-CBC (BouncyCastle)       | 128B         |     5.095 μs | 0.0077 μs | 0.0069 μs |  13,737 B |    1312 B |
|                                             |              |              |           |           |           |           |
| Encrypt · ARIA-192-CBC (CryptoHives-Scalar) | 128B         |     3.900 μs | 0.0031 μs | 0.0029 μs |  10,361 B |         - |
| Encrypt · ARIA-192-CBC (BouncyCastle)       | 128B         |     4.752 μs | 0.0043 μs | 0.0038 μs |   7,778 B |    1312 B |
|                                             |              |              |           |           |           |           |
| Decrypt · ARIA-192-CBC (CryptoHives-Scalar) | 1KB          |    27.524 μs | 0.0347 μs | 0.0325 μs |  10,361 B |         - |
| Decrypt · ARIA-192-CBC (BouncyCastle)       | 1KB          |    29.688 μs | 0.0304 μs | 0.0269 μs |  13,927 B |    3552 B |
|                                             |              |              |           |           |           |           |
| Encrypt · ARIA-192-CBC (CryptoHives-Scalar) | 1KB          |    27.612 μs | 0.0317 μs | 0.0296 μs |   4,026 B |         - |
| Encrypt · ARIA-192-CBC (BouncyCastle)       | 1KB          |    29.720 μs | 0.0208 μs | 0.0185 μs |  13,927 B |    3552 B |
|                                             |              |              |           |           |           |           |
| Decrypt · ARIA-192-CBC (CryptoHives-Scalar) | 8KB          |   217.283 μs | 0.3986 μs | 0.3728 μs |   4,026 B |         - |
| Decrypt · ARIA-192-CBC (BouncyCastle)       | 8KB          |   226.861 μs | 0.2879 μs | 0.2404 μs |  13,737 B |   21472 B |
|                                             |              |              |           |           |           |           |
| Encrypt · ARIA-192-CBC (CryptoHives-Scalar) | 8KB          |   217.861 μs | 0.3612 μs | 0.3378 μs |   4,026 B |         - |
| Encrypt · ARIA-192-CBC (BouncyCastle)       | 8KB          |   221.618 μs | 0.1984 μs | 0.1855 μs |   7,778 B |   21472 B |
|                                             |              |              |           |           |           |           |
| Decrypt · ARIA-192-CBC (CryptoHives-Scalar) | 128KB        | 3,451.200 μs | 3.0978 μs | 2.5868 μs |  10,361 B |         - |
| Decrypt · ARIA-192-CBC (BouncyCastle)       | 128KB        | 3,586.236 μs | 2.6639 μs | 2.4918 μs |  13,927 B |  328672 B |
|                                             |              |              |           |           |           |           |
| Encrypt · ARIA-192-CBC (CryptoHives-Scalar) | 128KB        | 3,501.548 μs | 4.1592 μs | 3.6871 μs |  10,551 B |         - |
| Encrypt · ARIA-192-CBC (BouncyCastle)       | 128KB        | 3,523.358 μs | 1.9923 μs | 1.8636 μs |  13,737 B |  328672 B |