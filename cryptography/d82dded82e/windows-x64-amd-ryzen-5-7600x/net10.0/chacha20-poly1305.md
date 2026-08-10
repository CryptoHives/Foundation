| Description                                | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|
| Decrypt · ChaCha20-Poly1305 (OS)           | 128B         |     342.9 ns |     2.01 ns |     1.88 ns |         - |
| Decrypt · ChaCha20-Poly1305 (AVX2)         | 128B         |     484.4 ns |     2.05 ns |     1.92 ns |         - |
| Decrypt · ChaCha20-Poly1305 (SSSE3)        | 128B         |     537.9 ns |     1.59 ns |     1.48 ns |         - |
| Decrypt · ChaCha20-Poly1305 (NaCl.Core)    | 128B         |     580.0 ns |     2.76 ns |     2.58 ns |      48 B |
| Decrypt · ChaCha20-Poly1305 (BouncyCastle) | 128B         |     706.4 ns |     2.50 ns |     2.34 ns |     416 B |
| Decrypt · ChaCha20-Poly1305 (Managed)      | 128B         |     857.5 ns |     1.64 ns |     1.54 ns |         - |
|                                            |              |              |             |             |           |
| Encrypt · ChaCha20-Poly1305 (OS)           | 128B         |     345.3 ns |     1.94 ns |     1.81 ns |         - |
| Encrypt · ChaCha20-Poly1305 (BouncyCastle) | 128B         |     414.3 ns |     1.39 ns |     1.30 ns |     336 B |
| Encrypt · ChaCha20-Poly1305 (AVX2)         | 128B         |     432.2 ns |     1.11 ns |     0.98 ns |         - |
| Encrypt · ChaCha20-Poly1305 (SSSE3)        | 128B         |     492.3 ns |     0.86 ns |     0.80 ns |         - |
| Encrypt · ChaCha20-Poly1305 (NaCl.Core)    | 128B         |     534.7 ns |     1.08 ns |     0.96 ns |      48 B |
| Encrypt · ChaCha20-Poly1305 (Managed)      | 128B         |     815.6 ns |     2.51 ns |     2.35 ns |         - |
|                                            |              |              |             |             |           |
| Decrypt · ChaCha20-Poly1305 (AVX2)         | 1KB          |   1,321.4 ns |     4.15 ns |     3.88 ns |         - |
| Decrypt · ChaCha20-Poly1305 (BouncyCastle) | 1KB          |   1,707.0 ns |     5.67 ns |     5.31 ns |     416 B |
| Decrypt · ChaCha20-Poly1305 (OS)           | 1KB          |   1,761.9 ns |     5.32 ns |     4.98 ns |         - |
| Decrypt · ChaCha20-Poly1305 (SSSE3)        | 1KB          |   1,786.6 ns |     4.79 ns |     4.49 ns |         - |
| Decrypt · ChaCha20-Poly1305 (NaCl.Core)    | 1KB          |   2,558.2 ns |    12.78 ns |    11.33 ns |      72 B |
| Decrypt · ChaCha20-Poly1305 (Managed)      | 1KB          |   4,361.5 ns |    17.12 ns |    16.01 ns |         - |
|                                            |              |              |             |             |           |
| Encrypt · ChaCha20-Poly1305 (AVX2)         | 1KB          |   1,277.0 ns |     2.91 ns |     2.72 ns |         - |
| Encrypt · ChaCha20-Poly1305 (BouncyCastle) | 1KB          |   1,407.6 ns |     6.31 ns |     5.90 ns |     336 B |
| Encrypt · ChaCha20-Poly1305 (SSSE3)        | 1KB          |   1,740.6 ns |     3.75 ns |     3.51 ns |         - |
| Encrypt · ChaCha20-Poly1305 (OS)           | 1KB          |   1,757.5 ns |     4.80 ns |     4.01 ns |         - |
| Encrypt · ChaCha20-Poly1305 (NaCl.Core)    | 1KB          |   2,515.5 ns |     4.03 ns |     3.77 ns |      72 B |
| Encrypt · ChaCha20-Poly1305 (Managed)      | 1KB          |   4,304.4 ns |    13.47 ns |    12.60 ns |         - |
|                                            |              |              |             |             |           |
| Decrypt · ChaCha20-Poly1305 (AVX2)         | 8KB          |   8,040.8 ns |    26.56 ns |    24.84 ns |         - |
| Decrypt · ChaCha20-Poly1305 (BouncyCastle) | 8KB          |   9,469.8 ns |    45.91 ns |    42.94 ns |     416 B |
| Decrypt · ChaCha20-Poly1305 (SSSE3)        | 8KB          |  11,700.6 ns |    21.87 ns |    19.39 ns |         - |
| Decrypt · ChaCha20-Poly1305 (OS)           | 8KB          |  13,100.2 ns |    33.91 ns |    30.06 ns |         - |
| Decrypt · ChaCha20-Poly1305 (NaCl.Core)    | 8KB          |  18,339.1 ns |    67.88 ns |    60.17 ns |      72 B |
| Decrypt · ChaCha20-Poly1305 (Managed)      | 8KB          |  32,291.3 ns |   167.18 ns |   156.38 ns |         - |
|                                            |              |              |             |             |           |
| Encrypt · ChaCha20-Poly1305 (AVX2)         | 8KB          |   8,004.1 ns |    16.82 ns |    15.73 ns |         - |
| Encrypt · ChaCha20-Poly1305 (BouncyCastle) | 8KB          |   9,355.4 ns |    48.10 ns |    42.64 ns |     336 B |
| Encrypt · ChaCha20-Poly1305 (SSSE3)        | 8KB          |  11,657.5 ns |    13.83 ns |    11.55 ns |         - |
| Encrypt · ChaCha20-Poly1305 (OS)           | 8KB          |  13,077.6 ns |    31.24 ns |    29.22 ns |         - |
| Encrypt · ChaCha20-Poly1305 (NaCl.Core)    | 8KB          |  18,221.4 ns |    36.85 ns |    32.67 ns |      72 B |
| Encrypt · ChaCha20-Poly1305 (Managed)      | 8KB          |  32,279.0 ns |    84.84 ns |    75.21 ns |         - |
|                                            |              |              |             |             |           |
| Decrypt · ChaCha20-Poly1305 (AVX2)         | 128KB        | 123,266.9 ns |   559.46 ns |   523.32 ns |         - |
| Decrypt · ChaCha20-Poly1305 (BouncyCastle) | 128KB        | 146,214.9 ns |   541.17 ns |   506.21 ns |     416 B |
| Decrypt · ChaCha20-Poly1305 (SSSE3)        | 128KB        | 181,971.8 ns |   365.01 ns |   341.43 ns |         - |
| Decrypt · ChaCha20-Poly1305 (OS)           | 128KB        | 206,938.3 ns |   453.29 ns |   424.01 ns |         - |
| Decrypt · ChaCha20-Poly1305 (NaCl.Core)    | 128KB        | 294,267.0 ns |   766.28 ns |   679.29 ns |      72 B |
| Decrypt · ChaCha20-Poly1305 (Managed)      | 128KB        | 511,743.0 ns | 2,026.45 ns | 1,895.54 ns |         - |
|                                            |              |              |             |             |           |
| Encrypt · ChaCha20-Poly1305 (AVX2)         | 128KB        | 123,349.9 ns |   476.94 ns |   446.13 ns |         - |
| Encrypt · ChaCha20-Poly1305 (BouncyCastle) | 128KB        | 148,023.3 ns |   388.90 ns |   344.75 ns |     336 B |
| Encrypt · ChaCha20-Poly1305 (SSSE3)        | 128KB        | 181,722.8 ns |   382.18 ns |   319.14 ns |         - |
| Encrypt · ChaCha20-Poly1305 (OS)           | 128KB        | 206,895.1 ns |   280.81 ns |   234.49 ns |         - |
| Encrypt · ChaCha20-Poly1305 (NaCl.Core)    | 128KB        | 287,722.4 ns | 1,433.12 ns | 1,340.54 ns |      72 B |
| Encrypt · ChaCha20-Poly1305 (Managed)      | 128KB        | 511,277.0 ns | 1,459.14 ns | 1,364.88 ns |         - |