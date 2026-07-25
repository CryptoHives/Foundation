| Description                                 | TestDataSize | Mean          | Error        | StdDev     | Allocated |
|-------------------------------------------- |------------- |--------------:|-------------:|-----------:|----------:|
| Decrypt · AES-256-CBC (CryptoHives-ARM-AES) | 128B         |      25.94 ns |     0.012 ns |   0.011 ns |         - |
| Decrypt · AES-256-CBC (OS)                  | 128B         |     228.65 ns |     0.760 ns |   0.711 ns |      72 B |
| Decrypt · AES-256-CBC (CryptoHives-Scalar)  | 128B         |     520.73 ns |     0.409 ns |   0.383 ns |         - |
| Decrypt · AES-256-CBC (BouncyCastle)        | 128B         |     796.21 ns |     0.478 ns |   0.447 ns |    1024 B |
|                                             |              |               |              |            |           |
| Encrypt · AES-256-CBC (CryptoHives-ARM-AES) | 128B         |      51.21 ns |     0.133 ns |   0.125 ns |         - |
| Encrypt · AES-256-CBC (OS)                  | 128B         |     249.99 ns |     1.042 ns |   0.975 ns |      72 B |
| Encrypt · AES-256-CBC (CryptoHives-Scalar)  | 128B         |     569.79 ns |     0.102 ns |   0.090 ns |         - |
| Encrypt · AES-256-CBC (BouncyCastle)        | 128B         |     736.16 ns |     0.332 ns |   0.310 ns |    1024 B |
|                                             |              |               |              |            |           |
| Decrypt · AES-256-CBC (CryptoHives-ARM-AES) | 1KB          |     110.75 ns |     0.171 ns |   0.160 ns |         - |
| Decrypt · AES-256-CBC (OS)                  | 1KB          |     283.38 ns |     2.026 ns |   1.796 ns |      72 B |
| Decrypt · AES-256-CBC (CryptoHives-Scalar)  | 1KB          |   3,675.46 ns |     1.102 ns |   0.977 ns |         - |
| Decrypt · AES-256-CBC (BouncyCastle)        | 1KB          |   4,457.34 ns |    22.236 ns |  20.800 ns |    1024 B |
|                                             |              |               |              |            |           |
| Encrypt · AES-256-CBC (CryptoHives-ARM-AES) | 1KB          |     502.20 ns |     2.961 ns |   2.770 ns |         - |
| Encrypt · AES-256-CBC (OS)                  | 1KB          |     740.11 ns |     3.304 ns |   3.090 ns |      72 B |
| Encrypt · AES-256-CBC (CryptoHives-Scalar)  | 1KB          |   4,094.64 ns |     4.150 ns |   3.882 ns |         - |
| Encrypt · AES-256-CBC (BouncyCastle)        | 1KB          |   4,279.88 ns |     0.877 ns |   0.777 ns |    1024 B |
|                                             |              |               |              |            |           |
| Decrypt · AES-256-CBC (OS)                  | 8KB          |     737.84 ns |     2.291 ns |   2.143 ns |      72 B |
| Decrypt · AES-256-CBC (CryptoHives-ARM-AES) | 8KB          |     784.13 ns |     1.241 ns |   1.161 ns |         - |
| Decrypt · AES-256-CBC (CryptoHives-Scalar)  | 8KB          |  28,876.69 ns |    31.235 ns |  27.689 ns |         - |
| Decrypt · AES-256-CBC (BouncyCastle)        | 8KB          |  33,243.01 ns |    57.197 ns |  53.502 ns |    1024 B |
|                                             |              |               |              |            |           |
| Encrypt · AES-256-CBC (CryptoHives-ARM-AES) | 8KB          |   4,416.69 ns |     2.514 ns |   2.099 ns |         - |
| Encrypt · AES-256-CBC (OS)                  | 8KB          |   4,431.78 ns |    29.443 ns |  27.541 ns |      72 B |
| Encrypt · AES-256-CBC (CryptoHives-Scalar)  | 8KB          |  32,276.93 ns |    19.301 ns |  18.054 ns |         - |
| Encrypt · AES-256-CBC (BouncyCastle)        | 8KB          |  32,513.05 ns |    15.985 ns |  13.348 ns |    1024 B |
|                                             |              |               |              |            |           |
| Decrypt · AES-256-CBC (OS)                  | 128KB        |   8,687.05 ns |    35.014 ns |  32.752 ns |      72 B |
| Decrypt · AES-256-CBC (CryptoHives-ARM-AES) | 128KB        |  12,332.70 ns |    18.755 ns |  17.544 ns |         - |
| Decrypt · AES-256-CBC (CryptoHives-Scalar)  | 128KB        | 463,437.70 ns |    85.650 ns |  80.117 ns |         - |
| Decrypt · AES-256-CBC (BouncyCastle)        | 128KB        | 527,909.74 ns | 1,089.556 ns | 965.863 ns |    1024 B |
|                                             |              |               |              |            |           |
| Encrypt · AES-256-CBC (OS)                  | 128KB        |  69,064.77 ns |   295.145 ns | 276.079 ns |      72 B |
| Encrypt · AES-256-CBC (CryptoHives-ARM-AES) | 128KB        |  72,581.96 ns |   323.630 ns | 302.723 ns |         - |
| Encrypt · AES-256-CBC (CryptoHives-Scalar)  | 128KB        | 515,155.44 ns |   145.406 ns | 128.898 ns |         - |
| Encrypt · AES-256-CBC (BouncyCastle)        | 128KB        | 518,235.92 ns |   127.222 ns | 112.779 ns |    1024 B |