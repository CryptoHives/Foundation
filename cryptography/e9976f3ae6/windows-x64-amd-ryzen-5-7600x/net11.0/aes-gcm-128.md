| Description                                           | TestDataSize | Mean          | Error        | StdDev       | Code Size | Allocated |
|------------------------------------------------------ |------------- |--------------:|-------------:|-------------:|----------:|----------:|
| Decrypt · AES-128-GCM (CryptoHives-AES-NI+PClMul)     | 17B          |     115.23 ns |     0.150 ns |     0.125 ns |     306 B |         - |
| Decrypt · AES-128-GCM (CryptoHives-AES-NI+PClMulV256) | 17B          |     115.57 ns |     0.407 ns |     0.381 ns |     306 B |         - |
| Decrypt · AES-128-GCM (OS)                            | 17B          |     135.72 ns |     0.411 ns |     0.364 ns |   2,361 B |         - |
| Decrypt · AES-128-GCM (CryptoHives-Scalar)            | 17B          |     375.54 ns |     1.083 ns |     0.960 ns |     306 B |         - |
| Decrypt · AES-128-GCM (BouncyCastle)                  | 17B          |     563.40 ns |     3.069 ns |     2.396 ns |     306 B |    1624 B |
|                                                       |              |               |              |              |           |           |
| Encrypt · AES-128-GCM (CryptoHives-AES-NI+PClMulV256) | 17B          |      74.94 ns |     0.686 ns |     0.641 ns |     386 B |         - |
| Encrypt · AES-128-GCM (CryptoHives-AES-NI+PClMul)     | 17B          |      79.34 ns |     0.323 ns |     0.302 ns |     386 B |         - |
| Encrypt · AES-128-GCM (OS)                            | 17B          |     145.77 ns |     1.646 ns |     1.539 ns |   2,257 B |         - |
| Encrypt · AES-128-GCM (CryptoHives-Scalar)            | 17B          |     334.45 ns |     3.856 ns |     3.607 ns |     386 B |         - |
| Encrypt · AES-128-GCM (BouncyCastle)                  | 17B          |     477.06 ns |     5.878 ns |     5.498 ns |     386 B |    1608 B |
|                                                       |              |               |              |              |           |           |
| Decrypt · AES-128-GCM (CryptoHives-AES-NI+PClMulV256) | 65B          |     114.51 ns |     0.360 ns |     0.319 ns |     306 B |         - |
| Decrypt · AES-128-GCM (CryptoHives-AES-NI+PClMul)     | 65B          |     117.09 ns |     0.189 ns |     0.167 ns |     306 B |         - |
| Decrypt · AES-128-GCM (OS)                            | 65B          |     144.54 ns |     1.715 ns |     1.604 ns |   2,361 B |         - |
| Decrypt · AES-128-GCM (CryptoHives-Scalar)            | 65B          |     639.68 ns |     2.136 ns |     1.893 ns |     306 B |         - |
| Decrypt · AES-128-GCM (BouncyCastle)                  | 65B          |     795.57 ns |    12.865 ns |    12.034 ns |     306 B |    1624 B |
|                                                       |              |               |              |              |           |           |
| Encrypt · AES-128-GCM (CryptoHives-AES-NI+PClMul)     | 65B          |      81.11 ns |     0.707 ns |     0.661 ns |     386 B |         - |
| Encrypt · AES-128-GCM (CryptoHives-AES-NI+PClMulV256) | 65B          |      82.04 ns |     0.703 ns |     0.658 ns |     386 B |         - |
| Encrypt · AES-128-GCM (OS)                            | 65B          |     149.10 ns |     1.097 ns |     1.026 ns |   2,257 B |         - |
| Encrypt · AES-128-GCM (CryptoHives-Scalar)            | 65B          |     606.63 ns |     7.308 ns |     6.836 ns |     386 B |         - |
| Encrypt · AES-128-GCM (BouncyCastle)                  | 65B          |     638.76 ns |    11.539 ns |    10.793 ns |     386 B |    1608 B |
|                                                       |              |               |              |              |           |           |
| Decrypt · AES-128-GCM (CryptoHives-AES-NI+PClMul)     | 128B         |     116.84 ns |     0.164 ns |     0.128 ns |     306 B |         - |
| Decrypt · AES-128-GCM (CryptoHives-AES-NI+PClMulV256) | 128B         |     121.70 ns |     0.447 ns |     0.396 ns |     306 B |         - |
| Decrypt · AES-128-GCM (OS)                            | 128B         |     138.93 ns |     1.096 ns |     0.856 ns |   2,361 B |         - |
| Decrypt · AES-128-GCM (BouncyCastle)                  | 128B         |     877.86 ns |     7.743 ns |     7.243 ns |     306 B |    1624 B |
| Decrypt · AES-128-GCM (CryptoHives-Scalar)            | 128B         |     895.11 ns |     4.826 ns |     4.278 ns |     306 B |         - |
|                                                       |              |               |              |              |           |           |
| Encrypt · AES-128-GCM (CryptoHives-AES-NI+PClMulV256) | 128B         |      69.47 ns |     0.434 ns |     0.406 ns |     386 B |         - |
| Encrypt · AES-128-GCM (CryptoHives-AES-NI+PClMul)     | 128B         |      70.61 ns |     0.686 ns |     0.641 ns |     386 B |         - |
| Encrypt · AES-128-GCM (OS)                            | 128B         |     139.62 ns |     1.262 ns |     1.118 ns |   2,257 B |         - |
| Encrypt · AES-128-GCM (BouncyCastle)                  | 128B         |     782.16 ns |    11.668 ns |    10.915 ns |     386 B |    1608 B |
| Encrypt · AES-128-GCM (CryptoHives-Scalar)            | 128B         |     862.89 ns |    11.890 ns |    10.540 ns |     386 B |         - |
|                                                       |              |               |              |              |           |           |
| Decrypt · AES-128-GCM (CryptoHives-AES-NI+PClMul)     | 152B         |     137.02 ns |     0.331 ns |     0.258 ns |     306 B |         - |
| Decrypt · AES-128-GCM (CryptoHives-AES-NI+PClMulV256) | 152B         |     138.02 ns |     0.805 ns |     0.714 ns |     306 B |         - |
| Decrypt · AES-128-GCM (OS)                            | 152B         |     159.97 ns |     0.299 ns |     0.265 ns |   2,361 B |         - |
| Decrypt · AES-128-GCM (BouncyCastle)                  | 152B         |   1,004.15 ns |     4.036 ns |     3.578 ns |     306 B |    1624 B |
| Decrypt · AES-128-GCM (CryptoHives-Scalar)            | 152B         |   1,062.10 ns |     2.225 ns |     1.858 ns |     306 B |         - |
|                                                       |              |               |              |              |           |           |
| Encrypt · AES-128-GCM (CryptoHives-AES-NI+PClMulV256) | 152B         |      95.56 ns |     0.399 ns |     0.333 ns |     386 B |         - |
| Encrypt · AES-128-GCM (CryptoHives-AES-NI+PClMul)     | 152B         |      98.48 ns |     0.998 ns |     0.934 ns |     386 B |         - |
| Encrypt · AES-128-GCM (OS)                            | 152B         |     159.75 ns |     2.160 ns |     2.021 ns |   2,257 B |         - |
| Encrypt · AES-128-GCM (BouncyCastle)                  | 152B         |     911.78 ns |    10.665 ns |     9.454 ns |     386 B |    1608 B |
| Encrypt · AES-128-GCM (CryptoHives-Scalar)            | 152B         |   1,061.99 ns |    11.453 ns |    10.713 ns |     386 B |         - |
|                                                       |              |               |              |              |           |           |
| Decrypt · AES-128-GCM (CryptoHives-AES-NI+PClMulV256) | 256B         |     136.29 ns |     0.467 ns |     0.414 ns |     306 B |         - |
| Decrypt · AES-128-GCM (OS)                            | 256B         |     147.41 ns |     0.607 ns |     0.507 ns |   2,361 B |         - |
| Decrypt · AES-128-GCM (CryptoHives-AES-NI+PClMul)     | 256B         |     152.81 ns |     0.882 ns |     0.782 ns |     306 B |         - |
| Decrypt · AES-128-GCM (BouncyCastle)                  | 256B         |   1,282.69 ns |     3.821 ns |     3.387 ns |     306 B |    1624 B |
| Decrypt · AES-128-GCM (CryptoHives-Scalar)            | 256B         |   1,590.08 ns |     9.356 ns |     8.294 ns |     306 B |         - |
|                                                       |              |               |              |              |           |           |
| Encrypt · AES-128-GCM (CryptoHives-AES-NI+PClMulV256) | 256B         |      87.58 ns |     0.918 ns |     0.859 ns |     383 B |         - |
| Encrypt · AES-128-GCM (CryptoHives-AES-NI+PClMul)     | 256B         |      92.65 ns |     0.742 ns |     0.694 ns |     383 B |         - |
| Encrypt · AES-128-GCM (OS)                            | 256B         |     144.90 ns |     1.904 ns |     1.781 ns |   2,254 B |         - |
| Encrypt · AES-128-GCM (BouncyCastle)                  | 256B         |   1,220.92 ns |    19.153 ns |    16.978 ns |     383 B |    1608 B |
| Encrypt · AES-128-GCM (CryptoHives-Scalar)            | 256B         |   1,563.09 ns |    16.899 ns |    15.807 ns |     383 B |         - |
|                                                       |              |               |              |              |           |           |
| Decrypt · AES-128-GCM (OS)                            | 1KB          |     208.38 ns |     0.543 ns |     0.482 ns |   2,361 B |         - |
| Decrypt · AES-128-GCM (CryptoHives-AES-NI+PClMulV256) | 1KB          |     239.46 ns |     1.272 ns |     1.128 ns |     306 B |         - |
| Decrypt · AES-128-GCM (CryptoHives-AES-NI+PClMul)     | 1KB          |     290.10 ns |     1.176 ns |     1.043 ns |     306 B |         - |
| Decrypt · AES-128-GCM (BouncyCastle)                  | 1KB          |   3,768.41 ns |    14.732 ns |    13.781 ns |     306 B |    1624 B |
| Decrypt · AES-128-GCM (CryptoHives-Scalar)            | 1KB          |   5,704.14 ns |    23.056 ns |    19.252 ns |     306 B |         - |
|                                                       |              |               |              |              |           |           |
| Encrypt · AES-128-GCM (OS)                            | 1KB          |     200.99 ns |     1.484 ns |     1.389 ns |   2,257 B |         - |
| Encrypt · AES-128-GCM (CryptoHives-AES-NI+PClMulV256) | 1KB          |     207.72 ns |     2.552 ns |     2.387 ns |     386 B |         - |
| Encrypt · AES-128-GCM (CryptoHives-AES-NI+PClMul)     | 1KB          |     237.16 ns |     1.865 ns |     1.653 ns |     386 B |         - |
| Encrypt · AES-128-GCM (BouncyCastle)                  | 1KB          |   3,748.93 ns |    30.410 ns |    25.393 ns |     386 B |    1608 B |
| Encrypt · AES-128-GCM (CryptoHives-Scalar)            | 1KB          |   5,749.56 ns |    85.731 ns |    80.193 ns |     386 B |         - |
|                                                       |              |               |              |              |           |           |
| Decrypt · AES-128-GCM (OS)                            | 8KB          |     817.53 ns |     1.024 ns |     0.800 ns |   2,361 B |         - |
| Decrypt · AES-128-GCM (CryptoHives-AES-NI+PClMulV256) | 8KB          |   1,182.96 ns |     5.256 ns |     4.389 ns |     306 B |         - |
| Decrypt · AES-128-GCM (CryptoHives-AES-NI+PClMul)     | 8KB          |   1,606.55 ns |     4.271 ns |     3.786 ns |     306 B |         - |
| Decrypt · AES-128-GCM (BouncyCastle)                  | 8KB          |  26,782.09 ns |    77.367 ns |    64.605 ns |     306 B |    1624 B |
| Decrypt · AES-128-GCM (CryptoHives-Scalar)            | 8KB          |  46,013.13 ns |   188.523 ns |   167.121 ns |     306 B |         - |
|                                                       |              |               |              |              |           |           |
| Encrypt · AES-128-GCM (OS)                            | 8KB          |     780.29 ns |     7.446 ns |     6.965 ns |   2,257 B |         - |
| Encrypt · AES-128-GCM (CryptoHives-AES-NI+PClMulV256) | 8KB          |   1,290.43 ns |    13.341 ns |    12.479 ns |     386 B |         - |
| Encrypt · AES-128-GCM (CryptoHives-AES-NI+PClMul)     | 8KB          |   1,545.84 ns |    17.229 ns |    16.116 ns |     386 B |         - |
| Encrypt · AES-128-GCM (BouncyCastle)                  | 8KB          |  27,169.55 ns |   355.388 ns |   332.430 ns |     386 B |    1608 B |
| Encrypt · AES-128-GCM (CryptoHives-Scalar)            | 8KB          |  45,840.42 ns |   557.280 ns |   521.280 ns |     386 B |         - |
|                                                       |              |               |              |              |           |           |
| Decrypt · AES-128-GCM (OS)                            | 128KB        |  12,442.35 ns |    39.750 ns |    35.237 ns |   2,361 B |         - |
| Decrypt · AES-128-GCM (CryptoHives-AES-NI+PClMulV256) | 128KB        |  18,309.70 ns |    39.708 ns |    33.158 ns |     306 B |         - |
| Decrypt · AES-128-GCM (CryptoHives-AES-NI+PClMul)     | 128KB        |  24,220.01 ns |    39.450 ns |    32.942 ns |     306 B |         - |
| Decrypt · AES-128-GCM (BouncyCastle)                  | 128KB        | 429,255.19 ns |   742.956 ns |   580.051 ns |     306 B |    1624 B |
| Decrypt · AES-128-GCM (CryptoHives-Scalar)            | 128KB        | 703,345.36 ns | 3,681.225 ns | 3,073.989 ns |     306 B |         - |
|                                                       |              |               |              |              |           |           |
| Encrypt · AES-128-GCM (OS)                            | 128KB        |  11,465.62 ns |    15.766 ns |    12.309 ns |   2,257 B |         - |
| Encrypt · AES-128-GCM (CryptoHives-AES-NI+PClMulV256) | 128KB        |  19,905.94 ns |   205.453 ns |   192.181 ns |     386 B |         - |
| Encrypt · AES-128-GCM (CryptoHives-AES-NI+PClMul)     | 128KB        |  24,209.39 ns |   251.148 ns |   234.924 ns |     386 B |         - |
| Encrypt · AES-128-GCM (BouncyCastle)                  | 128KB        | 426,945.78 ns | 1,181.793 ns | 1,105.450 ns |     386 B |    1608 B |
| Encrypt · AES-128-GCM (CryptoHives-Scalar)            | 128KB        | 702,118.56 ns | 1,683.030 ns | 1,405.406 ns |     386 B |         - |