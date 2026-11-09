| Description                                      | TestDataSize | Mean           | Error        | StdDev       | Code Size | Allocated |
|------------------------------------------------- |------------- |---------------:|-------------:|-------------:|----------:|----------:|
| Decrypt · ChaCha20-Poly1305 (CryptoHives-AVX2)   | 128B         |       356.0 ns |      0.30 ns |      0.25 ns |     310 B |         - |
| Decrypt · ChaCha20-Poly1305 (CryptoHives-SSSE3)  | 128B         |       416.3 ns |      0.54 ns |      0.51 ns |     310 B |         - |
| Decrypt · ChaCha20-Poly1305 (OS)                 | 128B         |       507.4 ns |      1.07 ns |      1.00 ns |   1,859 B |         - |
| Decrypt · ChaCha20-Poly1305 (NaCl.Core)          | 128B         |       828.8 ns |      1.92 ns |      1.80 ns |  18,354 B |      48 B |
| Decrypt · ChaCha20-Poly1305 (BouncyCastle)       | 128B         |     1,029.6 ns |      2.23 ns |      1.86 ns |     310 B |     416 B |
| Decrypt · ChaCha20-Poly1305 (CryptoHives-Scalar) | 128B         |     1,817.2 ns |      2.93 ns |      2.59 ns |     310 B |         - |
|                                                  |              |                |              |              |           |           |
| Encrypt · ChaCha20-Poly1305 (CryptoHives-AVX2)   | 128B         |       298.8 ns |      4.35 ns |      4.07 ns |     387 B |         - |
| Encrypt · ChaCha20-Poly1305 (CryptoHives-SSSE3)  | 128B         |       367.4 ns |      5.43 ns |      5.08 ns |     387 B |         - |
| Encrypt · ChaCha20-Poly1305 (OS)                 | 128B         |       579.0 ns |      9.24 ns |      8.65 ns |   1,924 B |         - |
| Encrypt · ChaCha20-Poly1305 (BouncyCastle)       | 128B         |       606.5 ns |     10.43 ns |      9.75 ns |     387 B |     336 B |
| Encrypt · ChaCha20-Poly1305 (NaCl.Core)          | 128B         |       764.2 ns |     14.74 ns |     14.48 ns |  17,778 B |      48 B |
| Encrypt · ChaCha20-Poly1305 (CryptoHives-Scalar) | 128B         |     1,812.8 ns |     20.76 ns |     19.42 ns |     390 B |         - |
|                                                  |              |                |              |              |           |           |
| Decrypt · ChaCha20-Poly1305 (CryptoHives-AVX2)   | 1KB          |     1,494.2 ns |      2.95 ns |      2.62 ns |     310 B |         - |
| Decrypt · ChaCha20-Poly1305 (CryptoHives-SSSE3)  | 1KB          |     2,059.1 ns |      5.60 ns |      4.97 ns |     310 B |         - |
| Decrypt · ChaCha20-Poly1305 (BouncyCastle)       | 1KB          |     2,345.2 ns |      6.59 ns |      5.84 ns |     310 B |     416 B |
| Decrypt · ChaCha20-Poly1305 (OS)                 | 1KB          |     2,541.1 ns |      3.68 ns |      3.44 ns |   2,020 B |         - |
| Decrypt · ChaCha20-Poly1305 (NaCl.Core)          | 1KB          |     3,524.0 ns |      3.08 ns |      2.57 ns |  19,547 B |      72 B |
| Decrypt · ChaCha20-Poly1305 (CryptoHives-Scalar) | 1KB          |     9,865.4 ns |     22.73 ns |     21.26 ns |     310 B |         - |
|                                                  |              |                |              |              |           |           |
| Encrypt · ChaCha20-Poly1305 (CryptoHives-AVX2)   | 1KB          |     1,468.8 ns |     21.53 ns |     20.13 ns |     390 B |         - |
| Encrypt · ChaCha20-Poly1305 (BouncyCastle)       | 1KB          |     1,883.9 ns |     32.34 ns |     30.25 ns |     390 B |     336 B |
| Encrypt · ChaCha20-Poly1305 (CryptoHives-SSSE3)  | 1KB          |     2,072.0 ns |     34.27 ns |     32.06 ns |     390 B |         - |
| Encrypt · ChaCha20-Poly1305 (OS)                 | 1KB          |     2,609.0 ns |     36.20 ns |     33.86 ns |   1,921 B |         - |
| Encrypt · ChaCha20-Poly1305 (NaCl.Core)          | 1KB          |     3,563.8 ns |     46.25 ns |     43.26 ns |  18,302 B |      72 B |
| Encrypt · ChaCha20-Poly1305 (CryptoHives-Scalar) | 1KB          |    10,066.6 ns |    193.34 ns |    180.85 ns |     387 B |         - |
|                                                  |              |                |              |              |           |           |
| Decrypt · ChaCha20-Poly1305 (CryptoHives-AVX2)   | 8KB          |    10,632.4 ns |     15.52 ns |     13.76 ns |     310 B |         - |
| Decrypt · ChaCha20-Poly1305 (BouncyCastle)       | 8KB          |    13,242.6 ns |    132.99 ns |    124.40 ns |     310 B |     416 B |
| Decrypt · ChaCha20-Poly1305 (CryptoHives-SSSE3)  | 8KB          |    14,755.9 ns |     24.72 ns |     21.91 ns |     310 B |         - |
| Decrypt · ChaCha20-Poly1305 (OS)                 | 8KB          |    18,985.4 ns |    279.15 ns |    261.12 ns |   2,020 B |         - |
| Decrypt · ChaCha20-Poly1305 (NaCl.Core)          | 8KB          |    26,568.5 ns |    349.01 ns |    326.46 ns |  20,715 B |      72 B |
| Decrypt · ChaCha20-Poly1305 (CryptoHives-Scalar) | 8KB          |    74,259.7 ns |    126.62 ns |    118.44 ns |     310 B |         - |
|                                                  |              |                |              |              |           |           |
| Encrypt · ChaCha20-Poly1305 (CryptoHives-AVX2)   | 8KB          |    10,841.0 ns |    160.28 ns |    149.93 ns |     387 B |         - |
| Encrypt · ChaCha20-Poly1305 (BouncyCastle)       | 8KB          |    12,056.5 ns |    193.19 ns |    180.71 ns |     387 B |     336 B |
| Encrypt · ChaCha20-Poly1305 (CryptoHives-SSSE3)  | 8KB          |    15,177.1 ns |    190.00 ns |    177.72 ns |     387 B |         - |
| Encrypt · ChaCha20-Poly1305 (OS)                 | 8KB          |    19,099.2 ns |     92.77 ns |     86.77 ns |   1,921 B |         - |
| Encrypt · ChaCha20-Poly1305 (NaCl.Core)          | 8KB          |    25,738.6 ns |    380.77 ns |    356.18 ns |  18,499 B |      72 B |
| Encrypt · ChaCha20-Poly1305 (CryptoHives-Scalar) | 8KB          |    76,486.6 ns |  1,072.16 ns |  1,002.90 ns |     387 B |         - |
|                                                  |              |                |              |              |           |           |
| Decrypt · ChaCha20-Poly1305 (CryptoHives-AVX2)   | 128KB        |   172,200.4 ns |  2,599.66 ns |  2,431.73 ns |     310 B |         - |
| Decrypt · ChaCha20-Poly1305 (BouncyCastle)       | 128KB        |   195,264.6 ns |  2,336.59 ns |  2,185.65 ns |     310 B |     416 B |
| Decrypt · ChaCha20-Poly1305 (CryptoHives-SSSE3)  | 128KB        |   240,135.0 ns |  3,125.24 ns |  2,923.35 ns |     310 B |         - |
| Decrypt · ChaCha20-Poly1305 (OS)                 | 128KB        |   299,702.5 ns |  4,892.83 ns |  4,576.76 ns |   2,020 B |         - |
| Decrypt · ChaCha20-Poly1305 (NaCl.Core)          | 128KB        |   417,140.4 ns |  4,378.78 ns |  4,095.91 ns |  19,475 B |      72 B |
| Decrypt · ChaCha20-Poly1305 (CryptoHives-Scalar) | 128KB        | 1,219,462.1 ns | 17,519.75 ns | 16,387.99 ns |     310 B |         - |
|                                                  |              |                |              |              |           |           |
| Encrypt · ChaCha20-Poly1305 (CryptoHives-AVX2)   | 128KB        |   170,891.8 ns |  2,806.90 ns |  2,625.57 ns |     387 B |         - |
| Encrypt · ChaCha20-Poly1305 (BouncyCastle)       | 128KB        |   187,920.2 ns |    799.09 ns |    747.47 ns |     387 B |     336 B |
| Encrypt · ChaCha20-Poly1305 (CryptoHives-SSSE3)  | 128KB        |   240,347.6 ns |  2,535.38 ns |  2,371.60 ns |     387 B |         - |
| Encrypt · ChaCha20-Poly1305 (OS)                 | 128KB        |   292,445.7 ns |    596.69 ns |    528.95 ns |   1,921 B |         - |
| Encrypt · ChaCha20-Poly1305 (NaCl.Core)          | 128KB        |   413,464.1 ns |  3,451.91 ns |  3,228.92 ns |  17,255 B |      72 B |
| Encrypt · ChaCha20-Poly1305 (CryptoHives-Scalar) | 128KB        | 1,221,090.7 ns | 11,439.79 ns | 10,700.79 ns |     387 B |         - |