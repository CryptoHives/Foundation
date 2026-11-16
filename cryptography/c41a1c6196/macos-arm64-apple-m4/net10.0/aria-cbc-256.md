| Description                                 | TestDataSize | Mean         | Error      | StdDev    | Allocated |
|-------------------------------------------- |------------- |-------------:|-----------:|----------:|----------:|
| Decrypt · ARIA-256-CBC (CryptoHives-Scalar) | 128B         |     1.236 μs |  0.0019 μs | 0.0017 μs |         - |
| Decrypt · ARIA-256-CBC (BouncyCastle)       | 128B         |     2.771 μs |  0.0078 μs | 0.0073 μs |    1416 B |
|                                             |              |              |            |           |           |
| Encrypt · ARIA-256-CBC (CryptoHives-Scalar) | 128B         |     1.221 μs |  0.0009 μs | 0.0007 μs |         - |
| Encrypt · ARIA-256-CBC (BouncyCastle)       | 128B         |     2.672 μs |  0.0086 μs | 0.0080 μs |    1416 B |
|                                             |              |              |            |           |           |
| Decrypt · ARIA-256-CBC (CryptoHives-Scalar) | 1KB          |     8.790 μs |  0.0095 μs | 0.0089 μs |         - |
| Decrypt · ARIA-256-CBC (BouncyCastle)       | 1KB          |    16.962 μs |  0.1218 μs | 0.1140 μs |    3656 B |
|                                             |              |              |            |           |           |
| Encrypt · ARIA-256-CBC (CryptoHives-Scalar) | 1KB          |     8.717 μs |  0.0097 μs | 0.0090 μs |         - |
| Encrypt · ARIA-256-CBC (BouncyCastle)       | 1KB          |    16.843 μs |  0.0808 μs | 0.0756 μs |    3656 B |
|                                             |              |              |            |           |           |
| Decrypt · ARIA-256-CBC (CryptoHives-Scalar) | 8KB          |    68.996 μs |  0.1275 μs | 0.1193 μs |         - |
| Decrypt · ARIA-256-CBC (BouncyCastle)       | 8KB          |   132.742 μs |  0.4498 μs | 0.3988 μs |   21576 B |
|                                             |              |              |            |           |           |
| Encrypt · ARIA-256-CBC (CryptoHives-Scalar) | 8KB          |    68.929 μs |  0.2569 μs | 0.2403 μs |         - |
| Encrypt · ARIA-256-CBC (BouncyCastle)       | 8KB          |   129.644 μs |  0.5483 μs | 0.5129 μs |   21576 B |
|                                             |              |              |            |           |           |
| Decrypt · ARIA-256-CBC (CryptoHives-Scalar) | 128KB        | 1,102.333 μs |  1.2573 μs | 1.1761 μs |         - |
| Decrypt · ARIA-256-CBC (BouncyCastle)       | 128KB        | 2,109.504 μs |  7.6583 μs | 7.1636 μs |  328776 B |
|                                             |              |              |            |           |           |
| Encrypt · ARIA-256-CBC (CryptoHives-Scalar) | 128KB        | 1,104.406 μs |  1.4536 μs | 1.3597 μs |         - |
| Encrypt · ARIA-256-CBC (BouncyCastle)       | 128KB        | 2,075.650 μs | 10.6306 μs | 9.9439 μs |  328776 B |