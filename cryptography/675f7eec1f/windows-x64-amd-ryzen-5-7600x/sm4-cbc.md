| Description                            | TestDataSize | Mean           | Error       | StdDev      | Allocated |
|--------------------------------------- |------------- |---------------:|------------:|------------:|----------:|
| Decrypt · SM4-CBC (CryptoHives-Scalar) | 128B         |       815.1 ns |     3.94 ns |     3.29 ns |         - |
| Decrypt · SM4-CBC (BouncyCastle)       | 128B         |     1,305.6 ns |     5.66 ns |     5.29 ns |      40 B |
|                                        |              |                |             |             |           |
| Encrypt · SM4-CBC (CryptoHives-Scalar) | 128B         |       871.1 ns |     3.28 ns |     3.07 ns |         - |
| Encrypt · SM4-CBC (BouncyCastle)       | 128B         |     1,320.9 ns |     4.62 ns |     4.32 ns |      40 B |
|                                        |              |                |             |             |           |
| Decrypt · SM4-CBC (CryptoHives-Scalar) | 1KB          |     5,791.9 ns |    23.97 ns |    22.42 ns |         - |
| Decrypt · SM4-CBC (BouncyCastle)       | 1KB          |     8,179.2 ns |    30.90 ns |    25.81 ns |      40 B |
|                                        |              |                |             |             |           |
| Encrypt · SM4-CBC (CryptoHives-Scalar) | 1KB          |     6,220.5 ns |    25.81 ns |    20.15 ns |         - |
| Encrypt · SM4-CBC (BouncyCastle)       | 1KB          |     8,329.0 ns |    16.29 ns |    15.24 ns |      40 B |
|                                        |              |                |             |             |           |
| Decrypt · SM4-CBC (CryptoHives-Scalar) | 8KB          |    45,524.6 ns |    89.31 ns |    79.17 ns |         - |
| Decrypt · SM4-CBC (BouncyCastle)       | 8KB          |    63,344.1 ns |   205.06 ns |   191.81 ns |      40 B |
|                                        |              |                |             |             |           |
| Encrypt · SM4-CBC (CryptoHives-Scalar) | 8KB          |    48,990.9 ns |   147.36 ns |   130.63 ns |         - |
| Encrypt · SM4-CBC (BouncyCastle)       | 8KB          |    64,462.9 ns |   160.74 ns |   142.49 ns |      40 B |
|                                        |              |                |             |             |           |
| Decrypt · SM4-CBC (CryptoHives-Scalar) | 128KB        |   728,480.2 ns | 2,683.65 ns | 2,510.29 ns |         - |
| Decrypt · SM4-CBC (BouncyCastle)       | 128KB        | 1,007,024.6 ns | 2,106.75 ns | 1,759.23 ns |      40 B |
|                                        |              |                |             |             |           |
| Encrypt · SM4-CBC (CryptoHives-Scalar) | 128KB        |   781,660.9 ns | 2,003.31 ns | 1,775.88 ns |         - |
| Encrypt · SM4-CBC (BouncyCastle)       | 128KB        | 1,026,064.0 ns | 2,593.90 ns | 2,426.34 ns |      40 B |