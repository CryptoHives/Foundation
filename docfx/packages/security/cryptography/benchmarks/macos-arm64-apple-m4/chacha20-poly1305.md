| Description                                      | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|------------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|
| Decrypt · ChaCha20-Poly1305 (CryptoHives-Neon)   | 128B         |     416.4 ns |     1.51 ns |     1.41 ns |         - |
| Decrypt · ChaCha20-Poly1305 (BouncyCastle)       | 128B         |     695.1 ns |     1.59 ns |     1.49 ns |     416 B |
| Decrypt · ChaCha20-Poly1305 (NaCl.Core)          | 128B         |     826.0 ns |     3.22 ns |     3.01 ns |      48 B |
| Decrypt · ChaCha20-Poly1305 (CryptoHives-Scalar) | 128B         |   1,361.1 ns |    18.77 ns |    17.56 ns |         - |
| Decrypt · ChaCha20-Poly1305 (OS)                 | 128B         |   2,293.3 ns |    12.33 ns |    11.53 ns |         - |
|                                                  |              |              |             |             |           |
| Encrypt · ChaCha20-Poly1305 (CryptoHives-Neon)   | 128B         |     354.9 ns |     0.93 ns |     0.82 ns |         - |
| Encrypt · ChaCha20-Poly1305 (BouncyCastle)       | 128B         |     498.5 ns |     0.41 ns |     0.35 ns |     336 B |
| Encrypt · ChaCha20-Poly1305 (NaCl.Core)          | 128B         |     791.8 ns |     0.56 ns |     0.52 ns |      48 B |
| Encrypt · ChaCha20-Poly1305 (CryptoHives-Scalar) | 128B         |   1,346.5 ns |     5.66 ns |     5.30 ns |         - |
| Encrypt · ChaCha20-Poly1305 (OS)                 | 128B         |   1,978.4 ns |     4.84 ns |     4.04 ns |         - |
|                                                  |              |              |             |             |           |
| Decrypt · ChaCha20-Poly1305 (CryptoHives-Neon)   | 1KB          |   2,006.7 ns |     4.96 ns |     4.39 ns |         - |
| Decrypt · ChaCha20-Poly1305 (BouncyCastle)       | 1KB          |   2,410.7 ns |     2.28 ns |     2.13 ns |     416 B |
| Decrypt · ChaCha20-Poly1305 (OS)                 | 1KB          |   3,253.4 ns |    16.95 ns |    15.86 ns |         - |
| Decrypt · ChaCha20-Poly1305 (NaCl.Core)          | 1KB          |   3,676.4 ns |     5.41 ns |     5.06 ns |      72 B |
| Decrypt · ChaCha20-Poly1305 (CryptoHives-Scalar) | 1KB          |   6,902.8 ns |    20.10 ns |    18.80 ns |         - |
|                                                  |              |              |             |             |           |
| Encrypt · ChaCha20-Poly1305 (CryptoHives-Neon)   | 1KB          |   1,940.8 ns |     4.20 ns |     3.73 ns |         - |
| Encrypt · ChaCha20-Poly1305 (BouncyCastle)       | 1KB          |   2,211.3 ns |     1.42 ns |     1.26 ns |     336 B |
| Encrypt · ChaCha20-Poly1305 (OS)                 | 1KB          |   2,913.0 ns |    13.28 ns |    12.42 ns |         - |
| Encrypt · ChaCha20-Poly1305 (NaCl.Core)          | 1KB          |   3,629.1 ns |     1.37 ns |     1.22 ns |      72 B |
| Encrypt · ChaCha20-Poly1305 (CryptoHives-Scalar) | 1KB          |   6,864.7 ns |    13.85 ns |    12.96 ns |         - |
|                                                  |              |              |             |             |           |
| Decrypt · ChaCha20-Poly1305 (OS)                 | 8KB          |  10,902.5 ns |    41.51 ns |    38.82 ns |         - |
| Decrypt · ChaCha20-Poly1305 (CryptoHives-Neon)   | 8KB          |  14,535.6 ns |     9.43 ns |     8.36 ns |         - |
| Decrypt · ChaCha20-Poly1305 (BouncyCastle)       | 8KB          |  15,876.2 ns |    12.97 ns |    10.83 ns |     416 B |
| Decrypt · ChaCha20-Poly1305 (NaCl.Core)          | 8KB          |  26,306.3 ns |    14.49 ns |    12.10 ns |      72 B |
| Decrypt · ChaCha20-Poly1305 (CryptoHives-Scalar) | 8KB          |  49,612.1 ns |   158.03 ns |   147.83 ns |         - |
|                                                  |              |              |             |             |           |
| Encrypt · ChaCha20-Poly1305 (OS)                 | 8KB          |  10,391.7 ns |    60.62 ns |    56.70 ns |         - |
| Encrypt · ChaCha20-Poly1305 (CryptoHives-Neon)   | 8KB          |  14,470.9 ns |     5.98 ns |     5.59 ns |         - |
| Encrypt · ChaCha20-Poly1305 (BouncyCastle)       | 8KB          |  15,753.4 ns |     9.06 ns |     8.47 ns |     336 B |
| Encrypt · ChaCha20-Poly1305 (NaCl.Core)          | 8KB          |  26,241.8 ns |     6.90 ns |     6.12 ns |      72 B |
| Encrypt · ChaCha20-Poly1305 (CryptoHives-Scalar) | 8KB          |  49,627.3 ns |   105.83 ns |    98.99 ns |         - |
|                                                  |              |              |             |             |           |
| Decrypt · ChaCha20-Poly1305 (OS)                 | 128KB        | 150,325.2 ns |   611.41 ns |   571.91 ns |         - |
| Decrypt · ChaCha20-Poly1305 (CryptoHives-Neon)   | 128KB        | 228,442.7 ns |   504.39 ns |   471.81 ns |         - |
| Decrypt · ChaCha20-Poly1305 (BouncyCastle)       | 128KB        | 248,892.6 ns |   170.05 ns |   159.07 ns |     416 B |
| Decrypt · ChaCha20-Poly1305 (NaCl.Core)          | 128KB        | 422,416.7 ns |   421.49 ns |   373.64 ns |      72 B |
| Decrypt · ChaCha20-Poly1305 (CryptoHives-Scalar) | 128KB        | 783,090.5 ns | 2,470.46 ns | 2,310.87 ns |         - |
|                                                  |              |              |             |             |           |
| Encrypt · ChaCha20-Poly1305 (OS)                 | 128KB        | 140,386.8 ns |   716.27 ns |   669.99 ns |         - |
| Encrypt · ChaCha20-Poly1305 (CryptoHives-Neon)   | 128KB        | 228,966.8 ns |    93.92 ns |    83.26 ns |         - |
| Encrypt · ChaCha20-Poly1305 (BouncyCastle)       | 128KB        | 250,398.7 ns |   441.82 ns |   413.28 ns |     336 B |
| Encrypt · ChaCha20-Poly1305 (NaCl.Core)          | 128KB        | 415,249.9 ns |   395.86 ns |   370.29 ns |      72 B |
| Encrypt · ChaCha20-Poly1305 (CryptoHives-Scalar) | 128KB        | 783,435.5 ns | 2,575.63 ns | 2,409.25 ns |         - |