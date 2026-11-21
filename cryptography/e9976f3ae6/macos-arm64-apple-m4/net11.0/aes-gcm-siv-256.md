| Description                                     | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|------------------------------------------------ |------------- |-------------:|------------:|------------:|----------:|
| Decrypt · AES-256-GCM-SIV (CryptoHives-ARM-AES) | 128B         |     671.5 ns |     7.27 ns |     6.80 ns |         - |
| Decrypt · AES-256-GCM-SIV (CryptoHives-Scalar)  | 128B         |   1,395.5 ns |     5.85 ns |     5.19 ns |         - |
| Decrypt · AES-256-GCM-SIV (BouncyCastle)        | 128B         |   1,626.5 ns |     2.57 ns |     2.41 ns |    3408 B |
|                                                 |              |              |             |             |           |
| Encrypt · AES-256-GCM-SIV (CryptoHives-ARM-AES) | 128B         |     638.1 ns |     7.78 ns |     7.27 ns |         - |
| Encrypt · AES-256-GCM-SIV (CryptoHives-Scalar)  | 128B         |   1,355.2 ns |     4.11 ns |     3.84 ns |         - |
| Encrypt · AES-256-GCM-SIV (BouncyCastle)        | 128B         |   1,758.9 ns |     3.79 ns |     3.36 ns |    3000 B |
|                                                 |              |              |             |             |           |
| Decrypt · AES-256-GCM-SIV (CryptoHives-ARM-AES) | 1KB          |   3,148.6 ns |     7.80 ns |     6.09 ns |         - |
| Decrypt · AES-256-GCM-SIV (CryptoHives-Scalar)  | 1KB          |   6,850.1 ns |    17.18 ns |    16.07 ns |         - |
| Decrypt · AES-256-GCM-SIV (BouncyCastle)        | 1KB          |   6,971.7 ns |    13.50 ns |    12.63 ns |    7832 B |
|                                                 |              |              |             |             |           |
| Encrypt · AES-256-GCM-SIV (CryptoHives-ARM-AES) | 1KB          |   3,111.9 ns |     6.81 ns |     6.04 ns |         - |
| Encrypt · AES-256-GCM-SIV (CryptoHives-Scalar)  | 1KB          |   6,811.0 ns |    14.52 ns |    13.58 ns |         - |
| Encrypt · AES-256-GCM-SIV (BouncyCastle)        | 1KB          |   6,971.1 ns |     7.85 ns |     7.34 ns |    3768 B |
|                                                 |              |              |             |             |           |
| Decrypt · AES-256-GCM-SIV (CryptoHives-ARM-AES) | 8KB          |  22,890.2 ns |    67.71 ns |    56.54 ns |         - |
| Decrypt · AES-256-GCM-SIV (BouncyCastle)        | 8KB          |  49,479.5 ns |   220.31 ns |   206.08 ns |   43744 B |
| Decrypt · AES-256-GCM-SIV (CryptoHives-Scalar)  | 8KB          |  50,403.2 ns |    69.95 ns |    62.01 ns |         - |
|                                                 |              |              |             |             |           |
| Encrypt · AES-256-GCM-SIV (CryptoHives-ARM-AES) | 8KB          |  22,865.4 ns |    46.59 ns |    43.58 ns |         - |
| Encrypt · AES-256-GCM-SIV (BouncyCastle)        | 8KB          |  48,702.4 ns |    93.01 ns |    87.00 ns |   10936 B |
| Encrypt · AES-256-GCM-SIV (CryptoHives-Scalar)  | 8KB          |  50,341.0 ns |   126.59 ns |   118.41 ns |         - |
|                                                 |              |              |             |             |           |
| Decrypt · AES-256-GCM-SIV (CryptoHives-ARM-AES) | 128KB        | 361,548.9 ns | 1,109.37 ns | 1,037.70 ns |         - |
| Decrypt · AES-256-GCM-SIV (CryptoHives-Scalar)  | 128KB        | 799,522.3 ns | 1,665.55 ns | 1,557.96 ns |         - |
| Decrypt · AES-256-GCM-SIV (BouncyCastle)        | 128KB        | 810,852.8 ns |   969.10 ns |   906.50 ns |  658399 B |
|                                                 |              |              |             |             |           |
| Encrypt · AES-256-GCM-SIV (CryptoHives-ARM-AES) | 128KB        | 361,450.8 ns | 1,439.42 ns | 1,346.43 ns |         - |
| Encrypt · AES-256-GCM-SIV (BouncyCastle)        | 128KB        | 768,141.5 ns |   730.73 ns |   570.51 ns |  133855 B |
| Encrypt · AES-256-GCM-SIV (CryptoHives-Scalar)  | 128KB        | 797,165.4 ns | 2,613.70 ns | 2,444.86 ns |         - |