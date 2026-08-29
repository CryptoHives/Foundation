| Description                            | TestDataSize | Mean           | Error       | StdDev      | Allocated |
|--------------------------------------- |------------- |---------------:|------------:|------------:|----------:|
| Decrypt · SM4-CBC (CryptoHives-Scalar) | 128B         |       951.7 ns |     1.56 ns |     1.38 ns |         - |
| Decrypt · SM4-CBC (BouncyCastle)       | 128B         |     1,430.7 ns |     6.25 ns |     5.54 ns |      40 B |
|                                        |              |                |             |             |           |
| Encrypt · SM4-CBC (CryptoHives-Scalar) | 128B         |     1,094.8 ns |    18.13 ns |    16.96 ns |         - |
| Encrypt · SM4-CBC (BouncyCastle)       | 128B         |     1,525.8 ns |     7.57 ns |     7.08 ns |      40 B |
|                                        |              |                |             |             |           |
| Decrypt · SM4-CBC (CryptoHives-Scalar) | 1KB          |     6,769.5 ns |    20.62 ns |    19.28 ns |         - |
| Decrypt · SM4-CBC (BouncyCastle)       | 1KB          |     9,315.8 ns |   165.95 ns |   177.56 ns |      40 B |
|                                        |              |                |             |             |           |
| Encrypt · SM4-CBC (CryptoHives-Scalar) | 1KB          |     7,811.3 ns |     7.70 ns |     6.83 ns |         - |
| Encrypt · SM4-CBC (BouncyCastle)       | 1KB          |    10,140.2 ns |    21.98 ns |    19.48 ns |      40 B |
|                                        |              |                |             |             |           |
| Decrypt · SM4-CBC (CryptoHives-Scalar) | 8KB          |    53,229.7 ns |   102.19 ns |    85.33 ns |         - |
| Decrypt · SM4-CBC (BouncyCastle)       | 8KB          |    70,702.7 ns |   120.26 ns |    93.89 ns |      40 B |
|                                        |              |                |             |             |           |
| Encrypt · SM4-CBC (CryptoHives-Scalar) | 8KB          |    61,597.0 ns |   159.80 ns |   133.44 ns |         - |
| Encrypt · SM4-CBC (BouncyCastle)       | 8KB          |    79,128.0 ns |   203.07 ns |   169.57 ns |      40 B |
|                                        |              |                |             |             |           |
| Decrypt · SM4-CBC (CryptoHives-Scalar) | 128KB        |   852,630.5 ns | 2,994.38 ns | 2,500.45 ns |         - |
| Decrypt · SM4-CBC (BouncyCastle)       | 128KB        | 1,130,423.8 ns | 6,149.22 ns | 5,134.88 ns |      40 B |
|                                        |              |                |             |             |           |
| Encrypt · SM4-CBC (CryptoHives-Scalar) | 128KB        |   985,058.0 ns | 2,084.96 ns | 1,950.27 ns |         - |
| Encrypt · SM4-CBC (BouncyCastle)       | 128KB        | 1,262,078.8 ns | 2,507.58 ns | 2,345.59 ns |      40 B |