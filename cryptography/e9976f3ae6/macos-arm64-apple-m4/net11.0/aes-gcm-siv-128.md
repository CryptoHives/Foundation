| Description                                     | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|------------------------------------------------ |------------- |-------------:|------------:|------------:|----------:|
| Decrypt · AES-128-GCM-SIV (CryptoHives-ARM-AES) | 128B         |     629.5 ns |     5.76 ns |     5.39 ns |         - |
| Decrypt · AES-128-GCM-SIV (CryptoHives-Scalar)  | 128B         |   1,070.8 ns |     6.87 ns |     6.43 ns |         - |
| Decrypt · AES-128-GCM-SIV (BouncyCastle)        | 128B         |   1,250.7 ns |     2.78 ns |     2.60 ns |    2992 B |
|                                                 |              |              |             |             |           |
| Encrypt · AES-128-GCM-SIV (CryptoHives-ARM-AES) | 128B         |     598.3 ns |     5.34 ns |     4.99 ns |         - |
| Encrypt · AES-128-GCM-SIV (CryptoHives-Scalar)  | 128B         |   1,040.9 ns |     5.34 ns |     4.73 ns |         - |
| Encrypt · AES-128-GCM-SIV (BouncyCastle)        | 128B         |   1,423.9 ns |     1.64 ns |     1.45 ns |    2584 B |
|                                                 |              |              |             |             |           |
| Decrypt · AES-128-GCM-SIV (CryptoHives-ARM-AES) | 1KB          |   3,096.7 ns |    12.60 ns |    11.79 ns |         - |
| Decrypt · AES-128-GCM-SIV (CryptoHives-Scalar)  | 1KB          |   5,715.0 ns |    13.23 ns |    12.37 ns |         - |
| Decrypt · AES-128-GCM-SIV (BouncyCastle)        | 1KB          |   5,738.1 ns |    15.29 ns |    14.30 ns |    7416 B |
|                                                 |              |              |             |             |           |
| Encrypt · AES-128-GCM-SIV (CryptoHives-ARM-AES) | 1KB          |   3,069.2 ns |     7.31 ns |     5.70 ns |         - |
| Encrypt · AES-128-GCM-SIV (CryptoHives-Scalar)  | 1KB          |   5,693.3 ns |     9.36 ns |     8.76 ns |         - |
| Encrypt · AES-128-GCM-SIV (BouncyCastle)        | 1KB          |   5,765.8 ns |    15.03 ns |    14.06 ns |    3352 B |
|                                                 |              |              |             |             |           |
| Decrypt · AES-128-GCM-SIV (CryptoHives-ARM-AES) | 8KB          |  22,716.5 ns |    60.76 ns |    53.86 ns |         - |
| Decrypt · AES-128-GCM-SIV (BouncyCastle)        | 8KB          |  41,275.9 ns |    98.99 ns |    92.60 ns |   43328 B |
| Decrypt · AES-128-GCM-SIV (CryptoHives-Scalar)  | 8KB          |  42,786.6 ns |   135.66 ns |   126.90 ns |         - |
|                                                 |              |              |             |             |           |
| Encrypt · AES-128-GCM-SIV (CryptoHives-ARM-AES) | 8KB          |  22,743.3 ns |    56.52 ns |    47.20 ns |         - |
| Encrypt · AES-128-GCM-SIV (BouncyCastle)        | 8KB          |  40,760.8 ns |   108.55 ns |   101.53 ns |   10520 B |
| Encrypt · AES-128-GCM-SIV (CryptoHives-Scalar)  | 8KB          |  42,796.2 ns |   159.50 ns |   149.19 ns |         - |
|                                                 |              |              |             |             |           |
| Decrypt · AES-128-GCM-SIV (CryptoHives-ARM-AES) | 128KB        | 359,180.5 ns | 1,311.06 ns | 1,226.37 ns |         - |
| Decrypt · AES-128-GCM-SIV (CryptoHives-Scalar)  | 128KB        | 679,754.0 ns | 1,341.99 ns | 1,189.64 ns |         - |
| Decrypt · AES-128-GCM-SIV (BouncyCastle)        | 128KB        | 684,942.6 ns | 1,832.20 ns | 1,713.84 ns |  657983 B |
|                                                 |              |              |             |             |           |
| Encrypt · AES-128-GCM-SIV (CryptoHives-ARM-AES) | 128KB        | 360,439.2 ns | 1,010.74 ns |   945.44 ns |         - |
| Encrypt · AES-128-GCM-SIV (BouncyCastle)        | 128KB        | 646,703.7 ns |   542.42 ns |   507.38 ns |  133439 B |
| Encrypt · AES-128-GCM-SIV (CryptoHives-Scalar)  | 128KB        | 680,548.6 ns | 1,606.97 ns | 1,503.17 ns |         - |