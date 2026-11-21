| Description                             | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|---------------------------------------- |------------- |-------------:|------------:|------------:|----------:|
| Decrypt · ChaCha20 (CryptoHives-Neon)   | 128B         |     174.7 ns |     0.56 ns |     0.53 ns |         - |
| Decrypt · ChaCha20 (BouncyCastle)       | 128B         |     276.0 ns |     1.03 ns |     0.96 ns |      96 B |
| Decrypt · ChaCha20 (NaCl.Core)          | 128B         |     525.9 ns |     1.28 ns |     1.20 ns |      24 B |
| Decrypt · ChaCha20 (CryptoHives-Scalar) | 128B         |     836.9 ns |     3.04 ns |     2.84 ns |         - |
|                                         |              |              |             |             |           |
| Encrypt · ChaCha20 (CryptoHives-Neon)   | 128B         |     174.3 ns |     0.11 ns |     0.10 ns |         - |
| Encrypt · ChaCha20 (BouncyCastle)       | 128B         |     275.3 ns |     1.48 ns |     1.39 ns |      96 B |
| Encrypt · ChaCha20 (NaCl.Core)          | 128B         |     524.0 ns |     0.43 ns |     0.38 ns |      24 B |
| Encrypt · ChaCha20 (CryptoHives-Scalar) | 128B         |     833.1 ns |     1.62 ns |     1.51 ns |         - |
|                                         |              |              |             |             |           |
| Decrypt · ChaCha20 (CryptoHives-Neon)   | 1KB          |   1,356.9 ns |     7.14 ns |     6.68 ns |         - |
| Decrypt · ChaCha20 (BouncyCastle)       | 1KB          |   1,894.8 ns |     3.30 ns |     3.09 ns |      96 B |
| Decrypt · ChaCha20 (NaCl.Core)          | 1KB          |   2,934.8 ns |     4.59 ns |     4.29 ns |      24 B |
| Decrypt · ChaCha20 (CryptoHives-Scalar) | 1KB          |   6,557.2 ns |    17.74 ns |    16.59 ns |         - |
|                                         |              |              |             |             |           |
| Encrypt · ChaCha20 (CryptoHives-Neon)   | 1KB          |   1,356.9 ns |     1.17 ns |     1.09 ns |         - |
| Encrypt · ChaCha20 (BouncyCastle)       | 1KB          |   1,888.7 ns |     4.00 ns |     3.55 ns |      96 B |
| Encrypt · ChaCha20 (NaCl.Core)          | 1KB          |   2,936.5 ns |     4.87 ns |     4.56 ns |      24 B |
| Encrypt · ChaCha20 (CryptoHives-Scalar) | 1KB          |   6,527.1 ns |    17.31 ns |    15.35 ns |         - |
|                                         |              |              |             |             |           |
| Decrypt · ChaCha20 (CryptoHives-Neon)   | 8KB          |  10,792.7 ns |     9.66 ns |     9.03 ns |         - |
| Decrypt · ChaCha20 (BouncyCastle)       | 8KB          |  14,970.6 ns |    30.51 ns |    28.54 ns |      96 B |
| Decrypt · ChaCha20 (NaCl.Core)          | 8KB          |  22,244.3 ns |    13.32 ns |    12.46 ns |      24 B |
| Decrypt · ChaCha20 (CryptoHives-Scalar) | 8KB          |  52,258.7 ns |   150.86 ns |   125.97 ns |         - |
|                                         |              |              |             |             |           |
| Encrypt · ChaCha20 (CryptoHives-Neon)   | 8KB          |  10,788.5 ns |    12.04 ns |    11.26 ns |         - |
| Encrypt · ChaCha20 (BouncyCastle)       | 8KB          |  14,968.3 ns |    25.33 ns |    23.69 ns |      96 B |
| Encrypt · ChaCha20 (NaCl.Core)          | 8KB          |  22,235.2 ns |    18.77 ns |    16.64 ns |      24 B |
| Encrypt · ChaCha20 (CryptoHives-Scalar) | 8KB          |  52,144.1 ns |   143.44 ns |   134.18 ns |         - |
|                                         |              |              |             |             |           |
| Decrypt · ChaCha20 (CryptoHives-Neon)   | 128KB        | 171,177.1 ns |    87.86 ns |    73.37 ns |         - |
| Decrypt · ChaCha20 (BouncyCastle)       | 128KB        | 239,645.5 ns |   437.09 ns |   408.85 ns |      96 B |
| Decrypt · ChaCha20 (NaCl.Core)          | 128KB        | 353,028.5 ns |   392.05 ns |   366.72 ns |      24 B |
| Decrypt · ChaCha20 (CryptoHives-Scalar) | 128KB        | 835,883.8 ns | 1,821.90 ns | 1,704.21 ns |         - |
|                                         |              |              |             |             |           |
| Encrypt · ChaCha20 (CryptoHives-Neon)   | 128KB        | 171,464.9 ns |   291.85 ns |   273.00 ns |         - |
| Encrypt · ChaCha20 (BouncyCastle)       | 128KB        | 239,733.1 ns |   307.13 ns |   287.29 ns |      96 B |
| Encrypt · ChaCha20 (NaCl.Core)          | 128KB        | 353,450.4 ns |   354.28 ns |   331.39 ns |      24 B |
| Encrypt · ChaCha20 (CryptoHives-Scalar) | 128KB        | 839,939.7 ns | 2,848.92 ns | 2,664.88 ns |         - |