| Description                           | TestDataSize | Mean         | Error     | StdDev    | Allocated |
|-------------------------------------- |------------- |-------------:|----------:|----------:|----------:|
| Decrypt · ARIA-128-CBC (Managed)      | 128B         |     2.226 μs | 0.0014 μs | 0.0013 μs |         - |
| Decrypt · ARIA-128-CBC (BouncyCastle) | 128B         |     2.336 μs | 0.0050 μs | 0.0047 μs |    1288 B |
|                                       |              |              |           |           |           |
| Encrypt · ARIA-128-CBC (Managed)      | 128B         |     2.235 μs | 0.0013 μs | 0.0012 μs |         - |
| Encrypt · ARIA-128-CBC (BouncyCastle) | 128B         |     2.288 μs | 0.0030 μs | 0.0028 μs |    1288 B |
|                                       |              |              |           |           |           |
| Decrypt · ARIA-128-CBC (BouncyCastle) | 1KB          |    14.411 μs | 0.0165 μs | 0.0146 μs |    3528 B |
| Decrypt · ARIA-128-CBC (Managed)      | 1KB          |    15.966 μs | 0.0078 μs | 0.0073 μs |         - |
|                                       |              |              |           |           |           |
| Encrypt · ARIA-128-CBC (BouncyCastle) | 1KB          |    14.045 μs | 0.0118 μs | 0.0105 μs |    3528 B |
| Encrypt · ARIA-128-CBC (Managed)      | 1KB          |    16.044 μs | 0.0078 μs | 0.0069 μs |         - |
|                                       |              |              |           |           |           |
| Decrypt · ARIA-128-CBC (BouncyCastle) | 8KB          |   109.532 μs | 0.1260 μs | 0.1179 μs |   21448 B |
| Decrypt · ARIA-128-CBC (Managed)      | 8KB          |   125.877 μs | 0.0707 μs | 0.0591 μs |         - |
|                                       |              |              |           |           |           |
| Encrypt · ARIA-128-CBC (BouncyCastle) | 8KB          |   109.394 μs | 0.1387 μs | 0.1298 μs |   21448 B |
| Encrypt · ARIA-128-CBC (Managed)      | 8KB          |   126.431 μs | 0.0572 μs | 0.0535 μs |         - |
|                                       |              |              |           |           |           |
| Decrypt · ARIA-128-CBC (BouncyCastle) | 128KB        | 1,735.399 μs | 1.8963 μs | 1.7738 μs |  328648 B |
| Decrypt · ARIA-128-CBC (Managed)      | 128KB        | 2,014.252 μs | 1.0882 μs | 1.0179 μs |         - |
|                                       |              |              |           |           |           |
| Encrypt · ARIA-128-CBC (BouncyCastle) | 128KB        | 1,717.304 μs | 1.1384 μs | 0.9506 μs |  328648 B |
| Encrypt · ARIA-128-CBC (Managed)      | 128KB        | 2,020.876 μs | 1.3611 μs | 1.2732 μs |         - |