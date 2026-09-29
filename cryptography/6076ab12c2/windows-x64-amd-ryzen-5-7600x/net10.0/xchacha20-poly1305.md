| Description                                       | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|-------------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|
| Decrypt · XChaCha20-Poly1305 (CryptoHives-AVX2)   | 128B         |     647.7 ns |     3.15 ns |     2.94 ns |         - |
| Decrypt · XChaCha20-Poly1305 (CryptoHives-SSSE3)  | 128B         |     718.1 ns |     4.88 ns |     4.56 ns |         - |
| Decrypt · XChaCha20-Poly1305 (NaCl.Core)          | 128B         |   1,125.4 ns |     9.50 ns |     8.89 ns |      48 B |
| Decrypt · XChaCha20-Poly1305 (CryptoHives-Scalar) | 128B         |   1,291.9 ns |     7.40 ns |     6.18 ns |         - |
|                                                   |              |              |             |             |           |
| Encrypt · XChaCha20-Poly1305 (CryptoHives-AVX2)   | 128B         |     589.4 ns |     3.78 ns |     3.54 ns |         - |
| Encrypt · XChaCha20-Poly1305 (CryptoHives-SSSE3)  | 128B         |     655.1 ns |     3.77 ns |     3.52 ns |         - |
| Encrypt · XChaCha20-Poly1305 (NaCl.Core)          | 128B         |   1,073.8 ns |     7.15 ns |     6.68 ns |      48 B |
| Encrypt · XChaCha20-Poly1305 (CryptoHives-Scalar) | 128B         |   1,240.6 ns |     8.74 ns |     8.18 ns |         - |
|                                                   |              |              |             |             |           |
| Decrypt · XChaCha20-Poly1305 (CryptoHives-AVX2)   | 1KB          |   1,745.8 ns |     8.16 ns |     7.64 ns |         - |
| Decrypt · XChaCha20-Poly1305 (CryptoHives-SSSE3)  | 1KB          |   2,294.3 ns |     9.05 ns |     8.47 ns |         - |
| Decrypt · XChaCha20-Poly1305 (NaCl.Core)          | 1KB          |   4,953.3 ns |    34.12 ns |    31.92 ns |      72 B |
| Decrypt · XChaCha20-Poly1305 (CryptoHives-Scalar) | 1KB          |   5,541.7 ns |    43.46 ns |    40.65 ns |         - |
|                                                   |              |              |             |             |           |
| Encrypt · XChaCha20-Poly1305 (CryptoHives-AVX2)   | 1KB          |   1,683.5 ns |    10.08 ns |     9.43 ns |         - |
| Encrypt · XChaCha20-Poly1305 (CryptoHives-SSSE3)  | 1KB          |   2,234.9 ns |     9.35 ns |     8.74 ns |         - |
| Encrypt · XChaCha20-Poly1305 (NaCl.Core)          | 1KB          |   4,950.7 ns |    27.79 ns |    26.00 ns |      72 B |
| Encrypt · XChaCha20-Poly1305 (CryptoHives-Scalar) | 1KB          |   5,489.4 ns |    42.35 ns |    39.62 ns |         - |
|                                                   |              |              |             |             |           |
| Decrypt · XChaCha20-Poly1305 (CryptoHives-AVX2)   | 8KB          |  10,492.9 ns |    51.83 ns |    45.95 ns |         - |
| Decrypt · XChaCha20-Poly1305 (CryptoHives-SSSE3)  | 8KB          |  14,861.1 ns |    49.97 ns |    46.75 ns |         - |
| Decrypt · XChaCha20-Poly1305 (NaCl.Core)          | 8KB          |  39,438.9 ns |   106.67 ns |    99.78 ns |      72 B |
| Decrypt · XChaCha20-Poly1305 (CryptoHives-Scalar) | 8KB          |  39,510.7 ns |   271.40 ns |   253.87 ns |         - |
|                                                   |              |              |             |             |           |
| Encrypt · XChaCha20-Poly1305 (CryptoHives-AVX2)   | 8KB          |  10,426.4 ns |    43.60 ns |    40.79 ns |         - |
| Encrypt · XChaCha20-Poly1305 (CryptoHives-SSSE3)  | 8KB          |  14,809.2 ns |    40.77 ns |    38.14 ns |         - |
| Encrypt · XChaCha20-Poly1305 (NaCl.Core)          | 8KB          |  35,683.5 ns |   175.40 ns |   164.07 ns |      72 B |
| Encrypt · XChaCha20-Poly1305 (CryptoHives-Scalar) | 8KB          |  39,418.6 ns |   217.56 ns |   203.50 ns |         - |
|                                                   |              |              |             |             |           |
| Decrypt · XChaCha20-Poly1305 (CryptoHives-AVX2)   | 128KB        | 160,482.7 ns |   652.37 ns |   610.23 ns |         - |
| Decrypt · XChaCha20-Poly1305 (CryptoHives-SSSE3)  | 128KB        | 230,673.7 ns |   679.76 ns |   635.84 ns |         - |
| Decrypt · XChaCha20-Poly1305 (NaCl.Core)          | 128KB        | 567,402.0 ns | 3,405.86 ns | 3,185.84 ns |      72 B |
| Decrypt · XChaCha20-Poly1305 (CryptoHives-Scalar) | 128KB        | 622,015.3 ns | 5,212.14 ns | 4,875.44 ns |         - |
|                                                   |              |              |             |             |           |
| Encrypt · XChaCha20-Poly1305 (CryptoHives-AVX2)   | 128KB        | 160,111.0 ns |   627.94 ns |   587.38 ns |         - |
| Encrypt · XChaCha20-Poly1305 (CryptoHives-SSSE3)  | 128KB        | 230,515.8 ns |   606.77 ns |   567.58 ns |         - |
| Encrypt · XChaCha20-Poly1305 (NaCl.Core)          | 128KB        | 561,352.1 ns | 3,554.00 ns | 3,324.41 ns |      72 B |
| Encrypt · XChaCha20-Poly1305 (CryptoHives-Scalar) | 128KB        | 620,597.1 ns | 5,057.37 ns | 4,730.66 ns |         - |