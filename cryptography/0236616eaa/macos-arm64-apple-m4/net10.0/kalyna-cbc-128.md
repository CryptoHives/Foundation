| Description                                   | TestDataSize | Mean           | Error        | StdDev       | Allocated |
|---------------------------------------------- |------------- |---------------:|-------------:|-------------:|----------:|
| Decrypt · Kalyna-128-CBC (CryptoHives-Scalar) | 128B         |     3,774.2 ns |      2.40 ns |      1.87 ns |         - |
| Decrypt · Kalyna-128-CBC (BouncyCastle)       | 128B         |    11,377.4 ns |      4.99 ns |      4.67 ns |     872 B |
|                                               |              |                |              |              |           |
| Encrypt · Kalyna-128-CBC (CryptoHives-Scalar) | 128B         |       405.0 ns |      0.33 ns |      0.31 ns |         - |
| Encrypt · Kalyna-128-CBC (BouncyCastle)       | 128B         |     1,274.6 ns |      0.31 ns |      0.29 ns |     872 B |
|                                               |              |                |              |              |           |
| Decrypt · Kalyna-128-CBC (CryptoHives-Scalar) | 1KB          |    26,793.8 ns |     15.07 ns |     13.36 ns |         - |
| Decrypt · Kalyna-128-CBC (BouncyCastle)       | 1KB          |    72,539.4 ns |     43.30 ns |     33.81 ns |     872 B |
|                                               |              |                |              |              |           |
| Encrypt · Kalyna-128-CBC (CryptoHives-Scalar) | 1KB          |     2,917.3 ns |      5.09 ns |      4.77 ns |         - |
| Encrypt · Kalyna-128-CBC (BouncyCastle)       | 1KB          |     7,175.5 ns |      1.78 ns |      1.48 ns |     872 B |
|                                               |              |                |              |              |           |
| Decrypt · Kalyna-128-CBC (CryptoHives-Scalar) | 8KB          |    44,614.7 ns |    146.41 ns |    195.46 ns |         - |
| Decrypt · Kalyna-128-CBC (BouncyCastle)       | 8KB          |   118,935.0 ns |     32.31 ns |     28.64 ns |     872 B |
|                                               |              |                |              |              |           |
| Encrypt · Kalyna-128-CBC (CryptoHives-Scalar) | 8KB          |    25,178.8 ns |    470.35 ns |    483.02 ns |         - |
| Encrypt · Kalyna-128-CBC (BouncyCastle)       | 8KB          |    58,176.4 ns |    490.03 ns |    434.40 ns |     872 B |
|                                               |              |                |              |              |           |
| Decrypt · Kalyna-128-CBC (CryptoHives-Scalar) | 128KB        |   711,866.0 ns |    231.56 ns |    180.79 ns |         - |
| Decrypt · Kalyna-128-CBC (BouncyCastle)       | 128KB        | 1,897,439.7 ns |    187.28 ns |    156.39 ns |     872 B |
|                                               |              |                |              |              |           |
| Encrypt · Kalyna-128-CBC (CryptoHives-Scalar) | 128KB        | 1,737,908.8 ns | 21,408.39 ns | 16,714.26 ns |         - |
| Encrypt · Kalyna-128-CBC (BouncyCastle)       | 128KB        | 4,084,962.8 ns |  1,970.36 ns |  1,645.34 ns |     872 B |