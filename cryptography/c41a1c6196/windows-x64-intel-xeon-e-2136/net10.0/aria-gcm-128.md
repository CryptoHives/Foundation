| Description                                 | TestDataSize | Mean         | Error      | StdDev     | Code Size | Allocated |
|-------------------------------------------- |------------- |-------------:|-----------:|-----------:|----------:|----------:|
| Decrypt · ARIA-128-GCM (CryptoHives-PClMul) | 128B         |     3.707 μs |  0.0015 μs |  0.0012 μs |     310 B |         - |
| Decrypt · ARIA-128-GCM (CryptoHives-Scalar) | 128B         |     4.786 μs |  0.0316 μs |  0.0296 μs |     310 B |         - |
| Decrypt · ARIA-128-GCM (BouncyCastle)       | 128B         |     5.269 μs |  0.0156 μs |  0.0146 μs |     310 B |    2040 B |
|                                             |              |              |            |            |           |           |
| Encrypt · ARIA-128-GCM (CryptoHives-PClMul) | 128B         |     3.615 μs |  0.0016 μs |  0.0015 μs |     387 B |         - |
| Encrypt · ARIA-128-GCM (CryptoHives-Scalar) | 128B         |     4.676 μs |  0.0157 μs |  0.0139 μs |     390 B |         - |
| Encrypt · ARIA-128-GCM (BouncyCastle)       | 128B         |     5.148 μs |  0.0186 μs |  0.0174 μs |     387 B |    2024 B |
|                                             |              |              |            |            |           |           |
| Decrypt · ARIA-128-GCM (CryptoHives-PClMul) | 1KB          |    25.460 μs |  0.0099 μs |  0.0092 μs |     310 B |         - |
| Decrypt · ARIA-128-GCM (BouncyCastle)       | 1KB          |    27.850 μs |  0.0652 μs |  0.0610 μs |     310 B |    4280 B |
| Decrypt · ARIA-128-GCM (CryptoHives-Scalar) | 1KB          |    32.926 μs |  0.0997 μs |  0.0884 μs |     310 B |         - |
|                                             |              |              |            |            |           |           |
| Encrypt · ARIA-128-GCM (CryptoHives-PClMul) | 1KB          |    25.371 μs |  0.0123 μs |  0.0115 μs |     387 B |         - |
| Encrypt · ARIA-128-GCM (BouncyCastle)       | 1KB          |    27.482 μs |  0.0909 μs |  0.0806 μs |     387 B |    4264 B |
| Encrypt · ARIA-128-GCM (CryptoHives-Scalar) | 1KB          |    32.887 μs |  0.1924 μs |  0.1705 μs |     387 B |         - |
|                                             |              |              |            |            |           |           |
| Decrypt · ARIA-128-GCM (CryptoHives-PClMul) | 8KB          |   199.678 μs |  0.0711 μs |  0.0665 μs |     310 B |         - |
| Decrypt · ARIA-128-GCM (BouncyCastle)       | 8KB          |   205.640 μs |  0.4557 μs |  0.4040 μs |     310 B |   22200 B |
| Decrypt · ARIA-128-GCM (CryptoHives-Scalar) | 8KB          |   257.956 μs |  1.0186 μs |  0.9528 μs |     310 B |         - |
|                                             |              |              |            |            |           |           |
| Encrypt · ARIA-128-GCM (CryptoHives-PClMul) | 8KB          |   199.223 μs |  0.0195 μs |  0.0173 μs |     387 B |         - |
| Encrypt · ARIA-128-GCM (BouncyCastle)       | 8KB          |   206.676 μs |  0.5347 μs |  0.5002 μs |     387 B |   22184 B |
| Encrypt · ARIA-128-GCM (CryptoHives-Scalar) | 8KB          |   258.070 μs |  1.3693 μs |  1.2809 μs |     387 B |         - |
|                                             |              |              |            |            |           |           |
| Decrypt · ARIA-128-GCM (CryptoHives-PClMul) | 128KB        | 3,186.686 μs |  1.4443 μs |  1.3510 μs |     310 B |         - |
| Decrypt · ARIA-128-GCM (BouncyCastle)       | 128KB        | 3,333.249 μs |  7.0402 μs |  6.5854 μs |     310 B |  329400 B |
| Decrypt · ARIA-128-GCM (CryptoHives-Scalar) | 128KB        | 4,113.859 μs | 13.7892 μs | 11.5146 μs |     310 B |         - |
|                                             |              |              |            |            |           |           |
| Encrypt · ARIA-128-GCM (CryptoHives-PClMul) | 128KB        | 3,183.393 μs |  0.5309 μs |  0.4433 μs |     387 B |         - |
| Encrypt · ARIA-128-GCM (BouncyCastle)       | 128KB        | 3,340.063 μs | 11.1263 μs | 10.4075 μs |     387 B |  329384 B |
| Encrypt · ARIA-128-GCM (CryptoHives-Scalar) | 128KB        | 4,126.162 μs | 26.8293 μs | 25.0961 μs |     387 B |         - |