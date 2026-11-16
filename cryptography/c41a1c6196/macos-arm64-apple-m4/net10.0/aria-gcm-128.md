| Description                                   | TestDataSize | Mean           | Error       | StdDev      | Allocated |
|---------------------------------------------- |------------- |---------------:|------------:|------------:|----------:|
| Decrypt · ARIA-128-GCM (CryptoHives-ArmPmull) | 128B         |       911.9 ns |     0.81 ns |     0.72 ns |         - |
| Decrypt · ARIA-128-GCM (CryptoHives-Scalar)   | 128B         |     1,393.8 ns |     2.28 ns |     2.14 ns |         - |
| Decrypt · ARIA-128-GCM (BouncyCastle)         | 128B         |     2,592.7 ns |    10.18 ns |     9.52 ns |    1952 B |
|                                               |              |                |             |             |           |
| Encrypt · ARIA-128-GCM (CryptoHives-ArmPmull) | 128B         |       871.5 ns |     3.03 ns |     2.83 ns |         - |
| Encrypt · ARIA-128-GCM (CryptoHives-Scalar)   | 128B         |     1,352.8 ns |     2.83 ns |     2.64 ns |         - |
| Encrypt · ARIA-128-GCM (BouncyCastle)         | 128B         |     2,605.7 ns |    10.87 ns |    10.17 ns |    1936 B |
|                                               |              |                |             |             |           |
| Decrypt · ARIA-128-GCM (CryptoHives-ArmPmull) | 1KB          |     6,250.1 ns |     5.87 ns |     5.49 ns |         - |
| Decrypt · ARIA-128-GCM (CryptoHives-Scalar)   | 1KB          |     9,486.5 ns |    18.21 ns |    17.03 ns |         - |
| Decrypt · ARIA-128-GCM (BouncyCastle)         | 1KB          |    14,812.7 ns |    47.59 ns |    44.52 ns |    4192 B |
|                                               |              |                |             |             |           |
| Encrypt · ARIA-128-GCM (CryptoHives-ArmPmull) | 1KB          |     6,203.1 ns |     6.85 ns |     6.07 ns |         - |
| Encrypt · ARIA-128-GCM (CryptoHives-Scalar)   | 1KB          |     9,418.6 ns |    21.41 ns |    20.03 ns |         - |
| Encrypt · ARIA-128-GCM (BouncyCastle)         | 1KB          |    15,097.1 ns |    34.84 ns |    32.59 ns |    4176 B |
|                                               |              |                |             |             |           |
| Decrypt · ARIA-128-GCM (CryptoHives-ArmPmull) | 8KB          |    48,857.3 ns |    68.09 ns |    63.69 ns |         - |
| Decrypt · ARIA-128-GCM (CryptoHives-Scalar)   | 8KB          |    73,940.6 ns |   222.54 ns |   208.16 ns |         - |
| Decrypt · ARIA-128-GCM (BouncyCastle)         | 8KB          |   111,490.3 ns |   199.35 ns |   186.47 ns |   22112 B |
|                                               |              |                |             |             |           |
| Encrypt · ARIA-128-GCM (CryptoHives-ArmPmull) | 8KB          |    48,869.1 ns |    57.41 ns |    53.70 ns |         - |
| Encrypt · ARIA-128-GCM (CryptoHives-Scalar)   | 8KB          |    73,895.9 ns |   271.55 ns |   254.01 ns |         - |
| Encrypt · ARIA-128-GCM (BouncyCastle)         | 8KB          |   114,871.1 ns |   235.47 ns |   220.26 ns |   22096 B |
|                                               |              |                |             |             |           |
| Decrypt · ARIA-128-GCM (CryptoHives-ArmPmull) | 128KB        |   780,242.7 ns |   630.93 ns |   590.18 ns |         - |
| Decrypt · ARIA-128-GCM (CryptoHives-Scalar)   | 128KB        | 1,175,816.2 ns | 2,050.94 ns | 1,918.45 ns |         - |
| Decrypt · ARIA-128-GCM (BouncyCastle)         | 128KB        | 1,778,413.9 ns | 2,077.06 ns | 1,942.89 ns |  329312 B |
|                                               |              |                |             |             |           |
| Encrypt · ARIA-128-GCM (CryptoHives-ArmPmull) | 128KB        |   779,353.8 ns |   665.32 ns |   622.34 ns |         - |
| Encrypt · ARIA-128-GCM (CryptoHives-Scalar)   | 128KB        | 1,175,976.3 ns | 3,311.65 ns | 3,097.72 ns |         - |
| Encrypt · ARIA-128-GCM (BouncyCastle)         | 128KB        | 1,831,620.4 ns | 4,171.40 ns | 3,901.93 ns |  329296 B |