| Description                                | TestDataSize | Mean          | Error        | StdDev       | Code Size | Allocated |
|------------------------------------------- |------------- |--------------:|-------------:|-------------:|----------:|----------:|
| Decrypt · AES-256-CBC (CryptoHives-AES-NI) | 128B         |      65.54 ns |     0.214 ns |     0.190 ns |     255 B |         - |
| Decrypt · AES-256-CBC (OS)                 | 128B         |     296.14 ns |     1.143 ns |     0.955 ns |  11,790 B |     128 B |
| Decrypt · AES-256-CBC (CryptoHives-Scalar) | 128B         |     591.55 ns |     1.853 ns |     1.643 ns |     255 B |         - |
| Decrypt · AES-256-CBC (BouncyCastle)       | 128B         |   1,000.56 ns |     4.107 ns |     3.842 ns |   2,909 B |    1024 B |
|                                            |              |               |              |              |           |           |
| Encrypt · AES-256-CBC (CryptoHives-AES-NI) | 128B         |     129.14 ns |     0.143 ns |     0.127 ns |     255 B |         - |
| Encrypt · AES-256-CBC (OS)                 | 128B         |     365.66 ns |     4.001 ns |     3.547 ns |   9,935 B |     128 B |
| Encrypt · AES-256-CBC (CryptoHives-Scalar) | 128B         |     662.10 ns |     2.032 ns |     1.801 ns |     255 B |         - |
| Encrypt · AES-256-CBC (BouncyCastle)       | 128B         |     906.75 ns |     2.561 ns |     2.270 ns |   2,898 B |    1024 B |
|                                            |              |               |              |              |           |           |
| Decrypt · AES-256-CBC (CryptoHives-AES-NI) | 1KB          |     342.39 ns |     0.367 ns |     0.307 ns |     255 B |         - |
| Decrypt · AES-256-CBC (OS)                 | 1KB          |     383.71 ns |     1.484 ns |     1.315 ns |  11,787 B |     128 B |
| Decrypt · AES-256-CBC (CryptoHives-Scalar) | 1KB          |   4,083.47 ns |    10.394 ns |     9.214 ns |     255 B |         - |
| Decrypt · AES-256-CBC (BouncyCastle)       | 1KB          |   5,573.99 ns |    20.454 ns |    18.132 ns |   2,913 B |    1024 B |
|                                            |              |               |              |              |           |           |
| Encrypt · AES-256-CBC (CryptoHives-AES-NI) | 1KB          |     833.00 ns |     1.096 ns |     1.025 ns |     255 B |         - |
| Encrypt · AES-256-CBC (OS)                 | 1KB          |   1,060.11 ns |     8.552 ns |     7.581 ns |   9,896 B |     128 B |
| Encrypt · AES-256-CBC (CryptoHives-Scalar) | 1KB          |   4,319.93 ns |    52.743 ns |    49.335 ns |     255 B |         - |
| Encrypt · AES-256-CBC (BouncyCastle)       | 1KB          |   5,588.12 ns |    85.485 ns |    79.963 ns |   2,904 B |    1024 B |
|                                            |              |               |              |              |           |           |
| Decrypt · AES-256-CBC (OS)                 | 8KB          |   1,097.19 ns |     2.124 ns |     1.882 ns |  12,049 B |     128 B |
| Decrypt · AES-256-CBC (CryptoHives-AES-NI) | 8KB          |   2,547.89 ns |     5.296 ns |     4.422 ns |     255 B |         - |
| Decrypt · AES-256-CBC (CryptoHives-Scalar) | 8KB          |  32,158.87 ns |   158.312 ns |   140.340 ns |     255 B |         - |
| Decrypt · AES-256-CBC (BouncyCastle)       | 8KB          |  41,994.20 ns |   157.846 ns |   139.926 ns |   2,911 B |    1024 B |
|                                            |              |               |              |              |           |           |
| Encrypt · AES-256-CBC (CryptoHives-AES-NI) | 8KB          |   6,456.91 ns |     4.492 ns |     4.202 ns |     255 B |         - |
| Encrypt · AES-256-CBC (OS)                 | 8KB          |   6,550.73 ns |     3.308 ns |     2.762 ns |  10,864 B |     128 B |
| Encrypt · AES-256-CBC (CryptoHives-Scalar) | 8KB          |  33,931.49 ns |   396.667 ns |   371.043 ns |     255 B |         - |
| Encrypt · AES-256-CBC (BouncyCastle)       | 8KB          |  42,822.57 ns |   552.294 ns |   516.616 ns |   2,911 B |    1024 B |
|                                            |              |               |              |              |           |           |
| Decrypt · AES-256-CBC (OS)                 | 128KB        |  13,696.51 ns |     9.363 ns |     8.300 ns |  12,851 B |     128 B |
| Decrypt · AES-256-CBC (CryptoHives-AES-NI) | 128KB        |  40,442.35 ns |   114.324 ns |    95.465 ns |     255 B |         - |
| Decrypt · AES-256-CBC (CryptoHives-Scalar) | 128KB        | 511,265.03 ns | 1,991.161 ns | 1,862.533 ns |     255 B |         - |
| Decrypt · AES-256-CBC (BouncyCastle)       | 128KB        | 666,020.15 ns | 2,478.724 ns | 2,197.324 ns |   2,911 B |    1024 B |
|                                            |              |               |              |              |           |           |
| Encrypt · AES-256-CBC (OS)                 | 128KB        | 101,624.26 ns |    81.050 ns |    71.849 ns |  11,262 B |     128 B |
| Encrypt · AES-256-CBC (CryptoHives-AES-NI) | 128KB        | 103,125.64 ns |    49.093 ns |    43.520 ns |     255 B |         - |
| Encrypt · AES-256-CBC (CryptoHives-Scalar) | 128KB        | 532,542.46 ns | 1,696.114 ns | 1,416.332 ns |     255 B |         - |
| Encrypt · AES-256-CBC (BouncyCastle)       | 128KB        | 669,494.89 ns | 2,362.133 ns | 2,093.970 ns |   2,911 B |    1024 B |