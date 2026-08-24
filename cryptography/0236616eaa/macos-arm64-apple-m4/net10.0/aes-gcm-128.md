| Description                                       | TestDataSize | Mean          | Error        | StdDev       | Median        | Allocated |
|-------------------------------------------------- |------------- |--------------:|-------------:|-------------:|--------------:|----------:|
| Decrypt · AES-128-GCM (CryptoHives-Scalar)        | 17B          |     371.33 ns |     7.135 ns |    13.575 ns |     368.98 ns |         - |
| Decrypt · AES-128-GCM (CryptoHives-ARM-AES+PMULL) | 17B          |     378.73 ns |     4.489 ns |     4.199 ns |     378.40 ns |         - |
| Decrypt · AES-128-GCM (BouncyCastle)              | 17B          |     495.98 ns |     0.506 ns |     0.449 ns |     495.95 ns |    1536 B |
| Decrypt · AES-128-GCM (OS)                        | 17B          |   1,867.98 ns |    17.799 ns |    16.650 ns |   1,865.40 ns |         - |
|                                                   |              |               |              |              |               |           |
| Encrypt · AES-128-GCM (CryptoHives-ARM-AES+PMULL) | 17B          |      53.00 ns |     0.066 ns |     0.062 ns |      53.00 ns |         - |
| Encrypt · AES-128-GCM (CryptoHives-Scalar)        | 17B          |     322.99 ns |     0.073 ns |     0.068 ns |     322.99 ns |         - |
| Encrypt · AES-128-GCM (BouncyCastle)              | 17B          |     426.17 ns |     3.665 ns |     3.060 ns |     427.23 ns |    1520 B |
| Encrypt · AES-128-GCM (OS)                        | 17B          |   1,680.19 ns |    11.381 ns |    10.646 ns |   1,684.73 ns |         - |
|                                                   |              |               |              |              |               |           |
| Decrypt · AES-128-GCM (CryptoHives-ARM-AES+PMULL) | 65B          |     115.86 ns |     0.230 ns |     0.204 ns |     115.85 ns |         - |
| Decrypt · AES-128-GCM (CryptoHives-Scalar)        | 65B          |     637.30 ns |     0.974 ns |     0.911 ns |     637.39 ns |         - |
| Decrypt · AES-128-GCM (BouncyCastle)              | 65B          |     691.29 ns |     0.364 ns |     0.341 ns |     691.44 ns |    1536 B |
| Decrypt · AES-128-GCM (OS)                        | 65B          |   1,901.86 ns |     9.014 ns |     8.432 ns |   1,904.17 ns |         - |
|                                                   |              |               |              |              |               |           |
| Encrypt · AES-128-GCM (CryptoHives-ARM-AES+PMULL) | 65B          |      83.89 ns |     0.433 ns |     0.405 ns |      83.72 ns |         - |
| Encrypt · AES-128-GCM (CryptoHives-Scalar)        | 65B          |     589.01 ns |     0.458 ns |     0.382 ns |     589.07 ns |         - |
| Encrypt · AES-128-GCM (BouncyCastle)              | 65B          |     632.91 ns |     0.429 ns |     0.380 ns |     632.88 ns |    1520 B |
| Encrypt · AES-128-GCM (OS)                        | 65B          |   1,694.97 ns |     3.887 ns |     3.636 ns |   1,695.06 ns |         - |
|                                                   |              |               |              |              |               |           |
| Decrypt · AES-128-GCM (CryptoHives-ARM-AES+PMULL) | 128B         |     153.64 ns |     0.391 ns |     0.365 ns |     153.82 ns |         - |
| Decrypt · AES-128-GCM (CryptoHives-Scalar)        | 128B         |     906.42 ns |     0.745 ns |     0.697 ns |     906.19 ns |         - |
| Decrypt · AES-128-GCM (BouncyCastle)              | 128B         |     992.76 ns |    17.822 ns |    16.670 ns |     993.28 ns |    1536 B |
| Decrypt · AES-128-GCM (OS)                        | 128B         |   2,058.29 ns |    40.186 ns |    52.253 ns |   2,065.72 ns |         - |
|                                                   |              |               |              |              |               |           |
| Encrypt · AES-128-GCM (CryptoHives-ARM-AES+PMULL) | 128B         |     117.93 ns |     0.304 ns |     0.284 ns |     117.95 ns |         - |
| Encrypt · AES-128-GCM (CryptoHives-Scalar)        | 128B         |     852.65 ns |     0.315 ns |     0.295 ns |     852.67 ns |         - |
| Encrypt · AES-128-GCM (BouncyCastle)              | 128B         |     930.41 ns |    17.874 ns |    21.278 ns |     925.17 ns |    1520 B |
| Encrypt · AES-128-GCM (OS)                        | 128B         |   1,962.16 ns |    38.983 ns |    95.626 ns |   1,930.35 ns |         - |
|                                                   |              |               |              |              |               |           |
| Decrypt · AES-128-GCM (CryptoHives-ARM-AES+PMULL) | 152B         |     193.09 ns |     1.274 ns |     1.192 ns |     193.32 ns |         - |
| Decrypt · AES-128-GCM (BouncyCastle)              | 152B         |   1,232.34 ns |    24.280 ns |    41.229 ns |   1,236.09 ns |    1536 B |
| Decrypt · AES-128-GCM (CryptoHives-Scalar)        | 152B         |   1,267.45 ns |    25.536 ns |    73.267 ns |   1,287.74 ns |         - |
| Decrypt · AES-128-GCM (OS)                        | 152B         |   9,129.81 ns |    71.158 ns |    66.562 ns |   9,153.55 ns |         - |
|                                                   |              |               |              |              |               |           |
| Encrypt · AES-128-GCM (CryptoHives-ARM-AES+PMULL) | 152B         |     151.29 ns |     0.038 ns |     0.032 ns |     151.28 ns |         - |
| Encrypt · AES-128-GCM (CryptoHives-Scalar)        | 152B         |   1,247.76 ns |    21.262 ns |    32.470 ns |   1,243.46 ns |         - |
| Encrypt · AES-128-GCM (OS)                        | 152B         |   1,704.31 ns |     6.524 ns |     5.783 ns |   1,703.45 ns |         - |
| Encrypt · AES-128-GCM (BouncyCastle)              | 152B         |   3,658.81 ns |   584.238 ns | 1,722.639 ns |   4,654.80 ns |    1520 B |
|                                                   |              |               |              |              |               |           |
| Decrypt · AES-128-GCM (CryptoHives-ARM-AES+PMULL) | 256B         |   1,261.10 ns |    12.599 ns |    11.785 ns |   1,263.99 ns |         - |
| Decrypt · AES-128-GCM (BouncyCastle)              | 256B         |   6,615.57 ns |    35.886 ns |    29.966 ns |   6,606.37 ns |    1536 B |
| Decrypt · AES-128-GCM (CryptoHives-Scalar)        | 256B         |   7,671.62 ns |     5.166 ns |     4.832 ns |   7,671.15 ns |         - |
| Decrypt · AES-128-GCM (OS)                        | 256B         |   9,084.28 ns |    54.564 ns |    45.563 ns |   9,091.74 ns |         - |
|                                                   |              |               |              |              |               |           |
| Encrypt · AES-128-GCM (CryptoHives-ARM-AES+PMULL) | 256B         |     211.78 ns |     3.058 ns |     2.711 ns |     211.34 ns |         - |
| Encrypt · AES-128-GCM (BouncyCastle)              | 256B         |   1,398.80 ns |     0.610 ns |     0.476 ns |   1,398.71 ns |    1520 B |
| Encrypt · AES-128-GCM (CryptoHives-Scalar)        | 256B         |   1,570.45 ns |     0.483 ns |     0.404 ns |   1,570.59 ns |         - |
| Encrypt · AES-128-GCM (OS)                        | 256B         |   1,735.89 ns |     6.720 ns |     6.286 ns |   1,736.36 ns |         - |
|                                                   |              |               |              |              |               |           |
| Decrypt · AES-128-GCM (OS)                        | 1KB          |   2,063.30 ns |     8.979 ns |     7.959 ns |   2,064.50 ns |         - |
| Decrypt · AES-128-GCM (CryptoHives-ARM-AES+PMULL) | 1KB          |   4,192.50 ns |    13.397 ns |    12.531 ns |   4,191.01 ns |         - |
| Decrypt · AES-128-GCM (BouncyCastle)              | 1KB          |   4,391.59 ns |     2.682 ns |     2.509 ns |   4,391.62 ns |    1536 B |
| Decrypt · AES-128-GCM (CryptoHives-Scalar)        | 1KB          |   5,873.75 ns |    81.572 ns |   189.055 ns |   5,810.27 ns |         - |
|                                                   |              |               |              |              |               |           |
| Encrypt · AES-128-GCM (CryptoHives-ARM-AES+PMULL) | 1KB          |     789.28 ns |    15.181 ns |    14.909 ns |     796.26 ns |         - |
| Encrypt · AES-128-GCM (OS)                        | 1KB          |   1,862.37 ns |     5.195 ns |     4.860 ns |   1,862.98 ns |         - |
| Encrypt · AES-128-GCM (BouncyCastle)              | 1KB          |   4,661.30 ns |     0.755 ns |     0.707 ns |   4,661.44 ns |    1520 B |
| Encrypt · AES-128-GCM (CryptoHives-Scalar)        | 1KB          |   5,682.06 ns |     0.968 ns |     0.905 ns |   5,682.28 ns |         - |
|                                                   |              |               |              |              |               |           |
| Decrypt · AES-128-GCM (OS)                        | 8KB          |   2,919.63 ns |    10.428 ns |     9.754 ns |   2,918.23 ns |         - |
| Decrypt · AES-128-GCM (CryptoHives-ARM-AES+PMULL) | 8KB          |   6,600.55 ns |    16.915 ns |    15.823 ns |   6,594.42 ns |         - |
| Decrypt · AES-128-GCM (BouncyCastle)              | 8KB          |  32,237.24 ns |    26.727 ns |    23.693 ns |  32,239.23 ns |    1536 B |
| Decrypt · AES-128-GCM (CryptoHives-Scalar)        | 8KB          |  45,606.19 ns |   819.490 ns | 2,187.384 ns |  44,613.87 ns |         - |
|                                                   |              |               |              |              |               |           |
| Encrypt · AES-128-GCM (OS)                        | 8KB          |   3,055.22 ns |    30.614 ns |    28.636 ns |   3,052.23 ns |         - |
| Encrypt · AES-128-GCM (CryptoHives-ARM-AES+PMULL) | 8KB          |   6,397.61 ns |    29.183 ns |    27.297 ns |   6,390.78 ns |         - |
| Encrypt · AES-128-GCM (BouncyCastle)              | 8KB          |  37,432.46 ns |   732.487 ns | 1,161.802 ns |  37,464.02 ns |    1520 B |
| Encrypt · AES-128-GCM (CryptoHives-Scalar)        | 8KB          |  44,444.10 ns |    32.058 ns |    28.419 ns |  44,430.74 ns |         - |
|                                                   |              |               |              |              |               |           |
| Decrypt · AES-128-GCM (OS)                        | 128KB        |  18,502.63 ns |   114.799 ns |   107.383 ns |  18,515.75 ns |         - |
| Decrypt · AES-128-GCM (CryptoHives-ARM-AES+PMULL) | 128KB        | 101,951.82 ns | 1,977.495 ns | 3,019.844 ns | 100,571.96 ns |         - |
| Decrypt · AES-128-GCM (BouncyCastle)              | 128KB        | 510,983.20 ns |   878.479 ns |   733.570 ns | 510,907.47 ns |    1536 B |
| Decrypt · AES-128-GCM (CryptoHives-Scalar)        | 128KB        | 710,212.86 ns |   350.487 ns |   327.846 ns | 710,232.58 ns |         - |
|                                                   |              |               |              |              |               |           |
| Encrypt · AES-128-GCM (OS)                        | 128KB        |  92,527.52 ns |   808.596 ns |   756.361 ns |  92,647.64 ns |         - |
| Encrypt · AES-128-GCM (CryptoHives-ARM-AES+PMULL) | 128KB        | 104,874.83 ns |   231.933 ns |   216.950 ns | 104,802.78 ns |         - |
| Encrypt · AES-128-GCM (BouncyCastle)              | 128KB        | 686,014.08 ns | 3,994.680 ns | 3,736.626 ns | 686,045.17 ns |    1520 B |
| Encrypt · AES-128-GCM (CryptoHives-Scalar)        | 128KB        | 708,519.30 ns |    72.619 ns |    67.928 ns | 708,523.68 ns |         - |