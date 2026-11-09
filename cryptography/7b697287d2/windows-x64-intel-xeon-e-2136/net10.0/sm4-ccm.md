| Description                            | TestDataSize | Mean         | Error      | StdDev     | Code Size | Allocated |
|--------------------------------------- |------------- |-------------:|-----------:|-----------:|----------:|----------:|
| Decrypt · SM4-CCM (CryptoHives-Scalar) | 128B         |     2.455 μs |  0.0261 μs |  0.0244 μs |  10,185 B |         - |
| Decrypt · SM4-CCM (BouncyCastle)       | 128B         |     4.080 μs |  0.0650 μs |  0.0608 μs |     310 B |    1032 B |
|                                        |              |              |            |            |           |           |
| Encrypt · SM4-CCM (CryptoHives-Scalar) | 128B         |     2.379 μs |  0.0407 μs |  0.0380 μs |  10,241 B |         - |
| Encrypt · SM4-CCM (BouncyCastle)       | 128B         |     3.993 μs |  0.0687 μs |  0.0643 μs |     387 B |     920 B |
|                                        |              |              |            |            |           |           |
| Decrypt · SM4-CCM (CryptoHives-Scalar) | 1KB          |    15.432 μs |  0.2395 μs |  0.2240 μs |  10,192 B |         - |
| Decrypt · SM4-CCM (BouncyCastle)       | 1KB          |    22.706 μs |  0.1411 μs |  0.1320 μs |     310 B |    1928 B |
|                                        |              |              |            |            |           |           |
| Encrypt · SM4-CCM (CryptoHives-Scalar) | 1KB          |    15.502 μs |  0.0844 μs |  0.0790 μs |  10,238 B |         - |
| Encrypt · SM4-CCM (BouncyCastle)       | 1KB          |    22.512 μs |  0.2996 μs |  0.2802 μs |     387 B |     920 B |
|                                        |              |              |            |            |           |           |
| Decrypt · SM4-CCM (CryptoHives-Scalar) | 8KB          |   118.686 μs |  1.7283 μs |  1.6166 μs |  10,193 B |         - |
| Decrypt · SM4-CCM (BouncyCastle)       | 8KB          |   171.020 μs |  2.2508 μs |  2.1054 μs |     310 B |    9096 B |
|                                        |              |              |            |            |           |           |
| Encrypt · SM4-CCM (CryptoHives-Scalar) | 8KB          |   117.283 μs |  2.3371 μs |  2.1861 μs |  10,249 B |         - |
| Encrypt · SM4-CCM (BouncyCastle)       | 8KB          |   168.492 μs |  3.1104 μs |  2.9094 μs |     387 B |     920 B |
|                                        |              |              |            |            |           |           |
| Decrypt · SM4-CCM (CryptoHives-Scalar) | 128KB        | 1,894.160 μs | 22.8413 μs | 21.3658 μs |  10,196 B |         - |
| Decrypt · SM4-CCM (BouncyCastle)       | 128KB        | 2,767.268 μs | 26.9564 μs | 25.2150 μs |     310 B |  131989 B |
|                                        |              |              |            |            |           |           |
| Encrypt · SM4-CCM (CryptoHives-Scalar) | 128KB        | 1,891.610 μs | 27.5950 μs | 25.8124 μs |  10,249 B |         - |
| Encrypt · SM4-CCM (BouncyCastle)       | 128KB        | 2,691.317 μs | 43.1938 μs | 40.4035 μs |     387 B |     920 B |