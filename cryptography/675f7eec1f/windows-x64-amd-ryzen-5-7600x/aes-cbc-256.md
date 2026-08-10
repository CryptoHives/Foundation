| Description                                | TestDataSize | Mean          | Error        | StdDev       | Allocated |
|------------------------------------------- |------------- |--------------:|-------------:|-------------:|----------:|
| Decrypt · AES-256-CBC (CryptoHives-AES-NI) | 128B         |      61.74 ns |     0.267 ns |     0.250 ns |         - |
| Decrypt · AES-256-CBC (OS)                 | 128B         |     272.54 ns |     3.843 ns |     3.595 ns |     128 B |
| Decrypt · AES-256-CBC (CryptoHives-Scalar) | 128B         |     570.67 ns |     2.848 ns |     2.378 ns |         - |
| Decrypt · AES-256-CBC (BouncyCastle)       | 128B         |     940.76 ns |    17.935 ns |    16.776 ns |    1024 B |
|                                            |              |               |              |              |           |
| Encrypt · AES-256-CBC (CryptoHives-AES-NI) | 128B         |     129.82 ns |     1.863 ns |     1.743 ns |         - |
| Encrypt · AES-256-CBC (OS)                 | 128B         |     322.00 ns |     3.433 ns |     3.043 ns |     128 B |
| Encrypt · AES-256-CBC (CryptoHives-Scalar) | 128B         |     575.20 ns |     6.665 ns |     6.234 ns |         - |
| Encrypt · AES-256-CBC (BouncyCastle)       | 128B         |     818.10 ns |    16.170 ns |    15.126 ns |    1024 B |
|                                            |              |               |              |              |           |
| Decrypt · AES-256-CBC (CryptoHives-AES-NI) | 1KB          |     305.45 ns |     3.952 ns |     3.697 ns |         - |
| Decrypt · AES-256-CBC (OS)                 | 1KB          |     344.56 ns |     3.976 ns |     3.719 ns |     128 B |
| Decrypt · AES-256-CBC (CryptoHives-Scalar) | 1KB          |   4,191.15 ns |    80.366 ns |    62.745 ns |         - |
| Decrypt · AES-256-CBC (BouncyCastle)       | 1KB          |   5,001.74 ns |    92.737 ns |    86.746 ns |    1024 B |
|                                            |              |               |              |              |           |
| Encrypt · AES-256-CBC (CryptoHives-AES-NI) | 1KB          |     753.54 ns |     9.482 ns |     8.869 ns |         - |
| Encrypt · AES-256-CBC (OS)                 | 1KB          |     900.36 ns |     6.526 ns |     5.785 ns |     128 B |
| Encrypt · AES-256-CBC (CryptoHives-Scalar) | 1KB          |   4,052.77 ns |    42.241 ns |    35.273 ns |         - |
| Encrypt · AES-256-CBC (BouncyCastle)       | 1KB          |   4,861.04 ns |    73.932 ns |    69.156 ns |    1024 B |
|                                            |              |               |              |              |           |
| Decrypt · AES-256-CBC (OS)                 | 8KB          |     960.97 ns |     8.184 ns |     7.255 ns |     128 B |
| Decrypt · AES-256-CBC (CryptoHives-AES-NI) | 8KB          |   2,230.65 ns |    22.790 ns |    21.318 ns |         - |
| Decrypt · AES-256-CBC (CryptoHives-Scalar) | 8KB          |  32,570.22 ns |   522.803 ns |   489.030 ns |         - |
| Decrypt · AES-256-CBC (BouncyCastle)       | 8KB          |  37,377.63 ns |   414.761 ns |   387.968 ns |    1024 B |
|                                            |              |               |              |              |           |
| Encrypt · AES-256-CBC (CryptoHives-AES-NI) | 8KB          |   5,832.79 ns |    60.991 ns |    50.930 ns |         - |
| Encrypt · AES-256-CBC (OS)                 | 8KB          |   5,874.50 ns |    40.222 ns |    37.624 ns |     128 B |
| Encrypt · AES-256-CBC (CryptoHives-Scalar) | 8KB          |  32,249.66 ns |   433.742 ns |   405.722 ns |         - |
| Encrypt · AES-256-CBC (BouncyCastle)       | 8KB          |  37,176.95 ns |   524.839 ns |   465.256 ns |    1024 B |
|                                            |              |               |              |              |           |
| Decrypt · AES-256-CBC (OS)                 | 128KB        |  11,857.07 ns |    87.247 ns |    72.855 ns |     128 B |
| Decrypt · AES-256-CBC (CryptoHives-AES-NI) | 128KB        |  35,127.00 ns |   337.963 ns |   299.595 ns |         - |
| Decrypt · AES-256-CBC (CryptoHives-Scalar) | 128KB        | 523,460.53 ns | 6,375.347 ns | 5,651.579 ns |         - |
| Decrypt · AES-256-CBC (BouncyCastle)       | 128KB        | 590,541.01 ns | 7,847.407 ns | 6,552.941 ns |    1024 B |
|                                            |              |               |              |              |           |
| Encrypt · AES-256-CBC (OS)                 | 128KB        |  91,236.45 ns |   420.119 ns |   372.424 ns |     128 B |
| Encrypt · AES-256-CBC (CryptoHives-AES-NI) | 128KB        |  92,665.90 ns |   516.943 ns |   483.549 ns |         - |
| Encrypt · AES-256-CBC (CryptoHives-Scalar) | 128KB        | 507,281.98 ns | 2,009.266 ns | 1,879.469 ns |         - |
| Encrypt · AES-256-CBC (BouncyCastle)       | 128KB        | 584,313.73 ns | 3,871.240 ns | 3,621.161 ns |    1024 B |