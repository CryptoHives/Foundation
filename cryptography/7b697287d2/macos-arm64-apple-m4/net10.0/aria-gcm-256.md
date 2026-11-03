| Description                                   | TestDataSize | Mean         | Error      | StdDev     | Allocated |
|---------------------------------------------- |------------- |-------------:|-----------:|-----------:|----------:|
| Decrypt · ARIA-256-GCM (CryptoHives-ArmPmull) | 128B         |     1.192 μs |  0.0007 μs |  0.0007 μs |         - |
| Decrypt · ARIA-256-GCM (CryptoHives-Scalar)   | 128B         |     1.661 μs |  0.0013 μs |  0.0012 μs |         - |
| Decrypt · ARIA-256-GCM (BouncyCastle)         | 128B         |     3.197 μs |  0.0092 μs |  0.0086 μs |    2176 B |
|                                               |              |              |            |            |           |
| Encrypt · ARIA-256-GCM (CryptoHives-ArmPmull) | 128B         |     1.159 μs |  0.0049 μs |  0.0046 μs |         - |
| Encrypt · ARIA-256-GCM (CryptoHives-Scalar)   | 128B         |     1.615 μs |  0.0080 μs |  0.0075 μs |         - |
| Encrypt · ARIA-256-GCM (BouncyCastle)         | 128B         |     3.177 μs |  0.0134 μs |  0.0126 μs |    2160 B |
|                                               |              |              |            |            |           |
| Decrypt · ARIA-256-GCM (CryptoHives-ArmPmull) | 1KB          |     8.308 μs |  0.0334 μs |  0.0313 μs |         - |
| Decrypt · ARIA-256-GCM (CryptoHives-Scalar)   | 1KB          |    11.431 μs |  0.0457 μs |  0.0427 μs |         - |
| Decrypt · ARIA-256-GCM (BouncyCastle)         | 1KB          |    18.558 μs |  0.0438 μs |  0.0410 μs |    4416 B |
|                                               |              |              |            |            |           |
| Encrypt · ARIA-256-GCM (CryptoHives-ArmPmull) | 1KB          |     8.264 μs |  0.0246 μs |  0.0230 μs |         - |
| Encrypt · ARIA-256-GCM (CryptoHives-Scalar)   | 1KB          |    11.390 μs |  0.0541 μs |  0.0506 μs |         - |
| Encrypt · ARIA-256-GCM (BouncyCastle)         | 1KB          |    18.998 μs |  0.0720 μs |  0.0673 μs |    4400 B |
|                                               |              |              |            |            |           |
| Decrypt · ARIA-256-GCM (CryptoHives-ArmPmull) | 8KB          |    65.054 μs |  0.2326 μs |  0.2175 μs |         - |
| Decrypt · ARIA-256-GCM (CryptoHives-Scalar)   | 8KB          |    89.530 μs |  0.2080 μs |  0.1946 μs |         - |
| Decrypt · ARIA-256-GCM (BouncyCastle)         | 8KB          |   140.947 μs |  0.5302 μs |  0.4959 μs |   22336 B |
|                                               |              |              |            |            |           |
| Encrypt · ARIA-256-GCM (CryptoHives-ArmPmull) | 8KB          |    64.829 μs |  0.0446 μs |  0.0417 μs |         - |
| Encrypt · ARIA-256-GCM (CryptoHives-Scalar)   | 8KB          |    88.994 μs |  0.2885 μs |  0.2699 μs |         - |
| Encrypt · ARIA-256-GCM (BouncyCastle)         | 8KB          |   144.749 μs |  0.4699 μs |  0.4395 μs |   22320 B |
|                                               |              |              |            |            |           |
| Decrypt · ARIA-256-GCM (CryptoHives-ArmPmull) | 128KB        | 1,040.239 μs |  3.3763 μs |  3.1582 μs |         - |
| Decrypt · ARIA-256-GCM (CryptoHives-Scalar)   | 128KB        | 1,424.532 μs |  1.9075 μs |  1.7843 μs |         - |
| Decrypt · ARIA-256-GCM (BouncyCastle)         | 128KB        | 2,248.118 μs | 12.4248 μs | 11.6222 μs |  329536 B |
|                                               |              |              |            |            |           |
| Encrypt · ARIA-256-GCM (CryptoHives-ArmPmull) | 128KB        | 1,035.903 μs |  0.5252 μs |  0.4913 μs |         - |
| Encrypt · ARIA-256-GCM (CryptoHives-Scalar)   | 128KB        | 1,401.314 μs |  1.0482 μs |  0.8753 μs |         - |
| Encrypt · ARIA-256-GCM (BouncyCastle)         | 128KB        | 2,265.683 μs |  6.9542 μs |  6.5049 μs |  329520 B |