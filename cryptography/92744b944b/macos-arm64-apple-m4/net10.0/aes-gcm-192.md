| Description                                       | TestDataSize | Mean            | Error        | StdDev       | Median          | Allocated |
|-------------------------------------------------- |------------- |----------------:|-------------:|-------------:|----------------:|----------:|
| Decrypt · AES-192-GCM (CryptoHives-ARM-AES+PMULL) | 17B          |       392.45 ns |     3.110 ns |     2.909 ns |       393.96 ns |         - |
| Decrypt · AES-192-GCM (CryptoHives-Scalar)        | 17B          |     1,758.46 ns |     3.325 ns |     3.110 ns |     1,758.40 ns |         - |
| Decrypt · AES-192-GCM (BouncyCastle)              | 17B          |     2,938.89 ns |     2.402 ns |     2.129 ns |     2,939.04 ns |    1640 B |
| Decrypt · AES-192-GCM (OS)                        | 17B          |     8,777.06 ns |    50.778 ns |    39.644 ns |     8,784.71 ns |         - |
|                                                   |              |                 |              |              |                 |           |
| Encrypt · AES-192-GCM (CryptoHives-ARM-AES+PMULL) | 17B          |        57.95 ns |     1.177 ns |     2.182 ns |        58.07 ns |         - |
| Encrypt · AES-192-GCM (CryptoHives-Scalar)        | 17B          |       369.48 ns |     7.030 ns |    10.945 ns |       375.66 ns |         - |
| Encrypt · AES-192-GCM (BouncyCastle)              | 17B          |       633.13 ns |    12.309 ns |    15.567 ns |       625.88 ns |    1624 B |
| Encrypt · AES-192-GCM (OS)                        | 17B          |     1,945.43 ns |    38.579 ns |    93.173 ns |     1,923.46 ns |         - |
|                                                   |              |                 |              |              |                 |           |
| Decrypt · AES-192-GCM (CryptoHives-ARM-AES+PMULL) | 65B          |       553.25 ns |     3.749 ns |     3.507 ns |       553.77 ns |         - |
| Decrypt · AES-192-GCM (CryptoHives-Scalar)        | 65B          |     3,066.36 ns |     4.271 ns |     3.786 ns |     3,066.78 ns |         - |
| Decrypt · AES-192-GCM (BouncyCastle)              | 65B          |     3,921.21 ns |     2.323 ns |     1.813 ns |     3,921.44 ns |    1640 B |
| Decrypt · AES-192-GCM (OS)                        | 65B          |     8,863.75 ns |    93.957 ns |    87.888 ns |     8,857.16 ns |         - |
|                                                   |              |                 |              |              |                 |           |
| Encrypt · AES-192-GCM (CryptoHives-ARM-AES+PMULL) | 65B          |        93.13 ns |     1.876 ns |     3.832 ns |        93.18 ns |         - |
| Encrypt · AES-192-GCM (CryptoHives-Scalar)        | 65B          |       704.40 ns |    13.883 ns |    23.195 ns |       694.92 ns |         - |
| Encrypt · AES-192-GCM (BouncyCastle)              | 65B          |       928.02 ns |    18.266 ns |    17.086 ns |       927.66 ns |    1624 B |
| Encrypt · AES-192-GCM (OS)                        | 65B          |     1,975.34 ns |    38.805 ns |    58.082 ns |     1,964.51 ns |         - |
|                                                   |              |                 |              |              |                 |           |
| Decrypt · AES-192-GCM (CryptoHives-ARM-AES+PMULL) | 128B         |       742.05 ns |     4.259 ns |     3.557 ns |       742.57 ns |         - |
| Decrypt · AES-192-GCM (CryptoHives-Scalar)        | 128B         |     4,368.73 ns |     6.113 ns |     5.718 ns |     4,368.56 ns |         - |
| Decrypt · AES-192-GCM (BouncyCastle)              | 128B         |     4,996.76 ns |    15.475 ns |    14.475 ns |     4,993.00 ns |    1640 B |
| Decrypt · AES-192-GCM (OS)                        | 128B         |     9,045.71 ns |   149.994 ns |   140.304 ns |     8,985.30 ns |         - |
|                                                   |              |                 |              |              |                 |           |
| Encrypt · AES-192-GCM (CryptoHives-ARM-AES+PMULL) | 128B         |       124.62 ns |     0.125 ns |     0.111 ns |       124.58 ns |         - |
| Encrypt · AES-192-GCM (CryptoHives-Scalar)        | 128B         |     1,069.40 ns |    12.551 ns |    11.740 ns |     1,074.00 ns |         - |
| Encrypt · AES-192-GCM (BouncyCastle)              | 128B         |     1,241.79 ns |    17.618 ns |    16.479 ns |     1,239.67 ns |    1624 B |
| Encrypt · AES-192-GCM (OS)                        | 128B         |     2,136.51 ns |    22.193 ns |    19.674 ns |     2,130.53 ns |         - |
|                                                   |              |                 |              |              |                 |           |
| Decrypt · AES-192-GCM (CryptoHives-ARM-AES+PMULL) | 152B         |       918.21 ns |    10.882 ns |    10.179 ns |       918.23 ns |         - |
| Decrypt · AES-192-GCM (CryptoHives-Scalar)        | 152B         |     5,311.08 ns |    17.759 ns |    16.611 ns |     5,305.41 ns |         - |
| Decrypt · AES-192-GCM (BouncyCastle)              | 152B         |     5,674.82 ns |    15.316 ns |    14.327 ns |     5,669.71 ns |    1640 B |
| Decrypt · AES-192-GCM (OS)                        | 152B         |     8,969.10 ns |    79.931 ns |    74.767 ns |     8,949.62 ns |         - |
|                                                   |              |                 |              |              |                 |           |
| Encrypt · AES-192-GCM (CryptoHives-ARM-AES+PMULL) | 152B         |       164.19 ns |     3.243 ns |     4.952 ns |       165.42 ns |         - |
| Encrypt · AES-192-GCM (CryptoHives-Scalar)        | 152B         |     5,117.36 ns |    15.223 ns |    13.495 ns |     5,123.91 ns |         - |
| Encrypt · AES-192-GCM (BouncyCastle)              | 152B         |     5,457.81 ns |     7.070 ns |     6.267 ns |     5,457.61 ns |    1624 B |
| Encrypt · AES-192-GCM (OS)                        | 152B         |     8,187.88 ns |    82.140 ns |    76.834 ns |     8,206.96 ns |         - |
|                                                   |              |                 |              |              |                 |           |
| Decrypt · AES-192-GCM (CryptoHives-ARM-AES+PMULL) | 256B         |     1,269.01 ns |    13.239 ns |    12.384 ns |     1,261.99 ns |         - |
| Decrypt · AES-192-GCM (BouncyCastle)              | 256B         |     7,635.70 ns |     3.393 ns |     2.833 ns |     7,636.31 ns |    1640 B |
| Decrypt · AES-192-GCM (CryptoHives-Scalar)        | 256B         |     7,991.88 ns |     6.588 ns |     6.163 ns |     7,989.93 ns |         - |
| Decrypt · AES-192-GCM (OS)                        | 256B         |     9,162.01 ns |    59.437 ns |    55.597 ns |     9,152.20 ns |         - |
|                                                   |              |                 |              |              |                 |           |
| Encrypt · AES-192-GCM (CryptoHives-ARM-AES+PMULL) | 256B         |     1,086.05 ns |     0.968 ns |     0.756 ns |     1,086.30 ns |         - |
| Encrypt · AES-192-GCM (BouncyCastle)              | 256B         |     7,593.12 ns |     5.763 ns |     5.108 ns |     7,592.27 ns |    1624 B |
| Encrypt · AES-192-GCM (CryptoHives-Scalar)        | 256B         |     7,811.69 ns |     5.031 ns |     4.201 ns |     7,810.45 ns |         - |
| Encrypt · AES-192-GCM (OS)                        | 256B         |     8,337.81 ns |    69.314 ns |    64.837 ns |     8,349.16 ns |         - |
|                                                   |              |                 |              |              |                 |           |
| Decrypt · AES-192-GCM (CryptoHives-ARM-AES+PMULL) | 1KB          |       854.23 ns |    17.011 ns |    22.120 ns |       860.14 ns |         - |
| Decrypt · AES-192-GCM (OS)                        | 1KB          |     1,960.22 ns |    39.188 ns |    40.243 ns |     1,947.46 ns |         - |
| Decrypt · AES-192-GCM (BouncyCastle)              | 1KB          |     5,056.71 ns |    39.262 ns |    32.786 ns |     5,042.00 ns |    1640 B |
| Decrypt · AES-192-GCM (CryptoHives-Scalar)        | 1KB          |     6,134.89 ns |    73.339 ns |    61.241 ns |     6,102.35 ns |         - |
|                                                   |              |                 |              |              |                 |           |
| Encrypt · AES-192-GCM (CryptoHives-ARM-AES+PMULL) | 1KB          |     4,036.06 ns |     3.988 ns |     3.535 ns |     4,035.07 ns |         - |
| Encrypt · AES-192-GCM (OS)                        | 1KB          |     8,762.99 ns |    79.900 ns |    74.739 ns |     8,755.16 ns |         - |
| Encrypt · AES-192-GCM (BouncyCastle)              | 1KB          |    24,634.84 ns |    12.668 ns |    10.578 ns |    24,632.61 ns |    1624 B |
| Encrypt · AES-192-GCM (CryptoHives-Scalar)        | 1KB          |    28,191.66 ns |    11.438 ns |    10.140 ns |    28,191.53 ns |         - |
|                                                   |              |                 |              |              |                 |           |
| Decrypt · AES-192-GCM (OS)                        | 8KB          |     2,955.64 ns |    17.672 ns |    15.666 ns |     2,952.98 ns |         - |
| Decrypt · AES-192-GCM (CryptoHives-ARM-AES+PMULL) | 8KB          |     6,083.40 ns |     4.775 ns |     3.728 ns |     6,084.46 ns |         - |
| Decrypt · AES-192-GCM (BouncyCastle)              | 8KB          |    36,111.73 ns |    17.922 ns |    16.764 ns |    36,117.73 ns |    1640 B |
| Decrypt · AES-192-GCM (CryptoHives-Scalar)        | 8KB          |    46,917.34 ns |     9.490 ns |     8.412 ns |    46,917.63 ns |         - |
|                                                   |              |                 |              |              |                 |           |
| Encrypt · AES-192-GCM (OS)                        | 8KB          |    13,389.90 ns |    71.936 ns |    56.163 ns |    13,401.61 ns |         - |
| Encrypt · AES-192-GCM (CryptoHives-ARM-AES+PMULL) | 8KB          |    31,544.06 ns |     9.340 ns |     7.292 ns |    31,544.54 ns |         - |
| Encrypt · AES-192-GCM (BouncyCastle)              | 8KB          |   181,571.55 ns |   235.114 ns |   196.331 ns |   181,621.22 ns |    1624 B |
| Encrypt · AES-192-GCM (CryptoHives-Scalar)        | 8KB          |   220,715.77 ns |   117.549 ns |    91.774 ns |   220,697.41 ns |         - |
|                                                   |              |                 |              |              |                 |           |
| Decrypt · AES-192-GCM (OS)                        | 128KB        |    19,516.26 ns |    88.794 ns |    83.058 ns |    19,509.62 ns |         - |
| Decrypt · AES-192-GCM (CryptoHives-ARM-AES+PMULL) | 128KB        |    98,492.34 ns |   815.194 ns |   722.648 ns |    98,489.86 ns |         - |
| Decrypt · AES-192-GCM (BouncyCastle)              | 128KB        |   569,394.54 ns |   356.216 ns |   297.456 ns |   569,324.58 ns |    1640 B |
| Decrypt · AES-192-GCM (CryptoHives-Scalar)        | 128KB        |   747,695.84 ns |   550.855 ns |   459.989 ns |   747,488.81 ns |         - |
|                                                   |              |                 |              |              |                 |           |
| Encrypt · AES-192-GCM (OS)                        | 128KB        |    96,747.02 ns |   119.204 ns |    93.067 ns |    96,742.32 ns |         - |
| Encrypt · AES-192-GCM (CryptoHives-ARM-AES+PMULL) | 128KB        |   504,290.32 ns |   347.637 ns |   308.171 ns |   504,308.11 ns |         - |
| Encrypt · AES-192-GCM (BouncyCastle)              | 128KB        | 2,872,363.98 ns | 1,840.506 ns | 1,536.906 ns | 2,872,103.19 ns |    1624 B |
| Encrypt · AES-192-GCM (CryptoHives-Scalar)        | 128KB        | 3,519,943.02 ns | 2,355.070 ns | 1,966.590 ns | 3,518,982.10 ns |         - |