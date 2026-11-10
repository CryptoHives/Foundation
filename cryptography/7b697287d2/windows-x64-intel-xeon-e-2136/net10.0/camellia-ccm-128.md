| Description                                     | TestDataSize | Mean         | Error     | StdDev    | Code Size | Allocated |
|------------------------------------------------ |------------- |-------------:|----------:|----------:|----------:|----------:|
| Decrypt · Camellia-128-CCM (CryptoHives-Scalar) | 128B         |     3.172 μs | 0.0029 μs | 0.0027 μs |  18,775 B |         - |
| Decrypt · Camellia-128-CCM (BouncyCastle)       | 128B         |     4.441 μs | 0.0140 μs | 0.0131 μs |     310 B |    2184 B |
|                                                 |              |              |           |           |           |           |
| Encrypt · Camellia-128-CCM (CryptoHives-Scalar) | 128B         |     3.058 μs | 0.0026 μs | 0.0023 μs |  18,825 B |         - |
| Encrypt · Camellia-128-CCM (BouncyCastle)       | 128B         |     4.346 μs | 0.0135 μs | 0.0120 μs |     390 B |    2072 B |
|                                                 |              |              |           |           |           |           |
| Decrypt · Camellia-128-CCM (CryptoHives-Scalar) | 1KB          |    19.807 μs | 0.0259 μs | 0.0230 μs |  18,779 B |         - |
| Decrypt · Camellia-128-CCM (BouncyCastle)       | 1KB          |    25.251 μs | 0.0655 μs | 0.0581 μs |     310 B |    7560 B |
|                                                 |              |              |           |           |           |           |
| Encrypt · Camellia-128-CCM (CryptoHives-Scalar) | 1KB          |    19.693 μs | 0.0223 μs | 0.0186 μs |  18,835 B |         - |
| Encrypt · Camellia-128-CCM (BouncyCastle)       | 1KB          |    24.668 μs | 0.0387 μs | 0.0343 μs |     387 B |    6552 B |
|                                                 |              |              |           |           |           |           |
| Decrypt · Camellia-128-CCM (CryptoHives-Scalar) | 8KB          |   152.421 μs | 0.1009 μs | 0.0843 μs |  18,780 B |         - |
| Decrypt · Camellia-128-CCM (BouncyCastle)       | 8KB          |   188.555 μs | 0.3711 μs | 0.3290 μs |     310 B |   50568 B |
|                                                 |              |              |           |           |           |           |
| Encrypt · Camellia-128-CCM (CryptoHives-Scalar) | 8KB          |   152.056 μs | 0.1550 μs | 0.1374 μs |  18,836 B |         - |
| Encrypt · Camellia-128-CCM (BouncyCastle)       | 8KB          |   187.717 μs | 0.5782 μs | 0.5126 μs |     387 B |   42392 B |
|                                                 |              |              |           |           |           |           |
| Decrypt · Camellia-128-CCM (CryptoHives-Scalar) | 128KB        | 2,423.737 μs | 2.1192 μs | 1.8786 μs |  18,783 B |         - |
| Decrypt · Camellia-128-CCM (BouncyCastle)       | 128KB        | 3,086.498 μs | 4.1380 μs | 3.8706 μs |     310 B |  787861 B |
|                                                 |              |              |           |           |           |           |
| Encrypt · Camellia-128-CCM (CryptoHives-Scalar) | 128KB        | 2,427.398 μs | 1.7230 μs | 1.4388 μs |  18,836 B |         - |
| Encrypt · Camellia-128-CCM (BouncyCastle)       | 128KB        | 2,956.164 μs | 5.6255 μs | 5.2621 μs |     387 B |  656792 B |