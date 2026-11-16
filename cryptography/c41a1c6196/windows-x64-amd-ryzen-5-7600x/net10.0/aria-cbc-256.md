| Description                                 | TestDataSize | Mean         | Error      | StdDev    | Code Size | Allocated |
|-------------------------------------------- |------------- |-------------:|-----------:|----------:|----------:|----------:|
| Decrypt · ARIA-256-CBC (CryptoHives-Scalar) | 128B         |     2.214 μs |  0.0076 μs | 0.0067 μs |   1,289 B |         - |
| Decrypt · ARIA-256-CBC (BouncyCastle)       | 128B         |     3.673 μs |  0.0085 μs | 0.0075 μs |   2,903 B |    1416 B |
|                                             |              |              |            |           |           |           |
| Encrypt · ARIA-256-CBC (CryptoHives-Scalar) | 128B         |     2.217 μs |  0.0103 μs | 0.0092 μs |   1,285 B |         - |
| Encrypt · ARIA-256-CBC (BouncyCastle)       | 128B         |     3.524 μs |  0.0113 μs | 0.0106 μs |   2,901 B |    1416 B |
|                                             |              |              |            |           |           |           |
| Decrypt · ARIA-256-CBC (CryptoHives-Scalar) | 1KB          |    15.846 μs |  0.0369 μs | 0.0327 μs |   1,289 B |         - |
| Decrypt · ARIA-256-CBC (BouncyCastle)       | 1KB          |    23.173 μs |  0.0989 μs | 0.0877 μs |   2,905 B |    3656 B |
|                                             |              |              |            |           |           |           |
| Encrypt · ARIA-256-CBC (CryptoHives-Scalar) | 1KB          |    15.822 μs |  0.0958 μs | 0.0896 μs |   1,285 B |         - |
| Encrypt · ARIA-256-CBC (BouncyCastle)       | 1KB          |    23.356 μs |  0.0554 μs | 0.0518 μs |   2,891 B |    3656 B |
|                                             |              |              |            |           |           |           |
| Decrypt · ARIA-256-CBC (CryptoHives-Scalar) | 8KB          |   124.573 μs |  0.4748 μs | 0.4441 μs |   1,289 B |         - |
| Decrypt · ARIA-256-CBC (BouncyCastle)       | 8KB          |   179.454 μs |  0.4968 μs | 0.4404 μs |   2,905 B |   21576 B |
|                                             |              |              |            |           |           |           |
| Encrypt · ARIA-256-CBC (CryptoHives-Scalar) | 8KB          |   124.638 μs |  0.3533 μs | 0.3132 μs |   1,285 B |         - |
| Encrypt · ARIA-256-CBC (BouncyCastle)       | 8KB          |   181.143 μs |  0.3880 μs | 0.3240 μs |   2,905 B |   21576 B |
|                                             |              |              |            |           |           |           |
| Decrypt · ARIA-256-CBC (CryptoHives-Scalar) | 128KB        | 1,997.822 μs |  8.3340 μs | 7.7956 μs |   1,289 B |         - |
| Decrypt · ARIA-256-CBC (BouncyCastle)       | 128KB        | 2,850.689 μs |  9.3206 μs | 8.2625 μs |   2,903 B |  328776 B |
|                                             |              |              |            |           |           |           |
| Encrypt · ARIA-256-CBC (CryptoHives-Scalar) | 128KB        | 1,993.046 μs | 10.6037 μs | 8.8546 μs |   1,289 B |         - |
| Encrypt · ARIA-256-CBC (BouncyCastle)       | 128KB        | 2,884.657 μs |  5.4306 μs | 5.0797 μs |   2,903 B |  328776 B |