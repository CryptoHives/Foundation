| Description                                | TestDataSize | Mean         | Error        | StdDev       | Allocated |
|------------------------------------------- |------------- |-------------:|-------------:|-------------:|----------:|
| Decrypt · AES-128-CCM (CryptoHives-AES-NI) | 128B         |     412.6 ns |      4.07 ns |      3.80 ns |         - |
| Decrypt · AES-128-CCM (CryptoHives-Scalar) | 128B         |   1,027.6 ns |     15.36 ns |     14.37 ns |         - |
| Decrypt · AES-128-CCM (BouncyCastle)       | 128B         |   1,677.2 ns |     18.39 ns |     16.30 ns |    2424 B |
|                                            |              |              |              |              |           |
| Encrypt · AES-128-CCM (CryptoHives-AES-NI) | 128B         |     352.9 ns |      1.77 ns |      1.65 ns |         - |
| Encrypt · AES-128-CCM (CryptoHives-Scalar) | 128B         |   1,000.2 ns |     19.55 ns |     19.20 ns |         - |
| Encrypt · AES-128-CCM (BouncyCastle)       | 128B         |   1,641.6 ns |     24.09 ns |     22.54 ns |    2464 B |
|                                            |              |              |              |              |           |
| Decrypt · AES-128-CCM (CryptoHives-AES-NI) | 1KB          |   2,315.7 ns |     15.64 ns |     13.86 ns |         - |
| Decrypt · AES-128-CCM (CryptoHives-Scalar) | 1KB          |   6,500.7 ns |     83.94 ns |     74.41 ns |         - |
| Decrypt · AES-128-CCM (BouncyCastle)       | 1KB          |   8,529.0 ns |    112.23 ns |    104.98 ns |    2424 B |
|                                            |              |              |              |              |           |
| Encrypt · AES-128-CCM (CryptoHives-AES-NI) | 1KB          |   2,258.3 ns |     17.74 ns |     15.72 ns |         - |
| Encrypt · AES-128-CCM (CryptoHives-Scalar) | 1KB          |   6,497.7 ns |     87.78 ns |     82.11 ns |         - |
| Encrypt · AES-128-CCM (BouncyCastle)       | 1KB          |   8,325.9 ns |    113.60 ns |    100.71 ns |    2464 B |
|                                            |              |              |              |              |           |
| Decrypt · AES-128-CCM (CryptoHives-AES-NI) | 8KB          |  17,581.8 ns |    199.29 ns |    186.42 ns |         - |
| Decrypt · AES-128-CCM (CryptoHives-Scalar) | 8KB          |  59,723.6 ns |    596.31 ns |    528.61 ns |         - |
| Decrypt · AES-128-CCM (BouncyCastle)       | 8KB          |  61,227.1 ns |    432.64 ns |    404.69 ns |    2424 B |
|                                            |              |              |              |              |           |
| Encrypt · AES-128-CCM (CryptoHives-AES-NI) | 8KB          |  17,609.3 ns |    221.45 ns |    196.31 ns |         - |
| Encrypt · AES-128-CCM (CryptoHives-Scalar) | 8KB          |  50,436.7 ns |    594.71 ns |    556.29 ns |         - |
| Encrypt · AES-128-CCM (BouncyCastle)       | 8KB          |  61,468.1 ns |    532.57 ns |    498.17 ns |    2464 B |
|                                            |              |              |              |              |           |
| Decrypt · AES-128-CCM (CryptoHives-AES-NI) | 128KB        | 278,204.0 ns |  2,858.81 ns |  2,387.24 ns |         - |
| Decrypt · AES-128-CCM (CryptoHives-Scalar) | 128KB        | 800,486.6 ns |  9,285.72 ns |  8,685.87 ns |         - |
| Decrypt · AES-128-CCM (BouncyCastle)       | 128KB        | 974,323.0 ns | 12,288.80 ns | 10,893.70 ns |    2424 B |
|                                            |              |              |              |              |           |
| Encrypt · AES-128-CCM (CryptoHives-AES-NI) | 128KB        | 278,912.4 ns |  3,351.30 ns |  3,134.81 ns |         - |
| Encrypt · AES-128-CCM (CryptoHives-Scalar) | 128KB        | 801,453.4 ns | 11,196.19 ns | 10,472.92 ns |         - |
| Encrypt · AES-128-CCM (BouncyCastle)       | 128KB        | 970,425.2 ns |  9,298.90 ns |  8,243.24 ns |    2464 B |