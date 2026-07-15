| Description                                       | TestDataSize | Mean          | Error      | StdDev     | Allocated |
|-------------------------------------------------- |------------- |--------------:|-----------:|-----------:|----------:|
| Decrypt · AES-256-GCM (CryptoHives-ARM-AES+PMULL) | 17B          |      81.93 ns |   0.459 ns |   0.407 ns |         - |
| Decrypt · AES-256-GCM (CryptoHives-Scalar)        | 17B          |     399.45 ns |   3.125 ns |   2.770 ns |         - |
| Decrypt · AES-256-GCM (BouncyCastle)              | 17B          |     664.17 ns |   0.965 ns |   0.903 ns |    1744 B |
| Decrypt · AES-256-GCM (OS)                        | 17B          |   1,908.36 ns |   8.973 ns |   8.393 ns |         - |
|                                                   |              |               |            |            |           |
| Encrypt · AES-256-GCM (CryptoHives-ARM-AES+PMULL) | 17B          |      55.20 ns |   0.049 ns |   0.043 ns |         - |
| Encrypt · AES-256-GCM (CryptoHives-Scalar)        | 17B          |     357.59 ns |   0.186 ns |   0.165 ns |         - |
| Encrypt · AES-256-GCM (BouncyCastle)              | 17B          |     586.16 ns |   0.571 ns |   0.534 ns |    1728 B |
| Encrypt · AES-256-GCM (OS)                        | 17B          |   1,716.04 ns |   9.017 ns |   8.435 ns |         - |
|                                                   |              |               |            |            |           |
| Decrypt · AES-256-GCM (CryptoHives-ARM-AES+PMULL) | 65B          |     117.85 ns |   0.839 ns |   0.785 ns |         - |
| Decrypt · AES-256-GCM (CryptoHives-Scalar)        | 65B          |     700.25 ns |   0.476 ns |   0.445 ns |         - |
| Decrypt · AES-256-GCM (BouncyCastle)              | 65B          |     904.71 ns |   0.543 ns |   0.508 ns |    1744 B |
| Decrypt · AES-256-GCM (OS)                        | 65B          |   1,916.60 ns |  12.581 ns |  11.768 ns |         - |
|                                                   |              |               |            |            |           |
| Encrypt · AES-256-GCM (CryptoHives-ARM-AES+PMULL) | 65B          |      85.40 ns |   0.238 ns |   0.222 ns |         - |
| Encrypt · AES-256-GCM (CryptoHives-Scalar)        | 65B          |     660.42 ns |   0.378 ns |   0.316 ns |         - |
| Encrypt · AES-256-GCM (BouncyCastle)              | 65B          |     844.02 ns |   0.934 ns |   0.873 ns |    1728 B |
| Encrypt · AES-256-GCM (OS)                        | 65B          |   1,709.95 ns |  10.773 ns |  10.077 ns |         - |
|                                                   |              |               |            |            |           |
| Decrypt · AES-256-GCM (CryptoHives-ARM-AES+PMULL) | 128B         |     158.28 ns |   0.706 ns |   0.660 ns |         - |
| Decrypt · AES-256-GCM (CryptoHives-Scalar)        | 128B         |   1,007.02 ns |   0.432 ns |   0.404 ns |         - |
| Decrypt · AES-256-GCM (BouncyCastle)              | 128B         |   1,151.65 ns |   0.485 ns |   0.453 ns |    1744 B |
| Decrypt · AES-256-GCM (OS)                        | 128B         |   1,944.51 ns |  22.287 ns |  20.847 ns |         - |
|                                                   |              |               |            |            |           |
| Encrypt · AES-256-GCM (CryptoHives-ARM-AES+PMULL) | 128B         |     118.28 ns |   0.646 ns |   0.604 ns |         - |
| Encrypt · AES-256-GCM (CryptoHives-Scalar)        | 128B         |     960.14 ns |   0.300 ns |   0.266 ns |         - |
| Encrypt · AES-256-GCM (BouncyCastle)              | 128B         |   1,105.29 ns |   0.954 ns |   0.892 ns |    1728 B |
| Encrypt · AES-256-GCM (OS)                        | 128B         |   1,739.64 ns |   7.510 ns |   6.271 ns |         - |
|                                                   |              |               |            |            |           |
| Decrypt · AES-256-GCM (CryptoHives-ARM-AES+PMULL) | 152B         |     192.12 ns |   1.691 ns |   1.582 ns |         - |
| Decrypt · AES-256-GCM (CryptoHives-Scalar)        | 152B         |   1,206.38 ns |   0.889 ns |   0.832 ns |         - |
| Decrypt · AES-256-GCM (BouncyCastle)              | 152B         |   1,307.17 ns |   0.698 ns |   0.653 ns |    1744 B |
| Decrypt · AES-256-GCM (OS)                        | 152B         |   1,934.32 ns |  15.577 ns |  14.571 ns |         - |
|                                                   |              |               |            |            |           |
| Encrypt · AES-256-GCM (CryptoHives-ARM-AES+PMULL) | 152B         |     148.44 ns |   0.566 ns |   0.529 ns |         - |
| Encrypt · AES-256-GCM (CryptoHives-Scalar)        | 152B         |   1,165.28 ns |   2.019 ns |   1.889 ns |         - |
| Encrypt · AES-256-GCM (BouncyCastle)              | 152B         |   1,268.83 ns |   0.553 ns |   0.432 ns |    1728 B |
| Encrypt · AES-256-GCM (OS)                        | 152B         |   1,752.40 ns |  12.081 ns |  11.301 ns |         - |
|                                                   |              |               |            |            |           |
| Decrypt · AES-256-GCM (CryptoHives-ARM-AES+PMULL) | 256B         |     260.26 ns |   1.620 ns |   1.516 ns |         - |
| Decrypt · AES-256-GCM (BouncyCastle)              | 256B         |   1,777.70 ns |   0.663 ns |   0.588 ns |    1744 B |
| Decrypt · AES-256-GCM (CryptoHives-Scalar)        | 256B         |   1,821.35 ns |   2.425 ns |   2.150 ns |         - |
| Decrypt · AES-256-GCM (OS)                        | 256B         |   1,960.40 ns |  21.716 ns |  20.313 ns |         - |
|                                                   |              |               |            |            |           |
| Encrypt · AES-256-GCM (CryptoHives-ARM-AES+PMULL) | 256B         |     218.57 ns |   1.039 ns |   0.972 ns |         - |
| Encrypt · AES-256-GCM (OS)                        | 256B         |   1,765.22 ns |   8.841 ns |   8.270 ns |         - |
| Encrypt · AES-256-GCM (BouncyCastle)              | 256B         |   1,770.47 ns |   1.662 ns |   1.473 ns |    1728 B |
| Encrypt · AES-256-GCM (CryptoHives-Scalar)        | 256B         |   1,774.43 ns |   0.262 ns |   0.232 ns |         - |
|                                                   |              |               |            |            |           |
| Decrypt · AES-256-GCM (CryptoHives-ARM-AES+PMULL) | 1KB          |     846.82 ns |   3.809 ns |   3.563 ns |         - |
| Decrypt · AES-256-GCM (OS)                        | 1KB          |   2,070.91 ns |   9.462 ns |   7.901 ns |         - |
| Decrypt · AES-256-GCM (BouncyCastle)              | 1KB          |   5,527.45 ns |   0.963 ns |   0.900 ns |    1744 B |
| Decrypt · AES-256-GCM (CryptoHives-Scalar)        | 1KB          |   6,584.67 ns |   6.798 ns |   5.677 ns |         - |
|                                                   |              |               |            |            |           |
| Encrypt · AES-256-GCM (CryptoHives-ARM-AES+PMULL) | 1KB          |     801.30 ns |   5.143 ns |   4.810 ns |         - |
| Encrypt · AES-256-GCM (OS)                        | 1KB          |   1,901.97 ns |  15.642 ns |  14.632 ns |         - |
| Encrypt · AES-256-GCM (BouncyCastle)              | 1KB          |   5,751.49 ns |   2.852 ns |   2.529 ns |    1728 B |
| Encrypt · AES-256-GCM (CryptoHives-Scalar)        | 1KB          |   6,443.43 ns |   0.727 ns |   0.680 ns |         - |
|                                                   |              |               |            |            |           |
| Decrypt · AES-256-GCM (OS)                        | 8KB          |   3,074.88 ns |  24.702 ns |  23.107 ns |         - |
| Decrypt · AES-256-GCM (CryptoHives-ARM-AES+PMULL) | 8KB          |   6,266.34 ns |  29.429 ns |  27.528 ns |         - |
| Decrypt · AES-256-GCM (BouncyCastle)              | 8KB          |  40,035.64 ns |  11.713 ns |  10.956 ns |    1744 B |
| Decrypt · AES-256-GCM (CryptoHives-Scalar)        | 8KB          |  50,778.44 ns |   6.445 ns |   6.029 ns |         - |
|                                                   |              |               |            |            |           |
| Encrypt · AES-256-GCM (OS)                        | 8KB          |   2,913.78 ns |  13.955 ns |  13.053 ns |         - |
| Encrypt · AES-256-GCM (CryptoHives-ARM-AES+PMULL) | 8KB          |   6,244.50 ns |  49.260 ns |  46.078 ns |         - |
| Encrypt · AES-256-GCM (BouncyCastle)              | 8KB          |  42,620.19 ns |  11.059 ns |   9.804 ns |    1728 B |
| Encrypt · AES-256-GCM (CryptoHives-Scalar)        | 8KB          |  50,556.94 ns |  21.089 ns |  19.727 ns |         - |
|                                                   |              |               |            |            |           |
| Decrypt · AES-256-GCM (OS)                        | 128KB        |  20,630.64 ns | 113.702 ns | 106.357 ns |         - |
| Decrypt · AES-256-GCM (CryptoHives-ARM-AES+PMULL) | 128KB        | 100,350.23 ns | 483.408 ns | 428.529 ns |         - |
| Decrypt · AES-256-GCM (BouncyCastle)              | 128KB        | 633,296.41 ns | 237.810 ns | 210.813 ns |    1744 B |
| Decrypt · AES-256-GCM (CryptoHives-Scalar)        | 128KB        | 808,200.48 ns | 378.984 ns | 295.886 ns |         - |
|                                                   |              |               |            |            |           |
| Encrypt · AES-256-GCM (OS)                        | 128KB        |  21,509.75 ns |  57.782 ns |  54.049 ns |         - |
| Encrypt · AES-256-GCM (CryptoHives-ARM-AES+PMULL) | 128KB        | 100,238.85 ns | 389.967 ns | 345.695 ns |         - |
| Encrypt · AES-256-GCM (BouncyCastle)              | 128KB        | 672,608.54 ns | 261.288 ns | 244.409 ns |    1728 B |
| Encrypt · AES-256-GCM (CryptoHives-Scalar)        | 128KB        | 806,265.04 ns |  98.784 ns |  92.403 ns |         - |