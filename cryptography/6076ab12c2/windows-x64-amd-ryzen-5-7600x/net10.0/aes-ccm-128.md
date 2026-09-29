| Description                                | TestDataSize | Mean           | Error        | StdDev       | Allocated |
|------------------------------------------- |------------- |---------------:|-------------:|-------------:|----------:|
| Decrypt · AES-128-CCM (CryptoHives-AES-NI) | 128B         |       465.5 ns |      2.87 ns |      2.68 ns |         - |
| Decrypt · AES-128-CCM (CryptoHives-Scalar) | 128B         |     1,097.7 ns |     14.87 ns |     13.91 ns |         - |
| Decrypt · AES-128-CCM (BouncyCastle)       | 128B         |     1,787.3 ns |     17.75 ns |     15.74 ns |    2616 B |
|                                            |              |                |              |              |           |
| Encrypt · AES-128-CCM (CryptoHives-AES-NI) | 128B         |       405.4 ns |      2.42 ns |      2.27 ns |         - |
| Encrypt · AES-128-CCM (CryptoHives-Scalar) | 128B         |     1,053.5 ns |      9.51 ns |      8.89 ns |         - |
| Encrypt · AES-128-CCM (BouncyCastle)       | 128B         |     1,710.8 ns |     30.41 ns |     28.45 ns |    2504 B |
|                                            |              |                |              |              |           |
| Decrypt · AES-128-CCM (CryptoHives-AES-NI) | 1KB          |     2,684.1 ns |     11.25 ns |     10.52 ns |         - |
| Decrypt · AES-128-CCM (CryptoHives-Scalar) | 1KB          |     6,950.3 ns |     76.11 ns |     71.19 ns |         - |
| Decrypt · AES-128-CCM (BouncyCastle)       | 1KB          |     9,424.6 ns |     89.66 ns |     79.48 ns |    3512 B |
|                                            |              |                |              |              |           |
| Encrypt · AES-128-CCM (CryptoHives-AES-NI) | 1KB          |     2,624.3 ns |      5.79 ns |      5.13 ns |         - |
| Encrypt · AES-128-CCM (CryptoHives-Scalar) | 1KB          |     6,871.0 ns |     95.05 ns |     88.91 ns |         - |
| Encrypt · AES-128-CCM (BouncyCastle)       | 1KB          |     9,337.2 ns |    182.02 ns |    170.26 ns |    2504 B |
|                                            |              |                |              |              |           |
| Decrypt · AES-128-CCM (CryptoHives-AES-NI) | 8KB          |    20,399.2 ns |    115.61 ns |    108.14 ns |         - |
| Decrypt · AES-128-CCM (CryptoHives-Scalar) | 8KB          |    53,216.5 ns |    475.55 ns |    397.10 ns |         - |
| Decrypt · AES-128-CCM (BouncyCastle)       | 8KB          |    69,933.5 ns |    955.46 ns |    893.74 ns |   10680 B |
|                                            |              |                |              |              |           |
| Encrypt · AES-128-CCM (CryptoHives-AES-NI) | 8KB          |    20,423.5 ns |    118.59 ns |    110.93 ns |         - |
| Encrypt · AES-128-CCM (CryptoHives-Scalar) | 8KB          |    54,074.5 ns |    711.17 ns |    665.22 ns |         - |
| Encrypt · AES-128-CCM (BouncyCastle)       | 8KB          |    70,110.4 ns |    927.05 ns |    867.17 ns |    2504 B |
|                                            |              |                |              |              |           |
| Decrypt · AES-128-CCM (CryptoHives-AES-NI) | 128KB        |   323,601.2 ns |  1,544.27 ns |  1,444.51 ns |         - |
| Decrypt · AES-128-CCM (CryptoHives-Scalar) | 128KB        |   851,993.7 ns | 11,264.79 ns | 10,537.09 ns |         - |
| Decrypt · AES-128-CCM (BouncyCastle)       | 128KB        | 1,149,208.4 ns | 13,755.94 ns | 12,867.32 ns |  133574 B |
|                                            |              |                |              |              |           |
| Encrypt · AES-128-CCM (CryptoHives-AES-NI) | 128KB        |   323,989.3 ns |  1,810.34 ns |  1,693.39 ns |         - |
| Encrypt · AES-128-CCM (CryptoHives-Scalar) | 128KB        |   855,843.9 ns |  9,212.85 ns |  8,617.71 ns |      12 B |
| Encrypt · AES-128-CCM (BouncyCastle)       | 128KB        | 1,112,347.3 ns | 12,934.33 ns | 11,465.95 ns |    2504 B |