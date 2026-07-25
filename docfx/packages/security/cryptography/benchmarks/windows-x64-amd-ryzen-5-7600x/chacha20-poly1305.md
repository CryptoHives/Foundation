| Description                                      | TestDataSize | Mean         | Error       | StdDev    | Allocated |
|------------------------------------------------- |------------- |-------------:|------------:|----------:|----------:|
| Decrypt · ChaCha20-Poly1305 (CryptoHives-AVX2)   | 128B         |     338.0 ns |     0.78 ns |   0.69 ns |         - |
| Decrypt · ChaCha20-Poly1305 (OS)                 | 128B         |     345.8 ns |     0.38 ns |   0.34 ns |         - |
| Decrypt · ChaCha20-Poly1305 (CryptoHives-SSSE3)  | 128B         |     398.2 ns |     0.61 ns |   0.54 ns |         - |
| Decrypt · ChaCha20-Poly1305 (NaCl.Core)          | 128B         |     579.4 ns |     1.40 ns |   1.31 ns |      48 B |
| Decrypt · ChaCha20-Poly1305 (BouncyCastle)       | 128B         |     721.9 ns |     0.99 ns |   0.83 ns |     416 B |
| Decrypt · ChaCha20-Poly1305 (CryptoHives-Scalar) | 128B         |     892.7 ns |     0.86 ns |   0.77 ns |         - |
|                                                  |              |              |             |           |           |
| Encrypt · ChaCha20-Poly1305 (CryptoHives-AVX2)   | 128B         |     297.2 ns |     0.36 ns |   0.32 ns |         - |
| Encrypt · ChaCha20-Poly1305 (OS)                 | 128B         |     345.8 ns |     0.65 ns |   0.58 ns |         - |
| Encrypt · ChaCha20-Poly1305 (CryptoHives-SSSE3)  | 128B         |     354.0 ns |     0.53 ns |   0.44 ns |         - |
| Encrypt · ChaCha20-Poly1305 (BouncyCastle)       | 128B         |     424.5 ns |     0.62 ns |   0.52 ns |     336 B |
| Encrypt · ChaCha20-Poly1305 (NaCl.Core)          | 128B         |     541.3 ns |     1.34 ns |   1.19 ns |      48 B |
| Encrypt · ChaCha20-Poly1305 (CryptoHives-Scalar) | 128B         |     849.0 ns |     2.07 ns |   1.83 ns |         - |
|                                                  |              |              |             |           |           |
| Decrypt · ChaCha20-Poly1305 (CryptoHives-AVX2)   | 1KB          |   1,265.7 ns |     1.06 ns |   0.88 ns |         - |
| Decrypt · ChaCha20-Poly1305 (CryptoHives-SSSE3)  | 1KB          |   1,720.7 ns |     1.34 ns |   1.12 ns |         - |
| Decrypt · ChaCha20-Poly1305 (BouncyCastle)       | 1KB          |   1,721.4 ns |     3.07 ns |   2.87 ns |     416 B |
| Decrypt · ChaCha20-Poly1305 (OS)                 | 1KB          |   1,751.1 ns |     2.92 ns |   2.44 ns |         - |
| Decrypt · ChaCha20-Poly1305 (NaCl.Core)          | 1KB          |   2,566.5 ns |     3.86 ns |   3.42 ns |      72 B |
| Decrypt · ChaCha20-Poly1305 (CryptoHives-Scalar) | 1KB          |   4,561.5 ns |     5.00 ns |   4.43 ns |         - |
|                                                  |              |              |             |           |           |
| Encrypt · ChaCha20-Poly1305 (CryptoHives-AVX2)   | 1KB          |   1,216.8 ns |     2.65 ns |   2.35 ns |         - |
| Encrypt · ChaCha20-Poly1305 (BouncyCastle)       | 1KB          |   1,424.8 ns |     3.09 ns |   2.89 ns |     336 B |
| Encrypt · ChaCha20-Poly1305 (CryptoHives-SSSE3)  | 1KB          |   1,672.3 ns |     2.94 ns |   2.61 ns |         - |
| Encrypt · ChaCha20-Poly1305 (OS)                 | 1KB          |   1,749.5 ns |     1.24 ns |   1.10 ns |         - |
| Encrypt · ChaCha20-Poly1305 (NaCl.Core)          | 1KB          |   2,514.2 ns |     4.34 ns |   3.63 ns |      72 B |
| Encrypt · ChaCha20-Poly1305 (CryptoHives-Scalar) | 1KB          |   4,499.4 ns |     9.28 ns |   8.22 ns |         - |
|                                                  |              |              |             |           |           |
| Decrypt · ChaCha20-Poly1305 (CryptoHives-AVX2)   | 8KB          |   8,742.8 ns |    15.60 ns |  14.59 ns |         - |
| Decrypt · ChaCha20-Poly1305 (BouncyCastle)       | 8KB          |   9,643.1 ns |    26.63 ns |  22.24 ns |     416 B |
| Decrypt · ChaCha20-Poly1305 (CryptoHives-SSSE3)  | 8KB          |  12,360.9 ns |    12.34 ns |  10.31 ns |         - |
| Decrypt · ChaCha20-Poly1305 (OS)                 | 8KB          |  13,030.5 ns |    80.19 ns |  66.96 ns |         - |
| Decrypt · ChaCha20-Poly1305 (NaCl.Core)          | 8KB          |  18,375.1 ns |    47.47 ns |  44.40 ns |      72 B |
| Decrypt · ChaCha20-Poly1305 (CryptoHives-Scalar) | 8KB          |  33,889.7 ns |    49.10 ns |  43.53 ns |         - |
|                                                  |              |              |             |           |           |
| Encrypt · ChaCha20-Poly1305 (CryptoHives-AVX2)   | 8KB          |   8,697.3 ns |     8.99 ns |   7.02 ns |         - |
| Encrypt · ChaCha20-Poly1305 (BouncyCastle)       | 8KB          |   9,455.2 ns |    25.22 ns |  23.59 ns |     336 B |
| Encrypt · ChaCha20-Poly1305 (CryptoHives-SSSE3)  | 8KB          |  12,336.5 ns |    17.77 ns |  16.62 ns |         - |
| Encrypt · ChaCha20-Poly1305 (OS)                 | 8KB          |  12,961.4 ns |     8.55 ns |   7.14 ns |         - |
| Encrypt · ChaCha20-Poly1305 (NaCl.Core)          | 8KB          |  18,275.4 ns |    49.21 ns |  43.62 ns |      72 B |
| Encrypt · ChaCha20-Poly1305 (CryptoHives-Scalar) | 8KB          |  33,786.7 ns |    34.05 ns |  30.18 ns |         - |
|                                                  |              |              |             |           |           |
| Decrypt · ChaCha20-Poly1305 (CryptoHives-AVX2)   | 128KB        | 136,820.5 ns |   231.75 ns | 205.44 ns |         - |
| Decrypt · ChaCha20-Poly1305 (BouncyCastle)       | 128KB        | 148,013.6 ns |   216.92 ns | 181.14 ns |     416 B |
| Decrypt · ChaCha20-Poly1305 (CryptoHives-SSSE3)  | 128KB        | 194,703.5 ns |   330.69 ns | 293.14 ns |         - |
| Decrypt · ChaCha20-Poly1305 (OS)                 | 128KB        | 205,388.9 ns |   164.56 ns | 153.93 ns |         - |
| Decrypt · ChaCha20-Poly1305 (NaCl.Core)          | 128KB        | 295,118.7 ns |   742.13 ns | 694.19 ns |      72 B |
| Decrypt · ChaCha20-Poly1305 (CryptoHives-Scalar) | 128KB        | 536,341.7 ns |   660.56 ns | 617.89 ns |         - |
|                                                  |              |              |             |           |           |
| Encrypt · ChaCha20-Poly1305 (CryptoHives-AVX2)   | 128KB        | 136,528.2 ns |   348.46 ns | 325.95 ns |         - |
| Encrypt · ChaCha20-Poly1305 (BouncyCastle)       | 128KB        | 149,583.8 ns |   184.12 ns | 143.75 ns |     336 B |
| Encrypt · ChaCha20-Poly1305 (CryptoHives-SSSE3)  | 128KB        | 194,357.2 ns |   376.34 ns | 333.62 ns |         - |
| Encrypt · ChaCha20-Poly1305 (OS)                 | 128KB        | 205,550.4 ns |   412.50 ns | 385.85 ns |         - |
| Encrypt · ChaCha20-Poly1305 (NaCl.Core)          | 128KB        | 290,186.7 ns | 1,190.92 ns | 994.47 ns |      72 B |
| Encrypt · ChaCha20-Poly1305 (CryptoHives-Scalar) | 128KB        | 536,618.9 ns |   359.05 ns | 280.32 ns |         - |