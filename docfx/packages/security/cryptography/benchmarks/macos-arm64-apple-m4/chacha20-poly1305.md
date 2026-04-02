| Description                                | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|
| Decrypt · ChaCha20-Poly1305 (BouncyCastle) | 128B         |     684.7 ns |     0.99 ns |     0.93 ns |     416 B |
| Decrypt · ChaCha20-Poly1305 (Neon)         | 128B         |     725.1 ns |     3.68 ns |     3.44 ns |         - |
| Decrypt · ChaCha20-Poly1305 (NaCl.Core)    | 128B         |     822.1 ns |     0.42 ns |     0.33 ns |      48 B |
| Decrypt · ChaCha20-Poly1305 (Managed)      | 128B         |   1,314.5 ns |     9.14 ns |     8.55 ns |         - |
| Decrypt · ChaCha20-Poly1305 (OS)           | 128B         |   2,262.0 ns |    21.27 ns |    18.85 ns |         - |
|                                            |              |              |             |             |           |
| Encrypt · ChaCha20-Poly1305 (BouncyCastle) | 128B         |     493.7 ns |     1.23 ns |     1.15 ns |     336 B |
| Encrypt · ChaCha20-Poly1305 (Neon)         | 128B         |     655.5 ns |     2.59 ns |     2.29 ns |         - |
| Encrypt · ChaCha20-Poly1305 (NaCl.Core)    | 128B         |     790.9 ns |     0.15 ns |     0.14 ns |      48 B |
| Encrypt · ChaCha20-Poly1305 (Managed)      | 128B         |   1,207.0 ns |    18.02 ns |    16.85 ns |         - |
| Encrypt · ChaCha20-Poly1305 (OS)           | 128B         |   1,933.5 ns |    21.88 ns |    20.47 ns |         - |
|                                            |              |              |             |             |           |
| Decrypt · ChaCha20-Poly1305 (Neon)         | 1KB          |   2,333.8 ns |     0.98 ns |     0.82 ns |         - |
| Decrypt · ChaCha20-Poly1305 (BouncyCastle) | 1KB          |   2,395.5 ns |     4.30 ns |     4.02 ns |     416 B |
| Decrypt · ChaCha20-Poly1305 (OS)           | 1KB          |   3,155.5 ns |    18.22 ns |    17.04 ns |         - |
| Decrypt · ChaCha20-Poly1305 (NaCl.Core)    | 1KB          |   3,668.8 ns |     1.21 ns |     1.13 ns |      72 B |
| Decrypt · ChaCha20-Poly1305 (Managed)      | 1KB          |   6,721.7 ns |    20.85 ns |    19.50 ns |         - |
|                                            |              |              |             |             |           |
| Encrypt · ChaCha20-Poly1305 (BouncyCastle) | 1KB          |   2,195.2 ns |     4.44 ns |     3.70 ns |     336 B |
| Encrypt · ChaCha20-Poly1305 (Neon)         | 1KB          |   2,278.3 ns |     0.86 ns |     0.80 ns |         - |
| Encrypt · ChaCha20-Poly1305 (OS)           | 1KB          |   2,848.6 ns |    21.18 ns |    19.81 ns |         - |
| Encrypt · ChaCha20-Poly1305 (NaCl.Core)    | 1KB          |   3,625.7 ns |     0.83 ns |     0.77 ns |      72 B |
| Encrypt · ChaCha20-Poly1305 (Managed)      | 1KB          |   6,658.5 ns |    22.85 ns |    21.37 ns |         - |
|                                            |              |              |             |             |           |
| Decrypt · ChaCha20-Poly1305 (OS)           | 8KB          |  10,635.2 ns |    42.47 ns |    39.73 ns |         - |
| Decrypt · ChaCha20-Poly1305 (Neon)         | 8KB          |  14,726.0 ns |     9.83 ns |     9.19 ns |         - |
| Decrypt · ChaCha20-Poly1305 (BouncyCastle) | 8KB          |  15,766.2 ns |    42.70 ns |    39.94 ns |     416 B |
| Decrypt · ChaCha20-Poly1305 (NaCl.Core)    | 8KB          |  26,270.6 ns |     9.37 ns |     8.76 ns |      72 B |
| Decrypt · ChaCha20-Poly1305 (Managed)      | 8KB          |  48,278.6 ns |   137.24 ns |   128.37 ns |         - |
|                                            |              |              |             |             |           |
| Encrypt · ChaCha20-Poly1305 (OS)           | 8KB          |  10,135.5 ns |    49.14 ns |    45.96 ns |         - |
| Encrypt · ChaCha20-Poly1305 (Neon)         | 8KB          |  14,754.8 ns |     4.52 ns |     3.77 ns |         - |
| Encrypt · ChaCha20-Poly1305 (BouncyCastle) | 8KB          |  15,683.5 ns |    40.95 ns |    38.30 ns |     336 B |
| Encrypt · ChaCha20-Poly1305 (NaCl.Core)    | 8KB          |  26,311.4 ns |     8.07 ns |     7.15 ns |      72 B |
| Encrypt · ChaCha20-Poly1305 (Managed)      | 8KB          |  47,890.3 ns |   173.96 ns |   162.72 ns |         - |
|                                            |              |              |             |             |           |
| Decrypt · ChaCha20-Poly1305 (OS)           | 128KB        | 147,445.9 ns |   855.86 ns |   800.57 ns |         - |
| Decrypt · ChaCha20-Poly1305 (Neon)         | 128KB        | 228,291.2 ns |   170.33 ns |   159.33 ns |         - |
| Decrypt · ChaCha20-Poly1305 (BouncyCastle) | 128KB        | 247,358.2 ns |   713.67 ns |   667.57 ns |     416 B |
| Decrypt · ChaCha20-Poly1305 (NaCl.Core)    | 128KB        | 414,167.8 ns |   183.58 ns |   171.72 ns |      72 B |
| Decrypt · ChaCha20-Poly1305 (Managed)      | 128KB        | 761,690.2 ns | 3,038.17 ns | 2,841.91 ns |         - |
|                                            |              |              |             |             |           |
| Encrypt · ChaCha20-Poly1305 (OS)           | 128KB        | 136,972.2 ns |   815.14 ns |   762.49 ns |         - |
| Encrypt · ChaCha20-Poly1305 (Neon)         | 128KB        | 228,956.6 ns |    57.95 ns |    54.20 ns |         - |
| Encrypt · ChaCha20-Poly1305 (BouncyCastle) | 128KB        | 249,403.3 ns |   567.57 ns |   530.90 ns |     336 B |
| Encrypt · ChaCha20-Poly1305 (NaCl.Core)    | 128KB        | 414,330.5 ns |   165.82 ns |   147.00 ns |      72 B |
| Encrypt · ChaCha20-Poly1305 (Managed)      | 128KB        | 760,649.4 ns | 3,111.39 ns | 2,910.40 ns |         - |