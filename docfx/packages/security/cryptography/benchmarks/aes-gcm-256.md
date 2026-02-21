| Description                               | TestDataSize | Mean          | Error        | StdDev       | Allocated |
|------------------------------------------ |------------- |--------------:|-------------:|-------------:|----------:|
| Decrypt · AES-256-GCM (AES-NI+PClMul)     | 128B         |      75.30 ns |     1.353 ns |     1.265 ns |         - |
| Decrypt · AES-256-GCM (AES-NI+PClMulV256) | 128B         |      78.04 ns |     0.704 ns |     0.659 ns |         - |
| Decrypt · AES-256-GCM (OS)                | 128B         |     124.05 ns |     1.245 ns |     1.165 ns |         - |
| Decrypt · AES-256-GCM (AES-NI)            | 128B         |     614.06 ns |     9.642 ns |     9.019 ns |         - |
| Decrypt · AES-256-GCM (PClMul)            | 128B         |     616.39 ns |    12.022 ns |    15.204 ns |         - |
| Decrypt · AES-256-GCM (Managed)           | 128B         |     947.57 ns |     6.406 ns |     5.679 ns |         - |
| Decrypt · AES-256-GCM (BouncyCastle)      | 128B         |   1,074.20 ns |     8.374 ns |     7.833 ns |    1832 B |
|                                           |              |               |              |              |           |
| Encrypt · AES-256-GCM (AES-NI+PClMulV256) | 128B         |      65.08 ns |     1.223 ns |     1.084 ns |         - |
| Encrypt · AES-256-GCM (AES-NI+PClMul)     | 128B         |      66.64 ns |     1.305 ns |     1.221 ns |         - |
| Encrypt · AES-256-GCM (OS)                | 128B         |     144.63 ns |     1.741 ns |     1.629 ns |         - |
| Encrypt · AES-256-GCM (AES-NI)            | 128B         |     566.01 ns |     8.841 ns |     8.270 ns |         - |
| Encrypt · AES-256-GCM (PClMul)            | 128B         |     571.51 ns |    10.151 ns |     9.495 ns |         - |
| Encrypt · AES-256-GCM (Managed)           | 128B         |     932.16 ns |     6.261 ns |     5.857 ns |         - |
| Encrypt · AES-256-GCM (BouncyCastle)      | 128B         |   1,008.77 ns |    19.339 ns |    18.994 ns |    1816 B |
|                                           |              |               |              |              |           |
| Decrypt · AES-256-GCM (OS)                | 1KB          |     209.96 ns |     1.662 ns |     1.554 ns |         - |
| Decrypt · AES-256-GCM (AES-NI+PClMulV256) | 1KB          |     233.43 ns |     0.970 ns |     0.810 ns |         - |
| Decrypt · AES-256-GCM (AES-NI+PClMul)     | 1KB          |     256.94 ns |     2.843 ns |     2.660 ns |         - |
| Decrypt · AES-256-GCM (AES-NI)            | 1KB          |   3,746.25 ns |    20.327 ns |    19.014 ns |         - |
| Decrypt · AES-256-GCM (PClMul)            | 1KB          |   3,880.23 ns |    27.365 ns |    25.597 ns |         - |
| Decrypt · AES-256-GCM (BouncyCastle)      | 1KB          |   4,718.90 ns |    24.231 ns |    21.480 ns |    1832 B |
| Decrypt · AES-256-GCM (Managed)           | 1KB          |   6,207.45 ns |    29.938 ns |    28.004 ns |         - |
|                                           |              |               |              |              |           |
| Encrypt · AES-256-GCM (OS)                | 1KB          |     189.13 ns |     2.010 ns |     1.880 ns |         - |
| Encrypt · AES-256-GCM (AES-NI+PClMulV256) | 1KB          |     205.38 ns |     2.057 ns |     1.924 ns |         - |
| Encrypt · AES-256-GCM (AES-NI+PClMul)     | 1KB          |     227.96 ns |     1.676 ns |     1.486 ns |         - |
| Encrypt · AES-256-GCM (AES-NI)            | 1KB          |   3,769.78 ns |    18.155 ns |    16.983 ns |         - |
| Encrypt · AES-256-GCM (PClMul)            | 1KB          |   3,936.26 ns |    77.748 ns |    72.725 ns |         - |
| Encrypt · AES-256-GCM (BouncyCastle)      | 1KB          |   4,756.90 ns |    59.473 ns |    55.631 ns |    1816 B |
| Encrypt · AES-256-GCM (Managed)           | 1KB          |   6,315.38 ns |    77.920 ns |    69.074 ns |         - |
|                                           |              |               |              |              |           |
| Decrypt · AES-256-GCM (OS)                | 8KB          |     921.40 ns |     5.939 ns |     5.555 ns |         - |
| Decrypt · AES-256-GCM (AES-NI+PClMulV256) | 8KB          |   1,336.04 ns |     9.287 ns |     8.687 ns |         - |
| Decrypt · AES-256-GCM (AES-NI+PClMul)     | 8KB          |   1,529.60 ns |    13.122 ns |    12.274 ns |         - |
| Decrypt · AES-256-GCM (AES-NI)            | 8KB          |  28,934.86 ns |   144.576 ns |   135.236 ns |         - |
| Decrypt · AES-256-GCM (PClMul)            | 8KB          |  30,018.78 ns |   309.425 ns |   289.436 ns |         - |
| Decrypt · AES-256-GCM (BouncyCastle)      | 8KB          |  33,669.98 ns |   205.237 ns |   191.979 ns |    1832 B |
| Decrypt · AES-256-GCM (Managed)           | 8KB          |  48,126.24 ns |   296.826 ns |   277.652 ns |         - |
|                                           |              |               |              |              |           |
| Encrypt · AES-256-GCM (OS)                | 8KB          |     719.50 ns |     7.688 ns |     7.191 ns |         - |
| Encrypt · AES-256-GCM (AES-NI+PClMulV256) | 8KB          |   1,342.56 ns |    21.116 ns |    19.752 ns |         - |
| Encrypt · AES-256-GCM (AES-NI+PClMul)     | 8KB          |   1,516.91 ns |    15.033 ns |    14.061 ns |         - |
| Encrypt · AES-256-GCM (AES-NI)            | 8KB          |  29,431.87 ns |   105.189 ns |    98.394 ns |         - |
| Encrypt · AES-256-GCM (PClMul)            | 8KB          |  30,835.00 ns |   228.910 ns |   214.123 ns |         - |
| Encrypt · AES-256-GCM (BouncyCastle)      | 8KB          |  33,858.06 ns |   275.144 ns |   229.758 ns |    1816 B |
| Encrypt · AES-256-GCM (Managed)           | 8KB          |  48,857.22 ns |   630.789 ns |   492.479 ns |         - |
|                                           |              |               |              |              |           |
| Decrypt · AES-256-GCM (OS)                | 128KB        |  15,288.76 ns |   279.456 ns |   261.403 ns |         - |
| Decrypt · AES-256-GCM (AES-NI+PClMulV256) | 128KB        |  20,310.12 ns |   164.941 ns |   154.286 ns |         - |
| Decrypt · AES-256-GCM (AES-NI+PClMul)     | 128KB        |  23,042.21 ns |   134.279 ns |   125.604 ns |         - |
| Decrypt · AES-256-GCM (AES-NI)            | 128KB        | 460,284.88 ns | 2,157.332 ns | 2,017.969 ns |         - |
| Decrypt · AES-256-GCM (PClMul)            | 128KB        | 480,126.47 ns | 3,028.815 ns | 2,833.155 ns |         - |
| Decrypt · AES-256-GCM (BouncyCastle)      | 128KB        | 531,762.41 ns | 3,945.590 ns | 3,690.707 ns |    1832 B |
| Decrypt · AES-256-GCM (Managed)           | 128KB        | 769,806.43 ns | 5,765.566 ns | 5,393.114 ns |         - |
|                                           |              |               |              |              |           |
| Encrypt · AES-256-GCM (OS)                | 128KB        |  10,893.81 ns |   160.180 ns |   149.832 ns |         - |
| Encrypt · AES-256-GCM (AES-NI+PClMulV256) | 128KB        |  20,864.83 ns |   331.960 ns |   326.029 ns |         - |
| Encrypt · AES-256-GCM (AES-NI+PClMul)     | 128KB        |  23,863.91 ns |   359.297 ns |   280.515 ns |         - |
| Encrypt · AES-256-GCM (AES-NI)            | 128KB        | 464,820.76 ns | 1,910.727 ns | 1,787.295 ns |         - |
| Encrypt · AES-256-GCM (PClMul)            | 128KB        | 483,100.66 ns | 1,714.647 ns | 1,519.990 ns |         - |
| Encrypt · AES-256-GCM (BouncyCastle)      | 128KB        | 547,402.46 ns | 8,101.967 ns | 7,578.585 ns |    1816 B |
| Encrypt · AES-256-GCM (Managed)           | 128KB        | 794,377.28 ns | 9,155.005 ns | 8,563.598 ns |         - |