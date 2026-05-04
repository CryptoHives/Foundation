| Description                            | TestDataSize | Mean           | Error       | StdDev      | Allocated |
|--------------------------------------- |------------- |---------------:|------------:|------------:|----------:|
| Decrypt · SM4-CBC (CryptoHives-Scalar) | 128B         |       792.2 ns |     2.61 ns |     2.45 ns |         - |
| Decrypt · SM4-CBC (BouncyCastle)       | 128B         |     1,292.3 ns |     3.98 ns |     3.53 ns |      40 B |
|                                        |              |                |             |             |           |
| Encrypt · SM4-CBC (CryptoHives-Scalar) | 128B         |       862.4 ns |     1.36 ns |     1.20 ns |         - |
| Encrypt · SM4-CBC (BouncyCastle)       | 128B         |     1,309.3 ns |     3.76 ns |     3.52 ns |      40 B |
|                                        |              |                |             |             |           |
| Decrypt · SM4-CBC (CryptoHives-Scalar) | 1KB          |     5,604.7 ns |    11.61 ns |    10.86 ns |         - |
| Decrypt · SM4-CBC (BouncyCastle)       | 1KB          |     8,139.6 ns |    12.51 ns |    11.09 ns |      40 B |
|                                        |              |                |             |             |           |
| Encrypt · SM4-CBC (CryptoHives-Scalar) | 1KB          |     6,187.6 ns |    10.73 ns |     9.51 ns |         - |
| Encrypt · SM4-CBC (BouncyCastle)       | 1KB          |     8,289.3 ns |    12.37 ns |    10.33 ns |      40 B |
|                                        |              |                |             |             |           |
| Decrypt · SM4-CBC (CryptoHives-Scalar) | 8KB          |    44,187.6 ns |   142.25 ns |   126.10 ns |         - |
| Decrypt · SM4-CBC (BouncyCastle)       | 8KB          |    63,006.5 ns |   175.02 ns |   163.72 ns |      40 B |
|                                        |              |                |             |             |           |
| Encrypt · SM4-CBC (CryptoHives-Scalar) | 8KB          |    49,049.6 ns |   104.41 ns |    97.66 ns |         - |
| Encrypt · SM4-CBC (BouncyCastle)       | 8KB          |    64,173.3 ns |   190.27 ns |   177.98 ns |      40 B |
|                                        |              |                |             |             |           |
| Decrypt · SM4-CBC (CryptoHives-Scalar) | 128KB        |   705,026.4 ns | 2,455.70 ns | 2,297.06 ns |         - |
| Decrypt · SM4-CBC (BouncyCastle)       | 128KB        | 1,000,424.7 ns | 2,507.68 ns | 2,094.03 ns |      40 B |
|                                        |              |                |             |             |           |
| Encrypt · SM4-CBC (CryptoHives-Scalar) | 128KB        |   777,629.4 ns | 1,589.16 ns | 1,486.50 ns |         - |
| Encrypt · SM4-CBC (BouncyCastle)       | 128KB        | 1,024,598.9 ns | 2,702.42 ns | 2,527.85 ns |      40 B |