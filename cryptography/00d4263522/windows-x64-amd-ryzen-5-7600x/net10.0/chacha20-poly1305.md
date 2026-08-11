| Description                                      | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|------------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|
| Decrypt · ChaCha20-Poly1305 (CryptoHives-AVX2)   | 128B         |     327.0 ns |     1.00 ns |     0.93 ns |         - |
| Decrypt · ChaCha20-Poly1305 (OS)                 | 128B         |     349.8 ns |     2.48 ns |     2.32 ns |         - |
| Decrypt · ChaCha20-Poly1305 (CryptoHives-SSSE3)  | 128B         |     385.7 ns |     0.94 ns |     0.88 ns |         - |
| Decrypt · ChaCha20-Poly1305 (NaCl.Core)          | 128B         |     589.0 ns |     2.53 ns |     2.24 ns |      48 B |
| Decrypt · ChaCha20-Poly1305 (BouncyCastle)       | 128B         |     647.3 ns |     2.80 ns |     2.62 ns |     416 B |
| Decrypt · ChaCha20-Poly1305 (CryptoHives-Scalar) | 128B         |     881.2 ns |     5.22 ns |     4.63 ns |         - |
|                                                  |              |              |             |             |           |
| Encrypt · ChaCha20-Poly1305 (CryptoHives-AVX2)   | 128B         |     287.4 ns |     0.71 ns |     0.63 ns |         - |
| Encrypt · ChaCha20-Poly1305 (CryptoHives-SSSE3)  | 128B         |     342.3 ns |     1.06 ns |     0.99 ns |         - |
| Encrypt · ChaCha20-Poly1305 (OS)                 | 128B         |     352.2 ns |     2.53 ns |     2.37 ns |         - |
| Encrypt · ChaCha20-Poly1305 (BouncyCastle)       | 128B         |     370.0 ns |     2.44 ns |     2.29 ns |     336 B |
| Encrypt · ChaCha20-Poly1305 (NaCl.Core)          | 128B         |     549.1 ns |     2.26 ns |     2.00 ns |      48 B |
| Encrypt · ChaCha20-Poly1305 (CryptoHives-Scalar) | 128B         |     842.6 ns |     2.47 ns |     2.19 ns |         - |
|                                                  |              |              |             |             |           |
| Decrypt · ChaCha20-Poly1305 (CryptoHives-AVX2)   | 1KB          |   1,254.0 ns |     2.32 ns |     2.17 ns |         - |
| Decrypt · ChaCha20-Poly1305 (BouncyCastle)       | 1KB          |   1,593.4 ns |     9.96 ns |     9.32 ns |     416 B |
| Decrypt · ChaCha20-Poly1305 (CryptoHives-SSSE3)  | 1KB          |   1,718.1 ns |     3.88 ns |     3.63 ns |         - |
| Decrypt · ChaCha20-Poly1305 (OS)                 | 1KB          |   1,765.5 ns |    10.51 ns |     9.83 ns |         - |
| Decrypt · ChaCha20-Poly1305 (NaCl.Core)          | 1KB          |   2,577.6 ns |    10.04 ns |     9.40 ns |      72 B |
| Decrypt · ChaCha20-Poly1305 (CryptoHives-Scalar) | 1KB          |   4,510.9 ns |    22.24 ns |    20.80 ns |         - |
|                                                  |              |              |             |             |           |
| Encrypt · ChaCha20-Poly1305 (CryptoHives-AVX2)   | 1KB          |   1,215.9 ns |     3.90 ns |     3.65 ns |         - |
| Encrypt · ChaCha20-Poly1305 (BouncyCastle)       | 1KB          |   1,301.1 ns |     7.62 ns |     7.13 ns |     336 B |
| Encrypt · ChaCha20-Poly1305 (CryptoHives-SSSE3)  | 1KB          |   1,690.3 ns |     5.15 ns |     4.82 ns |         - |
| Encrypt · ChaCha20-Poly1305 (OS)                 | 1KB          |   1,768.1 ns |     5.10 ns |     4.77 ns |         - |
| Encrypt · ChaCha20-Poly1305 (NaCl.Core)          | 1KB          |   2,535.2 ns |     7.50 ns |     6.65 ns |      72 B |
| Encrypt · ChaCha20-Poly1305 (CryptoHives-Scalar) | 1KB          |   4,474.2 ns |    19.67 ns |    18.40 ns |         - |
|                                                  |              |              |             |             |           |
| Decrypt · ChaCha20-Poly1305 (CryptoHives-AVX2)   | 8KB          |   8,698.5 ns |    18.52 ns |    17.33 ns |         - |
| Decrypt · ChaCha20-Poly1305 (BouncyCastle)       | 8KB          |   9,140.6 ns |    31.11 ns |    29.10 ns |     416 B |
| Decrypt · ChaCha20-Poly1305 (CryptoHives-SSSE3)  | 8KB          |  12,354.9 ns |    35.12 ns |    31.14 ns |         - |
| Decrypt · ChaCha20-Poly1305 (OS)                 | 8KB          |  13,134.1 ns |    69.62 ns |    65.12 ns |         - |
| Decrypt · ChaCha20-Poly1305 (NaCl.Core)          | 8KB          |  18,694.9 ns |   285.62 ns |   267.17 ns |      72 B |
| Decrypt · ChaCha20-Poly1305 (CryptoHives-Scalar) | 8KB          |  33,506.4 ns |    98.27 ns |    87.12 ns |         - |
|                                                  |              |              |             |             |           |
| Encrypt · ChaCha20-Poly1305 (CryptoHives-AVX2)   | 8KB          |   8,618.0 ns |    24.28 ns |    21.53 ns |         - |
| Encrypt · ChaCha20-Poly1305 (BouncyCastle)       | 8KB          |   8,654.4 ns |    33.66 ns |    31.48 ns |     336 B |
| Encrypt · ChaCha20-Poly1305 (CryptoHives-SSSE3)  | 8KB          |  12,292.6 ns |    26.71 ns |    24.98 ns |         - |
| Encrypt · ChaCha20-Poly1305 (OS)                 | 8KB          |  13,157.1 ns |    48.94 ns |    45.78 ns |         - |
| Encrypt · ChaCha20-Poly1305 (NaCl.Core)          | 8KB          |  18,211.9 ns |    58.85 ns |    55.04 ns |      72 B |
| Encrypt · ChaCha20-Poly1305 (CryptoHives-Scalar) | 8KB          |  33,549.0 ns |   181.07 ns |   169.37 ns |         - |
|                                                  |              |              |             |             |           |
| Decrypt · ChaCha20-Poly1305 (CryptoHives-AVX2)   | 128KB        | 135,755.7 ns |   341.97 ns |   303.15 ns |         - |
| Decrypt · ChaCha20-Poly1305 (BouncyCastle)       | 128KB        | 140,849.4 ns |   747.44 ns |   699.15 ns |     416 B |
| Decrypt · ChaCha20-Poly1305 (CryptoHives-SSSE3)  | 128KB        | 194,511.4 ns |   243.13 ns |   227.42 ns |         - |
| Decrypt · ChaCha20-Poly1305 (OS)                 | 128KB        | 208,469.8 ns | 1,201.19 ns | 1,123.59 ns |         - |
| Decrypt · ChaCha20-Poly1305 (NaCl.Core)          | 128KB        | 290,991.4 ns | 1,374.35 ns | 1,285.56 ns |      72 B |
| Decrypt · ChaCha20-Poly1305 (CryptoHives-Scalar) | 128KB        | 532,526.9 ns | 2,679.81 ns | 2,506.70 ns |         - |
|                                                  |              |              |             |             |           |
| Encrypt · ChaCha20-Poly1305 (CryptoHives-AVX2)   | 128KB        | 135,816.6 ns |   316.98 ns |   296.50 ns |         - |
| Encrypt · ChaCha20-Poly1305 (BouncyCastle)       | 128KB        | 137,878.6 ns |   621.22 ns |   550.70 ns |     336 B |
| Encrypt · ChaCha20-Poly1305 (CryptoHives-SSSE3)  | 128KB        | 194,732.9 ns |   482.32 ns |   451.16 ns |         - |
| Encrypt · ChaCha20-Poly1305 (OS)                 | 128KB        | 207,808.7 ns |   845.23 ns |   790.62 ns |         - |
| Encrypt · ChaCha20-Poly1305 (NaCl.Core)          | 128KB        | 287,464.1 ns | 1,035.65 ns |   968.75 ns |      72 B |
| Encrypt · ChaCha20-Poly1305 (CryptoHives-Scalar) | 128KB        | 528,821.0 ns | 2,338.99 ns | 2,073.46 ns |         - |