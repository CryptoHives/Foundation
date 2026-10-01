| Description                            | TestDataSize | Mean           | Error       | StdDev      | Allocated |
|--------------------------------------- |------------- |---------------:|------------:|------------:|----------:|
| Decrypt · SM4-CBC (CryptoHives-Scalar) | 128B         |       954.1 ns |     6.62 ns |     6.20 ns |         - |
| Decrypt · SM4-CBC (BouncyCastle)       | 128B         |     1,475.3 ns |     5.55 ns |     5.19 ns |      40 B |
|                                        |              |                |             |             |           |
| Encrypt · SM4-CBC (CryptoHives-Scalar) | 128B         |     1,049.0 ns |     5.56 ns |     5.20 ns |         - |
| Encrypt · SM4-CBC (BouncyCastle)       | 128B         |     1,488.5 ns |     6.08 ns |     5.69 ns |      40 B |
|                                        |              |                |             |             |           |
| Decrypt · SM4-CBC (CryptoHives-Scalar) | 1KB          |     6,775.6 ns |    19.67 ns |    18.40 ns |         - |
| Decrypt · SM4-CBC (BouncyCastle)       | 1KB          |     9,574.4 ns |    43.55 ns |    40.74 ns |      40 B |
|                                        |              |                |             |             |           |
| Encrypt · SM4-CBC (CryptoHives-Scalar) | 1KB          |     7,273.3 ns |    32.30 ns |    30.22 ns |         - |
| Encrypt · SM4-CBC (BouncyCastle)       | 1KB          |     9,703.2 ns |    36.33 ns |    33.98 ns |      40 B |
|                                        |              |                |             |             |           |
| Decrypt · SM4-CBC (CryptoHives-Scalar) | 8KB          |    53,686.4 ns |   308.90 ns |   288.94 ns |         - |
| Decrypt · SM4-CBC (BouncyCastle)       | 8KB          |    74,085.3 ns |   424.22 ns |   396.82 ns |      40 B |
|                                        |              |                |             |             |           |
| Encrypt · SM4-CBC (CryptoHives-Scalar) | 8KB          |    57,349.4 ns |   126.09 ns |   105.29 ns |         - |
| Encrypt · SM4-CBC (BouncyCastle)       | 8KB          |    75,395.0 ns |   337.64 ns |   299.31 ns |      40 B |
|                                        |              |                |             |             |           |
| Decrypt · SM4-CBC (CryptoHives-Scalar) | 128KB        |   852,572.8 ns | 5,140.98 ns | 4,808.87 ns |         - |
| Decrypt · SM4-CBC (BouncyCastle)       | 128KB        | 1,179,242.2 ns | 6,143.71 ns | 5,746.83 ns |      40 B |
|                                        |              |                |             |             |           |
| Encrypt · SM4-CBC (CryptoHives-Scalar) | 128KB        |   915,572.1 ns | 4,897.05 ns | 4,580.70 ns |         - |
| Encrypt · SM4-CBC (BouncyCastle)       | 128KB        | 1,201,147.9 ns | 4,943.98 ns | 4,624.60 ns |      40 B |