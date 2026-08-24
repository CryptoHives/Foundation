| Description                                       | TestDataSize | Mean          | Error         | StdDev        | Median        | Allocated |
|-------------------------------------------------- |------------- |--------------:|--------------:|--------------:|--------------:|----------:|
| Decrypt · AES-192-GCM (CryptoHives-ARM-AES+PMULL) | 17B          |      81.04 ns |      1.386 ns |      1.297 ns |      81.33 ns |         - |
| Decrypt · AES-192-GCM (CryptoHives-Scalar)        | 17B          |     388.47 ns |      0.871 ns |      0.814 ns |     388.54 ns |         - |
| Decrypt · AES-192-GCM (BouncyCastle)              | 17B          |     541.83 ns |      0.662 ns |      0.587 ns |     541.88 ns |    1640 B |
| Decrypt · AES-192-GCM (OS)                        | 17B          |   1,870.42 ns |      5.576 ns |      5.216 ns |   1,869.50 ns |         - |
|                                                   |              |               |               |               |               |           |
| Encrypt · AES-192-GCM (CryptoHives-ARM-AES+PMULL) | 17B          |      54.60 ns |      0.018 ns |      0.016 ns |      54.60 ns |         - |
| Encrypt · AES-192-GCM (CryptoHives-Scalar)        | 17B          |     342.46 ns |      0.067 ns |      0.052 ns |     342.45 ns |         - |
| Encrypt · AES-192-GCM (BouncyCastle)              | 17B          |     477.76 ns |      9.512 ns |     20.064 ns |     464.77 ns |    1624 B |
| Encrypt · AES-192-GCM (OS)                        | 17B          |   1,711.24 ns |      8.479 ns |      6.620 ns |   1,711.49 ns |         - |
|                                                   |              |               |               |               |               |           |
| Decrypt · AES-192-GCM (CryptoHives-ARM-AES+PMULL) | 65B          |     118.51 ns |      0.484 ns |      0.453 ns |     118.42 ns |         - |
| Decrypt · AES-192-GCM (CryptoHives-Scalar)        | 65B          |     681.27 ns |      0.737 ns |      0.689 ns |     681.30 ns |         - |
| Decrypt · AES-192-GCM (BouncyCastle)              | 65B          |     760.29 ns |      0.539 ns |      0.504 ns |     760.23 ns |    1640 B |
| Decrypt · AES-192-GCM (OS)                        | 65B          |   1,909.48 ns |     11.249 ns |     10.522 ns |   1,904.30 ns |         - |
|                                                   |              |               |               |               |               |           |
| Encrypt · AES-192-GCM (CryptoHives-ARM-AES+PMULL) | 65B          |      86.31 ns |      0.308 ns |      0.288 ns |      86.37 ns |         - |
| Encrypt · AES-192-GCM (CryptoHives-Scalar)        | 65B          |     640.51 ns |      0.880 ns |      0.780 ns |     640.33 ns |         - |
| Encrypt · AES-192-GCM (BouncyCastle)              | 65B          |     699.01 ns |      0.265 ns |      0.248 ns |     699.00 ns |    1624 B |
| Encrypt · AES-192-GCM (OS)                        | 65B          |   1,690.62 ns |      3.767 ns |      3.340 ns |   1,690.76 ns |         - |
|                                                   |              |               |               |               |               |           |
| Decrypt · AES-192-GCM (CryptoHives-ARM-AES+PMULL) | 128B         |     156.78 ns |      0.438 ns |      0.388 ns |     156.70 ns |         - |
| Decrypt · AES-192-GCM (CryptoHives-Scalar)        | 128B         |     975.40 ns |      3.385 ns |      3.166 ns |     975.25 ns |         - |
| Decrypt · AES-192-GCM (BouncyCastle)              | 128B         |     984.95 ns |      0.658 ns |      0.615 ns |     985.06 ns |    1640 B |
| Decrypt · AES-192-GCM (OS)                        | 128B         |   1,984.77 ns |     39.360 ns |     53.877 ns |   1,985.54 ns |         - |
|                                                   |              |               |               |               |               |           |
| Encrypt · AES-192-GCM (CryptoHives-ARM-AES+PMULL) | 128B         |     120.67 ns |      0.263 ns |      0.246 ns |     120.73 ns |         - |
| Encrypt · AES-192-GCM (CryptoHives-Scalar)        | 128B         |     918.75 ns |      0.389 ns |      0.325 ns |     918.81 ns |         - |
| Encrypt · AES-192-GCM (BouncyCastle)              | 128B         |   1,179.13 ns |     10.363 ns |      9.694 ns |   1,179.52 ns |    1624 B |
| Encrypt · AES-192-GCM (OS)                        | 128B         |   2,138.68 ns |     31.733 ns |     29.683 ns |   2,145.66 ns |         - |
|                                                   |              |               |               |               |               |           |
| Decrypt · AES-192-GCM (CryptoHives-ARM-AES+PMULL) | 152B         |     195.70 ns |      1.616 ns |      1.433 ns |     195.99 ns |         - |
| Decrypt · AES-192-GCM (CryptoHives-Scalar)        | 152B         |   1,262.66 ns |     25.118 ns |     47.790 ns |   1,269.80 ns |         - |
| Decrypt · AES-192-GCM (BouncyCastle)              | 152B         |   1,339.93 ns |     26.286 ns |     41.692 ns |   1,341.03 ns |    1640 B |
| Decrypt · AES-192-GCM (OS)                        | 152B         |   2,243.81 ns |     15.764 ns |     13.163 ns |   2,243.26 ns |         - |
|                                                   |              |               |               |               |               |           |
| Encrypt · AES-192-GCM (CryptoHives-ARM-AES+PMULL) | 152B         |     733.00 ns |      1.425 ns |      1.263 ns |     732.30 ns |         - |
| Encrypt · AES-192-GCM (BouncyCastle)              | 152B         |   1,085.61 ns |      0.651 ns |      0.577 ns |   1,085.55 ns |    1624 B |
| Encrypt · AES-192-GCM (CryptoHives-Scalar)        | 152B         |   1,126.62 ns |      9.050 ns |      8.465 ns |   1,120.80 ns |         - |
| Encrypt · AES-192-GCM (OS)                        | 152B         |   1,697.34 ns |      4.298 ns |      3.589 ns |   1,698.08 ns |         - |
|                                                   |              |               |               |               |               |           |
| Decrypt · AES-192-GCM (CryptoHives-ARM-AES+PMULL) | 256B         |     266.27 ns |      2.097 ns |      1.962 ns |     265.95 ns |         - |
| Decrypt · AES-192-GCM (BouncyCastle)              | 256B         |   1,917.27 ns |     10.038 ns |      9.389 ns |   1,913.98 ns |    1640 B |
| Decrypt · AES-192-GCM (CryptoHives-Scalar)        | 256B         |   2,113.62 ns |     33.403 ns |     31.245 ns |   2,113.05 ns |         - |
| Decrypt · AES-192-GCM (OS)                        | 256B         |   8,685.11 ns |    477.754 ns |  1,401.169 ns |   9,005.42 ns |         - |
|                                                   |              |               |               |               |               |           |
| Encrypt · AES-192-GCM (CryptoHives-ARM-AES+PMULL) | 256B         |     215.64 ns |      0.950 ns |      0.889 ns |     215.46 ns |         - |
| Encrypt · AES-192-GCM (BouncyCastle)              | 256B         |   1,544.30 ns |      0.602 ns |      0.563 ns |   1,544.41 ns |    1624 B |
| Encrypt · AES-192-GCM (CryptoHives-Scalar)        | 256B         |   1,689.62 ns |      0.283 ns |      0.236 ns |   1,689.65 ns |         - |
| Encrypt · AES-192-GCM (OS)                        | 256B         |   1,719.99 ns |      4.773 ns |      4.464 ns |   1,720.43 ns |         - |
|                                                   |              |               |               |               |               |           |
| Decrypt · AES-192-GCM (CryptoHives-ARM-AES+PMULL) | 1KB          |     861.60 ns |      5.421 ns |      4.806 ns |     861.18 ns |         - |
| Decrypt · AES-192-GCM (OS)                        | 1KB          |   2,044.22 ns |     13.103 ns |     12.257 ns |   2,045.33 ns |         - |
| Decrypt · AES-192-GCM (BouncyCastle)              | 1KB          |   4,994.28 ns |     79.462 ns |     62.038 ns |   4,974.77 ns |    1640 B |
| Decrypt · AES-192-GCM (CryptoHives-Scalar)        | 1KB          |   6,307.58 ns |      5.146 ns |      4.297 ns |   6,306.54 ns |         - |
|                                                   |              |               |               |               |               |           |
| Encrypt · AES-192-GCM (CryptoHives-ARM-AES+PMULL) | 1KB          |     828.70 ns |      2.065 ns |      1.932 ns |     829.25 ns |         - |
| Encrypt · AES-192-GCM (OS)                        | 1KB          |   2,159.94 ns |     26.068 ns |     24.384 ns |   2,167.83 ns |         - |
| Encrypt · AES-192-GCM (BouncyCastle)              | 1KB          |   6,231.46 ns |    122.008 ns |    167.006 ns |   6,262.85 ns |    1624 B |
| Encrypt · AES-192-GCM (CryptoHives-Scalar)        | 1KB          |   6,960.88 ns |    146.138 ns |    430.892 ns |   6,892.37 ns |         - |
|                                                   |              |               |               |               |               |           |
| Decrypt · AES-192-GCM (OS)                        | 8KB          |   2,949.96 ns |     13.090 ns |     12.245 ns |   2,951.50 ns |         - |
| Decrypt · AES-192-GCM (CryptoHives-ARM-AES+PMULL) | 8KB          |   6,402.04 ns |     64.544 ns |     57.217 ns |   6,390.15 ns |         - |
| Decrypt · AES-192-GCM (BouncyCastle)              | 8KB          |  38,592.71 ns |     51.503 ns |     48.176 ns |  38,590.74 ns |    1640 B |
| Decrypt · AES-192-GCM (CryptoHives-Scalar)        | 8KB          |  48,824.17 ns |    424.898 ns |    397.450 ns |  48,543.37 ns |         - |
|                                                   |              |               |               |               |               |           |
| Encrypt · AES-192-GCM (CryptoHives-ARM-AES+PMULL) | 8KB          |   6,559.79 ns |     23.134 ns |     19.318 ns |   6,557.26 ns |         - |
| Encrypt · AES-192-GCM (OS)                        | 8KB          |  13,249.33 ns |     49.911 ns |     38.968 ns |  13,252.60 ns |         - |
| Encrypt · AES-192-GCM (BouncyCastle)              | 8KB          | 182,999.28 ns |     45.364 ns |     37.881 ns | 183,003.66 ns |    1624 B |
| Encrypt · AES-192-GCM (CryptoHives-Scalar)        | 8KB          | 228,305.93 ns |    280.615 ns |    262.487 ns | 228,355.12 ns |         - |
|                                                   |              |               |               |               |               |           |
| Decrypt · AES-192-GCM (OS)                        | 128KB        |  19,490.02 ns |     26.321 ns |     23.333 ns |  19,489.83 ns |         - |
| Decrypt · AES-192-GCM (CryptoHives-ARM-AES+PMULL) | 128KB        |  99,330.46 ns |    464.316 ns |    411.604 ns |  99,234.72 ns |         - |
| Decrypt · AES-192-GCM (BouncyCastle)              | 128KB        | 569,506.55 ns |    215.385 ns |    201.471 ns | 569,553.71 ns |    1640 B |
| Decrypt · AES-192-GCM (CryptoHives-Scalar)        | 128KB        | 772,823.58 ns |    318.756 ns |    298.164 ns | 772,931.52 ns |         - |
|                                                   |              |               |               |               |               |           |
| Encrypt · AES-192-GCM (OS)                        | 128KB        |  21,037.01 ns |     71.745 ns |     67.110 ns |  21,048.01 ns |         - |
| Encrypt · AES-192-GCM (CryptoHives-ARM-AES+PMULL) | 128KB        | 507,938.22 ns |  4,342.239 ns |  3,625.966 ns | 508,247.23 ns |         - |
| Encrypt · AES-192-GCM (BouncyCastle)              | 128KB        | 615,138.86 ns |    525.083 ns |    491.163 ns | 615,299.03 ns |    1624 B |
| Encrypt · AES-192-GCM (CryptoHives-Scalar)        | 128KB        | 792,256.73 ns | 15,777.071 ns | 26,790.667 ns | 783,138.02 ns |         - |