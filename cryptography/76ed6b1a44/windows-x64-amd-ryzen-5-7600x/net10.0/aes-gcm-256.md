| Description                                           | TestDataSize | Mean          | Error        | StdDev       | Median        | Allocated |
|------------------------------------------------------ |------------- |--------------:|-------------:|-------------:|--------------:|----------:|
| Decrypt · AES-256-GCM (CryptoHives-AES-NI+PClMul)     | 17B          |     119.51 ns |     0.224 ns |     0.175 ns |     119.56 ns |         - |
| Decrypt · AES-256-GCM (OS)                            | 17B          |     122.81 ns |     0.716 ns |     0.670 ns |     122.96 ns |         - |
| Decrypt · AES-256-GCM (CryptoHives-AES-NI+PClMulV256) | 17B          |     123.42 ns |     0.348 ns |     0.272 ns |     123.50 ns |         - |
| Decrypt · AES-256-GCM (CryptoHives-Scalar)            | 17B          |     399.34 ns |     1.820 ns |     1.520 ns |     399.69 ns |         - |
| Decrypt · AES-256-GCM (BouncyCastle)                  | 17B          |     648.08 ns |     3.634 ns |     3.222 ns |     648.10 ns |    1832 B |
|                                                       |              |               |              |              |               |           |
| Encrypt · AES-256-GCM (CryptoHives-AES-NI+PClMul)     | 17B          |      73.05 ns |     1.406 ns |     1.246 ns |      72.76 ns |         - |
| Encrypt · AES-256-GCM (CryptoHives-AES-NI+PClMulV256) | 17B          |      74.65 ns |     1.063 ns |     0.994 ns |      74.61 ns |         - |
| Encrypt · AES-256-GCM (OS)                            | 17B          |     134.76 ns |     1.491 ns |     1.322 ns |     134.62 ns |         - |
| Encrypt · AES-256-GCM (CryptoHives-Scalar)            | 17B          |     376.62 ns |     4.891 ns |     4.336 ns |     377.74 ns |         - |
| Encrypt · AES-256-GCM (BouncyCastle)                  | 17B          |     671.07 ns |    13.065 ns |    16.988 ns |     666.14 ns |    1816 B |
|                                                       |              |               |              |              |               |           |
| Decrypt · AES-256-GCM (CryptoHives-AES-NI+PClMulV256) | 65B          |     105.05 ns |     0.436 ns |     0.387 ns |     104.93 ns |         - |
| Decrypt · AES-256-GCM (CryptoHives-AES-NI+PClMul)     | 65B          |     114.99 ns |     0.429 ns |     0.358 ns |     114.91 ns |         - |
| Decrypt · AES-256-GCM (OS)                            | 65B          |     125.96 ns |     0.214 ns |     0.167 ns |     125.99 ns |         - |
| Decrypt · AES-256-GCM (CryptoHives-Scalar)            | 65B          |     658.76 ns |     2.993 ns |     2.800 ns |     658.13 ns |         - |
| Decrypt · AES-256-GCM (BouncyCastle)                  | 65B          |     878.20 ns |     3.302 ns |     2.757 ns |     878.53 ns |    1832 B |
|                                                       |              |               |              |              |               |           |
| Encrypt · AES-256-GCM (CryptoHives-AES-NI+PClMul)     | 65B          |      82.01 ns |     1.595 ns |     1.492 ns |      82.58 ns |         - |
| Encrypt · AES-256-GCM (CryptoHives-AES-NI+PClMulV256) | 65B          |      82.35 ns |     1.231 ns |     1.151 ns |      82.50 ns |         - |
| Encrypt · AES-256-GCM (OS)                            | 65B          |     147.17 ns |     2.865 ns |     2.680 ns |     146.91 ns |         - |
| Encrypt · AES-256-GCM (CryptoHives-Scalar)            | 65B          |     688.80 ns |     7.599 ns |     6.345 ns |     690.10 ns |         - |
| Encrypt · AES-256-GCM (BouncyCastle)                  | 65B          |     894.76 ns |    16.789 ns |    17.241 ns |     892.04 ns |    1816 B |
|                                                       |              |               |              |              |               |           |
| Decrypt · AES-256-GCM (CryptoHives-AES-NI+PClMul)     | 128B         |     100.27 ns |     0.528 ns |     0.468 ns |     100.27 ns |         - |
| Decrypt · AES-256-GCM (CryptoHives-AES-NI+PClMulV256) | 128B         |     102.61 ns |     0.601 ns |     0.502 ns |     102.54 ns |         - |
| Decrypt · AES-256-GCM (OS)                            | 128B         |     124.28 ns |     0.762 ns |     0.712 ns |     124.27 ns |         - |
| Decrypt · AES-256-GCM (CryptoHives-Scalar)            | 128B         |     939.96 ns |     6.396 ns |     5.670 ns |     938.55 ns |         - |
| Decrypt · AES-256-GCM (BouncyCastle)                  | 128B         |   1,125.26 ns |     6.726 ns |     5.963 ns |   1,122.42 ns |    1832 B |
|                                                       |              |               |              |              |               |           |
| Encrypt · AES-256-GCM (CryptoHives-AES-NI+PClMulV256) | 128B         |      67.36 ns |     0.742 ns |     0.658 ns |      67.32 ns |         - |
| Encrypt · AES-256-GCM (CryptoHives-AES-NI+PClMul)     | 128B         |      70.95 ns |     1.353 ns |     1.329 ns |      70.89 ns |         - |
| Encrypt · AES-256-GCM (OS)                            | 128B         |     131.63 ns |     2.301 ns |     2.152 ns |     131.85 ns |         - |
| Encrypt · AES-256-GCM (CryptoHives-Scalar)            | 128B         |     995.86 ns |    19.752 ns |    18.476 ns |     993.39 ns |         - |
| Encrypt · AES-256-GCM (BouncyCastle)                  | 128B         |   1,142.21 ns |    22.291 ns |    32.674 ns |   1,142.15 ns |    1816 B |
|                                                       |              |               |              |              |               |           |
| Decrypt · AES-256-GCM (CryptoHives-AES-NI+PClMulV256) | 152B         |     131.70 ns |     0.626 ns |     0.555 ns |     131.52 ns |         - |
| Decrypt · AES-256-GCM (CryptoHives-AES-NI+PClMul)     | 152B         |     136.84 ns |     0.506 ns |     0.449 ns |     136.74 ns |         - |
| Decrypt · AES-256-GCM (OS)                            | 152B         |     142.64 ns |     0.754 ns |     0.630 ns |     142.37 ns |         - |
| Decrypt · AES-256-GCM (CryptoHives-Scalar)            | 152B         |   1,133.05 ns |     8.100 ns |     7.181 ns |   1,131.42 ns |         - |
| Decrypt · AES-256-GCM (BouncyCastle)                  | 152B         |   1,224.91 ns |     6.377 ns |     5.325 ns |   1,223.50 ns |    1832 B |
|                                                       |              |               |              |              |               |           |
| Encrypt · AES-256-GCM (CryptoHives-AES-NI+PClMulV256) | 152B         |      96.19 ns |     1.301 ns |     1.153 ns |      96.47 ns |         - |
| Encrypt · AES-256-GCM (CryptoHives-AES-NI+PClMul)     | 152B         |      99.66 ns |     1.684 ns |     1.575 ns |      99.42 ns |         - |
| Encrypt · AES-256-GCM (OS)                            | 152B         |     154.75 ns |     3.120 ns |     6.784 ns |     152.27 ns |         - |
| Encrypt · AES-256-GCM (CryptoHives-Scalar)            | 152B         |   1,182.02 ns |    23.463 ns |    23.044 ns |   1,178.16 ns |         - |
| Encrypt · AES-256-GCM (BouncyCastle)                  | 152B         |   1,245.16 ns |    24.561 ns |    31.062 ns |   1,244.54 ns |    1816 B |
|                                                       |              |               |              |              |               |           |
| Decrypt · AES-256-GCM (CryptoHives-AES-NI+PClMulV256) | 256B         |     112.94 ns |     0.580 ns |     0.514 ns |     112.85 ns |         - |
| Decrypt · AES-256-GCM (CryptoHives-AES-NI+PClMul)     | 256B         |     125.34 ns |     0.628 ns |     0.556 ns |     125.24 ns |         - |
| Decrypt · AES-256-GCM (OS)                            | 256B         |     135.24 ns |     0.482 ns |     0.427 ns |     135.12 ns |         - |
| Decrypt · AES-256-GCM (BouncyCastle)                  | 256B         |   1,595.44 ns |    10.341 ns |     9.673 ns |   1,592.48 ns |    1832 B |
| Decrypt · AES-256-GCM (CryptoHives-Scalar)            | 256B         |   1,683.39 ns |     4.173 ns |     3.700 ns |   1,683.44 ns |         - |
|                                                       |              |               |              |              |               |           |
| Encrypt · AES-256-GCM (CryptoHives-AES-NI+PClMulV256) | 256B         |      83.44 ns |     0.471 ns |     0.417 ns |      83.26 ns |         - |
| Encrypt · AES-256-GCM (CryptoHives-AES-NI+PClMul)     | 256B         |      89.18 ns |     1.804 ns |     2.078 ns |      87.94 ns |         - |
| Encrypt · AES-256-GCM (OS)                            | 256B         |     131.18 ns |     0.640 ns |     0.567 ns |     131.10 ns |         - |
| Encrypt · AES-256-GCM (BouncyCastle)                  | 256B         |   1,494.89 ns |     5.223 ns |     4.361 ns |   1,493.71 ns |    1816 B |
| Encrypt · AES-256-GCM (CryptoHives-Scalar)            | 256B         |   1,665.83 ns |     8.158 ns |     7.231 ns |   1,666.48 ns |         - |
|                                                       |              |               |              |              |               |           |
| Decrypt · AES-256-GCM (CryptoHives-AES-NI+PClMulV256) | 1KB          |     210.62 ns |     0.955 ns |     0.893 ns |     210.50 ns |         - |
| Decrypt · AES-256-GCM (OS)                            | 1KB          |     213.15 ns |     0.918 ns |     0.859 ns |     212.75 ns |         - |
| Decrypt · AES-256-GCM (CryptoHives-AES-NI+PClMul)     | 1KB          |     262.20 ns |     2.220 ns |     1.968 ns |     261.32 ns |         - |
| Decrypt · AES-256-GCM (BouncyCastle)                  | 1KB          |   4,739.77 ns |    29.435 ns |    26.093 ns |   4,729.53 ns |    1832 B |
| Decrypt · AES-256-GCM (CryptoHives-Scalar)            | 1KB          |   6,180.07 ns |    33.297 ns |    29.517 ns |   6,181.93 ns |         - |
|                                                       |              |               |              |              |               |           |
| Encrypt · AES-256-GCM (OS)                            | 1KB          |     182.44 ns |     0.753 ns |     0.629 ns |     182.43 ns |         - |
| Encrypt · AES-256-GCM (CryptoHives-AES-NI+PClMulV256) | 1KB          |     201.65 ns |     0.554 ns |     0.519 ns |     201.45 ns |         - |
| Encrypt · AES-256-GCM (CryptoHives-AES-NI+PClMul)     | 1KB          |     221.88 ns |     1.099 ns |     0.918 ns |     221.63 ns |         - |
| Encrypt · AES-256-GCM (BouncyCastle)                  | 1KB          |   4,600.68 ns |    21.483 ns |    17.940 ns |   4,601.12 ns |    1816 B |
| Encrypt · AES-256-GCM (CryptoHives-Scalar)            | 1KB          |   6,179.35 ns |    34.963 ns |    30.994 ns |   6,180.43 ns |         - |
|                                                       |              |               |              |              |               |           |
| Decrypt · AES-256-GCM (OS)                            | 8KB          |     924.39 ns |     3.027 ns |     2.831 ns |     924.64 ns |         - |
| Decrypt · AES-256-GCM (CryptoHives-AES-NI+PClMulV256) | 8KB          |   1,120.00 ns |     5.492 ns |     4.868 ns |   1,118.15 ns |         - |
| Decrypt · AES-256-GCM (CryptoHives-AES-NI+PClMul)     | 8KB          |   1,535.68 ns |     5.197 ns |     4.340 ns |   1,534.88 ns |         - |
| Decrypt · AES-256-GCM (BouncyCastle)                  | 8KB          |  33,519.39 ns |   174.608 ns |   145.806 ns |  33,507.47 ns |    1832 B |
| Decrypt · AES-256-GCM (CryptoHives-Scalar)            | 8KB          |  48,118.70 ns |   199.467 ns |   186.582 ns |  48,086.23 ns |         - |
|                                                       |              |               |              |              |               |           |
| Encrypt · AES-256-GCM (OS)                            | 8KB          |     707.69 ns |     3.287 ns |     2.744 ns |     706.98 ns |         - |
| Encrypt · AES-256-GCM (CryptoHives-AES-NI+PClMulV256) | 8KB          |   1,308.38 ns |     8.097 ns |     7.178 ns |   1,304.73 ns |         - |
| Encrypt · AES-256-GCM (CryptoHives-AES-NI+PClMul)     | 8KB          |   1,480.58 ns |     4.287 ns |     4.010 ns |   1,479.76 ns |         - |
| Encrypt · AES-256-GCM (BouncyCastle)                  | 8KB          |  33,433.35 ns |   184.879 ns |   172.936 ns |  33,434.55 ns |    1816 B |
| Encrypt · AES-256-GCM (CryptoHives-Scalar)            | 8KB          |  48,511.14 ns |   316.603 ns |   296.150 ns |  48,379.07 ns |         - |
|                                                       |              |               |              |              |               |           |
| Decrypt · AES-256-GCM (OS)                            | 128KB        |  14,293.85 ns |    46.789 ns |    41.478 ns |  14,283.89 ns |         - |
| Decrypt · AES-256-GCM (CryptoHives-AES-NI+PClMulV256) | 128KB        |  18,394.46 ns |   321.096 ns |   300.354 ns |  18,274.94 ns |         - |
| Decrypt · AES-256-GCM (CryptoHives-AES-NI+PClMul)     | 128KB        |  23,343.89 ns |    61.481 ns |    51.339 ns |  23,341.68 ns |         - |
| Decrypt · AES-256-GCM (BouncyCastle)                  | 128KB        | 532,577.98 ns | 2,702.047 ns | 2,527.497 ns | 532,125.98 ns |    1832 B |
| Decrypt · AES-256-GCM (CryptoHives-Scalar)            | 128KB        | 766,620.70 ns | 4,201.580 ns | 3,508.510 ns | 765,550.59 ns |         - |
|                                                       |              |               |              |              |               |           |
| Encrypt · AES-256-GCM (OS)                            | 128KB        |  10,633.04 ns |    72.316 ns |    64.106 ns |  10,632.63 ns |         - |
| Encrypt · AES-256-GCM (CryptoHives-AES-NI+PClMulV256) | 128KB        |  20,228.13 ns |    41.758 ns |    37.017 ns |  20,231.02 ns |         - |
| Encrypt · AES-256-GCM (CryptoHives-AES-NI+PClMul)     | 128KB        |  22,975.18 ns |    58.283 ns |    51.667 ns |  22,965.65 ns |         - |
| Encrypt · AES-256-GCM (BouncyCastle)                  | 128KB        | 529,994.82 ns | 2,467.205 ns | 1,926.231 ns | 529,640.97 ns |    1816 B |
| Encrypt · AES-256-GCM (CryptoHives-Scalar)            | 128KB        | 766,479.08 ns | 4,636.697 ns | 4,337.169 ns | 765,515.38 ns |         - |