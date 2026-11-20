| Description                                | TestDataSize | Mean         | Error       | StdDev      | Code Size | Allocated |
|------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|----------:|
| Decrypt · AES-128-CBC (CryptoHives-AES-NI) | 128B         |     101.7 ns |     0.23 ns |     0.22 ns |     255 B |         - |
| Decrypt · AES-128-CBC (OS)                 | 128B         |     143.8 ns |     0.43 ns |     0.36 ns |  11,078 B |         - |
| Decrypt · AES-128-CBC (CryptoHives-Scalar) | 128B         |     761.7 ns |     2.56 ns |     2.39 ns |     255 B |         - |
| Decrypt · AES-128-CBC (BouncyCastle)       | 128B         |   1,527.0 ns |     4.70 ns |     4.40 ns |   7,776 B |     832 B |
|                                            |              |              |             |             |           |           |
| Encrypt · AES-128-CBC (CryptoHives-AES-NI) | 128B         |     157.6 ns |     0.69 ns |     0.65 ns |     255 B |         - |
| Encrypt · AES-128-CBC (OS)                 | 128B         |     207.0 ns |     0.13 ns |     0.12 ns |  16,030 B |         - |
| Encrypt · AES-128-CBC (CryptoHives-Scalar) | 128B         |     797.3 ns |     0.56 ns |     0.44 ns |     255 B |         - |
| Encrypt · AES-128-CBC (BouncyCastle)       | 128B         |   1,341.2 ns |     4.55 ns |     4.26 ns |   7,776 B |     832 B |
|                                            |              |              |             |             |           |           |
| Decrypt · AES-128-CBC (OS)                 | 1KB          |     315.8 ns |     0.22 ns |     0.20 ns |  11,134 B |         - |
| Decrypt · AES-128-CBC (CryptoHives-AES-NI) | 1KB          |     375.7 ns |     0.76 ns |     0.67 ns |     255 B |         - |
| Decrypt · AES-128-CBC (CryptoHives-Scalar) | 1KB          |   5,139.3 ns |    24.24 ns |    22.67 ns |     255 B |         - |
| Decrypt · AES-128-CBC (BouncyCastle)       | 1KB          |   7,974.0 ns |    12.77 ns |    10.66 ns |   7,776 B |     832 B |
|                                            |              |              |             |             |           |           |
| Encrypt · AES-128-CBC (CryptoHives-AES-NI) | 1KB          |     901.9 ns |     0.68 ns |     0.64 ns |     255 B |         - |
| Encrypt · AES-128-CBC (OS)                 | 1KB          |     911.2 ns |     0.85 ns |     0.71 ns |   9,751 B |         - |
| Encrypt · AES-128-CBC (CryptoHives-Scalar) | 1KB          |   5,513.3 ns |    11.21 ns |     9.94 ns |     255 B |         - |
| Encrypt · AES-128-CBC (BouncyCastle)       | 1KB          |   8,130.1 ns |    16.43 ns |    15.37 ns |  13,735 B |     832 B |
|                                            |              |              |             |             |           |           |
| Decrypt · AES-128-CBC (OS)                 | 8KB          |   1,725.3 ns |     0.82 ns |     0.73 ns |  17,413 B |         - |
| Decrypt · AES-128-CBC (CryptoHives-AES-NI) | 8KB          |   2,632.1 ns |     5.95 ns |     5.28 ns |     255 B |         - |
| Decrypt · AES-128-CBC (CryptoHives-Scalar) | 8KB          |  40,092.2 ns |    57.46 ns |    44.86 ns |     255 B |         - |
| Decrypt · AES-128-CBC (BouncyCastle)       | 8KB          |  63,912.8 ns |   117.58 ns |   104.23 ns |  13,925 B |     832 B |
|                                            |              |              |             |             |           |           |
| Encrypt · AES-128-CBC (OS)                 | 8KB          |   6,566.3 ns |     3.57 ns |     3.34 ns |  16,069 B |         - |
| Encrypt · AES-128-CBC (CryptoHives-AES-NI) | 8KB          |   6,841.4 ns |     1.32 ns |     1.10 ns |     255 B |         - |
| Encrypt · AES-128-CBC (CryptoHives-Scalar) | 8KB          |  43,413.2 ns |   130.16 ns |   115.38 ns |     255 B |         - |
| Encrypt · AES-128-CBC (BouncyCastle)       | 8KB          |  59,117.9 ns |   112.93 ns |   100.11 ns |   7,776 B |     832 B |
|                                            |              |              |             |             |           |           |
| Decrypt · AES-128-CBC (OS)                 | 128KB        |  25,339.1 ns |    13.46 ns |    11.24 ns |  17,413 B |         - |
| Decrypt · AES-128-CBC (CryptoHives-AES-NI) | 128KB        |  41,337.3 ns |   168.24 ns |   149.14 ns |     255 B |         - |
| Decrypt · AES-128-CBC (CryptoHives-Scalar) | 128KB        | 642,545.9 ns |   960.42 ns |   749.83 ns |     255 B |         - |
| Decrypt · AES-128-CBC (BouncyCastle)       | 128KB        | 985,452.1 ns | 4,466.35 ns | 3,959.30 ns |  13,735 B |     832 B |
|                                            |              |              |             |             |           |           |
| Encrypt · AES-128-CBC (OS)                 | 128KB        | 105,375.9 ns |   215.60 ns |   201.67 ns |  16,105 B |         - |
| Encrypt · AES-128-CBC (CryptoHives-AES-NI) | 128KB        | 108,536.9 ns |    29.84 ns |    27.91 ns |     255 B |         - |
| Encrypt · AES-128-CBC (CryptoHives-Scalar) | 128KB        | 693,714.6 ns | 1,500.16 ns | 1,252.70 ns |     255 B |         - |
| Encrypt · AES-128-CBC (BouncyCastle)       | 128KB        | 982,384.3 ns | 5,493.31 ns | 5,138.45 ns |  13,735 B |     832 B |