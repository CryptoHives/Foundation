| Description                             | TestDataSize | Mean            | Error         | StdDev        | Median          | Code Size | Allocated |
|---------------------------------------- |------------- |----------------:|--------------:|--------------:|----------------:|----------:|----------:|
| Decrypt · ChaCha20 (CryptoHives-AVX2)   | 128B         |        87.09 ns |      0.397 ns |      0.371 ns |        87.06 ns |   2,656 B |         - |
| Decrypt · ChaCha20 (CryptoHives-SSSE3)  | 128B         |       150.16 ns |      1.188 ns |      1.053 ns |       149.78 ns |   2,415 B |         - |
| Decrypt · ChaCha20 (NaCl.Core)          | 128B         |       373.02 ns |      0.906 ns |      0.848 ns |       372.84 ns |   7,397 B |      24 B |
| Decrypt · ChaCha20 (BouncyCastle)       | 128B         |       478.41 ns |      1.327 ns |      1.176 ns |       478.01 ns |     762 B |      96 B |
| Decrypt · ChaCha20 (CryptoHives-Scalar) | 128B         |     1,080.85 ns |      5.059 ns |      4.225 ns |     1,079.14 ns |   3,618 B |         - |
|                                         |              |                 |               |               |                 |           |           |
| Encrypt · ChaCha20 (CryptoHives-AVX2)   | 128B         |        92.38 ns |      0.711 ns |      0.665 ns |        92.67 ns |   2,656 B |         - |
| Encrypt · ChaCha20 (CryptoHives-SSSE3)  | 128B         |       152.72 ns |      0.367 ns |      0.343 ns |       152.78 ns |   2,415 B |         - |
| Encrypt · ChaCha20 (NaCl.Core)          | 128B         |       391.77 ns |      3.597 ns |      3.365 ns |       392.92 ns |   7,349 B |      24 B |
| Encrypt · ChaCha20 (BouncyCastle)       | 128B         |       495.81 ns |      6.266 ns |      5.861 ns |       498.85 ns |     762 B |      96 B |
| Encrypt · ChaCha20 (CryptoHives-Scalar) | 128B         |     1,119.32 ns |      8.655 ns |      8.096 ns |     1,123.39 ns |   3,618 B |         - |
|                                         |              |                 |               |               |                 |           |           |
| Decrypt · ChaCha20 (CryptoHives-AVX2)   | 1KB          |       579.52 ns |      1.098 ns |      1.027 ns |       579.34 ns |   2,677 B |         - |
| Decrypt · ChaCha20 (CryptoHives-SSSE3)  | 1KB          |     1,124.82 ns |      5.878 ns |      5.498 ns |     1,125.30 ns |   2,415 B |         - |
| Decrypt · ChaCha20 (NaCl.Core)          | 1KB          |     2,051.18 ns |     36.589 ns |     34.225 ns |     2,074.58 ns |   7,438 B |      24 B |
| Decrypt · ChaCha20 (BouncyCastle)       | 1KB          |     3,755.75 ns |     50.430 ns |     47.172 ns |     3,775.39 ns |     762 B |      96 B |
| Decrypt · ChaCha20 (CryptoHives-Scalar) | 1KB          |     8,748.46 ns |     90.133 ns |     84.311 ns |     8,766.38 ns |   3,618 B |         - |
|                                         |              |                 |               |               |                 |           |           |
| Encrypt · ChaCha20 (CryptoHives-AVX2)   | 1KB          |       600.40 ns |      5.916 ns |      5.534 ns |       603.15 ns |   2,656 B |         - |
| Encrypt · ChaCha20 (CryptoHives-SSSE3)  | 1KB          |     1,133.53 ns |      4.905 ns |      4.348 ns |     1,134.39 ns |   2,415 B |         - |
| Encrypt · ChaCha20 (NaCl.Core)          | 1KB          |     2,069.47 ns |     25.461 ns |     23.816 ns |     2,082.63 ns |   7,446 B |      24 B |
| Encrypt · ChaCha20 (BouncyCastle)       | 1KB          |     3,689.69 ns |     48.004 ns |     44.903 ns |     3,668.31 ns |     762 B |      96 B |
| Encrypt · ChaCha20 (CryptoHives-Scalar) | 1KB          |     8,603.67 ns |     36.386 ns |     32.255 ns |     8,597.76 ns |   3,618 B |         - |
|                                         |              |                 |               |               |                 |           |           |
| Decrypt · ChaCha20 (CryptoHives-AVX2)   | 8KB          |     4,620.74 ns |     84.206 ns |     78.767 ns |     4,653.46 ns |   2,656 B |         - |
| Decrypt · ChaCha20 (CryptoHives-SSSE3)  | 8KB          |     8,909.15 ns |    103.363 ns |     96.686 ns |     8,952.81 ns |   2,415 B |         - |
| Decrypt · ChaCha20 (NaCl.Core)          | 8KB          |    15,404.53 ns |    288.364 ns |    269.736 ns |    15,543.83 ns |   7,440 B |      24 B |
| Decrypt · ChaCha20 (BouncyCastle)       | 8KB          |    29,105.15 ns |    411.470 ns |    384.889 ns |    29,259.35 ns |     762 B |      96 B |
| Decrypt · ChaCha20 (CryptoHives-Scalar) | 8KB          |    68,901.56 ns |  1,286.051 ns |  1,202.973 ns |    68,978.71 ns |   3,618 B |         - |
|                                         |              |                 |               |               |                 |           |           |
| Encrypt · ChaCha20 (CryptoHives-AVX2)   | 8KB          |     4,581.49 ns |     12.902 ns |     11.437 ns |     4,579.19 ns |   2,656 B |         - |
| Encrypt · ChaCha20 (CryptoHives-SSSE3)  | 8KB          |     8,749.77 ns |     15.096 ns |     13.382 ns |     8,751.94 ns |   2,415 B |         - |
| Encrypt · ChaCha20 (NaCl.Core)          | 8KB          |    15,151.50 ns |     33.089 ns |     29.332 ns |    15,148.81 ns |   7,462 B |      24 B |
| Encrypt · ChaCha20 (BouncyCastle)       | 8KB          |    28,845.97 ns |     75.806 ns |     70.909 ns |    28,844.86 ns |     762 B |      96 B |
| Encrypt · ChaCha20 (CryptoHives-Scalar) | 8KB          |    68,658.04 ns |    154.249 ns |    144.284 ns |    68,714.51 ns |   3,618 B |         - |
|                                         |              |                 |               |               |                 |           |           |
| Decrypt · ChaCha20 (CryptoHives-AVX2)   | 128KB        |    73,738.40 ns |  1,308.229 ns |  1,223.718 ns |    74,553.23 ns |   2,677 B |         - |
| Decrypt · ChaCha20 (CryptoHives-SSSE3)  | 128KB        |   140,407.13 ns |  2,231.093 ns |  2,086.966 ns |   141,538.21 ns |   2,423 B |         - |
| Decrypt · ChaCha20 (NaCl.Core)          | 128KB        |   246,651.23 ns |  4,890.845 ns |  4,803.464 ns |   250,245.34 ns |   7,445 B |      24 B |
| Decrypt · ChaCha20 (BouncyCastle)       | 128KB        |   467,623.48 ns |  5,107.721 ns |  4,777.766 ns |   469,378.91 ns |     762 B |      96 B |
| Decrypt · ChaCha20 (CryptoHives-Scalar) | 128KB        | 1,118,133.95 ns | 16,495.468 ns | 15,429.871 ns | 1,126,363.48 ns |   3,618 B |         - |
|                                         |              |                 |               |               |                 |           |           |
| Encrypt · ChaCha20 (CryptoHives-AVX2)   | 128KB        |    72,934.04 ns |    107.165 ns |     89.488 ns |    72,910.38 ns |   2,656 B |         - |
| Encrypt · ChaCha20 (CryptoHives-SSSE3)  | 128KB        |   139,296.32 ns |    471.031 ns |    440.603 ns |   139,304.30 ns |   2,415 B |         - |
| Encrypt · ChaCha20 (NaCl.Core)          | 128KB        |   244,381.61 ns |    905.650 ns |    847.145 ns |   244,354.37 ns |   7,437 B |      24 B |
| Encrypt · ChaCha20 (BouncyCastle)       | 128KB        |   458,427.21 ns |    776.557 ns |    726.392 ns |   458,263.55 ns |     762 B |      96 B |
| Encrypt · ChaCha20 (CryptoHives-Scalar) | 128KB        | 1,105,250.96 ns |  3,747.234 ns |  2,925.594 ns | 1,105,466.02 ns |   3,618 B |         - |