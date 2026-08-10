| Description                           | TestDataSize | Mean         | Error      | StdDev     | Allocated |
|-------------------------------------- |------------- |-------------:|-----------:|-----------:|----------:|
| Decrypt · ARIA-128-CBC (BouncyCastle) | 128B         |     2.447 μs |  0.0090 μs |  0.0080 μs |    1288 B |
| Decrypt · ARIA-128-CBC (Managed)      | 128B         |     2.458 μs |  0.0176 μs |  0.0147 μs |         - |
|                                       |              |              |            |            |           |
| Encrypt · ARIA-128-CBC (BouncyCastle) | 128B         |     2.383 μs |  0.0350 μs |  0.0328 μs |    1288 B |
| Encrypt · ARIA-128-CBC (Managed)      | 128B         |     2.534 μs |  0.0498 μs |  0.0489 μs |         - |
|                                       |              |              |            |            |           |
| Decrypt · ARIA-128-CBC (BouncyCastle) | 1KB          |    15.246 μs |  0.1806 μs |  0.1601 μs |    3528 B |
| Decrypt · ARIA-128-CBC (Managed)      | 1KB          |    17.551 μs |  0.0637 μs |  0.0565 μs |         - |
|                                       |              |              |            |            |           |
| Encrypt · ARIA-128-CBC (BouncyCastle) | 1KB          |    15.710 μs |  0.3127 μs |  0.3955 μs |    3528 B |
| Encrypt · ARIA-128-CBC (Managed)      | 1KB          |    17.795 μs |  0.2146 μs |  0.1792 μs |         - |
|                                       |              |              |            |            |           |
| Decrypt · ARIA-128-CBC (BouncyCastle) | 8KB          |   118.020 μs |  1.2635 μs |  1.1201 μs |   21448 B |
| Decrypt · ARIA-128-CBC (Managed)      | 8KB          |   138.427 μs |  0.5805 μs |  0.4532 μs |         - |
|                                       |              |              |            |            |           |
| Encrypt · ARIA-128-CBC (BouncyCastle) | 8KB          |   118.737 μs |  0.7789 μs |  0.7285 μs |   21448 B |
| Encrypt · ARIA-128-CBC (Managed)      | 8KB          |   143.474 μs |  2.1698 μs |  2.0296 μs |         - |
|                                       |              |              |            |            |           |
| Decrypt · ARIA-128-CBC (BouncyCastle) | 128KB        | 1,868.992 μs | 14.7834 μs | 13.1051 μs |  328648 B |
| Decrypt · ARIA-128-CBC (Managed)      | 128KB        | 2,244.941 μs | 26.0349 μs | 21.7403 μs |         - |
|                                       |              |              |            |            |           |
| Encrypt · ARIA-128-CBC (BouncyCastle) | 128KB        | 1,903.041 μs | 19.0678 μs | 17.8360 μs |  328648 B |
| Encrypt · ARIA-128-CBC (Managed)      | 128KB        | 2,241.878 μs | 10.3547 μs |  9.1791 μs |         - |