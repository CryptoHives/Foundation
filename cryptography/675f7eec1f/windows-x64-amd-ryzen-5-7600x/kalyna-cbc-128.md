| Description                                   | TestDataSize | Mean           | Error       | StdDev      | Allocated |
|---------------------------------------------- |------------- |---------------:|------------:|------------:|----------:|
| Decrypt · Kalyna-128-CBC (CryptoHives-Scalar) | 128B         |       934.1 ns |     3.90 ns |     3.65 ns |         - |
| Decrypt · Kalyna-128-CBC (BouncyCastle)       | 128B         |     2,431.5 ns |    22.59 ns |    20.03 ns |     872 B |
|                                               |              |                |             |             |           |
| Encrypt · Kalyna-128-CBC (CryptoHives-Scalar) | 128B         |       402.7 ns |     2.98 ns |     2.79 ns |         - |
| Encrypt · Kalyna-128-CBC (BouncyCastle)       | 128B         |     1,371.8 ns |     9.29 ns |     8.69 ns |     872 B |
|                                               |              |                |             |             |           |
| Decrypt · Kalyna-128-CBC (CryptoHives-Scalar) | 1KB          |     6,642.3 ns |    36.87 ns |    32.69 ns |         - |
| Decrypt · Kalyna-128-CBC (BouncyCastle)       | 1KB          |    14,751.5 ns |    81.57 ns |    72.31 ns |     872 B |
|                                               |              |                |             |             |           |
| Encrypt · Kalyna-128-CBC (CryptoHives-Scalar) | 1KB          |     2,810.4 ns |    19.38 ns |    16.19 ns |         - |
| Encrypt · Kalyna-128-CBC (BouncyCastle)       | 1KB          |     7,200.8 ns |    33.02 ns |    30.88 ns |     872 B |
|                                               |              |                |             |             |           |
| Decrypt · Kalyna-128-CBC (CryptoHives-Scalar) | 8KB          |    52,184.7 ns |   208.99 ns |   185.27 ns |         - |
| Decrypt · Kalyna-128-CBC (BouncyCastle)       | 8KB          |   113,191.6 ns |   749.30 ns |   625.70 ns |     872 B |
|                                               |              |                |             |             |           |
| Encrypt · Kalyna-128-CBC (CryptoHives-Scalar) | 8KB          |    21,961.4 ns |   153.70 ns |   143.77 ns |         - |
| Encrypt · Kalyna-128-CBC (BouncyCastle)       | 8KB          |    53,917.0 ns |   409.46 ns |   383.01 ns |     872 B |
|                                               |              |                |             |             |           |
| Decrypt · Kalyna-128-CBC (CryptoHives-Scalar) | 128KB        |   835,253.2 ns | 4,686.35 ns | 4,383.62 ns |         - |
| Decrypt · Kalyna-128-CBC (BouncyCastle)       | 128KB        | 1,795,131.8 ns | 9,802.31 ns | 9,169.08 ns |     872 B |
|                                               |              |                |             |             |           |
| Encrypt · Kalyna-128-CBC (CryptoHives-Scalar) | 128KB        |   349,980.4 ns | 1,866.71 ns | 1,654.79 ns |         - |
| Encrypt · Kalyna-128-CBC (BouncyCastle)       | 128KB        |   852,680.8 ns | 3,633.26 ns | 3,398.56 ns |     872 B |