| Description                                           | TestDataSize | Mean          | Error        | StdDev       | Allocated |
|------------------------------------------------------ |------------- |--------------:|-------------:|-------------:|----------:|
| Decrypt · AES-192-GCM (OS)                            | 17B          |     119.67 ns |     0.376 ns |     0.352 ns |         - |
| Decrypt · AES-192-GCM (CryptoHives-AES-NI+PClMul)     | 17B          |     121.49 ns |     0.224 ns |     0.210 ns |         - |
| Decrypt · AES-192-GCM (CryptoHives-AES-NI+PClMulV256) | 17B          |     122.11 ns |     0.211 ns |     0.197 ns |         - |
| Decrypt · AES-192-GCM (CryptoHives-Scalar)            | 17B          |     358.48 ns |     1.811 ns |     1.694 ns |         - |
| Decrypt · AES-192-GCM (BouncyCastle)                  | 17B          |     599.53 ns |     2.944 ns |     2.754 ns |    1728 B |
|                                                       |              |               |              |              |           |
| Encrypt · AES-192-GCM (CryptoHives-AES-NI+PClMulV256) | 17B          |      65.84 ns |     0.103 ns |     0.096 ns |         - |
| Encrypt · AES-192-GCM (CryptoHives-AES-NI+PClMul)     | 17B          |      66.07 ns |     0.250 ns |     0.234 ns |         - |
| Encrypt · AES-192-GCM (OS)                            | 17B          |     123.65 ns |     0.319 ns |     0.283 ns |         - |
| Encrypt · AES-192-GCM (CryptoHives-Scalar)            | 17B          |     328.72 ns |     1.369 ns |     1.280 ns |         - |
| Encrypt · AES-192-GCM (BouncyCastle)                  | 17B          |     539.65 ns |     2.822 ns |     2.639 ns |    1712 B |
|                                                       |              |               |              |              |           |
| Decrypt · AES-192-GCM (CryptoHives-AES-NI+PClMulV256) | 65B          |     102.57 ns |     0.333 ns |     0.311 ns |         - |
| Decrypt · AES-192-GCM (CryptoHives-AES-NI+PClMul)     | 65B          |     107.48 ns |     0.314 ns |     0.293 ns |         - |
| Decrypt · AES-192-GCM (OS)                            | 65B          |     122.79 ns |     0.380 ns |     0.337 ns |         - |
| Decrypt · AES-192-GCM (CryptoHives-Scalar)            | 65B          |     615.44 ns |     2.428 ns |     2.271 ns |         - |
| Decrypt · AES-192-GCM (BouncyCastle)                  | 65B          |     796.90 ns |     2.880 ns |     2.694 ns |    1728 B |
|                                                       |              |               |              |              |           |
| Encrypt · AES-192-GCM (CryptoHives-AES-NI+PClMul)     | 65B          |      72.81 ns |     0.161 ns |     0.151 ns |         - |
| Encrypt · AES-192-GCM (CryptoHives-AES-NI+PClMulV256) | 65B          |      73.21 ns |     0.183 ns |     0.171 ns |         - |
| Encrypt · AES-192-GCM (OS)                            | 65B          |     126.98 ns |     0.344 ns |     0.322 ns |         - |
| Encrypt · AES-192-GCM (CryptoHives-Scalar)            | 65B          |     587.28 ns |     1.288 ns |     1.205 ns |         - |
| Encrypt · AES-192-GCM (BouncyCastle)                  | 65B          |     705.92 ns |     2.831 ns |     2.648 ns |    1712 B |
|                                                       |              |               |              |              |           |
| Decrypt · AES-192-GCM (CryptoHives-AES-NI+PClMulV256) | 128B         |      96.57 ns |     0.354 ns |     0.332 ns |         - |
| Decrypt · AES-192-GCM (CryptoHives-AES-NI+PClMul)     | 128B         |     100.27 ns |     0.337 ns |     0.315 ns |         - |
| Decrypt · AES-192-GCM (OS)                            | 128B         |     121.43 ns |     0.501 ns |     0.469 ns |         - |
| Decrypt · AES-192-GCM (BouncyCastle)                  | 128B         |     965.69 ns |     6.360 ns |     5.949 ns |    1728 B |
| Decrypt · AES-192-GCM (CryptoHives-Scalar)            | 128B         |   1,579.78 ns |    31.297 ns |    34.786 ns |         - |
|                                                       |              |               |              |              |           |
| Encrypt · AES-192-GCM (CryptoHives-AES-NI+PClMulV256) | 128B         |      59.91 ns |     0.199 ns |     0.186 ns |         - |
| Encrypt · AES-192-GCM (CryptoHives-AES-NI+PClMul)     | 128B         |      62.61 ns |     0.155 ns |     0.145 ns |         - |
| Encrypt · AES-192-GCM (OS)                            | 128B         |     119.13 ns |     0.286 ns |     0.224 ns |         - |
| Encrypt · AES-192-GCM (BouncyCastle)                  | 128B         |     875.34 ns |     2.935 ns |     2.602 ns |    1712 B |
| Encrypt · AES-192-GCM (CryptoHives-Scalar)            | 128B         |     883.59 ns |     1.438 ns |     1.201 ns |         - |
|                                                       |              |               |              |              |           |
| Decrypt · AES-192-GCM (CryptoHives-AES-NI+PClMulV256) | 152B         |     126.81 ns |     0.240 ns |     0.213 ns |         - |
| Decrypt · AES-192-GCM (CryptoHives-AES-NI+PClMul)     | 152B         |     127.10 ns |     0.661 ns |     0.586 ns |         - |
| Decrypt · AES-192-GCM (OS)                            | 152B         |     137.44 ns |     0.516 ns |     0.483 ns |         - |
| Decrypt · AES-192-GCM (CryptoHives-Scalar)            | 152B         |   1,052.88 ns |     4.091 ns |     3.827 ns |         - |
| Decrypt · AES-192-GCM (BouncyCastle)                  | 152B         |   1,104.68 ns |     4.454 ns |     4.166 ns |    1728 B |
|                                                       |              |               |              |              |           |
| Encrypt · AES-192-GCM (CryptoHives-AES-NI+PClMulV256) | 152B         |      87.32 ns |     0.158 ns |     0.148 ns |         - |
| Encrypt · AES-192-GCM (CryptoHives-AES-NI+PClMul)     | 152B         |      89.45 ns |     0.172 ns |     0.161 ns |         - |
| Encrypt · AES-192-GCM (OS)                            | 152B         |     135.72 ns |     0.542 ns |     0.507 ns |         - |
| Encrypt · AES-192-GCM (BouncyCastle)                  | 152B         |   1,003.91 ns |     5.388 ns |     5.040 ns |    1712 B |
| Encrypt · AES-192-GCM (CryptoHives-Scalar)            | 152B         |   1,023.66 ns |     3.858 ns |     3.609 ns |         - |
|                                                       |              |               |              |              |           |
| Decrypt · AES-192-GCM (CryptoHives-AES-NI+PClMulV256) | 256B         |     113.66 ns |     0.289 ns |     0.256 ns |         - |
| Decrypt · AES-192-GCM (OS)                            | 256B         |     129.24 ns |     0.157 ns |     0.131 ns |         - |
| Decrypt · AES-192-GCM (CryptoHives-AES-NI+PClMul)     | 256B         |     131.80 ns |     1.213 ns |     1.076 ns |         - |
| Decrypt · AES-192-GCM (BouncyCastle)                  | 256B         |   1,417.31 ns |     4.532 ns |     4.239 ns |    1728 B |
| Decrypt · AES-192-GCM (CryptoHives-Scalar)            | 256B         |   1,571.12 ns |     6.925 ns |     6.477 ns |         - |
|                                                       |              |               |              |              |           |
| Encrypt · AES-192-GCM (CryptoHives-AES-NI+PClMulV256) | 256B         |      77.91 ns |     0.243 ns |     0.227 ns |         - |
| Encrypt · AES-192-GCM (CryptoHives-AES-NI+PClMul)     | 256B         |      81.82 ns |     0.299 ns |     0.280 ns |         - |
| Encrypt · AES-192-GCM (OS)                            | 256B         |     122.95 ns |     0.245 ns |     0.217 ns |         - |
| Encrypt · AES-192-GCM (BouncyCastle)                  | 256B         |   1,327.54 ns |     7.432 ns |     6.952 ns |    1712 B |
| Encrypt · AES-192-GCM (CryptoHives-Scalar)            | 256B         |   1,554.01 ns |     2.578 ns |     2.285 ns |         - |
|                                                       |              |               |              |              |           |
| Decrypt · AES-192-GCM (CryptoHives-AES-NI+PClMulV256) | 1KB          |     201.13 ns |     0.683 ns |     0.639 ns |         - |
| Decrypt · AES-192-GCM (OS)                            | 1KB          |     204.98 ns |     0.383 ns |     0.358 ns |         - |
| Decrypt · AES-192-GCM (CryptoHives-AES-NI+PClMul)     | 1KB          |     252.16 ns |     0.978 ns |     0.915 ns |         - |
| Decrypt · AES-192-GCM (BouncyCastle)                  | 1KB          |   4,141.49 ns |    16.911 ns |    15.819 ns |    1728 B |
| Decrypt · AES-192-GCM (CryptoHives-Scalar)            | 1KB          |   5,743.99 ns |    20.118 ns |    18.818 ns |         - |
|                                                       |              |               |              |              |           |
| Encrypt · AES-192-GCM (OS)                            | 1KB          |     174.93 ns |     0.682 ns |     0.638 ns |         - |
| Encrypt · AES-192-GCM (CryptoHives-AES-NI+PClMulV256) | 1KB          |     186.38 ns |     0.651 ns |     0.577 ns |         - |
| Encrypt · AES-192-GCM (CryptoHives-AES-NI+PClMul)     | 1KB          |     204.88 ns |     0.492 ns |     0.460 ns |         - |
| Encrypt · AES-192-GCM (BouncyCastle)                  | 1KB          |   4,060.13 ns |    22.901 ns |    21.422 ns |    1712 B |
| Encrypt · AES-192-GCM (CryptoHives-Scalar)            | 1KB          |   5,712.17 ns |    17.085 ns |    15.981 ns |         - |
|                                                       |              |               |              |              |           |
| Decrypt · AES-192-GCM (OS)                            | 8KB          |     776.84 ns |     2.816 ns |     2.634 ns |         - |
| Decrypt · AES-192-GCM (CryptoHives-AES-NI+PClMulV256) | 8KB          |   1,055.90 ns |     5.346 ns |     5.000 ns |         - |
| Decrypt · AES-192-GCM (CryptoHives-AES-NI+PClMul)     | 8KB          |   1,458.85 ns |     3.377 ns |     2.993 ns |         - |
| Decrypt · AES-192-GCM (BouncyCastle)                  | 8KB          |  29,455.32 ns |    56.637 ns |    50.207 ns |    1728 B |
| Decrypt · AES-192-GCM (CryptoHives-Scalar)            | 8KB          |  45,045.79 ns |   223.156 ns |   208.740 ns |         - |
|                                                       |              |               |              |              |           |
| Encrypt · AES-192-GCM (OS)                            | 8KB          |     684.09 ns |     3.133 ns |     2.930 ns |         - |
| Encrypt · AES-192-GCM (CryptoHives-AES-NI+PClMulV256) | 8KB          |   1,184.52 ns |     2.791 ns |     2.474 ns |         - |
| Encrypt · AES-192-GCM (CryptoHives-AES-NI+PClMul)     | 8KB          |   1,364.40 ns |     4.701 ns |     4.397 ns |         - |
| Encrypt · AES-192-GCM (BouncyCastle)                  | 8KB          |  29,380.01 ns |    50.207 ns |    46.964 ns |    1712 B |
| Encrypt · AES-192-GCM (CryptoHives-Scalar)            | 8KB          |  44,544.59 ns |   195.274 ns |   182.659 ns |         - |
|                                                       |              |               |              |              |           |
| Decrypt · AES-192-GCM (OS)                            | 128KB        |  11,598.76 ns |    39.805 ns |    37.234 ns |         - |
| Decrypt · AES-192-GCM (CryptoHives-AES-NI+PClMulV256) | 128KB        |  16,379.91 ns |    87.162 ns |    81.532 ns |         - |
| Decrypt · AES-192-GCM (CryptoHives-AES-NI+PClMul)     | 128KB        |  21,987.06 ns |    69.737 ns |    65.232 ns |         - |
| Decrypt · AES-192-GCM (BouncyCastle)                  | 128KB        | 464,656.26 ns | 1,575.756 ns | 1,473.963 ns |    1728 B |
| Decrypt · AES-192-GCM (CryptoHives-Scalar)            | 128KB        | 711,492.12 ns | 2,554.506 ns | 2,389.486 ns |         - |
|                                                       |              |               |              |              |           |
| Encrypt · AES-192-GCM (OS)                            | 128KB        |  10,069.99 ns |    53.713 ns |    47.615 ns |         - |
| Encrypt · AES-192-GCM (CryptoHives-AES-NI+PClMulV256) | 128KB        |  18,417.35 ns |    46.386 ns |    38.734 ns |         - |
| Encrypt · AES-192-GCM (CryptoHives-AES-NI+PClMul)     | 128KB        |  21,138.81 ns |    73.152 ns |    68.426 ns |         - |
| Encrypt · AES-192-GCM (BouncyCastle)                  | 128KB        | 464,245.22 ns | 1,350.243 ns | 1,263.018 ns |    1712 B |
| Encrypt · AES-192-GCM (CryptoHives-Scalar)            | 128KB        | 711,611.54 ns | 4,121.843 ns | 3,855.575 ns |         - |