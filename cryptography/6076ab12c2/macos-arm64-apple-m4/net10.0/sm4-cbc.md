| Description                            | TestDataSize | Mean           | Error       | StdDev      | Allocated |
|--------------------------------------- |------------- |---------------:|------------:|------------:|----------:|
| Decrypt · SM4-CBC (CryptoHives-Scalar) | 128B         |       967.8 ns |     0.25 ns |     0.22 ns |         - |
| Decrypt · SM4-CBC (BouncyCastle)       | 128B         |     1,454.7 ns |     3.90 ns |     3.46 ns |      40 B |
|                                        |              |                |             |             |           |
| Encrypt · SM4-CBC (CryptoHives-Scalar) | 128B         |     1,098.0 ns |     2.17 ns |     1.92 ns |         - |
| Encrypt · SM4-CBC (BouncyCastle)       | 128B         |     1,550.2 ns |     4.94 ns |     3.86 ns |      40 B |
|                                        |              |                |             |             |           |
| Decrypt · SM4-CBC (CryptoHives-Scalar) | 1KB          |     6,858.3 ns |     1.74 ns |     1.54 ns |         - |
| Decrypt · SM4-CBC (BouncyCastle)       | 1KB          |     9,333.0 ns |     7.18 ns |     6.72 ns |      40 B |
|                                        |              |                |             |             |           |
| Encrypt · SM4-CBC (CryptoHives-Scalar) | 1KB          |     7,958.5 ns |    20.98 ns |    19.62 ns |         - |
| Encrypt · SM4-CBC (BouncyCastle)       | 1KB          |    10,352.6 ns |    32.09 ns |    28.45 ns |      40 B |
|                                        |              |                |             |             |           |
| Decrypt · SM4-CBC (CryptoHives-Scalar) | 8KB          |    53,117.3 ns |    24.89 ns |    22.07 ns |         - |
| Decrypt · SM4-CBC (BouncyCastle)       | 8KB          |    69,734.4 ns |   339.58 ns |   301.03 ns |      40 B |
|                                        |              |                |             |             |           |
| Encrypt · SM4-CBC (CryptoHives-Scalar) | 8KB          |    62,759.7 ns |   142.82 ns |   126.61 ns |         - |
| Encrypt · SM4-CBC (BouncyCastle)       | 8KB          |    84,614.5 ns | 1,686.23 ns | 2,523.87 ns |      40 B |
|                                        |              |                |             |             |           |
| Decrypt · SM4-CBC (CryptoHives-Scalar) | 128KB        |   839,885.3 ns | 2,260.79 ns | 2,114.75 ns |         - |
| Decrypt · SM4-CBC (BouncyCastle)       | 128KB        | 1,094,569.9 ns | 4,547.43 ns | 4,253.67 ns |      40 B |
|                                        |              |                |             |             |           |
| Encrypt · SM4-CBC (CryptoHives-Scalar) | 128KB        | 1,002,520.1 ns |   835.05 ns |   740.25 ns |         - |
| Encrypt · SM4-CBC (BouncyCastle)       | 128KB        | 1,289,018.5 ns |   395.62 ns |   370.07 ns |      40 B |