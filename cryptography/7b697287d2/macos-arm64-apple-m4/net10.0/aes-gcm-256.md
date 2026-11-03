| Description                                       | TestDataSize | Mean          | Error      | StdDev     | Allocated |
|-------------------------------------------------- |------------- |--------------:|-----------:|-----------:|----------:|
| Decrypt · AES-256-GCM (CryptoHives-ARM-AES+PMULL) | 17B          |      83.57 ns |   0.305 ns |   0.270 ns |         - |
| Decrypt · AES-256-GCM (CryptoHives-Scalar)        | 17B          |     380.35 ns |   1.123 ns |   0.938 ns |         - |
| Decrypt · AES-256-GCM (BouncyCastle)              | 17B          |     581.87 ns |   0.812 ns |   0.678 ns |    1744 B |
| Decrypt · AES-256-GCM (OS)                        | 17B          |   1,858.96 ns |   8.483 ns |   7.935 ns |         - |
|                                                   |              |               |            |            |           |
| Encrypt · AES-256-GCM (CryptoHives-ARM-AES+PMULL) | 17B          |      52.93 ns |   0.165 ns |   0.154 ns |         - |
| Encrypt · AES-256-GCM (CryptoHives-Scalar)        | 17B          |     344.91 ns |   0.219 ns |   0.183 ns |         - |
| Encrypt · AES-256-GCM (BouncyCastle)              | 17B          |     511.54 ns |   2.473 ns |   2.313 ns |    1728 B |
| Encrypt · AES-256-GCM (OS)                        | 17B          |   1,686.75 ns |  10.305 ns |   9.640 ns |         - |
|                                                   |              |               |            |            |           |
| Decrypt · AES-256-GCM (CryptoHives-ARM-AES+PMULL) | 65B          |      90.39 ns |   0.535 ns |   0.500 ns |         - |
| Decrypt · AES-256-GCM (CryptoHives-Scalar)        | 65B          |     687.55 ns |   0.785 ns |   0.735 ns |         - |
| Decrypt · AES-256-GCM (BouncyCastle)              | 65B          |     826.77 ns |   0.676 ns |   0.633 ns |    1744 B |
| Decrypt · AES-256-GCM (OS)                        | 65B          |   1,869.81 ns |   8.002 ns |   6.248 ns |         - |
|                                                   |              |               |            |            |           |
| Encrypt · AES-256-GCM (CryptoHives-ARM-AES+PMULL) | 65B          |      59.88 ns |   0.324 ns |   0.303 ns |         - |
| Encrypt · AES-256-GCM (CryptoHives-Scalar)        | 65B          |     648.87 ns |   0.490 ns |   0.409 ns |         - |
| Encrypt · AES-256-GCM (BouncyCastle)              | 65B          |     770.06 ns |   0.658 ns |   0.584 ns |    1728 B |
| Encrypt · AES-256-GCM (OS)                        | 65B          |   1,674.16 ns |   8.569 ns |   7.597 ns |         - |
|                                                   |              |               |            |            |           |
| Decrypt · AES-256-GCM (CryptoHives-ARM-AES+PMULL) | 128B         |      90.37 ns |   0.363 ns |   0.339 ns |         - |
| Decrypt · AES-256-GCM (CryptoHives-Scalar)        | 128B         |     999.25 ns |   3.146 ns |   2.627 ns |         - |
| Decrypt · AES-256-GCM (BouncyCastle)              | 128B         |   1,075.00 ns |   0.949 ns |   0.842 ns |    1744 B |
| Decrypt · AES-256-GCM (OS)                        | 128B         |   1,889.89 ns |  26.760 ns |  20.893 ns |         - |
|                                                   |              |               |            |            |           |
| Encrypt · AES-256-GCM (CryptoHives-ARM-AES+PMULL) | 128B         |      62.87 ns |   0.323 ns |   0.302 ns |         - |
| Encrypt · AES-256-GCM (CryptoHives-Scalar)        | 128B         |     966.79 ns |   2.630 ns |   2.460 ns |         - |
| Encrypt · AES-256-GCM (BouncyCastle)              | 128B         |   1,036.19 ns |   0.775 ns |   0.725 ns |    1728 B |
| Encrypt · AES-256-GCM (OS)                        | 128B         |   1,713.05 ns |  10.025 ns |   9.378 ns |         - |
|                                                   |              |               |            |            |           |
| Decrypt · AES-256-GCM (CryptoHives-ARM-AES+PMULL) | 152B         |     114.10 ns |   0.364 ns |   0.341 ns |         - |
| Decrypt · AES-256-GCM (CryptoHives-Scalar)        | 152B         |   1,205.17 ns |   1.474 ns |   1.379 ns |         - |
| Decrypt · AES-256-GCM (BouncyCastle)              | 152B         |   1,235.59 ns |   0.987 ns |   0.923 ns |    1744 B |
| Decrypt · AES-256-GCM (OS)                        | 152B         |   1,899.78 ns |   7.473 ns |   6.625 ns |         - |
|                                                   |              |               |            |            |           |
| Encrypt · AES-256-GCM (CryptoHives-ARM-AES+PMULL) | 152B         |      83.67 ns |   0.546 ns |   0.511 ns |         - |
| Encrypt · AES-256-GCM (CryptoHives-Scalar)        | 152B         |   1,151.03 ns |   1.320 ns |   1.170 ns |         - |
| Encrypt · AES-256-GCM (BouncyCastle)              | 152B         |   1,197.18 ns |   0.655 ns |   0.613 ns |    1728 B |
| Encrypt · AES-256-GCM (OS)                        | 152B         |   1,698.84 ns |   5.125 ns |   4.544 ns |         - |
|                                                   |              |               |            |            |           |
| Decrypt · AES-256-GCM (CryptoHives-ARM-AES+PMULL) | 256B         |     127.09 ns |   0.466 ns |   0.436 ns |         - |
| Decrypt · AES-256-GCM (BouncyCastle)              | 256B         |   1,701.56 ns |   0.717 ns |   0.636 ns |    1744 B |
| Decrypt · AES-256-GCM (CryptoHives-Scalar)        | 256B         |   1,827.13 ns |   1.866 ns |   1.654 ns |         - |
| Decrypt · AES-256-GCM (OS)                        | 256B         |   1,893.65 ns |  21.526 ns |  20.136 ns |         - |
|                                                   |              |               |            |            |           |
| Encrypt · AES-256-GCM (CryptoHives-ARM-AES+PMULL) | 256B         |      92.33 ns |   0.261 ns |   0.244 ns |         - |
| Encrypt · AES-256-GCM (BouncyCastle)              | 256B         |   1,702.88 ns |   0.881 ns |   0.824 ns |    1728 B |
| Encrypt · AES-256-GCM (OS)                        | 256B         |   1,726.89 ns |   3.160 ns |   2.801 ns |         - |
| Encrypt · AES-256-GCM (CryptoHives-Scalar)        | 256B         |   1,791.08 ns |   2.321 ns |   2.057 ns |         - |
|                                                   |              |               |            |            |           |
| Decrypt · AES-256-GCM (CryptoHives-ARM-AES+PMULL) | 1KB          |     317.74 ns |   1.390 ns |   1.300 ns |         - |
| Decrypt · AES-256-GCM (OS)                        | 1KB          |   2,035.77 ns |  12.898 ns |  12.065 ns |         - |
| Decrypt · AES-256-GCM (BouncyCastle)              | 1KB          |   5,430.91 ns |   1.896 ns |   1.773 ns |    1744 B |
| Decrypt · AES-256-GCM (CryptoHives-Scalar)        | 1KB          |   6,614.67 ns |  27.402 ns |  25.631 ns |         - |
|                                                   |              |               |            |            |           |
| Encrypt · AES-256-GCM (CryptoHives-ARM-AES+PMULL) | 1KB          |     285.82 ns |   0.742 ns |   0.694 ns |         - |
| Encrypt · AES-256-GCM (OS)                        | 1KB          |   1,858.56 ns |   9.324 ns |   8.722 ns |         - |
| Encrypt · AES-256-GCM (BouncyCastle)              | 1KB          |   5,675.99 ns |   1.732 ns |   1.620 ns |    1728 B |
| Encrypt · AES-256-GCM (CryptoHives-Scalar)        | 1KB          |   6,317.47 ns |   3.634 ns |   3.222 ns |         - |
|                                                   |              |               |            |            |           |
| Decrypt · AES-256-GCM (CryptoHives-ARM-AES+PMULL) | 8KB          |   2,113.01 ns |   8.022 ns |   7.504 ns |         - |
| Decrypt · AES-256-GCM (OS)                        | 8KB          |   2,981.66 ns |  14.807 ns |  13.851 ns |         - |
| Decrypt · AES-256-GCM (BouncyCastle)              | 8KB          |  39,853.48 ns |  13.845 ns |  12.273 ns |    1744 B |
| Decrypt · AES-256-GCM (CryptoHives-Scalar)        | 8KB          |  50,337.86 ns | 131.343 ns | 122.858 ns |         - |
|                                                   |              |               |            |            |           |
| Encrypt · AES-256-GCM (CryptoHives-ARM-AES+PMULL) | 8KB          |   2,108.06 ns |   6.704 ns |   5.943 ns |         - |
| Encrypt · AES-256-GCM (OS)                        | 8KB          |   2,868.29 ns |  17.943 ns |  16.784 ns |         - |
| Encrypt · AES-256-GCM (BouncyCastle)              | 8KB          |  42,827.17 ns |  18.201 ns |  17.025 ns |    1728 B |
| Encrypt · AES-256-GCM (CryptoHives-Scalar)        | 8KB          |  49,273.02 ns |  55.407 ns |  43.258 ns |         - |
|                                                   |              |               |            |            |           |
| Decrypt · AES-256-GCM (OS)                        | 128KB        |  20,034.69 ns | 164.668 ns | 154.031 ns |         - |
| Decrypt · AES-256-GCM (CryptoHives-ARM-AES+PMULL) | 128KB        |  32,935.30 ns | 140.548 ns | 117.364 ns |         - |
| Decrypt · AES-256-GCM (BouncyCastle)              | 128KB        | 634,375.61 ns | 302.842 ns | 283.279 ns |    1744 B |
| Decrypt · AES-256-GCM (CryptoHives-Scalar)        | 128KB        | 787,199.98 ns | 622.559 ns | 582.342 ns |         - |
|                                                   |              |               |            |            |           |
| Encrypt · AES-256-GCM (OS)                        | 128KB        |  21,217.35 ns | 129.415 ns | 121.055 ns |         - |
| Encrypt · AES-256-GCM (CryptoHives-ARM-AES+PMULL) | 128KB        |  33,521.05 ns | 637.644 ns | 759.070 ns |         - |
| Encrypt · AES-256-GCM (BouncyCastle)              | 128KB        | 677,920.43 ns | 554.425 ns | 491.483 ns |    1728 B |
| Encrypt · AES-256-GCM (CryptoHives-Scalar)        | 128KB        | 784,866.50 ns | 453.853 ns | 424.534 ns |         - |