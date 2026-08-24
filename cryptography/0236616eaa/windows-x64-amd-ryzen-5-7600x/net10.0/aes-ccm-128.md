| Description                                | TestDataSize | Mean           | Error       | StdDev      | Allocated |
|------------------------------------------- |------------- |---------------:|------------:|------------:|----------:|
| Decrypt · AES-128-CCM (CryptoHives-AES-NI) | 128B         |       423.5 ns |     2.49 ns |     2.33 ns |         - |
| Decrypt · AES-128-CCM (CryptoHives-Scalar) | 128B         |     1,389.3 ns |     8.67 ns |     7.69 ns |         - |
| Decrypt · AES-128-CCM (BouncyCastle)       | 128B         |     1,596.9 ns |    15.69 ns |    14.68 ns |    2616 B |
|                                            |              |                |             |             |           |
| Encrypt · AES-128-CCM (CryptoHives-AES-NI) | 128B         |       353.3 ns |     0.60 ns |     0.53 ns |         - |
| Encrypt · AES-128-CCM (CryptoHives-Scalar) | 128B         |     1,339.4 ns |     3.47 ns |     2.90 ns |         - |
| Encrypt · AES-128-CCM (BouncyCastle)       | 128B         |     1,503.6 ns |     4.01 ns |     3.56 ns |    2504 B |
|                                            |              |                |             |             |           |
| Decrypt · AES-128-CCM (CryptoHives-AES-NI) | 1KB          |     2,339.5 ns |    20.19 ns |    17.89 ns |         - |
| Decrypt · AES-128-CCM (BouncyCastle)       | 1KB          |     8,208.7 ns |    17.26 ns |    14.42 ns |    3512 B |
| Decrypt · AES-128-CCM (CryptoHives-Scalar) | 1KB          |     8,944.5 ns |   136.47 ns |   120.97 ns |         - |
|                                            |              |                |             |             |           |
| Encrypt · AES-128-CCM (CryptoHives-AES-NI) | 1KB          |     2,258.1 ns |     5.35 ns |     4.74 ns |         - |
| Encrypt · AES-128-CCM (BouncyCastle)       | 1KB          |     8,174.2 ns |    19.79 ns |    16.52 ns |    2504 B |
| Encrypt · AES-128-CCM (CryptoHives-Scalar) | 1KB          |     8,835.9 ns |    39.77 ns |    35.26 ns |         - |
|                                            |              |                |             |             |           |
| Decrypt · AES-128-CCM (CryptoHives-AES-NI) | 8KB          |    17,512.4 ns |    23.07 ns |    19.26 ns |         - |
| Decrypt · AES-128-CCM (BouncyCastle)       | 8KB          |    61,494.6 ns |   304.61 ns |   254.37 ns |   10680 B |
| Decrypt · AES-128-CCM (CryptoHives-Scalar) | 8KB          |    68,100.1 ns |   130.18 ns |   115.40 ns |         - |
|                                            |              |                |             |             |           |
| Encrypt · AES-128-CCM (CryptoHives-AES-NI) | 8KB          |    17,505.6 ns |    24.81 ns |    23.21 ns |         - |
| Encrypt · AES-128-CCM (BouncyCastle)       | 8KB          |    60,852.5 ns |   151.82 ns |   142.01 ns |    2504 B |
| Encrypt · AES-128-CCM (CryptoHives-Scalar) | 8KB          |    68,155.0 ns |   172.73 ns |   144.24 ns |         - |
|                                            |              |                |             |             |           |
| Decrypt · AES-128-CCM (CryptoHives-AES-NI) | 128KB        |   277,761.6 ns |   318.23 ns |   265.74 ns |         - |
| Decrypt · AES-128-CCM (BouncyCastle)       | 128KB        |   998,098.9 ns | 1,566.42 ns | 1,388.59 ns |  133574 B |
| Decrypt · AES-128-CCM (CryptoHives-Scalar) | 128KB        | 1,162,115.9 ns | 2,838.60 ns | 2,516.34 ns |         - |
|                                            |              |                |             |             |           |
| Encrypt · AES-128-CCM (CryptoHives-AES-NI) | 128KB        |   278,270.2 ns |   529.19 ns |   469.12 ns |         - |
| Encrypt · AES-128-CCM (BouncyCastle)       | 128KB        |   971,864.7 ns | 4,732.12 ns | 4,426.43 ns |    2504 B |
| Encrypt · AES-128-CCM (CryptoHives-Scalar) | 128KB        | 1,171,412.1 ns | 5,342.24 ns | 4,461.01 ns |         - |