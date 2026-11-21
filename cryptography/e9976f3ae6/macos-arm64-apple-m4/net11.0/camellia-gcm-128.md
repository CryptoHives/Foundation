| Description                                       | TestDataSize | Mean           | Error       | StdDev      | Allocated |
|-------------------------------------------------- |------------- |---------------:|------------:|------------:|----------:|
| Decrypt · Camellia-128-GCM (CryptoHives-ArmPmull) | 128B         |       883.8 ns |     3.23 ns |     3.02 ns |         - |
| Decrypt · Camellia-128-GCM (BouncyCastle)         | 128B         |     1,322.9 ns |     2.01 ns |     1.88 ns |    1320 B |
| Decrypt · Camellia-128-GCM (CryptoHives-Scalar)   | 128B         |     1,412.4 ns |     5.44 ns |     5.09 ns |         - |
|                                                   |              |                |             |             |           |
| Encrypt · Camellia-128-GCM (CryptoHives-ArmPmull) | 128B         |       842.9 ns |     1.30 ns |     1.16 ns |         - |
| Encrypt · Camellia-128-GCM (BouncyCastle)         | 128B         |     1,200.3 ns |     3.76 ns |     3.52 ns |    1304 B |
| Encrypt · Camellia-128-GCM (CryptoHives-Scalar)   | 128B         |     1,325.6 ns |     5.44 ns |     5.09 ns |         - |
|                                                   |              |                |             |             |           |
| Decrypt · Camellia-128-GCM (CryptoHives-ArmPmull) | 1KB          |     6,120.6 ns |    11.40 ns |    10.11 ns |         - |
| Decrypt · Camellia-128-GCM (BouncyCastle)         | 1KB          |     6,918.9 ns |     7.32 ns |     6.85 ns |    3560 B |
| Decrypt · Camellia-128-GCM (CryptoHives-Scalar)   | 1KB          |     9,582.9 ns |    41.89 ns |    39.18 ns |         - |
|                                                   |              |                |             |             |           |
| Encrypt · Camellia-128-GCM (CryptoHives-ArmPmull) | 1KB          |     6,053.4 ns |    15.37 ns |    14.37 ns |         - |
| Encrypt · Camellia-128-GCM (BouncyCastle)         | 1KB          |     7,827.4 ns |    60.67 ns |    56.75 ns |    3544 B |
| Encrypt · Camellia-128-GCM (CryptoHives-Scalar)   | 1KB          |     9,753.5 ns |    48.94 ns |    45.78 ns |         - |
|                                                   |              |                |             |             |           |
| Decrypt · Camellia-128-GCM (CryptoHives-ArmPmull) | 8KB          |    48,191.3 ns |   200.67 ns |   177.89 ns |         - |
| Decrypt · Camellia-128-GCM (BouncyCastle)         | 8KB          |    52,271.2 ns |    96.52 ns |    90.28 ns |   21480 B |
| Decrypt · Camellia-128-GCM (CryptoHives-Scalar)   | 8KB          |    75,566.7 ns |   494.91 ns |   462.94 ns |         - |
|                                                   |              |                |             |             |           |
| Encrypt · Camellia-128-GCM (CryptoHives-ArmPmull) | 8KB          |    48,223.2 ns |   138.98 ns |   116.06 ns |         - |
| Encrypt · Camellia-128-GCM (BouncyCastle)         | 8KB          |    52,867.4 ns |    86.55 ns |    80.96 ns |   21464 B |
| Encrypt · Camellia-128-GCM (CryptoHives-Scalar)   | 8KB          |    76,092.3 ns |   225.48 ns |   210.92 ns |         - |
|                                                   |              |                |             |             |           |
| Decrypt · Camellia-128-GCM (CryptoHives-ArmPmull) | 128KB        |   773,708.0 ns | 2,980.49 ns | 2,642.13 ns |         - |
| Decrypt · Camellia-128-GCM (BouncyCastle)         | 128KB        |   830,082.4 ns | 1,241.90 ns | 1,161.67 ns |  328680 B |
| Decrypt · Camellia-128-GCM (CryptoHives-Scalar)   | 128KB        | 1,220,036.6 ns | 6,728.63 ns | 6,293.97 ns |         - |
|                                                   |              |                |             |             |           |
| Encrypt · Camellia-128-GCM (CryptoHives-ArmPmull) | 128KB        |   791,611.2 ns | 2,141.87 ns | 1,898.71 ns |         - |
| Encrypt · Camellia-128-GCM (BouncyCastle)         | 128KB        |   837,415.7 ns |   992.50 ns |   928.38 ns |  328664 B |
| Encrypt · Camellia-128-GCM (CryptoHives-Scalar)   | 128KB        | 1,188,621.3 ns | 6,283.77 ns | 5,877.84 ns |         - |