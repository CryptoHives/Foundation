| Description                             | TestDataSize | Mean          | Error        | StdDev       | Allocated |
|---------------------------------------- |------------- |--------------:|-------------:|-------------:|----------:|
| Decrypt · ChaCha20 (CryptoHives-AVX2)   | 128B         |      68.53 ns |     1.321 ns |     1.171 ns |         - |
| Decrypt · ChaCha20 (CryptoHives-SSSE3)  | 128B         |     126.23 ns |     0.414 ns |     0.367 ns |         - |
| Decrypt · ChaCha20 (BouncyCastle)       | 128B         |     235.95 ns |     1.425 ns |     1.113 ns |      96 B |
| Decrypt · ChaCha20 (NaCl.Core)          | 128B         |     276.37 ns |     0.786 ns |     0.697 ns |      24 B |
| Decrypt · ChaCha20 (CryptoHives-Scalar) | 128B         |     465.16 ns |     2.070 ns |     1.936 ns |         - |
|                                         |              |               |              |              |           |
| Encrypt · ChaCha20 (CryptoHives-AVX2)   | 128B         |      66.99 ns |     1.343 ns |     1.599 ns |         - |
| Encrypt · ChaCha20 (CryptoHives-SSSE3)  | 128B         |     126.26 ns |     0.799 ns |     0.624 ns |         - |
| Encrypt · ChaCha20 (BouncyCastle)       | 128B         |     236.47 ns |     1.096 ns |     0.971 ns |      96 B |
| Encrypt · ChaCha20 (NaCl.Core)          | 128B         |     278.63 ns |     1.278 ns |     1.067 ns |      24 B |
| Encrypt · ChaCha20 (CryptoHives-Scalar) | 128B         |     460.96 ns |     0.646 ns |     0.504 ns |         - |
|                                         |              |               |              |              |           |
| Decrypt · ChaCha20 (CryptoHives-AVX2)   | 1KB          |     521.16 ns |     2.231 ns |     1.742 ns |         - |
| Decrypt · ChaCha20 (CryptoHives-SSSE3)  | 1KB          |   1,000.01 ns |     5.280 ns |     4.122 ns |         - |
| Decrypt · ChaCha20 (NaCl.Core)          | 1KB          |   1,512.49 ns |     3.092 ns |     2.582 ns |      24 B |
| Decrypt · ChaCha20 (BouncyCastle)       | 1KB          |   1,744.30 ns |     8.823 ns |     7.821 ns |      96 B |
| Decrypt · ChaCha20 (CryptoHives-Scalar) | 1KB          |   3,600.71 ns |    10.366 ns |     9.189 ns |         - |
|                                         |              |               |              |              |           |
| Encrypt · ChaCha20 (CryptoHives-AVX2)   | 1KB          |     522.71 ns |     1.641 ns |     1.370 ns |         - |
| Encrypt · ChaCha20 (CryptoHives-SSSE3)  | 1KB          |     999.93 ns |     2.577 ns |     2.152 ns |         - |
| Encrypt · ChaCha20 (NaCl.Core)          | 1KB          |   1,499.07 ns |     3.726 ns |     3.486 ns |      24 B |
| Encrypt · ChaCha20 (BouncyCastle)       | 1KB          |   1,740.76 ns |     7.485 ns |     6.250 ns |      96 B |
| Encrypt · ChaCha20 (CryptoHives-Scalar) | 1KB          |   3,600.84 ns |    11.661 ns |     9.738 ns |         - |
|                                         |              |               |              |              |           |
| Decrypt · ChaCha20 (CryptoHives-AVX2)   | 8KB          |   4,138.54 ns |    11.100 ns |     8.666 ns |         - |
| Decrypt · ChaCha20 (CryptoHives-SSSE3)  | 8KB          |   8,008.83 ns |    30.631 ns |    28.652 ns |         - |
| Decrypt · ChaCha20 (NaCl.Core)          | 8KB          |  11,279.53 ns |    38.354 ns |    34.000 ns |      24 B |
| Decrypt · ChaCha20 (BouncyCastle)       | 8KB          |  13,901.03 ns |   222.035 ns |   207.691 ns |      96 B |
| Decrypt · ChaCha20 (CryptoHives-Scalar) | 8KB          |  28,732.29 ns |   148.756 ns |   116.139 ns |         - |
|                                         |              |               |              |              |           |
| Encrypt · ChaCha20 (CryptoHives-AVX2)   | 8KB          |   4,143.30 ns |    19.479 ns |    18.221 ns |         - |
| Encrypt · ChaCha20 (CryptoHives-SSSE3)  | 8KB          |   8,007.90 ns |    28.706 ns |    26.852 ns |         - |
| Encrypt · ChaCha20 (NaCl.Core)          | 8KB          |  11,379.33 ns |    32.432 ns |    28.750 ns |      24 B |
| Encrypt · ChaCha20 (BouncyCastle)       | 8KB          |  13,717.91 ns |    56.292 ns |    47.007 ns |      96 B |
| Encrypt · ChaCha20 (CryptoHives-Scalar) | 8KB          |  28,733.17 ns |   274.806 ns |   229.476 ns |         - |
|                                         |              |               |              |              |           |
| Decrypt · ChaCha20 (CryptoHives-AVX2)   | 128KB        |  66,227.41 ns |   342.651 ns |   303.751 ns |         - |
| Decrypt · ChaCha20 (CryptoHives-SSSE3)  | 128KB        | 129,011.01 ns | 2,066.543 ns | 1,831.936 ns |         - |
| Decrypt · ChaCha20 (NaCl.Core)          | 128KB        | 178,826.75 ns | 1,158.883 ns |   904.780 ns |      24 B |
| Decrypt · ChaCha20 (BouncyCastle)       | 128KB        | 230,102.78 ns |   537.926 ns |   503.176 ns |      96 B |
| Decrypt · ChaCha20 (CryptoHives-Scalar) | 128KB        | 459,401.79 ns | 1,067.682 ns |   998.711 ns |         - |
|                                         |              |               |              |              |           |
| Encrypt · ChaCha20 (CryptoHives-AVX2)   | 128KB        |  66,119.12 ns |   251.143 ns |   234.919 ns |         - |
| Encrypt · ChaCha20 (CryptoHives-SSSE3)  | 128KB        | 128,108.44 ns |   723.944 ns |   677.177 ns |         - |
| Encrypt · ChaCha20 (NaCl.Core)          | 128KB        | 179,295.88 ns | 1,174.027 ns |   980.365 ns |      24 B |
| Encrypt · ChaCha20 (BouncyCastle)       | 128KB        | 227,941.01 ns |   871.763 ns |   815.447 ns |      96 B |
| Encrypt · ChaCha20 (CryptoHives-Scalar) | 128KB        | 459,065.86 ns | 2,211.352 ns | 1,726.478 ns |         - |