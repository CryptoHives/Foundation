| Description                                      | TestDataSize | Mean         | Error       | StdDev      | Code Size | Allocated |
|------------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|----------:|
| Decrypt · ChaCha20-Poly1305 (CryptoHives-AVX2)   | 128B         |     364.1 ns |     2.41 ns |     2.13 ns |     306 B |         - |
| Decrypt · ChaCha20-Poly1305 (OS)                 | 128B         |     408.9 ns |     2.95 ns |     2.76 ns |   1,834 B |         - |
| Decrypt · ChaCha20-Poly1305 (CryptoHives-SSSE3)  | 128B         |     439.3 ns |     0.56 ns |     0.49 ns |     306 B |         - |
| Decrypt · ChaCha20-Poly1305 (NaCl.Core)          | 128B         |     689.8 ns |     4.83 ns |     4.28 ns |  19,382 B |      48 B |
| Decrypt · ChaCha20-Poly1305 (BouncyCastle)       | 128B         |     733.2 ns |     1.30 ns |     1.15 ns |     306 B |     416 B |
| Decrypt · ChaCha20-Poly1305 (CryptoHives-Scalar) | 128B         |   1,030.8 ns |     1.10 ns |     0.92 ns |     306 B |         - |
|                                                  |              |              |             |             |           |           |
| Encrypt · ChaCha20-Poly1305 (CryptoHives-AVX2)   | 128B         |     306.5 ns |     0.30 ns |     0.26 ns |     386 B |         - |
| Encrypt · ChaCha20-Poly1305 (CryptoHives-SSSE3)  | 128B         |     401.8 ns |     1.49 ns |     1.40 ns |     383 B |         - |
| Encrypt · ChaCha20-Poly1305 (OS)                 | 128B         |     404.7 ns |     0.82 ns |     0.64 ns |   1,913 B |         - |
| Encrypt · ChaCha20-Poly1305 (BouncyCastle)       | 128B         |     425.6 ns |     1.00 ns |     0.93 ns |     383 B |     336 B |
| Encrypt · ChaCha20-Poly1305 (NaCl.Core)          | 128B         |     645.9 ns |     1.78 ns |     1.67 ns |  17,750 B |      48 B |
| Encrypt · ChaCha20-Poly1305 (CryptoHives-Scalar) | 128B         |     971.5 ns |     2.15 ns |     1.90 ns |     386 B |         - |
|                                                  |              |              |             |             |           |           |
| Decrypt · ChaCha20-Poly1305 (CryptoHives-AVX2)   | 1KB          |   1,368.3 ns |     8.42 ns |     7.87 ns |     306 B |         - |
| Decrypt · ChaCha20-Poly1305 (BouncyCastle)       | 1KB          |   1,867.0 ns |    17.42 ns |    16.29 ns |     306 B |     416 B |
| Decrypt · ChaCha20-Poly1305 (CryptoHives-SSSE3)  | 1KB          |   1,906.8 ns |    13.69 ns |    12.13 ns |     306 B |         - |
| Decrypt · ChaCha20-Poly1305 (OS)                 | 1KB          |   2,099.2 ns |    14.30 ns |    13.37 ns |   1,989 B |         - |
| Decrypt · ChaCha20-Poly1305 (NaCl.Core)          | 1KB          |   3,343.1 ns |    29.02 ns |    27.15 ns |  20,582 B |      72 B |
| Decrypt · ChaCha20-Poly1305 (CryptoHives-Scalar) | 1KB          |   5,255.8 ns |    33.52 ns |    31.36 ns |     306 B |         - |
|                                                  |              |              |             |             |           |           |
| Encrypt · ChaCha20-Poly1305 (CryptoHives-AVX2)   | 1KB          |   1,290.0 ns |     1.93 ns |     1.71 ns |     386 B |         - |
| Encrypt · ChaCha20-Poly1305 (BouncyCastle)       | 1KB          |   1,501.9 ns |     3.93 ns |     3.67 ns |     386 B |     336 B |
| Encrypt · ChaCha20-Poly1305 (CryptoHives-SSSE3)  | 1KB          |   1,838.1 ns |     1.47 ns |     1.23 ns |     386 B |         - |
| Encrypt · ChaCha20-Poly1305 (OS)                 | 1KB          |   2,068.7 ns |     6.58 ns |     6.16 ns |   1,910 B |         - |
| Encrypt · ChaCha20-Poly1305 (NaCl.Core)          | 1KB          |   2,958.5 ns |     7.02 ns |     6.56 ns |  18,317 B |      72 B |
| Encrypt · ChaCha20-Poly1305 (CryptoHives-Scalar) | 1KB          |   5,152.5 ns |     6.73 ns |     5.96 ns |     386 B |         - |
|                                                  |              |              |             |             |           |           |
| Decrypt · ChaCha20-Poly1305 (CryptoHives-AVX2)   | 8KB          |   9,290.2 ns |    61.20 ns |    57.25 ns |     306 B |         - |
| Decrypt · ChaCha20-Poly1305 (BouncyCastle)       | 8KB          |  10,806.0 ns |   110.05 ns |   102.94 ns |     306 B |     416 B |
| Decrypt · ChaCha20-Poly1305 (CryptoHives-SSSE3)  | 8KB          |  13,593.0 ns |    60.34 ns |    56.44 ns |     306 B |         - |
| Decrypt · ChaCha20-Poly1305 (OS)                 | 8KB          |  15,455.5 ns |    78.22 ns |    73.17 ns |   1,989 B |         - |
| Decrypt · ChaCha20-Poly1305 (NaCl.Core)          | 8KB          |  21,941.1 ns |   139.69 ns |   130.66 ns |  20,667 B |      72 B |
| Decrypt · ChaCha20-Poly1305 (CryptoHives-Scalar) | 8KB          |  38,945.7 ns |   310.18 ns |   290.15 ns |     306 B |         - |
|                                                  |              |              |             |             |           |           |
| Encrypt · ChaCha20-Poly1305 (CryptoHives-AVX2)   | 8KB          |   9,173.1 ns |    17.18 ns |    16.07 ns |     383 B |         - |
| Encrypt · ChaCha20-Poly1305 (BouncyCastle)       | 8KB          |  10,127.3 ns |    24.72 ns |    23.12 ns |     383 B |     336 B |
| Encrypt · ChaCha20-Poly1305 (CryptoHives-SSSE3)  | 8KB          |  13,446.9 ns |     9.90 ns |     9.26 ns |     383 B |         - |
| Encrypt · ChaCha20-Poly1305 (OS)                 | 8KB          |  15,354.2 ns |    49.75 ns |    46.53 ns |   1,910 B |         - |
| Encrypt · ChaCha20-Poly1305 (NaCl.Core)          | 8KB          |  21,578.5 ns |    39.84 ns |    33.27 ns |  18,358 B |      72 B |
| Encrypt · ChaCha20-Poly1305 (CryptoHives-Scalar) | 8KB          |  38,506.3 ns |    48.74 ns |    38.05 ns |     383 B |         - |
|                                                  |              |              |             |             |           |           |
| Decrypt · ChaCha20-Poly1305 (CryptoHives-AVX2)   | 128KB        | 145,272.7 ns |   798.69 ns |   747.10 ns |     306 B |         - |
| Decrypt · ChaCha20-Poly1305 (BouncyCastle)       | 128KB        | 166,727.7 ns | 1,495.37 ns | 1,398.77 ns |     306 B |     416 B |
| Decrypt · ChaCha20-Poly1305 (CryptoHives-SSSE3)  | 128KB        | 213,710.6 ns |   846.90 ns |   792.19 ns |     306 B |         - |
| Decrypt · ChaCha20-Poly1305 (OS)                 | 128KB        | 244,456.2 ns | 1,410.84 ns | 1,319.70 ns |   1,989 B |         - |
| Decrypt · ChaCha20-Poly1305 (NaCl.Core)          | 128KB        | 344,194.9 ns | 2,331.30 ns | 2,180.70 ns |  19,523 B |      72 B |
| Decrypt · ChaCha20-Poly1305 (CryptoHives-Scalar) | 128KB        | 616,325.7 ns | 3,705.04 ns | 3,465.70 ns |     306 B |         - |
|                                                  |              |              |             |             |           |           |
| Encrypt · ChaCha20-Poly1305 (CryptoHives-AVX2)   | 128KB        | 144,003.7 ns |   243.24 ns |   215.63 ns |     383 B |         - |
| Encrypt · ChaCha20-Poly1305 (BouncyCastle)       | 128KB        | 160,918.0 ns |   392.40 ns |   347.85 ns |     383 B |     336 B |
| Encrypt · ChaCha20-Poly1305 (CryptoHives-SSSE3)  | 128KB        | 212,617.9 ns |   183.22 ns |   171.38 ns |     383 B |         - |
| Encrypt · ChaCha20-Poly1305 (OS)                 | 128KB        | 242,555.4 ns |   179.53 ns |   149.91 ns |   1,910 B |         - |
| Encrypt · ChaCha20-Poly1305 (NaCl.Core)          | 128KB        | 337,929.7 ns |   778.87 ns |   690.45 ns |  17,275 B |      72 B |
| Encrypt · ChaCha20-Poly1305 (CryptoHives-Scalar) | 128KB        | 610,365.2 ns | 1,164.77 ns | 1,089.52 ns |     383 B |         - |