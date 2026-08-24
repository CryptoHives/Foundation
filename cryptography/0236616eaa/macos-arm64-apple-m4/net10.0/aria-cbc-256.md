| Description                                 | TestDataSize | Mean         | Error      | StdDev     | Allocated |
|-------------------------------------------- |------------- |-------------:|-----------:|-----------:|----------:|
| Decrypt · ARIA-256-CBC (CryptoHives-Scalar) | 128B         |     5.826 μs |  0.0036 μs |  0.0032 μs |         - |
| Decrypt · ARIA-256-CBC (BouncyCastle)       | 128B         |    13.233 μs |  0.0092 μs |  0.0077 μs |    1416 B |
|                                             |              |              |            |            |           |
| Encrypt · ARIA-256-CBC (CryptoHives-Scalar) | 128B         |     1.446 μs |  0.0285 μs |  0.0361 μs |         - |
| Encrypt · ARIA-256-CBC (BouncyCastle)       | 128B         |     3.257 μs |  0.0640 μs |  0.0598 μs |    1416 B |
|                                             |              |              |            |            |           |
| Decrypt · ARIA-256-CBC (CryptoHives-Scalar) | 1KB          |    41.645 μs |  0.0428 μs |  0.0357 μs |         - |
| Decrypt · ARIA-256-CBC (BouncyCastle)       | 1KB          |    82.491 μs |  0.0916 μs |  0.0812 μs |    3656 B |
|                                             |              |              |            |            |           |
| Encrypt · ARIA-256-CBC (CryptoHives-Scalar) | 1KB          |    41.098 μs |  0.0636 μs |  0.0595 μs |         - |
| Encrypt · ARIA-256-CBC (BouncyCastle)       | 1KB          |    80.640 μs |  0.0554 μs |  0.0462 μs |    3656 B |
|                                             |              |              |            |            |           |
| Decrypt · ARIA-256-CBC (CryptoHives-Scalar) | 8KB          |   327.929 μs |  0.1473 μs |  0.1230 μs |         - |
| Decrypt · ARIA-256-CBC (BouncyCastle)       | 8KB          |   640.653 μs |  0.4794 μs |  0.4004 μs |   21576 B |
|                                             |              |              |            |            |           |
| Encrypt · ARIA-256-CBC (CryptoHives-Scalar) | 8KB          |   323.455 μs |  0.1283 μs |  0.1001 μs |         - |
| Encrypt · ARIA-256-CBC (BouncyCastle)       | 8KB          |   624.898 μs |  0.4293 μs |  0.3352 μs |   21576 B |
|                                             |              |              |            |            |           |
| Decrypt · ARIA-256-CBC (CryptoHives-Scalar) | 128KB        | 1,139.009 μs | 21.8170 μs | 55.1343 μs |         - |
| Decrypt · ARIA-256-CBC (BouncyCastle)       | 128KB        | 2,135.931 μs | 29.5149 μs | 26.1642 μs |  328776 B |
|                                             |              |              |            |            |           |
| Encrypt · ARIA-256-CBC (CryptoHives-Scalar) | 128KB        | 5,177.697 μs | 14.6669 μs | 13.0018 μs |         - |
| Encrypt · ARIA-256-CBC (BouncyCastle)       | 128KB        | 9,921.040 μs | 14.5804 μs | 12.9251 μs |  328776 B |