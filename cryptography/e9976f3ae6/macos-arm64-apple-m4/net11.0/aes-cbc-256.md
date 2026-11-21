| Description                                 | TestDataSize | Mean          | Error        | StdDev       | Allocated |
|-------------------------------------------- |------------- |--------------:|-------------:|-------------:|----------:|
| Decrypt · AES-256-CBC (CryptoHives-ARM-AES) | 128B         |      25.89 ns |     0.055 ns |     0.051 ns |         - |
| Decrypt · AES-256-CBC (OS)                  | 128B         |      53.52 ns |     0.163 ns |     0.136 ns |         - |
| Decrypt · AES-256-CBC (CryptoHives-Scalar)  | 128B         |     476.46 ns |     0.522 ns |     0.488 ns |         - |
| Decrypt · AES-256-CBC (BouncyCastle)        | 128B         |     770.69 ns |     1.305 ns |     1.221 ns |    1024 B |
|                                             |              |               |              |              |           |
| Encrypt · AES-256-CBC (CryptoHives-ARM-AES) | 128B         |      49.19 ns |     0.070 ns |     0.059 ns |         - |
| Encrypt · AES-256-CBC (OS)                  | 128B         |     103.93 ns |     0.276 ns |     0.258 ns |         - |
| Encrypt · AES-256-CBC (CryptoHives-Scalar)  | 128B         |     562.12 ns |     0.685 ns |     0.641 ns |         - |
| Encrypt · AES-256-CBC (BouncyCastle)        | 128B         |     711.74 ns |     0.732 ns |     0.684 ns |    1024 B |
|                                             |              |               |              |              |           |
| Decrypt · AES-256-CBC (CryptoHives-ARM-AES) | 1KB          |     102.24 ns |     0.201 ns |     0.179 ns |         - |
| Decrypt · AES-256-CBC (OS)                  | 1KB          |     109.26 ns |     0.296 ns |     0.247 ns |         - |
| Decrypt · AES-256-CBC (CryptoHives-Scalar)  | 1KB          |   3,424.28 ns |    12.980 ns |    10.839 ns |         - |
| Decrypt · AES-256-CBC (BouncyCastle)        | 1KB          |   4,295.99 ns |    12.270 ns |    11.478 ns |    1024 B |
|                                             |              |               |              |              |           |
| Encrypt · AES-256-CBC (CryptoHives-ARM-AES) | 1KB          |     476.87 ns |     0.201 ns |     0.188 ns |         - |
| Encrypt · AES-256-CBC (OS)                  | 1KB          |     561.68 ns |     2.413 ns |     2.257 ns |         - |
| Encrypt · AES-256-CBC (CryptoHives-Scalar)  | 1KB          |   4,040.41 ns |     4.816 ns |     4.269 ns |         - |
| Encrypt · AES-256-CBC (BouncyCastle)        | 1KB          |   4,232.34 ns |     4.645 ns |     4.345 ns |    1024 B |
|                                             |              |               |              |              |           |
| Decrypt · AES-256-CBC (OS)                  | 8KB          |     572.32 ns |     1.677 ns |     1.569 ns |         - |
| Decrypt · AES-256-CBC (CryptoHives-ARM-AES) | 8KB          |     715.22 ns |     2.084 ns |     1.847 ns |         - |
| Decrypt · AES-256-CBC (CryptoHives-Scalar)  | 8KB          |  26,278.42 ns |    52.777 ns |    49.367 ns |         - |
| Decrypt · AES-256-CBC (BouncyCastle)        | 8KB          |  32,356.39 ns |    32.106 ns |    30.032 ns |    1024 B |
|                                             |              |               |              |              |           |
| Encrypt · AES-256-CBC (CryptoHives-ARM-AES) | 8KB          |   4,194.83 ns |     5.432 ns |     5.081 ns |         - |
| Encrypt · AES-256-CBC (OS)                  | 8KB          |   4,312.13 ns |     6.084 ns |     5.691 ns |         - |
| Encrypt · AES-256-CBC (CryptoHives-Scalar)  | 8KB          |  31,745.29 ns |    58.488 ns |    54.709 ns |         - |
| Encrypt · AES-256-CBC (BouncyCastle)        | 8KB          |  32,350.61 ns |    39.431 ns |    36.884 ns |    1024 B |
|                                             |              |               |              |              |           |
| Decrypt · AES-256-CBC (OS)                  | 128KB        |   8,534.53 ns |    28.893 ns |    27.027 ns |         - |
| Decrypt · AES-256-CBC (CryptoHives-ARM-AES) | 128KB        |  11,180.34 ns |    23.290 ns |    21.786 ns |         - |
| Decrypt · AES-256-CBC (CryptoHives-Scalar)  | 128KB        | 426,474.43 ns |   374.988 ns |   332.418 ns |         - |
| Decrypt · AES-256-CBC (BouncyCastle)        | 128KB        | 511,411.52 ns |   624.346 ns |   584.014 ns |    1024 B |
|                                             |              |               |              |              |           |
| Encrypt · AES-256-CBC (CryptoHives-ARM-AES) | 128KB        |  67,975.08 ns |    44.394 ns |    41.526 ns |         - |
| Encrypt · AES-256-CBC (OS)                  | 128KB        |  69,666.23 ns |    63.197 ns |    59.115 ns |         - |
| Encrypt · AES-256-CBC (CryptoHives-Scalar)  | 128KB        | 507,389.10 ns | 1,180.858 ns | 1,104.575 ns |         - |
| Encrypt · AES-256-CBC (BouncyCastle)        | 128KB        | 516,055.17 ns |   470.395 ns |   440.007 ns |    1024 B |