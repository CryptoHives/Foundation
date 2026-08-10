| Description                               | TestDataSize | Mean          | Error        | StdDev       | Allocated |
|------------------------------------------ |------------- |--------------:|-------------:|-------------:|----------:|
| Decrypt · AES-256-GCM (AES-NI+PClMulV256) | 17B          |     118.89 ns |     0.844 ns |     0.705 ns |         - |
| Decrypt · AES-256-GCM (AES-NI+PClMul)     | 17B          |     119.57 ns |     0.255 ns |     0.199 ns |         - |
| Decrypt · AES-256-GCM (OS)                | 17B          |     127.17 ns |     0.890 ns |     0.833 ns |         - |
| Decrypt · AES-256-GCM (Managed)           | 17B          |     382.53 ns |     1.574 ns |     1.314 ns |         - |
| Decrypt · AES-256-GCM (BouncyCastle)      | 17B          |     662.88 ns |     6.107 ns |     5.414 ns |    1832 B |
|                                           |              |               |              |              |           |
| Encrypt · AES-256-GCM (AES-NI+PClMulV256) | 17B          |      69.11 ns |     0.364 ns |     0.285 ns |         - |
| Encrypt · AES-256-GCM (AES-NI+PClMul)     | 17B          |      69.60 ns |     0.254 ns |     0.238 ns |         - |
| Encrypt · AES-256-GCM (OS)                | 17B          |     129.90 ns |     0.675 ns |     0.632 ns |         - |
| Encrypt · AES-256-GCM (Managed)           | 17B          |     351.72 ns |     3.373 ns |     3.155 ns |         - |
| Encrypt · AES-256-GCM (BouncyCastle)      | 17B          |     603.54 ns |     6.660 ns |     5.904 ns |    1816 B |
|                                           |              |               |              |              |           |
| Decrypt · AES-256-GCM (AES-NI+PClMulV256) | 65B          |     107.13 ns |     0.301 ns |     0.252 ns |         - |
| Decrypt · AES-256-GCM (AES-NI+PClMul)     | 65B          |     109.64 ns |     0.550 ns |     0.487 ns |         - |
| Decrypt · AES-256-GCM (OS)                | 65B          |     127.01 ns |     1.359 ns |     1.271 ns |         - |
| Decrypt · AES-256-GCM (Managed)           | 65B          |     668.95 ns |     5.996 ns |     5.315 ns |         - |
| Decrypt · AES-256-GCM (BouncyCastle)      | 65B          |     892.44 ns |     6.545 ns |     5.802 ns |    1832 B |
|                                           |              |               |              |              |           |
| Encrypt · AES-256-GCM (AES-NI+PClMul)     | 65B          |      77.66 ns |     0.371 ns |     0.329 ns |         - |
| Encrypt · AES-256-GCM (AES-NI+PClMulV256) | 65B          |      77.91 ns |     0.144 ns |     0.128 ns |         - |
| Encrypt · AES-256-GCM (OS)                | 65B          |     134.37 ns |     1.045 ns |     0.927 ns |         - |
| Encrypt · AES-256-GCM (Managed)           | 65B          |     643.97 ns |     4.826 ns |     4.515 ns |         - |
| Encrypt · AES-256-GCM (BouncyCastle)      | 65B          |     805.13 ns |     7.322 ns |     6.491 ns |    1816 B |
|                                           |              |               |              |              |           |
| Decrypt · AES-256-GCM (AES-NI+PClMulV256) | 128B         |     100.68 ns |     0.583 ns |     0.545 ns |         - |
| Decrypt · AES-256-GCM (AES-NI+PClMul)     | 128B         |     101.89 ns |     0.802 ns |     0.711 ns |         - |
| Decrypt · AES-256-GCM (OS)                | 128B         |     123.44 ns |     1.033 ns |     0.967 ns |         - |
| Decrypt · AES-256-GCM (Managed)           | 128B         |     945.40 ns |     6.214 ns |     5.813 ns |         - |
| Decrypt · AES-256-GCM (BouncyCastle)      | 128B         |   1,070.03 ns |     7.843 ns |     6.123 ns |    1832 B |
|                                           |              |               |              |              |           |
| Encrypt · AES-256-GCM (AES-NI+PClMulV256) | 128B         |      62.80 ns |     0.488 ns |     0.457 ns |         - |
| Encrypt · AES-256-GCM (AES-NI+PClMul)     | 128B         |      65.55 ns |     0.355 ns |     0.315 ns |         - |
| Encrypt · AES-256-GCM (OS)                | 128B         |     125.39 ns |     1.416 ns |     1.325 ns |         - |
| Encrypt · AES-256-GCM (Managed)           | 128B         |     915.84 ns |     7.820 ns |     7.315 ns |         - |
| Encrypt · AES-256-GCM (BouncyCastle)      | 128B         |     981.03 ns |    12.046 ns |    11.268 ns |    1816 B |
|                                           |              |               |              |              |           |
| Decrypt · AES-256-GCM (AES-NI+PClMul)     | 152B         |     129.66 ns |     0.587 ns |     0.549 ns |         - |
| Decrypt · AES-256-GCM (AES-NI+PClMulV256) | 152B         |     130.17 ns |     0.494 ns |     0.462 ns |         - |
| Decrypt · AES-256-GCM (OS)                | 152B         |     143.35 ns |     0.908 ns |     0.758 ns |         - |
| Decrypt · AES-256-GCM (Managed)           | 152B         |   1,143.06 ns |    19.829 ns |    18.548 ns |         - |
| Decrypt · AES-256-GCM (BouncyCastle)      | 152B         |   1,234.76 ns |    10.857 ns |     9.066 ns |    1832 B |
|                                           |              |               |              |              |           |
| Encrypt · AES-256-GCM (AES-NI+PClMulV256) | 152B         |      92.62 ns |     0.551 ns |     0.516 ns |         - |
| Encrypt · AES-256-GCM (AES-NI+PClMul)     | 152B         |      93.95 ns |     0.504 ns |     0.447 ns |         - |
| Encrypt · AES-256-GCM (OS)                | 152B         |     145.69 ns |     1.304 ns |     1.219 ns |         - |
| Encrypt · AES-256-GCM (Managed)           | 152B         |   1,109.88 ns |    12.589 ns |    11.776 ns |         - |
| Encrypt · AES-256-GCM (BouncyCastle)      | 152B         |   1,126.41 ns |    10.300 ns |     9.131 ns |    1816 B |
|                                           |              |               |              |              |           |
| Decrypt · AES-256-GCM (AES-NI+PClMulV256) | 256B         |     116.71 ns |     0.593 ns |     0.554 ns |         - |
| Decrypt · AES-256-GCM (AES-NI+PClMul)     | 256B         |     126.91 ns |     0.978 ns |     0.915 ns |         - |
| Decrypt · AES-256-GCM (OS)                | 256B         |     136.67 ns |     0.954 ns |     0.892 ns |         - |
| Decrypt · AES-256-GCM (BouncyCastle)      | 256B         |   1,609.70 ns |    10.894 ns |     9.097 ns |    1832 B |
| Decrypt · AES-256-GCM (Managed)           | 256B         |   1,699.13 ns |    11.966 ns |    11.193 ns |         - |
|                                           |              |               |              |              |           |
| Encrypt · AES-256-GCM (AES-NI+PClMulV256) | 256B         |      83.50 ns |     0.513 ns |     0.479 ns |         - |
| Encrypt · AES-256-GCM (AES-NI+PClMul)     | 256B         |      88.80 ns |     0.333 ns |     0.295 ns |         - |
| Encrypt · AES-256-GCM (OS)                | 256B         |     128.85 ns |     0.987 ns |     0.923 ns |         - |
| Encrypt · AES-256-GCM (BouncyCastle)      | 256B         |   1,502.56 ns |    10.865 ns |    10.163 ns |    1816 B |
| Encrypt · AES-256-GCM (Managed)           | 256B         |   1,662.25 ns |     6.886 ns |     5.750 ns |         - |
|                                           |              |               |              |              |           |
| Decrypt · AES-256-GCM (OS)                | 1KB          |     210.67 ns |     0.763 ns |     0.714 ns |         - |
| Decrypt · AES-256-GCM (AES-NI+PClMulV256) | 1KB          |     215.21 ns |     1.467 ns |     1.300 ns |         - |
| Decrypt · AES-256-GCM (AES-NI+PClMul)     | 1KB          |     262.97 ns |     2.319 ns |     2.169 ns |         - |
| Decrypt · AES-256-GCM (BouncyCastle)      | 1KB          |   4,724.42 ns |    43.730 ns |    40.905 ns |    1832 B |
| Decrypt · AES-256-GCM (Managed)           | 1KB          |   6,227.20 ns |    56.776 ns |    53.109 ns |         - |
|                                           |              |               |              |              |           |
| Encrypt · AES-256-GCM (OS)                | 1KB          |     181.57 ns |     1.637 ns |     1.531 ns |         - |
| Encrypt · AES-256-GCM (AES-NI+PClMulV256) | 1KB          |     201.35 ns |     0.725 ns |     0.678 ns |         - |
| Encrypt · AES-256-GCM (AES-NI+PClMul)     | 1KB          |     223.50 ns |     1.544 ns |     1.444 ns |         - |
| Encrypt · AES-256-GCM (BouncyCastle)      | 1KB          |   4,624.47 ns |    24.170 ns |    20.183 ns |    1816 B |
| Encrypt · AES-256-GCM (Managed)           | 1KB          |   6,245.11 ns |    43.910 ns |    38.925 ns |         - |
|                                           |              |               |              |              |           |
| Decrypt · AES-256-GCM (OS)                | 8KB          |     927.41 ns |     5.267 ns |     4.927 ns |         - |
| Decrypt · AES-256-GCM (AES-NI+PClMulV256) | 8KB          |   1,146.68 ns |     8.181 ns |     7.653 ns |         - |
| Decrypt · AES-256-GCM (AES-NI+PClMul)     | 8KB          |   1,547.15 ns |     8.277 ns |     6.463 ns |         - |
| Decrypt · AES-256-GCM (BouncyCastle)      | 8KB          |  33,774.57 ns |   217.488 ns |   192.797 ns |    1832 B |
| Decrypt · AES-256-GCM (Managed)           | 8KB          |  48,476.54 ns |   360.853 ns |   337.542 ns |         - |
|                                           |              |               |              |              |           |
| Encrypt · AES-256-GCM (OS)                | 8KB          |     718.18 ns |    10.613 ns |     9.408 ns |         - |
| Encrypt · AES-256-GCM (AES-NI+PClMulV256) | 8KB          |   1,320.61 ns |     8.468 ns |     7.921 ns |         - |
| Encrypt · AES-256-GCM (AES-NI+PClMul)     | 8KB          |   1,482.82 ns |     9.426 ns |     8.817 ns |         - |
| Encrypt · AES-256-GCM (BouncyCastle)      | 8KB          |  33,695.94 ns |   331.623 ns |   293.975 ns |    1816 B |
| Encrypt · AES-256-GCM (Managed)           | 8KB          |  48,381.37 ns |   300.843 ns |   281.409 ns |         - |
|                                           |              |               |              |              |           |
| Decrypt · AES-256-GCM (OS)                | 128KB        |  14,322.51 ns |    71.426 ns |    59.644 ns |         - |
| Decrypt · AES-256-GCM (AES-NI+PClMulV256) | 128KB        |  17,537.35 ns |   244.810 ns |   217.018 ns |         - |
| Decrypt · AES-256-GCM (AES-NI+PClMul)     | 128KB        |  23,553.77 ns |   150.640 ns |   133.539 ns |         - |
| Decrypt · AES-256-GCM (BouncyCastle)      | 128KB        | 533,688.55 ns | 4,023.400 ns | 3,566.639 ns |    1832 B |
| Decrypt · AES-256-GCM (Managed)           | 128KB        | 776,034.74 ns | 3,733.151 ns | 3,117.350 ns |         - |
|                                           |              |               |              |              |           |
| Encrypt · AES-256-GCM (OS)                | 128KB        |  10,669.18 ns |    71.486 ns |    66.868 ns |         - |
| Encrypt · AES-256-GCM (AES-NI+PClMulV256) | 128KB        |  20,321.79 ns |    94.830 ns |    84.064 ns |         - |
| Encrypt · AES-256-GCM (AES-NI+PClMul)     | 128KB        |  23,119.78 ns |    92.728 ns |    82.201 ns |         - |
| Encrypt · AES-256-GCM (BouncyCastle)      | 128KB        | 534,568.99 ns | 4,658.149 ns | 3,889.765 ns |    1816 B |
| Encrypt · AES-256-GCM (Managed)           | 128KB        | 773,207.41 ns | 4,212.402 ns | 3,517.547 ns |         - |