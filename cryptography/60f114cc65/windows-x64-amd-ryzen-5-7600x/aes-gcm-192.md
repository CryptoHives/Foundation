| Description                               | TestDataSize | Mean          | Error        | StdDev       | Allocated |
|------------------------------------------ |------------- |--------------:|-------------:|-------------:|----------:|
| Decrypt · AES-192-GCM (AES-NI+PClMulV256) | 17B          |     117.48 ns |     0.280 ns |     0.234 ns |         - |
| Decrypt · AES-192-GCM (AES-NI+PClMul)     | 17B          |     117.51 ns |     0.327 ns |     0.306 ns |         - |
| Decrypt · AES-192-GCM (OS)                | 17B          |     119.10 ns |     0.667 ns |     0.591 ns |         - |
| Decrypt · AES-192-GCM (Managed)           | 17B          |     362.57 ns |     2.464 ns |     2.304 ns |         - |
| Decrypt · AES-192-GCM (BouncyCastle)      | 17B          |     612.44 ns |     6.031 ns |     5.346 ns |    1728 B |
|                                           |              |               |              |              |           |
| Encrypt · AES-192-GCM (AES-NI+PClMulV256) | 17B          |      66.56 ns |     0.251 ns |     0.235 ns |         - |
| Encrypt · AES-192-GCM (AES-NI+PClMul)     | 17B          |      67.08 ns |     0.269 ns |     0.238 ns |         - |
| Encrypt · AES-192-GCM (OS)                | 17B          |     126.05 ns |     0.828 ns |     0.775 ns |         - |
| Encrypt · AES-192-GCM (Managed)           | 17B          |     331.92 ns |     1.967 ns |     1.642 ns |         - |
| Encrypt · AES-192-GCM (BouncyCastle)      | 17B          |     553.63 ns |     6.142 ns |     5.746 ns |    1712 B |
|                                           |              |               |              |              |           |
| Decrypt · AES-192-GCM (AES-NI+PClMul)     | 65B          |     105.70 ns |     0.480 ns |     0.426 ns |         - |
| Decrypt · AES-192-GCM (AES-NI+PClMulV256) | 65B          |     117.75 ns |     0.998 ns |     0.885 ns |         - |
| Decrypt · AES-192-GCM (OS)                | 65B          |     123.39 ns |     0.685 ns |     0.572 ns |         - |
| Decrypt · AES-192-GCM (Managed)           | 65B          |     627.14 ns |     3.803 ns |     3.371 ns |         - |
| Decrypt · AES-192-GCM (BouncyCastle)      | 65B          |     825.41 ns |     5.558 ns |     4.927 ns |    1728 B |
|                                           |              |               |              |              |           |
| Encrypt · AES-192-GCM (AES-NI+PClMul)     | 65B          |      73.08 ns |     0.291 ns |     0.258 ns |         - |
| Encrypt · AES-192-GCM (AES-NI+PClMulV256) | 65B          |      74.16 ns |     0.334 ns |     0.312 ns |         - |
| Encrypt · AES-192-GCM (OS)                | 65B          |     135.17 ns |     1.499 ns |     1.329 ns |         - |
| Encrypt · AES-192-GCM (Managed)           | 65B          |     597.56 ns |     5.352 ns |     5.006 ns |         - |
| Encrypt · AES-192-GCM (BouncyCastle)      | 65B          |     724.47 ns |     6.556 ns |     6.132 ns |    1712 B |
|                                           |              |               |              |              |           |
| Decrypt · AES-192-GCM (AES-NI+PClMul)     | 128B         |      98.89 ns |     0.695 ns |     0.650 ns |         - |
| Decrypt · AES-192-GCM (AES-NI+PClMulV256) | 128B         |     103.32 ns |     0.477 ns |     0.423 ns |         - |
| Decrypt · AES-192-GCM (OS)                | 128B         |     121.07 ns |     0.771 ns |     0.721 ns |         - |
| Decrypt · AES-192-GCM (Managed)           | 128B         |     888.24 ns |     3.249 ns |     2.713 ns |         - |
| Decrypt · AES-192-GCM (BouncyCastle)      | 128B         |     976.30 ns |    13.839 ns |    12.268 ns |    1728 B |
|                                           |              |               |              |              |           |
| Encrypt · AES-192-GCM (AES-NI+PClMulV256) | 128B         |      60.22 ns |     0.334 ns |     0.312 ns |         - |
| Encrypt · AES-192-GCM (AES-NI+PClMul)     | 128B         |      62.51 ns |     0.608 ns |     0.569 ns |         - |
| Encrypt · AES-192-GCM (OS)                | 128B         |     122.48 ns |     1.103 ns |     1.032 ns |         - |
| Encrypt · AES-192-GCM (Managed)           | 128B         |     861.04 ns |     4.950 ns |     4.630 ns |         - |
| Encrypt · AES-192-GCM (BouncyCastle)      | 128B         |     886.16 ns |     5.980 ns |     5.594 ns |    1712 B |
|                                           |              |               |              |              |           |
| Decrypt · AES-192-GCM (AES-NI+PClMul)     | 152B         |     126.39 ns |     0.795 ns |     0.705 ns |         - |
| Decrypt · AES-192-GCM (AES-NI+PClMulV256) | 152B         |     130.49 ns |     0.983 ns |     0.872 ns |         - |
| Decrypt · AES-192-GCM (OS)                | 152B         |     138.63 ns |     0.855 ns |     0.800 ns |         - |
| Decrypt · AES-192-GCM (Managed)           | 152B         |   1,073.72 ns |     4.856 ns |     4.305 ns |         - |
| Decrypt · AES-192-GCM (BouncyCastle)      | 152B         |   1,121.34 ns |    11.055 ns |    10.341 ns |    1728 B |
|                                           |              |               |              |              |           |
| Encrypt · AES-192-GCM (AES-NI+PClMulV256) | 152B         |      87.42 ns |     0.452 ns |     0.353 ns |         - |
| Encrypt · AES-192-GCM (AES-NI+PClMul)     | 152B         |      89.71 ns |     0.385 ns |     0.360 ns |         - |
| Encrypt · AES-192-GCM (OS)                | 152B         |     140.15 ns |     1.082 ns |     0.959 ns |         - |
| Encrypt · AES-192-GCM (BouncyCastle)      | 152B         |   1,022.01 ns |     6.540 ns |     5.797 ns |    1712 B |
| Encrypt · AES-192-GCM (Managed)           | 152B         |   1,037.02 ns |     7.854 ns |     6.963 ns |         - |
|                                           |              |               |              |              |           |
| Decrypt · AES-192-GCM (AES-NI+PClMulV256) | 256B         |     117.79 ns |     1.045 ns |     0.926 ns |         - |
| Decrypt · AES-192-GCM (AES-NI+PClMul)     | 256B         |     121.66 ns |     1.107 ns |     0.981 ns |         - |
| Decrypt · AES-192-GCM (OS)                | 256B         |     131.09 ns |     0.938 ns |     0.878 ns |         - |
| Decrypt · AES-192-GCM (BouncyCastle)      | 256B         |   1,446.97 ns |    12.454 ns |    11.649 ns |    1728 B |
| Decrypt · AES-192-GCM (Managed)           | 256B         |   1,588.42 ns |    10.390 ns |     9.719 ns |         - |
|                                           |              |               |              |              |           |
| Encrypt · AES-192-GCM (AES-NI+PClMulV256) | 256B         |      78.86 ns |     0.214 ns |     0.189 ns |         - |
| Encrypt · AES-192-GCM (AES-NI+PClMul)     | 256B         |      83.69 ns |     0.570 ns |     0.476 ns |         - |
| Encrypt · AES-192-GCM (OS)                | 256B         |     125.95 ns |     0.674 ns |     0.597 ns |         - |
| Encrypt · AES-192-GCM (BouncyCastle)      | 256B         |   1,352.25 ns |    16.868 ns |    13.169 ns |    1712 B |
| Encrypt · AES-192-GCM (Managed)           | 256B         |   1,561.89 ns |     5.326 ns |     4.721 ns |         - |
|                                           |              |               |              |              |           |
| Decrypt · AES-192-GCM (OS)                | 1KB          |     189.61 ns |     1.256 ns |     1.175 ns |         - |
| Decrypt · AES-192-GCM (AES-NI+PClMulV256) | 1KB          |     209.12 ns |     1.198 ns |     1.120 ns |         - |
| Decrypt · AES-192-GCM (AES-NI+PClMul)     | 1KB          |     251.54 ns |     2.490 ns |     2.207 ns |         - |
| Decrypt · AES-192-GCM (BouncyCastle)      | 1KB          |   4,180.02 ns |    42.542 ns |    35.524 ns |    1728 B |
| Decrypt · AES-192-GCM (Managed)           | 1KB          |   5,798.63 ns |    48.916 ns |    43.362 ns |         - |
|                                           |              |               |              |              |           |
| Encrypt · AES-192-GCM (OS)                | 1KB          |     179.60 ns |     2.727 ns |     2.277 ns |         - |
| Encrypt · AES-192-GCM (AES-NI+PClMulV256) | 1KB          |     187.88 ns |     0.849 ns |     0.752 ns |         - |
| Encrypt · AES-192-GCM (AES-NI+PClMul)     | 1KB          |     206.96 ns |     1.549 ns |     1.449 ns |         - |
| Encrypt · AES-192-GCM (BouncyCastle)      | 1KB          |   4,122.48 ns |    36.014 ns |    33.688 ns |    1712 B |
| Encrypt · AES-192-GCM (Managed)           | 1KB          |   5,790.42 ns |    28.124 ns |    23.485 ns |         - |
|                                           |              |               |              |              |           |
| Decrypt · AES-192-GCM (OS)                | 8KB          |     756.75 ns |     5.969 ns |     4.985 ns |         - |
| Decrypt · AES-192-GCM (AES-NI+PClMulV256) | 8KB          |   1,066.21 ns |     5.738 ns |     5.086 ns |         - |
| Decrypt · AES-192-GCM (AES-NI+PClMul)     | 8KB          |   1,462.09 ns |     6.368 ns |     5.645 ns |         - |
| Decrypt · AES-192-GCM (BouncyCastle)      | 8KB          |  29,757.30 ns |   125.765 ns |   111.487 ns |    1728 B |
| Decrypt · AES-192-GCM (Managed)           | 8KB          |  45,039.28 ns |   184.090 ns |   163.191 ns |         - |
|                                           |              |               |              |              |           |
| Encrypt · AES-192-GCM (OS)                | 8KB          |     687.21 ns |     5.210 ns |     4.618 ns |         - |
| Encrypt · AES-192-GCM (AES-NI+PClMulV256) | 8KB          |   1,196.75 ns |    10.057 ns |     9.408 ns |         - |
| Encrypt · AES-192-GCM (AES-NI+PClMul)     | 8KB          |   1,372.70 ns |    13.774 ns |    12.885 ns |         - |
| Encrypt · AES-192-GCM (BouncyCastle)      | 8KB          |  29,854.72 ns |   116.640 ns |   109.105 ns |    1712 B |
| Encrypt · AES-192-GCM (Managed)           | 8KB          |  45,133.44 ns |   259.213 ns |   242.468 ns |         - |
|                                           |              |               |              |              |           |
| Decrypt · AES-192-GCM (OS)                | 128KB        |  11,638.79 ns |    42.208 ns |    37.416 ns |         - |
| Decrypt · AES-192-GCM (AES-NI+PClMulV256) | 128KB        |  16,593.59 ns |   191.827 ns |   179.435 ns |         - |
| Decrypt · AES-192-GCM (AES-NI+PClMul)     | 128KB        |  22,211.61 ns |   138.667 ns |   129.709 ns |         - |
| Decrypt · AES-192-GCM (BouncyCastle)      | 128KB        | 469,761.72 ns | 3,282.997 ns | 2,910.291 ns |    1728 B |
| Decrypt · AES-192-GCM (Managed)           | 128KB        | 718,347.10 ns | 3,057.411 ns | 2,859.904 ns |         - |
|                                           |              |               |              |              |           |
| Encrypt · AES-192-GCM (OS)                | 128KB        |  10,207.86 ns |    67.903 ns |    63.517 ns |         - |
| Encrypt · AES-192-GCM (AES-NI+PClMulV256) | 128KB        |  18,622.89 ns |   154.868 ns |   144.864 ns |         - |
| Encrypt · AES-192-GCM (AES-NI+PClMul)     | 128KB        |  21,280.21 ns |   139.051 ns |   123.265 ns |         - |
| Encrypt · AES-192-GCM (BouncyCastle)      | 128KB        | 468,968.62 ns | 2,738.187 ns | 2,561.302 ns |    1712 B |
| Encrypt · AES-192-GCM (Managed)           | 128KB        | 720,454.15 ns | 3,743.722 ns | 3,501.880 ns |         - |