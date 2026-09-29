| Description                                           | TestDataSize | Mean          | Error         | StdDev        | Allocated |
|------------------------------------------------------ |------------- |--------------:|--------------:|--------------:|----------:|
| Decrypt · AES-256-GCM (CryptoHives-AES-NI+PClMulV256) | 17B          |     113.12 ns |      0.754 ns |      0.668 ns |         - |
| Decrypt · AES-256-GCM (CryptoHives-AES-NI+PClMul)     | 17B          |     115.36 ns |      0.827 ns |      0.773 ns |         - |
| Decrypt · AES-256-GCM (OS)                            | 17B          |     144.66 ns |      1.619 ns |      1.514 ns |         - |
| Decrypt · AES-256-GCM (CryptoHives-Scalar)            | 17B          |     425.22 ns |      4.522 ns |      4.230 ns |         - |
| Decrypt · AES-256-GCM (BouncyCastle)                  | 17B          |     662.38 ns |      5.642 ns |      5.278 ns |    1832 B |
|                                                       |              |               |               |               |           |
| Encrypt · AES-256-GCM (CryptoHives-AES-NI+PClMulV256) | 17B          |      84.64 ns |      0.574 ns |      0.537 ns |         - |
| Encrypt · AES-256-GCM (CryptoHives-AES-NI+PClMul)     | 17B          |      84.89 ns |      0.695 ns |      0.650 ns |         - |
| Encrypt · AES-256-GCM (OS)                            | 17B          |     152.33 ns |      0.736 ns |      0.688 ns |         - |
| Encrypt · AES-256-GCM (CryptoHives-Scalar)            | 17B          |     390.07 ns |      3.882 ns |      3.631 ns |         - |
| Encrypt · AES-256-GCM (BouncyCastle)                  | 17B          |     596.34 ns |     11.370 ns |     10.635 ns |    1816 B |
|                                                       |              |               |               |               |           |
| Decrypt · AES-256-GCM (CryptoHives-AES-NI+PClMulV256) | 65B          |     116.33 ns |      1.037 ns |      0.970 ns |         - |
| Decrypt · AES-256-GCM (CryptoHives-AES-NI+PClMul)     | 65B          |     121.55 ns |      1.737 ns |      1.625 ns |         - |
| Decrypt · AES-256-GCM (OS)                            | 65B          |     150.20 ns |      1.628 ns |      1.522 ns |         - |
| Decrypt · AES-256-GCM (CryptoHives-Scalar)            | 65B          |     745.35 ns |     10.263 ns |      9.600 ns |         - |
| Decrypt · AES-256-GCM (BouncyCastle)                  | 65B          |     924.17 ns |     14.413 ns |     13.482 ns |    1832 B |
|                                                       |              |               |               |               |           |
| Encrypt · AES-256-GCM (CryptoHives-AES-NI+PClMul)     | 65B          |      94.01 ns |      0.796 ns |      0.745 ns |         - |
| Encrypt · AES-256-GCM (CryptoHives-AES-NI+PClMulV256) | 65B          |      95.05 ns |      0.770 ns |      0.720 ns |         - |
| Encrypt · AES-256-GCM (OS)                            | 65B          |     156.92 ns |      1.526 ns |      1.427 ns |         - |
| Encrypt · AES-256-GCM (CryptoHives-Scalar)            | 65B          |     711.26 ns |      6.928 ns |      6.141 ns |         - |
| Encrypt · AES-256-GCM (BouncyCastle)                  | 65B          |     819.10 ns |     12.568 ns |     11.756 ns |    1816 B |
|                                                       |              |               |               |               |           |
| Decrypt · AES-256-GCM (CryptoHives-AES-NI+PClMulV256) | 128B         |     117.08 ns |      1.409 ns |      1.318 ns |         - |
| Decrypt · AES-256-GCM (CryptoHives-AES-NI+PClMul)     | 128B         |     125.97 ns |      1.708 ns |      1.598 ns |         - |
| Decrypt · AES-256-GCM (OS)                            | 128B         |     145.15 ns |      1.727 ns |      1.616 ns |         - |
| Decrypt · AES-256-GCM (CryptoHives-Scalar)            | 128B         |   1,069.18 ns |      8.536 ns |      7.984 ns |         - |
| Decrypt · AES-256-GCM (BouncyCastle)                  | 128B         |   1,157.47 ns |     15.587 ns |     14.580 ns |    1832 B |
|                                                       |              |               |               |               |           |
| Encrypt · AES-256-GCM (CryptoHives-AES-NI+PClMulV256) | 128B         |      78.69 ns |      0.780 ns |      0.730 ns |         - |
| Encrypt · AES-256-GCM (CryptoHives-AES-NI+PClMul)     | 128B         |      82.46 ns |      0.583 ns |      0.545 ns |         - |
| Encrypt · AES-256-GCM (OS)                            | 128B         |     146.39 ns |      1.960 ns |      1.833 ns |         - |
| Encrypt · AES-256-GCM (CryptoHives-Scalar)            | 128B         |   1,025.17 ns |     14.908 ns |     13.945 ns |         - |
| Encrypt · AES-256-GCM (BouncyCastle)                  | 128B         |   1,042.26 ns |     17.244 ns |     16.130 ns |    1816 B |
|                                                       |              |               |               |               |           |
| Decrypt · AES-256-GCM (CryptoHives-AES-NI+PClMul)     | 152B         |     143.69 ns |      1.763 ns |      1.649 ns |         - |
| Decrypt · AES-256-GCM (CryptoHives-AES-NI+PClMulV256) | 152B         |     144.17 ns |      1.420 ns |      1.328 ns |         - |
| Decrypt · AES-256-GCM (OS)                            | 152B         |     167.94 ns |      2.323 ns |      2.059 ns |         - |
| Decrypt · AES-256-GCM (CryptoHives-Scalar)            | 152B         |   1,275.49 ns |     15.360 ns |     14.368 ns |         - |
| Decrypt · AES-256-GCM (BouncyCastle)                  | 152B         |   1,329.62 ns |     16.800 ns |     14.029 ns |    1832 B |
|                                                       |              |               |               |               |           |
| Encrypt · AES-256-GCM (CryptoHives-AES-NI+PClMulV256) | 152B         |     110.35 ns |      0.425 ns |      0.398 ns |         - |
| Encrypt · AES-256-GCM (CryptoHives-AES-NI+PClMul)     | 152B         |     111.72 ns |      1.241 ns |      1.161 ns |         - |
| Encrypt · AES-256-GCM (OS)                            | 152B         |     168.34 ns |      2.692 ns |      2.518 ns |         - |
| Encrypt · AES-256-GCM (BouncyCastle)                  | 152B         |   1,229.07 ns |     17.611 ns |     16.473 ns |    1816 B |
| Encrypt · AES-256-GCM (CryptoHives-Scalar)            | 152B         |   1,240.91 ns |     16.340 ns |     15.285 ns |         - |
|                                                       |              |               |               |               |           |
| Decrypt · AES-256-GCM (CryptoHives-AES-NI+PClMulV256) | 256B         |     137.08 ns |      1.911 ns |      1.788 ns |         - |
| Decrypt · AES-256-GCM (CryptoHives-AES-NI+PClMul)     | 256B         |     157.69 ns |      1.834 ns |      1.716 ns |         - |
| Decrypt · AES-256-GCM (OS)                            | 256B         |     161.42 ns |      1.772 ns |      1.657 ns |         - |
| Decrypt · AES-256-GCM (BouncyCastle)                  | 256B         |   1,773.07 ns |     27.945 ns |     26.140 ns |    1832 B |
| Decrypt · AES-256-GCM (CryptoHives-Scalar)            | 256B         |   1,917.72 ns |     21.530 ns |     20.139 ns |         - |
|                                                       |              |               |               |               |           |
| Encrypt · AES-256-GCM (CryptoHives-AES-NI+PClMulV256) | 256B         |     101.65 ns |      1.025 ns |      0.959 ns |         - |
| Encrypt · AES-256-GCM (CryptoHives-AES-NI+PClMul)     | 256B         |     108.13 ns |      1.179 ns |      1.103 ns |         - |
| Encrypt · AES-256-GCM (OS)                            | 256B         |     151.41 ns |      2.044 ns |      1.912 ns |         - |
| Encrypt · AES-256-GCM (BouncyCastle)                  | 256B         |   1,645.96 ns |     23.398 ns |     20.741 ns |    1816 B |
| Encrypt · AES-256-GCM (CryptoHives-Scalar)            | 256B         |   1,890.82 ns |     26.020 ns |     24.340 ns |         - |
|                                                       |              |               |               |               |           |
| Decrypt · AES-256-GCM (CryptoHives-AES-NI+PClMulV256) | 1KB          |     251.41 ns |      3.595 ns |      3.363 ns |         - |
| Decrypt · AES-256-GCM (OS)                            | 1KB          |     254.55 ns |      3.030 ns |      2.834 ns |         - |
| Decrypt · AES-256-GCM (CryptoHives-AES-NI+PClMul)     | 1KB          |     316.05 ns |      3.618 ns |      3.385 ns |         - |
| Decrypt · AES-256-GCM (BouncyCastle)                  | 1KB          |   5,449.36 ns |     32.118 ns |     30.043 ns |    1832 B |
| Decrypt · AES-256-GCM (CryptoHives-Scalar)            | 1KB          |   7,036.57 ns |     75.102 ns |     70.250 ns |         - |
|                                                       |              |               |               |               |           |
| Encrypt · AES-256-GCM (OS)                            | 1KB          |     216.32 ns |      2.552 ns |      2.387 ns |         - |
| Encrypt · AES-256-GCM (CryptoHives-AES-NI+PClMulV256) | 1KB          |     240.99 ns |      3.139 ns |      2.936 ns |         - |
| Encrypt · AES-256-GCM (CryptoHives-AES-NI+PClMul)     | 1KB          |     266.89 ns |      4.201 ns |      3.930 ns |         - |
| Encrypt · AES-256-GCM (BouncyCastle)                  | 1KB          |   5,299.30 ns |     56.604 ns |     52.947 ns |    1816 B |
| Encrypt · AES-256-GCM (CryptoHives-Scalar)            | 1KB          |   6,993.11 ns |    100.180 ns |     93.708 ns |         - |
|                                                       |              |               |               |               |           |
| Decrypt · AES-256-GCM (OS)                            | 8KB          |   1,128.22 ns |     11.668 ns |     10.914 ns |         - |
| Decrypt · AES-256-GCM (CryptoHives-AES-NI+PClMulV256) | 8KB          |   1,339.22 ns |     14.583 ns |     13.641 ns |         - |
| Decrypt · AES-256-GCM (CryptoHives-AES-NI+PClMul)     | 8KB          |   1,842.39 ns |     21.269 ns |     19.895 ns |         - |
| Decrypt · AES-256-GCM (BouncyCastle)                  | 8KB          |  39,564.32 ns |    396.008 ns |    370.427 ns |    1832 B |
| Decrypt · AES-256-GCM (CryptoHives-Scalar)            | 8KB          |  54,711.50 ns |    794.899 ns |    743.549 ns |         - |
|                                                       |              |               |               |               |           |
| Encrypt · AES-256-GCM (OS)                            | 8KB          |     855.09 ns |     12.579 ns |     11.766 ns |         - |
| Encrypt · AES-256-GCM (CryptoHives-AES-NI+PClMulV256) | 8KB          |   1,546.49 ns |     14.479 ns |     13.543 ns |         - |
| Encrypt · AES-256-GCM (CryptoHives-AES-NI+PClMul)     | 8KB          |   1,761.10 ns |     22.069 ns |     20.643 ns |         - |
| Encrypt · AES-256-GCM (BouncyCastle)                  | 8KB          |  39,299.98 ns |    394.492 ns |    369.008 ns |    1816 B |
| Encrypt · AES-256-GCM (CryptoHives-Scalar)            | 8KB          |  54,701.85 ns |    511.359 ns |    478.326 ns |         - |
|                                                       |              |               |               |               |           |
| Decrypt · AES-256-GCM (OS)                            | 128KB        |  17,135.53 ns |    166.294 ns |    155.552 ns |         - |
| Decrypt · AES-256-GCM (CryptoHives-AES-NI+PClMulV256) | 128KB        |  21,168.01 ns |    270.038 ns |    252.594 ns |         - |
| Decrypt · AES-256-GCM (CryptoHives-AES-NI+PClMul)     | 128KB        |  27,777.55 ns |    448.779 ns |    419.788 ns |         - |
| Decrypt · AES-256-GCM (BouncyCastle)                  | 128KB        | 628,439.66 ns |  6,886.169 ns |  6,441.327 ns |    1832 B |
| Decrypt · AES-256-GCM (CryptoHives-Scalar)            | 128KB        | 871,934.26 ns | 10,880.459 ns | 10,177.588 ns |         - |
|                                                       |              |               |               |               |           |
| Encrypt · AES-256-GCM (OS)                            | 128KB        |  12,500.14 ns |    180.957 ns |    169.267 ns |         - |
| Encrypt · AES-256-GCM (CryptoHives-AES-NI+PClMulV256) | 128KB        |  23,963.40 ns |    306.639 ns |    286.831 ns |         - |
| Encrypt · AES-256-GCM (CryptoHives-AES-NI+PClMul)     | 128KB        |  27,254.68 ns |    364.557 ns |    341.007 ns |         - |
| Encrypt · AES-256-GCM (BouncyCastle)                  | 128KB        | 624,115.13 ns |  7,988.387 ns |  7,472.342 ns |    1816 B |
| Encrypt · AES-256-GCM (CryptoHives-Scalar)            | 128KB        | 887,029.43 ns |  7,033.633 ns |  6,579.265 ns |         - |