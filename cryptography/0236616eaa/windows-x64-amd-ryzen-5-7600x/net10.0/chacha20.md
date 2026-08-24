| Description                             | TestDataSize | Mean          | Error      | StdDev     | Allocated |
|---------------------------------------- |------------- |--------------:|-----------:|-----------:|----------:|
| Decrypt · ChaCha20 (CryptoHives-AVX2)   | 128B         |      68.58 ns |   0.354 ns |   0.296 ns |         - |
| Decrypt · ChaCha20 (CryptoHives-SSSE3)  | 128B         |     126.46 ns |   0.664 ns |   0.589 ns |         - |
| Decrypt · ChaCha20 (BouncyCastle)       | 128B         |     236.73 ns |   0.359 ns |   0.280 ns |      96 B |
| Decrypt · ChaCha20 (NaCl.Core)          | 128B         |     276.63 ns |   1.011 ns |   0.845 ns |      24 B |
| Decrypt · ChaCha20 (CryptoHives-Scalar) | 128B         |     465.92 ns |   1.478 ns |   1.234 ns |         - |
|                                         |              |               |            |            |           |
| Encrypt · ChaCha20 (CryptoHives-AVX2)   | 128B         |      68.25 ns |   0.229 ns |   0.214 ns |         - |
| Encrypt · ChaCha20 (CryptoHives-SSSE3)  | 128B         |     125.89 ns |   0.443 ns |   0.393 ns |         - |
| Encrypt · ChaCha20 (BouncyCastle)       | 128B         |     236.27 ns |   0.401 ns |   0.356 ns |      96 B |
| Encrypt · ChaCha20 (NaCl.Core)          | 128B         |     275.38 ns |   0.650 ns |   0.543 ns |      24 B |
| Encrypt · ChaCha20 (CryptoHives-Scalar) | 128B         |     467.85 ns |   0.620 ns |   0.550 ns |         - |
|                                         |              |               |            |            |           |
| Decrypt · ChaCha20 (CryptoHives-AVX2)   | 1KB          |     520.96 ns |   2.084 ns |   1.949 ns |         - |
| Decrypt · ChaCha20 (CryptoHives-SSSE3)  | 1KB          |   1,000.51 ns |   3.366 ns |   3.149 ns |         - |
| Decrypt · ChaCha20 (NaCl.Core)          | 1KB          |   1,491.06 ns |   3.506 ns |   3.280 ns |      24 B |
| Decrypt · ChaCha20 (BouncyCastle)       | 1KB          |   1,750.31 ns |   6.030 ns |   5.345 ns |      96 B |
| Decrypt · ChaCha20 (CryptoHives-Scalar) | 1KB          |   3,620.59 ns |   5.440 ns |   5.089 ns |         - |
|                                         |              |               |            |            |           |
| Encrypt · ChaCha20 (CryptoHives-AVX2)   | 1KB          |     520.69 ns |   2.307 ns |   1.927 ns |         - |
| Encrypt · ChaCha20 (CryptoHives-SSSE3)  | 1KB          |   1,002.11 ns |   3.276 ns |   2.904 ns |         - |
| Encrypt · ChaCha20 (NaCl.Core)          | 1KB          |   1,497.96 ns |   3.000 ns |   2.659 ns |      24 B |
| Encrypt · ChaCha20 (BouncyCastle)       | 1KB          |   1,739.47 ns |   2.792 ns |   2.180 ns |      96 B |
| Encrypt · ChaCha20 (CryptoHives-Scalar) | 1KB          |   3,619.64 ns |   4.342 ns |   3.626 ns |         - |
|                                         |              |               |            |            |           |
| Decrypt · ChaCha20 (CryptoHives-AVX2)   | 8KB          |   4,139.79 ns |  19.374 ns |  17.175 ns |         - |
| Decrypt · ChaCha20 (CryptoHives-SSSE3)  | 8KB          |   8,007.95 ns |  36.256 ns |  28.306 ns |         - |
| Decrypt · ChaCha20 (NaCl.Core)          | 8KB          |  11,275.98 ns |  29.084 ns |  25.782 ns |      24 B |
| Decrypt · ChaCha20 (BouncyCastle)       | 8KB          |  13,759.60 ns |  59.061 ns |  52.356 ns |      96 B |
| Decrypt · ChaCha20 (CryptoHives-Scalar) | 8KB          |  28,798.45 ns |  40.173 ns |  33.547 ns |         - |
|                                         |              |               |            |            |           |
| Encrypt · ChaCha20 (CryptoHives-AVX2)   | 8KB          |   4,136.67 ns |   8.448 ns |   7.489 ns |         - |
| Encrypt · ChaCha20 (CryptoHives-SSSE3)  | 8KB          |   8,093.63 ns | 138.149 ns | 169.659 ns |         - |
| Encrypt · ChaCha20 (NaCl.Core)          | 8KB          |  11,283.08 ns |  15.849 ns |  12.374 ns |      24 B |
| Encrypt · ChaCha20 (BouncyCastle)       | 8KB          |  13,812.92 ns |  60.797 ns |  56.870 ns |      96 B |
| Encrypt · ChaCha20 (CryptoHives-Scalar) | 8KB          |  28,799.80 ns |  22.464 ns |  18.758 ns |         - |
|                                         |              |               |            |            |           |
| Decrypt · ChaCha20 (CryptoHives-AVX2)   | 128KB        |  66,064.84 ns | 289.377 ns | 270.684 ns |         - |
| Decrypt · ChaCha20 (CryptoHives-SSSE3)  | 128KB        | 127,876.34 ns | 315.475 ns | 279.660 ns |         - |
| Decrypt · ChaCha20 (NaCl.Core)          | 128KB        | 178,061.24 ns | 490.310 ns | 458.636 ns |      24 B |
| Decrypt · ChaCha20 (BouncyCastle)       | 128KB        | 220,128.00 ns | 580.065 ns | 542.593 ns |      96 B |
| Decrypt · ChaCha20 (CryptoHives-Scalar) | 128KB        | 460,857.40 ns | 741.344 ns | 657.182 ns |         - |
|                                         |              |               |            |            |           |
| Encrypt · ChaCha20 (CryptoHives-AVX2)   | 128KB        |  66,072.48 ns | 209.827 ns | 186.006 ns |         - |
| Encrypt · ChaCha20 (CryptoHives-SSSE3)  | 128KB        | 128,306.44 ns | 595.683 ns | 528.058 ns |         - |
| Encrypt · ChaCha20 (BouncyCastle)       | 128KB        | 220,019.41 ns | 355.630 ns | 332.656 ns |      96 B |
| Encrypt · ChaCha20 (NaCl.Core)          | 128KB        | 257,500.56 ns | 428.318 ns | 379.693 ns |      24 B |
| Encrypt · ChaCha20 (CryptoHives-Scalar) | 128KB        | 459,784.28 ns | 704.660 ns | 588.423 ns |         - |