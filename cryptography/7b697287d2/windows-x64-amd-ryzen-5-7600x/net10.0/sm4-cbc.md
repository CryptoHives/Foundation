| Description                            | TestDataSize | Mean           | Error       | StdDev      | Code Size | Allocated |
|--------------------------------------- |------------- |---------------:|------------:|------------:|----------:|----------:|
| Decrypt · SM4-CBC (CryptoHives-Scalar) | 128B         |       959.3 ns |     1.48 ns |     1.39 ns |   1,289 B |         - |
| Decrypt · SM4-CBC (BouncyCastle)       | 128B         |     1,460.9 ns |     1.02 ns |     0.85 ns |   2,913 B |      40 B |
|                                        |              |                |             |             |           |           |
| Encrypt · SM4-CBC (CryptoHives-Scalar) | 128B         |     1,022.9 ns |     1.80 ns |     1.68 ns |   1,285 B |         - |
| Encrypt · SM4-CBC (BouncyCastle)       | 128B         |     1,478.2 ns |     1.36 ns |     1.21 ns |   2,911 B |      40 B |
|                                        |              |                |             |             |           |           |
| Decrypt · SM4-CBC (CryptoHives-Scalar) | 1KB          |     6,769.3 ns |     5.22 ns |     4.88 ns |   1,289 B |         - |
| Decrypt · SM4-CBC (BouncyCastle)       | 1KB          |     9,478.5 ns |     9.04 ns |     8.46 ns |   2,913 B |      40 B |
|                                        |              |                |             |             |           |           |
| Encrypt · SM4-CBC (CryptoHives-Scalar) | 1KB          |     7,267.8 ns |     4.83 ns |     4.52 ns |   1,285 B |         - |
| Encrypt · SM4-CBC (BouncyCastle)       | 1KB          |     9,637.7 ns |     6.44 ns |     5.38 ns |   2,911 B |      40 B |
|                                        |              |                |             |             |           |           |
| Decrypt · SM4-CBC (CryptoHives-Scalar) | 8KB          |    53,275.4 ns |    47.41 ns |    44.35 ns |   1,289 B |         - |
| Decrypt · SM4-CBC (BouncyCastle)       | 8KB          |    73,520.4 ns |    77.75 ns |    72.73 ns |   2,911 B |      40 B |
|                                        |              |                |             |             |           |           |
| Encrypt · SM4-CBC (CryptoHives-Scalar) | 8KB          |    57,235.2 ns |    39.38 ns |    32.89 ns |   1,283 B |         - |
| Encrypt · SM4-CBC (BouncyCastle)       | 8KB          |    75,000.4 ns |    77.77 ns |    68.94 ns |   2,911 B |      40 B |
|                                        |              |                |             |             |           |           |
| Decrypt · SM4-CBC (CryptoHives-Scalar) | 128KB        |   850,625.5 ns |   798.53 ns |   707.87 ns |   1,289 B |         - |
| Decrypt · SM4-CBC (BouncyCastle)       | 128KB        | 1,175,597.5 ns | 1,204.86 ns | 1,127.03 ns |   2,911 B |      40 B |
|                                        |              |                |             |             |           |           |
| Encrypt · SM4-CBC (CryptoHives-Scalar) | 128KB        |   913,898.6 ns |   767.69 ns |   718.10 ns |   1,283 B |         - |
| Encrypt · SM4-CBC (BouncyCastle)       | 128KB        | 1,195,036.2 ns |   758.50 ns |   709.50 ns |   2,911 B |      40 B |