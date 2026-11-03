| Description                                   | TestDataSize | Mean           | Error       | StdDev      | Allocated |
|---------------------------------------------- |------------- |---------------:|------------:|------------:|----------:|
| Decrypt · ARIA-128-GCM (CryptoHives-ArmPmull) | 128B         |       907.6 ns |     3.34 ns |     3.12 ns |         - |
| Decrypt · ARIA-128-GCM (CryptoHives-Scalar)   | 128B         |     1,380.4 ns |     5.38 ns |     5.04 ns |         - |
| Decrypt · ARIA-128-GCM (BouncyCastle)         | 128B         |     2,552.1 ns |    13.50 ns |    12.63 ns |    1952 B |
|                                               |              |                |             |             |           |
| Encrypt · ARIA-128-GCM (CryptoHives-ArmPmull) | 128B         |       867.7 ns |     0.53 ns |     0.49 ns |         - |
| Encrypt · ARIA-128-GCM (CryptoHives-Scalar)   | 128B         |     1,311.6 ns |     6.65 ns |     6.22 ns |         - |
| Encrypt · ARIA-128-GCM (BouncyCastle)         | 128B         |     2,482.2 ns |     9.02 ns |     8.44 ns |    1936 B |
|                                               |              |                |             |             |           |
| Decrypt · ARIA-128-GCM (CryptoHives-ArmPmull) | 1KB          |     6,222.4 ns |    25.41 ns |    23.77 ns |         - |
| Decrypt · ARIA-128-GCM (CryptoHives-Scalar)   | 1KB          |     9,365.5 ns |    33.25 ns |    31.10 ns |         - |
| Decrypt · ARIA-128-GCM (BouncyCastle)         | 1KB          |    14,387.2 ns |    63.34 ns |    59.25 ns |    4192 B |
|                                               |              |                |             |             |           |
| Encrypt · ARIA-128-GCM (CryptoHives-ArmPmull) | 1KB          |     6,161.3 ns |     2.40 ns |     2.24 ns |         - |
| Encrypt · ARIA-128-GCM (CryptoHives-Scalar)   | 1KB          |     9,133.8 ns |    50.25 ns |    47.00 ns |         - |
| Encrypt · ARIA-128-GCM (BouncyCastle)         | 1KB          |    14,814.9 ns |    41.66 ns |    38.97 ns |    4176 B |
|                                               |              |                |             |             |           |
| Decrypt · ARIA-128-GCM (CryptoHives-ArmPmull) | 8KB          |    48,738.3 ns |   161.72 ns |   151.27 ns |         - |
| Decrypt · ARIA-128-GCM (CryptoHives-Scalar)   | 8KB          |    73,020.7 ns |   260.71 ns |   243.87 ns |         - |
| Decrypt · ARIA-128-GCM (BouncyCastle)         | 8KB          |   110,240.6 ns |   460.63 ns |   430.88 ns |   22112 B |
|                                               |              |                |             |             |           |
| Encrypt · ARIA-128-GCM (CryptoHives-ArmPmull) | 8KB          |    48,483.6 ns |    15.86 ns |    14.84 ns |         - |
| Encrypt · ARIA-128-GCM (CryptoHives-Scalar)   | 8KB          |    72,307.4 ns |   596.75 ns |   558.20 ns |         - |
| Encrypt · ARIA-128-GCM (BouncyCastle)         | 8KB          |   113,116.4 ns |   394.99 ns |   350.15 ns |   22096 B |
|                                               |              |                |             |             |           |
| Decrypt · ARIA-128-GCM (CryptoHives-ArmPmull) | 128KB        |   776,803.9 ns | 2,503.14 ns | 2,341.44 ns |         - |
| Decrypt · ARIA-128-GCM (CryptoHives-Scalar)   | 128KB        | 1,161,026.1 ns | 2,458.40 ns | 2,299.59 ns |         - |
| Decrypt · ARIA-128-GCM (BouncyCastle)         | 128KB        | 1,752,169.0 ns | 4,738.70 ns | 4,200.74 ns |  329312 B |
|                                               |              |                |             |             |           |
| Encrypt · ARIA-128-GCM (CryptoHives-ArmPmull) | 128KB        |   777,940.5 ns | 2,537.35 ns | 2,373.44 ns |         - |
| Encrypt · ARIA-128-GCM (CryptoHives-Scalar)   | 128KB        | 1,152,394.9 ns | 4,252.02 ns | 3,977.34 ns |         - |
| Encrypt · ARIA-128-GCM (BouncyCastle)         | 128KB        | 1,805,136.8 ns | 5,463.21 ns | 5,110.29 ns |  329296 B |