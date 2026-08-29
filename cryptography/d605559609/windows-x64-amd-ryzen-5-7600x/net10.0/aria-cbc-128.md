| Description                                 | TestDataSize | Mean         | Error     | StdDev    | Allocated |
|-------------------------------------------- |------------- |-------------:|----------:|----------:|----------:|
| Decrypt · ARIA-128-CBC (CryptoHives-Scalar) | 128B         |     1.500 μs | 0.0160 μs | 0.0142 μs |         - |
| Decrypt · ARIA-128-CBC (BouncyCastle)       | 128B         |     2.467 μs | 0.0103 μs | 0.0091 μs |    1208 B |
|                                             |              |              |           |           |           |
| Encrypt · ARIA-128-CBC (CryptoHives-Scalar) | 128B         |     1.499 μs | 0.0096 μs | 0.0090 μs |         - |
| Encrypt · ARIA-128-CBC (BouncyCastle)       | 128B         |     2.383 μs | 0.0163 μs | 0.0136 μs |    1208 B |
|                                             |              |              |           |           |           |
| Decrypt · ARIA-128-CBC (CryptoHives-Scalar) | 1KB          |    10.652 μs | 0.0631 μs | 0.0560 μs |         - |
| Decrypt · ARIA-128-CBC (BouncyCastle)       | 1KB          |    15.428 μs | 0.1170 μs | 0.1094 μs |    3448 B |
|                                             |              |              |           |           |           |
| Encrypt · ARIA-128-CBC (CryptoHives-Scalar) | 1KB          |    10.669 μs | 0.1008 μs | 0.0943 μs |         - |
| Encrypt · ARIA-128-CBC (BouncyCastle)       | 1KB          |    15.531 μs | 0.1462 μs | 0.1368 μs |    3448 B |
|                                             |              |              |           |           |           |
| Decrypt · ARIA-128-CBC (CryptoHives-Scalar) | 8KB          |    83.991 μs | 0.5650 μs | 0.4718 μs |         - |
| Decrypt · ARIA-128-CBC (BouncyCastle)       | 8KB          |   119.235 μs | 0.3469 μs | 0.2896 μs |   21368 B |
|                                             |              |              |           |           |           |
| Encrypt · ARIA-128-CBC (CryptoHives-Scalar) | 8KB          |    84.071 μs | 0.4289 μs | 0.3802 μs |         - |
| Encrypt · ARIA-128-CBC (BouncyCastle)       | 8KB          |   120.711 μs | 0.6318 μs | 0.5910 μs |   21368 B |
|                                             |              |              |           |           |           |
| Decrypt · ARIA-128-CBC (CryptoHives-Scalar) | 128KB        | 1,347.315 μs | 9.5843 μs | 8.4962 μs |         - |
| Decrypt · ARIA-128-CBC (BouncyCastle)       | 128KB        | 1,890.321 μs | 7.3353 μs | 5.7270 μs |  328568 B |
|                                             |              |              |           |           |           |
| Encrypt · ARIA-128-CBC (CryptoHives-Scalar) | 128KB        | 1,338.315 μs | 8.7595 μs | 8.1937 μs |         - |
| Encrypt · ARIA-128-CBC (BouncyCastle)       | 128KB        | 1,913.536 μs | 9.3920 μs | 8.7853 μs |  328568 B |