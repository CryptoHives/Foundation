| Description                                   | TestDataSize | Mean           | Error       | StdDev      | Allocated |
|---------------------------------------------- |------------- |---------------:|------------:|------------:|----------:|
| Decrypt · Kalyna-256-CBC (CryptoHives-Scalar) | 128B         |     1,287.1 ns |     6.20 ns |     5.80 ns |         - |
| Decrypt · Kalyna-256-CBC (BouncyCastle)       | 128B         |     3,244.3 ns |    11.81 ns |    11.04 ns |    1112 B |
|                                               |              |                |             |             |           |
| Encrypt · Kalyna-256-CBC (CryptoHives-Scalar) | 128B         |       568.8 ns |    10.07 ns |    11.20 ns |         - |
| Encrypt · Kalyna-256-CBC (BouncyCastle)       | 128B         |     1,788.6 ns |    17.13 ns |    14.30 ns |    1112 B |
|                                               |              |                |             |             |           |
| Decrypt · Kalyna-256-CBC (CryptoHives-Scalar) | 1KB          |     9,166.3 ns |    28.00 ns |    24.82 ns |         - |
| Decrypt · Kalyna-256-CBC (BouncyCastle)       | 1KB          |    20,369.7 ns |    73.57 ns |    61.43 ns |    1112 B |
|                                               |              |                |             |             |           |
| Encrypt · Kalyna-256-CBC (CryptoHives-Scalar) | 1KB          |     4,070.8 ns |    22.05 ns |    19.54 ns |         - |
| Encrypt · Kalyna-256-CBC (BouncyCastle)       | 1KB          |     9,744.8 ns |    36.00 ns |    33.67 ns |    1112 B |
|                                               |              |                |             |             |           |
| Decrypt · Kalyna-256-CBC (CryptoHives-Scalar) | 8KB          |    71,977.2 ns |    83.58 ns |    69.79 ns |         - |
| Decrypt · Kalyna-256-CBC (BouncyCastle)       | 8KB          |   156,789.2 ns |   736.05 ns |   652.49 ns |    1112 B |
|                                               |              |                |             |             |           |
| Encrypt · Kalyna-256-CBC (CryptoHives-Scalar) | 8KB          |    31,184.0 ns |    76.94 ns |    68.21 ns |         - |
| Encrypt · Kalyna-256-CBC (BouncyCastle)       | 8KB          |    71,987.6 ns |   388.34 ns |   303.19 ns |    1112 B |
|                                               |              |                |             |             |           |
| Decrypt · Kalyna-256-CBC (CryptoHives-Scalar) | 128KB        | 1,150,333.8 ns | 4,122.29 ns | 3,856.00 ns |         - |
| Decrypt · Kalyna-256-CBC (BouncyCastle)       | 128KB        | 2,490,011.8 ns | 4,113.75 ns | 3,211.75 ns |    1112 B |
|                                               |              |                |             |             |           |
| Encrypt · Kalyna-256-CBC (CryptoHives-Scalar) | 128KB        |   487,132.2 ns | 3,452.29 ns | 3,229.27 ns |         - |
| Encrypt · Kalyna-256-CBC (BouncyCastle)       | 128KB        | 1,160,103.0 ns | 4,420.79 ns | 3,918.92 ns |    1112 B |