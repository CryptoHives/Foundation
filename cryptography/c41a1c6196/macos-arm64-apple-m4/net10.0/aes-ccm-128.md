| Description                                 | TestDataSize | Mean         | Error     | StdDev    | Allocated |
|-------------------------------------------- |------------- |-------------:|----------:|----------:|----------:|
| Decrypt · AES-128-CCM (CryptoHives-ARM-AES) | 128B         |     199.8 ns |   0.41 ns |   0.38 ns |         - |
| Decrypt · AES-128-CCM (CryptoHives-Scalar)  | 128B         |     870.0 ns |   0.97 ns |   0.91 ns |         - |
| Decrypt · AES-128-CCM (BouncyCastle)        | 128B         |   1,367.9 ns |   2.76 ns |   2.45 ns |    2616 B |
|                                             |              |              |           |           |           |
| Encrypt · AES-128-CCM (CryptoHives-ARM-AES) | 128B         |     157.9 ns |   0.63 ns |   0.59 ns |         - |
| Encrypt · AES-128-CCM (CryptoHives-Scalar)  | 128B         |     820.6 ns |   0.67 ns |   0.60 ns |         - |
| Encrypt · AES-128-CCM (BouncyCastle)        | 128B         |   1,321.6 ns |  10.05 ns |   8.39 ns |    2504 B |
|                                             |              |              |           |           |           |
| Decrypt · AES-128-CCM (CryptoHives-ARM-AES) | 1KB          |     964.4 ns |   4.46 ns |   3.95 ns |         - |
| Decrypt · AES-128-CCM (CryptoHives-Scalar)  | 1KB          |   5,332.1 ns |   7.12 ns |   6.66 ns |         - |
| Decrypt · AES-128-CCM (BouncyCastle)        | 1KB          |   6,885.9 ns |  10.65 ns |   9.44 ns |    3512 B |
|                                             |              |              |           |           |           |
| Encrypt · AES-128-CCM (CryptoHives-ARM-AES) | 1KB          |     933.2 ns |   2.50 ns |   2.21 ns |         - |
| Encrypt · AES-128-CCM (CryptoHives-Scalar)  | 1KB          |   5,296.9 ns |   6.61 ns |   6.18 ns |         - |
| Encrypt · AES-128-CCM (BouncyCastle)        | 1KB          |   6,774.2 ns |  17.72 ns |  16.58 ns |    2504 B |
|                                             |              |              |           |           |           |
| Decrypt · AES-128-CCM (CryptoHives-ARM-AES) | 8KB          |   7,057.1 ns |  16.30 ns |  15.24 ns |         - |
| Decrypt · AES-128-CCM (CryptoHives-Scalar)  | 8KB          |  41,082.5 ns |  92.79 ns |  86.79 ns |         - |
| Decrypt · AES-128-CCM (BouncyCastle)        | 8KB          |  50,944.0 ns | 136.61 ns | 127.78 ns |   10680 B |
|                                             |              |              |           |           |           |
| Encrypt · AES-128-CCM (CryptoHives-ARM-AES) | 8KB          |   7,089.1 ns |  11.17 ns |   9.90 ns |         - |
| Encrypt · AES-128-CCM (CryptoHives-Scalar)  | 8KB          |  41,084.6 ns |  36.38 ns |  34.03 ns |         - |
| Encrypt · AES-128-CCM (BouncyCastle)        | 8KB          |  50,356.9 ns |  30.94 ns |  27.43 ns |    2504 B |
|                                             |              |              |           |           |           |
| Decrypt · AES-128-CCM (CryptoHives-ARM-AES) | 128KB        | 111,353.0 ns | 346.91 ns | 324.50 ns |         - |
| Decrypt · AES-128-CCM (CryptoHives-Scalar)  | 128KB        | 654,801.5 ns | 787.16 ns | 736.31 ns |         - |
| Decrypt · AES-128-CCM (BouncyCastle)        | 128KB        | 817,340.7 ns | 716.95 ns | 670.63 ns |  133588 B |
|                                             |              |              |           |           |           |
| Encrypt · AES-128-CCM (CryptoHives-ARM-AES) | 128KB        | 113,783.8 ns | 382.27 ns | 357.58 ns |         - |
| Encrypt · AES-128-CCM (CryptoHives-Scalar)  | 128KB        | 653,786.8 ns | 986.33 ns | 874.35 ns |         - |
| Encrypt · AES-128-CCM (BouncyCastle)        | 128KB        | 801,994.7 ns | 740.56 ns | 692.72 ns |    2504 B |