| Description                                 | TestDataSize | Mean         | Error      | StdDev     | Code Size | Allocated |
|-------------------------------------------- |------------- |-------------:|-----------:|-----------:|----------:|----------:|
| Decrypt · ARIA-256-GCM (CryptoHives-PClMul) | 128B         |     3.668 μs |  0.0108 μs |  0.0085 μs |     310 B |         - |
| Decrypt · ARIA-256-GCM (CryptoHives-Scalar) | 128B         |     4.465 μs |  0.0137 μs |  0.0128 μs |     310 B |         - |
| Decrypt · ARIA-256-GCM (BouncyCastle)       | 128B         |     5.086 μs |  0.0134 μs |  0.0112 μs |     310 B |    2264 B |
|                                             |              |              |            |            |           |           |
| Encrypt · ARIA-256-GCM (CryptoHives-PClMul) | 128B         |     3.602 μs |  0.0106 μs |  0.0089 μs |     387 B |         - |
| Encrypt · ARIA-256-GCM (CryptoHives-Scalar) | 128B         |     4.381 μs |  0.0125 μs |  0.0111 μs |     390 B |         - |
| Encrypt · ARIA-256-GCM (BouncyCastle)       | 128B         |     5.005 μs |  0.0160 μs |  0.0142 μs |     387 B |    2248 B |
|                                             |              |              |            |            |           |           |
| Decrypt · ARIA-256-GCM (CryptoHives-PClMul) | 1KB          |    25.521 μs |  0.0734 μs |  0.0686 μs |     310 B |         - |
| Decrypt · ARIA-256-GCM (BouncyCastle)       | 1KB          |    27.770 μs |  0.0642 μs |  0.0569 μs |     310 B |    4504 B |
| Decrypt · ARIA-256-GCM (CryptoHives-Scalar) | 1KB          |    31.016 μs |  0.1021 μs |  0.0955 μs |     310 B |         - |
|                                             |              |              |            |            |           |           |
| Encrypt · ARIA-256-GCM (CryptoHives-PClMul) | 1KB          |    25.586 μs |  0.0600 μs |  0.0532 μs |     387 B |         - |
| Encrypt · ARIA-256-GCM (BouncyCastle)       | 1KB          |    27.778 μs |  0.1075 μs |  0.1006 μs |     387 B |    4488 B |
| Encrypt · ARIA-256-GCM (CryptoHives-Scalar) | 1KB          |    30.987 μs |  0.1738 μs |  0.1626 μs |     387 B |         - |
|                                             |              |              |            |            |           |           |
| Decrypt · ARIA-256-GCM (CryptoHives-PClMul) | 8KB          |   200.372 μs |  0.5401 μs |  0.4788 μs |     310 B |         - |
| Decrypt · ARIA-256-GCM (BouncyCastle)       | 8KB          |   208.160 μs |  0.7301 μs |  0.6829 μs |     310 B |   22424 B |
| Decrypt · ARIA-256-GCM (CryptoHives-Scalar) | 8KB          |   243.898 μs |  1.1265 μs |  1.0537 μs |     310 B |         - |
|                                             |              |              |            |            |           |           |
| Encrypt · ARIA-256-GCM (CryptoHives-PClMul) | 8KB          |   199.933 μs |  0.4085 μs |  0.3821 μs |     387 B |         - |
| Encrypt · ARIA-256-GCM (BouncyCastle)       | 8KB          |   205.639 μs |  0.6422 μs |  0.5693 μs |     387 B |   22408 B |
| Encrypt · ARIA-256-GCM (CryptoHives-Scalar) | 8KB          |   243.762 μs |  1.1802 μs |  1.1039 μs |     387 B |         - |
|                                             |              |              |            |            |           |           |
| Decrypt · ARIA-256-GCM (CryptoHives-PClMul) | 128KB        | 3,186.342 μs |  6.2541 μs |  5.8501 μs |     310 B |         - |
| Decrypt · ARIA-256-GCM (BouncyCastle)       | 128KB        | 3,267.626 μs |  9.7097 μs |  8.1081 μs |     310 B |  329624 B |
| Decrypt · ARIA-256-GCM (CryptoHives-Scalar) | 128KB        | 3,885.271 μs | 15.4108 μs | 14.4153 μs |     310 B |         - |
|                                             |              |              |            |            |           |           |
| Encrypt · ARIA-256-GCM (CryptoHives-PClMul) | 128KB        | 3,196.506 μs |  8.1626 μs |  7.6353 μs |     387 B |         - |
| Encrypt · ARIA-256-GCM (BouncyCastle)       | 128KB        | 3,285.136 μs | 12.2957 μs | 11.5014 μs |     387 B |  329608 B |
| Encrypt · ARIA-256-GCM (CryptoHives-Scalar) | 128KB        | 3,866.537 μs | 10.8976 μs | 10.1936 μs |     387 B |         - |