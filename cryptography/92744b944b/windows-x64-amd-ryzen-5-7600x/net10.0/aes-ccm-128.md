| Description                                | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|
| Decrypt · AES-128-CCM (CryptoHives-AES-NI) | 128B         |     399.1 ns |     0.54 ns |     0.51 ns |         - |
| Decrypt · AES-128-CCM (CryptoHives-Scalar) | 128B         |     988.4 ns |     4.42 ns |     4.13 ns |         - |
| Decrypt · AES-128-CCM (BouncyCastle)       | 128B         |   1,599.4 ns |    11.14 ns |     9.88 ns |    2424 B |
|                                            |              |              |             |             |           |
| Encrypt · AES-128-CCM (CryptoHives-AES-NI) | 128B         |     350.7 ns |     0.49 ns |     0.43 ns |         - |
| Encrypt · AES-128-CCM (CryptoHives-Scalar) | 128B         |     956.3 ns |     4.17 ns |     3.90 ns |         - |
| Encrypt · AES-128-CCM (BouncyCastle)       | 128B         |   1,561.5 ns |    13.94 ns |    12.36 ns |    2464 B |
|                                            |              |              |             |             |           |
| Decrypt · AES-128-CCM (CryptoHives-AES-NI) | 1KB          |   2,281.6 ns |     3.96 ns |     3.70 ns |         - |
| Decrypt · AES-128-CCM (CryptoHives-Scalar) | 1KB          |   6,251.7 ns |    12.71 ns |    11.27 ns |         - |
| Decrypt · AES-128-CCM (BouncyCastle)       | 1KB          |   7,998.5 ns |    42.92 ns |    40.14 ns |    2424 B |
|                                            |              |              |             |             |           |
| Encrypt · AES-128-CCM (CryptoHives-AES-NI) | 1KB          |   2,239.2 ns |     3.13 ns |     2.93 ns |         - |
| Encrypt · AES-128-CCM (CryptoHives-Scalar) | 1KB          |   6,207.7 ns |    11.41 ns |     9.53 ns |         - |
| Encrypt · AES-128-CCM (BouncyCastle)       | 1KB          |   7,994.5 ns |    30.19 ns |    28.24 ns |    2464 B |
|                                            |              |              |             |             |           |
| Decrypt · AES-128-CCM (CryptoHives-AES-NI) | 8KB          |  17,480.9 ns |    33.36 ns |    31.20 ns |         - |
| Decrypt · AES-128-CCM (CryptoHives-Scalar) | 8KB          |  48,275.4 ns |   154.19 ns |   144.23 ns |         - |
| Decrypt · AES-128-CCM (BouncyCastle)       | 8KB          |  58,976.9 ns |   253.61 ns |   237.23 ns |    2424 B |
|                                            |              |              |             |             |           |
| Encrypt · AES-128-CCM (CryptoHives-AES-NI) | 8KB          |  17,385.0 ns |    21.97 ns |    20.55 ns |         - |
| Encrypt · AES-128-CCM (CryptoHives-Scalar) | 8KB          |  48,211.8 ns |   233.97 ns |   218.86 ns |         - |
| Encrypt · AES-128-CCM (BouncyCastle)       | 8KB          |  58,909.2 ns |   125.34 ns |   111.11 ns |    2464 B |
|                                            |              |              |             |             |           |
| Decrypt · AES-128-CCM (CryptoHives-AES-NI) | 128KB        | 277,037.5 ns |   518.83 ns |   485.32 ns |         - |
| Decrypt · AES-128-CCM (CryptoHives-Scalar) | 128KB        | 768,752.6 ns | 2,447.15 ns | 2,289.07 ns |         - |
| Decrypt · AES-128-CCM (BouncyCastle)       | 128KB        | 933,584.1 ns | 3,067.61 ns | 2,869.44 ns |    2424 B |
|                                            |              |              |             |             |           |
| Encrypt · AES-128-CCM (CryptoHives-AES-NI) | 128KB        | 276,953.8 ns |   341.10 ns |   319.07 ns |         - |
| Encrypt · AES-128-CCM (CryptoHives-Scalar) | 128KB        | 770,092.3 ns | 1,219.94 ns | 1,081.44 ns |         - |
| Encrypt · AES-128-CCM (BouncyCastle)       | 128KB        | 934,335.8 ns | 2,759.48 ns | 2,446.21 ns |    2464 B |