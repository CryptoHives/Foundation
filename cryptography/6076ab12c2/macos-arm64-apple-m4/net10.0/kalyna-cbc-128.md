| Description                                   | TestDataSize | Mean           | Error       | StdDev      | Allocated |
|---------------------------------------------- |------------- |---------------:|------------:|------------:|----------:|
| Decrypt · Kalyna-128-CBC (CryptoHives-Scalar) | 128B         |       812.5 ns |     0.16 ns |     0.14 ns |         - |
| Decrypt · Kalyna-128-CBC (BouncyCastle)       | 128B         |     2,454.4 ns |     1.07 ns |     0.83 ns |     872 B |
|                                               |              |                |             |             |           |
| Encrypt · Kalyna-128-CBC (CryptoHives-Scalar) | 128B         |       412.2 ns |     0.78 ns |     0.69 ns |         - |
| Encrypt · Kalyna-128-CBC (BouncyCastle)       | 128B         |     1,300.2 ns |     4.14 ns |     3.88 ns |     872 B |
|                                               |              |                |             |             |           |
| Decrypt · Kalyna-128-CBC (CryptoHives-Scalar) | 1KB          |     5,752.5 ns |     1.37 ns |     1.28 ns |         - |
| Decrypt · Kalyna-128-CBC (BouncyCastle)       | 1KB          |    15,615.7 ns |     4.54 ns |     4.25 ns |     872 B |
|                                               |              |                |             |             |           |
| Encrypt · Kalyna-128-CBC (CryptoHives-Scalar) | 1KB          |     2,946.4 ns |     9.47 ns |     8.39 ns |         - |
| Encrypt · Kalyna-128-CBC (BouncyCastle)       | 1KB          |     7,326.1 ns |    22.37 ns |    20.93 ns |     872 B |
|                                               |              |                |             |             |           |
| Decrypt · Kalyna-128-CBC (CryptoHives-Scalar) | 8KB          |    45,279.9 ns |    10.76 ns |     8.98 ns |         - |
| Decrypt · Kalyna-128-CBC (BouncyCastle)       | 8KB          |   120,952.9 ns |    38.06 ns |    35.61 ns |     872 B |
|                                               |              |                |             |             |           |
| Encrypt · Kalyna-128-CBC (CryptoHives-Scalar) | 8KB          |    23,442.4 ns |    47.48 ns |    42.09 ns |         - |
| Encrypt · Kalyna-128-CBC (BouncyCastle)       | 8KB          |    55,501.3 ns |   124.72 ns |   110.56 ns |     872 B |
|                                               |              |                |             |             |           |
| Decrypt · Kalyna-128-CBC (CryptoHives-Scalar) | 128KB        |   725,013.5 ns | 1,103.73 ns |   978.43 ns |         - |
| Decrypt · Kalyna-128-CBC (BouncyCastle)       | 128KB        | 1,933,709.1 ns | 4,513.00 ns | 4,221.46 ns |     872 B |
|                                               |              |                |             |             |           |
| Encrypt · Kalyna-128-CBC (CryptoHives-Scalar) | 128KB        |   375,341.0 ns |   110.33 ns |    97.80 ns |         - |
| Encrypt · Kalyna-128-CBC (BouncyCastle)       | 128KB        |   879,626.8 ns |   140.13 ns |   124.22 ns |     872 B |