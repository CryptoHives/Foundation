| Description                                           | TestDataSize | Mean          | Error        | StdDev       | Allocated |
|------------------------------------------------------ |------------- |--------------:|-------------:|-------------:|----------:|
| Decrypt · AES-192-GCM (OS)                            | 17B          |     120.80 ns |     0.226 ns |     0.200 ns |         - |
| Decrypt · AES-192-GCM (CryptoHives-AES-NI+PClMul)     | 17B          |     123.47 ns |     0.167 ns |     0.130 ns |         - |
| Decrypt · AES-192-GCM (CryptoHives-AES-NI+PClMulV256) | 17B          |     123.81 ns |     0.095 ns |     0.085 ns |         - |
| Decrypt · AES-192-GCM (CryptoHives-Scalar)            | 17B          |     375.30 ns |     0.882 ns |     0.737 ns |         - |
| Decrypt · AES-192-GCM (BouncyCastle)                  | 17B          |     630.59 ns |     2.297 ns |     2.036 ns |    1728 B |
|                                                       |              |               |              |              |           |
| Encrypt · AES-192-GCM (CryptoHives-AES-NI+PClMul)     | 17B          |      69.29 ns |     0.119 ns |     0.105 ns |         - |
| Encrypt · AES-192-GCM (CryptoHives-AES-NI+PClMulV256) | 17B          |      69.36 ns |     0.167 ns |     0.148 ns |         - |
| Encrypt · AES-192-GCM (OS)                            | 17B          |     125.65 ns |     0.250 ns |     0.222 ns |         - |
| Encrypt · AES-192-GCM (CryptoHives-Scalar)            | 17B          |     336.02 ns |     0.608 ns |     0.539 ns |         - |
| Encrypt · AES-192-GCM (BouncyCastle)                  | 17B          |     563.13 ns |     1.906 ns |     1.592 ns |    1712 B |
|                                                       |              |               |              |              |           |
| Decrypt · AES-192-GCM (CryptoHives-AES-NI+PClMulV256) | 65B          |     108.17 ns |     0.205 ns |     0.171 ns |         - |
| Decrypt · AES-192-GCM (CryptoHives-AES-NI+PClMul)     | 65B          |     111.93 ns |     0.208 ns |     0.174 ns |         - |
| Decrypt · AES-192-GCM (OS)                            | 65B          |     124.79 ns |     0.217 ns |     0.203 ns |         - |
| Decrypt · AES-192-GCM (CryptoHives-Scalar)            | 65B          |     635.28 ns |     1.600 ns |     1.497 ns |         - |
| Decrypt · AES-192-GCM (BouncyCastle)                  | 65B          |     828.99 ns |     2.152 ns |     1.680 ns |    1728 B |
|                                                       |              |               |              |              |           |
| Encrypt · AES-192-GCM (CryptoHives-AES-NI+PClMulV256) | 65B          |      76.16 ns |     0.090 ns |     0.079 ns |         - |
| Encrypt · AES-192-GCM (CryptoHives-AES-NI+PClMul)     | 65B          |      76.45 ns |     0.147 ns |     0.131 ns |         - |
| Encrypt · AES-192-GCM (OS)                            | 65B          |     130.58 ns |     0.389 ns |     0.325 ns |         - |
| Encrypt · AES-192-GCM (CryptoHives-Scalar)            | 65B          |     605.49 ns |     0.987 ns |     0.923 ns |         - |
| Encrypt · AES-192-GCM (BouncyCastle)                  | 65B          |     742.86 ns |     2.065 ns |     1.612 ns |    1712 B |
|                                                       |              |               |              |              |           |
| Decrypt · AES-192-GCM (CryptoHives-AES-NI+PClMulV256) | 128B         |     100.27 ns |     0.159 ns |     0.141 ns |         - |
| Decrypt · AES-192-GCM (CryptoHives-AES-NI+PClMul)     | 128B         |     100.84 ns |     0.320 ns |     0.284 ns |         - |
| Decrypt · AES-192-GCM (OS)                            | 128B         |     123.67 ns |     0.569 ns |     0.444 ns |         - |
| Decrypt · AES-192-GCM (CryptoHives-Scalar)            | 128B         |     900.41 ns |     1.735 ns |     1.449 ns |         - |
| Decrypt · AES-192-GCM (BouncyCastle)                  | 128B         |   1,016.39 ns |     2.764 ns |     2.450 ns |    1728 B |
|                                                       |              |               |              |              |           |
| Encrypt · AES-192-GCM (CryptoHives-AES-NI+PClMulV256) | 128B         |      63.76 ns |     0.112 ns |     0.100 ns |         - |
| Encrypt · AES-192-GCM (CryptoHives-AES-NI+PClMul)     | 128B         |      65.97 ns |     0.105 ns |     0.093 ns |         - |
| Encrypt · AES-192-GCM (OS)                            | 128B         |     122.86 ns |     0.244 ns |     0.203 ns |         - |
| Encrypt · AES-192-GCM (CryptoHives-Scalar)            | 128B         |     872.13 ns |     1.645 ns |     1.284 ns |         - |
| Encrypt · AES-192-GCM (BouncyCastle)                  | 128B         |     915.15 ns |     4.827 ns |     4.279 ns |    1712 B |
|                                                       |              |               |              |              |           |
| Decrypt · AES-192-GCM (CryptoHives-AES-NI+PClMulV256) | 152B         |     131.02 ns |     0.167 ns |     0.148 ns |         - |
| Decrypt · AES-192-GCM (CryptoHives-AES-NI+PClMul)     | 152B         |     132.29 ns |     0.367 ns |     0.325 ns |         - |
| Decrypt · AES-192-GCM (OS)                            | 152B         |     139.30 ns |     0.208 ns |     0.195 ns |         - |
| Decrypt · AES-192-GCM (CryptoHives-Scalar)            | 152B         |   1,079.64 ns |     3.145 ns |     2.941 ns |         - |
| Decrypt · AES-192-GCM (BouncyCastle)                  | 152B         |   1,136.80 ns |     4.901 ns |     4.584 ns |    1728 B |
|                                                       |              |               |              |              |           |
| Encrypt · AES-192-GCM (CryptoHives-AES-NI+PClMulV256) | 152B         |      91.07 ns |     0.121 ns |     0.113 ns |         - |
| Encrypt · AES-192-GCM (CryptoHives-AES-NI+PClMul)     | 152B         |      92.81 ns |     0.202 ns |     0.168 ns |         - |
| Encrypt · AES-192-GCM (OS)                            | 152B         |     140.31 ns |     0.370 ns |     0.309 ns |         - |
| Encrypt · AES-192-GCM (CryptoHives-Scalar)            | 152B         |   1,056.58 ns |     1.782 ns |     1.667 ns |         - |
| Encrypt · AES-192-GCM (BouncyCastle)                  | 152B         |   1,070.39 ns |     4.468 ns |     3.961 ns |    1712 B |
|                                                       |              |               |              |              |           |
| Decrypt · AES-192-GCM (CryptoHives-AES-NI+PClMulV256) | 256B         |     122.90 ns |     0.541 ns |     0.451 ns |         - |
| Decrypt · AES-192-GCM (CryptoHives-AES-NI+PClMul)     | 256B         |     128.34 ns |     0.275 ns |     0.229 ns |         - |
| Decrypt · AES-192-GCM (OS)                            | 256B         |     139.47 ns |     0.227 ns |     0.201 ns |         - |
| Decrypt · AES-192-GCM (BouncyCastle)                  | 256B         |   1,468.52 ns |     6.098 ns |     5.704 ns |    1728 B |
| Decrypt · AES-192-GCM (CryptoHives-Scalar)            | 256B         |   1,611.16 ns |     4.268 ns |     3.992 ns |         - |
|                                                       |              |               |              |              |           |
| Encrypt · AES-192-GCM (CryptoHives-AES-NI+PClMulV256) | 256B         |      82.39 ns |     0.232 ns |     0.206 ns |         - |
| Encrypt · AES-192-GCM (CryptoHives-AES-NI+PClMul)     | 256B         |      87.45 ns |     0.236 ns |     0.209 ns |         - |
| Encrypt · AES-192-GCM (OS)                            | 256B         |     134.31 ns |     0.337 ns |     0.298 ns |         - |
| Encrypt · AES-192-GCM (BouncyCastle)                  | 256B         |   1,373.41 ns |     4.665 ns |     4.135 ns |    1712 B |
| Encrypt · AES-192-GCM (CryptoHives-Scalar)            | 256B         |   1,583.42 ns |     3.265 ns |     2.895 ns |         - |
|                                                       |              |               |              |              |           |
| Decrypt · AES-192-GCM (OS)                            | 1KB          |     193.13 ns |     0.785 ns |     0.696 ns |         - |
| Decrypt · AES-192-GCM (CryptoHives-AES-NI+PClMulV256) | 1KB          |     208.56 ns |     0.296 ns |     0.262 ns |         - |
| Decrypt · AES-192-GCM (CryptoHives-AES-NI+PClMul)     | 1KB          |     268.47 ns |     0.984 ns |     0.921 ns |         - |
| Decrypt · AES-192-GCM (BouncyCastle)                  | 1KB          |   4,277.00 ns |     5.985 ns |     5.305 ns |    1728 B |
| Decrypt · AES-192-GCM (CryptoHives-Scalar)            | 1KB          |   5,876.38 ns |     8.178 ns |     7.250 ns |         - |
|                                                       |              |               |              |              |           |
| Encrypt · AES-192-GCM (OS)                            | 1KB          |     180.47 ns |     0.337 ns |     0.282 ns |         - |
| Encrypt · AES-192-GCM (CryptoHives-AES-NI+PClMulV256) | 1KB          |     191.29 ns |     0.507 ns |     0.474 ns |         - |
| Encrypt · AES-192-GCM (CryptoHives-AES-NI+PClMul)     | 1KB          |     210.95 ns |     0.331 ns |     0.293 ns |         - |
| Encrypt · AES-192-GCM (BouncyCastle)                  | 1KB          |   4,167.29 ns |     9.854 ns |     8.735 ns |    1712 B |
| Encrypt · AES-192-GCM (CryptoHives-Scalar)            | 1KB          |   5,899.56 ns |    12.058 ns |    10.069 ns |         - |
|                                                       |              |               |              |              |           |
| Decrypt · AES-192-GCM (OS)                            | 8KB          |     774.53 ns |     1.855 ns |     1.645 ns |         - |
| Decrypt · AES-192-GCM (CryptoHives-AES-NI+PClMulV256) | 8KB          |   1,114.36 ns |     1.952 ns |     1.731 ns |         - |
| Decrypt · AES-192-GCM (CryptoHives-AES-NI+PClMul)     | 8KB          |   1,479.76 ns |     4.129 ns |     3.660 ns |         - |
| Decrypt · AES-192-GCM (BouncyCastle)                  | 8KB          |  30,162.55 ns |    34.672 ns |    28.953 ns |    1728 B |
| Decrypt · AES-192-GCM (CryptoHives-Scalar)            | 8KB          |  45,845.07 ns |   111.186 ns |    92.846 ns |         - |
|                                                       |              |               |              |              |           |
| Encrypt · AES-192-GCM (OS)                            | 8KB          |     698.82 ns |     1.857 ns |     1.646 ns |         - |
| Encrypt · AES-192-GCM (CryptoHives-AES-NI+PClMulV256) | 8KB          |   1,213.83 ns |     4.938 ns |     4.378 ns |         - |
| Encrypt · AES-192-GCM (CryptoHives-AES-NI+PClMul)     | 8KB          |   1,377.27 ns |     3.766 ns |     3.523 ns |         - |
| Encrypt · AES-192-GCM (BouncyCastle)                  | 8KB          |  30,072.43 ns |    33.706 ns |    31.528 ns |    1712 B |
| Encrypt · AES-192-GCM (CryptoHives-Scalar)            | 8KB          |  45,959.71 ns |   153.950 ns |   136.473 ns |         - |
|                                                       |              |               |              |              |           |
| Decrypt · AES-192-GCM (OS)                            | 128KB        |  11,884.81 ns |    17.907 ns |    16.751 ns |         - |
| Decrypt · AES-192-GCM (CryptoHives-AES-NI+PClMulV256) | 128KB        |  17,050.61 ns |   304.750 ns |   270.153 ns |         - |
| Decrypt · AES-192-GCM (CryptoHives-AES-NI+PClMul)     | 128KB        |  22,215.62 ns |    61.871 ns |    51.665 ns |         - |
| Decrypt · AES-192-GCM (BouncyCastle)                  | 128KB        | 476,774.19 ns |   885.362 ns |   784.850 ns |    1728 B |
| Decrypt · AES-192-GCM (CryptoHives-Scalar)            | 128KB        | 730,811.60 ns | 1,700.731 ns | 1,420.187 ns |         - |
|                                                       |              |               |              |              |           |
| Encrypt · AES-192-GCM (OS)                            | 128KB        |  10,380.00 ns |    25.911 ns |    22.970 ns |         - |
| Encrypt · AES-192-GCM (CryptoHives-AES-NI+PClMulV256) | 128KB        |  18,860.65 ns |   104.917 ns |    98.139 ns |         - |
| Encrypt · AES-192-GCM (CryptoHives-AES-NI+PClMul)     | 128KB        |  21,431.82 ns |    59.238 ns |    49.466 ns |         - |
| Encrypt · AES-192-GCM (BouncyCastle)                  | 128KB        | 476,306.86 ns |   619.326 ns |   517.166 ns |    1712 B |
| Encrypt · AES-192-GCM (CryptoHives-Scalar)            | 128KB        | 730,918.98 ns | 1,590.454 ns | 1,328.101 ns |         - |