| Description                                           | TestDataSize | Mean          | Error        | StdDev       | Code Size | Allocated |
|------------------------------------------------------ |------------- |--------------:|-------------:|-------------:|----------:|----------:|
| Decrypt · AES-192-GCM (CryptoHives-AES-NI+PClMul)     | 17B          |     111.11 ns |     0.312 ns |     0.292 ns |     306 B |         - |
| Decrypt · AES-192-GCM (CryptoHives-AES-NI+PClMulV256) | 17B          |     113.33 ns |     0.222 ns |     0.186 ns |     306 B |         - |
| Decrypt · AES-192-GCM (OS)                            | 17B          |     137.54 ns |     0.315 ns |     0.295 ns |   2,230 B |         - |
| Decrypt · AES-192-GCM (CryptoHives-Scalar)            | 17B          |     399.84 ns |     0.780 ns |     0.729 ns |     306 B |         - |
| Decrypt · AES-192-GCM (BouncyCastle)                  | 17B          |     598.76 ns |     2.804 ns |     2.623 ns |     306 B |    1728 B |
|                                                       |              |               |              |              |           |           |
| Encrypt · AES-192-GCM (CryptoHives-AES-NI+PClMul)     | 17B          |      76.20 ns |     0.252 ns |     0.236 ns |     383 B |         - |
| Encrypt · AES-192-GCM (CryptoHives-AES-NI+PClMulV256) | 17B          |      93.74 ns |     0.073 ns |     0.061 ns |     383 B |         - |
| Encrypt · AES-192-GCM (OS)                            | 17B          |     145.04 ns |     0.393 ns |     0.349 ns |   2,202 B |         - |
| Encrypt · AES-192-GCM (CryptoHives-Scalar)            | 17B          |     358.96 ns |     1.492 ns |     1.396 ns |     386 B |         - |
| Encrypt · AES-192-GCM (BouncyCastle)                  | 17B          |     531.99 ns |     2.412 ns |     2.138 ns |     386 B |    1712 B |
|                                                       |              |               |              |              |           |           |
| Decrypt · AES-192-GCM (CryptoHives-AES-NI+PClMul)     | 65B          |     115.56 ns |     0.242 ns |     0.214 ns |     306 B |         - |
| Decrypt · AES-192-GCM (CryptoHives-AES-NI+PClMulV256) | 65B          |     115.96 ns |     0.352 ns |     0.329 ns |     306 B |         - |
| Decrypt · AES-192-GCM (OS)                            | 65B          |     142.00 ns |     0.475 ns |     0.444 ns |   2,230 B |         - |
| Decrypt · AES-192-GCM (CryptoHives-Scalar)            | 65B          |     686.26 ns |     3.334 ns |     3.118 ns |     306 B |         - |
| Decrypt · AES-192-GCM (BouncyCastle)                  | 65B          |     825.44 ns |     2.713 ns |     2.538 ns |     306 B |    1728 B |
|                                                       |              |               |              |              |           |           |
| Encrypt · AES-192-GCM (CryptoHives-AES-NI+PClMulV256) | 65B          |      83.79 ns |     0.191 ns |     0.178 ns |     383 B |         - |
| Encrypt · AES-192-GCM (CryptoHives-AES-NI+PClMul)     | 65B          |      83.90 ns |     0.170 ns |     0.159 ns |     383 B |         - |
| Encrypt · AES-192-GCM (OS)                            | 65B          |     156.16 ns |     0.605 ns |     0.566 ns |   2,202 B |         - |
| Encrypt · AES-192-GCM (CryptoHives-Scalar)            | 65B          |     633.85 ns |     1.332 ns |     1.246 ns |     386 B |         - |
| Encrypt · AES-192-GCM (BouncyCastle)                  | 65B          |     727.88 ns |     2.950 ns |     2.615 ns |     383 B |    1712 B |
|                                                       |              |               |              |              |           |           |
| Decrypt · AES-192-GCM (CryptoHives-AES-NI+PClMul)     | 128B         |     116.02 ns |     0.398 ns |     0.372 ns |     306 B |         - |
| Decrypt · AES-192-GCM (CryptoHives-AES-NI+PClMulV256) | 128B         |     120.12 ns |     0.367 ns |     0.326 ns |     306 B |         - |
| Decrypt · AES-192-GCM (OS)                            | 128B         |     140.68 ns |     0.400 ns |     0.374 ns |   2,230 B |         - |
| Decrypt · AES-192-GCM (CryptoHives-Scalar)            | 128B         |     973.25 ns |     5.002 ns |     4.679 ns |     306 B |         - |
| Decrypt · AES-192-GCM (BouncyCastle)                  | 128B         |   1,024.04 ns |     5.310 ns |     4.967 ns |     306 B |    1728 B |
|                                                       |              |               |              |              |           |           |
| Encrypt · AES-192-GCM (CryptoHives-AES-NI+PClMulV256) | 128B         |      69.26 ns |     0.192 ns |     0.180 ns |     383 B |         - |
| Encrypt · AES-192-GCM (CryptoHives-AES-NI+PClMul)     | 128B         |      78.14 ns |     0.227 ns |     0.212 ns |     383 B |         - |
| Encrypt · AES-192-GCM (OS)                            | 128B         |     141.08 ns |     0.629 ns |     0.588 ns |   2,202 B |         - |
| Encrypt · AES-192-GCM (BouncyCastle)                  | 128B         |     912.98 ns |     2.315 ns |     2.165 ns |     383 B |    1712 B |
| Encrypt · AES-192-GCM (CryptoHives-Scalar)            | 128B         |     922.29 ns |     1.307 ns |     1.158 ns |     383 B |         - |
|                                                       |              |               |              |              |           |           |
| Decrypt · AES-192-GCM (CryptoHives-AES-NI+PClMul)     | 152B         |     132.04 ns |     0.309 ns |     0.274 ns |     306 B |         - |
| Decrypt · AES-192-GCM (CryptoHives-AES-NI+PClMulV256) | 152B         |     136.25 ns |     0.363 ns |     0.321 ns |     306 B |         - |
| Decrypt · AES-192-GCM (OS)                            | 152B         |     162.59 ns |     0.526 ns |     0.492 ns |   2,230 B |         - |
| Decrypt · AES-192-GCM (CryptoHives-Scalar)            | 152B         |   1,157.47 ns |     3.994 ns |     3.541 ns |     306 B |         - |
| Decrypt · AES-192-GCM (BouncyCastle)                  | 152B         |   1,176.27 ns |     4.615 ns |     4.317 ns |     306 B |    1728 B |
|                                                       |              |               |              |              |           |           |
| Encrypt · AES-192-GCM (CryptoHives-AES-NI+PClMulV256) | 152B         |      98.77 ns |     0.187 ns |     0.175 ns |     386 B |         - |
| Encrypt · AES-192-GCM (CryptoHives-AES-NI+PClMul)     | 152B         |     100.49 ns |     0.164 ns |     0.153 ns |     383 B |         - |
| Encrypt · AES-192-GCM (OS)                            | 152B         |     161.48 ns |     0.261 ns |     0.218 ns |   2,202 B |         - |
| Encrypt · AES-192-GCM (BouncyCastle)                  | 152B         |   1,072.78 ns |     6.398 ns |     5.985 ns |     383 B |    1712 B |
| Encrypt · AES-192-GCM (CryptoHives-Scalar)            | 152B         |   1,108.37 ns |     2.965 ns |     2.628 ns |     383 B |         - |
|                                                       |              |               |              |              |           |           |
| Decrypt · AES-192-GCM (CryptoHives-AES-NI+PClMulV256) | 256B         |     137.63 ns |     0.551 ns |     0.488 ns |     306 B |         - |
| Decrypt · AES-192-GCM (OS)                            | 256B         |     151.59 ns |     0.380 ns |     0.355 ns |   2,230 B |         - |
| Decrypt · AES-192-GCM (CryptoHives-AES-NI+PClMul)     | 256B         |     154.46 ns |     0.711 ns |     0.665 ns |     306 B |         - |
| Decrypt · AES-192-GCM (BouncyCastle)                  | 256B         |   1,553.21 ns |     3.622 ns |     3.388 ns |     306 B |    1728 B |
| Decrypt · AES-192-GCM (CryptoHives-Scalar)            | 256B         |   1,724.94 ns |     4.631 ns |     4.332 ns |     306 B |         - |
|                                                       |              |               |              |              |           |           |
| Encrypt · AES-192-GCM (CryptoHives-AES-NI+PClMulV256) | 256B         |      90.07 ns |     0.228 ns |     0.202 ns |     383 B |         - |
| Encrypt · AES-192-GCM (CryptoHives-AES-NI+PClMul)     | 256B         |      95.39 ns |     0.323 ns |     0.302 ns |     383 B |         - |
| Encrypt · AES-192-GCM (OS)                            | 256B         |     147.74 ns |     0.511 ns |     0.478 ns |   2,202 B |         - |
| Encrypt · AES-192-GCM (BouncyCastle)                  | 256B         |   1,473.01 ns |     4.476 ns |     4.187 ns |     383 B |    1712 B |
| Encrypt · AES-192-GCM (CryptoHives-Scalar)            | 256B         |   1,674.15 ns |     2.730 ns |     2.420 ns |     383 B |         - |
|                                                       |              |               |              |              |           |           |
| Decrypt · AES-192-GCM (OS)                            | 1KB          |     215.84 ns |     0.331 ns |     0.277 ns |   2,230 B |         - |
| Decrypt · AES-192-GCM (CryptoHives-AES-NI+PClMulV256) | 1KB          |     247.77 ns |     1.110 ns |     1.038 ns |     306 B |         - |
| Decrypt · AES-192-GCM (CryptoHives-AES-NI+PClMul)     | 1KB          |     297.55 ns |     0.826 ns |     0.732 ns |     306 B |         - |
| Decrypt · AES-192-GCM (BouncyCastle)                  | 1KB          |   4,703.55 ns |    13.358 ns |    12.495 ns |     306 B |    1728 B |
| Decrypt · AES-192-GCM (CryptoHives-Scalar)            | 1KB          |   6,260.10 ns |    15.216 ns |    13.488 ns |     306 B |         - |
|                                                       |              |               |              |              |           |           |
| Encrypt · AES-192-GCM (OS)                            | 1KB          |     210.50 ns |     0.417 ns |     0.369 ns |   2,205 B |         - |
| Encrypt · AES-192-GCM (CryptoHives-AES-NI+PClMulV256) | 1KB          |     216.31 ns |     0.432 ns |     0.337 ns |     383 B |         - |
| Encrypt · AES-192-GCM (CryptoHives-AES-NI+PClMul)     | 1KB          |     245.03 ns |     0.857 ns |     0.760 ns |     383 B |         - |
| Encrypt · AES-192-GCM (BouncyCastle)                  | 1KB          |   4,670.47 ns |    26.849 ns |    25.114 ns |     383 B |    1712 B |
| Encrypt · AES-192-GCM (CryptoHives-Scalar)            | 1KB          |   6,202.46 ns |     9.913 ns |     8.278 ns |     386 B |         - |
|                                                       |              |               |              |              |           |           |
| Decrypt · AES-192-GCM (OS)                            | 8KB          |     903.32 ns |     1.770 ns |     1.478 ns |   2,230 B |         - |
| Decrypt · AES-192-GCM (CryptoHives-AES-NI+PClMulV256) | 8KB          |   1,262.47 ns |     4.052 ns |     3.790 ns |     306 B |         - |
| Decrypt · AES-192-GCM (CryptoHives-AES-NI+PClMul)     | 8KB          |   1,703.95 ns |     6.367 ns |     5.956 ns |     306 B |         - |
| Decrypt · AES-192-GCM (BouncyCastle)                  | 8KB          |  34,060.40 ns |    92.381 ns |    86.413 ns |     306 B |    1728 B |
| Decrypt · AES-192-GCM (CryptoHives-Scalar)            | 8KB          |  48,627.45 ns |   168.793 ns |   157.889 ns |     306 B |         - |
|                                                       |              |               |              |              |           |           |
| Encrypt · AES-192-GCM (OS)                            | 8KB          |     798.08 ns |     2.028 ns |     1.798 ns |   2,205 B |         - |
| Encrypt · AES-192-GCM (CryptoHives-AES-NI+PClMulV256) | 8KB          |   1,388.77 ns |     3.534 ns |     3.133 ns |     383 B |         - |
| Encrypt · AES-192-GCM (CryptoHives-AES-NI+PClMul)     | 8KB          |   1,594.66 ns |     4.186 ns |     3.711 ns |     383 B |         - |
| Encrypt · AES-192-GCM (BouncyCastle)                  | 8KB          |  34,006.58 ns |   112.551 ns |   105.280 ns |     383 B |    1712 B |
| Encrypt · AES-192-GCM (CryptoHives-Scalar)            | 8KB          |  48,556.03 ns |   157.096 ns |   146.947 ns |     383 B |         - |
|                                                       |              |               |              |              |           |           |
| Decrypt · AES-192-GCM (OS)                            | 128KB        |  13,258.99 ns |    22.180 ns |    17.316 ns |   2,230 B |         - |
| Decrypt · AES-192-GCM (CryptoHives-AES-NI+PClMulV256) | 128KB        |  19,167.30 ns |    63.773 ns |    59.653 ns |     306 B |         - |
| Decrypt · AES-192-GCM (CryptoHives-AES-NI+PClMul)     | 128KB        |  25,756.98 ns |   102.751 ns |    91.086 ns |     306 B |         - |
| Decrypt · AES-192-GCM (BouncyCastle)                  | 128KB        | 542,958.34 ns | 1,636.961 ns | 1,451.123 ns |     306 B |    1728 B |
| Decrypt · AES-192-GCM (CryptoHives-Scalar)            | 128KB        | 773,077.96 ns | 1,861.968 ns | 1,741.686 ns |     306 B |         - |
|                                                       |              |               |              |              |           |           |
| Encrypt · AES-192-GCM (OS)                            | 128KB        |  11,769.22 ns |    30.418 ns |    28.453 ns |   2,202 B |         - |
| Encrypt · AES-192-GCM (CryptoHives-AES-NI+PClMulV256) | 128KB        |  21,520.28 ns |    81.668 ns |    76.392 ns |     383 B |         - |
| Encrypt · AES-192-GCM (CryptoHives-AES-NI+PClMul)     | 128KB        |  24,763.28 ns |    50.323 ns |    47.072 ns |     383 B |         - |
| Encrypt · AES-192-GCM (BouncyCastle)                  | 128KB        | 541,219.78 ns | 3,929.721 ns | 3,483.596 ns |     383 B |    1712 B |
| Encrypt · AES-192-GCM (CryptoHives-Scalar)            | 128KB        | 773,573.80 ns | 1,993.720 ns | 1,767.381 ns |     383 B |         - |