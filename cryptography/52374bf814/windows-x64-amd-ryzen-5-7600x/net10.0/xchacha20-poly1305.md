| Description                              | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|----------------------------------------- |------------- |-------------:|------------:|------------:|----------:|
| Decrypt · XChaCha20-Poly1305 (AVX2)      | 128B         |     703.5 ns |     1.32 ns |     1.23 ns |         - |
| Decrypt · XChaCha20-Poly1305 (SSSE3)     | 128B         |     760.0 ns |     2.12 ns |     1.98 ns |         - |
| Decrypt · XChaCha20-Poly1305 (NaCl.Core) | 128B         |     906.8 ns |     2.78 ns |     2.60 ns |      48 B |
| Decrypt · XChaCha20-Poly1305 (Managed)   | 128B         |   1,075.9 ns |     4.32 ns |     3.61 ns |         - |
|                                          |              |              |             |             |           |
| Encrypt · XChaCha20-Poly1305 (AVX2)      | 128B         |     657.8 ns |     1.28 ns |     1.14 ns |         - |
| Encrypt · XChaCha20-Poly1305 (SSSE3)     | 128B         |     710.5 ns |     2.26 ns |     2.12 ns |         - |
| Encrypt · XChaCha20-Poly1305 (NaCl.Core) | 128B         |     873.6 ns |     1.55 ns |     1.45 ns |      48 B |
| Encrypt · XChaCha20-Poly1305 (Managed)   | 128B         |   1,033.9 ns |     2.27 ns |     2.01 ns |         - |
|                                          |              |              |             |             |           |
| Decrypt · XChaCha20-Poly1305 (AVX2)      | 1KB          |   1,536.6 ns |     5.78 ns |     4.83 ns |         - |
| Decrypt · XChaCha20-Poly1305 (SSSE3)     | 1KB          |   2,000.7 ns |     6.87 ns |     6.43 ns |         - |
| Decrypt · XChaCha20-Poly1305 (NaCl.Core) | 1KB          |   4,036.5 ns |     8.34 ns |     7.39 ns |      72 B |
| Decrypt · XChaCha20-Poly1305 (Managed)   | 1KB          |   4,558.1 ns |     5.82 ns |     4.86 ns |         - |
|                                          |              |              |             |             |           |
| Encrypt · XChaCha20-Poly1305 (AVX2)      | 1KB          |   1,493.3 ns |     3.93 ns |     3.67 ns |         - |
| Encrypt · XChaCha20-Poly1305 (SSSE3)     | 1KB          |   1,955.5 ns |     4.97 ns |     4.65 ns |         - |
| Encrypt · XChaCha20-Poly1305 (NaCl.Core) | 1KB          |   4,003.9 ns |    11.72 ns |    10.39 ns |      72 B |
| Encrypt · XChaCha20-Poly1305 (Managed)   | 1KB          |   4,516.6 ns |    10.57 ns |     8.83 ns |         - |
|                                          |              |              |             |             |           |
| Decrypt · XChaCha20-Poly1305 (AVX2)      | 8KB          |   8,284.5 ns |    31.68 ns |    29.63 ns |         - |
| Decrypt · XChaCha20-Poly1305 (SSSE3)     | 8KB          |  11,922.9 ns |    29.96 ns |    28.03 ns |         - |
| Decrypt · XChaCha20-Poly1305 (NaCl.Core) | 8KB          |  29,205.6 ns |    48.94 ns |    40.86 ns |      72 B |
| Decrypt · XChaCha20-Poly1305 (Managed)   | 8KB          |  32,367.0 ns |    90.79 ns |    75.81 ns |         - |
|                                          |              |              |             |             |           |
| Encrypt · XChaCha20-Poly1305 (AVX2)      | 8KB          |   8,219.1 ns |    30.35 ns |    28.39 ns |         - |
| Encrypt · XChaCha20-Poly1305 (SSSE3)     | 8KB          |  11,884.7 ns |    30.49 ns |    28.52 ns |         - |
| Encrypt · XChaCha20-Poly1305 (NaCl.Core) | 8KB          |  28,973.5 ns |    84.13 ns |    65.68 ns |      72 B |
| Encrypt · XChaCha20-Poly1305 (Managed)   | 8KB          |  32,474.5 ns |    91.77 ns |    81.36 ns |         - |
|                                          |              |              |             |             |           |
| Decrypt · XChaCha20-Poly1305 (AVX2)      | 128KB        | 123,746.1 ns |   348.59 ns |   326.07 ns |         - |
| Decrypt · XChaCha20-Poly1305 (SSSE3)     | 128KB        | 182,123.4 ns |   354.64 ns |   331.73 ns |         - |
| Decrypt · XChaCha20-Poly1305 (NaCl.Core) | 128KB        | 460,058.9 ns | 1,313.45 ns | 1,228.60 ns |      72 B |
| Decrypt · XChaCha20-Poly1305 (Managed)   | 128KB        | 510,279.3 ns | 1,301.11 ns | 1,217.06 ns |         - |
|                                          |              |              |             |             |           |
| Encrypt · XChaCha20-Poly1305 (AVX2)      | 128KB        | 123,615.0 ns |   287.51 ns |   254.87 ns |         - |
| Encrypt · XChaCha20-Poly1305 (SSSE3)     | 128KB        | 182,337.8 ns |   476.24 ns |   445.47 ns |         - |
| Encrypt · XChaCha20-Poly1305 (NaCl.Core) | 128KB        | 459,045.8 ns |   891.74 ns |   834.13 ns |      72 B |
| Encrypt · XChaCha20-Poly1305 (Managed)   | 128KB        | 509,389.8 ns | 2,092.12 ns | 1,956.97 ns |         - |