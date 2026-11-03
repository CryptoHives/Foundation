| Description                                       | TestDataSize | Mean         | Error       | StdDev      | Code Size | Allocated |
|-------------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|----------:|
| Decrypt · XChaCha20-Poly1305 (CryptoHives-AVX2)   | 128B         |     632.5 ns |     0.84 ns |     0.74 ns |     306 B |         - |
| Decrypt · XChaCha20-Poly1305 (CryptoHives-SSSE3)  | 128B         |     692.1 ns |     0.75 ns |     0.66 ns |     306 B |         - |
| Decrypt · XChaCha20-Poly1305 (NaCl.Core)          | 128B         |   1,115.1 ns |     1.12 ns |     0.99 ns |  18,263 B |      48 B |
| Decrypt · XChaCha20-Poly1305 (CryptoHives-Scalar) | 128B         |   1,279.2 ns |     1.66 ns |     1.39 ns |     306 B |         - |
|                                                   |              |              |             |             |           |           |
| Encrypt · XChaCha20-Poly1305 (CryptoHives-AVX2)   | 128B         |     566.0 ns |     1.29 ns |     1.14 ns |     383 B |         - |
| Encrypt · XChaCha20-Poly1305 (CryptoHives-SSSE3)  | 128B         |     629.4 ns |     0.98 ns |     0.87 ns |     386 B |         - |
| Encrypt · XChaCha20-Poly1305 (NaCl.Core)          | 128B         |   1,076.0 ns |     1.76 ns |     1.56 ns |  17,718 B |      48 B |
| Encrypt · XChaCha20-Poly1305 (CryptoHives-Scalar) | 128B         |   1,218.3 ns |     1.72 ns |     1.44 ns |     383 B |         - |
|                                                   |              |              |             |             |           |           |
| Decrypt · XChaCha20-Poly1305 (CryptoHives-AVX2)   | 1KB          |   1,604.8 ns |     2.26 ns |     1.89 ns |     306 B |         - |
| Decrypt · XChaCha20-Poly1305 (CryptoHives-SSSE3)  | 1KB          |   2,132.7 ns |     3.48 ns |     3.26 ns |     306 B |         - |
| Decrypt · XChaCha20-Poly1305 (NaCl.Core)          | 1KB          |   4,928.0 ns |     9.75 ns |     8.64 ns |  20,459 B |      72 B |
| Decrypt · XChaCha20-Poly1305 (CryptoHives-Scalar) | 1KB          |   5,436.9 ns |     9.88 ns |     8.25 ns |     306 B |         - |
|                                                   |              |              |             |             |           |           |
| Encrypt · XChaCha20-Poly1305 (CryptoHives-AVX2)   | 1KB          |   1,550.3 ns |     2.36 ns |     2.09 ns |     386 B |         - |
| Encrypt · XChaCha20-Poly1305 (CryptoHives-SSSE3)  | 1KB          |   2,076.9 ns |     2.33 ns |     1.95 ns |     386 B |         - |
| Encrypt · XChaCha20-Poly1305 (NaCl.Core)          | 1KB          |   4,893.6 ns |    11.09 ns |     9.26 ns |  18,286 B |      72 B |
| Encrypt · XChaCha20-Poly1305 (CryptoHives-Scalar) | 1KB          |   5,392.8 ns |     8.06 ns |     7.54 ns |     386 B |         - |
|                                                   |              |              |             |             |           |           |
| Decrypt · XChaCha20-Poly1305 (CryptoHives-AVX2)   | 8KB          |   9,441.8 ns |    16.69 ns |    13.93 ns |     306 B |         - |
| Decrypt · XChaCha20-Poly1305 (CryptoHives-SSSE3)  | 8KB          |  13,726.1 ns |    10.33 ns |     9.16 ns |     306 B |         - |
| Decrypt · XChaCha20-Poly1305 (NaCl.Core)          | 8KB          |  35,587.4 ns |    45.10 ns |    37.66 ns |  20,539 B |      72 B |
| Decrypt · XChaCha20-Poly1305 (CryptoHives-Scalar) | 8KB          |  38,763.0 ns |   109.60 ns |   102.52 ns |     306 B |         - |
|                                                   |              |              |             |             |           |           |
| Encrypt · XChaCha20-Poly1305 (CryptoHives-AVX2)   | 8KB          |   9,402.1 ns |    16.55 ns |    14.67 ns |     383 B |         - |
| Encrypt · XChaCha20-Poly1305 (CryptoHives-SSSE3)  | 8KB          |  13,679.6 ns |    11.24 ns |     8.78 ns |     383 B |         - |
| Encrypt · XChaCha20-Poly1305 (NaCl.Core)          | 8KB          |  36,308.5 ns |    62.26 ns |    55.20 ns |  18,479 B |      72 B |
| Encrypt · XChaCha20-Poly1305 (CryptoHives-Scalar) | 8KB          |  38,856.9 ns |    56.43 ns |    47.13 ns |     383 B |         - |
|                                                   |              |              |             |             |           |           |
| Decrypt · XChaCha20-Poly1305 (CryptoHives-AVX2)   | 128KB        | 143,822.0 ns |   173.09 ns |   153.44 ns |     306 B |         - |
| Decrypt · XChaCha20-Poly1305 (CryptoHives-SSSE3)  | 128KB        | 212,316.2 ns |   213.92 ns |   189.63 ns |     306 B |         - |
| Decrypt · XChaCha20-Poly1305 (NaCl.Core)          | 128KB        | 558,124.0 ns |   982.50 ns |   870.96 ns |  19,518 B |      72 B |
| Decrypt · XChaCha20-Poly1305 (CryptoHives-Scalar) | 128KB        | 608,761.4 ns | 1,537.58 ns | 1,363.03 ns |     306 B |         - |
|                                                   |              |              |             |             |           |           |
| Encrypt · XChaCha20-Poly1305 (CryptoHives-AVX2)   | 128KB        | 144,081.4 ns |   323.67 ns |   286.92 ns |     383 B |         - |
| Encrypt · XChaCha20-Poly1305 (CryptoHives-SSSE3)  | 128KB        | 212,222.8 ns |   162.02 ns |   135.29 ns |     383 B |         - |
| Encrypt · XChaCha20-Poly1305 (NaCl.Core)          | 128KB        | 556,700.3 ns | 1,057.99 ns |   937.88 ns |  17,197 B |      72 B |
| Encrypt · XChaCha20-Poly1305 (CryptoHives-Scalar) | 128KB        | 607,663.7 ns | 1,190.26 ns | 1,055.13 ns |     383 B |         - |