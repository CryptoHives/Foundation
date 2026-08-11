| Description                                       | TestDataSize | Mean          | Error         | StdDev        | Allocated |
|-------------------------------------------------- |------------- |--------------:|--------------:|--------------:|----------:|
| Decrypt · AES-256-GCM (CryptoHives-ARM-AES+PMULL) | 17B          |      83.76 ns |      1.643 ns |      1.614 ns |         - |
| Decrypt · AES-256-GCM (CryptoHives-Scalar)        | 17B          |     398.41 ns |      5.315 ns |      4.971 ns |         - |
| Decrypt · AES-256-GCM (BouncyCastle)              | 17B          |     588.24 ns |      1.091 ns |      0.852 ns |    1744 B |
| Decrypt · AES-256-GCM (OS)                        | 17B          |   1,917.25 ns |     15.657 ns |     12.224 ns |         - |
|                                                   |              |               |               |               |           |
| Encrypt · AES-256-GCM (CryptoHives-ARM-AES+PMULL) | 17B          |      55.45 ns |      0.568 ns |      0.531 ns |         - |
| Encrypt · AES-256-GCM (CryptoHives-Scalar)        | 17B          |     360.73 ns |      4.008 ns |      3.346 ns |         - |
| Encrypt · AES-256-GCM (BouncyCastle)              | 17B          |     515.69 ns |      0.587 ns |      0.458 ns |    1728 B |
| Encrypt · AES-256-GCM (OS)                        | 17B          |   1,745.47 ns |     22.609 ns |     21.149 ns |         - |
|                                                   |              |               |               |               |           |
| Decrypt · AES-256-GCM (CryptoHives-ARM-AES+PMULL) | 65B          |     120.14 ns |      0.556 ns |      0.434 ns |         - |
| Decrypt · AES-256-GCM (CryptoHives-Scalar)        | 65B          |     709.95 ns |      9.725 ns |      9.097 ns |         - |
| Decrypt · AES-256-GCM (BouncyCastle)              | 65B          |     834.39 ns |     11.776 ns |     11.015 ns |    1744 B |
| Decrypt · AES-256-GCM (OS)                        | 65B          |   1,906.57 ns |     13.741 ns |     10.728 ns |         - |
|                                                   |              |               |               |               |           |
| Encrypt · AES-256-GCM (CryptoHives-ARM-AES+PMULL) | 65B          |      88.25 ns |      1.058 ns |      0.989 ns |         - |
| Encrypt · AES-256-GCM (CryptoHives-Scalar)        | 65B          |     669.96 ns |     10.309 ns |      9.643 ns |         - |
| Encrypt · AES-256-GCM (BouncyCastle)              | 65B          |     775.05 ns |     11.315 ns |     10.030 ns |    1728 B |
| Encrypt · AES-256-GCM (OS)                        | 65B          |   1,744.50 ns |     22.929 ns |     21.448 ns |         - |
|                                                   |              |               |               |               |           |
| Decrypt · AES-256-GCM (CryptoHives-ARM-AES+PMULL) | 128B         |     163.42 ns |      2.065 ns |      1.932 ns |         - |
| Decrypt · AES-256-GCM (CryptoHives-Scalar)        | 128B         |   1,013.10 ns |      2.107 ns |      1.645 ns |         - |
| Decrypt · AES-256-GCM (BouncyCastle)              | 128B         |   1,076.85 ns |      2.453 ns |      1.915 ns |    1744 B |
| Decrypt · AES-256-GCM (OS)                        | 128B         |   1,948.90 ns |     12.992 ns |     10.144 ns |         - |
|                                                   |              |               |               |               |           |
| Encrypt · AES-256-GCM (CryptoHives-ARM-AES+PMULL) | 128B         |     122.07 ns |      0.442 ns |      0.345 ns |         - |
| Encrypt · AES-256-GCM (CryptoHives-Scalar)        | 128B         |     966.12 ns |      2.300 ns |      1.796 ns |         - |
| Encrypt · AES-256-GCM (BouncyCastle)              | 128B         |   1,032.63 ns |      2.805 ns |      2.190 ns |    1728 B |
| Encrypt · AES-256-GCM (OS)                        | 128B         |   1,781.07 ns |     22.851 ns |     21.374 ns |         - |
|                                                   |              |               |               |               |           |
| Decrypt · AES-256-GCM (CryptoHives-ARM-AES+PMULL) | 152B         |     199.29 ns |      2.788 ns |      2.608 ns |         - |
| Decrypt · AES-256-GCM (CryptoHives-Scalar)        | 152B         |   1,220.41 ns |      4.913 ns |      3.836 ns |         - |
| Decrypt · AES-256-GCM (BouncyCastle)              | 152B         |   1,237.06 ns |     23.815 ns |     22.277 ns |    1744 B |
| Decrypt · AES-256-GCM (OS)                        | 152B         |   1,936.87 ns |     16.352 ns |     13.655 ns |         - |
|                                                   |              |               |               |               |           |
| Encrypt · AES-256-GCM (CryptoHives-ARM-AES+PMULL) | 152B         |     153.03 ns |      0.500 ns |      0.390 ns |         - |
| Encrypt · AES-256-GCM (CryptoHives-Scalar)        | 152B         |   1,179.32 ns |     19.616 ns |     17.389 ns |         - |
| Encrypt · AES-256-GCM (BouncyCastle)              | 152B         |   1,194.00 ns |      2.301 ns |      1.797 ns |    1728 B |
| Encrypt · AES-256-GCM (OS)                        | 152B         |   1,775.56 ns |     24.212 ns |     22.648 ns |         - |
|                                                   |              |               |               |               |           |
| Decrypt · AES-256-GCM (CryptoHives-ARM-AES+PMULL) | 256B         |     268.27 ns |      2.253 ns |      1.759 ns |         - |
| Decrypt · AES-256-GCM (BouncyCastle)              | 256B         |   1,716.33 ns |     24.387 ns |     22.811 ns |    1744 B |
| Decrypt · AES-256-GCM (CryptoHives-Scalar)        | 256B         |   1,838.45 ns |     21.838 ns |     20.427 ns |         - |
| Decrypt · AES-256-GCM (OS)                        | 256B         |   1,955.52 ns |     13.415 ns |     10.474 ns |         - |
|                                                   |              |               |               |               |           |
| Encrypt · AES-256-GCM (CryptoHives-ARM-AES+PMULL) | 256B         |     228.39 ns |      2.311 ns |      2.162 ns |         - |
| Encrypt · AES-256-GCM (BouncyCastle)              | 256B         |   1,718.69 ns |     25.355 ns |     23.717 ns |    1728 B |
| Encrypt · AES-256-GCM (OS)                        | 256B         |   1,783.75 ns |     24.050 ns |     22.497 ns |         - |
| Encrypt · AES-256-GCM (CryptoHives-Scalar)        | 256B         |   1,796.32 ns |     21.690 ns |     20.289 ns |         - |
|                                                   |              |               |               |               |           |
| Decrypt · AES-256-GCM (CryptoHives-ARM-AES+PMULL) | 1KB          |     882.31 ns |      8.360 ns |      7.820 ns |         - |
| Decrypt · AES-256-GCM (OS)                        | 1KB          |   2,097.86 ns |      7.288 ns |      5.690 ns |         - |
| Decrypt · AES-256-GCM (BouncyCastle)              | 1KB          |   5,477.18 ns |     93.223 ns |     87.201 ns |    1744 B |
| Decrypt · AES-256-GCM (CryptoHives-Scalar)        | 1KB          |   6,666.25 ns |     85.784 ns |     80.243 ns |         - |
|                                                   |              |               |               |               |           |
| Encrypt · AES-256-GCM (CryptoHives-ARM-AES+PMULL) | 1KB          |     851.57 ns |      9.895 ns |      9.256 ns |         - |
| Encrypt · AES-256-GCM (OS)                        | 1KB          |   1,918.27 ns |      8.173 ns |      6.381 ns |         - |
| Encrypt · AES-256-GCM (BouncyCastle)              | 1KB          |   5,731.81 ns |     89.858 ns |     84.053 ns |    1728 B |
| Encrypt · AES-256-GCM (CryptoHives-Scalar)        | 1KB          |   6,535.68 ns |     83.128 ns |     77.758 ns |         - |
|                                                   |              |               |               |               |           |
| Decrypt · AES-256-GCM (OS)                        | 8KB          |   3,101.11 ns |     39.357 ns |     36.814 ns |         - |
| Decrypt · AES-256-GCM (CryptoHives-ARM-AES+PMULL) | 8KB          |   6,611.78 ns |     62.233 ns |     58.212 ns |         - |
| Decrypt · AES-256-GCM (BouncyCastle)              | 8KB          |  40,482.76 ns |    761.581 ns |    712.383 ns |    1744 B |
| Decrypt · AES-256-GCM (CryptoHives-Scalar)        | 8KB          |  51,413.20 ns |    666.848 ns |    623.770 ns |         - |
|                                                   |              |               |               |               |           |
| Encrypt · AES-256-GCM (OS)                        | 8KB          |   2,974.80 ns |     44.599 ns |     41.718 ns |         - |
| Encrypt · AES-256-GCM (CryptoHives-ARM-AES+PMULL) | 8KB          |   6,597.98 ns |     80.655 ns |     75.445 ns |         - |
| Encrypt · AES-256-GCM (BouncyCastle)              | 8KB          |  42,888.55 ns |    664.370 ns |    621.453 ns |    1728 B |
| Encrypt · AES-256-GCM (CryptoHives-Scalar)        | 8KB          |  51,297.15 ns |    713.106 ns |    667.040 ns |         - |
|                                                   |              |               |               |               |           |
| Decrypt · AES-256-GCM (OS)                        | 128KB        |  21,104.41 ns |    318.283 ns |    297.722 ns |         - |
| Decrypt · AES-256-GCM (CryptoHives-ARM-AES+PMULL) | 128KB        | 106,066.88 ns |  1,486.790 ns |  1,390.744 ns |         - |
| Decrypt · AES-256-GCM (BouncyCastle)              | 128KB        | 643,673.18 ns | 10,793.305 ns | 10,096.064 ns |    1744 B |
| Decrypt · AES-256-GCM (CryptoHives-Scalar)        | 128KB        | 848,506.41 ns | 10,793.039 ns |  9,567.748 ns |         - |
|                                                   |              |               |               |               |           |
| Encrypt · AES-256-GCM (OS)                        | 128KB        |  21,692.75 ns |    344.286 ns |    305.201 ns |         - |
| Encrypt · AES-256-GCM (CryptoHives-ARM-AES+PMULL) | 128KB        | 107,037.05 ns |  2,120.193 ns |  1,983.230 ns |         - |
| Encrypt · AES-256-GCM (BouncyCastle)              | 128KB        | 682,282.88 ns | 10,987.076 ns | 10,277.318 ns |    1728 B |
| Encrypt · AES-256-GCM (CryptoHives-Scalar)        | 128KB        | 817,124.38 ns | 10,660.588 ns |  9,971.921 ns |         - |