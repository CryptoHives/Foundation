| Description                                | TestDataSize | Mean          | Error        | StdDev       | Median        | Allocated |
|------------------------------------------- |------------- |--------------:|-------------:|-------------:|--------------:|----------:|
| Decrypt · AES-128-CBC (CryptoHives-AES-NI) | 128B         |      50.73 ns |     0.128 ns |     0.113 ns |      50.73 ns |         - |
| Decrypt · AES-128-CBC (OS)                 | 128B         |     260.66 ns |     2.111 ns |     1.762 ns |     260.24 ns |     128 B |
| Decrypt · AES-128-CBC (CryptoHives-Scalar) | 128B         |     467.87 ns |     3.053 ns |     2.706 ns |     467.10 ns |         - |
| Decrypt · AES-128-CBC (BouncyCastle)       | 128B         |     704.89 ns |     2.508 ns |     2.095 ns |     704.15 ns |     832 B |
|                                            |              |               |              |              |               |           |
| Encrypt · AES-128-CBC (CryptoHives-AES-NI) | 128B         |      85.35 ns |     0.315 ns |     0.263 ns |      85.27 ns |         - |
| Encrypt · AES-128-CBC (OS)                 | 128B         |     283.06 ns |     1.003 ns |     0.838 ns |     283.05 ns |     128 B |
| Encrypt · AES-128-CBC (BouncyCastle)       | 128B         |     640.09 ns |     1.840 ns |     1.631 ns |     640.19 ns |     832 B |
| Encrypt · AES-128-CBC (CryptoHives-Scalar) | 128B         |     647.38 ns |     6.202 ns |     5.498 ns |     646.89 ns |         - |
|                                            |              |               |              |              |               |           |
| Decrypt · AES-128-CBC (CryptoHives-AES-NI) | 1KB          |     222.07 ns |     0.502 ns |     0.445 ns |     222.01 ns |         - |
| Decrypt · AES-128-CBC (OS)                 | 1KB          |     308.43 ns |     2.603 ns |     2.174 ns |     308.87 ns |     128 B |
| Decrypt · AES-128-CBC (CryptoHives-Scalar) | 1KB          |   3,269.91 ns |    22.578 ns |    18.854 ns |   3,270.80 ns |         - |
| Decrypt · AES-128-CBC (BouncyCastle)       | 1KB          |   4,001.77 ns |    30.196 ns |    25.215 ns |   3,993.95 ns |     832 B |
|                                            |              |               |              |              |               |           |
| Encrypt · AES-128-CBC (CryptoHives-AES-NI) | 1KB          |     519.86 ns |     1.641 ns |     1.455 ns |     519.48 ns |         - |
| Encrypt · AES-128-CBC (OS)                 | 1KB          |     716.95 ns |     2.435 ns |     2.033 ns |     716.69 ns |     128 B |
| Encrypt · AES-128-CBC (BouncyCastle)       | 1KB          |   3,864.18 ns |    36.415 ns |    30.408 ns |   3,860.73 ns |     832 B |
| Encrypt · AES-128-CBC (CryptoHives-Scalar) | 1KB          |   4,594.91 ns |     6.876 ns |     5.368 ns |   4,597.12 ns |         - |
|                                            |              |               |              |              |               |           |
| Decrypt · AES-128-CBC (OS)                 | 8KB          |     761.90 ns |     9.964 ns |     8.320 ns |     756.92 ns |     128 B |
| Decrypt · AES-128-CBC (CryptoHives-AES-NI) | 8KB          |   1,611.70 ns |     4.691 ns |     3.917 ns |   1,610.26 ns |         - |
| Decrypt · AES-128-CBC (CryptoHives-Scalar) | 8KB          |  25,785.46 ns |   295.362 ns |   230.599 ns |  25,722.25 ns |         - |
| Decrypt · AES-128-CBC (BouncyCastle)       | 8KB          |  30,132.06 ns |   114.728 ns |    95.803 ns |  30,172.55 ns |     832 B |
|                                            |              |               |              |              |               |           |
| Encrypt · AES-128-CBC (CryptoHives-AES-NI) | 8KB          |   4,143.96 ns |    79.963 ns |    85.560 ns |   4,173.96 ns |         - |
| Encrypt · AES-128-CBC (OS)                 | 8KB          |   4,273.00 ns |    85.358 ns |   215.711 ns |   4,149.14 ns |     128 B |
| Encrypt · AES-128-CBC (BouncyCastle)       | 8KB          |  29,350.33 ns |   120.138 ns |   106.499 ns |  29,299.26 ns |     832 B |
| Encrypt · AES-128-CBC (CryptoHives-Scalar) | 8KB          |  34,390.39 ns |    54.258 ns |    48.098 ns |  34,401.90 ns |         - |
|                                            |              |               |              |              |               |           |
| Decrypt · AES-128-CBC (OS)                 | 128KB        |   8,601.85 ns |    45.273 ns |    40.133 ns |   8,585.64 ns |     128 B |
| Decrypt · AES-128-CBC (CryptoHives-AES-NI) | 128KB        |  25,431.99 ns |    90.042 ns |    79.820 ns |  25,419.28 ns |         - |
| Decrypt · AES-128-CBC (CryptoHives-Scalar) | 128KB        | 415,837.92 ns | 4,092.633 ns | 3,628.013 ns | 416,653.76 ns |         - |
| Decrypt · AES-128-CBC (BouncyCastle)       | 128KB        | 480,265.83 ns | 5,773.931 ns | 5,118.439 ns | 479,070.95 ns |     832 B |
|                                            |              |               |              |              |               |           |
| Encrypt · AES-128-CBC (OS)                 | 128KB        |  63,299.33 ns |   723.416 ns |   676.684 ns |  63,099.18 ns |     128 B |
| Encrypt · AES-128-CBC (CryptoHives-AES-NI) | 128KB        |  64,230.85 ns |   756.360 ns |   956.553 ns |  63,888.88 ns |         - |
| Encrypt · AES-128-CBC (BouncyCastle)       | 128KB        | 466,527.83 ns | 1,525.837 ns | 1,352.615 ns | 466,035.25 ns |     832 B |
| Encrypt · AES-128-CBC (CryptoHives-Scalar) | 128KB        | 555,548.42 ns | 8,980.265 ns | 7,960.771 ns | 551,970.75 ns |         - |