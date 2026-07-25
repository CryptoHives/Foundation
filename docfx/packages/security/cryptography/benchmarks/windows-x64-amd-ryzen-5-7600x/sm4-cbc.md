| Description                            | TestDataSize | Mean           | Error       | StdDev      | Allocated |
|--------------------------------------- |------------- |---------------:|------------:|------------:|----------:|
| Decrypt · SM4-CBC (CryptoHives-Scalar) | 128B         |       817.3 ns |     1.31 ns |     1.16 ns |         - |
| Decrypt · SM4-CBC (BouncyCastle)       | 128B         |     1,303.7 ns |     5.11 ns |     4.27 ns |      40 B |
|                                        |              |                |             |             |           |
| Encrypt · SM4-CBC (CryptoHives-Scalar) | 128B         |       871.9 ns |     0.80 ns |     0.71 ns |         - |
| Encrypt · SM4-CBC (BouncyCastle)       | 128B         |     1,314.6 ns |     1.82 ns |     1.70 ns |      40 B |
|                                        |              |                |             |             |           |
| Decrypt · SM4-CBC (CryptoHives-Scalar) | 1KB          |     5,805.4 ns |     8.52 ns |     7.12 ns |         - |
| Decrypt · SM4-CBC (BouncyCastle)       | 1KB          |     8,205.3 ns |    17.46 ns |    15.47 ns |      40 B |
|                                        |              |                |             |             |           |
| Encrypt · SM4-CBC (CryptoHives-Scalar) | 1KB          |     6,233.3 ns |    11.37 ns |    10.08 ns |         - |
| Encrypt · SM4-CBC (BouncyCastle)       | 1KB          |     8,342.4 ns |     8.84 ns |     7.38 ns |      40 B |
|                                        |              |                |             |             |           |
| Decrypt · SM4-CBC (CryptoHives-Scalar) | 8KB          |    45,685.6 ns |    73.29 ns |    64.97 ns |         - |
| Decrypt · SM4-CBC (BouncyCastle)       | 8KB          |    63,440.4 ns |   121.66 ns |   107.84 ns |      40 B |
|                                        |              |                |             |             |           |
| Encrypt · SM4-CBC (CryptoHives-Scalar) | 8KB          |    49,100.0 ns |    90.69 ns |    84.83 ns |         - |
| Encrypt · SM4-CBC (BouncyCastle)       | 8KB          |    64,509.4 ns |   109.14 ns |    96.75 ns |      40 B |
|                                        |              |                |             |             |           |
| Decrypt · SM4-CBC (CryptoHives-Scalar) | 128KB        |   727,746.9 ns |   970.63 ns |   860.44 ns |         - |
| Decrypt · SM4-CBC (BouncyCastle)       | 128KB        | 1,005,229.8 ns | 1,246.91 ns | 1,041.23 ns |      40 B |
|                                        |              |                |             |             |           |
| Encrypt · SM4-CBC (CryptoHives-Scalar) | 128KB        |   784,189.1 ns | 1,390.73 ns | 1,300.89 ns |         - |
| Encrypt · SM4-CBC (BouncyCastle)       | 128KB        | 1,026,462.0 ns | 2,253.74 ns | 2,108.15 ns |      40 B |