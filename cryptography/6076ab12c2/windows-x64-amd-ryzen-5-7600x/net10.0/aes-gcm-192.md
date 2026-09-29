| Description                                           | TestDataSize | Mean          | Error        | StdDev       | Allocated |
|------------------------------------------------------ |------------- |--------------:|-------------:|-------------:|----------:|
| Decrypt · AES-192-GCM (CryptoHives-AES-NI+PClMul)     | 17B          |     121.06 ns |     0.671 ns |     0.628 ns |         - |
| Decrypt · AES-192-GCM (CryptoHives-AES-NI+PClMulV256) | 17B          |     121.87 ns |     1.449 ns |     1.284 ns |         - |
| Decrypt · AES-192-GCM (OS)                            | 17B          |     141.08 ns |     1.364 ns |     1.276 ns |         - |
| Decrypt · AES-192-GCM (CryptoHives-Scalar)            | 17B          |     404.37 ns |     4.111 ns |     3.845 ns |         - |
| Decrypt · AES-192-GCM (BouncyCastle)                  | 17B          |     608.21 ns |     9.641 ns |     9.019 ns |    1728 B |
|                                                       |              |               |              |              |           |
| Encrypt · AES-192-GCM (CryptoHives-AES-NI+PClMul)     | 17B          |      80.68 ns |     0.165 ns |     0.154 ns |         - |
| Encrypt · AES-192-GCM (CryptoHives-AES-NI+PClMulV256) | 17B          |      81.59 ns |     0.659 ns |     0.617 ns |         - |
| Encrypt · AES-192-GCM (OS)                            | 17B          |     148.05 ns |     2.164 ns |     2.024 ns |         - |
| Encrypt · AES-192-GCM (CryptoHives-Scalar)            | 17B          |     378.11 ns |     3.080 ns |     2.881 ns |         - |
| Encrypt · AES-192-GCM (BouncyCastle)                  | 17B          |     548.36 ns |     7.154 ns |     6.692 ns |    1712 B |
|                                                       |              |               |              |              |           |
| Decrypt · AES-192-GCM (CryptoHives-AES-NI+PClMulV256) | 65B          |     113.57 ns |     1.497 ns |     1.400 ns |         - |
| Decrypt · AES-192-GCM (CryptoHives-AES-NI+PClMul)     | 65B          |     114.12 ns |     1.388 ns |     1.298 ns |         - |
| Decrypt · AES-192-GCM (OS)                            | 65B          |     144.45 ns |     1.560 ns |     1.459 ns |         - |
| Decrypt · AES-192-GCM (CryptoHives-Scalar)            | 65B          |     738.65 ns |    10.588 ns |     9.904 ns |         - |
| Decrypt · AES-192-GCM (BouncyCastle)                  | 65B          |     846.12 ns |    14.251 ns |    13.330 ns |    1728 B |
|                                                       |              |               |              |              |           |
| Encrypt · AES-192-GCM (CryptoHives-AES-NI+PClMul)     | 65B          |      89.47 ns |     0.545 ns |     0.483 ns |         - |
| Encrypt · AES-192-GCM (CryptoHives-AES-NI+PClMulV256) | 65B          |      90.47 ns |     0.690 ns |     0.646 ns |         - |
| Encrypt · AES-192-GCM (OS)                            | 65B          |     152.35 ns |     2.125 ns |     1.988 ns |         - |
| Encrypt · AES-192-GCM (CryptoHives-Scalar)            | 65B          |     669.68 ns |     6.796 ns |     6.357 ns |         - |
| Encrypt · AES-192-GCM (BouncyCastle)                  | 65B          |     746.72 ns |    13.260 ns |    12.404 ns |    1712 B |
|                                                       |              |               |              |              |           |
| Decrypt · AES-192-GCM (CryptoHives-AES-NI+PClMulV256) | 128B         |     117.52 ns |     1.121 ns |     1.049 ns |         - |
| Decrypt · AES-192-GCM (CryptoHives-AES-NI+PClMul)     | 128B         |     117.70 ns |     1.029 ns |     0.963 ns |         - |
| Decrypt · AES-192-GCM (OS)                            | 128B         |     143.19 ns |     1.806 ns |     1.690 ns |         - |
| Decrypt · AES-192-GCM (CryptoHives-Scalar)            | 128B         |   1,003.74 ns |    11.747 ns |    10.988 ns |         - |
| Decrypt · AES-192-GCM (BouncyCastle)                  | 128B         |   1,061.90 ns |    16.140 ns |    15.097 ns |    1728 B |
|                                                       |              |               |              |              |           |
| Encrypt · AES-192-GCM (CryptoHives-AES-NI+PClMulV256) | 128B         |      75.13 ns |     0.854 ns |     0.799 ns |         - |
| Encrypt · AES-192-GCM (CryptoHives-AES-NI+PClMul)     | 128B         |      78.18 ns |     0.663 ns |     0.620 ns |         - |
| Encrypt · AES-192-GCM (OS)                            | 128B         |     142.78 ns |     1.459 ns |     1.365 ns |         - |
| Encrypt · AES-192-GCM (BouncyCastle)                  | 128B         |     946.54 ns |    11.812 ns |    11.049 ns |    1712 B |
| Encrypt · AES-192-GCM (CryptoHives-Scalar)            | 128B         |     970.51 ns |    13.047 ns |    12.204 ns |         - |
|                                                       |              |               |              |              |           |
| Decrypt · AES-192-GCM (CryptoHives-AES-NI+PClMul)     | 152B         |     135.31 ns |     0.642 ns |     0.601 ns |         - |
| Decrypt · AES-192-GCM (CryptoHives-AES-NI+PClMulV256) | 152B         |     136.43 ns |     0.848 ns |     0.793 ns |         - |
| Decrypt · AES-192-GCM (OS)                            | 152B         |     161.98 ns |     1.814 ns |     1.608 ns |         - |
| Decrypt · AES-192-GCM (CryptoHives-Scalar)            | 152B         |   1,200.66 ns |    14.420 ns |    13.489 ns |         - |
| Decrypt · AES-192-GCM (BouncyCastle)                  | 152B         |   1,213.39 ns |    18.393 ns |    17.205 ns |    1728 B |
|                                                       |              |               |              |              |           |
| Encrypt · AES-192-GCM (CryptoHives-AES-NI+PClMulV256) | 152B         |     105.19 ns |     0.790 ns |     0.739 ns |         - |
| Encrypt · AES-192-GCM (CryptoHives-AES-NI+PClMul)     | 152B         |     107.37 ns |     1.245 ns |     1.165 ns |         - |
| Encrypt · AES-192-GCM (OS)                            | 152B         |     162.78 ns |     1.720 ns |     1.609 ns |         - |
| Encrypt · AES-192-GCM (BouncyCastle)                  | 152B         |   1,093.18 ns |    15.491 ns |    14.490 ns |    1712 B |
| Encrypt · AES-192-GCM (CryptoHives-Scalar)            | 152B         |   1,170.18 ns |    17.428 ns |    16.303 ns |         - |
|                                                       |              |               |              |              |           |
| Decrypt · AES-192-GCM (CryptoHives-AES-NI+PClMulV256) | 256B         |     136.98 ns |     1.645 ns |     1.539 ns |         - |
| Decrypt · AES-192-GCM (CryptoHives-AES-NI+PClMul)     | 256B         |     148.67 ns |     1.714 ns |     1.603 ns |         - |
| Decrypt · AES-192-GCM (OS)                            | 256B         |     166.36 ns |     2.232 ns |     2.088 ns |         - |
| Decrypt · AES-192-GCM (BouncyCastle)                  | 256B         |   1,593.70 ns |    28.286 ns |    26.459 ns |    1728 B |
| Decrypt · AES-192-GCM (CryptoHives-Scalar)            | 256B         |   1,790.62 ns |    20.104 ns |    18.805 ns |         - |
|                                                       |              |               |              |              |           |
| Encrypt · AES-192-GCM (CryptoHives-AES-NI+PClMulV256) | 256B         |      96.24 ns |     1.030 ns |     0.964 ns |         - |
| Encrypt · AES-192-GCM (CryptoHives-AES-NI+PClMul)     | 256B         |     101.60 ns |     1.302 ns |     1.218 ns |         - |
| Encrypt · AES-192-GCM (OS)                            | 256B         |     146.48 ns |     1.446 ns |     1.208 ns |         - |
| Encrypt · AES-192-GCM (BouncyCastle)                  | 256B         |   1,476.48 ns |    16.996 ns |    15.898 ns |    1712 B |
| Encrypt · AES-192-GCM (CryptoHives-Scalar)            | 256B         |   1,773.92 ns |    23.751 ns |    22.217 ns |         - |
|                                                       |              |               |              |              |           |
| Decrypt · AES-192-GCM (OS)                            | 1KB          |     221.78 ns |     2.365 ns |     2.212 ns |         - |
| Decrypt · AES-192-GCM (CryptoHives-AES-NI+PClMulV256) | 1KB          |     244.51 ns |     2.659 ns |     2.487 ns |         - |
| Decrypt · AES-192-GCM (CryptoHives-AES-NI+PClMul)     | 1KB          |     301.04 ns |     5.759 ns |     5.387 ns |         - |
| Decrypt · AES-192-GCM (BouncyCastle)                  | 1KB          |   4,824.47 ns |    76.461 ns |    71.522 ns |    1728 B |
| Decrypt · AES-192-GCM (CryptoHives-Scalar)            | 1KB          |   6,533.16 ns |    81.466 ns |    76.203 ns |         - |
|                                                       |              |               |              |              |           |
| Encrypt · AES-192-GCM (OS)                            | 1KB          |     215.09 ns |     3.064 ns |     2.866 ns |         - |
| Encrypt · AES-192-GCM (CryptoHives-AES-NI+PClMulV256) | 1KB          |     224.24 ns |     2.476 ns |     2.316 ns |         - |
| Encrypt · AES-192-GCM (CryptoHives-AES-NI+PClMul)     | 1KB          |     248.74 ns |     3.177 ns |     2.972 ns |         - |
| Encrypt · AES-192-GCM (BouncyCastle)                  | 1KB          |   4,699.05 ns |    75.214 ns |    62.807 ns |    1712 B |
| Encrypt · AES-192-GCM (CryptoHives-Scalar)            | 1KB          |   6,530.70 ns |    87.079 ns |    81.454 ns |         - |
|                                                       |              |               |              |              |           |
| Decrypt · AES-192-GCM (OS)                            | 8KB          |     917.59 ns |     8.292 ns |     6.925 ns |         - |
| Decrypt · AES-192-GCM (CryptoHives-AES-NI+PClMulV256) | 8KB          |   1,273.67 ns |    18.857 ns |    16.716 ns |         - |
| Decrypt · AES-192-GCM (CryptoHives-AES-NI+PClMul)     | 8KB          |   1,730.24 ns |    23.195 ns |    21.697 ns |         - |
| Decrypt · AES-192-GCM (BouncyCastle)                  | 8KB          |  34,742.11 ns |   419.339 ns |   392.250 ns |    1728 B |
| Decrypt · AES-192-GCM (CryptoHives-Scalar)            | 8KB          |  51,049.41 ns |   494.119 ns |   462.199 ns |         - |
|                                                       |              |               |              |              |           |
| Encrypt · AES-192-GCM (OS)                            | 8KB          |     812.98 ns |    14.747 ns |    13.795 ns |         - |
| Encrypt · AES-192-GCM (CryptoHives-AES-NI+PClMulV256) | 8KB          |   1,424.79 ns |    18.678 ns |    17.471 ns |         - |
| Encrypt · AES-192-GCM (CryptoHives-AES-NI+PClMul)     | 8KB          |   1,623.20 ns |    24.108 ns |    22.551 ns |         - |
| Encrypt · AES-192-GCM (BouncyCastle)                  | 8KB          |  34,643.37 ns |   461.592 ns |   431.774 ns |    1712 B |
| Encrypt · AES-192-GCM (CryptoHives-Scalar)            | 8KB          |  50,980.10 ns |   671.635 ns |   628.248 ns |         - |
|                                                       |              |               |              |              |           |
| Decrypt · AES-192-GCM (OS)                            | 128KB        |  13,585.50 ns |   123.947 ns |   115.940 ns |         - |
| Decrypt · AES-192-GCM (CryptoHives-AES-NI+PClMulV256) | 128KB        |  19,439.41 ns |   261.372 ns |   244.488 ns |         - |
| Decrypt · AES-192-GCM (CryptoHives-AES-NI+PClMul)     | 128KB        |  26,163.86 ns |   330.852 ns |   309.479 ns |         - |
| Decrypt · AES-192-GCM (BouncyCastle)                  | 128KB        | 550,291.10 ns | 7,814.650 ns | 7,309.829 ns |    1728 B |
| Decrypt · AES-192-GCM (CryptoHives-Scalar)            | 128KB        | 813,275.40 ns | 8,853.133 ns | 8,281.226 ns |         - |
|                                                       |              |               |              |              |           |
| Encrypt · AES-192-GCM (OS)                            | 128KB        |  11,893.78 ns |   104.967 ns |    98.187 ns |         - |
| Encrypt · AES-192-GCM (CryptoHives-AES-NI+PClMulV256) | 128KB        |  21,943.66 ns |   147.741 ns |   138.197 ns |         - |
| Encrypt · AES-192-GCM (CryptoHives-AES-NI+PClMul)     | 128KB        |  25,237.42 ns |   250.967 ns |   222.476 ns |         - |
| Encrypt · AES-192-GCM (BouncyCastle)                  | 128KB        | 549,326.18 ns | 8,346.949 ns | 7,807.741 ns |    1712 B |
| Encrypt · AES-192-GCM (CryptoHives-Scalar)            | 128KB        | 816,532.14 ns | 9,989.160 ns | 9,343.866 ns |         - |