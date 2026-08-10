| Description                                   | TestDataSize | Mean           | Error       | StdDev      | Allocated |
|---------------------------------------------- |------------- |---------------:|------------:|------------:|----------:|
| Decrypt · Kalyna-256-CBC (CryptoHives-Scalar) | 128B         |     1,132.7 ns |     1.16 ns |     1.09 ns |         - |
| Decrypt · Kalyna-256-CBC (BouncyCastle)       | 128B         |     3,314.7 ns |     5.25 ns |     4.91 ns |    1112 B |
|                                               |              |                |             |             |           |
| Encrypt · Kalyna-256-CBC (CryptoHives-Scalar) | 128B         |       556.5 ns |     1.44 ns |     1.35 ns |         - |
| Encrypt · Kalyna-256-CBC (BouncyCastle)       | 128B         |     1,714.4 ns |     2.15 ns |     2.01 ns |    1112 B |
|                                               |              |                |             |             |           |
| Decrypt · Kalyna-256-CBC (CryptoHives-Scalar) | 1KB          |     8,072.1 ns |    24.68 ns |    23.08 ns |         - |
| Decrypt · Kalyna-256-CBC (BouncyCastle)       | 1KB          |    21,292.0 ns |    34.78 ns |    32.53 ns |    1112 B |
|                                               |              |                |             |             |           |
| Encrypt · Kalyna-256-CBC (CryptoHives-Scalar) | 1KB          |     4,044.1 ns |     2.41 ns |     2.25 ns |         - |
| Encrypt · Kalyna-256-CBC (BouncyCastle)       | 1KB          |     9,853.5 ns |     9.81 ns |     9.17 ns |    1112 B |
|                                               |              |                |             |             |           |
| Decrypt · Kalyna-256-CBC (CryptoHives-Scalar) | 8KB          |    63,606.0 ns |   164.53 ns |   153.90 ns |         - |
| Decrypt · Kalyna-256-CBC (BouncyCastle)       | 8KB          |   164,816.6 ns |   574.91 ns |   480.07 ns |    1112 B |
|                                               |              |                |             |             |           |
| Encrypt · Kalyna-256-CBC (CryptoHives-Scalar) | 8KB          |    31,832.7 ns |    72.20 ns |    67.53 ns |         - |
| Encrypt · Kalyna-256-CBC (BouncyCastle)       | 8KB          |    74,980.5 ns |   183.65 ns |   171.79 ns |    1112 B |
|                                               |              |                |             |             |           |
| Decrypt · Kalyna-256-CBC (CryptoHives-Scalar) | 128KB        | 1,017,234.9 ns | 2,877.26 ns | 2,691.39 ns |         - |
| Decrypt · Kalyna-256-CBC (BouncyCastle)       | 128KB        | 2,628,988.7 ns | 2,214.65 ns | 1,963.23 ns |    1112 B |
|                                               |              |                |             |             |           |
| Encrypt · Kalyna-256-CBC (CryptoHives-Scalar) | 128KB        |   509,280.8 ns |   300.30 ns |   280.90 ns |         - |
| Encrypt · Kalyna-256-CBC (BouncyCastle)       | 128KB        | 1,192,645.4 ns | 1,933.39 ns | 1,808.49 ns |    1112 B |