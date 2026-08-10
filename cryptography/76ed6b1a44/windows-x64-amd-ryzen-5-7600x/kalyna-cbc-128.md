| Description                                   | TestDataSize | Mean           | Error       | StdDev      | Allocated |
|---------------------------------------------- |------------- |---------------:|------------:|------------:|----------:|
| Decrypt · Kalyna-128-CBC (CryptoHives-Scalar) | 128B         |       929.8 ns |     9.34 ns |     8.74 ns |         - |
| Decrypt · Kalyna-128-CBC (BouncyCastle)       | 128B         |     2,372.6 ns |    13.01 ns |    12.17 ns |     872 B |
|                                               |              |                |             |             |           |
| Encrypt · Kalyna-128-CBC (CryptoHives-Scalar) | 128B         |       392.6 ns |     3.58 ns |     3.35 ns |         - |
| Encrypt · Kalyna-128-CBC (BouncyCastle)       | 128B         |     1,357.1 ns |     5.66 ns |     5.01 ns |     872 B |
|                                               |              |                |             |             |           |
| Decrypt · Kalyna-128-CBC (CryptoHives-Scalar) | 1KB          |     6,569.8 ns |    14.88 ns |    13.92 ns |         - |
| Decrypt · Kalyna-128-CBC (BouncyCastle)       | 1KB          |    14,381.0 ns |    63.39 ns |    56.20 ns |     872 B |
|                                               |              |                |             |             |           |
| Encrypt · Kalyna-128-CBC (CryptoHives-Scalar) | 1KB          |     2,785.7 ns |    19.83 ns |    16.56 ns |         - |
| Encrypt · Kalyna-128-CBC (BouncyCastle)       | 1KB          |     7,090.0 ns |    30.89 ns |    27.39 ns |     872 B |
|                                               |              |                |             |             |           |
| Decrypt · Kalyna-128-CBC (CryptoHives-Scalar) | 8KB          |    51,860.2 ns |   182.83 ns |   171.02 ns |         - |
| Decrypt · Kalyna-128-CBC (BouncyCastle)       | 8KB          |   110,702.4 ns |   507.11 ns |   474.35 ns |     872 B |
|                                               |              |                |             |             |           |
| Encrypt · Kalyna-128-CBC (CryptoHives-Scalar) | 8KB          |    21,379.4 ns |    79.21 ns |    70.22 ns |         - |
| Encrypt · Kalyna-128-CBC (BouncyCastle)       | 8KB          |    53,086.9 ns |   158.20 ns |   132.10 ns |     872 B |
|                                               |              |                |             |             |           |
| Decrypt · Kalyna-128-CBC (CryptoHives-Scalar) | 128KB        |   826,959.4 ns | 1,971.56 ns | 1,844.20 ns |         - |
| Decrypt · Kalyna-128-CBC (BouncyCastle)       | 128KB        | 1,762,739.8 ns | 9,967.62 ns | 9,323.72 ns |     872 B |
|                                               |              |                |             |             |           |
| Encrypt · Kalyna-128-CBC (CryptoHives-Scalar) | 128KB        |   341,884.5 ns | 1,493.29 ns | 1,396.83 ns |         - |
| Encrypt · Kalyna-128-CBC (BouncyCastle)       | 128KB        |   838,112.3 ns | 1,680.78 ns | 1,312.24 ns |     872 B |