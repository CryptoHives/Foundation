| Description                                           | TestDataSize | Mean          | Error        | StdDev       | Code Size | Allocated |
|------------------------------------------------------ |------------- |--------------:|-------------:|-------------:|----------:|----------:|
| Decrypt · AES-256-GCM (CryptoHives-AES-NI+PClMulV256) | 17B          |     119.89 ns |     0.320 ns |     0.250 ns |     306 B |         - |
| Decrypt · AES-256-GCM (CryptoHives-AES-NI+PClMul)     | 17B          |     119.91 ns |     0.431 ns |     0.403 ns |     306 B |         - |
| Decrypt · AES-256-GCM (OS)                            | 17B          |     143.31 ns |     0.352 ns |     0.329 ns |   2,361 B |         - |
| Decrypt · AES-256-GCM (CryptoHives-Scalar)            | 17B          |     412.51 ns |     1.295 ns |     1.081 ns |     306 B |         - |
| Decrypt · AES-256-GCM (BouncyCastle)                  | 17B          |     628.52 ns |     1.567 ns |     1.309 ns |     306 B |    1832 B |
|                                                       |              |               |              |              |           |           |
| Encrypt · AES-256-GCM (CryptoHives-AES-NI+PClMulV256) | 17B          |      82.81 ns |     0.174 ns |     0.145 ns |     386 B |         - |
| Encrypt · AES-256-GCM (CryptoHives-AES-NI+PClMul)     | 17B          |      83.95 ns |     0.100 ns |     0.088 ns |     386 B |         - |
| Encrypt · AES-256-GCM (OS)                            | 17B          |     155.35 ns |     0.255 ns |     0.213 ns |   2,257 B |         - |
| Encrypt · AES-256-GCM (CryptoHives-Scalar)            | 17B          |     372.85 ns |     1.458 ns |     1.293 ns |     386 B |         - |
| Encrypt · AES-256-GCM (BouncyCastle)                  | 17B          |     594.96 ns |     3.990 ns |     3.332 ns |     386 B |    1816 B |
|                                                       |              |               |              |              |           |           |
| Decrypt · AES-256-GCM (CryptoHives-AES-NI+PClMul)     | 65B          |     124.51 ns |     0.328 ns |     0.307 ns |     306 B |         - |
| Decrypt · AES-256-GCM (CryptoHives-AES-NI+PClMulV256) | 65B          |     126.25 ns |     0.428 ns |     0.400 ns |     306 B |         - |
| Decrypt · AES-256-GCM (OS)                            | 65B          |     149.57 ns |     1.665 ns |     1.557 ns |   2,361 B |         - |
| Decrypt · AES-256-GCM (CryptoHives-Scalar)            | 65B          |     714.79 ns |     2.204 ns |     2.061 ns |     306 B |         - |
| Decrypt · AES-256-GCM (BouncyCastle)                  | 65B          |     881.15 ns |    17.363 ns |    20.669 ns |     306 B |    1832 B |
|                                                       |              |               |              |              |           |           |
| Encrypt · AES-256-GCM (CryptoHives-AES-NI+PClMulV256) | 65B          |      92.12 ns |     0.130 ns |     0.102 ns |     386 B |         - |
| Encrypt · AES-256-GCM (CryptoHives-AES-NI+PClMul)     | 65B          |      92.43 ns |     0.216 ns |     0.191 ns |     386 B |         - |
| Encrypt · AES-256-GCM (OS)                            | 65B          |     155.77 ns |     0.252 ns |     0.210 ns |   2,257 B |         - |
| Encrypt · AES-256-GCM (CryptoHives-Scalar)            | 65B          |     674.78 ns |     0.848 ns |     0.708 ns |     386 B |         - |
| Encrypt · AES-256-GCM (BouncyCastle)                  | 65B          |     769.39 ns |     2.564 ns |     2.398 ns |     386 B |    1816 B |
|                                                       |              |               |              |              |           |           |
| Decrypt · AES-256-GCM (CryptoHives-AES-NI+PClMul)     | 128B         |     128.09 ns |     0.376 ns |     0.333 ns |     306 B |         - |
| Decrypt · AES-256-GCM (CryptoHives-AES-NI+PClMulV256) | 128B         |     129.85 ns |     0.370 ns |     0.328 ns |     306 B |         - |
| Decrypt · AES-256-GCM (OS)                            | 128B         |     143.85 ns |     0.304 ns |     0.269 ns |   2,361 B |         - |
| Decrypt · AES-256-GCM (CryptoHives-Scalar)            | 128B         |   1,018.01 ns |     4.663 ns |     3.641 ns |     306 B |         - |
| Decrypt · AES-256-GCM (BouncyCastle)                  | 128B         |   1,060.00 ns |     3.043 ns |     2.697 ns |     306 B |    1832 B |
|                                                       |              |               |              |              |           |           |
| Encrypt · AES-256-GCM (CryptoHives-AES-NI+PClMulV256) | 128B         |      75.62 ns |     0.648 ns |     0.574 ns |     386 B |         - |
| Encrypt · AES-256-GCM (CryptoHives-AES-NI+PClMul)     | 128B         |      77.61 ns |     0.266 ns |     0.236 ns |     386 B |         - |
| Encrypt · AES-256-GCM (OS)                            | 128B         |     146.29 ns |     0.771 ns |     0.722 ns |   2,257 B |         - |
| Encrypt · AES-256-GCM (BouncyCastle)                  | 128B         |     956.15 ns |     4.390 ns |     4.106 ns |     386 B |    1816 B |
| Encrypt · AES-256-GCM (CryptoHives-Scalar)            | 128B         |     970.00 ns |     3.332 ns |     2.954 ns |     386 B |         - |
|                                                       |              |               |              |              |           |           |
| Decrypt · AES-256-GCM (CryptoHives-AES-NI+PClMulV256) | 152B         |     148.05 ns |     0.556 ns |     0.493 ns |     306 B |         - |
| Decrypt · AES-256-GCM (CryptoHives-AES-NI+PClMul)     | 152B         |     148.72 ns |     0.580 ns |     0.514 ns |     306 B |         - |
| Decrypt · AES-256-GCM (OS)                            | 152B         |     168.50 ns |     0.599 ns |     0.531 ns |   2,361 B |         - |
| Decrypt · AES-256-GCM (CryptoHives-Scalar)            | 152B         |   1,214.05 ns |     3.036 ns |     2.370 ns |     306 B |         - |
| Decrypt · AES-256-GCM (BouncyCastle)                  | 152B         |   1,225.25 ns |     3.624 ns |     3.213 ns |     306 B |    1832 B |
|                                                       |              |               |              |              |           |           |
| Encrypt · AES-256-GCM (CryptoHives-AES-NI+PClMulV256) | 152B         |     106.55 ns |     0.394 ns |     0.349 ns |     386 B |         - |
| Encrypt · AES-256-GCM (CryptoHives-AES-NI+PClMul)     | 152B         |     109.08 ns |     0.367 ns |     0.307 ns |     386 B |         - |
| Encrypt · AES-256-GCM (OS)                            | 152B         |     168.71 ns |     0.360 ns |     0.320 ns |   2,257 B |         - |
| Encrypt · AES-256-GCM (BouncyCastle)                  | 152B         |   1,125.93 ns |     4.712 ns |     4.177 ns |     386 B |    1816 B |
| Encrypt · AES-256-GCM (CryptoHives-Scalar)            | 152B         |   1,171.39 ns |     6.198 ns |     5.495 ns |     386 B |         - |
|                                                       |              |               |              |              |           |           |
| Decrypt · AES-256-GCM (CryptoHives-AES-NI+PClMulV256) | 256B         |     148.87 ns |     0.528 ns |     0.468 ns |     306 B |         - |
| Decrypt · AES-256-GCM (OS)                            | 256B         |     159.81 ns |     0.420 ns |     0.351 ns |   2,361 B |         - |
| Decrypt · AES-256-GCM (CryptoHives-AES-NI+PClMul)     | 256B         |     170.42 ns |     0.305 ns |     0.255 ns |     306 B |         - |
| Decrypt · AES-256-GCM (BouncyCastle)                  | 256B         |   1,612.32 ns |     3.652 ns |     3.237 ns |     306 B |    1832 B |
| Decrypt · AES-256-GCM (CryptoHives-Scalar)            | 256B         |   1,830.46 ns |     4.574 ns |     4.279 ns |     306 B |         - |
|                                                       |              |               |              |              |           |           |
| Encrypt · AES-256-GCM (CryptoHives-AES-NI+PClMulV256) | 256B         |      98.11 ns |     0.125 ns |     0.105 ns |     383 B |         - |
| Encrypt · AES-256-GCM (CryptoHives-AES-NI+PClMul)     | 256B         |     103.87 ns |     0.180 ns |     0.151 ns |     383 B |         - |
| Encrypt · AES-256-GCM (OS)                            | 256B         |     151.45 ns |     0.734 ns |     0.613 ns |   2,254 B |         - |
| Encrypt · AES-256-GCM (BouncyCastle)                  | 256B         |   1,498.15 ns |     5.457 ns |     4.557 ns |     383 B |    1816 B |
| Encrypt · AES-256-GCM (CryptoHives-Scalar)            | 256B         |   1,766.70 ns |     3.691 ns |     3.082 ns |     383 B |         - |
|                                                       |              |               |              |              |           |           |
| Decrypt · AES-256-GCM (OS)                            | 1KB          |     244.58 ns |     0.447 ns |     0.349 ns |   2,361 B |         - |
| Decrypt · AES-256-GCM (CryptoHives-AES-NI+PClMulV256) | 1KB          |     259.03 ns |     1.093 ns |     0.969 ns |     306 B |         - |
| Decrypt · AES-256-GCM (CryptoHives-AES-NI+PClMul)     | 1KB          |     327.13 ns |     1.397 ns |     1.306 ns |     306 B |         - |
| Decrypt · AES-256-GCM (BouncyCastle)                  | 1KB          |   5,202.31 ns |    99.069 ns |   121.666 ns |     306 B |    1832 B |
| Decrypt · AES-256-GCM (CryptoHives-Scalar)            | 1KB          |   6,602.78 ns |    20.699 ns |    17.285 ns |     306 B |         - |
|                                                       |              |               |              |              |           |           |
| Encrypt · AES-256-GCM (OS)                            | 1KB          |     223.79 ns |     0.229 ns |     0.179 ns |   2,257 B |         - |
| Encrypt · AES-256-GCM (CryptoHives-AES-NI+PClMulV256) | 1KB          |     235.03 ns |     0.261 ns |     0.218 ns |     386 B |         - |
| Encrypt · AES-256-GCM (CryptoHives-AES-NI+PClMul)     | 1KB          |     264.84 ns |     0.871 ns |     0.772 ns |     386 B |         - |
| Encrypt · AES-256-GCM (BouncyCastle)                  | 1KB          |   4,841.79 ns |    39.420 ns |    30.776 ns |     386 B |    1816 B |
| Encrypt · AES-256-GCM (CryptoHives-Scalar)            | 1KB          |   6,565.90 ns |    14.657 ns |    12.993 ns |     386 B |         - |
|                                                       |              |               |              |              |           |           |
| Decrypt · AES-256-GCM (OS)                            | 8KB          |   1,110.04 ns |     3.107 ns |     2.906 ns |   2,361 B |         - |
| Decrypt · AES-256-GCM (CryptoHives-AES-NI+PClMulV256) | 8KB          |   1,369.53 ns |     3.366 ns |     2.811 ns |     306 B |         - |
| Decrypt · AES-256-GCM (CryptoHives-AES-NI+PClMul)     | 8KB          |   1,824.92 ns |    14.408 ns |    12.772 ns |     306 B |         - |
| Decrypt · AES-256-GCM (BouncyCastle)                  | 8KB          |  35,234.96 ns |   124.034 ns |   109.953 ns |     306 B |    1832 B |
| Decrypt · AES-256-GCM (CryptoHives-Scalar)            | 8KB          |  51,177.72 ns |   154.803 ns |   137.229 ns |     306 B |         - |
|                                                       |              |               |              |              |           |           |
| Encrypt · AES-256-GCM (OS)                            | 8KB          |     840.91 ns |     2.175 ns |     1.816 ns |   2,257 B |         - |
| Encrypt · AES-256-GCM (CryptoHives-AES-NI+PClMulV256) | 8KB          |   1,525.46 ns |     5.148 ns |     4.299 ns |     386 B |         - |
| Encrypt · AES-256-GCM (CryptoHives-AES-NI+PClMul)     | 8KB          |   1,733.29 ns |     3.633 ns |     2.836 ns |     386 B |         - |
| Encrypt · AES-256-GCM (BouncyCastle)                  | 8KB          |  35,087.66 ns |    89.310 ns |    69.727 ns |     386 B |    1816 B |
| Encrypt · AES-256-GCM (CryptoHives-Scalar)            | 8KB          |  51,411.17 ns |   511.276 ns |   453.233 ns |     386 B |         - |
|                                                       |              |               |              |              |           |           |
| Decrypt · AES-256-GCM (OS)                            | 128KB        |  16,772.97 ns |    32.378 ns |    30.286 ns |   2,361 B |         - |
| Decrypt · AES-256-GCM (CryptoHives-AES-NI+PClMulV256) | 128KB        |  20,688.13 ns |    59.771 ns |    52.985 ns |     306 B |         - |
| Decrypt · AES-256-GCM (CryptoHives-AES-NI+PClMul)     | 128KB        |  27,385.00 ns |    91.926 ns |    81.490 ns |     306 B |         - |
| Decrypt · AES-256-GCM (BouncyCastle)                  | 128KB        | 564,517.23 ns | 1,953.527 ns | 1,631.283 ns |     306 B |    1832 B |
| Decrypt · AES-256-GCM (CryptoHives-Scalar)            | 128KB        | 829,245.48 ns | 1,274.010 ns | 1,063.856 ns |     306 B |         - |
|                                                       |              |               |              |              |           |           |
| Encrypt · AES-256-GCM (OS)                            | 128KB        |  12,910.75 ns |    27.842 ns |    24.681 ns |   2,257 B |         - |
| Encrypt · AES-256-GCM (CryptoHives-AES-NI+PClMulV256) | 128KB        |  23,612.72 ns |    41.817 ns |    34.919 ns |     386 B |         - |
| Encrypt · AES-256-GCM (CryptoHives-AES-NI+PClMul)     | 128KB        |  26,986.95 ns |    78.218 ns |    73.165 ns |     386 B |         - |
| Encrypt · AES-256-GCM (BouncyCastle)                  | 128KB        | 555,739.75 ns | 2,455.297 ns | 2,296.686 ns |     386 B |    1816 B |
| Encrypt · AES-256-GCM (CryptoHives-Scalar)            | 128KB        | 815,779.09 ns | 2,759.020 ns | 2,445.800 ns |     386 B |         - |