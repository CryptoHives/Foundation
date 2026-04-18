| Description                                       | TestDataSize | Mean         | Error       | StdDev      | Median       | Allocated |
|-------------------------------------------------- |------------- |-------------:|------------:|------------:|-------------:|----------:|
| Decrypt · XChaCha20-Poly1305 (CryptoHives-Neon)   | 128B         |     870.8 ns |     7.85 ns |     6.96 ns |     869.1 ns |         - |
| Decrypt · XChaCha20-Poly1305 (NaCl.Core)          | 128B         |   1,494.1 ns |     1.85 ns |     1.64 ns |   1,493.5 ns |      48 B |
| Decrypt · XChaCha20-Poly1305 (CryptoHives-Scalar) | 128B         |   1,777.1 ns |    10.78 ns |     9.00 ns |   1,774.8 ns |         - |
|                                                   |              |              |             |             |              |           |
| Encrypt · XChaCha20-Poly1305 (CryptoHives-Neon)   | 128B         |     724.6 ns |     5.29 ns |     4.95 ns |     726.2 ns |         - |
| Encrypt · XChaCha20-Poly1305 (NaCl.Core)          | 128B         |   1,448.5 ns |     1.33 ns |     1.18 ns |   1,447.9 ns |      48 B |
| Encrypt · XChaCha20-Poly1305 (CryptoHives-Scalar) | 128B         |   1,681.4 ns |     9.47 ns |     8.39 ns |   1,681.9 ns |         - |
|                                                   |              |              |             |             |              |           |
| Decrypt · XChaCha20-Poly1305 (CryptoHives-Neon)   | 1KB          |   2,468.2 ns |     2.50 ns |     2.21 ns |   2,467.3 ns |         - |
| Decrypt · XChaCha20-Poly1305 (NaCl.Core)          | 1KB          |   6,662.1 ns |    54.00 ns |    45.10 ns |   6,647.6 ns |      72 B |
| Decrypt · XChaCha20-Poly1305 (CryptoHives-Scalar) | 1KB          |   7,248.1 ns |    28.61 ns |    23.89 ns |   7,255.3 ns |         - |
|                                                   |              |              |             |             |              |           |
| Encrypt · XChaCha20-Poly1305 (CryptoHives-Neon)   | 1KB          |   2,360.2 ns |     1.34 ns |     1.12 ns |   2,360.2 ns |         - |
| Encrypt · XChaCha20-Poly1305 (NaCl.Core)          | 1KB          |   6,632.1 ns |    91.79 ns |    81.37 ns |   6,590.8 ns |      72 B |
| Encrypt · XChaCha20-Poly1305 (CryptoHives-Scalar) | 1KB          |   7,140.9 ns |    22.92 ns |    20.32 ns |   7,141.7 ns |         - |
|                                                   |              |              |             |             |              |           |
| Decrypt · XChaCha20-Poly1305 (CryptoHives-Neon)   | 8KB          |  14,941.5 ns |    12.66 ns |    10.57 ns |  14,938.7 ns |         - |
| Decrypt · XChaCha20-Poly1305 (NaCl.Core)          | 8KB          |  48,078.7 ns |   590.11 ns |   551.99 ns |  47,752.9 ns |      72 B |
| Decrypt · XChaCha20-Poly1305 (CryptoHives-Scalar) | 8KB          |  49,552.9 ns |   159.09 ns |   141.03 ns |  49,545.3 ns |         - |
|                                                   |              |              |             |             |              |           |
| Encrypt · XChaCha20-Poly1305 (CryptoHives-Neon)   | 8KB          |  14,876.7 ns |     4.58 ns |     3.58 ns |  14,875.9 ns |         - |
| Encrypt · XChaCha20-Poly1305 (CryptoHives-Scalar) | 8KB          |  49,262.7 ns |   197.17 ns |   184.43 ns |  49,166.9 ns |         - |
| Encrypt · XChaCha20-Poly1305 (NaCl.Core)          | 8KB          |  49,715.8 ns |   987.01 ns | 2,402.51 ns |  48,239.9 ns |      72 B |
|                                                   |              |              |             |             |              |           |
| Decrypt · XChaCha20-Poly1305 (CryptoHives-Neon)   | 128KB        | 230,374.7 ns | 1,734.54 ns | 1,448.42 ns | 230,310.9 ns |         - |
| Decrypt · XChaCha20-Poly1305 (NaCl.Core)          | 128KB        | 753,041.0 ns | 2,679.29 ns | 2,375.12 ns | 752,726.2 ns |      72 B |
| Decrypt · XChaCha20-Poly1305 (CryptoHives-Scalar) | 128KB        | 778,248.7 ns | 5,998.17 ns | 5,317.22 ns | 777,958.1 ns |         - |
|                                                   |              |              |             |             |              |           |
| Encrypt · XChaCha20-Poly1305 (CryptoHives-Neon)   | 128KB        | 232,627.7 ns | 3,798.88 ns | 3,553.47 ns | 231,496.5 ns |         - |
| Encrypt · XChaCha20-Poly1305 (NaCl.Core)          | 128KB        | 754,021.8 ns | 2,403.71 ns | 2,130.83 ns | 753,460.4 ns |      72 B |
| Encrypt · XChaCha20-Poly1305 (CryptoHives-Scalar) | 128KB        | 785,492.5 ns | 3,332.60 ns | 2,782.87 ns | 784,970.5 ns |         - |