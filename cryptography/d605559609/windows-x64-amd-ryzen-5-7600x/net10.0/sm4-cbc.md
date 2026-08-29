| Description                            | TestDataSize | Mean           | Error        | StdDev       | Allocated |
|--------------------------------------- |------------- |---------------:|-------------:|-------------:|----------:|
| Decrypt · SM4-CBC (CryptoHives-Scalar) | 128B         |       815.9 ns |      2.60 ns |      2.30 ns |         - |
| Decrypt · SM4-CBC (BouncyCastle)       | 128B         |     1,260.9 ns |      3.41 ns |      3.02 ns |      40 B |
|                                        |              |                |              |              |           |
| Encrypt · SM4-CBC (CryptoHives-Scalar) | 128B         |       870.8 ns |      2.36 ns |      2.09 ns |         - |
| Encrypt · SM4-CBC (BouncyCastle)       | 128B         |     1,272.1 ns |      2.42 ns |      2.15 ns |      40 B |
|                                        |              |                |              |              |           |
| Decrypt · SM4-CBC (CryptoHives-Scalar) | 1KB          |     5,811.8 ns |     79.08 ns |     66.03 ns |         - |
| Decrypt · SM4-CBC (BouncyCastle)       | 1KB          |     8,136.4 ns |     17.44 ns |     14.56 ns |      40 B |
|                                        |              |                |              |              |           |
| Encrypt · SM4-CBC (CryptoHives-Scalar) | 1KB          |     6,215.7 ns |     15.61 ns |     14.61 ns |         - |
| Encrypt · SM4-CBC (BouncyCastle)       | 1KB          |     8,289.2 ns |     16.00 ns |     13.36 ns |      40 B |
|                                        |              |                |              |              |           |
| Decrypt · SM4-CBC (CryptoHives-Scalar) | 8KB          |    45,512.0 ns |    154.11 ns |    136.62 ns |         - |
| Decrypt · SM4-CBC (BouncyCastle)       | 8KB          |    63,489.4 ns |    256.11 ns |    213.86 ns |      40 B |
|                                        |              |                |              |              |           |
| Encrypt · SM4-CBC (CryptoHives-Scalar) | 8KB          |    48,987.0 ns |    149.00 ns |    124.42 ns |         - |
| Encrypt · SM4-CBC (BouncyCastle)       | 8KB          |    64,519.9 ns |    223.78 ns |    198.38 ns |      40 B |
|                                        |              |                |              |              |           |
| Decrypt · SM4-CBC (CryptoHives-Scalar) | 128KB        |   727,791.5 ns |  2,418.89 ns |  1,888.51 ns |         - |
| Decrypt · SM4-CBC (BouncyCastle)       | 128KB        | 1,003,645.2 ns |  2,291.35 ns |  1,913.38 ns |      40 B |
|                                        |              |                |              |              |           |
| Encrypt · SM4-CBC (CryptoHives-Scalar) | 128KB        |   782,566.7 ns |  2,733.24 ns |  2,422.95 ns |         - |
| Encrypt · SM4-CBC (BouncyCastle)       | 128KB        | 1,034,253.2 ns | 18,456.73 ns | 15,412.21 ns |      40 B |