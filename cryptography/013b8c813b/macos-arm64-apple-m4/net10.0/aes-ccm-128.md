| Description                                 | TestDataSize | Mean         | Error     | StdDev    | Allocated |
|-------------------------------------------- |------------- |-------------:|----------:|----------:|----------:|
| Decrypt · AES-128-CCM (CryptoHives-ARM-AES) | 128B         |     279.8 ns |   0.12 ns |   0.10 ns |         - |
| Decrypt · AES-128-CCM (CryptoHives-Scalar)  | 128B         |     958.4 ns |   0.49 ns |   0.45 ns |         - |
| Decrypt · AES-128-CCM (BouncyCastle)        | 128B         |   1,447.1 ns |   1.42 ns |   1.26 ns |    2424 B |
|                                             |              |              |           |           |           |
| Encrypt · AES-128-CCM (CryptoHives-ARM-AES) | 128B         |     243.0 ns |   0.38 ns |   0.32 ns |         - |
| Encrypt · AES-128-CCM (CryptoHives-Scalar)  | 128B         |     922.0 ns |   0.24 ns |   0.22 ns |         - |
| Encrypt · AES-128-CCM (BouncyCastle)        | 128B         |   1,398.9 ns |   1.04 ns |   0.97 ns |    2464 B |
|                                             |              |              |           |           |           |
| Decrypt · AES-128-CCM (CryptoHives-ARM-AES) | 1KB          |   1,569.7 ns |   1.54 ns |   1.37 ns |         - |
| Decrypt · AES-128-CCM (CryptoHives-Scalar)  | 1KB          |   5,992.7 ns |   1.87 ns |   1.66 ns |         - |
| Decrypt · AES-128-CCM (BouncyCastle)        | 1KB          |   6,892.1 ns |   5.37 ns |   4.19 ns |    2424 B |
|                                             |              |              |           |           |           |
| Encrypt · AES-128-CCM (CryptoHives-ARM-AES) | 1KB          |   1,537.4 ns |   1.39 ns |   1.30 ns |         - |
| Encrypt · AES-128-CCM (CryptoHives-Scalar)  | 1KB          |   5,957.0 ns |   1.73 ns |   1.53 ns |         - |
| Encrypt · AES-128-CCM (BouncyCastle)        | 1KB          |   6,836.5 ns |   5.20 ns |   4.86 ns |    2464 B |
|                                             |              |              |           |           |           |
| Decrypt · AES-128-CCM (CryptoHives-ARM-AES) | 8KB          |  11,836.4 ns |  15.60 ns |  13.83 ns |         - |
| Decrypt · AES-128-CCM (CryptoHives-Scalar)  | 8KB          |  46,222.8 ns |   6.91 ns |   6.46 ns |         - |
| Decrypt · AES-128-CCM (BouncyCastle)        | 8KB          |  50,122.1 ns |  18.06 ns |  16.89 ns |    2424 B |
|                                             |              |              |           |           |           |
| Encrypt · AES-128-CCM (CryptoHives-ARM-AES) | 8KB          |  11,796.4 ns |  11.17 ns |   9.90 ns |         - |
| Encrypt · AES-128-CCM (CryptoHives-Scalar)  | 8KB          |  46,166.9 ns |   7.87 ns |   7.36 ns |         - |
| Encrypt · AES-128-CCM (BouncyCastle)        | 8KB          |  49,993.8 ns |  14.17 ns |  11.06 ns |    2464 B |
|                                             |              |              |           |           |           |
| Decrypt · AES-128-CCM (CryptoHives-ARM-AES) | 128KB        | 189,387.4 ns | 167.50 ns | 148.49 ns |         - |
| Decrypt · AES-128-CCM (CryptoHives-Scalar)  | 128KB        | 736,442.0 ns | 104.72 ns |  97.95 ns |         - |
| Decrypt · AES-128-CCM (BouncyCastle)        | 128KB        | 793,476.2 ns | 316.57 ns | 296.12 ns |    2424 B |
|                                             |              |              |           |           |           |
| Encrypt · AES-128-CCM (CryptoHives-ARM-AES) | 128KB        | 187,476.9 ns | 274.05 ns | 256.34 ns |         - |
| Encrypt · AES-128-CCM (CryptoHives-Scalar)  | 128KB        | 736,311.0 ns | 122.17 ns | 114.28 ns |         - |
| Encrypt · AES-128-CCM (BouncyCastle)        | 128KB        | 794,560.2 ns | 272.32 ns | 254.73 ns |    2464 B |