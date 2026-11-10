| Description                            | TestDataSize | Mean         | Error     | StdDev    | Code Size | Allocated |
|--------------------------------------- |------------- |-------------:|----------:|----------:|----------:|----------:|
| Decrypt · SM4-CCM (CryptoHives-Scalar) | 128B         |     3.218 μs | 0.0033 μs | 0.0030 μs |  10,188 B |         - |
| Decrypt · SM4-CCM (BouncyCastle)       | 128B         |     5.342 μs | 0.0113 μs | 0.0106 μs |     310 B |    1032 B |
|                                        |              |              |           |           |           |           |
| Encrypt · SM4-CCM (CryptoHives-Scalar) | 128B         |     3.124 μs | 0.0031 μs | 0.0028 μs |  10,241 B |         - |
| Encrypt · SM4-CCM (BouncyCastle)       | 128B         |     5.235 μs | 0.0137 μs | 0.0122 μs |     387 B |     920 B |
|                                        |              |              |           |           |           |           |
| Decrypt · SM4-CCM (CryptoHives-Scalar) | 1KB          |    20.452 μs | 0.0407 μs | 0.0381 μs |  10,192 B |         - |
| Decrypt · SM4-CCM (BouncyCastle)       | 1KB          |    29.654 μs | 0.0327 μs | 0.0306 μs |     310 B |    1928 B |
|                                        |              |              |           |           |           |           |
| Encrypt · SM4-CCM (CryptoHives-Scalar) | 1KB          |    20.359 μs | 0.0960 μs | 0.0898 μs |  10,238 B |         - |
| Encrypt · SM4-CCM (BouncyCastle)       | 1KB          |    29.438 μs | 0.0322 μs | 0.0301 μs |     387 B |     920 B |
|                                        |              |              |           |           |           |           |
| Decrypt · SM4-CCM (CryptoHives-Scalar) | 8KB          |   157.217 μs | 0.0957 μs | 0.0848 μs |  10,199 B |         - |
| Decrypt · SM4-CCM (BouncyCastle)       | 8KB          |   224.352 μs | 0.1685 μs | 0.1407 μs |     310 B |    9096 B |
|                                        |              |              |           |           |           |           |
| Encrypt · SM4-CCM (CryptoHives-Scalar) | 8KB          |   156.188 μs | 0.1465 μs | 0.1371 μs |  10,249 B |         - |
| Encrypt · SM4-CCM (BouncyCastle)       | 8KB          |   223.751 μs | 0.1817 μs | 0.1518 μs |     387 B |     920 B |
|                                        |              |              |           |           |           |           |
| Decrypt · SM4-CCM (CryptoHives-Scalar) | 128KB        | 2,489.308 μs | 1.9735 μs | 1.8460 μs |  10,196 B |         - |
| Decrypt · SM4-CCM (BouncyCastle)       | 128KB        | 3,631.976 μs | 3.0192 μs | 2.6765 μs |     310 B |  131989 B |
|                                        |              |              |           |           |           |           |
| Encrypt · SM4-CCM (CryptoHives-Scalar) | 128KB        | 2,493.814 μs | 2.5571 μs | 2.2668 μs |  10,249 B |         - |
| Encrypt · SM4-CCM (BouncyCastle)       | 128KB        | 3,551.146 μs | 2.9270 μs | 2.4442 μs |     387 B |     920 B |