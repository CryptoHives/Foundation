| Description                                       | TestDataSize | Mean          | Error        | StdDev       | Allocated |
|-------------------------------------------------- |------------- |--------------:|-------------:|-------------:|----------:|
| Decrypt · AES-128-GCM (CryptoHives-ARM-AES+PMULL) | 17B          |      81.57 ns |     0.472 ns |     0.441 ns |         - |
| Decrypt · AES-128-GCM (CryptoHives-Scalar)        | 17B          |     352.93 ns |     0.263 ns |     0.246 ns |         - |
| Decrypt · AES-128-GCM (BouncyCastle)              | 17B          |     574.36 ns |     0.587 ns |     0.549 ns |    1536 B |
| Decrypt · AES-128-GCM (OS)                        | 17B          |   1,873.97 ns |     2.744 ns |     2.292 ns |         - |
|                                                   |              |               |              |              |           |
| Encrypt · AES-128-GCM (CryptoHives-ARM-AES+PMULL) | 17B          |      52.97 ns |     0.127 ns |     0.106 ns |         - |
| Encrypt · AES-128-GCM (CryptoHives-Scalar)        | 17B          |     314.09 ns |     0.486 ns |     0.406 ns |         - |
| Encrypt · AES-128-GCM (BouncyCastle)              | 17B          |     499.72 ns |     0.832 ns |     0.778 ns |    1520 B |
| Encrypt · AES-128-GCM (OS)                        | 17B          |   1,674.47 ns |     3.880 ns |     3.440 ns |         - |
|                                                   |              |               |              |              |           |
| Decrypt · AES-128-GCM (CryptoHives-ARM-AES+PMULL) | 65B          |     115.40 ns |     0.377 ns |     0.334 ns |         - |
| Decrypt · AES-128-GCM (CryptoHives-Scalar)        | 65B          |     611.85 ns |     0.376 ns |     0.314 ns |         - |
| Decrypt · AES-128-GCM (BouncyCastle)              | 65B          |     773.67 ns |     0.614 ns |     0.545 ns |    1536 B |
| Decrypt · AES-128-GCM (OS)                        | 65B          |   1,878.47 ns |     4.693 ns |     4.160 ns |         - |
|                                                   |              |               |              |              |           |
| Encrypt · AES-128-GCM (CryptoHives-ARM-AES+PMULL) | 65B          |      84.16 ns |     0.294 ns |     0.246 ns |         - |
| Encrypt · AES-128-GCM (CryptoHives-Scalar)        | 65B          |     575.53 ns |     1.502 ns |     1.405 ns |         - |
| Encrypt · AES-128-GCM (BouncyCastle)              | 65B          |     710.40 ns |     0.867 ns |     0.769 ns |    1520 B |
| Encrypt · AES-128-GCM (OS)                        | 65B          |   1,686.75 ns |     7.238 ns |     5.651 ns |         - |
|                                                   |              |               |              |              |           |
| Decrypt · AES-128-GCM (CryptoHives-ARM-AES+PMULL) | 128B         |     153.04 ns |     0.826 ns |     0.773 ns |         - |
| Decrypt · AES-128-GCM (CryptoHives-Scalar)        | 128B         |     868.16 ns |     2.004 ns |     1.874 ns |         - |
| Decrypt · AES-128-GCM (BouncyCastle)              | 128B         |     975.70 ns |     0.957 ns |     0.895 ns |    1536 B |
| Decrypt · AES-128-GCM (OS)                        | 128B         |   1,905.71 ns |     7.132 ns |     6.671 ns |         - |
|                                                   |              |               |              |              |           |
| Encrypt · AES-128-GCM (CryptoHives-ARM-AES+PMULL) | 128B         |     116.73 ns |     0.260 ns |     0.243 ns |         - |
| Encrypt · AES-128-GCM (CryptoHives-Scalar)        | 128B         |     837.28 ns |     1.924 ns |     1.800 ns |         - |
| Encrypt · AES-128-GCM (BouncyCastle)              | 128B         |     929.89 ns |     0.696 ns |     0.651 ns |    1520 B |
| Encrypt · AES-128-GCM (OS)                        | 128B         |   1,711.98 ns |     2.151 ns |     2.012 ns |         - |
|                                                   |              |               |              |              |           |
| Decrypt · AES-128-GCM (CryptoHives-ARM-AES+PMULL) | 152B         |     189.97 ns |     1.001 ns |     0.836 ns |         - |
| Decrypt · AES-128-GCM (CryptoHives-Scalar)        | 152B         |   1,057.49 ns |     1.258 ns |     1.115 ns |         - |
| Decrypt · AES-128-GCM (BouncyCastle)              | 152B         |   1,104.17 ns |     2.559 ns |     2.393 ns |    1536 B |
| Decrypt · AES-128-GCM (OS)                        | 152B         |   1,905.40 ns |     6.481 ns |     5.412 ns |         - |
|                                                   |              |               |              |              |           |
| Encrypt · AES-128-GCM (CryptoHives-ARM-AES+PMULL) | 152B         |     148.52 ns |     0.630 ns |     0.589 ns |         - |
| Encrypt · AES-128-GCM (CryptoHives-Scalar)        | 152B         |   1,007.52 ns |     0.739 ns |     0.617 ns |         - |
| Encrypt · AES-128-GCM (BouncyCastle)              | 152B         |   1,063.20 ns |     0.857 ns |     0.802 ns |    1520 B |
| Encrypt · AES-128-GCM (OS)                        | 152B         |   1,709.70 ns |     4.531 ns |     4.239 ns |         - |
|                                                   |              |               |              |              |           |
| Decrypt · AES-128-GCM (CryptoHives-ARM-AES+PMULL) | 256B         |     255.77 ns |     1.399 ns |     1.309 ns |         - |
| Decrypt · AES-128-GCM (BouncyCastle)              | 256B         |   1,486.96 ns |     4.122 ns |     3.654 ns |    1536 B |
| Decrypt · AES-128-GCM (CryptoHives-Scalar)        | 256B         |   1,582.31 ns |     1.230 ns |     1.150 ns |         - |
| Decrypt · AES-128-GCM (OS)                        | 256B         |   1,896.66 ns |     4.938 ns |     3.855 ns |         - |
|                                                   |              |               |              |              |           |
| Encrypt · AES-128-GCM (CryptoHives-ARM-AES+PMULL) | 256B         |     215.12 ns |     0.583 ns |     0.517 ns |         - |
| Encrypt · AES-128-GCM (BouncyCastle)              | 256B         |   1,479.38 ns |     3.286 ns |     3.073 ns |    1520 B |
| Encrypt · AES-128-GCM (CryptoHives-Scalar)        | 256B         |   1,544.35 ns |     1.091 ns |     1.021 ns |         - |
| Encrypt · AES-128-GCM (OS)                        | 256B         |   1,748.45 ns |     4.554 ns |     3.555 ns |         - |
|                                                   |              |               |              |              |           |
| Decrypt · AES-128-GCM (CryptoHives-ARM-AES+PMULL) | 1KB          |     840.33 ns |     3.762 ns |     3.519 ns |         - |
| Decrypt · AES-128-GCM (OS)                        | 1KB          |   2,024.30 ns |     9.723 ns |     8.620 ns |         - |
| Decrypt · AES-128-GCM (BouncyCastle)              | 1KB          |   4,526.16 ns |     8.305 ns |     6.935 ns |    1536 B |
| Decrypt · AES-128-GCM (CryptoHives-Scalar)        | 1KB          |   5,664.27 ns |    13.058 ns |    12.214 ns |         - |
|                                                   |              |               |              |              |           |
| Encrypt · AES-128-GCM (CryptoHives-ARM-AES+PMULL) | 1KB          |     799.27 ns |     2.413 ns |     2.015 ns |         - |
| Encrypt · AES-128-GCM (OS)                        | 1KB          |   1,854.72 ns |     2.951 ns |     2.616 ns |         - |
| Encrypt · AES-128-GCM (BouncyCastle)              | 1KB          |   4,763.99 ns |     5.256 ns |     4.916 ns |    1520 B |
| Encrypt · AES-128-GCM (CryptoHives-Scalar)        | 1KB          |   5,531.46 ns |     5.677 ns |     5.033 ns |         - |
|                                                   |              |               |              |              |           |
| Decrypt · AES-128-GCM (OS)                        | 8KB          |   2,907.95 ns |     8.141 ns |     7.615 ns |         - |
| Decrypt · AES-128-GCM (CryptoHives-ARM-AES+PMULL) | 8KB          |   6,369.43 ns |    54.612 ns |    51.084 ns |         - |
| Decrypt · AES-128-GCM (BouncyCastle)              | 8KB          |  32,582.37 ns |    37.072 ns |    30.957 ns |    1536 B |
| Decrypt · AES-128-GCM (CryptoHives-Scalar)        | 8KB          |  43,273.15 ns |    80.748 ns |    71.581 ns |         - |
|                                                   |              |               |              |              |           |
| Encrypt · AES-128-GCM (OS)                        | 8KB          |   2,808.66 ns |     9.966 ns |     9.322 ns |         - |
| Encrypt · AES-128-GCM (CryptoHives-ARM-AES+PMULL) | 8KB          |   6,292.44 ns |    51.839 ns |    45.954 ns |         - |
| Encrypt · AES-128-GCM (BouncyCastle)              | 8KB          |  34,851.77 ns |   102.453 ns |    90.822 ns |    1520 B |
| Encrypt · AES-128-GCM (CryptoHives-Scalar)        | 8KB          |  43,335.69 ns |    45.629 ns |    38.103 ns |         - |
|                                                   |              |               |              |              |           |
| Decrypt · AES-128-GCM (OS)                        | 128KB        |  18,581.70 ns |   103.598 ns |    96.906 ns |         - |
| Decrypt · AES-128-GCM (CryptoHives-ARM-AES+PMULL) | 128KB        | 101,387.74 ns |   527.661 ns |   467.758 ns |         - |
| Decrypt · AES-128-GCM (BouncyCastle)              | 128KB        | 513,054.70 ns |   659.537 ns |   616.931 ns |    1536 B |
| Decrypt · AES-128-GCM (CryptoHives-Scalar)        | 128KB        | 691,168.75 ns |   525.607 ns |   465.937 ns |         - |
|                                                   |              |               |              |              |           |
| Encrypt · AES-128-GCM (OS)                        | 128KB        |  19,753.51 ns |    92.144 ns |    86.191 ns |         - |
| Encrypt · AES-128-GCM (CryptoHives-ARM-AES+PMULL) | 128KB        | 100,731.09 ns |   625.701 ns |   554.668 ns |         - |
| Encrypt · AES-128-GCM (BouncyCastle)              | 128KB        | 552,679.48 ns | 1,558.620 ns | 1,381.676 ns |    1520 B |
| Encrypt · AES-128-GCM (CryptoHives-Scalar)        | 128KB        | 689,829.55 ns |   806.886 ns |   715.283 ns |         - |