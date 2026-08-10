| Description                                   | TestDataSize | Mean           | Error       | StdDev      | Allocated |
|---------------------------------------------- |------------- |---------------:|------------:|------------:|----------:|
| Decrypt · Kalyna-256-CBC (CryptoHives-Scalar) | 128B         |     1,270.8 ns |     2.72 ns |     2.41 ns |         - |
| Decrypt · Kalyna-256-CBC (BouncyCastle)       | 128B         |     3,256.7 ns |     5.23 ns |     4.89 ns |    1112 B |
|                                               |              |                |             |             |           |
| Encrypt · Kalyna-256-CBC (CryptoHives-Scalar) | 128B         |       555.3 ns |     1.45 ns |     1.36 ns |         - |
| Encrypt · Kalyna-256-CBC (BouncyCastle)       | 128B         |     1,772.6 ns |     3.45 ns |     3.22 ns |    1112 B |
|                                               |              |                |             |             |           |
| Decrypt · Kalyna-256-CBC (CryptoHives-Scalar) | 1KB          |     9,106.9 ns |    17.18 ns |    14.35 ns |         - |
| Decrypt · Kalyna-256-CBC (BouncyCastle)       | 1KB          |    20,134.7 ns |    43.75 ns |    40.92 ns |    1112 B |
|                                               |              |                |             |             |           |
| Encrypt · Kalyna-256-CBC (CryptoHives-Scalar) | 1KB          |     3,909.5 ns |     7.99 ns |     7.08 ns |         - |
| Encrypt · Kalyna-256-CBC (BouncyCastle)       | 1KB          |     9,610.5 ns |    19.66 ns |    17.43 ns |    1112 B |
|                                               |              |                |             |             |           |
| Decrypt · Kalyna-256-CBC (CryptoHives-Scalar) | 8KB          |    71,420.0 ns |   109.93 ns |    97.45 ns |         - |
| Decrypt · Kalyna-256-CBC (BouncyCastle)       | 8KB          |   155,555.3 ns |   377.70 ns |   334.82 ns |    1112 B |
|                                               |              |                |             |             |           |
| Encrypt · Kalyna-256-CBC (CryptoHives-Scalar) | 8KB          |    30,734.0 ns |    42.76 ns |    35.71 ns |         - |
| Encrypt · Kalyna-256-CBC (BouncyCastle)       | 8KB          |    71,946.8 ns |    89.65 ns |    83.86 ns |    1112 B |
|                                               |              |                |             |             |           |
| Decrypt · Kalyna-256-CBC (CryptoHives-Scalar) | 128KB        | 1,137,122.7 ns | 1,711.80 ns | 1,429.43 ns |         - |
| Decrypt · Kalyna-256-CBC (BouncyCastle)       | 128KB        | 2,467,322.8 ns | 7,261.35 ns | 5,669.19 ns |    1112 B |
|                                               |              |                |             |             |           |
| Encrypt · Kalyna-256-CBC (CryptoHives-Scalar) | 128KB        |   490,099.1 ns | 1,084.17 ns |   961.09 ns |         - |
| Encrypt · Kalyna-256-CBC (BouncyCastle)       | 128KB        | 1,145,118.8 ns | 2,679.18 ns | 2,375.02 ns |    1112 B |