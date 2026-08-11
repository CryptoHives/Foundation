| Description                             | TestDataSize | Mean          | Error        | StdDev       | Allocated |
|---------------------------------------- |------------- |--------------:|-------------:|-------------:|----------:|
| Decrypt · ChaCha20 (CryptoHives-AVX2)   | 128B         |      68.20 ns |     0.187 ns |     0.175 ns |         - |
| Decrypt · ChaCha20 (CryptoHives-SSSE3)  | 128B         |     125.20 ns |     0.569 ns |     0.444 ns |         - |
| Decrypt · ChaCha20 (BouncyCastle)       | 128B         |     233.03 ns |     1.257 ns |     1.176 ns |      96 B |
| Decrypt · ChaCha20 (NaCl.Core)          | 128B         |     274.80 ns |     0.826 ns |     0.772 ns |      24 B |
| Decrypt · ChaCha20 (CryptoHives-Scalar) | 128B         |     460.13 ns |     1.485 ns |     1.389 ns |         - |
|                                         |              |               |              |              |           |
| Encrypt · ChaCha20 (CryptoHives-AVX2)   | 128B         |      67.99 ns |     0.556 ns |     0.520 ns |         - |
| Encrypt · ChaCha20 (CryptoHives-SSSE3)  | 128B         |     125.44 ns |     0.370 ns |     0.328 ns |         - |
| Encrypt · ChaCha20 (BouncyCastle)       | 128B         |     232.78 ns |     1.597 ns |     1.494 ns |      96 B |
| Encrypt · ChaCha20 (NaCl.Core)          | 128B         |     275.36 ns |     0.904 ns |     0.846 ns |      24 B |
| Encrypt · ChaCha20 (CryptoHives-Scalar) | 128B         |     456.95 ns |     1.130 ns |     1.057 ns |         - |
|                                         |              |               |              |              |           |
| Decrypt · ChaCha20 (CryptoHives-AVX2)   | 1KB          |     519.86 ns |     1.952 ns |     1.826 ns |         - |
| Decrypt · ChaCha20 (CryptoHives-SSSE3)  | 1KB          |     999.47 ns |     2.810 ns |     2.491 ns |         - |
| Decrypt · ChaCha20 (NaCl.Core)          | 1KB          |   1,501.86 ns |     3.584 ns |     3.352 ns |      24 B |
| Decrypt · ChaCha20 (BouncyCastle)       | 1KB          |   1,739.92 ns |    19.621 ns |    18.354 ns |      96 B |
| Decrypt · ChaCha20 (CryptoHives-Scalar) | 1KB          |   3,573.56 ns |     9.656 ns |     9.032 ns |         - |
|                                         |              |               |              |              |           |
| Encrypt · ChaCha20 (CryptoHives-AVX2)   | 1KB          |     519.34 ns |     1.663 ns |     1.388 ns |         - |
| Encrypt · ChaCha20 (CryptoHives-SSSE3)  | 1KB          |     997.53 ns |     3.744 ns |     3.502 ns |         - |
| Encrypt · ChaCha20 (NaCl.Core)          | 1KB          |   1,507.45 ns |     4.854 ns |     4.540 ns |      24 B |
| Encrypt · ChaCha20 (BouncyCastle)       | 1KB          |   1,726.52 ns |    10.520 ns |     9.841 ns |      96 B |
| Encrypt · ChaCha20 (CryptoHives-Scalar) | 1KB          |   3,564.65 ns |    15.194 ns |    14.212 ns |         - |
|                                         |              |               |              |              |           |
| Decrypt · ChaCha20 (CryptoHives-AVX2)   | 8KB          |   4,130.77 ns |    13.451 ns |    11.924 ns |         - |
| Decrypt · ChaCha20 (CryptoHives-SSSE3)  | 8KB          |   7,973.47 ns |    41.060 ns |    38.408 ns |         - |
| Decrypt · ChaCha20 (NaCl.Core)          | 8KB          |  11,133.89 ns |    24.113 ns |    22.555 ns |      24 B |
| Decrypt · ChaCha20 (BouncyCastle)       | 8KB          |  13,532.89 ns |   100.337 ns |    93.855 ns |      96 B |
| Decrypt · ChaCha20 (CryptoHives-Scalar) | 8KB          |  28,484.43 ns |    72.306 ns |    67.635 ns |         - |
|                                         |              |               |              |              |           |
| Encrypt · ChaCha20 (CryptoHives-AVX2)   | 8KB          |   4,129.36 ns |    10.715 ns |    10.022 ns |         - |
| Encrypt · ChaCha20 (CryptoHives-SSSE3)  | 8KB          |   7,988.47 ns |    35.827 ns |    29.917 ns |         - |
| Encrypt · ChaCha20 (NaCl.Core)          | 8KB          |  11,475.93 ns |    21.010 ns |    19.652 ns |      24 B |
| Encrypt · ChaCha20 (BouncyCastle)       | 8KB          |  13,620.46 ns |   140.938 ns |   131.833 ns |      96 B |
| Encrypt · ChaCha20 (CryptoHives-Scalar) | 8KB          |  28,413.35 ns |    76.539 ns |    63.913 ns |         - |
|                                         |              |               |              |              |           |
| Decrypt · ChaCha20 (CryptoHives-AVX2)   | 128KB        |  66,035.36 ns |   244.993 ns |   229.167 ns |         - |
| Decrypt · ChaCha20 (CryptoHives-SSSE3)  | 128KB        | 127,913.43 ns |   544.863 ns |   454.985 ns |         - |
| Decrypt · ChaCha20 (NaCl.Core)          | 128KB        | 180,026.02 ns |   493.428 ns |   412.035 ns |      24 B |
| Decrypt · ChaCha20 (BouncyCastle)       | 128KB        | 216,812.56 ns | 1,216.465 ns | 1,137.882 ns |      96 B |
| Decrypt · ChaCha20 (CryptoHives-Scalar) | 128KB        | 455,997.56 ns | 1,391.140 ns | 1,301.273 ns |         - |
|                                         |              |               |              |              |           |
| Encrypt · ChaCha20 (CryptoHives-AVX2)   | 128KB        |  66,028.59 ns |   298.198 ns |   278.934 ns |         - |
| Encrypt · ChaCha20 (CryptoHives-SSSE3)  | 128KB        | 127,839.29 ns |   361.732 ns |   302.063 ns |         - |
| Encrypt · ChaCha20 (BouncyCastle)       | 128KB        | 217,162.50 ns | 1,419.959 ns | 1,328.230 ns |      96 B |
| Encrypt · ChaCha20 (NaCl.Core)          | 128KB        | 256,257.21 ns |   819.471 ns |   726.440 ns |      24 B |
| Encrypt · ChaCha20 (CryptoHives-Scalar) | 128KB        | 454,951.58 ns | 1,341.407 ns | 1,189.122 ns |         - |