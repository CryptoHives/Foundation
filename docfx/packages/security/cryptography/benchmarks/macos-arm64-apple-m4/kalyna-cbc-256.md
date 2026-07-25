| Description                                   | TestDataSize | Mean           | Error       | StdDev      | Allocated |
|---------------------------------------------- |------------- |---------------:|------------:|------------:|----------:|
| Decrypt · Kalyna-256-CBC (CryptoHives-Scalar) | 128B         |     1,122.2 ns |     0.99 ns |     0.92 ns |         - |
| Decrypt · Kalyna-256-CBC (BouncyCastle)       | 128B         |     3,289.0 ns |     2.17 ns |     2.03 ns |    1112 B |
|                                               |              |                |             |             |           |
| Encrypt · Kalyna-256-CBC (CryptoHives-Scalar) | 128B         |       553.4 ns |     0.38 ns |     0.33 ns |         - |
| Encrypt · Kalyna-256-CBC (BouncyCastle)       | 128B         |     1,705.0 ns |     1.20 ns |     1.13 ns |    1112 B |
|                                               |              |                |             |             |           |
| Decrypt · Kalyna-256-CBC (CryptoHives-Scalar) | 1KB          |     8,010.9 ns |    12.45 ns |    11.03 ns |         - |
| Decrypt · Kalyna-256-CBC (BouncyCastle)       | 1KB          |    21,136.2 ns |     9.85 ns |     9.22 ns |    1112 B |
|                                               |              |                |             |             |           |
| Encrypt · Kalyna-256-CBC (CryptoHives-Scalar) | 1KB          |     4,011.0 ns |     1.64 ns |     1.54 ns |         - |
| Encrypt · Kalyna-256-CBC (BouncyCastle)       | 1KB          |     9,741.5 ns |    17.28 ns |    16.17 ns |    1112 B |
|                                               |              |                |             |             |           |
| Decrypt · Kalyna-256-CBC (CryptoHives-Scalar) | 8KB          |    63,107.0 ns |   117.43 ns |    91.68 ns |         - |
| Decrypt · Kalyna-256-CBC (BouncyCastle)       | 8KB          |   164,039.3 ns |   387.62 ns |   323.68 ns |    1112 B |
|                                               |              |                |             |             |           |
| Encrypt · Kalyna-256-CBC (CryptoHives-Scalar) | 8KB          |    31,626.4 ns |    26.42 ns |    24.71 ns |         - |
| Encrypt · Kalyna-256-CBC (BouncyCastle)       | 8KB          |    73,843.6 ns |   159.31 ns |   141.23 ns |    1112 B |
|                                               |              |                |             |             |           |
| Decrypt · Kalyna-256-CBC (CryptoHives-Scalar) | 128KB        | 1,011,116.8 ns |   914.14 ns |   810.36 ns |         - |
| Decrypt · Kalyna-256-CBC (BouncyCastle)       | 128KB        | 2,619,103.8 ns | 1,515.69 ns | 1,265.67 ns |    1112 B |
|                                               |              |                |             |             |           |
| Encrypt · Kalyna-256-CBC (CryptoHives-Scalar) | 128KB        |   505,551.8 ns |   206.42 ns |   182.98 ns |         - |
| Encrypt · Kalyna-256-CBC (BouncyCastle)       | 128KB        | 1,177,154.1 ns | 4,032.05 ns | 3,771.58 ns |    1112 B |