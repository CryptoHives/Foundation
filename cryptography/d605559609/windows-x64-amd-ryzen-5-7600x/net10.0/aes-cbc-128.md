| Description                                | TestDataSize | Mean          | Error        | StdDev       | Allocated |
|------------------------------------------- |------------- |--------------:|-------------:|-------------:|----------:|
| Decrypt · AES-128-CBC (CryptoHives-AES-NI) | 128B         |      49.91 ns |     0.254 ns |     0.225 ns |         - |
| Decrypt · AES-128-CBC (OS)                 | 128B         |     260.97 ns |     1.394 ns |     1.088 ns |     128 B |
| Decrypt · AES-128-CBC (CryptoHives-Scalar) | 128B         |     431.83 ns |     1.972 ns |     1.748 ns |         - |
| Decrypt · AES-128-CBC (BouncyCastle)       | 128B         |     701.02 ns |     6.758 ns |     5.276 ns |     832 B |
|                                            |              |               |              |              |           |
| Encrypt · AES-128-CBC (CryptoHives-AES-NI) | 128B         |      85.25 ns |     0.173 ns |     0.153 ns |         - |
| Encrypt · AES-128-CBC (OS)                 | 128B         |     289.00 ns |     1.799 ns |     1.595 ns |     128 B |
| Encrypt · AES-128-CBC (CryptoHives-Scalar) | 128B         |     433.01 ns |     8.137 ns |     6.795 ns |         - |
| Encrypt · AES-128-CBC (BouncyCastle)       | 128B         |     635.63 ns |     5.708 ns |     5.060 ns |     832 B |
|                                            |              |               |              |              |           |
| Decrypt · AES-128-CBC (CryptoHives-AES-NI) | 1KB          |     219.60 ns |     0.907 ns |     0.804 ns |         - |
| Decrypt · AES-128-CBC (OS)                 | 1KB          |     308.74 ns |     2.217 ns |     1.965 ns |     128 B |
| Decrypt · AES-128-CBC (CryptoHives-Scalar) | 1KB          |   3,026.56 ns |    36.967 ns |    30.869 ns |         - |
| Decrypt · AES-128-CBC (BouncyCastle)       | 1KB          |   3,976.64 ns |    33.221 ns |    31.075 ns |     832 B |
|                                            |              |               |              |              |           |
| Encrypt · AES-128-CBC (CryptoHives-AES-NI) | 1KB          |     520.00 ns |     0.666 ns |     0.590 ns |         - |
| Encrypt · AES-128-CBC (OS)                 | 1KB          |     705.40 ns |     1.651 ns |     1.544 ns |     128 B |
| Encrypt · AES-128-CBC (CryptoHives-Scalar) | 1KB          |   2,997.54 ns |    15.517 ns |    13.755 ns |         - |
| Encrypt · AES-128-CBC (BouncyCastle)       | 1KB          |   3,819.57 ns |    17.687 ns |    13.809 ns |     832 B |
|                                            |              |               |              |              |           |
| Decrypt · AES-128-CBC (OS)                 | 8KB          |     758.31 ns |     4.299 ns |     3.356 ns |     128 B |
| Decrypt · AES-128-CBC (CryptoHives-AES-NI) | 8KB          |   1,599.65 ns |     5.430 ns |     5.079 ns |         - |
| Decrypt · AES-128-CBC (CryptoHives-Scalar) | 8KB          |  23,758.80 ns |   185.690 ns |   155.060 ns |         - |
| Decrypt · AES-128-CBC (BouncyCastle)       | 8KB          |  29,979.67 ns |   123.018 ns |   115.071 ns |     832 B |
|                                            |              |               |              |              |           |
| Encrypt · AES-128-CBC (CryptoHives-AES-NI) | 8KB          |   4,054.34 ns |    66.879 ns |    62.559 ns |         - |
| Encrypt · AES-128-CBC (OS)                 | 8KB          |   4,098.27 ns |     7.495 ns |     7.010 ns |     128 B |
| Encrypt · AES-128-CBC (CryptoHives-Scalar) | 8KB          |  23,651.42 ns |   349.682 ns |   273.009 ns |         - |
| Encrypt · AES-128-CBC (BouncyCastle)       | 8KB          |  29,296.99 ns |    98.492 ns |    87.310 ns |     832 B |
|                                            |              |               |              |              |           |
| Decrypt · AES-128-CBC (OS)                 | 128KB        |   8,510.87 ns |    34.558 ns |    32.325 ns |     128 B |
| Decrypt · AES-128-CBC (CryptoHives-AES-NI) | 128KB        |  25,137.51 ns |   119.828 ns |   112.087 ns |         - |
| Decrypt · AES-128-CBC (CryptoHives-Scalar) | 128KB        | 400,805.97 ns | 3,152.667 ns | 2,949.007 ns |         - |
| Decrypt · AES-128-CBC (BouncyCastle)       | 128KB        | 476,567.41 ns | 4,208.951 ns | 3,514.665 ns |     832 B |
|                                            |              |               |              |              |           |
| Encrypt · AES-128-CBC (OS)                 | 128KB        |  63,421.78 ns |   861.193 ns |   805.560 ns |     128 B |
| Encrypt · AES-128-CBC (CryptoHives-AES-NI) | 128KB        |  64,371.60 ns |   623.232 ns |   582.972 ns |         - |
| Encrypt · AES-128-CBC (CryptoHives-Scalar) | 128KB        | 375,365.52 ns | 1,966.437 ns | 1,839.407 ns |         - |
| Encrypt · AES-128-CBC (BouncyCastle)       | 128KB        | 464,718.36 ns | 1,967.900 ns | 1,643.285 ns |     832 B |