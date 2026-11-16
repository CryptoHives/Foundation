| Description                            | TestDataSize | Mean         | Error     | StdDev    | Code Size | Allocated |
|--------------------------------------- |------------- |-------------:|----------:|----------:|----------:|----------:|
| Decrypt · SM4-CCM (CryptoHives-Scalar) | 128B         |     3.249 μs | 0.0033 μs | 0.0028 μs |  10,185 B |         - |
| Decrypt · SM4-CCM (BouncyCastle)       | 128B         |     5.353 μs | 0.0536 μs | 0.0501 μs |     310 B |    1032 B |
|                                        |              |              |           |           |           |           |
| Encrypt · SM4-CCM (CryptoHives-Scalar) | 128B         |     3.132 μs | 0.0091 μs | 0.0080 μs |  10,238 B |         - |
| Encrypt · SM4-CCM (BouncyCastle)       | 128B         |     5.241 μs | 0.0186 μs | 0.0174 μs |     390 B |     920 B |
|                                        |              |              |           |           |           |           |
| Decrypt · SM4-CCM (CryptoHives-Scalar) | 1KB          |    20.302 μs | 0.0487 μs | 0.0455 μs |  10,195 B |         - |
| Decrypt · SM4-CCM (BouncyCastle)       | 1KB          |    29.651 μs | 0.0563 μs | 0.0499 μs |     310 B |    1928 B |
|                                        |              |              |           |           |           |           |
| Encrypt · SM4-CCM (CryptoHives-Scalar) | 1KB          |    20.190 μs | 0.0486 μs | 0.0454 μs |  10,238 B |         - |
| Encrypt · SM4-CCM (BouncyCastle)       | 1KB          |    29.447 μs | 0.0292 μs | 0.0273 μs |     387 B |     920 B |
|                                        |              |              |           |           |           |           |
| Decrypt · SM4-CCM (CryptoHives-Scalar) | 8KB          |   156.053 μs | 0.1654 μs | 0.1292 μs |  10,196 B |         - |
| Decrypt · SM4-CCM (BouncyCastle)       | 8KB          |   224.251 μs | 0.3803 μs | 0.3558 μs |     310 B |    9096 B |
|                                        |              |              |           |           |           |           |
| Encrypt · SM4-CCM (CryptoHives-Scalar) | 8KB          |   156.041 μs | 0.2540 μs | 0.2376 μs |  10,249 B |         - |
| Encrypt · SM4-CCM (BouncyCastle)       | 8KB          |   223.430 μs | 0.5746 μs | 0.5374 μs |     387 B |     920 B |
|                                        |              |              |           |           |           |           |
| Decrypt · SM4-CCM (CryptoHives-Scalar) | 128KB        | 2,493.537 μs | 6.0422 μs | 5.6519 μs |  10,196 B |         - |
| Decrypt · SM4-CCM (BouncyCastle)       | 128KB        | 3,613.751 μs | 4.1154 μs | 3.8495 μs |     310 B |  131989 B |
|                                        |              |              |           |           |           |           |
| Encrypt · SM4-CCM (CryptoHives-Scalar) | 128KB        | 2,494.557 μs | 5.0030 μs | 4.4350 μs |  10,249 B |         - |
| Encrypt · SM4-CCM (BouncyCastle)       | 128KB        | 3,550.224 μs | 7.8157 μs | 6.9284 μs |     387 B |     920 B |