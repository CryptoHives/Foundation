| Description                             | TestDataSize | Mean          | Error        | StdDev     | Allocated |
|---------------------------------------- |------------- |--------------:|-------------:|-----------:|----------:|
| Decrypt · ChaCha20 (CryptoHives-AVX2)   | 128B         |      67.55 ns |     0.261 ns |   0.218 ns |         - |
| Decrypt · ChaCha20 (CryptoHives-SSSE3)  | 128B         |     126.01 ns |     0.460 ns |   0.384 ns |         - |
| Decrypt · ChaCha20 (NaCl.Core)          | 128B         |     277.67 ns |     0.477 ns |   0.423 ns |      24 B |
| Decrypt · ChaCha20 (BouncyCastle)       | 128B         |     308.61 ns |     1.093 ns |   1.023 ns |      96 B |
| Decrypt · ChaCha20 (CryptoHives-Scalar) | 128B         |     454.74 ns |     0.440 ns |   0.412 ns |         - |
|                                         |              |               |              |            |           |
| Encrypt · ChaCha20 (CryptoHives-AVX2)   | 128B         |      67.68 ns |     0.205 ns |   0.182 ns |         - |
| Encrypt · ChaCha20 (CryptoHives-SSSE3)  | 128B         |     123.94 ns |     0.455 ns |   0.404 ns |         - |
| Encrypt · ChaCha20 (NaCl.Core)          | 128B         |     280.05 ns |     0.524 ns |   0.490 ns |      24 B |
| Encrypt · ChaCha20 (BouncyCastle)       | 128B         |     308.35 ns |     0.520 ns |   0.461 ns |      96 B |
| Encrypt · ChaCha20 (CryptoHives-Scalar) | 128B         |     453.89 ns |     0.686 ns |   0.642 ns |         - |
|                                         |              |               |              |            |           |
| Decrypt · ChaCha20 (CryptoHives-AVX2)   | 1KB          |     512.56 ns |     1.483 ns |   1.315 ns |         - |
| Decrypt · ChaCha20 (CryptoHives-SSSE3)  | 1KB          |     987.01 ns |     3.093 ns |   2.742 ns |         - |
| Decrypt · ChaCha20 (NaCl.Core)          | 1KB          |   1,493.61 ns |     2.311 ns |   2.162 ns |      24 B |
| Decrypt · ChaCha20 (BouncyCastle)       | 1KB          |   1,769.99 ns |     3.590 ns |   3.182 ns |      96 B |
| Decrypt · ChaCha20 (CryptoHives-Scalar) | 1KB          |   3,538.19 ns |     4.612 ns |   4.314 ns |         - |
|                                         |              |               |              |            |           |
| Encrypt · ChaCha20 (CryptoHives-AVX2)   | 1KB          |     513.55 ns |     1.166 ns |   1.034 ns |         - |
| Encrypt · ChaCha20 (CryptoHives-SSSE3)  | 1KB          |     992.18 ns |    15.295 ns |  11.941 ns |         - |
| Encrypt · ChaCha20 (NaCl.Core)          | 1KB          |   1,505.34 ns |     2.473 ns |   2.193 ns |      24 B |
| Encrypt · ChaCha20 (BouncyCastle)       | 1KB          |   1,769.83 ns |     2.930 ns |   2.740 ns |      96 B |
| Encrypt · ChaCha20 (CryptoHives-Scalar) | 1KB          |   3,535.70 ns |     5.249 ns |   4.910 ns |         - |
|                                         |              |               |              |            |           |
| Decrypt · ChaCha20 (CryptoHives-AVX2)   | 8KB          |   4,077.43 ns |     8.447 ns |   7.054 ns |         - |
| Decrypt · ChaCha20 (CryptoHives-SSSE3)  | 8KB          |   7,960.62 ns |   108.865 ns |  96.506 ns |         - |
| Decrypt · ChaCha20 (NaCl.Core)          | 8KB          |  11,209.76 ns |    23.650 ns |  20.965 ns |      24 B |
| Decrypt · ChaCha20 (BouncyCastle)       | 8KB          |  13,402.93 ns |    30.141 ns |  28.194 ns |      96 B |
| Decrypt · ChaCha20 (CryptoHives-Scalar) | 8KB          |  28,267.31 ns |    32.359 ns |  30.269 ns |         - |
|                                         |              |               |              |            |           |
| Encrypt · ChaCha20 (CryptoHives-AVX2)   | 8KB          |   4,083.97 ns |     8.244 ns |   7.711 ns |         - |
| Encrypt · ChaCha20 (CryptoHives-SSSE3)  | 8KB          |   7,897.85 ns |    18.287 ns |  17.106 ns |         - |
| Encrypt · ChaCha20 (NaCl.Core)          | 8KB          |  11,293.96 ns |    17.476 ns |  16.347 ns |      24 B |
| Encrypt · ChaCha20 (BouncyCastle)       | 8KB          |  13,414.61 ns |    29.113 ns |  27.233 ns |      96 B |
| Encrypt · ChaCha20 (CryptoHives-Scalar) | 8KB          |  28,136.97 ns |    28.923 ns |  27.054 ns |         - |
|                                         |              |               |              |            |           |
| Decrypt · ChaCha20 (CryptoHives-AVX2)   | 128KB        |  65,264.31 ns |   220.054 ns | 205.839 ns |         - |
| Decrypt · ChaCha20 (CryptoHives-SSSE3)  | 128KB        | 126,363.85 ns |   511.892 ns | 427.453 ns |         - |
| Decrypt · ChaCha20 (NaCl.Core)          | 128KB        | 206,611.27 ns | 1,059.845 ns | 885.018 ns |      24 B |
| Decrypt · ChaCha20 (BouncyCastle)       | 128KB        | 213,005.90 ns |   352.533 ns | 312.511 ns |      96 B |
| Decrypt · ChaCha20 (CryptoHives-Scalar) | 128KB        | 451,890.37 ns |   649.580 ns | 607.617 ns |         - |
|                                         |              |               |              |            |           |
| Encrypt · ChaCha20 (CryptoHives-AVX2)   | 128KB        |  65,191.51 ns |   153.744 ns | 128.383 ns |         - |
| Encrypt · ChaCha20 (CryptoHives-SSSE3)  | 128KB        | 126,474.21 ns |   371.853 ns | 347.832 ns |         - |
| Encrypt · ChaCha20 (NaCl.Core)          | 128KB        | 205,533.24 ns |   789.461 ns | 659.236 ns |      24 B |
| Encrypt · ChaCha20 (BouncyCastle)       | 128KB        | 213,216.11 ns |   483.442 ns | 452.212 ns |      96 B |
| Encrypt · ChaCha20 (CryptoHives-Scalar) | 128KB        | 450,820.34 ns |   651.128 ns | 609.065 ns |         - |