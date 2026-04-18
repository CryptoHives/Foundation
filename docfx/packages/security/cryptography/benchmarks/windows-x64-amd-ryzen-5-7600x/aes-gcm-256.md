| Description                                           | TestDataSize | Mean          | Error        | StdDev       | Allocated |
|------------------------------------------------------ |------------- |--------------:|-------------:|-------------:|----------:|
| Decrypt · AES-256-GCM (CryptoHives-AES-NI+PClMulV256) | 17B          |     122.05 ns |     0.211 ns |     0.187 ns |         - |
| Decrypt · AES-256-GCM (OS)                            | 17B          |     122.48 ns |     0.308 ns |     0.273 ns |         - |
| Decrypt · AES-256-GCM (CryptoHives-AES-NI+PClMul)     | 17B          |     160.23 ns |     0.148 ns |     0.131 ns |         - |
| Decrypt · AES-256-GCM (CryptoHives-Scalar)            | 17B          |     376.12 ns |     1.795 ns |     1.679 ns |         - |
| Decrypt · AES-256-GCM (BouncyCastle)                  | 17B          |     645.23 ns |     4.986 ns |     4.664 ns |    1832 B |
|                                                       |              |               |              |              |           |
| Encrypt · AES-256-GCM (CryptoHives-AES-NI+PClMulV256) | 17B          |      69.23 ns |     0.150 ns |     0.140 ns |         - |
| Encrypt · AES-256-GCM (CryptoHives-AES-NI+PClMul)     | 17B          |      69.23 ns |     0.119 ns |     0.112 ns |         - |
| Encrypt · AES-256-GCM (OS)                            | 17B          |     128.30 ns |     0.216 ns |     0.191 ns |         - |
| Encrypt · AES-256-GCM (CryptoHives-Scalar)            | 17B          |     360.08 ns |     1.333 ns |     1.247 ns |         - |
| Encrypt · AES-256-GCM (BouncyCastle)                  | 17B          |     595.20 ns |     2.812 ns |     2.630 ns |    1816 B |
|                                                       |              |               |              |              |           |
| Decrypt · AES-256-GCM (CryptoHives-AES-NI+PClMulV256) | 65B          |     116.69 ns |     0.245 ns |     0.229 ns |         - |
| Decrypt · AES-256-GCM (CryptoHives-AES-NI+PClMul)     | 65B          |     118.49 ns |     0.352 ns |     0.329 ns |         - |
| Decrypt · AES-256-GCM (OS)                            | 65B          |     134.00 ns |     0.353 ns |     0.313 ns |         - |
| Decrypt · AES-256-GCM (CryptoHives-Scalar)            | 65B          |     657.06 ns |     3.393 ns |     3.174 ns |         - |
| Decrypt · AES-256-GCM (BouncyCastle)                  | 65B          |     867.23 ns |     4.225 ns |     3.952 ns |    1832 B |
|                                                       |              |               |              |              |           |
| Encrypt · AES-256-GCM (CryptoHives-AES-NI+PClMulV256) | 65B          |      76.63 ns |     0.156 ns |     0.130 ns |         - |
| Encrypt · AES-256-GCM (CryptoHives-AES-NI+PClMul)     | 65B          |      76.65 ns |     0.235 ns |     0.220 ns |         - |
| Encrypt · AES-256-GCM (OS)                            | 65B          |     133.33 ns |     0.555 ns |     0.519 ns |         - |
| Encrypt · AES-256-GCM (CryptoHives-Scalar)            | 65B          |     637.93 ns |     1.670 ns |     1.562 ns |         - |
| Encrypt · AES-256-GCM (BouncyCastle)                  | 65B          |     788.39 ns |    14.276 ns |    13.354 ns |    1816 B |
|                                                       |              |               |              |              |           |
| Decrypt · AES-256-GCM (CryptoHives-AES-NI+PClMulV256) | 128B         |     105.56 ns |     0.447 ns |     0.418 ns |         - |
| Decrypt · AES-256-GCM (CryptoHives-AES-NI+PClMul)     | 128B         |     106.15 ns |     0.222 ns |     0.197 ns |         - |
| Decrypt · AES-256-GCM (OS)                            | 128B         |     123.44 ns |     0.561 ns |     0.525 ns |         - |
| Decrypt · AES-256-GCM (CryptoHives-Scalar)            | 128B         |     940.22 ns |     3.068 ns |     2.870 ns |         - |
| Decrypt · AES-256-GCM (BouncyCastle)                  | 128B         |   1,054.45 ns |     4.264 ns |     3.561 ns |    1832 B |
|                                                       |              |               |              |              |           |
| Encrypt · AES-256-GCM (CryptoHives-AES-NI+PClMulV256) | 128B         |      62.49 ns |     0.059 ns |     0.049 ns |         - |
| Encrypt · AES-256-GCM (CryptoHives-AES-NI+PClMul)     | 128B         |      64.53 ns |     0.200 ns |     0.187 ns |         - |
| Encrypt · AES-256-GCM (OS)                            | 128B         |     124.39 ns |     0.272 ns |     0.255 ns |         - |
| Encrypt · AES-256-GCM (CryptoHives-Scalar)            | 128B         |     922.62 ns |     3.278 ns |     2.906 ns |         - |
| Encrypt · AES-256-GCM (BouncyCastle)                  | 128B         |     973.00 ns |     6.086 ns |     5.693 ns |    1816 B |
|                                                       |              |               |              |              |           |
| Decrypt · AES-256-GCM (OS)                            | 152B         |     140.15 ns |     0.462 ns |     0.432 ns |         - |
| Decrypt · AES-256-GCM (CryptoHives-AES-NI+PClMul)     | 152B         |     142.09 ns |     0.302 ns |     0.253 ns |         - |
| Decrypt · AES-256-GCM (CryptoHives-AES-NI+PClMulV256) | 152B         |     142.53 ns |     0.445 ns |     0.416 ns |         - |
| Decrypt · AES-256-GCM (CryptoHives-Scalar)            | 152B         |   1,127.70 ns |     5.327 ns |     4.722 ns |         - |
| Decrypt · AES-256-GCM (BouncyCastle)                  | 152B         |   1,233.06 ns |     3.676 ns |     3.439 ns |    1832 B |
|                                                       |              |               |              |              |           |
| Encrypt · AES-256-GCM (CryptoHives-AES-NI+PClMulV256) | 152B         |      92.11 ns |     0.203 ns |     0.189 ns |         - |
| Encrypt · AES-256-GCM (CryptoHives-AES-NI+PClMul)     | 152B         |      95.67 ns |     0.227 ns |     0.212 ns |         - |
| Encrypt · AES-256-GCM (OS)                            | 152B         |     144.04 ns |     0.373 ns |     0.330 ns |         - |
| Encrypt · AES-256-GCM (CryptoHives-Scalar)            | 152B         |   1,095.90 ns |     4.841 ns |     4.528 ns |         - |
| Encrypt · AES-256-GCM (BouncyCastle)                  | 152B         |   1,114.16 ns |     5.102 ns |     4.523 ns |    1816 B |
|                                                       |              |               |              |              |           |
| Decrypt · AES-256-GCM (CryptoHives-AES-NI+PClMulV256) | 256B         |     122.39 ns |     0.663 ns |     0.621 ns |         - |
| Decrypt · AES-256-GCM (CryptoHives-AES-NI+PClMul)     | 256B         |     127.93 ns |     0.375 ns |     0.351 ns |         - |
| Decrypt · AES-256-GCM (OS)                            | 256B         |     136.50 ns |     0.249 ns |     0.220 ns |         - |
| Decrypt · AES-256-GCM (BouncyCastle)                  | 256B         |   1,585.44 ns |    10.158 ns |     9.502 ns |    1832 B |
| Decrypt · AES-256-GCM (CryptoHives-Scalar)            | 256B         |   1,693.38 ns |    10.323 ns |     9.656 ns |         - |
|                                                       |              |               |              |              |           |
| Encrypt · AES-256-GCM (CryptoHives-AES-NI+PClMulV256) | 256B         |      83.19 ns |     0.140 ns |     0.131 ns |         - |
| Encrypt · AES-256-GCM (CryptoHives-AES-NI+PClMul)     | 256B         |      88.14 ns |     0.230 ns |     0.204 ns |         - |
| Encrypt · AES-256-GCM (OS)                            | 256B         |     125.27 ns |     0.303 ns |     0.284 ns |         - |
| Encrypt · AES-256-GCM (BouncyCastle)                  | 256B         |   1,483.49 ns |     7.845 ns |     7.338 ns |    1816 B |
| Encrypt · AES-256-GCM (CryptoHives-Scalar)            | 256B         |   1,652.90 ns |     9.410 ns |     8.803 ns |         - |
|                                                       |              |               |              |              |           |
| Decrypt · AES-256-GCM (OS)                            | 1KB          |     213.04 ns |     0.376 ns |     0.334 ns |         - |
| Decrypt · AES-256-GCM (CryptoHives-AES-NI+PClMulV256) | 1KB          |     214.28 ns |     0.338 ns |     0.299 ns |         - |
| Decrypt · AES-256-GCM (CryptoHives-AES-NI+PClMul)     | 1KB          |     265.04 ns |     0.583 ns |     0.517 ns |         - |
| Decrypt · AES-256-GCM (BouncyCastle)                  | 1KB          |   4,682.35 ns |    17.021 ns |    15.089 ns |    1832 B |
| Decrypt · AES-256-GCM (CryptoHives-Scalar)            | 1KB          |   6,174.70 ns |    17.272 ns |    16.156 ns |         - |
|                                                       |              |               |              |              |           |
| Encrypt · AES-256-GCM (OS)                            | 1KB          |     181.92 ns |     0.606 ns |     0.567 ns |         - |
| Encrypt · AES-256-GCM (CryptoHives-AES-NI+PClMulV256) | 1KB          |     200.22 ns |     0.435 ns |     0.386 ns |         - |
| Encrypt · AES-256-GCM (CryptoHives-AES-NI+PClMul)     | 1KB          |     221.72 ns |     0.614 ns |     0.545 ns |         - |
| Encrypt · AES-256-GCM (BouncyCastle)                  | 1KB          |   4,576.39 ns |    17.458 ns |    16.331 ns |    1816 B |
| Encrypt · AES-256-GCM (CryptoHives-Scalar)            | 1KB          |   6,152.93 ns |    45.113 ns |    42.199 ns |         - |
|                                                       |              |               |              |              |           |
| Decrypt · AES-256-GCM (OS)                            | 8KB          |     942.26 ns |     2.067 ns |     1.933 ns |         - |
| Decrypt · AES-256-GCM (CryptoHives-AES-NI+PClMulV256) | 8KB          |   1,134.22 ns |     2.542 ns |     2.253 ns |         - |
| Decrypt · AES-256-GCM (CryptoHives-AES-NI+PClMul)     | 8KB          |   1,557.05 ns |     4.576 ns |     4.281 ns |         - |
| Decrypt · AES-256-GCM (BouncyCastle)                  | 8KB          |  33,442.91 ns |   103.238 ns |    91.517 ns |    1832 B |
| Decrypt · AES-256-GCM (CryptoHives-Scalar)            | 8KB          |  48,079.90 ns |   224.575 ns |   210.068 ns |         - |
|                                                       |              |               |              |              |           |
| Encrypt · AES-256-GCM (OS)                            | 8KB          |     727.51 ns |     2.786 ns |     2.606 ns |         - |
| Encrypt · AES-256-GCM (CryptoHives-AES-NI+PClMulV256) | 8KB          |   1,301.33 ns |     4.258 ns |     3.775 ns |         - |
| Encrypt · AES-256-GCM (CryptoHives-AES-NI+PClMul)     | 8KB          |   1,472.20 ns |     2.903 ns |     2.715 ns |         - |
| Encrypt · AES-256-GCM (BouncyCastle)                  | 8KB          |  33,246.75 ns |   146.025 ns |   136.591 ns |    1816 B |
| Encrypt · AES-256-GCM (CryptoHives-Scalar)            | 8KB          |  47,977.81 ns |   141.797 ns |   125.699 ns |         - |
|                                                       |              |               |              |              |           |
| Decrypt · AES-256-GCM (OS)                            | 128KB        |  14,285.30 ns |    27.413 ns |    25.642 ns |         - |
| Decrypt · AES-256-GCM (CryptoHives-AES-NI+PClMulV256) | 128KB        |  17,360.33 ns |   146.891 ns |   137.402 ns |         - |
| Decrypt · AES-256-GCM (CryptoHives-AES-NI+PClMul)     | 128KB        |  23,289.15 ns |    80.120 ns |    74.944 ns |         - |
| Decrypt · AES-256-GCM (BouncyCastle)                  | 128KB        | 533,993.69 ns | 1,012.869 ns |   947.438 ns |    1832 B |
| Decrypt · AES-256-GCM (CryptoHives-Scalar)            | 128KB        | 768,052.74 ns | 3,574.137 ns | 3,343.250 ns |         - |
|                                                       |              |               |              |              |           |
| Encrypt · AES-256-GCM (OS)                            | 128KB        |  10,574.83 ns |    44.383 ns |    41.516 ns |         - |
| Encrypt · AES-256-GCM (CryptoHives-AES-NI+PClMulV256) | 128KB        |  20,219.61 ns |    59.127 ns |    55.307 ns |         - |
| Encrypt · AES-256-GCM (CryptoHives-AES-NI+PClMul)     | 128KB        |  22,953.02 ns |    85.087 ns |    79.590 ns |         - |
| Encrypt · AES-256-GCM (BouncyCastle)                  | 128KB        | 527,109.62 ns | 2,193.061 ns | 2,051.390 ns |    1816 B |
| Encrypt · AES-256-GCM (CryptoHives-Scalar)            | 128KB        | 763,765.67 ns | 4,693.947 ns | 4,390.721 ns |         - |