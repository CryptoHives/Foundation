| Description                                 | TestDataSize | Mean         | Error        | StdDev       | Allocated |
|-------------------------------------------- |------------- |-------------:|-------------:|-------------:|----------:|
| Decrypt · AES-128-CCM (CryptoHives-ARM-AES) | 128B         |     282.6 ns |      1.75 ns |      1.36 ns |         - |
| Decrypt · AES-128-CCM (CryptoHives-Scalar)  | 128B         |     995.0 ns |      0.69 ns |      0.64 ns |         - |
| Decrypt · AES-128-CCM (BouncyCastle)        | 128B         |   1,357.4 ns |      0.48 ns |      0.43 ns |    2616 B |
|                                             |              |              |              |              |           |
| Encrypt · AES-128-CCM (CryptoHives-ARM-AES) | 128B         |   1,156.4 ns |      3.30 ns |      2.92 ns |         - |
| Encrypt · AES-128-CCM (CryptoHives-Scalar)  | 128B         |   4,473.8 ns |      3.90 ns |      3.46 ns |         - |
| Encrypt · AES-128-CCM (BouncyCastle)        | 128B         |   6,140.7 ns |      5.05 ns |      4.72 ns |    2504 B |
|                                             |              |              |              |              |           |
| Decrypt · AES-128-CCM (CryptoHives-ARM-AES) | 1KB          |   1,586.4 ns |      1.09 ns |      1.02 ns |         - |
| Decrypt · AES-128-CCM (CryptoHives-Scalar)  | 1KB          |   6,224.8 ns |      2.27 ns |      2.13 ns |         - |
| Decrypt · AES-128-CCM (BouncyCastle)        | 1KB          |   6,822.5 ns |      1.73 ns |      1.54 ns |    3512 B |
|                                             |              |              |              |              |           |
| Encrypt · AES-128-CCM (CryptoHives-ARM-AES) | 1KB          |   7,312.3 ns |      6.10 ns |      4.77 ns |         - |
| Encrypt · AES-128-CCM (CryptoHives-Scalar)  | 1KB          |  29,138.1 ns |     17.81 ns |     16.66 ns |         - |
| Encrypt · AES-128-CCM (BouncyCastle)        | 1KB          |  31,673.6 ns |     20.81 ns |     19.47 ns |    2504 B |
|                                             |              |              |              |              |           |
| Decrypt · AES-128-CCM (CryptoHives-ARM-AES) | 8KB          |  11,914.3 ns |     10.58 ns |      9.89 ns |         - |
| Decrypt · AES-128-CCM (CryptoHives-Scalar)  | 8KB          |  51,714.1 ns |  1,029.74 ns |  2,281.83 ns |         - |
| Decrypt · AES-128-CCM (BouncyCastle)        | 8KB          |  55,367.2 ns |  1,073.21 ns |  1,432.71 ns |   10680 B |
|                                             |              |              |              |              |           |
| Encrypt · AES-128-CCM (CryptoHives-ARM-AES) | 8KB          |  12,071.3 ns |    193.11 ns |    294.90 ns |         - |
| Encrypt · AES-128-CCM (CryptoHives-Scalar)  | 8KB          |  47,682.6 ns |      7.02 ns |      6.57 ns |         - |
| Encrypt · AES-128-CCM (BouncyCastle)        | 8KB          |  49,883.5 ns |     18.77 ns |     14.66 ns |    2504 B |
|                                             |              |              |              |              |           |
| Decrypt · AES-128-CCM (CryptoHives-ARM-AES) | 128KB        | 210,889.2 ns |  4,192.08 ns |  8,076.72 ns |         - |
| Decrypt · AES-128-CCM (CryptoHives-Scalar)  | 128KB        | 943,278.7 ns | 18,740.41 ns | 25,017.91 ns |         - |
| Decrypt · AES-128-CCM (BouncyCastle)        | 128KB        | 991,133.0 ns | 19,719.35 ns | 24,938.67 ns |  133588 B |
|                                             |              |              |              |              |           |
| Encrypt · AES-128-CCM (CryptoHives-ARM-AES) | 128KB        | 186,625.0 ns |    119.18 ns |     99.52 ns |         - |
| Encrypt · AES-128-CCM (CryptoHives-Scalar)  | 128KB        | 760,536.8 ns |     85.77 ns |     76.03 ns |         - |
| Encrypt · AES-128-CCM (BouncyCastle)        | 128KB        | 803,794.3 ns |  3,053.49 ns |  2,549.80 ns |    2504 B |