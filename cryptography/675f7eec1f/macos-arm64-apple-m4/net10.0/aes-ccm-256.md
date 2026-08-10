| Description                                 | TestDataSize | Mean           | Error       | StdDev      | Allocated |
|-------------------------------------------- |------------- |---------------:|------------:|------------:|----------:|
| Decrypt · AES-256-CCM (CryptoHives-ARM-AES) | 128B         |       309.5 ns |     0.48 ns |     0.45 ns |         - |
| Decrypt · AES-256-CCM (CryptoHives-Scalar)  | 128B         |     1,261.2 ns |     1.64 ns |     1.54 ns |         - |
| Decrypt · AES-256-CCM (BouncyCastle)        | 128B         |     1,825.2 ns |     4.61 ns |     4.09 ns |    2808 B |
|                                             |              |                |             |             |           |
| Encrypt · AES-256-CCM (CryptoHives-ARM-AES) | 128B         |       273.6 ns |     0.28 ns |     0.24 ns |         - |
| Encrypt · AES-256-CCM (CryptoHives-Scalar)  | 128B         |     1,216.6 ns |     2.40 ns |     2.13 ns |         - |
| Encrypt · AES-256-CCM (BouncyCastle)        | 128B         |     1,776.3 ns |     1.27 ns |     1.19 ns |    2848 B |
|                                             |              |                |             |             |           |
| Decrypt · AES-256-CCM (CryptoHives-ARM-AES) | 1KB          |     1,764.9 ns |     1.29 ns |     1.14 ns |         - |
| Decrypt · AES-256-CCM (CryptoHives-Scalar)  | 1KB          |     8,000.7 ns |     6.05 ns |     5.66 ns |         - |
| Decrypt · AES-256-CCM (BouncyCastle)        | 1KB          |     9,000.6 ns |    12.13 ns |    11.35 ns |    2808 B |
|                                             |              |                |             |             |           |
| Encrypt · AES-256-CCM (CryptoHives-ARM-AES) | 1KB          |     1,725.4 ns |     5.10 ns |     4.52 ns |         - |
| Encrypt · AES-256-CCM (CryptoHives-Scalar)  | 1KB          |     7,955.0 ns |    12.33 ns |    11.54 ns |         - |
| Encrypt · AES-256-CCM (BouncyCastle)        | 1KB          |     8,954.5 ns |    10.77 ns |    10.07 ns |    2848 B |
|                                             |              |                |             |             |           |
| Decrypt · AES-256-CCM (CryptoHives-ARM-AES) | 8KB          |    13,326.6 ns |    14.50 ns |    13.56 ns |         - |
| Decrypt · AES-256-CCM (CryptoHives-Scalar)  | 8KB          |    61,801.2 ns |    37.77 ns |    33.48 ns |         - |
| Decrypt · AES-256-CCM (BouncyCastle)        | 8KB          |    65,902.5 ns |   217.95 ns |   203.87 ns |    2808 B |
|                                             |              |                |             |             |           |
| Encrypt · AES-256-CCM (CryptoHives-ARM-AES) | 8KB          |    13,277.3 ns |    12.99 ns |    12.16 ns |         - |
| Encrypt · AES-256-CCM (CryptoHives-Scalar)  | 8KB          |    61,636.8 ns |   235.97 ns |   197.04 ns |         - |
| Encrypt · AES-256-CCM (BouncyCastle)        | 8KB          |    66,085.1 ns |    64.24 ns |    60.09 ns |    2848 B |
|                                             |              |                |             |             |           |
| Decrypt · AES-256-CCM (CryptoHives-ARM-AES) | 128KB        |   212,072.3 ns |   583.40 ns |   517.17 ns |         - |
| Decrypt · AES-256-CCM (CryptoHives-Scalar)  | 128KB        |   984,748.1 ns |   671.27 ns |   627.90 ns |         - |
| Decrypt · AES-256-CCM (BouncyCastle)        | 128KB        | 1,046,082.8 ns | 3,099.62 ns | 2,899.39 ns |    2808 B |
|                                             |              |                |             |             |           |
| Encrypt · AES-256-CCM (CryptoHives-ARM-AES) | 128KB        |   211,756.0 ns |   575.65 ns |   538.46 ns |         - |
| Encrypt · AES-256-CCM (CryptoHives-Scalar)  | 128KB        |   985,056.6 ns |   651.05 ns |   608.99 ns |         - |
| Encrypt · AES-256-CCM (BouncyCastle)        | 128KB        | 1,047,547.2 ns | 1,757.02 ns | 1,643.52 ns |    2848 B |