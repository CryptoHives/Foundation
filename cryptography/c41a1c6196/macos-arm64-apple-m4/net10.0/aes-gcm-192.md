| Description                                       | TestDataSize | Mean          | Error        | StdDev       | Allocated |
|-------------------------------------------------- |------------- |--------------:|-------------:|-------------:|----------:|
| Decrypt · AES-192-GCM (CryptoHives-ARM-AES+PMULL) | 17B          |      83.72 ns |     0.264 ns |     0.247 ns |         - |
| Decrypt · AES-192-GCM (CryptoHives-Scalar)        | 17B          |     363.59 ns |     0.882 ns |     0.825 ns |         - |
| Decrypt · AES-192-GCM (BouncyCastle)              | 17B          |     543.46 ns |     1.887 ns |     1.765 ns |    1640 B |
| Decrypt · AES-192-GCM (OS)                        | 17B          |   1,852.05 ns |     8.056 ns |     7.536 ns |         - |
|                                                   |              |               |              |              |           |
| Encrypt · AES-192-GCM (CryptoHives-ARM-AES+PMULL) | 17B          |      52.64 ns |     0.195 ns |     0.183 ns |         - |
| Encrypt · AES-192-GCM (CryptoHives-Scalar)        | 17B          |     325.64 ns |     0.368 ns |     0.307 ns |         - |
| Encrypt · AES-192-GCM (BouncyCastle)              | 17B          |     467.81 ns |     1.166 ns |     1.090 ns |    1624 B |
| Encrypt · AES-192-GCM (OS)                        | 17B          |   1,699.46 ns |     6.302 ns |     5.895 ns |         - |
|                                                   |              |               |              |              |           |
| Decrypt · AES-192-GCM (CryptoHives-ARM-AES+PMULL) | 65B          |      91.49 ns |     0.344 ns |     0.322 ns |         - |
| Decrypt · AES-192-GCM (CryptoHives-Scalar)        | 65B          |     653.55 ns |     1.064 ns |     0.996 ns |         - |
| Decrypt · AES-192-GCM (BouncyCastle)              | 65B          |     766.22 ns |     1.093 ns |     1.023 ns |    1640 B |
| Decrypt · AES-192-GCM (OS)                        | 65B          |   1,857.53 ns |     4.244 ns |     3.763 ns |         - |
|                                                   |              |               |              |              |           |
| Encrypt · AES-192-GCM (CryptoHives-ARM-AES+PMULL) | 65B          |      60.22 ns |     0.462 ns |     0.432 ns |         - |
| Encrypt · AES-192-GCM (CryptoHives-Scalar)        | 65B          |     609.23 ns |     2.130 ns |     1.992 ns |         - |
| Encrypt · AES-192-GCM (BouncyCastle)              | 65B          |     704.45 ns |     1.622 ns |     1.517 ns |    1624 B |
| Encrypt · AES-192-GCM (OS)                        | 65B          |   1,667.28 ns |    12.924 ns |    12.089 ns |         - |
|                                                   |              |               |              |              |           |
| Decrypt · AES-192-GCM (CryptoHives-ARM-AES+PMULL) | 128B         |      89.25 ns |     0.253 ns |     0.224 ns |         - |
| Decrypt · AES-192-GCM (CryptoHives-Scalar)        | 128B         |     951.00 ns |     2.592 ns |     2.298 ns |         - |
| Decrypt · AES-192-GCM (BouncyCastle)              | 128B         |     995.00 ns |     1.509 ns |     1.411 ns |    1640 B |
| Decrypt · AES-192-GCM (OS)                        | 128B         |   1,849.55 ns |     5.386 ns |     4.775 ns |         - |
|                                                   |              |               |              |              |           |
| Encrypt · AES-192-GCM (CryptoHives-ARM-AES+PMULL) | 128B         |      61.44 ns |     0.325 ns |     0.304 ns |         - |
| Encrypt · AES-192-GCM (CryptoHives-Scalar)        | 128B         |     909.29 ns |     1.700 ns |     1.590 ns |         - |
| Encrypt · AES-192-GCM (BouncyCastle)              | 128B         |     946.93 ns |     0.681 ns |     0.604 ns |    1624 B |
| Encrypt · AES-192-GCM (OS)                        | 128B         |   1,688.35 ns |     7.547 ns |     7.059 ns |         - |
|                                                   |              |               |              |              |           |
| Decrypt · AES-192-GCM (CryptoHives-ARM-AES+PMULL) | 152B         |     113.60 ns |     0.357 ns |     0.334 ns |         - |
| Decrypt · AES-192-GCM (BouncyCastle)              | 152B         |   1,135.72 ns |     1.212 ns |     1.134 ns |    1640 B |
| Decrypt · AES-192-GCM (CryptoHives-Scalar)        | 152B         |   1,141.95 ns |     1.770 ns |     1.655 ns |         - |
| Decrypt · AES-192-GCM (OS)                        | 152B         |   1,857.19 ns |     8.409 ns |     7.866 ns |         - |
|                                                   |              |               |              |              |           |
| Encrypt · AES-192-GCM (CryptoHives-ARM-AES+PMULL) | 152B         |      83.23 ns |     0.266 ns |     0.249 ns |         - |
| Encrypt · AES-192-GCM (CryptoHives-Scalar)        | 152B         |   1,074.97 ns |     2.828 ns |     2.645 ns |         - |
| Encrypt · AES-192-GCM (BouncyCastle)              | 152B         |   1,097.32 ns |     1.850 ns |     1.730 ns |    1624 B |
| Encrypt · AES-192-GCM (OS)                        | 152B         |   1,692.04 ns |     5.545 ns |     4.915 ns |         - |
|                                                   |              |               |              |              |           |
| Decrypt · AES-192-GCM (CryptoHives-ARM-AES+PMULL) | 256B         |     121.66 ns |     0.548 ns |     0.513 ns |         - |
| Decrypt · AES-192-GCM (BouncyCastle)              | 256B         |   1,564.60 ns |     1.454 ns |     1.289 ns |    1640 B |
| Decrypt · AES-192-GCM (CryptoHives-Scalar)        | 256B         |   1,752.21 ns |     2.862 ns |     2.677 ns |         - |
| Decrypt · AES-192-GCM (OS)                        | 256B         |   1,888.84 ns |     5.976 ns |     5.590 ns |         - |
|                                                   |              |               |              |              |           |
| Encrypt · AES-192-GCM (CryptoHives-ARM-AES+PMULL) | 256B         |      87.64 ns |     0.324 ns |     0.303 ns |         - |
| Encrypt · AES-192-GCM (BouncyCastle)              | 256B         |   1,566.53 ns |     3.319 ns |     3.105 ns |    1624 B |
| Encrypt · AES-192-GCM (CryptoHives-Scalar)        | 256B         |   1,674.36 ns |     4.998 ns |     4.676 ns |         - |
| Encrypt · AES-192-GCM (OS)                        | 256B         |   1,716.61 ns |     4.693 ns |     4.160 ns |         - |
|                                                   |              |               |              |              |           |
| Decrypt · AES-192-GCM (CryptoHives-ARM-AES+PMULL) | 1KB          |     302.55 ns |     0.802 ns |     0.626 ns |         - |
| Decrypt · AES-192-GCM (OS)                        | 1KB          |   2,001.88 ns |    17.537 ns |    16.404 ns |         - |
| Decrypt · AES-192-GCM (BouncyCastle)              | 1KB          |   4,950.23 ns |     5.798 ns |     5.423 ns |    1640 B |
| Decrypt · AES-192-GCM (CryptoHives-Scalar)        | 1KB          |   6,184.16 ns |    11.486 ns |    10.744 ns |         - |
|                                                   |              |               |              |              |           |
| Encrypt · AES-192-GCM (CryptoHives-ARM-AES+PMULL) | 1KB          |     267.69 ns |     1.237 ns |     1.157 ns |         - |
| Encrypt · AES-192-GCM (OS)                        | 1KB          |   1,854.17 ns |     4.957 ns |     4.636 ns |         - |
| Encrypt · AES-192-GCM (BouncyCastle)              | 1KB          |   5,245.88 ns |     9.271 ns |     8.672 ns |    1624 B |
| Encrypt · AES-192-GCM (CryptoHives-Scalar)        | 1KB          |   5,873.02 ns |     3.225 ns |     2.859 ns |         - |
|                                                   |              |               |              |              |           |
| Decrypt · AES-192-GCM (CryptoHives-ARM-AES+PMULL) | 8KB          |   2,008.56 ns |    18.358 ns |    15.330 ns |         - |
| Decrypt · AES-192-GCM (OS)                        | 8KB          |   2,948.09 ns |     8.707 ns |     7.719 ns |         - |
| Decrypt · AES-192-GCM (BouncyCastle)              | 8KB          |  36,559.50 ns |   103.022 ns |    91.326 ns |    1640 B |
| Decrypt · AES-192-GCM (CryptoHives-Scalar)        | 8KB          |  45,984.94 ns |    84.870 ns |    79.388 ns |         - |
|                                                   |              |               |              |              |           |
| Encrypt · AES-192-GCM (CryptoHives-ARM-AES+PMULL) | 8KB          |   1,964.14 ns |    11.444 ns |    10.705 ns |         - |
| Encrypt · AES-192-GCM (OS)                        | 8KB          |   2,806.54 ns |    19.793 ns |    17.546 ns |         - |
| Encrypt · AES-192-GCM (BouncyCastle)              | 8KB          |  39,045.26 ns |    67.354 ns |    52.586 ns |    1624 B |
| Encrypt · AES-192-GCM (CryptoHives-Scalar)        | 8KB          |  45,700.31 ns |    62.244 ns |    58.223 ns |         - |
|                                                   |              |               |              |              |           |
| Decrypt · AES-192-GCM (OS)                        | 128KB        |  19,237.62 ns |    54.707 ns |    51.173 ns |         - |
| Decrypt · AES-192-GCM (CryptoHives-ARM-AES+PMULL) | 128KB        |  30,858.96 ns |   164.163 ns |   145.526 ns |         - |
| Decrypt · AES-192-GCM (BouncyCastle)              | 128KB        | 575,428.92 ns |   497.173 ns |   465.056 ns |    1640 B |
| Decrypt · AES-192-GCM (CryptoHives-Scalar)        | 128KB        | 743,798.36 ns | 2,212.208 ns | 2,069.301 ns |         - |
|                                                   |              |               |              |              |           |
| Encrypt · AES-192-GCM (OS)                        | 128KB        |  20,498.44 ns |   119.293 ns |   111.587 ns |         - |
| Encrypt · AES-192-GCM (CryptoHives-ARM-AES+PMULL) | 128KB        |  30,893.76 ns |   163.105 ns |   152.569 ns |         - |
| Encrypt · AES-192-GCM (BouncyCastle)              | 128KB        | 620,000.13 ns |   774.852 ns |   724.797 ns |    1624 B |
| Encrypt · AES-192-GCM (CryptoHives-Scalar)        | 128KB        | 728,912.08 ns |   559.873 ns |   467.520 ns |         - |