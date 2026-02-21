| Description                               | TestDataSize | Mean          | Error         | StdDev        | Allocated |
|------------------------------------------ |------------- |--------------:|--------------:|--------------:|----------:|
| Decrypt · AES-192-GCM (AES-NI+PClMul)     | 128B         |      74.52 ns |      1.184 ns |      1.108 ns |         - |
| Decrypt · AES-192-GCM (AES-NI+PClMulV256) | 128B         |      76.20 ns |      1.230 ns |      1.150 ns |         - |
| Decrypt · AES-192-GCM (OS)                | 128B         |     126.52 ns |      2.439 ns |      2.609 ns |         - |
| Decrypt · AES-192-GCM (PClMul)            | 128B         |     548.84 ns |     10.045 ns |      9.396 ns |         - |
| Decrypt · AES-192-GCM (AES-NI)            | 128B         |     592.07 ns |      7.945 ns |      7.431 ns |         - |
| Decrypt · AES-192-GCM (Managed)           | 128B         |     914.52 ns |      5.840 ns |      5.463 ns |         - |
| Decrypt · AES-192-GCM (BouncyCastle)      | 128B         |   1,013.86 ns |     20.156 ns |     18.854 ns |    1728 B |
|                                           |              |               |               |               |           |
| Encrypt · AES-192-GCM (AES-NI+PClMulV256) | 128B         |      59.94 ns |      0.261 ns |      0.231 ns |         - |
| Encrypt · AES-192-GCM (AES-NI+PClMul)     | 128B         |      62.69 ns |      0.168 ns |      0.141 ns |         - |
| Encrypt · AES-192-GCM (OS)                | 128B         |     121.17 ns |      0.592 ns |      0.525 ns |         - |
| Encrypt · AES-192-GCM (PClMul)            | 128B         |     494.73 ns |      2.662 ns |      2.490 ns |         - |
| Encrypt · AES-192-GCM (AES-NI)            | 128B         |     538.61 ns |      2.420 ns |      2.264 ns |         - |
| Encrypt · AES-192-GCM (Managed)           | 128B         |     848.25 ns |      4.361 ns |      4.080 ns |         - |
| Encrypt · AES-192-GCM (BouncyCastle)      | 128B         |     899.55 ns |      6.389 ns |      5.976 ns |    1712 B |
|                                           |              |               |               |               |           |
| Decrypt · AES-192-GCM (OS)                | 1KB          |     192.81 ns |      2.902 ns |      2.572 ns |         - |
| Decrypt · AES-192-GCM (AES-NI+PClMulV256) | 1KB          |     230.36 ns |      1.866 ns |      1.745 ns |         - |
| Decrypt · AES-192-GCM (AES-NI+PClMul)     | 1KB          |     259.04 ns |      4.989 ns |      4.667 ns |         - |
| Decrypt · AES-192-GCM (PClMul)            | 1KB          |   3,519.03 ns |     19.685 ns |     17.450 ns |         - |
| Decrypt · AES-192-GCM (AES-NI)            | 1KB          |   3,725.41 ns |     26.088 ns |     23.127 ns |         - |
| Decrypt · AES-192-GCM (BouncyCastle)      | 1KB          |   4,302.01 ns |     81.572 ns |     90.667 ns |    1728 B |
| Decrypt · AES-192-GCM (Managed)           | 1KB          |   5,950.93 ns |     61.565 ns |     57.588 ns |         - |
|                                           |              |               |               |               |           |
| Encrypt · AES-192-GCM (OS)                | 1KB          |     181.80 ns |      2.014 ns |      1.884 ns |         - |
| Encrypt · AES-192-GCM (AES-NI+PClMulV256) | 1KB          |     193.01 ns |      3.029 ns |      2.833 ns |         - |
| Encrypt · AES-192-GCM (AES-NI+PClMul)     | 1KB          |     208.50 ns |      0.770 ns |      0.720 ns |         - |
| Encrypt · AES-192-GCM (PClMul)            | 1KB          |   3,397.55 ns |     17.537 ns |     15.546 ns |         - |
| Encrypt · AES-192-GCM (AES-NI)            | 1KB          |   3,580.41 ns |      5.155 ns |      4.570 ns |         - |
| Encrypt · AES-192-GCM (BouncyCastle)      | 1KB          |   4,216.62 ns |     54.000 ns |     50.512 ns |    1712 B |
| Encrypt · AES-192-GCM (Managed)           | 1KB          |   5,995.47 ns |    117.477 ns |    109.888 ns |         - |
|                                           |              |               |               |               |           |
| Decrypt · AES-192-GCM (OS)                | 8KB          |     773.65 ns |     10.246 ns |      9.584 ns |         - |
| Decrypt · AES-192-GCM (AES-NI+PClMulV256) | 8KB          |   1,294.51 ns |     17.042 ns |     15.941 ns |         - |
| Decrypt · AES-192-GCM (AES-NI+PClMul)     | 8KB          |   1,515.32 ns |     17.049 ns |     15.948 ns |         - |
| Decrypt · AES-192-GCM (PClMul)            | 8KB          |  27,448.01 ns |    305.146 ns |    285.434 ns |         - |
| Decrypt · AES-192-GCM (AES-NI)            | 8KB          |  28,741.27 ns |    206.317 ns |    192.989 ns |         - |
| Decrypt · AES-192-GCM (BouncyCastle)      | 8KB          |  30,584.68 ns |    127.176 ns |    118.960 ns |    1728 B |
| Decrypt · AES-192-GCM (Managed)           | 8KB          |  46,108.82 ns |    812.977 ns |    760.459 ns |         - |
|                                           |              |               |               |               |           |
| Encrypt · AES-192-GCM (OS)                | 8KB          |     704.03 ns |     10.975 ns |     10.266 ns |         - |
| Encrypt · AES-192-GCM (AES-NI+PClMulV256) | 8KB          |   1,241.49 ns |     20.460 ns |     19.138 ns |         - |
| Encrypt · AES-192-GCM (AES-NI+PClMul)     | 8KB          |   1,417.59 ns |     28.346 ns |     27.840 ns |         - |
| Encrypt · AES-192-GCM (PClMul)            | 8KB          |  27,378.74 ns |    238.058 ns |    222.680 ns |         - |
| Encrypt · AES-192-GCM (AES-NI)            | 8KB          |  28,778.68 ns |    208.249 ns |    194.796 ns |         - |
| Encrypt · AES-192-GCM (BouncyCastle)      | 8KB          |  30,429.70 ns |    271.223 ns |    240.432 ns |    1712 B |
| Encrypt · AES-192-GCM (Managed)           | 8KB          |  46,220.14 ns |    732.176 ns |    684.878 ns |         - |
|                                           |              |               |               |               |           |
| Decrypt · AES-192-GCM (OS)                | 128KB        |  11,912.32 ns |    185.879 ns |    164.776 ns |         - |
| Decrypt · AES-192-GCM (AES-NI+PClMulV256) | 128KB        |  19,634.35 ns |    370.913 ns |    380.900 ns |         - |
| Decrypt · AES-192-GCM (AES-NI+PClMul)     | 128KB        |  22,936.71 ns |    293.596 ns |    274.630 ns |         - |
| Decrypt · AES-192-GCM (PClMul)            | 128KB        | 436,520.82 ns |  3,609.577 ns |  3,376.401 ns |         - |
| Decrypt · AES-192-GCM (AES-NI)            | 128KB        | 457,606.88 ns |  2,824.314 ns |  2,641.865 ns |         - |
| Decrypt · AES-192-GCM (BouncyCastle)      | 128KB        | 481,038.30 ns |  3,144.975 ns |  2,787.938 ns |    1728 B |
| Decrypt · AES-192-GCM (Managed)           | 128KB        | 738,083.48 ns |  9,205.945 ns |  8,611.247 ns |         - |
|                                           |              |               |               |               |           |
| Encrypt · AES-192-GCM (OS)                | 128KB        |  10,659.16 ns |    168.871 ns |    157.962 ns |         - |
| Encrypt · AES-192-GCM (AES-NI+PClMulV256) | 128KB        |  19,142.88 ns |    314.322 ns |    294.017 ns |         - |
| Encrypt · AES-192-GCM (AES-NI+PClMul)     | 128KB        |  21,950.26 ns |    251.836 ns |    235.568 ns |         - |
| Encrypt · AES-192-GCM (PClMul)            | 128KB        | 436,673.25 ns |  2,786.805 ns |  2,606.779 ns |         - |
| Encrypt · AES-192-GCM (AES-NI)            | 128KB        | 459,017.76 ns |  3,037.827 ns |  2,536.723 ns |         - |
| Encrypt · AES-192-GCM (BouncyCastle)      | 128KB        | 478,078.90 ns |  3,766.642 ns |  3,339.030 ns |    1712 B |
| Encrypt · AES-192-GCM (Managed)           | 128KB        | 739,869.32 ns | 12,315.381 ns | 11,519.815 ns |         - |