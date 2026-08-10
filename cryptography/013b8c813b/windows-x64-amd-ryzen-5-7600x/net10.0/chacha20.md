| Description                             | TestDataSize | Mean          | Error        | StdDev       | Median        | Allocated |
|---------------------------------------- |------------- |--------------:|-------------:|-------------:|--------------:|----------:|
| Decrypt · ChaCha20 (CryptoHives-AVX2)   | 128B         |      68.71 ns |     0.261 ns |     0.244 ns |      68.74 ns |         - |
| Decrypt · ChaCha20 (CryptoHives-SSSE3)  | 128B         |     125.96 ns |     0.405 ns |     0.379 ns |     125.99 ns |         - |
| Decrypt · ChaCha20 (NaCl.Core)          | 128B         |     279.83 ns |     0.529 ns |     0.442 ns |     280.00 ns |      24 B |
| Decrypt · ChaCha20 (BouncyCastle)       | 128B         |     317.57 ns |     0.470 ns |     0.393 ns |     317.56 ns |      96 B |
| Decrypt · ChaCha20 (CryptoHives-Scalar) | 128B         |     461.65 ns |     0.718 ns |     0.637 ns |     461.69 ns |         - |
|                                         |              |               |              |              |               |           |
| Encrypt · ChaCha20 (CryptoHives-AVX2)   | 128B         |      68.76 ns |     0.266 ns |     0.236 ns |      68.70 ns |         - |
| Encrypt · ChaCha20 (CryptoHives-SSSE3)  | 128B         |     127.06 ns |     1.111 ns |     0.927 ns |     126.82 ns |         - |
| Encrypt · ChaCha20 (NaCl.Core)          | 128B         |     275.58 ns |     1.010 ns |     0.895 ns |     275.48 ns |      24 B |
| Encrypt · ChaCha20 (BouncyCastle)       | 128B         |     316.48 ns |     0.675 ns |     0.599 ns |     316.45 ns |      96 B |
| Encrypt · ChaCha20 (CryptoHives-Scalar) | 128B         |     460.43 ns |     0.487 ns |     0.431 ns |     460.37 ns |         - |
|                                         |              |               |              |              |               |           |
| Decrypt · ChaCha20 (CryptoHives-AVX2)   | 1KB          |     520.18 ns |     1.450 ns |     1.356 ns |     520.28 ns |         - |
| Decrypt · ChaCha20 (CryptoHives-SSSE3)  | 1KB          |   1,000.47 ns |     3.162 ns |     2.958 ns |   1,000.17 ns |         - |
| Decrypt · ChaCha20 (NaCl.Core)          | 1KB          |   1,505.00 ns |     2.384 ns |     1.991 ns |   1,504.94 ns |      24 B |
| Decrypt · ChaCha20 (BouncyCastle)       | 1KB          |   1,805.21 ns |     3.823 ns |     3.389 ns |   1,805.38 ns |      96 B |
| Decrypt · ChaCha20 (CryptoHives-Scalar) | 1KB          |   3,611.11 ns |     6.663 ns |     5.906 ns |   3,610.61 ns |         - |
|                                         |              |               |              |              |               |           |
| Encrypt · ChaCha20 (CryptoHives-AVX2)   | 1KB          |     520.92 ns |     1.673 ns |     1.483 ns |     520.61 ns |         - |
| Encrypt · ChaCha20 (CryptoHives-SSSE3)  | 1KB          |   1,003.75 ns |     3.649 ns |     3.413 ns |   1,003.05 ns |         - |
| Encrypt · ChaCha20 (NaCl.Core)          | 1KB          |   1,500.57 ns |     2.154 ns |     2.015 ns |   1,500.45 ns |      24 B |
| Encrypt · ChaCha20 (BouncyCastle)       | 1KB          |   1,797.09 ns |     3.161 ns |     2.802 ns |   1,796.32 ns |      96 B |
| Encrypt · ChaCha20 (CryptoHives-Scalar) | 1KB          |   3,592.26 ns |     4.760 ns |     4.220 ns |   3,591.55 ns |         - |
|                                         |              |               |              |              |               |           |
| Decrypt · ChaCha20 (CryptoHives-AVX2)   | 8KB          |   4,151.85 ns |    13.677 ns |    11.421 ns |   4,152.57 ns |         - |
| Decrypt · ChaCha20 (CryptoHives-SSSE3)  | 8KB          |   8,007.39 ns |    35.514 ns |    33.220 ns |   7,995.08 ns |         - |
| Decrypt · ChaCha20 (NaCl.Core)          | 8KB          |  11,309.29 ns |    27.336 ns |    24.232 ns |  11,307.99 ns |      24 B |
| Decrypt · ChaCha20 (BouncyCastle)       | 8KB          |  13,659.25 ns |    11.274 ns |     9.994 ns |  13,657.57 ns |      96 B |
| Decrypt · ChaCha20 (CryptoHives-Scalar) | 8KB          |  28,735.90 ns |    23.626 ns |    20.944 ns |  28,735.48 ns |         - |
|                                         |              |               |              |              |               |           |
| Encrypt · ChaCha20 (CryptoHives-AVX2)   | 8KB          |   4,140.87 ns |    17.260 ns |    16.145 ns |   4,138.69 ns |         - |
| Encrypt · ChaCha20 (CryptoHives-SSSE3)  | 8KB          |   8,062.35 ns |   147.176 ns |   130.468 ns |   8,010.07 ns |         - |
| Encrypt · ChaCha20 (NaCl.Core)          | 8KB          |  11,353.58 ns |   145.656 ns |   136.247 ns |  11,246.86 ns |      24 B |
| Encrypt · ChaCha20 (BouncyCastle)       | 8KB          |  13,625.08 ns |    22.554 ns |    19.994 ns |  13,619.11 ns |      96 B |
| Encrypt · ChaCha20 (CryptoHives-Scalar) | 8KB          |  28,662.90 ns |    44.668 ns |    41.782 ns |  28,652.48 ns |         - |
|                                         |              |               |              |              |               |           |
| Decrypt · ChaCha20 (CryptoHives-AVX2)   | 128KB        |  66,263.43 ns |   345.620 ns |   306.383 ns |  66,179.12 ns |         - |
| Decrypt · ChaCha20 (CryptoHives-SSSE3)  | 128KB        | 128,436.38 ns |   713.914 ns |   632.866 ns | 128,291.24 ns |         - |
| Decrypt · ChaCha20 (NaCl.Core)          | 128KB        | 182,403.32 ns | 2,885.183 ns | 5,128.410 ns | 180,120.35 ns |      24 B |
| Decrypt · ChaCha20 (BouncyCastle)       | 128KB        | 217,864.72 ns |   692.249 ns |   613.661 ns | 217,605.69 ns |      96 B |
| Decrypt · ChaCha20 (CryptoHives-Scalar) | 128KB        | 459,242.57 ns |   426.098 ns |   377.725 ns | 459,349.34 ns |         - |
|                                         |              |               |              |              |               |           |
| Encrypt · ChaCha20 (CryptoHives-AVX2)   | 128KB        |  66,103.97 ns |   211.471 ns |   197.811 ns |  66,073.47 ns |         - |
| Encrypt · ChaCha20 (CryptoHives-SSSE3)  | 128KB        | 128,136.21 ns |   719.607 ns |   600.905 ns | 128,075.02 ns |         - |
| Encrypt · ChaCha20 (NaCl.Core)          | 128KB        | 178,490.04 ns |   217.570 ns |   181.681 ns | 178,474.37 ns |      24 B |
| Encrypt · ChaCha20 (BouncyCastle)       | 128KB        | 217,241.51 ns |   318.968 ns |   298.363 ns | 217,214.33 ns |      96 B |
| Encrypt · ChaCha20 (CryptoHives-Scalar) | 128KB        | 457,646.76 ns |   462.641 ns |   410.120 ns | 457,697.05 ns |         - |