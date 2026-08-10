| Description                                      | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|------------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|
| Decrypt · ChaCha20-Poly1305 (CryptoHives-AVX2)   | 128B         |     340.1 ns |     5.76 ns |     5.39 ns |         - |
| Decrypt · ChaCha20-Poly1305 (OS)                 | 128B         |     355.0 ns |     2.40 ns |     2.13 ns |         - |
| Decrypt · ChaCha20-Poly1305 (CryptoHives-SSSE3)  | 128B         |     393.1 ns |     4.04 ns |     3.58 ns |         - |
| Decrypt · ChaCha20-Poly1305 (NaCl.Core)          | 128B         |     590.9 ns |     2.55 ns |     2.26 ns |      48 B |
| Decrypt · ChaCha20-Poly1305 (BouncyCastle)       | 128B         |     737.7 ns |     4.73 ns |     4.43 ns |     416 B |
| Decrypt · ChaCha20-Poly1305 (CryptoHives-Scalar) | 128B         |     914.9 ns |    14.82 ns |    13.87 ns |         - |
|                                                  |              |              |             |             |           |
| Encrypt · ChaCha20-Poly1305 (CryptoHives-AVX2)   | 128B         |     291.5 ns |     2.18 ns |     1.93 ns |         - |
| Encrypt · ChaCha20-Poly1305 (CryptoHives-SSSE3)  | 128B         |     349.9 ns |     6.27 ns |     5.87 ns |         - |
| Encrypt · ChaCha20-Poly1305 (OS)                 | 128B         |     362.0 ns |     5.92 ns |     5.53 ns |         - |
| Encrypt · ChaCha20-Poly1305 (BouncyCastle)       | 128B         |     427.2 ns |     6.07 ns |     5.38 ns |     336 B |
| Encrypt · ChaCha20-Poly1305 (NaCl.Core)          | 128B         |     544.8 ns |     4.69 ns |     3.92 ns |      48 B |
| Encrypt · ChaCha20-Poly1305 (CryptoHives-Scalar) | 128B         |     859.3 ns |    13.70 ns |    12.82 ns |         - |
|                                                  |              |              |             |             |           |
| Decrypt · ChaCha20-Poly1305 (CryptoHives-AVX2)   | 1KB          |   1,290.6 ns |    11.75 ns |    10.99 ns |         - |
| Decrypt · ChaCha20-Poly1305 (CryptoHives-SSSE3)  | 1KB          |   1,738.1 ns |     3.36 ns |     3.14 ns |         - |
| Decrypt · ChaCha20-Poly1305 (BouncyCastle)       | 1KB          |   1,755.2 ns |    12.97 ns |    12.14 ns |     416 B |
| Decrypt · ChaCha20-Poly1305 (OS)                 | 1KB          |   1,793.7 ns |     6.40 ns |     5.99 ns |         - |
| Decrypt · ChaCha20-Poly1305 (NaCl.Core)          | 1KB          |   2,656.4 ns |    15.41 ns |    14.41 ns |      72 B |
| Decrypt · ChaCha20-Poly1305 (CryptoHives-Scalar) | 1KB          |   4,566.8 ns |    27.65 ns |    24.51 ns |         - |
|                                                  |              |              |             |             |           |
| Encrypt · ChaCha20-Poly1305 (CryptoHives-AVX2)   | 1KB          |   1,236.2 ns |     7.77 ns |     6.89 ns |         - |
| Encrypt · ChaCha20-Poly1305 (BouncyCastle)       | 1KB          |   1,464.5 ns |    22.00 ns |    20.58 ns |     336 B |
| Encrypt · ChaCha20-Poly1305 (CryptoHives-SSSE3)  | 1KB          |   1,739.2 ns |    34.03 ns |    34.95 ns |         - |
| Encrypt · ChaCha20-Poly1305 (OS)                 | 1KB          |   1,806.1 ns |    19.25 ns |    17.07 ns |         - |
| Encrypt · ChaCha20-Poly1305 (NaCl.Core)          | 1KB          |   2,618.3 ns |    48.71 ns |    45.57 ns |      72 B |
| Encrypt · ChaCha20-Poly1305 (CryptoHives-Scalar) | 1KB          |   4,581.0 ns |    87.72 ns |    93.86 ns |         - |
|                                                  |              |              |             |             |           |
| Decrypt · ChaCha20-Poly1305 (CryptoHives-AVX2)   | 8KB          |   8,800.9 ns |    36.11 ns |    32.01 ns |         - |
| Decrypt · ChaCha20-Poly1305 (BouncyCastle)       | 8KB          |   9,859.2 ns |    73.26 ns |    68.53 ns |     416 B |
| Decrypt · ChaCha20-Poly1305 (CryptoHives-SSSE3)  | 8KB          |  12,443.6 ns |    26.82 ns |    22.40 ns |         - |
| Decrypt · ChaCha20-Poly1305 (OS)                 | 8KB          |  13,277.8 ns |    31.32 ns |    27.77 ns |         - |
| Decrypt · ChaCha20-Poly1305 (NaCl.Core)          | 8KB          |  18,633.1 ns |    99.59 ns |    93.15 ns |      72 B |
| Decrypt · ChaCha20-Poly1305 (CryptoHives-Scalar) | 8KB          |  33,956.8 ns |   361.42 ns |   338.07 ns |         - |
|                                                  |              |              |             |             |           |
| Encrypt · ChaCha20-Poly1305 (CryptoHives-AVX2)   | 8KB          |   8,840.1 ns |   164.71 ns |   154.07 ns |         - |
| Encrypt · ChaCha20-Poly1305 (BouncyCastle)       | 8KB          |   9,720.5 ns |   183.37 ns |   180.10 ns |     336 B |
| Encrypt · ChaCha20-Poly1305 (CryptoHives-SSSE3)  | 8KB          |  12,560.6 ns |   233.48 ns |   218.40 ns |         - |
| Encrypt · ChaCha20-Poly1305 (OS)                 | 8KB          |  13,328.8 ns |   135.29 ns |   119.93 ns |         - |
| Encrypt · ChaCha20-Poly1305 (NaCl.Core)          | 8KB          |  19,108.5 ns |   379.93 ns |   406.52 ns |      72 B |
| Encrypt · ChaCha20-Poly1305 (CryptoHives-Scalar) | 8KB          |  34,108.0 ns |   636.60 ns |   595.47 ns |         - |
|                                                  |              |              |             |             |           |
| Decrypt · ChaCha20-Poly1305 (CryptoHives-AVX2)   | 128KB        | 137,147.5 ns |   382.31 ns |   357.61 ns |         - |
| Decrypt · ChaCha20-Poly1305 (BouncyCastle)       | 128KB        | 150,580.9 ns | 1,054.92 ns |   935.16 ns |     416 B |
| Decrypt · ChaCha20-Poly1305 (CryptoHives-SSSE3)  | 128KB        | 195,815.1 ns |   698.66 ns |   653.53 ns |         - |
| Decrypt · ChaCha20-Poly1305 (OS)                 | 128KB        | 209,457.1 ns | 2,572.46 ns | 2,406.28 ns |         - |
| Decrypt · ChaCha20-Poly1305 (NaCl.Core)          | 128KB        | 301,524.9 ns | 1,655.87 ns | 1,548.90 ns |      72 B |
| Decrypt · ChaCha20-Poly1305 (CryptoHives-Scalar) | 128KB        | 537,618.9 ns | 4,345.09 ns | 4,064.40 ns |         - |
|                                                  |              |              |             |             |           |
| Encrypt · ChaCha20-Poly1305 (CryptoHives-AVX2)   | 128KB        | 137,765.4 ns | 2,026.47 ns | 1,796.41 ns |         - |
| Encrypt · ChaCha20-Poly1305 (BouncyCastle)       | 128KB        | 154,914.0 ns | 2,926.50 ns | 3,252.79 ns |     336 B |
| Encrypt · ChaCha20-Poly1305 (CryptoHives-SSSE3)  | 128KB        | 198,854.7 ns | 3,339.44 ns | 3,123.72 ns |         - |
| Encrypt · ChaCha20-Poly1305 (OS)                 | 128KB        | 213,292.6 ns | 3,658.50 ns | 3,422.16 ns |         - |
| Encrypt · ChaCha20-Poly1305 (NaCl.Core)          | 128KB        | 302,588.3 ns | 5,606.65 ns | 5,244.46 ns |      72 B |
| Encrypt · ChaCha20-Poly1305 (CryptoHives-Scalar) | 128KB        | 538,066.4 ns | 5,095.20 ns | 4,254.72 ns |         - |