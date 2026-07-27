| Description                                       | TestDataSize | Mean          | Error        | StdDev       | Allocated |
|-------------------------------------------------- |------------- |--------------:|-------------:|-------------:|----------:|
| Decrypt · AES-256-GCM (CryptoHives-ARM-AES+PMULL) | 17B          |      82.83 ns |     0.348 ns |     0.326 ns |         - |
| Decrypt · AES-256-GCM (CryptoHives-Scalar)        | 17B          |     396.20 ns |     0.256 ns |     0.239 ns |         - |
| Decrypt · AES-256-GCM (BouncyCastle)              | 17B          |     667.23 ns |     0.699 ns |     0.654 ns |    1744 B |
| Decrypt · AES-256-GCM (OS)                        | 17B          |   1,887.01 ns |     4.368 ns |     4.086 ns |         - |
|                                                   |              |               |              |              |           |
| Encrypt · AES-256-GCM (CryptoHives-ARM-AES+PMULL) | 17B          |      55.64 ns |     0.164 ns |     0.153 ns |         - |
| Encrypt · AES-256-GCM (CryptoHives-Scalar)        | 17B          |     360.65 ns |     0.112 ns |     0.100 ns |         - |
| Encrypt · AES-256-GCM (BouncyCastle)              | 17B          |     594.30 ns |     0.670 ns |     0.627 ns |    1728 B |
| Encrypt · AES-256-GCM (OS)                        | 17B          |   1,711.27 ns |     6.775 ns |     6.006 ns |         - |
|                                                   |              |               |              |              |           |
| Decrypt · AES-256-GCM (CryptoHives-ARM-AES+PMULL) | 65B          |     118.79 ns |     0.285 ns |     0.267 ns |         - |
| Decrypt · AES-256-GCM (CryptoHives-Scalar)        | 65B          |     706.90 ns |     1.793 ns |     1.677 ns |         - |
| Decrypt · AES-256-GCM (BouncyCastle)              | 65B          |     908.99 ns |     0.662 ns |     0.620 ns |    1744 B |
| Decrypt · AES-256-GCM (OS)                        | 65B          |   1,889.70 ns |    12.675 ns |    11.856 ns |         - |
|                                                   |              |               |              |              |           |
| Encrypt · AES-256-GCM (CryptoHives-ARM-AES+PMULL) | 65B          |      87.02 ns |     0.190 ns |     0.169 ns |         - |
| Encrypt · AES-256-GCM (CryptoHives-Scalar)        | 65B          |     665.63 ns |     0.638 ns |     0.597 ns |         - |
| Encrypt · AES-256-GCM (BouncyCastle)              | 65B          |     850.01 ns |     2.162 ns |     1.917 ns |    1728 B |
| Encrypt · AES-256-GCM (OS)                        | 65B          |   1,708.80 ns |     6.215 ns |     5.813 ns |         - |
|                                                   |              |               |              |              |           |
| Decrypt · AES-256-GCM (CryptoHives-ARM-AES+PMULL) | 128B         |     160.32 ns |     0.765 ns |     0.715 ns |         - |
| Decrypt · AES-256-GCM (CryptoHives-Scalar)        | 128B         |   1,012.53 ns |     0.696 ns |     0.651 ns |         - |
| Decrypt · AES-256-GCM (BouncyCastle)              | 128B         |   1,157.59 ns |     0.994 ns |     0.930 ns |    1744 B |
| Decrypt · AES-256-GCM (OS)                        | 128B         |   1,914.90 ns |    16.968 ns |    15.872 ns |         - |
|                                                   |              |               |              |              |           |
| Encrypt · AES-256-GCM (CryptoHives-ARM-AES+PMULL) | 128B         |     120.34 ns |     0.573 ns |     0.508 ns |         - |
| Encrypt · AES-256-GCM (CryptoHives-Scalar)        | 128B         |     965.95 ns |     3.252 ns |     3.042 ns |         - |
| Encrypt · AES-256-GCM (BouncyCastle)              | 128B         |   1,112.43 ns |     2.957 ns |     2.766 ns |    1728 B |
| Encrypt · AES-256-GCM (OS)                        | 128B         |   1,737.69 ns |     9.527 ns |     8.911 ns |         - |
|                                                   |              |               |              |              |           |
| Decrypt · AES-256-GCM (CryptoHives-ARM-AES+PMULL) | 152B         |     196.20 ns |     1.230 ns |     1.151 ns |         - |
| Decrypt · AES-256-GCM (CryptoHives-Scalar)        | 152B         |   1,217.65 ns |     0.819 ns |     0.766 ns |         - |
| Decrypt · AES-256-GCM (BouncyCastle)              | 152B         |   1,313.43 ns |     1.218 ns |     1.139 ns |    1744 B |
| Decrypt · AES-256-GCM (OS)                        | 152B         |   1,905.77 ns |     8.889 ns |     8.315 ns |         - |
|                                                   |              |               |              |              |           |
| Encrypt · AES-256-GCM (CryptoHives-ARM-AES+PMULL) | 152B         |     151.75 ns |     0.648 ns |     0.606 ns |         - |
| Encrypt · AES-256-GCM (CryptoHives-Scalar)        | 152B         |   1,176.59 ns |     0.647 ns |     0.605 ns |         - |
| Encrypt · AES-256-GCM (BouncyCastle)              | 152B         |   1,279.59 ns |     1.897 ns |     1.774 ns |    1728 B |
| Encrypt · AES-256-GCM (OS)                        | 152B         |   1,732.70 ns |     5.339 ns |     4.733 ns |         - |
|                                                   |              |               |              |              |           |
| Decrypt · AES-256-GCM (CryptoHives-ARM-AES+PMULL) | 256B         |     265.62 ns |     1.813 ns |     1.696 ns |         - |
| Decrypt · AES-256-GCM (BouncyCastle)              | 256B         |   1,789.42 ns |     3.934 ns |     3.679 ns |    1744 B |
| Decrypt · AES-256-GCM (CryptoHives-Scalar)        | 256B         |   1,835.60 ns |     2.098 ns |     1.962 ns |         - |
| Decrypt · AES-256-GCM (OS)                        | 256B         |   1,951.96 ns |     5.638 ns |     4.998 ns |         - |
|                                                   |              |               |              |              |           |
| Encrypt · AES-256-GCM (CryptoHives-ARM-AES+PMULL) | 256B         |     223.89 ns |     0.870 ns |     0.814 ns |         - |
| Encrypt · AES-256-GCM (OS)                        | 256B         |   1,754.84 ns |     5.535 ns |     5.178 ns |         - |
| Encrypt · AES-256-GCM (BouncyCastle)              | 256B         |   1,782.27 ns |     0.757 ns |     0.708 ns |    1728 B |
| Encrypt · AES-256-GCM (CryptoHives-Scalar)        | 256B         |   1,787.39 ns |     1.089 ns |     1.019 ns |         - |
|                                                   |              |               |              |              |           |
| Decrypt · AES-256-GCM (CryptoHives-ARM-AES+PMULL) | 1KB          |     865.58 ns |     2.735 ns |     2.558 ns |         - |
| Decrypt · AES-256-GCM (OS)                        | 1KB          |   2,080.01 ns |    10.964 ns |    10.256 ns |         - |
| Decrypt · AES-256-GCM (BouncyCastle)              | 1KB          |   5,555.57 ns |    10.036 ns |     9.388 ns |    1744 B |
| Decrypt · AES-256-GCM (CryptoHives-Scalar)        | 1KB          |   6,621.02 ns |    14.536 ns |    13.597 ns |         - |
|                                                   |              |               |              |              |           |
| Encrypt · AES-256-GCM (CryptoHives-ARM-AES+PMULL) | 1KB          |     830.48 ns |    10.813 ns |    10.115 ns |         - |
| Encrypt · AES-256-GCM (OS)                        | 1KB          |   1,893.68 ns |     8.658 ns |     7.675 ns |         - |
| Encrypt · AES-256-GCM (BouncyCastle)              | 1KB          |   5,793.47 ns |    13.170 ns |    12.319 ns |    1728 B |
| Encrypt · AES-256-GCM (CryptoHives-Scalar)        | 1KB          |   6,495.91 ns |    17.126 ns |    16.019 ns |         - |
|                                                   |              |               |              |              |           |
| Decrypt · AES-256-GCM (OS)                        | 8KB          |   3,050.45 ns |     4.179 ns |     3.909 ns |         - |
| Decrypt · AES-256-GCM (CryptoHives-ARM-AES+PMULL) | 8KB          |   6,532.90 ns |    48.114 ns |    45.006 ns |         - |
| Decrypt · AES-256-GCM (BouncyCastle)              | 8KB          |  40,315.75 ns |    82.110 ns |    72.788 ns |    1744 B |
| Decrypt · AES-256-GCM (CryptoHives-Scalar)        | 8KB          |  51,054.78 ns |   108.918 ns |    96.553 ns |         - |
|                                                   |              |               |              |              |           |
| Encrypt · AES-256-GCM (OS)                        | 8KB          |   2,958.88 ns |    14.861 ns |    13.901 ns |         - |
| Encrypt · AES-256-GCM (CryptoHives-ARM-AES+PMULL) | 8KB          |   6,412.98 ns |    51.968 ns |    46.069 ns |         - |
| Encrypt · AES-256-GCM (BouncyCastle)              | 8KB          |  42,889.27 ns |    59.642 ns |    55.790 ns |    1728 B |
| Encrypt · AES-256-GCM (CryptoHives-Scalar)        | 8KB          |  50,943.76 ns |   111.247 ns |    98.618 ns |         - |
|                                                   |              |               |              |              |           |
| Decrypt · AES-256-GCM (OS)                        | 128KB        |  20,919.34 ns |    62.350 ns |    58.322 ns |         - |
| Decrypt · AES-256-GCM (CryptoHives-ARM-AES+PMULL) | 128KB        | 103,009.71 ns |   692.606 ns |   613.977 ns |         - |
| Decrypt · AES-256-GCM (BouncyCastle)              | 128KB        | 636,315.45 ns |   553.266 ns |   517.526 ns |    1744 B |
| Decrypt · AES-256-GCM (CryptoHives-Scalar)        | 128KB        | 812,736.16 ns |   419.570 ns |   392.466 ns |         - |
|                                                   |              |               |              |              |           |
| Encrypt · AES-256-GCM (OS)                        | 128KB        |  21,899.07 ns |    41.055 ns |    38.403 ns |         - |
| Encrypt · AES-256-GCM (CryptoHives-ARM-AES+PMULL) | 128KB        | 105,218.75 ns | 2,102.090 ns | 2,249.213 ns |         - |
| Encrypt · AES-256-GCM (BouncyCastle)              | 128KB        | 676,916.83 ns |   405.586 ns |   379.385 ns |    1728 B |
| Encrypt · AES-256-GCM (CryptoHives-Scalar)        | 128KB        | 812,011.31 ns | 1,829.159 ns | 1,710.997 ns |         - |