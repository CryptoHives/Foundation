| Description                               | TestDataSize | Mean          | Error         | StdDev       | Allocated |
|------------------------------------------ |------------- |--------------:|--------------:|-------------:|----------:|
| Decrypt · AES-192-GCM (AES-NI+PClMul)     | 17B          |     105.78 ns |      0.863 ns |     0.807 ns |         - |
| Decrypt · AES-192-GCM (AES-NI+PClMulV256) | 17B          |     106.15 ns |      0.539 ns |     0.504 ns |         - |
| Decrypt · AES-192-GCM (OS)                | 17B          |     124.14 ns |      1.618 ns |     1.513 ns |         - |
| Decrypt · AES-192-GCM (Managed)           | 17B          |     375.56 ns |      4.936 ns |     4.376 ns |         - |
| Decrypt · AES-192-GCM (BouncyCastle)      | 17B          |     634.67 ns |      8.916 ns |     8.340 ns |    1728 B |
|                                           |              |               |               |              |           |
| Encrypt · AES-192-GCM (AES-NI+PClMulV256) | 17B          |      72.02 ns |      0.524 ns |     0.491 ns |         - |
| Encrypt · AES-192-GCM (AES-NI+PClMul)     | 17B          |      72.31 ns |      0.659 ns |     0.616 ns |         - |
| Encrypt · AES-192-GCM (OS)                | 17B          |     127.99 ns |      1.562 ns |     1.461 ns |         - |
| Encrypt · AES-192-GCM (Managed)           | 17B          |     348.96 ns |      3.313 ns |     2.937 ns |         - |
| Encrypt · AES-192-GCM (BouncyCastle)      | 17B          |     571.15 ns |      9.635 ns |     9.012 ns |    1712 B |
|                                           |              |               |               |              |           |
| Decrypt · AES-192-GCM (AES-NI+PClMulV256) | 65B          |     106.23 ns |      0.869 ns |     0.813 ns |         - |
| Decrypt · AES-192-GCM (AES-NI+PClMul)     | 65B          |     108.20 ns |      0.351 ns |     0.293 ns |         - |
| Decrypt · AES-192-GCM (OS)                | 65B          |     127.27 ns |      1.983 ns |     1.855 ns |         - |
| Decrypt · AES-192-GCM (Managed)           | 65B          |     648.53 ns |      5.684 ns |     5.317 ns |         - |
| Decrypt · AES-192-GCM (BouncyCastle)      | 65B          |     841.95 ns |      6.850 ns |     6.407 ns |    1728 B |
|                                           |              |               |               |              |           |
| Encrypt · AES-192-GCM (AES-NI+PClMulV256) | 65B          |      80.36 ns |      0.546 ns |     0.510 ns |         - |
| Encrypt · AES-192-GCM (AES-NI+PClMul)     | 65B          |      81.01 ns |      0.705 ns |     0.659 ns |         - |
| Encrypt · AES-192-GCM (OS)                | 65B          |     132.80 ns |      1.955 ns |     1.829 ns |         - |
| Encrypt · AES-192-GCM (Managed)           | 65B          |     614.95 ns |      8.296 ns |     7.760 ns |         - |
| Encrypt · AES-192-GCM (BouncyCastle)      | 65B          |     749.66 ns |      3.221 ns |     3.013 ns |    1712 B |
|                                           |              |               |               |              |           |
| Decrypt · AES-192-GCM (AES-NI+PClMulV256) | 128B         |     102.26 ns |      0.789 ns |     0.738 ns |         - |
| Decrypt · AES-192-GCM (AES-NI+PClMul)     | 128B         |     105.88 ns |      0.739 ns |     0.692 ns |         - |
| Decrypt · AES-192-GCM (OS)                | 128B         |     125.75 ns |      2.225 ns |     2.081 ns |         - |
| Decrypt · AES-192-GCM (Managed)           | 128B         |     934.16 ns |      4.479 ns |     3.970 ns |         - |
| Decrypt · AES-192-GCM (BouncyCastle)      | 128B         |   1,029.79 ns |     20.149 ns |    20.691 ns |    1728 B |
|                                           |              |               |               |              |           |
| Encrypt · AES-192-GCM (AES-NI+PClMulV256) | 128B         |      66.78 ns |      0.408 ns |     0.362 ns |         - |
| Encrypt · AES-192-GCM (AES-NI+PClMul)     | 128B         |      68.87 ns |      0.870 ns |     0.814 ns |         - |
| Encrypt · AES-192-GCM (OS)                | 128B         |     126.78 ns |      2.189 ns |     2.048 ns |         - |
| Encrypt · AES-192-GCM (Managed)           | 128B         |     889.55 ns |      4.762 ns |     4.454 ns |         - |
| Encrypt · AES-192-GCM (BouncyCastle)      | 128B         |     945.67 ns |      7.248 ns |     6.425 ns |    1712 B |
|                                           |              |               |               |              |           |
| Decrypt · AES-192-GCM (AES-NI+PClMulV256) | 152B         |     123.82 ns |      1.610 ns |     1.428 ns |         - |
| Decrypt · AES-192-GCM (AES-NI+PClMul)     | 152B         |     129.39 ns |      0.924 ns |     0.865 ns |         - |
| Decrypt · AES-192-GCM (OS)                | 152B         |     141.51 ns |      1.541 ns |     1.441 ns |         - |
| Decrypt · AES-192-GCM (Managed)           | 152B         |   1,116.82 ns |     14.866 ns |    13.905 ns |         - |
| Decrypt · AES-192-GCM (BouncyCastle)      | 152B         |   1,198.46 ns |     15.861 ns |    14.837 ns |    1728 B |
|                                           |              |               |               |              |           |
| Encrypt · AES-192-GCM (AES-NI+PClMulV256) | 152B         |      96.13 ns |      0.308 ns |     0.288 ns |         - |
| Encrypt · AES-192-GCM (AES-NI+PClMul)     | 152B         |      97.08 ns |      0.821 ns |     0.686 ns |         - |
| Encrypt · AES-192-GCM (OS)                | 152B         |     142.86 ns |      0.629 ns |     0.589 ns |         - |
| Encrypt · AES-192-GCM (BouncyCastle)      | 152B         |   1,054.83 ns |      6.571 ns |     5.825 ns |    1712 B |
| Encrypt · AES-192-GCM (Managed)           | 152B         |   1,060.46 ns |      5.318 ns |     4.974 ns |         - |
|                                           |              |               |               |              |           |
| Decrypt · AES-192-GCM (AES-NI+PClMulV256) | 256B         |     115.63 ns |      0.833 ns |     0.779 ns |         - |
| Decrypt · AES-192-GCM (AES-NI+PClMul)     | 256B         |     130.10 ns |      1.469 ns |     1.374 ns |         - |
| Decrypt · AES-192-GCM (OS)                | 256B         |     134.09 ns |      1.254 ns |     1.173 ns |         - |
| Decrypt · AES-192-GCM (BouncyCastle)      | 256B         |   1,487.65 ns |     22.321 ns |    20.879 ns |    1728 B |
| Decrypt · AES-192-GCM (Managed)           | 256B         |   1,638.46 ns |     14.520 ns |    13.582 ns |         - |
|                                           |              |               |               |              |           |
| Encrypt · AES-192-GCM (AES-NI+PClMulV256) | 256B         |      83.29 ns |      0.289 ns |     0.256 ns |         - |
| Encrypt · AES-192-GCM (AES-NI+PClMul)     | 256B         |      86.80 ns |      0.301 ns |     0.267 ns |         - |
| Encrypt · AES-192-GCM (OS)                | 256B         |     128.49 ns |      2.466 ns |     2.422 ns |         - |
| Encrypt · AES-192-GCM (BouncyCastle)      | 256B         |   1,412.45 ns |      6.909 ns |     6.463 ns |    1712 B |
| Encrypt · AES-192-GCM (Managed)           | 256B         |   1,594.77 ns |      6.924 ns |     6.138 ns |         - |
|                                           |              |               |               |              |           |
| Decrypt · AES-192-GCM (OS)                | 1KB          |     198.45 ns |      2.196 ns |     2.054 ns |         - |
| Decrypt · AES-192-GCM (AES-NI+PClMulV256) | 1KB          |     205.10 ns |      1.600 ns |     1.497 ns |         - |
| Decrypt · AES-192-GCM (AES-NI+PClMul)     | 1KB          |     236.24 ns |      1.591 ns |     1.488 ns |         - |
| Decrypt · AES-192-GCM (BouncyCastle)      | 1KB          |   4,346.96 ns |     75.664 ns |    70.776 ns |    1728 B |
| Decrypt · AES-192-GCM (Managed)           | 1KB          |   6,012.74 ns |     43.221 ns |    40.429 ns |         - |
|                                           |              |               |               |              |           |
| Encrypt · AES-192-GCM (AES-NI+PClMulV256) | 1KB          |     175.82 ns |      2.667 ns |     2.364 ns |         - |
| Encrypt · AES-192-GCM (AES-NI+PClMul)     | 1KB          |     187.89 ns |      1.916 ns |     1.699 ns |         - |
| Encrypt · AES-192-GCM (OS)                | 1KB          |     189.30 ns |      1.513 ns |     1.415 ns |         - |
| Encrypt · AES-192-GCM (BouncyCastle)      | 1KB          |   4,277.27 ns |     57.970 ns |    54.225 ns |    1712 B |
| Encrypt · AES-192-GCM (Managed)           | 1KB          |   5,991.79 ns |     46.617 ns |    43.606 ns |         - |
|                                           |              |               |               |              |           |
| Decrypt · AES-192-GCM (OS)                | 8KB          |     800.85 ns |      8.217 ns |     7.284 ns |         - |
| Decrypt · AES-192-GCM (AES-NI+PClMulV256) | 8KB          |   1,033.26 ns |     17.561 ns |    15.568 ns |         - |
| Decrypt · AES-192-GCM (AES-NI+PClMul)     | 8KB          |   1,280.35 ns |     23.039 ns |    21.551 ns |         - |
| Decrypt · AES-192-GCM (BouncyCastle)      | 8KB          |  30,699.47 ns |    200.208 ns |   177.479 ns |    1728 B |
| Decrypt · AES-192-GCM (Managed)           | 8KB          |  46,415.30 ns |    497.609 ns |   465.464 ns |         - |
|                                           |              |               |               |              |           |
| Encrypt · AES-192-GCM (OS)                | 8KB          |     725.93 ns |      9.079 ns |     8.492 ns |         - |
| Encrypt · AES-192-GCM (AES-NI+PClMulV256) | 8KB          |   1,069.36 ns |     18.639 ns |    16.523 ns |         - |
| Encrypt · AES-192-GCM (AES-NI+PClMul)     | 8KB          |   1,139.19 ns |     13.867 ns |    12.972 ns |         - |
| Encrypt · AES-192-GCM (BouncyCastle)      | 8KB          |  30,624.11 ns |    162.671 ns |   152.162 ns |    1712 B |
| Encrypt · AES-192-GCM (Managed)           | 8KB          |  46,551.56 ns |    469.920 ns |   392.404 ns |         - |
|                                           |              |               |               |              |           |
| Decrypt · AES-192-GCM (OS)                | 128KB        |  12,101.07 ns |    141.127 ns |   132.011 ns |         - |
| Decrypt · AES-192-GCM (AES-NI+PClMulV256) | 128KB        |  15,624.67 ns |    211.321 ns |   197.669 ns |         - |
| Decrypt · AES-192-GCM (AES-NI+PClMul)     | 128KB        |  20,462.96 ns |    398.579 ns |   443.019 ns |         - |
| Decrypt · AES-192-GCM (BouncyCastle)      | 128KB        | 483,442.10 ns |  2,381.924 ns | 2,111.513 ns |    1728 B |
| Decrypt · AES-192-GCM (Managed)           | 128KB        | 741,116.62 ns | 11,035.532 ns | 9,782.712 ns |         - |
|                                           |              |               |               |              |           |
| Encrypt · AES-192-GCM (OS)                | 128KB        |  11,059.20 ns |    124.262 ns |   116.235 ns |         - |
| Encrypt · AES-192-GCM (AES-NI+PClMulV256) | 128KB        |  16,150.82 ns |    280.839 ns |   300.494 ns |         - |
| Encrypt · AES-192-GCM (AES-NI+PClMul)     | 128KB        |  17,479.01 ns |    338.515 ns |   347.630 ns |         - |
| Encrypt · AES-192-GCM (BouncyCastle)      | 128KB        | 483,090.92 ns |  2,915.114 ns | 2,726.799 ns |    1712 B |
| Encrypt · AES-192-GCM (Managed)           | 128KB        | 742,203.52 ns |  6,064.270 ns | 5,672.522 ns |         - |