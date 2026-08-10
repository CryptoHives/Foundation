| Description                                 | TestDataSize | Mean           | Error     | StdDev    | Allocated |
|-------------------------------------------- |------------- |---------------:|----------:|----------:|----------:|
| Decrypt · AES-256-CCM (CryptoHives-ARM-AES) | 128B         |       307.7 ns |   0.63 ns |   0.59 ns |         - |
| Decrypt · AES-256-CCM (CryptoHives-Scalar)  | 128B         |     1,252.8 ns |   0.77 ns |   0.64 ns |         - |
| Decrypt · AES-256-CCM (BouncyCastle)        | 128B         |     1,807.3 ns |   2.40 ns |   2.25 ns |    2808 B |
|                                             |              |                |           |           |           |
| Encrypt · AES-256-CCM (CryptoHives-ARM-AES) | 128B         |       271.0 ns |   0.33 ns |   0.30 ns |         - |
| Encrypt · AES-256-CCM (CryptoHives-Scalar)  | 128B         |     1,209.3 ns |   0.47 ns |   0.44 ns |         - |
| Encrypt · AES-256-CCM (BouncyCastle)        | 128B         |     1,759.6 ns |   0.84 ns |   0.74 ns |    2848 B |
|                                             |              |                |           |           |           |
| Decrypt · AES-256-CCM (CryptoHives-ARM-AES) | 1KB          |     1,742.3 ns |   2.72 ns |   2.55 ns |         - |
| Decrypt · AES-256-CCM (CryptoHives-Scalar)  | 1KB          |     8,051.2 ns |   1.68 ns |   1.49 ns |         - |
| Decrypt · AES-256-CCM (BouncyCastle)        | 1KB          |     8,921.5 ns |   6.03 ns |   5.35 ns |    2808 B |
|                                             |              |                |           |           |           |
| Encrypt · AES-256-CCM (CryptoHives-ARM-AES) | 1KB          |     1,704.6 ns |   1.92 ns |   1.70 ns |         - |
| Encrypt · AES-256-CCM (CryptoHives-Scalar)  | 1KB          |     7,904.1 ns |   2.70 ns |   2.53 ns |         - |
| Encrypt · AES-256-CCM (BouncyCastle)        | 1KB          |     8,884.8 ns |   4.87 ns |   4.55 ns |    2848 B |
|                                             |              |                |           |           |           |
| Decrypt · AES-256-CCM (CryptoHives-ARM-AES) | 8KB          |    13,151.6 ns |  28.84 ns |  25.57 ns |         - |
| Decrypt · AES-256-CCM (CryptoHives-Scalar)  | 8KB          |    61,426.7 ns |  23.03 ns |  17.98 ns |         - |
| Decrypt · AES-256-CCM (BouncyCastle)        | 8KB          |    65,671.8 ns |  90.82 ns |  80.51 ns |    2808 B |
|                                             |              |                |           |           |           |
| Encrypt · AES-256-CCM (CryptoHives-ARM-AES) | 8KB          |    13,111.9 ns |  33.27 ns |  29.50 ns |         - |
| Encrypt · AES-256-CCM (CryptoHives-Scalar)  | 8KB          |    61,372.1 ns |  84.31 ns |  70.40 ns |         - |
| Encrypt · AES-256-CCM (BouncyCastle)        | 8KB          |    65,466.4 ns |  19.28 ns |  18.03 ns |    2848 B |
|                                             |              |                |           |           |           |
| Decrypt · AES-256-CCM (CryptoHives-ARM-AES) | 128KB        |   209,624.1 ns | 260.19 ns | 243.38 ns |         - |
| Decrypt · AES-256-CCM (CryptoHives-Scalar)  | 128KB        |   978,324.4 ns | 181.35 ns | 169.63 ns |         - |
| Decrypt · AES-256-CCM (BouncyCastle)        | 128KB        | 1,056,633.1 ns | 766.94 ns | 717.39 ns |    2808 B |
|                                             |              |                |           |           |           |
| Encrypt · AES-256-CCM (CryptoHives-ARM-AES) | 128KB        |   208,898.2 ns | 277.94 ns | 246.39 ns |         - |
| Encrypt · AES-256-CCM (CryptoHives-Scalar)  | 128KB        |   978,369.4 ns | 296.87 ns | 277.69 ns |         - |
| Encrypt · AES-256-CCM (BouncyCastle)        | 128KB        | 1,042,585.9 ns | 316.74 ns | 280.78 ns |    2848 B |