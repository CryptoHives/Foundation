| Description                             | TestDataSize | Mean          | Error        | StdDev       | Allocated |
|---------------------------------------- |------------- |--------------:|-------------:|-------------:|----------:|
| Decrypt · ChaCha20 (CryptoHives-AVX2)   | 128B         |      68.12 ns |     0.303 ns |     0.268 ns |         - |
| Decrypt · ChaCha20 (CryptoHives-SSSE3)  | 128B         |     125.02 ns |     0.483 ns |     0.428 ns |         - |
| Decrypt · ChaCha20 (NaCl.Core)          | 128B         |     278.77 ns |     0.909 ns |     0.759 ns |      24 B |
| Decrypt · ChaCha20 (BouncyCastle)       | 128B         |     361.47 ns |     1.201 ns |     1.124 ns |      96 B |
| Decrypt · ChaCha20 (CryptoHives-Scalar) | 128B         |     457.72 ns |     0.780 ns |     0.692 ns |         - |
|                                         |              |               |              |              |           |
| Encrypt · ChaCha20 (CryptoHives-AVX2)   | 128B         |      67.99 ns |     0.448 ns |     0.397 ns |         - |
| Encrypt · ChaCha20 (CryptoHives-SSSE3)  | 128B         |     125.49 ns |     0.405 ns |     0.379 ns |         - |
| Encrypt · ChaCha20 (NaCl.Core)          | 128B         |     283.42 ns |     0.451 ns |     0.400 ns |      24 B |
| Encrypt · ChaCha20 (BouncyCastle)       | 128B         |     308.45 ns |     1.069 ns |     1.000 ns |      96 B |
| Encrypt · ChaCha20 (CryptoHives-Scalar) | 128B         |     455.31 ns |     1.198 ns |     1.062 ns |         - |
|                                         |              |               |              |              |           |
| Decrypt · ChaCha20 (CryptoHives-AVX2)   | 1KB          |     517.04 ns |     1.487 ns |     1.242 ns |         - |
| Decrypt · ChaCha20 (CryptoHives-SSSE3)  | 1KB          |     993.49 ns |     1.972 ns |     1.748 ns |         - |
| Decrypt · ChaCha20 (NaCl.Core)          | 1KB          |   1,492.87 ns |     2.690 ns |     2.384 ns |      24 B |
| Decrypt · ChaCha20 (BouncyCastle)       | 1KB          |   1,782.13 ns |     6.678 ns |     5.920 ns |      96 B |
| Decrypt · ChaCha20 (CryptoHives-Scalar) | 1KB          |   3,549.72 ns |     7.166 ns |     6.352 ns |         - |
|                                         |              |               |              |              |           |
| Encrypt · ChaCha20 (CryptoHives-AVX2)   | 1KB          |     517.17 ns |     1.431 ns |     1.269 ns |         - |
| Encrypt · ChaCha20 (CryptoHives-SSSE3)  | 1KB          |     993.84 ns |     3.039 ns |     2.843 ns |         - |
| Encrypt · ChaCha20 (NaCl.Core)          | 1KB          |   1,510.31 ns |     4.616 ns |     3.855 ns |      24 B |
| Encrypt · ChaCha20 (BouncyCastle)       | 1KB          |   1,778.35 ns |    15.179 ns |    14.198 ns |      96 B |
| Encrypt · ChaCha20 (CryptoHives-Scalar) | 1KB          |   3,550.02 ns |     7.507 ns |     6.655 ns |         - |
|                                         |              |               |              |              |           |
| Decrypt · ChaCha20 (CryptoHives-AVX2)   | 8KB          |   4,112.21 ns |    10.676 ns |     8.335 ns |         - |
| Decrypt · ChaCha20 (CryptoHives-SSSE3)  | 8KB          |   7,973.43 ns |    15.091 ns |    12.601 ns |         - |
| Decrypt · ChaCha20 (NaCl.Core)          | 8KB          |  11,215.16 ns |    17.882 ns |    15.852 ns |      24 B |
| Decrypt · ChaCha20 (BouncyCastle)       | 8KB          |  13,453.92 ns |    35.210 ns |    29.402 ns |      96 B |
| Decrypt · ChaCha20 (CryptoHives-Scalar) | 8KB          |  28,355.75 ns |    57.121 ns |    50.636 ns |         - |
|                                         |              |               |              |              |           |
| Encrypt · ChaCha20 (CryptoHives-AVX2)   | 8KB          |   4,108.21 ns |     7.424 ns |     6.199 ns |         - |
| Encrypt · ChaCha20 (CryptoHives-SSSE3)  | 8KB          |   7,967.10 ns |    18.206 ns |    16.139 ns |         - |
| Encrypt · ChaCha20 (NaCl.Core)          | 8KB          |  11,203.31 ns |    17.016 ns |    15.084 ns |      24 B |
| Encrypt · ChaCha20 (BouncyCastle)       | 8KB          |  13,428.49 ns |    33.346 ns |    27.846 ns |      96 B |
| Encrypt · ChaCha20 (CryptoHives-Scalar) | 8KB          |  28,222.93 ns |    29.969 ns |    26.567 ns |         - |
|                                         |              |               |              |              |           |
| Decrypt · ChaCha20 (CryptoHives-AVX2)   | 128KB        |  65,691.31 ns |   148.419 ns |   138.831 ns |         - |
| Decrypt · ChaCha20 (CryptoHives-SSSE3)  | 128KB        | 127,341.47 ns |   419.809 ns |   350.560 ns |         - |
| Decrypt · ChaCha20 (NaCl.Core)          | 128KB        | 177,926.79 ns |   519.198 ns |   485.658 ns |      24 B |
| Decrypt · ChaCha20 (BouncyCastle)       | 128KB        | 213,883.77 ns |   557.884 ns |   494.550 ns |      96 B |
| Decrypt · ChaCha20 (CryptoHives-Scalar) | 128KB        | 453,279.03 ns | 1,172.416 ns | 1,039.316 ns |         - |
|                                         |              |               |              |              |           |
| Encrypt · ChaCha20 (CryptoHives-AVX2)   | 128KB        |  65,867.15 ns |   194.891 ns |   162.743 ns |         - |
| Encrypt · ChaCha20 (CryptoHives-SSSE3)  | 128KB        | 127,506.50 ns |   509.641 ns |   451.783 ns |         - |
| Encrypt · ChaCha20 (NaCl.Core)          | 128KB        | 177,904.71 ns |   249.016 ns |   207.940 ns |      24 B |
| Encrypt · ChaCha20 (BouncyCastle)       | 128KB        | 213,657.74 ns |   701.518 ns |   585.800 ns |      96 B |
| Encrypt · ChaCha20 (CryptoHives-Scalar) | 128KB        | 451,041.46 ns | 1,146.715 ns | 1,072.638 ns |         - |