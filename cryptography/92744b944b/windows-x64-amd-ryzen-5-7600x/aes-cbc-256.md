| Description                                | TestDataSize | Mean          | Error        | StdDev       | Allocated |
|------------------------------------------- |------------- |--------------:|-------------:|-------------:|----------:|
| Decrypt · AES-256-CBC (CryptoHives-AES-NI) | 128B         |      56.25 ns |     0.338 ns |     0.316 ns |         - |
| Decrypt · AES-256-CBC (OS)                 | 128B         |     248.27 ns |     1.848 ns |     1.729 ns |     128 B |
| Decrypt · AES-256-CBC (CryptoHives-Scalar) | 128B         |     559.26 ns |     3.515 ns |     3.288 ns |         - |
| Decrypt · AES-256-CBC (BouncyCastle)       | 128B         |     881.16 ns |    13.362 ns |    12.499 ns |    1024 B |
|                                            |              |               |              |              |           |
| Encrypt · AES-256-CBC (CryptoHives-AES-NI) | 128B         |     200.24 ns |     0.843 ns |     0.747 ns |         - |
| Encrypt · AES-256-CBC (OS)                 | 128B         |     307.94 ns |     1.811 ns |     1.694 ns |     128 B |
| Encrypt · AES-256-CBC (CryptoHives-Scalar) | 128B         |     563.04 ns |     4.012 ns |     3.753 ns |         - |
| Encrypt · AES-256-CBC (BouncyCastle)       | 128B         |     783.77 ns |     6.225 ns |     5.823 ns |    1024 B |
|                                            |              |               |              |              |           |
| Decrypt · AES-256-CBC (CryptoHives-AES-NI) | 1KB          |     293.29 ns |     0.583 ns |     0.545 ns |         - |
| Decrypt · AES-256-CBC (OS)                 | 1KB          |     326.17 ns |     1.114 ns |     0.988 ns |     128 B |
| Decrypt · AES-256-CBC (CryptoHives-Scalar) | 1KB          |   3,938.90 ns |    14.716 ns |    13.766 ns |         - |
| Decrypt · AES-256-CBC (BouncyCastle)       | 1KB          |   4,774.60 ns |    12.701 ns |    10.606 ns |    1024 B |
|                                            |              |               |              |              |           |
| Encrypt · AES-256-CBC (OS)                 | 1KB          |     894.49 ns |     3.834 ns |     3.586 ns |     128 B |
| Encrypt · AES-256-CBC (CryptoHives-AES-NI) | 1KB          |   1,385.28 ns |     5.744 ns |     5.373 ns |         - |
| Encrypt · AES-256-CBC (CryptoHives-Scalar) | 1KB          |   3,986.95 ns |    24.802 ns |    23.200 ns |         - |
| Encrypt · AES-256-CBC (BouncyCastle)       | 1KB          |   4,714.87 ns |    23.306 ns |    21.800 ns |    1024 B |
|                                            |              |               |              |              |           |
| Decrypt · AES-256-CBC (OS)                 | 8KB          |     937.29 ns |     2.520 ns |     2.234 ns |     128 B |
| Decrypt · AES-256-CBC (CryptoHives-AES-NI) | 8KB          |   2,183.52 ns |     5.979 ns |     5.593 ns |         - |
| Decrypt · AES-256-CBC (CryptoHives-Scalar) | 8KB          |  30,976.15 ns |   165.309 ns |   154.630 ns |         - |
| Decrypt · AES-256-CBC (BouncyCastle)       | 8KB          |  35,917.27 ns |   128.397 ns |   120.103 ns |    1024 B |
|                                            |              |               |              |              |           |
| Encrypt · AES-256-CBC (OS)                 | 8KB          |   5,841.92 ns |    24.041 ns |    21.311 ns |     128 B |
| Encrypt · AES-256-CBC (CryptoHives-AES-NI) | 8KB          |  10,781.37 ns |    59.217 ns |    52.495 ns |         - |
| Encrypt · AES-256-CBC (CryptoHives-Scalar) | 8KB          |  31,377.28 ns |   225.441 ns |   199.848 ns |         - |
| Encrypt · AES-256-CBC (BouncyCastle)       | 8KB          |  36,311.11 ns |   216.880 ns |   202.870 ns |    1024 B |
|                                            |              |               |              |              |           |
| Decrypt · AES-256-CBC (OS)                 | 128KB        |  11,218.70 ns |    23.120 ns |    21.627 ns |     128 B |
| Decrypt · AES-256-CBC (CryptoHives-AES-NI) | 128KB        |  34,456.57 ns |    52.498 ns |    40.987 ns |         - |
| Decrypt · AES-256-CBC (CryptoHives-Scalar) | 128KB        | 499,034.39 ns | 2,373.491 ns | 2,220.165 ns |         - |
| Decrypt · AES-256-CBC (BouncyCastle)       | 128KB        | 568,959.83 ns | 2,913.285 ns | 2,725.089 ns |    1024 B |
|                                            |              |               |              |              |           |
| Encrypt · AES-256-CBC (OS)                 | 128KB        |  90,573.99 ns |   364.180 ns |   322.836 ns |     128 B |
| Encrypt · AES-256-CBC (CryptoHives-AES-NI) | 128KB        | 171,486.16 ns |   332.831 ns |   277.929 ns |         - |
| Encrypt · AES-256-CBC (CryptoHives-Scalar) | 128KB        | 505,301.05 ns | 2,744.895 ns | 2,567.576 ns |         - |
| Encrypt · AES-256-CBC (BouncyCastle)       | 128KB        | 575,718.61 ns | 4,352.420 ns | 4,071.257 ns |    1024 B |