| Description                                     | TestDataSize | Mean         | Error      | StdDev     | Median       | Code Size | Allocated |
|------------------------------------------------ |------------- |-------------:|-----------:|-----------:|-------------:|----------:|----------:|
| Decrypt · Camellia-128-GCM (CryptoHives-PClMul) | 128B         |     1.426 μs |  0.0014 μs |  0.0013 μs |     1.426 μs |     310 B |         - |
| Decrypt · Camellia-128-GCM (BouncyCastle)       | 128B         |     2.242 μs |  0.0029 μs |  0.0026 μs |     2.242 μs |     310 B |    1408 B |
| Decrypt · Camellia-128-GCM (CryptoHives-Scalar) | 128B         |     2.498 μs |  0.0107 μs |  0.0084 μs |     2.497 μs |     310 B |         - |
|                                                 |              |              |            |            |              |           |           |
| Encrypt · Camellia-128-GCM (CryptoHives-PClMul) | 128B         |     1.344 μs |  0.0011 μs |  0.0010 μs |     1.345 μs |     387 B |         - |
| Encrypt · Camellia-128-GCM (BouncyCastle)       | 128B         |     2.090 μs |  0.0028 μs |  0.0024 μs |     2.089 μs |     390 B |    1392 B |
| Encrypt · Camellia-128-GCM (CryptoHives-Scalar) | 128B         |     2.397 μs |  0.0200 μs |  0.0177 μs |     2.394 μs |     387 B |         - |
|                                                 |              |              |            |            |              |           |           |
| Decrypt · Camellia-128-GCM (CryptoHives-PClMul) | 1KB          |     9.472 μs |  0.0055 μs |  0.0051 μs |     9.472 μs |     310 B |         - |
| Decrypt · Camellia-128-GCM (BouncyCastle)       | 1KB          |    11.210 μs |  0.0275 μs |  0.0258 μs |    11.197 μs |     310 B |    3648 B |
| Decrypt · Camellia-128-GCM (CryptoHives-Scalar) | 1KB          |    16.777 μs |  0.0805 μs |  0.0672 μs |    16.773 μs |     310 B |         - |
|                                                 |              |              |            |            |              |           |           |
| Encrypt · Camellia-128-GCM (CryptoHives-PClMul) | 1KB          |     9.287 μs |  0.0083 μs |  0.0073 μs |     9.286 μs |     390 B |         - |
| Encrypt · Camellia-128-GCM (BouncyCastle)       | 1KB          |    10.986 μs |  0.0121 μs |  0.0107 μs |    10.984 μs |     387 B |    3632 B |
| Encrypt · Camellia-128-GCM (CryptoHives-Scalar) | 1KB          |    16.773 μs |  0.1182 μs |  0.1048 μs |    16.747 μs |     390 B |         - |
|                                                 |              |              |            |            |              |           |           |
| Decrypt · Camellia-128-GCM (CryptoHives-PClMul) | 8KB          |    72.983 μs |  0.0522 μs |  0.0488 μs |    73.003 μs |     310 B |         - |
| Decrypt · Camellia-128-GCM (BouncyCastle)       | 8KB          |    84.290 μs |  0.1742 μs |  0.1630 μs |    84.272 μs |     310 B |   21568 B |
| Decrypt · Camellia-128-GCM (CryptoHives-Scalar) | 8KB          |   132.627 μs |  1.6763 μs |  1.5680 μs |   131.981 μs |     310 B |         - |
|                                                 |              |              |            |            |              |           |           |
| Encrypt · Camellia-128-GCM (CryptoHives-PClMul) | 8KB          |    73.927 μs |  0.0426 μs |  0.0399 μs |    73.934 μs |     387 B |         - |
| Encrypt · Camellia-128-GCM (BouncyCastle)       | 8KB          |    83.118 μs |  0.0986 μs |  0.0823 μs |    83.116 μs |     387 B |   21552 B |
| Encrypt · Camellia-128-GCM (CryptoHives-Scalar) | 8KB          |   131.747 μs |  1.2630 μs |  1.1814 μs |   131.313 μs |     387 B |         - |
|                                                 |              |              |            |            |              |           |           |
| Decrypt · Camellia-128-GCM (CryptoHives-PClMul) | 128KB        | 1,165.906 μs |  2.0454 μs |  1.8132 μs | 1,165.359 μs |     310 B |         - |
| Decrypt · Camellia-128-GCM (BouncyCastle)       | 128KB        | 1,324.398 μs |  1.1803 μs |  0.9856 μs | 1,324.420 μs |     310 B |  328768 B |
| Decrypt · Camellia-128-GCM (CryptoHives-Scalar) | 128KB        | 2,084.106 μs | 11.7276 μs |  9.1562 μs | 2,081.748 μs |     310 B |         - |
|                                                 |              |              |            |            |              |           |           |
| Encrypt · Camellia-128-GCM (CryptoHives-PClMul) | 128KB        | 1,180.679 μs |  9.3608 μs |  8.7561 μs | 1,173.602 μs |     387 B |         - |
| Encrypt · Camellia-128-GCM (BouncyCastle)       | 128KB        | 1,324.644 μs |  1.0240 μs |  0.8551 μs | 1,324.635 μs |     387 B |  328752 B |
| Encrypt · Camellia-128-GCM (CryptoHives-Scalar) | 128KB        | 2,101.207 μs | 16.7133 μs | 14.8159 μs | 2,098.174 μs |     387 B |         - |