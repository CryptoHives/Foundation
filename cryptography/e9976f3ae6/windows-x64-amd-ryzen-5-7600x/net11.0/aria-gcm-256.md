| Description                                 | TestDataSize | Mean         | Error      | StdDev     | Code Size | Allocated |
|-------------------------------------------- |------------- |-------------:|-----------:|-----------:|----------:|----------:|
| Decrypt · ARIA-256-GCM (CryptoHives-PClMul) | 128B         |     2.177 μs |  0.0151 μs |  0.0142 μs |     306 B |         - |
| Decrypt · ARIA-256-GCM (CryptoHives-Scalar) | 128B         |     2.605 μs |  0.0162 μs |  0.0151 μs |     306 B |         - |
| Decrypt · ARIA-256-GCM (BouncyCastle)       | 128B         |     3.724 μs |  0.0216 μs |  0.0191 μs |     306 B |    2264 B |
|                                             |              |              |            |            |           |           |
| Encrypt · ARIA-256-GCM (CryptoHives-PClMul) | 128B         |     2.133 μs |  0.0211 μs |  0.0198 μs |     386 B |         - |
| Encrypt · ARIA-256-GCM (CryptoHives-Scalar) | 128B         |     2.559 μs |  0.0115 μs |  0.0096 μs |     386 B |         - |
| Encrypt · ARIA-256-GCM (BouncyCastle)       | 128B         |     3.583 μs |  0.0162 μs |  0.0135 μs |     386 B |    2248 B |
|                                             |              |              |            |            |           |           |
| Decrypt · ARIA-256-GCM (CryptoHives-PClMul) | 1KB          |    15.265 μs |  0.0969 μs |  0.0907 μs |     306 B |         - |
| Decrypt · ARIA-256-GCM (CryptoHives-Scalar) | 1KB          |    17.857 μs |  0.0689 μs |  0.0575 μs |     306 B |         - |
| Decrypt · ARIA-256-GCM (BouncyCastle)       | 1KB          |    20.841 μs |  0.0451 μs |  0.0376 μs |     306 B |    4504 B |
|                                             |              |              |            |            |           |           |
| Encrypt · ARIA-256-GCM (CryptoHives-PClMul) | 1KB          |    15.218 μs |  0.1136 μs |  0.1063 μs |     386 B |         - |
| Encrypt · ARIA-256-GCM (CryptoHives-Scalar) | 1KB          |    18.033 μs |  0.1433 μs |  0.1340 μs |     386 B |         - |
| Encrypt · ARIA-256-GCM (BouncyCastle)       | 1KB          |    20.939 μs |  0.1190 μs |  0.1113 μs |     386 B |    4488 B |
|                                             |              |              |            |            |           |           |
| Decrypt · ARIA-256-GCM (CryptoHives-PClMul) | 8KB          |   118.645 μs |  0.5966 μs |  0.5289 μs |     306 B |         - |
| Decrypt · ARIA-256-GCM (CryptoHives-Scalar) | 8KB          |   140.025 μs |  0.2063 μs |  0.1722 μs |     306 B |         - |
| Decrypt · ARIA-256-GCM (BouncyCastle)       | 8KB          |   159.630 μs |  0.2167 μs |  0.1810 μs |     306 B |   22424 B |
|                                             |              |              |            |            |           |           |
| Encrypt · ARIA-256-GCM (CryptoHives-PClMul) | 8KB          |   119.850 μs |  0.7831 μs |  0.7325 μs |     386 B |         - |
| Encrypt · ARIA-256-GCM (CryptoHives-Scalar) | 8KB          |   141.624 μs |  0.9281 μs |  0.8681 μs |     386 B |         - |
| Encrypt · ARIA-256-GCM (BouncyCastle)       | 8KB          |   159.383 μs |  0.7887 μs |  0.6586 μs |     386 B |   22408 B |
|                                             |              |              |            |            |           |           |
| Decrypt · ARIA-256-GCM (CryptoHives-PClMul) | 128KB        | 1,905.002 μs | 12.6593 μs | 11.2221 μs |     306 B |         - |
| Decrypt · ARIA-256-GCM (CryptoHives-Scalar) | 128KB        | 2,250.370 μs | 16.8114 μs | 15.7254 μs |     306 B |         - |
| Decrypt · ARIA-256-GCM (BouncyCastle)       | 128KB        | 2,516.508 μs |  6.8840 μs |  6.1025 μs |     306 B |  329624 B |
|                                             |              |              |            |            |           |           |
| Encrypt · ARIA-256-GCM (CryptoHives-PClMul) | 128KB        | 1,907.995 μs |  6.1715 μs |  5.4709 μs |     386 B |         - |
| Encrypt · ARIA-256-GCM (CryptoHives-Scalar) | 128KB        | 2,261.674 μs | 12.8826 μs | 12.0504 μs |     386 B |         - |
| Encrypt · ARIA-256-GCM (BouncyCastle)       | 128KB        | 2,537.797 μs | 14.0770 μs | 12.4789 μs |     386 B |  329608 B |