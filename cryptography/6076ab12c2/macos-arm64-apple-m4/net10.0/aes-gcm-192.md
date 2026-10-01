| Description                                       | TestDataSize | Mean          | Error        | StdDev       | Allocated |
|-------------------------------------------------- |------------- |--------------:|-------------:|-------------:|----------:|
| Decrypt · AES-192-GCM (CryptoHives-ARM-AES+PMULL) | 17B          |      85.66 ns |     0.424 ns |     0.376 ns |         - |
| Decrypt · AES-192-GCM (CryptoHives-Scalar)        | 17B          |     369.92 ns |     3.615 ns |     3.204 ns |         - |
| Decrypt · AES-192-GCM (BouncyCastle)              | 17B          |     542.19 ns |     2.192 ns |     2.050 ns |    1640 B |
| Decrypt · AES-192-GCM (OS)                        | 17B          |   1,855.25 ns |    11.289 ns |     9.427 ns |         - |
|                                                   |              |               |              |              |           |
| Encrypt · AES-192-GCM (CryptoHives-ARM-AES+PMULL) | 17B          |      53.17 ns |     0.074 ns |     0.069 ns |         - |
| Encrypt · AES-192-GCM (CryptoHives-Scalar)        | 17B          |     333.87 ns |     0.924 ns |     0.865 ns |         - |
| Encrypt · AES-192-GCM (BouncyCastle)              | 17B          |     463.83 ns |     0.250 ns |     0.222 ns |    1624 B |
| Encrypt · AES-192-GCM (OS)                        | 17B          |   1,709.03 ns |     8.066 ns |     7.150 ns |         - |
|                                                   |              |               |              |              |           |
| Decrypt · AES-192-GCM (CryptoHives-ARM-AES+PMULL) | 65B          |      93.08 ns |     0.793 ns |     0.703 ns |         - |
| Decrypt · AES-192-GCM (CryptoHives-Scalar)        | 65B          |     670.30 ns |     5.251 ns |     4.385 ns |         - |
| Decrypt · AES-192-GCM (BouncyCastle)              | 65B          |     758.72 ns |     1.731 ns |     1.352 ns |    1640 B |
| Decrypt · AES-192-GCM (OS)                        | 65B          |   1,888.59 ns |    21.181 ns |    18.777 ns |         - |
|                                                   |              |               |              |              |           |
| Encrypt · AES-192-GCM (CryptoHives-ARM-AES+PMULL) | 65B          |      63.59 ns |     0.416 ns |     0.389 ns |         - |
| Encrypt · AES-192-GCM (CryptoHives-Scalar)        | 65B          |     621.25 ns |     4.311 ns |     3.822 ns |         - |
| Encrypt · AES-192-GCM (BouncyCastle)              | 65B          |     696.64 ns |     0.429 ns |     0.402 ns |    1624 B |
| Encrypt · AES-192-GCM (OS)                        | 65B          |   1,701.01 ns |     6.948 ns |     6.159 ns |         - |
|                                                   |              |               |              |              |           |
| Decrypt · AES-192-GCM (CryptoHives-ARM-AES+PMULL) | 128B         |      92.84 ns |     0.166 ns |     0.148 ns |         - |
| Decrypt · AES-192-GCM (CryptoHives-Scalar)        | 128B         |     952.12 ns |     7.872 ns |     7.364 ns |         - |
| Decrypt · AES-192-GCM (BouncyCastle)              | 128B         |   1,002.43 ns |     1.630 ns |     1.525 ns |    1640 B |
| Decrypt · AES-192-GCM (OS)                        | 128B         |   2,004.52 ns |    37.210 ns |    32.985 ns |         - |
|                                                   |              |               |              |              |           |
| Encrypt · AES-192-GCM (CryptoHives-ARM-AES+PMULL) | 128B         |      66.95 ns |     0.049 ns |     0.043 ns |         - |
| Encrypt · AES-192-GCM (CryptoHives-Scalar)        | 128B         |     909.85 ns |     6.380 ns |     5.327 ns |         - |
| Encrypt · AES-192-GCM (BouncyCastle)              | 128B         |     946.02 ns |     0.329 ns |     0.292 ns |    1624 B |
| Encrypt · AES-192-GCM (OS)                        | 128B         |   1,724.79 ns |     4.552 ns |     4.036 ns |         - |
|                                                   |              |               |              |              |           |
| Decrypt · AES-192-GCM (CryptoHives-ARM-AES+PMULL) | 152B         |     123.01 ns |     0.470 ns |     0.440 ns |         - |
| Decrypt · AES-192-GCM (BouncyCastle)              | 152B         |   1,139.92 ns |     4.657 ns |     3.888 ns |    1640 B |
| Decrypt · AES-192-GCM (CryptoHives-Scalar)        | 152B         |   1,163.38 ns |     5.213 ns |     4.353 ns |         - |
| Decrypt · AES-192-GCM (OS)                        | 152B         |   1,942.65 ns |     9.134 ns |     8.544 ns |         - |
|                                                   |              |               |              |              |           |
| Encrypt · AES-192-GCM (CryptoHives-ARM-AES+PMULL) | 152B         |      87.60 ns |     0.368 ns |     0.344 ns |         - |
| Encrypt · AES-192-GCM (BouncyCastle)              | 152B         |   1,103.12 ns |     0.608 ns |     0.569 ns |    1624 B |
| Encrypt · AES-192-GCM (CryptoHives-Scalar)        | 152B         |   1,115.49 ns |     6.761 ns |     6.324 ns |         - |
| Encrypt · AES-192-GCM (OS)                        | 152B         |   1,716.11 ns |    16.752 ns |    14.850 ns |         - |
|                                                   |              |               |              |              |           |
| Decrypt · AES-192-GCM (CryptoHives-ARM-AES+PMULL) | 256B         |     125.39 ns |     1.304 ns |     1.219 ns |         - |
| Decrypt · AES-192-GCM (BouncyCastle)              | 256B         |   1,571.16 ns |    16.863 ns |    15.773 ns |    1640 B |
| Decrypt · AES-192-GCM (CryptoHives-Scalar)        | 256B         |   1,745.84 ns |    10.529 ns |     9.849 ns |         - |
| Decrypt · AES-192-GCM (OS)                        | 256B         |   1,907.12 ns |    22.398 ns |    19.855 ns |         - |
|                                                   |              |               |              |              |           |
| Encrypt · AES-192-GCM (CryptoHives-ARM-AES+PMULL) | 256B         |      95.18 ns |     1.937 ns |     3.183 ns |         - |
| Encrypt · AES-192-GCM (BouncyCastle)              | 256B         |   1,549.44 ns |    11.355 ns |    10.622 ns |    1624 B |
| Encrypt · AES-192-GCM (CryptoHives-Scalar)        | 256B         |   1,698.54 ns |    20.880 ns |    19.531 ns |         - |
| Encrypt · AES-192-GCM (OS)                        | 256B         |   1,724.71 ns |     8.711 ns |     8.148 ns |         - |
|                                                   |              |               |              |              |           |
| Decrypt · AES-192-GCM (CryptoHives-ARM-AES+PMULL) | 1KB          |     332.11 ns |     6.044 ns |     5.654 ns |         - |
| Decrypt · AES-192-GCM (OS)                        | 1KB          |   2,005.15 ns |    21.351 ns |    19.972 ns |         - |
| Decrypt · AES-192-GCM (BouncyCastle)              | 1KB          |   4,942.89 ns |    46.098 ns |    43.120 ns |    1640 B |
| Decrypt · AES-192-GCM (CryptoHives-Scalar)        | 1KB          |   6,158.72 ns |    31.579 ns |    29.539 ns |         - |
|                                                   |              |               |              |              |           |
| Encrypt · AES-192-GCM (CryptoHives-ARM-AES+PMULL) | 1KB          |     294.61 ns |     5.025 ns |     4.196 ns |         - |
| Encrypt · AES-192-GCM (OS)                        | 1KB          |   1,917.38 ns |    22.372 ns |    19.832 ns |         - |
| Encrypt · AES-192-GCM (BouncyCastle)              | 1KB          |   5,278.26 ns |    30.554 ns |    25.514 ns |    1624 B |
| Encrypt · AES-192-GCM (CryptoHives-Scalar)        | 1KB          |   5,920.15 ns |    19.274 ns |    17.086 ns |         - |
|                                                   |              |               |              |              |           |
| Decrypt · AES-192-GCM (CryptoHives-ARM-AES+PMULL) | 8KB          |   2,242.47 ns |    26.748 ns |    23.711 ns |         - |
| Decrypt · AES-192-GCM (OS)                        | 8KB          |   2,972.00 ns |    14.135 ns |    13.222 ns |         - |
| Decrypt · AES-192-GCM (BouncyCastle)              | 8KB          |  35,921.49 ns |    18.413 ns |    15.376 ns |    1640 B |
| Decrypt · AES-192-GCM (CryptoHives-Scalar)        | 8KB          |  47,110.15 ns |   254.862 ns |   225.929 ns |         - |
|                                                   |              |               |              |              |           |
| Encrypt · AES-192-GCM (CryptoHives-ARM-AES+PMULL) | 8KB          |   2,202.97 ns |    30.438 ns |    26.982 ns |         - |
| Encrypt · AES-192-GCM (OS)                        | 8KB          |   2,830.28 ns |    20.510 ns |    18.182 ns |         - |
| Encrypt · AES-192-GCM (BouncyCastle)              | 8KB          |  39,401.48 ns |   271.761 ns |   226.932 ns |    1624 B |
| Encrypt · AES-192-GCM (CryptoHives-Scalar)        | 8KB          |  46,850.13 ns |   143.289 ns |   134.032 ns |         - |
|                                                   |              |               |              |              |           |
| Decrypt · AES-192-GCM (OS)                        | 128KB        |  18,934.55 ns |   252.102 ns |   223.482 ns |         - |
| Decrypt · AES-192-GCM (CryptoHives-ARM-AES+PMULL) | 128KB        |  37,539.67 ns |   744.789 ns | 1,975.074 ns |         - |
| Decrypt · AES-192-GCM (BouncyCastle)              | 128KB        | 572,669.09 ns | 2,374.270 ns | 2,104.728 ns |    1640 B |
| Decrypt · AES-192-GCM (CryptoHives-Scalar)        | 128KB        | 758,834.76 ns | 6,975.623 ns | 5,824.961 ns |         - |
|                                                   |              |               |              |              |           |
| Encrypt · AES-192-GCM (OS)                        | 128KB        |  20,303.26 ns |   211.055 ns |   187.095 ns |         - |
| Encrypt · AES-192-GCM (CryptoHives-ARM-AES+PMULL) | 128KB        |  36,276.19 ns |   658.446 ns | 1,252.762 ns |         - |
| Encrypt · AES-192-GCM (BouncyCastle)              | 128KB        | 618,063.04 ns | 1,613.915 ns | 1,347.693 ns |    1624 B |
| Encrypt · AES-192-GCM (CryptoHives-Scalar)        | 128KB        | 751,662.45 ns | 3,966.173 ns | 3,096.527 ns |         - |