| Description                                | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|
| Decrypt · ChaCha20-Poly1305 (OS)           | 128B         |     349.1 ns |     3.16 ns |     2.95 ns |         - |
| Decrypt · ChaCha20-Poly1305 (SSSE3)        | 128B         |     545.7 ns |     8.27 ns |     7.74 ns |         - |
| Decrypt · ChaCha20-Poly1305 (BouncyCastle) | 128B         |     779.1 ns |    15.51 ns |    15.23 ns |     896 B |
| Decrypt · ChaCha20-Poly1305 (Managed)      | 128B         |     871.0 ns |    10.81 ns |     8.44 ns |         - |
|                                            |              |              |             |             |           |
| Encrypt · ChaCha20-Poly1305 (OS)           | 128B         |     350.8 ns |     4.46 ns |     3.96 ns |         - |
| Encrypt · ChaCha20-Poly1305 (BouncyCastle) | 128B         |     485.7 ns |     9.26 ns |    12.67 ns |     816 B |
| Encrypt · ChaCha20-Poly1305 (SSSE3)        | 128B         |     502.4 ns |     9.42 ns |     9.67 ns |         - |
| Encrypt · ChaCha20-Poly1305 (Managed)      | 128B         |     834.2 ns |    12.67 ns |    11.24 ns |         - |
|                                            |              |              |             |             |           |
| Decrypt · ChaCha20-Poly1305 (OS)           | 1KB          |   1,774.6 ns |    13.47 ns |    11.25 ns |         - |
| Decrypt · ChaCha20-Poly1305 (SSSE3)        | 1KB          |   1,806.0 ns |    28.03 ns |    27.53 ns |         - |
| Decrypt · ChaCha20-Poly1305 (BouncyCastle) | 1KB          |   1,875.7 ns |    34.05 ns |    30.19 ns |    2688 B |
| Decrypt · ChaCha20-Poly1305 (Managed)      | 1KB          |   4,421.9 ns |    58.83 ns |    52.15 ns |         - |
|                                            |              |              |             |             |           |
| Encrypt · ChaCha20-Poly1305 (BouncyCastle) | 1KB          |   1,555.4 ns |    30.61 ns |    28.64 ns |    2608 B |
| Encrypt · ChaCha20-Poly1305 (SSSE3)        | 1KB          |   1,752.9 ns |    20.15 ns |    18.85 ns |         - |
| Encrypt · ChaCha20-Poly1305 (OS)           | 1KB          |   1,775.2 ns |    16.06 ns |    14.24 ns |         - |
| Encrypt · ChaCha20-Poly1305 (Managed)      | 1KB          |   4,366.2 ns |    42.35 ns |    39.62 ns |         - |
|                                            |              |              |             |             |           |
| Decrypt · ChaCha20-Poly1305 (BouncyCastle) | 8KB          |  10,132.5 ns |    97.62 ns |    81.52 ns |   17024 B |
| Decrypt · ChaCha20-Poly1305 (SSSE3)        | 8KB          |  12,022.3 ns |   223.46 ns |   274.43 ns |         - |
| Decrypt · ChaCha20-Poly1305 (OS)           | 8KB          |  13,211.7 ns |    86.21 ns |    76.43 ns |         - |
| Decrypt · ChaCha20-Poly1305 (Managed)      | 8KB          |  32,813.2 ns |   573.30 ns |   536.26 ns |         - |
|                                            |              |              |             |             |           |
| Encrypt · ChaCha20-Poly1305 (BouncyCastle) | 8KB          |  10,138.6 ns |   187.96 ns |   175.82 ns |   16944 B |
| Encrypt · ChaCha20-Poly1305 (SSSE3)        | 8KB          |  11,782.1 ns |    75.59 ns |    59.02 ns |         - |
| Encrypt · ChaCha20-Poly1305 (OS)           | 8KB          |  13,237.6 ns |   133.20 ns |   124.59 ns |         - |
| Encrypt · ChaCha20-Poly1305 (Managed)      | 8KB          |  32,598.5 ns |   347.32 ns |   307.89 ns |         - |
|                                            |              |              |             |             |           |
| Decrypt · ChaCha20-Poly1305 (SSSE3)        | 128KB        | 186,038.5 ns | 3,612.25 ns | 3,709.52 ns |         - |
| Decrypt · ChaCha20-Poly1305 (BouncyCastle) | 128KB        | 208,939.6 ns | 2,885.28 ns | 2,698.89 ns |  262812 B |
| Decrypt · ChaCha20-Poly1305 (OS)           | 128KB        | 209,190.6 ns | 1,929.89 ns | 1,710.80 ns |         - |
| Decrypt · ChaCha20-Poly1305 (Managed)      | 128KB        | 517,015.1 ns | 5,153.00 ns | 4,302.99 ns |         - |
|                                            |              |              |             |             |           |
| Encrypt · ChaCha20-Poly1305 (SSSE3)        | 128KB        | 183,349.8 ns | 1,251.37 ns | 1,044.95 ns |         - |
| Encrypt · ChaCha20-Poly1305 (OS)           | 128KB        | 207,716.2 ns |   660.56 ns |   617.89 ns |         - |
| Encrypt · ChaCha20-Poly1305 (BouncyCastle) | 128KB        | 209,834.1 ns | 2,235.35 ns | 1,866.62 ns |  262732 B |
| Encrypt · ChaCha20-Poly1305 (Managed)      | 128KB        | 516,379.4 ns | 7,690.24 ns | 6,817.20 ns |         - |