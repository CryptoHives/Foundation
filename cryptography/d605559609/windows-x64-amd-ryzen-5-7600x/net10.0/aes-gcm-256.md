| Description                                           | TestDataSize | Mean          | Error        | StdDev       | Allocated |
|------------------------------------------------------ |------------- |--------------:|-------------:|-------------:|----------:|
| Decrypt · AES-256-GCM (CryptoHives-AES-NI+PClMulV256) | 17B          |     120.95 ns |     0.428 ns |     0.380 ns |         - |
| Decrypt · AES-256-GCM (CryptoHives-AES-NI+PClMul)     | 17B          |     121.22 ns |     0.497 ns |     0.465 ns |         - |
| Decrypt · AES-256-GCM (OS)                            | 17B          |     127.40 ns |     0.702 ns |     0.622 ns |         - |
| Decrypt · AES-256-GCM (CryptoHives-Scalar)            | 17B          |     372.74 ns |     2.158 ns |     1.685 ns |         - |
| Decrypt · AES-256-GCM (BouncyCastle)                  | 17B          |     582.57 ns |     2.521 ns |     2.105 ns |    1832 B |
|                                                       |              |               |              |              |           |
| Encrypt · AES-256-GCM (CryptoHives-AES-NI+PClMulV256) | 17B          |      77.74 ns |     1.034 ns |     0.968 ns |         - |
| Encrypt · AES-256-GCM (CryptoHives-AES-NI+PClMul)     | 17B          |      78.38 ns |     0.454 ns |     0.354 ns |         - |
| Encrypt · AES-256-GCM (OS)                            | 17B          |     133.16 ns |     0.830 ns |     0.693 ns |         - |
| Encrypt · AES-256-GCM (CryptoHives-Scalar)            | 17B          |     346.44 ns |     6.415 ns |     5.009 ns |         - |
| Encrypt · AES-256-GCM (BouncyCastle)                  | 17B          |     532.21 ns |     9.216 ns |     8.621 ns |    1816 B |
|                                                       |              |               |              |              |           |
| Decrypt · AES-256-GCM (CryptoHives-AES-NI+PClMulV256) | 65B          |     112.91 ns |     0.546 ns |     0.484 ns |         - |
| Decrypt · AES-256-GCM (CryptoHives-AES-NI+PClMul)     | 65B          |     121.06 ns |     0.499 ns |     0.467 ns |         - |
| Decrypt · AES-256-GCM (OS)                            | 65B          |     129.08 ns |     0.862 ns |     0.764 ns |         - |
| Decrypt · AES-256-GCM (CryptoHives-Scalar)            | 65B          |     673.77 ns |     3.117 ns |     2.763 ns |         - |
| Decrypt · AES-256-GCM (BouncyCastle)                  | 65B          |     816.55 ns |     6.014 ns |     5.022 ns |    1832 B |
|                                                       |              |               |              |              |           |
| Encrypt · AES-256-GCM (CryptoHives-AES-NI+PClMulV256) | 65B          |      83.01 ns |     0.766 ns |     0.679 ns |         - |
| Encrypt · AES-256-GCM (CryptoHives-AES-NI+PClMul)     | 65B          |      84.03 ns |     1.115 ns |     0.931 ns |         - |
| Encrypt · AES-256-GCM (OS)                            | 65B          |     137.20 ns |     2.079 ns |     1.945 ns |         - |
| Encrypt · AES-256-GCM (CryptoHives-Scalar)            | 65B          |     620.91 ns |     3.098 ns |     2.587 ns |         - |
| Encrypt · AES-256-GCM (BouncyCastle)                  | 65B          |     737.32 ns |    11.310 ns |    12.571 ns |    1816 B |
|                                                       |              |               |              |              |           |
| Decrypt · AES-256-GCM (CryptoHives-AES-NI+PClMulV256) | 128B         |     102.16 ns |     0.511 ns |     0.453 ns |         - |
| Decrypt · AES-256-GCM (CryptoHives-AES-NI+PClMul)     | 128B         |     106.54 ns |     0.366 ns |     0.325 ns |         - |
| Decrypt · AES-256-GCM (OS)                            | 128B         |     124.70 ns |     0.332 ns |     0.259 ns |         - |
| Decrypt · AES-256-GCM (CryptoHives-Scalar)            | 128B         |     966.54 ns |     3.831 ns |     2.991 ns |         - |
| Decrypt · AES-256-GCM (BouncyCastle)                  | 128B         |   1,013.39 ns |    10.288 ns |     9.120 ns |    1832 B |
|                                                       |              |               |              |              |           |
| Encrypt · AES-256-GCM (CryptoHives-AES-NI+PClMulV256) | 128B         |      68.59 ns |     1.374 ns |     1.285 ns |         - |
| Encrypt · AES-256-GCM (CryptoHives-AES-NI+PClMul)     | 128B         |      69.20 ns |     0.536 ns |     0.447 ns |         - |
| Encrypt · AES-256-GCM (OS)                            | 128B         |     129.35 ns |     2.531 ns |     3.108 ns |         - |
| Encrypt · AES-256-GCM (CryptoHives-Scalar)            | 128B         |     937.92 ns |     9.594 ns |     8.974 ns |         - |
| Encrypt · AES-256-GCM (BouncyCastle)                  | 128B         |     953.09 ns |    14.108 ns |    12.507 ns |    1816 B |
|                                                       |              |               |              |              |           |
| Decrypt · AES-256-GCM (OS)                            | 152B         |     144.28 ns |     1.322 ns |     1.104 ns |         - |
| Decrypt · AES-256-GCM (CryptoHives-AES-NI+PClMulV256) | 152B         |     145.53 ns |     1.411 ns |     1.178 ns |         - |
| Decrypt · AES-256-GCM (CryptoHives-AES-NI+PClMul)     | 152B         |     206.79 ns |     1.133 ns |     0.884 ns |         - |
| Decrypt · AES-256-GCM (CryptoHives-Scalar)            | 152B         |   1,111.92 ns |     7.119 ns |     6.659 ns |         - |
| Decrypt · AES-256-GCM (BouncyCastle)                  | 152B         |   1,166.39 ns |     9.258 ns |     7.731 ns |    1832 B |
|                                                       |              |               |              |              |           |
| Encrypt · AES-256-GCM (CryptoHives-AES-NI+PClMulV256) | 152B         |      99.33 ns |     1.381 ns |     1.224 ns |         - |
| Encrypt · AES-256-GCM (CryptoHives-AES-NI+PClMul)     | 152B         |     102.86 ns |     1.138 ns |     1.065 ns |         - |
| Encrypt · AES-256-GCM (OS)                            | 152B         |     147.48 ns |     1.290 ns |     1.007 ns |         - |
| Encrypt · AES-256-GCM (BouncyCastle)                  | 152B         |   1,074.16 ns |    15.627 ns |    14.618 ns |    1816 B |
| Encrypt · AES-256-GCM (CryptoHives-Scalar)            | 152B         |   1,124.89 ns |    10.565 ns |     9.882 ns |         - |
|                                                       |              |               |              |              |           |
| Decrypt · AES-256-GCM (CryptoHives-AES-NI+PClMulV256) | 256B         |     121.32 ns |     2.157 ns |     1.801 ns |         - |
| Decrypt · AES-256-GCM (CryptoHives-AES-NI+PClMul)     | 256B         |     134.46 ns |     1.898 ns |     1.682 ns |         - |
| Decrypt · AES-256-GCM (OS)                            | 256B         |     138.26 ns |     0.598 ns |     0.530 ns |         - |
| Decrypt · AES-256-GCM (BouncyCastle)                  | 256B         |   1,548.33 ns |    10.128 ns |     9.474 ns |    1832 B |
| Decrypt · AES-256-GCM (CryptoHives-Scalar)            | 256B         |   1,653.35 ns |     7.621 ns |     6.364 ns |         - |
|                                                       |              |               |              |              |           |
| Encrypt · AES-256-GCM (CryptoHives-AES-NI+PClMulV256) | 256B         |      86.75 ns |     0.373 ns |     0.331 ns |         - |
| Encrypt · AES-256-GCM (CryptoHives-AES-NI+PClMul)     | 256B         |      92.54 ns |     0.824 ns |     0.644 ns |         - |
| Encrypt · AES-256-GCM (OS)                            | 256B         |     132.81 ns |     1.245 ns |     1.103 ns |         - |
| Encrypt · AES-256-GCM (BouncyCastle)                  | 256B         |   1,438.32 ns |     9.579 ns |     7.999 ns |    1816 B |
| Encrypt · AES-256-GCM (CryptoHives-Scalar)            | 256B         |   1,656.75 ns |     6.934 ns |     6.147 ns |         - |
|                                                       |              |               |              |              |           |
| Decrypt · AES-256-GCM (OS)                            | 1KB          |     213.83 ns |     0.741 ns |     0.657 ns |         - |
| Decrypt · AES-256-GCM (CryptoHives-AES-NI+PClMulV256) | 1KB          |     218.31 ns |     1.182 ns |     0.987 ns |         - |
| Decrypt · AES-256-GCM (CryptoHives-AES-NI+PClMul)     | 1KB          |     275.21 ns |     3.227 ns |     3.018 ns |         - |
| Decrypt · AES-256-GCM (BouncyCastle)                  | 1KB          |   4,747.61 ns |    35.957 ns |    33.634 ns |    1832 B |
| Decrypt · AES-256-GCM (CryptoHives-Scalar)            | 1KB          |   6,013.41 ns |    26.789 ns |    22.370 ns |         - |
|                                                       |              |               |              |              |           |
| Encrypt · AES-256-GCM (OS)                            | 1KB          |     186.28 ns |     3.590 ns |     2.998 ns |         - |
| Encrypt · AES-256-GCM (CryptoHives-AES-NI+PClMulV256) | 1KB          |     206.08 ns |     0.989 ns |     0.772 ns |         - |
| Encrypt · AES-256-GCM (CryptoHives-AES-NI+PClMul)     | 1KB          |     230.52 ns |     1.101 ns |     0.860 ns |         - |
| Encrypt · AES-256-GCM (BouncyCastle)                  | 1KB          |   4,654.80 ns |    67.382 ns |    63.029 ns |    1816 B |
| Encrypt · AES-256-GCM (CryptoHives-Scalar)            | 1KB          |   6,025.57 ns |    36.621 ns |    30.580 ns |         - |
|                                                       |              |               |              |              |           |
| Decrypt · AES-256-GCM (OS)                            | 8KB          |     957.96 ns |     6.590 ns |     6.165 ns |         - |
| Decrypt · AES-256-GCM (CryptoHives-AES-NI+PClMulV256) | 8KB          |   1,136.81 ns |     6.341 ns |     5.295 ns |         - |
| Decrypt · AES-256-GCM (CryptoHives-AES-NI+PClMul)     | 8KB          |   1,553.69 ns |     7.669 ns |     7.174 ns |         - |
| Decrypt · AES-256-GCM (BouncyCastle)                  | 8KB          |  34,122.42 ns |   133.333 ns |   118.196 ns |    1832 B |
| Decrypt · AES-256-GCM (CryptoHives-Scalar)            | 8KB          |  46,974.65 ns |   372.987 ns |   311.461 ns |         - |
|                                                       |              |               |              |              |           |
| Encrypt · AES-256-GCM (OS)                            | 8KB          |     734.87 ns |     3.468 ns |     2.896 ns |         - |
| Encrypt · AES-256-GCM (CryptoHives-AES-NI+PClMulV256) | 8KB          |   1,316.59 ns |     4.979 ns |     3.887 ns |         - |
| Encrypt · AES-256-GCM (CryptoHives-AES-NI+PClMul)     | 8KB          |   1,494.33 ns |    10.759 ns |     8.985 ns |         - |
| Encrypt · AES-256-GCM (BouncyCastle)                  | 8KB          |  34,671.60 ns |   237.648 ns |   222.296 ns |    1816 B |
| Encrypt · AES-256-GCM (CryptoHives-Scalar)            | 8KB          |  49,088.98 ns |   856.718 ns |   668.869 ns |         - |
|                                                       |              |               |              |              |           |
| Decrypt · AES-256-GCM (OS)                            | 128KB        |  14,766.70 ns |    53.397 ns |    47.335 ns |         - |
| Decrypt · AES-256-GCM (CryptoHives-AES-NI+PClMulV256) | 128KB        |  17,784.93 ns |   148.915 ns |   139.295 ns |         - |
| Decrypt · AES-256-GCM (CryptoHives-AES-NI+PClMul)     | 128KB        |  23,772.22 ns |   268.070 ns |   209.291 ns |         - |
| Decrypt · AES-256-GCM (BouncyCastle)                  | 128KB        | 543,443.50 ns | 6,771.622 ns | 5,286.837 ns |    1832 B |
| Decrypt · AES-256-GCM (CryptoHives-Scalar)            | 128KB        | 779,941.88 ns | 2,894.763 ns | 2,566.132 ns |         - |
|                                                       |              |               |              |              |           |
| Encrypt · AES-256-GCM (OS)                            | 128KB        |  10,917.60 ns |    59.851 ns |    49.978 ns |         - |
| Encrypt · AES-256-GCM (CryptoHives-AES-NI+PClMulV256) | 128KB        |  20,477.69 ns |   156.941 ns |   131.053 ns |         - |
| Encrypt · AES-256-GCM (CryptoHives-AES-NI+PClMul)     | 128KB        |  23,383.06 ns |   398.364 ns |   311.017 ns |         - |
| Encrypt · AES-256-GCM (BouncyCastle)                  | 128KB        | 541,082.80 ns | 3,307.801 ns | 3,094.119 ns |    1816 B |
| Encrypt · AES-256-GCM (CryptoHives-Scalar)            | 128KB        | 748,986.70 ns | 2,445.159 ns | 2,167.570 ns |         - |