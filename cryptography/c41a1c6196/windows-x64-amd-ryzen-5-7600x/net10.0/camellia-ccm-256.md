| Description                                     | TestDataSize | Mean         | Error     | StdDev    | Code Size | Allocated |
|------------------------------------------------ |------------- |-------------:|----------:|----------:|----------:|----------:|
| Decrypt · Camellia-256-CCM (CryptoHives-Scalar) | 128B         |     2.286 μs | 0.0047 μs | 0.0039 μs |  18,613 B |         - |
| Decrypt · Camellia-256-CCM (BouncyCastle)       | 128B         |     3.324 μs | 0.0066 μs | 0.0055 μs |     306 B |    2232 B |
|                                                 |              |              |           |           |           |           |
| Encrypt · Camellia-256-CCM (CryptoHives-Scalar) | 128B         |     2.245 μs | 0.0039 μs | 0.0033 μs |  18,651 B |         - |
| Encrypt · Camellia-256-CCM (BouncyCastle)       | 128B         |     3.426 μs | 0.0071 μs | 0.0055 μs |     383 B |    2120 B |
|                                                 |              |              |           |           |           |           |
| Decrypt · Camellia-256-CCM (CryptoHives-Scalar) | 1KB          |    14.418 μs | 0.0273 μs | 0.0255 μs |  18,619 B |         - |
| Decrypt · Camellia-256-CCM (BouncyCastle)       | 1KB          |    19.968 μs | 0.0519 μs | 0.0460 μs |     306 B |    7608 B |
|                                                 |              |              |           |           |           |           |
| Encrypt · Camellia-256-CCM (CryptoHives-Scalar) | 1KB          |    14.606 μs | 0.0195 μs | 0.0173 μs |  18,664 B |         - |
| Encrypt · Camellia-256-CCM (BouncyCastle)       | 1KB          |    19.758 μs | 0.0405 μs | 0.0359 μs |     383 B |    6600 B |
|                                                 |              |              |           |           |           |           |
| Decrypt · Camellia-256-CCM (CryptoHives-Scalar) | 8KB          |   111.180 μs | 0.1139 μs | 0.0951 μs |  18,623 B |         - |
| Decrypt · Camellia-256-CCM (BouncyCastle)       | 8KB          |   152.220 μs | 0.4142 μs | 0.3874 μs |     306 B |   50616 B |
|                                                 |              |              |           |           |           |           |
| Encrypt · Camellia-256-CCM (CryptoHives-Scalar) | 8KB          |   112.365 μs | 0.1159 μs | 0.0968 μs |  18,665 B |         - |
| Encrypt · Camellia-256-CCM (BouncyCastle)       | 8KB          |   151.512 μs | 0.4901 μs | 0.4345 μs |     383 B |   42440 B |
|                                                 |              |              |           |           |           |           |
| Decrypt · Camellia-256-CCM (CryptoHives-Scalar) | 128KB        | 1,789.946 μs | 1.8683 μs | 1.6562 μs |  18,627 B |         - |
| Decrypt · Camellia-256-CCM (BouncyCastle)       | 128KB        | 2,491.253 μs | 9.3585 μs | 8.2961 μs |     306 B |  787909 B |
|                                                 |              |              |           |           |           |           |
| Encrypt · Camellia-256-CCM (CryptoHives-Scalar) | 128KB        | 1,789.400 μs | 2.3505 μs | 1.8351 μs |  18,662 B |         - |
| Encrypt · Camellia-256-CCM (BouncyCastle)       | 128KB        | 2,407.423 μs | 4.8001 μs | 4.0083 μs |     383 B |  656840 B |