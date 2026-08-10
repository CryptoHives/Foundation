| Description                                       | TestDataSize | Mean            | Error        | StdDev       | Median          | Allocated |
|-------------------------------------------------- |------------- |----------------:|-------------:|-------------:|----------------:|----------:|
| Decrypt · AES-256-GCM (CryptoHives-ARM-AES+PMULL) | 17B          |       392.48 ns |     4.065 ns |     3.803 ns |       391.99 ns |         - |
| Decrypt · AES-256-GCM (CryptoHives-Scalar)        | 17B          |     1,848.11 ns |     2.697 ns |     2.522 ns |     1,848.36 ns |         - |
| Decrypt · AES-256-GCM (BouncyCastle)              | 17B          |     3,120.12 ns |     7.685 ns |     6.813 ns |     3,118.81 ns |    1744 B |
| Decrypt · AES-256-GCM (OS)                        | 17B          |     9,008.65 ns |    85.134 ns |    79.634 ns |     9,021.45 ns |         - |
|                                                   |              |                 |              |              |                 |           |
| Encrypt · AES-256-GCM (CryptoHives-ARM-AES+PMULL) | 17B          |        55.91 ns |     0.054 ns |     0.045 ns |        55.92 ns |         - |
| Encrypt · AES-256-GCM (CryptoHives-Scalar)        | 17B          |       360.84 ns |     0.204 ns |     0.191 ns |       360.85 ns |         - |
| Encrypt · AES-256-GCM (BouncyCastle)              | 17B          |       586.76 ns |     0.718 ns |     0.672 ns |       586.60 ns |    1728 B |
| Encrypt · AES-256-GCM (OS)                        | 17B          |     1,739.71 ns |    12.648 ns |    11.831 ns |     1,733.40 ns |         - |
|                                                   |              |                 |              |              |                 |           |
| Decrypt · AES-256-GCM (CryptoHives-ARM-AES+PMULL) | 65B          |       562.57 ns |     2.518 ns |     2.355 ns |       561.77 ns |         - |
| Decrypt · AES-256-GCM (CryptoHives-Scalar)        | 65B          |     3,299.54 ns |     4.311 ns |     3.821 ns |     3,299.90 ns |         - |
| Decrypt · AES-256-GCM (BouncyCastle)              | 65B          |     4,257.31 ns |     4.490 ns |     4.200 ns |     4,258.70 ns |    1744 B |
| Decrypt · AES-256-GCM (OS)                        | 65B          |     9,069.33 ns |    44.404 ns |    41.536 ns |     9,060.56 ns |         - |
|                                                   |              |                 |              |              |                 |           |
| Encrypt · AES-256-GCM (CryptoHives-ARM-AES+PMULL) | 65B          |        87.64 ns |     0.030 ns |     0.028 ns |        87.63 ns |         - |
| Encrypt · AES-256-GCM (CryptoHives-Scalar)        | 65B          |       663.07 ns |     0.171 ns |     0.160 ns |       663.07 ns |         - |
| Encrypt · AES-256-GCM (BouncyCastle)              | 65B          |       840.77 ns |     0.835 ns |     0.697 ns |       840.93 ns |    1728 B |
| Encrypt · AES-256-GCM (OS)                        | 65B          |     1,967.93 ns |    35.177 ns |    80.115 ns |     1,950.23 ns |         - |
|                                                   |              |                 |              |              |                 |           |
| Decrypt · AES-256-GCM (CryptoHives-ARM-AES+PMULL) | 128B         |       768.34 ns |     5.102 ns |     4.773 ns |       767.17 ns |         - |
| Decrypt · AES-256-GCM (CryptoHives-Scalar)        | 128B         |     4,746.61 ns |     5.049 ns |     4.476 ns |     4,745.02 ns |         - |
| Decrypt · AES-256-GCM (BouncyCastle)              | 128B         |     5,417.20 ns |     3.699 ns |     3.279 ns |     5,416.63 ns |    1744 B |
| Decrypt · AES-256-GCM (OS)                        | 128B         |     9,212.45 ns |   106.131 ns |    99.275 ns |     9,235.57 ns |         - |
|                                                   |              |                 |              |              |                 |           |
| Encrypt · AES-256-GCM (CryptoHives-ARM-AES+PMULL) | 128B         |       126.78 ns |     0.120 ns |     0.106 ns |       126.80 ns |         - |
| Encrypt · AES-256-GCM (CryptoHives-Scalar)        | 128B         |       963.68 ns |     0.282 ns |     0.220 ns |       963.66 ns |         - |
| Encrypt · AES-256-GCM (BouncyCastle)              | 128B         |     1,290.47 ns |    25.576 ns |    39.819 ns |     1,295.46 ns |    1728 B |
| Encrypt · AES-256-GCM (OS)                        | 128B         |     1,967.29 ns |    24.487 ns |    20.448 ns |     1,962.75 ns |         - |
|                                                   |              |                 |              |              |                 |           |
| Decrypt · AES-256-GCM (CryptoHives-ARM-AES+PMULL) | 152B         |       938.06 ns |     4.264 ns |     3.329 ns |       938.90 ns |         - |
| Decrypt · AES-256-GCM (CryptoHives-Scalar)        | 152B         |     5,673.72 ns |     4.763 ns |     4.455 ns |     5,672.28 ns |         - |
| Decrypt · AES-256-GCM (BouncyCastle)              | 152B         |     6,151.40 ns |     7.209 ns |     6.744 ns |     6,152.46 ns |    1744 B |
| Decrypt · AES-256-GCM (OS)                        | 152B         |     9,095.95 ns |    55.664 ns |    52.069 ns |     9,098.71 ns |         - |
|                                                   |              |                 |              |              |                 |           |
| Encrypt · AES-256-GCM (CryptoHives-ARM-AES+PMULL) | 152B         |       156.25 ns |     0.152 ns |     0.135 ns |       156.29 ns |         - |
| Encrypt · AES-256-GCM (CryptoHives-Scalar)        | 152B         |     1,360.08 ns |    26.254 ns |    26.961 ns |     1,360.72 ns |         - |
| Encrypt · AES-256-GCM (BouncyCastle)              | 152B         |     1,545.96 ns |    30.671 ns |    31.496 ns |     1,553.18 ns |    1728 B |
| Encrypt · AES-256-GCM (OS)                        | 152B         |     2,099.86 ns |    23.709 ns |    22.178 ns |     2,101.45 ns |         - |
|                                                   |              |                 |              |              |                 |           |
| Decrypt · AES-256-GCM (CryptoHives-ARM-AES+PMULL) | 256B         |     1,297.43 ns |    12.461 ns |    11.656 ns |     1,297.96 ns |         - |
| Decrypt · AES-256-GCM (BouncyCastle)              | 256B         |     1,777.07 ns |     1.360 ns |     1.272 ns |     1,776.82 ns |    1744 B |
| Decrypt · AES-256-GCM (CryptoHives-Scalar)        | 256B         |     1,840.39 ns |    36.503 ns |    61.985 ns |     1,810.38 ns |         - |
| Decrypt · AES-256-GCM (OS)                        | 256B         |     1,972.13 ns |    15.607 ns |    14.599 ns |     1,968.01 ns |         - |
|                                                   |              |                 |              |              |                 |           |
| Encrypt · AES-256-GCM (CryptoHives-ARM-AES+PMULL) | 256B         |       233.89 ns |     0.628 ns |     0.524 ns |       233.80 ns |         - |
| Encrypt · AES-256-GCM (CryptoHives-Scalar)        | 256B         |     2,093.08 ns |    40.431 ns |    53.974 ns |     2,108.54 ns |         - |
| Encrypt · AES-256-GCM (BouncyCastle)              | 256B         |     2,122.70 ns |    41.953 ns |    60.168 ns |     2,111.18 ns |    1728 B |
| Encrypt · AES-256-GCM (OS)                        | 256B         |     2,191.74 ns |    43.816 ns |    38.841 ns |     2,198.54 ns |         - |
|                                                   |              |                 |              |              |                 |           |
| Decrypt · AES-256-GCM (CryptoHives-ARM-AES+PMULL) | 1KB          |       837.58 ns |     8.276 ns |     6.911 ns |       837.76 ns |         - |
| Decrypt · AES-256-GCM (OS)                        | 1KB          |     2,099.22 ns |    19.172 ns |    16.995 ns |     2,094.14 ns |         - |
| Decrypt · AES-256-GCM (BouncyCastle)              | 1KB          |     5,522.34 ns |     4.760 ns |     3.975 ns |     5,521.94 ns |    1744 B |
| Decrypt · AES-256-GCM (CryptoHives-Scalar)        | 1KB          |     6,580.40 ns |     2.054 ns |     1.604 ns |     6,580.24 ns |         - |
|                                                   |              |                 |              |              |                 |           |
| Encrypt · AES-256-GCM (CryptoHives-ARM-AES+PMULL) | 1KB          |       889.83 ns |    17.806 ns |    16.656 ns |       889.44 ns |         - |
| Encrypt · AES-256-GCM (OS)                        | 1KB          |     9,040.18 ns |   119.524 ns |   111.802 ns |     8,986.19 ns |         - |
| Encrypt · AES-256-GCM (BouncyCastle)              | 1KB          |    27,106.41 ns |    11.764 ns |    10.429 ns |    27,103.38 ns |    1728 B |
| Encrypt · AES-256-GCM (CryptoHives-Scalar)        | 1KB          |    30,003.83 ns | 1,111.541 ns | 3,153.258 ns |    30,457.34 ns |         - |
|                                                   |              |                 |              |              |                 |           |
| Decrypt · AES-256-GCM (OS)                        | 8KB          |     3,099.95 ns |    13.097 ns |    12.251 ns |     3,095.90 ns |         - |
| Decrypt · AES-256-GCM (CryptoHives-ARM-AES+PMULL) | 8KB          |     6,362.26 ns |    83.183 ns |    69.462 ns |     6,371.20 ns |         - |
| Decrypt · AES-256-GCM (BouncyCastle)              | 8KB          |    40,008.45 ns |     8.312 ns |     6.490 ns |    40,009.26 ns |    1744 B |
| Decrypt · AES-256-GCM (CryptoHives-Scalar)        | 8KB          |    50,781.50 ns |    35.053 ns |    27.367 ns |    50,771.57 ns |         - |
|                                                   |              |                 |              |              |                 |           |
| Encrypt · AES-256-GCM (OS)                        | 8KB          |    13,975.05 ns |   175.416 ns |   164.084 ns |    13,928.83 ns |         - |
| Encrypt · AES-256-GCM (CryptoHives-ARM-AES+PMULL) | 8KB          |    32,094.53 ns |    48.704 ns |    38.025 ns |    32,120.38 ns |         - |
| Encrypt · AES-256-GCM (BouncyCastle)              | 8KB          |   200,098.54 ns |   122.654 ns |   102.422 ns |   200,085.24 ns |    1728 B |
| Encrypt · AES-256-GCM (CryptoHives-Scalar)        | 8KB          |   238,659.34 ns |   145.934 ns |   129.367 ns |   238,671.31 ns |         - |
|                                                   |              |                 |              |              |                 |           |
| Decrypt · AES-256-GCM (OS)                        | 128KB        |    20,784.60 ns |    76.921 ns |    71.952 ns |    20,791.28 ns |         - |
| Decrypt · AES-256-GCM (CryptoHives-ARM-AES+PMULL) | 128KB        |   103,150.76 ns |   472.990 ns |   442.435 ns |   103,087.03 ns |         - |
| Decrypt · AES-256-GCM (BouncyCastle)              | 128KB        |   632,521.95 ns |   243.138 ns |   215.535 ns |   632,514.93 ns |    1744 B |
| Decrypt · AES-256-GCM (CryptoHives-Scalar)        | 128KB        |   808,029.66 ns |   101.426 ns |    94.874 ns |   807,995.85 ns |         - |
|                                                   |              |                 |              |              |                 |           |
| Encrypt · AES-256-GCM (OS)                        | 128KB        |   102,155.07 ns |   597.475 ns |   529.646 ns |   101,828.32 ns |         - |
| Encrypt · AES-256-GCM (CryptoHives-ARM-AES+PMULL) | 128KB        |   511,507.58 ns |   233.359 ns |   182.192 ns |   511,515.99 ns |         - |
| Encrypt · AES-256-GCM (BouncyCastle)              | 128KB        | 3,181,223.93 ns | 1,684.265 ns | 1,493.057 ns | 3,181,190.92 ns |    1728 B |
| Encrypt · AES-256-GCM (CryptoHives-Scalar)        | 128KB        | 3,806,613.70 ns | 1,725.147 ns | 1,529.298 ns | 3,805,917.32 ns |         - |