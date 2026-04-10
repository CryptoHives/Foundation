| Description                                | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|
| Decrypt · ChaCha20-Poly1305 (OS)           | 128B         |     343.7 ns |     1.07 ns |     1.00 ns |         - |
| Decrypt · ChaCha20-Poly1305 (AVX2)         | 128B         |     492.3 ns |     3.04 ns |     2.69 ns |         - |
| Decrypt · ChaCha20-Poly1305 (SSSE3)        | 128B         |     555.8 ns |     1.78 ns |     1.58 ns |         - |
| Decrypt · ChaCha20-Poly1305 (NaCl.Core)    | 128B         |     580.9 ns |     2.71 ns |     2.54 ns |      48 B |
| Decrypt · ChaCha20-Poly1305 (BouncyCastle) | 128B         |     722.5 ns |     4.32 ns |     4.04 ns |     416 B |
| Decrypt · ChaCha20-Poly1305 (Managed)      | 128B         |     874.7 ns |     4.65 ns |     4.35 ns |         - |
|                                            |              |              |             |             |           |
| Encrypt · ChaCha20-Poly1305 (OS)           | 128B         |     347.7 ns |     2.07 ns |     1.93 ns |         - |
| Encrypt · ChaCha20-Poly1305 (BouncyCastle) | 128B         |     413.4 ns |     2.81 ns |     2.63 ns |     336 B |
| Encrypt · ChaCha20-Poly1305 (AVX2)         | 128B         |     453.0 ns |     0.48 ns |     0.40 ns |         - |
| Encrypt · ChaCha20-Poly1305 (SSSE3)        | 128B         |     511.8 ns |     1.32 ns |     1.23 ns |         - |
| Encrypt · ChaCha20-Poly1305 (NaCl.Core)    | 128B         |     537.7 ns |     2.15 ns |     2.01 ns |      48 B |
| Encrypt · ChaCha20-Poly1305 (Managed)      | 128B         |     839.4 ns |     2.95 ns |     2.76 ns |         - |
|                                            |              |              |             |             |           |
| Decrypt · ChaCha20-Poly1305 (AVX2)         | 1KB          |   1,414.4 ns |     4.24 ns |     3.76 ns |         - |
| Decrypt · ChaCha20-Poly1305 (BouncyCastle) | 1KB          |   1,704.7 ns |    15.15 ns |    14.18 ns |     416 B |
| Decrypt · ChaCha20-Poly1305 (OS)           | 1KB          |   1,759.7 ns |     4.59 ns |     3.59 ns |         - |
| Decrypt · ChaCha20-Poly1305 (SSSE3)        | 1KB          |   1,878.1 ns |     3.82 ns |     3.38 ns |         - |
| Decrypt · ChaCha20-Poly1305 (NaCl.Core)    | 1KB          |   2,588.4 ns |    12.26 ns |    10.87 ns |      72 B |
| Decrypt · ChaCha20-Poly1305 (Managed)      | 1KB          |   4,499.1 ns |    36.85 ns |    34.47 ns |         - |
|                                            |              |              |             |             |           |
| Encrypt · ChaCha20-Poly1305 (AVX2)         | 1KB          |   1,385.1 ns |     4.67 ns |     3.90 ns |         - |
| Encrypt · ChaCha20-Poly1305 (BouncyCastle) | 1KB          |   1,414.0 ns |     6.47 ns |     6.06 ns |     336 B |
| Encrypt · ChaCha20-Poly1305 (OS)           | 1KB          |   1,765.7 ns |    13.06 ns |    12.22 ns |         - |
| Encrypt · ChaCha20-Poly1305 (SSSE3)        | 1KB          |   1,843.6 ns |     3.63 ns |     3.03 ns |         - |
| Encrypt · ChaCha20-Poly1305 (NaCl.Core)    | 1KB          |   2,523.9 ns |    16.62 ns |    15.54 ns |      72 B |
| Encrypt · ChaCha20-Poly1305 (Managed)      | 1KB          |   4,439.3 ns |    15.95 ns |    14.92 ns |         - |
|                                            |              |              |             |             |           |
| Decrypt · ChaCha20-Poly1305 (AVX2)         | 8KB          |   8,863.6 ns |    36.07 ns |    33.74 ns |         - |
| Decrypt · ChaCha20-Poly1305 (BouncyCastle) | 8KB          |   9,509.2 ns |    55.85 ns |    49.51 ns |     416 B |
| Decrypt · ChaCha20-Poly1305 (SSSE3)        | 8KB          |  12,516.8 ns |    52.18 ns |    46.25 ns |         - |
| Decrypt · ChaCha20-Poly1305 (OS)           | 8KB          |  13,097.9 ns |    77.70 ns |    72.68 ns |         - |
| Decrypt · ChaCha20-Poly1305 (NaCl.Core)    | 8KB          |  18,262.3 ns |    67.09 ns |    59.48 ns |      72 B |
| Decrypt · ChaCha20-Poly1305 (Managed)      | 8KB          |  33,392.4 ns |   246.49 ns |   230.57 ns |         - |
|                                            |              |              |             |             |           |
| Encrypt · ChaCha20-Poly1305 (AVX2)         | 8KB          |   8,837.8 ns |    59.59 ns |    49.76 ns |         - |
| Encrypt · ChaCha20-Poly1305 (BouncyCastle) | 8KB          |   9,380.2 ns |    51.07 ns |    42.65 ns |     336 B |
| Encrypt · ChaCha20-Poly1305 (SSSE3)        | 8KB          |  12,453.3 ns |    30.92 ns |    24.14 ns |         - |
| Encrypt · ChaCha20-Poly1305 (OS)           | 8KB          |  13,074.5 ns |    30.54 ns |    25.51 ns |         - |
| Encrypt · ChaCha20-Poly1305 (NaCl.Core)    | 8KB          |  18,341.2 ns |    97.47 ns |    81.39 ns |      72 B |
| Encrypt · ChaCha20-Poly1305 (Managed)      | 8KB          |  33,275.6 ns |    87.65 ns |    77.70 ns |         - |
|                                            |              |              |             |             |           |
| Decrypt · ChaCha20-Poly1305 (AVX2)         | 128KB        | 136,207.9 ns |   561.81 ns |   525.51 ns |         - |
| Decrypt · ChaCha20-Poly1305 (BouncyCastle) | 128KB        | 146,934.2 ns |   827.71 ns |   774.24 ns |     416 B |
| Decrypt · ChaCha20-Poly1305 (SSSE3)        | 128KB        | 194,899.4 ns |   607.84 ns |   568.58 ns |         - |
| Decrypt · ChaCha20-Poly1305 (OS)           | 128KB        | 207,127.6 ns |   835.11 ns |   740.31 ns |         - |
| Decrypt · ChaCha20-Poly1305 (NaCl.Core)    | 128KB        | 294,152.7 ns | 1,535.66 ns | 1,361.32 ns |      72 B |
| Decrypt · ChaCha20-Poly1305 (Managed)      | 128KB        | 529,515.2 ns | 4,126.94 ns | 3,860.34 ns |         - |
|                                            |              |              |             |             |           |
| Encrypt · ChaCha20-Poly1305 (AVX2)         | 128KB        | 136,108.9 ns |   527.71 ns |   467.80 ns |         - |
| Encrypt · ChaCha20-Poly1305 (BouncyCastle) | 128KB        | 150,547.5 ns |   661.12 ns |   552.07 ns |     336 B |
| Encrypt · ChaCha20-Poly1305 (SSSE3)        | 128KB        | 194,713.4 ns |   419.26 ns |   371.66 ns |         - |
| Encrypt · ChaCha20-Poly1305 (OS)           | 128KB        | 208,041.6 ns |   813.05 ns |   720.74 ns |         - |
| Encrypt · ChaCha20-Poly1305 (NaCl.Core)    | 128KB        | 290,107.7 ns | 2,210.49 ns | 2,067.69 ns |      72 B |
| Encrypt · ChaCha20-Poly1305 (Managed)      | 128KB        | 528,761.8 ns | 3,137.35 ns | 2,934.68 ns |         - |