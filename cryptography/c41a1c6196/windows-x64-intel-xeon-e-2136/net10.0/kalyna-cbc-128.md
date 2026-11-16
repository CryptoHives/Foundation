| Description                                   | TestDataSize | Mean           | Error        | StdDev       | Code Size | Allocated |
|---------------------------------------------- |------------- |---------------:|-------------:|-------------:|----------:|----------:|
| Decrypt · Kalyna-128-CBC (CryptoHives-Scalar) | 128B         |     1,504.8 ns |      1.63 ns |      1.52 ns |   1,431 B |         - |
| Decrypt · Kalyna-128-CBC (BouncyCastle)       | 128B         |     4,361.7 ns |     15.89 ns |     14.87 ns |   2,937 B |     872 B |
|                                               |              |                |              |              |           |           |
| Encrypt · Kalyna-128-CBC (CryptoHives-Scalar) | 128B         |       671.2 ns |      1.02 ns |      0.95 ns |   1,433 B |         - |
| Encrypt · Kalyna-128-CBC (BouncyCastle)       | 128B         |     2,509.8 ns |     25.84 ns |     24.17 ns |   2,935 B |     872 B |
|                                               |              |                |              |              |           |           |
| Decrypt · Kalyna-128-CBC (CryptoHives-Scalar) | 1KB          |    10,500.4 ns |     12.74 ns |     11.30 ns |   1,431 B |         - |
| Decrypt · Kalyna-128-CBC (BouncyCastle)       | 1KB          |    27,107.1 ns |     48.26 ns |     42.78 ns |   2,937 B |     872 B |
|                                               |              |                |              |              |           |           |
| Encrypt · Kalyna-128-CBC (CryptoHives-Scalar) | 1KB          |     4,571.9 ns |      8.95 ns |      8.37 ns |   1,433 B |         - |
| Encrypt · Kalyna-128-CBC (BouncyCastle)       | 1KB          |    12,850.9 ns |     47.77 ns |     44.68 ns |   2,935 B |     872 B |
|                                               |              |                |              |              |           |           |
| Decrypt · Kalyna-128-CBC (CryptoHives-Scalar) | 8KB          |    82,536.2 ns |    106.90 ns |    100.00 ns |   1,431 B |         - |
| Decrypt · Kalyna-128-CBC (BouncyCastle)       | 8KB          |   211,297.4 ns |    504.30 ns |    421.11 ns |   2,935 B |     872 B |
|                                               |              |                |              |              |           |           |
| Encrypt · Kalyna-128-CBC (CryptoHives-Scalar) | 8KB          |    36,290.8 ns |     37.18 ns |     34.78 ns |   1,433 B |         - |
| Encrypt · Kalyna-128-CBC (BouncyCastle)       | 8KB          |    96,531.1 ns |  1,000.83 ns |    936.18 ns |   2,933 B |     872 B |
|                                               |              |                |              |              |           |           |
| Decrypt · Kalyna-128-CBC (CryptoHives-Scalar) | 128KB        | 1,315,493.1 ns |  2,487.53 ns |  2,205.13 ns |   1,431 B |         - |
| Decrypt · Kalyna-128-CBC (BouncyCastle)       | 128KB        | 3,364,398.2 ns |  7,338.01 ns |  6,863.98 ns |   2,933 B |     872 B |
|                                               |              |                |              |              |           |           |
| Encrypt · Kalyna-128-CBC (CryptoHives-Scalar) | 128KB        |   565,841.3 ns |  1,203.94 ns |  1,126.17 ns |   1,433 B |         - |
| Encrypt · Kalyna-128-CBC (BouncyCastle)       | 128KB        | 1,526,048.1 ns | 12,777.27 ns | 11,951.87 ns |   2,933 B |     872 B |