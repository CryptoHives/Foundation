| Description                                           | TestDataSize | Mean          | Error        | StdDev       | Code Size | Allocated |
|------------------------------------------------------ |------------- |--------------:|-------------:|-------------:|----------:|----------:|
| Decrypt · AES-256-GCM (CryptoHives-AES-NI+PClMulV256) | 17B          |     116.81 ns |     0.361 ns |     0.337 ns |     306 B |         - |
| Decrypt · AES-256-GCM (CryptoHives-AES-NI+PClMul)     | 17B          |     123.97 ns |     2.508 ns |     2.888 ns |     306 B |         - |
| Decrypt · AES-256-GCM (OS)                            | 17B          |     144.42 ns |     0.615 ns |     0.545 ns |   2,230 B |         - |
| Decrypt · AES-256-GCM (CryptoHives-Scalar)            | 17B          |     422.13 ns |     1.042 ns |     0.870 ns |     306 B |         - |
| Decrypt · AES-256-GCM (BouncyCastle)                  | 17B          |     652.04 ns |     2.239 ns |     1.985 ns |     306 B |    1832 B |
|                                                       |              |               |              |              |           |           |
| Encrypt · AES-256-GCM (CryptoHives-AES-NI+PClMul)     | 17B          |      80.62 ns |     0.174 ns |     0.163 ns |     383 B |         - |
| Encrypt · AES-256-GCM (CryptoHives-AES-NI+PClMulV256) | 17B          |      81.30 ns |     0.227 ns |     0.212 ns |     383 B |         - |
| Encrypt · AES-256-GCM (OS)                            | 17B          |     152.69 ns |     0.400 ns |     0.355 ns |   2,202 B |         - |
| Encrypt · AES-256-GCM (CryptoHives-Scalar)            | 17B          |     374.54 ns |     1.079 ns |     0.957 ns |     386 B |         - |
| Encrypt · AES-256-GCM (BouncyCastle)                  | 17B          |     588.93 ns |     3.783 ns |     3.354 ns |     383 B |    1816 B |
|                                                       |              |               |              |              |           |           |
| Decrypt · AES-256-GCM (CryptoHives-AES-NI+PClMulV256) | 65B          |     125.13 ns |     0.531 ns |     0.443 ns |     306 B |         - |
| Decrypt · AES-256-GCM (CryptoHives-AES-NI+PClMul)     | 65B          |     132.98 ns |     0.359 ns |     0.336 ns |     306 B |         - |
| Decrypt · AES-256-GCM (OS)                            | 65B          |     147.12 ns |     0.285 ns |     0.238 ns |   2,230 B |         - |
| Decrypt · AES-256-GCM (CryptoHives-Scalar)            | 65B          |     734.68 ns |     2.428 ns |     2.027 ns |     306 B |         - |
| Decrypt · AES-256-GCM (BouncyCastle)                  | 65B          |     917.56 ns |     2.763 ns |     2.307 ns |     306 B |    1832 B |
|                                                       |              |               |              |              |           |           |
| Encrypt · AES-256-GCM (CryptoHives-AES-NI+PClMulV256) | 65B          |      90.45 ns |     0.300 ns |     0.280 ns |     383 B |         - |
| Encrypt · AES-256-GCM (CryptoHives-AES-NI+PClMul)     | 65B          |      91.24 ns |     0.315 ns |     0.295 ns |     383 B |         - |
| Encrypt · AES-256-GCM (OS)                            | 65B          |     156.14 ns |     0.452 ns |     0.377 ns |   2,202 B |         - |
| Encrypt · AES-256-GCM (CryptoHives-Scalar)            | 65B          |     683.01 ns |     1.716 ns |     1.521 ns |     386 B |         - |
| Encrypt · AES-256-GCM (BouncyCastle)                  | 65B          |     814.55 ns |     4.672 ns |     3.901 ns |     383 B |    1816 B |
|                                                       |              |               |              |              |           |           |
| Decrypt · AES-256-GCM (CryptoHives-AES-NI+PClMul)     | 128B         |     127.09 ns |     0.556 ns |     0.493 ns |     306 B |         - |
| Decrypt · AES-256-GCM (CryptoHives-AES-NI+PClMulV256) | 128B         |     128.22 ns |     0.837 ns |     0.783 ns |     306 B |         - |
| Decrypt · AES-256-GCM (OS)                            | 128B         |     144.07 ns |     0.375 ns |     0.351 ns |   2,230 B |         - |
| Decrypt · AES-256-GCM (CryptoHives-Scalar)            | 128B         |   1,038.42 ns |     5.995 ns |     5.314 ns |     306 B |         - |
| Decrypt · AES-256-GCM (BouncyCastle)                  | 128B         |   1,142.88 ns |     5.442 ns |     4.544 ns |     306 B |    1832 B |
|                                                       |              |               |              |              |           |           |
| Encrypt · AES-256-GCM (CryptoHives-AES-NI+PClMulV256) | 128B         |      73.07 ns |     0.226 ns |     0.211 ns |     383 B |         - |
| Encrypt · AES-256-GCM (CryptoHives-AES-NI+PClMul)     | 128B         |      75.34 ns |     0.244 ns |     0.228 ns |     383 B |         - |
| Encrypt · AES-256-GCM (OS)                            | 128B         |     144.80 ns |     0.504 ns |     0.472 ns |   2,202 B |         - |
| Encrypt · AES-256-GCM (CryptoHives-Scalar)            | 128B         |     999.52 ns |     2.979 ns |     2.641 ns |     383 B |         - |
| Encrypt · AES-256-GCM (BouncyCastle)                  | 128B         |   1,031.27 ns |     6.520 ns |     6.099 ns |     383 B |    1816 B |
|                                                       |              |               |              |              |           |           |
| Decrypt · AES-256-GCM (CryptoHives-AES-NI+PClMul)     | 152B         |     145.18 ns |     0.522 ns |     0.488 ns |     306 B |         - |
| Decrypt · AES-256-GCM (CryptoHives-AES-NI+PClMulV256) | 152B         |     146.67 ns |     0.420 ns |     0.373 ns |     306 B |         - |
| Decrypt · AES-256-GCM (OS)                            | 152B         |     165.60 ns |     0.296 ns |     0.247 ns |   2,230 B |         - |
| Decrypt · AES-256-GCM (CryptoHives-Scalar)            | 152B         |   1,234.91 ns |     3.483 ns |     3.088 ns |     306 B |         - |
| Decrypt · AES-256-GCM (BouncyCastle)                  | 152B         |   1,320.22 ns |     7.354 ns |     6.879 ns |     306 B |    1832 B |
|                                                       |              |               |              |              |           |           |
| Encrypt · AES-256-GCM (CryptoHives-AES-NI+PClMul)     | 152B         |     109.76 ns |     0.323 ns |     0.286 ns |     383 B |         - |
| Encrypt · AES-256-GCM (CryptoHives-AES-NI+PClMulV256) | 152B         |     113.99 ns |     0.358 ns |     0.335 ns |     383 B |         - |
| Encrypt · AES-256-GCM (OS)                            | 152B         |     167.51 ns |     0.261 ns |     0.218 ns |   2,202 B |         - |
| Encrypt · AES-256-GCM (CryptoHives-Scalar)            | 152B         |   1,189.91 ns |     4.868 ns |     4.553 ns |     383 B |         - |
| Encrypt · AES-256-GCM (BouncyCastle)                  | 152B         |   1,197.36 ns |     3.346 ns |     2.794 ns |     383 B |    1816 B |
|                                                       |              |               |              |              |           |           |
| Decrypt · AES-256-GCM (CryptoHives-AES-NI+PClMulV256) | 256B         |     150.56 ns |     0.512 ns |     0.479 ns |     306 B |         - |
| Decrypt · AES-256-GCM (CryptoHives-AES-NI+PClMul)     | 256B         |     159.56 ns |     0.488 ns |     0.457 ns |     306 B |         - |
| Decrypt · AES-256-GCM (OS)                            | 256B         |     161.99 ns |     0.543 ns |     0.508 ns |   2,230 B |         - |
| Decrypt · AES-256-GCM (BouncyCastle)                  | 256B         |   1,734.76 ns |     7.406 ns |     6.566 ns |     306 B |    1832 B |
| Decrypt · AES-256-GCM (CryptoHives-Scalar)            | 256B         |   2,075.55 ns |     6.000 ns |     5.319 ns |     306 B |         - |
|                                                       |              |               |              |              |           |           |
| Encrypt · AES-256-GCM (CryptoHives-AES-NI+PClMulV256) | 256B         |      96.53 ns |     0.231 ns |     0.204 ns |     383 B |         - |
| Encrypt · AES-256-GCM (CryptoHives-AES-NI+PClMul)     | 256B         |     101.87 ns |     0.220 ns |     0.195 ns |     383 B |         - |
| Encrypt · AES-256-GCM (OS)                            | 256B         |     154.99 ns |     0.308 ns |     0.257 ns |   2,202 B |         - |
| Encrypt · AES-256-GCM (BouncyCastle)                  | 256B         |   1,630.74 ns |     6.582 ns |     5.835 ns |     383 B |    1816 B |
| Encrypt · AES-256-GCM (CryptoHives-Scalar)            | 256B         |   1,806.00 ns |     5.669 ns |     4.734 ns |     383 B |         - |
|                                                       |              |               |              |              |           |           |
| Decrypt · AES-256-GCM (OS)                            | 1KB          |     249.86 ns |     1.363 ns |     1.275 ns |   2,230 B |         - |
| Decrypt · AES-256-GCM (CryptoHives-AES-NI+PClMulV256) | 1KB          |     298.16 ns |     0.601 ns |     0.533 ns |     306 B |         - |
| Decrypt · AES-256-GCM (CryptoHives-AES-NI+PClMul)     | 1KB          |     325.76 ns |     0.807 ns |     0.674 ns |     306 B |         - |
| Decrypt · AES-256-GCM (BouncyCastle)                  | 1KB          |   5,374.05 ns |    22.593 ns |    20.028 ns |     306 B |    1832 B |
| Decrypt · AES-256-GCM (CryptoHives-Scalar)            | 1KB          |   6,741.52 ns |    11.603 ns |    10.286 ns |     306 B |         - |
|                                                       |              |               |              |              |           |           |
| Encrypt · AES-256-GCM (OS)                            | 1KB          |     219.70 ns |     0.794 ns |     0.743 ns |   2,205 B |         - |
| Encrypt · AES-256-GCM (CryptoHives-AES-NI+PClMulV256) | 1KB          |     234.39 ns |     0.663 ns |     0.620 ns |     383 B |         - |
| Encrypt · AES-256-GCM (CryptoHives-AES-NI+PClMul)     | 1KB          |     286.50 ns |     4.469 ns |     4.181 ns |     386 B |         - |
| Encrypt · AES-256-GCM (BouncyCastle)                  | 1KB          |   5,258.43 ns |    11.660 ns |    10.336 ns |     383 B |    1816 B |
| Encrypt · AES-256-GCM (CryptoHives-Scalar)            | 1KB          |   6,748.83 ns |    21.548 ns |    20.156 ns |     386 B |         - |
|                                                       |              |               |              |              |           |           |
| Decrypt · AES-256-GCM (OS)                            | 8KB          |   1,100.92 ns |     2.713 ns |     2.405 ns |   2,230 B |         - |
| Decrypt · AES-256-GCM (CryptoHives-AES-NI+PClMulV256) | 8KB          |   1,317.22 ns |     5.128 ns |     4.796 ns |     306 B |         - |
| Decrypt · AES-256-GCM (CryptoHives-AES-NI+PClMul)     | 8KB          |   1,816.03 ns |     5.524 ns |     4.897 ns |     306 B |         - |
| Decrypt · AES-256-GCM (BouncyCastle)                  | 8KB          |  38,988.62 ns |   141.206 ns |   117.913 ns |     306 B |    1832 B |
| Decrypt · AES-256-GCM (CryptoHives-Scalar)            | 8KB          |  52,375.05 ns |   122.339 ns |   108.450 ns |     306 B |         - |
|                                                       |              |               |              |              |           |           |
| Encrypt · AES-256-GCM (OS)                            | 8KB          |     858.35 ns |     1.055 ns |     0.881 ns |   2,205 B |         - |
| Encrypt · AES-256-GCM (CryptoHives-AES-NI+PClMulV256) | 8KB          |   1,547.64 ns |     2.533 ns |     2.115 ns |     383 B |         - |
| Encrypt · AES-256-GCM (CryptoHives-AES-NI+PClMul)     | 8KB          |   1,724.68 ns |     2.735 ns |     2.425 ns |     383 B |         - |
| Encrypt · AES-256-GCM (BouncyCastle)                  | 8KB          |  39,014.05 ns |   113.395 ns |   100.522 ns |     383 B |    1816 B |
| Encrypt · AES-256-GCM (CryptoHives-Scalar)            | 8KB          |  52,285.19 ns |   123.283 ns |   109.287 ns |     383 B |         - |
|                                                       |              |               |              |              |           |           |
| Decrypt · AES-256-GCM (OS)                            | 128KB        |  16,758.65 ns |    41.478 ns |    38.799 ns |   2,385 B |         - |
| Decrypt · AES-256-GCM (CryptoHives-AES-NI+PClMulV256) | 128KB        |  20,438.00 ns |    70.940 ns |    66.358 ns |     306 B |         - |
| Decrypt · AES-256-GCM (CryptoHives-AES-NI+PClMul)     | 128KB        |  27,461.09 ns |    57.090 ns |    50.609 ns |     306 B |         - |
| Decrypt · AES-256-GCM (BouncyCastle)                  | 128KB        | 618,105.03 ns | 2,403.170 ns | 2,130.348 ns |     306 B |    1832 B |
| Decrypt · AES-256-GCM (CryptoHives-Scalar)            | 128KB        | 838,356.36 ns | 2,418.619 ns | 2,144.042 ns |     306 B |         - |
|                                                       |              |               |              |              |           |           |
| Encrypt · AES-256-GCM (OS)                            | 128KB        |  12,330.28 ns |    23.899 ns |    19.957 ns |   2,205 B |         - |
| Encrypt · AES-256-GCM (CryptoHives-AES-NI+PClMulV256) | 128KB        |  23,651.71 ns |    56.283 ns |    49.893 ns |     383 B |         - |
| Encrypt · AES-256-GCM (CryptoHives-AES-NI+PClMul)     | 128KB        |  26,950.36 ns |    99.993 ns |    93.533 ns |     383 B |         - |
| Encrypt · AES-256-GCM (BouncyCastle)                  | 128KB        | 620,453.76 ns | 1,576.917 ns | 1,397.896 ns |     383 B |    1816 B |
| Encrypt · AES-256-GCM (CryptoHives-Scalar)            | 128KB        | 836,894.89 ns | 2,164.482 ns | 1,807.441 ns |     383 B |         - |