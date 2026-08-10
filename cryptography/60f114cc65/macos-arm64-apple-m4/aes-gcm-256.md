| Description                             | TestDataSize | Mean          | Error      | StdDev     | Allocated |
|---------------------------------------- |------------- |--------------:|-----------:|-----------:|----------:|
| Decrypt · AES-256-GCM (ArmAes+ArmPmull) | 17B          |      82.49 ns |   0.559 ns |   0.523 ns |         - |
| Decrypt · AES-256-GCM (Managed)         | 17B          |     407.12 ns |   3.241 ns |   3.031 ns |         - |
| Decrypt · AES-256-GCM (BouncyCastle)    | 17B          |     664.80 ns |   0.533 ns |   0.498 ns |    1744 B |
| Decrypt · AES-256-GCM (OS)              | 17B          |   1,933.88 ns |  16.520 ns |  15.453 ns |         - |
|                                         |              |               |            |            |           |
| Encrypt · AES-256-GCM (ArmAes+ArmPmull) | 17B          |      55.29 ns |   0.055 ns |   0.052 ns |         - |
| Encrypt · AES-256-GCM (Managed)         | 17B          |     359.51 ns |   0.326 ns |   0.305 ns |         - |
| Encrypt · AES-256-GCM (BouncyCastle)    | 17B          |     583.97 ns |   0.588 ns |   0.550 ns |    1728 B |
| Encrypt · AES-256-GCM (OS)              | 17B          |   1,752.26 ns |   7.326 ns |   6.853 ns |         - |
|                                         |              |               |            |            |           |
| Decrypt · AES-256-GCM (ArmAes+ArmPmull) | 65B          |     116.48 ns |   0.567 ns |   0.530 ns |         - |
| Decrypt · AES-256-GCM (Managed)         | 65B          |     700.44 ns |   0.407 ns |   0.360 ns |         - |
| Decrypt · AES-256-GCM (BouncyCastle)    | 65B          |     901.62 ns |   0.968 ns |   0.905 ns |    1744 B |
| Decrypt · AES-256-GCM (OS)              | 65B          |   1,940.56 ns |  21.364 ns |  19.984 ns |         - |
|                                         |              |               |            |            |           |
| Encrypt · AES-256-GCM (ArmAes+ArmPmull) | 65B          |      87.09 ns |   0.133 ns |   0.124 ns |         - |
| Encrypt · AES-256-GCM (Managed)         | 65B          |     663.66 ns |   0.375 ns |   0.293 ns |         - |
| Encrypt · AES-256-GCM (BouncyCastle)    | 65B          |     839.63 ns |   0.450 ns |   0.399 ns |    1728 B |
| Encrypt · AES-256-GCM (OS)              | 65B          |   1,753.96 ns |   9.560 ns |   8.942 ns |         - |
|                                         |              |               |            |            |           |
| Decrypt · AES-256-GCM (ArmAes+ArmPmull) | 128B         |     158.18 ns |   0.914 ns |   0.855 ns |         - |
| Decrypt · AES-256-GCM (Managed)         | 128B         |   1,005.51 ns |   0.288 ns |   0.270 ns |         - |
| Decrypt · AES-256-GCM (BouncyCastle)    | 128B         |   1,151.31 ns |   0.886 ns |   0.828 ns |    1744 B |
| Decrypt · AES-256-GCM (OS)              | 128B         |   1,936.98 ns |  22.971 ns |  21.487 ns |         - |
|                                         |              |               |            |            |           |
| Encrypt · AES-256-GCM (ArmAes+ArmPmull) | 128B         |     124.40 ns |   0.604 ns |   0.565 ns |         - |
| Encrypt · AES-256-GCM (Managed)         | 128B         |     964.12 ns |   0.418 ns |   0.391 ns |         - |
| Encrypt · AES-256-GCM (BouncyCastle)    | 128B         |   1,103.65 ns |   1.082 ns |   1.012 ns |    1728 B |
| Encrypt · AES-256-GCM (OS)              | 128B         |   1,769.28 ns |   6.046 ns |   5.656 ns |         - |
|                                         |              |               |            |            |           |
| Decrypt · AES-256-GCM (ArmAes+ArmPmull) | 152B         |     191.42 ns |   1.137 ns |   1.008 ns |         - |
| Decrypt · AES-256-GCM (Managed)         | 152B         |   1,205.34 ns |   0.436 ns |   0.386 ns |         - |
| Decrypt · AES-256-GCM (BouncyCastle)    | 152B         |   1,312.86 ns |   0.979 ns |   0.868 ns |    1744 B |
| Decrypt · AES-256-GCM (OS)              | 152B         |   1,928.24 ns |  14.906 ns |  13.943 ns |         - |
|                                         |              |               |            |            |           |
| Encrypt · AES-256-GCM (ArmAes+ArmPmull) | 152B         |     152.96 ns |   0.615 ns |   0.575 ns |         - |
| Encrypt · AES-256-GCM (Managed)         | 152B         |   1,169.67 ns |   0.746 ns |   0.697 ns |         - |
| Encrypt · AES-256-GCM (BouncyCastle)    | 152B         |   1,268.44 ns |   0.597 ns |   0.530 ns |    1728 B |
| Encrypt · AES-256-GCM (OS)              | 152B         |   1,771.80 ns |   9.272 ns |   7.743 ns |         - |
|                                         |              |               |            |            |           |
| Decrypt · AES-256-GCM (ArmAes+ArmPmull) | 256B         |     258.47 ns |   1.865 ns |   1.744 ns |         - |
| Decrypt · AES-256-GCM (BouncyCastle)    | 256B         |   1,775.54 ns |   0.961 ns |   0.852 ns |    1744 B |
| Decrypt · AES-256-GCM (Managed)         | 256B         |   1,816.19 ns |   0.453 ns |   0.402 ns |         - |
| Decrypt · AES-256-GCM (OS)              | 256B         |   1,982.62 ns |  28.403 ns |  29.168 ns |         - |
|                                         |              |               |            |            |           |
| Encrypt · AES-256-GCM (ArmAes+ArmPmull) | 256B         |     223.87 ns |   0.959 ns |   0.897 ns |         - |
| Encrypt · AES-256-GCM (BouncyCastle)    | 256B         |   1,768.01 ns |   0.650 ns |   0.608 ns |    1728 B |
| Encrypt · AES-256-GCM (Managed)         | 256B         |   1,779.18 ns |   0.443 ns |   0.414 ns |         - |
| Encrypt · AES-256-GCM (OS)              | 256B         |   1,795.11 ns |   6.315 ns |   5.907 ns |         - |
|                                         |              |               |            |            |           |
| Decrypt · AES-256-GCM (ArmAes+ArmPmull) | 1KB          |     837.52 ns |   3.971 ns |   3.715 ns |         - |
| Decrypt · AES-256-GCM (OS)              | 1KB          |   2,062.46 ns |   6.468 ns |   5.401 ns |         - |
| Decrypt · AES-256-GCM (BouncyCastle)    | 1KB          |   5,521.29 ns |   2.299 ns |   2.038 ns |    1744 B |
| Decrypt · AES-256-GCM (Managed)         | 1KB          |   6,727.03 ns |  87.925 ns |  82.246 ns |         - |
|                                         |              |               |            |            |           |
| Encrypt · AES-256-GCM (ArmAes+ArmPmull) | 1KB          |     810.15 ns |   5.449 ns |   5.097 ns |         - |
| Encrypt · AES-256-GCM (OS)              | 1KB          |   1,939.52 ns |  31.372 ns |  32.217 ns |         - |
| Encrypt · AES-256-GCM (BouncyCastle)    | 1KB          |   5,746.51 ns |   1.067 ns |   0.998 ns |    1728 B |
| Encrypt · AES-256-GCM (Managed)         | 1KB          |   6,458.96 ns |   1.156 ns |   1.082 ns |         - |
|                                         |              |               |            |            |           |
| Decrypt · AES-256-GCM (OS)              | 8KB          |   3,044.75 ns |  13.786 ns |  12.896 ns |         - |
| Decrypt · AES-256-GCM (ArmAes+ArmPmull) | 8KB          |   6,244.86 ns |  30.140 ns |  28.193 ns |         - |
| Decrypt · AES-256-GCM (BouncyCastle)    | 8KB          |  40,065.31 ns |  14.030 ns |  12.437 ns |    1744 B |
| Decrypt · AES-256-GCM (Managed)         | 8KB          |  50,789.79 ns |  14.453 ns |  13.519 ns |         - |
|                                         |              |               |            |            |           |
| Encrypt · AES-256-GCM (OS)              | 8KB          |   2,948.01 ns |  19.038 ns |  17.808 ns |         - |
| Encrypt · AES-256-GCM (ArmAes+ArmPmull) | 8KB          |   6,225.31 ns |  47.137 ns |  41.786 ns |         - |
| Encrypt · AES-256-GCM (BouncyCastle)    | 8KB          |  42,559.77 ns |  17.138 ns |  15.192 ns |    1728 B |
| Encrypt · AES-256-GCM (Managed)         | 8KB          |  50,626.59 ns |  27.598 ns |  25.815 ns |         - |
|                                         |              |               |            |            |           |
| Decrypt · AES-256-GCM (OS)              | 128KB        |  20,568.98 ns |  55.919 ns |  52.307 ns |         - |
| Decrypt · AES-256-GCM (ArmAes+ArmPmull) | 128KB        |  99,249.59 ns | 624.051 ns | 553.205 ns |         - |
| Decrypt · AES-256-GCM (BouncyCastle)    | 128KB        | 632,204.18 ns | 384.128 ns | 359.314 ns |    1744 B |
| Decrypt · AES-256-GCM (Managed)         | 128KB        | 807,790.22 ns | 114.541 ns |  89.426 ns |         - |
|                                         |              |               |            |            |           |
| Encrypt · AES-256-GCM (OS)              | 128KB        |  21,498.42 ns | 161.310 ns | 150.889 ns |         - |
| Encrypt · AES-256-GCM (ArmAes+ArmPmull) | 128KB        | 100,346.37 ns | 843.552 ns | 747.787 ns |         - |
| Encrypt · AES-256-GCM (BouncyCastle)    | 128KB        | 672,427.99 ns | 307.502 ns | 287.637 ns |    1728 B |
| Encrypt · AES-256-GCM (Managed)         | 128KB        | 806,986.05 ns | 150.124 ns | 117.207 ns |         - |