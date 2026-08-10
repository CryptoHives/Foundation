| Description                                       | TestDataSize | Mean          | Error      | StdDev     | Allocated |
|-------------------------------------------------- |------------- |--------------:|-----------:|-----------:|----------:|
| Decrypt · AES-192-GCM (CryptoHives-ARM-AES+PMULL) | 17B          |      81.62 ns |   0.904 ns |   0.846 ns |         - |
| Decrypt · AES-192-GCM (CryptoHives-Scalar)        | 17B          |     370.10 ns |   0.686 ns |   0.642 ns |         - |
| Decrypt · AES-192-GCM (BouncyCastle)              | 17B          |     623.17 ns |   0.565 ns |   0.528 ns |    1640 B |
| Decrypt · AES-192-GCM (OS)                        | 17B          |   1,866.41 ns |  12.850 ns |  12.020 ns |         - |
|                                                   |              |               |            |            |           |
| Encrypt · AES-192-GCM (CryptoHives-ARM-AES+PMULL) | 17B          |      53.69 ns |   0.034 ns |   0.032 ns |         - |
| Encrypt · AES-192-GCM (CryptoHives-Scalar)        | 17B          |     333.71 ns |   0.059 ns |   0.055 ns |         - |
| Encrypt · AES-192-GCM (BouncyCastle)              | 17B          |     537.94 ns |   0.774 ns |   0.724 ns |    1624 B |
| Encrypt · AES-192-GCM (OS)                        | 17B          |   1,677.55 ns |  10.117 ns |   9.463 ns |         - |
|                                                   |              |               |            |            |           |
| Decrypt · AES-192-GCM (CryptoHives-ARM-AES+PMULL) | 65B          |     115.21 ns |   0.506 ns |   0.473 ns |         - |
| Decrypt · AES-192-GCM (CryptoHives-Scalar)        | 65B          |     649.73 ns |   0.767 ns |   0.717 ns |         - |
| Decrypt · AES-192-GCM (BouncyCastle)              | 65B          |     840.54 ns |   0.722 ns |   0.675 ns |    1640 B |
| Decrypt · AES-192-GCM (OS)                        | 65B          |   1,905.10 ns |   9.644 ns |   8.549 ns |         - |
|                                                   |              |               |            |            |           |
| Encrypt · AES-192-GCM (CryptoHives-ARM-AES+PMULL) | 65B          |      84.41 ns |   0.276 ns |   0.258 ns |         - |
| Encrypt · AES-192-GCM (CryptoHives-Scalar)        | 65B          |     616.70 ns |   0.449 ns |   0.398 ns |         - |
| Encrypt · AES-192-GCM (BouncyCastle)              | 65B          |     768.36 ns |   0.575 ns |   0.538 ns |    1624 B |
| Encrypt · AES-192-GCM (OS)                        | 65B          |   1,691.62 ns |  12.867 ns |  12.035 ns |         - |
|                                                   |              |               |            |            |           |
| Decrypt · AES-192-GCM (CryptoHives-ARM-AES+PMULL) | 128B         |     154.25 ns |   0.684 ns |   0.640 ns |         - |
| Decrypt · AES-192-GCM (CryptoHives-Scalar)        | 128B         |     928.81 ns |   0.381 ns |   0.337 ns |         - |
| Decrypt · AES-192-GCM (BouncyCastle)              | 128B         |   1,062.42 ns |   1.025 ns |   0.856 ns |    1640 B |
| Decrypt · AES-192-GCM (OS)                        | 128B         |   1,912.29 ns |  16.900 ns |  15.808 ns |         - |
|                                                   |              |               |            |            |           |
| Encrypt · AES-192-GCM (CryptoHives-ARM-AES+PMULL) | 128B         |     117.01 ns |   0.403 ns |   0.377 ns |         - |
| Encrypt · AES-192-GCM (CryptoHives-Scalar)        | 128B         |     894.13 ns |   0.112 ns |   0.105 ns |         - |
| Encrypt · AES-192-GCM (BouncyCastle)              | 128B         |   1,009.75 ns |   0.609 ns |   0.570 ns |    1624 B |
| Encrypt · AES-192-GCM (OS)                        | 128B         |   1,729.30 ns |   9.252 ns |   8.201 ns |         - |
|                                                   |              |               |            |            |           |
| Decrypt · AES-192-GCM (CryptoHives-ARM-AES+PMULL) | 152B         |     187.65 ns |   1.166 ns |   1.091 ns |         - |
| Decrypt · AES-192-GCM (CryptoHives-Scalar)        | 152B         |   1,125.93 ns |   1.015 ns |   0.792 ns |         - |
| Decrypt · AES-192-GCM (BouncyCastle)              | 152B         |   1,217.13 ns |   0.582 ns |   0.516 ns |    1640 B |
| Decrypt · AES-192-GCM (OS)                        | 152B         |   1,914.29 ns |  14.994 ns |  14.025 ns |         - |
|                                                   |              |               |            |            |           |
| Encrypt · AES-192-GCM (CryptoHives-ARM-AES+PMULL) | 152B         |     147.21 ns |   0.737 ns |   0.689 ns |         - |
| Encrypt · AES-192-GCM (CryptoHives-Scalar)        | 152B         |   1,082.85 ns |   0.568 ns |   0.474 ns |         - |
| Encrypt · AES-192-GCM (BouncyCastle)              | 152B         |   1,156.52 ns |   1.524 ns |   1.426 ns |    1624 B |
| Encrypt · AES-192-GCM (OS)                        | 152B         |   1,723.15 ns |  10.124 ns |   9.470 ns |         - |
|                                                   |              |               |            |            |           |
| Decrypt · AES-192-GCM (CryptoHives-ARM-AES+PMULL) | 256B         |     255.82 ns |   2.105 ns |   1.866 ns |         - |
| Decrypt · AES-192-GCM (BouncyCastle)              | 256B         |   1,636.81 ns |   0.935 ns |   0.829 ns |    1640 B |
| Decrypt · AES-192-GCM (CryptoHives-Scalar)        | 256B         |   1,691.78 ns |   0.476 ns |   0.422 ns |         - |
| Decrypt · AES-192-GCM (OS)                        | 256B         |   1,910.88 ns |   9.973 ns |   8.841 ns |         - |
|                                                   |              |               |            |            |           |
| Encrypt · AES-192-GCM (CryptoHives-ARM-AES+PMULL) | 256B         |     213.26 ns |   0.915 ns |   0.856 ns |         - |
| Encrypt · AES-192-GCM (BouncyCastle)              | 256B         |   1,612.55 ns |   1.439 ns |   1.276 ns |    1624 B |
| Encrypt · AES-192-GCM (CryptoHives-Scalar)        | 256B         |   1,655.74 ns |   0.214 ns |   0.189 ns |         - |
| Encrypt · AES-192-GCM (OS)                        | 256B         |   1,756.52 ns |  12.565 ns |  11.754 ns |         - |
|                                                   |              |               |            |            |           |
| Decrypt · AES-192-GCM (CryptoHives-ARM-AES+PMULL) | 1KB          |     829.29 ns |   2.973 ns |   2.781 ns |         - |
| Decrypt · AES-192-GCM (OS)                        | 1KB          |   2,052.01 ns |  15.344 ns |  14.353 ns |         - |
| Decrypt · AES-192-GCM (BouncyCastle)              | 1KB          |   5,016.23 ns |   3.877 ns |   3.627 ns |    1640 B |
| Decrypt · AES-192-GCM (CryptoHives-Scalar)        | 1KB          |   6,100.72 ns |   2.250 ns |   2.104 ns |         - |
|                                                   |              |               |            |            |           |
| Encrypt · AES-192-GCM (CryptoHives-ARM-AES+PMULL) | 1KB          |     783.51 ns |   4.139 ns |   3.871 ns |         - |
| Encrypt · AES-192-GCM (OS)                        | 1KB          |   1,862.16 ns |  16.471 ns |  15.407 ns |         - |
| Encrypt · AES-192-GCM (BouncyCastle)              | 1KB          |   5,230.86 ns |   1.743 ns |   1.545 ns |    1624 B |
| Encrypt · AES-192-GCM (CryptoHives-Scalar)        | 1KB          |   5,962.33 ns |   1.588 ns |   1.326 ns |         - |
|                                                   |              |               |            |            |           |
| Decrypt · AES-192-GCM (OS)                        | 8KB          |   2,950.89 ns |  13.615 ns |  11.369 ns |         - |
| Decrypt · AES-192-GCM (CryptoHives-ARM-AES+PMULL) | 8KB          |   6,137.21 ns |  34.518 ns |  32.288 ns |         - |
| Decrypt · AES-192-GCM (BouncyCastle)              | 8KB          |  36,043.71 ns |  33.620 ns |  31.448 ns |    1640 B |
| Decrypt · AES-192-GCM (CryptoHives-Scalar)        | 8KB          |  46,889.80 ns |   7.282 ns |   6.455 ns |         - |
|                                                   |              |               |            |            |           |
| Encrypt · AES-192-GCM (OS)                        | 8KB          |   2,836.81 ns |  21.205 ns |  18.798 ns |         - |
| Encrypt · AES-192-GCM (CryptoHives-ARM-AES+PMULL) | 8KB          |   6,106.32 ns |  42.994 ns |  40.216 ns |         - |
| Encrypt · AES-192-GCM (BouncyCastle)              | 8KB          |  38,505.62 ns |  33.372 ns |  31.216 ns |    1624 B |
| Encrypt · AES-192-GCM (CryptoHives-Scalar)        | 8KB          |  46,819.49 ns |  33.849 ns |  31.663 ns |         - |
|                                                   |              |               |            |            |           |
| Decrypt · AES-192-GCM (OS)                        | 128KB        |  19,419.47 ns |  64.891 ns |  57.524 ns |         - |
| Decrypt · AES-192-GCM (CryptoHives-ARM-AES+PMULL) | 128KB        |  98,833.62 ns | 448.633 ns | 419.652 ns |         - |
| Decrypt · AES-192-GCM (BouncyCastle)              | 128KB        | 570,219.57 ns | 402.324 ns | 376.334 ns |    1640 B |
| Decrypt · AES-192-GCM (CryptoHives-Scalar)        | 128KB        | 747,091.74 ns | 195.242 ns | 152.432 ns |         - |
|                                                   |              |               |            |            |           |
| Encrypt · AES-192-GCM (OS)                        | 128KB        |  20,499.65 ns |  67.806 ns |  63.426 ns |         - |
| Encrypt · AES-192-GCM (CryptoHives-ARM-AES+PMULL) | 128KB        |  98,640.93 ns | 588.235 ns | 550.236 ns |         - |
| Encrypt · AES-192-GCM (BouncyCastle)              | 128KB        | 610,048.24 ns | 335.106 ns | 297.063 ns |    1624 B |
| Encrypt · AES-192-GCM (CryptoHives-Scalar)        | 128KB        | 745,908.59 ns | 154.941 ns | 129.382 ns |         - |