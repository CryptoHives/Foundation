| Description                                 | TestDataSize | Mean         | Error      | StdDev     | Allocated |
|-------------------------------------------- |------------- |-------------:|-----------:|-----------:|----------:|
| Decrypt · ARIA-256-CBC (CryptoHives-Scalar) | 128B         |     1.227 μs |  0.0015 μs |  0.0013 μs |         - |
| Decrypt · ARIA-256-CBC (BouncyCastle)       | 128B         |     2.589 μs |  0.0099 μs |  0.0088 μs |    1416 B |
|                                             |              |              |            |            |           |
| Encrypt · ARIA-256-CBC (CryptoHives-Scalar) | 128B         |     1.228 μs |  0.0018 μs |  0.0017 μs |         - |
| Encrypt · ARIA-256-CBC (BouncyCastle)       | 128B         |     2.470 μs |  0.0078 μs |  0.0070 μs |    1416 B |
|                                             |              |              |            |            |           |
| Decrypt · ARIA-256-CBC (CryptoHives-Scalar) | 1KB          |     8.762 μs |  0.0244 μs |  0.0204 μs |         - |
| Decrypt · ARIA-256-CBC (BouncyCastle)       | 1KB          |    15.228 μs |  0.0265 μs |  0.0235 μs |    3656 B |
|                                             |              |              |            |            |           |
| Encrypt · ARIA-256-CBC (CryptoHives-Scalar) | 1KB          |     8.756 μs |  0.0116 μs |  0.0108 μs |         - |
| Encrypt · ARIA-256-CBC (BouncyCastle)       | 1KB          |    16.120 μs |  0.0630 μs |  0.0590 μs |    3656 B |
|                                             |              |              |            |            |           |
| Decrypt · ARIA-256-CBC (CryptoHives-Scalar) | 8KB          |    68.995 μs |  0.0742 μs |  0.0694 μs |         - |
| Decrypt · ARIA-256-CBC (BouncyCastle)       | 8KB          |   116.690 μs |  0.2717 μs |  0.2541 μs |   21576 B |
|                                             |              |              |            |            |           |
| Encrypt · ARIA-256-CBC (CryptoHives-Scalar) | 8KB          |    68.946 μs |  0.0913 μs |  0.0854 μs |         - |
| Encrypt · ARIA-256-CBC (BouncyCastle)       | 8KB          |   124.608 μs |  0.6936 μs |  0.6488 μs |   21576 B |
|                                             |              |              |            |            |           |
| Decrypt · ARIA-256-CBC (CryptoHives-Scalar) | 128KB        | 1,100.683 μs |  2.1351 μs |  1.9972 μs |         - |
| Decrypt · ARIA-256-CBC (BouncyCastle)       | 128KB        | 1,872.983 μs |  4.0231 μs |  3.7632 μs |  328776 B |
|                                             |              |              |            |            |           |
| Encrypt · ARIA-256-CBC (CryptoHives-Scalar) | 128KB        | 1,101.912 μs |  1.0609 μs |  0.9923 μs |         - |
| Encrypt · ARIA-256-CBC (BouncyCastle)       | 128KB        | 2,000.216 μs | 10.9113 μs | 10.2065 μs |  328776 B |