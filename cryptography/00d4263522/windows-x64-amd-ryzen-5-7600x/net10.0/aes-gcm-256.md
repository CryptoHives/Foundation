| Description                                           | TestDataSize | Mean          | Error        | StdDev       | Allocated |
|------------------------------------------------------ |------------- |--------------:|-------------:|-------------:|----------:|
| Decrypt · AES-256-GCM (CryptoHives-AES-NI+PClMulV256) | 17B          |     121.71 ns |     0.546 ns |     0.510 ns |         - |
| Decrypt · AES-256-GCM (OS)                            | 17B          |     123.55 ns |     0.517 ns |     0.483 ns |         - |
| Decrypt · AES-256-GCM (CryptoHives-AES-NI+PClMul)     | 17B          |     125.46 ns |     0.450 ns |     0.399 ns |         - |
| Decrypt · AES-256-GCM (CryptoHives-Scalar)            | 17B          |     382.80 ns |     1.407 ns |     1.175 ns |         - |
| Decrypt · AES-256-GCM (BouncyCastle)                  | 17B          |     579.49 ns |     5.619 ns |     5.256 ns |    1832 B |
|                                                       |              |               |              |              |           |
| Encrypt · AES-256-GCM (CryptoHives-AES-NI+PClMul)     | 17B          |      71.76 ns |     0.282 ns |     0.264 ns |         - |
| Encrypt · AES-256-GCM (CryptoHives-AES-NI+PClMulV256) | 17B          |      72.72 ns |     0.198 ns |     0.176 ns |         - |
| Encrypt · AES-256-GCM (OS)                            | 17B          |     130.01 ns |     0.744 ns |     0.696 ns |         - |
| Encrypt · AES-256-GCM (CryptoHives-Scalar)            | 17B          |     354.02 ns |     2.468 ns |     2.308 ns |         - |
| Encrypt · AES-256-GCM (BouncyCastle)                  | 17B          |     519.94 ns |     3.637 ns |     3.402 ns |    1816 B |
|                                                       |              |               |              |              |           |
| Decrypt · AES-256-GCM (CryptoHives-AES-NI+PClMul)     | 65B          |     116.82 ns |     0.394 ns |     0.369 ns |         - |
| Decrypt · AES-256-GCM (CryptoHives-AES-NI+PClMulV256) | 65B          |     123.20 ns |     0.594 ns |     0.555 ns |         - |
| Decrypt · AES-256-GCM (OS)                            | 65B          |     127.12 ns |     0.746 ns |     0.698 ns |         - |
| Decrypt · AES-256-GCM (CryptoHives-Scalar)            | 65B          |     671.98 ns |     4.963 ns |     4.642 ns |         - |
| Decrypt · AES-256-GCM (BouncyCastle)                  | 65B          |     903.74 ns |     4.935 ns |     4.121 ns |    1832 B |
|                                                       |              |               |              |              |           |
| Encrypt · AES-256-GCM (CryptoHives-AES-NI+PClMulV256) | 65B          |      80.73 ns |     0.394 ns |     0.349 ns |         - |
| Encrypt · AES-256-GCM (CryptoHives-AES-NI+PClMul)     | 65B          |      81.17 ns |     0.296 ns |     0.277 ns |         - |
| Encrypt · AES-256-GCM (OS)                            | 65B          |     133.59 ns |     0.575 ns |     0.509 ns |         - |
| Encrypt · AES-256-GCM (CryptoHives-Scalar)            | 65B          |     641.41 ns |     4.902 ns |     4.585 ns |         - |
| Encrypt · AES-256-GCM (BouncyCastle)                  | 65B          |     713.06 ns |     5.276 ns |     4.935 ns |    1816 B |
|                                                       |              |               |              |              |           |
| Decrypt · AES-256-GCM (CryptoHives-AES-NI+PClMul)     | 128B         |     104.70 ns |     0.735 ns |     0.688 ns |         - |
| Decrypt · AES-256-GCM (CryptoHives-AES-NI+PClMulV256) | 128B         |     106.92 ns |     0.714 ns |     0.668 ns |         - |
| Decrypt · AES-256-GCM (OS)                            | 128B         |     124.32 ns |     0.670 ns |     0.627 ns |         - |
| Decrypt · AES-256-GCM (CryptoHives-Scalar)            | 128B         |     985.89 ns |     8.690 ns |     7.703 ns |         - |
| Decrypt · AES-256-GCM (BouncyCastle)                  | 128B         |   1,016.44 ns |     6.606 ns |     6.179 ns |    1832 B |
|                                                       |              |               |              |              |           |
| Encrypt · AES-256-GCM (CryptoHives-AES-NI+PClMulV256) | 128B         |      66.37 ns |     0.277 ns |     0.246 ns |         - |
| Encrypt · AES-256-GCM (CryptoHives-AES-NI+PClMul)     | 128B         |      69.88 ns |     0.291 ns |     0.272 ns |         - |
| Encrypt · AES-256-GCM (OS)                            | 128B         |     125.60 ns |     0.898 ns |     0.840 ns |         - |
| Encrypt · AES-256-GCM (BouncyCastle)                  | 128B         |     914.63 ns |     8.345 ns |     7.806 ns |    1816 B |
| Encrypt · AES-256-GCM (CryptoHives-Scalar)            | 128B         |     938.22 ns |     5.927 ns |     5.544 ns |         - |
|                                                       |              |               |              |              |           |
| Decrypt · AES-256-GCM (CryptoHives-AES-NI+PClMul)     | 152B         |     131.59 ns |     0.581 ns |     0.515 ns |         - |
| Decrypt · AES-256-GCM (CryptoHives-AES-NI+PClMulV256) | 152B         |     138.08 ns |     0.673 ns |     0.629 ns |         - |
| Decrypt · AES-256-GCM (OS)                            | 152B         |     144.04 ns |     1.040 ns |     0.973 ns |         - |
| Decrypt · AES-256-GCM (CryptoHives-Scalar)            | 152B         |   1,141.40 ns |     8.594 ns |     8.038 ns |         - |
| Decrypt · AES-256-GCM (BouncyCastle)                  | 152B         |   1,155.79 ns |     7.857 ns |     7.349 ns |    1832 B |
|                                                       |              |               |              |              |           |
| Encrypt · AES-256-GCM (CryptoHives-AES-NI+PClMulV256) | 152B         |      94.95 ns |     0.516 ns |     0.483 ns |         - |
| Encrypt · AES-256-GCM (CryptoHives-AES-NI+PClMul)     | 152B         |      96.78 ns |     0.390 ns |     0.365 ns |         - |
| Encrypt · AES-256-GCM (OS)                            | 152B         |     144.33 ns |     0.757 ns |     0.671 ns |         - |
| Encrypt · AES-256-GCM (BouncyCastle)                  | 152B         |   1,052.67 ns |     7.440 ns |     6.595 ns |    1816 B |
| Encrypt · AES-256-GCM (CryptoHives-Scalar)            | 152B         |   1,119.82 ns |     9.691 ns |     9.065 ns |         - |
|                                                       |              |               |              |              |           |
| Decrypt · AES-256-GCM (CryptoHives-AES-NI+PClMulV256) | 256B         |     120.32 ns |     0.966 ns |     0.903 ns |         - |
| Decrypt · AES-256-GCM (CryptoHives-AES-NI+PClMul)     | 256B         |     130.77 ns |     0.936 ns |     0.876 ns |         - |
| Decrypt · AES-256-GCM (OS)                            | 256B         |     142.62 ns |     0.642 ns |     0.569 ns |         - |
| Decrypt · AES-256-GCM (BouncyCastle)                  | 256B         |   1,535.12 ns |     9.138 ns |     8.548 ns |    1832 B |
| Decrypt · AES-256-GCM (CryptoHives-Scalar)            | 256B         |   1,708.91 ns |    11.802 ns |    11.039 ns |         - |
|                                                       |              |               |              |              |           |
| Encrypt · AES-256-GCM (CryptoHives-AES-NI+PClMulV256) | 256B         |      86.59 ns |     0.517 ns |     0.483 ns |         - |
| Encrypt · AES-256-GCM (CryptoHives-AES-NI+PClMul)     | 256B         |      90.44 ns |     0.345 ns |     0.323 ns |         - |
| Encrypt · AES-256-GCM (OS)                            | 256B         |     135.57 ns |     0.398 ns |     0.332 ns |         - |
| Encrypt · AES-256-GCM (BouncyCastle)                  | 256B         |   1,428.60 ns |     8.355 ns |     7.406 ns |    1816 B |
| Encrypt · AES-256-GCM (CryptoHives-Scalar)            | 256B         |   1,686.28 ns |    13.931 ns |    13.031 ns |         - |
|                                                       |              |               |              |              |           |
| Decrypt · AES-256-GCM (OS)                            | 1KB          |     213.18 ns |     1.069 ns |     1.000 ns |         - |
| Decrypt · AES-256-GCM (CryptoHives-AES-NI+PClMulV256) | 1KB          |     216.11 ns |     1.174 ns |     1.098 ns |         - |
| Decrypt · AES-256-GCM (CryptoHives-AES-NI+PClMul)     | 1KB          |     268.17 ns |     1.738 ns |     1.626 ns |         - |
| Decrypt · AES-256-GCM (BouncyCastle)                  | 1KB          |   4,661.81 ns |    26.966 ns |    23.904 ns |    1832 B |
| Decrypt · AES-256-GCM (CryptoHives-Scalar)            | 1KB          |   6,259.53 ns |    29.396 ns |    26.058 ns |         - |
|                                                       |              |               |              |              |           |
| Encrypt · AES-256-GCM (OS)                            | 1KB          |     183.11 ns |     0.977 ns |     0.866 ns |         - |
| Encrypt · AES-256-GCM (CryptoHives-AES-NI+PClMulV256) | 1KB          |     204.30 ns |     0.552 ns |     0.516 ns |         - |
| Encrypt · AES-256-GCM (CryptoHives-AES-NI+PClMul)     | 1KB          |     226.61 ns |     1.147 ns |     1.073 ns |         - |
| Encrypt · AES-256-GCM (BouncyCastle)                  | 1KB          |   4,589.04 ns |    26.732 ns |    25.005 ns |    1816 B |
| Encrypt · AES-256-GCM (CryptoHives-Scalar)            | 1KB          |   6,250.26 ns |    38.277 ns |    35.804 ns |         - |
|                                                       |              |               |              |              |           |
| Decrypt · AES-256-GCM (OS)                            | 8KB          |     925.86 ns |     4.340 ns |     4.060 ns |         - |
| Decrypt · AES-256-GCM (CryptoHives-AES-NI+PClMulV256) | 8KB          |   1,140.67 ns |    10.154 ns |     9.498 ns |         - |
| Decrypt · AES-256-GCM (CryptoHives-AES-NI+PClMul)     | 8KB          |   1,557.78 ns |     7.335 ns |     6.502 ns |         - |
| Decrypt · AES-256-GCM (BouncyCastle)                  | 8KB          |  33,807.88 ns |   125.413 ns |    97.914 ns |    1832 B |
| Decrypt · AES-256-GCM (CryptoHives-Scalar)            | 8KB          |  53,913.30 ns |   291.579 ns |   272.744 ns |         - |
|                                                       |              |               |              |              |           |
| Encrypt · AES-256-GCM (OS)                            | 8KB          |     717.86 ns |     4.891 ns |     4.575 ns |         - |
| Encrypt · AES-256-GCM (CryptoHives-AES-NI+PClMulV256) | 8KB          |   1,313.59 ns |    11.529 ns |    10.784 ns |         - |
| Encrypt · AES-256-GCM (CryptoHives-AES-NI+PClMul)     | 8KB          |   1,484.48 ns |    11.121 ns |    10.403 ns |         - |
| Encrypt · AES-256-GCM (BouncyCastle)                  | 8KB          |  34,101.14 ns |   328.461 ns |   307.243 ns |    1816 B |
| Encrypt · AES-256-GCM (CryptoHives-Scalar)            | 8KB          |  48,881.48 ns |   336.697 ns |   314.947 ns |         - |
|                                                       |              |               |              |              |           |
| Decrypt · AES-256-GCM (OS)                            | 128KB        |  15,189.34 ns |    62.886 ns |    58.823 ns |         - |
| Decrypt · AES-256-GCM (CryptoHives-AES-NI+PClMulV256) | 128KB        |  17,597.61 ns |    96.432 ns |    80.525 ns |         - |
| Decrypt · AES-256-GCM (CryptoHives-AES-NI+PClMul)     | 128KB        |  23,551.04 ns |    85.443 ns |    75.743 ns |         - |
| Decrypt · AES-256-GCM (BouncyCastle)                  | 128KB        | 537,429.29 ns | 4,782.363 ns | 4,473.425 ns |    1832 B |
| Decrypt · AES-256-GCM (CryptoHives-Scalar)            | 128KB        | 777,480.43 ns | 6,297.327 ns | 5,890.523 ns |         - |
|                                                       |              |               |              |              |           |
| Encrypt · AES-256-GCM (OS)                            | 128KB        |  10,779.29 ns |    61.772 ns |    57.782 ns |         - |
| Encrypt · AES-256-GCM (CryptoHives-AES-NI+PClMulV256) | 128KB        |  20,424.58 ns |   151.403 ns |   141.623 ns |         - |
| Encrypt · AES-256-GCM (CryptoHives-AES-NI+PClMul)     | 128KB        |  23,151.74 ns |   129.615 ns |   121.242 ns |         - |
| Encrypt · AES-256-GCM (BouncyCastle)                  | 128KB        | 536,925.03 ns | 4,257.289 ns | 3,982.271 ns |    1816 B |
| Encrypt · AES-256-GCM (CryptoHives-Scalar)            | 128KB        | 774,857.02 ns | 5,539.438 ns | 5,181.594 ns |         - |