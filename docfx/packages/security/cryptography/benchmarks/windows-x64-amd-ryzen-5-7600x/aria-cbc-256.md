| Description                           | TestDataSize | Mean         | Error      | StdDev     | Allocated |
|-------------------------------------- |------------- |-------------:|-----------:|-----------:|----------:|
| Decrypt · ARIA-256-CBC (BouncyCastle) | 128B         |     3.460 μs |  0.0237 μs |  0.0222 μs |    1496 B |
| Decrypt · ARIA-256-CBC (Managed)      | 128B         |     3.529 μs |  0.0202 μs |  0.0179 μs |         - |
|                                       |              |              |            |            |           |
| Encrypt · ARIA-256-CBC (BouncyCastle) | 128B         |     3.533 μs |  0.0690 μs |  0.0708 μs |    1496 B |
| Encrypt · ARIA-256-CBC (Managed)      | 128B         |     3.686 μs |  0.0715 μs |  0.0823 μs |         - |
|                                       |              |              |            |            |           |
| Decrypt · ARIA-256-CBC (BouncyCastle) | 1KB          |    21.765 μs |  0.2543 μs |  0.2379 μs |    3736 B |
| Decrypt · ARIA-256-CBC (Managed)      | 1KB          |    25.382 μs |  0.1899 μs |  0.1683 μs |         - |
|                                       |              |              |            |            |           |
| Encrypt · ARIA-256-CBC (BouncyCastle) | 1KB          |    22.283 μs |  0.3046 μs |  0.2849 μs |    3736 B |
| Encrypt · ARIA-256-CBC (Managed)      | 1KB          |    26.715 μs |  0.5300 μs |  0.9421 μs |         - |
|                                       |              |              |            |            |           |
| Decrypt · ARIA-256-CBC (BouncyCastle) | 8KB          |   167.904 μs |  1.5118 μs |  1.4141 μs |   21656 B |
| Decrypt · ARIA-256-CBC (Managed)      | 8KB          |   199.821 μs |  1.7383 μs |  1.5410 μs |         - |
|                                       |              |              |            |            |           |
| Encrypt · ARIA-256-CBC (BouncyCastle) | 8KB          |   169.882 μs |  1.5385 μs |  1.3638 μs |   21656 B |
| Encrypt · ARIA-256-CBC (Managed)      | 8KB          |   202.817 μs |  1.8558 μs |  1.7359 μs |         - |
|                                       |              |              |            |            |           |
| Decrypt · ARIA-256-CBC (BouncyCastle) | 128KB        | 2,662.388 μs | 18.6247 μs | 17.4216 μs |  328856 B |
| Decrypt · ARIA-256-CBC (Managed)      | 128KB        | 3,185.541 μs | 23.9965 μs | 21.2723 μs |         - |
|                                       |              |              |            |            |           |
| Encrypt · ARIA-256-CBC (BouncyCastle) | 128KB        | 2,709.181 μs | 23.9714 μs | 22.4228 μs |  328856 B |
| Encrypt · ARIA-256-CBC (Managed)      | 128KB        | 3,211.215 μs | 29.7823 μs | 27.8584 μs |         - |