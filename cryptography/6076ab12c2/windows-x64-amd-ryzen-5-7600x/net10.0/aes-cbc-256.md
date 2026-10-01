| Description                                | TestDataSize | Mean          | Error        | StdDev       | Allocated |
|------------------------------------------- |------------- |--------------:|-------------:|-------------:|----------:|
| Decrypt · AES-256-CBC (CryptoHives-AES-NI) | 128B         |      71.35 ns |     0.766 ns |     0.717 ns |         - |
| Decrypt · AES-256-CBC (OS)                 | 128B         |     300.66 ns |     5.814 ns |     5.438 ns |     128 B |
| Decrypt · AES-256-CBC (CryptoHives-Scalar) | 128B         |     626.41 ns |     8.885 ns |     8.311 ns |         - |
| Decrypt · AES-256-CBC (BouncyCastle)       | 128B         |   1,022.59 ns |    12.878 ns |    12.046 ns |    1024 B |
|                                            |              |               |              |              |           |
| Encrypt · AES-256-CBC (CryptoHives-AES-NI) | 128B         |     126.29 ns |     0.482 ns |     0.450 ns |         - |
| Encrypt · AES-256-CBC (OS)                 | 128B         |     365.53 ns |     4.541 ns |     4.247 ns |     128 B |
| Encrypt · AES-256-CBC (CryptoHives-Scalar) | 128B         |     609.73 ns |     9.601 ns |     8.981 ns |         - |
| Encrypt · AES-256-CBC (BouncyCastle)       | 128B         |     911.62 ns |    12.692 ns |    11.872 ns |    1024 B |
|                                            |              |               |              |              |           |
| Decrypt · AES-256-CBC (CryptoHives-AES-NI) | 1KB          |     347.55 ns |     2.349 ns |     2.197 ns |         - |
| Decrypt · AES-256-CBC (OS)                 | 1KB          |     387.81 ns |     6.904 ns |     6.458 ns |     128 B |
| Decrypt · AES-256-CBC (CryptoHives-Scalar) | 1KB          |   4,402.37 ns |    59.973 ns |    56.099 ns |         - |
| Decrypt · AES-256-CBC (BouncyCastle)       | 1KB          |   5,644.62 ns |    44.572 ns |    37.219 ns |    1024 B |
|                                            |              |               |              |              |           |
| Encrypt · AES-256-CBC (CryptoHives-AES-NI) | 1KB          |     842.93 ns |     0.757 ns |     0.708 ns |         - |
| Encrypt · AES-256-CBC (OS)                 | 1KB          |   1,063.03 ns |     8.323 ns |     7.785 ns |     128 B |
| Encrypt · AES-256-CBC (CryptoHives-Scalar) | 1KB          |   4,306.73 ns |    63.109 ns |    59.032 ns |         - |
| Encrypt · AES-256-CBC (BouncyCastle)       | 1KB          |   5,567.32 ns |    68.140 ns |    63.738 ns |    1024 B |
|                                            |              |               |              |              |           |
| Decrypt · AES-256-CBC (OS)                 | 8KB          |   1,115.31 ns |    12.784 ns |    11.958 ns |     128 B |
| Decrypt · AES-256-CBC (CryptoHives-AES-NI) | 8KB          |   2,564.75 ns |    20.486 ns |    19.163 ns |         - |
| Decrypt · AES-256-CBC (CryptoHives-Scalar) | 8KB          |  34,566.49 ns |   294.807 ns |   275.763 ns |         - |
| Decrypt · AES-256-CBC (BouncyCastle)       | 8KB          |  42,654.21 ns |   595.978 ns |   557.479 ns |    1024 B |
|                                            |              |               |              |              |           |
| Encrypt · AES-256-CBC (CryptoHives-AES-NI) | 8KB          |   6,446.06 ns |     4.892 ns |     4.337 ns |         - |
| Encrypt · AES-256-CBC (OS)                 | 8KB          |   6,601.87 ns |    10.822 ns |    10.123 ns |     128 B |
| Encrypt · AES-256-CBC (CryptoHives-Scalar) | 8KB          |  33,900.02 ns |   414.005 ns |   387.261 ns |         - |
| Encrypt · AES-256-CBC (BouncyCastle)       | 8KB          |  42,847.56 ns |   454.024 ns |   424.695 ns |    1024 B |
|                                            |              |               |              |              |           |
| Decrypt · AES-256-CBC (OS)                 | 128KB        |  13,723.32 ns |    70.184 ns |    65.651 ns |     128 B |
| Decrypt · AES-256-CBC (CryptoHives-AES-NI) | 128KB        |  40,647.55 ns |   314.283 ns |   293.981 ns |         - |
| Decrypt · AES-256-CBC (CryptoHives-Scalar) | 128KB        | 549,416.58 ns | 7,109.496 ns | 6,650.227 ns |         - |
| Decrypt · AES-256-CBC (BouncyCastle)       | 128KB        | 675,667.74 ns | 9,163.882 ns | 8,571.901 ns |    1024 B |
|                                            |              |               |              |              |           |
| Encrypt · AES-256-CBC (OS)                 | 128KB        | 101,480.07 ns |   165.018 ns |   154.358 ns |     128 B |
| Encrypt · AES-256-CBC (CryptoHives-AES-NI) | 128KB        | 102,729.07 ns |    81.691 ns |    76.413 ns |         - |
| Encrypt · AES-256-CBC (CryptoHives-Scalar) | 128KB        | 541,114.65 ns | 7,844.198 ns | 7,337.467 ns |         - |
| Encrypt · AES-256-CBC (BouncyCastle)       | 128KB        | 680,651.49 ns | 8,558.640 ns | 8,005.757 ns |    1024 B |