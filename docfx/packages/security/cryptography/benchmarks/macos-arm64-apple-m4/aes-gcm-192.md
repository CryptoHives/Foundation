| Description                                       | TestDataSize | Mean          | Error        | StdDev       | Allocated |
|-------------------------------------------------- |------------- |--------------:|-------------:|-------------:|----------:|
| Decrypt · AES-192-GCM (CryptoHives-ARM-AES+PMULL) | 17B          |      81.26 ns |     1.406 ns |     1.316 ns |         - |
| Decrypt · AES-192-GCM (CryptoHives-Scalar)        | 17B          |     372.21 ns |     1.177 ns |     1.043 ns |         - |
| Decrypt · AES-192-GCM (BouncyCastle)              | 17B          |     627.05 ns |     0.506 ns |     0.473 ns |    1640 B |
| Decrypt · AES-192-GCM (OS)                        | 17B          |   1,853.50 ns |     3.141 ns |     2.785 ns |         - |
|                                                   |              |               |              |              |           |
| Encrypt · AES-192-GCM (CryptoHives-ARM-AES+PMULL) | 17B          |      54.15 ns |     0.039 ns |     0.035 ns |         - |
| Encrypt · AES-192-GCM (CryptoHives-Scalar)        | 17B          |     336.36 ns |     0.342 ns |     0.320 ns |         - |
| Encrypt · AES-192-GCM (BouncyCastle)              | 17B          |     539.51 ns |     0.561 ns |     0.525 ns |    1624 B |
| Encrypt · AES-192-GCM (OS)                        | 17B          |   1,678.31 ns |    14.583 ns |    13.641 ns |         - |
|                                                   |              |               |              |              |           |
| Decrypt · AES-192-GCM (CryptoHives-ARM-AES+PMULL) | 65B          |     117.93 ns |     0.760 ns |     0.635 ns |         - |
| Decrypt · AES-192-GCM (CryptoHives-Scalar)        | 65B          |     656.38 ns |     0.578 ns |     0.540 ns |         - |
| Decrypt · AES-192-GCM (BouncyCastle)              | 65B          |     844.67 ns |     0.639 ns |     0.598 ns |    1640 B |
| Decrypt · AES-192-GCM (OS)                        | 65B          |   1,873.54 ns |     8.574 ns |     7.159 ns |         - |
|                                                   |              |               |              |              |           |
| Encrypt · AES-192-GCM (CryptoHives-ARM-AES+PMULL) | 65B          |      86.08 ns |     0.234 ns |     0.219 ns |         - |
| Encrypt · AES-192-GCM (CryptoHives-Scalar)        | 65B          |     620.25 ns |     0.846 ns |     0.792 ns |         - |
| Encrypt · AES-192-GCM (BouncyCastle)              | 65B          |     773.21 ns |     1.531 ns |     1.432 ns |    1624 B |
| Encrypt · AES-192-GCM (OS)                        | 65B          |   1,690.75 ns |     4.507 ns |     3.518 ns |         - |
|                                                   |              |               |              |              |           |
| Decrypt · AES-192-GCM (CryptoHives-ARM-AES+PMULL) | 128B         |     158.12 ns |     0.952 ns |     0.890 ns |         - |
| Decrypt · AES-192-GCM (CryptoHives-Scalar)        | 128B         |     935.31 ns |     2.986 ns |     2.793 ns |         - |
| Decrypt · AES-192-GCM (BouncyCastle)              | 128B         |   1,073.31 ns |     2.465 ns |     2.306 ns |    1640 B |
| Decrypt · AES-192-GCM (OS)                        | 128B         |   1,896.89 ns |    11.527 ns |    10.782 ns |         - |
|                                                   |              |               |              |              |           |
| Encrypt · AES-192-GCM (CryptoHives-ARM-AES+PMULL) | 128B         |     119.08 ns |     0.452 ns |     0.422 ns |         - |
| Encrypt · AES-192-GCM (CryptoHives-Scalar)        | 128B         |     900.42 ns |     2.409 ns |     2.254 ns |         - |
| Encrypt · AES-192-GCM (BouncyCastle)              | 128B         |   1,018.57 ns |     2.160 ns |     1.804 ns |    1624 B |
| Encrypt · AES-192-GCM (OS)                        | 128B         |   1,701.93 ns |     2.629 ns |     2.331 ns |         - |
|                                                   |              |               |              |              |           |
| Decrypt · AES-192-GCM (CryptoHives-ARM-AES+PMULL) | 152B         |     193.29 ns |     0.889 ns |     0.832 ns |         - |
| Decrypt · AES-192-GCM (CryptoHives-Scalar)        | 152B         |   1,134.08 ns |     1.216 ns |     1.137 ns |         - |
| Decrypt · AES-192-GCM (BouncyCastle)              | 152B         |   1,210.48 ns |     1.592 ns |     1.329 ns |    1640 B |
| Decrypt · AES-192-GCM (OS)                        | 152B         |   1,873.27 ns |     9.727 ns |     9.098 ns |         - |
|                                                   |              |               |              |              |           |
| Encrypt · AES-192-GCM (CryptoHives-ARM-AES+PMULL) | 152B         |     150.11 ns |     0.527 ns |     0.493 ns |         - |
| Encrypt · AES-192-GCM (CryptoHives-Scalar)        | 152B         |   1,092.92 ns |     1.923 ns |     1.799 ns |         - |
| Encrypt · AES-192-GCM (BouncyCastle)              | 152B         |   1,173.63 ns |     4.256 ns |     3.554 ns |    1624 B |
| Encrypt · AES-192-GCM (OS)                        | 152B         |   1,681.89 ns |     4.246 ns |     3.972 ns |         - |
|                                                   |              |               |              |              |           |
| Decrypt · AES-192-GCM (CryptoHives-ARM-AES+PMULL) | 256B         |     260.53 ns |     1.533 ns |     1.434 ns |         - |
| Decrypt · AES-192-GCM (BouncyCastle)              | 256B         |   1,642.18 ns |     1.102 ns |     1.031 ns |    1640 B |
| Decrypt · AES-192-GCM (CryptoHives-Scalar)        | 256B         |   1,712.19 ns |     1.721 ns |     1.437 ns |         - |
| Decrypt · AES-192-GCM (OS)                        | 256B         |   1,913.80 ns |     9.219 ns |     8.173 ns |         - |
|                                                   |              |               |              |              |           |
| Encrypt · AES-192-GCM (CryptoHives-ARM-AES+PMULL) | 256B         |     218.10 ns |     0.945 ns |     0.884 ns |         - |
| Encrypt · AES-192-GCM (BouncyCastle)              | 256B         |   1,628.35 ns |     1.514 ns |     1.416 ns |    1624 B |
| Encrypt · AES-192-GCM (CryptoHives-Scalar)        | 256B         |   1,663.31 ns |     1.029 ns |     0.962 ns |         - |
| Encrypt · AES-192-GCM (OS)                        | 256B         |   1,738.67 ns |     6.181 ns |     5.479 ns |         - |
|                                                   |              |               |              |              |           |
| Decrypt · AES-192-GCM (CryptoHives-ARM-AES+PMULL) | 1KB          |     852.17 ns |     2.621 ns |     2.323 ns |         - |
| Decrypt · AES-192-GCM (OS)                        | 1KB          |   2,032.43 ns |     5.348 ns |     5.002 ns |         - |
| Decrypt · AES-192-GCM (BouncyCastle)              | 1KB          |   5,040.78 ns |     2.759 ns |     2.446 ns |    1640 B |
| Decrypt · AES-192-GCM (CryptoHives-Scalar)        | 1KB          |   6,145.22 ns |     3.365 ns |     3.148 ns |         - |
|                                                   |              |               |              |              |           |
| Encrypt · AES-192-GCM (CryptoHives-ARM-AES+PMULL) | 1KB          |     809.61 ns |     4.194 ns |     3.924 ns |         - |
| Encrypt · AES-192-GCM (OS)                        | 1KB          |   1,863.31 ns |     7.608 ns |     7.117 ns |         - |
| Encrypt · AES-192-GCM (BouncyCastle)              | 1KB          |   5,283.23 ns |     6.071 ns |     5.070 ns |    1624 B |
| Encrypt · AES-192-GCM (CryptoHives-Scalar)        | 1KB          |   6,009.21 ns |    13.398 ns |    12.532 ns |         - |
|                                                   |              |               |              |              |           |
| Decrypt · AES-192-GCM (OS)                        | 8KB          |   2,989.64 ns |     9.764 ns |     8.153 ns |         - |
| Decrypt · AES-192-GCM (CryptoHives-ARM-AES+PMULL) | 8KB          |   6,485.20 ns |    73.022 ns |    68.305 ns |         - |
| Decrypt · AES-192-GCM (BouncyCastle)              | 8KB          |  36,287.28 ns |   106.499 ns |    99.619 ns |    1640 B |
| Decrypt · AES-192-GCM (CryptoHives-Scalar)        | 8KB          |  47,245.86 ns |   126.774 ns |   118.584 ns |         - |
|                                                   |              |               |              |              |           |
| Encrypt · AES-192-GCM (OS)                        | 8KB          |   2,859.48 ns |    20.931 ns |    19.579 ns |         - |
| Encrypt · AES-192-GCM (CryptoHives-ARM-AES+PMULL) | 8KB          |   6,288.91 ns |    25.372 ns |    23.733 ns |         - |
| Encrypt · AES-192-GCM (BouncyCastle)              | 8KB          |  38,844.80 ns |   136.405 ns |   127.593 ns |    1624 B |
| Encrypt · AES-192-GCM (CryptoHives-Scalar)        | 8KB          |  47,101.84 ns |   108.217 ns |   101.227 ns |         - |
|                                                   |              |               |              |              |           |
| Decrypt · AES-192-GCM (OS)                        | 128KB        |  19,697.04 ns |    62.210 ns |    58.191 ns |         - |
| Decrypt · AES-192-GCM (CryptoHives-ARM-AES+PMULL) | 128KB        | 102,333.71 ns |   892.119 ns |   834.489 ns |         - |
| Decrypt · AES-192-GCM (BouncyCastle)              | 128KB        | 573,003.80 ns |   635.423 ns |   563.286 ns |    1640 B |
| Decrypt · AES-192-GCM (CryptoHives-Scalar)        | 128KB        | 752,273.73 ns | 1,544.739 ns | 1,444.949 ns |         - |
|                                                   |              |               |              |              |           |
| Encrypt · AES-192-GCM (OS)                        | 128KB        |  20,766.06 ns |    25.026 ns |    20.898 ns |         - |
| Encrypt · AES-192-GCM (CryptoHives-ARM-AES+PMULL) | 128KB        | 104,094.41 ns | 2,037.722 ns | 2,502.505 ns |         - |
| Encrypt · AES-192-GCM (BouncyCastle)              | 128KB        | 617,558.91 ns | 1,441.692 ns | 1,278.023 ns |    1624 B |
| Encrypt · AES-192-GCM (CryptoHives-Scalar)        | 128KB        | 751,556.15 ns |   224.805 ns |   210.283 ns |         - |