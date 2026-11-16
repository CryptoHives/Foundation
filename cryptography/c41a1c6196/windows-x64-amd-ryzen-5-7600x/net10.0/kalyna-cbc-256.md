| Description                                   | TestDataSize | Mean           | Error        | StdDev       | Code Size | Allocated |
|---------------------------------------------- |------------- |---------------:|-------------:|-------------:|----------:|----------:|
| Decrypt · Kalyna-256-CBC (CryptoHives-Scalar) | 128B         |     1,462.2 ns |     13.58 ns |     12.70 ns |   1,409 B |         - |
| Decrypt · Kalyna-256-CBC (BouncyCastle)       | 128B         |     3,697.3 ns |     48.49 ns |     45.36 ns |   2,911 B |    1112 B |
|                                               |              |                |              |              |           |           |
| Encrypt · Kalyna-256-CBC (CryptoHives-Scalar) | 128B         |       650.1 ns |      6.03 ns |      5.64 ns |   1,411 B |         - |
| Encrypt · Kalyna-256-CBC (BouncyCastle)       | 128B         |     2,031.9 ns |     24.29 ns |     22.72 ns |   2,909 B |    1112 B |
|                                               |              |                |              |              |           |           |
| Decrypt · Kalyna-256-CBC (CryptoHives-Scalar) | 1KB          |    10,428.7 ns |     72.76 ns |     68.06 ns |   1,409 B |         - |
| Decrypt · Kalyna-256-CBC (BouncyCastle)       | 1KB          |    23,121.2 ns |    255.45 ns |    238.95 ns |   2,911 B |    1112 B |
|                                               |              |                |              |              |           |           |
| Encrypt · Kalyna-256-CBC (CryptoHives-Scalar) | 1KB          |     4,550.7 ns |     31.27 ns |     29.25 ns |   1,411 B |         - |
| Encrypt · Kalyna-256-CBC (BouncyCastle)       | 1KB          |    11,213.4 ns |     94.43 ns |     88.33 ns |   2,909 B |    1112 B |
|                                               |              |                |              |              |           |           |
| Decrypt · Kalyna-256-CBC (CryptoHives-Scalar) | 8KB          |    82,118.3 ns |    738.19 ns |    690.50 ns |   1,409 B |         - |
| Decrypt · Kalyna-256-CBC (BouncyCastle)       | 8KB          |   179,544.1 ns |  3,023.59 ns |  2,524.84 ns |   2,909 B |    1112 B |
|                                               |              |                |              |              |           |           |
| Encrypt · Kalyna-256-CBC (CryptoHives-Scalar) | 8KB          |    35,844.2 ns |    357.00 ns |    333.94 ns |   1,411 B |         - |
| Encrypt · Kalyna-256-CBC (BouncyCastle)       | 8KB          |    84,161.8 ns |    736.20 ns |    688.64 ns |   2,909 B |    1112 B |
|                                               |              |                |              |              |           |           |
| Decrypt · Kalyna-256-CBC (CryptoHives-Scalar) | 128KB        | 1,310,206.3 ns | 12,491.43 ns | 11,684.49 ns |   1,409 B |         - |
| Decrypt · Kalyna-256-CBC (BouncyCastle)       | 128KB        | 2,844,162.2 ns | 25,852.53 ns | 24,182.47 ns |   2,911 B |    1112 B |
|                                               |              |                |              |              |           |           |
| Encrypt · Kalyna-256-CBC (CryptoHives-Scalar) | 128KB        |   572,834.6 ns |  3,351.55 ns |  3,135.04 ns |   1,411 B |         - |
| Encrypt · Kalyna-256-CBC (BouncyCastle)       | 128KB        | 1,339,009.5 ns | 13,199.68 ns | 12,346.99 ns |   2,911 B |    1112 B |