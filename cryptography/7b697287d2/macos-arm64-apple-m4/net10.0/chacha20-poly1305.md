| Description                                      | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|------------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|
| Decrypt · ChaCha20-Poly1305 (CryptoHives-Neon)   | 128B         |     465.6 ns |     1.64 ns |     1.54 ns |         - |
| Decrypt · ChaCha20-Poly1305 (BouncyCastle)       | 128B         |     622.7 ns |     2.03 ns |     1.80 ns |     416 B |
| Decrypt · ChaCha20-Poly1305 (NaCl.Core)          | 128B         |     831.2 ns |     2.82 ns |     2.64 ns |      48 B |
| Decrypt · ChaCha20-Poly1305 (CryptoHives-Scalar) | 128B         |   1,404.9 ns |     9.05 ns |     8.47 ns |         - |
| Decrypt · ChaCha20-Poly1305 (OS)                 | 128B         |   2,223.6 ns |    18.38 ns |    17.19 ns |         - |
|                                                  |              |              |             |             |           |
| Encrypt · ChaCha20-Poly1305 (CryptoHives-Neon)   | 128B         |     350.3 ns |     1.29 ns |     1.20 ns |         - |
| Encrypt · ChaCha20-Poly1305 (BouncyCastle)       | 128B         |     426.9 ns |     1.23 ns |     1.15 ns |     336 B |
| Encrypt · ChaCha20-Poly1305 (NaCl.Core)          | 128B         |     797.3 ns |     2.89 ns |     2.70 ns |      48 B |
| Encrypt · ChaCha20-Poly1305 (CryptoHives-Scalar) | 128B         |   1,359.5 ns |     7.60 ns |     7.11 ns |         - |
| Encrypt · ChaCha20-Poly1305 (OS)                 | 128B         |   1,918.3 ns |     7.15 ns |     6.69 ns |         - |
|                                                  |              |              |             |             |           |
| Decrypt · ChaCha20-Poly1305 (CryptoHives-Neon)   | 1KB          |   2,014.7 ns |     8.55 ns |     8.00 ns |         - |
| Decrypt · ChaCha20-Poly1305 (BouncyCastle)       | 1KB          |   2,099.2 ns |     5.87 ns |     5.49 ns |     416 B |
| Decrypt · ChaCha20-Poly1305 (OS)                 | 1KB          |   3,169.8 ns |    12.90 ns |    12.07 ns |         - |
| Decrypt · ChaCha20-Poly1305 (NaCl.Core)          | 1KB          |   3,679.4 ns |    10.12 ns |     9.47 ns |      72 B |
| Decrypt · ChaCha20-Poly1305 (CryptoHives-Scalar) | 1KB          |   7,429.8 ns |    41.31 ns |    38.64 ns |         - |
|                                                  |              |              |             |             |           |
| Encrypt · ChaCha20-Poly1305 (CryptoHives-Neon)   | 1KB          |   1,904.1 ns |     7.70 ns |     7.20 ns |         - |
| Encrypt · ChaCha20-Poly1305 (BouncyCastle)       | 1KB          |   1,908.1 ns |     6.18 ns |     5.78 ns |     336 B |
| Encrypt · ChaCha20-Poly1305 (OS)                 | 1KB          |   2,817.8 ns |    20.48 ns |    19.15 ns |         - |
| Encrypt · ChaCha20-Poly1305 (NaCl.Core)          | 1KB          |   3,642.4 ns |    11.46 ns |    10.72 ns |      72 B |
| Encrypt · ChaCha20-Poly1305 (CryptoHives-Scalar) | 1KB          |   7,405.2 ns |    40.22 ns |    37.62 ns |         - |
|                                                  |              |              |             |             |           |
| Decrypt · ChaCha20-Poly1305 (OS)                 | 8KB          |  10,530.4 ns |    33.89 ns |    28.30 ns |         - |
| Decrypt · ChaCha20-Poly1305 (BouncyCastle)       | 8KB          |  13,671.1 ns |    30.95 ns |    28.95 ns |     416 B |
| Decrypt · ChaCha20-Poly1305 (CryptoHives-Neon)   | 8KB          |  14,398.1 ns |    49.95 ns |    46.73 ns |         - |
| Decrypt · ChaCha20-Poly1305 (NaCl.Core)          | 8KB          |  26,401.8 ns |    77.62 ns |    68.81 ns |      72 B |
| Decrypt · ChaCha20-Poly1305 (CryptoHives-Scalar) | 8KB          |  55,376.4 ns |   245.46 ns |   229.61 ns |         - |
|                                                  |              |              |             |             |           |
| Encrypt · ChaCha20-Poly1305 (OS)                 | 8KB          |  10,024.3 ns |    74.33 ns |    69.53 ns |         - |
| Encrypt · ChaCha20-Poly1305 (BouncyCastle)       | 8KB          |  13,605.5 ns |    41.11 ns |    38.45 ns |     336 B |
| Encrypt · ChaCha20-Poly1305 (CryptoHives-Neon)   | 8KB          |  14,294.7 ns |    44.10 ns |    41.25 ns |         - |
| Encrypt · ChaCha20-Poly1305 (NaCl.Core)          | 8KB          |  26,367.3 ns |    87.79 ns |    82.12 ns |      72 B |
| Encrypt · ChaCha20-Poly1305 (CryptoHives-Scalar) | 8KB          |  55,365.7 ns |   325.71 ns |   304.67 ns |         - |
|                                                  |              |              |             |             |           |
| Decrypt · ChaCha20-Poly1305 (OS)                 | 128KB        | 145,639.6 ns |   966.42 ns |   903.99 ns |         - |
| Decrypt · ChaCha20-Poly1305 (BouncyCastle)       | 128KB        | 212,565.1 ns |   547.15 ns |   511.81 ns |     416 B |
| Decrypt · ChaCha20-Poly1305 (CryptoHives-Neon)   | 128KB        | 226,566.4 ns |   615.82 ns |   576.04 ns |         - |
| Decrypt · ChaCha20-Poly1305 (NaCl.Core)          | 128KB        | 416,348.9 ns | 1,255.49 ns | 1,112.96 ns |      72 B |
| Decrypt · ChaCha20-Poly1305 (CryptoHives-Scalar) | 128KB        | 877,999.9 ns | 4,348.62 ns | 4,067.70 ns |         - |
|                                                  |              |              |             |             |           |
| Encrypt · ChaCha20-Poly1305 (OS)                 | 128KB        | 136,013.8 ns |   967.61 ns |   905.10 ns |         - |
| Encrypt · ChaCha20-Poly1305 (BouncyCastle)       | 128KB        | 214,915.9 ns |   804.05 ns |   752.11 ns |     336 B |
| Encrypt · ChaCha20-Poly1305 (CryptoHives-Neon)   | 128KB        | 226,634.9 ns |   725.08 ns |   678.24 ns |         - |
| Encrypt · ChaCha20-Poly1305 (NaCl.Core)          | 128KB        | 416,119.1 ns | 1,649.86 ns | 1,543.28 ns |      72 B |
| Encrypt · ChaCha20-Poly1305 (CryptoHives-Scalar) | 128KB        | 877,529.8 ns | 4,790.83 ns | 4,481.35 ns |         - |