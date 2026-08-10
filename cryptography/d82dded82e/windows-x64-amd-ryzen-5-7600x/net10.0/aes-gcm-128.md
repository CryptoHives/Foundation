| Description                               | TestDataSize | Mean          | Error        | StdDev       | Allocated |
|------------------------------------------ |------------- |--------------:|-------------:|-------------:|----------:|
| Decrypt · AES-128-GCM (AES-NI+PClMulV256) | 17B          |     102.95 ns |     0.331 ns |     0.293 ns |         - |
| Decrypt · AES-128-GCM (AES-NI+PClMul)     | 17B          |     104.40 ns |     0.371 ns |     0.347 ns |         - |
| Decrypt · AES-128-GCM (OS)                | 17B          |     114.99 ns |     0.637 ns |     0.565 ns |         - |
| Decrypt · AES-128-GCM (Managed)           | 17B          |     340.88 ns |     1.797 ns |     1.681 ns |         - |
| Decrypt · AES-128-GCM (BouncyCastle)      | 17B          |     559.75 ns |     3.006 ns |     2.812 ns |    1624 B |
|                                           |              |               |              |              |           |
| Encrypt · AES-128-GCM (AES-NI+PClMul)     | 17B          |      62.08 ns |     0.189 ns |     0.167 ns |         - |
| Encrypt · AES-128-GCM (AES-NI+PClMulV256) | 17B          |      62.62 ns |     0.138 ns |     0.123 ns |         - |
| Encrypt · AES-128-GCM (OS)                | 17B          |     122.74 ns |     0.571 ns |     0.534 ns |         - |
| Encrypt · AES-128-GCM (Managed)           | 17B          |     313.01 ns |     1.462 ns |     1.368 ns |         - |
| Encrypt · AES-128-GCM (BouncyCastle)      | 17B          |     499.26 ns |     3.590 ns |     2.998 ns |    1608 B |
|                                           |              |               |              |              |           |
| Decrypt · AES-128-GCM (AES-NI+PClMulV256) | 65B          |     101.25 ns |     0.527 ns |     0.493 ns |         - |
| Decrypt · AES-128-GCM (AES-NI+PClMul)     | 65B          |     103.23 ns |     0.438 ns |     0.410 ns |         - |
| Decrypt · AES-128-GCM (OS)                | 65B          |     117.66 ns |     0.763 ns |     0.714 ns |         - |
| Decrypt · AES-128-GCM (Managed)           | 65B          |     581.40 ns |     3.339 ns |     3.123 ns |         - |
| Decrypt · AES-128-GCM (BouncyCastle)      | 65B          |     739.54 ns |     2.530 ns |     2.367 ns |    1624 B |
|                                           |              |               |              |              |           |
| Encrypt · AES-128-GCM (AES-NI+PClMul)     | 65B          |      68.42 ns |     0.196 ns |     0.183 ns |         - |
| Encrypt · AES-128-GCM (AES-NI+PClMulV256) | 65B          |      68.77 ns |     0.340 ns |     0.301 ns |         - |
| Encrypt · AES-128-GCM (OS)                | 65B          |     122.76 ns |     0.407 ns |     0.340 ns |         - |
| Encrypt · AES-128-GCM (Managed)           | 65B          |     548.80 ns |     3.678 ns |     3.441 ns |         - |
| Encrypt · AES-128-GCM (BouncyCastle)      | 65B          |     648.90 ns |     6.516 ns |     5.777 ns |    1608 B |
|                                           |              |               |              |              |           |
| Decrypt · AES-128-GCM (AES-NI+PClMulV256) | 128B         |      95.70 ns |     0.407 ns |     0.380 ns |         - |
| Decrypt · AES-128-GCM (AES-NI+PClMul)     | 128B         |      98.45 ns |     0.321 ns |     0.300 ns |         - |
| Decrypt · AES-128-GCM (OS)                | 128B         |     116.39 ns |     0.314 ns |     0.262 ns |         - |
| Decrypt · AES-128-GCM (Managed)           | 128B         |     818.32 ns |     3.375 ns |     2.991 ns |         - |
| Decrypt · AES-128-GCM (BouncyCastle)      | 128B         |     876.64 ns |     2.989 ns |     2.796 ns |    1624 B |
|                                           |              |               |              |              |           |
| Encrypt · AES-128-GCM (AES-NI+PClMulV256) | 128B         |      57.24 ns |     0.106 ns |     0.094 ns |         - |
| Encrypt · AES-128-GCM (AES-NI+PClMul)     | 128B         |      59.48 ns |     0.540 ns |     0.505 ns |         - |
| Encrypt · AES-128-GCM (OS)                | 128B         |     120.30 ns |     0.801 ns |     0.749 ns |         - |
| Encrypt · AES-128-GCM (Managed)           | 128B         |     789.27 ns |     3.525 ns |     3.297 ns |         - |
| Encrypt · AES-128-GCM (BouncyCastle)      | 128B         |     792.65 ns |     5.102 ns |     4.523 ns |    1608 B |
|                                           |              |               |              |              |           |
| Decrypt · AES-128-GCM (AES-NI+PClMulV256) | 152B         |     120.05 ns |     0.240 ns |     0.188 ns |         - |
| Decrypt · AES-128-GCM (AES-NI+PClMul)     | 152B         |     123.28 ns |     0.365 ns |     0.305 ns |         - |
| Decrypt · AES-128-GCM (OS)                | 152B         |     132.80 ns |     0.332 ns |     0.277 ns |         - |
| Decrypt · AES-128-GCM (BouncyCastle)      | 152B         |     999.24 ns |     4.913 ns |     4.595 ns |    1624 B |
| Decrypt · AES-128-GCM (Managed)           | 152B         |   1,002.47 ns |    10.254 ns |     9.592 ns |         - |
|                                           |              |               |              |              |           |
| Encrypt · AES-128-GCM (AES-NI+PClMulV256) | 152B         |      82.86 ns |     0.210 ns |     0.196 ns |         - |
| Encrypt · AES-128-GCM (AES-NI+PClMul)     | 152B         |      84.51 ns |     0.161 ns |     0.143 ns |         - |
| Encrypt · AES-128-GCM (OS)                | 152B         |     131.56 ns |     0.614 ns |     0.545 ns |         - |
| Encrypt · AES-128-GCM (BouncyCastle)      | 152B         |     903.64 ns |     5.494 ns |     5.139 ns |    1608 B |
| Encrypt · AES-128-GCM (Managed)           | 152B         |     953.86 ns |     4.207 ns |     3.729 ns |         - |
|                                           |              |               |              |              |           |
| Decrypt · AES-128-GCM (AES-NI+PClMulV256) | 256B         |     111.85 ns |     0.334 ns |     0.312 ns |         - |
| Decrypt · AES-128-GCM (OS)                | 256B         |     122.60 ns |     0.568 ns |     0.504 ns |         - |
| Decrypt · AES-128-GCM (AES-NI+PClMul)     | 256B         |     124.00 ns |     0.866 ns |     0.810 ns |         - |
| Decrypt · AES-128-GCM (BouncyCastle)      | 256B         |   1,274.52 ns |     5.696 ns |     5.049 ns |    1624 B |
| Decrypt · AES-128-GCM (Managed)           | 256B         |   1,462.78 ns |     9.769 ns |     9.138 ns |         - |
|                                           |              |               |              |              |           |
| Encrypt · AES-128-GCM (AES-NI+PClMulV256) | 256B         |      72.90 ns |     0.432 ns |     0.404 ns |         - |
| Encrypt · AES-128-GCM (AES-NI+PClMul)     | 256B         |      77.77 ns |     0.266 ns |     0.248 ns |         - |
| Encrypt · AES-128-GCM (OS)                | 256B         |     120.86 ns |     0.584 ns |     0.546 ns |         - |
| Encrypt · AES-128-GCM (BouncyCastle)      | 256B         |   1,187.06 ns |    12.003 ns |    11.228 ns |    1608 B |
| Encrypt · AES-128-GCM (Managed)           | 256B         |   1,430.67 ns |     7.493 ns |     7.009 ns |         - |
|                                           |              |               |              |              |           |
| Decrypt · AES-128-GCM (OS)                | 1KB          |     176.06 ns |     0.851 ns |     0.796 ns |         - |
| Decrypt · AES-128-GCM (AES-NI+PClMulV256) | 1KB          |     202.11 ns |     0.745 ns |     0.660 ns |         - |
| Decrypt · AES-128-GCM (AES-NI+PClMul)     | 1KB          |     250.02 ns |     1.481 ns |     1.385 ns |         - |
| Decrypt · AES-128-GCM (BouncyCastle)      | 1KB          |   3,646.17 ns |    17.730 ns |    16.585 ns |    1624 B |
| Decrypt · AES-128-GCM (Managed)           | 1KB          |   5,321.67 ns |    26.885 ns |    25.148 ns |         - |
|                                           |              |               |              |              |           |
| Encrypt · AES-128-GCM (AES-NI+PClMulV256) | 1KB          |     170.82 ns |     1.061 ns |     0.992 ns |         - |
| Encrypt · AES-128-GCM (OS)                | 1KB          |     171.72 ns |     0.928 ns |     0.868 ns |         - |
| Encrypt · AES-128-GCM (AES-NI+PClMul)     | 1KB          |     194.79 ns |     0.744 ns |     0.660 ns |         - |
| Encrypt · AES-128-GCM (BouncyCastle)      | 1KB          |   3,533.12 ns |     7.379 ns |     6.162 ns |    1608 B |
| Encrypt · AES-128-GCM (Managed)           | 1KB          |   5,275.04 ns |    32.511 ns |    30.411 ns |         - |
|                                           |              |               |              |              |           |
| Decrypt · AES-128-GCM (OS)                | 8KB          |     749.33 ns |     2.528 ns |     2.241 ns |         - |
| Decrypt · AES-128-GCM (AES-NI+PClMulV256) | 8KB          |   1,024.88 ns |     4.731 ns |     4.194 ns |         - |
| Decrypt · AES-128-GCM (AES-NI+PClMul)     | 8KB          |   1,365.80 ns |     5.493 ns |     4.587 ns |         - |
| Decrypt · AES-128-GCM (BouncyCastle)      | 8KB          |  25,495.69 ns |   130.849 ns |   122.396 ns |    1624 B |
| Decrypt · AES-128-GCM (Managed)           | 8KB          |  41,842.83 ns |   244.320 ns |   228.537 ns |         - |
|                                           |              |               |              |              |           |
| Encrypt · AES-128-GCM (OS)                | 8KB          |     665.39 ns |     4.516 ns |     4.224 ns |         - |
| Encrypt · AES-128-GCM (AES-NI+PClMulV256) | 8KB          |   1,083.19 ns |     5.775 ns |     4.822 ns |         - |
| Encrypt · AES-128-GCM (AES-NI+PClMul)     | 8KB          |   1,296.43 ns |     3.035 ns |     2.691 ns |         - |
| Encrypt · AES-128-GCM (BouncyCastle)      | 8KB          |  25,328.18 ns |   142.092 ns |   125.961 ns |    1608 B |
| Encrypt · AES-128-GCM (Managed)           | 8KB          |  40,995.91 ns |   131.972 ns |   116.990 ns |         - |
|                                           |              |               |              |              |           |
| Decrypt · AES-128-GCM (OS)                | 128KB        |  10,769.09 ns |    70.491 ns |    65.937 ns |         - |
| Decrypt · AES-128-GCM (AES-NI+PClMulV256) | 128KB        |  16,651.25 ns |   325.878 ns |   362.213 ns |         - |
| Decrypt · AES-128-GCM (AES-NI+PClMul)     | 128KB        |  20,730.36 ns |   114.943 ns |   107.517 ns |         - |
| Decrypt · AES-128-GCM (BouncyCastle)      | 128KB        | 401,251.41 ns | 1,495.452 ns | 1,325.680 ns |    1624 B |
| Decrypt · AES-128-GCM (Managed)           | 128KB        | 656,117.23 ns | 3,867.558 ns | 3,229.586 ns |         - |
|                                           |              |               |              |              |           |
| Encrypt · AES-128-GCM (OS)                | 128KB        |   9,868.98 ns |    64.336 ns |    60.180 ns |         - |
| Encrypt · AES-128-GCM (AES-NI+PClMulV256) | 128KB        |  16,782.50 ns |   103.115 ns |    96.453 ns |         - |
| Encrypt · AES-128-GCM (AES-NI+PClMul)     | 128KB        |  20,316.93 ns |    99.132 ns |    92.728 ns |         - |
| Encrypt · AES-128-GCM (BouncyCastle)      | 128KB        | 401,508.72 ns | 2,259.139 ns | 2,002.668 ns |    1608 B |
| Encrypt · AES-128-GCM (Managed)           | 128KB        | 659,908.63 ns | 4,853.744 ns | 4,540.195 ns |         - |