| Description                                   | TestDataSize | Mean           | Error       | StdDev      | Allocated |
|---------------------------------------------- |------------- |---------------:|------------:|------------:|----------:|
| Decrypt · Kalyna-128-CBC (CryptoHives-Scalar) | 128B         |       786.6 ns |     3.77 ns |     3.52 ns |         - |
| Decrypt · Kalyna-128-CBC (BouncyCastle)       | 128B         |     2,417.7 ns |     9.79 ns |     9.15 ns |     872 B |
|                                               |              |                |             |             |           |
| Encrypt · Kalyna-128-CBC (CryptoHives-Scalar) | 128B         |       406.1 ns |     1.07 ns |     0.95 ns |         - |
| Encrypt · Kalyna-128-CBC (BouncyCastle)       | 128B         |     1,267.8 ns |     4.97 ns |     4.40 ns |     872 B |
|                                               |              |                |             |             |           |
| Decrypt · Kalyna-128-CBC (CryptoHives-Scalar) | 1KB          |     5,556.5 ns |    22.83 ns |    21.36 ns |         - |
| Decrypt · Kalyna-128-CBC (BouncyCastle)       | 1KB          |    15,354.5 ns |    45.11 ns |    42.20 ns |     872 B |
|                                               |              |                |             |             |           |
| Encrypt · Kalyna-128-CBC (CryptoHives-Scalar) | 1KB          |     2,896.7 ns |    12.05 ns |    11.27 ns |         - |
| Encrypt · Kalyna-128-CBC (BouncyCastle)       | 1KB          |     7,034.0 ns |    19.86 ns |    18.58 ns |     872 B |
|                                               |              |                |             |             |           |
| Decrypt · Kalyna-128-CBC (CryptoHives-Scalar) | 8KB          |    43,760.7 ns |   238.19 ns |   222.80 ns |         - |
| Decrypt · Kalyna-128-CBC (BouncyCastle)       | 8KB          |   118,666.1 ns |   224.73 ns |   199.21 ns |     872 B |
|                                               |              |                |             |             |           |
| Encrypt · Kalyna-128-CBC (CryptoHives-Scalar) | 8KB          |    22,857.9 ns |    76.23 ns |    71.31 ns |         - |
| Encrypt · Kalyna-128-CBC (BouncyCastle)       | 8KB          |    53,319.5 ns |   248.79 ns |   232.72 ns |     872 B |
|                                               |              |                |             |             |           |
| Decrypt · Kalyna-128-CBC (CryptoHives-Scalar) | 128KB        |   697,027.9 ns | 2,176.55 ns | 2,035.95 ns |         - |
| Decrypt · Kalyna-128-CBC (BouncyCastle)       | 128KB        | 1,890,008.3 ns | 2,286.40 ns | 2,026.83 ns |     872 B |
|                                               |              |                |             |             |           |
| Encrypt · Kalyna-128-CBC (CryptoHives-Scalar) | 128KB        |   366,804.3 ns | 1,577.63 ns | 1,475.72 ns |         - |
| Encrypt · Kalyna-128-CBC (BouncyCastle)       | 128KB        |   845,377.6 ns | 3,764.27 ns | 3,521.10 ns |     872 B |