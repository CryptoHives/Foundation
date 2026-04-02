| Description                               | TestDataSize | Mean          | Error        | StdDev       | Allocated |
|------------------------------------------ |------------- |--------------:|-------------:|-------------:|----------:|
| Decrypt · AES-256-GCM (AES-NI+PClMulV256) | 17B          |     108.72 ns |     0.249 ns |     0.233 ns |         - |
| Decrypt · AES-256-GCM (AES-NI+PClMul)     | 17B          |     109.00 ns |     0.546 ns |     0.456 ns |         - |
| Decrypt · AES-256-GCM (OS)                | 17B          |     122.81 ns |     0.686 ns |     0.642 ns |         - |
| Decrypt · AES-256-GCM (Managed)           | 17B          |     382.74 ns |     1.482 ns |     1.237 ns |         - |
| Decrypt · AES-256-GCM (BouncyCastle)      | 17B          |     644.88 ns |     3.685 ns |     3.447 ns |    1832 B |
|                                           |              |               |              |              |           |
| Encrypt · AES-256-GCM (AES-NI+PClMul)     | 17B          |      68.81 ns |     0.122 ns |     0.108 ns |         - |
| Encrypt · AES-256-GCM (AES-NI+PClMulV256) | 17B          |      69.39 ns |     0.136 ns |     0.121 ns |         - |
| Encrypt · AES-256-GCM (OS)                | 17B          |     130.51 ns |     0.584 ns |     0.546 ns |         - |
| Encrypt · AES-256-GCM (Managed)           | 17B          |     345.12 ns |     1.129 ns |     1.056 ns |         - |
| Encrypt · AES-256-GCM (BouncyCastle)      | 17B          |     600.85 ns |     3.506 ns |     3.280 ns |    1816 B |
|                                           |              |               |              |              |           |
| Decrypt · AES-256-GCM (AES-NI+PClMul)     | 65B          |     109.08 ns |     0.549 ns |     0.513 ns |         - |
| Decrypt · AES-256-GCM (AES-NI+PClMulV256) | 65B          |     109.20 ns |     0.213 ns |     0.189 ns |         - |
| Decrypt · AES-256-GCM (OS)                | 65B          |     126.78 ns |     0.585 ns |     0.547 ns |         - |
| Decrypt · AES-256-GCM (Managed)           | 65B          |     662.58 ns |     4.395 ns |     4.112 ns |         - |
| Decrypt · AES-256-GCM (BouncyCastle)      | 65B          |     884.33 ns |     3.945 ns |     3.690 ns |    1832 B |
|                                           |              |               |              |              |           |
| Encrypt · AES-256-GCM (AES-NI+PClMulV256) | 65B          |      77.05 ns |     0.135 ns |     0.105 ns |         - |
| Encrypt · AES-256-GCM (AES-NI+PClMul)     | 65B          |      77.37 ns |     0.222 ns |     0.197 ns |         - |
| Encrypt · AES-256-GCM (OS)                | 65B          |     131.87 ns |     0.591 ns |     0.553 ns |         - |
| Encrypt · AES-256-GCM (Managed)           | 65B          |     626.16 ns |     3.679 ns |     3.441 ns |         - |
| Encrypt · AES-256-GCM (BouncyCastle)      | 65B          |     795.94 ns |     3.402 ns |     3.182 ns |    1816 B |
|                                           |              |               |              |              |           |
| Decrypt · AES-256-GCM (AES-NI+PClMulV256) | 128B         |     107.19 ns |     0.540 ns |     0.479 ns |         - |
| Decrypt · AES-256-GCM (AES-NI+PClMul)     | 128B         |     108.44 ns |     0.309 ns |     0.274 ns |         - |
| Decrypt · AES-256-GCM (OS)                | 128B         |     121.92 ns |     0.490 ns |     0.434 ns |         - |
| Decrypt · AES-256-GCM (Managed)           | 128B         |     948.20 ns |     5.615 ns |     5.252 ns |         - |
| Decrypt · AES-256-GCM (BouncyCastle)      | 128B         |   1,056.85 ns |     6.403 ns |     5.676 ns |    1832 B |
|                                           |              |               |              |              |           |
| Encrypt · AES-256-GCM (AES-NI+PClMulV256) | 128B         |      63.54 ns |     0.213 ns |     0.189 ns |         - |
| Encrypt · AES-256-GCM (AES-NI+PClMul)     | 128B         |      71.46 ns |     0.224 ns |     0.209 ns |         - |
| Encrypt · AES-256-GCM (OS)                | 128B         |     123.50 ns |     0.612 ns |     0.573 ns |         - |
| Encrypt · AES-256-GCM (Managed)           | 128B         |     904.82 ns |     3.732 ns |     3.308 ns |         - |
| Encrypt · AES-256-GCM (BouncyCastle)      | 128B         |   1,012.70 ns |     4.668 ns |     4.366 ns |    1816 B |
|                                           |              |               |              |              |           |
| Decrypt · AES-256-GCM (AES-NI+PClMul)     | 152B         |     131.08 ns |     0.858 ns |     0.802 ns |         - |
| Decrypt · AES-256-GCM (AES-NI+PClMulV256) | 152B         |     131.99 ns |     0.787 ns |     0.698 ns |         - |
| Decrypt · AES-256-GCM (OS)                | 152B         |     142.00 ns |     0.315 ns |     0.280 ns |         - |
| Decrypt · AES-256-GCM (Managed)           | 152B         |   1,127.07 ns |     6.519 ns |     6.098 ns |         - |
| Decrypt · AES-256-GCM (BouncyCastle)      | 152B         |   1,214.17 ns |     9.240 ns |     8.191 ns |    1832 B |
|                                           |              |               |              |              |           |
| Encrypt · AES-256-GCM (AES-NI+PClMulV256) | 152B         |      92.68 ns |     0.178 ns |     0.158 ns |         - |
| Encrypt · AES-256-GCM (AES-NI+PClMul)     | 152B         |      94.24 ns |     0.395 ns |     0.370 ns |         - |
| Encrypt · AES-256-GCM (OS)                | 152B         |     148.24 ns |     0.851 ns |     0.796 ns |         - |
| Encrypt · AES-256-GCM (Managed)           | 152B         |   1,096.46 ns |     5.063 ns |     4.228 ns |         - |
| Encrypt · AES-256-GCM (BouncyCastle)      | 152B         |   1,122.65 ns |     6.721 ns |     6.287 ns |    1816 B |
|                                           |              |               |              |              |           |
| Decrypt · AES-256-GCM (AES-NI+PClMulV256) | 256B         |     122.88 ns |     1.284 ns |     1.201 ns |         - |
| Decrypt · AES-256-GCM (AES-NI+PClMul)     | 256B         |     131.46 ns |     0.889 ns |     0.832 ns |         - |
| Decrypt · AES-256-GCM (OS)                | 256B         |     134.13 ns |     0.575 ns |     0.509 ns |         - |
| Decrypt · AES-256-GCM (BouncyCastle)      | 256B         |   1,590.66 ns |     6.639 ns |     5.885 ns |    1832 B |
| Decrypt · AES-256-GCM (Managed)           | 256B         |   1,698.82 ns |    11.399 ns |    10.663 ns |         - |
|                                           |              |               |              |              |           |
| Encrypt · AES-256-GCM (AES-NI+PClMulV256) | 256B         |      83.18 ns |     0.284 ns |     0.237 ns |         - |
| Encrypt · AES-256-GCM (AES-NI+PClMul)     | 256B         |      88.55 ns |     0.305 ns |     0.286 ns |         - |
| Encrypt · AES-256-GCM (OS)                | 256B         |     127.40 ns |     0.420 ns |     0.372 ns |         - |
| Encrypt · AES-256-GCM (BouncyCastle)      | 256B         |   1,481.70 ns |     5.179 ns |     4.591 ns |    1816 B |
| Encrypt · AES-256-GCM (Managed)           | 256B         |   1,650.46 ns |     7.357 ns |     6.144 ns |         - |
|                                           |              |               |              |              |           |
| Decrypt · AES-256-GCM (AES-NI+PClMulV256) | 1KB          |     218.63 ns |     0.611 ns |     0.541 ns |         - |
| Decrypt · AES-256-GCM (OS)                | 1KB          |     220.69 ns |     0.655 ns |     0.613 ns |         - |
| Decrypt · AES-256-GCM (AES-NI+PClMul)     | 1KB          |     267.59 ns |     0.883 ns |     0.783 ns |         - |
| Decrypt · AES-256-GCM (BouncyCastle)      | 1KB          |   4,687.06 ns |    27.773 ns |    25.979 ns |    1832 B |
| Decrypt · AES-256-GCM (Managed)           | 1KB          |   6,157.86 ns |    22.056 ns |    20.631 ns |         - |
|                                           |              |               |              |              |           |
| Encrypt · AES-256-GCM (OS)                | 1KB          |     183.41 ns |     0.504 ns |     0.472 ns |         - |
| Encrypt · AES-256-GCM (AES-NI+PClMulV256) | 1KB          |     201.37 ns |     0.787 ns |     0.736 ns |         - |
| Encrypt · AES-256-GCM (AES-NI+PClMul)     | 1KB          |     223.81 ns |     0.669 ns |     0.593 ns |         - |
| Encrypt · AES-256-GCM (BouncyCastle)      | 1KB          |   4,614.02 ns |    32.285 ns |    28.619 ns |    1816 B |
| Encrypt · AES-256-GCM (Managed)           | 1KB          |   6,118.87 ns |    27.491 ns |    25.715 ns |         - |
|                                           |              |               |              |              |           |
| Decrypt · AES-256-GCM (OS)                | 8KB          |     936.73 ns |     3.258 ns |     3.047 ns |         - |
| Decrypt · AES-256-GCM (AES-NI+PClMulV256) | 8KB          |   1,168.22 ns |     5.238 ns |     4.644 ns |         - |
| Decrypt · AES-256-GCM (AES-NI+PClMul)     | 8KB          |   1,554.83 ns |     8.923 ns |     8.347 ns |         - |
| Decrypt · AES-256-GCM (BouncyCastle)      | 8KB          |  33,577.14 ns |   190.100 ns |   168.518 ns |    1832 B |
| Decrypt · AES-256-GCM (Managed)           | 8KB          |  47,817.30 ns |   235.168 ns |   208.470 ns |         - |
|                                           |              |               |              |              |           |
| Encrypt · AES-256-GCM (OS)                | 8KB          |     729.36 ns |     5.497 ns |     5.142 ns |         - |
| Encrypt · AES-256-GCM (AES-NI+PClMulV256) | 8KB          |   1,305.50 ns |     5.511 ns |     4.602 ns |         - |
| Encrypt · AES-256-GCM (AES-NI+PClMul)     | 8KB          |   1,477.81 ns |     4.976 ns |     4.654 ns |         - |
| Encrypt · AES-256-GCM (BouncyCastle)      | 8KB          |  33,284.19 ns |   149.876 ns |   132.861 ns |    1816 B |
| Encrypt · AES-256-GCM (Managed)           | 8KB          |  47,789.42 ns |    95.041 ns |    84.251 ns |         - |
|                                           |              |               |              |              |           |
| Decrypt · AES-256-GCM (OS)                | 128KB        |  14,265.22 ns |    47.633 ns |    44.556 ns |         - |
| Decrypt · AES-256-GCM (AES-NI+PClMulV256) | 128KB        |  17,535.12 ns |   220.158 ns |   205.936 ns |         - |
| Decrypt · AES-256-GCM (AES-NI+PClMul)     | 128KB        |  23,406.55 ns |   129.596 ns |   114.883 ns |         - |
| Decrypt · AES-256-GCM (BouncyCastle)      | 128KB        | 530,424.36 ns | 4,877.317 ns | 4,562.246 ns |    1832 B |
| Decrypt · AES-256-GCM (Managed)           | 128KB        | 765,189.91 ns | 3,844.945 ns | 3,408.444 ns |         - |
|                                           |              |               |              |              |           |
| Encrypt · AES-256-GCM (OS)                | 128KB        |  10,592.03 ns |    68.171 ns |    63.767 ns |         - |
| Encrypt · AES-256-GCM (AES-NI+PClMulV256) | 128KB        |  20,264.57 ns |    71.643 ns |    59.825 ns |         - |
| Encrypt · AES-256-GCM (AES-NI+PClMul)     | 128KB        |  23,047.55 ns |   195.404 ns |   182.781 ns |         - |
| Encrypt · AES-256-GCM (BouncyCastle)      | 128KB        | 526,690.43 ns | 2,718.741 ns | 2,543.112 ns |    1816 B |
| Encrypt · AES-256-GCM (Managed)           | 128KB        | 764,229.17 ns | 2,364.723 ns | 2,211.963 ns |         - |