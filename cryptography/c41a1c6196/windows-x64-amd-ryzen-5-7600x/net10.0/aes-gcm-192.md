| Description                                           | TestDataSize | Mean          | Error        | StdDev       | Code Size | Allocated |
|------------------------------------------------------ |------------- |--------------:|-------------:|-------------:|----------:|----------:|
| Decrypt · AES-192-GCM (CryptoHives-AES-NI+PClMul)     | 17B          |     115.59 ns |     0.250 ns |     0.222 ns |     306 B |         - |
| Decrypt · AES-192-GCM (CryptoHives-AES-NI+PClMulV256) | 17B          |     115.76 ns |     0.244 ns |     0.229 ns |     306 B |         - |
| Decrypt · AES-192-GCM (OS)                            | 17B          |     139.97 ns |     0.408 ns |     0.341 ns |   2,230 B |         - |
| Decrypt · AES-192-GCM (CryptoHives-Scalar)            | 17B          |     403.22 ns |     1.404 ns |     1.314 ns |     306 B |         - |
| Decrypt · AES-192-GCM (BouncyCastle)                  | 17B          |     602.82 ns |     3.155 ns |     2.951 ns |     306 B |    1728 B |
|                                                       |              |               |              |              |           |           |
| Encrypt · AES-192-GCM (CryptoHives-AES-NI+PClMulV256) | 17B          |      75.14 ns |     0.141 ns |     0.125 ns |     383 B |         - |
| Encrypt · AES-192-GCM (CryptoHives-AES-NI+PClMul)     | 17B          |      77.02 ns |     0.137 ns |     0.122 ns |     383 B |         - |
| Encrypt · AES-192-GCM (OS)                            | 17B          |     146.94 ns |     0.502 ns |     0.420 ns |   2,202 B |         - |
| Encrypt · AES-192-GCM (CryptoHives-Scalar)            | 17B          |     354.74 ns |     0.850 ns |     0.710 ns |     386 B |         - |
| Encrypt · AES-192-GCM (BouncyCastle)                  | 17B          |     542.82 ns |     2.923 ns |     2.735 ns |     386 B |    1712 B |
|                                                       |              |               |              |              |           |           |
| Decrypt · AES-192-GCM (CryptoHives-AES-NI+PClMulV256) | 65B          |     112.72 ns |     0.411 ns |     0.364 ns |     306 B |         - |
| Decrypt · AES-192-GCM (CryptoHives-AES-NI+PClMul)     | 65B          |     120.09 ns |     0.984 ns |     0.768 ns |     306 B |         - |
| Decrypt · AES-192-GCM (OS)                            | 65B          |     142.74 ns |     0.468 ns |     0.438 ns |   2,230 B |         - |
| Decrypt · AES-192-GCM (CryptoHives-Scalar)            | 65B          |     691.26 ns |     2.078 ns |     1.842 ns |     306 B |         - |
| Decrypt · AES-192-GCM (BouncyCastle)                  | 65B          |     839.01 ns |     5.607 ns |     4.682 ns |     306 B |    1728 B |
|                                                       |              |               |              |              |           |           |
| Encrypt · AES-192-GCM (CryptoHives-AES-NI+PClMulV256) | 65B          |      83.37 ns |     0.213 ns |     0.189 ns |     383 B |         - |
| Encrypt · AES-192-GCM (CryptoHives-AES-NI+PClMul)     | 65B          |      89.60 ns |     0.198 ns |     0.186 ns |     383 B |         - |
| Encrypt · AES-192-GCM (OS)                            | 65B          |     151.90 ns |     0.350 ns |     0.327 ns |   2,202 B |         - |
| Encrypt · AES-192-GCM (CryptoHives-Scalar)            | 65B          |     641.03 ns |     1.210 ns |     1.011 ns |     386 B |         - |
| Encrypt · AES-192-GCM (BouncyCastle)                  | 65B          |     739.77 ns |    14.087 ns |    16.223 ns |     383 B |    1712 B |
|                                                       |              |               |              |              |           |           |
| Decrypt · AES-192-GCM (CryptoHives-AES-NI+PClMulV256) | 128B         |     117.21 ns |     0.528 ns |     0.468 ns |     306 B |         - |
| Decrypt · AES-192-GCM (CryptoHives-AES-NI+PClMul)     | 128B         |     125.41 ns |     0.384 ns |     0.340 ns |     306 B |         - |
| Decrypt · AES-192-GCM (OS)                            | 128B         |     140.85 ns |     0.327 ns |     0.290 ns |   2,230 B |         - |
| Decrypt · AES-192-GCM (CryptoHives-Scalar)            | 128B         |     977.76 ns |     3.522 ns |     3.294 ns |     306 B |         - |
| Decrypt · AES-192-GCM (BouncyCastle)                  | 128B         |   1,039.72 ns |     4.521 ns |     4.229 ns |     306 B |    1728 B |
|                                                       |              |               |              |              |           |           |
| Encrypt · AES-192-GCM (CryptoHives-AES-NI+PClMulV256) | 128B         |      69.12 ns |     0.132 ns |     0.110 ns |     383 B |         - |
| Encrypt · AES-192-GCM (CryptoHives-AES-NI+PClMul)     | 128B         |      71.71 ns |     0.223 ns |     0.186 ns |     383 B |         - |
| Encrypt · AES-192-GCM (OS)                            | 128B         |     147.58 ns |     0.334 ns |     0.296 ns |   2,202 B |         - |
| Encrypt · AES-192-GCM (BouncyCastle)                  | 128B         |     921.19 ns |     2.464 ns |     1.924 ns |     386 B |    1712 B |
| Encrypt · AES-192-GCM (CryptoHives-Scalar)            | 128B         |     932.00 ns |     2.399 ns |     2.003 ns |     383 B |         - |
|                                                       |              |               |              |              |           |           |
| Decrypt · AES-192-GCM (CryptoHives-AES-NI+PClMulV256) | 152B         |     133.23 ns |     0.658 ns |     0.583 ns |     306 B |         - |
| Decrypt · AES-192-GCM (CryptoHives-AES-NI+PClMul)     | 152B         |     137.71 ns |     0.535 ns |     0.474 ns |     306 B |         - |
| Decrypt · AES-192-GCM (OS)                            | 152B         |     168.25 ns |     0.385 ns |     0.341 ns |   2,230 B |         - |
| Decrypt · AES-192-GCM (CryptoHives-Scalar)            | 152B         |   1,163.12 ns |     4.541 ns |     4.248 ns |     306 B |         - |
| Decrypt · AES-192-GCM (BouncyCastle)                  | 152B         |   1,199.05 ns |     6.253 ns |     5.543 ns |     306 B |    1728 B |
|                                                       |              |               |              |              |           |           |
| Encrypt · AES-192-GCM (CryptoHives-AES-NI+PClMulV256) | 152B         |      99.22 ns |     0.271 ns |     0.253 ns |     386 B |         - |
| Encrypt · AES-192-GCM (CryptoHives-AES-NI+PClMul)     | 152B         |     101.10 ns |     0.281 ns |     0.234 ns |     386 B |         - |
| Encrypt · AES-192-GCM (OS)                            | 152B         |     168.49 ns |     0.646 ns |     0.573 ns |   2,202 B |         - |
| Encrypt · AES-192-GCM (BouncyCastle)                  | 152B         |   1,083.21 ns |     4.320 ns |     3.608 ns |     386 B |    1712 B |
| Encrypt · AES-192-GCM (CryptoHives-Scalar)            | 152B         |   1,117.78 ns |     7.484 ns |     7.001 ns |     383 B |         - |
|                                                       |              |               |              |              |           |           |
| Decrypt · AES-192-GCM (CryptoHives-AES-NI+PClMulV256) | 256B         |     141.83 ns |     0.665 ns |     0.555 ns |     306 B |         - |
| Decrypt · AES-192-GCM (CryptoHives-AES-NI+PClMul)     | 256B         |     150.78 ns |     0.648 ns |     0.575 ns |     306 B |         - |
| Decrypt · AES-192-GCM (OS)                            | 256B         |     159.67 ns |     0.412 ns |     0.365 ns |   2,230 B |         - |
| Decrypt · AES-192-GCM (BouncyCastle)                  | 256B         |   1,568.00 ns |     4.218 ns |     3.946 ns |     306 B |    1728 B |
| Decrypt · AES-192-GCM (CryptoHives-Scalar)            | 256B         |   1,736.88 ns |     5.950 ns |     5.274 ns |     306 B |         - |
|                                                       |              |               |              |              |           |           |
| Encrypt · AES-192-GCM (CryptoHives-AES-NI+PClMulV256) | 256B         |      90.22 ns |     0.320 ns |     0.300 ns |     383 B |         - |
| Encrypt · AES-192-GCM (CryptoHives-AES-NI+PClMul)     | 256B         |      96.20 ns |     0.303 ns |     0.283 ns |     383 B |         - |
| Encrypt · AES-192-GCM (OS)                            | 256B         |     147.84 ns |     0.371 ns |     0.347 ns |   2,202 B |         - |
| Encrypt · AES-192-GCM (BouncyCastle)                  | 256B         |   1,455.45 ns |     3.670 ns |     3.253 ns |     386 B |    1712 B |
| Encrypt · AES-192-GCM (CryptoHives-Scalar)            | 256B         |   1,700.29 ns |     4.632 ns |     4.333 ns |     383 B |         - |
|                                                       |              |               |              |              |           |           |
| Decrypt · AES-192-GCM (OS)                            | 1KB          |     226.16 ns |     0.794 ns |     0.704 ns |   2,230 B |         - |
| Decrypt · AES-192-GCM (CryptoHives-AES-NI+PClMulV256) | 1KB          |     249.49 ns |     0.884 ns |     0.784 ns |     306 B |         - |
| Decrypt · AES-192-GCM (CryptoHives-AES-NI+PClMul)     | 1KB          |     301.66 ns |     0.978 ns |     0.867 ns |     306 B |         - |
| Decrypt · AES-192-GCM (BouncyCastle)                  | 1KB          |   4,739.85 ns |     9.332 ns |     7.793 ns |     306 B |    1728 B |
| Decrypt · AES-192-GCM (CryptoHives-Scalar)            | 1KB          |   6,328.38 ns |    19.066 ns |    16.902 ns |     306 B |         - |
|                                                       |              |               |              |              |           |           |
| Encrypt · AES-192-GCM (CryptoHives-AES-NI+PClMulV256) | 1KB          |     219.30 ns |     0.525 ns |     0.491 ns |     383 B |         - |
| Encrypt · AES-192-GCM (OS)                            | 1KB          |     221.84 ns |     0.501 ns |     0.418 ns |   2,205 B |         - |
| Encrypt · AES-192-GCM (CryptoHives-AES-NI+PClMul)     | 1KB          |     246.05 ns |     0.946 ns |     0.885 ns |     383 B |         - |
| Encrypt · AES-192-GCM (BouncyCastle)                  | 1KB          |   4,633.53 ns |    23.952 ns |    21.233 ns |     383 B |    1712 B |
| Encrypt · AES-192-GCM (CryptoHives-Scalar)            | 1KB          |   6,273.25 ns |    36.750 ns |    30.688 ns |     383 B |         - |
|                                                       |              |               |              |              |           |           |
| Decrypt · AES-192-GCM (OS)                            | 8KB          |     910.36 ns |     2.414 ns |     2.140 ns |   2,230 B |         - |
| Decrypt · AES-192-GCM (CryptoHives-AES-NI+PClMulV256) | 8KB          |   1,251.51 ns |     7.087 ns |     6.629 ns |     306 B |         - |
| Decrypt · AES-192-GCM (CryptoHives-AES-NI+PClMul)     | 8KB          |   1,724.27 ns |     4.870 ns |     4.317 ns |     306 B |         - |
| Decrypt · AES-192-GCM (BouncyCastle)                  | 8KB          |  34,448.37 ns |   161.451 ns |   143.122 ns |     306 B |    1728 B |
| Decrypt · AES-192-GCM (CryptoHives-Scalar)            | 8KB          |  48,922.28 ns |   184.574 ns |   154.128 ns |     306 B |         - |
|                                                       |              |               |              |              |           |           |
| Encrypt · AES-192-GCM (OS)                            | 8KB          |     811.75 ns |     1.179 ns |     0.920 ns |   2,205 B |         - |
| Encrypt · AES-192-GCM (CryptoHives-AES-NI+PClMulV256) | 8KB          |   1,399.63 ns |     4.132 ns |     3.663 ns |     383 B |         - |
| Encrypt · AES-192-GCM (CryptoHives-AES-NI+PClMul)     | 8KB          |   1,604.99 ns |     7.401 ns |     5.778 ns |     383 B |         - |
| Encrypt · AES-192-GCM (BouncyCastle)                  | 8KB          |  34,215.21 ns |   129.500 ns |   108.139 ns |     383 B |    1712 B |
| Encrypt · AES-192-GCM (CryptoHives-Scalar)            | 8KB          |  48,821.95 ns |   171.611 ns |   152.128 ns |     383 B |         - |
|                                                       |              |               |              |              |           |           |
| Decrypt · AES-192-GCM (OS)                            | 128KB        |  13,752.43 ns |   106.128 ns |    88.622 ns |   2,230 B |         - |
| Decrypt · AES-192-GCM (CryptoHives-AES-NI+PClMulV256) | 128KB        |  19,216.35 ns |    61.115 ns |    51.034 ns |     306 B |         - |
| Decrypt · AES-192-GCM (CryptoHives-AES-NI+PClMul)     | 128KB        |  26,002.71 ns |    75.809 ns |    70.912 ns |     306 B |         - |
| Decrypt · AES-192-GCM (BouncyCastle)                  | 128KB        | 544,259.72 ns | 1,513.395 ns | 1,341.585 ns |     306 B |    1728 B |
| Decrypt · AES-192-GCM (CryptoHives-Scalar)            | 128KB        | 780,546.56 ns | 3,231.360 ns | 3,022.616 ns |     306 B |         - |
|                                                       |              |               |              |              |           |           |
| Encrypt · AES-192-GCM (OS)                            | 128KB        |  11,858.55 ns |    34.102 ns |    28.477 ns |   2,202 B |         - |
| Encrypt · AES-192-GCM (CryptoHives-AES-NI+PClMulV256) | 128KB        |  21,667.77 ns |    81.501 ns |    76.236 ns |     383 B |         - |
| Encrypt · AES-192-GCM (CryptoHives-AES-NI+PClMul)     | 128KB        |  24,991.60 ns |    58.209 ns |    51.601 ns |     383 B |         - |
| Encrypt · AES-192-GCM (BouncyCastle)                  | 128KB        | 541,813.12 ns | 2,104.638 ns | 1,865.707 ns |     383 B |    1712 B |
| Encrypt · AES-192-GCM (CryptoHives-Scalar)            | 128KB        | 779,786.74 ns | 2,336.823 ns | 1,951.353 ns |     383 B |         - |