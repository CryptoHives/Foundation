| Description                                           | TestDataSize | Mean          | Error        | StdDev       | Allocated |
|------------------------------------------------------ |------------- |--------------:|-------------:|-------------:|----------:|
| Decrypt · AES-128-GCM (OS)                            | 17B          |     116.15 ns |     0.396 ns |     0.331 ns |         - |
| Decrypt · AES-128-GCM (CryptoHives-AES-NI+PClMul)     | 17B          |     118.74 ns |     0.433 ns |     0.405 ns |         - |
| Decrypt · AES-128-GCM (CryptoHives-AES-NI+PClMulV256) | 17B          |     124.92 ns |     0.772 ns |     0.723 ns |         - |
| Decrypt · AES-128-GCM (CryptoHives-Scalar)            | 17B          |     343.34 ns |     2.778 ns |     2.599 ns |         - |
| Decrypt · AES-128-GCM (BouncyCastle)                  | 17B          |     484.41 ns |     4.088 ns |     3.824 ns |    1624 B |
|                                                       |              |               |              |              |           |
| Encrypt · AES-128-GCM (CryptoHives-AES-NI+PClMulV256) | 17B          |      66.80 ns |     0.236 ns |     0.221 ns |         - |
| Encrypt · AES-128-GCM (CryptoHives-AES-NI+PClMul)     | 17B          |      67.24 ns |     0.297 ns |     0.278 ns |         - |
| Encrypt · AES-128-GCM (OS)                            | 17B          |     122.95 ns |     0.899 ns |     0.841 ns |         - |
| Encrypt · AES-128-GCM (CryptoHives-Scalar)            | 17B          |     312.80 ns |     1.363 ns |     1.208 ns |         - |
| Encrypt · AES-128-GCM (BouncyCastle)                  | 17B          |     431.09 ns |     2.354 ns |     2.202 ns |    1608 B |
|                                                       |              |               |              |              |           |
| Decrypt · AES-128-GCM (CryptoHives-AES-NI+PClMul)     | 65B          |      99.84 ns |     0.369 ns |     0.327 ns |         - |
| Decrypt · AES-128-GCM (CryptoHives-AES-NI+PClMulV256) | 65B          |     101.83 ns |     0.745 ns |     0.697 ns |         - |
| Decrypt · AES-128-GCM (OS)                            | 65B          |     119.44 ns |     0.595 ns |     0.497 ns |         - |
| Decrypt · AES-128-GCM (CryptoHives-Scalar)            | 65B          |     584.52 ns |     2.917 ns |     2.728 ns |         - |
| Decrypt · AES-128-GCM (BouncyCastle)                  | 65B          |     664.53 ns |     4.745 ns |     4.439 ns |    1624 B |
|                                                       |              |               |              |              |           |
| Encrypt · AES-128-GCM (CryptoHives-AES-NI+PClMulV256) | 65B          |      71.13 ns |     0.265 ns |     0.248 ns |         - |
| Encrypt · AES-128-GCM (CryptoHives-AES-NI+PClMul)     | 65B          |      71.79 ns |     0.279 ns |     0.261 ns |         - |
| Encrypt · AES-128-GCM (OS)                            | 65B          |     125.95 ns |     0.729 ns |     0.682 ns |         - |
| Encrypt · AES-128-GCM (CryptoHives-Scalar)            | 65B          |     558.61 ns |     2.714 ns |     2.539 ns |         - |
| Encrypt · AES-128-GCM (BouncyCastle)                  | 65B          |     575.20 ns |     6.055 ns |     5.664 ns |    1608 B |
|                                                       |              |               |              |              |           |
| Decrypt · AES-128-GCM (CryptoHives-AES-NI+PClMul)     | 128B         |      93.95 ns |     0.628 ns |     0.587 ns |         - |
| Decrypt · AES-128-GCM (CryptoHives-AES-NI+PClMulV256) | 128B         |      97.15 ns |     0.498 ns |     0.466 ns |         - |
| Decrypt · AES-128-GCM (OS)                            | 128B         |     119.78 ns |     0.980 ns |     0.917 ns |         - |
| Decrypt · AES-128-GCM (BouncyCastle)                  | 128B         |     820.93 ns |     4.511 ns |     3.767 ns |    1624 B |
| Decrypt · AES-128-GCM (CryptoHives-Scalar)            | 128B         |     834.01 ns |     3.843 ns |     3.594 ns |         - |
|                                                       |              |               |              |              |           |
| Encrypt · AES-128-GCM (CryptoHives-AES-NI+PClMulV256) | 128B         |      60.15 ns |     0.329 ns |     0.308 ns |         - |
| Encrypt · AES-128-GCM (CryptoHives-AES-NI+PClMul)     | 128B         |      62.76 ns |     0.303 ns |     0.284 ns |         - |
| Encrypt · AES-128-GCM (OS)                            | 128B         |     119.19 ns |     0.812 ns |     0.720 ns |         - |
| Encrypt · AES-128-GCM (BouncyCastle)                  | 128B         |     715.42 ns |     4.601 ns |     4.303 ns |    1608 B |
| Encrypt · AES-128-GCM (CryptoHives-Scalar)            | 128B         |     801.64 ns |     5.322 ns |     4.978 ns |         - |
|                                                       |              |               |              |              |           |
| Decrypt · AES-128-GCM (CryptoHives-AES-NI+PClMul)     | 152B         |     120.25 ns |     0.661 ns |     0.586 ns |         - |
| Decrypt · AES-128-GCM (CryptoHives-AES-NI+PClMulV256) | 152B         |     123.77 ns |     0.900 ns |     0.842 ns |         - |
| Decrypt · AES-128-GCM (OS)                            | 152B         |     134.06 ns |     0.923 ns |     0.863 ns |         - |
| Decrypt · AES-128-GCM (BouncyCastle)                  | 152B         |     944.44 ns |     5.834 ns |     5.457 ns |    1624 B |
| Decrypt · AES-128-GCM (CryptoHives-Scalar)            | 152B         |   1,007.52 ns |     9.430 ns |     8.821 ns |         - |
|                                                       |              |               |              |              |           |
| Encrypt · AES-128-GCM (CryptoHives-AES-NI+PClMulV256) | 152B         |      89.56 ns |     0.238 ns |     0.199 ns |         - |
| Encrypt · AES-128-GCM (CryptoHives-AES-NI+PClMul)     | 152B         |      92.90 ns |     0.414 ns |     0.367 ns |         - |
| Encrypt · AES-128-GCM (OS)                            | 152B         |     134.62 ns |     0.896 ns |     0.838 ns |         - |
| Encrypt · AES-128-GCM (BouncyCastle)                  | 152B         |     835.78 ns |     6.042 ns |     5.652 ns |    1608 B |
| Encrypt · AES-128-GCM (CryptoHives-Scalar)            | 152B         |     968.62 ns |    11.190 ns |    10.467 ns |         - |
|                                                       |              |               |              |              |           |
| Decrypt · AES-128-GCM (CryptoHives-AES-NI+PClMulV256) | 256B         |     111.11 ns |     0.621 ns |     0.581 ns |         - |
| Decrypt · AES-128-GCM (CryptoHives-AES-NI+PClMul)     | 256B         |     119.13 ns |     0.952 ns |     0.844 ns |         - |
| Decrypt · AES-128-GCM (OS)                            | 256B         |     130.52 ns |     1.036 ns |     0.969 ns |         - |
| Decrypt · AES-128-GCM (BouncyCastle)                  | 256B         |   1,214.99 ns |     6.589 ns |     6.163 ns |    1624 B |
| Decrypt · AES-128-GCM (CryptoHives-Scalar)            | 256B         |   1,481.17 ns |     8.298 ns |     7.762 ns |         - |
|                                                       |              |               |              |              |           |
| Encrypt · AES-128-GCM (CryptoHives-AES-NI+PClMulV256) | 256B         |      77.14 ns |     0.371 ns |     0.347 ns |         - |
| Encrypt · AES-128-GCM (CryptoHives-AES-NI+PClMul)     | 256B         |      81.21 ns |     0.479 ns |     0.448 ns |         - |
| Encrypt · AES-128-GCM (OS)                            | 256B         |     123.20 ns |     0.787 ns |     0.657 ns |         - |
| Encrypt · AES-128-GCM (BouncyCastle)                  | 256B         |   1,118.82 ns |     4.572 ns |     3.818 ns |    1608 B |
| Encrypt · AES-128-GCM (CryptoHives-Scalar)            | 256B         |   1,453.86 ns |     7.651 ns |     6.782 ns |         - |
|                                                       |              |               |              |              |           |
| Decrypt · AES-128-GCM (OS)                            | 1KB          |     178.17 ns |     1.040 ns |     0.973 ns |         - |
| Decrypt · AES-128-GCM (CryptoHives-AES-NI+PClMulV256) | 1KB          |     198.56 ns |     1.236 ns |     1.095 ns |         - |
| Decrypt · AES-128-GCM (CryptoHives-AES-NI+PClMul)     | 1KB          |     238.73 ns |     1.247 ns |     1.166 ns |         - |
| Decrypt · AES-128-GCM (BouncyCastle)                  | 1KB          |   3,612.86 ns |    26.994 ns |    22.541 ns |    1624 B |
| Decrypt · AES-128-GCM (CryptoHives-Scalar)            | 1KB          |   5,393.77 ns |    32.703 ns |    27.308 ns |         - |
|                                                       |              |               |              |              |           |
| Encrypt · AES-128-GCM (OS)                            | 1KB          |     170.44 ns |     0.859 ns |     0.803 ns |         - |
| Encrypt · AES-128-GCM (CryptoHives-AES-NI+PClMulV256) | 1KB          |     175.07 ns |     0.950 ns |     0.842 ns |         - |
| Encrypt · AES-128-GCM (CryptoHives-AES-NI+PClMul)     | 1KB          |     198.96 ns |     0.773 ns |     0.723 ns |         - |
| Encrypt · AES-128-GCM (BouncyCastle)                  | 1KB          |   3,498.08 ns |    15.749 ns |    14.732 ns |    1608 B |
| Encrypt · AES-128-GCM (CryptoHives-Scalar)            | 1KB          |   6,042.66 ns |    33.159 ns |    31.017 ns |         - |
|                                                       |              |               |              |              |           |
| Decrypt · AES-128-GCM (OS)                            | 8KB          |     689.69 ns |     5.119 ns |     4.788 ns |         - |
| Decrypt · AES-128-GCM (CryptoHives-AES-NI+PClMulV256) | 8KB          |   1,021.17 ns |     7.801 ns |     7.297 ns |         - |
| Decrypt · AES-128-GCM (CryptoHives-AES-NI+PClMul)     | 8KB          |   1,376.38 ns |    11.727 ns |     9.793 ns |         - |
| Decrypt · AES-128-GCM (BouncyCastle)                  | 8KB          |  25,910.24 ns |    98.504 ns |    92.140 ns |    1624 B |
| Decrypt · AES-128-GCM (CryptoHives-Scalar)            | 8KB          |  41,968.37 ns |   335.503 ns |   313.830 ns |         - |
|                                                       |              |               |              |              |           |
| Encrypt · AES-128-GCM (OS)                            | 8KB          |     657.69 ns |     3.885 ns |     3.634 ns |         - |
| Encrypt · AES-128-GCM (CryptoHives-AES-NI+PClMulV256) | 8KB          |   1,097.79 ns |     7.656 ns |     7.162 ns |         - |
| Encrypt · AES-128-GCM (CryptoHives-AES-NI+PClMul)     | 8KB          |   1,314.66 ns |     7.578 ns |     7.088 ns |         - |
| Encrypt · AES-128-GCM (BouncyCastle)                  | 8KB          |  25,611.01 ns |   139.757 ns |   130.729 ns |    1608 B |
| Encrypt · AES-128-GCM (CryptoHives-Scalar)            | 8KB          |  41,857.10 ns |   276.584 ns |   258.717 ns |         - |
|                                                       |              |               |              |              |           |
| Decrypt · AES-128-GCM (OS)                            | 128KB        |  10,850.46 ns |    82.661 ns |    77.321 ns |         - |
| Decrypt · AES-128-GCM (CryptoHives-AES-NI+PClMulV256) | 128KB        |  15,819.36 ns |    95.923 ns |    89.726 ns |         - |
| Decrypt · AES-128-GCM (CryptoHives-AES-NI+PClMul)     | 128KB        |  21,037.63 ns |   123.963 ns |   109.890 ns |         - |
| Decrypt · AES-128-GCM (BouncyCastle)                  | 128KB        | 407,395.15 ns | 2,514.601 ns | 2,352.159 ns |    1624 B |
| Decrypt · AES-128-GCM (CryptoHives-Scalar)            | 128KB        | 669,367.26 ns | 3,587.522 ns | 3,180.244 ns |         - |
|                                                       |              |               |              |              |           |
| Encrypt · AES-128-GCM (OS)                            | 128KB        |   9,828.12 ns |    57.083 ns |    53.395 ns |         - |
| Encrypt · AES-128-GCM (CryptoHives-AES-NI+PClMulV256) | 128KB        |  17,046.21 ns |   131.798 ns |   123.284 ns |         - |
| Encrypt · AES-128-GCM (CryptoHives-AES-NI+PClMul)     | 128KB        |  20,395.14 ns |   178.594 ns |   167.057 ns |         - |
| Encrypt · AES-128-GCM (BouncyCastle)                  | 128KB        | 406,383.88 ns | 2,886.885 ns | 2,559.149 ns |    1608 B |
| Encrypt · AES-128-GCM (CryptoHives-Scalar)            | 128KB        | 669,312.93 ns | 4,971.049 ns | 4,406.706 ns |         - |