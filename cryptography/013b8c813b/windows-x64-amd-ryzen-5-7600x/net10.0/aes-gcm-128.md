| Description                                           | TestDataSize | Mean          | Error        | StdDev       | Allocated |
|------------------------------------------------------ |------------- |--------------:|-------------:|-------------:|----------:|
| Decrypt · AES-128-GCM (OS)                            | 17B          |     117.81 ns |     0.387 ns |     0.323 ns |         - |
| Decrypt · AES-128-GCM (CryptoHives-AES-NI+PClMulV256) | 17B          |     120.68 ns |     0.246 ns |     0.218 ns |         - |
| Decrypt · AES-128-GCM (CryptoHives-AES-NI+PClMul)     | 17B          |     125.04 ns |     0.221 ns |     0.207 ns |         - |
| Decrypt · AES-128-GCM (CryptoHives-Scalar)            | 17B          |     347.19 ns |     0.824 ns |     0.730 ns |         - |
| Decrypt · AES-128-GCM (BouncyCastle)                  | 17B          |     587.58 ns |     2.472 ns |     2.313 ns |    1624 B |
|                                                       |              |               |              |              |           |
| Encrypt · AES-128-GCM (CryptoHives-AES-NI+PClMulV256) | 17B          |      66.54 ns |     0.101 ns |     0.090 ns |         - |
| Encrypt · AES-128-GCM (CryptoHives-AES-NI+PClMul)     | 17B          |      67.49 ns |     0.071 ns |     0.059 ns |         - |
| Encrypt · AES-128-GCM (OS)                            | 17B          |     122.84 ns |     0.171 ns |     0.143 ns |         - |
| Encrypt · AES-128-GCM (CryptoHives-Scalar)            | 17B          |     317.65 ns |     0.523 ns |     0.463 ns |         - |
| Encrypt · AES-128-GCM (BouncyCastle)                  | 17B          |     566.44 ns |     3.521 ns |     3.294 ns |    1608 B |
|                                                       |              |               |              |              |           |
| Decrypt · AES-128-GCM (CryptoHives-AES-NI+PClMulV256) | 65B          |     102.36 ns |     0.383 ns |     0.340 ns |         - |
| Decrypt · AES-128-GCM (CryptoHives-AES-NI+PClMul)     | 65B          |     103.46 ns |     0.171 ns |     0.160 ns |         - |
| Decrypt · AES-128-GCM (OS)                            | 65B          |     122.84 ns |     0.356 ns |     0.315 ns |         - |
| Decrypt · AES-128-GCM (CryptoHives-Scalar)            | 65B          |     593.71 ns |     1.330 ns |     1.179 ns |         - |
| Decrypt · AES-128-GCM (BouncyCastle)                  | 65B          |     779.70 ns |     3.011 ns |     2.817 ns |    1624 B |
|                                                       |              |               |              |              |           |
| Encrypt · AES-128-GCM (CryptoHives-AES-NI+PClMul)     | 65B          |      71.67 ns |     0.169 ns |     0.149 ns |         - |
| Encrypt · AES-128-GCM (CryptoHives-AES-NI+PClMulV256) | 65B          |      71.74 ns |     0.177 ns |     0.166 ns |         - |
| Encrypt · AES-128-GCM (OS)                            | 65B          |     127.24 ns |     0.534 ns |     0.446 ns |         - |
| Encrypt · AES-128-GCM (CryptoHives-Scalar)            | 65B          |     564.17 ns |     1.586 ns |     1.406 ns |         - |
| Encrypt · AES-128-GCM (BouncyCastle)                  | 65B          |     680.58 ns |     2.944 ns |     2.609 ns |    1608 B |
|                                                       |              |               |              |              |           |
| Decrypt · AES-128-GCM (CryptoHives-AES-NI+PClMulV256) | 128B         |      96.70 ns |     0.202 ns |     0.158 ns |         - |
| Decrypt · AES-128-GCM (CryptoHives-AES-NI+PClMul)     | 128B         |      98.06 ns |     0.139 ns |     0.130 ns |         - |
| Decrypt · AES-128-GCM (OS)                            | 128B         |     126.33 ns |     0.407 ns |     0.340 ns |         - |
| Decrypt · AES-128-GCM (CryptoHives-Scalar)            | 128B         |     839.97 ns |     2.033 ns |     1.698 ns |         - |
| Decrypt · AES-128-GCM (BouncyCastle)                  | 128B         |     903.47 ns |     1.874 ns |     1.565 ns |    1624 B |
|                                                       |              |               |              |              |           |
| Encrypt · AES-128-GCM (CryptoHives-AES-NI+PClMulV256) | 128B         |      60.46 ns |     0.154 ns |     0.136 ns |         - |
| Encrypt · AES-128-GCM (CryptoHives-AES-NI+PClMul)     | 128B         |      63.38 ns |     0.201 ns |     0.168 ns |         - |
| Encrypt · AES-128-GCM (OS)                            | 128B         |     119.13 ns |     0.247 ns |     0.206 ns |         - |
| Encrypt · AES-128-GCM (CryptoHives-Scalar)            | 128B         |     812.25 ns |     1.403 ns |     1.313 ns |         - |
| Encrypt · AES-128-GCM (BouncyCastle)                  | 128B         |     823.44 ns |     4.457 ns |     4.169 ns |    1608 B |
|                                                       |              |               |              |              |           |
| Decrypt · AES-128-GCM (CryptoHives-AES-NI+PClMul)     | 152B         |     124.23 ns |     0.293 ns |     0.260 ns |         - |
| Decrypt · AES-128-GCM (CryptoHives-AES-NI+PClMulV256) | 152B         |     129.68 ns |     0.308 ns |     0.258 ns |         - |
| Decrypt · AES-128-GCM (OS)                            | 152B         |     138.24 ns |     0.465 ns |     0.363 ns |         - |
| Decrypt · AES-128-GCM (CryptoHives-Scalar)            | 152B         |   1,027.69 ns |     1.986 ns |     1.858 ns |         - |
| Decrypt · AES-128-GCM (BouncyCastle)                  | 152B         |   1,042.76 ns |     1.850 ns |     1.640 ns |    1624 B |
|                                                       |              |               |              |              |           |
| Encrypt · AES-128-GCM (CryptoHives-AES-NI+PClMulV256) | 152B         |      90.11 ns |     0.179 ns |     0.140 ns |         - |
| Encrypt · AES-128-GCM (CryptoHives-AES-NI+PClMul)     | 152B         |      91.99 ns |     0.139 ns |     0.124 ns |         - |
| Encrypt · AES-128-GCM (OS)                            | 152B         |     137.48 ns |     0.383 ns |     0.320 ns |         - |
| Encrypt · AES-128-GCM (BouncyCastle)                  | 152B         |     940.85 ns |     3.121 ns |     2.920 ns |    1608 B |
| Encrypt · AES-128-GCM (CryptoHives-Scalar)            | 152B         |     983.02 ns |     1.625 ns |     1.520 ns |         - |
|                                                       |              |               |              |              |           |
| Decrypt · AES-128-GCM (CryptoHives-AES-NI+PClMulV256) | 256B         |     111.71 ns |     0.183 ns |     0.162 ns |         - |
| Decrypt · AES-128-GCM (CryptoHives-AES-NI+PClMul)     | 256B         |     123.01 ns |     0.290 ns |     0.242 ns |         - |
| Decrypt · AES-128-GCM (OS)                            | 256B         |     131.11 ns |     0.162 ns |     0.136 ns |         - |
| Decrypt · AES-128-GCM (BouncyCastle)                  | 256B         |   1,310.09 ns |     3.564 ns |     3.159 ns |    1624 B |
| Decrypt · AES-128-GCM (CryptoHives-Scalar)            | 256B         |   1,498.95 ns |     5.014 ns |     4.445 ns |         - |
|                                                       |              |               |              |              |           |
| Encrypt · AES-128-GCM (CryptoHives-AES-NI+PClMulV256) | 256B         |      77.05 ns |     0.111 ns |     0.098 ns |         - |
| Encrypt · AES-128-GCM (CryptoHives-AES-NI+PClMul)     | 256B         |      81.65 ns |     0.240 ns |     0.225 ns |         - |
| Encrypt · AES-128-GCM (OS)                            | 256B         |     132.90 ns |     0.221 ns |     0.207 ns |         - |
| Encrypt · AES-128-GCM (BouncyCastle)                  | 256B         |   1,222.44 ns |     2.941 ns |     2.296 ns |    1608 B |
| Encrypt · AES-128-GCM (CryptoHives-Scalar)            | 256B         |   1,476.89 ns |     7.364 ns |     6.150 ns |         - |
|                                                       |              |               |              |              |           |
| Decrypt · AES-128-GCM (OS)                            | 1KB          |     180.32 ns |     0.367 ns |     0.306 ns |         - |
| Decrypt · AES-128-GCM (CryptoHives-AES-NI+PClMulV256) | 1KB          |     201.31 ns |     0.248 ns |     0.232 ns |         - |
| Decrypt · AES-128-GCM (CryptoHives-AES-NI+PClMul)     | 1KB          |     244.63 ns |     0.513 ns |     0.455 ns |         - |
| Decrypt · AES-128-GCM (BouncyCastle)                  | 1KB          |   3,753.43 ns |     4.031 ns |     3.366 ns |    1624 B |
| Decrypt · AES-128-GCM (CryptoHives-Scalar)            | 1KB          |   5,444.19 ns |    18.118 ns |    16.061 ns |         - |
|                                                       |              |               |              |              |           |
| Encrypt · AES-128-GCM (OS)                            | 1KB          |     174.21 ns |     0.776 ns |     0.648 ns |         - |
| Encrypt · AES-128-GCM (CryptoHives-AES-NI+PClMulV256) | 1KB          |     177.52 ns |     0.364 ns |     0.340 ns |         - |
| Encrypt · AES-128-GCM (CryptoHives-AES-NI+PClMul)     | 1KB          |     200.05 ns |     0.225 ns |     0.176 ns |         - |
| Encrypt · AES-128-GCM (BouncyCastle)                  | 1KB          |   3,643.70 ns |     5.336 ns |     4.731 ns |    1608 B |
| Encrypt · AES-128-GCM (CryptoHives-Scalar)            | 1KB          |   5,434.36 ns |    11.437 ns |    10.139 ns |         - |
|                                                       |              |               |              |              |           |
| Decrypt · AES-128-GCM (OS)                            | 8KB          |     710.91 ns |     1.422 ns |     1.261 ns |         - |
| Decrypt · AES-128-GCM (CryptoHives-AES-NI+PClMulV256) | 8KB          |   1,042.15 ns |     8.076 ns |     6.744 ns |         - |
| Decrypt · AES-128-GCM (CryptoHives-AES-NI+PClMul)     | 8KB          |   1,391.93 ns |     4.956 ns |     4.636 ns |         - |
| Decrypt · AES-128-GCM (BouncyCastle)                  | 8KB          |  26,228.89 ns |    78.670 ns |    69.739 ns |    1624 B |
| Decrypt · AES-128-GCM (CryptoHives-Scalar)            | 8KB          |  42,211.55 ns |    79.233 ns |    70.238 ns |         - |
|                                                       |              |               |              |              |           |
| Encrypt · AES-128-GCM (OS)                            | 8KB          |     665.34 ns |     1.408 ns |     1.317 ns |         - |
| Encrypt · AES-128-GCM (CryptoHives-AES-NI+PClMulV256) | 8KB          |   1,107.08 ns |     3.038 ns |     2.841 ns |         - |
| Encrypt · AES-128-GCM (CryptoHives-AES-NI+PClMul)     | 8KB          |   1,320.55 ns |     3.013 ns |     2.671 ns |         - |
| Encrypt · AES-128-GCM (BouncyCastle)                  | 8KB          |  26,145.80 ns |    46.419 ns |    38.762 ns |    1608 B |
| Encrypt · AES-128-GCM (CryptoHives-Scalar)            | 8KB          |  42,389.81 ns |   108.949 ns |    96.580 ns |         - |
|                                                       |              |               |              |              |           |
| Decrypt · AES-128-GCM (OS)                            | 128KB        |  10,992.96 ns |    30.370 ns |    26.922 ns |         - |
| Decrypt · AES-128-GCM (CryptoHives-AES-NI+PClMulV256) | 128KB        |  16,706.54 ns |   277.474 ns |   259.549 ns |         - |
| Decrypt · AES-128-GCM (CryptoHives-AES-NI+PClMul)     | 128KB        |  20,981.58 ns |    96.822 ns |    80.851 ns |         - |
| Decrypt · AES-128-GCM (BouncyCastle)                  | 128KB        | 412,144.78 ns | 2,466.792 ns | 2,059.883 ns |    1624 B |
| Decrypt · AES-128-GCM (CryptoHives-Scalar)            | 128KB        | 675,487.64 ns | 1,941.587 ns | 1,816.162 ns |         - |
|                                                       |              |               |              |              |           |
| Encrypt · AES-128-GCM (OS)                            | 128KB        |   9,923.34 ns |    23.906 ns |    19.962 ns |         - |
| Encrypt · AES-128-GCM (CryptoHives-AES-NI+PClMulV256) | 128KB        |  17,252.79 ns |    49.831 ns |    38.905 ns |         - |
| Encrypt · AES-128-GCM (CryptoHives-AES-NI+PClMul)     | 128KB        |  20,531.69 ns |    51.475 ns |    42.984 ns |         - |
| Encrypt · AES-128-GCM (BouncyCastle)                  | 128KB        | 412,313.24 ns |   684.916 ns |   607.161 ns |    1608 B |
| Encrypt · AES-128-GCM (CryptoHives-Scalar)            | 128KB        | 676,873.40 ns |   954.153 ns |   845.832 ns |         - |