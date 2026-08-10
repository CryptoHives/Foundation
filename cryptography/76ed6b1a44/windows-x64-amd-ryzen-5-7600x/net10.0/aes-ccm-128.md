| Description                                | TestDataSize | Mean         | Error        | StdDev       | Allocated |
|------------------------------------------- |------------- |-------------:|-------------:|-------------:|----------:|
| Decrypt · AES-128-CCM (CryptoHives-AES-NI) | 128B         |     418.3 ns |      7.98 ns |      7.47 ns |         - |
| Decrypt · AES-128-CCM (CryptoHives-Scalar) | 128B         |   1,070.0 ns |     21.21 ns |     26.05 ns |         - |
| Decrypt · AES-128-CCM (BouncyCastle)       | 128B         |   1,716.2 ns |     19.62 ns |     17.39 ns |    2424 B |
|                                            |              |              |              |              |           |
| Encrypt · AES-128-CCM (CryptoHives-AES-NI) | 128B         |     364.5 ns |      6.20 ns |      5.80 ns |         - |
| Encrypt · AES-128-CCM (CryptoHives-Scalar) | 128B         |   1,003.4 ns |     13.55 ns |     10.58 ns |         - |
| Encrypt · AES-128-CCM (BouncyCastle)       | 128B         |   1,757.5 ns |     29.06 ns |     25.76 ns |    2464 B |
|                                            |              |              |              |              |           |
| Decrypt · AES-128-CCM (CryptoHives-AES-NI) | 1KB          |   2,336.5 ns |     17.23 ns |     16.11 ns |         - |
| Decrypt · AES-128-CCM (CryptoHives-Scalar) | 1KB          |   6,615.6 ns |     79.02 ns |     73.91 ns |         - |
| Decrypt · AES-128-CCM (BouncyCastle)       | 1KB          |   8,636.4 ns |    168.74 ns |    225.26 ns |    2424 B |
|                                            |              |              |              |              |           |
| Encrypt · AES-128-CCM (CryptoHives-AES-NI) | 1KB          |   2,311.9 ns |     17.76 ns |     14.83 ns |         - |
| Encrypt · AES-128-CCM (CryptoHives-Scalar) | 1KB          |   6,596.1 ns |    125.07 ns |    116.99 ns |         - |
| Encrypt · AES-128-CCM (BouncyCastle)       | 1KB          |   8,374.1 ns |     82.37 ns |     64.31 ns |    2464 B |
|                                            |              |              |              |              |           |
| Decrypt · AES-128-CCM (CryptoHives-AES-NI) | 8KB          |  17,996.4 ns |    358.47 ns |    317.78 ns |         - |
| Decrypt · AES-128-CCM (CryptoHives-Scalar) | 8KB          |  52,370.2 ns |  1,043.40 ns |  1,319.57 ns |         - |
| Decrypt · AES-128-CCM (BouncyCastle)       | 8KB          |  62,866.2 ns |  1,246.30 ns |  1,620.55 ns |    2424 B |
|                                            |              |              |              |              |           |
| Encrypt · AES-128-CCM (CryptoHives-AES-NI) | 8KB          |  17,691.0 ns |    105.30 ns |     87.93 ns |         - |
| Encrypt · AES-128-CCM (CryptoHives-Scalar) | 8KB          |  52,439.0 ns |    975.09 ns |  1,366.94 ns |         - |
| Encrypt · AES-128-CCM (BouncyCastle)       | 8KB          |  62,662.2 ns |  1,224.23 ns |  1,409.82 ns |    2464 B |
|                                            |              |              |              |              |           |
| Decrypt · AES-128-CCM (CryptoHives-AES-NI) | 128KB        | 286,031.8 ns |  5,501.22 ns |  5,649.35 ns |         - |
| Decrypt · AES-128-CCM (CryptoHives-Scalar) | 128KB        | 817,828.2 ns | 14,740.85 ns | 13,067.38 ns |         - |
| Decrypt · AES-128-CCM (BouncyCastle)       | 128KB        | 986,481.5 ns | 15,046.89 ns | 13,338.68 ns |    2424 B |
|                                            |              |              |              |              |           |
| Encrypt · AES-128-CCM (CryptoHives-AES-NI) | 128KB        | 281,794.7 ns |  2,710.52 ns |  2,263.41 ns |         - |
| Encrypt · AES-128-CCM (CryptoHives-Scalar) | 128KB        | 819,973.2 ns | 15,710.71 ns | 16,133.74 ns |         - |
| Encrypt · AES-128-CCM (BouncyCastle)       | 128KB        | 998,539.2 ns | 18,955.60 ns | 17,731.08 ns |    2464 B |