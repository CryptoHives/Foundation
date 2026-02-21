| Description                               | TestDataSize | Mean          | Error        | StdDev       | Allocated |
|------------------------------------------ |------------- |--------------:|-------------:|-------------:|----------:|
| Decrypt · AES-256-GCM (AES-NI+PClMulV256) | 17B          |     110.12 ns |     0.515 ns |     0.482 ns |         - |
| Decrypt · AES-256-GCM (AES-NI+PClMul)     | 17B          |     120.62 ns |     0.828 ns |     0.734 ns |         - |
| Decrypt · AES-256-GCM (OS)                | 17B          |     124.43 ns |     0.711 ns |     0.594 ns |         - |
| Decrypt · AES-256-GCM (Managed)           | 17B          |     398.13 ns |     1.957 ns |     1.831 ns |         - |
| Decrypt · AES-256-GCM (BouncyCastle)      | 17B          |     674.08 ns |     9.237 ns |     7.713 ns |    1832 B |
|                                           |              |               |              |              |           |
| Encrypt · AES-256-GCM (AES-NI+PClMulV256) | 17B          |      70.40 ns |     0.322 ns |     0.301 ns |         - |
| Encrypt · AES-256-GCM (AES-NI+PClMul)     | 17B          |      70.41 ns |     0.265 ns |     0.248 ns |         - |
| Encrypt · AES-256-GCM (OS)                | 17B          |     129.97 ns |     0.933 ns |     0.827 ns |         - |
| Encrypt · AES-256-GCM (Managed)           | 17B          |     351.31 ns |     2.225 ns |     2.081 ns |         - |
| Encrypt · AES-256-GCM (BouncyCastle)      | 17B          |     602.77 ns |     3.750 ns |     3.325 ns |    1816 B |
|                                           |              |               |              |              |           |
| Decrypt · AES-256-GCM (AES-NI+PClMulV256) | 65B          |     110.25 ns |     0.617 ns |     0.578 ns |         - |
| Decrypt · AES-256-GCM (AES-NI+PClMul)     | 65B          |     111.99 ns |     0.361 ns |     0.337 ns |         - |
| Decrypt · AES-256-GCM (OS)                | 65B          |     127.21 ns |     1.007 ns |     0.892 ns |         - |
| Decrypt · AES-256-GCM (Managed)           | 65B          |     674.55 ns |     6.001 ns |     5.614 ns |         - |
| Decrypt · AES-256-GCM (BouncyCastle)      | 65B          |     888.51 ns |     4.893 ns |     4.338 ns |    1832 B |
|                                           |              |               |              |              |           |
| Encrypt · AES-256-GCM (AES-NI+PClMul)     | 65B          |      77.57 ns |     0.273 ns |     0.256 ns |         - |
| Encrypt · AES-256-GCM (AES-NI+PClMulV256) | 65B          |      78.45 ns |     1.584 ns |     1.481 ns |         - |
| Encrypt · AES-256-GCM (OS)                | 65B          |     135.40 ns |     0.948 ns |     0.887 ns |         - |
| Encrypt · AES-256-GCM (Managed)           | 65B          |     638.87 ns |     3.311 ns |     2.935 ns |         - |
| Encrypt · AES-256-GCM (BouncyCastle)      | 65B          |     807.69 ns |     5.624 ns |     5.261 ns |    1816 B |
|                                           |              |               |              |              |           |
| Decrypt · AES-256-GCM (AES-NI+PClMulV256) | 128B         |     108.15 ns |     0.565 ns |     0.528 ns |         - |
| Decrypt · AES-256-GCM (AES-NI+PClMul)     | 128B         |     109.49 ns |     0.576 ns |     0.510 ns |         - |
| Decrypt · AES-256-GCM (OS)                | 128B         |     125.86 ns |     1.033 ns |     0.916 ns |         - |
| Decrypt · AES-256-GCM (Managed)           | 128B         |     964.25 ns |     8.176 ns |     7.648 ns |         - |
| Decrypt · AES-256-GCM (BouncyCastle)      | 128B         |   1,094.32 ns |     9.571 ns |     8.953 ns |    1832 B |
|                                           |              |               |              |              |           |
| Encrypt · AES-256-GCM (AES-NI+PClMulV256) | 128B         |      64.45 ns |     0.274 ns |     0.256 ns |         - |
| Encrypt · AES-256-GCM (AES-NI+PClMul)     | 128B         |      66.08 ns |     0.312 ns |     0.292 ns |         - |
| Encrypt · AES-256-GCM (OS)                | 128B         |     125.38 ns |     0.698 ns |     0.653 ns |         - |
| Encrypt · AES-256-GCM (Managed)           | 128B         |     916.12 ns |     3.875 ns |     3.624 ns |         - |
| Encrypt · AES-256-GCM (BouncyCastle)      | 128B         |     996.67 ns |     9.759 ns |     9.128 ns |    1816 B |
|                                           |              |               |              |              |           |
| Decrypt · AES-256-GCM (AES-NI+PClMul)     | 152B         |     134.13 ns |     0.528 ns |     0.468 ns |         - |
| Decrypt · AES-256-GCM (AES-NI+PClMulV256) | 152B         |     136.06 ns |     0.721 ns |     0.674 ns |         - |
| Decrypt · AES-256-GCM (OS)                | 152B         |     146.62 ns |     0.886 ns |     0.786 ns |         - |
| Decrypt · AES-256-GCM (Managed)           | 152B         |   1,145.12 ns |     7.968 ns |     7.453 ns |         - |
| Decrypt · AES-256-GCM (BouncyCastle)      | 152B         |   1,230.57 ns |     9.543 ns |     8.459 ns |    1832 B |
|                                           |              |               |              |              |           |
| Encrypt · AES-256-GCM (AES-NI+PClMulV256) | 152B         |      93.15 ns |     0.524 ns |     0.464 ns |         - |
| Encrypt · AES-256-GCM (AES-NI+PClMul)     | 152B         |      94.89 ns |     0.386 ns |     0.323 ns |         - |
| Encrypt · AES-256-GCM (OS)                | 152B         |     146.42 ns |     0.992 ns |     0.928 ns |         - |
| Encrypt · AES-256-GCM (BouncyCastle)      | 152B         |   1,139.30 ns |     8.333 ns |     7.387 ns |    1816 B |
| Encrypt · AES-256-GCM (Managed)           | 152B         |   1,165.64 ns |     9.225 ns |     8.630 ns |         - |
|                                           |              |               |              |              |           |
| Decrypt · AES-256-GCM (AES-NI+PClMulV256) | 256B         |     125.42 ns |     1.091 ns |     1.020 ns |         - |
| Decrypt · AES-256-GCM (OS)                | 256B         |     138.51 ns |     0.828 ns |     0.734 ns |         - |
| Decrypt · AES-256-GCM (AES-NI+PClMul)     | 256B         |     139.14 ns |     0.910 ns |     0.851 ns |         - |
| Decrypt · AES-256-GCM (BouncyCastle)      | 256B         |   1,622.23 ns |     8.205 ns |     7.274 ns |    1832 B |
| Decrypt · AES-256-GCM (Managed)           | 256B         |   1,712.39 ns |     6.561 ns |     5.816 ns |         - |
|                                           |              |               |              |              |           |
| Encrypt · AES-256-GCM (AES-NI+PClMulV256) | 256B         |      84.39 ns |     0.367 ns |     0.325 ns |         - |
| Encrypt · AES-256-GCM (AES-NI+PClMul)     | 256B         |      88.81 ns |     0.617 ns |     0.577 ns |         - |
| Encrypt · AES-256-GCM (OS)                | 256B         |     127.57 ns |     0.556 ns |     0.493 ns |         - |
| Encrypt · AES-256-GCM (BouncyCastle)      | 256B         |   1,513.57 ns |    12.718 ns |    11.896 ns |    1816 B |
| Encrypt · AES-256-GCM (Managed)           | 256B         |   1,676.14 ns |     9.340 ns |     7.799 ns |         - |
|                                           |              |               |              |              |           |
| Decrypt · AES-256-GCM (OS)                | 1KB          |     210.74 ns |     0.989 ns |     0.925 ns |         - |
| Decrypt · AES-256-GCM (AES-NI+PClMulV256) | 1KB          |     221.17 ns |     1.159 ns |     1.085 ns |         - |
| Decrypt · AES-256-GCM (AES-NI+PClMul)     | 1KB          |     273.06 ns |     1.924 ns |     1.706 ns |         - |
| Decrypt · AES-256-GCM (BouncyCastle)      | 1KB          |   4,766.47 ns |    40.671 ns |    33.962 ns |    1832 B |
| Decrypt · AES-256-GCM (Managed)           | 1KB          |   6,269.40 ns |    27.617 ns |    24.482 ns |         - |
|                                           |              |               |              |              |           |
| Encrypt · AES-256-GCM (OS)                | 1KB          |     185.72 ns |     1.092 ns |     1.021 ns |         - |
| Encrypt · AES-256-GCM (AES-NI+PClMulV256) | 1KB          |     203.88 ns |     1.256 ns |     0.981 ns |         - |
| Encrypt · AES-256-GCM (AES-NI+PClMul)     | 1KB          |     226.11 ns |     0.801 ns |     0.669 ns |         - |
| Encrypt · AES-256-GCM (BouncyCastle)      | 1KB          |   4,657.94 ns |    26.666 ns |    23.639 ns |    1816 B |
| Encrypt · AES-256-GCM (Managed)           | 1KB          |   6,224.11 ns |    30.430 ns |    26.975 ns |         - |
|                                           |              |               |              |              |           |
| Decrypt · AES-256-GCM (OS)                | 8KB          |     947.24 ns |     3.494 ns |     2.918 ns |         - |
| Decrypt · AES-256-GCM (AES-NI+PClMulV256) | 8KB          |   1,169.14 ns |     9.318 ns |     8.260 ns |         - |
| Decrypt · AES-256-GCM (AES-NI+PClMul)     | 8KB          |   1,576.99 ns |     5.499 ns |     5.143 ns |         - |
| Decrypt · AES-256-GCM (BouncyCastle)      | 8KB          |  34,113.53 ns |   235.268 ns |   220.070 ns |    1832 B |
| Decrypt · AES-256-GCM (Managed)           | 8KB          |  49,254.38 ns |   285.002 ns |   252.647 ns |         - |
|                                           |              |               |              |              |           |
| Encrypt · AES-256-GCM (OS)                | 8KB          |     729.45 ns |     5.413 ns |     5.063 ns |         - |
| Encrypt · AES-256-GCM (AES-NI+PClMulV256) | 8KB          |   1,321.10 ns |     7.891 ns |     7.382 ns |         - |
| Encrypt · AES-256-GCM (AES-NI+PClMul)     | 8KB          |   1,497.63 ns |     8.493 ns |     7.529 ns |         - |
| Encrypt · AES-256-GCM (BouncyCastle)      | 8KB          |  33,790.68 ns |   260.884 ns |   231.267 ns |    1816 B |
| Encrypt · AES-256-GCM (Managed)           | 8KB          |  48,744.61 ns |   392.330 ns |   366.986 ns |         - |
|                                           |              |               |              |              |           |
| Decrypt · AES-256-GCM (OS)                | 128KB        |  14,527.05 ns |    54.026 ns |    50.536 ns |         - |
| Decrypt · AES-256-GCM (AES-NI+PClMulV256) | 128KB        |  17,704.75 ns |   121.152 ns |   134.660 ns |         - |
| Decrypt · AES-256-GCM (AES-NI+PClMul)     | 128KB        |  23,783.44 ns |   149.532 ns |   139.873 ns |         - |
| Decrypt · AES-256-GCM (BouncyCastle)      | 128KB        | 541,140.46 ns | 3,962.958 ns | 3,706.954 ns |    1832 B |
| Decrypt · AES-256-GCM (Managed)           | 128KB        | 776,340.85 ns | 5,293.579 ns | 4,692.620 ns |         - |
|                                           |              |               |              |              |           |
| Encrypt · AES-256-GCM (OS)                | 128KB        |  10,708.90 ns |    51.733 ns |    45.860 ns |         - |
| Encrypt · AES-256-GCM (AES-NI+PClMulV256) | 128KB        |  20,626.11 ns |   116.566 ns |   109.036 ns |         - |
| Encrypt · AES-256-GCM (AES-NI+PClMul)     | 128KB        |  23,222.32 ns |    87.148 ns |    72.773 ns |         - |
| Encrypt · AES-256-GCM (BouncyCastle)      | 128KB        | 535,471.48 ns | 3,730.769 ns | 3,489.764 ns |    1816 B |
| Encrypt · AES-256-GCM (Managed)           | 128KB        | 777,245.67 ns | 6,059.214 ns | 5,667.793 ns |         - |