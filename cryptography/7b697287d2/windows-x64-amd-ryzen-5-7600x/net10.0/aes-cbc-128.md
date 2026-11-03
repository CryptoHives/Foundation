| Description                                | TestDataSize | Mean          | Error        | StdDev       | Code Size | Allocated |
|------------------------------------------- |------------- |--------------:|-------------:|-------------:|----------:|----------:|
| Decrypt · AES-128-CBC (CryptoHives-AES-NI) | 128B         |      54.59 ns |     0.069 ns |     0.061 ns |     255 B |         - |
| Decrypt · AES-128-CBC (OS)                 | 128B         |     272.67 ns |     0.903 ns |     0.800 ns |  11,795 B |     128 B |
| Decrypt · AES-128-CBC (CryptoHives-Scalar) | 128B         |     446.06 ns |     0.856 ns |     0.800 ns |     255 B |         - |
| Decrypt · AES-128-CBC (BouncyCastle)       | 128B         |     778.33 ns |     0.945 ns |     0.738 ns |   2,909 B |     832 B |
|                                            |              |               |              |              |           |           |
| Encrypt · AES-128-CBC (CryptoHives-AES-NI) | 128B         |      98.00 ns |     0.101 ns |     0.094 ns |     255 B |         - |
| Encrypt · AES-128-CBC (OS)                 | 128B         |     317.74 ns |     0.884 ns |     0.827 ns |  10,011 B |     128 B |
| Encrypt · AES-128-CBC (CryptoHives-Scalar) | 128B         |     477.67 ns |     1.692 ns |     1.500 ns |     255 B |         - |
| Encrypt · AES-128-CBC (BouncyCastle)       | 128B         |     698.14 ns |     1.759 ns |     1.559 ns |   2,900 B |     832 B |
|                                            |              |               |              |              |           |           |
| Decrypt · AES-128-CBC (CryptoHives-AES-NI) | 1KB          |     244.30 ns |     0.764 ns |     0.715 ns |     255 B |         - |
| Decrypt · AES-128-CBC (OS)                 | 1KB          |     340.26 ns |     4.050 ns |     3.789 ns |  11,797 B |     128 B |
| Decrypt · AES-128-CBC (CryptoHives-Scalar) | 1KB          |   3,108.84 ns |     8.332 ns |     7.793 ns |     255 B |         - |
| Decrypt · AES-128-CBC (BouncyCastle)       | 1KB          |   4,463.74 ns |    36.422 ns |    30.414 ns |   2,911 B |     832 B |
|                                            |              |               |              |              |           |           |
| Encrypt · AES-128-CBC (CryptoHives-AES-NI) | 1KB          |     606.51 ns |     0.467 ns |     0.390 ns |     255 B |         - |
| Encrypt · AES-128-CBC (OS)                 | 1KB          |     809.98 ns |     1.139 ns |     1.065 ns |  10,010 B |     128 B |
| Encrypt · AES-128-CBC (CryptoHives-Scalar) | 1KB          |   3,330.03 ns |     4.529 ns |     3.782 ns |     255 B |         - |
| Encrypt · AES-128-CBC (BouncyCastle)       | 1KB          |   4,263.21 ns |    23.918 ns |    22.373 ns |   2,904 B |     832 B |
|                                            |              |               |              |              |           |           |
| Decrypt · AES-128-CBC (OS)                 | 8KB          |     850.83 ns |     6.873 ns |     6.093 ns |  11,804 B |     128 B |
| Decrypt · AES-128-CBC (CryptoHives-AES-NI) | 8KB          |   1,793.39 ns |    11.945 ns |    11.173 ns |     255 B |         - |
| Decrypt · AES-128-CBC (CryptoHives-Scalar) | 8KB          |  24,817.33 ns |   283.389 ns |   265.082 ns |     255 B |         - |
| Decrypt · AES-128-CBC (BouncyCastle)       | 8KB          |  33,907.87 ns |   405.634 ns |   379.431 ns |   2,911 B |     832 B |
|                                            |              |               |              |              |           |           |
| Encrypt · AES-128-CBC (CryptoHives-AES-NI) | 8KB          |   4,671.56 ns |     2.856 ns |     2.671 ns |     255 B |         - |
| Encrypt · AES-128-CBC (OS)                 | 8KB          |   4,756.50 ns |     2.321 ns |     1.938 ns |  10,870 B |     128 B |
| Encrypt · AES-128-CBC (CryptoHives-Scalar) | 8KB          |  26,133.75 ns |    42.717 ns |    37.868 ns |     255 B |         - |
| Encrypt · AES-128-CBC (BouncyCastle)       | 8KB          |  32,682.46 ns |   115.683 ns |   108.210 ns |   2,911 B |     832 B |
|                                            |              |               |              |              |           |           |
| Decrypt · AES-128-CBC (OS)                 | 128KB        |   9,731.70 ns |    88.175 ns |    82.479 ns |  12,855 B |     128 B |
| Decrypt · AES-128-CBC (CryptoHives-AES-NI) | 128KB        |  28,485.01 ns |   194.403 ns |   181.845 ns |     255 B |         - |
| Decrypt · AES-128-CBC (CryptoHives-Scalar) | 128KB        | 396,525.30 ns | 5,325.903 ns | 4,981.853 ns |     255 B |         - |
| Decrypt · AES-128-CBC (BouncyCastle)       | 128KB        | 536,546.00 ns | 6,791.085 ns | 6,352.385 ns |   2,911 B |     832 B |
|                                            |              |               |              |              |           |           |
| Encrypt · AES-128-CBC (OS)                 | 128KB        |  72,939.93 ns |    44.834 ns |    39.744 ns |  11,269 B |     128 B |
| Encrypt · AES-128-CBC (CryptoHives-AES-NI) | 128KB        |  74,658.66 ns |    43.760 ns |    38.792 ns |     255 B |         - |
| Encrypt · AES-128-CBC (CryptoHives-Scalar) | 128KB        | 421,457.49 ns |   970.623 ns |   810.514 ns |     255 B |         - |
| Encrypt · AES-128-CBC (BouncyCastle)       | 128KB        | 519,707.33 ns | 2,357.727 ns | 2,205.419 ns |   2,911 B |     832 B |