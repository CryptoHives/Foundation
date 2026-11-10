| Description                                 | TestDataSize | Mean         | Error      | StdDev     | Code Size | Allocated |
|-------------------------------------------- |------------- |-------------:|-----------:|-----------:|----------:|----------:|
| Decrypt · ARIA-128-CCM (CryptoHives-Scalar) | 128B         |     8.102 μs |  0.0059 μs |  0.0053 μs |  14,358 B |         - |
| Decrypt · ARIA-128-CCM (BouncyCastle)       | 128B         |    10.992 μs |  0.0295 μs |  0.0276 μs |     310 B |    3448 B |
|                                             |              |              |            |            |           |           |
| Encrypt · ARIA-128-CCM (CryptoHives-Scalar) | 128B         |     8.019 μs |  0.0064 μs |  0.0057 μs |  14,411 B |         - |
| Encrypt · ARIA-128-CCM (BouncyCastle)       | 128B         |    10.946 μs |  0.0281 μs |  0.0263 μs |     387 B |    3336 B |
|                                             |              |              |            |            |           |           |
| Decrypt · ARIA-128-CCM (CryptoHives-Scalar) | 1KB          |    52.374 μs |  0.0613 μs |  0.0573 μs |  14,365 B |         - |
| Decrypt · ARIA-128-CCM (BouncyCastle)       | 1KB          |    61.449 μs |  0.1620 μs |  0.1515 μs |     310 B |    8824 B |
|                                             |              |              |            |            |           |           |
| Encrypt · ARIA-128-CCM (CryptoHives-Scalar) | 1KB          |    52.337 μs |  0.0466 μs |  0.0413 μs |  14,400 B |         - |
| Encrypt · ARIA-128-CCM (BouncyCastle)       | 1KB          |    60.648 μs |  0.1170 μs |  0.1095 μs |     387 B |    7816 B |
|                                             |              |              |            |            |           |           |
| Decrypt · ARIA-128-CCM (CryptoHives-Scalar) | 8KB          |   407.414 μs |  0.2974 μs |  0.2637 μs |  14,366 B |         - |
| Decrypt · ARIA-128-CCM (BouncyCastle)       | 8KB          |   467.007 μs |  0.9053 μs |  0.8025 μs |     310 B |   51832 B |
|                                             |              |              |            |            |           |           |
| Encrypt · ARIA-128-CCM (CryptoHives-Scalar) | 8KB          |   406.253 μs |  0.2373 μs |  0.1981 μs |  14,419 B |         - |
| Encrypt · ARIA-128-CCM (BouncyCastle)       | 8KB          |   460.359 μs |  0.6906 μs |  0.6122 μs |     387 B |   43656 B |
|                                             |              |              |            |            |           |           |
| Decrypt · ARIA-128-CCM (CryptoHives-Scalar) | 128KB        | 6,482.780 μs |  4.5171 μs |  4.0043 μs |  14,366 B |         - |
| Decrypt · ARIA-128-CCM (BouncyCastle)       | 128KB        | 7,592.048 μs | 12.6999 μs | 11.8795 μs |     310 B |  789125 B |
|                                             |              |              |            |            |           |           |
| Encrypt · ARIA-128-CCM (CryptoHives-Scalar) | 128KB        | 6,483.352 μs |  4.9765 μs |  4.4116 μs |  14,419 B |         - |
| Encrypt · ARIA-128-CCM (BouncyCastle)       | 128KB        | 7,361.847 μs | 10.4570 μs |  9.7815 μs |     387 B |  658056 B |