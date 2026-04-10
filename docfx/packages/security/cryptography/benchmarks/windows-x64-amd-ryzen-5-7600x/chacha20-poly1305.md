| Description                                | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|
| Decrypt · ChaCha20-Poly1305 (OS)           | 128B         |     354.6 ns |     5.26 ns |     4.92 ns |         - |
| Decrypt · ChaCha20-Poly1305 (AVX2)         | 128B         |     502.3 ns |     6.26 ns |     5.55 ns |         - |
| Decrypt · ChaCha20-Poly1305 (SSSE3)        | 128B         |     565.9 ns |     6.35 ns |     5.94 ns |         - |
| Decrypt · ChaCha20-Poly1305 (NaCl.Core)    | 128B         |     591.5 ns |     6.21 ns |     5.81 ns |      48 B |
| Decrypt · ChaCha20-Poly1305 (BouncyCastle) | 128B         |     727.2 ns |    11.28 ns |    10.55 ns |     416 B |
| Decrypt · ChaCha20-Poly1305 (Managed)      | 128B         |     897.2 ns |     6.41 ns |     5.68 ns |         - |
|                                            |              |              |             |             |           |
| Encrypt · ChaCha20-Poly1305 (OS)           | 128B         |     360.1 ns |     5.42 ns |     6.45 ns |         - |
| Encrypt · ChaCha20-Poly1305 (BouncyCastle) | 128B         |     439.4 ns |     8.11 ns |     7.19 ns |     336 B |
| Encrypt · ChaCha20-Poly1305 (AVX2)         | 128B         |     466.3 ns |     8.68 ns |     8.12 ns |         - |
| Encrypt · ChaCha20-Poly1305 (SSSE3)        | 128B         |     517.6 ns |     9.49 ns |     8.88 ns |         - |
| Encrypt · ChaCha20-Poly1305 (NaCl.Core)    | 128B         |     553.4 ns |    10.31 ns |    11.03 ns |      48 B |
| Encrypt · ChaCha20-Poly1305 (Managed)      | 128B         |     850.6 ns |     6.63 ns |     5.18 ns |         - |
|                                            |              |              |             |             |           |
| Decrypt · ChaCha20-Poly1305 (AVX2)         | 1KB          |   1,431.9 ns |    12.77 ns |    11.94 ns |         - |
| Decrypt · ChaCha20-Poly1305 (BouncyCastle) | 1KB          |   1,755.7 ns |    21.34 ns |    18.91 ns |     416 B |
| Decrypt · ChaCha20-Poly1305 (OS)           | 1KB          |   1,791.0 ns |    17.87 ns |    16.71 ns |         - |
| Decrypt · ChaCha20-Poly1305 (SSSE3)        | 1KB          |   1,895.2 ns |    10.99 ns |    10.28 ns |         - |
| Decrypt · ChaCha20-Poly1305 (NaCl.Core)    | 1KB          |   2,649.4 ns |    21.82 ns |    20.41 ns |      72 B |
| Decrypt · ChaCha20-Poly1305 (Managed)      | 1KB          |   4,572.9 ns |    51.18 ns |    47.88 ns |         - |
|                                            |              |              |             |             |           |
| Encrypt · ChaCha20-Poly1305 (AVX2)         | 1KB          |   1,415.3 ns |     6.89 ns |     5.75 ns |         - |
| Encrypt · ChaCha20-Poly1305 (BouncyCastle) | 1KB          |   1,433.3 ns |    19.35 ns |    18.10 ns |     336 B |
| Encrypt · ChaCha20-Poly1305 (OS)           | 1KB          |   1,790.6 ns |    15.00 ns |    14.03 ns |         - |
| Encrypt · ChaCha20-Poly1305 (SSSE3)        | 1KB          |   1,859.7 ns |    12.43 ns |    11.02 ns |         - |
| Encrypt · ChaCha20-Poly1305 (NaCl.Core)    | 1KB          |   2,559.8 ns |    20.00 ns |    18.71 ns |      72 B |
| Encrypt · ChaCha20-Poly1305 (Managed)      | 1KB          |   4,520.5 ns |    39.50 ns |    36.95 ns |         - |
|                                            |              |              |             |             |           |
| Decrypt · ChaCha20-Poly1305 (AVX2)         | 8KB          |   8,921.3 ns |    77.49 ns |    72.48 ns |         - |
| Decrypt · ChaCha20-Poly1305 (BouncyCastle) | 8KB          |   9,784.2 ns |   147.59 ns |   138.06 ns |     416 B |
| Decrypt · ChaCha20-Poly1305 (SSSE3)        | 8KB          |  12,600.5 ns |    57.08 ns |    53.39 ns |         - |
| Decrypt · ChaCha20-Poly1305 (OS)           | 8KB          |  13,317.9 ns |    88.58 ns |    82.86 ns |         - |
| Decrypt · ChaCha20-Poly1305 (NaCl.Core)    | 8KB          |  18,463.4 ns |   218.37 ns |   182.35 ns |      72 B |
| Decrypt · ChaCha20-Poly1305 (Managed)      | 8KB          |  34,184.6 ns |   447.95 ns |   419.01 ns |         - |
|                                            |              |              |             |             |           |
| Encrypt · ChaCha20-Poly1305 (AVX2)         | 8KB          |   8,889.4 ns |    77.85 ns |    69.01 ns |         - |
| Encrypt · ChaCha20-Poly1305 (BouncyCastle) | 8KB          |   9,523.4 ns |    93.12 ns |    87.10 ns |     336 B |
| Encrypt · ChaCha20-Poly1305 (SSSE3)        | 8KB          |  12,562.9 ns |    79.71 ns |    74.56 ns |         - |
| Encrypt · ChaCha20-Poly1305 (OS)           | 8KB          |  13,346.6 ns |   122.66 ns |   114.74 ns |         - |
| Encrypt · ChaCha20-Poly1305 (NaCl.Core)    | 8KB          |  18,541.2 ns |   184.50 ns |   172.58 ns |      72 B |
| Encrypt · ChaCha20-Poly1305 (Managed)      | 8KB          |  34,130.3 ns |   431.37 ns |   382.40 ns |         - |
|                                            |              |              |             |             |           |
| Decrypt · ChaCha20-Poly1305 (AVX2)         | 128KB        | 137,766.1 ns | 1,127.34 ns |   999.36 ns |         - |
| Decrypt · ChaCha20-Poly1305 (BouncyCastle) | 128KB        | 150,349.9 ns | 2,450.15 ns | 2,045.99 ns |     416 B |
| Decrypt · ChaCha20-Poly1305 (SSSE3)        | 128KB        | 197,443.5 ns | 2,703.60 ns | 2,528.95 ns |         - |
| Decrypt · ChaCha20-Poly1305 (OS)           | 128KB        | 210,490.8 ns | 2,279.60 ns | 2,132.34 ns |         - |
| Decrypt · ChaCha20-Poly1305 (NaCl.Core)    | 128KB        | 299,737.8 ns | 2,973.90 ns | 2,781.79 ns |      72 B |
| Decrypt · ChaCha20-Poly1305 (Managed)      | 128KB        | 536,932.5 ns | 7,907.09 ns | 7,396.30 ns |         - |
|                                            |              |              |             |             |           |
| Encrypt · ChaCha20-Poly1305 (AVX2)         | 128KB        | 137,386.9 ns |   866.88 ns |   810.88 ns |         - |
| Encrypt · ChaCha20-Poly1305 (BouncyCastle) | 128KB        | 150,921.2 ns | 1,833.69 ns | 1,715.23 ns |     336 B |
| Encrypt · ChaCha20-Poly1305 (SSSE3)        | 128KB        | 196,070.4 ns | 1,190.39 ns | 1,055.25 ns |         - |
| Encrypt · ChaCha20-Poly1305 (OS)           | 128KB        | 210,620.7 ns | 1,710.41 ns | 1,599.92 ns |         - |
| Encrypt · ChaCha20-Poly1305 (NaCl.Core)    | 128KB        | 293,168.2 ns | 4,113.03 ns | 3,646.09 ns |      72 B |
| Encrypt · ChaCha20-Poly1305 (Managed)      | 128KB        | 536,801.9 ns | 6,371.50 ns | 5,959.91 ns |         - |