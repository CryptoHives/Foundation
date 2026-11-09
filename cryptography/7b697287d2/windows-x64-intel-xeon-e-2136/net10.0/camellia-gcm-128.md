| Description                                     | TestDataSize | Mean         | Error     | StdDev    | Code Size | Allocated |
|------------------------------------------------ |------------- |-------------:|----------:|----------:|----------:|----------:|
| Decrypt · Camellia-128-GCM (CryptoHives-PClMul) | 128B         |     1.098 μs | 0.0043 μs | 0.0038 μs |     310 B |         - |
| Decrypt · Camellia-128-GCM (BouncyCastle)       | 128B         |     1.729 μs | 0.0106 μs | 0.0099 μs |     310 B |    1408 B |
| Decrypt · Camellia-128-GCM (CryptoHives-Scalar) | 128B         |     1.900 μs | 0.0192 μs | 0.0179 μs |     310 B |         - |
|                                                 |              |              |           |           |           |           |
| Encrypt · Camellia-128-GCM (CryptoHives-PClMul) | 128B         |     1.024 μs | 0.0119 μs | 0.0111 μs |     387 B |         - |
| Encrypt · Camellia-128-GCM (BouncyCastle)       | 128B         |     1.585 μs | 0.0176 μs | 0.0165 μs |     387 B |    1392 B |
| Encrypt · Camellia-128-GCM (CryptoHives-Scalar) | 128B         |     1.814 μs | 0.0194 μs | 0.0181 μs |     387 B |         - |
|                                                 |              |              |           |           |           |           |
| Decrypt · Camellia-128-GCM (CryptoHives-PClMul) | 1KB          |     7.191 μs | 0.0681 μs | 0.0637 μs |     310 B |         - |
| Decrypt · Camellia-128-GCM (BouncyCastle)       | 1KB          |     8.662 μs | 0.0899 μs | 0.0841 μs |     310 B |    3648 B |
| Decrypt · Camellia-128-GCM (CryptoHives-Scalar) | 1KB          |    12.777 μs | 0.1101 μs | 0.0976 μs |     310 B |         - |
|                                                 |              |              |           |           |           |           |
| Encrypt · Camellia-128-GCM (CryptoHives-PClMul) | 1KB          |     7.129 μs | 0.0688 μs | 0.0610 μs |     390 B |         - |
| Encrypt · Camellia-128-GCM (BouncyCastle)       | 1KB          |     8.337 μs | 0.1503 μs | 0.1406 μs |     387 B |    3632 B |
| Encrypt · Camellia-128-GCM (CryptoHives-Scalar) | 1KB          |    12.654 μs | 0.1949 μs | 0.1823 μs |     387 B |         - |
|                                                 |              |              |           |           |           |           |
| Decrypt · Camellia-128-GCM (CryptoHives-PClMul) | 8KB          |    56.765 μs | 0.6260 μs | 0.5856 μs |     310 B |         - |
| Decrypt · Camellia-128-GCM (BouncyCastle)       | 8KB          |    62.546 μs | 0.3262 μs | 0.3051 μs |     310 B |   21568 B |
| Decrypt · Camellia-128-GCM (CryptoHives-Scalar) | 8KB          |    99.788 μs | 0.6845 μs | 0.6403 μs |     310 B |         - |
|                                                 |              |              |           |           |           |           |
| Encrypt · Camellia-128-GCM (CryptoHives-PClMul) | 8KB          |    56.381 μs | 0.9195 μs | 0.7678 μs |     387 B |         - |
| Encrypt · Camellia-128-GCM (BouncyCastle)       | 8KB          |    63.247 μs | 0.5357 μs | 0.5011 μs |     387 B |   21552 B |
| Encrypt · Camellia-128-GCM (CryptoHives-Scalar) | 8KB          |   100.973 μs | 0.8946 μs | 0.8368 μs |     387 B |         - |
|                                                 |              |              |           |           |           |           |
| Decrypt · Camellia-128-GCM (CryptoHives-PClMul) | 128KB        |   881.526 μs | 2.8271 μs | 2.6445 μs |     310 B |         - |
| Decrypt · Camellia-128-GCM (BouncyCastle)       | 128KB        | 1,001.240 μs | 4.8436 μs | 4.2937 μs |     310 B |  328768 B |
| Decrypt · Camellia-128-GCM (CryptoHives-Scalar) | 128KB        | 1,556.614 μs | 9.4647 μs | 7.9035 μs |     310 B |         - |
|                                                 |              |              |           |           |           |           |
| Encrypt · Camellia-128-GCM (CryptoHives-PClMul) | 128KB        |   922.474 μs | 7.6505 μs | 7.1563 μs |     387 B |         - |
| Encrypt · Camellia-128-GCM (BouncyCastle)       | 128KB        | 1,020.649 μs | 9.9410 μs | 9.2988 μs |     387 B |  328752 B |
| Encrypt · Camellia-128-GCM (CryptoHives-Scalar) | 128KB        | 1,607.877 μs | 6.1094 μs | 5.7147 μs |     387 B |         - |