| Description                                           | TestDataSize | Mean          | Error         | StdDev        | Allocated |
|------------------------------------------------------ |------------- |--------------:|--------------:|--------------:|----------:|
| Decrypt · AES-128-GCM (OS)                            | 17B          |     120.90 ns |      1.311 ns |      1.227 ns |         - |
| Decrypt · AES-128-GCM (CryptoHives-AES-NI+PClMulV256) | 17B          |     125.18 ns |      2.521 ns |      2.698 ns |         - |
| Decrypt · AES-128-GCM (CryptoHives-AES-NI+PClMul)     | 17B          |     127.55 ns |      1.090 ns |      1.019 ns |         - |
| Decrypt · AES-128-GCM (CryptoHives-Scalar)            | 17B          |     355.45 ns |      2.956 ns |      2.468 ns |         - |
| Decrypt · AES-128-GCM (BouncyCastle)                  | 17B          |     621.57 ns |      7.004 ns |      6.552 ns |    1624 B |
|                                                       |              |               |               |               |           |
| Encrypt · AES-128-GCM (CryptoHives-AES-NI+PClMulV256) | 17B          |      65.77 ns |      0.272 ns |      0.255 ns |         - |
| Encrypt · AES-128-GCM (CryptoHives-AES-NI+PClMul)     | 17B          |      66.36 ns |      0.159 ns |      0.133 ns |         - |
| Encrypt · AES-128-GCM (OS)                            | 17B          |     128.19 ns |      1.205 ns |      1.127 ns |         - |
| Encrypt · AES-128-GCM (CryptoHives-Scalar)            | 17B          |     331.85 ns |      3.129 ns |      2.927 ns |         - |
| Encrypt · AES-128-GCM (BouncyCastle)                  | 17B          |     558.93 ns |      9.317 ns |      8.715 ns |    1608 B |
|                                                       |              |               |               |               |           |
| Decrypt · AES-128-GCM (CryptoHives-AES-NI+PClMulV256) | 65B          |     102.41 ns |      1.589 ns |      1.486 ns |         - |
| Decrypt · AES-128-GCM (CryptoHives-AES-NI+PClMul)     | 65B          |     105.78 ns |      1.125 ns |      0.998 ns |         - |
| Decrypt · AES-128-GCM (OS)                            | 65B          |     125.79 ns |      2.545 ns |      3.219 ns |         - |
| Decrypt · AES-128-GCM (CryptoHives-Scalar)            | 65B          |     628.58 ns |     11.961 ns |     10.604 ns |         - |
| Decrypt · AES-128-GCM (BouncyCastle)                  | 65B          |     849.11 ns |     16.198 ns |     21.624 ns |    1624 B |
|                                                       |              |               |               |               |           |
| Encrypt · AES-128-GCM (CryptoHives-AES-NI+PClMul)     | 65B          |      70.57 ns |      0.438 ns |      0.366 ns |         - |
| Encrypt · AES-128-GCM (CryptoHives-AES-NI+PClMulV256) | 65B          |      70.74 ns |      0.323 ns |      0.270 ns |         - |
| Encrypt · AES-128-GCM (OS)                            | 65B          |     131.19 ns |      0.615 ns |      0.575 ns |         - |
| Encrypt · AES-128-GCM (CryptoHives-Scalar)            | 65B          |     579.04 ns |      4.327 ns |      3.378 ns |         - |
| Encrypt · AES-128-GCM (BouncyCastle)                  | 65B          |     715.78 ns |     11.904 ns |     10.553 ns |    1608 B |
|                                                       |              |               |               |               |           |
| Decrypt · AES-128-GCM (CryptoHives-AES-NI+PClMulV256) | 128B         |      97.95 ns |      1.917 ns |      1.793 ns |         - |
| Decrypt · AES-128-GCM (CryptoHives-AES-NI+PClMul)     | 128B         |     100.12 ns |      0.658 ns |      0.550 ns |         - |
| Decrypt · AES-128-GCM (OS)                            | 128B         |     122.31 ns |      0.702 ns |      0.586 ns |         - |
| Decrypt · AES-128-GCM (CryptoHives-Scalar)            | 128B         |     859.02 ns |     10.048 ns |      9.399 ns |         - |
| Decrypt · AES-128-GCM (BouncyCastle)                  | 128B         |     957.60 ns |     11.804 ns |     11.042 ns |    1624 B |
|                                                       |              |               |               |               |           |
| Encrypt · AES-128-GCM (CryptoHives-AES-NI+PClMulV256) | 128B         |      59.45 ns |      0.404 ns |      0.378 ns |         - |
| Encrypt · AES-128-GCM (CryptoHives-AES-NI+PClMul)     | 128B         |      61.89 ns |      0.637 ns |      0.564 ns |         - |
| Encrypt · AES-128-GCM (OS)                            | 128B         |     125.36 ns |      1.561 ns |      1.460 ns |         - |
| Encrypt · AES-128-GCM (CryptoHives-Scalar)            | 128B         |     824.55 ns |     14.780 ns |     13.825 ns |         - |
| Encrypt · AES-128-GCM (BouncyCastle)                  | 128B         |     864.72 ns |     13.318 ns |     12.458 ns |    1608 B |
|                                                       |              |               |               |               |           |
| Decrypt · AES-128-GCM (CryptoHives-AES-NI+PClMulV256) | 152B         |     127.24 ns |      1.637 ns |      1.531 ns |         - |
| Decrypt · AES-128-GCM (CryptoHives-AES-NI+PClMul)     | 152B         |     129.91 ns |      1.466 ns |      1.371 ns |         - |
| Decrypt · AES-128-GCM (OS)                            | 152B         |     142.53 ns |      1.945 ns |      1.724 ns |         - |
| Decrypt · AES-128-GCM (CryptoHives-Scalar)            | 152B         |   1,043.02 ns |     18.180 ns |     17.006 ns |         - |
| Decrypt · AES-128-GCM (BouncyCastle)                  | 152B         |   1,100.54 ns |     14.216 ns |     13.297 ns |    1624 B |
|                                                       |              |               |               |               |           |
| Encrypt · AES-128-GCM (CryptoHives-AES-NI+PClMulV256) | 152B         |      86.29 ns |      1.724 ns |      1.693 ns |         - |
| Encrypt · AES-128-GCM (CryptoHives-AES-NI+PClMul)     | 152B         |      89.17 ns |      1.556 ns |      1.528 ns |         - |
| Encrypt · AES-128-GCM (OS)                            | 152B         |     139.99 ns |      1.302 ns |      1.218 ns |         - |
| Encrypt · AES-128-GCM (BouncyCastle)                  | 152B         |   1,010.19 ns |     20.000 ns |     18.708 ns |    1608 B |
| Encrypt · AES-128-GCM (CryptoHives-Scalar)            | 152B         |   1,023.17 ns |     20.331 ns |     22.598 ns |         - |
|                                                       |              |               |               |               |           |
| Decrypt · AES-128-GCM (CryptoHives-AES-NI+PClMulV256) | 256B         |     115.11 ns |      1.273 ns |      1.191 ns |         - |
| Decrypt · AES-128-GCM (CryptoHives-AES-NI+PClMul)     | 256B         |     133.64 ns |      2.699 ns |      3.510 ns |         - |
| Decrypt · AES-128-GCM (OS)                            | 256B         |     139.17 ns |      2.787 ns |      2.862 ns |         - |
| Decrypt · AES-128-GCM (BouncyCastle)                  | 256B         |   1,434.62 ns |     28.322 ns |     36.827 ns |    1624 B |
| Decrypt · AES-128-GCM (CryptoHives-Scalar)            | 256B         |   1,544.24 ns |     19.158 ns |     17.920 ns |         - |
|                                                       |              |               |               |               |           |
| Encrypt · AES-128-GCM (CryptoHives-AES-NI+PClMulV256) | 256B         |      76.63 ns |      1.201 ns |      1.124 ns |         - |
| Encrypt · AES-128-GCM (CryptoHives-AES-NI+PClMul)     | 256B         |      81.24 ns |      0.799 ns |      0.747 ns |         - |
| Encrypt · AES-128-GCM (OS)                            | 256B         |     133.52 ns |      2.645 ns |      3.959 ns |         - |
| Encrypt · AES-128-GCM (BouncyCastle)                  | 256B         |   1,297.97 ns |     23.544 ns |     22.023 ns |    1608 B |
| Encrypt · AES-128-GCM (CryptoHives-Scalar)            | 256B         |   1,515.08 ns |     17.327 ns |     16.208 ns |         - |
|                                                       |              |               |               |               |           |
| Decrypt · AES-128-GCM (OS)                            | 1KB          |     189.01 ns |      3.375 ns |      3.157 ns |         - |
| Decrypt · AES-128-GCM (CryptoHives-AES-NI+PClMulV256) | 1KB          |     207.78 ns |      4.134 ns |      4.922 ns |         - |
| Decrypt · AES-128-GCM (CryptoHives-AES-NI+PClMul)     | 1KB          |     265.17 ns |      4.488 ns |      4.198 ns |         - |
| Decrypt · AES-128-GCM (BouncyCastle)                  | 1KB          |   3,844.68 ns |     46.142 ns |     36.025 ns |    1624 B |
| Decrypt · AES-128-GCM (CryptoHives-Scalar)            | 1KB          |   5,760.38 ns |    109.675 ns |    107.715 ns |         - |
|                                                       |              |               |               |               |           |
| Encrypt · AES-128-GCM (CryptoHives-AES-NI+PClMulV256) | 1KB          |     179.05 ns |      3.480 ns |      3.418 ns |         - |
| Encrypt · AES-128-GCM (OS)                            | 1KB          |     184.82 ns |      2.815 ns |      2.495 ns |         - |
| Encrypt · AES-128-GCM (CryptoHives-AES-NI+PClMul)     | 1KB          |     207.94 ns |      4.151 ns |      4.076 ns |         - |
| Encrypt · AES-128-GCM (BouncyCastle)                  | 1KB          |   3,712.32 ns |     34.814 ns |     30.862 ns |    1608 B |
| Encrypt · AES-128-GCM (CryptoHives-Scalar)            | 1KB          |   5,997.45 ns |     65.878 ns |     61.622 ns |         - |
|                                                       |              |               |               |               |           |
| Decrypt · AES-128-GCM (OS)                            | 8KB          |     717.21 ns |     14.099 ns |     13.189 ns |         - |
| Decrypt · AES-128-GCM (CryptoHives-AES-NI+PClMulV256) | 8KB          |   1,073.78 ns |     15.036 ns |     13.329 ns |         - |
| Decrypt · AES-128-GCM (CryptoHives-AES-NI+PClMul)     | 8KB          |   1,467.09 ns |     28.733 ns |     28.219 ns |         - |
| Decrypt · AES-128-GCM (BouncyCastle)                  | 8KB          |  26,887.71 ns |    260.587 ns |    243.753 ns |    1624 B |
| Decrypt · AES-128-GCM (CryptoHives-Scalar)            | 8KB          |  43,639.69 ns |    494.512 ns |    462.566 ns |         - |
|                                                       |              |               |               |               |           |
| Encrypt · AES-128-GCM (OS)                            | 8KB          |     691.59 ns |     10.838 ns |     10.138 ns |         - |
| Encrypt · AES-128-GCM (CryptoHives-AES-NI+PClMulV256) | 8KB          |   1,152.68 ns |     14.763 ns |     13.810 ns |         - |
| Encrypt · AES-128-GCM (CryptoHives-AES-NI+PClMul)     | 8KB          |   1,361.15 ns |     13.827 ns |     12.934 ns |         - |
| Encrypt · AES-128-GCM (BouncyCastle)                  | 8KB          |  26,510.39 ns |    220.545 ns |    206.298 ns |    1608 B |
| Encrypt · AES-128-GCM (CryptoHives-Scalar)            | 8KB          |  43,119.14 ns |    207.101 ns |    183.590 ns |         - |
|                                                       |              |               |               |               |           |
| Decrypt · AES-128-GCM (OS)                            | 128KB        |  11,360.11 ns |    138.436 ns |    115.600 ns |         - |
| Decrypt · AES-128-GCM (CryptoHives-AES-NI+PClMulV256) | 128KB        |  16,465.23 ns |    255.352 ns |    238.856 ns |         - |
| Decrypt · AES-128-GCM (CryptoHives-AES-NI+PClMul)     | 128KB        |  21,794.01 ns |    369.365 ns |    345.505 ns |         - |
| Decrypt · AES-128-GCM (BouncyCastle)                  | 128KB        | 419,142.68 ns |  6,298.970 ns |  5,259.925 ns |    1624 B |
| Decrypt · AES-128-GCM (CryptoHives-Scalar)            | 128KB        | 700,467.03 ns | 13,642.634 ns | 13,398.891 ns |         - |
|                                                       |              |               |               |               |           |
| Encrypt · AES-128-GCM (OS)                            | 128KB        |  10,145.57 ns |    148.883 ns |    139.265 ns |         - |
| Encrypt · AES-128-GCM (CryptoHives-AES-NI+PClMulV256) | 128KB        |  17,575.66 ns |    182.644 ns |    161.909 ns |         - |
| Encrypt · AES-128-GCM (CryptoHives-AES-NI+PClMul)     | 128KB        |  21,014.08 ns |    232.972 ns |    217.922 ns |         - |
| Encrypt · AES-128-GCM (BouncyCastle)                  | 128KB        | 418,362.57 ns |  2,760.521 ns |  2,582.193 ns |    1608 B |
| Encrypt · AES-128-GCM (CryptoHives-Scalar)            | 128KB        | 688,774.13 ns |  8,493.157 ns |  7,944.504 ns |         - |