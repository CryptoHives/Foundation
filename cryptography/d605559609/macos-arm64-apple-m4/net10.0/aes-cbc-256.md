| Description                                 | TestDataSize | Mean          | Error        | StdDev       | Allocated |
|-------------------------------------------- |------------- |--------------:|-------------:|-------------:|----------:|
| Decrypt · AES-256-CBC (CryptoHives-ARM-AES) | 128B         |      25.95 ns |     0.051 ns |     0.040 ns |         - |
| Decrypt · AES-256-CBC (OS)                  | 128B         |     228.02 ns |     0.703 ns |     0.624 ns |      72 B |
| Decrypt · AES-256-CBC (CryptoHives-Scalar)  | 128B         |     512.50 ns |     1.090 ns |     1.019 ns |         - |
| Decrypt · AES-256-CBC (BouncyCastle)        | 128B         |     787.37 ns |     1.267 ns |     1.123 ns |    1024 B |
|                                             |              |               |              |              |           |
| Encrypt · AES-256-CBC (CryptoHives-ARM-AES) | 128B         |      51.59 ns |     0.061 ns |     0.057 ns |         - |
| Encrypt · AES-256-CBC (OS)                  | 128B         |     252.48 ns |     1.122 ns |     0.937 ns |      72 B |
| Encrypt · AES-256-CBC (CryptoHives-Scalar)  | 128B         |     558.70 ns |     1.298 ns |     1.084 ns |         - |
| Encrypt · AES-256-CBC (BouncyCastle)        | 128B         |     726.60 ns |     3.968 ns |     3.314 ns |    1024 B |
|                                             |              |               |              |              |           |
| Decrypt · AES-256-CBC (CryptoHives-ARM-AES) | 1KB          |     111.98 ns |     0.405 ns |     0.359 ns |         - |
| Decrypt · AES-256-CBC (OS)                  | 1KB          |     289.50 ns |     0.999 ns |     0.780 ns |      72 B |
| Decrypt · AES-256-CBC (CryptoHives-Scalar)  | 1KB          |   3,616.99 ns |     6.599 ns |     5.510 ns |         - |
| Decrypt · AES-256-CBC (BouncyCastle)        | 1KB          |   4,419.12 ns |     9.201 ns |     7.683 ns |    1024 B |
|                                             |              |               |              |              |           |
| Encrypt · AES-256-CBC (CryptoHives-ARM-AES) | 1KB          |     533.58 ns |     3.431 ns |     3.041 ns |         - |
| Encrypt · AES-256-CBC (OS)                  | 1KB          |     768.86 ns |     2.924 ns |     2.735 ns |      72 B |
| Encrypt · AES-256-CBC (CryptoHives-Scalar)  | 1KB          |   4,020.79 ns |     9.582 ns |     8.494 ns |         - |
| Encrypt · AES-256-CBC (BouncyCastle)        | 1KB          |   4,271.93 ns |     9.720 ns |     8.117 ns |    1024 B |
|                                             |              |               |              |              |           |
| Decrypt · AES-256-CBC (OS)                  | 8KB          |     759.77 ns |     3.062 ns |     2.864 ns |      72 B |
| Decrypt · AES-256-CBC (CryptoHives-ARM-AES) | 8KB          |     792.44 ns |     1.095 ns |     0.914 ns |         - |
| Decrypt · AES-256-CBC (CryptoHives-Scalar)  | 8KB          |  28,363.91 ns |    37.639 ns |    35.207 ns |         - |
| Decrypt · AES-256-CBC (BouncyCastle)        | 8KB          |  33,336.62 ns |   122.293 ns |   108.410 ns |    1024 B |
|                                             |              |               |              |              |           |
| Encrypt · AES-256-CBC (CryptoHives-ARM-AES) | 8KB          |   4,524.74 ns |    40.502 ns |    37.885 ns |         - |
| Encrypt · AES-256-CBC (OS)                  | 8KB          |   4,631.62 ns |    30.154 ns |    26.731 ns |      72 B |
| Encrypt · AES-256-CBC (CryptoHives-Scalar)  | 8KB          |  31,697.26 ns |    60.065 ns |    53.246 ns |         - |
| Encrypt · AES-256-CBC (BouncyCastle)        | 8KB          |  32,654.20 ns |    55.233 ns |    48.963 ns |    1024 B |
|                                             |              |               |              |              |           |
| Decrypt · AES-256-CBC (OS)                  | 128KB        |   8,846.82 ns |    14.316 ns |    13.391 ns |      72 B |
| Decrypt · AES-256-CBC (CryptoHives-ARM-AES) | 128KB        |  12,480.86 ns |    81.069 ns |    67.696 ns |         - |
| Decrypt · AES-256-CBC (CryptoHives-Scalar)  | 128KB        | 462,461.80 ns | 8,898.580 ns | 8,323.738 ns |         - |
| Decrypt · AES-256-CBC (BouncyCastle)        | 128KB        | 531,706.85 ns | 1,845.875 ns | 1,636.320 ns |    1024 B |
|                                             |              |               |              |              |           |
| Encrypt · AES-256-CBC (OS)                  | 128KB        |  71,948.08 ns |   307.002 ns |   256.361 ns |      72 B |
| Encrypt · AES-256-CBC (CryptoHives-ARM-AES) | 128KB        |  73,239.83 ns |   646.856 ns |   605.069 ns |         - |
| Encrypt · AES-256-CBC (CryptoHives-Scalar)  | 128KB        | 505,004.12 ns |   209.135 ns |   185.392 ns |         - |
| Encrypt · AES-256-CBC (BouncyCastle)        | 128KB        | 519,842.18 ns |   203.695 ns |   170.095 ns |    1024 B |