| Description                                     | TestDataSize | Mean         | Error     | StdDev    | Code Size | Allocated |
|------------------------------------------------ |------------- |-------------:|----------:|----------:|----------:|----------:|
| Decrypt · Camellia-256-CCM (CryptoHives-Scalar) | 128B         |     2.293 μs | 0.0045 μs | 0.0037 μs |  29,438 B |         - |
| Decrypt · Camellia-256-CCM (BouncyCastle)       | 128B         |     3.070 μs | 0.0069 μs | 0.0061 μs |     306 B |    2200 B |
|                                                 |              |              |           |           |           |           |
| Encrypt · Camellia-256-CCM (CryptoHives-Scalar) | 128B         |     2.241 μs | 0.0059 μs | 0.0049 μs |  31,479 B |         - |
| Encrypt · Camellia-256-CCM (BouncyCastle)       | 128B         |     3.090 μs | 0.0107 μs | 0.0089 μs |     386 B |    2048 B |
|                                                 |              |              |           |           |           |           |
| Decrypt · Camellia-256-CCM (CryptoHives-Scalar) | 1KB          |    14.429 μs | 0.0163 μs | 0.0136 μs |  39,847 B |         - |
| Decrypt · Camellia-256-CCM (BouncyCastle)       | 1KB          |    18.397 μs | 0.0514 μs | 0.0429 μs |     306 B |    7576 B |
|                                                 |              |              |           |           |           |           |
| Encrypt · Camellia-256-CCM (CryptoHives-Scalar) | 1KB          |    14.646 μs | 0.0466 μs | 0.0436 μs |  32,110 B |         - |
| Encrypt · Camellia-256-CCM (BouncyCastle)       | 1KB          |    18.265 μs | 0.0571 μs | 0.0477 μs |     386 B |    6528 B |
|                                                 |              |              |           |           |           |           |
| Decrypt · Camellia-256-CCM (CryptoHives-Scalar) | 8KB          |   112.026 μs | 0.8414 μs | 0.7871 μs |  29,448 B |         - |
| Decrypt · Camellia-256-CCM (BouncyCastle)       | 8KB          |   140.546 μs | 0.9921 μs | 0.8285 μs |     306 B |   50584 B |
|                                                 |              |              |           |           |           |           |
| Encrypt · Camellia-256-CCM (CryptoHives-Scalar) | 8KB          |   114.129 μs | 0.1324 μs | 0.1106 μs |  31,418 B |         - |
| Encrypt · Camellia-256-CCM (BouncyCastle)       | 8KB          |   140.053 μs | 0.4400 μs | 0.3674 μs |     386 B |   42368 B |
|                                                 |              |              |           |           |           |           |
| Decrypt · Camellia-256-CCM (CryptoHives-Scalar) | 128KB        | 1,791.219 μs | 9.4419 μs | 8.3700 μs |  29,300 B |         - |
| Decrypt · Camellia-256-CCM (BouncyCastle)       | 128KB        | 2,382.203 μs | 9.9521 μs | 9.3092 μs |     306 B |  787915 B |
|                                                 |              |              |           |           |           |           |
| Encrypt · Camellia-256-CCM (CryptoHives-Scalar) | 128KB        | 1,812.814 μs | 2.7926 μs | 2.3319 μs |  24,998 B |         - |
| Encrypt · Camellia-256-CCM (BouncyCastle)       | 128KB        | 2,241.447 μs | 4.7666 μs | 4.2254 μs |     386 B |  656768 B |