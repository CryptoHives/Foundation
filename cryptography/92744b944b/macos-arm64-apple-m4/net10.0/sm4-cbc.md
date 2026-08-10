| Description                            | TestDataSize | Mean           | Error        | StdDev       | Allocated |
|--------------------------------------- |------------- |---------------:|-------------:|-------------:|----------:|
| Decrypt · SM4-CBC (CryptoHives-Scalar) | 128B         |       921.5 ns |     12.28 ns |     10.89 ns |         - |
| Decrypt · SM4-CBC (BouncyCastle)       | 128B         |     1,411.9 ns |      8.01 ns |      6.25 ns |      40 B |
|                                        |              |                |              |              |           |
| Encrypt · SM4-CBC (CryptoHives-Scalar) | 128B         |     1,036.8 ns |      4.76 ns |      4.45 ns |         - |
| Encrypt · SM4-CBC (BouncyCastle)       | 128B         |     1,472.8 ns |      5.07 ns |      4.49 ns |      40 B |
|                                        |              |                |              |              |           |
| Decrypt · SM4-CBC (CryptoHives-Scalar) | 1KB          |     6,479.2 ns |     26.79 ns |     22.37 ns |         - |
| Decrypt · SM4-CBC (BouncyCastle)       | 1KB          |     8,835.6 ns |    115.11 ns |    107.67 ns |      40 B |
|                                        |              |                |              |              |           |
| Encrypt · SM4-CBC (CryptoHives-Scalar) | 1KB          |     7,430.8 ns |     16.52 ns |     15.45 ns |         - |
| Encrypt · SM4-CBC (BouncyCastle)       | 1KB          |     9,525.7 ns |     71.14 ns |     63.07 ns |      40 B |
|                                        |              |                |              |              |           |
| Decrypt · SM4-CBC (CryptoHives-Scalar) | 8KB          |    51,202.7 ns |    428.44 ns |    400.76 ns |         - |
| Decrypt · SM4-CBC (BouncyCastle)       | 8KB          |    67,298.9 ns |    334.28 ns |    279.13 ns |      40 B |
|                                        |              |                |              |              |           |
| Encrypt · SM4-CBC (CryptoHives-Scalar) | 8KB          |    58,660.9 ns |    176.29 ns |    147.21 ns |         - |
| Encrypt · SM4-CBC (BouncyCastle)       | 8KB          |    73,962.4 ns |    398.15 ns |    352.95 ns |      40 B |
|                                        |              |                |              |              |           |
| Decrypt · SM4-CBC (CryptoHives-Scalar) | 128KB        |   826,478.1 ns | 13,701.75 ns | 15,778.96 ns |         - |
| Decrypt · SM4-CBC (BouncyCastle)       | 128KB        | 1,076,688.9 ns |  4,939.38 ns |  4,378.63 ns |      40 B |
|                                        |              |                |              |              |           |
| Encrypt · SM4-CBC (CryptoHives-Scalar) | 128KB        |   937,807.3 ns |  1,932.93 ns |  1,713.49 ns |         - |
| Encrypt · SM4-CBC (BouncyCastle)       | 128KB        | 1,176,637.9 ns |  6,588.28 ns |  6,162.68 ns |      40 B |