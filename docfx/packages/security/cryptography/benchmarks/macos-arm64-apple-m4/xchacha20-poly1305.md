| Description                                       | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|-------------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|
| Decrypt · XChaCha20-Poly1305 (CryptoHives-Neon)   | 128B         |     891.7 ns |     3.00 ns |     2.80 ns |         - |
| Decrypt · XChaCha20-Poly1305 (NaCl.Core)          | 128B         |   1,481.4 ns |     1.53 ns |     1.43 ns |      48 B |
| Decrypt · XChaCha20-Poly1305 (CryptoHives-Scalar) | 128B         |   1,730.5 ns |     3.32 ns |     2.94 ns |         - |
|                                                   |              |              |             |             |           |
| Encrypt · XChaCha20-Poly1305 (CryptoHives-Neon)   | 128B         |     753.2 ns |     3.40 ns |     2.65 ns |         - |
| Encrypt · XChaCha20-Poly1305 (NaCl.Core)          | 128B         |   1,465.8 ns |    16.78 ns |    14.01 ns |      48 B |
| Encrypt · XChaCha20-Poly1305 (CryptoHives-Scalar) | 128B         |   1,725.9 ns |     6.40 ns |     5.99 ns |         - |
|                                                   |              |              |             |             |           |
| Decrypt · XChaCha20-Poly1305 (CryptoHives-Neon)   | 1KB          |   2,486.6 ns |    13.83 ns |    12.93 ns |         - |
| Decrypt · XChaCha20-Poly1305 (NaCl.Core)          | 1KB          |   6,624.1 ns |     0.98 ns |     0.82 ns |      72 B |
| Decrypt · XChaCha20-Poly1305 (CryptoHives-Scalar) | 1KB          |   7,368.3 ns |    15.60 ns |    14.59 ns |         - |
|                                                   |              |              |             |             |           |
| Encrypt · XChaCha20-Poly1305 (CryptoHives-Neon)   | 1KB          |   2,407.2 ns |    31.38 ns |    27.82 ns |         - |
| Encrypt · XChaCha20-Poly1305 (NaCl.Core)          | 1KB          |   6,579.0 ns |     4.67 ns |     3.90 ns |      72 B |
| Encrypt · XChaCha20-Poly1305 (CryptoHives-Scalar) | 1KB          |   7,358.9 ns |    18.70 ns |    17.49 ns |         - |
|                                                   |              |              |             |             |           |
| Decrypt · XChaCha20-Poly1305 (CryptoHives-Neon)   | 8KB          |  14,969.0 ns |    30.79 ns |    28.80 ns |         - |
| Decrypt · XChaCha20-Poly1305 (NaCl.Core)          | 8KB          |  47,610.7 ns |    28.53 ns |    23.82 ns |      72 B |
| Decrypt · XChaCha20-Poly1305 (CryptoHives-Scalar) | 8KB          |  50,421.4 ns |   107.91 ns |   100.94 ns |         - |
|                                                   |              |              |             |             |           |
| Encrypt · XChaCha20-Poly1305 (CryptoHives-Neon)   | 8KB          |  14,890.3 ns |    22.12 ns |    17.27 ns |         - |
| Encrypt · XChaCha20-Poly1305 (NaCl.Core)          | 8KB          |  47,555.8 ns |    29.49 ns |    24.62 ns |      72 B |
| Encrypt · XChaCha20-Poly1305 (CryptoHives-Scalar) | 8KB          |  50,528.6 ns |    91.02 ns |    85.14 ns |         - |
|                                                   |              |              |             |             |           |
| Decrypt · XChaCha20-Poly1305 (CryptoHives-Neon)   | 128KB        | 229,285.2 ns |   486.52 ns |   455.09 ns |         - |
| Decrypt · XChaCha20-Poly1305 (NaCl.Core)          | 128KB        | 750,792.2 ns |   148.83 ns |   131.94 ns |      72 B |
| Decrypt · XChaCha20-Poly1305 (CryptoHives-Scalar) | 128KB        | 789,487.3 ns | 1,833.32 ns | 1,714.89 ns |         - |
|                                                   |              |              |             |             |           |
| Encrypt · XChaCha20-Poly1305 (CryptoHives-Neon)   | 128KB        | 230,297.4 ns |   451.66 ns |   400.39 ns |         - |
| Encrypt · XChaCha20-Poly1305 (NaCl.Core)          | 128KB        | 750,301.6 ns |   362.22 ns |   302.47 ns |      72 B |
| Encrypt · XChaCha20-Poly1305 (CryptoHives-Scalar) | 128KB        | 790,587.7 ns | 1,823.69 ns | 1,705.88 ns |         - |