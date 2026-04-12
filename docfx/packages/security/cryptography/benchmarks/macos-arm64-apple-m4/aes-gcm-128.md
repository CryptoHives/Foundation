| Description                             | TestDataSize | Mean          | Error         | StdDev        | Median        | Allocated |
|---------------------------------------- |------------- |--------------:|--------------:|--------------:|--------------:|----------:|
| Decrypt · AES-128-GCM (ArmAes+ArmPmull) | 17B          |     103.17 ns |      0.536 ns |      0.501 ns |     103.27 ns |         - |
| Decrypt · AES-128-GCM (Managed)         | 17B          |     424.25 ns |      3.941 ns |      3.686 ns |     422.54 ns |         - |
| Decrypt · AES-128-GCM (BouncyCastle)    | 17B          |     716.75 ns |     64.211 ns |    163.437 ns |     721.07 ns |    1536 B |
| Decrypt · AES-128-GCM (OS)              | 17B          |   2,597.70 ns |     38.161 ns |     33.829 ns |   2,595.87 ns |         - |
|                                         |              |               |               |               |               |           |
| Encrypt · AES-128-GCM (ArmAes+ArmPmull) | 17B          |      68.38 ns |      1.241 ns |      1.161 ns |      68.80 ns |         - |
| Encrypt · AES-128-GCM (Managed)         | 17B          |     377.11 ns |      4.603 ns |      4.080 ns |     376.22 ns |         - |
| Encrypt · AES-128-GCM (BouncyCastle)    | 17B          |     631.53 ns |      6.617 ns |      6.190 ns |     629.83 ns |    1520 B |
| Encrypt · AES-128-GCM (OS)              | 17B          |   2,262.58 ns |     29.862 ns |     27.933 ns |   2,256.14 ns |         - |
|                                         |              |               |               |               |               |           |
| Decrypt · AES-128-GCM (ArmAes+ArmPmull) | 65B          |     142.52 ns |      1.509 ns |      1.412 ns |     142.85 ns |         - |
| Decrypt · AES-128-GCM (Managed)         | 65B          |   2,906.50 ns |      7.586 ns |      7.096 ns |   2,907.09 ns |         - |
| Decrypt · AES-128-GCM (BouncyCastle)    | 65B          |   3,606.87 ns |      5.434 ns |      4.817 ns |   3,607.05 ns |    1536 B |
| Decrypt · AES-128-GCM (OS)              | 65B          |   8,847.88 ns |     58.632 ns |     51.976 ns |   8,845.47 ns |         - |
|                                         |              |               |               |               |               |           |
| Encrypt · AES-128-GCM (ArmAes+ArmPmull) | 65B          |     100.30 ns |      2.009 ns |      1.678 ns |     100.66 ns |         - |
| Encrypt · AES-128-GCM (Managed)         | 65B          |     685.12 ns |      1.198 ns |      1.062 ns |     684.93 ns |         - |
| Encrypt · AES-128-GCM (BouncyCastle)    | 65B          |     889.29 ns |      5.935 ns |      5.552 ns |     887.36 ns |    1520 B |
| Encrypt · AES-128-GCM (OS)              | 65B          |   2,366.04 ns |      7.273 ns |      6.073 ns |   2,364.66 ns |         - |
|                                         |              |               |               |               |               |           |
| Decrypt · AES-128-GCM (ArmAes+ArmPmull) | 128B         |     146.71 ns |      2.190 ns |      2.434 ns |     146.16 ns |         - |
| Decrypt · AES-128-GCM (Managed)         | 128B         |   1,048.15 ns |     13.523 ns |     12.650 ns |   1,043.52 ns |         - |
| Decrypt · AES-128-GCM (BouncyCastle)    | 128B         |   1,222.06 ns |      6.079 ns |      5.389 ns |   1,219.74 ns |    1536 B |
| Decrypt · AES-128-GCM (OS)              | 128B         |   2,660.60 ns |     16.961 ns |     15.865 ns |   2,660.11 ns |         - |
|                                         |              |               |               |               |               |           |
| Encrypt · AES-128-GCM (ArmAes+ArmPmull) | 128B         |     137.34 ns |      2.596 ns |      3.188 ns |     136.70 ns |         - |
| Encrypt · AES-128-GCM (Managed)         | 128B         |   1,000.74 ns |      0.592 ns |      0.462 ns |   1,000.75 ns |         - |
| Encrypt · AES-128-GCM (BouncyCastle)    | 128B         |   1,171.94 ns |      5.876 ns |      5.209 ns |   1,170.28 ns |    1520 B |
| Encrypt · AES-128-GCM (OS)              | 128B         |   2,417.13 ns |     14.324 ns |     13.399 ns |   2,418.78 ns |         - |
|                                         |              |               |               |               |               |           |
| Decrypt · AES-128-GCM (ArmAes+ArmPmull) | 152B         |     210.39 ns |      2.268 ns |      2.122 ns |     210.76 ns |         - |
| Decrypt · AES-128-GCM (Managed)         | 152B         |   1,256.35 ns |      6.222 ns |      5.516 ns |   1,257.91 ns |         - |
| Decrypt · AES-128-GCM (BouncyCastle)    | 152B         |   1,393.99 ns |     21.967 ns |     20.548 ns |   1,387.70 ns |    1536 B |
| Decrypt · AES-128-GCM (OS)              | 152B         |   2,658.78 ns |     14.281 ns |     13.358 ns |   2,657.44 ns |         - |
|                                         |              |               |               |               |               |           |
| Encrypt · AES-128-GCM (ArmAes+ArmPmull) | 152B         |     167.45 ns |      0.396 ns |      0.351 ns |     167.31 ns |         - |
| Encrypt · AES-128-GCM (Managed)         | 152B         |   1,199.85 ns |      4.506 ns |      3.994 ns |   1,200.17 ns |         - |
| Encrypt · AES-128-GCM (BouncyCastle)    | 152B         |   1,319.98 ns |      5.273 ns |      4.403 ns |   1,318.21 ns |    1520 B |
| Encrypt · AES-128-GCM (OS)              | 152B         |   2,406.11 ns |     10.047 ns |      8.907 ns |   2,403.58 ns |         - |
|                                         |              |               |               |               |               |           |
| Decrypt · AES-128-GCM (ArmAes+ArmPmull) | 256B         |     285.38 ns |      1.383 ns |      1.226 ns |     285.14 ns |         - |
| Decrypt · AES-128-GCM (Managed)         | 256B         |   1,894.68 ns |     21.895 ns |     20.480 ns |   1,883.35 ns |         - |
| Decrypt · AES-128-GCM (OS)              | 256B         |   2,674.13 ns |      9.492 ns |      7.411 ns |   2,674.49 ns |         - |
| Decrypt · AES-128-GCM (BouncyCastle)    | 256B         |   3,787.83 ns |    838.454 ns |  2,472.202 ns |   1,841.74 ns |    1536 B |
|                                         |              |               |               |               |               |           |
| Encrypt · AES-128-GCM (ArmAes+ArmPmull) | 256B         |     240.24 ns |      2.224 ns |      2.080 ns |     238.90 ns |         - |
| Encrypt · AES-128-GCM (BouncyCastle)    | 256B         |   1,841.91 ns |      9.822 ns |      9.187 ns |   1,837.96 ns |    1520 B |
| Encrypt · AES-128-GCM (Managed)         | 256B         |   1,846.99 ns |     30.066 ns |     25.106 ns |   1,834.34 ns |         - |
| Encrypt · AES-128-GCM (OS)              | 256B         |   2,428.49 ns |     11.511 ns |      8.987 ns |   2,429.85 ns |         - |
|                                         |              |               |               |               |               |           |
| Decrypt · AES-128-GCM (ArmAes+ArmPmull) | 1KB          |     916.18 ns |     18.348 ns |     18.020 ns |     924.08 ns |         - |
| Decrypt · AES-128-GCM (OS)              | 1KB          |   2,849.68 ns |     18.170 ns |     16.997 ns |   2,845.46 ns |         - |
| Decrypt · AES-128-GCM (BouncyCastle)    | 1KB          |   5,595.08 ns |     65.025 ns |     60.824 ns |   5,565.37 ns |    1536 B |
| Decrypt · AES-128-GCM (Managed)         | 1KB          |   6,759.80 ns |     11.235 ns |      9.960 ns |   6,755.46 ns |         - |
|                                         |              |               |               |               |               |           |
| Encrypt · AES-128-GCM (ArmAes+ArmPmull) | 1KB          |     838.25 ns |      0.886 ns |      0.829 ns |     838.04 ns |         - |
| Encrypt · AES-128-GCM (OS)              | 1KB          |   2,604.38 ns |      8.081 ns |      6.748 ns |   2,604.53 ns |         - |
| Encrypt · AES-128-GCM (BouncyCastle)    | 1KB          |   5,861.01 ns |     22.558 ns |     19.997 ns |   5,852.55 ns |    1520 B |
| Encrypt · AES-128-GCM (Managed)         | 1KB          |   6,615.64 ns |     20.615 ns |     17.214 ns |   6,611.41 ns |         - |
|                                         |              |               |               |               |               |           |
| Decrypt · AES-128-GCM (OS)              | 8KB          |   4,036.04 ns |      7.154 ns |      5.974 ns |   4,036.37 ns |         - |
| Decrypt · AES-128-GCM (ArmAes+ArmPmull) | 8KB          |   6,632.88 ns |      9.380 ns |      8.774 ns |   6,632.62 ns |         - |
| Decrypt · AES-128-GCM (BouncyCastle)    | 8KB          |  39,670.23 ns |    117.660 ns |     98.252 ns |  39,665.58 ns |    1536 B |
| Decrypt · AES-128-GCM (Managed)         | 8KB          |  94,926.96 ns | 23,588.866 ns | 69,552.307 ns |  52,166.89 ns |         - |
|                                         |              |               |               |               |               |           |
| Encrypt · AES-128-GCM (ArmAes+ArmPmull) | 8KB          |   6,573.30 ns |     10.475 ns |      9.286 ns |   6,573.35 ns |         - |
| Encrypt · AES-128-GCM (OS)              | 8KB          |   9,960.99 ns |  1,544.902 ns |  4,555.179 ns |  13,248.40 ns |         - |
| Encrypt · AES-128-GCM (Managed)         | 8KB          |  68,919.19 ns |    989.131 ns |    925.234 ns |  68,552.17 ns |         - |
| Encrypt · AES-128-GCM (BouncyCastle)    | 8KB          |  83,157.78 ns | 19,831.981 ns | 58,475.049 ns |  42,846.97 ns |    1520 B |
|                                         |              |               |               |               |               |           |
| Decrypt · AES-128-GCM (OS)              | 128KB        |  87,061.52 ns |    542.445 ns |    507.404 ns |  86,900.65 ns |         - |
| Decrypt · AES-128-GCM (ArmAes+ArmPmull) | 128KB        | 105,676.81 ns |    428.014 ns |    357.411 ns | 105,605.97 ns |         - |
| Decrypt · AES-128-GCM (BouncyCastle)    | 128KB        | 627,243.67 ns |  2,197.455 ns |  2,055.501 ns | 627,236.00 ns |    1536 B |
| Decrypt · AES-128-GCM (Managed)         | 128KB        | 830,951.32 ns |  9,250.159 ns |  8,652.604 ns | 826,879.92 ns |         - |
|                                         |              |               |               |               |               |           |
| Encrypt · AES-128-GCM (OS)              | 128KB        |  28,383.59 ns |     94.780 ns |     84.020 ns |  28,364.55 ns |         - |
| Encrypt · AES-128-GCM (ArmAes+ArmPmull) | 128KB        | 104,668.48 ns |    516.761 ns |    483.379 ns | 104,664.31 ns |         - |
| Encrypt · AES-128-GCM (BouncyCastle)    | 128KB        | 680,526.58 ns |  1,631.346 ns |  1,362.248 ns | 680,039.63 ns |    1520 B |
| Encrypt · AES-128-GCM (Managed)         | 128KB        | 826,114.60 ns |  9,086.892 ns |  7,094.448 ns | 826,170.49 ns |         - |