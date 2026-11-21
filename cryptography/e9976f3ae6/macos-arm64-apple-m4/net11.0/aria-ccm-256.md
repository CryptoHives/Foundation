| Description                                 | TestDataSize | Mean         | Error     | StdDev    | Allocated |
|-------------------------------------------- |------------- |-------------:|----------:|----------:|----------:|
| Decrypt · ARIA-256-CCM (CryptoHives-Scalar) | 128B         |     2.693 μs | 0.0044 μs | 0.0041 μs |         - |
| Decrypt · ARIA-256-CCM (BouncyCastle)       | 128B         |     5.384 μs | 0.0122 μs | 0.0114 μs |    3848 B |
|                                             |              |              |           |           |           |
| Encrypt · ARIA-256-CCM (CryptoHives-Scalar) | 128B         |     2.659 μs | 0.0022 μs | 0.0021 μs |         - |
| Encrypt · ARIA-256-CCM (BouncyCastle)       | 128B         |     5.308 μs | 0.0170 μs | 0.0159 μs |    3696 B |
|                                             |              |              |           |           |           |
| Decrypt · ARIA-256-CCM (CryptoHives-Scalar) | 1KB          |    17.292 μs | 0.0343 μs | 0.0321 μs |         - |
| Decrypt · ARIA-256-CCM (BouncyCastle)       | 1KB          |    31.123 μs | 0.1377 μs | 0.1288 μs |    9224 B |
|                                             |              |              |           |           |           |
| Encrypt · ARIA-256-CCM (CryptoHives-Scalar) | 1KB          |    17.229 μs | 0.0168 μs | 0.0158 μs |         - |
| Encrypt · ARIA-256-CCM (BouncyCastle)       | 1KB          |    31.013 μs | 0.1631 μs | 0.1526 μs |    8176 B |
|                                             |              |              |           |           |           |
| Decrypt · ARIA-256-CCM (CryptoHives-Scalar) | 8KB          |   133.772 μs | 0.1803 μs | 0.1686 μs |         - |
| Decrypt · ARIA-256-CCM (BouncyCastle)       | 8KB          |   237.926 μs | 0.8513 μs | 0.7963 μs |   52232 B |
|                                             |              |              |           |           |           |
| Encrypt · ARIA-256-CCM (CryptoHives-Scalar) | 8KB          |   133.691 μs | 0.2106 μs | 0.1970 μs |         - |
| Encrypt · ARIA-256-CCM (BouncyCastle)       | 8KB          |   237.020 μs | 0.4647 μs | 0.4347 μs |   44016 B |
|                                             |              |              |           |           |           |
| Decrypt · ARIA-256-CCM (CryptoHives-Scalar) | 128KB        | 2,140.801 μs | 2.1185 μs | 1.9816 μs |         - |
| Decrypt · ARIA-256-CCM (BouncyCastle)       | 128KB        | 3,807.698 μs | 6.9294 μs | 6.4818 μs |  789536 B |
|                                             |              |              |           |           |           |
| Encrypt · ARIA-256-CCM (CryptoHives-Scalar) | 128KB        | 2,135.555 μs | 2.2312 μs | 2.0871 μs |         - |
| Encrypt · ARIA-256-CCM (BouncyCastle)       | 128KB        | 3,777.591 μs | 9.2242 μs | 8.6283 μs |  658416 B |