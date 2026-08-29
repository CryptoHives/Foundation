| Description                                           | TestDataSize | Mean          | Error         | StdDev        | Median        | Allocated |
|------------------------------------------------------ |------------- |--------------:|--------------:|--------------:|--------------:|----------:|
| Decrypt · AES-192-GCM (CryptoHives-AES-NI+PClMulV256) | 17B          |     121.96 ns |      2.419 ns |      3.391 ns |     120.92 ns |         - |
| Decrypt · AES-192-GCM (CryptoHives-AES-NI+PClMul)     | 17B          |     122.06 ns |      2.081 ns |      1.947 ns |     121.39 ns |         - |
| Decrypt · AES-192-GCM (OS)                            | 17B          |     123.31 ns |      1.541 ns |      1.287 ns |     122.77 ns |         - |
| Decrypt · AES-192-GCM (CryptoHives-Scalar)            | 17B          |     375.38 ns |      4.651 ns |      3.884 ns |     374.56 ns |         - |
| Decrypt · AES-192-GCM (BouncyCastle)                  | 17B          |     559.15 ns |      9.034 ns |      8.451 ns |     559.00 ns |    1728 B |
|                                                       |              |               |               |               |               |           |
| Encrypt · AES-192-GCM (CryptoHives-AES-NI+PClMul)     | 17B          |      74.59 ns |      1.070 ns |      0.949 ns |      74.45 ns |         - |
| Encrypt · AES-192-GCM (CryptoHives-AES-NI+PClMulV256) | 17B          |      75.43 ns |      1.142 ns |      1.068 ns |      75.30 ns |         - |
| Encrypt · AES-192-GCM (OS)                            | 17B          |     132.72 ns |      2.609 ns |      3.393 ns |     132.52 ns |         - |
| Encrypt · AES-192-GCM (CryptoHives-Scalar)            | 17B          |     337.76 ns |      6.765 ns |     10.924 ns |     334.42 ns |         - |
| Encrypt · AES-192-GCM (BouncyCastle)                  | 17B          |     515.14 ns |     10.277 ns |     15.694 ns |     511.24 ns |    1712 B |
|                                                       |              |               |               |               |               |           |
| Decrypt · AES-192-GCM (CryptoHives-AES-NI+PClMul)     | 65B          |     107.75 ns |      0.849 ns |      0.795 ns |     107.90 ns |         - |
| Decrypt · AES-192-GCM (CryptoHives-AES-NI+PClMulV256) | 65B          |     117.15 ns |      1.358 ns |      1.270 ns |     116.75 ns |         - |
| Decrypt · AES-192-GCM (OS)                            | 65B          |     128.12 ns |      2.581 ns |      2.650 ns |     127.47 ns |         - |
| Decrypt · AES-192-GCM (CryptoHives-Scalar)            | 65B          |     622.21 ns |     10.097 ns |      8.951 ns |     618.70 ns |         - |
| Decrypt · AES-192-GCM (BouncyCastle)                  | 65B          |     782.43 ns |     15.403 ns |     28.550 ns |     777.03 ns |    1728 B |
|                                                       |              |               |               |               |               |           |
| Encrypt · AES-192-GCM (CryptoHives-AES-NI+PClMulV256) | 65B          |      78.86 ns |      0.671 ns |      0.560 ns |      78.82 ns |         - |
| Encrypt · AES-192-GCM (CryptoHives-AES-NI+PClMul)     | 65B          |      81.09 ns |      1.628 ns |      2.228 ns |      80.73 ns |         - |
| Encrypt · AES-192-GCM (OS)                            | 65B          |     133.76 ns |      1.924 ns |      1.800 ns |     133.24 ns |         - |
| Encrypt · AES-192-GCM (CryptoHives-Scalar)            | 65B          |     602.60 ns |     10.820 ns |     14.810 ns |     599.58 ns |         - |
| Encrypt · AES-192-GCM (BouncyCastle)                  | 65B          |     697.81 ns |      8.386 ns |      7.434 ns |     696.20 ns |    1712 B |
|                                                       |              |               |               |               |               |           |
| Decrypt · AES-192-GCM (CryptoHives-AES-NI+PClMulV256) | 128B         |     100.17 ns |      1.932 ns |      1.898 ns |      99.60 ns |         - |
| Decrypt · AES-192-GCM (CryptoHives-AES-NI+PClMul)     | 128B         |     101.23 ns |      1.788 ns |      1.673 ns |     101.50 ns |         - |
| Decrypt · AES-192-GCM (OS)                            | 128B         |     125.21 ns |      1.496 ns |      1.399 ns |     125.13 ns |         - |
| Decrypt · AES-192-GCM (CryptoHives-Scalar)            | 128B         |     876.42 ns |      6.881 ns |      6.436 ns |     879.43 ns |         - |
| Decrypt · AES-192-GCM (BouncyCastle)                  | 128B         |     932.44 ns |      7.152 ns |      6.340 ns |     933.84 ns |    1728 B |
|                                                       |              |               |               |               |               |           |
| Encrypt · AES-192-GCM (CryptoHives-AES-NI+PClMulV256) | 128B         |      64.87 ns |      0.898 ns |      0.840 ns |      64.87 ns |         - |
| Encrypt · AES-192-GCM (CryptoHives-AES-NI+PClMul)     | 128B         |      67.56 ns |      0.973 ns |      0.910 ns |      67.48 ns |         - |
| Encrypt · AES-192-GCM (OS)                            | 128B         |     126.91 ns |      1.499 ns |      1.328 ns |     126.58 ns |         - |
| Encrypt · AES-192-GCM (BouncyCastle)                  | 128B         |     841.71 ns |      7.655 ns |      6.786 ns |     839.25 ns |    1712 B |
| Encrypt · AES-192-GCM (CryptoHives-Scalar)            | 128B         |     852.78 ns |      7.573 ns |      6.324 ns |     850.16 ns |         - |
|                                                       |              |               |               |               |               |           |
| Decrypt · AES-192-GCM (CryptoHives-AES-NI+PClMul)     | 152B         |     127.56 ns |      1.811 ns |      1.694 ns |     126.93 ns |         - |
| Decrypt · AES-192-GCM (CryptoHives-AES-NI+PClMulV256) | 152B         |     127.91 ns |      1.701 ns |      1.591 ns |     127.21 ns |         - |
| Decrypt · AES-192-GCM (OS)                            | 152B         |     140.80 ns |      1.355 ns |      1.132 ns |     140.56 ns |         - |
| Decrypt · AES-192-GCM (CryptoHives-Scalar)            | 152B         |   1,098.83 ns |     12.471 ns |     11.665 ns |   1,098.04 ns |         - |
| Decrypt · AES-192-GCM (BouncyCastle)                  | 152B         |   1,099.20 ns |     13.367 ns |     13.128 ns |   1,096.02 ns |    1728 B |
|                                                       |              |               |               |               |               |           |
| Encrypt · AES-192-GCM (CryptoHives-AES-NI+PClMul)     | 152B         |     100.63 ns |      0.741 ns |      0.693 ns |     100.74 ns |         - |
| Encrypt · AES-192-GCM (CryptoHives-AES-NI+PClMulV256) | 152B         |     102.20 ns |      1.684 ns |      1.653 ns |     102.08 ns |         - |
| Encrypt · AES-192-GCM (OS)                            | 152B         |     148.23 ns |      2.135 ns |      2.193 ns |     147.62 ns |         - |
| Encrypt · AES-192-GCM (BouncyCastle)                  | 152B         |     987.16 ns |     19.216 ns |     17.974 ns |     981.08 ns |    1712 B |
| Encrypt · AES-192-GCM (CryptoHives-Scalar)            | 152B         |   1,049.89 ns |     18.401 ns |     17.212 ns |   1,048.60 ns |         - |
|                                                       |              |               |               |               |               |           |
| Decrypt · AES-192-GCM (CryptoHives-AES-NI+PClMulV256) | 256B         |     115.38 ns |      2.235 ns |      2.090 ns |     114.84 ns |         - |
| Decrypt · AES-192-GCM (CryptoHives-AES-NI+PClMul)     | 256B         |     130.37 ns |      2.363 ns |      2.210 ns |     129.74 ns |         - |
| Decrypt · AES-192-GCM (OS)                            | 256B         |     133.78 ns |      1.610 ns |      1.581 ns |     133.52 ns |         - |
| Decrypt · AES-192-GCM (BouncyCastle)                  | 256B         |   1,413.50 ns |     15.482 ns |     14.482 ns |   1,414.26 ns |    1728 B |
| Decrypt · AES-192-GCM (CryptoHives-Scalar)            | 256B         |   1,569.49 ns |     18.061 ns |     16.894 ns |   1,566.56 ns |         - |
|                                                       |              |               |               |               |               |           |
| Encrypt · AES-192-GCM (CryptoHives-AES-NI+PClMulV256) | 256B         |      84.02 ns |      1.091 ns |      1.020 ns |      83.74 ns |         - |
| Encrypt · AES-192-GCM (CryptoHives-AES-NI+PClMul)     | 256B         |      89.03 ns |      1.344 ns |      1.191 ns |      88.71 ns |         - |
| Encrypt · AES-192-GCM (OS)                            | 256B         |     134.85 ns |      1.663 ns |      1.474 ns |     134.47 ns |         - |
| Encrypt · AES-192-GCM (BouncyCastle)                  | 256B         |   1,364.25 ns |     21.336 ns |     20.955 ns |   1,356.19 ns |    1712 B |
| Encrypt · AES-192-GCM (CryptoHives-Scalar)            | 256B         |   1,624.61 ns |     19.992 ns |     17.723 ns |   1,620.17 ns |         - |
|                                                       |              |               |               |               |               |           |
| Decrypt · AES-192-GCM (OS)                            | 1KB          |     194.20 ns |      1.080 ns |      0.958 ns |     193.93 ns |         - |
| Decrypt · AES-192-GCM (CryptoHives-AES-NI+PClMulV256) | 1KB          |     210.92 ns |      1.878 ns |      1.665 ns |     210.67 ns |         - |
| Decrypt · AES-192-GCM (CryptoHives-AES-NI+PClMul)     | 1KB          |     261.49 ns |      5.128 ns |      4.797 ns |     258.92 ns |         - |
| Decrypt · AES-192-GCM (BouncyCastle)                  | 1KB          |   4,257.92 ns |     71.824 ns |     67.185 ns |   4,232.21 ns |    1728 B |
| Decrypt · AES-192-GCM (CryptoHives-Scalar)            | 1KB          |   5,774.47 ns |     57.956 ns |     54.212 ns |   5,761.58 ns |         - |
|                                                       |              |               |               |               |               |           |
| Encrypt · AES-192-GCM (OS)                            | 1KB          |     192.25 ns |      1.789 ns |      1.586 ns |     191.68 ns |         - |
| Encrypt · AES-192-GCM (CryptoHives-AES-NI+PClMulV256) | 1KB          |     196.99 ns |      2.883 ns |      2.555 ns |     196.75 ns |         - |
| Encrypt · AES-192-GCM (CryptoHives-AES-NI+PClMul)     | 1KB          |     217.72 ns |      3.442 ns |      2.874 ns |     218.63 ns |         - |
| Encrypt · AES-192-GCM (BouncyCastle)                  | 1KB          |   4,201.39 ns |     66.664 ns |     62.357 ns |   4,178.67 ns |    1712 B |
| Encrypt · AES-192-GCM (CryptoHives-Scalar)            | 1KB          |   5,786.90 ns |    112.685 ns |    120.572 ns |   5,741.50 ns |         - |
|                                                       |              |               |               |               |               |           |
| Decrypt · AES-192-GCM (OS)                            | 8KB          |     812.63 ns |     13.616 ns |     12.736 ns |     809.22 ns |         - |
| Decrypt · AES-192-GCM (CryptoHives-AES-NI+PClMulV256) | 8KB          |   1,098.23 ns |     18.327 ns |     16.246 ns |   1,092.45 ns |         - |
| Decrypt · AES-192-GCM (CryptoHives-AES-NI+PClMul)     | 8KB          |   1,494.51 ns |     28.025 ns |     27.524 ns |   1,493.55 ns |         - |
| Decrypt · AES-192-GCM (BouncyCastle)                  | 8KB          |  30,575.42 ns |    491.847 ns |    384.002 ns |  30,449.96 ns |    1728 B |
| Decrypt · AES-192-GCM (CryptoHives-Scalar)            | 8KB          |  46,450.06 ns |    598.984 ns |    560.290 ns |  46,244.40 ns |         - |
|                                                       |              |               |               |               |               |           |
| Encrypt · AES-192-GCM (OS)                            | 8KB          |     723.63 ns |     12.876 ns |     12.044 ns |     723.46 ns |         - |
| Encrypt · AES-192-GCM (CryptoHives-AES-NI+PClMulV256) | 8KB          |   1,268.66 ns |     23.779 ns |     22.243 ns |   1,265.64 ns |         - |
| Encrypt · AES-192-GCM (CryptoHives-AES-NI+PClMul)     | 8KB          |   1,439.69 ns |     28.060 ns |     42.850 ns |   1,428.27 ns |         - |
| Encrypt · AES-192-GCM (BouncyCastle)                  | 8KB          |  31,100.32 ns |    613.447 ns |    573.819 ns |  30,917.21 ns |    1712 B |
| Encrypt · AES-192-GCM (CryptoHives-Scalar)            | 8KB          |  44,633.53 ns |    348.700 ns |    309.114 ns |  44,615.14 ns |         - |
|                                                       |              |               |               |               |               |           |
| Decrypt · AES-192-GCM (OS)                            | 128KB        |  11,946.66 ns |     97.061 ns |     90.791 ns |  11,946.36 ns |         - |
| Decrypt · AES-192-GCM (CryptoHives-AES-NI+PClMulV256) | 128KB        |  16,864.63 ns |    160.323 ns |    142.122 ns |  16,849.75 ns |         - |
| Decrypt · AES-192-GCM (CryptoHives-AES-NI+PClMul)     | 128KB        |  22,926.92 ns |    308.883 ns |    288.929 ns |  22,957.66 ns |         - |
| Decrypt · AES-192-GCM (BouncyCastle)                  | 128KB        | 484,579.18 ns |  5,971.225 ns |  5,585.487 ns | 483,952.32 ns |    1728 B |
| Decrypt · AES-192-GCM (CryptoHives-Scalar)            | 128KB        | 714,044.42 ns | 12,049.015 ns | 10,681.138 ns | 713,452.44 ns |         - |
|                                                       |              |               |               |               |               |           |
| Encrypt · AES-192-GCM (OS)                            | 128KB        |  10,900.58 ns |    193.115 ns |    180.640 ns |  10,866.56 ns |         - |
| Encrypt · AES-192-GCM (CryptoHives-AES-NI+PClMulV256) | 128KB        |  20,150.81 ns |    386.746 ns |    516.295 ns |  20,136.24 ns |         - |
| Encrypt · AES-192-GCM (CryptoHives-AES-NI+PClMul)     | 128KB        |  22,205.82 ns |    330.334 ns |    308.995 ns |  22,088.65 ns |         - |
| Encrypt · AES-192-GCM (BouncyCastle)                  | 128KB        | 489,300.71 ns |  9,457.667 ns |  7,383.924 ns | 490,544.51 ns |    1712 B |
| Encrypt · AES-192-GCM (CryptoHives-Scalar)            | 128KB        | 727,463.84 ns | 14,341.681 ns | 21,465.955 ns | 716,571.68 ns |         - |