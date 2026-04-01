| Description                               | TestDataSize | Mean          | Error        | StdDev       | Allocated |
|------------------------------------------ |------------- |--------------:|-------------:|-------------:|----------:|
| Decrypt · AES-192-GCM (AES-NI+PClMulV256) | 17B          |     105.91 ns |     0.257 ns |     0.228 ns |         - |
| Decrypt · AES-192-GCM (AES-NI+PClMul)     | 17B          |     106.22 ns |     0.426 ns |     0.398 ns |         - |
| Decrypt · AES-192-GCM (OS)                | 17B          |     118.06 ns |     0.637 ns |     0.596 ns |         - |
| Decrypt · AES-192-GCM (Managed)           | 17B          |     360.41 ns |     0.989 ns |     0.772 ns |         - |
| Decrypt · AES-192-GCM (BouncyCastle)      | 17B          |     602.39 ns |     4.475 ns |     4.186 ns |    1728 B |
|                                           |              |               |              |              |           |
| Encrypt · AES-192-GCM (AES-NI+PClMulV256) | 17B          |      66.04 ns |     0.185 ns |     0.173 ns |         - |
| Encrypt · AES-192-GCM (AES-NI+PClMul)     | 17B          |      66.27 ns |     0.247 ns |     0.231 ns |         - |
| Encrypt · AES-192-GCM (OS)                | 17B          |     125.46 ns |     0.659 ns |     0.616 ns |         - |
| Encrypt · AES-192-GCM (Managed)           | 17B          |     326.77 ns |     1.672 ns |     1.564 ns |         - |
| Encrypt · AES-192-GCM (BouncyCastle)      | 17B          |     550.55 ns |     2.682 ns |     2.508 ns |    1712 B |
|                                           |              |               |              |              |           |
| Decrypt · AES-192-GCM (AES-NI+PClMulV256) | 65B          |     103.80 ns |     0.357 ns |     0.334 ns |         - |
| Decrypt · AES-192-GCM (AES-NI+PClMul)     | 65B          |     106.50 ns |     0.568 ns |     0.504 ns |         - |
| Decrypt · AES-192-GCM (OS)                | 65B          |     123.77 ns |     0.418 ns |     0.391 ns |         - |
| Decrypt · AES-192-GCM (Managed)           | 65B          |     625.27 ns |     2.828 ns |     2.646 ns |         - |
| Decrypt · AES-192-GCM (BouncyCastle)      | 65B          |     809.36 ns |     3.047 ns |     2.701 ns |    1728 B |
|                                           |              |               |              |              |           |
| Encrypt · AES-192-GCM (AES-NI+PClMul)     | 65B          |      73.00 ns |     0.427 ns |     0.399 ns |         - |
| Encrypt · AES-192-GCM (AES-NI+PClMulV256) | 65B          |      73.43 ns |     0.380 ns |     0.355 ns |         - |
| Encrypt · AES-192-GCM (OS)                | 65B          |     127.68 ns |     0.408 ns |     0.381 ns |         - |
| Encrypt · AES-192-GCM (Managed)           | 65B          |     588.70 ns |     2.439 ns |     2.162 ns |         - |
| Encrypt · AES-192-GCM (BouncyCastle)      | 65B          |     716.15 ns |     2.949 ns |     2.614 ns |    1712 B |
|                                           |              |               |              |              |           |
| Decrypt · AES-192-GCM (AES-NI+PClMulV256) | 128B         |     105.56 ns |     0.655 ns |     0.581 ns |         - |
| Decrypt · AES-192-GCM (AES-NI+PClMul)     | 128B         |     111.23 ns |     0.779 ns |     0.729 ns |         - |
| Decrypt · AES-192-GCM (OS)                | 128B         |     119.17 ns |     0.718 ns |     0.671 ns |         - |
| Decrypt · AES-192-GCM (Managed)           | 128B         |     883.02 ns |     2.748 ns |     2.571 ns |         - |
| Decrypt · AES-192-GCM (BouncyCastle)      | 128B         |     987.49 ns |     5.565 ns |     5.205 ns |    1728 B |
|                                           |              |               |              |              |           |
| Encrypt · AES-192-GCM (AES-NI+PClMulV256) | 128B         |      59.96 ns |     0.221 ns |     0.206 ns |         - |
| Encrypt · AES-192-GCM (AES-NI+PClMul)     | 128B         |      62.26 ns |     0.214 ns |     0.189 ns |         - |
| Encrypt · AES-192-GCM (OS)                | 128B         |     122.73 ns |     0.545 ns |     0.510 ns |         - |
| Encrypt · AES-192-GCM (Managed)           | 128B         |     851.09 ns |     5.556 ns |     5.197 ns |         - |
| Encrypt · AES-192-GCM (BouncyCastle)      | 128B         |     880.26 ns |     4.912 ns |     4.594 ns |    1712 B |
|                                           |              |               |              |              |           |
| Decrypt · AES-192-GCM (AES-NI+PClMulV256) | 152B         |     124.49 ns |     0.607 ns |     0.538 ns |         - |
| Decrypt · AES-192-GCM (AES-NI+PClMul)     | 152B         |     126.86 ns |     0.361 ns |     0.302 ns |         - |
| Decrypt · AES-192-GCM (OS)                | 152B         |     145.64 ns |     0.639 ns |     0.598 ns |         - |
| Decrypt · AES-192-GCM (Managed)           | 152B         |   1,052.51 ns |     3.535 ns |     2.952 ns |         - |
| Decrypt · AES-192-GCM (BouncyCastle)      | 152B         |   1,104.38 ns |     7.629 ns |     7.136 ns |    1728 B |
|                                           |              |               |              |              |           |
| Encrypt · AES-192-GCM (AES-NI+PClMulV256) | 152B         |      87.23 ns |     0.318 ns |     0.282 ns |         - |
| Encrypt · AES-192-GCM (AES-NI+PClMul)     | 152B         |      88.65 ns |     0.452 ns |     0.401 ns |         - |
| Encrypt · AES-192-GCM (OS)                | 152B         |     137.30 ns |     0.695 ns |     0.651 ns |         - |
| Encrypt · AES-192-GCM (BouncyCastle)      | 152B         |   1,008.18 ns |     6.388 ns |     5.976 ns |    1712 B |
| Encrypt · AES-192-GCM (Managed)           | 152B         |   1,021.50 ns |     5.500 ns |     4.593 ns |         - |
|                                           |              |               |              |              |           |
| Decrypt · AES-192-GCM (AES-NI+PClMulV256) | 256B         |     114.10 ns |     0.436 ns |     0.408 ns |         - |
| Decrypt · AES-192-GCM (AES-NI+PClMul)     | 256B         |     127.45 ns |     0.725 ns |     0.643 ns |         - |
| Decrypt · AES-192-GCM (OS)                | 256B         |     128.91 ns |     0.607 ns |     0.538 ns |         - |
| Decrypt · AES-192-GCM (BouncyCastle)      | 256B         |   1,438.80 ns |     6.776 ns |     6.339 ns |    1728 B |
| Decrypt · AES-192-GCM (Managed)           | 256B         |   1,572.05 ns |     8.249 ns |     6.888 ns |         - |
|                                           |              |               |              |              |           |
| Encrypt · AES-192-GCM (AES-NI+PClMulV256) | 256B         |      77.67 ns |     0.191 ns |     0.160 ns |         - |
| Encrypt · AES-192-GCM (AES-NI+PClMul)     | 256B         |      83.38 ns |     0.305 ns |     0.271 ns |         - |
| Encrypt · AES-192-GCM (OS)                | 256B         |     124.39 ns |     0.484 ns |     0.429 ns |         - |
| Encrypt · AES-192-GCM (BouncyCastle)      | 256B         |   1,330.59 ns |     6.732 ns |     5.968 ns |    1712 B |
| Encrypt · AES-192-GCM (Managed)           | 256B         |   1,541.04 ns |     8.856 ns |     8.284 ns |         - |
|                                           |              |               |              |              |           |
| Decrypt · AES-192-GCM (OS)                | 1KB          |     186.56 ns |     0.633 ns |     0.592 ns |         - |
| Decrypt · AES-192-GCM (AES-NI+PClMulV256) | 1KB          |     207.95 ns |     1.180 ns |     1.046 ns |         - |
| Decrypt · AES-192-GCM (AES-NI+PClMul)     | 1KB          |     254.63 ns |     1.238 ns |     1.098 ns |         - |
| Decrypt · AES-192-GCM (BouncyCastle)      | 1KB          |   4,145.35 ns |    19.536 ns |    17.318 ns |    1728 B |
| Decrypt · AES-192-GCM (Managed)           | 1KB          |   5,758.13 ns |    43.629 ns |    38.676 ns |         - |
|                                           |              |               |              |              |           |
| Encrypt · AES-192-GCM (OS)                | 1KB          |     174.77 ns |     0.923 ns |     0.819 ns |         - |
| Encrypt · AES-192-GCM (AES-NI+PClMulV256) | 1KB          |     185.61 ns |     0.532 ns |     0.498 ns |         - |
| Encrypt · AES-192-GCM (AES-NI+PClMul)     | 1KB          |     205.37 ns |     0.722 ns |     0.640 ns |         - |
| Encrypt · AES-192-GCM (BouncyCastle)      | 1KB          |   4,103.11 ns |    37.661 ns |    35.228 ns |    1712 B |
| Encrypt · AES-192-GCM (Managed)           | 1KB          |   5,705.90 ns |    25.707 ns |    22.788 ns |         - |
|                                           |              |               |              |              |           |
| Decrypt · AES-192-GCM (OS)                | 8KB          |     780.13 ns |     4.673 ns |     4.371 ns |         - |
| Decrypt · AES-192-GCM (AES-NI+PClMulV256) | 8KB          |   1,065.81 ns |     5.804 ns |     4.846 ns |         - |
| Decrypt · AES-192-GCM (AES-NI+PClMul)     | 8KB          |   1,465.01 ns |     6.443 ns |     5.381 ns |         - |
| Decrypt · AES-192-GCM (BouncyCastle)      | 8KB          |  29,478.84 ns |    88.623 ns |    82.898 ns |    1728 B |
| Decrypt · AES-192-GCM (Managed)           | 8KB          |  44,667.82 ns |   282.174 ns |   263.946 ns |         - |
|                                           |              |               |              |              |           |
| Encrypt · AES-192-GCM (OS)                | 8KB          |     691.27 ns |     2.886 ns |     2.558 ns |         - |
| Encrypt · AES-192-GCM (AES-NI+PClMulV256) | 8KB          |   1,206.25 ns |     5.555 ns |     4.925 ns |         - |
| Encrypt · AES-192-GCM (AES-NI+PClMul)     | 8KB          |   1,360.40 ns |     5.647 ns |     5.006 ns |         - |
| Encrypt · AES-192-GCM (BouncyCastle)      | 8KB          |  29,302.83 ns |    87.959 ns |    82.277 ns |    1712 B |
| Encrypt · AES-192-GCM (Managed)           | 8KB          |  44,741.58 ns |   298.890 ns |   279.582 ns |         - |
|                                           |              |               |              |              |           |
| Decrypt · AES-192-GCM (OS)                | 128KB        |  11,566.06 ns |    45.235 ns |    42.313 ns |         - |
| Decrypt · AES-192-GCM (AES-NI+PClMulV256) | 128KB        |  16,649.51 ns |   314.432 ns |   322.899 ns |         - |
| Decrypt · AES-192-GCM (AES-NI+PClMul)     | 128KB        |  22,003.14 ns |    62.833 ns |    55.700 ns |         - |
| Decrypt · AES-192-GCM (BouncyCastle)      | 128KB        | 464,310.77 ns | 1,443.731 ns | 1,279.830 ns |    1728 B |
| Decrypt · AES-192-GCM (Managed)           | 128KB        | 709,900.30 ns | 2,517.967 ns | 2,355.308 ns |         - |
|                                           |              |               |              |              |           |
| Encrypt · AES-192-GCM (OS)                | 128KB        |  10,228.13 ns |    48.590 ns |    45.451 ns |         - |
| Encrypt · AES-192-GCM (AES-NI+PClMulV256) | 128KB        |  18,451.56 ns |    82.729 ns |    77.384 ns |         - |
| Encrypt · AES-192-GCM (AES-NI+PClMul)     | 128KB        |  21,223.44 ns |   154.737 ns |   144.741 ns |         - |
| Encrypt · AES-192-GCM (BouncyCastle)      | 128KB        | 465,860.25 ns | 2,875.950 ns | 2,690.165 ns |    1712 B |
| Encrypt · AES-192-GCM (Managed)           | 128KB        | 725,079.20 ns | 2,145.340 ns | 1,901.788 ns |         - |