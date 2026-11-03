| Description                                 | TestDataSize | Mean          | Error        | StdDev       | Allocated |
|-------------------------------------------- |------------- |--------------:|-------------:|-------------:|----------:|
| Decrypt · AES-128-CBC (CryptoHives-ARM-AES) | 128B         |      23.19 ns |     0.121 ns |     0.107 ns |         - |
| Decrypt · AES-128-CBC (OS)                  | 128B         |     190.89 ns |     0.881 ns |     0.824 ns |      72 B |
| Decrypt · AES-128-CBC (CryptoHives-Scalar)  | 128B         |     341.88 ns |     0.477 ns |     0.446 ns |         - |
| Decrypt · AES-128-CBC (BouncyCastle)        | 128B         |     603.71 ns |     0.443 ns |     0.370 ns |     832 B |
|                                             |              |               |              |              |           |
| Encrypt · AES-128-CBC (CryptoHives-ARM-AES) | 128B         |      37.79 ns |     0.058 ns |     0.054 ns |         - |
| Encrypt · AES-128-CBC (OS)                  | 128B         |     200.50 ns |     0.747 ns |     0.699 ns |      72 B |
| Encrypt · AES-128-CBC (CryptoHives-Scalar)  | 128B         |     426.39 ns |     0.516 ns |     0.430 ns |         - |
| Encrypt · AES-128-CBC (BouncyCastle)        | 128B         |     556.14 ns |     0.722 ns |     0.675 ns |     832 B |
|                                             |              |               |              |              |           |
| Decrypt · AES-128-CBC (CryptoHives-ARM-AES) | 1KB          |      89.47 ns |     0.150 ns |     0.133 ns |         - |
| Decrypt · AES-128-CBC (OS)                  | 1KB          |     237.49 ns |     2.065 ns |     1.931 ns |      72 B |
| Decrypt · AES-128-CBC (CryptoHives-Scalar)  | 1KB          |   2,362.75 ns |     4.159 ns |     3.890 ns |         - |
| Decrypt · AES-128-CBC (BouncyCastle)        | 1KB          |   3,372.42 ns |     5.553 ns |     4.637 ns |     832 B |
|                                             |              |               |              |              |           |
| Encrypt · AES-128-CBC (CryptoHives-ARM-AES) | 1KB          |     344.21 ns |     1.636 ns |     1.450 ns |         - |
| Encrypt · AES-128-CBC (OS)                  | 1KB          |     562.31 ns |     3.316 ns |     3.101 ns |      72 B |
| Encrypt · AES-128-CBC (CryptoHives-Scalar)  | 1KB          |   3,077.81 ns |     4.589 ns |     4.068 ns |         - |
| Encrypt · AES-128-CBC (BouncyCastle)        | 1KB          |   3,248.04 ns |     3.773 ns |     3.151 ns |     832 B |
|                                             |              |               |              |              |           |
| Decrypt · AES-128-CBC (OS)                  | 8KB          |     581.98 ns |     3.141 ns |     2.938 ns |      72 B |
| Decrypt · AES-128-CBC (CryptoHives-ARM-AES) | 8KB          |     625.02 ns |     2.159 ns |     2.019 ns |         - |
| Decrypt · AES-128-CBC (CryptoHives-Scalar)  | 8KB          |  18,619.08 ns |    23.461 ns |    20.797 ns |         - |
| Decrypt · AES-128-CBC (BouncyCastle)        | 8KB          |  25,290.83 ns |    71.274 ns |    59.517 ns |     832 B |
|                                             |              |               |              |              |           |
| Encrypt · AES-128-CBC (CryptoHives-ARM-AES) | 8KB          |   3,098.73 ns |    11.668 ns |    10.343 ns |         - |
| Encrypt · AES-128-CBC (OS)                  | 8KB          |   3,302.72 ns |    13.505 ns |    11.972 ns |      72 B |
| Encrypt · AES-128-CBC (CryptoHives-Scalar)  | 8KB          |  24,263.61 ns |    38.255 ns |    33.912 ns |         - |
| Encrypt · AES-128-CBC (BouncyCastle)        | 8KB          |  24,733.07 ns |    33.308 ns |    31.156 ns |     832 B |
|                                             |              |               |              |              |           |
| Decrypt · AES-128-CBC (OS)                  | 128KB        |   6,615.52 ns |    20.698 ns |    19.361 ns |      72 B |
| Decrypt · AES-128-CBC (CryptoHives-ARM-AES) | 128KB        |   9,757.76 ns |    18.369 ns |    15.339 ns |         - |
| Decrypt · AES-128-CBC (CryptoHives-Scalar)  | 128KB        | 297,637.38 ns |    93.068 ns |    82.503 ns |         - |
| Decrypt · AES-128-CBC (BouncyCastle)        | 128KB        | 402,523.65 ns | 1,544.157 ns | 1,444.405 ns |     832 B |
|                                             |              |               |              |              |           |
| Encrypt · AES-128-CBC (CryptoHives-ARM-AES) | 128KB        |  50,811.37 ns |   169.591 ns |   150.338 ns |         - |
| Encrypt · AES-128-CBC (OS)                  | 128KB        |  50,904.16 ns |   264.573 ns |   247.482 ns |      72 B |
| Encrypt · AES-128-CBC (CryptoHives-Scalar)  | 128KB        | 386,709.62 ns |   614.622 ns |   574.918 ns |         - |
| Encrypt · AES-128-CBC (BouncyCastle)        | 128KB        | 394,566.04 ns |   553.204 ns |   517.468 ns |     832 B |