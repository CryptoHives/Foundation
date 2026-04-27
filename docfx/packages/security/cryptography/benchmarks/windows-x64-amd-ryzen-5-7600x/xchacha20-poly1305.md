| Description                                       | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|-------------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|
| Decrypt · XChaCha20-Poly1305 (CryptoHives-AVX2)   | 128B         |     551.9 ns |     1.92 ns |     1.79 ns |         - |
| Decrypt · XChaCha20-Poly1305 (CryptoHives-SSSE3)  | 128B         |     618.3 ns |     1.46 ns |     1.22 ns |         - |
| Decrypt · XChaCha20-Poly1305 (NaCl.Core)          | 128B         |     909.9 ns |     2.38 ns |     2.11 ns |      48 B |
| Decrypt · XChaCha20-Poly1305 (CryptoHives-Scalar) | 128B         |   1,092.6 ns |     3.97 ns |     3.72 ns |         - |
|                                                   |              |              |             |             |           |
| Encrypt · XChaCha20-Poly1305 (CryptoHives-AVX2)   | 128B         |     489.9 ns |     1.69 ns |     1.50 ns |         - |
| Encrypt · XChaCha20-Poly1305 (CryptoHives-SSSE3)  | 128B         |     564.9 ns |     1.63 ns |     1.53 ns |         - |
| Encrypt · XChaCha20-Poly1305 (NaCl.Core)          | 128B         |     870.5 ns |     2.57 ns |     2.40 ns |      48 B |
| Encrypt · XChaCha20-Poly1305 (CryptoHives-Scalar) | 128B         |   1,065.2 ns |    12.29 ns |    11.50 ns |         - |
|                                                   |              |              |             |             |           |
| Decrypt · XChaCha20-Poly1305 (CryptoHives-AVX2)   | 1KB          |   1,471.9 ns |     3.54 ns |     3.31 ns |         - |
| Decrypt · XChaCha20-Poly1305 (CryptoHives-SSSE3)  | 1KB          |   1,944.4 ns |     4.55 ns |     4.25 ns |         - |
| Decrypt · XChaCha20-Poly1305 (NaCl.Core)          | 1KB          |   4,052.2 ns |    15.09 ns |    14.12 ns |      72 B |
| Decrypt · XChaCha20-Poly1305 (CryptoHives-Scalar) | 1KB          |   4,689.3 ns |     9.95 ns |     8.82 ns |         - |
|                                                   |              |              |             |             |           |
| Encrypt · XChaCha20-Poly1305 (CryptoHives-AVX2)   | 1KB          |   1,449.3 ns |     3.69 ns |     3.27 ns |         - |
| Encrypt · XChaCha20-Poly1305 (CryptoHives-SSSE3)  | 1KB          |   1,890.9 ns |     2.76 ns |     2.58 ns |         - |
| Encrypt · XChaCha20-Poly1305 (NaCl.Core)          | 1KB          |   4,011.0 ns |    15.61 ns |    14.61 ns |      72 B |
| Encrypt · XChaCha20-Poly1305 (CryptoHives-Scalar) | 1KB          |   4,641.2 ns |    17.11 ns |    16.00 ns |         - |
|                                                   |              |              |             |             |           |
| Decrypt · XChaCha20-Poly1305 (CryptoHives-AVX2)   | 8KB          |   8,902.7 ns |    27.83 ns |    24.67 ns |         - |
| Decrypt · XChaCha20-Poly1305 (CryptoHives-SSSE3)  | 8KB          |  12,549.1 ns |    24.66 ns |    21.86 ns |         - |
| Decrypt · XChaCha20-Poly1305 (NaCl.Core)          | 8KB          |  29,255.7 ns |    84.43 ns |    78.97 ns |      72 B |
| Decrypt · XChaCha20-Poly1305 (CryptoHives-Scalar) | 8KB          |  33,486.7 ns |   112.23 ns |   104.98 ns |         - |
|                                                   |              |              |             |             |           |
| Encrypt · XChaCha20-Poly1305 (CryptoHives-AVX2)   | 8KB          |   8,827.2 ns |    17.23 ns |    16.12 ns |         - |
| Encrypt · XChaCha20-Poly1305 (CryptoHives-SSSE3)  | 8KB          |  12,497.0 ns |    15.73 ns |    14.71 ns |         - |
| Encrypt · XChaCha20-Poly1305 (NaCl.Core)          | 8KB          |  29,102.1 ns |   107.45 ns |    95.25 ns |      72 B |
| Encrypt · XChaCha20-Poly1305 (CryptoHives-Scalar) | 8KB          |  33,491.0 ns |   181.38 ns |   160.79 ns |         - |
|                                                   |              |              |             |             |           |
| Decrypt · XChaCha20-Poly1305 (CryptoHives-AVX2)   | 128KB        | 135,896.0 ns |   296.21 ns |   277.07 ns |         - |
| Decrypt · XChaCha20-Poly1305 (CryptoHives-SSSE3)  | 128KB        | 194,242.9 ns |   379.20 ns |   354.70 ns |         - |
| Decrypt · XChaCha20-Poly1305 (NaCl.Core)          | 128KB        | 459,540.5 ns | 1,289.56 ns | 1,143.17 ns |      72 B |
| Decrypt · XChaCha20-Poly1305 (CryptoHives-Scalar) | 128KB        | 528,010.4 ns | 1,441.38 ns | 1,348.27 ns |         - |
|                                                   |              |              |             |             |           |
| Encrypt · XChaCha20-Poly1305 (CryptoHives-AVX2)   | 128KB        | 135,850.3 ns |   314.75 ns |   279.02 ns |         - |
| Encrypt · XChaCha20-Poly1305 (CryptoHives-SSSE3)  | 128KB        | 194,470.6 ns |   417.31 ns |   369.94 ns |         - |
| Encrypt · XChaCha20-Poly1305 (NaCl.Core)          | 128KB        | 462,093.2 ns | 1,652.95 ns | 1,546.17 ns |      72 B |
| Encrypt · XChaCha20-Poly1305 (CryptoHives-Scalar) | 128KB        | 525,017.3 ns | 1,013.39 ns |   846.22 ns |         - |