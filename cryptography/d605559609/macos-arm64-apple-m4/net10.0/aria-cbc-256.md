| Description                                 | TestDataSize | Mean         | Error      | StdDev      | Allocated |
|-------------------------------------------- |------------- |-------------:|-----------:|------------:|----------:|
| Decrypt · ARIA-256-CBC (CryptoHives-Scalar) | 128B         |     1.217 μs |  0.0005 μs |   0.0005 μs |         - |
| Decrypt · ARIA-256-CBC (BouncyCastle)       | 128B         |     2.785 μs |  0.0012 μs |   0.0011 μs |    1416 B |
|                                             |              |              |            |             |           |
| Encrypt · ARIA-256-CBC (CryptoHives-Scalar) | 128B         |     1.220 μs |  0.0030 μs |   0.0023 μs |         - |
| Encrypt · ARIA-256-CBC (BouncyCastle)       | 128B         |     2.673 μs |  0.0015 μs |   0.0014 μs |    1416 B |
|                                             |              |              |            |             |           |
| Decrypt · ARIA-256-CBC (CryptoHives-Scalar) | 1KB          |     8.676 μs |  0.0033 μs |   0.0029 μs |         - |
| Decrypt · ARIA-256-CBC (BouncyCastle)       | 1KB          |    17.263 μs |  0.0094 μs |   0.0078 μs |    3656 B |
|                                             |              |              |            |             |           |
| Encrypt · ARIA-256-CBC (CryptoHives-Scalar) | 1KB          |     8.770 μs |  0.0841 μs |   0.0702 μs |         - |
| Encrypt · ARIA-256-CBC (BouncyCastle)       | 1KB          |    17.012 μs |  0.0119 μs |   0.0093 μs |    3656 B |
|                                             |              |              |            |             |           |
| Decrypt · ARIA-256-CBC (CryptoHives-Scalar) | 8KB          |    68.387 μs |  0.0420 μs |   0.0372 μs |         - |
| Decrypt · ARIA-256-CBC (BouncyCastle)       | 8KB          |   134.623 μs |  0.0706 μs |   0.0589 μs |   21576 B |
|                                             |              |              |            |             |           |
| Encrypt · ARIA-256-CBC (CryptoHives-Scalar) | 8KB          |    68.638 μs |  0.0153 μs |   0.0143 μs |         - |
| Encrypt · ARIA-256-CBC (BouncyCastle)       | 8KB          |   131.501 μs |  0.0978 μs |   0.0915 μs |   21576 B |
|                                             |              |              |            |             |           |
| Decrypt · ARIA-256-CBC (CryptoHives-Scalar) | 128KB        | 1,094.554 μs |  0.4340 μs |   0.3624 μs |         - |
| Decrypt · ARIA-256-CBC (BouncyCastle)       | 128KB        | 2,189.175 μs | 73.2321 μs | 186.3992 μs |  328776 B |
|                                             |              |              |            |             |           |
| Encrypt · ARIA-256-CBC (CryptoHives-Scalar) | 128KB        | 1,096.924 μs |  0.3448 μs |   0.3056 μs |         - |
| Encrypt · ARIA-256-CBC (BouncyCastle)       | 128KB        | 2,080.305 μs |  0.9752 μs |   0.9122 μs |  328776 B |