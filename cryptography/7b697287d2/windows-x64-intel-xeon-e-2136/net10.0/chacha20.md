| Description                             | TestDataSize | Mean           | Error       | StdDev      | Code Size | Allocated |
|---------------------------------------- |------------- |---------------:|------------:|------------:|----------:|----------:|
| Decrypt · ChaCha20 (CryptoHives-AVX2)   | 128B         |       123.1 ns |     0.16 ns |     0.15 ns |   2,656 B |         - |
| Decrypt · ChaCha20 (CryptoHives-SSSE3)  | 128B         |       198.9 ns |     0.12 ns |     0.11 ns |   2,415 B |         - |
| Decrypt · ChaCha20 (NaCl.Core)          | 128B         |       514.6 ns |     0.62 ns |     0.55 ns |   7,400 B |      24 B |
| Decrypt · ChaCha20 (BouncyCastle)       | 128B         |       649.7 ns |     1.60 ns |     1.50 ns |     760 B |      96 B |
| Decrypt · ChaCha20 (CryptoHives-Scalar) | 128B         |     1,460.0 ns |     4.10 ns |     3.83 ns |   3,639 B |         - |
|                                         |              |                |             |             |           |           |
| Encrypt · ChaCha20 (CryptoHives-AVX2)   | 128B         |       117.0 ns |     0.19 ns |     0.18 ns |   2,656 B |         - |
| Encrypt · ChaCha20 (CryptoHives-SSSE3)  | 128B         |       207.4 ns |     0.10 ns |     0.09 ns |   2,415 B |         - |
| Encrypt · ChaCha20 (NaCl.Core)          | 128B         |       507.7 ns |     1.27 ns |     1.13 ns |   7,349 B |      24 B |
| Encrypt · ChaCha20 (BouncyCastle)       | 128B         |       657.2 ns |     1.70 ns |     1.59 ns |     762 B |      96 B |
| Encrypt · ChaCha20 (CryptoHives-Scalar) | 128B         |     1,459.2 ns |     1.60 ns |     1.42 ns |   3,618 B |         - |
|                                         |              |                |             |             |           |           |
| Decrypt · ChaCha20 (CryptoHives-AVX2)   | 1KB          |       785.5 ns |     0.39 ns |     0.34 ns |   2,656 B |         - |
| Decrypt · ChaCha20 (CryptoHives-SSSE3)  | 1KB          |     1,473.5 ns |     0.99 ns |     0.92 ns |   2,415 B |         - |
| Decrypt · ChaCha20 (NaCl.Core)          | 1KB          |     2,742.9 ns |     3.69 ns |     3.27 ns |   7,450 B |      24 B |
| Decrypt · ChaCha20 (BouncyCastle)       | 1KB          |     4,888.7 ns |     9.49 ns |     8.88 ns |     762 B |      96 B |
| Decrypt · ChaCha20 (CryptoHives-Scalar) | 1KB          |    11,439.8 ns |    11.67 ns |    10.35 ns |   3,618 B |         - |
|                                         |              |                |             |             |           |           |
| Encrypt · ChaCha20 (CryptoHives-AVX2)   | 1KB          |       784.7 ns |     0.54 ns |     0.47 ns |   2,656 B |         - |
| Encrypt · ChaCha20 (CryptoHives-SSSE3)  | 1KB          |     1,471.7 ns |     1.01 ns |     0.94 ns |   2,415 B |         - |
| Encrypt · ChaCha20 (NaCl.Core)          | 1KB          |     2,722.3 ns |     4.14 ns |     3.67 ns |   7,446 B |      24 B |
| Encrypt · ChaCha20 (BouncyCastle)       | 1KB          |     4,892.2 ns |    14.21 ns |    12.59 ns |     762 B |      96 B |
| Encrypt · ChaCha20 (CryptoHives-Scalar) | 1KB          |    11,447.8 ns |    34.70 ns |    32.46 ns |   3,618 B |         - |
|                                         |              |                |             |             |           |           |
| Decrypt · ChaCha20 (CryptoHives-AVX2)   | 8KB          |     6,097.9 ns |     1.96 ns |     1.74 ns |   2,677 B |         - |
| Decrypt · ChaCha20 (CryptoHives-SSSE3)  | 8KB          |    11,636.8 ns |     3.72 ns |     3.30 ns |   2,415 B |         - |
| Decrypt · ChaCha20 (NaCl.Core)          | 8KB          |    20,410.4 ns |    19.94 ns |    15.57 ns |   7,437 B |      24 B |
| Decrypt · ChaCha20 (BouncyCastle)       | 8KB          |    38,353.4 ns |   113.94 ns |   106.58 ns |     762 B |      96 B |
| Decrypt · ChaCha20 (CryptoHives-Scalar) | 8KB          |    91,256.1 ns |   224.04 ns |   209.56 ns |   3,639 B |         - |
|                                         |              |                |             |             |           |           |
| Encrypt · ChaCha20 (CryptoHives-AVX2)   | 8KB          |     6,082.5 ns |     2.33 ns |     2.18 ns |   2,656 B |         - |
| Encrypt · ChaCha20 (CryptoHives-SSSE3)  | 8KB          |    11,637.0 ns |     3.34 ns |     2.79 ns |   2,423 B |         - |
| Encrypt · ChaCha20 (NaCl.Core)          | 8KB          |    20,648.1 ns |    24.30 ns |    21.54 ns |   7,440 B |      24 B |
| Encrypt · ChaCha20 (BouncyCastle)       | 8KB          |    38,320.9 ns |    72.63 ns |    60.65 ns |     762 B |      96 B |
| Encrypt · ChaCha20 (CryptoHives-Scalar) | 8KB          |    91,302.0 ns |   159.35 ns |   149.05 ns |   3,618 B |         - |
|                                         |              |                |             |             |           |           |
| Decrypt · ChaCha20 (CryptoHives-AVX2)   | 128KB        |    97,116.8 ns |    48.79 ns |    45.64 ns |   2,656 B |         - |
| Decrypt · ChaCha20 (CryptoHives-SSSE3)  | 128KB        |   184,875.8 ns |    91.34 ns |    85.44 ns |   2,449 B |         - |
| Decrypt · ChaCha20 (NaCl.Core)          | 128KB        |   326,348.6 ns |   503.68 ns |   471.14 ns |   7,455 B |      24 B |
| Decrypt · ChaCha20 (BouncyCastle)       | 128KB        |   612,978.8 ns | 1,577.71 ns | 1,398.60 ns |     762 B |      96 B |
| Decrypt · ChaCha20 (CryptoHives-Scalar) | 128KB        | 1,465,727.4 ns | 3,306.54 ns | 3,092.94 ns |   3,618 B |         - |
|                                         |              |                |             |             |           |           |
| Encrypt · ChaCha20 (CryptoHives-AVX2)   | 128KB        |    97,156.3 ns |    29.18 ns |    25.86 ns |   2,664 B |         - |
| Encrypt · ChaCha20 (CryptoHives-SSSE3)  | 128KB        |   185,012.6 ns |   102.91 ns |    91.23 ns |   2,432 B |         - |
| Encrypt · ChaCha20 (NaCl.Core)          | 128KB        |   324,005.1 ns |   351.75 ns |   293.73 ns |   7,437 B |      24 B |
| Encrypt · ChaCha20 (BouncyCastle)       | 128KB        |   616,022.7 ns |   654.18 ns |   546.27 ns |     762 B |      96 B |
| Encrypt · ChaCha20 (CryptoHives-Scalar) | 128KB        | 1,467,405.3 ns | 2,962.16 ns | 2,770.81 ns |   3,618 B |         - |