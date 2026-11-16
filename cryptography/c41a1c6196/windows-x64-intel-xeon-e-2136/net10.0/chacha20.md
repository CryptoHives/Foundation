| Description                             | TestDataSize | Mean           | Error       | StdDev      | Code Size | Allocated |
|---------------------------------------- |------------- |---------------:|------------:|------------:|----------:|----------:|
| Decrypt · ChaCha20 (CryptoHives-AVX2)   | 128B         |       117.2 ns |     0.15 ns |     0.14 ns |   2,656 B |         - |
| Decrypt · ChaCha20 (CryptoHives-SSSE3)  | 128B         |       201.6 ns |     0.36 ns |     0.34 ns |   2,415 B |         - |
| Decrypt · ChaCha20 (NaCl.Core)          | 128B         |       507.1 ns |     1.81 ns |     1.60 ns |   7,363 B |      24 B |
| Decrypt · ChaCha20 (BouncyCastle)       | 128B         |       653.1 ns |     6.30 ns |     5.90 ns |     760 B |      96 B |
| Decrypt · ChaCha20 (CryptoHives-Scalar) | 128B         |     1,451.7 ns |     6.59 ns |     6.16 ns |   3,618 B |         - |
|                                         |              |                |             |             |           |           |
| Encrypt · ChaCha20 (CryptoHives-AVX2)   | 128B         |       122.1 ns |     0.32 ns |     0.30 ns |   2,656 B |         - |
| Encrypt · ChaCha20 (CryptoHives-SSSE3)  | 128B         |       198.7 ns |     0.25 ns |     0.24 ns |   2,415 B |         - |
| Encrypt · ChaCha20 (NaCl.Core)          | 128B         |       507.0 ns |     5.00 ns |     4.43 ns |   7,356 B |      24 B |
| Encrypt · ChaCha20 (BouncyCastle)       | 128B         |       654.5 ns |     8.21 ns |     7.68 ns |     760 B |      96 B |
| Encrypt · ChaCha20 (CryptoHives-Scalar) | 128B         |     1,471.1 ns |     6.57 ns |     6.14 ns |   3,652 B |         - |
|                                         |              |                |             |             |           |           |
| Decrypt · ChaCha20 (CryptoHives-AVX2)   | 1KB          |       777.2 ns |     0.80 ns |     0.67 ns |   2,656 B |         - |
| Decrypt · ChaCha20 (CryptoHives-SSSE3)  | 1KB          |     1,463.7 ns |     1.11 ns |     1.04 ns |   2,436 B |         - |
| Decrypt · ChaCha20 (NaCl.Core)          | 1KB          |     2,724.0 ns |    12.64 ns |    11.82 ns |   7,437 B |      24 B |
| Decrypt · ChaCha20 (BouncyCastle)       | 1KB          |     4,925.9 ns |    42.02 ns |    39.31 ns |     762 B |      96 B |
| Decrypt · ChaCha20 (CryptoHives-Scalar) | 1KB          |    11,435.1 ns |    46.32 ns |    43.33 ns |   3,618 B |         - |
|                                         |              |                |             |             |           |           |
| Encrypt · ChaCha20 (CryptoHives-AVX2)   | 1KB          |       788.2 ns |     0.52 ns |     0.43 ns |   2,656 B |         - |
| Encrypt · ChaCha20 (CryptoHives-SSSE3)  | 1KB          |     1,469.0 ns |     1.65 ns |     1.54 ns |   2,436 B |         - |
| Encrypt · ChaCha20 (NaCl.Core)          | 1KB          |     2,727.5 ns |    10.36 ns |     9.18 ns |   7,450 B |      24 B |
| Encrypt · ChaCha20 (BouncyCastle)       | 1KB          |     4,927.4 ns |    51.05 ns |    45.26 ns |     762 B |      96 B |
| Encrypt · ChaCha20 (CryptoHives-Scalar) | 1KB          |    11,402.4 ns |    53.64 ns |    50.18 ns |   3,618 B |         - |
|                                         |              |                |             |             |           |           |
| Decrypt · ChaCha20 (CryptoHives-AVX2)   | 8KB          |     6,090.4 ns |     4.89 ns |     4.33 ns |   2,677 B |         - |
| Decrypt · ChaCha20 (CryptoHives-SSSE3)  | 8KB          |    11,629.0 ns |    17.23 ns |    16.11 ns |   2,415 B |         - |
| Decrypt · ChaCha20 (NaCl.Core)          | 8KB          |    20,670.0 ns |   372.96 ns |   348.87 ns |   7,448 B |      24 B |
| Decrypt · ChaCha20 (BouncyCastle)       | 8KB          |    38,534.8 ns |   255.29 ns |   226.31 ns |     762 B |      96 B |
| Decrypt · ChaCha20 (CryptoHives-Scalar) | 8KB          |    90,967.6 ns |   307.43 ns |   272.53 ns |   3,618 B |         - |
|                                         |              |                |             |             |           |           |
| Encrypt · ChaCha20 (CryptoHives-AVX2)   | 8KB          |     6,088.3 ns |     3.23 ns |     3.02 ns |   2,677 B |         - |
| Encrypt · ChaCha20 (CryptoHives-SSSE3)  | 8KB          |    11,604.1 ns |     9.14 ns |     8.11 ns |   2,436 B |         - |
| Encrypt · ChaCha20 (NaCl.Core)          | 8KB          |    20,385.0 ns |   137.00 ns |   128.15 ns |   7,448 B |      24 B |
| Encrypt · ChaCha20 (BouncyCastle)       | 8KB          |    38,419.4 ns |   187.25 ns |   156.36 ns |     762 B |      96 B |
| Encrypt · ChaCha20 (CryptoHives-Scalar) | 8KB          |    90,886.2 ns |   447.80 ns |   418.88 ns |   3,618 B |         - |
|                                         |              |                |             |             |           |           |
| Decrypt · ChaCha20 (CryptoHives-AVX2)   | 128KB        |    96,996.7 ns |    43.98 ns |    38.98 ns |   2,656 B |         - |
| Decrypt · ChaCha20 (CryptoHives-SSSE3)  | 128KB        |   184,678.6 ns |   157.06 ns |   146.92 ns |   2,415 B |         - |
| Decrypt · ChaCha20 (NaCl.Core)          | 128KB        |   329,397.7 ns | 3,765.49 ns | 3,522.24 ns |   7,459 B |      24 B |
| Decrypt · ChaCha20 (BouncyCastle)       | 128KB        |   614,899.6 ns | 5,288.71 ns | 4,416.31 ns |     762 B |      96 B |
| Decrypt · ChaCha20 (CryptoHives-Scalar) | 128KB        | 1,464,224.4 ns | 8,135.42 ns | 7,609.88 ns |   3,618 B |         - |
|                                         |              |                |             |             |           |           |
| Encrypt · ChaCha20 (CryptoHives-AVX2)   | 128KB        |    96,991.6 ns |    73.46 ns |    68.71 ns |   2,677 B |         - |
| Encrypt · ChaCha20 (CryptoHives-SSSE3)  | 128KB        |   184,848.6 ns |   158.88 ns |   148.62 ns |   2,423 B |         - |
| Encrypt · ChaCha20 (NaCl.Core)          | 128KB        |   340,764.5 ns | 3,949.78 ns | 3,694.63 ns |   7,437 B |      24 B |
| Encrypt · ChaCha20 (BouncyCastle)       | 128KB        |   614,912.1 ns | 4,727.22 ns | 4,190.56 ns |     762 B |      96 B |
| Encrypt · ChaCha20 (CryptoHives-Scalar) | 128KB        | 1,463,144.9 ns | 7,651.31 ns | 7,157.04 ns |   3,618 B |         - |