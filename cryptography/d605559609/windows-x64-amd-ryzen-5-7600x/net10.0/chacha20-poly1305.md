| Description                                      | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|------------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|
| Decrypt · ChaCha20-Poly1305 (CryptoHives-AVX2)   | 128B         |     343.9 ns |     1.32 ns |     1.17 ns |         - |
| Decrypt · ChaCha20-Poly1305 (OS)                 | 128B         |     357.3 ns |     2.05 ns |     1.71 ns |         - |
| Decrypt · ChaCha20-Poly1305 (CryptoHives-SSSE3)  | 128B         |     394.9 ns |     1.89 ns |     1.47 ns |         - |
| Decrypt · ChaCha20-Poly1305 (NaCl.Core)          | 128B         |     593.0 ns |     8.85 ns |     7.39 ns |      48 B |
| Decrypt · ChaCha20-Poly1305 (BouncyCastle)       | 128B         |     646.3 ns |     3.10 ns |     2.75 ns |     416 B |
| Decrypt · ChaCha20-Poly1305 (CryptoHives-Scalar) | 128B         |     885.8 ns |     2.87 ns |     2.55 ns |         - |
|                                                  |              |              |             |             |           |
| Encrypt · ChaCha20-Poly1305 (CryptoHives-AVX2)   | 128B         |     292.1 ns |     0.85 ns |     0.80 ns |         - |
| Encrypt · ChaCha20-Poly1305 (CryptoHives-SSSE3)  | 128B         |     348.1 ns |     0.66 ns |     0.59 ns |         - |
| Encrypt · ChaCha20-Poly1305 (OS)                 | 128B         |     352.6 ns |     2.54 ns |     2.12 ns |         - |
| Encrypt · ChaCha20-Poly1305 (BouncyCastle)       | 128B         |     375.6 ns |     2.43 ns |     2.15 ns |     336 B |
| Encrypt · ChaCha20-Poly1305 (NaCl.Core)          | 128B         |     559.1 ns |     3.15 ns |     2.63 ns |      48 B |
| Encrypt · ChaCha20-Poly1305 (CryptoHives-Scalar) | 128B         |     853.8 ns |    17.03 ns |    15.93 ns |         - |
|                                                  |              |              |             |             |           |
| Decrypt · ChaCha20-Poly1305 (CryptoHives-AVX2)   | 1KB          |   1,279.1 ns |     3.97 ns |     3.51 ns |         - |
| Decrypt · ChaCha20-Poly1305 (BouncyCastle)       | 1KB          |   1,608.6 ns |     8.67 ns |     8.11 ns |     416 B |
| Decrypt · ChaCha20-Poly1305 (CryptoHives-SSSE3)  | 1KB          |   1,739.6 ns |    12.38 ns |    10.34 ns |         - |
| Decrypt · ChaCha20-Poly1305 (OS)                 | 1KB          |   1,783.0 ns |     4.83 ns |     4.03 ns |         - |
| Decrypt · ChaCha20-Poly1305 (NaCl.Core)          | 1KB          |   2,609.6 ns |    11.56 ns |     9.65 ns |      72 B |
| Decrypt · ChaCha20-Poly1305 (CryptoHives-Scalar) | 1KB          |   4,525.0 ns |    12.55 ns |    11.13 ns |         - |
|                                                  |              |              |             |             |           |
| Encrypt · ChaCha20-Poly1305 (CryptoHives-AVX2)   | 1KB          |   1,238.0 ns |     3.21 ns |     2.68 ns |         - |
| Encrypt · ChaCha20-Poly1305 (BouncyCastle)       | 1KB          |   1,303.0 ns |     9.58 ns |     8.00 ns |     336 B |
| Encrypt · ChaCha20-Poly1305 (CryptoHives-SSSE3)  | 1KB          |   1,681.5 ns |     1.56 ns |     1.38 ns |         - |
| Encrypt · ChaCha20-Poly1305 (OS)                 | 1KB          |   1,786.4 ns |     6.76 ns |     6.00 ns |         - |
| Encrypt · ChaCha20-Poly1305 (NaCl.Core)          | 1KB          |   2,559.5 ns |     8.54 ns |     7.13 ns |      72 B |
| Encrypt · ChaCha20-Poly1305 (CryptoHives-Scalar) | 1KB          |   4,492.8 ns |    10.49 ns |     8.19 ns |         - |
|                                                  |              |              |             |             |           |
| Decrypt · ChaCha20-Poly1305 (CryptoHives-AVX2)   | 8KB          |   8,727.8 ns |    37.08 ns |    34.69 ns |         - |
| Decrypt · ChaCha20-Poly1305 (BouncyCastle)       | 8KB          |   9,266.2 ns |    33.78 ns |    31.59 ns |     416 B |
| Decrypt · ChaCha20-Poly1305 (CryptoHives-SSSE3)  | 8KB          |  12,456.6 ns |   115.24 ns |   102.16 ns |         - |
| Decrypt · ChaCha20-Poly1305 (OS)                 | 8KB          |  13,263.6 ns |    66.54 ns |    58.99 ns |         - |
| Decrypt · ChaCha20-Poly1305 (NaCl.Core)          | 8KB          |  18,711.4 ns |    97.52 ns |    91.22 ns |      72 B |
| Decrypt · ChaCha20-Poly1305 (CryptoHives-Scalar) | 8KB          |  33,732.2 ns |   118.20 ns |   104.78 ns |         - |
|                                                  |              |              |             |             |           |
| Encrypt · ChaCha20-Poly1305 (CryptoHives-AVX2)   | 8KB          |   8,725.3 ns |   153.98 ns |   158.13 ns |         - |
| Encrypt · ChaCha20-Poly1305 (BouncyCastle)       | 8KB          |   8,774.2 ns |    62.82 ns |    49.05 ns |     336 B |
| Encrypt · ChaCha20-Poly1305 (CryptoHives-SSSE3)  | 8KB          |  12,356.3 ns |    31.96 ns |    29.90 ns |         - |
| Encrypt · ChaCha20-Poly1305 (OS)                 | 8KB          |  13,232.1 ns |    45.20 ns |    40.07 ns |         - |
| Encrypt · ChaCha20-Poly1305 (NaCl.Core)          | 8KB          |  18,652.1 ns |    70.68 ns |    66.11 ns |      72 B |
| Encrypt · ChaCha20-Poly1305 (CryptoHives-Scalar) | 8KB          |  33,693.7 ns |    74.73 ns |    62.41 ns |         - |
|                                                  |              |              |             |             |           |
| Decrypt · ChaCha20-Poly1305 (CryptoHives-AVX2)   | 128KB        | 136,327.4 ns |   334.92 ns |   279.68 ns |         - |
| Decrypt · ChaCha20-Poly1305 (BouncyCastle)       | 128KB        | 142,805.3 ns |   849.92 ns |   753.43 ns |     416 B |
| Decrypt · ChaCha20-Poly1305 (CryptoHives-SSSE3)  | 128KB        | 194,736.2 ns |   221.61 ns |   173.02 ns |         - |
| Decrypt · ChaCha20-Poly1305 (OS)                 | 128KB        | 209,600.9 ns |   438.21 ns |   388.46 ns |         - |
| Decrypt · ChaCha20-Poly1305 (NaCl.Core)          | 128KB        | 341,247.3 ns |   674.85 ns |   598.24 ns |      72 B |
| Decrypt · ChaCha20-Poly1305 (CryptoHives-Scalar) | 128KB        | 536,100.6 ns | 1,776.21 ns | 1,574.57 ns |         - |
|                                                  |              |              |             |             |           |
| Encrypt · ChaCha20-Poly1305 (CryptoHives-AVX2)   | 128KB        | 136,502.6 ns |   472.46 ns |   394.53 ns |         - |
| Encrypt · ChaCha20-Poly1305 (BouncyCastle)       | 128KB        | 139,129.6 ns |   695.24 ns |   650.33 ns |     336 B |
| Encrypt · ChaCha20-Poly1305 (CryptoHives-SSSE3)  | 128KB        | 195,120.0 ns |   348.43 ns |   308.87 ns |         - |
| Encrypt · ChaCha20-Poly1305 (OS)                 | 128KB        | 209,883.3 ns |   962.84 ns |   900.64 ns |         - |
| Encrypt · ChaCha20-Poly1305 (NaCl.Core)          | 128KB        | 292,856.4 ns | 1,466.90 ns | 1,145.26 ns |      72 B |
| Encrypt · ChaCha20-Poly1305 (CryptoHives-Scalar) | 128KB        | 535,436.8 ns | 1,848.35 ns | 1,638.52 ns |         - |