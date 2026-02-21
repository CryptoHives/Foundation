| Description                               | TestDataSize | Mean          | Error        | StdDev       | Allocated |
|------------------------------------------ |------------- |--------------:|-------------:|-------------:|----------:|
| Decrypt · AES-128-GCM (AES-NI+PClMulV256) | 128B         |      70.44 ns |     0.266 ns |     0.249 ns |         - |
| Decrypt · AES-128-GCM (AES-NI+PClMul)     | 128B         |      72.49 ns |     0.467 ns |     0.437 ns |         - |
| Decrypt · AES-128-GCM (OS)                | 128B         |     119.90 ns |     0.731 ns |     0.684 ns |         - |
| Decrypt · AES-128-GCM (PClMul)            | 128B         |     466.49 ns |     2.302 ns |     2.153 ns |         - |
| Decrypt · AES-128-GCM (AES-NI)            | 128B         |     561.30 ns |     2.631 ns |     2.333 ns |         - |
| Decrypt · AES-128-GCM (Managed)           | 128B         |     823.96 ns |     3.497 ns |     3.271 ns |         - |
| Decrypt · AES-128-GCM (BouncyCastle)      | 128B         |     883.74 ns |     3.612 ns |     3.378 ns |    1624 B |
|                                           |              |               |              |              |           |
| Encrypt · AES-128-GCM (AES-NI+PClMulV256) | 128B         |      57.13 ns |     0.221 ns |     0.207 ns |         - |
| Encrypt · AES-128-GCM (AES-NI+PClMul)     | 128B         |      59.07 ns |     0.281 ns |     0.249 ns |         - |
| Encrypt · AES-128-GCM (OS)                | 128B         |     117.53 ns |     0.539 ns |     0.477 ns |         - |
| Encrypt · AES-128-GCM (PClMul)            | 128B         |     435.83 ns |     2.480 ns |     2.320 ns |         - |
| Encrypt · AES-128-GCM (AES-NI)            | 128B         |     522.65 ns |     2.709 ns |     2.402 ns |         - |
| Encrypt · AES-128-GCM (BouncyCastle)      | 128B         |     788.93 ns |     3.716 ns |     3.476 ns |    1608 B |
| Encrypt · AES-128-GCM (Managed)           | 128B         |     802.35 ns |     2.734 ns |     2.557 ns |         - |
|                                           |              |               |              |              |           |
| Decrypt · AES-128-GCM (OS)                | 1KB          |     176.15 ns |     0.721 ns |     0.675 ns |         - |
| Decrypt · AES-128-GCM (AES-NI+PClMulV256) | 1KB          |     205.66 ns |     1.175 ns |     1.099 ns |         - |
| Decrypt · AES-128-GCM (AES-NI+PClMul)     | 1KB          |     236.99 ns |     1.610 ns |     1.506 ns |         - |
| Decrypt · AES-128-GCM (PClMul)            | 1KB          |   2,993.54 ns |    18.181 ns |    17.006 ns |         - |
| Decrypt · AES-128-GCM (BouncyCastle)      | 1KB          |   3,640.24 ns |    23.134 ns |    20.508 ns |    1624 B |
| Decrypt · AES-128-GCM (AES-NI)            | 1KB          |   3,666.65 ns |    18.963 ns |    17.738 ns |         - |
| Decrypt · AES-128-GCM (Managed)           | 1KB          |   5,369.70 ns |    38.115 ns |    33.788 ns |         - |
|                                           |              |               |              |              |           |
| Encrypt · AES-128-GCM (AES-NI+PClMulV256) | 1KB          |     170.75 ns |     0.687 ns |     0.609 ns |         - |
| Encrypt · AES-128-GCM (OS)                | 1KB          |     170.91 ns |     1.748 ns |     1.635 ns |         - |
| Encrypt · AES-128-GCM (AES-NI+PClMul)     | 1KB          |     194.91 ns |     0.794 ns |     0.743 ns |         - |
| Encrypt · AES-128-GCM (PClMul)            | 1KB          |   2,963.31 ns |    11.692 ns |    10.365 ns |         - |
| Encrypt · AES-128-GCM (AES-NI)            | 1KB          |   3,554.55 ns |     9.538 ns |     8.456 ns |         - |
| Encrypt · AES-128-GCM (BouncyCastle)      | 1KB          |   3,558.87 ns |    16.555 ns |    15.486 ns |    1608 B |
| Encrypt · AES-128-GCM (Managed)           | 1KB          |   5,276.12 ns |    23.703 ns |    22.172 ns |         - |
|                                           |              |               |              |              |           |
| Decrypt · AES-128-GCM (OS)                | 8KB          |     717.04 ns |     3.334 ns |     3.118 ns |         - |
| Decrypt · AES-128-GCM (AES-NI+PClMulV256) | 8KB          |   1,144.48 ns |     6.757 ns |     6.321 ns |         - |
| Decrypt · AES-128-GCM (AES-NI+PClMul)     | 8KB          |   1,386.37 ns |     8.170 ns |     7.642 ns |         - |
| Decrypt · AES-128-GCM (PClMul)            | 8KB          |  23,181.89 ns |   172.843 ns |   161.677 ns |         - |
| Decrypt · AES-128-GCM (BouncyCastle)      | 8KB          |  25,522.49 ns |    92.149 ns |    81.688 ns |    1624 B |
| Decrypt · AES-128-GCM (AES-NI)            | 8KB          |  27,212.38 ns |    71.242 ns |    66.639 ns |         - |
| Decrypt · AES-128-GCM (Managed)           | 8KB          |  41,268.31 ns |   144.948 ns |   135.584 ns |         - |
|                                           |              |               |              |              |           |
| Encrypt · AES-128-GCM (OS)                | 8KB          |     648.95 ns |     5.024 ns |     4.700 ns |         - |
| Encrypt · AES-128-GCM (AES-NI+PClMulV256) | 8KB          |   1,080.12 ns |     8.608 ns |     8.052 ns |         - |
| Encrypt · AES-128-GCM (AES-NI+PClMul)     | 8KB          |   1,291.12 ns |     6.069 ns |     5.677 ns |         - |
| Encrypt · AES-128-GCM (PClMul)            | 8KB          |  23,118.19 ns |   142.914 ns |   133.682 ns |         - |
| Encrypt · AES-128-GCM (BouncyCastle)      | 8KB          |  25,373.82 ns |   107.103 ns |   100.184 ns |    1608 B |
| Encrypt · AES-128-GCM (AES-NI)            | 8KB          |  27,388.90 ns |   107.604 ns |   100.652 ns |         - |
| Encrypt · AES-128-GCM (Managed)           | 8KB          |  41,182.34 ns |   151.218 ns |   141.449 ns |         - |
|                                           |              |               |              |              |           |
| Decrypt · AES-128-GCM (OS)                | 128KB        |  10,671.50 ns |    48.348 ns |    42.859 ns |         - |
| Decrypt · AES-128-GCM (AES-NI+PClMulV256) | 128KB        |  17,473.63 ns |   106.662 ns |    99.771 ns |         - |
| Decrypt · AES-128-GCM (AES-NI+PClMul)     | 128KB        |  21,164.14 ns |   105.356 ns |    93.396 ns |         - |
| Decrypt · AES-128-GCM (PClMul)            | 128KB        | 368,385.92 ns | 1,152.250 ns | 1,021.440 ns |         - |
| Decrypt · AES-128-GCM (BouncyCastle)      | 128KB        | 402,922.64 ns | 2,622.719 ns | 2,453.293 ns |    1624 B |
| Decrypt · AES-128-GCM (AES-NI)            | 128KB        | 434,793.54 ns | 1,464.670 ns | 1,298.392 ns |         - |
| Decrypt · AES-128-GCM (Managed)           | 128KB        | 658,886.31 ns | 2,690.009 ns | 2,516.236 ns |         - |
|                                           |              |               |              |              |           |
| Encrypt · AES-128-GCM (OS)                | 128KB        |  10,354.31 ns |    89.159 ns |    83.399 ns |         - |
| Encrypt · AES-128-GCM (AES-NI+PClMulV256) | 128KB        |  16,704.61 ns |    68.358 ns |    57.082 ns |         - |
| Encrypt · AES-128-GCM (AES-NI+PClMul)     | 128KB        |  20,171.35 ns |    96.782 ns |    90.530 ns |         - |
| Encrypt · AES-128-GCM (PClMul)            | 128KB        | 368,635.67 ns | 1,804.611 ns | 1,688.035 ns |         - |
| Encrypt · AES-128-GCM (BouncyCastle)      | 128KB        | 410,570.39 ns | 7,433.539 ns | 6,953.337 ns |    1608 B |
| Encrypt · AES-128-GCM (AES-NI)            | 128KB        | 433,387.32 ns |   792.440 ns |   618.685 ns |         - |
| Encrypt · AES-128-GCM (Managed)           | 128KB        | 676,206.31 ns | 4,959.580 ns | 4,141.474 ns |         - |