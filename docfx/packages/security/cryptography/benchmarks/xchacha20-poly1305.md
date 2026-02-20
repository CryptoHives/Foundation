| Description                              | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|----------------------------------------- |------------- |-------------:|------------:|------------:|----------:|
| Decrypt · XChaCha20-Poly1305 (AVX2)      | 128B         |     714.1 ns |     1.33 ns |     1.25 ns |         - |
| Decrypt · XChaCha20-Poly1305 (SSSE3)     | 128B         |     762.9 ns |     1.79 ns |     1.59 ns |         - |
| Decrypt · XChaCha20-Poly1305 (NaCl.Core) | 128B         |     905.6 ns |     1.23 ns |     1.15 ns |      48 B |
| Decrypt · XChaCha20-Poly1305 (Managed)   | 128B         |   1,091.7 ns |     1.75 ns |     1.47 ns |         - |
|                                          |              |              |             |             |           |
| Encrypt · XChaCha20-Poly1305 (AVX2)      | 128B         |     673.2 ns |     8.51 ns |     7.96 ns |         - |
| Encrypt · XChaCha20-Poly1305 (SSSE3)     | 128B         |     728.6 ns |     9.36 ns |     8.75 ns |         - |
| Encrypt · XChaCha20-Poly1305 (NaCl.Core) | 128B         |     871.1 ns |     0.92 ns |     0.81 ns |      48 B |
| Encrypt · XChaCha20-Poly1305 (Managed)   | 128B         |   1,061.6 ns |    12.25 ns |    11.46 ns |         - |
|                                          |              |              |             |             |           |
| Decrypt · XChaCha20-Poly1305 (AVX2)      | 1KB          |   1,555.8 ns |     6.56 ns |     5.82 ns |         - |
| Decrypt · XChaCha20-Poly1305 (SSSE3)     | 1KB          |   2,009.2 ns |    15.02 ns |    12.54 ns |         - |
| Decrypt · XChaCha20-Poly1305 (NaCl.Core) | 1KB          |   4,045.1 ns |     7.78 ns |     7.28 ns |      72 B |
| Decrypt · XChaCha20-Poly1305 (Managed)   | 1KB          |   4,643.9 ns |     6.51 ns |     6.09 ns |         - |
|                                          |              |              |             |             |           |
| Encrypt · XChaCha20-Poly1305 (AVX2)      | 1KB          |   1,505.6 ns |     2.07 ns |     1.73 ns |         - |
| Encrypt · XChaCha20-Poly1305 (SSSE3)     | 1KB          |   1,969.9 ns |     7.17 ns |     6.71 ns |         - |
| Encrypt · XChaCha20-Poly1305 (NaCl.Core) | 1KB          |   4,104.2 ns |    77.08 ns |    79.16 ns |      72 B |
| Encrypt · XChaCha20-Poly1305 (Managed)   | 1KB          |   4,609.5 ns |    14.75 ns |    11.52 ns |         - |
|                                          |              |              |             |             |           |
| Decrypt · XChaCha20-Poly1305 (AVX2)      | 8KB          |   8,288.9 ns |    15.28 ns |    13.54 ns |         - |
| Decrypt · XChaCha20-Poly1305 (SSSE3)     | 8KB          |  11,917.5 ns |    24.82 ns |    23.22 ns |         - |
| Decrypt · XChaCha20-Poly1305 (NaCl.Core) | 8KB          |  29,523.6 ns |   583.64 ns |   624.49 ns |      72 B |
| Decrypt · XChaCha20-Poly1305 (Managed)   | 8KB          |  33,063.9 ns |   148.31 ns |   123.84 ns |         - |
|                                          |              |              |             |             |           |
| Encrypt · XChaCha20-Poly1305 (AVX2)      | 8KB          |   8,258.9 ns |    26.89 ns |    22.46 ns |         - |
| Encrypt · XChaCha20-Poly1305 (SSSE3)     | 8KB          |  11,921.2 ns |    64.16 ns |    56.88 ns |         - |
| Encrypt · XChaCha20-Poly1305 (NaCl.Core) | 8KB          |  29,130.9 ns |    68.04 ns |    56.82 ns |      72 B |
| Encrypt · XChaCha20-Poly1305 (Managed)   | 8KB          |  33,025.3 ns |   105.85 ns |    99.01 ns |         - |
|                                          |              |              |             |             |           |
| Decrypt · XChaCha20-Poly1305 (AVX2)      | 128KB        | 124,106.6 ns |   328.60 ns |   291.30 ns |         - |
| Decrypt · XChaCha20-Poly1305 (SSSE3)     | 128KB        | 182,150.3 ns |   618.00 ns |   516.06 ns |         - |
| Decrypt · XChaCha20-Poly1305 (NaCl.Core) | 128KB        | 459,092.6 ns | 1,039.35 ns |   972.21 ns |      72 B |
| Decrypt · XChaCha20-Poly1305 (Managed)   | 128KB        | 527,491.1 ns | 6,557.51 ns | 6,133.90 ns |         - |
|                                          |              |              |             |             |           |
| Encrypt · XChaCha20-Poly1305 (AVX2)      | 128KB        | 123,858.0 ns |   169.18 ns |   149.97 ns |         - |
| Encrypt · XChaCha20-Poly1305 (SSSE3)     | 128KB        | 181,886.9 ns |   233.68 ns |   182.44 ns |         - |
| Encrypt · XChaCha20-Poly1305 (NaCl.Core) | 128KB        | 459,032.3 ns | 1,338.86 ns | 1,252.37 ns |      72 B |
| Encrypt · XChaCha20-Poly1305 (Managed)   | 128KB        | 521,952.1 ns | 6,864.32 ns | 5,732.02 ns |         - |