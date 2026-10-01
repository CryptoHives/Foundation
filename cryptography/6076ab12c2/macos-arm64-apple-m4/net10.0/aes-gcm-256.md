| Description                                       | TestDataSize | Mean          | Error        | StdDev       | Median        | Allocated |
|-------------------------------------------------- |------------- |--------------:|-------------:|-------------:|--------------:|----------:|
| Decrypt · AES-256-GCM (CryptoHives-ARM-AES+PMULL) | 17B          |      85.14 ns |     0.494 ns |     0.438 ns |      85.05 ns |         - |
| Decrypt · AES-256-GCM (CryptoHives-Scalar)        | 17B          |     401.77 ns |     2.184 ns |     1.936 ns |     401.43 ns |         - |
| Decrypt · AES-256-GCM (BouncyCastle)              | 17B          |     616.57 ns |    13.604 ns |    39.898 ns |     593.72 ns |    1744 B |
| Decrypt · AES-256-GCM (OS)                        | 17B          |   1,913.07 ns |    26.080 ns |    21.778 ns |   1,915.85 ns |         - |
|                                                   |              |               |              |              |               |           |
| Encrypt · AES-256-GCM (CryptoHives-ARM-AES+PMULL) | 17B          |      55.56 ns |     0.111 ns |     0.093 ns |      55.56 ns |         - |
| Encrypt · AES-256-GCM (CryptoHives-Scalar)        | 17B          |     362.96 ns |     2.558 ns |     2.267 ns |     363.80 ns |         - |
| Encrypt · AES-256-GCM (BouncyCastle)              | 17B          |     516.36 ns |     2.254 ns |     2.108 ns |     516.16 ns |    1728 B |
| Encrypt · AES-256-GCM (OS)                        | 17B          |   1,720.76 ns |    31.209 ns |    29.193 ns |   1,714.09 ns |         - |
|                                                   |              |               |              |              |               |           |
| Decrypt · AES-256-GCM (CryptoHives-ARM-AES+PMULL) | 65B          |      93.96 ns |     0.228 ns |     0.202 ns |      94.02 ns |         - |
| Decrypt · AES-256-GCM (CryptoHives-Scalar)        | 65B          |     717.83 ns |    12.720 ns |    11.276 ns |     714.39 ns |         - |
| Decrypt · AES-256-GCM (BouncyCastle)              | 65B          |     838.44 ns |     7.410 ns |     6.187 ns |     838.29 ns |    1744 B |
| Decrypt · AES-256-GCM (OS)                        | 65B          |   1,925.31 ns |    36.587 ns |    34.223 ns |   1,914.03 ns |         - |
|                                                   |              |               |              |              |               |           |
| Encrypt · AES-256-GCM (CryptoHives-ARM-AES+PMULL) | 65B          |      64.03 ns |     0.383 ns |     0.340 ns |      64.01 ns |         - |
| Encrypt · AES-256-GCM (CryptoHives-Scalar)        | 65B          |     668.95 ns |     5.365 ns |     5.018 ns |     668.09 ns |         - |
| Encrypt · AES-256-GCM (BouncyCastle)              | 65B          |     779.81 ns |     9.264 ns |    14.146 ns |     776.09 ns |    1728 B |
| Encrypt · AES-256-GCM (OS)                        | 65B          |   1,691.29 ns |    12.551 ns |    11.740 ns |   1,688.09 ns |         - |
|                                                   |              |               |              |              |               |           |
| Decrypt · AES-256-GCM (CryptoHives-ARM-AES+PMULL) | 128B         |      95.84 ns |     0.291 ns |     0.273 ns |      95.90 ns |         - |
| Decrypt · AES-256-GCM (CryptoHives-Scalar)        | 128B         |   1,014.17 ns |     5.363 ns |     4.754 ns |   1,015.07 ns |         - |
| Decrypt · AES-256-GCM (BouncyCastle)              | 128B         |   1,089.92 ns |     0.728 ns |     0.646 ns |   1,089.95 ns |    1744 B |
| Decrypt · AES-256-GCM (OS)                        | 128B         |   1,964.99 ns |     7.779 ns |     7.276 ns |   1,966.95 ns |         - |
|                                                   |              |               |              |              |               |           |
| Encrypt · AES-256-GCM (CryptoHives-ARM-AES+PMULL) | 128B         |      68.48 ns |     0.391 ns |     0.366 ns |      68.31 ns |         - |
| Encrypt · AES-256-GCM (CryptoHives-Scalar)        | 128B         |     976.03 ns |    10.605 ns |     9.920 ns |     977.31 ns |         - |
| Encrypt · AES-256-GCM (BouncyCastle)              | 128B         |   1,041.93 ns |     4.401 ns |     4.117 ns |   1,041.66 ns |    1728 B |
| Encrypt · AES-256-GCM (OS)                        | 128B         |   1,742.89 ns |     7.989 ns |     6.671 ns |   1,742.98 ns |         - |
|                                                   |              |               |              |              |               |           |
| Decrypt · AES-256-GCM (CryptoHives-ARM-AES+PMULL) | 152B         |     127.46 ns |     0.138 ns |     0.108 ns |     127.46 ns |         - |
| Decrypt · AES-256-GCM (BouncyCastle)              | 152B         |   1,226.11 ns |     0.668 ns |     0.592 ns |   1,226.06 ns |    1744 B |
| Decrypt · AES-256-GCM (CryptoHives-Scalar)        | 152B         |   1,243.68 ns |     5.416 ns |     5.066 ns |   1,243.07 ns |         - |
| Decrypt · AES-256-GCM (OS)                        | 152B         |   1,916.75 ns |    14.351 ns |    11.984 ns |   1,919.71 ns |         - |
|                                                   |              |               |              |              |               |           |
| Encrypt · AES-256-GCM (CryptoHives-ARM-AES+PMULL) | 152B         |      87.58 ns |     1.782 ns |     2.499 ns |      87.83 ns |         - |
| Encrypt · AES-256-GCM (CryptoHives-Scalar)        | 152B         |   1,177.29 ns |    12.683 ns |    10.591 ns |   1,178.81 ns |         - |
| Encrypt · AES-256-GCM (BouncyCastle)              | 152B         |   1,198.78 ns |    13.769 ns |    12.880 ns |   1,191.83 ns |    1728 B |
| Encrypt · AES-256-GCM (OS)                        | 152B         |   1,696.16 ns |    16.623 ns |    15.549 ns |   1,696.04 ns |         - |
|                                                   |              |               |              |              |               |           |
| Decrypt · AES-256-GCM (CryptoHives-ARM-AES+PMULL) | 256B         |     132.46 ns |     0.433 ns |     0.338 ns |     132.47 ns |         - |
| Decrypt · AES-256-GCM (BouncyCastle)              | 256B         |   1,701.68 ns |     2.851 ns |     2.226 ns |   1,701.40 ns |    1744 B |
| Decrypt · AES-256-GCM (CryptoHives-Scalar)        | 256B         |   1,855.41 ns |    12.164 ns |    11.378 ns |   1,853.65 ns |         - |
| Decrypt · AES-256-GCM (OS)                        | 256B         |   1,961.61 ns |     8.955 ns |     8.376 ns |   1,961.33 ns |         - |
|                                                   |              |               |              |              |               |           |
| Encrypt · AES-256-GCM (CryptoHives-ARM-AES+PMULL) | 256B         |      94.94 ns |     0.532 ns |     0.472 ns |      95.03 ns |         - |
| Encrypt · AES-256-GCM (BouncyCastle)              | 256B         |   1,710.60 ns |     7.063 ns |     6.607 ns |   1,710.02 ns |    1728 B |
| Encrypt · AES-256-GCM (OS)                        | 256B         |   1,741.39 ns |    10.090 ns |     8.944 ns |   1,745.13 ns |         - |
| Encrypt · AES-256-GCM (CryptoHives-Scalar)        | 256B         |   1,821.96 ns |    17.649 ns |    16.509 ns |   1,824.37 ns |         - |
|                                                   |              |               |              |              |               |           |
| Decrypt · AES-256-GCM (CryptoHives-ARM-AES+PMULL) | 1KB          |     383.26 ns |     2.011 ns |     1.881 ns |     383.31 ns |         - |
| Decrypt · AES-256-GCM (OS)                        | 1KB          |   2,076.50 ns |    12.167 ns |    11.381 ns |   2,074.92 ns |         - |
| Decrypt · AES-256-GCM (BouncyCastle)              | 1KB          |   5,430.47 ns |     2.536 ns |     2.248 ns |   5,431.30 ns |    1744 B |
| Decrypt · AES-256-GCM (CryptoHives-Scalar)        | 1KB          |   6,653.73 ns |    35.677 ns |    33.373 ns |   6,663.54 ns |         - |
|                                                   |              |               |              |              |               |           |
| Encrypt · AES-256-GCM (CryptoHives-ARM-AES+PMULL) | 1KB          |     309.59 ns |     3.993 ns |     3.117 ns |     310.57 ns |         - |
| Encrypt · AES-256-GCM (OS)                        | 1KB          |   1,878.60 ns |    10.712 ns |     8.945 ns |   1,878.07 ns |         - |
| Encrypt · AES-256-GCM (BouncyCastle)              | 1KB          |   5,764.63 ns |    33.697 ns |    31.520 ns |   5,776.53 ns |    1728 B |
| Encrypt · AES-256-GCM (CryptoHives-Scalar)        | 1KB          |   6,398.00 ns |    29.212 ns |    24.393 ns |   6,400.08 ns |         - |
|                                                   |              |               |              |              |               |           |
| Decrypt · AES-256-GCM (CryptoHives-ARM-AES+PMULL) | 8KB          |   2,361.32 ns |     5.283 ns |     4.412 ns |   2,359.60 ns |         - |
| Decrypt · AES-256-GCM (OS)                        | 8KB          |   3,156.18 ns |    12.559 ns |    11.133 ns |   3,157.23 ns |         - |
| Decrypt · AES-256-GCM (BouncyCastle)              | 8KB          |  40,547.13 ns |    23.257 ns |    21.755 ns |  40,546.90 ns |    1744 B |
| Decrypt · AES-256-GCM (CryptoHives-Scalar)        | 8KB          |  51,686.34 ns |   145.912 ns |   136.486 ns |  51,699.60 ns |         - |
|                                                   |              |               |              |              |               |           |
| Encrypt · AES-256-GCM (CryptoHives-ARM-AES+PMULL) | 8KB          |   2,310.64 ns |     6.108 ns |     5.714 ns |   2,307.41 ns |         - |
| Encrypt · AES-256-GCM (OS)                        | 8KB          |   2,963.27 ns |    28.468 ns |    25.236 ns |   2,962.78 ns |         - |
| Encrypt · AES-256-GCM (BouncyCastle)              | 8KB          |  42,490.26 ns |    14.415 ns |    12.778 ns |  42,490.54 ns |    1728 B |
| Encrypt · AES-256-GCM (CryptoHives-Scalar)        | 8KB          |  49,811.61 ns |    37.337 ns |    31.178 ns |  49,819.15 ns |         - |
|                                                   |              |               |              |              |               |           |
| Decrypt · AES-256-GCM (OS)                        | 128KB        |  20,998.61 ns |    42.147 ns |    37.362 ns |  20,985.80 ns |         - |
| Decrypt · AES-256-GCM (CryptoHives-ARM-AES+PMULL) | 128KB        |  38,544.16 ns |   760.687 ns | 1,390.960 ns |  37,985.22 ns |         - |
| Decrypt · AES-256-GCM (BouncyCastle)              | 128KB        | 643,456.25 ns |   261.468 ns |   244.577 ns | 643,474.28 ns |    1744 B |
| Decrypt · AES-256-GCM (CryptoHives-Scalar)        | 128KB        | 821,695.87 ns | 2,251.346 ns | 2,105.911 ns | 822,086.79 ns |         - |
|                                                   |              |               |              |              |               |           |
| Encrypt · AES-256-GCM (OS)                        | 128KB        |  21,772.71 ns |    79.018 ns |    61.692 ns |  21,771.25 ns |         - |
| Encrypt · AES-256-GCM (CryptoHives-ARM-AES+PMULL) | 128KB        |  37,162.04 ns |   733.484 ns | 1,004.001 ns |  36,619.25 ns |         - |
| Encrypt · AES-256-GCM (BouncyCastle)              | 128KB        | 678,056.86 ns |   278.094 ns |   232.221 ns | 678,023.97 ns |    1728 B |
| Encrypt · AES-256-GCM (CryptoHives-Scalar)        | 128KB        | 805,456.71 ns | 1,417.599 ns | 1,106.768 ns | 805,548.83 ns |         - |