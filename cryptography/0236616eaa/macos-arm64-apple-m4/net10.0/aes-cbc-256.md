| Description                                 | TestDataSize | Mean          | Error         | StdDev        | Median        | Allocated |
|-------------------------------------------- |------------- |--------------:|--------------:|--------------:|--------------:|----------:|
| Decrypt · AES-256-CBC (CryptoHives-ARM-AES) | 128B         |      32.93 ns |      0.653 ns |      0.850 ns |      32.60 ns |         - |
| Decrypt · AES-256-CBC (OS)                  | 128B         |     226.13 ns |      1.272 ns |      1.190 ns |     226.18 ns |      72 B |
| Decrypt · AES-256-CBC (BouncyCastle)        | 128B         |     793.08 ns |      6.863 ns |     12.199 ns |     790.44 ns |    1024 B |
| Decrypt · AES-256-CBC (CryptoHives-Scalar)  | 128B         |   2,331.59 ns |    175.158 ns |    491.162 ns |   2,477.06 ns |         - |
|                                             |              |               |               |               |               |           |
| Encrypt · AES-256-CBC (CryptoHives-ARM-AES) | 128B         |      51.37 ns |      0.106 ns |      0.094 ns |      51.41 ns |         - |
| Encrypt · AES-256-CBC (OS)                  | 128B         |     249.75 ns |      0.748 ns |      0.700 ns |     249.85 ns |      72 B |
| Encrypt · AES-256-CBC (CryptoHives-Scalar)  | 128B         |     586.50 ns |      0.137 ns |      0.128 ns |     586.54 ns |         - |
| Encrypt · AES-256-CBC (BouncyCastle)        | 128B         |     723.57 ns |      0.347 ns |      0.324 ns |     723.59 ns |    1024 B |
|                                             |              |               |               |               |               |           |
| Decrypt · AES-256-CBC (CryptoHives-ARM-AES) | 1KB          |     111.32 ns |      0.091 ns |      0.080 ns |     111.29 ns |         - |
| Decrypt · AES-256-CBC (OS)                  | 1KB          |     287.53 ns |      1.326 ns |      1.240 ns |     287.55 ns |      72 B |
| Decrypt · AES-256-CBC (CryptoHives-Scalar)  | 1KB          |   3,690.80 ns |      0.874 ns |      0.775 ns |   3,690.77 ns |         - |
| Decrypt · AES-256-CBC (BouncyCastle)        | 1KB          |   4,408.24 ns |      2.882 ns |      2.555 ns |   4,408.70 ns |    1024 B |
|                                             |              |               |               |               |               |           |
| Encrypt · AES-256-CBC (CryptoHives-ARM-AES) | 1KB          |     515.10 ns |      3.108 ns |      2.907 ns |     514.44 ns |         - |
| Encrypt · AES-256-CBC (OS)                  | 1KB          |     769.50 ns |      2.551 ns |      2.386 ns |     769.98 ns |      72 B |
| Encrypt · AES-256-CBC (CryptoHives-Scalar)  | 1KB          |   4,208.36 ns |      2.321 ns |      2.058 ns |   4,208.85 ns |         - |
| Encrypt · AES-256-CBC (BouncyCastle)        | 1KB          |   4,262.41 ns |      1.848 ns |      1.728 ns |   4,262.68 ns |    1024 B |
|                                             |              |               |               |               |               |           |
| Decrypt · AES-256-CBC (OS)                  | 8KB          |     759.97 ns |      2.808 ns |      2.626 ns |     759.43 ns |      72 B |
| Decrypt · AES-256-CBC (CryptoHives-ARM-AES) | 8KB          |     790.88 ns |      0.110 ns |      0.097 ns |     790.88 ns |         - |
| Decrypt · AES-256-CBC (CryptoHives-Scalar)  | 8KB          |  29,123.55 ns |      9.153 ns |      8.562 ns |  29,124.91 ns |         - |
| Decrypt · AES-256-CBC (BouncyCastle)        | 8KB          |  33,275.11 ns |     72.917 ns |     68.207 ns |  33,286.49 ns |    1024 B |
|                                             |              |               |               |               |               |           |
| Encrypt · AES-256-CBC (CryptoHives-ARM-AES) | 8KB          |   4,548.85 ns |     25.137 ns |     23.513 ns |   4,548.06 ns |         - |
| Encrypt · AES-256-CBC (OS)                  | 8KB          |   4,722.10 ns |     23.099 ns |     20.476 ns |   4,714.88 ns |      72 B |
| Encrypt · AES-256-CBC (BouncyCastle)        | 8KB          |  32,514.33 ns |     23.345 ns |     21.837 ns |  32,505.58 ns |    1024 B |
| Encrypt · AES-256-CBC (CryptoHives-Scalar)  | 8KB          |  33,176.10 ns |     10.843 ns |     10.143 ns |  33,175.99 ns |         - |
|                                             |              |               |               |               |               |           |
| Decrypt · AES-256-CBC (CryptoHives-ARM-AES) | 128KB        |  14,580.00 ns |    322.945 ns |    947.141 ns |  14,947.81 ns |         - |
| Decrypt · AES-256-CBC (OS)                  | 128KB        |  41,686.29 ns |     56.837 ns |     50.384 ns |  41,670.54 ns |      72 B |
| Decrypt · AES-256-CBC (CryptoHives-Scalar)  | 128KB        | 563,375.22 ns | 11,078.152 ns | 22,124.268 ns | 567,642.82 ns |         - |
| Decrypt · AES-256-CBC (BouncyCastle)        | 128KB        | 641,776.61 ns |  9,974.781 ns |  9,330.417 ns | 643,098.84 ns |    1024 B |
|                                             |              |               |               |               |               |           |
| Encrypt · AES-256-CBC (OS)                  | 128KB        |  74,086.27 ns |    479.728 ns |    448.738 ns |  74,034.37 ns |      72 B |
| Encrypt · AES-256-CBC (CryptoHives-ARM-AES) | 128KB        |  75,120.57 ns |    376.062 ns |    351.768 ns |  75,159.10 ns |         - |
| Encrypt · AES-256-CBC (CryptoHives-Scalar)  | 128KB        | 617,797.11 ns | 13,910.654 ns | 41,015.880 ns | 624,446.84 ns |         - |
| Encrypt · AES-256-CBC (BouncyCastle)        | 128KB        | 620,988.75 ns | 12,409.093 ns | 16,565.785 ns | 626,090.21 ns |    1024 B |