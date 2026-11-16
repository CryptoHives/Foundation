| Description                                       | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|-------------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|
| Decrypt · XChaCha20-Poly1305 (CryptoHives-Neon)   | 128B         |     864.5 ns |     2.99 ns |     2.79 ns |         - |
| Decrypt · XChaCha20-Poly1305 (NaCl.Core)          | 128B         |   1,504.9 ns |     6.64 ns |     6.21 ns |      48 B |
| Decrypt · XChaCha20-Poly1305 (CryptoHives-Scalar) | 128B         |   1,897.7 ns |     6.11 ns |     5.72 ns |         - |
|                                                   |              |              |             |             |           |
| Encrypt · XChaCha20-Poly1305 (CryptoHives-Neon)   | 128B         |     755.1 ns |     1.95 ns |     1.83 ns |         - |
| Encrypt · XChaCha20-Poly1305 (NaCl.Core)          | 128B         |   1,470.3 ns |     4.06 ns |     3.80 ns |      48 B |
| Encrypt · XChaCha20-Poly1305 (CryptoHives-Scalar) | 128B         |   1,848.1 ns |     5.09 ns |     4.76 ns |         - |
|                                                   |              |              |             |             |           |
| Decrypt · XChaCha20-Poly1305 (CryptoHives-Neon)   | 1KB          |   2,425.2 ns |     6.85 ns |     6.41 ns |         - |
| Decrypt · XChaCha20-Poly1305 (NaCl.Core)          | 1KB          |   6,689.4 ns |    46.74 ns |    43.72 ns |      72 B |
| Decrypt · XChaCha20-Poly1305 (CryptoHives-Scalar) | 1KB          |   8,104.6 ns |    57.31 ns |    53.61 ns |         - |
|                                                   |              |              |             |             |           |
| Encrypt · XChaCha20-Poly1305 (CryptoHives-Neon)   | 1KB          |   2,316.2 ns |     8.10 ns |     7.57 ns |         - |
| Encrypt · XChaCha20-Poly1305 (NaCl.Core)          | 1KB          |   6,683.8 ns |    18.26 ns |    17.08 ns |      72 B |
| Encrypt · XChaCha20-Poly1305 (CryptoHives-Scalar) | 1KB          |   7,960.4 ns |    59.80 ns |    55.94 ns |         - |
|                                                   |              |              |             |             |           |
| Decrypt · XChaCha20-Poly1305 (CryptoHives-Neon)   | 8KB          |  14,771.9 ns |    31.33 ns |    27.77 ns |         - |
| Decrypt · XChaCha20-Poly1305 (NaCl.Core)          | 8KB          |  48,288.1 ns |   136.86 ns |   128.02 ns |      72 B |
| Decrypt · XChaCha20-Poly1305 (CryptoHives-Scalar) | 8KB          |  57,677.1 ns |   222.63 ns |   208.25 ns |         - |
|                                                   |              |              |             |             |           |
| Encrypt · XChaCha20-Poly1305 (CryptoHives-Neon)   | 8KB          |  14,834.9 ns |    37.28 ns |    34.87 ns |         - |
| Encrypt · XChaCha20-Poly1305 (NaCl.Core)          | 8KB          |  48,245.6 ns |   146.75 ns |   137.27 ns |      72 B |
| Encrypt · XChaCha20-Poly1305 (CryptoHives-Scalar) | 8KB          |  56,866.0 ns |   136.88 ns |   128.04 ns |         - |
|                                                   |              |              |             |             |           |
| Decrypt · XChaCha20-Poly1305 (CryptoHives-Neon)   | 128KB        | 228,386.5 ns |   507.72 ns |   474.92 ns |         - |
| Decrypt · XChaCha20-Poly1305 (NaCl.Core)          | 128KB        | 760,271.1 ns | 2,509.32 ns | 2,347.22 ns |      72 B |
| Decrypt · XChaCha20-Poly1305 (CryptoHives-Scalar) | 128KB        | 906,545.1 ns | 2,536.71 ns | 2,248.73 ns |         - |
|                                                   |              |              |             |             |           |
| Encrypt · XChaCha20-Poly1305 (CryptoHives-Neon)   | 128KB        | 228,780.4 ns |   561.51 ns |   525.24 ns |         - |
| Encrypt · XChaCha20-Poly1305 (NaCl.Core)          | 128KB        | 760,951.5 ns | 2,554.17 ns | 2,389.17 ns |      72 B |
| Encrypt · XChaCha20-Poly1305 (CryptoHives-Scalar) | 128KB        | 895,775.9 ns | 2,835.42 ns | 2,652.25 ns |         - |