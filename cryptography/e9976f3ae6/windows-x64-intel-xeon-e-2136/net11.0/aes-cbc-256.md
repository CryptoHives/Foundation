| Description                                | TestDataSize | Mean           | Error       | StdDev      | Code Size | Allocated |
|------------------------------------------- |------------- |---------------:|------------:|------------:|----------:|----------:|
| Decrypt · AES-256-CBC (CryptoHives-AES-NI) | 128B         |       111.1 ns |     0.21 ns |     0.18 ns |     255 B |         - |
| Decrypt · AES-256-CBC (OS)                 | 128B         |       161.9 ns |     3.10 ns |     3.57 ns |  11,036 B |         - |
| Decrypt · AES-256-CBC (CryptoHives-Scalar) | 128B         |       965.6 ns |     2.58 ns |     2.29 ns |     255 B |         - |
| Decrypt · AES-256-CBC (BouncyCastle)       | 128B         |     1,878.1 ns |     2.09 ns |     1.64 ns |  13,925 B |    1024 B |
|                                            |              |                |             |             |           |           |
| Encrypt · AES-256-CBC (CryptoHives-AES-NI) | 128B         |       198.7 ns |     0.06 ns |     0.05 ns |     255 B |         - |
| Encrypt · AES-256-CBC (OS)                 | 128B         |       251.9 ns |     0.37 ns |     0.31 ns |   9,695 B |         - |
| Encrypt · AES-256-CBC (CryptoHives-Scalar) | 128B         |     1,006.1 ns |     5.90 ns |     5.52 ns |     255 B |         - |
| Encrypt · AES-256-CBC (BouncyCastle)       | 128B         |     1,671.3 ns |     5.29 ns |     4.95 ns |   7,776 B |    1024 B |
|                                            |              |                |             |             |           |           |
| Decrypt · AES-256-CBC (OS)                 | 1KB          |       398.2 ns |     1.29 ns |     1.20 ns |  17,413 B |         - |
| Decrypt · AES-256-CBC (CryptoHives-AES-NI) | 1KB          |       473.9 ns |     1.77 ns |     1.65 ns |     255 B |         - |
| Decrypt · AES-256-CBC (CryptoHives-Scalar) | 1KB          |     6,618.1 ns |    35.17 ns |    32.90 ns |     255 B |         - |
| Decrypt · AES-256-CBC (BouncyCastle)       | 1KB          |    10,425.8 ns |    32.76 ns |    29.04 ns |   7,776 B |    1024 B |
|                                            |              |                |             |             |           |           |
| Encrypt · AES-256-CBC (CryptoHives-AES-NI) | 1KB          |     1,212.4 ns |     0.29 ns |     0.23 ns |     255 B |         - |
| Encrypt · AES-256-CBC (OS)                 | 1KB          |     1,219.3 ns |     0.33 ns |     0.28 ns |   9,695 B |         - |
| Encrypt · AES-256-CBC (CryptoHives-Scalar) | 1KB          |     6,972.3 ns |    17.46 ns |    16.33 ns |     255 B |         - |
| Encrypt · AES-256-CBC (BouncyCastle)       | 1KB          |     9,594.0 ns |    32.35 ns |    27.01 ns |   7,776 B |    1024 B |
|                                            |              |                |             |             |           |           |
| Decrypt · AES-256-CBC (OS)                 | 8KB          |     2,361.4 ns |     4.89 ns |     4.58 ns |  17,811 B |         - |
| Decrypt · AES-256-CBC (CryptoHives-AES-NI) | 8KB          |     3,372.9 ns |     3.41 ns |     3.03 ns |     255 B |         - |
| Decrypt · AES-256-CBC (CryptoHives-Scalar) | 8KB          |    51,817.0 ns |   141.18 ns |   125.16 ns |     255 B |         - |
| Decrypt · AES-256-CBC (BouncyCastle)       | 8KB          |    77,673.2 ns |   135.95 ns |   106.14 ns |  13,735 B |    1024 B |
|                                            |              |                |             |             |           |           |
| Encrypt · AES-256-CBC (OS)                 | 8KB          |     9,115.4 ns |    17.04 ns |    15.94 ns |   9,790 B |         - |
| Encrypt · AES-256-CBC (CryptoHives-AES-NI) | 8KB          |     9,333.3 ns |     2.33 ns |     1.94 ns |     255 B |         - |
| Encrypt · AES-256-CBC (CryptoHives-Scalar) | 8KB          |    54,822.8 ns |   189.74 ns |   177.49 ns |     255 B |         - |
| Encrypt · AES-256-CBC (BouncyCastle)       | 8KB          |    72,723.0 ns |    70.76 ns |    55.25 ns |   7,776 B |    1024 B |
|                                            |              |                |             |             |           |           |
| Decrypt · AES-256-CBC (OS)                 | 128KB        |    35,402.1 ns |    32.17 ns |    28.52 ns |  11,078 B |         - |
| Decrypt · AES-256-CBC (CryptoHives-AES-NI) | 128KB        |    53,500.6 ns |    94.19 ns |    78.66 ns |     255 B |         - |
| Decrypt · AES-256-CBC (CryptoHives-Scalar) | 128KB        |   828,216.8 ns |   846.21 ns |   706.63 ns |     255 B |         - |
| Decrypt · AES-256-CBC (BouncyCastle)       | 128KB        | 1,185,926.7 ns | 1,651.52 ns | 1,379.10 ns |  13,735 B |    1024 B |
|                                            |              |                |             |             |           |           |
| Encrypt · AES-256-CBC (OS)                 | 128KB        |   145,446.2 ns |   484.89 ns |   453.56 ns |  16,503 B |         - |
| Encrypt · AES-256-CBC (CryptoHives-AES-NI) | 128KB        |   148,571.3 ns |    42.59 ns |    35.57 ns |     255 B |         - |
| Encrypt · AES-256-CBC (CryptoHives-Scalar) | 128KB        |   875,498.5 ns | 1,952.69 ns | 1,826.55 ns |     255 B |         - |
| Encrypt · AES-256-CBC (BouncyCastle)       | 128KB        | 1,223,792.7 ns | 4,484.17 ns | 3,975.10 ns |   7,776 B |    1024 B |