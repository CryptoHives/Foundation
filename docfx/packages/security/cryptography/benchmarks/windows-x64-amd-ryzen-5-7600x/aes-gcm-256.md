| Description                                           | TestDataSize | Mean          | Error        | StdDev       | Allocated |
|------------------------------------------------------ |------------- |--------------:|-------------:|-------------:|----------:|
| Decrypt · AES-256-GCM (CryptoHives-AES-NI+PClMulV256) | 17B          |     121.71 ns |     0.373 ns |     0.331 ns |         - |
| Decrypt · AES-256-GCM (OS)                            | 17B          |     124.18 ns |     0.209 ns |     0.174 ns |         - |
| Decrypt · AES-256-GCM (CryptoHives-AES-NI+PClMul)     | 17B          |     127.88 ns |     0.206 ns |     0.183 ns |         - |
| Decrypt · AES-256-GCM (CryptoHives-Scalar)            | 17B          |     387.90 ns |     0.655 ns |     0.547 ns |         - |
| Decrypt · AES-256-GCM (BouncyCastle)                  | 17B          |     683.92 ns |     4.927 ns |     4.368 ns |    1832 B |
|                                                       |              |               |              |              |           |
| Encrypt · AES-256-GCM (CryptoHives-AES-NI+PClMul)     | 17B          |      72.01 ns |     0.112 ns |     0.104 ns |         - |
| Encrypt · AES-256-GCM (CryptoHives-AES-NI+PClMulV256) | 17B          |      72.78 ns |     0.116 ns |     0.108 ns |         - |
| Encrypt · AES-256-GCM (OS)                            | 17B          |     130.88 ns |     0.197 ns |     0.174 ns |         - |
| Encrypt · AES-256-GCM (CryptoHives-Scalar)            | 17B          |     374.69 ns |     0.619 ns |     0.517 ns |         - |
| Encrypt · AES-256-GCM (BouncyCastle)                  | 17B          |     618.72 ns |     1.840 ns |     1.536 ns |    1816 B |
|                                                       |              |               |              |              |           |
| Decrypt · AES-256-GCM (CryptoHives-AES-NI+PClMulV256) | 65B          |     112.57 ns |     0.270 ns |     0.240 ns |         - |
| Decrypt · AES-256-GCM (CryptoHives-AES-NI+PClMul)     | 65B          |     116.54 ns |     0.251 ns |     0.235 ns |         - |
| Decrypt · AES-256-GCM (OS)                            | 65B          |     129.70 ns |     2.567 ns |     4.694 ns |         - |
| Decrypt · AES-256-GCM (CryptoHives-Scalar)            | 65B          |     679.22 ns |     1.336 ns |     1.185 ns |         - |
| Decrypt · AES-256-GCM (BouncyCastle)                  | 65B          |     918.44 ns |     2.112 ns |     1.872 ns |    1832 B |
|                                                       |              |               |              |              |           |
| Encrypt · AES-256-GCM (CryptoHives-AES-NI+PClMulV256) | 65B          |      79.88 ns |     0.156 ns |     0.139 ns |         - |
| Encrypt · AES-256-GCM (CryptoHives-AES-NI+PClMul)     | 65B          |      80.32 ns |     0.168 ns |     0.157 ns |         - |
| Encrypt · AES-256-GCM (OS)                            | 65B          |     135.74 ns |     0.413 ns |     0.323 ns |         - |
| Encrypt · AES-256-GCM (CryptoHives-Scalar)            | 65B          |     644.25 ns |     0.925 ns |     0.820 ns |         - |
| Encrypt · AES-256-GCM (BouncyCastle)                  | 65B          |     823.85 ns |     1.796 ns |     1.500 ns |    1816 B |
|                                                       |              |               |              |              |           |
| Decrypt · AES-256-GCM (CryptoHives-AES-NI+PClMulV256) | 128B         |     103.51 ns |     0.403 ns |     0.357 ns |         - |
| Decrypt · AES-256-GCM (CryptoHives-AES-NI+PClMul)     | 128B         |     105.75 ns |     0.158 ns |     0.140 ns |         - |
| Decrypt · AES-256-GCM (OS)                            | 128B         |     125.56 ns |     0.344 ns |     0.305 ns |         - |
| Decrypt · AES-256-GCM (CryptoHives-Scalar)            | 128B         |     962.95 ns |     1.900 ns |     1.586 ns |         - |
| Decrypt · AES-256-GCM (BouncyCastle)                  | 128B         |   1,121.05 ns |     3.101 ns |     2.589 ns |    1832 B |
|                                                       |              |               |              |              |           |
| Encrypt · AES-256-GCM (CryptoHives-AES-NI+PClMulV256) | 128B         |      66.51 ns |     0.149 ns |     0.140 ns |         - |
| Encrypt · AES-256-GCM (CryptoHives-AES-NI+PClMul)     | 128B         |      69.66 ns |     0.136 ns |     0.120 ns |         - |
| Encrypt · AES-256-GCM (OS)                            | 128B         |     127.34 ns |     2.065 ns |     3.929 ns |         - |
| Encrypt · AES-256-GCM (CryptoHives-Scalar)            | 128B         |     936.00 ns |     2.018 ns |     1.685 ns |         - |
| Encrypt · AES-256-GCM (BouncyCastle)                  | 128B         |   1,013.77 ns |     5.423 ns |     4.529 ns |    1816 B |
|                                                       |              |               |              |              |           |
| Decrypt · AES-256-GCM (CryptoHives-AES-NI+PClMulV256) | 152B         |     139.12 ns |     0.171 ns |     0.151 ns |         - |
| Decrypt · AES-256-GCM (CryptoHives-AES-NI+PClMul)     | 152B         |     140.05 ns |     0.284 ns |     0.252 ns |         - |
| Decrypt · AES-256-GCM (OS)                            | 152B         |     151.40 ns |     0.307 ns |     0.287 ns |         - |
| Decrypt · AES-256-GCM (CryptoHives-Scalar)            | 152B         |   1,151.35 ns |     1.544 ns |     1.289 ns |         - |
| Decrypt · AES-256-GCM (BouncyCastle)                  | 152B         |   1,266.05 ns |     4.639 ns |     4.113 ns |    1832 B |
|                                                       |              |               |              |              |           |
| Encrypt · AES-256-GCM (CryptoHives-AES-NI+PClMulV256) | 152B         |      94.84 ns |     0.109 ns |     0.097 ns |         - |
| Encrypt · AES-256-GCM (CryptoHives-AES-NI+PClMul)     | 152B         |      97.39 ns |     0.102 ns |     0.085 ns |         - |
| Encrypt · AES-256-GCM (OS)                            | 152B         |     144.78 ns |     0.323 ns |     0.287 ns |         - |
| Encrypt · AES-256-GCM (CryptoHives-Scalar)            | 152B         |   1,143.24 ns |     1.732 ns |     1.621 ns |         - |
| Encrypt · AES-256-GCM (BouncyCastle)                  | 152B         |   1,173.78 ns |     4.456 ns |     3.950 ns |    1816 B |
|                                                       |              |               |              |              |           |
| Decrypt · AES-256-GCM (CryptoHives-AES-NI+PClMulV256) | 256B         |     117.95 ns |     0.307 ns |     0.272 ns |         - |
| Decrypt · AES-256-GCM (CryptoHives-AES-NI+PClMul)     | 256B         |     134.19 ns |     0.221 ns |     0.173 ns |         - |
| Decrypt · AES-256-GCM (OS)                            | 256B         |     144.05 ns |     0.296 ns |     0.247 ns |         - |
| Decrypt · AES-256-GCM (BouncyCastle)                  | 256B         |   1,664.01 ns |    10.085 ns |     8.421 ns |    1832 B |
| Decrypt · AES-256-GCM (CryptoHives-Scalar)            | 256B         |   1,728.74 ns |     6.542 ns |     6.119 ns |         - |
|                                                       |              |               |              |              |           |
| Encrypt · AES-256-GCM (CryptoHives-AES-NI+PClMulV256) | 256B         |      86.99 ns |     0.129 ns |     0.114 ns |         - |
| Encrypt · AES-256-GCM (CryptoHives-AES-NI+PClMul)     | 256B         |      91.56 ns |     0.189 ns |     0.177 ns |         - |
| Encrypt · AES-256-GCM (OS)                            | 256B         |     134.46 ns |     0.292 ns |     0.259 ns |         - |
| Encrypt · AES-256-GCM (BouncyCastle)                  | 256B         |   1,539.75 ns |     5.156 ns |     4.571 ns |    1816 B |
| Encrypt · AES-256-GCM (CryptoHives-Scalar)            | 256B         |   1,700.23 ns |     2.247 ns |     2.102 ns |         - |
|                                                       |              |               |              |              |           |
| Decrypt · AES-256-GCM (OS)                            | 1KB          |     213.54 ns |     0.320 ns |     0.284 ns |         - |
| Decrypt · AES-256-GCM (CryptoHives-AES-NI+PClMulV256) | 1KB          |     215.50 ns |     0.490 ns |     0.459 ns |         - |
| Decrypt · AES-256-GCM (CryptoHives-AES-NI+PClMul)     | 1KB          |     268.78 ns |     0.531 ns |     0.443 ns |         - |
| Decrypt · AES-256-GCM (BouncyCastle)                  | 1KB          |   4,852.61 ns |     9.886 ns |     8.764 ns |    1832 B |
| Decrypt · AES-256-GCM (CryptoHives-Scalar)            | 1KB          |   6,317.55 ns |     9.781 ns |     8.168 ns |         - |
|                                                       |              |               |              |              |           |
| Encrypt · AES-256-GCM (OS)                            | 1KB          |     185.92 ns |     0.508 ns |     0.475 ns |         - |
| Encrypt · AES-256-GCM (CryptoHives-AES-NI+PClMulV256) | 1KB          |     205.50 ns |     0.391 ns |     0.346 ns |         - |
| Encrypt · AES-256-GCM (CryptoHives-AES-NI+PClMul)     | 1KB          |     225.66 ns |     0.409 ns |     0.363 ns |         - |
| Encrypt · AES-256-GCM (BouncyCastle)                  | 1KB          |   4,729.14 ns |     9.580 ns |     8.493 ns |    1816 B |
| Encrypt · AES-256-GCM (CryptoHives-Scalar)            | 1KB          |   6,308.98 ns |     8.586 ns |     7.169 ns |         - |
|                                                       |              |               |              |              |           |
| Decrypt · AES-256-GCM (OS)                            | 8KB          |     939.09 ns |     1.851 ns |     1.641 ns |         - |
| Decrypt · AES-256-GCM (CryptoHives-AES-NI+PClMulV256) | 8KB          |   1,145.26 ns |     2.611 ns |     2.314 ns |         - |
| Decrypt · AES-256-GCM (CryptoHives-AES-NI+PClMul)     | 8KB          |   1,566.65 ns |     3.584 ns |     3.177 ns |         - |
| Decrypt · AES-256-GCM (BouncyCastle)                  | 8KB          |  34,399.46 ns |   115.553 ns |   102.435 ns |    1832 B |
| Decrypt · AES-256-GCM (CryptoHives-Scalar)            | 8KB          |  49,219.28 ns |    53.871 ns |    47.755 ns |         - |
|                                                       |              |               |              |              |           |
| Encrypt · AES-256-GCM (OS)                            | 8KB          |     726.86 ns |     1.243 ns |     1.038 ns |         - |
| Encrypt · AES-256-GCM (CryptoHives-AES-NI+PClMulV256) | 8KB          |   1,328.76 ns |     3.504 ns |     2.736 ns |         - |
| Encrypt · AES-256-GCM (CryptoHives-AES-NI+PClMul)     | 8KB          |   1,501.64 ns |    17.159 ns |    16.051 ns |         - |
| Encrypt · AES-256-GCM (BouncyCastle)                  | 8KB          |  34,112.69 ns |    64.403 ns |    57.091 ns |    1816 B |
| Encrypt · AES-256-GCM (CryptoHives-Scalar)            | 8KB          |  49,187.45 ns |    58.387 ns |    48.756 ns |         - |
|                                                       |              |               |              |              |           |
| Decrypt · AES-256-GCM (OS)                            | 128KB        |  14,661.12 ns |    28.951 ns |    24.175 ns |         - |
| Decrypt · AES-256-GCM (CryptoHives-AES-NI+PClMulV256) | 128KB        |  18,570.83 ns |   169.777 ns |   158.810 ns |         - |
| Decrypt · AES-256-GCM (CryptoHives-AES-NI+PClMul)     | 128KB        |  23,677.30 ns |    78.994 ns |    70.026 ns |         - |
| Decrypt · AES-256-GCM (BouncyCastle)                  | 128KB        | 542,589.24 ns | 1,549.193 ns | 1,373.319 ns |    1832 B |
| Decrypt · AES-256-GCM (CryptoHives-Scalar)            | 128KB        | 786,476.43 ns | 1,105.307 ns |   979.826 ns |         - |
|                                                       |              |               |              |              |           |
| Encrypt · AES-256-GCM (OS)                            | 128KB        |  10,917.80 ns |    52.355 ns |    43.719 ns |         - |
| Encrypt · AES-256-GCM (CryptoHives-AES-NI+PClMulV256) | 128KB        |  20,611.81 ns |    78.652 ns |    69.723 ns |         - |
| Encrypt · AES-256-GCM (CryptoHives-AES-NI+PClMul)     | 128KB        |  23,284.73 ns |    60.690 ns |    53.800 ns |         - |
| Encrypt · AES-256-GCM (BouncyCastle)                  | 128KB        | 542,380.43 ns | 1,343.140 ns | 1,256.374 ns |    1816 B |
| Encrypt · AES-256-GCM (CryptoHives-Scalar)            | 128KB        | 788,912.01 ns |   943.250 ns |   836.167 ns |         - |