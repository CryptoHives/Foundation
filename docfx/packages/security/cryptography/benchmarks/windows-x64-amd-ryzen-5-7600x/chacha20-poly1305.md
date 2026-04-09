| Description                                | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|
| Decrypt · ChaCha20-Poly1305 (OS)           | 128B         |     342.4 ns |     1.22 ns |     1.14 ns |         - |
| Decrypt · ChaCha20-Poly1305 (AVX2)         | 128B         |     494.8 ns |     1.18 ns |     1.10 ns |         - |
| Decrypt · ChaCha20-Poly1305 (SSSE3)        | 128B         |     555.3 ns |     1.60 ns |     1.41 ns |         - |
| Decrypt · ChaCha20-Poly1305 (NaCl.Core)    | 128B         |     584.8 ns |     1.49 ns |     1.32 ns |      48 B |
| Decrypt · ChaCha20-Poly1305 (BouncyCastle) | 128B         |     705.3 ns |     1.36 ns |     1.14 ns |     416 B |
| Decrypt · ChaCha20-Poly1305 (Managed)      | 128B         |     871.5 ns |     2.39 ns |     2.23 ns |         - |
|                                            |              |              |             |             |           |
| Encrypt · ChaCha20-Poly1305 (OS)           | 128B         |     344.2 ns |     1.16 ns |     1.09 ns |         - |
| Encrypt · ChaCha20-Poly1305 (BouncyCastle) | 128B         |     408.0 ns |     1.20 ns |     1.12 ns |     336 B |
| Encrypt · ChaCha20-Poly1305 (AVX2)         | 128B         |     448.0 ns |     1.36 ns |     1.27 ns |         - |
| Encrypt · ChaCha20-Poly1305 (SSSE3)        | 128B         |     508.5 ns |     1.46 ns |     1.22 ns |         - |
| Encrypt · ChaCha20-Poly1305 (NaCl.Core)    | 128B         |     541.2 ns |     1.67 ns |     1.39 ns |      48 B |
| Encrypt · ChaCha20-Poly1305 (Managed)      | 128B         |     826.7 ns |     1.69 ns |     1.58 ns |         - |
|                                            |              |              |             |             |           |
| Decrypt · ChaCha20-Poly1305 (AVX2)         | 1KB          |   1,421.9 ns |     3.15 ns |     2.95 ns |         - |
| Decrypt · ChaCha20-Poly1305 (BouncyCastle) | 1KB          |   1,692.3 ns |     4.24 ns |     3.97 ns |     416 B |
| Decrypt · ChaCha20-Poly1305 (OS)           | 1KB          |   1,759.2 ns |     4.08 ns |     3.82 ns |         - |
| Decrypt · ChaCha20-Poly1305 (SSSE3)        | 1KB          |   1,883.6 ns |     2.80 ns |     2.48 ns |         - |
| Decrypt · ChaCha20-Poly1305 (NaCl.Core)    | 1KB          |   2,585.2 ns |    10.31 ns |     9.14 ns |      72 B |
| Decrypt · ChaCha20-Poly1305 (Managed)      | 1KB          |   4,473.9 ns |    11.67 ns |    10.91 ns |         - |
|                                            |              |              |             |             |           |
| Encrypt · ChaCha20-Poly1305 (AVX2)         | 1KB          |   1,375.7 ns |     2.47 ns |     2.19 ns |         - |
| Encrypt · ChaCha20-Poly1305 (BouncyCastle) | 1KB          |   1,405.9 ns |     5.22 ns |     4.63 ns |     336 B |
| Encrypt · ChaCha20-Poly1305 (OS)           | 1KB          |   1,767.6 ns |     4.51 ns |     4.22 ns |         - |
| Encrypt · ChaCha20-Poly1305 (SSSE3)        | 1KB          |   1,841.5 ns |     3.44 ns |     3.05 ns |         - |
| Encrypt · ChaCha20-Poly1305 (NaCl.Core)    | 1KB          |   2,536.9 ns |     9.31 ns |     8.71 ns |      72 B |
| Encrypt · ChaCha20-Poly1305 (Managed)      | 1KB          |   4,427.2 ns |    14.55 ns |    13.61 ns |         - |
|                                            |              |              |             |             |           |
| Decrypt · ChaCha20-Poly1305 (AVX2)         | 8KB          |   8,842.5 ns |     9.43 ns |     8.36 ns |         - |
| Decrypt · ChaCha20-Poly1305 (BouncyCastle) | 8KB          |   9,488.3 ns |    47.79 ns |    44.70 ns |     416 B |
| Decrypt · ChaCha20-Poly1305 (SSSE3)        | 8KB          |  12,520.7 ns |    26.65 ns |    24.93 ns |         - |
| Decrypt · ChaCha20-Poly1305 (OS)           | 8KB          |  13,101.2 ns |    24.53 ns |    19.15 ns |         - |
| Decrypt · ChaCha20-Poly1305 (NaCl.Core)    | 8KB          |  18,672.6 ns |    78.96 ns |    73.86 ns |      72 B |
| Decrypt · ChaCha20-Poly1305 (Managed)      | 8KB          |  33,137.2 ns |    64.28 ns |    60.13 ns |         - |
|                                            |              |              |             |             |           |
| Encrypt · ChaCha20-Poly1305 (AVX2)         | 8KB          |   8,800.9 ns |    22.45 ns |    21.00 ns |         - |
| Encrypt · ChaCha20-Poly1305 (BouncyCastle) | 8KB          |   9,419.7 ns |    22.74 ns |    21.27 ns |     336 B |
| Encrypt · ChaCha20-Poly1305 (SSSE3)        | 8KB          |  12,464.7 ns |    15.58 ns |    13.81 ns |         - |
| Encrypt · ChaCha20-Poly1305 (OS)           | 8KB          |  13,070.4 ns |    21.61 ns |    19.16 ns |         - |
| Encrypt · ChaCha20-Poly1305 (NaCl.Core)    | 8KB          |  18,413.4 ns |    74.31 ns |    69.51 ns |      72 B |
| Encrypt · ChaCha20-Poly1305 (Managed)      | 8KB          |  33,046.0 ns |    91.47 ns |    85.56 ns |         - |
|                                            |              |              |             |             |           |
| Decrypt · ChaCha20-Poly1305 (AVX2)         | 128KB        | 135,952.9 ns |   265.48 ns |   235.35 ns |         - |
| Decrypt · ChaCha20-Poly1305 (BouncyCastle) | 128KB        | 146,167.4 ns |   476.57 ns |   445.78 ns |     416 B |
| Decrypt · ChaCha20-Poly1305 (SSSE3)        | 128KB        | 195,038.8 ns |   421.76 ns |   394.52 ns |         - |
| Decrypt · ChaCha20-Poly1305 (OS)           | 128KB        | 207,395.9 ns |   431.00 ns |   382.07 ns |         - |
| Decrypt · ChaCha20-Poly1305 (NaCl.Core)    | 128KB        | 290,099.3 ns |   864.07 ns |   808.26 ns |      72 B |
| Decrypt · ChaCha20-Poly1305 (Managed)      | 128KB        | 523,820.9 ns | 1,431.76 ns | 1,195.58 ns |         - |
|                                            |              |              |             |             |           |
| Encrypt · ChaCha20-Poly1305 (AVX2)         | 128KB        | 136,154.7 ns |   233.89 ns |   218.78 ns |         - |
| Encrypt · ChaCha20-Poly1305 (BouncyCastle) | 128KB        | 148,246.3 ns |   392.28 ns |   366.94 ns |     336 B |
| Encrypt · ChaCha20-Poly1305 (SSSE3)        | 128KB        | 194,673.4 ns |   299.72 ns |   280.36 ns |         - |
| Encrypt · ChaCha20-Poly1305 (OS)           | 128KB        | 207,175.8 ns |   465.20 ns |   412.38 ns |         - |
| Encrypt · ChaCha20-Poly1305 (NaCl.Core)    | 128KB        | 290,566.8 ns |   754.65 ns |   705.90 ns |      72 B |
| Encrypt · ChaCha20-Poly1305 (Managed)      | 128KB        | 521,794.5 ns | 1,611.03 ns | 1,506.96 ns |         - |