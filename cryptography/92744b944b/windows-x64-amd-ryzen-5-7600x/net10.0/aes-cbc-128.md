| Description                                | TestDataSize | Mean          | Error        | StdDev       | Allocated |
|------------------------------------------- |------------- |--------------:|-------------:|-------------:|----------:|
| Decrypt · AES-128-CBC (CryptoHives-AES-NI) | 128B         |      43.17 ns |     0.181 ns |     0.161 ns |         - |
| Decrypt · AES-128-CBC (OS)                 | 128B         |     243.43 ns |     1.785 ns |     1.582 ns |     128 B |
| Decrypt · AES-128-CBC (CryptoHives-Scalar) | 128B         |     440.90 ns |     1.557 ns |     1.456 ns |         - |
| Decrypt · AES-128-CBC (BouncyCastle)       | 128B         |     687.82 ns |     3.306 ns |     3.093 ns |     832 B |
|                                            |              |               |              |              |           |
| Encrypt · AES-128-CBC (CryptoHives-AES-NI) | 128B         |     177.58 ns |     3.294 ns |     3.081 ns |         - |
| Encrypt · AES-128-CBC (OS)                 | 128B         |     290.90 ns |     5.064 ns |     5.629 ns |     128 B |
| Encrypt · AES-128-CBC (CryptoHives-Scalar) | 128B         |     452.48 ns |     5.147 ns |     4.563 ns |         - |
| Encrypt · AES-128-CBC (BouncyCastle)       | 128B         |     628.09 ns |     5.175 ns |     4.587 ns |     832 B |
|                                            |              |               |              |              |           |
| Decrypt · AES-128-CBC (CryptoHives-AES-NI) | 1KB          |     228.41 ns |     0.542 ns |     0.507 ns |         - |
| Decrypt · AES-128-CBC (OS)                 | 1KB          |     301.76 ns |     2.199 ns |     2.057 ns |     128 B |
| Decrypt · AES-128-CBC (CryptoHives-Scalar) | 1KB          |   3,101.18 ns |    21.408 ns |    20.025 ns |         - |
| Decrypt · AES-128-CBC (BouncyCastle)       | 1KB          |   3,873.68 ns |    33.008 ns |    30.876 ns |     832 B |
|                                            |              |               |              |              |           |
| Encrypt · AES-128-CBC (OS)                 | 1KB          |     702.95 ns |     2.720 ns |     2.545 ns |     128 B |
| Encrypt · AES-128-CBC (CryptoHives-AES-NI) | 1KB          |   1,176.11 ns |     3.232 ns |     2.865 ns |         - |
| Encrypt · AES-128-CBC (CryptoHives-Scalar) | 1KB          |   3,138.37 ns |    11.263 ns |     9.984 ns |         - |
| Encrypt · AES-128-CBC (BouncyCastle)       | 1KB          |   3,709.17 ns |    23.366 ns |    21.856 ns |     832 B |
|                                            |              |               |              |              |           |
| Decrypt · AES-128-CBC (OS)                 | 8KB          |     732.49 ns |     4.807 ns |     4.261 ns |     128 B |
| Decrypt · AES-128-CBC (CryptoHives-AES-NI) | 8KB          |   1,555.19 ns |     8.042 ns |     7.522 ns |         - |
| Decrypt · AES-128-CBC (CryptoHives-Scalar) | 8KB          |  24,417.64 ns |   155.710 ns |   145.651 ns |         - |
| Decrypt · AES-128-CBC (BouncyCastle)       | 8KB          |  29,020.13 ns |   182.137 ns |   161.460 ns |     832 B |
|                                            |              |               |              |              |           |
| Encrypt · AES-128-CBC (OS)                 | 8KB          |   4,248.04 ns |    30.043 ns |    26.632 ns |     128 B |
| Encrypt · AES-128-CBC (CryptoHives-AES-NI) | 8KB          |   9,449.34 ns |    55.769 ns |    49.438 ns |         - |
| Encrypt · AES-128-CBC (CryptoHives-Scalar) | 8KB          |  24,657.81 ns |    73.621 ns |    65.263 ns |         - |
| Encrypt · AES-128-CBC (BouncyCastle)       | 8KB          |  28,512.77 ns |   209.950 ns |   186.115 ns |     832 B |
|                                            |              |               |              |              |           |
| Decrypt · AES-128-CBC (OS)                 | 128KB        |   8,261.76 ns |    28.680 ns |    26.827 ns |     128 B |
| Decrypt · AES-128-CBC (CryptoHives-AES-NI) | 128KB        |  24,533.06 ns |   125.368 ns |   117.269 ns |         - |
| Decrypt · AES-128-CBC (CryptoHives-Scalar) | 128KB        | 390,174.43 ns | 2,100.277 ns | 1,964.601 ns |         - |
| Decrypt · AES-128-CBC (BouncyCastle)       | 128KB        | 459,847.82 ns | 2,134.402 ns | 1,892.092 ns |     832 B |
|                                            |              |               |              |              |           |
| Encrypt · AES-128-CBC (OS)                 | 128KB        |  65,167.59 ns |   443.417 ns |   370.273 ns |     128 B |
| Encrypt · AES-128-CBC (CryptoHives-AES-NI) | 128KB        | 147,034.93 ns |   227.566 ns |   177.669 ns |         - |
| Encrypt · AES-128-CBC (CryptoHives-Scalar) | 128KB        | 395,207.30 ns | 1,834.482 ns | 1,626.220 ns |         - |
| Encrypt · AES-128-CBC (BouncyCastle)       | 128KB        | 450,755.05 ns | 2,709.060 ns | 2,534.056 ns |     832 B |