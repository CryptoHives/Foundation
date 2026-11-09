| Description                                     | TestDataSize | Mean         | Error      | StdDev     | Code Size | Allocated |
|------------------------------------------------ |------------- |-------------:|-----------:|-----------:|----------:|----------:|
| Decrypt · Camellia-256-GCM (CryptoHives-PClMul) | 128B         |     1.417 μs |  0.0123 μs |  0.0115 μs |     310 B |         - |
| Decrypt · Camellia-256-GCM (BouncyCastle)       | 128B         |     2.095 μs |  0.0141 μs |  0.0132 μs |     310 B |    1440 B |
| Decrypt · Camellia-256-GCM (CryptoHives-Scalar) | 128B         |     2.225 μs |  0.0237 μs |  0.0222 μs |     310 B |         - |
|                                                 |              |              |            |            |           |           |
| Encrypt · Camellia-256-GCM (CryptoHives-PClMul) | 128B         |     1.302 μs |  0.0073 μs |  0.0068 μs |     390 B |         - |
| Encrypt · Camellia-256-GCM (BouncyCastle)       | 128B         |     1.919 μs |  0.0094 μs |  0.0088 μs |     390 B |    1424 B |
| Encrypt · Camellia-256-GCM (CryptoHives-Scalar) | 128B         |     2.091 μs |  0.0036 μs |  0.0034 μs |     387 B |         - |
|                                                 |              |              |            |            |           |           |
| Decrypt · Camellia-256-GCM (CryptoHives-PClMul) | 1KB          |     9.400 μs |  0.0762 μs |  0.0712 μs |     310 B |         - |
| Decrypt · Camellia-256-GCM (BouncyCastle)       | 1KB          |    10.927 μs |  0.1106 μs |  0.1035 μs |     310 B |    3680 B |
| Decrypt · Camellia-256-GCM (CryptoHives-Scalar) | 1KB          |    14.904 μs |  0.1343 μs |  0.1256 μs |     310 B |         - |
|                                                 |              |              |            |            |           |           |
| Encrypt · Camellia-256-GCM (CryptoHives-PClMul) | 1KB          |     9.103 μs |  0.0284 μs |  0.0237 μs |     387 B |         - |
| Encrypt · Camellia-256-GCM (BouncyCastle)       | 1KB          |    10.632 μs |  0.0953 μs |  0.0795 μs |     387 B |    3664 B |
| Encrypt · Camellia-256-GCM (CryptoHives-Scalar) | 1KB          |    14.582 μs |  0.0365 μs |  0.0341 μs |     390 B |         - |
|                                                 |              |              |            |            |           |           |
| Decrypt · Camellia-256-GCM (CryptoHives-PClMul) | 8KB          |    73.315 μs |  0.6948 μs |  0.6499 μs |     310 B |         - |
| Decrypt · Camellia-256-GCM (BouncyCastle)       | 8KB          |    82.290 μs |  0.7525 μs |  0.7039 μs |     310 B |   21600 B |
| Decrypt · Camellia-256-GCM (CryptoHives-Scalar) | 8KB          |   117.659 μs |  0.8562 μs |  0.7590 μs |     310 B |         - |
|                                                 |              |              |            |            |           |           |
| Encrypt · Camellia-256-GCM (CryptoHives-PClMul) | 8KB          |    71.564 μs |  0.2912 μs |  0.2724 μs |     387 B |         - |
| Encrypt · Camellia-256-GCM (BouncyCastle)       | 8KB          |    80.117 μs |  0.2316 μs |  0.2167 μs |     387 B |   21584 B |
| Encrypt · Camellia-256-GCM (CryptoHives-Scalar) | 8KB          |   114.481 μs |  0.5961 μs |  0.5284 μs |     387 B |         - |
|                                                 |              |              |            |            |           |           |
| Decrypt · Camellia-256-GCM (CryptoHives-PClMul) | 128KB        | 1,166.325 μs | 10.5684 μs |  9.8857 μs |     310 B |         - |
| Decrypt · Camellia-256-GCM (BouncyCastle)       | 128KB        | 1,284.681 μs | 13.8206 μs | 12.9278 μs |     310 B |  328800 B |
| Decrypt · Camellia-256-GCM (CryptoHives-Scalar) | 128KB        | 1,873.172 μs | 16.6248 μs | 15.5509 μs |     310 B |         - |
|                                                 |              |              |            |            |           |           |
| Encrypt · Camellia-256-GCM (CryptoHives-PClMul) | 128KB        | 1,167.265 μs | 12.4813 μs | 11.6750 μs |     387 B |         - |
| Encrypt · Camellia-256-GCM (BouncyCastle)       | 128KB        | 1,297.627 μs | 14.6033 μs | 13.6600 μs |     387 B |  328784 B |
| Encrypt · Camellia-256-GCM (CryptoHives-Scalar) | 128KB        | 1,882.738 μs | 17.5088 μs | 16.3777 μs |     387 B |         - |