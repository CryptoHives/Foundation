| Description                                   | TestDataSize | Mean           | Error        | StdDev       | Allocated |
|---------------------------------------------- |------------- |---------------:|-------------:|-------------:|----------:|
| Decrypt · Kalyna-128-CBC (CryptoHives-Scalar) | 128B         |     1,079.3 ns |      9.38 ns |      8.77 ns |         - |
| Decrypt · Kalyna-128-CBC (BouncyCastle)       | 128B         |     2,758.0 ns |     54.86 ns |     51.31 ns |     872 B |
|                                               |              |                |              |              |           |
| Encrypt · Kalyna-128-CBC (CryptoHives-Scalar) | 128B         |       469.5 ns |      3.13 ns |      2.62 ns |         - |
| Encrypt · Kalyna-128-CBC (BouncyCastle)       | 128B         |     1,558.2 ns |     13.77 ns |     12.88 ns |     872 B |
|                                               |              |                |              |              |           |
| Decrypt · Kalyna-128-CBC (CryptoHives-Scalar) | 1KB          |     7,674.6 ns |     62.73 ns |     55.61 ns |         - |
| Decrypt · Kalyna-128-CBC (BouncyCastle)       | 1KB          |    16,883.0 ns |    200.41 ns |    187.46 ns |     872 B |
|                                               |              |                |              |              |           |
| Encrypt · Kalyna-128-CBC (CryptoHives-Scalar) | 1KB          |     3,279.1 ns |     33.75 ns |     31.57 ns |         - |
| Encrypt · Kalyna-128-CBC (BouncyCastle)       | 1KB          |     8,343.5 ns |     97.12 ns |     90.84 ns |     872 B |
|                                               |              |                |              |              |           |
| Decrypt · Kalyna-128-CBC (CryptoHives-Scalar) | 8KB          |    60,259.6 ns |    354.08 ns |    331.21 ns |         - |
| Decrypt · Kalyna-128-CBC (BouncyCastle)       | 8KB          |   130,132.2 ns |  1,734.60 ns |  1,622.54 ns |     872 B |
|                                               |              |                |              |              |           |
| Encrypt · Kalyna-128-CBC (CryptoHives-Scalar) | 8KB          |    25,602.0 ns |    285.98 ns |    267.50 ns |         - |
| Encrypt · Kalyna-128-CBC (BouncyCastle)       | 8KB          |    62,586.9 ns |    427.35 ns |    399.75 ns |     872 B |
|                                               |              |                |              |              |           |
| Decrypt · Kalyna-128-CBC (CryptoHives-Scalar) | 128KB        |   964,218.9 ns |  7,919.41 ns |  7,020.35 ns |         - |
| Decrypt · Kalyna-128-CBC (BouncyCastle)       | 128KB        | 2,072,516.4 ns | 27,658.16 ns | 25,871.46 ns |     872 B |
|                                               |              |                |              |              |           |
| Encrypt · Kalyna-128-CBC (CryptoHives-Scalar) | 128KB        |   408,540.2 ns |  4,419.63 ns |  4,134.13 ns |         - |
| Encrypt · Kalyna-128-CBC (BouncyCastle)       | 128KB        |   994,450.6 ns |  8,480.90 ns |  7,933.04 ns |     872 B |