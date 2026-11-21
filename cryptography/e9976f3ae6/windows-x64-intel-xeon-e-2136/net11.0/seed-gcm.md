| Description                             | TestDataSize | Mean         | Error      | StdDev    | Code Size | Allocated |
|---------------------------------------- |------------- |-------------:|-----------:|----------:|----------:|----------:|
| Decrypt · SEED-GCM (CryptoHives-PClMul) | 128B         |     2.028 μs |  0.0012 μs | 0.0010 μs |     310 B |         - |
| Decrypt · SEED-GCM (BouncyCastle)       | 128B         |     2.738 μs |  0.0036 μs | 0.0032 μs |     310 B |     944 B |
| Decrypt · SEED-GCM (CryptoHives-Scalar) | 128B         |     2.940 μs |  0.0104 μs | 0.0092 μs |     310 B |         - |
|                                         |              |              |            |           |           |           |
| Encrypt · SEED-GCM (CryptoHives-PClMul) | 128B         |     1.940 μs |  0.0023 μs | 0.0021 μs |     390 B |         - |
| Encrypt · SEED-GCM (BouncyCastle)       | 128B         |     2.560 μs |  0.0018 μs | 0.0016 μs |     390 B |     928 B |
| Encrypt · SEED-GCM (CryptoHives-Scalar) | 128B         |     2.864 μs |  0.0179 μs | 0.0167 μs |     390 B |         - |
|                                         |              |              |            |           |           |           |
| Decrypt · SEED-GCM (CryptoHives-PClMul) | 1KB          |    13.517 μs |  0.0013 μs | 0.0012 μs |     310 B |         - |
| Decrypt · SEED-GCM (BouncyCastle)       | 1KB          |    14.711 μs |  0.0053 μs | 0.0047 μs |     310 B |     944 B |
| Decrypt · SEED-GCM (CryptoHives-Scalar) | 1KB          |    19.603 μs |  0.0460 μs | 0.0359 μs |     310 B |         - |
|                                         |              |              |            |           |           |           |
| Encrypt · SEED-GCM (CryptoHives-PClMul) | 1KB          |    13.430 μs |  0.0023 μs | 0.0021 μs |     390 B |         - |
| Encrypt · SEED-GCM (BouncyCastle)       | 1KB          |    14.525 μs |  0.0039 μs | 0.0037 μs |     390 B |     928 B |
| Encrypt · SEED-GCM (CryptoHives-Scalar) | 1KB          |    19.642 μs |  0.1839 μs | 0.1720 μs |     390 B |         - |
|                                         |              |              |            |           |           |           |
| Decrypt · SEED-GCM (CryptoHives-PClMul) | 8KB          |   105.610 μs |  0.0167 μs | 0.0140 μs |     310 B |         - |
| Decrypt · SEED-GCM (BouncyCastle)       | 8KB          |   110.435 μs |  0.0187 μs | 0.0175 μs |     310 B |     944 B |
| Decrypt · SEED-GCM (CryptoHives-Scalar) | 8KB          |   153.322 μs |  0.3475 μs | 0.3081 μs |     310 B |         - |
|                                         |              |              |            |           |           |           |
| Encrypt · SEED-GCM (CryptoHives-PClMul) | 8KB          |   105.430 μs |  0.0206 μs | 0.0182 μs |     390 B |         - |
| Encrypt · SEED-GCM (BouncyCastle)       | 8KB          |   110.113 μs |  0.0372 μs | 0.0330 μs |     390 B |     928 B |
| Encrypt · SEED-GCM (CryptoHives-Scalar) | 8KB          |   152.909 μs |  0.4294 μs | 0.3585 μs |     390 B |         - |
|                                         |              |              |            |           |           |           |
| Decrypt · SEED-GCM (CryptoHives-PClMul) | 128KB        | 1,691.817 μs |  0.2404 μs | 0.2249 μs |     310 B |         - |
| Decrypt · SEED-GCM (BouncyCastle)       | 128KB        | 1,758.808 μs |  0.3509 μs | 0.2930 μs |     310 B |     944 B |
| Decrypt · SEED-GCM (CryptoHives-Scalar) | 128KB        | 2,457.671 μs | 10.4738 μs | 9.7972 μs |     310 B |         - |
|                                         |              |              |            |           |           |           |
| Encrypt · SEED-GCM (CryptoHives-PClMul) | 128KB        | 1,694.772 μs |  0.2553 μs | 0.2263 μs |     390 B |         - |
| Encrypt · SEED-GCM (BouncyCastle)       | 128KB        | 1,750.742 μs |  0.1529 μs | 0.1355 μs |     390 B |     928 B |
| Encrypt · SEED-GCM (CryptoHives-Scalar) | 128KB        | 2,454.382 μs |  9.1053 μs | 8.0716 μs |     390 B |         - |