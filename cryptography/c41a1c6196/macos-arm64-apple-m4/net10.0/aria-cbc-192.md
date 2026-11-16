| Description                                 | TestDataSize | Mean         | Error     | StdDev    | Allocated |
|-------------------------------------------- |------------- |-------------:|----------:|----------:|----------:|
| Decrypt · ARIA-192-CBC (CryptoHives-Scalar) | 128B         |     1.084 μs | 0.0026 μs | 0.0024 μs |         - |
| Decrypt · ARIA-192-CBC (BouncyCastle)       | 128B         |     2.464 μs | 0.0045 μs | 0.0040 μs |    1312 B |
|                                             |              |              |           |           |           |
| Encrypt · ARIA-192-CBC (CryptoHives-Scalar) | 128B         |     1.087 μs | 0.0016 μs | 0.0015 μs |         - |
| Encrypt · ARIA-192-CBC (BouncyCastle)       | 128B         |     2.422 μs | 0.0079 μs | 0.0074 μs |    1312 B |
|                                             |              |              |           |           |           |
| Decrypt · ARIA-192-CBC (CryptoHives-Scalar) | 1KB          |     7.703 μs | 0.0089 μs | 0.0083 μs |         - |
| Decrypt · ARIA-192-CBC (BouncyCastle)       | 1KB          |    15.378 μs | 0.0825 μs | 0.0772 μs |    3552 B |
|                                             |              |              |           |           |           |
| Encrypt · ARIA-192-CBC (CryptoHives-Scalar) | 1KB          |     7.747 μs | 0.0084 μs | 0.0079 μs |         - |
| Encrypt · ARIA-192-CBC (BouncyCastle)       | 1KB          |    15.050 μs | 0.0341 μs | 0.0319 μs |    3552 B |
|                                             |              |              |           |           |           |
| Decrypt · ARIA-192-CBC (CryptoHives-Scalar) | 8KB          |    60.359 μs | 0.1402 μs | 0.1243 μs |         - |
| Decrypt · ARIA-192-CBC (BouncyCastle)       | 8KB          |   117.458 μs | 0.2126 μs | 0.1884 μs |   21472 B |
|                                             |              |              |           |           |           |
| Encrypt · ARIA-192-CBC (CryptoHives-Scalar) | 8KB          |    60.922 μs | 0.0562 μs | 0.0498 μs |         - |
| Encrypt · ARIA-192-CBC (BouncyCastle)       | 8KB          |   115.005 μs | 0.2231 μs | 0.1977 μs |   21472 B |
|                                             |              |              |           |           |           |
| Decrypt · ARIA-192-CBC (CryptoHives-Scalar) | 128KB        |   964.517 μs | 0.9169 μs | 0.8128 μs |         - |
| Decrypt · ARIA-192-CBC (BouncyCastle)       | 128KB        | 1,877.302 μs | 2.4482 μs | 2.2901 μs |  328672 B |
|                                             |              |              |           |           |           |
| Encrypt · ARIA-192-CBC (CryptoHives-Scalar) | 128KB        |   972.645 μs | 3.1222 μs | 2.7678 μs |         - |
| Encrypt · ARIA-192-CBC (BouncyCastle)       | 128KB        | 1,838.426 μs | 3.3080 μs | 3.0943 μs |  328672 B |