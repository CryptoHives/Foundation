| Description                                      | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|------------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|
| Decrypt · ChaCha20-Poly1305 (CryptoHives-AVX2)   | 128B         |     336.8 ns |     1.21 ns |     1.13 ns |         - |
| Decrypt · ChaCha20-Poly1305 (OS)                 | 128B         |     349.1 ns |     1.69 ns |     1.50 ns |         - |
| Decrypt · ChaCha20-Poly1305 (CryptoHives-SSSE3)  | 128B         |     390.7 ns |     1.69 ns |     1.58 ns |         - |
| Decrypt · ChaCha20-Poly1305 (NaCl.Core)          | 128B         |     609.1 ns |     5.12 ns |     4.79 ns |      48 B |
| Decrypt · ChaCha20-Poly1305 (BouncyCastle)       | 128B         |     727.3 ns |     4.77 ns |     4.23 ns |     416 B |
| Decrypt · ChaCha20-Poly1305 (CryptoHives-Scalar) | 128B         |     882.4 ns |     3.35 ns |     3.13 ns |         - |
|                                                  |              |              |             |             |           |
| Encrypt · ChaCha20-Poly1305 (CryptoHives-AVX2)   | 128B         |     288.5 ns |     1.75 ns |     1.46 ns |         - |
| Encrypt · ChaCha20-Poly1305 (CryptoHives-SSSE3)  | 128B         |     343.0 ns |     1.20 ns |     1.12 ns |         - |
| Encrypt · ChaCha20-Poly1305 (OS)                 | 128B         |     349.8 ns |     1.16 ns |     1.09 ns |         - |
| Encrypt · ChaCha20-Poly1305 (BouncyCastle)       | 128B         |     418.2 ns |     2.22 ns |     1.97 ns |     336 B |
| Encrypt · ChaCha20-Poly1305 (NaCl.Core)          | 128B         |     555.1 ns |     2.88 ns |     2.69 ns |      48 B |
| Encrypt · ChaCha20-Poly1305 (CryptoHives-Scalar) | 128B         |     843.7 ns |     3.54 ns |     3.31 ns |         - |
|                                                  |              |              |             |             |           |
| Decrypt · ChaCha20-Poly1305 (CryptoHives-AVX2)   | 1KB          |   1,269.2 ns |     3.11 ns |     2.76 ns |         - |
| Decrypt · ChaCha20-Poly1305 (CryptoHives-SSSE3)  | 1KB          |   1,715.1 ns |     4.73 ns |     4.43 ns |         - |
| Decrypt · ChaCha20-Poly1305 (BouncyCastle)       | 1KB          |   1,719.0 ns |    11.68 ns |    10.35 ns |     416 B |
| Decrypt · ChaCha20-Poly1305 (OS)                 | 1KB          |   1,775.1 ns |     6.30 ns |     5.58 ns |         - |
| Decrypt · ChaCha20-Poly1305 (NaCl.Core)          | 1KB          |   2,783.3 ns |    11.19 ns |     9.34 ns |      72 B |
| Decrypt · ChaCha20-Poly1305 (CryptoHives-Scalar) | 1KB          |   4,588.7 ns |    20.77 ns |    19.43 ns |         - |
|                                                  |              |              |             |             |           |
| Encrypt · ChaCha20-Poly1305 (CryptoHives-AVX2)   | 1KB          |   1,230.6 ns |     3.18 ns |     2.82 ns |         - |
| Encrypt · ChaCha20-Poly1305 (BouncyCastle)       | 1KB          |   1,421.3 ns |     7.11 ns |     6.30 ns |     336 B |
| Encrypt · ChaCha20-Poly1305 (CryptoHives-SSSE3)  | 1KB          |   1,683.5 ns |     3.60 ns |     3.37 ns |         - |
| Encrypt · ChaCha20-Poly1305 (OS)                 | 1KB          |   1,776.4 ns |    10.09 ns |     9.44 ns |         - |
| Encrypt · ChaCha20-Poly1305 (NaCl.Core)          | 1KB          |   2,542.2 ns |     9.11 ns |     8.52 ns |      72 B |
| Encrypt · ChaCha20-Poly1305 (CryptoHives-Scalar) | 1KB          |   4,493.2 ns |    20.79 ns |    19.45 ns |         - |
|                                                  |              |              |             |             |           |
| Decrypt · ChaCha20-Poly1305 (CryptoHives-AVX2)   | 8KB          |   8,738.6 ns |    25.01 ns |    23.39 ns |         - |
| Decrypt · ChaCha20-Poly1305 (BouncyCastle)       | 8KB          |   9,660.0 ns |    47.89 ns |    42.45 ns |     416 B |
| Decrypt · ChaCha20-Poly1305 (CryptoHives-SSSE3)  | 8KB          |  12,369.4 ns |    22.74 ns |    18.99 ns |         - |
| Decrypt · ChaCha20-Poly1305 (OS)                 | 8KB          |  13,190.4 ns |    36.70 ns |    30.65 ns |         - |
| Decrypt · ChaCha20-Poly1305 (NaCl.Core)          | 8KB          |  18,303.6 ns |    61.90 ns |    57.90 ns |      72 B |
| Decrypt · ChaCha20-Poly1305 (CryptoHives-Scalar) | 8KB          |  33,648.2 ns |   170.52 ns |   159.50 ns |         - |
|                                                  |              |              |             |             |           |
| Encrypt · ChaCha20-Poly1305 (CryptoHives-AVX2)   | 8KB          |   8,649.0 ns |    23.98 ns |    20.02 ns |         - |
| Encrypt · ChaCha20-Poly1305 (BouncyCastle)       | 8KB          |   9,450.7 ns |    56.03 ns |    52.41 ns |     336 B |
| Encrypt · ChaCha20-Poly1305 (CryptoHives-SSSE3)  | 8KB          |  12,351.6 ns |    32.38 ns |    30.29 ns |         - |
| Encrypt · ChaCha20-Poly1305 (OS)                 | 8KB          |  13,219.7 ns |    49.28 ns |    46.10 ns |         - |
| Encrypt · ChaCha20-Poly1305 (NaCl.Core)          | 8KB          |  18,401.5 ns |    95.44 ns |    89.27 ns |      72 B |
| Encrypt · ChaCha20-Poly1305 (CryptoHives-Scalar) | 8KB          |  33,569.2 ns |   100.66 ns |    84.05 ns |         - |
|                                                  |              |              |             |             |           |
| Decrypt · ChaCha20-Poly1305 (CryptoHives-AVX2)   | 128KB        | 136,795.9 ns |   765.71 ns |   716.24 ns |         - |
| Decrypt · ChaCha20-Poly1305 (BouncyCastle)       | 128KB        | 147,772.4 ns |   774.45 ns |   724.42 ns |     416 B |
| Decrypt · ChaCha20-Poly1305 (CryptoHives-SSSE3)  | 128KB        | 194,945.7 ns |   354.48 ns |   331.58 ns |         - |
| Decrypt · ChaCha20-Poly1305 (OS)                 | 128KB        | 209,103.6 ns |   543.40 ns |   481.71 ns |         - |
| Decrypt · ChaCha20-Poly1305 (NaCl.Core)          | 128KB        | 296,404.4 ns |   932.18 ns |   778.41 ns |      72 B |
| Decrypt · ChaCha20-Poly1305 (CryptoHives-Scalar) | 128KB        | 533,896.2 ns | 3,236.26 ns | 2,702.42 ns |         - |
|                                                  |              |              |             |             |           |
| Encrypt · ChaCha20-Poly1305 (CryptoHives-AVX2)   | 128KB        | 136,112.2 ns |   368.80 ns |   326.93 ns |         - |
| Encrypt · ChaCha20-Poly1305 (BouncyCastle)       | 128KB        | 151,564.1 ns |   544.21 ns |   482.43 ns |     336 B |
| Encrypt · ChaCha20-Poly1305 (CryptoHives-SSSE3)  | 128KB        | 194,880.8 ns |   299.80 ns |   265.77 ns |         - |
| Encrypt · ChaCha20-Poly1305 (OS)                 | 128KB        | 209,185.0 ns |   924.97 ns |   819.96 ns |         - |
| Encrypt · ChaCha20-Poly1305 (NaCl.Core)          | 128KB        | 289,913.8 ns | 1,276.95 ns | 1,131.98 ns |      72 B |
| Encrypt · ChaCha20-Poly1305 (CryptoHives-Scalar) | 128KB        | 532,685.7 ns | 1,154.09 ns |   963.71 ns |         - |