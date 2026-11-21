| Description                                 | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|-------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|
| Decrypt · AES-128-CCM (CryptoHives-ARM-AES) | 128B         |     205.0 ns |     0.35 ns |     0.31 ns |         - |
| Decrypt · AES-128-CCM (CryptoHives-Scalar)  | 128B         |     871.3 ns |     0.43 ns |     0.40 ns |         - |
| Decrypt · AES-128-CCM (BouncyCastle)        | 128B         |   1,338.3 ns |     2.70 ns |     2.40 ns |    2584 B |
|                                             |              |              |             |             |           |
| Encrypt · AES-128-CCM (CryptoHives-ARM-AES) | 128B         |     167.1 ns |     0.51 ns |     0.45 ns |         - |
| Encrypt · AES-128-CCM (CryptoHives-Scalar)  | 128B         |     821.6 ns |     1.21 ns |     1.13 ns |         - |
| Encrypt · AES-128-CCM (BouncyCastle)        | 128B         |   1,299.1 ns |     2.87 ns |     2.68 ns |    2432 B |
|                                             |              |              |             |             |           |
| Decrypt · AES-128-CCM (CryptoHives-ARM-AES) | 1KB          |   1,003.7 ns |     4.31 ns |     4.03 ns |         - |
| Decrypt · AES-128-CCM (CryptoHives-Scalar)  | 1KB          |   5,364.5 ns |    18.41 ns |    17.22 ns |         - |
| Decrypt · AES-128-CCM (BouncyCastle)        | 1KB          |   6,826.3 ns |     8.64 ns |     8.08 ns |    3480 B |
|                                             |              |              |             |             |           |
| Encrypt · AES-128-CCM (CryptoHives-ARM-AES) | 1KB          |     933.2 ns |     3.29 ns |     2.75 ns |         - |
| Encrypt · AES-128-CCM (CryptoHives-Scalar)  | 1KB          |   5,301.0 ns |     5.67 ns |     5.30 ns |         - |
| Encrypt · AES-128-CCM (BouncyCastle)        | 1KB          |   6,850.9 ns |     7.42 ns |     6.95 ns |    2432 B |
|                                             |              |              |             |             |           |
| Decrypt · AES-128-CCM (CryptoHives-ARM-AES) | 8KB          |   7,319.0 ns |    15.83 ns |    14.04 ns |         - |
| Decrypt · AES-128-CCM (CryptoHives-Scalar)  | 8KB          |  41,434.2 ns |    69.45 ns |    64.97 ns |         - |
| Decrypt · AES-128-CCM (BouncyCastle)        | 8KB          |  50,685.5 ns |   173.42 ns |   162.22 ns |   10648 B |
|                                             |              |              |             |             |           |
| Encrypt · AES-128-CCM (CryptoHives-ARM-AES) | 8KB          |   7,068.1 ns |    25.25 ns |    23.61 ns |         - |
| Encrypt · AES-128-CCM (CryptoHives-Scalar)  | 8KB          |  41,072.2 ns |    55.30 ns |    51.73 ns |         - |
| Encrypt · AES-128-CCM (BouncyCastle)        | 8KB          |  51,381.3 ns |    62.59 ns |    48.87 ns |    2432 B |
|                                             |              |              |             |             |           |
| Decrypt · AES-128-CCM (CryptoHives-ARM-AES) | 128KB        | 117,307.2 ns |   266.53 ns |   249.31 ns |         - |
| Decrypt · AES-128-CCM (CryptoHives-Scalar)  | 128KB        | 660,390.1 ns | 1,678.12 ns | 1,569.72 ns |         - |
| Decrypt · AES-128-CCM (BouncyCastle)        | 128KB        | 811,674.8 ns |   655.45 ns |   581.04 ns |  133554 B |
|                                             |              |              |             |             |           |
| Encrypt · AES-128-CCM (CryptoHives-ARM-AES) | 128KB        | 113,437.1 ns |   328.98 ns |   307.72 ns |         - |
| Encrypt · AES-128-CCM (CryptoHives-Scalar)  | 128KB        | 654,703.9 ns | 1,097.33 ns | 1,026.44 ns |         - |
| Encrypt · AES-128-CCM (BouncyCastle)        | 128KB        | 816,511.5 ns |   846.11 ns |   791.45 ns |    2432 B |