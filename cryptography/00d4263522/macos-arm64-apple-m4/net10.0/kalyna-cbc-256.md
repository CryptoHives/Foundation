| Description                                   | TestDataSize | Mean           | Error        | StdDev       | Allocated |
|---------------------------------------------- |------------- |---------------:|-------------:|-------------:|----------:|
| Decrypt · Kalyna-256-CBC (CryptoHives-Scalar) | 128B         |     1,134.4 ns |      0.67 ns |      0.52 ns |         - |
| Decrypt · Kalyna-256-CBC (BouncyCastle)       | 128B         |     3,317.6 ns |     42.03 ns |     39.32 ns |    1112 B |
|                                               |              |                |              |              |           |
| Encrypt · Kalyna-256-CBC (CryptoHives-Scalar) | 128B         |       557.3 ns |      0.76 ns |      0.59 ns |         - |
| Encrypt · Kalyna-256-CBC (BouncyCastle)       | 128B         |     1,711.7 ns |     21.90 ns |     20.48 ns |    1112 B |
|                                               |              |                |              |              |           |
| Decrypt · Kalyna-256-CBC (CryptoHives-Scalar) | 1KB          |     8,063.7 ns |      4.15 ns |      3.24 ns |         - |
| Decrypt · Kalyna-256-CBC (BouncyCastle)       | 1KB          |    21,404.3 ns |    319.59 ns |    298.95 ns |    1112 B |
|                                               |              |                |              |              |           |
| Encrypt · Kalyna-256-CBC (CryptoHives-Scalar) | 1KB          |     4,033.0 ns |      6.47 ns |      5.05 ns |         - |
| Encrypt · Kalyna-256-CBC (BouncyCastle)       | 1KB          |     9,879.6 ns |    147.02 ns |    130.33 ns |    1112 B |
|                                               |              |                |              |              |           |
| Decrypt · Kalyna-256-CBC (CryptoHives-Scalar) | 8KB          |    63,553.6 ns |     26.36 ns |     20.58 ns |         - |
| Decrypt · Kalyna-256-CBC (BouncyCastle)       | 8KB          |   165,980.4 ns |  2,641.27 ns |  2,470.64 ns |    1112 B |
|                                               |              |                |              |              |           |
| Encrypt · Kalyna-256-CBC (CryptoHives-Scalar) | 8KB          |    31,792.7 ns |     43.08 ns |     33.63 ns |         - |
| Encrypt · Kalyna-256-CBC (BouncyCastle)       | 8KB          |    75,366.4 ns |  1,206.85 ns |  1,128.89 ns |    1112 B |
|                                               |              |                |              |              |           |
| Decrypt · Kalyna-256-CBC (CryptoHives-Scalar) | 128KB        | 1,015,792.0 ns |    721.74 ns |    563.49 ns |         - |
| Decrypt · Kalyna-256-CBC (BouncyCastle)       | 128KB        | 2,645,924.8 ns | 38,466.66 ns | 35,981.74 ns |    1112 B |
|                                               |              |                |              |              |           |
| Encrypt · Kalyna-256-CBC (CryptoHives-Scalar) | 128KB        |   507,815.0 ns |    865.52 ns |    675.74 ns |         - |
| Encrypt · Kalyna-256-CBC (BouncyCastle)       | 128KB        | 1,199,759.0 ns | 19,102.61 ns | 17,868.60 ns |    1112 B |