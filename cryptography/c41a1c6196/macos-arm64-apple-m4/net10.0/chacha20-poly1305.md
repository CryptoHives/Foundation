| Description                                      | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|------------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|
| Decrypt · ChaCha20-Poly1305 (CryptoHives-Neon)   | 128B         |     468.3 ns |     0.37 ns |     0.35 ns |         - |
| Decrypt · ChaCha20-Poly1305 (BouncyCastle)       | 128B         |     629.9 ns |     2.39 ns |     2.23 ns |     416 B |
| Decrypt · ChaCha20-Poly1305 (NaCl.Core)          | 128B         |     836.8 ns |     1.93 ns |     1.81 ns |      48 B |
| Decrypt · ChaCha20-Poly1305 (CryptoHives-Scalar) | 128B         |   1,426.9 ns |     2.84 ns |     2.52 ns |         - |
| Decrypt · ChaCha20-Poly1305 (OS)                 | 128B         |   2,245.9 ns |    10.85 ns |    10.15 ns |         - |
|                                                  |              |              |             |             |           |
| Encrypt · ChaCha20-Poly1305 (CryptoHives-Neon)   | 128B         |     353.1 ns |     0.73 ns |     0.68 ns |         - |
| Encrypt · ChaCha20-Poly1305 (BouncyCastle)       | 128B         |     427.7 ns |     0.99 ns |     0.93 ns |     336 B |
| Encrypt · ChaCha20-Poly1305 (NaCl.Core)          | 128B         |     803.3 ns |     0.72 ns |     0.64 ns |      48 B |
| Encrypt · ChaCha20-Poly1305 (CryptoHives-Scalar) | 128B         |   1,385.5 ns |     3.71 ns |     3.47 ns |         - |
| Encrypt · ChaCha20-Poly1305 (OS)                 | 128B         |   1,957.5 ns |    12.99 ns |    12.15 ns |         - |
|                                                  |              |              |             |             |           |
| Decrypt · ChaCha20-Poly1305 (CryptoHives-Neon)   | 1KB          |   2,027.2 ns |     2.67 ns |     2.50 ns |         - |
| Decrypt · ChaCha20-Poly1305 (BouncyCastle)       | 1KB          |   2,106.1 ns |     9.21 ns |     8.62 ns |     416 B |
| Decrypt · ChaCha20-Poly1305 (OS)                 | 1KB          |   3,195.8 ns |     5.76 ns |     5.11 ns |         - |
| Decrypt · ChaCha20-Poly1305 (NaCl.Core)          | 1KB          |   3,715.6 ns |     4.78 ns |     4.47 ns |      72 B |
| Decrypt · ChaCha20-Poly1305 (CryptoHives-Scalar) | 1KB          |   7,563.6 ns |    24.21 ns |    22.64 ns |         - |
|                                                  |              |              |             |             |           |
| Encrypt · ChaCha20-Poly1305 (BouncyCastle)       | 1KB          |   1,906.1 ns |     6.46 ns |     6.04 ns |     336 B |
| Encrypt · ChaCha20-Poly1305 (CryptoHives-Neon)   | 1KB          |   1,911.5 ns |     5.45 ns |     5.10 ns |         - |
| Encrypt · ChaCha20-Poly1305 (OS)                 | 1KB          |   2,856.7 ns |     8.94 ns |     7.92 ns |         - |
| Encrypt · ChaCha20-Poly1305 (NaCl.Core)          | 1KB          |   3,670.8 ns |     2.38 ns |     2.22 ns |      72 B |
| Encrypt · ChaCha20-Poly1305 (CryptoHives-Scalar) | 1KB          |   7,503.7 ns |    16.43 ns |    15.37 ns |         - |
|                                                  |              |              |             |             |           |
| Decrypt · ChaCha20-Poly1305 (OS)                 | 8KB          |  10,702.2 ns |    32.80 ns |    30.68 ns |         - |
| Decrypt · ChaCha20-Poly1305 (BouncyCastle)       | 8KB          |  13,734.5 ns |    30.79 ns |    28.80 ns |     416 B |
| Decrypt · ChaCha20-Poly1305 (CryptoHives-Neon)   | 8KB          |  14,516.1 ns |     8.86 ns |     8.29 ns |         - |
| Decrypt · ChaCha20-Poly1305 (NaCl.Core)          | 8KB          |  26,556.1 ns |    36.18 ns |    33.84 ns |      72 B |
| Decrypt · ChaCha20-Poly1305 (CryptoHives-Scalar) | 8KB          |  56,414.0 ns |   120.16 ns |   112.40 ns |         - |
|                                                  |              |              |             |             |           |
| Encrypt · ChaCha20-Poly1305 (OS)                 | 8KB          |  10,200.9 ns |    27.30 ns |    25.53 ns |         - |
| Encrypt · ChaCha20-Poly1305 (BouncyCastle)       | 8KB          |  13,676.8 ns |    35.71 ns |    33.41 ns |     336 B |
| Encrypt · ChaCha20-Poly1305 (CryptoHives-Neon)   | 8KB          |  14,404.1 ns |     9.93 ns |     8.80 ns |         - |
| Encrypt · ChaCha20-Poly1305 (NaCl.Core)          | 8KB          |  26,549.0 ns |    18.10 ns |    16.93 ns |      72 B |
| Encrypt · ChaCha20-Poly1305 (CryptoHives-Scalar) | 8KB          |  56,332.4 ns |   143.67 ns |   134.39 ns |         - |
|                                                  |              |              |             |             |           |
| Decrypt · ChaCha20-Poly1305 (OS)                 | 128KB        | 148,723.0 ns |   626.75 ns |   586.26 ns |         - |
| Decrypt · ChaCha20-Poly1305 (BouncyCastle)       | 128KB        | 213,633.3 ns |   642.03 ns |   600.56 ns |     416 B |
| Decrypt · ChaCha20-Poly1305 (CryptoHives-Neon)   | 128KB        | 227,464.2 ns |   317.27 ns |   296.77 ns |         - |
| Decrypt · ChaCha20-Poly1305 (NaCl.Core)          | 128KB        | 419,449.8 ns |   365.87 ns |   342.23 ns |      72 B |
| Decrypt · ChaCha20-Poly1305 (CryptoHives-Scalar) | 128KB        | 893,719.3 ns | 1,926.02 ns | 1,801.60 ns |         - |
|                                                  |              |              |             |             |           |
| Encrypt · ChaCha20-Poly1305 (OS)                 | 128KB        | 137,855.0 ns |   775.64 ns |   725.53 ns |         - |
| Encrypt · ChaCha20-Poly1305 (BouncyCastle)       | 128KB        | 216,110.3 ns |   595.97 ns |   557.47 ns |     336 B |
| Encrypt · ChaCha20-Poly1305 (CryptoHives-Neon)   | 128KB        | 228,076.1 ns |   127.26 ns |   112.81 ns |         - |
| Encrypt · ChaCha20-Poly1305 (NaCl.Core)          | 128KB        | 418,859.3 ns |   235.47 ns |   220.25 ns |      72 B |
| Encrypt · ChaCha20-Poly1305 (CryptoHives-Scalar) | 128KB        | 892,714.9 ns | 2,051.91 ns | 1,919.36 ns |         - |