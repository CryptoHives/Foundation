| Description                                | TestDataSize | Mean          | Error        | StdDev       | Code Size | Allocated |
|------------------------------------------- |------------- |--------------:|-------------:|-------------:|----------:|----------:|
| Decrypt · AES-128-CBC (CryptoHives-AES-NI) | 128B         |      51.75 ns |     0.139 ns |     0.130 ns |     255 B |         - |
| Decrypt · AES-128-CBC (OS)                 | 128B         |      59.26 ns |     0.668 ns |     0.592 ns |  17,185 B |         - |
| Decrypt · AES-128-CBC (CryptoHives-Scalar) | 128B         |     450.41 ns |     0.956 ns |     0.894 ns |     255 B |         - |
| Decrypt · AES-128-CBC (BouncyCastle)       | 128B         |     753.27 ns |     3.762 ns |     3.335 ns |   7,734 B |     832 B |
|                                            |              |               |              |              |           |           |
| Encrypt · AES-128-CBC (CryptoHives-AES-NI) | 128B         |     101.03 ns |     0.415 ns |     0.346 ns |     255 B |         - |
| Encrypt · AES-128-CBC (OS)                 | 128B         |     114.34 ns |     0.623 ns |     0.583 ns |  15,805 B |         - |
| Encrypt · AES-128-CBC (CryptoHives-Scalar) | 128B         |     495.14 ns |     7.799 ns |     6.913 ns |     255 B |         - |
| Encrypt · AES-128-CBC (BouncyCastle)       | 128B         |     688.42 ns |    10.111 ns |     9.458 ns |  13,878 B |     832 B |
|                                            |              |               |              |              |           |           |
| Decrypt · AES-128-CBC (OS)                 | 1KB          |     122.20 ns |     1.169 ns |     1.093 ns |  17,766 B |         - |
| Decrypt · AES-128-CBC (CryptoHives-AES-NI) | 1KB          |     244.14 ns |     0.544 ns |     0.509 ns |     255 B |         - |
| Decrypt · AES-128-CBC (CryptoHives-Scalar) | 1KB          |   3,280.88 ns |    64.848 ns |    63.690 ns |     255 B |         - |
| Decrypt · AES-128-CBC (BouncyCastle)       | 1KB          |   4,288.76 ns |    38.283 ns |    33.937 ns |  13,878 B |     832 B |
|                                            |              |               |              |              |           |           |
| Encrypt · AES-128-CBC (CryptoHives-AES-NI) | 1KB          |     610.09 ns |     1.094 ns |     0.970 ns |     255 B |         - |
| Encrypt · AES-128-CBC (OS)                 | 1KB          |     611.21 ns |     1.297 ns |     1.213 ns |  15,988 B |         - |
| Encrypt · AES-128-CBC (CryptoHives-Scalar) | 1KB          |   3,464.41 ns |    45.795 ns |    38.241 ns |     255 B |         - |
| Encrypt · AES-128-CBC (BouncyCastle)       | 1KB          |   4,084.15 ns |    56.432 ns |    52.787 ns |   7,734 B |     832 B |
|                                            |              |               |              |              |           |           |
| Decrypt · AES-128-CBC (OS)                 | 8KB          |     617.90 ns |     3.565 ns |     3.335 ns |  17,157 B |         - |
| Decrypt · AES-128-CBC (CryptoHives-AES-NI) | 8KB          |   1,807.46 ns |     9.896 ns |     9.257 ns |     255 B |         - |
| Decrypt · AES-128-CBC (CryptoHives-Scalar) | 8KB          |  25,203.77 ns |   307.990 ns |   273.025 ns |     255 B |         - |
| Decrypt · AES-128-CBC (BouncyCastle)       | 8KB          |  32,451.34 ns |   374.978 ns |   350.755 ns |   7,734 B |     832 B |
|                                            |              |               |              |              |           |           |
| Encrypt · AES-128-CBC (OS)                 | 8KB          |   4,528.10 ns |     2.790 ns |     2.473 ns |   9,692 B |         - |
| Encrypt · AES-128-CBC (CryptoHives-AES-NI) | 8KB          |   4,675.71 ns |     4.445 ns |     4.158 ns |     255 B |         - |
| Encrypt · AES-128-CBC (CryptoHives-Scalar) | 8KB          |  29,027.24 ns |   166.663 ns |   147.743 ns |     255 B |         - |
| Encrypt · AES-128-CBC (BouncyCastle)       | 8KB          |  30,919.01 ns |   134.208 ns |   104.781 ns |  13,693 B |     832 B |
|                                            |              |               |              |              |           |           |
| Decrypt · AES-128-CBC (OS)                 | 128KB        |   9,465.98 ns |    56.971 ns |    53.291 ns |  17,766 B |         - |
| Decrypt · AES-128-CBC (CryptoHives-AES-NI) | 128KB        |  28,699.26 ns |   151.093 ns |   141.332 ns |     255 B |         - |
| Decrypt · AES-128-CBC (CryptoHives-Scalar) | 128KB        | 402,823.51 ns | 4,292.355 ns | 4,015.072 ns |     255 B |         - |
| Decrypt · AES-128-CBC (BouncyCastle)       | 128KB        | 516,240.41 ns | 5,687.831 ns | 5,320.401 ns |  13,878 B |     832 B |
|                                            |              |               |              |              |           |           |
| Encrypt · AES-128-CBC (OS)                 | 128KB        |  72,692.23 ns |    34.697 ns |    28.974 ns |  16,250 B |         - |
| Encrypt · AES-128-CBC (CryptoHives-AES-NI) | 128KB        |  74,498.98 ns |    79.878 ns |    74.718 ns |     255 B |         - |
| Encrypt · AES-128-CBC (CryptoHives-Scalar) | 128KB        | 428,498.31 ns |   809.957 ns |   676.351 ns |     255 B |         - |
| Encrypt · AES-128-CBC (BouncyCastle)       | 128KB        | 487,758.36 ns | 2,322.921 ns | 1,939.744 ns |  13,697 B |     832 B |