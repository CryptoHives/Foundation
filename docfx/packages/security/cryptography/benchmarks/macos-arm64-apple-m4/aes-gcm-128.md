| Description                                       | TestDataSize | Mean            | Error        | StdDev       | Allocated |
|-------------------------------------------------- |------------- |----------------:|-------------:|-------------:|----------:|
| Decrypt · AES-128-GCM (CryptoHives-ARM-AES+PMULL) | 17B          |       389.43 ns |     3.280 ns |     3.068 ns |         - |
| Decrypt · AES-128-GCM (CryptoHives-Scalar)        | 17B          |     1,638.59 ns |     4.881 ns |     4.327 ns |         - |
| Decrypt · AES-128-GCM (BouncyCastle)              | 17B          |     2,699.87 ns |     2.009 ns |     1.678 ns |    1536 B |
| Decrypt · AES-128-GCM (OS)                        | 17B          |     8,929.34 ns |    89.738 ns |    79.550 ns |         - |
|                                                   |              |                 |              |              |           |
| Encrypt · AES-128-GCM (CryptoHives-ARM-AES+PMULL) | 17B          |        65.32 ns |     0.204 ns |     0.181 ns |         - |
| Encrypt · AES-128-GCM (CryptoHives-Scalar)        | 17B          |     1,492.51 ns |     4.913 ns |     4.355 ns |         - |
| Encrypt · AES-128-GCM (BouncyCastle)              | 17B          |     2,332.59 ns |     4.123 ns |     3.443 ns |    1520 B |
| Encrypt · AES-128-GCM (OS)                        | 17B          |     7,954.80 ns |    35.601 ns |    31.559 ns |         - |
|                                                   |              |                 |              |              |           |
| Decrypt · AES-128-GCM (CryptoHives-ARM-AES+PMULL) | 65B          |       552.80 ns |     1.273 ns |     1.063 ns |         - |
| Decrypt · AES-128-GCM (CryptoHives-Scalar)        | 65B          |     2,867.56 ns |     3.519 ns |     3.120 ns |         - |
| Decrypt · AES-128-GCM (BouncyCastle)              | 65B          |     3,626.11 ns |     6.691 ns |     6.259 ns |    1536 B |
| Decrypt · AES-128-GCM (OS)                        | 65B          |     8,821.32 ns |    67.076 ns |    59.461 ns |         - |
|                                                   |              |                 |              |              |           |
| Encrypt · AES-128-GCM (CryptoHives-ARM-AES+PMULL) | 65B          |       407.28 ns |     0.229 ns |     0.179 ns |         - |
| Encrypt · AES-128-GCM (CryptoHives-Scalar)        | 65B          |     2,704.24 ns |     3.921 ns |     3.668 ns |         - |
| Encrypt · AES-128-GCM (BouncyCastle)              | 65B          |     3,340.67 ns |     5.560 ns |     5.201 ns |    1520 B |
| Encrypt · AES-128-GCM (OS)                        | 65B          |     7,976.92 ns |    40.196 ns |    31.383 ns |         - |
|                                                   |              |                 |              |              |           |
| Decrypt · AES-128-GCM (CryptoHives-ARM-AES+PMULL) | 128B         |       727.20 ns |     5.243 ns |     4.904 ns |         - |
| Decrypt · AES-128-GCM (CryptoHives-Scalar)        | 128B         |     4,066.16 ns |     4.142 ns |     3.875 ns |         - |
| Decrypt · AES-128-GCM (BouncyCastle)              | 128B         |     4,559.98 ns |     4.211 ns |     3.288 ns |    1536 B |
| Decrypt · AES-128-GCM (OS)                        | 128B         |     8,866.51 ns |    47.055 ns |    41.713 ns |         - |
|                                                   |              |                 |              |              |           |
| Encrypt · AES-128-GCM (CryptoHives-ARM-AES+PMULL) | 128B         |       593.66 ns |     0.250 ns |     0.209 ns |         - |
| Encrypt · AES-128-GCM (CryptoHives-Scalar)        | 128B         |     3,941.76 ns |     2.220 ns |     1.733 ns |         - |
| Encrypt · AES-128-GCM (BouncyCastle)              | 128B         |     4,371.03 ns |     6.346 ns |     5.299 ns |    1520 B |
| Encrypt · AES-128-GCM (OS)                        | 128B         |     8,138.36 ns |    80.187 ns |    75.007 ns |         - |
|                                                   |              |                 |              |              |           |
| Decrypt · AES-128-GCM (CryptoHives-ARM-AES+PMULL) | 152B         |       903.42 ns |    14.675 ns |    13.727 ns |         - |
| Decrypt · AES-128-GCM (CryptoHives-Scalar)        | 152B         |     4,933.29 ns |     4.163 ns |     3.690 ns |         - |
| Decrypt · AES-128-GCM (BouncyCastle)              | 152B         |     5,166.28 ns |     7.061 ns |     6.260 ns |    1536 B |
| Decrypt · AES-128-GCM (OS)                        | 152B         |     8,954.32 ns |    47.750 ns |    42.329 ns |         - |
|                                                   |              |                 |              |              |           |
| Encrypt · AES-128-GCM (CryptoHives-ARM-AES+PMULL) | 152B         |       732.69 ns |     0.223 ns |     0.174 ns |         - |
| Encrypt · AES-128-GCM (CryptoHives-Scalar)        | 152B         |     4,709.54 ns |     7.031 ns |     6.232 ns |         - |
| Encrypt · AES-128-GCM (BouncyCastle)              | 152B         |     4,975.79 ns |    10.718 ns |     9.502 ns |    1520 B |
| Encrypt · AES-128-GCM (OS)                        | 152B         |     8,257.26 ns |   129.869 ns |   121.479 ns |         - |
|                                                   |              |                 |              |              |           |
| Decrypt · AES-128-GCM (CryptoHives-ARM-AES+PMULL) | 256B         |       250.03 ns |     5.113 ns |     6.087 ns |         - |
| Decrypt · AES-128-GCM (BouncyCastle)              | 256B         |     1,474.91 ns |     1.244 ns |     1.039 ns |    1536 B |
| Decrypt · AES-128-GCM (CryptoHives-Scalar)        | 256B         |     1,578.76 ns |    24.977 ns |    23.364 ns |         - |
| Decrypt · AES-128-GCM (OS)                        | 256B         |     1,851.45 ns |    14.041 ns |    12.447 ns |         - |
|                                                   |              |                 |              |              |           |
| Encrypt · AES-128-GCM (CryptoHives-ARM-AES+PMULL) | 256B         |     1,072.68 ns |     0.643 ns |     0.537 ns |         - |
| Encrypt · AES-128-GCM (BouncyCastle)              | 256B         |     6,919.93 ns |     4.011 ns |     3.350 ns |    1520 B |
| Encrypt · AES-128-GCM (CryptoHives-Scalar)        | 256B         |     7,247.23 ns |     2.920 ns |     2.280 ns |         - |
| Encrypt · AES-128-GCM (OS)                        | 256B         |     8,277.33 ns |   124.031 ns |   116.019 ns |         - |
|                                                   |              |                 |              |              |           |
| Decrypt · AES-128-GCM (CryptoHives-ARM-AES+PMULL) | 1KB          |       804.89 ns |     1.422 ns |     1.330 ns |         - |
| Decrypt · AES-128-GCM (OS)                        | 1KB          |     2,062.07 ns |    15.769 ns |    13.979 ns |         - |
| Decrypt · AES-128-GCM (BouncyCastle)              | 1KB          |     4,503.30 ns |     2.430 ns |     2.029 ns |    1536 B |
| Decrypt · AES-128-GCM (CryptoHives-Scalar)        | 1KB          |     5,624.93 ns |    16.460 ns |    12.851 ns |         - |
|                                                   |              |                 |              |              |           |
| Encrypt · AES-128-GCM (CryptoHives-ARM-AES+PMULL) | 1KB          |     4,024.61 ns |     4.514 ns |     3.769 ns |         - |
| Encrypt · AES-128-GCM (OS)                        | 1KB          |     8,791.51 ns |    38.908 ns |    32.490 ns |         - |
| Encrypt · AES-128-GCM (BouncyCastle)              | 1KB          |    22,295.05 ns |    13.812 ns |    11.533 ns |    1520 B |
| Encrypt · AES-128-GCM (CryptoHives-Scalar)        | 1KB          |    25,923.08 ns |    12.712 ns |     9.925 ns |         - |
|                                                   |              |                 |              |              |           |
| Decrypt · AES-128-GCM (OS)                        | 8KB          |     2,902.27 ns |    21.412 ns |    17.880 ns |         - |
| Decrypt · AES-128-GCM (CryptoHives-ARM-AES+PMULL) | 8KB          |     6,172.11 ns |    36.613 ns |    34.248 ns |         - |
| Decrypt · AES-128-GCM (BouncyCastle)              | 8KB          |    32,444.51 ns |    11.323 ns |    10.037 ns |    1536 B |
| Decrypt · AES-128-GCM (CryptoHives-Scalar)        | 8KB          |    43,153.23 ns |    22.199 ns |    17.331 ns |         - |
|                                                   |              |                 |              |              |           |
| Encrypt · AES-128-GCM (OS)                        | 8KB          |    13,204.40 ns |   115.049 ns |   107.617 ns |         - |
| Encrypt · AES-128-GCM (CryptoHives-ARM-AES+PMULL) | 8KB          |    31,403.84 ns |    14.656 ns |    11.442 ns |         - |
| Encrypt · AES-128-GCM (BouncyCastle)              | 8KB          |   163,736.64 ns |   566.036 ns |   501.776 ns |    1520 B |
| Encrypt · AES-128-GCM (CryptoHives-Scalar)        | 8KB          |   202,917.77 ns |   288.201 ns |   255.483 ns |         - |
|                                                   |              |                 |              |              |           |
| Decrypt · AES-128-GCM (OS)                        | 128KB        |    19,683.11 ns |   129.639 ns |   121.264 ns |         - |
| Decrypt · AES-128-GCM (CryptoHives-ARM-AES+PMULL) | 128KB        |   101,850.67 ns |   721.677 ns |   639.748 ns |         - |
| Decrypt · AES-128-GCM (BouncyCastle)              | 128KB        |   509,399.33 ns |   200.182 ns |   187.250 ns |    1536 B |
| Decrypt · AES-128-GCM (CryptoHives-Scalar)        | 128KB        |   686,087.41 ns |   109.640 ns |    97.193 ns |         - |
|                                                   |              |                 |              |              |           |
| Encrypt · AES-128-GCM (OS)                        | 128KB        |    92,595.84 ns | 1,003.219 ns |   938.412 ns |         - |
| Encrypt · AES-128-GCM (CryptoHives-ARM-AES+PMULL) | 128KB        |   503,971.26 ns |   643.796 ns |   502.634 ns |         - |
| Encrypt · AES-128-GCM (BouncyCastle)              | 128KB        | 2,584,321.85 ns | 1,926.173 ns | 1,608.442 ns |    1520 B |
| Encrypt · AES-128-GCM (CryptoHives-Scalar)        | 128KB        | 3,232,210.80 ns | 1,524.435 ns | 1,190.179 ns |         - |