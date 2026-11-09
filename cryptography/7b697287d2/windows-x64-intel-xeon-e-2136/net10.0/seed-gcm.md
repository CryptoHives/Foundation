| Description                             | TestDataSize | Mean         | Error      | StdDev     | Code Size | Allocated |
|---------------------------------------- |------------- |-------------:|-----------:|-----------:|----------:|----------:|
| Decrypt · SEED-GCM (CryptoHives-PClMul) | 128B         |     1.609 μs |  0.0251 μs |  0.0235 μs |     310 B |         - |
| Decrypt · SEED-GCM (BouncyCastle)       | 128B         |     2.182 μs |  0.0291 μs |  0.0272 μs |     310 B |     944 B |
| Decrypt · SEED-GCM (CryptoHives-Scalar) | 128B         |     2.412 μs |  0.0307 μs |  0.0287 μs |     310 B |         - |
|                                         |              |              |            |            |           |           |
| Encrypt · SEED-GCM (CryptoHives-PClMul) | 128B         |     1.545 μs |  0.0221 μs |  0.0207 μs |     387 B |         - |
| Encrypt · SEED-GCM (BouncyCastle)       | 128B         |     2.023 μs |  0.0282 μs |  0.0264 μs |     390 B |     928 B |
| Encrypt · SEED-GCM (CryptoHives-Scalar) | 128B         |     2.333 μs |  0.0328 μs |  0.0307 μs |     387 B |         - |
|                                         |              |              |            |            |           |           |
| Decrypt · SEED-GCM (CryptoHives-PClMul) | 1KB          |    10.841 μs |  0.0659 μs |  0.0584 μs |     310 B |         - |
| Decrypt · SEED-GCM (BouncyCastle)       | 1KB          |    11.699 μs |  0.1827 μs |  0.1709 μs |     310 B |     944 B |
| Decrypt · SEED-GCM (CryptoHives-Scalar) | 1KB          |    16.251 μs |  0.3021 μs |  0.2826 μs |     310 B |         - |
|                                         |              |              |            |            |           |           |
| Encrypt · SEED-GCM (CryptoHives-PClMul) | 1KB          |    10.691 μs |  0.1525 μs |  0.1427 μs |     387 B |         - |
| Encrypt · SEED-GCM (BouncyCastle)       | 1KB          |    11.592 μs |  0.1346 μs |  0.1259 μs |     390 B |     928 B |
| Encrypt · SEED-GCM (CryptoHives-Scalar) | 1KB          |    16.306 μs |  0.1123 μs |  0.1051 μs |     387 B |         - |
|                                         |              |              |            |            |           |           |
| Decrypt · SEED-GCM (CryptoHives-PClMul) | 8KB          |    84.322 μs |  1.1242 μs |  1.0515 μs |     310 B |         - |
| Decrypt · SEED-GCM (BouncyCastle)       | 8KB          |    87.889 μs |  1.5581 μs |  1.4575 μs |     310 B |     944 B |
| Decrypt · SEED-GCM (CryptoHives-Scalar) | 8KB          |   127.254 μs |  2.1172 μs |  1.9804 μs |     310 B |         - |
|                                         |              |              |            |            |           |           |
| Encrypt · SEED-GCM (CryptoHives-PClMul) | 8KB          |    83.954 μs |  1.1827 μs |  1.1063 μs |     387 B |         - |
| Encrypt · SEED-GCM (BouncyCastle)       | 8KB          |    87.967 μs |  1.4924 μs |  1.3960 μs |     387 B |     928 B |
| Encrypt · SEED-GCM (CryptoHives-Scalar) | 8KB          |   127.095 μs |  2.0750 μs |  1.9410 μs |     387 B |         - |
|                                         |              |              |            |            |           |           |
| Decrypt · SEED-GCM (CryptoHives-PClMul) | 128KB        | 1,351.080 μs | 16.2787 μs | 15.2271 μs |     310 B |         - |
| Decrypt · SEED-GCM (BouncyCastle)       | 128KB        | 1,396.575 μs | 18.1938 μs | 17.0185 μs |     310 B |     944 B |
| Decrypt · SEED-GCM (CryptoHives-Scalar) | 128KB        | 2,036.365 μs | 31.0960 μs | 29.0872 μs |     310 B |         - |
|                                         |              |              |            |            |           |           |
| Encrypt · SEED-GCM (CryptoHives-PClMul) | 128KB        | 1,345.337 μs | 23.7765 μs | 22.2405 μs |     387 B |         - |
| Encrypt · SEED-GCM (BouncyCastle)       | 128KB        | 1,396.061 μs | 22.3336 μs | 20.8908 μs |     387 B |     928 B |
| Encrypt · SEED-GCM (CryptoHives-Scalar) | 128KB        | 2,038.030 μs | 32.9311 μs | 30.8038 μs |     387 B |         - |