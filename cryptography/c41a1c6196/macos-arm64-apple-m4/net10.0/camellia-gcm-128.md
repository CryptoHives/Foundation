| Description                                       | TestDataSize | Mean           | Error       | StdDev      | Allocated |
|-------------------------------------------------- |------------- |---------------:|------------:|------------:|----------:|
| Decrypt · Camellia-128-GCM (CryptoHives-ArmPmull) | 128B         |       871.4 ns |     3.11 ns |     2.91 ns |         - |
| Decrypt · Camellia-128-GCM (CryptoHives-Scalar)   | 128B         |     1,331.3 ns |     3.26 ns |     3.05 ns |         - |
| Decrypt · Camellia-128-GCM (BouncyCastle)         | 128B         |     1,339.9 ns |     3.99 ns |     3.73 ns |    1320 B |
|                                                   |              |                |             |             |           |
| Encrypt · Camellia-128-GCM (CryptoHives-ArmPmull) | 128B         |       830.8 ns |     2.61 ns |     2.44 ns |         - |
| Encrypt · Camellia-128-GCM (BouncyCastle)         | 128B         |     1,280.0 ns |     5.54 ns |     5.18 ns |    1304 B |
| Encrypt · Camellia-128-GCM (CryptoHives-Scalar)   | 128B         |     1,299.0 ns |     6.33 ns |     5.92 ns |         - |
|                                                   |              |                |             |             |           |
| Decrypt · Camellia-128-GCM (CryptoHives-ArmPmull) | 1KB          |     5,974.4 ns |    23.18 ns |    21.68 ns |         - |
| Decrypt · Camellia-128-GCM (BouncyCastle)         | 1KB          |     7,335.7 ns |    17.44 ns |    16.31 ns |    3560 B |
| Decrypt · Camellia-128-GCM (CryptoHives-Scalar)   | 1KB          |     9,038.5 ns |    39.44 ns |    36.89 ns |         - |
|                                                   |              |                |             |             |           |
| Encrypt · Camellia-128-GCM (CryptoHives-ArmPmull) | 1KB          |     5,939.5 ns |    20.71 ns |    19.38 ns |         - |
| Encrypt · Camellia-128-GCM (BouncyCastle)         | 1KB          |     7,515.6 ns |    15.56 ns |    14.55 ns |    3544 B |
| Encrypt · Camellia-128-GCM (CryptoHives-Scalar)   | 1KB          |     8,998.6 ns |    35.25 ns |    32.97 ns |         - |
|                                                   |              |                |             |             |           |
| Decrypt · Camellia-128-GCM (CryptoHives-ArmPmull) | 8KB          |    46,880.2 ns |    89.37 ns |    79.22 ns |         - |
| Decrypt · Camellia-128-GCM (BouncyCastle)         | 8KB          |    55,486.4 ns |   120.96 ns |   113.15 ns |   21480 B |
| Decrypt · Camellia-128-GCM (CryptoHives-Scalar)   | 8KB          |    74,590.8 ns |   415.21 ns |   388.38 ns |         - |
|                                                   |              |                |             |             |           |
| Encrypt · Camellia-128-GCM (CryptoHives-ArmPmull) | 8KB          |    46,903.6 ns |   141.60 ns |   132.45 ns |         - |
| Encrypt · Camellia-128-GCM (BouncyCastle)         | 8KB          |    56,678.4 ns |   162.39 ns |   143.95 ns |   21464 B |
| Encrypt · Camellia-128-GCM (CryptoHives-Scalar)   | 8KB          |    70,526.9 ns |   296.56 ns |   277.40 ns |         - |
|                                                   |              |                |             |             |           |
| Decrypt · Camellia-128-GCM (CryptoHives-ArmPmull) | 128KB        |   755,152.8 ns | 4,420.91 ns | 3,919.02 ns |         - |
| Decrypt · Camellia-128-GCM (BouncyCastle)         | 128KB        |   875,233.8 ns | 1,935.11 ns | 1,810.11 ns |  328680 B |
| Decrypt · Camellia-128-GCM (CryptoHives-Scalar)   | 128KB        | 1,138,051.9 ns | 3,865.73 ns | 3,616.00 ns |         - |
|                                                   |              |                |             |             |           |
| Encrypt · Camellia-128-GCM (CryptoHives-ArmPmull) | 128KB        |   749,126.2 ns | 3,268.60 ns | 2,729.43 ns |         - |
| Encrypt · Camellia-128-GCM (BouncyCastle)         | 128KB        |   894,784.0 ns | 2,279.45 ns | 2,020.67 ns |  328664 B |
| Encrypt · Camellia-128-GCM (CryptoHives-Scalar)   | 128KB        | 1,126,068.0 ns | 5,228.25 ns | 4,890.51 ns |         - |