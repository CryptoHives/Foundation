| Description                                       | TestDataSize | Mean          | Error        | StdDev       | Allocated |
|-------------------------------------------------- |------------- |--------------:|-------------:|-------------:|----------:|
| Decrypt · AES-256-GCM (CryptoHives-ARM-AES+PMULL) | 17B          |      84.64 ns |     0.232 ns |     0.217 ns |         - |
| Decrypt · AES-256-GCM (CryptoHives-Scalar)        | 17B          |     382.39 ns |     1.232 ns |     1.152 ns |         - |
| Decrypt · AES-256-GCM (BouncyCastle)              | 17B          |     588.22 ns |     1.612 ns |     1.508 ns |    1744 B |
| Decrypt · AES-256-GCM (OS)                        | 17B          |   1,894.59 ns |     8.200 ns |     7.269 ns |         - |
|                                                   |              |               |              |              |           |
| Encrypt · AES-256-GCM (CryptoHives-ARM-AES+PMULL) | 17B          |      53.63 ns |     0.080 ns |     0.075 ns |         - |
| Encrypt · AES-256-GCM (CryptoHives-Scalar)        | 17B          |     346.83 ns |     0.321 ns |     0.268 ns |         - |
| Encrypt · AES-256-GCM (BouncyCastle)              | 17B          |     516.61 ns |     1.568 ns |     1.467 ns |    1728 B |
| Encrypt · AES-256-GCM (OS)                        | 17B          |   1,726.72 ns |     5.287 ns |     4.686 ns |         - |
|                                                   |              |               |              |              |           |
| Decrypt · AES-256-GCM (CryptoHives-ARM-AES+PMULL) | 65B          |      92.29 ns |     0.531 ns |     0.496 ns |         - |
| Decrypt · AES-256-GCM (CryptoHives-Scalar)        | 65B          |     694.64 ns |     1.271 ns |     1.126 ns |         - |
| Decrypt · AES-256-GCM (BouncyCastle)              | 65B          |     837.52 ns |     1.288 ns |     1.205 ns |    1744 B |
| Decrypt · AES-256-GCM (OS)                        | 65B          |   1,878.06 ns |    10.828 ns |    10.128 ns |         - |
|                                                   |              |               |              |              |           |
| Encrypt · AES-256-GCM (CryptoHives-ARM-AES+PMULL) | 65B          |      60.41 ns |     0.336 ns |     0.315 ns |         - |
| Encrypt · AES-256-GCM (CryptoHives-Scalar)        | 65B          |     653.17 ns |     1.278 ns |     1.196 ns |         - |
| Encrypt · AES-256-GCM (BouncyCastle)              | 65B          |     779.39 ns |     0.742 ns |     0.657 ns |    1728 B |
| Encrypt · AES-256-GCM (OS)                        | 65B          |   1,706.98 ns |     9.064 ns |     8.479 ns |         - |
|                                                   |              |               |              |              |           |
| Decrypt · AES-256-GCM (CryptoHives-ARM-AES+PMULL) | 128B         |      89.78 ns |     0.521 ns |     0.488 ns |         - |
| Decrypt · AES-256-GCM (CryptoHives-Scalar)        | 128B         |   1,000.17 ns |     2.674 ns |     2.501 ns |         - |
| Decrypt · AES-256-GCM (BouncyCastle)              | 128B         |   1,084.98 ns |     1.641 ns |     1.535 ns |    1744 B |
| Decrypt · AES-256-GCM (OS)                        | 128B         |   1,916.96 ns |    23.337 ns |    21.829 ns |         - |
|                                                   |              |               |              |              |           |
| Encrypt · AES-256-GCM (CryptoHives-ARM-AES+PMULL) | 128B         |      63.48 ns |     0.224 ns |     0.187 ns |         - |
| Encrypt · AES-256-GCM (CryptoHives-Scalar)        | 128B         |     972.20 ns |     1.989 ns |     1.763 ns |         - |
| Encrypt · AES-256-GCM (BouncyCastle)              | 128B         |   1,048.46 ns |     2.050 ns |     1.918 ns |    1728 B |
| Encrypt · AES-256-GCM (OS)                        | 128B         |   1,747.85 ns |     5.525 ns |     5.168 ns |         - |
|                                                   |              |               |              |              |           |
| Decrypt · AES-256-GCM (CryptoHives-ARM-AES+PMULL) | 152B         |     115.64 ns |     0.334 ns |     0.312 ns |         - |
| Decrypt · AES-256-GCM (CryptoHives-Scalar)        | 152B         |   1,211.90 ns |     3.621 ns |     3.387 ns |         - |
| Decrypt · AES-256-GCM (BouncyCastle)              | 152B         |   1,246.02 ns |     2.168 ns |     2.028 ns |    1744 B |
| Decrypt · AES-256-GCM (OS)                        | 152B         |   1,908.64 ns |    20.245 ns |    18.937 ns |         - |
|                                                   |              |               |              |              |           |
| Encrypt · AES-256-GCM (CryptoHives-ARM-AES+PMULL) | 152B         |      85.92 ns |     0.292 ns |     0.259 ns |         - |
| Encrypt · AES-256-GCM (CryptoHives-Scalar)        | 152B         |   1,157.36 ns |     1.770 ns |     1.478 ns |         - |
| Encrypt · AES-256-GCM (BouncyCastle)              | 152B         |   1,211.82 ns |     2.083 ns |     1.948 ns |    1728 B |
| Encrypt · AES-256-GCM (OS)                        | 152B         |   1,721.07 ns |     9.393 ns |     8.786 ns |         - |
|                                                   |              |               |              |              |           |
| Decrypt · AES-256-GCM (CryptoHives-ARM-AES+PMULL) | 256B         |     128.90 ns |     0.456 ns |     0.427 ns |         - |
| Decrypt · AES-256-GCM (BouncyCastle)              | 256B         |   1,718.92 ns |     2.428 ns |     2.271 ns |    1744 B |
| Decrypt · AES-256-GCM (CryptoHives-Scalar)        | 256B         |   1,835.51 ns |     3.142 ns |     2.939 ns |         - |
| Decrypt · AES-256-GCM (OS)                        | 256B         |   1,898.02 ns |    14.462 ns |    13.528 ns |         - |
|                                                   |              |               |              |              |           |
| Encrypt · AES-256-GCM (CryptoHives-ARM-AES+PMULL) | 256B         |      93.80 ns |     0.440 ns |     0.390 ns |         - |
| Encrypt · AES-256-GCM (BouncyCastle)              | 256B         |   1,721.98 ns |     2.326 ns |     2.176 ns |    1728 B |
| Encrypt · AES-256-GCM (OS)                        | 256B         |   1,770.12 ns |     5.065 ns |     4.490 ns |         - |
| Encrypt · AES-256-GCM (CryptoHives-Scalar)        | 256B         |   1,800.82 ns |     3.071 ns |     2.872 ns |         - |
|                                                   |              |               |              |              |           |
| Decrypt · AES-256-GCM (CryptoHives-ARM-AES+PMULL) | 1KB          |     322.73 ns |     0.838 ns |     0.784 ns |         - |
| Decrypt · AES-256-GCM (OS)                        | 1KB          |   2,037.06 ns |    17.752 ns |    16.605 ns |         - |
| Decrypt · AES-256-GCM (BouncyCastle)              | 1KB          |   5,476.28 ns |     7.673 ns |     7.177 ns |    1744 B |
| Decrypt · AES-256-GCM (CryptoHives-Scalar)        | 1KB          |   6,531.88 ns |    10.015 ns |     8.878 ns |         - |
|                                                   |              |               |              |              |           |
| Encrypt · AES-256-GCM (CryptoHives-ARM-AES+PMULL) | 1KB          |     287.26 ns |     1.208 ns |     1.130 ns |         - |
| Encrypt · AES-256-GCM (OS)                        | 1KB          |   1,889.07 ns |     6.184 ns |     5.482 ns |         - |
| Encrypt · AES-256-GCM (BouncyCastle)              | 1KB          |   5,773.04 ns |     4.929 ns |     4.610 ns |    1728 B |
| Encrypt · AES-256-GCM (CryptoHives-Scalar)        | 1KB          |   6,358.22 ns |     8.526 ns |     7.975 ns |         - |
|                                                   |              |               |              |              |           |
| Decrypt · AES-256-GCM (CryptoHives-ARM-AES+PMULL) | 8KB          |   2,139.40 ns |     6.548 ns |     5.468 ns |         - |
| Decrypt · AES-256-GCM (OS)                        | 8KB          |   3,040.33 ns |    14.541 ns |    13.602 ns |         - |
| Decrypt · AES-256-GCM (BouncyCastle)              | 8KB          |  40,345.06 ns |    32.289 ns |    30.204 ns |    1744 B |
| Decrypt · AES-256-GCM (CryptoHives-Scalar)        | 8KB          |  50,778.92 ns |    92.138 ns |    86.186 ns |         - |
|                                                   |              |               |              |              |           |
| Encrypt · AES-256-GCM (CryptoHives-ARM-AES+PMULL) | 8KB          |   2,118.41 ns |     7.725 ns |     7.226 ns |         - |
| Encrypt · AES-256-GCM (OS)                        | 8KB          |   2,907.53 ns |     9.276 ns |     8.223 ns |         - |
| Encrypt · AES-256-GCM (BouncyCastle)              | 8KB          |  43,067.66 ns |    47.619 ns |    44.543 ns |    1728 B |
| Encrypt · AES-256-GCM (CryptoHives-Scalar)        | 8KB          |  49,601.62 ns |    43.951 ns |    41.112 ns |         - |
|                                                   |              |               |              |              |           |
| Decrypt · AES-256-GCM (OS)                        | 128KB        |  20,377.64 ns |    79.022 ns |    70.051 ns |         - |
| Decrypt · AES-256-GCM (CryptoHives-ARM-AES+PMULL) | 128KB        |  33,828.02 ns |   535.743 ns |   550.169 ns |         - |
| Decrypt · AES-256-GCM (BouncyCastle)              | 128KB        | 635,947.72 ns |   780.337 ns |   729.927 ns |    1744 B |
| Decrypt · AES-256-GCM (CryptoHives-Scalar)        | 128KB        | 802,515.56 ns | 1,775.002 ns | 1,660.338 ns |         - |
|                                                   |              |               |              |              |           |
| Encrypt · AES-256-GCM (OS)                        | 128KB        |  21,703.32 ns |    64.038 ns |    59.901 ns |         - |
| Encrypt · AES-256-GCM (CryptoHives-ARM-AES+PMULL) | 128KB        |  33,391.12 ns |   165.630 ns |   154.930 ns |         - |
| Encrypt · AES-256-GCM (BouncyCastle)              | 128KB        | 679,920.26 ns |   764.530 ns |   715.142 ns |    1728 B |
| Encrypt · AES-256-GCM (CryptoHives-Scalar)        | 128KB        | 790,421.07 ns | 1,395.659 ns | 1,237.215 ns |         - |