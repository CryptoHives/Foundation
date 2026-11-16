| Description                                       | TestDataSize | Mean          | Error         | StdDev       | Median        | Allocated |
|-------------------------------------------------- |------------- |--------------:|--------------:|-------------:|--------------:|----------:|
| Decrypt · AES-128-GCM (CryptoHives-ARM-AES+PMULL) | 17B          |      84.14 ns |      0.223 ns |     0.208 ns |      84.12 ns |         - |
| Decrypt · AES-128-GCM (CryptoHives-Scalar)        | 17B          |     337.54 ns |      1.292 ns |     1.208 ns |     337.58 ns |         - |
| Decrypt · AES-128-GCM (BouncyCastle)              | 17B          |     500.07 ns |      1.578 ns |     1.399 ns |     500.33 ns |    1536 B |
| Decrypt · AES-128-GCM (OS)                        | 17B          |   1,853.13 ns |      6.123 ns |     5.727 ns |   1,853.42 ns |         - |
|                                                   |              |               |               |              |               |           |
| Encrypt · AES-128-GCM (CryptoHives-ARM-AES+PMULL) | 17B          |      51.34 ns |      0.159 ns |     0.149 ns |      51.31 ns |         - |
| Encrypt · AES-128-GCM (CryptoHives-Scalar)        | 17B          |     302.62 ns |      0.734 ns |     0.651 ns |     302.61 ns |         - |
| Encrypt · AES-128-GCM (BouncyCastle)              | 17B          |     422.85 ns |      0.554 ns |     0.491 ns |     422.93 ns |    1520 B |
| Encrypt · AES-128-GCM (OS)                        | 17B          |   1,679.11 ns |      5.223 ns |     4.886 ns |   1,679.12 ns |         - |
|                                                   |              |               |               |              |               |           |
| Decrypt · AES-128-GCM (CryptoHives-ARM-AES+PMULL) | 65B          |      90.95 ns |      0.356 ns |     0.333 ns |      90.81 ns |         - |
| Decrypt · AES-128-GCM (CryptoHives-Scalar)        | 65B          |     599.51 ns |      1.691 ns |     1.581 ns |     599.78 ns |         - |
| Decrypt · AES-128-GCM (BouncyCastle)              | 65B          |     699.44 ns |      1.456 ns |     1.362 ns |     698.99 ns |    1536 B |
| Decrypt · AES-128-GCM (OS)                        | 65B          |   1,870.90 ns |      4.798 ns |     4.488 ns |   1,870.77 ns |         - |
|                                                   |              |               |               |              |               |           |
| Encrypt · AES-128-GCM (CryptoHives-ARM-AES+PMULL) | 65B          |      58.77 ns |      0.415 ns |     0.388 ns |      58.73 ns |         - |
| Encrypt · AES-128-GCM (CryptoHives-Scalar)        | 65B          |     566.32 ns |      0.475 ns |     0.445 ns |     566.10 ns |         - |
| Encrypt · AES-128-GCM (BouncyCastle)              | 65B          |     634.16 ns |      0.748 ns |     0.663 ns |     634.24 ns |    1520 B |
| Encrypt · AES-128-GCM (OS)                        | 65B          |   1,721.33 ns |      9.085 ns |     8.498 ns |   1,720.67 ns |         - |
|                                                   |              |               |               |              |               |           |
| Decrypt · AES-128-GCM (CryptoHives-ARM-AES+PMULL) | 128B         |      89.16 ns |      0.115 ns |     0.102 ns |      89.16 ns |         - |
| Decrypt · AES-128-GCM (CryptoHives-Scalar)        | 128B         |     875.32 ns |      0.972 ns |     0.909 ns |     875.69 ns |         - |
| Decrypt · AES-128-GCM (BouncyCastle)              | 128B         |     904.64 ns |      0.944 ns |     0.836 ns |     904.51 ns |    1536 B |
| Decrypt · AES-128-GCM (OS)                        | 128B         |   1,858.82 ns |      5.219 ns |     4.882 ns |   1,858.04 ns |         - |
|                                                   |              |               |               |              |               |           |
| Encrypt · AES-128-GCM (CryptoHives-ARM-AES+PMULL) | 128B         |      59.43 ns |      0.260 ns |     0.243 ns |      59.38 ns |         - |
| Encrypt · AES-128-GCM (CryptoHives-Scalar)        | 128B         |     843.78 ns |      1.662 ns |     1.555 ns |     844.08 ns |         - |
| Encrypt · AES-128-GCM (BouncyCastle)              | 128B         |     856.57 ns |      0.570 ns |     0.505 ns |     856.58 ns |    1520 B |
| Encrypt · AES-128-GCM (OS)                        | 128B         |   1,749.18 ns |      7.759 ns |     6.878 ns |   1,750.01 ns |         - |
|                                                   |              |               |               |              |               |           |
| Decrypt · AES-128-GCM (CryptoHives-ARM-AES+PMULL) | 152B         |     112.06 ns |      0.275 ns |     0.257 ns |     112.11 ns |         - |
| Decrypt · AES-128-GCM (CryptoHives-Scalar)        | 152B         |   1,028.50 ns |      2.632 ns |     2.462 ns |   1,028.77 ns |         - |
| Decrypt · AES-128-GCM (BouncyCastle)              | 152B         |   1,030.87 ns |      2.615 ns |     2.446 ns |   1,031.23 ns |    1536 B |
| Decrypt · AES-128-GCM (OS)                        | 152B         |   1,887.94 ns |      8.820 ns |     8.250 ns |   1,891.18 ns |         - |
|                                                   |              |               |               |              |               |           |
| Encrypt · AES-128-GCM (CryptoHives-ARM-AES+PMULL) | 152B         |      83.19 ns |      0.327 ns |     0.305 ns |      83.16 ns |         - |
| Encrypt · AES-128-GCM (BouncyCastle)              | 152B         |     995.56 ns |      1.287 ns |     1.204 ns |     995.87 ns |    1520 B |
| Encrypt · AES-128-GCM (CryptoHives-Scalar)        | 152B         |     996.58 ns |      1.761 ns |     1.561 ns |     996.74 ns |         - |
| Encrypt · AES-128-GCM (OS)                        | 152B         |   1,724.62 ns |     11.725 ns |    10.967 ns |   1,728.88 ns |         - |
|                                                   |              |               |               |              |               |           |
| Decrypt · AES-128-GCM (CryptoHives-ARM-AES+PMULL) | 256B         |     117.30 ns |      0.840 ns |     0.701 ns |     117.25 ns |         - |
| Decrypt · AES-128-GCM (BouncyCastle)              | 256B         |   1,415.52 ns |      1.563 ns |     1.462 ns |   1,415.73 ns |    1536 B |
| Decrypt · AES-128-GCM (CryptoHives-Scalar)        | 256B         |   1,625.66 ns |      3.014 ns |     2.819 ns |   1,624.48 ns |         - |
| Decrypt · AES-128-GCM (OS)                        | 256B         |   1,874.18 ns |      3.797 ns |     2.965 ns |   1,874.10 ns |         - |
|                                                   |              |               |               |              |               |           |
| Encrypt · AES-128-GCM (CryptoHives-ARM-AES+PMULL) | 256B         |      81.63 ns |      0.196 ns |     0.183 ns |      81.65 ns |         - |
| Encrypt · AES-128-GCM (BouncyCastle)              | 256B         |   1,418.44 ns |      2.726 ns |     2.549 ns |   1,418.17 ns |    1520 B |
| Encrypt · AES-128-GCM (CryptoHives-Scalar)        | 256B         |   1,560.34 ns |      6.629 ns |     6.201 ns |   1,561.56 ns |         - |
| Encrypt · AES-128-GCM (OS)                        | 256B         |   1,739.98 ns |     10.064 ns |     9.414 ns |   1,743.30 ns |         - |
|                                                   |              |               |               |              |               |           |
| Decrypt · AES-128-GCM (CryptoHives-ARM-AES+PMULL) | 1KB          |     286.23 ns |      1.078 ns |     1.009 ns |     286.48 ns |         - |
| Decrypt · AES-128-GCM (OS)                        | 1KB          |   2,008.13 ns |     14.107 ns |    13.195 ns |   2,001.99 ns |         - |
| Decrypt · AES-128-GCM (BouncyCastle)              | 1KB          |   4,442.46 ns |      4.508 ns |     4.217 ns |   4,444.12 ns |    1536 B |
| Decrypt · AES-128-GCM (CryptoHives-Scalar)        | 1KB          |   5,706.00 ns |      9.721 ns |     9.093 ns |   5,706.00 ns |         - |
|                                                   |              |               |               |              |               |           |
| Encrypt · AES-128-GCM (CryptoHives-ARM-AES+PMULL) | 1KB          |     251.87 ns |      1.489 ns |     1.320 ns |     252.13 ns |         - |
| Encrypt · AES-128-GCM (OS)                        | 1KB          |   1,843.28 ns |      4.024 ns |     3.567 ns |   1,843.84 ns |         - |
| Encrypt · AES-128-GCM (BouncyCastle)              | 1KB          |   4,717.30 ns |     10.112 ns |     9.459 ns |   4,718.85 ns |    1520 B |
| Encrypt · AES-128-GCM (CryptoHives-Scalar)        | 1KB          |   5,399.35 ns |     12.027 ns |    11.250 ns |   5,401.49 ns |         - |
|                                                   |              |               |               |              |               |           |
| Decrypt · AES-128-GCM (CryptoHives-ARM-AES+PMULL) | 8KB          |   1,843.92 ns |      7.422 ns |     6.579 ns |   1,844.61 ns |         - |
| Decrypt · AES-128-GCM (OS)                        | 8KB          |   2,877.83 ns |     12.908 ns |    11.442 ns |   2,876.22 ns |         - |
| Decrypt · AES-128-GCM (BouncyCastle)              | 8KB          |  32,422.40 ns |     60.438 ns |    53.577 ns |  32,437.25 ns |    1536 B |
| Decrypt · AES-128-GCM (CryptoHives-Scalar)        | 8KB          |  43,201.55 ns |    523.690 ns |   489.860 ns |  43,266.01 ns |         - |
|                                                   |              |               |               |              |               |           |
| Encrypt · AES-128-GCM (CryptoHives-ARM-AES+PMULL) | 8KB          |   1,835.33 ns |      6.662 ns |     6.232 ns |   1,837.12 ns |         - |
| Encrypt · AES-128-GCM (OS)                        | 8KB          |   2,773.21 ns |      9.462 ns |     8.850 ns |   2,771.39 ns |         - |
| Encrypt · AES-128-GCM (BouncyCastle)              | 8KB          |  34,982.82 ns |     71.596 ns |    66.971 ns |  35,004.52 ns |    1520 B |
| Encrypt · AES-128-GCM (CryptoHives-Scalar)        | 8KB          |  41,974.52 ns |     50.715 ns |    47.439 ns |  41,969.79 ns |         - |
|                                                   |              |               |               |              |               |           |
| Decrypt · AES-128-GCM (OS)                        | 128KB        |  18,223.23 ns |     65.800 ns |    61.549 ns |  18,231.81 ns |         - |
| Decrypt · AES-128-GCM (CryptoHives-ARM-AES+PMULL) | 128KB        |  31,174.64 ns |    617.809 ns | 1,772.610 ns |  30,535.62 ns |         - |
| Decrypt · AES-128-GCM (BouncyCastle)              | 128KB        | 511,750.33 ns |    888.825 ns |   831.408 ns | 511,798.99 ns |    1536 B |
| Decrypt · AES-128-GCM (CryptoHives-Scalar)        | 128KB        | 694,850.03 ns | 10,224.931 ns | 9,064.135 ns | 694,573.20 ns |         - |
|                                                   |              |               |               |              |               |           |
| Encrypt · AES-128-GCM (OS)                        | 128KB        |  19,523.98 ns |     84.407 ns |    78.955 ns |  19,534.08 ns |         - |
| Encrypt · AES-128-GCM (CryptoHives-ARM-AES+PMULL) | 128KB        |  28,539.42 ns |     56.702 ns |    53.039 ns |  28,525.60 ns |         - |
| Encrypt · AES-128-GCM (BouncyCastle)              | 128KB        | 557,177.72 ns |    774.050 ns |   724.047 ns | 557,003.70 ns |    1520 B |
| Encrypt · AES-128-GCM (CryptoHives-Scalar)        | 128KB        | 668,916.01 ns |  1,986.448 ns | 1,858.125 ns | 669,289.35 ns |         - |