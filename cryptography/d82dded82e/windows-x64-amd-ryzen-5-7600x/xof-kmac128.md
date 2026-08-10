| Description                             | TestDataSize | Mean       | Error     | StdDev    | Allocated |
|---------------------------------------- |------------- |-----------:|----------:|----------:|----------:|
| AbsorbSqueeze · KMAC-128 · Managed      | 128B         |   3.137 μs | 0.0127 μs | 0.0106 μs |         - |
| AbsorbSqueeze · KMAC-128 · OS Native    | 128B         |   3.862 μs | 0.0266 μs | 0.0236 μs |      32 B |
| AbsorbSqueeze · KMAC-128 · BouncyCastle | 128B         |   4.986 μs | 0.0189 μs | 0.0177 μs |     128 B |
|                                         |              |            |           |           |           |
| AbsorbSqueeze · KMAC-128 · Managed      | 1KB          |   4.846 μs | 0.0319 μs | 0.0266 μs |         - |
| AbsorbSqueeze · KMAC-128 · OS Native    | 1KB          |   5.261 μs | 0.0352 μs | 0.0329 μs |      32 B |
| AbsorbSqueeze · KMAC-128 · BouncyCastle | 1KB          |   6.893 μs | 0.0170 μs | 0.0151 μs |    1280 B |
|                                         |              |            |           |           |           |
| AbsorbSqueeze · KMAC-128 · OS Native    | 8KB          |  15.210 μs | 0.0496 μs | 0.0414 μs |      32 B |
| AbsorbSqueeze · KMAC-128 · Managed      | 8KB          |  17.349 μs | 0.1498 μs | 0.1401 μs |         - |
| AbsorbSqueeze · KMAC-128 · BouncyCastle | 8KB          |  20.355 μs | 0.0940 μs | 0.0833 μs |    9344 B |
|                                         |              |            |           |           |           |
| AbsorbSqueeze · KMAC-128 · OS Native    | 128KB        | 188.629 μs | 1.2776 μs | 1.1326 μs |      32 B |
| AbsorbSqueeze · KMAC-128 · Managed      | 128KB        | 233.733 μs | 1.0369 μs | 0.9191 μs |         - |
| AbsorbSqueeze · KMAC-128 · BouncyCastle | 128KB        | 255.404 μs | 1.9300 μs | 1.8054 μs |  149888 B |