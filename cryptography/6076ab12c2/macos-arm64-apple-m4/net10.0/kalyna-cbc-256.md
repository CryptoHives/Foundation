| Description                                   | TestDataSize | Mean           | Error       | StdDev      | Allocated |
|---------------------------------------------- |------------- |---------------:|------------:|------------:|----------:|
| Decrypt · Kalyna-256-CBC (CryptoHives-Scalar) | 128B         |     1,131.4 ns |     4.47 ns |     3.96 ns |         - |
| Decrypt · Kalyna-256-CBC (BouncyCastle)       | 128B         |     3,314.5 ns |    10.23 ns |     9.57 ns |    1112 B |
|                                               |              |                |             |             |           |
| Encrypt · Kalyna-256-CBC (CryptoHives-Scalar) | 128B         |       566.0 ns |     1.55 ns |     1.37 ns |         - |
| Encrypt · Kalyna-256-CBC (BouncyCastle)       | 128B         |     1,738.1 ns |     3.53 ns |     3.30 ns |    1112 B |
|                                               |              |                |             |             |           |
| Decrypt · Kalyna-256-CBC (CryptoHives-Scalar) | 1KB          |     8,068.3 ns |    31.38 ns |    29.35 ns |         - |
| Decrypt · Kalyna-256-CBC (BouncyCastle)       | 1KB          |    21,276.1 ns |    83.85 ns |    78.44 ns |    1112 B |
|                                               |              |                |             |             |           |
| Encrypt · Kalyna-256-CBC (CryptoHives-Scalar) | 1KB          |     4,077.8 ns |     7.57 ns |     6.71 ns |         - |
| Encrypt · Kalyna-256-CBC (BouncyCastle)       | 1KB          |    10,005.7 ns |    24.75 ns |    21.94 ns |    1112 B |
|                                               |              |                |             |             |           |
| Decrypt · Kalyna-256-CBC (CryptoHives-Scalar) | 8KB          |    63,518.1 ns |   181.32 ns |   169.61 ns |         - |
| Decrypt · Kalyna-256-CBC (BouncyCastle)       | 8KB          |   164,757.5 ns |   328.29 ns |   291.02 ns |    1112 B |
|                                               |              |                |             |             |           |
| Encrypt · Kalyna-256-CBC (CryptoHives-Scalar) | 8KB          |    32,231.5 ns |    67.20 ns |    62.86 ns |         - |
| Encrypt · Kalyna-256-CBC (BouncyCastle)       | 8KB          |    75,881.3 ns |   401.45 ns |   375.52 ns |    1112 B |
|                                               |              |                |             |             |           |
| Decrypt · Kalyna-256-CBC (CryptoHives-Scalar) | 128KB        | 1,014,228.9 ns | 3,787.12 ns | 3,357.19 ns |         - |
| Decrypt · Kalyna-256-CBC (BouncyCastle)       | 128KB        | 2,623,816.5 ns | 7,470.15 ns | 6,987.59 ns |    1112 B |
|                                               |              |                |             |             |           |
| Encrypt · Kalyna-256-CBC (CryptoHives-Scalar) | 128KB        |   508,524.9 ns | 1,623.38 ns | 1,518.51 ns |         - |
| Encrypt · Kalyna-256-CBC (BouncyCastle)       | 128KB        | 1,192,312.1 ns | 3,629.93 ns | 3,395.44 ns |    1112 B |