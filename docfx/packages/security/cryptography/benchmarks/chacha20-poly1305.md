| Description                                | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|
| Decrypt · ChaCha20-Poly1305 (OS)           | 128B         |     347.3 ns |     2.41 ns |     2.25 ns |         - |
| Decrypt · ChaCha20-Poly1305 (AVX2)         | 128B         |     480.6 ns |     3.10 ns |     2.59 ns |         - |
| Decrypt · ChaCha20-Poly1305 (SSSE3)        | 128B         |     538.8 ns |     4.62 ns |     4.09 ns |         - |
| Decrypt · ChaCha20-Poly1305 (NaCl.Core)    | 128B         |     586.2 ns |     4.06 ns |     3.60 ns |      48 B |
| Decrypt · ChaCha20-Poly1305 (BouncyCastle) | 128B         |     725.2 ns |     8.36 ns |     7.41 ns |     416 B |
| Decrypt · ChaCha20-Poly1305 (Managed)      | 128B         |     875.9 ns |     3.79 ns |     3.16 ns |         - |
|                                            |              |              |             |             |           |
| Encrypt · ChaCha20-Poly1305 (OS)           | 128B         |     349.0 ns |     1.10 ns |     0.92 ns |         - |
| Encrypt · ChaCha20-Poly1305 (BouncyCastle) | 128B         |     419.1 ns |     3.72 ns |     3.48 ns |     336 B |
| Encrypt · ChaCha20-Poly1305 (AVX2)         | 128B         |     446.6 ns |     1.09 ns |     0.91 ns |         - |
| Encrypt · ChaCha20-Poly1305 (SSSE3)        | 128B         |     498.4 ns |     3.99 ns |     3.54 ns |         - |
| Encrypt · ChaCha20-Poly1305 (NaCl.Core)    | 128B         |     541.5 ns |     3.74 ns |     3.32 ns |      48 B |
| Encrypt · ChaCha20-Poly1305 (Managed)      | 128B         |     830.9 ns |    13.51 ns |    11.98 ns |         - |
|                                            |              |              |             |             |           |
| Decrypt · ChaCha20-Poly1305 (AVX2)         | 1KB          |   1,326.4 ns |     7.49 ns |     6.64 ns |         - |
| Decrypt · ChaCha20-Poly1305 (BouncyCastle) | 1KB          |   1,730.0 ns |     6.53 ns |     5.45 ns |     416 B |
| Decrypt · ChaCha20-Poly1305 (OS)           | 1KB          |   1,775.3 ns |    16.74 ns |    15.65 ns |         - |
| Decrypt · ChaCha20-Poly1305 (SSSE3)        | 1KB          |   1,789.3 ns |     7.42 ns |     6.94 ns |         - |
| Decrypt · ChaCha20-Poly1305 (NaCl.Core)    | 1KB          |   2,607.2 ns |     9.30 ns |     7.76 ns |      72 B |
| Decrypt · ChaCha20-Poly1305 (Managed)      | 1KB          |   4,394.3 ns |    28.99 ns |    25.70 ns |         - |
|                                            |              |              |             |             |           |
| Encrypt · ChaCha20-Poly1305 (AVX2)         | 1KB          |   1,284.3 ns |     4.50 ns |     4.21 ns |         - |
| Encrypt · ChaCha20-Poly1305 (BouncyCastle) | 1KB          |   1,431.8 ns |     7.26 ns |     6.79 ns |     336 B |
| Encrypt · ChaCha20-Poly1305 (SSSE3)        | 1KB          |   1,744.5 ns |     8.80 ns |     7.80 ns |         - |
| Encrypt · ChaCha20-Poly1305 (OS)           | 1KB          |   1,770.6 ns |     9.46 ns |     8.38 ns |         - |
| Encrypt · ChaCha20-Poly1305 (NaCl.Core)    | 1KB          |   2,555.8 ns |     7.13 ns |     6.67 ns |      72 B |
| Encrypt · ChaCha20-Poly1305 (Managed)      | 1KB          |   4,380.1 ns |    49.34 ns |    43.74 ns |         - |
|                                            |              |              |             |             |           |
| Decrypt · ChaCha20-Poly1305 (AVX2)         | 8KB          |   8,068.7 ns |    30.30 ns |    28.34 ns |         - |
| Decrypt · ChaCha20-Poly1305 (BouncyCastle) | 8KB          |   9,564.0 ns |    68.18 ns |    60.44 ns |     416 B |
| Decrypt · ChaCha20-Poly1305 (SSSE3)        | 8KB          |  11,773.2 ns |    37.73 ns |    35.29 ns |         - |
| Decrypt · ChaCha20-Poly1305 (OS)           | 8KB          |  13,213.9 ns |   105.31 ns |    98.51 ns |         - |
| Decrypt · ChaCha20-Poly1305 (NaCl.Core)    | 8KB          |  18,456.0 ns |   114.04 ns |   106.67 ns |      72 B |
| Decrypt · ChaCha20-Poly1305 (Managed)      | 8KB          |  32,530.7 ns |   262.20 ns |   218.95 ns |         - |
|                                            |              |              |             |             |           |
| Encrypt · ChaCha20-Poly1305 (AVX2)         | 8KB          |   8,070.6 ns |    41.18 ns |    36.50 ns |         - |
| Encrypt · ChaCha20-Poly1305 (BouncyCastle) | 8KB          |   9,424.2 ns |    47.19 ns |    39.40 ns |     336 B |
| Encrypt · ChaCha20-Poly1305 (SSSE3)        | 8KB          |  11,828.2 ns |   129.66 ns |   121.28 ns |         - |
| Encrypt · ChaCha20-Poly1305 (OS)           | 8KB          |  13,144.9 ns |    94.78 ns |    79.14 ns |         - |
| Encrypt · ChaCha20-Poly1305 (NaCl.Core)    | 8KB          |  18,732.4 ns |   181.68 ns |   161.05 ns |      72 B |
| Encrypt · ChaCha20-Poly1305 (Managed)      | 8KB          |  32,477.6 ns |   238.35 ns |   186.09 ns |         - |
|                                            |              |              |             |             |           |
| Decrypt · ChaCha20-Poly1305 (AVX2)         | 128KB        | 124,151.9 ns |   783.98 ns |   694.98 ns |         - |
| Decrypt · ChaCha20-Poly1305 (BouncyCastle) | 128KB        | 147,744.8 ns |   560.25 ns |   496.65 ns |     416 B |
| Decrypt · ChaCha20-Poly1305 (SSSE3)        | 128KB        | 182,818.5 ns |   534.56 ns |   473.87 ns |         - |
| Decrypt · ChaCha20-Poly1305 (OS)           | 128KB        | 210,194.6 ns | 2,796.69 ns | 2,479.19 ns |         - |
| Decrypt · ChaCha20-Poly1305 (NaCl.Core)    | 128KB        | 297,411.5 ns | 2,243.45 ns | 2,098.52 ns |      72 B |
| Decrypt · ChaCha20-Poly1305 (Managed)      | 128KB        | 517,826.7 ns | 5,727.39 ns | 5,077.18 ns |         - |
|                                            |              |              |             |             |           |
| Encrypt · ChaCha20-Poly1305 (AVX2)         | 128KB        | 124,285.7 ns |   353.09 ns |   313.00 ns |         - |
| Encrypt · ChaCha20-Poly1305 (BouncyCastle) | 128KB        | 149,875.3 ns | 1,731.09 ns | 1,534.56 ns |     336 B |
| Encrypt · ChaCha20-Poly1305 (SSSE3)        | 128KB        | 183,078.7 ns | 1,260.31 ns | 1,178.89 ns |         - |
| Encrypt · ChaCha20-Poly1305 (OS)           | 128KB        | 207,695.9 ns |   957.84 ns |   747.82 ns |         - |
| Encrypt · ChaCha20-Poly1305 (NaCl.Core)    | 128KB        | 294,063.4 ns | 4,419.74 ns | 4,134.23 ns |      72 B |
| Encrypt · ChaCha20-Poly1305 (Managed)      | 128KB        | 513,274.5 ns | 2,619.84 ns | 2,450.60 ns |         - |