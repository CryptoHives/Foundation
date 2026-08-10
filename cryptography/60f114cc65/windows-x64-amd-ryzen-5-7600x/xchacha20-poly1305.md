| Description                              | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|----------------------------------------- |------------- |-------------:|------------:|------------:|----------:|
| Decrypt · XChaCha20-Poly1305 (AVX2)      | 128B         |     550.6 ns |     2.01 ns |     1.88 ns |         - |
| Decrypt · XChaCha20-Poly1305 (SSSE3)     | 128B         |     608.0 ns |     3.53 ns |     3.30 ns |         - |
| Decrypt · XChaCha20-Poly1305 (NaCl.Core) | 128B         |     913.6 ns |     2.45 ns |     2.05 ns |      48 B |
| Decrypt · XChaCha20-Poly1305 (Managed)   | 128B         |   1,096.1 ns |     7.12 ns |     6.31 ns |         - |
|                                          |              |              |             |             |           |
| Encrypt · XChaCha20-Poly1305 (AVX2)      | 128B         |     499.8 ns |     3.26 ns |     3.05 ns |         - |
| Encrypt · XChaCha20-Poly1305 (SSSE3)     | 128B         |     560.8 ns |     1.85 ns |     1.55 ns |         - |
| Encrypt · XChaCha20-Poly1305 (NaCl.Core) | 128B         |     874.1 ns |     2.15 ns |     2.01 ns |      48 B |
| Encrypt · XChaCha20-Poly1305 (Managed)   | 128B         |   1,062.0 ns |     4.24 ns |     3.75 ns |         - |
|                                          |              |              |             |             |           |
| Decrypt · XChaCha20-Poly1305 (AVX2)      | 1KB          |   1,478.7 ns |     3.74 ns |     3.32 ns |         - |
| Decrypt · XChaCha20-Poly1305 (SSSE3)     | 1KB          |   1,939.0 ns |     7.48 ns |     7.00 ns |         - |
| Decrypt · XChaCha20-Poly1305 (NaCl.Core) | 1KB          |   4,066.4 ns |    26.09 ns |    24.41 ns |      72 B |
| Decrypt · XChaCha20-Poly1305 (Managed)   | 1KB          |   4,711.4 ns |    15.42 ns |    14.43 ns |         - |
|                                          |              |              |             |             |           |
| Encrypt · XChaCha20-Poly1305 (AVX2)      | 1KB          |   1,445.8 ns |     4.05 ns |     3.79 ns |         - |
| Encrypt · XChaCha20-Poly1305 (SSSE3)     | 1KB          |   1,891.0 ns |     3.99 ns |     3.33 ns |         - |
| Encrypt · XChaCha20-Poly1305 (NaCl.Core) | 1KB          |   4,030.9 ns |     8.66 ns |     7.68 ns |      72 B |
| Encrypt · XChaCha20-Poly1305 (Managed)   | 1KB          |   4,659.2 ns |    14.88 ns |    13.19 ns |         - |
|                                          |              |              |             |             |           |
| Decrypt · XChaCha20-Poly1305 (AVX2)      | 8KB          |   8,923.0 ns |    23.40 ns |    21.89 ns |         - |
| Decrypt · XChaCha20-Poly1305 (SSSE3)     | 8KB          |  12,580.9 ns |    18.88 ns |    17.66 ns |         - |
| Decrypt · XChaCha20-Poly1305 (NaCl.Core) | 8KB          |  29,072.0 ns |    56.67 ns |    53.01 ns |      72 B |
| Decrypt · XChaCha20-Poly1305 (Managed)   | 8KB          |  33,565.8 ns |   232.85 ns |   181.79 ns |         - |
|                                          |              |              |             |             |           |
| Encrypt · XChaCha20-Poly1305 (AVX2)      | 8KB          |   8,854.1 ns |    25.72 ns |    22.80 ns |         - |
| Encrypt · XChaCha20-Poly1305 (SSSE3)     | 8KB          |  12,536.7 ns |    16.22 ns |    14.38 ns |         - |
| Encrypt · XChaCha20-Poly1305 (NaCl.Core) | 8KB          |  28,998.2 ns |   104.39 ns |    92.54 ns |      72 B |
| Encrypt · XChaCha20-Poly1305 (Managed)   | 8KB          |  33,542.7 ns |   151.53 ns |   141.74 ns |         - |
|                                          |              |              |             |             |           |
| Decrypt · XChaCha20-Poly1305 (AVX2)      | 128KB        | 136,085.2 ns |   458.91 ns |   406.81 ns |         - |
| Decrypt · XChaCha20-Poly1305 (SSSE3)     | 128KB        | 194,735.1 ns |   216.12 ns |   191.58 ns |         - |
| Decrypt · XChaCha20-Poly1305 (NaCl.Core) | 128KB        | 475,150.6 ns |   954.11 ns |   845.79 ns |      72 B |
| Decrypt · XChaCha20-Poly1305 (Managed)   | 128KB        | 528,259.8 ns | 1,760.73 ns | 1,470.29 ns |         - |
|                                          |              |              |             |             |           |
| Encrypt · XChaCha20-Poly1305 (AVX2)      | 128KB        | 136,004.9 ns |   462.57 ns |   361.14 ns |         - |
| Encrypt · XChaCha20-Poly1305 (SSSE3)     | 128KB        | 194,845.0 ns |   293.70 ns |   245.25 ns |         - |
| Encrypt · XChaCha20-Poly1305 (NaCl.Core) | 128KB        | 458,992.1 ns | 1,039.60 ns |   921.58 ns |      72 B |
| Encrypt · XChaCha20-Poly1305 (Managed)   | 128KB        | 529,076.4 ns | 3,045.35 ns | 2,848.62 ns |         - |