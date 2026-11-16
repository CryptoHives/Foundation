| Description                                     | TestDataSize | Mean         | Error       | StdDev      | Code Size | Allocated |
|------------------------------------------------ |------------- |-------------:|------------:|------------:|----------:|----------:|
| Decrypt · Camellia-128-CBC (CryptoHives-Scalar) | 128B         |     691.4 ns |     1.31 ns |     1.22 ns |   1,289 B |         - |
| Decrypt · Camellia-128-CBC (BouncyCastle)       | 128B         |   1,148.1 ns |     3.07 ns |     2.87 ns |   2,913 B |     576 B |
|                                                 |              |              |             |             |           |           |
| Encrypt · Camellia-128-CBC (CryptoHives-Scalar) | 128B         |     724.6 ns |     2.08 ns |     1.94 ns |   1,291 B |         - |
| Encrypt · Camellia-128-CBC (BouncyCastle)       | 128B         |   1,133.7 ns |     2.95 ns |     2.76 ns |   2,911 B |     576 B |
|                                                 |              |              |             |             |           |           |
| Decrypt · Camellia-128-CBC (CryptoHives-Scalar) | 1KB          |   4,873.7 ns |    10.78 ns |     9.56 ns |   1,289 B |         - |
| Decrypt · Camellia-128-CBC (BouncyCastle)       | 1KB          |   7,707.2 ns |    20.63 ns |    18.29 ns |   2,913 B |    2816 B |
|                                                 |              |              |             |             |           |           |
| Encrypt · Camellia-128-CBC (CryptoHives-Scalar) | 1KB          |   4,959.4 ns |    14.87 ns |    13.18 ns |   1,291 B |         - |
| Encrypt · Camellia-128-CBC (BouncyCastle)       | 1KB          |   7,634.6 ns |    15.96 ns |    14.15 ns |   2,911 B |    2816 B |
|                                                 |              |              |             |             |           |           |
| Decrypt · Camellia-128-CBC (CryptoHives-Scalar) | 8KB          |  38,378.2 ns |    83.36 ns |    69.61 ns |   1,289 B |         - |
| Decrypt · Camellia-128-CBC (BouncyCastle)       | 8KB          |  59,904.8 ns |   165.65 ns |   146.84 ns |   2,911 B |   20736 B |
|                                                 |              |              |             |             |           |           |
| Encrypt · Camellia-128-CBC (CryptoHives-Scalar) | 8KB          |  39,551.1 ns |    82.57 ns |    77.23 ns |   1,291 B |         - |
| Encrypt · Camellia-128-CBC (BouncyCastle)       | 8KB          |  59,451.6 ns |   457.59 ns |   382.10 ns |   2,911 B |   20736 B |
|                                                 |              |              |             |             |           |           |
| Decrypt · Camellia-128-CBC (CryptoHives-Scalar) | 128KB        | 604,527.1 ns | 1,035.37 ns |   917.83 ns |   1,289 B |         - |
| Decrypt · Camellia-128-CBC (BouncyCastle)       | 128KB        | 961,114.2 ns | 2,658.28 ns | 2,486.56 ns |   2,911 B |  327936 B |
|                                                 |              |              |             |             |           |           |
| Encrypt · Camellia-128-CBC (CryptoHives-Scalar) | 128KB        | 623,531.9 ns | 1,301.08 ns | 1,153.37 ns |   1,285 B |         - |
| Encrypt · Camellia-128-CBC (BouncyCastle)       | 128KB        | 949,267.5 ns | 3,306.97 ns | 2,931.54 ns |   2,911 B |  327936 B |