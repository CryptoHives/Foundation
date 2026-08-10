| Description                                           | TestDataSize | Mean          | Error        | StdDev       | Allocated |
|------------------------------------------------------ |------------- |--------------:|-------------:|-------------:|----------:|
| Decrypt · AES-192-GCM (OS)                            | 17B          |     121.62 ns |     1.359 ns |     1.271 ns |         - |
| Decrypt · AES-192-GCM (CryptoHives-AES-NI+PClMul)     | 17B          |     123.01 ns |     0.642 ns |     0.601 ns |         - |
| Decrypt · AES-192-GCM (CryptoHives-AES-NI+PClMulV256) | 17B          |     123.11 ns |     0.573 ns |     0.536 ns |         - |
| Decrypt · AES-192-GCM (CryptoHives-Scalar)            | 17B          |     367.45 ns |     3.526 ns |     3.298 ns |         - |
| Decrypt · AES-192-GCM (BouncyCastle)                  | 17B          |     619.85 ns |     6.970 ns |     6.179 ns |    1728 B |
|                                                       |              |               |              |              |           |
| Encrypt · AES-192-GCM (CryptoHives-AES-NI+PClMul)     | 17B          |      68.43 ns |     0.128 ns |     0.113 ns |         - |
| Encrypt · AES-192-GCM (CryptoHives-AES-NI+PClMulV256) | 17B          |      70.11 ns |     0.441 ns |     0.413 ns |         - |
| Encrypt · AES-192-GCM (OS)                            | 17B          |     127.81 ns |     0.768 ns |     0.642 ns |         - |
| Encrypt · AES-192-GCM (CryptoHives-Scalar)            | 17B          |     335.67 ns |     2.774 ns |     2.459 ns |         - |
| Encrypt · AES-192-GCM (BouncyCastle)                  | 17B          |     564.36 ns |     4.295 ns |     3.586 ns |    1712 B |
|                                                       |              |               |              |              |           |
| Decrypt · AES-192-GCM (CryptoHives-AES-NI+PClMulV256) | 65B          |     110.06 ns |     0.465 ns |     0.435 ns |         - |
| Decrypt · AES-192-GCM (CryptoHives-AES-NI+PClMul)     | 65B          |     113.45 ns |     0.733 ns |     0.650 ns |         - |
| Decrypt · AES-192-GCM (OS)                            | 65B          |     124.02 ns |     0.669 ns |     0.559 ns |         - |
| Decrypt · AES-192-GCM (CryptoHives-Scalar)            | 65B          |     633.57 ns |     3.986 ns |     3.728 ns |         - |
| Decrypt · AES-192-GCM (BouncyCastle)                  | 65B          |     830.63 ns |     5.619 ns |     4.692 ns |    1728 B |
|                                                       |              |               |              |              |           |
| Encrypt · AES-192-GCM (CryptoHives-AES-NI+PClMul)     | 65B          |      76.46 ns |     0.381 ns |     0.338 ns |         - |
| Encrypt · AES-192-GCM (CryptoHives-AES-NI+PClMulV256) | 65B          |      76.95 ns |     0.365 ns |     0.341 ns |         - |
| Encrypt · AES-192-GCM (OS)                            | 65B          |     134.62 ns |     1.355 ns |     1.267 ns |         - |
| Encrypt · AES-192-GCM (CryptoHives-Scalar)            | 65B          |     659.37 ns |     5.602 ns |     5.240 ns |         - |
| Encrypt · AES-192-GCM (BouncyCastle)                  | 65B          |     740.93 ns |     5.279 ns |     4.938 ns |    1712 B |
|                                                       |              |               |              |              |           |
| Decrypt · AES-192-GCM (CryptoHives-AES-NI+PClMulV256) | 128B         |      99.43 ns |     0.818 ns |     0.683 ns |         - |
| Decrypt · AES-192-GCM (CryptoHives-AES-NI+PClMul)     | 128B         |     110.87 ns |     1.099 ns |     1.028 ns |         - |
| Decrypt · AES-192-GCM (OS)                            | 128B         |     125.48 ns |     1.095 ns |     0.970 ns |         - |
| Decrypt · AES-192-GCM (CryptoHives-Scalar)            | 128B         |     899.80 ns |     4.144 ns |     3.876 ns |         - |
| Decrypt · AES-192-GCM (BouncyCastle)                  | 128B         |   1,013.59 ns |    12.294 ns |    10.898 ns |    1728 B |
|                                                       |              |               |              |              |           |
| Encrypt · AES-192-GCM (CryptoHives-AES-NI+PClMulV256) | 128B         |      63.69 ns |     0.320 ns |     0.283 ns |         - |
| Encrypt · AES-192-GCM (CryptoHives-AES-NI+PClMul)     | 128B         |      66.21 ns |     0.841 ns |     0.746 ns |         - |
| Encrypt · AES-192-GCM (OS)                            | 128B         |     123.51 ns |     0.731 ns |     0.684 ns |         - |
| Encrypt · AES-192-GCM (CryptoHives-Scalar)            | 128B         |     872.28 ns |     5.200 ns |     4.609 ns |         - |
| Encrypt · AES-192-GCM (BouncyCastle)                  | 128B         |     910.20 ns |     6.578 ns |     6.153 ns |    1712 B |
|                                                       |              |               |              |              |           |
| Decrypt · AES-192-GCM (CryptoHives-AES-NI+PClMulV256) | 152B         |     126.19 ns |     0.912 ns |     0.808 ns |         - |
| Decrypt · AES-192-GCM (CryptoHives-AES-NI+PClMul)     | 152B         |     127.85 ns |     0.594 ns |     0.496 ns |         - |
| Decrypt · AES-192-GCM (OS)                            | 152B         |     139.20 ns |     0.920 ns |     0.816 ns |         - |
| Decrypt · AES-192-GCM (CryptoHives-Scalar)            | 152B         |   1,081.29 ns |     8.235 ns |     6.877 ns |         - |
| Decrypt · AES-192-GCM (BouncyCastle)                  | 152B         |   1,143.32 ns |    12.792 ns |    10.682 ns |    1728 B |
|                                                       |              |               |              |              |           |
| Encrypt · AES-192-GCM (CryptoHives-AES-NI+PClMulV256) | 152B         |      91.69 ns |     0.505 ns |     0.448 ns |         - |
| Encrypt · AES-192-GCM (CryptoHives-AES-NI+PClMul)     | 152B         |      93.33 ns |     0.491 ns |     0.460 ns |         - |
| Encrypt · AES-192-GCM (OS)                            | 152B         |     142.27 ns |     1.326 ns |     1.175 ns |         - |
| Encrypt · AES-192-GCM (CryptoHives-Scalar)            | 152B         |   1,055.52 ns |     6.951 ns |     6.162 ns |         - |
| Encrypt · AES-192-GCM (BouncyCastle)                  | 152B         |   1,057.00 ns |     6.063 ns |     5.375 ns |    1712 B |
|                                                       |              |               |              |              |           |
| Decrypt · AES-192-GCM (CryptoHives-AES-NI+PClMulV256) | 256B         |     114.13 ns |     0.748 ns |     0.699 ns |         - |
| Decrypt · AES-192-GCM (CryptoHives-AES-NI+PClMul)     | 256B         |     129.53 ns |     1.343 ns |     1.256 ns |         - |
| Decrypt · AES-192-GCM (OS)                            | 256B         |     136.74 ns |     1.608 ns |     1.343 ns |         - |
| Decrypt · AES-192-GCM (BouncyCastle)                  | 256B         |   1,477.92 ns |     9.514 ns |     8.899 ns |    1728 B |
| Decrypt · AES-192-GCM (CryptoHives-Scalar)            | 256B         |   1,615.13 ns |    11.227 ns |     9.953 ns |         - |
|                                                       |              |               |              |              |           |
| Encrypt · AES-192-GCM (CryptoHives-AES-NI+PClMulV256) | 256B         |      81.91 ns |     0.571 ns |     0.534 ns |         - |
| Encrypt · AES-192-GCM (CryptoHives-AES-NI+PClMul)     | 256B         |      86.55 ns |     0.424 ns |     0.397 ns |         - |
| Encrypt · AES-192-GCM (OS)                            | 256B         |     128.19 ns |     1.228 ns |     1.149 ns |         - |
| Encrypt · AES-192-GCM (BouncyCastle)                  | 256B         |   1,378.89 ns |    10.703 ns |    10.011 ns |    1712 B |
| Encrypt · AES-192-GCM (CryptoHives-Scalar)            | 256B         |   1,592.49 ns |    12.409 ns |    10.362 ns |         - |
|                                                       |              |               |              |              |           |
| Decrypt · AES-192-GCM (OS)                            | 1KB          |     194.01 ns |     0.792 ns |     0.702 ns |         - |
| Decrypt · AES-192-GCM (CryptoHives-AES-NI+PClMulV256) | 1KB          |     207.23 ns |     1.373 ns |     1.217 ns |         - |
| Decrypt · AES-192-GCM (CryptoHives-AES-NI+PClMul)     | 1KB          |     259.93 ns |     1.766 ns |     1.652 ns |         - |
| Decrypt · AES-192-GCM (BouncyCastle)                  | 1KB          |   4,301.69 ns |    35.094 ns |    29.305 ns |    1728 B |
| Decrypt · AES-192-GCM (CryptoHives-Scalar)            | 1KB          |   5,889.88 ns |    26.834 ns |    25.101 ns |         - |
|                                                       |              |               |              |              |           |
| Encrypt · AES-192-GCM (OS)                            | 1KB          |     181.19 ns |     1.152 ns |     0.962 ns |         - |
| Encrypt · AES-192-GCM (CryptoHives-AES-NI+PClMulV256) | 1KB          |     191.76 ns |     1.139 ns |     1.065 ns |         - |
| Encrypt · AES-192-GCM (CryptoHives-AES-NI+PClMul)     | 1KB          |     211.66 ns |     1.028 ns |     0.961 ns |         - |
| Encrypt · AES-192-GCM (BouncyCastle)                  | 1KB          |   4,176.93 ns |    27.873 ns |    24.709 ns |    1712 B |
| Encrypt · AES-192-GCM (CryptoHives-Scalar)            | 1KB          |   5,886.38 ns |    39.264 ns |    32.787 ns |         - |
|                                                       |              |               |              |              |           |
| Decrypt · AES-192-GCM (OS)                            | 8KB          |     791.13 ns |     4.559 ns |     4.041 ns |         - |
| Decrypt · AES-192-GCM (CryptoHives-AES-NI+PClMulV256) | 8KB          |   1,082.25 ns |     6.956 ns |     6.506 ns |         - |
| Decrypt · AES-192-GCM (CryptoHives-AES-NI+PClMul)     | 8KB          |   1,485.68 ns |    11.148 ns |     9.309 ns |         - |
| Decrypt · AES-192-GCM (BouncyCastle)                  | 8KB          |  30,200.13 ns |   211.873 ns |   198.186 ns |    1728 B |
| Decrypt · AES-192-GCM (CryptoHives-Scalar)            | 8KB          |  45,683.56 ns |   210.031 ns |   186.187 ns |         - |
|                                                       |              |               |              |              |           |
| Encrypt · AES-192-GCM (OS)                            | 8KB          |     709.72 ns |     3.737 ns |     3.495 ns |         - |
| Encrypt · AES-192-GCM (CryptoHives-AES-NI+PClMulV256) | 8KB          |   1,214.24 ns |     6.265 ns |     5.232 ns |         - |
| Encrypt · AES-192-GCM (CryptoHives-AES-NI+PClMul)     | 8KB          |   1,390.79 ns |     6.678 ns |     5.576 ns |         - |
| Encrypt · AES-192-GCM (BouncyCastle)                  | 8KB          |  30,011.68 ns |   156.915 ns |   131.031 ns |    1712 B |
| Encrypt · AES-192-GCM (CryptoHives-Scalar)            | 8KB          |  45,761.38 ns |   193.558 ns |   161.629 ns |         - |
|                                                       |              |               |              |              |           |
| Decrypt · AES-192-GCM (OS)                            | 128KB        |  11,759.00 ns |    80.111 ns |    71.016 ns |         - |
| Decrypt · AES-192-GCM (CryptoHives-AES-NI+PClMulV256) | 128KB        |  16,703.77 ns |    83.215 ns |    64.969 ns |         - |
| Decrypt · AES-192-GCM (CryptoHives-AES-NI+PClMul)     | 128KB        |  22,537.92 ns |   252.892 ns |   224.182 ns |         - |
| Decrypt · AES-192-GCM (BouncyCastle)                  | 128KB        | 477,543.21 ns | 2,193.260 ns | 2,051.577 ns |    1728 B |
| Decrypt · AES-192-GCM (CryptoHives-Scalar)            | 128KB        | 734,393.27 ns | 5,925.227 ns | 5,542.461 ns |         - |
|                                                       |              |               |              |              |           |
| Encrypt · AES-192-GCM (OS)                            | 128KB        |  10,321.67 ns |    61.900 ns |    54.873 ns |         - |
| Encrypt · AES-192-GCM (CryptoHives-AES-NI+PClMulV256) | 128KB        |  18,743.55 ns |   107.209 ns |    95.038 ns |         - |
| Encrypt · AES-192-GCM (CryptoHives-AES-NI+PClMul)     | 128KB        |  21,588.07 ns |   195.687 ns |   183.046 ns |         - |
| Encrypt · AES-192-GCM (BouncyCastle)                  | 128KB        | 475,940.51 ns | 3,513.591 ns | 3,114.707 ns |    1712 B |
| Encrypt · AES-192-GCM (CryptoHives-Scalar)            | 128KB        | 730,424.86 ns | 6,197.974 ns | 5,175.589 ns |         - |