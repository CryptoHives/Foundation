| Description                                      | TestDataSize | Mean         | Error       | StdDev    | Code Size | Allocated |
|------------------------------------------------- |------------- |-------------:|------------:|----------:|----------:|----------:|
| Decrypt · ChaCha20-Poly1305 (CryptoHives-AVX2)   | 128B         |     363.5 ns |     0.69 ns |   0.61 ns |     306 B |         - |
| Decrypt · ChaCha20-Poly1305 (OS)                 | 128B         |     408.3 ns |     0.74 ns |   0.66 ns |   1,834 B |         - |
| Decrypt · ChaCha20-Poly1305 (CryptoHives-SSSE3)  | 128B         |     444.5 ns |     0.62 ns |   0.55 ns |     306 B |         - |
| Decrypt · ChaCha20-Poly1305 (NaCl.Core)          | 128B         |     694.6 ns |     1.03 ns |   0.92 ns |  18,263 B |      48 B |
| Decrypt · ChaCha20-Poly1305 (BouncyCastle)       | 128B         |     733.2 ns |     3.09 ns |   2.74 ns |     306 B |     416 B |
| Decrypt · ChaCha20-Poly1305 (CryptoHives-Scalar) | 128B         |   1,024.6 ns |     5.52 ns |   4.90 ns |     306 B |         - |
|                                                  |              |              |             |           |           |           |
| Encrypt · ChaCha20-Poly1305 (CryptoHives-AVX2)   | 128B         |     310.6 ns |     1.54 ns |   1.37 ns |     386 B |         - |
| Encrypt · ChaCha20-Poly1305 (CryptoHives-SSSE3)  | 128B         |     382.9 ns |     1.72 ns |   1.61 ns |     383 B |         - |
| Encrypt · ChaCha20-Poly1305 (OS)                 | 128B         |     406.8 ns |     3.02 ns |   2.83 ns |   1,913 B |         - |
| Encrypt · ChaCha20-Poly1305 (BouncyCastle)       | 128B         |     432.1 ns |     3.67 ns |   3.43 ns |     386 B |     336 B |
| Encrypt · ChaCha20-Poly1305 (NaCl.Core)          | 128B         |     651.0 ns |     5.46 ns |   5.11 ns |  17,737 B |      48 B |
| Encrypt · ChaCha20-Poly1305 (CryptoHives-Scalar) | 128B         |     974.3 ns |     6.89 ns |   6.44 ns |     386 B |         - |
|                                                  |              |              |             |           |           |           |
| Decrypt · ChaCha20-Poly1305 (CryptoHives-AVX2)   | 1KB          |   1,350.0 ns |     2.13 ns |   1.89 ns |     306 B |         - |
| Decrypt · ChaCha20-Poly1305 (BouncyCastle)       | 1KB          |   1,830.7 ns |     4.37 ns |   4.09 ns |     306 B |     416 B |
| Decrypt · ChaCha20-Poly1305 (CryptoHives-SSSE3)  | 1KB          |   1,896.7 ns |     1.59 ns |   1.49 ns |     306 B |         - |
| Decrypt · ChaCha20-Poly1305 (OS)                 | 1KB          |   2,054.6 ns |     4.63 ns |   4.10 ns |   1,989 B |         - |
| Decrypt · ChaCha20-Poly1305 (NaCl.Core)          | 1KB          |   3,031.5 ns |     5.04 ns |   4.21 ns |  20,606 B |      72 B |
| Decrypt · ChaCha20-Poly1305 (CryptoHives-Scalar) | 1KB          |   5,207.6 ns |    11.52 ns |  10.21 ns |     306 B |         - |
|                                                  |              |              |             |           |           |           |
| Encrypt · ChaCha20-Poly1305 (CryptoHives-AVX2)   | 1KB          |   1,306.4 ns |     5.40 ns |   4.79 ns |     386 B |         - |
| Encrypt · ChaCha20-Poly1305 (BouncyCastle)       | 1KB          |   1,509.2 ns |     8.12 ns |   7.60 ns |     383 B |     336 B |
| Encrypt · ChaCha20-Poly1305 (CryptoHives-SSSE3)  | 1KB          |   1,837.0 ns |     6.33 ns |   5.92 ns |     386 B |         - |
| Encrypt · ChaCha20-Poly1305 (OS)                 | 1KB          |   2,071.6 ns |    10.36 ns |   9.69 ns |   1,910 B |         - |
| Encrypt · ChaCha20-Poly1305 (NaCl.Core)          | 1KB          |   2,983.4 ns |    17.82 ns |  15.79 ns |  18,281 B |      72 B |
| Encrypt · ChaCha20-Poly1305 (CryptoHives-Scalar) | 1KB          |   5,205.7 ns |    25.08 ns |  23.46 ns |     386 B |         - |
|                                                  |              |              |             |           |           |           |
| Decrypt · ChaCha20-Poly1305 (CryptoHives-AVX2)   | 8KB          |   9,201.0 ns |    18.92 ns |  16.78 ns |     306 B |         - |
| Decrypt · ChaCha20-Poly1305 (BouncyCastle)       | 8KB          |  10,606.1 ns |    16.16 ns |  14.32 ns |     306 B |     416 B |
| Decrypt · ChaCha20-Poly1305 (CryptoHives-SSSE3)  | 8KB          |  13,491.7 ns |    11.79 ns |  11.03 ns |     306 B |         - |
| Decrypt · ChaCha20-Poly1305 (OS)                 | 8KB          |  15,313.6 ns |    56.64 ns |  52.99 ns |   1,989 B |         - |
| Decrypt · ChaCha20-Poly1305 (NaCl.Core)          | 8KB          |  21,412.1 ns |   125.18 ns | 110.97 ns |  20,670 B |      72 B |
| Decrypt · ChaCha20-Poly1305 (CryptoHives-Scalar) | 8KB          |  38,513.0 ns |    55.23 ns |  48.96 ns |     306 B |         - |
|                                                  |              |              |             |           |           |           |
| Encrypt · ChaCha20-Poly1305 (CryptoHives-AVX2)   | 8KB          |   9,214.3 ns |    25.85 ns |  24.18 ns |     383 B |         - |
| Encrypt · ChaCha20-Poly1305 (BouncyCastle)       | 8KB          |  10,206.8 ns |    80.60 ns |  75.40 ns |     383 B |     336 B |
| Encrypt · ChaCha20-Poly1305 (CryptoHives-SSSE3)  | 8KB          |  13,761.5 ns |    51.03 ns |  47.73 ns |     383 B |         - |
| Encrypt · ChaCha20-Poly1305 (OS)                 | 8KB          |  15,281.2 ns |    32.30 ns |  28.63 ns |   1,910 B |         - |
| Encrypt · ChaCha20-Poly1305 (NaCl.Core)          | 8KB          |  21,643.7 ns |   170.74 ns | 151.35 ns |  18,364 B |      72 B |
| Encrypt · ChaCha20-Poly1305 (CryptoHives-Scalar) | 8KB          |  38,721.1 ns |   220.88 ns | 206.61 ns |     383 B |         - |
|                                                  |              |              |             |           |           |           |
| Decrypt · ChaCha20-Poly1305 (CryptoHives-AVX2)   | 128KB        | 143,644.5 ns |   325.95 ns | 288.95 ns |     306 B |         - |
| Decrypt · ChaCha20-Poly1305 (BouncyCastle)       | 128KB        | 177,575.0 ns |   264.29 ns | 234.28 ns |     306 B |     416 B |
| Decrypt · ChaCha20-Poly1305 (CryptoHives-SSSE3)  | 128KB        | 212,136.5 ns |   208.96 ns | 185.24 ns |     306 B |         - |
| Decrypt · ChaCha20-Poly1305 (OS)                 | 128KB        | 242,458.2 ns |   317.56 ns | 265.18 ns |   1,989 B |         - |
| Decrypt · ChaCha20-Poly1305 (NaCl.Core)          | 128KB        | 340,010.7 ns |   880.35 ns | 780.41 ns |  19,396 B |      72 B |
| Decrypt · ChaCha20-Poly1305 (CryptoHives-Scalar) | 128KB        | 609,041.5 ns |   877.02 ns | 777.45 ns |     306 B |         - |
|                                                  |              |              |             |           |           |           |
| Encrypt · ChaCha20-Poly1305 (CryptoHives-AVX2)   | 128KB        | 143,664.0 ns |   279.24 ns | 247.54 ns |     383 B |         - |
| Encrypt · ChaCha20-Poly1305 (BouncyCastle)       | 128KB        | 160,162.4 ns |   236.40 ns | 209.56 ns |     383 B |     336 B |
| Encrypt · ChaCha20-Poly1305 (CryptoHives-SSSE3)  | 128KB        | 212,216.5 ns |   293.24 ns | 259.95 ns |     383 B |         - |
| Encrypt · ChaCha20-Poly1305 (OS)                 | 128KB        | 242,292.3 ns |   388.14 ns | 344.08 ns |   1,910 B |         - |
| Encrypt · ChaCha20-Poly1305 (NaCl.Core)          | 128KB        | 341,470.9 ns | 1,007.08 ns | 942.02 ns |  17,204 B |      72 B |
| Encrypt · ChaCha20-Poly1305 (CryptoHives-Scalar) | 128KB        | 608,655.4 ns |   851.57 ns | 796.56 ns |     383 B |         - |