| Description                                   | TestDataSize | Mean           | Error       | StdDev      | Allocated |
|---------------------------------------------- |------------- |---------------:|------------:|------------:|----------:|
| Decrypt · Kalyna-256-CBC (CryptoHives-Scalar) | 128B         |     1,128.5 ns |     3.81 ns |     3.18 ns |         - |
| Decrypt · Kalyna-256-CBC (BouncyCastle)       | 128B         |     3,303.0 ns |     2.29 ns |     2.03 ns |    1112 B |
|                                               |              |                |             |             |           |
| Encrypt · Kalyna-256-CBC (CryptoHives-Scalar) | 128B         |       554.4 ns |     2.69 ns |     2.10 ns |         - |
| Encrypt · Kalyna-256-CBC (BouncyCastle)       | 128B         |     1,699.2 ns |     3.38 ns |     2.82 ns |    1112 B |
|                                               |              |                |             |             |           |
| Decrypt · Kalyna-256-CBC (CryptoHives-Scalar) | 1KB          |     8,036.5 ns |    31.95 ns |    24.95 ns |         - |
| Decrypt · Kalyna-256-CBC (BouncyCastle)       | 1KB          |    21,269.0 ns |    16.57 ns |    12.93 ns |    1112 B |
|                                               |              |                |             |             |           |
| Encrypt · Kalyna-256-CBC (CryptoHives-Scalar) | 1KB          |     4,010.7 ns |    17.98 ns |    15.01 ns |         - |
| Encrypt · Kalyna-256-CBC (BouncyCastle)       | 1KB          |     9,626.2 ns |    19.34 ns |    17.15 ns |    1112 B |
|                                               |              |                |             |             |           |
| Decrypt · Kalyna-256-CBC (CryptoHives-Scalar) | 8KB          |    63,253.3 ns |   244.99 ns |   229.16 ns |         - |
| Decrypt · Kalyna-256-CBC (BouncyCastle)       | 8KB          |   164,958.9 ns |   155.34 ns |   145.31 ns |    1112 B |
|                                               |              |                |             |             |           |
| Encrypt · Kalyna-256-CBC (CryptoHives-Scalar) | 8KB          |    31,585.1 ns |   164.62 ns |   145.93 ns |         - |
| Encrypt · Kalyna-256-CBC (BouncyCastle)       | 8KB          |    73,257.0 ns |   363.53 ns |   322.26 ns |    1112 B |
|                                               |              |                |             |             |           |
| Decrypt · Kalyna-256-CBC (CryptoHives-Scalar) | 128KB        | 1,005,918.9 ns | 3,380.08 ns | 3,161.73 ns |         - |
| Decrypt · Kalyna-256-CBC (BouncyCastle)       | 128KB        | 2,628,385.5 ns | 1,761.63 ns | 1,375.36 ns |    1112 B |
|                                               |              |                |             |             |           |
| Encrypt · Kalyna-256-CBC (CryptoHives-Scalar) | 128KB        |   506,426.0 ns | 1,779.25 ns | 1,577.25 ns |         - |
| Encrypt · Kalyna-256-CBC (BouncyCastle)       | 128KB        | 1,164,810.6 ns | 4,690.58 ns | 4,158.07 ns |    1112 B |