| Description                                       | TestDataSize | Mean         | Error     | StdDev    | Code Size | Allocated |
|-------------------------------------------------- |------------- |-------------:|----------:|----------:|----------:|----------:|
| Decrypt · XChaCha20-Poly1305 (CryptoHives-AVX2)   | 128B         |     613.2 ns |   0.79 ns |   0.66 ns |     306 B |         - |
| Decrypt · XChaCha20-Poly1305 (CryptoHives-SSSE3)  | 128B         |     684.6 ns |   1.80 ns |   1.68 ns |     306 B |         - |
| Decrypt · XChaCha20-Poly1305 (NaCl.Core)          | 128B         |   1,115.7 ns |   0.83 ns |   0.69 ns |  19,274 B |      48 B |
| Decrypt · XChaCha20-Poly1305 (CryptoHives-Scalar) | 128B         |   1,280.3 ns |   1.77 ns |   1.57 ns |     306 B |         - |
|                                                   |              |              |           |           |           |           |
| Encrypt · XChaCha20-Poly1305 (CryptoHives-AVX2)   | 128B         |     558.2 ns |   0.63 ns |   0.53 ns |     383 B |         - |
| Encrypt · XChaCha20-Poly1305 (CryptoHives-SSSE3)  | 128B         |     628.5 ns |   1.94 ns |   1.81 ns |     383 B |         - |
| Encrypt · XChaCha20-Poly1305 (NaCl.Core)          | 128B         |   1,085.5 ns |   1.23 ns |   1.15 ns |  17,746 B |      48 B |
| Encrypt · XChaCha20-Poly1305 (CryptoHives-Scalar) | 128B         |   1,214.8 ns |   1.37 ns |   1.15 ns |     386 B |         - |
|                                                   |              |              |           |           |           |           |
| Decrypt · XChaCha20-Poly1305 (CryptoHives-AVX2)   | 1KB          |   1,596.4 ns |   1.82 ns |   1.61 ns |     306 B |         - |
| Decrypt · XChaCha20-Poly1305 (CryptoHives-SSSE3)  | 1KB          |   2,141.3 ns |  14.95 ns |  13.25 ns |     306 B |         - |
| Decrypt · XChaCha20-Poly1305 (NaCl.Core)          | 1KB          |   4,948.9 ns |   8.58 ns |   8.02 ns |  20,606 B |      72 B |
| Decrypt · XChaCha20-Poly1305 (CryptoHives-Scalar) | 1KB          |   5,433.9 ns |   4.76 ns |   3.97 ns |     306 B |         - |
|                                                   |              |              |           |           |           |           |
| Encrypt · XChaCha20-Poly1305 (CryptoHives-AVX2)   | 1KB          |   1,548.3 ns |   2.16 ns |   2.02 ns |     386 B |         - |
| Encrypt · XChaCha20-Poly1305 (CryptoHives-SSSE3)  | 1KB          |   2,078.6 ns |   2.16 ns |   1.92 ns |     386 B |         - |
| Encrypt · XChaCha20-Poly1305 (NaCl.Core)          | 1KB          |   4,878.4 ns |   5.73 ns |   5.08 ns |  18,322 B |      72 B |
| Encrypt · XChaCha20-Poly1305 (CryptoHives-Scalar) | 1KB          |   5,407.9 ns |   7.03 ns |   6.58 ns |     386 B |         - |
|                                                   |              |              |           |           |           |           |
| Decrypt · XChaCha20-Poly1305 (CryptoHives-AVX2)   | 8KB          |   9,456.7 ns |  17.49 ns |  16.36 ns |     306 B |         - |
| Decrypt · XChaCha20-Poly1305 (CryptoHives-SSSE3)  | 8KB          |  13,714.4 ns |  11.16 ns |   8.71 ns |     306 B |         - |
| Decrypt · XChaCha20-Poly1305 (NaCl.Core)          | 8KB          |  35,462.4 ns |  57.85 ns |  54.11 ns |  20,666 B |      72 B |
| Decrypt · XChaCha20-Poly1305 (CryptoHives-Scalar) | 8KB          |  38,720.1 ns |  52.74 ns |  49.34 ns |     306 B |         - |
|                                                   |              |              |           |           |           |           |
| Encrypt · XChaCha20-Poly1305 (CryptoHives-AVX2)   | 8KB          |   9,387.4 ns |  10.43 ns |   9.25 ns |     383 B |         - |
| Encrypt · XChaCha20-Poly1305 (CryptoHives-SSSE3)  | 8KB          |  13,646.2 ns |   8.99 ns |   7.51 ns |     383 B |         - |
| Encrypt · XChaCha20-Poly1305 (NaCl.Core)          | 8KB          |  35,409.2 ns |  42.13 ns |  39.41 ns |  18,374 B |      72 B |
| Encrypt · XChaCha20-Poly1305 (CryptoHives-Scalar) | 8KB          |  38,793.7 ns |  49.26 ns |  43.66 ns |     383 B |         - |
|                                                   |              |              |           |           |           |           |
| Decrypt · XChaCha20-Poly1305 (CryptoHives-AVX2)   | 128KB        | 143,585.7 ns | 135.60 ns | 126.84 ns |     306 B |         - |
| Decrypt · XChaCha20-Poly1305 (CryptoHives-SSSE3)  | 128KB        | 213,059.8 ns | 171.57 ns | 152.09 ns |     306 B |         - |
| Decrypt · XChaCha20-Poly1305 (NaCl.Core)          | 128KB        | 558,548.4 ns | 592.58 ns | 525.31 ns |  19,518 B |      72 B |
| Decrypt · XChaCha20-Poly1305 (CryptoHives-Scalar) | 128KB        | 607,456.0 ns | 821.35 ns | 728.11 ns |     306 B |         - |
|                                                   |              |              |           |           |           |           |
| Encrypt · XChaCha20-Poly1305 (CryptoHives-AVX2)   | 128KB        | 143,702.2 ns | 105.76 ns |  93.75 ns |     383 B |         - |
| Encrypt · XChaCha20-Poly1305 (CryptoHives-SSSE3)  | 128KB        | 212,007.4 ns |  76.84 ns |  64.17 ns |     383 B |         - |
| Encrypt · XChaCha20-Poly1305 (CryptoHives-Scalar) | 128KB        | 607,602.6 ns | 911.81 ns | 808.30 ns |     383 B |         - |
| Encrypt · XChaCha20-Poly1305 (NaCl.Core)          | 128KB        | 616,760.4 ns | 599.42 ns | 560.70 ns |  17,197 B |      72 B |