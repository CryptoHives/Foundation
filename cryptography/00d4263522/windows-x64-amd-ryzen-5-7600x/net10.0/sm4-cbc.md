| Description                            | TestDataSize | Mean           | Error       | StdDev      | Allocated |
|--------------------------------------- |------------- |---------------:|------------:|------------:|----------:|
| Decrypt · SM4-CBC (CryptoHives-Scalar) | 128B         |       831.6 ns |     1.07 ns |     0.89 ns |         - |
| Decrypt · SM4-CBC (BouncyCastle)       | 128B         |     1,274.2 ns |     1.95 ns |     1.63 ns |      40 B |
|                                        |              |                |             |             |           |
| Encrypt · SM4-CBC (CryptoHives-Scalar) | 128B         |       882.4 ns |     1.24 ns |     1.10 ns |         - |
| Encrypt · SM4-CBC (BouncyCastle)       | 128B         |     1,286.4 ns |     3.58 ns |     2.80 ns |      40 B |
|                                        |              |                |             |             |           |
| Decrypt · SM4-CBC (CryptoHives-Scalar) | 1KB          |     5,873.1 ns |    13.74 ns |    12.18 ns |         - |
| Decrypt · SM4-CBC (BouncyCastle)       | 1KB          |     8,228.1 ns |     9.91 ns |     8.78 ns |      40 B |
|                                        |              |                |             |             |           |
| Encrypt · SM4-CBC (CryptoHives-Scalar) | 1KB          |     6,303.0 ns |    15.86 ns |    14.83 ns |         - |
| Encrypt · SM4-CBC (BouncyCastle)       | 1KB          |     8,361.5 ns |     8.07 ns |     6.30 ns |      40 B |
|                                        |              |                |             |             |           |
| Decrypt · SM4-CBC (CryptoHives-Scalar) | 8KB          |    46,295.8 ns |    92.20 ns |    86.24 ns |         - |
| Decrypt · SM4-CBC (BouncyCastle)       | 8KB          |    63,763.3 ns |   124.72 ns |   104.15 ns |      40 B |
|                                        |              |                |             |             |           |
| Encrypt · SM4-CBC (CryptoHives-Scalar) | 8KB          |    49,600.4 ns |    71.04 ns |    66.45 ns |         - |
| Encrypt · SM4-CBC (BouncyCastle)       | 8KB          |    64,902.3 ns |    73.89 ns |    61.70 ns |      40 B |
|                                        |              |                |             |             |           |
| Decrypt · SM4-CBC (CryptoHives-Scalar) | 128KB        |   738,371.1 ns |   938.54 ns |   831.99 ns |         - |
| Decrypt · SM4-CBC (BouncyCastle)       | 128KB        | 1,021,606.2 ns | 2,468.92 ns | 2,309.43 ns |      40 B |
|                                        |              |                |             |             |           |
| Encrypt · SM4-CBC (CryptoHives-Scalar) | 128KB        |   793,705.7 ns | 1,717.26 ns | 1,522.31 ns |         - |
| Encrypt · SM4-CBC (BouncyCastle)       | 128KB        | 1,035,442.3 ns | 2,259.74 ns | 2,113.77 ns |      40 B |