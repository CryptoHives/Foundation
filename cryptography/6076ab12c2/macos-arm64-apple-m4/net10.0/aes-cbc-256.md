| Description                                 | TestDataSize | Mean          | Error        | StdDev       | Allocated |
|-------------------------------------------- |------------- |--------------:|-------------:|-------------:|----------:|
| Decrypt · AES-256-CBC (CryptoHives-ARM-AES) | 128B         |      25.36 ns |     0.036 ns |     0.032 ns |         - |
| Decrypt · AES-256-CBC (OS)                  | 128B         |     224.43 ns |     1.655 ns |     1.548 ns |      72 B |
| Decrypt · AES-256-CBC (CryptoHives-Scalar)  | 128B         |     510.55 ns |     0.508 ns |     0.450 ns |         - |
| Decrypt · AES-256-CBC (BouncyCastle)        | 128B         |     786.17 ns |     0.457 ns |     0.427 ns |    1024 B |
|                                             |              |               |              |              |           |
| Encrypt · AES-256-CBC (CryptoHives-ARM-AES) | 128B         |      50.97 ns |     0.162 ns |     0.152 ns |         - |
| Encrypt · AES-256-CBC (OS)                  | 128B         |     245.62 ns |     1.627 ns |     1.522 ns |      72 B |
| Encrypt · AES-256-CBC (CryptoHives-Scalar)  | 128B         |     559.40 ns |     1.229 ns |     1.026 ns |         - |
| Encrypt · AES-256-CBC (BouncyCastle)        | 128B         |     722.40 ns |     1.120 ns |     0.993 ns |    1024 B |
|                                             |              |               |              |              |           |
| Decrypt · AES-256-CBC (CryptoHives-ARM-AES) | 1KB          |     107.61 ns |     0.576 ns |     0.511 ns |         - |
| Decrypt · AES-256-CBC (OS)                  | 1KB          |     278.01 ns |     3.526 ns |     3.126 ns |      72 B |
| Decrypt · AES-256-CBC (CryptoHives-Scalar)  | 1KB          |   3,595.93 ns |     0.919 ns |     0.859 ns |         - |
| Decrypt · AES-256-CBC (BouncyCastle)        | 1KB          |   4,425.50 ns |     2.573 ns |     2.281 ns |    1024 B |
|                                             |              |               |              |              |           |
| Encrypt · AES-256-CBC (CryptoHives-ARM-AES) | 1KB          |     500.32 ns |     0.244 ns |     0.217 ns |         - |
| Encrypt · AES-256-CBC (OS)                  | 1KB          |     717.35 ns |     2.743 ns |     2.566 ns |      72 B |
| Encrypt · AES-256-CBC (CryptoHives-Scalar)  | 1KB          |   4,010.00 ns |     2.622 ns |     2.325 ns |         - |
| Encrypt · AES-256-CBC (BouncyCastle)        | 1KB          |   4,256.66 ns |     1.738 ns |     1.541 ns |    1024 B |
|                                             |              |               |              |              |           |
| Decrypt · AES-256-CBC (OS)                  | 8KB          |     724.68 ns |     2.922 ns |     2.282 ns |      72 B |
| Decrypt · AES-256-CBC (CryptoHives-ARM-AES) | 8KB          |     754.71 ns |     2.899 ns |     2.711 ns |         - |
| Decrypt · AES-256-CBC (CryptoHives-Scalar)  | 8KB          |  28,443.75 ns |   229.963 ns |   215.108 ns |         - |
| Decrypt · AES-256-CBC (BouncyCastle)        | 8KB          |  33,243.35 ns |    63.989 ns |    56.725 ns |    1024 B |
|                                             |              |               |              |              |           |
| Encrypt · AES-256-CBC (CryptoHives-ARM-AES) | 8KB          |   4,418.27 ns |     1.679 ns |     1.489 ns |         - |
| Encrypt · AES-256-CBC (OS)                  | 8KB          |   4,422.31 ns |     2.988 ns |     2.495 ns |      72 B |
| Encrypt · AES-256-CBC (CryptoHives-Scalar)  | 8KB          |  31,552.52 ns |    16.174 ns |    15.129 ns |         - |
| Encrypt · AES-256-CBC (BouncyCastle)        | 8KB          |  32,547.15 ns |    11.350 ns |    10.617 ns |    1024 B |
|                                             |              |               |              |              |           |
| Decrypt · AES-256-CBC (OS)                  | 128KB        |   8,678.56 ns |   124.693 ns |   110.537 ns |      72 B |
| Decrypt · AES-256-CBC (CryptoHives-ARM-AES) | 128KB        |  12,002.22 ns |    23.390 ns |    20.735 ns |         - |
| Decrypt · AES-256-CBC (CryptoHives-Scalar)  | 128KB        | 454,262.04 ns |   424.783 ns |   331.643 ns |         - |
| Decrypt · AES-256-CBC (BouncyCastle)        | 128KB        | 531,148.25 ns | 2,340.632 ns | 2,074.910 ns |    1024 B |
|                                             |              |               |              |              |           |
| Encrypt · AES-256-CBC (OS)                  | 128KB        |  69,013.04 ns |    34.496 ns |    32.268 ns |      72 B |
| Encrypt · AES-256-CBC (CryptoHives-ARM-AES) | 128KB        |  71,622.78 ns |    29.574 ns |    24.696 ns |         - |
| Encrypt · AES-256-CBC (CryptoHives-Scalar)  | 128KB        | 504,341.19 ns |   199.056 ns |   176.458 ns |         - |
| Encrypt · AES-256-CBC (BouncyCastle)        | 128KB        | 519,814.20 ns |   165.072 ns |   154.409 ns |    1024 B |