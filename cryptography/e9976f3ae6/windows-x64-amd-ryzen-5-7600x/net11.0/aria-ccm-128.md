| Description                                 | TestDataSize | Mean         | Error      | StdDev     | Code Size | Allocated |
|-------------------------------------------- |------------- |-------------:|-----------:|-----------:|----------:|----------:|
| Decrypt · ARIA-128-CCM (CryptoHives-Scalar) | 128B         |     3.740 μs |  0.0344 μs |  0.0321 μs |  30,365 B |         - |
| Decrypt · ARIA-128-CCM (BouncyCastle)       | 128B         |     5.742 μs |  0.0582 μs |  0.0516 μs |     306 B |    3416 B |
|                                             |              |              |            |            |           |           |
| Encrypt · ARIA-128-CCM (CryptoHives-Scalar) | 128B         |     3.687 μs |  0.0377 μs |  0.0334 μs |  26,607 B |         - |
| Encrypt · ARIA-128-CCM (BouncyCastle)       | 128B         |     5.708 μs |  0.0591 μs |  0.0553 μs |     386 B |    3264 B |
|                                             |              |              |            |            |           |           |
| Decrypt · ARIA-128-CCM (CryptoHives-Scalar) | 1KB          |    24.162 μs |  0.3296 μs |  0.3083 μs |  25,166 B |         - |
| Decrypt · ARIA-128-CCM (BouncyCastle)       | 1KB          |    33.512 μs |  0.2277 μs |  0.2130 μs |     306 B |    8792 B |
|                                             |              |              |            |            |           |           |
| Encrypt · ARIA-128-CCM (CryptoHives-Scalar) | 1KB          |    24.085 μs |  0.2753 μs |  0.2575 μs |  26,558 B |         - |
| Encrypt · ARIA-128-CCM (BouncyCastle)       | 1KB          |    33.565 μs |  0.3620 μs |  0.3386 μs |     386 B |    7744 B |
|                                             |              |              |            |            |           |           |
| Decrypt · ARIA-128-CCM (CryptoHives-Scalar) | 8KB          |   187.523 μs |  2.0802 μs |  1.9458 μs |  24,991 B |         - |
| Decrypt · ARIA-128-CCM (BouncyCastle)       | 8KB          |   256.384 μs |  2.8103 μs |  2.6287 μs |     306 B |   51800 B |
|                                             |              |              |            |            |           |           |
| Encrypt · ARIA-128-CCM (CryptoHives-Scalar) | 8KB          |   187.818 μs |  1.0106 μs |  0.9453 μs |  26,391 B |         - |
| Encrypt · ARIA-128-CCM (BouncyCastle)       | 8KB          |   257.376 μs |  1.7191 μs |  1.6080 μs |     386 B |   43584 B |
|                                             |              |              |            |            |           |           |
| Decrypt · ARIA-128-CCM (CryptoHives-Scalar) | 128KB        | 2,978.041 μs | 31.0599 μs | 27.5337 μs |  25,868 B |         - |
| Decrypt · ARIA-128-CCM (BouncyCastle)       | 128KB        | 4,153.542 μs | 35.2449 μs | 32.9681 μs |     306 B |  789131 B |
|                                             |              |              |            |            |           |           |
| Encrypt · ARIA-128-CCM (CryptoHives-Scalar) | 128KB        | 2,976.540 μs | 32.2226 μs | 28.5645 μs |  28,426 B |         - |
| Encrypt · ARIA-128-CCM (BouncyCastle)       | 128KB        | 4,080.551 μs | 35.2290 μs | 31.2296 μs |     386 B |  657984 B |