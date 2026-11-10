| Description                                 | TestDataSize | Mean         | Error     | StdDev    | Code Size | Allocated |
|-------------------------------------------- |------------- |-------------:|----------:|----------:|----------:|----------:|
| Decrypt · ARIA-256-GCM (CryptoHives-PClMul) | 128B         |     4.893 μs | 0.0082 μs | 0.0077 μs |     310 B |         - |
| Decrypt · ARIA-256-GCM (CryptoHives-Scalar) | 128B         |     5.955 μs | 0.0162 μs | 0.0152 μs |     310 B |         - |
| Decrypt · ARIA-256-GCM (BouncyCastle)       | 128B         |     6.778 μs | 0.0120 μs | 0.0106 μs |     310 B |    2264 B |
|                                             |              |              |           |           |           |           |
| Encrypt · ARIA-256-GCM (CryptoHives-PClMul) | 128B         |     4.800 μs | 0.0065 μs | 0.0061 μs |     387 B |         - |
| Encrypt · ARIA-256-GCM (CryptoHives-Scalar) | 128B         |     5.845 μs | 0.0120 μs | 0.0106 μs |     387 B |         - |
| Encrypt · ARIA-256-GCM (BouncyCastle)       | 128B         |     6.622 μs | 0.0124 μs | 0.0116 μs |     387 B |    2248 B |
|                                             |              |              |           |           |           |           |
| Decrypt · ARIA-256-GCM (CryptoHives-PClMul) | 1KB          |    34.033 μs | 0.0245 μs | 0.0191 μs |     310 B |         - |
| Decrypt · ARIA-256-GCM (BouncyCastle)       | 1KB          |    36.614 μs | 0.0329 μs | 0.0257 μs |     310 B |    4504 B |
| Decrypt · ARIA-256-GCM (CryptoHives-Scalar) | 1KB          |    41.353 μs | 0.0420 μs | 0.0328 μs |     310 B |         - |
|                                             |              |              |           |           |           |           |
| Encrypt · ARIA-256-GCM (CryptoHives-PClMul) | 1KB          |    34.007 μs | 0.0560 μs | 0.0524 μs |     387 B |         - |
| Encrypt · ARIA-256-GCM (BouncyCastle)       | 1KB          |    36.489 μs | 0.0490 μs | 0.0409 μs |     387 B |    4488 B |
| Encrypt · ARIA-256-GCM (CryptoHives-Scalar) | 1KB          |    41.285 μs | 0.0638 μs | 0.0566 μs |     387 B |         - |
|                                             |              |              |           |           |           |           |
| Decrypt · ARIA-256-GCM (CryptoHives-PClMul) | 8KB          |   267.322 μs | 0.3458 μs | 0.3235 μs |     310 B |         - |
| Decrypt · ARIA-256-GCM (BouncyCastle)       | 8KB          |   278.030 μs | 0.5617 μs | 0.5254 μs |     310 B |   22424 B |
| Decrypt · ARIA-256-GCM (CryptoHives-Scalar) | 8KB          |   324.101 μs | 0.6398 μs | 0.5985 μs |     310 B |         - |
|                                             |              |              |           |           |           |           |
| Encrypt · ARIA-256-GCM (CryptoHives-PClMul) | 8KB          |   267.205 μs | 0.4215 μs | 0.3736 μs |     387 B |         - |
| Encrypt · ARIA-256-GCM (BouncyCastle)       | 8KB          |   276.721 μs | 0.4770 μs | 0.3983 μs |     387 B |   22408 B |
| Encrypt · ARIA-256-GCM (CryptoHives-Scalar) | 8KB          |   323.911 μs | 0.3791 μs | 0.3361 μs |     387 B |         - |
|                                             |              |              |           |           |           |           |
| Decrypt · ARIA-256-GCM (CryptoHives-PClMul) | 128KB        | 4,267.258 μs | 8.4264 μs | 7.8821 μs |     310 B |         - |
| Decrypt · ARIA-256-GCM (BouncyCastle)       | 128KB        | 4,290.804 μs | 5.0894 μs | 4.7606 μs |     310 B |  329624 B |
| Decrypt · ARIA-256-GCM (CryptoHives-Scalar) | 128KB        | 5,176.964 μs | 6.2653 μs | 5.2318 μs |     310 B |         - |
|                                             |              |              |           |           |           |           |
| Encrypt · ARIA-256-GCM (CryptoHives-PClMul) | 128KB        | 4,265.452 μs | 3.1405 μs | 2.6225 μs |     387 B |         - |
| Encrypt · ARIA-256-GCM (BouncyCastle)       | 128KB        | 4,382.880 μs | 8.8460 μs | 8.2745 μs |     387 B |  329608 B |
| Encrypt · ARIA-256-GCM (CryptoHives-Scalar) | 128KB        | 5,167.927 μs | 4.8309 μs | 3.7716 μs |     387 B |         - |