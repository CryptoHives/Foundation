| Description                                   | TestDataSize | Mean           | Error       | StdDev      | Allocated |
|---------------------------------------------- |------------- |---------------:|------------:|------------:|----------:|
| Decrypt · ARIA-128-GCM (CryptoHives-ArmPmull) | 128B         |       909.1 ns |     0.77 ns |     0.72 ns |         - |
| Decrypt · ARIA-128-GCM (CryptoHives-Scalar)   | 128B         |     1,381.4 ns |     1.60 ns |     1.50 ns |         - |
| Decrypt · ARIA-128-GCM (BouncyCastle)         | 128B         |     2,303.7 ns |     9.71 ns |     9.08 ns |    1952 B |
|                                               |              |                |             |             |           |
| Encrypt · ARIA-128-GCM (CryptoHives-ArmPmull) | 128B         |       875.0 ns |     0.59 ns |     0.56 ns |         - |
| Encrypt · ARIA-128-GCM (CryptoHives-Scalar)   | 128B         |     1,320.0 ns |     2.57 ns |     2.41 ns |         - |
| Encrypt · ARIA-128-GCM (BouncyCastle)         | 128B         |     2,224.2 ns |     4.10 ns |     3.63 ns |    1936 B |
|                                               |              |                |             |             |           |
| Decrypt · ARIA-128-GCM (CryptoHives-ArmPmull) | 1KB          |     6,231.0 ns |     5.59 ns |     5.23 ns |         - |
| Decrypt · ARIA-128-GCM (CryptoHives-Scalar)   | 1KB          |     9,784.4 ns |    38.99 ns |    36.48 ns |         - |
| Decrypt · ARIA-128-GCM (BouncyCastle)         | 1KB          |    12,850.6 ns |    29.06 ns |    27.18 ns |    4192 B |
|                                               |              |                |             |             |           |
| Encrypt · ARIA-128-GCM (CryptoHives-ArmPmull) | 1KB          |     6,194.5 ns |     7.99 ns |     7.48 ns |         - |
| Encrypt · ARIA-128-GCM (CryptoHives-Scalar)   | 1KB          |     9,750.4 ns |   183.07 ns |   195.88 ns |         - |
| Encrypt · ARIA-128-GCM (BouncyCastle)         | 1KB          |    12,862.3 ns |    13.56 ns |    10.58 ns |    4176 B |
|                                               |              |                |             |             |           |
| Decrypt · ARIA-128-GCM (CryptoHives-ArmPmull) | 8KB          |    48,894.0 ns |    74.72 ns |    69.89 ns |         - |
| Decrypt · ARIA-128-GCM (CryptoHives-Scalar)   | 8KB          |    75,706.3 ns |   817.54 ns |   764.73 ns |         - |
| Decrypt · ARIA-128-GCM (BouncyCastle)         | 8KB          |    96,803.7 ns |   198.03 ns |   185.24 ns |   22112 B |
|                                               |              |                |             |             |           |
| Encrypt · ARIA-128-GCM (CryptoHives-ArmPmull) | 8KB          |    48,839.2 ns |   103.06 ns |    96.40 ns |         - |
| Encrypt · ARIA-128-GCM (CryptoHives-Scalar)   | 8KB          |    76,047.1 ns |   587.33 ns |   520.65 ns |         - |
| Encrypt · ARIA-128-GCM (BouncyCastle)         | 8KB          |    97,985.8 ns |   186.94 ns |   156.11 ns |   22096 B |
|                                               |              |                |             |             |           |
| Decrypt · ARIA-128-GCM (CryptoHives-ArmPmull) | 128KB        |   777,884.5 ns | 1,076.35 ns | 1,006.81 ns |         - |
| Decrypt · ARIA-128-GCM (CryptoHives-Scalar)   | 128KB        | 1,194,386.6 ns | 3,827.42 ns | 3,580.17 ns |         - |
| Decrypt · ARIA-128-GCM (BouncyCastle)         | 128KB        | 1,539,823.2 ns | 3,427.04 ns | 3,037.98 ns |  329312 B |
|                                               |              |                |             |             |           |
| Encrypt · ARIA-128-GCM (CryptoHives-ArmPmull) | 128KB        |   778,667.3 ns |   870.88 ns |   814.62 ns |         - |
| Encrypt · ARIA-128-GCM (CryptoHives-Scalar)   | 128KB        | 1,189,421.7 ns | 4,619.99 ns | 4,321.54 ns |         - |
| Encrypt · ARIA-128-GCM (BouncyCastle)         | 128KB        | 1,560,735.3 ns | 2,428.27 ns | 2,152.60 ns |  329296 B |