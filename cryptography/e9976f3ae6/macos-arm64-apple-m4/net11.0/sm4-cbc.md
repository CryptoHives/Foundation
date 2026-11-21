| Description                            | TestDataSize | Mean           | Error       | StdDev      | Allocated |
|--------------------------------------- |------------- |---------------:|------------:|------------:|----------:|
| Decrypt · SM4-CBC (CryptoHives-Scalar) | 128B         |       938.4 ns |     3.45 ns |     3.23 ns |         - |
| Decrypt · SM4-CBC (BouncyCastle)       | 128B         |     1,344.0 ns |     6.45 ns |     5.39 ns |      40 B |
|                                        |              |                |             |             |           |
| Encrypt · SM4-CBC (CryptoHives-Scalar) | 128B         |     1,043.8 ns |     9.75 ns |     9.12 ns |         - |
| Encrypt · SM4-CBC (BouncyCastle)       | 128B         |     1,449.4 ns |     2.95 ns |     2.76 ns |      40 B |
|                                        |              |                |             |             |           |
| Decrypt · SM4-CBC (CryptoHives-Scalar) | 1KB          |     6,625.4 ns |    23.27 ns |    21.77 ns |         - |
| Decrypt · SM4-CBC (BouncyCastle)       | 1KB          |     8,545.5 ns |    55.29 ns |    51.71 ns |      40 B |
|                                        |              |                |             |             |           |
| Encrypt · SM4-CBC (CryptoHives-Scalar) | 1KB          |     7,540.6 ns |    35.78 ns |    33.47 ns |         - |
| Encrypt · SM4-CBC (BouncyCastle)       | 1KB          |     9,648.6 ns |    56.29 ns |    52.66 ns |      40 B |
|                                        |              |                |             |             |           |
| Decrypt · SM4-CBC (CryptoHives-Scalar) | 8KB          |    51,827.8 ns |   197.51 ns |   184.75 ns |         - |
| Decrypt · SM4-CBC (BouncyCastle)       | 8KB          |    65,965.5 ns |   360.22 ns |   336.95 ns |      40 B |
|                                        |              |                |             |             |           |
| Encrypt · SM4-CBC (CryptoHives-Scalar) | 8KB          |    59,566.0 ns |   228.03 ns |   213.30 ns |         - |
| Encrypt · SM4-CBC (BouncyCastle)       | 8KB          |    75,291.5 ns |   442.56 ns |   413.97 ns |      40 B |
|                                        |              |                |             |             |           |
| Decrypt · SM4-CBC (CryptoHives-Scalar) | 128KB        |   828,154.8 ns | 1,632.73 ns | 1,274.73 ns |         - |
| Decrypt · SM4-CBC (BouncyCastle)       | 128KB        | 1,051,688.6 ns | 4,737.95 ns | 4,431.89 ns |      40 B |
|                                        |              |                |             |             |           |
| Encrypt · SM4-CBC (CryptoHives-Scalar) | 128KB        |   950,969.4 ns | 4,392.79 ns | 4,109.02 ns |         - |
| Encrypt · SM4-CBC (BouncyCastle)       | 128KB        | 1,200,100.7 ns | 6,456.26 ns | 6,039.19 ns |      40 B |