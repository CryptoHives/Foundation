| Description                               | TestDataSize | Mean          | Error         | StdDev        | Allocated |
|------------------------------------------ |------------- |--------------:|--------------:|--------------:|----------:|
| Decrypt · AES-128-GCM (AES-NI+PClMul)     | 17B          |     105.23 ns |      0.793 ns |      0.703 ns |         - |
| Decrypt · AES-128-GCM (AES-NI+PClMulV256) | 17B          |     105.63 ns |      0.718 ns |      0.672 ns |         - |
| Decrypt · AES-128-GCM (OS)                | 17B          |     125.21 ns |      2.293 ns |      2.145 ns |         - |
| Decrypt · AES-128-GCM (Managed)           | 17B          |     355.80 ns |      5.702 ns |      5.333 ns |         - |
| Decrypt · AES-128-GCM (BouncyCastle)      | 17B          |     605.19 ns |      9.938 ns |      9.296 ns |    1624 B |
|                                           |              |               |               |               |           |
| Encrypt · AES-128-GCM (AES-NI+PClMulV256) | 17B          |      63.07 ns |      0.349 ns |      0.310 ns |         - |
| Encrypt · AES-128-GCM (AES-NI+PClMul)     | 17B          |      63.17 ns |      1.251 ns |      1.109 ns |         - |
| Encrypt · AES-128-GCM (OS)                | 17B          |     120.57 ns |      1.033 ns |      0.966 ns |         - |
| Encrypt · AES-128-GCM (Managed)           | 17B          |     310.96 ns |      1.518 ns |      1.185 ns |         - |
| Encrypt · AES-128-GCM (BouncyCastle)      | 17B          |     515.25 ns |      5.586 ns |      5.225 ns |    1608 B |
|                                           |              |               |               |               |           |
| Decrypt · AES-128-GCM (AES-NI+PClMulV256) | 65B          |     104.51 ns |      0.891 ns |      0.833 ns |         - |
| Decrypt · AES-128-GCM (AES-NI+PClMul)     | 65B          |     106.29 ns |      1.007 ns |      0.892 ns |         - |
| Decrypt · AES-128-GCM (OS)                | 65B          |     124.16 ns |      2.402 ns |      2.570 ns |         - |
| Decrypt · AES-128-GCM (Managed)           | 65B          |     610.34 ns |     12.177 ns |     11.391 ns |         - |
| Decrypt · AES-128-GCM (BouncyCastle)      | 65B          |     803.56 ns |      9.092 ns |      8.504 ns |    1624 B |
|                                           |              |               |               |               |           |
| Encrypt · AES-128-GCM (AES-NI+PClMul)     | 65B          |      68.81 ns |      0.371 ns |      0.347 ns |         - |
| Encrypt · AES-128-GCM (AES-NI+PClMulV256) | 65B          |      69.44 ns |      0.519 ns |      0.486 ns |         - |
| Encrypt · AES-128-GCM (OS)                | 65B          |     124.03 ns |      0.706 ns |      0.626 ns |         - |
| Encrypt · AES-128-GCM (Managed)           | 65B          |     558.60 ns |      5.587 ns |      5.226 ns |         - |
| Encrypt · AES-128-GCM (BouncyCastle)      | 65B          |     661.64 ns |      5.680 ns |      5.313 ns |    1608 B |
|                                           |              |               |               |               |           |
| Decrypt · AES-128-GCM (AES-NI+PClMulV256) | 128B         |      99.07 ns |      0.915 ns |      0.811 ns |         - |
| Decrypt · AES-128-GCM (AES-NI+PClMul)     | 128B         |     101.63 ns |      1.080 ns |      1.010 ns |         - |
| Decrypt · AES-128-GCM (OS)                | 128B         |     121.65 ns |      0.712 ns |      0.631 ns |         - |
| Decrypt · AES-128-GCM (Managed)           | 128B         |     850.01 ns |      7.225 ns |      6.404 ns |         - |
| Decrypt · AES-128-GCM (BouncyCastle)      | 128B         |     910.73 ns |      9.428 ns |      8.819 ns |    1624 B |
|                                           |              |               |               |               |           |
| Encrypt · AES-128-GCM (AES-NI+PClMulV256) | 128B         |      57.46 ns |      0.353 ns |      0.313 ns |         - |
| Encrypt · AES-128-GCM (AES-NI+PClMul)     | 128B         |      59.19 ns |      0.578 ns |      0.512 ns |         - |
| Encrypt · AES-128-GCM (OS)                | 128B         |     157.90 ns |      3.074 ns |      2.875 ns |         - |
| Encrypt · AES-128-GCM (Managed)           | 128B         |     832.70 ns |      6.847 ns |      6.405 ns |         - |
| Encrypt · AES-128-GCM (BouncyCastle)      | 128B         |     840.73 ns |     16.315 ns |     22.871 ns |    1608 B |
|                                           |              |               |               |               |           |
| Decrypt · AES-128-GCM (AES-NI+PClMulV256) | 152B         |     124.72 ns |      2.489 ns |      2.328 ns |         - |
| Decrypt · AES-128-GCM (AES-NI+PClMul)     | 152B         |     127.20 ns |      2.571 ns |      2.751 ns |         - |
| Decrypt · AES-128-GCM (OS)                | 152B         |     136.27 ns |      2.010 ns |      1.880 ns |         - |
| Decrypt · AES-128-GCM (Managed)           | 152B         |   1,023.19 ns |     19.951 ns |     21.347 ns |         - |
| Decrypt · AES-128-GCM (BouncyCastle)      | 152B         |   1,090.01 ns |     20.278 ns |     19.916 ns |    1624 B |
|                                           |              |               |               |               |           |
| Encrypt · AES-128-GCM (AES-NI+PClMulV256) | 152B         |      85.64 ns |      1.145 ns |      1.071 ns |         - |
| Encrypt · AES-128-GCM (AES-NI+PClMul)     | 152B         |      88.34 ns |      1.641 ns |      1.535 ns |         - |
| Encrypt · AES-128-GCM (OS)                | 152B         |     138.44 ns |      2.579 ns |      2.413 ns |         - |
| Encrypt · AES-128-GCM (BouncyCastle)      | 152B         |     947.77 ns |      5.935 ns |      5.552 ns |    1608 B |
| Encrypt · AES-128-GCM (Managed)           | 152B         |     994.17 ns |     19.070 ns |     22.701 ns |         - |
|                                           |              |               |               |               |           |
| Decrypt · AES-128-GCM (AES-NI+PClMulV256) | 256B         |     114.94 ns |      0.690 ns |      0.646 ns |         - |
| Decrypt · AES-128-GCM (OS)                | 256B         |     126.24 ns |      0.770 ns |      0.720 ns |         - |
| Decrypt · AES-128-GCM (AES-NI+PClMul)     | 256B         |     128.94 ns |      2.563 ns |      3.676 ns |         - |
| Decrypt · AES-128-GCM (BouncyCastle)      | 256B         |   1,325.32 ns |     25.407 ns |     24.953 ns |    1624 B |
| Decrypt · AES-128-GCM (Managed)           | 256B         |   1,516.14 ns |     19.168 ns |     17.930 ns |         - |
|                                           |              |               |               |               |           |
| Encrypt · AES-128-GCM (AES-NI+PClMulV256) | 256B         |      75.89 ns |      1.012 ns |      0.947 ns |         - |
| Encrypt · AES-128-GCM (AES-NI+PClMul)     | 256B         |      80.49 ns |      1.330 ns |      1.244 ns |         - |
| Encrypt · AES-128-GCM (OS)                | 256B         |     125.67 ns |      2.511 ns |      2.686 ns |         - |
| Encrypt · AES-128-GCM (BouncyCastle)      | 256B         |   1,229.66 ns |     18.110 ns |     16.940 ns |    1608 B |
| Encrypt · AES-128-GCM (Managed)           | 256B         |   1,492.04 ns |     16.701 ns |     15.623 ns |         - |
|                                           |              |               |               |               |           |
| Decrypt · AES-128-GCM (OS)                | 1KB          |     178.69 ns |      0.774 ns |      0.724 ns |         - |
| Decrypt · AES-128-GCM (AES-NI+PClMulV256) | 1KB          |     201.57 ns |      1.393 ns |      1.235 ns |         - |
| Decrypt · AES-128-GCM (AES-NI+PClMul)     | 1KB          |     248.13 ns |      2.015 ns |      1.885 ns |         - |
| Decrypt · AES-128-GCM (BouncyCastle)      | 1KB          |   3,708.04 ns |     23.669 ns |     22.140 ns |    1624 B |
| Decrypt · AES-128-GCM (Managed)           | 1KB          |   5,385.57 ns |     28.983 ns |     25.693 ns |         - |
|                                           |              |               |               |               |           |
| Encrypt · AES-128-GCM (AES-NI+PClMulV256) | 1KB          |     176.32 ns |      2.497 ns |      2.335 ns |         - |
| Encrypt · AES-128-GCM (OS)                | 1KB          |     177.66 ns |      3.052 ns |      2.706 ns |         - |
| Encrypt · AES-128-GCM (AES-NI+PClMul)     | 1KB          |     201.62 ns |      2.138 ns |      1.895 ns |         - |
| Encrypt · AES-128-GCM (BouncyCastle)      | 1KB          |   3,685.51 ns |     26.151 ns |     24.462 ns |    1608 B |
| Encrypt · AES-128-GCM (Managed)           | 1KB          |   5,479.01 ns |     94.715 ns |     88.597 ns |         - |
|                                           |              |               |               |               |           |
| Decrypt · AES-128-GCM (OS)                | 8KB          |     687.14 ns |      4.783 ns |      4.474 ns |         - |
| Decrypt · AES-128-GCM (AES-NI+PClMulV256) | 8KB          |   1,024.42 ns |      9.035 ns |      8.452 ns |         - |
| Decrypt · AES-128-GCM (AES-NI+PClMul)     | 8KB          |   1,395.81 ns |     15.156 ns |     14.176 ns |         - |
| Decrypt · AES-128-GCM (BouncyCastle)      | 8KB          |  25,817.91 ns |    186.932 ns |    156.097 ns |    1624 B |
| Decrypt · AES-128-GCM (Managed)           | 8KB          |  41,729.40 ns |    182.063 ns |    161.394 ns |         - |
|                                           |              |               |               |               |           |
| Encrypt · AES-128-GCM (OS)                | 8KB          |     674.10 ns |     12.917 ns |     12.082 ns |         - |
| Encrypt · AES-128-GCM (AES-NI+PClMulV256) | 8KB          |   1,118.95 ns |     21.707 ns |     20.305 ns |         - |
| Encrypt · AES-128-GCM (AES-NI+PClMul)     | 8KB          |   1,341.78 ns |     24.089 ns |     22.533 ns |         - |
| Encrypt · AES-128-GCM (BouncyCastle)      | 8KB          |  26,207.61 ns |    225.538 ns |    210.968 ns |    1608 B |
| Encrypt · AES-128-GCM (Managed)           | 8KB          |  42,769.22 ns |    477.509 ns |    446.662 ns |         - |
|                                           |              |               |               |               |           |
| Decrypt · AES-128-GCM (OS)                | 128KB        |  10,881.04 ns |     39.135 ns |     32.679 ns |         - |
| Decrypt · AES-128-GCM (AES-NI+PClMulV256) | 128KB        |  15,968.52 ns |    200.948 ns |    187.967 ns |         - |
| Decrypt · AES-128-GCM (AES-NI+PClMul)     | 128KB        |  21,023.79 ns |    106.721 ns |     94.606 ns |         - |
| Decrypt · AES-128-GCM (BouncyCastle)      | 128KB        | 409,905.49 ns |  3,921.800 ns |  3,668.454 ns |    1624 B |
| Decrypt · AES-128-GCM (Managed)           | 128KB        | 668,119.73 ns |  5,905.788 ns |  5,524.278 ns |         - |
|                                           |              |               |               |               |           |
| Encrypt · AES-128-GCM (OS)                | 128KB        |   9,991.19 ns |    196.652 ns |    183.949 ns |         - |
| Encrypt · AES-128-GCM (AES-NI+PClMulV256) | 128KB        |  17,399.22 ns |    342.975 ns |    381.216 ns |         - |
| Encrypt · AES-128-GCM (AES-NI+PClMul)     | 128KB        |  21,034.60 ns |    269.991 ns |    239.340 ns |         - |
| Encrypt · AES-128-GCM (BouncyCastle)      | 128KB        | 416,158.72 ns |  5,065.124 ns |  4,737.920 ns |    1608 B |
| Encrypt · AES-128-GCM (Managed)           | 128KB        | 679,895.12 ns | 11,810.967 ns | 11,047.986 ns |         - |