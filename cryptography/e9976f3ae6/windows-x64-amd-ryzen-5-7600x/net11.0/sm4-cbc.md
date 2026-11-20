| Description                            | TestDataSize | Mean         | Error     | StdDev    | Code Size | Allocated |
|--------------------------------------- |------------- |-------------:|----------:|----------:|----------:|----------:|
| Decrypt · SM4-CBC (CryptoHives-Scalar) | 128B         |     1.021 μs | 0.0085 μs | 0.0079 μs |  10,737 B |         - |
| Decrypt · SM4-CBC (BouncyCastle)       | 128B         |     1.515 μs | 0.0226 μs | 0.0211 μs |  13,688 B |      40 B |
|                                        |              |              |           |           |           |           |
| Encrypt · SM4-CBC (CryptoHives-Scalar) | 128B         |     1.025 μs | 0.0023 μs | 0.0021 μs |   3,997 B |         - |
| Encrypt · SM4-CBC (BouncyCastle)       | 128B         |     1.484 μs | 0.0018 μs | 0.0015 μs |   7,734 B |      40 B |
|                                        |              |              |           |           |           |           |
| Decrypt · SM4-CBC (CryptoHives-Scalar) | 1KB          |     7.015 μs | 0.0140 μs | 0.0110 μs |  10,522 B |         - |
| Decrypt · SM4-CBC (BouncyCastle)       | 1KB          |     9.685 μs | 0.0344 μs | 0.0322 μs |  13,693 B |      40 B |
|                                        |              |              |           |           |           |           |
| Encrypt · SM4-CBC (CryptoHives-Scalar) | 1KB          |     7.273 μs | 0.0145 μs | 0.0135 μs |   3,997 B |         - |
| Encrypt · SM4-CBC (BouncyCastle)       | 1KB          |     9.682 μs | 0.0088 μs | 0.0078 μs |   7,738 B |      40 B |
|                                        |              |              |           |           |           |           |
| Decrypt · SM4-CBC (CryptoHives-Scalar) | 8KB          |    56.368 μs | 0.1858 μs | 0.1647 μs |   3,997 B |         - |
| Decrypt · SM4-CBC (BouncyCastle)       | 8KB          |    74.704 μs | 0.2760 μs | 0.2305 μs |  13,883 B |      40 B |
|                                        |              |              |           |           |           |           |
| Encrypt · SM4-CBC (CryptoHives-Scalar) | 8KB          |    57.135 μs | 0.0210 μs | 0.0175 μs |  10,522 B |         - |
| Encrypt · SM4-CBC (BouncyCastle)       | 8KB          |    75.913 μs | 0.0604 μs | 0.0536 μs |   7,734 B |      40 B |
|                                        |              |              |           |           |           |           |
| Decrypt · SM4-CBC (CryptoHives-Scalar) | 128KB        |   877.312 μs | 1.0372 μs | 0.8098 μs |   3,997 B |         - |
| Decrypt · SM4-CBC (BouncyCastle)       | 128KB        | 1,190.411 μs | 3.8503 μs | 3.6016 μs |   7,738 B |      40 B |
|                                        |              |              |           |           |           |           |
| Encrypt · SM4-CBC (CryptoHives-Scalar) | 128KB        |   914.003 μs | 1.6580 μs | 1.3845 μs |  10,522 B |         - |
| Encrypt · SM4-CBC (BouncyCastle)       | 128KB        | 1,223.106 μs | 9.0927 μs | 8.5053 μs |  13,693 B |      40 B |