| Description                                   | TestDataSize | Mean           | Error        | StdDev       | Code Size | Allocated |
|---------------------------------------------- |------------- |---------------:|-------------:|-------------:|----------:|----------:|
| Decrypt · Kalyna-128-CBC (CryptoHives-Scalar) | 128B         |     1,150.8 ns |     15.75 ns |     14.73 ns |   1,431 B |         - |
| Decrypt · Kalyna-128-CBC (BouncyCastle)       | 128B         |     3,367.9 ns |     49.85 ns |     46.63 ns |   2,937 B |     872 B |
|                                               |              |                |              |              |           |           |
| Encrypt · Kalyna-128-CBC (CryptoHives-Scalar) | 128B         |       516.4 ns |      2.54 ns |      2.38 ns |   1,433 B |         - |
| Encrypt · Kalyna-128-CBC (BouncyCastle)       | 128B         |     1,886.9 ns |     30.84 ns |     28.85 ns |   2,933 B |     872 B |
|                                               |              |                |              |              |           |           |
| Decrypt · Kalyna-128-CBC (CryptoHives-Scalar) | 1KB          |     8,102.2 ns |     47.80 ns |     44.72 ns |   1,431 B |         - |
| Decrypt · Kalyna-128-CBC (BouncyCastle)       | 1KB          |    21,431.4 ns |    303.00 ns |    283.43 ns |   2,935 B |     872 B |
|                                               |              |                |              |              |           |           |
| Encrypt · Kalyna-128-CBC (CryptoHives-Scalar) | 1KB          |     3,494.0 ns |     45.11 ns |     42.19 ns |   1,433 B |         - |
| Encrypt · Kalyna-128-CBC (BouncyCastle)       | 1KB          |     9,787.9 ns |    125.71 ns |    117.59 ns |   2,935 B |     872 B |
|                                               |              |                |              |              |           |           |
| Decrypt · Kalyna-128-CBC (CryptoHives-Scalar) | 8KB          |    63,301.0 ns |    293.04 ns |    274.11 ns |   1,431 B |         - |
| Decrypt · Kalyna-128-CBC (BouncyCastle)       | 8KB          |   161,296.5 ns |  2,264.91 ns |  2,118.60 ns |   2,935 B |     872 B |
|                                               |              |                |              |              |           |           |
| Encrypt · Kalyna-128-CBC (CryptoHives-Scalar) | 8KB          |    27,171.5 ns |    364.33 ns |    340.79 ns |   1,433 B |         - |
| Encrypt · Kalyna-128-CBC (BouncyCastle)       | 8KB          |    73,304.6 ns |  1,142.31 ns |  1,068.52 ns |   2,935 B |     872 B |
|                                               |              |                |              |              |           |           |
| Decrypt · Kalyna-128-CBC (CryptoHives-Scalar) | 128KB        | 1,019,971.4 ns | 17,029.08 ns | 15,929.01 ns |   1,431 B |         - |
| Decrypt · Kalyna-128-CBC (BouncyCastle)       | 128KB        | 2,535,003.9 ns | 41,989.11 ns | 39,276.64 ns |   2,935 B |     872 B |
|                                               |              |                |              |              |           |           |
| Encrypt · Kalyna-128-CBC (CryptoHives-Scalar) | 128KB        |   432,849.6 ns |  6,230.93 ns |  5,828.42 ns |   1,433 B |         - |
| Encrypt · Kalyna-128-CBC (BouncyCastle)       | 128KB        | 1,159,601.8 ns | 17,573.79 ns | 16,438.54 ns |   2,935 B |     872 B |