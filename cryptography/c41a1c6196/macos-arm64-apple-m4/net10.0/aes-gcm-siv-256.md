| Description                                     | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|------------------------------------------------ |------------- |-------------:|------------:|------------:|----------:|
| Decrypt · AES-256-GCM-SIV (CryptoHives-ARM-AES) | 128B         |     667.6 ns |    12.22 ns |    10.83 ns |         - |
| Decrypt · AES-256-GCM-SIV (CryptoHives-Scalar)  | 128B         |   1,392.0 ns |     5.69 ns |     5.05 ns |         - |
| Decrypt · AES-256-GCM-SIV (BouncyCastle)        | 128B         |   1,648.5 ns |     2.02 ns |     1.79 ns |    3408 B |
|                                                 |              |              |             |             |           |
| Encrypt · AES-256-GCM-SIV (CryptoHives-ARM-AES) | 128B         |     630.0 ns |     9.12 ns |     8.53 ns |         - |
| Encrypt · AES-256-GCM-SIV (CryptoHives-Scalar)  | 128B         |   1,352.4 ns |     5.24 ns |     4.64 ns |         - |
| Encrypt · AES-256-GCM-SIV (BouncyCastle)        | 128B         |   1,809.2 ns |     3.62 ns |     3.21 ns |    3000 B |
|                                                 |              |              |             |             |           |
| Decrypt · AES-256-GCM-SIV (CryptoHives-ARM-AES) | 1KB          |   3,141.6 ns |    12.21 ns |    11.42 ns |         - |
| Decrypt · AES-256-GCM-SIV (CryptoHives-Scalar)  | 1KB          |   6,872.5 ns |    19.07 ns |    17.84 ns |         - |
| Decrypt · AES-256-GCM-SIV (BouncyCastle)        | 1KB          |   6,992.7 ns |     9.23 ns |     8.64 ns |    7832 B |
|                                                 |              |              |             |             |           |
| Encrypt · AES-256-GCM-SIV (CryptoHives-ARM-AES) | 1KB          |   3,088.9 ns |    15.95 ns |    14.92 ns |         - |
| Encrypt · AES-256-GCM-SIV (CryptoHives-Scalar)  | 1KB          |   6,828.9 ns |    17.13 ns |    16.02 ns |         - |
| Encrypt · AES-256-GCM-SIV (BouncyCastle)        | 1KB          |   7,256.7 ns |    13.08 ns |    12.24 ns |    3768 B |
|                                                 |              |              |             |             |           |
| Decrypt · AES-256-GCM-SIV (CryptoHives-ARM-AES) | 8KB          |  22,816.9 ns |    74.71 ns |    69.89 ns |         - |
| Decrypt · AES-256-GCM-SIV (BouncyCastle)        | 8KB          |  50,198.4 ns |   235.58 ns |   220.36 ns |   43744 B |
| Decrypt · AES-256-GCM-SIV (CryptoHives-Scalar)  | 8KB          |  50,638.7 ns |    85.54 ns |    80.02 ns |         - |
|                                                 |              |              |             |             |           |
| Encrypt · AES-256-GCM-SIV (CryptoHives-ARM-AES) | 8KB          |  22,795.4 ns |    41.09 ns |    38.44 ns |         - |
| Encrypt · AES-256-GCM-SIV (CryptoHives-Scalar)  | 8KB          |  50,654.1 ns |    88.27 ns |    78.25 ns |         - |
| Encrypt · AES-256-GCM-SIV (BouncyCastle)        | 8KB          |  51,025.5 ns |    91.66 ns |    85.74 ns |   10936 B |
|                                                 |              |              |             |             |           |
| Decrypt · AES-256-GCM-SIV (CryptoHives-ARM-AES) | 128KB        | 360,648.9 ns | 2,006.57 ns | 1,876.95 ns |         - |
| Decrypt · AES-256-GCM-SIV (BouncyCastle)        | 128KB        | 795,814.6 ns |   737.88 ns |   690.22 ns |  658352 B |
| Decrypt · AES-256-GCM-SIV (CryptoHives-Scalar)  | 128KB        | 801,342.3 ns | 1,202.63 ns | 1,004.25 ns |         - |
|                                                 |              |              |             |             |           |
| Encrypt · AES-256-GCM-SIV (CryptoHives-ARM-AES) | 128KB        | 360,520.7 ns | 1,224.38 ns | 1,085.38 ns |         - |
| Encrypt · AES-256-GCM-SIV (BouncyCastle)        | 128KB        | 792,679.9 ns |   875.85 ns |   819.27 ns |  133844 B |
| Encrypt · AES-256-GCM-SIV (CryptoHives-Scalar)  | 128KB        | 801,461.7 ns | 1,510.91 ns | 1,261.68 ns |         - |