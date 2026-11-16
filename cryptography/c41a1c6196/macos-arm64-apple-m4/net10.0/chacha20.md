| Description                             | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|---------------------------------------- |------------- |-------------:|------------:|------------:|----------:|
| Decrypt · ChaCha20 (CryptoHives-Neon)   | 128B         |     171.9 ns |     0.13 ns |     0.12 ns |         - |
| Decrypt · ChaCha20 (BouncyCastle)       | 128B         |     240.7 ns |     3.77 ns |     3.53 ns |      96 B |
| Decrypt · ChaCha20 (NaCl.Core)          | 128B         |     525.9 ns |     0.67 ns |     0.60 ns |      24 B |
| Decrypt · ChaCha20 (CryptoHives-Scalar) | 128B         |     829.2 ns |     2.35 ns |     2.20 ns |         - |
|                                         |              |              |             |             |           |
| Encrypt · ChaCha20 (CryptoHives-Neon)   | 128B         |     171.7 ns |     0.24 ns |     0.22 ns |         - |
| Encrypt · ChaCha20 (BouncyCastle)       | 128B         |     249.6 ns |     2.94 ns |     2.75 ns |      96 B |
| Encrypt · ChaCha20 (NaCl.Core)          | 128B         |     525.7 ns |     0.39 ns |     0.37 ns |      24 B |
| Encrypt · ChaCha20 (CryptoHives-Scalar) | 128B         |     829.4 ns |     1.62 ns |     1.52 ns |         - |
|                                         |              |              |             |             |           |
| Decrypt · ChaCha20 (CryptoHives-Neon)   | 1KB          |   1,350.3 ns |     1.53 ns |     1.43 ns |         - |
| Decrypt · ChaCha20 (BouncyCastle)       | 1KB          |   1,870.7 ns |    16.01 ns |    14.98 ns |      96 B |
| Decrypt · ChaCha20 (NaCl.Core)          | 1KB          |   2,954.3 ns |     1.79 ns |     1.67 ns |      24 B |
| Decrypt · ChaCha20 (CryptoHives-Scalar) | 1KB          |   6,478.3 ns |    13.37 ns |    12.50 ns |         - |
|                                         |              |              |             |             |           |
| Encrypt · ChaCha20 (CryptoHives-Neon)   | 1KB          |   1,349.2 ns |     1.86 ns |     1.65 ns |         - |
| Encrypt · ChaCha20 (BouncyCastle)       | 1KB          |   1,789.9 ns |     5.21 ns |     4.87 ns |      96 B |
| Encrypt · ChaCha20 (NaCl.Core)          | 1KB          |   2,954.0 ns |     2.04 ns |     1.81 ns |      24 B |
| Encrypt · ChaCha20 (CryptoHives-Scalar) | 1KB          |   6,479.1 ns |    15.65 ns |    14.64 ns |         - |
|                                         |              |              |             |             |           |
| Decrypt · ChaCha20 (CryptoHives-Neon)   | 8KB          |  10,785.4 ns |    10.95 ns |    10.24 ns |         - |
| Decrypt · ChaCha20 (BouncyCastle)       | 8KB          |  14,714.2 ns |    38.38 ns |    35.90 ns |      96 B |
| Decrypt · ChaCha20 (NaCl.Core)          | 8KB          |  22,383.0 ns |    47.73 ns |    44.65 ns |      24 B |
| Decrypt · ChaCha20 (CryptoHives-Scalar) | 8KB          |  51,642.5 ns |   143.38 ns |   134.12 ns |         - |
|                                         |              |              |             |             |           |
| Encrypt · ChaCha20 (CryptoHives-Neon)   | 8KB          |  10,778.3 ns |    14.90 ns |    13.93 ns |         - |
| Encrypt · ChaCha20 (BouncyCastle)       | 8KB          |  14,727.7 ns |    25.13 ns |    23.51 ns |      96 B |
| Encrypt · ChaCha20 (NaCl.Core)          | 8KB          |  22,397.2 ns |    13.65 ns |    12.77 ns |      24 B |
| Encrypt · ChaCha20 (CryptoHives-Scalar) | 8KB          |  51,695.6 ns |   121.92 ns |   114.05 ns |         - |
|                                         |              |              |             |             |           |
| Decrypt · ChaCha20 (CryptoHives-Neon)   | 128KB        | 171,576.0 ns |    94.72 ns |    88.61 ns |         - |
| Decrypt · ChaCha20 (BouncyCastle)       | 128KB        | 227,525.6 ns |   302.58 ns |   283.03 ns |      96 B |
| Decrypt · ChaCha20 (NaCl.Core)          | 128KB        | 356,039.2 ns |   571.04 ns |   506.21 ns |      24 B |
| Decrypt · ChaCha20 (CryptoHives-Scalar) | 128KB        | 827,330.2 ns | 1,530.50 ns | 1,431.63 ns |         - |
|                                         |              |              |             |             |           |
| Encrypt · ChaCha20 (CryptoHives-Neon)   | 128KB        | 172,215.5 ns |   186.10 ns |   174.08 ns |         - |
| Encrypt · ChaCha20 (BouncyCastle)       | 128KB        | 228,064.3 ns |   260.65 ns |   231.06 ns |      96 B |
| Encrypt · ChaCha20 (NaCl.Core)          | 128KB        | 356,516.2 ns |   897.21 ns |   839.25 ns |      24 B |
| Encrypt · ChaCha20 (CryptoHives-Scalar) | 128KB        | 825,114.2 ns | 4,232.27 ns | 3,958.87 ns |         - |