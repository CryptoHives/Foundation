| Description                                | TestDataSize | Mean          | Error        | StdDev       | Allocated |
|------------------------------------------- |------------- |--------------:|-------------:|-------------:|----------:|
| Decrypt · AES-128-CBC (CryptoHives-AES-NI) | 128B         |      49.57 ns |     0.394 ns |     0.329 ns |         - |
| Decrypt · AES-128-CBC (OS)                 | 128B         |     251.58 ns |     3.171 ns |     2.966 ns |     128 B |
| Decrypt · AES-128-CBC (CryptoHives-Scalar) | 128B         |     451.75 ns |     3.134 ns |     2.617 ns |         - |
| Decrypt · AES-128-CBC (BouncyCastle)       | 128B         |     690.71 ns |     6.132 ns |     5.736 ns |     832 B |
|                                            |              |               |              |              |           |
| Encrypt · AES-128-CBC (CryptoHives-AES-NI) | 128B         |      86.95 ns |     1.682 ns |     1.573 ns |         - |
| Encrypt · AES-128-CBC (OS)                 | 128B         |     282.18 ns |     3.309 ns |     3.095 ns |     128 B |
| Encrypt · AES-128-CBC (CryptoHives-Scalar) | 128B         |     459.64 ns |     4.017 ns |     3.757 ns |         - |
| Encrypt · AES-128-CBC (BouncyCastle)       | 128B         |     626.96 ns |     4.997 ns |     4.674 ns |     832 B |
|                                            |              |               |              |              |           |
| Decrypt · AES-128-CBC (CryptoHives-AES-NI) | 1KB          |     216.65 ns |     1.522 ns |     1.423 ns |         - |
| Decrypt · AES-128-CBC (OS)                 | 1KB          |     304.90 ns |     2.196 ns |     2.054 ns |     128 B |
| Decrypt · AES-128-CBC (CryptoHives-Scalar) | 1KB          |   3,152.41 ns |    21.199 ns |    19.830 ns |         - |
| Decrypt · AES-128-CBC (BouncyCastle)       | 1KB          |   3,951.35 ns |    46.283 ns |    43.293 ns |     832 B |
|                                            |              |               |              |              |           |
| Encrypt · AES-128-CBC (CryptoHives-AES-NI) | 1KB          |     519.83 ns |     1.454 ns |     1.135 ns |         - |
| Encrypt · AES-128-CBC (OS)                 | 1KB          |     698.76 ns |     3.804 ns |     3.558 ns |     128 B |
| Encrypt · AES-128-CBC (CryptoHives-Scalar) | 1KB          |   3,205.51 ns |    25.123 ns |    23.500 ns |         - |
| Encrypt · AES-128-CBC (BouncyCastle)       | 1KB          |   3,820.35 ns |    41.633 ns |    36.907 ns |     832 B |
|                                            |              |               |              |              |           |
| Decrypt · AES-128-CBC (OS)                 | 8KB          |     754.48 ns |     8.405 ns |     7.862 ns |     128 B |
| Decrypt · AES-128-CBC (CryptoHives-AES-NI) | 8KB          |   1,582.30 ns |    13.276 ns |    12.419 ns |         - |
| Decrypt · AES-128-CBC (CryptoHives-Scalar) | 8KB          |  24,849.08 ns |   217.967 ns |   203.886 ns |         - |
| Decrypt · AES-128-CBC (BouncyCastle)       | 8KB          |  29,635.58 ns |   270.678 ns |   253.192 ns |     832 B |
|                                            |              |               |              |              |           |
| Encrypt · AES-128-CBC (OS)                 | 8KB          |   4,114.42 ns |    23.377 ns |    21.867 ns |     128 B |
| Encrypt · AES-128-CBC (CryptoHives-AES-NI) | 8KB          |   4,139.31 ns |    73.385 ns |    68.644 ns |         - |
| Encrypt · AES-128-CBC (CryptoHives-Scalar) | 8KB          |  25,186.55 ns |   277.031 ns |   216.288 ns |         - |
| Encrypt · AES-128-CBC (BouncyCastle)       | 8KB          |  29,237.92 ns |   205.660 ns |   192.374 ns |     832 B |
|                                            |              |               |              |              |           |
| Decrypt · AES-128-CBC (OS)                 | 128KB        |   8,430.93 ns |    70.290 ns |    65.749 ns |     128 B |
| Decrypt · AES-128-CBC (CryptoHives-AES-NI) | 128KB        |  25,082.34 ns |   173.458 ns |   162.253 ns |         - |
| Decrypt · AES-128-CBC (CryptoHives-Scalar) | 128KB        | 398,115.30 ns | 2,886.445 ns | 2,699.983 ns |         - |
| Decrypt · AES-128-CBC (BouncyCastle)       | 128KB        | 470,733.17 ns | 4,170.943 ns | 3,901.503 ns |     832 B |
|                                            |              |               |              |              |           |
| Encrypt · AES-128-CBC (CryptoHives-AES-NI) | 128KB        |  65,221.04 ns |   744.493 ns |   696.400 ns |         - |
| Encrypt · AES-128-CBC (OS)                 | 128KB        |  65,277.10 ns |   604.712 ns |   565.648 ns |     128 B |
| Encrypt · AES-128-CBC (CryptoHives-Scalar) | 128KB        | 402,739.84 ns | 2,199.602 ns | 1,949.890 ns |         - |
| Encrypt · AES-128-CBC (BouncyCastle)       | 128KB        | 461,571.88 ns | 3,253.636 ns | 3,043.453 ns |     832 B |