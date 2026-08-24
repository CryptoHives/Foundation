| Description                                   | TestDataSize | Mean           | Error     | StdDev    | Allocated |
|---------------------------------------------- |------------- |---------------:|----------:|----------:|----------:|
| Decrypt · Kalyna-256-CBC (CryptoHives-Scalar) | 128B         |     1,126.0 ns |   0.23 ns |   0.22 ns |         - |
| Decrypt · Kalyna-256-CBC (BouncyCastle)       | 128B         |     3,296.7 ns |   0.74 ns |   0.65 ns |    1112 B |
|                                               |              |                |           |           |           |
| Encrypt · Kalyna-256-CBC (CryptoHives-Scalar) | 128B         |       554.8 ns |   0.58 ns |   0.48 ns |         - |
| Encrypt · Kalyna-256-CBC (BouncyCastle)       | 128B         |     1,715.2 ns |   1.28 ns |   1.00 ns |    1112 B |
|                                               |              |                |           |           |           |
| Decrypt · Kalyna-256-CBC (CryptoHives-Scalar) | 1KB          |     8,033.6 ns |   2.14 ns |   1.67 ns |         - |
| Decrypt · Kalyna-256-CBC (BouncyCastle)       | 1KB          |    21,166.8 ns |   4.90 ns |   4.34 ns |    1112 B |
|                                               |              |                |           |           |           |
| Encrypt · Kalyna-256-CBC (CryptoHives-Scalar) | 1KB          |     4,014.0 ns |   1.58 ns |   1.40 ns |         - |
| Encrypt · Kalyna-256-CBC (BouncyCastle)       | 1KB          |     9,805.8 ns |   4.29 ns |   3.58 ns |    1112 B |
|                                               |              |                |           |           |           |
| Decrypt · Kalyna-256-CBC (CryptoHives-Scalar) | 8KB          |    63,287.7 ns |   9.97 ns |   9.33 ns |         - |
| Decrypt · Kalyna-256-CBC (BouncyCastle)       | 8KB          |   163,948.2 ns |  37.27 ns |  34.86 ns |    1112 B |
|                                               |              |                |           |           |           |
| Encrypt · Kalyna-256-CBC (CryptoHives-Scalar) | 8KB          |    31,668.4 ns |  18.63 ns |  16.52 ns |         - |
| Encrypt · Kalyna-256-CBC (BouncyCastle)       | 8KB          |    74,417.6 ns |  33.19 ns |  29.42 ns |    1112 B |
|                                               |              |                |           |           |           |
| Decrypt · Kalyna-256-CBC (CryptoHives-Scalar) | 128KB        | 1,011,627.7 ns | 193.22 ns | 171.28 ns |         - |
| Decrypt · Kalyna-256-CBC (BouncyCastle)       | 128KB        | 2,611,998.7 ns | 439.55 ns | 389.65 ns |    1112 B |
|                                               |              |                |           |           |           |
| Encrypt · Kalyna-256-CBC (CryptoHives-Scalar) | 128KB        |   506,128.6 ns | 166.95 ns | 156.16 ns |         - |
| Encrypt · Kalyna-256-CBC (BouncyCastle)       | 128KB        | 1,185,565.4 ns | 220.35 ns | 195.34 ns |    1112 B |