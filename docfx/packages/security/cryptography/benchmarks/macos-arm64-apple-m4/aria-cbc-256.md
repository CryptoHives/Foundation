| Description                                 | TestDataSize | Mean         | Error     | StdDev    | Allocated |
|-------------------------------------------- |------------- |-------------:|----------:|----------:|----------:|
| Decrypt · ARIA-256-CBC (CryptoHives-Scalar) | 128B         |     1.210 μs | 0.0005 μs | 0.0005 μs |         - |
| Decrypt · ARIA-256-CBC (BouncyCastle)       | 128B         |     3.003 μs | 0.0050 μs | 0.0047 μs |    1496 B |
|                                             |              |              |           |           |           |
| Encrypt · ARIA-256-CBC (CryptoHives-Scalar) | 128B         |     1.245 μs | 0.0011 μs | 0.0010 μs |         - |
| Encrypt · ARIA-256-CBC (BouncyCastle)       | 128B         |     2.914 μs | 0.0058 μs | 0.0054 μs |    1496 B |
|                                             |              |              |           |           |           |
| Decrypt · ARIA-256-CBC (CryptoHives-Scalar) | 1KB          |     8.639 μs | 0.0104 μs | 0.0097 μs |         - |
| Decrypt · ARIA-256-CBC (BouncyCastle)       | 1KB          |    18.666 μs | 0.0537 μs | 0.0476 μs |    3736 B |
|                                             |              |              |           |           |           |
| Encrypt · ARIA-256-CBC (CryptoHives-Scalar) | 1KB          |     8.922 μs | 0.0042 μs | 0.0039 μs |         - |
| Encrypt · ARIA-256-CBC (BouncyCastle)       | 1KB          |    18.424 μs | 0.0485 μs | 0.0454 μs |    3736 B |
|                                             |              |              |           |           |           |
| Decrypt · ARIA-256-CBC (CryptoHives-Scalar) | 8KB          |    68.079 μs | 0.0810 μs | 0.0758 μs |         - |
| Decrypt · ARIA-256-CBC (BouncyCastle)       | 8KB          |   143.145 μs | 0.3001 μs | 0.2807 μs |   21656 B |
|                                             |              |              |           |           |           |
| Encrypt · ARIA-256-CBC (CryptoHives-Scalar) | 8KB          |    70.319 μs | 0.1612 μs | 0.1346 μs |         - |
| Encrypt · ARIA-256-CBC (BouncyCastle)       | 8KB          |   140.554 μs | 0.2828 μs | 0.2645 μs |   21656 B |
|                                             |              |              |           |           |           |
| Decrypt · ARIA-256-CBC (CryptoHives-Scalar) | 128KB        | 1,088.538 μs | 2.2789 μs | 2.1317 μs |         - |
| Decrypt · ARIA-256-CBC (BouncyCastle)       | 128KB        | 2,266.721 μs | 6.7677 μs | 6.3305 μs |  328856 B |
|                                             |              |              |           |           |           |
| Encrypt · ARIA-256-CBC (CryptoHives-Scalar) | 128KB        | 1,124.559 μs | 0.7575 μs | 0.7085 μs |         - |
| Encrypt · ARIA-256-CBC (BouncyCastle)       | 128KB        | 2,246.388 μs | 6.5943 μs | 6.1683 μs |  328856 B |