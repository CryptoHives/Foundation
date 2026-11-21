| Description                                      | TestDataSize | Mean         | Error       | StdDev      | Code Size | Allocated |
|------------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|----------:|
| Decrypt · ChaCha20-Poly1305 (CryptoHives-AVX2)   | 128B         |     313.8 ns |     0.69 ns |     0.61 ns |     306 B |         - |
| Decrypt · ChaCha20-Poly1305 (CryptoHives-SSSE3)  | 128B         |     381.8 ns |     0.51 ns |     0.45 ns |     306 B |         - |
| Decrypt · ChaCha20-Poly1305 (OS)                 | 128B         |     402.8 ns |     1.03 ns |     0.91 ns |   1,956 B |         - |
| Decrypt · ChaCha20-Poly1305 (NaCl.Core)          | 128B         |     657.9 ns |     0.59 ns |     0.49 ns |  31,384 B |      48 B |
| Decrypt · ChaCha20-Poly1305 (BouncyCastle)       | 128B         |     711.0 ns |     0.90 ns |     0.75 ns |     306 B |     416 B |
| Decrypt · ChaCha20-Poly1305 (CryptoHives-Scalar) | 128B         |     951.6 ns |     0.62 ns |     0.55 ns |     306 B |         - |
|                                                  |              |              |             |             |           |           |
| Encrypt · ChaCha20-Poly1305 (CryptoHives-AVX2)   | 128B         |     260.1 ns |     0.39 ns |     0.36 ns |     386 B |         - |
| Encrypt · ChaCha20-Poly1305 (CryptoHives-SSSE3)  | 128B         |     324.8 ns |     0.46 ns |     0.41 ns |     386 B |         - |
| Encrypt · ChaCha20-Poly1305 (OS)                 | 128B         |     409.6 ns |     0.89 ns |     0.79 ns |     693 B |         - |
| Encrypt · ChaCha20-Poly1305 (BouncyCastle)       | 128B         |     416.8 ns |     0.69 ns |     0.54 ns |     386 B |     336 B |
| Encrypt · ChaCha20-Poly1305 (NaCl.Core)          | 128B         |     614.5 ns |     1.80 ns |     1.59 ns |  29,227 B |      48 B |
| Encrypt · ChaCha20-Poly1305 (CryptoHives-Scalar) | 128B         |     906.6 ns |     2.06 ns |     1.83 ns |     386 B |         - |
|                                                  |              |              |             |             |           |           |
| Decrypt · ChaCha20-Poly1305 (CryptoHives-AVX2)   | 1KB          |   1,351.0 ns |     1.61 ns |     1.43 ns |     306 B |         - |
| Decrypt · ChaCha20-Poly1305 (BouncyCastle)       | 1KB          |   1,823.8 ns |     4.09 ns |     3.63 ns |     306 B |     416 B |
| Decrypt · ChaCha20-Poly1305 (CryptoHives-SSSE3)  | 1KB          |   1,887.3 ns |     2.31 ns |     2.05 ns |     306 B |         - |
| Decrypt · ChaCha20-Poly1305 (OS)                 | 1KB          |   2,053.8 ns |     3.41 ns |     3.02 ns |   1,956 B |         - |
| Decrypt · ChaCha20-Poly1305 (NaCl.Core)          | 1KB          |   2,854.8 ns |     4.08 ns |     3.41 ns |  31,843 B |      72 B |
| Decrypt · ChaCha20-Poly1305 (CryptoHives-Scalar) | 1KB          |   5,082.1 ns |     5.54 ns |     4.91 ns |     306 B |         - |
|                                                  |              |              |             |             |           |           |
| Encrypt · ChaCha20-Poly1305 (CryptoHives-AVX2)   | 1KB          |   1,298.3 ns |     1.47 ns |     1.30 ns |     386 B |         - |
| Encrypt · ChaCha20-Poly1305 (BouncyCastle)       | 1KB          |   1,467.6 ns |     3.34 ns |     2.79 ns |     386 B |     336 B |
| Encrypt · ChaCha20-Poly1305 (CryptoHives-SSSE3)  | 1KB          |   1,831.7 ns |     3.54 ns |     3.31 ns |     386 B |         - |
| Encrypt · ChaCha20-Poly1305 (OS)                 | 1KB          |   2,051.4 ns |     3.31 ns |     2.94 ns |   1,870 B |         - |
| Encrypt · ChaCha20-Poly1305 (NaCl.Core)          | 1KB          |   2,814.2 ns |     2.99 ns |     2.33 ns |  25,140 B |      72 B |
| Encrypt · ChaCha20-Poly1305 (CryptoHives-Scalar) | 1KB          |   5,035.4 ns |     6.74 ns |     5.62 ns |     386 B |         - |
|                                                  |              |              |             |             |           |           |
| Decrypt · ChaCha20-Poly1305 (CryptoHives-AVX2)   | 8KB          |   9,624.9 ns |     9.18 ns |     8.14 ns |     306 B |         - |
| Decrypt · ChaCha20-Poly1305 (BouncyCastle)       | 8KB          |  10,571.8 ns |    15.51 ns |    12.11 ns |     306 B |     416 B |
| Decrypt · ChaCha20-Poly1305 (CryptoHives-SSSE3)  | 8KB          |  13,918.8 ns |    26.96 ns |    23.90 ns |     306 B |         - |
| Decrypt · ChaCha20-Poly1305 (OS)                 | 8KB          |  15,296.7 ns |    26.16 ns |    20.42 ns |   1,956 B |         - |
| Decrypt · ChaCha20-Poly1305 (NaCl.Core)          | 8KB          |  20,175.0 ns |    36.65 ns |    30.60 ns |  31,087 B |      72 B |
| Decrypt · ChaCha20-Poly1305 (CryptoHives-Scalar) | 8KB          |  38,118.7 ns |    27.79 ns |    23.20 ns |     306 B |         - |
|                                                  |              |              |             |             |           |           |
| Encrypt · ChaCha20-Poly1305 (CryptoHives-AVX2)   | 8KB          |   9,573.3 ns |     9.53 ns |     8.45 ns |     386 B |         - |
| Encrypt · ChaCha20-Poly1305 (BouncyCastle)       | 8KB          |   9,972.6 ns |    25.82 ns |    22.89 ns |     386 B |     336 B |
| Encrypt · ChaCha20-Poly1305 (CryptoHives-SSSE3)  | 8KB          |  13,868.3 ns |    20.86 ns |    19.52 ns |     386 B |         - |
| Encrypt · ChaCha20-Poly1305 (OS)                 | 8KB          |  15,271.9 ns |    25.15 ns |    22.29 ns |   1,870 B |         - |
| Encrypt · ChaCha20-Poly1305 (NaCl.Core)          | 8KB          |  20,297.0 ns |    23.82 ns |    19.89 ns |  30,886 B |      72 B |
| Encrypt · ChaCha20-Poly1305 (CryptoHives-Scalar) | 8KB          |  38,038.5 ns |    77.30 ns |    68.53 ns |     386 B |         - |
|                                                  |              |              |             |             |           |           |
| Decrypt · ChaCha20-Poly1305 (CryptoHives-AVX2)   | 128KB        | 151,970.2 ns |   294.23 ns |   275.22 ns |     306 B |         - |
| Decrypt · ChaCha20-Poly1305 (BouncyCastle)       | 128KB        | 177,635.0 ns |   121.76 ns |   101.68 ns |     306 B |     416 B |
| Decrypt · ChaCha20-Poly1305 (CryptoHives-SSSE3)  | 128KB        | 220,152.4 ns |   275.61 ns |   257.81 ns |     306 B |         - |
| Decrypt · ChaCha20-Poly1305 (OS)                 | 128KB        | 242,097.7 ns |   319.01 ns |   266.39 ns |   1,956 B |         - |
| Decrypt · ChaCha20-Poly1305 (NaCl.Core)          | 128KB        | 324,115.6 ns |   299.06 ns |   249.73 ns |  28,766 B |      72 B |
| Decrypt · ChaCha20-Poly1305 (CryptoHives-Scalar) | 128KB        | 605,378.2 ns | 2,357.86 ns | 2,205.54 ns |     306 B |         - |
|                                                  |              |              |             |             |           |           |
| Encrypt · ChaCha20-Poly1305 (CryptoHives-AVX2)   | 128KB        | 151,432.0 ns |   228.47 ns |   190.78 ns |     386 B |         - |
| Encrypt · ChaCha20-Poly1305 (BouncyCastle)       | 128KB        | 158,658.2 ns |   603.31 ns |   503.79 ns |     386 B |     336 B |
| Encrypt · ChaCha20-Poly1305 (CryptoHives-SSSE3)  | 128KB        | 219,995.0 ns |   289.92 ns |   271.20 ns |     386 B |         - |
| Encrypt · ChaCha20-Poly1305 (OS)                 | 128KB        | 242,410.2 ns |   474.76 ns |   444.09 ns |   1,870 B |         - |
| Encrypt · ChaCha20-Poly1305 (NaCl.Core)          | 128KB        | 325,207.6 ns |   257.71 ns |   228.45 ns |  34,884 B |      72 B |
| Encrypt · ChaCha20-Poly1305 (CryptoHives-Scalar) | 128KB        | 603,736.8 ns | 1,102.49 ns |   920.63 ns |     386 B |         - |