| Description                                 | TestDataSize | Mean           | Error       | StdDev      | Allocated |
|-------------------------------------------- |------------- |---------------:|------------:|------------:|----------:|
| Decrypt · AES-256-CCM (CryptoHives-ARM-AES) | 128B         |       231.0 ns |     0.33 ns |     0.29 ns |         - |
| Decrypt · AES-256-CCM (CryptoHives-Scalar)  | 128B         |     1,165.6 ns |     1.80 ns |     1.68 ns |         - |
| Decrypt · AES-256-CCM (BouncyCastle)        | 128B         |     1,701.1 ns |     2.37 ns |     2.22 ns |    2984 B |
|                                             |              |                |             |             |           |
| Encrypt · AES-256-CCM (CryptoHives-ARM-AES) | 128B         |       188.3 ns |     0.70 ns |     0.62 ns |         - |
| Encrypt · AES-256-CCM (CryptoHives-Scalar)  | 128B         |     1,123.2 ns |     0.93 ns |     0.83 ns |         - |
| Encrypt · AES-256-CCM (BouncyCastle)        | 128B         |     1,666.4 ns |     2.58 ns |     2.42 ns |    2832 B |
|                                             |              |                |             |             |           |
| Decrypt · AES-256-CCM (CryptoHives-ARM-AES) | 1KB          |     1,167.5 ns |     5.47 ns |     5.12 ns |         - |
| Decrypt · AES-256-CCM (CryptoHives-Scalar)  | 1KB          |     7,311.1 ns |     8.95 ns |     7.93 ns |         - |
| Decrypt · AES-256-CCM (BouncyCastle)        | 1KB          |     8,829.4 ns |    16.67 ns |    14.78 ns |    3880 B |
|                                             |              |                |             |             |           |
| Encrypt · AES-256-CCM (CryptoHives-ARM-AES) | 1KB          |     1,099.5 ns |     5.69 ns |     5.32 ns |         - |
| Encrypt · AES-256-CCM (CryptoHives-Scalar)  | 1KB          |     7,247.7 ns |     7.76 ns |     7.26 ns |         - |
| Encrypt · AES-256-CCM (BouncyCastle)        | 1KB          |     8,895.7 ns |    45.02 ns |    39.91 ns |    2832 B |
|                                             |              |                |             |             |           |
| Decrypt · AES-256-CCM (CryptoHives-ARM-AES) | 8KB          |     8,603.0 ns |    24.76 ns |    20.67 ns |         - |
| Decrypt · AES-256-CCM (CryptoHives-Scalar)  | 8KB          |    56,437.6 ns |   180.54 ns |   168.88 ns |         - |
| Decrypt · AES-256-CCM (BouncyCastle)        | 8KB          |    66,106.2 ns |   125.91 ns |   117.78 ns |   11048 B |
|                                             |              |                |             |             |           |
| Encrypt · AES-256-CCM (CryptoHives-ARM-AES) | 8KB          |     8,257.4 ns |    61.96 ns |    57.96 ns |         - |
| Encrypt · AES-256-CCM (CryptoHives-Scalar)  | 8KB          |    56,199.0 ns |    71.31 ns |    66.70 ns |         - |
| Encrypt · AES-256-CCM (BouncyCastle)        | 8KB          |    66,798.5 ns |   166.70 ns |   155.93 ns |    2832 B |
|                                             |              |                |             |             |           |
| Decrypt · AES-256-CCM (CryptoHives-ARM-AES) | 128KB        |   138,109.0 ns | 1,032.23 ns |   965.55 ns |         - |
| Decrypt · AES-256-CCM (CryptoHives-Scalar)  | 128KB        |   899,920.4 ns | 1,069.75 ns | 1,000.64 ns |         - |
| Decrypt · AES-256-CCM (BouncyCastle)        | 128KB        | 1,054,032.7 ns | 1,817.07 ns | 1,610.79 ns |  133954 B |
|                                             |              |                |             |             |           |
| Encrypt · AES-256-CCM (CryptoHives-ARM-AES) | 128KB        |   131,404.3 ns |   676.91 ns |   633.18 ns |         - |
| Encrypt · AES-256-CCM (CryptoHives-Scalar)  | 128KB        |   896,311.0 ns |   765.50 ns |   716.05 ns |         - |
| Encrypt · AES-256-CCM (BouncyCastle)        | 128KB        | 1,068,529.1 ns | 2,629.09 ns | 2,459.25 ns |    2832 B |