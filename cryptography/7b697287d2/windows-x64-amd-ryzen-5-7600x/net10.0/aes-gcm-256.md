| Description                                           | TestDataSize | Mean          | Error        | StdDev       | Median        | Code Size | Allocated |
|------------------------------------------------------ |------------- |--------------:|-------------:|-------------:|--------------:|----------:|----------:|
| Decrypt · AES-256-GCM (CryptoHives-AES-NI+PClMulV256) | 17B          |     122.11 ns |     2.462 ns |     3.760 ns |     124.56 ns |     306 B |         - |
| Decrypt · AES-256-GCM (CryptoHives-AES-NI+PClMul)     | 17B          |     122.89 ns |     2.458 ns |     3.754 ns |     125.11 ns |     306 B |         - |
| Decrypt · AES-256-GCM (OS)                            | 17B          |     143.76 ns |     0.315 ns |     0.279 ns |     143.73 ns |   2,230 B |         - |
| Decrypt · AES-256-GCM (CryptoHives-Scalar)            | 17B          |     422.62 ns |     0.788 ns |     0.658 ns |     422.49 ns |     306 B |         - |
| Decrypt · AES-256-GCM (BouncyCastle)                  | 17B          |     642.64 ns |     3.381 ns |     3.162 ns |     641.56 ns |     306 B |    1832 B |
|                                                       |              |               |              |              |               |           |           |
| Encrypt · AES-256-GCM (CryptoHives-AES-NI+PClMul)     | 17B          |      79.79 ns |     0.254 ns |     0.237 ns |      79.73 ns |     383 B |         - |
| Encrypt · AES-256-GCM (CryptoHives-AES-NI+PClMulV256) | 17B          |      80.74 ns |     0.235 ns |     0.220 ns |      80.76 ns |     383 B |         - |
| Encrypt · AES-256-GCM (OS)                            | 17B          |     151.30 ns |     0.339 ns |     0.317 ns |     151.31 ns |   2,202 B |         - |
| Encrypt · AES-256-GCM (CryptoHives-Scalar)            | 17B          |     373.18 ns |     1.138 ns |     1.009 ns |     373.09 ns |     386 B |         - |
| Encrypt · AES-256-GCM (BouncyCastle)                  | 17B          |     581.81 ns |     2.386 ns |     2.116 ns |     582.07 ns |     383 B |    1816 B |
|                                                       |              |               |              |              |               |           |           |
| Decrypt · AES-256-GCM (CryptoHives-AES-NI+PClMul)     | 65B          |     131.41 ns |     2.534 ns |     2.918 ns |     132.83 ns |     306 B |         - |
| Decrypt · AES-256-GCM (CryptoHives-AES-NI+PClMulV256) | 65B          |     138.29 ns |     2.737 ns |     3.042 ns |     139.96 ns |     306 B |         - |
| Decrypt · AES-256-GCM (OS)                            | 65B          |     151.63 ns |     0.422 ns |     0.352 ns |     151.63 ns |   2,230 B |         - |
| Decrypt · AES-256-GCM (CryptoHives-Scalar)            | 65B          |     725.58 ns |     1.311 ns |     1.163 ns |     725.39 ns |     306 B |         - |
| Decrypt · AES-256-GCM (BouncyCastle)                  | 65B          |     898.00 ns |     2.679 ns |     2.506 ns |     898.01 ns |     306 B |    1832 B |
|                                                       |              |               |              |              |               |           |           |
| Encrypt · AES-256-GCM (CryptoHives-AES-NI+PClMul)     | 65B          |      90.77 ns |     0.269 ns |     0.252 ns |      90.73 ns |     383 B |         - |
| Encrypt · AES-256-GCM (CryptoHives-AES-NI+PClMulV256) | 65B          |      93.38 ns |     1.330 ns |     1.244 ns |      93.42 ns |     383 B |         - |
| Encrypt · AES-256-GCM (OS)                            | 65B          |     154.84 ns |     0.206 ns |     0.172 ns |     154.83 ns |   2,202 B |         - |
| Encrypt · AES-256-GCM (CryptoHives-Scalar)            | 65B          |     681.61 ns |     1.588 ns |     1.485 ns |     681.44 ns |     386 B |         - |
| Encrypt · AES-256-GCM (BouncyCastle)                  | 65B          |     824.97 ns |     2.971 ns |     2.634 ns |     824.92 ns |     383 B |    1816 B |
|                                                       |              |               |              |              |               |           |           |
| Decrypt · AES-256-GCM (CryptoHives-AES-NI+PClMul)     | 128B         |     122.36 ns |     0.370 ns |     0.346 ns |     122.35 ns |     306 B |         - |
| Decrypt · AES-256-GCM (CryptoHives-AES-NI+PClMulV256) | 128B         |     122.51 ns |     0.493 ns |     0.461 ns |     122.58 ns |     306 B |         - |
| Decrypt · AES-256-GCM (OS)                            | 128B         |     146.98 ns |     0.659 ns |     0.616 ns |     146.85 ns |   2,230 B |         - |
| Decrypt · AES-256-GCM (CryptoHives-Scalar)            | 128B         |   1,029.17 ns |     2.329 ns |     1.945 ns |   1,028.54 ns |     306 B |         - |
| Decrypt · AES-256-GCM (BouncyCastle)                  | 128B         |   1,132.36 ns |     9.378 ns |     8.772 ns |   1,128.76 ns |     306 B |    1832 B |
|                                                       |              |               |              |              |               |           |           |
| Encrypt · AES-256-GCM (CryptoHives-AES-NI+PClMulV256) | 128B         |      73.95 ns |     0.251 ns |     0.209 ns |      73.87 ns |     383 B |         - |
| Encrypt · AES-256-GCM (CryptoHives-AES-NI+PClMul)     | 128B         |      75.51 ns |     0.238 ns |     0.223 ns |      75.50 ns |     383 B |         - |
| Encrypt · AES-256-GCM (OS)                            | 128B         |     152.35 ns |     0.326 ns |     0.289 ns |     152.31 ns |   2,202 B |         - |
| Encrypt · AES-256-GCM (CryptoHives-Scalar)            | 128B         |     984.97 ns |     1.706 ns |     1.332 ns |     985.23 ns |     383 B |         - |
| Encrypt · AES-256-GCM (BouncyCastle)                  | 128B         |   1,028.62 ns |     6.450 ns |     6.033 ns |   1,027.10 ns |     386 B |    1816 B |
|                                                       |              |               |              |              |               |           |           |
| Decrypt · AES-256-GCM (CryptoHives-AES-NI+PClMulV256) | 152B         |     138.49 ns |     0.553 ns |     0.517 ns |     138.41 ns |     306 B |         - |
| Decrypt · AES-256-GCM (CryptoHives-AES-NI+PClMul)     | 152B         |     139.23 ns |     0.435 ns |     0.407 ns |     139.15 ns |     306 B |         - |
| Decrypt · AES-256-GCM (OS)                            | 152B         |     167.88 ns |     0.397 ns |     0.352 ns |     167.76 ns |   2,230 B |         - |
| Decrypt · AES-256-GCM (CryptoHives-Scalar)            | 152B         |   1,228.70 ns |     3.263 ns |     3.052 ns |   1,228.70 ns |     306 B |         - |
| Decrypt · AES-256-GCM (BouncyCastle)                  | 152B         |   1,303.47 ns |     4.563 ns |     4.268 ns |   1,303.65 ns |     306 B |    1832 B |
|                                                       |              |               |              |              |               |           |           |
| Encrypt · AES-256-GCM (CryptoHives-AES-NI+PClMulV256) | 152B         |     106.14 ns |     0.432 ns |     0.404 ns |     106.14 ns |     386 B |         - |
| Encrypt · AES-256-GCM (CryptoHives-AES-NI+PClMul)     | 152B         |     107.12 ns |     0.143 ns |     0.127 ns |     107.08 ns |     383 B |         - |
| Encrypt · AES-256-GCM (OS)                            | 152B         |     165.38 ns |     0.777 ns |     0.689 ns |     165.19 ns |   2,202 B |         - |
| Encrypt · AES-256-GCM (CryptoHives-Scalar)            | 152B         |   1,184.46 ns |     2.850 ns |     2.526 ns |   1,184.37 ns |     383 B |         - |
| Encrypt · AES-256-GCM (BouncyCastle)                  | 152B         |   1,184.92 ns |     3.174 ns |     2.478 ns |   1,184.90 ns |     386 B |    1816 B |
|                                                       |              |               |              |              |               |           |           |
| Decrypt · AES-256-GCM (CryptoHives-AES-NI+PClMulV256) | 256B         |     140.08 ns |     0.866 ns |     0.810 ns |     139.94 ns |     306 B |         - |
| Decrypt · AES-256-GCM (CryptoHives-AES-NI+PClMul)     | 256B         |     153.08 ns |     0.474 ns |     0.396 ns |     153.16 ns |     306 B |         - |
| Decrypt · AES-256-GCM (OS)                            | 256B         |     163.20 ns |     0.312 ns |     0.277 ns |     163.20 ns |   2,230 B |         - |
| Decrypt · AES-256-GCM (BouncyCastle)                  | 256B         |   1,739.56 ns |     7.215 ns |     6.749 ns |   1,738.63 ns |     306 B |    1832 B |
| Decrypt · AES-256-GCM (CryptoHives-Scalar)            | 256B         |   1,913.04 ns |     4.981 ns |     4.159 ns |   1,912.76 ns |     306 B |         - |
|                                                       |              |               |              |              |               |           |           |
| Encrypt · AES-256-GCM (CryptoHives-AES-NI+PClMulV256) | 256B         |      96.25 ns |     0.202 ns |     0.189 ns |      96.29 ns |     383 B |         - |
| Encrypt · AES-256-GCM (CryptoHives-AES-NI+PClMul)     | 256B         |     102.57 ns |     0.335 ns |     0.314 ns |     102.63 ns |     383 B |         - |
| Encrypt · AES-256-GCM (OS)                            | 256B         |     146.69 ns |     0.426 ns |     0.398 ns |     146.60 ns |   2,202 B |         - |
| Encrypt · AES-256-GCM (BouncyCastle)                  | 256B         |   1,613.67 ns |     3.490 ns |     3.265 ns |   1,614.05 ns |     383 B |    1816 B |
| Encrypt · AES-256-GCM (CryptoHives-Scalar)            | 256B         |   1,789.94 ns |     1.733 ns |     1.447 ns |   1,790.09 ns |     383 B |         - |
|                                                       |              |               |              |              |               |           |           |
| Decrypt · AES-256-GCM (OS)                            | 1KB          |     246.46 ns |     0.403 ns |     0.377 ns |     246.55 ns |   2,230 B |         - |
| Decrypt · AES-256-GCM (CryptoHives-AES-NI+PClMulV256) | 1KB          |     256.04 ns |     1.068 ns |     0.999 ns |     256.12 ns |     306 B |         - |
| Decrypt · AES-256-GCM (CryptoHives-AES-NI+PClMul)     | 1KB          |     311.77 ns |     1.103 ns |     1.031 ns |     311.74 ns |     306 B |         - |
| Decrypt · AES-256-GCM (BouncyCastle)                  | 1KB          |   5,325.98 ns |    20.639 ns |    19.305 ns |   5,322.21 ns |     306 B |    1832 B |
| Decrypt · AES-256-GCM (CryptoHives-Scalar)            | 1KB          |   6,768.18 ns |    23.740 ns |    22.207 ns |   6,757.43 ns |     306 B |         - |
|                                                       |              |               |              |              |               |           |           |
| Encrypt · AES-256-GCM (OS)                            | 1KB          |     221.75 ns |     0.793 ns |     0.742 ns |     222.00 ns |   2,202 B |         - |
| Encrypt · AES-256-GCM (CryptoHives-AES-NI+PClMulV256) | 1KB          |     232.99 ns |     0.374 ns |     0.313 ns |     232.91 ns |     383 B |         - |
| Encrypt · AES-256-GCM (CryptoHives-AES-NI+PClMul)     | 1KB          |     256.77 ns |     0.842 ns |     0.788 ns |     256.66 ns |     383 B |         - |
| Encrypt · AES-256-GCM (BouncyCastle)                  | 1KB          |   5,214.40 ns |    19.594 ns |    18.328 ns |   5,213.97 ns |     383 B |    1816 B |
| Encrypt · AES-256-GCM (CryptoHives-Scalar)            | 1KB          |   6,803.90 ns |    11.881 ns |     9.921 ns |   6,801.78 ns |     386 B |         - |
|                                                       |              |               |              |              |               |           |           |
| Decrypt · AES-256-GCM (OS)                            | 8KB          |   1,094.73 ns |     2.838 ns |     2.516 ns |   1,094.94 ns |   2,230 B |         - |
| Decrypt · AES-256-GCM (CryptoHives-AES-NI+PClMulV256) | 8KB          |   1,302.68 ns |     3.656 ns |     3.420 ns |   1,303.06 ns |     306 B |         - |
| Decrypt · AES-256-GCM (CryptoHives-AES-NI+PClMul)     | 8KB          |   1,813.88 ns |     5.416 ns |     5.066 ns |   1,813.93 ns |     306 B |         - |
| Decrypt · AES-256-GCM (BouncyCastle)                  | 8KB          |  38,790.05 ns |   158.441 ns |   148.206 ns |  38,747.28 ns |     306 B |    1832 B |
| Decrypt · AES-256-GCM (CryptoHives-Scalar)            | 8KB          |  52,910.96 ns |   146.802 ns |   130.136 ns |  52,873.72 ns |     306 B |         - |
|                                                       |              |               |              |              |               |           |           |
| Encrypt · AES-256-GCM (OS)                            | 8KB          |     829.28 ns |     1.823 ns |     1.705 ns |     829.53 ns |   2,202 B |         - |
| Encrypt · AES-256-GCM (CryptoHives-AES-NI+PClMulV256) | 8KB          |   1,515.31 ns |     3.195 ns |     2.833 ns |   1,516.35 ns |     383 B |         - |
| Encrypt · AES-256-GCM (CryptoHives-AES-NI+PClMul)     | 8KB          |   1,713.70 ns |     2.231 ns |     1.863 ns |   1,713.23 ns |     383 B |         - |
| Encrypt · AES-256-GCM (BouncyCastle)                  | 8KB          |  38,655.46 ns |    91.804 ns |    81.382 ns |  38,657.51 ns |     383 B |    1816 B |
| Encrypt · AES-256-GCM (CryptoHives-Scalar)            | 8KB          |  52,134.82 ns |   120.009 ns |   112.257 ns |  52,140.70 ns |     383 B |         - |
|                                                       |              |               |              |              |               |           |           |
| Decrypt · AES-256-GCM (OS)                            | 128KB        |  16,604.48 ns |    43.630 ns |    38.677 ns |  16,608.29 ns |   2,385 B |         - |
| Decrypt · AES-256-GCM (CryptoHives-AES-NI+PClMulV256) | 128KB        |  20,256.29 ns |    46.482 ns |    38.815 ns |  20,256.95 ns |     306 B |         - |
| Decrypt · AES-256-GCM (CryptoHives-AES-NI+PClMul)     | 128KB        |  27,343.71 ns |    67.800 ns |    63.420 ns |  27,334.29 ns |     306 B |         - |
| Decrypt · AES-256-GCM (BouncyCastle)                  | 128KB        | 614,628.85 ns | 2,191.023 ns | 2,049.485 ns | 613,701.66 ns |     306 B |    1832 B |
| Decrypt · AES-256-GCM (CryptoHives-Scalar)            | 128KB        | 831,337.14 ns | 2,364.742 ns | 2,211.981 ns | 830,774.02 ns |     306 B |         - |
|                                                       |              |               |              |              |               |           |           |
| Encrypt · AES-256-GCM (OS)                            | 128KB        |  12,433.54 ns |    41.736 ns |    39.040 ns |  12,439.13 ns |   2,202 B |         - |
| Encrypt · AES-256-GCM (CryptoHives-AES-NI+PClMulV256) | 128KB        |  23,486.45 ns |    49.353 ns |    43.750 ns |  23,485.12 ns |     383 B |         - |
| Encrypt · AES-256-GCM (CryptoHives-AES-NI+PClMul)     | 128KB        |  26,659.96 ns |    52.467 ns |    49.078 ns |  26,644.02 ns |     383 B |         - |
| Encrypt · AES-256-GCM (BouncyCastle)                  | 128KB        | 613,130.15 ns | 1,372.551 ns | 1,146.142 ns | 613,468.36 ns |     383 B |    1816 B |
| Encrypt · AES-256-GCM (CryptoHives-Scalar)            | 128KB        | 830,513.35 ns | 3,181.360 ns | 2,975.846 ns | 828,771.97 ns |     383 B |         - |