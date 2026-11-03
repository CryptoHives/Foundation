| Description                             | TestDataSize | Mean          | Error        | StdDev       | Code Size | Allocated |
|---------------------------------------- |------------- |--------------:|-------------:|-------------:|----------:|----------:|
| Decrypt · ChaCha20 (CryptoHives-AVX2)   | 128B         |      83.41 ns |     0.226 ns |     0.211 ns |   2,637 B |         - |
| Decrypt · ChaCha20 (CryptoHives-SSSE3)  | 128B         |     142.43 ns |     0.721 ns |     0.675 ns |   2,388 B |         - |
| Decrypt · ChaCha20 (BouncyCastle)       | 128B         |     274.61 ns |     2.373 ns |     2.220 ns |     762 B |      96 B |
| Decrypt · ChaCha20 (NaCl.Core)          | 128B         |     324.72 ns |     1.935 ns |     1.810 ns |   7,343 B |      24 B |
| Decrypt · ChaCha20 (CryptoHives-Scalar) | 128B         |     551.69 ns |     4.097 ns |     3.832 ns |   3,582 B |         - |
|                                         |              |               |              |              |           |           |
| Encrypt · ChaCha20 (CryptoHives-AVX2)   | 128B         |      76.95 ns |     0.760 ns |     0.673 ns |   2,637 B |         - |
| Encrypt · ChaCha20 (CryptoHives-SSSE3)  | 128B         |     149.56 ns |     2.369 ns |     2.216 ns |   2,388 B |         - |
| Encrypt · ChaCha20 (BouncyCastle)       | 128B         |     277.76 ns |     3.586 ns |     3.179 ns |     762 B |      96 B |
| Encrypt · ChaCha20 (NaCl.Core)          | 128B         |     324.99 ns |     1.716 ns |     1.605 ns |   7,338 B |      24 B |
| Encrypt · ChaCha20 (CryptoHives-Scalar) | 128B         |     552.63 ns |     3.536 ns |     3.307 ns |   3,582 B |         - |
|                                         |              |               |              |              |           |           |
| Decrypt · ChaCha20 (CryptoHives-AVX2)   | 1KB          |     589.62 ns |     0.998 ns |     0.934 ns |   2,658 B |         - |
| Decrypt · ChaCha20 (CryptoHives-SSSE3)  | 1KB          |   1,110.75 ns |     2.195 ns |     2.053 ns |   2,409 B |         - |
| Decrypt · ChaCha20 (NaCl.Core)          | 1KB          |   1,766.77 ns |     7.454 ns |     6.973 ns |   7,443 B |      24 B |
| Decrypt · ChaCha20 (BouncyCastle)       | 1KB          |   2,025.86 ns |    22.818 ns |    21.344 ns |     762 B |      96 B |
| Decrypt · ChaCha20 (CryptoHives-Scalar) | 1KB          |   4,277.22 ns |    21.775 ns |    20.368 ns |   3,582 B |         - |
|                                         |              |               |              |              |           |           |
| Encrypt · ChaCha20 (CryptoHives-AVX2)   | 1KB          |     577.88 ns |     1.100 ns |     0.975 ns |   2,637 B |         - |
| Encrypt · ChaCha20 (CryptoHives-SSSE3)  | 1KB          |   1,123.48 ns |     1.602 ns |     1.498 ns |   2,388 B |         - |
| Encrypt · ChaCha20 (NaCl.Core)          | 1KB          |   1,766.85 ns |     7.676 ns |     7.180 ns |   7,429 B |      24 B |
| Encrypt · ChaCha20 (BouncyCastle)       | 1KB          |   2,045.34 ns |    19.208 ns |    17.967 ns |     762 B |      96 B |
| Encrypt · ChaCha20 (CryptoHives-Scalar) | 1KB          |   4,284.54 ns |     8.902 ns |     7.892 ns |   3,582 B |         - |
|                                         |              |               |              |              |           |           |
| Decrypt · ChaCha20 (CryptoHives-AVX2)   | 8KB          |   4,616.04 ns |     8.637 ns |     8.079 ns |   2,637 B |         - |
| Decrypt · ChaCha20 (CryptoHives-SSSE3)  | 8KB          |   8,881.66 ns |    16.096 ns |    15.056 ns |   2,388 B |         - |
| Decrypt · ChaCha20 (NaCl.Core)          | 8KB          |  13,227.98 ns |    50.251 ns |    47.005 ns |   7,442 B |      24 B |
| Decrypt · ChaCha20 (BouncyCastle)       | 8KB          |  15,935.25 ns |   145.873 ns |   136.450 ns |     762 B |      96 B |
| Decrypt · ChaCha20 (CryptoHives-Scalar) | 8KB          |  34,059.56 ns |   269.583 ns |   252.168 ns |   3,582 B |         - |
|                                         |              |               |              |              |           |           |
| Encrypt · ChaCha20 (CryptoHives-AVX2)   | 8KB          |   4,618.77 ns |     8.656 ns |     8.096 ns |   2,637 B |         - |
| Encrypt · ChaCha20 (CryptoHives-SSSE3)  | 8KB          |   8,883.51 ns |    12.558 ns |    10.487 ns |   2,388 B |         - |
| Encrypt · ChaCha20 (NaCl.Core)          | 8KB          |  13,262.07 ns |    24.464 ns |    22.884 ns |   7,442 B |      24 B |
| Encrypt · ChaCha20 (BouncyCastle)       | 8KB          |  15,960.52 ns |   171.188 ns |   160.130 ns |     762 B |      96 B |
| Encrypt · ChaCha20 (CryptoHives-Scalar) | 8KB          |  34,120.35 ns |   296.995 ns |   277.809 ns |   3,582 B |         - |
|                                         |              |               |              |              |           |           |
| Decrypt · ChaCha20 (CryptoHives-AVX2)   | 128KB        |  73,722.82 ns |   112.661 ns |   105.383 ns |   2,637 B |         - |
| Decrypt · ChaCha20 (CryptoHives-SSSE3)  | 128KB        | 141,991.39 ns |   180.261 ns |   159.797 ns |   2,388 B |         - |
| Decrypt · ChaCha20 (NaCl.Core)          | 128KB        | 209,840.67 ns |   723.418 ns |   676.685 ns |   7,431 B |      24 B |
| Decrypt · ChaCha20 (BouncyCastle)       | 128KB        | 254,424.23 ns | 1,922.436 ns | 1,798.247 ns |     762 B |      96 B |
| Decrypt · ChaCha20 (CryptoHives-Scalar) | 128KB        | 542,018.99 ns | 3,434.722 ns | 3,212.841 ns |   3,603 B |         - |
|                                         |              |               |              |              |           |           |
| Encrypt · ChaCha20 (CryptoHives-AVX2)   | 128KB        |  73,827.13 ns |   102.098 ns |    95.503 ns |   2,637 B |         - |
| Encrypt · ChaCha20 (CryptoHives-SSSE3)  | 128KB        | 141,836.38 ns |   138.819 ns |   123.059 ns |   2,388 B |         - |
| Encrypt · ChaCha20 (NaCl.Core)          | 128KB        | 209,401.76 ns |   993.022 ns |   928.873 ns |   7,431 B |      24 B |
| Encrypt · ChaCha20 (BouncyCastle)       | 128KB        | 254,194.40 ns | 2,304.359 ns | 2,155.499 ns |     762 B |      96 B |
| Encrypt · ChaCha20 (CryptoHives-Scalar) | 128KB        | 541,764.15 ns | 3,276.060 ns | 3,064.429 ns |   3,582 B |         - |