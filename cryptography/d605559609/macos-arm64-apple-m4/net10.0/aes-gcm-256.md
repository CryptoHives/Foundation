| Description                                       | TestDataSize | Mean          | Error        | StdDev       | Allocated |
|-------------------------------------------------- |------------- |--------------:|-------------:|-------------:|----------:|
| Decrypt · AES-256-GCM (CryptoHives-ARM-AES+PMULL) | 17B          |      82.48 ns |     0.779 ns |     0.651 ns |         - |
| Decrypt · AES-256-GCM (CryptoHives-Scalar)        | 17B          |     388.47 ns |     0.340 ns |     0.302 ns |         - |
| Decrypt · AES-256-GCM (BouncyCastle)              | 17B          |     589.27 ns |     3.740 ns |     3.316 ns |    1744 B |
| Decrypt · AES-256-GCM (OS)                        | 17B          |   1,945.16 ns |    11.650 ns |    10.327 ns |         - |
|                                                   |              |               |              |              |           |
| Encrypt · AES-256-GCM (CryptoHives-ARM-AES+PMULL) | 17B          |      55.66 ns |     0.083 ns |     0.073 ns |         - |
| Encrypt · AES-256-GCM (CryptoHives-Scalar)        | 17B          |     352.75 ns |     0.271 ns |     0.226 ns |         - |
| Encrypt · AES-256-GCM (BouncyCastle)              | 17B          |     513.95 ns |     0.645 ns |     0.572 ns |    1728 B |
| Encrypt · AES-256-GCM (OS)                        | 17B          |   1,721.01 ns |     6.639 ns |     5.886 ns |         - |
|                                                   |              |               |              |              |           |
| Decrypt · AES-256-GCM (CryptoHives-ARM-AES+PMULL) | 65B          |      91.68 ns |     1.510 ns |     1.412 ns |         - |
| Decrypt · AES-256-GCM (CryptoHives-Scalar)        | 65B          |     695.08 ns |    13.746 ns |    13.500 ns |         - |
| Decrypt · AES-256-GCM (BouncyCastle)              | 65B          |     830.56 ns |     5.707 ns |     4.456 ns |    1744 B |
| Decrypt · AES-256-GCM (OS)                        | 65B          |   1,927.44 ns |    17.802 ns |    16.652 ns |         - |
|                                                   |              |               |              |              |           |
| Encrypt · AES-256-GCM (CryptoHives-ARM-AES+PMULL) | 65B          |      65.71 ns |     0.036 ns |     0.030 ns |         - |
| Encrypt · AES-256-GCM (CryptoHives-Scalar)        | 65B          |     659.47 ns |     1.110 ns |     1.038 ns |         - |
| Encrypt · AES-256-GCM (BouncyCastle)              | 65B          |     770.32 ns |     0.855 ns |     0.758 ns |    1728 B |
| Encrypt · AES-256-GCM (OS)                        | 65B          |   1,733.34 ns |     9.226 ns |     8.179 ns |         - |
|                                                   |              |               |              |              |           |
| Decrypt · AES-256-GCM (CryptoHives-ARM-AES+PMULL) | 128B         |      95.89 ns |     0.259 ns |     0.216 ns |         - |
| Decrypt · AES-256-GCM (CryptoHives-Scalar)        | 128B         |     983.93 ns |     1.982 ns |     1.655 ns |         - |
| Decrypt · AES-256-GCM (BouncyCastle)              | 128B         |   1,077.43 ns |     5.317 ns |     4.151 ns |    1744 B |
| Decrypt · AES-256-GCM (OS)                        | 128B         |   1,975.24 ns |    30.708 ns |    31.534 ns |         - |
|                                                   |              |               |              |              |           |
| Encrypt · AES-256-GCM (CryptoHives-ARM-AES+PMULL) | 128B         |      69.74 ns |     0.120 ns |     0.100 ns |         - |
| Encrypt · AES-256-GCM (CryptoHives-Scalar)        | 128B         |     950.93 ns |     0.966 ns |     0.856 ns |         - |
| Encrypt · AES-256-GCM (BouncyCastle)              | 128B         |   1,036.38 ns |     0.990 ns |     0.878 ns |    1728 B |
| Encrypt · AES-256-GCM (OS)                        | 128B         |   1,746.74 ns |     5.614 ns |     4.976 ns |         - |
|                                                   |              |               |              |              |           |
| Decrypt · AES-256-GCM (CryptoHives-ARM-AES+PMULL) | 152B         |     131.90 ns |     1.400 ns |     1.309 ns |         - |
| Decrypt · AES-256-GCM (CryptoHives-Scalar)        | 152B         |   1,211.38 ns |    23.739 ns |    21.044 ns |         - |
| Decrypt · AES-256-GCM (BouncyCastle)              | 152B         |   1,223.30 ns |     2.605 ns |     2.437 ns |    1744 B |
| Decrypt · AES-256-GCM (OS)                        | 152B         |   1,950.96 ns |     9.342 ns |     7.801 ns |         - |
|                                                   |              |               |              |              |           |
| Encrypt · AES-256-GCM (CryptoHives-ARM-AES+PMULL) | 152B         |      91.44 ns |     0.861 ns |     0.719 ns |         - |
| Encrypt · AES-256-GCM (CryptoHives-Scalar)        | 152B         |   1,152.18 ns |     1.932 ns |     1.713 ns |         - |
| Encrypt · AES-256-GCM (BouncyCastle)              | 152B         |   1,196.97 ns |     0.614 ns |     0.479 ns |    1728 B |
| Encrypt · AES-256-GCM (OS)                        | 152B         |   1,746.90 ns |     7.388 ns |     6.910 ns |         - |
|                                                   |              |               |              |              |           |
| Decrypt · AES-256-GCM (CryptoHives-ARM-AES+PMULL) | 256B         |     142.29 ns |     1.776 ns |     1.661 ns |         - |
| Decrypt · AES-256-GCM (BouncyCastle)              | 256B         |   1,721.17 ns |    13.390 ns |    12.525 ns |    1744 B |
| Decrypt · AES-256-GCM (CryptoHives-Scalar)        | 256B         |   1,817.65 ns |    23.773 ns |    22.237 ns |         - |
| Decrypt · AES-256-GCM (OS)                        | 256B         |   1,985.99 ns |    18.152 ns |    14.172 ns |         - |
|                                                   |              |               |              |              |           |
| Encrypt · AES-256-GCM (CryptoHives-ARM-AES+PMULL) | 256B         |      97.52 ns |     0.401 ns |     0.375 ns |         - |
| Encrypt · AES-256-GCM (BouncyCastle)              | 256B         |   1,712.58 ns |     1.117 ns |     0.872 ns |    1728 B |
| Encrypt · AES-256-GCM (CryptoHives-Scalar)        | 256B         |   1,762.01 ns |     1.835 ns |     1.433 ns |         - |
| Encrypt · AES-256-GCM (OS)                        | 256B         |   1,768.99 ns |    10.284 ns |     8.588 ns |         - |
|                                                   |              |               |              |              |           |
| Decrypt · AES-256-GCM (CryptoHives-ARM-AES+PMULL) | 1KB          |     381.76 ns |     3.743 ns |     3.318 ns |         - |
| Decrypt · AES-256-GCM (OS)                        | 1KB          |   2,130.43 ns |    18.904 ns |    17.683 ns |         - |
| Decrypt · AES-256-GCM (BouncyCastle)              | 1KB          |   5,544.76 ns |    38.176 ns |    31.879 ns |    1744 B |
| Decrypt · AES-256-GCM (CryptoHives-Scalar)        | 1KB          |   6,714.16 ns |    59.447 ns |    52.698 ns |         - |
|                                                   |              |               |              |              |           |
| Encrypt · AES-256-GCM (CryptoHives-ARM-AES+PMULL) | 1KB          |     329.33 ns |     2.696 ns |     2.105 ns |         - |
| Encrypt · AES-256-GCM (OS)                        | 1KB          |   1,897.82 ns |    13.235 ns |    12.380 ns |         - |
| Encrypt · AES-256-GCM (BouncyCastle)              | 1KB          |   5,723.52 ns |    73.481 ns |    68.734 ns |    1728 B |
| Encrypt · AES-256-GCM (CryptoHives-Scalar)        | 1KB          |   6,359.52 ns |     0.968 ns |     0.756 ns |         - |
|                                                   |              |               |              |              |           |
| Decrypt · AES-256-GCM (CryptoHives-ARM-AES+PMULL) | 8KB          |   2,503.36 ns |    44.046 ns |    47.129 ns |         - |
| Decrypt · AES-256-GCM (OS)                        | 8KB          |   3,100.30 ns |    16.277 ns |    15.226 ns |         - |
| Decrypt · AES-256-GCM (BouncyCastle)              | 8KB          |  40,528.22 ns |    90.395 ns |    80.133 ns |    1744 B |
| Decrypt · AES-256-GCM (CryptoHives-Scalar)        | 8KB          |  50,836.69 ns |    80.824 ns |    63.102 ns |         - |
|                                                   |              |               |              |              |           |
| Encrypt · AES-256-GCM (CryptoHives-ARM-AES+PMULL) | 8KB          |   2,366.23 ns |    31.961 ns |    28.333 ns |         - |
| Encrypt · AES-256-GCM (OS)                        | 8KB          |   2,958.40 ns |    11.201 ns |    10.478 ns |         - |
| Encrypt · AES-256-GCM (BouncyCastle)              | 8KB          |  42,887.89 ns |   219.918 ns |   183.641 ns |    1728 B |
| Encrypt · AES-256-GCM (CryptoHives-Scalar)        | 8KB          |  49,860.05 ns |    74.414 ns |    62.139 ns |         - |
|                                                   |              |               |              |              |           |
| Decrypt · AES-256-GCM (OS)                        | 128KB        |  20,848.30 ns |   249.029 ns |   207.950 ns |         - |
| Decrypt · AES-256-GCM (CryptoHives-ARM-AES+PMULL) | 128KB        |  37,293.66 ns |   743.711 ns |   763.736 ns |         - |
| Decrypt · AES-256-GCM (BouncyCastle)              | 128KB        | 638,803.22 ns | 8,642.407 ns | 8,084.113 ns |    1744 B |
| Decrypt · AES-256-GCM (CryptoHives-Scalar)        | 128KB        | 807,584.43 ns | 3,524.642 ns | 2,943.236 ns |         - |
|                                                   |              |               |              |              |           |
| Encrypt · AES-256-GCM (OS)                        | 128KB        |  21,823.57 ns |   421.318 ns |   394.102 ns |         - |
| Encrypt · AES-256-GCM (CryptoHives-ARM-AES+PMULL) | 128KB        |  37,399.05 ns |   735.375 ns |   875.412 ns |         - |
| Encrypt · AES-256-GCM (BouncyCastle)              | 128KB        | 675,000.81 ns |   384.582 ns |   321.144 ns |    1728 B |
| Encrypt · AES-256-GCM (CryptoHives-Scalar)        | 128KB        | 794,330.66 ns |   282.618 ns |   235.999 ns |         - |