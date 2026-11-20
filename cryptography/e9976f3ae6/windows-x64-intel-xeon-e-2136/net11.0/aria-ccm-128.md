| Description                                 | TestDataSize | Mean         | Error     | StdDev    | Code Size | Allocated |
|-------------------------------------------- |------------- |-------------:|----------:|----------:|----------:|----------:|
| Decrypt · ARIA-128-CCM (CryptoHives-Scalar) | 128B         |     7.243 μs | 0.0071 μs | 0.0063 μs |  18,927 B |         - |
| Decrypt · ARIA-128-CCM (BouncyCastle)       | 128B         |     9.425 μs | 0.0199 μs | 0.0186 μs |     310 B |    3416 B |
|                                             |              |              |           |           |           |           |
| Encrypt · ARIA-128-CCM (CryptoHives-Scalar) | 128B         |     7.144 μs | 0.0074 μs | 0.0069 μs |  22,908 B |         - |
| Encrypt · ARIA-128-CCM (BouncyCastle)       | 128B         |     9.442 μs | 0.0168 μs | 0.0149 μs |     390 B |    3264 B |
|                                             |              |              |           |           |           |           |
| Decrypt · ARIA-128-CCM (CryptoHives-Scalar) | 1KB          |    46.954 μs | 0.0624 μs | 0.0584 μs |  26,213 B |         - |
| Decrypt · ARIA-128-CCM (BouncyCastle)       | 1KB          |    52.659 μs | 0.0520 μs | 0.0487 μs |     310 B |    8792 B |
|                                             |              |              |           |           |           |           |
| Encrypt · ARIA-128-CCM (CryptoHives-Scalar) | 1KB          |    46.544 μs | 0.0338 μs | 0.0299 μs |  26,707 B |         - |
| Encrypt · ARIA-128-CCM (BouncyCastle)       | 1KB          |    51.653 μs | 0.0309 μs | 0.0258 μs |     390 B |    7744 B |
|                                             |              |              |           |           |           |           |
| Decrypt · ARIA-128-CCM (CryptoHives-Scalar) | 8KB          |   361.174 μs | 0.3002 μs | 0.2507 μs |  25,131 B |         - |
| Decrypt · ARIA-128-CCM (BouncyCastle)       | 8KB          |   384.152 μs | 0.4075 μs | 0.3812 μs |     310 B |   51800 B |
|                                             |              |              |           |           |           |           |
| Encrypt · ARIA-128-CCM (CryptoHives-Scalar) | 8KB          |   361.188 μs | 0.2898 μs | 0.2420 μs |  22,389 B |         - |
| Encrypt · ARIA-128-CCM (BouncyCastle)       | 8KB          |   385.443 μs | 0.4563 μs | 0.4269 μs |     390 B |   43584 B |
|                                             |              |              |           |           |           |           |
| Decrypt · ARIA-128-CCM (CryptoHives-Scalar) | 128KB        | 5,778.391 μs | 4.2942 μs | 4.0168 μs |  18,725 B |         - |
| Decrypt · ARIA-128-CCM (BouncyCastle)       | 128KB        | 6,307.366 μs | 4.7090 μs | 4.1744 μs |     310 B |  789131 B |
|                                             |              |              |           |           |           |           |
| Encrypt · ARIA-128-CCM (CryptoHives-Scalar) | 128KB        | 5,763.748 μs | 2.6398 μs | 2.3401 μs |  20,187 B |         - |
| Encrypt · ARIA-128-CCM (BouncyCastle)       | 128KB        | 6,177.578 μs | 5.1588 μs | 4.8255 μs |     390 B |  657984 B |