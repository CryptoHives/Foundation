| Description                                   | TestDataSize | Mean           | Error       | StdDev      | Allocated |
|---------------------------------------------- |------------- |---------------:|------------:|------------:|----------:|
| Decrypt · Kalyna-128-CBC (CryptoHives-Scalar) | 128B         |       930.4 ns |    14.70 ns |    15.73 ns |         - |
| Decrypt · Kalyna-128-CBC (BouncyCastle)       | 128B         |     2,417.0 ns |    16.53 ns |    15.46 ns |     872 B |
|                                               |              |                |             |             |           |
| Encrypt · Kalyna-128-CBC (CryptoHives-Scalar) | 128B         |       408.4 ns |     2.95 ns |     2.76 ns |         - |
| Encrypt · Kalyna-128-CBC (BouncyCastle)       | 128B         |     1,351.9 ns |     9.09 ns |     8.50 ns |     872 B |
|                                               |              |                |             |             |           |
| Decrypt · Kalyna-128-CBC (CryptoHives-Scalar) | 1KB          |     6,553.5 ns |    17.74 ns |    15.73 ns |         - |
| Decrypt · Kalyna-128-CBC (BouncyCastle)       | 1KB          |    14,752.8 ns |   109.72 ns |    85.66 ns |     872 B |
|                                               |              |                |             |             |           |
| Encrypt · Kalyna-128-CBC (CryptoHives-Scalar) | 1KB          |     2,821.0 ns |    24.67 ns |    20.60 ns |         - |
| Encrypt · Kalyna-128-CBC (BouncyCastle)       | 1KB          |     7,193.5 ns |    22.43 ns |    18.73 ns |     872 B |
|                                               |              |                |             |             |           |
| Decrypt · Kalyna-128-CBC (CryptoHives-Scalar) | 8KB          |    51,627.3 ns |   171.36 ns |   151.90 ns |         - |
| Decrypt · Kalyna-128-CBC (BouncyCastle)       | 8KB          |   114,039.3 ns |   631.87 ns |   527.64 ns |     872 B |
|                                               |              |                |             |             |           |
| Encrypt · Kalyna-128-CBC (CryptoHives-Scalar) | 8KB          |    22,111.0 ns |   174.00 ns |   145.30 ns |         - |
| Encrypt · Kalyna-128-CBC (BouncyCastle)       | 8KB          |    53,982.3 ns |   121.15 ns |   107.39 ns |     872 B |
|                                               |              |                |             |             |           |
| Decrypt · Kalyna-128-CBC (CryptoHives-Scalar) | 128KB        |   824,332.3 ns | 3,339.26 ns | 2,788.43 ns |         - |
| Decrypt · Kalyna-128-CBC (BouncyCastle)       | 128KB        | 1,804,862.5 ns | 8,451.56 ns | 7,905.60 ns |     872 B |
|                                               |              |                |             |             |           |
| Encrypt · Kalyna-128-CBC (CryptoHives-Scalar) | 128KB        |   352,621.6 ns | 1,904.61 ns | 1,688.39 ns |         - |
| Encrypt · Kalyna-128-CBC (BouncyCastle)       | 128KB        |   853,229.1 ns | 4,302.56 ns | 4,024.62 ns |     872 B |