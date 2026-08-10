| Description                           | TestDataSize | Mean         | Error      | StdDev     | Allocated |
|-------------------------------------- |------------- |-------------:|-----------:|-----------:|----------:|
| Decrypt · ARIA-128-CBC (Managed)      | 128B         |     2.714 μs |  0.0529 μs |  0.0588 μs |         - |
| Decrypt · ARIA-128-CBC (BouncyCastle) | 128B         |     2.784 μs |  0.0551 μs |  0.0735 μs |    1288 B |
|                                       |              |              |            |            |           |
| Encrypt · ARIA-128-CBC (BouncyCastle) | 128B         |     2.640 μs |  0.0472 μs |  0.0418 μs |    1288 B |
| Encrypt · ARIA-128-CBC (Managed)      | 128B         |     2.792 μs |  0.0343 μs |  0.0321 μs |         - |
|                                       |              |              |            |            |           |
| Decrypt · ARIA-128-CBC (BouncyCastle) | 1KB          |    17.006 μs |  0.3281 μs |  0.3906 μs |    3528 B |
| Decrypt · ARIA-128-CBC (Managed)      | 1KB          |    19.115 μs |  0.1618 μs |  0.1263 μs |         - |
|                                       |              |              |            |            |           |
| Encrypt · ARIA-128-CBC (BouncyCastle) | 1KB          |    17.171 μs |  0.3305 μs |  0.3934 μs |    3528 B |
| Encrypt · ARIA-128-CBC (Managed)      | 1KB          |    19.702 μs |  0.2550 μs |  0.2385 μs |         - |
|                                       |              |              |            |            |           |
| Decrypt · ARIA-128-CBC (BouncyCastle) | 8KB          |   129.665 μs |  1.4121 μs |  1.3209 μs |   21448 B |
| Decrypt · ARIA-128-CBC (Managed)      | 8KB          |   154.274 μs |  2.0972 μs |  1.9617 μs |         - |
|                                       |              |              |            |            |           |
| Encrypt · ARIA-128-CBC (BouncyCastle) | 8KB          |   132.466 μs |  2.5480 μs |  2.5025 μs |   21448 B |
| Encrypt · ARIA-128-CBC (Managed)      | 8KB          |   155.422 μs |  3.0345 μs |  2.9803 μs |         - |
|                                       |              |              |            |            |           |
| Decrypt · ARIA-128-CBC (BouncyCastle) | 128KB        | 2,111.599 μs | 41.6075 μs | 46.2466 μs |  328648 B |
| Decrypt · ARIA-128-CBC (Managed)      | 128KB        | 2,420.193 μs | 19.2853 μs | 16.1041 μs |         - |
|                                       |              |              |            |            |           |
| Encrypt · ARIA-128-CBC (BouncyCastle) | 128KB        | 2,136.619 μs | 42.7241 μs | 41.9607 μs |  328648 B |
| Encrypt · ARIA-128-CBC (Managed)      | 128KB        | 2,471.062 μs | 47.0090 μs | 43.9722 μs |         - |