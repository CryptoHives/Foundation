| Description                            | TestDataSize | Mean           | Error        | StdDev       | Allocated |
|--------------------------------------- |------------- |---------------:|-------------:|-------------:|----------:|
| Decrypt · SM4-CBC (CryptoHives-Scalar) | 128B         |       953.6 ns |      1.00 ns |      0.78 ns |         - |
| Decrypt · SM4-CBC (BouncyCastle)       | 128B         |     1,435.9 ns |     20.91 ns |     19.56 ns |      40 B |
|                                        |              |                |              |              |           |
| Encrypt · SM4-CBC (CryptoHives-Scalar) | 128B         |     1,063.7 ns |      2.56 ns |      2.00 ns |         - |
| Encrypt · SM4-CBC (BouncyCastle)       | 128B         |     1,516.8 ns |     14.92 ns |     13.96 ns |      40 B |
|                                        |              |                |              |              |           |
| Decrypt · SM4-CBC (CryptoHives-Scalar) | 1KB          |     6,798.8 ns |     63.02 ns |     58.95 ns |         - |
| Decrypt · SM4-CBC (BouncyCastle)       | 1KB          |     9,110.4 ns |     51.85 ns |     40.48 ns |      40 B |
|                                        |              |                |              |              |           |
| Encrypt · SM4-CBC (CryptoHives-Scalar) | 1KB          |     7,691.5 ns |     33.43 ns |     26.10 ns |         - |
| Encrypt · SM4-CBC (BouncyCastle)       | 1KB          |    10,091.9 ns |    183.20 ns |    171.37 ns |      40 B |
|                                        |              |                |              |              |           |
| Decrypt · SM4-CBC (CryptoHives-Scalar) | 8KB          |    53,484.2 ns |    465.06 ns |    435.01 ns |         - |
| Decrypt · SM4-CBC (BouncyCastle)       | 8KB          |    70,183.2 ns |    265.18 ns |    207.03 ns |      40 B |
|                                        |              |                |              |              |           |
| Encrypt · SM4-CBC (CryptoHives-Scalar) | 8KB          |    60,773.4 ns |    328.47 ns |    256.45 ns |         - |
| Encrypt · SM4-CBC (BouncyCastle)       | 8KB          |    78,490.9 ns |  1,112.40 ns |  1,040.54 ns |      40 B |
|                                        |              |                |              |              |           |
| Decrypt · SM4-CBC (CryptoHives-Scalar) | 128KB        |   856,137.3 ns |  7,752.04 ns |  6,871.98 ns |         - |
| Decrypt · SM4-CBC (BouncyCastle)       | 128KB        | 1,119,304.8 ns |  4,090.72 ns |  3,193.76 ns |      40 B |
|                                        |              |                |              |              |           |
| Encrypt · SM4-CBC (CryptoHives-Scalar) | 128KB        |   976,677.1 ns |  5,335.06 ns |  4,990.42 ns |         - |
| Encrypt · SM4-CBC (BouncyCastle)       | 128KB        | 1,251,324.2 ns | 18,235.51 ns | 17,057.51 ns |      40 B |