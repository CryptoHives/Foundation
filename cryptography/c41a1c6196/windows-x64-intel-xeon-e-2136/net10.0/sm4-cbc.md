| Description                            | TestDataSize | Mean         | Error     | StdDev    | Code Size | Allocated |
|--------------------------------------- |------------- |-------------:|----------:|----------:|----------:|----------:|
| Decrypt · SM4-CBC (CryptoHives-Scalar) | 128B         |     1.643 μs | 0.0062 μs | 0.0055 μs |   1,311 B |         - |
| Decrypt · SM4-CBC (BouncyCastle)       | 128B         |     2.287 μs | 0.0080 μs | 0.0075 μs |   2,921 B |      40 B |
|                                        |              |              |           |           |           |           |
| Encrypt · SM4-CBC (CryptoHives-Scalar) | 128B         |     1.600 μs | 0.0174 μs | 0.0163 μs |   1,307 B |         - |
| Encrypt · SM4-CBC (BouncyCastle)       | 128B         |     2.208 μs | 0.0064 μs | 0.0060 μs |   2,933 B |      40 B |
|                                        |              |              |           |           |           |           |
| Decrypt · SM4-CBC (CryptoHives-Scalar) | 1KB          |    11.119 μs | 0.0173 μs | 0.0153 μs |   1,311 B |         - |
| Decrypt · SM4-CBC (BouncyCastle)       | 1KB          |    14.300 μs | 0.0300 μs | 0.0266 μs |   2,937 B |      40 B |
|                                        |              |              |           |           |           |           |
| Encrypt · SM4-CBC (CryptoHives-Scalar) | 1KB          |    11.202 μs | 0.0595 μs | 0.0527 μs |   1,307 B |         - |
| Encrypt · SM4-CBC (BouncyCastle)       | 1KB          |    14.214 μs | 0.0169 μs | 0.0158 μs |   2,935 B |      40 B |
|                                        |              |              |           |           |           |           |
| Decrypt · SM4-CBC (CryptoHives-Scalar) | 8KB          |    86.861 μs | 0.0463 μs | 0.0433 μs |   1,311 B |         - |
| Decrypt · SM4-CBC (BouncyCastle)       | 8KB          |   109.413 μs | 0.2042 μs | 0.1705 μs |   2,935 B |      40 B |
|                                        |              |              |           |           |           |           |
| Encrypt · SM4-CBC (CryptoHives-Scalar) | 8KB          |    87.973 μs | 0.7594 μs | 0.7103 μs |   1,305 B |         - |
| Encrypt · SM4-CBC (BouncyCastle)       | 8KB          |   109.987 μs | 0.1435 μs | 0.1272 μs |   2,935 B |      40 B |
|                                        |              |              |           |           |           |           |
| Decrypt · SM4-CBC (CryptoHives-Scalar) | 128KB        | 1,383.907 μs | 0.6297 μs | 0.5258 μs |   1,311 B |         - |
| Decrypt · SM4-CBC (BouncyCastle)       | 128KB        | 1,740.820 μs | 3.3104 μs | 2.9346 μs |   2,935 B |      40 B |
|                                        |              |              |           |           |           |           |
| Encrypt · SM4-CBC (CryptoHives-Scalar) | 128KB        | 1,396.820 μs | 5.1423 μs | 4.5585 μs |   1,305 B |         - |
| Encrypt · SM4-CBC (BouncyCastle)       | 128KB        | 1,759.585 μs | 1.4595 μs | 1.3652 μs |   2,935 B |      40 B |