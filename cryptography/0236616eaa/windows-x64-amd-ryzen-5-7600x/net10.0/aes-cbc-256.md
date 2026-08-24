| Description                                | TestDataSize | Mean          | Error        | StdDev       | Allocated |
|------------------------------------------- |------------- |--------------:|-------------:|-------------:|----------:|
| Decrypt · AES-256-CBC (CryptoHives-AES-NI) | 128B         |      63.65 ns |     0.134 ns |     0.112 ns |         - |
| Decrypt · AES-256-CBC (OS)                 | 128B         |     279.22 ns |     5.524 ns |     8.601 ns |     128 B |
| Decrypt · AES-256-CBC (CryptoHives-Scalar) | 128B         |     594.09 ns |     2.091 ns |     1.853 ns |         - |
| Decrypt · AES-256-CBC (BouncyCastle)       | 128B         |     894.06 ns |     2.314 ns |     1.932 ns |    1024 B |
|                                            |              |               |              |              |           |
| Encrypt · AES-256-CBC (CryptoHives-AES-NI) | 128B         |     111.65 ns |     0.086 ns |     0.080 ns |         - |
| Encrypt · AES-256-CBC (OS)                 | 128B         |     320.45 ns |     1.169 ns |     1.093 ns |     128 B |
| Encrypt · AES-256-CBC (BouncyCastle)       | 128B         |     802.04 ns |     2.936 ns |     2.603 ns |    1024 B |
| Encrypt · AES-256-CBC (CryptoHives-Scalar) | 128B         |     818.31 ns |     2.856 ns |     2.672 ns |         - |
|                                            |              |               |              |              |           |
| Decrypt · AES-256-CBC (CryptoHives-AES-NI) | 1KB          |     306.67 ns |     0.809 ns |     0.717 ns |         - |
| Decrypt · AES-256-CBC (OS)                 | 1KB          |     345.56 ns |     1.994 ns |     1.865 ns |     128 B |
| Decrypt · AES-256-CBC (CryptoHives-Scalar) | 1KB          |   4,185.32 ns |    17.782 ns |    16.633 ns |         - |
| Decrypt · AES-256-CBC (BouncyCastle)       | 1KB          |   4,933.87 ns |    20.530 ns |    16.029 ns |    1024 B |
|                                            |              |               |              |              |           |
| Encrypt · AES-256-CBC (CryptoHives-AES-NI) | 1KB          |     728.87 ns |    14.513 ns |    13.576 ns |         - |
| Encrypt · AES-256-CBC (OS)                 | 1KB          |     915.01 ns |    10.117 ns |     8.969 ns |     128 B |
| Encrypt · AES-256-CBC (BouncyCastle)       | 1KB          |   4,938.45 ns |    96.727 ns |    80.771 ns |    1024 B |
| Encrypt · AES-256-CBC (CryptoHives-Scalar) | 1KB          |   5,807.43 ns |    13.182 ns |    11.686 ns |         - |
|                                            |              |               |              |              |           |
| Decrypt · AES-256-CBC (OS)                 | 8KB          |     965.27 ns |     3.980 ns |     3.723 ns |     128 B |
| Decrypt · AES-256-CBC (CryptoHives-AES-NI) | 8KB          |   2,257.89 ns |     3.466 ns |     2.894 ns |         - |
| Decrypt · AES-256-CBC (CryptoHives-Scalar) | 8KB          |  32,924.04 ns |   110.616 ns |   103.470 ns |         - |
| Decrypt · AES-256-CBC (BouncyCastle)       | 8KB          |  37,036.81 ns |   100.060 ns |    88.701 ns |    1024 B |
|                                            |              |               |              |              |           |
| Encrypt · AES-256-CBC (OS)                 | 8KB          |   5,606.65 ns |    19.988 ns |    16.691 ns |     128 B |
| Encrypt · AES-256-CBC (CryptoHives-AES-NI) | 8KB          |   5,827.43 ns |    18.841 ns |    17.623 ns |         - |
| Encrypt · AES-256-CBC (BouncyCastle)       | 8KB          |  37,545.92 ns |   135.964 ns |   120.528 ns |    1024 B |
| Encrypt · AES-256-CBC (CryptoHives-Scalar) | 8KB          |  45,773.02 ns |   107.093 ns |    94.935 ns |         - |
|                                            |              |               |              |              |           |
| Decrypt · AES-256-CBC (OS)                 | 128KB        |  11,906.45 ns |    39.595 ns |    37.037 ns |     128 B |
| Decrypt · AES-256-CBC (CryptoHives-AES-NI) | 128KB        |  35,476.22 ns |    62.628 ns |    55.518 ns |         - |
| Decrypt · AES-256-CBC (CryptoHives-Scalar) | 128KB        | 535,192.12 ns | 1,535.004 ns | 1,281.798 ns |         - |
| Decrypt · AES-256-CBC (BouncyCastle)       | 128KB        | 589,169.01 ns | 1,368.409 ns | 1,068.364 ns |    1024 B |
|                                            |              |               |              |              |           |
| Encrypt · AES-256-CBC (OS)                 | 128KB        |  91,150.12 ns |   901.232 ns |   798.918 ns |     128 B |
| Encrypt · AES-256-CBC (CryptoHives-AES-NI) | 128KB        |  94,688.85 ns | 1,554.156 ns | 1,453.758 ns |         - |
| Encrypt · AES-256-CBC (BouncyCastle)       | 128KB        | 593,160.44 ns |   999.176 ns |   885.744 ns |    1024 B |
| Encrypt · AES-256-CBC (CryptoHives-Scalar) | 128KB        | 731,832.43 ns | 1,647.208 ns | 1,540.799 ns |         - |