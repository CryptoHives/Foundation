| Description                                   | TestDataSize | Mean           | Error       | StdDev      | Allocated |
|---------------------------------------------- |------------- |---------------:|------------:|------------:|----------:|
| Decrypt · Kalyna-128-CBC (CryptoHives-Scalar) | 128B         |       798.7 ns |     2.73 ns |     2.42 ns |         - |
| Decrypt · Kalyna-128-CBC (BouncyCastle)       | 128B         |     2,425.8 ns |     3.09 ns |     2.89 ns |     872 B |
|                                               |              |                |             |             |           |
| Encrypt · Kalyna-128-CBC (CryptoHives-Scalar) | 128B         |       396.9 ns |     1.65 ns |     1.38 ns |         - |
| Encrypt · Kalyna-128-CBC (BouncyCastle)       | 128B         |     1,252.7 ns |     4.56 ns |     4.26 ns |     872 B |
|                                               |              |                |             |             |           |
| Decrypt · Kalyna-128-CBC (CryptoHives-Scalar) | 1KB          |     5,642.5 ns |    17.20 ns |    16.09 ns |         - |
| Decrypt · Kalyna-128-CBC (BouncyCastle)       | 1KB          |    15,461.9 ns |    12.48 ns |    11.06 ns |     872 B |
|                                               |              |                |             |             |           |
| Encrypt · Kalyna-128-CBC (CryptoHives-Scalar) | 1KB          |     2,886.6 ns |    12.01 ns |    11.23 ns |         - |
| Encrypt · Kalyna-128-CBC (BouncyCastle)       | 1KB          |     7,027.7 ns |    23.47 ns |    21.96 ns |     872 B |
|                                               |              |                |             |             |           |
| Decrypt · Kalyna-128-CBC (CryptoHives-Scalar) | 8KB          |    44,408.3 ns |   191.24 ns |   169.53 ns |         - |
| Decrypt · Kalyna-128-CBC (BouncyCastle)       | 8KB          |   119,614.1 ns |    88.51 ns |    78.46 ns |     872 B |
|                                               |              |                |             |             |           |
| Encrypt · Kalyna-128-CBC (CryptoHives-Scalar) | 8KB          |    22,890.9 ns |    66.92 ns |    62.60 ns |         - |
| Encrypt · Kalyna-128-CBC (BouncyCastle)       | 8KB          |    53,186.3 ns |   138.19 ns |   122.50 ns |     872 B |
|                                               |              |                |             |             |           |
| Decrypt · Kalyna-128-CBC (CryptoHives-Scalar) | 128KB        |   706,983.4 ns | 2,881.66 ns | 2,249.81 ns |         - |
| Decrypt · Kalyna-128-CBC (BouncyCastle)       | 128KB        | 1,902,282.2 ns | 2,917.11 ns | 2,277.49 ns |     872 B |
|                                               |              |                |             |             |           |
| Encrypt · Kalyna-128-CBC (CryptoHives-Scalar) | 128KB        |   369,102.1 ns |   873.51 ns |   817.08 ns |         - |
| Encrypt · Kalyna-128-CBC (BouncyCastle)       | 128KB        |   847,327.0 ns | 1,901.11 ns | 1,685.28 ns |     872 B |