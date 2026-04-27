| Description                                   | TestDataSize | Mean           | Error        | StdDev       | Allocated |
|---------------------------------------------- |------------- |---------------:|-------------:|-------------:|----------:|
| Decrypt · Kalyna-256-CBC (CryptoHives-Scalar) | 128B         |     1,251.2 ns |      3.77 ns |      3.15 ns |         - |
| Decrypt · Kalyna-256-CBC (BouncyCastle)       | 128B         |     3,170.1 ns |     22.24 ns |     20.80 ns |    1112 B |
|                                               |              |                |              |              |           |
| Encrypt · Kalyna-256-CBC (CryptoHives-Scalar) | 128B         |       538.2 ns |      3.82 ns |      3.39 ns |         - |
| Encrypt · Kalyna-256-CBC (BouncyCastle)       | 128B         |     1,759.1 ns |     11.33 ns |     10.04 ns |    1112 B |
|                                               |              |                |              |              |           |
| Decrypt · Kalyna-256-CBC (CryptoHives-Scalar) | 1KB          |     8,946.5 ns |     47.97 ns |     42.52 ns |         - |
| Decrypt · Kalyna-256-CBC (BouncyCastle)       | 1KB          |    19,582.4 ns |     95.84 ns |     80.03 ns |    1112 B |
|                                               |              |                |              |              |           |
| Encrypt · Kalyna-256-CBC (CryptoHives-Scalar) | 1KB          |     3,790.6 ns |      9.36 ns |      8.75 ns |         - |
| Encrypt · Kalyna-256-CBC (BouncyCastle)       | 1KB          |     9,454.2 ns |     48.34 ns |     45.22 ns |    1112 B |
|                                               |              |                |              |              |           |
| Decrypt · Kalyna-256-CBC (CryptoHives-Scalar) | 8KB          |    74,906.3 ns |    284.29 ns |    265.93 ns |         - |
| Decrypt · Kalyna-256-CBC (BouncyCastle)       | 8KB          |   151,295.3 ns |  1,324.45 ns |  1,238.89 ns |    1112 B |
|                                               |              |                |              |              |           |
| Encrypt · Kalyna-256-CBC (CryptoHives-Scalar) | 8KB          |    29,792.6 ns |     65.27 ns |     61.05 ns |         - |
| Encrypt · Kalyna-256-CBC (BouncyCastle)       | 8KB          |    71,155.1 ns |    358.34 ns |    317.66 ns |    1112 B |
|                                               |              |                |              |              |           |
| Decrypt · Kalyna-256-CBC (CryptoHives-Scalar) | 128KB        | 1,124,427.5 ns |  4,483.91 ns |  3,974.87 ns |         - |
| Decrypt · Kalyna-256-CBC (BouncyCastle)       | 128KB        | 2,401,999.9 ns | 15,429.08 ns | 14,432.37 ns |    1112 B |
|                                               |              |                |              |              |           |
| Encrypt · Kalyna-256-CBC (CryptoHives-Scalar) | 128KB        |   489,780.4 ns |  2,184.52 ns |  1,936.52 ns |         - |
| Encrypt · Kalyna-256-CBC (BouncyCastle)       | 128KB        | 1,127,764.5 ns |  4,344.35 ns |  3,627.73 ns |    1112 B |