| Description                                 | TestDataSize | Mean         | Error      | StdDev     | Allocated |
|-------------------------------------------- |------------- |-------------:|-----------:|-----------:|----------:|
| Decrypt · ARIA-256-CBC (CryptoHives-Scalar) | 128B         |     1.939 μs |  0.0188 μs |  0.0175 μs |         - |
| Decrypt · ARIA-256-CBC (BouncyCastle)       | 128B         |     3.228 μs |  0.0164 μs |  0.0145 μs |    1416 B |
|                                             |              |              |            |            |           |
| Encrypt · ARIA-256-CBC (CryptoHives-Scalar) | 128B         |     1.944 μs |  0.0166 μs |  0.0147 μs |         - |
| Encrypt · ARIA-256-CBC (BouncyCastle)       | 128B         |     3.110 μs |  0.0568 μs |  0.0444 μs |    1416 B |
|                                             |              |              |            |            |           |
| Decrypt · ARIA-256-CBC (CryptoHives-Scalar) | 1KB          |    13.917 μs |  0.1098 μs |  0.0857 μs |         - |
| Decrypt · ARIA-256-CBC (BouncyCastle)       | 1KB          |    20.310 μs |  0.1672 μs |  0.1482 μs |    3656 B |
|                                             |              |              |            |            |           |
| Encrypt · ARIA-256-CBC (CryptoHives-Scalar) | 1KB          |    13.877 μs |  0.0669 μs |  0.0593 μs |         - |
| Encrypt · ARIA-256-CBC (BouncyCastle)       | 1KB          |    20.316 μs |  0.0448 μs |  0.0397 μs |    3656 B |
|                                             |              |              |            |            |           |
| Decrypt · ARIA-256-CBC (CryptoHives-Scalar) | 8KB          |   109.714 μs |  0.6868 μs |  0.6424 μs |         - |
| Decrypt · ARIA-256-CBC (BouncyCastle)       | 8KB          |   156.637 μs |  0.9547 μs |  0.7972 μs |   21576 B |
|                                             |              |              |            |            |           |
| Encrypt · ARIA-256-CBC (CryptoHives-Scalar) | 8KB          |   110.084 μs |  1.7355 μs |  1.3550 μs |         - |
| Encrypt · ARIA-256-CBC (BouncyCastle)       | 8KB          |   158.489 μs |  0.6857 μs |  0.6079 μs |   21576 B |
|                                             |              |              |            |            |           |
| Decrypt · ARIA-256-CBC (CryptoHives-Scalar) | 128KB        | 1,762.639 μs | 25.8263 μs | 21.5662 μs |         - |
| Decrypt · ARIA-256-CBC (BouncyCastle)       | 128KB        | 2,490.326 μs | 10.8012 μs |  9.5750 μs |  328776 B |
|                                             |              |              |            |            |           |
| Encrypt · ARIA-256-CBC (CryptoHives-Scalar) | 128KB        | 1,751.058 μs | 11.7474 μs |  9.8096 μs |         - |
| Encrypt · ARIA-256-CBC (BouncyCastle)       | 128KB        | 2,522.614 μs | 13.2123 μs | 10.3153 μs |  328776 B |