| Description                                | TestDataSize | Mean          | Error        | StdDev       | Allocated |
|------------------------------------------- |------------- |--------------:|-------------:|-------------:|----------:|
| Decrypt · AES-128-CBC (CryptoHives-AES-NI) | 128B         |      50.75 ns |     0.665 ns |     0.622 ns |         - |
| Decrypt · AES-128-CBC (OS)                 | 128B         |     259.28 ns |     3.436 ns |     3.046 ns |     128 B |
| Decrypt · AES-128-CBC (CryptoHives-Scalar) | 128B         |     459.91 ns |     3.365 ns |     2.810 ns |         - |
| Decrypt · AES-128-CBC (BouncyCastle)       | 128B         |     724.96 ns |    11.037 ns |     9.784 ns |     832 B |
|                                            |              |               |              |              |           |
| Encrypt · AES-128-CBC (CryptoHives-AES-NI) | 128B         |      86.03 ns |     0.341 ns |     0.319 ns |         - |
| Encrypt · AES-128-CBC (OS)                 | 128B         |     281.92 ns |     2.968 ns |     2.631 ns |     128 B |
| Encrypt · AES-128-CBC (CryptoHives-Scalar) | 128B         |     463.42 ns |     9.173 ns |     8.581 ns |         - |
| Encrypt · AES-128-CBC (BouncyCastle)       | 128B         |     644.05 ns |     7.155 ns |     6.693 ns |     832 B |
|                                            |              |               |              |              |           |
| Decrypt · AES-128-CBC (CryptoHives-AES-NI) | 1KB          |     221.59 ns |     2.074 ns |     1.940 ns |         - |
| Decrypt · AES-128-CBC (OS)                 | 1KB          |     326.26 ns |     3.053 ns |     2.549 ns |     128 B |
| Decrypt · AES-128-CBC (CryptoHives-Scalar) | 1KB          |   3,244.04 ns |    38.375 ns |    35.896 ns |         - |
| Decrypt · AES-128-CBC (BouncyCastle)       | 1KB          |   4,025.68 ns |    48.740 ns |    45.592 ns |     832 B |
|                                            |              |               |              |              |           |
| Encrypt · AES-128-CBC (CryptoHives-AES-NI) | 1KB          |     530.67 ns |    10.477 ns |    12.867 ns |         - |
| Encrypt · AES-128-CBC (OS)                 | 1KB          |     710.89 ns |     9.922 ns |     9.281 ns |     128 B |
| Encrypt · AES-128-CBC (CryptoHives-Scalar) | 1KB          |   3,693.67 ns |    42.842 ns |    40.074 ns |         - |
| Encrypt · AES-128-CBC (BouncyCastle)       | 1KB          |   3,815.45 ns |    36.916 ns |    34.531 ns |     832 B |
|                                            |              |               |              |              |           |
| Decrypt · AES-128-CBC (OS)                 | 8KB          |     801.01 ns |    15.972 ns |    28.391 ns |     128 B |
| Decrypt · AES-128-CBC (CryptoHives-AES-NI) | 8KB          |   1,635.22 ns |    25.371 ns |    23.732 ns |         - |
| Decrypt · AES-128-CBC (CryptoHives-Scalar) | 8KB          |  25,519.65 ns |   280.294 ns |   248.473 ns |         - |
| Decrypt · AES-128-CBC (BouncyCastle)       | 8KB          |  30,968.59 ns |   511.694 ns |   453.603 ns |     832 B |
|                                            |              |               |              |              |           |
| Encrypt · AES-128-CBC (OS)                 | 8KB          |   4,096.32 ns |     6.893 ns |     5.756 ns |     128 B |
| Encrypt · AES-128-CBC (CryptoHives-AES-NI) | 8KB          |   4,248.89 ns |    71.238 ns |    66.636 ns |         - |
| Encrypt · AES-128-CBC (CryptoHives-Scalar) | 8KB          |  25,190.52 ns |   263.730 ns |   233.790 ns |         - |
| Encrypt · AES-128-CBC (BouncyCastle)       | 8KB          |  29,326.17 ns |   484.022 ns |   452.754 ns |     832 B |
|                                            |              |               |              |              |           |
| Decrypt · AES-128-CBC (OS)                 | 128KB        |   8,966.72 ns |    33.686 ns |    29.861 ns |     128 B |
| Decrypt · AES-128-CBC (CryptoHives-AES-NI) | 128KB        |  26,638.21 ns |   202.247 ns |   189.182 ns |         - |
| Decrypt · AES-128-CBC (CryptoHives-Scalar) | 128KB        | 426,122.10 ns | 2,724.730 ns | 2,415.402 ns |         - |
| Decrypt · AES-128-CBC (BouncyCastle)       | 128KB        | 502,036.98 ns | 2,695.768 ns | 2,521.623 ns |     832 B |
|                                            |              |               |              |              |           |
| Encrypt · AES-128-CBC (OS)                 | 128KB        |  65,444.28 ns | 1,278.862 ns | 1,522.395 ns |     128 B |
| Encrypt · AES-128-CBC (CryptoHives-AES-NI) | 128KB        |  66,361.36 ns |   675.774 ns |   632.120 ns |         - |
| Encrypt · AES-128-CBC (BouncyCastle)       | 128KB        | 464,628.84 ns | 4,527.173 ns | 3,780.395 ns |     832 B |
| Encrypt · AES-128-CBC (CryptoHives-Scalar) | 128KB        | 467,512.10 ns | 5,175.913 ns | 4,041.012 ns |         - |