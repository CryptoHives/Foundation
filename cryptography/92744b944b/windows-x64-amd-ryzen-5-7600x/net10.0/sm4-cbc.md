| Description                            | TestDataSize | Mean         | Error     | StdDev    | Allocated |
|--------------------------------------- |------------- |-------------:|----------:|----------:|----------:|
| Decrypt · SM4-CBC (CryptoHives-Scalar) | 128B         |     1.059 μs | 0.0023 μs | 0.0022 μs |         - |
| Decrypt · SM4-CBC (BouncyCastle)       | 128B         |     1.288 μs | 0.0015 μs | 0.0013 μs |      40 B |
|                                        |              |              |           |           |           |
| Encrypt · SM4-CBC (CryptoHives-Scalar) | 128B         |     1.089 μs | 0.0016 μs | 0.0015 μs |         - |
| Encrypt · SM4-CBC (BouncyCastle)       | 128B         |     1.304 μs | 0.0016 μs | 0.0015 μs |      40 B |
|                                        |              |              |           |           |           |
| Decrypt · SM4-CBC (CryptoHives-Scalar) | 1KB          |     7.552 μs | 0.0092 μs | 0.0081 μs |         - |
| Decrypt · SM4-CBC (BouncyCastle)       | 1KB          |     8.139 μs | 0.0091 μs | 0.0085 μs |      40 B |
|                                        |              |              |           |           |           |
| Encrypt · SM4-CBC (CryptoHives-Scalar) | 1KB          |     7.815 μs | 0.0095 μs | 0.0084 μs |         - |
| Encrypt · SM4-CBC (BouncyCastle)       | 1KB          |     8.289 μs | 0.0165 μs | 0.0154 μs |      40 B |
|                                        |              |              |           |           |           |
| Decrypt · SM4-CBC (CryptoHives-Scalar) | 8KB          |    59.732 μs | 0.0968 μs | 0.0906 μs |         - |
| Decrypt · SM4-CBC (BouncyCastle)       | 8KB          |    62.854 μs | 0.0865 μs | 0.0809 μs |      40 B |
|                                        |              |              |           |           |           |
| Encrypt · SM4-CBC (CryptoHives-Scalar) | 8KB          |    61.540 μs | 0.0574 μs | 0.0537 μs |         - |
| Encrypt · SM4-CBC (BouncyCastle)       | 8KB          |    64.092 μs | 0.1438 μs | 0.1345 μs |      40 B |
|                                        |              |              |           |           |           |
| Decrypt · SM4-CBC (CryptoHives-Scalar) | 128KB        |   950.801 μs | 1.1701 μs | 1.0372 μs |         - |
| Decrypt · SM4-CBC (BouncyCastle)       | 128KB        | 1,000.849 μs | 1.3062 μs | 1.2218 μs |      40 B |
|                                        |              |              |           |           |           |
| Encrypt · SM4-CBC (CryptoHives-Scalar) | 128KB        |   981.308 μs | 1.5298 μs | 1.3562 μs |         - |
| Encrypt · SM4-CBC (BouncyCastle)       | 128KB        | 1,020.790 μs | 1.3841 μs | 1.2270 μs |      40 B |