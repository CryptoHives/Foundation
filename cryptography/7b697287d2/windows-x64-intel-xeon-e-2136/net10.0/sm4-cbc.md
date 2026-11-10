| Description                            | TestDataSize | Mean         | Error     | StdDev    | Code Size | Allocated |
|--------------------------------------- |------------- |-------------:|----------:|----------:|----------:|----------:|
| Decrypt · SM4-CBC (CryptoHives-Scalar) | 128B         |     1.654 μs | 0.0031 μs | 0.0027 μs |   1,311 B |         - |
| Decrypt · SM4-CBC (BouncyCastle)       | 128B         |     2.265 μs | 0.0030 μs | 0.0028 μs |   2,937 B |      40 B |
|                                        |              |              |           |           |           |           |
| Encrypt · SM4-CBC (CryptoHives-Scalar) | 128B         |     1.591 μs | 0.0100 μs | 0.0094 μs |   1,307 B |         - |
| Encrypt · SM4-CBC (BouncyCastle)       | 128B         |     2.204 μs | 0.0037 μs | 0.0030 μs |   2,935 B |      40 B |
|                                        |              |              |           |           |           |           |
| Decrypt · SM4-CBC (CryptoHives-Scalar) | 1KB          |    11.085 μs | 0.0085 μs | 0.0076 μs |   1,311 B |         - |
| Decrypt · SM4-CBC (BouncyCastle)       | 1KB          |    14.322 μs | 0.0093 μs | 0.0087 μs |   2,937 B |      40 B |
|                                        |              |              |           |           |           |           |
| Encrypt · SM4-CBC (CryptoHives-Scalar) | 1KB          |    11.219 μs | 0.1040 μs | 0.0973 μs |   1,307 B |         - |
| Encrypt · SM4-CBC (BouncyCastle)       | 1KB          |    14.199 μs | 0.0132 μs | 0.0124 μs |   2,935 B |      40 B |
|                                        |              |              |           |           |           |           |
| Decrypt · SM4-CBC (CryptoHives-Scalar) | 8KB          |    86.983 μs | 0.0457 μs | 0.0427 μs |   1,311 B |         - |
| Decrypt · SM4-CBC (BouncyCastle)       | 8KB          |   108.921 μs | 0.1888 μs | 0.1766 μs |   2,935 B |      40 B |
|                                        |              |              |           |           |           |           |
| Encrypt · SM4-CBC (CryptoHives-Scalar) | 8KB          |    87.333 μs | 0.2311 μs | 0.2162 μs |   1,305 B |         - |
| Encrypt · SM4-CBC (BouncyCastle)       | 8KB          |   110.100 μs | 0.1160 μs | 0.1029 μs |   2,935 B |      40 B |
|                                        |              |              |           |           |           |           |
| Decrypt · SM4-CBC (CryptoHives-Scalar) | 128KB        | 1,385.870 μs | 0.7532 μs | 0.6677 μs |   1,311 B |         - |
| Decrypt · SM4-CBC (BouncyCastle)       | 128KB        | 1,739.176 μs | 3.6623 μs | 3.4257 μs |   2,935 B |      40 B |
|                                        |              |              |           |           |           |           |
| Encrypt · SM4-CBC (CryptoHives-Scalar) | 128KB        | 1,392.454 μs | 2.2625 μs | 1.8893 μs |   1,305 B |         - |
| Encrypt · SM4-CBC (BouncyCastle)       | 128KB        | 1,761.755 μs | 2.4671 μs | 2.1870 μs |   2,935 B |      40 B |