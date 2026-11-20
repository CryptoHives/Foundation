| Description                                | TestDataSize | Mean          | Error         | StdDev        | Median        | Code Size | Allocated |
|------------------------------------------- |------------- |--------------:|--------------:|--------------:|--------------:|----------:|----------:|
| Decrypt · AES-256-CBC (CryptoHives-AES-NI) | 128B         |      64.71 ns |      0.169 ns |      0.141 ns |      64.69 ns |     255 B |         - |
| Decrypt · AES-256-CBC (OS)                 | 128B         |      66.35 ns |      0.143 ns |      0.112 ns |      66.33 ns |  17,766 B |         - |
| Decrypt · AES-256-CBC (CryptoHives-Scalar) | 128B         |     579.69 ns |      1.743 ns |      1.630 ns |     580.41 ns |     255 B |         - |
| Decrypt · AES-256-CBC (BouncyCastle)       | 128B         |     975.97 ns |      7.638 ns |      6.771 ns |     973.68 ns |  13,878 B |    1024 B |
|                                            |              |               |               |               |               |           |           |
| Encrypt · AES-256-CBC (CryptoHives-AES-NI) | 128B         |     132.53 ns |      0.403 ns |      0.377 ns |     132.55 ns |     255 B |         - |
| Encrypt · AES-256-CBC (OS)                 | 128B         |     149.62 ns |      2.956 ns |      5.971 ns |     147.36 ns |  16,178 B |         - |
| Encrypt · AES-256-CBC (CryptoHives-Scalar) | 128B         |     623.22 ns |      5.468 ns |      5.114 ns |     624.43 ns |     255 B |         - |
| Encrypt · AES-256-CBC (BouncyCastle)       | 128B         |     855.36 ns |     11.353 ns |     10.619 ns |     855.69 ns |  13,878 B |    1024 B |
|                                            |              |               |               |               |               |           |           |
| Decrypt · AES-256-CBC (OS)                 | 1KB          |     155.83 ns |      0.502 ns |      0.470 ns |     155.88 ns |  17,874 B |         - |
| Decrypt · AES-256-CBC (CryptoHives-AES-NI) | 1KB          |     340.23 ns |      0.866 ns |      0.677 ns |     340.26 ns |     255 B |         - |
| Decrypt · AES-256-CBC (CryptoHives-Scalar) | 1KB          |   4,083.15 ns |      9.350 ns |      8.746 ns |   4,082.40 ns |     255 B |         - |
| Decrypt · AES-256-CBC (BouncyCastle)       | 1KB          |   5,346.16 ns |     12.552 ns |     10.481 ns |   5,346.46 ns |   7,738 B |    1024 B |
|                                            |              |               |               |               |               |           |           |
| Encrypt · AES-256-CBC (OS)                 | 1KB          |     834.08 ns |      0.729 ns |      0.682 ns |     834.15 ns |  15,988 B |         - |
| Encrypt · AES-256-CBC (CryptoHives-AES-NI) | 1KB          |     835.11 ns |      0.395 ns |      0.370 ns |     835.04 ns |     255 B |         - |
| Encrypt · AES-256-CBC (CryptoHives-Scalar) | 1KB          |   4,292.44 ns |      9.076 ns |      7.086 ns |   4,292.69 ns |     255 B |         - |
| Encrypt · AES-256-CBC (BouncyCastle)       | 1KB          |   5,094.28 ns |     42.394 ns |     37.582 ns |   5,079.53 ns |  13,878 B |    1024 B |
|                                            |              |               |               |               |               |           |           |
| Decrypt · AES-256-CBC (OS)                 | 8KB          |     847.02 ns |      0.896 ns |      0.794 ns |     846.99 ns |  17,368 B |         - |
| Decrypt · AES-256-CBC (CryptoHives-AES-NI) | 8KB          |   2,535.20 ns |      3.293 ns |      2.750 ns |   2,535.23 ns |     255 B |         - |
| Decrypt · AES-256-CBC (CryptoHives-Scalar) | 8KB          |  32,167.84 ns |    126.765 ns |    112.374 ns |  32,133.65 ns |     255 B |         - |
| Decrypt · AES-256-CBC (BouncyCastle)       | 8KB          |  40,255.40 ns |    119.755 ns |    100.001 ns |  40,238.17 ns |   7,738 B |    1024 B |
|                                            |              |               |               |               |               |           |           |
| Encrypt · AES-256-CBC (OS)                 | 8KB          |   6,301.99 ns |      4.489 ns |      4.199 ns |   6,299.92 ns |  16,432 B |         - |
| Encrypt · AES-256-CBC (CryptoHives-AES-NI) | 8KB          |   6,446.71 ns |      2.077 ns |      1.943 ns |   6,446.51 ns |     255 B |         - |
| Encrypt · AES-256-CBC (CryptoHives-Scalar) | 8KB          |  33,596.81 ns |    138.192 ns |    129.264 ns |  33,563.42 ns |     255 B |         - |
| Encrypt · AES-256-CBC (BouncyCastle)       | 8KB          |  39,586.07 ns |    399.636 ns |    354.267 ns |  39,492.24 ns |   7,729 B |    1024 B |
|                                            |              |               |               |               |               |           |           |
| Decrypt · AES-256-CBC (OS)                 | 128KB        |  13,339.99 ns |     15.559 ns |     14.554 ns |  13,336.58 ns |  17,558 B |         - |
| Decrypt · AES-256-CBC (CryptoHives-AES-NI) | 128KB        |  40,156.33 ns |     44.158 ns |     39.145 ns |  40,155.41 ns |     255 B |         - |
| Decrypt · AES-256-CBC (CryptoHives-Scalar) | 128KB        | 514,254.99 ns |  2,094.211 ns |  1,748.761 ns | 513,795.02 ns |     255 B |         - |
| Decrypt · AES-256-CBC (BouncyCastle)       | 128KB        | 637,685.70 ns |  1,726.347 ns |  1,530.362 ns | 637,628.08 ns |  13,889 B |    1024 B |
|                                            |              |               |               |               |               |           |           |
| Encrypt · AES-256-CBC (OS)                 | 128KB        | 101,021.20 ns |     53.112 ns |     47.082 ns | 101,013.16 ns |  16,063 B |         - |
| Encrypt · AES-256-CBC (CryptoHives-AES-NI) | 128KB        | 102,671.98 ns |     31.491 ns |     27.916 ns | 102,671.32 ns |     255 B |         - |
| Encrypt · AES-256-CBC (BouncyCastle)       | 128KB        | 618,224.93 ns |  2,131.824 ns |  1,780.170 ns | 617,779.20 ns |  13,693 B |    1024 B |
| Encrypt · AES-256-CBC (CryptoHives-Scalar) | 128KB        | 690,927.05 ns | 14,514.357 ns | 42,795.912 ns | 719,169.63 ns |     255 B |         - |