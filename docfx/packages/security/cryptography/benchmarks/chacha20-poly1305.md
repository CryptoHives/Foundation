| Description                                | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|
| Decrypt · ChaCha20-Poly1305 (OS)           | 128B         |     343.4 ns |     1.40 ns |     1.17 ns |         - |
| Decrypt · ChaCha20-Poly1305 (AVX2)         | 128B         |     483.9 ns |     1.61 ns |     1.51 ns |         - |
| Decrypt · ChaCha20-Poly1305 (SSSE3)        | 128B         |     544.8 ns |     1.72 ns |     1.44 ns |         - |
| Decrypt · ChaCha20-Poly1305 (NaCl.Core)    | 128B         |     587.7 ns |     2.35 ns |     2.20 ns |      48 B |
| Decrypt · ChaCha20-Poly1305 (BouncyCastle) | 128B         |     702.8 ns |     2.14 ns |     1.90 ns |     416 B |
| Decrypt · ChaCha20-Poly1305 (Managed)      | 128B         |     851.9 ns |     1.73 ns |     1.53 ns |         - |
|                                            |              |              |             |             |           |
| Encrypt · ChaCha20-Poly1305 (OS)           | 128B         |     344.1 ns |     0.88 ns |     0.82 ns |         - |
| Encrypt · ChaCha20-Poly1305 (BouncyCastle) | 128B         |     410.2 ns |     1.57 ns |     1.39 ns |     336 B |
| Encrypt · ChaCha20-Poly1305 (AVX2)         | 128B         |     435.5 ns |     1.44 ns |     1.35 ns |         - |
| Encrypt · ChaCha20-Poly1305 (SSSE3)        | 128B         |     493.1 ns |     1.84 ns |     1.63 ns |         - |
| Encrypt · ChaCha20-Poly1305 (NaCl.Core)    | 128B         |     533.8 ns |     2.21 ns |     2.07 ns |      48 B |
| Encrypt · ChaCha20-Poly1305 (Managed)      | 128B         |     813.5 ns |     1.14 ns |     1.01 ns |         - |
|                                            |              |              |             |             |           |
| Decrypt · ChaCha20-Poly1305 (AVX2)         | 1KB          |   1,329.3 ns |     4.12 ns |     3.86 ns |         - |
| Decrypt · ChaCha20-Poly1305 (BouncyCastle) | 1KB          |   1,686.0 ns |     5.73 ns |     5.36 ns |     416 B |
| Decrypt · ChaCha20-Poly1305 (OS)           | 1KB          |   1,757.5 ns |     3.96 ns |     3.71 ns |         - |
| Decrypt · ChaCha20-Poly1305 (SSSE3)        | 1KB          |   1,781.1 ns |     1.81 ns |     1.60 ns |         - |
| Decrypt · ChaCha20-Poly1305 (NaCl.Core)    | 1KB          |   2,569.9 ns |     8.78 ns |     7.79 ns |      72 B |
| Decrypt · ChaCha20-Poly1305 (Managed)      | 1KB          |   4,354.0 ns |    10.84 ns |     9.61 ns |         - |
|                                            |              |              |             |             |           |
| Encrypt · ChaCha20-Poly1305 (AVX2)         | 1KB          |   1,279.7 ns |     3.96 ns |     3.51 ns |         - |
| Encrypt · ChaCha20-Poly1305 (BouncyCastle) | 1KB          |   1,405.7 ns |     4.57 ns |     4.05 ns |     336 B |
| Encrypt · ChaCha20-Poly1305 (SSSE3)        | 1KB          |   1,732.6 ns |     3.63 ns |     3.39 ns |         - |
| Encrypt · ChaCha20-Poly1305 (OS)           | 1KB          |   1,760.2 ns |     4.98 ns |     4.41 ns |         - |
| Encrypt · ChaCha20-Poly1305 (NaCl.Core)    | 1KB          |   2,520.5 ns |     7.71 ns |     7.21 ns |      72 B |
| Encrypt · ChaCha20-Poly1305 (Managed)      | 1KB          |   4,314.8 ns |    15.59 ns |    14.58 ns |         - |
|                                            |              |              |             |             |           |
| Decrypt · ChaCha20-Poly1305 (AVX2)         | 8KB          |   8,058.2 ns |    17.99 ns |    15.03 ns |         - |
| Decrypt · ChaCha20-Poly1305 (BouncyCastle) | 8KB          |   9,524.8 ns |    31.80 ns |    29.74 ns |     416 B |
| Decrypt · ChaCha20-Poly1305 (SSSE3)        | 8KB          |  11,745.4 ns |    25.26 ns |    23.63 ns |         - |
| Decrypt · ChaCha20-Poly1305 (OS)           | 8KB          |  13,090.6 ns |    30.89 ns |    28.90 ns |         - |
| Decrypt · ChaCha20-Poly1305 (NaCl.Core)    | 8KB          |  18,255.1 ns |    65.64 ns |    58.19 ns |      72 B |
| Decrypt · ChaCha20-Poly1305 (Managed)      | 8KB          |  32,238.9 ns |   123.39 ns |   115.42 ns |         - |
|                                            |              |              |             |             |           |
| Encrypt · ChaCha20-Poly1305 (AVX2)         | 8KB          |   8,001.8 ns |    17.62 ns |    16.48 ns |         - |
| Encrypt · ChaCha20-Poly1305 (BouncyCastle) | 8KB          |   9,379.7 ns |    27.01 ns |    23.94 ns |     336 B |
| Encrypt · ChaCha20-Poly1305 (SSSE3)        | 8KB          |  11,663.3 ns |    22.69 ns |    20.11 ns |         - |
| Encrypt · ChaCha20-Poly1305 (OS)           | 8KB          |  13,078.6 ns |    20.86 ns |    16.29 ns |         - |
| Encrypt · ChaCha20-Poly1305 (NaCl.Core)    | 8KB          |  18,321.6 ns |    27.37 ns |    25.60 ns |      72 B |
| Encrypt · ChaCha20-Poly1305 (Managed)      | 8KB          |  32,121.4 ns |    51.78 ns |    45.90 ns |         - |
|                                            |              |              |             |             |           |
| Decrypt · ChaCha20-Poly1305 (AVX2)         | 128KB        | 123,240.4 ns |   301.99 ns |   267.71 ns |         - |
| Decrypt · ChaCha20-Poly1305 (BouncyCastle) | 128KB        | 146,166.6 ns |   397.51 ns |   352.39 ns |     416 B |
| Decrypt · ChaCha20-Poly1305 (SSSE3)        | 128KB        | 181,960.6 ns |   345.25 ns |   322.94 ns |         - |
| Decrypt · ChaCha20-Poly1305 (OS)           | 128KB        | 207,022.0 ns |   451.56 ns |   422.39 ns |         - |
| Decrypt · ChaCha20-Poly1305 (NaCl.Core)    | 128KB        | 290,079.1 ns |   880.62 ns |   780.64 ns |      72 B |
| Decrypt · ChaCha20-Poly1305 (Managed)      | 128KB        | 509,258.5 ns | 1,103.49 ns |   978.22 ns |         - |
|                                            |              |              |             |             |           |
| Encrypt · ChaCha20-Poly1305 (AVX2)         | 128KB        | 123,418.3 ns |   373.91 ns |   349.75 ns |         - |
| Encrypt · ChaCha20-Poly1305 (BouncyCastle) | 128KB        | 149,717.1 ns |   289.73 ns |   241.94 ns |     336 B |
| Encrypt · ChaCha20-Poly1305 (SSSE3)        | 128KB        | 181,813.4 ns |   220.76 ns |   172.36 ns |         - |
| Encrypt · ChaCha20-Poly1305 (OS)           | 128KB        | 206,726.5 ns |   358.65 ns |   335.48 ns |         - |
| Encrypt · ChaCha20-Poly1305 (NaCl.Core)    | 128KB        | 291,947.3 ns |   816.79 ns |   724.06 ns |      72 B |
| Encrypt · ChaCha20-Poly1305 (Managed)      | 128KB        | 510,841.0 ns | 1,617.21 ns | 1,350.44 ns |         - |