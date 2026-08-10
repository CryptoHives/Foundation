| Description                                | TestDataSize | Mean           | Error       | StdDev      | Allocated |
|------------------------------------------- |------------- |---------------:|------------:|------------:|----------:|
| Decrypt · AES-256-CCM (CryptoHives-AES-NI) | 128B         |       446.6 ns |     0.69 ns |     0.65 ns |         - |
| Decrypt · AES-256-CCM (CryptoHives-Scalar) | 128B         |     1,256.2 ns |     4.73 ns |     4.42 ns |         - |
| Decrypt · AES-256-CCM (BouncyCastle)       | 128B         |     1,942.7 ns |     8.74 ns |     8.18 ns |    2808 B |
|                                            |              |                |             |             |           |
| Encrypt · AES-256-CCM (CryptoHives-AES-NI) | 128B         |       412.9 ns |     0.57 ns |     0.53 ns |         - |
| Encrypt · AES-256-CCM (CryptoHives-Scalar) | 128B         |     1,214.2 ns |     4.22 ns |     3.94 ns |         - |
| Encrypt · AES-256-CCM (BouncyCastle)       | 128B         |     1,903.9 ns |     6.58 ns |     6.15 ns |    2848 B |
|                                            |              |                |             |             |           |
| Decrypt · AES-256-CCM (CryptoHives-AES-NI) | 1KB          |     2,730.3 ns |     4.44 ns |     4.16 ns |         - |
| Decrypt · AES-256-CCM (CryptoHives-Scalar) | 1KB          |     7,981.7 ns |    27.43 ns |    24.32 ns |         - |
| Decrypt · AES-256-CCM (BouncyCastle)       | 1KB          |    10,070.9 ns |    46.31 ns |    43.32 ns |    2808 B |
|                                            |              |                |             |             |           |
| Encrypt · AES-256-CCM (CryptoHives-AES-NI) | 1KB          |     2,694.5 ns |     3.04 ns |     2.70 ns |         - |
| Encrypt · AES-256-CCM (CryptoHives-Scalar) | 1KB          |     7,942.8 ns |    28.15 ns |    26.33 ns |         - |
| Encrypt · AES-256-CCM (BouncyCastle)       | 1KB          |    10,012.1 ns |    39.86 ns |    37.29 ns |    2848 B |
|                                            |              |                |             |             |           |
| Decrypt · AES-256-CCM (CryptoHives-AES-NI) | 8KB          |    21,046.4 ns |    25.56 ns |    23.91 ns |         - |
| Decrypt · AES-256-CCM (CryptoHives-Scalar) | 8KB          |    61,670.3 ns |   237.07 ns |   210.16 ns |         - |
| Decrypt · AES-256-CCM (BouncyCastle)       | 8KB          |    74,571.4 ns |   388.74 ns |   363.63 ns |    2808 B |
|                                            |              |                |             |             |           |
| Encrypt · AES-256-CCM (CryptoHives-AES-NI) | 8KB          |    20,973.4 ns |    25.71 ns |    24.05 ns |         - |
| Encrypt · AES-256-CCM (CryptoHives-Scalar) | 8KB          |    61,837.6 ns |   196.67 ns |   183.96 ns |         - |
| Encrypt · AES-256-CCM (BouncyCastle)       | 8KB          |    74,922.0 ns |   312.18 ns |   292.01 ns |    2848 B |
|                                            |              |                |             |             |           |
| Decrypt · AES-256-CCM (CryptoHives-AES-NI) | 128KB        |   334,196.8 ns |   238.04 ns |   222.66 ns |         - |
| Decrypt · AES-256-CCM (CryptoHives-Scalar) | 128KB        |   985,478.8 ns | 5,687.86 ns | 5,320.43 ns |         - |
| Decrypt · AES-256-CCM (BouncyCastle)       | 128KB        | 1,181,242.9 ns | 4,068.32 ns | 3,805.51 ns |    2808 B |
|                                            |              |                |             |             |           |
| Encrypt · AES-256-CCM (CryptoHives-AES-NI) | 128KB        |   334,282.6 ns |   366.60 ns |   342.91 ns |         - |
| Encrypt · AES-256-CCM (CryptoHives-Scalar) | 128KB        |   985,928.2 ns | 4,992.46 ns | 4,168.93 ns |         - |
| Encrypt · AES-256-CCM (BouncyCastle)       | 128KB        | 1,182,530.1 ns | 4,696.97 ns | 4,393.55 ns |    2848 B |