| Description                             | TestDataSize | Mean         | Error       | StdDev       | Allocated |
|---------------------------------------- |------------- |-------------:|------------:|-------------:|----------:|
| Decrypt · ChaCha20 (CryptoHives-Neon)   | 128B         |     170.8 ns |     0.59 ns |      0.52 ns |         - |
| Decrypt · ChaCha20 (BouncyCastle)       | 128B         |     244.5 ns |     0.53 ns |      0.50 ns |      96 B |
| Decrypt · ChaCha20 (NaCl.Core)          | 128B         |     522.0 ns |     1.59 ns |      1.41 ns |      24 B |
| Decrypt · ChaCha20 (CryptoHives-Scalar) | 128B         |     822.6 ns |     3.46 ns |      3.23 ns |         - |
|                                         |              |              |             |              |           |
| Encrypt · ChaCha20 (CryptoHives-Neon)   | 128B         |     171.9 ns |     2.29 ns |      3.83 ns |         - |
| Encrypt · ChaCha20 (BouncyCastle)       | 128B         |     248.1 ns |     1.82 ns |      1.71 ns |      96 B |
| Encrypt · ChaCha20 (NaCl.Core)          | 128B         |     522.6 ns |     1.80 ns |      1.68 ns |      24 B |
| Encrypt · ChaCha20 (CryptoHives-Scalar) | 128B         |     827.6 ns |     4.00 ns |      3.54 ns |         - |
|                                         |              |              |             |              |           |
| Decrypt · ChaCha20 (CryptoHives-Neon)   | 1KB          |   1,345.4 ns |     4.32 ns |      4.04 ns |         - |
| Decrypt · ChaCha20 (BouncyCastle)       | 1KB          |   1,890.4 ns |    35.65 ns |     38.14 ns |      96 B |
| Decrypt · ChaCha20 (NaCl.Core)          | 1KB          |   2,936.6 ns |    11.32 ns |     10.03 ns |      24 B |
| Decrypt · ChaCha20 (CryptoHives-Scalar) | 1KB          |   6,468.2 ns |    31.44 ns |     29.41 ns |         - |
|                                         |              |              |             |              |           |
| Encrypt · ChaCha20 (CryptoHives-Neon)   | 1KB          |   1,345.2 ns |     5.04 ns |      4.47 ns |         - |
| Encrypt · ChaCha20 (BouncyCastle)       | 1KB          |   1,909.6 ns |    23.14 ns |     21.64 ns |      96 B |
| Encrypt · ChaCha20 (NaCl.Core)          | 1KB          |   2,938.7 ns |     9.92 ns |      9.28 ns |      24 B |
| Encrypt · ChaCha20 (CryptoHives-Scalar) | 1KB          |   6,477.2 ns |    31.26 ns |     29.24 ns |         - |
|                                         |              |              |             |              |           |
| Decrypt · ChaCha20 (CryptoHives-Neon)   | 8KB          |  10,736.7 ns |    32.43 ns |     30.33 ns |         - |
| Decrypt · ChaCha20 (BouncyCastle)       | 8KB          |  14,167.9 ns |    57.09 ns |     53.41 ns |      96 B |
| Decrypt · ChaCha20 (NaCl.Core)          | 8KB          |  22,236.8 ns |    55.65 ns |     52.06 ns |      24 B |
| Decrypt · ChaCha20 (CryptoHives-Scalar) | 8KB          |  51,392.4 ns |   226.64 ns |    212.00 ns |         - |
|                                         |              |              |             |              |           |
| Encrypt · ChaCha20 (CryptoHives-Neon)   | 8KB          |  10,725.9 ns |    32.36 ns |     28.69 ns |         - |
| Encrypt · ChaCha20 (BouncyCastle)       | 8KB          |  14,173.4 ns |    39.74 ns |     37.17 ns |      96 B |
| Encrypt · ChaCha20 (NaCl.Core)          | 8KB          |  22,238.2 ns |    74.59 ns |     69.77 ns |      24 B |
| Encrypt · ChaCha20 (CryptoHives-Scalar) | 8KB          |  51,653.2 ns |   304.48 ns |    269.91 ns |         - |
|                                         |              |              |             |              |           |
| Decrypt · ChaCha20 (CryptoHives-Neon)   | 128KB        | 171,238.3 ns |   564.46 ns |    500.38 ns |         - |
| Decrypt · ChaCha20 (BouncyCastle)       | 128KB        | 236,448.9 ns |   614.72 ns |    575.01 ns |      96 B |
| Decrypt · ChaCha20 (NaCl.Core)          | 128KB        | 354,723.5 ns | 1,213.36 ns |  1,134.98 ns |      24 B |
| Decrypt · ChaCha20 (CryptoHives-Scalar) | 128KB        | 819,423.8 ns | 3,768.00 ns |  3,524.59 ns |         - |
|                                         |              |              |             |              |           |
| Encrypt · ChaCha20 (CryptoHives-Neon)   | 128KB        | 171,331.9 ns |   493.79 ns |    461.89 ns |         - |
| Encrypt · ChaCha20 (BouncyCastle)       | 128KB        | 236,383.2 ns |   754.74 ns |    669.06 ns |      96 B |
| Encrypt · ChaCha20 (NaCl.Core)          | 128KB        | 358,117.9 ns | 5,232.80 ns | 11,375.67 ns |      24 B |
| Encrypt · ChaCha20 (CryptoHives-Scalar) | 128KB        | 824,890.4 ns | 4,100.03 ns |  3,634.57 ns |         - |