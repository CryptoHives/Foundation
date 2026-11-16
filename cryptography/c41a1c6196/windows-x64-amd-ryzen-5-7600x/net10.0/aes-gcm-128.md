| Description                                           | TestDataSize | Mean          | Error        | StdDev       | Code Size | Allocated |
|------------------------------------------------------ |------------- |--------------:|-------------:|-------------:|----------:|----------:|
| Decrypt · AES-128-GCM (CryptoHives-AES-NI+PClMul)     | 17B          |     116.53 ns |     0.298 ns |     0.264 ns |     306 B |         - |
| Decrypt · AES-128-GCM (CryptoHives-AES-NI+PClMulV256) | 17B          |     116.89 ns |     0.250 ns |     0.222 ns |     306 B |         - |
| Decrypt · AES-128-GCM (OS)                            | 17B          |     135.44 ns |     0.464 ns |     0.387 ns |   2,230 B |         - |
| Decrypt · AES-128-GCM (CryptoHives-Scalar)            | 17B          |     376.31 ns |     0.886 ns |     0.829 ns |     306 B |         - |
| Decrypt · AES-128-GCM (BouncyCastle)                  | 17B          |     551.05 ns |     2.841 ns |     2.519 ns |     306 B |    1624 B |
|                                                       |              |               |              |              |           |           |
| Encrypt · AES-128-GCM (CryptoHives-AES-NI+PClMulV256) | 17B          |      73.03 ns |     0.907 ns |     0.848 ns |     383 B |         - |
| Encrypt · AES-128-GCM (CryptoHives-AES-NI+PClMul)     | 17B          |      73.46 ns |     0.726 ns |     0.679 ns |     383 B |         - |
| Encrypt · AES-128-GCM (OS)                            | 17B          |     146.06 ns |     0.713 ns |     0.632 ns |   2,202 B |         - |
| Encrypt · AES-128-GCM (CryptoHives-Scalar)            | 17B          |     343.43 ns |     4.130 ns |     3.863 ns |     386 B |         - |
| Encrypt · AES-128-GCM (BouncyCastle)                  | 17B          |     494.43 ns |     5.633 ns |     5.269 ns |     386 B |    1608 B |
|                                                       |              |               |              |              |           |           |
| Decrypt · AES-128-GCM (CryptoHives-AES-NI+PClMul)     | 65B          |     116.63 ns |     0.178 ns |     0.157 ns |     306 B |         - |
| Decrypt · AES-128-GCM (CryptoHives-AES-NI+PClMulV256) | 65B          |     116.77 ns |     0.256 ns |     0.214 ns |     306 B |         - |
| Decrypt · AES-128-GCM (OS)                            | 65B          |     142.01 ns |     0.349 ns |     0.310 ns |   2,230 B |         - |
| Decrypt · AES-128-GCM (CryptoHives-Scalar)            | 65B          |     646.08 ns |     1.417 ns |     1.106 ns |     306 B |         - |
| Decrypt · AES-128-GCM (BouncyCastle)                  | 65B          |     760.64 ns |     2.552 ns |     2.262 ns |     306 B |    1624 B |
|                                                       |              |               |              |              |           |           |
| Encrypt · AES-128-GCM (CryptoHives-AES-NI+PClMulV256) | 65B          |      80.37 ns |     0.730 ns |     0.683 ns |     383 B |         - |
| Encrypt · AES-128-GCM (CryptoHives-AES-NI+PClMul)     | 65B          |      80.51 ns |     0.824 ns |     0.731 ns |     383 B |         - |
| Encrypt · AES-128-GCM (OS)                            | 65B          |     149.03 ns |     1.763 ns |     1.649 ns |   2,202 B |         - |
| Encrypt · AES-128-GCM (CryptoHives-Scalar)            | 65B          |     608.02 ns |     6.141 ns |     5.744 ns |     386 B |         - |
| Encrypt · AES-128-GCM (BouncyCastle)                  | 65B          |     670.72 ns |    12.237 ns |    11.447 ns |     386 B |    1608 B |
|                                                       |              |               |              |              |           |           |
| Decrypt · AES-128-GCM (CryptoHives-AES-NI+PClMul)     | 128B         |     118.97 ns |     0.490 ns |     0.435 ns |     306 B |         - |
| Decrypt · AES-128-GCM (CryptoHives-AES-NI+PClMulV256) | 128B         |     119.14 ns |     1.307 ns |     1.091 ns |     306 B |         - |
| Decrypt · AES-128-GCM (OS)                            | 128B         |     140.70 ns |     0.950 ns |     0.793 ns |   2,230 B |         - |
| Decrypt · AES-128-GCM (CryptoHives-Scalar)            | 128B         |     914.21 ns |     3.124 ns |     2.922 ns |     306 B |         - |
| Decrypt · AES-128-GCM (BouncyCastle)                  | 128B         |     929.92 ns |     2.120 ns |     1.655 ns |     306 B |    1624 B |
|                                                       |              |               |              |              |           |           |
| Encrypt · AES-128-GCM (CryptoHives-AES-NI+PClMulV256) | 128B         |      67.65 ns |     0.697 ns |     0.652 ns |     383 B |         - |
| Encrypt · AES-128-GCM (CryptoHives-AES-NI+PClMul)     | 128B         |      69.36 ns |     0.737 ns |     0.689 ns |     383 B |         - |
| Encrypt · AES-128-GCM (OS)                            | 128B         |     140.11 ns |     1.965 ns |     1.838 ns |   2,202 B |         - |
| Encrypt · AES-128-GCM (BouncyCastle)                  | 128B         |     839.76 ns |    12.997 ns |    10.853 ns |     383 B |    1608 B |
| Encrypt · AES-128-GCM (CryptoHives-Scalar)            | 128B         |     882.97 ns |    12.232 ns |    11.442 ns |     386 B |         - |
|                                                       |              |               |              |              |           |           |
| Decrypt · AES-128-GCM (CryptoHives-AES-NI+PClMulV256) | 152B         |     135.44 ns |     0.575 ns |     0.510 ns |     306 B |         - |
| Decrypt · AES-128-GCM (CryptoHives-AES-NI+PClMul)     | 152B         |     135.61 ns |     0.639 ns |     0.567 ns |     306 B |         - |
| Decrypt · AES-128-GCM (OS)                            | 152B         |     155.92 ns |     0.579 ns |     0.541 ns |   2,230 B |         - |
| Decrypt · AES-128-GCM (BouncyCastle)                  | 152B         |   1,081.12 ns |     7.568 ns |     6.709 ns |     306 B |    1624 B |
| Decrypt · AES-128-GCM (CryptoHives-Scalar)            | 152B         |   1,091.70 ns |     3.988 ns |     3.535 ns |     306 B |         - |
|                                                       |              |               |              |              |           |           |
| Encrypt · AES-128-GCM (CryptoHives-AES-NI+PClMulV256) | 152B         |      97.26 ns |     1.552 ns |     1.296 ns |     383 B |         - |
| Encrypt · AES-128-GCM (CryptoHives-AES-NI+PClMul)     | 152B         |      98.10 ns |     1.092 ns |     1.021 ns |     383 B |         - |
| Encrypt · AES-128-GCM (OS)                            | 152B         |     158.60 ns |     1.892 ns |     1.770 ns |   2,202 B |         - |
| Encrypt · AES-128-GCM (BouncyCastle)                  | 152B         |     977.54 ns |    10.638 ns |     9.951 ns |     383 B |    1608 B |
| Encrypt · AES-128-GCM (CryptoHives-Scalar)            | 152B         |   1,051.67 ns |    13.200 ns |    11.701 ns |     383 B |         - |
|                                                       |              |               |              |              |           |           |
| Decrypt · AES-128-GCM (CryptoHives-AES-NI+PClMulV256) | 256B         |     136.36 ns |     0.546 ns |     0.510 ns |     306 B |         - |
| Decrypt · AES-128-GCM (OS)                            | 256B         |     144.88 ns |     0.644 ns |     0.602 ns |   2,230 B |         - |
| Decrypt · AES-128-GCM (CryptoHives-AES-NI+PClMul)     | 256B         |     150.03 ns |     0.649 ns |     0.607 ns |     306 B |         - |
| Decrypt · AES-128-GCM (BouncyCastle)                  | 256B         |   1,392.55 ns |     6.335 ns |     5.616 ns |     306 B |    1624 B |
| Decrypt · AES-128-GCM (CryptoHives-Scalar)            | 256B         |   1,621.14 ns |     4.544 ns |     3.795 ns |     306 B |         - |
|                                                       |              |               |              |              |           |           |
| Encrypt · AES-128-GCM (CryptoHives-AES-NI+PClMulV256) | 256B         |      86.56 ns |     1.089 ns |     1.018 ns |     383 B |         - |
| Encrypt · AES-128-GCM (CryptoHives-AES-NI+PClMul)     | 256B         |      90.75 ns |     0.771 ns |     0.721 ns |     383 B |         - |
| Encrypt · AES-128-GCM (OS)                            | 256B         |     145.12 ns |     1.492 ns |     1.396 ns |   2,202 B |         - |
| Encrypt · AES-128-GCM (BouncyCastle)                  | 256B         |   1,299.37 ns |    21.666 ns |    20.266 ns |     383 B |    1608 B |
| Encrypt · AES-128-GCM (CryptoHives-Scalar)            | 256B         |   1,603.72 ns |    19.511 ns |    18.250 ns |     383 B |         - |
|                                                       |              |               |              |              |           |           |
| Decrypt · AES-128-GCM (OS)                            | 1KB          |     207.83 ns |     0.395 ns |     0.350 ns |   2,230 B |         - |
| Decrypt · AES-128-GCM (CryptoHives-AES-NI+PClMulV256) | 1KB          |     266.94 ns |     1.752 ns |     1.638 ns |     306 B |         - |
| Decrypt · AES-128-GCM (CryptoHives-AES-NI+PClMul)     | 1KB          |     290.60 ns |     0.983 ns |     0.821 ns |     306 B |         - |
| Decrypt · AES-128-GCM (BouncyCastle)                  | 1KB          |   4,137.77 ns |    12.424 ns |    10.374 ns |     306 B |    1624 B |
| Decrypt · AES-128-GCM (CryptoHives-Scalar)            | 1KB          |   5,855.36 ns |    19.393 ns |    16.194 ns |     306 B |         - |
|                                                       |              |               |              |              |           |           |
| Encrypt · AES-128-GCM (OS)                            | 1KB          |     198.82 ns |     1.439 ns |     1.276 ns |   2,205 B |         - |
| Encrypt · AES-128-GCM (CryptoHives-AES-NI+PClMulV256) | 1KB          |     206.86 ns |     0.729 ns |     0.682 ns |     383 B |         - |
| Encrypt · AES-128-GCM (CryptoHives-AES-NI+PClMul)     | 1KB          |     227.88 ns |     1.707 ns |     1.514 ns |     383 B |         - |
| Encrypt · AES-128-GCM (BouncyCastle)                  | 1KB          |   4,042.66 ns |    13.683 ns |    12.130 ns |     383 B |    1608 B |
| Encrypt · AES-128-GCM (CryptoHives-Scalar)            | 1KB          |   5,812.42 ns |    14.932 ns |    13.237 ns |     383 B |         - |
|                                                       |              |               |              |              |           |           |
| Decrypt · AES-128-GCM (OS)                            | 8KB          |     809.38 ns |     3.195 ns |     2.988 ns |   2,230 B |         - |
| Decrypt · AES-128-GCM (CryptoHives-AES-NI+PClMulV256) | 8KB          |   1,204.27 ns |     4.473 ns |     4.184 ns |     306 B |         - |
| Decrypt · AES-128-GCM (CryptoHives-AES-NI+PClMul)     | 8KB          |   1,614.22 ns |     5.895 ns |     4.923 ns |     306 B |         - |
| Decrypt · AES-128-GCM (BouncyCastle)                  | 8KB          |  29,662.12 ns |    63.225 ns |    56.047 ns |     306 B |    1624 B |
| Decrypt · AES-128-GCM (CryptoHives-Scalar)            | 8KB          |  45,358.17 ns |   139.248 ns |   123.440 ns |     306 B |         - |
|                                                       |              |               |              |              |           |           |
| Encrypt · AES-128-GCM (OS)                            | 8KB          |     782.45 ns |     1.976 ns |     1.849 ns |   2,205 B |         - |
| Encrypt · AES-128-GCM (CryptoHives-AES-NI+PClMulV256) | 8KB          |   1,277.83 ns |     3.482 ns |     3.087 ns |     383 B |         - |
| Encrypt · AES-128-GCM (CryptoHives-AES-NI+PClMul)     | 8KB          |   1,520.23 ns |     3.519 ns |     3.291 ns |     383 B |         - |
| Encrypt · AES-128-GCM (BouncyCastle)                  | 8KB          |  29,466.37 ns |    54.419 ns |    45.442 ns |     383 B |    1608 B |
| Encrypt · AES-128-GCM (CryptoHives-Scalar)            | 8KB          |  45,233.65 ns |   126.140 ns |   111.820 ns |     383 B |         - |
|                                                       |              |               |              |              |           |           |
| Decrypt · AES-128-GCM (OS)                            | 128KB        |  12,485.57 ns |    22.533 ns |    18.816 ns |   2,230 B |         - |
| Decrypt · AES-128-GCM (CryptoHives-AES-NI+PClMulV256) | 128KB        |  18,383.13 ns |    85.102 ns |    79.604 ns |     306 B |         - |
| Decrypt · AES-128-GCM (CryptoHives-AES-NI+PClMul)     | 128KB        |  24,278.13 ns |    47.391 ns |    39.574 ns |     306 B |         - |
| Decrypt · AES-128-GCM (BouncyCastle)                  | 128KB        | 468,861.81 ns |   764.449 ns |   677.664 ns |     306 B |    1624 B |
| Decrypt · AES-128-GCM (CryptoHives-Scalar)            | 128KB        | 727,078.23 ns | 2,598.229 ns | 2,303.262 ns |     306 B |         - |
|                                                       |              |               |              |              |           |           |
| Encrypt · AES-128-GCM (OS)                            | 128KB        |  11,232.09 ns |    32.267 ns |    26.944 ns |   2,202 B |         - |
| Encrypt · AES-128-GCM (CryptoHives-AES-NI+PClMulV256) | 128KB        |  19,809.68 ns |    33.392 ns |    27.884 ns |     383 B |         - |
| Encrypt · AES-128-GCM (CryptoHives-AES-NI+PClMul)     | 128KB        |  23,837.11 ns |    33.599 ns |    29.785 ns |     383 B |         - |
| Encrypt · AES-128-GCM (BouncyCastle)                  | 128KB        | 468,600.66 ns | 2,107.811 ns | 1,868.520 ns |     383 B |    1608 B |
| Encrypt · AES-128-GCM (CryptoHives-Scalar)            | 128KB        | 732,575.29 ns | 1,888.605 ns | 1,674.199 ns |     383 B |         - |