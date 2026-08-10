| Description                                           | TestDataSize | Mean          | Error        | StdDev       | Allocated |
|------------------------------------------------------ |------------- |--------------:|-------------:|-------------:|----------:|
| Decrypt · AES-128-GCM (OS)                            | 17B          |     115.36 ns |     0.451 ns |     0.422 ns |         - |
| Decrypt · AES-128-GCM (CryptoHives-AES-NI+PClMulV256) | 17B          |     117.80 ns |     0.241 ns |     0.226 ns |         - |
| Decrypt · AES-128-GCM (CryptoHives-AES-NI+PClMul)     | 17B          |     118.99 ns |     0.239 ns |     0.224 ns |         - |
| Decrypt · AES-128-GCM (CryptoHives-Scalar)            | 17B          |     336.41 ns |     1.631 ns |     1.526 ns |         - |
| Decrypt · AES-128-GCM (BouncyCastle)                  | 17B          |     556.45 ns |     4.420 ns |     4.134 ns |    1624 B |
|                                                       |              |               |              |              |           |
| Encrypt · AES-128-GCM (CryptoHives-AES-NI+PClMul)     | 17B          |      62.22 ns |     0.155 ns |     0.145 ns |         - |
| Encrypt · AES-128-GCM (CryptoHives-AES-NI+PClMulV256) | 17B          |      62.54 ns |     0.156 ns |     0.146 ns |         - |
| Encrypt · AES-128-GCM (OS)                            | 17B          |     119.99 ns |     0.397 ns |     0.371 ns |         - |
| Encrypt · AES-128-GCM (CryptoHives-Scalar)            | 17B          |     309.73 ns |     0.588 ns |     0.491 ns |         - |
| Encrypt · AES-128-GCM (BouncyCastle)                  | 17B          |     492.14 ns |     1.594 ns |     1.413 ns |    1608 B |
|                                                       |              |               |              |              |           |
| Decrypt · AES-128-GCM (CryptoHives-AES-NI+PClMulV256) | 65B          |      97.88 ns |     0.373 ns |     0.349 ns |         - |
| Decrypt · AES-128-GCM (CryptoHives-AES-NI+PClMul)     | 65B          |     101.55 ns |     0.129 ns |     0.114 ns |         - |
| Decrypt · AES-128-GCM (OS)                            | 65B          |     117.21 ns |     0.270 ns |     0.226 ns |         - |
| Decrypt · AES-128-GCM (CryptoHives-Scalar)            | 65B          |     581.35 ns |     3.181 ns |     2.820 ns |         - |
| Decrypt · AES-128-GCM (BouncyCastle)                  | 65B          |     748.74 ns |     3.771 ns |     3.343 ns |    1624 B |
|                                                       |              |               |              |              |           |
| Encrypt · AES-128-GCM (CryptoHives-AES-NI+PClMulV256) | 65B          |      68.18 ns |     0.143 ns |     0.127 ns |         - |
| Encrypt · AES-128-GCM (CryptoHives-AES-NI+PClMul)     | 65B          |      68.54 ns |     0.206 ns |     0.192 ns |         - |
| Encrypt · AES-128-GCM (OS)                            | 65B          |     124.98 ns |     0.245 ns |     0.191 ns |         - |
| Encrypt · AES-128-GCM (CryptoHives-Scalar)            | 65B          |     547.58 ns |     1.888 ns |     1.766 ns |         - |
| Encrypt · AES-128-GCM (BouncyCastle)                  | 65B          |     663.33 ns |     4.148 ns |     3.880 ns |    1608 B |
|                                                       |              |               |              |              |           |
| Decrypt · AES-128-GCM (CryptoHives-AES-NI+PClMulV256) | 128B         |      92.49 ns |     0.297 ns |     0.278 ns |         - |
| Decrypt · AES-128-GCM (CryptoHives-AES-NI+PClMul)     | 128B         |      94.73 ns |     0.188 ns |     0.166 ns |         - |
| Decrypt · AES-128-GCM (OS)                            | 128B         |     116.50 ns |     0.545 ns |     0.510 ns |         - |
| Decrypt · AES-128-GCM (CryptoHives-Scalar)            | 128B         |     816.23 ns |     3.511 ns |     3.284 ns |         - |
| Decrypt · AES-128-GCM (BouncyCastle)                  | 128B         |     894.51 ns |     2.394 ns |     2.123 ns |    1624 B |
|                                                       |              |               |              |              |           |
| Encrypt · AES-128-GCM (CryptoHives-AES-NI+PClMulV256) | 128B         |      57.54 ns |     0.130 ns |     0.122 ns |         - |
| Encrypt · AES-128-GCM (CryptoHives-AES-NI+PClMul)     | 128B         |      59.64 ns |     0.210 ns |     0.196 ns |         - |
| Encrypt · AES-128-GCM (OS)                            | 128B         |     119.54 ns |     0.562 ns |     0.526 ns |         - |
| Encrypt · AES-128-GCM (CryptoHives-Scalar)            | 128B         |     787.47 ns |     3.046 ns |     2.849 ns |         - |
| Encrypt · AES-128-GCM (BouncyCastle)                  | 128B         |     791.11 ns |     3.725 ns |     3.302 ns |    1608 B |
|                                                       |              |               |              |              |           |
| Decrypt · AES-128-GCM (CryptoHives-AES-NI+PClMulV256) | 152B         |     119.14 ns |     0.366 ns |     0.343 ns |         - |
| Decrypt · AES-128-GCM (CryptoHives-AES-NI+PClMul)     | 152B         |     122.59 ns |     0.285 ns |     0.253 ns |         - |
| Decrypt · AES-128-GCM (OS)                            | 152B         |     133.18 ns |     0.399 ns |     0.373 ns |         - |
| Decrypt · AES-128-GCM (CryptoHives-Scalar)            | 152B         |     978.85 ns |     3.268 ns |     3.057 ns |         - |
| Decrypt · AES-128-GCM (BouncyCastle)                  | 152B         |     988.49 ns |     5.152 ns |     4.302 ns |    1624 B |
|                                                       |              |               |              |              |           |
| Encrypt · AES-128-GCM (CryptoHives-AES-NI+PClMulV256) | 152B         |      82.61 ns |     0.194 ns |     0.182 ns |         - |
| Encrypt · AES-128-GCM (CryptoHives-AES-NI+PClMul)     | 152B         |      84.61 ns |     0.261 ns |     0.244 ns |         - |
| Encrypt · AES-128-GCM (OS)                            | 152B         |     133.21 ns |     0.662 ns |     0.620 ns |         - |
| Encrypt · AES-128-GCM (BouncyCastle)                  | 152B         |     908.51 ns |     5.545 ns |     5.186 ns |    1608 B |
| Encrypt · AES-128-GCM (CryptoHives-Scalar)            | 152B         |     951.71 ns |     4.256 ns |     3.981 ns |         - |
|                                                       |              |               |              |              |           |
| Decrypt · AES-128-GCM (CryptoHives-AES-NI+PClMulV256) | 256B         |     107.84 ns |     0.464 ns |     0.434 ns |         - |
| Decrypt · AES-128-GCM (CryptoHives-AES-NI+PClMul)     | 256B         |     119.73 ns |     0.636 ns |     0.595 ns |         - |
| Decrypt · AES-128-GCM (OS)                            | 256B         |     124.29 ns |     0.310 ns |     0.290 ns |         - |
| Decrypt · AES-128-GCM (BouncyCastle)                  | 256B         |   1,260.40 ns |     7.431 ns |     6.951 ns |    1624 B |
| Decrypt · AES-128-GCM (CryptoHives-Scalar)            | 256B         |   1,455.75 ns |     4.351 ns |     4.070 ns |         - |
|                                                       |              |               |              |              |           |
| Encrypt · AES-128-GCM (CryptoHives-AES-NI+PClMulV256) | 256B         |      72.79 ns |     0.293 ns |     0.274 ns |         - |
| Encrypt · AES-128-GCM (CryptoHives-AES-NI+PClMul)     | 256B         |      77.83 ns |     0.333 ns |     0.295 ns |         - |
| Encrypt · AES-128-GCM (OS)                            | 256B         |     120.78 ns |     0.544 ns |     0.509 ns |         - |
| Encrypt · AES-128-GCM (BouncyCastle)                  | 256B         |   1,183.38 ns |     8.789 ns |     8.221 ns |    1608 B |
| Encrypt · AES-128-GCM (CryptoHives-Scalar)            | 256B         |   1,427.31 ns |     4.823 ns |     4.512 ns |         - |
|                                                       |              |               |              |              |           |
| Decrypt · AES-128-GCM (OS)                            | 1KB          |     176.88 ns |     0.971 ns |     0.860 ns |         - |
| Decrypt · AES-128-GCM (CryptoHives-AES-NI+PClMulV256) | 1KB          |     193.79 ns |     1.057 ns |     0.989 ns |         - |
| Decrypt · AES-128-GCM (CryptoHives-AES-NI+PClMul)     | 1KB          |     240.54 ns |     1.045 ns |     0.978 ns |         - |
| Decrypt · AES-128-GCM (BouncyCastle)                  | 1KB          |   3,650.03 ns |    10.071 ns |     8.928 ns |    1624 B |
| Decrypt · AES-128-GCM (CryptoHives-Scalar)            | 1KB          |   5,301.19 ns |    18.975 ns |    17.749 ns |         - |
|                                                       |              |               |              |              |           |
| Encrypt · AES-128-GCM (CryptoHives-AES-NI+PClMulV256) | 1KB          |     169.88 ns |     0.397 ns |     0.371 ns |         - |
| Encrypt · AES-128-GCM (OS)                            | 1KB          |     171.20 ns |     0.627 ns |     0.556 ns |         - |
| Encrypt · AES-128-GCM (CryptoHives-AES-NI+PClMul)     | 1KB          |     195.02 ns |     0.546 ns |     0.511 ns |         - |
| Encrypt · AES-128-GCM (BouncyCastle)                  | 1KB          |   3,528.52 ns |    19.218 ns |    17.977 ns |    1608 B |
| Encrypt · AES-128-GCM (CryptoHives-Scalar)            | 1KB          |   5,282.98 ns |    19.701 ns |    16.451 ns |         - |
|                                                       |              |               |              |              |           |
| Decrypt · AES-128-GCM (OS)                            | 8KB          |     697.38 ns |     2.528 ns |     2.364 ns |         - |
| Decrypt · AES-128-GCM (CryptoHives-AES-NI+PClMulV256) | 8KB          |   1,008.21 ns |     3.247 ns |     2.878 ns |         - |
| Decrypt · AES-128-GCM (CryptoHives-AES-NI+PClMul)     | 8KB          |   1,365.39 ns |     4.269 ns |     3.993 ns |         - |
| Decrypt · AES-128-GCM (BouncyCastle)                  | 8KB          |  25,400.87 ns |    92.402 ns |    86.433 ns |    1624 B |
| Decrypt · AES-128-GCM (CryptoHives-Scalar)            | 8KB          |  41,106.89 ns |   172.087 ns |   160.970 ns |         - |
|                                                       |              |               |              |              |           |
| Encrypt · AES-128-GCM (OS)                            | 8KB          |     660.88 ns |     3.272 ns |     3.061 ns |         - |
| Encrypt · AES-128-GCM (CryptoHives-AES-NI+PClMulV256) | 8KB          |   1,093.28 ns |     2.196 ns |     1.946 ns |         - |
| Encrypt · AES-128-GCM (CryptoHives-AES-NI+PClMul)     | 8KB          |   1,297.97 ns |     3.210 ns |     3.002 ns |         - |
| Encrypt · AES-128-GCM (BouncyCastle)                  | 8KB          |  25,487.30 ns |    67.742 ns |    56.568 ns |    1608 B |
| Encrypt · AES-128-GCM (CryptoHives-Scalar)            | 8KB          |  41,140.75 ns |   260.029 ns |   243.231 ns |         - |
|                                                       |              |               |              |              |           |
| Decrypt · AES-128-GCM (OS)                            | 128KB        |  10,847.21 ns |    13.060 ns |    11.577 ns |         - |
| Decrypt · AES-128-GCM (CryptoHives-AES-NI+PClMulV256) | 128KB        |  15,620.14 ns |    67.150 ns |    59.527 ns |         - |
| Decrypt · AES-128-GCM (CryptoHives-AES-NI+PClMul)     | 128KB        |  20,623.03 ns |   101.666 ns |    95.098 ns |         - |
| Decrypt · AES-128-GCM (BouncyCastle)                  | 128KB        | 401,817.23 ns |   939.908 ns |   833.204 ns |    1624 B |
| Decrypt · AES-128-GCM (CryptoHives-Scalar)            | 128KB        | 671,240.85 ns | 1,063.373 ns |   994.680 ns |         - |
|                                                       |              |               |              |              |           |
| Encrypt · AES-128-GCM (OS)                            | 128KB        |   9,606.26 ns |    35.176 ns |    32.903 ns |         - |
| Encrypt · AES-128-GCM (CryptoHives-AES-NI+PClMulV256) | 128KB        |  16,753.47 ns |    61.975 ns |    57.972 ns |         - |
| Encrypt · AES-128-GCM (CryptoHives-AES-NI+PClMul)     | 128KB        |  20,240.08 ns |    76.682 ns |    67.977 ns |         - |
| Encrypt · AES-128-GCM (BouncyCastle)                  | 128KB        | 400,510.74 ns | 1,054.740 ns |   986.605 ns |    1608 B |
| Encrypt · AES-128-GCM (CryptoHives-Scalar)            | 128KB        | 656,694.11 ns | 2,870.029 ns | 2,544.206 ns |         - |