| Description                                 | TestDataSize | Mean         | Error      | StdDev     | Allocated |
|-------------------------------------------- |------------- |-------------:|-----------:|-----------:|----------:|
| Decrypt · ARIA-256-CCM (CryptoHives-Scalar) | 128B         |     2.675 μs |  0.0016 μs |  0.0015 μs |         - |
| Decrypt · ARIA-256-CCM (BouncyCastle)       | 128B         |     6.065 μs |  0.0131 μs |  0.0122 μs |    3880 B |
|                                             |              |              |            |            |           |
| Encrypt · ARIA-256-CCM (CryptoHives-Scalar) | 128B         |     2.623 μs |  0.0012 μs |  0.0012 μs |         - |
| Encrypt · ARIA-256-CCM (BouncyCastle)       | 128B         |     6.009 μs |  0.0133 μs |  0.0111 μs |    3768 B |
|                                             |              |              |            |            |           |
| Decrypt · ARIA-256-CCM (CryptoHives-Scalar) | 1KB          |    17.142 μs |  0.0067 μs |  0.0062 μs |         - |
| Decrypt · ARIA-256-CCM (BouncyCastle)       | 1KB          |    34.760 μs |  0.1215 μs |  0.1137 μs |    9256 B |
|                                             |              |              |            |            |           |
| Encrypt · ARIA-256-CCM (CryptoHives-Scalar) | 1KB          |    17.098 μs |  0.0077 μs |  0.0068 μs |         - |
| Encrypt · ARIA-256-CCM (BouncyCastle)       | 1KB          |    34.692 μs |  0.1287 μs |  0.1204 μs |    8248 B |
|                                             |              |              |            |            |           |
| Decrypt · ARIA-256-CCM (CryptoHives-Scalar) | 8KB          |   132.928 μs |  0.0468 μs |  0.0438 μs |         - |
| Decrypt · ARIA-256-CCM (BouncyCastle)       | 8KB          |   264.003 μs |  0.9530 μs |  0.8915 μs |   52264 B |
|                                             |              |              |            |            |           |
| Encrypt · ARIA-256-CCM (CryptoHives-Scalar) | 8KB          |   133.234 μs |  0.6414 μs |  0.5685 μs |         - |
| Encrypt · ARIA-256-CCM (BouncyCastle)       | 8KB          |   263.823 μs |  0.9366 μs |  0.8761 μs |   44088 B |
|                                             |              |              |            |            |           |
| Decrypt · ARIA-256-CCM (CryptoHives-Scalar) | 128KB        | 2,119.575 μs |  1.0420 μs |  0.9746 μs |         - |
| Decrypt · ARIA-256-CCM (BouncyCastle)       | 128KB        | 4,232.125 μs | 24.9238 μs | 23.3138 μs |  789570 B |
|                                             |              |              |            |            |           |
| Encrypt · ARIA-256-CCM (CryptoHives-Scalar) | 128KB        | 2,119.477 μs |  1.5447 μs |  1.4449 μs |         - |
| Encrypt · ARIA-256-CCM (BouncyCastle)       | 128KB        | 4,191.757 μs | 14.6783 μs | 13.7301 μs |  658488 B |