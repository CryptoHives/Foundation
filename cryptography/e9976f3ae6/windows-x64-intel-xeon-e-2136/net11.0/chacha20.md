| Description                             | TestDataSize | Mean           | Error       | StdDev      | Code Size | Allocated |
|---------------------------------------- |------------- |---------------:|------------:|------------:|----------:|----------:|
| Decrypt · ChaCha20 (CryptoHives-AVX2)   | 128B         |       119.0 ns |     0.11 ns |     0.10 ns |   2,840 B |         - |
| Decrypt · ChaCha20 (CryptoHives-SSSE3)  | 128B         |       202.3 ns |     0.09 ns |     0.09 ns |   2,654 B |         - |
| Decrypt · ChaCha20 (NaCl.Core)          | 128B         |       501.3 ns |     2.31 ns |     2.04 ns |  18,353 B |      24 B |
| Decrypt · ChaCha20 (BouncyCastle)       | 128B         |       659.3 ns |     2.19 ns |     1.94 ns |     757 B |      96 B |
| Decrypt · ChaCha20 (CryptoHives-Scalar) | 128B         |     1,460.9 ns |     5.37 ns |     5.02 ns |  12,651 B |         - |
|                                         |              |                |             |             |           |           |
| Encrypt · ChaCha20 (CryptoHives-AVX2)   | 128B         |       119.0 ns |     0.19 ns |     0.18 ns |   2,840 B |         - |
| Encrypt · ChaCha20 (CryptoHives-SSSE3)  | 128B         |       204.2 ns |     0.06 ns |     0.06 ns |   2,654 B |         - |
| Encrypt · ChaCha20 (NaCl.Core)          | 128B         |       501.9 ns |     1.43 ns |     1.19 ns |  18,353 B |      24 B |
| Encrypt · ChaCha20 (BouncyCastle)       | 128B         |       659.8 ns |     3.63 ns |     3.22 ns |     757 B |      96 B |
| Encrypt · ChaCha20 (CryptoHives-Scalar) | 128B         |     1,461.0 ns |     5.22 ns |     4.88 ns |   6,502 B |         - |
|                                         |              |                |             |             |           |           |
| Decrypt · ChaCha20 (CryptoHives-AVX2)   | 1KB          |       777.4 ns |     0.24 ns |     0.23 ns |   2,840 B |         - |
| Decrypt · ChaCha20 (CryptoHives-SSSE3)  | 1KB          |     1,469.6 ns |     0.51 ns |     0.48 ns |   2,654 B |         - |
| Decrypt · ChaCha20 (NaCl.Core)          | 1KB          |     2,676.2 ns |     6.14 ns |     5.44 ns |  11,587 B |      24 B |
| Decrypt · ChaCha20 (BouncyCastle)       | 1KB          |     4,918.3 ns |     3.32 ns |     2.77 ns |     757 B |      96 B |
| Decrypt · ChaCha20 (CryptoHives-Scalar) | 1KB          |    11,425.0 ns |    35.99 ns |    33.66 ns |  12,651 B |         - |
|                                         |              |                |             |             |           |           |
| Encrypt · ChaCha20 (CryptoHives-AVX2)   | 1KB          |       782.7 ns |     0.40 ns |     0.36 ns |   2,840 B |         - |
| Encrypt · ChaCha20 (CryptoHives-SSSE3)  | 1KB          |     1,468.8 ns |     0.51 ns |     0.48 ns |   2,654 B |         - |
| Encrypt · ChaCha20 (NaCl.Core)          | 1KB          |     2,706.6 ns |     2.29 ns |     1.91 ns |  11,578 B |      24 B |
| Encrypt · ChaCha20 (BouncyCastle)       | 1KB          |     4,961.9 ns |    14.73 ns |    12.30 ns |     757 B |      96 B |
| Encrypt · ChaCha20 (CryptoHives-Scalar) | 1KB          |    11,449.6 ns |    38.72 ns |    36.22 ns |  12,651 B |         - |
|                                         |              |                |             |             |           |           |
| Decrypt · ChaCha20 (CryptoHives-AVX2)   | 8KB          |     6,055.2 ns |     1.18 ns |     1.05 ns |   2,840 B |         - |
| Decrypt · ChaCha20 (CryptoHives-SSSE3)  | 8KB          |    11,619.4 ns |     6.92 ns |     6.47 ns |   2,654 B |         - |
| Decrypt · ChaCha20 (NaCl.Core)          | 8KB          |    19,953.7 ns |    35.39 ns |    33.11 ns |  18,444 B |      24 B |
| Decrypt · ChaCha20 (BouncyCastle)       | 8KB          |    38,913.0 ns |   263.35 ns |   246.34 ns |     769 B |      96 B |
| Decrypt · ChaCha20 (CryptoHives-Scalar) | 8KB          |    91,281.3 ns |   363.54 ns |   340.06 ns |  12,651 B |         - |
|                                         |              |                |             |             |           |           |
| Encrypt · ChaCha20 (CryptoHives-AVX2)   | 8KB          |     6,058.3 ns |     0.85 ns |     0.79 ns |   2,840 B |         - |
| Encrypt · ChaCha20 (CryptoHives-SSSE3)  | 8KB          |    11,628.4 ns |     2.85 ns |     2.66 ns |   2,654 B |         - |
| Encrypt · ChaCha20 (NaCl.Core)          | 8KB          |    20,124.5 ns |    68.62 ns |    64.19 ns |  18,263 B |      24 B |
| Encrypt · ChaCha20 (BouncyCastle)       | 8KB          |    41,433.1 ns |    47.28 ns |    44.23 ns |     757 B |      96 B |
| Encrypt · ChaCha20 (CryptoHives-Scalar) | 8KB          |    91,270.1 ns |   316.26 ns |   295.83 ns |   6,502 B |         - |
|                                         |              |                |             |             |           |           |
| Decrypt · ChaCha20 (CryptoHives-AVX2)   | 128KB        |    97,014.2 ns |    31.37 ns |    27.81 ns |   2,840 B |         - |
| Decrypt · ChaCha20 (CryptoHives-SSSE3)  | 128KB        |   184,881.5 ns |   105.01 ns |    98.22 ns |   2,654 B |         - |
| Decrypt · ChaCha20 (NaCl.Core)          | 128KB        |   322,610.5 ns | 2,584.65 ns | 2,417.68 ns |  18,247 B |      24 B |
| Decrypt · ChaCha20 (BouncyCastle)       | 128KB        |   619,592.5 ns | 3,872.45 ns | 3,233.67 ns |     757 B |      96 B |
| Decrypt · ChaCha20 (CryptoHives-Scalar) | 128KB        | 1,466,417.5 ns | 5,870.73 ns | 5,491.49 ns |   6,502 B |         - |
|                                         |              |                |             |             |           |           |
| Encrypt · ChaCha20 (CryptoHives-AVX2)   | 128KB        |    96,626.4 ns |    28.01 ns |    26.20 ns |   2,840 B |         - |
| Encrypt · ChaCha20 (CryptoHives-SSSE3)  | 128KB        |   184,978.8 ns |    76.42 ns |    71.49 ns |   2,654 B |         - |
| Encrypt · ChaCha20 (NaCl.Core)          | 128KB        |   318,285.5 ns |   791.44 ns |   740.31 ns |  18,257 B |      24 B |
| Encrypt · ChaCha20 (BouncyCastle)       | 128KB        |   622,896.4 ns | 7,912.89 ns | 7,401.72 ns |     757 B |      96 B |
| Encrypt · ChaCha20 (CryptoHives-Scalar) | 128KB        | 1,466,678.6 ns | 4,711.54 ns | 4,407.18 ns |  12,461 B |         - |