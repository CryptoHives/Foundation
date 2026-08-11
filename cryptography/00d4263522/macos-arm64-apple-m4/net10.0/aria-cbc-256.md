| Description                                 | TestDataSize | Mean         | Error      | StdDev     | Allocated |
|-------------------------------------------- |------------- |-------------:|-----------:|-----------:|----------:|
| Decrypt · ARIA-256-CBC (CryptoHives-Scalar) | 128B         |     1.252 μs |  0.0228 μs |  0.0214 μs |         - |
| Decrypt · ARIA-256-CBC (BouncyCastle)       | 128B         |     2.981 μs |  0.0363 μs |  0.0321 μs |    1416 B |
|                                             |              |              |            |            |           |
| Encrypt · ARIA-256-CBC (CryptoHives-Scalar) | 128B         |     1.226 μs |  0.0012 μs |  0.0009 μs |         - |
| Encrypt · ARIA-256-CBC (BouncyCastle)       | 128B         |     2.934 μs |  0.0367 μs |  0.0343 μs |    1416 B |
|                                             |              |              |            |            |           |
| Decrypt · ARIA-256-CBC (CryptoHives-Scalar) | 1KB          |     8.950 μs |  0.1689 μs |  0.1579 μs |         - |
| Decrypt · ARIA-256-CBC (BouncyCastle)       | 1KB          |    18.591 μs |  0.0233 μs |  0.0182 μs |    3656 B |
|                                             |              |              |            |            |           |
| Encrypt · ARIA-256-CBC (CryptoHives-Scalar) | 1KB          |     8.837 μs |  0.1629 μs |  0.1524 μs |         - |
| Encrypt · ARIA-256-CBC (BouncyCastle)       | 1KB          |    18.491 μs |  0.0209 μs |  0.0163 μs |    3656 B |
|                                             |              |              |            |            |           |
| Decrypt · ARIA-256-CBC (CryptoHives-Scalar) | 8KB          |    70.367 μs |  1.0951 μs |  1.1718 μs |         - |
| Decrypt · ARIA-256-CBC (BouncyCastle)       | 8KB          |   142.806 μs |  0.1689 μs |  0.1319 μs |   21576 B |
|                                             |              |              |            |            |           |
| Encrypt · ARIA-256-CBC (CryptoHives-Scalar) | 8KB          |    68.896 μs |  0.0608 μs |  0.0475 μs |         - |
| Encrypt · ARIA-256-CBC (BouncyCastle)       | 8KB          |   142.564 μs |  0.6632 μs |  0.5177 μs |   21576 B |
|                                             |              |              |            |            |           |
| Decrypt · ARIA-256-CBC (CryptoHives-Scalar) | 128KB        | 1,116.609 μs |  3.6769 μs |  2.8707 μs |         - |
| Decrypt · ARIA-256-CBC (BouncyCastle)       | 128KB        | 2,335.404 μs |  3.7541 μs |  2.9310 μs |  328776 B |
|                                             |              |              |            |            |           |
| Encrypt · ARIA-256-CBC (CryptoHives-Scalar) | 128KB        | 1,101.035 μs |  1.1213 μs |  0.8755 μs |         - |
| Encrypt · ARIA-256-CBC (BouncyCastle)       | 128KB        | 2,281.693 μs | 36.9727 μs | 34.5843 μs |  328776 B |