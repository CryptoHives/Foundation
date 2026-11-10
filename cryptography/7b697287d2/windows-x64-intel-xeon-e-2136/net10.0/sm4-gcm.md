| Description                            | TestDataSize | Mean         | Error      | StdDev     | Code Size | Allocated |
|--------------------------------------- |------------- |-------------:|-----------:|-----------:|----------:|----------:|
| Decrypt · SM4-GCM (CryptoHives-PClMul) | 128B         |     1.425 μs |  0.0086 μs |  0.0072 μs |     310 B |         - |
| Decrypt · SM4-GCM (CryptoHives-Scalar) | 128B         |     2.518 μs |  0.0112 μs |  0.0093 μs |     310 B |         - |
| Decrypt · SM4-GCM (BouncyCastle)       | 128B         |     2.696 μs |  0.0033 μs |  0.0031 μs |     310 B |     832 B |
|                                        |              |              |            |            |           |           |
| Encrypt · SM4-GCM (CryptoHives-PClMul) | 128B         |     1.353 μs |  0.0096 μs |  0.0090 μs |     387 B |         - |
| Encrypt · SM4-GCM (CryptoHives-Scalar) | 128B         |     2.426 μs |  0.0058 μs |  0.0051 μs |     387 B |         - |
| Encrypt · SM4-GCM (BouncyCastle)       | 128B         |     2.497 μs |  0.0023 μs |  0.0020 μs |     387 B |     816 B |
|                                        |              |              |            |            |           |           |
| Decrypt · SM4-GCM (CryptoHives-PClMul) | 1KB          |     9.380 μs |  0.0110 μs |  0.0092 μs |     310 B |         - |
| Decrypt · SM4-GCM (BouncyCastle)       | 1KB          |    13.849 μs |  0.0163 μs |  0.0153 μs |     310 B |     832 B |
| Decrypt · SM4-GCM (CryptoHives-Scalar) | 1KB          |    16.732 μs |  0.1436 μs |  0.1273 μs |     310 B |         - |
|                                        |              |              |            |            |           |           |
| Encrypt · SM4-GCM (CryptoHives-PClMul) | 1KB          |     9.300 μs |  0.0509 μs |  0.0425 μs |     387 B |         - |
| Encrypt · SM4-GCM (BouncyCastle)       | 1KB          |    13.458 μs |  0.0211 μs |  0.0176 μs |     387 B |     816 B |
| Encrypt · SM4-GCM (CryptoHives-Scalar) | 1KB          |    16.578 μs |  0.0689 μs |  0.0611 μs |     387 B |         - |
|                                        |              |              |            |            |           |           |
| Decrypt · SM4-GCM (CryptoHives-PClMul) | 8KB          |    72.524 μs |  0.0445 μs |  0.0394 μs |     310 B |         - |
| Decrypt · SM4-GCM (BouncyCastle)       | 8KB          |   102.854 μs |  0.0834 μs |  0.0739 μs |     310 B |     832 B |
| Decrypt · SM4-GCM (CryptoHives-Scalar) | 8KB          |   129.385 μs |  0.3178 μs |  0.2654 μs |     310 B |         - |
|                                        |              |              |            |            |           |           |
| Encrypt · SM4-GCM (CryptoHives-PClMul) | 8KB          |    73.223 μs |  0.2188 μs |  0.2047 μs |     387 B |         - |
| Encrypt · SM4-GCM (BouncyCastle)       | 8KB          |   101.009 μs |  0.1176 μs |  0.0982 μs |     387 B |     816 B |
| Encrypt · SM4-GCM (CryptoHives-Scalar) | 8KB          |   130.328 μs |  0.4755 μs |  0.4215 μs |     387 B |         - |
|                                        |              |              |            |            |           |           |
| Decrypt · SM4-GCM (CryptoHives-PClMul) | 128KB        | 1,197.979 μs |  3.7281 μs |  3.4873 μs |     310 B |         - |
| Decrypt · SM4-GCM (BouncyCastle)       | 128KB        | 1,617.833 μs |  1.0624 μs |  0.9938 μs |     310 B |     832 B |
| Decrypt · SM4-GCM (CryptoHives-Scalar) | 128KB        | 2,069.786 μs | 13.9975 μs | 11.6885 μs |     310 B |         - |
|                                        |              |              |            |            |           |           |
| Encrypt · SM4-GCM (CryptoHives-PClMul) | 128KB        | 1,168.204 μs |  1.3653 μs |  1.0659 μs |     387 B |         - |
| Encrypt · SM4-GCM (BouncyCastle)       | 128KB        | 1,606.842 μs |  0.8920 μs |  0.8344 μs |     387 B |     816 B |
| Encrypt · SM4-GCM (CryptoHives-Scalar) | 128KB        | 2,071.852 μs | 14.7551 μs | 13.8019 μs |     387 B |         - |