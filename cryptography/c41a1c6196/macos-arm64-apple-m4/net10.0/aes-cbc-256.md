| Description                                 | TestDataSize | Mean          | Error        | StdDev       | Allocated |
|-------------------------------------------- |------------- |--------------:|-------------:|-------------:|----------:|
| Decrypt · AES-256-CBC (CryptoHives-ARM-AES) | 128B         |      25.81 ns |     0.078 ns |     0.065 ns |         - |
| Decrypt · AES-256-CBC (OS)                  | 128B         |     234.20 ns |     0.968 ns |     0.756 ns |      72 B |
| Decrypt · AES-256-CBC (CryptoHives-Scalar)  | 128B         |     478.54 ns |     1.416 ns |     1.255 ns |         - |
| Decrypt · AES-256-CBC (BouncyCastle)        | 128B         |     796.30 ns |     3.735 ns |     3.119 ns |    1024 B |
|                                             |              |               |              |              |           |
| Encrypt · AES-256-CBC (CryptoHives-ARM-AES) | 128B         |      48.13 ns |     0.378 ns |     0.335 ns |         - |
| Encrypt · AES-256-CBC (OS)                  | 128B         |     250.21 ns |     1.292 ns |     1.079 ns |      72 B |
| Encrypt · AES-256-CBC (CryptoHives-Scalar)  | 128B         |     571.93 ns |     6.529 ns |     5.452 ns |         - |
| Encrypt · AES-256-CBC (BouncyCastle)        | 128B         |     734.97 ns |     4.955 ns |     3.868 ns |    1024 B |
|                                             |              |               |              |              |           |
| Decrypt · AES-256-CBC (CryptoHives-ARM-AES) | 1KB          |     109.38 ns |     0.396 ns |     0.309 ns |         - |
| Decrypt · AES-256-CBC (OS)                  | 1KB          |     286.00 ns |     1.365 ns |     1.210 ns |      72 B |
| Decrypt · AES-256-CBC (CryptoHives-Scalar)  | 1KB          |   3,316.12 ns |     4.351 ns |     3.857 ns |         - |
| Decrypt · AES-256-CBC (BouncyCastle)        | 1KB          |   4,426.45 ns |     8.370 ns |     7.420 ns |    1024 B |
|                                             |              |               |              |              |           |
| Encrypt · AES-256-CBC (CryptoHives-ARM-AES) | 1KB          |     469.87 ns |     0.873 ns |     0.816 ns |         - |
| Encrypt · AES-256-CBC (OS)                  | 1KB          |     742.30 ns |     3.446 ns |     3.055 ns |      72 B |
| Encrypt · AES-256-CBC (CryptoHives-Scalar)  | 1KB          |   4,058.35 ns |    13.950 ns |    12.366 ns |         - |
| Encrypt · AES-256-CBC (BouncyCastle)        | 1KB          |   4,315.98 ns |    13.309 ns |    11.798 ns |    1024 B |
|                                             |              |               |              |              |           |
| Decrypt · AES-256-CBC (OS)                  | 8KB          |     748.66 ns |     3.543 ns |     3.141 ns |      72 B |
| Decrypt · AES-256-CBC (CryptoHives-ARM-AES) | 8KB          |     769.03 ns |     1.177 ns |     0.983 ns |         - |
| Decrypt · AES-256-CBC (CryptoHives-Scalar)  | 8KB          |  26,289.05 ns |    24.242 ns |    18.927 ns |         - |
| Decrypt · AES-256-CBC (BouncyCastle)        | 8KB          |  33,430.18 ns |   100.998 ns |    89.532 ns |    1024 B |
|                                             |              |               |              |              |           |
| Encrypt · AES-256-CBC (CryptoHives-ARM-AES) | 8KB          |   4,139.66 ns |    10.201 ns |     9.542 ns |         - |
| Encrypt · AES-256-CBC (OS)                  | 8KB          |   4,512.44 ns |    18.141 ns |    15.148 ns |      72 B |
| Encrypt · AES-256-CBC (CryptoHives-Scalar)  | 8KB          |  32,064.10 ns |    90.492 ns |    84.646 ns |         - |
| Encrypt · AES-256-CBC (BouncyCastle)        | 8KB          |  33,034.34 ns |   147.558 ns |   123.218 ns |    1024 B |
|                                             |              |               |              |              |           |
| Decrypt · AES-256-CBC (OS)                  | 128KB        |   8,773.94 ns |    40.019 ns |    37.434 ns |      72 B |
| Decrypt · AES-256-CBC (CryptoHives-ARM-AES) | 128KB        |  12,165.19 ns |    63.711 ns |    53.202 ns |         - |
| Decrypt · AES-256-CBC (CryptoHives-Scalar)  | 128KB        | 418,380.56 ns | 1,159.883 ns | 1,028.206 ns |         - |
| Decrypt · AES-256-CBC (BouncyCastle)        | 128KB        | 533,099.99 ns | 1,698.432 ns | 1,505.616 ns |    1024 B |
|                                             |              |               |              |              |           |
| Encrypt · AES-256-CBC (CryptoHives-ARM-AES) | 128KB        |  66,933.51 ns |   144.645 ns |   120.785 ns |         - |
| Encrypt · AES-256-CBC (OS)                  | 128KB        |  70,033.34 ns |   237.661 ns |   198.458 ns |      72 B |
| Encrypt · AES-256-CBC (CryptoHives-Scalar)  | 128KB        | 510,698.05 ns | 1,135.762 ns |   948.413 ns |         - |
| Encrypt · AES-256-CBC (BouncyCastle)        | 128KB        | 526,753.33 ns |   788.754 ns |   615.807 ns |    1024 B |