| Description                                 | TestDataSize | Mean           | Error       | StdDev      | Allocated |
|-------------------------------------------- |------------- |---------------:|------------:|------------:|----------:|
| Decrypt · AES-256-CCM (CryptoHives-ARM-AES) | 128B         |       309.1 ns |     1.14 ns |     0.89 ns |         - |
| Decrypt · AES-256-CCM (CryptoHives-Scalar)  | 128B         |     1,269.5 ns |    21.14 ns |    19.78 ns |         - |
| Decrypt · AES-256-CCM (BouncyCastle)        | 128B         |     1,736.7 ns |    22.04 ns |    20.62 ns |    3016 B |
|                                             |              |                |             |             |           |
| Encrypt · AES-256-CCM (CryptoHives-ARM-AES) | 128B         |       273.3 ns |     0.45 ns |     0.35 ns |         - |
| Encrypt · AES-256-CCM (CryptoHives-Scalar)  | 128B         |     1,215.7 ns |     4.91 ns |     3.83 ns |         - |
| Encrypt · AES-256-CCM (BouncyCastle)        | 128B         |     1,677.2 ns |    24.17 ns |    22.60 ns |    2904 B |
|                                             |              |                |             |             |           |
| Decrypt · AES-256-CCM (CryptoHives-ARM-AES) | 1KB          |     1,779.5 ns |    21.29 ns |    19.91 ns |         - |
| Decrypt · AES-256-CCM (CryptoHives-Scalar)  | 1KB          |     7,983.7 ns |    11.41 ns |     8.90 ns |         - |
| Decrypt · AES-256-CCM (BouncyCastle)        | 1KB          |     8,922.2 ns |     9.37 ns |     7.32 ns |    3912 B |
|                                             |              |                |             |             |           |
| Encrypt · AES-256-CCM (CryptoHives-ARM-AES) | 1KB          |     1,737.6 ns |    20.07 ns |    18.78 ns |         - |
| Encrypt · AES-256-CCM (CryptoHives-Scalar)  | 1KB          |     7,938.0 ns |     9.84 ns |     7.68 ns |         - |
| Encrypt · AES-256-CCM (BouncyCastle)        | 1KB          |     8,878.2 ns |   168.60 ns |   165.59 ns |    2904 B |
|                                             |              |                |             |             |           |
| Decrypt · AES-256-CCM (CryptoHives-ARM-AES) | 8KB          |    13,402.2 ns |   143.23 ns |   133.98 ns |         - |
| Decrypt · AES-256-CCM (CryptoHives-Scalar)  | 8KB          |    61,646.1 ns |    62.45 ns |    48.75 ns |         - |
| Decrypt · AES-256-CCM (BouncyCastle)        | 8KB          |    66,273.7 ns |   357.40 ns |   279.04 ns |   11080 B |
|                                             |              |                |             |             |           |
| Encrypt · AES-256-CCM (CryptoHives-ARM-AES) | 8KB          |    13,370.4 ns |   172.52 ns |   161.37 ns |         - |
| Encrypt · AES-256-CCM (CryptoHives-Scalar)  | 8KB          |    61,639.9 ns |    26.53 ns |    20.71 ns |         - |
| Encrypt · AES-256-CCM (BouncyCastle)        | 8KB          |    65,777.2 ns |   122.74 ns |    95.83 ns |    2904 B |
|                                             |              |                |             |             |           |
| Decrypt · AES-256-CCM (CryptoHives-ARM-AES) | 128KB        |   213,840.1 ns | 2,756.42 ns | 2,578.35 ns |         - |
| Decrypt · AES-256-CCM (CryptoHives-Scalar)  | 128KB        |   992,823.1 ns | 2,466.52 ns | 1,925.70 ns |         - |
| Decrypt · AES-256-CCM (BouncyCastle)        | 128KB        | 1,068,454.1 ns | 1,228.33 ns |   959.00 ns |  133988 B |
|                                             |              |                |             |             |           |
| Encrypt · AES-256-CCM (CryptoHives-ARM-AES) | 128KB        |   213,368.2 ns | 2,613.82 ns | 2,444.97 ns |         - |
| Encrypt · AES-256-CCM (CryptoHives-Scalar)  | 128KB        |   983,052.2 ns | 1,372.72 ns | 1,071.73 ns |         - |
| Encrypt · AES-256-CCM (BouncyCastle)        | 128KB        | 1,058,008.2 ns |   354.09 ns |   276.45 ns |    2904 B |