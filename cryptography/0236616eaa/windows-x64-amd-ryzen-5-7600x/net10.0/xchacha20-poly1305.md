| Description                                       | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|-------------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|
| Decrypt · XChaCha20-Poly1305 (CryptoHives-AVX2)   | 128B         |     567.4 ns |     0.96 ns |     0.80 ns |         - |
| Decrypt · XChaCha20-Poly1305 (CryptoHives-SSSE3)  | 128B         |     622.3 ns |     0.77 ns |     0.68 ns |         - |
| Decrypt · XChaCha20-Poly1305 (NaCl.Core)          | 128B         |     967.5 ns |     2.07 ns |     1.84 ns |      48 B |
| Decrypt · XChaCha20-Poly1305 (CryptoHives-Scalar) | 128B         |   1,123.4 ns |     1.18 ns |     1.05 ns |         - |
|                                                   |              |              |             |             |           |
| Encrypt · XChaCha20-Poly1305 (CryptoHives-AVX2)   | 128B         |     506.5 ns |     1.11 ns |     0.98 ns |         - |
| Encrypt · XChaCha20-Poly1305 (CryptoHives-SSSE3)  | 128B         |     572.0 ns |     1.07 ns |     1.00 ns |         - |
| Encrypt · XChaCha20-Poly1305 (NaCl.Core)          | 128B         |     916.3 ns |     3.53 ns |     3.13 ns |      48 B |
| Encrypt · XChaCha20-Poly1305 (CryptoHives-Scalar) | 128B         |   1,068.8 ns |     1.68 ns |     1.31 ns |         - |
|                                                   |              |              |             |             |           |
| Decrypt · XChaCha20-Poly1305 (CryptoHives-AVX2)   | 1KB          |   1,490.9 ns |     1.71 ns |     1.42 ns |         - |
| Decrypt · XChaCha20-Poly1305 (CryptoHives-SSSE3)  | 1KB          |   1,948.7 ns |     3.34 ns |     2.79 ns |         - |
| Decrypt · XChaCha20-Poly1305 (NaCl.Core)          | 1KB          |   4,210.1 ns |     8.86 ns |     7.85 ns |      72 B |
| Decrypt · XChaCha20-Poly1305 (CryptoHives-Scalar) | 1KB          |   4,791.4 ns |     6.87 ns |     5.74 ns |         - |
|                                                   |              |              |             |             |           |
| Encrypt · XChaCha20-Poly1305 (CryptoHives-AVX2)   | 1KB          |   1,464.8 ns |     2.63 ns |     2.33 ns |         - |
| Encrypt · XChaCha20-Poly1305 (CryptoHives-SSSE3)  | 1KB          |   1,899.8 ns |     0.97 ns |     0.81 ns |         - |
| Encrypt · XChaCha20-Poly1305 (NaCl.Core)          | 1KB          |   4,203.8 ns |    14.57 ns |    13.63 ns |      72 B |
| Encrypt · XChaCha20-Poly1305 (CryptoHives-Scalar) | 1KB          |   4,761.5 ns |    11.45 ns |     9.56 ns |         - |
|                                                   |              |              |             |             |           |
| Decrypt · XChaCha20-Poly1305 (CryptoHives-AVX2)   | 8KB          |   8,984.1 ns |    18.17 ns |    16.11 ns |         - |
| Decrypt · XChaCha20-Poly1305 (CryptoHives-SSSE3)  | 8KB          |  12,548.2 ns |    14.99 ns |    12.52 ns |         - |
| Decrypt · XChaCha20-Poly1305 (NaCl.Core)          | 8KB          |  30,079.9 ns |    48.72 ns |    45.57 ns |      72 B |
| Decrypt · XChaCha20-Poly1305 (CryptoHives-Scalar) | 8KB          |  34,309.1 ns |    70.16 ns |    65.63 ns |         - |
|                                                   |              |              |             |             |           |
| Encrypt · XChaCha20-Poly1305 (CryptoHives-AVX2)   | 8KB          |   8,929.0 ns |    13.04 ns |    11.56 ns |         - |
| Encrypt · XChaCha20-Poly1305 (CryptoHives-SSSE3)  | 8KB          |  12,536.1 ns |     9.71 ns |     8.61 ns |         - |
| Encrypt · XChaCha20-Poly1305 (NaCl.Core)          | 8KB          |  30,237.5 ns |    35.66 ns |    29.78 ns |      72 B |
| Encrypt · XChaCha20-Poly1305 (CryptoHives-Scalar) | 8KB          |  34,222.1 ns |    69.66 ns |    58.17 ns |         - |
|                                                   |              |              |             |             |           |
| Decrypt · XChaCha20-Poly1305 (CryptoHives-AVX2)   | 128KB        | 136,962.8 ns |   256.89 ns |   214.51 ns |         - |
| Decrypt · XChaCha20-Poly1305 (CryptoHives-SSSE3)  | 128KB        | 195,135.1 ns |   167.19 ns |   156.39 ns |         - |
| Decrypt · XChaCha20-Poly1305 (NaCl.Core)          | 128KB        | 478,484.9 ns | 1,584.23 ns | 1,404.38 ns |      72 B |
| Decrypt · XChaCha20-Poly1305 (CryptoHives-Scalar) | 128KB        | 540,334.2 ns |   566.52 ns |   502.20 ns |         - |
|                                                   |              |              |             |             |           |
| Encrypt · XChaCha20-Poly1305 (CryptoHives-AVX2)   | 128KB        | 136,864.7 ns |   149.86 ns |   125.14 ns |         - |
| Encrypt · XChaCha20-Poly1305 (CryptoHives-SSSE3)  | 128KB        | 195,132.6 ns |   422.74 ns |   353.01 ns |         - |
| Encrypt · XChaCha20-Poly1305 (NaCl.Core)          | 128KB        | 475,864.3 ns |   964.76 ns |   855.23 ns |      72 B |
| Encrypt · XChaCha20-Poly1305 (CryptoHives-Scalar) | 128KB        | 538,234.7 ns | 1,171.41 ns | 1,095.74 ns |         - |