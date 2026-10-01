| Description                                   | TestDataSize | Mean           | Error        | StdDev       | Allocated |
|---------------------------------------------- |------------- |---------------:|-------------:|-------------:|----------:|
| Decrypt · Kalyna-256-CBC (CryptoHives-Scalar) | 128B         |     1,455.8 ns |     10.72 ns |     10.03 ns |         - |
| Decrypt · Kalyna-256-CBC (BouncyCastle)       | 128B         |     3,681.9 ns |     37.44 ns |     35.02 ns |    1112 B |
|                                               |              |                |              |              |           |
| Encrypt · Kalyna-256-CBC (CryptoHives-Scalar) | 128B         |       644.4 ns |      6.94 ns |      6.49 ns |         - |
| Encrypt · Kalyna-256-CBC (BouncyCastle)       | 128B         |     2,030.2 ns |     24.84 ns |     23.23 ns |    1112 B |
|                                               |              |                |              |              |           |
| Decrypt · Kalyna-256-CBC (CryptoHives-Scalar) | 1KB          |    10,389.2 ns |     91.17 ns |     85.28 ns |         - |
| Decrypt · Kalyna-256-CBC (BouncyCastle)       | 1KB          |    23,050.1 ns |    269.09 ns |    251.71 ns |    1112 B |
|                                               |              |                |              |              |           |
| Encrypt · Kalyna-256-CBC (CryptoHives-Scalar) | 1KB          |     4,530.6 ns |     48.17 ns |     45.05 ns |         - |
| Encrypt · Kalyna-256-CBC (BouncyCastle)       | 1KB          |    11,160.2 ns |     85.85 ns |     80.30 ns |    1112 B |
|                                               |              |                |              |              |           |
| Decrypt · Kalyna-256-CBC (CryptoHives-Scalar) | 8KB          |    81,917.5 ns |    758.66 ns |    709.65 ns |         - |
| Decrypt · Kalyna-256-CBC (BouncyCastle)       | 8KB          |   177,660.9 ns |  2,133.82 ns |  1,995.98 ns |    1112 B |
|                                               |              |                |              |              |           |
| Encrypt · Kalyna-256-CBC (CryptoHives-Scalar) | 8KB          |    35,706.8 ns |    190.52 ns |    178.21 ns |         - |
| Encrypt · Kalyna-256-CBC (BouncyCastle)       | 8KB          |    85,102.2 ns |    816.76 ns |    764.00 ns |    1112 B |
|                                               |              |                |              |              |           |
| Decrypt · Kalyna-256-CBC (CryptoHives-Scalar) | 128KB        | 1,306,529.5 ns | 11,921.34 ns | 11,151.23 ns |         - |
| Decrypt · Kalyna-256-CBC (BouncyCastle)       | 128KB        | 2,829,934.2 ns | 43,093.39 ns | 40,309.58 ns |    1112 B |
|                                               |              |                |              |              |           |
| Encrypt · Kalyna-256-CBC (CryptoHives-Scalar) | 128KB        |   569,692.4 ns |  3,015.31 ns |  2,820.53 ns |         - |
| Encrypt · Kalyna-256-CBC (BouncyCastle)       | 128KB        | 1,330,068.8 ns |  6,730.11 ns |  6,295.35 ns |    1112 B |