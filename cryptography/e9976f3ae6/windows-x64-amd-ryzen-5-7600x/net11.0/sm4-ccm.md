| Description                            | TestDataSize | Mean         | Error     | StdDev    | Code Size | Allocated |
|--------------------------------------- |------------- |-------------:|----------:|----------:|----------:|----------:|
| Decrypt · SM4-CCM (CryptoHives-Scalar) | 128B         |     2.211 μs | 0.0074 μs | 0.0066 μs |  20,970 B |         - |
| Decrypt · SM4-CCM (BouncyCastle)       | 128B         |     3.498 μs | 0.0193 μs | 0.0151 μs |     306 B |    1000 B |
|                                        |              |              |           |           |           |           |
| Encrypt · SM4-CCM (CryptoHives-Scalar) | 128B         |     2.173 μs | 0.0034 μs | 0.0030 μs |  22,512 B |         - |
| Encrypt · SM4-CCM (BouncyCastle)       | 128B         |     3.434 μs | 0.0068 μs | 0.0060 μs |     386 B |     848 B |
|                                        |              |              |           |           |           |           |
| Decrypt · SM4-CCM (CryptoHives-Scalar) | 1KB          |    14.150 μs | 0.0329 μs | 0.0308 μs |  22,264 B |         - |
| Decrypt · SM4-CCM (BouncyCastle)       | 1KB          |    20.228 μs | 0.0576 μs | 0.0481 μs |     306 B |    1896 B |
|                                        |              |              |           |           |           |           |
| Encrypt · SM4-CCM (CryptoHives-Scalar) | 1KB          |    14.194 μs | 0.0456 μs | 0.0356 μs |  23,175 B |         - |
| Encrypt · SM4-CCM (BouncyCastle)       | 1KB          |    20.073 μs | 0.0225 μs | 0.0175 μs |     386 B |     848 B |
|                                        |              |              |           |           |           |           |
| Decrypt · SM4-CCM (CryptoHives-Scalar) | 8KB          |   109.247 μs | 0.1560 μs | 0.1303 μs |  26,979 B |         - |
| Decrypt · SM4-CCM (BouncyCastle)       | 8KB          |   154.350 μs | 0.7282 μs | 0.6812 μs |     306 B |    9064 B |
|                                        |              |              |           |           |           |           |
| Encrypt · SM4-CCM (CryptoHives-Scalar) | 8KB          |   109.257 μs | 0.0790 μs | 0.0700 μs |  22,258 B |         - |
| Encrypt · SM4-CCM (BouncyCastle)       | 8KB          |   153.387 μs | 0.2540 μs | 0.1983 μs |     386 B |     848 B |
|                                        |              |              |           |           |           |           |
| Decrypt · SM4-CCM (CryptoHives-Scalar) | 128KB        | 1,740.359 μs | 1.9606 μs | 1.8340 μs |  20,648 B |         - |
| Decrypt · SM4-CCM (BouncyCastle)       | 128KB        | 2,506.094 μs | 6.0908 μs | 5.3994 μs |     306 B |  131995 B |
|                                        |              |              |           |           |           |           |
| Encrypt · SM4-CCM (CryptoHives-Scalar) | 128KB        | 1,751.023 μs | 1.2187 μs | 1.0804 μs |  22,355 B |         - |
| Encrypt · SM4-CCM (BouncyCastle)       | 128KB        | 2,449.896 μs | 6.8934 μs | 5.7563 μs |     386 B |     848 B |