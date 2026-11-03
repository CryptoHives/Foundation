| Description                                   | TestDataSize | Mean           | Error       | StdDev      | Allocated |
|---------------------------------------------- |------------- |---------------:|------------:|------------:|----------:|
| Decrypt · Kalyna-256-CBC (CryptoHives-Scalar) | 128B         |     1,093.2 ns |     3.62 ns |     3.38 ns |         - |
| Decrypt · Kalyna-256-CBC (BouncyCastle)       | 128B         |     3,268.8 ns |     6.93 ns |     6.48 ns |    1112 B |
|                                               |              |                |             |             |           |
| Encrypt · Kalyna-256-CBC (CryptoHives-Scalar) | 128B         |       550.7 ns |     2.13 ns |     1.99 ns |         - |
| Encrypt · Kalyna-256-CBC (BouncyCastle)       | 128B         |     1,683.4 ns |     5.41 ns |     5.06 ns |    1112 B |
|                                               |              |                |             |             |           |
| Decrypt · Kalyna-256-CBC (CryptoHives-Scalar) | 1KB          |     7,792.4 ns |    22.76 ns |    19.01 ns |         - |
| Decrypt · Kalyna-256-CBC (BouncyCastle)       | 1KB          |    20,965.4 ns |    59.24 ns |    55.41 ns |    1112 B |
|                                               |              |                |             |             |           |
| Encrypt · Kalyna-256-CBC (CryptoHives-Scalar) | 1KB          |     3,949.3 ns |    14.87 ns |    13.91 ns |         - |
| Encrypt · Kalyna-256-CBC (BouncyCastle)       | 1KB          |     9,458.4 ns |    34.82 ns |    32.57 ns |    1112 B |
|                                               |              |                |             |             |           |
| Decrypt · Kalyna-256-CBC (CryptoHives-Scalar) | 8KB          |    61,582.2 ns |   166.93 ns |   156.15 ns |         - |
| Decrypt · Kalyna-256-CBC (BouncyCastle)       | 8KB          |   162,484.3 ns |   337.69 ns |   315.87 ns |    1112 B |
|                                               |              |                |             |             |           |
| Encrypt · Kalyna-256-CBC (CryptoHives-Scalar) | 8KB          |    31,107.2 ns |   155.39 ns |   145.35 ns |         - |
| Encrypt · Kalyna-256-CBC (BouncyCastle)       | 8KB          |    72,241.8 ns |   681.16 ns |   603.83 ns |    1112 B |
|                                               |              |                |             |             |           |
| Decrypt · Kalyna-256-CBC (CryptoHives-Scalar) | 128KB        |   985,193.5 ns | 2,504.90 ns | 2,343.09 ns |         - |
| Decrypt · Kalyna-256-CBC (BouncyCastle)       | 128KB        | 2,591,229.8 ns | 8,402.86 ns | 7,860.04 ns |    1112 B |
|                                               |              |                |             |             |           |
| Encrypt · Kalyna-256-CBC (CryptoHives-Scalar) | 128KB        |   497,896.6 ns | 2,882.82 ns | 2,696.59 ns |         - |
| Encrypt · Kalyna-256-CBC (BouncyCastle)       | 128KB        | 1,138,357.1 ns | 4,836.06 ns | 4,523.66 ns |    1112 B |