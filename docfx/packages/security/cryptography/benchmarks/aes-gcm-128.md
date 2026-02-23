| Description                               | TestDataSize | Mean          | Error        | StdDev       | Allocated |
|------------------------------------------ |------------- |--------------:|-------------:|-------------:|----------:|
| Decrypt · AES-128-GCM (AES-NI+PClMulV256) | 17B          |     103.86 ns |     0.794 ns |     0.743 ns |         - |
| Decrypt · AES-128-GCM (AES-NI+PClMul)     | 17B          |     104.53 ns |     0.711 ns |     0.665 ns |         - |
| Decrypt · AES-128-GCM (OS)                | 17B          |     119.96 ns |     0.600 ns |     0.562 ns |         - |
| Decrypt · AES-128-GCM (Managed)           | 17B          |     356.46 ns |     2.751 ns |     2.439 ns |         - |
| Decrypt · AES-128-GCM (BouncyCastle)      | 17B          |     599.21 ns |    10.517 ns |     9.838 ns |    1624 B |
|                                           |              |               |              |              |           |
| Encrypt · AES-128-GCM (AES-NI+PClMulV256) | 17B          |      69.39 ns |     0.206 ns |     0.161 ns |         - |
| Encrypt · AES-128-GCM (AES-NI+PClMul)     | 17B          |      69.88 ns |     1.311 ns |     1.226 ns |         - |
| Encrypt · AES-128-GCM (OS)                | 17B          |     124.29 ns |     0.632 ns |     0.560 ns |         - |
| Encrypt · AES-128-GCM (Managed)           | 17B          |     317.01 ns |     3.411 ns |     3.191 ns |         - |
| Encrypt · AES-128-GCM (BouncyCastle)      | 17B          |     505.81 ns |     6.553 ns |     6.129 ns |    1608 B |
|                                           |              |               |              |              |           |
| Decrypt · AES-128-GCM (AES-NI+PClMulV256) | 65B          |     102.99 ns |     0.969 ns |     0.906 ns |         - |
| Decrypt · AES-128-GCM (AES-NI+PClMul)     | 65B          |     106.15 ns |     0.492 ns |     0.436 ns |         - |
| Decrypt · AES-128-GCM (OS)                | 65B          |     125.41 ns |     1.645 ns |     1.539 ns |         - |
| Decrypt · AES-128-GCM (Managed)           | 65B          |     609.40 ns |     8.939 ns |     7.924 ns |         - |
| Decrypt · AES-128-GCM (BouncyCastle)      | 65B          |     772.92 ns |     6.566 ns |     6.142 ns |    1624 B |
|                                           |              |               |              |              |           |
| Encrypt · AES-128-GCM (AES-NI+PClMul)     | 65B          |      75.64 ns |     0.610 ns |     0.541 ns |         - |
| Encrypt · AES-128-GCM (AES-NI+PClMulV256) | 65B          |      76.00 ns |     0.622 ns |     0.581 ns |         - |
| Encrypt · AES-128-GCM (OS)                | 65B          |     125.58 ns |     2.180 ns |     2.039 ns |         - |
| Encrypt · AES-128-GCM (Managed)           | 65B          |     558.08 ns |     6.318 ns |     5.910 ns |         - |
| Encrypt · AES-128-GCM (BouncyCastle)      | 65B          |     660.69 ns |     5.539 ns |     5.181 ns |    1608 B |
|                                           |              |               |              |              |           |
| Decrypt · AES-128-GCM (AES-NI+PClMulV256) | 128B         |     100.75 ns |     0.924 ns |     0.864 ns |         - |
| Decrypt · AES-128-GCM (AES-NI+PClMul)     | 128B         |     102.57 ns |     0.887 ns |     0.829 ns |         - |
| Decrypt · AES-128-GCM (OS)                | 128B         |     123.78 ns |     2.172 ns |     2.032 ns |         - |
| Decrypt · AES-128-GCM (Managed)           | 128B         |     857.65 ns |     7.776 ns |     7.274 ns |         - |
| Decrypt · AES-128-GCM (BouncyCastle)      | 128B         |     930.81 ns |     7.528 ns |     6.673 ns |    1624 B |
|                                           |              |               |              |              |           |
| Encrypt · AES-128-GCM (AES-NI+PClMulV256) | 128B         |      65.01 ns |     0.916 ns |     0.812 ns |         - |
| Encrypt · AES-128-GCM (AES-NI+PClMul)     | 128B         |      67.27 ns |     1.176 ns |     1.100 ns |         - |
| Encrypt · AES-128-GCM (OS)                | 128B         |     124.46 ns |     2.338 ns |     2.187 ns |         - |
| Encrypt · AES-128-GCM (Managed)           | 128B         |     825.10 ns |    12.669 ns |    10.579 ns |         - |
| Encrypt · AES-128-GCM (BouncyCastle)      | 128B         |     838.74 ns |    16.136 ns |    15.848 ns |    1608 B |
|                                           |              |               |              |              |           |
| Decrypt · AES-128-GCM (AES-NI+PClMulV256) | 152B         |     119.40 ns |     0.745 ns |     0.660 ns |         - |
| Decrypt · AES-128-GCM (AES-NI+PClMul)     | 152B         |     122.40 ns |     2.018 ns |     1.888 ns |         - |
| Decrypt · AES-128-GCM (OS)                | 152B         |     138.06 ns |     1.517 ns |     1.419 ns |         - |
| Decrypt · AES-128-GCM (Managed)           | 152B         |   1,028.58 ns |    14.446 ns |    13.513 ns |         - |
| Decrypt · AES-128-GCM (BouncyCastle)      | 152B         |   1,048.96 ns |    20.436 ns |    19.116 ns |    1624 B |
|                                           |              |               |              |              |           |
| Encrypt · AES-128-GCM (AES-NI+PClMul)     | 152B         |      92.08 ns |     0.890 ns |     0.832 ns |         - |
| Encrypt · AES-128-GCM (AES-NI+PClMulV256) | 152B         |      94.09 ns |     0.766 ns |     0.717 ns |         - |
| Encrypt · AES-128-GCM (OS)                | 152B         |     138.87 ns |     2.316 ns |     2.054 ns |         - |
| Encrypt · AES-128-GCM (BouncyCastle)      | 152B         |     949.59 ns |     5.675 ns |     5.030 ns |    1608 B |
| Encrypt · AES-128-GCM (Managed)           | 152B         |   1,003.28 ns |    19.788 ns |    27.086 ns |         - |
|                                           |              |               |              |              |           |
| Decrypt · AES-128-GCM (AES-NI+PClMulV256) | 256B         |     113.70 ns |     0.739 ns |     0.691 ns |         - |
| Decrypt · AES-128-GCM (AES-NI+PClMul)     | 256B         |     121.53 ns |     0.706 ns |     0.626 ns |         - |
| Decrypt · AES-128-GCM (OS)                | 256B         |     129.40 ns |     0.722 ns |     0.564 ns |         - |
| Decrypt · AES-128-GCM (BouncyCastle)      | 256B         |   1,344.22 ns |    25.103 ns |    20.962 ns |    1624 B |
| Decrypt · AES-128-GCM (Managed)           | 256B         |   1,542.72 ns |    16.771 ns |    15.687 ns |         - |
|                                           |              |               |              |              |           |
| Encrypt · AES-128-GCM (AES-NI+PClMulV256) | 256B         |      79.04 ns |     0.830 ns |     0.776 ns |         - |
| Encrypt · AES-128-GCM (AES-NI+PClMul)     | 256B         |      84.47 ns |     1.107 ns |     1.035 ns |         - |
| Encrypt · AES-128-GCM (OS)                | 256B         |     124.95 ns |     2.420 ns |     2.690 ns |         - |
| Encrypt · AES-128-GCM (BouncyCastle)      | 256B         |   1,243.08 ns |    23.723 ns |    23.299 ns |    1608 B |
| Encrypt · AES-128-GCM (Managed)           | 256B         |   1,478.69 ns |    22.567 ns |    21.109 ns |         - |
|                                           |              |               |              |              |           |
| Decrypt · AES-128-GCM (OS)                | 1KB          |     183.22 ns |     1.870 ns |     1.749 ns |         - |
| Decrypt · AES-128-GCM (AES-NI+PClMulV256) | 1KB          |     190.96 ns |     1.515 ns |     1.417 ns |         - |
| Decrypt · AES-128-GCM (AES-NI+PClMul)     | 1KB          |     223.36 ns |     1.941 ns |     1.816 ns |         - |
| Decrypt · AES-128-GCM (BouncyCastle)      | 1KB          |   3,831.73 ns |    26.440 ns |    24.732 ns |    1624 B |
| Decrypt · AES-128-GCM (Managed)           | 1KB          |   5,568.99 ns |    67.656 ns |    63.285 ns |         - |
|                                           |              |               |              |              |           |
| Encrypt · AES-128-GCM (AES-NI+PClMulV256) | 1KB          |     162.59 ns |     2.542 ns |     2.253 ns |         - |
| Encrypt · AES-128-GCM (AES-NI+PClMul)     | 1KB          |     175.79 ns |     2.364 ns |     2.211 ns |         - |
| Encrypt · AES-128-GCM (OS)                | 1KB          |     181.52 ns |     3.379 ns |     2.995 ns |         - |
| Encrypt · AES-128-GCM (BouncyCastle)      | 1KB          |   3,689.68 ns |    18.133 ns |    16.962 ns |    1608 B |
| Encrypt · AES-128-GCM (Managed)           | 1KB          |   5,512.67 ns |    78.512 ns |    73.440 ns |         - |
|                                           |              |               |              |              |           |
| Decrypt · AES-128-GCM (OS)                | 8KB          |     708.11 ns |     7.367 ns |     6.891 ns |         - |
| Decrypt · AES-128-GCM (AES-NI+PClMulV256) | 8KB          |     987.63 ns |    19.508 ns |    17.294 ns |         - |
| Decrypt · AES-128-GCM (AES-NI+PClMul)     | 8KB          |   1,184.31 ns |    16.813 ns |    15.727 ns |         - |
| Decrypt · AES-128-GCM (BouncyCastle)      | 8KB          |  26,577.88 ns |   226.300 ns |   211.682 ns |    1624 B |
| Decrypt · AES-128-GCM (Managed)           | 8KB          |  43,324.50 ns |   735.115 ns |   687.627 ns |         - |
|                                           |              |               |              |              |           |
| Encrypt · AES-128-GCM (OS)                | 8KB          |     684.81 ns |     7.772 ns |     7.270 ns |         - |
| Encrypt · AES-128-GCM (AES-NI+PClMulV256) | 8KB          |   1,004.29 ns |    20.051 ns |    16.744 ns |         - |
| Encrypt · AES-128-GCM (AES-NI+PClMul)     | 8KB          |   1,100.47 ns |    16.981 ns |    15.884 ns |         - |
| Encrypt · AES-128-GCM (BouncyCastle)      | 8KB          |  26,657.78 ns |   248.214 ns |   232.179 ns |    1608 B |
| Encrypt · AES-128-GCM (Managed)           | 8KB          |  43,287.67 ns |   417.611 ns |   390.634 ns |         - |
|                                           |              |               |              |              |           |
| Decrypt · AES-128-GCM (OS)                | 128KB        |  11,233.91 ns |    59.362 ns |    49.570 ns |         - |
| Decrypt · AES-128-GCM (AES-NI+PClMulV256) | 128KB        |  15,049.02 ns |    91.170 ns |    80.819 ns |         - |
| Decrypt · AES-128-GCM (AES-NI+PClMul)     | 128KB        |  18,754.73 ns |   281.993 ns |   263.776 ns |         - |
| Decrypt · AES-128-GCM (BouncyCastle)      | 128KB        | 418,728.63 ns | 4,427.303 ns | 3,924.689 ns |    1624 B |
| Decrypt · AES-128-GCM (Managed)           | 128KB        | 689,134.91 ns | 9,730.483 ns | 9,101.899 ns |         - |
|                                           |              |               |              |              |           |
| Encrypt · AES-128-GCM (OS)                | 128KB        |  10,607.00 ns |   117.124 ns |   109.558 ns |         - |
| Encrypt · AES-128-GCM (AES-NI+PClMulV256) | 128KB        |  15,024.10 ns |   100.016 ns |    88.662 ns |         - |
| Encrypt · AES-128-GCM (AES-NI+PClMul)     | 128KB        |  16,841.69 ns |   330.312 ns |   339.206 ns |         - |
| Encrypt · AES-128-GCM (BouncyCastle)      | 128KB        | 421,064.56 ns | 3,183.694 ns | 2,978.029 ns |    1608 B |
| Encrypt · AES-128-GCM (Managed)           | 128KB        | 687,307.19 ns | 6,573.000 ns | 5,826.793 ns |         - |