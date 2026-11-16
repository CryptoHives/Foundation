| Description                                 | TestDataSize | Mean         | Error      | StdDev     | Code Size | Allocated |
|-------------------------------------------- |------------- |-------------:|-----------:|-----------:|----------:|----------:|
| Decrypt · ARIA-256-GCM (CryptoHives-PClMul) | 128B         |     2.170 μs |  0.0085 μs |  0.0076 μs |     306 B |         - |
| Decrypt · ARIA-256-GCM (CryptoHives-Scalar) | 128B         |     2.611 μs |  0.0068 μs |  0.0060 μs |     306 B |         - |
| Decrypt · ARIA-256-GCM (BouncyCastle)       | 128B         |     3.996 μs |  0.0082 μs |  0.0076 μs |     306 B |    2264 B |
|                                             |              |              |            |            |           |           |
| Encrypt · ARIA-256-GCM (CryptoHives-PClMul) | 128B         |     2.126 μs |  0.0058 μs |  0.0054 μs |     383 B |         - |
| Encrypt · ARIA-256-GCM (CryptoHives-Scalar) | 128B         |     2.565 μs |  0.0087 μs |  0.0082 μs |     383 B |         - |
| Encrypt · ARIA-256-GCM (BouncyCastle)       | 128B         |     3.894 μs |  0.0094 μs |  0.0084 μs |     386 B |    2248 B |
|                                             |              |              |            |            |           |           |
| Decrypt · ARIA-256-GCM (CryptoHives-PClMul) | 1KB          |    15.151 μs |  0.0392 μs |  0.0347 μs |     306 B |         - |
| Decrypt · ARIA-256-GCM (CryptoHives-Scalar) | 1KB          |    18.065 μs |  0.0510 μs |  0.0477 μs |     306 B |         - |
| Decrypt · ARIA-256-GCM (BouncyCastle)       | 1KB          |    22.843 μs |  0.0671 μs |  0.0594 μs |     306 B |    4504 B |
|                                             |              |              |            |            |           |           |
| Encrypt · ARIA-256-GCM (CryptoHives-PClMul) | 1KB          |    15.155 μs |  0.0427 μs |  0.0378 μs |     383 B |         - |
| Encrypt · ARIA-256-GCM (CryptoHives-Scalar) | 1KB          |    18.119 μs |  0.1023 μs |  0.0957 μs |     383 B |         - |
| Encrypt · ARIA-256-GCM (BouncyCastle)       | 1KB          |    22.780 μs |  0.0570 μs |  0.0476 μs |     383 B |    4488 B |
|                                             |              |              |            |            |           |           |
| Decrypt · ARIA-256-GCM (CryptoHives-PClMul) | 8KB          |   118.914 μs |  0.2292 μs |  0.2144 μs |     306 B |         - |
| Decrypt · ARIA-256-GCM (CryptoHives-Scalar) | 8KB          |   142.202 μs |  0.8277 μs |  0.7742 μs |     306 B |         - |
| Decrypt · ARIA-256-GCM (BouncyCastle)       | 8KB          |   173.885 μs |  0.4750 μs |  0.4443 μs |     306 B |   22424 B |
|                                             |              |              |            |            |           |           |
| Encrypt · ARIA-256-GCM (CryptoHives-PClMul) | 8KB          |   119.192 μs |  0.2378 μs |  0.1986 μs |     383 B |         - |
| Encrypt · ARIA-256-GCM (CryptoHives-Scalar) | 8KB          |   142.290 μs |  0.5582 μs |  0.5221 μs |     383 B |         - |
| Encrypt · ARIA-256-GCM (BouncyCastle)       | 8KB          |   174.216 μs |  0.6949 μs |  0.6500 μs |     383 B |   22408 B |
|                                             |              |              |            |            |           |           |
| Decrypt · ARIA-256-GCM (CryptoHives-PClMul) | 128KB        | 1,898.146 μs |  3.9479 μs |  3.2967 μs |     306 B |         - |
| Decrypt · ARIA-256-GCM (CryptoHives-Scalar) | 128KB        | 2,271.806 μs | 11.5478 μs | 10.8018 μs |     306 B |         - |
| Decrypt · ARIA-256-GCM (BouncyCastle)       | 128KB        | 2,767.940 μs |  4.8332 μs |  3.7734 μs |     306 B |  329624 B |
|                                             |              |              |            |            |           |           |
| Encrypt · ARIA-256-GCM (CryptoHives-PClMul) | 128KB        | 1,897.717 μs |  4.3002 μs |  3.8120 μs |     383 B |         - |
| Encrypt · ARIA-256-GCM (CryptoHives-Scalar) | 128KB        | 2,271.227 μs |  8.9196 μs |  8.3434 μs |     383 B |         - |
| Encrypt · ARIA-256-GCM (BouncyCastle)       | 128KB        | 2,770.503 μs |  5.5720 μs |  5.2120 μs |     383 B |  329608 B |