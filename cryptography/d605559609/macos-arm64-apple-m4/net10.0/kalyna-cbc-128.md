| Description                                   | TestDataSize | Mean           | Error        | StdDev       | Median         | Allocated |
|---------------------------------------------- |------------- |---------------:|-------------:|-------------:|---------------:|----------:|
| Decrypt · Kalyna-128-CBC (CryptoHives-Scalar) | 128B         |       799.0 ns |      0.11 ns |      0.09 ns |       799.0 ns |         - |
| Decrypt · Kalyna-128-CBC (BouncyCastle)       | 128B         |     2,411.7 ns |      0.98 ns |      0.82 ns |     2,411.7 ns |     872 B |
|                                               |              |                |              |              |                |           |
| Encrypt · Kalyna-128-CBC (CryptoHives-Scalar) | 128B         |     1,909.1 ns |      1.38 ns |      1.15 ns |     1,908.9 ns |         - |
| Encrypt · Kalyna-128-CBC (BouncyCastle)       | 128B         |     5,999.0 ns |      3.51 ns |      3.11 ns |     5,997.9 ns |     872 B |
|                                               |              |                |              |              |                |           |
| Decrypt · Kalyna-128-CBC (CryptoHives-Scalar) | 1KB          |     5,653.2 ns |      1.26 ns |      1.11 ns |     5,652.9 ns |         - |
| Decrypt · Kalyna-128-CBC (BouncyCastle)       | 1KB          |    15,377.5 ns |      5.15 ns |      4.30 ns |    15,378.2 ns |     872 B |
|                                               |              |                |              |              |                |           |
| Encrypt · Kalyna-128-CBC (CryptoHives-Scalar) | 1KB          |     2,934.4 ns |     45.88 ns |     77.91 ns |     2,895.8 ns |         - |
| Encrypt · Kalyna-128-CBC (BouncyCastle)       | 1KB          |     7,136.9 ns |     18.55 ns |     17.35 ns |     7,138.2 ns |     872 B |
|                                               |              |                |              |              |                |           |
| Decrypt · Kalyna-128-CBC (CryptoHives-Scalar) | 8KB          |    44,527.8 ns |      4.89 ns |      4.08 ns |    44,528.3 ns |         - |
| Decrypt · Kalyna-128-CBC (BouncyCastle)       | 8KB          |   118,980.6 ns |     15.16 ns |     12.66 ns |   118,977.5 ns |     872 B |
|                                               |              |                |              |              |                |           |
| Encrypt · Kalyna-128-CBC (CryptoHives-Scalar) | 8KB          |    23,033.3 ns |     30.58 ns |     27.11 ns |    23,035.3 ns |         - |
| Encrypt · Kalyna-128-CBC (BouncyCastle)       | 8KB          |    54,872.6 ns |    467.33 ns |    437.14 ns |    54,537.2 ns |     872 B |
|                                               |              |                |              |              |                |           |
| Decrypt · Kalyna-128-CBC (CryptoHives-Scalar) | 128KB        |   711,752.9 ns |    124.32 ns |    110.21 ns |   711,767.5 ns |         - |
| Decrypt · Kalyna-128-CBC (BouncyCastle)       | 128KB        | 2,028,905.4 ns | 39,828.74 ns | 31,095.66 ns | 2,042,555.5 ns |     872 B |
|                                               |              |                |              |              |                |           |
| Encrypt · Kalyna-128-CBC (CryptoHives-Scalar) | 128KB        |   369,324.7 ns |    168.48 ns |    149.35 ns |   369,319.9 ns |         - |
| Encrypt · Kalyna-128-CBC (BouncyCastle)       | 128KB        |   865,466.1 ns |    121.29 ns |    107.52 ns |   865,501.4 ns |     872 B |