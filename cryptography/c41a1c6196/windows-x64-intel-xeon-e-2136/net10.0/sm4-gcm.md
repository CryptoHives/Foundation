| Description                            | TestDataSize | Mean         | Error      | StdDev     | Code Size | Allocated |
|--------------------------------------- |------------- |-------------:|-----------:|-----------:|----------:|----------:|
| Decrypt · SM4-GCM (CryptoHives-PClMul) | 128B         |     1.430 μs |  0.0033 μs |  0.0029 μs |     310 B |         - |
| Decrypt · SM4-GCM (CryptoHives-Scalar) | 128B         |     2.535 μs |  0.0207 μs |  0.0183 μs |     310 B |         - |
| Decrypt · SM4-GCM (BouncyCastle)       | 128B         |     2.677 μs |  0.0055 μs |  0.0049 μs |     310 B |     832 B |
|                                        |              |              |            |            |           |           |
| Encrypt · SM4-GCM (CryptoHives-PClMul) | 128B         |     1.352 μs |  0.0101 μs |  0.0095 μs |     387 B |         - |
| Encrypt · SM4-GCM (CryptoHives-Scalar) | 128B         |     2.433 μs |  0.0219 μs |  0.0183 μs |     387 B |         - |
| Encrypt · SM4-GCM (BouncyCastle)       | 128B         |     2.484 μs |  0.0043 μs |  0.0040 μs |     387 B |     816 B |
|                                        |              |              |            |            |           |           |
| Decrypt · SM4-GCM (CryptoHives-PClMul) | 1KB          |     9.384 μs |  0.0701 μs |  0.0656 μs |     310 B |         - |
| Decrypt · SM4-GCM (BouncyCastle)       | 1KB          |    13.960 μs |  0.0076 μs |  0.0059 μs |     310 B |     832 B |
| Decrypt · SM4-GCM (CryptoHives-Scalar) | 1KB          |    16.673 μs |  0.1374 μs |  0.1218 μs |     310 B |         - |
|                                        |              |              |            |            |           |           |
| Encrypt · SM4-GCM (CryptoHives-PClMul) | 1KB          |     9.290 μs |  0.0314 μs |  0.0278 μs |     387 B |         - |
| Encrypt · SM4-GCM (BouncyCastle)       | 1KB          |    13.546 μs |  0.0312 μs |  0.0292 μs |     387 B |     816 B |
| Encrypt · SM4-GCM (CryptoHives-Scalar) | 1KB          |    16.772 μs |  0.2891 μs |  0.2704 μs |     387 B |         - |
|                                        |              |              |            |            |           |           |
| Decrypt · SM4-GCM (CryptoHives-PClMul) | 8KB          |    72.536 μs |  0.4118 μs |  0.3439 μs |     310 B |         - |
| Decrypt · SM4-GCM (BouncyCastle)       | 8KB          |   102.723 μs |  0.0872 μs |  0.0728 μs |     310 B |     832 B |
| Decrypt · SM4-GCM (CryptoHives-Scalar) | 8KB          |   130.393 μs |  1.4911 μs |  1.3948 μs |     310 B |         - |
|                                        |              |              |            |            |           |           |
| Encrypt · SM4-GCM (CryptoHives-PClMul) | 8KB          |    74.824 μs |  0.3056 μs |  0.2859 μs |     387 B |         - |
| Encrypt · SM4-GCM (BouncyCastle)       | 8KB          |   100.779 μs |  0.2556 μs |  0.2390 μs |     387 B |     816 B |
| Encrypt · SM4-GCM (CryptoHives-Scalar) | 8KB          |   130.100 μs |  1.2520 μs |  1.1711 μs |     387 B |         - |
|                                        |              |              |            |            |           |           |
| Decrypt · SM4-GCM (CryptoHives-PClMul) | 128KB        | 1,155.341 μs |  6.3540 μs |  5.3059 μs |     310 B |         - |
| Decrypt · SM4-GCM (BouncyCastle)       | 128KB        | 1,614.345 μs |  2.1532 μs |  2.0141 μs |     310 B |     832 B |
| Decrypt · SM4-GCM (CryptoHives-Scalar) | 128KB        | 2,083.673 μs | 19.4473 μs | 17.2395 μs |     310 B |         - |
|                                        |              |              |            |            |           |           |
| Encrypt · SM4-GCM (CryptoHives-PClMul) | 128KB        | 1,166.870 μs | 11.9611 μs | 11.1884 μs |     387 B |         - |
| Encrypt · SM4-GCM (BouncyCastle)       | 128KB        | 1,600.377 μs |  3.7442 μs |  3.5024 μs |     387 B |     816 B |
| Encrypt · SM4-GCM (CryptoHives-Scalar) | 128KB        | 2,063.471 μs |  9.5297 μs |  7.9578 μs |     387 B |         - |