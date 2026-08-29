| Description                                       | TestDataSize | Mean          | Error         | StdDev        | Median        | Allocated |
|-------------------------------------------------- |------------- |--------------:|--------------:|--------------:|--------------:|----------:|
| Decrypt · AES-128-GCM (CryptoHives-ARM-AES+PMULL) | 17B          |      82.90 ns |      0.679 ns |      0.567 ns |      82.82 ns |         - |
| Decrypt · AES-128-GCM (CryptoHives-Scalar)        | 17B          |     343.92 ns |      3.916 ns |      3.270 ns |     342.48 ns |         - |
| Decrypt · AES-128-GCM (BouncyCastle)              | 17B          |     499.79 ns |      3.857 ns |      3.221 ns |     498.90 ns |    1536 B |
| Decrypt · AES-128-GCM (OS)                        | 17B          |   1,923.46 ns |     36.479 ns |     34.122 ns |   1,910.93 ns |         - |
|                                                   |              |               |               |               |               |           |
| Encrypt · AES-128-GCM (CryptoHives-ARM-AES+PMULL) | 17B          |      54.31 ns |      0.090 ns |      0.079 ns |      54.31 ns |         - |
| Encrypt · AES-128-GCM (CryptoHives-Scalar)        | 17B          |     312.76 ns |      0.711 ns |      0.665 ns |     312.39 ns |         - |
| Encrypt · AES-128-GCM (BouncyCastle)              | 17B          |     429.11 ns |      0.435 ns |      0.340 ns |     429.19 ns |    1520 B |
| Encrypt · AES-128-GCM (OS)                        | 17B          |   1,715.79 ns |      8.483 ns |      6.623 ns |   1,714.32 ns |         - |
|                                                   |              |               |               |               |               |           |
| Decrypt · AES-128-GCM (CryptoHives-ARM-AES+PMULL) | 65B          |     103.74 ns |      0.828 ns |      0.734 ns |     103.58 ns |         - |
| Decrypt · AES-128-GCM (CryptoHives-Scalar)        | 65B          |     596.20 ns |      0.496 ns |      0.440 ns |     596.21 ns |         - |
| Decrypt · AES-128-GCM (BouncyCastle)              | 65B          |     693.02 ns |      0.717 ns |      0.599 ns |     692.85 ns |    1536 B |
| Decrypt · AES-128-GCM (OS)                        | 65B          |   1,928.49 ns |     20.618 ns |     16.097 ns |   1,926.59 ns |         - |
|                                                   |              |               |               |               |               |           |
| Encrypt · AES-128-GCM (CryptoHives-ARM-AES+PMULL) | 65B          |      62.95 ns |      0.154 ns |      0.137 ns |      62.97 ns |         - |
| Encrypt · AES-128-GCM (CryptoHives-Scalar)        | 65B          |     564.20 ns |      0.291 ns |      0.258 ns |     564.18 ns |         - |
| Encrypt · AES-128-GCM (BouncyCastle)              | 65B          |     633.10 ns |      0.851 ns |      0.710 ns |     632.76 ns |    1520 B |
| Encrypt · AES-128-GCM (OS)                        | 65B          |   1,720.01 ns |      5.931 ns |      5.548 ns |   1,721.97 ns |         - |
|                                                   |              |               |               |               |               |           |
| Decrypt · AES-128-GCM (CryptoHives-ARM-AES+PMULL) | 128B         |      92.29 ns |      1.311 ns |      1.162 ns |      91.92 ns |         - |
| Decrypt · AES-128-GCM (CryptoHives-Scalar)        | 128B         |     857.04 ns |      5.279 ns |      4.680 ns |     855.12 ns |         - |
| Decrypt · AES-128-GCM (BouncyCastle)              | 128B         |     896.31 ns |      1.039 ns |      0.811 ns |     896.28 ns |    1536 B |
| Decrypt · AES-128-GCM (OS)                        | 128B         |   1,939.98 ns |     37.643 ns |     38.656 ns |   1,949.25 ns |         - |
|                                                   |              |               |               |               |               |           |
| Encrypt · AES-128-GCM (CryptoHives-ARM-AES+PMULL) | 128B         |      65.85 ns |      0.082 ns |      0.068 ns |      65.85 ns |         - |
| Encrypt · AES-128-GCM (CryptoHives-Scalar)        | 128B         |     827.22 ns |      0.737 ns |      0.616 ns |     826.97 ns |         - |
| Encrypt · AES-128-GCM (BouncyCastle)              | 128B         |     851.30 ns |      0.942 ns |      0.881 ns |     850.98 ns |    1520 B |
| Encrypt · AES-128-GCM (OS)                        | 128B         |   1,754.88 ns |     26.097 ns |     24.411 ns |   1,754.17 ns |         - |
|                                                   |              |               |               |               |               |           |
| Decrypt · AES-128-GCM (CryptoHives-ARM-AES+PMULL) | 152B         |     127.12 ns |      1.690 ns |      1.581 ns |     126.91 ns |         - |
| Decrypt · AES-128-GCM (BouncyCastle)              | 152B         |   1,012.82 ns |      0.867 ns |      0.724 ns |   1,012.46 ns |    1536 B |
| Decrypt · AES-128-GCM (CryptoHives-Scalar)        | 152B         |   1,049.06 ns |     20.842 ns |     22.301 ns |   1,047.65 ns |         - |
| Decrypt · AES-128-GCM (OS)                        | 152B         |   1,909.60 ns |     11.519 ns |      9.619 ns |   1,909.82 ns |         - |
|                                                   |              |               |               |               |               |           |
| Encrypt · AES-128-GCM (CryptoHives-ARM-AES+PMULL) | 152B         |      89.68 ns |      1.044 ns |      0.977 ns |      89.91 ns |         - |
| Encrypt · AES-128-GCM (BouncyCastle)              | 152B         |     989.20 ns |      5.194 ns |      4.859 ns |     988.29 ns |    1520 B |
| Encrypt · AES-128-GCM (CryptoHives-Scalar)        | 152B         |   1,021.56 ns |     19.483 ns |     35.627 ns |   1,002.18 ns |         - |
| Encrypt · AES-128-GCM (OS)                        | 152B         |   1,759.28 ns |     13.624 ns |     11.377 ns |   1,758.75 ns |         - |
|                                                   |              |               |               |               |               |           |
| Decrypt · AES-128-GCM (CryptoHives-ARM-AES+PMULL) | 256B         |     132.81 ns |      1.406 ns |      1.246 ns |     132.64 ns |         - |
| Decrypt · AES-128-GCM (BouncyCastle)              | 256B         |   1,403.17 ns |      1.901 ns |      1.587 ns |   1,402.64 ns |    1536 B |
| Decrypt · AES-128-GCM (CryptoHives-Scalar)        | 256B         |   1,551.03 ns |      0.796 ns |      0.664 ns |   1,550.83 ns |         - |
| Decrypt · AES-128-GCM (OS)                        | 256B         |   1,947.73 ns |     21.565 ns |     18.008 ns |   1,943.30 ns |         - |
|                                                   |              |               |               |               |               |           |
| Encrypt · AES-128-GCM (CryptoHives-ARM-AES+PMULL) | 256B         |      90.72 ns |      0.274 ns |      0.243 ns |      90.67 ns |         - |
| Encrypt · AES-128-GCM (BouncyCastle)              | 256B         |   1,393.27 ns |      0.720 ns |      0.562 ns |   1,393.36 ns |    1520 B |
| Encrypt · AES-128-GCM (CryptoHives-Scalar)        | 256B         |   1,523.49 ns |      2.356 ns |      1.968 ns |   1,522.63 ns |         - |
| Encrypt · AES-128-GCM (OS)                        | 256B         |   1,733.83 ns |     10.207 ns |      9.548 ns |   1,730.41 ns |         - |
|                                                   |              |               |               |               |               |           |
| Decrypt · AES-128-GCM (CryptoHives-ARM-AES+PMULL) | 1KB          |     344.25 ns |      6.756 ns |      7.510 ns |     345.51 ns |         - |
| Decrypt · AES-128-GCM (OS)                        | 1KB          |   2,044.86 ns |     12.149 ns |     10.769 ns |   2,043.34 ns |         - |
| Decrypt · AES-128-GCM (BouncyCastle)              | 1KB          |   4,441.04 ns |     32.515 ns |     30.414 ns |   4,423.01 ns |    1536 B |
| Decrypt · AES-128-GCM (CryptoHives-Scalar)        | 1KB          |   5,556.85 ns |     49.551 ns |     38.686 ns |   5,543.14 ns |         - |
|                                                   |              |               |               |               |               |           |
| Encrypt · AES-128-GCM (CryptoHives-ARM-AES+PMULL) | 1KB          |     293.38 ns |      1.857 ns |      1.647 ns |     293.64 ns |         - |
| Encrypt · AES-128-GCM (OS)                        | 1KB          |   1,887.41 ns |     12.652 ns |      9.878 ns |   1,890.39 ns |         - |
| Encrypt · AES-128-GCM (BouncyCastle)              | 1KB          |   4,650.81 ns |      4.174 ns |      3.259 ns |   4,650.92 ns |    1520 B |
| Encrypt · AES-128-GCM (CryptoHives-Scalar)        | 1KB          |   5,415.31 ns |      6.668 ns |      5.911 ns |   5,413.41 ns |         - |
|                                                   |              |               |               |               |               |           |
| Decrypt · AES-128-GCM (CryptoHives-ARM-AES+PMULL) | 8KB          |   2,347.85 ns |     41.092 ns |     38.438 ns |   2,351.95 ns |         - |
| Decrypt · AES-128-GCM (OS)                        | 8KB          |   3,000.30 ns |     17.443 ns |     14.565 ns |   2,997.27 ns |         - |
| Decrypt · AES-128-GCM (BouncyCastle)              | 8KB          |  33,350.53 ns |    665.716 ns |    683.642 ns |  33,256.28 ns |    1536 B |
| Decrypt · AES-128-GCM (CryptoHives-Scalar)        | 8KB          |  43,193.40 ns |     79.632 ns |     62.171 ns |  43,184.80 ns |         - |
|                                                   |              |               |               |               |               |           |
| Encrypt · AES-128-GCM (CryptoHives-ARM-AES+PMULL) | 8KB          |   2,204.58 ns |      7.418 ns |      6.194 ns |   2,203.63 ns |         - |
| Encrypt · AES-128-GCM (OS)                        | 8KB          |   2,836.68 ns |     43.047 ns |     40.266 ns |   2,822.61 ns |         - |
| Encrypt · AES-128-GCM (BouncyCastle)              | 8KB          |  35,020.43 ns |    470.773 ns |    367.549 ns |  34,862.10 ns |    1520 B |
| Encrypt · AES-128-GCM (CryptoHives-Scalar)        | 8KB          |  42,459.76 ns |     95.958 ns |     74.918 ns |  42,440.17 ns |         - |
|                                                   |              |               |               |               |               |           |
| Decrypt · AES-128-GCM (OS)                        | 128KB        |  18,480.74 ns |     38.837 ns |     34.428 ns |  18,485.73 ns |         - |
| Decrypt · AES-128-GCM (CryptoHives-ARM-AES+PMULL) | 128KB        |  35,515.89 ns |    621.613 ns |    551.044 ns |  35,216.62 ns |         - |
| Decrypt · AES-128-GCM (BouncyCastle)              | 128KB        | 510,446.54 ns |  3,170.481 ns |  2,475.303 ns | 509,956.56 ns |    1536 B |
| Decrypt · AES-128-GCM (CryptoHives-Scalar)        | 128KB        | 677,803.43 ns |    892.009 ns |    696.422 ns | 677,521.85 ns |         - |
|                                                   |              |               |               |               |               |           |
| Encrypt · AES-128-GCM (OS)                        | 128KB        |  20,232.04 ns |    370.502 ns |    363.883 ns |  20,201.56 ns |         - |
| Encrypt · AES-128-GCM (CryptoHives-ARM-AES+PMULL) | 128KB        |  35,967.28 ns |    706.125 ns |  1,218.031 ns |  35,716.86 ns |         - |
| Encrypt · AES-128-GCM (BouncyCastle)              | 128KB        | 553,415.10 ns |  3,736.574 ns |  3,120.209 ns | 552,868.35 ns |    1520 B |
| Encrypt · AES-128-GCM (CryptoHives-Scalar)        | 128KB        | 687,220.58 ns | 10,737.377 ns | 10,043.749 ns | 685,431.40 ns |         - |