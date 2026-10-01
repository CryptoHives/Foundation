| Description                             | TestDataSize | Mean          | Error        | StdDev       | Allocated |
|---------------------------------------- |------------- |--------------:|-------------:|-------------:|----------:|
| Decrypt · ChaCha20 (CryptoHives-AVX2)   | 128B         |      75.78 ns |     0.536 ns |     0.501 ns |         - |
| Decrypt · ChaCha20 (CryptoHives-SSSE3)  | 128B         |     139.82 ns |     0.392 ns |     0.367 ns |         - |
| Decrypt · ChaCha20 (BouncyCastle)       | 128B         |     275.91 ns |     2.762 ns |     2.584 ns |      96 B |
| Decrypt · ChaCha20 (NaCl.Core)          | 128B         |     325.02 ns |     1.322 ns |     1.236 ns |      24 B |
| Decrypt · ChaCha20 (CryptoHives-Scalar) | 128B         |     537.30 ns |     3.847 ns |     3.599 ns |         - |
|                                         |              |               |              |              |           |
| Encrypt · ChaCha20 (CryptoHives-AVX2)   | 128B         |      76.14 ns |     0.264 ns |     0.247 ns |         - |
| Encrypt · ChaCha20 (CryptoHives-SSSE3)  | 128B         |     139.58 ns |     0.711 ns |     0.665 ns |         - |
| Encrypt · ChaCha20 (BouncyCastle)       | 128B         |     274.17 ns |     2.599 ns |     2.431 ns |      96 B |
| Encrypt · ChaCha20 (NaCl.Core)          | 128B         |     323.54 ns |     1.999 ns |     1.870 ns |      24 B |
| Encrypt · ChaCha20 (CryptoHives-Scalar) | 128B         |     535.55 ns |     3.904 ns |     3.460 ns |         - |
|                                         |              |               |              |              |           |
| Decrypt · ChaCha20 (CryptoHives-AVX2)   | 1KB          |     578.51 ns |     1.286 ns |     1.203 ns |         - |
| Decrypt · ChaCha20 (CryptoHives-SSSE3)  | 1KB          |   1,108.32 ns |     2.308 ns |     2.159 ns |         - |
| Decrypt · ChaCha20 (NaCl.Core)          | 1KB          |   1,756.44 ns |     7.090 ns |     6.632 ns |      24 B |
| Decrypt · ChaCha20 (BouncyCastle)       | 1KB          |   2,038.89 ns |    25.783 ns |    24.117 ns |      96 B |
| Decrypt · ChaCha20 (CryptoHives-Scalar) | 1KB          |   4,200.22 ns |    25.196 ns |    23.569 ns |         - |
|                                         |              |               |              |              |           |
| Encrypt · ChaCha20 (CryptoHives-AVX2)   | 1KB          |     578.03 ns |     1.418 ns |     1.326 ns |         - |
| Encrypt · ChaCha20 (CryptoHives-SSSE3)  | 1KB          |   1,111.48 ns |     1.215 ns |     1.137 ns |         - |
| Encrypt · ChaCha20 (NaCl.Core)          | 1KB          |   1,761.73 ns |     7.307 ns |     6.835 ns |      24 B |
| Encrypt · ChaCha20 (BouncyCastle)       | 1KB          |   2,031.15 ns |    24.523 ns |    22.939 ns |      96 B |
| Encrypt · ChaCha20 (CryptoHives-Scalar) | 1KB          |   4,185.12 ns |    29.606 ns |    27.693 ns |         - |
|                                         |              |               |              |              |           |
| Decrypt · ChaCha20 (CryptoHives-AVX2)   | 8KB          |   4,624.93 ns |     6.612 ns |     6.185 ns |         - |
| Decrypt · ChaCha20 (CryptoHives-SSSE3)  | 8KB          |   8,870.02 ns |     6.368 ns |     5.957 ns |         - |
| Decrypt · ChaCha20 (NaCl.Core)          | 8KB          |  13,239.85 ns |    54.564 ns |    51.040 ns |      24 B |
| Decrypt · ChaCha20 (BouncyCastle)       | 8KB          |  16,146.96 ns |   321.914 ns |   301.119 ns |      96 B |
| Decrypt · ChaCha20 (CryptoHives-Scalar) | 8KB          |  33,358.65 ns |   224.351 ns |   209.858 ns |         - |
|                                         |              |               |              |              |           |
| Encrypt · ChaCha20 (CryptoHives-AVX2)   | 8KB          |   4,617.83 ns |     6.402 ns |     5.989 ns |         - |
| Encrypt · ChaCha20 (CryptoHives-SSSE3)  | 8KB          |   8,879.33 ns |    12.526 ns |    11.717 ns |         - |
| Encrypt · ChaCha20 (NaCl.Core)          | 8KB          |  13,150.45 ns |    66.280 ns |    61.998 ns |      24 B |
| Encrypt · ChaCha20 (BouncyCastle)       | 8KB          |  16,625.39 ns |   204.133 ns |   190.946 ns |      96 B |
| Encrypt · ChaCha20 (CryptoHives-Scalar) | 8KB          |  33,359.99 ns |   228.098 ns |   213.363 ns |         - |
|                                         |              |               |              |              |           |
| Decrypt · ChaCha20 (CryptoHives-AVX2)   | 128KB        |  73,770.60 ns |    81.823 ns |    72.534 ns |         - |
| Decrypt · ChaCha20 (CryptoHives-SSSE3)  | 128KB        | 142,142.12 ns |   101.469 ns |    94.914 ns |         - |
| Decrypt · ChaCha20 (NaCl.Core)          | 128KB        | 210,623.52 ns | 1,019.633 ns |   953.766 ns |      24 B |
| Decrypt · ChaCha20 (BouncyCastle)       | 128KB        | 254,822.65 ns | 2,596.356 ns | 2,428.633 ns |      96 B |
| Decrypt · ChaCha20 (CryptoHives-Scalar) | 128KB        | 533,307.83 ns | 3,448.936 ns | 3,226.137 ns |         - |
|                                         |              |               |              |              |           |
| Encrypt · ChaCha20 (CryptoHives-AVX2)   | 128KB        |  73,802.15 ns |    47.032 ns |    43.994 ns |         - |
| Encrypt · ChaCha20 (CryptoHives-SSSE3)  | 128KB        | 141,915.86 ns |   154.687 ns |   144.694 ns |         - |
| Encrypt · ChaCha20 (NaCl.Core)          | 128KB        | 209,397.49 ns |   937.496 ns |   876.934 ns |      24 B |
| Encrypt · ChaCha20 (BouncyCastle)       | 128KB        | 258,687.56 ns | 3,841.223 ns | 3,593.082 ns |      96 B |
| Encrypt · ChaCha20 (CryptoHives-Scalar) | 128KB        | 533,004.36 ns | 3,059.404 ns | 2,861.769 ns |         - |