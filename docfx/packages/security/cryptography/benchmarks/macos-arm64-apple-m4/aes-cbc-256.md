| Description                                 | TestDataSize | Mean          | Error        | StdDev       | Allocated |
|-------------------------------------------- |------------- |--------------:|-------------:|-------------:|----------:|
| Decrypt · AES-256-CBC (CryptoHives-ARM-AES) | 128B         |      24.89 ns |     0.022 ns |     0.018 ns |         - |
| Decrypt · AES-256-CBC (OS)                  | 128B         |     226.71 ns |     1.738 ns |     1.452 ns |      72 B |
| Decrypt · AES-256-CBC (CryptoHives-Scalar)  | 128B         |     519.76 ns |     0.421 ns |     0.328 ns |         - |
| Decrypt · AES-256-CBC (BouncyCastle)        | 128B         |     796.15 ns |     2.271 ns |     1.773 ns |    1024 B |
|                                             |              |               |              |              |           |
| Encrypt · AES-256-CBC (CryptoHives-ARM-AES) | 128B         |     152.05 ns |     0.659 ns |     0.617 ns |         - |
| Encrypt · AES-256-CBC (OS)                  | 128B         |     254.59 ns |     0.770 ns |     0.683 ns |      72 B |
| Encrypt · AES-256-CBC (CryptoHives-Scalar)  | 128B         |     569.41 ns |     0.174 ns |     0.162 ns |         - |
| Encrypt · AES-256-CBC (BouncyCastle)        | 128B         |     739.33 ns |     0.335 ns |     0.261 ns |    1024 B |
|                                             |              |               |              |              |           |
| Decrypt · AES-256-CBC (CryptoHives-ARM-AES) | 1KB          |     103.67 ns |     1.002 ns |     0.888 ns |         - |
| Decrypt · AES-256-CBC (OS)                  | 1KB          |     277.33 ns |     1.808 ns |     1.510 ns |      72 B |
| Decrypt · AES-256-CBC (CryptoHives-Scalar)  | 1KB          |   3,665.74 ns |     0.654 ns |     0.546 ns |         - |
| Decrypt · AES-256-CBC (BouncyCastle)        | 1KB          |   4,431.11 ns |     4.299 ns |     3.811 ns |    1024 B |
|                                             |              |               |              |              |           |
| Encrypt · AES-256-CBC (OS)                  | 1KB          |     725.48 ns |     6.036 ns |     5.041 ns |      72 B |
| Encrypt · AES-256-CBC (CryptoHives-ARM-AES) | 1KB          |   1,111.63 ns |     1.337 ns |     1.250 ns |         - |
| Encrypt · AES-256-CBC (CryptoHives-Scalar)  | 1KB          |   4,080.11 ns |     6.491 ns |     5.754 ns |         - |
| Encrypt · AES-256-CBC (BouncyCastle)        | 1KB          |   4,278.77 ns |     1.812 ns |     1.415 ns |    1024 B |
|                                             |              |               |              |              |           |
| Decrypt · AES-256-CBC (OS)                  | 8KB          |     718.94 ns |     5.224 ns |     4.631 ns |      72 B |
| Decrypt · AES-256-CBC (CryptoHives-ARM-AES) | 8KB          |     757.18 ns |     7.508 ns |     6.656 ns |         - |
| Decrypt · AES-256-CBC (CryptoHives-Scalar)  | 8KB          |  28,852.85 ns |    11.885 ns |     9.279 ns |         - |
| Decrypt · AES-256-CBC (BouncyCastle)        | 8KB          |  33,210.94 ns |    35.105 ns |    32.837 ns |    1024 B |
|                                             |              |               |              |              |           |
| Encrypt · AES-256-CBC (OS)                  | 8KB          |   4,427.06 ns |     2.474 ns |     2.193 ns |      72 B |
| Encrypt · AES-256-CBC (CryptoHives-ARM-AES) | 8KB          |   8,449.00 ns |   125.718 ns |   104.980 ns |         - |
| Encrypt · AES-256-CBC (CryptoHives-Scalar)  | 8KB          |  32,271.16 ns |    15.984 ns |    14.951 ns |         - |
| Encrypt · AES-256-CBC (BouncyCastle)        | 8KB          |  32,441.36 ns |     9.565 ns |     8.479 ns |    1024 B |
|                                             |              |               |              |              |           |
| Decrypt · AES-256-CBC (OS)                  | 128KB        |   8,427.32 ns |    66.965 ns |    55.919 ns |      72 B |
| Decrypt · AES-256-CBC (CryptoHives-ARM-AES) | 128KB        |  12,018.59 ns |    19.040 ns |    14.865 ns |         - |
| Decrypt · AES-256-CBC (CryptoHives-Scalar)  | 128KB        | 460,842.07 ns | 2,400.630 ns | 2,004.635 ns |         - |
| Decrypt · AES-256-CBC (BouncyCastle)        | 128KB        | 527,934.17 ns | 2,460.032 ns | 2,054.238 ns |    1024 B |
|                                             |              |               |              |              |           |
| Encrypt · AES-256-CBC (OS)                  | 128KB        |  69,445.56 ns |   565.076 ns |   528.573 ns |      72 B |
| Encrypt · AES-256-CBC (CryptoHives-ARM-AES) | 128KB        | 140,490.51 ns | 1,373.498 ns | 1,146.933 ns |         - |
| Encrypt · AES-256-CBC (CryptoHives-Scalar)  | 128KB        | 515,748.26 ns |   457.872 ns |   357.476 ns |         - |
| Encrypt · AES-256-CBC (BouncyCastle)        | 128KB        | 517,875.88 ns |   244.278 ns |   203.984 ns |    1024 B |