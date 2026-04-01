| Description                              | TestDataSize | Mean       | Error     | StdDev    | Allocated |
|----------------------------------------- |------------- |-----------:|----------:|----------:|----------:|
| Decrypt · XChaCha20-Poly1305 (Neon)      | 128B         |   1.167 μs | 0.0064 μs | 0.0060 μs |         - |
| Decrypt · XChaCha20-Poly1305 (NaCl.Core) | 128B         |   1.480 μs | 0.0002 μs | 0.0002 μs |      48 B |
| Decrypt · XChaCha20-Poly1305 (Managed)   | 128B         |   1.722 μs | 0.0056 μs | 0.0052 μs |         - |
|                                          |              |            |           |           |           |
| Encrypt · XChaCha20-Poly1305 (Neon)      | 128B         |   1.096 μs | 0.0075 μs | 0.0070 μs |         - |
| Encrypt · XChaCha20-Poly1305 (NaCl.Core) | 128B         |   1.448 μs | 0.0003 μs | 0.0002 μs |      48 B |
| Encrypt · XChaCha20-Poly1305 (Managed)   | 128B         |   1.621 μs | 0.0049 μs | 0.0045 μs |         - |
|                                          |              |            |           |           |           |
| Decrypt · XChaCha20-Poly1305 (Neon)      | 1KB          |   2.699 μs | 0.0012 μs | 0.0011 μs |         - |
| Decrypt · XChaCha20-Poly1305 (NaCl.Core) | 1KB          |   6.635 μs | 0.0023 μs | 0.0021 μs |      72 B |
| Decrypt · XChaCha20-Poly1305 (Managed)   | 1KB          |   7.086 μs | 0.0254 μs | 0.0238 μs |         - |
|                                          |              |            |           |           |           |
| Encrypt · XChaCha20-Poly1305 (Neon)      | 1KB          |   2.671 μs | 0.0012 μs | 0.0012 μs |         - |
| Encrypt · XChaCha20-Poly1305 (NaCl.Core) | 1KB          |   6.597 μs | 0.0015 μs | 0.0013 μs |      72 B |
| Encrypt · XChaCha20-Poly1305 (Managed)   | 1KB          |   7.048 μs | 0.0183 μs | 0.0171 μs |         - |
|                                          |              |            |           |           |           |
| Decrypt · XChaCha20-Poly1305 (Neon)      | 8KB          |  15.129 μs | 0.0049 μs | 0.0041 μs |         - |
| Decrypt · XChaCha20-Poly1305 (NaCl.Core) | 8KB          |  47.608 μs | 0.0093 μs | 0.0087 μs |      72 B |
| Decrypt · XChaCha20-Poly1305 (Managed)   | 8KB          |  48.467 μs | 0.2036 μs | 0.1905 μs |         - |
|                                          |              |            |           |           |           |
| Encrypt · XChaCha20-Poly1305 (Neon)      | 8KB          |  15.204 μs | 0.0069 μs | 0.0065 μs |         - |
| Encrypt · XChaCha20-Poly1305 (NaCl.Core) | 8KB          |  47.521 μs | 0.0060 μs | 0.0050 μs |      72 B |
| Encrypt · XChaCha20-Poly1305 (Managed)   | 8KB          |  48.376 μs | 0.2060 μs | 0.1927 μs |         - |
|                                          |              |            |           |           |           |
| Decrypt · XChaCha20-Poly1305 (Neon)      | 128KB        | 228.965 μs | 0.1020 μs | 0.0954 μs |         - |
| Decrypt · XChaCha20-Poly1305 (NaCl.Core) | 128KB        | 751.208 μs | 0.1381 μs | 0.1292 μs |      72 B |
| Decrypt · XChaCha20-Poly1305 (Managed)   | 128KB        | 757.817 μs | 3.0047 μs | 2.8106 μs |         - |
|                                          |              |            |           |           |           |
| Encrypt · XChaCha20-Poly1305 (Neon)      | 128KB        | 229.493 μs | 0.0862 μs | 0.0806 μs |         - |
| Encrypt · XChaCha20-Poly1305 (NaCl.Core) | 128KB        | 750.458 μs | 0.1387 μs | 0.1298 μs |      72 B |
| Encrypt · XChaCha20-Poly1305 (Managed)   | 128KB        | 756.772 μs | 2.3731 μs | 2.2198 μs |         - |