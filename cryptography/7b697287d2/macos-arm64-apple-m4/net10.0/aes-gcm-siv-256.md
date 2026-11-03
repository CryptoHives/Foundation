| Description                                     | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|------------------------------------------------ |------------- |-------------:|------------:|------------:|----------:|
| Decrypt · AES-256-GCM-SIV (CryptoHives-ARM-AES) | 128B         |     660.9 ns |     5.60 ns |     4.96 ns |         - |
| Decrypt · AES-256-GCM-SIV (CryptoHives-Scalar)  | 128B         |   1,374.4 ns |    10.28 ns |     9.62 ns |         - |
| Decrypt · AES-256-GCM-SIV (BouncyCastle)        | 128B         |   1,625.5 ns |     2.38 ns |     2.23 ns |    3408 B |
|                                                 |              |              |             |             |           |
| Encrypt · AES-256-GCM-SIV (CryptoHives-ARM-AES) | 128B         |     625.6 ns |    11.73 ns |    10.97 ns |         - |
| Encrypt · AES-256-GCM-SIV (CryptoHives-Scalar)  | 128B         |   1,334.7 ns |     4.63 ns |     4.11 ns |         - |
| Encrypt · AES-256-GCM-SIV (BouncyCastle)        | 128B         |   1,786.5 ns |     1.16 ns |     1.08 ns |    3000 B |
|                                                 |              |              |             |             |           |
| Decrypt · AES-256-GCM-SIV (CryptoHives-ARM-AES) | 1KB          |   3,075.2 ns |     8.66 ns |     7.23 ns |         - |
| Decrypt · AES-256-GCM-SIV (CryptoHives-Scalar)  | 1KB          |   6,801.1 ns |    17.10 ns |    15.99 ns |         - |
| Decrypt · AES-256-GCM-SIV (BouncyCastle)        | 1KB          |   6,912.9 ns |     4.87 ns |     4.32 ns |    7832 B |
|                                                 |              |              |             |             |           |
| Encrypt · AES-256-GCM-SIV (CryptoHives-ARM-AES) | 1KB          |   3,045.4 ns |    10.80 ns |    10.10 ns |         - |
| Encrypt · AES-256-GCM-SIV (CryptoHives-Scalar)  | 1KB          |   6,759.2 ns |     9.71 ns |     9.08 ns |         - |
| Encrypt · AES-256-GCM-SIV (BouncyCastle)        | 1KB          |   7,175.3 ns |     3.12 ns |     2.77 ns |    3768 B |
|                                                 |              |              |             |             |           |
| Decrypt · AES-256-GCM-SIV (CryptoHives-ARM-AES) | 8KB          |  22,431.2 ns |    76.32 ns |    71.39 ns |         - |
| Decrypt · AES-256-GCM-SIV (BouncyCastle)        | 8KB          |  48,677.8 ns |    74.83 ns |    69.99 ns |   43744 B |
| Decrypt · AES-256-GCM-SIV (CryptoHives-Scalar)  | 8KB          |  50,130.1 ns |   112.33 ns |   105.08 ns |         - |
|                                                 |              |              |             |             |           |
| Encrypt · AES-256-GCM-SIV (CryptoHives-ARM-AES) | 8KB          |  22,393.1 ns |    62.14 ns |    58.13 ns |         - |
| Encrypt · AES-256-GCM-SIV (BouncyCastle)        | 8KB          |  50,035.2 ns |    43.13 ns |    40.34 ns |   10936 B |
| Encrypt · AES-256-GCM-SIV (CryptoHives-Scalar)  | 8KB          |  50,146.5 ns |   165.24 ns |   154.56 ns |         - |
|                                                 |              |              |             |             |           |
| Decrypt · AES-256-GCM-SIV (CryptoHives-ARM-AES) | 128KB        | 354,362.1 ns | 1,146.14 ns | 1,072.10 ns |         - |
| Decrypt · AES-256-GCM-SIV (BouncyCastle)        | 128KB        | 789,643.6 ns |   507.91 ns |   475.10 ns |  658352 B |
| Decrypt · AES-256-GCM-SIV (CryptoHives-Scalar)  | 128KB        | 792,882.8 ns | 1,479.68 ns | 1,384.09 ns |         - |
|                                                 |              |              |             |             |           |
| Encrypt · AES-256-GCM-SIV (CryptoHives-ARM-AES) | 128KB        | 354,302.2 ns | 1,293.15 ns | 1,209.61 ns |         - |
| Encrypt · AES-256-GCM-SIV (BouncyCastle)        | 128KB        | 788,138.8 ns |   477.62 ns |   446.77 ns |  133844 B |
| Encrypt · AES-256-GCM-SIV (CryptoHives-Scalar)  | 128KB        | 794,209.1 ns | 1,858.70 ns | 1,738.62 ns |         - |