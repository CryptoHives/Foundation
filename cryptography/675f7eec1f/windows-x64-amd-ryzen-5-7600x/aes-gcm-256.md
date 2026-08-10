| Description                                           | TestDataSize | Mean          | Error        | StdDev       | Allocated |
|------------------------------------------------------ |------------- |--------------:|-------------:|-------------:|----------:|
| Decrypt · AES-256-GCM (CryptoHives-AES-NI+PClMulV256) | 17B          |     120.56 ns |     0.487 ns |     0.455 ns |         - |
| Decrypt · AES-256-GCM (CryptoHives-AES-NI+PClMul)     | 17B          |     125.39 ns |     0.553 ns |     0.490 ns |         - |
| Decrypt · AES-256-GCM (OS)                            | 17B          |     126.22 ns |     0.975 ns |     0.912 ns |         - |
| Decrypt · AES-256-GCM (CryptoHives-Scalar)            | 17B          |     388.66 ns |     2.846 ns |     2.662 ns |         - |
| Decrypt · AES-256-GCM (BouncyCastle)                  | 17B          |     676.22 ns |     8.011 ns |     7.494 ns |    1832 B |
|                                                       |              |               |              |              |           |
| Encrypt · AES-256-GCM (CryptoHives-AES-NI+PClMul)     | 17B          |      72.96 ns |     0.294 ns |     0.275 ns |         - |
| Encrypt · AES-256-GCM (CryptoHives-AES-NI+PClMulV256) | 17B          |      73.59 ns |     0.305 ns |     0.270 ns |         - |
| Encrypt · AES-256-GCM (OS)                            | 17B          |     141.60 ns |     1.278 ns |     1.196 ns |         - |
| Encrypt · AES-256-GCM (CryptoHives-Scalar)            | 17B          |     357.44 ns |     2.634 ns |     2.464 ns |         - |
| Encrypt · AES-256-GCM (BouncyCastle)                  | 17B          |     614.45 ns |     8.213 ns |     7.682 ns |    1816 B |
|                                                       |              |               |              |              |           |
| Decrypt · AES-256-GCM (CryptoHives-AES-NI+PClMul)     | 65B          |     118.44 ns |     0.327 ns |     0.306 ns |         - |
| Decrypt · AES-256-GCM (CryptoHives-AES-NI+PClMulV256) | 65B          |     121.29 ns |     0.648 ns |     0.574 ns |         - |
| Decrypt · AES-256-GCM (OS)                            | 65B          |     127.57 ns |     1.160 ns |     1.028 ns |         - |
| Decrypt · AES-256-GCM (CryptoHives-Scalar)            | 65B          |     677.38 ns |     4.298 ns |     4.020 ns |         - |
| Decrypt · AES-256-GCM (BouncyCastle)                  | 65B          |     902.54 ns |     9.076 ns |     8.490 ns |    1832 B |
|                                                       |              |               |              |              |           |
| Encrypt · AES-256-GCM (CryptoHives-AES-NI+PClMul)     | 65B          |      80.56 ns |     0.354 ns |     0.314 ns |         - |
| Encrypt · AES-256-GCM (CryptoHives-AES-NI+PClMulV256) | 65B          |      81.27 ns |     0.513 ns |     0.455 ns |         - |
| Encrypt · AES-256-GCM (OS)                            | 65B          |     138.04 ns |     1.089 ns |     0.909 ns |         - |
| Encrypt · AES-256-GCM (CryptoHives-Scalar)            | 65B          |     649.45 ns |     4.596 ns |     4.299 ns |         - |
| Encrypt · AES-256-GCM (BouncyCastle)                  | 65B          |     822.13 ns |     7.202 ns |     6.014 ns |    1816 B |
|                                                       |              |               |              |              |           |
| Decrypt · AES-256-GCM (CryptoHives-AES-NI+PClMulV256) | 128B         |     109.35 ns |     0.664 ns |     0.589 ns |         - |
| Decrypt · AES-256-GCM (CryptoHives-AES-NI+PClMul)     | 128B         |     110.45 ns |     0.801 ns |     0.749 ns |         - |
| Decrypt · AES-256-GCM (OS)                            | 128B         |     125.72 ns |     0.893 ns |     0.746 ns |         - |
| Decrypt · AES-256-GCM (CryptoHives-Scalar)            | 128B         |     968.72 ns |     9.125 ns |     8.089 ns |         - |
| Decrypt · AES-256-GCM (BouncyCastle)                  | 128B         |   1,107.30 ns |    10.799 ns |     9.573 ns |    1832 B |
|                                                       |              |               |              |              |           |
| Encrypt · AES-256-GCM (CryptoHives-AES-NI+PClMulV256) | 128B         |      66.95 ns |     0.475 ns |     0.444 ns |         - |
| Encrypt · AES-256-GCM (CryptoHives-AES-NI+PClMul)     | 128B         |      70.08 ns |     0.348 ns |     0.291 ns |         - |
| Encrypt · AES-256-GCM (OS)                            | 128B         |     126.97 ns |     1.224 ns |     1.144 ns |         - |
| Encrypt · AES-256-GCM (CryptoHives-Scalar)            | 128B         |     935.51 ns |     9.050 ns |    10.774 ns |         - |
| Encrypt · AES-256-GCM (BouncyCastle)                  | 128B         |   1,004.67 ns |     6.113 ns |     5.104 ns |    1816 B |
|                                                       |              |               |              |              |           |
| Decrypt · AES-256-GCM (CryptoHives-AES-NI+PClMul)     | 152B         |     134.92 ns |     0.781 ns |     0.731 ns |         - |
| Decrypt · AES-256-GCM (CryptoHives-AES-NI+PClMulV256) | 152B         |     139.67 ns |     0.877 ns |     0.820 ns |         - |
| Decrypt · AES-256-GCM (OS)                            | 152B         |     143.88 ns |     1.112 ns |     0.929 ns |         - |
| Decrypt · AES-256-GCM (CryptoHives-Scalar)            | 152B         |   1,155.91 ns |     7.641 ns |     6.774 ns |         - |
| Decrypt · AES-256-GCM (BouncyCastle)                  | 152B         |   1,259.54 ns |     7.038 ns |     6.239 ns |    1832 B |
|                                                       |              |               |              |              |           |
| Encrypt · AES-256-GCM (CryptoHives-AES-NI+PClMulV256) | 152B         |      95.68 ns |     0.301 ns |     0.251 ns |         - |
| Encrypt · AES-256-GCM (CryptoHives-AES-NI+PClMul)     | 152B         |      98.68 ns |     0.351 ns |     0.293 ns |         - |
| Encrypt · AES-256-GCM (OS)                            | 152B         |     144.38 ns |     1.549 ns |     1.294 ns |         - |
| Encrypt · AES-256-GCM (BouncyCastle)                  | 152B         |   1,161.06 ns |    18.399 ns |    16.310 ns |    1816 B |
| Encrypt · AES-256-GCM (CryptoHives-Scalar)            | 152B         |   1,244.86 ns |     9.527 ns |     8.911 ns |         - |
|                                                       |              |               |              |              |           |
| Decrypt · AES-256-GCM (CryptoHives-AES-NI+PClMulV256) | 256B         |     121.17 ns |     1.021 ns |     0.955 ns |         - |
| Decrypt · AES-256-GCM (CryptoHives-AES-NI+PClMul)     | 256B         |     132.45 ns |     1.677 ns |     1.569 ns |         - |
| Decrypt · AES-256-GCM (OS)                            | 256B         |     144.97 ns |     1.380 ns |     1.291 ns |         - |
| Decrypt · AES-256-GCM (BouncyCastle)                  | 256B         |   1,653.46 ns |    16.227 ns |    14.385 ns |    1832 B |
| Decrypt · AES-256-GCM (CryptoHives-Scalar)            | 256B         |   1,733.27 ns |    11.454 ns |    10.714 ns |         - |
|                                                       |              |               |              |              |           |
| Encrypt · AES-256-GCM (CryptoHives-AES-NI+PClMulV256) | 256B         |      87.29 ns |     0.463 ns |     0.410 ns |         - |
| Encrypt · AES-256-GCM (CryptoHives-AES-NI+PClMul)     | 256B         |      91.24 ns |     0.369 ns |     0.327 ns |         - |
| Encrypt · AES-256-GCM (OS)                            | 256B         |     134.94 ns |     1.539 ns |     1.440 ns |         - |
| Encrypt · AES-256-GCM (BouncyCastle)                  | 256B         |   1,533.06 ns |     7.728 ns |     6.454 ns |    1816 B |
| Encrypt · AES-256-GCM (CryptoHives-Scalar)            | 256B         |   1,701.03 ns |    12.572 ns |    11.145 ns |         - |
|                                                       |              |               |              |              |           |
| Decrypt · AES-256-GCM (OS)                            | 1KB          |     212.81 ns |     1.659 ns |     1.471 ns |         - |
| Decrypt · AES-256-GCM (CryptoHives-AES-NI+PClMulV256) | 1KB          |     220.68 ns |     1.104 ns |     0.979 ns |         - |
| Decrypt · AES-256-GCM (CryptoHives-AES-NI+PClMul)     | 1KB          |     273.66 ns |     2.511 ns |     2.349 ns |         - |
| Decrypt · AES-256-GCM (BouncyCastle)                  | 1KB          |   4,816.16 ns |    37.222 ns |    32.996 ns |    1832 B |
| Decrypt · AES-256-GCM (CryptoHives-Scalar)            | 1KB          |   6,334.56 ns |    52.909 ns |    49.491 ns |         - |
|                                                       |              |               |              |              |           |
| Encrypt · AES-256-GCM (OS)                            | 1KB          |     183.68 ns |     1.269 ns |     1.187 ns |         - |
| Encrypt · AES-256-GCM (CryptoHives-AES-NI+PClMulV256) | 1KB          |     206.80 ns |     0.824 ns |     0.688 ns |         - |
| Encrypt · AES-256-GCM (CryptoHives-AES-NI+PClMul)     | 1KB          |     228.62 ns |     1.075 ns |     1.006 ns |         - |
| Encrypt · AES-256-GCM (BouncyCastle)                  | 1KB          |   4,719.80 ns |    48.178 ns |    42.709 ns |    1816 B |
| Encrypt · AES-256-GCM (CryptoHives-Scalar)            | 1KB          |   6,293.24 ns |    52.984 ns |    41.366 ns |         - |
|                                                       |              |               |              |              |           |
| Decrypt · AES-256-GCM (OS)                            | 8KB          |     960.73 ns |     5.033 ns |     4.708 ns |         - |
| Decrypt · AES-256-GCM (CryptoHives-AES-NI+PClMulV256) | 8KB          |   1,142.69 ns |     5.817 ns |     5.157 ns |         - |
| Decrypt · AES-256-GCM (CryptoHives-AES-NI+PClMul)     | 8KB          |   1,556.88 ns |    11.820 ns |     9.870 ns |         - |
| Decrypt · AES-256-GCM (BouncyCastle)                  | 8KB          |  34,266.24 ns |   242.284 ns |   226.632 ns |    1832 B |
| Decrypt · AES-256-GCM (CryptoHives-Scalar)            | 8KB          |  49,214.68 ns |   607.361 ns |   507.174 ns |         - |
|                                                       |              |               |              |              |           |
| Encrypt · AES-256-GCM (OS)                            | 8KB          |     734.18 ns |     5.918 ns |     5.246 ns |         - |
| Encrypt · AES-256-GCM (CryptoHives-AES-NI+PClMulV256) | 8KB          |   1,324.72 ns |     7.525 ns |     7.039 ns |         - |
| Encrypt · AES-256-GCM (CryptoHives-AES-NI+PClMul)     | 8KB          |   1,488.93 ns |     9.791 ns |     8.679 ns |         - |
| Encrypt · AES-256-GCM (BouncyCastle)                  | 8KB          |  34,087.36 ns |   185.732 ns |   155.095 ns |    1816 B |
| Encrypt · AES-256-GCM (CryptoHives-Scalar)            | 8KB          |  49,133.87 ns |   450.526 ns |   399.380 ns |         - |
|                                                       |              |               |              |              |           |
| Decrypt · AES-256-GCM (OS)                            | 128KB        |  14,556.54 ns |    52.291 ns |    43.665 ns |         - |
| Decrypt · AES-256-GCM (CryptoHives-AES-NI+PClMulV256) | 128KB        |  17,750.11 ns |   152.610 ns |   142.752 ns |         - |
| Decrypt · AES-256-GCM (CryptoHives-AES-NI+PClMul)     | 128KB        |  23,934.60 ns |   165.315 ns |   154.636 ns |         - |
| Decrypt · AES-256-GCM (BouncyCastle)                  | 128KB        | 543,299.08 ns | 4,202.856 ns | 3,725.723 ns |    1832 B |
| Decrypt · AES-256-GCM (CryptoHives-Scalar)            | 128KB        | 784,841.43 ns | 4,049.414 ns | 3,381.444 ns |         - |
|                                                       |              |               |              |              |           |
| Encrypt · AES-256-GCM (OS)                            | 128KB        |  10,858.84 ns |    43.683 ns |    38.724 ns |         - |
| Encrypt · AES-256-GCM (CryptoHives-AES-NI+PClMulV256) | 128KB        |  20,538.05 ns |   182.106 ns |   152.067 ns |         - |
| Encrypt · AES-256-GCM (CryptoHives-AES-NI+PClMul)     | 128KB        |  23,274.06 ns |   131.221 ns |   116.324 ns |         - |
| Encrypt · AES-256-GCM (BouncyCastle)                  | 128KB        | 542,453.87 ns | 5,245.757 ns | 4,906.884 ns |    1816 B |
| Encrypt · AES-256-GCM (CryptoHives-Scalar)            | 128KB        | 870,871.21 ns | 4,768.916 ns | 3,982.260 ns |         - |