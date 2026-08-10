| Description                             | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|---------------------------------------- |------------- |-------------:|------------:|------------:|----------:|
| Decrypt · ChaCha20 (CryptoHives-Neon)   | 128B         |     171.7 ns |     0.58 ns |     0.54 ns |         - |
| Decrypt · ChaCha20 (BouncyCastle)       | 128B         |     313.9 ns |     1.32 ns |     1.24 ns |      96 B |
| Decrypt · ChaCha20 (NaCl.Core)          | 128B         |     524.2 ns |     1.59 ns |     1.49 ns |      24 B |
| Decrypt · ChaCha20 (CryptoHives-Scalar) | 128B         |     722.2 ns |     1.53 ns |     1.43 ns |         - |
|                                         |              |              |             |             |           |
| Encrypt · ChaCha20 (CryptoHives-Neon)   | 128B         |     171.3 ns |     0.46 ns |     0.43 ns |         - |
| Encrypt · ChaCha20 (BouncyCastle)       | 128B         |     317.5 ns |     1.51 ns |     1.41 ns |      96 B |
| Encrypt · ChaCha20 (NaCl.Core)          | 128B         |     523.7 ns |     1.93 ns |     1.81 ns |      24 B |
| Encrypt · ChaCha20 (CryptoHives-Scalar) | 128B         |     721.7 ns |     2.02 ns |     1.79 ns |         - |
|                                         |              |              |             |             |           |
| Decrypt · ChaCha20 (CryptoHives-Neon)   | 1KB          |   1,347.2 ns |     0.83 ns |     0.73 ns |         - |
| Decrypt · ChaCha20 (BouncyCastle)       | 1KB          |   1,924.7 ns |    14.09 ns |    13.18 ns |      96 B |
| Decrypt · ChaCha20 (NaCl.Core)          | 1KB          |   2,948.9 ns |     5.03 ns |     4.70 ns |      24 B |
| Decrypt · ChaCha20 (CryptoHives-Scalar) | 1KB          |   5,698.9 ns |    23.02 ns |    21.53 ns |         - |
|                                         |              |              |             |             |           |
| Encrypt · ChaCha20 (CryptoHives-Neon)   | 1KB          |   1,346.8 ns |     2.71 ns |     2.53 ns |         - |
| Encrypt · ChaCha20 (BouncyCastle)       | 1KB          |   1,944.0 ns |    25.59 ns |    23.94 ns |      96 B |
| Encrypt · ChaCha20 (NaCl.Core)          | 1KB          |   2,950.9 ns |     9.52 ns |     8.91 ns |      24 B |
| Encrypt · ChaCha20 (CryptoHives-Scalar) | 1KB          |   5,706.2 ns |    11.52 ns |    10.77 ns |         - |
|                                         |              |              |             |             |           |
| Decrypt · ChaCha20 (CryptoHives-Neon)   | 8KB          |  10,741.0 ns |    20.69 ns |    19.35 ns |         - |
| Decrypt · ChaCha20 (BouncyCastle)       | 8KB          |  13,459.1 ns |    21.92 ns |    17.11 ns |      96 B |
| Decrypt · ChaCha20 (NaCl.Core)          | 8KB          |  22,375.8 ns |    32.05 ns |    28.41 ns |      24 B |
| Decrypt · ChaCha20 (CryptoHives-Scalar) | 8KB          |  45,621.6 ns |   101.85 ns |    95.27 ns |         - |
|                                         |              |              |             |             |           |
| Encrypt · ChaCha20 (CryptoHives-Neon)   | 8KB          |  10,746.7 ns |     6.55 ns |     6.12 ns |         - |
| Encrypt · ChaCha20 (BouncyCastle)       | 8KB          |  14,129.8 ns |   204.60 ns |   191.38 ns |      96 B |
| Encrypt · ChaCha20 (NaCl.Core)          | 8KB          |  22,404.5 ns |    24.31 ns |    22.74 ns |      24 B |
| Encrypt · ChaCha20 (CryptoHives-Scalar) | 8KB          |  45,557.0 ns |   166.11 ns |   155.38 ns |         - |
|                                         |              |              |             |             |           |
| Decrypt · ChaCha20 (CryptoHives-Neon)   | 128KB        | 171,423.5 ns |   184.36 ns |   172.45 ns |         - |
| Decrypt · ChaCha20 (BouncyCastle)       | 128KB        | 216,202.4 ns |   402.63 ns |   376.62 ns |      96 B |
| Decrypt · ChaCha20 (NaCl.Core)          | 128KB        | 355,135.2 ns |   531.47 ns |   497.13 ns |      24 B |
| Decrypt · ChaCha20 (CryptoHives-Scalar) | 128KB        | 729,818.6 ns | 1,903.40 ns | 1,687.31 ns |         - |
|                                         |              |              |             |             |           |
| Encrypt · ChaCha20 (CryptoHives-Neon)   | 128KB        | 171,604.3 ns |   303.00 ns |   283.43 ns |         - |
| Encrypt · ChaCha20 (BouncyCastle)       | 128KB        | 215,586.3 ns |   357.26 ns |   334.18 ns |      96 B |
| Encrypt · ChaCha20 (NaCl.Core)          | 128KB        | 354,964.4 ns | 1,244.48 ns | 1,164.09 ns |      24 B |
| Encrypt · ChaCha20 (CryptoHives-Scalar) | 128KB        | 729,045.7 ns | 1,318.01 ns | 1,232.87 ns |         - |