| Description                                      | TestDataSize | Mean           | Error       | StdDev      | Code Size | Allocated |
|------------------------------------------------- |------------- |---------------:|------------:|------------:|----------:|----------:|
| Decrypt · ChaCha20-Poly1305 (CryptoHives-AVX2)   | 128B         |       470.6 ns |     0.47 ns |     0.44 ns |     310 B |         - |
| Decrypt · ChaCha20-Poly1305 (CryptoHives-SSSE3)  | 128B         |       548.0 ns |     0.38 ns |     0.33 ns |     310 B |         - |
| Decrypt · ChaCha20-Poly1305 (OS)                 | 128B         |       690.7 ns |     2.27 ns |     2.01 ns |   1,987 B |         - |
| Decrypt · ChaCha20-Poly1305 (NaCl.Core)          | 128B         |     1,121.3 ns |     1.77 ns |     1.57 ns |  32,320 B |      48 B |
| Decrypt · ChaCha20-Poly1305 (BouncyCastle)       | 128B         |     1,374.9 ns |     2.73 ns |     2.55 ns |     310 B |     416 B |
| Decrypt · ChaCha20-Poly1305 (CryptoHives-Scalar) | 128B         |     2,424.9 ns |     7.12 ns |     6.66 ns |     310 B |         - |
|                                                  |              |                |             |             |           |           |
| Encrypt · ChaCha20-Poly1305 (CryptoHives-AVX2)   | 128B         |       375.2 ns |     0.26 ns |     0.24 ns |     390 B |         - |
| Encrypt · ChaCha20-Poly1305 (CryptoHives-SSSE3)  | 128B         |       457.2 ns |     0.10 ns |     0.09 ns |     390 B |         - |
| Encrypt · ChaCha20-Poly1305 (OS)                 | 128B         |       691.1 ns |     1.75 ns |     1.64 ns |     698 B |         - |
| Encrypt · ChaCha20-Poly1305 (BouncyCastle)       | 128B         |       800.0 ns |     0.92 ns |     0.77 ns |     390 B |     336 B |
| Encrypt · ChaCha20-Poly1305 (NaCl.Core)          | 128B         |       982.5 ns |     3.63 ns |     3.22 ns |  30,001 B |      48 B |
| Encrypt · ChaCha20-Poly1305 (CryptoHives-Scalar) | 128B         |     2,340.1 ns |     9.22 ns |     8.63 ns |     390 B |         - |
|                                                  |              |                |             |             |           |           |
| Decrypt · ChaCha20-Poly1305 (CryptoHives-AVX2)   | 1KB          |     1,864.7 ns |     0.70 ns |     0.66 ns |     310 B |         - |
| Decrypt · ChaCha20-Poly1305 (CryptoHives-SSSE3)  | 1KB          |     2,615.0 ns |     1.61 ns |     1.51 ns |     310 B |         - |
| Decrypt · ChaCha20-Poly1305 (BouncyCastle)       | 1KB          |     3,073.2 ns |     7.06 ns |     6.26 ns |     310 B |     416 B |
| Decrypt · ChaCha20-Poly1305 (OS)                 | 1KB          |     3,424.8 ns |     7.79 ns |     7.29 ns |   1,987 B |         - |
| Decrypt · ChaCha20-Poly1305 (NaCl.Core)          | 1KB          |     4,611.9 ns |    17.19 ns |    16.08 ns |  32,140 B |      72 B |
| Decrypt · ChaCha20-Poly1305 (CryptoHives-Scalar) | 1KB          |    13,080.7 ns |    55.48 ns |    51.89 ns |     310 B |         - |
|                                                  |              |                |             |             |           |           |
| Encrypt · ChaCha20-Poly1305 (CryptoHives-AVX2)   | 1KB          |     1,779.5 ns |     0.92 ns |     0.77 ns |     390 B |         - |
| Encrypt · ChaCha20-Poly1305 (BouncyCastle)       | 1KB          |     2,430.7 ns |     3.52 ns |     3.12 ns |     390 B |     336 B |
| Encrypt · ChaCha20-Poly1305 (CryptoHives-SSSE3)  | 1KB          |     2,553.8 ns |     0.98 ns |     0.92 ns |     390 B |         - |
| Encrypt · ChaCha20-Poly1305 (OS)                 | 1KB          |     3,426.0 ns |     6.06 ns |     5.67 ns |     698 B |         - |
| Encrypt · ChaCha20-Poly1305 (NaCl.Core)          | 1KB          |     4,526.3 ns |    12.54 ns |    11.73 ns |  30,397 B |      72 B |
| Encrypt · ChaCha20-Poly1305 (CryptoHives-Scalar) | 1KB          |    12,991.3 ns |    47.78 ns |    44.69 ns |     390 B |         - |
|                                                  |              |                |             |             |           |           |
| Decrypt · ChaCha20-Poly1305 (CryptoHives-AVX2)   | 8KB          |    13,195.2 ns |     2.41 ns |     2.01 ns |     310 B |         - |
| Decrypt · ChaCha20-Poly1305 (BouncyCastle)       | 8KB          |    17,110.7 ns |    36.65 ns |    34.28 ns |     310 B |     416 B |
| Decrypt · ChaCha20-Poly1305 (CryptoHives-SSSE3)  | 8KB          |    18,732.9 ns |     7.37 ns |     6.90 ns |     310 B |         - |
| Decrypt · ChaCha20-Poly1305 (OS)                 | 8KB          |    24,902.1 ns |    43.06 ns |    40.28 ns |   1,987 B |         - |
| Decrypt · ChaCha20-Poly1305 (NaCl.Core)          | 8KB          |    32,917.9 ns |    71.18 ns |    63.10 ns |  28,062 B |      72 B |
| Decrypt · ChaCha20-Poly1305 (CryptoHives-Scalar) | 8KB          |    98,566.2 ns |   210.68 ns |   197.07 ns |     310 B |         - |
|                                                  |              |                |             |             |           |           |
| Encrypt · ChaCha20-Poly1305 (CryptoHives-AVX2)   | 8KB          |    13,076.3 ns |     2.89 ns |     2.56 ns |     390 B |         - |
| Encrypt · ChaCha20-Poly1305 (BouncyCastle)       | 8KB          |    15,774.5 ns |    17.68 ns |    15.67 ns |     390 B |     336 B |
| Encrypt · ChaCha20-Poly1305 (CryptoHives-SSSE3)  | 8KB          |    18,682.8 ns |    17.31 ns |    16.19 ns |     390 B |         - |
| Encrypt · ChaCha20-Poly1305 (OS)                 | 8KB          |    24,879.5 ns |    87.25 ns |    81.62 ns |     698 B |         - |
| Encrypt · ChaCha20-Poly1305 (NaCl.Core)          | 8KB          |    32,886.2 ns |    90.33 ns |    84.49 ns |  30,644 B |      72 B |
| Encrypt · ChaCha20-Poly1305 (CryptoHives-Scalar) | 8KB          |    98,544.4 ns |   193.26 ns |   180.77 ns |     390 B |         - |
|                                                  |              |                |             |             |           |           |
| Decrypt · ChaCha20-Poly1305 (CryptoHives-AVX2)   | 128KB        |   206,232.5 ns |    71.70 ns |    67.07 ns |     310 B |         - |
| Decrypt · ChaCha20-Poly1305 (BouncyCastle)       | 128KB        |   258,268.6 ns | 1,644.55 ns | 1,373.28 ns |     310 B |     416 B |
| Decrypt · ChaCha20-Poly1305 (CryptoHives-SSSE3)  | 128KB        |   295,320.1 ns |    99.37 ns |    92.95 ns |     310 B |         - |
| Decrypt · ChaCha20-Poly1305 (OS)                 | 128KB        |   393,841.5 ns | 1,118.33 ns | 1,046.09 ns |   1,987 B |         - |
| Decrypt · ChaCha20-Poly1305 (NaCl.Core)          | 128KB        |   529,028.4 ns | 2,900.09 ns | 2,570.85 ns |  32,531 B |      72 B |
| Decrypt · ChaCha20-Poly1305 (CryptoHives-Scalar) | 128KB        | 1,569,890.7 ns | 5,603.26 ns | 5,241.30 ns |     310 B |         - |
|                                                  |              |                |             |             |           |           |
| Encrypt · ChaCha20-Poly1305 (CryptoHives-AVX2)   | 128KB        |   205,996.1 ns |    51.92 ns |    48.56 ns |     390 B |         - |
| Encrypt · ChaCha20-Poly1305 (BouncyCastle)       | 128KB        |   242,649.8 ns |   148.43 ns |   138.84 ns |     390 B |     336 B |
| Encrypt · ChaCha20-Poly1305 (CryptoHives-SSSE3)  | 128KB        |   295,361.8 ns |    63.01 ns |    49.20 ns |     390 B |         - |
| Encrypt · ChaCha20-Poly1305 (OS)                 | 128KB        |   394,685.4 ns |   714.11 ns |   667.97 ns |     698 B |         - |
| Encrypt · ChaCha20-Poly1305 (NaCl.Core)          | 128KB        |   520,105.2 ns | 4,656.19 ns | 4,127.59 ns |  24,791 B |      72 B |
| Encrypt · ChaCha20-Poly1305 (CryptoHives-Scalar) | 128KB        | 1,570,114.4 ns | 3,385.95 ns | 3,167.22 ns |     390 B |         - |