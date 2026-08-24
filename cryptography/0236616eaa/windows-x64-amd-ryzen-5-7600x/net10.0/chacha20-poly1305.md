| Description                                      | TestDataSize | Mean         | Error     | StdDev    | Allocated |
|------------------------------------------------- |------------- |-------------:|----------:|----------:|----------:|
| Decrypt · ChaCha20-Poly1305 (CryptoHives-AVX2)   | 128B         |     344.6 ns |   0.47 ns |   0.37 ns |         - |
| Decrypt · ChaCha20-Poly1305 (OS)                 | 128B         |     351.6 ns |   0.78 ns |   0.65 ns |         - |
| Decrypt · ChaCha20-Poly1305 (CryptoHives-SSSE3)  | 128B         |     399.8 ns |   0.41 ns |   0.39 ns |         - |
| Decrypt · ChaCha20-Poly1305 (NaCl.Core)          | 128B         |     595.3 ns |   1.26 ns |   1.11 ns |      48 B |
| Decrypt · ChaCha20-Poly1305 (BouncyCastle)       | 128B         |     642.1 ns |   6.95 ns |   5.80 ns |     416 B |
| Decrypt · ChaCha20-Poly1305 (CryptoHives-Scalar) | 128B         |     890.8 ns |   1.20 ns |   1.00 ns |         - |
|                                                  |              |              |           |           |           |
| Encrypt · ChaCha20-Poly1305 (CryptoHives-AVX2)   | 128B         |     280.3 ns |   0.68 ns |   0.64 ns |         - |
| Encrypt · ChaCha20-Poly1305 (CryptoHives-SSSE3)  | 128B         |     349.4 ns |   0.74 ns |   0.69 ns |         - |
| Encrypt · ChaCha20-Poly1305 (OS)                 | 128B         |     352.8 ns |   0.44 ns |   0.39 ns |         - |
| Encrypt · ChaCha20-Poly1305 (BouncyCastle)       | 128B         |     380.1 ns |   0.78 ns |   0.69 ns |     336 B |
| Encrypt · ChaCha20-Poly1305 (NaCl.Core)          | 128B         |     562.9 ns |   1.16 ns |   1.03 ns |      48 B |
| Encrypt · ChaCha20-Poly1305 (CryptoHives-Scalar) | 128B         |     850.6 ns |   1.15 ns |   1.08 ns |         - |
|                                                  |              |              |           |           |           |
| Decrypt · ChaCha20-Poly1305 (CryptoHives-AVX2)   | 1KB          |   1,266.0 ns |   1.18 ns |   1.05 ns |         - |
| Decrypt · ChaCha20-Poly1305 (BouncyCastle)       | 1KB          |   1,614.5 ns |   4.14 ns |   3.67 ns |     416 B |
| Decrypt · ChaCha20-Poly1305 (CryptoHives-SSSE3)  | 1KB          |   1,716.8 ns |   3.19 ns |   2.83 ns |         - |
| Decrypt · ChaCha20-Poly1305 (OS)                 | 1KB          |   1,788.9 ns |   1.59 ns |   1.41 ns |         - |
| Decrypt · ChaCha20-Poly1305 (NaCl.Core)          | 1KB          |   2,602.0 ns |   7.14 ns |   6.33 ns |      72 B |
| Decrypt · ChaCha20-Poly1305 (CryptoHives-Scalar) | 1KB          |   4,567.0 ns |   5.74 ns |   5.09 ns |         - |
|                                                  |              |              |           |           |           |
| Encrypt · ChaCha20-Poly1305 (CryptoHives-AVX2)   | 1KB          |   1,216.8 ns |   2.17 ns |   2.03 ns |         - |
| Encrypt · ChaCha20-Poly1305 (BouncyCastle)       | 1KB          |   1,300.4 ns |   4.42 ns |   4.13 ns |     336 B |
| Encrypt · ChaCha20-Poly1305 (CryptoHives-SSSE3)  | 1KB          |   1,672.4 ns |   3.83 ns |   3.58 ns |         - |
| Encrypt · ChaCha20-Poly1305 (OS)                 | 1KB          |   1,786.7 ns |   5.89 ns |   4.60 ns |         - |
| Encrypt · ChaCha20-Poly1305 (NaCl.Core)          | 1KB          |   2,549.6 ns |   5.58 ns |   4.66 ns |      72 B |
| Encrypt · ChaCha20-Poly1305 (CryptoHives-Scalar) | 1KB          |   4,524.5 ns |   7.76 ns |   6.48 ns |         - |
|                                                  |              |              |           |           |           |
| Decrypt · ChaCha20-Poly1305 (CryptoHives-AVX2)   | 8KB          |   8,721.1 ns |  11.69 ns |  10.37 ns |         - |
| Decrypt · ChaCha20-Poly1305 (BouncyCastle)       | 8KB          |   9,237.6 ns |  25.08 ns |  23.46 ns |     416 B |
| Decrypt · ChaCha20-Poly1305 (CryptoHives-SSSE3)  | 8KB          |  12,326.7 ns |  27.40 ns |  22.88 ns |         - |
| Decrypt · ChaCha20-Poly1305 (OS)                 | 8KB          |  13,294.2 ns |  15.01 ns |  13.31 ns |         - |
| Decrypt · ChaCha20-Poly1305 (NaCl.Core)          | 8KB          |  18,658.3 ns |  59.35 ns |  52.61 ns |      72 B |
| Decrypt · ChaCha20-Poly1305 (CryptoHives-Scalar) | 8KB          |  34,048.9 ns |  61.76 ns |  54.74 ns |         - |
|                                                  |              |              |           |           |           |
| Encrypt · ChaCha20-Poly1305 (CryptoHives-AVX2)   | 8KB          |   8,684.0 ns |  18.76 ns |  16.63 ns |         - |
| Encrypt · ChaCha20-Poly1305 (BouncyCastle)       | 8KB          |   8,731.5 ns |  12.01 ns |  10.03 ns |     336 B |
| Encrypt · ChaCha20-Poly1305 (CryptoHives-SSSE3)  | 8KB          |  12,292.9 ns |  15.54 ns |  14.54 ns |         - |
| Encrypt · ChaCha20-Poly1305 (OS)                 | 8KB          |  13,286.7 ns |  14.35 ns |  11.98 ns |         - |
| Encrypt · ChaCha20-Poly1305 (NaCl.Core)          | 8KB          |  19,038.4 ns |  70.29 ns |  62.31 ns |      72 B |
| Encrypt · ChaCha20-Poly1305 (CryptoHives-Scalar) | 8KB          |  33,897.6 ns |  64.79 ns |  57.43 ns |         - |
|                                                  |              |              |           |           |           |
| Decrypt · ChaCha20-Poly1305 (CryptoHives-AVX2)   | 128KB        | 136,720.6 ns | 117.28 ns |  97.94 ns |         - |
| Decrypt · ChaCha20-Poly1305 (BouncyCastle)       | 128KB        | 142,411.5 ns | 480.62 ns | 401.34 ns |     416 B |
| Decrypt · ChaCha20-Poly1305 (CryptoHives-SSSE3)  | 128KB        | 194,603.6 ns | 345.82 ns | 323.48 ns |         - |
| Decrypt · ChaCha20-Poly1305 (OS)                 | 128KB        | 210,626.2 ns | 225.16 ns | 188.02 ns |         - |
| Decrypt · ChaCha20-Poly1305 (NaCl.Core)          | 128KB        | 298,642.0 ns | 870.68 ns | 814.44 ns |      72 B |
| Decrypt · ChaCha20-Poly1305 (CryptoHives-Scalar) | 128KB        | 539,267.5 ns | 988.80 ns | 876.54 ns |         - |
|                                                  |              |              |           |           |           |
| Encrypt · ChaCha20-Poly1305 (CryptoHives-AVX2)   | 128KB        | 136,714.6 ns | 220.22 ns | 205.99 ns |         - |
| Encrypt · ChaCha20-Poly1305 (BouncyCastle)       | 128KB        | 138,650.3 ns | 234.94 ns | 208.27 ns |     336 B |
| Encrypt · ChaCha20-Poly1305 (CryptoHives-SSSE3)  | 128KB        | 194,425.4 ns | 262.72 ns | 219.39 ns |         - |
| Encrypt · ChaCha20-Poly1305 (OS)                 | 128KB        | 210,410.5 ns | 145.66 ns | 121.63 ns |         - |
| Encrypt · ChaCha20-Poly1305 (NaCl.Core)          | 128KB        | 288,804.5 ns | 982.84 ns | 871.26 ns |      72 B |
| Encrypt · ChaCha20-Poly1305 (CryptoHives-Scalar) | 128KB        | 537,384.3 ns | 901.89 ns | 753.12 ns |         - |