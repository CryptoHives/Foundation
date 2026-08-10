| Description                                | TestDataSize | Mean          | Error        | StdDev       | Allocated |
|------------------------------------------- |------------- |--------------:|-------------:|-------------:|----------:|
| Decrypt · AES-128-CBC (CryptoHives-AES-NI) | 128B         |      50.16 ns |     0.718 ns |     0.671 ns |         - |
| Decrypt · AES-128-CBC (OS)                 | 128B         |     249.56 ns |     3.510 ns |     3.283 ns |     128 B |
| Decrypt · AES-128-CBC (CryptoHives-Scalar) | 128B         |     469.73 ns |     5.830 ns |     5.454 ns |         - |
| Decrypt · AES-128-CBC (BouncyCastle)       | 128B         |     725.88 ns |     9.203 ns |     8.609 ns |     832 B |
|                                            |              |               |              |              |           |
| Encrypt · AES-128-CBC (CryptoHives-AES-NI) | 128B         |      86.64 ns |     1.751 ns |     2.017 ns |         - |
| Encrypt · AES-128-CBC (OS)                 | 128B         |     281.66 ns |     4.991 ns |     4.668 ns |     128 B |
| Encrypt · AES-128-CBC (CryptoHives-Scalar) | 128B         |     459.83 ns |     5.316 ns |     4.973 ns |         - |
| Encrypt · AES-128-CBC (BouncyCastle)       | 128B         |     646.99 ns |     7.914 ns |     7.403 ns |     832 B |
|                                            |              |               |              |              |           |
| Decrypt · AES-128-CBC (CryptoHives-AES-NI) | 1KB          |     217.53 ns |     1.427 ns |     1.265 ns |         - |
| Decrypt · AES-128-CBC (OS)                 | 1KB          |     303.88 ns |     4.073 ns |     3.810 ns |     128 B |
| Decrypt · AES-128-CBC (CryptoHives-Scalar) | 1KB          |   3,168.46 ns |    29.783 ns |    26.401 ns |         - |
| Decrypt · AES-128-CBC (BouncyCastle)       | 1KB          |   3,955.75 ns |    40.802 ns |    36.170 ns |     832 B |
|                                            |              |               |              |              |           |
| Encrypt · AES-128-CBC (CryptoHives-AES-NI) | 1KB          |     532.67 ns |    10.263 ns |    14.387 ns |         - |
| Encrypt · AES-128-CBC (OS)                 | 1KB          |     703.88 ns |     7.908 ns |     7.398 ns |     128 B |
| Encrypt · AES-128-CBC (CryptoHives-Scalar) | 1KB          |   3,208.20 ns |    40.400 ns |    37.790 ns |         - |
| Encrypt · AES-128-CBC (BouncyCastle)       | 1KB          |   3,822.48 ns |    66.645 ns |    62.340 ns |     832 B |
|                                            |              |               |              |              |           |
| Decrypt · AES-128-CBC (OS)                 | 8KB          |     753.30 ns |    10.588 ns |     9.904 ns |     128 B |
| Decrypt · AES-128-CBC (CryptoHives-AES-NI) | 8KB          |   1,560.05 ns |    11.481 ns |    10.177 ns |         - |
| Decrypt · AES-128-CBC (CryptoHives-Scalar) | 8KB          |  25,363.91 ns |   365.674 ns |   342.052 ns |         - |
| Decrypt · AES-128-CBC (BouncyCastle)       | 8KB          |  29,945.36 ns |   422.365 ns |   395.081 ns |     832 B |
|                                            |              |               |              |              |           |
| Encrypt · AES-128-CBC (OS)                 | 8KB          |   4,127.97 ns |    61.739 ns |    57.750 ns |     128 B |
| Encrypt · AES-128-CBC (CryptoHives-AES-NI) | 8KB          |   4,234.68 ns |    63.668 ns |    59.555 ns |         - |
| Encrypt · AES-128-CBC (CryptoHives-Scalar) | 8KB          |  25,312.45 ns |   458.816 ns |   429.177 ns |         - |
| Encrypt · AES-128-CBC (BouncyCastle)       | 8KB          |  28,870.87 ns |   272.045 ns |   241.161 ns |     832 B |
|                                            |              |               |              |              |           |
| Decrypt · AES-128-CBC (OS)                 | 128KB        |   8,409.82 ns |    70.984 ns |    62.925 ns |     128 B |
| Decrypt · AES-128-CBC (CryptoHives-AES-NI) | 128KB        |  25,016.60 ns |   315.165 ns |   294.806 ns |         - |
| Decrypt · AES-128-CBC (CryptoHives-Scalar) | 128KB        | 399,283.49 ns | 4,627.329 ns | 4,102.007 ns |         - |
| Decrypt · AES-128-CBC (BouncyCastle)       | 128KB        | 472,666.37 ns | 6,324.282 ns | 5,915.737 ns |     832 B |
|                                            |              |               |              |              |           |
| Encrypt · AES-128-CBC (OS)                 | 128KB        |  66,134.92 ns |   997.893 ns |   933.430 ns |     128 B |
| Encrypt · AES-128-CBC (CryptoHives-AES-NI) | 128KB        |  66,812.52 ns |   648.045 ns |   574.475 ns |         - |
| Encrypt · AES-128-CBC (CryptoHives-Scalar) | 128KB        | 402,543.47 ns | 5,683.072 ns | 5,315.949 ns |         - |
| Encrypt · AES-128-CBC (BouncyCastle)       | 128KB        | 463,905.14 ns | 6,620.714 ns | 6,193.020 ns |     832 B |