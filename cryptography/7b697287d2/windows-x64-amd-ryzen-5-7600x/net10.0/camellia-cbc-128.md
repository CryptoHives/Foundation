| Description                                     | TestDataSize | Mean         | Error       | StdDev      | Code Size | Allocated |
|------------------------------------------------ |------------- |-------------:|------------:|------------:|----------:|----------:|
| Decrypt · Camellia-128-CBC (CryptoHives-Scalar) | 128B         |     698.3 ns |     1.30 ns |     1.15 ns |   1,289 B |         - |
| Decrypt · Camellia-128-CBC (BouncyCastle)       | 128B         |   1,157.9 ns |     3.14 ns |     2.93 ns |   2,913 B |     576 B |
|                                                 |              |              |             |             |           |           |
| Encrypt · Camellia-128-CBC (CryptoHives-Scalar) | 128B         |     727.1 ns |     5.25 ns |     5.83 ns |   1,291 B |         - |
| Encrypt · Camellia-128-CBC (BouncyCastle)       | 128B         |   1,146.7 ns |     3.26 ns |     2.89 ns |   2,911 B |     576 B |
|                                                 |              |              |             |             |           |           |
| Decrypt · Camellia-128-CBC (CryptoHives-Scalar) | 1KB          |   4,850.0 ns |    12.06 ns |    10.69 ns |   1,289 B |         - |
| Decrypt · Camellia-128-CBC (BouncyCastle)       | 1KB          |   7,738.4 ns |    12.76 ns |    11.93 ns |   2,913 B |    2816 B |
|                                                 |              |              |             |             |           |           |
| Encrypt · Camellia-128-CBC (CryptoHives-Scalar) | 1KB          |   4,977.7 ns |    16.04 ns |    15.01 ns |   1,291 B |         - |
| Encrypt · Camellia-128-CBC (BouncyCastle)       | 1KB          |   7,610.3 ns |    11.44 ns |    10.70 ns |   2,911 B |    2816 B |
|                                                 |              |              |             |             |           |           |
| Decrypt · Camellia-128-CBC (CryptoHives-Scalar) | 8KB          |  38,055.4 ns |    50.61 ns |    42.27 ns |   1,289 B |         - |
| Decrypt · Camellia-128-CBC (BouncyCastle)       | 8KB          |  60,196.6 ns |    98.66 ns |    92.29 ns |   2,911 B |   20736 B |
|                                                 |              |              |             |             |           |           |
| Encrypt · Camellia-128-CBC (CryptoHives-Scalar) | 8KB          |  39,584.7 ns |    88.28 ns |    82.58 ns |   1,291 B |         - |
| Encrypt · Camellia-128-CBC (BouncyCastle)       | 8KB          |  59,549.7 ns |   125.25 ns |   117.15 ns |   2,911 B |   20736 B |
|                                                 |              |              |             |             |           |           |
| Decrypt · Camellia-128-CBC (CryptoHives-Scalar) | 128KB        | 607,203.7 ns | 1,601.20 ns | 1,497.76 ns |   1,289 B |         - |
| Decrypt · Camellia-128-CBC (BouncyCastle)       | 128KB        | 959,539.4 ns | 1,473.37 ns | 1,306.11 ns |   2,911 B |  327936 B |
|                                                 |              |              |             |             |           |           |
| Encrypt · Camellia-128-CBC (CryptoHives-Scalar) | 128KB        | 625,841.6 ns | 2,727.42 ns | 2,551.23 ns |   1,291 B |         - |
| Encrypt · Camellia-128-CBC (BouncyCastle)       | 128KB        | 949,263.0 ns | 2,312.33 ns | 2,162.95 ns |   2,911 B |  327936 B |