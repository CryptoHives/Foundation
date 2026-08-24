| Description                                 | TestDataSize | Mean           | Error        | StdDev       | Median         | Allocated |
|-------------------------------------------- |------------- |---------------:|-------------:|-------------:|---------------:|----------:|
| Decrypt · AES-256-CCM (CryptoHives-ARM-AES) | 128B         |     1,470.1 ns |      2.16 ns |      1.92 ns |     1,470.2 ns |         - |
| Decrypt · AES-256-CCM (BouncyCastle)        | 128B         |     1,750.7 ns |     31.17 ns |     54.60 ns |     1,734.9 ns |    3016 B |
| Decrypt · AES-256-CCM (CryptoHives-Scalar)  | 128B         |     6,141.5 ns |      8.48 ns |      7.51 ns |     6,140.7 ns |         - |
|                                             |              |                |              |              |                |           |
| Encrypt · AES-256-CCM (CryptoHives-ARM-AES) | 128B         |       305.8 ns |      3.91 ns |      3.26 ns |       306.1 ns |         - |
| Encrypt · AES-256-CCM (CryptoHives-Scalar)  | 128B         |     1,539.8 ns |     20.94 ns |     18.56 ns |     1,537.7 ns |         - |
| Encrypt · AES-256-CCM (BouncyCastle)        | 128B         |     7,833.2 ns |     12.30 ns |     11.50 ns |     7,832.6 ns |    2904 B |
|                                             |              |                |              |              |                |           |
| Decrypt · AES-256-CCM (CryptoHives-ARM-AES) | 1KB          |     1,768.6 ns |      0.52 ns |      0.46 ns |     1,768.5 ns |         - |
| Decrypt · AES-256-CCM (CryptoHives-Scalar)  | 1KB          |     8,250.3 ns |      2.48 ns |      2.32 ns |     8,250.1 ns |         - |
| Decrypt · AES-256-CCM (BouncyCastle)        | 1KB          |     8,898.6 ns |      2.32 ns |      2.06 ns |     8,898.4 ns |    3912 B |
|                                             |              |                |              |              |                |           |
| Encrypt · AES-256-CCM (CryptoHives-ARM-AES) | 1KB          |     8,174.8 ns |      8.61 ns |      7.63 ns |     8,171.5 ns |         - |
| Encrypt · AES-256-CCM (CryptoHives-Scalar)  | 1KB          |    38,694.5 ns |     28.08 ns |     23.45 ns |    38,693.7 ns |         - |
| Encrypt · AES-256-CCM (BouncyCastle)        | 1KB          |    41,340.0 ns |     32.53 ns |     27.16 ns |    41,341.4 ns |    2904 B |
|                                             |              |                |              |              |                |           |
| Decrypt · AES-256-CCM (CryptoHives-ARM-AES) | 8KB          |    13,363.1 ns |      7.29 ns |      6.82 ns |    13,363.7 ns |         - |
| Decrypt · AES-256-CCM (CryptoHives-Scalar)  | 8KB          |    64,457.1 ns |    975.82 ns |  2,121.35 ns |    63,545.5 ns |         - |
| Decrypt · AES-256-CCM (BouncyCastle)        | 8KB          |    65,949.3 ns |     24.64 ns |     23.05 ns |    65,946.1 ns |   11080 B |
|                                             |              |                |              |              |                |           |
| Encrypt · AES-256-CCM (CryptoHives-ARM-AES) | 8KB          |    62,864.9 ns |     88.20 ns |     82.51 ns |    62,865.2 ns |         - |
| Encrypt · AES-256-CCM (CryptoHives-Scalar)  | 8KB          |   299,511.4 ns |    153.37 ns |    135.96 ns |   299,481.5 ns |         - |
| Encrypt · AES-256-CCM (BouncyCastle)        | 8KB          |   308,753.4 ns |    201.13 ns |    188.14 ns |   308,769.9 ns |    2904 B |
|                                             |              |                |              |              |                |           |
| Decrypt · AES-256-CCM (CryptoHives-ARM-AES) | 128KB        |   211,187.9 ns |    128.92 ns |    114.29 ns |   211,174.3 ns |         - |
| Decrypt · AES-256-CCM (CryptoHives-Scalar)  | 128KB        | 1,058,243.4 ns | 20,552.44 ns | 57,291.98 ns | 1,028,007.9 ns |         - |
| Decrypt · AES-256-CCM (BouncyCastle)        | 128KB        | 1,071,580.1 ns |    437.42 ns |    365.27 ns | 1,071,499.6 ns |  133988 B |
|                                             |              |                |              |              |                |           |
| Encrypt · AES-256-CCM (CryptoHives-ARM-AES) | 128KB        |   997,155.1 ns |    829.54 ns |    735.36 ns |   997,154.5 ns |         - |
| Encrypt · AES-256-CCM (CryptoHives-Scalar)  | 128KB        | 4,773,981.6 ns |  2,226.39 ns |  1,859.13 ns | 4,773,661.9 ns |         - |
| Encrypt · AES-256-CCM (BouncyCastle)        | 128KB        | 4,917,964.7 ns |  3,510.33 ns |  2,931.29 ns | 4,917,206.1 ns |    2904 B |