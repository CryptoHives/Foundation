| Description                            | TestDataSize | Mean         | Error     | StdDev    | Code Size | Allocated |
|--------------------------------------- |------------- |-------------:|----------:|----------:|----------:|----------:|
| Decrypt · SM4-CCM (CryptoHives-Scalar) | 128B         |     2.194 μs | 0.0013 μs | 0.0011 μs |  10,033 B |         - |
| Decrypt · SM4-CCM (BouncyCastle)       | 128B         |     3.429 μs | 0.0031 μs | 0.0029 μs |     306 B |    1032 B |
|                                        |              |              |           |           |           |           |
| Encrypt · SM4-CCM (CryptoHives-Scalar) | 128B         |     2.169 μs | 0.0018 μs | 0.0016 μs |  10,071 B |         - |
| Encrypt · SM4-CCM (BouncyCastle)       | 128B         |     3.375 μs | 0.0028 μs | 0.0025 μs |     383 B |     920 B |
|                                        |              |              |           |           |           |           |
| Decrypt · SM4-CCM (CryptoHives-Scalar) | 1KB          |    14.031 μs | 0.0068 μs | 0.0063 μs |  10,043 B |         - |
| Decrypt · SM4-CCM (BouncyCastle)       | 1KB          |    20.020 μs | 0.0172 μs | 0.0161 μs |     306 B |    1928 B |
|                                        |              |              |           |           |           |           |
| Encrypt · SM4-CCM (CryptoHives-Scalar) | 1KB          |    14.031 μs | 0.0064 μs | 0.0060 μs |  10,084 B |         - |
| Encrypt · SM4-CCM (BouncyCastle)       | 1KB          |    19.920 μs | 0.0221 μs | 0.0207 μs |     383 B |     920 B |
|                                        |              |              |           |           |           |           |
| Decrypt · SM4-CCM (CryptoHives-Scalar) | 8KB          |   108.996 μs | 0.0675 μs | 0.0631 μs |  10,047 B |         - |
| Decrypt · SM4-CCM (BouncyCastle)       | 8KB          |   152.827 μs | 0.1189 μs | 0.1113 μs |     306 B |    9096 B |
|                                        |              |              |           |           |           |           |
| Encrypt · SM4-CCM (CryptoHives-Scalar) | 8KB          |   108.675 μs | 0.0466 μs | 0.0413 μs |  10,085 B |         - |
| Encrypt · SM4-CCM (BouncyCastle)       | 8KB          |   152.127 μs | 0.1434 μs | 0.1342 μs |     383 B |     920 B |
|                                        |              |              |           |           |           |           |
| Decrypt · SM4-CCM (CryptoHives-Scalar) | 128KB        | 1,731.941 μs | 0.7269 μs | 0.6800 μs |  10,047 B |         - |
| Decrypt · SM4-CCM (BouncyCastle)       | 128KB        | 2,460.918 μs | 2.4064 μs | 2.2510 μs |     306 B |  131989 B |
|                                        |              |              |           |           |           |           |
| Encrypt · SM4-CCM (CryptoHives-Scalar) | 128KB        | 1,736.793 μs | 1.2683 μs | 1.1863 μs |  10,085 B |         - |
| Encrypt · SM4-CCM (BouncyCastle)       | 128KB        | 2,420.180 μs | 2.1621 μs | 1.9167 μs |     383 B |     920 B |