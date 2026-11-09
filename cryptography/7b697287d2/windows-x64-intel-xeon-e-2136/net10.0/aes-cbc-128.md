| Description                                | TestDataSize | Mean          | Error         | StdDev        | Median        | Code Size | Allocated |
|------------------------------------------- |------------- |--------------:|--------------:|--------------:|--------------:|----------:|----------:|
| Decrypt · AES-128-CBC (CryptoHives-AES-NI) | 128B         |      71.19 ns |      0.827 ns |      1.287 ns |      70.68 ns |     255 B |         - |
| Decrypt · AES-128-CBC (OS)                 | 128B         |     443.21 ns |      2.278 ns |      2.131 ns |     442.51 ns |  12,048 B |     128 B |
| Decrypt · AES-128-CBC (CryptoHives-Scalar) | 128B         |     555.80 ns |      1.429 ns |      1.193 ns |     555.76 ns |     255 B |         - |
| Decrypt · AES-128-CBC (BouncyCastle)       | 128B         |   1,225.90 ns |     15.933 ns |     14.903 ns |   1,218.35 ns |   2,929 B |     832 B |
|                                            |              |               |               |               |               |           |           |
| Encrypt · AES-128-CBC (CryptoHives-AES-NI) | 128B         |     118.77 ns |      0.369 ns |      0.345 ns |     118.71 ns |     255 B |         - |
| Encrypt · AES-128-CBC (OS)                 | 128B         |     486.62 ns |      2.937 ns |      2.604 ns |     486.24 ns |   9,960 B |     128 B |
| Encrypt · AES-128-CBC (CryptoHives-Scalar) | 128B         |     606.11 ns |      3.109 ns |      2.756 ns |     605.63 ns |     255 B |         - |
| Encrypt · AES-128-CBC (BouncyCastle)       | 128B         |   1,086.87 ns |      6.907 ns |      6.460 ns |   1,085.74 ns |   2,918 B |     832 B |
|                                            |              |               |               |               |               |           |           |
| Decrypt · AES-128-CBC (CryptoHives-AES-NI) | 1KB          |     321.02 ns |      1.237 ns |      0.966 ns |     320.98 ns |     255 B |         - |
| Decrypt · AES-128-CBC (OS)                 | 1KB          |     587.03 ns |      3.701 ns |      3.281 ns |     587.60 ns |  12,073 B |     128 B |
| Decrypt · AES-128-CBC (CryptoHives-Scalar) | 1KB          |   4,118.02 ns |     79.955 ns |    129.113 ns |   4,098.22 ns |     255 B |         - |
| Decrypt · AES-128-CBC (BouncyCastle)       | 1KB          |   7,358.82 ns |     52.420 ns |     43.773 ns |   7,371.14 ns |   2,931 B |     832 B |
|                                            |              |               |               |               |               |           |           |
| Encrypt · AES-128-CBC (CryptoHives-AES-NI) | 1KB          |     687.99 ns |      4.581 ns |      4.285 ns |     687.01 ns |     255 B |         - |
| Encrypt · AES-128-CBC (OS)                 | 1KB          |   1,036.81 ns |     13.183 ns |     12.947 ns |   1,036.22 ns |   9,536 B |     128 B |
| Encrypt · AES-128-CBC (CryptoHives-Scalar) | 1KB          |   4,299.41 ns |     63.152 ns |     59.072 ns |   4,264.30 ns |     255 B |         - |
| Encrypt · AES-128-CBC (BouncyCastle)       | 1KB          |  11,036.97 ns |    794.934 ns |  2,343.882 ns |  12,219.00 ns |   2,924 B |     832 B |
|                                            |              |               |               |               |               |           |           |
| Decrypt · AES-128-CBC (OS)                 | 8KB          |   1,686.16 ns |     18.719 ns |     17.510 ns |   1,683.58 ns |  11,831 B |     128 B |
| Decrypt · AES-128-CBC (CryptoHives-AES-NI) | 8KB          |   2,088.24 ns |      8.515 ns |      7.548 ns |   2,087.42 ns |     255 B |         - |
| Decrypt · AES-128-CBC (CryptoHives-Scalar) | 8KB          |  31,028.84 ns |    127.222 ns |    112.779 ns |  30,992.00 ns |     255 B |         - |
| Decrypt · AES-128-CBC (BouncyCastle)       | 8KB          |  58,332.00 ns |    669.832 ns |    593.789 ns |  58,222.37 ns |   2,935 B |     832 B |
|                                            |              |               |               |               |               |           |           |
| Encrypt · AES-128-CBC (CryptoHives-AES-NI) | 8KB          |   5,218.28 ns |     33.610 ns |     31.439 ns |   5,214.30 ns |     255 B |         - |
| Encrypt · AES-128-CBC (OS)                 | 8KB          |   5,372.04 ns |     28.559 ns |     26.714 ns |   5,368.13 ns |   9,558 B |     128 B |
| Encrypt · AES-128-CBC (CryptoHives-Scalar) | 8KB          |  32,947.28 ns |    133.833 ns |    125.187 ns |  32,900.38 ns |     255 B |         - |
| Encrypt · AES-128-CBC (BouncyCastle)       | 8KB          |  47,824.33 ns |    301.852 ns |    252.060 ns |  47,805.30 ns |   2,935 B |     832 B |
|                                            |              |               |               |               |               |           |           |
| Decrypt · AES-128-CBC (OS)                 | 128KB        |  20,483.54 ns |    233.177 ns |    218.114 ns |  20,539.17 ns |  12,882 B |     128 B |
| Decrypt · AES-128-CBC (CryptoHives-AES-NI) | 128KB        |  33,224.18 ns |    341.753 ns |    319.676 ns |  33,182.90 ns |     255 B |         - |
| Decrypt · AES-128-CBC (CryptoHives-Scalar) | 128KB        | 510,772.63 ns |  4,670.426 ns |  4,368.720 ns | 510,689.01 ns |     255 B |         - |
| Decrypt · AES-128-CBC (BouncyCastle)       | 128KB        | 879,505.41 ns | 11,605.700 ns | 10,288.151 ns | 879,193.46 ns |   2,935 B |     832 B |
|                                            |              |               |               |               |               |           |           |
| Encrypt · AES-128-CBC (CryptoHives-AES-NI) | 128KB        |  82,655.39 ns |    446.469 ns |    417.628 ns |  82,608.76 ns |     255 B |         - |
| Encrypt · AES-128-CBC (OS)                 | 128KB        |  82,691.71 ns |  1,623.641 ns |  1,667.360 ns |  83,490.32 ns |  11,326 B |     128 B |
| Encrypt · AES-128-CBC (CryptoHives-Scalar) | 128KB        | 529,618.05 ns |  5,812.121 ns |  5,436.662 ns | 529,509.28 ns |     255 B |         - |
| Encrypt · AES-128-CBC (BouncyCastle)       | 128KB        | 801,198.40 ns | 13,612.064 ns | 16,204.196 ns | 796,232.42 ns |   2,935 B |     832 B |