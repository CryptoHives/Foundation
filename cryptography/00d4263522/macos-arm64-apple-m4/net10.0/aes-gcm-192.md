| Description                                       | TestDataSize | Mean          | Error         | StdDev        | Allocated |
|-------------------------------------------------- |------------- |--------------:|--------------:|--------------:|----------:|
| Decrypt · AES-192-GCM (CryptoHives-ARM-AES+PMULL) | 17B          |      83.00 ns |      1.640 ns |      1.534 ns |         - |
| Decrypt · AES-192-GCM (CryptoHives-Scalar)        | 17B          |     376.56 ns |      6.387 ns |      5.974 ns |         - |
| Decrypt · AES-192-GCM (BouncyCastle)              | 17B          |     543.14 ns |      0.487 ns |      0.380 ns |    1640 B |
| Decrypt · AES-192-GCM (OS)                        | 17B          |   1,894.46 ns |     24.631 ns |     23.040 ns |         - |
|                                                   |              |               |               |               |           |
| Encrypt · AES-192-GCM (CryptoHives-ARM-AES+PMULL) | 17B          |      54.93 ns |      0.600 ns |      0.561 ns |         - |
| Encrypt · AES-192-GCM (CryptoHives-Scalar)        | 17B          |     337.20 ns |      5.018 ns |      4.694 ns |         - |
| Encrypt · AES-192-GCM (BouncyCastle)              | 17B          |     469.08 ns |      6.441 ns |      6.025 ns |    1624 B |
| Encrypt · AES-192-GCM (OS)                        | 17B          |   1,713.90 ns |     24.146 ns |     21.405 ns |         - |
|                                                   |              |               |               |               |           |
| Decrypt · AES-192-GCM (CryptoHives-ARM-AES+PMULL) | 65B          |     115.70 ns |      0.916 ns |      0.715 ns |         - |
| Decrypt · AES-192-GCM (CryptoHives-Scalar)        | 65B          |     660.64 ns |      9.225 ns |      8.629 ns |         - |
| Decrypt · AES-192-GCM (BouncyCastle)              | 65B          |     767.57 ns |     12.903 ns |     12.070 ns |    1640 B |
| Decrypt · AES-192-GCM (OS)                        | 65B          |   1,877.24 ns |     27.175 ns |     25.420 ns |         - |
|                                                   |              |               |               |               |           |
| Encrypt · AES-192-GCM (CryptoHives-ARM-AES+PMULL) | 65B          |      87.14 ns |      1.164 ns |      1.089 ns |         - |
| Encrypt · AES-192-GCM (CryptoHives-Scalar)        | 65B          |     618.23 ns |      1.141 ns |      0.891 ns |         - |
| Encrypt · AES-192-GCM (BouncyCastle)              | 65B          |     703.90 ns |     11.423 ns |     10.685 ns |    1624 B |
| Encrypt · AES-192-GCM (OS)                        | 65B          |   1,711.44 ns |     23.912 ns |     22.367 ns |         - |
|                                                   |              |               |               |               |           |
| Decrypt · AES-192-GCM (CryptoHives-ARM-AES+PMULL) | 128B         |     158.51 ns |      2.218 ns |      2.075 ns |         - |
| Decrypt · AES-192-GCM (CryptoHives-Scalar)        | 128B         |     940.85 ns |     10.801 ns |     10.103 ns |         - |
| Decrypt · AES-192-GCM (BouncyCastle)              | 128B         |     988.71 ns |      1.160 ns |      0.905 ns |    1640 B |
| Decrypt · AES-192-GCM (OS)                        | 128B         |   1,899.61 ns |     11.311 ns |      8.831 ns |         - |
|                                                   |              |               |               |               |           |
| Encrypt · AES-192-GCM (CryptoHives-ARM-AES+PMULL) | 128B         |     120.42 ns |      0.438 ns |      0.342 ns |         - |
| Encrypt · AES-192-GCM (CryptoHives-Scalar)        | 128B         |     905.47 ns |     10.480 ns |      9.803 ns |         - |
| Encrypt · AES-192-GCM (BouncyCastle)              | 128B         |     948.62 ns |     12.051 ns |     11.273 ns |    1624 B |
| Encrypt · AES-192-GCM (OS)                        | 128B         |   1,736.71 ns |     25.666 ns |     24.008 ns |         - |
|                                                   |              |               |               |               |           |
| Decrypt · AES-192-GCM (CryptoHives-ARM-AES+PMULL) | 152B         |     196.76 ns |      3.151 ns |      2.948 ns |         - |
| Decrypt · AES-192-GCM (BouncyCastle)              | 152B         |   1,121.30 ns |      0.935 ns |      0.730 ns |    1640 B |
| Decrypt · AES-192-GCM (CryptoHives-Scalar)        | 152B         |   1,143.28 ns |     20.734 ns |     19.395 ns |         - |
| Decrypt · AES-192-GCM (OS)                        | 152B         |   1,940.97 ns |     29.651 ns |     26.284 ns |         - |
|                                                   |              |               |               |               |           |
| Encrypt · AES-192-GCM (CryptoHives-ARM-AES+PMULL) | 152B         |     152.74 ns |      1.953 ns |      1.731 ns |         - |
| Encrypt · AES-192-GCM (BouncyCastle)              | 152B         |   1,085.59 ns |      3.118 ns |      2.435 ns |    1624 B |
| Encrypt · AES-192-GCM (CryptoHives-Scalar)        | 152B         |   1,089.03 ns |      1.963 ns |      1.532 ns |         - |
| Encrypt · AES-192-GCM (OS)                        | 152B         |   1,731.97 ns |     24.049 ns |     22.495 ns |         - |
|                                                   |              |               |               |               |           |
| Decrypt · AES-192-GCM (CryptoHives-ARM-AES+PMULL) | 256B         |     265.27 ns |      3.368 ns |      2.985 ns |         - |
| Decrypt · AES-192-GCM (BouncyCastle)              | 256B         |   1,569.57 ns |     24.433 ns |     22.855 ns |    1640 B |
| Decrypt · AES-192-GCM (CryptoHives-Scalar)        | 256B         |   1,729.93 ns |     25.530 ns |     23.881 ns |         - |
| Decrypt · AES-192-GCM (OS)                        | 256B         |   1,924.91 ns |     20.710 ns |     17.294 ns |         - |
|                                                   |              |               |               |               |           |
| Encrypt · AES-192-GCM (CryptoHives-ARM-AES+PMULL) | 256B         |     223.56 ns |      1.897 ns |      1.774 ns |         - |
| Encrypt · AES-192-GCM (BouncyCastle)              | 256B         |   1,553.90 ns |     21.063 ns |     19.702 ns |    1624 B |
| Encrypt · AES-192-GCM (CryptoHives-Scalar)        | 256B         |   1,672.48 ns |     21.308 ns |     19.932 ns |         - |
| Encrypt · AES-192-GCM (OS)                        | 256B         |   1,728.22 ns |     21.973 ns |     20.554 ns |         - |
|                                                   |              |               |               |               |           |
| Decrypt · AES-192-GCM (CryptoHives-ARM-AES+PMULL) | 1KB          |     872.62 ns |      8.313 ns |      7.776 ns |         - |
| Decrypt · AES-192-GCM (OS)                        | 1KB          |   2,068.07 ns |     40.595 ns |     41.688 ns |         - |
| Decrypt · AES-192-GCM (BouncyCastle)              | 1KB          |   4,934.79 ns |     72.716 ns |     60.721 ns |    1640 B |
| Decrypt · AES-192-GCM (CryptoHives-Scalar)        | 1KB          |   6,178.31 ns |     80.482 ns |     75.283 ns |         - |
|                                                   |              |               |               |               |           |
| Encrypt · AES-192-GCM (CryptoHives-ARM-AES+PMULL) | 1KB          |     848.91 ns |     12.128 ns |     11.345 ns |         - |
| Encrypt · AES-192-GCM (OS)                        | 1KB          |   1,876.92 ns |     26.669 ns |     23.641 ns |         - |
| Encrypt · AES-192-GCM (BouncyCastle)              | 1KB          |   5,157.18 ns |      7.085 ns |      5.532 ns |    1624 B |
| Encrypt · AES-192-GCM (CryptoHives-Scalar)        | 1KB          |   6,036.29 ns |     76.472 ns |     67.791 ns |         - |
|                                                   |              |               |               |               |           |
| Decrypt · AES-192-GCM (OS)                        | 8KB          |   3,047.37 ns |     43.139 ns |     40.352 ns |         - |
| Decrypt · AES-192-GCM (CryptoHives-ARM-AES+PMULL) | 8KB          |   6,518.83 ns |     95.394 ns |     89.231 ns |         - |
| Decrypt · AES-192-GCM (BouncyCastle)              | 8KB          |  36,090.16 ns |     36.803 ns |     28.733 ns |    1640 B |
| Decrypt · AES-192-GCM (CryptoHives-Scalar)        | 8KB          |  47,517.89 ns |    611.899 ns |    572.370 ns |         - |
|                                                   |              |               |               |               |           |
| Encrypt · AES-192-GCM (OS)                        | 8KB          |   2,892.27 ns |     41.891 ns |     39.185 ns |         - |
| Encrypt · AES-192-GCM (CryptoHives-ARM-AES+PMULL) | 8KB          |   6,454.73 ns |     54.392 ns |     50.879 ns |         - |
| Encrypt · AES-192-GCM (BouncyCastle)              | 8KB          |  38,727.19 ns |    106.239 ns |     82.945 ns |    1624 B |
| Encrypt · AES-192-GCM (CryptoHives-Scalar)        | 8KB          |  47,283.55 ns |    523.677 ns |    464.226 ns |         - |
|                                                   |              |               |               |               |           |
| Decrypt · AES-192-GCM (OS)                        | 128KB        |  19,723.92 ns |     96.015 ns |     74.962 ns |         - |
| Decrypt · AES-192-GCM (CryptoHives-ARM-AES+PMULL) | 128KB        | 104,196.47 ns |  1,427.580 ns |  1,335.359 ns |         - |
| Decrypt · AES-192-GCM (BouncyCastle)              | 128KB        | 572,304.77 ns |    671.582 ns |    524.327 ns |    1640 B |
| Decrypt · AES-192-GCM (CryptoHives-Scalar)        | 128KB        | 767,349.50 ns | 12,067.831 ns | 11,288.257 ns |         - |
|                                                   |              |               |               |               |           |
| Encrypt · AES-192-GCM (OS)                        | 128KB        |  20,503.19 ns |    394.779 ns |    329.659 ns |         - |
| Encrypt · AES-192-GCM (CryptoHives-ARM-AES+PMULL) | 128KB        | 104,476.32 ns |  1,284.123 ns |  1,201.170 ns |         - |
| Encrypt · AES-192-GCM (BouncyCastle)              | 128KB        | 619,379.13 ns | 12,092.666 ns | 11,311.487 ns |    1624 B |
| Encrypt · AES-192-GCM (CryptoHives-Scalar)        | 128KB        | 756,452.44 ns | 10,409.273 ns |  9,736.840 ns |         - |