| Description                              | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|----------------------------------------- |------------- |-------------:|------------:|------------:|----------:|
| Decrypt · XChaCha20-Poly1305 (AVX2)      | 128B         |     709.2 ns |     7.35 ns |     6.51 ns |         - |
| Decrypt · XChaCha20-Poly1305 (SSSE3)     | 128B         |     764.6 ns |     5.68 ns |     5.31 ns |         - |
| Decrypt · XChaCha20-Poly1305 (NaCl.Core) | 128B         |     921.6 ns |     3.24 ns |     2.71 ns |      48 B |
| Decrypt · XChaCha20-Poly1305 (Managed)   | 128B         |   1,100.9 ns |    14.19 ns |    13.27 ns |         - |
|                                          |              |              |             |             |           |
| Encrypt · XChaCha20-Poly1305 (AVX2)      | 128B         |     661.8 ns |     6.15 ns |     5.75 ns |         - |
| Encrypt · XChaCha20-Poly1305 (SSSE3)     | 128B         |     718.2 ns |     6.70 ns |     6.26 ns |         - |
| Encrypt · XChaCha20-Poly1305 (NaCl.Core) | 128B         |     881.2 ns |     2.48 ns |     2.07 ns |      48 B |
| Encrypt · XChaCha20-Poly1305 (Managed)   | 128B         |   1,064.8 ns |    13.20 ns |    12.35 ns |         - |
|                                          |              |              |             |             |           |
| Decrypt · XChaCha20-Poly1305 (AVX2)      | 1KB          |   1,564.6 ns |     8.95 ns |     8.38 ns |         - |
| Decrypt · XChaCha20-Poly1305 (SSSE3)     | 1KB          |   2,022.1 ns |    25.98 ns |    24.30 ns |         - |
| Decrypt · XChaCha20-Poly1305 (NaCl.Core) | 1KB          |   4,113.0 ns |    60.99 ns |    54.07 ns |      72 B |
| Decrypt · XChaCha20-Poly1305 (Managed)   | 1KB          |   4,661.7 ns |    56.02 ns |    52.40 ns |         - |
|                                          |              |              |             |             |           |
| Encrypt · XChaCha20-Poly1305 (AVX2)      | 1KB          |   1,522.9 ns |     9.56 ns |     8.94 ns |         - |
| Encrypt · XChaCha20-Poly1305 (SSSE3)     | 1KB          |   1,982.4 ns |    20.80 ns |    19.46 ns |         - |
| Encrypt · XChaCha20-Poly1305 (NaCl.Core) | 1KB          |   4,072.2 ns |    31.65 ns |    29.61 ns |      72 B |
| Encrypt · XChaCha20-Poly1305 (Managed)   | 1KB          |   4,604.3 ns |    51.07 ns |    47.77 ns |         - |
|                                          |              |              |             |             |           |
| Decrypt · XChaCha20-Poly1305 (AVX2)      | 8KB          |   8,390.3 ns |    82.00 ns |    76.70 ns |         - |
| Decrypt · XChaCha20-Poly1305 (SSSE3)     | 8KB          |  12,289.4 ns |    52.75 ns |    49.34 ns |         - |
| Decrypt · XChaCha20-Poly1305 (NaCl.Core) | 8KB          |  29,337.0 ns |   131.83 ns |   123.32 ns |      72 B |
| Decrypt · XChaCha20-Poly1305 (Managed)   | 8KB          |  33,100.5 ns |   419.68 ns |   392.57 ns |         - |
|                                          |              |              |             |             |           |
| Encrypt · XChaCha20-Poly1305 (AVX2)      | 8KB          |   8,368.2 ns |    98.67 ns |    92.29 ns |         - |
| Encrypt · XChaCha20-Poly1305 (SSSE3)     | 8KB          |  12,033.1 ns |    45.12 ns |    42.21 ns |         - |
| Encrypt · XChaCha20-Poly1305 (NaCl.Core) | 8KB          |  29,573.6 ns |   200.00 ns |   187.08 ns |      72 B |
| Encrypt · XChaCha20-Poly1305 (Managed)   | 8KB          |  33,097.0 ns |   447.11 ns |   396.35 ns |         - |
|                                          |              |              |             |             |           |
| Decrypt · XChaCha20-Poly1305 (AVX2)      | 128KB        | 125,555.7 ns | 1,269.44 ns | 1,187.43 ns |         - |
| Decrypt · XChaCha20-Poly1305 (SSSE3)     | 128KB        | 184,498.6 ns |   869.86 ns |   813.67 ns |         - |
| Decrypt · XChaCha20-Poly1305 (NaCl.Core) | 128KB        | 466,232.5 ns | 2,212.12 ns | 1,847.22 ns |      72 B |
| Decrypt · XChaCha20-Poly1305 (Managed)   | 128KB        | 522,221.3 ns | 7,480.93 ns | 6,997.67 ns |         - |
|                                          |              |              |             |             |           |
| Encrypt · XChaCha20-Poly1305 (AVX2)      | 128KB        | 125,467.8 ns | 1,080.12 ns | 1,010.35 ns |         - |
| Encrypt · XChaCha20-Poly1305 (SSSE3)     | 128KB        | 183,993.5 ns |   584.72 ns |   518.34 ns |         - |
| Encrypt · XChaCha20-Poly1305 (NaCl.Core) | 128KB        | 465,928.4 ns | 3,452.22 ns | 2,695.27 ns |      72 B |
| Encrypt · XChaCha20-Poly1305 (Managed)   | 128KB        | 521,416.7 ns | 7,662.18 ns | 7,167.21 ns |         - |