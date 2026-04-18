| Description                                 | TestDataSize | Mean         | Error      | StdDev     | Allocated |
|-------------------------------------------- |------------- |-------------:|-----------:|-----------:|----------:|
| Decrypt · ARIA-256-CBC (BouncyCastle)       | 128B         |     3.139 μs |  0.0097 μs |  0.0086 μs |    1496 B |
| Decrypt · ARIA-256-CBC (CryptoHives-Scalar) | 128B         |     3.265 μs |  0.0046 μs |  0.0041 μs |         - |
|                                             |              |              |            |            |           |
| Encrypt · ARIA-256-CBC (BouncyCastle)       | 128B         |     3.019 μs |  0.0066 μs |  0.0059 μs |    1496 B |
| Encrypt · ARIA-256-CBC (CryptoHives-Scalar) | 128B         |     3.245 μs |  0.0095 μs |  0.0089 μs |         - |
|                                             |              |              |            |            |           |
| Decrypt · ARIA-256-CBC (BouncyCastle)       | 1KB          |    19.770 μs |  0.0639 μs |  0.0598 μs |    3736 B |
| Decrypt · ARIA-256-CBC (CryptoHives-Scalar) | 1KB          |    23.202 μs |  0.1088 μs |  0.1018 μs |         - |
|                                             |              |              |            |            |           |
| Encrypt · ARIA-256-CBC (BouncyCastle)       | 1KB          |    19.788 μs |  0.0563 μs |  0.0499 μs |    3736 B |
| Encrypt · ARIA-256-CBC (CryptoHives-Scalar) | 1KB          |    23.242 μs |  0.0999 μs |  0.0934 μs |         - |
|                                             |              |              |            |            |           |
| Decrypt · ARIA-256-CBC (BouncyCastle)       | 8KB          |   153.419 μs |  0.5030 μs |  0.4705 μs |   21656 B |
| Decrypt · ARIA-256-CBC (CryptoHives-Scalar) | 8KB          |   183.142 μs |  0.2246 μs |  0.1876 μs |         - |
|                                             |              |              |            |            |           |
| Encrypt · ARIA-256-CBC (BouncyCastle)       | 8KB          |   154.947 μs |  0.3621 μs |  0.3388 μs |   21656 B |
| Encrypt · ARIA-256-CBC (CryptoHives-Scalar) | 8KB          |   183.539 μs |  1.0040 μs |  0.9391 μs |         - |
|                                             |              |              |            |            |           |
| Decrypt · ARIA-256-CBC (BouncyCastle)       | 128KB        | 2,431.475 μs |  6.3892 μs |  5.9764 μs |  328856 B |
| Decrypt · ARIA-256-CBC (CryptoHives-Scalar) | 128KB        | 2,929.538 μs | 13.8826 μs | 12.9858 μs |         - |
|                                             |              |              |            |            |           |
| Encrypt · ARIA-256-CBC (BouncyCastle)       | 128KB        | 2,463.406 μs |  5.1349 μs |  4.5519 μs |  328856 B |
| Encrypt · ARIA-256-CBC (CryptoHives-Scalar) | 128KB        | 2,927.544 μs |  7.8173 μs |  7.3123 μs |         - |