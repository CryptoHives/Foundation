| Description                           | TestDataSize | Mean         | Error     | StdDev    | Allocated |
|-------------------------------------- |------------- |-------------:|----------:|----------:|----------:|
| Decrypt · ARIA-256-CBC (Managed)      | 128B         |     2.953 μs | 0.0010 μs | 0.0010 μs |         - |
| Decrypt · ARIA-256-CBC (BouncyCastle) | 128B         |     2.986 μs | 0.0050 μs | 0.0047 μs |    1496 B |
|                                       |              |              |           |           |           |
| Encrypt · ARIA-256-CBC (BouncyCastle) | 128B         |     2.918 μs | 0.0036 μs | 0.0034 μs |    1496 B |
| Encrypt · ARIA-256-CBC (Managed)      | 128B         |     2.963 μs | 0.0007 μs | 0.0006 μs |         - |
|                                       |              |              |           |           |           |
| Decrypt · ARIA-256-CBC (BouncyCastle) | 1KB          |    18.517 μs | 0.0186 μs | 0.0174 μs |    3736 B |
| Decrypt · ARIA-256-CBC (Managed)      | 1KB          |    21.219 μs | 0.0121 μs | 0.0108 μs |         - |
|                                       |              |              |           |           |           |
| Encrypt · ARIA-256-CBC (BouncyCastle) | 1KB          |    18.435 μs | 0.0333 μs | 0.0295 μs |    3736 B |
| Encrypt · ARIA-256-CBC (Managed)      | 1KB          |    21.286 μs | 0.0111 μs | 0.0104 μs |         - |
|                                       |              |              |           |           |           |
| Decrypt · ARIA-256-CBC (BouncyCastle) | 8KB          |   141.994 μs | 0.2160 μs | 0.2020 μs |   21656 B |
| Decrypt · ARIA-256-CBC (Managed)      | 8KB          |   167.412 μs | 0.0720 μs | 0.0674 μs |         - |
|                                       |              |              |           |           |           |
| Encrypt · ARIA-256-CBC (BouncyCastle) | 8KB          |   141.703 μs | 0.1907 μs | 0.1592 μs |   21656 B |
| Encrypt · ARIA-256-CBC (Managed)      | 8KB          |   167.863 μs | 0.0773 μs | 0.0723 μs |         - |
|                                       |              |              |           |           |           |
| Decrypt · ARIA-256-CBC (BouncyCastle) | 128KB        | 2,254.305 μs | 3.0537 μs | 2.8565 μs |  328856 B |
| Decrypt · ARIA-256-CBC (Managed)      | 128KB        | 2,678.686 μs | 1.9391 μs | 1.8138 μs |         - |
|                                       |              |              |           |           |           |
| Encrypt · ARIA-256-CBC (BouncyCastle) | 128KB        | 2,237.491 μs | 3.6037 μs | 3.3709 μs |  328856 B |
| Encrypt · ARIA-256-CBC (Managed)      | 128KB        | 2,684.485 μs | 0.8334 μs | 0.6507 μs |         - |