| Description                                 | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|-------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|
| Decrypt · AES-128-CCM (CryptoHives-ARM-AES) | 128B         |     283.6 ns |     0.48 ns |     0.40 ns |         - |
| Decrypt · AES-128-CCM (CryptoHives-Scalar)  | 128B         |     948.3 ns |     2.27 ns |     2.01 ns |         - |
| Decrypt · AES-128-CCM (BouncyCastle)        | 128B         |   1,360.4 ns |     1.99 ns |     1.55 ns |    2616 B |
|                                             |              |              |             |             |           |
| Encrypt · AES-128-CCM (CryptoHives-ARM-AES) | 128B         |     245.8 ns |     0.60 ns |     0.53 ns |         - |
| Encrypt · AES-128-CCM (CryptoHives-Scalar)  | 128B         |     898.7 ns |     2.76 ns |     2.44 ns |         - |
| Encrypt · AES-128-CCM (BouncyCastle)        | 128B         |   1,302.3 ns |     0.89 ns |     0.69 ns |    2504 B |
|                                             |              |              |             |             |           |
| Decrypt · AES-128-CCM (CryptoHives-ARM-AES) | 1KB          |   1,590.3 ns |     2.62 ns |     2.32 ns |         - |
| Decrypt · AES-128-CCM (CryptoHives-Scalar)  | 1KB          |   5,890.9 ns |    10.47 ns |     8.17 ns |         - |
| Decrypt · AES-128-CCM (BouncyCastle)        | 1KB          |   6,861.5 ns |    34.65 ns |    28.93 ns |    3512 B |
|                                             |              |              |             |             |           |
| Encrypt · AES-128-CCM (CryptoHives-ARM-AES) | 1KB          |   1,551.9 ns |     1.87 ns |     1.75 ns |         - |
| Encrypt · AES-128-CCM (CryptoHives-Scalar)  | 1KB          |   5,830.4 ns |     4.35 ns |     3.63 ns |         - |
| Encrypt · AES-128-CCM (BouncyCastle)        | 1KB          |   6,748.3 ns |    23.05 ns |    20.43 ns |    2504 B |
|                                             |              |              |             |             |           |
| Decrypt · AES-128-CCM (CryptoHives-ARM-AES) | 8KB          |  11,940.3 ns |    22.85 ns |    17.84 ns |         - |
| Decrypt · AES-128-CCM (CryptoHives-Scalar)  | 8KB          |  45,522.5 ns |    96.61 ns |    85.64 ns |         - |
| Decrypt · AES-128-CCM (BouncyCastle)        | 8KB          |  50,404.7 ns |    56.97 ns |    53.29 ns |   10680 B |
|                                             |              |              |             |             |           |
| Encrypt · AES-128-CCM (CryptoHives-ARM-AES) | 8KB          |  11,890.1 ns |    23.12 ns |    20.49 ns |         - |
| Encrypt · AES-128-CCM (CryptoHives-Scalar)  | 8KB          |  45,841.7 ns |   861.69 ns |   763.87 ns |         - |
| Encrypt · AES-128-CCM (BouncyCastle)        | 8KB          |  49,987.5 ns |    52.00 ns |    48.64 ns |    2504 B |
|                                             |              |              |             |             |           |
| Decrypt · AES-128-CCM (CryptoHives-ARM-AES) | 128KB        | 187,292.3 ns |   288.38 ns |   255.64 ns |         - |
| Decrypt · AES-128-CCM (CryptoHives-Scalar)  | 128KB        | 723,697.0 ns | 1,056.98 ns |   936.98 ns |         - |
| Decrypt · AES-128-CCM (BouncyCastle)        | 128KB        | 809,960.1 ns | 2,026.84 ns | 1,692.50 ns |  133588 B |
|                                             |              |              |             |             |           |
| Encrypt · AES-128-CCM (CryptoHives-ARM-AES) | 128KB        | 187,571.0 ns |   372.64 ns |   290.93 ns |         - |
| Encrypt · AES-128-CCM (CryptoHives-Scalar)  | 128KB        | 724,697.4 ns | 2,088.08 ns | 1,630.24 ns |         - |
| Encrypt · AES-128-CCM (BouncyCastle)        | 128KB        | 800,996.3 ns | 1,645.40 ns | 1,284.62 ns |    2504 B |