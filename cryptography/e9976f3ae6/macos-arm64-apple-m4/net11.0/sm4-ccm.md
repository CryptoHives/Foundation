| Description                            | TestDataSize | Mean         | Error      | StdDev     | Allocated |
|--------------------------------------- |------------- |-------------:|-----------:|-----------:|----------:|
| Decrypt · SM4-CCM (CryptoHives-Scalar) | 128B         |     2.151 μs |  0.0126 μs |  0.0118 μs |         - |
| Decrypt · SM4-CCM (BouncyCastle)       | 128B         |     3.210 μs |  0.0063 μs |  0.0059 μs |    1000 B |
|                                        |              |              |            |            |           |
| Encrypt · SM4-CCM (CryptoHives-Scalar) | 128B         |     2.105 μs |  0.0153 μs |  0.0143 μs |         - |
| Encrypt · SM4-CCM (BouncyCastle)       | 128B         |     3.155 μs |  0.0105 μs |  0.0093 μs |     848 B |
|                                        |              |              |            |            |           |
| Decrypt · SM4-CCM (CryptoHives-Scalar) | 1KB          |    13.762 μs |  0.0445 μs |  0.0416 μs |         - |
| Decrypt · SM4-CCM (BouncyCastle)       | 1KB          |    18.712 μs |  0.0807 μs |  0.0674 μs |    1896 B |
|                                        |              |              |            |            |           |
| Encrypt · SM4-CCM (CryptoHives-Scalar) | 1KB          |    13.718 μs |  0.0228 μs |  0.0213 μs |         - |
| Encrypt · SM4-CCM (BouncyCastle)       | 1KB          |    18.672 μs |  0.1025 μs |  0.0959 μs |     848 B |
|                                        |              |              |            |            |           |
| Decrypt · SM4-CCM (CryptoHives-Scalar) | 8KB          |   106.601 μs |  0.2748 μs |  0.2571 μs |         - |
| Decrypt · SM4-CCM (BouncyCastle)       | 8KB          |   142.991 μs |  0.7754 μs |  0.7253 μs |    9064 B |
|                                        |              |              |            |            |           |
| Encrypt · SM4-CCM (CryptoHives-Scalar) | 8KB          |   106.750 μs |  0.1485 μs |  0.1240 μs |         - |
| Encrypt · SM4-CCM (BouncyCastle)       | 8KB          |   142.422 μs |  0.4800 μs |  0.4255 μs |     848 B |
|                                        |              |              |            |            |           |
| Decrypt · SM4-CCM (CryptoHives-Scalar) | 128KB        | 1,699.598 μs |  5.6662 μs |  5.3001 μs |         - |
| Decrypt · SM4-CCM (BouncyCastle)       | 128KB        | 2,283.566 μs |  8.8008 μs |  8.2323 μs |  131968 B |
|                                        |              |              |            |            |           |
| Encrypt · SM4-CCM (CryptoHives-Scalar) | 128KB        | 1,698.396 μs |  3.8559 μs |  3.6068 μs |         - |
| Encrypt · SM4-CCM (BouncyCastle)       | 128KB        | 2,269.361 μs | 11.7168 μs | 10.9599 μs |     848 B |