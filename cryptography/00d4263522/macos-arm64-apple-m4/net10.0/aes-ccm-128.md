| Description                                 | TestDataSize | Mean         | Error        | StdDev       | Allocated |
|-------------------------------------------- |------------- |-------------:|-------------:|-------------:|----------:|
| Decrypt · AES-128-CCM (CryptoHives-ARM-AES) | 128B         |     281.4 ns |      0.34 ns |      0.27 ns |         - |
| Decrypt · AES-128-CCM (CryptoHives-Scalar)  | 128B         |     971.4 ns |     19.05 ns |     16.89 ns |         - |
| Decrypt · AES-128-CCM (BouncyCastle)        | 128B         |   1,360.8 ns |     22.22 ns |     19.70 ns |    2616 B |
|                                             |              |              |              |              |           |
| Encrypt · AES-128-CCM (CryptoHives-ARM-AES) | 128B         |     242.9 ns |      0.71 ns |      0.55 ns |         - |
| Encrypt · AES-128-CCM (CryptoHives-Scalar)  | 128B         |     923.1 ns |     10.59 ns |      9.91 ns |         - |
| Encrypt · AES-128-CCM (BouncyCastle)        | 128B         |   1,306.6 ns |     13.60 ns |     10.62 ns |    2504 B |
|                                             |              |              |              |              |           |
| Decrypt · AES-128-CCM (CryptoHives-ARM-AES) | 1KB          |   1,595.2 ns |     19.01 ns |     17.78 ns |         - |
| Decrypt · AES-128-CCM (CryptoHives-Scalar)  | 1KB          |   6,077.7 ns |     77.49 ns |     72.48 ns |         - |
| Decrypt · AES-128-CCM (BouncyCastle)        | 1KB          |   6,899.3 ns |     91.99 ns |     86.05 ns |    3512 B |
|                                             |              |              |              |              |           |
| Encrypt · AES-128-CCM (CryptoHives-ARM-AES) | 1KB          |   1,557.1 ns |     19.65 ns |     18.38 ns |         - |
| Encrypt · AES-128-CCM (CryptoHives-Scalar)  | 1KB          |   6,026.3 ns |     79.23 ns |     74.11 ns |         - |
| Encrypt · AES-128-CCM (BouncyCastle)        | 1KB          |   6,818.1 ns |     95.86 ns |     89.67 ns |    2504 B |
|                                             |              |              |              |              |           |
| Decrypt · AES-128-CCM (CryptoHives-ARM-AES) | 8KB          |  12,012.3 ns |    160.63 ns |    150.26 ns |         - |
| Decrypt · AES-128-CCM (CryptoHives-Scalar)  | 8KB          |  46,779.0 ns |    644.42 ns |    602.80 ns |         - |
| Decrypt · AES-128-CCM (BouncyCastle)        | 8KB          |  50,961.2 ns |    809.54 ns |    757.24 ns |   10680 B |
|                                             |              |              |              |              |           |
| Encrypt · AES-128-CCM (CryptoHives-ARM-AES) | 8KB          |  11,969.0 ns |    153.58 ns |    143.66 ns |         - |
| Encrypt · AES-128-CCM (CryptoHives-Scalar)  | 8KB          |  46,716.3 ns |    634.07 ns |    593.11 ns |         - |
| Encrypt · AES-128-CCM (BouncyCastle)        | 8KB          |  50,717.9 ns |    754.16 ns |    705.44 ns |    2504 B |
|                                             |              |              |              |              |           |
| Decrypt · AES-128-CCM (CryptoHives-ARM-AES) | 128KB        | 192,653.6 ns |  2,590.81 ns |  2,423.45 ns |         - |
| Decrypt · AES-128-CCM (CryptoHives-Scalar)  | 128KB        | 745,052.4 ns |  9,491.10 ns |  8,877.98 ns |         - |
| Decrypt · AES-128-CCM (BouncyCastle)        | 128KB        | 817,401.8 ns | 14,269.57 ns | 13,347.76 ns |  133588 B |
|                                             |              |              |              |              |           |
| Encrypt · AES-128-CCM (CryptoHives-ARM-AES) | 128KB        | 190,462.9 ns |  2,723.10 ns |  2,547.19 ns |         - |
| Encrypt · AES-128-CCM (CryptoHives-Scalar)  | 128KB        | 745,858.8 ns | 10,593.58 ns |  9,909.24 ns |         - |
| Encrypt · AES-128-CCM (BouncyCastle)        | 128KB        | 804,608.4 ns | 12,085.74 ns | 11,305.01 ns |    2504 B |