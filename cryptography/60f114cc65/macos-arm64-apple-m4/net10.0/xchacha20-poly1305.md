| Description                              | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|----------------------------------------- |------------- |-------------:|------------:|------------:|----------:|
| Decrypt · XChaCha20-Poly1305 (Neon)      | 128B         |     858.6 ns |     4.12 ns |     3.85 ns |         - |
| Decrypt · XChaCha20-Poly1305 (NaCl.Core) | 128B         |   1,481.3 ns |     0.14 ns |     0.13 ns |      48 B |
| Decrypt · XChaCha20-Poly1305 (Managed)   | 128B         |   1,741.2 ns |     6.55 ns |     6.13 ns |         - |
|                                          |              |              |             |             |           |
| Encrypt · XChaCha20-Poly1305 (Neon)      | 128B         |     727.7 ns |     4.50 ns |     4.21 ns |         - |
| Encrypt · XChaCha20-Poly1305 (NaCl.Core) | 128B         |   1,449.0 ns |     0.23 ns |     0.21 ns |      48 B |
| Encrypt · XChaCha20-Poly1305 (Managed)   | 128B         |   1,668.1 ns |     6.62 ns |     6.19 ns |         - |
|                                          |              |              |             |             |           |
| Decrypt · XChaCha20-Poly1305 (Neon)      | 1KB          |   2,463.3 ns |     0.62 ns |     0.58 ns |         - |
| Decrypt · XChaCha20-Poly1305 (NaCl.Core) | 1KB          |   6,632.7 ns |     0.83 ns |     0.78 ns |      72 B |
| Decrypt · XChaCha20-Poly1305 (Managed)   | 1KB          |   7,207.5 ns |    22.08 ns |    20.65 ns |         - |
|                                          |              |              |             |             |           |
| Encrypt · XChaCha20-Poly1305 (Neon)      | 1KB          |   2,357.4 ns |     0.92 ns |     0.86 ns |         - |
| Encrypt · XChaCha20-Poly1305 (NaCl.Core) | 1KB          |   6,592.8 ns |     1.29 ns |     1.15 ns |      72 B |
| Encrypt · XChaCha20-Poly1305 (Managed)   | 1KB          |   7,160.7 ns |    26.37 ns |    24.67 ns |         - |
|                                          |              |              |             |             |           |
| Decrypt · XChaCha20-Poly1305 (Neon)      | 8KB          |  14,923.2 ns |     5.52 ns |     4.61 ns |         - |
| Decrypt · XChaCha20-Poly1305 (NaCl.Core) | 8KB          |  47,621.4 ns |     8.43 ns |     7.88 ns |      72 B |
| Decrypt · XChaCha20-Poly1305 (Managed)   | 8KB          |  49,370.7 ns |   175.61 ns |   164.26 ns |         - |
|                                          |              |              |             |             |           |
| Encrypt · XChaCha20-Poly1305 (Neon)      | 8KB          |  14,842.9 ns |     3.61 ns |     3.37 ns |         - |
| Encrypt · XChaCha20-Poly1305 (NaCl.Core) | 8KB          |  47,537.2 ns |     7.72 ns |     7.22 ns |      72 B |
| Encrypt · XChaCha20-Poly1305 (Managed)   | 8KB          |  49,276.8 ns |   218.65 ns |   204.52 ns |         - |
|                                          |              |              |             |             |           |
| Decrypt · XChaCha20-Poly1305 (Neon)      | 128KB        | 228,248.5 ns |    77.65 ns |    68.83 ns |         - |
| Decrypt · XChaCha20-Poly1305 (NaCl.Core) | 128KB        | 750,378.5 ns |   142.32 ns |   126.16 ns |      72 B |
| Decrypt · XChaCha20-Poly1305 (Managed)   | 128KB        | 773,283.2 ns | 2,111.40 ns | 1,975.01 ns |         - |
|                                          |              |              |             |             |           |
| Encrypt · XChaCha20-Poly1305 (Neon)      | 128KB        | 229,160.6 ns |    81.17 ns |    75.93 ns |         - |
| Encrypt · XChaCha20-Poly1305 (NaCl.Core) | 128KB        | 750,622.5 ns |   144.25 ns |   134.93 ns |      72 B |
| Encrypt · XChaCha20-Poly1305 (Managed)   | 128KB        | 773,519.8 ns | 2,937.24 ns | 2,747.49 ns |         - |