| Description                            | TestDataSize | Mean         | Error      | StdDev     | Code Size | Allocated |
|--------------------------------------- |------------- |-------------:|-----------:|-----------:|----------:|----------:|
| Decrypt · SM4-GCM (CryptoHives-PClMul) | 128B         |     1.053 μs |  0.0026 μs |  0.0023 μs |     310 B |         - |
| Decrypt · SM4-GCM (CryptoHives-Scalar) | 128B         |     1.872 μs |  0.0023 μs |  0.0018 μs |     310 B |         - |
| Decrypt · SM4-GCM (BouncyCastle)       | 128B         |     1.997 μs |  0.0047 μs |  0.0044 μs |     310 B |     832 B |
|                                        |              |              |            |            |           |           |
| Encrypt · SM4-GCM (CryptoHives-PClMul) | 128B         |     1.022 μs |  0.0155 μs |  0.0145 μs |     387 B |         - |
| Encrypt · SM4-GCM (CryptoHives-Scalar) | 128B         |     1.851 μs |  0.0264 μs |  0.0247 μs |     387 B |         - |
| Encrypt · SM4-GCM (BouncyCastle)       | 128B         |     1.889 μs |  0.0336 μs |  0.0314 μs |     390 B |     816 B |
|                                        |              |              |            |            |           |           |
| Decrypt · SM4-GCM (CryptoHives-PClMul) | 1KB          |     6.932 μs |  0.0098 μs |  0.0082 μs |     310 B |         - |
| Decrypt · SM4-GCM (BouncyCastle)       | 1KB          |    10.233 μs |  0.0158 μs |  0.0132 μs |     310 B |     832 B |
| Decrypt · SM4-GCM (CryptoHives-Scalar) | 1KB          |    12.234 μs |  0.0309 μs |  0.0274 μs |     310 B |         - |
|                                        |              |              |            |            |           |           |
| Encrypt · SM4-GCM (CryptoHives-PClMul) | 1KB          |     7.083 μs |  0.0970 μs |  0.0908 μs |     390 B |         - |
| Encrypt · SM4-GCM (BouncyCastle)       | 1KB          |    10.278 μs |  0.1493 μs |  0.1396 μs |     387 B |     816 B |
| Encrypt · SM4-GCM (CryptoHives-Scalar) | 1KB          |    12.635 μs |  0.1595 μs |  0.1492 μs |     387 B |         - |
|                                        |              |              |            |            |           |           |
| Decrypt · SM4-GCM (CryptoHives-PClMul) | 8KB          |    53.504 μs |  0.0621 μs |  0.0581 μs |     310 B |         - |
| Decrypt · SM4-GCM (BouncyCastle)       | 8KB          |    76.132 μs |  0.1970 μs |  0.1843 μs |     310 B |     832 B |
| Decrypt · SM4-GCM (CryptoHives-Scalar) | 8KB          |    95.381 μs |  0.1853 μs |  0.1733 μs |     310 B |         - |
|                                        |              |              |            |            |           |           |
| Encrypt · SM4-GCM (CryptoHives-PClMul) | 8KB          |    54.972 μs |  0.8487 μs |  0.7939 μs |     387 B |         - |
| Encrypt · SM4-GCM (BouncyCastle)       | 8KB          |    77.400 μs |  1.3941 μs |  1.3040 μs |     387 B |     816 B |
| Encrypt · SM4-GCM (CryptoHives-Scalar) | 8KB          |    98.417 μs |  1.4004 μs |  1.3099 μs |     387 B |         - |
|                                        |              |              |            |            |           |           |
| Decrypt · SM4-GCM (CryptoHives-PClMul) | 128KB        |   874.845 μs | 11.1387 μs | 10.4191 μs |     310 B |         - |
| Decrypt · SM4-GCM (BouncyCastle)       | 128KB        | 1,235.895 μs | 15.8177 μs | 14.7959 μs |     310 B |     832 B |
| Decrypt · SM4-GCM (CryptoHives-Scalar) | 128KB        | 1,564.844 μs | 23.7383 μs | 22.2048 μs |     310 B |         - |
|                                        |              |              |            |            |           |           |
| Encrypt · SM4-GCM (CryptoHives-PClMul) | 128KB        |   880.750 μs | 14.7707 μs | 13.8166 μs |     387 B |         - |
| Encrypt · SM4-GCM (BouncyCastle)       | 128KB        | 1,201.151 μs | 21.0840 μs | 19.7220 μs |     387 B |     816 B |
| Encrypt · SM4-GCM (CryptoHives-Scalar) | 128KB        | 1,558.989 μs | 27.3008 μs | 25.5372 μs |     387 B |         - |