| Description                                 | TestDataSize | Mean          | Error        | StdDev       | Allocated |
|-------------------------------------------- |------------- |--------------:|-------------:|-------------:|----------:|
| Decrypt · AES-128-CBC (CryptoHives-ARM-AES) | 128B         |      23.50 ns |     0.415 ns |     0.388 ns |         - |
| Decrypt · AES-128-CBC (OS)                  | 128B         |     201.60 ns |     2.685 ns |     2.512 ns |      72 B |
| Decrypt · AES-128-CBC (CryptoHives-Scalar)  | 128B         |     392.81 ns |     5.965 ns |     5.580 ns |         - |
| Decrypt · AES-128-CBC (BouncyCastle)        | 128B         |     606.02 ns |     0.510 ns |     0.398 ns |     832 B |
|                                             |              |               |              |              |           |
| Encrypt · AES-128-CBC (CryptoHives-ARM-AES) | 128B         |      42.23 ns |     0.750 ns |     0.701 ns |         - |
| Encrypt · AES-128-CBC (OS)                  | 128B         |     203.71 ns |     3.164 ns |     2.959 ns |      72 B |
| Encrypt · AES-128-CBC (CryptoHives-Scalar)  | 128B         |     442.19 ns |     5.118 ns |     4.788 ns |         - |
| Encrypt · AES-128-CBC (BouncyCastle)        | 128B         |     557.66 ns |     1.404 ns |     1.096 ns |     832 B |
|                                             |              |               |              |              |           |
| Decrypt · AES-128-CBC (CryptoHives-ARM-AES) | 1KB          |      92.75 ns |     1.544 ns |     1.444 ns |         - |
| Decrypt · AES-128-CBC (OS)                  | 1KB          |     237.66 ns |     3.814 ns |     3.568 ns |      72 B |
| Decrypt · AES-128-CBC (CryptoHives-Scalar)  | 1KB          |   2,740.88 ns |    44.232 ns |    41.375 ns |         - |
| Decrypt · AES-128-CBC (BouncyCastle)        | 1KB          |   3,418.33 ns |    51.174 ns |    47.868 ns |     832 B |
|                                             |              |               |              |              |           |
| Encrypt · AES-128-CBC (CryptoHives-ARM-AES) | 1KB          |     407.54 ns |     4.839 ns |     4.526 ns |         - |
| Encrypt · AES-128-CBC (OS)                  | 1KB          |     601.56 ns |     8.653 ns |     8.094 ns |      72 B |
| Encrypt · AES-128-CBC (CryptoHives-Scalar)  | 1KB          |   3,187.17 ns |    61.171 ns |    57.219 ns |         - |
| Encrypt · AES-128-CBC (BouncyCastle)        | 1KB          |   3,294.32 ns |    50.227 ns |    46.983 ns |     832 B |
|                                             |              |               |              |              |           |
| Decrypt · AES-128-CBC (OS)                  | 8KB          |     603.24 ns |    11.744 ns |    10.986 ns |      72 B |
| Decrypt · AES-128-CBC (CryptoHives-ARM-AES) | 8KB          |     654.87 ns |    12.284 ns |    11.490 ns |         - |
| Decrypt · AES-128-CBC (CryptoHives-Scalar)  | 8KB          |  21,531.10 ns |   334.521 ns |   312.912 ns |         - |
| Decrypt · AES-128-CBC (BouncyCastle)        | 8KB          |  25,678.19 ns |   373.566 ns |   349.434 ns |     832 B |
|                                             |              |               |              |              |           |
| Encrypt · AES-128-CBC (OS)                  | 8KB          |   3,541.38 ns |    35.254 ns |    32.977 ns |      72 B |
| Encrypt · AES-128-CBC (CryptoHives-ARM-AES) | 8KB          |   3,614.91 ns |    38.107 ns |    35.646 ns |         - |
| Encrypt · AES-128-CBC (CryptoHives-Scalar)  | 8KB          |  25,006.99 ns |   328.757 ns |   307.519 ns |         - |
| Encrypt · AES-128-CBC (BouncyCastle)        | 8KB          |  25,038.75 ns |   331.579 ns |   310.160 ns |     832 B |
|                                             |              |               |              |              |           |
| Decrypt · AES-128-CBC (OS)                  | 128KB        |   6,794.65 ns |    92.963 ns |    86.958 ns |      72 B |
| Decrypt · AES-128-CBC (CryptoHives-ARM-AES) | 128KB        |  10,209.24 ns |   179.770 ns |   168.157 ns |         - |
| Decrypt · AES-128-CBC (CryptoHives-Scalar)  | 128KB        | 346,511.16 ns | 5,676.002 ns | 5,309.336 ns |         - |
| Decrypt · AES-128-CBC (BouncyCastle)        | 128KB        | 408,061.96 ns | 6,203.768 ns | 5,803.009 ns |     832 B |
|                                             |              |               |              |              |           |
| Encrypt · AES-128-CBC (OS)                  | 128KB        |  54,199.10 ns |   550.329 ns |   514.778 ns |      72 B |
| Encrypt · AES-128-CBC (CryptoHives-ARM-AES) | 128KB        |  58,860.43 ns |   655.675 ns |   613.319 ns |         - |
| Encrypt · AES-128-CBC (CryptoHives-Scalar)  | 128KB        | 399,846.38 ns | 6,221.955 ns | 5,820.021 ns |         - |
| Encrypt · AES-128-CBC (BouncyCastle)        | 128KB        | 400,707.97 ns | 7,361.727 ns | 6,886.164 ns |     832 B |