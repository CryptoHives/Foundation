| Description                                 | TestDataSize | Mean         | Error     | StdDev    | Code Size | Allocated |
|-------------------------------------------- |------------- |-------------:|----------:|----------:|----------:|----------:|
| Decrypt · ARIA-128-GCM (CryptoHives-PClMul) | 128B         |     3.715 μs | 0.0035 μs | 0.0031 μs |     310 B |         - |
| Decrypt · ARIA-128-GCM (CryptoHives-Scalar) | 128B         |     4.764 μs | 0.0051 μs | 0.0048 μs |     310 B |         - |
| Decrypt · ARIA-128-GCM (BouncyCastle)       | 128B         |     5.230 μs | 0.0086 μs | 0.0076 μs |     310 B |    2040 B |
|                                             |              |              |           |           |           |           |
| Encrypt · ARIA-128-GCM (CryptoHives-PClMul) | 128B         |     3.619 μs | 0.0021 μs | 0.0018 μs |     387 B |         - |
| Encrypt · ARIA-128-GCM (CryptoHives-Scalar) | 128B         |     4.666 μs | 0.0061 μs | 0.0054 μs |     387 B |         - |
| Encrypt · ARIA-128-GCM (BouncyCastle)       | 128B         |     5.152 μs | 0.0109 μs | 0.0097 μs |     387 B |    2024 B |
|                                             |              |              |           |           |           |           |
| Decrypt · ARIA-128-GCM (CryptoHives-PClMul) | 1KB          |    25.528 μs | 0.0230 μs | 0.0203 μs |     310 B |         - |
| Decrypt · ARIA-128-GCM (BouncyCastle)       | 1KB          |    27.832 μs | 0.0387 μs | 0.0343 μs |     310 B |    4280 B |
| Decrypt · ARIA-128-GCM (CryptoHives-Scalar) | 1KB          |    32.933 μs | 0.0634 μs | 0.0593 μs |     310 B |         - |
|                                             |              |              |           |           |           |           |
| Encrypt · ARIA-128-GCM (CryptoHives-PClMul) | 1KB          |    25.498 μs | 0.0144 μs | 0.0128 μs |     387 B |         - |
| Encrypt · ARIA-128-GCM (BouncyCastle)       | 1KB          |    27.629 μs | 0.0326 μs | 0.0273 μs |     387 B |    4264 B |
| Encrypt · ARIA-128-GCM (CryptoHives-Scalar) | 1KB          |    32.750 μs | 0.0526 μs | 0.0439 μs |     387 B |         - |
|                                             |              |              |           |           |           |           |
| Decrypt · ARIA-128-GCM (CryptoHives-PClMul) | 8KB          |   200.926 μs | 0.1703 μs | 0.1329 μs |     310 B |         - |
| Decrypt · ARIA-128-GCM (BouncyCastle)       | 8KB          |   211.827 μs | 0.3223 μs | 0.2516 μs |     310 B |   22200 B |
| Decrypt · ARIA-128-GCM (CryptoHives-Scalar) | 8KB          |   257.279 μs | 0.3855 μs | 0.3219 μs |     310 B |         - |
|                                             |              |              |           |           |           |           |
| Encrypt · ARIA-128-GCM (CryptoHives-PClMul) | 8KB          |   199.869 μs | 0.1489 μs | 0.1243 μs |     387 B |         - |
| Encrypt · ARIA-128-GCM (BouncyCastle)       | 8KB          |   207.246 μs | 0.3573 μs | 0.3342 μs |     387 B |   22184 B |
| Encrypt · ARIA-128-GCM (CryptoHives-Scalar) | 8KB          |   256.985 μs | 0.5685 μs | 0.4747 μs |     387 B |         - |
|                                             |              |              |           |           |           |           |
| Decrypt · ARIA-128-GCM (CryptoHives-PClMul) | 128KB        | 3,192.479 μs | 4.0131 μs | 3.7539 μs |     310 B |         - |
| Decrypt · ARIA-128-GCM (BouncyCastle)       | 128KB        | 3,300.479 μs | 1.2777 μs | 0.9976 μs |     310 B |  329400 B |
| Decrypt · ARIA-128-GCM (CryptoHives-Scalar) | 128KB        | 4,120.259 μs | 9.3366 μs | 8.7334 μs |     310 B |         - |
|                                             |              |              |           |           |           |           |
| Encrypt · ARIA-128-GCM (CryptoHives-PClMul) | 128KB        | 3,192.796 μs | 5.3354 μs | 4.4553 μs |     387 B |         - |
| Encrypt · ARIA-128-GCM (BouncyCastle)       | 128KB        | 3,357.153 μs | 3.1596 μs | 2.8009 μs |     387 B |  329384 B |
| Encrypt · ARIA-128-GCM (CryptoHives-Scalar) | 128KB        | 4,103.804 μs | 8.8671 μs | 7.8605 μs |     387 B |         - |