| Description                            | TestDataSize | Mean         | Error      | StdDev     | Code Size | Allocated |
|--------------------------------------- |------------- |-------------:|-----------:|-----------:|----------:|----------:|
| Decrypt · SM4-CBC (CryptoHives-Scalar) | 128B         |     1.265 μs |  0.0160 μs |  0.0150 μs |   1,311 B |         - |
| Decrypt · SM4-CBC (BouncyCastle)       | 128B         |     1.723 μs |  0.0245 μs |  0.0229 μs |   2,937 B |      40 B |
|                                        |              |              |            |            |           |           |
| Encrypt · SM4-CBC (CryptoHives-Scalar) | 128B         |     1.212 μs |  0.0054 μs |  0.0048 μs |   1,307 B |         - |
| Encrypt · SM4-CBC (BouncyCastle)       | 128B         |     1.674 μs |  0.0262 μs |  0.0245 μs |   2,935 B |      40 B |
|                                        |              |              |            |            |           |           |
| Decrypt · SM4-CBC (CryptoHives-Scalar) | 1KB          |     8.473 μs |  0.0737 μs |  0.0689 μs |   1,311 B |         - |
| Decrypt · SM4-CBC (BouncyCastle)       | 1KB          |    10.949 μs |  0.1320 μs |  0.1234 μs |   2,937 B |      40 B |
|                                        |              |              |            |            |           |           |
| Encrypt · SM4-CBC (CryptoHives-Scalar) | 1KB          |     8.508 μs |  0.1212 μs |  0.1134 μs |   1,307 B |         - |
| Encrypt · SM4-CBC (BouncyCastle)       | 1KB          |    10.824 μs |  0.1744 μs |  0.1631 μs |   2,935 B |      40 B |
|                                        |              |              |            |            |           |           |
| Decrypt · SM4-CBC (CryptoHives-Scalar) | 8KB          |    66.111 μs |  1.0419 μs |  0.9746 μs |   1,311 B |         - |
| Decrypt · SM4-CBC (BouncyCastle)       | 8KB          |    82.758 μs |  1.2625 μs |  1.1809 μs |   2,935 B |      40 B |
|                                        |              |              |            |            |           |           |
| Encrypt · SM4-CBC (CryptoHives-Scalar) | 8KB          |    66.605 μs |  0.6753 μs |  0.6317 μs |   1,305 B |         - |
| Encrypt · SM4-CBC (BouncyCastle)       | 8KB          |    83.580 μs |  1.4673 μs |  1.3725 μs |   2,935 B |      40 B |
|                                        |              |              |            |            |           |           |
| Decrypt · SM4-CBC (CryptoHives-Scalar) | 128KB        | 1,055.449 μs | 16.7532 μs | 15.6709 μs |   1,311 B |         - |
| Decrypt · SM4-CBC (BouncyCastle)       | 128KB        | 1,342.193 μs | 21.8678 μs | 20.4551 μs |   2,935 B |      40 B |
|                                        |              |              |            |            |           |           |
| Encrypt · SM4-CBC (CryptoHives-Scalar) | 128KB        | 1,055.892 μs | 18.0102 μs | 16.8467 μs |   1,305 B |         - |
| Encrypt · SM4-CBC (BouncyCastle)       | 128KB        | 1,347.607 μs |  4.8556 μs |  4.5419 μs |   2,935 B |      40 B |