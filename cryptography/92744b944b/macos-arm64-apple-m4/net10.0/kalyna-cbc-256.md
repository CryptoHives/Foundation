| Description                                   | TestDataSize | Mean          | Error      | StdDev     | Allocated |
|---------------------------------------------- |------------- |--------------:|-----------:|-----------:|----------:|
| Decrypt · Kalyna-256-CBC (CryptoHives-Scalar) | 128B         |     14.626 μs |  0.0066 μs |  0.0058 μs |         - |
| Decrypt · Kalyna-256-CBC (BouncyCastle)       | 128B         |     15.499 μs |  0.0101 μs |  0.0085 μs |    1112 B |
|                                               |              |               |            |            |           |
| Encrypt · Kalyna-256-CBC (BouncyCastle)       | 128B         |      8.032 μs |  0.0112 μs |  0.0105 μs |    1112 B |
| Encrypt · Kalyna-256-CBC (CryptoHives-Scalar) | 128B         |     13.069 μs |  0.0179 μs |  0.0149 μs |         - |
|                                               |              |               |            |            |           |
| Decrypt · Kalyna-256-CBC (BouncyCastle)       | 1KB          |     99.783 μs |  0.0840 μs |  0.0702 μs |    1112 B |
| Decrypt · Kalyna-256-CBC (CryptoHives-Scalar) | 1KB          |    104.872 μs |  0.0364 μs |  0.0340 μs |         - |
|                                               |              |               |            |            |           |
| Encrypt · Kalyna-256-CBC (BouncyCastle)       | 1KB          |     46.026 μs |  0.0245 μs |  0.0205 μs |    1112 B |
| Encrypt · Kalyna-256-CBC (CryptoHives-Scalar) | 1KB          |     93.874 μs |  0.1473 μs |  0.1378 μs |         - |
|                                               |              |               |            |            |           |
| Decrypt · Kalyna-256-CBC (BouncyCastle)       | 8KB          |    774.335 μs |  0.3431 μs |  0.3210 μs |    1112 B |
| Decrypt · Kalyna-256-CBC (CryptoHives-Scalar) | 8KB          |    827.234 μs |  0.5608 μs |  0.5246 μs |         - |
|                                               |              |               |            |            |           |
| Encrypt · Kalyna-256-CBC (BouncyCastle)       | 8KB          |    350.339 μs |  0.2128 μs |  0.1886 μs |    1112 B |
| Encrypt · Kalyna-256-CBC (CryptoHives-Scalar) | 8KB          |    739.892 μs |  1.8743 μs |  1.5652 μs |         - |
|                                               |              |               |            |            |           |
| Decrypt · Kalyna-256-CBC (BouncyCastle)       | 128KB        |  2,628.318 μs | 31.0346 μs | 59.7931 μs |    1112 B |
| Decrypt · Kalyna-256-CBC (CryptoHives-Scalar) | 128KB        | 13,231.225 μs |  6.8742 μs |  6.0938 μs |         - |
|                                               |              |               |            |            |           |
| Encrypt · Kalyna-256-CBC (BouncyCastle)       | 128KB        |  5,569.737 μs |  3.4409 μs |  2.8733 μs |    1112 B |
| Encrypt · Kalyna-256-CBC (CryptoHives-Scalar) | 128KB        | 11,931.521 μs | 19.3520 μs | 17.1551 μs |         - |