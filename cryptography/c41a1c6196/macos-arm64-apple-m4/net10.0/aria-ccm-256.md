| Description                                 | TestDataSize | Mean         | Error      | StdDev     | Allocated |
|-------------------------------------------- |------------- |-------------:|-----------:|-----------:|----------:|
| Decrypt · ARIA-256-CCM (CryptoHives-Scalar) | 128B         |     2.693 μs |  0.0032 μs |  0.0030 μs |         - |
| Decrypt · ARIA-256-CCM (BouncyCastle)       | 128B         |     6.209 μs |  0.0168 μs |  0.0157 μs |    3880 B |
|                                             |              |              |            |            |           |
| Encrypt · ARIA-256-CCM (CryptoHives-Scalar) | 128B         |     2.644 μs |  0.0027 μs |  0.0026 μs |         - |
| Encrypt · ARIA-256-CCM (BouncyCastle)       | 128B         |     6.192 μs |  0.0165 μs |  0.0154 μs |    3768 B |
|                                             |              |              |            |            |           |
| Decrypt · ARIA-256-CCM (CryptoHives-Scalar) | 1KB          |    17.272 μs |  0.0213 μs |  0.0199 μs |         - |
| Decrypt · ARIA-256-CCM (BouncyCastle)       | 1KB          |    35.955 μs |  0.1250 μs |  0.1169 μs |    9256 B |
|                                             |              |              |            |            |           |
| Encrypt · ARIA-256-CCM (CryptoHives-Scalar) | 1KB          |    17.227 μs |  0.0229 μs |  0.0203 μs |         - |
| Encrypt · ARIA-256-CCM (BouncyCastle)       | 1KB          |    35.257 μs |  0.1559 μs |  0.1459 μs |    8248 B |
|                                             |              |              |            |            |           |
| Decrypt · ARIA-256-CCM (CryptoHives-Scalar) | 8KB          |   133.932 μs |  0.1632 μs |  0.1527 μs |         - |
| Decrypt · ARIA-256-CCM (BouncyCastle)       | 8KB          |   271.378 μs |  1.2874 μs |  1.2043 μs |   52264 B |
|                                             |              |              |            |            |           |
| Encrypt · ARIA-256-CCM (CryptoHives-Scalar) | 8KB          |   133.722 μs |  0.3114 μs |  0.2913 μs |         - |
| Encrypt · ARIA-256-CCM (BouncyCastle)       | 8KB          |   270.890 μs |  1.2677 μs |  1.1858 μs |   44088 B |
|                                             |              |              |            |            |           |
| Decrypt · ARIA-256-CCM (CryptoHives-Scalar) | 128KB        | 2,132.921 μs |  2.4845 μs |  2.2024 μs |         - |
| Decrypt · ARIA-256-CCM (BouncyCastle)       | 128KB        | 4,340.738 μs | 13.9175 μs | 13.0185 μs |  789570 B |
|                                             |              |              |            |            |           |
| Encrypt · ARIA-256-CCM (CryptoHives-Scalar) | 128KB        | 2,132.939 μs |  2.7992 μs |  2.6184 μs |         - |
| Encrypt · ARIA-256-CCM (BouncyCastle)       | 128KB        | 4,294.135 μs | 20.2909 μs | 18.9801 μs |  658488 B |