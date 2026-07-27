| Description                                      | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|------------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|
| Decrypt · ChaCha20-Poly1305 (CryptoHives-Neon)   | 128B         |     425.0 ns |     2.00 ns |     1.87 ns |         - |
| Decrypt · ChaCha20-Poly1305 (BouncyCastle)       | 128B         |     705.2 ns |     2.11 ns |     1.97 ns |     416 B |
| Decrypt · ChaCha20-Poly1305 (NaCl.Core)          | 128B         |     846.5 ns |     2.67 ns |     2.50 ns |      48 B |
| Decrypt · ChaCha20-Poly1305 (CryptoHives-Scalar) | 128B         |   1,389.4 ns |    11.63 ns |    10.88 ns |         - |
| Decrypt · ChaCha20-Poly1305 (OS)                 | 128B         |   2,300.2 ns |     7.61 ns |     7.12 ns |         - |
|                                                  |              |              |             |             |           |
| Encrypt · ChaCha20-Poly1305 (CryptoHives-Neon)   | 128B         |     356.4 ns |     0.82 ns |     0.76 ns |         - |
| Encrypt · ChaCha20-Poly1305 (BouncyCastle)       | 128B         |     502.2 ns |     0.75 ns |     0.66 ns |     336 B |
| Encrypt · ChaCha20-Poly1305 (NaCl.Core)          | 128B         |     805.3 ns |     3.22 ns |     2.86 ns |      48 B |
| Encrypt · ChaCha20-Poly1305 (CryptoHives-Scalar) | 128B         |   1,357.6 ns |     2.45 ns |     2.29 ns |         - |
| Encrypt · ChaCha20-Poly1305 (OS)                 | 128B         |   1,989.9 ns |    12.28 ns |    11.49 ns |         - |
|                                                  |              |              |             |             |           |
| Decrypt · ChaCha20-Poly1305 (CryptoHives-Neon)   | 1KB          |   2,020.9 ns |     6.88 ns |     6.09 ns |         - |
| Decrypt · ChaCha20-Poly1305 (BouncyCastle)       | 1KB          |   2,420.7 ns |     5.83 ns |     5.17 ns |     416 B |
| Decrypt · ChaCha20-Poly1305 (OS)                 | 1KB          |   3,262.4 ns |    15.54 ns |    14.53 ns |         - |
| Decrypt · ChaCha20-Poly1305 (NaCl.Core)          | 1KB          |   3,733.8 ns |    13.08 ns |    12.23 ns |      72 B |
| Decrypt · ChaCha20-Poly1305 (CryptoHives-Scalar) | 1KB          |   7,026.4 ns |    19.05 ns |    17.82 ns |         - |
|                                                  |              |              |             |             |           |
| Encrypt · ChaCha20-Poly1305 (CryptoHives-Neon)   | 1KB          |   1,957.3 ns |     8.26 ns |     7.73 ns |         - |
| Encrypt · ChaCha20-Poly1305 (BouncyCastle)       | 1KB          |   2,211.2 ns |     1.56 ns |     1.30 ns |     336 B |
| Encrypt · ChaCha20-Poly1305 (OS)                 | 1KB          |   2,948.9 ns |    13.12 ns |    12.27 ns |         - |
| Encrypt · ChaCha20-Poly1305 (NaCl.Core)          | 1KB          |   3,697.7 ns |    17.01 ns |    15.91 ns |      72 B |
| Encrypt · ChaCha20-Poly1305 (CryptoHives-Scalar) | 1KB          |   6,975.7 ns |    27.32 ns |    25.55 ns |         - |
|                                                  |              |              |             |             |           |
| Decrypt · ChaCha20-Poly1305 (OS)                 | 8KB          |  11,167.4 ns |    54.25 ns |    50.75 ns |         - |
| Decrypt · ChaCha20-Poly1305 (CryptoHives-Neon)   | 8KB          |  14,582.9 ns |    35.17 ns |    29.37 ns |         - |
| Decrypt · ChaCha20-Poly1305 (BouncyCastle)       | 8KB          |  15,988.9 ns |    25.88 ns |    24.21 ns |     416 B |
| Decrypt · ChaCha20-Poly1305 (NaCl.Core)          | 8KB          |  26,628.7 ns |   133.00 ns |   124.41 ns |      72 B |
| Decrypt · ChaCha20-Poly1305 (CryptoHives-Scalar) | 8KB          |  50,593.9 ns |   138.70 ns |   129.74 ns |         - |
|                                                  |              |              |             |             |           |
| Encrypt · ChaCha20-Poly1305 (OS)                 | 8KB          |  10,581.6 ns |    23.38 ns |    21.87 ns |         - |
| Encrypt · ChaCha20-Poly1305 (CryptoHives-Neon)   | 8KB          |  14,608.3 ns |    48.14 ns |    45.03 ns |         - |
| Encrypt · ChaCha20-Poly1305 (BouncyCastle)       | 8KB          |  15,879.2 ns |    16.13 ns |    14.30 ns |     336 B |
| Encrypt · ChaCha20-Poly1305 (NaCl.Core)          | 8KB          |  26,646.8 ns |    90.10 ns |    84.28 ns |      72 B |
| Encrypt · ChaCha20-Poly1305 (CryptoHives-Scalar) | 8KB          |  50,622.6 ns |   101.45 ns |    94.90 ns |         - |
|                                                  |              |              |             |             |           |
| Decrypt · ChaCha20-Poly1305 (OS)                 | 128KB        | 153,909.2 ns |   745.59 ns |   697.43 ns |         - |
| Decrypt · ChaCha20-Poly1305 (CryptoHives-Neon)   | 128KB        | 231,425.1 ns | 1,211.98 ns | 1,074.39 ns |         - |
| Decrypt · ChaCha20-Poly1305 (BouncyCastle)       | 128KB        | 248,846.4 ns |   160.19 ns |   149.85 ns |     416 B |
| Decrypt · ChaCha20-Poly1305 (NaCl.Core)          | 128KB        | 421,003.5 ns | 1,673.38 ns | 1,565.28 ns |      72 B |
| Decrypt · ChaCha20-Poly1305 (CryptoHives-Scalar) | 128KB        | 795,712.7 ns | 1,870.25 ns | 1,749.43 ns |         - |
|                                                  |              |              |             |             |           |
| Encrypt · ChaCha20-Poly1305 (OS)                 | 128KB        | 143,340.0 ns |   658.65 ns |   616.10 ns |         - |
| Encrypt · ChaCha20-Poly1305 (CryptoHives-Neon)   | 128KB        | 231,805.9 ns |   613.62 ns |   573.98 ns |         - |
| Encrypt · ChaCha20-Poly1305 (BouncyCastle)       | 128KB        | 251,684.3 ns |   214.28 ns |   200.44 ns |     336 B |
| Encrypt · ChaCha20-Poly1305 (NaCl.Core)          | 128KB        | 419,797.2 ns | 1,127.98 ns | 1,055.11 ns |      72 B |
| Encrypt · ChaCha20-Poly1305 (CryptoHives-Scalar) | 128KB        | 797,812.4 ns | 2,038.92 ns | 1,907.21 ns |         - |