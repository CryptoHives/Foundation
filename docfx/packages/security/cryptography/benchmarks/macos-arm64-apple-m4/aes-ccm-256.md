| Description                                 | TestDataSize | Mean           | Error        | StdDev       | Median         | Allocated |
|-------------------------------------------- |------------- |---------------:|-------------:|-------------:|---------------:|----------:|
| Decrypt · AES-256-CCM (CryptoHives-ARM-AES) | 128B         |       337.8 ns |      6.49 ns |      5.75 ns |       339.0 ns |         - |
| Decrypt · AES-256-CCM (CryptoHives-Scalar)  | 128B         |     1,437.3 ns |     28.78 ns |     63.78 ns |     1,407.8 ns |         - |
| Decrypt · AES-256-CCM (BouncyCastle)        | 128B         |     2,113.7 ns |     42.01 ns |    118.48 ns |     2,078.6 ns |    2808 B |
|                                             |              |                |              |              |                |           |
| Encrypt · AES-256-CCM (CryptoHives-ARM-AES) | 128B         |       272.3 ns |      0.33 ns |      0.31 ns |       272.5 ns |         - |
| Encrypt · AES-256-CCM (CryptoHives-Scalar)  | 128B         |     1,209.3 ns |      0.45 ns |      0.43 ns |     1,209.4 ns |         - |
| Encrypt · AES-256-CCM (BouncyCastle)        | 128B         |     1,759.0 ns |      1.36 ns |      1.27 ns |     1,758.8 ns |    2848 B |
|                                             |              |                |              |              |                |           |
| Decrypt · AES-256-CCM (CryptoHives-ARM-AES) | 1KB          |     1,988.8 ns |     39.16 ns |     60.97 ns |     1,964.0 ns |         - |
| Decrypt · AES-256-CCM (CryptoHives-Scalar)  | 1KB          |     9,733.2 ns |    193.41 ns |    180.91 ns |     9,743.4 ns |         - |
| Decrypt · AES-256-CCM (BouncyCastle)        | 1KB          |    10,563.3 ns |    206.98 ns |    383.65 ns |    10,490.3 ns |    2808 B |
|                                             |              |                |              |              |                |           |
| Encrypt · AES-256-CCM (CryptoHives-ARM-AES) | 1KB          |     1,716.5 ns |      1.43 ns |      1.34 ns |     1,716.7 ns |         - |
| Encrypt · AES-256-CCM (CryptoHives-Scalar)  | 1KB          |     7,904.6 ns |      1.19 ns |      1.06 ns |     7,904.5 ns |         - |
| Encrypt · AES-256-CCM (BouncyCastle)        | 1KB          |     8,874.2 ns |      3.47 ns |      3.24 ns |     8,873.8 ns |    2848 B |
|                                             |              |                |              |              |                |           |
| Decrypt · AES-256-CCM (CryptoHives-ARM-AES) | 8KB          |    14,769.1 ns |    228.42 ns |    368.85 ns |    14,659.5 ns |         - |
| Decrypt · AES-256-CCM (CryptoHives-Scalar)  | 8KB          |    74,334.0 ns |  1,429.61 ns |  1,701.85 ns |    74,752.2 ns |         - |
| Decrypt · AES-256-CCM (BouncyCastle)        | 8KB          |    74,908.0 ns |    619.45 ns |    579.43 ns |    74,797.7 ns |    2808 B |
|                                             |              |                |              |              |                |           |
| Encrypt · AES-256-CCM (CryptoHives-ARM-AES) | 8KB          |    13,200.3 ns |      4.76 ns |      3.98 ns |    13,201.8 ns |         - |
| Encrypt · AES-256-CCM (CryptoHives-Scalar)  | 8KB          |    64,871.5 ns |  1,275.19 ns |  2,165.37 ns |    65,645.0 ns |         - |
| Encrypt · AES-256-CCM (BouncyCastle)        | 8KB          |    71,548.6 ns |  1,389.83 ns |  1,300.05 ns |    71,899.2 ns |    2848 B |
|                                             |              |                |              |              |                |           |
| Decrypt · AES-256-CCM (CryptoHives-ARM-AES) | 128KB        |   238,909.2 ns |  4,709.22 ns |  8,491.69 ns |   235,102.1 ns |         - |
| Decrypt · AES-256-CCM (CryptoHives-Scalar)  | 128KB        | 1,147,014.8 ns | 22,832.17 ns | 32,745.21 ns | 1,157,165.6 ns |         - |
| Decrypt · AES-256-CCM (BouncyCastle)        | 128KB        | 1,281,403.6 ns | 13,744.75 ns | 12,856.85 ns | 1,276,111.1 ns |    2808 B |
|                                             |              |                |              |              |                |           |
| Encrypt · AES-256-CCM (CryptoHives-ARM-AES) | 128KB        |   226,366.6 ns |  1,819.51 ns |  1,612.95 ns |   226,620.7 ns |         - |
| Encrypt · AES-256-CCM (CryptoHives-Scalar)  | 128KB        | 1,083,294.2 ns | 19,719.07 ns | 24,938.32 ns | 1,086,819.6 ns |         - |
| Encrypt · AES-256-CCM (BouncyCastle)        | 128KB        | 1,156,635.3 ns | 17,336.29 ns | 20,637.62 ns | 1,156,524.3 ns |    2848 B |