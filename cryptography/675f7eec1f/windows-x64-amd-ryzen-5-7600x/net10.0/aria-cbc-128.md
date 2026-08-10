| Description                                 | TestDataSize | Mean         | Error      | StdDev    | Allocated |
|-------------------------------------------- |------------- |-------------:|-----------:|----------:|----------:|
| Decrypt · ARIA-128-CBC (CryptoHives-Scalar) | 128B         |     1.482 μs |  0.0080 μs | 0.0075 μs |         - |
| Decrypt · ARIA-128-CBC (BouncyCastle)       | 128B         |     2.503 μs |  0.0170 μs | 0.0159 μs |    1288 B |
|                                             |              |              |            |           |           |
| Encrypt · ARIA-128-CBC (CryptoHives-Scalar) | 128B         |     1.477 μs |  0.0115 μs | 0.0107 μs |         - |
| Encrypt · ARIA-128-CBC (BouncyCastle)       | 128B         |     2.387 μs |  0.0145 μs | 0.0129 μs |    1288 B |
|                                             |              |              |            |           |           |
| Decrypt · ARIA-128-CBC (CryptoHives-Scalar) | 1KB          |    10.632 μs |  0.1040 μs | 0.0922 μs |         - |
| Decrypt · ARIA-128-CBC (BouncyCastle)       | 1KB          |    15.600 μs |  0.1407 μs | 0.1316 μs |    3528 B |
|                                             |              |              |            |           |           |
| Encrypt · ARIA-128-CBC (CryptoHives-Scalar) | 1KB          |    10.619 μs |  0.0723 μs | 0.0676 μs |         - |
| Encrypt · ARIA-128-CBC (BouncyCastle)       | 1KB          |    15.454 μs |  0.0891 μs | 0.0744 μs |    3528 B |
|                                             |              |              |            |           |           |
| Decrypt · ARIA-128-CBC (CryptoHives-Scalar) | 8KB          |    83.676 μs |  0.6459 μs | 0.6042 μs |         - |
| Decrypt · ARIA-128-CBC (BouncyCastle)       | 8KB          |   119.082 μs |  1.2288 μs | 1.1494 μs |   21448 B |
|                                             |              |              |            |           |           |
| Encrypt · ARIA-128-CBC (CryptoHives-Scalar) | 8KB          |    83.926 μs |  0.9878 μs | 0.8757 μs |         - |
| Encrypt · ARIA-128-CBC (BouncyCastle)       | 8KB          |   120.102 μs |  0.7322 μs | 0.6849 μs |   21448 B |
|                                             |              |              |            |           |           |
| Decrypt · ARIA-128-CBC (CryptoHives-Scalar) | 128KB        | 1,340.258 μs |  8.2037 μs | 7.6738 μs |         - |
| Decrypt · ARIA-128-CBC (BouncyCastle)       | 128KB        | 1,885.161 μs | 11.8537 μs | 9.8984 μs |  328648 B |
|                                             |              |              |            |           |           |
| Encrypt · ARIA-128-CBC (CryptoHives-Scalar) | 128KB        | 1,333.286 μs |  9.3856 μs | 8.7793 μs |         - |
| Encrypt · ARIA-128-CBC (BouncyCastle)       | 128KB        | 1,908.691 μs | 11.0045 μs | 9.7552 μs |  328648 B |