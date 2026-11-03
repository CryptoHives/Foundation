| Description                                   | TestDataSize | Mean           | Error       | StdDev      | Code Size | Allocated |
|---------------------------------------------- |------------- |---------------:|------------:|------------:|----------:|----------:|
| Decrypt · Kalyna-256-CBC (CryptoHives-Scalar) | 128B         |     1,452.8 ns |     1.92 ns |     1.80 ns |   1,409 B |         - |
| Decrypt · Kalyna-256-CBC (BouncyCastle)       | 128B         |     3,609.6 ns |     6.54 ns |     6.12 ns |   2,911 B |    1112 B |
|                                               |              |                |             |             |           |           |
| Encrypt · Kalyna-256-CBC (CryptoHives-Scalar) | 128B         |       638.5 ns |     1.32 ns |     1.24 ns |   1,411 B |         - |
| Encrypt · Kalyna-256-CBC (BouncyCastle)       | 128B         |     2,001.5 ns |     8.47 ns |     7.92 ns |   2,909 B |    1112 B |
|                                               |              |                |             |             |           |           |
| Decrypt · Kalyna-256-CBC (CryptoHives-Scalar) | 1KB          |    10,307.4 ns |    13.73 ns |    12.84 ns |   1,409 B |         - |
| Decrypt · Kalyna-256-CBC (BouncyCastle)       | 1KB          |    22,573.2 ns |    51.03 ns |    45.24 ns |   2,911 B |    1112 B |
|                                               |              |                |             |             |           |           |
| Encrypt · Kalyna-256-CBC (CryptoHives-Scalar) | 1KB          |     4,474.0 ns |    10.56 ns |     9.88 ns |   1,411 B |         - |
| Encrypt · Kalyna-256-CBC (BouncyCastle)       | 1KB          |    10,977.9 ns |    17.66 ns |    15.65 ns |   2,909 B |    1112 B |
|                                               |              |                |             |             |           |           |
| Decrypt · Kalyna-256-CBC (CryptoHives-Scalar) | 8KB          |    80,731.0 ns |   144.21 ns |   134.89 ns |   1,409 B |         - |
| Decrypt · Kalyna-256-CBC (BouncyCastle)       | 8KB          |   175,203.0 ns |   268.93 ns |   251.55 ns |   2,909 B |    1112 B |
|                                               |              |                |             |             |           |           |
| Encrypt · Kalyna-256-CBC (CryptoHives-Scalar) | 8KB          |    35,166.2 ns |    56.94 ns |    50.48 ns |   1,411 B |         - |
| Encrypt · Kalyna-256-CBC (BouncyCastle)       | 8KB          |    82,688.5 ns |   124.16 ns |   110.06 ns |   2,909 B |    1112 B |
|                                               |              |                |             |             |           |           |
| Decrypt · Kalyna-256-CBC (CryptoHives-Scalar) | 128KB        | 1,291,702.8 ns | 1,191.49 ns | 1,114.52 ns |   1,409 B |         - |
| Decrypt · Kalyna-256-CBC (BouncyCastle)       | 128KB        | 2,790,809.5 ns | 4,033.58 ns | 3,773.01 ns |   2,911 B |    1112 B |
|                                               |              |                |             |             |           |           |
| Encrypt · Kalyna-256-CBC (CryptoHives-Scalar) | 128KB        |   561,160.8 ns | 1,462.34 ns | 1,296.33 ns |   1,411 B |         - |
| Encrypt · Kalyna-256-CBC (BouncyCastle)       | 128KB        | 1,316,659.8 ns | 2,986.08 ns | 2,647.08 ns |   2,911 B |    1112 B |