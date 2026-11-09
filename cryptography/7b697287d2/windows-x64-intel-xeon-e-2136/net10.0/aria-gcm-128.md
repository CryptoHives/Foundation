| Description                                 | TestDataSize | Mean         | Error      | StdDev     | Code Size | Allocated |
|-------------------------------------------- |------------- |-------------:|-----------:|-----------:|----------:|----------:|
| Decrypt · ARIA-128-GCM (CryptoHives-PClMul) | 128B         |     2.831 μs |  0.0545 μs |  0.0483 μs |     310 B |         - |
| Decrypt · ARIA-128-GCM (CryptoHives-Scalar) | 128B         |     3.576 μs |  0.0083 μs |  0.0070 μs |     310 B |         - |
| Decrypt · ARIA-128-GCM (BouncyCastle)       | 128B         |     3.945 μs |  0.0181 μs |  0.0169 μs |     310 B |    2040 B |
|                                             |              |              |            |            |           |           |
| Encrypt · ARIA-128-GCM (CryptoHives-PClMul) | 128B         |     2.683 μs |  0.0044 μs |  0.0039 μs |     387 B |         - |
| Encrypt · ARIA-128-GCM (CryptoHives-Scalar) | 128B         |     3.455 μs |  0.0068 μs |  0.0064 μs |     387 B |         - |
| Encrypt · ARIA-128-GCM (BouncyCastle)       | 128B         |     3.820 μs |  0.0243 μs |  0.0190 μs |     387 B |    2024 B |
|                                             |              |              |            |            |           |           |
| Decrypt · ARIA-128-GCM (CryptoHives-PClMul) | 1KB          |    19.171 μs |  0.0885 μs |  0.0785 μs |     310 B |         - |
| Decrypt · ARIA-128-GCM (BouncyCastle)       | 1KB          |    20.740 μs |  0.0731 μs |  0.0648 μs |     310 B |    4280 B |
| Decrypt · ARIA-128-GCM (CryptoHives-Scalar) | 1KB          |    24.554 μs |  0.0650 μs |  0.0608 μs |     310 B |         - |
|                                             |              |              |            |            |           |           |
| Encrypt · ARIA-128-GCM (CryptoHives-PClMul) | 1KB          |    19.298 μs |  0.3780 μs |  0.3882 μs |     387 B |         - |
| Encrypt · ARIA-128-GCM (BouncyCastle)       | 1KB          |    20.725 μs |  0.0759 μs |  0.0673 μs |     387 B |    4264 B |
| Encrypt · ARIA-128-GCM (CryptoHives-Scalar) | 1KB          |    24.677 μs |  0.0972 μs |  0.0759 μs |     387 B |         - |
|                                             |              |              |            |            |           |           |
| Decrypt · ARIA-128-GCM (CryptoHives-PClMul) | 8KB          |   150.228 μs |  0.4952 μs |  0.4632 μs |     310 B |         - |
| Decrypt · ARIA-128-GCM (BouncyCastle)       | 8KB          |   165.247 μs |  0.3691 μs |  0.3082 μs |     310 B |   22200 B |
| Decrypt · ARIA-128-GCM (CryptoHives-Scalar) | 8KB          |   192.673 μs |  1.0286 μs |  0.9621 μs |     310 B |         - |
|                                             |              |              |            |            |           |           |
| Encrypt · ARIA-128-GCM (CryptoHives-PClMul) | 8KB          |   150.022 μs |  0.3757 μs |  0.3515 μs |     387 B |         - |
| Encrypt · ARIA-128-GCM (BouncyCastle)       | 8KB          |   156.670 μs |  0.4220 μs |  0.3524 μs |     387 B |   22184 B |
| Encrypt · ARIA-128-GCM (CryptoHives-Scalar) | 8KB          |   192.211 μs |  0.5862 μs |  0.5483 μs |     387 B |         - |
|                                             |              |              |            |            |           |           |
| Decrypt · ARIA-128-GCM (CryptoHives-PClMul) | 128KB        | 2,400.406 μs | 10.6303 μs |  9.9435 μs |     310 B |         - |
| Decrypt · ARIA-128-GCM (BouncyCastle)       | 128KB        | 2,459.187 μs |  5.6778 μs |  4.7412 μs |     310 B |  329400 B |
| Decrypt · ARIA-128-GCM (CryptoHives-Scalar) | 128KB        | 3,068.213 μs | 13.8683 μs | 12.9724 μs |     310 B |         - |
|                                             |              |              |            |            |           |           |
| Encrypt · ARIA-128-GCM (CryptoHives-PClMul) | 128KB        | 2,392.822 μs | 11.2086 μs |  9.3597 μs |     387 B |         - |
| Encrypt · ARIA-128-GCM (BouncyCastle)       | 128KB        | 2,586.954 μs |  8.9688 μs |  7.9506 μs |     387 B |  329384 B |
| Encrypt · ARIA-128-GCM (CryptoHives-Scalar) | 128KB        | 3,066.054 μs | 10.4379 μs |  9.7636 μs |     387 B |         - |