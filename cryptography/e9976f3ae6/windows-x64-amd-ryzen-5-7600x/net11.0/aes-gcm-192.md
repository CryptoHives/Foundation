| Description                                           | TestDataSize | Mean          | Error        | StdDev       | Code Size | Allocated |
|------------------------------------------------------ |------------- |--------------:|-------------:|-------------:|----------:|----------:|
| Decrypt · AES-192-GCM (CryptoHives-AES-NI+PClMulV256) | 17B          |     117.89 ns |     0.253 ns |     0.237 ns |     306 B |         - |
| Decrypt · AES-192-GCM (CryptoHives-AES-NI+PClMul)     | 17B          |     118.68 ns |     0.134 ns |     0.112 ns |     306 B |         - |
| Decrypt · AES-192-GCM (OS)                            | 17B          |     139.48 ns |     0.281 ns |     0.235 ns |   2,361 B |         - |
| Decrypt · AES-192-GCM (CryptoHives-Scalar)            | 17B          |     392.24 ns |     0.650 ns |     0.543 ns |     306 B |         - |
| Decrypt · AES-192-GCM (BouncyCastle)                  | 17B          |     584.25 ns |     2.874 ns |     2.548 ns |     306 B |    1728 B |
|                                                       |              |               |              |              |           |           |
| Encrypt · AES-192-GCM (CryptoHives-AES-NI+PClMul)     | 17B          |      77.77 ns |     0.113 ns |     0.101 ns |     386 B |         - |
| Encrypt · AES-192-GCM (CryptoHives-AES-NI+PClMulV256) | 17B          |      77.77 ns |     0.160 ns |     0.142 ns |     386 B |         - |
| Encrypt · AES-192-GCM (OS)                            | 17B          |     145.87 ns |     0.274 ns |     0.214 ns |   2,257 B |         - |
| Encrypt · AES-192-GCM (CryptoHives-Scalar)            | 17B          |     350.70 ns |     1.059 ns |     0.827 ns |     386 B |         - |
| Encrypt · AES-192-GCM (BouncyCastle)                  | 17B          |     518.17 ns |     0.916 ns |     0.715 ns |     386 B |    1712 B |
|                                                       |              |               |              |              |           |           |
| Decrypt · AES-192-GCM (CryptoHives-AES-NI+PClMul)     | 65B          |     119.59 ns |     0.463 ns |     0.386 ns |     306 B |         - |
| Decrypt · AES-192-GCM (CryptoHives-AES-NI+PClMulV256) | 65B          |     121.32 ns |     0.531 ns |     0.444 ns |     306 B |         - |
| Decrypt · AES-192-GCM (OS)                            | 65B          |     143.38 ns |     0.523 ns |     0.464 ns |   2,361 B |         - |
| Decrypt · AES-192-GCM (CryptoHives-Scalar)            | 65B          |     672.86 ns |     1.914 ns |     1.697 ns |     306 B |         - |
| Decrypt · AES-192-GCM (BouncyCastle)                  | 65B          |     805.77 ns |     6.008 ns |     5.620 ns |     306 B |    1728 B |
|                                                       |              |               |              |              |           |           |
| Encrypt · AES-192-GCM (CryptoHives-AES-NI+PClMul)     | 65B          |      87.04 ns |     0.174 ns |     0.163 ns |     386 B |         - |
| Encrypt · AES-192-GCM (CryptoHives-AES-NI+PClMulV256) | 65B          |      88.71 ns |     0.263 ns |     0.246 ns |     386 B |         - |
| Encrypt · AES-192-GCM (OS)                            | 65B          |     155.00 ns |     1.989 ns |     1.861 ns |   2,257 B |         - |
| Encrypt · AES-192-GCM (CryptoHives-Scalar)            | 65B          |     637.56 ns |     7.200 ns |     6.383 ns |     386 B |         - |
| Encrypt · AES-192-GCM (BouncyCastle)                  | 65B          |     711.09 ns |    13.321 ns |    12.460 ns |     386 B |    1712 B |
|                                                       |              |               |              |              |           |           |
| Decrypt · AES-192-GCM (CryptoHives-AES-NI+PClMul)     | 128B         |     122.63 ns |     0.291 ns |     0.243 ns |     306 B |         - |
| Decrypt · AES-192-GCM (CryptoHives-AES-NI+PClMulV256) | 128B         |     128.43 ns |     0.690 ns |     0.611 ns |     306 B |         - |
| Decrypt · AES-192-GCM (OS)                            | 128B         |     142.54 ns |     0.346 ns |     0.323 ns |   2,361 B |         - |
| Decrypt · AES-192-GCM (CryptoHives-Scalar)            | 128B         |     977.97 ns |    18.202 ns |    17.026 ns |     306 B |         - |
| Decrypt · AES-192-GCM (BouncyCastle)                  | 128B         |   1,018.28 ns |     4.600 ns |     4.078 ns |     306 B |    1728 B |
|                                                       |              |               |              |              |           |           |
| Encrypt · AES-192-GCM (CryptoHives-AES-NI+PClMulV256) | 128B         |      73.12 ns |     0.823 ns |     0.770 ns |     386 B |         - |
| Encrypt · AES-192-GCM (CryptoHives-AES-NI+PClMul)     | 128B         |      75.56 ns |     0.585 ns |     0.547 ns |     386 B |         - |
| Encrypt · AES-192-GCM (OS)                            | 128B         |     144.06 ns |     0.938 ns |     0.832 ns |   2,257 B |         - |
| Encrypt · AES-192-GCM (BouncyCastle)                  | 128B         |     885.39 ns |     9.206 ns |     8.611 ns |     386 B |    1712 B |
| Encrypt · AES-192-GCM (CryptoHives-Scalar)            | 128B         |     925.12 ns |     9.456 ns |     8.846 ns |     386 B |         - |
|                                                       |              |               |              |              |           |           |
| Decrypt · AES-192-GCM (CryptoHives-AES-NI+PClMul)     | 152B         |     142.47 ns |     0.440 ns |     0.368 ns |     306 B |         - |
| Decrypt · AES-192-GCM (CryptoHives-AES-NI+PClMulV256) | 152B         |     143.09 ns |     0.665 ns |     0.519 ns |     306 B |         - |
| Decrypt · AES-192-GCM (OS)                            | 152B         |     160.80 ns |     0.565 ns |     0.501 ns |   2,361 B |         - |
| Decrypt · AES-192-GCM (BouncyCastle)                  | 152B         |   1,127.43 ns |     7.189 ns |     6.372 ns |     306 B |    1728 B |
| Decrypt · AES-192-GCM (CryptoHives-Scalar)            | 152B         |   1,140.38 ns |     3.361 ns |     2.624 ns |     306 B |         - |
|                                                       |              |               |              |              |           |           |
| Encrypt · AES-192-GCM (CryptoHives-AES-NI+PClMulV256) | 152B         |     102.75 ns |     1.003 ns |     0.939 ns |     386 B |         - |
| Encrypt · AES-192-GCM (CryptoHives-AES-NI+PClMul)     | 152B         |     107.10 ns |     0.963 ns |     0.901 ns |     386 B |         - |
| Encrypt · AES-192-GCM (OS)                            | 152B         |     166.18 ns |     2.136 ns |     1.998 ns |   2,257 B |         - |
| Encrypt · AES-192-GCM (BouncyCastle)                  | 152B         |   1,039.40 ns |    14.878 ns |    13.917 ns |     386 B |    1712 B |
| Encrypt · AES-192-GCM (CryptoHives-Scalar)            | 152B         |   1,111.57 ns |    14.627 ns |    13.682 ns |     386 B |         - |
|                                                       |              |               |              |              |           |           |
| Decrypt · AES-192-GCM (CryptoHives-AES-NI+PClMulV256) | 256B         |     139.03 ns |     0.393 ns |     0.349 ns |     306 B |         - |
| Decrypt · AES-192-GCM (OS)                            | 256B         |     150.28 ns |     0.393 ns |     0.328 ns |   2,361 B |         - |
| Decrypt · AES-192-GCM (CryptoHives-AES-NI+PClMul)     | 256B         |     153.45 ns |     0.574 ns |     0.509 ns |     306 B |         - |
| Decrypt · AES-192-GCM (BouncyCastle)                  | 256B         |   1,457.73 ns |     4.985 ns |     4.663 ns |     306 B |    1728 B |
| Decrypt · AES-192-GCM (CryptoHives-Scalar)            | 256B         |   1,701.78 ns |     5.681 ns |     5.314 ns |     306 B |         - |
|                                                       |              |               |              |              |           |           |
| Encrypt · AES-192-GCM (CryptoHives-AES-NI+PClMulV256) | 256B         |      93.08 ns |     0.714 ns |     0.668 ns |     383 B |         - |
| Encrypt · AES-192-GCM (CryptoHives-AES-NI+PClMul)     | 256B         |      99.69 ns |     1.131 ns |     1.058 ns |     383 B |         - |
| Encrypt · AES-192-GCM (OS)                            | 256B         |     146.05 ns |     0.355 ns |     0.332 ns |   2,254 B |         - |
| Encrypt · AES-192-GCM (BouncyCastle)                  | 256B         |   1,358.31 ns |     6.757 ns |     6.320 ns |     383 B |    1712 B |
| Encrypt · AES-192-GCM (CryptoHives-Scalar)            | 256B         |   1,678.92 ns |    26.141 ns |    24.452 ns |     383 B |         - |
|                                                       |              |               |              |              |           |           |
| Decrypt · AES-192-GCM (OS)                            | 1KB          |     217.69 ns |     0.685 ns |     0.572 ns |   2,361 B |         - |
| Decrypt · AES-192-GCM (CryptoHives-AES-NI+PClMulV256) | 1KB          |     249.20 ns |     0.778 ns |     0.649 ns |     306 B |         - |
| Decrypt · AES-192-GCM (CryptoHives-AES-NI+PClMul)     | 1KB          |     304.98 ns |     1.875 ns |     1.662 ns |     306 B |         - |
| Decrypt · AES-192-GCM (BouncyCastle)                  | 1KB          |   4,330.33 ns |    20.050 ns |    17.773 ns |     306 B |    1728 B |
| Decrypt · AES-192-GCM (CryptoHives-Scalar)            | 1KB          |   6,162.68 ns |    36.870 ns |    32.684 ns |     306 B |         - |
|                                                       |              |               |              |              |           |           |
| Encrypt · AES-192-GCM (OS)                            | 1KB          |     204.46 ns |     0.378 ns |     0.316 ns |   2,257 B |         - |
| Encrypt · AES-192-GCM (CryptoHives-AES-NI+PClMulV256) | 1KB          |     217.71 ns |     0.842 ns |     0.746 ns |     386 B |         - |
| Encrypt · AES-192-GCM (CryptoHives-AES-NI+PClMul)     | 1KB          |     242.97 ns |     0.592 ns |     0.494 ns |     386 B |         - |
| Encrypt · AES-192-GCM (BouncyCastle)                  | 1KB          |   4,198.02 ns |    12.490 ns |    11.072 ns |     386 B |    1712 B |
| Encrypt · AES-192-GCM (CryptoHives-Scalar)            | 1KB          |   6,330.29 ns |    11.997 ns |    10.018 ns |     386 B |         - |
|                                                       |              |               |              |              |           |           |
| Decrypt · AES-192-GCM (OS)                            | 8KB          |     867.87 ns |     1.229 ns |     0.960 ns |   2,361 B |         - |
| Decrypt · AES-192-GCM (CryptoHives-AES-NI+PClMulV256) | 8KB          |   1,277.72 ns |     5.004 ns |     4.680 ns |     306 B |         - |
| Decrypt · AES-192-GCM (CryptoHives-AES-NI+PClMul)     | 8KB          |   1,711.40 ns |     2.734 ns |     2.283 ns |     306 B |         - |
| Decrypt · AES-192-GCM (BouncyCastle)                  | 8KB          |  31,420.43 ns |   495.846 ns |   439.555 ns |     306 B |    1728 B |
| Decrypt · AES-192-GCM (CryptoHives-Scalar)            | 8KB          |  47,659.85 ns |   130.755 ns |   109.187 ns |     306 B |         - |
|                                                       |              |               |              |              |           |           |
| Encrypt · AES-192-GCM (OS)                            | 8KB          |     804.01 ns |     3.890 ns |     3.448 ns |   2,257 B |         - |
| Encrypt · AES-192-GCM (CryptoHives-AES-NI+PClMulV256) | 8KB          |   1,391.05 ns |     3.589 ns |     3.357 ns |     386 B |         - |
| Encrypt · AES-192-GCM (CryptoHives-AES-NI+PClMul)     | 8KB          |   1,597.63 ns |     2.831 ns |     2.510 ns |     386 B |         - |
| Encrypt · AES-192-GCM (BouncyCastle)                  | 8KB          |  31,151.01 ns |   123.316 ns |   115.350 ns |     386 B |    1712 B |
| Encrypt · AES-192-GCM (CryptoHives-Scalar)            | 8KB          |  47,853.00 ns |   141.645 ns |   118.280 ns |     386 B |         - |
|                                                       |              |               |              |              |           |           |
| Decrypt · AES-192-GCM (OS)                            | 128KB        |  13,550.20 ns |    44.807 ns |    41.912 ns |   2,361 B |         - |
| Decrypt · AES-192-GCM (CryptoHives-AES-NI+PClMulV256) | 128KB        |  19,193.09 ns |   136.924 ns |   114.338 ns |     306 B |         - |
| Decrypt · AES-192-GCM (CryptoHives-AES-NI+PClMul)     | 128KB        |  25,744.79 ns |    44.994 ns |    37.572 ns |     306 B |         - |
| Decrypt · AES-192-GCM (BouncyCastle)                  | 128KB        | 492,635.34 ns | 2,148.215 ns | 1,793.857 ns |     306 B |    1728 B |
| Decrypt · AES-192-GCM (CryptoHives-Scalar)            | 128KB        | 771,532.02 ns | 2,711.918 ns | 2,264.574 ns |     306 B |         - |
|                                                       |              |               |              |              |           |           |
| Encrypt · AES-192-GCM (OS)                            | 128KB        |  11,852.41 ns |    34.744 ns |    30.800 ns |   2,257 B |         - |
| Encrypt · AES-192-GCM (CryptoHives-AES-NI+PClMulV256) | 128KB        |  21,592.02 ns |    54.031 ns |    45.118 ns |     386 B |         - |
| Encrypt · AES-192-GCM (CryptoHives-AES-NI+PClMul)     | 128KB        |  24,911.27 ns |   106.680 ns |    89.083 ns |     386 B |         - |
| Encrypt · AES-192-GCM (BouncyCastle)                  | 128KB        | 489,831.81 ns | 1,214.043 ns | 1,013.781 ns |     386 B |    1712 B |
| Encrypt · AES-192-GCM (CryptoHives-Scalar)            | 128KB        | 759,199.16 ns | 2,065.490 ns | 1,831.003 ns |     386 B |         - |