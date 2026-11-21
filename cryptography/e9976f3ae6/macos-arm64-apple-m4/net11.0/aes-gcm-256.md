| Description                                       | TestDataSize | Mean          | Error        | StdDev       | Median        | Allocated |
|-------------------------------------------------- |------------- |--------------:|-------------:|-------------:|--------------:|----------:|
| Decrypt · AES-256-GCM (CryptoHives-ARM-AES+PMULL) | 17B          |      87.93 ns |     0.342 ns |     0.320 ns |      88.02 ns |         - |
| Decrypt · AES-256-GCM (CryptoHives-Scalar)        | 17B          |     402.36 ns |     0.989 ns |     0.925 ns |     402.07 ns |         - |
| Decrypt · AES-256-GCM (BouncyCastle)              | 17B          |     593.07 ns |     1.053 ns |     0.985 ns |     593.11 ns |    1744 B |
| Decrypt · AES-256-GCM (OS)                        | 17B          |   1,905.64 ns |    10.330 ns |     9.157 ns |   1,905.25 ns |         - |
|                                                   |              |               |              |              |               |           |
| Encrypt · AES-256-GCM (CryptoHives-ARM-AES+PMULL) | 17B          |      55.42 ns |     0.184 ns |     0.172 ns |      55.43 ns |         - |
| Encrypt · AES-256-GCM (CryptoHives-Scalar)        | 17B          |     364.09 ns |     0.833 ns |     0.779 ns |     364.05 ns |         - |
| Encrypt · AES-256-GCM (BouncyCastle)              | 17B          |     515.86 ns |     0.994 ns |     0.930 ns |     515.81 ns |    1728 B |
| Encrypt · AES-256-GCM (OS)                        | 17B          |   1,487.15 ns |     3.254 ns |     2.885 ns |   1,486.45 ns |         - |
|                                                   |              |               |              |              |               |           |
| Decrypt · AES-256-GCM (CryptoHives-ARM-AES+PMULL) | 65B          |      94.87 ns |     0.218 ns |     0.193 ns |      94.90 ns |         - |
| Decrypt · AES-256-GCM (CryptoHives-Scalar)        | 65B          |     734.89 ns |     1.276 ns |     1.193 ns |     734.62 ns |         - |
| Decrypt · AES-256-GCM (BouncyCastle)              | 65B          |     826.71 ns |     1.323 ns |     1.237 ns |     826.51 ns |    1744 B |
| Decrypt · AES-256-GCM (OS)                        | 65B          |   1,931.27 ns |     9.832 ns |     9.197 ns |   1,930.16 ns |         - |
|                                                   |              |               |              |              |               |           |
| Encrypt · AES-256-GCM (CryptoHives-ARM-AES+PMULL) | 65B          |      63.21 ns |     0.259 ns |     0.242 ns |      63.15 ns |         - |
| Encrypt · AES-256-GCM (CryptoHives-Scalar)        | 65B          |     643.44 ns |     2.085 ns |     1.848 ns |     644.09 ns |         - |
| Encrypt · AES-256-GCM (BouncyCastle)              | 65B          |     759.92 ns |     0.967 ns |     0.858 ns |     759.96 ns |    1728 B |
| Encrypt · AES-256-GCM (OS)                        | 65B          |   1,480.38 ns |     4.801 ns |     4.491 ns |   1,479.34 ns |         - |
|                                                   |              |               |              |              |               |           |
| Decrypt · AES-256-GCM (CryptoHives-ARM-AES+PMULL) | 128B         |      88.78 ns |     0.183 ns |     0.162 ns |      88.71 ns |         - |
| Decrypt · AES-256-GCM (BouncyCastle)              | 128B         |   1,063.18 ns |     1.133 ns |     1.060 ns |   1,063.38 ns |    1744 B |
| Decrypt · AES-256-GCM (CryptoHives-Scalar)        | 128B         |   1,070.68 ns |     4.662 ns |     4.361 ns |   1,071.05 ns |         - |
| Decrypt · AES-256-GCM (OS)                        | 128B         |   1,911.23 ns |    12.381 ns |    11.581 ns |   1,907.37 ns |         - |
|                                                   |              |               |              |              |               |           |
| Encrypt · AES-256-GCM (CryptoHives-ARM-AES+PMULL) | 128B         |      65.73 ns |     0.242 ns |     0.215 ns |      65.74 ns |         - |
| Encrypt · AES-256-GCM (CryptoHives-Scalar)        | 128B         |     941.44 ns |     0.828 ns |     0.775 ns |     941.46 ns |         - |
| Encrypt · AES-256-GCM (BouncyCastle)              | 128B         |   1,005.74 ns |     1.216 ns |     1.137 ns |   1,005.74 ns |    1728 B |
| Encrypt · AES-256-GCM (OS)                        | 128B         |   1,512.53 ns |     4.869 ns |     4.555 ns |   1,513.12 ns |         - |
|                                                   |              |               |              |              |               |           |
| Decrypt · AES-256-GCM (CryptoHives-ARM-AES+PMULL) | 152B         |     117.44 ns |     0.196 ns |     0.183 ns |     117.46 ns |         - |
| Decrypt · AES-256-GCM (BouncyCastle)              | 152B         |   1,215.78 ns |     2.254 ns |     2.109 ns |   1,216.68 ns |    1744 B |
| Decrypt · AES-256-GCM (CryptoHives-Scalar)        | 152B         |   1,295.37 ns |     6.718 ns |     6.284 ns |   1,295.48 ns |         - |
| Decrypt · AES-256-GCM (OS)                        | 152B         |   1,916.37 ns |    14.510 ns |    13.573 ns |   1,917.65 ns |         - |
|                                                   |              |               |              |              |               |           |
| Encrypt · AES-256-GCM (CryptoHives-ARM-AES+PMULL) | 152B         |      87.62 ns |     0.310 ns |     0.290 ns |      87.62 ns |         - |
| Encrypt · AES-256-GCM (BouncyCastle)              | 152B         |   1,162.34 ns |     1.709 ns |     1.599 ns |   1,162.37 ns |    1728 B |
| Encrypt · AES-256-GCM (CryptoHives-Scalar)        | 152B         |   1,238.10 ns |     7.985 ns |     7.469 ns |   1,237.83 ns |         - |
| Encrypt · AES-256-GCM (OS)                        | 152B         |   1,514.04 ns |     4.066 ns |     3.395 ns |   1,513.35 ns |         - |
|                                                   |              |               |              |              |               |           |
| Decrypt · AES-256-GCM (CryptoHives-ARM-AES+PMULL) | 256B         |     131.34 ns |     0.454 ns |     0.424 ns |     131.16 ns |         - |
| Decrypt · AES-256-GCM (BouncyCastle)              | 256B         |   1,682.58 ns |     1.777 ns |     1.662 ns |   1,682.53 ns |    1744 B |
| Decrypt · AES-256-GCM (CryptoHives-Scalar)        | 256B         |   1,845.97 ns |     4.666 ns |     3.896 ns |   1,847.24 ns |         - |
| Decrypt · AES-256-GCM (OS)                        | 256B         |   1,940.14 ns |     9.268 ns |     8.669 ns |   1,941.99 ns |         - |
|                                                   |              |               |              |              |               |           |
| Encrypt · AES-256-GCM (CryptoHives-ARM-AES+PMULL) | 256B         |      93.07 ns |     0.254 ns |     0.237 ns |      93.14 ns |         - |
| Encrypt · AES-256-GCM (OS)                        | 256B         |   1,560.23 ns |     8.104 ns |     7.580 ns |   1,559.33 ns |         - |
| Encrypt · AES-256-GCM (BouncyCastle)              | 256B         |   1,626.98 ns |     0.560 ns |     0.467 ns |   1,627.00 ns |    1728 B |
| Encrypt · AES-256-GCM (CryptoHives-Scalar)        | 256B         |   1,800.71 ns |    11.738 ns |    10.406 ns |   1,803.54 ns |         - |
|                                                   |              |               |              |              |               |           |
| Decrypt · AES-256-GCM (CryptoHives-ARM-AES+PMULL) | 1KB          |     330.33 ns |     0.802 ns |     0.711 ns |     330.47 ns |         - |
| Decrypt · AES-256-GCM (OS)                        | 1KB          |   2,069.69 ns |    14.786 ns |    13.830 ns |   2,070.02 ns |         - |
| Decrypt · AES-256-GCM (BouncyCastle)              | 1KB          |   5,349.30 ns |     6.464 ns |     6.046 ns |   5,350.90 ns |    1744 B |
| Decrypt · AES-256-GCM (CryptoHives-Scalar)        | 1KB          |   7,113.74 ns |    24.541 ns |    22.955 ns |   7,112.24 ns |         - |
|                                                   |              |               |              |              |               |           |
| Encrypt · AES-256-GCM (CryptoHives-ARM-AES+PMULL) | 1KB          |     290.50 ns |     1.038 ns |     0.971 ns |     290.42 ns |         - |
| Encrypt · AES-256-GCM (OS)                        | 1KB          |   1,638.90 ns |     6.471 ns |     6.053 ns |   1,638.93 ns |         - |
| Encrypt · AES-256-GCM (BouncyCastle)              | 1KB          |   5,394.64 ns |     4.326 ns |     3.378 ns |   5,395.22 ns |    1728 B |
| Encrypt · AES-256-GCM (CryptoHives-Scalar)        | 1KB          |   7,953.22 ns |    45.539 ns |    42.597 ns |   7,937.43 ns |         - |
|                                                   |              |               |              |              |               |           |
| Decrypt · AES-256-GCM (CryptoHives-ARM-AES+PMULL) | 8KB          |   2,154.49 ns |     8.246 ns |     7.713 ns |   2,154.95 ns |         - |
| Decrypt · AES-256-GCM (OS)                        | 8KB          |   3,033.45 ns |     8.986 ns |     8.406 ns |   3,033.59 ns |         - |
| Decrypt · AES-256-GCM (BouncyCastle)              | 8KB          |  39,491.94 ns |    51.141 ns |    47.837 ns |  39,498.76 ns |    1744 B |
| Decrypt · AES-256-GCM (CryptoHives-Scalar)        | 8KB          |  49,775.27 ns |    43.841 ns |    41.009 ns |  49,762.15 ns |         - |
|                                                   |              |               |              |              |               |           |
| Encrypt · AES-256-GCM (CryptoHives-ARM-AES+PMULL) | 8KB          |   2,133.40 ns |     9.452 ns |     8.842 ns |   2,136.33 ns |         - |
| Encrypt · AES-256-GCM (OS)                        | 8KB          |   2,602.55 ns |    16.893 ns |    15.802 ns |   2,602.58 ns |         - |
| Encrypt · AES-256-GCM (BouncyCastle)              | 8KB          |  40,847.48 ns |    42.155 ns |    39.432 ns |  40,857.09 ns |    1728 B |
| Encrypt · AES-256-GCM (CryptoHives-Scalar)        | 8KB          |  49,473.10 ns |    76.168 ns |    71.248 ns |  49,477.10 ns |         - |
|                                                   |              |               |              |              |               |           |
| Decrypt · AES-256-GCM (OS)                        | 128KB        |  20,529.84 ns |    65.055 ns |    60.852 ns |  20,528.06 ns |         - |
| Decrypt · AES-256-GCM (CryptoHives-ARM-AES+PMULL) | 128KB        |  35,686.97 ns |   856.199 ns | 2,511.085 ns |  34,317.06 ns |         - |
| Decrypt · AES-256-GCM (BouncyCastle)              | 128KB        | 625,087.82 ns |   932.092 ns |   871.879 ns | 625,288.98 ns |    1744 B |
| Decrypt · AES-256-GCM (CryptoHives-Scalar)        | 128KB        | 856,297.65 ns | 3,463.889 ns | 3,240.124 ns | 856,425.74 ns |         - |
|                                                   |              |               |              |              |               |           |
| Encrypt · AES-256-GCM (OS)                        | 128KB        |  25,634.52 ns |   166.590 ns |   155.828 ns |  25,633.98 ns |         - |
| Encrypt · AES-256-GCM (CryptoHives-ARM-AES+PMULL) | 128KB        |  33,492.80 ns |    95.762 ns |    89.575 ns |  33,510.97 ns |         - |
| Encrypt · AES-256-GCM (BouncyCastle)              | 128KB        | 649,497.65 ns |   601.264 ns |   562.422 ns | 649,616.78 ns |    1728 B |
| Encrypt · AES-256-GCM (CryptoHives-Scalar)        | 128KB        | 842,593.32 ns | 9,793.878 ns | 9,161.199 ns | 845,682.62 ns |         - |