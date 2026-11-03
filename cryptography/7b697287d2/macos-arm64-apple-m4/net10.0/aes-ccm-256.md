| Description                                 | TestDataSize | Mean           | Error     | StdDev    | Allocated |
|-------------------------------------------- |------------- |---------------:|----------:|----------:|----------:|
| Decrypt · AES-256-CCM (CryptoHives-ARM-AES) | 128B         |       218.4 ns |   0.78 ns |   0.73 ns |         - |
| Decrypt · AES-256-CCM (CryptoHives-Scalar)  | 128B         |     1,152.6 ns |   0.98 ns |   0.92 ns |         - |
| Decrypt · AES-256-CCM (BouncyCastle)        | 128B         |     1,709.4 ns |   3.52 ns |   3.29 ns |    3016 B |
|                                             |              |                |           |           |           |
| Encrypt · AES-256-CCM (CryptoHives-ARM-AES) | 128B         |       179.8 ns |   0.78 ns |   0.73 ns |         - |
| Encrypt · AES-256-CCM (CryptoHives-Scalar)  | 128B         |     1,108.2 ns |   0.81 ns |   0.76 ns |         - |
| Encrypt · AES-256-CCM (BouncyCastle)        | 128B         |     1,652.0 ns |   2.67 ns |   2.37 ns |    2904 B |
|                                             |              |                |           |           |           |
| Decrypt · AES-256-CCM (CryptoHives-ARM-AES) | 1KB          |     1,093.5 ns |   5.62 ns |   5.26 ns |         - |
| Decrypt · AES-256-CCM (CryptoHives-Scalar)  | 1KB          |     7,226.0 ns |   3.91 ns |   3.46 ns |         - |
| Decrypt · AES-256-CCM (BouncyCastle)        | 1KB          |     8,884.9 ns |   2.39 ns |   2.23 ns |    3912 B |
|                                             |              |                |           |           |           |
| Encrypt · AES-256-CCM (CryptoHives-ARM-AES) | 1KB          |     1,047.5 ns |   7.42 ns |   6.94 ns |         - |
| Encrypt · AES-256-CCM (CryptoHives-Scalar)  | 1KB          |     7,180.4 ns |   3.84 ns |   3.60 ns |         - |
| Encrypt · AES-256-CCM (BouncyCastle)        | 1KB          |     8,756.8 ns |   3.05 ns |   2.71 ns |    2904 B |
|                                             |              |                |           |           |           |
| Decrypt · AES-256-CCM (CryptoHives-ARM-AES) | 8KB          |     8,029.7 ns |  39.40 ns |  36.86 ns |         - |
| Decrypt · AES-256-CCM (CryptoHives-Scalar)  | 8KB          |    56,290.7 ns | 667.92 ns | 624.78 ns |         - |
| Decrypt · AES-256-CCM (BouncyCastle)        | 8KB          |    66,023.4 ns |  29.74 ns |  24.84 ns |   11080 B |
|                                             |              |                |           |           |           |
| Encrypt · AES-256-CCM (CryptoHives-ARM-AES) | 8KB          |     7,992.0 ns |  58.32 ns |  54.55 ns |         - |
| Encrypt · AES-256-CCM (CryptoHives-Scalar)  | 8KB          |    55,740.4 ns |  40.61 ns |  37.99 ns |         - |
| Encrypt · AES-256-CCM (BouncyCastle)        | 8KB          |    65,516.8 ns |  35.53 ns |  33.24 ns |    2904 B |
|                                             |              |                |           |           |           |
| Decrypt · AES-256-CCM (CryptoHives-ARM-AES) | 128KB        |   127,458.0 ns | 846.37 ns | 791.69 ns |         - |
| Decrypt · AES-256-CCM (CryptoHives-Scalar)  | 128KB        |   887,172.8 ns | 743.44 ns | 620.80 ns |         - |
| Decrypt · AES-256-CCM (BouncyCastle)        | 128KB        | 1,054,113.9 ns | 721.64 ns | 675.02 ns |  133988 B |
|                                             |              |                |           |           |           |
| Encrypt · AES-256-CCM (CryptoHives-ARM-AES) | 128KB        |   127,399.5 ns | 694.95 ns | 650.06 ns |         - |
| Encrypt · AES-256-CCM (CryptoHives-Scalar)  | 128KB        |   887,125.5 ns | 733.71 ns | 686.32 ns |         - |
| Encrypt · AES-256-CCM (BouncyCastle)        | 128KB        | 1,040,424.8 ns | 543.27 ns | 508.18 ns |    2904 B |