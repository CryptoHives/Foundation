| Description                              | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|----------------------------------------- |------------- |-------------:|------------:|------------:|----------:|
| Decrypt · XChaCha20-Poly1305 (AVX2)      | 128B         |     725.1 ns |     7.09 ns |     6.63 ns |         - |
| Decrypt · XChaCha20-Poly1305 (SSSE3)     | 128B         |     785.8 ns |     5.35 ns |     5.01 ns |         - |
| Decrypt · XChaCha20-Poly1305 (NaCl.Core) | 128B         |     924.3 ns |     6.29 ns |     5.57 ns |      48 B |
| Decrypt · XChaCha20-Poly1305 (Managed)   | 128B         |   1,118.9 ns |    11.24 ns |     9.39 ns |         - |
|                                          |              |              |             |             |           |
| Encrypt · XChaCha20-Poly1305 (AVX2)      | 128B         |     679.0 ns |     8.01 ns |     7.49 ns |         - |
| Encrypt · XChaCha20-Poly1305 (SSSE3)     | 128B         |     744.6 ns |     4.53 ns |     4.02 ns |         - |
| Encrypt · XChaCha20-Poly1305 (NaCl.Core) | 128B         |     880.4 ns |     3.45 ns |     2.88 ns |      48 B |
| Encrypt · XChaCha20-Poly1305 (Managed)   | 128B         |   1,075.3 ns |    17.35 ns |    16.23 ns |         - |
|                                          |              |              |             |             |           |
| Decrypt · XChaCha20-Poly1305 (AVX2)      | 1KB          |   1,670.7 ns |    14.81 ns |    11.56 ns |         - |
| Decrypt · XChaCha20-Poly1305 (SSSE3)     | 1KB          |   2,117.7 ns |    12.87 ns |    12.04 ns |         - |
| Decrypt · XChaCha20-Poly1305 (NaCl.Core) | 1KB          |   4,104.0 ns |    24.44 ns |    20.41 ns |      72 B |
| Decrypt · XChaCha20-Poly1305 (Managed)   | 1KB          |   4,776.0 ns |    52.43 ns |    46.48 ns |         - |
|                                          |              |              |             |             |           |
| Encrypt · XChaCha20-Poly1305 (AVX2)      | 1KB          |   1,616.2 ns |     7.39 ns |     6.92 ns |         - |
| Encrypt · XChaCha20-Poly1305 (SSSE3)     | 1KB          |   2,081.2 ns |    14.78 ns |    13.82 ns |         - |
| Encrypt · XChaCha20-Poly1305 (NaCl.Core) | 1KB          |   4,082.5 ns |    52.02 ns |    46.11 ns |      72 B |
| Encrypt · XChaCha20-Poly1305 (Managed)   | 1KB          |   4,742.8 ns |    45.40 ns |    42.47 ns |         - |
|                                          |              |              |             |             |           |
| Decrypt · XChaCha20-Poly1305 (AVX2)      | 8KB          |   9,177.1 ns |    91.75 ns |    85.82 ns |         - |
| Decrypt · XChaCha20-Poly1305 (SSSE3)     | 8KB          |  12,859.4 ns |    93.95 ns |    87.88 ns |         - |
| Decrypt · XChaCha20-Poly1305 (NaCl.Core) | 8KB          |  29,328.7 ns |   171.96 ns |   152.44 ns |      72 B |
| Decrypt · XChaCha20-Poly1305 (Managed)   | 8KB          |  34,221.7 ns |   480.24 ns |   425.72 ns |         - |
|                                          |              |              |             |             |           |
| Encrypt · XChaCha20-Poly1305 (AVX2)      | 8KB          |   9,086.0 ns |    57.12 ns |    53.43 ns |         - |
| Encrypt · XChaCha20-Poly1305 (SSSE3)     | 8KB          |  12,789.8 ns |    75.60 ns |    70.71 ns |         - |
| Encrypt · XChaCha20-Poly1305 (NaCl.Core) | 8KB          |  29,308.0 ns |   130.13 ns |   108.67 ns |      72 B |
| Encrypt · XChaCha20-Poly1305 (Managed)   | 8KB          |  34,047.6 ns |   341.42 ns |   319.37 ns |         - |
|                                          |              |              |             |             |           |
| Decrypt · XChaCha20-Poly1305 (AVX2)      | 128KB        | 137,400.6 ns |   727.48 ns |   607.47 ns |         - |
| Decrypt · XChaCha20-Poly1305 (SSSE3)     | 128KB        | 196,140.5 ns | 1,288.52 ns | 1,205.28 ns |         - |
| Decrypt · XChaCha20-Poly1305 (NaCl.Core) | 128KB        | 465,290.5 ns | 4,263.50 ns | 3,988.08 ns |      72 B |
| Decrypt · XChaCha20-Poly1305 (Managed)   | 128KB        | 536,320.4 ns | 5,700.02 ns | 5,052.92 ns |         - |
|                                          |              |              |             |             |           |
| Encrypt · XChaCha20-Poly1305 (AVX2)      | 128KB        | 137,744.8 ns |   998.02 ns |   933.55 ns |         - |
| Encrypt · XChaCha20-Poly1305 (SSSE3)     | 128KB        | 196,605.4 ns | 1,191.00 ns | 1,055.79 ns |         - |
| Encrypt · XChaCha20-Poly1305 (NaCl.Core) | 128KB        | 463,343.7 ns | 2,687.58 ns | 2,513.97 ns |      72 B |
| Encrypt · XChaCha20-Poly1305 (Managed)   | 128KB        | 535,693.4 ns | 7,461.92 ns | 6,614.80 ns |         - |