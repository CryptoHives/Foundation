| Description                             | TestDataSize | Mean         | Error       | StdDev      | Median       | Allocated |
|---------------------------------------- |------------- |-------------:|------------:|------------:|-------------:|----------:|
| Decrypt · ChaCha20 (CryptoHives-Neon)   | 128B         |     179.6 ns |     1.02 ns |     0.95 ns |     179.6 ns |         - |
| Decrypt · ChaCha20 (BouncyCastle)       | 128B         |     245.5 ns |     1.33 ns |     1.24 ns |     245.0 ns |      96 B |
| Decrypt · ChaCha20 (NaCl.Core)          | 128B         |     551.6 ns |     3.57 ns |     3.34 ns |     551.5 ns |      24 B |
| Decrypt · ChaCha20 (CryptoHives-Scalar) | 128B         |     844.0 ns |     0.20 ns |     0.17 ns |     844.0 ns |         - |
|                                         |              |              |             |             |              |           |
| Encrypt · ChaCha20 (CryptoHives-Neon)   | 128B         |     169.8 ns |     0.15 ns |     0.13 ns |     169.8 ns |         - |
| Encrypt · ChaCha20 (BouncyCastle)       | 128B         |     247.1 ns |     0.60 ns |     0.57 ns |     247.1 ns |      96 B |
| Encrypt · ChaCha20 (NaCl.Core)          | 128B         |     519.6 ns |     0.12 ns |     0.10 ns |     519.6 ns |      24 B |
| Encrypt · ChaCha20 (CryptoHives-Scalar) | 128B         |     798.5 ns |     2.82 ns |     2.50 ns |     797.9 ns |         - |
|                                         |              |              |             |             |              |           |
| Decrypt · ChaCha20 (CryptoHives-Neon)   | 1KB          |   1,415.1 ns |     5.40 ns |     5.05 ns |   1,414.5 ns |         - |
| Decrypt · ChaCha20 (NaCl.Core)          | 1KB          |   2,921.1 ns |     0.76 ns |     0.60 ns |   2,921.2 ns |      24 B |
| Decrypt · ChaCha20 (BouncyCastle)       | 1KB          |   4,947.9 ns | 1,149.21 ns | 3,388.46 ns |   2,039.8 ns |      96 B |
| Decrypt · ChaCha20 (CryptoHives-Scalar) | 1KB          |   6,657.8 ns |     0.64 ns |     0.60 ns |   6,657.8 ns |         - |
|                                         |              |              |             |             |              |           |
| Encrypt · ChaCha20 (CryptoHives-Neon)   | 1KB          |   1,337.1 ns |     0.41 ns |     0.38 ns |   1,337.0 ns |         - |
| Encrypt · ChaCha20 (BouncyCastle)       | 1KB          |   1,822.0 ns |     0.83 ns |     0.69 ns |   1,822.3 ns |      96 B |
| Encrypt · ChaCha20 (NaCl.Core)          | 1KB          |   2,943.5 ns |    18.33 ns |    17.14 ns |   2,944.2 ns |      24 B |
| Encrypt · ChaCha20 (CryptoHives-Scalar) | 1KB          |   6,497.9 ns |    26.82 ns |    25.08 ns |   6,491.5 ns |         - |
|                                         |              |              |             |             |              |           |
| Decrypt · ChaCha20 (CryptoHives-Neon)   | 8KB          |  10,670.7 ns |     4.37 ns |     4.09 ns |  10,669.9 ns |         - |
| Decrypt · ChaCha20 (BouncyCastle)       | 8KB          |  14,110.6 ns |     3.27 ns |     2.90 ns |  14,110.3 ns |      96 B |
| Decrypt · ChaCha20 (NaCl.Core)          | 8KB          |  22,335.0 ns |   106.31 ns |    99.44 ns |  22,349.0 ns |      24 B |
| Decrypt · ChaCha20 (CryptoHives-Scalar) | 8KB          |  52,220.0 ns |   165.24 ns |   154.57 ns |  52,215.9 ns |         - |
|                                         |              |              |             |             |              |           |
| Encrypt · ChaCha20 (CryptoHives-Neon)   | 8KB          |  10,756.2 ns |    47.09 ns |    44.05 ns |  10,771.9 ns |         - |
| Encrypt · ChaCha20 (BouncyCastle)       | 8KB          |  14,111.6 ns |     3.74 ns |     3.12 ns |  14,111.2 ns |      96 B |
| Encrypt · ChaCha20 (NaCl.Core)          | 8KB          |  22,794.6 ns |   142.59 ns |   133.38 ns |  22,790.3 ns |      24 B |
| Encrypt · ChaCha20 (CryptoHives-Scalar) | 8KB          |  52,969.6 ns |    71.50 ns |    66.89 ns |  52,960.5 ns |         - |
|                                         |              |              |             |             |              |           |
| Decrypt · ChaCha20 (CryptoHives-Neon)   | 128KB        | 173,717.0 ns | 1,219.22 ns | 1,140.46 ns | 173,572.9 ns |         - |
| Decrypt · ChaCha20 (BouncyCastle)       | 128KB        | 235,448.1 ns |    25.49 ns |    22.60 ns | 235,449.1 ns |      96 B |
| Decrypt · ChaCha20 (NaCl.Core)          | 128KB        | 366,080.3 ns | 1,704.78 ns | 1,594.66 ns | 366,437.5 ns |      24 B |
| Decrypt · ChaCha20 (CryptoHives-Scalar) | 128KB        | 851,153.9 ns |   294.74 ns |   261.28 ns | 851,193.9 ns |         - |
|                                         |              |              |             |             |              |           |
| Encrypt · ChaCha20 (CryptoHives-Neon)   | 128KB        | 176,234.3 ns |   892.94 ns |   835.25 ns | 176,278.6 ns |         - |
| Encrypt · ChaCha20 (BouncyCastle)       | 128KB        | 235,345.6 ns |    24.53 ns |    19.15 ns | 235,352.4 ns |      96 B |
| Encrypt · ChaCha20 (NaCl.Core)          | 128KB        | 368,380.7 ns | 1,973.75 ns | 1,846.25 ns | 369,112.5 ns |      24 B |
| Encrypt · ChaCha20 (CryptoHives-Scalar) | 128KB        | 851,681.2 ns |   301.69 ns |   251.92 ns | 851,606.7 ns |         - |