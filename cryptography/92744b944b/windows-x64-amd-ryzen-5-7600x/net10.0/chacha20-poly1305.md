| Description                                      | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|------------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|
| Decrypt · ChaCha20-Poly1305 (OS)                 | 128B         |     342.3 ns |     1.00 ns |     0.94 ns |         - |
| Decrypt · ChaCha20-Poly1305 (CryptoHives-AVX2)   | 128B         |     342.6 ns |     0.45 ns |     0.42 ns |         - |
| Decrypt · ChaCha20-Poly1305 (CryptoHives-SSSE3)  | 128B         |     382.7 ns |     0.59 ns |     0.52 ns |         - |
| Decrypt · ChaCha20-Poly1305 (NaCl.Core)          | 128B         |     572.5 ns |     1.66 ns |     1.55 ns |      48 B |
| Decrypt · ChaCha20-Poly1305 (BouncyCastle)       | 128B         |     703.9 ns |     2.83 ns |     2.64 ns |     416 B |
| Decrypt · ChaCha20-Poly1305 (CryptoHives-Scalar) | 128B         |     866.1 ns |     1.37 ns |     1.28 ns |         - |
|                                                  |              |              |             |             |           |
| Encrypt · ChaCha20-Poly1305 (CryptoHives-AVX2)   | 128B         |     295.1 ns |     0.61 ns |     0.57 ns |         - |
| Encrypt · ChaCha20-Poly1305 (OS)                 | 128B         |     342.2 ns |     0.71 ns |     0.63 ns |         - |
| Encrypt · ChaCha20-Poly1305 (CryptoHives-SSSE3)  | 128B         |     350.8 ns |     0.32 ns |     0.27 ns |         - |
| Encrypt · ChaCha20-Poly1305 (BouncyCastle)       | 128B         |     406.2 ns |     0.98 ns |     0.91 ns |     336 B |
| Encrypt · ChaCha20-Poly1305 (NaCl.Core)          | 128B         |     534.1 ns |     0.97 ns |     0.86 ns |      48 B |
| Encrypt · ChaCha20-Poly1305 (CryptoHives-Scalar) | 128B         |     837.5 ns |     1.16 ns |     1.09 ns |         - |
|                                                  |              |              |             |             |           |
| Decrypt · ChaCha20-Poly1305 (CryptoHives-AVX2)   | 1KB          |   1,252.4 ns |     1.99 ns |     1.86 ns |         - |
| Decrypt · ChaCha20-Poly1305 (BouncyCastle)       | 1KB          |   1,682.7 ns |     3.84 ns |     3.59 ns |     416 B |
| Decrypt · ChaCha20-Poly1305 (CryptoHives-SSSE3)  | 1KB          |   1,717.9 ns |     1.92 ns |     1.79 ns |         - |
| Decrypt · ChaCha20-Poly1305 (OS)                 | 1KB          |   1,751.5 ns |     2.68 ns |     2.50 ns |         - |
| Decrypt · ChaCha20-Poly1305 (NaCl.Core)          | 1KB          |   2,553.5 ns |     5.95 ns |     5.28 ns |      72 B |
| Decrypt · ChaCha20-Poly1305 (CryptoHives-Scalar) | 1KB          |   4,592.6 ns |     5.93 ns |     5.25 ns |         - |
|                                                  |              |              |             |             |           |
| Encrypt · ChaCha20-Poly1305 (CryptoHives-AVX2)   | 1KB          |   1,225.4 ns |     1.49 ns |     1.32 ns |         - |
| Encrypt · ChaCha20-Poly1305 (BouncyCastle)       | 1KB          |   1,395.0 ns |     3.16 ns |     2.95 ns |     336 B |
| Encrypt · ChaCha20-Poly1305 (CryptoHives-SSSE3)  | 1KB          |   1,669.9 ns |     0.55 ns |     0.43 ns |         - |
| Encrypt · ChaCha20-Poly1305 (OS)                 | 1KB          |   1,749.2 ns |     2.58 ns |     2.41 ns |         - |
| Encrypt · ChaCha20-Poly1305 (NaCl.Core)          | 1KB          |   2,506.2 ns |     4.92 ns |     4.61 ns |      72 B |
| Encrypt · ChaCha20-Poly1305 (CryptoHives-Scalar) | 1KB          |   4,428.2 ns |    16.03 ns |    14.99 ns |         - |
|                                                  |              |              |             |             |           |
| Decrypt · ChaCha20-Poly1305 (CryptoHives-AVX2)   | 8KB          |   8,663.5 ns |     9.17 ns |     7.65 ns |         - |
| Decrypt · ChaCha20-Poly1305 (BouncyCastle)       | 8KB          |   9,448.9 ns |    19.79 ns |    18.52 ns |     416 B |
| Decrypt · ChaCha20-Poly1305 (CryptoHives-SSSE3)  | 8KB          |  12,312.8 ns |    14.22 ns |    13.30 ns |         - |
| Decrypt · ChaCha20-Poly1305 (OS)                 | 8KB          |  13,037.5 ns |    27.70 ns |    25.91 ns |         - |
| Decrypt · ChaCha20-Poly1305 (NaCl.Core)          | 8KB          |  18,460.3 ns |    43.74 ns |    40.91 ns |      72 B |
| Decrypt · ChaCha20-Poly1305 (CryptoHives-Scalar) | 8KB          |  33,174.0 ns |    47.65 ns |    44.58 ns |         - |
|                                                  |              |              |             |             |           |
| Encrypt · ChaCha20-Poly1305 (CryptoHives-AVX2)   | 8KB          |   8,614.3 ns |    15.38 ns |    13.63 ns |         - |
| Encrypt · ChaCha20-Poly1305 (BouncyCastle)       | 8KB          |   9,327.4 ns |    15.06 ns |    14.09 ns |     336 B |
| Encrypt · ChaCha20-Poly1305 (CryptoHives-SSSE3)  | 8KB          |  12,268.8 ns |    10.48 ns |     9.80 ns |         - |
| Encrypt · ChaCha20-Poly1305 (OS)                 | 8KB          |  13,036.2 ns |    18.87 ns |    16.73 ns |         - |
| Encrypt · ChaCha20-Poly1305 (NaCl.Core)          | 8KB          |  18,138.1 ns |    37.79 ns |    35.35 ns |      72 B |
| Encrypt · ChaCha20-Poly1305 (CryptoHives-Scalar) | 8KB          |  33,068.5 ns |    62.13 ns |    58.12 ns |         - |
|                                                  |              |              |             |             |           |
| Decrypt · ChaCha20-Poly1305 (CryptoHives-AVX2)   | 128KB        | 135,438.6 ns |   206.55 ns |   183.10 ns |         - |
| Decrypt · ChaCha20-Poly1305 (BouncyCastle)       | 128KB        | 145,704.3 ns |   482.52 ns |   451.35 ns |     416 B |
| Decrypt · ChaCha20-Poly1305 (CryptoHives-SSSE3)  | 128KB        | 194,017.2 ns |   229.67 ns |   214.83 ns |         - |
| Decrypt · ChaCha20-Poly1305 (OS)                 | 128KB        | 206,806.3 ns |   339.58 ns |   301.03 ns |         - |
| Decrypt · ChaCha20-Poly1305 (NaCl.Core)          | 128KB        | 290,364.0 ns | 1,249.90 ns | 1,169.16 ns |      72 B |
| Decrypt · ChaCha20-Poly1305 (CryptoHives-Scalar) | 128KB        | 524,822.1 ns |   738.00 ns |   690.33 ns |         - |
|                                                  |              |              |             |             |           |
| Encrypt · ChaCha20-Poly1305 (CryptoHives-AVX2)   | 128KB        | 135,391.6 ns |   135.27 ns |   126.54 ns |         - |
| Encrypt · ChaCha20-Poly1305 (BouncyCastle)       | 128KB        | 147,828.9 ns |   197.10 ns |   174.73 ns |     336 B |
| Encrypt · ChaCha20-Poly1305 (CryptoHives-SSSE3)  | 128KB        | 194,029.2 ns |   211.68 ns |   198.01 ns |         - |
| Encrypt · ChaCha20-Poly1305 (OS)                 | 128KB        | 206,592.8 ns |   271.03 ns |   253.52 ns |         - |
| Encrypt · ChaCha20-Poly1305 (NaCl.Core)          | 128KB        | 290,543.6 ns |   727.42 ns |   680.43 ns |      72 B |
| Encrypt · ChaCha20-Poly1305 (CryptoHives-Scalar) | 128KB        | 524,291.1 ns |   907.66 ns |   849.02 ns |         - |