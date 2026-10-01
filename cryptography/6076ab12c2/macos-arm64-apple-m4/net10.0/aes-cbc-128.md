| Description                                 | TestDataSize | Mean          | Error        | StdDev       | Allocated |
|-------------------------------------------- |------------- |--------------:|-------------:|-------------:|----------:|
| Decrypt · AES-128-CBC (CryptoHives-ARM-AES) | 128B         |      22.85 ns |     0.012 ns |     0.011 ns |         - |
| Decrypt · AES-128-CBC (OS)                  | 128B         |     191.07 ns |     0.894 ns |     0.836 ns |      72 B |
| Decrypt · AES-128-CBC (CryptoHives-Scalar)  | 128B         |     378.23 ns |     0.118 ns |     0.111 ns |         - |
| Decrypt · AES-128-CBC (BouncyCastle)        | 128B         |     601.82 ns |     0.419 ns |     0.392 ns |     832 B |
|                                             |              |               |              |              |           |
| Encrypt · AES-128-CBC (CryptoHives-ARM-AES) | 128B         |      41.41 ns |     0.318 ns |     0.265 ns |         - |
| Encrypt · AES-128-CBC (OS)                  | 128B         |     198.54 ns |     0.473 ns |     0.420 ns |      72 B |
| Encrypt · AES-128-CBC (CryptoHives-Scalar)  | 128B         |     427.25 ns |     0.929 ns |     0.725 ns |         - |
| Encrypt · AES-128-CBC (BouncyCastle)        | 128B         |     557.22 ns |     0.508 ns |     0.450 ns |     832 B |
|                                             |              |               |              |              |           |
| Decrypt · AES-128-CBC (CryptoHives-ARM-AES) | 1KB          |      88.42 ns |     0.292 ns |     0.259 ns |         - |
| Decrypt · AES-128-CBC (OS)                  | 1KB          |     232.92 ns |     1.110 ns |     0.984 ns |      72 B |
| Decrypt · AES-128-CBC (CryptoHives-Scalar)  | 1KB          |   2,651.71 ns |     3.406 ns |     2.659 ns |         - |
| Decrypt · AES-128-CBC (BouncyCastle)        | 1KB          |   3,367.52 ns |     3.337 ns |     3.121 ns |     832 B |
|                                             |              |               |              |              |           |
| Encrypt · AES-128-CBC (CryptoHives-ARM-AES) | 1KB          |     378.84 ns |     0.412 ns |     0.365 ns |         - |
| Encrypt · AES-128-CBC (OS)                  | 1KB          |     552.76 ns |     3.024 ns |     2.681 ns |      72 B |
| Encrypt · AES-128-CBC (CryptoHives-Scalar)  | 1KB          |   3,068.97 ns |     2.547 ns |     2.383 ns |         - |
| Encrypt · AES-128-CBC (BouncyCastle)        | 1KB          |   3,259.68 ns |     4.093 ns |     3.195 ns |     832 B |
|                                             |              |               |              |              |           |
| Decrypt · AES-128-CBC (OS)                  | 8KB          |     571.68 ns |     2.477 ns |     2.196 ns |      72 B |
| Decrypt · AES-128-CBC (CryptoHives-ARM-AES) | 8KB          |     619.86 ns |     2.550 ns |     2.261 ns |         - |
| Decrypt · AES-128-CBC (CryptoHives-Scalar)  | 8KB          |  20,849.85 ns |     6.322 ns |     5.913 ns |         - |
| Decrypt · AES-128-CBC (BouncyCastle)        | 8KB          |  25,337.84 ns |    63.501 ns |    59.398 ns |     832 B |
|                                             |              |               |              |              |           |
| Encrypt · AES-128-CBC (OS)                  | 8KB          |   3,267.25 ns |     1.899 ns |     1.684 ns |      72 B |
| Encrypt · AES-128-CBC (CryptoHives-ARM-AES) | 8KB          |   3,430.62 ns |     4.712 ns |     4.177 ns |         - |
| Encrypt · AES-128-CBC (CryptoHives-Scalar)  | 8KB          |  24,089.03 ns |    19.809 ns |    16.542 ns |         - |
| Encrypt · AES-128-CBC (BouncyCastle)        | 8KB          |  24,746.97 ns |     9.472 ns |     8.396 ns |     832 B |
|                                             |              |               |              |              |           |
| Decrypt · AES-128-CBC (OS)                  | 128KB        |   6,717.90 ns |   128.750 ns |   107.512 ns |      72 B |
| Decrypt · AES-128-CBC (CryptoHives-ARM-AES) | 128KB        |   9,726.06 ns |    24.942 ns |    23.331 ns |         - |
| Decrypt · AES-128-CBC (CryptoHives-Scalar)  | 128KB        | 333,780.48 ns |   424.561 ns |   376.362 ns |         - |
| Decrypt · AES-128-CBC (BouncyCastle)        | 128KB        | 401,873.86 ns | 1,638.280 ns | 1,452.293 ns |     832 B |
|                                             |              |               |              |              |           |
| Encrypt · AES-128-CBC (OS)                  | 128KB        |  50,542.69 ns |    45.778 ns |    42.821 ns |      73 B |
| Encrypt · AES-128-CBC (CryptoHives-ARM-AES) | 128KB        |  55,737.00 ns |    11.456 ns |    10.155 ns |         - |
| Encrypt · AES-128-CBC (CryptoHives-Scalar)  | 128KB        | 385,083.03 ns |   489.149 ns |   457.551 ns |         - |
| Encrypt · AES-128-CBC (BouncyCastle)        | 128KB        | 394,997.06 ns |   123.481 ns |   115.504 ns |     832 B |