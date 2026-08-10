| Description                                           | TestDataSize | Mean          | Error        | StdDev       | Allocated |
|------------------------------------------------------ |------------- |--------------:|-------------:|-------------:|----------:|
| Decrypt · AES-128-GCM (CryptoHives-AES-NI+PClMul)     | 17B          |     114.54 ns |     0.352 ns |     0.329 ns |         - |
| Decrypt · AES-128-GCM (OS)                            | 17B          |     117.51 ns |     0.638 ns |     0.597 ns |         - |
| Decrypt · AES-128-GCM (CryptoHives-AES-NI+PClMulV256) | 17B          |     119.78 ns |     0.540 ns |     0.479 ns |         - |
| Decrypt · AES-128-GCM (CryptoHives-Scalar)            | 17B          |     345.27 ns |     2.527 ns |     2.364 ns |         - |
| Decrypt · AES-128-GCM (BouncyCastle)                  | 17B          |     590.37 ns |     5.526 ns |     5.169 ns |    1624 B |
|                                                       |              |               |              |              |           |
| Encrypt · AES-128-GCM (CryptoHives-AES-NI+PClMulV256) | 17B          |      65.69 ns |     0.254 ns |     0.212 ns |         - |
| Encrypt · AES-128-GCM (CryptoHives-AES-NI+PClMul)     | 17B          |      65.87 ns |     0.310 ns |     0.290 ns |         - |
| Encrypt · AES-128-GCM (OS)                            | 17B          |     123.21 ns |     1.150 ns |     1.019 ns |         - |
| Encrypt · AES-128-GCM (CryptoHives-Scalar)            | 17B          |     319.76 ns |     4.076 ns |     3.613 ns |         - |
| Encrypt · AES-128-GCM (BouncyCastle)                  | 17B          |     519.67 ns |     9.343 ns |     9.176 ns |    1608 B |
|                                                       |              |               |              |              |           |
| Decrypt · AES-128-GCM (CryptoHives-AES-NI+PClMul)     | 65B          |      99.79 ns |     0.460 ns |     0.359 ns |         - |
| Decrypt · AES-128-GCM (CryptoHives-AES-NI+PClMulV256) | 65B          |     107.08 ns |     0.628 ns |     0.557 ns |         - |
| Decrypt · AES-128-GCM (OS)                            | 65B          |     120.65 ns |     0.511 ns |     0.427 ns |         - |
| Decrypt · AES-128-GCM (CryptoHives-Scalar)            | 65B          |     650.79 ns |     5.269 ns |     4.929 ns |         - |
| Decrypt · AES-128-GCM (BouncyCastle)                  | 65B          |     770.16 ns |     5.319 ns |     4.715 ns |    1624 B |
|                                                       |              |               |              |              |           |
| Encrypt · AES-128-GCM (CryptoHives-AES-NI+PClMul)     | 65B          |      71.49 ns |     0.392 ns |     0.367 ns |         - |
| Encrypt · AES-128-GCM (CryptoHives-AES-NI+PClMulV256) | 65B          |      72.13 ns |     0.195 ns |     0.173 ns |         - |
| Encrypt · AES-128-GCM (OS)                            | 65B          |     126.14 ns |     0.918 ns |     0.814 ns |         - |
| Encrypt · AES-128-GCM (CryptoHives-Scalar)            | 65B          |     564.91 ns |     4.430 ns |     3.927 ns |         - |
| Encrypt · AES-128-GCM (BouncyCastle)                  | 65B          |     666.95 ns |     5.567 ns |     5.208 ns |    1608 B |
|                                                       |              |               |              |              |           |
| Decrypt · AES-128-GCM (CryptoHives-AES-NI+PClMul)     | 128B         |      94.97 ns |     0.555 ns |     0.519 ns |         - |
| Decrypt · AES-128-GCM (CryptoHives-AES-NI+PClMulV256) | 128B         |      98.07 ns |     0.731 ns |     0.611 ns |         - |
| Decrypt · AES-128-GCM (OS)                            | 128B         |     121.26 ns |     0.645 ns |     0.572 ns |         - |
| Decrypt · AES-128-GCM (CryptoHives-Scalar)            | 128B         |     839.84 ns |     5.057 ns |     4.483 ns |         - |
| Decrypt · AES-128-GCM (BouncyCastle)                  | 128B         |     962.51 ns |     7.528 ns |     6.673 ns |    1624 B |
|                                                       |              |               |              |              |           |
| Encrypt · AES-128-GCM (CryptoHives-AES-NI+PClMulV256) | 128B         |      61.21 ns |     0.544 ns |     0.509 ns |         - |
| Encrypt · AES-128-GCM (CryptoHives-AES-NI+PClMul)     | 128B         |      63.25 ns |     0.766 ns |     0.716 ns |         - |
| Encrypt · AES-128-GCM (OS)                            | 128B         |     122.60 ns |     0.562 ns |     0.498 ns |         - |
| Encrypt · AES-128-GCM (CryptoHives-Scalar)            | 128B         |     812.11 ns |     6.254 ns |     5.850 ns |         - |
| Encrypt · AES-128-GCM (BouncyCastle)                  | 128B         |     815.00 ns |     4.504 ns |     3.517 ns |    1608 B |
|                                                       |              |               |              |              |           |
| Decrypt · AES-128-GCM (CryptoHives-AES-NI+PClMul)     | 152B         |     120.64 ns |     1.592 ns |     1.412 ns |         - |
| Decrypt · AES-128-GCM (CryptoHives-AES-NI+PClMulV256) | 152B         |     124.99 ns |     1.033 ns |     0.966 ns |         - |
| Decrypt · AES-128-GCM (OS)                            | 152B         |     136.39 ns |     0.939 ns |     0.878 ns |         - |
| Decrypt · AES-128-GCM (CryptoHives-Scalar)            | 152B         |   1,008.29 ns |     6.537 ns |     5.795 ns |         - |
| Decrypt · AES-128-GCM (BouncyCastle)                  | 152B         |   1,028.87 ns |    14.534 ns |    12.884 ns |    1624 B |
|                                                       |              |               |              |              |           |
| Encrypt · AES-128-GCM (CryptoHives-AES-NI+PClMulV256) | 152B         |      86.77 ns |     0.355 ns |     0.332 ns |         - |
| Encrypt · AES-128-GCM (CryptoHives-AES-NI+PClMul)     | 152B         |      87.99 ns |     0.447 ns |     0.418 ns |         - |
| Encrypt · AES-128-GCM (OS)                            | 152B         |     136.73 ns |     1.028 ns |     0.962 ns |         - |
| Encrypt · AES-128-GCM (BouncyCastle)                  | 152B         |     942.36 ns |    18.430 ns |    18.927 ns |    1608 B |
| Encrypt · AES-128-GCM (CryptoHives-Scalar)            | 152B         |   1,001.51 ns |     8.972 ns |     8.393 ns |         - |
|                                                       |              |               |              |              |           |
| Decrypt · AES-128-GCM (CryptoHives-AES-NI+PClMulV256) | 256B         |     112.55 ns |     0.665 ns |     0.622 ns |         - |
| Decrypt · AES-128-GCM (CryptoHives-AES-NI+PClMul)     | 256B         |     125.24 ns |     1.259 ns |     1.178 ns |         - |
| Decrypt · AES-128-GCM (OS)                            | 256B         |     127.88 ns |     1.017 ns |     0.902 ns |         - |
| Decrypt · AES-128-GCM (BouncyCastle)                  | 256B         |   1,325.67 ns |    10.500 ns |     9.308 ns |    1624 B |
| Decrypt · AES-128-GCM (CryptoHives-Scalar)            | 256B         |   1,512.37 ns |    18.164 ns |    16.990 ns |         - |
|                                                       |              |               |              |              |           |
| Encrypt · AES-128-GCM (CryptoHives-AES-NI+PClMulV256) | 256B         |      77.27 ns |     0.481 ns |     0.426 ns |         - |
| Encrypt · AES-128-GCM (CryptoHives-AES-NI+PClMul)     | 256B         |      82.51 ns |     1.041 ns |     0.869 ns |         - |
| Encrypt · AES-128-GCM (OS)                            | 256B         |     127.59 ns |     0.724 ns |     0.565 ns |         - |
| Encrypt · AES-128-GCM (BouncyCastle)                  | 256B         |   1,227.27 ns |    11.074 ns |    10.358 ns |    1608 B |
| Encrypt · AES-128-GCM (CryptoHives-Scalar)            | 256B         |   1,470.18 ns |    10.730 ns |     9.512 ns |         - |
|                                                       |              |               |              |              |           |
| Decrypt · AES-128-GCM (OS)                            | 1KB          |     180.70 ns |     1.811 ns |     1.694 ns |         - |
| Decrypt · AES-128-GCM (CryptoHives-AES-NI+PClMulV256) | 1KB          |     203.32 ns |     2.140 ns |     2.002 ns |         - |
| Decrypt · AES-128-GCM (CryptoHives-AES-NI+PClMul)     | 1KB          |     245.20 ns |     2.467 ns |     2.187 ns |         - |
| Decrypt · AES-128-GCM (BouncyCastle)                  | 1KB          |   3,753.11 ns |    29.720 ns |    27.800 ns |    1624 B |
| Decrypt · AES-128-GCM (CryptoHives-Scalar)            | 1KB          |   5,451.85 ns |    33.631 ns |    31.459 ns |         - |
|                                                       |              |               |              |              |           |
| Encrypt · AES-128-GCM (OS)                            | 1KB          |     173.58 ns |     1.254 ns |     1.112 ns |         - |
| Encrypt · AES-128-GCM (CryptoHives-AES-NI+PClMulV256) | 1KB          |     176.34 ns |     1.728 ns |     1.617 ns |         - |
| Encrypt · AES-128-GCM (CryptoHives-AES-NI+PClMul)     | 1KB          |     201.11 ns |     1.363 ns |     1.275 ns |         - |
| Encrypt · AES-128-GCM (BouncyCastle)                  | 1KB          |   3,627.51 ns |    19.187 ns |    16.022 ns |    1608 B |
| Encrypt · AES-128-GCM (CryptoHives-Scalar)            | 1KB          |   5,414.04 ns |    41.725 ns |    39.029 ns |         - |
|                                                       |              |               |              |              |           |
| Decrypt · AES-128-GCM (OS)                            | 8KB          |     716.47 ns |     4.543 ns |     3.794 ns |         - |
| Decrypt · AES-128-GCM (CryptoHives-AES-NI+PClMulV256) | 8KB          |   1,033.54 ns |    12.406 ns |    11.605 ns |         - |
| Decrypt · AES-128-GCM (CryptoHives-AES-NI+PClMul)     | 8KB          |   1,383.80 ns |     9.889 ns |     8.767 ns |         - |
| Decrypt · AES-128-GCM (BouncyCastle)                  | 8KB          |  26,117.31 ns |   186.457 ns |   174.412 ns |    1624 B |
| Decrypt · AES-128-GCM (CryptoHives-Scalar)            | 8KB          |  42,542.39 ns |   450.564 ns |   376.241 ns |         - |
|                                                       |              |               |              |              |           |
| Encrypt · AES-128-GCM (OS)                            | 8KB          |     672.90 ns |     4.601 ns |     3.842 ns |         - |
| Encrypt · AES-128-GCM (CryptoHives-AES-NI+PClMulV256) | 8KB          |   1,105.61 ns |     8.702 ns |     8.140 ns |         - |
| Encrypt · AES-128-GCM (CryptoHives-AES-NI+PClMul)     | 8KB          |   1,315.50 ns |    10.101 ns |     8.434 ns |         - |
| Encrypt · AES-128-GCM (BouncyCastle)                  | 8KB          |  26,088.83 ns |   167.838 ns |   140.153 ns |    1608 B |
| Encrypt · AES-128-GCM (CryptoHives-Scalar)            | 8KB          |  42,460.89 ns |   206.777 ns |   193.419 ns |         - |
|                                                       |              |               |              |              |           |
| Decrypt · AES-128-GCM (CryptoHives-AES-NI+PClMulV256) | 128KB        |  15,943.39 ns |   122.238 ns |   102.075 ns |         - |
| Decrypt · AES-128-GCM (OS)                            | 128KB        |  18,641.58 ns |    81.996 ns |    76.699 ns |         - |
| Decrypt · AES-128-GCM (CryptoHives-AES-NI+PClMul)     | 128KB        |  21,040.02 ns |   115.420 ns |    96.381 ns |         - |
| Decrypt · AES-128-GCM (BouncyCastle)                  | 128KB        | 410,422.25 ns | 4,776.905 ns | 4,468.320 ns |    1624 B |
| Decrypt · AES-128-GCM (CryptoHives-Scalar)            | 128KB        | 674,505.99 ns | 3,493.110 ns | 3,096.551 ns |         - |
|                                                       |              |               |              |              |           |
| Encrypt · AES-128-GCM (OS)                            | 128KB        |   9,882.90 ns |    53.441 ns |    49.988 ns |         - |
| Encrypt · AES-128-GCM (CryptoHives-AES-NI+PClMulV256) | 128KB        |  17,162.10 ns |   112.538 ns |    93.974 ns |         - |
| Encrypt · AES-128-GCM (CryptoHives-AES-NI+PClMul)     | 128KB        |  20,604.96 ns |   233.860 ns |   207.311 ns |         - |
| Encrypt · AES-128-GCM (BouncyCastle)                  | 128KB        | 410,867.34 ns | 3,109.869 ns | 2,908.974 ns |    1608 B |
| Encrypt · AES-128-GCM (CryptoHives-Scalar)            | 128KB        | 672,746.30 ns | 2,822.553 ns | 2,502.120 ns |         - |