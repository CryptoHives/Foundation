| Description                                | TestDataSize | Mean           | Error        | StdDev       | Code Size | Allocated |
|------------------------------------------- |------------- |---------------:|-------------:|-------------:|----------:|----------:|
| Decrypt · AES-256-CCM (CryptoHives-AES-NI) | 128B         |       490.6 ns |      1.69 ns |      1.58 ns |   9,490 B |         - |
| Decrypt · AES-256-CCM (CryptoHives-Scalar) | 128B         |     1,307.0 ns |     15.18 ns |     14.20 ns |  10,459 B |         - |
| Decrypt · AES-256-CCM (BouncyCastle)       | 128B         |     2,322.2 ns |     45.62 ns |     44.81 ns |     306 B |    3016 B |
|                                            |              |                |              |              |           |           |
| Encrypt · AES-256-CCM (CryptoHives-AES-NI) | 128B         |       437.9 ns |      0.19 ns |      0.17 ns |   9,438 B |         - |
| Encrypt · AES-256-CCM (CryptoHives-Scalar) | 128B         |     1,238.9 ns |      2.32 ns |      1.94 ns |  10,407 B |         - |
| Encrypt · AES-256-CCM (BouncyCastle)       | 128B         |     2,097.2 ns |      8.55 ns |      7.58 ns |     383 B |    2904 B |
|                                            |              |                |              |              |           |           |
| Decrypt · AES-256-CCM (CryptoHives-AES-NI) | 1KB          |     2,787.9 ns |      2.46 ns |      2.30 ns |   9,497 B |         - |
| Decrypt · AES-256-CCM (CryptoHives-Scalar) | 1KB          |     8,111.6 ns |     94.78 ns |     88.66 ns |  10,466 B |         - |
| Decrypt · AES-256-CCM (BouncyCastle)       | 1KB          |    11,921.6 ns |    160.30 ns |    149.94 ns |     306 B |    3912 B |
|                                            |              |                |              |              |           |           |
| Encrypt · AES-256-CCM (CryptoHives-AES-NI) | 1KB          |     2,746.8 ns |      1.13 ns |      0.94 ns |   9,445 B |         - |
| Encrypt · AES-256-CCM (CryptoHives-Scalar) | 1KB          |     7,919.3 ns |     38.98 ns |     34.56 ns |  10,414 B |         - |
| Encrypt · AES-256-CCM (BouncyCastle)       | 1KB          |    11,578.7 ns |     33.28 ns |     31.13 ns |     383 B |    2904 B |
|                                            |              |                |              |              |           |           |
| Decrypt · AES-256-CCM (CryptoHives-AES-NI) | 8KB          |    21,160.8 ns |     17.79 ns |     16.65 ns |   9,498 B |         - |
| Decrypt · AES-256-CCM (CryptoHives-Scalar) | 8KB          |    62,307.7 ns |    779.64 ns |    729.28 ns |  10,473 B |         - |
| Decrypt · AES-256-CCM (BouncyCastle)       | 8KB          |    89,675.5 ns |  1,398.57 ns |  1,308.22 ns |     306 B |   11080 B |
|                                            |              |                |              |              |           |           |
| Encrypt · AES-256-CCM (CryptoHives-AES-NI) | 8KB          |    21,116.0 ns |     13.36 ns |     12.49 ns |   9,452 B |         - |
| Encrypt · AES-256-CCM (CryptoHives-Scalar) | 8KB          |    61,256.9 ns |    150.64 ns |    125.79 ns |  10,415 B |         - |
| Encrypt · AES-256-CCM (BouncyCastle)       | 8KB          |    87,154.2 ns |    179.27 ns |    149.70 ns |     383 B |    2904 B |
|                                            |              |                |              |              |           |           |
| Decrypt · AES-256-CCM (CryptoHives-AES-NI) | 128KB        |   339,846.3 ns |    405.27 ns |    379.09 ns |   9,504 B |         - |
| Decrypt · AES-256-CCM (CryptoHives-Scalar) | 128KB        |   992,421.0 ns | 13,256.19 ns | 12,399.85 ns |  10,473 B |         - |
| Decrypt · AES-256-CCM (BouncyCastle)       | 128KB        | 1,452,679.6 ns | 17,039.01 ns | 15,938.30 ns |     306 B |  133974 B |
|                                            |              |                |              |              |           |           |
| Encrypt · AES-256-CCM (CryptoHives-AES-NI) | 128KB        |   337,835.5 ns |    236.03 ns |    220.78 ns |   9,449 B |         - |
| Encrypt · AES-256-CCM (CryptoHives-Scalar) | 128KB        | 1,017,069.5 ns |  7,226.77 ns |  6,406.35 ns |  10,418 B |         - |
| Encrypt · AES-256-CCM (BouncyCastle)       | 128KB        | 1,409,964.8 ns | 14,736.82 ns | 13,784.83 ns |     383 B |    2904 B |