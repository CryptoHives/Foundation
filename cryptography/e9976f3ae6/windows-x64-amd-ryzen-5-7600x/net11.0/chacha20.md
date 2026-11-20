| Description                             | TestDataSize | Mean          | Error        | StdDev       | Code Size | Allocated |
|---------------------------------------- |------------- |--------------:|-------------:|-------------:|----------:|----------:|
| Decrypt · ChaCha20 (CryptoHives-AVX2)   | 128B         |      77.07 ns |     0.258 ns |     0.229 ns |   2,843 B |         - |
| Decrypt · ChaCha20 (CryptoHives-SSSE3)  | 128B         |     142.64 ns |     0.340 ns |     0.302 ns |   2,630 B |         - |
| Decrypt · ChaCha20 (BouncyCastle)       | 128B         |     275.18 ns |     1.123 ns |     0.995 ns |     766 B |      96 B |
| Decrypt · ChaCha20 (NaCl.Core)          | 128B         |     326.09 ns |     1.029 ns |     0.859 ns |  18,133 B |      24 B |
| Decrypt · ChaCha20 (CryptoHives-Scalar) | 128B         |     548.68 ns |     1.894 ns |     1.772 ns |   6,464 B |         - |
|                                         |              |               |              |              |           |           |
| Encrypt · ChaCha20 (CryptoHives-AVX2)   | 128B         |      76.39 ns |     0.259 ns |     0.230 ns |   2,843 B |         - |
| Encrypt · ChaCha20 (CryptoHives-SSSE3)  | 128B         |     142.57 ns |     0.325 ns |     0.304 ns |   2,630 B |         - |
| Encrypt · ChaCha20 (BouncyCastle)       | 128B         |     274.55 ns |     1.137 ns |     1.008 ns |     757 B |      96 B |
| Encrypt · ChaCha20 (NaCl.Core)          | 128B         |     325.21 ns |     1.141 ns |     1.068 ns |  11,481 B |      24 B |
| Encrypt · ChaCha20 (CryptoHives-Scalar) | 128B         |     544.52 ns |     2.070 ns |     1.936 ns |  12,828 B |         - |
|                                         |              |               |              |              |           |           |
| Decrypt · ChaCha20 (CryptoHives-AVX2)   | 1KB          |     578.75 ns |     0.555 ns |     0.519 ns |   2,843 B |         - |
| Decrypt · ChaCha20 (CryptoHives-SSSE3)  | 1KB          |   1,110.66 ns |     1.892 ns |     1.770 ns |   2,630 B |         - |
| Decrypt · ChaCha20 (NaCl.Core)          | 1KB          |   1,732.24 ns |     3.812 ns |     3.380 ns |  18,218 B |      24 B |
| Decrypt · ChaCha20 (BouncyCastle)       | 1KB          |   2,015.60 ns |     7.336 ns |     6.862 ns |     762 B |      96 B |
| Decrypt · ChaCha20 (CryptoHives-Scalar) | 1KB          |   4,261.29 ns |    13.134 ns |    12.286 ns |   6,464 B |         - |
|                                         |              |               |              |              |           |           |
| Encrypt · ChaCha20 (CryptoHives-AVX2)   | 1KB          |     577.85 ns |     0.909 ns |     0.805 ns |   2,843 B |         - |
| Encrypt · ChaCha20 (CryptoHives-SSSE3)  | 1KB          |   1,110.23 ns |     2.141 ns |     2.002 ns |   2,630 B |         - |
| Encrypt · ChaCha20 (NaCl.Core)          | 1KB          |   1,747.30 ns |     4.403 ns |     3.903 ns |  11,566 B |      24 B |
| Encrypt · ChaCha20 (BouncyCastle)       | 1KB          |   2,022.54 ns |     6.151 ns |     5.453 ns |     766 B |      96 B |
| Encrypt · ChaCha20 (CryptoHives-Scalar) | 1KB          |   4,264.51 ns |    10.934 ns |    10.228 ns |  12,423 B |         - |
|                                         |              |               |              |              |           |           |
| Decrypt · ChaCha20 (CryptoHives-AVX2)   | 8KB          |   4,585.32 ns |     6.259 ns |     5.549 ns |   2,843 B |         - |
| Decrypt · ChaCha20 (CryptoHives-SSSE3)  | 8KB          |   8,870.66 ns |    16.682 ns |    15.604 ns |   2,630 B |         - |
| Decrypt · ChaCha20 (NaCl.Core)          | 8KB          |  13,025.06 ns |    40.903 ns |    38.260 ns |  11,567 B |      24 B |
| Decrypt · ChaCha20 (BouncyCastle)       | 8KB          |  15,986.57 ns |    66.272 ns |    55.340 ns |     766 B |      96 B |
| Decrypt · ChaCha20 (CryptoHives-Scalar) | 8KB          |  33,761.99 ns |    92.946 ns |    86.942 ns |   6,464 B |         - |
|                                         |              |               |              |              |           |           |
| Encrypt · ChaCha20 (CryptoHives-AVX2)   | 8KB          |   4,582.96 ns |     5.197 ns |     4.607 ns |   2,843 B |         - |
| Encrypt · ChaCha20 (CryptoHives-SSSE3)  | 8KB          |   8,871.91 ns |    10.138 ns |     9.483 ns |   2,630 B |         - |
| Encrypt · ChaCha20 (NaCl.Core)          | 8KB          |  13,014.10 ns |    33.180 ns |    31.037 ns |  18,219 B |      24 B |
| Encrypt · ChaCha20 (BouncyCastle)       | 8KB          |  15,941.49 ns |    38.623 ns |    32.252 ns |     766 B |      96 B |
| Encrypt · ChaCha20 (CryptoHives-Scalar) | 8KB          |  33,734.29 ns |   105.050 ns |    98.264 ns |  12,423 B |         - |
|                                         |              |               |              |              |           |           |
| Decrypt · ChaCha20 (CryptoHives-AVX2)   | 128KB        |  73,398.88 ns |   135.998 ns |   106.178 ns |   2,843 B |         - |
| Decrypt · ChaCha20 (CryptoHives-SSSE3)  | 128KB        | 141,784.64 ns |   159.206 ns |   148.921 ns |   2,630 B |         - |
| Decrypt · ChaCha20 (NaCl.Core)          | 128KB        | 206,003.04 ns |   336.462 ns |   298.265 ns |  18,210 B |      24 B |
| Decrypt · ChaCha20 (BouncyCastle)       | 128KB        | 250,885.50 ns |   406.202 ns |   339.197 ns |     762 B |      96 B |
| Decrypt · ChaCha20 (CryptoHives-Scalar) | 128KB        | 537,367.59 ns |   772.039 ns |   684.393 ns |   6,463 B |         - |
|                                         |              |               |              |              |           |           |
| Encrypt · ChaCha20 (CryptoHives-AVX2)   | 128KB        |  73,390.88 ns |   105.674 ns |    98.848 ns |   2,843 B |         - |
| Encrypt · ChaCha20 (CryptoHives-SSSE3)  | 128KB        | 141,873.19 ns |   138.289 ns |   129.355 ns |   2,630 B |         - |
| Encrypt · ChaCha20 (NaCl.Core)          | 128KB        | 208,387.13 ns |   377.701 ns |   353.301 ns |  18,212 B |      24 B |
| Encrypt · ChaCha20 (BouncyCastle)       | 128KB        | 252,731.70 ns | 1,110.496 ns |   927.314 ns |     762 B |      96 B |
| Encrypt · ChaCha20 (CryptoHives-Scalar) | 128KB        | 539,412.84 ns | 1,286.587 ns | 1,203.475 ns |   6,463 B |         - |