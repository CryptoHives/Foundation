| Description                                   | TestDataSize | Mean           | Error     | StdDev    | Allocated |
|---------------------------------------------- |------------- |---------------:|----------:|----------:|----------:|
| Decrypt · Kalyna-128-CBC (CryptoHives-Scalar) | 128B         |       798.3 ns |   0.52 ns |   0.48 ns |         - |
| Decrypt · Kalyna-128-CBC (BouncyCastle)       | 128B         |     2,414.8 ns |   1.11 ns |   1.04 ns |     872 B |
|                                               |              |                |           |           |           |
| Encrypt · Kalyna-128-CBC (CryptoHives-Scalar) | 128B         |       403.8 ns |   0.36 ns |   0.34 ns |         - |
| Encrypt · Kalyna-128-CBC (BouncyCastle)       | 128B         |     1,266.2 ns |   0.48 ns |   0.42 ns |     872 B |
|                                               |              |                |           |           |           |
| Decrypt · Kalyna-128-CBC (CryptoHives-Scalar) | 1KB          |     5,658.3 ns |   4.04 ns |   3.78 ns |         - |
| Decrypt · Kalyna-128-CBC (BouncyCastle)       | 1KB          |    15,384.8 ns |   7.81 ns |   6.92 ns |     872 B |
|                                               |              |                |           |           |           |
| Encrypt · Kalyna-128-CBC (CryptoHives-Scalar) | 1KB          |     2,914.6 ns |   7.31 ns |   6.83 ns |         - |
| Encrypt · Kalyna-128-CBC (BouncyCastle)       | 1KB          |     7,175.8 ns |   4.62 ns |   4.32 ns |     872 B |
|                                               |              |                |           |           |           |
| Decrypt · Kalyna-128-CBC (CryptoHives-Scalar) | 8KB          |    44,498.4 ns |  21.83 ns |  20.42 ns |         - |
| Decrypt · Kalyna-128-CBC (BouncyCastle)       | 8KB          |   118,897.6 ns |  40.72 ns |  36.10 ns |     872 B |
|                                               |              |                |           |           |           |
| Encrypt · Kalyna-128-CBC (CryptoHives-Scalar) | 8KB          |    23,048.0 ns |  35.53 ns |  33.23 ns |         - |
| Encrypt · Kalyna-128-CBC (BouncyCastle)       | 8KB          |    54,157.0 ns |  54.87 ns |  51.32 ns |     872 B |
|                                               |              |                |           |           |           |
| Decrypt · Kalyna-128-CBC (CryptoHives-Scalar) | 128KB        |   710,804.9 ns | 326.17 ns | 305.10 ns |         - |
| Decrypt · Kalyna-128-CBC (BouncyCastle)       | 128KB        | 1,895,526.2 ns | 429.38 ns | 401.64 ns |     872 B |
|                                               |              |                |           |           |           |
| Encrypt · Kalyna-128-CBC (CryptoHives-Scalar) | 128KB        |   368,934.4 ns | 219.40 ns | 205.23 ns |         - |
| Encrypt · Kalyna-128-CBC (BouncyCastle)       | 128KB        |   862,475.7 ns | 813.47 ns | 760.92 ns |     872 B |