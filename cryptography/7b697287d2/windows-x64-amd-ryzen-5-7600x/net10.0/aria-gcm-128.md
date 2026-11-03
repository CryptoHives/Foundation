| Description                                 | TestDataSize | Mean         | Error     | StdDev    | Code Size | Allocated |
|-------------------------------------------- |------------- |-------------:|----------:|----------:|----------:|----------:|
| Decrypt · ARIA-128-GCM (CryptoHives-PClMul) | 128B         |     1.658 μs | 0.0038 μs | 0.0032 μs |     306 B |         - |
| Decrypt · ARIA-128-GCM (CryptoHives-Scalar) | 128B         |     2.097 μs | 0.0115 μs | 0.0107 μs |     306 B |         - |
| Decrypt · ARIA-128-GCM (BouncyCastle)       | 128B         |     3.144 μs | 0.0085 μs | 0.0079 μs |     306 B |    2040 B |
|                                             |              |              |           |           |           |           |
| Encrypt · ARIA-128-GCM (CryptoHives-PClMul) | 128B         |     1.610 μs | 0.0046 μs | 0.0041 μs |     383 B |         - |
| Encrypt · ARIA-128-GCM (CryptoHives-Scalar) | 128B         |     2.052 μs | 0.0109 μs | 0.0097 μs |     383 B |         - |
| Encrypt · ARIA-128-GCM (BouncyCastle)       | 128B         |     3.024 μs | 0.0034 μs | 0.0030 μs |     383 B |    2024 B |
|                                             |              |              |           |           |           |           |
| Decrypt · ARIA-128-GCM (CryptoHives-PClMul) | 1KB          |    11.502 μs | 0.0330 μs | 0.0293 μs |     306 B |         - |
| Decrypt · ARIA-128-GCM (CryptoHives-Scalar) | 1KB          |    14.499 μs | 0.0322 μs | 0.0286 μs |     306 B |         - |
| Decrypt · ARIA-128-GCM (BouncyCastle)       | 1KB          |    17.557 μs | 0.0733 μs | 0.0650 μs |     306 B |    4280 B |
|                                             |              |              |           |           |           |           |
| Encrypt · ARIA-128-GCM (CryptoHives-PClMul) | 1KB          |    11.499 μs | 0.0394 μs | 0.0368 μs |     386 B |         - |
| Encrypt · ARIA-128-GCM (CryptoHives-Scalar) | 1KB          |    14.413 μs | 0.0283 μs | 0.0236 μs |     383 B |         - |
| Encrypt · ARIA-128-GCM (BouncyCastle)       | 1KB          |    17.346 μs | 0.0531 μs | 0.0471 μs |     383 B |    4264 B |
|                                             |              |              |           |           |           |           |
| Decrypt · ARIA-128-GCM (CryptoHives-PClMul) | 8KB          |    90.144 μs | 0.2593 μs | 0.2426 μs |     306 B |         - |
| Decrypt · ARIA-128-GCM (CryptoHives-Scalar) | 8KB          |   113.035 μs | 0.1500 μs | 0.1253 μs |     306 B |         - |
| Decrypt · ARIA-128-GCM (BouncyCastle)       | 8KB          |   131.811 μs | 0.5273 μs | 0.4932 μs |     306 B |   22200 B |
|                                             |              |              |           |           |           |           |
| Encrypt · ARIA-128-GCM (CryptoHives-PClMul) | 8KB          |    90.144 μs | 0.3595 μs | 0.3363 μs |     383 B |         - |
| Encrypt · ARIA-128-GCM (CryptoHives-Scalar) | 8KB          |   112.657 μs | 0.1752 μs | 0.1639 μs |     383 B |         - |
| Encrypt · ARIA-128-GCM (BouncyCastle)       | 8KB          |   131.347 μs | 0.2898 μs | 0.2711 μs |     383 B |   22184 B |
|                                             |              |              |           |           |           |           |
| Decrypt · ARIA-128-GCM (CryptoHives-PClMul) | 128KB        | 1,444.206 μs | 7.1393 μs | 6.6781 μs |     306 B |         - |
| Decrypt · ARIA-128-GCM (CryptoHives-Scalar) | 128KB        | 1,805.376 μs | 2.2931 μs | 2.0328 μs |     306 B |         - |
| Decrypt · ARIA-128-GCM (BouncyCastle)       | 128KB        | 2,101.893 μs | 9.7961 μs | 9.1633 μs |     306 B |  329400 B |
|                                             |              |              |           |           |           |           |
| Encrypt · ARIA-128-GCM (CryptoHives-PClMul) | 128KB        | 1,431.655 μs | 5.4294 μs | 5.0787 μs |     383 B |         - |
| Encrypt · ARIA-128-GCM (CryptoHives-Scalar) | 128KB        | 1,799.609 μs | 4.0556 μs | 3.7936 μs |     383 B |         - |
| Encrypt · ARIA-128-GCM (BouncyCastle)       | 128KB        | 2,099.085 μs | 5.0024 μs | 4.4345 μs |     383 B |  329384 B |