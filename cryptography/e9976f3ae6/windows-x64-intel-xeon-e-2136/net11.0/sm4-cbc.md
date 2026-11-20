| Description                            | TestDataSize | Mean         | Error      | StdDev     | Code Size | Allocated |
|--------------------------------------- |------------- |-------------:|-----------:|-----------:|----------:|----------:|
| Decrypt · SM4-CBC (CryptoHives-Scalar) | 128B         |     1.607 μs |  0.0049 μs |  0.0041 μs |  10,361 B |         - |
| Decrypt · SM4-CBC (BouncyCastle)       | 128B         |     2.275 μs |  0.0084 μs |  0.0074 μs |   7,776 B |      40 B |
|                                        |              |              |            |            |           |           |
| Encrypt · SM4-CBC (CryptoHives-Scalar) | 128B         |     1.589 μs |  0.0101 μs |  0.0094 μs |   4,026 B |         - |
| Encrypt · SM4-CBC (BouncyCastle)       | 128B         |     2.183 μs |  0.0027 μs |  0.0024 μs |  13,735 B |      40 B |
|                                        |              |              |            |            |           |           |
| Decrypt · SM4-CBC (CryptoHives-Scalar) | 1KB          |    11.215 μs |  0.0674 μs |  0.0597 μs |  10,361 B |         - |
| Decrypt · SM4-CBC (BouncyCastle)       | 1KB          |    14.199 μs |  0.0153 μs |  0.0128 μs |  13,735 B |      40 B |
|                                        |              |              |            |            |           |           |
| Encrypt · SM4-CBC (CryptoHives-Scalar) | 1KB          |    11.097 μs |  0.0483 μs |  0.0452 μs |  10,361 B |         - |
| Encrypt · SM4-CBC (BouncyCastle)       | 1KB          |    14.081 μs |  0.0266 μs |  0.0236 μs |  13,735 B |      40 B |
|                                        |              |              |            |            |           |           |
| Decrypt · SM4-CBC (CryptoHives-Scalar) | 8KB          |    87.700 μs |  0.4040 μs |  0.3374 μs |   4,026 B |         - |
| Decrypt · SM4-CBC (BouncyCastle)       | 8KB          |   109.502 μs |  0.1520 μs |  0.1348 μs |   7,776 B |      40 B |
|                                        |              |              |            |            |           |           |
| Encrypt · SM4-CBC (CryptoHives-Scalar) | 8KB          |    86.961 μs |  0.1859 μs |  0.1552 μs |  10,551 B |         - |
| Encrypt · SM4-CBC (BouncyCastle)       | 8KB          |   108.652 μs |  0.0839 μs |  0.0785 μs |   7,776 B |      40 B |
|                                        |              |              |            |            |           |           |
| Decrypt · SM4-CBC (CryptoHives-Scalar) | 128KB        | 1,418.857 μs | 18.7473 μs | 16.6190 μs |   4,026 B |         - |
| Decrypt · SM4-CBC (BouncyCastle)       | 128KB        | 1,759.790 μs | 11.2491 μs | 10.5224 μs |  13,925 B |      40 B |
|                                        |              |              |            |            |           |           |
| Encrypt · SM4-CBC (CryptoHives-Scalar) | 128KB        | 1,391.847 μs |  6.5305 μs |  5.7891 μs |  10,361 B |         - |
| Encrypt · SM4-CBC (BouncyCastle)       | 128KB        | 1,734.707 μs |  0.6385 μs |  0.5332 μs |  13,737 B |      40 B |