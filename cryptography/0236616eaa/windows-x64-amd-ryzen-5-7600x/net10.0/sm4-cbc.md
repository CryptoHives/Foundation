| Description                            | TestDataSize | Mean           | Error       | StdDev      | Allocated |
|--------------------------------------- |------------- |---------------:|------------:|------------:|----------:|
| Decrypt · SM4-CBC (CryptoHives-Scalar) | 128B         |       815.6 ns |     0.96 ns |     0.75 ns |         - |
| Decrypt · SM4-CBC (BouncyCastle)       | 128B         |     1,263.4 ns |     2.80 ns |     2.62 ns |      40 B |
|                                        |              |                |             |             |           |
| Encrypt · SM4-CBC (CryptoHives-Scalar) | 128B         |       871.3 ns |     2.14 ns |     2.00 ns |         - |
| Encrypt · SM4-CBC (BouncyCastle)       | 128B         |     1,270.2 ns |     0.72 ns |     0.64 ns |      40 B |
|                                        |              |                |             |             |           |
| Decrypt · SM4-CBC (CryptoHives-Scalar) | 1KB          |     6,132.6 ns |    13.27 ns |    12.42 ns |         - |
| Decrypt · SM4-CBC (BouncyCastle)       | 1KB          |     8,150.2 ns |    26.65 ns |    22.26 ns |      40 B |
|                                        |              |                |             |             |           |
| Encrypt · SM4-CBC (CryptoHives-Scalar) | 1KB          |     6,207.5 ns |     6.14 ns |     5.13 ns |         - |
| Encrypt · SM4-CBC (BouncyCastle)       | 1KB          |     8,285.4 ns |    12.29 ns |    11.50 ns |      40 B |
|                                        |              |                |             |             |           |
| Decrypt · SM4-CBC (CryptoHives-Scalar) | 8KB          |    45,545.5 ns |    51.31 ns |    45.48 ns |         - |
| Decrypt · SM4-CBC (BouncyCastle)       | 8KB          |    63,144.7 ns |    91.18 ns |    85.29 ns |      40 B |
|                                        |              |                |             |             |           |
| Encrypt · SM4-CBC (CryptoHives-Scalar) | 8KB          |    48,961.9 ns |   251.70 ns |   210.18 ns |         - |
| Encrypt · SM4-CBC (BouncyCastle)       | 8KB          |    64,402.5 ns |   120.32 ns |   112.54 ns |      40 B |
|                                        |              |                |             |             |           |
| Decrypt · SM4-CBC (CryptoHives-Scalar) | 128KB        |   728,808.9 ns |   707.16 ns |   626.88 ns |         - |
| Decrypt · SM4-CBC (BouncyCastle)       | 128KB        | 1,012,401.9 ns | 1,618.67 ns | 1,351.66 ns |      40 B |
|                                        |              |                |             |             |           |
| Encrypt · SM4-CBC (CryptoHives-Scalar) | 128KB        |   781,433.0 ns |   732.45 ns |   571.85 ns |         - |
| Encrypt · SM4-CBC (BouncyCastle)       | 128KB        | 1,024,961.0 ns | 1,301.73 ns | 1,153.95 ns |      40 B |