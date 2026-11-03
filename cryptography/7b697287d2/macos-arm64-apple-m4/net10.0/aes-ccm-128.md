| Description                                 | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|-------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|
| Decrypt · AES-128-CCM (CryptoHives-ARM-AES) | 128B         |     196.4 ns |     0.62 ns |     0.58 ns |         - |
| Decrypt · AES-128-CCM (CryptoHives-Scalar)  | 128B         |     861.8 ns |     0.72 ns |     0.68 ns |         - |
| Decrypt · AES-128-CCM (BouncyCastle)        | 128B         |   1,352.7 ns |     1.63 ns |     1.52 ns |    2616 B |
|                                             |              |              |             |             |           |
| Encrypt · AES-128-CCM (CryptoHives-ARM-AES) | 128B         |     154.8 ns |     0.65 ns |     0.61 ns |         - |
| Encrypt · AES-128-CCM (CryptoHives-Scalar)  | 128B         |     813.5 ns |     0.33 ns |     0.31 ns |         - |
| Encrypt · AES-128-CCM (BouncyCastle)        | 128B         |   1,299.1 ns |     1.20 ns |     1.12 ns |    2504 B |
|                                             |              |              |             |             |           |
| Decrypt · AES-128-CCM (CryptoHives-ARM-AES) | 1KB          |     947.2 ns |     3.35 ns |     3.14 ns |         - |
| Decrypt · AES-128-CCM (CryptoHives-Scalar)  | 1KB          |   5,302.8 ns |     2.30 ns |     2.16 ns |         - |
| Decrypt · AES-128-CCM (BouncyCastle)        | 1KB          |   6,815.0 ns |     2.93 ns |     2.29 ns |    3512 B |
|                                             |              |              |             |             |           |
| Encrypt · AES-128-CCM (CryptoHives-ARM-AES) | 1KB          |     901.3 ns |     2.12 ns |     1.88 ns |         - |
| Encrypt · AES-128-CCM (CryptoHives-Scalar)  | 1KB          |   5,253.7 ns |     3.08 ns |     2.88 ns |         - |
| Encrypt · AES-128-CCM (BouncyCastle)        | 1KB          |   6,703.2 ns |     4.35 ns |     4.07 ns |    2504 B |
|                                             |              |              |             |             |           |
| Decrypt · AES-128-CCM (CryptoHives-ARM-AES) | 8KB          |   6,927.7 ns |    21.69 ns |    20.29 ns |         - |
| Decrypt · AES-128-CCM (CryptoHives-Scalar)  | 8KB          |  40,855.3 ns |    65.55 ns |    58.10 ns |         - |
| Decrypt · AES-128-CCM (BouncyCastle)        | 8KB          |  50,161.4 ns |    30.20 ns |    26.77 ns |   10680 B |
|                                             |              |              |             |             |           |
| Encrypt · AES-128-CCM (CryptoHives-ARM-AES) | 8KB          |   6,830.3 ns |    23.66 ns |    22.13 ns |         - |
| Encrypt · AES-128-CCM (CryptoHives-Scalar)  | 8KB          |  40,770.6 ns |    30.63 ns |    25.58 ns |         - |
| Encrypt · AES-128-CCM (BouncyCastle)        | 8KB          |  49,990.3 ns |    44.70 ns |    41.81 ns |    2504 B |
|                                             |              |              |             |             |           |
| Decrypt · AES-128-CCM (CryptoHives-ARM-AES) | 128KB        | 108,957.7 ns |   368.59 ns |   344.78 ns |         - |
| Decrypt · AES-128-CCM (CryptoHives-Scalar)  | 128KB        | 649,668.9 ns | 1,027.39 ns |   961.02 ns |         - |
| Decrypt · AES-128-CCM (BouncyCastle)        | 128KB        | 806,237.6 ns |   566.12 ns |   529.55 ns |  133588 B |
|                                             |              |              |             |             |           |
| Encrypt · AES-128-CCM (CryptoHives-ARM-AES) | 128KB        | 108,922.7 ns |   483.59 ns |   452.35 ns |         - |
| Encrypt · AES-128-CCM (CryptoHives-Scalar)  | 128KB        | 661,972.7 ns | 7,617.55 ns | 7,125.47 ns |         - |
| Encrypt · AES-128-CCM (BouncyCastle)        | 128KB        | 802,408.6 ns | 1,471.09 ns | 1,304.08 ns |    2504 B |