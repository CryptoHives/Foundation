| Description                                | TestDataSize | Mean           | Error        | StdDev       | Allocated |
|------------------------------------------- |------------- |---------------:|-------------:|-------------:|----------:|
| Decrypt · AES-256-CCM (CryptoHives-AES-NI) | 128B         |       457.2 ns |      1.15 ns |      1.02 ns |         - |
| Decrypt · AES-256-CCM (CryptoHives-Scalar) | 128B         |     1,274.1 ns |      5.09 ns |      4.51 ns |         - |
| Decrypt · AES-256-CCM (BouncyCastle)       | 128B         |     1,900.5 ns |     23.81 ns |     22.27 ns |    3016 B |
|                                            |              |                |              |              |           |
| Encrypt · AES-256-CCM (CryptoHives-AES-NI) | 128B         |       413.8 ns |      0.73 ns |      0.61 ns |         - |
| Encrypt · AES-256-CCM (CryptoHives-Scalar) | 128B         |     1,241.3 ns |     12.34 ns |     11.55 ns |         - |
| Encrypt · AES-256-CCM (BouncyCastle)       | 128B         |     1,866.6 ns |     14.73 ns |     13.05 ns |    2904 B |
|                                            |              |                |              |              |           |
| Decrypt · AES-256-CCM (CryptoHives-AES-NI) | 1KB          |     2,738.6 ns |      5.52 ns |      4.89 ns |         - |
| Decrypt · AES-256-CCM (CryptoHives-Scalar) | 1KB          |     8,131.3 ns |     50.55 ns |     44.81 ns |         - |
| Decrypt · AES-256-CCM (BouncyCastle)       | 1KB          |    10,181.3 ns |     50.02 ns |     46.79 ns |    3912 B |
|                                            |              |                |              |              |           |
| Encrypt · AES-256-CCM (CryptoHives-AES-NI) | 1KB          |     2,696.0 ns |      3.76 ns |      2.94 ns |         - |
| Encrypt · AES-256-CCM (CryptoHives-Scalar) | 1KB          |     9,472.4 ns |     62.96 ns |     58.89 ns |         - |
| Encrypt · AES-256-CCM (BouncyCastle)       | 1KB          |    10,063.9 ns |     75.11 ns |     62.72 ns |    2904 B |
|                                            |              |                |              |              |           |
| Decrypt · AES-256-CCM (CryptoHives-AES-NI) | 8KB          |    20,988.8 ns |     25.49 ns |     22.59 ns |         - |
| Decrypt · AES-256-CCM (CryptoHives-Scalar) | 8KB          |    74,931.6 ns |    627.50 ns |    586.96 ns |         - |
| Decrypt · AES-256-CCM (BouncyCastle)       | 8KB          |    76,347.6 ns |    377.57 ns |    353.18 ns |   11080 B |
|                                            |              |                |              |              |           |
| Encrypt · AES-256-CCM (CryptoHives-AES-NI) | 8KB          |    20,955.6 ns |     40.64 ns |     38.01 ns |         - |
| Encrypt · AES-256-CCM (CryptoHives-Scalar) | 8KB          |    63,117.0 ns |    366.62 ns |    306.14 ns |         - |
| Encrypt · AES-256-CCM (BouncyCastle)       | 8KB          |    75,792.2 ns |    542.83 ns |    507.76 ns |    2904 B |
|                                            |              |                |              |              |           |
| Decrypt · AES-256-CCM (CryptoHives-AES-NI) | 128KB        |   333,774.9 ns |    693.97 ns |    615.18 ns |         - |
| Decrypt · AES-256-CCM (CryptoHives-Scalar) | 128KB        | 1,008,689.6 ns | 11,926.04 ns | 11,155.62 ns |         - |
| Decrypt · AES-256-CCM (BouncyCastle)       | 128KB        | 1,236,650.9 ns |  5,756.24 ns |  5,102.76 ns |  133974 B |
|                                            |              |                |              |              |           |
| Encrypt · AES-256-CCM (CryptoHives-AES-NI) | 128KB        |   333,960.3 ns |    561.40 ns |    525.14 ns |         - |
| Encrypt · AES-256-CCM (CryptoHives-Scalar) | 128KB        | 1,177,403.0 ns |  6,646.10 ns |  6,216.77 ns |         - |
| Encrypt · AES-256-CCM (BouncyCastle)       | 128KB        | 1,203,462.5 ns | 10,401.79 ns |  9,729.84 ns |    2904 B |