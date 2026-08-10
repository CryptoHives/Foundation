| Description                                 | TestDataSize | Mean          | Error        | StdDev     | Allocated |
|-------------------------------------------- |------------- |--------------:|-------------:|-----------:|----------:|
| Decrypt · AES-128-CBC (CryptoHives-ARM-AES) | 128B         |      22.59 ns |     0.039 ns |   0.037 ns |         - |
| Decrypt · AES-128-CBC (OS)                  | 128B         |     197.10 ns |     0.822 ns |   0.729 ns |      72 B |
| Decrypt · AES-128-CBC (CryptoHives-Scalar)  | 128B         |     385.61 ns |     0.187 ns |   0.175 ns |         - |
| Decrypt · AES-128-CBC (BouncyCastle)        | 128B         |     615.04 ns |     0.511 ns |   0.478 ns |     832 B |
|                                             |              |               |              |            |           |
| Encrypt · AES-128-CBC (CryptoHives-ARM-AES) | 128B         |     136.85 ns |     0.727 ns |   0.680 ns |         - |
| Encrypt · AES-128-CBC (OS)                  | 128B         |     202.67 ns |     0.612 ns |   0.542 ns |      72 B |
| Encrypt · AES-128-CBC (CryptoHives-Scalar)  | 128B         |     436.00 ns |     0.121 ns |   0.107 ns |         - |
| Encrypt · AES-128-CBC (BouncyCastle)        | 128B         |     574.91 ns |     0.358 ns |   0.335 ns |     832 B |
|                                             |              |               |              |            |           |
| Decrypt · AES-128-CBC (CryptoHives-ARM-AES) | 1KB          |      88.84 ns |     0.117 ns |   0.098 ns |         - |
| Decrypt · AES-128-CBC (OS)                  | 1KB          |     234.61 ns |     0.825 ns |   0.772 ns |      72 B |
| Decrypt · AES-128-CBC (CryptoHives-Scalar)  | 1KB          |   2,705.18 ns |     0.601 ns |   0.533 ns |         - |
| Decrypt · AES-128-CBC (BouncyCastle)        | 1KB          |   3,382.96 ns |     4.409 ns |   4.124 ns |     832 B |
|                                             |              |               |              |            |           |
| Encrypt · AES-128-CBC (OS)                  | 1KB          |     557.71 ns |     2.487 ns |   2.326 ns |      72 B |
| Encrypt · AES-128-CBC (CryptoHives-ARM-AES) | 1KB          |     984.41 ns |     3.148 ns |   2.945 ns |         - |
| Encrypt · AES-128-CBC (CryptoHives-Scalar)  | 1KB          |   3,133.08 ns |     0.250 ns |   0.195 ns |         - |
| Encrypt · AES-128-CBC (BouncyCastle)        | 1KB          |   3,271.53 ns |     0.931 ns |   0.826 ns |     832 B |
|                                             |              |               |              |            |           |
| Decrypt · AES-128-CBC (OS)                  | 8KB          |     591.12 ns |     3.471 ns |   3.247 ns |      72 B |
| Decrypt · AES-128-CBC (CryptoHives-ARM-AES) | 8KB          |     627.20 ns |     1.189 ns |   1.112 ns |         - |
| Decrypt · AES-128-CBC (CryptoHives-Scalar)  | 8KB          |  21,309.84 ns |    33.386 ns |  29.596 ns |         - |
| Decrypt · AES-128-CBC (BouncyCastle)        | 8KB          |  25,321.70 ns |    43.447 ns |  40.641 ns |     832 B |
|                                             |              |               |              |            |           |
| Encrypt · AES-128-CBC (OS)                  | 8KB          |   3,284.32 ns |     8.210 ns |   7.679 ns |      72 B |
| Encrypt · AES-128-CBC (CryptoHives-ARM-AES) | 8KB          |   9,902.54 ns |    49.818 ns |  46.600 ns |         - |
| Encrypt · AES-128-CBC (BouncyCastle)        | 8KB          |  24,664.10 ns |     3.629 ns |   3.217 ns |     832 B |
| Encrypt · AES-128-CBC (CryptoHives-Scalar)  | 8KB          |  24,696.69 ns |     3.173 ns |   2.968 ns |         - |
|                                             |              |               |              |            |           |
| Decrypt · AES-128-CBC (OS)                  | 128KB        |   6,686.33 ns |    60.404 ns |  53.546 ns |      72 B |
| Decrypt · AES-128-CBC (CryptoHives-ARM-AES) | 128KB        |   9,844.99 ns |     4.951 ns |   4.631 ns |         - |
| Decrypt · AES-128-CBC (CryptoHives-Scalar)  | 128KB        | 341,916.59 ns |    89.519 ns |  83.736 ns |         - |
| Decrypt · AES-128-CBC (BouncyCastle)        | 128KB        | 402,781.64 ns | 1,109.311 ns | 983.375 ns |     832 B |
|                                             |              |               |              |            |           |
| Encrypt · AES-128-CBC (OS)                  | 128KB        |  50,596.49 ns |    26.602 ns |  23.582 ns |      72 B |
| Encrypt · AES-128-CBC (CryptoHives-ARM-AES) | 128KB        | 123,352.94 ns |   940.343 ns | 879.597 ns |         - |
| Encrypt · AES-128-CBC (BouncyCastle)        | 128KB        | 394,324.31 ns |    81.897 ns |  68.387 ns |     832 B |
| Encrypt · AES-128-CBC (CryptoHives-Scalar)  | 128KB        | 394,511.75 ns |   103.156 ns |  96.492 ns |         - |