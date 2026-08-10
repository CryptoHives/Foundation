| Description                           | TestDataSize | Mean         | Error     | StdDev    | Allocated |
|-------------------------------------- |------------- |-------------:|----------:|----------:|----------:|
| Decrypt · ARIA-256-CBC (Managed)      | 128B         |     2.969 μs | 0.0142 μs | 0.0126 μs |         - |
| Decrypt · ARIA-256-CBC (BouncyCastle) | 128B         |     2.991 μs | 0.0063 μs | 0.0053 μs |    1496 B |
|                                       |              |              |           |           |           |
| Encrypt · ARIA-256-CBC (BouncyCastle) | 128B         |     2.907 μs | 0.0053 μs | 0.0047 μs |    1496 B |
| Encrypt · ARIA-256-CBC (Managed)      | 128B         |     2.974 μs | 0.0052 μs | 0.0046 μs |         - |
|                                       |              |              |           |           |           |
| Decrypt · ARIA-256-CBC (BouncyCastle) | 1KB          |    18.676 μs | 0.0366 μs | 0.0306 μs |    3736 B |
| Decrypt · ARIA-256-CBC (Managed)      | 1KB          |    21.258 μs | 0.0321 μs | 0.0284 μs |         - |
|                                       |              |              |           |           |           |
| Encrypt · ARIA-256-CBC (BouncyCastle) | 1KB          |    18.359 μs | 0.0685 μs | 0.0572 μs |    3736 B |
| Encrypt · ARIA-256-CBC (Managed)      | 1KB          |    21.345 μs | 0.0424 μs | 0.0397 μs |         - |
|                                       |              |              |           |           |           |
| Decrypt · ARIA-256-CBC (BouncyCastle) | 8KB          |   139.550 μs | 0.2432 μs | 0.1899 μs |   21656 B |
| Decrypt · ARIA-256-CBC (Managed)      | 8KB          |   168.287 μs | 0.6729 μs | 0.5965 μs |         - |
|                                       |              |              |           |           |           |
| Encrypt · ARIA-256-CBC (BouncyCastle) | 8KB          |   140.725 μs | 0.3938 μs | 0.3491 μs |   21656 B |
| Encrypt · ARIA-256-CBC (Managed)      | 8KB          |   168.559 μs | 0.2917 μs | 0.2586 μs |         - |
|                                       |              |              |           |           |           |
| Decrypt · ARIA-256-CBC (BouncyCastle) | 128KB        | 2,275.573 μs | 6.0435 μs | 5.3574 μs |  328856 B |
| Decrypt · ARIA-256-CBC (Managed)      | 128KB        | 2,691.327 μs | 9.0075 μs | 8.4256 μs |         - |
|                                       |              |              |           |           |           |
| Encrypt · ARIA-256-CBC (BouncyCastle) | 128KB        | 2,247.459 μs | 6.1531 μs | 5.7556 μs |  328856 B |
| Encrypt · ARIA-256-CBC (Managed)      | 128KB        | 2,704.634 μs | 8.3292 μs | 6.9553 μs |         - |