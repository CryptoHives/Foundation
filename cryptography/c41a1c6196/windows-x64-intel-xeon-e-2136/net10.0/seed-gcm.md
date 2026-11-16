| Description                             | TestDataSize | Mean         | Error      | StdDev     | Code Size | Allocated |
|---------------------------------------- |------------- |-------------:|-----------:|-----------:|----------:|----------:|
| Decrypt · SEED-GCM (CryptoHives-PClMul) | 128B         |     2.100 μs |  0.0030 μs |  0.0027 μs |     310 B |         - |
| Decrypt · SEED-GCM (BouncyCastle)       | 128B         |     2.843 μs |  0.0053 μs |  0.0050 μs |     310 B |     944 B |
| Decrypt · SEED-GCM (CryptoHives-Scalar) | 128B         |     3.142 μs |  0.0055 μs |  0.0046 μs |     310 B |         - |
|                                         |              |              |            |            |           |           |
| Encrypt · SEED-GCM (CryptoHives-PClMul) | 128B         |     2.016 μs |  0.0026 μs |  0.0023 μs |     387 B |         - |
| Encrypt · SEED-GCM (BouncyCastle)       | 128B         |     2.651 μs |  0.0026 μs |  0.0023 μs |     387 B |     928 B |
| Encrypt · SEED-GCM (CryptoHives-Scalar) | 128B         |     3.066 μs |  0.0153 μs |  0.0143 μs |     387 B |         - |
|                                         |              |              |            |            |           |           |
| Decrypt · SEED-GCM (CryptoHives-PClMul) | 1KB          |    14.129 μs |  0.0040 μs |  0.0033 μs |     310 B |         - |
| Decrypt · SEED-GCM (BouncyCastle)       | 1KB          |    15.383 μs |  0.0116 μs |  0.0102 μs |     310 B |     944 B |
| Decrypt · SEED-GCM (CryptoHives-Scalar) | 1KB          |    21.489 μs |  0.1396 μs |  0.1306 μs |     310 B |         - |
|                                         |              |              |            |            |           |           |
| Encrypt · SEED-GCM (CryptoHives-PClMul) | 1KB          |    14.036 μs |  0.0063 μs |  0.0056 μs |     387 B |         - |
| Encrypt · SEED-GCM (BouncyCastle)       | 1KB          |    15.183 μs |  0.0067 μs |  0.0052 μs |     387 B |     928 B |
| Encrypt · SEED-GCM (CryptoHives-Scalar) | 1KB          |    21.461 μs |  0.1921 μs |  0.1797 μs |     387 B |         - |
|                                         |              |              |            |            |           |           |
| Decrypt · SEED-GCM (CryptoHives-PClMul) | 8KB          |   110.431 μs |  0.1011 μs |  0.0945 μs |     310 B |         - |
| Decrypt · SEED-GCM (BouncyCastle)       | 8KB          |   115.572 μs |  0.0122 μs |  0.0108 μs |     310 B |     944 B |
| Decrypt · SEED-GCM (CryptoHives-Scalar) | 8KB          |   168.498 μs |  1.1719 μs |  1.0962 μs |     310 B |         - |
|                                         |              |              |            |            |           |           |
| Encrypt · SEED-GCM (CryptoHives-PClMul) | 8KB          |   110.251 μs |  0.0834 μs |  0.0780 μs |     387 B |         - |
| Encrypt · SEED-GCM (BouncyCastle)       | 8KB          |   115.571 μs |  0.0286 μs |  0.0253 μs |     387 B |     928 B |
| Encrypt · SEED-GCM (CryptoHives-Scalar) | 8KB          |   167.642 μs |  0.7584 μs |  0.6723 μs |     387 B |         - |
|                                         |              |              |            |            |           |           |
| Decrypt · SEED-GCM (CryptoHives-PClMul) | 128KB        | 1,768.653 μs |  0.4084 μs |  0.3820 μs |     310 B |         - |
| Decrypt · SEED-GCM (BouncyCastle)       | 128KB        | 1,832.336 μs |  0.5765 μs |  0.5393 μs |     310 B |     944 B |
| Decrypt · SEED-GCM (CryptoHives-Scalar) | 128KB        | 2,679.378 μs |  7.3051 μs |  6.1001 μs |     310 B |         - |
|                                         |              |              |            |            |           |           |
| Encrypt · SEED-GCM (CryptoHives-PClMul) | 128KB        | 1,772.725 μs |  0.7546 μs |  0.7058 μs |     387 B |         - |
| Encrypt · SEED-GCM (BouncyCastle)       | 128KB        | 1,833.988 μs |  0.2178 μs |  0.1819 μs |     387 B |     928 B |
| Encrypt · SEED-GCM (CryptoHives-Scalar) | 128KB        | 2,689.254 μs | 20.1013 μs | 17.8192 μs |     387 B |         - |