| Description                                      | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|------------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|
| Decrypt · ChaCha20-Poly1305 (CryptoHives-Neon)   | 128B         |     468.5 ns |     0.84 ns |     0.79 ns |         - |
| Decrypt · ChaCha20-Poly1305 (BouncyCastle)       | 128B         |     609.5 ns |     1.12 ns |     1.05 ns |     416 B |
| Decrypt · ChaCha20-Poly1305 (NaCl.Core)          | 128B         |     828.0 ns |     0.69 ns |     0.54 ns |      48 B |
| Decrypt · ChaCha20-Poly1305 (CryptoHives-Scalar) | 128B         |   1,438.9 ns |     2.95 ns |     2.61 ns |         - |
| Decrypt · ChaCha20-Poly1305 (OS)                 | 128B         |   2,281.3 ns |    12.22 ns |    11.43 ns |         - |
|                                                  |              |              |             |             |           |
| Encrypt · ChaCha20-Poly1305 (CryptoHives-Neon)   | 128B         |     356.2 ns |     0.79 ns |     0.66 ns |         - |
| Encrypt · ChaCha20-Poly1305 (BouncyCastle)       | 128B         |     413.6 ns |     0.45 ns |     0.42 ns |     336 B |
| Encrypt · ChaCha20-Poly1305 (NaCl.Core)          | 128B         |     799.6 ns |     0.81 ns |     0.72 ns |      48 B |
| Encrypt · ChaCha20-Poly1305 (CryptoHives-Scalar) | 128B         |   1,404.4 ns |     5.75 ns |     5.37 ns |         - |
| Encrypt · ChaCha20-Poly1305 (OS)                 | 128B         |   1,738.1 ns |     7.52 ns |     7.03 ns |         - |
|                                                  |              |              |             |             |           |
| Decrypt · ChaCha20-Poly1305 (CryptoHives-Neon)   | 1KB          |   2,025.5 ns |     4.74 ns |     4.20 ns |         - |
| Decrypt · ChaCha20-Poly1305 (BouncyCastle)       | 1KB          |   2,029.5 ns |     5.86 ns |     5.48 ns |     416 B |
| Decrypt · ChaCha20-Poly1305 (OS)                 | 1KB          |   3,215.8 ns |     8.70 ns |     7.71 ns |         - |
| Decrypt · ChaCha20-Poly1305 (NaCl.Core)          | 1KB          |   3,695.6 ns |     3.24 ns |     3.03 ns |      72 B |
| Decrypt · ChaCha20-Poly1305 (CryptoHives-Scalar) | 1KB          |   7,634.8 ns |    18.15 ns |    16.09 ns |         - |
|                                                  |              |              |             |             |           |
| Encrypt · ChaCha20-Poly1305 (BouncyCastle)       | 1KB          |   1,861.4 ns |     5.61 ns |     5.25 ns |     336 B |
| Encrypt · ChaCha20-Poly1305 (CryptoHives-Neon)   | 1KB          |   1,933.3 ns |     5.99 ns |     5.60 ns |         - |
| Encrypt · ChaCha20-Poly1305 (OS)                 | 1KB          |   2,611.8 ns |    13.28 ns |    12.42 ns |         - |
| Encrypt · ChaCha20-Poly1305 (NaCl.Core)          | 1KB          |   3,644.5 ns |     3.99 ns |     3.73 ns |      72 B |
| Encrypt · ChaCha20-Poly1305 (CryptoHives-Scalar) | 1KB          |   7,623.1 ns |    17.26 ns |    15.30 ns |         - |
|                                                  |              |              |             |             |           |
| Decrypt · ChaCha20-Poly1305 (OS)                 | 8KB          |  10,793.4 ns |    30.62 ns |    28.64 ns |         - |
| Decrypt · ChaCha20-Poly1305 (BouncyCastle)       | 8KB          |  13,338.7 ns |    28.66 ns |    26.81 ns |     416 B |
| Decrypt · ChaCha20-Poly1305 (CryptoHives-Neon)   | 8KB          |  14,458.4 ns |     8.02 ns |     7.50 ns |         - |
| Decrypt · ChaCha20-Poly1305 (NaCl.Core)          | 8KB          |  25,703.0 ns |    54.58 ns |    51.05 ns |      72 B |
| Decrypt · ChaCha20-Poly1305 (CryptoHives-Scalar) | 8KB          |  56,970.5 ns |   103.97 ns |    92.16 ns |         - |
|                                                  |              |              |             |             |           |
| Encrypt · ChaCha20-Poly1305 (OS)                 | 8KB          |   9,952.0 ns |    35.96 ns |    33.63 ns |         - |
| Encrypt · ChaCha20-Poly1305 (BouncyCastle)       | 8KB          |  13,345.8 ns |    18.78 ns |    17.57 ns |     336 B |
| Encrypt · ChaCha20-Poly1305 (CryptoHives-Neon)   | 8KB          |  14,406.5 ns |    17.85 ns |    16.70 ns |         - |
| Encrypt · ChaCha20-Poly1305 (NaCl.Core)          | 8KB          |  25,635.6 ns |    38.25 ns |    29.86 ns |      72 B |
| Encrypt · ChaCha20-Poly1305 (CryptoHives-Scalar) | 8KB          |  56,904.9 ns |   113.56 ns |   106.22 ns |         - |
|                                                  |              |              |             |             |           |
| Decrypt · ChaCha20-Poly1305 (OS)                 | 128KB        | 149,805.7 ns |   686.79 ns |   642.43 ns |         - |
| Decrypt · ChaCha20-Poly1305 (BouncyCastle)       | 128KB        | 208,152.2 ns |   379.13 ns |   354.64 ns |     416 B |
| Decrypt · ChaCha20-Poly1305 (CryptoHives-Neon)   | 128KB        | 226,804.9 ns |   180.64 ns |   168.97 ns |         - |
| Decrypt · ChaCha20-Poly1305 (NaCl.Core)          | 128KB        | 406,009.9 ns |   839.16 ns |   743.89 ns |      72 B |
| Decrypt · ChaCha20-Poly1305 (CryptoHives-Scalar) | 128KB        | 902,391.1 ns | 1,667.75 ns | 1,560.01 ns |         - |
|                                                  |              |              |             |             |           |
| Encrypt · ChaCha20-Poly1305 (OS)                 | 128KB        | 140,010.7 ns |   866.73 ns |   810.74 ns |         - |
| Encrypt · ChaCha20-Poly1305 (BouncyCastle)       | 128KB        | 211,489.7 ns |   632.68 ns |   591.81 ns |     336 B |
| Encrypt · ChaCha20-Poly1305 (CryptoHives-Neon)   | 128KB        | 227,988.6 ns |   113.22 ns |   105.91 ns |         - |
| Encrypt · ChaCha20-Poly1305 (NaCl.Core)          | 128KB        | 405,136.5 ns |   500.14 ns |   467.83 ns |      72 B |
| Encrypt · ChaCha20-Poly1305 (CryptoHives-Scalar) | 128KB        | 902,923.2 ns | 1,840.62 ns | 1,631.66 ns |         - |