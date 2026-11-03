| Description                                 | TestDataSize | Mean         | Error      | StdDev     | Code Size | Allocated |
|-------------------------------------------- |------------- |-------------:|-----------:|-----------:|----------:|----------:|
| Decrypt · ARIA-256-GCM (CryptoHives-PClMul) | 128B         |     2.170 μs |  0.0097 μs |  0.0091 μs |     306 B |         - |
| Decrypt · ARIA-256-GCM (CryptoHives-Scalar) | 128B         |     2.609 μs |  0.0050 μs |  0.0047 μs |     306 B |         - |
| Decrypt · ARIA-256-GCM (BouncyCastle)       | 128B         |     4.023 μs |  0.0178 μs |  0.0166 μs |     306 B |    2264 B |
|                                             |              |              |            |            |           |           |
| Encrypt · ARIA-256-GCM (CryptoHives-PClMul) | 128B         |     2.128 μs |  0.0131 μs |  0.0123 μs |     383 B |         - |
| Encrypt · ARIA-256-GCM (CryptoHives-Scalar) | 128B         |     2.569 μs |  0.0077 μs |  0.0072 μs |     383 B |         - |
| Encrypt · ARIA-256-GCM (BouncyCastle)       | 128B         |     3.918 μs |  0.0141 μs |  0.0132 μs |     383 B |    2248 B |
|                                             |              |              |            |            |           |           |
| Decrypt · ARIA-256-GCM (CryptoHives-PClMul) | 1KB          |    15.223 μs |  0.0725 μs |  0.0678 μs |     306 B |         - |
| Decrypt · ARIA-256-GCM (CryptoHives-Scalar) | 1KB          |    18.084 μs |  0.0728 μs |  0.0681 μs |     306 B |         - |
| Decrypt · ARIA-256-GCM (BouncyCastle)       | 1KB          |    22.850 μs |  0.0426 μs |  0.0378 μs |     306 B |    4504 B |
|                                             |              |              |            |            |           |           |
| Encrypt · ARIA-256-GCM (CryptoHives-PClMul) | 1KB          |    15.173 μs |  0.0241 μs |  0.0214 μs |     383 B |         - |
| Encrypt · ARIA-256-GCM (CryptoHives-Scalar) | 1KB          |    18.108 μs |  0.0924 μs |  0.0864 μs |     383 B |         - |
| Encrypt · ARIA-256-GCM (BouncyCastle)       | 1KB          |    22.896 μs |  0.0648 μs |  0.0606 μs |     383 B |    4488 B |
|                                             |              |              |            |            |           |           |
| Decrypt · ARIA-256-GCM (CryptoHives-PClMul) | 8KB          |   119.024 μs |  0.2796 μs |  0.2616 μs |     306 B |         - |
| Decrypt · ARIA-256-GCM (CryptoHives-Scalar) | 8KB          |   142.174 μs |  0.5472 μs |  0.5118 μs |     306 B |         - |
| Decrypt · ARIA-256-GCM (BouncyCastle)       | 8KB          |   176.815 μs |  0.2924 μs |  0.2592 μs |     306 B |   22424 B |
|                                             |              |              |            |            |           |           |
| Encrypt · ARIA-256-GCM (CryptoHives-PClMul) | 8KB          |   119.271 μs |  0.2449 μs |  0.2171 μs |     383 B |         - |
| Encrypt · ARIA-256-GCM (CryptoHives-Scalar) | 8KB          |   142.205 μs |  0.7265 μs |  0.6796 μs |     383 B |         - |
| Encrypt · ARIA-256-GCM (BouncyCastle)       | 8KB          |   174.445 μs |  0.5966 μs |  0.5581 μs |     383 B |   22408 B |
|                                             |              |              |            |            |           |           |
| Decrypt · ARIA-256-GCM (CryptoHives-PClMul) | 128KB        | 1,904.352 μs |  5.8972 μs |  5.2277 μs |     306 B |         - |
| Decrypt · ARIA-256-GCM (CryptoHives-Scalar) | 128KB        | 2,263.881 μs | 11.6025 μs | 10.8530 μs |     306 B |         - |
| Decrypt · ARIA-256-GCM (BouncyCastle)       | 128KB        | 2,763.546 μs |  4.4696 μs |  3.9622 μs |     306 B |  329624 B |
|                                             |              |              |            |            |           |           |
| Encrypt · ARIA-256-GCM (CryptoHives-PClMul) | 128KB        | 1,906.856 μs |  3.0771 μs |  2.8783 μs |     383 B |         - |
| Encrypt · ARIA-256-GCM (CryptoHives-Scalar) | 128KB        | 2,280.717 μs |  7.3764 μs |  6.8998 μs |     383 B |         - |
| Encrypt · ARIA-256-GCM (BouncyCastle)       | 128KB        | 2,772.834 μs |  6.8630 μs |  5.7309 μs |     383 B |  329608 B |