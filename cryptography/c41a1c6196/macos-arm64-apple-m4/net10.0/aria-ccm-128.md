| Description                                 | TestDataSize | Mean         | Error     | StdDev    | Allocated |
|-------------------------------------------- |------------- |-------------:|----------:|----------:|----------:|
| Decrypt · ARIA-128-CCM (CryptoHives-Scalar) | 128B         |     2.054 μs | 0.0018 μs | 0.0017 μs |         - |
| Decrypt · ARIA-128-CCM (BouncyCastle)       | 128B         |     4.837 μs | 0.0164 μs | 0.0154 μs |    3448 B |
|                                             |              |              |           |           |           |
| Encrypt · ARIA-128-CCM (CryptoHives-Scalar) | 128B         |     2.003 μs | 0.0031 μs | 0.0029 μs |         - |
| Encrypt · ARIA-128-CCM (BouncyCastle)       | 128B         |     4.851 μs | 0.0164 μs | 0.0153 μs |    3336 B |
|                                             |              |              |           |           |           |
| Decrypt · ARIA-128-CCM (CryptoHives-Scalar) | 1KB          |    13.020 μs | 0.0253 μs | 0.0236 μs |         - |
| Decrypt · ARIA-128-CCM (BouncyCastle)       | 1KB          |    27.332 μs | 0.0604 μs | 0.0565 μs |    8824 B |
|                                             |              |              |           |           |           |
| Encrypt · ARIA-128-CCM (CryptoHives-Scalar) | 1KB          |    12.999 μs | 0.0142 μs | 0.0133 μs |         - |
| Encrypt · ARIA-128-CCM (BouncyCastle)       | 1KB          |    27.014 μs | 0.0640 μs | 0.0567 μs |    7816 B |
|                                             |              |              |           |           |           |
| Decrypt · ARIA-128-CCM (CryptoHives-Scalar) | 8KB          |   100.937 μs | 0.0839 μs | 0.0785 μs |         - |
| Decrypt · ARIA-128-CCM (BouncyCastle)       | 8KB          |   205.573 μs | 0.7347 μs | 0.6135 μs |   51832 B |
|                                             |              |              |           |           |           |
| Encrypt · ARIA-128-CCM (CryptoHives-Scalar) | 8KB          |   100.887 μs | 0.1565 μs | 0.1464 μs |         - |
| Encrypt · ARIA-128-CCM (BouncyCastle)       | 8KB          |   207.535 μs | 0.5784 μs | 0.5128 μs |   43656 B |
|                                             |              |              |           |           |           |
| Decrypt · ARIA-128-CCM (CryptoHives-Scalar) | 128KB        | 1,607.916 μs | 1.9219 μs | 1.7037 μs |         - |
| Decrypt · ARIA-128-CCM (BouncyCastle)       | 128KB        | 3,369.061 μs | 6.6214 μs | 6.1937 μs |  789138 B |
|                                             |              |              |           |           |           |
| Encrypt · ARIA-128-CCM (CryptoHives-Scalar) | 128KB        | 1,609.703 μs | 2.1297 μs | 1.9921 μs |         - |
| Encrypt · ARIA-128-CCM (BouncyCastle)       | 128KB        | 3,291.068 μs | 6.0647 μs | 5.6729 μs |  658056 B |