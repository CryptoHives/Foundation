| Description                                   | TestDataSize | Mean           | Error        | StdDev       | Code Size | Allocated |
|---------------------------------------------- |------------- |---------------:|-------------:|-------------:|----------:|----------:|
| Decrypt · Kalyna-256-CBC (CryptoHives-Scalar) | 128B         |     2,082.1 ns |      3.24 ns |      2.88 ns |   1,431 B |         - |
| Decrypt · Kalyna-256-CBC (BouncyCastle)       | 128B         |     6,140.1 ns |     14.06 ns |     12.47 ns |   2,935 B |    1112 B |
|                                               |              |                |              |              |           |           |
| Encrypt · Kalyna-256-CBC (CryptoHives-Scalar) | 128B         |       902.0 ns |      1.16 ns |      1.08 ns |   1,433 B |         - |
| Encrypt · Kalyna-256-CBC (BouncyCastle)       | 128B         |     3,236.5 ns |      4.63 ns |      3.87 ns |   2,931 B |    1112 B |
|                                               |              |                |              |              |           |           |
| Decrypt · Kalyna-256-CBC (CryptoHives-Scalar) | 1KB          |    14,287.5 ns |     10.19 ns |      8.51 ns |   1,431 B |         - |
| Decrypt · Kalyna-256-CBC (BouncyCastle)       | 1KB          |    38,996.0 ns |     93.30 ns |     87.28 ns |   2,935 B |    1112 B |
|                                               |              |                |              |              |           |           |
| Encrypt · Kalyna-256-CBC (CryptoHives-Scalar) | 1KB          |     6,173.3 ns |      8.08 ns |      7.56 ns |   1,433 B |         - |
| Encrypt · Kalyna-256-CBC (BouncyCastle)       | 1KB          |    16,964.6 ns |     52.71 ns |     49.31 ns |   2,933 B |    1112 B |
|                                               |              |                |              |              |           |           |
| Decrypt · Kalyna-256-CBC (CryptoHives-Scalar) | 8KB          |   112,044.7 ns |    132.58 ns |    124.01 ns |   1,431 B |         - |
| Decrypt · Kalyna-256-CBC (BouncyCastle)       | 8KB          |   283,224.0 ns |    322.32 ns |    301.50 ns |   2,935 B |    1112 B |
|                                               |              |                |              |              |           |           |
| Encrypt · Kalyna-256-CBC (CryptoHives-Scalar) | 8KB          |    49,360.7 ns |    104.93 ns |     93.02 ns |   1,433 B |         - |
| Encrypt · Kalyna-256-CBC (BouncyCastle)       | 8KB          |   128,776.1 ns |    283.31 ns |    251.14 ns |   2,935 B |    1112 B |
|                                               |              |                |              |              |           |           |
| Decrypt · Kalyna-256-CBC (CryptoHives-Scalar) | 128KB        | 1,794,528.9 ns |  1,342.49 ns |  1,190.08 ns |   1,431 B |         - |
| Decrypt · Kalyna-256-CBC (BouncyCastle)       | 128KB        | 4,501,418.3 ns |  5,078.72 ns |  4,502.15 ns |   2,933 B |    1112 B |
|                                               |              |                |              |              |           |           |
| Encrypt · Kalyna-256-CBC (CryptoHives-Scalar) | 128KB        |   781,511.5 ns |    778.48 ns |    650.06 ns |   1,433 B |         - |
| Encrypt · Kalyna-256-CBC (BouncyCastle)       | 128KB        | 2,025,663.9 ns | 12,228.52 ns | 11,438.57 ns |   2,935 B |    1112 B |