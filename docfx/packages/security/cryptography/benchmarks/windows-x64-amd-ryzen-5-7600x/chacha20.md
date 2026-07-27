| Description                             | TestDataSize | Mean          | Error        | StdDev       | Allocated |
|---------------------------------------- |------------- |--------------:|-------------:|-------------:|----------:|
| Decrypt · ChaCha20 (CryptoHives-AVX2)   | 128B         |      68.00 ns |     0.652 ns |     0.610 ns |         - |
| Decrypt · ChaCha20 (CryptoHives-SSSE3)  | 128B         |     126.21 ns |     0.616 ns |     0.546 ns |         - |
| Decrypt · ChaCha20 (NaCl.Core)          | 128B         |     277.55 ns |     0.717 ns |     0.670 ns |      24 B |
| Decrypt · ChaCha20 (BouncyCastle)       | 128B         |     319.80 ns |     2.294 ns |     2.034 ns |      96 B |
| Decrypt · ChaCha20 (CryptoHives-Scalar) | 128B         |     459.49 ns |     1.417 ns |     1.256 ns |         - |
|                                         |              |               |              |              |           |
| Encrypt · ChaCha20 (CryptoHives-AVX2)   | 128B         |      69.70 ns |     0.247 ns |     0.219 ns |         - |
| Encrypt · ChaCha20 (CryptoHives-SSSE3)  | 128B         |     127.03 ns |     1.307 ns |     1.092 ns |         - |
| Encrypt · ChaCha20 (NaCl.Core)          | 128B         |     280.44 ns |     1.236 ns |     1.156 ns |      24 B |
| Encrypt · ChaCha20 (BouncyCastle)       | 128B         |     315.40 ns |     2.586 ns |     2.419 ns |      96 B |
| Encrypt · ChaCha20 (CryptoHives-Scalar) | 128B         |     459.14 ns |     2.082 ns |     1.738 ns |         - |
|                                         |              |               |              |              |           |
| Decrypt · ChaCha20 (CryptoHives-AVX2)   | 1KB          |     523.41 ns |     5.218 ns |     4.881 ns |         - |
| Decrypt · ChaCha20 (CryptoHives-SSSE3)  | 1KB          |   1,009.03 ns |    15.396 ns |    14.401 ns |         - |
| Decrypt · ChaCha20 (NaCl.Core)          | 1KB          |   1,498.05 ns |     3.557 ns |     3.153 ns |      24 B |
| Decrypt · ChaCha20 (BouncyCastle)       | 1KB          |   1,820.05 ns |    10.108 ns |     9.455 ns |      96 B |
| Decrypt · ChaCha20 (CryptoHives-Scalar) | 1KB          |   3,590.98 ns |    13.058 ns |    11.576 ns |         - |
|                                         |              |               |              |              |           |
| Encrypt · ChaCha20 (CryptoHives-AVX2)   | 1KB          |     522.97 ns |     6.522 ns |     6.100 ns |         - |
| Encrypt · ChaCha20 (CryptoHives-SSSE3)  | 1KB          |   1,003.61 ns |     9.901 ns |     9.261 ns |         - |
| Encrypt · ChaCha20 (NaCl.Core)          | 1KB          |   1,498.93 ns |     2.184 ns |     1.705 ns |      24 B |
| Encrypt · ChaCha20 (BouncyCastle)       | 1KB          |   1,799.92 ns |     7.861 ns |     7.354 ns |      96 B |
| Encrypt · ChaCha20 (CryptoHives-Scalar) | 1KB          |   3,597.07 ns |    13.102 ns |    12.256 ns |         - |
|                                         |              |               |              |              |           |
| Decrypt · ChaCha20 (CryptoHives-AVX2)   | 8KB          |   4,167.23 ns |    45.943 ns |    42.975 ns |         - |
| Decrypt · ChaCha20 (CryptoHives-SSSE3)  | 8KB          |   8,043.99 ns |    77.268 ns |    72.277 ns |         - |
| Decrypt · ChaCha20 (NaCl.Core)          | 8KB          |  11,278.18 ns |    20.513 ns |    16.015 ns |      24 B |
| Decrypt · ChaCha20 (BouncyCastle)       | 8KB          |  13,627.76 ns |    77.677 ns |    68.859 ns |      96 B |
| Decrypt · ChaCha20 (CryptoHives-Scalar) | 8KB          |  28,717.85 ns |   102.310 ns |    90.696 ns |         - |
|                                         |              |               |              |              |           |
| Encrypt · ChaCha20 (CryptoHives-AVX2)   | 8KB          |   4,159.35 ns |    33.346 ns |    29.560 ns |         - |
| Encrypt · ChaCha20 (CryptoHives-SSSE3)  | 8KB          |   8,057.00 ns |    96.242 ns |    85.316 ns |         - |
| Encrypt · ChaCha20 (NaCl.Core)          | 8KB          |  11,334.58 ns |    30.071 ns |    26.657 ns |      24 B |
| Encrypt · ChaCha20 (BouncyCastle)       | 8KB          |  13,626.88 ns |    69.708 ns |    61.794 ns |      96 B |
| Encrypt · ChaCha20 (CryptoHives-Scalar) | 8KB          |  28,608.28 ns |    94.998 ns |    88.861 ns |         - |
|                                         |              |               |              |              |           |
| Decrypt · ChaCha20 (CryptoHives-AVX2)   | 128KB        |  66,402.99 ns |   754.138 ns |   705.422 ns |         - |
| Decrypt · ChaCha20 (CryptoHives-SSSE3)  | 128KB        | 128,124.87 ns |   503.979 ns |   393.474 ns |         - |
| Decrypt · ChaCha20 (NaCl.Core)          | 128KB        | 178,989.11 ns |   510.228 ns |   426.064 ns |      24 B |
| Decrypt · ChaCha20 (BouncyCastle)       | 128KB        | 216,877.65 ns | 1,161.175 ns | 1,086.164 ns |      96 B |
| Decrypt · ChaCha20 (CryptoHives-Scalar) | 128KB        | 456,684.62 ns |   636.063 ns |   496.596 ns |         - |
|                                         |              |               |              |              |           |
| Encrypt · ChaCha20 (CryptoHives-AVX2)   | 128KB        |  66,403.11 ns |   684.752 ns |   640.518 ns |         - |
| Encrypt · ChaCha20 (CryptoHives-SSSE3)  | 128KB        | 128,690.43 ns | 1,377.675 ns | 1,150.421 ns |         - |
| Encrypt · ChaCha20 (NaCl.Core)          | 128KB        | 180,194.01 ns |   604.838 ns |   565.766 ns |      24 B |
| Encrypt · ChaCha20 (BouncyCastle)       | 128KB        | 216,731.42 ns | 1,250.613 ns | 1,108.636 ns |      96 B |
| Encrypt · ChaCha20 (CryptoHives-Scalar) | 128KB        | 457,487.04 ns | 2,534.839 ns | 2,247.068 ns |         - |