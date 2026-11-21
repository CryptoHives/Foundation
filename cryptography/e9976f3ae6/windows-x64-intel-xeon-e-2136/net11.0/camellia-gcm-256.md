| Description                                     | TestDataSize | Mean         | Error      | StdDev     | Code Size | Allocated |
|------------------------------------------------ |------------- |-------------:|-----------:|-----------:|----------:|----------:|
| Decrypt · Camellia-256-GCM (CryptoHives-PClMul) | 128B         |     1.801 μs |  0.0011 μs |  0.0010 μs |     310 B |         - |
| Decrypt · Camellia-256-GCM (BouncyCastle)       | 128B         |     2.505 μs |  0.0075 μs |  0.0070 μs |     310 B |    1440 B |
| Decrypt · Camellia-256-GCM (CryptoHives-Scalar) | 128B         |     2.698 μs |  0.0125 μs |  0.0111 μs |     310 B |         - |
|                                                 |              |              |            |            |           |           |
| Encrypt · Camellia-256-GCM (CryptoHives-PClMul) | 128B         |     1.693 μs |  0.0011 μs |  0.0009 μs |     390 B |         - |
| Encrypt · Camellia-256-GCM (BouncyCastle)       | 128B         |     2.330 μs |  0.0030 μs |  0.0028 μs |     390 B |    1424 B |
| Encrypt · Camellia-256-GCM (CryptoHives-Scalar) | 128B         |     2.616 μs |  0.0045 μs |  0.0040 μs |     390 B |         - |
|                                                 |              |              |            |            |           |           |
| Decrypt · Camellia-256-GCM (CryptoHives-PClMul) | 1KB          |    11.839 μs |  0.0055 μs |  0.0052 μs |     310 B |         - |
| Decrypt · Camellia-256-GCM (BouncyCastle)       | 1KB          |    12.656 μs |  0.0194 μs |  0.0172 μs |     310 B |    3680 B |
| Decrypt · Camellia-256-GCM (CryptoHives-Scalar) | 1KB          |    18.044 μs |  0.0649 μs |  0.0576 μs |     310 B |         - |
|                                                 |              |              |            |            |           |           |
| Encrypt · Camellia-256-GCM (CryptoHives-PClMul) | 1KB          |    11.775 μs |  0.0054 μs |  0.0045 μs |     390 B |         - |
| Encrypt · Camellia-256-GCM (BouncyCastle)       | 1KB          |    12.526 μs |  0.0347 μs |  0.0290 μs |     390 B |    3664 B |
| Encrypt · Camellia-256-GCM (CryptoHives-Scalar) | 1KB          |    18.012 μs |  0.0529 μs |  0.0495 μs |     390 B |         - |
|                                                 |              |              |            |            |           |           |
| Decrypt · Camellia-256-GCM (CryptoHives-PClMul) | 8KB          |    93.160 μs |  0.0288 μs |  0.0255 μs |     310 B |         - |
| Decrypt · Camellia-256-GCM (BouncyCastle)       | 8KB          |    93.819 μs |  0.1573 μs |  0.1471 μs |     310 B |   21600 B |
| Decrypt · Camellia-256-GCM (CryptoHives-Scalar) | 8KB          |   140.247 μs |  0.2927 μs |  0.2444 μs |     310 B |         - |
|                                                 |              |              |            |            |           |           |
| Encrypt · Camellia-256-GCM (CryptoHives-PClMul) | 8KB          |    94.044 μs |  1.7557 μs |  1.6423 μs |     390 B |         - |
| Encrypt · Camellia-256-GCM (BouncyCastle)       | 8KB          |    94.485 μs |  0.0886 μs |  0.0828 μs |     390 B |   21584 B |
| Encrypt · Camellia-256-GCM (CryptoHives-Scalar) | 8KB          |   140.246 μs |  0.2508 μs |  0.2346 μs |     390 B |         - |
|                                                 |              |              |            |            |           |           |
| Decrypt · Camellia-256-GCM (BouncyCastle)       | 128KB        | 1,492.086 μs |  1.4987 μs |  1.3286 μs |     310 B |  328800 B |
| Decrypt · Camellia-256-GCM (CryptoHives-PClMul) | 128KB        | 1,497.643 μs |  2.4375 μs |  2.2800 μs |     310 B |         - |
| Decrypt · Camellia-256-GCM (CryptoHives-Scalar) | 128KB        | 2,252.575 μs | 14.2994 μs | 13.3757 μs |     310 B |         - |
|                                                 |              |              |            |            |           |           |
| Encrypt · Camellia-256-GCM (CryptoHives-PClMul) | 128KB        | 1,487.750 μs |  0.3661 μs |  0.3057 μs |     390 B |         - |
| Encrypt · Camellia-256-GCM (BouncyCastle)       | 128KB        | 1,517.295 μs |  1.6021 μs |  1.4986 μs |     390 B |  328784 B |
| Encrypt · Camellia-256-GCM (CryptoHives-Scalar) | 128KB        | 2,256.599 μs | 12.3173 μs | 10.9190 μs |     390 B |         - |