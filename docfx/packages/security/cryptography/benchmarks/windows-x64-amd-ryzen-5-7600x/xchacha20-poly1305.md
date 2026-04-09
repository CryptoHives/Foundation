| Description                              | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|----------------------------------------- |------------- |-------------:|------------:|------------:|----------:|
| Decrypt · XChaCha20-Poly1305 (AVX2)      | 128B         |     727.6 ns |     1.07 ns |     0.89 ns |         - |
| Decrypt · XChaCha20-Poly1305 (SSSE3)     | 128B         |     772.5 ns |     0.64 ns |     0.56 ns |         - |
| Decrypt · XChaCha20-Poly1305 (NaCl.Core) | 128B         |     910.4 ns |     1.88 ns |     1.66 ns |      48 B |
| Decrypt · XChaCha20-Poly1305 (Managed)   | 128B         |   1,110.2 ns |     1.57 ns |     1.40 ns |         - |
|                                          |              |              |             |             |           |
| Encrypt · XChaCha20-Poly1305 (AVX2)      | 128B         |     669.2 ns |     1.61 ns |     1.43 ns |         - |
| Encrypt · XChaCha20-Poly1305 (SSSE3)     | 128B         |     732.1 ns |     2.25 ns |     2.10 ns |         - |
| Encrypt · XChaCha20-Poly1305 (NaCl.Core) | 128B         |     870.6 ns |     1.37 ns |     1.28 ns |      48 B |
| Encrypt · XChaCha20-Poly1305 (Managed)   | 128B         |   1,047.4 ns |     2.41 ns |     2.25 ns |         - |
|                                          |              |              |             |             |           |
| Decrypt · XChaCha20-Poly1305 (AVX2)      | 1KB          |   1,652.8 ns |     1.80 ns |     1.69 ns |         - |
| Decrypt · XChaCha20-Poly1305 (SSSE3)     | 1KB          |   2,103.7 ns |     2.47 ns |     2.19 ns |         - |
| Decrypt · XChaCha20-Poly1305 (NaCl.Core) | 1KB          |   4,055.0 ns |     7.46 ns |     6.61 ns |      72 B |
| Decrypt · XChaCha20-Poly1305 (Managed)   | 1KB          |   4,743.1 ns |     6.65 ns |     5.19 ns |         - |
|                                          |              |              |             |             |           |
| Encrypt · XChaCha20-Poly1305 (AVX2)      | 1KB          |   1,609.0 ns |     3.59 ns |     3.18 ns |         - |
| Encrypt · XChaCha20-Poly1305 (SSSE3)     | 1KB          |   2,055.5 ns |     5.94 ns |     5.56 ns |         - |
| Encrypt · XChaCha20-Poly1305 (NaCl.Core) | 1KB          |   4,009.3 ns |     8.91 ns |     7.90 ns |      72 B |
| Encrypt · XChaCha20-Poly1305 (Managed)   | 1KB          |   4,623.1 ns |     9.56 ns |     8.47 ns |         - |
|                                          |              |              |             |             |           |
| Decrypt · XChaCha20-Poly1305 (AVX2)      | 8KB          |   9,078.8 ns |    11.72 ns |    10.96 ns |         - |
| Decrypt · XChaCha20-Poly1305 (SSSE3)     | 8KB          |  12,708.4 ns |    23.24 ns |    21.74 ns |         - |
| Decrypt · XChaCha20-Poly1305 (NaCl.Core) | 8KB          |  28,999.4 ns |    46.61 ns |    41.31 ns |      72 B |
| Decrypt · XChaCha20-Poly1305 (Managed)   | 8KB          |  33,879.2 ns |    37.21 ns |    31.07 ns |         - |
|                                          |              |              |             |             |           |
| Encrypt · XChaCha20-Poly1305 (AVX2)      | 8KB          |   9,039.3 ns |    20.29 ns |    18.98 ns |         - |
| Encrypt · XChaCha20-Poly1305 (SSSE3)     | 8KB          |  12,679.1 ns |    14.93 ns |    13.97 ns |         - |
| Encrypt · XChaCha20-Poly1305 (NaCl.Core) | 8KB          |  28,954.3 ns |    71.98 ns |    63.81 ns |      72 B |
| Encrypt · XChaCha20-Poly1305 (Managed)   | 8KB          |  33,322.9 ns |   114.07 ns |   106.70 ns |         - |
|                                          |              |              |             |             |           |
| Decrypt · XChaCha20-Poly1305 (AVX2)      | 128KB        | 136,462.9 ns |   173.88 ns |   154.14 ns |         - |
| Decrypt · XChaCha20-Poly1305 (SSSE3)     | 128KB        | 194,622.2 ns |   170.20 ns |   142.13 ns |         - |
| Decrypt · XChaCha20-Poly1305 (NaCl.Core) | 128KB        | 458,962.0 ns |   873.85 ns |   817.40 ns |      72 B |
| Decrypt · XChaCha20-Poly1305 (Managed)   | 128KB        | 532,351.9 ns |   565.99 ns |   472.63 ns |         - |
|                                          |              |              |             |             |           |
| Encrypt · XChaCha20-Poly1305 (AVX2)      | 128KB        | 136,213.9 ns |   407.85 ns |   381.50 ns |         - |
| Encrypt · XChaCha20-Poly1305 (SSSE3)     | 128KB        | 194,989.3 ns |   434.88 ns |   406.79 ns |         - |
| Encrypt · XChaCha20-Poly1305 (NaCl.Core) | 128KB        | 460,350.2 ns |   613.94 ns |   574.28 ns |      72 B |
| Encrypt · XChaCha20-Poly1305 (Managed)   | 128KB        | 532,604.5 ns | 3,192.68 ns | 2,666.03 ns |         - |