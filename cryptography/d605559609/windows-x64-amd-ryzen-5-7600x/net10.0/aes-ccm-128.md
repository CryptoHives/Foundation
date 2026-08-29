| Description                                | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|
| Decrypt · AES-128-CCM (CryptoHives-AES-NI) | 128B         |     402.3 ns |     1.11 ns |     1.04 ns |         - |
| Decrypt · AES-128-CCM (CryptoHives-Scalar) | 128B         |   1,019.3 ns |     4.83 ns |     4.51 ns |         - |
| Decrypt · AES-128-CCM (BouncyCastle)       | 128B         |   1,548.9 ns |     7.51 ns |     6.66 ns |    2616 B |
|                                            |              |              |             |             |           |
| Encrypt · AES-128-CCM (CryptoHives-AES-NI) | 128B         |     356.0 ns |     4.81 ns |     4.02 ns |         - |
| Encrypt · AES-128-CCM (CryptoHives-Scalar) | 128B         |     916.9 ns |     4.90 ns |     4.35 ns |         - |
| Encrypt · AES-128-CCM (BouncyCastle)       | 128B         |   1,502.1 ns |     8.55 ns |     7.58 ns |    2504 B |
|                                            |              |              |             |             |           |
| Decrypt · AES-128-CCM (CryptoHives-AES-NI) | 1KB          |   2,319.1 ns |    24.26 ns |    22.69 ns |         - |
| Decrypt · AES-128-CCM (CryptoHives-Scalar) | 1KB          |   6,019.6 ns |    66.40 ns |    62.11 ns |         - |
| Decrypt · AES-128-CCM (BouncyCastle)       | 1KB          |   8,200.0 ns |    44.71 ns |    39.63 ns |    3512 B |
|                                            |              |              |             |             |           |
| Encrypt · AES-128-CCM (CryptoHives-AES-NI) | 1KB          |   2,262.1 ns |    20.38 ns |    15.91 ns |         - |
| Encrypt · AES-128-CCM (CryptoHives-Scalar) | 1KB          |   5,981.6 ns |    25.23 ns |    22.37 ns |         - |
| Encrypt · AES-128-CCM (BouncyCastle)       | 1KB          |   8,139.6 ns |    46.33 ns |    43.34 ns |    2504 B |
|                                            |              |              |             |             |           |
| Decrypt · AES-128-CCM (CryptoHives-AES-NI) | 8KB          |  17,820.8 ns |   351.88 ns |   418.89 ns |         - |
| Decrypt · AES-128-CCM (CryptoHives-Scalar) | 8KB          |  46,366.2 ns |   411.53 ns |   343.64 ns |         - |
| Decrypt · AES-128-CCM (BouncyCastle)       | 8KB          |  61,164.4 ns |   283.86 ns |   265.52 ns |   10680 B |
|                                            |              |              |             |             |           |
| Encrypt · AES-128-CCM (CryptoHives-AES-NI) | 8KB          |  17,498.6 ns |    36.71 ns |    32.54 ns |         - |
| Encrypt · AES-128-CCM (CryptoHives-Scalar) | 8KB          |  46,244.9 ns |   214.82 ns |   190.43 ns |         - |
| Encrypt · AES-128-CCM (BouncyCastle)       | 8KB          |  60,769.5 ns |   332.18 ns |   310.73 ns |    2504 B |
|                                            |              |              |             |             |           |
| Decrypt · AES-128-CCM (CryptoHives-AES-NI) | 128KB        | 278,876.4 ns | 1,620.04 ns | 1,352.81 ns |         - |
| Decrypt · AES-128-CCM (CryptoHives-Scalar) | 128KB        | 737,094.5 ns | 3,848.97 ns | 3,600.33 ns |         - |
| Decrypt · AES-128-CCM (BouncyCastle)       | 128KB        | 997,213.2 ns | 4,088.24 ns | 3,413.87 ns |  133574 B |
|                                            |              |              |             |             |           |
| Encrypt · AES-128-CCM (CryptoHives-AES-NI) | 128KB        | 282,820.3 ns | 5,550.02 ns | 7,216.60 ns |         - |
| Encrypt · AES-128-CCM (CryptoHives-Scalar) | 128KB        | 794,640.7 ns | 2,826.13 ns | 2,505.29 ns |         - |
| Encrypt · AES-128-CCM (BouncyCastle)       | 128KB        | 965,045.5 ns | 4,372.54 ns | 4,090.08 ns |    2504 B |