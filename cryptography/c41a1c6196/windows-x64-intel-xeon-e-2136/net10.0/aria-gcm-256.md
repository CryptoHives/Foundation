| Description                                 | TestDataSize | Mean         | Error      | StdDev     | Code Size | Allocated |
|-------------------------------------------- |------------- |-------------:|-----------:|-----------:|----------:|----------:|
| Decrypt · ARIA-256-GCM (CryptoHives-PClMul) | 128B         |     4.893 μs |  0.0099 μs |  0.0087 μs |     310 B |         - |
| Decrypt · ARIA-256-GCM (CryptoHives-Scalar) | 128B         |     5.949 μs |  0.0151 μs |  0.0118 μs |     310 B |         - |
| Decrypt · ARIA-256-GCM (BouncyCastle)       | 128B         |     6.782 μs |  0.0160 μs |  0.0142 μs |     310 B |    2264 B |
|                                             |              |              |            |            |           |           |
| Encrypt · ARIA-256-GCM (CryptoHives-PClMul) | 128B         |     4.796 μs |  0.0069 μs |  0.0061 μs |     387 B |         - |
| Encrypt · ARIA-256-GCM (CryptoHives-Scalar) | 128B         |     5.851 μs |  0.0111 μs |  0.0093 μs |     390 B |         - |
| Encrypt · ARIA-256-GCM (BouncyCastle)       | 128B         |     6.543 μs |  0.0128 μs |  0.0113 μs |     390 B |    2248 B |
|                                             |              |              |            |            |           |           |
| Decrypt · ARIA-256-GCM (CryptoHives-PClMul) | 1KB          |    34.066 μs |  0.0851 μs |  0.0796 μs |     310 B |         - |
| Decrypt · ARIA-256-GCM (BouncyCastle)       | 1KB          |    36.267 μs |  0.1172 μs |  0.1096 μs |     310 B |    4504 B |
| Decrypt · ARIA-256-GCM (CryptoHives-Scalar) | 1KB          |    41.559 μs |  0.2267 μs |  0.2121 μs |     310 B |         - |
|                                             |              |              |            |            |           |           |
| Encrypt · ARIA-256-GCM (CryptoHives-PClMul) | 1KB          |    33.945 μs |  0.0637 μs |  0.0565 μs |     387 B |         - |
| Encrypt · ARIA-256-GCM (BouncyCastle)       | 1KB          |    36.917 μs |  0.1189 μs |  0.1112 μs |     387 B |    4488 B |
| Encrypt · ARIA-256-GCM (CryptoHives-Scalar) | 1KB          |    41.429 μs |  0.1696 μs |  0.1587 μs |     387 B |         - |
|                                             |              |              |            |            |           |           |
| Decrypt · ARIA-256-GCM (CryptoHives-PClMul) | 8KB          |   266.808 μs |  0.2540 μs |  0.2121 μs |     310 B |         - |
| Decrypt · ARIA-256-GCM (BouncyCastle)       | 8KB          |   272.749 μs |  0.7397 μs |  0.6919 μs |     310 B |   22424 B |
| Decrypt · ARIA-256-GCM (CryptoHives-Scalar) | 8KB          |   325.178 μs |  0.7385 μs |  0.6167 μs |     310 B |         - |
|                                             |              |              |            |            |           |           |
| Encrypt · ARIA-256-GCM (CryptoHives-PClMul) | 8KB          |   266.801 μs |  0.4038 μs |  0.3372 μs |     387 B |         - |
| Encrypt · ARIA-256-GCM (BouncyCastle)       | 8KB          |   271.227 μs |  0.9163 μs |  0.8571 μs |     387 B |   22408 B |
| Encrypt · ARIA-256-GCM (CryptoHives-Scalar) | 8KB          |   324.662 μs |  0.4457 μs |  0.3480 μs |     387 B |         - |
|                                             |              |              |            |            |           |           |
| Decrypt · ARIA-256-GCM (CryptoHives-PClMul) | 128KB        | 4,262.401 μs |  5.2696 μs |  4.1142 μs |     310 B |         - |
| Decrypt · ARIA-256-GCM (BouncyCastle)       | 128KB        | 4,406.585 μs | 16.3032 μs | 15.2500 μs |     310 B |  329624 B |
| Decrypt · ARIA-256-GCM (CryptoHives-Scalar) | 128KB        | 5,204.005 μs | 23.0688 μs | 21.5785 μs |     310 B |         - |
|                                             |              |              |            |            |           |           |
| Encrypt · ARIA-256-GCM (CryptoHives-PClMul) | 128KB        | 4,261.818 μs |  8.3025 μs |  7.3599 μs |     387 B |         - |
| Encrypt · ARIA-256-GCM (BouncyCastle)       | 128KB        | 4,402.966 μs | 19.6344 μs | 18.3660 μs |     387 B |  329608 B |
| Encrypt · ARIA-256-GCM (CryptoHives-Scalar) | 128KB        | 5,191.540 μs | 19.3697 μs | 17.1707 μs |     387 B |         - |