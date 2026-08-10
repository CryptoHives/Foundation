| Description                                   | TestDataSize | Mean           | Error        | StdDev       | Allocated |
|---------------------------------------------- |------------- |---------------:|-------------:|-------------:|----------:|
| Decrypt · Kalyna-256-CBC (CryptoHives-Scalar) | 128B         |     1,261.4 ns |      7.83 ns |      6.94 ns |         - |
| Decrypt · Kalyna-256-CBC (BouncyCastle)       | 128B         |     3,234.1 ns |     21.85 ns |     17.06 ns |    1112 B |
|                                               |              |                |              |              |           |
| Encrypt · Kalyna-256-CBC (CryptoHives-Scalar) | 128B         |       557.8 ns |      3.05 ns |      2.54 ns |         - |
| Encrypt · Kalyna-256-CBC (BouncyCastle)       | 128B         |     1,775.5 ns |      9.30 ns |      8.70 ns |    1112 B |
|                                               |              |                |              |              |           |
| Decrypt · Kalyna-256-CBC (CryptoHives-Scalar) | 1KB          |     9,021.1 ns |     41.89 ns |     34.98 ns |         - |
| Decrypt · Kalyna-256-CBC (BouncyCastle)       | 1KB          |    20,338.2 ns |    114.33 ns |    106.95 ns |    1112 B |
|                                               |              |                |              |              |           |
| Encrypt · Kalyna-256-CBC (CryptoHives-Scalar) | 1KB          |     3,889.0 ns |     22.68 ns |     20.10 ns |         - |
| Encrypt · Kalyna-256-CBC (BouncyCastle)       | 1KB          |     9,619.7 ns |     81.52 ns |     72.26 ns |    1112 B |
|                                               |              |                |              |              |           |
| Decrypt · Kalyna-256-CBC (CryptoHives-Scalar) | 8KB          |    71,115.0 ns |    312.73 ns |    292.52 ns |         - |
| Decrypt · Kalyna-256-CBC (BouncyCastle)       | 8KB          |   154,324.8 ns |  1,158.24 ns |  1,026.75 ns |    1112 B |
|                                               |              |                |              |              |           |
| Encrypt · Kalyna-256-CBC (CryptoHives-Scalar) | 8KB          |    30,640.7 ns |    201.86 ns |    188.82 ns |         - |
| Encrypt · Kalyna-256-CBC (BouncyCastle)       | 8KB          |    71,567.5 ns |    304.54 ns |    254.31 ns |    1112 B |
|                                               |              |                |              |              |           |
| Decrypt · Kalyna-256-CBC (CryptoHives-Scalar) | 128KB        | 1,133,259.1 ns |  3,172.71 ns |  2,967.76 ns |         - |
| Decrypt · Kalyna-256-CBC (BouncyCastle)       | 128KB        | 2,460,387.9 ns | 19,070.09 ns | 17,838.18 ns |    1112 B |
|                                               |              |                |              |              |           |
| Encrypt · Kalyna-256-CBC (CryptoHives-Scalar) | 128KB        |   488,027.2 ns |  1,205.34 ns |  1,068.51 ns |         - |
| Encrypt · Kalyna-256-CBC (BouncyCastle)       | 128KB        | 1,138,358.4 ns |  8,524.49 ns |  7,973.81 ns |    1112 B |