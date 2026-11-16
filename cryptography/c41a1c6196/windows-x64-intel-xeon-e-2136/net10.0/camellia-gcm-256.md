| Description                                     | TestDataSize | Mean         | Error      | StdDev     | Code Size | Allocated |
|------------------------------------------------ |------------- |-------------:|-----------:|-----------:|----------:|----------:|
| Decrypt · Camellia-256-GCM (CryptoHives-PClMul) | 128B         |     1.833 μs |  0.0011 μs |  0.0008 μs |     310 B |         - |
| Decrypt · Camellia-256-GCM (BouncyCastle)       | 128B         |     2.728 μs |  0.0038 μs |  0.0032 μs |     310 B |    1440 B |
| Decrypt · Camellia-256-GCM (CryptoHives-Scalar) | 128B         |     2.888 μs |  0.0071 μs |  0.0055 μs |     310 B |         - |
|                                                 |              |              |            |            |           |           |
| Encrypt · Camellia-256-GCM (CryptoHives-PClMul) | 128B         |     1.734 μs |  0.0010 μs |  0.0008 μs |     390 B |         - |
| Encrypt · Camellia-256-GCM (BouncyCastle)       | 128B         |     2.538 μs |  0.0031 μs |  0.0029 μs |     387 B |    1424 B |
| Encrypt · Camellia-256-GCM (CryptoHives-Scalar) | 128B         |     2.780 μs |  0.0108 μs |  0.0096 μs |     387 B |         - |
|                                                 |              |              |            |            |           |           |
| Decrypt · Camellia-256-GCM (CryptoHives-PClMul) | 1KB          |    12.130 μs |  0.0024 μs |  0.0021 μs |     310 B |         - |
| Decrypt · Camellia-256-GCM (BouncyCastle)       | 1KB          |    14.209 μs |  0.0224 μs |  0.0210 μs |     310 B |    3680 B |
| Decrypt · Camellia-256-GCM (CryptoHives-Scalar) | 1KB          |    19.575 μs |  0.0693 μs |  0.0615 μs |     310 B |         - |
|                                                 |              |              |            |            |           |           |
| Encrypt · Camellia-256-GCM (CryptoHives-PClMul) | 1KB          |    12.022 μs |  0.0066 μs |  0.0052 μs |     387 B |         - |
| Encrypt · Camellia-256-GCM (BouncyCastle)       | 1KB          |    13.985 μs |  0.0127 μs |  0.0119 μs |     387 B |    3664 B |
| Encrypt · Camellia-256-GCM (CryptoHives-Scalar) | 1KB          |    19.446 μs |  0.1147 μs |  0.1017 μs |     390 B |         - |
|                                                 |              |              |            |            |           |           |
| Decrypt · Camellia-256-GCM (CryptoHives-PClMul) | 8KB          |    95.076 μs |  0.0435 μs |  0.0385 μs |     310 B |         - |
| Decrypt · Camellia-256-GCM (BouncyCastle)       | 8KB          |   106.110 μs |  0.2057 μs |  0.1924 μs |     310 B |   21600 B |
| Decrypt · Camellia-256-GCM (CryptoHives-Scalar) | 8KB          |   155.443 μs |  1.1452 μs |  1.0712 μs |     310 B |         - |
|                                                 |              |              |            |            |           |           |
| Encrypt · Camellia-256-GCM (CryptoHives-PClMul) | 8KB          |    94.501 μs |  0.0403 μs |  0.0377 μs |     387 B |         - |
| Encrypt · Camellia-256-GCM (BouncyCastle)       | 8KB          |   106.062 μs |  0.1461 μs |  0.1366 μs |     387 B |   21584 B |
| Encrypt · Camellia-256-GCM (CryptoHives-Scalar) | 8KB          |   153.499 μs |  0.9381 μs |  0.8775 μs |     387 B |         - |
|                                                 |              |              |            |            |           |           |
| Decrypt · Camellia-256-GCM (CryptoHives-PClMul) | 128KB        | 1,514.824 μs |  1.1362 μs |  1.0072 μs |     310 B |         - |
| Decrypt · Camellia-256-GCM (BouncyCastle)       | 128KB        | 1,671.854 μs |  2.2096 μs |  1.8451 μs |     310 B |  328800 B |
| Decrypt · Camellia-256-GCM (CryptoHives-Scalar) | 128KB        | 2,447.451 μs | 18.8227 μs | 16.6858 μs |     310 B |         - |
|                                                 |              |              |            |            |           |           |
| Encrypt · Camellia-256-GCM (CryptoHives-PClMul) | 128KB        | 1,519.772 μs |  0.3511 μs |  0.3284 μs |     387 B |         - |
| Encrypt · Camellia-256-GCM (BouncyCastle)       | 128KB        | 1,670.829 μs |  1.7173 μs |  1.4340 μs |     387 B |  328784 B |
| Encrypt · Camellia-256-GCM (CryptoHives-Scalar) | 128KB        | 2,451.705 μs | 13.2069 μs | 11.7076 μs |     387 B |         - |