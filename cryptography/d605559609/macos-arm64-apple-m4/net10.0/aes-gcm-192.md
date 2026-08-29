| Description                                       | TestDataSize | Mean          | Error        | StdDev       | Median        | Allocated |
|-------------------------------------------------- |------------- |--------------:|-------------:|-------------:|--------------:|----------:|
| Decrypt · AES-192-GCM (CryptoHives-ARM-AES+PMULL) | 17B          |      84.27 ns |     0.344 ns |     0.268 ns |      84.23 ns |         - |
| Decrypt · AES-192-GCM (CryptoHives-Scalar)        | 17B          |     363.47 ns |     0.923 ns |     0.771 ns |     363.60 ns |         - |
| Decrypt · AES-192-GCM (BouncyCastle)              | 17B          |     542.11 ns |     0.554 ns |     0.463 ns |     542.05 ns |    1640 B |
| Decrypt · AES-192-GCM (OS)                        | 17B          |   1,936.92 ns |    13.922 ns |    12.341 ns |   1,936.54 ns |         - |
|                                                   |              |               |              |              |               |           |
| Encrypt · AES-192-GCM (CryptoHives-ARM-AES+PMULL) | 17B          |      55.69 ns |     0.637 ns |     0.532 ns |      55.72 ns |         - |
| Encrypt · AES-192-GCM (CryptoHives-Scalar)        | 17B          |     334.67 ns |     2.944 ns |     2.610 ns |     333.88 ns |         - |
| Encrypt · AES-192-GCM (BouncyCastle)              | 17B          |     479.12 ns |     9.354 ns |    10.009 ns |     473.14 ns |    1624 B |
| Encrypt · AES-192-GCM (OS)                        | 17B          |   1,719.58 ns |     6.920 ns |     6.473 ns |   1,720.68 ns |         - |
|                                                   |              |               |              |              |               |           |
| Decrypt · AES-192-GCM (CryptoHives-ARM-AES+PMULL) | 65B          |      90.57 ns |     0.803 ns |     0.751 ns |      90.38 ns |         - |
| Decrypt · AES-192-GCM (CryptoHives-Scalar)        | 65B          |     642.52 ns |     1.077 ns |     0.955 ns |     642.39 ns |         - |
| Decrypt · AES-192-GCM (BouncyCastle)              | 65B          |     762.57 ns |     2.133 ns |     1.995 ns |     762.22 ns |    1640 B |
| Decrypt · AES-192-GCM (OS)                        | 65B          |   1,879.74 ns |     5.794 ns |     5.420 ns |   1,881.67 ns |         - |
|                                                   |              |               |              |              |               |           |
| Encrypt · AES-192-GCM (CryptoHives-ARM-AES+PMULL) | 65B          |      64.07 ns |     0.081 ns |     0.072 ns |      64.04 ns |         - |
| Encrypt · AES-192-GCM (CryptoHives-Scalar)        | 65B          |     607.95 ns |     0.596 ns |     0.465 ns |     607.78 ns |         - |
| Encrypt · AES-192-GCM (BouncyCastle)              | 65B          |     697.77 ns |     0.809 ns |     0.676 ns |     697.85 ns |    1624 B |
| Encrypt · AES-192-GCM (OS)                        | 65B          |   1,720.99 ns |    32.667 ns |    30.557 ns |   1,716.02 ns |         - |
|                                                   |              |               |              |              |               |           |
| Decrypt · AES-192-GCM (CryptoHives-ARM-AES+PMULL) | 128B         |      91.15 ns |     1.467 ns |     1.373 ns |      91.40 ns |         - |
| Decrypt · AES-192-GCM (CryptoHives-Scalar)        | 128B         |     925.98 ns |     7.661 ns |     7.166 ns |     930.89 ns |         - |
| Decrypt · AES-192-GCM (BouncyCastle)              | 128B         |   1,012.91 ns |    17.589 ns |    16.453 ns |   1,004.50 ns |    1640 B |
| Decrypt · AES-192-GCM (OS)                        | 128B         |   1,917.12 ns |    20.492 ns |    19.168 ns |   1,916.35 ns |         - |
|                                                   |              |               |              |              |               |           |
| Encrypt · AES-192-GCM (CryptoHives-ARM-AES+PMULL) | 128B         |      69.57 ns |     0.783 ns |     0.694 ns |      69.31 ns |         - |
| Encrypt · AES-192-GCM (CryptoHives-Scalar)        | 128B         |     904.01 ns |     0.877 ns |     0.732 ns |     903.92 ns |         - |
| Encrypt · AES-192-GCM (BouncyCastle)              | 128B         |     957.38 ns |     6.010 ns |     5.327 ns |     959.33 ns |    1624 B |
| Encrypt · AES-192-GCM (OS)                        | 128B         |   1,710.94 ns |     6.076 ns |     5.386 ns |   1,713.69 ns |         - |
|                                                   |              |               |              |              |               |           |
| Decrypt · AES-192-GCM (CryptoHives-ARM-AES+PMULL) | 152B         |     128.19 ns |     2.012 ns |     1.882 ns |     127.72 ns |         - |
| Decrypt · AES-192-GCM (CryptoHives-Scalar)        | 152B         |   1,127.32 ns |    16.642 ns |    13.897 ns |   1,120.25 ns |         - |
| Decrypt · AES-192-GCM (BouncyCastle)              | 152B         |   1,128.64 ns |    21.381 ns |    17.854 ns |   1,120.89 ns |    1640 B |
| Decrypt · AES-192-GCM (OS)                        | 152B         |   1,950.82 ns |    23.766 ns |    21.068 ns |   1,945.84 ns |         - |
|                                                   |              |               |              |              |               |           |
| Encrypt · AES-192-GCM (CryptoHives-ARM-AES+PMULL) | 152B         |      92.46 ns |     0.182 ns |     0.152 ns |      92.44 ns |         - |
| Encrypt · AES-192-GCM (CryptoHives-Scalar)        | 152B         |   1,072.86 ns |     1.858 ns |     1.647 ns |   1,072.40 ns |         - |
| Encrypt · AES-192-GCM (BouncyCastle)              | 152B         |   1,090.19 ns |     1.288 ns |     1.142 ns |   1,089.95 ns |    1624 B |
| Encrypt · AES-192-GCM (OS)                        | 152B         |   1,740.38 ns |    27.203 ns |    24.115 ns |   1,745.67 ns |         - |
|                                                   |              |               |              |              |               |           |
| Decrypt · AES-192-GCM (CryptoHives-ARM-AES+PMULL) | 256B         |     135.01 ns |     1.409 ns |     1.318 ns |     135.21 ns |         - |
| Decrypt · AES-192-GCM (BouncyCastle)              | 256B         |   1,552.30 ns |     2.693 ns |     2.387 ns |   1,551.63 ns |    1640 B |
| Decrypt · AES-192-GCM (CryptoHives-Scalar)        | 256B         |   1,695.29 ns |    32.532 ns |    30.430 ns |   1,678.16 ns |         - |
| Decrypt · AES-192-GCM (OS)                        | 256B         |   1,925.82 ns |     8.611 ns |     8.054 ns |   1,926.27 ns |         - |
|                                                   |              |               |              |              |               |           |
| Encrypt · AES-192-GCM (CryptoHives-ARM-AES+PMULL) | 256B         |      93.39 ns |     0.728 ns |     0.681 ns |      93.65 ns |         - |
| Encrypt · AES-192-GCM (BouncyCastle)              | 256B         |   1,546.94 ns |     2.712 ns |     2.537 ns |   1,545.49 ns |    1624 B |
| Encrypt · AES-192-GCM (CryptoHives-Scalar)        | 256B         |   1,641.76 ns |     3.536 ns |     2.953 ns |   1,640.09 ns |         - |
| Encrypt · AES-192-GCM (OS)                        | 256B         |   1,755.15 ns |    18.299 ns |    14.286 ns |   1,756.01 ns |         - |
|                                                   |              |               |              |              |               |           |
| Decrypt · AES-192-GCM (CryptoHives-ARM-AES+PMULL) | 1KB          |     342.34 ns |     1.695 ns |     1.323 ns |     342.07 ns |         - |
| Decrypt · AES-192-GCM (OS)                        | 1KB          |   2,065.21 ns |    13.209 ns |    11.030 ns |   2,068.75 ns |         - |
| Decrypt · AES-192-GCM (BouncyCastle)              | 1KB          |   4,922.36 ns |    14.639 ns |    11.429 ns |   4,920.44 ns |    1640 B |
| Decrypt · AES-192-GCM (CryptoHives-Scalar)        | 1KB          |   6,009.26 ns |    10.944 ns |     9.139 ns |   6,007.20 ns |         - |
|                                                   |              |               |              |              |               |           |
| Encrypt · AES-192-GCM (CryptoHives-ARM-AES+PMULL) | 1KB          |     309.91 ns |     6.146 ns |    12.131 ns |     304.75 ns |         - |
| Encrypt · AES-192-GCM (OS)                        | 1KB          |   1,885.19 ns |    10.501 ns |     9.823 ns |   1,886.42 ns |         - |
| Encrypt · AES-192-GCM (BouncyCastle)              | 1KB          |   5,194.29 ns |     7.066 ns |     6.264 ns |   5,194.03 ns |    1624 B |
| Encrypt · AES-192-GCM (CryptoHives-Scalar)        | 1KB          |   5,914.09 ns |    42.139 ns |    35.188 ns |   5,906.53 ns |         - |
|                                                   |              |               |              |              |               |           |
| Decrypt · AES-192-GCM (CryptoHives-ARM-AES+PMULL) | 8KB          |   2,256.16 ns |    29.134 ns |    24.328 ns |   2,245.20 ns |         - |
| Decrypt · AES-192-GCM (OS)                        | 8KB          |   3,012.97 ns |     9.435 ns |     8.825 ns |   3,012.53 ns |         - |
| Decrypt · AES-192-GCM (BouncyCastle)              | 8KB          |  35,988.72 ns |    47.856 ns |    39.962 ns |  35,976.97 ns |    1640 B |
| Decrypt · AES-192-GCM (CryptoHives-Scalar)        | 8KB          |  46,199.30 ns |    20.245 ns |    16.905 ns |  46,196.04 ns |         - |
|                                                   |              |               |              |              |               |           |
| Encrypt · AES-192-GCM (CryptoHives-ARM-AES+PMULL) | 8KB          |   2,274.93 ns |    41.515 ns |    46.144 ns |   2,255.38 ns |         - |
| Encrypt · AES-192-GCM (OS)                        | 8KB          |   2,856.30 ns |    14.699 ns |    13.749 ns |   2,853.60 ns |         - |
| Encrypt · AES-192-GCM (BouncyCastle)              | 8KB          |  38,704.79 ns |    18.502 ns |    16.401 ns |  38,701.18 ns |    1624 B |
| Encrypt · AES-192-GCM (CryptoHives-Scalar)        | 8KB          |  46,087.83 ns |    59.137 ns |    46.170 ns |  46,072.10 ns |         - |
|                                                   |              |               |              |              |               |           |
| Decrypt · AES-192-GCM (OS)                        | 128KB        |  19,539.70 ns |    61.430 ns |    57.462 ns |  19,527.17 ns |         - |
| Decrypt · AES-192-GCM (CryptoHives-ARM-AES+PMULL) | 128KB        |  37,039.42 ns |   726.746 ns | 1,328.897 ns |  37,283.19 ns |         - |
| Decrypt · AES-192-GCM (BouncyCastle)              | 128KB        | 569,093.82 ns |   408.002 ns |   340.700 ns | 568,988.73 ns |    1640 B |
| Decrypt · AES-192-GCM (CryptoHives-Scalar)        | 128KB        | 736,349.96 ns | 1,678.376 ns | 1,310.365 ns | 735,634.50 ns |         - |
|                                                   |              |               |              |              |               |           |
| Encrypt · AES-192-GCM (OS)                        | 128KB        |  20,899.83 ns |   411.526 ns |   384.942 ns |  20,707.83 ns |         - |
| Encrypt · AES-192-GCM (CryptoHives-ARM-AES+PMULL) | 128KB        |  35,752.65 ns |   695.766 ns | 1,323.767 ns |  34,988.54 ns |         - |
| Encrypt · AES-192-GCM (BouncyCastle)              | 128KB        | 611,781.57 ns |   194.371 ns |   162.309 ns | 611,802.98 ns |    1624 B |
| Encrypt · AES-192-GCM (CryptoHives-Scalar)        | 128KB        | 734,103.18 ns |   232.459 ns |   181.489 ns | 734,061.14 ns |         - |