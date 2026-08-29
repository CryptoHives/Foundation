| Description                                      | TestDataSize | Mean           | Error       | StdDev      | Median         | Allocated |
|------------------------------------------------- |------------- |---------------:|------------:|------------:|---------------:|----------:|
| Decrypt · ChaCha20-Poly1305 (CryptoHives-Neon)   | 128B         |       448.7 ns |     1.09 ns |     1.02 ns |       448.8 ns |         - |
| Decrypt · ChaCha20-Poly1305 (BouncyCastle)       | 128B         |       633.4 ns |    11.89 ns |    20.18 ns |       625.3 ns |     416 B |
| Decrypt · ChaCha20-Poly1305 (NaCl.Core)          | 128B         |       890.3 ns |    11.53 ns |    10.22 ns |       886.5 ns |      48 B |
| Decrypt · ChaCha20-Poly1305 (OS)                 | 128B         |     2,316.3 ns |     6.11 ns |     5.10 ns |     2,315.5 ns |         - |
| Decrypt · ChaCha20-Poly1305 (CryptoHives-Scalar) | 128B         |     7,828.2 ns |    11.48 ns |    10.17 ns |     7,828.0 ns |         - |
|                                                  |              |                |             |             |                |           |
| Encrypt · ChaCha20-Poly1305 (BouncyCastle)       | 128B         |       431.6 ns |     8.74 ns |    20.24 ns |       418.0 ns |     336 B |
| Encrypt · ChaCha20-Poly1305 (NaCl.Core)          | 128B         |       793.1 ns |     0.19 ns |     0.18 ns |       793.1 ns |      48 B |
| Encrypt · ChaCha20-Poly1305 (CryptoHives-Neon)   | 128B         |     1,846.4 ns |    10.95 ns |    10.24 ns |     1,849.4 ns |         - |
| Encrypt · ChaCha20-Poly1305 (OS)                 | 128B         |     1,974.6 ns |    20.11 ns |    18.81 ns |     1,969.9 ns |         - |
| Encrypt · ChaCha20-Poly1305 (CryptoHives-Scalar) | 128B         |     7,631.6 ns |     8.59 ns |     7.17 ns |     7,635.0 ns |         - |
|                                                  |              |                |             |             |                |           |
| Decrypt · ChaCha20-Poly1305 (BouncyCastle)       | 1KB          |     2,098.9 ns |     0.82 ns |     0.77 ns |     2,098.6 ns |     416 B |
| Decrypt · ChaCha20-Poly1305 (CryptoHives-Neon)   | 1KB          |     2,158.9 ns |    37.72 ns |    35.29 ns |     2,162.0 ns |         - |
| Decrypt · ChaCha20-Poly1305 (OS)                 | 1KB          |     3,307.6 ns |     8.12 ns |     7.60 ns |     3,305.0 ns |         - |
| Decrypt · ChaCha20-Poly1305 (NaCl.Core)          | 1KB          |     3,713.6 ns |    16.48 ns |    14.61 ns |     3,716.2 ns |      72 B |
| Decrypt · ChaCha20-Poly1305 (CryptoHives-Scalar) | 1KB          |     7,718.3 ns |    26.07 ns |    24.39 ns |     7,728.9 ns |         - |
|                                                  |              |                |             |             |                |           |
| Encrypt · ChaCha20-Poly1305 (BouncyCastle)       | 1KB          |     1,912.8 ns |     0.85 ns |     0.79 ns |     1,912.6 ns |     336 B |
| Encrypt · ChaCha20-Poly1305 (CryptoHives-Neon)   | 1KB          |     1,983.3 ns |    39.34 ns |    71.94 ns |     1,939.7 ns |         - |
| Encrypt · ChaCha20-Poly1305 (OS)                 | 1KB          |     2,958.6 ns |    16.49 ns |    15.42 ns |     2,954.1 ns |         - |
| Encrypt · ChaCha20-Poly1305 (NaCl.Core)          | 1KB          |     3,644.9 ns |     8.32 ns |     7.38 ns |     3,646.6 ns |      72 B |
| Encrypt · ChaCha20-Poly1305 (CryptoHives-Scalar) | 1KB          |     7,690.9 ns |    35.27 ns |    32.99 ns |     7,694.9 ns |         - |
|                                                  |              |                |             |             |                |           |
| Decrypt · ChaCha20-Poly1305 (OS)                 | 8KB          |    11,325.8 ns |    10.16 ns |     9.01 ns |    11,328.2 ns |         - |
| Decrypt · ChaCha20-Poly1305 (BouncyCastle)       | 8KB          |    13,706.6 ns |    11.38 ns |     9.50 ns |    13,706.8 ns |     416 B |
| Decrypt · ChaCha20-Poly1305 (CryptoHives-Neon)   | 8KB          |    14,809.7 ns |    59.89 ns |    53.09 ns |    14,814.7 ns |         - |
| Decrypt · ChaCha20-Poly1305 (NaCl.Core)          | 8KB          |    27,725.6 ns |    84.94 ns |    75.30 ns |    27,739.8 ns |      72 B |
| Decrypt · ChaCha20-Poly1305 (CryptoHives-Scalar) | 8KB          |    58,345.0 ns |    36.64 ns |    32.48 ns |    58,352.3 ns |         - |
|                                                  |              |                |             |             |                |           |
| Encrypt · ChaCha20-Poly1305 (OS)                 | 8KB          |    10,829.6 ns |    19.24 ns |    18.00 ns |    10,835.4 ns |         - |
| Encrypt · ChaCha20-Poly1305 (BouncyCastle)       | 8KB          |    13,680.1 ns |    11.12 ns |    10.40 ns |    13,683.6 ns |     336 B |
| Encrypt · ChaCha20-Poly1305 (CryptoHives-Neon)   | 8KB          |    14,652.0 ns |    62.37 ns |    58.34 ns |    14,647.3 ns |         - |
| Encrypt · ChaCha20-Poly1305 (NaCl.Core)          | 8KB          |    27,305.3 ns |   146.73 ns |   137.26 ns |    27,296.0 ns |      72 B |
| Encrypt · ChaCha20-Poly1305 (CryptoHives-Scalar) | 8KB          |    58,108.8 ns |    66.58 ns |    59.02 ns |    58,124.4 ns |         - |
|                                                  |              |                |             |             |                |           |
| Decrypt · ChaCha20-Poly1305 (BouncyCastle)       | 128KB        |   213,987.0 ns |   324.52 ns |   253.37 ns |   214,016.1 ns |     416 B |
| Decrypt · ChaCha20-Poly1305 (CryptoHives-Neon)   | 128KB        |   240,544.3 ns |   970.56 ns |   860.38 ns |   240,689.4 ns |         - |
| Decrypt · ChaCha20-Poly1305 (OS)                 | 128KB        |   770,464.5 ns | 8,487.37 ns | 7,087.34 ns |   773,249.3 ns |         - |
| Decrypt · ChaCha20-Poly1305 (CryptoHives-Scalar) | 128KB        |   919,383.2 ns |   237.10 ns |   210.18 ns |   919,429.4 ns |         - |
| Decrypt · ChaCha20-Poly1305 (NaCl.Core)          | 128KB        | 2,155,740.4 ns | 1,738.01 ns | 1,540.70 ns | 2,155,424.3 ns |      72 B |
|                                                  |              |                |             |             |                |           |
| Encrypt · ChaCha20-Poly1305 (OS)                 | 128KB        |   146,997.4 ns |    72.49 ns |    64.26 ns |   146,992.5 ns |         - |
| Encrypt · ChaCha20-Poly1305 (BouncyCastle)       | 128KB        |   215,620.5 ns |   154.25 ns |   120.43 ns |   215,638.9 ns |     336 B |
| Encrypt · ChaCha20-Poly1305 (CryptoHives-Neon)   | 128KB        |   239,731.8 ns |   582.95 ns |   516.77 ns |   239,795.3 ns |         - |
| Encrypt · ChaCha20-Poly1305 (NaCl.Core)          | 128KB        |   440,315.6 ns | 1,320.33 ns | 1,235.04 ns |   439,894.7 ns |      72 B |
| Encrypt · ChaCha20-Poly1305 (CryptoHives-Scalar) | 128KB        |   920,473.7 ns |   169.52 ns |   150.27 ns |   920,495.5 ns |         - |