| Description                                 | TestDataSize | Mean         | Error      | StdDev     | Allocated |
|-------------------------------------------- |------------- |-------------:|-----------:|-----------:|----------:|
| Decrypt · ARIA-256-CBC (CryptoHives-Scalar) | 128B         |     1.912 μs |  0.0130 μs |  0.0116 μs |         - |
| Decrypt · ARIA-256-CBC (BouncyCastle)       | 128B         |     3.199 μs |  0.0164 μs |  0.0153 μs |    1416 B |
|                                             |              |              |            |            |           |
| Encrypt · ARIA-256-CBC (CryptoHives-Scalar) | 128B         |     1.917 μs |  0.0187 μs |  0.0175 μs |         - |
| Encrypt · ARIA-256-CBC (BouncyCastle)       | 128B         |     3.071 μs |  0.0169 μs |  0.0158 μs |    1416 B |
|                                             |              |              |            |            |           |
| Decrypt · ARIA-256-CBC (CryptoHives-Scalar) | 1KB          |    13.795 μs |  0.1584 μs |  0.1482 μs |         - |
| Decrypt · ARIA-256-CBC (BouncyCastle)       | 1KB          |    20.048 μs |  0.1082 μs |  0.1012 μs |    3656 B |
|                                             |              |              |            |            |           |
| Encrypt · ARIA-256-CBC (CryptoHives-Scalar) | 1KB          |    13.749 μs |  0.0871 μs |  0.0815 μs |         - |
| Encrypt · ARIA-256-CBC (BouncyCastle)       | 1KB          |    20.098 μs |  0.0850 μs |  0.0795 μs |    3656 B |
|                                             |              |              |            |            |           |
| Decrypt · ARIA-256-CBC (CryptoHives-Scalar) | 8KB          |   107.708 μs |  0.6684 μs |  0.5925 μs |         - |
| Decrypt · ARIA-256-CBC (BouncyCastle)       | 8KB          |   155.039 μs |  0.8529 μs |  0.7560 μs |   21576 B |
|                                             |              |              |            |            |           |
| Encrypt · ARIA-256-CBC (CryptoHives-Scalar) | 8KB          |   107.560 μs |  0.5141 μs |  0.4293 μs |         - |
| Encrypt · ARIA-256-CBC (BouncyCastle)       | 8KB          |   157.434 μs |  1.1377 μs |  1.0086 μs |   21576 B |
|                                             |              |              |            |            |           |
| Decrypt · ARIA-256-CBC (CryptoHives-Scalar) | 128KB        | 1,724.580 μs |  9.7574 μs |  9.1271 μs |         - |
| Decrypt · ARIA-256-CBC (BouncyCastle)       | 128KB        | 2,471.908 μs |  8.8225 μs |  7.8209 μs |  328776 B |
|                                             |              |              |            |            |           |
| Encrypt · ARIA-256-CBC (CryptoHives-Scalar) | 128KB        | 1,728.679 μs |  9.2960 μs |  8.2407 μs |         - |
| Encrypt · ARIA-256-CBC (BouncyCastle)       | 128KB        | 2,501.985 μs | 11.6724 μs | 10.9184 μs |  328776 B |