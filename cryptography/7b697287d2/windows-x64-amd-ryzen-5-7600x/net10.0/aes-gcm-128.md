| Description                                           | TestDataSize | Mean          | Error        | StdDev       | Code Size | Allocated |
|------------------------------------------------------ |------------- |--------------:|-------------:|-------------:|----------:|----------:|
| Decrypt · AES-128-GCM (CryptoHives-AES-NI+PClMul)     | 17B          |     110.16 ns |     1.021 ns |     0.955 ns |     306 B |         - |
| Decrypt · AES-128-GCM (CryptoHives-AES-NI+PClMulV256) | 17B          |     115.30 ns |     1.029 ns |     0.963 ns |     306 B |         - |
| Decrypt · AES-128-GCM (OS)                            | 17B          |     136.26 ns |     1.911 ns |     1.787 ns |   2,230 B |         - |
| Decrypt · AES-128-GCM (CryptoHives-Scalar)            | 17B          |     380.39 ns |     2.738 ns |     2.287 ns |     306 B |         - |
| Decrypt · AES-128-GCM (BouncyCastle)                  | 17B          |     557.23 ns |    10.974 ns |    11.270 ns |     306 B |    1624 B |
|                                                       |              |               |              |              |           |           |
| Encrypt · AES-128-GCM (CryptoHives-AES-NI+PClMulV256) | 17B          |      72.06 ns |     0.546 ns |     0.511 ns |     383 B |         - |
| Encrypt · AES-128-GCM (CryptoHives-AES-NI+PClMul)     | 17B          |      73.23 ns |     0.879 ns |     0.822 ns |     383 B |         - |
| Encrypt · AES-128-GCM (OS)                            | 17B          |     139.74 ns |     1.994 ns |     1.865 ns |   2,202 B |         - |
| Encrypt · AES-128-GCM (CryptoHives-Scalar)            | 17B          |     334.13 ns |     4.481 ns |     4.191 ns |     386 B |         - |
| Encrypt · AES-128-GCM (BouncyCastle)                  | 17B          |     495.62 ns |     6.619 ns |     6.192 ns |     383 B |    1608 B |
|                                                       |              |               |              |              |           |           |
| Decrypt · AES-128-GCM (CryptoHives-AES-NI+PClMul)     | 65B          |     111.52 ns |     0.830 ns |     0.736 ns |     306 B |         - |
| Decrypt · AES-128-GCM (CryptoHives-AES-NI+PClMulV256) | 65B          |     117.08 ns |     1.218 ns |     1.139 ns |     306 B |         - |
| Decrypt · AES-128-GCM (OS)                            | 65B          |     139.90 ns |     1.926 ns |     1.801 ns |   2,230 B |         - |
| Decrypt · AES-128-GCM (CryptoHives-Scalar)            | 65B          |     639.97 ns |     4.967 ns |     4.403 ns |     306 B |         - |
| Decrypt · AES-128-GCM (BouncyCastle)                  | 65B          |     766.93 ns |    11.421 ns |    10.684 ns |     306 B |    1624 B |
|                                                       |              |               |              |              |           |           |
| Encrypt · AES-128-GCM (CryptoHives-AES-NI+PClMul)     | 65B          |      80.17 ns |     0.632 ns |     0.592 ns |     383 B |         - |
| Encrypt · AES-128-GCM (CryptoHives-AES-NI+PClMulV256) | 65B          |      81.27 ns |     0.985 ns |     0.921 ns |     383 B |         - |
| Encrypt · AES-128-GCM (OS)                            | 65B          |     146.01 ns |     1.311 ns |     1.226 ns |   2,202 B |         - |
| Encrypt · AES-128-GCM (CryptoHives-Scalar)            | 65B          |     604.50 ns |     7.145 ns |     6.683 ns |     386 B |         - |
| Encrypt · AES-128-GCM (BouncyCastle)                  | 65B          |     659.73 ns |    11.608 ns |    10.858 ns |     383 B |    1608 B |
|                                                       |              |               |              |              |           |           |
| Decrypt · AES-128-GCM (CryptoHives-AES-NI+PClMul)     | 128B         |     116.90 ns |     1.328 ns |     1.242 ns |     306 B |         - |
| Decrypt · AES-128-GCM (CryptoHives-AES-NI+PClMulV256) | 128B         |     119.25 ns |     1.380 ns |     1.291 ns |     306 B |         - |
| Decrypt · AES-128-GCM (OS)                            | 128B         |     145.28 ns |     1.265 ns |     1.121 ns |   2,230 B |         - |
| Decrypt · AES-128-GCM (CryptoHives-Scalar)            | 128B         |     919.32 ns |     9.287 ns |     8.687 ns |     306 B |         - |
| Decrypt · AES-128-GCM (BouncyCastle)                  | 128B         |     931.52 ns |     4.836 ns |     3.776 ns |     306 B |    1624 B |
|                                                       |              |               |              |              |           |           |
| Encrypt · AES-128-GCM (CryptoHives-AES-NI+PClMulV256) | 128B         |      66.14 ns |     0.551 ns |     0.516 ns |     383 B |         - |
| Encrypt · AES-128-GCM (CryptoHives-AES-NI+PClMul)     | 128B         |      67.92 ns |     0.913 ns |     0.854 ns |     383 B |         - |
| Encrypt · AES-128-GCM (OS)                            | 128B         |     136.91 ns |     1.808 ns |     1.691 ns |   2,202 B |         - |
| Encrypt · AES-128-GCM (BouncyCastle)                  | 128B         |     823.57 ns |     8.948 ns |     8.370 ns |     386 B |    1608 B |
| Encrypt · AES-128-GCM (CryptoHives-Scalar)            | 128B         |     866.90 ns |     7.891 ns |     7.381 ns |     383 B |         - |
|                                                       |              |               |              |              |           |           |
| Decrypt · AES-128-GCM (CryptoHives-AES-NI+PClMul)     | 152B         |     130.90 ns |     1.631 ns |     1.526 ns |     306 B |         - |
| Decrypt · AES-128-GCM (CryptoHives-AES-NI+PClMulV256) | 152B         |     151.33 ns |     2.228 ns |     2.084 ns |     306 B |         - |
| Decrypt · AES-128-GCM (OS)                            | 152B         |     201.45 ns |     1.879 ns |     1.666 ns |   2,230 B |         - |
| Decrypt · AES-128-GCM (BouncyCastle)                  | 152B         |   1,081.68 ns |    13.007 ns |    12.167 ns |     306 B |    1624 B |
| Decrypt · AES-128-GCM (CryptoHives-Scalar)            | 152B         |   1,091.48 ns |    12.145 ns |    11.360 ns |     306 B |         - |
|                                                       |              |               |              |              |           |           |
| Encrypt · AES-128-GCM (CryptoHives-AES-NI+PClMul)     | 152B         |      96.72 ns |     1.145 ns |     1.071 ns |     383 B |         - |
| Encrypt · AES-128-GCM (CryptoHives-AES-NI+PClMulV256) | 152B         |      98.54 ns |     1.089 ns |     1.019 ns |     383 B |         - |
| Encrypt · AES-128-GCM (OS)                            | 152B         |     156.77 ns |     1.954 ns |     1.827 ns |   2,205 B |         - |
| Encrypt · AES-128-GCM (BouncyCastle)                  | 152B         |     962.57 ns |    13.932 ns |    13.032 ns |     386 B |    1608 B |
| Encrypt · AES-128-GCM (CryptoHives-Scalar)            | 152B         |   1,053.09 ns |    15.372 ns |    14.379 ns |     383 B |         - |
|                                                       |              |               |              |              |           |           |
| Decrypt · AES-128-GCM (CryptoHives-AES-NI+PClMulV256) | 256B         |     137.38 ns |     1.890 ns |     1.768 ns |     306 B |         - |
| Decrypt · AES-128-GCM (OS)                            | 256B         |     144.47 ns |     1.453 ns |     1.359 ns |   2,230 B |         - |
| Decrypt · AES-128-GCM (CryptoHives-AES-NI+PClMul)     | 256B         |     155.65 ns |     1.447 ns |     1.353 ns |     306 B |         - |
| Decrypt · AES-128-GCM (BouncyCastle)                  | 256B         |   1,394.05 ns |    18.812 ns |    17.597 ns |     306 B |    1624 B |
| Decrypt · AES-128-GCM (CryptoHives-Scalar)            | 256B         |   1,620.73 ns |    14.502 ns |    13.565 ns |     306 B |         - |
|                                                       |              |               |              |              |           |           |
| Encrypt · AES-128-GCM (CryptoHives-AES-NI+PClMulV256) | 256B         |      85.78 ns |     0.856 ns |     0.800 ns |     383 B |         - |
| Encrypt · AES-128-GCM (CryptoHives-AES-NI+PClMul)     | 256B         |      90.82 ns |     1.151 ns |     1.077 ns |     383 B |         - |
| Encrypt · AES-128-GCM (OS)                            | 256B         |     142.12 ns |     1.843 ns |     1.724 ns |   2,202 B |         - |
| Encrypt · AES-128-GCM (BouncyCastle)                  | 256B         |   1,298.44 ns |    18.956 ns |    17.731 ns |     386 B |    1608 B |
| Encrypt · AES-128-GCM (CryptoHives-Scalar)            | 256B         |   1,583.57 ns |    21.074 ns |    19.712 ns |     383 B |         - |
|                                                       |              |               |              |              |           |           |
| Decrypt · AES-128-GCM (OS)                            | 1KB          |     209.99 ns |     0.952 ns |     0.744 ns |   2,230 B |         - |
| Decrypt · AES-128-GCM (CryptoHives-AES-NI+PClMulV256) | 1KB          |     237.28 ns |     3.027 ns |     2.832 ns |     306 B |         - |
| Decrypt · AES-128-GCM (CryptoHives-AES-NI+PClMul)     | 1KB          |     299.58 ns |     3.978 ns |     3.721 ns |     306 B |         - |
| Decrypt · AES-128-GCM (BouncyCastle)                  | 1KB          |   4,200.92 ns |    65.370 ns |    61.147 ns |     306 B |    1624 B |
| Decrypt · AES-128-GCM (CryptoHives-Scalar)            | 1KB          |   5,857.09 ns |    67.404 ns |    63.050 ns |     306 B |         - |
|                                                       |              |               |              |              |           |           |
| Encrypt · AES-128-GCM (CryptoHives-AES-NI+PClMulV256) | 1KB          |     199.76 ns |     2.348 ns |     2.196 ns |     383 B |         - |
| Encrypt · AES-128-GCM (OS)                            | 1KB          |     203.84 ns |     1.487 ns |     1.242 ns |   2,205 B |         - |
| Encrypt · AES-128-GCM (CryptoHives-AES-NI+PClMul)     | 1KB          |     227.85 ns |     2.491 ns |     2.331 ns |     383 B |         - |
| Encrypt · AES-128-GCM (BouncyCastle)                  | 1KB          |   4,081.62 ns |    56.800 ns |    53.130 ns |     386 B |    1608 B |
| Encrypt · AES-128-GCM (CryptoHives-Scalar)            | 1KB          |   5,813.67 ns |    49.018 ns |    45.851 ns |     383 B |         - |
|                                                       |              |               |              |              |           |           |
| Decrypt · AES-128-GCM (OS)                            | 8KB          |     815.46 ns |    10.563 ns |     9.881 ns |   2,230 B |         - |
| Decrypt · AES-128-GCM (CryptoHives-AES-NI+PClMulV256) | 8KB          |   1,204.32 ns |    16.748 ns |    15.666 ns |     306 B |         - |
| Decrypt · AES-128-GCM (CryptoHives-AES-NI+PClMul)     | 8KB          |   1,621.77 ns |    21.280 ns |    19.905 ns |     306 B |         - |
| Decrypt · AES-128-GCM (BouncyCastle)                  | 8KB          |  29,699.38 ns |   263.717 ns |   246.681 ns |     306 B |    1624 B |
| Decrypt · AES-128-GCM (CryptoHives-Scalar)            | 8KB          |  45,561.51 ns |   598.275 ns |   559.627 ns |     306 B |         - |
|                                                       |              |               |              |              |           |           |
| Encrypt · AES-128-GCM (OS)                            | 8KB          |     805.99 ns |     7.122 ns |     6.662 ns |   2,205 B |         - |
| Encrypt · AES-128-GCM (CryptoHives-AES-NI+PClMulV256) | 8KB          |   1,269.99 ns |    18.419 ns |    17.229 ns |     383 B |         - |
| Encrypt · AES-128-GCM (CryptoHives-AES-NI+PClMul)     | 8KB          |   1,518.90 ns |    17.789 ns |    16.639 ns |     383 B |         - |
| Encrypt · AES-128-GCM (BouncyCastle)                  | 8KB          |  29,437.54 ns |   314.139 ns |   293.846 ns |     383 B |    1608 B |
| Encrypt · AES-128-GCM (CryptoHives-Scalar)            | 8KB          |  45,932.44 ns |   535.447 ns |   500.857 ns |     383 B |         - |
|                                                       |              |               |              |              |           |           |
| Decrypt · AES-128-GCM (OS)                            | 128KB        |  12,546.82 ns |   139.713 ns |   130.687 ns |   2,230 B |         - |
| Decrypt · AES-128-GCM (CryptoHives-AES-NI+PClMulV256) | 128KB        |  18,530.54 ns |   278.141 ns |   260.173 ns |     306 B |         - |
| Decrypt · AES-128-GCM (CryptoHives-AES-NI+PClMul)     | 128KB        |  24,320.34 ns |   237.627 ns |   198.429 ns |     306 B |         - |
| Decrypt · AES-128-GCM (BouncyCastle)                  | 128KB        | 470,318.68 ns | 5,467.176 ns | 5,113.999 ns |     306 B |    1624 B |
| Decrypt · AES-128-GCM (CryptoHives-Scalar)            | 128KB        | 716,862.17 ns | 3,016.810 ns | 2,355.326 ns |     306 B |         - |
|                                                       |              |               |              |              |           |           |
| Encrypt · AES-128-GCM (OS)                            | 128KB        |  11,301.88 ns |   160.622 ns |   150.246 ns |   2,202 B |         - |
| Encrypt · AES-128-GCM (CryptoHives-AES-NI+PClMulV256) | 128KB        |  19,676.61 ns |   248.341 ns |   232.298 ns |     383 B |         - |
| Encrypt · AES-128-GCM (CryptoHives-AES-NI+PClMul)     | 128KB        |  23,739.12 ns |   312.697 ns |   292.497 ns |     383 B |         - |
| Encrypt · AES-128-GCM (BouncyCastle)                  | 128KB        | 466,807.37 ns | 2,274.098 ns | 1,898.975 ns |     383 B |    1608 B |
| Encrypt · AES-128-GCM (CryptoHives-Scalar)            | 128KB        | 724,886.10 ns | 7,948.376 ns | 7,434.915 ns |     383 B |         - |