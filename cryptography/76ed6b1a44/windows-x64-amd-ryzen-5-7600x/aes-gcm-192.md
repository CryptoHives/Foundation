| Description                                           | TestDataSize | Mean          | Error         | StdDev        | Allocated |
|------------------------------------------------------ |------------- |--------------:|--------------:|--------------:|----------:|
| Decrypt · AES-192-GCM (CryptoHives-AES-NI+PClMul)     | 17B          |     120.95 ns |      2.376 ns |      2.440 ns |         - |
| Decrypt · AES-192-GCM (CryptoHives-AES-NI+PClMulV256) | 17B          |     121.20 ns |      2.337 ns |      2.691 ns |         - |
| Decrypt · AES-192-GCM (OS)                            | 17B          |     128.08 ns |      2.241 ns |      2.096 ns |         - |
| Decrypt · AES-192-GCM (CryptoHives-Scalar)            | 17B          |     394.28 ns |      6.815 ns |     10.201 ns |         - |
| Decrypt · AES-192-GCM (BouncyCastle)                  | 17B          |     702.23 ns |      9.815 ns |      8.196 ns |    1728 B |
|                                                       |              |               |               |               |           |
| Encrypt · AES-192-GCM (CryptoHives-AES-NI+PClMul)     | 17B          |      68.20 ns |      0.888 ns |      0.787 ns |         - |
| Encrypt · AES-192-GCM (CryptoHives-AES-NI+PClMulV256) | 17B          |      68.80 ns |      1.387 ns |      1.484 ns |         - |
| Encrypt · AES-192-GCM (OS)                            | 17B          |     131.08 ns |      2.484 ns |      2.761 ns |         - |
| Encrypt · AES-192-GCM (CryptoHives-Scalar)            | 17B          |     356.48 ns |      7.103 ns |      9.482 ns |         - |
| Encrypt · AES-192-GCM (BouncyCastle)                  | 17B          |     611.84 ns |     12.070 ns |     16.521 ns |    1712 B |
|                                                       |              |               |               |               |           |
| Decrypt · AES-192-GCM (CryptoHives-AES-NI+PClMulV256) | 65B          |     116.34 ns |      1.575 ns |      1.474 ns |         - |
| Decrypt · AES-192-GCM (CryptoHives-AES-NI+PClMul)     | 65B          |     116.85 ns |      1.872 ns |      1.751 ns |         - |
| Decrypt · AES-192-GCM (OS)                            | 65B          |     127.40 ns |      2.249 ns |      2.104 ns |         - |
| Decrypt · AES-192-GCM (CryptoHives-Scalar)            | 65B          |     653.40 ns |     11.668 ns |     13.436 ns |         - |
| Decrypt · AES-192-GCM (BouncyCastle)                  | 65B          |     886.73 ns |     14.037 ns |     12.444 ns |    1728 B |
|                                                       |              |               |               |               |           |
| Encrypt · AES-192-GCM (CryptoHives-AES-NI+PClMul)     | 65B          |      75.60 ns |      1.040 ns |      0.922 ns |         - |
| Encrypt · AES-192-GCM (CryptoHives-AES-NI+PClMulV256) | 65B          |      75.93 ns |      1.465 ns |      1.439 ns |         - |
| Encrypt · AES-192-GCM (OS)                            | 65B          |     135.72 ns |      2.624 ns |      2.577 ns |         - |
| Encrypt · AES-192-GCM (CryptoHives-Scalar)            | 65B          |     626.51 ns |     12.140 ns |     13.493 ns |         - |
| Encrypt · AES-192-GCM (BouncyCastle)                  | 65B          |     787.63 ns |     14.040 ns |     13.133 ns |    1712 B |
|                                                       |              |               |               |               |           |
| Decrypt · AES-192-GCM (CryptoHives-AES-NI+PClMul)     | 128B         |      99.91 ns |      0.766 ns |      0.640 ns |         - |
| Decrypt · AES-192-GCM (CryptoHives-AES-NI+PClMulV256) | 128B         |     100.74 ns |      1.169 ns |      1.094 ns |         - |
| Decrypt · AES-192-GCM (OS)                            | 128B         |     125.60 ns |      2.384 ns |      2.341 ns |         - |
| Decrypt · AES-192-GCM (CryptoHives-Scalar)            | 128B         |     930.73 ns |     18.588 ns |     19.889 ns |         - |
| Decrypt · AES-192-GCM (BouncyCastle)                  | 128B         |   1,058.67 ns |     20.582 ns |     22.022 ns |    1728 B |
|                                                       |              |               |               |               |           |
| Encrypt · AES-192-GCM (CryptoHives-AES-NI+PClMulV256) | 128B         |      62.86 ns |      1.210 ns |      1.242 ns |         - |
| Encrypt · AES-192-GCM (CryptoHives-AES-NI+PClMul)     | 128B         |      65.03 ns |      0.649 ns |      0.507 ns |         - |
| Encrypt · AES-192-GCM (OS)                            | 128B         |     128.21 ns |      2.546 ns |      2.382 ns |         - |
| Encrypt · AES-192-GCM (CryptoHives-Scalar)            | 128B         |     899.09 ns |     17.020 ns |     15.087 ns |         - |
| Encrypt · AES-192-GCM (BouncyCastle)                  | 128B         |     963.87 ns |     18.765 ns |     20.078 ns |    1712 B |
|                                                       |              |               |               |               |           |
| Decrypt · AES-192-GCM (CryptoHives-AES-NI+PClMulV256) | 152B         |     128.83 ns |      2.185 ns |      2.043 ns |         - |
| Decrypt · AES-192-GCM (CryptoHives-AES-NI+PClMul)     | 152B         |     132.76 ns |      1.137 ns |      0.949 ns |         - |
| Decrypt · AES-192-GCM (OS)                            | 152B         |     147.03 ns |      2.654 ns |      2.482 ns |         - |
| Decrypt · AES-192-GCM (CryptoHives-Scalar)            | 152B         |   1,126.01 ns |     21.387 ns |     21.005 ns |         - |
| Decrypt · AES-192-GCM (BouncyCastle)                  | 152B         |   1,212.28 ns |     23.505 ns |     28.866 ns |    1728 B |
|                                                       |              |               |               |               |           |
| Encrypt · AES-192-GCM (CryptoHives-AES-NI+PClMulV256) | 152B         |      90.91 ns |      1.354 ns |      1.201 ns |         - |
| Encrypt · AES-192-GCM (CryptoHives-AES-NI+PClMul)     | 152B         |      94.31 ns |      1.883 ns |      1.934 ns |         - |
| Encrypt · AES-192-GCM (OS)                            | 152B         |     144.20 ns |      1.395 ns |      1.165 ns |         - |
| Encrypt · AES-192-GCM (BouncyCastle)                  | 152B         |   1,086.55 ns |     11.756 ns |     10.997 ns |    1712 B |
| Encrypt · AES-192-GCM (CryptoHives-Scalar)            | 152B         |   1,095.62 ns |     21.205 ns |     23.570 ns |         - |
|                                                       |              |               |               |               |           |
| Decrypt · AES-192-GCM (CryptoHives-AES-NI+PClMulV256) | 256B         |     118.67 ns |      1.961 ns |      1.834 ns |         - |
| Decrypt · AES-192-GCM (CryptoHives-AES-NI+PClMul)     | 256B         |     130.96 ns |      2.350 ns |      2.198 ns |         - |
| Decrypt · AES-192-GCM (OS)                            | 256B         |     141.15 ns |      2.006 ns |      1.876 ns |         - |
| Decrypt · AES-192-GCM (BouncyCastle)                  | 256B         |   1,534.63 ns |     17.770 ns |     16.622 ns |    1728 B |
| Decrypt · AES-192-GCM (CryptoHives-Scalar)            | 256B         |   1,644.79 ns |     14.288 ns |     11.931 ns |         - |
|                                                       |              |               |               |               |           |
| Encrypt · AES-192-GCM (CryptoHives-AES-NI+PClMulV256) | 256B         |      81.44 ns |      0.825 ns |      0.771 ns |         - |
| Encrypt · AES-192-GCM (CryptoHives-AES-NI+PClMul)     | 256B         |      86.54 ns |      0.858 ns |      0.802 ns |         - |
| Encrypt · AES-192-GCM (OS)                            | 256B         |     135.02 ns |      1.086 ns |      0.963 ns |         - |
| Encrypt · AES-192-GCM (BouncyCastle)                  | 256B         |   1,421.64 ns |     14.556 ns |     13.616 ns |    1712 B |
| Encrypt · AES-192-GCM (CryptoHives-Scalar)            | 256B         |   1,626.45 ns |     15.925 ns |     14.117 ns |         - |
|                                                       |              |               |               |               |           |
| Decrypt · AES-192-GCM (OS)                            | 1KB          |     201.82 ns |      4.008 ns |      3.936 ns |         - |
| Decrypt · AES-192-GCM (CryptoHives-AES-NI+PClMulV256) | 1KB          |     212.83 ns |      3.818 ns |      3.571 ns |         - |
| Decrypt · AES-192-GCM (CryptoHives-AES-NI+PClMul)     | 1KB          |     266.36 ns |      4.397 ns |      4.113 ns |         - |
| Decrypt · AES-192-GCM (BouncyCastle)                  | 1KB          |   4,436.19 ns |     82.200 ns |     80.731 ns |    1728 B |
| Decrypt · AES-192-GCM (CryptoHives-Scalar)            | 1KB          |   6,047.13 ns |     71.144 ns |     63.067 ns |         - |
|                                                       |              |               |               |               |           |
| Encrypt · AES-192-GCM (OS)                            | 1KB          |     188.19 ns |      3.676 ns |      3.259 ns |         - |
| Encrypt · AES-192-GCM (CryptoHives-AES-NI+PClMulV256) | 1KB          |     192.80 ns |      1.629 ns |      1.524 ns |         - |
| Encrypt · AES-192-GCM (CryptoHives-AES-NI+PClMul)     | 1KB          |     214.18 ns |      1.730 ns |      1.618 ns |         - |
| Encrypt · AES-192-GCM (BouncyCastle)                  | 1KB          |   4,351.48 ns |     82.849 ns |     85.079 ns |    1712 B |
| Encrypt · AES-192-GCM (CryptoHives-Scalar)            | 1KB          |   6,027.21 ns |     91.044 ns |     85.163 ns |         - |
|                                                       |              |               |               |               |           |
| Decrypt · AES-192-GCM (OS)                            | 8KB          |     838.64 ns |     15.821 ns |     14.799 ns |         - |
| Decrypt · AES-192-GCM (CryptoHives-AES-NI+PClMulV256) | 8KB          |   1,123.26 ns |     17.752 ns |     15.737 ns |         - |
| Decrypt · AES-192-GCM (CryptoHives-AES-NI+PClMul)     | 8KB          |   1,540.66 ns |     30.440 ns |     29.896 ns |         - |
| Decrypt · AES-192-GCM (BouncyCastle)                  | 8KB          |  31,999.31 ns |    638.334 ns |    974.804 ns |    1728 B |
| Decrypt · AES-192-GCM (CryptoHives-Scalar)            | 8KB          |  47,227.81 ns |    819.517 ns |    766.577 ns |         - |
|                                                       |              |               |               |               |           |
| Encrypt · AES-192-GCM (OS)                            | 8KB          |     719.69 ns |     13.878 ns |     17.044 ns |         - |
| Encrypt · AES-192-GCM (CryptoHives-AES-NI+PClMulV256) | 8KB          |   1,260.63 ns |     25.204 ns |     24.754 ns |         - |
| Encrypt · AES-192-GCM (CryptoHives-AES-NI+PClMul)     | 8KB          |   1,429.44 ns |     28.210 ns |     30.185 ns |         - |
| Encrypt · AES-192-GCM (BouncyCastle)                  | 8KB          |  30,999.88 ns |    474.427 ns |    420.567 ns |    1712 B |
| Encrypt · AES-192-GCM (CryptoHives-Scalar)            | 8KB          |  47,098.46 ns |    926.024 ns |  1,029.273 ns |         - |
|                                                       |              |               |               |               |           |
| Decrypt · AES-192-GCM (OS)                            | 128KB        |  13,320.57 ns |    256.902 ns |    324.898 ns |         - |
| Decrypt · AES-192-GCM (CryptoHives-AES-NI+PClMulV256) | 128KB        |  18,278.08 ns |    351.159 ns |    480.671 ns |         - |
| Decrypt · AES-192-GCM (CryptoHives-AES-NI+PClMul)     | 128KB        |  24,358.78 ns |    469.228 ns |    438.917 ns |         - |
| Decrypt · AES-192-GCM (BouncyCastle)                  | 128KB        | 518,511.76 ns | 10,350.799 ns | 12,321.890 ns |    1728 B |
| Decrypt · AES-192-GCM (CryptoHives-Scalar)            | 128KB        | 795,957.06 ns | 15,815.995 ns | 15,533.422 ns |         - |
|                                                       |              |               |               |               |           |
| Encrypt · AES-192-GCM (OS)                            | 128KB        |  10,718.06 ns |    199.055 ns |    186.196 ns |         - |
| Encrypt · AES-192-GCM (CryptoHives-AES-NI+PClMulV256) | 128KB        |  19,381.53 ns |    360.848 ns |    354.401 ns |         - |
| Encrypt · AES-192-GCM (CryptoHives-AES-NI+PClMul)     | 128KB        |  22,394.91 ns |    432.143 ns |    404.227 ns |         - |
| Encrypt · AES-192-GCM (BouncyCastle)                  | 128KB        | 488,858.11 ns |  8,982.683 ns |  8,402.408 ns |    1712 B |
| Encrypt · AES-192-GCM (CryptoHives-Scalar)            | 128KB        | 753,256.12 ns | 13,557.271 ns | 12,681.480 ns |         - |