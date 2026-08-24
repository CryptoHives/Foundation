| Description                                           | TestDataSize | Mean            | Error        | StdDev       | Allocated |
|------------------------------------------------------ |------------- |----------------:|-------------:|-------------:|----------:|
| Decrypt · AES-256-GCM (CryptoHives-AES-NI+PClMulV256) | 17B          |       122.39 ns |     0.158 ns |     0.140 ns |         - |
| Decrypt · AES-256-GCM (CryptoHives-AES-NI+PClMul)     | 17B          |       124.27 ns |     0.285 ns |     0.252 ns |         - |
| Decrypt · AES-256-GCM (OS)                            | 17B          |       125.35 ns |     0.397 ns |     0.371 ns |         - |
| Decrypt · AES-256-GCM (CryptoHives-Scalar)            | 17B          |       462.99 ns |     1.635 ns |     1.366 ns |         - |
| Decrypt · AES-256-GCM (BouncyCastle)                  | 17B          |       583.96 ns |     1.990 ns |     1.662 ns |    1832 B |
|                                                       |              |                 |              |              |           |
| Encrypt · AES-256-GCM (CryptoHives-AES-NI+PClMulV256) | 17B          |        71.72 ns |     0.138 ns |     0.122 ns |         - |
| Encrypt · AES-256-GCM (CryptoHives-AES-NI+PClMul)     | 17B          |        71.78 ns |     0.157 ns |     0.131 ns |         - |
| Encrypt · AES-256-GCM (OS)                            | 17B          |       132.33 ns |     0.375 ns |     0.332 ns |         - |
| Encrypt · AES-256-GCM (CryptoHives-Scalar)            | 17B          |       434.12 ns |     0.415 ns |     0.324 ns |         - |
| Encrypt · AES-256-GCM (BouncyCastle)                  | 17B          |       523.72 ns |     4.505 ns |     3.993 ns |    1816 B |
|                                                       |              |                 |              |              |           |
| Decrypt · AES-256-GCM (CryptoHives-AES-NI+PClMulV256) | 65B          |       108.58 ns |     0.140 ns |     0.124 ns |         - |
| Decrypt · AES-256-GCM (CryptoHives-AES-NI+PClMul)     | 65B          |       121.05 ns |     0.098 ns |     0.081 ns |         - |
| Decrypt · AES-256-GCM (OS)                            | 65B          |       128.92 ns |     0.407 ns |     0.381 ns |         - |
| Decrypt · AES-256-GCM (BouncyCastle)                  | 65B          |       803.26 ns |     3.045 ns |     2.377 ns |    1832 B |
| Decrypt · AES-256-GCM (CryptoHives-Scalar)            | 65B          |       824.60 ns |     1.318 ns |     1.168 ns |         - |
|                                                       |              |                 |              |              |           |
| Encrypt · AES-256-GCM (CryptoHives-AES-NI+PClMul)     | 65B          |        79.77 ns |     0.130 ns |     0.115 ns |         - |
| Encrypt · AES-256-GCM (CryptoHives-AES-NI+PClMulV256) | 65B          |        80.58 ns |     0.102 ns |     0.085 ns |         - |
| Encrypt · AES-256-GCM (OS)                            | 65B          |       135.58 ns |     0.359 ns |     0.319 ns |         - |
| Encrypt · AES-256-GCM (BouncyCastle)                  | 65B          |       716.29 ns |     3.186 ns |     2.660 ns |    1816 B |
| Encrypt · AES-256-GCM (CryptoHives-Scalar)            | 65B          |       796.86 ns |     4.117 ns |     3.214 ns |         - |
|                                                       |              |                 |              |              |           |
| Decrypt · AES-256-GCM (CryptoHives-AES-NI+PClMulV256) | 128B         |       105.49 ns |     0.231 ns |     0.193 ns |         - |
| Decrypt · AES-256-GCM (CryptoHives-AES-NI+PClMul)     | 128B         |       106.32 ns |     0.119 ns |     0.093 ns |         - |
| Decrypt · AES-256-GCM (OS)                            | 128B         |       126.39 ns |     0.199 ns |     0.177 ns |         - |
| Decrypt · AES-256-GCM (BouncyCastle)                  | 128B         |     1,014.50 ns |     4.858 ns |     4.307 ns |    1832 B |
| Decrypt · AES-256-GCM (CryptoHives-Scalar)            | 128B         |     1,187.34 ns |     3.463 ns |     3.070 ns |         - |
|                                                       |              |                 |              |              |           |
| Encrypt · AES-256-GCM (CryptoHives-AES-NI+PClMulV256) | 128B         |        66.89 ns |     0.193 ns |     0.161 ns |         - |
| Encrypt · AES-256-GCM (CryptoHives-AES-NI+PClMul)     | 128B         |        69.66 ns |     0.164 ns |     0.137 ns |         - |
| Encrypt · AES-256-GCM (OS)                            | 128B         |       127.04 ns |     0.218 ns |     0.182 ns |         - |
| Encrypt · AES-256-GCM (BouncyCastle)                  | 128B         |       909.51 ns |     3.377 ns |     3.159 ns |    1816 B |
| Encrypt · AES-256-GCM (CryptoHives-Scalar)            | 128B         |     1,155.13 ns |     2.829 ns |     2.362 ns |         - |
|                                                       |              |                 |              |              |           |
| Decrypt · AES-256-GCM (CryptoHives-AES-NI+PClMulV256) | 152B         |       132.19 ns |     0.363 ns |     0.303 ns |         - |
| Decrypt · AES-256-GCM (CryptoHives-AES-NI+PClMul)     | 152B         |       133.88 ns |     0.463 ns |     0.387 ns |         - |
| Decrypt · AES-256-GCM (OS)                            | 152B         |       144.87 ns |     0.314 ns |     0.278 ns |         - |
| Decrypt · AES-256-GCM (BouncyCastle)                  | 152B         |     1,160.60 ns |     6.845 ns |     6.403 ns |    1832 B |
| Decrypt · AES-256-GCM (CryptoHives-Scalar)            | 152B         |     1,432.29 ns |     3.243 ns |     2.708 ns |         - |
|                                                       |              |                 |              |              |           |
| Encrypt · AES-256-GCM (CryptoHives-AES-NI+PClMulV256) | 152B         |        94.98 ns |     0.164 ns |     0.128 ns |         - |
| Encrypt · AES-256-GCM (CryptoHives-AES-NI+PClMul)     | 152B         |        96.82 ns |     0.140 ns |     0.131 ns |         - |
| Encrypt · AES-256-GCM (OS)                            | 152B         |       145.63 ns |     1.323 ns |     1.105 ns |         - |
| Encrypt · AES-256-GCM (BouncyCastle)                  | 152B         |     1,054.02 ns |     5.280 ns |     4.680 ns |    1816 B |
| Encrypt · AES-256-GCM (CryptoHives-Scalar)            | 152B         |     1,401.39 ns |     4.536 ns |     4.021 ns |         - |
|                                                       |              |                 |              |              |           |
| Decrypt · AES-256-GCM (CryptoHives-AES-NI+PClMulV256) | 256B         |       118.09 ns |     0.374 ns |     0.350 ns |         - |
| Decrypt · AES-256-GCM (CryptoHives-AES-NI+PClMul)     | 256B         |       137.58 ns |     0.591 ns |     0.493 ns |         - |
| Decrypt · AES-256-GCM (OS)                            | 256B         |       139.03 ns |     0.374 ns |     0.313 ns |         - |
| Decrypt · AES-256-GCM (BouncyCastle)                  | 256B         |     1,532.30 ns |     7.006 ns |     6.211 ns |    1832 B |
| Decrypt · AES-256-GCM (CryptoHives-Scalar)            | 256B         |     2,151.65 ns |     4.404 ns |     3.677 ns |         - |
|                                                       |              |                 |              |              |           |
| Encrypt · AES-256-GCM (CryptoHives-AES-NI+PClMulV256) | 256B         |        87.13 ns |     0.396 ns |     0.351 ns |         - |
| Encrypt · AES-256-GCM (CryptoHives-AES-NI+PClMul)     | 256B         |        91.85 ns |     0.165 ns |     0.154 ns |         - |
| Encrypt · AES-256-GCM (OS)                            | 256B         |       130.30 ns |     0.266 ns |     0.236 ns |         - |
| Encrypt · AES-256-GCM (BouncyCastle)                  | 256B         |     1,445.51 ns |    11.219 ns |     9.946 ns |    1816 B |
| Encrypt · AES-256-GCM (CryptoHives-Scalar)            | 256B         |     2,213.19 ns |     6.970 ns |     6.179 ns |         - |
|                                                       |              |                 |              |              |           |
| Decrypt · AES-256-GCM (OS)                            | 1KB          |       213.20 ns |     0.378 ns |     0.353 ns |         - |
| Decrypt · AES-256-GCM (CryptoHives-AES-NI+PClMulV256) | 1KB          |       218.34 ns |     0.665 ns |     0.589 ns |         - |
| Decrypt · AES-256-GCM (CryptoHives-AES-NI+PClMul)     | 1KB          |       272.38 ns |     1.010 ns |     0.895 ns |         - |
| Decrypt · AES-256-GCM (BouncyCastle)                  | 1KB          |     4,762.00 ns |    21.612 ns |    20.216 ns |    1832 B |
| Decrypt · AES-256-GCM (CryptoHives-Scalar)            | 1KB          |     8,279.90 ns |    22.280 ns |    19.751 ns |         - |
|                                                       |              |                 |              |              |           |
| Encrypt · AES-256-GCM (OS)                            | 1KB          |       185.57 ns |     0.611 ns |     0.541 ns |         - |
| Encrypt · AES-256-GCM (CryptoHives-AES-NI+PClMulV256) | 1KB          |       206.30 ns |     0.253 ns |     0.212 ns |         - |
| Encrypt · AES-256-GCM (CryptoHives-AES-NI+PClMul)     | 1KB          |       224.75 ns |     0.428 ns |     0.380 ns |         - |
| Encrypt · AES-256-GCM (BouncyCastle)                  | 1KB          |     4,635.91 ns |    26.853 ns |    23.805 ns |    1816 B |
| Encrypt · AES-256-GCM (CryptoHives-Scalar)            | 1KB          |     7,962.28 ns |    29.967 ns |    23.396 ns |         - |
|                                                       |              |                 |              |              |           |
| Decrypt · AES-256-GCM (OS)                            | 8KB          |       954.77 ns |     2.113 ns |     1.764 ns |         - |
| Decrypt · AES-256-GCM (CryptoHives-AES-NI+PClMulV256) | 8KB          |     1,136.09 ns |     2.689 ns |     2.515 ns |         - |
| Decrypt · AES-256-GCM (CryptoHives-AES-NI+PClMul)     | 8KB          |     1,554.07 ns |     2.421 ns |     2.022 ns |         - |
| Decrypt · AES-256-GCM (BouncyCastle)                  | 8KB          |    34,329.80 ns |   119.326 ns |   105.779 ns |    1832 B |
| Decrypt · AES-256-GCM (CryptoHives-Scalar)            | 8KB          |    62,413.53 ns |   385.621 ns |   322.011 ns |         - |
|                                                       |              |                 |              |              |           |
| Encrypt · AES-256-GCM (OS)                            | 8KB          |       733.61 ns |     1.654 ns |     1.466 ns |         - |
| Encrypt · AES-256-GCM (CryptoHives-AES-NI+PClMulV256) | 8KB          |     1,327.01 ns |     1.831 ns |     1.529 ns |         - |
| Encrypt · AES-256-GCM (CryptoHives-AES-NI+PClMul)     | 8KB          |     1,495.21 ns |    11.175 ns |     9.331 ns |         - |
| Encrypt · AES-256-GCM (BouncyCastle)                  | 8KB          |    34,157.69 ns |    85.743 ns |    66.943 ns |    1816 B |
| Encrypt · AES-256-GCM (CryptoHives-Scalar)            | 8KB          |    64,862.50 ns |   404.646 ns |   337.897 ns |         - |
|                                                       |              |                 |              |              |           |
| Decrypt · AES-256-GCM (OS)                            | 128KB        |    14,695.12 ns |    18.773 ns |    16.642 ns |         - |
| Decrypt · AES-256-GCM (CryptoHives-AES-NI+PClMulV256) | 128KB        |    20,347.43 ns |   577.931 ns | 1,704.043 ns |         - |
| Decrypt · AES-256-GCM (CryptoHives-AES-NI+PClMul)     | 128KB        |    23,657.60 ns |    27.634 ns |    21.575 ns |         - |
| Decrypt · AES-256-GCM (BouncyCastle)                  | 128KB        |   543,893.21 ns | 1,616.832 ns | 1,433.280 ns |    1832 B |
| Decrypt · AES-256-GCM (CryptoHives-Scalar)            | 128KB        | 1,044,751.52 ns | 2,088.152 ns | 1,851.093 ns |         - |
|                                                       |              |                 |              |              |           |
| Encrypt · AES-256-GCM (OS)                            | 128KB        |    11,457.81 ns |    18.973 ns |    15.843 ns |         - |
| Encrypt · AES-256-GCM (CryptoHives-AES-NI+PClMulV256) | 128KB        |    20,573.16 ns |    40.205 ns |    35.641 ns |         - |
| Encrypt · AES-256-GCM (CryptoHives-AES-NI+PClMul)     | 128KB        |    23,224.75 ns |    44.131 ns |    41.280 ns |         - |
| Encrypt · AES-256-GCM (BouncyCastle)                  | 128KB        |   541,424.42 ns |   824.047 ns |   688.116 ns |    1816 B |
| Encrypt · AES-256-GCM (CryptoHives-Scalar)            | 128KB        |   987,252.20 ns | 2,110.228 ns | 1,762.136 ns |         - |