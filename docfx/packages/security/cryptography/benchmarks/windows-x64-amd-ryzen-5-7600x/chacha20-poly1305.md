| Description                                | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|
| Decrypt · ChaCha20-Poly1305 (OS)           | 128B         |     343.3 ns |     1.67 ns |     1.56 ns |         - |
| Decrypt · ChaCha20-Poly1305 (AVX2)         | 128B         |     498.1 ns |     1.17 ns |     1.04 ns |         - |
| Decrypt · ChaCha20-Poly1305 (SSSE3)        | 128B         |     543.2 ns |     1.25 ns |     1.11 ns |         - |
| Decrypt · ChaCha20-Poly1305 (NaCl.Core)    | 128B         |     591.2 ns |     2.88 ns |     2.69 ns |      48 B |
| Decrypt · ChaCha20-Poly1305 (BouncyCastle) | 128B         |     717.0 ns |     4.98 ns |     4.66 ns |     416 B |
| Decrypt · ChaCha20-Poly1305 (Managed)      | 128B         |     867.7 ns |     2.58 ns |     2.42 ns |         - |
|                                            |              |              |             |             |           |
| Encrypt · ChaCha20-Poly1305 (OS)           | 128B         |     347.6 ns |     1.55 ns |     1.45 ns |         - |
| Encrypt · ChaCha20-Poly1305 (BouncyCastle) | 128B         |     414.4 ns |     1.25 ns |     1.11 ns |     336 B |
| Encrypt · ChaCha20-Poly1305 (AVX2)         | 128B         |     450.1 ns |     1.23 ns |     1.15 ns |         - |
| Encrypt · ChaCha20-Poly1305 (SSSE3)        | 128B         |     511.5 ns |     1.50 ns |     1.40 ns |         - |
| Encrypt · ChaCha20-Poly1305 (NaCl.Core)    | 128B         |     540.8 ns |     2.03 ns |     1.90 ns |      48 B |
| Encrypt · ChaCha20-Poly1305 (Managed)      | 128B         |     829.1 ns |     2.39 ns |     2.11 ns |         - |
|                                            |              |              |             |             |           |
| Decrypt · ChaCha20-Poly1305 (AVX2)         | 1KB          |   1,431.1 ns |     4.63 ns |     4.33 ns |         - |
| Decrypt · ChaCha20-Poly1305 (BouncyCastle) | 1KB          |   1,687.4 ns |     8.77 ns |     8.20 ns |     416 B |
| Decrypt · ChaCha20-Poly1305 (OS)           | 1KB          |   1,758.8 ns |     3.19 ns |     2.66 ns |         - |
| Decrypt · ChaCha20-Poly1305 (SSSE3)        | 1KB          |   1,873.6 ns |     3.10 ns |     2.59 ns |         - |
| Decrypt · ChaCha20-Poly1305 (NaCl.Core)    | 1KB          |   2,582.1 ns |    11.58 ns |    10.26 ns |      72 B |
| Decrypt · ChaCha20-Poly1305 (Managed)      | 1KB          |   4,469.5 ns |    20.27 ns |    18.96 ns |         - |
|                                            |              |              |             |             |           |
| Encrypt · ChaCha20-Poly1305 (AVX2)         | 1KB          |   1,382.3 ns |     3.09 ns |     2.74 ns |         - |
| Encrypt · ChaCha20-Poly1305 (BouncyCastle) | 1KB          |   1,406.1 ns |     6.87 ns |     6.42 ns |     336 B |
| Encrypt · ChaCha20-Poly1305 (OS)           | 1KB          |   1,758.3 ns |     3.70 ns |     3.28 ns |         - |
| Encrypt · ChaCha20-Poly1305 (SSSE3)        | 1KB          |   1,833.5 ns |     2.27 ns |     2.12 ns |         - |
| Encrypt · ChaCha20-Poly1305 (NaCl.Core)    | 1KB          |   2,550.6 ns |    10.05 ns |     9.40 ns |      72 B |
| Encrypt · ChaCha20-Poly1305 (Managed)      | 1KB          |   4,439.5 ns |    18.36 ns |    17.17 ns |         - |
|                                            |              |              |             |             |           |
| Decrypt · ChaCha20-Poly1305 (AVX2)         | 8KB          |   8,806.0 ns |    11.41 ns |     8.91 ns |         - |
| Decrypt · ChaCha20-Poly1305 (BouncyCastle) | 8KB          |   9,475.9 ns |    34.81 ns |    32.56 ns |     416 B |
| Decrypt · ChaCha20-Poly1305 (SSSE3)        | 8KB          |  12,498.3 ns |    17.18 ns |    16.07 ns |         - |
| Decrypt · ChaCha20-Poly1305 (OS)           | 8KB          |  13,098.9 ns |    44.94 ns |    42.04 ns |         - |
| Decrypt · ChaCha20-Poly1305 (NaCl.Core)    | 8KB          |  18,282.9 ns |    61.59 ns |    57.61 ns |      72 B |
| Decrypt · ChaCha20-Poly1305 (Managed)      | 8KB          |  33,154.4 ns |    67.44 ns |    52.66 ns |         - |
|                                            |              |              |             |             |           |
| Encrypt · ChaCha20-Poly1305 (AVX2)         | 8KB          |   8,791.8 ns |    20.22 ns |    17.92 ns |         - |
| Encrypt · ChaCha20-Poly1305 (BouncyCastle) | 8KB          |   9,333.1 ns |    20.90 ns |    16.32 ns |     336 B |
| Encrypt · ChaCha20-Poly1305 (SSSE3)        | 8KB          |  12,470.6 ns |    17.47 ns |    15.49 ns |         - |
| Encrypt · ChaCha20-Poly1305 (OS)           | 8KB          |  13,080.9 ns |    46.70 ns |    43.69 ns |         - |
| Encrypt · ChaCha20-Poly1305 (NaCl.Core)    | 8KB          |  18,196.0 ns |    64.01 ns |    59.87 ns |      72 B |
| Encrypt · ChaCha20-Poly1305 (Managed)      | 8KB          |  33,146.2 ns |   104.89 ns |    98.11 ns |         - |
|                                            |              |              |             |             |           |
| Decrypt · ChaCha20-Poly1305 (AVX2)         | 128KB        | 135,828.5 ns |   284.48 ns |   266.10 ns |         - |
| Decrypt · ChaCha20-Poly1305 (BouncyCastle) | 128KB        | 149,002.5 ns |   520.12 ns |   486.52 ns |     416 B |
| Decrypt · ChaCha20-Poly1305 (SSSE3)        | 128KB        | 194,238.1 ns |   295.43 ns |   276.34 ns |         - |
| Decrypt · ChaCha20-Poly1305 (OS)           | 128KB        | 207,564.0 ns | 1,208.13 ns | 1,130.09 ns |         - |
| Decrypt · ChaCha20-Poly1305 (NaCl.Core)    | 128KB        | 292,411.6 ns |   780.20 ns |   691.62 ns |      72 B |
| Decrypt · ChaCha20-Poly1305 (Managed)      | 128KB        | 527,024.1 ns | 1,500.86 ns | 1,403.90 ns |         - |
|                                            |              |              |             |             |           |
| Encrypt · ChaCha20-Poly1305 (AVX2)         | 128KB        | 135,785.5 ns |   123.29 ns |   109.29 ns |         - |
| Encrypt · ChaCha20-Poly1305 (BouncyCastle) | 128KB        | 148,093.9 ns |   354.29 ns |   314.07 ns |     336 B |
| Encrypt · ChaCha20-Poly1305 (SSSE3)        | 128KB        | 194,512.0 ns |   433.99 ns |   405.96 ns |         - |
| Encrypt · ChaCha20-Poly1305 (OS)           | 128KB        | 207,352.0 ns |   569.05 ns |   532.29 ns |         - |
| Encrypt · ChaCha20-Poly1305 (NaCl.Core)    | 128KB        | 293,708.6 ns | 1,130.33 ns | 1,057.31 ns |      72 B |
| Encrypt · ChaCha20-Poly1305 (Managed)      | 128KB        | 525,885.2 ns | 1,538.20 ns | 1,438.83 ns |         - |