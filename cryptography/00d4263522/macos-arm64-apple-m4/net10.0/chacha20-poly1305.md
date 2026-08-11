| Description                                      | TestDataSize | Mean         | Error        | StdDev       | Allocated |
|------------------------------------------------- |------------- |-------------:|-------------:|-------------:|----------:|
| Decrypt · ChaCha20-Poly1305 (CryptoHives-Neon)   | 128B         |     434.3 ns |      4.15 ns |      3.88 ns |         - |
| Decrypt · ChaCha20-Poly1305 (BouncyCastle)       | 128B         |     636.7 ns |     11.38 ns |     10.64 ns |     416 B |
| Decrypt · ChaCha20-Poly1305 (NaCl.Core)          | 128B         |     860.3 ns |      9.44 ns |      8.83 ns |      48 B |
| Decrypt · ChaCha20-Poly1305 (CryptoHives-Scalar) | 128B         |   1,415.8 ns |     23.27 ns |     21.77 ns |         - |
| Decrypt · ChaCha20-Poly1305 (OS)                 | 128B         |   2,360.9 ns |     42.84 ns |     40.07 ns |         - |
|                                                  |              |              |              |              |           |
| Encrypt · ChaCha20-Poly1305 (CryptoHives-Neon)   | 128B         |     362.5 ns |      5.59 ns |      5.23 ns |         - |
| Encrypt · ChaCha20-Poly1305 (BouncyCastle)       | 128B         |     430.7 ns |      6.08 ns |      5.69 ns |     336 B |
| Encrypt · ChaCha20-Poly1305 (NaCl.Core)          | 128B         |     822.9 ns |     10.59 ns |      9.91 ns |      48 B |
| Encrypt · ChaCha20-Poly1305 (CryptoHives-Scalar) | 128B         |   1,393.6 ns |     23.22 ns |     21.72 ns |         - |
| Encrypt · ChaCha20-Poly1305 (OS)                 | 128B         |   2,024.2 ns |     15.34 ns |     11.98 ns |         - |
|                                                  |              |              |              |              |           |
| Decrypt · ChaCha20-Poly1305 (CryptoHives-Neon)   | 1KB          |   2,038.0 ns |     16.24 ns |     12.68 ns |         - |
| Decrypt · ChaCha20-Poly1305 (BouncyCastle)       | 1KB          |   2,105.2 ns |      0.81 ns |      0.67 ns |     416 B |
| Decrypt · ChaCha20-Poly1305 (OS)                 | 1KB          |   3,321.5 ns |     41.40 ns |     38.73 ns |         - |
| Decrypt · ChaCha20-Poly1305 (NaCl.Core)          | 1KB          |   3,781.0 ns |     28.26 ns |     23.60 ns |      72 B |
| Decrypt · ChaCha20-Poly1305 (CryptoHives-Scalar) | 1KB          |   7,129.6 ns |     99.46 ns |     93.04 ns |         - |
|                                                  |              |              |              |              |           |
| Encrypt · ChaCha20-Poly1305 (BouncyCastle)       | 1KB          |   1,912.3 ns |      3.73 ns |      2.92 ns |     336 B |
| Encrypt · ChaCha20-Poly1305 (CryptoHives-Neon)   | 1KB          |   1,971.7 ns |     15.77 ns |     12.31 ns |         - |
| Encrypt · ChaCha20-Poly1305 (OS)                 | 1KB          |   2,997.7 ns |     37.46 ns |     35.04 ns |         - |
| Encrypt · ChaCha20-Poly1305 (NaCl.Core)          | 1KB          |   3,760.4 ns |     38.03 ns |     35.58 ns |      72 B |
| Encrypt · ChaCha20-Poly1305 (CryptoHives-Scalar) | 1KB          |   7,094.2 ns |     96.28 ns |     90.06 ns |         - |
|                                                  |              |              |              |              |           |
| Decrypt · ChaCha20-Poly1305 (OS)                 | 8KB          |  11,286.2 ns |    133.34 ns |    124.72 ns |         - |
| Decrypt · ChaCha20-Poly1305 (BouncyCastle)       | 8KB          |  13,884.9 ns |    183.77 ns |    171.89 ns |     416 B |
| Decrypt · ChaCha20-Poly1305 (CryptoHives-Neon)   | 8KB          |  14,752.2 ns |    111.46 ns |     87.02 ns |         - |
| Decrypt · ChaCha20-Poly1305 (NaCl.Core)          | 8KB          |  27,157.4 ns |    291.75 ns |    272.90 ns |      72 B |
| Decrypt · ChaCha20-Poly1305 (CryptoHives-Scalar) | 8KB          |  51,322.1 ns |    833.37 ns |    779.54 ns |         - |
|                                                  |              |              |              |              |           |
| Encrypt · ChaCha20-Poly1305 (OS)                 | 8KB          |  10,768.0 ns |    133.40 ns |    124.78 ns |         - |
| Encrypt · ChaCha20-Poly1305 (BouncyCastle)       | 8KB          |  13,823.9 ns |    181.19 ns |    169.48 ns |     336 B |
| Encrypt · ChaCha20-Poly1305 (CryptoHives-Neon)   | 8KB          |  14,835.4 ns |    175.37 ns |    164.04 ns |         - |
| Encrypt · ChaCha20-Poly1305 (NaCl.Core)          | 8KB          |  27,062.0 ns |    334.37 ns |    312.77 ns |      72 B |
| Encrypt · ChaCha20-Poly1305 (CryptoHives-Scalar) | 8KB          |  51,160.4 ns |    757.77 ns |    708.82 ns |         - |
|                                                  |              |              |              |              |           |
| Decrypt · ChaCha20-Poly1305 (OS)                 | 128KB        | 156,916.0 ns |  3,029.67 ns |  3,367.47 ns |         - |
| Decrypt · ChaCha20-Poly1305 (BouncyCastle)       | 128KB        | 215,589.3 ns |  2,645.88 ns |  2,474.96 ns |     416 B |
| Decrypt · ChaCha20-Poly1305 (CryptoHives-Neon)   | 128KB        | 235,196.1 ns |  2,744.87 ns |  2,567.56 ns |         - |
| Decrypt · ChaCha20-Poly1305 (NaCl.Core)          | 128KB        | 426,892.8 ns |  4,955.21 ns |  4,635.10 ns |      72 B |
| Decrypt · ChaCha20-Poly1305 (CryptoHives-Scalar) | 128KB        | 806,781.0 ns | 14,673.20 ns | 13,725.32 ns |         - |
|                                                  |              |              |              |              |           |
| Encrypt · ChaCha20-Poly1305 (OS)                 | 128KB        | 144,535.5 ns |    793.51 ns |    619.52 ns |         - |
| Encrypt · ChaCha20-Poly1305 (BouncyCastle)       | 128KB        | 218,717.1 ns |  2,469.24 ns |  2,309.72 ns |     336 B |
| Encrypt · ChaCha20-Poly1305 (CryptoHives-Neon)   | 128KB        | 235,101.9 ns |  2,955.55 ns |  2,764.62 ns |         - |
| Encrypt · ChaCha20-Poly1305 (NaCl.Core)          | 128KB        | 425,603.0 ns |  5,281.87 ns |  4,940.66 ns |      72 B |
| Encrypt · ChaCha20-Poly1305 (CryptoHives-Scalar) | 128KB        | 807,301.3 ns | 12,956.96 ns | 12,119.94 ns |         - |