| Description                                       | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|-------------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|
| Decrypt · XChaCha20-Poly1305 (CryptoHives-Neon)   | 128B         |     921.7 ns |     3.53 ns |     3.30 ns |         - |
| Decrypt · XChaCha20-Poly1305 (NaCl.Core)          | 128B         |   1,493.7 ns |     5.71 ns |     5.06 ns |      48 B |
| Decrypt · XChaCha20-Poly1305 (CryptoHives-Scalar) | 128B         |   1,964.4 ns |     7.91 ns |     7.40 ns |         - |
|                                                   |              |              |             |             |           |
| Encrypt · XChaCha20-Poly1305 (CryptoHives-Neon)   | 128B         |     813.4 ns |     4.59 ns |     4.06 ns |         - |
| Encrypt · XChaCha20-Poly1305 (NaCl.Core)          | 128B         |   1,458.9 ns |     5.82 ns |     5.45 ns |      48 B |
| Encrypt · XChaCha20-Poly1305 (CryptoHives-Scalar) | 128B         |   1,969.9 ns |     8.76 ns |     7.31 ns |         - |
|                                                   |              |              |             |             |           |
| Decrypt · XChaCha20-Poly1305 (CryptoHives-Neon)   | 1KB          |   2,538.9 ns |     8.83 ns |     8.26 ns |         - |
| Decrypt · XChaCha20-Poly1305 (NaCl.Core)          | 1KB          |   6,658.1 ns |    22.39 ns |    19.85 ns |      72 B |
| Decrypt · XChaCha20-Poly1305 (CryptoHives-Scalar) | 1KB          |   8,151.6 ns |    50.37 ns |    44.65 ns |         - |
|                                                   |              |              |             |             |           |
| Encrypt · XChaCha20-Poly1305 (CryptoHives-Neon)   | 1KB          |   2,416.3 ns |     8.03 ns |     7.51 ns |         - |
| Encrypt · XChaCha20-Poly1305 (NaCl.Core)          | 1KB          |   6,609.4 ns |    17.03 ns |    15.93 ns |      72 B |
| Encrypt · XChaCha20-Poly1305 (CryptoHives-Scalar) | 1KB          |   8,141.5 ns |    37.99 ns |    35.54 ns |         - |
|                                                   |              |              |             |             |           |
| Decrypt · XChaCha20-Poly1305 (CryptoHives-Neon)   | 8KB          |  15,004.0 ns |    56.38 ns |    49.98 ns |         - |
| Decrypt · XChaCha20-Poly1305 (NaCl.Core)          | 8KB          |  47,830.8 ns |   181.63 ns |   169.90 ns |      72 B |
| Decrypt · XChaCha20-Poly1305 (CryptoHives-Scalar) | 8KB          |  56,092.4 ns |   245.13 ns |   229.29 ns |         - |
|                                                   |              |              |             |             |           |
| Encrypt · XChaCha20-Poly1305 (CryptoHives-Neon)   | 8KB          |  14,957.6 ns |    54.52 ns |    51.00 ns |         - |
| Encrypt · XChaCha20-Poly1305 (NaCl.Core)          | 8KB          |  47,726.2 ns |   165.16 ns |   154.49 ns |      72 B |
| Encrypt · XChaCha20-Poly1305 (CryptoHives-Scalar) | 8KB          |  56,251.1 ns |   200.27 ns |   187.33 ns |         - |
|                                                   |              |              |             |             |           |
| Decrypt · XChaCha20-Poly1305 (CryptoHives-Neon)   | 128KB        | 229,593.8 ns |   593.16 ns |   554.84 ns |         - |
| Decrypt · XChaCha20-Poly1305 (NaCl.Core)          | 128KB        | 753,392.2 ns | 2,813.72 ns | 2,494.29 ns |      72 B |
| Decrypt · XChaCha20-Poly1305 (CryptoHives-Scalar) | 128KB        | 876,278.4 ns | 3,463.70 ns | 3,070.48 ns |         - |
|                                                   |              |              |             |             |           |
| Encrypt · XChaCha20-Poly1305 (CryptoHives-Neon)   | 128KB        | 230,535.9 ns |   498.45 ns |   441.87 ns |         - |
| Encrypt · XChaCha20-Poly1305 (NaCl.Core)          | 128KB        | 753,114.9 ns | 2,477.43 ns | 2,317.39 ns |      72 B |
| Encrypt · XChaCha20-Poly1305 (CryptoHives-Scalar) | 128KB        | 880,024.0 ns | 3,901.45 ns | 3,458.53 ns |         - |