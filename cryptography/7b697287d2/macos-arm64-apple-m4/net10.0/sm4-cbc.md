| Description                            | TestDataSize | Mean           | Error       | StdDev      | Allocated |
|--------------------------------------- |------------- |---------------:|------------:|------------:|----------:|
| Decrypt · SM4-CBC (CryptoHives-Scalar) | 128B         |       905.2 ns |     1.87 ns |     1.75 ns |         - |
| Decrypt · SM4-CBC (BouncyCastle)       | 128B         |     1,339.4 ns |     7.92 ns |     7.41 ns |      40 B |
|                                        |              |                |             |             |           |
| Encrypt · SM4-CBC (CryptoHives-Scalar) | 128B         |     1,008.4 ns |     4.51 ns |     4.22 ns |         - |
| Encrypt · SM4-CBC (BouncyCastle)       | 128B         |     1,410.1 ns |     6.17 ns |     5.77 ns |      40 B |
|                                        |              |                |             |             |           |
| Decrypt · SM4-CBC (CryptoHives-Scalar) | 1KB          |     6,392.3 ns |    14.66 ns |    13.71 ns |         - |
| Decrypt · SM4-CBC (BouncyCastle)       | 1KB          |     8,557.7 ns |    41.27 ns |    38.61 ns |      40 B |
|                                        |              |                |             |             |           |
| Encrypt · SM4-CBC (CryptoHives-Scalar) | 1KB          |     7,300.8 ns |    23.43 ns |    21.91 ns |         - |
| Encrypt · SM4-CBC (BouncyCastle)       | 1KB          |     9,382.4 ns |    42.58 ns |    39.83 ns |      40 B |
|                                        |              |                |             |             |           |
| Decrypt · SM4-CBC (CryptoHives-Scalar) | 8KB          |    50,443.8 ns |   116.87 ns |   109.32 ns |         - |
| Decrypt · SM4-CBC (BouncyCastle)       | 8KB          |    65,855.3 ns |   412.49 ns |   385.84 ns |      40 B |
|                                        |              |                |             |             |           |
| Encrypt · SM4-CBC (CryptoHives-Scalar) | 8KB          |    57,608.1 ns |   112.67 ns |    94.09 ns |         - |
| Encrypt · SM4-CBC (BouncyCastle)       | 8KB          |    72,914.1 ns |   320.95 ns |   300.22 ns |      40 B |
|                                        |              |                |             |             |           |
| Decrypt · SM4-CBC (CryptoHives-Scalar) | 128KB        |   806,954.7 ns | 1,760.49 ns | 1,470.09 ns |         - |
| Decrypt · SM4-CBC (BouncyCastle)       | 128KB        | 1,052,925.6 ns | 5,297.89 ns | 4,955.65 ns |      40 B |
|                                        |              |                |             |             |           |
| Encrypt · SM4-CBC (CryptoHives-Scalar) | 128KB        |   922,642.4 ns | 3,639.53 ns | 3,404.42 ns |         - |
| Encrypt · SM4-CBC (BouncyCastle)       | 128KB        | 1,166,850.7 ns | 5,313.67 ns | 4,970.41 ns |      40 B |