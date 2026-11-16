| Description                                   | TestDataSize | Mean         | Error      | StdDev     | Allocated |
|---------------------------------------------- |------------- |-------------:|-----------:|-----------:|----------:|
| Decrypt · ARIA-256-GCM (CryptoHives-ArmPmull) | 128B         |     1.202 μs |  0.0014 μs |  0.0012 μs |         - |
| Decrypt · ARIA-256-GCM (CryptoHives-Scalar)   | 128B         |     1.684 μs |  0.0029 μs |  0.0027 μs |         - |
| Decrypt · ARIA-256-GCM (BouncyCastle)         | 128B         |     3.284 μs |  0.0070 μs |  0.0062 μs |    2176 B |
|                                               |              |              |            |            |           |
| Encrypt · ARIA-256-GCM (CryptoHives-ArmPmull) | 128B         |     1.162 μs |  0.0029 μs |  0.0027 μs |         - |
| Encrypt · ARIA-256-GCM (CryptoHives-Scalar)   | 128B         |     1.641 μs |  0.0018 μs |  0.0016 μs |         - |
| Encrypt · ARIA-256-GCM (BouncyCastle)         | 128B         |     3.280 μs |  0.0147 μs |  0.0138 μs |    2160 B |
|                                               |              |              |            |            |           |
| Decrypt · ARIA-256-GCM (CryptoHives-ArmPmull) | 1KB          |     8.325 μs |  0.0140 μs |  0.0124 μs |         - |
| Decrypt · ARIA-256-GCM (CryptoHives-Scalar)   | 1KB          |    11.552 μs |  0.0251 μs |  0.0235 μs |         - |
| Decrypt · ARIA-256-GCM (BouncyCastle)         | 1KB          |    18.873 μs |  0.0921 μs |  0.0861 μs |    4416 B |
|                                               |              |              |            |            |           |
| Encrypt · ARIA-256-GCM (CryptoHives-ArmPmull) | 1KB          |     8.276 μs |  0.0339 μs |  0.0317 μs |         - |
| Encrypt · ARIA-256-GCM (CryptoHives-Scalar)   | 1KB          |    11.505 μs |  0.0224 μs |  0.0210 μs |         - |
| Encrypt · ARIA-256-GCM (BouncyCastle)         | 1KB          |    19.169 μs |  0.0892 μs |  0.0834 μs |    4400 B |
|                                               |              |              |            |            |           |
| Decrypt · ARIA-256-GCM (CryptoHives-ArmPmull) | 8KB          |    65.293 μs |  0.1080 μs |  0.1010 μs |         - |
| Decrypt · ARIA-256-GCM (CryptoHives-Scalar)   | 8KB          |    90.646 μs |  0.3005 μs |  0.2811 μs |         - |
| Decrypt · ARIA-256-GCM (BouncyCastle)         | 8KB          |   144.548 μs |  0.6739 μs |  0.6303 μs |   22336 B |
|                                               |              |              |            |            |           |
| Encrypt · ARIA-256-GCM (CryptoHives-ArmPmull) | 8KB          |    65.319 μs |  0.1192 μs |  0.1115 μs |         - |
| Encrypt · ARIA-256-GCM (CryptoHives-Scalar)   | 8KB          |    90.423 μs |  0.1389 μs |  0.1300 μs |         - |
| Encrypt · ARIA-256-GCM (BouncyCastle)         | 8KB          |   146.153 μs |  0.7644 μs |  0.7150 μs |   22320 B |
|                                               |              |              |            |            |           |
| Decrypt · ARIA-256-GCM (CryptoHives-ArmPmull) | 128KB        | 1,046.361 μs |  3.4820 μs |  3.2571 μs |         - |
| Decrypt · ARIA-256-GCM (CryptoHives-Scalar)   | 128KB        | 1,440.555 μs |  2.9746 μs |  2.7824 μs |         - |
| Decrypt · ARIA-256-GCM (BouncyCastle)         | 128KB        | 2,271.993 μs |  9.5337 μs |  8.9178 μs |  329536 B |
|                                               |              |              |            |            |           |
| Encrypt · ARIA-256-GCM (CryptoHives-ArmPmull) | 128KB        | 1,042.676 μs |  1.0819 μs |  1.0121 μs |         - |
| Encrypt · ARIA-256-GCM (CryptoHives-Scalar)   | 128KB        | 1,439.638 μs |  4.1916 μs |  3.9208 μs |         - |
| Encrypt · ARIA-256-GCM (BouncyCastle)         | 128KB        | 2,332.171 μs | 11.9751 μs | 11.2016 μs |  329520 B |