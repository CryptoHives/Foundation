| Description                             | TestDataSize | Mean          | Error        | StdDev       | Median        | Allocated |
|---------------------------------------- |------------- |--------------:|-------------:|-------------:|--------------:|----------:|
| Decrypt · AES-192-GCM (ArmAes+ArmPmull) | 17B          |      88.64 ns |     0.816 ns |     1.386 ns |      88.48 ns |         - |
| Decrypt · AES-192-GCM (Managed)         | 17B          |     384.55 ns |     2.477 ns |     2.317 ns |     383.82 ns |         - |
| Decrypt · AES-192-GCM (BouncyCastle)    | 17B          |     644.88 ns |     2.070 ns |     1.936 ns |     644.89 ns |    1640 B |
| Decrypt · AES-192-GCM (OS)              | 17B          |   1,961.31 ns |     9.998 ns |     9.352 ns |   1,963.25 ns |         - |
|                                         |              |               |              |              |               |           |
| Encrypt · AES-192-GCM (ArmAes+ArmPmull) | 17B          |      54.83 ns |     0.363 ns |     0.339 ns |      54.80 ns |         - |
| Encrypt · AES-192-GCM (Managed)         | 17B          |     337.99 ns |     0.361 ns |     0.301 ns |     337.96 ns |         - |
| Encrypt · AES-192-GCM (BouncyCastle)    | 17B          |     539.33 ns |     1.369 ns |     1.213 ns |     539.13 ns |    1624 B |
| Encrypt · AES-192-GCM (OS)              | 17B          |   1,724.67 ns |    11.283 ns |    10.002 ns |   1,725.28 ns |         - |
|                                         |              |               |              |              |               |           |
| Decrypt · AES-192-GCM (ArmAes+ArmPmull) | 65B          |     127.00 ns |     0.526 ns |     0.466 ns |     126.98 ns |         - |
| Decrypt · AES-192-GCM (Managed)         | 65B          |     678.65 ns |     3.988 ns |     3.535 ns |     678.16 ns |         - |
| Decrypt · AES-192-GCM (BouncyCastle)    | 65B          |     875.62 ns |     6.169 ns |     5.469 ns |     873.15 ns |    1640 B |
| Decrypt · AES-192-GCM (OS)              | 65B          |   1,961.01 ns |     8.769 ns |     8.203 ns |   1,960.41 ns |         - |
|                                         |              |               |              |              |               |           |
| Encrypt · AES-192-GCM (ArmAes+ArmPmull) | 65B          |      85.93 ns |     0.357 ns |     0.334 ns |      86.04 ns |         - |
| Encrypt · AES-192-GCM (Managed)         | 65B          |     621.38 ns |     5.008 ns |     4.439 ns |     620.10 ns |         - |
| Encrypt · AES-192-GCM (BouncyCastle)    | 65B          |     768.43 ns |     1.952 ns |     1.630 ns |     767.94 ns |    1624 B |
| Encrypt · AES-192-GCM (OS)              | 65B          |   1,699.25 ns |     6.290 ns |     5.884 ns |   1,697.84 ns |         - |
|                                         |              |               |              |              |               |           |
| Decrypt · AES-192-GCM (ArmAes+ArmPmull) | 128B         |     165.14 ns |     0.953 ns |     0.892 ns |     165.07 ns |         - |
| Decrypt · AES-192-GCM (Managed)         | 128B         |     963.21 ns |     5.582 ns |     4.948 ns |     964.87 ns |         - |
| Decrypt · AES-192-GCM (BouncyCastle)    | 128B         |   1,123.41 ns |     2.551 ns |     2.386 ns |   1,123.69 ns |    1640 B |
| Decrypt · AES-192-GCM (OS)              | 128B         |   2,013.48 ns |    25.533 ns |    23.884 ns |   2,016.24 ns |         - |
|                                         |              |               |              |              |               |           |
| Encrypt · AES-192-GCM (ArmAes+ArmPmull) | 128B         |     119.79 ns |     0.434 ns |     0.406 ns |     119.74 ns |         - |
| Encrypt · AES-192-GCM (Managed)         | 128B         |     900.18 ns |     1.336 ns |     1.185 ns |     899.74 ns |         - |
| Encrypt · AES-192-GCM (BouncyCastle)    | 128B         |   1,011.73 ns |     1.451 ns |     1.357 ns |   1,011.96 ns |    1624 B |
| Encrypt · AES-192-GCM (OS)              | 128B         |   1,721.26 ns |     9.321 ns |     8.719 ns |   1,720.09 ns |         - |
|                                         |              |               |              |              |               |           |
| Decrypt · AES-192-GCM (ArmAes+ArmPmull) | 152B         |     197.90 ns |     0.479 ns |     0.425 ns |     197.89 ns |         - |
| Decrypt · AES-192-GCM (Managed)         | 152B         |   1,186.42 ns |     3.950 ns |     3.695 ns |   1,187.44 ns |         - |
| Decrypt · AES-192-GCM (BouncyCastle)    | 152B         |   1,269.90 ns |     7.636 ns |     7.143 ns |   1,269.82 ns |    1640 B |
| Decrypt · AES-192-GCM (OS)              | 152B         |   2,026.10 ns |    21.096 ns |    19.733 ns |   2,028.72 ns |         - |
|                                         |              |               |              |              |               |           |
| Encrypt · AES-192-GCM (ArmAes+ArmPmull) | 152B         |     148.07 ns |     0.826 ns |     0.773 ns |     147.96 ns |         - |
| Encrypt · AES-192-GCM (Managed)         | 152B         |   1,083.81 ns |     2.450 ns |     2.172 ns |   1,083.46 ns |         - |
| Encrypt · AES-192-GCM (BouncyCastle)    | 152B         |   1,156.93 ns |     1.140 ns |     1.011 ns |   1,156.88 ns |    1624 B |
| Encrypt · AES-192-GCM (OS)              | 152B         |   1,886.51 ns |    37.631 ns |    77.714 ns |   1,921.00 ns |         - |
|                                         |              |               |              |              |               |           |
| Decrypt · AES-192-GCM (ArmAes+ArmPmull) | 256B         |     274.20 ns |     1.219 ns |     1.140 ns |     274.24 ns |         - |
| Decrypt · AES-192-GCM (BouncyCastle)    | 256B         |   1,716.26 ns |     5.456 ns |     5.104 ns |   1,715.83 ns |    1640 B |
| Decrypt · AES-192-GCM (Managed)         | 256B         |   1,777.79 ns |     4.789 ns |     4.480 ns |   1,777.46 ns |         - |
| Decrypt · AES-192-GCM (OS)              | 256B         |   2,006.89 ns |     5.787 ns |     5.414 ns |   2,006.84 ns |         - |
|                                         |              |               |              |              |               |           |
| Encrypt · AES-192-GCM (ArmAes+ArmPmull) | 256B         |     245.46 ns |     3.782 ns |     3.538 ns |     246.90 ns |         - |
| Encrypt · AES-192-GCM (BouncyCastle)    | 256B         |   1,784.07 ns |    13.793 ns |    12.902 ns |   1,785.44 ns |    1624 B |
| Encrypt · AES-192-GCM (Managed)         | 256B         |   1,826.82 ns |    16.124 ns |    15.082 ns |   1,832.15 ns |         - |
| Encrypt · AES-192-GCM (OS)              | 256B         |   1,942.43 ns |    26.472 ns |    23.467 ns |   1,944.04 ns |         - |
|                                         |              |               |              |              |               |           |
| Decrypt · AES-192-GCM (ArmAes+ArmPmull) | 1KB          |     919.98 ns |    17.348 ns |    23.747 ns |     910.43 ns |         - |
| Decrypt · AES-192-GCM (OS)              | 1KB          |   2,129.58 ns |    29.742 ns |    24.836 ns |   2,125.08 ns |         - |
| Decrypt · AES-192-GCM (BouncyCastle)    | 1KB          |   5,155.56 ns |    83.072 ns |   119.140 ns |   5,093.43 ns |    1640 B |
| Decrypt · AES-192-GCM (Managed)         | 1KB          |   6,220.61 ns |    20.487 ns |    19.164 ns |   6,220.82 ns |         - |
|                                         |              |               |              |              |               |           |
| Encrypt · AES-192-GCM (ArmAes+ArmPmull) | 1KB          |     911.15 ns |    15.261 ns |    14.275 ns |     914.45 ns |         - |
| Encrypt · AES-192-GCM (OS)              | 1KB          |   2,084.34 ns |    18.503 ns |    16.402 ns |   2,084.09 ns |         - |
| Encrypt · AES-192-GCM (BouncyCastle)    | 1KB          |   5,806.63 ns |    41.236 ns |    38.572 ns |   5,816.79 ns |    1624 B |
| Encrypt · AES-192-GCM (Managed)         | 1KB          |   6,625.54 ns |    56.436 ns |    52.790 ns |   6,646.75 ns |         - |
|                                         |              |               |              |              |               |           |
| Decrypt · AES-192-GCM (OS)              | 8KB          |   3,192.92 ns |    41.167 ns |    38.507 ns |   3,197.00 ns |         - |
| Decrypt · AES-192-GCM (ArmAes+ArmPmull) | 8KB          |   6,861.46 ns |    96.269 ns |    85.340 ns |   6,846.07 ns |         - |
| Decrypt · AES-192-GCM (BouncyCastle)    | 8KB          |  36,794.07 ns |   157.620 ns |   147.438 ns |  36,746.45 ns |    1640 B |
| Decrypt · AES-192-GCM (Managed)         | 8KB          |  47,855.32 ns |   115.413 ns |   107.957 ns |  47,853.18 ns |         - |
|                                         |              |               |              |              |               |           |
| Encrypt · AES-192-GCM (OS)              | 8KB          |   3,216.31 ns |    25.133 ns |    22.280 ns |   3,216.80 ns |         - |
| Encrypt · AES-192-GCM (ArmAes+ArmPmull) | 8KB          |   7,275.47 ns |   143.373 ns |   147.234 ns |   7,293.49 ns |         - |
| Encrypt · AES-192-GCM (BouncyCastle)    | 8KB          |  42,470.61 ns |   342.962 ns |   320.807 ns |  42,536.57 ns |    1624 B |
| Encrypt · AES-192-GCM (Managed)         | 8KB          |  51,352.26 ns | 1,025.780 ns | 1,566.475 ns |  51,974.95 ns |         - |
|                                         |              |               |              |              |               |           |
| Decrypt · AES-192-GCM (OS)              | 128KB        |  21,617.22 ns |    41.413 ns |    38.738 ns |  21,625.07 ns |         - |
| Decrypt · AES-192-GCM (ArmAes+ArmPmull) | 128KB        | 108,670.67 ns | 1,473.814 ns | 3,502.675 ns | 108,040.67 ns |         - |
| Decrypt · AES-192-GCM (BouncyCastle)    | 128KB        | 569,932.15 ns |   197.979 ns |   175.504 ns | 569,919.62 ns |    1640 B |
| Decrypt · AES-192-GCM (Managed)         | 128KB        | 747,764.92 ns |   339.076 ns |   283.143 ns | 747,864.68 ns |         - |
|                                         |              |               |              |              |               |           |
| Encrypt · AES-192-GCM (OS)              | 128KB        |  23,587.42 ns |   129.504 ns |   114.802 ns |  23,599.07 ns |         - |
| Encrypt · AES-192-GCM (ArmAes+ArmPmull) | 128KB        | 112,051.01 ns | 2,663.548 ns | 7,246.378 ns | 113,045.82 ns |         - |
| Encrypt · AES-192-GCM (BouncyCastle)    | 128KB        | 643,812.16 ns | 7,453.016 ns | 6,971.556 ns | 644,847.05 ns |    1624 B |
| Encrypt · AES-192-GCM (Managed)         | 128KB        | 796,955.76 ns | 5,329.920 ns | 4,450.725 ns | 797,598.18 ns |         - |