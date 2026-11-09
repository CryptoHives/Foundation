| Description                                       | TestDataSize | Mean           | Error        | StdDev       | Code Size | Allocated |
|-------------------------------------------------- |------------- |---------------:|-------------:|-------------:|----------:|----------:|
| Decrypt · XChaCha20-Poly1305 (CryptoHives-AVX2)   | 128B         |       907.6 ns |     13.64 ns |     12.76 ns |     310 B |         - |
| Decrypt · XChaCha20-Poly1305 (CryptoHives-SSSE3)  | 128B         |       974.3 ns |     17.33 ns |     16.21 ns |     310 B |         - |
| Decrypt · XChaCha20-Poly1305 (NaCl.Core)          | 128B         |     1,316.6 ns |      9.85 ns |      9.21 ns |  18,332 B |      48 B |
| Decrypt · XChaCha20-Poly1305 (CryptoHives-Scalar) | 128B         |     2,424.4 ns |     35.95 ns |     33.63 ns |     310 B |         - |
|                                                   |              |                |              |              |           |           |
| Encrypt · XChaCha20-Poly1305 (CryptoHives-AVX2)   | 128B         |       845.6 ns |     13.53 ns |     12.65 ns |     390 B |         - |
| Encrypt · XChaCha20-Poly1305 (CryptoHives-SSSE3)  | 128B         |       908.2 ns |      7.48 ns |      7.00 ns |     390 B |         - |
| Encrypt · XChaCha20-Poly1305 (NaCl.Core)          | 128B         |     1,240.3 ns |     19.69 ns |     17.45 ns |  17,782 B |      48 B |
| Encrypt · XChaCha20-Poly1305 (CryptoHives-Scalar) | 128B         |     2,361.0 ns |     35.88 ns |     33.56 ns |     390 B |         - |
|                                                   |              |                |              |              |           |           |
| Decrypt · XChaCha20-Poly1305 (CryptoHives-AVX2)   | 1KB          |     2,081.6 ns |     28.81 ns |     26.95 ns |     310 B |         - |
| Decrypt · XChaCha20-Poly1305 (CryptoHives-SSSE3)  | 1KB          |     2,666.2 ns |     35.50 ns |     33.21 ns |     310 B |         - |
| Decrypt · XChaCha20-Poly1305 (NaCl.Core)          | 1KB          |     5,755.5 ns |     68.53 ns |     64.11 ns |  20,500 B |      72 B |
| Decrypt · XChaCha20-Poly1305 (CryptoHives-Scalar) | 1KB          |    10,781.6 ns |     65.00 ns |     60.80 ns |     310 B |         - |
|                                                   |              |                |              |              |           |           |
| Encrypt · XChaCha20-Poly1305 (CryptoHives-AVX2)   | 1KB          |     2,010.4 ns |     34.11 ns |     31.91 ns |     387 B |         - |
| Encrypt · XChaCha20-Poly1305 (CryptoHives-SSSE3)  | 1KB          |     2,589.8 ns |     38.02 ns |     35.57 ns |     390 B |         - |
| Encrypt · XChaCha20-Poly1305 (NaCl.Core)          | 1KB          |     5,676.1 ns |     85.58 ns |     80.05 ns |  18,383 B |      72 B |
| Encrypt · XChaCha20-Poly1305 (CryptoHives-Scalar) | 1KB          |    10,672.8 ns |    141.92 ns |    132.76 ns |     390 B |         - |
|                                                   |              |                |              |              |           |           |
| Decrypt · XChaCha20-Poly1305 (CryptoHives-AVX2)   | 8KB          |    11,451.6 ns |    199.07 ns |    186.21 ns |     310 B |         - |
| Decrypt · XChaCha20-Poly1305 (CryptoHives-SSSE3)  | 8KB          |    15,821.7 ns |    158.94 ns |    148.67 ns |     310 B |         - |
| Decrypt · XChaCha20-Poly1305 (NaCl.Core)          | 8KB          |    40,849.0 ns |    592.93 ns |    554.63 ns |  20,591 B |      72 B |
| Decrypt · XChaCha20-Poly1305 (CryptoHives-Scalar) | 8KB          |    76,866.2 ns |  1,382.52 ns |  1,293.21 ns |     310 B |         - |
|                                                   |              |                |              |              |           |           |
| Encrypt · XChaCha20-Poly1305 (CryptoHives-AVX2)   | 8KB          |    11,439.6 ns |    163.71 ns |    153.13 ns |     387 B |         - |
| Encrypt · XChaCha20-Poly1305 (CryptoHives-SSSE3)  | 8KB          |    15,669.1 ns |    288.43 ns |    269.80 ns |     390 B |         - |
| Encrypt · XChaCha20-Poly1305 (NaCl.Core)          | 8KB          |    40,806.2 ns |    572.12 ns |    535.16 ns |  18,377 B |      72 B |
| Encrypt · XChaCha20-Poly1305 (CryptoHives-Scalar) | 8KB          |    76,666.1 ns |  1,313.82 ns |  1,228.95 ns |     387 B |         - |
|                                                   |              |                |              |              |           |           |
| Decrypt · XChaCha20-Poly1305 (CryptoHives-AVX2)   | 128KB        |   172,097.2 ns |  2,780.50 ns |  2,600.88 ns |     310 B |         - |
| Decrypt · XChaCha20-Poly1305 (CryptoHives-SSSE3)  | 128KB        |   239,930.0 ns |  3,747.31 ns |  3,505.24 ns |     310 B |         - |
| Decrypt · XChaCha20-Poly1305 (NaCl.Core)          | 128KB        |   650,677.1 ns |  9,077.95 ns |  8,491.52 ns |  19,518 B |      72 B |
| Decrypt · XChaCha20-Poly1305 (CryptoHives-Scalar) | 128KB        | 1,221,623.3 ns | 16,361.10 ns | 15,304.18 ns |     310 B |         - |
|                                                   |              |                |              |              |           |           |
| Encrypt · XChaCha20-Poly1305 (CryptoHives-AVX2)   | 128KB        |   172,714.0 ns |  1,222.32 ns |  1,143.36 ns |     387 B |         - |
| Encrypt · XChaCha20-Poly1305 (CryptoHives-SSSE3)  | 128KB        |   240,900.3 ns |  2,761.64 ns |  2,583.24 ns |     387 B |         - |
| Encrypt · XChaCha20-Poly1305 (NaCl.Core)          | 128KB        |   650,510.4 ns |  8,682.34 ns |  8,121.47 ns |  17,267 B |      72 B |
| Encrypt · XChaCha20-Poly1305 (CryptoHives-Scalar) | 128KB        | 1,218,774.8 ns | 16,076.00 ns | 15,037.50 ns |     390 B |         - |