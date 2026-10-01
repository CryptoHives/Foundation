| Description                                 | TestDataSize | Mean           | Error        | StdDev       | Allocated |
|-------------------------------------------- |------------- |---------------:|-------------:|-------------:|----------:|
| Decrypt · AES-256-CCM (CryptoHives-ARM-AES) | 128B         |       301.3 ns |      1.47 ns |      1.38 ns |         - |
| Decrypt · AES-256-CCM (CryptoHives-Scalar)  | 128B         |     1,236.6 ns |      1.21 ns |      1.13 ns |         - |
| Decrypt · AES-256-CCM (BouncyCastle)        | 128B         |     1,709.5 ns |     19.05 ns |     17.82 ns |    3016 B |
|                                             |              |                |              |              |           |
| Encrypt · AES-256-CCM (CryptoHives-ARM-AES) | 128B         |       271.3 ns |      1.32 ns |      1.23 ns |         - |
| Encrypt · AES-256-CCM (CryptoHives-Scalar)  | 128B         |     1,203.8 ns |      7.80 ns |      6.91 ns |         - |
| Encrypt · AES-256-CCM (BouncyCastle)        | 128B         |     1,674.8 ns |     17.90 ns |     16.74 ns |    2904 B |
|                                             |              |                |              |              |           |
| Decrypt · AES-256-CCM (CryptoHives-ARM-AES) | 1KB          |     1,770.3 ns |     26.76 ns |     23.72 ns |         - |
| Decrypt · AES-256-CCM (CryptoHives-Scalar)  | 1KB          |     7,854.6 ns |     26.75 ns |     25.02 ns |         - |
| Decrypt · AES-256-CCM (BouncyCastle)        | 1KB          |     8,933.9 ns |     33.04 ns |     30.91 ns |    3912 B |
|                                             |              |                |              |              |           |
| Encrypt · AES-256-CCM (CryptoHives-ARM-AES) | 1KB          |     1,711.6 ns |     33.12 ns |     39.42 ns |         - |
| Encrypt · AES-256-CCM (CryptoHives-Scalar)  | 1KB          |     7,773.3 ns |      3.20 ns |      2.99 ns |         - |
| Encrypt · AES-256-CCM (BouncyCastle)        | 1KB          |     8,775.9 ns |      5.11 ns |      4.53 ns |    2904 B |
|                                             |              |                |              |              |           |
| Decrypt · AES-256-CCM (CryptoHives-ARM-AES) | 8KB          |    13,354.7 ns |     74.70 ns |     69.88 ns |         - |
| Decrypt · AES-256-CCM (CryptoHives-Scalar)  | 8KB          |    61,022.5 ns |    450.02 ns |    420.95 ns |         - |
| Decrypt · AES-256-CCM (BouncyCastle)        | 8KB          |    66,975.1 ns |    123.80 ns |    109.74 ns |   11080 B |
|                                             |              |                |              |              |           |
| Encrypt · AES-256-CCM (CryptoHives-ARM-AES) | 8KB          |    13,091.3 ns |     60.74 ns |     53.84 ns |         - |
| Encrypt · AES-256-CCM (CryptoHives-Scalar)  | 8KB          |    60,847.0 ns |    414.15 ns |    367.13 ns |         - |
| Encrypt · AES-256-CCM (BouncyCastle)        | 8KB          |    65,546.2 ns |     28.93 ns |     27.06 ns |    2904 B |
|                                             |              |                |              |              |           |
| Decrypt · AES-256-CCM (CryptoHives-ARM-AES) | 128KB        |   206,375.4 ns |    768.56 ns |    718.92 ns |         - |
| Decrypt · AES-256-CCM (CryptoHives-Scalar)  | 128KB        |   978,628.3 ns | 14,355.30 ns | 13,427.95 ns |         - |
| Decrypt · AES-256-CCM (BouncyCastle)        | 128KB        | 1,070,226.1 ns |  5,745.13 ns |  4,797.44 ns |  133988 B |
|                                             |              |                |              |              |           |
| Encrypt · AES-256-CCM (CryptoHives-ARM-AES) | 128KB        |   206,597.4 ns |    872.87 ns |    728.89 ns |         - |
| Encrypt · AES-256-CCM (CryptoHives-Scalar)  | 128KB        |   961,911.7 ns |    435.45 ns |    407.32 ns |         - |
| Encrypt · AES-256-CCM (BouncyCastle)        | 128KB        | 1,043,171.1 ns |  8,991.85 ns |  8,410.98 ns |    2904 B |