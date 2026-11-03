| Description                                       | TestDataSize | Mean          | Error        | StdDev       | Median        | Allocated |
|-------------------------------------------------- |------------- |--------------:|-------------:|-------------:|--------------:|----------:|
| Decrypt · AES-128-GCM (CryptoHives-ARM-AES+PMULL) | 17B          |      85.51 ns |     0.283 ns |     0.237 ns |      85.54 ns |         - |
| Decrypt · AES-128-GCM (CryptoHives-Scalar)        | 17B          |     338.48 ns |     1.244 ns |     0.971 ns |     338.27 ns |         - |
| Decrypt · AES-128-GCM (BouncyCastle)              | 17B          |     498.36 ns |     0.684 ns |     0.534 ns |     498.44 ns |    1536 B |
| Decrypt · AES-128-GCM (OS)                        | 17B          |   1,871.39 ns |    15.205 ns |    14.223 ns |   1,875.71 ns |         - |
|                                                   |              |               |              |              |               |           |
| Encrypt · AES-128-GCM (CryptoHives-ARM-AES+PMULL) | 17B          |      50.35 ns |     0.245 ns |     0.218 ns |      50.38 ns |         - |
| Encrypt · AES-128-GCM (CryptoHives-Scalar)        | 17B          |     308.43 ns |     0.708 ns |     0.627 ns |     308.36 ns |         - |
| Encrypt · AES-128-GCM (BouncyCastle)              | 17B          |     422.11 ns |     1.282 ns |     1.200 ns |     422.13 ns |    1520 B |
| Encrypt · AES-128-GCM (OS)                        | 17B          |   1,670.62 ns |     7.360 ns |     6.885 ns |   1,672.75 ns |         - |
|                                                   |              |               |              |              |               |           |
| Decrypt · AES-128-GCM (CryptoHives-ARM-AES+PMULL) | 65B          |      90.16 ns |     0.475 ns |     0.371 ns |      90.13 ns |         - |
| Decrypt · AES-128-GCM (CryptoHives-Scalar)        | 65B          |     602.31 ns |     1.018 ns |     0.903 ns |     602.35 ns |         - |
| Decrypt · AES-128-GCM (BouncyCastle)              | 65B          |     692.79 ns |     0.734 ns |     0.687 ns |     692.94 ns |    1536 B |
| Decrypt · AES-128-GCM (OS)                        | 65B          |   1,880.87 ns |    14.787 ns |    13.832 ns |   1,878.92 ns |         - |
|                                                   |              |               |              |              |               |           |
| Encrypt · AES-128-GCM (CryptoHives-ARM-AES+PMULL) | 65B          |      58.08 ns |     0.171 ns |     0.160 ns |      58.11 ns |         - |
| Encrypt · AES-128-GCM (CryptoHives-Scalar)        | 65B          |     567.75 ns |     1.203 ns |     1.005 ns |     567.49 ns |         - |
| Encrypt · AES-128-GCM (BouncyCastle)              | 65B          |     633.28 ns |     0.941 ns |     0.834 ns |     633.36 ns |    1520 B |
| Encrypt · AES-128-GCM (OS)                        | 65B          |   1,700.97 ns |    16.474 ns |    15.410 ns |   1,697.13 ns |         - |
|                                                   |              |               |              |              |               |           |
| Decrypt · AES-128-GCM (CryptoHives-ARM-AES+PMULL) | 128B         |      88.92 ns |     0.468 ns |     0.391 ns |      88.82 ns |         - |
| Decrypt · AES-128-GCM (CryptoHives-Scalar)        | 128B         |     875.07 ns |     2.719 ns |     2.410 ns |     874.96 ns |         - |
| Decrypt · AES-128-GCM (BouncyCastle)              | 128B         |     896.94 ns |     4.921 ns |     4.109 ns |     895.47 ns |    1536 B |
| Decrypt · AES-128-GCM (OS)                        | 128B         |   1,880.55 ns |    10.868 ns |     9.634 ns |   1,878.94 ns |         - |
|                                                   |              |               |              |              |               |           |
| Encrypt · AES-128-GCM (CryptoHives-ARM-AES+PMULL) | 128B         |      60.27 ns |     0.809 ns |     0.717 ns |      60.32 ns |         - |
| Encrypt · AES-128-GCM (CryptoHives-Scalar)        | 128B         |     844.94 ns |     1.359 ns |     1.272 ns |     844.75 ns |         - |
| Encrypt · AES-128-GCM (BouncyCastle)              | 128B         |     865.45 ns |    16.948 ns |    14.153 ns |     860.04 ns |    1520 B |
| Encrypt · AES-128-GCM (OS)                        | 128B         |   1,711.07 ns |    13.917 ns |    10.865 ns |   1,714.16 ns |         - |
|                                                   |              |               |              |              |               |           |
| Decrypt · AES-128-GCM (CryptoHives-ARM-AES+PMULL) | 152B         |     112.02 ns |     0.232 ns |     0.194 ns |     112.11 ns |         - |
| Decrypt · AES-128-GCM (BouncyCastle)              | 152B         |   1,022.43 ns |     2.003 ns |     1.673 ns |   1,021.82 ns |    1536 B |
| Decrypt · AES-128-GCM (CryptoHives-Scalar)        | 152B         |   1,039.78 ns |     2.741 ns |     2.289 ns |   1,039.70 ns |         - |
| Decrypt · AES-128-GCM (OS)                        | 152B         |   1,891.73 ns |    16.254 ns |    15.204 ns |   1,886.97 ns |         - |
|                                                   |              |               |              |              |               |           |
| Encrypt · AES-128-GCM (CryptoHives-ARM-AES+PMULL) | 152B         |      81.84 ns |     0.532 ns |     0.416 ns |      81.79 ns |         - |
| Encrypt · AES-128-GCM (BouncyCastle)              | 152B         |     982.65 ns |     0.352 ns |     0.312 ns |     982.63 ns |    1520 B |
| Encrypt · AES-128-GCM (CryptoHives-Scalar)        | 152B         |     996.87 ns |     2.491 ns |     1.945 ns |     997.52 ns |         - |
| Encrypt · AES-128-GCM (OS)                        | 152B         |   1,705.11 ns |     8.919 ns |     8.343 ns |   1,704.67 ns |         - |
|                                                   |              |               |              |              |               |           |
| Decrypt · AES-128-GCM (CryptoHives-ARM-AES+PMULL) | 256B         |     119.27 ns |     2.327 ns |     2.587 ns |     117.56 ns |         - |
| Decrypt · AES-128-GCM (BouncyCastle)              | 256B         |   1,413.32 ns |    15.001 ns |    14.032 ns |   1,409.04 ns |    1536 B |
| Decrypt · AES-128-GCM (CryptoHives-Scalar)        | 256B         |   1,635.18 ns |    21.257 ns |    21.830 ns |   1,626.63 ns |         - |
| Decrypt · AES-128-GCM (OS)                        | 256B         |   1,899.18 ns |    12.432 ns |    11.020 ns |   1,898.58 ns |         - |
|                                                   |              |               |              |              |               |           |
| Encrypt · AES-128-GCM (CryptoHives-ARM-AES+PMULL) | 256B         |      80.41 ns |     0.233 ns |     0.218 ns |      80.43 ns |         - |
| Encrypt · AES-128-GCM (BouncyCastle)              | 256B         |   1,433.95 ns |    27.971 ns |    32.211 ns |   1,422.68 ns |    1520 B |
| Encrypt · AES-128-GCM (CryptoHives-Scalar)        | 256B         |   1,553.35 ns |     2.058 ns |     1.719 ns |   1,553.72 ns |         - |
| Encrypt · AES-128-GCM (OS)                        | 256B         |   1,751.10 ns |    34.334 ns |    30.436 ns |   1,744.26 ns |         - |
|                                                   |              |               |              |              |               |           |
| Decrypt · AES-128-GCM (CryptoHives-ARM-AES+PMULL) | 1KB          |     288.15 ns |     1.456 ns |     1.291 ns |     288.44 ns |         - |
| Decrypt · AES-128-GCM (OS)                        | 1KB          |   2,059.66 ns |    22.250 ns |    18.580 ns |   2,053.38 ns |         - |
| Decrypt · AES-128-GCM (BouncyCastle)              | 1KB          |   4,437.68 ns |    62.328 ns |    48.662 ns |   4,416.66 ns |    1536 B |
| Decrypt · AES-128-GCM (CryptoHives-Scalar)        | 1KB          |   5,669.05 ns |    22.118 ns |    19.607 ns |   5,670.12 ns |         - |
|                                                   |              |               |              |              |               |           |
| Encrypt · AES-128-GCM (CryptoHives-ARM-AES+PMULL) | 1KB          |     253.25 ns |     2.028 ns |     1.992 ns |     253.59 ns |         - |
| Encrypt · AES-128-GCM (OS)                        | 1KB          |   1,872.28 ns |    14.435 ns |    13.503 ns |   1,872.79 ns |         - |
| Encrypt · AES-128-GCM (BouncyCastle)              | 1KB          |   4,707.81 ns |     5.646 ns |     5.282 ns |   4,707.82 ns |    1520 B |
| Encrypt · AES-128-GCM (CryptoHives-Scalar)        | 1KB          |   5,384.45 ns |     5.352 ns |     4.469 ns |   5,383.68 ns |         - |
|                                                   |              |               |              |              |               |           |
| Decrypt · AES-128-GCM (CryptoHives-ARM-AES+PMULL) | 8KB          |   1,846.88 ns |     2.667 ns |     2.364 ns |   1,846.58 ns |         - |
| Decrypt · AES-128-GCM (OS)                        | 8KB          |   2,898.43 ns |    26.951 ns |    25.210 ns |   2,898.78 ns |         - |
| Decrypt · AES-128-GCM (BouncyCastle)              | 8KB          |  32,244.97 ns |   218.267 ns |   193.488 ns |  32,175.19 ns |    1536 B |
| Decrypt · AES-128-GCM (CryptoHives-Scalar)        | 8KB          |  43,000.74 ns |   160.238 ns |   142.047 ns |  42,958.70 ns |         - |
|                                                   |              |               |              |              |               |           |
| Encrypt · AES-128-GCM (CryptoHives-ARM-AES+PMULL) | 8KB          |   1,831.78 ns |     4.629 ns |     4.330 ns |   1,830.60 ns |         - |
| Encrypt · AES-128-GCM (OS)                        | 8KB          |   2,757.71 ns |    24.600 ns |    21.807 ns |   2,761.38 ns |         - |
| Encrypt · AES-128-GCM (BouncyCastle)              | 8KB          |  34,860.21 ns |    36.478 ns |    30.461 ns |  34,854.48 ns |    1520 B |
| Encrypt · AES-128-GCM (CryptoHives-Scalar)        | 8KB          |  41,787.38 ns |    93.843 ns |    73.266 ns |  41,760.63 ns |         - |
|                                                   |              |               |              |              |               |           |
| Decrypt · AES-128-GCM (OS)                        | 128KB        |  18,203.43 ns |   102.429 ns |    90.800 ns |  18,195.81 ns |         - |
| Decrypt · AES-128-GCM (CryptoHives-ARM-AES+PMULL) | 128KB        |  32,301.22 ns |   881.975 ns | 2,586.679 ns |  31,857.73 ns |         - |
| Decrypt · AES-128-GCM (BouncyCastle)              | 128KB        | 508,496.79 ns |   367.064 ns |   325.393 ns | 508,427.84 ns |    1536 B |
| Decrypt · AES-128-GCM (CryptoHives-Scalar)        | 128KB        | 681,946.71 ns | 3,379.717 ns | 2,822.216 ns | 682,563.84 ns |         - |
|                                                   |              |               |              |              |               |           |
| Encrypt · AES-128-GCM (OS)                        | 128KB        |  19,328.93 ns |   203.849 ns |   180.707 ns |  19,334.56 ns |         - |
| Encrypt · AES-128-GCM (CryptoHives-ARM-AES+PMULL) | 128KB        |  28,436.93 ns |    42.158 ns |    37.372 ns |  28,433.99 ns |         - |
| Encrypt · AES-128-GCM (BouncyCastle)              | 128KB        | 552,978.73 ns | 4,216.619 ns | 3,521.068 ns | 551,289.63 ns |    1520 B |
| Encrypt · AES-128-GCM (CryptoHives-Scalar)        | 128KB        | 666,653.17 ns | 1,048.319 ns |   929.307 ns | 666,503.58 ns |         - |