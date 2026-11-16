| Description                                   | TestDataSize | Mean           | Error       | StdDev      | Allocated |
|---------------------------------------------- |------------- |---------------:|------------:|------------:|----------:|
| Decrypt · Kalyna-128-CBC (CryptoHives-Scalar) | 128B         |       792.0 ns |     2.05 ns |     1.81 ns |         - |
| Decrypt · Kalyna-128-CBC (BouncyCastle)       | 128B         |     2,421.0 ns |    10.41 ns |     8.69 ns |     872 B |
|                                               |              |                |             |             |           |
| Encrypt · Kalyna-128-CBC (CryptoHives-Scalar) | 128B         |       407.9 ns |     0.79 ns |     0.66 ns |         - |
| Encrypt · Kalyna-128-CBC (BouncyCastle)       | 128B         |     1,274.8 ns |     4.57 ns |     4.27 ns |     872 B |
|                                               |              |                |             |             |           |
| Decrypt · Kalyna-128-CBC (CryptoHives-Scalar) | 1KB          |     5,635.4 ns |    26.37 ns |    23.38 ns |         - |
| Decrypt · Kalyna-128-CBC (BouncyCastle)       | 1KB          |    15,480.6 ns |   109.08 ns |   102.04 ns |     872 B |
|                                               |              |                |             |             |           |
| Encrypt · Kalyna-128-CBC (CryptoHives-Scalar) | 1KB          |     2,893.0 ns |     9.55 ns |     7.97 ns |         - |
| Encrypt · Kalyna-128-CBC (BouncyCastle)       | 1KB          |     7,112.6 ns |    23.52 ns |    22.00 ns |     872 B |
|                                               |              |                |             |             |           |
| Decrypt · Kalyna-128-CBC (CryptoHives-Scalar) | 8KB          |    44,324.0 ns |   153.43 ns |   143.52 ns |         - |
| Decrypt · Kalyna-128-CBC (BouncyCastle)       | 8KB          |   119,805.9 ns |   410.50 ns |   383.98 ns |     872 B |
|                                               |              |                |             |             |           |
| Encrypt · Kalyna-128-CBC (CryptoHives-Scalar) | 8KB          |    22,950.8 ns |    52.52 ns |    49.13 ns |         - |
| Encrypt · Kalyna-128-CBC (BouncyCastle)       | 8KB          |    53,743.0 ns |   179.52 ns |   167.92 ns |     872 B |
|                                               |              |                |             |             |           |
| Decrypt · Kalyna-128-CBC (CryptoHives-Scalar) | 128KB        |   708,033.5 ns | 3,580.00 ns | 3,348.73 ns |         - |
| Decrypt · Kalyna-128-CBC (BouncyCastle)       | 128KB        | 1,911,092.3 ns | 4,744.93 ns | 4,438.41 ns |     872 B |
|                                               |              |                |             |             |           |
| Encrypt · Kalyna-128-CBC (CryptoHives-Scalar) | 128KB        |   367,497.4 ns |   546.48 ns |   484.44 ns |         - |
| Encrypt · Kalyna-128-CBC (BouncyCastle)       | 128KB        |   854,409.2 ns | 2,033.92 ns | 1,902.53 ns |     872 B |