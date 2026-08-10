| Description                            | TestDataSize | Mean           | Error       | StdDev      | Allocated |
|--------------------------------------- |------------- |---------------:|------------:|------------:|----------:|
| Decrypt · SM4-CBC (CryptoHives-Scalar) | 128B         |       950.7 ns |     2.06 ns |     1.93 ns |         - |
| Decrypt · SM4-CBC (BouncyCastle)       | 128B         |     1,459.2 ns |     7.46 ns |     6.98 ns |      40 B |
|                                        |              |                |             |             |           |
| Encrypt · SM4-CBC (CryptoHives-Scalar) | 128B         |     1,060.1 ns |     3.87 ns |     3.62 ns |         - |
| Encrypt · SM4-CBC (BouncyCastle)       | 128B         |     1,536.2 ns |     7.67 ns |     7.17 ns |      40 B |
|                                        |              |                |             |             |           |
| Decrypt · SM4-CBC (CryptoHives-Scalar) | 1KB          |     6,740.1 ns |    20.51 ns |    19.19 ns |         - |
| Decrypt · SM4-CBC (BouncyCastle)       | 1KB          |     9,104.7 ns |    29.62 ns |    27.71 ns |      40 B |
|                                        |              |                |             |             |           |
| Encrypt · SM4-CBC (CryptoHives-Scalar) | 1KB          |     7,650.4 ns |    40.74 ns |    36.12 ns |         - |
| Encrypt · SM4-CBC (BouncyCastle)       | 1KB          |     9,972.7 ns |    42.06 ns |    39.34 ns |      40 B |
|                                        |              |                |             |             |           |
| Decrypt · SM4-CBC (CryptoHives-Scalar) | 8KB          |    53,017.5 ns |   174.75 ns |   163.46 ns |         - |
| Decrypt · SM4-CBC (BouncyCastle)       | 8KB          |    69,893.0 ns |   228.47 ns |   213.71 ns |      40 B |
|                                        |              |                |             |             |           |
| Encrypt · SM4-CBC (CryptoHives-Scalar) | 8KB          |    60,449.8 ns |   233.91 ns |   218.80 ns |         - |
| Encrypt · SM4-CBC (BouncyCastle)       | 8KB          |    77,728.4 ns |   278.24 ns |   260.26 ns |      40 B |
|                                        |              |                |             |             |           |
| Decrypt · SM4-CBC (CryptoHives-Scalar) | 128KB        |   849,122.0 ns | 1,743.43 ns | 1,630.80 ns |         - |
| Decrypt · SM4-CBC (BouncyCastle)       | 128KB        | 1,112,592.1 ns | 6,878.10 ns | 6,097.26 ns |      40 B |
|                                        |              |                |             |             |           |
| Encrypt · SM4-CBC (CryptoHives-Scalar) | 128KB        |   967,133.1 ns | 1,762.64 ns | 1,562.54 ns |         - |
| Encrypt · SM4-CBC (BouncyCastle)       | 128KB        | 1,232,639.6 ns | 2,426.51 ns | 2,151.04 ns |      40 B |