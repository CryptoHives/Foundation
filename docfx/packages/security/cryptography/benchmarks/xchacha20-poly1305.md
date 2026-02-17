| Description                              | TestDataSize | Mean         | Error       | StdDev      | Median       | Allocated |
|----------------------------------------- |------------- |-------------:|------------:|------------:|-------------:|----------:|
| Decrypt · XChaCha20-Poly1305 (AVX2)      | 128B         |     716.4 ns |    12.44 ns |    11.63 ns |     715.3 ns |         - |
| Decrypt · XChaCha20-Poly1305 (SSSE3)     | 128B         |     772.1 ns |     7.40 ns |     6.93 ns |     770.4 ns |         - |
| Decrypt · XChaCha20-Poly1305 (NaCl.Core) | 128B         |     927.6 ns |    10.03 ns |     9.38 ns |     927.4 ns |      48 B |
| Decrypt · XChaCha20-Poly1305 (Managed)   | 128B         |   1,102.9 ns |    11.70 ns |     9.77 ns |   1,103.0 ns |         - |
|                                          |              |              |             |             |              |           |
| Encrypt · XChaCha20-Poly1305 (AVX2)      | 128B         |     667.1 ns |     9.82 ns |     9.18 ns |     665.5 ns |         - |
| Encrypt · XChaCha20-Poly1305 (SSSE3)     | 128B         |     717.8 ns |     4.83 ns |     4.29 ns |     717.4 ns |         - |
| Encrypt · XChaCha20-Poly1305 (NaCl.Core) | 128B         |     873.3 ns |     4.37 ns |     3.65 ns |     871.6 ns |      48 B |
| Encrypt · XChaCha20-Poly1305 (Managed)   | 128B         |   1,040.4 ns |     3.62 ns |     3.02 ns |   1,040.6 ns |         - |
|                                          |              |              |             |             |              |           |
| Decrypt · XChaCha20-Poly1305 (AVX2)      | 1KB          |   1,572.2 ns |    14.34 ns |    13.42 ns |   1,570.4 ns |         - |
| Decrypt · XChaCha20-Poly1305 (SSSE3)     | 1KB          |   2,057.3 ns |    39.92 ns |    47.52 ns |   2,027.0 ns |         - |
| Decrypt · XChaCha20-Poly1305 (NaCl.Core) | 1KB          |   4,162.5 ns |    68.79 ns |    64.34 ns |   4,142.1 ns |      72 B |
| Decrypt · XChaCha20-Poly1305 (Managed)   | 1KB          |   4,693.8 ns |    54.10 ns |    45.18 ns |   4,685.2 ns |         - |
|                                          |              |              |             |             |              |           |
| Encrypt · XChaCha20-Poly1305 (AVX2)      | 1KB          |   1,513.0 ns |     5.83 ns |     5.16 ns |   1,512.0 ns |         - |
| Encrypt · XChaCha20-Poly1305 (SSSE3)     | 1KB          |   1,973.8 ns |     5.31 ns |     4.44 ns |   1,973.9 ns |         - |
| Encrypt · XChaCha20-Poly1305 (NaCl.Core) | 1KB          |   4,089.3 ns |    64.91 ns |    60.71 ns |   4,062.3 ns |      72 B |
| Encrypt · XChaCha20-Poly1305 (Managed)   | 1KB          |   4,574.2 ns |    33.66 ns |    26.28 ns |   4,570.6 ns |         - |
|                                          |              |              |             |             |              |           |
| Decrypt · XChaCha20-Poly1305 (AVX2)      | 8KB          |   8,465.4 ns |    92.52 ns |    86.54 ns |   8,431.9 ns |         - |
| Decrypt · XChaCha20-Poly1305 (SSSE3)     | 8KB          |  12,100.5 ns |   171.46 ns |   151.99 ns |  12,042.4 ns |         - |
| Decrypt · XChaCha20-Poly1305 (NaCl.Core) | 8KB          |  29,316.3 ns |   298.13 ns |   278.87 ns |  29,242.2 ns |      72 B |
| Decrypt · XChaCha20-Poly1305 (Managed)   | 8KB          |  33,123.0 ns |   568.79 ns |   532.05 ns |  32,920.7 ns |         - |
|                                          |              |              |             |             |              |           |
| Encrypt · XChaCha20-Poly1305 (AVX2)      | 8KB          |   8,463.6 ns |   132.30 ns |   123.76 ns |   8,412.1 ns |         - |
| Encrypt · XChaCha20-Poly1305 (SSSE3)     | 8KB          |  12,195.4 ns |   208.66 ns |   195.18 ns |  12,163.8 ns |         - |
| Encrypt · XChaCha20-Poly1305 (NaCl.Core) | 8KB          |  29,830.0 ns |   330.22 ns |   308.89 ns |  29,795.5 ns |      72 B |
| Encrypt · XChaCha20-Poly1305 (Managed)   | 8KB          |  33,005.0 ns |   494.65 ns |   438.49 ns |  32,819.6 ns |         - |
|                                          |              |              |             |             |              |           |
| Decrypt · XChaCha20-Poly1305 (AVX2)      | 128KB        | 126,419.7 ns | 2,399.06 ns | 2,356.20 ns | 125,907.9 ns |         - |
| Decrypt · XChaCha20-Poly1305 (SSSE3)     | 128KB        | 185,921.7 ns | 2,682.58 ns | 2,509.28 ns | 184,825.4 ns |         - |
| Decrypt · XChaCha20-Poly1305 (NaCl.Core) | 128KB        | 462,726.8 ns | 3,171.31 ns | 2,811.29 ns | 462,314.2 ns |      72 B |
| Decrypt · XChaCha20-Poly1305 (Managed)   | 128KB        | 516,694.4 ns | 2,967.57 ns | 2,478.06 ns | 517,097.0 ns |         - |
|                                          |              |              |             |             |              |           |
| Encrypt · XChaCha20-Poly1305 (AVX2)      | 128KB        | 127,365.8 ns | 2,357.60 ns | 2,315.48 ns | 126,421.2 ns |         - |
| Encrypt · XChaCha20-Poly1305 (SSSE3)     | 128KB        | 186,507.0 ns | 2,676.39 ns | 2,372.55 ns | 185,843.8 ns |         - |
| Encrypt · XChaCha20-Poly1305 (NaCl.Core) | 128KB        | 466,442.5 ns | 5,137.66 ns | 4,554.40 ns | 466,191.7 ns |      72 B |
| Encrypt · XChaCha20-Poly1305 (Managed)   | 128KB        | 525,858.0 ns | 5,860.18 ns | 5,194.90 ns | 526,366.6 ns |         - |