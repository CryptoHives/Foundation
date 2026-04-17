| Description                            | TestDataSize | Mean           | Error       | StdDev      | Allocated |
|--------------------------------------- |------------- |---------------:|------------:|------------:|----------:|
| Decrypt · SM4-CBC (CryptoHives-Neon)   | 128B         |       935.5 ns |     2.62 ns |     2.45 ns |         - |
| Decrypt · SM4-CBC (CryptoHives-Scalar) | 128B         |     1,347.8 ns |     6.18 ns |     4.83 ns |         - |
| Decrypt · SM4-CBC (BouncyCastle)       | 128B         |     1,423.3 ns |     4.80 ns |     4.49 ns |      40 B |
|                                        |              |                |             |             |           |
| Encrypt · SM4-CBC (CryptoHives-Neon)   | 128B         |     1,038.2 ns |     6.76 ns |     5.99 ns |         - |
| Encrypt · SM4-CBC (CryptoHives-Scalar) | 128B         |     1,448.8 ns |     4.90 ns |     4.34 ns |         - |
| Encrypt · SM4-CBC (BouncyCastle)       | 128B         |     1,486.8 ns |     3.67 ns |     3.44 ns |      40 B |
|                                        |              |                |             |             |           |
| Decrypt · SM4-CBC (CryptoHives-Neon)   | 1KB          |     6,603.1 ns |    52.84 ns |    44.12 ns |         - |
| Decrypt · SM4-CBC (BouncyCastle)       | 1KB          |     8,873.3 ns |    33.52 ns |    31.35 ns |      40 B |
| Decrypt · SM4-CBC (CryptoHives-Scalar) | 1KB          |     9,585.1 ns |    53.18 ns |    47.15 ns |         - |
|                                        |              |                |             |             |           |
| Encrypt · SM4-CBC (CryptoHives-Neon)   | 1KB          |     7,519.9 ns |    13.52 ns |    11.98 ns |         - |
| Encrypt · SM4-CBC (BouncyCastle)       | 1KB          |     9,647.1 ns |    30.89 ns |    28.90 ns |      40 B |
| Encrypt · SM4-CBC (CryptoHives-Scalar) | 1KB          |    10,480.6 ns |    63.18 ns |    59.09 ns |         - |
|                                        |              |                |             |             |           |
| Decrypt · SM4-CBC (CryptoHives-Neon)   | 8KB          |    51,742.8 ns |   232.60 ns |   206.20 ns |         - |
| Decrypt · SM4-CBC (BouncyCastle)       | 8KB          |    68,314.0 ns |   287.68 ns |   240.22 ns |      40 B |
| Decrypt · SM4-CBC (CryptoHives-Scalar) | 8KB          |    75,475.5 ns |   578.23 ns |   451.45 ns |         - |
|                                        |              |                |             |             |           |
| Encrypt · SM4-CBC (CryptoHives-Neon)   | 8KB          |    59,578.5 ns |   338.83 ns |   300.36 ns |         - |
| Encrypt · SM4-CBC (BouncyCastle)       | 8KB          |    75,798.8 ns |   539.75 ns |   450.72 ns |      40 B |
| Encrypt · SM4-CBC (CryptoHives-Scalar) | 8KB          |    83,943.9 ns |   510.49 ns |   452.54 ns |         - |
|                                        |              |                |             |             |           |
| Decrypt · SM4-CBC (CryptoHives-Neon)   | 128KB        |   836,098.1 ns | 1,905.57 ns | 1,591.24 ns |         - |
| Decrypt · SM4-CBC (BouncyCastle)       | 128KB        | 1,092,954.4 ns | 4,979.25 ns | 4,157.90 ns |      40 B |
| Decrypt · SM4-CBC (CryptoHives-Scalar) | 128KB        | 1,210,703.9 ns | 5,971.61 ns | 5,293.67 ns |         - |
|                                        |              |                |             |             |           |
| Encrypt · SM4-CBC (CryptoHives-Neon)   | 128KB        |   958,420.6 ns | 4,762.40 ns | 3,976.82 ns |         - |
| Encrypt · SM4-CBC (BouncyCastle)       | 128KB        | 1,205,439.7 ns | 4,128.44 ns | 3,659.75 ns |      40 B |
| Encrypt · SM4-CBC (CryptoHives-Scalar) | 128KB        | 1,339,193.7 ns | 5,114.35 ns | 4,533.74 ns |         - |