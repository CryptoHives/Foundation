| Description                                       | TestDataSize | Mean          | Error        | StdDev       | Allocated |
|-------------------------------------------------- |------------- |--------------:|-------------:|-------------:|----------:|
| Decrypt · AES-128-GCM (CryptoHives-ARM-AES+PMULL) | 17B          |      84.72 ns |     0.106 ns |     0.099 ns |         - |
| Decrypt · AES-128-GCM (CryptoHives-Scalar)        | 17B          |     348.90 ns |     3.648 ns |     3.412 ns |         - |
| Decrypt · AES-128-GCM (BouncyCastle)              | 17B          |     495.57 ns |     2.158 ns |     2.018 ns |    1536 B |
| Decrypt · AES-128-GCM (OS)                        | 17B          |   1,866.72 ns |    24.078 ns |    21.344 ns |         - |
|                                                   |              |               |              |              |           |
| Encrypt · AES-128-GCM (CryptoHives-ARM-AES+PMULL) | 17B          |      52.64 ns |     1.035 ns |     1.381 ns |         - |
| Encrypt · AES-128-GCM (CryptoHives-Scalar)        | 17B          |     318.85 ns |     0.814 ns |     0.721 ns |         - |
| Encrypt · AES-128-GCM (BouncyCastle)              | 17B          |     428.71 ns |     0.359 ns |     0.300 ns |    1520 B |
| Encrypt · AES-128-GCM (OS)                        | 17B          |   1,729.95 ns |     6.705 ns |     5.944 ns |         - |
|                                                   |              |               |              |              |           |
| Decrypt · AES-128-GCM (CryptoHives-ARM-AES+PMULL) | 65B          |      91.37 ns |     0.618 ns |     0.578 ns |         - |
| Decrypt · AES-128-GCM (CryptoHives-Scalar)        | 65B          |     610.53 ns |     6.867 ns |     6.423 ns |         - |
| Decrypt · AES-128-GCM (BouncyCastle)              | 65B          |     683.71 ns |     2.134 ns |     1.997 ns |    1536 B |
| Decrypt · AES-128-GCM (OS)                        | 65B          |   1,817.52 ns |    12.703 ns |    11.261 ns |         - |
|                                                   |              |               |              |              |           |
| Encrypt · AES-128-GCM (CryptoHives-ARM-AES+PMULL) | 65B          |      62.96 ns |     0.190 ns |     0.169 ns |         - |
| Encrypt · AES-128-GCM (CryptoHives-Scalar)        | 65B          |     588.20 ns |     5.679 ns |     4.434 ns |         - |
| Encrypt · AES-128-GCM (BouncyCastle)              | 65B          |     631.12 ns |     1.139 ns |     1.065 ns |    1520 B |
| Encrypt · AES-128-GCM (OS)                        | 65B          |   1,745.71 ns |    23.256 ns |    20.615 ns |         - |
|                                                   |              |               |              |              |           |
| Decrypt · AES-128-GCM (CryptoHives-ARM-AES+PMULL) | 128B         |      91.25 ns |     0.541 ns |     0.479 ns |         - |
| Decrypt · AES-128-GCM (CryptoHives-Scalar)        | 128B         |     881.84 ns |     5.333 ns |     4.728 ns |         - |
| Decrypt · AES-128-GCM (BouncyCastle)              | 128B         |     906.97 ns |     7.130 ns |     5.954 ns |    1536 B |
| Decrypt · AES-128-GCM (OS)                        | 128B         |   1,896.98 ns |    10.996 ns |     9.182 ns |         - |
|                                                   |              |               |              |              |           |
| Encrypt · AES-128-GCM (CryptoHives-ARM-AES+PMULL) | 128B         |      64.49 ns |     0.742 ns |     0.694 ns |         - |
| Encrypt · AES-128-GCM (BouncyCastle)              | 128B         |     854.63 ns |     3.266 ns |     3.055 ns |    1520 B |
| Encrypt · AES-128-GCM (CryptoHives-Scalar)        | 128B         |     871.18 ns |    11.038 ns |     9.785 ns |         - |
| Encrypt · AES-128-GCM (OS)                        | 128B         |   1,694.86 ns |    21.339 ns |    18.917 ns |         - |
|                                                   |              |               |              |              |           |
| Decrypt · AES-128-GCM (CryptoHives-ARM-AES+PMULL) | 152B         |     118.94 ns |     0.555 ns |     0.492 ns |         - |
| Decrypt · AES-128-GCM (BouncyCastle)              | 152B         |   1,022.99 ns |     3.611 ns |     3.377 ns |    1536 B |
| Decrypt · AES-128-GCM (CryptoHives-Scalar)        | 152B         |   1,051.35 ns |     4.675 ns |     4.373 ns |         - |
| Decrypt · AES-128-GCM (OS)                        | 152B         |   1,904.57 ns |    15.293 ns |    14.305 ns |         - |
|                                                   |              |               |              |              |           |
| Encrypt · AES-128-GCM (CryptoHives-ARM-AES+PMULL) | 152B         |      84.33 ns |     0.659 ns |     0.617 ns |         - |
| Encrypt · AES-128-GCM (BouncyCastle)              | 152B         |     989.46 ns |     1.939 ns |     1.719 ns |    1520 B |
| Encrypt · AES-128-GCM (CryptoHives-Scalar)        | 152B         |   1,040.17 ns |    20.713 ns |    23.853 ns |         - |
| Encrypt · AES-128-GCM (OS)                        | 152B         |   1,670.87 ns |    31.267 ns |    29.247 ns |         - |
|                                                   |              |               |              |              |           |
| Decrypt · AES-128-GCM (CryptoHives-ARM-AES+PMULL) | 256B         |     121.21 ns |     0.813 ns |     0.721 ns |         - |
| Decrypt · AES-128-GCM (BouncyCastle)              | 256B         |   1,407.00 ns |     5.141 ns |     4.557 ns |    1536 B |
| Decrypt · AES-128-GCM (CryptoHives-Scalar)        | 256B         |   1,615.32 ns |    10.610 ns |     9.924 ns |         - |
| Decrypt · AES-128-GCM (OS)                        | 256B         |   1,921.16 ns |     7.532 ns |     6.677 ns |         - |
|                                                   |              |               |              |              |           |
| Encrypt · AES-128-GCM (CryptoHives-ARM-AES+PMULL) | 256B         |      89.10 ns |     0.642 ns |     0.600 ns |         - |
| Encrypt · AES-128-GCM (BouncyCastle)              | 256B         |   1,408.35 ns |     2.916 ns |     2.728 ns |    1520 B |
| Encrypt · AES-128-GCM (CryptoHives-Scalar)        | 256B         |   1,582.29 ns |    22.532 ns |    21.076 ns |         - |
| Encrypt · AES-128-GCM (OS)                        | 256B         |   1,725.36 ns |    14.330 ns |    13.405 ns |         - |
|                                                   |              |               |              |              |           |
| Decrypt · AES-128-GCM (CryptoHives-ARM-AES+PMULL) | 1KB          |     324.05 ns |     0.647 ns |     0.606 ns |         - |
| Decrypt · AES-128-GCM (OS)                        | 1KB          |   2,085.28 ns |     9.538 ns |     8.921 ns |         - |
| Decrypt · AES-128-GCM (BouncyCastle)              | 1KB          |   4,473.66 ns |     2.176 ns |     1.929 ns |    1536 B |
| Decrypt · AES-128-GCM (CryptoHives-Scalar)        | 1KB          |   5,779.31 ns |    26.478 ns |    24.767 ns |         - |
|                                                   |              |               |              |              |           |
| Encrypt · AES-128-GCM (CryptoHives-ARM-AES+PMULL) | 1KB          |     288.36 ns |     1.502 ns |     1.405 ns |         - |
| Encrypt · AES-128-GCM (OS)                        | 1KB          |   1,875.53 ns |    13.096 ns |    12.250 ns |         - |
| Encrypt · AES-128-GCM (BouncyCastle)              | 1KB          |   4,755.22 ns |    22.271 ns |    18.598 ns |    1520 B |
| Encrypt · AES-128-GCM (CryptoHives-Scalar)        | 1KB          |   5,443.51 ns |    16.573 ns |    15.502 ns |         - |
|                                                   |              |               |              |              |           |
| Decrypt · AES-128-GCM (CryptoHives-ARM-AES+PMULL) | 8KB          |   2,251.75 ns |    14.811 ns |    13.130 ns |         - |
| Decrypt · AES-128-GCM (OS)                        | 8KB          |   2,941.93 ns |    17.429 ns |    15.450 ns |         - |
| Decrypt · AES-128-GCM (BouncyCastle)              | 8KB          |  32,628.06 ns |    33.288 ns |    31.137 ns |    1536 B |
| Decrypt · AES-128-GCM (CryptoHives-Scalar)        | 8KB          |  44,059.84 ns |   232.449 ns |   206.060 ns |         - |
|                                                   |              |               |              |              |           |
| Encrypt · AES-128-GCM (CryptoHives-ARM-AES+PMULL) | 8KB          |   2,189.88 ns |    42.604 ns |    39.852 ns |         - |
| Encrypt · AES-128-GCM (OS)                        | 8KB          |   2,777.73 ns |    27.290 ns |    25.527 ns |         - |
| Encrypt · AES-128-GCM (BouncyCastle)              | 8KB          |  35,204.67 ns |   161.558 ns |   126.134 ns |    1520 B |
| Encrypt · AES-128-GCM (CryptoHives-Scalar)        | 8KB          |  42,468.63 ns |   275.110 ns |   243.878 ns |         - |
|                                                   |              |               |              |              |           |
| Decrypt · AES-128-GCM (OS)                        | 128KB        |  18,380.43 ns |    63.612 ns |    59.503 ns |         - |
| Decrypt · AES-128-GCM (CryptoHives-ARM-AES+PMULL) | 128KB        |  35,298.96 ns |   481.378 ns |   515.069 ns |         - |
| Decrypt · AES-128-GCM (BouncyCastle)              | 128KB        | 507,397.97 ns |   388.708 ns |   344.579 ns |    1536 B |
| Decrypt · AES-128-GCM (CryptoHives-Scalar)        | 128KB        | 688,702.07 ns | 2,949.559 ns | 2,759.019 ns |         - |
|                                                   |              |               |              |              |           |
| Encrypt · AES-128-GCM (OS)                        | 128KB        |  19,353.12 ns |   375.729 ns |   351.457 ns |         - |
| Encrypt · AES-128-GCM (CryptoHives-ARM-AES+PMULL) | 128KB        |  34,565.51 ns |   662.740 ns |   553.418 ns |         - |
| Encrypt · AES-128-GCM (BouncyCastle)              | 128KB        | 553,505.93 ns | 1,669.205 ns | 1,479.707 ns |    1520 B |
| Encrypt · AES-128-GCM (CryptoHives-Scalar)        | 128KB        | 672,995.89 ns |   424.139 ns |   354.175 ns |         - |