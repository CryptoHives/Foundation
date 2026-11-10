| Description                                   | TestDataSize | Mean           | Error       | StdDev      | Code Size | Allocated |
|---------------------------------------------- |------------- |---------------:|------------:|------------:|----------:|----------:|
| Decrypt · Kalyna-128-CBC (CryptoHives-Scalar) | 128B         |     1,517.9 ns |     1.25 ns |     1.17 ns |   1,431 B |         - |
| Decrypt · Kalyna-128-CBC (BouncyCastle)       | 128B         |     4,396.6 ns |     8.28 ns |     7.34 ns |   2,937 B |     872 B |
|                                               |              |                |             |             |           |           |
| Encrypt · Kalyna-128-CBC (CryptoHives-Scalar) | 128B         |       672.6 ns |     0.91 ns |     0.80 ns |   1,430 B |         - |
| Encrypt · Kalyna-128-CBC (BouncyCastle)       | 128B         |     2,492.0 ns |    12.02 ns |    11.24 ns |   2,935 B |     872 B |
|                                               |              |                |             |             |           |           |
| Decrypt · Kalyna-128-CBC (CryptoHives-Scalar) | 1KB          |    10,598.5 ns |     8.93 ns |     8.35 ns |   1,431 B |         - |
| Decrypt · Kalyna-128-CBC (BouncyCastle)       | 1KB          |    30,321.7 ns |    30.67 ns |    28.69 ns |   2,937 B |     872 B |
|                                               |              |                |             |             |           |           |
| Encrypt · Kalyna-128-CBC (CryptoHives-Scalar) | 1KB          |     4,583.3 ns |     5.64 ns |     5.27 ns |   1,433 B |         - |
| Encrypt · Kalyna-128-CBC (BouncyCastle)       | 1KB          |    12,690.0 ns |    17.03 ns |    15.09 ns |   2,935 B |     872 B |
|                                               |              |                |             |             |           |           |
| Decrypt · Kalyna-128-CBC (CryptoHives-Scalar) | 8KB          |    82,391.7 ns |    64.41 ns |    53.78 ns |   1,431 B |         - |
| Decrypt · Kalyna-128-CBC (BouncyCastle)       | 8KB          |   211,204.3 ns |   282.37 ns |   264.13 ns |   2,935 B |     872 B |
|                                               |              |                |             |             |           |           |
| Encrypt · Kalyna-128-CBC (CryptoHives-Scalar) | 8KB          |    35,626.9 ns |    27.95 ns |    23.34 ns |   1,433 B |         - |
| Encrypt · Kalyna-128-CBC (BouncyCastle)       | 8KB          |    99,375.8 ns |   208.12 ns |   194.68 ns |   2,933 B |     872 B |
|                                               |              |                |             |             |           |           |
| Decrypt · Kalyna-128-CBC (CryptoHives-Scalar) | 128KB        | 1,318,534.1 ns | 1,378.01 ns | 1,288.99 ns |   1,431 B |         - |
| Decrypt · Kalyna-128-CBC (BouncyCastle)       | 128KB        | 3,378,698.2 ns | 6,314.79 ns | 5,597.90 ns |   2,935 B |     872 B |
|                                               |              |                |             |             |           |           |
| Encrypt · Kalyna-128-CBC (CryptoHives-Scalar) | 128KB        |   570,344.6 ns |   402.16 ns |   376.18 ns |   1,433 B |         - |
| Encrypt · Kalyna-128-CBC (BouncyCastle)       | 128KB        | 1,523,939.1 ns | 2,271.53 ns | 2,124.79 ns |   2,933 B |     872 B |