| Description                                           | TestDataSize | Mean          | Error        | StdDev       | Allocated |
|------------------------------------------------------ |------------- |--------------:|-------------:|-------------:|----------:|
| Decrypt · AES-128-GCM (OS)                            | 17B          |     117.77 ns |     0.160 ns |     0.133 ns |         - |
| Decrypt · AES-128-GCM (CryptoHives-AES-NI+PClMul)     | 17B          |     121.66 ns |     0.227 ns |     0.201 ns |         - |
| Decrypt · AES-128-GCM (CryptoHives-AES-NI+PClMulV256) | 17B          |     177.85 ns |     0.627 ns |     0.524 ns |         - |
| Decrypt · AES-128-GCM (CryptoHives-Scalar)            | 17B          |     399.00 ns |     0.471 ns |     0.440 ns |         - |
| Decrypt · AES-128-GCM (BouncyCastle)                  | 17B          |     493.73 ns |     3.466 ns |     3.073 ns |    1624 B |
|                                                       |              |               |              |              |           |
| Encrypt · AES-128-GCM (CryptoHives-AES-NI+PClMul)     | 17B          |      66.54 ns |     0.340 ns |     0.284 ns |         - |
| Encrypt · AES-128-GCM (CryptoHives-AES-NI+PClMulV256) | 17B          |      66.67 ns |     0.183 ns |     0.172 ns |         - |
| Encrypt · AES-128-GCM (OS)                            | 17B          |     123.68 ns |     0.228 ns |     0.191 ns |         - |
| Encrypt · AES-128-GCM (CryptoHives-Scalar)            | 17B          |     383.48 ns |     0.611 ns |     0.542 ns |         - |
| Encrypt · AES-128-GCM (BouncyCastle)                  | 17B          |     457.81 ns |     1.700 ns |     1.419 ns |    1608 B |
|                                                       |              |               |              |              |           |
| Decrypt · AES-128-GCM (CryptoHives-AES-NI+PClMul)     | 65B          |     102.34 ns |     0.278 ns |     0.232 ns |         - |
| Decrypt · AES-128-GCM (CryptoHives-AES-NI+PClMulV256) | 65B          |     105.72 ns |     0.201 ns |     0.179 ns |         - |
| Decrypt · AES-128-GCM (OS)                            | 65B          |     121.59 ns |     0.221 ns |     0.196 ns |         - |
| Decrypt · AES-128-GCM (BouncyCastle)                  | 65B          |     676.04 ns |     2.733 ns |     2.422 ns |    1624 B |
| Decrypt · AES-128-GCM (CryptoHives-Scalar)            | 65B          |     695.03 ns |     1.864 ns |     1.557 ns |         - |
|                                                       |              |               |              |              |           |
| Encrypt · AES-128-GCM (CryptoHives-AES-NI+PClMul)     | 65B          |      71.50 ns |     0.188 ns |     0.166 ns |         - |
| Encrypt · AES-128-GCM (CryptoHives-AES-NI+PClMulV256) | 65B          |      71.71 ns |     0.184 ns |     0.172 ns |         - |
| Encrypt · AES-128-GCM (OS)                            | 65B          |     126.45 ns |     0.712 ns |     0.595 ns |         - |
| Encrypt · AES-128-GCM (BouncyCastle)                  | 65B          |     662.25 ns |     5.299 ns |     4.425 ns |    1608 B |
| Encrypt · AES-128-GCM (CryptoHives-Scalar)            | 65B          |     665.77 ns |     1.433 ns |     1.341 ns |         - |
|                                                       |              |               |              |              |           |
| Decrypt · AES-128-GCM (CryptoHives-AES-NI+PClMul)     | 128B         |      97.28 ns |     0.195 ns |     0.172 ns |         - |
| Decrypt · AES-128-GCM (CryptoHives-AES-NI+PClMulV256) | 128B         |      97.89 ns |     0.135 ns |     0.120 ns |         - |
| Decrypt · AES-128-GCM (OS)                            | 128B         |     121.67 ns |     0.352 ns |     0.329 ns |         - |
| Decrypt · AES-128-GCM (BouncyCastle)                  | 128B         |     824.35 ns |     3.767 ns |     3.339 ns |    1624 B |
| Decrypt · AES-128-GCM (CryptoHives-Scalar)            | 128B         |     990.95 ns |     3.868 ns |     3.429 ns |         - |
|                                                       |              |               |              |              |           |
| Encrypt · AES-128-GCM (CryptoHives-AES-NI+PClMulV256) | 128B         |      61.25 ns |     0.127 ns |     0.113 ns |         - |
| Encrypt · AES-128-GCM (CryptoHives-AES-NI+PClMul)     | 128B         |      62.23 ns |     0.120 ns |     0.093 ns |         - |
| Encrypt · AES-128-GCM (OS)                            | 128B         |     120.09 ns |     0.370 ns |     0.346 ns |         - |
| Encrypt · AES-128-GCM (BouncyCastle)                  | 128B         |     734.62 ns |     2.154 ns |     1.910 ns |    1608 B |
| Encrypt · AES-128-GCM (CryptoHives-Scalar)            | 128B         |     956.50 ns |     2.132 ns |     1.890 ns |         - |
|                                                       |              |               |              |              |           |
| Decrypt · AES-128-GCM (CryptoHives-AES-NI+PClMulV256) | 152B         |     124.44 ns |     0.254 ns |     0.198 ns |         - |
| Decrypt · AES-128-GCM (CryptoHives-AES-NI+PClMul)     | 152B         |     131.45 ns |     0.077 ns |     0.064 ns |         - |
| Decrypt · AES-128-GCM (OS)                            | 152B         |     135.37 ns |     0.297 ns |     0.263 ns |         - |
| Decrypt · AES-128-GCM (BouncyCastle)                  | 152B         |     962.58 ns |     3.352 ns |     2.971 ns |    1624 B |
| Decrypt · AES-128-GCM (CryptoHives-Scalar)            | 152B         |   1,194.57 ns |     3.457 ns |     3.065 ns |         - |
|                                                       |              |               |              |              |           |
| Encrypt · AES-128-GCM (CryptoHives-AES-NI+PClMulV256) | 152B         |      86.63 ns |     0.144 ns |     0.121 ns |         - |
| Encrypt · AES-128-GCM (CryptoHives-AES-NI+PClMul)     | 152B         |      88.09 ns |     0.165 ns |     0.137 ns |         - |
| Encrypt · AES-128-GCM (OS)                            | 152B         |     136.79 ns |     0.317 ns |     0.281 ns |         - |
| Encrypt · AES-128-GCM (BouncyCastle)                  | 152B         |     849.56 ns |     3.577 ns |     3.171 ns |    1608 B |
| Encrypt · AES-128-GCM (CryptoHives-Scalar)            | 152B         |   1,199.51 ns |     4.328 ns |     3.837 ns |         - |
|                                                       |              |               |              |              |           |
| Decrypt · AES-128-GCM (CryptoHives-AES-NI+PClMulV256) | 256B         |     121.78 ns |     0.307 ns |     0.240 ns |         - |
| Decrypt · AES-128-GCM (CryptoHives-AES-NI+PClMul)     | 256B         |     123.50 ns |     0.244 ns |     0.204 ns |         - |
| Decrypt · AES-128-GCM (OS)                            | 256B         |     128.74 ns |     0.324 ns |     0.287 ns |         - |
| Decrypt · AES-128-GCM (BouncyCastle)                  | 256B         |   1,231.60 ns |     4.641 ns |     3.624 ns |    1624 B |
| Decrypt · AES-128-GCM (CryptoHives-Scalar)            | 256B         |   1,771.63 ns |     1.974 ns |     1.750 ns |         - |
|                                                       |              |               |              |              |           |
| Encrypt · AES-128-GCM (CryptoHives-AES-NI+PClMulV256) | 256B         |      76.82 ns |     0.098 ns |     0.076 ns |         - |
| Encrypt · AES-128-GCM (CryptoHives-AES-NI+PClMul)     | 256B         |      81.80 ns |     0.203 ns |     0.180 ns |         - |
| Encrypt · AES-128-GCM (OS)                            | 256B         |     124.74 ns |     0.301 ns |     0.251 ns |         - |
| Encrypt · AES-128-GCM (BouncyCastle)                  | 256B         |   1,124.85 ns |     3.641 ns |     2.842 ns |    1608 B |
| Encrypt · AES-128-GCM (CryptoHives-Scalar)            | 256B         |   1,740.22 ns |     2.299 ns |     1.920 ns |         - |
|                                                       |              |               |              |              |           |
| Decrypt · AES-128-GCM (OS)                            | 1KB          |     180.40 ns |     0.385 ns |     0.341 ns |         - |
| Decrypt · AES-128-GCM (CryptoHives-AES-NI+PClMulV256) | 1KB          |     201.47 ns |     0.533 ns |     0.472 ns |         - |
| Decrypt · AES-128-GCM (CryptoHives-AES-NI+PClMul)     | 1KB          |     245.09 ns |     0.818 ns |     0.725 ns |         - |
| Decrypt · AES-128-GCM (BouncyCastle)                  | 1KB          |   3,664.41 ns |     7.978 ns |     6.229 ns |    1624 B |
| Decrypt · AES-128-GCM (CryptoHives-Scalar)            | 1KB          |   6,686.65 ns |    13.904 ns |    12.326 ns |         - |
|                                                       |              |               |              |              |           |
| Encrypt · AES-128-GCM (OS)                            | 1KB          |     174.30 ns |     2.041 ns |     1.810 ns |         - |
| Encrypt · AES-128-GCM (CryptoHives-AES-NI+PClMulV256) | 1KB          |     175.61 ns |     0.510 ns |     0.426 ns |         - |
| Encrypt · AES-128-GCM (CryptoHives-AES-NI+PClMul)     | 1KB          |     201.40 ns |     0.948 ns |     0.791 ns |         - |
| Encrypt · AES-128-GCM (BouncyCastle)                  | 1KB          |   3,551.54 ns |    13.848 ns |    11.564 ns |    1608 B |
| Encrypt · AES-128-GCM (CryptoHives-Scalar)            | 1KB          |   6,707.06 ns |     8.780 ns |     7.332 ns |         - |
|                                                       |              |               |              |              |           |
| Decrypt · AES-128-GCM (OS)                            | 8KB          |     720.50 ns |     0.783 ns |     0.694 ns |         - |
| Decrypt · AES-128-GCM (CryptoHives-AES-NI+PClMulV256) | 8KB          |   1,031.76 ns |     2.526 ns |     1.972 ns |         - |
| Decrypt · AES-128-GCM (CryptoHives-AES-NI+PClMul)     | 8KB          |   1,381.41 ns |     2.468 ns |     2.188 ns |         - |
| Decrypt · AES-128-GCM (BouncyCastle)                  | 8KB          |  26,004.86 ns |    95.608 ns |    79.837 ns |    1624 B |
| Decrypt · AES-128-GCM (CryptoHives-Scalar)            | 8KB          |  50,626.62 ns |   180.164 ns |   150.445 ns |         - |
|                                                       |              |               |              |              |           |
| Encrypt · AES-128-GCM (OS)                            | 8KB          |     674.59 ns |     0.875 ns |     0.683 ns |         - |
| Encrypt · AES-128-GCM (CryptoHives-AES-NI+PClMulV256) | 8KB          |   1,110.72 ns |     2.347 ns |     1.960 ns |         - |
| Encrypt · AES-128-GCM (CryptoHives-AES-NI+PClMul)     | 8KB          |   1,311.48 ns |     6.201 ns |     5.178 ns |         - |
| Encrypt · AES-128-GCM (BouncyCastle)                  | 8KB          |  25,873.57 ns |    52.703 ns |    46.719 ns |    1608 B |
| Encrypt · AES-128-GCM (CryptoHives-Scalar)            | 8KB          |  50,534.00 ns |   105.653 ns |    88.225 ns |         - |
|                                                       |              |               |              |              |           |
| Decrypt · AES-128-GCM (OS)                            | 128KB        |  10,989.52 ns |    25.923 ns |    22.980 ns |         - |
| Decrypt · AES-128-GCM (CryptoHives-AES-NI+PClMulV256) | 128KB        |  16,077.19 ns |   195.611 ns |   182.975 ns |         - |
| Decrypt · AES-128-GCM (CryptoHives-AES-NI+PClMul)     | 128KB        |  20,908.53 ns |    32.672 ns |    27.283 ns |         - |
| Decrypt · AES-128-GCM (BouncyCastle)                  | 128KB        | 413,631.25 ns |   547.057 ns |   427.106 ns |    1624 B |
| Decrypt · AES-128-GCM (CryptoHives-Scalar)            | 128KB        | 805,874.02 ns | 1,574.515 ns | 1,395.767 ns |         - |
|                                                       |              |               |              |              |           |
| Encrypt · AES-128-GCM (OS)                            | 128KB        |  10,054.42 ns |    17.991 ns |    15.948 ns |         - |
| Encrypt · AES-128-GCM (CryptoHives-AES-NI+PClMulV256) | 128KB        |  17,132.86 ns |    42.073 ns |    37.297 ns |         - |
| Encrypt · AES-128-GCM (CryptoHives-AES-NI+PClMul)     | 128KB        |  20,491.74 ns |    71.557 ns |    66.934 ns |         - |
| Encrypt · AES-128-GCM (BouncyCastle)                  | 128KB        | 411,858.26 ns |   807.971 ns |   674.692 ns |    1608 B |
| Encrypt · AES-128-GCM (CryptoHives-Scalar)            | 128KB        | 837,294.05 ns | 4,186.374 ns | 3,495.812 ns |         - |