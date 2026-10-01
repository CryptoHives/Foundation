| Description                                           | TestDataSize | Mean          | Error         | StdDev       | Allocated |
|------------------------------------------------------ |------------- |--------------:|--------------:|-------------:|----------:|
| Decrypt · AES-128-GCM (CryptoHives-AES-NI+PClMulV256) | 17B          |     114.28 ns |      1.173 ns |     1.097 ns |         - |
| Decrypt · AES-128-GCM (CryptoHives-AES-NI+PClMul)     | 17B          |     114.78 ns |      1.215 ns |     1.136 ns |         - |
| Decrypt · AES-128-GCM (OS)                            | 17B          |     133.52 ns |      0.472 ns |     0.441 ns |         - |
| Decrypt · AES-128-GCM (CryptoHives-Scalar)            | 17B          |     389.09 ns |      4.813 ns |     4.502 ns |         - |
| Decrypt · AES-128-GCM (BouncyCastle)                  | 17B          |     569.30 ns |     10.799 ns |    17.742 ns |    1624 B |
|                                                       |              |               |               |              |           |
| Encrypt · AES-128-GCM (CryptoHives-AES-NI+PClMul)     | 17B          |      77.62 ns |      0.668 ns |     0.625 ns |         - |
| Encrypt · AES-128-GCM (CryptoHives-AES-NI+PClMulV256) | 17B          |      78.67 ns |      0.813 ns |     0.761 ns |         - |
| Encrypt · AES-128-GCM (OS)                            | 17B          |     141.91 ns |      1.675 ns |     1.567 ns |         - |
| Encrypt · AES-128-GCM (CryptoHives-Scalar)            | 17B          |     351.45 ns |      4.126 ns |     3.859 ns |         - |
| Encrypt · AES-128-GCM (BouncyCastle)                  | 17B          |     498.91 ns |      9.940 ns |    10.636 ns |    1608 B |
|                                                       |              |               |               |              |           |
| Decrypt · AES-128-GCM (CryptoHives-AES-NI+PClMul)     | 65B          |     107.26 ns |      0.241 ns |     0.225 ns |         - |
| Decrypt · AES-128-GCM (CryptoHives-AES-NI+PClMulV256) | 65B          |     108.22 ns |      0.303 ns |     0.284 ns |         - |
| Decrypt · AES-128-GCM (OS)                            | 65B          |     138.72 ns |      0.523 ns |     0.489 ns |         - |
| Decrypt · AES-128-GCM (CryptoHives-Scalar)            | 65B          |     648.90 ns |      1.483 ns |     1.315 ns |         - |
| Decrypt · AES-128-GCM (BouncyCastle)                  | 65B          |     752.50 ns |      1.362 ns |     1.137 ns |    1624 B |
|                                                       |              |               |               |              |           |
| Encrypt · AES-128-GCM (CryptoHives-AES-NI+PClMulV256) | 65B          |      84.58 ns |      0.907 ns |     0.849 ns |         - |
| Encrypt · AES-128-GCM (CryptoHives-AES-NI+PClMul)     | 65B          |      85.26 ns |      0.865 ns |     0.767 ns |         - |
| Encrypt · AES-128-GCM (OS)                            | 65B          |     145.12 ns |      0.739 ns |     0.655 ns |         - |
| Encrypt · AES-128-GCM (CryptoHives-Scalar)            | 65B          |     630.34 ns |      7.791 ns |     7.287 ns |         - |
| Encrypt · AES-128-GCM (BouncyCastle)                  | 65B          |     663.07 ns |      5.509 ns |     4.600 ns |    1608 B |
|                                                       |              |               |               |              |           |
| Decrypt · AES-128-GCM (CryptoHives-AES-NI+PClMul)     | 128B         |     110.44 ns |      0.226 ns |     0.212 ns |         - |
| Decrypt · AES-128-GCM (CryptoHives-AES-NI+PClMulV256) | 128B         |     113.92 ns |      0.906 ns |     0.757 ns |         - |
| Decrypt · AES-128-GCM (OS)                            | 128B         |     142.43 ns |      0.306 ns |     0.271 ns |         - |
| Decrypt · AES-128-GCM (BouncyCastle)                  | 128B         |     918.09 ns |      2.186 ns |     2.045 ns |    1624 B |
| Decrypt · AES-128-GCM (CryptoHives-Scalar)            | 128B         |     923.48 ns |      1.696 ns |     1.503 ns |         - |
|                                                       |              |               |               |              |           |
| Encrypt · AES-128-GCM (CryptoHives-AES-NI+PClMulV256) | 128B         |      72.24 ns |      0.676 ns |     0.633 ns |         - |
| Encrypt · AES-128-GCM (CryptoHives-AES-NI+PClMul)     | 128B         |      74.81 ns |      0.630 ns |     0.589 ns |         - |
| Encrypt · AES-128-GCM (OS)                            | 128B         |     138.84 ns |      2.766 ns |     2.310 ns |         - |
| Encrypt · AES-128-GCM (BouncyCastle)                  | 128B         |     848.13 ns |     16.964 ns |    22.058 ns |    1608 B |
| Encrypt · AES-128-GCM (CryptoHives-Scalar)            | 128B         |     914.61 ns |     10.029 ns |     9.381 ns |         - |
|                                                       |              |               |               |              |           |
| Decrypt · AES-128-GCM (CryptoHives-AES-NI+PClMul)     | 152B         |     126.11 ns |      0.450 ns |     0.399 ns |         - |
| Decrypt · AES-128-GCM (CryptoHives-AES-NI+PClMulV256) | 152B         |     127.29 ns |      0.520 ns |     0.487 ns |         - |
| Decrypt · AES-128-GCM (OS)                            | 152B         |     154.13 ns |      0.400 ns |     0.374 ns |         - |
| Decrypt · AES-128-GCM (BouncyCastle)                  | 152B         |   1,055.91 ns |      2.970 ns |     2.778 ns |    1624 B |
| Decrypt · AES-128-GCM (CryptoHives-Scalar)            | 152B         |   1,106.69 ns |      2.877 ns |     2.692 ns |         - |
|                                                       |              |               |               |              |           |
| Encrypt · AES-128-GCM (CryptoHives-AES-NI+PClMulV256) | 152B         |      98.74 ns |      0.768 ns |     0.681 ns |         - |
| Encrypt · AES-128-GCM (CryptoHives-AES-NI+PClMul)     | 152B         |     101.12 ns |      1.016 ns |     0.950 ns |         - |
| Encrypt · AES-128-GCM (OS)                            | 152B         |     158.60 ns |      1.959 ns |     1.833 ns |         - |
| Encrypt · AES-128-GCM (BouncyCastle)                  | 152B         |     979.85 ns |     15.197 ns |    14.216 ns |    1608 B |
| Encrypt · AES-128-GCM (CryptoHives-Scalar)            | 152B         |   1,091.19 ns |     16.298 ns |    15.245 ns |         - |
|                                                       |              |               |               |              |           |
| Decrypt · AES-128-GCM (CryptoHives-AES-NI+PClMulV256) | 256B         |     128.11 ns |      0.429 ns |     0.380 ns |         - |
| Decrypt · AES-128-GCM (OS)                            | 256B         |     146.10 ns |      0.332 ns |     0.310 ns |         - |
| Decrypt · AES-128-GCM (CryptoHives-AES-NI+PClMul)     | 256B         |     148.59 ns |      0.330 ns |     0.293 ns |         - |
| Decrypt · AES-128-GCM (BouncyCastle)                  | 256B         |   1,380.07 ns |      6.154 ns |     5.757 ns |    1624 B |
| Decrypt · AES-128-GCM (CryptoHives-Scalar)            | 256B         |   1,644.87 ns |      3.402 ns |     3.183 ns |         - |
|                                                       |              |               |               |              |           |
| Encrypt · AES-128-GCM (CryptoHives-AES-NI+PClMulV256) | 256B         |      91.27 ns |      0.833 ns |     0.780 ns |         - |
| Encrypt · AES-128-GCM (CryptoHives-AES-NI+PClMul)     | 256B         |      95.77 ns |      0.866 ns |     0.810 ns |         - |
| Encrypt · AES-128-GCM (OS)                            | 256B         |     145.90 ns |      0.972 ns |     0.909 ns |         - |
| Encrypt · AES-128-GCM (BouncyCastle)                  | 256B         |   1,309.08 ns |     22.518 ns |    21.063 ns |    1608 B |
| Encrypt · AES-128-GCM (CryptoHives-Scalar)            | 256B         |   1,644.13 ns |     21.312 ns |    19.936 ns |         - |
|                                                       |              |               |               |              |           |
| Decrypt · AES-128-GCM (OS)                            | 1KB          |     216.16 ns |      0.383 ns |     0.339 ns |         - |
| Decrypt · AES-128-GCM (CryptoHives-AES-NI+PClMulV256) | 1KB          |     230.37 ns |      0.356 ns |     0.315 ns |         - |
| Decrypt · AES-128-GCM (CryptoHives-AES-NI+PClMul)     | 1KB          |     288.27 ns |      0.628 ns |     0.556 ns |         - |
| Decrypt · AES-128-GCM (BouncyCastle)                  | 1KB          |   4,111.58 ns |     17.989 ns |    16.827 ns |    1624 B |
| Decrypt · AES-128-GCM (CryptoHives-Scalar)            | 1KB          |   6,037.06 ns |     10.412 ns |     8.695 ns |         - |
|                                                       |              |               |               |              |           |
| Encrypt · AES-128-GCM (OS)                            | 1KB          |     204.44 ns |      2.978 ns |     2.785 ns |         - |
| Encrypt · AES-128-GCM (CryptoHives-AES-NI+PClMulV256) | 1KB          |     206.27 ns |      2.061 ns |     1.928 ns |         - |
| Encrypt · AES-128-GCM (CryptoHives-AES-NI+PClMul)     | 1KB          |     235.31 ns |      2.684 ns |     2.510 ns |         - |
| Encrypt · AES-128-GCM (BouncyCastle)                  | 1KB          |   4,059.43 ns |     57.365 ns |    53.659 ns |    1608 B |
| Encrypt · AES-128-GCM (CryptoHives-Scalar)            | 1KB          |   6,064.11 ns |     79.608 ns |    74.466 ns |         - |
|                                                       |              |               |               |              |           |
| Decrypt · AES-128-GCM (OS)                            | 8KB          |     817.32 ns |      1.375 ns |     1.219 ns |         - |
| Decrypt · AES-128-GCM (CryptoHives-AES-NI+PClMulV256) | 8KB          |   1,174.09 ns |      4.823 ns |     4.276 ns |         - |
| Decrypt · AES-128-GCM (CryptoHives-AES-NI+PClMul)     | 8KB          |   1,603.79 ns |      3.798 ns |     3.172 ns |         - |
| Decrypt · AES-128-GCM (BouncyCastle)                  | 8KB          |  29,522.56 ns |     28.278 ns |    26.451 ns |    1624 B |
| Decrypt · AES-128-GCM (CryptoHives-Scalar)            | 8KB          |  46,588.16 ns |     83.872 ns |    74.350 ns |         - |
|                                                       |              |               |               |              |           |
| Encrypt · AES-128-GCM (OS)                            | 8KB          |     777.73 ns |     12.577 ns |    11.765 ns |         - |
| Encrypt · AES-128-GCM (CryptoHives-AES-NI+PClMulV256) | 8KB          |   1,286.08 ns |     15.804 ns |    14.783 ns |         - |
| Encrypt · AES-128-GCM (CryptoHives-AES-NI+PClMul)     | 8KB          |   1,541.56 ns |     18.761 ns |    17.549 ns |         - |
| Encrypt · AES-128-GCM (BouncyCastle)                  | 8KB          |  29,867.06 ns |    339.418 ns |   317.492 ns |    1608 B |
| Encrypt · AES-128-GCM (CryptoHives-Scalar)            | 8KB          |  47,415.11 ns |    729.107 ns |   682.008 ns |         - |
|                                                       |              |               |               |              |           |
| Decrypt · AES-128-GCM (OS)                            | 128KB        |  12,530.77 ns |     18.283 ns |    17.102 ns |         - |
| Decrypt · AES-128-GCM (CryptoHives-AES-NI+PClMulV256) | 128KB        |  18,232.12 ns |     41.954 ns |    39.244 ns |         - |
| Decrypt · AES-128-GCM (CryptoHives-AES-NI+PClMul)     | 128KB        |  24,336.70 ns |     55.904 ns |    52.292 ns |         - |
| Decrypt · AES-128-GCM (BouncyCastle)                  | 128KB        | 467,344.27 ns |    582.767 ns |   516.608 ns |    1624 B |
| Decrypt · AES-128-GCM (CryptoHives-Scalar)            | 128KB        | 761,545.80 ns |  1,368.862 ns | 1,213.460 ns |         - |
|                                                       |              |               |               |              |           |
| Encrypt · AES-128-GCM (OS)                            | 128KB        |  11,318.57 ns |    148.547 ns |   138.951 ns |         - |
| Encrypt · AES-128-GCM (CryptoHives-AES-NI+PClMulV256) | 128KB        |  20,059.91 ns |    345.560 ns |   323.237 ns |         - |
| Encrypt · AES-128-GCM (CryptoHives-AES-NI+PClMul)     | 128KB        |  24,218.60 ns |    380.475 ns |   355.897 ns |         - |
| Encrypt · AES-128-GCM (BouncyCastle)                  | 128KB        | 475,168.59 ns |  5,962.191 ns | 5,577.038 ns |    1608 B |
| Encrypt · AES-128-GCM (CryptoHives-Scalar)            | 128KB        | 758,006.35 ns | 10,123.393 ns | 9,469.428 ns |         - |