| Description                                      | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|------------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|
| Decrypt · ChaCha20-Poly1305 (CryptoHives-AVX2)   | 128B         |     380.5 ns |     2.95 ns |     2.76 ns |         - |
| Decrypt · ChaCha20-Poly1305 (OS)                 | 128B         |     404.6 ns |     3.93 ns |     3.68 ns |         - |
| Decrypt · ChaCha20-Poly1305 (CryptoHives-SSSE3)  | 128B         |     470.5 ns |     1.90 ns |     1.77 ns |         - |
| Decrypt · ChaCha20-Poly1305 (NaCl.Core)          | 128B         |     688.1 ns |     3.29 ns |     2.75 ns |      48 B |
| Decrypt · ChaCha20-Poly1305 (BouncyCastle)       | 128B         |     748.0 ns |     4.65 ns |     3.88 ns |     416 B |
| Decrypt · ChaCha20-Poly1305 (CryptoHives-Scalar) | 128B         |   1,028.4 ns |     7.39 ns |     6.91 ns |         - |
|                                                  |              |              |             |             |           |
| Encrypt · ChaCha20-Poly1305 (CryptoHives-AVX2)   | 128B         |     353.0 ns |     1.50 ns |     1.40 ns |         - |
| Encrypt · ChaCha20-Poly1305 (OS)                 | 128B         |     409.6 ns |     2.83 ns |     2.65 ns |         - |
| Encrypt · ChaCha20-Poly1305 (CryptoHives-SSSE3)  | 128B         |     410.9 ns |     1.84 ns |     1.72 ns |         - |
| Encrypt · ChaCha20-Poly1305 (BouncyCastle)       | 128B         |     433.5 ns |     4.89 ns |     4.57 ns |     336 B |
| Encrypt · ChaCha20-Poly1305 (NaCl.Core)          | 128B         |     647.7 ns |     3.99 ns |     3.73 ns |      48 B |
| Encrypt · ChaCha20-Poly1305 (CryptoHives-Scalar) | 128B         |     986.3 ns |     8.59 ns |     8.03 ns |         - |
|                                                  |              |              |             |             |           |
| Decrypt · ChaCha20-Poly1305 (CryptoHives-AVX2)   | 1KB          |   1,500.7 ns |     4.89 ns |     4.57 ns |         - |
| Decrypt · ChaCha20-Poly1305 (BouncyCastle)       | 1KB          |   1,872.3 ns |    14.48 ns |    13.54 ns |     416 B |
| Decrypt · ChaCha20-Poly1305 (CryptoHives-SSSE3)  | 1KB          |   2,046.9 ns |     4.09 ns |     3.83 ns |         - |
| Decrypt · ChaCha20-Poly1305 (OS)                 | 1KB          |   2,073.9 ns |    17.40 ns |    16.27 ns |         - |
| Decrypt · ChaCha20-Poly1305 (NaCl.Core)          | 1KB          |   3,054.3 ns |    21.64 ns |    20.24 ns |      72 B |
| Decrypt · ChaCha20-Poly1305 (CryptoHives-Scalar) | 1KB          |   5,267.9 ns |    39.89 ns |    37.31 ns |         - |
|                                                  |              |              |             |             |           |
| Encrypt · ChaCha20-Poly1305 (CryptoHives-AVX2)   | 1KB          |   1,452.2 ns |     6.23 ns |     5.83 ns |         - |
| Encrypt · ChaCha20-Poly1305 (BouncyCastle)       | 1KB          |   1,514.3 ns |    11.92 ns |    11.15 ns |     336 B |
| Encrypt · ChaCha20-Poly1305 (CryptoHives-SSSE3)  | 1KB          |   1,974.1 ns |     5.18 ns |     4.85 ns |         - |
| Encrypt · ChaCha20-Poly1305 (OS)                 | 1KB          |   2,070.5 ns |    21.49 ns |    20.10 ns |         - |
| Encrypt · ChaCha20-Poly1305 (NaCl.Core)          | 1KB          |   2,979.9 ns |    23.23 ns |    21.73 ns |      72 B |
| Encrypt · ChaCha20-Poly1305 (CryptoHives-Scalar) | 1KB          |   5,232.5 ns |    27.00 ns |    23.93 ns |         - |
|                                                  |              |              |             |             |           |
| Decrypt · ChaCha20-Poly1305 (CryptoHives-AVX2)   | 8KB          |  10,308.1 ns |    42.98 ns |    40.20 ns |         - |
| Decrypt · ChaCha20-Poly1305 (BouncyCastle)       | 8KB          |  10,736.0 ns |    44.61 ns |    41.73 ns |     416 B |
| Decrypt · ChaCha20-Poly1305 (CryptoHives-SSSE3)  | 8KB          |  14,595.2 ns |    47.76 ns |    44.68 ns |         - |
| Decrypt · ChaCha20-Poly1305 (OS)                 | 8KB          |  15,392.9 ns |   111.65 ns |   104.44 ns |         - |
| Decrypt · ChaCha20-Poly1305 (NaCl.Core)          | 8KB          |  21,725.4 ns |   142.47 ns |   133.27 ns |      72 B |
| Decrypt · ChaCha20-Poly1305 (CryptoHives-Scalar) | 8KB          |  39,166.7 ns |   129.53 ns |   108.17 ns |         - |
|                                                  |              |              |             |             |           |
| Encrypt · ChaCha20-Poly1305 (BouncyCastle)       | 8KB          |  10,247.5 ns |    93.49 ns |    87.45 ns |     336 B |
| Encrypt · ChaCha20-Poly1305 (CryptoHives-AVX2)   | 8KB          |  10,281.8 ns |    48.57 ns |    45.44 ns |         - |
| Encrypt · ChaCha20-Poly1305 (CryptoHives-SSSE3)  | 8KB          |  14,574.7 ns |    52.25 ns |    48.88 ns |         - |
| Encrypt · ChaCha20-Poly1305 (OS)                 | 8KB          |  15,452.8 ns |    66.94 ns |    62.62 ns |         - |
| Encrypt · ChaCha20-Poly1305 (NaCl.Core)          | 8KB          |  21,578.7 ns |   185.40 ns |   173.42 ns |      72 B |
| Encrypt · ChaCha20-Poly1305 (CryptoHives-Scalar) | 8KB          |  39,241.5 ns |   209.81 ns |   196.26 ns |         - |
|                                                  |              |              |             |             |           |
| Decrypt · ChaCha20-Poly1305 (CryptoHives-AVX2)   | 128KB        | 161,654.9 ns |   649.87 ns |   607.89 ns |         - |
| Decrypt · ChaCha20-Poly1305 (BouncyCastle)       | 128KB        | 166,180.8 ns | 1,093.36 ns | 1,022.73 ns |     416 B |
| Decrypt · ChaCha20-Poly1305 (CryptoHives-SSSE3)  | 128KB        | 230,317.3 ns |   397.22 ns |   371.56 ns |         - |
| Decrypt · ChaCha20-Poly1305 (OS)                 | 128KB        | 244,365.2 ns | 1,372.34 ns | 1,283.68 ns |         - |
| Decrypt · ChaCha20-Poly1305 (NaCl.Core)          | 128KB        | 342,748.6 ns | 2,206.15 ns | 2,063.64 ns |      72 B |
| Decrypt · ChaCha20-Poly1305 (CryptoHives-Scalar) | 128KB        | 621,062.4 ns | 4,435.97 ns | 4,149.41 ns |         - |
|                                                  |              |              |             |             |           |
| Encrypt · ChaCha20-Poly1305 (CryptoHives-AVX2)   | 128KB        | 161,424.6 ns |   758.04 ns |   709.07 ns |         - |
| Encrypt · ChaCha20-Poly1305 (BouncyCastle)       | 128KB        | 163,914.1 ns | 1,519.36 ns | 1,421.21 ns |     336 B |
| Encrypt · ChaCha20-Poly1305 (CryptoHives-SSSE3)  | 128KB        | 229,968.0 ns |   419.53 ns |   350.33 ns |         - |
| Encrypt · ChaCha20-Poly1305 (OS)                 | 128KB        | 244,848.3 ns | 1,611.19 ns | 1,428.28 ns |         - |
| Encrypt · ChaCha20-Poly1305 (NaCl.Core)          | 128KB        | 354,851.0 ns | 2,982.34 ns | 2,789.68 ns |      72 B |
| Encrypt · ChaCha20-Poly1305 (CryptoHives-Scalar) | 128KB        | 620,877.7 ns | 4,669.85 ns | 4,368.18 ns |         - |