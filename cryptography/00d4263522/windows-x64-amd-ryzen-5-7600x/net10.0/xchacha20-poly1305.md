| Description                                       | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|-------------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|
| Decrypt · XChaCha20-Poly1305 (CryptoHives-AVX2)   | 128B         |     564.9 ns |     1.20 ns |     1.00 ns |         - |
| Decrypt · XChaCha20-Poly1305 (CryptoHives-SSSE3)  | 128B         |     624.7 ns |     0.91 ns |     0.85 ns |         - |
| Decrypt · XChaCha20-Poly1305 (NaCl.Core)          | 128B         |     967.7 ns |     2.58 ns |     2.16 ns |      48 B |
| Decrypt · XChaCha20-Poly1305 (CryptoHives-Scalar) | 128B         |   1,133.2 ns |     3.99 ns |     3.73 ns |         - |
|                                                   |              |              |             |             |           |
| Encrypt · XChaCha20-Poly1305 (CryptoHives-AVX2)   | 128B         |     513.9 ns |     1.55 ns |     1.38 ns |         - |
| Encrypt · XChaCha20-Poly1305 (CryptoHives-SSSE3)  | 128B         |     579.1 ns |     0.71 ns |     0.59 ns |         - |
| Encrypt · XChaCha20-Poly1305 (NaCl.Core)          | 128B         |     933.9 ns |     1.81 ns |     1.70 ns |      48 B |
| Encrypt · XChaCha20-Poly1305 (CryptoHives-Scalar) | 128B         |   1,093.2 ns |     8.68 ns |     7.25 ns |         - |
|                                                   |              |              |             |             |           |
| Decrypt · XChaCha20-Poly1305 (CryptoHives-AVX2)   | 1KB          |   1,515.7 ns |     2.22 ns |     2.08 ns |         - |
| Decrypt · XChaCha20-Poly1305 (CryptoHives-SSSE3)  | 1KB          |   1,969.5 ns |     3.53 ns |     3.13 ns |         - |
| Decrypt · XChaCha20-Poly1305 (NaCl.Core)          | 1KB          |   4,302.7 ns |    11.35 ns |     9.48 ns |      72 B |
| Decrypt · XChaCha20-Poly1305 (CryptoHives-Scalar) | 1KB          |   4,859.2 ns |     8.81 ns |     7.81 ns |         - |
|                                                   |              |              |             |             |           |
| Encrypt · XChaCha20-Poly1305 (CryptoHives-AVX2)   | 1KB          |   1,465.8 ns |     1.33 ns |     1.18 ns |         - |
| Encrypt · XChaCha20-Poly1305 (CryptoHives-SSSE3)  | 1KB          |   1,921.0 ns |     2.30 ns |     2.04 ns |         - |
| Encrypt · XChaCha20-Poly1305 (NaCl.Core)          | 1KB          |   4,467.6 ns |    11.99 ns |    10.63 ns |      72 B |
| Encrypt · XChaCha20-Poly1305 (CryptoHives-Scalar) | 1KB          |   4,824.2 ns |    12.99 ns |    11.52 ns |         - |
|                                                   |              |              |             |             |           |
| Decrypt · XChaCha20-Poly1305 (CryptoHives-AVX2)   | 8KB          |   9,109.4 ns |    17.06 ns |    15.96 ns |         - |
| Decrypt · XChaCha20-Poly1305 (CryptoHives-SSSE3)  | 8KB          |  12,686.6 ns |    21.82 ns |    20.41 ns |         - |
| Decrypt · XChaCha20-Poly1305 (NaCl.Core)          | 8KB          |  30,494.8 ns |    45.70 ns |    40.51 ns |      72 B |
| Decrypt · XChaCha20-Poly1305 (CryptoHives-Scalar) | 8KB          |  34,670.2 ns |    93.83 ns |    73.26 ns |         - |
|                                                   |              |              |             |             |           |
| Encrypt · XChaCha20-Poly1305 (CryptoHives-AVX2)   | 8KB          |   9,043.5 ns |    17.55 ns |    15.56 ns |         - |
| Encrypt · XChaCha20-Poly1305 (CryptoHives-SSSE3)  | 8KB          |  12,625.5 ns |    14.48 ns |    12.09 ns |         - |
| Encrypt · XChaCha20-Poly1305 (NaCl.Core)          | 8KB          |  30,394.1 ns |    84.06 ns |    74.51 ns |      72 B |
| Encrypt · XChaCha20-Poly1305 (CryptoHives-Scalar) | 8KB          |  34,671.0 ns |    46.89 ns |    41.57 ns |         - |
|                                                   |              |              |             |             |           |
| Decrypt · XChaCha20-Poly1305 (CryptoHives-AVX2)   | 128KB        | 139,065.6 ns |   214.24 ns |   189.92 ns |         - |
| Decrypt · XChaCha20-Poly1305 (CryptoHives-SSSE3)  | 128KB        | 196,486.1 ns |   354.15 ns |   331.27 ns |         - |
| Decrypt · XChaCha20-Poly1305 (NaCl.Core)          | 128KB        | 482,312.3 ns | 1,124.87 ns | 1,052.21 ns |      72 B |
| Decrypt · XChaCha20-Poly1305 (CryptoHives-Scalar) | 128KB        | 545,302.9 ns |   638.76 ns |   566.24 ns |         - |
|                                                   |              |              |             |             |           |
| Encrypt · XChaCha20-Poly1305 (CryptoHives-AVX2)   | 128KB        | 139,032.9 ns |   342.43 ns |   320.31 ns |         - |
| Encrypt · XChaCha20-Poly1305 (CryptoHives-SSSE3)  | 128KB        | 196,697.5 ns |   426.34 ns |   356.01 ns |         - |
| Encrypt · XChaCha20-Poly1305 (NaCl.Core)          | 128KB        | 479,860.9 ns | 2,114.10 ns | 1,874.09 ns |      72 B |
| Encrypt · XChaCha20-Poly1305 (CryptoHives-Scalar) | 128KB        | 544,359.5 ns | 1,035.50 ns |   864.69 ns |         - |