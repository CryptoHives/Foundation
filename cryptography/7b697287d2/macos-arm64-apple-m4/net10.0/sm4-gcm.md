| Description                              | TestDataSize | Mean           | Error       | StdDev      | Allocated |
|----------------------------------------- |------------- |---------------:|------------:|------------:|----------:|
| Decrypt · SM4-GCM (CryptoHives-ArmPmull) | 128B         |       857.9 ns |     2.55 ns |     2.38 ns |         - |
| Decrypt · SM4-GCM (CryptoHives-Scalar)   | 128B         |     1,337.2 ns |     7.80 ns |     6.52 ns |         - |
| Decrypt · SM4-GCM (BouncyCastle)         | 128B         |     1,770.5 ns |     3.19 ns |     2.98 ns |     744 B |
|                                          |              |                |             |             |           |
| Encrypt · SM4-GCM (CryptoHives-ArmPmull) | 128B         |       811.2 ns |     2.97 ns |     2.78 ns |         - |
| Encrypt · SM4-GCM (CryptoHives-Scalar)   | 128B         |     1,281.7 ns |     5.93 ns |     5.54 ns |         - |
| Encrypt · SM4-GCM (BouncyCastle)         | 128B         |     1,717.6 ns |     3.62 ns |     3.39 ns |     728 B |
|                                          |              |                |             |             |           |
| Decrypt · SM4-GCM (CryptoHives-ArmPmull) | 1KB          |     5,850.6 ns |    21.09 ns |    19.73 ns |         - |
| Decrypt · SM4-GCM (CryptoHives-Scalar)   | 1KB          |     9,036.8 ns |    37.57 ns |    35.14 ns |         - |
| Decrypt · SM4-GCM (BouncyCastle)         | 1KB          |     9,994.1 ns |    40.34 ns |    37.73 ns |     744 B |
|                                          |              |                |             |             |           |
| Encrypt · SM4-GCM (CryptoHives-ArmPmull) | 1KB          |     5,803.8 ns |    28.23 ns |    26.41 ns |         - |
| Encrypt · SM4-GCM (CryptoHives-Scalar)   | 1KB          |     8,921.2 ns |    31.94 ns |    29.88 ns |         - |
| Encrypt · SM4-GCM (BouncyCastle)         | 1KB          |     9,982.9 ns |    54.29 ns |    50.79 ns |     728 B |
|                                          |              |                |             |             |           |
| Decrypt · SM4-GCM (CryptoHives-ArmPmull) | 8KB          |    45,694.8 ns |   180.12 ns |   168.49 ns |         - |
| Decrypt · SM4-GCM (CryptoHives-Scalar)   | 8KB          |    69,905.5 ns |   266.34 ns |   249.14 ns |         - |
| Decrypt · SM4-GCM (BouncyCastle)         | 8KB          |    75,386.2 ns |   406.71 ns |   380.44 ns |     744 B |
|                                          |              |                |             |             |           |
| Encrypt · SM4-GCM (CryptoHives-ArmPmull) | 8KB          |    45,660.3 ns |   243.37 ns |   227.65 ns |         - |
| Encrypt · SM4-GCM (CryptoHives-Scalar)   | 8KB          |    69,883.2 ns |   233.71 ns |   218.61 ns |         - |
| Encrypt · SM4-GCM (BouncyCastle)         | 8KB          |    75,602.1 ns |   290.53 ns |   271.76 ns |     728 B |
|                                          |              |                |             |             |           |
| Decrypt · SM4-GCM (CryptoHives-ArmPmull) | 128KB        |   729,879.9 ns | 1,971.81 ns | 1,844.43 ns |         - |
| Decrypt · SM4-GCM (CryptoHives-Scalar)   | 128KB        | 1,115,805.3 ns | 3,949.92 ns | 3,694.76 ns |         - |
| Decrypt · SM4-GCM (BouncyCastle)         | 128KB        | 1,197,901.7 ns | 6,457.65 ns | 5,724.54 ns |     744 B |
|                                          |              |                |             |             |           |
| Encrypt · SM4-GCM (CryptoHives-ArmPmull) | 128KB        |   729,972.0 ns | 3,640.40 ns | 3,405.23 ns |         - |
| Encrypt · SM4-GCM (CryptoHives-Scalar)   | 128KB        | 1,113,336.5 ns | 3,885.21 ns | 3,444.13 ns |         - |
| Encrypt · SM4-GCM (BouncyCastle)         | 128KB        | 1,199,968.3 ns | 6,718.26 ns | 6,284.26 ns |     728 B |