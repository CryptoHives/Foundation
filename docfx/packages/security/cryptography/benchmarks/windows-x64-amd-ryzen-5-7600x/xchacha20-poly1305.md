| Description                              | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|----------------------------------------- |------------- |-------------:|------------:|------------:|----------:|
| Decrypt · XChaCha20-Poly1305 (AVX2)      | 128B         |     711.8 ns |     1.41 ns |     1.32 ns |         - |
| Decrypt · XChaCha20-Poly1305 (SSSE3)     | 128B         |     773.4 ns |     1.08 ns |     0.95 ns |         - |
| Decrypt · XChaCha20-Poly1305 (NaCl.Core) | 128B         |     909.0 ns |     2.28 ns |     2.13 ns |      48 B |
| Decrypt · XChaCha20-Poly1305 (Managed)   | 128B         |   1,089.9 ns |     2.44 ns |     2.04 ns |         - |
|                                          |              |              |             |             |           |
| Encrypt · XChaCha20-Poly1305 (AVX2)      | 128B         |     677.5 ns |     1.16 ns |     1.09 ns |         - |
| Encrypt · XChaCha20-Poly1305 (SSSE3)     | 128B         |     722.4 ns |     1.67 ns |     1.48 ns |         - |
| Encrypt · XChaCha20-Poly1305 (NaCl.Core) | 128B         |     869.7 ns |     2.92 ns |     2.73 ns |      48 B |
| Encrypt · XChaCha20-Poly1305 (Managed)   | 128B         |   1,048.1 ns |     2.38 ns |     2.23 ns |         - |
|                                          |              |              |             |             |           |
| Decrypt · XChaCha20-Poly1305 (AVX2)      | 1KB          |   1,644.5 ns |     2.44 ns |     2.29 ns |         - |
| Decrypt · XChaCha20-Poly1305 (SSSE3)     | 1KB          |   2,093.9 ns |     6.57 ns |     5.83 ns |         - |
| Decrypt · XChaCha20-Poly1305 (NaCl.Core) | 1KB          |   4,055.2 ns |     7.99 ns |     7.47 ns |      72 B |
| Decrypt · XChaCha20-Poly1305 (Managed)   | 1KB          |   4,683.0 ns |    12.10 ns |    11.32 ns |         - |
|                                          |              |              |             |             |           |
| Encrypt · XChaCha20-Poly1305 (AVX2)      | 1KB          |   1,614.7 ns |     3.56 ns |     3.33 ns |         - |
| Encrypt · XChaCha20-Poly1305 (SSSE3)     | 1KB          |   2,064.1 ns |     4.24 ns |     3.96 ns |         - |
| Encrypt · XChaCha20-Poly1305 (NaCl.Core) | 1KB          |   4,006.1 ns |    11.82 ns |    11.06 ns |      72 B |
| Encrypt · XChaCha20-Poly1305 (Managed)   | 1KB          |   4,641.6 ns |    14.24 ns |    12.62 ns |         - |
|                                          |              |              |             |             |           |
| Decrypt · XChaCha20-Poly1305 (AVX2)      | 8KB          |   9,049.9 ns |    18.96 ns |    17.74 ns |         - |
| Decrypt · XChaCha20-Poly1305 (SSSE3)     | 8KB          |  12,702.9 ns |    17.14 ns |    16.03 ns |         - |
| Decrypt · XChaCha20-Poly1305 (NaCl.Core) | 8KB          |  29,833.9 ns |    52.50 ns |    49.11 ns |      72 B |
| Decrypt · XChaCha20-Poly1305 (Managed)   | 8KB          |  33,381.3 ns |    54.40 ns |    45.42 ns |         - |
|                                          |              |              |             |             |           |
| Encrypt · XChaCha20-Poly1305 (AVX2)      | 8KB          |   9,000.6 ns |    19.02 ns |    15.88 ns |         - |
| Encrypt · XChaCha20-Poly1305 (SSSE3)     | 8KB          |  12,667.5 ns |    21.09 ns |    19.73 ns |         - |
| Encrypt · XChaCha20-Poly1305 (NaCl.Core) | 8KB          |  28,907.1 ns |    60.41 ns |    50.44 ns |      72 B |
| Encrypt · XChaCha20-Poly1305 (Managed)   | 8KB          |  33,415.0 ns |    72.35 ns |    64.14 ns |         - |
|                                          |              |              |             |             |           |
| Decrypt · XChaCha20-Poly1305 (AVX2)      | 128KB        | 136,009.0 ns |   287.15 ns |   268.60 ns |         - |
| Decrypt · XChaCha20-Poly1305 (SSSE3)     | 128KB        | 194,660.2 ns |   188.91 ns |   176.71 ns |         - |
| Decrypt · XChaCha20-Poly1305 (NaCl.Core) | 128KB        | 477,540.7 ns | 1,322.76 ns | 1,237.31 ns |      72 B |
| Decrypt · XChaCha20-Poly1305 (Managed)   | 128KB        | 526,168.2 ns | 1,495.81 ns | 1,325.99 ns |         - |
|                                          |              |              |             |             |           |
| Encrypt · XChaCha20-Poly1305 (AVX2)      | 128KB        | 135,911.7 ns |   279.50 ns |   247.77 ns |         - |
| Encrypt · XChaCha20-Poly1305 (SSSE3)     | 128KB        | 194,509.1 ns |   449.56 ns |   420.52 ns |         - |
| Encrypt · XChaCha20-Poly1305 (NaCl.Core) | 128KB        | 459,900.0 ns | 1,110.54 ns | 1,038.80 ns |      72 B |
| Encrypt · XChaCha20-Poly1305 (Managed)   | 128KB        | 526,384.1 ns | 1,903.84 ns | 1,780.85 ns |         - |