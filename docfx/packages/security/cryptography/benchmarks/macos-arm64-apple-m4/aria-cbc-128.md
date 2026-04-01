| Description                           | TestDataSize | Mean         | Error     | StdDev    | Allocated |
|-------------------------------------- |------------- |-------------:|----------:|----------:|----------:|
| Decrypt · ARIA-128-CBC (Managed)      | 128B         |     2.221 μs | 0.0083 μs | 0.0073 μs |         - |
| Decrypt · ARIA-128-CBC (BouncyCastle) | 128B         |     2.339 μs | 0.0087 μs | 0.0073 μs |    1288 B |
|                                       |              |              |           |           |           |
| Encrypt · ARIA-128-CBC (Managed)      | 128B         |     2.197 μs | 0.0079 μs | 0.0070 μs |         - |
| Encrypt · ARIA-128-CBC (BouncyCastle) | 128B         |     2.228 μs | 0.0071 μs | 0.0059 μs |    1288 B |
|                                       |              |              |           |           |           |
| Decrypt · ARIA-128-CBC (BouncyCastle) | 1KB          |    14.343 μs | 0.0478 μs | 0.0424 μs |    3528 B |
| Decrypt · ARIA-128-CBC (Managed)      | 1KB          |    15.985 μs | 0.0751 μs | 0.0703 μs |         - |
|                                       |              |              |           |           |           |
| Encrypt · ARIA-128-CBC (BouncyCastle) | 1KB          |    14.107 μs | 0.2760 μs | 0.2711 μs |    3528 B |
| Encrypt · ARIA-128-CBC (Managed)      | 1KB          |    15.848 μs | 0.0734 μs | 0.0613 μs |         - |
|                                       |              |              |           |           |           |
| Decrypt · ARIA-128-CBC (BouncyCastle) | 8KB          |   109.475 μs | 0.3934 μs | 0.3487 μs |   21448 B |
| Decrypt · ARIA-128-CBC (Managed)      | 8KB          |   126.115 μs | 0.3413 μs | 0.2850 μs |         - |
|                                       |              |              |           |           |           |
| Encrypt · ARIA-128-CBC (BouncyCastle) | 8KB          |   106.352 μs | 0.2397 μs | 0.2002 μs |   21448 B |
| Encrypt · ARIA-128-CBC (Managed)      | 8KB          |   125.575 μs | 0.4582 μs | 0.4062 μs |         - |
|                                       |              |              |           |           |           |
| Decrypt · ARIA-128-CBC (BouncyCastle) | 128KB        | 1,719.477 μs | 5.5217 μs | 4.8948 μs |  328648 B |
| Decrypt · ARIA-128-CBC (Managed)      | 128KB        | 2,023.756 μs | 9.2452 μs | 8.1956 μs |         - |
|                                       |              |              |           |           |           |
| Encrypt · ARIA-128-CBC (BouncyCastle) | 128KB        | 1,696.951 μs | 5.7161 μs | 5.0672 μs |  328648 B |
| Encrypt · ARIA-128-CBC (Managed)      | 128KB        | 2,021.430 μs | 8.8185 μs | 7.8173 μs |         - |