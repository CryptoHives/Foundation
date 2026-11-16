| Description                                   | TestDataSize | Mean           | Error        | StdDev       | Code Size | Allocated |
|---------------------------------------------- |------------- |---------------:|-------------:|-------------:|----------:|----------:|
| Decrypt · Kalyna-128-CBC (CryptoHives-Scalar) | 128B         |     1,080.5 ns |     10.22 ns |      9.56 ns |   1,409 B |         - |
| Decrypt · Kalyna-128-CBC (BouncyCastle)       | 128B         |     2,758.1 ns |     33.22 ns |     31.07 ns |   2,911 B |     872 B |
|                                               |              |                |              |              |           |           |
| Encrypt · Kalyna-128-CBC (CryptoHives-Scalar) | 128B         |       484.7 ns |      6.60 ns |      6.17 ns |   1,411 B |         - |
| Encrypt · Kalyna-128-CBC (BouncyCastle)       | 128B         |     1,561.5 ns |     17.24 ns |     16.13 ns |   2,911 B |     872 B |
|                                               |              |                |              |              |           |           |
| Decrypt · Kalyna-128-CBC (CryptoHives-Scalar) | 1KB          |     7,670.5 ns |     76.60 ns |     71.65 ns |   1,409 B |         - |
| Decrypt · Kalyna-128-CBC (BouncyCastle)       | 1KB          |    17,041.0 ns |    237.04 ns |    221.72 ns |   2,913 B |     872 B |
|                                               |              |                |              |              |           |           |
| Encrypt · Kalyna-128-CBC (CryptoHives-Scalar) | 1KB          |     3,281.7 ns |     37.03 ns |     34.64 ns |   1,411 B |         - |
| Encrypt · Kalyna-128-CBC (BouncyCastle)       | 1KB          |     8,386.9 ns |     43.09 ns |     40.31 ns |   2,911 B |     872 B |
|                                               |              |                |              |              |           |           |
| Decrypt · Kalyna-128-CBC (CryptoHives-Scalar) | 8KB          |    60,477.4 ns |    419.39 ns |    371.78 ns |   1,409 B |         - |
| Decrypt · Kalyna-128-CBC (BouncyCastle)       | 8KB          |   130,867.1 ns |  1,856.20 ns |  1,736.29 ns |   2,911 B |     872 B |
|                                               |              |                |              |              |           |           |
| Encrypt · Kalyna-128-CBC (CryptoHives-Scalar) | 8KB          |    25,744.7 ns |    301.43 ns |    281.95 ns |   1,411 B |         - |
| Encrypt · Kalyna-128-CBC (BouncyCastle)       | 8KB          |    62,709.9 ns |    523.56 ns |    489.74 ns |   2,911 B |     872 B |
|                                               |              |                |              |              |           |           |
| Decrypt · Kalyna-128-CBC (CryptoHives-Scalar) | 128KB        |   965,861.5 ns |  7,788.47 ns |  7,285.34 ns |   1,409 B |         - |
| Decrypt · Kalyna-128-CBC (BouncyCastle)       | 128KB        | 2,067,644.2 ns | 30,989.92 ns | 28,987.99 ns |   2,911 B |     872 B |
|                                               |              |                |              |              |           |           |
| Encrypt · Kalyna-128-CBC (CryptoHives-Scalar) | 128KB        |   410,582.4 ns |  2,817.04 ns |  2,635.06 ns |   1,411 B |         - |
| Encrypt · Kalyna-128-CBC (BouncyCastle)       | 128KB        |   992,993.2 ns |  8,092.16 ns |  7,569.42 ns |   2,909 B |     872 B |