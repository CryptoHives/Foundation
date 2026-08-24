| Description                                       | TestDataSize | Mean           | Error       | StdDev      | Allocated |
|-------------------------------------------------- |------------- |---------------:|------------:|------------:|----------:|
| Decrypt · XChaCha20-Poly1305 (CryptoHives-Neon)   | 128B         |     4,784.4 ns |     3.58 ns |     3.17 ns |         - |
| Decrypt · XChaCha20-Poly1305 (NaCl.Core)          | 128B         |     7,724.4 ns |     3.98 ns |     3.53 ns |      48 B |
| Decrypt · XChaCha20-Poly1305 (CryptoHives-Scalar) | 128B         |    10,125.3 ns |    71.35 ns |    66.74 ns |         - |
|                                                   |              |                |             |             |           |
| Encrypt · XChaCha20-Poly1305 (CryptoHives-Neon)   | 128B         |       830.3 ns |     4.94 ns |     4.62 ns |         - |
| Encrypt · XChaCha20-Poly1305 (NaCl.Core)          | 128B         |     1,480.7 ns |     6.86 ns |     6.42 ns |      48 B |
| Encrypt · XChaCha20-Poly1305 (CryptoHives-Scalar) | 128B         |     2,050.6 ns |     5.22 ns |     4.89 ns |         - |
|                                                   |              |                |             |             |           |
| Decrypt · XChaCha20-Poly1305 (CryptoHives-Neon)   | 1KB          |    13,178.3 ns |    13.58 ns |    12.70 ns |         - |
| Decrypt · XChaCha20-Poly1305 (NaCl.Core)          | 1KB          |    34,477.9 ns |    25.60 ns |    22.69 ns |      72 B |
| Decrypt · XChaCha20-Poly1305 (CryptoHives-Scalar) | 1KB          |    40,879.9 ns |    11.37 ns |     9.49 ns |         - |
|                                                   |              |                |             |             |           |
| Encrypt · XChaCha20-Poly1305 (CryptoHives-Neon)   | 1KB          |     2,523.5 ns |     9.65 ns |     8.56 ns |         - |
| Encrypt · XChaCha20-Poly1305 (NaCl.Core)          | 1KB          |     6,800.0 ns |    39.23 ns |    36.69 ns |      72 B |
| Encrypt · XChaCha20-Poly1305 (CryptoHives-Scalar) | 1KB          |     8,573.0 ns |     3.33 ns |     2.95 ns |         - |
|                                                   |              |                |             |             |           |
| Decrypt · XChaCha20-Poly1305 (CryptoHives-Neon)   | 8KB          |    78,070.5 ns |    78.26 ns |    65.35 ns |         - |
| Decrypt · XChaCha20-Poly1305 (NaCl.Core)          | 8KB          |   247,651.3 ns |   148.94 ns |   132.03 ns |      72 B |
| Decrypt · XChaCha20-Poly1305 (CryptoHives-Scalar) | 8KB          |   280,916.8 ns |   305.08 ns |   238.18 ns |         - |
|                                                   |              |                |             |             |           |
| Encrypt · XChaCha20-Poly1305 (CryptoHives-Neon)   | 8KB          |    15,625.0 ns |   120.60 ns |   112.81 ns |         - |
| Encrypt · XChaCha20-Poly1305 (NaCl.Core)          | 8KB          |    49,603.0 ns |   262.50 ns |   245.55 ns |      72 B |
| Encrypt · XChaCha20-Poly1305 (CryptoHives-Scalar) | 8KB          |    58,924.2 ns |     7.98 ns |     7.46 ns |         - |
|                                                   |              |                |             |             |           |
| Decrypt · XChaCha20-Poly1305 (CryptoHives-Neon)   | 128KB        | 1,189,635.8 ns | 2,393.37 ns | 2,121.66 ns |         - |
| Decrypt · XChaCha20-Poly1305 (NaCl.Core)          | 128KB        | 3,903,536.2 ns | 3,141.91 ns | 2,623.64 ns |      72 B |
| Decrypt · XChaCha20-Poly1305 (CryptoHives-Scalar) | 128KB        | 4,392,248.0 ns | 2,957.62 ns | 2,469.75 ns |         - |
|                                                   |              |                |             |             |           |
| Encrypt · XChaCha20-Poly1305 (CryptoHives-Neon)   | 128KB        |   242,769.9 ns | 1,010.81 ns |   844.07 ns |         - |
| Encrypt · XChaCha20-Poly1305 (CryptoHives-Scalar) | 128KB        |   921,438.0 ns |   122.89 ns |   108.94 ns |         - |
| Encrypt · XChaCha20-Poly1305 (NaCl.Core)          | 128KB        | 3,905,193.1 ns | 3,685.42 ns | 3,447.34 ns |      72 B |