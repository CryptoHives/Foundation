| Description                             | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|---------------------------------------- |------------- |-------------:|------------:|------------:|----------:|
| Decrypt · ChaCha20 (CryptoHives-Neon)   | 128B         |     169.8 ns |     0.07 ns |     0.06 ns |         - |
| Decrypt · ChaCha20 (BouncyCastle)       | 128B         |     304.8 ns |     3.22 ns |     3.02 ns |      96 B |
| Decrypt · ChaCha20 (NaCl.Core)          | 128B         |     521.1 ns |     0.09 ns |     0.08 ns |      24 B |
| Decrypt · ChaCha20 (CryptoHives-Scalar) | 128B         |     708.6 ns |     2.10 ns |     1.96 ns |         - |
|                                         |              |              |             |             |           |
| Encrypt · ChaCha20 (CryptoHives-Neon)   | 128B         |     169.7 ns |     0.12 ns |     0.10 ns |         - |
| Encrypt · ChaCha20 (BouncyCastle)       | 128B         |     303.9 ns |     4.41 ns |     4.12 ns |      96 B |
| Encrypt · ChaCha20 (NaCl.Core)          | 128B         |     521.1 ns |     0.20 ns |     0.15 ns |      24 B |
| Encrypt · ChaCha20 (CryptoHives-Scalar) | 128B         |     708.5 ns |     2.08 ns |     1.94 ns |         - |
|                                         |              |              |             |             |           |
| Decrypt · ChaCha20 (CryptoHives-Neon)   | 1KB          |   1,337.1 ns |     0.40 ns |     0.36 ns |         - |
| Decrypt · ChaCha20 (BouncyCastle)       | 1KB          |   1,826.0 ns |    34.56 ns |    32.32 ns |      96 B |
| Decrypt · ChaCha20 (NaCl.Core)          | 1KB          |   2,935.9 ns |     0.72 ns |     0.64 ns |      24 B |
| Decrypt · ChaCha20 (CryptoHives-Scalar) | 1KB          |   5,593.2 ns |    15.50 ns |    14.50 ns |         - |
|                                         |              |              |             |             |           |
| Encrypt · ChaCha20 (CryptoHives-Neon)   | 1KB          |   1,337.3 ns |     0.73 ns |     0.61 ns |         - |
| Encrypt · ChaCha20 (BouncyCastle)       | 1KB          |   1,890.4 ns |    35.29 ns |    37.76 ns |      96 B |
| Encrypt · ChaCha20 (NaCl.Core)          | 1KB          |   2,935.8 ns |     1.13 ns |     1.00 ns |      24 B |
| Encrypt · ChaCha20 (CryptoHives-Scalar) | 1KB          |   5,603.2 ns |    12.97 ns |    12.13 ns |         - |
|                                         |              |              |             |             |           |
| Decrypt · ChaCha20 (CryptoHives-Neon)   | 8KB          |  10,672.4 ns |     7.30 ns |     6.47 ns |         - |
| Decrypt · ChaCha20 (BouncyCastle)       | 8KB          |  13,612.7 ns |   208.54 ns |   195.07 ns |      96 B |
| Decrypt · ChaCha20 (NaCl.Core)          | 8KB          |  22,290.6 ns |    23.55 ns |    22.03 ns |      24 B |
| Decrypt · ChaCha20 (CryptoHives-Scalar) | 8KB          |  44,682.0 ns |   146.71 ns |   137.23 ns |         - |
|                                         |              |              |             |             |           |
| Encrypt · ChaCha20 (CryptoHives-Neon)   | 8KB          |  10,673.6 ns |     7.05 ns |     5.89 ns |         - |
| Encrypt · ChaCha20 (BouncyCastle)       | 8KB          |  13,594.4 ns |   187.00 ns |   174.92 ns |      96 B |
| Encrypt · ChaCha20 (NaCl.Core)          | 8KB          |  22,278.1 ns |    28.81 ns |    26.95 ns |      24 B |
| Encrypt · ChaCha20 (CryptoHives-Scalar) | 8KB          |  44,701.9 ns |   120.88 ns |   100.94 ns |         - |
|                                         |              |              |             |             |           |
| Decrypt · ChaCha20 (CryptoHives-Neon)   | 128KB        | 170,647.8 ns |    58.97 ns |    52.28 ns |         - |
| Decrypt · ChaCha20 (BouncyCastle)       | 128KB        | 213,044.1 ns |   156.11 ns |   146.03 ns |      96 B |
| Decrypt · ChaCha20 (NaCl.Core)          | 128KB        | 353,484.2 ns |    53.85 ns |    47.73 ns |      24 B |
| Decrypt · ChaCha20 (CryptoHives-Scalar) | 128KB        | 715,376.1 ns | 1,205.07 ns | 1,068.26 ns |         - |
|                                         |              |              |             |             |           |
| Encrypt · ChaCha20 (CryptoHives-Neon)   | 128KB        | 170,542.3 ns |    70.32 ns |    54.90 ns |         - |
| Encrypt · ChaCha20 (BouncyCastle)       | 128KB        | 212,602.1 ns |   148.61 ns |   124.10 ns |      96 B |
| Encrypt · ChaCha20 (NaCl.Core)          | 128KB        | 353,402.2 ns |   145.97 ns |   121.89 ns |      24 B |
| Encrypt · ChaCha20 (CryptoHives-Scalar) | 128KB        | 715,358.5 ns | 1,416.82 ns | 1,183.10 ns |         - |