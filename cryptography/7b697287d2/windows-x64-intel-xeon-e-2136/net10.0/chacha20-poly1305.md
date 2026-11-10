| Description                                      | TestDataSize | Mean           | Error       | StdDev      | Code Size | Allocated |
|------------------------------------------------- |------------- |---------------:|------------:|------------:|----------:|----------:|
| Decrypt · ChaCha20-Poly1305 (CryptoHives-AVX2)   | 128B         |       484.0 ns |     0.41 ns |     0.36 ns |     310 B |         - |
| Decrypt · ChaCha20-Poly1305 (CryptoHives-SSSE3)  | 128B         |       570.3 ns |     0.51 ns |     0.48 ns |     310 B |         - |
| Decrypt · ChaCha20-Poly1305 (OS)                 | 128B         |       687.3 ns |     0.57 ns |     0.54 ns |   1,859 B |         - |
| Decrypt · ChaCha20-Poly1305 (NaCl.Core)          | 128B         |     1,102.2 ns |     2.03 ns |     1.90 ns |  18,360 B |      48 B |
| Decrypt · ChaCha20-Poly1305 (BouncyCastle)       | 128B         |     1,395.9 ns |     2.00 ns |     1.77 ns |     310 B |     416 B |
| Decrypt · ChaCha20-Poly1305 (CryptoHives-Scalar) | 128B         |     2,460.3 ns |     3.01 ns |     2.67 ns |     310 B |         - |
|                                                  |              |                |             |             |           |           |
| Encrypt · ChaCha20-Poly1305 (CryptoHives-AVX2)   | 128B         |       393.1 ns |     0.25 ns |     0.24 ns |     390 B |         - |
| Encrypt · ChaCha20-Poly1305 (CryptoHives-SSSE3)  | 128B         |       474.8 ns |     0.21 ns |     0.20 ns |     387 B |         - |
| Encrypt · ChaCha20-Poly1305 (OS)                 | 128B         |       687.3 ns |     1.07 ns |     1.00 ns |   1,921 B |         - |
| Encrypt · ChaCha20-Poly1305 (BouncyCastle)       | 128B         |       799.1 ns |     1.03 ns |     0.96 ns |     387 B |     336 B |
| Encrypt · ChaCha20-Poly1305 (NaCl.Core)          | 128B         |     1,023.1 ns |     3.80 ns |     3.56 ns |  17,744 B |      48 B |
| Encrypt · ChaCha20-Poly1305 (CryptoHives-Scalar) | 128B         |     2,374.5 ns |     6.71 ns |     6.28 ns |     390 B |         - |
|                                                  |              |                |             |             |           |           |
| Decrypt · ChaCha20-Poly1305 (CryptoHives-AVX2)   | 1KB          |     2,021.4 ns |     1.13 ns |     0.88 ns |     310 B |         - |
| Decrypt · ChaCha20-Poly1305 (CryptoHives-SSSE3)  | 1KB          |     2,767.2 ns |     3.23 ns |     3.02 ns |     310 B |         - |
| Decrypt · ChaCha20-Poly1305 (BouncyCastle)       | 1KB          |     3,164.3 ns |     4.16 ns |     3.69 ns |     310 B |     416 B |
| Decrypt · ChaCha20-Poly1305 (OS)                 | 1KB          |     3,425.4 ns |     3.46 ns |     3.24 ns |   2,020 B |         - |
| Decrypt · ChaCha20-Poly1305 (NaCl.Core)          | 1KB          |     4,807.4 ns |     8.33 ns |     7.39 ns |  20,483 B |      72 B |
| Decrypt · ChaCha20-Poly1305 (CryptoHives-Scalar) | 1KB          |    13,348.6 ns |    28.82 ns |    26.96 ns |     310 B |         - |
|                                                  |              |                |             |             |           |           |
| Encrypt · ChaCha20-Poly1305 (CryptoHives-AVX2)   | 1KB          |     1,929.5 ns |     1.45 ns |     1.29 ns |     387 B |         - |
| Encrypt · ChaCha20-Poly1305 (BouncyCastle)       | 1KB          |     2,482.4 ns |     2.78 ns |     2.46 ns |     387 B |     336 B |
| Encrypt · ChaCha20-Poly1305 (CryptoHives-SSSE3)  | 1KB          |     2,705.5 ns |     1.11 ns |     0.93 ns |     387 B |         - |
| Encrypt · ChaCha20-Poly1305 (OS)                 | 1KB          |     3,429.4 ns |     3.57 ns |     3.34 ns |   1,921 B |         - |
| Encrypt · ChaCha20-Poly1305 (NaCl.Core)          | 1KB          |     4,697.4 ns |     5.83 ns |     5.17 ns |  18,383 B |      72 B |
| Encrypt · ChaCha20-Poly1305 (CryptoHives-Scalar) | 1KB          |    13,275.9 ns |    19.88 ns |    18.59 ns |     387 B |         - |
|                                                  |              |                |             |             |           |           |
| Decrypt · ChaCha20-Poly1305 (CryptoHives-AVX2)   | 8KB          |    14,370.1 ns |     6.59 ns |     6.17 ns |     310 B |         - |
| Decrypt · ChaCha20-Poly1305 (BouncyCastle)       | 8KB          |    17,306.6 ns |    19.62 ns |    16.39 ns |     310 B |     416 B |
| Decrypt · ChaCha20-Poly1305 (CryptoHives-SSSE3)  | 8KB          |    19,974.0 ns |     9.95 ns |     8.82 ns |     310 B |         - |
| Decrypt · ChaCha20-Poly1305 (OS)                 | 8KB          |    24,951.5 ns |    21.70 ns |    19.24 ns |   2,020 B |         - |
| Decrypt · ChaCha20-Poly1305 (NaCl.Core)          | 8KB          |    34,090.0 ns |    44.67 ns |    41.79 ns |  20,602 B |      72 B |
| Decrypt · ChaCha20-Poly1305 (CryptoHives-Scalar) | 8KB          |   100,419.7 ns |   224.12 ns |   209.65 ns |     310 B |         - |
|                                                  |              |                |             |             |           |           |
| Encrypt · ChaCha20-Poly1305 (CryptoHives-AVX2)   | 8KB          |    14,284.4 ns |     9.69 ns |     8.59 ns |     387 B |         - |
| Encrypt · ChaCha20-Poly1305 (BouncyCastle)       | 8KB          |    16,170.3 ns |    13.83 ns |    12.26 ns |     387 B |     336 B |
| Encrypt · ChaCha20-Poly1305 (CryptoHives-SSSE3)  | 8KB          |    19,921.1 ns |     7.84 ns |     6.95 ns |     387 B |         - |
| Encrypt · ChaCha20-Poly1305 (OS)                 | 8KB          |    24,933.2 ns |    15.54 ns |    14.53 ns |   1,921 B |         - |
| Encrypt · ChaCha20-Poly1305 (NaCl.Core)          | 8KB          |    33,829.9 ns |    31.42 ns |    27.85 ns |  18,504 B |      72 B |
| Encrypt · ChaCha20-Poly1305 (CryptoHives-Scalar) | 8KB          |   100,329.1 ns |   236.93 ns |   221.62 ns |     387 B |         - |
|                                                  |              |                |             |             |           |           |
| Decrypt · ChaCha20-Poly1305 (CryptoHives-AVX2)   | 128KB        |   225,420.6 ns |   159.56 ns |   149.25 ns |     310 B |         - |
| Decrypt · ChaCha20-Poly1305 (BouncyCastle)       | 128KB        |   255,693.4 ns |   125.62 ns |   111.36 ns |     310 B |     416 B |
| Decrypt · ChaCha20-Poly1305 (CryptoHives-SSSE3)  | 128KB        |   315,012.0 ns |   155.11 ns |   129.52 ns |     310 B |         - |
| Decrypt · ChaCha20-Poly1305 (OS)                 | 128KB        |   394,414.1 ns |   437.35 ns |   409.10 ns |   2,020 B |         - |
| Decrypt · ChaCha20-Poly1305 (NaCl.Core)          | 128KB        |   541,990.3 ns | 1,893.05 ns | 1,580.78 ns |  19,595 B |      72 B |
| Decrypt · ChaCha20-Poly1305 (CryptoHives-Scalar) | 128KB        | 1,601,428.6 ns | 2,939.88 ns | 2,749.97 ns |     310 B |         - |
|                                                  |              |                |             |             |           |           |
| Encrypt · ChaCha20-Poly1305 (CryptoHives-AVX2)   | 128KB        |   225,357.6 ns |   189.90 ns |   177.64 ns |     387 B |         - |
| Encrypt · ChaCha20-Poly1305 (BouncyCastle)       | 128KB        |   245,635.6 ns |   270.01 ns |   252.57 ns |     387 B |     336 B |
| Encrypt · ChaCha20-Poly1305 (CryptoHives-SSSE3)  | 128KB        |   315,178.7 ns |   181.20 ns |   169.50 ns |     387 B |         - |
| Encrypt · ChaCha20-Poly1305 (OS)                 | 128KB        |   395,323.0 ns |   312.39 ns |   292.21 ns |   1,921 B |         - |
| Encrypt · ChaCha20-Poly1305 (NaCl.Core)          | 128KB        |   544,638.3 ns | 1,198.20 ns | 1,062.17 ns |  17,264 B |      72 B |
| Encrypt · ChaCha20-Poly1305 (CryptoHives-Scalar) | 128KB        | 1,598,828.5 ns | 2,165.65 ns | 2,025.75 ns |     387 B |         - |