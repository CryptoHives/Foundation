| Description                                 | TestDataSize | Mean          | Error      | StdDev     | Median        | Allocated |
|-------------------------------------------- |------------- |--------------:|-----------:|-----------:|--------------:|----------:|
| Decrypt · ARIA-256-CBC (CryptoHives-Scalar) | 128B         |     13.950 μs |  0.0076 μs |  0.0067 μs |     13.950 μs |         - |
| Decrypt · ARIA-256-CBC (BouncyCastle)       | 128B         |     14.363 μs |  0.0094 μs |  0.0079 μs |     14.363 μs |    1496 B |
|                                             |              |               |            |            |               |           |
| Encrypt · ARIA-256-CBC (CryptoHives-Scalar) | 128B         |      3.702 μs |  0.0734 μs |  0.1121 μs |      3.639 μs |         - |
| Encrypt · ARIA-256-CBC (BouncyCastle)       | 128B         |     13.823 μs |  0.0178 μs |  0.0148 μs |     13.824 μs |    1496 B |
|                                             |              |               |            |            |               |           |
| Decrypt · ARIA-256-CBC (BouncyCastle)       | 1KB          |     89.631 μs |  0.0580 μs |  0.0484 μs |     89.629 μs |    3736 B |
| Decrypt · ARIA-256-CBC (CryptoHives-Scalar) | 1KB          |    100.178 μs |  0.0888 μs |  0.0741 μs |    100.174 μs |         - |
|                                             |              |               |            |            |               |           |
| Encrypt · ARIA-256-CBC (BouncyCastle)       | 1KB          |     88.067 μs |  0.2277 μs |  0.2018 μs |     88.116 μs |    3736 B |
| Encrypt · ARIA-256-CBC (CryptoHives-Scalar) | 1KB          |    100.706 μs |  0.2030 μs |  0.1899 μs |    100.653 μs |         - |
|                                             |              |               |            |            |               |           |
| Decrypt · ARIA-256-CBC (BouncyCastle)       | 8KB          |    683.643 μs |  1.4952 μs |  1.3986 μs |    684.128 μs |   21656 B |
| Decrypt · ARIA-256-CBC (CryptoHives-Scalar) | 8KB          |    790.639 μs |  0.7298 μs |  0.6470 μs |    790.638 μs |         - |
|                                             |              |               |            |            |               |           |
| Encrypt · ARIA-256-CBC (BouncyCastle)       | 8KB          |    671.514 μs |  2.0876 μs |  1.9527 μs |    671.821 μs |   21656 B |
| Encrypt · ARIA-256-CBC (CryptoHives-Scalar) | 8KB          |    792.649 μs |  1.2037 μs |  1.0671 μs |    792.220 μs |         - |
|                                             |              |               |            |            |               |           |
| Decrypt · ARIA-256-CBC (BouncyCastle)       | 128KB        | 10,854.067 μs | 17.9846 μs | 16.8228 μs | 10,858.107 μs |  328856 B |
| Decrypt · ARIA-256-CBC (CryptoHives-Scalar) | 128KB        | 12,636.719 μs |  8.9280 μs |  8.3513 μs | 12,634.152 μs |         - |
|                                             |              |               |            |            |               |           |
| Encrypt · ARIA-256-CBC (BouncyCastle)       | 128KB        | 10,730.781 μs | 17.6026 μs | 14.6990 μs | 10,730.607 μs |  328856 B |
| Encrypt · ARIA-256-CBC (CryptoHives-Scalar) | 128KB        | 12,671.084 μs | 10.0120 μs |  8.3605 μs | 12,672.146 μs |         - |