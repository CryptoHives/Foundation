| Description                                       | TestDataSize | Mean          | Error        | StdDev       | Allocated |
|-------------------------------------------------- |------------- |--------------:|-------------:|-------------:|----------:|
| Decrypt · AES-192-GCM (CryptoHives-ARM-AES+PMULL) | 17B          |      87.82 ns |     0.176 ns |     0.165 ns |         - |
| Decrypt · AES-192-GCM (CryptoHives-Scalar)        | 17B          |     374.12 ns |     0.760 ns |     0.674 ns |         - |
| Decrypt · AES-192-GCM (BouncyCastle)              | 17B          |     533.90 ns |     0.512 ns |     0.479 ns |    1640 B |
| Decrypt · AES-192-GCM (OS)                        | 17B          |   1,903.13 ns |    14.752 ns |    13.799 ns |         - |
|                                                   |              |               |              |              |           |
| Encrypt · AES-192-GCM (CryptoHives-ARM-AES+PMULL) | 17B          |      54.34 ns |     0.106 ns |     0.100 ns |         - |
| Encrypt · AES-192-GCM (CryptoHives-Scalar)        | 17B          |     344.04 ns |     1.411 ns |     1.320 ns |         - |
| Encrypt · AES-192-GCM (BouncyCastle)              | 17B          |     462.19 ns |     0.612 ns |     0.573 ns |    1624 B |
| Encrypt · AES-192-GCM (OS)                        | 17B          |   1,467.04 ns |     3.729 ns |     3.488 ns |         - |
|                                                   |              |               |              |              |           |
| Decrypt · AES-192-GCM (CryptoHives-ARM-AES+PMULL) | 65B          |      94.57 ns |     0.172 ns |     0.153 ns |         - |
| Decrypt · AES-192-GCM (CryptoHives-Scalar)        | 65B          |     687.52 ns |     0.860 ns |     0.718 ns |         - |
| Decrypt · AES-192-GCM (BouncyCastle)              | 65B          |     745.80 ns |     1.001 ns |     0.887 ns |    1640 B |
| Decrypt · AES-192-GCM (OS)                        | 65B          |   1,861.28 ns |     4.031 ns |     3.574 ns |         - |
|                                                   |              |               |              |              |           |
| Encrypt · AES-192-GCM (CryptoHives-ARM-AES+PMULL) | 65B          |      62.16 ns |     0.357 ns |     0.334 ns |         - |
| Encrypt · AES-192-GCM (CryptoHives-Scalar)        | 65B          |     659.77 ns |     1.311 ns |     1.227 ns |         - |
| Encrypt · AES-192-GCM (BouncyCastle)              | 65B          |     681.48 ns |     0.611 ns |     0.571 ns |    1624 B |
| Encrypt · AES-192-GCM (OS)                        | 65B          |   1,472.02 ns |     7.329 ns |     6.497 ns |         - |
|                                                   |              |               |              |              |           |
| Decrypt · AES-192-GCM (CryptoHives-ARM-AES+PMULL) | 128B         |      88.80 ns |     0.133 ns |     0.118 ns |         - |
| Decrypt · AES-192-GCM (BouncyCastle)              | 128B         |     959.57 ns |     0.930 ns |     0.870 ns |    1640 B |
| Decrypt · AES-192-GCM (CryptoHives-Scalar)        | 128B         |     999.55 ns |     4.358 ns |     4.076 ns |         - |
| Decrypt · AES-192-GCM (OS)                        | 128B         |   1,915.00 ns |    12.947 ns |    12.111 ns |         - |
|                                                   |              |               |              |              |           |
| Encrypt · AES-192-GCM (CryptoHives-ARM-AES+PMULL) | 128B         |      63.22 ns |     0.256 ns |     0.227 ns |         - |
| Encrypt · AES-192-GCM (BouncyCastle)              | 128B         |     910.13 ns |     1.471 ns |     1.376 ns |    1624 B |
| Encrypt · AES-192-GCM (CryptoHives-Scalar)        | 128B         |     985.89 ns |     8.465 ns |     7.918 ns |         - |
| Encrypt · AES-192-GCM (OS)                        | 128B         |   1,492.84 ns |     6.086 ns |     5.395 ns |         - |
|                                                   |              |               |              |              |           |
| Decrypt · AES-192-GCM (CryptoHives-ARM-AES+PMULL) | 152B         |     115.66 ns |     0.154 ns |     0.144 ns |         - |
| Decrypt · AES-192-GCM (BouncyCastle)              | 152B         |   1,097.94 ns |     2.424 ns |     2.267 ns |    1640 B |
| Decrypt · AES-192-GCM (CryptoHives-Scalar)        | 152B         |   1,121.55 ns |     1.933 ns |     1.808 ns |         - |
| Decrypt · AES-192-GCM (OS)                        | 152B         |   1,876.00 ns |     2.780 ns |     2.464 ns |         - |
|                                                   |              |               |              |              |           |
| Encrypt · AES-192-GCM (CryptoHives-ARM-AES+PMULL) | 152B         |      86.05 ns |     0.231 ns |     0.216 ns |         - |
| Encrypt · AES-192-GCM (BouncyCastle)              | 152B         |   1,049.62 ns |     1.750 ns |     1.637 ns |    1624 B |
| Encrypt · AES-192-GCM (CryptoHives-Scalar)        | 152B         |   1,154.11 ns |     6.155 ns |     5.757 ns |         - |
| Encrypt · AES-192-GCM (OS)                        | 152B         |   1,490.53 ns |     4.660 ns |     4.359 ns |         - |
|                                                   |              |               |              |              |           |
| Decrypt · AES-192-GCM (CryptoHives-ARM-AES+PMULL) | 256B         |     126.10 ns |     0.264 ns |     0.247 ns |         - |
| Decrypt · AES-192-GCM (BouncyCastle)              | 256B         |   1,517.40 ns |     3.845 ns |     3.596 ns |    1640 B |
| Decrypt · AES-192-GCM (CryptoHives-Scalar)        | 256B         |   1,878.49 ns |     5.999 ns |     5.612 ns |         - |
| Decrypt · AES-192-GCM (OS)                        | 256B         |   1,928.03 ns |     8.981 ns |     8.401 ns |         - |
|                                                   |              |               |              |              |           |
| Encrypt · AES-192-GCM (CryptoHives-ARM-AES+PMULL) | 256B         |      88.98 ns |     0.223 ns |     0.209 ns |         - |
| Encrypt · AES-192-GCM (BouncyCastle)              | 256B         |   1,485.69 ns |     2.118 ns |     1.982 ns |    1624 B |
| Encrypt · AES-192-GCM (OS)                        | 256B         |   1,537.75 ns |     9.096 ns |     8.509 ns |         - |
| Encrypt · AES-192-GCM (CryptoHives-Scalar)        | 256B         |   1,843.89 ns |     9.285 ns |     8.685 ns |         - |
|                                                   |              |               |              |              |           |
| Decrypt · AES-192-GCM (CryptoHives-ARM-AES+PMULL) | 1KB          |     311.79 ns |     0.844 ns |     0.705 ns |         - |
| Decrypt · AES-192-GCM (OS)                        | 1KB          |   2,011.77 ns |     7.434 ns |     6.954 ns |         - |
| Decrypt · AES-192-GCM (BouncyCastle)              | 1KB          |   4,831.35 ns |     5.605 ns |     5.243 ns |    1640 B |
| Decrypt · AES-192-GCM (CryptoHives-Scalar)        | 1KB          |   5,987.27 ns |    21.074 ns |    19.713 ns |         - |
|                                                   |              |               |              |              |           |
| Encrypt · AES-192-GCM (CryptoHives-ARM-AES+PMULL) | 1KB          |     274.83 ns |     0.861 ns |     0.805 ns |         - |
| Encrypt · AES-192-GCM (OS)                        | 1KB          |   1,614.99 ns |     4.367 ns |     3.871 ns |         - |
| Encrypt · AES-192-GCM (BouncyCastle)              | 1KB          |   4,922.45 ns |     3.493 ns |     3.268 ns |    1624 B |
| Encrypt · AES-192-GCM (CryptoHives-Scalar)        | 1KB          |   6,266.54 ns |    66.507 ns |    62.210 ns |         - |
|                                                   |              |               |              |              |           |
| Decrypt · AES-192-GCM (CryptoHives-ARM-AES+PMULL) | 8KB          |   2,025.40 ns |     8.374 ns |     6.538 ns |         - |
| Decrypt · AES-192-GCM (OS)                        | 8KB          |   2,927.65 ns |     9.499 ns |     8.885 ns |         - |
| Decrypt · AES-192-GCM (BouncyCastle)              | 8KB          |  35,571.43 ns |    54.520 ns |    50.998 ns |    1640 B |
| Decrypt · AES-192-GCM (CryptoHives-Scalar)        | 8KB          |  50,091.56 ns |   189.009 ns |   167.552 ns |         - |
|                                                   |              |               |              |              |           |
| Encrypt · AES-192-GCM (CryptoHives-ARM-AES+PMULL) | 8KB          |   1,975.87 ns |     6.772 ns |     6.335 ns |         - |
| Encrypt · AES-192-GCM (OS)                        | 8KB          |   2,490.66 ns |    17.211 ns |    16.099 ns |         - |
| Encrypt · AES-192-GCM (BouncyCastle)              | 8KB          |  36,961.07 ns |    42.465 ns |    39.721 ns |    1624 B |
| Encrypt · AES-192-GCM (CryptoHives-Scalar)        | 8KB          |  48,596.93 ns |   380.148 ns |   355.591 ns |         - |
|                                                   |              |               |              |              |           |
| Decrypt · AES-192-GCM (OS)                        | 128KB        |  19,368.65 ns |    72.154 ns |    63.962 ns |         - |
| Decrypt · AES-192-GCM (CryptoHives-ARM-AES+PMULL) | 128KB        |  31,043.81 ns |    72.009 ns |    67.357 ns |         - |
| Decrypt · AES-192-GCM (BouncyCastle)              | 128KB        | 562,963.22 ns |   659.674 ns |   617.060 ns |    1640 B |
| Decrypt · AES-192-GCM (CryptoHives-Scalar)        | 128KB        | 794,319.40 ns | 3,463.039 ns | 3,239.328 ns |         - |
|                                                   |              |               |              |              |           |
| Encrypt · AES-192-GCM (OS)                        | 128KB        |  24,767.06 ns |    81.841 ns |    72.550 ns |         - |
| Encrypt · AES-192-GCM (CryptoHives-ARM-AES+PMULL) | 128KB        |  31,085.43 ns |    74.319 ns |    69.518 ns |         - |
| Encrypt · AES-192-GCM (BouncyCastle)              | 128KB        | 587,455.46 ns |   429.745 ns |   401.984 ns |    1624 B |
| Encrypt · AES-192-GCM (CryptoHives-Scalar)        | 128KB        | 759,032.96 ns | 3,582.413 ns | 3,175.716 ns |         - |