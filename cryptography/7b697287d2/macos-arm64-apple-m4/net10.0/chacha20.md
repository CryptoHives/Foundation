| Description                             | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|---------------------------------------- |------------- |-------------:|------------:|------------:|----------:|
| Decrypt · ChaCha20 (CryptoHives-Neon)   | 128B         |     170.6 ns |     0.57 ns |     0.50 ns |         - |
| Decrypt · ChaCha20 (BouncyCastle)       | 128B         |     240.4 ns |     1.56 ns |     1.39 ns |      96 B |
| Decrypt · ChaCha20 (NaCl.Core)          | 128B         |     522.0 ns |     1.85 ns |     1.73 ns |      24 B |
| Decrypt · ChaCha20 (CryptoHives-Scalar) | 128B         |     815.2 ns |     4.22 ns |     3.94 ns |         - |
|                                         |              |              |             |             |           |
| Encrypt · ChaCha20 (CryptoHives-Neon)   | 128B         |     170.4 ns |     0.58 ns |     0.54 ns |         - |
| Encrypt · ChaCha20 (BouncyCastle)       | 128B         |     244.1 ns |     1.25 ns |     1.17 ns |      96 B |
| Encrypt · ChaCha20 (NaCl.Core)          | 128B         |     521.6 ns |     2.05 ns |     1.92 ns |      24 B |
| Encrypt · ChaCha20 (CryptoHives-Scalar) | 128B         |     815.8 ns |     4.72 ns |     4.41 ns |         - |
|                                         |              |              |             |             |           |
| Decrypt · ChaCha20 (CryptoHives-Neon)   | 1KB          |   1,338.5 ns |     4.32 ns |     4.04 ns |         - |
| Decrypt · ChaCha20 (BouncyCastle)       | 1KB          |   1,849.1 ns |     6.48 ns |     6.06 ns |      96 B |
| Decrypt · ChaCha20 (NaCl.Core)          | 1KB          |   2,937.2 ns |    11.62 ns |    10.87 ns |      24 B |
| Decrypt · ChaCha20 (CryptoHives-Scalar) | 1KB          |   6,371.5 ns |    36.60 ns |    34.24 ns |         - |
|                                         |              |              |             |             |           |
| Encrypt · ChaCha20 (CryptoHives-Neon)   | 1KB          |   1,337.2 ns |     5.08 ns |     4.75 ns |         - |
| Encrypt · ChaCha20 (BouncyCastle)       | 1KB          |   1,851.1 ns |     6.38 ns |     5.97 ns |      96 B |
| Encrypt · ChaCha20 (NaCl.Core)          | 1KB          |   2,941.0 ns |    12.73 ns |    11.91 ns |      24 B |
| Encrypt · ChaCha20 (CryptoHives-Scalar) | 1KB          |   6,372.5 ns |    49.81 ns |    46.59 ns |         - |
|                                         |              |              |             |             |           |
| Decrypt · ChaCha20 (CryptoHives-Neon)   | 8KB          |  10,690.4 ns |    34.94 ns |    32.68 ns |         - |
| Decrypt · ChaCha20 (BouncyCastle)       | 8KB          |  14,142.7 ns |    48.33 ns |    45.21 ns |      96 B |
| Decrypt · ChaCha20 (NaCl.Core)          | 8KB          |  22,239.7 ns |    61.08 ns |    57.14 ns |      24 B |
| Decrypt · ChaCha20 (CryptoHives-Scalar) | 8KB          |  50,831.1 ns |   261.31 ns |   244.43 ns |         - |
|                                         |              |              |             |             |           |
| Encrypt · ChaCha20 (CryptoHives-Neon)   | 8KB          |  10,707.9 ns |    38.96 ns |    36.45 ns |         - |
| Encrypt · ChaCha20 (BouncyCastle)       | 8KB          |  14,144.6 ns |    47.89 ns |    44.79 ns |      96 B |
| Encrypt · ChaCha20 (NaCl.Core)          | 8KB          |  22,255.4 ns |    54.79 ns |    51.25 ns |      24 B |
| Encrypt · ChaCha20 (CryptoHives-Scalar) | 8KB          |  50,705.0 ns |   325.49 ns |   304.46 ns |         - |
|                                         |              |              |             |             |           |
| Decrypt · ChaCha20 (CryptoHives-Neon)   | 128KB        | 170,860.7 ns |   370.89 ns |   346.93 ns |         - |
| Decrypt · ChaCha20 (BouncyCastle)       | 128KB        | 235,508.4 ns |   403.72 ns |   377.64 ns |      96 B |
| Decrypt · ChaCha20 (NaCl.Core)          | 128KB        | 354,448.3 ns | 1,151.92 ns | 1,077.50 ns |      24 B |
| Decrypt · ChaCha20 (CryptoHives-Scalar) | 128KB        | 813,377.4 ns | 3,850.75 ns | 3,602.00 ns |         - |
|                                         |              |              |             |             |           |
| Encrypt · ChaCha20 (CryptoHives-Neon)   | 128KB        | 170,978.1 ns |   509.57 ns |   476.66 ns |         - |
| Encrypt · ChaCha20 (BouncyCastle)       | 128KB        | 235,377.0 ns |   510.02 ns |   477.07 ns |      96 B |
| Encrypt · ChaCha20 (NaCl.Core)          | 128KB        | 353,951.7 ns | 1,410.32 ns | 1,319.22 ns |      24 B |
| Encrypt · ChaCha20 (CryptoHives-Scalar) | 128KB        | 812,472.4 ns | 4,869.17 ns | 4,554.63 ns |         - |