| Description                                   | TestDataSize | Mean           | Error        | StdDev       | Allocated |
|---------------------------------------------- |------------- |---------------:|-------------:|-------------:|----------:|
| Decrypt · Kalyna-128-CBC (CryptoHives-Scalar) | 128B         |       808.6 ns |      9.66 ns |      9.04 ns |         - |
| Decrypt · Kalyna-128-CBC (BouncyCastle)       | 128B         |     2,438.7 ns |     46.42 ns |     47.67 ns |     872 B |
|                                               |              |                |              |              |           |
| Encrypt · Kalyna-128-CBC (CryptoHives-Scalar) | 128B         |       408.4 ns |      4.61 ns |      4.31 ns |         - |
| Encrypt · Kalyna-128-CBC (BouncyCastle)       | 128B         |     1,269.1 ns |     16.83 ns |     14.06 ns |     872 B |
|                                               |              |                |              |              |           |
| Decrypt · Kalyna-128-CBC (CryptoHives-Scalar) | 1KB          |     5,717.4 ns |     67.15 ns |     59.52 ns |         - |
| Decrypt · Kalyna-128-CBC (BouncyCastle)       | 1KB          |    15,431.9 ns |      7.67 ns |      5.99 ns |     872 B |
|                                               |              |                |              |              |           |
| Encrypt · Kalyna-128-CBC (CryptoHives-Scalar) | 1KB          |     2,946.9 ns |     29.72 ns |     27.80 ns |         - |
| Encrypt · Kalyna-128-CBC (BouncyCastle)       | 1KB          |     7,230.2 ns |     87.30 ns |     81.66 ns |     872 B |
|                                               |              |                |              |              |           |
| Decrypt · Kalyna-128-CBC (CryptoHives-Scalar) | 8KB          |    44,902.5 ns |    447.50 ns |    373.69 ns |         - |
| Decrypt · Kalyna-128-CBC (BouncyCastle)       | 8KB          |   120,211.3 ns |  1,430.61 ns |  1,338.19 ns |     872 B |
|                                               |              |                |              |              |           |
| Encrypt · Kalyna-128-CBC (CryptoHives-Scalar) | 8KB          |    23,287.1 ns |    240.97 ns |    225.40 ns |         - |
| Encrypt · Kalyna-128-CBC (BouncyCastle)       | 8KB          |    55,246.9 ns |    623.51 ns |    583.23 ns |     872 B |
|                                               |              |                |              |              |           |
| Decrypt · Kalyna-128-CBC (CryptoHives-Scalar) | 128KB        |   720,671.6 ns |  9,359.52 ns |  8,754.90 ns |         - |
| Decrypt · Kalyna-128-CBC (BouncyCastle)       | 128KB        | 1,921,432.4 ns | 22,734.57 ns | 21,265.93 ns |     872 B |
|                                               |              |                |              |              |           |
| Encrypt · Kalyna-128-CBC (CryptoHives-Scalar) | 128KB        |   372,413.5 ns |  3,630.33 ns |  3,218.19 ns |         - |
| Encrypt · Kalyna-128-CBC (BouncyCastle)       | 128KB        |   876,997.4 ns | 10,392.52 ns |  9,721.17 ns |     872 B |