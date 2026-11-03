| Description                                   | TestDataSize | Mean           | Error       | StdDev      | Code Size | Allocated |
|---------------------------------------------- |------------- |---------------:|------------:|------------:|----------:|----------:|
| Decrypt · Kalyna-128-CBC (CryptoHives-Scalar) | 128B         |     1,134.0 ns |     2.31 ns |     2.16 ns |   1,409 B |         - |
| Decrypt · Kalyna-128-CBC (BouncyCastle)       | 128B         |     2,698.5 ns |     5.20 ns |     4.86 ns |   2,911 B |     872 B |
|                                               |              |                |             |             |           |           |
| Encrypt · Kalyna-128-CBC (CryptoHives-Scalar) | 128B         |       472.4 ns |     1.65 ns |     1.54 ns |   1,411 B |         - |
| Encrypt · Kalyna-128-CBC (BouncyCastle)       | 128B         |     1,531.4 ns |     3.49 ns |     3.09 ns |   2,911 B |     872 B |
|                                               |              |                |             |             |           |           |
| Decrypt · Kalyna-128-CBC (CryptoHives-Scalar) | 1KB          |     7,531.3 ns |     7.81 ns |     7.30 ns |   1,409 B |         - |
| Decrypt · Kalyna-128-CBC (BouncyCastle)       | 1KB          |    16,603.4 ns |    61.89 ns |    57.89 ns |   2,913 B |     872 B |
|                                               |              |                |             |             |           |           |
| Encrypt · Kalyna-128-CBC (CryptoHives-Scalar) | 1KB          |     3,223.9 ns |     4.09 ns |     3.82 ns |   1,411 B |         - |
| Encrypt · Kalyna-128-CBC (BouncyCastle)       | 1KB          |     8,260.1 ns |    26.53 ns |    23.51 ns |   2,911 B |     872 B |
|                                               |              |                |             |             |           |           |
| Decrypt · Kalyna-128-CBC (CryptoHives-Scalar) | 8KB          |    59,309.8 ns |    59.40 ns |    52.65 ns |   1,409 B |         - |
| Decrypt · Kalyna-128-CBC (BouncyCastle)       | 8KB          |   127,938.5 ns |   321.06 ns |   300.32 ns |   2,911 B |     872 B |
|                                               |              |                |             |             |           |           |
| Encrypt · Kalyna-128-CBC (CryptoHives-Scalar) | 8KB          |    25,183.9 ns |    44.79 ns |    39.71 ns |   1,411 B |         - |
| Encrypt · Kalyna-128-CBC (BouncyCastle)       | 8KB          |    61,743.3 ns |   210.21 ns |   196.63 ns |   2,911 B |     872 B |
|                                               |              |                |             |             |           |           |
| Decrypt · Kalyna-128-CBC (CryptoHives-Scalar) | 128KB        |   952,265.7 ns |   743.31 ns |   695.30 ns |   1,409 B |         - |
| Decrypt · Kalyna-128-CBC (BouncyCastle)       | 128KB        | 2,030,908.0 ns | 2,551.13 ns | 2,261.51 ns |   2,911 B |     872 B |
|                                               |              |                |             |             |           |           |
| Encrypt · Kalyna-128-CBC (CryptoHives-Scalar) | 128KB        |   402,219.4 ns |   576.92 ns |   511.42 ns |   1,411 B |         - |
| Encrypt · Kalyna-128-CBC (BouncyCastle)       | 128KB        |   977,582.4 ns |   597.22 ns |   498.70 ns |   2,909 B |     872 B |