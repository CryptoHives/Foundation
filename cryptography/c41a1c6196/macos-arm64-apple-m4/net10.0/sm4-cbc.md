| Description                            | TestDataSize | Mean           | Error       | StdDev      | Allocated |
|--------------------------------------- |------------- |---------------:|------------:|------------:|----------:|
| Decrypt · SM4-CBC (CryptoHives-Scalar) | 128B         |       925.1 ns |     3.86 ns |     3.61 ns |         - |
| Decrypt · SM4-CBC (BouncyCastle)       | 128B         |     1,368.3 ns |     5.04 ns |     4.72 ns |      40 B |
|                                        |              |                |             |             |           |
| Encrypt · SM4-CBC (CryptoHives-Scalar) | 128B         |     1,027.1 ns |     5.57 ns |     5.21 ns |         - |
| Encrypt · SM4-CBC (BouncyCastle)       | 128B         |     1,442.1 ns |     2.69 ns |     2.38 ns |      40 B |
|                                        |              |                |             |             |           |
| Decrypt · SM4-CBC (CryptoHives-Scalar) | 1KB          |     6,546.3 ns |    22.28 ns |    19.75 ns |         - |
| Decrypt · SM4-CBC (BouncyCastle)       | 1KB          |     8,757.7 ns |    59.34 ns |    55.51 ns |      40 B |
|                                        |              |                |             |             |           |
| Encrypt · SM4-CBC (CryptoHives-Scalar) | 1KB          |     7,436.6 ns |    20.63 ns |    19.29 ns |         - |
| Encrypt · SM4-CBC (BouncyCastle)       | 1KB          |     9,587.4 ns |    34.72 ns |    32.48 ns |      40 B |
|                                        |              |                |             |             |           |
| Decrypt · SM4-CBC (CryptoHives-Scalar) | 8KB          |    51,505.8 ns |   164.51 ns |   145.83 ns |         - |
| Decrypt · SM4-CBC (BouncyCastle)       | 8KB          |    67,703.5 ns |   558.33 ns |   522.26 ns |      40 B |
|                                        |              |                |             |             |           |
| Encrypt · SM4-CBC (CryptoHives-Scalar) | 8KB          |    58,762.7 ns |   185.57 ns |   173.58 ns |         - |
| Encrypt · SM4-CBC (BouncyCastle)       | 8KB          |    74,842.6 ns |   444.48 ns |   415.77 ns |      40 B |
|                                        |              |                |             |             |           |
| Decrypt · SM4-CBC (CryptoHives-Scalar) | 128KB        |   824,578.3 ns | 3,057.36 ns | 2,859.85 ns |         - |
| Decrypt · SM4-CBC (BouncyCastle)       | 128KB        | 1,080,931.7 ns | 7,771.43 ns | 7,269.40 ns |      40 B |
|                                        |              |                |             |             |           |
| Encrypt · SM4-CBC (CryptoHives-Scalar) | 128KB        |   940,463.2 ns | 2,752.79 ns | 2,574.96 ns |         - |
| Encrypt · SM4-CBC (BouncyCastle)       | 128KB        | 1,195,683.4 ns | 7,061.86 ns | 6,605.66 ns |      40 B |