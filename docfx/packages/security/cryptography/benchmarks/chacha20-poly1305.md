| Description                                | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|
| Decrypt · ChaCha20-Poly1305 (OS)           | 128B         |     351.3 ns |     5.35 ns |     5.00 ns |         - |
| Decrypt · ChaCha20-Poly1305 (AVX2)         | 128B         |     488.7 ns |     3.65 ns |     3.24 ns |         - |
| Decrypt · ChaCha20-Poly1305 (SSSE3)        | 128B         |     536.1 ns |     4.89 ns |     4.57 ns |         - |
| Decrypt · ChaCha20-Poly1305 (NaCl.Core)    | 128B         |     584.3 ns |     3.87 ns |     3.62 ns |      48 B |
| Decrypt · ChaCha20-Poly1305 (BouncyCastle) | 128B         |     720.5 ns |     9.45 ns |     8.84 ns |     416 B |
| Decrypt · ChaCha20-Poly1305 (Managed)      | 128B         |     862.6 ns |     4.60 ns |     4.07 ns |         - |
|                                            |              |              |             |             |           |
| Encrypt · ChaCha20-Poly1305 (OS)           | 128B         |     349.5 ns |     0.73 ns |     0.65 ns |         - |
| Encrypt · ChaCha20-Poly1305 (BouncyCastle) | 128B         |     416.5 ns |     0.80 ns |     0.71 ns |     336 B |
| Encrypt · ChaCha20-Poly1305 (AVX2)         | 128B         |     438.5 ns |     0.86 ns |     0.77 ns |         - |
| Encrypt · ChaCha20-Poly1305 (SSSE3)        | 128B         |     493.2 ns |     2.69 ns |     2.39 ns |         - |
| Encrypt · ChaCha20-Poly1305 (NaCl.Core)    | 128B         |     540.9 ns |     1.52 ns |     1.35 ns |      48 B |
| Encrypt · ChaCha20-Poly1305 (Managed)      | 128B         |     823.3 ns |     1.41 ns |     1.17 ns |         - |
|                                            |              |              |             |             |           |
| Decrypt · ChaCha20-Poly1305 (AVX2)         | 1KB          |   1,330.7 ns |     7.37 ns |     6.89 ns |         - |
| Decrypt · ChaCha20-Poly1305 (BouncyCastle) | 1KB          |   1,731.5 ns |    13.44 ns |    12.57 ns |     416 B |
| Decrypt · ChaCha20-Poly1305 (OS)           | 1KB          |   1,782.3 ns |     4.47 ns |     3.74 ns |         - |
| Decrypt · ChaCha20-Poly1305 (SSSE3)        | 1KB          |   1,838.8 ns |    34.29 ns |    32.08 ns |         - |
| Decrypt · ChaCha20-Poly1305 (NaCl.Core)    | 1KB          |   2,562.7 ns |     5.86 ns |     4.90 ns |      72 B |
| Decrypt · ChaCha20-Poly1305 (Managed)      | 1KB          |   4,396.2 ns |    37.59 ns |    35.16 ns |         - |
|                                            |              |              |             |             |           |
| Encrypt · ChaCha20-Poly1305 (AVX2)         | 1KB          |   1,275.1 ns |     2.41 ns |     2.13 ns |         - |
| Encrypt · ChaCha20-Poly1305 (BouncyCastle) | 1KB          |   1,412.8 ns |     2.96 ns |     2.47 ns |     336 B |
| Encrypt · ChaCha20-Poly1305 (SSSE3)        | 1KB          |   1,736.3 ns |     2.22 ns |     1.96 ns |         - |
| Encrypt · ChaCha20-Poly1305 (OS)           | 1KB          |   1,767.9 ns |     2.87 ns |     2.55 ns |         - |
| Encrypt · ChaCha20-Poly1305 (NaCl.Core)    | 1KB          |   2,536.6 ns |     5.04 ns |     4.21 ns |      72 B |
| Encrypt · ChaCha20-Poly1305 (Managed)      | 1KB          |   4,351.2 ns |    19.98 ns |    15.60 ns |         - |
|                                            |              |              |             |             |           |
| Decrypt · ChaCha20-Poly1305 (AVX2)         | 8KB          |   8,070.9 ns |    10.11 ns |     8.44 ns |         - |
| Decrypt · ChaCha20-Poly1305 (BouncyCastle) | 8KB          |   9,711.5 ns |   120.58 ns |   112.79 ns |     416 B |
| Decrypt · ChaCha20-Poly1305 (SSSE3)        | 8KB          |  11,699.9 ns |    17.75 ns |    14.82 ns |         - |
| Decrypt · ChaCha20-Poly1305 (OS)           | 8KB          |  13,230.2 ns |    32.50 ns |    30.40 ns |         - |
| Decrypt · ChaCha20-Poly1305 (NaCl.Core)    | 8KB          |  18,476.3 ns |    77.81 ns |    72.78 ns |      72 B |
| Decrypt · ChaCha20-Poly1305 (Managed)      | 8KB          |  33,245.8 ns |   554.62 ns |   518.80 ns |         - |
|                                            |              |              |             |             |           |
| Encrypt · ChaCha20-Poly1305 (AVX2)         | 8KB          |   7,994.3 ns |    14.96 ns |    13.26 ns |         - |
| Encrypt · ChaCha20-Poly1305 (BouncyCastle) | 8KB          |   9,357.0 ns |    39.41 ns |    30.77 ns |     336 B |
| Encrypt · ChaCha20-Poly1305 (SSSE3)        | 8KB          |  11,650.9 ns |    28.37 ns |    23.69 ns |         - |
| Encrypt · ChaCha20-Poly1305 (OS)           | 8KB          |  13,158.4 ns |    22.57 ns |    21.11 ns |         - |
| Encrypt · ChaCha20-Poly1305 (NaCl.Core)    | 8KB          |  18,086.7 ns |    44.77 ns |    34.95 ns |      72 B |
| Encrypt · ChaCha20-Poly1305 (Managed)      | 8KB          |  32,470.0 ns |    86.21 ns |    76.42 ns |         - |
|                                            |              |              |             |             |           |
| Decrypt · ChaCha20-Poly1305 (AVX2)         | 128KB        | 123,704.5 ns |   272.53 ns |   241.59 ns |         - |
| Decrypt · ChaCha20-Poly1305 (BouncyCastle) | 128KB        | 150,483.7 ns | 2,451.71 ns | 2,293.33 ns |     416 B |
| Decrypt · ChaCha20-Poly1305 (SSSE3)        | 128KB        | 181,907.7 ns |   390.27 ns |   345.97 ns |         - |
| Decrypt · ChaCha20-Poly1305 (OS)           | 128KB        | 209,438.9 ns |   360.13 ns |   336.87 ns |         - |
| Decrypt · ChaCha20-Poly1305 (NaCl.Core)    | 128KB        | 291,187.9 ns | 1,320.51 ns | 1,235.20 ns |      72 B |
| Decrypt · ChaCha20-Poly1305 (Managed)      | 128KB        | 525,997.5 ns | 7,243.07 ns | 6,775.17 ns |         - |
|                                            |              |              |             |             |           |
| Encrypt · ChaCha20-Poly1305 (AVX2)         | 128KB        | 123,451.7 ns |   340.11 ns |   284.01 ns |         - |
| Encrypt · ChaCha20-Poly1305 (BouncyCastle) | 128KB        | 150,276.5 ns | 2,469.60 ns | 2,189.24 ns |     336 B |
| Encrypt · ChaCha20-Poly1305 (SSSE3)        | 128KB        | 181,874.0 ns |   438.69 ns |   388.89 ns |         - |
| Encrypt · ChaCha20-Poly1305 (OS)           | 128KB        | 208,582.1 ns | 1,754.99 ns | 1,465.50 ns |         - |
| Encrypt · ChaCha20-Poly1305 (NaCl.Core)    | 128KB        | 293,817.0 ns | 1,989.52 ns | 1,861.00 ns |      72 B |
| Encrypt · ChaCha20-Poly1305 (Managed)      | 128KB        | 515,099.8 ns |   567.09 ns |   473.55 ns |         - |