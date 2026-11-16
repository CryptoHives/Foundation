| Description                                | TestDataSize | Mean          | Error        | StdDev       | Code Size | Allocated |
|------------------------------------------- |------------- |--------------:|-------------:|-------------:|----------:|----------:|
| Decrypt · AES-128-CBC (CryptoHives-AES-NI) | 128B         |      53.10 ns |     0.125 ns |     0.105 ns |     255 B |         - |
| Decrypt · AES-128-CBC (OS)                 | 128B         |     286.24 ns |     1.732 ns |     1.620 ns |  12,057 B |     128 B |
| Decrypt · AES-128-CBC (CryptoHives-Scalar) | 128B         |     454.41 ns |     1.529 ns |     1.194 ns |     255 B |         - |
| Decrypt · AES-128-CBC (BouncyCastle)       | 128B         |     785.72 ns |     3.053 ns |     2.383 ns |   2,909 B |     832 B |
|                                            |              |               |              |              |           |           |
| Encrypt · AES-128-CBC (CryptoHives-AES-NI) | 128B         |      98.52 ns |     0.253 ns |     0.211 ns |     255 B |         - |
| Encrypt · AES-128-CBC (OS)                 | 128B         |     325.44 ns |     1.095 ns |     0.971 ns |  10,003 B |     128 B |
| Encrypt · AES-128-CBC (CryptoHives-Scalar) | 128B         |     481.69 ns |     3.531 ns |     2.949 ns |     255 B |         - |
| Encrypt · AES-128-CBC (BouncyCastle)       | 128B         |     706.60 ns |     2.172 ns |     1.814 ns |   2,898 B |     832 B |
|                                            |              |               |              |              |           |           |
| Decrypt · AES-128-CBC (CryptoHives-AES-NI) | 1KB          |     245.66 ns |     0.670 ns |     0.627 ns |     255 B |         - |
| Decrypt · AES-128-CBC (OS)                 | 1KB          |     346.89 ns |     1.158 ns |     1.083 ns |  11,797 B |     128 B |
| Decrypt · AES-128-CBC (CryptoHives-Scalar) | 1KB          |   3,149.78 ns |    17.243 ns |    16.129 ns |     255 B |         - |
| Decrypt · AES-128-CBC (BouncyCastle)       | 1KB          |   4,465.48 ns |    25.444 ns |    22.556 ns |   2,913 B |     832 B |
|                                            |              |               |              |              |           |           |
| Encrypt · AES-128-CBC (CryptoHives-AES-NI) | 1KB          |     608.87 ns |     0.524 ns |     0.490 ns |     255 B |         - |
| Encrypt · AES-128-CBC (OS)                 | 1KB          |     811.38 ns |     2.139 ns |     2.000 ns |  10,252 B |     128 B |
| Encrypt · AES-128-CBC (CryptoHives-Scalar) | 1KB          |   3,395.39 ns |    16.199 ns |    14.360 ns |     255 B |         - |
| Encrypt · AES-128-CBC (BouncyCastle)       | 1KB          |   4,303.71 ns |    26.903 ns |    23.849 ns |   2,902 B |     832 B |
|                                            |              |               |              |              |           |           |
| Decrypt · AES-128-CBC (OS)                 | 8KB          |     864.26 ns |    15.297 ns |    15.709 ns |  12,051 B |     128 B |
| Decrypt · AES-128-CBC (CryptoHives-AES-NI) | 8KB          |   1,805.69 ns |     2.879 ns |     2.552 ns |     255 B |         - |
| Decrypt · AES-128-CBC (CryptoHives-Scalar) | 8KB          |  24,620.29 ns |    65.387 ns |    57.964 ns |     255 B |         - |
| Decrypt · AES-128-CBC (BouncyCastle)       | 8KB          |  33,731.43 ns |    66.727 ns |    59.152 ns |   2,911 B |     832 B |
|                                            |              |               |              |              |           |           |
| Encrypt · AES-128-CBC (CryptoHives-AES-NI) | 8KB          |   4,680.51 ns |     5.134 ns |     4.287 ns |     255 B |         - |
| Encrypt · AES-128-CBC (OS)                 | 8KB          |   4,766.80 ns |     4.823 ns |     4.275 ns |  10,865 B |     128 B |
| Encrypt · AES-128-CBC (CryptoHives-Scalar) | 8KB          |  26,347.87 ns |   102.569 ns |    95.943 ns |     255 B |         - |
| Encrypt · AES-128-CBC (BouncyCastle)       | 8KB          |  32,976.77 ns |   214.174 ns |   189.859 ns |   2,909 B |     832 B |
|                                            |              |               |              |              |           |           |
| Decrypt · AES-128-CBC (OS)                 | 128KB        |   9,753.86 ns |    17.375 ns |    16.252 ns |  12,855 B |     128 B |
| Decrypt · AES-128-CBC (CryptoHives-AES-NI) | 128KB        |  28,485.85 ns |    41.107 ns |    34.327 ns |     255 B |         - |
| Decrypt · AES-128-CBC (CryptoHives-Scalar) | 128KB        | 392,393.77 ns | 1,116.269 ns |   989.543 ns |     255 B |         - |
| Decrypt · AES-128-CBC (BouncyCastle)       | 128KB        | 536,329.79 ns | 2,197.046 ns | 1,947.624 ns |   2,911 B |     832 B |
|                                            |              |               |              |              |           |           |
| Encrypt · AES-128-CBC (OS)                 | 128KB        |  73,106.24 ns |    48.623 ns |    45.482 ns |  11,269 B |     128 B |
| Encrypt · AES-128-CBC (CryptoHives-AES-NI) | 128KB        |  74,725.27 ns |    26.886 ns |    23.834 ns |     255 B |         - |
| Encrypt · AES-128-CBC (CryptoHives-Scalar) | 128KB        | 419,938.90 ns | 1,622.085 ns | 1,437.936 ns |     255 B |         - |
| Encrypt · AES-128-CBC (BouncyCastle)       | 128KB        | 525,811.43 ns | 4,497.267 ns | 4,416.917 ns |   2,911 B |     832 B |