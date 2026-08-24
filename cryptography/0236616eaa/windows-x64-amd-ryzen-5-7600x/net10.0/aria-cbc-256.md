| Description                                 | TestDataSize | Mean         | Error     | StdDev    | Allocated |
|-------------------------------------------- |------------- |-------------:|----------:|----------:|----------:|
| Decrypt · ARIA-256-CBC (CryptoHives-Scalar) | 128B         |     1.934 μs | 0.0033 μs | 0.0029 μs |         - |
| Decrypt · ARIA-256-CBC (BouncyCastle)       | 128B         |     3.244 μs | 0.0045 μs | 0.0038 μs |    1416 B |
|                                             |              |              |           |           |           |
| Encrypt · ARIA-256-CBC (CryptoHives-Scalar) | 128B         |     1.943 μs | 0.0207 μs | 0.0173 μs |         - |
| Encrypt · ARIA-256-CBC (BouncyCastle)       | 128B         |     3.096 μs | 0.0045 μs | 0.0040 μs |    1416 B |
|                                             |              |              |           |           |           |
| Decrypt · ARIA-256-CBC (CryptoHives-Scalar) | 1KB          |    13.881 μs | 0.0345 μs | 0.0306 μs |         - |
| Decrypt · ARIA-256-CBC (BouncyCastle)       | 1KB          |    20.317 μs | 0.0262 μs | 0.0232 μs |    3656 B |
|                                             |              |              |           |           |           |
| Encrypt · ARIA-256-CBC (CryptoHives-Scalar) | 1KB          |    14.053 μs | 0.0286 μs | 0.0254 μs |         - |
| Encrypt · ARIA-256-CBC (BouncyCastle)       | 1KB          |    20.380 μs | 0.0559 μs | 0.0467 μs |    3656 B |
|                                             |              |              |           |           |           |
| Decrypt · ARIA-256-CBC (CryptoHives-Scalar) | 8KB          |   109.437 μs | 0.1569 μs | 0.1225 μs |         - |
| Decrypt · ARIA-256-CBC (BouncyCastle)       | 8KB          |   157.410 μs | 0.3946 μs | 0.3692 μs |   21576 B |
|                                             |              |              |           |           |           |
| Encrypt · ARIA-256-CBC (CryptoHives-Scalar) | 8KB          |   109.221 μs | 0.2013 μs | 0.1572 μs |         - |
| Encrypt · ARIA-256-CBC (BouncyCastle)       | 8KB          |   158.948 μs | 0.3056 μs | 0.2859 μs |   21576 B |
|                                             |              |              |           |           |           |
| Decrypt · ARIA-256-CBC (CryptoHives-Scalar) | 128KB        | 1,747.718 μs | 3.9417 μs | 3.2915 μs |         - |
| Decrypt · ARIA-256-CBC (BouncyCastle)       | 128KB        | 2,502.926 μs | 3.6878 μs | 3.4496 μs |  328776 B |
|                                             |              |              |           |           |           |
| Encrypt · ARIA-256-CBC (CryptoHives-Scalar) | 128KB        | 1,745.003 μs | 4.9414 μs | 4.3804 μs |         - |
| Encrypt · ARIA-256-CBC (BouncyCastle)       | 128KB        | 2,538.705 μs | 5.3034 μs | 4.7013 μs |  328776 B |