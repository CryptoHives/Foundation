| Description                                      | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|------------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|
| Decrypt · ChaCha20-Poly1305 (CryptoHives-Neon)   | 128B         |     445.3 ns |     1.91 ns |     1.79 ns |         - |
| Decrypt · ChaCha20-Poly1305 (BouncyCastle)       | 128B         |     636.4 ns |     4.54 ns |     4.02 ns |     416 B |
| Decrypt · ChaCha20-Poly1305 (NaCl.Core)          | 128B         |     878.5 ns |     3.82 ns |     3.58 ns |      48 B |
| Decrypt · ChaCha20-Poly1305 (CryptoHives-Scalar) | 128B         |   1,614.6 ns |    17.53 ns |    16.40 ns |         - |
| Decrypt · ChaCha20-Poly1305 (OS)                 | 128B         |   2,326.5 ns |     7.36 ns |     6.88 ns |         - |
|                                                  |              |              |             |             |           |
| Encrypt · ChaCha20-Poly1305 (CryptoHives-Neon)   | 128B         |     369.5 ns |     2.21 ns |     2.06 ns |         - |
| Encrypt · ChaCha20-Poly1305 (BouncyCastle)       | 128B         |     425.2 ns |     0.09 ns |     0.08 ns |     336 B |
| Encrypt · ChaCha20-Poly1305 (NaCl.Core)          | 128B         |     852.4 ns |     3.18 ns |     2.97 ns |      48 B |
| Encrypt · ChaCha20-Poly1305 (CryptoHives-Scalar) | 128B         |   1,588.9 ns |     1.00 ns |     0.88 ns |         - |
| Encrypt · ChaCha20-Poly1305 (OS)                 | 128B         |   2,133.1 ns |    41.88 ns |    74.44 ns |         - |
|                                                  |              |              |             |             |           |
| Decrypt · ChaCha20-Poly1305 (BouncyCastle)       | 1KB          |   2,098.4 ns |     0.58 ns |     0.51 ns |     416 B |
| Decrypt · ChaCha20-Poly1305 (CryptoHives-Neon)   | 1KB          |   2,156.7 ns |    42.72 ns |    71.37 ns |         - |
| Decrypt · ChaCha20-Poly1305 (OS)                 | 1KB          |   3,316.6 ns |     3.45 ns |     2.88 ns |         - |
| Decrypt · ChaCha20-Poly1305 (NaCl.Core)          | 1KB          |   3,768.5 ns |    25.49 ns |    22.60 ns |      72 B |
| Decrypt · ChaCha20-Poly1305 (CryptoHives-Scalar) | 1KB          |   8,067.7 ns |     8.74 ns |     8.18 ns |         - |
|                                                  |              |              |             |             |           |
| Encrypt · ChaCha20-Poly1305 (CryptoHives-Neon)   | 1KB          |   2,074.1 ns |    11.51 ns |    10.76 ns |         - |
| Encrypt · ChaCha20-Poly1305 (CryptoHives-Scalar) | 1KB          |   8,048.1 ns |     3.20 ns |     2.83 ns |         - |
| Encrypt · ChaCha20-Poly1305 (BouncyCastle)       | 1KB          |   9,013.8 ns |     5.30 ns |     4.43 ns |     336 B |
| Encrypt · ChaCha20-Poly1305 (OS)                 | 1KB          |  14,102.9 ns |    87.03 ns |    81.41 ns |         - |
| Encrypt · ChaCha20-Poly1305 (NaCl.Core)          | 1KB          |  18,901.7 ns |    10.18 ns |     9.53 ns |      72 B |
|                                                  |              |              |             |             |           |
| Decrypt · ChaCha20-Poly1305 (OS)                 | 8KB          |  11,103.1 ns |    60.30 ns |    56.41 ns |         - |
| Decrypt · ChaCha20-Poly1305 (BouncyCastle)       | 8KB          |  13,747.8 ns |    23.85 ns |    19.92 ns |     416 B |
| Decrypt · ChaCha20-Poly1305 (CryptoHives-Neon)   | 8KB          |  15,276.0 ns |   297.36 ns |   488.58 ns |         - |
| Decrypt · ChaCha20-Poly1305 (NaCl.Core)          | 8KB          |  26,302.8 ns |    46.77 ns |    39.06 ns |      72 B |
| Decrypt · ChaCha20-Poly1305 (CryptoHives-Scalar) | 8KB          |  58,254.2 ns |   323.03 ns |   286.36 ns |         - |
|                                                  |              |              |             |             |           |
| Encrypt · ChaCha20-Poly1305 (OS)                 | 8KB          |  51,725.5 ns |    97.39 ns |    81.33 ns |         - |
| Encrypt · ChaCha20-Poly1305 (BouncyCastle)       | 8KB          |  64,505.1 ns |   142.61 ns |   126.42 ns |     336 B |
| Encrypt · ChaCha20-Poly1305 (CryptoHives-Neon)   | 8KB          |  75,476.8 ns |   126.87 ns |   118.67 ns |         - |
| Encrypt · ChaCha20-Poly1305 (NaCl.Core)          | 8KB          | 136,617.4 ns |   150.94 ns |   141.19 ns |      72 B |
| Encrypt · ChaCha20-Poly1305 (CryptoHives-Scalar) | 8KB          | 278,366.8 ns |    67.07 ns |    52.36 ns |         - |
|                                                  |              |              |             |             |           |
| Decrypt · ChaCha20-Poly1305 (OS)                 | 128KB        | 157,122.2 ns |   493.13 ns |   437.15 ns |         - |
| Decrypt · ChaCha20-Poly1305 (BouncyCastle)       | 128KB        | 213,089.7 ns |    68.40 ns |    53.40 ns |     416 B |
| Decrypt · ChaCha20-Poly1305 (CryptoHives-Neon)   | 128KB        | 231,987.3 ns |   977.62 ns |   914.47 ns |         - |
| Decrypt · ChaCha20-Poly1305 (NaCl.Core)          | 128KB        | 434,878.8 ns | 1,172.94 ns | 1,039.78 ns |      72 B |
| Decrypt · ChaCha20-Poly1305 (CryptoHives-Scalar) | 128KB        | 914,394.0 ns | 1,436.50 ns | 1,343.70 ns |         - |
|                                                  |              |              |             |             |           |
| Encrypt · ChaCha20-Poly1305 (OS)                 | 128KB        | 146,856.6 ns |   100.54 ns |    89.13 ns |         - |
| Encrypt · ChaCha20-Poly1305 (BouncyCastle)       | 128KB        | 216,760.6 ns |   403.37 ns |   377.31 ns |     336 B |
| Encrypt · ChaCha20-Poly1305 (CryptoHives-Neon)   | 128KB        | 234,264.3 ns | 1,440.15 ns | 2,065.42 ns |         - |
| Encrypt · ChaCha20-Poly1305 (NaCl.Core)          | 128KB        | 433,970.9 ns | 1,773.61 ns | 1,659.03 ns |      72 B |
| Encrypt · ChaCha20-Poly1305 (CryptoHives-Scalar) | 128KB        | 919,946.0 ns |   337.87 ns |   299.51 ns |         - |