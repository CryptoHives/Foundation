| Description                              | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|----------------------------------------- |------------- |-------------:|------------:|------------:|----------:|
| Decrypt · XChaCha20-Poly1305 (AVX2)      | 128B         |     700.9 ns |     1.58 ns |     1.48 ns |         - |
| Decrypt · XChaCha20-Poly1305 (SSSE3)     | 128B         |     766.1 ns |     1.61 ns |     1.35 ns |         - |
| Decrypt · XChaCha20-Poly1305 (NaCl.Core) | 128B         |     907.3 ns |     1.95 ns |     1.83 ns |      48 B |
| Decrypt · XChaCha20-Poly1305 (Managed)   | 128B         |   1,075.6 ns |     2.82 ns |     2.36 ns |         - |
|                                          |              |              |             |             |           |
| Encrypt · XChaCha20-Poly1305 (AVX2)      | 128B         |     651.1 ns |     2.24 ns |     1.99 ns |         - |
| Encrypt · XChaCha20-Poly1305 (SSSE3)     | 128B         |     708.9 ns |     1.97 ns |     1.84 ns |         - |
| Encrypt · XChaCha20-Poly1305 (NaCl.Core) | 128B         |     871.1 ns |     1.55 ns |     1.45 ns |      48 B |
| Encrypt · XChaCha20-Poly1305 (Managed)   | 128B         |   1,036.9 ns |     2.67 ns |     2.23 ns |         - |
|                                          |              |              |             |             |           |
| Decrypt · XChaCha20-Poly1305 (AVX2)      | 1KB          |   1,542.0 ns |     3.93 ns |     3.67 ns |         - |
| Decrypt · XChaCha20-Poly1305 (SSSE3)     | 1KB          |   2,008.0 ns |     5.53 ns |     4.90 ns |         - |
| Decrypt · XChaCha20-Poly1305 (NaCl.Core) | 1KB          |   4,063.8 ns |    12.38 ns |    11.58 ns |      72 B |
| Decrypt · XChaCha20-Poly1305 (Managed)   | 1KB          |   4,560.6 ns |     9.52 ns |     8.44 ns |         - |
|                                          |              |              |             |             |           |
| Encrypt · XChaCha20-Poly1305 (AVX2)      | 1KB          |   1,491.4 ns |     3.80 ns |     3.37 ns |         - |
| Encrypt · XChaCha20-Poly1305 (SSSE3)     | 1KB          |   1,963.3 ns |     3.75 ns |     3.33 ns |         - |
| Encrypt · XChaCha20-Poly1305 (NaCl.Core) | 1KB          |   4,025.6 ns |     6.62 ns |     6.19 ns |      72 B |
| Encrypt · XChaCha20-Poly1305 (Managed)   | 1KB          |   4,539.8 ns |    12.87 ns |    12.04 ns |         - |
|                                          |              |              |             |             |           |
| Decrypt · XChaCha20-Poly1305 (AVX2)      | 8KB          |   8,277.8 ns |    25.53 ns |    22.63 ns |         - |
| Decrypt · XChaCha20-Poly1305 (SSSE3)     | 8KB          |  11,904.3 ns |    14.05 ns |    11.73 ns |         - |
| Decrypt · XChaCha20-Poly1305 (NaCl.Core) | 8KB          |  29,478.6 ns |    50.42 ns |    47.16 ns |      72 B |
| Decrypt · XChaCha20-Poly1305 (Managed)   | 8KB          |  32,377.8 ns |    74.92 ns |    66.41 ns |         - |
|                                          |              |              |             |             |           |
| Encrypt · XChaCha20-Poly1305 (AVX2)      | 8KB          |   8,231.0 ns |    22.94 ns |    20.34 ns |         - |
| Encrypt · XChaCha20-Poly1305 (SSSE3)     | 8KB          |  11,888.7 ns |    18.64 ns |    17.44 ns |         - |
| Encrypt · XChaCha20-Poly1305 (NaCl.Core) | 8KB          |  28,923.2 ns |    84.92 ns |    79.44 ns |      72 B |
| Encrypt · XChaCha20-Poly1305 (Managed)   | 8KB          |  32,413.2 ns |   104.24 ns |    92.40 ns |         - |
|                                          |              |              |             |             |           |
| Decrypt · XChaCha20-Poly1305 (AVX2)      | 128KB        | 123,671.2 ns |   428.09 ns |   400.43 ns |         - |
| Decrypt · XChaCha20-Poly1305 (SSSE3)     | 128KB        | 182,051.7 ns |   250.06 ns |   221.67 ns |         - |
| Decrypt · XChaCha20-Poly1305 (NaCl.Core) | 128KB        | 462,978.3 ns | 1,014.63 ns |   949.08 ns |      72 B |
| Decrypt · XChaCha20-Poly1305 (Managed)   | 128KB        | 512,007.1 ns | 2,092.87 ns | 1,855.28 ns |         - |
|                                          |              |              |             |             |           |
| Encrypt · XChaCha20-Poly1305 (AVX2)      | 128KB        | 123,481.8 ns |   316.93 ns |   280.95 ns |         - |
| Encrypt · XChaCha20-Poly1305 (SSSE3)     | 128KB        | 182,054.7 ns |   291.44 ns |   272.61 ns |         - |
| Encrypt · XChaCha20-Poly1305 (NaCl.Core) | 128KB        | 465,119.3 ns |   914.17 ns |   855.12 ns |      72 B |
| Encrypt · XChaCha20-Poly1305 (Managed)   | 128KB        | 510,319.2 ns | 1,966.96 ns | 1,839.89 ns |         - |