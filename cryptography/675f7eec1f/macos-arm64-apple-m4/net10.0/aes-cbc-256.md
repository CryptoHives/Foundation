| Description                                 | TestDataSize | Mean          | Error        | StdDev       | Allocated |
|-------------------------------------------- |------------- |--------------:|-------------:|-------------:|----------:|
| Decrypt · AES-256-CBC (CryptoHives-ARM-AES) | 128B         |      26.07 ns |     0.017 ns |     0.014 ns |         - |
| Decrypt · AES-256-CBC (OS)                  | 128B         |     228.85 ns |     0.446 ns |     0.418 ns |      72 B |
| Decrypt · AES-256-CBC (CryptoHives-Scalar)  | 128B         |     521.27 ns |     0.258 ns |     0.201 ns |         - |
| Decrypt · AES-256-CBC (BouncyCastle)        | 128B         |     802.41 ns |     0.927 ns |     0.867 ns |    1024 B |
|                                             |              |               |              |              |           |
| Encrypt · AES-256-CBC (CryptoHives-ARM-AES) | 128B         |      52.15 ns |     0.076 ns |     0.071 ns |         - |
| Encrypt · AES-256-CBC (OS)                  | 128B         |     254.07 ns |     1.156 ns |     1.081 ns |      72 B |
| Encrypt · AES-256-CBC (CryptoHives-Scalar)  | 128B         |     574.12 ns |     0.622 ns |     0.582 ns |         - |
| Encrypt · AES-256-CBC (BouncyCastle)        | 128B         |     740.73 ns |     1.799 ns |     1.595 ns |    1024 B |
|                                             |              |               |              |              |           |
| Decrypt · AES-256-CBC (CryptoHives-ARM-AES) | 1KB          |     112.03 ns |     0.293 ns |     0.260 ns |         - |
| Decrypt · AES-256-CBC (OS)                  | 1KB          |     286.16 ns |     1.029 ns |     0.803 ns |      72 B |
| Decrypt · AES-256-CBC (CryptoHives-Scalar)  | 1KB          |   3,693.21 ns |     5.982 ns |     5.595 ns |         - |
| Decrypt · AES-256-CBC (BouncyCastle)        | 1KB          |   4,462.47 ns |     6.016 ns |     5.627 ns |    1024 B |
|                                             |              |               |              |              |           |
| Encrypt · AES-256-CBC (CryptoHives-ARM-AES) | 1KB          |     509.31 ns |     2.571 ns |     2.405 ns |         - |
| Encrypt · AES-256-CBC (OS)                  | 1KB          |     753.34 ns |     2.375 ns |     2.222 ns |      72 B |
| Encrypt · AES-256-CBC (CryptoHives-Scalar)  | 1KB          |   4,124.08 ns |     2.420 ns |     2.145 ns |         - |
| Encrypt · AES-256-CBC (BouncyCastle)        | 1KB          |   4,298.17 ns |     3.393 ns |     3.008 ns |    1024 B |
|                                             |              |               |              |              |           |
| Decrypt · AES-256-CBC (OS)                  | 8KB          |     751.27 ns |     2.476 ns |     2.316 ns |      72 B |
| Decrypt · AES-256-CBC (CryptoHives-ARM-AES) | 8KB          |     795.29 ns |     0.824 ns |     0.771 ns |         - |
| Decrypt · AES-256-CBC (CryptoHives-Scalar)  | 8KB          |  29,029.50 ns |    12.643 ns |     9.871 ns |         - |
| Decrypt · AES-256-CBC (BouncyCastle)        | 8KB          |  33,489.24 ns |    97.561 ns |    91.258 ns |    1024 B |
|                                             |              |               |              |              |           |
| Encrypt · AES-256-CBC (CryptoHives-ARM-AES) | 8KB          |   4,457.18 ns |     7.155 ns |     6.343 ns |         - |
| Encrypt · AES-256-CBC (OS)                  | 8KB          |   4,526.50 ns |    24.708 ns |    23.112 ns |      72 B |
| Encrypt · AES-256-CBC (CryptoHives-Scalar)  | 8KB          |  32,474.01 ns |    30.975 ns |    24.184 ns |         - |
| Encrypt · AES-256-CBC (BouncyCastle)        | 8KB          |  32,603.65 ns |    97.827 ns |    86.721 ns |    1024 B |
|                                             |              |               |              |              |           |
| Decrypt · AES-256-CBC (OS)                  | 128KB        |   8,825.22 ns |    11.213 ns |     9.363 ns |      72 B |
| Decrypt · AES-256-CBC (CryptoHives-ARM-AES) | 128KB        |  12,436.12 ns |    19.394 ns |    18.141 ns |         - |
| Decrypt · AES-256-CBC (CryptoHives-Scalar)  | 128KB        | 465,972.65 ns |   912.976 ns |   853.998 ns |         - |
| Decrypt · AES-256-CBC (BouncyCastle)        | 128KB        | 532,577.48 ns | 1,267.529 ns | 1,185.648 ns |    1024 B |
|                                             |              |               |              |              |           |
| Encrypt · AES-256-CBC (OS)                  | 128KB        |  70,874.07 ns |   592.802 ns |   554.507 ns |      72 B |
| Encrypt · AES-256-CBC (CryptoHives-ARM-AES) | 128KB        |  72,088.61 ns |   213.440 ns |   199.652 ns |         - |
| Encrypt · AES-256-CBC (CryptoHives-Scalar)  | 128KB        | 517,773.61 ns | 1,723.353 ns | 1,612.026 ns |         - |
| Encrypt · AES-256-CBC (BouncyCastle)        | 128KB        | 522,895.66 ns | 1,375.700 ns | 1,286.830 ns |    1024 B |