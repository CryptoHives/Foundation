| Description                                     | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|------------------------------------------------ |------------- |-------------:|------------:|------------:|----------:|
| Decrypt · AES-128-GCM-SIV (CryptoHives-ARM-AES) | 128B         |     624.1 ns |     4.57 ns |     4.05 ns |         - |
| Decrypt · AES-128-GCM-SIV (CryptoHives-Scalar)  | 128B         |   1,086.1 ns |     4.20 ns |     3.72 ns |         - |
| Decrypt · AES-128-GCM-SIV (BouncyCastle)        | 128B         |   1,268.9 ns |     6.41 ns |     6.00 ns |    2992 B |
|                                                 |              |              |             |             |           |
| Encrypt · AES-128-GCM-SIV (CryptoHives-ARM-AES) | 128B         |     584.9 ns |    11.24 ns |    11.03 ns |         - |
| Encrypt · AES-128-GCM-SIV (CryptoHives-Scalar)  | 128B         |   1,046.0 ns |     4.29 ns |     4.02 ns |         - |
| Encrypt · AES-128-GCM-SIV (BouncyCastle)        | 128B         |   1,440.5 ns |     2.01 ns |     1.88 ns |    2584 B |
|                                                 |              |              |             |             |           |
| Decrypt · AES-128-GCM-SIV (CryptoHives-ARM-AES) | 1KB          |   3,068.4 ns |     7.37 ns |     6.16 ns |         - |
| Decrypt · AES-128-GCM-SIV (CryptoHives-Scalar)  | 1KB          |   5,743.3 ns |    15.26 ns |    13.53 ns |         - |
| Decrypt · AES-128-GCM-SIV (BouncyCastle)        | 1KB          |   5,789.4 ns |    11.78 ns |    11.02 ns |    7416 B |
|                                                 |              |              |             |             |           |
| Encrypt · AES-128-GCM-SIV (CryptoHives-ARM-AES) | 1KB          |   3,038.6 ns |    13.66 ns |    12.11 ns |         - |
| Encrypt · AES-128-GCM-SIV (CryptoHives-Scalar)  | 1KB          |   5,720.4 ns |    15.06 ns |    14.09 ns |         - |
| Encrypt · AES-128-GCM-SIV (BouncyCastle)        | 1KB          |   6,028.1 ns |     7.75 ns |     6.87 ns |    3352 B |
|                                                 |              |              |             |             |           |
| Decrypt · AES-128-GCM-SIV (CryptoHives-ARM-AES) | 8KB          |  22,600.3 ns |    34.09 ns |    28.47 ns |         - |
| Decrypt · AES-128-GCM-SIV (BouncyCastle)        | 8KB          |  41,653.6 ns |   215.97 ns |   202.02 ns |   43328 B |
| Decrypt · AES-128-GCM-SIV (CryptoHives-Scalar)  | 8KB          |  43,006.7 ns |    90.56 ns |    84.71 ns |         - |
|                                                 |              |              |             |             |           |
| Encrypt · AES-128-GCM-SIV (CryptoHives-ARM-AES) | 8KB          |  22,594.0 ns |   110.47 ns |   103.33 ns |         - |
| Encrypt · AES-128-GCM-SIV (BouncyCastle)        | 8KB          |  42,701.8 ns |   106.94 ns |    94.80 ns |   10520 B |
| Encrypt · AES-128-GCM-SIV (CryptoHives-Scalar)  | 8KB          |  43,031.7 ns |   138.81 ns |   129.84 ns |         - |
|                                                 |              |              |             |             |           |
| Decrypt · AES-128-GCM-SIV (CryptoHives-ARM-AES) | 128KB        | 357,403.7 ns | 1,453.96 ns | 1,288.90 ns |         - |
| Decrypt · AES-128-GCM-SIV (BouncyCastle)        | 128KB        | 655,769.8 ns | 1,782.88 ns | 1,667.71 ns |  657936 B |
| Decrypt · AES-128-GCM-SIV (CryptoHives-Scalar)  | 128KB        | 681,302.6 ns | 2,652.45 ns | 2,351.33 ns |         - |
|                                                 |              |              |             |             |           |
| Encrypt · AES-128-GCM-SIV (CryptoHives-ARM-AES) | 128KB        | 357,215.4 ns | 1,236.88 ns | 1,156.98 ns |         - |
| Encrypt · AES-128-GCM-SIV (BouncyCastle)        | 128KB        | 668,761.9 ns |   662.17 ns |   619.39 ns |  133428 B |
| Encrypt · AES-128-GCM-SIV (CryptoHives-Scalar)  | 128KB        | 682,441.7 ns | 3,860.46 ns | 3,611.08 ns |         - |