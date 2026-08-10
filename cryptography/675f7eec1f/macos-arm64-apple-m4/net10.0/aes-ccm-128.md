| Description                                 | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|-------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|
| Decrypt · AES-128-CCM (CryptoHives-ARM-AES) | 128B         |     281.3 ns |     0.81 ns |     0.76 ns |         - |
| Decrypt · AES-128-CCM (CryptoHives-Scalar)  | 128B         |     965.3 ns |     0.73 ns |     0.68 ns |         - |
| Decrypt · AES-128-CCM (BouncyCastle)        | 128B         |   1,453.5 ns |     6.36 ns |     5.31 ns |    2424 B |
|                                             |              |              |             |             |           |
| Encrypt · AES-128-CCM (CryptoHives-ARM-AES) | 128B         |     243.5 ns |     0.68 ns |     0.60 ns |         - |
| Encrypt · AES-128-CCM (CryptoHives-Scalar)  | 128B         |     919.0 ns |     0.73 ns |     0.61 ns |         - |
| Encrypt · AES-128-CCM (BouncyCastle)        | 128B         |   1,407.1 ns |     1.40 ns |     1.31 ns |    2464 B |
|                                             |              |              |             |             |           |
| Decrypt · AES-128-CCM (CryptoHives-ARM-AES) | 1KB          |   1,585.7 ns |     0.65 ns |     0.58 ns |         - |
| Decrypt · AES-128-CCM (CryptoHives-Scalar)  | 1KB          |   6,028.0 ns |    14.27 ns |    13.35 ns |         - |
| Decrypt · AES-128-CCM (BouncyCastle)        | 1KB          |   6,900.9 ns |     4.51 ns |     4.22 ns |    2424 B |
|                                             |              |              |             |             |           |
| Encrypt · AES-128-CCM (CryptoHives-ARM-AES) | 1KB          |   1,546.1 ns |     4.17 ns |     3.70 ns |         - |
| Encrypt · AES-128-CCM (CryptoHives-Scalar)  | 1KB          |   5,993.1 ns |     2.24 ns |     1.87 ns |         - |
| Encrypt · AES-128-CCM (BouncyCastle)        | 1KB          |   6,874.3 ns |    12.72 ns |    11.90 ns |    2464 B |
|                                             |              |              |             |             |           |
| Decrypt · AES-128-CCM (CryptoHives-ARM-AES) | 8KB          |  11,939.7 ns |    26.01 ns |    23.06 ns |         - |
| Decrypt · AES-128-CCM (CryptoHives-Scalar)  | 8KB          |  46,520.9 ns |    36.98 ns |    34.60 ns |         - |
| Decrypt · AES-128-CCM (BouncyCastle)        | 8KB          |  50,312.3 ns |    34.35 ns |    32.13 ns |    2424 B |
|                                             |              |              |             |             |           |
| Encrypt · AES-128-CCM (CryptoHives-ARM-AES) | 8KB          |  11,887.8 ns |    32.99 ns |    27.55 ns |         - |
| Encrypt · AES-128-CCM (CryptoHives-Scalar)  | 8KB          |  46,496.2 ns |    29.85 ns |    27.92 ns |         - |
| Encrypt · AES-128-CCM (BouncyCastle)        | 8KB          |  50,283.8 ns |    46.64 ns |    43.63 ns |    2464 B |
|                                             |              |              |             |             |           |
| Decrypt · AES-128-CCM (CryptoHives-ARM-AES) | 128KB        | 188,963.8 ns |    98.10 ns |    86.97 ns |         - |
| Decrypt · AES-128-CCM (CryptoHives-Scalar)  | 128KB        | 741,216.0 ns | 1,074.96 ns |   897.64 ns |         - |
| Decrypt · AES-128-CCM (BouncyCastle)        | 128KB        | 802,202.7 ns |   566.85 ns |   530.23 ns |    2424 B |
|                                             |              |              |             |             |           |
| Encrypt · AES-128-CCM (CryptoHives-ARM-AES) | 128KB        | 189,016.5 ns |   518.36 ns |   459.51 ns |         - |
| Encrypt · AES-128-CCM (CryptoHives-Scalar)  | 128KB        | 741,170.6 ns |   334.30 ns |   279.16 ns |         - |
| Encrypt · AES-128-CCM (BouncyCastle)        | 128KB        | 797,213.1 ns | 1,967.77 ns | 1,840.65 ns |    2464 B |