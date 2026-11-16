| Description                                      | TestDataSize | Mean           | Error       | StdDev      | Code Size | Allocated |
|------------------------------------------------- |------------- |---------------:|------------:|------------:|----------:|----------:|
| Decrypt · ChaCha20-Poly1305 (CryptoHives-AVX2)   | 128B         |       484.4 ns |     0.83 ns |     0.77 ns |     310 B |         - |
| Decrypt · ChaCha20-Poly1305 (CryptoHives-SSSE3)  | 128B         |       565.8 ns |     0.44 ns |     0.36 ns |     310 B |         - |
| Decrypt · ChaCha20-Poly1305 (OS)                 | 128B         |       689.6 ns |     2.01 ns |     1.88 ns |   1,859 B |         - |
| Decrypt · ChaCha20-Poly1305 (NaCl.Core)          | 128B         |     1,110.6 ns |     6.72 ns |     5.96 ns |  18,352 B |      48 B |
| Decrypt · ChaCha20-Poly1305 (BouncyCastle)       | 128B         |     1,386.2 ns |     2.34 ns |     2.19 ns |     310 B |     416 B |
| Decrypt · ChaCha20-Poly1305 (CryptoHives-Scalar) | 128B         |     2,463.7 ns |    10.20 ns |     9.54 ns |     310 B |         - |
|                                                  |              |                |             |             |           |           |
| Encrypt · ChaCha20-Poly1305 (CryptoHives-AVX2)   | 128B         |       397.6 ns |     0.43 ns |     0.38 ns |     390 B |         - |
| Encrypt · ChaCha20-Poly1305 (CryptoHives-SSSE3)  | 128B         |       476.3 ns |     0.44 ns |     0.39 ns |     390 B |         - |
| Encrypt · ChaCha20-Poly1305 (OS)                 | 128B         |       685.2 ns |     1.16 ns |     1.09 ns |   1,921 B |         - |
| Encrypt · ChaCha20-Poly1305 (BouncyCastle)       | 128B         |       795.0 ns |     1.72 ns |     1.61 ns |     390 B |     336 B |
| Encrypt · ChaCha20-Poly1305 (NaCl.Core)          | 128B         |     1,017.1 ns |     8.03 ns |     7.51 ns |  17,763 B |      48 B |
| Encrypt · ChaCha20-Poly1305 (CryptoHives-Scalar) | 128B         |     2,361.4 ns |     9.00 ns |     8.42 ns |     390 B |         - |
|                                                  |              |                |             |             |           |           |
| Decrypt · ChaCha20-Poly1305 (CryptoHives-AVX2)   | 1KB          |     2,022.7 ns |     1.40 ns |     1.31 ns |     310 B |         - |
| Decrypt · ChaCha20-Poly1305 (CryptoHives-SSSE3)  | 1KB          |     2,769.9 ns |     2.34 ns |     2.08 ns |     310 B |         - |
| Decrypt · ChaCha20-Poly1305 (BouncyCastle)       | 1KB          |     3,166.6 ns |     7.48 ns |     6.24 ns |     310 B |     416 B |
| Decrypt · ChaCha20-Poly1305 (OS)                 | 1KB          |     3,423.3 ns |     5.60 ns |     5.24 ns |   1,859 B |         - |
| Decrypt · ChaCha20-Poly1305 (NaCl.Core)          | 1KB          |     4,803.7 ns |    17.73 ns |    16.58 ns |  20,633 B |      72 B |
| Decrypt · ChaCha20-Poly1305 (CryptoHives-Scalar) | 1KB          |    13,334.2 ns |    53.08 ns |    49.65 ns |     310 B |         - |
|                                                  |              |                |             |             |           |           |
| Encrypt · ChaCha20-Poly1305 (CryptoHives-AVX2)   | 1KB          |     1,936.7 ns |     1.24 ns |     1.16 ns |     387 B |         - |
| Encrypt · ChaCha20-Poly1305 (BouncyCastle)       | 1KB          |     2,458.8 ns |     6.91 ns |     6.46 ns |     387 B |     336 B |
| Encrypt · ChaCha20-Poly1305 (CryptoHives-SSSE3)  | 1KB          |     2,703.9 ns |     1.70 ns |     1.59 ns |     387 B |         - |
| Encrypt · ChaCha20-Poly1305 (OS)                 | 1KB          |     3,420.1 ns |    10.92 ns |    10.21 ns |   1,924 B |         - |
| Encrypt · ChaCha20-Poly1305 (NaCl.Core)          | 1KB          |     4,690.8 ns |    17.87 ns |    16.71 ns |  18,327 B |      72 B |
| Encrypt · ChaCha20-Poly1305 (CryptoHives-Scalar) | 1KB          |    13,211.3 ns |    45.25 ns |    42.33 ns |     387 B |         - |
|                                                  |              |                |             |             |           |           |
| Decrypt · ChaCha20-Poly1305 (CryptoHives-AVX2)   | 8KB          |    14,372.1 ns |     5.12 ns |     4.79 ns |     310 B |         - |
| Decrypt · ChaCha20-Poly1305 (BouncyCastle)       | 8KB          |    17,279.6 ns |    21.29 ns |    17.78 ns |     310 B |     416 B |
| Decrypt · ChaCha20-Poly1305 (CryptoHives-SSSE3)  | 8KB          |    19,936.4 ns |    21.74 ns |    20.34 ns |     310 B |         - |
| Decrypt · ChaCha20-Poly1305 (OS)                 | 8KB          |    24,817.4 ns |   100.97 ns |    94.45 ns |   2,020 B |         - |
| Decrypt · ChaCha20-Poly1305 (NaCl.Core)          | 8KB          |    34,080.7 ns |    70.78 ns |    59.10 ns |  20,713 B |      72 B |
| Decrypt · ChaCha20-Poly1305 (CryptoHives-Scalar) | 8KB          |   100,168.5 ns |   428.79 ns |   401.09 ns |     310 B |         - |
|                                                  |              |                |             |             |           |           |
| Encrypt · ChaCha20-Poly1305 (CryptoHives-AVX2)   | 8KB          |    14,270.4 ns |     5.69 ns |     5.32 ns |     387 B |         - |
| Encrypt · ChaCha20-Poly1305 (BouncyCastle)       | 8KB          |    15,827.0 ns |    52.63 ns |    49.23 ns |     387 B |     336 B |
| Encrypt · ChaCha20-Poly1305 (CryptoHives-SSSE3)  | 8KB          |    19,909.0 ns |    13.95 ns |    13.05 ns |     387 B |         - |
| Encrypt · ChaCha20-Poly1305 (OS)                 | 8KB          |    24,832.5 ns |    97.96 ns |    91.63 ns |   1,921 B |         - |
| Encrypt · ChaCha20-Poly1305 (NaCl.Core)          | 8KB          |    34,073.6 ns |   129.57 ns |   114.86 ns |  18,352 B |      72 B |
| Encrypt · ChaCha20-Poly1305 (CryptoHives-Scalar) | 8KB          |   100,229.5 ns |   415.13 ns |   388.31 ns |     387 B |         - |
|                                                  |              |                |             |             |           |           |
| Decrypt · ChaCha20-Poly1305 (CryptoHives-AVX2)   | 128KB        |   225,183.0 ns |    51.18 ns |    45.37 ns |     310 B |         - |
| Decrypt · ChaCha20-Poly1305 (BouncyCastle)       | 128KB        |   255,441.3 ns |   299.28 ns |   279.95 ns |     310 B |     416 B |
| Decrypt · ChaCha20-Poly1305 (CryptoHives-SSSE3)  | 128KB        |   314,584.6 ns |   227.43 ns |   189.92 ns |     310 B |         - |
| Decrypt · ChaCha20-Poly1305 (OS)                 | 128KB        |   393,090.1 ns | 1,165.98 ns | 1,090.66 ns |   2,020 B |         - |
| Decrypt · ChaCha20-Poly1305 (NaCl.Core)          | 128KB        |   541,257.4 ns | 1,913.85 ns | 1,598.15 ns |  19,601 B |      72 B |
| Decrypt · ChaCha20-Poly1305 (CryptoHives-Scalar) | 128KB        | 1,593,060.1 ns | 5,428.67 ns | 5,077.98 ns |     310 B |         - |
|                                                  |              |                |             |             |           |           |
| Encrypt · ChaCha20-Poly1305 (CryptoHives-AVX2)   | 128KB        |   225,107.2 ns |    86.99 ns |    72.64 ns |     387 B |         - |
| Encrypt · ChaCha20-Poly1305 (BouncyCastle)       | 128KB        |   248,035.2 ns |   752.56 ns |   703.95 ns |     387 B |     336 B |
| Encrypt · ChaCha20-Poly1305 (CryptoHives-SSSE3)  | 128KB        |   314,369.5 ns |   346.37 ns |   323.99 ns |     387 B |         - |
| Encrypt · ChaCha20-Poly1305 (OS)                 | 128KB        |   394,422.2 ns |   759.63 ns |   710.56 ns |   1,921 B |         - |
| Encrypt · ChaCha20-Poly1305 (NaCl.Core)          | 128KB        |   547,662.2 ns | 4,321.10 ns | 4,041.96 ns |  17,255 B |      72 B |
| Encrypt · ChaCha20-Poly1305 (CryptoHives-Scalar) | 128KB        | 1,594,995.6 ns | 5,339.72 ns | 4,994.78 ns |     387 B |         - |