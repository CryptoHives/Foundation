| Description                                | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|
| Decrypt · ChaCha20-Poly1305 (AVX2)         | 128B         |     331.6 ns |     0.75 ns |     0.66 ns |         - |
| Decrypt · ChaCha20-Poly1305 (OS)           | 128B         |     344.9 ns |     1.57 ns |     1.39 ns |         - |
| Decrypt · ChaCha20-Poly1305 (SSSE3)        | 128B         |     386.6 ns |     1.55 ns |     1.45 ns |         - |
| Decrypt · ChaCha20-Poly1305 (NaCl.Core)    | 128B         |     586.6 ns |     2.33 ns |     2.18 ns |      48 B |
| Decrypt · ChaCha20-Poly1305 (BouncyCastle) | 128B         |     715.5 ns |     5.39 ns |     4.50 ns |     416 B |
| Decrypt · ChaCha20-Poly1305 (Managed)      | 128B         |     872.9 ns |     5.24 ns |     4.90 ns |         - |
|                                            |              |              |             |             |           |
| Encrypt · ChaCha20-Poly1305 (AVX2)         | 128B         |     285.7 ns |     1.27 ns |     1.12 ns |         - |
| Encrypt · ChaCha20-Poly1305 (OS)           | 128B         |     345.8 ns |     1.51 ns |     1.34 ns |         - |
| Encrypt · ChaCha20-Poly1305 (SSSE3)        | 128B         |     348.7 ns |     1.35 ns |     1.13 ns |         - |
| Encrypt · ChaCha20-Poly1305 (BouncyCastle) | 128B         |     416.2 ns |     3.16 ns |     2.96 ns |     336 B |
| Encrypt · ChaCha20-Poly1305 (NaCl.Core)    | 128B         |     538.0 ns |     2.26 ns |     2.00 ns |      48 B |
| Encrypt · ChaCha20-Poly1305 (Managed)      | 128B         |     836.3 ns |     3.20 ns |     2.84 ns |         - |
|                                            |              |              |             |             |           |
| Decrypt · ChaCha20-Poly1305 (AVX2)         | 1KB          |   1,257.9 ns |     2.52 ns |     2.36 ns |         - |
| Decrypt · ChaCha20-Poly1305 (BouncyCastle) | 1KB          |   1,719.2 ns |     9.64 ns |     8.05 ns |     416 B |
| Decrypt · ChaCha20-Poly1305 (SSSE3)        | 1KB          |   1,729.8 ns |     3.24 ns |     2.71 ns |         - |
| Decrypt · ChaCha20-Poly1305 (OS)           | 1KB          |   1,761.0 ns |     6.00 ns |     5.32 ns |         - |
| Decrypt · ChaCha20-Poly1305 (NaCl.Core)    | 1KB          |   2,600.6 ns |     5.20 ns |     4.86 ns |      72 B |
| Decrypt · ChaCha20-Poly1305 (Managed)      | 1KB          |   4,493.4 ns |    28.86 ns |    25.58 ns |         - |
|                                            |              |              |             |             |           |
| Encrypt · ChaCha20-Poly1305 (AVX2)         | 1KB          |   1,219.9 ns |     5.42 ns |     4.80 ns |         - |
| Encrypt · ChaCha20-Poly1305 (BouncyCastle) | 1KB          |   1,409.9 ns |     6.97 ns |     6.52 ns |     336 B |
| Encrypt · ChaCha20-Poly1305 (SSSE3)        | 1KB          |   1,673.4 ns |     2.40 ns |     2.12 ns |         - |
| Encrypt · ChaCha20-Poly1305 (OS)           | 1KB          |   1,762.5 ns |     5.87 ns |     5.49 ns |         - |
| Encrypt · ChaCha20-Poly1305 (NaCl.Core)    | 1KB          |   2,565.0 ns |     7.49 ns |     7.00 ns |      72 B |
| Encrypt · ChaCha20-Poly1305 (Managed)      | 1KB          |   4,436.1 ns |    14.88 ns |    13.19 ns |         - |
|                                            |              |              |             |             |           |
| Decrypt · ChaCha20-Poly1305 (AVX2)         | 8KB          |   8,692.0 ns |    25.14 ns |    23.52 ns |         - |
| Decrypt · ChaCha20-Poly1305 (BouncyCastle) | 8KB          |   9,594.5 ns |    72.85 ns |    68.14 ns |     416 B |
| Decrypt · ChaCha20-Poly1305 (SSSE3)        | 8KB          |  12,346.5 ns |    24.97 ns |    23.36 ns |         - |
| Decrypt · ChaCha20-Poly1305 (OS)           | 8KB          |  13,085.8 ns |    22.93 ns |    19.15 ns |         - |
| Decrypt · ChaCha20-Poly1305 (NaCl.Core)    | 8KB          |  18,303.6 ns |   152.33 ns |   135.03 ns |      72 B |
| Decrypt · ChaCha20-Poly1305 (Managed)      | 8KB          |  33,245.4 ns |   138.93 ns |   123.16 ns |         - |
|                                            |              |              |             |             |           |
| Encrypt · ChaCha20-Poly1305 (AVX2)         | 8KB          |   8,797.0 ns |    23.87 ns |    22.33 ns |         - |
| Encrypt · ChaCha20-Poly1305 (BouncyCastle) | 8KB          |   9,452.5 ns |    68.63 ns |    60.84 ns |     336 B |
| Encrypt · ChaCha20-Poly1305 (SSSE3)        | 8KB          |  12,302.4 ns |    17.34 ns |    16.22 ns |         - |
| Encrypt · ChaCha20-Poly1305 (OS)           | 8KB          |  13,079.7 ns |    35.98 ns |    31.89 ns |         - |
| Encrypt · ChaCha20-Poly1305 (NaCl.Core)    | 8KB          |  18,471.0 ns |    80.40 ns |    71.27 ns |      72 B |
| Encrypt · ChaCha20-Poly1305 (Managed)      | 8KB          |  33,254.7 ns |   100.72 ns |    84.10 ns |         - |
|                                            |              |              |             |             |           |
| Decrypt · ChaCha20-Poly1305 (AVX2)         | 128KB        | 136,079.4 ns |   562.25 ns |   525.93 ns |         - |
| Decrypt · ChaCha20-Poly1305 (BouncyCastle) | 128KB        | 147,120.6 ns |   719.44 ns |   600.76 ns |     416 B |
| Decrypt · ChaCha20-Poly1305 (SSSE3)        | 128KB        | 194,365.8 ns |   447.07 ns |   418.19 ns |         - |
| Decrypt · ChaCha20-Poly1305 (OS)           | 128KB        | 207,576.8 ns |   560.46 ns |   468.01 ns |         - |
| Decrypt · ChaCha20-Poly1305 (NaCl.Core)    | 128KB        | 293,413.2 ns | 1,978.06 ns | 1,753.50 ns |      72 B |
| Decrypt · ChaCha20-Poly1305 (Managed)      | 128KB        | 527,715.7 ns | 2,218.14 ns | 2,074.85 ns |         - |
|                                            |              |              |             |             |           |
| Encrypt · ChaCha20-Poly1305 (AVX2)         | 128KB        | 135,855.6 ns |   369.06 ns |   345.22 ns |         - |
| Encrypt · ChaCha20-Poly1305 (BouncyCastle) | 128KB        | 149,082.2 ns |   954.13 ns |   892.50 ns |     336 B |
| Encrypt · ChaCha20-Poly1305 (SSSE3)        | 128KB        | 194,430.8 ns |   240.94 ns |   188.11 ns |         - |
| Encrypt · ChaCha20-Poly1305 (OS)           | 128KB        | 207,681.5 ns |   518.89 ns |   459.98 ns |         - |
| Encrypt · ChaCha20-Poly1305 (NaCl.Core)    | 128KB        | 293,919.5 ns | 1,410.50 ns | 1,319.39 ns |      72 B |
| Encrypt · ChaCha20-Poly1305 (Managed)      | 128KB        | 528,361.9 ns | 2,134.34 ns | 1,892.04 ns |         - |