| Description                                 | TestDataSize | Mean           | Error       | StdDev      | Allocated |
|-------------------------------------------- |------------- |---------------:|------------:|------------:|----------:|
| Decrypt · AES-256-CCM (CryptoHives-ARM-AES) | 128B         |       221.9 ns |     0.54 ns |     0.48 ns |         - |
| Decrypt · AES-256-CCM (CryptoHives-Scalar)  | 128B         |     1,160.7 ns |     6.57 ns |     5.82 ns |         - |
| Decrypt · AES-256-CCM (BouncyCastle)        | 128B         |     1,731.1 ns |     4.95 ns |     4.39 ns |    3016 B |
|                                             |              |                |             |             |           |
| Encrypt · AES-256-CCM (CryptoHives-ARM-AES) | 128B         |       184.2 ns |     0.47 ns |     0.41 ns |         - |
| Encrypt · AES-256-CCM (CryptoHives-Scalar)  | 128B         |     1,115.6 ns |     3.73 ns |     3.12 ns |         - |
| Encrypt · AES-256-CCM (BouncyCastle)        | 128B         |     1,669.8 ns |     4.41 ns |     3.91 ns |    2904 B |
|                                             |              |                |             |             |           |
| Decrypt · AES-256-CCM (CryptoHives-ARM-AES) | 1KB          |     1,120.4 ns |     6.96 ns |     6.17 ns |         - |
| Decrypt · AES-256-CCM (CryptoHives-Scalar)  | 1KB          |     7,225.9 ns |     8.47 ns |     7.92 ns |         - |
| Decrypt · AES-256-CCM (BouncyCastle)        | 1KB          |     8,891.6 ns |     3.81 ns |     3.56 ns |    3912 B |
|                                             |              |                |             |             |           |
| Encrypt · AES-256-CCM (CryptoHives-ARM-AES) | 1KB          |     1,085.9 ns |     5.01 ns |     4.68 ns |         - |
| Encrypt · AES-256-CCM (CryptoHives-Scalar)  | 1KB          |     7,182.3 ns |    10.66 ns |     9.97 ns |         - |
| Encrypt · AES-256-CCM (BouncyCastle)        | 1KB          |     8,904.8 ns |   104.36 ns |    92.51 ns |    2904 B |
|                                             |              |                |             |             |           |
| Decrypt · AES-256-CCM (CryptoHives-ARM-AES) | 8KB          |     8,324.9 ns |    60.21 ns |    56.32 ns |         - |
| Decrypt · AES-256-CCM (CryptoHives-Scalar)  | 8KB          |    56,211.8 ns |   110.56 ns |   103.42 ns |         - |
| Decrypt · AES-256-CCM (BouncyCastle)        | 8KB          |    66,109.9 ns |   109.17 ns |    91.16 ns |   11080 B |
|                                             |              |                |             |             |           |
| Encrypt · AES-256-CCM (CryptoHives-ARM-AES) | 8KB          |     8,344.9 ns |    61.67 ns |    54.67 ns |         - |
| Encrypt · AES-256-CCM (CryptoHives-Scalar)  | 8KB          |    56,151.6 ns |   155.38 ns |   145.34 ns |         - |
| Encrypt · AES-256-CCM (BouncyCastle)        | 8KB          |    65,508.3 ns |    31.10 ns |    29.09 ns |    2904 B |
|                                             |              |                |             |             |           |
| Decrypt · AES-256-CCM (CryptoHives-ARM-AES) | 128KB        |   134,667.6 ns |   647.35 ns |   605.53 ns |         - |
| Decrypt · AES-256-CCM (CryptoHives-Scalar)  | 128KB        |   895,373.3 ns | 1,123.71 ns | 1,051.12 ns |         - |
| Decrypt · AES-256-CCM (BouncyCastle)        | 128KB        | 1,060,445.8 ns | 3,331.08 ns | 3,115.89 ns |  133988 B |
|                                             |              |                |             |             |           |
| Encrypt · AES-256-CCM (CryptoHives-ARM-AES) | 128KB        |   132,431.9 ns |   936.85 ns |   876.33 ns |         - |
| Encrypt · AES-256-CCM (CryptoHives-Scalar)  | 128KB        |   887,034.6 ns |   921.99 ns |   862.43 ns |         - |
| Encrypt · AES-256-CCM (BouncyCastle)        | 128KB        | 1,044,305.9 ns | 1,431.49 ns | 1,268.98 ns |    2904 B |