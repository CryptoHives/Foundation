| Description                                   | TestDataSize | Mean           | Error       | StdDev      | Allocated |
|---------------------------------------------- |------------- |---------------:|------------:|------------:|----------:|
| Decrypt · Kalyna-256-CBC (CryptoHives-Scalar) | 128B         |     1,126.1 ns |     0.19 ns |     0.18 ns |         - |
| Decrypt · Kalyna-256-CBC (BouncyCastle)       | 128B         |     3,299.2 ns |    11.83 ns |     9.24 ns |    1112 B |
|                                               |              |                |             |             |           |
| Encrypt · Kalyna-256-CBC (CryptoHives-Scalar) | 128B         |       603.1 ns |     4.80 ns |     4.01 ns |         - |
| Encrypt · Kalyna-256-CBC (BouncyCastle)       | 128B         |     8,111.8 ns |    21.34 ns |    17.82 ns |    1112 B |
|                                               |              |                |             |             |           |
| Decrypt · Kalyna-256-CBC (CryptoHives-Scalar) | 1KB          |     8,107.3 ns |    95.43 ns |    74.50 ns |         - |
| Decrypt · Kalyna-256-CBC (BouncyCastle)       | 1KB          |    21,146.4 ns |     4.14 ns |     3.67 ns |    1112 B |
|                                               |              |                |             |             |           |
| Encrypt · Kalyna-256-CBC (CryptoHives-Scalar) | 1KB          |    18,950.1 ns |     6.82 ns |     5.32 ns |         - |
| Encrypt · Kalyna-256-CBC (BouncyCastle)       | 1KB          |    46,283.0 ns |    30.15 ns |    28.20 ns |    1112 B |
|                                               |              |                |             |             |           |
| Decrypt · Kalyna-256-CBC (CryptoHives-Scalar) | 8KB          |    63,218.4 ns |    35.89 ns |    33.57 ns |         - |
| Decrypt · Kalyna-256-CBC (BouncyCastle)       | 8KB          |   163,975.5 ns |    32.03 ns |    28.40 ns |    1112 B |
|                                               |              |                |             |             |           |
| Encrypt · Kalyna-256-CBC (CryptoHives-Scalar) | 8KB          |   149,370.5 ns |   280.44 ns |   248.60 ns |         - |
| Encrypt · Kalyna-256-CBC (BouncyCastle)       | 8KB          |   351,138.0 ns |    67.83 ns |    52.96 ns |    1112 B |
|                                               |              |                |             |             |           |
| Decrypt · Kalyna-256-CBC (CryptoHives-Scalar) | 128KB        | 1,011,518.7 ns |   335.07 ns |   297.03 ns |         - |
| Decrypt · Kalyna-256-CBC (BouncyCastle)       | 128KB        | 2,613,483.5 ns |   495.82 ns |   463.79 ns |    1112 B |
|                                               |              |                |             |             |           |
| Encrypt · Kalyna-256-CBC (BouncyCastle)       | 128KB        | 1,185,398.5 ns | 3,443.45 ns | 3,052.53 ns |    1112 B |
| Encrypt · Kalyna-256-CBC (CryptoHives-Scalar) | 128KB        | 2,386,317.4 ns | 1,116.36 ns |   989.63 ns |         - |