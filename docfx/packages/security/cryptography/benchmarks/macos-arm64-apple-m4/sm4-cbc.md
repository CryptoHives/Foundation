| Description                            | TestDataSize | Mean           | Error        | StdDev       | Allocated |
|--------------------------------------- |------------- |---------------:|-------------:|-------------:|----------:|
| Decrypt · SM4-CBC (CryptoHives-Scalar) | 128B         |       940.0 ns |      2.70 ns |      2.52 ns |         - |
| Decrypt · SM4-CBC (BouncyCastle)       | 128B         |     1,442.6 ns |      4.82 ns |      4.51 ns |      40 B |
|                                        |              |                |              |              |           |
| Encrypt · SM4-CBC (CryptoHives-Scalar) | 128B         |     1,048.0 ns |      4.11 ns |      3.85 ns |         - |
| Encrypt · SM4-CBC (BouncyCastle)       | 128B         |     1,523.2 ns |      6.63 ns |      6.20 ns |      40 B |
|                                        |              |                |              |              |           |
| Decrypt · SM4-CBC (CryptoHives-Scalar) | 1KB          |     6,658.6 ns |     16.00 ns |     14.97 ns |         - |
| Decrypt · SM4-CBC (BouncyCastle)       | 1KB          |     9,012.6 ns |     36.88 ns |     32.69 ns |      40 B |
|                                        |              |                |              |              |           |
| Encrypt · SM4-CBC (CryptoHives-Scalar) | 1KB          |     7,576.7 ns |     15.81 ns |     14.02 ns |         - |
| Encrypt · SM4-CBC (BouncyCastle)       | 1KB          |     9,841.0 ns |     48.90 ns |     45.74 ns |      40 B |
|                                        |              |                |              |              |           |
| Decrypt · SM4-CBC (CryptoHives-Scalar) | 8KB          |    52,524.8 ns |    125.83 ns |    117.70 ns |         - |
| Decrypt · SM4-CBC (BouncyCastle)       | 8KB          |    69,288.6 ns |    248.85 ns |    232.78 ns |      40 B |
|                                        |              |                |              |              |           |
| Encrypt · SM4-CBC (CryptoHives-Scalar) | 8KB          |    59,850.8 ns |    145.59 ns |    136.18 ns |         - |
| Encrypt · SM4-CBC (BouncyCastle)       | 8KB          |    76,415.4 ns |    321.87 ns |    301.07 ns |      40 B |
|                                        |              |                |              |              |           |
| Decrypt · SM4-CBC (CryptoHives-Scalar) | 128KB        |   838,849.9 ns |  2,472.28 ns |  2,312.57 ns |         - |
| Decrypt · SM4-CBC (BouncyCastle)       | 128KB        | 1,110,861.3 ns | 14,963.84 ns | 13,265.06 ns |      40 B |
|                                        |              |                |              |              |           |
| Encrypt · SM4-CBC (CryptoHives-Scalar) | 128KB        |   956,054.3 ns |  2,355.72 ns |  2,203.54 ns |         - |
| Encrypt · SM4-CBC (BouncyCastle)       | 128KB        | 1,218,526.6 ns |  4,521.53 ns |  4,229.44 ns |      40 B |