| Description                                      | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|------------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|
| Decrypt · ChaCha20-Poly1305 (CryptoHives-Neon)   | 128B         |     427.1 ns |     1.18 ns |     1.11 ns |         - |
| Decrypt · ChaCha20-Poly1305 (BouncyCastle)       | 128B         |     643.1 ns |     5.75 ns |     5.10 ns |     416 B |
| Decrypt · ChaCha20-Poly1305 (NaCl.Core)          | 128B         |     904.6 ns |     5.52 ns |     4.90 ns |      48 B |
| Decrypt · ChaCha20-Poly1305 (CryptoHives-Scalar) | 128B         |   1,558.2 ns |     5.82 ns |     5.44 ns |         - |
| Decrypt · ChaCha20-Poly1305 (OS)                 | 128B         |   2,343.0 ns |     8.39 ns |     7.85 ns |         - |
|                                                  |              |              |             |             |           |
| Encrypt · ChaCha20-Poly1305 (CryptoHives-Neon)   | 128B         |     353.1 ns |     0.78 ns |     0.69 ns |         - |
| Encrypt · ChaCha20-Poly1305 (BouncyCastle)       | 128B         |     427.2 ns |     1.62 ns |     1.52 ns |     336 B |
| Encrypt · ChaCha20-Poly1305 (NaCl.Core)          | 128B         |     799.4 ns |     2.24 ns |     2.09 ns |      48 B |
| Encrypt · ChaCha20-Poly1305 (CryptoHives-Scalar) | 128B         |   1,514.1 ns |     8.48 ns |     7.93 ns |         - |
| Encrypt · ChaCha20-Poly1305 (OS)                 | 128B         |   1,968.9 ns |    15.91 ns |    14.10 ns |         - |
|                                                  |              |              |             |             |           |
| Decrypt · ChaCha20-Poly1305 (BouncyCastle)       | 1KB          |   2,142.1 ns |     7.62 ns |     6.75 ns |     416 B |
| Decrypt · ChaCha20-Poly1305 (CryptoHives-Neon)   | 1KB          |   2,228.3 ns |    15.71 ns |    13.93 ns |         - |
| Decrypt · ChaCha20-Poly1305 (OS)                 | 1KB          |   3,353.1 ns |    12.49 ns |    11.68 ns |         - |
| Decrypt · ChaCha20-Poly1305 (NaCl.Core)          | 1KB          |   4,068.4 ns |    23.59 ns |    22.07 ns |      72 B |
| Decrypt · ChaCha20-Poly1305 (CryptoHives-Scalar) | 1KB          |   8,189.0 ns |    26.48 ns |    24.77 ns |         - |
|                                                  |              |              |             |             |           |
| Encrypt · ChaCha20-Poly1305 (BouncyCastle)       | 1KB          |   1,906.4 ns |     6.84 ns |     6.06 ns |     336 B |
| Encrypt · ChaCha20-Poly1305 (CryptoHives-Neon)   | 1KB          |   1,947.1 ns |     6.38 ns |     5.96 ns |         - |
| Encrypt · ChaCha20-Poly1305 (OS)                 | 1KB          |   2,885.9 ns |    14.24 ns |    13.32 ns |         - |
| Encrypt · ChaCha20-Poly1305 (NaCl.Core)          | 1KB          |   3,650.2 ns |    11.02 ns |    10.31 ns |      72 B |
| Encrypt · ChaCha20-Poly1305 (CryptoHives-Scalar) | 1KB          |   7,667.8 ns |    34.59 ns |    32.35 ns |         - |
|                                                  |              |              |             |             |           |
| Decrypt · ChaCha20-Poly1305 (OS)                 | 8KB          |  11,536.9 ns |    19.44 ns |    18.19 ns |         - |
| Decrypt · ChaCha20-Poly1305 (BouncyCastle)       | 8KB          |  13,979.2 ns |    36.19 ns |    33.85 ns |     416 B |
| Decrypt · ChaCha20-Poly1305 (CryptoHives-Neon)   | 8KB          |  16,126.7 ns |    92.41 ns |    81.92 ns |         - |
| Decrypt · ChaCha20-Poly1305 (NaCl.Core)          | 8KB          |  29,175.8 ns |    98.81 ns |    92.43 ns |      72 B |
| Decrypt · ChaCha20-Poly1305 (CryptoHives-Scalar) | 8KB          |  59,379.0 ns |   110.49 ns |    92.27 ns |         - |
|                                                  |              |              |             |             |           |
| Encrypt · ChaCha20-Poly1305 (OS)                 | 8KB          |  10,291.1 ns |    50.74 ns |    47.46 ns |         - |
| Encrypt · ChaCha20-Poly1305 (BouncyCastle)       | 8KB          |  13,730.9 ns |    32.72 ns |    29.01 ns |     336 B |
| Encrypt · ChaCha20-Poly1305 (CryptoHives-Neon)   | 8KB          |  14,544.5 ns |    53.13 ns |    49.69 ns |         - |
| Encrypt · ChaCha20-Poly1305 (NaCl.Core)          | 8KB          |  26,431.9 ns |   120.19 ns |   112.43 ns |      72 B |
| Encrypt · ChaCha20-Poly1305 (CryptoHives-Scalar) | 8KB          |  55,742.3 ns |   286.39 ns |   267.89 ns |         - |
|                                                  |              |              |             |             |           |
| Decrypt · ChaCha20-Poly1305 (OS)                 | 128KB        | 159,927.8 ns |   576.31 ns |   510.88 ns |         - |
| Decrypt · ChaCha20-Poly1305 (BouncyCastle)       | 128KB        | 217,086.9 ns |   306.05 ns |   255.56 ns |     416 B |
| Decrypt · ChaCha20-Poly1305 (CryptoHives-Neon)   | 128KB        | 254,411.4 ns |   457.90 ns |   382.37 ns |         - |
| Decrypt · ChaCha20-Poly1305 (NaCl.Core)          | 128KB        | 460,464.1 ns |   986.07 ns |   922.37 ns |      72 B |
| Decrypt · ChaCha20-Poly1305 (CryptoHives-Scalar) | 128KB        | 938,180.7 ns | 2,330.90 ns | 2,180.33 ns |         - |
|                                                  |              |              |             |             |           |
| Encrypt · ChaCha20-Poly1305 (OS)                 | 128KB        | 139,022.8 ns |   860.68 ns |   805.08 ns |         - |
| Encrypt · ChaCha20-Poly1305 (BouncyCastle)       | 128KB        | 217,019.8 ns |   452.10 ns |   422.89 ns |     336 B |
| Encrypt · ChaCha20-Poly1305 (CryptoHives-Neon)   | 128KB        | 229,886.1 ns |   652.43 ns |   610.28 ns |         - |
| Encrypt · ChaCha20-Poly1305 (NaCl.Core)          | 128KB        | 416,790.7 ns |   902.10 ns |   799.69 ns |      72 B |
| Encrypt · ChaCha20-Poly1305 (CryptoHives-Scalar) | 128KB        | 880,330.1 ns | 3,979.76 ns | 3,722.67 ns |         - |