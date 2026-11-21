| Description                                 | TestDataSize | Mean         | Error      | StdDev     | Code Size | Allocated |
|-------------------------------------------- |------------- |-------------:|-----------:|-----------:|----------:|----------:|
| Decrypt · ARIA-256-GCM (CryptoHives-PClMul) | 128B         |     4.326 μs |  0.0057 μs |  0.0045 μs |     310 B |         - |
| Decrypt · ARIA-256-GCM (CryptoHives-Scalar) | 128B         |     5.242 μs |  0.0185 μs |  0.0164 μs |     310 B |         - |
| Decrypt · ARIA-256-GCM (BouncyCastle)       | 128B         |     6.015 μs |  0.0095 μs |  0.0089 μs |     310 B |    2264 B |
|                                             |              |              |            |            |           |           |
| Encrypt · ARIA-256-GCM (CryptoHives-PClMul) | 128B         |     4.247 μs |  0.0112 μs |  0.0105 μs |     390 B |         - |
| Encrypt · ARIA-256-GCM (CryptoHives-Scalar) | 128B         |     5.148 μs |  0.0112 μs |  0.0100 μs |     390 B |         - |
| Encrypt · ARIA-256-GCM (BouncyCastle)       | 128B         |     5.829 μs |  0.0088 μs |  0.0078 μs |     390 B |    2248 B |
|                                             |              |              |            |            |           |           |
| Decrypt · ARIA-256-GCM (CryptoHives-PClMul) | 1KB          |    29.998 μs |  0.0397 μs |  0.0352 μs |     310 B |         - |
| Decrypt · ARIA-256-GCM (BouncyCastle)       | 1KB          |    32.285 μs |  0.0684 μs |  0.0640 μs |     310 B |    4504 B |
| Decrypt · ARIA-256-GCM (CryptoHives-Scalar) | 1KB          |    36.181 μs |  0.0628 μs |  0.0524 μs |     310 B |         - |
|                                             |              |              |            |            |           |           |
| Encrypt · ARIA-256-GCM (CryptoHives-PClMul) | 1KB          |    29.893 μs |  0.0220 μs |  0.0195 μs |     390 B |         - |
| Encrypt · ARIA-256-GCM (BouncyCastle)       | 1KB          |    31.746 μs |  0.0365 μs |  0.0342 μs |     390 B |    4488 B |
| Encrypt · ARIA-256-GCM (CryptoHives-Scalar) | 1KB          |    36.055 μs |  0.0337 μs |  0.0315 μs |     390 B |         - |
|                                             |              |              |            |            |           |           |
| Decrypt · ARIA-256-GCM (CryptoHives-PClMul) | 8KB          |   234.713 μs |  0.2797 μs |  0.2335 μs |     310 B |         - |
| Decrypt · ARIA-256-GCM (BouncyCastle)       | 8KB          |   243.954 μs |  0.3499 μs |  0.3273 μs |     310 B |   22424 B |
| Decrypt · ARIA-256-GCM (CryptoHives-Scalar) | 8KB          |   282.493 μs |  0.6140 μs |  0.5127 μs |     310 B |         - |
|                                             |              |              |            |            |           |           |
| Encrypt · ARIA-256-GCM (CryptoHives-PClMul) | 8KB          |   236.361 μs |  0.1354 μs |  0.1131 μs |     390 B |         - |
| Encrypt · ARIA-256-GCM (BouncyCastle)       | 8KB          |   243.306 μs |  0.2304 μs |  0.1924 μs |     390 B |   22408 B |
| Encrypt · ARIA-256-GCM (CryptoHives-Scalar) | 8KB          |   282.885 μs |  0.5163 μs |  0.4829 μs |     390 B |         - |
|                                             |              |              |            |            |           |           |
| Decrypt · ARIA-256-GCM (BouncyCastle)       | 128KB        | 3,776.224 μs |  7.3780 μs |  6.9014 μs |     310 B |  329624 B |
| Decrypt · ARIA-256-GCM (CryptoHives-PClMul) | 128KB        | 3,777.861 μs |  3.6478 μs |  3.0461 μs |     310 B |         - |
| Decrypt · ARIA-256-GCM (CryptoHives-Scalar) | 128KB        | 4,524.529 μs | 21.8233 μs | 19.3457 μs |     310 B |         - |
|                                             |              |              |            |            |           |           |
| Encrypt · ARIA-256-GCM (CryptoHives-PClMul) | 128KB        | 3,749.532 μs |  2.3407 μs |  1.9546 μs |     390 B |         - |
| Encrypt · ARIA-256-GCM (BouncyCastle)       | 128KB        | 3,803.898 μs |  3.0426 μs |  2.8461 μs |     390 B |  329608 B |
| Encrypt · ARIA-256-GCM (CryptoHives-Scalar) | 128KB        | 4,519.395 μs |  8.5488 μs |  7.9965 μs |     390 B |         - |