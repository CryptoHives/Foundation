| Description                                 | TestDataSize | Mean          | Error        | StdDev       | Allocated |
|-------------------------------------------- |------------- |--------------:|-------------:|-------------:|----------:|
| Decrypt · AES-256-CBC (CryptoHives-ARM-AES) | 128B         |      26.28 ns |     0.414 ns |     0.387 ns |         - |
| Decrypt · AES-256-CBC (OS)                  | 128B         |     234.02 ns |     2.953 ns |     2.762 ns |      72 B |
| Decrypt · AES-256-CBC (CryptoHives-Scalar)  | 128B         |     522.99 ns |     1.427 ns |     1.114 ns |         - |
| Decrypt · AES-256-CBC (BouncyCastle)        | 128B         |     794.87 ns |    12.258 ns |    11.466 ns |    1024 B |
|                                             |              |               |              |              |           |
| Encrypt · AES-256-CBC (CryptoHives-ARM-AES) | 128B         |      52.95 ns |     0.796 ns |     0.745 ns |         - |
| Encrypt · AES-256-CBC (OS)                  | 128B         |     257.16 ns |     0.647 ns |     0.505 ns |      72 B |
| Encrypt · AES-256-CBC (CryptoHives-Scalar)  | 128B         |     578.66 ns |    10.266 ns |     9.602 ns |         - |
| Encrypt · AES-256-CBC (BouncyCastle)        | 128B         |     732.96 ns |    10.920 ns |    10.215 ns |    1024 B |
|                                             |              |               |              |              |           |
| Decrypt · AES-256-CBC (CryptoHives-ARM-AES) | 1KB          |     112.76 ns |     1.706 ns |     1.596 ns |         - |
| Decrypt · AES-256-CBC (OS)                  | 1KB          |     294.36 ns |     1.774 ns |     1.385 ns |      72 B |
| Decrypt · AES-256-CBC (CryptoHives-Scalar)  | 1KB          |   3,716.39 ns |    45.297 ns |    42.371 ns |         - |
| Decrypt · AES-256-CBC (BouncyCastle)        | 1KB          |   4,530.65 ns |    78.750 ns |    73.663 ns |    1024 B |
|                                             |              |               |              |              |           |
| Encrypt · AES-256-CBC (CryptoHives-ARM-AES) | 1KB          |     540.51 ns |     8.825 ns |     8.255 ns |         - |
| Encrypt · AES-256-CBC (OS)                  | 1KB          |     789.22 ns |    10.996 ns |    10.285 ns |      72 B |
| Encrypt · AES-256-CBC (CryptoHives-Scalar)  | 1KB          |   4,118.78 ns |     4.694 ns |     3.665 ns |         - |
| Encrypt · AES-256-CBC (BouncyCastle)        | 1KB          |   4,295.10 ns |    63.345 ns |    52.896 ns |    1024 B |
|                                             |              |               |              |              |           |
| Decrypt · AES-256-CBC (OS)                  | 8KB          |     768.50 ns |    11.644 ns |    10.892 ns |      72 B |
| Decrypt · AES-256-CBC (CryptoHives-ARM-AES) | 8KB          |     800.23 ns |    11.300 ns |    10.017 ns |         - |
| Decrypt · AES-256-CBC (CryptoHives-Scalar)  | 8KB          |  29,284.70 ns |   362.806 ns |   339.369 ns |         - |
| Decrypt · AES-256-CBC (BouncyCastle)        | 8KB          |  33,739.42 ns |   656.293 ns |   613.897 ns |    1024 B |
|                                             |              |               |              |              |           |
| Encrypt · AES-256-CBC (CryptoHives-ARM-AES) | 8KB          |   4,644.90 ns |    56.201 ns |    49.821 ns |         - |
| Encrypt · AES-256-CBC (OS)                  | 8KB          |   4,726.78 ns |    38.167 ns |    31.871 ns |      72 B |
| Encrypt · AES-256-CBC (CryptoHives-Scalar)  | 8KB          |  32,440.04 ns |   161.035 ns |   125.725 ns |         - |
| Encrypt · AES-256-CBC (BouncyCastle)        | 8KB          |  32,548.20 ns |     9.926 ns |     7.749 ns |    1024 B |
|                                             |              |               |              |              |           |
| Decrypt · AES-256-CBC (OS)                  | 128KB        |   8,901.59 ns |    39.265 ns |    30.655 ns |      72 B |
| Decrypt · AES-256-CBC (CryptoHives-ARM-AES) | 128KB        |  12,555.49 ns |   184.932 ns |   172.986 ns |         - |
| Decrypt · AES-256-CBC (CryptoHives-Scalar)  | 128KB        | 475,491.93 ns | 6,033.931 ns | 5,644.142 ns |         - |
| Decrypt · AES-256-CBC (BouncyCastle)        | 128KB        | 532,099.95 ns | 2,329.937 ns | 1,819.062 ns |    1024 B |
|                                             |              |               |              |              |           |
| Encrypt · AES-256-CBC (OS)                  | 128KB        |  73,625.32 ns |   832.653 ns |   778.864 ns |      72 B |
| Encrypt · AES-256-CBC (CryptoHives-ARM-AES) | 128KB        |  74,530.48 ns |   439.479 ns |   343.116 ns |         - |
| Encrypt · AES-256-CBC (CryptoHives-Scalar)  | 128KB        | 517,704.18 ns |   762.935 ns |   595.650 ns |         - |
| Encrypt · AES-256-CBC (BouncyCastle)        | 128KB        | 520,659.98 ns |   388.739 ns |   303.502 ns |    1024 B |