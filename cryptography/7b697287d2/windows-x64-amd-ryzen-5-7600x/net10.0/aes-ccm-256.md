| Description                                | TestDataSize | Mean           | Error       | StdDev      | Code Size | Allocated |
|------------------------------------------- |------------- |---------------:|------------:|------------:|----------:|----------:|
| Decrypt · AES-256-CCM (CryptoHives-AES-NI) | 128B         |       504.8 ns |     0.37 ns |     0.35 ns |   9,490 B |         - |
| Decrypt · AES-256-CCM (CryptoHives-Scalar) | 128B         |     1,271.0 ns |     2.16 ns |     2.02 ns |  10,459 B |         - |
| Decrypt · AES-256-CCM (BouncyCastle)       | 128B         |     2,142.6 ns |     9.36 ns |     8.76 ns |     306 B |    3016 B |
|                                            |              |                |             |             |           |           |
| Encrypt · AES-256-CCM (CryptoHives-AES-NI) | 128B         |       434.9 ns |     0.18 ns |     0.16 ns |   9,438 B |         - |
| Encrypt · AES-256-CCM (CryptoHives-Scalar) | 128B         |     1,222.1 ns |     2.80 ns |     2.33 ns |  10,407 B |         - |
| Encrypt · AES-256-CCM (BouncyCastle)       | 128B         |     2,087.4 ns |     8.38 ns |     7.84 ns |     383 B |    2904 B |
|                                            |              |                |             |             |           |           |
| Decrypt · AES-256-CCM (CryptoHives-AES-NI) | 1KB          |     2,804.4 ns |     1.34 ns |     1.19 ns |   9,497 B |         - |
| Decrypt · AES-256-CCM (CryptoHives-Scalar) | 1KB          |     7,927.0 ns |    29.37 ns |    27.47 ns |  10,466 B |         - |
| Decrypt · AES-256-CCM (BouncyCastle)       | 1KB          |    11,575.7 ns |    20.57 ns |    18.24 ns |     306 B |    3912 B |
|                                            |              |                |             |             |           |           |
| Encrypt · AES-256-CCM (CryptoHives-AES-NI) | 1KB          |     2,726.4 ns |     0.49 ns |     0.46 ns |   9,445 B |         - |
| Encrypt · AES-256-CCM (CryptoHives-Scalar) | 1KB          |     7,858.5 ns |    22.36 ns |    19.82 ns |  10,414 B |         - |
| Encrypt · AES-256-CCM (BouncyCastle)       | 1KB          |    11,478.7 ns |    34.36 ns |    32.14 ns |     383 B |    2904 B |
|                                            |              |                |             |             |           |           |
| Decrypt · AES-256-CCM (CryptoHives-AES-NI) | 8KB          |    21,189.4 ns |     6.60 ns |     6.18 ns |   9,504 B |         - |
| Decrypt · AES-256-CCM (CryptoHives-Scalar) | 8KB          |    61,270.7 ns |    75.16 ns |    66.63 ns |  10,473 B |         - |
| Decrypt · AES-256-CCM (BouncyCastle)       | 8KB          |    87,293.9 ns |   170.88 ns |   142.70 ns |     306 B |   11080 B |
|                                            |              |                |             |             |           |           |
| Encrypt · AES-256-CCM (CryptoHives-AES-NI) | 8KB          |    21,109.7 ns |     5.76 ns |     5.10 ns |   9,452 B |         - |
| Encrypt · AES-256-CCM (CryptoHives-Scalar) | 8KB          |    60,687.9 ns |    81.02 ns |    75.78 ns |  10,415 B |         - |
| Encrypt · AES-256-CCM (BouncyCastle)       | 8KB          |    86,592.9 ns |   192.37 ns |   170.53 ns |     383 B |    2904 B |
|                                            |              |                |             |             |           |           |
| Decrypt · AES-256-CCM (CryptoHives-AES-NI) | 128KB        |   336,229.2 ns |   117.66 ns |   104.30 ns |   9,504 B |         - |
| Decrypt · AES-256-CCM (CryptoHives-Scalar) | 128KB        |   970,328.9 ns | 1,695.68 ns | 1,586.14 ns |  10,473 B |         - |
| Decrypt · AES-256-CCM (BouncyCastle)       | 128KB        | 1,413,334.6 ns | 3,264.50 ns | 3,053.61 ns |     306 B |  133974 B |
|                                            |              |                |             |             |           |           |
| Encrypt · AES-256-CCM (CryptoHives-AES-NI) | 128KB        |   335,648.8 ns |   167.58 ns |   156.75 ns |   9,443 B |         - |
| Encrypt · AES-256-CCM (CryptoHives-Scalar) | 128KB        |   970,692.5 ns | 1,714.40 ns | 1,519.77 ns |  10,418 B |         - |
| Encrypt · AES-256-CCM (BouncyCastle)       | 128KB        | 1,370,468.9 ns | 2,343.48 ns | 2,192.09 ns |     383 B |    2904 B |