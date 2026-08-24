| Description                                           | TestDataSize | Mean          | Error        | StdDev       | Allocated |
|------------------------------------------------------ |------------- |--------------:|-------------:|-------------:|----------:|
| Decrypt · AES-192-GCM (CryptoHives-AES-NI+PClMulV256) | 17B          |     119.38 ns |     0.202 ns |     0.169 ns |         - |
| Decrypt · AES-192-GCM (OS)                            | 17B          |     122.51 ns |     0.350 ns |     0.327 ns |         - |
| Decrypt · AES-192-GCM (CryptoHives-AES-NI+PClMul)     | 17B          |     123.88 ns |     0.345 ns |     0.322 ns |         - |
| Decrypt · AES-192-GCM (CryptoHives-Scalar)            | 17B          |     431.85 ns |     0.605 ns |     0.506 ns |         - |
| Decrypt · AES-192-GCM (BouncyCastle)                  | 17B          |     541.87 ns |     2.762 ns |     2.449 ns |    1728 B |
|                                                       |              |               |              |              |           |
| Encrypt · AES-192-GCM (CryptoHives-AES-NI+PClMul)     | 17B          |      69.25 ns |     0.253 ns |     0.224 ns |         - |
| Encrypt · AES-192-GCM (CryptoHives-AES-NI+PClMulV256) | 17B          |      69.95 ns |     0.115 ns |     0.096 ns |         - |
| Encrypt · AES-192-GCM (OS)                            | 17B          |     126.31 ns |     0.371 ns |     0.347 ns |         - |
| Encrypt · AES-192-GCM (CryptoHives-Scalar)            | 17B          |     400.53 ns |     1.251 ns |     1.109 ns |         - |
| Encrypt · AES-192-GCM (BouncyCastle)                  | 17B          |     475.33 ns |     2.124 ns |     1.986 ns |    1712 B |
|                                                       |              |               |              |              |           |
| Decrypt · AES-192-GCM (CryptoHives-AES-NI+PClMul)     | 65B          |     114.24 ns |     0.344 ns |     0.322 ns |         - |
| Decrypt · AES-192-GCM (CryptoHives-AES-NI+PClMulV256) | 65B          |     117.15 ns |     0.558 ns |     0.495 ns |         - |
| Decrypt · AES-192-GCM (OS)                            | 65B          |     125.27 ns |     0.312 ns |     0.276 ns |         - |
| Decrypt · AES-192-GCM (BouncyCastle)                  | 65B          |     747.81 ns |     3.624 ns |     3.212 ns |    1728 B |
| Decrypt · AES-192-GCM (CryptoHives-Scalar)            | 65B          |     761.68 ns |     2.217 ns |     2.074 ns |         - |
|                                                       |              |               |              |              |           |
| Encrypt · AES-192-GCM (CryptoHives-AES-NI+PClMulV256) | 65B          |      75.76 ns |     0.166 ns |     0.156 ns |         - |
| Encrypt · AES-192-GCM (CryptoHives-AES-NI+PClMul)     | 65B          |      76.06 ns |     0.780 ns |     0.730 ns |         - |
| Encrypt · AES-192-GCM (OS)                            | 65B          |     131.56 ns |     1.571 ns |     1.312 ns |         - |
| Encrypt · AES-192-GCM (BouncyCastle)                  | 65B          |     663.52 ns |     5.236 ns |     4.372 ns |    1712 B |
| Encrypt · AES-192-GCM (CryptoHives-Scalar)            | 65B          |     731.35 ns |     1.601 ns |     1.419 ns |         - |
|                                                       |              |               |              |              |           |
| Decrypt · AES-192-GCM (CryptoHives-AES-NI+PClMulV256) | 128B         |      98.45 ns |     0.294 ns |     0.246 ns |         - |
| Decrypt · AES-192-GCM (CryptoHives-AES-NI+PClMul)     | 128B         |     102.05 ns |     0.247 ns |     0.219 ns |         - |
| Decrypt · AES-192-GCM (OS)                            | 128B         |     123.03 ns |     0.263 ns |     0.246 ns |         - |
| Decrypt · AES-192-GCM (BouncyCastle)                  | 128B         |     928.83 ns |     5.227 ns |     4.889 ns |    1728 B |
| Decrypt · AES-192-GCM (CryptoHives-Scalar)            | 128B         |   1,164.39 ns |     2.209 ns |     1.959 ns |         - |
|                                                       |              |               |              |              |           |
| Encrypt · AES-192-GCM (CryptoHives-AES-NI+PClMulV256) | 128B         |      63.61 ns |     0.105 ns |     0.088 ns |         - |
| Encrypt · AES-192-GCM (CryptoHives-AES-NI+PClMul)     | 128B         |      65.39 ns |     0.150 ns |     0.126 ns |         - |
| Encrypt · AES-192-GCM (OS)                            | 128B         |     122.93 ns |     0.763 ns |     0.595 ns |         - |
| Encrypt · AES-192-GCM (BouncyCastle)                  | 128B         |     817.61 ns |     3.240 ns |     3.030 ns |    1712 B |
| Encrypt · AES-192-GCM (CryptoHives-Scalar)            | 128B         |   1,065.33 ns |    21.137 ns |    20.759 ns |         - |
|                                                       |              |               |              |              |           |
| Decrypt · AES-192-GCM (CryptoHives-AES-NI+PClMulV256) | 152B         |     127.97 ns |     0.315 ns |     0.263 ns |         - |
| Decrypt · AES-192-GCM (CryptoHives-AES-NI+PClMul)     | 152B         |     128.35 ns |     0.219 ns |     0.183 ns |         - |
| Decrypt · AES-192-GCM (OS)                            | 152B         |     140.27 ns |     0.487 ns |     0.456 ns |         - |
| Decrypt · AES-192-GCM (BouncyCastle)                  | 152B         |   1,059.90 ns |     7.633 ns |     6.374 ns |    1728 B |
| Decrypt · AES-192-GCM (CryptoHives-Scalar)            | 152B         |   1,307.29 ns |     5.094 ns |     4.516 ns |         - |
|                                                       |              |               |              |              |           |
| Encrypt · AES-192-GCM (CryptoHives-AES-NI+PClMulV256) | 152B         |      90.79 ns |     0.138 ns |     0.129 ns |         - |
| Encrypt · AES-192-GCM (CryptoHives-AES-NI+PClMul)     | 152B         |      92.55 ns |     0.256 ns |     0.227 ns |         - |
| Encrypt · AES-192-GCM (OS)                            | 152B         |     142.35 ns |     0.872 ns |     0.816 ns |         - |
| Encrypt · AES-192-GCM (BouncyCastle)                  | 152B         |     984.26 ns |    10.892 ns |    10.188 ns |    1712 B |
| Encrypt · AES-192-GCM (CryptoHives-Scalar)            | 152B         |   1,289.57 ns |     5.129 ns |     4.283 ns |         - |
|                                                       |              |               |              |              |           |
| Decrypt · AES-192-GCM (CryptoHives-AES-NI+PClMulV256) | 256B         |     115.08 ns |     0.426 ns |     0.377 ns |         - |
| Decrypt · AES-192-GCM (CryptoHives-AES-NI+PClMul)     | 256B         |     132.74 ns |     0.478 ns |     0.447 ns |         - |
| Decrypt · AES-192-GCM (OS)                            | 256B         |     133.08 ns |     1.409 ns |     1.249 ns |         - |
| Decrypt · AES-192-GCM (BouncyCastle)                  | 256B         |   1,397.82 ns |     8.875 ns |     7.411 ns |    1728 B |
| Decrypt · AES-192-GCM (CryptoHives-Scalar)            | 256B         |   2,032.89 ns |     4.461 ns |     3.725 ns |         - |
|                                                       |              |               |              |              |           |
| Encrypt · AES-192-GCM (CryptoHives-AES-NI+PClMulV256) | 256B         |      83.06 ns |     0.447 ns |     0.373 ns |         - |
| Encrypt · AES-192-GCM (CryptoHives-AES-NI+PClMul)     | 256B         |      87.45 ns |     0.375 ns |     0.351 ns |         - |
| Encrypt · AES-192-GCM (OS)                            | 256B         |     127.94 ns |     0.485 ns |     0.405 ns |         - |
| Encrypt · AES-192-GCM (BouncyCastle)                  | 256B         |   1,302.49 ns |     9.172 ns |     8.131 ns |    1712 B |
| Encrypt · AES-192-GCM (CryptoHives-Scalar)            | 256B         |   1,936.82 ns |     4.392 ns |     3.667 ns |         - |
|                                                       |              |               |              |              |           |
| Decrypt · AES-192-GCM (OS)                            | 1KB          |     191.11 ns |     0.263 ns |     0.219 ns |         - |
| Decrypt · AES-192-GCM (CryptoHives-AES-NI+PClMulV256) | 1KB          |     207.59 ns |     0.271 ns |     0.212 ns |         - |
| Decrypt · AES-192-GCM (CryptoHives-AES-NI+PClMul)     | 1KB          |     257.37 ns |     0.715 ns |     0.634 ns |         - |
| Decrypt · AES-192-GCM (BouncyCastle)                  | 1KB          |   4,194.62 ns |    15.795 ns |    13.189 ns |    1728 B |
| Decrypt · AES-192-GCM (CryptoHives-Scalar)            | 1KB          |   7,204.17 ns |    11.424 ns |    10.127 ns |         - |
|                                                       |              |               |              |              |           |
| Encrypt · AES-192-GCM (OS)                            | 1KB          |     177.72 ns |     0.480 ns |     0.401 ns |         - |
| Encrypt · AES-192-GCM (CryptoHives-AES-NI+PClMulV256) | 1KB          |     192.15 ns |     0.308 ns |     0.288 ns |         - |
| Encrypt · AES-192-GCM (CryptoHives-AES-NI+PClMul)     | 1KB          |     211.41 ns |     0.525 ns |     0.491 ns |         - |
| Encrypt · AES-192-GCM (BouncyCastle)                  | 1KB          |   4,114.06 ns |    19.401 ns |    16.201 ns |    1712 B |
| Encrypt · AES-192-GCM (CryptoHives-Scalar)            | 1KB          |   7,508.56 ns |    16.220 ns |    12.663 ns |         - |
|                                                       |              |               |              |              |           |
| Decrypt · AES-192-GCM (OS)                            | 8KB          |     798.28 ns |     1.656 ns |     1.468 ns |         - |
| Decrypt · AES-192-GCM (CryptoHives-AES-NI+PClMulV256) | 8KB          |   1,084.35 ns |     3.391 ns |     2.648 ns |         - |
| Decrypt · AES-192-GCM (CryptoHives-AES-NI+PClMul)     | 8KB          |   1,479.36 ns |     2.029 ns |     1.694 ns |         - |
| Decrypt · AES-192-GCM (BouncyCastle)                  | 8KB          |  30,104.89 ns |    69.905 ns |    61.969 ns |    1728 B |
| Decrypt · AES-192-GCM (CryptoHives-Scalar)            | 8KB          |  59,222.96 ns |    50.257 ns |    39.237 ns |         - |
|                                                       |              |               |              |              |           |
| Encrypt · AES-192-GCM (OS)                            | 8KB          |     708.60 ns |     2.545 ns |     2.125 ns |         - |
| Encrypt · AES-192-GCM (CryptoHives-AES-NI+PClMulV256) | 8KB          |   1,221.23 ns |     4.237 ns |     3.308 ns |         - |
| Encrypt · AES-192-GCM (CryptoHives-AES-NI+PClMul)     | 8KB          |   1,379.37 ns |     4.877 ns |     4.323 ns |         - |
| Encrypt · AES-192-GCM (BouncyCastle)                  | 8KB          |  30,212.33 ns |   120.875 ns |   107.152 ns |    1712 B |
| Encrypt · AES-192-GCM (CryptoHives-Scalar)            | 8KB          |  56,480.66 ns |   201.165 ns |   167.982 ns |         - |
|                                                       |              |               |              |              |           |
| Decrypt · AES-192-GCM (OS)                            | 128KB        |  11,838.85 ns |    34.191 ns |    30.309 ns |         - |
| Decrypt · AES-192-GCM (CryptoHives-AES-NI+PClMulV256) | 128KB        |  16,877.09 ns |   171.739 ns |   160.645 ns |         - |
| Decrypt · AES-192-GCM (CryptoHives-AES-NI+PClMul)     | 128KB        |  22,343.66 ns |    65.739 ns |    54.895 ns |         - |
| Decrypt · AES-192-GCM (BouncyCastle)                  | 128KB        | 477,312.47 ns | 1,253.906 ns | 1,047.068 ns |    1728 B |
| Decrypt · AES-192-GCM (CryptoHives-Scalar)            | 128KB        | 898,177.12 ns | 2,019.360 ns | 1,790.110 ns |         - |
|                                                       |              |               |              |              |           |
| Encrypt · AES-192-GCM (OS)                            | 128KB        |  10,504.37 ns |    64.655 ns |    50.478 ns |         - |
| Encrypt · AES-192-GCM (CryptoHives-AES-NI+PClMulV256) | 128KB        |  18,850.86 ns |    64.250 ns |    53.651 ns |         - |
| Encrypt · AES-192-GCM (CryptoHives-AES-NI+PClMul)     | 128KB        |  21,555.96 ns |    72.139 ns |    63.949 ns |         - |
| Encrypt · AES-192-GCM (BouncyCastle)                  | 128KB        | 478,765.34 ns | 2,431.299 ns | 2,274.238 ns |    1712 B |
| Encrypt · AES-192-GCM (CryptoHives-Scalar)            | 128KB        | 897,012.42 ns | 2,227.959 ns | 1,860.447 ns |         - |