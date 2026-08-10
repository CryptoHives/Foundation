| Description                                       | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|-------------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|
| Decrypt · XChaCha20-Poly1305 (CryptoHives-Neon)   | 128B         |     896.0 ns |     2.49 ns |     2.33 ns |         - |
| Decrypt · XChaCha20-Poly1305 (NaCl.Core)          | 128B         |   1,493.3 ns |     3.73 ns |     3.49 ns |      48 B |
| Decrypt · XChaCha20-Poly1305 (CryptoHives-Scalar) | 128B         |   1,804.9 ns |     6.15 ns |     5.75 ns |         - |
|                                                   |              |              |             |             |           |
| Encrypt · XChaCha20-Poly1305 (CryptoHives-Neon)   | 128B         |     750.2 ns |     6.31 ns |     5.90 ns |         - |
| Encrypt · XChaCha20-Poly1305 (NaCl.Core)          | 128B         |   1,458.9 ns |     3.71 ns |     3.47 ns |      48 B |
| Encrypt · XChaCha20-Poly1305 (CryptoHives-Scalar) | 128B         |   1,724.8 ns |     6.67 ns |     6.24 ns |         - |
|                                                   |              |              |             |             |           |
| Decrypt · XChaCha20-Poly1305 (CryptoHives-Neon)   | 1KB          |   2,511.7 ns |    16.03 ns |    15.00 ns |         - |
| Decrypt · XChaCha20-Poly1305 (NaCl.Core)          | 1KB          |   6,670.8 ns |     6.65 ns |     6.22 ns |      72 B |
| Decrypt · XChaCha20-Poly1305 (CryptoHives-Scalar) | 1KB          |   7,436.3 ns |    24.70 ns |    23.11 ns |         - |
|                                                   |              |              |             |             |           |
| Encrypt · XChaCha20-Poly1305 (CryptoHives-Neon)   | 1KB          |   2,385.2 ns |    10.43 ns |     9.76 ns |         - |
| Encrypt · XChaCha20-Poly1305 (NaCl.Core)          | 1KB          |   6,617.4 ns |    17.14 ns |    16.03 ns |      72 B |
| Encrypt · XChaCha20-Poly1305 (CryptoHives-Scalar) | 1KB          |   7,390.1 ns |    17.32 ns |    15.36 ns |         - |
|                                                   |              |              |             |             |           |
| Decrypt · XChaCha20-Poly1305 (CryptoHives-Neon)   | 8KB          |  15,054.1 ns |    48.83 ns |    45.68 ns |         - |
| Decrypt · XChaCha20-Poly1305 (NaCl.Core)          | 8KB          |  47,897.5 ns |    41.39 ns |    38.72 ns |      72 B |
| Decrypt · XChaCha20-Poly1305 (CryptoHives-Scalar) | 8KB          |  50,975.7 ns |   166.25 ns |   155.51 ns |         - |
|                                                   |              |              |             |             |           |
| Encrypt · XChaCha20-Poly1305 (CryptoHives-Neon)   | 8KB          |  14,975.4 ns |    30.53 ns |    28.56 ns |         - |
| Encrypt · XChaCha20-Poly1305 (NaCl.Core)          | 8KB          |  47,877.8 ns |    70.68 ns |    66.11 ns |      72 B |
| Encrypt · XChaCha20-Poly1305 (CryptoHives-Scalar) | 8KB          |  50,873.6 ns |   151.01 ns |   141.26 ns |         - |
|                                                   |              |              |             |             |           |
| Decrypt · XChaCha20-Poly1305 (CryptoHives-Neon)   | 128KB        | 230,467.0 ns |   687.46 ns |   643.05 ns |         - |
| Decrypt · XChaCha20-Poly1305 (NaCl.Core)          | 128KB        | 755,165.9 ns |   968.31 ns |   905.76 ns |      72 B |
| Decrypt · XChaCha20-Poly1305 (CryptoHives-Scalar) | 128KB        | 798,526.9 ns | 1,521.36 ns | 1,348.65 ns |         - |
|                                                   |              |              |             |             |           |
| Encrypt · XChaCha20-Poly1305 (CryptoHives-Neon)   | 128KB        | 231,229.7 ns |   550.00 ns |   514.47 ns |         - |
| Encrypt · XChaCha20-Poly1305 (NaCl.Core)          | 128KB        | 754,702.7 ns |   858.98 ns |   803.49 ns |      72 B |
| Encrypt · XChaCha20-Poly1305 (CryptoHives-Scalar) | 128KB        | 797,935.6 ns | 2,844.50 ns | 2,660.75 ns |         - |