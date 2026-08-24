| Description                                       | TestDataSize | Mean            | Error        | StdDev       | Median          | Allocated |
|-------------------------------------------------- |------------- |----------------:|-------------:|-------------:|----------------:|----------:|
| Decrypt · AES-256-GCM (CryptoHives-ARM-AES+PMULL) | 17B          |       402.14 ns |     3.135 ns |     2.932 ns |       403.50 ns |         - |
| Decrypt · AES-256-GCM (CryptoHives-Scalar)        | 17B          |     1,939.91 ns |     3.831 ns |     3.397 ns |     1,939.94 ns |         - |
| Decrypt · AES-256-GCM (BouncyCastle)              | 17B          |     2,755.81 ns |     2.925 ns |     2.442 ns |     2,755.79 ns |    1744 B |
| Decrypt · AES-256-GCM (OS)                        | 17B          |     9,136.30 ns |    75.171 ns |    70.315 ns |     9,133.25 ns |         - |
|                                                   |              |                 |              |              |                 |           |
| Encrypt · AES-256-GCM (CryptoHives-ARM-AES+PMULL) | 17B          |        55.76 ns |     0.037 ns |     0.034 ns |        55.75 ns |         - |
| Encrypt · AES-256-GCM (CryptoHives-Scalar)        | 17B          |       365.66 ns |     0.712 ns |     0.666 ns |       365.38 ns |         - |
| Encrypt · AES-256-GCM (BouncyCastle)              | 17B          |       560.03 ns |    10.652 ns |    23.382 ns |       567.27 ns |    1728 B |
| Encrypt · AES-256-GCM (OS)                        | 17B          |     1,889.74 ns |    34.448 ns |    45.987 ns |     1,876.85 ns |         - |
|                                                   |              |                 |              |              |                 |           |
| Decrypt · AES-256-GCM (CryptoHives-ARM-AES+PMULL) | 65B          |       562.69 ns |     6.965 ns |     6.515 ns |       566.54 ns |         - |
| Decrypt · AES-256-GCM (BouncyCastle)              | 65B          |       843.23 ns |     1.590 ns |     1.953 ns |       842.85 ns |    1744 B |
| Decrypt · AES-256-GCM (OS)                        | 65B          |     1,912.94 ns |    12.000 ns |    11.224 ns |     1,914.88 ns |         - |
| Decrypt · AES-256-GCM (CryptoHives-Scalar)        | 65B          |     3,423.87 ns |     5.108 ns |     4.778 ns |     3,424.21 ns |         - |
|                                                   |              |                 |              |              |                 |           |
| Encrypt · AES-256-GCM (CryptoHives-ARM-AES+PMULL) | 65B          |        93.36 ns |     1.857 ns |     3.300 ns |        92.98 ns |         - |
| Encrypt · AES-256-GCM (CryptoHives-Scalar)        | 65B          |       827.14 ns |    16.307 ns |    20.026 ns |       819.48 ns |         - |
| Encrypt · AES-256-GCM (BouncyCastle)              | 65B          |       922.79 ns |    18.473 ns |    19.766 ns |       923.15 ns |    1728 B |
| Encrypt · AES-256-GCM (OS)                        | 65B          |     1,998.88 ns |    15.958 ns |    12.459 ns |     1,996.88 ns |         - |
|                                                   |              |                 |              |              |                 |           |
| Decrypt · AES-256-GCM (CryptoHives-ARM-AES+PMULL) | 128B         |       158.43 ns |     0.639 ns |     0.598 ns |       158.42 ns |         - |
| Decrypt · AES-256-GCM (CryptoHives-Scalar)        | 128B         |     1,039.14 ns |     0.926 ns |     0.723 ns |     1,039.18 ns |         - |
| Decrypt · AES-256-GCM (BouncyCastle)              | 128B         |     1,080.96 ns |     9.284 ns |     8.684 ns |     1,087.23 ns |    1744 B |
| Decrypt · AES-256-GCM (OS)                        | 128B         |     1,952.25 ns |    15.320 ns |    14.330 ns |     1,946.91 ns |         - |
|                                                   |              |                 |              |              |                 |           |
| Encrypt · AES-256-GCM (CryptoHives-ARM-AES+PMULL) | 128B         |       514.02 ns |    57.566 ns |   169.734 ns |       588.23 ns |         - |
| Encrypt · AES-256-GCM (CryptoHives-Scalar)        | 128B         |     4,665.38 ns |     8.818 ns |     7.363 ns |     4,661.65 ns |         - |
| Encrypt · AES-256-GCM (BouncyCastle)              | 128B         |     4,884.52 ns |     4.068 ns |     3.397 ns |     4,883.35 ns |    1728 B |
| Encrypt · AES-256-GCM (OS)                        | 128B         |     8,271.37 ns |    35.695 ns |    33.389 ns |     8,272.66 ns |         - |
|                                                   |              |                 |              |              |                 |           |
| Decrypt · AES-256-GCM (CryptoHives-ARM-AES+PMULL) | 152B         |       197.13 ns |     2.508 ns |     2.223 ns |       197.40 ns |         - |
| Decrypt · AES-256-GCM (BouncyCastle)              | 152B         |     1,226.50 ns |     0.897 ns |     0.839 ns |     1,226.34 ns |    1744 B |
| Decrypt · AES-256-GCM (CryptoHives-Scalar)        | 152B         |     1,263.86 ns |     0.457 ns |     0.406 ns |     1,263.86 ns |         - |
| Decrypt · AES-256-GCM (OS)                        | 152B         |     1,948.40 ns |    11.307 ns |    10.577 ns |     1,951.39 ns |         - |
|                                                   |              |                 |              |              |                 |           |
| Encrypt · AES-256-GCM (CryptoHives-ARM-AES+PMULL) | 152B         |       149.41 ns |     1.065 ns |     0.944 ns |       149.51 ns |         - |
| Encrypt · AES-256-GCM (BouncyCastle)              | 152B         |     1,196.08 ns |     0.811 ns |     0.719 ns |     1,196.00 ns |    1728 B |
| Encrypt · AES-256-GCM (CryptoHives-Scalar)        | 152B         |     1,217.38 ns |     0.323 ns |     0.302 ns |     1,217.41 ns |         - |
| Encrypt · AES-256-GCM (OS)                        | 152B         |     1,759.58 ns |    15.037 ns |    14.065 ns |     1,755.40 ns |         - |
|                                                   |              |                 |              |              |                 |           |
| Decrypt · AES-256-GCM (CryptoHives-ARM-AES+PMULL) | 256B         |       264.20 ns |     2.031 ns |     1.899 ns |       264.44 ns |         - |
| Decrypt · AES-256-GCM (BouncyCastle)              | 256B         |     1,702.56 ns |     0.707 ns |     0.661 ns |     1,702.61 ns |    1744 B |
| Decrypt · AES-256-GCM (CryptoHives-Scalar)        | 256B         |     1,896.22 ns |     1.920 ns |     1.796 ns |     1,896.93 ns |         - |
| Decrypt · AES-256-GCM (OS)                        | 256B         |     1,977.22 ns |    34.629 ns |    32.392 ns |     1,971.69 ns |         - |
|                                                   |              |                 |              |              |                 |           |
| Encrypt · AES-256-GCM (CryptoHives-ARM-AES+PMULL) | 256B         |       224.16 ns |     0.808 ns |     0.755 ns |       224.07 ns |         - |
| Encrypt · AES-256-GCM (BouncyCastle)              | 256B         |     1,697.09 ns |     0.643 ns |     0.570 ns |     1,696.99 ns |    1728 B |
| Encrypt · AES-256-GCM (OS)                        | 256B         |     1,747.38 ns |     5.929 ns |     5.546 ns |     1,746.38 ns |         - |
| Encrypt · AES-256-GCM (CryptoHives-Scalar)        | 256B         |     1,811.76 ns |     1.194 ns |     0.932 ns |     1,811.48 ns |         - |
|                                                   |              |                 |              |              |                 |           |
| Decrypt · AES-256-GCM (CryptoHives-ARM-AES+PMULL) | 1KB          |       892.29 ns |     2.502 ns |     2.218 ns |       892.07 ns |         - |
| Decrypt · AES-256-GCM (OS)                        | 1KB          |     2,519.20 ns |    37.718 ns |    35.281 ns |     2,508.78 ns |         - |
| Decrypt · AES-256-GCM (BouncyCastle)              | 1KB          |     6,375.34 ns |   125.640 ns |   250.917 ns |     6,432.22 ns |    1744 B |
| Decrypt · AES-256-GCM (CryptoHives-Scalar)        | 1KB          |     7,471.06 ns |   148.484 ns |   332.106 ns |     7,558.87 ns |         - |
|                                                   |              |                 |              |              |                 |           |
| Encrypt · AES-256-GCM (CryptoHives-ARM-AES+PMULL) | 1KB          |       806.45 ns |     3.908 ns |     3.655 ns |       807.03 ns |         - |
| Encrypt · AES-256-GCM (OS)                        | 1KB          |     1,889.25 ns |     9.659 ns |     9.035 ns |     1,887.51 ns |         - |
| Encrypt · AES-256-GCM (BouncyCastle)              | 1KB          |     5,694.15 ns |     1.625 ns |     1.357 ns |     5,693.62 ns |    1728 B |
| Encrypt · AES-256-GCM (CryptoHives-Scalar)        | 1KB          |     6,675.32 ns |     0.800 ns |     0.709 ns |     6,675.44 ns |         - |
|                                                   |              |                 |              |              |                 |           |
| Decrypt · AES-256-GCM (OS)                        | 8KB          |    14,649.63 ns |   143.823 ns |   134.532 ns |    14,643.18 ns |         - |
| Decrypt · AES-256-GCM (CryptoHives-ARM-AES+PMULL) | 8KB          |    32,323.67 ns |    52.443 ns |    46.490 ns |    32,316.62 ns |         - |
| Decrypt · AES-256-GCM (BouncyCastle)              | 8KB          |   188,247.76 ns |   117.529 ns |   109.936 ns |   188,223.75 ns |    1744 B |
| Decrypt · AES-256-GCM (CryptoHives-Scalar)        | 8KB          |   247,234.80 ns |   158.812 ns |   140.782 ns |   247,223.54 ns |         - |
|                                                   |              |                 |              |              |                 |           |
| Encrypt · AES-256-GCM (OS)                        | 8KB          |     3,222.30 ns |    54.360 ns |    58.164 ns |     3,253.27 ns |         - |
| Encrypt · AES-256-GCM (CryptoHives-ARM-AES+PMULL) | 8KB          |     6,547.20 ns |    16.577 ns |    13.843 ns |     6,541.98 ns |         - |
| Encrypt · AES-256-GCM (BouncyCastle)              | 8KB          |    46,046.01 ns |   537.279 ns |   502.571 ns |    45,830.43 ns |    1728 B |
| Encrypt · AES-256-GCM (CryptoHives-Scalar)        | 8KB          |    52,286.67 ns |    29.629 ns |    27.715 ns |    52,282.80 ns |         - |
|                                                   |              |                 |              |              |                 |           |
| Decrypt · AES-256-GCM (OS)                        | 128KB        |    20,011.13 ns |   132.876 ns |   190.567 ns |    19,991.55 ns |         - |
| Decrypt · AES-256-GCM (CryptoHives-ARM-AES+PMULL) | 128KB        |   511,849.03 ns |   393.925 ns |   328.945 ns |   511,879.19 ns |         - |
| Decrypt · AES-256-GCM (BouncyCastle)              | 128KB        | 2,985,627.73 ns | 1,814.103 ns | 1,608.155 ns | 2,985,366.95 ns |    1744 B |
| Decrypt · AES-256-GCM (CryptoHives-Scalar)        | 128KB        | 3,943,812.19 ns | 3,600.441 ns | 3,191.697 ns | 3,943,339.68 ns |         - |
|                                                   |              |                 |              |              |                 |           |
| Encrypt · AES-256-GCM (OS)                        | 128KB        |    28,252.90 ns |   533.561 ns |   524.028 ns |    28,327.61 ns |         - |
| Encrypt · AES-256-GCM (CryptoHives-ARM-AES+PMULL) | 128KB        |   106,602.01 ns |   296.905 ns |   247.930 ns |   106,548.17 ns |         - |
| Encrypt · AES-256-GCM (CryptoHives-Scalar)        | 128KB        |   833,459.96 ns |   193.488 ns |   171.522 ns |   833,445.03 ns |         - |
| Encrypt · AES-256-GCM (BouncyCastle)              | 128KB        |   838,705.08 ns | 4,667.694 ns | 4,137.789 ns |   839,079.92 ns |    1728 B |