| Description                             | TestDataSize | Mean         | Error     | StdDev    | Code Size | Allocated |
|---------------------------------------- |------------- |-------------:|----------:|----------:|----------:|----------:|
| Decrypt · SEED-GCM (CryptoHives-PClMul) | 128B         |     2.107 μs | 0.0015 μs | 0.0014 μs |     310 B |         - |
| Decrypt · SEED-GCM (BouncyCastle)       | 128B         |     2.846 μs | 0.0010 μs | 0.0008 μs |     310 B |     944 B |
| Decrypt · SEED-GCM (CryptoHives-Scalar) | 128B         |     3.146 μs | 0.0023 μs | 0.0021 μs |     310 B |         - |
|                                         |              |              |           |           |           |           |
| Encrypt · SEED-GCM (CryptoHives-PClMul) | 128B         |     2.015 μs | 0.0014 μs | 0.0013 μs |     387 B |         - |
| Encrypt · SEED-GCM (BouncyCastle)       | 128B         |     2.656 μs | 0.0030 μs | 0.0027 μs |     390 B |     928 B |
| Encrypt · SEED-GCM (CryptoHives-Scalar) | 128B         |     3.060 μs | 0.0045 μs | 0.0042 μs |     387 B |         - |
|                                         |              |              |           |           |           |           |
| Decrypt · SEED-GCM (CryptoHives-PClMul) | 1KB          |    14.139 μs | 0.0050 μs | 0.0047 μs |     310 B |         - |
| Decrypt · SEED-GCM (BouncyCastle)       | 1KB          |    15.391 μs | 0.0085 μs | 0.0075 μs |     310 B |     944 B |
| Decrypt · SEED-GCM (CryptoHives-Scalar) | 1KB          |    21.432 μs | 0.1022 μs | 0.0906 μs |     310 B |         - |
|                                         |              |              |           |           |           |           |
| Encrypt · SEED-GCM (CryptoHives-PClMul) | 1KB          |    14.037 μs | 0.0037 μs | 0.0035 μs |     387 B |         - |
| Encrypt · SEED-GCM (BouncyCastle)       | 1KB          |    15.218 μs | 0.0077 μs | 0.0069 μs |     387 B |     928 B |
| Encrypt · SEED-GCM (CryptoHives-Scalar) | 1KB          |    21.297 μs | 0.0301 μs | 0.0281 μs |     387 B |         - |
|                                         |              |              |           |           |           |           |
| Decrypt · SEED-GCM (CryptoHives-PClMul) | 8KB          |   110.513 μs | 0.0365 μs | 0.0341 μs |     310 B |         - |
| Decrypt · SEED-GCM (BouncyCastle)       | 8KB          |   115.662 μs | 0.0721 μs | 0.0639 μs |     310 B |     944 B |
| Decrypt · SEED-GCM (CryptoHives-Scalar) | 8KB          |   168.108 μs | 1.0056 μs | 0.8914 μs |     310 B |         - |
|                                         |              |              |           |           |           |           |
| Encrypt · SEED-GCM (CryptoHives-PClMul) | 8KB          |   110.311 μs | 0.0607 μs | 0.0568 μs |     387 B |         - |
| Encrypt · SEED-GCM (BouncyCastle)       | 8KB          |   115.638 μs | 0.0483 μs | 0.0428 μs |     387 B |     928 B |
| Encrypt · SEED-GCM (CryptoHives-Scalar) | 8KB          |   167.204 μs | 0.1013 μs | 0.0846 μs |     387 B |         - |
|                                         |              |              |           |           |           |           |
| Decrypt · SEED-GCM (CryptoHives-PClMul) | 128KB        | 1,770.317 μs | 0.5748 μs | 0.5376 μs |     310 B |         - |
| Decrypt · SEED-GCM (BouncyCastle)       | 128KB        | 1,832.919 μs | 0.3393 μs | 0.3174 μs |     310 B |     944 B |
| Decrypt · SEED-GCM (CryptoHives-Scalar) | 128KB        | 2,678.846 μs | 5.1092 μs | 4.7792 μs |     310 B |         - |
|                                         |              |              |           |           |           |           |
| Encrypt · SEED-GCM (CryptoHives-PClMul) | 128KB        | 1,774.019 μs | 0.9092 μs | 0.8060 μs |     387 B |         - |
| Encrypt · SEED-GCM (BouncyCastle)       | 128KB        | 1,834.409 μs | 0.3480 μs | 0.3255 μs |     387 B |     928 B |
| Encrypt · SEED-GCM (CryptoHives-Scalar) | 128KB        | 2,682.119 μs | 3.8526 μs | 3.2171 μs |     387 B |         - |