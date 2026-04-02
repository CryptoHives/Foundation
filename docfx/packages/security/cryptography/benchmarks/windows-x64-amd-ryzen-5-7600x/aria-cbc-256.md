| Description                           | TestDataSize | Mean         | Error      | StdDev     | Allocated |
|-------------------------------------- |------------- |-------------:|-----------:|-----------:|----------:|
| Decrypt · ARIA-256-CBC (BouncyCastle) | 128B         |     3.193 μs |  0.0171 μs |  0.0143 μs |    1496 B |
| Decrypt · ARIA-256-CBC (Managed)      | 128B         |     3.317 μs |  0.0440 μs |  0.0412 μs |         - |
|                                       |              |              |            |            |           |
| Encrypt · ARIA-256-CBC (BouncyCastle) | 128B         |     3.051 μs |  0.0316 μs |  0.0296 μs |    1496 B |
| Encrypt · ARIA-256-CBC (Managed)      | 128B         |     3.283 μs |  0.0295 μs |  0.0261 μs |         - |
|                                       |              |              |            |            |           |
| Decrypt · ARIA-256-CBC (BouncyCastle) | 1KB          |    20.196 μs |  0.3179 μs |  0.2818 μs |    3736 B |
| Decrypt · ARIA-256-CBC (Managed)      | 1KB          |    23.413 μs |  0.1369 μs |  0.1214 μs |         - |
|                                       |              |              |            |            |           |
| Encrypt · ARIA-256-CBC (BouncyCastle) | 1KB          |    20.362 μs |  0.3135 μs |  0.2618 μs |    3736 B |
| Encrypt · ARIA-256-CBC (Managed)      | 1KB          |    23.490 μs |  0.1306 μs |  0.1221 μs |         - |
|                                       |              |              |            |            |           |
| Decrypt · ARIA-256-CBC (BouncyCastle) | 8KB          |   154.833 μs |  1.5984 μs |  1.4169 μs |   21656 B |
| Decrypt · ARIA-256-CBC (Managed)      | 8KB          |   184.569 μs |  1.3917 μs |  1.2337 μs |         - |
|                                       |              |              |            |            |           |
| Encrypt · ARIA-256-CBC (BouncyCastle) | 8KB          |   156.923 μs |  1.6273 μs |  1.4425 μs |   21656 B |
| Encrypt · ARIA-256-CBC (Managed)      | 8KB          |   186.950 μs |  2.4522 μs |  2.2938 μs |         - |
|                                       |              |              |            |            |           |
| Decrypt · ARIA-256-CBC (BouncyCastle) | 128KB        | 2,467.166 μs | 29.1114 μs | 25.8065 μs |  328856 B |
| Decrypt · ARIA-256-CBC (Managed)      | 128KB        | 3,040.122 μs | 54.0616 μs | 50.5692 μs |         - |
|                                       |              |              |            |            |           |
| Encrypt · ARIA-256-CBC (BouncyCastle) | 128KB        | 2,547.165 μs | 40.1627 μs | 37.5682 μs |  328856 B |
| Encrypt · ARIA-256-CBC (Managed)      | 128KB        | 2,987.826 μs | 54.8898 μs | 48.6584 μs |         - |